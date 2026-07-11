using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production.ReportEntityProduction
{
    public class RptLocalExportCarton
    {
        public string modelno { get; set; }
        public string barcode { get; set; }
        public string batch_no { get; set; }
        public decimal? ball_dia { get; set; }
        public string ball_type { get; set; }
        public string wire_type { get; set; }
        public decimal? tot_qty { get; set; }
        public decimal? net_wt { get; set; }
        public decimal? gross_wt { get; set; }
        public string carton { get; set; }
        public string pallet_no { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string unit_code { get; set; }
        public string doc_no { get; set; }
        public string cust_prod_code { get; set; }
        public string cust_prod_no { get; set; }
        public string ItemCode { get; set; }
        public string grade { get; set; }
        public decimal? qty_per_bag { get; set; }
        public decimal? tot_no_bags { get; set; }
        public string cust_no { get; set; }
        public int? no_of_carton { get; set; }
        public decimal? qty_per_carton { get; set; }
        public bool? check { get; set; }
        public string item_name { get; set; }
        public string shipping_mrk { get; set; }
        public byte[] qr_batch { get; set; }
    }
}
