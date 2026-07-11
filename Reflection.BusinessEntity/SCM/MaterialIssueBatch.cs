using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.SCM
{
    public class MaterialIssueBatch
    {
        public int id { get; set; }
        public Nullable<int> grn_id { get; set; }
        public int item_line_id { get; set; }
        public string doc_no { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> sr_line_no { get; set; }
        public string batch_no { get; set; }
        public string vendor_batch_no { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> rec_qty { get; set; }
        public string unit_code { get; set; }
        public string description { get; set; }
        public string t_status { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string wa_code { get; set; }
        public string store_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<decimal> para1 { get; set; }
        public Nullable<decimal> para2 { get; set; }
        public Nullable<decimal> para3 { get; set; }
        public Nullable<decimal> para4 { get; set; }
        public Nullable<decimal> para5 { get; set; }
        public Nullable<decimal> para6 { get; set; }
        public Nullable<decimal> para7 { get; set; }
        public string sku { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
    }
}
