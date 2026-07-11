//using System;
//using System.Data;
//using System.Text;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Data;
//using System.ComponentModel;
//using System.Reflection;
//using System.Collections.ObjectModel;
//using System.Windows.Data;

//namespace Reflection.Presentation.Services
//{
//    public class VisibilityConverter : IMultiValueConverter
//    {
//        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
//        {
//            try
//            {

//                {
//                    object dataSource = values[0];
//                    string displayMember = "wbtsta";
//                    string valueMember = "wbtsta";

//                    string displayMember1 = "wbtstb";
//                    string valueMember1 = "wbtstb";

//                    int z = -1;
//                    IEnumerable list = (IEnumerable)dataSource;
//                    Type elementType = list.GetType().GetGenericArguments()[0];
//                    PropertyInfo property = elementType.GetProperty(displayMember);

//                    List<object> displayValues = list.Cast<object>()
//                                                     .Select(v => property.GetValue(v, null))
//                                                     .ToList();

//                    IEnumerable list1 = (IEnumerable)dataSource;
//                    Type elementType1 = list.GetType().GetGenericArguments()[0];
//                    PropertyInfo property1 = elementType.GetProperty(displayMember1);

//                    List<object> displayValues1 = list1.Cast<object>()
//                                                     .Select(v => property.GetValue(v, null))
//                                                     .ToList();


//                    if (displayValues.Count == 0)
//                    {
//                        return Visibility.Collapsed;
//                    }
//                    else
//                    {
//                        for (int i = 0; i < displayValues.Count; i++)
//                        {
//                            if (displayValues[i].ToString() != "0" && displayValues1[i].ToString() != "0")
//                            {
//                                z = 1;
//                            }
//                            else
//                            {
//                                z = 0;
//                                break;
//                            }
//                        }
//                        if (z == 1)
//                        {
//                            return Visibility.Visible;
//                        }
//                        else
//                        {
//                            return Visibility.Collapsed;
//                        }

//                    }



//                }

//                if (values[0].ToString() == "0" && values[1].ToString() == "0")
//                {
//                    return Visibility.Collapsed;
//                }
//                else
//                {
//                    return Visibility.Visible;
//                }
//            }
//            catch (Exception)
//            {
//                return Visibility.Collapsed;
//            }
//        }

//        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
//        {
//            throw new NotImplementedException();
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
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (values.ToString() == "0")
                {
                    return false;
                }
                else
                {
                    return true;
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
    
    public class VisibilityValueConverter : IValueConverter
    {
        public object Convert(object values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if ( (int)values > 0)
                {
                    return false;
                }
                else
                {
                    return true;
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
}
