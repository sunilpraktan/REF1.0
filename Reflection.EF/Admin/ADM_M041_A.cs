using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M041_A
    {
        public int id { get; set; }
        public string licn_type { get; set; }
        public string licn_desc { get; set; }
        public bool? active { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string edit_by { get; set; }
        public DateTime? edit_date { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
    }
}
