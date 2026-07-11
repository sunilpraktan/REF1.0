using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Project_Management
{
    public partial class PRO_T003 : ObjectBase
    {
        public string issue_id { get; set; }
        public string issue_name { get; set; }
        public System.DateTime doc_date { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public System.DateTime facing_from_date { get; set; }
        public System.DateTime reporting_date { get; set; }
        public string reporter_id { get; set; }
        public string reporter_name { get; set; }
        public string project_id { get; set; }
        public string phase_id { get; set; }
        public string task_id { get; set; }
        public string assign_to { get; set; }
        public Nullable<int> ver_id { get; set; }
        public string description { get; set; }
        public string t_status { get; set; }
        public string priority { get; set; }
        public Nullable<decimal> hours_to_close { get; set; }
        public Nullable<decimal> hours_to_open { get; set; }
        public Nullable<System.DateTime> last_action_date { get; set; }
        public Nullable<System.DateTime> next_action_date { get; set; }
        public Nullable<System.DateTime> closing_date { get; set; }
        public Nullable<System.DateTime> reopen_date { get; set; }
        public Nullable<decimal> progress { get; set; }
        public Nullable<int> color { get; set; }
        public bool active { get; set; }
        public Nullable<decimal> duration { get; set; }
        public Nullable<decimal> day_open { get; set; }
        public string PartyId { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string kanban_state { get; set; }
        public Nullable<int> section_id { get; set; }
        public string email_cc { get; set; }
        public Nullable<int> channel_id { get; set; }
        public string email_from { get; set; }
        public Nullable<int> analytic_accid { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string cat_id { get; set; }
        public string language { get; set; }
        public string status_remark { get; set; }      
      
        //Scalar variables

        public string project_name { get; set; }
        public string phase_name { get; set; }
        public string assignto_name { get; set; }
        public string title { get; set; }
        public string cat_title { get; set; }

    }

    public class PRO_T003_A
    {
        public int id { get; set; }
        public string issue_id { get; set; }
        public string done_by { get; set; }
        public decimal hours_spent { get; set; }
        public string action_summary { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public string start_time { get; set; }
        public System.DateTime end_date { get; set; }
        public string end_time { get; set; }
        public bool active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }

        public Nullable<bool> invoicable { get; set; }
        public Nullable<bool> invoice_generated { get; set; }
        public Nullable<decimal> invoice_percentage { get; set; }

        //Scalar variables
        public string done_by_name { get; set; }
        public string role_name { get; set; }
    }
    public class PRO_T003_View
    {
        public string issue_id { get; set; }
        public string issue_name { get; set; }
        public System.DateTime reporting_date { get; set; }
        public string reporter_name { get; set; }
        public string t_status { get; set; }
        public string assignto_name { get; set; }
        public string task_name { get; set; }     
        public string phase_name { get; set; }
        public string project_name { get; set; }
        public string project_id { get; set; }

    }
}
