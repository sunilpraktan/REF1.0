using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance.ReportEntityFinance
{
    public class MIS_LedgerReport
    {
        public string sr_no { get; set; }
        public string gl_name { get; set; }
        public string location_Id { get; set; }
        public string LoctnNm { get; set; }
        public string ac_group_code { get; set; }
        public string ac_group_name { get; set; }
        public string comp_code { get; set; }
        public string CompName { get; set; }
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
        public string Opening { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
        public decimal closing { get; set; }
        public string Closing { get; set; }
        public string TranCode { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string Balance { get; set; }
        public string Closing1 { get; set; }
        public string balance1 { get; set; }
        public string doc_desc { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
        public string dcat_name { get; set; }
        public string cat_name { get; set; }
        public string ReportType { get; set; }
        public string ts_code { get; set; }
        public string ts_namespace { get; set; }
        public string ts_class_file { get; set; }
        public string ledger_gen { get; set; }
        public string ledger_gen_name { get; set; }
        public string item_text { get; set; }
    }
}
