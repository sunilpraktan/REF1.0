using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.ReflectionSystem
{
    public partial class SYS_M009 : ObjectBase
    {
        public int report_no { get; set; }
        public string doc_type { get; set; }
        public string report_type { get; set; }
        public string report_name { get; set; }
        public string report_description { get; set; }
    }
}
