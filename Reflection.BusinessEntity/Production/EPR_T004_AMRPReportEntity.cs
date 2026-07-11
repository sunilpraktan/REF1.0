using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.Production
{
    public class EPR_T004_AMRPReportEntity
    {
        public string plan_no { get; set; }
        public string planning_item { get; set; }
        public Nullable<decimal> plan_qty { get; set; }
        public string plan_unit { get; set; }
        public string Bom_item { get; set; }
        public Nullable<decimal> bom_qty { get; set; }
        public string BOMUnit { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string sku { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> c_factor { get; set; }
        public Nullable<decimal> TotalQty { get; set; }
        public Nullable<decimal> stock_total { get; set; }
        public Nullable<decimal> po_qty { get; set; }
        public Nullable<decimal> stock_reserve { get; set; }
        public Nullable<decimal> ShortageQty { get; set; }


    }
}
