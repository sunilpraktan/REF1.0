using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M001_F
    {
     
        public int id { get; set; }

        public string div_code { get; set; }
       
        public string so_code { get; set; }
       
        public bool active { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }


        //scalar
        public bool select { get; set; }

        public string div_name { get; set; }

        public string sales_org { get; set; }

    }
}
