using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production.ReportEntityProduction
{
    public class RptSmallCarton
    {
        public string modelno { get; set; }
        public string barcode { get; set; }
        public string batch_no { get; set; }
        public string batch1 { get; set; }
        public string batch2 { get; set; }
        public string barcode1 { get; set; }
        public string barcode2 { get; set; }
        public decimal? ball_dia { get; set; }
        public string ball_type { get; set; }
        public string wire_type { get; set; }
        public decimal? tot_qty { get; set; }
        public decimal? net_wt { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string unit_code { get; set; }
        public string ABN { get; set; }
        public bool? check { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string grade { get; set; }
        public float? qty { get; set; }
        public DateTime? batch_date1 { get; set; }
        public DateTime? batch_date2 { get; set; }
        public string machinecode1 { get; set; }
        public string machinecode2 { get; set; }
        public string location_Nm { get; set; }
        public string comp_Nm { get; set; }
        public float? qty1 { get; set; }
        public float? qty2 { get; set; }
        public byte[] qr_batch1 { get; set; }
        public byte[] qr_batch2 { get; set; }
        public byte[] qr_batch3 { get; set; }

    }
}
