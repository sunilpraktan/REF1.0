using System;

namespace Reflection.EF.Admin
{
    public partial class ADM_M003_B
    {
        public int lab_id { get; set; }
        public string lab_code { get; set; }
        public string lab_name { get; set; }
        public string lab_abbr { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string addr1 { get; set; }
        public string addr2 { get; set; }
        public string city { get; set; }
        public string state_code { get; set; }
        public string country_code { get; set; }
        public string pin_no { get; set; }
        public string ph_off { get; set; }
        public string ph_ext { get; set; }
        public string faxno { get; set; }
        public string email { get; set; }
        public string activity_code { get; set; }
        public string add_by { get; set; }
        public DateTime? add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public bool? active { get; set; }
        public string lang_key { get; set; }
        public string client { get; set; }
        public string EmpId { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }

        //scalar
        public string LoctnNm { get; set; }
        public string CntryName { get; set; }
        public string StatName { get; set; }
        public string activtNm { get; set; }
        public string CompName { get; set; }
        public string EmpName { get; set; }
        public string EmpMobNo { get; set; }
        public string EmpEmailId { get; set; }
        public string XMLDataDocument_ADM_M003_B { get; set; }
    }
}
