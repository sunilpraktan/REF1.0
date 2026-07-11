using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reflection.EF.Asset_Management
{
    public partial class ACC_M002_S : ObjectBase //Real depreciation area
    {
        public string cod { get; set; }
        public int dep_area { get; set; }
        public int dep_area_val { get; set; }
        public Nullable<int> trnsfr_dep_da { get; set; }
        public Nullable<bool> ind_cal_rpl_val { get; set; }
        public Nullable<bool> idntcl_trnsfr_val { get; set; }
        public string idntcl_dt_copied { get; set; }
        public string dep_cal_seq { get; set; }
        public Nullable<bool> ind_mng_acq_yr { get; set; }
        public Nullable<bool> ind_mng_curr { get; set; }
        public Nullable<bool> ind_dpnt_da_exists { get; set; }
        public Nullable<bool> ind_trnsfr_hist_val { get; set; }
        public string consolidtn_vrsn { get; set; }
        public string sub_grp { get; set; }
        public Nullable<int> loc_curr_no { get; set; }
        public string curr_type { get; set; }
        public string stndztn_da { get; set; }
        public string cap_vrsn { get; set; }
        public Nullable<bool> qty_updt_rlvnt { get; set; }
        public string comp_code { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
    }
}
