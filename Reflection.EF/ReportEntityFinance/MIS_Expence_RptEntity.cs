using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance.ReportEntityFinance
{
   public class MIS_Expence_RptEntity
    {
        public string sono { get; set; }
        public DateTime? sodate { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string doc_desc_user { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string EmpId { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public decimal? quantity { get; set; }
        public decimal? unit_price { get; set; }
        public decimal? amount { get; set; }
        public string curr_code { get; set; }
        public string buyer_name { get; set; }
        public string unit_code { get; set; }
        public string seller_name { get; set; }
        public decimal? tax_amt { get; set; }
        public string project_name { get; set; }
        public string project_type { get; set; }
        public string bill_doc { get; set; }
        public string ref_doc_no { get; set; }
        public string PartyNm { get; set; }
        public decimal? tax_amount { get; set; }
        public decimal? sub_total { get; set; }
        public decimal? roundup_total { get; set; }
        public decimal? received_amt { get; set; }
        public decimal? outstanding_amt { get; set; }
        public string cust_ref { get; set; }
        public DateTime? cust_ref_date { get; set; }

        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public string site_name { get; set; }
        public string po_no { get; set; }
        public DateTime? po_date { get; set; }
        public Nullable<decimal> totalactualarea { get; set; }
        public Nullable<decimal> totalwastage { get; set; }
        public string mes_taken_by { get; set; }
        public string approved_by { get; set; }
        public string remark { get; set; }
        public Nullable<decimal> total_bal_piece { get; set; }
        public Nullable<decimal> sumtotalarea { get; set; }
        public Nullable<decimal> sumtotalwaste { get; set; }
        public string area_name { get; set; }
        public Nullable<decimal> width { get; set; }
        public Nullable<decimal> height { get; set; }
        public Nullable<int> panna { get; set; }
        public Nullable<decimal> pannavalue { get; set; }
        public Nullable<decimal> bal_piece_width { get; set; }
        public Nullable<decimal> bal_piece_height { get; set; }
        public Nullable<decimal> roundup { get; set; }
        public Nullable<decimal> totalwidth { get; set; }
        public Nullable<decimal> extraheight { get; set; }
        public Nullable<decimal> totalheight { get; set; }

        public string travel_from { get; set; }
        public string travel_to { get; set; }
        public decimal? dist_in_km { get; set; }
        public decimal? approved_amt { get; set; }
        public DateTime? expenses_date { get; set; }

        //Expence Voucher
        public decimal? advance { get; set; }
        public string EmpName { get; set; }
        public string location { get; set; }
        public string additional_person { get; set; }
        public decimal? bal_amount { get; set; }
        public decimal? grand_total { get; set; }
        public string CustomerNm { get; set; }
        public string transport_mode { get; set; }
        public string food_expense { get; set; }
        public decimal? food_exp_amt { get; set; }
        public string misc_detail { get; set; }
        public decimal? misc_amt { get; set; }
        public string print_stat { get; set; }
        public decimal? print_stat_amt { get; set; }
        public string other_expense { get; set; }
        public decimal? other_exp_amt { get; set; }

        public string gl_code { get; set; }
        public string gl_name { get; set; }
        public decimal? debit_amt { get; set; }
        public decimal? credit_amt { get; set; }
        public decimal? total_amt { get; set; }
        public string comm_inv_no { get; set; }
        public DateTime? comm_inv_date { get; set; }
        public DateTime? bank_date { get; set; }
        public string pay_method { get; set; }
        public string check_no { get; set; }
        public decimal? tax_profit { get; set; }
        public decimal? cash_disc1 { get; set; }
        public decimal? net_pay_amt { get; set; }
        public decimal? order_price { get; set; }
        public DateTime? entry_date { get; set; }
        public string our_bank { get; set; }
        public string supplier_name { get; set; }
        public decimal? invoice_amt { get; set; }
        public decimal? invoice_exc_rate { get; set; }
        public decimal? curr_exc_rate { get; set; }
        public decimal? exc_rate_fluc { get; set; }
        public decimal? forgn_fluc { get; set; }



    }

}
