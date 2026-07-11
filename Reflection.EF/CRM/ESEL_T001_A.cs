using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class ESEL_T001_A : ObjectBase
    {
        public int id { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string entry_no { get; set; }
        public Nullable<System.DateTime> entry_dt { get; set; }
        public Nullable<int> frm_type { get; set; }
        public string PartyId { get; set; }
        public string cust_ref_no { get; set; }
        public string serial_no { get; set; }
        public Nullable<System.DateTime> issue_dt { get; set; }
        public string period { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<decimal> total_form { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string remark { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string client { get; set; }
        public string language { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string description { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string ref_doc_type { get; set; }
        public string qtr { get; set; }
        //Scalar
        public string PartyNm { get; set; }
        public string PartyIdReport { get; set; }
        public string PartyNmReport { get; set; }
        public string frm_typeReport { get; set; }
        public string descriptionReport { get; set; }
        public string qtrReport { get; set; }
        public string fin_yearReport { get; set; }
    }

    public partial class ESEL_T001_B
    {
        public int id { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string entry_no { get; set; }
        public string inv_no { get; set; }
        public Nullable<System.DateTime> inv_dt { get; set; }
        public Nullable<decimal> val_of_goods { get; set; }
        public Nullable<decimal> tax { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<decimal> total_form { get; set; }
        public Nullable<decimal> total_inv_amt { get; set; }
        public string period { get; set; }
        public string serial_no { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string remark { get; set; }
        public Nullable<System.DateTime> issue_dt { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string client { get; set; }
        public string language { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string ref_doc_type { get; set; }
        
    }


} 


