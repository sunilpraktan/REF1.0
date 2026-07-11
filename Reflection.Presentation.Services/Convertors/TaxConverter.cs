
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
    public class TaxConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                string taxdesc = "";
                string displayMember = "id";
                string valueMember = "description";

                if (values[0] != null)
                {
                    string[] split = values[0].ToString().Split(',');
                    object dataSource = values[1];

                    IEnumerable list = (IEnumerable)dataSource;
                    if (list != null) // NOTE : this check condition added to avoide exception on 22/05/2022
                    {
                        Type elementType = list.GetType().GetGenericArguments()[0];
                        PropertyInfo property = elementType.GetProperty(displayMember);

                        List<object> displayValues = list.Cast<object>()
                                                   .Select(v => property.GetValue(v, null))
                                                   .ToList();

                        string displayMember1 = "description";
                        string valueMember1 = "id";
                        Type elementType1 = list.GetType().GetGenericArguments()[0];
                        PropertyInfo property1 = elementType.GetProperty(displayMember1);

                        List<object> displayValues1 = list.Cast<object>()
                                                 .Select(v => property1.GetValue(v, null))
                                                 .ToList();

                        foreach (var item in split)
                        {
                            if (taxdesc == "")
                            {
                                for (int i = 0; i < displayValues.Count; i++)
                                {
                                    if (displayValues[i].ToString() == item)
                                    {
                                        taxdesc = displayValues1[i].ToString();
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < displayValues.Count; i++)
                                {
                                    if (displayValues[i].ToString() == item)
                                    {
                                        taxdesc = taxdesc + "," + displayValues1[i].ToString();
                                    }
                                }
                            }

                        }
                    }
                }
                values[1] = taxdesc;
            }
            catch
            {

            }            
            return values[1];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

      


    }
}
