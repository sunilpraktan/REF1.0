using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production.ReportEntityProduction
{
    public class RptUltrasonicLabelGen
    {
        public string batch_no { get; set; }
        public string barcode { get; set; }
        public string shift1 { get; set; }
        public string machinecode { get; set; }
        public string ItemCode { get; set; }
        public decimal quantity { get; set; }
        public string doc_no { get; set; }
        public System.DateTime prod_date { get; set; }
       

    }
}
