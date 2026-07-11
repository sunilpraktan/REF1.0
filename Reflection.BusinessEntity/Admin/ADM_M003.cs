using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;



namespace Reflection.BusinessEntity
{
    public class ADM_M003 : ObjectBase

    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
                }
            }
        }
        private string _LoctnNm { get; set; }
        public string LoctnNm
        {
            get { return _LoctnNm; }
            set
            {
                if (_LoctnNm != value)
                {
                    _LoctnNm = value;
                    RaisePropertyChanged("LoctnNm "); RaisePropertyChanged("LoctnNm", ModelEntityUpdated);
                }
            }
        }
        private string _LoctnAbbre { get; set; }
        public string LoctnAbbre
        {
            get { return _LoctnAbbre; }
            set
            {
                if (_LoctnAbbre != value)
                {
                    _LoctnAbbre = value;
                    RaisePropertyChanged("LoctnAbbre"); RaisePropertyChanged("LoctnAbbre", ModelEntityUpdated);
                }
            }
        }
        private string _comp_code { get; set; }
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value;
                    RaisePropertyChanged("comp_code");
                }
            }
        }
        
        internal bool? _Select { get; set; }
        [DisplayName("")]
        public bool? Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;
                    RaisePropertyChanged("Select");
                }
            }
        }
        private string _Add1 { get; set; }
        public string Add1
        {
            get { return _Add1; }
            set
            {
                if (_Add1 != value)
                {
                    _Add1 = value;
                    RaisePropertyChanged("Add1");
                }
            }
        }
        private string _Add2 { get; set; }
        public string Add2
        {
            get { return _Add2; }
            set
            {
                if (_Add2 != value)
                {
                    _Add2 = value;
                    RaisePropertyChanged("Add2");
                }
            }
        }
        private string _City { get; set; }
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
                    RaisePropertyChanged("state_Code");
                }
            }
        }
        private string _country_code { get; set; }
        public string country_code
        {
            get { return _country_code; }
            set
            {
                if (_country_code != value)
                {
                    _country_code = value;
                    RaisePropertyChanged("country_Code");
                }
            }
        }
        private string _PinCode { get; set; }
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
        private string _PhOffi { get; set; }
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
        private string _PhOffiExt { get; set; }
        public string PhOffiExt
        {
            get { return _PhOffiExt; }
            set
            {
                if (_PhOffiExt != value)
                {
                    _PhOffiExt = value;
                    RaisePropertyChanged("PhOffiExt");
                }
            }
        }
        private string _FaxNo { get; set; }
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

        private string _MailId { get; set; }
        public string MailId
        {
            get { return _MailId; }
            set
            {
                if (_MailId != value)
                {
                    _MailId = value;
                    RaisePropertyChanged("MailId");
                }
            }
        }
        private string _CentCode { get; set; }
        public string CentCode
        {
            get { return _CentCode; }
            set
            {
                if (_CentCode != value)
                {
                    _CentCode = value;
                    RaisePropertyChanged("CentCode");
                }
            }
        }
        private string _activity_code { get; set; }
        public string activity_code
        {
            get { return _activity_code; }
            set
            {
                if (_activity_code != value)
                {
                    _activity_code = value;
                    RaisePropertyChanged("activity_code");
                }
            }
        }

        
        private string _add_by { get; set; }
        public string add_by
        {
            get { return _add_by; }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value;
                    RaisePropertyChanged("add_by");
                }
            }
        }
        private DateTime? _add_date;
        public DateTime? add_date
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
        private string _editby { get; set; }
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
        private DateTime? _edit_date;
        public DateTime? edit_date
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
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }

        private string _gstinno;
        public string gstinno
        {
            get { return _gstinno; }
            set
            {
                if (_gstinno != value)
                {
                    _gstinno = value;
                    RaisePropertyChanged("gstinno");
                }
            }
        }
        private string _buss_place;
        public string buss_place
        {
            get { return _buss_place; }
            set
            {
                if (_buss_place != value)
                {
                    _buss_place = value;
                    RaisePropertyChanged("buss_place");
                }
            }
        }
        private DateTime? _gstindate;
        public DateTime? gstindate
        {
            get { return _gstindate; }

            set
            {
                if (_gstindate != value)
                {
                    _gstindate = value; RaisePropertyChanged("gstindate");
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
        private string _ActivityName;
        public string ActivityName
        {
            get { return _ActivityName; }
            set
            {
                if (_ActivityName != value)
                {
                    _ActivityName = value;
                    RaisePropertyChanged("ActivityName");
                }
            }
        }
        private string _CompanyName;
        public string CompanyName
        {
            get { return _CompanyName; }
            set
            {
                if (_CompanyName != value)
                {
                    _CompanyName = value;
                    RaisePropertyChanged("CompanyName");
                }
            }
        }
        private string _plc_name;
        public string plc_name
        {
            get { return _plc_name; }
            set
            {
                if (_plc_name != value)
                {
                    _plc_name = value;
                    RaisePropertyChanged("plc_name");
                }
            }
        }
        private string _bisness_state_code;
        public string bisness_state_code
        {
            get { return _bisness_state_code; }
            set
            {
                if (_bisness_state_code != value)
                {
                    _bisness_state_code = value;
                    RaisePropertyChanged("bisness_state_code");
                }
            }
        }
        private string _doc_no_key;
        public string doc_no_key
        {
            get { return _doc_no_key; }
            set
            {
                if (_doc_no_key != value)
                {
                    _doc_no_key = value;
                    RaisePropertyChanged("doc_no_key");
                }
            }
        }
        private string _ind_reg;
        public string ind_reg
        {
            get {return _ind_reg; }
            set { if(_ind_reg != value) { _ind_reg = value; RaisePropertyChanged("ind_reg"); } }
        }

        private string _customer_code;
        public string customer_code
        {
            get { return _customer_code; }
            set { if (_customer_code != value) { _customer_code = value; RaisePropertyChanged("customer_code"); } }
        }
        private string _supplier_code;
        public string supplier_code
        {
            get { return _supplier_code; }
            set { if (_supplier_code != value) { _supplier_code = value; RaisePropertyChanged("supplier_code"); } }
        }

        private string _group_code;
        public string group_code
        {
            get { return _group_code; }
            set { if (_group_code != value) { _group_code = value; RaisePropertyChanged("group_code"); } }
        }
        private string _comp_name;
        public string comp_name
        {
            get { return _comp_name; }
            set { if (_comp_name != value) { _comp_name = value; RaisePropertyChanged("comp_name"); } }
        }
        private string _abrv;
        public string abrv
        {
            get { return _abrv; }
            set { if (_abrv != value) { _abrv = value; RaisePropertyChanged("abrv"); } }
        }
        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set { if (_location_id != value) { _location_id = value; RaisePropertyChanged("location_id"); } }
        }
        private string _location_name;
        public string location_name
        {
            get { return _location_name; }
            set { if (_location_name != value) { _location_name = value; RaisePropertyChanged("location_name"); } }
        }
        private string _place;
        public string place
        {
            get { return _place; }
            set { if (_place != value) { _place = value; RaisePropertyChanged("place"); } }
        }
        private string _city;
        public string city
        {
            get { return _city; }
            set { if (_city != value) { _city = value; RaisePropertyChanged("city"); } }
        }
        private string _state;
        public string state
        {
            get { return _state; }
            set { if (_state != value) { _state = value; RaisePropertyChanged("state"); } }
        }
        private string _add_code;
        public string add_code
        {
            get { return _add_code; }
            set { if (_add_code != value) { _add_code = value; RaisePropertyChanged("add_code"); } }
        }

        public string tax_reg_no { get; set; }
        public string address { get; set; }
    }

    public class MultipleContextADM_M003
    {
        public List<ADM_M003> Locationes { get; set; }
        public ObservableCollection<ADM_M012_P> Countrys { get; set; }
        public ObservableCollection<ADM_M013_P> States { get; set; }
        public ObservableCollection<ADM_M004_P> Activityes { get; set; }
        public ObservableCollection<ADM_M002_P> Companyes { get; set; }
        public List<ADM_M003_C_P> BusinessPlace { get; set; }
    }
}
