using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Reflection.BusinessEntity;

namespace Reflection.BusinessEntity
{
    public class BalanceOFClosedPO
    {
        public string sono { get; set; }
        public string sodate { get; set; }
        public string PartyNm { get; set; }
        public string UnitName { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public Nullable<decimal> poqty { get; set; }

        public Nullable<decimal> schwithoupo { get; set; }
        public Nullable<decimal> Deliverdqty { get; set; }

        public string ItemCode { get; set; }
        public Nullable<decimal> SO_qty { get; set; }
        public string sch_date { get; set; }
        public Nullable<decimal> schquantity { get; set; }
        public string dc_entrydt { get; set; }
        public string bill_doc { get; set; }
        public Nullable<decimal> invqty { get; set; }
        public Nullable<decimal> spltupqty { get; set; }
        public string del_status { get; set; }
        public int id { get; set; }

        //
        public int item_id { get; set; }
        public string POType { get; set; }
        public Nullable<decimal> SchduleValue { get; set; }
        public string desp_date { get; set; }
        public string inv_no { get; set; }
        public Nullable<decimal> SpiltUp { get; set; }
        public Nullable<decimal> SchduleValueComplete { get; set; }
        public string pono { get; set; }
        public string SchduleNo { get; set; }
        public string description { get; set; }
        public Nullable<decimal> bal_qty { get; set; }

    }

}
