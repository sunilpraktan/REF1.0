using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance
{
    public partial class ACC_T005 : ObjectBase
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string place { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string para5 { get; set; }
        public Nullable<System.DateTime> pay_expected_date { get; set; }
        public Nullable<decimal> payment { get; set; }
        public string fin_year { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string posting_period { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public string project_name { get; set; }
        public string project_location { get; set; }
        public string project_type { get; set; }
        public Nullable<decimal> out_amt { get; set; }
        public Nullable<decimal> non_finalise { get; set; }
        public Nullable<decimal> prospectus_amt { get; set; }
        public Nullable<decimal> PO_rec_amt { get; set; }
        public Nullable<decimal> Total { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_type { get; set; }
        public string ref_doc_cat { get; set; }
        public Nullable<System.DateTime> ref_doc_date { get; set; }
        public string Emp_Id { get; set; }
        public Nullable<bool> active { get; set; }
        public string EmpName { get; set; }
    }
    public partial class ACC_T005_A
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string place { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string para5 { get; set; }
        public Nullable<System.DateTime> pay_expected_date { get; set; }
        public Nullable<decimal> payment { get; set; }
        public string fin_year { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string posting_period { get; set; }
        public string project_name { get; set; }
        public string project_location { get; set; }
        public string project_type { get; set; }
        public Nullable<decimal> out_amt { get; set; }
        public Nullable<decimal> non_finalise { get; set; }
        public Nullable<decimal> prospectus_amt { get; set; }
        public Nullable<decimal> PO_rec_amt { get; set; }
        public Nullable<decimal> Total { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_type { get; set; }
        public string ref_doc_cat { get; set; }
        public Nullable<System.DateTime> ref_doc_date { get; set; }
        public string Emp_Id { get; set; }
        public Nullable<bool> active { get; set; }
        public string CustomerNm { get; set; }
        public string sales_org { get; set; }
        public string sg_name { get; set; }
        public Nullable<decimal> pending { get; set; }
        public string Order_type { get; set; }
    }

}
