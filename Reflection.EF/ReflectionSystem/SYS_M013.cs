using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.ReflectionSystem
{
    public class SYS_M013 : ObjectBase
    {
        public int id { get; set; }
        public string doc_type { get; set; }
        public string doc_type_user { get; set; }
        public string doc_type_doc_no { get; set; }
        public string doc_desc { get; set; }
        public string doc_desc_user { get; set; } 
        public string doc_cat { get; set; }
        public Nullable<bool> default_doc { get; set; }
        public string delivery_type { get; set; }
        public string billing_type { get; set; }
        public string report_name { get; set; }
        public string doc_no_format { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public int range1 { get; set; }
        public int range2 { get; set; }
        public int doc_no_digits { get; set; }
        public string TranCode { get; set; }
        public string ts_code_cn { get; set; }
    }
}
