using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production.ReportEntityProduction
{
    public class RptLabelGen
    {
        public string modelno { get; set; }
        public string batch_no { get; set; }
        public string barcode { get; set; }
        public decimal? ball_dia { get; set; }
        public string ball_type { get; set; }
        public string wire_type { get; set; }
        public decimal? label_qty { get; set; }
        public decimal? net_wt { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string unit_code { get; set; }
        public string cust_batch_no { get; set; }
        public string ABN { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string machinecode { get; set; }
        public string shift { get; set; }
        public DateTime? prod_dt { get; set; }
        public byte[] qr_batch { get; set; }
        public decimal? tot_qty { get; set; }
        public string batch_no_m { get; set; }
        public string doc_type { get; set; }
        public string pack_type { get; set; }
        public string total_len { get; set; }
    }
}
