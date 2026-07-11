using System;
using System.Windows.Data;

namespace Reflection.Presentation.Services
{
    public class DisplayPropertyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var __type = value.ToString();
            __type = "parametervalue";
            //if (__type.ToString() == "Make") return "Make";
            //else if (__type.ToString() == "Flute") return "FName";
            //else if (__type.ToString() == "Shade") return "Shade";
            //else if (__type.ToString() == "Colour") return "Colour";

            //else if (__type.ToString() == "Brand") return "Brand";
            //else if (__type.ToString() == "Form") return "Form";
            //else if (__type.ToString() == "Deckle") return "Deckle";

            return __type;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
