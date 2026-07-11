using System;

namespace Reflection.EF.QMS
{
    public partial class QMS_T002 : ObjectBase
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string barcode { get; set; }
        public System.DateTime doc_date { get; set; }
        public string serv_type { get; set; }
        public string ref_doc_no { get; set; }
        public string inst_code { get; set; }
        public string inst_id { get; set; }
        public string model_no { get; set; }
        public string inst_name { get; set; }
        public int? qty { get; set; }
        public decimal? least_count { get; set; }
        public string inst_make { get; set; }
        public string range { get; set; }
        public decimal? accuracy_up { get; set; }
        public string unit_code { get; set; }
        public string tech_spec { get; set; }
        public string sp_remark1 { get; set; }
        public string sp_remark2 { get; set; }
        public string sent_cf_to { get; set; }
        public string inst_cond { get; set; }
        public string remark { get; set; }
        public string cal_type { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public bool? active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string lang_key { get; set; }
        public string test_code { get; set; }
        public string inst_srno { get; set; }
        public DateTime? req_date { get; set; }
        public DateTime? exp_date { get; set; }
        public int? ref_item_row_id { get; set; }
        public DateTime? last_date { get; set; }
        public int? cal_freq { get; set; }
        public string cal_period { get; set; }
        public DateTime? next_date { get; set; }
        public DateTime? due_date { get; set; }
        public string lab_code { get; set; }
        public string insp_lot_no { get; set; }
        public string sono { get; set; }
        public string cont_per_name { get; set; }
        public int ContInfoId { get; set; }
        public string po_no { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_type { get; set; }
        public int? ref_item_line_id { get; set; }
        public string ItemCode { get; set; }
        public string so_doc_cat { get; set; }
        public string so_doc_type { get; set; }
        public int? so_item_line_id { get; set; }
        public int? so_item_row_id { get; set; }
        public decimal? resolution { get; set; }
        public string insp_cat { get; set; }
        public string range_unit { get; set; }
        public string accuracy_up_unit { get; set; }
        public string least_count_unit { get; set; }
        public string resolution_unit { get; set; }
        public decimal? upper_range { get; set; }
        public decimal? lower_range { get; set; }
        public string upper_range_unit { get; set; }
        public string lower_range_unit { get; set; }
        public decimal? accuracy_down { get; set; }
        public string accuracy_down_unit { get; set; }
        public string grn_no { get; set; }
        public int? grn_item_row_id { get; set; }

        // Scalar
        public string lab_name { get; set; }
        public string TranCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string test_name { get; set; }
        public string cust_name { get; set; }
        public string assigned_to { get; set; }
        public string assigned_to_name { get; set; }
    }

    public partial class QMS_T002_A
    {
        public int id { get; set; }
        public string ItemCode { get; set; }
        public string doc_no { get; set; }
        public string ItemId { get; set; }
        public string ItemScope { get; set; }
        public string ItemType { get; set; }
        public bool? active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string ItemName { get; set; }
    }

    public partial class QMS_T002_B
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string inst_code { get; set; }
        public string insp_lot_no { get; set; }
        public string inst_id { get; set; }
        public string inst_name { get; set; }
        public int qty { get; set; }
        public DateTime? completion_date { get; set; }
        public DateTime? exp_date { get; set; }
        public bool? active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string po_no { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_type { get; set; }
        public int? ref_item_line_id { get; set; }
        public int? ref_item_row_id { get; set; }
        public string sono { get; set; }
        public string so_doc_cat { get; set; }
        public string so_doc_type { get; set; }
        public int? so_item_line_id { get; set; }
        public int? so_item_row_id { get; set; }
        public string inst_srno { get; set; }
        public string model_no { get; set; }
        public decimal? least_count { get; set; }
        public string inst_make { get; set; }
        public string inst_cond { get; set; }
        public string range { get; set; }
        public decimal? accuracy_up { get; set; }
        public decimal? accuracy_down { get; set; }
        public decimal? resolution { get; set; }
        public string insp_cat { get; set; }
        public string range_unit { get; set; }
        public string accuracy_up_unit { get; set; }
        public string accuracy_down_unit { get; set; }
        public string least_count_unit { get; set; }
        public string resolution_unit { get; set; }
        public decimal? upper_range { get; set; }
        public decimal? lower_range { get; set; }
        public string upper_range_unit { get; set; }
        public string lower_range_unit { get; set; }
        public DateTime? last_date { get; set; }
        public int? cal_freq { get; set; }
        public string cal_period { get; set; }
        public DateTime? next_date { get; set; }
        public DateTime? due_date { get; set; }
        //Scalar        
        public int srno { get; set; }
    }

    public partial class QMS_T002_C
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string inst_code { get; set; }
        public string test_code { get; set; }
        public string EmpId { get; set; }
        public int sample_row_id { get; set; }
        public DateTime? completion_date { get; set; }
        public DateTime? exp_date { get; set; }
        public bool? active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string lab_code { get; set; }
        public string assigned_to { get; set; }
        //scalar
        public int srno { get; set; }
        public string insp_type_name { get; set; }
        public string test_name { get; set; }
        public string lab_name { get; set; }
        public string assigned_to_name { get; set; }
    }

    public partial class QMS_T002_D
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string para_code { get; set; }
        public string value_code { get; set; }
        public string para_name { get; set; }
        public string para_value { get; set; }
        public string unit_code { get; set; }
        public bool? active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
    }
}
