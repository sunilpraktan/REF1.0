using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.PPC
{
    // PPC_M0001 is new Work Center Master Entity and now not completed.
    public partial class PPC_M0001 : ObjectBase
    {
        public string wc_code { get; set; }
        public string wc_name { get; set; }
        public string short_text { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string wc_type { get; set; }
        public string wc_cat { get; set; }
        public string place { get; set; }
        public string cc_code { get; set; } // cost center code
        public string pc_code { get; set; } // profit center code
        public string unit_code { get; set; }
        public string cap_code { get; set; }
        public string setup_time { get; set; }
        public string control_key { get; set; }

    }

    public class PPC_M0002
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string op_code { get; set; }
        public string op_desc { get; set; }
        public string op_name { get; set; }
        public string act_type { get; set; }
    }

    public class STD_PPC_BE
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string wc_code { get; set; }
        public string wc_name { get; set; }
        public string short_text { get; set; }
        public string text_name { get; set; }


    }
}
