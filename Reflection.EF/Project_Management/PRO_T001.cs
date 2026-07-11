using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Project_Management
{
    public partial class PRO_T001 : ObjectBase
    {
        public string project_id { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public System.DateTime doc_date { get; set; }
        public bool use_tasks { get; set; }
        public bool use_timesheet { get; set; }
        public bool use_issue { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_type { get; set; }
        public string ref_doc_cat { get; set; }
        public string work_order { get; set; }
        public string pcode_1 { get; set; }
        public string pcode_2 { get; set; }
        public string project_name { get; set; }
        public string project_manager { get; set; }
        public Nullable<int> alias_id { get; set; }
        public string alias_model { get; set; }
        public string privacy_visibility { get; set; }
        public bool active { get; set; }
        public string priority { get; set; }
        public string t_status { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> actual_start { get; set; }
        public Nullable<System.DateTime> dead_date { get; set; }
        public Nullable<System.DateTime> actual_end { get; set; }
        public Nullable<decimal> planned_hours { get; set; }
        public Nullable<decimal> hours_spent { get; set; }
        public Nullable<decimal> rem_hours { get; set; }
        public Nullable<decimal> total_hours { get; set; }
        public Nullable<decimal> work_hours_day { get; set; }
        public Nullable<decimal> progress_rate { get; set; }
        public Nullable<int> analytic_accid { get; set; }
        public string customer_id { get; set; }
        public string location_Id { get; set; }
        public string po_no { get; set; }
        public Nullable<decimal> b_amt { get; set; }
        public Nullable<int> color { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string comp_code { get; set; }
        public string language { get; set; }
        public bool? use_appchecklist { get; set; }
        public string status_remark { get; set; }
        public bool? addactionlog_ts { get; set; }
        public string curr_code { get; set; }
        public string local_curr { get; set; }
        public decimal? local_exc_rate { get; set; }
        public string cat_id { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string projectmanagernm { get; set; }
        public string LoctnNm { get; set; }
        public string customernm { get; set; }
        public int taskcount { get; set; }
        public int issuescount { get; set; }
        public string cat_title { get; set; }
        public string title { get; set; }
        public string Hoursspent { get; set; }
        public string RemHours { get; set; }
        public string progress { get; set; }
        public string sub_cat { get; set; }
        public string make { get; set; }
        public string model { get; set; }

    }
    public class PRO_T001_A
    {
        public int id { get; set; }
        public string project_id { get; set; }
        public string phase_id { get; set; }

        public string t_status { get; set; }
        public System.DateTime start_date { get; set; }
        public Nullable<System.DateTime> actual_start { get; set; }
        public System.DateTime dead_date { get; set; }
        public Nullable<System.DateTime> actual_end { get; set; }
        public int sequence { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string phasenm { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
    }
    public class PRO_T001_B
    {
        public int id { get; set; }
        public string project_id { get; set; }
        public string EmpId { get; set; }
        public string Emp_Type { get; set; }
        public string RoleCode { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string empname { get; set; }
        public string role_name { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
    }
    public class PRO_T001_C
    {
        public int id { get; set; }
        public string project_id { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public decimal quantity { get; set; }
        public string unit_code { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string store_code { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string itemname { get; set; }
        public string client { get; set; }
    }
    public class PRO_T001_D
    {
        public int id { get; set; }
        public string project_id { get; set; }
        public string point_id { get; set; }
        public bool check { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string point_description { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
    }
    public class PRO_T001_FLIP
    {
        public string project_id { get; set; }
        public string project_name { get; set; }
        public string project_manager { get; set; }
        public string t_status { get; set; }
        public string ref_doc_no { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> actual_start { get; set; }
        public Nullable<System.DateTime> dead_date { get; set; }
        public Nullable<System.DateTime> actual_end { get; set; }
        public Nullable<decimal> planned_hours { get; set; }
        public Nullable<decimal> hours_spent { get; set; }
        public Nullable<decimal> rem_hours { get; set; }
        public Nullable<decimal> total_hours { get; set; }
        public Nullable<decimal> progress_rate { get; set; }
        public Nullable<decimal> b_amt { get; set; }
        public string customernm { get; set; }
        public string projectmanagernm { get; set; }
        public string plantname { get; set; }
        public int taskcount { get; set; }
        public string pcode_1 { get; set; }
        public string pcode_2 { get; set; }

    }
}
