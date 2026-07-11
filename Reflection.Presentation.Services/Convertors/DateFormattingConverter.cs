using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Reflection.Presentation.Services
{
    /// <summary>
    /// This converter is used to show DateTime in short date format
    /// </summary>
    public class DateFormattingConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value != null)
                return ((DateTime)value).ToShortDateString();

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (string.IsNullOrEmpty((string)value))
                return null;

            string dateString = (string)value;

            // Append first month and day if just the year was entered
            if (dateString.Length == 4)
                dateString = "1/1/" + dateString;


            DateTime date;
            DateTime.TryParse(dateString, out date);
            return date;
        }

        #endregion
    }

    /// <summary>
    /// This converter is used to show time part ifrom date
    /// </summary>
    public class DateTimeToTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.ToString("HH:mm:ss");
            }
            return string.Empty; // Return empty string if value is null
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // No need to convert back in this case
        }
    }
}
