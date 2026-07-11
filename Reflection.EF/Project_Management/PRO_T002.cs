using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Project_Management
{
     public partial class PRO_T002 : ObjectBase
    { 
        public string task_id { get; set; }
        public DateTime doc_date { get; set; }
        public string project_id { get; set; }
        public string phase_id { get; set; }
        public string EmpId { get; set; }
        public string t_status { get; set; }
        public bool active { get; set; }
        public string reviewer_id { get; set; }
        public string title { get; set; }
        public string priority { get; set; }
        public decimal? plan_hours { get; set; }
        public decimal? hours_spent { get; set; }
        public decimal? remaining_hours { get; set; }
        public decimal? delay_hours { get; set; }
        public decimal? total_hours { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? actual_start { get; set; }
        public DateTime? dead_date { get; set; }
        public DateTime? actual_end { get; set; }
        public decimal? progress { get; set; }
        public int sequence { get; set; }
        public int? color { get; set; }
        public string kanban_state { get; set; }
        public string repeat_id { get; set; }
        public int? procurement_id { get; set; }
        public int? sale_line_id { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string t_description { get; set; }
        public string cat_id { get; set; }
        public string r_accept { get; set; }
        public string review_by { get; set; }
        public DateTime? review_date { get; set; }
        public string dependancy { get; set; }
        public bool? t_complete { get; set; }
        public string task_type { get; set; }
        public string location_Id { get; set; }
        public string PartyId { get; set; }
        public string language { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string comp_code { get; set; }
        public string status_remark { get; set; }
        public string task_code { get; set; }

        //Extra Scalers

        public string project_name { get; set; }
        public string phase_name { get; set; }
        public string assignto_name { get; set; }
        public string reviewer_name { get; set; }
        public string dependancy_name { get; set; }
        public string repeat_name { get; set; }
        public int SrNo { get; set; }
    }

    public class PRO_T002_A
    {
        public int id { get; set; }  //SCOPE_IDENTITY() column
        public string task_id { get; set; }
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
        public string comp_code { get; set; }
        public string client { get; set; }

        //Extra Scalar
        public string done_by_name { get; set; }
    }

    public class PRO_T002_A_3_A         // Timesheet Entity
    {
        public int id { get; set; }  //SCOPE_IDENTITY() column
        public string task_id { get; set; }
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
        public string title { get; set; }
        public string project_id { get; set; }
        public string project_name { get; set; }
        public Nullable<bool> check { get; set; }
    }

    public class PRO_T002_View
     {
        public string task_id { get; set; }
        public string title { get; set; }
        public DateTime? doc_date { get; set; }
        public string project_id { get; set; }
        public string project_name { get; set; }
        public string phase_id { get; set; }
        public string EmpId { get; set; }
        public string phase_name { get; set; }
        public string reviewer_id { get; set; }
        public string assignto_name { get; set; }
        public string reviewer_name { get; set; }
        public string t_status { get; set; }
        public decimal plan_hours { get; set; }
        public decimal? hours_spent { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? actual_start { get; set; }
        public DateTime? dead_date { get; set; }
        public DateTime? actual_end { get; set; }
        public decimal? progress { get; set; }
        public string repeat_id { get; set; }
        public string repeat_name { get; set; }
        public string dependancy { get; set; }
        public string dependancy_name { get; set; }

    }

}
