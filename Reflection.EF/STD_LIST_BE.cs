using System;

namespace Reflection.EF
{
    // NOTE: POC required to Generate Business Entity dynamically on fly / run time with the help of database table dictonary ot result return by SQL query. also need BE with notifychange envent and collection change event with all features of class required. if this POC is done then no need to create Business Entity Class in Web and Client project.

    // STD_LIST_BE : Declare general field name to use for multiple popup so that it can use same fields for multiple Masters by changing fields name in SQL select query using AS keyword. i.e. Table column is incoterm and inco_desc but we will crate select statement as "SELECT incoterm as key_code, inco_desc as key_name FROM ADM_M044". in this way we can reduce filed declaration in this Entity class.
    public class STD_LIST_BE : ObjectBase
    {
        public object class_object { get; set; }
        public string cat_code { get; set; }
        public string cat_name { get; set; }
        public bool? selected { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string order_to_plant { get; set; }
        public int? id { get; set; }
        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public DateTime? from_date { get; set; }
        public DateTime? to_date { get; set; }
        public DateTime? post_date { get; set; }
        public DateTime? prod_date { get; set; }
        public DateTime? bill_date { get; set; }
        public DateTime? price_date { get; set; }
        public DateTime? validity_from_date { get; set; }
        public DateTime? validity_to_date { get; set; }
        public DateTime? valid_from { get; set; }
        public DateTime? valid_to { get; set; }
        public DateTime? date_start { get; set; }
        public DateTime? date_end { get; set; }
        public DateTime? issue_date { get; set; }
        public string billing_doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_cat_name { get; set; }
        public string doc_title { get; set; }
        public string doc_type { get; set; }
        public string doc_type_name { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_cat_name { get; set; }
        public string ref_doc_type { get; set; }
        public string ref_doc_type_name { get; set; }
        public string t_status { get; set; }
        public string t_status1 { get; set; }
        public string t_status2 { get; set; }
        public string t_status3 { get; set; }
        public string t_status4 { get; set; }
        public string t_status5 { get; set; }
        public string t_display { get; set; }
        public string t_display1 { get; set; }
        public string t_display2 { get; set; }
        public string t_display3 { get; set; }
        public string t_display4 { get; set; }
        public string t_display5 { get; set; }
        public string t_name { get; set; }
        public string ref_doc_no { get; set; }
        public DateTime? ref_doc_date { get; set; }
        public string party_code { get; set; }
        public string party_name { get; set; }
        public string email_id { get; set; }
        public string party_code_ship { get; set; }
        public string party_name_ship { get; set; }
        public string add_code { get; set; } // address code of object
        public string sold_to_address { get; set; } //deatial address sold to party
        public string add_code_del { get; set; } // delivery address code of object
        public string ship_to_address { get; set; } //deatial address sold to party
        public string tax_reg_ba { get; set; } // Tax Registration No (GST) for billing address 
        public string tax_reg_da { get; set; } // Tax Registration No (GST) for delivery address 
        public string pan_no { get; set; } // PAN Account No
        public string cp_code { get; set; } // Contact person code
        public string cn_code { get; set; } // Contact details of object
        public string cn_name { get; set; } // Contact details of object
        public string cn_text { get; set; } // Contact details of object
        public string curr_code { get; set; }
        public decimal? exch_rate { get; set; }
        public string curr_name { get; set; }
        public string symbol { get; set; }
        public decimal? document_value { get; set; }
        public string location { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public string emp_no { get; set; }
        public string emp_email { get; set; }
        public string country_key { get; set; }
        public string ctry_code { get; set; }
        public string ctry_name { get; set; }
        public string country_name { get; set; }
        public string state_code { get; set; }
        public string state_name { get; set; }
        public string country_code { get; set; }
        public string StatName { get; set; }
        public string po_code { get; set; }
        public string po_name { get; set; }
        public string pg_code { get; set; }
        public string pg_name { get; set; }
        public string so_code { get; set; }
        public string so_name { get; set; }
        public string sg_code { get; set; }
        public string sg_name { get; set; }
        public decimal? qty { get; set; }
        public decimal? req_qty { get; set; }
        public string bom_no { get; set; }
        public string bom_name { get; set; }
        public string bom_exp_no { get; set; }
        public string routing_no { get; set; }
        public string plan_no { get; set; }
        public DateTime? plan_date { get; set; }
        public decimal? plan_qty { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public int? line_id { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string item_cat { get; set; }
        public string item_cat_name { get; set; }
        public string item_subcat { get; set; }
        public string sub_cat { get; set; }
        public string item_subcat_name { get; set; }
        public string item_type { get; set; }
        public string item_type_name { get; set; }
        public string item_subtype { get; set; }
        public string sub_type { get; set; }
        public string item_subtype_name { get; set; }
        public string curr_unit { get; set; } // Unit for Currency
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
        public string order_no { get; set; }
        public DateTime? order_date { get; set; }
        public decimal? order_qty { get; set; }
        public decimal? order_value { get; set; }
        public string sd_doc_no { get; set; }
        public string po_no { get; set; }
        public string delivery_no { get; set; }
        public string grn_no { get; set; }
        public int? op_seq { get; set; }
        public string op_code { get; set; }
        public string op_no { get; set; }
        public string op_name { get; set; }
        public string operation_no { get; set; }
        public string operation_desc { get; set; }
        public string control_key { get; set; }
        public int? plan_counter { get; set; }
        public decimal? dc_value1 { get; set; }
        public decimal? dc_value2 { get; set; }
        public int? counter1 { get; set; }
        public string mov_tp { get; set; }
        public string mov_tp_name { get; set; }
        public string order_type { get; set; }
        public string barcode { get; set; }
        public string batch_no { get; set; }
        public string prev_batch { get; set; }
        public string rpt_code { get; set; } // Report Entry for MIS Sctreen
        public string rpt_name { get; set; } // Report Name Entry for MIS Sctreen
        public string active { get; set; }
        public string rpt_file { get; set; }
        public string rpt_path { get; set; }
        public string rpt_url { get; set; }
        public string rpt_title { get; set; }
        public string sql_code { get; set; }
        public string ind_name { get; set; }
        public string group_code { get; set; }
        public string group_name { get; set; }
        public string incoterm { get; set; }
        public string inco_desc { get; set; }
        public string field_code { get; set; }
        public string field_name { get; set; }
        public string ind_dir { get; set; }
        public string ind_default { get; set; }
        public string ind_cat { get; set; }
        public string ind_gender { get; set; }
        public string ind_mar { get; set; } // Married unmarried 1: Married , 0: Unmaried
        public string ind_dir_default { get; set; }
        public string Ind_field_default { get; set; }
        public string display_name { get; set; }
        public string obj_type { get; set; }
        public string obj_type_name { get; set; }
        public string obj_key { get; set; }
        public string obj_no { get; set; }
        public string obj_code { get; set; }
        public string obj_name { get; set; }
        public string obj_group { get; set; }
        public string view_code { get; set; }
        public string obj_path { get; set; }
        public string obj_file { get; set; }
        public string obj_title { get; set; }
        public string obj_info { get; set; }
        public string obj_url { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string gl_code { get; set; }
        public string gl_name { get; set; }
        public string p_term_code { get; set; }
        public string p_term { get; set; }
        public string pt_code { get; set; }
        public string pt_name { get; set; }
        public string party_ref_no { get; set; }
        public DateTime? party_ref_date { get; set; }
        public string person_id { get; set; } // party contact Person id
        public string person_name { get; set; } // party contact Person name
        public string remark { get; set; }
        public string store_code { get; set; }
        public string store_name { get; set; }
        public decimal? stock_reserve { get; set; }
        public decimal? stock_total { get; set; }
        public string project_id { get; set; }
        public int? project_no { get; set; }
        public string project_name { get; set; }
        public string element_id { get; set; }
        public int? element_no { get; set; }
        public string element_name { get; set; }
        public string org_code { get; set; }
        public string org_name { get; set; }
        public string record_type { get; set; }
        public string record_cat { get; set; }
        public string type_name { get; set; }
        public string type_code { get; set; }
        public string ind_qty { get; set; }
        public string wc_code { get; set; }
        public string wc_name { get; set; }
        public string shift_code { get; set; }
        public string shift_name { get; set; }
        public string shift_hrs { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string data_type { get; set; }
        public string short_name { get; set; }
        public string short_text { get; set; }
        public string long_text { get; set; }
        public int? char_no { get; set; }
        public string char_code { get; set; }
        public string char_group { get; set; }
        public string char_type { get; set; }
        public string class_code { get; set; }
        public string char_name { get; set; }
        public string class_name { get; set; }
        public string class_group { get; set; }
        public string class_type { get; set; }
        public string lang_key { get; set; }
        public string class_no { get; set; }
        public string int_char { get; set; }
        public string int_counter { get; set; }
        public string note { get; set; }
        public string parent_id { get; set; }
        public string node_code { get; set; }
        public string node_name { get; set; }
        public int? node_seq { get; set; }
        public string img_path { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public decimal? int_value1 { get; set; }
        public decimal? int_value2 { get; set; }
        public decimal? value1 { get; set; }
        public decimal? value2 { get; set; }
        public decimal? value3 { get; set; }
        public string cp_name { get; set; } // Contact Person Name
        public string cp_no { get; set; } // Contact Person Contact Number
        public string cp_email { get; set; } // Contact Person Email ID
        public string add_bill { get; set; }
        public string add_ship { get; set; }
        public string equip_no { get; set; }
        public string equip_name { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string serial_no { get; set; }
        public DateTime? cal_date { get; set; } // repair, Maintainence & Calibration Date
        public string cert_no { get; set; } // Certificate No of the equipment after maintainance & Calibration
        public DateTime? create_date { get; set; }
        public string pr_code { get; set; }
        public string text_name { get; set; }
        public int? waitage { get; set; }
        public int? seq_no { get; set; }
        public string line_cat { get; set; }
        public string item_cat_code { get; set; }
        public string item_cat_desc { get; set; }
        public string cat_obj { get; set; }
        public string rel_billing { get; set; }
        public string rel_delivery { get; set; }
        public double? read_value { get; set; }
        public string dept_code { get; set; }
        public string dept_name { get; set; }
        public string item_code_party { get; set; }
        public string item_name_party { get; set; }
        public bool? ind_sku { get; set; }
        public bool? ind_stock { get; set; }
        public string tax_code { get; set; }
        public string bom_cat { get; set; }
        public string bom_no_alt { get; set; }
        public decimal? packet_Wt { get; set; }
        public string pack_no { get; set; }
        public decimal? pack_qty { get; set; }
        public decimal? batch_qty { get; set; }
        public decimal? stock_unr { get; set; }
        public string stock_unit { get; set; }
        public decimal? high_value { get; set; }
        public decimal? low_value { get; set; }
        public decimal? unit_price { get; set; }
        public string discount_type { get; set; }
        public decimal? discount { get; set; }
        public decimal? discount_value { get; set; }
        public decimal? base_price { get; set; }
        public decimal? purchase_price { get; set; }
        public decimal? freight1 { get; set; }
        public decimal? freight2 { get; set; }
        public decimal? freight3 { get; set; }
        public decimal? duties { get; set; }
        public decimal? other_cost { get; set; }
        public decimal? landed_cost { get; set; }
        public decimal? profit_ratio { get; set; }
        public decimal? profit_value { get; set; }
        public decimal? qty_price { get; set; }
        public decimal? price_qty { get; set; }
        public decimal? price_qty_uom { get; set; }
        public string customer_code { get; set; }
        public string customer_name { get; set; }
        public string supplier_code { get; set; }
        public string supplier_name { get; set; }
        public int? ref_item_row_id { get; set; }
        public string ind_vc { get; set; } // variant config indicator, sku_indicator
        public bool? bool_indicator { get; set; } // maintain true false value

        //QMS related fields
        public string tl_code { get; set; }
        public string tl_name { get; set; }
        public string sp_code { get; set; }
        public string sp_name { get; set; }
        public decimal? sample_size { get; set; }
        public decimal? lot_size { get; set; }
        public string sample_type { get; set; }
        public string value_mode { get; set; } // valuation mode
        public string ind_rule { get; set; }
        public string scheme { get; set; } // sample_scheme
        public string severity { get; set; } //insp_severity
        public string pay_mode { get; set; }
        public string ledger_gen { get; set; }
        public string ledger_gen_c { get; set; }
        public string ledger_gen_d { get; set; }
        public decimal? yield { get; set; }
        public decimal? confirm_qty { get; set; }
        public decimal? rework_qty { get; set; }
        public decimal? scrap_qty { get; set; }
        public string title { get; set; }
        public string req_code { get; set; } // Request Code // this is for request option for passing parameter. like if we pass object of this class to other function have same constructor but different purpose then this will get identify by this. e.g. some time we invoke document and same constructor can use for create auto document then request code can separate thing.
        public string req_cat { get; set; } // Request cat
        public string req_type { get; set; } // Request type
        public string request { get; set; } // Request Code
        public string request_type { get; set; } // Request Type
        public decimal? cost { get; set; }
        public decimal? bal_qty { get; set; }
        //public decimal? op_bal_qty { get; set; }
        public decimal? prev_yield { get; set; }

        //Bank Account Info
        public string acc_name { get; set; }
        public string bank_name { get; set; }
        public string acc_type { get; set; }
        public string acc_no { get; set; }
        public string ifsc_code { get; set; }
        public string swift_code { get; set; }
        public string not_type { get; set; }
        public string acc_group { get; set; }
        public string party_type { get; set; }
        public string revision_no { get; set; }
        public string color_code1 { get; set; }
        public string color_code2 { get; set; }
        public string color_code3 { get; set; }
        public string color_code4 { get; set; }
        public string color_code5 { get; set; }
        public byte[] qr_image { get; set; }

        // Depreciated
        public DateTime? prod_dt { get; set; }
        public string cat_desc { get; set; }

        

    }
    public class STD_ITEM : ObjectBase
    {
        public int? id { get; set; }
        //public string client { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string equip_no { get; set; }
        public string equip_name { get; set; }
        public string item_code_party { get; set; }
        public string item_name_party { get; set; }
        public bool? ind_sku { get; set; }
        public bool? ind_stock { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string line_cat { get; set; }
        public string item_cat { get; set; }
        public string item_subcat { get; set; }
        public string item_type { get; set; }
        public string item_subtype { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
        public string unit_code { get; set; } // Only Use this for selection and use coalesce to get appropriate unit as unit_code i.e in SD use COALESCE(sales_unit,unit_code) AS unit_code
        public string base_unit { get; set; }
        public string weight_unit { get; set; }
        public string volume_unit { get; set; }
        public decimal? volume { get; set; }
        public decimal? gross_wt { get; set; }
        public decimal? net_wt { get; set; }
        public string tax_id { get; set; }
        public string tax_code { get; set; }
        public string hsn_code { get; set; }
        public string hsn_group_code { get; set; }
        public string hsn_group_name { get; set; }
        public decimal? qty { get; set; }
        public decimal? req_qty { get; set; }
        public string bom_no { get; set; }
        public string bom_name { get; set; }
        public string bom_cat { get; set; }
        public string bom_no_alt { get; set; }
        public bool? selected { get; set; }
        public string batch_no { get; set; }
        public string store_code { get; set; }
        public decimal? packet_Wt { get; set; }
        public decimal? stock_total { get; set; }
        public string pack_no { get; set; }
        public decimal? pack_qty { get; set; }
        public string barcode { get; set; }
        public decimal? batch_qty { get; set; }
        public decimal? stock_unr { get; set; }
        public string stock_unit { get; set; }
        public decimal? high_value { get; set; }
        public decimal? low_value { get; set; }
        public decimal? unit_price { get; set; }
        public string rel_billing { get; set; }
        public string rel_delivery { get; set; }
        public string curr_code { get; set; }
        public string discount_type { get; set; }
        public decimal? discount { get; set; }
        public decimal? discount_value { get; set; }
        public DateTime? price_date { get; set; }
        public decimal? base_price { get; set; }
        public decimal? purchase_price { get; set; }
        public decimal? freight1 { get; set; }
        public decimal? freight2 { get; set; }
        public decimal? freight3 { get; set; }
        public decimal? duties { get; set; }
        public decimal? other_cost { get; set; }
        public decimal? landed_cost { get; set; }
        public decimal? profit_ratio { get; set; }
        public decimal? profit_value { get; set; }
        public decimal? qty_price { get; set; }
        public decimal? price_qty { get; set; }
        public decimal? price_qty_uom { get; set; }
        public string party_code { get; set; }
        public string party_name { get; set; }
        public string customer_code { get; set; }
        public string customer_name { get; set; }
        public string supplier_code { get; set; }
        public string supplier_name { get; set; }
        public string cat_code { get; set; }
        public string cat_name { get; set; }
        public string sub_cat { get; set; }
        public int? item_row_id { get; set; }
        public int? ref_item_row_id { get; set; }
        public int? order_item_row_id { get; set; }
        public string order_no { get; set; }
        public string obj_code { get; set; }
        public string obj_no { get; set; }
        public string obj_type { get; set; }
        public string obj_name { get; set; }
        public string ean_no { get; set; }
        public string ind_vc { get; set; }
        public string serial_no { get; set; }
        public string mfg_srno { get; set; }

        // Depricated Fields
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CatCode { get; set; }

    }
    public class STD_PARTY
    {
        public int? SrNo { get; set; }
        public string party_code { get; set; }
        public string party_name { get; set; }
        public string email_id { get; set; }
        public string curr_code { get; set; }
        public string symbol { get; set; }
        public string country_name { get; set; }
        public string party_type { get; set; }
        public string location { get; set; }
        public string abbrv { get; set; }
        public string acc_group { get; set; }
        public string recon_acc { get; set; }
        public string buss_place { get; set; }
        public string gl_code { get; set; }
        public string p_term_code { get; set; }
        public string p_term { get; set; }
        public string country_code { get; set; }
        public string country_key { get; set; }
        public string gl_name { get; set; }
        public string location_id { get; set; } // For Plant Location as supplier/Customer
        public int? ship_to_add { get; set; }
        public string ind_otp { get; set; } // one time party

        // Contact Person Section
        public string cp_code { get; set; } // Contact Person Code
        public string cp_code_new { get; set; }
        public string cp_name { get; set; }
        public string sal_code { get; set; }
        public string sal_name { get; set; }
        public string full_name { get; set; }
        public string nick_name { get; set; }
        public string gender { get; set; }
        public string dept_code { get; set; }
        public string f_name { get; set; }
        public string m_name { get; set; }
        public string l_name { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string phone { get; set; }
        public string phone_ext { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public string default_tax { get; set; }

        //Address Section
        public string add_code { get; set; } // NOTE: Address Code. Make this field as main and change datatype to varchar.
        public string add_code_new { get; set; }
        public string add_type { get; set; } // Address Type
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string land_mark { get; set; }
        public string map_link { get; set; }
        public string sat_view { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string place { get; set; }
        public string state_code { get; set; }
        public string postal_code { get; set; }
        public string pin { get; set; }
        public bool? active { get; set; }
        public string gstinno { get; set; }
        public string state_name { get; set; }
        public string address_full { get; set; }
        public string care_name { get; set; }
        public string train_station { get; set; }
        public string airport { get; set; }
        public string int_loc1 { get; set; }
        public string int_loc2 { get; set; }
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
        public string t_status { get; set; }
        public int? id { get; set; }

    }
    public class STD_DOC_CAT
    {
        public string key_code { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string cat_desc { get; set; }
        public string cat_name { get; set; }
        public string doc_cat_name { get; set; }
        public string module_code { get; set; }
    }
    public class STD_DOC_TYPE
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string doc_type { get; set; }
        public string type_name { get; set; }
        public string doc_type_name { get; set; }
        public string doc_type_user { get; set; }
        public string doc_type_doc_no { get; set; }
        public string doc_desc { get; set; }
        public string doc_desc_user { get; set; }
        public string doc_cat { get; set; }
        public bool? default_doc { get; set; }
        public string delivery_type { get; set; }
        public string billing_type { get; set; }
        public string report_name { get; set; }
        public string doc_no_format { get; set; }
        public string Workflow_id_temp { get; set; }
        public int? range1 { get; set; }
        public int? range2 { get; set; }
        public int? doc_no_digits { get; set; }
        public string ts_code { get; set; }
        public string unit_code { get; set; } // Default Entry Unit. i.e. Hrs(Hourse) in case of Production Entry Time Ticket.
        public bool? auto_roundup { get; set; }
        public int? roundup_digits { get; set; }
        public string posting_key { get; set; }
        public string store_code { get; set; } // default store code for POS invoice
        public string mov_tp_mi { get; set; } // default goods movement type for POS invoice
        public string ind_printf { get; set; }
        public string ind_digital { get; set; }
        public string ind_header { get; set; }
        public int? valid_days { get; set; }
        public bool? ind_source { get; set; } //NOTE: make it proper setting as per company, sles org or any ther proper setting. it is only to check reference value to vlidate reference party if customer comes with rrefrence else it is consider as direct customer without reference of commision. If refence exist, user need to select reference party in partner function.

    }
    public class STD_PERSONNEL
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public string dept_code { get; set; }
        public string dept_name { get; set; }
        public string emp_type { get; set; }
        public string email_id { get; set; }
    }
    public class STD_DOC_TYPE_SETTINGS
    {
        public string batch_no_format { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public int? range1 { get; set; }
        public int? doc_no_digits { get; set; }
        public string doc_type { get; set; }
        public string report_name { get; set; }
        public string report_name2 { get; set; }
        public decimal? net_wt { get; set; }
        public decimal? gross_wt { get; set; }
        public decimal? no_of_bags { get; set; }
        public int? no_of_cartons { get; set; }
        public string scan_source { get; set; }
        public int? min_length { get; set; }
        public string ind_residue_packing { get; set; }
        public string ind_check_qty { get; set; }
    }
    public class POSTING_KEY_DR_CR
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public string posting_key { get; set; }
        public string debcr_ind { get; set; }
        public string debcr_name { get; set; }

    }
    public class STD_NAVIGATION_BE
    {
        public string search_key1 { get; set; } // Use this field to search reference record from popup with this key field to standardise pupup function.need to set value from SQL Query and then use this in LINQ query in VM Insert.... Function. REF Implementation : EPR_T001_VM_STD, CollectSelectedReferenceDocuments Function. Benifit: We can use different fields for common Selection Key value if Multiple UNION Queries exists just like example we will filter with record number values and after selection found using other fileds to set on Transaction BE.
        public string search_key2 { get; set; } // Use this additional key if multiple filters exists. 
        public bool? selected { get; set; }
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public int? id { get; set; }
        public string ts_code { get; set; }
        public string ts_name { get; set; }
        public string rpt_code { get; set; }
        public string rpt_name { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
        public string color_code { get; set; }

    }
    public class UOMS
    {
        public int? class_id { get; set; } // Deprecated and use class_code varchar
        public string class_code { get; set; } // Deprecated class_id and use class_code varchar once replace
        public string class_name { get; set; }
        public bool? is_base_unit { get; set; }
        public string unit_code { get; set; }
        public string unit_name { get; set; }
        public string unit_abbrv { get; set; }
        public string base_unit_code { get; set; }
        public decimal? c_factor { get; set; }
        public decimal? round_precision { get; set; }
        public string conv_type { get; set; }
        public string base_unit { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string client { get; set; }
        public string unit_desc { get; set; }
        public bool? active { get; set; }
        public string symbol { get; set; }
    }

    

}
