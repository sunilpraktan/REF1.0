using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class SEL_T004 : ObjectBase
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string client { get; set; }
        public string wa_code { get; set; }
        public string mov_tp { get; set; }
        public string mov_type_wh { get; set; }
        public string to_priority { get; set; }
        public string shipping_type { get; set; }
        public string shipping_type_name { get; set; }
        public string to_time { get; set; }
        public string sgroup { get; set; }
        public string to_req_no { get; set; }
        public string delivery_no { get; set; }
        public string confirm_ind { get; set; }
        public Nullable<System.DateTime> confirm_date { get; set; }
        public string mat_doc_no { get; set; }
        public Nullable<int> mat_doc_year { get; set; }
        public string req_type { get; set; }
        public string req_no { get; set; }
        public string print_ind { get; set; }
        public string pre_plan_to { get; set; }
        public Nullable<System.DateTime> plan_ex_date { get; set; }
        public string add_ref_no { get; set; }
        public Nullable<decimal> plan_time { get; set; }
        public Nullable<decimal> actual_time { get; set; }
        public string time_unit { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string wh_door { get; set; }
        public string wh_staging_area { get; set; }
        public Nullable<int> th_act_time { get; set; }
        public string sd_doc_cat { get; set; }
        public string queue { get; set; }
        public string pick_confirm { get; set; }
        public Nullable<int> item_no_curr { get; set; }
        public string confirm_delivery { get; set; }
        public string to_multiple { get; set; }
        public string to_note { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string PartyNm { get; set; }
        public string del_address { get; set; }
        public string ref_doc_cat { get; set; }
        public string ship_to_party { get; set; }
        public string sold_to_party { get; set; }
        public string dispatch_time { get; set; }
        public string pickup_time { get; set; }
        public Nullable<System.DateTime> way_bill_date { get; set; }
        public Nullable<System.DateTime> client_del_receive_date { get; set; }
        public string way_bill_no { get; set; }
        public decimal? way_bill_value { get; set; }
        public Nullable<System.DateTime> order_date { get; set; }
        public Nullable<System.DateTime> SO_date;
        public string sono;
        public string ship_to_party_name { get; set; }
        public string PartyId { get; set; }
        public string t_display { get; set; }
        public string transporter_name { get; set; }
        public string transporter_cd { get; set; }
        public string shipping_mark { get; set; }
        public string ship_to_add { get; set; }
        public Nullable<System.DateTime> dispatch_date;
        public string tr_mode { get; set; }
        public string tr_party { get; set; }
        public string tr_type { get; set; }
        public string ts_code { get; set; }
        public string remark { get; set; }
        public string ship_to_address_location { get; set; }
        public string add_info { get; set; }
        public string add_code_del { get; set; }
        public string gstinno { get; set; }
    #region Scalars for Filtering View

        public string fltr_location_Id { get; set; }
        public string fltr_t_status { get; set; }
        public string fltr_t_display { get; set; }
        public string fltr_SoldToPartyID { get; set; }
        public string fltr_SoldToPartyNM { get; set; }
        public string fltr_SalesPersonID { get; set; }
        public string fltr_SalesPersonNM { get; set; }
        public DateTime? Fltr_FrmDate { get; set; }
        public DateTime? Fltr_ToDate { get; set; }
        public bool Fltr_active { get; set; }

        #endregion 
    }
    public partial class SEL_T004_A
    {
        public Nullable<System.DateTime> cust_po_date;
        public string cust_po_no;
        public int id { get; set; }
        public int line_id { get; set; }
        public string client { get; set; }
        public string wa_code { get; set; }
        public string doc_no { get; set; }
        public Nullable<int> item_code { get; set; }
        public Nullable<int> to_req_item { get; set; }
        public Nullable<int> sd_item_no { get; set; }
        public string ItemCode { get; set; }
        public string location_Id { get; set; }
        public string batch_no { get; set; }
        public string stock_cat { get; set; }
        public string sp_stock { get; set; }
        public string sp_number { get; set; }
        public string haz_material { get; set; }
        public string unit_code { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string unit_alt { get; set; }
        public Nullable<decimal> c_factor { get; set; }
        public Nullable<decimal> denom { get; set; }
        public string storage_unit_type { get; set; }
        public string pre_stock_ind { get; set; }
        public Nullable<int> sequence_item { get; set; }
        public string confirm_req { get; set; }
        public string confirm_complete_ind { get; set; }
        public Nullable<System.DateTime> confirm_date { get; set; }
        public string confirm_time { get; set; }
        public Nullable<decimal> gross_wt { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public string weight_unit { get; set; }
        public Nullable<int> item_mat_doc { get; set; }
        public string gr_ship_to_party { get; set; }
        public string unloading_point { get; set; }
        public Nullable<System.DateTime> gr_date { get; set; }
        public string gr_no { get; set; }
        public Nullable<int> gr_item { get; set; }
        public string cert_no { get; set; }
        public string trns_pro { get; set; }
        public string storage_type { get; set; }
        public string storage_sec { get; set; }
        public string storage_bin { get; set; }
        public Nullable<int> quant { get; set; }
        public string dest_storage_type { get; set; }
        public string dest_storage_sec { get; set; }
        public string dest_storage_bin { get; set; }
        public string pick_area { get; set; }
        public string store_code { get; set; }
        public Nullable<decimal> volume { get; set; }
        public string volume_unit { get; set; }
        public string pick_confirm { get; set; }
        public Nullable<System.DateTime> pick_confirm_date { get; set; }
        public string pick_confirm_time { get; set; }
        public string pack_material { get; set; }
        public string confirm_data_trns { get; set; }
        public string delivery { get; set; }
        public string t_status { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string ItemName { get; set; }
        public Nullable<System.DateTime> exp_date { get; set; }
        public string sch_no { get; set; }
        public string sono { get; set; }
        public string schedule_item_row_id { get; set; }
        public string order_item_row_id { get; set; }
        public string remark { get; set; }
        public decimal? unit_price { get; set; }
        public string symbol { get; set; }
    }
}
