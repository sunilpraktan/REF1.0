using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M022_A
    {
        public string hs_code { get; set; }
        public string ItemCode { get; set; }
        public string country_code { get; set; }
        public string hsn_group_code { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        //Scalar
        public string ItemName { get; set; }
        public string country_Name { get; set; }

        public string XmlDataDocument_FlipGrid { get; set; }
    }
}
