using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public class ADM_M001_G
    {
        public int id { get; set; }
        public string so_code { get; set; }
        public string dc_code { get; set; }
        public string location_Id { get; set; }
        public bool active { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }

        //Scaler
        public string sales_org { get; set; }
        public string dc_name { get; set; }
        public string LoctnNm { get; set; }

    }
}
