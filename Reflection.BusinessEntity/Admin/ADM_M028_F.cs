using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M028_F : ObjectBase
    {
        
        private string _party_id;
        public string party_id
        {
            get { return _party_id; }
            set
            {
                _party_id = value; RaisePropertyChanged("party_id");
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
       
        private string _party_name;
        public string party_name
        {
            get { return _party_name; }
            set
            {
                _party_name = value; RaisePropertyChanged("party_name");
            }
        }
        
        private string _abbreviation;
        public string abbreviation
        {
            get { return _abbreviation; }
            set
            {
                _abbreviation = value; RaisePropertyChanged("abbreviation");
            }
        }
        
        private string _location;
        public string location
        {
            get { return _location; }
            set
            {
                _location = value; RaisePropertyChanged("location");
            }
        }
        
        private string _party_type;
        public string party_type
        {
            get { return _party_type; }
            set
            {
                _party_type = value; RaisePropertyChanged("party_type");
            }
        }
        
        private string _party_group;
        public string party_group
        {
            get { return _party_group; }
            set
            {
                _party_group = value; RaisePropertyChanged("party_group");
            }
        }
        
        private string _buss_type;
        public string buss_type
        {
            get { return _buss_type; }
            set
            {
                _buss_type = value; RaisePropertyChanged("buss_type");
            }
        }
        
        private string _phone_no;
        public string phone_no
        {
            get { return _phone_no; }
            set
            {
                _phone_no = value; RaisePropertyChanged("phone_no");
            }
        }
        
        private string _phone_ext;
        public string phone_ext
        {
            get { return _phone_ext; }
            set
            {
                _phone_ext = value; RaisePropertyChanged("phone_ext");
            }
        }
        
        private string _fax_no;
        public string fax_no
        {
            get { return _fax_no; }
            set
            {
                _fax_no = value; RaisePropertyChanged("fax_no");
            }
        }
        
        private string _email_id;
        public string email_id
        {
            get { return _email_id; }
            set
            {
                _email_id = value; RaisePropertyChanged("email_id");
            }
        }
        
        private string _webside;
        public string webside
        {
            get { return _webside; }
            set
            {
                _webside = value; RaisePropertyChanged("webside");
            }
        }
        
        private Nullable<int> _sr_no;
        public Nullable<int> sr_no
        {
            get { return _sr_no; }
            set
            {
                _sr_no = value; RaisePropertyChanged("sr_no");
            }
        }
        
        private string _address_type;
        public string address_type
        {
            get { return _address_type; }
            set
            {
                _address_type = value; RaisePropertyChanged("address_type");
            }
        }
        
        private string _address1;
        public string address1
        {
            get { return _address1; }
            set
            {
                _address1 = value; RaisePropertyChanged("address1");
            }
        }
        
        private string _address2;
        public string address2
        {
            get { return _address2; }
            set
            {
                _address2 = value; RaisePropertyChanged("address2");
            }
        }
        
        private string _land_mark;
        public string land_mark
        {
            get { return _land_mark; }
            set
            {
                _land_mark = value; RaisePropertyChanged("land_mark");
            }
        }
        
        private string _city;
        public string city
        {
            get { return _city; }
            set
            {
                _city = value; RaisePropertyChanged("city");
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
       
        private string _state_code;
        public string state_code
        {
            get { return _state_code; }
            set
            {
                _state_code = value; RaisePropertyChanged("state_code");
            }
        }
        
        private string _pin;
        public string pin
        {
            get { return _pin; }
            set
            {
                _pin = value; RaisePropertyChanged("pin");
            }
        }
        
        private string _acc_group;
        public string acc_group
        {
            get { return _acc_group; }
            set
            {
                _acc_group = value; RaisePropertyChanged("acc_group");
            }
        }
        
        private string _region;
        public string region
        {
            get { return _region; }
            set
            {
                _region = value; RaisePropertyChanged("region");
            }
        }
        
        private string _corr_reg_no;
        public string corr_reg_no
        {
            get { return _corr_reg_no; }
            set
            {
                _corr_reg_no = value; RaisePropertyChanged("corr_reg_no");
            }
        }
        
        private string _gst_reg_no;
        public string gst_reg_no
        {
            get { return _gst_reg_no; }
            set
            {
                _gst_reg_no = value; RaisePropertyChanged("gst_reg_no");
            }
        }
        
        private string _cust_type;
        public string cust_type
        {
            get { return _cust_type; }
            set
            {
                _cust_type = value; RaisePropertyChanged("cust_type");
            }
        }
        
        private string _tax_lassification;
        public string tax_lassification
        {
            get { return _tax_lassification; }
            set
            {
                _tax_lassification = value; RaisePropertyChanged("tax_lassification");
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

        #endregion

        //XML doc 
        public string XmlDataDocument_ADM_M028_G { get; set; }
        public string XmlDataDocument_ADM_M028_F_Flip { get; set; }
    }
    public class ADM_M028_G : ObjectBase
    {
        
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value; RaisePropertyChanged("id");
            }
        }
        
        private string _party_id;
        public string party_id
        {
            get { return _party_id; }
            set
            {
                _party_id = value; RaisePropertyChanged("party_id");
            }
        }
        
        private string _sal_code;
        public string sal_code
        {
            get { return _sal_code; }
            set
            {
                _sal_code = value; RaisePropertyChanged("sal_code");
            }
        }
        
        private string _f_name;
        public string f_name
        {
            get { return _f_name; }
            set
            {
                _f_name = value; RaisePropertyChanged("f_name");
            }
        }
        
        private string _m_name;
        public string m_name
        {
            get { return _m_name; }
            set
            {
                _m_name = value; RaisePropertyChanged("m_name");
            }
        }
        
        private string _l_name;
        public string l_name
        {
            get { return _l_name; }
            set
            {
                _l_name = value; RaisePropertyChanged("l_name");
            }
        }
       
        private string _dept_code;
        public string dept_code
        {
            get { return _dept_code; }
            set
            {
                _dept_code = value; RaisePropertyChanged("dept_code");
            }
        }
       
        private string _desig_code;
        public string desig_code
        {
            get { return _desig_code; }
            set
            {
                _desig_code = value; RaisePropertyChanged("desig_code");
            }
        }
        
        private Nullable<int> _age;
        public Nullable<int> age
        {
            get { return _age; }
            set
            {
                _age = value; RaisePropertyChanged("comp_code");
            }
        }
        
        private string _gender;
        public string gender
        {
            get { return _gender; }
            set
            {
                _gender = value; RaisePropertyChanged("gender");
            }
        }
        
        private string _p_mobile_no;
        public string p_mobile_no
        {
            get { return _p_mobile_no; }
            set
            {
                _p_mobile_no = value; RaisePropertyChanged("p_mobile_no");
            }
        }
        
        private string _p_phone_no;
        public string p_phone_no
        {
            get { return _p_phone_no; }
            set
            {
                _p_phone_no = value; RaisePropertyChanged("p_phone_no");
            }
        }
        
        private string _p_phone_ext;
        public string p_phone_ext
        {
            get { return _p_phone_ext; }
            set
            {
                _p_phone_ext = value; RaisePropertyChanged("p_phone_ext");
            }
        }
        
        private string _p_fax_no;
        public string p_fax_no
        {
            get { return _p_fax_no; }
            set
            {
                _p_fax_no = value; RaisePropertyChanged("p_fax_no");
            }
        }
        
        private string _p_email;
        public string p_email
        {
            get { return _p_email; }
            set
            {
                _p_email = value; RaisePropertyChanged("p_email");
            }
        }
        
        private string _p_location;
        public string p_location
        {
            get { return _p_location; }
            set
            {
                _p_location = value; RaisePropertyChanged("p_location");
            }
        }
        
        private Nullable<bool> _default_del;
        public Nullable<bool> default_del
        {
            get { return _default_del; }
            set
            {
                _default_del = value; RaisePropertyChanged("default_del");
            }
        }
       
        private Nullable<bool> _default_bil;
        public Nullable<bool> default_bil
        {
            get { return _default_bil; }
            set
            {
                _default_bil = value; RaisePropertyChanged("default_bil");
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

        
        #endregion
    }
    public class MultipleContext_ADM_M028_F
    {
        public List<ADM_M028_F_BackFlip> BackFlipEntity { get; set; }
        public List<ADM_M028_F> MasterData { get; set; }
        public ObservableCollection<ADM_M028_G> DetailData { get; set; }
        public List<ADM_M028_B_P> PartyType { get; set; }
        public List<ADM_M028_A_P> Group { get; set; }
        public List<ADM_M012_P> Country { get; set; }
        public List<ADM_M013_P> State { get; set; }
        public List<ADM_M025_P> Department { get; set; }
        public List<ADM_M026_P> Designation { get; set; }
        public List<ADM_M050_P> Salutation { get; set; }
    }
    public class ADM_M028_F_BackFlip
    {
        public string party_id { get; set; }
        public int id { get; set; }
        public string party_name { get; set; }
        public string abbreviation { get; set; }
        public string location { get; set; }
        public string party_type { get; set; }
        public string party_group { get; set; }
        public string buss_type { get; set; }
        public string phone_no { get; set; }
        public string phone_ext { get; set; }
        public string fax_no { get; set; }
        public string email_id { get; set; }
        public string webside { get; set; }
        public Nullable<int> sr_no { get; set; }
        public string address_type { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string land_mark { get; set; }
        public string city { get; set; }
        public string country_code { get; set; }
        public string state_code { get; set; }
        public string pin { get; set; }
        public string acc_group { get; set; }
        public string region { get; set; }
        public string corr_reg_no { get; set; }
        public string gst_reg_no { get; set; }
        public string cust_type { get; set; }
        public string tax_lassification { get; set; }
    }
}
