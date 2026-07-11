
using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.ComponentModel;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace Reflection.Presentation.Services
{

    public class IsGreaterThanZero : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (decimal.Parse(value.ToString()) == 0)
            {
                return 0;
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    public class IsGreaterThanZeroOrLessOrEqual : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (decimal.Parse(value.ToString()) > 0)
            {
                return "G";
            }
            else if (decimal.Parse(value.ToString()) < 0)
            {
                return "L";
            }
            else
            {
                return "E";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}