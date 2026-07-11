using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class TSK_T001_C : ObjectBase
    {
        public int id { get; set; }    
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string act_action { get; set; }
        public string owner { get; set; }
        public string place { get; set; }
        public string address { get; set; }
        public string act_desc { get; set; }
        public string PartyId { get; set; }
        public string priority { get; set; }
        public System.DateTime start_date { get; set; }
        public string from_time { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public string to_time { get; set; }
        public Nullable<System.DateTime> close_date { get; set; }
        public string stage_id { get; set; }
        public string cat_id { get; set; }
        public string section_id { get; set; }
        public string note { get; set; }
        public string lead_id { get; set; }
        public string lead_title { get; set; }
        public string sono { get; set; }
        public string contact_person { get; set; }
        public string person_number { get; set; }
        public string activity_type { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string parent_activity { get; set; }
        public string action_type { get; set; }
        public string EmpName { get; set; }
        public string fin_year { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string posting_period { get; set; }
        public string s_status { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public string EmailId { get; set; }
        public string project_name { get; set; }
        public string project_location { get; set; }
        public string project_type { get; set; }
        public string architect_grade { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string para5 { get; set; }
        public Nullable<System.DateTime> pay_expected_date { get; set; }
        public Nullable<decimal> payment { get; set; }
        public string architect_name { get; set; }
        //New fields added
        public int folder_id { get; set; }
        public string assign_by { get; set; }
        public Nullable<bool> completed { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_type { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string ind_assist { get; set; }
        public string assist_doc_no { get; set; }
        public string sch_no { get; set; }
        public string project_id { get; set; }
        public Nullable<int> phase_id { get; set; }
        public string status_remark { get; set; }
        public Nullable<decimal> plan_hours { get; set; }
        public Nullable<decimal> hours_spent { get; set; }
        public Nullable<decimal> remaining_hours { get; set; }
        public Nullable<decimal> delay_hours { get; set; }
        public Nullable<decimal> total_hours { get; set; }
        public Nullable<System.DateTime> actual_start { get; set; }
        public Nullable<System.DateTime> actual_end { get; set; }
        public Nullable<decimal> progress { get; set; }
        public Nullable<int> sequence { get; set; }
        public Nullable<int> color { get; set; }
        public string kanban_state { get; set; }
        public string repeat_id { get; set; }
        public Nullable<int> procurement_id { get; set; }
        public string r_accept { get; set; }
        public string review_by { get; set; }
        public Nullable<System.DateTime> review_date { get; set; }
        public string dependancy { get; set; }
        public string language { get; set; }
        public string client { get; set; }
        //Added by Priya
        public string comp_plant { get; set; }
        public string ref_doc_no { get; set; }
        public Nullable<int> ref_item_row_id { get; set; }
        public Nullable<System.DateTime> dead_date { get; set; }
        public string activity_goal { get; set; }
        public string activity_cat { get; set; }
        public string ind_privacy { get; set; }
        public string activity_depend { get; set; }
        public string sub_task { get; set; }
        public string party_name { get; set; }
        public Nullable<System.DateTime> act_date { get; set; }
        public string duration { get; set; }
        public string prospectus { get; set; }
        public string EmpNameDisplay { get; set; }
        public string cat_desc { get; set; }
    }
    public class TSK_T001_D
    {
        public int id { get; set; }  //SCOPE_IDENTITY() column
        public string doc_no { get; set; }
        public string EmpId { get; set; }
        public decimal hours_spent { get; set; }
        public string work_summary { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public string start_time { get; set; }
        public DateTime end_date { get; set; }
        public string end_time { get; set; }
        public int? hr_ana_ts_id { get; set; }
        public bool active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public Nullable<bool> invoicable { get; set; }
        public Nullable<bool> invoice_generated { get; set; }
        public Nullable<decimal> invoice_percentage { get; set; }

        //Extra Scalar
        public string done_by_name { get; set; }
    }
    public class TSK_T001_E
    {
        public int id { get; set; }  //SCOPE_IDENTITY() column
        public string doc_no { get; set; }
        public string EmpId { get; set; }
        public string Emp_Type { get; set; }
        public string role_code { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        //scaler
        public string empname { get; set; }
        public string role_name { get; set; }

    }

}
