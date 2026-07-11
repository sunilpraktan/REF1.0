using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Asset_Management
{
  
    public partial class ACC_M002_C : ObjectBase //Asset classes: general data
    {
        public string asset_class { get; set; }
        public string asset_name { get; set; }
        public Nullable<bool> ind_asset_dlt { get; set; }
        public Nullable<bool> ind_asset_block { get; set; }
        public Nullable<bool> auc_settlmt { get; set; }
        public string acc_dtr { get; set; }
        public string athrztn_grp { get; set; }
        public string buss_area { get; set; }
        public string cost_center { get; set; }
        public string activity_type { get; set; }
        public string ind_hist_mgm { get; set; }
        public string sorting_key { get; set; }
        public string ind_compet { get; set; }
        public string ind_matchcode { get; set; }
        public string country_code { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string Asset_super_no { get; set; }
        public string ind_property { get; set; }
        public string prop_cls_key { get; set; }
        public Nullable<bool> net_worth_tax { get; set; }
        public string invst_spprt_key { get; set; }
        public string invst_reason { get; set; }
        public string asset_mfg { get; set; }
        public string base_unit_code { get; set; }
        public string unit_code { get; set; }
        public Nullable<bool> ind_inv { get; set; }
        public string tax_offc { get; set; }
        public string municipality { get; set; }
        public string asset_cat { get; set; }
        public Nullable<bool> asset_assgnmnt { get; set; }
        public Nullable<bool> ind_cap_asset { get; set; }
        public string leasing_comp { get; set; }
        public Nullable<int> tot_lease_yrs { get; set; }
        public Nullable<int> tot_lease_prd { get; set; }
        public Nullable<int> lease_pymnt_cycle { get; set; }
        public Nullable<decimal> lease_mnth_intrst { get; set; }
        public Nullable<decimal> tot_lease_pymnts { get; set; }
        public string lease_desc { get; set; }
        public string ind_reale { get; set; }
        public Nullable<bool> ind_grp_asset { get; set; }
        public Nullable<bool> auc_invst { get; set; }
        public string leasing_type { get; set; }
        public string cap_key { get; set; }
        public string asset_desc { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public string editby { get; set; }
        public System.DateTime add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string acc_dtr_desc { get; set; }
        public string unit_name { get; set; }
        public string XmlDataDocument_ACC_M002_C_FLIP { get; set; }
    }
}
