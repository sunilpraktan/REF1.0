using GalaSoft.MvvmLight.Ioc;
using Reflection.BusinessEntity;
using Reflection.Presentation.Common;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Reflection.Presentation.Services
{
    public class ReflectionFunctionService
    {
        WebServiceRepository<List<REF_T001>> repository_REF_T001 = new WebServiceRepository<List<REF_T001>>();

        public void Invoke_Documet(STD_LIST_BE STD_BE_OBJ)
        {
            CursorControl.SetBusyState();
            List<REF_T001> listREF_T001 = new List<REF_T001>();
            REF_T001 objREF_T001 = new REF_T001();
            listREF_T001 = repository_REF_T001.GetDataWithReturnDomainObject<List<REF_T001>>(listREF_T001, STD_BE_OBJ.request, "REF_T001_BL", "GEN", "REF_T001_BL", 0, "");
            if (listREF_T001.Count > 0)
            {
                objREF_T001 = listREF_T001[0];
                AppSessionState.ViewTitle = objREF_T001.ts_name_display;
                if (objREF_T001.screen_namespace != null && objREF_T001.screen_namespace != "" && objREF_T001.screen_class_path != null && objREF_T001.screen_class_path != "")
                {
                    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, objREF_T001.screen_namespace);
                    Assembly assembly = Assembly.LoadFile(path1);
                    Type type = assembly.GetType(objREF_T001.screen_class_path);
                    if (type != null)
                    {
                        dynamic instance = Activator.CreateInstance(type, objREF_T001.ts_code, STD_BE_OBJ);
                        //dynamic instance = Activator.CreateInstance(type, objREF_T001.doc_no, objREF_T001.ts_code, objREF_T001.ts_name_display);
                        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                    }
                }
            }
        }

        public void Invoke_Documet(string doc_no, string ParameterReference) // NOTE: remove this when above updated & use by all project
        {
            CursorControl.SetBusyState();
            List<REF_T001> listREF_T001 = new List<REF_T001>();
            REF_T001 objREF_T001 = new REF_T001();
            try
            {
                listREF_T001 = repository_REF_T001.GetDataWithReturnDomainObject<List<REF_T001>>(listREF_T001, "LoggingData", "LoggingControl", "LoggingControl", "", 0, doc_no);
                if (listREF_T001.Count > 0)
                {
                    objREF_T001 = listREF_T001[0];
                    AppSessionState.ViewTitle = objREF_T001.ts_name_display;
                    if (objREF_T001.screen_namespace != null && objREF_T001.screen_namespace != "" && objREF_T001.screen_class_path != null && objREF_T001.screen_class_path != "")
                    {
                        string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, objREF_T001.screen_namespace);
                        Assembly assembly = Assembly.LoadFile(path1);
                        Type type = assembly.GetType(objREF_T001.screen_class_path);
                        if (type != null)
                        {
                            dynamic instance = Activator.CreateInstance(type, objREF_T001.ts_code, objREF_T001.doc_no);
                            //dynamic instance = Activator.CreateInstance(type, objREF_T001.doc_no, objREF_T001.ts_code, objREF_T001.ts_name_display);
                            SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        
    }

    public class REF_T001
    {
        public int? id { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string doc_no { get; set; }
        public string ts_code { get; set; }
        public string client { get; set; }
        public string comp_code { get; set; }
        public string op_type { get; set; }
        public string t_type { get; set; }
        public string userid { get; set; }
        public DateTime? t_date { get; set; }
        public string t_stamp { get; set; }
        public DateTimeOffset? t_datetimeoffset { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string lang_key { get; set; }
        public string location_Id { get; set; }
        public string t_status { get; set; }
        public string screen_namespace { get; set; }
        public string screen_class_path { get; set; }
        public string ts_name_display { get; set; }
    }

    public static class ExtensionMethods2 // This Method not working properly , below is working function
    {
        public static void CopyProperties2To<T, U>(this T source, U dest)
        {
            var plistsource = from prop1 in typeof(T).GetProperties() where prop1.CanRead select prop1;
            var plistdest = from prop2 in typeof(U).GetProperties() where prop2.CanWrite select prop2;

            foreach (PropertyInfo destprop in plistdest)
            {
                var sourceprops = plistsource.Where((p) => p.Name == destprop.Name &&
                  destprop.PropertyType.IsAssignableFrom(p.GetType()));
                foreach (PropertyInfo sourceprop in sourceprops)
                { // should only be one
                    destprop.SetValue(dest, sourceprop.GetValue(source, null), null);
                }
            }
        }
    }
    public static class ExtensionMethods
    {
        public static void CopyPropertiesTo<T>(this T source, T dest)
        {
            var plist = from prop in typeof(T).GetProperties() where prop.CanRead && prop.CanWrite select prop;

            foreach (PropertyInfo prop in plist)
            {
                prop.SetValue(dest, prop.GetValue(source, null), null);
            }
        }
    }
}
