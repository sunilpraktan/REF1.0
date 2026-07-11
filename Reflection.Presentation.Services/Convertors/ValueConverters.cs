using Reflection.BusinessEntity;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;

namespace Reflection.Presentation.Services.Convertors
{
    #region File Converter
    public class FileConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string returnPath;
            try
            {
                //var fileObject = (FileObject)value;

                string internalPath = "pack://application:,,,/Reflection.Presentation.Resources;component/Images/{0}.ico";
                FileInfo fileInfo = new FileInfo(value.ToString());
                switch (fileInfo.Extension.ToLower())
                {
                    case ".doc":
                    case ".docx":
                        returnPath = string.Format(internalPath, "word");
                        break;
                    case ".xls":
                    case ".xlsx":
                        returnPath = string.Format(internalPath, "excel");
                        break;
                    case ".ppt":
                    case ".pptx":
                        returnPath = string.Format(internalPath, "powerpoint");
                        break;
                    case ".pdf":
                        returnPath = string.Format(internalPath, "pdf");
                        break;
                    case ".zip":
                        returnPath = string.Format(internalPath, "zip");
                        break;
                    case ".rar":
                        returnPath = string.Format(internalPath, "rar");
                        break;
                    default:
                        returnPath = System.Environment.CurrentDirectory + "\\temp\\" + value.ToString();
                        break;
                }
                return returnPath;

                //ShellFile shellFile = ShellFile.FromFilePath(value.ToString());
                //return shellFile.Thumbnail.BitmapSource;

                // Use BitmapCacheOption.OnLoad to prevent binding the source holding on to the photo file.
                //bitmap.CacheOption = BitmapCacheOption.OnLoad;

                //return bitmap;
            }
            catch
            {
                return value.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region FileName Converter
    public class FileNameConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;
            try
            {
                FileInfo fileInfo = new FileInfo(value.ToString());

                return fileInfo.Name;
            }
            catch
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region FileName Trimmer
    public class FileNameTrimmer : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(value.ToString());

                if (fileInfo.Name.Length > 25)
                    return fileInfo.Name.Substring(0, 25) + "...";
                return fileInfo.Name;
            }
            catch
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region Image Path Converter
    public class ImagePathConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;
            try
            {
                var fileObject = (COM_T003)value;
                if (fileObject.IsUploaded)
                {
                    //return System.Environment.CurrentDirectory.Replace("\\bin\\Debug", "\\temp\\" + fileObject.FilePath);
                    return System.Environment.CurrentDirectory + "\\temp\\" + fileObject.client + "\\" + fileObject.comp_code + "\\" + fileObject.FilePath;
                    //return "temp/" + fileObject.FilePath;
                }
                return fileObject.FilePath;
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //throw new NotImplementedException();
            return null;
        }
    }
    #endregion

    public class MultivalueConvertorStandard : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new Tuple<String, String>((String)values[0], (String)values[1]); ;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    #region DoubleToIntegerConverter

    [ValueConversion(typeof(double), typeof(int))]
    public class DoubleToIntegerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)(double)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }

    #endregion // DoubleToIntegerConverter	

    #region ProgressTrackWidthConverter

    /// <summary>
    /// Determines how wide a RaceHorse's progress indicator should be, based on how far into the race it is.
    /// </summary>
    public class ProgressIndicatorWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int percentComplete = (int)values[0];
            double availableWidth = (double)values[1];
            double width = Math.Floor(availableWidth * (percentComplete / 100.0));
            // Reduce the final width by a little bit to avoid a minor rendering overlap.
            return percentComplete == 100 ? width - 4 : width;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }

    #endregion // RaceTrackWidthConverter	

    //*************************************** Autosuggest Convertors Start *********************************************** 

    public class BooleanToVisibilityConverter : IValueConverter
    {
        public static readonly BooleanToVisibilityConverter Instance = new BooleanToVisibilityConverter();

        private BooleanToVisibilityConverter() { }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visible = false;
            if (value is bool) visible = (bool)value;
            else if (value is string) Boolean.TryParse((string)value, out visible);

            return visible ? Visibility.Visible : Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visible = Visibility.Visible;
            if (value is Visibility) visible = (Visibility)value;
            else if (value is string) VisibilityTryParse((string)value, out visible);

            return visible == Visibility.Visible;
        }

        private bool VisibilityTryParse(string value, out Visibility result)
        {
            switch (value.ToUpper())
            {
                case "VISIBLE": result = Visibility.Visible; return true;
                case "HIDDEN": result = Visibility.Hidden; return true;
                case "COLLAPSED": result = Visibility.Collapsed; return true;
                default: result = Visibility.Visible; return false;
            }
        }
    }

    public class ValueConverter : IValueConverter
    {
        public ValueConverter(Func<object, object> convert, Func<object, object> convertBack = null)
        {
            _convert = convert;
            _convertBack = convertBack;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) { return _convert(value); }
        private readonly Func<object, object> _convert;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (_convertBack == null) throw new NotImplementedException();

            return _convertBack(value);
        }
        private readonly Func<object, object> _convertBack;
    }

    public class IgnoreNewItemPlaceHolderConverter : IValueConverter
    {
        public static readonly IgnoreNewItemPlaceHolderConverter Instance = new IgnoreNewItemPlaceHolderConverter();

        private const string NewItemPlaceholderName = "{NewItemPlaceholder}";

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value.ToString() == NewItemPlaceholderName)
                return null;// DependencyProperty.UnsetValue;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value.ToString() == NewItemPlaceholderName)
                return null;// DependencyProperty.UnsetValue;
            return value;
        }
    }

    public class DebugConverter : IValueConverter
    {
        public static readonly DebugConverter Instance = new DebugConverter();

        private DebugConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debugger.Break();

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debugger.Break();

            return value;
        }
    }

    //*************************************** Autosuggest Convertors End *********************************************** 

    // Radio Button Selection Convertor Start
    public class RadioButtonValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((string)parameter == (string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? parameter : null;
        }
    }
    public class EnumBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ParameterString = parameter as string;
            if (ParameterString == null)
                return DependencyProperty.UnsetValue;

            if (Enum.IsDefined(value.GetType(), value) == false)
                return DependencyProperty.UnsetValue;

            object paramvalue = Enum.Parse(value.GetType(), ParameterString);
            return paramvalue.Equals(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ParameterString = parameter as string;
            var valueAsBool = (bool)value;

            if (ParameterString == null || !valueAsBool)
            {
                try
                {
                    return Enum.Parse(targetType, "0");
                }
                catch (Exception)
                {
                    return DependencyProperty.UnsetValue;
                }
            }
            return Enum.Parse(targetType, ParameterString);
        }
    }

    // Radio Button Selection Convertor End

    public class IsNullEmptyWhiteSpaceConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString().Trim());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
    
    // Return Null if value is Blank or White Space
    public class NullReturnConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //object obj = string.IsNullOrWhiteSpace((value ?? "").ToString().Trim()) == true ? null : value;
            return string.IsNullOrWhiteSpace((value ?? "").ToString().Trim()) == true ? null : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    public class UpperCaseValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                              CultureInfo culture)
        {
            if (value is string)
            {
                return value.ToString().ToUpper();
            }
            return String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  CultureInfo culture)
        {
            if (value is string)
            {
                return value.ToString().ToUpper();
            }
            return Binding.DoNothing;
        }
    }

    //If value is null then return Collapsed else Visible
    public class NullVisibilityConverter : IValueConverter
    {
        public object Convert(object values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (values==null)  //if (string.IsNullOrWhiteSpace(values.ToString()))
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    //If value is null then return True else false
    public class NullToBoolConverter : IValueConverter
    {
        public object Convert(object values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (values == null || string.IsNullOrWhiteSpace((values ?? "").ToString()))  //if (string.IsNullOrWhiteSpace((values ?? "").ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    //If value condition not satisfy and result is null then return apposite of True and false.e.g. if value satisfy then result is true then return false as opposit of resulf true.
    public class NullToBoolRevertConverter : IValueConverter
    {
        public object Convert(object values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (values == null || string.IsNullOrWhiteSpace((values ?? "").ToString()))  //if (string.IsNullOrWhiteSpace((values ?? "").ToString()))
                {
                    return !true;
                }
                else
                {
                    return !false;
                }
            }
            catch (Exception)
            {
                return !false;
            }
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }


}
