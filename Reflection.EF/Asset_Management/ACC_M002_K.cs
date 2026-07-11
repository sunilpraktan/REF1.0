using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Asset_Management
{
    public partial class ACC_M002_K : ObjectBase
    {
        public string dep_key { get; set; }
        public string cod { get; set; }
        public string dk_status { get; set; }
        public string mam { get; set; }
        public string cutoff_val_key { get; set; }
        public string ord_dep { get; set; }
        public string interest { get; set; }
        public string same_acq_yr { get; set; }
        public string pc_fin_yr { get; set; }
        public Nullable<int> tot_places { get; set; }
        public string dep_cal_day { get; set; }
        public string ind_reduce_dep { get; set; }
        public Nullable<bool> active { get; set; }
        public string comp_code { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string location_Id { get; set; }
        public string dep_key_desc { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        
        //scalar
        public string dep_area_desc { get; set; }
    }
}
