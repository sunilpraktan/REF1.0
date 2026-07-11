using System;

namespace Reflection.EF.Finance
{
    public class ACC_M004_A
    {
        public string hb_code { get; set; }
        public string bank_key { get; set; }
        public string country_code { get; set; }
        public string bank_code { get; set; }
        public string branch { get; set; }
        public string ifsccode { get; set; }
        public string iban_no { get; set; }
        public string swift_code { get; set; }
        public string client { get; set; }
        public string comp_code { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string invoice_details { get; set; }

        // Scalar
        public string CntryName { get; set; }
        public string bank_name { get; set; }
        public string bk_abbriviation { get; set; }
    }
}
