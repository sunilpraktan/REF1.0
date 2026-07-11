using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production
{
    public partial class EPR_T002 : ObjectBase
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public DateTime? entry_dt { get; set; }
        public DateTime? prod_dt { get; set; }
        public string ItemCode { get; set; }
        public int pack_style { get; set; }
        public int? ink_id { get; set; }
        public int? ild_id { get; set; }
        public string batch_no { get; set; }
        public int? machine_id { get; set; }
        public string machinecode { get; set; }
        public string shift { get; set; }
        public string conversion { get; set; }
        public decimal counter_qty { get; set; }
        public decimal? a_qty { get; set; }
        public decimal? b_qty { get; set; }
        public decimal? c_qty { get; set; }
        public decimal tip_wt_1 { get; set; }
        public decimal tip_wt_2 { get; set; }
        public decimal tip_wt_3 { get; set; }
        public decimal? tip_ave_wt { get; set; }
        public decimal? blank_wt { get; set; }
        public string unit_code { get; set; }
        public int? wire_make { get; set; }
        public int? ball_make { get; set; }
        public bool? auto_sort { get; set; }
        public bool? breakdown { get; set; }
        public string starttime { get; set; }
        public string endtime { get; set; }
        public string breakdown_reason { get; set; }
        public int? no_of_bags { get; set; }
        public string CustomerProductName { get; set; }
        public bool? active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string conversion_no { get; set; }
        public decimal rejection_qty { get; set; }
        public string grade { get; set; }
        public string PartyId { get; set; }
        public string m_operator { get; set; }
        public string shift_incharge { get; set; }
        public string barcode { get; set; }
        public string wc_code { get; set; }
        public int? doc_counter { get; set; }
        public int? object_id { get; set; }
        public string lang_key { get; set; }
        public decimal? break_time { get; set; }
        public string break_time_uom { get; set; }
        public decimal? ac_work { get; set; }
        public string ac_work_uom { get; set; }
        public decimal? ac_duration { get; set; }
        public string ac_duration_uom { get; set; }
        public string activity_type { get; set; }
        public string wage_type { get; set; }
        public string wage_group { get; set; }
        public int? emp_no { get; set; }
        public decimal? prev_yield { get; set; }
        public decimal? yield { get; set; }
        public decimal? scrap_qty { get; set; }
        public decimal? rework_qty { get; set; }
        public string var_reson { get; set; }
        public string emp_id { get; set; }
        public DateTime? execution_start { get; set; }
        public DateTime? finish_setup { get; set; }
        public DateTime? process_start { get; set; }
        public DateTime? process_finish { get; set; }
        public DateTime? teardown_start { get; set; }
        public DateTime? execution_finish { get; set; }
        public string conf_type { get; set; }
        public string routing_no { get; set; }
        public int? order_counter { get; set; }
        public string order_no { get; set; }
        public int? order_seq { get; set; }
        public string operation_no { get; set; }
        public string sub_op_no { get; set; }
        public int? op_line_id { get; set; }
        public int? op_seq { get; set; }
        public decimal? op_qty { get; set; }
        public string cost_center { get; set; }
        public string profit_center { get; set; }
        public string party_batch_no { get; set; }
        public string mat_doc_no { get; set; }
        public string ref_doc_no { get; set; }
        public int? ref_doc_item_row_id { get; set; }
        public string ref_doc_cat { get; set; }
        public DateTime? post_date { get; set; }
        public string record_type { get; set; }
        public string total_time { get; set; }
        public string store_code { get; set; }
        public string ind_batch { get; set; }
        public string ind_receipt { get; set; }
        public string sku { get; set; }
        public decimal? packing_qty { get; set; }
        public string control_key { get; set; }
        public string project_id { get; set; }
        public string element_id { get; set; }
        public int? element_no { get; set; }

        public string long_text { get; set; }

        //Scalar
        public string doc_no_op { get; set; } // Document no of operation/activity
        public string order_type { get; set; }
        public string PartyNm { get; set; }
        public string Ink { get; set; }
        public string Ild { get; set; }
        public string BallMake { get; set; }
        public string WireMake { get; set; }
        public string PackingUnit { get; set; }
        public Nullable<decimal> WireSize { get; set; }
        public string WireType { get; set; }
        public Nullable<decimal> BallSize { get; set; }
        public string BallType { get; set; }
        public string TipLen { get; set; }
        public Nullable<bool> check { get; set; }
        public string ItemName { get; set; }
        public string InchargeNm { get; set; }
        public string OperatorNm { get; set; }
        public string bdr_desc { get; set; }
        public bool? ProductionEntryExists { get; set; }
        public string t_display { get; set; }
        public decimal? final_qty { get; set; }
        public string prev_batch { get; set; }
        public decimal? batch_qty { get; set; }
        public decimal? batch_qty_balance { get; set; }
        public decimal? yield_total { get; set; }
        public decimal? rework_total { get; set; }
        public decimal? scrap_total { get; set; }
        public decimal? op_bal_qty { get; set; }
    }

    public partial class EPR_T002_A
    {
        public int id { get; set; }
        public Nullable<int> lg_line_id { get; set; }
        public string barcode { get; set; }
        public string batch_no { get; set; }
        public Nullable<decimal> label_qty { get; set; }
        public string grade { get; set; }
        public Nullable<decimal> bal_qty_merge { get; set; }
        public Nullable<bool> prod_entry_stat { get; set; }
        public Nullable<bool> carton_cons_stat { get; set; }
        public Nullable<bool> label_complete_stat { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string doc_no { get; set; }
        public string merge_status { get; set; }
        public string parent_label { get; set; }
        public string t_status { get; set; }
        public Nullable<decimal> merge_qty { get; set; }
        public string cust_batch_no { get; set; }
    }

    public partial class EPR_T002_B
    {
        public int id { get; set; }
        public string new_batch_no { get; set; }
        public string old_batch_no { get; set; }
        public Nullable<decimal> qty { get; set; }
    }

    public partial class EPR_T002_S
    {
        public bool auto_merge { get; set; }
        public string batch_no_format { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public int range1 { get; set; }
        public int doc_no_digits { get; set; }
        public string doc_type { get; set; }
        public string report_name { get; set; }
        public bool auto_prodentry { get; set; }
        public bool auto_goodsrec { get; set; }
        public string report2 { get; set; }
        public string scan_source { get; set; }
        public int min_length { get; set; }

    }
    public class OperationList
    {
        public string order_no { get; set; }
        public string routing_no { get; set; }
        public string op_code { get; set; }
        public string operation_desc { get; set; }
        public string operation_no { get; set; }
        public string sub_op_no { get; set; }
        public int? line_id { get; set; }
        public string wc_code { get; set; }
        public string control_key { get; set; }
    }

    public class MIS_STD_PPC_1
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string routing_no { get; set; }
        public string bom_no { get; set; }
        public string op_code { get; set; }
        public string operation_no { get; set; }
        public string operation_desc { get; set; }
        public string sub_op_no { get; set; }
        public string wc_code { get; set; }
        public string order_no { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string unit_code { get; set; }
        public decimal? order_qty { get; set; }
        public decimal? issue_qty { get; set; }
        public decimal? bal_qty { get; set; }
        public decimal? consumption_qty { get; set; }
        public decimal? curr_stock_qty { get; set; }
        public decimal? required_qty { get; set; }
        public decimal? yield { get; set; }
        public decimal? scrap_qty { get; set; }
        public decimal? rework_qty { get; set; }
        public string t_display { get; set; }
        public DateTime? prod_dt { get; set; }
        public DateTime? start_dt { get; set; }
        public DateTime? end_dt { get; set; }
        public string m_operator { get; set; }
        public string shift_incharge { get; set; }
        public string conf_type { get; set; }
        public string record_type { get; set; }
        public string shift { get; set; }
        public string var_reson { get; set; }
        public string reson_desc { get; set; }
        public string batch_no { get; set; }
        public string barcode { get; set; }
        public DateTime? doc_date { get; set; }
        public string total_time { get; set; }
        public string wc_name { get; set; }
        public string store_code { get; set; }
        public decimal? final_qty { get; set; }
        public string prv_batch { get; set; }
        public decimal? ac_duration { get; set; }
        public string ac_duration_uom { get; set; }
        public decimal? bd_duration { get; set; } // Breakdown duretion
        public string bd_duration_uom { get; set; } // Breakdown duretion uom
    }
}
