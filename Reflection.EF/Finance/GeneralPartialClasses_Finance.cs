using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance
{
    public class ACC_T001_Flip
    {
        public string doc_no { get; set; }
        public string doc_date { get; set; }
        public string t_status { get; set; }
        public string PartyNm { get; set; }
        public string PartyId { get; set; }
        public string pay_method { get; set; }
        public string amount { get; set; }
        public string check_no { get; set; }
        public string comp_code { get; set; }
        public string doc_type { get; set; }
        public string SalesPerson { get; set; }
        public string t_display { get; set; }
    }

 
    public class ACC_T002_Flip
    {
        public string doc_no { get; set; }
        public string doc_date { get; set; }
        public string t_status { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }        
        public bool active  { get; set; }
        public string PartyId1 { get; set; }
        public string PartyNm1 { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public decimal? debit { get; set; }
        public decimal? credit { get; set; }
        public string t_display { get; set; }
        public string curr_code { get; set; }
    }
    public class ACC_T003_Flip
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string t_status { get; set; }
        public string PartyId { get; set; }
        public string CustomerNm { get; set; }
        public string PartyNm { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string expense_no { get; set; }
        public string gl_code { get; set; }
        public Nullable<decimal> para6 { get; set; }
        public string fin_year { get; set; }
        public string ref_doc_no { get; set; }
        public Nullable<decimal> grand_total { get; set; }
        public string sono { get; set; }
        public string t_display { get; set; }
    }
    public class ACC_T004_Flip
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
    }
        public class ACC_T005_Flip
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string t_status { get; set; } 
        public string Emp_Id { get; set; }
        public string EmpName { get; set; }
    
    }
    public partial class ACC_T003
    {
        public string XmlDataDocument_ACC_T003_A { get; set; }
        public string XmlDataDocument_ACC_T003_C { get; set; }
        public string XmlDataDocument_ACC_T003_D { get; set; }
        public string XmlDataDocument_ACC_T003_E { get; set; }
        public string XmlDataDocument_ACC_T003_F { get; set; }
        public string XmlDataDocument_ACC_T003_G { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string XmlDataDocument_Approval { get; set; }

    }

    public partial class ACC_T004
    {
        public string XmlDataDocument_ACC_T004_A { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public partial class ACC_T005
    {
        public string XmlDataDocument_ACC_T005_A { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
    }

}
