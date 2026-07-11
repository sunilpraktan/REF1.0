using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.PMS
{
    public class PMS_T001 : ObjectBase
    {
        public string comp_code { get; set; }
        public string project_id { get; set; }
        public string location_id { get; set; }
        public int? project_no { get; set; }
        public string project_name { get; set; }
        public string short_text { get; set; }
        public string obj_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string pro_type { get; set; }
        public DateTime? doc_date { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_cat { get; set; }
        public string order_no { get; set; }
        public string pcode_1 { get; set; }
        public string pcode_2 { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }
        public DateTime? date_start { get; set; }
        public DateTime? date_end { get; set; }
        public DateTime? actual_start { get; set; }
        public DateTime? actual_end { get; set; }
        public string party_code { get; set; }
        public string lang_key { get; set; }
        public string cc_code { get; set; }
        public string pc_code { get; set; }
        public string cost_object { get; set; }
        public string curr_code { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public string app_id { get; set; }
        public string app_desc { get; set; }
        public string uom_time { get; set; }
        public string pri_code { get; set; }
        public string project_profile { get; set; }
        public string task_profile { get; set; }
        public string budget_profile { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string org_code { get; set; }
        public string group_code { get; set; }
        public string ind_task { get; set; }
        public string note { get; set; }
        public string std_code { get; set; }
        public string sub_std_code { get; set; }
        public decimal? duration { get; set; }
        public string duration_unit { get; set; }

        //GEN_T002 Fields
        public string long_text { get; set; }

        //Scalar Fields
        public string party_name { get; set; }
        public string t_display { get; set; }
        public string type_name { get; set; }
        public string std_name { get; set; }
        public string sub_std_name { get; set; }
        public decimal? duretion { get; set; } // Total period between start and end dates.
        public decimal? duretion_actual { get; set; } // Total period between actual start and end dates.
        public decimal? time_spent { get; set; } // Total Time Spent on Project, summ of all confirmations.
        public decimal? progress { get; set; } // Progress in percentage of total time vs time spent.
        public bool? ind_copy { get; set; } // Progress in percentage of total time vs time spent.
        //public DateTime? sch_date_max { get; set; }
        //public DateTime? sch_date_min { get; set; }
    }

    public class PMS_T002 : ObjectBase
    {
        public string comp_code { get; set; }
        public string element_id { get; set; }
        public string location_id { get; set; }
        public int? element_no { get; set; }
        public string element_name { get; set; }
        public string short_text { get; set; }
        public int? project_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string pro_type { get; set; }
        public string obj_no { get; set; }
        public DateTime? doc_date { get; set; }
        public int? no_of_emp { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public string app_id { get; set; }
        public string app_desc { get; set; }
        public string cc_code { get; set; }
        public string pc_code { get; set; }
        public string ind_billing { get; set; }
        public string ind_task { get; set; }
        public string pri_code { get; set; }
        public string equipment_no { get; set; }
        public string curr_code { get; set; }
        public string lang_key { get; set; }
        public decimal? quantity { get; set; }
        public string unit_code { get; set; }
        public string billing_plan { get; set; }
        public string place { get; set; }
        public string item_code { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }
        public string element_profile { get; set; }
        public string ref_element_id { get; set; }
        public string note { get; set; }
        public string parent_id { get; set; }
        public string party_code { get; set; }
        public string std_code { get; set; }
        public string sub_std_code { get; set; }
        public int? seq_no { get; set; }
        public DateTime? com_date { get; set; }
        public string com_rule { get; set; }

        //GEN_T002 Fields
        public string long_text { get; set; }

        //Scalar Fields
        public string std_name { get; set; }
        public string sub_std_name { get; set; }
        public string party_name { get; set; }
        public string project_name { get; set; }
        public string t_display { get; set; }
        public string project_id { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public string XDOC_A { get; set; }
        //public DateTime? sch_date_max { get; set; }
        //public DateTime? sch_date_min { get; set; }
    }

    public class PMS_T003 : ObjectBase
    {
        public string comp_code { get; set; }
        public int? project_no { get; set; }
        public int? element_no { get; set; }
        public int? element_up { get; set; }
        public int? element_down { get; set; }
        public int? element_left { get; set; }
        public int? element_right { get; set; }

    }

    public class PMS_T004 : ObjectBase
    {
        public string comp_code { get; set; }
        public string doc_no { get; set; }
        public int? milestone_no { get; set; }
        public string short_text { get; set; }
        public int? plan_counter { get; set; }
        public int? int_counter { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public DateTime? doc_date { get; set; }
        public string usage { get; set; }
        public string task_list_type { get; set; }
        public string node_no { get; set; }
        public string tlgroup_key { get; set; }
        public DateTime? date_from { get; set; }
        public string order_cat { get; set; }
        public string alt_order { get; set; }
        public string routing_no { get; set; }
        public int? int_counter_routing { get; set; }
        public string element_id { get; set; }
        public int? element_no { get; set; }
        public DateTime? date_schedule { get; set; }
        public TimeSpan? time_schedule { get; set; }
        public DateTime? date_schedule_f { get; set; }
        public TimeSpan? time_schedule_f { get; set; }
        public DateTime? date_fixed { get; set; }
        public TimeSpan? time_fixed { get; set; }
        public DateTime? date_fixed_f { get; set; }
        public TimeSpan? time_fixed_f { get; set; }
        public DateTime? date_actual_met { get; set; }
        public TimeSpan? time_actual_met { get; set; }
        public string ind_event { get; set; }
        public string doc_no_confirm { get; set; }
        public int? counter_confirm { get; set; }
        public string t_status { get; set; }
        public string active { get; set; }
        public decimal? per_project { get; set; }
        public decimal? per_element { get; set; }
        public decimal? per_task { get; set; }
        public decimal? per_invoice { get; set; }
        public int? op_row_id { get; set; }
        public string order_doc_cat { get; set; }
        public string order_no { get; set; }
        public int? order_item_row_id { get; set; }
        public string note { get; set; }

        // Scalar Fields
        public string project_id { get; set; }
        public string t_display { get; set; }
        public string element_name { get; set; }
        public string project_name { get; set; }

    }

    public class PMS_T005 : ObjectBase
    {
        public string comp_code { get; set; }
        

    }

    public class PMS_T006 : ObjectBase
    {
        public int? id { get; set; }
        public string comp_code { get; set; }
        public string element_id { get; set; }
        public int? element_no { get; set; }
        public string project_id { get; set; }
        public int? project_no { get; set; }
        public DateTime? date_schedule { get; set; }
        public DateTime? date_forecast { get; set; }
        public DateTime? date_actual { get; set; }
        public DateTime? date_finish { get; set; }
        public DateTime? date_forecast_finish { get; set; }
        public DateTime? date_actual_finish { get; set; }
        public decimal? length_schedule { get; set; }
        public decimal? length_forecast { get; set; }
        public decimal? length_actual { get; set; }
        public string uom_schedule { get; set; }
        public string uom_forecast { get; set; }
        public string uom_actual { get; set; }
        public string t_status { get; set; }
        public string active { get; set; }
        public string note { get; set; }
        public string ind_revised { get; set; }
        public DateTime? date_revised { get; set; }
        public string ind_change { get; set; }
    }

    


}
