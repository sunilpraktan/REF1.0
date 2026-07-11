using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
    public partial class EQCR_T001_A : ObjectBase
    {
        public int id { get; set; }
        public string doc_type { get; set; }
        public string doc_no { get; set; }
        public string ref_doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string invoice_no { get; set; }
        public Nullable<System.DateTime> invoice_date { get; set; }
        public Nullable<decimal> ship_qty { get; set; }
        public Nullable<decimal> qty_used { get; set; }
        public Nullable<decimal> defect_qty { get; set; }
        public Nullable<int> unit { get; set; }
        public string batch_no { get; set; }
        public string observation { get; set; }
        public string plant { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string wire { get; set; }
        public string item_nm { get; set; }
        public string wire_mat { get; set; }
        public string wire_dia { get; set; }
        public string grade { get; set; }
        public string CompName { get; set; }
        public string title { get; set; }
        public string doc_cat { get; set; }
        public string PartyId { get; set; }
        public string item_code { get; set; }
        public string unit_nm { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string editby { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string lot_no { get; set; }
        public string PartyName { get; set; }
    }


    public partial class EQCR_T001_B
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public Nullable<int> defect { get; set; }
        public string remark { get; set; }
        public Nullable<int> company_id { get; set; }
        public string plant { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string defect_nm { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string editby { get; set; }
    }

    public partial class EQCR_T001_C
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public Nullable<int> item { get; set; }
        public Nullable<decimal> ok_qty { get; set; }
        public Nullable<decimal> rejected_qty { get; set; }
        public byte[] image { get; set; }
        public Nullable<int> company_id { get; set; }
        public string plant { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string item_nm { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string ItemCode { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string editby { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
    }
}
