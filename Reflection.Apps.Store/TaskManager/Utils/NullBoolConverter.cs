using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Reflection.Apps.Store.TaskManager
{
    public class NullBoolConverter : IValueConverter
    {
        //uncommented by Priyanka
        //protected override bool ConvertBase(object input)
        //{
        //    return input != null;
        //}
        //end

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
