using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production.ReportEntityProduction
{
   public class Rpt_MIS_Pro_MFG
    {
        public string doc_no { get; set; }
        public DateTime? entry_dt { get; set; }
        public DateTime? prod_dt { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string tip_type { get; set; }
        public string shift { get; set; }
        public int? machine_id { get; set; }
        public string machinecode { get; set; }
        public decimal? a_qty { get; set; }
        public decimal? b_qty { get; set; }
        public decimal? c_qty { get; set; }
        public decimal? total_amt { get; set; }
        public int? model_id { get; set; }
        public string modeldesc { get; set; }
        public string unit_code { get; set; }
        public int? ink_id { get; set; }
        public int? ild_id { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public int? ball_type_id { get; set; }
        public string ball_type { get; set; }
        public int? wire_type_id { get; set; }
        public string wire_type { get; set; }
        public int? para1 { get; set; }
        public string para2 { get; set; }

    }
}
