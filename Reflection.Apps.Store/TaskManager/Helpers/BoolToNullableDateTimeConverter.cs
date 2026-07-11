using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Reflection.Apps.Store.TaskManager
{
    public class BoolToNullableDateTimeConverter : IValueConverter
    {
        //uncommented by Priyanka
        //protected override bool ConvertBase(DateTime? input)
        //{
        //    return input.HasValue;
        //}

        //protected override DateTime? ConvertBackBase(bool input)
        //{
        //    return input ? DateTime.Now : (DateTime?)null;
        //}
        //end

        public static BoolToNullableDateTimeConverter Instance
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = new BoolToNullableDateTimeConverter();
                }
                return s_instance;
            }
        }

        private static BoolToNullableDateTimeConverter s_instance;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //throw new NotImplementedException();
            //return input ? DateTime.Now : (DateTime?)null;
            return value; // commented by Priyanka
            
        }
    }
}
