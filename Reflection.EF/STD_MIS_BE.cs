using Reflection.EF.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF
{
    public class STD_MIS_BE : ObjectBase
    {
        public string comp_code { get; set; }
        public string comp_name { get; set; }
        public string location_id { get; set; }
        public string add_text { get; set; } //address details
        public int? serial_no { get; set; }
        public string sl_no { get; set; }
        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public DateTime? post_date { get; set; }
        public DateTime? bill_date { get; set; }
        public DateTime? released_date { get; set; }
        public string billing_doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_type { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
        public string ref_doc_no { get; set; }
        public DateTime? ref_doc_date { get; set; }
        public string party_code { get; set; }
        public string party_type { get; set; }
        public string party_code2 { get; set; }
        public string party_name { get; set; }
        public string party_name2 { get; set; }
        public string curr_code { get; set; }
        public string curr_code_sd { get; set; } // Currency of Sales Document
        public string curr_code_pd { get; set; } // Currency of Purchase Document
        public string tax_reg_no { get; set; }
        public string buss_place { get; set; }
        
        public string symbol { get; set; }
        public decimal? document_value { get; set; }
        public string location { get; set; }
        public string emp_code { get; set; }
        public string country_key { get; set; }
        public string ctry_key { get; set; }
        public string po_code { get; set; }
        public string po_name { get; set; }
        public string pg_code { get; set; }
        public string pg_name { get; set; }
        public string so_code { get; set; }
        public string so_name { get; set; }
        public string sg_code { get; set; }
        public string sg_name { get; set; }
        public string org_code { get; set; }
        public string org_name { get; set; }
        public string group_code { get; set; }
        public string group_name { get; set; }
        public decimal? qty { get; set; }
        public decimal? qty1 { get; set; }
        public decimal? qty2 { get; set; }
        public decimal? qty3 { get; set; }
        public decimal? unit_price { get; set; }
        public decimal? unit_price_lc { get; set; } // Unit Price Local Currency
        public string bom_no { get; set; }
        public string routing_no { get; set; }
        public string plan_no { get; set; }
        public string item_code { get; set; }
        public string item_code_party { get; set; }
        public string item_name { get; set; }
        public string item_name_party { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string item_cat { get; set; }
        public string item_subcat { get; set; }
        public string unit_code { get; set; } // Only Use this for selection and use coalesce to get appropriate unit as unit_code i.e in SD use COALESCE(sales_unit,unit_code) AS unit_code
        public string base_unit { get; set; }
        public string weight_unit { get; set; }
        public string volume_unit { get; set; }
        public decimal? volume { get; set; }
        public decimal? gross_wt { get; set; }
        public decimal? net_wt { get; set; }
        public string tax_id { get; set; }
        public string hsn_code { get; set; }
        public string hsn_group_code { get; set; }
        public string hsn_group_name { get; set; }
        public string order_no { get; set; }
        public decimal? order_qty { get; set; }
        public decimal? order_value { get; set; }
        public decimal? order_value_bal { get; set; }
        public decimal? ov_bal_lc { get; set; } // Order value balance in local currency
        public decimal? order_qty_bal { get; set; }
        public string sd_doc_no { get; set; }

        public string in_no { get; set; }
        public DateTime? in_date { get; set; }
        public decimal? in_qty { get; set; }
        public decimal? in_qty_bal { get; set; }
        public decimal? in_price { get; set; }
        public decimal? in_price_lc { get; set; }
        public decimal? in_value { get; set; }
        public decimal? in_value_lc { get; set; }
        public decimal? in_value_bal { get; set; }

        public string inv_no { get; set; }
        public DateTime? inv_date { get; set; }
        public decimal? inv_qty { get; set; }
        public decimal? inv_qty_bal { get; set; }
        public decimal? inv_price { get; set; }
        public decimal? inv_price_lc { get; set; }
        public decimal? inv_value { get; set; }
        public decimal? inv_value_lc { get; set; }
        public decimal? inv_value_bal { get; set; }

        public string qp_no { get; set; }
        public DateTime? qp_date { get; set; }
        public decimal? qp_qty { get; set; }
        public decimal? qp_qty_bal { get; set; }
        public decimal? qp_price { get; set; }
        public decimal? qp_price_lc { get; set; }
        public decimal? qp_value { get; set; }
        public decimal? qp_value_lc { get; set; }
        public decimal? qp_value_bal { get; set; }

        public string po_party { get; set; }
        public string po_no { get; set; }
        public DateTime? po_date { get; set; }
        public decimal? po_qty { get; set; }
        public decimal? po_qty_bal { get; set; }
        public decimal? po_price { get; set; }
        public decimal? po_price_lc { get; set; }
        public decimal? po_value { get; set; }
        public decimal? po_value_lc { get; set; }
        public decimal? po_value_bal { get; set; }

        public string grn_no { get; set; }
        public int? op_seq { get; set; }
        public string operation_no { get; set; }
        public decimal? dc_value1 { get; set; }
        public decimal? dc_value2 { get; set; }
        public decimal? dc_value3 { get; set; }
        public decimal? dc_value4 { get; set; }
        public decimal? dc_value5 { get; set; }
        public decimal? dc_value6 { get; set; }
        public decimal? dc_value7 { get; set; }
        public decimal? dc_value8 { get; set; }
        public decimal? dc_value9 { get; set; }
        public decimal? dc_value10 { get; set; }
        public string doc_type_user { get; set; }
        public string doc_desc { get; set; }
        public string doc_desc_user { get; set; }
        public string report_name { get; set; }
        public DateTime? add_date { get; set; }
        public string sending_plant { get; set; }
        public string rec_plant { get; set; }
        public string store_code { get; set; }
        public string mov_tp { get; set; }
        public string debcr_ind { get; set; }
        public string sono { get; set; }
        public string order_doc_cat { get; set; }
        public string order_doc_type { get; set; }
        public string t_status_2 { get; set; }
        public bool? active { get; set; }
        public string notes { get; set; }
        public decimal? effective_value { get; set; }
        public decimal? gross_value { get; set; }
        public decimal? net_value { get; set; }
        public decimal? ev_lc { get; set; } //effective_value Local Currency
        public decimal? gv_lc { get; set; } //gross_value Local Currency
        public decimal? nv_lc { get; set; } //net_value Local Currency
        public decimal? ov_lc { get; set; } //Order Value Local Currency
        public decimal? tax_value { get; set; }
        public decimal? tax_amount { get; set; }
        public decimal? withhold_tax_value { get; set; }
        public decimal? other_charges { get; set; }
        public decimal? oc_lc { get; set; } //Other Charges Value Local Currency
        public decimal? discount { get; set; }
        public decimal? discount_lc { get; set; } //discount Value Local Currency
        public decimal? discount_value { get; set; }
        public decimal? dv_lc { get; set; } //Discount Vale Local Currency
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string para5 { get; set; }
        public string para6 { get; set; }
        public string para7 { get; set; }
        public string para8 { get; set; }
        public string para9 { get; set; }
        public string para10 { get; set; }
        public decimal? para_value1 { get; set; }
        public decimal? para_value2 { get; set; }
        public decimal? para_value3 { get; set; }
        public DateTime? order_date { get; set; }
        public string party_ref_no { get; set; }
        public DateTime? party_ref_date { get; set; }
        public string party_ref_doc_no { get; set; } // Depricate
        public DateTime? party_ref_doc_date { get; set; } // Depricate
        public string project_id { get; set; }
        public string project_name { get; set; }
        public string element_id { get; set; }
        public string element_name { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public int? id { get; set; }
        public DateTime? prod_dt { get; set; }
        public decimal? req_qty { get; set; }
        public DateTime? plan_date { get; set; }
        public decimal? plan_qty { get; set; }
        public decimal? plan_rate { get; set; }
        public decimal? plan_value { get; set; }
        public int? row_id { get; set; }
        public int? ref_row_id { get; set; }
        public int? bom_item_row_id { get; set; }
        public int? order_item_row_id { get; set; }
        public int? sd_item_row_id { get; set; }
        public int? po_item_row_id { get; set; }
        public int? sch_item_row_id { get; set; }
        public int? dn_item_row_id { get; set; }
        public int? grn_item_row_id { get; set; }
        public int? item_row_id { get; set; }
        public string operation_desc { get; set; }
        public int? plan_counter { get; set; }
        public int? counter1 { get; set; }
        public string mov_tp_name { get; set; }
        public string order_type { get; set; }
        public string batch_no { get; set; }
        public decimal? batch_qty { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public decimal? open_qty { get; set; }
        public decimal? open_rate { get; set; }
        public decimal? open_value { get; set; }
        public decimal? purchase_qty { get; set; }
        public decimal? purchase_rate { get; set; }
        public decimal? purchase_value { get; set; }
        public decimal? issue_qty { get; set; }
        public decimal? issue_rate { get; set; }
        public decimal? issue_value { get; set; }
        public decimal? receipt_qty { get; set; }
        public decimal? receipt_rate { get; set; }
        public decimal? receipt_value { get; set; }
        public decimal? receipt_value_lc { get; set; }
        public decimal? production_qty { get; set; }
        public decimal? production_rate { get; set; }
        public decimal? production_value { get; set; }
        public decimal? ex_short_qty { get; set; }
        public decimal? ex_short_rate { get; set; }
        public decimal? ex_short_value { get; set; }
        public decimal? closing_qty { get; set; }
        public decimal? closing_rate { get; set; }
        public decimal? closing_value { get; set; }
        public decimal? current_qty { get; set; }
        public decimal? current_rate { get; set; }
        public decimal? current_value { get; set; }
        public decimal? rejection_qty { get; set; }
        public decimal? rejection_rate { get; set; }
        public decimal? rejection_value { get; set; }
        public string month_name { get; set; }
        public string month_abrv { get; set; }
        public string location_name { get; set; }
        public string place { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country_name { get; set; }
        public string moving_slot { get; set; } // This will assign Name of moving slot as per the movement of Material i.e. Fast Moving, Slow Moving and Non Moving.
        public int? calender_year { get; set; }
        public int? calender_month { get; set; }
        public string item_type { get; set; }
        public string item_subtype { get; set; }
        public string item_group { get; set; }
        public string item_cat_name { get; set; }
        public string item_subcat_name { get; set; }
        public string item_type_name { get; set; }
        public string item_subtype_name { get; set; }
        public decimal? stock_value { get; set; }
        public decimal? stock_total { get; set; }
        public decimal? stock_unr { get; set; }
        public decimal? stock_blocked { get; set; }
        public decimal? stock_in_insp { get; set; }
        public decimal? stock_in_transit { get; set; }
        public decimal? stock_in_transfer { get; set; }
        public string base_uom { get; set; }
        public decimal? price_std { get; set; }
        public decimal? price_mavg { get; set; }
        public decimal? price_fifo { get; set; }
        public decimal? price_lifo { get; set; }
        public string ind_trade { get; set; }
        public string item_class { get; set; }
        public string title { get; set; }
        public string cp_party { get; set; } // Contact Person Party
        public string contact_info { get; set; } // Contact details
        public string competitor_name { get; set; }
        public decimal? competitor_price { get; set; }
        public string competitor_name2 { get; set; }
        public decimal? competitor_price2 { get; set; }
        public string req_no { get; set; } // Purchase Requisition No
        public DateTime? req_date { get; set; }
        public string pur_inq_party { get; set; }
        public string pur_inq_no { get; set; } // Purchase Inquiry No
        public DateTime? pur_inq_date { get; set; }
        public string pur_quot_party { get; set; }
        public string pur_quot_no { get; set; } // Purchase Quotation No
        public DateTime? pur_quot_date { get; set; }
        public DateTime? pur_quot_rec_date { get; set; }
        public decimal? pur_quot_value { get; set; }
        public string sd_inq_party { get; set; }
        public string sd_inq_no { get; set; } // Sales Inquiry No
        public DateTime? sd_inq_date { get; set; }
        public string sd_quot_party { get; set; }
        public string sd_quot_no { get; set; } // Sales Quotation No
        public DateTime? sd_quot_date { get; set; }
        public DateTime? sodate { get; set; }
        public decimal? sales_qty { get; set; }
        public decimal? sales_rate { get; set; }
        public decimal? sales_value { get; set; }
        public string sch_no { get; set; } // Sales Schedule No
        public DateTime? sch_date { get; set; }
        public decimal? sch_qty { get; set; }
        public decimal? sch_value { get; set; }
        public decimal? sch_qty_bal { get; set; }
        public decimal? sch_value_bal { get; set; }
        public string pur_sch_no { get; set; } // Sales Schedule No
        public DateTime? pur_sch_date { get; set; }
        public decimal? pur_sch_qty { get; set; }
        public string pay_term { get; set; }
        public string incoterm { get; set; }
        public string incoterm2 { get; set; }
        public string supplier_id { get; set; }
        public string supplier_name { get; set; }
        public string customer_id { get; set; }
        public string customer_name { get; set; }
        public DateTime? order_ack_date { get; set; }
        public string order_ack_no { get; set; }
        public DateTime? po_ack_date { get; set; }
        public string po_ack_no { get; set; }
        public DateTime? so_ack_date { get; set; }
        public string so_ack_no { get; set; }
        public string abg_no { get; set; } // Advance Bank Guarantee Number
        public DateTime? abg_date { get; set; }
        public string invoice_no { get; set; }
        public DateTime? invoice_date { get; set; }
        public decimal? invoice_qty { get; set; }
        public decimal? invoice_value { get; set; }
        public decimal? invoice_value_lc { get; set; } // Invoice value in Local Currency
        public decimal? invoice_value_bal { get; set; }
        public decimal? iv_bal_lc { get; set; } // Invoice value in Local Currency
        public decimal? invoice_qty_bal { get; set; }
        public string pur_invoice_no { get; set; }
        public DateTime? pur_invoice_date { get; set; }
        public decimal? pur_invoice_value { get; set; }
        public string sales_invoice_no { get; set; }
        public DateTime? sales_invoice_date { get; set; }
        public decimal? sales_invoice_value { get; set; }
        public string proforma_no { get; set; }
        public DateTime? proforma_date { get; set; }
        public decimal? proforma_value { get; set; }
        public string pay_doc_no { get; set; }
        public DateTime? pay_doc_date { get; set; }
        public decimal? pay_doc_value { get; set; }
        public string pay_doc_in { get; set; }
        public DateTime? pay_date_in { get; set; }
        public decimal? pay_value_in { get; set; }
        public string pay_doc_out { get; set; }
        public DateTime? pay_date_out { get; set; }
        public decimal? pay_value_out { get; set; }
        public string pro_doc_no { get; set; } // Proforma Document Number
        public DateTime? pro_doc_date { get; set; }
        public decimal? pro_doc_value { get; set; }
        public DateTime? pick_date { get; set; }
        public string dimensions { get; set; }
        public DateTime? delivery_date { get; set; }
        public string delivery_no { get; set; }
        public decimal? delivery_qty { get; set; }
        public decimal? delivery_value { get; set; }
        public string del_from_plant { get; set; }
        public string del_to_plant { get; set; }
        public string ladding_bill { get; set; }
        public DateTime? ladding_date { get; set; }
        public DateTime? warrenty_start { get; set; }
        public DateTime? warrenty_end { get; set; }
        public DateTime? due_date { get; set; }
        public DateTime? payment_due_date { get; set; }
        public DateTime? grn_date { get; set; }
        public string service_provider { get; set; }
        public string tr_party { get; set; }
        public string tr_mode { get; set; }
        public DateTime? abg_release_date { get; set; }
        public bool? abg_flag { get; set; }
        public int? abg_days { get; set; }
        public string release_mode { get; set; }
        public string dept_code { get; set; }
        public string dept_name { get; set; }
        public DateTime? validity_start { get; set; }
        public DateTime? validity_end { get; set; }
        public DateTime? valid_from { get; set; }
        public DateTime? valid_to { get; set; }
        public string instrument_no { get; set; }
        public DateTime? instrument_date { get; set; }
        public string remark { get; set; }
        public string status_remark { get; set; }
        public decimal? balance_qty { get; set; }
        public decimal? balance_value { get; set; }
        public int? int_value1 { get; set; }
        public int? int_value2 { get; set; }
        public int? int_value3 { get; set; }
        public int? int_value4 { get; set; }
        public int? int_value5 { get; set; }
        public int? lead_time { get; set; }
        public string lead_uom { get; set; }
        public int? credit_days { get; set; }
        public decimal? credit_limit { get; set; }
        public DateTime? date_value1 { get; set; }
        public DateTime? date_value2 { get; set; }
        public DateTime? date_value3 { get; set; }
        public DateTime? date_value4 { get; set; }
        public DateTime? date_value5 { get; set; }
        
        public DateTime? confirm_date { get; set; }
        public DateTime? expected_date { get; set; }
        public DateTime? dispatch_date { get; set; }
        public DateTime? planned_date { get; set; }
        public DateTime? do_date { get; set; } //Dispatch Order Date
        public string do_no { get; set; } //Dispatch Order No
        public decimal? do_qty { get; set; }
        public decimal? do_value { get; set; }
        public decimal? do_qty_bal { get; set; }
        public decimal? do_value_bal { get; set; }
        public string wc_code { get; set; }
        public string wc_name { get; set; }
        public string wc_type { get; set; }
        public string op_code { get; set; }
        public string op_name { get; set; }
        public string sub_op_no { get; set; }
        public string sub_op_name { get; set; }
        public decimal? consumption_qty { get; set; }
        public decimal? curr_stock_qty { get; set; }
        public decimal? required_qty { get; set; }
        public decimal? counter_qty { get; set; }
        public decimal? yield { get; set; }
        public decimal? scrap_qty { get; set; }
        public decimal? rework_qty { get; set; }
        public DateTime? date_start { get; set; }
        public DateTime? date_end { get; set; }
        public string wc_operator { get; set; }
        public string shift_incharge { get; set; }
        public string conf_type { get; set; }
        public string record_type { get; set; }
        public string shift { get; set; }
        public string var_reson { get; set; }
        public string reson_desc { get; set; }
        public string barcode { get; set; }
        public string barcode2 { get; set; }
        public string qr_code { get; set; }
        public byte[] qr_image { get; set; }
        public string total_time { get; set; }
        public decimal? final_qty { get; set; }
        public string prv_batch { get; set; }
        public decimal? ac_duration { get; set; }
        public string ac_duration_uom { get; set; }
        public decimal? bd_duration { get; set; } // Breakdown duretion
        public string bd_duration_uom { get; set; } // Breakdown duretion uom
        public string hu_no { get; set; }
        public string hu_no_in { get; set; }
        public string parent_doc { get; set; }
        public string child_doc { get; set; }
        public string short_text { get; set; }
        public string long_text { get; set; }
        public decimal? assessed_value { get; set; }
        public decimal? sub_total { get; set; }
        public string address_del { get; set; }
        public string address_bil { get; set; }
        public string cat_code { get; set; }
        public string cat_name { get; set; }
        public string scat_code { get; set; } // Sub Item cat code
        public string scat_name { get; set; } // Sub Item cat name
        public string it_code { get; set; } // Item Type
        public string it_name { get; set; } // Item Type Name
        public string sit_code { get; set; } // sub Item Type
        public string sit_name { get; set; } // Sub Item Type Name
        public string equip_no { get; set; }
        public string equip_name { get; set; }
        public string model_no { get; set; }
        public string model_name { get; set; }
        public string make_code { get; set; }
        public string make_name { get; set; }
        public DateTime? inq_date { get; set; }
        public string inq_no { get; set; }
        public decimal? inq_value { get; set; }
        public DateTime? quot_date { get; set; }
        public string quot_no { get; set; }
        public decimal? quot_value { get; set; }

        public string sn_no { get; set; }
        public DateTime? sn_date { get; set; }
        public decimal? sn_qty { get; set; }
        public decimal? sn_qty_bal { get; set; }
        public decimal? sn_price { get; set; }
        public decimal? sn_price_lc { get; set; }
        public decimal? sn_value { get; set; }
        public decimal? sn_value_lc { get; set; }
        public decimal? sn_value_bal { get; set; }

        public string qn_no { get; set; }
        public DateTime? qn_date { get; set; }
        public decimal? qn_qty { get; set; }
        public decimal? qn_qty_bal { get; set; }
        public decimal? qn_price { get; set; }
        public decimal? qn_price_lc { get; set; }
        public decimal? qn_value { get; set; }
        public decimal? qn_value_lc { get; set; }
        public decimal? qn_value_bal { get; set; }

        public string so_no { get; set; }
        public DateTime? so_date { get; set; }
        public decimal? so_qty { get; set; }
        public decimal? so_qty_bal { get; set; }
        public decimal? so_price { get; set; }
        public decimal? so_price_lc { get; set; }
        public decimal? so_value { get; set; }
        public decimal? so_value_lc { get; set; }
        public decimal? so_value_bal { get; set; }

        public string char_code { get; set; }
        public string char_name { get; set; }
        public string char_type { get; set; }
        public string char_group { get; set; }
        public string char_value { get; set; }
        public string char_spec { get; set; }
        public decimal? up_lomit { get; set; }
        public decimal? low_lomit { get; set; }
        public decimal? up_tol { get; set; }
        public decimal? low_tol { get; set; }
        public decimal? target_value { get; set; }
        public decimal? mean_value { get; set; }
        public decimal? median_value { get; set; }
        public decimal? sample_size { get; set; }
        public decimal? lot_size { get; set; }
        public decimal? max_value { get; set; }
        public decimal? min_value { get; set; }
        public string valuation { get; set; }
        public DateTime? from_date { get; set; }
        public DateTime? to_date { get; set; }
        public string pp_code { get; set; }
        public string pp_type { get; set; }
        public string cp_code { get; set; }
        public string cp_name { get; set; }
        public string cp_email { get; set; }
        public string email_id { get; set; }
        public string phone_no { get; set; }
        public string mobile { get; set; }
        public string cn_text { get; set; }
        public string cn_code { get; set; }
        public string design_code { get; set; }
        public string designation { get; set; }
        public string serial_code { get; set; }


    }

    
}
