using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM.ReportEntityCRM
{
    public class MIS_CRM_PurchaseEntity
    {
        public string doc_no { get; set; }
        public string ref_doc_no { get; set; }
        public System.DateTime doc_date { get; set; }
        public System.DateTime po_date { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public string buyer { get; set; }
        public Nullable<decimal> amount_untaxed { get; set; }
        public Nullable<decimal> amount_tax { get; set; }
        public Nullable<decimal> amount_total { get; set; }
        public Nullable<decimal> roundup_total { get; set; }
        public string po_code { get; set; }
        public Nullable<System.DateTime> order_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string country_nm { get; set; }
        public string pincode { get; set; }
        public string catalogue_code { get; set; }
        public string t_status { get; set; }
        public string transacion_type { get; set; }
        public string curr_code { get; set; }
        public Nullable<System.DateTime> date_approve { get; set; }
        public string supplying_plant { get; set; }
        public string supplier_ref { get; set; }
        public Nullable<bool> shipped { get; set; }
        public Nullable<System.DateTime> shipped_date { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string ItemCode { get; set; }
        public string description { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public string dcat_name { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public string buyer_name { get; set; }
        public string seller_name { get; set; }
        public Nullable<decimal> po_qty { get; set; }
        public Nullable<decimal> ReceivedQty { get; set; }
        public Nullable<decimal> BalanceQty { get; set; }
        public Nullable<decimal> exch_rate { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<System.DateTime> expected_date { get; set; }
        public string inv_no { get; set; }
        public System.DateTime? inv_date { get; set; }
        public Nullable<decimal> extra_charges { get; set; }
        public string tax_name { get; set; }
        public string close_ref_no { get; set; }
        public Nullable<System.DateTime> close_ref_date { get; set; }
        public string status_remark { get; set; }
        public System.DateTime?  valid_from_date { get; set; }
        public System.DateTime? valid_to_date { get; set; }
        public string shipping_address { get; set; }
        public string project { get; set; }
    }
}
