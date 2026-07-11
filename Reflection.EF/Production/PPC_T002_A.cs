using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production
{
    public partial class PPC_T002_A
    {
        public int id { get; set; }
        public Nullable<int> company_id { get; set; }
        public string plant { get; set; }
        public string entryno { get; set; }
        public Nullable<System.DateTime> entrydt { get; set; }
        public string entrytype { get; set; }
        public string type { get; set; }
        public string itemcode { get; set; }
        public string sku { get; set; }
        public Nullable<int> operation_seq { get; set; }
        public string operation { get; set; }
        public string jobcard { get; set; }
        public Nullable<int> machine_id { get; set; }
        public string itemdesc { get; set; }
        public Nullable<int> unit { get; set; }
        public string operator1 { get; set; }
        public string operator2 { get; set; }
        public Nullable<decimal> prod_qty { get; set; }
        public Nullable<decimal> rejtn_qty { get; set; }
        public Nullable<decimal> usable_prod_qty { get; set; }
        public Nullable<System.DateTime> fromdate { get; set; }
        public Nullable<System.DateTime> todate { get; set; }
        public string fromtime { get; set; }
        public string totime { get; set; }
        public string activity { get; set; }
        public string makecode { get; set; }
        public Nullable<decimal> convfact { get; set; }
        public string shifsup { get; set; }
        public string brkdreas { get; set; }
        public string dwntime { get; set; }
        public string shifcode { get; set; }
        public string partno { get; set; }
        public string stkcode { get; set; }
        public Nullable<bool> chkshet { get; set; }
        public Nullable<bool> toolcard { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<int> edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<decimal> bal_qty { get; set; }
        public string MachineCode { get; set; }
        public string unit_name { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string ItemCode { get; set; }
        public string unit_code { get; set; }
        public string editby { get; set; }
        public string doc_no { get; set; }
    }
}
