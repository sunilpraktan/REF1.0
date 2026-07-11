using System;
using System.Globalization;
using System.Windows.Data;

namespace Reflection.Presentation.Services
{
    /// <summary>
    /// Returns true when a bool is true.
    /// </summary>
    public class BoolConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException("NotImplemented");
        }

        #endregion
    }

    /// <summary>
    /// Returns false when a bool is true.
    /// </summary>
    public class NotBoolConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException("NotImplemented");
        }

        #endregion
    }

    /// <summary>
    /// Returns false when a bool is true.
    /// </summary>
    public class NotConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException("NotImplemented");
        }

        #endregion
    }

    /// <summary>
    /// Returns Boolean Value when a object is string.
    /// </summary>
    public class StringToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                switch (value.ToString().ToLower())
                {
                    case "1":
                    case "yes":
                    case "y":
                    case "A":
                        return true;
                    case "0":
                    case "no":
                    case "D":
                    case "N":
                    case null:

                        return false;

                }
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                if (value is bool)
                {
                    if ((bool)value == true)
                        return "1";
                    else
                        return "0";

                }
            }
            return false;
        }
    }

    public class BoolToPrimaryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                return ((value as string).Equals("Y")) ? true : false;
            }
            else
                return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                return (bool)value ? "Y" : "N";
            }
            else
                return value;
        }
    }


    /// <summary>
    /// Returns Boolean Reverse Value.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InverseBooleanConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException("The target must be a boolean");

            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
