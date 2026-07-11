using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.HRMS
{
    public class HRM_M004 : ObjectBase
    {
        public string empl_type { get; set; }
        public string empl_type_name { get; set; }
        public string unit { get; set; }
        public string value { get; set; }
        public bool? active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public DateTime? add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string lang_key { get; set; }
        public string remark { get; set; }

    }
}
