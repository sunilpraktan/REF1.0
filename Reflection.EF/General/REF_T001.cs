using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.General
{
    public class REF_T001 : ObjectBase
    {
        public int? id { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string doc_no { get; set; }
        public string comp_code { get; set; }
        public string op_type { get; set; }
        public string t_type { get; set; }
        public string t_stamp { get; set; }
        public DateTimeOffset? t_datetimeoffset { get; set; }
        public string lang_key { get; set; }
        public string location_Id { get; set; }
        public string t_status { get; set; }
        public string screen_namespace { get; set; }
        public string screen_class_path { get; set; }
        public string ts_name_display { get; set; }
    }
}
