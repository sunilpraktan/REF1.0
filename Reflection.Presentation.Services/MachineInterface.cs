using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows; // WPF

namespace Reflection.Presentation.Services
{
    public static class MachineInterface
    {
        // ===================== SESSION LIFECYCLE =====================

        public static SerialPort StartComportSession(SerialPort serialPort, string portName, int baud, Parity parity, int dataBits, StopBits stopBits, Handshake handshake, StringBuilder rxBuffer, bool drainActive, DateTime lastByteAt)
        {
            StopSessionAndDispose(serialPort, rxBuffer, drainActive, lastByteAt); // ensure clean slate

            serialPort = new SerialPort(portName, baud, parity, dataBits, stopBits);
            serialPort.Handshake = handshake;   // mirror HyperTerminal
            serialPort.DtrEnable = true;        // flip to false if your device wants it
            serialPort.RtsEnable = true;        // if using RTS/CTS Handshake, let driver manage RTS (set false)
            serialPort.Encoding = Encoding.ASCII;
            serialPort.ReadTimeout = 3000;
            serialPort.WriteTimeout = 500;
            serialPort.NewLine = "\r";
            serialPort.ReceivedBytesThreshold = 1;

            try
            {
                // attach BEFORE open
                //serialPort.DataReceived += OnSerialDataReceived;
                serialPort.Open();
                lastByteAt = DateTime.UtcNow; //here value getting but see is it useful or not , and see that can we remove line
                Console.WriteLine("✅ Port " + serialPort.PortName + " opened. Listening...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("⚠ Serial port open failed: " + ex.Message);
            }

            return serialPort;
        }

        public static void StopSessionAndDispose(SerialPort serialPort, StringBuilder rxBuffer, bool drainActive, DateTime lastByteAt)
        {
            try
            {
                if (serialPort != null)
                {
                    try
                    {
                        serialPort.DataReceived += async (s, e) =>
                        {
                            await OnSerialDataReceived(s, e, drainActive, serialPort, rxBuffer, lastByteAt);
                        };
                    }
                    catch { }
                    try { if (serialPort.IsOpen) serialPort.DiscardInBuffer(); } catch { }
                    try { if (serialPort.IsOpen) serialPort.DiscardOutBuffer(); } catch { }
                    try { if (serialPort.IsOpen) serialPort.Close(); } catch { }
                    try { serialPort.Dispose(); } catch { }
                }
            }
            catch { }
            finally
            {
                serialPort = null;
                lock (rxBuffer) rxBuffer.Clear();
                drainActive = false;
            }
            Console.WriteLine("ℹ Session stopped & disposed.");
        }

        // ===================== DATARECEIVED + DRAIN =====================

        public static async Task<decimal> OnSerialDataReceived(object sender, SerialDataReceivedEventArgs e, bool drainActive, SerialPort serialPort, StringBuilder rxBuffer, DateTime lastByteAt)
        {
            // start a single drain per burst
            if (drainActive) return 0;
            drainActive = true;
            return await DrainIncomingAsync(serialPort, rxBuffer, drainActive, lastByteAt);
        }

        private static async Task<decimal> DrainIncomingAsync(SerialPort serialPort, StringBuilder rxBuffer, bool drainActive, DateTime lastByteAt)
        {
            decimal latestStableWeight = 0;

            try
            {
                TimeSpan idleThreshold = TimeSpan.FromMilliseconds(30); // end draining after 30ms of silence

                while (serialPort != null && serialPort.IsOpen)
                {
                    bool readSomething = false;

                    // drain everything currently buffered
                    while (serialPort.BytesToRead > 0)
                    {
                        string chunk = serialPort.ReadExisting();
                        lastByteAt = DateTime.UtcNow;
                        readSomething = true;

                        if (!string.IsNullOrEmpty(chunk))
                        {
                            lock (rxBuffer)
                            {
                                rxBuffer.Append(chunk);

                                int idx;
                                while ((idx = IndexOfTerminator(rxBuffer)) >= 0)
                                {
                                    string line = rxBuffer.ToString(0, idx);
                                    RemoveThroughTerminator(rxBuffer, idx);
                                    latestStableWeight = ProcessLine(line);
                                }
                            }
                        }
                    }

                    if (readSomething) continue; // more may arrive right away

                    // nothing buffered now; if quiet long enough, stop draining
                    if ((DateTime.UtcNow - lastByteAt) >= idleThreshold)
                        break;

                    await Task.Delay(5); 
                }  
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Drain error: " + ex.Message);
            }
            finally
            {
                drainActive = false;
            }

            return latestStableWeight;
        }

        // ===================== BUFFER → LINES → PROCESS =====================

        private static int IndexOfTerminator(StringBuilder sb)
        {
            for (int i = 0; i < sb.Length; i++)
            {
                char c = sb[i];
                if (c == '\r' || c == '\n') return i;
            }
            return -1;
        }

        private static void RemoveThroughTerminator(StringBuilder sb, int idx)
        {
            sb.Remove(0, idx);
            while (sb.Length > 0 && (sb[0] == '\r' || sb[0] == '\n'))
                sb.Remove(0, 1);
        }

        private static decimal ProcessLine(string rawLine)
        {
            if (string.IsNullOrWhiteSpace(rawLine)) return 0;
            string line = rawLine.Trim();

            // ignore echoes / statuses
            string up = line.ToUpperInvariant();
            if (up == "P" || up == "SI" || up == "IP" || up == "S" || up == "ES" || up == "US" || up == "OL" || up == "OK")
                return 0;

            Console.WriteLine("📥 " + line);

            decimal latestStableWeight = 0;
            if (TryParseWeight(line, out var numeric))
            {
                latestStableWeight = numeric;
            }

            return latestStableWeight;
        }

        // ===================== PARSING =====================

        private static bool TryParseWeight(string line, out decimal weight)
        {
            weight = 0;
            string s = line.Trim();

            // Drop short status prefix like "ST," / "US," / "ES,"
            int comma = s.IndexOf(',');
            if (comma >= 0 && comma < 4)
                s = s.Substring(comma + 1).Trim();   // works in 4.7 ✅

            // Remove trailing unit (g)
            if (s.EndsWith("g", StringComparison.OrdinalIgnoreCase))
                s = s.Substring(0, s.Length - 1).Trim();

            return decimal.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out weight);
        }


        // ===================== OPTIONAL: DETECT PORT =====================
        public static string DetectScalePort()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%(COM%'"))
                {
                    foreach (ManagementObject device in searcher.Get())
                    {
                        object nameObj = device["Name"];
                        string name = nameObj == null ? null : nameObj.ToString();
                        if (string.IsNullOrWhiteSpace(name)) continue;

                        int i = name.LastIndexOf("(COM", StringComparison.OrdinalIgnoreCase);
                        if (i >= 0)
                        {
                            int j = name.IndexOf(')', i);
                            if (j > i)
                            {
                                string port = name.Substring(i + 1, j - i - 1);

                                // Filter based on known keywords
                                if (name.IndexOf("(COM", StringComparison.OrdinalIgnoreCase) >= 0 &&
                                   (name.IndexOf("OHAUS", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    name.IndexOf("USB", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    name.IndexOf("Prolific", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    name.IndexOf("CH340", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    name.IndexOf("FTDI", StringComparison.OrdinalIgnoreCase) >= 0))
                                {
                                    return port;
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("⚠ Error detecting COM ports: " + ex.Message);
            }

            return "COM4"; // fallback for your testing; change to null + prompt after verification
        }
    }
}

