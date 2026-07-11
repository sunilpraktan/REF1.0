using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance
{
    public partial class ACC_T001 : ObjectBase
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string comp_code { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string doc_type { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public Nullable<System.DateTime> posting_date { get; set; }
        public string entry_time { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string pay_method { get; set; }
        public string check_no { get; set; }
        public Nullable<System.DateTime> check_date { get; set; }
        public string bank_party { get; set; }
        public string bank_branch { get; set; }
        public string bank_acc_no { get; set; }
        public string ifsc_code { get; set; }
        public string swift_code { get; set; }
        public string bank_acc_name { get; set; }
        public string iban_no { get; set; }
        public string hb_code { get; set; }
        public string hb_acc { get; set; }
        public string gl_code { get; set; }
        public string replace_check_no { get; set; }
        public string replace_check_bank { get; set; }
        public string replace_check_acc { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_type { get; set; }
        public string header_text { get; set; }
        public string curr_code { get; set; }
        public decimal exch_rate { get; set; }
        public string local_currency { get; set; }
        public string exch_rate_type { get; set; }
        public string ledger_gen { get; set; }
        public string ledger_group { get; set; }
        public string reason { get; set; }
        public string note { get; set; }
        public string location_Id { get; set; }
        public Nullable<bool> active { get; set; }
        public System.DateTime add_date { get; set; }
        public string t_status { get; set; }
        public string pan_no { get; set; }
        public Nullable<decimal> amount { get; set; }
        public string amt_word { get; set; }
        public string EmpId { get; set; }
        public Nullable<decimal> local_amount { get; set; }
        public Nullable<decimal> tot_inv_amt { get; set; }
        public Nullable<decimal> tot_fluc_amt { get; set; }
        public string doc_history_no { get; set; }
        public Nullable<System.DateTime> chq_encash_dt { get; set; }
        public int? chk_void_code { get; set; }
        public Nullable<System.DateTime> voided_chk_dt { get; set; }
        public string voided_chk_user { get; set; }
        public string ind_rev_clrng { get; set; }
        public Nullable<decimal> cash_dscnt_lc { get; set; }
        public Nullable<decimal> amt_paid_lc { get; set; }
        public string address { get; set; }
        public Nullable<decimal> bank_charges { get; set; }
        public Nullable<decimal> local_bank_charges { get; set; }
        public string profit_center { get; set; }
        public Nullable<System.DateTime> bank_date { get; set; }
        public string pay_req_no { get; set; }
        public string reason_code { get; set; }
        public Nullable<decimal> total_wtax_amt { get; set; }
        public Nullable<decimal> total_cash_disc_amt { get; set; }
        public Nullable<decimal> total_amt_paid { get; set; }
        public string sp_gl_code { get; set; }
        public string bank_gl_code { get; set; }
        public string order_no { get; set; }
        public string ind_spl_gl { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }

        //Scalar
        public string compName { get; set; }
        public string gl_name { get; set; }
        public string EmpName { get; set; }
        public string sp_gl_name { get; set; }
        public string bank_gl_name { get; set; }
        public string reason_desc { get; set; }
        public string profit_center_Desc { get; set; }
        public string party_bank_name { get; set; }
        public string our_hb_name { get; set; }
        public int? address_id { get; set; }
        public string t_display { get; set; }
        public decimal? received_amt { get; set; }
        public decimal? change_amt { get; set; }

        // for Open Items not added in WebService side
        private decimal? total_amt_paid_ex { get; set; }
        private decimal? balance_amt { get; set; }
        private decimal? adv_amt { get; set; }
        private decimal? advclr_amt { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string XmlDataDocument_ACC_T001_A { get; set; }
        public string XmlDataDocument_ACC_T001_B { get; set; }
        public string XmlDataDocument_ACC_T001_C { get; set; }

        // Depricated
        public string bank_no_payee { get; set; }
        public string PayeeBankName { get; set; }
        public string GlName { get; set; }
        public string bank_name_payer { get; set; }
        public string branch_payer { get; set; }
        public string pay_method_desc { get; set; }

    }

    public partial class ACC_T001_A
    {
        public int id { get; set; }
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string doc_no { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public int? line_no_acc_doc { get; set; }
        public string posting_key { get; set; }
        public string acc_type { get; set; }
        public string ind_gl { get; set; }
        public string sp_gltype { get; set; }
        public string ind_target_gl { get; set; }
        public string ind_debitcredit { get; set; }
        public string buss_area { get; set; }
        public string tax_code_w { get; set; }
        public decimal? amount_loc_curr { get; set; }
        public decimal? amount_doc_curr { get; set; }
        public decimal? amount_ledger { get; set; }
        public decimal? amt_loc_taxbase { get; set; }
        public decimal? amt_doc_taxbase { get; set; }
        public decimal? amt_tax_local_curr { get; set; }
        public decimal? amt_tax_doc_curr { get; set; }
        public decimal? amt_withhold_tax { get; set; }
        public decimal? value_diff { get; set; }
        public decimal? value_diff_sec_curr { get; set; }
        public string assign_no { get; set; }
        public string item_text { get; set; }
        public string description { get; set; }
        public string trns_type { get; set; }
        public string gl_trns_type { get; set; }
        public string control_area { get; set; }
        public string cost_center { get; set; }
        public string order_no { get; set; }
        public string bill_doc { get; set; }
        public string sales_doc { get; set; }
        public int? sd_item_row_id { get; set; }
        public int? bill_doc_item_row_id { get; set; }
        public int? sch_item_row_id { get; set; }
        public int? dn_item_row_id { get; set; }
        public string main_asset_no { get; set; }
        public string asse_subno { get; set; }
        public string ind_open_item { get; set; }
        public string ind_down_pay { get; set; }
        public string ind_post_key { get; set; }
        public string gl_code { get; set; }
        public string ledger_gen { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string payterm_key { get; set; }
        public decimal? cash_disc1 { get; set; }
        public decimal? payterm_period { get; set; }
        public decimal? disc_per1 { get; set; }
        public decimal? amt_cd_eligible { get; set; }
        public decimal? cd_loc_curr { get; set; }
        public decimal? cd_doc_curr { get; set; }
        public string pay_method { get; set; }
        public string pay_block_key { get; set; }
        public string hb_code { get; set; }
        public string hb_acc { get; set; }
        public decimal? net_pay_amt { get; set; }
        public string ex_bill_no { get; set; }
        public DateTime? ex_bill_duedate { get; set; }
        public string tax_certi { get; set; }
        public decimal? amt_withtax { get; set; }
        public decimal? amt_withtax_ex { get; set; }
        public decimal? qty { get; set; }
        public string base_unit { get; set; }
        public string unit_code { get; set; }
        public string po_no { get; set; }
        public int? po_item_row_id { get; set; }
        public string reason_code { get; set; }
        public string profit_center { get; set; }
        public string ind_neg_posting { get; set; }
        public string pay_ref { get; set; }
        public string acc_assign_cat { get; set; }
        public decimal net_payable_amt { get; set; }
        public decimal? loss_real1 { get; set; }
        public decimal? penalty_loc1 { get; set; }
        public int? days_penalty { get; set; }
        public string late_reason { get; set; }
        public decimal? tax_profit { get; set; }
        public string acc_gl_code { get; set; }
        public bool? active { get; set; }
        public string userid { get; set; }
        public System.DateTime add_date { get; set; }
        public string t_status { get; set; }
        public decimal doc_exch_rate { get; set; }
        public decimal? cur_exch_rate { get; set; }
        public DateTime? posting_dt { get; set; }
        public string ref_doc_no { get; set; }
        public int? ref_doc_item_row_id { get; set; }
        public DateTime? doc_date { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string tax_code { get; set; }
        public decimal? amt_withhold_taxbase { get; set; }
        public decimal? amt_withhold_tax_doc { get; set; }
        public decimal? amt_withhold_tax_loc { get; set; }
        public string wtax_certificate_no { get; set; }
        public string curr_code { get; set; }
        public decimal? bal_amt { get; set; }
        public decimal? order_price { get; set; }
        public decimal? amt_cc { get; set; }
        public string accounting_doc_no { get; set; }
        public int? open_item_row_id { get; set; }
        public decimal? ex_rate_diff { get; set; }

        //Scalers
        public string GlName { get; set; }
        public string gl_name { get; set; }
        public string t_display { get; set; }
        public bool? Select { get; set; } // NOTE: not required at web service end Entity.
        public string AssignColor { get; set; }

        // NOTE: Depricated
        private decimal? TotalInvoiceAmt { get; set; }
        private decimal? TotalBillingAmt { get; set; }
        private decimal? exch_rate { get; set; }
        private decimal? advance_amount { get; set; }

    }
    public partial class ACC_T001_B
    {
        public int id { get; set; }
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string doc_no { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public Nullable<int> line_no_acc_doc { get; set; }
        public Nullable<System.DateTime> clear_date { get; set; }
        public Nullable<System.DateTime> clear_entry_date { get; set; }
        public string clr_doc_no { get; set; }
        public string posting_key { get; set; }
        public string acc_type { get; set; }
        public string ind_gl { get; set; }
        public string sp_gltype { get; set; }
        public string ind_target_gl { get; set; }
        public string ind_debitcredit { get; set; }
        public string buss_area { get; set; }
        public string tax_code_w { get; set; }
        public Nullable<decimal> amount_loc_curr { get; set; }
        public Nullable<decimal> amount_doc_curr { get; set; }
        public Nullable<decimal> amount_ledger { get; set; }
        public Nullable<decimal> amt_loc_taxbase { get; set; }
        public Nullable<decimal> amt_doc_taxbase { get; set; }
        public Nullable<decimal> amt_tax_local_curr { get; set; }
        public Nullable<decimal> amt_tax_doc_curr { get; set; }
        public Nullable<decimal> amt_withhold_tax { get; set; }
        public Nullable<decimal> value_diff { get; set; }
        public Nullable<decimal> value_diff_sec_curr { get; set; }
        public string assign_no { get; set; }
        public string item_text { get; set; }
        public string description { get; set; }
        public string trns_type { get; set; }
        public string gl_trns_type { get; set; }
        public string control_area { get; set; }
        public string cost_center { get; set; }
        public string order_no { get; set; }
        public string bill_doc { get; set; }
        public string sales_doc { get; set; }
        public Nullable<int> sd_item_row_id { get; set; }
        public Nullable<int> bill_doc_item_row_id { get; set; }
        public Nullable<int> sch_item_row_id { get; set; }
        public Nullable<int> dn_item_row_id { get; set; }
        public string main_asset_no { get; set; }
        public string asse_subno { get; set; }
        public string ind_open_item { get; set; }
        public string ind_down_pay { get; set; }
        public string ind_post_key { get; set; }
        public string gl_code { get; set; }
        public string ledger_gen { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string payterm_key { get; set; }
        public Nullable<decimal> cash_disc1 { get; set; }
        public Nullable<decimal> payterm_period { get; set; }
        public Nullable<decimal> disc_per1 { get; set; }
        public Nullable<decimal> amt_cd_eligible { get; set; }
        public Nullable<decimal> cd_loc_curr { get; set; }
        public Nullable<decimal> cd_doc_curr { get; set; }
        public string pay_method { get; set; }
        public string pay_block_key { get; set; }
        public string hb_code { get; set; }
        public string hb_acc { get; set; }
        public Nullable<decimal> net_pay_amt { get; set; }
        public string ex_bill_no { get; set; }
        public Nullable<System.DateTime> ex_bill_duedate { get; set; }
        public string tax_certi { get; set; }
        public Nullable<decimal> amt_withtax { get; set; }
        public Nullable<decimal> amt_withtax_ex { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string base_unit { get; set; }
        public string unit_code { get; set; }
        public string po_no { get; set; }
        public Nullable<int> po_item_row_id { get; set; }
        public string reason_code { get; set; }
        public string profit_center { get; set; }
        public string ind_neg_posting { get; set; }
        public string pay_ref { get; set; }
        public string acc_assign_cat { get; set; }
        public Nullable<decimal> net_payable_amt { get; set; }
        public Nullable<decimal> loss_real1 { get; set; }
        public Nullable<decimal> penalty_loc1 { get; set; }
        public Nullable<int> days_penalty { get; set; }
        public string late_reason { get; set; }
        public Nullable<decimal> tax_profit { get; set; }
        public string acc_gl_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string userid { get; set; }
        public System.DateTime? add_date { get; set; }
        public string t_status { get; set; }
        public Nullable<decimal> doc_exch_rate { get; set; }
        public Nullable<decimal> cur_exch_rate { get; set; }
        public Nullable<System.DateTime> posting_dt { get; set; }
        public string ref_doc_no { get; set; }
        public Nullable<int> ref_doc_item_row_id { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string tax_code { get; set; }
        public Nullable<decimal> amt_withhold_taxbase { get; set; }
        public Nullable<decimal> amt_withhold_tax_doc { get; set; }
        public Nullable<decimal> amt_withhold_tax_loc { get; set; }
        public string wtax_certificate_no { get; set; }
        public string curr_code { get; set; }
        public Nullable<decimal> bal_amt { get; set; }
        public Nullable<decimal> order_price { get; set; }
        public Nullable<decimal> amt_cc { get; set; }
        public string accounting_doc_no { get; set; }
        public Nullable<int> open_item_row_id { get; set; }
        public decimal? ex_rate_diff { get; set; }

        //Scalers
        public string GlName { get; set; }
        public string gl_name { get; set; }
        public string t_display { get; set; }
        public Nullable<bool> Select { get; set; }
    }
    public class ACC_T001_C
    {
        public string doc_no { get; set; }
        public string comp_code { get; set; }
        public int? ref_row_id { get; set; }
        public string order_no { get; set; }
        public string bill_doc { get; set; }
        public string amount { get; set; }
    }
    public class RptPaymentEntry
    {
        public string doc_no { get; set; }
        public string doc_date { get; set; }
        public string doc_type { get; set; }
        public decimal amount { get; set; }
        public string check_no { get; set; }
        public string PartyNm { get; set; }
        public string bank_name_payer { get; set; }
        public string bank_branch { get; set; }
        public string note { get; set; }
        public byte[] authorised_signature { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string pay_method { get; set; }
        public string salesPersnNm { get; set; }
        public string PersnEmailId { get; set; }
        public string PersnContNo { get; set; }
    }
    public class RptPaymentEntryItem
    {
        public Nullable<decimal> cash_disc1 { get; set; }
        public string pay_ref { get; set; }
        public Nullable<decimal> net_pay_amt { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
    }


}