using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
    public class QMS_M0002:ObjectBase
    {
        public string insp_method { get; set; }
        public string method_name { get; set; }
        public string version_no { get; set; }
        public Nullable<System.DateTime> valid_from { get; set; }
        public string qualification { get; set; }
        public string lang_key { get; set; }
        public string method_code { get; set; }
        public string clause { get; set; }
        public string insp_type { get; set; }
        public string short_text { get; set; }
        public string long_text { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public bool? selected { get; set; }

    }
}
