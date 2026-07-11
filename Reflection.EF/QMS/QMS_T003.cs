using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
    public partial class QMS_T003 : ObjectBase
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string insp_type { get; set; }
        public string doc_source { get; set; }
        public string obj_no { get; set; }
        public string obj_cat { get; set; }
        public string sample_proc { get; set; }
        public DateTime? lot_create_date { get; set; }
        public string lot_create_time { get; set; }
        public DateTime? insp_start_date { get; set; }
        public string insp_start_time { get; set; }
        public DateTime? insp_end_date { get; set; }
        public string insp_end_time { get; set; }
        public string insp_point_type { get; set; }
        public string task_list_type { get; set; }
        public string tl_code { get; set; }
        public string task_list_usage { get; set; }
        public string sample_draw_proc { get; set; }
        public string item_code { get; set; }
        public string rev_level { get; set; }
        public string supplier_code { get; set; }
        public string mfg_no { get; set; }
        public string customer_code { get; set; }
        public string order_no { get; set; }
        public int? routing_no { get; set; }
        public string ship_to_party { get; set; }
        public string sold_to_party { get; set; }
        public string vendor_code { get; set; }
        public string party_item_code { get; set; }
        public string ref_doc_type { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_no { get; set; }
        public int? ref_doc_row_id { get; set; }
        public string sono { get; set; }
        public int? so_item_row_id { get; set; }
        public string po_no { get; set; }
        public int? po_item_row_id { get; set; }
        public int? del_sch_row_id { get; set; }
        public string so_code { get; set; }
        public string po_code { get; set; }
        public string delivery { get; set; }
        public int? delivery_items { get; set; }
        public string delivery_type { get; set; }
        public string delivery_cat { get; set; }
        public int? route { get; set; }
        public string country_code { get; set; }
        public string wa_code { get; set; }
        public string storage_type { get; set; }
        public string store_bin_code { get; set; }
        public string insp_stock_location_Id { get; set; }
        public string insp_stock_store_code { get; set; }
        public string mov_tp { get; set; }
        public DateTime? posting_date { get; set; }
        public string store_code { get; set; }
        public string item_code_2 { get; set; }
        public string rev_level_2 { get; set; }
        public string batch_no { get; set; }
        public DateTime? validity_date { get; set; }
        public DateTime? exp_date { get; set; }
        public string vendor_batch { get; set; }
        public double? insp_lot_qty { get; set; }
        public string unit_code_base { get; set; }
        public double? sample_size { get; set; }
        public string unit_code_sample { get; set; }
        public string insp_stage { get; set; }
        public string insp_severity { get; set; }
        public double? qty_unrestrict_stock { get; set; }
        public double? qty_scrap { get; set; }
        public double? qty_sample { get; set; }
        public double? qty_block_stock { get; set; }
        public double? qty_reserves { get; set; }
        public double? qty_material { get; set; }
        public string post_item_code { get; set; }
        public string batch_transferred { get; set; }
        public double? qty_vendor { get; set; }
        public double? qty_other_stock { get; set; }
        public double? qty_other_stock_2 { get; set; }
        public double? qty_posted { get; set; }
        public double? qty_inspected { get; set; }
        public double? qty_destroyed { get; set; }
        public double? qty_actual { get; set; }
        public double? qty_defective { get; set; }
        public string ind_logs_decision { get; set; }
        public double? qty_insp_scrap { get; set; }
        public string qual_cal_proc { get; set; }
        public double? qty_allowed_scrap { get; set; }
        public string consumption_posting { get; set; }
        public string account_cat { get; set; }
        public string po_item_cat { get; set; }
        public string account_key { get; set; }
        public string cost_center { get; set; }
        public string asset_number { get; set; }
        public string asset_subnumber { get; set; }
        public string profit_center { get; set; }
        public string business_area { get; set; }
        public string gl_code { get; set; }
        public string ref_insp_lot_no { get; set; }
        public string insp_stab_study { get; set; }
        public string maint_plan { get; set; }
        public string maint_item { get; set; }
        public int? maint_call_no { get; set; }
        public string maint_strategy { get; set; }
        public string trial_no { get; set; }
        public string emp_id { get; set; }
        public string barcode { get; set; }
        public string ind_block_stock { get; set; }
        public string ind_qty_status { get; set; }
        public string ind_insp_lot_creattion { get; set; }
        public string ind_partial_lot { get; set; }
        public string ind_insp_point { get; set; }
        public string ind_usage_decision { get; set; }
        public string ind_insp_source { get; set; }
        public string ind_ref_doc_no { get; set; }
        public string ind_insp_plan { get; set; }
        public string ind_sample { get; set; }
        public string ind_insp_approval { get; set; }
        public string ind_char { get; set; }
        public string ind_sample_cal { get; set; }
        public string ind_stock_posting { get; set; }
        public string ind_status_uasge_decision { get; set; }
        public string ind_lot_skipped { get; set; }
        public string ind_allow_skipped { get; set; }
        public string ind_complete_insp { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }
        public DateTime? doc_date { get; set; }
        public string location_id { get; set; }
        public string comp_code { get; set; }
        public string lang_key { get; set; }
        public string cp_name { get; set; }
        public string cp_code { get; set; }
        public string insp_cat { get; set; }
        public string XmlDataDocument_QMS_T003_Flip { get; set; }
        //Scalar
        public string OriginName { get; set; }
        public string item_name { get; set; }
        public string insp_typeNm { get; set; }
        public string PurOrgNm { get; set; }
        public string notes { get; set; }
        public string source { get; set; }
        public string party_name { get; set; }
        public string customer_name { get; set; }
        public string supplier_name { get; set; }
        public string MfgNm { get; set; }
        public string buyer { get; set; }
        public string grn_by { get; set; }
        public string t_display { get; set; }
        public bool? selected { get; set; }
        public string ts_namespace { get; set; }
        public string ts_class_file { get; set; }
        public string doc_desc { get; set; }
        public string wc_code { get; set; }
        public string wc_name { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }

        // Scallar
        public float age { get; set; }
        public string gender { get; set; }
        public string party_code { get; set; } // Collection Center
        public string ref_party { get; set; } // Reference Party
        public string cons_party { get; set; } // Cosultant Party
        public string coll_branch { get; set; } // Collection Center
        public DateTime? so_date { get; set; } // 
        public DateTime? rel_date { get; set; } // Released/Approve date for the Test not for all Test

        public string emp_name { get; set; }
        public string tl_name { get; set; }
        public string short_text { get; set; }
        public string plan_no { get; set; }
        public string XDOC_A { get; set; }
        public string XDOC_B { get; set; }
        public string XDOC_C { get; set; }
        public string XDOC_D { get; set; }
        public string XDOC_E { get; set; }
        public string XDOC_N { get; set; }
        public string XDOC_U { get; set; }
        public string ip_text { get; set; } // Interpritation Long Text
    }
    public class QMS_T003_A : ObjectBase // Summarized RR
    {
        public int? id { get; set; } //(int, not null)
        public string doc_no { get; set; } //(varchar(20), not null)
        public int? line_no { get; set; } //(int, not null)
        public int? mic_line_id { get; set; } //(int, not null)
        public string char_code { get; set; } //(varchar(5), null)
        public int? sample_no { get; set; } //(int, null)
        public int? valid_sample_no { get; set; } //(int, null)
        public string r_status { get; set; } //(varchar(1), null)
        public string attribute { get; set; } //(varchar(5), null)
        public string ind_source { get; set; } //(varchar(1), null)
        public string ind_equipment { get; set; } //(varchar(1), null)
        public string v_code { get; set; } //(varchar(1), not null)
        public string v_code_dm { get; set; } //(varchar(1), null)
        public string inspector { get; set; } //(varchar(10), null)
        public DateTime? start_date { get; set; } //(datetime2(7), null)
        public DateTime? end_date { get; set; } //(datetime2(7), null)
        public string short_desc { get; set; } //(varchar(50), null)
        public int? sample_recorded { get; set; } //(int, null)
        public int? sample_nonc { get; set; } //(int, null)
        public int? defect_no { get; set; } //(int, null)
        public int? above_values { get; set; } //(int, null)
        public int? below_values { get; set; } //(int, null)
        public int? sample_inspected { get; set; } //(int, null)
        public double? max_value { get; set; } //(double(18,6), null)
        public double? min_value { get; set; } //(double(18,6), null)
        public double? median_value { get; set; } //(double(18,6), null)
        public double? mean_value { get; set; } //(double(18,6), null)
        public int? sample_valid { get; set; } //(int, null)
        public string para_type { get; set; } //(nchar(10), null)
        public string para_code { get; set; } //(varchar(10), null)
        //public string value_code { get; set; } //(varchar(10), null)
        public string char_value { get; set; } //(varchar(10), null)
        public string version { get; set; } //(varchar(5), null)
        public string defect_class { get; set; } //(varchar(10), null)
        public string equipment { get; set; } //(varchar(40), null)
        public DateTime add_date { get; set; } //(datetime2(7), null)
        public string active { get; set; } //(bit, not null)
        public string t_status { get; set; } //(varchar(3), not null)
        public string lang_key { get; set; } //(varchar(5), null)
        public string comp_code { get; set; } //(varchar(3), not null)
        public string location_id { get; set; } //(int, not null)
        public string fun_loc { get; set; } //(varchar(10), null)
        public string ind_complete { get; set; } //(varchar(1), null)
        public string insp_level { get; set; }
        public string op_no { get; set; }
        public int? op_seq { get; set; }
        public int? line_id_op { get; set; }
        public string wc_code { get; set; }
        public string insp_type { get; set; }
        public string insp_point { get; set; }
        public string doc_no_oc { get; set; }
        public string ref_doc_no { get; set; }

        // Scallar
        public string specifications { get; set; }
        public string char_spec { get; set; }
        public string op_name { get; set; }
        public double? sample_size { get; set; }
        public string char_name { get; set; }
        public string char_result { get; set; }
        public string char_type { get; set; }
        public string v_code_text { get; set; }
        public double? low_limit { get; set; }
        public double? up_limit { get; set; }
        public double? target_value { get; set; }
        public string unit_code { get; set; }
        public int? line_id_a { get; set; }

        public string ind_char { get; set; }
        public string sample_uom { get; set; }
        public int? no_of_char { get; set; }
        public int? no_of_dec { get; set; }
        public string ind_case { get; set; }
        public string ind_mv { get; set; }
        public string ind_interval { get; set; }
        public string long_text { get; set; }
        public string fcode { get; set; }
        public string formula1 { get; set; }
        public string formula2 { get; set; }
        public string group_name { get; set; }
        public string tl_name { get; set; }
        public string usage_text { get; set; }
        public string method_name { get; set; }
        public int? char_seq { get; set; }
        public bool logo_vis { get; set; }
        public string ip_text { get; set; } // Interpritation Long Text
    }

    public class QMS_T003_B : ObjectBase // Characterwise RR
    {
        public int? id { get; set; } //(int, not null)
        public string doc_no { get; set; } //(varchar(20), not null)
        public int? line_no { get; set; } //(int, not null)
        public int? mic_line_id { get; set; } //(int, not null)
        public string char_code { get; set; } //(varchar(5), null)
        public int? sample_no { get; set; } //(int, not null)
        public int? valid_sample_no { get; set; } //(int, null)
        public string r_status { get; set; } //(varchar(1), null)
        public string attribute { get; set; } //(varchar(5), null)
        public string ind_source { get; set; } //(varchar(1), null)
        public string ind_equipment { get; set; } //(varchar(1), null)
        public string v_code { get; set; } //(varchar(1), not null)
        public string v_code_dm { get; set; } //(varchar(1), null)
        public string inspector { get; set; } //(varchar(10), null)
        public DateTime? start_date { get; set; } //(datetime2(7), null)
        public DateTime? end_date { get; set; } //(datetime2(7), null)
        public string short_desc { get; set; } //(varchar(50), null)
        public int? sample_recorded { get; set; } //(int, null)
        public int? sample_nonc { get; set; } //(int, null)
        public int? defect_no { get; set; } //(int, null)
        public int? above_values { get; set; } //(int, null)
        public int? below_values { get; set; } //(int, null)
        public int? sample_inspected { get; set; } //(int, null)
        public double? max_value { get; set; } //(double(18,6), null)
        public double? min_value { get; set; } //(double(18,6), null)
        public double? median_value { get; set; } //(double(18,6), null)
        public double? mean_value { get; set; } //(double(18,6), null)
        public int? sample_valid { get; set; } //(int, null)
        public string para_type { get; set; } //(nchar(10), null)
        public string para_code { get; set; } //(varchar(10), null)
        //public string value_code { get; set; } //(varchar(10), null)
        public string char_value { get; set; } //(varchar(10), null)
        public string version { get; set; } //(varchar(5), null)
        public string defect_class { get; set; } //(varchar(10), null)
        public string equipment { get; set; } //(varchar(40), null)
        public DateTime add_date { get; set; } //(datetime2(7), null)
        public string active { get; set; } //(bit, not null)
        public string t_status { get; set; } //(varchar(3), not null)
        public string lang_key { get; set; } //(varchar(5), null)
        public string comp_code { get; set; } //(varchar(3), not null)
        public string location_id { get; set; } //(int, not null)
        public string lab_code { get; set; } //(varchar(10), null)
        public string ind_complete { get; set; } //(varchar(1), null)
        public string insp_level { get; set; }
        public string op_no { get; set; }
        public int? op_seq { get; set; }
        public int? line_id_op { get; set; }
        public string wc_code { get; set; }
        public string insp_type { get; set; }
        public string insp_point { get; set; }
        public string doc_no_oc { get; set; }
        public string ref_doc_no { get; set; }

        // Scallar
        public string specifications { get; set; }
        public string op_name { get; set; }
        public double? sample_size { get; set; }
        public string char_name { get; set; }
        public string char_result { get; set; }
        public string char_type { get; set; }
        public double? low_limit { get; set; }
        public double? up_limit { get; set; }
        public double? target_value { get; set; }
        public string unit_code { get; set; }
        public int? line_id_a { get; set; }

        public string ind_char { get; set; }
        public string sample_uom { get; set; }
        public int? no_of_char { get; set; }
        public int? no_of_dec { get; set; }
        public string ind_case { get; set; }
        public string ind_mv { get; set; }
        public string ind_interval { get; set; }
        public string long_text { get; set; }
        public string fcode { get; set; }
        public string formula1 { get; set; }
        public string formula2 { get; set; }
        public string group_name { get; set; }
    }

    public class QMS_T003_C : ObjectBase // Classed RR / single Valued RR (QMS_T003_C / QMS_T003_D)
    {
        public int? id { get; set; } //(int, not null)
        public string doc_no { get; set; } //(varchar(20), not null)
        public int? line_no { get; set; } //(int, not null)
        public int? mic_line_id { get; set; } //(int, not null)
        public string char_code { get; set; } //(varchar(5), null)
        public int? rr_number { get; set; } //(int, not null)
        public int? sample_no { get; set; } //(int, not null)
        public string attribute { get; set; } //(varchar(5), null)
        public string ind_source { get; set; } //(varchar(1), null)
        public string ind_equipment { get; set; } //(varchar(1), null)
        public string v_code { get; set; } //(varchar(1), not null)
        public int? counter_insp_unit_no { get; set; } //(int, null)
        public string inspector { get; set; } //(varchar(10), null)
        public DateTime? start_date { get; set; } //(datetime2(7), null)
        public DateTime? end_date { get; set; } //(datetime2(7), null)
        public string short_desc { get; set; } //(varchar(50), null)
        public string measured_mode { get; set; } //(varchar(1), null)
        public double? measured_value { get; set; } //(double(18,6), null)
        public int? defect_no { get; set; } //(int, null)
        public string para_type { get; set; } //(nchar(10), null)
        public string para_code { get; set; } //(varchar(10), null)
        //public string value_code { get; set; } //(varchar(10), null)
        public string char_value { get; set; }
        public string version { get; set; } //(varchar(5), null)
        public string defect_class { get; set; } //(varchar(10), null)
        public string equipment { get; set; } //(varchar(40), null)
        public int? single_unit_lot { get; set; } //(int, null)
        public string single_unit_no { get; set; } //(varchar(20), null)
        public DateTime add_date { get; set; } //(datetime2(7), null)
        public string active { get; set; } //(bit, not null)
        public string t_status { get; set; } //(varchar(3), not null)
        public string lang_key { get; set; } //(varchar(5), null)
        public string comp_code { get; set; } //(varchar(3), not null)
        public string location_id { get; set; } //(varchar(3), not null)
        public string lab_code { get; set; } //(varchar(10), null)
        public string ind_complete { get; set; } //(varchar(1), null)
        public int a_row_id { get; set; } //(int, not null)

        // Scallar
        public string specifications { get; set; }
        public string char_spec { get; set; }
        public string op_no { get; set; }
        public string op_name { get; set; }
        public double? sample_size { get; set; }
        public string char_name { get; set; }
        public string char_result { get; set; }
        public string char_type { get; set; }
        public string v_code_text { get; set; }
        public double? low_limit { get; set; }
        public double? up_limit { get; set; }
        public double? target_value { get; set; }
        public string unit_code { get; set; }
        public int? line_id_a { get; set; } //(int, not null)

        public string ind_char { get; set; }
        public string sample_uom { get; set; }
        public int? no_of_char { get; set; }
        public int? no_of_dec { get; set; }
        public string ind_case { get; set; }
        public string ind_mv { get; set; }
        public string ind_interval { get; set; }
        public string group_name { get; set; }
    }

    public class QMS_T003_U : ObjectBase 
    {
        public string comp_code { get; set; } //(varchar(3), not null)
        public string location_id { get; set; } //(varchar(3), not null)
        public string doc_no { get; set; } //(varchar(20), not null)
        public string ind_cat { get; set; }
        public int? mic_row_id { get; set; } //(int, not null)
        public int? p_lot_no { get; set; } //(varchar(5), null)
        public string ud_no { get; set; } //(varchar(5), null)
        public string prof_type { get; set; } //(nchar(10), null)
        public string prof_code { get; set; } //(nchar(10), null)
        public string char_code { get; set; } //(varchar(10), null)
        public string char_value { get; set; }
        public string v_code { get; set; } //(varchar(5), null)
        public string v_code_dm { get; set; } //(varchar(5), null)
        public string fa_code { get; set; } //(varchar(5), null)
        public double? q_score { get; set; } //(int, not null)      
        public string emp_id { get; set; } //(varchar(5), null)
        public double? qty_ustock { get; set; }
        public double? qty_scrap { get; set; }
        public double? qty_sample { get; set; }
        public double? qty_bstock { get; set; }
        public double? qty_return { get; set; }
        public double? qty_destroyed { get; set; }
        public double? qty_inspected { get; set; }
        public double? qty_defective { get; set; }
        public string qs_pro { get; set; }
        public string remark { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }

        //Scalar
        public string short_text { get; set; }
        public string v_name { get; set; }
        public string long_text { get; set; }

    }

    public class QMS_T003_N : ObjectBase
    {
        public int? id { get; set; } //(int, not null)
        public string comp_code { get; set; } //(varchar(3), not null)
        public string location_id { get; set; } //(varchar(3), not null)
        public string defect_level { get; set; } //(varchar(3), not null)
        public string op_no { get; set; }
        public int? mic_line_id { get; set; } //(int, not null)
        public string doc_no { get; set; } //(varchar(20), not null)
        public int? line_no { get; set; } //(int, not null)
        public string char_code { get; set; } //(varchar(5), null)
        public int? sample_no { get; set; } //(int, not null)
        public int? ref_line_id { get; set; } //(int, not null)
        public string para_type { get; set; } //(varchar(5), null)
        public string para_code { get; set; } //(varchar(1), null)
        //public string value_code { get; set; } //(varchar(1), null)
        public string char_value { get; set; }
        public string version { get; set; } //(varchar(1), null)
        public string defect_desc { get; set; } //(varchar(1), not null)
        public string defect_class { get; set; } //(varchar(10), null)
        public int? no_of_defects { get; set; } //(int, null)
        public string defect_location { get; set; } //(varchar(50), null)
        public double? defect_valuation { get; set; } //(double(18,6), null)
        public string qn_process { get; set; } //(varchar(1), null)
        public DateTime? add_date { get; set; } //(datetime2(7), null)
        public string remark { get; set; } //(varchar(10), null)
        public bool active { get; set; }
        public int? a_row_id { get; set; } //(int, null)

        // Scallar
        public string op_name { get; set; }
        public double? sample_size { get; set; }
        public string char_name { get; set; }
        public string para_name { get; set; }
        public string para_value { get; set; }
        public string def_class_name { get; set; }

    }


    //public class MultipleContext_QMS_T003
    //{
    //    public List<QMS_T003_Flip> BackFlipData { get; set; }
    //    public List<ADM_M022_P> ItemMaster { get; set; }
    //    public List<QMS_P002_P> LotOriginMaster { get; set; }
    //    public List<QMS_M030_P> InspPlanMaster { get; set; }
    //    public List<ADM_M028_P> PartyMaster { get; set; }
    //    public List<ADM_M001_M_P> PurchaseOrg { get; set; }
    //    public List<QMS_T003> MasterEntity { get; set; }
    //    public List<ADM_M038_B_P> UnitMaster { get; set; }
    //    public List<QMS_T003_A> Insp_process_RR1 { get; set; }
    //    public List<QMS_T003_B> Insp_process_RR2 { get; set; }
    //    public List<QMS_T003_C> Insp_process_RR3 { get; set; }
    //    public List<QMS_M033_A> Profile_Values { get; set; }
    //    public List<QMS_T003_N> Defect_Data { get; set; }
    //    public List<QMS_T003_U> Usage_Decision { get; set; }
    //    public List<QMS_M048> Folloup_Action { get; set; }
    //    public List<MM_M001_P> StorageLocations { get; set; }
    //}

}
