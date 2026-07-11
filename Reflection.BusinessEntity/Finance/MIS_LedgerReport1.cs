using System;

namespace Reflection.BusinessEntity.Finance
{
    public class MIS_LedgerReport1
    {
        public string sr_no { get; set; }
        public string gl_name { get; set; }
        public string location_Id { get; set; }
        public string ac_group_code { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string gl_code { get; set; }
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public decimal? debit_amt { get; set; }
        public decimal? credit_amt { get; set; }
        public Nullable<System.DateTime> post_date { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string opening { get; set; }
        public string closing { get; set; }
        public string trans_code { get; set; }
    }
}