using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
    public partial class QMS_M030 : ObjectBase
    {
        public string plan_no { get; set; }
        public Nullable<System.DateTime> plan_date { get; set; }
        public string task_list { get; set; }
        public string group_counter { get; set; }
        public Nullable<int> plan_counter { get; set; }
        public Nullable<System.DateTime> valid_from { get; set; }
        public string task_list_use { get; set; }
        public string task_list_type { get; set; }
        public string task_list_unit { get; set; }
        public Nullable<decimal> lot_size_from { get; set; }
        public Nullable<decimal> lot_size_to { get; set; }
        public string task_list_desc { get; set; }
        public string lang_key { get; set; }
        public string assign_para_set { get; set; }
        public string para_set_location { get; set; }
        public string dynamic_rule { get; set; }
        public string para_group { get; set; }
        public string para_value { get; set; }
        public string sd_no { get; set; }
        public string sd_version { get; set; }
        public string insp_point { get; set; }
        public string ItemCode { get; set; }
        public string bom_no { get; set; }
        public string bom_cat { get; set; }
        public string alternate_bom_no { get; set; }
        public Nullable<decimal> base_qty { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> num_operation { get; set; }
        public Nullable<decimal> deno_operation { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string t_status { get; set; }
        public string plan_desc { get; set; }
        public string plan_app { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string ItemName { get; set; }
        public string XmlDataDocument_QMS_M030_Flip { get; set; }
        public string XmlDataDocument_QMS_M030_A { get; set; }
        public string XmlDataDocument_QMS_M030_B { get; set; }
        public string XmlDataDocument_QMS_M030_C { get; set; }
        public string XmlDataDocument_QMS_M030_D { get; set; }

    }

    public partial class QMS_M030_A
    {
        public int id { get; set; }
        public string plan_no { get; set; }
        public string client { get; set; }
        public string ItemCode { get; set; }
        public string task_list_type { get; set; }
        public string group_counter { get; set; }
        public Nullable<int> plan_counter { get; set; }
        public Nullable<System.DateTime> valid_from { get; set; }
        public string cust_id { get; set; }
        public string vender_id { get; set; }
        public string sales_doc_no { get; set; }
        public Nullable<int> sales_doc_item_row_id { get; set; }
        public string bom_no { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string t_status { get; set; }
        public string lang_key { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string inspector { get; set; }
        public string approve_by { get; set; }
        public int? seq_op { get; set; }
        public int? bom_item_line_id { get; set; }
        public int? line_id_op { get; set; }
        public decimal? qty { get; set; }
        public string unit_code { get; set; }
        public string ind_backflush { get; set; }
        public string alternet_bom { get; set; }
        public int? line_id { get; set; }

        //Scalar
        public string ItemName { get; set; }
    }

    public partial class QMS_M030_B
    {
        public int id { get; set; }
        public string plan_no { get; set; }
        public string task_list_type { get; set; }
        public string client { get; set; }
        public Nullable<int> plan_counter { get; set; }
        public Nullable<System.DateTime> valid_from { get; set; }
        public string operation_no { get; set; }
        public string control_key { get; set; }
        public string obj_id { get; set; }
        public string obj_type { get; set; }
        public string op_code { get; set; }
        public string short_text { get; set; }
        public string operation_desc { get; set; }
        public string lang_key { get; set; }
        public Nullable<decimal> base_qty { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> num_operation { get; set; }
        public Nullable<decimal> deno_operation { get; set; }
        public string activity_type1 { get; set; }
        public string unit_code1 { get; set; }
        public Nullable<decimal> std_value1 { get; set; }
        public string activity_type2 { get; set; }
        public string unit_code2 { get; set; }
        public Nullable<decimal> std_value2 { get; set; }
        public string activity_type3 { get; set; }
        public string unit_code3 { get; set; }
        public Nullable<decimal> std_value3 { get; set; }
        public string std_value_cal { get; set; }
        public Nullable<decimal> scrap_factor { get; set; }
        public string cust_id { get; set; }
        public string vendor_id { get; set; }
        public string bom_no { get; set; }
        public string bom_cat { get; set; }
        public Nullable<int> bom_item_row_id { get; set; }
        public string priority { get; set; }
        public string service_no { get; set; }
        public string pur_doc_no { get; set; }
        public Nullable<int> pur_doc_item_row_id { get; set; }
        public string inst_code { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string t_status { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public int? line_id { get; set; }
        public int? op_seq { get; set; }
        public string wc_code { get; set; }
        public string task_id { get; set; }
    }

    public partial class QMS_M030_C
    {
        public int id { get; set; }
        public string plan_no { get; set; }
        public string client { get; set; }
        public string task_list_type { get; set; }
        public string insp_char_type { get; set; }
        public int line_id { get; set; }
        public string insp_char { get; set; }
        public Nullable<int> insp_char_no { get; set; }
        public Nullable<int> plan_counter { get; set; }
        public Nullable<System.DateTime> valid_from { get; set; }
        public string insp_method { get; set; }
        public string insp_method_loc { get; set; }
        public string insp_method_version { get; set; }
        public string Ref_inspc_char { get; set; }
        public string insp_char_location { get; set; }
        public string insp_char_version_no { get; set; }
        public Nullable<System.DateTime> ver_date { get; set; }
        public string way_char { get; set; }
        public string inspector_qualification { get; set; }
        public string tol_key { get; set; }
        public string short_txt { get; set; }
        public string desc { get; set; }
        public string lang_key { get; set; }
        public Nullable<int> dc_place { get; set; }
        public string uom_quantitative { get; set; }
        public Nullable<decimal> target_value_char { get; set; }
        public string value1 { get; set; }
        public Nullable<decimal> lower_limit { get; set; }
        public Nullable<decimal> upp_limit { get; set; }
        public Nullable<decimal> lower_limit1 { get; set; }
        public Nullable<decimal> upp_limit1 { get; set; }
        public string value2 { get; set; }
        public Nullable<decimal> lower_tol_limit { get; set; }
        public Nullable<decimal> upper_tol_limit { get; set; }
        public string sample_uom { get; set; }
        public string samp_pro_char { get; set; }
        public Nullable<decimal> cf_sample { get; set; }
        public Nullable<decimal> cf_material { get; set; }
        public Nullable<decimal> sampl_qty_factor { get; set; }
        public string modification_data { get; set; }
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
        public string modification_rule { get; set; }
        public string test_equipment { get; set; }
        public string qm_para_group2 { get; set; }
        public string qm_para2 { get; set; }
        public string control_method { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string t_status { get; set; }
        public string control_data { get; set; }
        public string fract_cal { get; set; }
        public string MethodNm { get; set; }
        public string CharName { get; set; }
        public string operation_no { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string para_prof_code { get; set; }
        public string gc_or_ss { get; set; }
        public string ind_char { get; set; }
        public int? line_id_op { get; set; }
    }

    public partial class QMS_M030_D
    {
        public int id { get; set; }
        public string plan_no { get; set; }
        public string operation_no { get; set; }
        public string insp_char { get; set; }
        public string para_type { get; set; }
        public string gc_or_ss { get; set; }
        public string plant_gc { get; set; }
        public Nullable<bool> ind_gc_or_ss { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string t_status { get; set; }
        public string lang_key { get; set; }
        public string client { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public int? line_id_ic { get; set; }
        public int? line_id_op { get; set; }
        //scalar
        public string ParaName { get; set; }

    }
}
