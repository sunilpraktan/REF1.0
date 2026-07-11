using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Reflection.Apps.Store.TaskManager
{
    public class PrettyTimeSpanConverter : IValueConverter
    {
        //uncommented by Priyanka
        //protected override string ConvertBase(TimeSpan? input)
        //{
        //    return Convert(input);
        //}
        //end

        public static string Convert(TimeSpan? input)
        {
            if (input.HasValue)
            {
                return formatTimeSpan(input.Value);
            }
            else
            {
                return null;
            }
        }

        private static string formatTimeSpan(TimeSpan input)
        {
            if (input <= TimeSpan.FromMinutes(5)) return "5 Minutes or Less";
            if (input <= TimeSpan.FromMinutes(15)) return "15 Minutes";
            if (input <= TimeSpan.FromMinutes(30)) return "30 Minutes";
            if (input <= TimeSpan.FromHours(1)) return "One Hour";
            if (input <= TimeSpan.FromHours(2)) return "Two Hours";
            if (input <= TimeSpan.FromHours(3)) return "Three Hours";
            if (input <= TimeSpan.FromHours(4)) return "Half Day";
            return "Full Day or More";
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TimeSpan ts = new TimeSpan();
            //ts = (TimeSpan)value;
            return Convert(ts);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
