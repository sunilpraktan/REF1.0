using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.CustomerRelation
{
   public class RptSalesInvoiceTax
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
        public string hsn_code { get; set; }
        public string amt_word_tax { get; set; }
    }
}
