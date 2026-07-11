using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
    public class QMS_M0003:ObjectBase
    {
        public string fl_code { get; set; }
        public string fl_name { get; set; }
        public string short_text { get; set; }
        public DateTime? doe { get; set; }
       // public string doe { get; set; }
        public string reg_no { get; set; }
        public string auth_name { get; set; }
        public string lab_name_lang1 { get; set; }
        public string lab_name_lang2 { get; set; }
        public string lab_name_lang3 { get; set; }
        public string lang_key { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string active { get; set; }
    }
}
