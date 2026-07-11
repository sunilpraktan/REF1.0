using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M028_I //Master
    {
        public int id { get; set; }
        public string PartyId { get; set; }
        public string wtax_type { get; set; }
        public string wtax_code { get; set; }
        public string exemption_no { get; set; }
        public string exemption_rate { get; set; }
        public Nullable<System.DateTime> exemp_start_date { get; set; }
        public Nullable<System.DateTime> exemp_end_date { get; set; }
        public string exemption_reason { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string XmlDataDocument_ADM_M028_I { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
    }
}
