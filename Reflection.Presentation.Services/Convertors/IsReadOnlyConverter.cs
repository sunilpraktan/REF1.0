//using Reflection.Presentation.ViewModel;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Reflection.WebServices.Gateway;
//using Reflection.Presentation.Core.Services;
//using Reflection.Presentation.Core.Windows;
//using System.Windows.Data;
//using GalaSoft.MvvmLight.Command;
//using System.Collections.ObjectModel;
//using System.Windows;
//using Reflection.Presentation.Services;
//using Microsoft.Win32;
//using System.IO;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Data;
//using System.Data;
//using System.Collections;

//namespace Reflection.Presentation.Services
//{
//    public class IsReadOnlyConverter : IValueConverter
//    {
//        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
//        {
//            try
//            {

//                if (value.ToString() == "0")
//                {
//                    return false;
//                }
//                else
//                {
//                    return true;
//                }
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }
//        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
//        {
//            return value;
//        }

//    }
//}





using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.ComponentModel;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace Reflection.Presentation.Services
{
    public class IsReadOnlyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                object dataSource = values[0];
                string displayMember = "wbtsta";
                string valueMember = "wbtsta";
                if (values[2] == "refilno")
                {
                    displayMember = "refilno";
                }
                else if (values[2] == "wbtsta")
                {
                    displayMember = "wbtsta";
                }
                else if (values[2] == "watstb")
                {
                    displayMember = "watstb";
                }
                int z = 0;
                IEnumerable list = (IEnumerable)dataSource;
                Type elementType = list.GetType().GetGenericArguments()[0];
                PropertyInfo property = elementType.GetProperty(displayMember);

                List<object> displayValues = list.Cast<object>()
                                             .Select(v => property.GetValue(v, null))
                                             .ToList();



                if (values[2] == "refilno")
                {
                    for (int i = 0; i < displayValues.Count; i++)
                    {
                        //if (decimal.Parse(displayValues[i].ToString()) == 0 && ((values[1]) == null || (bool)(values[1]) == true))
                        if (((values[1]) == null || (bool)(values[1]) == true))
                        {
                            z = z + 1;
                        }
                        else
                        {
                            z = z + 0;
                        }
                    }
                }
                else if (values[2] == "wbtsta")
                {
                    for (int i = 0; i < displayValues.Count; i++)
                    {
                        if (decimal.Parse(displayValues[i].ToString()) == 0)
                        {
                            z = z + 1;
                        }
                        else
                        {
                            z = z + 0;
                        }
                    }
                }
                else if (values[2] == "watstb")
                {
                    for (int i = 0; i < displayValues.Count; i++)
                    {
                        if (decimal.Parse(displayValues[i].ToString()) == 0)
                        {
                            z = z + 1;
                        }
                        else
                        {
                            z = z + 0;
                        }
                    }

                }
                if (z > 0)
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

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }




    }
}
