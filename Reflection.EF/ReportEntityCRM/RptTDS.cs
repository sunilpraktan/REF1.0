using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM.ReportEntityCRM
{
    public class RptTDS
    {
        public int wire_dia_id { get; set; }
        public decimal wire_size { get; set; }
        public int wire_MakeCode { get; set; }
        public string WireMake { get; set; }
        public int ball_dia_id { get; set; }
        public decimal Ball_dia { get; set; }
        public int ball_MakeCode { get; set; }
        public string BallMake { get; set; }
     
      }
    public class RptTools
    {
        public string stn_no { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int MakeCode { get; set; }
        public string Make { get; set; }
        public string section_type { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public string life_days { get; set; }
        public string life_qty { get; set; }
        public string remark { get; set; }
    }
    public class RptDrills
    {
        public string stn_no { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int MakeCode { get; set; }
        public string Make { get; set; }
        public string section_type { get; set; }
        public Nullable<decimal> degree { get; set; }
        public string drill_spec { get; set; }
        public Nullable<decimal> drill_section { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public string life_days { get; set; }
        public string life_qty { get; set; }
        public string remark { get; set; }
    }
    public class RptSpares
    {
        public string stn_no { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int MakeCode { get; set; }
        public string Make { get; set; }
        public string section_type { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public string life_days { get; set; }
        public string life_qty { get; set; }
        public string remark { get; set; }
    }
  }
