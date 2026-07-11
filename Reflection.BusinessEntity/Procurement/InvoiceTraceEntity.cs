using System;

namespace Reflection.BusinessEntity
{
    public class InvoiceTraceEntity
    {
        public string cat_name { get; set; }
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string creator { get; set; }
        public string t_display { get; set; }
        public string ref_doc { get; set; }
        public string location_Id { get; set; }
        public string org_code { get; set; }
        public string remark_doc { get; set; }
        public string remark_item { get; set; }
        public int age { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal? qty { get; set; }
        public Nullable<System.DateTime> expected_date { get; set; }
        public decimal? price { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
    }
}
