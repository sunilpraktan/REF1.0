using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
    public partial class QMS_M0040 : ObjectBase
    {
        public int? id { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string insp_type { get; set; }
        public string item_code { get; set; }
        public string ind_tl { get; set; }
        public string ind_mat { get; set; }
        public string ind_config { get; set; }
        public string ind_batch { get; set; }
        public string ind_spec { get; set; }
        public string ind_char { get; set; }
        public string ind_stock { get; set; }
        public string ind_ud { get; set; }
        public string sp_code { get; set; }
        public string ind_dmrule { get; set; }
        public decimal? insp_per { get; set; }
        public string ind_per { get; set; }
        public string skip_allow { get; set; }
        public string ind_manual { get; set; }
        public string ind_cal { get; set; }
        public string ind_srm { get; set; }
        public decimal? avg_dur { get; set; }
        public string lot_control { get; set; }
        public string pq_score { get; set; }
        public decimal? scrap_share { get; set; }
        public string ind_rac { get; set; }
        public string order_no { get; set; }
        public string ind_comb { get; set; }
        public string ind_insp_type { get; set; }
        public string ind_ihu { get; set; }
        public DateTime? valid_from { get; set; }
        public string lang_key { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }
        
        
       //scalar
        public string sp_name { get; set; }
        public string item_name { get; set; }
        public string t_name { get; set; } // insp_type_name

    }
    public partial class QMS_M048 : ObjectBase
    {
        public string fa_code { get; set; }
        public string f_action { get; set; }
        public string fa_use { get; set; }

    }
}
