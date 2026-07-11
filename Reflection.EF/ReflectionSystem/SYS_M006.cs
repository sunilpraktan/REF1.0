using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.ReflectionSystem
{
    public partial class SYS_M006 : ObjectBase
    {
        public int doc_cid { get; set; }
        public string doc_cat { get; set; }
        public string cat_desc { get; set; }
        public string dcat_name { get; set; }
        public string cin_no { get; set; }
        public string doc_format_no { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
    }
}
