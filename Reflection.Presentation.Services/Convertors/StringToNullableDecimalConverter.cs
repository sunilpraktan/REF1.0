using System;
using System.Globalization;
using System.Windows.Data;

namespace Reflection.Presentation.Services
{
    public class StringToNullableDecimalConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            object value = values[1];
            if (value != null)
            {
                if (value is decimal)
                {
                    value = values[0] + " " + DoFormat(value);
                }
                return value;
            }
            return value;
        }  
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public string DoFormat(object value)
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

        //public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //{
        //    if (value == null)
        //    {
        //        return 0;
        //    }
        //    else if (value is string || (string)value.ToString() == "")
        //    {
        //        return 0;
        //    }

        //    return value;
        //}

        //public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //{
        //    if (value is string && (string)value == "")
        //    {
        //        return 0;
        //    }

        //    return value;
        //}
    }
}
