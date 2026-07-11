using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production
{
    public partial class ESO_T001_A
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string ItemCode { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string sort_cat { get; set; }
        public string defect_type { get; set; }
       
        public string shift1 { get; set; }
        public string shift2 { get; set; }
        public string shift3 { get; set; }
        public Nullable<decimal> defect_qty { get; set; }
        public string remark { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string t_status { get; set; }
        public string status_remark { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<decimal> rej_qty1 { get; set; }
        public Nullable<decimal> rej_qty2 { get; set; }
        public Nullable<decimal> total { get; set; }
        public string sort_by { get; set; }
        public string defect_condition { get; set; }
        public string barcode { get; set; }
        
    }

    public partial class ESO_T001_B
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string ItemCode { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string sort_cat { get; set; }
        public string defect_type { get; set; }
        public string shift1 { get; set; }
        public string shift2 { get; set; }
        public string shift3 { get; set; }
        public Nullable<decimal> defect_qty { get; set; }
        public string remark { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string t_status { get; set; }
        public string status_remark { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<decimal> rej_qty1 { get; set; }
        public Nullable<decimal> rej_qty2 { get; set; }
        public Nullable<decimal> total { get; set; }
        public string sort_by { get; set; }
        public string defect_condition { get; set; }
        public string barcode { get; set; }
        public string parent_defect { get; set; }
        public string machinecode { get; set; }

    }
}
