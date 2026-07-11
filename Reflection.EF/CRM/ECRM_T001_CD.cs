using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class ECRM_T001_CD : ObjectBase
    {
        public string sr_no { get; set; }
        public Nullable<System.DateTime> sr_date { get; set; }
        public string sa_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string analysis_for { get; set; }
        public string samp_details { get; set; }
        public string smooth { get; set; }
        public string fading { get; set; }
        public string ild { get; set; }
        public string gooping { get; set; }
        public string skiping { get; set; }
        public string deep_light { get; set; }
        public string wavi { get; set; }
        public string static_lkg { get; set; }
        public string wrt_length { get; set; }
        public string wrt_length_req { get; set; }
        public string check_material { get; set; }
        public string check_ball_dia { get; set; }
        public string prepare_drg { get; set; }
        public string match_model { get; set; }
        public string internal_geometry { get; set; }
        public string other_req { get; set; }
        public string remark { get; set; }
        public string ball_material { get; set; }
        public string max_ild { get; set; }
        public string min_ild { get; set; }
        public string avg_ild { get; set; }
        public string avg_gooping { get; set; }
        public string test_no { get; set; }
        public string handfil { get; set; }
        public string hausdtl { get; set; }
        public string remdca { get; set; }
        public string remdcb { get; set; }
        public string dcaflg { get; set; }
        public string dcbflg { get; set; }
        public string dcdone { get; set; }
        public string dcaid { get; set; }
        public string dcbid { get; set; }
        public Nullable<System.DateTime> dcadt { get; set; }
        public Nullable<System.DateTime> dcbdt { get; set; }
        public string authflg { get; set; }
        public string authby { get; set; }
        public Nullable<System.DateTime> authdt { get; set; }
        public string authnote { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
    }
}
