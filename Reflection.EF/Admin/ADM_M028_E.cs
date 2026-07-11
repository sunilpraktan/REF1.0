using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public class ADM_M028_E
    {
        public string pb_code { get; set; }
        public int id { get; set; }
        public string PartyId { get; set; }
        public string bank_code { get; set; }
        public string branch { get; set; }
        public string ifsccode { get; set; }
        public string acc_number { get; set; }


        public string swift_code { get; set; }
        public string acc_holder_name { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string gl_code { get; set; }
        public string client { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string edit_by { get; set; }
        public string t_status { get; set; }
        public bool active { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string lang_key { get; set; }
        public string country_code { get; set; }
        public string iban_no { get; set; }

        //scalar
        public string CntryName { get; set; }
        public string bank_name { get; set; }
        public string bk_abbriviation { get; set; }
        public string PartyNm { get; set; }






    }
}
