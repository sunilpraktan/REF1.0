using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Reflection.Presentation.Services
{
    public class BinaryImageConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            BitmapImage image = new BitmapImage();
            if (value != null && value is byte[])
            {
                byte[] bytes = value as byte[];
                MemoryStream stream = new MemoryStream(bytes);
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();
            }
            return image;
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
