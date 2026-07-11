using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M041_B
    {
        public int id { get; set; }
        public string sion_no { get; set; }
        public string sion_desc { get; set; }        
        public string exp_wire_dia { get; set; }
        public Nullable<decimal> exp_qty_pcs { get; set; }
        public Nullable<decimal> exp_qty_kg { get; set; }
        public Nullable<decimal> exp_maxlimit_kg { get; set; }
        public string imp_wire_type { get; set; }
        public string imp_wire_dia { get; set; }
        public Nullable<decimal> imp_wire_qty_allowed { get; set; }
        public string imp_ball_type { get; set; }
        public string imp_ball_dia { get; set; }
        public Nullable<decimal> imp_ball_qty_allowed { get; set; }
        public Nullable<decimal> import_value { get; set; }
        public Nullable<decimal> imp_maxlimit { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string XmlDataDocument_ADM_M041_B_Flip { get; set; }
        public string XmlDataDocument_ADM_M041_B { get; set; }

    }
}
