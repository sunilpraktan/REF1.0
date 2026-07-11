using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
    public class QMS_M0001 : ObjectBase
    {
        public string tsb_code { get; set; }
        public string traceability { get; set; }
        public string active { get; set; }
        public bool? selected { get; set; }
    }
    public class QMS_M0039 : ObjectBase
    {
        public string insp_type { get; set; }
        public string short_text { get; set; }
        public string tl_type { get; set; }
        public string not_type { get; set; }
        public string notification_type { get; set; }
        public string usage_code { get; set; }
        public string active { get; set; }
    }
    public class QMS_M0047 : ObjectBase
    {
        public string insp_type { get; set; }
        public string lot_origin { get; set; }
        public string origin_var { get; set; }
        public string active { get; set; }

        //Scalar
        public string short_text { get; set; }
        public string lo_text { get; set; } // lot_origin name

    }
    public class QMS_M0048 : ObjectBase
    {
        public string fa_code { get; set; }
        public string f_action { get; set; }
        public string fa_use { get; set; }
        public string active { get; set; }
        public bool? selected { get; set; }
    }
    public class QMS_M0031
    {
        public string def_class { get; set; }
        public string short_text { get; set; }
        public decimal? quality_score { get; set; }
        public DateTime? valid_from { get; set; }
    }
    public class QMS_M0032
    {
        public string prof_type { get; set; }
        public string short_text { get; set; }
        public string ind_set { get; set; }
        public string ind_value { get; set; }
    }
}
