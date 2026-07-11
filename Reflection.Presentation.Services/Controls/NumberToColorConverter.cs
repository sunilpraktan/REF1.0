using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Reflection.Presentation.Services
{
    [ValueConversion(typeof(object), typeof(int))]
    public class NumberToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double number = (double)System.Convert.ChangeType(value, typeof(double));

            if (number <= 0.0)
                return 0;
            if (number > 0.0)
                return 1;
            else
                return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("ConvertBack not supported");
        }
    }


    // Convert value into specific color
    [ValueConversion(typeof(object), typeof(int))]
    public class ValueToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //string obj_value = (value ?? "").ToString();
            string color_code = null;
            if (!string.IsNullOrWhiteSpace(value.ToString()))
            {
                color_code = "#8CD9B3";
                switch (value.ToString().ToLower())
                {
                    case "":
                    case "yes":
                    case "y":
                    case "A":
                        return color_code;
                    case "0":
                    case "no":
                    case "D":
                    case "N":
                    case null:

                        return color_code;

                }
            }
            return color_code;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("ConvertBack not supported");
        }
    }
}
