using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.VMS
{
    public partial class VMS_T001 : ObjectBase
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
        public string ter_id { get; set; }
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
        public string lang_key { get; set; }
    }
    public partial class VMS_T001_A
    {
        public int id { get; set; }
        public string app_id { get; set; }
        public string m_code { get; set; }
        public string m_desc { get; set; }
        public string sr_no { get; set; }
        public string make { get; set; }
        public string m_cat_code { get; set; }
        public string m_type_code { get; set; }
        public Nullable<bool> m_type_notify { get; set; }
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
    public partial class VMS_T001_B
    {
        public int id { get; set; }
        public string app_id { get; set; }
        public string av_code { get; set; }
        public string av_name { get; set; }
        public string av_gender { get; set; }
        public string av_rfid_card_no { get; set; }
        public string av_pass_no { get; set; }
        public string av_badge_no { get; set; }
        public byte[] av_thumb1 { get; set; }
        public byte[] av_thumb2 { get; set; }
        public byte[] av_retina { get; set; }
        public byte[] av_palm { get; set; }
        public byte[] av_image { get; set; }
        public byte[] av_sign { get; set; }
        public Nullable<bool> av_notify { get; set; }
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
    public partial class VMS_T001_C
    {
        public int id { get; set; }
        public string app_id { get; set; }
        public string vehicle_type { get; set; }
        public string own_by { get; set; }
        public string vehicle_no { get; set; }
        public string make { get; set; }
        public string driver_id { get; set; }
        public string driver_name { get; set; }
        public string driver_type { get; set; }
        public string rent { get; set; }
        public string rent_unit { get; set; }
        public string total_travel { get; set; }
        public string total_travel_unit { get; set; }
        public Nullable<bool> vehicle_notify { get; set; }
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
    public partial class VMS_T001_D
    {
        public int id { get; set; }
        public string app_id { get; set; }
        public string emp_id { get; set; }
        public string first_name { get; set; }
        public string mid_name { get; set; }
        public string last_name { get; set; }
        public string present_status { get; set; }
        public Nullable<bool> add_h_notify { get; set; }
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
    public partial class VMS_T001_E
    {
        public int id { get; set; }
        public string app_id { get; set; }
        public string doc_code { get; set; }
        public Nullable<bool> doc_notify { get; set; }
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
    public partial class VMS_M004_A
    {
        public int id { get; set; }
        public string app_id { get; set; }
        public string facility_code { get; set; }
        public Nullable<bool> avail_status { get; set; }
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
