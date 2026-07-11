using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reflection.EF.Admin
{
    public partial class ADM_M001_Q
    {
        public string id { get; set; }
        public string client { get; set; }

        public string lang_key { get; set; }
        public bool active { get; set; }
        public string po_code { get; set; }

        public string pg_code { get; set; }

        //scalar
        public string pg_name { get; set; }

        public string pur_org { get; set; }


    }
}
