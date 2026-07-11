using Reflection.BusinessEntity;
using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.GEN;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Reflection.Presentation.Services
{
    public static class AppSessionState 
    {
        public static string GST_AUTH_CODE { get; set; } // Authorization Code generated after login to GST Portal

        // this is for NotifyChange property from other call because static class not allow to use notifychange interface
        //private static AppsessionNotify sessionNotifyobject = new AppsessionNotify();
        //public static AppsessionNotify AppsessionNotifyobject
        //{
        //    get
        //    {
        //        return sessionNotifyobject;
        //    }
        //}



        public static List<ADM_S0001> MODULE_LIST { get; set; }
        public static List<ADM_M0002> COMPANY_LIST { get; set; }
        public static List<ADM_M0003> LOCATION_LIST { get; set; }
        public static ADM_M0002 OBJ_COMPANY { get; set; }
        public static ADM_M0003 OBJ_LOCATION { get; set; }
        public static GEN_M0011 OBJ_LOC_ADDRESS { get; set; }
        public static MM_M001 OBJ_STORE { get; set; }



        private static string _UserID;
        private static string _Name;
        private static string _location_Id;
        private static string _comp_code;
        private static string _FinYear;
        private static int _FinYearInt;
        private static MailAccount _MailAccount;
        private static bool _IsUserLogin;
        private static int _LoginCount;
        private static string _so_code;
        private static string _sg_code;
        private static string _po_code;
        private static string _pg_code;
        private static string _EmpId;
        private static string _EmpEmailId;
        private static string _EmpName;
        private static string _UserMailID;
        private static string _CompanyName;
        private static string _UserTheme;
        private static string _UserLanguage;
        private static string _ViewTitle;
        private static string _TransId;
        private static string _TransactionCode;
        private static object _TransValueType;
        private static object _TransValue;
        private static object _TransParameter;
        private static string _UserSource1;
        private static string _UserSource2;
        private static bool _ViewOtherRecordAllowed;
        private static string _CntryCurncy;
        private static string _client;
        private static string _curr_code;
        private static string _dept_code;
        public static string dept_code
        {
            get { return _dept_code; }
            set
            {
                if (_dept_code != value)
                {
                    _dept_code = value;
                }
            }
        }
        public static string client
        {
            get { return _client; }
            set
            {
                if (value != _client)
                {
                    _client = value;
                }
            }
        }
        public static string curr_code
        {
            get { return _curr_code; }
            set
            {
                if (value != _curr_code)
                {
                    _curr_code = value;
                }
            }
        }
        public static string CntryCurncy
        {
            get { return _CntryCurncy; }
            set
            {
                if (value != _CntryCurncy)
                {
                    _CntryCurncy = value;
                }
            }
        }
        private static object _TS_AUTH_OBJ;
        public static object TS_AUTH_OBJ
        {
            get
            {
                return _TS_AUTH_OBJ;
            }

            set
            {
                _TS_AUTH_OBJ = value;
            }
        }
        public static string UserSource1
        {
            get { return _UserSource1; }
            set
            {
                if (value != _UserSource1)
                {
                    _UserSource1 = value;
                }
            }
        }

        public static string UserSource2
        {
            get { return _UserSource2; }
            set
            {
                if (value != _UserSource2)
                {
                    _UserSource2 = value;
                }
            }
        }


        public static string UserTheme
        {
            get { return _UserTheme; }
            set
            {
                if (value != _UserTheme)
                {
                    _UserTheme = value;
                }
            }
        }

        public static string UserLanguage
        {
            get { return _UserLanguage; }
            set
            {
                if (value != _UserLanguage)
                {
                    _UserLanguage = value;
                }
            }
        }

        private static string _user_type;
        public static string user_type
        {
            get { return _user_type; }
            set
            {
                if (value != _user_type)
                {
                    _user_type = value;
                }
            }
        }
        private static string _user_level;
        public static string user_level
        {
            get { return _user_level; }
            set
            {
                if (value != _user_level)
                {
                    _user_level = value;
                }
            }
        }
        private static string _user_type_name;
        public static string user_type_name
        {
            get { return _user_type_name; }
            set
            {
                if (value != _user_type_name)
                {
                    _user_type_name = value;
                }
            }
        }

        public static string ViewTitle
        {
            get { return _ViewTitle; }
            set
            {
                if (value != _ViewTitle)
                {
                    _ViewTitle = value;
                }
            }
        }

        public static MailAccount MailAccount
        {
            get { return _MailAccount; }
            set
            {
                if (value != _MailAccount)
                {
                    _MailAccount = value;
                }
            }
        }
        public static bool IsUserLogin
        {
            get { return _IsUserLogin; }
            set
            {
                if (value != _IsUserLogin)
                {
                    _IsUserLogin = value;
                }
            }
        }
        public static int LoginCount
        {
            get { return _LoginCount; }
            set
            {
                if (value != _LoginCount)
                {
                    _LoginCount = value;
                }
            }
        }
        public static string UserID
        {
            get { return _UserID; }
            set
            {
                if (value != _UserID)
                {
                    _UserID = value;
                }
            }
        }
        private static string _session_id;
        public static string session_id
        {
            get { return _session_id; }
            set
            {
                if (value != _session_id)
                {
                    _session_id = value;
                }
            }
        }
        private static string _password;
        public static string password
        {
            get { return _password; }
            set
            {
                if (value != _password)
                {
                    _password = value;
                }
            }
        }

        // NOTE: Deprecated and define standard
        public static string Name
        {
            get { return _Name; }
            set
            {
                if (value != _Name)
                {
                    _Name = value;
                }
            }
        }
        public static string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (value != _location_Id)
                {
                    _location_Id = value;
                }
            }
        }

        public static string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (value != _comp_code)
                {
                    _comp_code = value;
                }
            }
        }
        // NOTE: Deprecated
        public static string so_code
        {
            get { return _so_code; }
            set
            {
                if (value != _so_code)
                {
                    _so_code = value;
                }
            }
        }
        // NOTE: Deprecated
        public static string sg_code
        {
            get { return _sg_code; }
            set
            {
                if (value != _sg_code)
                {
                    _sg_code = value;
                }
            }
        }

        // NOTE: Deprecated
        public static string po_code
        {
            get { return _po_code; }
            set
            {
                if (value != _po_code)
                {
                    _po_code = value;
                }
            }
        }

        // NOTE: Deprecated
        public static string pg_code
        {
            get { return _pg_code; }
            set
            {
                if (value != _pg_code)
                {
                    _pg_code = value;
                }
            }
        }

        // NOTE: Deprecated
        public static string EmpId
        {
            get { return _EmpId; }
            set
            {
                if (value != _EmpId)
                {
                    _EmpId = value;
                }
            }
        }

        // NOTE: Deprecated
        public static string EmpEmailId
        {
            get { return _EmpEmailId; }
            set
            {
                if (value != _EmpEmailId)
                {
                    _EmpEmailId = value;
                }
            }
        }

        public static string EmpName
        {
            get { return _EmpName; }
            set
            {
                if (value != _EmpName)
                {
                    _EmpName = value;
                }
            }
        }

        private static string _LogoUrl;
        public static string LogoUrl
        {
            get { return _LogoUrl; }
            set
            {
                _LogoUrl = value;
            }
        }

        private static Object _ADM_AUTH_LIST;
        public static Object ADM_AUTH_LIST
        {
            get { return _ADM_AUTH_LIST; }
            set
            {
                _ADM_AUTH_LIST = value;
            }
        }
        private static Object _ADM_AUTH_OBJ;
        public static Object ADM_AUTH_OBJ
        {
            get { return _ADM_AUTH_OBJ; }
            set
            {
                _ADM_AUTH_OBJ = value;
            }
        }
        // NOTE: Deprecated
        private static object _ADM_M002_List;
        public static object ADM_M002_List
        {
            get
            {
                return _ADM_M002_List;
            }

            set
            {
                _ADM_M002_List = value;
            }
        }

        // NOTE: Deprecated
        private static object _ADM_M003_List;
        public static object ADM_M003_List
        {
            get
            {
                return _ADM_M003_List;
            }

            set
            {
                _ADM_M003_List = value;
            }
        }
        
        // NOTE: Deprecated
        private static object _store_location;
        public static object store_location
        {
            get { return _store_location; }
            set
            {
                if (value != _store_location)
                {
                    _store_location = value;
                }
            }
        }
        

        // NOTE: Deprecated
        public static string CompanyName
        {
            get { return _CompanyName; }
            set
            {
                if (value != _CompanyName)
                {
                    _CompanyName = value;
                }
            }
        }


        // NOTE: Deprecated
        //sales group
        private static object _ADM_M001_H_List;
        public static object ADM_M001_H_List
        {
            get
            {
                return _ADM_M001_H_List;
            }

            set
            {
                _ADM_M001_H_List = value;
            }
        }

        // NOTE: Deprecated
        //--- sales organisation
        private static object _ADM_M001_A_List;
        public static object ADM_M001_A_List
        {
            get
            {
                return _ADM_M001_A_List;
            }

            set
            {
                _ADM_M001_A_List = value;
            }
        }

        // NOTE: Deprecated
        //purchase group
        private static object _ADM_M001_P_List;
        public static object ADM_M001_P_List
        {
            get
            {
                return _ADM_M001_P_List;
            }

            set
            {
                _ADM_M001_P_List = value;
            }
        }

        // NOTE: Deprecated
        // Purchase Organisation
        private static object _ADM_M001_M_List;
        public static object ADM_M001_M_List
        {
            get
            {
                return _ADM_M001_M_List;
            }

            set
            {
                _ADM_M001_M_List = value;
            }

        }
        // NOTE: Deprecated
        public static object CurrencyList;

        // NOTE: Deprecated
        public static string TransactionCode
        {
            get { return _TransactionCode; }
            set
            {
                if (value != _TransactionCode)
                {
                    _TransactionCode = value;
                }
            }
        }

        // NOTE: Deprecated
        public static object TransValueType
        {
            get { return _TransValueType; }
            set
            {
                if (value != _TransValueType)
                {
                    _TransValueType = value;
                }
            }
        }

        // NOTE: Deprecated
        public static object TransValue
        {
            get { return _TransValue; }
            set
            {
                if (value != _TransValue)
                {
                    _TransValue = value;
                }
            }
        }

        // NOTE: Deprecated
        public static object TransParameter
        {
            get { return _TransParameter; }
            set
            {
                if (value != _TransParameter)
                {
                    _TransParameter = value;
                }
            }
        }

        //NOTE: Deprecated
        public static bool ViewOtherRecordAllowed
        {
            get { return _ViewOtherRecordAllowed; }
            set
            {
                if (value != _ViewOtherRecordAllowed)
                {
                    _ViewOtherRecordAllowed = value;
                }
            }
        }

       
        private static string _WebReportDirectory;
        public static string WebReportDirectory
        {
            get { return _WebReportDirectory; }
            set { _WebReportDirectory = value; }
        }
        private static string _RootDirectory;
        public static string RootDirectory
        {
            get { return _RootDirectory; }
            set { _RootDirectory = value; }
        }
       

    }

    public static class Settings
    {
        private static int _id;
        public static int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private static string _def_culture;
        public static string def_culture
        {
            get { return _def_culture; }
            set { _def_culture = value; }
        }
        private static string _time_zone;
        public static string time_zone
        {
            get { return _time_zone; }
            set { _time_zone = value; }
        }
        private static string _date_format;
        public static string date_format
        {
            get { return _date_format; }
            set { _date_format = value; }
        }
        private static string _date_separator;
        public static string date_separator
        {
            get { return _date_separator; }
            set { _date_separator = value; }
        }
        private static int _decimal_digits;
        public static int decimal_digits
        {
            get { return _decimal_digits; }
            set { _decimal_digits = value; }
        }
        private static string _round_up_method_code;
        public static string round_up_method_code
        {
            get { return _round_up_method_code; }
            set { _round_up_method_code = value; }
        }
        private static bool? _value_suffix;
        public static bool? value_suffix
        {
            get { return _value_suffix; }
            set { _value_suffix = value; }
        }
        private static string _theme_code;
        public static string theme_code
        {
            get { return _theme_code; }
            set { _theme_code = value; }
        }
        private static byte[] _desktop_file;
        public static byte[] desktop_file
        {
            get { return _desktop_file; }
            set { _desktop_file = value; }
        }
        private static bool _round_up;
        public static bool round_up
        {
            get { return _round_up; }
            set { _round_up = value; }
        }
        private static bool? _curr_notation;
        public static bool? curr_notation
        {
            get { return _curr_notation; }
            set { _curr_notation = value; }
        }
        //Scalar
        private static string _date_sample;
        public static string date_sample
        {
            get { return _date_sample; }
            set { _date_sample = value; }
        }
        private static string _def_culture_name;
        public static string def_culture_name
        {
            get { return _def_culture_name; }
            set { _def_culture_name = value; }
        }
        private static string _round_up_method_name;
        public static string round_up_method_name
        {
            get { return _round_up_method_name; }
            set { _round_up_method_name = value; }
        }
        // assign "currency_symbol" + "!" + "currency_code" to this entity and 
        // pass it as a parameter to CurrencyDisplayConverter
        private static string _doc_currency_notation;
        public static string doc_currency_notation
        {
            get { return _doc_currency_notation; }
            set { _doc_currency_notation = value; }
        }
        private static string _decimal_format_code;
        public static string decimal_format_code
        {
            get { return _decimal_format_code; }
            set { _decimal_format_code = value; }
        }

    }

    //public class AppsessionNotify : INotifyPropertyChanged // NOTE: Commented full because it is comming first for intelesense before main class and anyway we have not using this class, it was designed for specific purpose which not happened for PropertyChangedEvent application for this class.
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    #region INotifyDataErrorInfo & INotifyPropertyChanged Members

    //    //public static event PropertyChangedEventHandler PropertyChanged;
    //    //public static void RaisePropertyChanged(string propertyName)
    //    //{
    //    //    var handler = PropertyChanged;
    //    //    if (handler != null)
    //    //        handler(this, new PropertyChangedEventArgs(propertyName));
    //    //}

    //    //private static string _CurrenctCompany;
    //    //public static string CurrenctCompany
    //    //{
    //    //    get { return _CurrenctCompany; }
    //    //    set
    //    //    {
    //    //        if (_CurrenctCompany != value)
    //    //        {
    //    //            _CurrenctCompany = value; //RaisePropertyChanged("CurrenctCompany");
    //    //            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("CurrenctCompany"));
    //    //        }
    //    //    }
    //    //}
    //    private string _UserLogInfo;
    //    public string UserLogInfo
    //    {
    //        get { return _UserLogInfo; }
    //        set
    //        {
    //            if (_UserLogInfo != value)
    //            {
    //                _UserLogInfo = value; //RaisePropertyChanged("CurrenctCompany");
    //                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("UserLogInfo"));
    //            }
    //        }
    //    }

    //    #endregion
    //}
}
