using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production.ReportEntityProduction
{
    public class RptCartonPacking
    {
        public string doc_no { get; set; }
        public string carton_type { get; set; }
        public string carton_no { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Nullable<int> ink_id { get; set; }
        public string ink { get; set; }
        public Nullable<int> ild_id { get; set; }
        public string ild { get; set; }
        public string grade { get; set; }
        public Nullable<decimal> tot_qty { get; set; }
        public string batch_no { get; set; }
        public string unit_code { get; set; }
        public string batch_noB { get; set; } 
        public Nullable<decimal> batch_qty { get; set; }
        public Nullable<int> machine_id { get; set; }
        public string machinecode { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public Nullable<decimal> gross_wt { get; set; }
        public DateTime? batch_date { get; set; }


    }
}
