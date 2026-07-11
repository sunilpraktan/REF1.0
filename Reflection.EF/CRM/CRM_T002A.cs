using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class CRM_T002A : ObjectBase
    {
        public string client { get; set; }
        public int id { get; set; }
        public string supp_cat_code { get; set; }
        public Nullable<System.DateTime> cat_date { get; set; }
        public string PartyId { get; set; }
        public Nullable<System.DateTime> from_date { get; set; }
        public Nullable<System.DateTime> to_date { get; set; }
        public string remark { get; set; }
        public string location_Id { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string comp_code { get; set; }
        public string description { get; set; }
        public string so_code { get; set; }
        public string po_code { get; set; }
        public string party_name { get; set; }
    }

    public partial class CRM_T002B
    {
        public int id { get; set; }
        public string supp_cat_code { get; set; }
        public Nullable<int> ref_srno { get; set; }
        public string ItemCode { get; set; }
        public string unit_code { get; set; }
        public string PartyId { get; set; }
        public string cstmr_itemcode { get; set; }
        public string cstmr_itemdescr { get; set; }
        public Nullable<int> lead_type { get; set; }
        public Nullable<decimal> min_ordrval { get; set; }
        public Nullable<decimal> min_qty { get; set; }
        public Nullable<decimal> max_qty { get; set; }
        public Nullable<decimal> b_rate { get; set; }
        public Nullable<decimal> price_list { get; set; }
        public Nullable<decimal> mrp { get; set; }
        public Nullable<decimal> higher_limit { get; set; }
        public Nullable<decimal> lower_limit { get; set; }
        public string rmrk { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string description { get; set; }
        public string sku { get; set; }
        public string tax_id { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string unit_name { get; set; }
        public string SubCategCod { get; set; }
        public Nullable<bool> StockUnt { get; set; }
        public string sku_desc { get; set; }
    }

    public partial class CRM_T002C
    {
        public int id { get; set; }
        public Nullable<int> line_id { get; set; }
        public Nullable<decimal> range1 { get; set; }
        public Nullable<decimal> range2 { get; set; }
        public Nullable<int> parameter_id { get; set; }
    }


    public partial class CRM_T002D
    {
        public int id { get; set; }
        public Nullable<int> line_id { get; set; }
        public Nullable<int> tax_id { get; set; }
    }

}
