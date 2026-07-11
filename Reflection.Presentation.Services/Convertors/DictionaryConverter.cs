using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;


namespace Reflection.Presentation.Services
{
    public  class DictionaryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || value.Equals(DependencyProperty.UnsetValue) || string.IsNullOrEmpty(value.ToString()) || string.IsNullOrWhiteSpace(value.ToString()))
                return null;
            string __type = value.ToString();
            Dictionary<string, object> dic = GetDictionary(__type);
            return dic;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        Dictionary<string, object> GetDictionary(string f)
        {
            if (string.IsNullOrEmpty(f) || string.IsNullOrWhiteSpace(f)) return null;
            Dictionary<string, object> d = new Dictionary<string, object>();
            // Divide all pairs (remove empty strings)
            string[] tokens = f.Split(new char[] { '/', ':', ',' },
                StringSplitOptions.RemoveEmptyEntries);
            // Walk through each item
            for (int i = 0; i < tokens.Length; i += 1)
            {
                string name = tokens[i];
                //string freq = tokens[i + 1];

                // Parse the int (this can throw)
                //int count = int.Parse(freq);
                // Fill the value in the sorted dictionary
                if (d.ContainsKey(name))
                {
                    //d[name] += count;
                }
                else
                {
                    d.Add(name, "");
                }
            }
            return d;
        }
    }
}
