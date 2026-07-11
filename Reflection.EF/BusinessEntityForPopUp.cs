using System;
using System.ComponentModel;


//Created by Team Praktan
namespace Reflection.EF
{
    class BusinessEntityForPopUp
    {

    }

    public class General_Ledger_P //General Ledger Popup 
    {
        public string gl_code { get; set; }
        public string ledger_gen { get; set; }
        public string ledger_gen_desc { get; set; }
        public string acc_type { get; set; }
        public string ledger_gen_type { get; set; }
        public string gl_name { get; set; }
    }
    public class ACC_M004_B_P //Bank Account Master
    {
        public string hb_code { get; set; }
        public string hb_acc { get; set; }
        public string acc_no { get; set; }
        public string acc_id { get; set; }
        public string bank_name { get; set; }
        public string gl_code { get; set; }
        public string gl_name { get; set; }
        public string ledger_gen { get; set; }
    }
    public class ADM_M028_E_P //Party Bank Account Master
    {
        public string acc_number { get; set; }
        public string bank_code { get; set; }
        public string bank_name { get; set; }
        public string ifsccode { get; set; }
        public string swift_code { get; set; }
        public string gl_code { get; set; }
        public string gl_name { get; set; }
    }
    public class SYS_M027_P //Reason Master
    {
        public string reason_code { get; set; }
        public string reason_desc { get; set; }
    }
    public class ACC_M020_P //Profit Center Master
    {
        public string profit_center { get; set; }
        public string profit_center_Desc { get; set; }
    }
    public class ACC_M027_P //Payment Method Master
    {
        public string pay_method { get; set; }
        public string pay_method_desc { get; set; }
        public string ledger_gen_c { get; set; }
        public string ledger_gen_d { get; set; }
    }
    //public class ADM_M0013 //Transaction Status Master
    //{
    //    public int id { get; set; }
    //    public string t_status { get; set; }
    //    public string t_name { get; set; }
    //    public string t_display { get; set; }
    //    public string ind_default { get; set; }
    //    public string ind_goods_posting { get; set; }
    //    public string ind_released { get; set; }
    //}
    public class GEN_T009_P    //Waybill doc no.
    {
        public string doc_no { get; set; }
    }
    //public class SYS_M025_P //Transaction Status Assignmnt to Doc
    //{
    //    public int id { get; set; }
    //    public string t_status { get; set; }
    //    public string t_name { get; set; }
    //    public string t_display { get; set; }
    //    public int t_sequence { get; set; }
    //    public string doc_type { get; set; }
    //    public string doc_cat { get; set; }
    //    public string t_module { get; set; }

    //}
    public class SYS_P004_P //Business Place Master
    {
        public string seg_code { get; set; }
        public string seg_name { get; set; }
    }
    public class ACC_M003_R_P //Business Place Master
    {
        public string buss_place { get; set; }
        public string buss_place_Nm { get; set; }
    }
    public class ACC_M003_C_P   //Business Place Master
    {
        public string group_cat { get; set; }
        public string group_cat_name { get; set; }
    }
    public class ACC_M003_T_Doc_Cat //entity to load doc_cat for Account Determination
    {
        public string doc_type { get; set; }
        public string doc_desc { get; set; }
    }

    public class QMS_M030_I_Flip
    {
        public string insp_char { get; set; }
        public string char_desc { get; set; }
        public Nullable<System.DateTime> from_date { get; set; }
        public string insp_char_type { get; set; }
        public decimal? lower_limit { get; set; }
        public decimal? upp_limit { get; set; }
        public string t_status { get; set; }
    }

    public class QMS_M032_P
    {
        public string para_type { get; set; }
        public string cat_type_desc { get; set; }
        public string ind_set { get; set; }
        public string ind_value { get; set; }
    }

    public class Group_Set
    {
        public string para_prof_code { get; set; }
        public string Name { get; set; }
        public string location_id { get; set; }
        public string Seperator { get; set; }
    }

    public class QMS_M036_P
    {
        public string valuation_mode { get; set; }
        public string desc { get; set; }
        public string ind_val_rule { get; set; }
    }

    public class QMS_M037_P
    {
        public string sample_type { get; set; }
        public string desc { get; set; }
    }

    public class QMS_M038_P
    {
        public string insp_severity { get; set; }
        public string insp_severity_desc { get; set; }
    }

    public class QMS_M034_Flip
    {
        public string sp_code { get; set; }
        public string sp_desc { get; set; }
        public string sample_type { get; set; }
        public string valuation_mode { get; set; }
        public string t_status { get; set; }
    }

    public class QMS_T003_Flip
    {
        public string doc_no { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string doc_source { get; set; }
        public string insp_type { get; set; }
        public Nullable<decimal> insp_lot_qty { get; set; }
        public string tl_code { get; set; }
    }

    public class QMS_P002_P
    {
        public string lot_origin { get; set; }
        public string OriginDesc { get; set; }
        public string insp_type { get; set; }
        public string InspTypeNm { get; set; }
    }

    public class QMS_M039_P
    {
        public string insp_type { get; set; }
        public string insp_type_desc { get; set; }
        public string task_list_type { get; set; }
        public string para_prof_code { get; set; }
        public string control_ke { get; set; }
        public string notification_type { get; set; }
        public string operation_no { get; set; }
    }

    public class QMS_M043_Flip
    {
        public string sd_no { get; set; }
        public string sd_desc { get; set; }
        public Nullable<System.DateTime> valid_from { get; set; }
        public string t_status { get; set; }
    }

    public class QMS_M044_P
    {
        public string phy_smpl_container { get; set; }
        public string smpl_desc { get; set; }
    }

    public class QMS_M040_Flip
    {

    }

    public class QMS_M034_P
    {
        public string sp_code { get; set; }
        public string sp_desc { get; set; }
        public string sample_type { get; set; }
        public string valuation_mode { get; set; }
        public string sample_scheme { get; set; }
        public string sample_size_per { get; set; }
        public string insp_severity { get; set; }

    }

    public class QMS_M022_Flip
    {
        public string qualification { get; set; }
        public string description { get; set; }
    }

    public class QMS_M035_P
    {
        public string sample_scheme { get; set; }
        public string desc { get; set; }
        public string ind_attr_insp { get; set; }
        public string ind_var_insp { get; set; }
        public string without_val_para { get; set; }
        public string ind_aql_val { get; set; }

    }

    public class QMS_M030_P
    {
        public string plan_no { get; set; }
        public Nullable<System.DateTime> plan_date { get; set; }
        public Nullable<System.DateTime> valid_from { get; set; }
        public decimal? lot_size_from { get; set; }
        public decimal? lot_size_to { get; set; }
        public string ItemCode { get; set; }
    }

    public class QMS_M030_Flip
    {
        public string plan_no { get; set; }
        public Nullable<System.DateTime> plan_date { get; set; }
        public Nullable<DateTime> valid_from { get; set; }
        public string ItemCode { get; set; }
        public decimal? lot_size_from { get; set; }
        public decimal? lot_size_to { get; set; }
        public string t_status { get; set; }
        public string plan_app { get; set; }
        public string location_Id { get; set; }
        public string ItemName { get; set; }
    }

    public class QMS_M035_Flip
    {
        public string sample_scheme { get; set; }
        public string desc { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string t_status { get; set; }
    }

    public class QMS_M009_F_P
    {
        public string para_code { get; set; }
        public string para_name { get; set; }
        public string para_type { get; set; }
    }

    public class QMS_M009_G_P
    {
        public string para_code { get; set; }
        public string para_name { get; set; }
        public string value_code { get; set; }
        public string para_value { get; set; }
        public string para_type { get; set; }
        public string cat_type_desc { get; set; }
        public string defect_class { get; set; }
        public string group_code_name { get; set; }
        public string def_class_name { get; set; }
        public Nullable<decimal> quality_score { get; set; }
        public string location_Id { get; set; }
    }



    public class QMS_M030_I_P
    {
        public string insp_char { get; set; }
        public string char_desc { get; set; }
        public string insp_char_type { get; set; }
        public Nullable<decimal> lower_limit { get; set; }
        public decimal? upp_limit { get; set; }
        public string version_no { get; set; }
        public Nullable<System.DateTime> from_date { get; set; }
        public string inspector_qualification { get; set; }
        public string way_char { get; set; }
        public string insp_char_location { get; set; }

    }

    public class QMS_M022_P
    {
        public string qualification { get; set; }
        public string description { get; set; }
    }

    public class QMS_M030_G_Flip
    {
        public string insp_method { get; set; }
        public string method_desc { get; set; }
        public string version_no { get; set; }
        public string t_status { get; set; }
    }

    public class QMS_M030_G_P
    {
        public string insp_method { get; set; }
        public string method_desc { get; set; }
        public string version_no { get; set; }
        public Nullable<System.DateTime> valid_from { get; set; }
        public string inspector_qualification { get; set; }
    }
    public class QMS_M031_P
    {
        public string defect_class { get; set; }
        public string defect_class_name { get; set; }
        public Nullable<decimal> quality_score { get; set; }
        public Nullable<System.DateTime> valid_from { get; set; }
    }
    public class QMS_M033_Flip
    {
        public string para_prof_code { get; set; }
        public string para_prof_desc { get; set; }
        public string para_type { get; set; }
        public string para_type_name { get; set; }
        public string t_status { get; set; }
    }

    public class QMS_M041_P
    {
        public string target_qm_sys { get; set; }
        public string qm_sys_desc { get; set; }
    }

    public class QMS_M042_P
    {
        public string certi_tp { get; set; }
        public string certi_desc { get; set; }
        public bool certi_req_pur { get; set; }
        public bool certi_req_delivry { get; set; }
        public string certi_not_available { get; set; }
    }
    public class ECRM_T004_P
    {
        public string barcode_no { get; set; }
        public string order_no { get; set; }
        public string shift { get; set; }
        public DateTime? prodate { get; set; }
    }

    public class ECRM_T003_P
    {
        public string ItemName { get; set; }
        public string EmpName { get; set; }
        public string PartyNm { get; set; }
        public string barcode { get; set; }
        public string wtno { get; set; }
        public DateTime? prddt { get; set; }
        public string prdct_code { get; set; }
        public int mchn_id { get; set; }
        public string machinecode { get; set; }
        public string shift { get; set; }
        public string PartyId { get; set; }
        public string modlno { get; set; }
        public string EmpId { get; set; }
        public string order_no { get; set; }
        public Decimal? counter_qty { get; set; }
        public string lotno { get; set; }
        public string tiptp { get; set; }
        public string ink { get; set; }
        public decimal? tmnild { get; set; }
        public decimal? tmxild { get; set; }
        public string Conv_lot { get; set; }

        public string PartyId1 { get; set; }
        public string PartyName1 { get; set; }
        public string ItemCode1 { get; set; }
        public string ItemName1 { get; set; }
        public string sono { get; set; }
        public decimal? quantity1 { get; set; }
        public DateTime? sodate { get; set; }
        public string Grade { get; set; }
        public string wc_code { get; set; }
        public string remark { get; set; }  //obrem
        public string remark1 { get; set; } //uhdec
        public string remark2 { get; set; } //uhrem
        public string counter_remark { get; set; }
    }
    public class MM_T001_P
    {
        public string doc_no { get; set; }
        public string ItemCode { get; set; }
        public decimal? qty { get; set; }
        public string order_doc_no { get; set; }
        public string sku { get; set; }
    }
    public class PRO_T002_P
    {
        public string task_id { get; set; }
        public string project_id { get; set; }
        public int phase_id { get; set; }
        public string title { get; set; }
        public string t_status { get; set; }
    }
    public class PRO_T002_P_1
    {
        public string title { get; set; }
        public string t_description { get; set; }
        public string task_code { get; set; }
    }
    public class PRO_T002_A_P
    {
        public string work_summary { get; set; }
    }
    public class PRO_M005_P
    {
        public string point_id { get; set; }
        public string point_description { get; set; }
    }
    public class SYS_M017_P
    {
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string TranCode { get; set; }
    }
    public class PRO_T001_B_P
    {
        public string EmpId { get; set; }
        public string EmpLName { get; set; }
        public string Emp_type { get; set; }
        public string project_id { get; set; }
        public string role_name { get; set; }
    }
    public class Report_Data_P
    {
        public int id { get; set; }
        public string data1 { get; set; }
    }
    public class TransHistory
    {
        public string Transaction { get; set; }
        public string TranCode { get; set; }
        public string doc_no { get; set; }
        public DateTime? date { get; set; }
        public string unit_code { get; set; }
        public decimal? Qty { get; set; }
        public Decimal Less_Qty { get; set; }
        public string Operator { get; set; }
        public string remark { get; set; }
        public string remark1 { get; set; }
        public string remark2 { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
    }

    public class PRO_T001_A_P
    {
        public string project_id { get; set; }
        public int phase_id { get; set; }
        public string phase_name { get; set; }
        public string sequence { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? dead_date { get; set; }
    }
    public class PRO_T001_P
    {
        public string project_id { get; set; }
        public string project_name { get; set; }
        public string element_id { get; set; }
        public string element_name { get; set; }
        public int? element_no { get; set; }
        public int? project_no { get; set; }
        public string customernm { get; set; }
        public string projectmanagernm { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_no { get; set; }
        public int? ref_item_row_id { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string party_code { get; set; }
        public string party_name { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
    }
    public class PRO_M004_P
    {
        public string RoleCode { get; set; }
        public string role_name { get; set; }
    }
    public class PRO_M003_P
    {
        public string phase_id { get; set; }
        public bool? fold { get; set; }
        public string phase_name { get; set; }
        public string description { get; set; }
        public string sequence { get; set; }
    }
    public class QMS_T002Flip
    {
        public string doc_no { get; set; }
        public string barcode { get; set; }
        public string ref_doc_no { get; set; }
        public string serv_type { get; set; }
        public string inst_name { get; set; }
        public DateTime doc_date { get; set; }
        public string cal_type { get; set; }
        public string cust_name { get; set; }
        public string t_status { get; set; }
        public string inst_srno { get; set; }
        public string inst_id { get; set; }
        public string model_no { get; set; }
        public DateTime req_date { get; set; }
        public DateTime exp_date { get; set; }
        // Scalar
        public string lab_name { get; set; }
        public string test_name { get; set; }
    }
    public class PRO_M002_P
    {
        public int ver_id { get; set; }
        public string ver_name { get; set; }

    }

    public class PMT_M001_P
    {
        public string bdr_code { get; set; }
        public string bdr_desc { get; set; }
    }
    public class ACC_M022
    {
        public string JE_type { get; set; }
        public string JE_desc { get; set; }
    }
    public class VendorPopup
    {
        public string vendor_code { get; set; }
        public string vendor_name { get; set; }
        public string JE_type { get; set; }
        public string gl_code { get; set; }
        public string acc_type { get; set; }
    }
    public class ACC_T003_H_POPUP
    {
        public int vehicle_id { get; set; }
        public string vehicle_no { get; set; }
        public string vehicle_name { get; set; }
        public string driver_name { get; set; }
    }
    public class SEL_T003_POP
    {
        public string bill_doc { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string PartyId { get; set; }
        public string CustomerNm { get; set; }
        public string ref_doc_type { get; set; }
        public string ref_doc_cat { get; set; }
        public Nullable<System.DateTime> ref_doc_date { get; set; }
        public string para3 { get; set; }
        public string project_location { get; set; }
        public string PartyType { get; set; }
    }
    public class SYS_C001_P
    {
        public string theme_code { get; set; }
        public string theme_title { get; set; }
    }
    public class SYS_C002
    {
        public string lang_key { get; set; }
        public string lang_desc { get; set; }
    }
    public class SYS_C007
    {
        public string date_format { get; set; }
        public string date_sample { get; set; }
    }
    public class SYS_C006
    {
        public string round_up_method_code { get; set; }
        public string round_up_method_name { get; set; }
    }
    public class ADM_M038_C_P
    {
        public string unit_code { get; set; }
        public string base_unit_code { get; set; }
        public decimal c_factor { get; set; }
    }

    public class ZADM_M009_Flip
    {
        public int model_id { get; set; }
        public string modelno { get; set; }
        public string modlnm { get; set; }
        public string modeldesc { get; set; }

    }
    public class QMS_M003_P
    {
        public string inst_code { get; set; }
        public string inst_name { get; set; }
        public string inst_srno { get; set; }
        public string inst_id { get; set; }
        public string model_no { get; set; }
        public string inst_make { get; set; }
        public string range { get; set; }
        public decimal? accuracy_up { get; set; }
        public decimal? least_count { get; set; }
        public decimal? resolution { get; set; }
        public string tr_code { get; set; }
        public string tr_name { get; set; }
        public DateTime? due_date { get; set; }
        public decimal? upper_range { get; set; }
        public decimal? lower_range { get; set; }
        public string range_unit { get; set; }
        public string upper_range_unit { get; set; }
        public string lower_range_unit { get; set; }
        public string accuracy_up_unit { get; set; }
        public string resolution_unit { get; set; }
        public string least_count_unit { get; set; }
        public decimal? accuracy_down { get; set; }
        public string accuracy_down_unit { get; set; }
    }
    public class QMS_M004_P
    {
        public int id { get; set; }
        public string ItemScope { get; set; }
        public string scope_desc { get; set; }
    }
    public class ADM_M003_B_P
    {
        public int lab_id { get; set; }
        public string lab_code { get; set; }
        public string lab_name { get; set; }

    }
    public class QMS_M001Flip
    {
        public int id { get; set; }
        public string grcode { get; set; }
        public string grname { get; set; }
        public string grdesc { get; set; }

    }
    public class QMS_M013_P
    {
        public string insp_type { get; set; }
        public string insp_type_name { get; set; }
    }
    public class QMS_M001_P
    {
        public string grcode { get; set; }
        public string grname { get; set; }
    }
    public class QMS_M002Flip
    {
        public int id { get; set; }
        public string sgrcode { get; set; }
        public string sgrname { get; set; }
        public string sgrdesc { get; set; }
        public string grcode { get; set; }
        public string grname { get; set; }
    }
    public class QMS_M003Flip
    {
        public int id { get; set; }
        public string inst_code { get; set; }
        public string inst_name { get; set; }
        public string t_status { get; set; }
        public string lab_name { get; set; }
        public string CatName { get; set; }
        public string SubCatName { get; set; }
        public string rig_name { get; set; }
        public string PartyNm { get; set; }
        public string EmpName { get; set; }
        public string barcode { get; set; }
        public string inst_srno { get; set; }
    }
    public class QMS_M008_P
    {
        public int id { get; set; }
        public string rig_code { get; set; }
        public string rig_abbr { get; set; }
        public string rig_name { get; set; }
    }
    public class QMS_M009Flip
    {
        public string test_code { get; set; }
        public string test_name { get; set; }
        public string insp_type { get; set; }
        public string insp_type_name { get; set; }
        public string test_desc { get; set; }
    }
    public class QMS_T001Flip
    {
        public string doc_no { get; set; }
        public DateTime doc_date { get; set; }
        public string inst_name { get; set; }
        public string test_code { get; set; }
        public string test_name { get; set; }
        public string EmpNm { get; set; }
        public string cal_cat { get; set; }
        public string PartyNm { get; set; }
        public string t_status { get; set; }
    }
    public class QMS_M006_P
    {
        public string tp_code { get; set; }
        public string tp_desc { get; set; }
    }
    public class QMS_M007_P
    {
        public string wi_code { get; set; }
        public string wi_desc { get; set; }
    }
    public class QMS_M024Flip
    {
        public string tl_code { get; set; }
        public string tl_type { get; set; }
        public string short_text { get; set; }
        public string long_text { get; set; }
    }
    public class QMS_M011
    {
        public string formula_code { get; set; }
        public string formula_desc { get; set; }
        public byte[] image1 { get; set; }
        public byte[] image2 { get; set; }
        public byte[] image3 { get; set; }
    }
    public class QMS_M017
    {
        public string env_code { get; set; }
        public string env_name { get; set; }
    }
    public class QMS_M016
    {
        public int id { get; set; }
        public decimal? conf_level { get; set; }
        public decimal? alpha { get; set; }
        public decimal? eff_dof { get; set; }
        public decimal? cov_factor { get; set; }
        public bool infinity_ind { get; set; }
        public bool active { get; set; }
    }
    public class QMS_M010_P
    {
        public string tr_code { get; set; }
        public string tr_name { get; set; }
    }
    public class QMS_M012_P
    {
        public string insp_code { get; set; }
        public string insp_name { get; set; }
        public string insp_id { get; set; }
        public string insp_desc { get; set; }
        public string clause { get; set; }
    }
    public class Inst_Pur_Details_P
    {
        public string po_no { get; set; }
        public DateTime po_date { get; set; }
        public string req_no { get; set; }
        public DateTime date_start { get; set; }
        public string doc_no { get; set; }
        public DateTime doc_date { get; set; }
    }
    public class ZADM_M010_P
    {
        public int prod_id { get; set; }
        public string prodnm { get; set; }
        public string ItemCode { get; set; }
        public string tip_type { get; set; }
        public string blank { get; set; }

    }
    public class ZSCM_T001_B_P
    {
        public int average_wt_id { get; set; }
        public decimal? avg_blank_wt { get; set; }
        public int blank_len { get; set; }
    }
    public class CRM_M001_P
    {
        public string tc_code { get; set; }
        public int sequence_code { get; set; }
        public int sequence1 { get; set; }
        public int sequence2 { get; set; }
        public int sequence3 { get; set; }
        public string short_text { get; set; }
        public string long_text { get; set; }
        public string con_type { get; set; }
        public string con_desc { get; set; }

    }

    public class ZADM_M023_P
    {
        public string cat_code { get; set; }
        public string cat_desc { get; set; }
    }

    public class ZADM_M024_P
    {
        public string sub_cat_code { get; set; }
        public string sub_cat_desc { get; set; }
    }
    public class ZCRM_T004_AFlip
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public DateTime doc_date { get; set; }
        public string tender_no { get; set; }
        public string tender_name { get; set; }
        public string tender_doc_cat { get; set; }
        public string tender_doc_type { get; set; }
        public string PartyId { get; set; }

    }
    public class MM_M008_P
    {
        public string tc_code { get; set; }
        public int sequence_code { get; set; }
        public int sequence1 { get; set; }
        public int sequence2 { get; set; }
        public int sequence3 { get; set; }
        public string short_text { get; set; }
        public string long_text { get; set; }
        public string con_type { get; set; }
        public string con_desc { get; set; }

    }
    public class SYS_M001_P //Document Category
    {
        [DisplayName("Document Category")]
        public string doc_cat { get; set; }
        public string dcat_name { get; set; }
    }

    public class SYS_M010_P //Document Category
    {
        [DisplayName("Document Category")]
        public string doc_cat { get; set; }
        public string dcat_name { get; set; }
    }

    public class SYS_M014_P //Document Category
    {
        public string doc_cat { get; set; }
        public string dcat_name { get; set; }
        public string TranCode { get; set; }
    }

    public class EPR_T003_A_P
    {
        public string doc_no { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string batch_no { get; set; }
        public string ItemCode { get; set; }
        public string grade { get; set; }
        public int? ink_id { get; set; }
        public int? ild_id { get; set; }
        public decimal? tot_qty { get; set; }
        public string unit_code { get; set; }
        public decimal? net_wt { get; set; }
        public decimal? gross_wt { get; set; }
        public int? no_kind_pack { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string barcode { get; set; }
        public string ItemName { get; set; }
        public string Ink { get; set; }
        public string Ild { get; set; }
        public string sku { get; set; }
        public Nullable<bool> carton_used_Flg { get; set; }
    }

    public class EPR_T004_A_P
    {
        public string plan_no { get; set; }
        public Nullable<System.DateTime> plan_date { get; set; }
        public string machine_no { get; set; }
        public Nullable<int> machine_id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string para1 { get; set; }
        public string para5 { get; set; }
        public string sales_order_no { get; set; }
        public Nullable<int> Srno { get; set; }
        public string unit_code { get; set; }
        public decimal? plan_qty { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string para6 { get; set; }
        public string para7 { get; set; }
        public string para8 { get; set; }
        public string para9 { get; set; }
        public string para10 { get; set; }

        // adding new field

        public bool lifeTest { get; set; }
        public bool TestDone { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public decimal? order_qty { get; set; }
        public string pre_order_no { get; set; }

    }

    public class PPC_T004_A_P    //table name EPR_T004 Changed as PPC_T004 so the detail table names also
    {
        public string plan_no { get; set; }
        public Nullable<System.DateTime> plan_date { get; set; }
        public string machine_no { get; set; }

        public Nullable<int> machine_id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }

        public string para1 { get; set; }
        public string para5 { get; set; }
        public string sales_order_no { get; set; }
        public Nullable<int> Srno { get; set; }
        public string unit_code { get; set; }
        public decimal? plan_qty { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string para6 { get; set; }
        public string para7 { get; set; }
        public string para8 { get; set; }
        public string para9 { get; set; }
        public string para10 { get; set; }

        // adding new Field
        public bool lifeTest { get; set; }
        public bool TestDone { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public decimal? order_qty { get; set; }
        public string order_no { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string wc_code { get; set; }
        public Nullable<int> ink_id { get; set; }
        public Nullable<int> wire_make_id { get; set; }
        public Nullable<int> ild_id { get; set; }
        public Nullable<int> ball_make_id { get; set; }
        public Nullable<int> ball_type_id { get; set; }
        public Nullable<int> wire_size_id { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string total_len { get; set; }
        public Nullable<int> plan_item_row_id { get; set; }
        public string pre_order_no { get; set; }

    }
    public class ADM_M043_D_P
    {
        public string ref_doc_cat { get; set; }
        public string doc_desc { get; set; }
    }
    public class ADM_M043_P
    {
        public string workflow_id { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public int level_no { get; set; }
        public string approver_id { get; set; }
        public string UserId { get; set; }
        public string authority { get; set; }
        public string ApproverName { get; set; }
        public string ApproverEmailId { get; set; }
    }
    public class TSK_T001_C_P
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string doc_cat { get; set; }

    }
    public class ADM_M045_P
    {
        public string grade_code { get; set; }
        public string grade_name { get; set; }

    }
    public class ZADM_M017_P
    {
        public int id { get; set; }
        public string unit_code { get; set; }
        public string pkgunit { get; set; }
        public float pkgqty { get; set; }
    }
    public class ZADM_M020_P
    {
        public int id { get; set; }
        public string CustomerProductName { get; set; }
        public string ProductName { get; set; }
    }



    public class SYS_M007_P //Document Type (po/quat)
    {
        public string doc_type { get; set; }
        public string doc_type_user { get; set; }
        public string doc_desc { get; set; }
        public string doc_cat { get; set; }
        public string display_doc_type { get; set; }
    }
    public class ADM_M065_P
    {
        public string test_id { get; set; }
        public string test_name { get; set; }
    }
    public class ECRM_T002_B_P
    {
        public int defect_id { get; set; }
        public string defect_description { get; set; }
    }
    public class ZADM_M009_P
    {
        public int model_id { get; set; }
        public string modelno { get; set; }
        public string basicmodel { get; set; }
        public string modeldesc { get; set; }
    }
    public class ZADM_M004_P
    {
        public int wire_type_id { get; set; }
        public string wire_type { get; set; }
    }
    public class ZADM_M026Flip
    {
        public int id { get; set; }
        public string supplier_id { get; set; }
        public string SupplierNm { get; set; }
        public string customer_id { get; set; }
        public string CustomerNm { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public string ink_code { get; set; }
        public Nullable<decimal> price { get; set; }
        public string t_status { get; set; }
    }
    public class ZADM_M003_P
    {
        public int wire_size_id { get; set; }
        public decimal wire_size { get; set; }
        private bool _Select;//scaler
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;
                }
            }
        }
    }
    public class ZADM_M001_P
    {
        public int ball_dia_id { get; set; }
        public decimal Ball_dia { get; set; }
        public decimal ball_dia { get; set; }

    }
    public class ZADM_M002_P
    {
        public int ball_type_id { get; set; }
        public string ball_type { get; set; }
    }
    public class ZADM_M008_P
    {
        public int tot_len_id { get; set; }
        public string total_len { get; set; }
        public string details { get; set; }
    }

    public class CRM_T002AFlip
    {
        public string supp_cat_code { get; set; }
        public Nullable<System.DateTime> cat_date { get; set; }
        public string PartyId { get; set; }
        public Nullable<System.DateTime> from_date { get; set; }
        public Nullable<System.DateTime> to_date { get; set; }
        public string remark { get; set; }
        public string location_Id { get; set; }
        public string fin_year { get; set; }
        public Nullable<bool> active { get; set; }
        public string comp_code { get; set; }
        public string description { get; set; }
        public string so_code { get; set; }
        public string po_code { get; set; }
        public string party_name { get; set; }

    }
    public class ADM_M004_P
    {
        public string activity_code { get; set; }
        public string activtNm { get; set; }
    }
    public class ADM_M003_C_P   //Business Place Master
    {
        public string buss_place { get; set; }
        public string plc_name { get; set; }
        public string bisness_state_code { get; set; }
        public string state_tax_code { get; set; }
    }
    public class ACC_M014_P
    {
        public int id { get; set; }
        public string t_code { get; set; }
        public string t_name { get; set; }
    }
    public class ACC_M013_A_P   //Tax classification / Type of customers
    {
        public string tax_cat_code { get; set; }
        public string tax_indicator { get; set; }
        public string tax_indicator_desc { get; set; }
    }
    public class ACC_M013_B_P   //Goods Movement Account Group
    {
        public string tax_acc_group { get; set; }
        public string tax_acc_group_name { get; set; }
    }
    public class ADM_M009_P
    {
        public string RoleCode { get; set; }
        public string RoleName { get; set; }

    }
    public class ADM_M001_PG
    {
        public string group_code { get; set; }
        public string GrpName { get; set; }
        public string pg_code { get; set; }
        public string pg_name { get; set; }
        public string client { get; set; }
    }
    public class MM_S003_P //Batch 
    {
        public string batch_no { get; set; }
        public string ItemCode { get; set; }
        public string unit_code { get; set; }
        public string sku { get; set; }
        public string item_Name { get; set; }
        public string store_code { get; set; }
        public Nullable<bool> stockunt { get; set; }
        public decimal? packetWt { get; set; }
        public decimal? stock_total { get; set; }
        public bool? Select { get; set; }
        public string location_id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string pack_no { get; set; }
        public string batch_no_pack { get; set; }
        public decimal? pack_qty { get; set; }
        public string barcode { get; set; }
        public decimal? batch_qty { get; set; }
        public decimal? stock_unr { get; set; }
        public string stock_unit { get; set; }
        public decimal? net_wt { get; set; }
        public decimal? gross_wt { get; set; }
        public string weight_unit { get; set; }
        public decimal? volume { get; set; }
        public string volume_unit { get; set; }

    }


    public class ECRM_T002_A_P //Quality Feedback
    {
        public int id { get; set; }
        public string quality_feedback_no { get; set; }
    }
    public class ADM_M0032_P //Make Master
    {
        public int MakeCode { get; set; }
        public string Make { get; set; }
    }

    public class MM_T003_P
    {
        public Nullable<int> id { get; set; }
        public string req_no { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string dept_code { get; set; }
        public string Dept_Name { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string sku { get; set; }
        public string unit_code { get; set; }
        public decimal qty { get; set; }
        public string SubCatCode { get; set; }
        public Nullable<bool> StockUnt { get; set; }
        public string req_ref { get; set; }
        public string location { get; set; }
        public string store_loc { get; set; }
        public string t_status { get; set; }
        public DateTime? date_start { get; set; }
        public string PendingAck { get; set; }
    }



    public class MM_M004_P
    {
        public string mov_name { get; set; }
        public string mov_tp { get; set; }
        public string mov_tp_name { get; set; }
        public string doc_type { get; set; }
        public string debit_credit { get; set; }

    }
    public class ADM_M028_D_P
    {
        public int SrNo { get; set; }
        public string ContInfoId { get; set; }
        public string PartyId { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string AddType { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string PersonName { get; set; }
        public string PersnEmailId { get; set; }
        public string PersnMobNo { get; set; }
        public string group1 { get; set; }
        public string acc_group { get; set; }
        public string assign_party { get; set; }


    }
    public class ECRM_T003_A_P //Writing Test 
    {
        public string prdct_code { get; set; }
        public string shift { get; set; }
        public string ink { get; set; }
        public string ItemName { get; set; }
        public string item_code { get; set; }

        public System.DateTime prddt { get; set; }
    }
    public partial class ECRM_T003_B_P//Wrting TestDetails
    {
        public int id { get; set; }
        public Nullable<int> wtid { get; set; }
        public string refilno { get; set; }
        public int tm { get; set; }
    }
    public class EPR_T001_P //Conv Lot From ILDChart 
    {
        public Nullable<int> id { get; set; }
        public string machinecode { get; set; }
        public Nullable<int> Conv_lot { get; set; }
        public string Status { get; set; }
        public Nullable<int> model_id { get; set; }
        public string modelno { get; set; }// old field model_no
        public string ItemCode { get; set; }//old field item_code
        public Nullable<int> party_id { get; set; }
        public string PartyNm { get; set; }
        public string shift { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public System.DateTime start_dt { get; set; }
        public System.DateTime end_dt { get; set; }
        public System.DateTime pro_dt { get; set; }
        public decimal? min_val { get; set; }
        public decimal? max_val { get; set; }
        public string shank_len { get; set; }
        public Nullable<decimal> shank_dia { get; set; }
        public string needle_dia { get; set; }
        public string needle { get; set; }
        public string total_len { get; set; }
        public Nullable<decimal> amnild { get; set; }
        public Nullable<decimal> amxild { get; set; }
        public Nullable<decimal> aavild { get; set; }
        public int machine_id { get; set; }
        public string machinedesc { get; set; }
        public string machine_type { get; set; }
        public string ItemName { get; set; }
        public int conv { get; set; }
        public string Unit_Code { get; set; }
        public string order_no { get; set; }
        public string ball_dia { get; set; }
        public string ball_make { get; set; }
        public string wire_make { get; set; }
        public string ball_type { get; set; }
        public string prod_plan { get; set; }
        public Nullable<decimal> wire_size { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string wc_code { get; set; }
    }
    public class SEL_T001_P //Reference doc no's
    {
        public int? id { get; set; }
        public string sono { get; set; }
        public System.DateTime? sodate { get; set; }
        public string EmpId { get; set; }
        public string EmpNm { get; set; }
        public string buyer { get; set; }
        public string buyer_name { get; set; }
        public string cust_ref { get; set; }
        public string Description { get; set; }
        public string doc_type_id { get; set; }
        public bool? Select { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public decimal? quantity { get; set; }
        public decimal? bal_qty { get; set; }
        public decimal? acc_qty { get; set; }
        public System.DateTime? ref_doc_date { get; set; }
        public string reference { get; set; }
        public string local_export { get; set; }
        public string t_status { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public string para3 { get; set; }
        public string location { get; set; }
        public string project_location { get; set; }
        public decimal? roundup_total { get; set; }
        public string address { get; set; }
        public string note { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string doc_no { get; set; }
        public string ref_doc_no { get; set; }
        public string t_display { get; set; }
        public string color_code { get; set; }
        public string cust_ref_date { get; set; }
        public string ship_to_party { get; set; }
        public string ship_to_party_name { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public string curr_code { get; set; }
        public int? del_address { get; set; }
        public string incoterms { get; set; }
        public string incoterms2 { get; set; }
        public string country_code { get; set; }
        public System.DateTime? expect_date { get; set; }
        public string unit_code { get; set; }
        public System.DateTime? date_planned { get; set; }
        public string location_Id { get; set; }
        public decimal? sch_qty { get; set; }
        public string p_term_code { get; set; }
        public int? line_id { get; set; }
        public decimal? unit_price { get; set; }
        public decimal? qty_price { get; set; }
        public decimal? price_qty { get; set; }
        public string price_qty_uom { get; set; }
        public string ref_doc_type { get; set; }
        public string ref_doc_cat { get; set; }
        public string tr_mode { get; set; }
        public string tr_type { get; set; }
        public string tr_party { get; set; }
        public string cp_no { get; set; }
        public string cp_mail { get; set; }
        public string add_code_del { get; set; }
        public string cp_code { get; set; }
        public string cp_name { get; set; }

    }
    public class SEL_T002_P//referance no 
    {
        public string sch_no { get; set; }
        public DateTime sch_date { get; set; }
        public string ItemCode { get; set; }

    }
    public class SEL_T002_Req_P //Requirement Details grid
    {
        public string sch_no { get; set; }
        public Nullable<Decimal> sch_qty { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public Nullable<Decimal> Rec_sch_qty { get; set; }
        public Nullable<Decimal> sch_open_qty { get; set; }
        public Nullable<System.DateTime> sch_date { get; set; }
    }
    public class SEL_T001_schedule_P // so popup for schedule
    {
        public string sono { get; set; }
        public Nullable<System.DateTime> sodate { get; set; }
        public string doc_type_user { get; set; }
        public string cust_ref { get; set; }
        public Nullable<System.DateTime> cust_ref_date { get; set; }
        public decimal quantity { get; set; }
        public string ItemCode { get; set; }
        public Nullable<Decimal> Schedule_Qty { get; set; }
        public Nullable<Decimal> Bal_Schedule_Qty { get; set; }
        public Nullable<Decimal> Bal_Schedule_Confirm { get; set; }
        public Nullable<Decimal> Despatch_qty { get; set; }
    }
    public class ZADM_M007_P //ILD Master
    {
        public int ild_id { get; set; }
        public string ild { get; set; }
        public string tip_type { get; set; }
        public string desc { get; set; }
        public string show_ild { get; set; }
        public string ild_type { get; set; }
    }
    public class ZADM_M006_P //INK Master
    {
        public int ink_id { get; set; }
        public string ink { get; set; }
        public string desc { get; set; }
        public string make { get; set; }
    }
    public class ECRM_T003_AFlip
    {

        public string wtno { get; set; }
        public string machinecode { get; set; }
        public DateTime wtdt { get; set; }
        public string lotno { get; set; }
        public string shift { get; set; }
        public DateTime prddt { get; set; }
        public string itemname { get; set; }
        public string ItemCode { get; set; }
        public string t_display { get; set; }
    }
    public class EPR_T001_Flip
    {
        public int? id { get; set; }
        public string order_no { get; set; }
        public int? conv { get; set; }
        public DateTime start_dt { get; set; }
        public string machinecode { get; set; }
        public string Conv_lot { get; set; }
        public string model_code { get; set; }
        public string status { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int? machine_id { get; set; }
        public string pre_order_no { get; set; }
        public string prod_plan { get; set; }
    }

    public class ECRM_T001_A_P
    {
        public string sa_no { get; set; }
    }
    public class ADM_M032_P
    {
        public int MakeCode { get; set; }
        public string Make { get; set; }
        public string make { get; set; }
        public string make_type { get; set; }
    }

    public class ADM_M032_P1
    {
        public int MakeCode { get; set; }
        public string Make { get; set; }
        public string make { get; set; }
        public string make_type { get; set; }
    }

    public class ADM_M022_P_ESSEM
    {
        public int SrNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string shanklen { get; set; }
        public string needledia { get; set; }
        public string needlelen { get; set; }
        public string tip_type { get; set; }
        public string prdct_code { get; set; }
        public int Model_id { get; set; }
        public string ModelCode { get; set; }
        public string wire_material { get; set; }
        public string wire_dia { get; set; }
        public string grade { get; set; }
        public Nullable<Decimal> ball_dia { get; set; }
        public string ball_type { get; set; }
        public string order_no { get; set; }
        public string routing_no { get; set; }

        //adding new field

        public bool lifeTest { get; set; }
        public bool TestDone { get; set; }
    }
    public class ZADM_M013_P_machine_type
    {
        public string mctype { get; set; }
    }


    public class ADM_M030_P
    {
        public string value_code { get; set; }
        public string para_code { get; set; }
        public string parametervalue { get; set; }
        public string unit_code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public Nullable<int> _selectedindex;
        public Nullable<int> selectedindex
        {
            get { return _selectedindex; }
            set { _selectedindex = value; }
        }
        public string _selectedValue;
        public string selectedValue
        {
            get { return _selectedValue; }
            set { _selectedValue = value; }
        }
        public string code { get; set; }
        public string grade_code { get; set; }
        public string grade_name { get; set; }
    }
    //Added by Priya For Financial Year and Posting Period 
    public class ACC_M001A_P
    {
        public string posting_period { get; set; }
        public string fin_year { get; set; }
        public string short_desc { get; set; }
        public int post_year { get; set; }
        public int calender_year { get; set; }
        public int post_per { get; set; }
        public int post_mon { get; set; }
        public string long_desc { get; set; }
        public string qtr { get; set; }
    }
    public class ADM_M031_P
    {
        public string para_code { get; set; }
        public string para_name { get; set; }
        public string SubCatCode { get; set; }
        public string parametervalue { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string ItemCode { get; set; }
        public int count { get; set; }
        public int code { get; set; }
        public string sku { get; set; }
        public string stockunit { get; set; }
        public string value_code { get; set; }
        public Nullable<int> dgselectedindex { get; set; }
    }
    public class SYS_M003_P//Item Category
    {
        public string sditem_cat_code { get; set; }
        public string item_cat_desc { get; set; }
        public string relevent_billing { get; set; }
        public string relevent_delivery { get; set; }
    }
    public class MM_M001_P
    {
        public string store_code { get; set; }
        public string location_Id { get; set; }
        public string store_name { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
    }
    public class ADM_M001_I_P//---Sales Office
    {
        public string soff_code { get; set; }
        public string sales_off { get; set; }
    }
    public class ADM_M001_H_P//---Sales Group
    {
        public string sg_code { get; set; }
        public string sg_name { get; set; }
        public string so_code { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string LoctnNm { get; set; }
    }
    public class ADM_M001_A_P//Sale Organisation
    {
        public string so_code { get; set; }
        public string sales_org { get; set; }
        public string comp_code { get; set; }
        public string org_type { get; set; }
    }
    public class ORG_Data
    {
        public string org_code { get; set; }
        public string org_name { get; set; }
        public string comp_code { get; set; }
        public string org_type { get; set; }
    }
    public class ADM_M001_C_P//--Distribution Channel
    {
        public string dc_code { get; set; }
        public string dc_name { get; set; }
    }
    public class ADM_M001_D_P//---Sales Division
    {
        public string div_code { get; set; }
        public string div_name { get; set; }
    }
    public class SYS_M002_P //Document Type
    {
        public string doc_type_user { get; set; }
        public string doc_type { get; set; }
        public string doc_type_doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_desc_user { get; set; }
        public string report_name { get; set; }
        public string doc_desc { get; set; }

    }

    public class SYS_M015_P//doc Type
    {
        public string doc_type { get; set; }
        public string doc_desc { get; set; }
    }

    public class SYS_M005_P// Delivery Type
    {
        public string delivery_type { get; set; }
        public string del_desc { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string stock_ind { get; set; }
    }
    public class ESO_T001_P
    {
        public DateTime prod_dt { get; set; }
        public string machinecode { get; set; }
    }
    public class ZADM_M016_P
    {
        public int dfctcda { get; set; }
        public int dftcdu { get; set; }
        public string dfctdsc { get; set; }
        public string scope { get; set; }
        internal bool _Select { get; set; }
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;
                }
            }
        }
        public string defect_type { get; set; }
    }
    public class ZADM_M013_P
    {
        public int machine_id { get; set; }
        public string machinecode { get; set; }
        public string wc_code { get; set; }
        public decimal machineorder { get; set; }
        public string machinedesc { get; set; }
        public string machinesrno { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string mctype { get; set; }
        public string engineer { get; set; }
        public bool Sorting { get; set; }
        internal bool _yes { get; set; }
        public bool yes
        {
            get { return _yes; }
            set
            {
                if (_yes != value)
                {
                    _yes = value;
                }
            }
        }
        public bool Select { get; set; }
    }

    public class ENG_T001_A_P
    {
        public string doc_no { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string unit_code { get; set; }
    }

    public class SYS_M011_P
    {
        public string doc_type { get; set; }
        public string doc_type_user { get; set; }
        public string doc_desc_user { get; set; }
    }
    public class ADM_M026_P
    {
        public string desig_code { get; set; }
        public string DesigName { get; set; }


    }
    public class ADM_M025_P
    {
        public string dept_code { get; set; }
        public string DeptName { get; set; }
        public string dept_name { get; set; }
    }


    public class ADM_M012_P
    {
        public string CntryName { get; set; }
        public string country_code { get; set; }

    }


    public class ADM_M013_P
    {
        public string state_code { get; set; }
        public string country_code { get; set; }
        public string StatName { get; set; }

    }

    public class ADM_M051_P
    {
        public string nation_code { get; set; }
        public string nation_desc { get; set; }
        public string country_code { get; set; }

    }
    public class ADM_M028_A_P
    {
        public string group1 { get; set; }

        public string grpNm { get; set; }

    }
    public class ADM_M028_B_P
    {
        public string PartyType { get; set; }
        public string PartyType_Nm { get; set; }
    }

    public class ADM_M007_P
    {
        public int UserTypCode { get; set; }
        public string UserTyp { get; set; }
    }
    public class ADM_M008B_P
    {
        public string TranCode { get; set; }
        public string TranName { get; set; }
        internal bool _Select { get; set; }
        public bool Select { get; set; }
    }
    public class ADM_M005_P
    {
        public int AuthFldCod { get; set; }
        public string AuthFldNm { get; set; }
    }
    public class ADM_M022_P //item
    {
        public int? SrNo { get; set; }
        [DisplayName("Item Code")]
        public string ItemCode { get; set; }
        [DisplayName("Item Name")]
        public string ItemName { get; set; }
        public string CatCode { get; set; }
        public string unit_code { get; set; }
        [DisplayName("Unit Name")]
        public string unit_name { get; set; }
        [DisplayName("CustItemCode")]
        public string CustItemCode { get; set; }
        [DisplayName("CustItemName")]
        public string CustItemName { get; set; }
        public string SubCatName { get; set; }
        public string CatName { get; set; }
        public string SubCatCode { get; set; }
        public Nullable<bool> StockUnt { get; set; }
        public Nullable<decimal> qty { get; set; }
        internal bool _Select { get; set; }
        [DisplayName("")]
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;
                }
            }
        }
        public Nullable<bool> RinReq { get; set; }
        public string stockingunit { get; set; }
        public string sku_desc { get; set; }
        public string SubItenTpCd { get; set; }
        public string sku { get; set; }
        public Nullable<decimal> MinQty { get; set; }
        public Nullable<decimal> MaxQty { get; set; }
        public Nullable<decimal> Reorder { get; set; }
        public Nullable<decimal> stock_total { get; set; }
        public Nullable<decimal> stock_reserve { get; set; }
        public Nullable<decimal> stock_unr { get; set; }
        public Nullable<decimal> stock_in_transit { get; set; }
        public string para_code { get; set; }
        public string weight_unit { get; set; }
        public decimal? unit_price { get; set; }
        public decimal? net_value { get; set; }
        public string order_no { get; set; }
        public string Make { get; set; }
        public string Type { get; set; }
        public string mat_cond { get; set; }
        public int ild_id { get; set; }
        public int ink_id { get; set; }
        public int model_id { get; set; }
        public string ild { get; set; }
        public string ink { get; set; }
        public string grade { get; set; }
        public Nullable<decimal> rate { get; set; }
        public int wire_type_id { get; set; }
        public string wire_type { get; set; }
        public string textdata { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_type { get; set; }
        public string ref_doc_cat { get; set; }
        public Nullable<System.DateTime> ref_doc_date { get; set; }
        public Nullable<int> so_item_id { get; set; }

        public string sono { get; set; }
        public int so_item_line_id { get; set; }
        public int so_item_row_id { get; set; }
        public string ref_doc { get; set; }
        public int ref_item_line_id { get; set; }
        public int ref_item_row_id { get; set; }
        public string cust_ref { get; set; }
        public DateTime? cust_ref_date { get; set; }
        public int line_id { get; set; }
        public string source { get; set; } // Image source of item
        //public int? SrNo { get; set; }
        //public string ItemCode { get; set; }
        //public string ItemName { get; set; }
        //public string CatCode { get; set; }
        //public string unit_code { get; set; }
        //public string unit_name { get; set; }
        //public string CustItemCode { get; set; }
        //public string CustItemName { get; set; }
        //public string SubCatName { get; set; }
        //public string CatName { get; set; }
        //public string SubCatCode { get; set; }
        //public Nullable<bool> StockUnt { get; set; }
        //public Nullable<decimal> qty { get; set; }
        //internal bool _Select { get; set; }
        //public bool Select
        //{
        //    get { return _Select; }
        //    set
        //    {
        //        if (_Select != value)
        //        {
        //            _Select = value;


        //        }
        //    }
        //}
        //public Nullable<bool> RinReq { get; set; }
        //public string stockingunit { get; set; }
        //public string sku_desc { get; set; }
        //public string SubItenTpCd { get; set; }
        //public string sku { get; set; }
        //public Nullable<decimal> MinQty { get; set; }
        //public Nullable<decimal> MaxQty { get; set; }
        //public Nullable<decimal> Reorder { get; set; }
        //public Nullable<decimal> stock_total { get; set; }
        //public Nullable<decimal> stock_reserve { get; set; }
        //public Nullable<decimal> stock_unr { get; set; }
        //public Nullable<decimal> stock_in_transit { get; set; }
        //public string para_code { get; set; }
        //public string weight_unit { get; set; }
        //public decimal? unit_price { get; set; }
        //public decimal? net_value { get; set; }
        //public string order_no { get; set; }
        //public string Make { get; set; }
        //public string Type { get; set; }
        //public string mat_cond { get; set; }
    }
    public class ADM_M022_P1
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string unit_code { get; set; }
        public string CatCode { get; set; }
        public bool? StockUnt { get; set; }
        public string SubCatCode { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string Grade { get; set; }
    }

    public class ADM_M040_P
    {
        public int id { get; set; }
        public string priority_code { get; set; }
        public string priority { get; set; }
        public string pr_code { get; set; }
        public string text_name { get; set; }

    }
    public class ADM_M038_A_P
    {
        public int id { get; set; }
        public string class_name { get; set; }
        public string base_unit { get; set; }

    }
    public class ADM_M042_P    // Shift Master
    {
        public string shift { get; set; }
        public string shift_name { get; set; }
        public string shift_hrs { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
    }
    public class ADM_M050_P    // Salutaion Master
    {
        public string sal_code { get; set; }
        public string sal_desc { get; set; }
    }
    public class ADM_M024_POP
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string driver_id { get; set; }
    }
    public class ADM_M024_P
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpLName { get; set; }
        public string EmpFName { get; set; }
        public string EmpMName { get; set; }
        public string UserId { get; set; }
        public string EmpEmailId { get; set; }
        public string EmpMobNo { get; set; }
        public string EmpPhNo { get; set; }
        public string EmpPhExt { get; set; }
        public string EmpFaxNo { get; set; }
        public byte[] Photo { get; set; }
        public bool? select { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string Status_Of_Visit { get; set; }
        public string desig_code { get; set; }
        public string curr_code { get; set; }
        public string dept_code { get; set; }
        public string emp_type { get; set; }
        // Scalar
        public string DeptName { get; set; }
        public string DesigName { get; set; }
        public string LoctnNm { get; set; }
        public string CompName { get; set; }
        public string empl_type_name { get; set; }
        public string EmpPermtAdd { get; set; }
        public string EmpTempAdd { get; set; }
        private bool? _Select;//scaler
        public bool? Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;
                }
            }
        }

        //Added by Karishma

        public string sal_code { get; set; }
        public string alias_name { get; set; }
        public Nullable<System.DateTime> emp_dob { get; set; }
        public string emp_pob { get; set; }
        public string emp_cob { get; set; }
        public string reli_code { get; set; }
        public string cast_code { get; set; }
        public string cat_code { get; set; }
        public string gender { get; set; }
        public string blood_group { get; set; }
        public Nullable<System.DateTime> emp_dom { get; set; }
        public string marital_status { get; set; }
        public string nation_code { get; set; }
        public string nation_code1 { get; set; }
        public string phy_dis { get; set; }
        public string height_val { get; set; }
        public string height_unit { get; set; }
        public string weight_val { get; set; }
        public string weight_unit { get; set; }
        public Nullable<System.DateTime> join_date { get; set; }
        public string applicant_id { get; set; }
        public string t_status { get; set; }
        public string remark { get; set; }

    }
    public class ADM_M003_P
    {
        public string location_Id { get; set; }
        public string LoctnNm { get; set; }
        public string comp_code { get; set; }
        public string comp_name { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpEmailId { get; set; }
        public string store_code { get; set; }



    }
    public class ADM_M018_P
    {
        public string CatName { get; set; }
        public string CatCode { get; set; }
    }

    public class ADM_M019_P
    {
        public string SubCatName { get; set; }
        public string SubCatCode { get; set; }
        public string CatCode { get; set; }

    }
    public class ADM_M015_P
    {
        public string ItemTypeNm { get; set; }
        public string ItemTypeCd { get; set; }
        public string SubCatCode { get; set; }


    }
    public class ADM_M016_P
    {
        public string SubItemTpNm { get; set; }
        public string ItemTypeCd { get; set; }
        public string SubItemTpCd { get; set; }


    }
    public class ADM_M020_P
    {
        public int id { get; set; }
        public string ProdNm { get; set; }
        public string ProdNmCd { get; set; }
        public string hs_code { get; set; }
    }
    public class ADM_M014_P
    {
        public string CommName { get; set; }
        public string CommCode { get; set; }
    }
    public class ADM_M021_P
    {
        public string MateName { get; set; }
        public string MateCode { get; set; }
    }
    public class ADM_M017_P
    {
        public string AssetNm { get; set; }
        public string AssetCode { get; set; }
    }
    public class ADM_M023_P
    {
        public string RgName { get; set; }
        public string RgCode { get; set; }
    }
    public class PUR_T002_AFlip
    {
        public string po_no { get; set; }
        public Nullable<DateTime> po_date { get; set; }
        public string doc_type { get; set; }
        public string display_doc_type { get; set; }
        public string doc_desc { get; set; }
        public string ref_doc_no { get; set; }
        public Nullable<DateTime> valid_to_date { get; set; }
        public string buyer { get; set; }
        public string Buyer_Name { get; set; }
        public string po_code { get; set; }
        public string pur_org { get; set; }
        public string party_name { get; set; }
        public string t_status { get; set; }
        public string location_id { get; set; }
        public string comp_code { get; set; }
        public string supplying_plant { get; set; }
        public string rec_plant { get; set; }
        public string supplyingplant_name { get; set; }
        public string rec_plant_name { get; set; }
        public Nullable<DateTime> min_planned_date { get; set; }
        public string t_display { get; set; }
        public string supplier_ref { get; set; }
        public string PartyId { get; set; }
        public string pg_code { get; set; }
        public string revision_no { get; set; }
    }
    public class Item_PopUp_PO
    {
        public string ItemCode { get; set; }//ADM_M022
        public string ItemName { get; set; }//ADM_M022
        public string CatCode { get; set; }//CRM_T001B CstmrItmCod as 
        public string SubCategCod { get; set; }//ADM_M022
        public string unit_code { get; set; }
        public Nullable<bool> Stockble { get; set; }
        public string PartyId { get; set; }
        public string cstmr_itemcode { get; set; }
        public string cstmr_itemdescr { get; set; }
        public Nullable<decimal> b_rate { get; set; }
        public string stocking_unit { get; set; }
        public string tax_id { get; set; }
        public string Catlog_UOM { get; set; }
        public string sku_desc { get; set; }
        public Nullable<decimal> Req_QTY { get; set; }
        public Nullable<decimal> Req_Approve_qty { get; set; }
        public string Req_NO { get; set; }
        public string req_type { get; set; }
        public string item_cat_id { get; set; }
        public string req_ref { get; set; }
        public Nullable<decimal> Rate_Suggested { get; set; }
        public Nullable<decimal> Rate_Catlog { get; set; }

    }
    public class ZADM_M027Flip
    {
        public int id { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public DateTime? revised_date { get; set; }
        //scalar fields
        public string monthyear { get; set; }
    }

    public class PUR_T002_P_RefeDoc//Reference doc no's
    {
        public string po_no { get; set; }
        public Nullable<DateTime> po_date { get; set; }
        public string partyId { get; set; }
        public string party_name { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string supplier_ref { get; set; }
        public string po_code { get; set; }
        public string quotation_no { get; set; }
        public Nullable<DateTime> quotation_date { get; set; }
        public string display_doc_type { get; set; }
        public string doc_desc { get; set; }
        public string ItemCode { get; set; }
        public string req_no { get; set; }

        public string curr_code { get; set; }
        public string country_nm_s { get; set; }
        public string del_address { get; set; }
        public string p_term_code { get; set; }
        public string incoterms { get; set; }
        public string color_code { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }

    }
    public class ADM_M001_M_P //---Purchase Organisation
    {
        public string po_code { get; set; }
        public string pur_org { get; set; }
    }
    public class ADM_M001_P_P //---Purchase Group
    {
        public string pg_code { get; set; }
        public string pg_name { get; set; }
        public string po_code { get; set; }
        public string pur_org { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string LoctnNm { get; set; }
    }
    public class ACC_M019_P//---Cost Center
    {
        public string cost_center { get; set; }
        public string cost_center_Desc { get; set; }
    }
    public class ADM_M002_P
    {
        public string comp_code { get; set; }
        public string CompName { get; set; }
        public string CompAbbre { get; set; }
        public string country_code { get; set; }
    }
    public class SYS_M008_P//Item Category
    {
        public string item_cat { get; set; }
        public string cat_desc { get; set; }
        public string rel_billing { get; set; }
        public string rel_delivery { get; set; }
    }
    public class PUR_T002_P_PR_ItemsList//Item List for Popup Purchase Documents from Purchase Requisition.
    {
        public bool Select { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CatCode { get; set; }
        public string SubCatCode { get; set; }
        public string unit_code { get; set; }
        public Nullable<bool> Stockble { get; set; }
        public string PartyId { get; set; }
        public string cstmr_itemcode { get; set; }
        public string cstmr_itemdescr { get; set; }
        public Nullable<decimal> b_rate { get; set; }
        public string sku { get; set; }
        public string tax_id { get; set; }
        public string Catlog_UOM { get; set; }
        public string sku_desc { get; set; }
        public Nullable<decimal> Req_QTY { get; set; }
        public Nullable<decimal> Req_Approve_qty { get; set; }
        public string Req_NO { get; set; }
        public int Pur_Req_Item_id { get; set; }
        public string req_type { get; set; }
        public string item_cat_id { get; set; }
        public string req_ref { get; set; }
        public Nullable<decimal> Rate_Suggested { get; set; }
        public Nullable<decimal> Rate_Catlog { get; set; }
        public Nullable<decimal> MinQty { get; set; }
        public Nullable<decimal> MaxQty { get; set; }
        public Nullable<decimal> Reorder { get; set; }
        public Nullable<decimal> stock_total { get; set; }
        public Nullable<decimal> stock_reserve { get; set; }
        public Nullable<decimal> stock_unr { get; set; }
        public Nullable<decimal> stock_in_transit { get; set; }
        public string note { get; set; }
        public string bom_no { get; set; }

    }
    public class SEL_T001_P_SO_ItemsList//Item List for Popup Sales Documents.
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CatCode { get; set; }
        public string SubCatCode { get; set; }
        public string unit_code { get; set; }
        public Nullable<bool> StockUnt { get; set; }
        public string cstmr_itemcode { get; set; }
        public string cstmr_itemdescr { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public Nullable<decimal> rate { get; set; }
        public string sku { get; set; }
        public string tax_id { get; set; }
        public string Catlog_UOM { get; set; }
        public string sku_desc { get; set; }
        public string item_cat_id { get; set; }
        public Nullable<decimal> Rate_Suggested { get; set; }
        public Nullable<decimal> Rate_Catlog { get; set; }
        public Nullable<decimal> MinQty { get; set; }
        public Nullable<decimal> MaxQty { get; set; }
        public Nullable<decimal> Reorder { get; set; }
        public Nullable<decimal> stock_total { get; set; }
        public Nullable<decimal> stock_reserve { get; set; }
        public Nullable<decimal> stock_unr { get; set; }
        public Nullable<decimal> stock_in_transit { get; set; }
        public string needledia { get; set; }
        public string needleangle { get; set; }
        public string needlelen { get; set; }
        public Nullable<int> model_id { get; set; }
        public string modelno { get; set; }
        public Nullable<int> wire_type_id { get; set; }
        public string wire_type { get; set; }
        public Nullable<int> ball_dia_id { get; set; }
        public Nullable<decimal> ball_dia { get; set; }
        public Nullable<int> ball_type_id { get; set; }
        public string ball_type { get; set; }
        public string tip_type { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string tipshape { get; set; }
        public int wire_size_id { get; set; }
        public Nullable<decimal> wire_size { get; set; }
        public string total_len { get; set; }
        public Nullable<decimal> higher_limit { get; set; }
        public Nullable<decimal> lower_limit { get; set; }
        public string store_name { get; set; }
        public string plant_name { get; set; }
        public string comp_name { get; set; }
        public string weight_unit { get; set; }
        public string volume_unit { get; set; }
        public bool? ind_sku { get; set; }
    }
    public class CRM_T003_ItemsList//Item List for Popup Sales Documents.
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CatCode { get; set; }
        public string SubCatCode { get; set; }
        public string unit_code { get; set; }
        public Nullable<bool> StockUnt { get; set; }
        public string cstmr_itemcode { get; set; }
        public string cstmr_itemdescr { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public Nullable<decimal> rate { get; set; }
        public string sku { get; set; }
        public string tax_id { get; set; }
        public string Catlog_UOM { get; set; }
        public string sku_desc { get; set; }
        public string item_cat_id { get; set; }
        public Nullable<decimal> Rate_Suggested { get; set; }
        public Nullable<decimal> Rate_Catlog { get; set; }
        public Nullable<decimal> MinQty { get; set; }
        public Nullable<decimal> MaxQty { get; set; }
        public Nullable<decimal> Reorder { get; set; }
        public Nullable<decimal> stock_total { get; set; }
        public Nullable<decimal> stock_reserve { get; set; }
        public Nullable<decimal> stock_unr { get; set; }
        public Nullable<decimal> stock_in_transit { get; set; }
        public string needledia { get; set; }
        public string needleangle { get; set; }
        public string needlelen { get; set; }
        public Nullable<int> model_id { get; set; }
        public string modelno { get; set; }
        public Nullable<int> wire_type_id { get; set; }
        public string wire_type { get; set; }
        public Nullable<int> ball_dia_id { get; set; }
        public Nullable<decimal> ball_dia { get; set; }
        public Nullable<int> ball_type_id { get; set; }
        public string ball_type { get; set; }
        public string tip_type { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string tipshape { get; set; }
        public int wire_size_id { get; set; }
        public Nullable<decimal> wire_size { get; set; }
        public string total_len { get; set; }
        public Nullable<decimal> higher_limit { get; set; }
        public Nullable<decimal> lower_limit { get; set; }


    }
    public class ACC_M028_P // Special GL code List
    {
        public string acc_code { get; set; }

        public string acc_type { get; set; }
        public string ind_spl_gl { get; set; }
        public string short_name { get; set; }
        public string long_name { get; set; }
        public string spl_trns_type { get; set; }
        public string dr_key { get; set; }
        public string cr_key { get; set; }
    }
    public class SEL_T003_P_SI_ItemsList//Item List for Popup Sales Invoice.
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CatCode { get; set; }
        public string SubCatCode { get; set; }
        public string unit_code { get; set; }
        public Nullable<bool> StockUnt { get; set; }
        public string cstmr_itemcode { get; set; }
        public string cstmr_itemdescr { get; set; }
        public Nullable<decimal> rate { get; set; }
        public string sku { get; set; }
        public string tax_id { get; set; }
        public string Catlog_UOM { get; set; }
        public string sku_desc { get; set; }
        public string item_cat_id { get; set; }
        public Nullable<decimal> Rate_Suggested { get; set; }
        public Nullable<decimal> Rate_Catlog { get; set; }
        public string gross_wt { get; set; }
        public string net_wt { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public Nullable<decimal> discount { get; set; }
        public string volume { get; set; }
        public string weight_unit_cd { get; set; }
        public string volume_unit_cd { get; set; }
        public string weight_unit { get; set; }
        public string volume_unit { get; set; }
        public Nullable<decimal> MinQty { get; set; }
        public Nullable<decimal> MaxQty { get; set; }
        public Nullable<decimal> Reorder { get; set; }
        public Nullable<decimal> stock_total { get; set; }
        public Nullable<decimal> stock_reserve { get; set; }
        public Nullable<decimal> stock_unr { get; set; }
        public Nullable<decimal> stock_in_transit { get; set; }
        public string acc_group { get; set; }
        public string value_class { get; set; }
        public string recon_acc { get; set; }
        public bool? ind_sku;

    }
    public class Log_T001_A_ItemsList//Item List for Popup transfer Documents from delivery no
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CatCode { get; set; }
        public string SubCatCode { get; set; }
        public string unit_code { get; set; }
        public Nullable<bool> Stockble { get; set; }
        public string PartyId { get; set; }
        public string sku { get; set; }
        public decimal qty { get; set; }
        public string sku_desc { get; set; }
        public string wa_code { get; set; }
        public string location_Id { get; set; }
        public string store_code { get; set; }
        public Nullable<decimal> MinQty { get; set; }
        public Nullable<decimal> MaxQty { get; set; }
        public Nullable<decimal> Reorder { get; set; }
        public Nullable<decimal> stock_total { get; set; }
        public Nullable<decimal> stock_reserve { get; set; }
        public Nullable<decimal> stock_unr { get; set; }
        public Nullable<decimal> stock_in_transit { get; set; }

    }
    public class ACC_M003_P // Account code List
    {
        public string acc_code { get; set; }
        public int id { get; set; }
        public string p_name { get; set; }
        public string p_code { get; set; }
        public string gl_code { get; set; }
        public string gl_name { get; set; }
        public string ac_group_code { get; set; }
        public string ac_group_name { get; set; }
        public string acc_type { get; set; }
        public string hb_code { get; set; }
        public string hb_acc { get; set; }
        public string ledger_gen { get; set; }
        public string acc_no { get; set; }
        public string bank_name { get; set; }
        public bool? ind_default { get; set; }
    }
    public class ACC_M003_O_P // Condition Type
    {
        public string con_type { get; set; }
        public string con_desc { get; set; }
        public string con_cat { get; set; }
        public string pricing_pro { get; set; }
        public string acc_key { get; set; }
        public string trns_key_code { get; set; }
    }
    public class ACC_M003_A_P
    {
        public string ac_group_code { get; set; }
        public string ac_group_name { get; set; }

    }
    public class ACC_M003_B_P
    {
        public int id { get; set; }
        public string ac_sg_code { get; set; }
        public string ac_sg_name { get; set; }
        public string ac_group_code { get; set; }
        public string ac_group_name { get; set; }
        public string parent_group_code { get; set; }
    }
    public class ACC_M003_Q_P // Posting Key Master
    {
        public string posting_key { get; set; }
        public string posting_type { get; set; }
        public string posting_desc { get; set; }
        public string post_desc2 { get; set; }
        public string ind_decr { get; set; }
    }
    public class ACC_M003_E_P // Transaction Key
    {
        public string trns_key_code { get; set; }
        public string trns_key_desc { get; set; }
        public string mod_group { get; set; }
        public string trns_code { get; set; }
        public string module { get; set; }

    }
    public class ACC_M003_J_P
    {
        public string trans_scope { get; set; }
        public string desc_app { get; set; }
    }
    public class ACC_M003_S1_P
    {
        public string con_type { get; set; }
    }
    public class ACC_M003_D_P
    {
        public string coa_key { get; set; }
        public string comp_code { get; set; }
    }
    public class ACC_M003_H_P
    {
        public string acc_group { get; set; }
        public string group_desc { get; set; }
        public string acc_group_type { get; set; }
    }

    public class PUR_T005_P_PI_ItemsList
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CatCode { get; set; }
        public string SubCatCode { get; set; }
        public string unit_code { get; set; }
        public Nullable<bool> StockUnt { get; set; }
        public string cstmr_itemcode { get; set; }
        public string cstmr_itemdescr { get; set; }
        public Nullable<decimal> rate { get; set; }
        public string sku { get; set; }
        public string tax_id { get; set; }
        public string Catlog_UOM { get; set; }
        public string sku_desc { get; set; }
        public string item_cat_id { get; set; }
        public Nullable<decimal> Rate_Suggested { get; set; }
        public Nullable<decimal> Rate_Catlog { get; set; }
        public string gross_wt { get; set; }
        public string net_wt { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public Nullable<decimal> discount { get; set; }
        public string volume { get; set; }
        public string weight_unit { get; set; }
        public string vol_unit { get; set; }
        public Nullable<decimal> MinQty { get; set; }
        public Nullable<decimal> MaxQty { get; set; }
        public Nullable<decimal> Reorder { get; set; }
        public Nullable<decimal> stock_total { get; set; }
        public Nullable<decimal> stock_reserve { get; set; }
        public Nullable<decimal> stock_unr { get; set; }
        public Nullable<decimal> stock_in_transit { get; set; }
        public string Ref_doc_no { get; set; }
        public string po_no { get; set; }



    } //Item List for Popup Purchase Invoice
    public class SEL_T003_P
    {
        public string bill_doc { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string local_export { get; set; }
        public string para7 { get; set; }
        public string para3 { get; set; }
        public Nullable<decimal> roundup_total { get; set; }
        public string curr_code { get; set; }
        public Nullable<decimal> lc_exc_rate { get; set; }
        public string PartyName { get; set; }
        public string cust_ref { get; set; }
        public string EmpId { get; set; }
        public string sales_person { get; set; }
        public string PartyId { get; set; }
        public Nullable<System.DateTime> post_date { get; set; }
        public string doc_desc { get; set; }
        //public string fin_year { get; set; }
        //public string Period { get; set; }

        public decimal sub_total { get; set; }
        public decimal tax_amount { get; set; }
        public decimal invoice_amt { get; set; }
        public decimal ass_value { get; set; }
        public decimal total_form { get; set; }
        public decimal total_inv_amt { get; set; }
        public string serial_no { get; set; }
        public string sono { get; set; }
    }
    public class ZSEL_T003_P
    {
        public string party_id { get; set; }
        public string sr_no { get; set; }
        public string cust_name { get; set; }
        public string cust_id { get; set; }
        public string hsn_code { get; set; }
        public string gst_no { get; set; }
        public string invoice_no { get; set; }
    }
    public class ZSEL_T003_A_P
    {
        public string hsn_code { get; set; }
        public string gst { get; set; }
        public Nullable<decimal> gst_p { get; set; }

    }
    public class ADM_M028_J_P
    {
        public string BusinessTyp { get; set; }
        public string Name { get; set; }
    }
    public class ADM_M028_P
    {
        public int? id { get; set; }
        public bool? selected { get; set; }
        public string party_code { get; set; }
        public string party_name { get; set; }
        public string cp_code { get; set; }
        public string cp_name { get; set; }
        public string cp_mail { get; set; }
        public string location { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string EmailId { get; set; }
        public string curr_code { get; set; }
        public string symbol { get; set; }
        public string contryNm { get; set; }
        public string PartyType { get; set; }
        public string Location { get; set; }
        public string PersnEmailId { get; set; }
        public string grpNm { get; set; }
        public string EmpId { get; set; }
        public string PersonName { get; set; }
        public string abbr { get; set; }
        public string acc_group { get; set; }
        public string recon_acc { get; set; }
        public string buss_place { get; set; }
        public int? ship_to_add { get; set; }
        public string acc_number { get; set; }
        public string bank_code { get; set; }
        public string bank_name { get; set; }
        public string ifsccode { get; set; }
        public string swift_code { get; set; }
        public string gl_code { get; set; }
        public string gl_name { get; set; }
        public string p_term_code { get; set; }
        public string p_term { get; set; }
        public string country_code { get; set; }
        public string transporter_name { get; set; }
        public string location_id { get; set; }
        public string location_name { get; set; }
        public string place { get; set; }
        public string VendorCd { get; set; }
        public string add_code { get; set; }
    }
    public class ADM_M028Flip
    {
        public int id { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string Location { get; set; }
        public string PartyTypeNm { get; set; }
        public string BusinesTyp { get; set; }
        public string PhNo { get; set; }
        public string EmailId { get; set; }
        public string WebSite { get; set; }
        public string EmpNm { get; set; }
        public Nullable<bool> Customer { get; set; }
        public Nullable<bool> Supplier { get; set; }
        public string curr_code { get; set; }
        public string gstinno { get; set; }
        public string address { get; set; }
        public string contact_person { get; set; }
        public string PersnMobNo { get; set; }
        public string PersnEmailId { get; set; }
        public string VendorCd { get; set; }

    }
    public class ADM_M053Flip
    {
        public string party_id { get; set; }
        public string party_name { get; set; }
        public string party_location { get; set; }
        public string refer_by { get; set; }
        public string refer_by_name { get; set; }
        public string party_type { get; set; }
        public string PartyTypeNm { get; set; }

    }
    public class ADM_M054Flip
    {
        public string cp_code { get; set; }
        public string party_id { get; set; }
        public string gender { get; set; }
        public string dept_code { get; set; }
        public string desig_code { get; set; }
        public string cp_name { get; set; }
        public string party_name { get; set; }
        public string DesigName { get; set; }
        public string DeptName { get; set; }

    }
    public class ADM_M028_sch_P
    {
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
    }
    public class ACC_M026_P
    {
        public string coa_key { get; set; }
        public string coa_key_desc { get; set; }
    }
    public class ADM_M038_B_P
    {
        public int? id { get; set; }
        public int? class_id { get; set; }
        public string class_name { get; set; }
        public bool? is_base_unit { get; set; }
        public string unit_code { get; set; }
        public string unit_name { get; set; }
        public string unit_abbrv { get; set; }
    }

    public class ECRM_T004_Aflip
    {
        public string barcode_no { get; set; }
        public string pdi_no { get; set; }
        public DateTime? pdi_date { get; set; }
        public DateTime? prodate { get; set; }
        public string ItemCode { get; set; }
        public string machinecode { get; set; }
        public string shift { get; set; }
        public string ItemName { get; set; }
        public string t_display { get; set; }
    }
    public class ESO_T001Sort
    {
        public string sort_by { get; set; }
        public string machinecode { get; set; }
    }

    public class ADM_M024_P2
    {

        public string EmpId { get; set; }
        public string EmpLName { get; set; }
        public string EmpFName { get; set; }
        public string EmpMName { get; set; }
        public string EmpMobNo { get; set; }
        public string DesigCode { get; set; }

    }
    public class ACC_M013_P // Tax Data
    {
        public int id { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }
        public string t_type { get; set; }
        public Nullable<Boolean> include_base_amount { get; set; }
        public Nullable<Boolean> child_depend { get; set; }
        public Nullable<Int32> parent_id { get; set; }
        public string taxaccount { get; set; }
        public Nullable<int> accountcollectdid { get; set; }
        public Nullable<Boolean> Price_include { get; set; }
        public int sequence { get; set; }
        public string tax_code { get; set; }
        public int? base_code_id { get; set; }
    }
    public class ADM_M028_D_Add
    {
        public int SrNo { get; set; }
        public string AddType { get; set; }
        public string del_add { get; set; }
        public string Location { get; set; }
        public string PartyId { get; set; }
        public string add_code { get; set; }

    }


    public class ACC_M007_P // Payment Terms
    {
        public string p_term { get; set; }
        public string p_term_code { get; set; }
        public string ind_default { get; set; }

    }
    public class ACC_M021_P // Payment Terms
    {
        public string pay_method { get; set; }
        public string pay_code { get; set; }
        public string pay_mode { get; set; }
        public string text_name { get; set; }
        public string short_text { get; set; }

    }
    public class MM_M002_P // Wearhouse Data
    {
        public string wa_code { get; set; }
        public string wa_name { get; set; }
    }
    public class ADM_M037_P//Currency Master
    {
        public string curr_code { get; set; }
        public string curr_name { get; set; }
        public string symbol { get; set; }
        public string file_no { get; set; }
        public Nullable<DateTime> iss_dt { get; set; }
        public Nullable<DateTime> exp_dt { get; set; }

        public decimal? rounding { get; set; }
        public bool? curr_base { get; set; }
        public string position { get; set; }
        public int? accuracy { get; set; }
        public bool? active { get; set; }
        public int? no_of_deci { get; set; }
        public string monitory_unit { get; set; }
        public string monitory_unit_prefix { get; set; }
        public string tail_word { get; set; }
        public decimal? exch_rate { get; set; }
        public decimal? exch_rate_direct { get; set; }
        public DateTime? date_effective { get; set; }
        public string curr_code_to { get; set; }

    }
    public class ADM_M004_A_P//Currency Master
    {
        public string bank_key { get; set; }
        public string bank_name { get; set; }
    }
    public class ACC_M005_P
    {
        public string j_code { get; set; }
        public string j_name { get; set; }
    }
    public class PPC_T001_P
    {
        public string doc_no { get; set; }
        public string doc_type { get; set; }
        public string mov_tp { get; set; }
        public string batch_no { get; set; }
        public Nullable<int> machine_id { get; set; }
        public string machinecode { get; set; }
        public string shift1 { get; set; }
        public string shift2 { get; set; }
        public string shift3 { get; set; }
        public string m_operator { get; set; }
        public string shift_incharge { get; set; }
        public string ItemCode { get; set; }
        public string OperatorName { get; set; }
        public string ShiftInchargeName { get; set; }
    }

    public class Order_No_P   // This Popup Class is used in Delivery Note for Combine Loading of Sales Order , Invoice and PO
    {
        public string order_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public DateTime? doc_date { get; set; }
        public string party_name { get; set; }
        public string t_status { get; set; }
        public string color_code { get; set; }
        public string t_display { get; set; }
        public string PartyId { get; set; }
        public string so_code { get; set; }
        public string curr_code { get; set; }
        public int del_address { get; set; }
        public string p_term_code { get; set; }
        public string incoterms { get; set; }
        public string country_nm_s { get; set; }
        public string supplying_plant { get; set; }
        public string rec_plant { get; set; }
        public decimal? qty { get; set; }
        public decimal? order_qty { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public string unit_code { get; set; }
        public string bom_no { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string cust_ref { get; set; }
        public string wc_code { get; set; }
        public string ind_executable { get; set; }
        public string short_text { get; set; }
    }
    public class OrderDetails_P
    {
        public Nullable<int> bill_address_id { get; set; }
        public Nullable<int> del_address { get; set; }
        public string so_code { get; set; }
        public string div_code { get; set; }
        public string sold_to_party { get; set; }
        public string dc_code { get; set; }
        public string sg_code { get; set; }
        public string sales_office { get; set; }
        public string business_area { get; set; }
        public string ship_to_party { get; set; }
        public string pre_carrage { get; set; }
        public string pre_carrage_place { get; set; }
        public string country_code { get; set; }
        public string cf_agent_cd { get; set; }
        public string lic_cod { get; set; }
        public string adv_lic_cd { get; set; }
        public string org_country_cd { get; set; }
        public string transporter_cd { get; set; }
        public string ship_mode { get; set; }
        public string port_desc { get; set; }
        public string final_dest { get; set; }
        public string ship_terms { get; set; }
        public string ship_mark { get; set; }
        public string port_load { get; set; }
        public string soldpartynm { get; set; }
        public string shippartynm { get; set; }
        public string transporternm { get; set; }
        public string supplying_plant { get; set; }
        public string rec_plant { get; set; }
        public string supplantnm { get; set; }
        public string recplantnm { get; set; }
        public string sales_person_cd { get; set; }
        public string buyer_name { get; set; }
        public string cust_ref { get; set; }
        public DateTime? cust_ref_date { get; set; }
        public string BillAddrLoc { get; set; }
        public string DelAddrLoc { get; set; }
        public string doc_history_no { get; set; }
        public string curr_code { get; set; }
        public string incoterms { get; set; }
        public string incoterm2 { get; set; }
        public string sono { get; set; }
        public string order_no { get; set; }
        public int so_item_line_id { get; set; }
        public int so_item_row_id { get; set; }
        public string ref_doc { get; set; }
        public int ref_item_line_id { get; set; }
        public int ref_item_row_id { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string tr_party { get; set; }
        public string tr_mode { get; set; }
    }
    public class SEL_T001_Flip
    {
        public string sono { get; set; }
        public Nullable<DateTime> sodate { get; set; }
        public string cust_ref { get; set; }
        public Nullable<DateTime> cust_ref_date { get; set; }
        public string doc_type { get; set; }
        public string dcat_name { get; set; }
        public string doc_cat { get; set; }
        public string doc_type_user { get; set; }
        public string doc_desc_user { get; set; }
        public string ref_doc_no { get; set; }
        public Nullable<DateTime> valid_to_date { get; set; }
        public string Seller { get; set; }
        public string buyer_name { get; set; }
        public string so_code { get; set; }
        public string sales_org { get; set; }
        public string party_name { get; set; }
        public string ship_to_party { get; set; }
        public string PartyId { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
        public string location_id { get; set; }
        public string comp_code { get; set; }
        public string roundup_total { get; set; }
        public string sg_code { get; set; }
        public string sg_name { get; set; }
        public string add_by { get; set; }
        public string reference { get; set; }
        public string remark1 { get; set; }

    }
    public class CRM_T003_Flip
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string source { get; set; }
        public Nullable<int> address_id { get; set; }
        public Nullable<System.DateTime> expect_date { get; set; }
        public Nullable<int> buyer { get; set; }
        public string notes { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_type { get; set; }
        public string PartyId { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string curr_code { get; set; }
        public string cost_center { get; set; }
        public string version { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string t_status { get; set; }
        public Nullable<decimal> ex_rate { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string revision_no { get; set; }
        public string revision_ind { get; set; }
        public string rev_ref_no { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string reference_by { get; set; }
        public string reference_details { get; set; }
        public string t_status_remark { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string doc_history_no { get; set; }
        public bool active { get; set; }
        public System.DateTime add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string group_key { get; set; }
        public string priority { get; set; }
        public string doc_score { get; set; }
        public string doc_rec { get; set; }
        public string camp_no { get; set; }
        public string project_no { get; set; }
        public string doc_title { get; set; }
        public string origin_code { get; set; }
        public string ind_privacy { get; set; }
        public Nullable<int> annual_revenue { get; set; }
        public Nullable<int> emp_strength { get; set; }
        public Nullable<decimal> exp_sales_opp { get; set; }
        public string seg_code { get; set; }
        public Nullable<System.DateTime> exp_closing_date { get; set; }
        public Nullable<decimal> success_chance { get; set; }
        public string ind_forecast { get; set; }
        public string doc_qulif_Level { get; set; }
        public string forcast_no { get; set; }
        public string planning_no { get; set; }
        public string ind_io { get; set; }
        public string survey_no { get; set; }
        public string cgroup_code { get; set; }
        public string pref_contact { get; set; }
        public string reason_code { get; set; }
        public string doc_stage { get; set; }
        public string color_code { get; set; }
        public string rank_star { get; set; }
        public Nullable<decimal> probability { get; set; }
        public int user_score { get; set; }
        public string doc_status { get; set; }
        public string doc_ref { get; set; }
        public Nullable<System.DateTime> ref_date { get; set; }
        public string ref_party { get; set; }
        public string ref_contact_person { get; set; }
        //Scaler   
        public string PartyNm { get; set; }
        public string seller_name { get; set; }
        public string cost_center_Desc { get; set; }
        public string PartyEmailId { get; set; }
        public string PersonEmailId { get; set; }
        public string dcat_name { get; set; }
        public string symbol { get; set; }
        public string doc_desc { get; set; }
        public string LoctnNm { get; set; }
        public string doc_type_user { get; set; }
        public string address_name { get; set; }
        public string buyer_name { get; set; }
        public string ref_contact_name { get; set; }
        public string origin_desc { get; set; }
        public string ref_party_name { get; set; }
        public string pref_contact_name { get; set; }
        public string seg_name { get; set; }
        public string action_type { get; set; }
        public string activity_cat { get; set; }
        //
        public string sales_person_name { get; set; }
        public string so_name { get; set; }
        public string sg_name { get; set; }
        public string location_name { get; set; }
        public string party_name { get; set; }
        public string party_location { get; set; }
        public string doc_status_name { get; set; }
        public string doc_stage_name { get; set; }
        public string doc_rec_name { get; set; }
        public string doc_score_name { get; set; }
        public string qulif_Level_name { get; set; }
        public string priority_name { get; set; }
        //Extra
        public string owner { get; set; }
        public string EmpName { get; set; }
        public string project_name { get; set; }
        public string contact_person { get; set; }
        public string person_number { get; set; }
        public string EmailId { get; set; }
        public string place { get; set; }
        public string party_name2 { get; set; }
        public string cp_name { get; set; }
    }

    public class ACC_M004_A_P
    {
        public string bank_key { get; set; }
        public string bank_name { get; set; }
        public string bank_code { get; set; }

    }
    public class SYS_M028_P //Control Code
    {
        public string control_code { get; set; }
        public string control_desc { get; set; }
    }
    public class ACC_M025_P
    {
        public string wtax_code { get; set; }
        public string wtax_ncode { get; set; }
        public decimal? wtax_rate { get; set; }
        public decimal? wtax_per { get; set; }
        public string wtax_type { get; set; }
    }
    public class ADM_M002_B
    {
        public string CatCode { get; set; }
        public string cat_name { get; set; }

    }
    public class ACC_M004_P
    {
        public string bank_code { get; set; }
        public string bank_name { get; set; }
        public string bk_abbriviation { get; set; }
        public string branch { get; set; }
        public string acc_number { get; set; }
        public string acc_no { get; set; }
        public string comp_code { get; set; }
        public string curr_code { get; set; }
        public string curr_name { get; set; }
        public string hb_code { get; set; }
        public string hb_acc { get; set; }
        public string pb_code { get; set; }
        public string PartyId { get; set; }
        public string acc_holder_name { get; set; }
        public string bank_key { get; set; }
        public string gl_code { get; set; }
        public string acc_type { get; set; }
        public bool? ind_default { get; set; }
        public string ind_trade { get; set; }
    }
    public class ADM_M028_C_P
    {
        public int? ContInfoId { get; set; }
        public int? SrNo { get; set; }
        public string contact_name { get; set; }
        public string PersonName { get; set; }
        public string PersnEmailId { get; set; }
        public string Location { get; set; }
        public string PersnMobNo { get; set; }
        public string PersnPhNo { get; set; }
        public string PartyId { get; set; }
        public string EmailId { get; set; }
        public int supplier_EmpId { get; set; }
        public string cp_code { get; set; }
        public string cp_name { get; set; }
    }
    public class SEL_T001_P_RefDoc //Sales Order Reference Documents as per Paarty
    {
        public string sono { get; set; }
        public DateTime sodate { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string cust_ref { get; set; }
        public Nullable<System.DateTime> cust_ref_date { get; set; }
        public string quotation_no { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public string ItemCode { get; set; }
        public string para3 { get; set; }
        public string so_code { get; set; }
        public string curr_code { get; set; }
        public string country_nm_s { get; set; }
        public string del_address { get; set; }
        public string bill_address_id { get; set; }
        public string p_term_code { get; set; }
        public string incoterms { get; set; }
        public string color_code { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }



    }

    public class ADM_M044_P //Incoterms
    {
        public string incoterms { get; set; }
        public string inco_desc { get; set; }
        public string inco_desc2 { get; set; }
    }

    public class ADM_M041_P //Incoterms
    {
        public string lic_cod { get; set; }
        public string lic_desc { get; set; }
        public string lic_type { get; set; }
        public DateTime? issue_date { get; set; }
        public DateTime? export_expiry_date { get; set; }
        public string file_no { get; set; }

    }
    public class SEL_T003_P_RefDoc //Sales Invoice Reference Documents as per Party
    {
        public string Ref_DocNo { get; set; }
        public DateTime Ref_date { get; set; }
        public string doc_cat { get; set; }
        public string Ref_DocType { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string ref_doc_no { get; set; }
        public string Location { get; set; }
        public Nullable<decimal> order_limit { get; set; }
        public string ref_cat { get; set; }
        public string order_type { get; set; }

        public string del_address { get; set; }
        public string bill_address_id { get; set; }
        public string p_term_code { get; set; }
        public string incoterms { get; set; }
        public string curr_code { get; set; }
        public string country_nm_s { get; set; }
        public DateTime goods_issue_date { get; set; }

        public string sono { get; set; }
        public Nullable<DateTime> sodate { get; set; }
        public string ItemCode { get; set; }
        public int id { get; set; }
        public int line_id { get; set; }
        public string sku { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public string doc_type { get; set; }
        public string t_status { get; set; }
        public string color_code { get; set; }
        public string t_display { get; set; }
        public string sch_no { get; set; }
        public Nullable<DateTime> desp_date { get; set; }
        public string Description { get; set; }
        public string unit_code { get; set; }
        public string quantity { get; set; }
        public Nullable<DateTime> del_date { get; set; }
        public string sch_qty { get; set; }
        public int ship_to_add { get; set; }
        public decimal? current_stock { get; set; }
        public string current_stock_uom { get; set; }
        public string cust_ref { get; set; }
        public Nullable<DateTime> cust_ref_date { get; set; }
        public decimal? so_qty { get; set; }
        public decimal? total_do_qty { get; set; }
        public decimal? total_dn_qty { get; set; }
        public decimal? bal_dn_qty { get; set; }
        public decimal? so_sch_qty { get; set; }
        public decimal? open_do_qty { get; set; }
        public decimal? so_bal_qty { get; set; }
        public decimal? sch_bal_qty { get; set; }
        public string ind_executable { get; set; }
        public string short_text { get; set; }

        public string po_no { get; set; }
        public DateTime? po_date { get; set; }
        public decimal? po_qty { get; set; }
        public string grn_no { get; set; }
        public DateTime? grn_date { get; set; }
        public decimal? grn_qty { get; set; }


    }
    public class PUR_T005_P_RefDoc //Purchase Invoice Reference Documents as per Party
    {
        public string Ref_DocNo { get; set; }
        public DateTime Ref_date { get; set; }
        public string doc_cat { get; set; }
        public string Ref_DocType { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
        public string po_code { get; set; }
        public string curr_code { get; set; }
        public int del_address { get; set; }
        public string p_term_code { get; set; }
        public string incoterms { get; set; }
        public int bill_address_id { get; set; }
        public string country_code { get; set; }
        public string country_nm_s { get; set; }
        public DateTime issue_date { get; set; }
        public string color_code { get; set; }
    }
    public class LOG_T001_A_P
    {
        public string delivery_no { get; set; }
        public DateTime? delivery_date { get; set; }
        public string doc_type { get; set; }
        public string PartyNm { get; set; }
        public string ShipToPartyNm { get; set; }
        public string doc_cat { get; set; }
        public DateTime? goods_issue_date { get; set; }
        public decimal? wt_goods { get; set; }
        public decimal? net_weight { get; set; }
        public decimal? net_value { get; set; }
        public string delivery_desc { get; set; }
        public string order_no { get; set; }
        public string t_status { get; set; }
        public bool? invoicemade { get; set; }
    }
    public class CRM_T001A_P
    {
        public string cust_cat_no { get; set; }
        public string description { get; set; }
        public string PartyId { get; set; }
    }
    public class CRM_T001B_P
    {
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }

    }
    public class MM_T004Flip
    {
        public string doc_no { get; set; }
        public DateTime? entry_date { get; set; }
        public string PartyNm { get; set; }
        public string EmpLName { get; set; }
        public string del_note_no { get; set; }
        public DateTime? del_note_date { get; set; }
        public string pod_no { get; set; }
        public DateTime? posting_date { get; set; }
        public string location { get; set; }
        public string ItemName { get; set; }
        public string trans_mode { get; set; }
        public string prepared_by_nm { get; set; }
        public string lrno { get; set; }
        public DateTime? date_of_receipt { get; set; }
        public string in_time { get; set; }
        public string out_time { get; set; }
        public string entry_time { get; set; }
        public string vehicle_no { get; set; }
        public string description { get; set; }
        public string PartyId { get; set; }
        public string place { get; set; }
        public string ItemCode { get; set; }
        public string EmpNm { get; set; }
        public string service_provider_id { get; set; }
        public decimal? qty { get; set; }
        public string t_display { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
    }
    public class EPR_T001_P1
    {
        public Nullable<int> id { get; set; }
        public string machinecode { get; set; }
        public Nullable<int> Conv_lot { get; set; }
        public string Status { get; set; }
        public Nullable<int> model_id { get; set; }
        public string modelno { get; set; }// old field model_no
        public string ItemCode { get; set; }//old field item_code
        public Nullable<int> party_id { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string shift { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public System.DateTime start_dt { get; set; }
        public System.DateTime end_dt { get; set; }

        public System.DateTime pro_dt { get; set; }

        public Nullable<decimal> min_val { get; set; }
        public Nullable<decimal> max_val { get; set; }
        public string shank_len { get; set; }
        public Nullable<decimal> shank_dia { get; set; }
        public string needle_dia { get; set; }
        public string needle { get; set; }
        public string total_len { get; set; }
        public Nullable<decimal> amnild { get; set; }
        public Nullable<decimal> amxild { get; set; }
        public Nullable<decimal> aavild { get; set; }
        public int machine_id { get; set; }
        public string machinedesc { get; set; }
        public string machine_type { get; set; }
        public string ItemName { get; set; }
        public int conv { get; set; }
        public string Unit_Code { get; set; }
        public string order_no { get; set; }
        public string model_code { get; set; }
        public string ball_make { get; set; }
        public string ball_dia { get; set; }
        public string wire_make { get; set; }
        public string shape { get; set; }
        public string basket { get; set; }
        public string spoons { get; set; }
        public string sf { get; set; }
        public string tds_no { get; set; }
        public string order_type { get; set; }
        public string status { get; set; }
        public string Note { get; set; }
        public string location_Id { get; set; }
        public string ball_type { get; set; }
        public Nullable<decimal> wire_size { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> ProduceQty { get; set; }
        public Nullable<decimal> BalanceQty { get; set; }
        public string wc_code { get; set; }
        //Scalar
        public decimal? Ball_dia { get; set; }
        public bool IsColour { get; set; }
        public bool StatusColor { get; set; }
        public string t_display { get; set; }
        public string active { get; set; }
    }
    public class SEL_T001_P1//Sales Order Details for Production planning
    {
        public string sono { get; set; }
        public Nullable<System.DateTime> sodate { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string Ink { get; set; }
        public string Ild { get; set; }
        public string CurrentStock { get; set; }
        public decimal ball_dia { get; set; }
        public string ball_type { get; set; }
        public decimal wire_size { get; set; }
        public Nullable<decimal> MinQty { get; set; }
        public Nullable<decimal> MaxQty { get; set; }
        public Nullable<decimal> Reorder { get; set; }
        public Nullable<decimal> stock_total { get; set; }
        public Nullable<decimal> stock_reserve { get; set; }
        public Nullable<decimal> stock_unr { get; set; }
        public Nullable<decimal> stock_in_transit { get; set; }
        public Nullable<decimal> Reserve_Stock { get; set; }
        public Nullable<decimal> Balence_Qty { get; set; }
        public int id { get; set; }
        public Nullable<decimal> plan_qty_for_SO { get; set; }
        public string t_status_PPC_B { get; set; }
        public string sku { get; set; }
        public Nullable<int> model_id { get; set; }
        public string model_code { get; set; }
    }
    public class EPR_T004_C_P
    {
        public string machine_no { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string unit_code { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string sono { get; set; }
        public string revision { get; set; }
        public string ItemName { get; set; }
        public string ild { get; set; }
        public string ink { get; set; }

    }

    public class PRO_M001_P
    {
        public string cat_id { get; set; }
        public string cat_title { get; set; }
        public bool? active { get; set; }

    }
    public class PRO_M001_A_P
    {
        public string sub_cat_code { get; set; }
        public string sub_cat { get; set; }
        public string cat_id { get; set; }
        public bool? active { get; set; }
    }
    public class ECRM_T001_A_Sample
    {
        public string sa_no { get; set; }
        public Nullable<System.DateTime> sa_date { get; set; }
        public Nullable<bool> smoth { get; set; }
        public Nullable<bool> fadng { get; set; }
        public Nullable<bool> ild { get; set; }
        public Nullable<bool> gooping { get; set; }
        public Nullable<bool> skiping { get; set; }
        public Nullable<bool> deep_light { get; set; }
        public Nullable<bool> waviness { get; set; }
        public Nullable<bool> stat_lickage { get; set; }
        public Nullable<bool> wrt_length { get; set; }
        public Nullable<bool> ch_ball { get; set; }
        public Nullable<bool> ch_matrl { get; set; }
        public Nullable<bool> prepare_digram { get; set; }
        public Nullable<bool> mch_esem_model { get; set; }
        public Nullable<bool> in_geometry { get; set; }
        public string other_req { get; set; }
        public string wrt_length_req { get; set; }
        public Nullable<bool> other_req1 { get; set; }

    }
    public class ZCRM_T004Flip
    {

        public string doc_no { get; set; }
        public DateTime doc_date { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string contact_per_nm { get; set; }
        public string t_status { get; set; }
        public string  tender_no { get; set; }
        public string EmpName { get; set; }

    }
    public class ADM_M022_POPUP
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string unit_code { get; set; }
        public string CatCode { get; set; }
        public bool StockUnt { get; set; }
        public string SubCatCode { get; set; }
        public bool Stockble { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string Grade { get; set; }
        public Nullable<decimal> para6 { get; set; }

    }
    public class ZCRM_T004_P
    {
        public string doc_no { get; set; }
        public string tender_no { get; set; }
        public string tender_name { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public int ContInfoId { get; set; }
        public string contact_per_nm { get; set; }
    }
    public class ACC_T003_B_P
    {
        public string head_code { get; set; }
        public string description { get; set; }
        public Nullable<decimal> limit { get; set; }
    }
    public class SEL_T001SSE_Flip
    {
        public string sono { get; set; }
        public Nullable<DateTime> sodate { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public string cust_ref { get; set; }
        public string Seller { get; set; }
        public string buyer_name { get; set; }
        public string t_status { get; set; }
        public string location_id { get; set; }
        public string comp_code { get; set; }
        public string order_type { get; set; }
        public string sch_no { get; set; }
        public int del_address { get; set; }
        public string del_add { get; set; }
        public string Location { get; set; }

    }
    public class PPC_T003_Batch
    {
        public string doc_no { get; set; }
        public DateTime prod_date { get; set; }
        public string batch_no { get; set; }
        public string barcode { get; set; }
        public int? machine_id { get; set; }
        public string machinecode { get; set; }
        public string shift1 { get; set; }
        public string shift2 { get; set; }
        public string shift3 { get; set; }
        public decimal quantity { get; set; }
        public decimal? counter_q { get; set; }
        public string t_status { get; set; }
        public string shift_incharge { get; set; }
        public string ShiftInchargeName { get; set; }
        public string ItemCode { get; set; }
        public string unit_code { get; set; }
        public decimal? counter_qty { get; set; }
        public decimal? uc_qty { get; set; }

        // EPR_T001 Fields
        public int model_id { get; set; }
        public string model_code { get; set; }
        public string ball_dia { get; set; }
        public string ball_make { get; set; }
        public int ball_make_id { get; set; }
        public string wire_make { get; set; }
        public int wire_make_id { get; set; }
        public decimal wire_size { get; set; }
        public int wire_size_id { get; set; }
        public string ild { get; set; }
        public int ild_id { get; set; }
        public string ball_type { get; set; }
        public int ball_type_id { get; set; }
        public string ink { get; set; }
        public int ink_id { get; set; }
        public Nullable<decimal> min_val { get; set; }
        public Nullable<decimal> max_val { get; set; }
        public string tip_type { get; set; }

        //scalar Add By sandeep
        public string ItemName { get; set; }
        public decimal? conversion_no { get; set; }
        public string m_operator { get; set; }
        public string operatornm { get; set; }
        public string RefDocNo { get; set; }
        public string doc_type { get; set; }
        public string order_no { get; set; }
        public Nullable<int> Conv_lot { get; set; }

        //For SO Details
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public string ItemCode1 { get; set; }
        public string ItemName1 { get; set; }
        public string sono { get; set; }
        public decimal? quantity1 { get; set; }
        public DateTime? sodate { get; set; }
        public string wc_code { get; set; }
        public string remark1 { get; set; }
        public string grade { get; set; }
        public string counter_remark { get; set; }
        public string test_code { get; set; }
    }

    public class ESO_T001Flip
    {
        public DateTime prod_dt { get; set; }
        public string doc_no { get; set; }
        public string batch_no { get; set; }
        public string shift { get; set; }
        public string ShiftInchargeName { get; set; }
        public string OperatorName { get; set; }
        public string ItemCode { get; set; }
        public string machinecode { get; set; }
        public string t_status { get; set; }
        public DateTime entry_dt { get; set; }
        public string t_display { get; set; }
    }

    public class ENG_M025_B_P
    {
        public string bom_cat_code { get; set; }
        public string bom_cat_desc { get; set; }
    }
    public class ENG_T001_P
    {
        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string bom_name { get; set; }
        public string bom_no { get; set; }

    }
    public class ENG_T003_P
    {
        public string parameter { get; set; }
        public string spec_para_code { get; set; }
        public string spec_type_code { get; set; }
        public string para_details { get; set; }
    }
    public class SYS_M013_P

    {
        public string TranCode { get; set; }
        public string doc_type { get; set; }
        public string doc_type_user { get; set; }
        public string doc_type_doc_no { get; set; }
        public string doc_desc { get; set; }
        public string doc_desc_user { get; set; }
        public string report_name { get; set; }
        public string ind_batch { get; set; }

    }
    public partial class SYS_M018_P
    {
        public int id { get; set; }
        public string EmpId { get; set; }
        public string UserId { get; set; }
        public string popup_alert { get; set; }

    }

    public class SEL_T003_PUR_T005_RefDoc
    {
        public string ref_doc_no { get; set; }
        public DateTime? ref_doc_date { get; set; }
        public string doc_cat { get; set; }
        public string ref_doc_type { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string TranCode { get; set; }
        public int ref_item_line_id { get; set; }
        public int ref_item_row_id { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public string sono { get; set; }
    }
    public class ECRM_T003_C_P
    {
        public string test_code { get; set; }
        public string test_desc { get; set; }
    }
    public class ACC_T003_P
    {
        public string doc_no { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string location_Id { get; set; }
    }
    public class ENG_T004_P
    {
        public string doc_no { get; set; }
        public DateTime doc_date { get; set; }
        public string modelno { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string wire_type { get; set; }
        public string machinecode { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string t_status { get; set; }
        public string location_Id { get; set; }
        public string LoctnNm { get; set; }
        public bool active { get; set; }
        public string revision_no { get; set; }
        public string cycle_type { get; set; }
        public string customer_nm { get; set; }
        public string parent_no { get; set; }
        //public decimal ball_dia { get; set; }
    }
    public class ZADM_M010_Flip
    {
        public Nullable<int> model_id { get; set; }
        public string modelno { get; set; }
        public string ItemCode { get; set; }
        public string prodnm { get; set; }
        public Nullable<int> wire_type_id { get; set; }
        public string wire_type { get; set; }
        public Nullable<int> ball_dia_id { get; set; }
        public decimal ball_dia { get; set; }
        public Nullable<int> ball_type_id { get; set; }
        public string ball_type { get; set; }
        public string tip_type { get; set; }
        public string total_len { get; set; }
    }
    public class ADM_M022_Flip
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CatCode { get; set; }
        public string CatName { get; set; }
        public string SubCatCode { get; set; }
        public string SubCatName { get; set; }
        public string ItemTypeCd { get; set; }
        public string ItemTypeNm { get; set; }
        public string SubItemTpCd { get; set; }
        public string SubItemTpNm { get; set; }
        public string ISCode { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string unit_name { get; set; }
        public string Weightunit_name { get; set; }
        public string hsn { get; set; }
    }

    public class SEL_T001_QN
    {
        public string sono { get; set; }
        public Nullable<System.DateTime> sodate { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string buyer_name { get; set; }
        public string buyer { get; set; }
        public Nullable<decimal> roundup_total { get; set; }
        public string sales_person_cd { get; set; }
        public string Seller_Name { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string t_status { get; set; }
        public string ref_doc_no { get; set; }
        public Nullable<decimal> net_pay_amt { get; set; }
        public string Order_type { get; set; }

    }
    public class ADM_M003_B_Flip
    {
        public string lab_code { get; set; }
        public string lab_name { get; set; }
        public string lab_abbr { get; set; }
        public string CompName { get; set; }
        public string LoctnNm { get; set; }
        public string activtNm { get; set; }
        public string EmpName { get; set; }
        public bool? active { get; set; }
    }

    public class QMS_M008_Flip
    {
        public string rig_code { get; set; }
        public string lab_code { get; set; }
        public string lab_name { get; set; }
        public string rig_abbr { get; set; }
        public string rig_name { get; set; }
        public string contprsn_code { get; set; }
        public string EmpName { get; set; }
        public Nullable<bool> active { get; set; }

    }
    public class ADM_M025_Flip
    {
        public string dept_code { get; set; }
        public string DeptName { get; set; }
    }
    public class ADM_M026_Flip
    {
        public string desig_code { get; set; }
        public string DesigName { get; set; }
    }

    public class EPR_T004_Flip
    {
        public string plan_no { get; set; }
        public Nullable<System.DateTime> plan_date { get; set; }
        public string status { get; set; }
        public string add_by { get; set; }
        public bool active { get; set; }
    }

    public class PPC_M001_P       //Work Center Master
    {
        public string wc_code { get; set; }  //Primary Key
        public int machine_id { get; set; }
        public string machinecode { get; set; }
        public Nullable<int> machine_type_id { get; set; }
        public string machinedesc { get; set; }
        public string machinesrno { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string mctype { get; set; }
        public string engineer { get; set; }
        public bool Sorting { get; set; }
        internal bool _yes { get; set; }
        public bool yes
        {
            get { return _yes; }
            set
            {
                if (_yes != value)
                {
                    _yes = value;
                }
            }
        }
        public bool Select { get; set; }
        public decimal? cycle_time { get; set; }
        public string cycle_uom { get; set; }
    }

    public class PPC_M001_A_P
    {
        public string wc_tp_code { get; set; }  //Primary Key
        public int machine_type_id { get; set; }
        public string machine_type { get; set; }

    }
    public class PPC_M001_B_P
    {
        public string wc_stp_code { get; set; }  //Primary Key
        public int machine_subtype_id { get; set; }
        public string machine_subtype { get; set; }

    }
    public class PPC_M001_C_P
    {
        public string wc_cat { get; set; }  //Primary Key
        public string wc_cat_desc { get; set; }

    }
    public class PPC_M001_D_P
    {
        public string place { get; set; }  //Primary Key
        public int place_no { get; set; }
        public string place_desc { get; set; }
        public string location_Id { get; set; }
    }
    public class PPC_M001_E_P
    {
        public string cap_code { get; set; }  //Primary Key        

    }
    public class PPC_M001_F_P
    {
        public string control_key { get; set; }  //Primary Key        
        public string control_desc { get; set; }

    }
    public class PPC_M001_G_P
    {
        public string gr_code { get; set; }  //Primary Key
        public string gr_name { get; set; }
        public string gr_desc { get; set; }

    }

    public class PPC_T004_P
    {
        public string plan_no { get; set; }
        public DateTime? plan_date { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? finish_date { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
        public string add_by { get; set; }
        public bool active { get; set; }
        public string wc_name { get; set; }
        public string wc_code { get; set; }
        public string order_no { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public decimal? plan_qty { get; set; }
        public string unit_code { get; set; }
        public string production_plant { get; set; }
        public decimal? order_qty { get; set; }

    }
    public class COM_T003_Files
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string description { get; set; }
        public string file_name { get; set; }
        public string url { get; set; }
        public string doc_type { get; set; }
        public string location_Id { get; set; }
        public string resource_name { get; set; }
        public Nullable<int> resource_id { get; set; }
        public string file_size { get; set; }
        public byte[] file_data { get; set; }
        public string stored_file_name { get; set; }
        public string f_name { get; set; }
        public string containt_type { get; set; }
        public Nullable<int> partner_id { get; set; }
        public string UserId { get; set; }
        public Nullable<int> parent_id { get; set; }
        public string file_index { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string newFileName { get; set; }
        public bool isUploaded { get; set; }
        public string filePath { get; set; }
        public int index { get; set; }
    }

    public class Ref_Doc_no
    {
        //new fields
        public string doc_no { get; set; }
        public System.DateTime? clean_date { get; set; }
        public System.DateTime? doc_date { get; set; }
        public string shift1 { get; set; }
        public string shift2 { get; set; }
        public string shift3 { get; set; }
        public decimal? quantity { get; set; }
        public decimal? rejection_q { get; set; }
        public string remarks { get; set; }
        public string m_operator { get; set; }
        public bool active { get; set; }
        public string doc_cat { get; set; }
        public string add_by { get; set; }
        public System.DateTime? add_date { get; set; }
        public string editby { get; set; }
        public System.DateTime? edit_date { get; set; }
        public string location_Id { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string t_status { get; set; }
        public decimal? excess_qty { get; set; }
        public decimal? sample_qty { get; set; }
        public string remark1 { get; set; }
        public string remark2 { get; set; }
        //Old Entity
        public string doc_type { get; set; }
        public string order_no { get; set; }
        public string conversion_no { get; set; }
        public string batch_no { get; set; }
        public string barcode { get; set; }
        public Nullable<int> machine_id { get; set; }
        public string machinecode { get; set; }
        public string shift { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ball_make { get; set; }
        public string wire_make { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string unit_code { get; set; }
        public string counter_q { get; set; }
        public System.DateTime prod_date { get; set; }
        public string RefDocNo { get; set; }
        public string EmpName { get; set; }
        public string shift_incharge { get; set; }

        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public string ItemCode1 { get; set; }
        public string ItemName1 { get; set; }
        public string sono { get; set; }
        public decimal? quantity1 { get; set; }
        public DateTime? sodate { get; set; }
        public string operatornm { get; set; }
        public string t_display { get; set; }
        public string wc_code { get; set; }
        public string grade { get; set; }
        public string doc_desc_user { get; set; }
        public string counter_remark { get; set; }
    }

    public class QMS_M007Flip
    {
        public string wi_code { get; set; }
        public string wi_no { get; set; }
        public string wi_desc { get; set; }
    }


    public class QMS_M006Flip
    {
        public string tp_code { get; set; }
        public string tp_desc { get; set; }
        public string tp_no { get; set; }
    }
    public class ADM_M041Flip
    {
        public int id { get; set; }
        public string lic_cod { get; set; }
        public string lic_desc { get; set; }
        public string lic_type { get; set; }
        public string sion_no { get; set; }
        public string registration_port { get; set; }
        public string bgb_no { get; set; }
        public decimal? bgb_amt { get; set; }
        public string bgb_register_at { get; set; }
        public bool? active { get; set; }

    }
    public class ADM_M041_B_P
    {
        public int id { get; set; }
        public string sion_no { get; set; }
        public string sion_desc { get; set; }
    }
    public class ADM_M041_D_P
    {
        public string lic_cat_code { get; set; }
        public string lic_cat_desc { get; set; }
    }
    public class ADM_M022_B_P
    {
        public string item_group_code { get; set; }
        public string item_group_desc { get; set; }
        public string prod_desc { get; set; }
    }
    public class ZCRM_T003_Batch
    {
        public string barcode { get; set; }
        public string order_no { get; set; }
        public string ItemCode { get; set; }
        public string machinecode { get; set; }
        public string machine_id { get; set; }
        public string shift { get; set; }
        public string shift_incharge { get; set; }
        public string conversion_no { get; set; }
        public string unit_code { get; set; }
        public System.DateTime pro_dt { get; set; }
        public string RefDocNo { get; set; }
        public string ItemName { get; set; }
        public string operatornm { get; set; }
        public string EmpName { get; set; }
        public string doc_type { get; set; }
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public string ItemCode1 { get; set; }
        public string ItemName1 { get; set; }
        public string sono { get; set; }
        public decimal? quantity1 { get; set; }
        public DateTime? sodate { get; set; }
        public string wc_code { get; set; }
        public string remark { get; set; }
        public string grade { get; set; }
        public decimal? counter_qty { get; set; }
        public string counter_remark { get; set; }
    }
    public class RND_T010_A_P
    {
        public string tb_code { get; set; }
        public string tb_name { get; set; }
    }
    public class RND_T010_B_P
    {
        public string project { get; set; }
        public string eng_model { get; set; }
        public string eng_no { get; set; }
        public string test_type { get; set; }
    }
    //Added by Priya for CRM
    //Status value
    public class CRM_M002_P
    {
        public int id { get; set; }
        public string status_code { get; set; }
        public string status_desc { get; set; }
        public int seq { get; set; }
        public string weightage { get; set; }
        public string type_code { get; set; }
        public string color_code { get; set; }
        public bool default_value { get; set; }
    }

    //Status Type
    public class CRM_M003_P
    {
        public int id { get; set; }
        public string type_code { get; set; }
        public string type_desc { get; set; }
        public string color_code { get; set; }

    }
    //Document(Lead) Status History
    public class CRM_M004_P
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public Nullable<System.DateTime> status_udate { get; set; }
        public string t_status { get; set; }
        public string status_remark { get; set; }
        public string status_code { get; set; }
        public int score { get; set; }

    }
    //Origin/Source of Document Info
    public class CRM_M005_P
    {
        public int id { get; set; }
        public string origin_code { get; set; }
        public string origin_desc { get; set; }

    }
    //Customer Group
    public class CRM_M006_P
    {
        public int id { get; set; }
        public string cgroup_code { get; set; }
        public string cgroup_desc { get; set; }

    }
    //Activity Category
    public class CRM_M007_P
    {
        public int id { get; set; }
        public string activity_cat { get; set; }
        public string cat_desc { get; set; }

    }
    //Reason of Lost Opportunity
    public class CRM_M008_P
    {
        public int id { get; set; }
        public string reason_code { get; set; }
        public string reason_desc { get; set; }

    }
    //Role Master 
    public class CRM_M009_P
    {
        public int id { get; set; }
        public string role_code { get; set; }
        public string role_name { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public System.DateTime edit_date { get; set; }

    }
    // Distribution Method 
    public class CRM_M010_P
    {
        public int id { get; set; }
        public string distbt_mcode { get; set; }
        public string distbt_mname { get; set; }

    }

    //VMS Module
    public class VMS_M001_P
    {
        public string v_cat_code { get; set; }
        public string v_cat_desc { get; set; }

    }
    public class VMS_M002_P
    {
        public string vp_code { get; set; }
        public string vp_desc { get; set; }

    }
    public class VMS_M003_P
    {
        public string place_code { get; set; }
        public string place_desc { get; set; }
        public string place_id { get; set; }
    }
    public class VMS_M004_P
    {
        public string facility_code { get; set; }
        public string facility_desc { get; set; }
    }
    public class VMS_M005_P
    {
        public string gst_house_code { get; set; }
        public string gst_house_desc { get; set; }
    }
    public class VMS_M006_P
    {
        public string doc_code { get; set; }
        public string doc_desc { get; set; }
    }
    public class VMS_M007_P
    {
        public string m_cat_code { get; set; }
        public string m_cat_desc { get; set; }
    }
    public class VMS_M008_P
    {
        public string m_type_code { get; set; }
        public string m_type_desc { get; set; }
    }

    //General
    public class ADM_M053_P
    {
        public int address_id { get; set; }
        public string address_name { get; set; }
        public string party_id { get; set; }
        public string PartyId { get; set; }
        public string sol_type { get; set; }
        public string party_name { get; set; }
        public string abbr { get; set; }
        public string party_type { get; set; }
        public string party_group { get; set; }
        public string buss_type { get; set; }
        public string acc_group { get; set; }
        public string symbol { get; set; }
    }
    public class ADM_M054_P
    {
        public string cp_code { get; set; }
        public int id { get; set; }
        public string party_id { get; set; }
        public string sal_code { get; set; }
        public string f_name { get; set; }
        public string m_name { get; set; }
        public string l_name { get; set; }
        public string nick_name { get; set; }
        public string addr_code { get; set; }
        public string cp_code1 { get; set; }
        public string gender { get; set; }
        public byte[] photo { get; set; }
        public string ind_mar_status { get; set; }
        public string dept_code { get; set; }
        public string desig_code { get; set; }
        //Scalar
        public string buyer_name { get; set; }
        public string buyer { get; set; }
        public string addr_place { get; set; }
        public string person_no { get; set; }
        public string email_id { get; set; }
    }
    public class ADM_M055_P
    {
        public string addr_code { get; set; }
        public int id { get; set; }
        public string addr_type { get; set; }
        public string trans_code { get; set; }
        public string parent_id { get; set; }
        public string addr_place { get; set; }
        public string addr_line1 { get; set; }
        public string addr_line2 { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string state_code { get; set; }
        public string postal_code { get; set; }
        public string country_code { get; set; }
        public string land_mark { get; set; }
        public string map_link { get; set; }
        public string sat_view { get; set; }
        public string care_name { get; set; }
        public string train_station { get; set; }
        public string airport { get; set; }
        public string int_loc1 { get; set; }
        public string int_loc2 { get; set; }
        public string location_id { get; set; }
        public string ind_cust_supp { get; set; }
        public string time_zone { get; set; }
        public string city_def_lang { get; set; }
        public string city1 { get; set; }
        public string build_code { get; set; }
        public string build_floor { get; set; }
        public string room_no { get; set; }
        public string house_no { get; set; }
        public string add_house_no { get; set; }
        public string township { get; set; }
        public string addr_title { get; set; }
        public string language { get; set; }
    }
    public class ADM_M055_A_P
    {
        public string add_type_code { get; set; }
        public string add_type_name { get; set; }
    }
    public class ADM_M057_A_P
    {
        public string type_code { get; set; }
        public string type_name { get; set; }
    }
    public class ADM_M057_P
    {
        public string acc_id { get; set; }
        public int id { get; set; }
        public string trans_code { get; set; }
        public string parent_id { get; set; }
        public string type_code { get; set; }
        public string sub_type { get; set; }
        public string ind_primary { get; set; }
        public string contact_no { get; set; }
        public string ext_no { get; set; }
        public string acc_name { get; set; }
        public string desc { get; set; }
        public string ass_contact_no { get; set; }
        public string ind_phone { get; set; }
        public string ind_pref_contact { get; set; }
        public string ind_def { get; set; }
        public Nullable<System.DateTime> valid_fdate { get; set; }
        public string seq_no { get; set; }
        public string cntry_tel_fax { get; set; }
        public string ind_sms_enable { get; set; }
        public string complete_phno { get; set; }
    }

    public class ADM_M058_A_P
    {
        public string ItemCode { get; set; }
        public decimal? calc_value { get; set; }
        public string wt_unit { get; set; }
        public string obj_name { get; set; }
        public decimal? qty { get; set; }
        public string unit_code { get; set; }
    }
    public class ADM_M063_P
    {
        public string report_declr { get; set; }
        public string declaration { get; set; }
        public string declaration_type { get; set; }
    }

    #region Asset Accounting Module PopUps And Flip Classes

    public class ACC_M002_Flip //Asset Master Flip
    {
        public string asset_no { get; set; }
        public string asset_class { get; set; }
        public string asset_name { get; set; }
        public string asset_sub_no { get; set; }
    }

    public class ACC_M002_K_Flip  //Depreciation Key Master Flip
    {
        public string dep_key { get; set; }
        public string dk_status { get; set; }
        public string dep_key_desc { get; set; }
    }

    public class ACC_M002_K_P  //Depreciation Key Master Flip
    {
        public string dep_key { get; set; }
        public string dk_status { get; set; }
        public string dep_key_desc { get; set; }
    }

    public class ACC_M002_D_Flip  //Asset Class And Area Assignment Flip
    {
        public string asset_class { get; set; }
        public int dep_area { get; set; }
        public string dep_key { get; set; }
    }
    public class ACC_M002_R_Flip  //Asset Area Master Flip
    {
        public string cod { get; set; }
        public int dep_area { get; set; }
        public string dep_area_desc { get; set; }
    }

    public class ACC_M002_R_P  //Asset Area Master PopUp List
    {
        public int dep_area { get; set; }
        public string dep_area_desc { get; set; }
    }
    public class ACC_M002_C_Flip  //Asset Class Master Flip
    {
        public string asset_class { get; set; }
        public string asset_name { get; set; }
        public string asset_desc { get; set; }
    }
    public class ACC_M002_C_P     //Asset Class Master PopUp
    {
        public string asset_class { get; set; }
        public string asset_name { get; set; }
        public string asset_desc { get; set; }
    }
    public class ACC_M023_P       //Depreciation Keys - Method Assignment
    {

    }
    public class ACC_M023_A_P     //Base Method
    {
        public string base_mthd { get; set; }
        public string base_mthd_desc { get; set; }
        public string dep_type { get; set; }
        public string cal_mthd { get; set; }
        public string cal_mthd_desc { get; set; }
    }
    public class ACC_M023_B_P     //Declining-Balance Method 
    {
        public string dbm { get; set; }
        public string dbm_desc { get; set; }
    }
    public class ACC_M023_C_P     //Period Control Method 
    {
        public string pcm { get; set; }
        public string pcm_desc { get; set; }
    }
    public class ACC_M023_D_P     //Multilevel Method
    {
        public string mm { get; set; }
        public string vldty_strt { get; set; }
        public string mm_desc { get; set; }
    }
    public class ACC_M023_E_P     //Maximum amount method
    {
        public string mam { get; set; }
        public string max_dep_amnt { get; set; }
        public string mam_desc { get; set; }
    }
    public class ACC_M023_F_P     //Calculation Methods Master for base methods 
    {
        public string cal_mthd { get; set; }
        public string cal_mthd_desc { get; set; }
    }
    public class ACC_M023_H_P     //CutOff Value Key
    {
        public string cutoff_val_key { get; set; }
        public string vldty_srt_prd { get; set; }
        public string ind_svd { get; set; }
    }
    public class ACC_M002_J_P // Chart of Depreciation List
    {
        public string cod { get; set; }
        public string orgnl_cod { get; set; }
        public string cod_desc { get; set; }
    }
    public class ACC_M002_L_P     //FI-AA Standard Account Determination
    {
        public string acc_dtr { get; set; }
        public string val_grp_code { get; set; }
        public string symbolic_acc { get; set; }
        public string acc_dtr_desc { get; set; }
    }

    #endregion

    //HRM Module
    public class HRM_M015_P     //Gate No
    {
        public string ter_id { get; set; }
        public string ter_desc { get; set; }
        public string equ_id { get; set; }
        public string ter_location { get; set; }
    }

    public class ACC_M025_A_P
    {
        public string wtax_type { get; set; }
        public string wtax_type_desc { get; set; }

    }

    public class ADM_M028_I_Flip
    {
        public string PartyId { get; set; }
        public string wtax_type { get; set; }
        public string wtax_code { get; set; }
        public string exemption_no { get; set; }
        public string exemption_rate { get; set; }
    }

    //HRMS Module
    public class HRM_M002_P   //Relationship master
    {
        public string rele_code { get; set; }
        public string rela_name { get; set; }
    }
    public class HRM_M003_P   //Profession master
    {
        public string prof_code { get; set; }
        public string prof_name { get; set; }
    }
    public class HRM_M004_P   //Type of Employment Master
    {
        public string empl_type { get; set; }
        public string empl_type_name { get; set; }
        public string unit { get; set; }
        public string value { get; set; }
    }
    public class HRM_M005_P   //Additional Activities Type
    {
        public string act_type { get; set; }
        public string act_title { get; set; }
    }
    public class HRM_M016_P   //Additional Activities Type
    {
        public string equ_id { get; set; }
        public string equ_name { get; set; }
    }
    public class SYS_P001_P   //Status 
    {
        public string t_status { get; set; }
        public string status_name { get; set; }
    }
    public class HRM_M008_P //Request Code
    {
        public string request_type { get; set; }
        public string req_type_desc { get; set; }
    }
    public class HRM_M009_P //Reason Code
    {
        public string reason_code { get; set; }
        public string reason_type { get; set; }
    }
    public class HRM_M009_A_P //Reason Code
    {
        public string sub_reason_code { get; set; }
        public string sub_reason_type { get; set; }
        public string reason_code { get; set; }

    }
    public class SYS_M022_P //Document Type
    {
        public string doc_type { get; set; }
        public string doc_type_name { get; set; }
        public string doc_cat { get; set; }
    }
    public class SYS_M021_P //Document Category
    {
        public string doc_cat { get; set; }
        public string cat_name { get; set; }
    }
    public class HRM_M008_A_P // Sub Request Code
    {
        public string sub_req_type { get; set; }
        public string sub_req_desc { get; set; }
        public string request_type { get; set; }
    }
    public class SYS_M033_P // Sub Request Code
    {
        public string day_code { get; set; }
        public string day_type { get; set; }

    }
    public class SYS_M034_P // Sub Request Code
    {
        public string obj_type { get; set; }
        public string obj_type_desc { get; set; }

    }

    public class HRM_M010_P // Pop up for Religion
    {
        public string reli_code { get; set; }
        public string reli_name { get; set; }
    }
    public class HRM_M012_P // Pop up for Cast
    {
        public string cast_code { get; set; }
        public string cast_name { get; set; }
    }
    public class HRM_M011_P // Pop up for catagory of cast
    {
        public string cat_code { get; set; }
        public string cat_name { get; set; }
    }
    public class HRM_M021_P // Pop up for Physical Disability
    {
        public string phy_dis { get; set; }
        public string phy_dis_nm { get; set; }
    }
    public class HRM_M022_P // Pop up for Language  
    {
        public string language_key { get; set; }
        public string language_desc { get; set; }
    }

    public class SearchEntity
    {
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public DateTime? from_date { get; set; }
        public DateTime? to_date { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string unit_code { get; set; }
        public string CatCode { get; set; }
        public string CatName { get; set; }
        public string SubCatCode { get; set; }
        public string SubCatName { get; set; }
        public bool active { get; set; }
        public string doc_no { get; set; }
        public string ref_doc_no { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
        public string PartyId { get; set; }
        public string location_Id { get; set; }
        public string EmpId { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
    }

    public partial class OrderItemData
    {
        public bool Select { get; set; }
        public int id { get; set; }
        public string order_no { get; set; }
        public Nullable<System.DateTime> order_date { get; set; }
        public DateTime? doc_date { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public int line_id { get; set; }
        public string ItemCode { get; set; }
        public string description { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> appr_qty { get; set; }
        public Nullable<decimal> cost { get; set; }
        public Nullable<System.DateTime> expected_date { get; set; }
        public string note { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string ItemCat { get; set; }
        public string item_cat { get; set; }
        public string textdata { get; set; }
        public string ItemCatName { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string bom_no { get; set; }
        public string t_display { get; set; }
        public string color_code { get; set; }
        public string requester { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string to_item_row_id { get; set; }
        public string sch_item_row_id { get; set; }
        public string supplying_plant { get; set; }
        public string rec_plant { get; set; }
        public string so_code { get; set; }
        public string curr_code { get; set; }
        public int del_address { get; set; }
        public string p_term_code { get; set; }
        public string incoterms { get; set; }
        public string country_nm_s { get; set; }
        public string cust_ref { get; set; }
    }

    public class PUR_T002_A_P// NOTE: replace with REF_DOC_MM_T001
    {
        public string po_no { get; set; }
        public DateTime? po_date { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string PartyId { get; set; }
        public string SupplierNm { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public decimal? qty { get; set; }
        public string supplantnm { get; set; }
        public string recplantnm { get; set; }
        public bool select { get; set; }
        public string location_Id { get; set; }
        public string color_code { get; set; }
        public string t_display { get; set; }
        public string party_ref_no { get; set; }
        public string delivery_no { get; set; }
    }
    public class REF_DOC_MM_T001 //Reference Documents For MM_T001
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string supplying_plant { get; set; }
        public string receiving_plant { get; set; }
        public string doc_cat { get; set; }
        public string doc_cat_name { get; set; }
        public string doc_type { get; set; }
        public string doc_type_name { get; set; }
        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public DateTime? posting_date { get; set; }
        public string party_id { get; set; }
        public string party_name { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string sku { get; set; }
        public decimal? qty { get; set; }
        public string color_code { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
        public string party_ref_no { get; set; }
        public DateTime? party_ref_date { get; set; }

    }

}

