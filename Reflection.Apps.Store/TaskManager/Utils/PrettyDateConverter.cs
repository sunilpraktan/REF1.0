using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Reflection.Apps.Store.TaskManager
{
    public class PrettyDateConverter : IValueConverter
    {
        //uncommented by Priyanka
        //protected override string ConvertBase(DateTime? input)
        //{
        //    return Convert(input, this.ShowOverdue);
        //}

        //end
        public static string Convert(DateTime? input, bool showOverdue)
        {
            if (input.HasValue)
            {
                return formatDateTime(input.Value, showOverdue);
            }
            else
            {
                return null;
            }
        }

        //uncommented by Priyanka
        //protected override DateTime? ConvertBackBase(string input)
        //{
        //    return DateParser.ParseDate(input);
        //}
        //end

        private static string formatDateTime(DateTime input, bool showOverdue)
        {
            string time = formatTime(input);
            return FormatDate(input, showOverdue) + (string.IsNullOrEmpty(time) ? "" : (" at" + time));

        }

        public static string FormatDate(DateTime input, bool showOverDue)
        {
            if (input.Date == DateTime.MaxValue.Date) return "Someday";
            if (showOverDue && input.Date < DateTime.Today) return "Overdue";

            int dayDiff = (input.Date - DateTime.Today.Date).Days;

            if (dayDiff == 0)
            {
                return "Today";
            }
            else if (dayDiff == 1)
            {
                return "Tomorrow";
            }
            else if (dayDiff == -1)
            {
                return "Yesterday";
            }
            else if (dayDiff > 1 && dayDiff < 7)
            {
                return input.DayOfWeek.ToString();
            }
            else if (dayDiff >= 7 && dayDiff < 12)
            {
                // not doing a full two weeks because it starts to feel confusing too far out
                return "Next " + input.DayOfWeek.ToString();
            }
            else
            {
                return input.ToString("ddd, MMMM d, yyyy");
            }
        }

        private static string formatTime(DateTime input)
        {
            string output;
            if (input.Hour == 0)
            {
                output = "";
            }
            else if (input.Minute == 0)
            {
                output = input.ToString(" htt");
            }
            else
            {
                output = input.ToString(" h:mmtt");
            }
            return output.ToLowerInvariant();
        }

        public bool ShowOverdue { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null; // Convert(System.Convert.ToDateTime(value), this.ShowOverdue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
