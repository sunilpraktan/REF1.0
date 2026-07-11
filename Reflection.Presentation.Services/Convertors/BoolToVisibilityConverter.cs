using System;
using System.Windows;
using System.Windows.Data;

namespace Reflection.Presentation.Services
{
    /// <summary>
    /// Returns visible when a bool is true.
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException("NotImplemented");
        }

        #endregion
    }

    /// <summary>
    /// Returns hidden when a bool is true.
    /// </summary>
    public class NotBoolToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException("NotImplemented");
        }

        

        #endregion
    }

    public class DataGridColumnVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                switch (value.ToString().ToLower())
                {
                    case "1":
                    case "2": // User Type level 1&2 have view permission.
                    case "Y":
                    case "y":
                    case "A":
                        return Visibility.Visible;
                    case "n":
                    case "N":
                    case "0":
                    case "3":
                    case "4":
                    case "":
                    case null:
                        return Visibility.Collapsed;
                }
            }
            else
            {
                return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        //public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //{
        //    Visibility vb = Visibility.Collapsed;

        //    if (value != null)
        //    {
        //        if (value.ToString().ToLower() == "1")
        //        {
        //            vb = Visibility.Visible;
        //            return Visibility.Visible;
        //        }
        //        else if (value.ToString().ToLower() == "y")
        //        {
        //            vb = Visibility.Visible;
        //            return Visibility.Visible;
        //        }
        //        else if (value.ToString().ToLower() == "a")
        //        {
        //            vb = Visibility.Visible;
        //            return Visibility.Visible;
        //        }
        //        else if (value.ToString().ToLower() == "0")
        //        {
        //            vb = Visibility.Collapsed;
        //            return Visibility.Collapsed;
        //        }
        //        else if (value.ToString().ToLower() == "n")
        //        {
        //            vb = Visibility.Collapsed;
        //            return Visibility.Collapsed;
        //        }

        //        //switch (value.ToString().ToLower())
        //        //{
        //        //    case "1":
        //        //    case "Y":
        //        //    case "y":
        //        //    case "A":
        //        //        return Visibility.Visible;
        //        //    case "n":
        //        //    case "N":
        //        //    case "0":
        //        //        return Visibility.Collapsed;
        //        //}
        //    }
        //    else
        //    {
        //        return Visibility.Collapsed;
        //    }
        //    return vb;
        //}

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}


//switch (parameter.ToString().ToLower())
//       {
//            case "data1":
//                 return (!String.IsNullOrEmpty(viewModel.Data1)) ? Visibility.Visible : Visibility.Collapsed;
//       }