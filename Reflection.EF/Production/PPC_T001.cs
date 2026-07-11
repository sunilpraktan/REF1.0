using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production
{

    public partial class PPC_T001 : ObjectBase
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string item_code { get; set; }
        public string description { get; set; }
        public string sku { get; set; }
        public string plan_no { get; set; }
        public string carton_no { get; set; }
        public string carton_name { get; set; }
        public Nullable<int> week_no { get; set; }
        public Nullable<decimal> jc_qty { get; set; }
        public string so_no { get; set; }
        public string so_item_no { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<bool> inprocess { get; set; }
        public Nullable<bool> close { get; set; }
        public string remark { get; set; }
        public string plant_id { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<int> edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<int> company_id { get; set; }
        public string ItemCode { get; set; }
        public string sono { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string editby { get; set; }
        public string doc_type { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
    }
}
