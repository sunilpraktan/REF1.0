using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Asset_Management
{
    public partial class ACC_M002_D : ObjectBase //Asset class: depreciation area
    {
        public int dep_area { get; set; }
        public string cod { get; set; }
        public string asset_class { get; set; }
        public Nullable<System.DateTime> vldty_end_dt { get; set; }
        public Nullable<System.DateTime> vldty_strt_dt { get; set; }
        public Nullable<bool> ind_asset_class_lock { get; set; }
        public Nullable<bool> ind_dlt { get; set; }
        public string acc_dtr { get; set; }
        public string low_value_asset_chk { get; set; }
        public Nullable<int> min_life_yrs { get; set; }
        public Nullable<int> min_life_prd { get; set; }
        public Nullable<int> max_life_yrs { get; set; }
        public Nullable<int> max_life_prd { get; set; }
        public string invst_spprt_key { get; set; }
        public string dep_key { get; set; }
        public Nullable<int> planned_life_yrs { get; set; }
        public Nullable<int> planned_life_prd { get; set; }
        public Nullable<decimal> dep_per_rt { get; set; }
        public Nullable<decimal> spl_dep_per_rt { get; set; }
        public string replcmnt_val_indx { get; set; }
        public string replcmnt_val_indx_age { get; set; }
        public string dep_portion { get; set; }
        public Nullable<bool> ind_tot_dep { get; set; }
        public Nullable<bool> ind_da_deactive { get; set; }
        public string group_asset { get; set; }
        public string reval_key { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }

        //Scalar
        public string XmlDataDocument_ACC_M002_D_FLIP { get; set; }
    }
}
