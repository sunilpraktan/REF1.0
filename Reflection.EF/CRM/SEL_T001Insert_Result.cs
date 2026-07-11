using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class SEL_T001Insert_Result
    {
        public int id { get; set; }
        public int srno { get; set; }
        public string sono { get; set; }
        public Nullable<System.DateTime> sodate { get; set; }
        public Nullable<int> order_to { get; set; }
        public Nullable<int> partner_id { get; set; }
        public Nullable<int> del_address { get; set; }
        public string cust_ref { get; set; }
        public Nullable<System.DateTime> cust_ref_date { get; set; }
        public Nullable<System.DateTime> validity { get; set; }
        public Nullable<int> quotation_id { get; set; }
        public string so_type { get; set; }
        public Nullable<int> buyer { get; set; }
        public Nullable<int> salesman { get; set; }
        public Nullable<int> pay_term { get; set; }
        public string description { get; set; }
        public string remark { get; set; }
        public Nullable<bool> delivered { get; set; }
        public Nullable<bool> invoice { get; set; }
        public Nullable<decimal> tax_amt { get; set; }
        public Nullable<decimal> untax_amt { get; set; }
        public string curr_status { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string edit_by { get; set; }
        public string LoctnNm { get; set; }
        public string EmpNm { get; set; }
        public string PartyNm { get; set; }
        public string ContPersnNm { get; set; }
    }

    public partial class SEL_T001LoadAll_Result
    {
        public int id { get; set; }
        public int srno { get; set; }
        public string sono { get; set; }
        public Nullable<System.DateTime> sodate { get; set; }
        public Nullable<int> order_to { get; set; }
        public Nullable<int> partner_id { get; set; }
        public Nullable<int> Invoice_address { get; set; }
        public Nullable<int> del_address { get; set; }
        public string cust_ref { get; set; }
        public Nullable<System.DateTime> cust_ref_date { get; set; }
        public Nullable<System.DateTime> validity { get; set; }
        public Nullable<int> quotation_id { get; set; }
        public string so_type { get; set; }
        public Nullable<int> buyer { get; set; }
        public Nullable<int> salesman { get; set; }
        public Nullable<int> pay_term { get; set; }
        public string description { get; set; }
        public string remark { get; set; }
        public Nullable<bool> delivered { get; set; }
        public Nullable<bool> invoice { get; set; }
        public Nullable<decimal> tax_amt { get; set; }
        public Nullable<decimal> untax_amt { get; set; }
        public Nullable<decimal> total_amt { get; set; }
        public string amt_inword { get; set; }
        public string curr_status { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string edit_by { get; set; }
        public string LoctnNm { get; set; }
    }
}
