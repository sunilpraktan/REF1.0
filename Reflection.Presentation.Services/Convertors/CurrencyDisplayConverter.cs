using System;
using System.Globalization;
using System.Windows.Data;

namespace Reflection.Presentation.Services.Convertors
{
    public class CurrencyDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    if (value is decimal)
                    {
                        var dValue = value as decimal?;
                        var nfi = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
                        if (Settings.curr_notation == false && parameter != null)
                        {
                            nfi.CurrencySymbol = parameter.ToString().Split('!')[0];
                        }
                        else if (Settings.curr_notation == true && parameter != null)
                        {
                            nfi.CurrencySymbol = parameter.ToString().Split('!')[1];
                        }

                        // Get the Default Culture 3 characters notation
                        //CultureInfo ci = new CultureInfo(Settings.def_culture);
                        //var ri = new RegionInfo(ci.LCID);
                        //string currency_code = ri.ISOCurrencySymbol;

                        //if prefix currency
                        if (Settings.value_suffix == false)
                        {
                            nfi.CurrencyPositivePattern = 2;
                            nfi.CurrencyNegativePattern = 2;
                        }
                        //if suffix currency
                        else if (Settings.value_suffix == true)
                        {
                            nfi.CurrencyPositivePattern = 3;
                            nfi.CurrencyNegativePattern = 3;
                        }
                        value = string.Format(nfi, "{0:C}", value);
                        return value;
                    }
                    return value;
                }
                return value;
            }
            catch (Exception ex) { return value; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal)
            {
                return value;
            }
            return value;
        }
    }
}
