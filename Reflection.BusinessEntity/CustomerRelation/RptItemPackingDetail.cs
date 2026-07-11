using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.CustomerRelation
{
    public class RptItemPackingDetail
    {
        public string bill_doc { get; set; }
        public Nullable<DateTime> doc_date { get; set; }
        public string ItemCode { get; set; }
        public string item_desc { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string pack_no { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public Nullable<decimal> gross_wt { get; set; }
    }
}
