using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.HRMS
{
    public class STD_HRMS_BE
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public string dept_code { get; set; }
        public string dept_name { get; set; }
        public string dsgn_code { get; set; }
        public string dsgn_name { get; set; }

    }

    public class HRM_M0024 : ObjectBase
    {
        public int? id { get; set; }
        public string qf_code { get; set; }
        public string qf_name { get; set; }
        public string active { get; set; }
        public bool? selected { get; set; }
    }

    public class HRM_M0026 : ObjectBase
    {
        public int? id { get; set; }
        public string desig_code { get; set; }
        public string short_text { get; set; }
        public string desig_name { get; set; }
        public string active { get; set; }
        public bool? selected { get; set; }
    }
}
