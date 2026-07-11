using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production
{
    public partial class PPC_T003 : ObjectBase
    {
        public string doc_no { get; set; }
        public System.DateTime prod_date { get; set; }
        public System.DateTime? clean_date { get; set; }
        public System.DateTime? doc_date { get; set; }
        public string batch_no { get; set; }
        public Nullable<int> machine_id { get; set; }
        public string machinecode { get; set; }
        public string shift1 { get; set; }
        public string shift2 { get; set; }
        public string shift3 { get; set; }
        public decimal? quantity { get; set; }
        public Nullable<decimal> counter_q { get; set; }
        public Nullable<decimal> rejection_q { get; set; }
        public string remarks { get; set; }
        public string m_operator { get; set; }
        public string shift_incharge { get; set; }
        public bool active { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string ItemCode { get; set; }
        public string unit_code { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string barcode { get; set; }
        
        public string EmpName { get; set; }
        public string operatornm { get; set; }
        public string ItemName { get; set; }
        public string t_status { get; set; }
        public string order_no { get; set; }
        public Nullable<int> conversion_no { get; set; }
        public Nullable<decimal> excess_qty { get; set; }
        public string ref_Doc_TypeNm { get; set; }
        public string ref_doc_type { get; set;}
        public string ref_doc_no { get; set; }
        public decimal? sample_qty { get; set; }
        public string remark1 { get; set; }
        public string remark2 { get; set; }
        public System.DateTime? Fromdt { get; set; }
        public System.DateTime? Todt { get; set; }
        public string EmpId1 { get; set; }
        public string qc_person1 { get; set; }
        public string sshift { get; set; }
        public string item { get; set; }
        public string con_no { get; set; }
        public string machine { get; set; }
        public string t_display { get; set; }
        public string wc_code { get; set; }
        public string grade { get; set; }
        public string counter_remark { get; set; }
    }
}
