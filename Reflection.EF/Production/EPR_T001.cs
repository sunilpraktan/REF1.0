using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production
{
    public partial class EPR_T001 : ObjectBase
    {
        public int id { get; set; }
        public string order_no { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public int? machine_id { get; set; }
        public string machinecode { get; set; }
        public string sono { get; set; }
        public string po_no { get; set; }
        public string PartyId { get; set; }
        public string shift { get; set; }
        public Nullable<int> conv { get; set; }
        public Nullable<int> model_id { get; set; }
        public string model_code { get; set; }
        public string ItemCode { get; set; }
        public string ball_dia { get; set; }
        public string ball_make { get; set; }
        public string wire_make { get; set; }
        public string ink { get; set; }
        public int? pack_style { get; set; }
        public string ild { get; set; }
        
        public string ball_type { get; set; }
        
        public string shape { get; set; }
        public string sf { get; set; }
        public string order_type { get; set; }
        public string shank_len { get; set; }
        public string needle_dia { get; set; }
        public string needle { get; set; }
        public System.DateTime start_dt { get; set; }
        public Nullable<System.DateTime> end_dt { get; set; }
        public Nullable<bool> appr { get; set; }
        
        public Nullable<System.DateTime> pro_dt { get; set; }
        public string prod_plan { get; set; }
        public string status { get; set; }
        
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        
        public Nullable<decimal> wire_size { get; set; }
        public string ref_doc_type { get; set; }
        public string ref_doc_no { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        
        public string pre_order_no { get; set; }
        public decimal? order_qty { get; set; }
        public string wc_code { get; set; }
        public int? plan_item_row_id { get; set; }
        public string ref_order_no { get; set; }
        public string cost_center { get; set; }
        public string profit_center { get; set; }
        public string emp_id { get; set; }
        public DateTime? sch_start_date { get; set; }
        public DateTime? sch_end_date { get; set; }
        public decimal? scrap_qty { get; set; }
        public string task_list_type { get; set; }
        public string task_list_group { get; set; }
        public int? group_counter { get; set; }
        public int? plan_counter { get; set; }
        public string ind_backflush { get; set; }
        public string req_plan_no { get; set; }
        public string routing_no { get; set; }
        public string bom_exp_no { get; set; }
        public string bom_no { get; set; }
        public string planned_order_no { get; set; }
        public int? planned_order_row_id { get; set; }
        public DateTime? doc_date { get; set; }
        public string planning_plant { get; set; }
        public string store_code { get; set; }
        public string t_status { get; set; }
        public string sku { get; set; }
        public string ind_batch { get; set; }
        public string ind_gr { get; set; }
        public string obj_no { get; set; }
        public int? element_no { get; set; }
        public string project_id { get; set; }
        public string element_id { get; set; }
        public string not_no { get; set; }
        public string equip_no { get; set; }
        public string item_code_asm { get; set; }
        public decimal? down_time { get; set; }
        public string unit_code_bd { get; set; }
        public string pm_plan_no { get; set; }
        public string pm_plan_item { get; set; }
        public int? pm_plan_call { get; set; }
        public string serial_no { get; set; }
        public string master_equip_no { get; set; }
        public string unique_code { get; set; }
        public int? task_no { get; set; }
        public int? seq_no { get; set; }
        public string char_code { get; set; } 
        public string char_spec { get; set; } 
        public string char_point { get; set; } 
        public string frequency { get; set; } 
        public string method { get; set; } 
        public double? accuracy { get; set; } 
        public string accuracy_uom { get; set; } 
        public string lang_key { get; set; } 
        public string ind_cap { get; set; } 
        public string ind_rm { get; set; }
        public string ind_sch { get; set; }
        public string ind_pay { get; set; }
        public string ind_ud { get; set; }
        public string ud_rule { get; set; }
        public string com_method { get; set; }
        public string request { get; set; }
        public string remark { get; set; }
        public string note { get; set; }
        public string note_diff { get; set; }
        public string con_note { get; set; }
        public string title { get; set; }

        //========================================Replaced

        //public string tds_no { get; set; } = char_code spec
        //public string col { get; set; } = char_point
        //public string basket { get; set; } = frequency
        //public string spoons { get; set; } = method
        //public string Note { get; set; } = note
        //public Nullable<System.DateTime> apr_dt { get; set; }
        //public string Conv_lot { get; set; } = com_method
        //public string test_para { get; set; } = char_code
        //public string fin_year { get; set; } = accuracy
        //public string posting_period { get; set; } = accuracy uom
        //public string language { get; set; } = lang_key
        //public int? ink_id { get; set; } = ind_cap
        //public int? wire_make_id { get; set; } = ind_rm
        //public int? ild_id { get; set; } = ind_schedule
        //public int? ball_make_id { get; set; } = ind_pay
        //public int? ball_type_id { get; set; } = ind_ud
        //public string apr_by { get; set; } = ud_rule
        //public int? wire_size_id { get; set; } = remark







        //========================================ReplaceEnd


        // Scalar Fields
        public string PlantName { get; set; }
        public string PartyName { get; set; }
        public string Type { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public string PackingUnit { get; set; }
        public string t_display { get; set; }
        public Nullable<decimal> prod_qty { get; set; }
        public Nullable<decimal> bal_qty { get; set; }
        public string XDOC_A { get; set; }
        public string XDOC_B { get; set; }
        public string XDOC_C { get; set; }
        public string XDOC_VC { get; set; } // Classification
        public string XmlDataDocument_EPR_T001 { get; set; }
        public string XmlDataDocument_EPR_T001_A { get; set; }
        public string XmlDataDocument_EPR_T001_Flip { get; set; }
        //public string color_code { get; set; }
        public decimal? final_qty { get; set; }
        public string prev_batch { get; set; }
        public string order_item_row_id { get; set; }
        public string short_text { get; set; }
        public string long_text { get; set; }
        public string emp_name { get; set; }
        public string element_name { get; set; }
        public string project_name { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string doc_title { get; set; } // Document Type Title
        public byte[] qr_image { get; set; }

        public string method_name { get; set; }
        public string com_name { get; set; } // Communicaion Type Name
        public string doc_type_name { get; set; } // Documemnt Type Name
        //public DateTime? sch_date_max { get; set; }
        //public DateTime? sch_date_min { get; set; }

        //// other doc info but first try to use seperate object for Salesd doc, Equipment, Back, Document etc...
        //public string add_billing { get; set; }
        //public string add_delivery { get; set; }
        //public string equip_name { get; set; }
        //public string make_info { get; set; }
        //public string model_info { get; set; }
        //public string grn_no { get; set; }// Sales Order no
        //public DateTime? grn_date { get; set; }
        //public string delivery_no { get; set; }// Delivery Note no
        //public DateTime? delivery_date { get; set; }
        //public int? inward_no { get; set; }
        //public string inv_no { get; set; }// Sales Invoice no
        //public DateTime? inv_date { get; set; }
        //public string so_no { get; set; }// Sales Order no
        //public DateTime? so_date { get; set; }
        //public string cpo_no { get; set; }// Customer Order no
        //public DateTime? cpo_date { get; set; }// 
        //public string inq_no { get; set; } // inquiry Doc no
        //public DateTime? inq_date { get; set; }
        //public string quot_no { get; set; } // Quotation No
        //public DateTime? quot_date { get; set; }
        public string cp_name { get; set; } // contact person of SD document
        //public string cn_contact { get; set; } // contact person contact details/ Phone Number
        //public string cp_dept { get; set; } // contact person department
        //public string cp_email { get; set; } // contact person email id
        //public string maint_doc_no { get; set; } // Last Repaire & Maintainence document or Calibration Certificate no
        //public DateTime? maint_date { get; set; } // Last Repaire & Maintainence or Calibration date
        //public string maint_status { get; set; } // Condition of Instrument
        //public string sold_to_party { get; set; } 
        //public string ship_to_party { get; set; }

        //public string feasibility { get; set; } //
        //public string feasibilty_info { get; set; } // Usage Decision of GRN inspection
        //public string assembly_info { get; set; } // Accessories / Manual supplied or not in case of calibration of customer equipment 

        public string add_del { get; set; }
        public string fl_name { get; set; } // Functional Location like Permanant Lab or Mobile Lab
        public string ref_no { get; set; }
        public DateTime? ref_date { get; set; }
        public DateTime? del_date { get; set; }
        public string equip_name { get; set; }
    }
    public partial class EPR_T001_A : ObjectBase
    {
        public int id { get; set; }
        public string order_no { get; set; }
        public string task_list_type { get; set; }
        public int? plan_counter { get; set; }
        public string operation_no { get; set; }
        public string sub_op_no { get; set; }
        public string control_key { get; set; }
        public string obj_id { get; set; }
        public string obj_type { get; set; }
        public string op_code { get; set; }
        public string short_text { get; set; }
        public string operation_desc { get; set; }
        public string lang_key { get; set; }
        public string group_counter { get; set; }
        public string location_id { get; set; }
        public string comp_code { get; set; }
        public string plan_no { get; set; }
        public int? operation_row_id { get; set; }
        public int? op_seq { get; set; }
        public int? line_id { get; set; }
        public int? ref_line_id { get; set; }
        public string tl_key { get; set; }
        public decimal? op_increment { get; set; }
        public decimal? no_of_emp { get; set; }
        public string line_id_super { get; set; }
        public string party_code { get; set; }
        public string pur_doc_no { get; set; }
        public int? pur_doc_item_row_id { get; set; }
        public string bom_no { get; set; }
        public string bom_cat { get; set; }
        public int? bom_item_row_id { get; set; }
        public string priority { get; set; }
        public string service_no { get; set; }
        public string inst_code { get; set; }
        public DateTime? add_date { get; set; }
        public string t_status { get; set; }
        public string wc_code { get; set; }
        public string inst_type { get; set; }
        public string task_id { get; set; }
        public decimal? scrap_factor { get; set; }
        public bool? active { get; set; }
        public string doc_no_oc { get; set; }
        public int? order_counter { get; set; }
        public decimal? cost_of_operation { get; set; }
        public decimal? op_cost { get; set; }
        public string obj_no { get; set; }
        public string cost_element { get; set; }
        public string usage { get; set; }
        public int? node_no { get; set; }
        public string tl_group_key { get; set; }
        public string emp_id { get; set; }
        public int? element_no { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string requester { get; set; }
        public string recipient { get; set; }
        public decimal? unit_price { get; set; }
        public string unit_code { get; set; }
        public string curr_code { get; set; }
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string long_text { get; set; }

        //Scalar Fields
        public string t_display { get; set; }
        public string emp_name { get; set; }
        public string XDOC_B;
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public string order_title { get; set; }
        public DateTime? start_date_order { get; set; }
        public DateTime? end_date_order { get; set; }
        public string emp_name_order { get; set; }
        //public DateTime? sch_date_max { get; set; }
        //public DateTime? sch_date_min { get; set; }
    }
    public class EPR_T001_B : ObjectBase
    {
        public int? plan_counter { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string plan_no { get; set; }
        public int? operation_row_id { get; set; }
        public string unit_code { get; set; }
        public decimal? qty { get; set; }
        public string unit_code_sv { get; set; }
        public decimal? std_value { get; set; }
        public string unit_code_work { get; set; }
        public decimal? opr_qty { get; set; }
        public decimal? opr_scrap { get; set; }
        public DateTime? sch_start { get; set; }
        public DateTime? sch_end { get; set; }
        public DateTime? forecast_start { get; set; }
        public DateTime? forecast_end { get; set; }
        public DateTime? actual_start { get; set; }
        public DateTime? actual_end { get; set; }
        public decimal? length_schedule { get; set; }
        public decimal? length_forecast { get; set; }
        public decimal? length_actual { get; set; }
        public string uom_schedule { get; set; }
        public string uom_forecast { get; set; }
        public string uom_actual { get; set; }
        public string t_status { get; set; }
        public string active { get; set; }
        public decimal? qty_work { get; set; }
        public string uom_work { get; set; }
        public int? line_id_opr { get; set; } // Operation line_id

        // Scalar

        //public DateTime? sch_date_max { get; set; }
        //public DateTime? sch_date_min{ get; set; }

    }
    public class EPR_T001_C : ObjectBase // Dependency
    {
        public string comp_code { get; set; }
        public string op_doc { get; set; }
        public string op_doc_dep { get; set; }
        //public int? op_row_id { get; set; }
        //public int? op_row_id_dep { get; set; }
        public string active { get; set; }

        // Scalar
        public string project_name { get; set; }
        public string element_name { get; set; }
        public string order_no { get; set; }
        public string order_title { get; set; }
        public string op_no { get; set; }
        public string op_name { get; set; }
        public string short_text { get; set; }
        public string operation_desc { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }


    }
}
