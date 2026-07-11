using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.ENG
{
    public class ENG_T001 : ObjectBase
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public System.DateTime? doc_date { get; set; }
        public string location_id { get; set; }
        public string comp_code { get; set; }
        public int? counter_no { get; set; }
        public string bom_cat { get; set; }
        public string item_code { get; set; }
        public string emp_id { get; set; }
        public string party_code { get; set; }
        public string unit_code { get; set; }
        public decimal? bom_qty { get; set; }
        public bool? alternate_bom { get; set; }
        public string revision_no { get; set; }
        public DateTime? revision_date { get; set; }
        public string ref_doc_no { get; set; }
        public string order_doc_type { get; set; }
        public string order_no { get; set; }
        public DateTime? valid_from { get; set; }
        public DateTime? valid_to { get; set; }
        public string bom_name { get; set; }
        public string note { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }

        //Scalar
        public string item_name { get; set; }
        public string remark { get; set; }
        public string party_name { get; set; }
        public string item_cat { get; set; }
        public string cat_code { get; set; }
        public string curr_code { get; set; }
        public string bom_cat_code { get; set; }
        public string XDOC_A { get; set; }
        public string XDOC_C { get; set; }


    }
    public class ENG_T001_A
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public int? counter_no { get; set; }
        public string bom_cat { get; set; }
        public int? bom_item_node_no { get; set; }
        public DateTime? valid_from { get; set; }
        public DateTime? valid_to { get; set; }
        public string change_no { get; set; }
        public string parent_node { get; set; }
        public int? previous_counter { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string issuing_plant { get; set; }
        public string line_cat { get; set; }
        public int? bom_item_no { get; set; }
        public string unit_code { get; set; }
        public decimal? qty { get; set; }
        public string fixed_qty { get; set; }
        public decimal? component_scrap { get; set; }
        public decimal? operation_scrap { get; set; }
        public string ind_net_scrap { get; set; }
        public string ind_item_prd { get; set; }
        public string ind_item_sales { get; set; }
        public string ind_plant { get; set; }
        public string ind_costing { get; set; }
        public string ind_engg { get; set; }
        public string ind_recursive { get; set; }
        public string ind_recursive_allowed { get; set; }
        public string ind_alternative_item { get; set; }
        public string ind_subitem_exit { get; set; }
        public string item_code_alt { get; set; }
        public string revision_no { get; set; }
        public DateTime? revision_date { get; set; }
        public string ref_revision_no { get; set; }
        public string ind_pm_assembly { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string info1 { get; set; }
        public string info2 { get; set; }
        public string info3 { get; set; }
        public decimal? con_qty { get; set; }
        public string con_uom { get; set; }
        public decimal? per_qty { get; set; }
        public string per_uom { get; set; }
        public string ind_usage { get; set; }
        public string ind_base { get; set; }
        public int? line_id { get; set; }
        public double? unit_price { get; set; }
        public double? price_unit { get; set; }
        public string curr_code { get; set; }
        public decimal? total_value { get; set; }
        public double? base_price { get; set; }
        public decimal? total_base { get; set; }
        public decimal? lead_time { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string ind_req_comp { get; set; }
        public string stoce_code { get; set; }
        public string ind_co_product { get; set; }
        public int? line_no { get; set; }
        public string node_no { get; set; }
        public int? node_line { get; set; }
        public string ind_hl_config { get; set; }
        public double? budget_price { get; set; }
        public double? target_price { get; set; }
        public double? sale_price { get; set; }
        public string ind_claim { get; set; }
        public string ind_rev { get; set; }
        public string ind_var { get; set; }
        public string ind_freeze { get; set; }


        // scalar
        public string sub_cat { get; set; }
        public bool? ind_stock { get; set; }
        public bool? ind_sku { get; set; }
        public string item_name_alt { get; set; }
        public string long_text { get; set; }
        public bool? selected { get; set; }
        public bool? read_only { get; set; }


    }
    public partial class ENG_T001_C : ObjectBase // Assign BOM to Materail, Plant etc...
    {
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string doc_no { get; set; }
        public string item_code { get; set; }
        public string bom_use { get; set; }
        public string alternate_bom { get; set; }
        public string ind_variant { get; set; }
        public DateTime? valid_from { get; set; }
        public string active { get; set; }

        //Scalar
        public string item_name { get; set; }
    }


    public partial class ENG_T005 : ObjectBase
    {
        public string doc_no { get; set; }
        public string short_text { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public DateTime? doc_date { get; set; }
        public string task_list { get; set; }
        public string group_counter { get; set; }
        public int? plan_counter { get; set; }
        public DateTime? valid_from { get; set; }
        public string tl_use { get; set; }
        public string tl_type { get; set; }
        public string tl_unit { get; set; }
        public decimal? lot_size_from { get; set; }
        public decimal? lot_size_to { get; set; }
        public string tl_name { get; set; }
        public string lang_key { get; set; }
        public string assign_para_set { get; set; }
        public string para_set_location { get; set; }
        public string dynamic_rule { get; set; }
        public string para_group { get; set; }
        public string para_value { get; set; }
        public string sd_no { get; set; }
        public string sd_version { get; set; }
        public string insp_point { get; set; }
        public string item_code { get; set; }
        public string bom_no { get; set; }
        public string bom_cat { get; set; }
        public string bom_no_alt { get; set; }
        public decimal? base_qty { get; set; }
        public string unit_code { get; set; }
        public decimal? num_operation { get; set; }
        public decimal? deno_operation { get; set; }
        public string comp_code { get; set; }
        public string active { get; set; }
        public string location_id { get; set; }
        public string t_status { get; set; }
        public string plan_app { get; set; }

        //Scallar
        public string item_name { get; set; }
        public string letter_text { get; set; }
        public string body_text { get; set; }
        public string header_text { get; set; }
        public string footer_text { get; set; }
        public string XDOC_A { get; set; }
        public string XDOC_B { get; set; }
        public string XDOC_C { get; set; }
        public string XDOC_R { get; set; }
        public string XDOC_M { get; set; }

        public string class_code { get; set; }
        public string class_name { get; set; }

    }
    public partial class ENG_T005_A : ObjectBase
    {
        public int? id { get; set; }
        public string doc_no { get; set; }
        public string tl_type { get; set; }
        public int? plan_counter { get; set; }
        public DateTime? valid_from { get; set; }
        public string op_no { get; set; }
        public string sub_op_no { get; set; }
        public string control_key { get; set; }
        public string obj_id { get; set; }
        public string obj_type { get; set; }
        public string op_code { get; set; }
        public string short_text { get; set; }
        public string op_name { get; set; }
        public string lang_key { get; set; }
        public decimal? base_qty { get; set; }
        public string unit_code { get; set; }
        public decimal? num_operation { get; set; }
        public decimal? deno_operation { get; set; }
        public string activity_type1 { get; set; }
        public string unit_code1 { get; set; }
        public decimal? std_value1 { get; set; }
        public string activity_type2 { get; set; }
        public string unit_code2 { get; set; }
        public decimal? std_value2 { get; set; }
        public string activity_type3 { get; set; }
        public string unit_code3 { get; set; }
        public decimal? std_value3 { get; set; }
        public string std_value_cal { get; set; }
        public decimal? scrap_factor { get; set; }
        public string cust_id { get; set; }
        public string vendor_id { get; set; }
        public string bom_no { get; set; }
        public string bom_cat { get; set; }
        public int? bom_item_row_id { get; set; }
        public string priority { get; set; }
        public string service_no { get; set; }
        public string pur_doc_no { get; set; }
        public int? pur_doc_item_row_id { get; set; }
        public string inst_code { get; set; }
        public string comp_code { get; set; }
        public string active { get; set; }
        public string location_id { get; set; }
        public string t_status { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public int? line_id { get; set; }
        public string wc_code { get; set; }
        public string insp_type { get; set; }
        public int? op_seq { get; set; }
        public string task_id { get; set; }
        public decimal? op_cost { get; set; }
        public string usage { get; set; }
        public int? node_no { get; set; }
        public string tlgroup_key { get; set; }
    }
    public partial class ENG_T005_B : ObjectBase
    {
        public int? id { get; set; }
        public string doc_no { get; set; }
        public string tl_type { get; set; }
        public string char_type { get; set; }
        public int? line_id { get; set; }
        public string char_code { get; set; }
        public string char_name { get; set; }
        public int? char_no { get; set; }
        public int? plan_counter { get; set; }
        public DateTime? valid_from { get; set; }
        public string insp_method { get; set; }
        public string insp_method_loc { get; set; }
        public string insp_method_version { get; set; }
        public string ref_char { get; set; }
        public string char_location { get; set; }
        public string char_ver { get; set; }
        public DateTime? ver_date { get; set; }
        public string way_char { get; set; }
        public string insp_qual { get; set; }
        public string tol_key { get; set; }
        public string short_text { get; set; }
        public string long_text { get; set; }
        public string lang_key { get; set; }
        public int? dc_place { get; set; }
        public string unit_code { get; set; }
        public double? target_value { get; set; }
        public string value1 { get; set; }
        public double? low_limit { get; set; }
        public double? up_limit { get; set; }
        public double? low_limit1 { get; set; }
        public double? up_limit1 { get; set; }
        public string value2 { get; set; }
        public double? low_tol_limit { get; set; }
        public double? up_tol_limit { get; set; }
        public string sample_uom { get; set; }
        public string samp_pro_char { get; set; }
        public double? cf_sample { get; set; }
        public double? cf_material { get; set; }
        public double? sampl_qty_factor { get; set; }
        public string mod_data { get; set; }
        public string cal_formula { get; set; }
        public string formula1 { get; set; }
        public string formula2 { get; set; }
        public string qm_para_group { get; set; }
        public string qm_para { get; set; }
        public string lower_ver_no { get; set; }
        public string qm_para_group1 { get; set; }
        public string qm_para1 { get; set; }
        public string upper_ver_no { get; set; }
        public string catlog_para_set { get; set; }
        public string cat_type_para_set { get; set; }
        public string assign_para_set { get; set; }
        public string plant_para_set { get; set; }
        public string version1 { get; set; }
        public string mod_rule { get; set; }
        public string equip_no { get; set; }
        public string qm_para_group2 { get; set; }
        public string qm_para2 { get; set; }
        public string control_method { get; set; }
        public string comp_code { get; set; }
        public string active { get; set; }
        public string location_id { get; set; }
        public string t_status { get; set; }
        public string control_data { get; set; }
        public string fract_cal { get; set; }
        public string op_no { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string para_prof_code { get; set; }
        public string gc_or_ss { get; set; }
        public string ind_char { get; set; }
        public int? line_id_op { get; set; }
        public int? op_row_id { get; set; }
        public string spec_info { get; set; }
        public string ref_class { get; set; }
        public string vc_code { get; set; }
        public string fcode { get; set; }
        public string lot_no { get; set; } // Addtional fields for QMS_T004 which is equavalant to this table.

        //Scalar Fields
        public string char_group { get; set; }
        public string group_name { get; set; }
        public string prof_tpye_name { get; set; }
        public string vc_name { get; set; } // name of the unique VC config code to display in dependency char details
        public string class_code { get; set; }
        public string class_name { get; set; }
        public string ind_interval { get; set; }
        public string ind_mv { get; set; }
        public int? char_seq { get; set; }
    }
    public partial class ENG_T005_C : ObjectBase
    {
        public int? id { get; set; }
        public string doc_no { get; set; }
        public string op_no { get; set; }
        public string char_code { get; set; }
        public string prof_type { get; set; }
        public string prof_code { get; set; }
        public string plant_gc { get; set; }
        public bool? ind_gc_or_ss { get; set; }
        public string comp_code { get; set; }
        public string active { get; set; }
        public string location_id { get; set; }
        public string t_status { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public int? line_id_ic { get; set; }
        public int? line_id_op { get; set; }
        public int? op_row_id { get; set; }
        public int? char_row_id { get; set; }
        //scalar
        public string para_name { get; set; }
        

    }
    public partial class ENG_T005_R : ObjectBase // compoanant assignment for operation
    {
        public int? id { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string doc_no { get; set; }
        public string tl_type { get; set; } //task_list_type
        public string group_counter { get; set; }
        public int? plan_counter { get; set; }
        public int? int_counter { get; set; }
        public DateTime? valid_from { get; set; }
        public int? op_row_id { get; set; }
        public int? node_no { get; set; }
        public decimal? qty { get; set; }
        public string unit_code { get; set; }
        public string ind_backflush { get; set; }
        public string ind_external { get; set; }
        public string item_code { get; set; }
        public string store_code { get; set; }
        public string active { get; set; }
        public string bom_no { get; set; }
        public string bom_no_alt { get; set; }
        public string bom_cat { get; set; }
        public int? bom_item_row_id { get; set; }

        //Scalar
        public string item_name { get; set; }
        public int? line_id_A { get; set; }
    }
    public partial class ENG_T005_M : ObjectBase // Assign Task List to Materail, Plant etc...
    {
        public int? id { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string doc_no { get; set; }
        public string item_code { get; set; }
        public string tl_type { get; set; }
        public string group_counter { get; set; }
        public int? plan_counter { get; set; }
        public int? int_counter { get; set; }
        public DateTime? valid_from { get; set; }
        public string customer { get; set; }
        public string supplier { get; set; }
        public string sd_doc_no { get; set; }
        public int? sd_item_row_id { get; set; }
        public string element_id { get; set; }
        public string active { get; set; }
        public string obj_code { get; set; }
        public string ind_sgroup { get; set; }
        public string dept_code { get; set; }

        //Scalar
        public string item_name { get; set; }
        public string obj_name { get; set; }
        public string dept_name { get; set; }
    }

    public class ENG_M0005 : ObjectBase
    {
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string mp_no { get; set; }
        public string obj_no { get; set; }
        public string pos_no { get; set; }
        public string short_text { get; set; }
        public string mp_cat { get; set; }
        public string ind_pose { get; set; }
        public string ind_ref { get; set; }
        public string ref_mp { get; set; }
        public string char_code { get; set; }
        public int? char_no { get; set; }
        public string ind_ma_ref { get; set; }
        public int? expon { get; set; }
        public int? decno { get; set; }
        public double? target_value { get; set; }
        //public string ind_value { get; set; }
        public string ind_value_ref { get; set; }
        public string note { get; set; }
        public double? low_limit { get; set; }
        public string ind_value1 { get; set; }
        public double? up_limit { get; set; }
        public string ind_value2 { get; set; }
        public string unit_code { get; set; }
        public string ind_counter { get; set; }
        public string ind_back { get; set; }
        public string ind_transfer { get; set; }
        public string mp_no_t { get; set; }
        public double? overflow { get; set; }
        public string ind_value3 { get; set; }
        public double? anual_value { get; set; }
        public string ind_value4 { get; set; }
        public string cat_type { get; set; }
        public string cat_group { get; set; }
        public string ind_cat { get; set; }
        public string ind_suf { get; set; }
        public string tr_mode { get; set; }
        public string ind_mode { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }

        //Scalar
        public string obj_name { get; set; }
        public string char_name { get; set; }
        public string long_text { get; set; }
        public string XDOC_A { get; set; }

    }

}
