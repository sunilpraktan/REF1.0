using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{ 
    public partial class ADM_M001_O
    {
        public string id { get; set; }
        public string po_code { get; set; }
        public string location_Id { get; set; }
        public bool? active { get; set; }
        public string client{ get; set; }
        public string lang_key { get; set; }
       

        //Scalar
        public string comp_code { get; set; }
        public string LoctnNm { get; set; }
        public string pur_org { get; set; }
    }
}
