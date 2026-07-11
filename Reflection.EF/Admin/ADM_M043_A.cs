using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M043_A
    {
        public int id { get; set; }
        public string workflow_id { get; set; }
        public int level_no { get; set; }
        public string approver_id { get; set; }
        public string UserId { get; set; }
        public string authority { get; set; }
        public string access_field { get; set; }
        public decimal field_value { get; set; }
        public string unit_code { get; set; }
        public string roperator { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string unit_name { get; set; }
        public string approvernm { get; set; }
        public string authorise_location { get; set; }
        public string authorise_comp { get; set; }
        public string authorise_locNm { get; set; }
        public string authorise_compNm { get; set; }
        public string dept_code { get; set; }
        public string org_code { get; set; }
    }

    public partial class ADM_M043_D
    {
        public int id { get; set; }
        public string doc_type { get; set; }
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string workflow_id { get; set; }
        public string approver_id { get; set; }
        public string UserId { get; set; }
        public string authority { get; set; }
        public string appro_status { get; set; }
        public Nullable<System.DateTime> appro_date { get; set; }
        public string read_status { get; set; }
        public Nullable<System.DateTime> read_date { get; set; }
        public string remarks { get; set; }
        public string ref_id { get; set; }
        public string forward  { get; set; }
        public int level_no { get; set; }
        public string creator { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string TranCode { get; set; }
        public string note_subject { get; set; }
        public string note_messagebody { get; set; }
        public string approvar_remark { get; set; }
        public string sender { get; set; }
        public string record_src { get; set; }
        public string doc_info { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string approvar_name { get; set; }
        public string dept_code { get; set; }
        public string t_display { get; set; }
        public string location_id { get; set; }
        public string org_code { get; set; }

    }
}
