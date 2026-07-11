using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Reflection.Presentation.Services.Convertors
{
    public class CustomDecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    value = System.Convert.ToDecimal(value);
                    if (value is decimal)
                    {
                        value = DoUserFormat(value);
                    }
                    return value;
                }
                return value;
            }
            catch (Exception Ex) { return value; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                string str = value.ToString();
                string text = str;
                foreach (char ch in text)
                {
                    if (!Char.IsDigit(ch))
                    {
                        if (ch.ToString() != NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
                        {
                            if (ch.ToString() != NumberFormatInfo.CurrentInfo.NumberGroupSeparator)
                            {
                                if (ch.ToString() != NumberFormatInfo.CurrentInfo.NegativeSign)
                                {
                                    str = str.Replace(ch.ToString(), String.Empty);
                                }
                            }
                        }
                    }
                }
                if (str.Contains(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator))
                {
                    int ind = str.IndexOf(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
                    if (ind == -1)
                    {
                        return str;
                    }
                    else
                    {
                        if (str.Contains(NumberFormatInfo.CurrentInfo.NegativeSign))
                        {
                            str = str.Replace((NumberFormatInfo.CurrentInfo.NegativeSign).ToString(), String.Empty);
                            str = NumberFormatInfo.CurrentInfo.NegativeSign + str;
                        }
                        return str + "0";
                    }
                }
                if (str.Contains(NumberFormatInfo.CurrentInfo.NegativeSign))
                {
                    str = str.Replace((NumberFormatInfo.CurrentInfo.NegativeSign).ToString(), String.Empty);
                    return (NumberFormatInfo.CurrentInfo.NegativeSign) + str;
                }
                return str;
            }
            return value;
        }

        #region Private static Methods
        private static string DoFormat(object value)
        {
            string str = value.ToString();
            if (str.Contains(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator))
            {
                int ind = str.IndexOf(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
                if (ind == -1)
                {
                    return str;
                }
                else
                {
                    string text = str.Substring(ind);
                    if (text != ".0")
                    {
                        var s = string.Format("{0:#,#0.0###########}", value);
                        return s;
                    }
                    else if (text == ".0")
                    {
                        var s = string.Format("{0:#,#0.0}", value);
                        return s;
                    }
                }
            }
            else
            {
                str = string.Format("{0:#,#0}", value);
            }
            return str;
        }
        private static string DoUserFormat(object value)
        {
            string str = value.ToString();
            if (str.Contains(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator))
            {
                int ind = str.IndexOf(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
                if (ind == -1)
                {
                    return str;
                }
                else
                {
                    bool roundup = Settings.round_up; //user input
                    string text = str.Substring(ind);
                    string s;
                    int digitinput = Settings.decimal_digits; //user input
                    switch (digitinput)
                    {
                        case 0:
                            s = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0###########}", value);
                            return s;
                        case 1:
                            if (roundup == false)
                            {
                                decimal d = System.Convert.ToDecimal(str);
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0}", Math.Floor(d * 10) / 10);
                                return str;
                            }
                            else if (roundup == true)
                            {
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0}", value);
                                return str;
                            }
                            return str;
                        case 2:
                            if (roundup == false)
                            {
                                decimal d = System.Convert.ToDecimal(str);
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00}", Math.Floor(d * 100) / 100);
                                return str;
                            }
                            else if (roundup == true)
                            {
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00}", value);
                                return str;
                            }
                            return str;
                        case 3:
                            //s = string.Format("{0:#,#0.000}", value);
                            //if ui = 3 then multiply decimal by 1000 and divide by 1000
                            if (roundup == false)
                            {
                                decimal d = System.Convert.ToDecimal(str);
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "000}", Math.Floor(d * 1000) / 1000);
                                return str;
                            }
                            else if (roundup == true)
                            {
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "000}", value);
                                return str;
                            }
                            return str;
                        case 4:
                            if (roundup == false)
                            {
                                decimal d = System.Convert.ToDecimal(str);
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0000}", Math.Floor(d * 10000) / 10000);
                                return str;
                            }
                            else if (roundup == true)
                            {
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0000}", value);
                                return str;
                            }
                            return str;
                        case 5:
                            if (roundup == false)
                            {
                                decimal d = System.Convert.ToDecimal(str);
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00000}", Math.Floor(d * 100000) / 100000);
                                return str;
                            }
                            else if (roundup == true)
                            {
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00000}", value);
                                return str;
                            }
                            return str;
                        case 6:
                            if (roundup == false)
                            {
                                decimal d = System.Convert.ToDecimal(str);
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "000000}", Math.Floor(d * 1000000) / 1000000);
                                return str;
                            }
                            else if (roundup == true)
                            {
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "000000}", value);
                                return str;
                            }
                            return str;
                        case 7:
                            if (roundup == false)
                            {
                                decimal d = System.Convert.ToDecimal(str);
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0000000}", Math.Floor(d * 10000000) / 10000000);
                                return str;
                            }
                            else if (roundup == true)
                            {
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0000000}", value);
                                return str;
                            }
                            return str;
                        case 8:
                            if (roundup == false)
                            {
                                decimal d = System.Convert.ToDecimal(str);
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00000000}", Math.Floor(d * 100000000) / 100000000);
                                return str;
                            }
                            else if (roundup == true)
                            {
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00000000}", value);
                                return str;
                            }
                            return str;
                        case 9:
                            if (roundup == false)
                            {
                                decimal d = System.Convert.ToDecimal(str);
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "000000000}", Math.Floor(d * 1000000000) / 1000000000);
                                return str;
                            }
                            else if (roundup == true)
                            {
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "000000000}", value);
                                return str;
                            }
                            return str;
                        case 10:
                            if (roundup == false)
                            {
                                decimal d = System.Convert.ToDecimal(str);
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0000000000}", Math.Floor(d * 10000000000) / 10000000000);
                                return str;
                            }
                            else if (roundup == true)
                            {
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0000000000}", value);
                                return str;
                            }
                            return str;
                        case 11:
                            if (roundup == false)
                            {
                                decimal d = System.Convert.ToDecimal(str);
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00000000000}", Math.Floor(d * 100000000000) / 100000000000);
                                return str;
                            }
                            else if (roundup == true)
                            {
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00000000000}", value);
                                return str;
                            }
                            return str;
                        case 12:
                            if (roundup == false)
                            {
                                decimal d = System.Convert.ToDecimal(str);
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "000000000000}", Math.Floor(d * 1000000000000) / 1000000000000);
                                return str;
                            }
                            else if (roundup == true)
                            {
                                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "000000000000}", value);
                                return str;
                            }
                            return str;
                        default:
                            s = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0###########}", value);
                            return s;
                    }
                }
            }
            else
            {
                str = string.Format("{0:#" + NumberFormatInfo.CurrentInfo.NumberGroupSeparator + "#0}", value);
            }
            return str;
        }

        #endregion
    }   
}
