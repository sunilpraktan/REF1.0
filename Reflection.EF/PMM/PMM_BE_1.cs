using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.PMM
{
    public class PMM_M0001 : ObjectBase
    {
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string equip_no { get; set; }
        public string equip_name { get; set; }
        public string short_text { get; set; }
        public string store_code { get; set; }
        public string batch_no { get; set; }
        public DateTime? create_date { get; set; }
        public string lang_key { get; set; }
        public string equip_cat { get; set; }
        public string obj_type { get; set; }
        public string obj_no { get; set; }
        public string dimension { get; set; }
        public decimal? obj_weight { get; set; }
        public string uom_weight { get; set; }
        public DateTime? aquisition_date { get; set; }
        public decimal? aquisition_value { get; set; }
        public string curr_code { get; set; }
        public string vendor_code { get; set; }
        public string customer_code { get; set; }
        public DateTime? warranty_date_sd { get; set; }
        public string warranty_code { get; set; }
        public DateTime? warranty_start { get; set; }
        public DateTime? warranty_end { get; set; }
        public string manufacturer { get; set; }
        public string mfg_srno { get; set; }
        public string mfg_model { get; set; }
        public string mfg_country { get; set; }
        public string mfg_drawing { get; set; }
        public DateTime? mfg_date { get; set; }
        public string mfg_year { get; set; }
        public string mfg_month { get; set; }
        public string serial_no { get; set; }
        public string item_code_config { get; set; }
        public string item_code { get; set; }
        public string maint_plan { get; set; }
        public string unique_code { get; set; }
        public string barcode { get; set; }
        public string party_code { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }
        public string lab_code { get; set; }
        public DateTime? valid_from { get; set; }
        public DateTime? valid_to { get; set; }
        public double? range_h { get; set; }
        public string range_h_uom { get; set; }
        public double? range_l { get; set; }
        public string range_l_uom { get; set; }
        public double? accuracy_h { get; set; }
        public double? accuracy_l { get; set; }
        public double? accuracy_h_var { get; set; }
        public double? accuracy_l_var { get; set; }
        public double? least_count { get; set; }
        public string lc_uom { get; set; }
        public double? resolution { get; set; }
        public string resolution_uom { get; set; }
        public double? uncertainty { get; set; }
        public string uncertainty_uom { get; set; }
        public string invoice_no { get; set; }
        public decimal? avg_consump { get; set; }
        public string avg_uom { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public string ah_uom { get; set; }
        public string al_uom { get; set; }
        public string tsb_code { get; set; }
        public double? ucmc { get; set; }
        public double? utot { get; set; }
        public DateTime? cal_date { get; set; }
        public string cert_no { get; set; }
        public string group_code { get; set; }
        public string ratio { get; set; }
        public string ratio_uom { get; set; }
        public string rating { get; set; }
        public string rating_uom { get; set; }


        //GEN_T002 Fields
        public string long_text { get; set; }

        //Scalar Fields
        public string object_name { get; set; } // Object Type Name
        public string party_name { get; set; }
        public string t_display { get; set; }
        public string cat_name { get; set; } // Equipment Category Name
        public string group_name { get; set; } // Equipment Group Name
        public string XDOC_A { get; set; } // Fleet Info



    }

    public class PMM_M0021 : ObjectBase
    {
        public string comp_code { get; set; }
        public string obj_no { get; set; }
        public string obj_group { get; set; }
        public string obj_type { get; set; }
        public string equip_cat { get; set; }
        public string equip_no { get; set; }
        public string fleet_no { get; set; }
        public string short_text { get; set; }
        public string fleet_no_mfg { get; set; }
        public string chassis_no { get; set; }
        public string lic_no { get; set; }
        public DateTime? valid_from { get; set; }
        public DateTime? valid_to { get; set; }
        public decimal? obj_height { get; set; }
        public decimal? obj_width { get; set; }
        public decimal? obj_length { get; set; }
        public string uom_length { get; set; }
        public string ind_cal { get; set; }
        public DateTime? date_replace { get; set; }
        public string odo_reading { get; set; }
        public string hr_reading { get; set; }
        public int? axel_no { get; set; }
        public int? max_ocu { get; set; }
        public string fuel_card { get; set; }
        public string key_no { get; set; }
        public string ind_use { get; set; }
        public string engine_type { get; set; }
        public decimal? eng_power { get; set; }
        public string uom_power { get; set; }
        public decimal? rpm { get; set; }
        public int? cyl_no { get; set; }
        public decimal? eng_capacity { get; set; }
        public string uom_eng { get; set; }
        public string eng_sr { get; set; }
        public string con_type1 { get; set; }
        public string con_type2 { get; set; }
        public string oil_type { get; set; }
        public decimal? wt_allowed { get; set; }
        public decimal? max_load { get; set; }
        public string uom_wt { get; set; }
        public decimal? load_height { get; set; }
        public decimal? load_width { get; set; }
        public decimal? load_length { get; set; }
        public string uom_freight { get; set; }
        public decimal? load_volume { get; set; }
        public string uom_volume { get; set; }
        public int? comp_no { get; set; }
        public decimal? max_speed { get; set; }
        public string uom_speed { get; set; }
        public decimal? trailer_load { get; set; }
        public string uom_weight { get; set; }
        public string active { get; set; }
        public string color { get; set; }
        public DateTime? reg_date { get; set; }
        


        //GEN_T002 Fields
        public string long_text { get; set; }

        //Scalar Fields
       


    }

    public class PMM_T001
    {
        public string client { get; set; }
        public int? id { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string short_text { get; set; }
        public string mp_cat { get; set; }
        public string str_code { get; set; }
        public int? sch_period { get; set; }
        public string sch_unit { get; set; }
        public string equip_no { get; set; }
        public string fun_loc { get; set; }
        public string cust_id { get; set; }
        public string party_code { get; set; }
        public int? call_no { get; set; }
        public int? shift_late { get; set; }
        public int? shift_early { get; set; }
        public int? tol_late { get; set; }
        public int? tol_early { get; set; }
        public decimal mod_factor { get; set; }
        public string ind_sch { get; set; }
        public int? re_sch { get; set; }
        public int? trigger_point { get; set; }
        public string ind_or_and { get; set; }
        public string ind_reserved { get; set; }
        public string obj_no { get; set; }
        public DateTime? start_date { get; set; }
        public string start_counter { get; set; }
        public int? l_float { get; set; }
        public int? f_float { get; set; }
        public DateTime? sch_start { get; set; }
        public string sch_time { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }


        //Scalar Fields

        public string long_text { get; set; }
        public string XDOC_A { get; set; }
        public string XDOC_B { get; set; }
        public string XDOC_C { get; set; }
        public string XDOC_D { get; set; }
        public string XDOC_E { get; set; }
    }

    public class PMM_T001_A
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string doc_no { get; set; }
        public int? id { get; set; }
        public string mp_item { get; set; }
        public string str_code { get; set; }
        public int? line_id { get; set; }
        public string short_text { get; set; }
        public string equip_no { get; set; }
        public int? obj_list_no { get; set; }
        public string tl_type { get; set; }
        public string tl_key { get; set; }
        public int? op_row_id { get; set; }
        public string group_counter { get; set; }
        public string wc_code { get; set; }
        public string mp_plant { get; set; }
        public string order_no { get; set; }
        public string order_cat { get; set; }
        public string assembly_code { get; set; }
        public string mp_act { get; set; }
        public string obj_no { get; set; }
        public string element_id { get; set; }
        public string tl_key2 { get; set; }
        public int? tl_node { get; set; }
        public string sd_doc_no { get; set; }
        public int? sd_item_row_id { get; set; }
        public string item_cat { get; set; }
        public string po_no { get; set; }
        public int? po_tem_row_id { get; set; }
        public int? pack_no { get; set; }
        public decimal net_price { get; set; }
        public string curr_code { get; set; }
        public string set_order { get; set; }
        public decimal exe_fact { get; set; }
        public string serial_no { get; set; }
        public string item_code { get; set; }
        public string device_data { get; set; }
        public string not_no { get; set; }
        public string not_type { get; set; }
        public string entry_no { get; set; }
        public string cat_type { get; set; }
        public string code_group { get; set; }
        public string value_code { get; set; }
        public string sample_no { get; set; }
        public string insp_type { get; set; }
        public string insp_lot { get; set; }
        public int? cycle_seq { get; set; }
        public string ref_element { get; set; }
        public string t_status { get; set; }
        public string active { get; set; }

        // Scalar

        public string item_name { get; set; }
        public string equip_name { get; set; }
        public string location_name { get; set; }
        public string wc_name { get; set; }
        public string strategy_name { get; set; }
        public string plan_cat_name { get; set; }
        public string order_cat_name { get; set; }
        public string tl_name { get; set; }

    }

    public class PMM_T001_B : ObjectBase
    {
        public int? id { get; set; }
        public string doc_no { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public int? item_row_id { get; set; }
        public int? t_counter { get; set; }
        public string comp_opr { get; set; }
        public double? mp_cycle { get; set; }
        public string unit_code { get; set; }
        public string short_text { get; set; }
        public string mp_no { get; set; }
        public double? mp_offset { get; set; }
        public string ind_event { get; set; }
        public double? next_read { get; set; }
        public int? pack_no { get; set; }
        public string note { get; set; }
        public int? cycle_seq { get; set; }
        public int? rep_factor { get; set; }
        public string t_status { get; set; }
        public string active { get; set; }

        

    }

    public class PMM_T002 : ObjectBase
    {
        public string comp_code { get; set; }
        public string doc_no { get; set; }
        public int? call_no { get; set; }
        public int? pack_no { get; set; }
        public string location_id { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public DateTime? next_plan_date { get; set; }
        public DateTime? last_plan_date { get; set; }
        public string sch_type { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? last_comp_date { get; set; }
        public double? offset_curr { get; set; }
        public double? offset_prev { get; set; }
        public DateTime? call_date { get; set; }
        public string emp_id { get; set; }
        public decimal? mod_factor { get; set; }
        public string ind_sch { get; set; }
        public int? sf_late { get; set; }
        public int? tol_late { get; set; }
        public DateTime? manual_date { get; set; }
        public double? prf_annual { get; set; }
        public double? shift_factor { get; set; }
        public string ind_reserved { get; set; }
        public string ind_call_date { get; set; }
        public string ind_call_out { get; set; }
        public string ind_call_reached { get; set; }
        public string ind_stop { get; set; }
        public DateTime? call_date2 { get; set; }
        public string sch_status { get; set; }
        public int? prev_call { get; set; }
        public double? pkg_offset { get; set; }
        public double? call_date_reading { get; set; }
        public int? lead_float { get; set; }
        public int? follow_float { get; set; }
        public double? start_reading { get; set; }
        public double? read_confirm { get; set; }
        public double? next_reading { get; set; }
        public string sch_emp_id { get; set; }
        public string mp_no { get; set; }
        public string ind_or_and { get; set; }
        public int? re_sch { get; set; }
        public double? pkg_offset1 { get; set; }
        public string per_unit { get; set; }
        public double? time_offset { get; set; }
        public double? next_plan_reading { get; set; }
        public string start_time { get; set; }
        public string last_comp_time { get; set; }
        public int? cycle_seq { get; set; }
        public string obj_no { get; set; }
        public string start_time_sch { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }

    }
    public class PMM_T003 : ObjectBase
    {
        public string doc_no { get; set; }
        public int? call_no { get; set; }
        public string mp_item { get; set; }
        public string comp_code { get; set; }
        public int? item_row_id { get; set; }
        public string order_no { get; set; }
        public DateTime? comp_date { get; set; }
        public string entry_no { get; set; }
        public string ind_call { get; set; }
        public string ind_sch { get; set; }
        public DateTime? start_date { get; set; }
        public string not_no { get; set; }
        public string comp_time { get; set; }
        public string insp_lot { get; set; }
        public string emp_id { get; set; }

    }
    public class PMM_T005 : ObjectBase
    {
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public DateTime? doc_date { get; set; }
        public string mp_no { get; set; }
        public DateTime? record_date { get; set; }
        public string record_time { get; set; }
        public string time_stamp { get; set; }
        public string ind_counter { get; set; }
        public string short_text { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public string ind_org { get; set; }
        public string lot_no { get; set; }
        public int? order_node_no { get; set; }
        public int? char_no { get; set; }
        public string source_doc { get; set; }
        public string prt_no { get; set; }
        public string obj_no { get; set; }
        public double? read_value { get; set; }
        public string ind_value { get; set; }
        public double? read_ue { get; set; }
        public string ind_value1 { get; set; }
        public string unit_code { get; set; }
        public double? read_counter { get; set; }
        public string ind_value2 { get; set; }
        public double? read_diff { get; set; }
        public string ind_value3 { get; set; }
        public string ind_diff { get; set; }
        public string ind_replace { get; set; }
        public string ind_ext { get; set; }
        public string cat_type { get; set; }
        public string cat_group { get; set; }
        public string value_code { get; set; }
        public string ver_no { get; set; }
        public string ind_rev { get; set; }
        public string obj_no_order { get; set; }
        public string part_sample_no { get; set; }
        public string result_val { get; set; }
        public string ind_time { get; set; }
        public DateTime? int_date { get; set; }
        public string int_time { get; set; }
        public decimal? time_stamp_d { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }

        //Scalar
        public string mp_name { get; set; }
        public string pos_no { get; set; }
        public string obj_name { get; set; }
        public string char_name { get; set; }
        public string char_unit { get; set; }
        public string long_text { get; set; }
        public string mp_cat { get; set; }
        public string cat_name { get; set; }
        public double? previous_value { get; set; } // Temp variable for stoaring prevous counter value

        public string XDOC_A { get; set; }

    }





    public class MC_PMM_T001_BE : MC_PMM_BE
    {
        public List<PMM_T001> MasterEntity { get; set; }
        public List<PMM_T001_A> ItemsEntity { get; set; }
        public List<PMM_T001_B> CycleEntity { get; set; }
        public List<PMM_T002> ScheduleEntity { get; set; }
        public List<PMM_T003> CallObjectEntity { get; set; }

    }
}
