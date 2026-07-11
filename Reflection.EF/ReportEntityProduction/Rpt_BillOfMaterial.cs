using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production.ReportEntityProduction
{
    public class Rpt_BillOfMaterial
    {
        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public string ItemCode { get; set; }
        public string ParentItem { get; set; }
        public decimal? qty { get; set; }
        public int? Quantity { get; set; }
        public string unit_code { get; set; }
        public decimal? unit_price { get; set; }
        public decimal? total_amount { get; set; }
        public int? Levels { get; set; }
        public string Name { get; set; }
        public string Sort { get; set; }
        public string ParentPartId { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string ItemCode1 { get; set; }
        public string ChildItem { get; set; }
        public string ShowLevels { get; set; }
        public string para2 { get; set; }
        public decimal? para3 { get; set; }
        public decimal? para4 { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public decimal? bom_qty { get; set; }
        public string bom_name { get; set; }
        public decimal? req_qty { get; set; }
        public decimal? current_stock { get; set; }
        public decimal? po_qty { get; set; }
        public decimal? res_stock { get; set; }
    }
}
