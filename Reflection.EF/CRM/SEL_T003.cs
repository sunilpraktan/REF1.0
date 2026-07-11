using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{


    public partial class SEL_T003 : ObjectBase
    {
        public int id { get; set; }
        public string bill_doc { get; set; }
        public string bill_type { get; set; }
        public string bill_cat { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string curr_code { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public Nullable<System.DateTime> post_date { get; set; }
        public string so_code { get; set; }
        public string dc_code { get; set; }
        public string ship_cnd { get; set; }
        public Nullable<System.DateTime> bill_date { get; set; }
        public string acc_doc { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string incoterms { get; set; }
        public string export_ind { get; set; }
        public string transfer_status { get; set; }
        public Nullable<decimal> exc_rate { get; set; }
        public string p_term_code { get; set; }
        public string pay_method { get; set; }
        public string country_code { get; set; }
        public string region { get; set; }
        public string city { get; set; }
        public string comp_code { get; set; }
        public Nullable<System.TimeSpan> entry_time { get; set; }
        public string PartyId { get; set; }
        public string payer { get; set; }
        public string vat_no { get; set; }
        public Nullable<int> exc_rate_tp { get; set; }
        public string div_code { get; set; }
        public string po_no { get; set; }
        public string ref_doc_no { get; set; }
        public DateTime? ref_doc_date { get; set; }
        public string tax_org { get; set; }
        public string st_org { get; set; }
        public string country_st_cd { get; set; }
        public string assign_no { get; set; }
        public Nullable<decimal> tax_amount { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public string amt_word { get; set; }
        public Nullable<decimal> disc_amt { get; set; }
        public Nullable<decimal> ass_value { get; set; }
        public Nullable<decimal> fright_values { get; set; }
        public Nullable<decimal> invoice_amt { get; set; }
        public Nullable<decimal> invoice_amtr { get; set; }
        public string cancel_doc { get; set; }
        public string lc_curr { get; set; }
        public Nullable<decimal> lc_exc_rate { get; set; }
        public string pay_ref { get; set; }
        public string party_bank { get; set; }
        public string buss_place { get; set; }
        public string contract_acc { get; set; }
        public string cancel_re { get; set; }
        public string source_type { get; set; }
        public string source_no { get; set; }
        public string hb_acc { get; set; }
        public string gl_code { get; set; }
        public string j_code { get; set; }
        public string cust_acc { get; set; }
        public string ProdNmCd { get; set; }
        public string bank_code { get; set; }
        public string para1 { get; set; }
        public Nullable<int> para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string para5 { get; set; }
        public Nullable<int> para6 { get; set; }
        public string para7 { get; set; }
        public string para8 { get; set; }
        public string para9 { get; set; }
        public string para10 { get; set; }
        public string lc_cond { get; set; }
        public string consignee { get; set; }
        public string local_export { get; set; }
        public string ind_trade { get; set; }
        public Nullable<int> form_type { get; set; }
        public string lr_no { get; set; }
        public Nullable<System.DateTime> lr_date { get; set; }
        public string del_no { get; set; }
        public Nullable<System.DateTime> del_date { get; set; }
        public string tr_mode { get; set; }
        public string tr_type { get; set; }
        public string tr_party { get; set; }
        public string tr_name { get; set; }
        public string pack_det { get; set; }
        public string pre_carrage { get; set; }
        public string pre_carrage_place { get; set; }
        public string dest_country_cd { get; set; }
        public string port_load { get; set; }
        public string port_desc { get; set; }
        public string port_final { get; set; }
        public string final_dest { get; set; }
        public string ship_terms { get; set; }
        public string advance_lic { get; set; }
        public string cf_agent_cd { get; set; }
        public string lic_cod { get; set; }
        public string org_country_cd { get; set; }
        public string pack_rem { get; set; }
        public string ship_mark { get; set; }
        public string vess_flight { get; set; }
        public Nullable<decimal> wt_gross { get; set; }
        public Nullable<decimal> wt_net { get; set; }
        public Nullable<decimal> gross_wt { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public Nullable<decimal> volume { get; set; }
        public string weight_unit { get; set; }
        public string unit_code { get; set; }
        public string volume_unit { get; set; }
        public string ref_data { get; set; }
        public string ref_data2 { get; set; }
        public string description { get; set; }
        public string t_status { get; set; }
        public string cost_center { get; set; }
        public string location_Id { get; set; }
        public Nullable<bool> active { get; set; }
        public string tax_declaration { get; set; }
        //public string user_source1 { get; set; }
        //public string user_source2 { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string nastro_bank_cd { get; set; }
        public string notify_party { get; set; }
        public string notify_party2 { get; set; }
        public Nullable<decimal> round_up { get; set; }
        public string account_no { get; set; }
        public string swift_code { get; set; }
        public string ifsc_code { get; set; }
        public string cust_cat_no { get; set; }
        public string address { get; set; }
        public string address1 { get; set; }
        public string sold_to_party_name { get; set; }
        public string bank_name { get; set; }
        public string nastro_bank_name { get; set; }
        public string cf_agent_name { get; set; }
        public string transporter_name { get; set; }
        public string sales_org { get; set; }
        public string sg_name { get; set; }
        public string cost_center_Desc { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_type { get; set; }
        public Nullable<int> bill_address_id { get; set; }
        public string payer_name { get; set; }
        public string PlantName { get; set; }
        public string wa_name { get; set; }
        public string dc_name { get; set; }
        public string FormDescription { get; set; }
        public string doc_desc { get; set; }
        public string CountryName { get; set; }
        public Nullable<decimal> roundup_total { get; set; }
        public string billing_address { get; set; }
        public string ProdNm { get; set; }
        public string div_name { get; set; }
        public string j_name { get; set; }
        public string shipping_mark { get; set; }
        public string insurance { get; set; }
        public string packing { get; set; }
        public string transhipment { get; set; }
        public string partshipment { get; set; }
        public Nullable<System.DateTime> shipment_date { get; set; }
        public string payment_mode { get; set; }
        public Nullable<System.DateTime> validity_date { get; set; }
        public string sg_code { get; set; }
        public Nullable<System.DateTime> po_date { get; set; }
        public string cust_ref { get; set; }
        public string party_ref_no { get; set; } // available on Item Entity also
        public DateTime? party_ref_date { get; set; } // available on Item Entity also
        public string seller_name { get; set; }
        public Nullable<System.DateTime> ref_date { get; set; }
        public string EmailId { get; set; }
        public string PersnEmailId { get; set; }
        public string doc_history_no { get; set; }
        public string stock_code { get; set; }
        public string inco_desc { get; set; }
        public string incoterm2 { get; set; }
        public Nullable<decimal> order_limit { get; set; }
        public string note { get; set; }
        public Nullable<decimal> net_value { get; set; }
        public string withholding_tax { get; set; }
        public Nullable<decimal> withholding_value { get; set; }
        public Nullable<decimal> withholding_ex_amt { get; set; }
        public Nullable<decimal> local_tax_amount { get; set; }
        public Nullable<decimal> local_sub_total { get; set; }
        public Nullable<decimal> local_discount { get; set; }
        public Nullable<decimal> local_ass_value { get; set; }
        public Nullable<decimal> local_invoice_amt { get; set; }
        public Nullable<decimal> local_net_value { get; set; }
        public Nullable<decimal> local_round_up { get; set; }
        public Nullable<decimal> local_roundup_total { get; set; }
        public Nullable<decimal> other_charges { get; set; }
        public Nullable<System.DateTime> inv_due_date { get; set; }
        public Nullable<decimal> gross_value { get; set; }
        public Nullable<decimal> effective_value { get; set; }
        public string symbol { get; set; }
        public string acc_group { get; set; }
        public string recon_acc { get; set; }
        public string duty_drawback { get; set; }
        public Nullable<decimal> export_commision { get; set; }
        public Nullable<decimal> export_commision_val { get; set; }
        public string meis { get; set; }
        public string lc_info { get; set; }
        public string awb_no { get; set; }
        public Nullable<System.DateTime> awb_date { get; set; }
        public string custom_inv_no { get; set; }
        public string proforma_inv_no { get; set; }
        public string gst_PartyId { get; set; }
        //public string client { get; set; }
        public string language { get; set; }
        public string plc_name { get; set; }
        public string ref_gst_PartyId { get; set; }
        public string ref_buss_place { get; set; }
        public string data1 { get; set; }
        public string PrintOption { get; set; }
        public string status_remark { get; set; }
        public string report_declr { get; set; }
        public string awb_inst { get; set; }
        public string add_code_del { get; set; }
        public string add_code_bil { get; set; }
        public DateTime? rev_date { get; set; }
        public string emp_id { get; set; }
        public string cp_code { get; set; } // Party's Contact Person Code
        public string pt_code { get; set; }
        
        public string ind_post { get; set; }
        public string plan_no { get; set; }
        //Scalar
        public string pt_name { get; set; }
        public string delivery_address { get; set; }
        public bool? order_limit_tax { get; set; }
        public string t_display { get; set; }
        public string declaration { get; set; }
        public string notify_party_name { get; set; }
        public string notify_party_name2 { get; set; }

        public string micr_code { get; set; }
        public string acc_no { get; set; } // Bank Account Number
        public string acc_name { get; set; } // Bank Account Name
        public string ad_code { get; set; }
        public string acc_type { get; set; } // Bank Account Type Current or Saving
        public string iban_no { get; set; }
        public string ifsccode { get; set; }

        public string emp_name { get; set; }
        public string cp_name { get; set; } // Party's Contact Person Name
        public string cp_email { get; set; } // Party's Contact Person email id
        public string cp_mobile { get; set; } // Party's Contact Person Phone
        public string cp_phone { get; set; } // Party's Contact Person Mobile
        public string pt_text { get; set; } // Payment term detail description text

        public string ind_tcs { get; set; }
        public string tax_reg_no_da { get; set; } // GST NO of Delivery address of Party
        public string tax_reg_date { get; set; }
        public string tax_reg_no_ba { get; set; } // GST NO of  Billing address of Party
        public string party_code { get; set; }
        public string party_code_del { get; set; }
        public string party_code_bil { get; set; }
        public string vendor_code { get; set; }
        public string party_name { get; set; }
        public string ship_to_party_name { get; set; }
        public string place_name { get; set; }
        public DateTime? supply_date { get; set; }
        public string qr_code { get; set; }
        public byte[] qr_image { get; set; }
        public string print_option { get; set; }
        public string XDOC_TC { get; set; }
        public string reg_no { get; set; }
    }

    public partial class SEL_T003_A
    {
        public string party_ref_no { get; set; } // available on Item Entity also
        public DateTime? party_ref_date { get; set; } // available on Item Entity also
        public Nullable<System.DateTime> cust_po_date;
        public string cust_po_no;
        public int id { get; set; }
        public string bill_doc { get; set; }
        public int line_id { get; set; }
        public string ItemCode { get; set; }
        public string item_desc { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string unit_code { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<decimal> conv_fact { get; set; }
        public string uom_base_cd { get; set; }
        public Nullable<decimal> qty_base_uom { get; set; }
        public Nullable<decimal> wt_net { get; set; }
        public Nullable<decimal> wt_gross { get; set; }
        public Nullable<decimal> gross_wt { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public Nullable<decimal> volume { get; set; }
        public string weight_unit { get; set; }
        public string volume_unit { get; set; }
        public string buss_area { get; set; }
        public Nullable<System.DateTime> price_date { get; set; }
        public Nullable<System.DateTime> serv_date { get; set; }
        public Nullable<decimal> exch_rate { get; set; }
        public Nullable<decimal> net_value { get; set; }
        public string tax_id { get; set; }
        public Nullable<decimal> tax_amt { get; set; }
        public Nullable<decimal> subtotal { get; set; }
        public Nullable<decimal> gross_value { get; set; }
        public string org_doc { get; set; }
        public string org_item_cd { get; set; }
        public string ref_item_cd { get; set; }
        public string doc_cat { get; set; }
        public string sd_doc { get; set; }
        public string sd_item_cd { get; set; }
        public string sd_ref_doc { get; set; }
        public string batch { get; set; }
        public string item_cat { get; set; }
        public string item_type { get; set; }
        public string ship_rec_point { get; set; }
        public string replace_part { get; set; }
        public string div_code { get; set; }
        public string country_code { get; set; }
        public string region { get; set; }
        public string located_country { get; set; }
        public string city { get; set; }
        public string tax_class1 { get; set; }
        public string tax_class2 { get; set; }
        public string tax_class3 { get; set; }
        public string hsn_code { get; set; }
        public string hsn_code2 { get; set; }
        public string cash_dis { get; set; }
        public Nullable<decimal> disc_amt_elig { get; set; }
        public string acc_assign { get; set; }
        public string cost_center { get; set; }
        public string eu_art { get; set; }
        public string sg_code { get; set; }
        public string soff_code { get; set; }
        public string value_type { get; set; }
        public string store_code { get; set; }
        public Nullable<decimal> doc_cost { get; set; }
        public string art_no { get; set; }
        public string profit_center { get; set; }
        public string order_no { get; set; }
        public string tax_juri { get; set; }
        public string batch_split { get; set; }
        public string dest_con_so { get; set; }
        public string so_region { get; set; }
        public string so_code { get; set; }
        public string dc_code { get; set; }
        public string sd_doc_cat { get; set; }
        public Nullable<decimal> credit_price { get; set; }
        public string credit_ind { get; set; }
        public string pay_gua { get; set; }
        public string value_con { get; set; }
        public string cont_ItemCode { get; set; }
        public string cont_no { get; set; }
        public Nullable<decimal> lc_exch_rate { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_item_cd { get; set; }
        public string curr_code { get; set; }
        public Nullable<decimal> loc_rate { get; set; }
        public Nullable<decimal> loc_amt { get; set; }
        public string acc_code { get; set; }
        public string grade { get; set; }
        public Nullable<int> para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string para5 { get; set; }
        public Nullable<int> para6 { get; set; }
        public string para7 { get; set; }
        public string para8 { get; set; }
        public string para9 { get; set; }
        public string para10 { get; set; }
        public Nullable<int> no_of_pkgs { get; set; }
        public string description { get; set; }
        public string t_status { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string cust_cat_no { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_type { get; set; }
        public Nullable<bool> StockUnt { get; set; }
        public string SubCatCode { get; set; }
        public Nullable<decimal> discount { get; set; }
        public Nullable<decimal> discount_amt { get; set; }
        public string discount_type { get; set; }
        public string textdata { get; set; }
        public int ref_item_line_id {get;set;}
        public string doc_history_no { get; set; }
        public Nullable<decimal> local_net_value { get; set; }
        public Nullable<decimal> local_gross_value { get; set; }
        public Nullable<decimal> local_subtotal { get; set; }
        public Nullable<decimal> local_discount { get; set; }
        public Nullable<decimal> effective_value { get; set; }
        public Nullable<decimal> tax_amount { get; set; }
        public string article_no { get; set; }
        public string bom_no { get; set; }
        public string ref_item_row_id { get; set; }
        public string sd_line_id { get; set; }
        public string sd_row_id { get; set; }
        public string gl_code { get; set; }
        public string symbol { get; set; }
        public string acc_group { get; set; }
        public string value_class { get; set; }
        public string recon_acc { get; set; }
        public string delivery_no { get; set; }
        public int del_item_row_id { get; set; }
        public string ship_to_Party { get; set; }
        public int? ship_to_add { get; set; }
        public string buss_place { get; set; }
        public string ref_ship_to_Party { get; set; }
        public int ref_ship_to_add { get; set; }
        public string ref_buss_place { get; set; }
        public string client { get; set; }
        public string language { get; set; }
        public string ProdNm { get; set; }
        public string ProdNmCd { get; set; }
        public string t_display { get; set; }
        public string sch_no { get; set; }
        public int sch_item_row_id { get; set; }
        public string service_doc_no { get; set; }
        public int service_item_row_id { get; set; }
        public string price_qty_uom { get; set; }
        public decimal? price_qty { get; set; }
        public decimal? qty_price { get; set; }
        public string item_code_party { get; set; }
        public string item_name_party { get; set; }

        public DateTime? ref_doc_date { get; set; }
        public string item_cat_code { get; set; }
    }


    public partial class SEL_T003_B
    {
        public int id { get; set; }
        public int item_row_id { get; set; }
        public int tax_id { get; set; }
    }

    //Depricated
    public partial class SEL_T003_C
    {
        public int id { get; set; }
        public Nullable<decimal> tax_amount { get; set; }
        public Nullable<int> account_id { get; set; }
        public Nullable<int> sequence { get; set; }
        public string doc_no { get; set; }
        public string manual { get; set; }
        public Nullable<decimal> base_amount { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<decimal> @base { get; set; }
        public Nullable<int> tax_code_id { get; set; }
        public Nullable<int> account_analytic_id { get; set; }
        public Nullable<int> base_code_id { get; set; }
        public string tax_name { get; set; }
        public string gl_code { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public Nullable<int> item_row_id { get; set; }
        public Nullable<int> item_line_id { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public Nullable<bool> active { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string dc_ind { get; set; }
        public string curr_code { get; set; }
        public Nullable<decimal> exch_rate { get; set; }
        public string local_curr { get; set; }
        public Nullable<decimal> amt_local_curr { get; set; }
        public string fix_per { get; set; }
        public string symbol { get; set; }
        //Added by Priya
        public string con_type { get; set; }
        public string con_cat { get; set; }
        public int acc_seq { get; set; }
        public string trns_key_code { get; set; }
        public string acc_key1 { get; set; }
        public string record_no { get; set; }
        public decimal? price_uom { get; set; }
        public string doc_uom_con { get; set; }
        public decimal? no_base_uom { get; set; }
        public decimal? dno_base_uo { get; set; }
        public string ind_con_acc { get; set; }
        public string vendor_code { get; set; }
        public string customera_code { get; set; }
        public decimal? rnd_diff { get; set; }
        public decimal? con_value { get; set; }
        public string ind_max_base { get; set; }
        public string ind_max_amt { get; set; }
        public string withholding_tax { get; set; }

        //Added by Priya on 2/5/2017
        public int stepno { get; set; }
        public int scounter { get; set; }
        public string trns_scope { get; set; }
        public decimal? pricing_date { get; set; }
        public string calc_type { get; set; }
        public decimal? con_qty { get; set; }
        public string ind_stats { get; set; }
        public string scale_type { get; set; }
        public decimal? scale_qty { get; set; }
        public string ind_con_acr { get; set; }
        public string PartyId { get; set; }
        public string tax_code { get; set; }
        public string origin_ind { get; set; }
        public string con_control { get; set; }
        public string round_method { get; set; }
        public string grp_con { get; set; }
        public string is_qty { get; set; }
        public string con_record_no { get; set; }
        public int con_seq { get; set; }
        public string con_class { get; set; }
        public int cc_head { get; set; }
        public decimal? f_cbv { get; set; }
        public decimal? f_cbp { get; set; }
        public string ind_scale { get; set; }
        public decimal? scale_value { get; set; }
        public string scale_uom { get; set; }
        public string scale_curr { get; set; }
        public string cost_center { get; set; }
        public string profit_center { get; set; }
        public string gross_indicator { get; set; }
        public string analysis_code { get; set; }
        public decimal? rate_uom { get; set; }
        public string pay_term { get; set; }
        public string lic_type { get; set; }
        public string lic_no { get; set; }
        public string client { get; set; }
        public string language { get; set; }
    }
}
