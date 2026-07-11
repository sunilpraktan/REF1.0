using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class CRM_T001B : ObjectBase
    {
        public int id { get; set; }
        public string cust_cat_no { get; set; }
        public Nullable<int> CatNo { get; set; }
        public Nullable<int> refsrno { get; set; }
        public string ItemCode { get; set; }
        public string unit_code { get; set; }
        public string PartyId { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public Nullable<int> LeadTym { get; set; }
        public Nullable<decimal> MinOrdrVal { get; set; }
        public Nullable<decimal> MinQty { get; set; }
        public Nullable<decimal> MaxQty { get; set; }
        public Nullable<decimal> Brate { get; set; }
        public Nullable<decimal> price_list { get; set; }
        public Nullable<decimal> mrp { get; set; }
        public Nullable<decimal> higher_limit { get; set; }
        public Nullable<decimal> lower_limit { get; set; }
        public string Rmrk { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string tax_id { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string item_code { get; set; }
        public string unit_name { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string description { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string client { get; set; }
    }

    public partial class CRM_T001C
    {
        public int id { get; set; }
        public int parent_id { get; set; }
        public int part_id { get; set; }
        public string ItemCode { get; set; }
        public string cstpart_code { get; set; }
        public string cstpart_name { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public bool active { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
    }
}
