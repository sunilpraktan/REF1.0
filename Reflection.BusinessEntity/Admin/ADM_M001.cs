using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Reflection.BusinessEntity
{
    public class ADM_M001 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        
        private string _group_code;
        public string group_code
        {
            get { return _group_code; }
            set
            {
                if (_group_code != value)
                {
                    _group_code = value;
                    RaisePropertyChanged("group_code", ModelEntityUpdated);
                }
            }
        }
        private string _Abbrv { get; set; }
        public string Abbrv
        {
            get { return _Abbrv; }
            set
            {
                if (_Abbrv != value)
                {
                    _Abbrv = value;
                    RaisePropertyChanged("Abbrv", ModelEntityUpdated);
                }
            }
        }


        private string _GrpName { get; set; }
        public string GrpName
        {
            get { return _GrpName; }
            set
            {
                if (_GrpName != value)
                {
                    _GrpName = value;
                    RaisePropertyChanged("GrpName", ModelEntityUpdated);
                }
            }
        }

        private string _Address1;
        public string Address1
        {
            get { return _Address1; }
            set
            {
                if (_Address1 != value)
                {
                    _Address1 = value;
                    RaisePropertyChanged("Address1");
                }
            }
        }
        private string _Address2 { get; set; }
        public string Address2
        {
            get { return _Address2; }
            set
            {
                if (_Address2 != value)
                {
                    _Address2 = value;
                    RaisePropertyChanged("Address2");
                }
            }
        }
        private string _City;
        public string City
        {
            get { return _City; }
            set
            {
                if (_City != value)
                {
                    _City = value;
                    RaisePropertyChanged("City");
                }
            }
        }

        private string _state_code;
        public string state_code
        {
            get { return _state_code; }
            set
            {
                if (_state_code != value)
                {
                    _state_code = value;
                    RaisePropertyChanged("state_code");
                }
            }
        }
        private string _country_code;
        public string country_code
        {
            get { return _country_code; }
            set
            {
                if (_country_code != value)
                {
                    _country_code = value;
                    RaisePropertyChanged("country_code");
                }
            }
        }

        private string _PinCode;
        public string PinCode
        {
            get { return _PinCode; }
            set
            {
                if (_PinCode != value)
                {
                    _PinCode = value;
                    RaisePropertyChanged("PinCode");
                }
            }
        }
        private string _PhOffi;
        public string PhOffi
        {
            get { return _PhOffi; }
            set
            {
                if (_PhOffi != value)
                {
                    _PhOffi = value;
                    RaisePropertyChanged("PhOffi");
                }
            }
        }
        private string _PhOffiExtn;
        public string PhOffiExtn
        {
            get { return _PhOffiExtn; }
            set
            {
                if (_PhOffiExtn != value)
                {
                    _PhOffiExtn = value;
                    RaisePropertyChanged("PhOffiExtn");
                }
            }
        }
        private string _FaxNo;
        public string FaxNo
        {
            get { return _FaxNo; }
            set
            {
                if (_FaxNo != value)
                {
                    _FaxNo = value;
                    RaisePropertyChanged("FaxNo");
                }
            }
        }
        private string _MailID;
        public string MailID
        {
            get { return _MailID; }
            set
            {
                if (_MailID != value)
                {
                    _MailID = value;
                    RaisePropertyChanged("MailID");
                }
            }
        }
        private string _WebSite;
        public string WebSite
        {
            get { return _WebSite; }
            set
            {
                if (_WebSite != value)
                {
                    _WebSite = value;
                    RaisePropertyChanged("WebSite");
                }
            }
        }
        
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value;
                    RaisePropertyChanged("add_date");
                }
            }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                if (_editby != value)
                {
                    _editby = value;
                    RaisePropertyChanged("editby");
                }
            }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value;
                    RaisePropertyChanged("edit_date");
                }
            }
        }
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value;
                    RaisePropertyChanged("lang_key");
                }
            }
        }
        private string _CountryName;
        public string CountryName
        {
            get { return _CountryName; }
            set
            {
                if (_CountryName != value)
                {
                    _CountryName = value;
                    RaisePropertyChanged("CountryName");
                }
            }
        }
        private string _StateName;
        public string StateName
        {
            get { return _StateName; }
            set
            {
                if (_StateName != value)
                {
                    _StateName = value;
                    RaisePropertyChanged("StateName");
                }
            }
        }

        
    }
    public class MultipleContext
    {
        public List<ADM_M001> Companies { get; set; }
        public ObservableCollection<ADM_M012_P> Countrys { get; set; }
        public ObservableCollection<ADM_M013_P> States { get; set; }
    }
}