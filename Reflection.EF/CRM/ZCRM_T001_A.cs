using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class ZCRM_T001_A : ObjectBase
    {
        public int id { get; set; }
        public string inv_no { get; set; }
        public Nullable<System.DateTime> inv_dt { get; set; }
        public string wa_code { get; set; }
        public string PartyId { get; set; }
        public Nullable<decimal> amount_total { get; set; }
        public string amt_in_word { get; set; }
        public string docket_no { get; set; }
        public string lrno { get; set; }
        public Nullable<System.DateTime> lrdt { get; set; }
        public Nullable<decimal> amount_untaxed { get; set; }
        public string store_code { get; set; }
        public Nullable<decimal> amount_taxed { get; set; }
        public string location_Id { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string po_no { get; set; }
        public Nullable<System.DateTime> po_dt { get; set; }
        public string Warehouse_Name { get; set; }
        public string Customer_name { get; set; }
        public string Selectfile { get; set; }
        public bool ackflag { get; set; }
        public Nullable<System.DateTime> ack_date { get; set; }
        public Nullable<System.DateTime> recd_date { get; set; }
        public bool dispachflag { get; set; }
        public string ItemCode { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public Nullable<decimal> balqty { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string unit_name { get; set; }
        public Nullable<decimal> boxqty { get; set; }
        public string remark { get; set; }
        public string comp_code { get; set; }
        public string sono { get; set; }
    }

    public partial class ZCRM_T001_B
    {
        public int id { get; set; }
        public Nullable<int> inv_id { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> uom_id { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<int> account_analytic_id { get; set; }
        public Nullable<int> location_Id { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<int> add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<int> edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<decimal> balqty { get; set; }
        public decimal sub_total { get; set; }
    }



}
