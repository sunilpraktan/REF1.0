using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Project_Management
{
    public partial class PRO_M006 : ObjectBase
    {
        public string task_code { get; set; }
        public string task_nm { get; set; }
        public string task_desc { get; set; }
        public bool active { get; set; }        
        public string comp_code { get; set; }
    }
}
