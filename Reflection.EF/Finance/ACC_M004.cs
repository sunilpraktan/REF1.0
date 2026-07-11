using System;


namespace Reflection.EF.Finance
{
    public class ACC_M004 : ObjectBase
    {
        public string bank_code { get; set; }
        public int id { get; set; }
        public string bank_name { get; set; }
        public string owner_name { get; set; }
        public Nullable<int> p_sequence { get; set; }
        public string street { get; set; }
        public Nullable<int> partner_id { get; set; }
        public string PartyId { get; set; }
        public Nullable<int> bank { get; set; }
        public string branch { get; set; }
        public string ifsccode { get; set; }
        public string city { get; set; }
        public string p_name { get; set; }
        public string zip { get; set; }
        public Nullable<bool> footer { get; set; }
        public string state_code { get; set; }
        public string country_code { get; set; }
        public string location_Id { get; set; }
        public string p_state { get; set; }
        public string swift_code { get; set; }
        public string iban_no { get; set; }
        public string acc_number { get; set; }
        public string bk_abbriviation { get; set; }
        public string j_code { get; set; }
        public System.DateTime add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string CntryName { get; set; }
        public string recon_acc { get; set; }
    }
}
