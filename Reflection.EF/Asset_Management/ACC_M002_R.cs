using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reflection.EF.Asset_Management
{
    public partial class ACC_M002_R : ObjectBase //Real and derived depreciation areas
    {
        public string cod { get; set; }
        public int dep_area { get; set; }
        public Nullable<bool> ind_store_rda { get; set; }
        public Nullable<bool> real_da { get; set; }
        public Nullable<int> pro_of_real_da { get; set; }
        public string gl_acc_posting { get; set; }
        public Nullable<bool> ind_da_ok { get; set; }
        public Nullable<bool> aa_da_fr_rpt { get; set; }
        public Nullable<int> da_used { get; set; }
        public string cross_sys_da { get; set; }
        public string trgt_ldgr_grp { get; set; }
        public Nullable<bool> treat_dda_as_ra { get; set; }
        public Nullable<int> acc_dtr_da { get; set; }
        public string da_purpose { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string dep_area_desc { get; set; }
        public string lang_key { get; set; }
        public string gl_code { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string cod_desc { get; set; }
        public string gl_desc { get; set; }
    }
}
