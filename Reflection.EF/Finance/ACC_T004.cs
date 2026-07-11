using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance
{
    public partial class ACC_T004 : ObjectBase
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string PartyId { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string gl_code { get; set; }
        public string gl_name { get; set; }
        public Nullable<decimal> credit_balance { get; set; }
        public Nullable<decimal> debit_balance { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public string language { get; set; }
        public DateTime? post_date { get; set; }

        public string para1 { get; set; }
        public string para2 { get; set; }
        public Nullable<int> para3 { get; set; }
        public Nullable<int> para4 { get; set; }
        public Nullable<decimal> para6 { get; set; }
        public Nullable<decimal> para7 { get; set; }
        //scaler fields
        public string CustomerNm { get; set; } 
        public string short_desc { get; set; }
        public int post_per { get; set; }
        public Nullable<bool> credit_amt { get; set; }
        public Nullable<bool> debit_amt { get; set; }
        public string t_display { get; set; }
    } 
    public partial class ACC_T004_A   //Detail
    {
        public int id { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string doc_no { get; set; }
        public string invoice_no { get; set; }
        public Nullable<System.DateTime> invoice_date { get; set; }
        public Nullable<decimal> balance_amt { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public Nullable<decimal> para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string para6 { get; set; }
        public string para7 { get; set; }
        public string ref_doc_no { get; set; }
        public Nullable<System.DateTime> ref_doc_date { get; set; }  
        public string ref_doc_type { get; set; }
        public string ref_doc_cat { get; set; }
        public string gl_code { get; set; }
        public string ledger_gen { get; set; }
        public string acc_type { get; set; }
        public string doc_curr_code { get; set; }
        public string dc_ind { get; set; }
        public Nullable<decimal> exc_rate { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public Nullable<decimal> balance_amt_lc { get; set; }
        public Nullable<decimal> balance_amt_dc { get; set; }
        public string bill_doc_no { get; set; }
        public Nullable<System.DateTime> bill_doc_date { get; set; }
        public Nullable<decimal> debit_amt_lc { get; set; }
        public Nullable<decimal> credit_amt_lc { get; set; }
        public Nullable<decimal> debit_amt_dc { get; set; }
        public Nullable<decimal> credit_amt_dc { get; set; }
        public string t_display { get; set; }
        public string client { get; set; }

    } 
}
