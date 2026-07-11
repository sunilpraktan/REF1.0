using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Presentation.Services
{
    public class UserCredentials
    {
        public void SetUserCredentials()
        {
            try
            {
                //To check if you're connected or not:
                bool NetworkExists = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                string hostName = Dns.GetHostName(); // Retrive the Name of HOST
                AppSessionState.UserSource1 = hostName;
                AppSessionState.UserSource1 = AppSessionState.UserSource1 + "/" + GetLocalIPAddress();

                // Get the IP
                //string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
                //string myIP2 = Dns.GetHostEntry(hostName).AddressList[1].ToString();

                IPAddress ipa = LocalIPAddress();

                string MAC_ID1 = GetMACAddress1();
                string MAC_ID2 = GetMACAddress2();
                //string strUUID = GetUUID();
                AppSessionState.UserSource2 = MAC_ID1 + "/" + MAC_ID2;
            }
            catch(Exception ex)
            { }
        }

        public static string GetLocalIPAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
                return "Unidentified";
                //throw new Exception("Local IP Address Not Found!");
            }
            catch(Exception ex)
            { }
            return "Unidentified";
        }
        private IPAddress LocalIPAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }
        //From System.Net namespace:
        public static string GetMACAddress1()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            try
            {
                
                foreach (NetworkInterface adapter in nics)
                {
                    if (sMacAddress == String.Empty)// only return MAC Address from first card  
                    {
                        //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                        sMacAddress = adapter.GetPhysicalAddress().ToString();
                    }
                }
            }
            catch (Exception ex)
            { }
            return sMacAddress;
        }

        //MAC From WMI:
        public static string GetMACAddress2()
        {
            ManagementObjectSearcher objMOS = new ManagementObjectSearcher("Select * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMOS.Get();
            string macAddress = String.Empty;
            try
            {
                
                foreach (ManagementObject objMO in objMOC)
                {
                    object tempMacAddrObj = objMO["MacAddress"];

                    if (tempMacAddrObj == null) //Skip objects without a MACAddress
                    {
                        continue;
                    }
                    if (macAddress == String.Empty) // only return MAC Address from first card that has a MAC Address
                    {
                        macAddress = tempMacAddrObj.ToString();
                    }
                    objMO.Dispose();
                }
                macAddress = macAddress.Replace(":", "");
            }
            catch (Exception ex)
            { }
            return macAddress;
        }

        public string GetUUID()
        {
            try
            {
                var procStartInfo = new ProcessStartInfo("cmd", "/c " + "wmic csproduct get UUID")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                var proc = new Process() { StartInfo = procStartInfo };
                proc.Start();

                return proc.StandardOutput.ReadToEnd().Replace("UUID", string.Empty).Trim().ToUpper();
            }
            catch(Exception ex)
            { }
            return "Unidentified";
        }
    }
}
