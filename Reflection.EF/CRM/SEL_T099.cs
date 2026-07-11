using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class SEL_T099  //Master
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
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public string client { get; set; }
        public string language { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string para1 { get; set; }
        public Nullable<int> para2 { get; set; }
        public Nullable<decimal> para3 { get; set; }
        public string ref_doc_type { get; set; }
        public string ref_doc_cat { get; set; }
        public Nullable<System.DateTime> ref_doc_date { get; set; }
        //scaler fields
        public string CustomerNm { get; set; }
    }
    public partial class SEL_T099_A  //Detail
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string PartyId { get; set; }
        public string invoice_no { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> rate { get; set; }
        public Nullable<decimal> subtotal { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public string remark { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public Nullable<decimal> para1 { get; set; }
        public Nullable<decimal> para2 { get; set; }
        //scaler fields
        public string CustomerNm { get; set; }
    }
}
