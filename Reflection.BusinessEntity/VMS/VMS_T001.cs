using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.VMS
{
    public class VMS_T001 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _app_id;
        public string app_id
        {
            get { return _app_id; }
            set
            {
                _app_id = value; RaisePropertyChanged("app_id");
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
        
        private string _v_first_nm;
        public string v_first_nm
        {
            get { return _v_first_nm; }
            set
            {
                _v_first_nm = value; RaisePropertyChanged("v_first_nm");
            }
        }
        
        private string _v_mid_nm;
        public string v_mid_nm
        {
            get { return _v_mid_nm; }
            set
            {
                _v_mid_nm = value; RaisePropertyChanged("v_mid_nm");
            }
        }
        
        private string _v_last_nm;
        public string v_last_nm
        {
            get { return _v_last_nm; }
            set
            {
                _v_last_nm = value; RaisePropertyChanged("v_last_nm");
            }
        }
        
        private string _v_gender;
        public string v_gender
        {
            get { return _v_gender; }
            set
            {
                _v_gender = value; RaisePropertyChanged("v_gender");
            }
        }
        
        private Nullable<System.DateTime> _v_dob;
        public Nullable<System.DateTime> v_dob
        {
            get { return _v_dob; }
            set
            {
                _v_dob = value; RaisePropertyChanged("v_dob");
            }
        }
        
        private string _v_party_id;
        public string v_party_id
        {
            get { return _v_party_id; }
            set
            {
                _v_party_id = value; RaisePropertyChanged("v_party_id");
            }
        }
        
        private string _v_party_name;
        public string v_party_name
        {
            get { return _v_party_name; }
            set
            {
                _v_party_name = value; RaisePropertyChanged("v_party_name");
            }
        }
        
        private string _gate_no;
        public string gate_no
        {
            get { return _gate_no; }
            set
            {
                _gate_no = value; RaisePropertyChanged("gate_no");
            }
        }
       
        private string _v_religion;
        public string v_religion
        {
            get { return _v_religion; }
            set
            {
                _v_religion = value; RaisePropertyChanged("v_religion");
            }
        }
        
        private string _v_cat_code;
        public string v_cat_code
        {
            get { return _v_cat_code; }
            set
            {
                _v_cat_code = value; RaisePropertyChanged("v_cat_code");
            }
        }
        
        private string _v_email;
        public string v_email
        {
            get { return _v_email; }
            set
            {
                _v_email = value; RaisePropertyChanged("v_email", ModelEntityUpdated);
            }
        }
        
        private string _v_phno1;
        public string v_phno1
        {
            get { return _v_phno1; }
            set
            {
                _v_phno1 = value; RaisePropertyChanged("v_phno1", ModelEntityUpdated);
            }
        }

        private string _v_phno2;
        public string v_phno2
        {
            get { return _v_phno2; }
            set
            {
                _v_phno2 = value; RaisePropertyChanged("v_phno2", ModelEntityUpdated);
            }
        }

        private string _v_emg_no;
        public string v_emg_no
        {
            get { return _v_emg_no; }
            set
            {
                _v_emg_no = value; RaisePropertyChanged("v_emg_no");
            }
        }
        
        private string _v_nation;
        public string v_nation
        {
            get { return _v_nation; }
            set
            {
                _v_nation = value; RaisePropertyChanged("v_nation");
            }
        }
        
        private string _v_address;
        public string v_address
        {
            get { return _v_address; }
            set
            {
                _v_address = value; RaisePropertyChanged("v_address");
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
        
        private string _v_city;
        public string v_city
        {
            get { return _v_city; }
            set
            {
                _v_city = value; RaisePropertyChanged("v_city");
            }
        }
        
        private string _v_pin;
        public string v_pin
        {
            get { return _v_pin; }
            set
            {
                _v_pin = value; RaisePropertyChanged("v_pin");
            }
        }
        
        private byte[] _v_thumb1;
        public byte[] v_thumb1
        {
            get { return _v_thumb1; }
            set
            {
                _v_thumb1 = value; RaisePropertyChanged("v_thumb1");
            }
        }
        
        private byte[] _v_thumb2;
        public byte[] v_thumb2
        {
            get { return _v_thumb2; }
            set
            {
                _v_thumb2 = value; RaisePropertyChanged("v_thumb2");
            }
        }
        
        private byte[] _v_retina;
        public byte[] v_retina
        {
            get { return _v_retina; }
            set
            {
                _v_retina = value; RaisePropertyChanged("v_retina");
            }
        }
        
        private byte[] _v_palm;
        public byte[] v_palm
        {
            get { return _v_palm; }
            set
            {
                _v_palm = value; RaisePropertyChanged("v_palm");
            }
        }
        
        private byte[] _v_image;
        public byte[] v_image
        {
            get { return _v_image; }
            set
            {
                _v_image = value; RaisePropertyChanged("v_image");
            }
        }
        
        private byte[] _v_sign;
        public byte[] v_sign
        {
            get { return _v_sign; }
            set
            {
                _v_sign = value; RaisePropertyChanged("v_sign");
            }
        }
        
        private string _v_off_no;
        public string v_off_no
        {
            get { return _v_off_no; }
            set
            {
                _v_off_no = value; RaisePropertyChanged("v_off_no");
            }
        }
       
        private string _v_off_ext_no;
        public string v_off_ext_no
        {
            get { return _v_off_ext_no; }
            set
            {
                _v_off_ext_no = value; RaisePropertyChanged("v_off_ext_no");
            }
        }
        
        private Nullable<int> _add_v_no;
        public Nullable<int> add_v_no
        {
            get { return _add_v_no; }
            set
            {
                _add_v_no = value; RaisePropertyChanged("add_v_no");
            }
        }
        
        private string _v_language;
        public string v_language
        {
            get { return _v_language; }
            set
            {
                _v_language = value; RaisePropertyChanged("v_language");
            }
        }
        
        private string _visit_desc;
        public string visit_desc
        {
            get { return _visit_desc; }
            set
            {
                _visit_desc = value; RaisePropertyChanged("visit_desc");
            }
        }
        
        private string _vp_code;
        public string vp_code
        {
            get { return _vp_code; }
            set
            {
                _vp_code = value; RaisePropertyChanged("vp_code");
            }
        }

        private string _ter_id;
        public string ter_id
        {
            get { return _ter_id; }
            set
            {
                _ter_id = value; RaisePropertyChanged("ter_id");
            }
        }

        private string _meet_sub;
        public string meet_sub
        {
            get { return _meet_sub; }
            set
            {
                _meet_sub = value; RaisePropertyChanged("meet_sub");
            }
        }
        
        private string _meet_desc;
        public string meet_desc
        {
            get { return _meet_desc; }
            set
            {
                _meet_desc = value; RaisePropertyChanged("meet_desc");
            }
        }
        
        private string _app_by;
        public string app_by
        {
            get { return _app_by; }
            set
            {
                _app_by = value; RaisePropertyChanged("app_by");
            }
        }
        
        private Nullable<System.DateTime> _pro_dt_frm;
        public Nullable<System.DateTime> pro_dt_frm
        {
            get { return _pro_dt_frm; }
            set
            {
                _pro_dt_frm = value; RaisePropertyChanged("pro_dt_frm");
            }
        }
        
        private Nullable<System.DateTime> _pro_dt_to;
        public Nullable<System.DateTime> pro_dt_to
        {
            get { return _pro_dt_to; }
            set
            {
                _pro_dt_to = value; RaisePropertyChanged("pro_dt_to");
            }
        }
        
        private string _pro_tm_frm;
        public string pro_tm_frm
        {
            get { return _pro_tm_frm; }
            set
            {
                _pro_tm_frm = value; RaisePropertyChanged("pro_tm_frm");
            }
        }
        
        private string _pro_tm_to;
        public string pro_tm_to
        {
            get { return _pro_tm_to; }
            set
            {
                _pro_tm_to = value; RaisePropertyChanged("pro_tm_to");
            }
        }
        
        private Nullable<System.DateTime> _sch_dt_frm;
        public Nullable<System.DateTime> sch_dt_frm
        {
            get { return _sch_dt_frm; }
            set
            {
                _sch_dt_frm = value; RaisePropertyChanged("sch_dt_frm");
            }
        }
        
        private Nullable<System.DateTime> _sch_dt_to;
        public Nullable<System.DateTime> sch_dt_to
        {
            get { return _sch_dt_to; }
            set
            {
                _sch_dt_to = value; RaisePropertyChanged("sch_dt_to");
            }
        }
        
        private string _sch_tm_frm;
        public string sch_tm_frm
        {
            get { return _sch_tm_frm; }
            set
            {
                _sch_tm_frm = value; RaisePropertyChanged("sch_tm_frm");
            }
        }
        
        private string _sch_tm_to;
        public string sch_tm_to
        {
            get { return _sch_tm_to; }
            set
            {
                _sch_tm_to = value; RaisePropertyChanged("sch_tm_to");
            }
        }
        
        private Nullable<System.DateTime> _meet_dt_frm;
        public Nullable<System.DateTime> meet_dt_frm
        {
            get { return _meet_dt_frm; }
            set
            {
                _meet_dt_frm = value; RaisePropertyChanged("meet_dt_frm");
            }
        }
        
        private Nullable<System.DateTime> _meet_dt_to;
        public Nullable<System.DateTime> meet_dt_to
        {
            get { return _meet_dt_to; }
            set
            {
                _meet_dt_to = value; RaisePropertyChanged("meet_dt_to");
            }
        }
        
        private Nullable<System.DateTime> _valid_dt_frm;
        public Nullable<System.DateTime> valid_dt_frm
        {
            get { return _valid_dt_frm; }
            set
            {
                _valid_dt_frm = value; RaisePropertyChanged("valid_dt_frm");
            }
        }
        
        private Nullable<System.DateTime> _valid_dt_to;
        public Nullable<System.DateTime> valid_dt_to
        {
            get { return _valid_dt_to; }
            set
            {
                _valid_dt_to = value; RaisePropertyChanged("valid_dt_to");
            }
        }
        
        private string _valid_tm_frm;
        public string valid_tm_frm
        {
            get { return _valid_tm_frm; }
            set
            {
                _valid_tm_frm = value; RaisePropertyChanged("valid_tm_frm");
            }
        }
        
        private string _valid_tm_to;
        public string valid_tm_to
        {
            get { return _valid_tm_to; }
            set
            {
                _valid_tm_to = value; RaisePropertyChanged("valid_tm_to");
            }
        }
        
        private Nullable<System.DateTime> _acc_dt_frm;
        public Nullable<System.DateTime> acc_dt_frm
        {
            get { return _acc_dt_frm; }
            set
            {
                _acc_dt_frm = value; RaisePropertyChanged("acc_dt_frm");
            }
        }
        
        private Nullable<System.DateTime> _acc_dt_to;
        public Nullable<System.DateTime> acc_dt_to
        {
            get { return _acc_dt_to; }
            set
            {
                _acc_dt_to = value; RaisePropertyChanged("acc_dt_to");
            }
        }
        
        private string _acc_tm_frm;
        public string acc_tm_frm
        {
            get { return _acc_tm_frm; }
            set
            {
                _acc_tm_frm = value; RaisePropertyChanged("acc_tm_frm");
            }
        }
        
        private string _acc_tm_to;
        public string acc_tm_to
        {
            get { return _acc_tm_to; }
            set
            {
                _acc_tm_to = value; RaisePropertyChanged("acc_tm_to");
            }
        }
        
        private string _gst_house_code;
        public string gst_house_code
        {
            get { return _gst_house_code; }
            set
            {
                _gst_house_code = value; RaisePropertyChanged("gst_house_code");
            }
        }
        
        private Nullable<bool> _acc_int;
        public Nullable<bool> acc_int
        {
            get { return _acc_int; }
            set
            {
                _acc_int = value; RaisePropertyChanged("acc_int");
            }
        }
        
        private Nullable<bool> _acc_ext;
        public Nullable<bool> acc_ext
        {
            get { return _acc_ext; }
            set
            {
                _acc_ext = value; RaisePropertyChanged("acc_ext");
            }
        }
        
        private Nullable<bool> _acc_paid;
        public Nullable<bool> acc_paid
        {
            get { return _acc_paid; }
            set
            {
                _acc_paid = value; RaisePropertyChanged("acc_paid");
            }
        }
        
        private Nullable<bool> _acc_free;
        public Nullable<bool> acc_free
        {
            get { return _acc_free; }
            set
            {
                _acc_free = value; RaisePropertyChanged("acc_free");
            }
        }
        
        private string _acc_build_no;
        public string acc_build_no
        {
            get { return _acc_build_no; }
            set
            {
                _acc_build_no = value; RaisePropertyChanged("acc_build_no");
            }
        }
        
        private string _acc_room_no;
        public string acc_room_no
        {
            get { return _acc_room_no; }
            set
            {
                _acc_room_no = value; RaisePropertyChanged("acc_room_no");
            }
        }
        
        private string _acc_place_id;
        public string acc_place_id
        {
            get { return _acc_place_id; }
            set
            {
                _acc_place_id = value; RaisePropertyChanged("acc_place_id");
            }
        }
        
        private string _acc_agency_id;
        public string acc_agency_id
        {
            get { return _acc_agency_id; }
            set
            {
                _acc_agency_id = value; RaisePropertyChanged("acc_agency_id");
            }
        }
        
        private string _acc_room_desc;
        public string acc_room_desc
        {
            get { return _acc_room_desc; }
            set
            {
                _acc_room_desc = value; RaisePropertyChanged("acc_room_desc");
            }
        }
        
        private string _h_name;
        public string h_name
        {
            get { return _h_name; }
            set
            {
                _h_name = value; RaisePropertyChanged("h_name");
            }
        }
        
        private string _h_emp_id;
        public string h_emp_id
        {
            get { return _h_emp_id; }
            set
            {
                _h_emp_id = value; RaisePropertyChanged("h_emp_id");
            }
        }
        
        private string _h_phone_no;
        public string h_phone_no
        {
            get { return _h_phone_no; }
            set
            {
                _h_phone_no = value; RaisePropertyChanged("h_phone_no");
            }
        }
        
        private string _h_landline;
        public string h_landline
        {
            get { return _h_landline; }
            set
            {
                _h_landline = value; RaisePropertyChanged("h_landline");
            }
        }
        
        private string _h_ext_no;
        public string h_ext_no
        {
            get { return _h_ext_no; }
            set
            {
                _h_ext_no = value; RaisePropertyChanged("h_ext_no");
            }
        }
        
        private string _h_email;
        public string h_email
        {
            get { return _h_email; }
            set
            {
                _h_email = value; RaisePropertyChanged("h_email");
            }
        }
        
        private string _h_work_place;
        public string h_work_place
        {
            get { return _h_work_place; }
            set
            {
                _h_work_place = value; RaisePropertyChanged("h_work_place");
            }
        }
        
        private Nullable<int> _add_h_no;
        public Nullable<int> add_h_no
        {
            get { return _add_h_no; }
            set
            {
                _add_h_no = value; RaisePropertyChanged("comp_code");
            }
        }
        
        private string _h_chkout_remark;
        public string h_chkout_remark
        {
            get { return _h_chkout_remark; }
            set
            {
                _h_chkout_remark = value; RaisePropertyChanged("h_chkout_remark");
            }
        }
        
        private Nullable<bool> _h_chkout_enable;
        public Nullable<bool> h_chkout_enable
        {
            get { return _h_chkout_enable; }
            set
            {
                _h_chkout_enable = value; RaisePropertyChanged("h_chkout_enable");
            }
        }

        private string _h_ra_define;
        public string h_ra_define
        {
            get { return _h_ra_define; }
            set
            {
                _h_ra_define = value; RaisePropertyChanged("h_ra_define");
            }
        }

        private string _v_rfid_card_no;
        public string v_rfid_card_no
        {
            get { return _v_rfid_card_no; }
            set
            {
                _v_rfid_card_no = value; RaisePropertyChanged("v_rfid_card_no");
            }
        }
        
        private string _bl_code;
        public string bl_code
        {
            get { return _bl_code; }
            set
            {
                _bl_code = value; RaisePropertyChanged("bl_code");
            }
        }
        
        private Nullable<bool> _bl_status;
        public Nullable<bool> bl_status
        {
            get { return _bl_status; }
            set
            {
                _bl_status = value; RaisePropertyChanged("bl_status");
            }
        }
       
        private string _bl_remark;
        public string bl_remark
        {
            get { return _bl_remark; }
            set
            {
                _bl_remark = value; RaisePropertyChanged("bl_remark");
            }
        }
        
        private Nullable<bool> _chk_in;
        public Nullable<bool> chk_in
        {
            get { return _chk_in; }
            set
            {
                _chk_in = value; RaisePropertyChanged("chk_in");
            }
        }
        
        private Nullable<bool> _chk_out;
        public Nullable<bool> chk_out
        {
            get { return _chk_out; }
            set
            {
                _chk_out = value; RaisePropertyChanged("chk_out");
            }
        }
        
        private string _dept;
        public string dept
        {
            get { return _dept; }
            set
            {
                _dept = value; RaisePropertyChanged("dept");
            }
        }
        
        private string _ref_by;
        public string ref_by
        {
            get { return _ref_by; }
            set
            {
                _ref_by = value; RaisePropertyChanged("ref_by");
            }
        }
        
        private string _v_pass_no;
        public string v_pass_no
        {
            get { return _v_pass_no; }
            set
            {
                _v_pass_no = value; RaisePropertyChanged("v_pass_no");
            }
        }
        
        private string _v_badge_no;
        public string v_badge_no
        {
            get { return _v_badge_no; }
            set
            {
                _v_badge_no = value; RaisePropertyChanged("v_badge_no");
            }
        }
        
        private string _v_book_entry_no;
        public string v_book_entry_no
        {
            get { return _v_book_entry_no; }
            set
            {
                _v_book_entry_no = value; RaisePropertyChanged("v_book_entry_no");
            }
        }
        
        private string _escort;
        public string escort
        {
            get { return _escort; }
            set
            {
                _escort = value; RaisePropertyChanged("escort");
            }
        }
        
        private string _security_clear;
        public string security_clear
        {
            get { return _security_clear; }
            set
            {
                _security_clear = value; RaisePropertyChanged("security_clear");
            }
        }
        
        private string _security_remark;
        public string security_remark
        {
            get { return _security_remark; }
            set
            {
                _security_remark = value; RaisePropertyChanged("security_remark");
            }
        }
        
        private string _place_code;
        public string place_code
        {
            get { return _place_code; }
            set
            {
                _place_code = value; RaisePropertyChanged("place_code");
            }
        }
        
        private Nullable<bool> _sms_notify;
        public Nullable<bool> sms_notify
        {
            get { return _sms_notify; }
            set
            {
                _sms_notify = value; RaisePropertyChanged("sms_notify");
            }
        }
        
        private Nullable<bool> _email_notify;
        public Nullable<bool> email_notify
        {
            get { return _email_notify; }
            set
            {
                _email_notify = value; RaisePropertyChanged("email_notify");
            }
        }
       
        private Nullable<bool> _phone_notify;
        public Nullable<bool> phone_notify
        {
            get { return _phone_notify; }
            set
            {
                _phone_notify = value; RaisePropertyChanged("phone_notify");
            }
        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set
            {
                _remark = value; RaisePropertyChanged("remark");
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
        public string XmlDataDocument_VMS_T001_A { get; set; }
        public string XmlDataDocument_VMS_T001_B { get; set; }
        public string XmlDataDocument_VMS_T001_C { get; set; }
        public string XmlDataDocument_VMS_T001_D { get; set; }
        public string XmlDataDocument_VMS_T001_E { get; set; }
        public string XmlDataDocument_VMS_M004_A { get; set; }
        public string XmlDataDocument_VMS_T001_Flip { get; set; }
    }
    public class VMS_T001_A : ObjectBase
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
       
        private string _app_id;
        public string app_id
        {
            get { return _app_id; }
            set
            {
                _app_id = value; RaisePropertyChanged("app_id");
            }
        }
        
        private string _m_code;
        public string m_code
        {
            get { return _m_code; }
            set
            {
                _m_code = value; RaisePropertyChanged("m_code");
            }
        }
        
        private string _m_desc;
        public string m_desc
        {
            get { return _m_desc; }
            set
            {
                _m_desc = value; RaisePropertyChanged("m_desc");
            }
        }
        
        private string _sr_no;
        public string sr_no
        {
            get { return _sr_no; }
            set
            {
                _sr_no = value; RaisePropertyChanged("sr_no");
            }
        }
        
        private string _make;
        public string make
        {
            get { return _make; }
            set
            {
                _make = value; RaisePropertyChanged("make");
            }
        }
        
        private string _m_cat_code;
        public string m_cat_code
        {
            get { return _m_cat_code; }
            set
            {
                _m_cat_code = value; RaisePropertyChanged("m_cat_code");
            }
        }
       
        private string _m_type_code;
        public string m_type_code
        {
            get { return _m_type_code; }
            set
            {
                _m_type_code = value; RaisePropertyChanged("m_type_code");
            }
        }
        
        private Nullable<bool> _m_type_notify;
        public Nullable<bool> m_type_notify
        {
            get { return _m_type_notify; }
            set
            {
                _m_type_notify = value; RaisePropertyChanged("m_type_notify");
            }
        }
        
        private string _remark;
        public string remark
        {
            get { return _remark; }
            set
            {
                _remark = value; RaisePropertyChanged("remark");
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
    public class VMS_T001_B : ObjectBase
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

        private string _app_id;
        public string app_id
        {
            get { return _app_id; }
            set
            {
                _app_id = value; RaisePropertyChanged("app_id");
            }
        }
        
        private string _av_code;
        public string av_code
        {
            get { return _av_code; }
            set
            {
                _av_code = value; RaisePropertyChanged("av_code");
            }
        }
        
        private string _av_name;
        public string av_name
        {
            get { return _av_name; }
            set
            {
                _av_name = value; RaisePropertyChanged("av_name");
            }
        }
        
        private string _av_gender;
        public string av_gender
        {
            get { return _av_gender; }
            set
            {
                _av_gender = value; RaisePropertyChanged("av_gender");
            }
        }
        
        private string _av_rfid_card_no;
        public string av_rfid_card_no
        {
            get { return _av_rfid_card_no; }
            set
            {
                _av_rfid_card_no = value; RaisePropertyChanged("av_rfid_card_no");
            }
        }
        
        private string _av_pass_no;
        public string av_pass_no
        {
            get { return _av_pass_no; }
            set
            {
                _av_pass_no = value; RaisePropertyChanged("av_pass_no");
            }
        }
        
        private string _av_badge_no;
        public string av_badge_no
        {
            get { return _av_badge_no; }
            set
            {
                _av_badge_no = value; RaisePropertyChanged("av_badge_no");
            }
        }
        
        private byte[] _av_thumb1;
        public byte[] av_thumb1
        {
            get { return _av_thumb1; }
            set
            {
                _av_thumb1 = value; RaisePropertyChanged("av_thumb1");
            }
        }
        
        private byte[] _av_thumb2;
        public byte[] av_thumb2
        {
            get { return _av_thumb2; }
            set
            {
                _av_thumb2 = value; RaisePropertyChanged("av_thumb2");
            }
        }
        
        private byte[] _av_retina;
        public byte[] av_retina
        {
            get { return _av_retina; }
            set
            {
                _av_retina = value; RaisePropertyChanged("av_retina");
            }
        }
        
        private byte[] _av_palm;
        public byte[] av_palm
        {
            get { return _av_palm; }
            set
            {
                _av_palm = value; RaisePropertyChanged("av_palm");
            }
        }
        
        private byte[] _av_image;
        public byte[] av_image
        {
            get { return _av_image; }
            set
            {
                _av_image = value; RaisePropertyChanged("av_image");
            }
        }
        
        private byte[] _av_sign;
        public byte[] av_sign
        {
            get { return _av_sign; }
            set
            {
                _av_sign = value; RaisePropertyChanged("av_sign");
            }
        }
        
        private Nullable<bool> _av_notify;
        public Nullable<bool> av_notify
        {
            get { return _av_notify; }
            set
            {
                _av_notify = value; RaisePropertyChanged("av_notify");
            }
        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set
            {
                _remark = value; RaisePropertyChanged("remark");
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
    public class VMS_T001_C : ObjectBase
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

        private string _app_id;
        public string app_id
        {
            get { return _app_id; }
            set
            {
                _app_id = value; RaisePropertyChanged("app_id");
            }
        }
        
        private string _vehicle_type;
        public string vehicle_type
        {
            get { return _vehicle_type; }
            set
            {
                _vehicle_type = value; RaisePropertyChanged("vehicle_type");
            }
        }
        
        private string _own_by;
        public string own_by
        {
            get { return _own_by; }
            set
            {
                _own_by = value; RaisePropertyChanged("own_by");
            }
        }
        
        private string _vehicle_no;
        public string vehicle_no
        {
            get { return _vehicle_no; }
            set
            {
                _vehicle_no = value; RaisePropertyChanged("vehicle_no");
            }
        }
        
        private string _make;
        public string make
        {
            get { return _make; }
            set
            {
                _make = value; RaisePropertyChanged("make");
            }
        }
        
        private string _driver_id;
        public string driver_id
        {
            get { return _driver_id; }
            set
            {
                _driver_id = value; RaisePropertyChanged("driver_id");
            }
        }
        
        private string _driver_name;
        public string driver_name
        {
            get { return _driver_name; }
            set
            {
                _driver_name = value; RaisePropertyChanged("driver_name");
            }
        }
        
        private string _driver_type;
        public string driver_type
        {
            get { return _driver_type; }
            set
            {
                _driver_type = value; RaisePropertyChanged("driver_type");
            }
        }
        
        private string _rent;
        public string rent
        {
            get { return _rent; }
            set
            {
                _rent = value; RaisePropertyChanged("rent");
            }
        }
        
        private string _rent_unit;
        public string rent_unit
        {
            get { return _rent_unit; }
            set
            {
                _rent_unit = value; RaisePropertyChanged("rent_unit");
            }
        }
        
        private string _total_travel;
        public string total_travel
        {
            get { return _total_travel; }
            set
            {
                _total_travel = value; RaisePropertyChanged("total_travel");
            }
        }
        
        private string _total_travel_unit;
        public string total_travel_unit
        {
            get { return _total_travel_unit; }
            set
            {
                _total_travel_unit = value; RaisePropertyChanged("total_travel_unit");
            }
        }
        
        private Nullable<bool> _vehicle_notify;
        public Nullable<bool> vehicle_notify
        {
            get { return _vehicle_notify; }
            set
            {
                _vehicle_notify = value; RaisePropertyChanged("vehicle_notify");
            }
        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set
            {
                _remark = value; RaisePropertyChanged("remark");
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
    public class VMS_T001_D : ObjectBase
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

        private string _app_id;
        public string app_id
        {
            get { return _app_id; }
            set
            {
                _app_id = value; RaisePropertyChanged("app_id");
            }
        }

        private string _emp_id;
        public string emp_id
        {
            get { return _emp_id; }
            set
            {
                _emp_id = value; RaisePropertyChanged("emp_id");
            }
        }

        private string _first_name;
        public string first_name
        {
            get { return _first_name; }
            set
            {
                _first_name = value; RaisePropertyChanged("first_name");
            }
        }

        private string _mid_name;
        public string mid_name
        {
            get { return _mid_name; }
            set
            {
                _mid_name = value; RaisePropertyChanged("mid_name");
            }
        }

        private string _last_name;
        public string last_name
        {
            get { return _last_name; }
            set
            {
                _last_name = value; RaisePropertyChanged("last_name");
            }
        }

        private string _present_status;
        public string present_status
        {
            get { return _present_status; }
            set
            {
                _present_status = value; RaisePropertyChanged("present_status");
            }
        }

        private Nullable<bool> _add_h_notify;
        public Nullable<bool> add_h_notify
        {
            get { return _add_h_notify; }
            set
            {
                _add_h_notify = value; RaisePropertyChanged("add_h_notify");
            }
        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set
            {
                _remark = value; RaisePropertyChanged("remark");
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
    public class VMS_T001_E : ObjectBase
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

        private string _app_id;
        public string app_id
        {
            get { return _app_id; }
            set
            {
                _app_id = value; RaisePropertyChanged("app_id");
            }
        }
        
        private string _doc_code;
        public string doc_code
        {
            get { return _doc_code; }
            set
            {
                _doc_code = value; RaisePropertyChanged("doc_code");
            }
        }
        
        private Nullable<bool> _doc_notify;
        public Nullable<bool> doc_notify
        {
            get { return _doc_notify; }
            set
            {
                _doc_notify = value; RaisePropertyChanged("doc_notify");
            }
        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set
            {
                _remark = value; RaisePropertyChanged("remark");
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
    public class VMS_M004_A : ObjectBase
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
       
        private string _app_id;
        public string app_id
        {
            get { return _app_id; }
            set
            {
                _app_id = value; RaisePropertyChanged("app_id");
            }
        }
        
        private string _facility_code;
        public string facility_code
        {
            get { return _facility_code; }
            set
            {
                _facility_code = value; RaisePropertyChanged("facility_code");
            }
        }
        
        private Nullable<bool> _avail_status;
        public Nullable<bool> avail_status
        {
            get { return _avail_status; }
            set
            {
                _avail_status = value; RaisePropertyChanged("avail_status");
            }
        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set
            {
                _remark = value; RaisePropertyChanged("remark");
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
    public class MultipleContext_VMS_T001
    {
        public List<VMS_T001_BackFlip> BackFlipEntity { get; set; }
        public List<VMS_T001> MasterData { get; set; }
        public ObservableCollection<VMS_T001_A> DetailData_A { get; set; }
        public ObservableCollection<VMS_T001_B> DetailData_B { get; set; }
        public ObservableCollection<VMS_T001_C> DetailData_C { get; set; }
        public ObservableCollection<VMS_T001_D> DetailData_D { get; set; }
        public ObservableCollection<VMS_T001_E> DetailData_E { get; set; }
        public ObservableCollection<VMS_M004_A> DetailData_X { get; set; }
        public List<ADM_M050_P> Salutation { get; set; }
        public List<VMS_M001_P> VCategory { get; set; }
        public List<ADM_M028_P> VCompany { get; set; }
        public List<ADM_M013_P> State { get; set; }
        public List<ADM_M012_P> Country { get; set; }
        public List<ADM_M051_P> Nationality { get; set; }
        public List<VMS_M002_P> VisitPurpose { get; set; }
        public List<VMS_M003_P> MeetingPlace { get; set; }
        public List<VMS_M004_P> VFacility { get; set; }
        public List<VMS_M005_P> GuestHouse { get; set; }
        public List<VMS_M006_P> VDocument { get; set; }
        public List<VMS_M007_P> VMaterialCategory { get; set; }
        public List<VMS_M008_P> VMaterialType { get; set; }
        public List<ADM_M024_P> HEmployee { get; set; }
        public List<HRM_M015_P> EntryGateNo { get; set; }
    }
    public class VMS_T001_BackFlip
    {
        public string app_id { get; set; }
        public string sal_code { get; set; }
        public string v_first_nm { get; set; }
        public string v_mid_nm { get; set; }
        public string v_last_nm { get; set; }
        public string v_gender { get; set; }
        public Nullable<System.DateTime> v_dob { get; set; }
        public string v_party_id { get; set; }
        public string v_party_name { get; set; }
        public string gate_no { get; set; }
        public string v_religion { get; set; }
        public string v_cat_code { get; set; }
        public string v_email { get; set; }
        public string v_phno1 { get; set; }
        public string v_phno2 { get; set; }
        public string v_emg_no { get; set; }
        public string v_nation { get; set; }
        public string v_address { get; set; }
        public string country_code { get; set; }
        public string state_code { get; set; }
        public string v_city { get; set; }
        public string v_pin { get; set; }
        public byte[] v_thumb1 { get; set; }
        public byte[] v_thumb2 { get; set; }
        public byte[] v_retina { get; set; }
        public byte[] v_palm { get; set; }
        public byte[] v_image { get; set; }
        public byte[] v_sign { get; set; }
        public string v_off_no { get; set; }
        public string v_off_ext_no { get; set; }
        public Nullable<int> add_v_no { get; set; }
        public string v_language { get; set; }
        public string visit_desc { get; set; }
        public string vp_code { get; set; }
        public string meet_sub { get; set; }
        public string meet_desc { get; set; }
        public string app_by { get; set; }
        public Nullable<System.DateTime> pro_dt_frm { get; set; }
        public Nullable<System.DateTime> pro_dt_to { get; set; }
        public string pro_tm_frm { get; set; }
        public string pro_tm_to { get; set; }
        public Nullable<System.DateTime> sch_dt_frm { get; set; }
        public Nullable<System.DateTime> sch_dt_to { get; set; }
        public string sch_tm_frm { get; set; }
        public string sch_tm_to { get; set; }
        public Nullable<System.DateTime> meet_dt_frm { get; set; }
        public Nullable<System.DateTime> meet_dt_to { get; set; }
        public Nullable<System.DateTime> valid_dt_frm { get; set; }
        public Nullable<System.DateTime> valid_dt_to { get; set; }
        public string valid_tm_frm { get; set; }
        public string valid_tm_to { get; set; }
        public Nullable<System.DateTime> acc_dt_frm { get; set; }
        public Nullable<System.DateTime> acc_dt_to { get; set; }
        public string acc_tm_frm { get; set; }
        public string acc_tm_to { get; set; }
        public string gst_house_code { get; set; }
        public Nullable<bool> acc_int { get; set; }
        public Nullable<bool> acc_ext { get; set; }
        public Nullable<bool> acc_paid { get; set; }
        public Nullable<bool> acc_free { get; set; }
        public string acc_build_no { get; set; }
        public string acc_room_no { get; set; }
        public string acc_place_id { get; set; }
        public string acc_agency_id { get; set; }
        public string acc_room_desc { get; set; }
        public string h_name { get; set; }
        public string h_emp_id { get; set; }
        public string h_phone_no { get; set; }
        public string h_landline { get; set; }
        public string h_ext_no { get; set; }
        public string h_email { get; set; }
        public string h_work_place { get; set; }
        public Nullable<int> add_h_no { get; set; }
        public string h_chkout_remark { get; set; }
        public Nullable<bool> h_chkout_enable { get; set; }
        public string h_ra_define { get; set; }
        public string v_rfid_card_no { get; set; }
        public string bl_code { get; set; }
        public Nullable<bool> bl_status { get; set; }
        public string bl_remark { get; set; }
        public Nullable<bool> chk_in { get; set; }
        public Nullable<bool> chk_out { get; set; }
        public string dept { get; set; }
        public string ref_by { get; set; }
        public string v_pass_no { get; set; }
        public string v_badge_no { get; set; }
        public string v_book_entry_no { get; set; }
        public string escort { get; set; }
        public string security_clear { get; set; }
        public string security_remark { get; set; }
        public string place_code { get; set; }
        public Nullable<bool> sms_notify { get; set; }
        public Nullable<bool> email_notify { get; set; }
        public Nullable<bool> phone_notify { get; set; }
        public string remark { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
    }
}
