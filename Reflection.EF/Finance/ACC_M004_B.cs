using System;

namespace Reflection.EF.Finance
{
    public class ACC_M004_B
    {
        public string hb_acc { get; set; }
        public string hb_code { get; set; }
        public string bank_code { get; set; }
        public string bank_key { get; set; }
        public string acc_id { get; set; }
        public string acc_no { get; set; }
        public string curr_code { get; set; }
        public string iban_no { get; set; }
        public string client { get; set; }
        public string comp_code { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<bool> active { get; set; }
        public string recon_acc { get; set; }
        public string ind_default { get; set; }

        //Scalar
        public string curr_name { get; set; }
        public string bank_name { get; set; }


    }
}
