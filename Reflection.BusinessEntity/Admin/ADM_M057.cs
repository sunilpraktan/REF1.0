using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M057 : ObjectBase
    {
        private string _acc_id;
        public string acc_id
        {
            get { return _acc_id; }
            set
            {
                _acc_id = value; RaisePropertyChanged("acc_id");
            }
        }

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value; RaisePropertyChanged("id");
            }
        }

        private string _trans_code;
        public string trans_code
        {
            get { return _trans_code; }
            set
            {
                _trans_code = value; RaisePropertyChanged("trans_code");
            }
        }

        private string _parent_id;
        public string parent_id
        {
            get { return _parent_id; }
            set
            {
                _parent_id = value; RaisePropertyChanged("parent_id");
            }
        }

        private string _type_code;
        public string type_code
        {
            get { return _type_code; }
            set
            {
                _type_code = value; RaisePropertyChanged("type_code");
            }
        }

        private string _sub_type;
        public string sub_type
        {
            get { return _sub_type; }
            set
            {
                _sub_type = value; RaisePropertyChanged("sub_type");
            }
        }

        private string _ind_primary;
        public string ind_primary
        {
            get { return _ind_primary; }
            set
            {
                _ind_primary = value; RaisePropertyChanged("ind_primary");
            }
        }

        private string _contact_no;
        public string contact_no
        {
            get { return _contact_no; }
            set
            {
                _contact_no = value; RaisePropertyChanged("contact_no");
            }
        }

        private string _ext_no;
        public string ext_no
        {
            get { return _ext_no; }
            set
            {
                _ext_no = value; RaisePropertyChanged("ext_no");
            }
        }

        private string _acc_name;
        public string acc_name
        {
            get { return _acc_name; }
            set
            {
                _acc_name = value; RaisePropertyChanged("acc_name");
            }
        }

        private string _desc;
        public string desc
        {
            get { return _desc; }
            set
            {
                _desc = value; RaisePropertyChanged("desc");
            }
        }

        private string _ass_contact_no;
        public string ass_contact_no
        {
            get { return _ass_contact_no; }
            set
            {
                _ass_contact_no = value; RaisePropertyChanged("ass_contact_no");
            }
        }

        private string _ind_phone;
        public string ind_phone
        {
            get { return _ind_phone; }
            set
            {
                _ind_phone = value; RaisePropertyChanged("ind_phone");
            }
        }

        private string _ind_pref_contact;
        public string ind_pref_contact
        {
            get { return _ind_pref_contact; }
            set
            {
                _ind_pref_contact = value; RaisePropertyChanged("ind_pref_contact");
            }
        }

        private string _ind_def;
        public string ind_def
        {
            get { return _ind_def; }
            set
            {
                _ind_def = value; RaisePropertyChanged("ind_def");
            }
        }

        private Nullable<System.DateTime> _valid_fdate;
        public Nullable<System.DateTime> valid_fdate
        {
            get { return _valid_fdate; }
            set
            {
                _valid_fdate = value; RaisePropertyChanged("valid_fdate");
            }
        }

        private string _seq_no;
        public string seq_no
        {
            get { return _seq_no; }
            set
            {
                _seq_no = value; RaisePropertyChanged("seq_no");
            }
        }

        private string _cntry_tel_fax;
        public string cntry_tel_fax
        {
            get { return _cntry_tel_fax; }
            set
            {
                _cntry_tel_fax = value; RaisePropertyChanged("cntry_tel_fax");
            }
        }

        private string _ind_sms_enable;
        public string ind_sms_enable
        {
            get { return _ind_sms_enable; }
            set
            {
                _ind_sms_enable = value; RaisePropertyChanged("ind_sms_enable");
            }
        }

        private string _complete_phno;
        public string complete_phno
        {
            get { return _complete_phno; }
            set
            {
                _complete_phno = value; RaisePropertyChanged("complete_phno");
            }
        }
        //scaler
        private string _type_name;
        public string type_name
        {
            get { return _type_name; }
            set
            {
                _type_name = value; RaisePropertyChanged("type_name");
            }
        }

        #region Default Fields
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value; RaisePropertyChanged("active");
            }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }

        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                _edit_by = value; RaisePropertyChanged("edit_by");
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value; RaisePropertyChanged("edit_date");
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                _lang_key = value;
                RaisePropertyChanged("lang_key");
            }
        }

      
        private bool _Click;
        public bool Click
        {
            get
            {
                return _Click;
            }
            set
            {
                if (_Click != value)
                {
                    _Click = value;
                    RaisePropertyChanged("Click");
                }
            }
        }
        private string _CntryName;
        public string CntryName
        {
            get { return _CntryName; }
            set
            {
                _CntryName = value;
                RaisePropertyChanged("CntryName");
            }
        }
        private string _country_code;
        public string country_code
        {
            get { return _country_code; }
            set
            {
                _country_code = value; RaisePropertyChanged("country_code");
            }
        }
        #endregion        
    }
    public class MultipleContext_ADM_M057
    {
        public List<ADM_M057> CommunicationList { get; set; }
        public List<ADM_M057_A_P> CommunicationTypeList { get; set; }
        public List<ADM_M012_P> CountryList { get; set; }


    }
}
