using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production.ReportEntityProduction
{
    public class RptCartonBatchDetails
    {
        public string batch_no { get; set; }
        public string grade { get; set; }
        public string ItemName { get; set; }
        public string Ink { get; set; }
        public string Ild { get; set; }
        public string batch_inner { get; set; }
        public string batch_label { get; set; }
        public decimal? label_qty { get; set; }
        public string machinecode { get; set; }
        public DateTime? prod_dt { get; set; }
        public decimal? inner_qty { get; set; }
        public string inner_unit { get; set; }
        public string label_unit { get; set; }
        public bool? check { get; set; }
        public decimal? tot_qty { get; set; }
        public string SrNo { get; set; }
        public byte[] qr_batch { get; set; }


    }
}
