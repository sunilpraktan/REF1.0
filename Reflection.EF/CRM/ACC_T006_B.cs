using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
   
    public partial class ACC_T006_B : ObjectBase
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
        public int item_line_id { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public Nullable<bool> active { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string dc_ind { get; set; }
        public string curr_code { get; set; }
        public decimal? exch_rate { get; set; }
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
        public Nullable<System.DateTime> pricing_date { get; set; }
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
        public string ind_computation { get; set; }

        // Scaller
        public string req_no { get; set; }
        public string hsn_code { get; set; }
        public string price_qty_uom { get; set; }
        public decimal? price_qty { get; set; }
        public decimal? qty_price { get; set; }
    }
}
