using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance
{
    public partial class ACC_M003_D //COA Assign to the Company	
    {
        public string coa_key { get; set; }
        public string comp_code { get; set; }
        public bool active { get; set; }
        public string client { get; set; }
    }
}
