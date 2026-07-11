using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.ReflectionSystem
{ 
     public class SYS_M025 : ObjectBase
    {
        public string doc_type { get; set; }
        public string t_status { get; set; }
        public string t_name { get; set; }
        public int? id { get; set; }
        public int? t_sequence { get; set; }
        public string doc_cat { get; set; }
        public string t_module { get; set; }
        public string t_display { get; set; }
        public int? t_weight { get; set; }
        public string t_next { get; set; }
        public string t_prev { get; set; }
        public string ind_closing { get; set; }
        public string ind_custom { get; set; }
        public string ind_manual { get; set; }
        public string ind_doc_type { get; set; }
        public string ind_change { get; set; }
        public string ind_cancel { get; set; }
        public string ind_modify { get; set; }
        public string ind_valid { get; set; }
        public string ind_active { get; set; }
        public string color_code { get; set; }
        public string lang_key { get; set; }
        public bool? active { get; set; }
        //scalar
        public bool? Click { get; set; }
        public string doc_desc_user { get; set; }

    }
}
