using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Asset_Management
{
   public partial class ACC_M002 : ObjectBase
    {
        public string comp_code { get; set; }
        public string asset_no { get; set; }
        public string asset_sub_no { get; set; }
        public string asset_class { get; set; }
        public string tech_asset_no { get; set; }
        public string asset_type { get; set; }
        public string ind_asset_dlt { get; set; }
        public string ind_asset_locked { get; set; }
        public string acc_dtr { get; set; }
        public string auc_settlmt { get; set; }
        public string asset_cat { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string t_status { get; set; }
        public Nullable<System.DateTime> asset_val_dt { get; set; }
        public Nullable<System.DateTime> asset_cap_dt { get; set; }
        public Nullable<System.DateTime> asset_val_ret_dt { get; set; }
        public Nullable<System.DateTime> deactivation_dt { get; set; }
        public Nullable<System.DateTime> plnnd_ret_dt { get; set; }
        public Nullable<System.DateTime> asset_po_dt { get; set; }
        public string asset_super_no { get; set; }
        public string asset { get; set; }
        public string asset_sort_key { get; set; }
        public Nullable<bool> ind_hist_mgm { get; set; }
        public string ind_compet { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string asset_mfg { get; set; }
        public string ind_property { get; set; }
        public string orgnl_asset { get; set; }
        public string orgnl_asset1 { get; set; }
        public Nullable<System.DateTime> orgnl_aqui_dt { get; set; }
        public string aqui_fin_year { get; set; }
        public string orgnl_aqui_fin_year { get; set; }
        public Nullable<decimal> orgnl_aqui_val { get; set; }
        public Nullable<decimal> prod_per { get; set; }
        public string invstmnt_odr { get; set; }
        public string base_unit_code { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string asset_type_nm { get; set; }
        public string invstmnt_reason { get; set; }
        public string ind_inv { get; set; }
        public Nullable<System.DateTime> last_inv_dt { get; set; }
        public string inv_specification { get; set; }
        public string prop_cls_key { get; set; }
        public string net_worth_tax { get; set; }
        public Nullable<decimal> net_worth_tax_val { get; set; }
        public Nullable<decimal> assessed_val { get; set; }
        public Nullable<System.DateTime> convynce_dt { get; set; }
        public Nullable<System.DateTime> last_ntc_dt { get; set; }
        public string tax_code { get; set; }
        public Nullable<System.DateTime> land_reg_of { get; set; }
        public Nullable<System.DateTime> land_reg_entry_dt { get; set; }
        public string land_reg_vol { get; set; }
        public string land_reg_pg { get; set; }
        public string lr_seq_no { get; set; }
        public string lr_map_no { get; set; }
        public string plot_no { get; set; }
        public string tax_offc { get; set; }
        public string municipality { get; set; }
        public string mnaul_val_reason { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> surface_area { get; set; }
        public string inv_no { get; set; }
        public string trdng_comp_id { get; set; }
        public string language { get; set; }
        public string asset_desc { get; set; }
        public string ind_lt_actv { get; set; }
        public string ind_lt_prop_val { get; set; }
        public string ind_tech_vieiw_lt { get; set; }
        public string ind_lt_actv1 { get; set; }
        public string ind_mfg_lt { get; set; }
        public string ind_lease_desc { get; set; }
        public string leasing_comp { get; set; }
        public Nullable<System.DateTime> leas_aggr_dt { get; set; }
        public Nullable<System.DateTime> leas_aggr_ntc_dt { get; set; }
        public Nullable<System.DateTime> leas_srt_dt { get; set; }
        public Nullable<int> tot_lease_yrs { get; set; }
        public Nullable<int> tot_lease_prd { get; set; }
        public Nullable<int> lease_pymnt_cycle { get; set; }
        public Nullable<decimal> prd_leas_pymnt_paid { get; set; }
        public Nullable<decimal> leas_base_val { get; set; }
        public Nullable<decimal> leas_asset_pur_price { get; set; }
        public Nullable<decimal> lease_mnth_intrst { get; set; }
        public Nullable<decimal> lease_intrst { get; set; }
        public Nullable<System.DateTime> leas_post_dt { get; set; }
        public Nullable<decimal> tot_posted_leas_pymnt { get; set; }
        public Nullable<decimal> tot_posted_leas_prd { get; set; }
        public Nullable<decimal> tot_leas_liability { get; set; }
        public Nullable<decimal> tot_leas_pymnt { get; set; }
        public string leas_aggr_no { get; set; }
        public string lease_desc { get; set; }
        public string ind_cap_asset { get; set; }
        public string ind_reale { get; set; }
        public string obj_no { get; set; }
        public string leasing_type { get; set; }
        public Nullable<bool> adv_pymnt { get; set; }
        public string wbs_elmnt_invst_proj { get; set; }
        public string ind_ignore_memo_val { get; set; }
        public string asset_aqui_used { get; set; }
        public string is_grp_asset { get; set; }
        public string auc_invst { get; set; }
        public string serial_no { get; set; }
        public string envrmnt_invst_reason { get; set; }
        public Nullable<System.DateTime> last_reval_dt { get; set; }
        public Nullable<System.DateTime> last_reorg_dt { get; set; }
        public string asset_td_val_param { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string country_code { get; set; }
        public Nullable<bool> asset_acqui_used { get; set; }
        public Nullable<bool> asset_acqui_new { get; set; }

        #region Scalar Variables ACC_M002
        public string XmlDataDocument_ACC_M002_FLIP { get; set; }
        public string XmlDataDocument_ACC_M002_I1 { get; set; }
        public string XmlDataDocument_ACC_M002_H { get; set; }
        public string XmlDataDocument_ACC_M002_B { get; set; }
        public string asset_class_desc { get; set; }
        public string ItemName { get; set; }
        public string gl_name { get; set; }
        public string leasing_comp_desc { get; set; }
        public string vendor_code { get; set; }
        public string dep_area_desc { get; set; }
        #endregion
    }
    public partial class ACC_M002_B
    {
        public int id { get; set; }
        public string client { get; set; }
        public string comp_code { get; set; }
        public string asset_no { get; set; }
        public string asset_sub_no { get; set; }
        public int dep_area { get; set; }
        public Nullable<System.DateTime> vldty_end_dt { get; set; }
        public Nullable<System.DateTime> vldty_bgn_dt { get; set; }
        public string ind_asset_dlt { get; set; }
        public string ind_asset_locked { get; set; }
        public string asset_amnt_qty_chk { get; set; }
        public string ind_dep_asset_tot { get; set; }
        public Nullable<System.DateTime> dep_cal_srt_dt { get; set; }
        public Nullable<System.DateTime> int_cal_srt_dt { get; set; }
        public Nullable<System.DateTime> spl_cal_srt_dt { get; set; }
        public string invst_spprt_key { get; set; }
        public string dep_key { get; set; }
        public Nullable<int> plnnd_usfl_yrs { get; set; }
        public Nullable<int> plnnd_usfl_prd { get; set; }
        public Nullable<decimal> ord_dep_per_rt { get; set; }
        public Nullable<decimal> spl_dep_per_rt { get; set; }
        public string rplcmnt_indx_series { get; set; }
        public string rplcmnt_indx_series_age { get; set; }
        public Nullable<decimal> var_dep_portion { get; set; }
        public Nullable<int> chngovr_yr_dep_k { get; set; }
        public int orgnl_usfl_life_yrs { get; set; }
        public Nullable<int> orgnl_usfl_life_prd { get; set; }
        public Nullable<decimal> asset_scrap_val { get; set; }
        public string lst_fin_yr { get; set; }
        public Nullable<int> prd_scaling { get; set; }
        public Nullable<int> reval { get; set; }
        public string grp_asset { get; set; }
        public string grp_asset_subno { get; set; }
        public string asset_aqui_yr { get; set; }
        public string asset_aqui_mnth { get; set; }
        public Nullable<System.DateTime> oprtng_readiness_dt { get; set; }
        public Nullable<System.DateTime> da_last_rtrmnt_val_dt { get; set; }
        public string reval_key { get; set; }
        public Nullable<System.DateTime> last_reval_dt { get; set; }
        public string last_indx_used { get; set; }
        public Nullable<decimal> scrap_val_per { get; set; }
        public Nullable<int> dk_chngovr_prd { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }

        //scalar
        public string dep_area_desc { get; set; }
        public string dep_key_desc { get; set; }
    }
    public partial class ACC_M002_H
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public string asset_no { get; set; }
        public string asset_sub_no { get; set; }
        public Nullable<System.DateTime> vldty_end_dt { get; set; }
        public Nullable<System.DateTime> vldty_bgn_dt { get; set; }
        public string buss_place { get; set; }
        public string plant { get; set; }
        public string activity_type { get; set; }
        public Nullable<decimal> shift_factor { get; set; }
        public Nullable<bool> ind_asst_shtdwn { get; set; }
        public string asset_location { get; set; }
        public string int_order { get; set; }
        public string room { get; set; }
        public string mntnce_order { get; set; }
        public string fnctnl_lctn { get; set; }
        public string tax_Jurisdiction { get; set; }
        public Nullable<int> wbs_elmnt { get; set; }
        public string lcnce_plate_no { get; set; }
        public string prsnl_no { get; set; }
        public string cost_center { get; set; }
        public string funds_center { get; set; }
        public string fund { get; set; }
        public string fnctnl_area { get; set; }
        public string grnt { get; set; }
        public string funds_center_aaa { get; set; }
        public string fund_aaa { get; set; }
        public string fnctnl_area_aaa { get; set; }
        public string grnt_aaa { get; set; }
        public string int_key_reale { get; set; }
        public Nullable<int> wbs_elmnt_cost { get; set; }
        public string fm_bdgt_prd { get; set; }
        public string bdgt_prd_aaa { get; set; }
        public string profit_center { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }

        //scalar
        public string dep_area_desc { get; set; }
        public string plantName { get; set; }
    }
    public partial class ACC_M002_I1
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public string asset_no { get; set; }
        public string asset_sub_no { get; set; }
        public Nullable<int> seq_no { get; set; }
        public string insurance_type { get; set; }
        public string insu_indx_series { get; set; }
        public Nullable<decimal> base_insu_val { get; set; }
        public Nullable<decimal> base_insu_val1 { get; set; }
        public string insu_comp { get; set; }
        public string ind_updt_val_mnuly { get; set; }
        public Nullable<decimal> mnuly_insu_val { get; set; }
        public string fin_yr_imv { get; set; }
        public string old_fin_yr_imv { get; set; }
        public Nullable<System.DateTime> i_strt_dt { get; set; }
        public string i_rate { get; set; }
        public string i_policy_no { get; set; }
        public string i_desc { get; set; }
        public Nullable<int> ap_seq_no { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string asset_mgf { get; set; }
    }

  
   
}
