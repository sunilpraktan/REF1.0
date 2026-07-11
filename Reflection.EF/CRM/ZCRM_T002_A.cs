using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class ZCRM_T002_A : ObjectBase
    {
        public int id { get; set; }
        public string dc_entryno { get; set; }
        public System.DateTime dc_entrydt { get; set; }
        public Nullable<int> supplier_id { get; set; }
        public Nullable<int> buyer_id { get; set; }
        public Nullable<decimal> subtotal { get; set; }
        public Nullable<decimal> totamnt { get; set; }
        public string amntwrd { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<int> add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<int> edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<int> location_id { get; set; }
        public string Customer_name { get; set; }
    }

    public partial class ZCRM_T002_B
    {
        public int id { get; set; }
        public int dc_id { get; set; }
        public Nullable<int> inv_id { get; set; }
        public Nullable<decimal> amnt { get; set; }
        public Nullable<decimal> invqty { get; set; }
        public Nullable<decimal> disqty { get; set; }
        public Nullable<int> item_id { get; set; }
        public Nullable<int> uom_id { get; set; }
        public Nullable<bool> ackflg { get; set; }
        public Nullable<int> make_id { get; set; }
        public Nullable<decimal> rate { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<int> add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<int> edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string unit_name { get; set; }
        public string invno { get; set; }
    }
}
