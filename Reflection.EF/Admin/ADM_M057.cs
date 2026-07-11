using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M057 : ObjectBase
    {
        public string acc_id { get; set; }
        public int id { get; set; }
        public string trans_code { get; set; }
        public string parent_id { get; set; }
        public string type_code { get; set; }
        public string sub_type { get; set; }
        public string ind_primary { get; set; }
        public string contact_no { get; set; }
        public string ext_no { get; set; }
        public string acc_name { get; set; }
        public string desc { get; set; }
        public string ass_contact_no { get; set; }
        public string ind_phone { get; set; }
        public string ind_pref_contact { get; set; }
        public string ind_def { get; set; }
        public Nullable<System.DateTime> valid_fdate { get; set; }
        public string seq_no { get; set; }
        public string cntry_tel_fax { get; set; }
        public string ind_sms_enable { get; set; }
        public string complete_phno { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string lang_key { get; set; }
        //Scaler
        public string type_name { get; set; }
        public string CntryName { get; set; }
        public string country_code { get; set; }

    }
}
