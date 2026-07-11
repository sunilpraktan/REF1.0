using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.Finance
{
    public class RptLedgerView
    {
        public string doc_no { get; set; }
        public System.DateTime doc_date { get; set; }
        public string doc_type { get; set; }
        public string local_currency { get; set; }
        public string gl_code { get; set; }
        public string gl_name { get; set; }
        public string dc_ind { get; set; }
        public Nullable<decimal> doc_curr_amt { get; set; }
        public Nullable<decimal> loc_curr_amt { get; set; }
        public int? id { get; set; }
        public string cost_center { get; set; }
        public string cost_center_name { get; set; }
        public Nullable<System.DateTime> posting_date { get; set; }
        public string party_ref_no { get; set; }
        public string t_status { get; set; }
        public string remark { get; set; }

        //public string ref_doc_no { get; set; }
        //public Nullable<System.DateTime> ref_doc_date { get; set; }
        //public string comp_code { get; set; }
        //public string location_Id { get; set; }
        //public string ref_doc_type { get; set; }
        //public string doc_cat { get; set; }
        //public decimal? debit_amt { get; set; }
        //public decimal? credit_amt { get; set; }
        //public decimal? balance_amt { get; set; }
        //public string sub_ledger_code { get; set; }
        //public string sub_ledger_name { get; set; }
    }
}
