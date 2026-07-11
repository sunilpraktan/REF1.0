using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using System.Reflection;

namespace Reflection.Presentation.Services
{
    public class ItemsSourceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<ADM_M030_PopUp> objectss = new List<ADM_M030_PopUp>();
            object dataSource = values[1];

            string displayMember = "para_code";  //Type
                                                 //  string valueMember = "parametervalue";  //Name
            try
            {
                IEnumerable list = (IEnumerable)dataSource;
                Type elementType = list.GetType().GetGenericArguments()[0];
                PropertyInfo property = elementType.GetProperty(displayMember);

                List<object> displayValues = list.Cast<object>().Select(v => property.GetValue(v, null)).ToList();

                string displayMember1 = "parametervalue";  //Name
                                                           // string valueMember1 = "para_code";

                IEnumerable list1 = (IEnumerable)dataSource;
                Type elementType1 = list.GetType().GetGenericArguments()[0];
                PropertyInfo property1 = elementType.GetProperty(displayMember1);

                List<object> displayValues1 = list.Cast<object>()
                                                     .Select(v => property1.GetValue(v, null))
                                                     .ToList();

                string displayMember2 = "value_code";
                //   string valueMember2 = "para_code";

                IEnumerable list2 = (IEnumerable)dataSource;
                Type elementType2 = list.GetType().GetGenericArguments()[0];
                PropertyInfo property2 = elementType.GetProperty(displayMember2);

                List<object> displayValues2 = list.Cast<object>().Select(v => property2.GetValue(v, null)).ToList();

                List<ADM_M030_P> ParameterValueList = new List<ADM_M030_P>();

                string val = values[0].ToString();

                for (int i = 0; i < displayValues.Count; i++)
                {
                    if (displayValues[i].ToString() == val)
                    {
                        ParameterValueList.Add(new ADM_M030_P()
                        {
                            value_code = (displayValues2[i].ToString()),
                            parametervalue = (displayValues1[i].ToString()),
                            para_code = displayValues[i].ToString()
                        });
                    }
                }
                #region
                //try
                //{
                //    object dataSource2 = values[2];
                //    string displayMember3 = "Srno";
                //    string valueMember3 = "Srno";

                //    IEnumerable list3 = (IEnumerable)dataSource2;
                //    Type elementType3 = list3.GetType().GetGenericArguments()[0];
                //    PropertyInfo property3 = elementType3.GetProperty(displayMember3);

                //    List<object> displayValues3 = list3.Cast<object>()
                //                                     .Select(v => property3.GetValue(v, null))
                //                                     .ToList();


                //    object dataSource3 = values[3];
                //    string displayMember4 = "Srno";
                //    string valueMember4 = "Srno";

                //    IEnumerable list4 = (IEnumerable)dataSource3;
                //    Type elementType4 = list4.GetType().GetGenericArguments()[0];
                //    PropertyInfo property4 = elementType4.GetProperty(displayMember4);

                //    List<object> displayValues4 = list4.Cast<object>()
                //                                     .Select(v => property4.GetValue(v, null))
                //                                     .ToList();


                //    values[1] = FluteList;

                //    if ((displayValues3.ToString() == displayValues4.ToString()))
                //    {

                //        return values[1];

                //    }
                //    else
                //    {
                //        return "";
                //    }
                //}
                //catch
                //{
                //    return values[1];
                //}
                #endregion

                values[1] = ParameterValueList;
                return values[1];
            }
            catch (Exception ex)
            {
                return values[1];
            }
        }

        //  new method tried
        //public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //{
        //    object dataSource = values[1];

        //    ADM_M030_P obj = ((IEnumerable)dataSource.cast<ADM_M030_P>().ToList()[0]); 

        //    // var parameterlist = dataSource as List<ADM_M030_P>;
        //    string val = values[0].ToString();

        //    List<ADM_M030_P> ParameterValueList = new List<ADM_M030_P>();
        //    List<ADM_M030_P> ParaValueList = new List<ADM_M030_P>();

        //    ParaValueList = (List<ADM_M030_P>)dataSource;
        //    if (ParaValueList.Count > 0)
        //    {
        //        var paravaluelisttemp = (from o in ParaValueList where o.para_code == val select o).ToList();
        //        ParameterValueList = paravaluelisttemp;
        //    }

        //    values[1] = ParameterValueList;
        //    return values[1];
        //}

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public class ADM_M030_PopUp
        {
            public string value_code { get; set; }
            ////public int code { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
        }

        public class ADM_M030_P
        {
            public string value_code { get; set; }
            public string para_code { get; set; }
            public string parametervalue { get; set; }    
        }

    }
}
