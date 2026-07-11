using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class ACC_T006_D : ObjectBase
    {
        public string client { get; set; }
        public int id { get; set; }
        public string doc_no { get; set; }
        public string bill_entry_no { get; set; }
        public Nullable<System.DateTime> bill_entry_date { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public Nullable<int> item_row_id { get; set; }
        public Nullable<int> item_line_id { get; set; }
        public string licence_no { get; set; }
        public string incoterms { get; set; }
        public Nullable<decimal> incoterm_value_doc { get; set; }
        public Nullable<decimal> incoterm_value_local { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> qty_against_lic { get; set; }
        public Nullable<decimal> value_lic_doc { get; set; }
        public Nullable<decimal> value_lic_loc { get; set; }       
        public string asset_no { get; set; }
        public string sub_asset_no { get; set; }
        public string order_no { get; set; }
        public string invoice_no { get; set; }
        public string asset_location { get; set; }
        public Nullable<decimal> exch_rate { get; set; }
        public Nullable<decimal> cons_rate { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_type { get; set; }
        public Nullable<System.DateTime> ref_doc_date { get; set; }
        public string con_type { get; set; }
        public string trns_key_code { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public Nullable<bool> active { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string curr_code { get; set; }
        public string PartyId { get; set; }
        public string remark { get; set; }
    }
}
