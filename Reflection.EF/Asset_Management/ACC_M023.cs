using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Asset_Management
{
    public partial class ACC_M023 : ObjectBase  //Assignment of Methods to Dep Key 
    {
        public string dep_key { get; set; }
        public string cod { get; set; }
        public string dep_type { get; set; }
        public string dep_phase { get; set; }
        public string base_mthd { get; set; }
        public string dbm { get; set; }
        public string pcm { get; set; }
        public string mm { get; set; }
        public string mam { get; set; }
        public string com { get; set; }
        public Nullable<decimal> nbv_dep_per { get; set; }
        public string mult_shft_efct { get; set; }
        public string scrp_val_efct { get; set; }
        public string cal_shtdwn { get; set; }
        public string od_clsfctn { get; set; }
        public Nullable<bool> active { get; set; }
        public string comp_code { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string location_Id { get; set; }
        public string dep_asgn_no { get; set; }

        //Scalar 

        public string XmlDataDocument_FlipGrid { get; set; }
        public string base_mthd_desc { get; set; }
        public string dbm_desc { get; set; }
        public string pcm_desc { get; set; }
        public string mm_desc { get; set; }
        public string mam_desc { get; set; }
    }
    public class ACC_M023_Flip
    {
        public string dep_key { get; set; }
        public string dep_type { get; set; }
        public string dep_phase { get; set; }
        public string base_mthd { get; set; }
        public string dbm { get; set; }
        public string pcm { get; set; }
        public string mm { get; set; }
        public string mam { get; set; }
        public string com { get; set; }
    }
}
