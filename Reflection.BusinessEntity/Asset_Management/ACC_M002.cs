using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Asset_Management
{
    public class ACC_M002 : ObjectBase
    {
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _asset_no;
        public string asset_no
        {
            get { return _asset_no; }
            set { _asset_no = value; RaisePropertyChanged("asset_no"); }
        }

        private string _asset_sub_no;
        public string asset_sub_no
        {
            get { return _asset_sub_no; }
            set { _asset_sub_no = value; RaisePropertyChanged("asset_sub_no"); }
        }

        private string _asset_class;
        public string asset_class
        {
            get { return _asset_class; }
            set { _asset_class = value; RaisePropertyChanged("asset_class"); }
        }

        private string _tech_asset_no;
        public string tech_asset_no
        {
            get { return _tech_asset_no; }
            set { _tech_asset_no = value; RaisePropertyChanged("tech_asset_no"); }
        }

        //public string _asset_type;
        //public string asset_type
        //{
        //    get { return _asset_type; }
        //    set { _asset_type = value; RaisePropertyChanged("asset_type"); }
        //}

        private string _ind_asset_dlt;
        public string ind_asset_dlt
        {
            get { return _ind_asset_dlt; }
            set { _ind_asset_dlt = value; RaisePropertyChanged("ind_asset_dlt"); }
        }

        private string _ind_asset_locked;
        public string ind_asset_locked
        {
            get { return _ind_asset_locked; }
            set { _ind_asset_locked = value; RaisePropertyChanged("ind_asset_locked"); }
        }

        private string _acc_dtr;
        public string acc_dtr
        {
            get { return _acc_dtr; }
            set { _acc_dtr = value; RaisePropertyChanged("acc_dtr"); }
        }

        private string _auc_settlmt;
        public string auc_settlmt
        {
            get { return _auc_settlmt; }
            set { _auc_settlmt = value; RaisePropertyChanged("auc_settlmt"); }
        }

        private string _asset_cat;
        public string asset_cat
        {
            get { return _asset_cat; }
            set { _asset_cat = value; RaisePropertyChanged("asset_cat"); }
        }

        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set { _fin_year = value; RaisePropertyChanged("fin_year"); }
        }

        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set { _posting_period = value; RaisePropertyChanged("posting_period"); }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }

        private Nullable<System.DateTime> _asset_val_dt;
        public Nullable<System.DateTime> asset_val_dt
        {
            get { return _asset_val_dt; }
            set { _asset_val_dt = value; RaisePropertyChanged("asset_val_dt"); }
        }

        private Nullable<System.DateTime> _asset_cap_dt;
        public Nullable<System.DateTime> asset_cap_dt
        {
            get { return _asset_cap_dt; }
            set { _asset_cap_dt = value; RaisePropertyChanged("asset_cap_dt"); }
        }

        private Nullable<System.DateTime> _asset_val_ret_dt;
        public Nullable<System.DateTime> asset_val_ret_dt
        {
            get { return _asset_val_ret_dt; }
            set { _asset_val_ret_dt = value; RaisePropertyChanged("asset_val_ret_dt"); }
        }

        private Nullable<System.DateTime> _deactivation_dt;
        public Nullable<System.DateTime> deactivation_dt
        {
            get { return _deactivation_dt; }
            set { _deactivation_dt = value; RaisePropertyChanged("deactivation_dt"); }
        }

        public Nullable<System.DateTime> _plnnd_ret_dt;
        public Nullable<System.DateTime> plnnd_ret_dt
        {
            get { return _plnnd_ret_dt; }
            set { _plnnd_ret_dt = value; RaisePropertyChanged("plnnd_ret_dt"); }
        }

        public Nullable<System.DateTime> _asset_po_dt;
        public Nullable<System.DateTime> asset_po_dt
        {
            get { return _asset_po_dt; }
            set { _asset_po_dt = value; RaisePropertyChanged("asset_po_dt"); }
        }

        private string _asset_super_no;
        public string asset_super_no
        {
            get { return _asset_super_no; }
            set { _asset_super_no = value; RaisePropertyChanged("asset_super_no"); }
        }

        private string _asset;
        public string asset
        {
            get { return _asset; }
            set { _asset = value; RaisePropertyChanged("asset"); }
        }

        private string _asset_sort_key;
        public string asset_sort_key
        {
            get { return _asset_sort_key; }
            set { _asset_sort_key = value; RaisePropertyChanged("asset_sort_key"); }
        }

        private Nullable<bool> _ind_hist_mgm;
        public Nullable<bool> ind_hist_mgm
        {
            get { return _ind_hist_mgm; }
            set { _ind_hist_mgm = value; RaisePropertyChanged("ind_hist_mgm"); }
        }

        private string _ind_compet;
        public string ind_compet
        {
            get { return _ind_compet; }
            set { _ind_compet = value; RaisePropertyChanged("ind_compet"); }
        }

        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set { _PartyId = value; RaisePropertyChanged("PartyId"); }
        }

        private string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set { _PartyNm = value; RaisePropertyChanged("PartyNm"); }
        }

        private string _asset_mfg;
        public string asset_mfg
        {
            get { return _asset_mfg; }
            set { _asset_mfg = value; RaisePropertyChanged("asset_mfg"); }
        }

        private string _ind_property;
        public string ind_property
        {
            get { return _ind_property; }
            set { _ind_property = value; RaisePropertyChanged("ind_property"); }
        }

        private string _orgnl_asset;
        public string orgnl_asset
        {
            get { return _orgnl_asset; }
            set { _orgnl_asset = value; RaisePropertyChanged("orgnl_asset"); }
        }

        private string _orgnl_asset1;
        public string orgnl_asset1
        {
            get { return _orgnl_asset1; }
            set { _orgnl_asset1 = value; RaisePropertyChanged("orgnl_asset1"); }
        }

        private Nullable<System.DateTime> _orgnl_aqui_dt;
        public Nullable<System.DateTime> orgnl_aqui_dt
        {
            get { return _orgnl_aqui_dt; }
            set { _orgnl_aqui_dt = value; RaisePropertyChanged("orgnl_aqui_dt"); }
        }

        private string _aqui_fin_year;
        public string aqui_fin_year
        {
            get { return _aqui_fin_year; }
            set { _aqui_fin_year = value; RaisePropertyChanged("aqui_fin_year"); }
        }


        private string _orgnl_aqui_fin_year;
        public string orgnl_aqui_fin_year
        {
            get { return _orgnl_aqui_fin_year; }
            set { _orgnl_aqui_fin_year = value; RaisePropertyChanged("orgnl_aqui_fin_year"); }
        }

        private Nullable<decimal> _orgnl_aqui_val;
        public Nullable<decimal> orgnl_aqui_val
        {
            get { return _orgnl_aqui_val; }
            set { _orgnl_aqui_val = value; RaisePropertyChanged("orgnl_aqui_val"); }
        }

        private Nullable<decimal> _prod_per;
        public Nullable<decimal> prod_per
        {
            get { return _prod_per; }
            set { _prod_per = value; RaisePropertyChanged("prod_per"); }
        }

        private string _invstmnt_odr;
        public string invstmnt_odr
        {
            get { return _invstmnt_odr; }
            set { _invstmnt_odr = value; RaisePropertyChanged("invstmnt_odr"); }
        }

        private string _base_unit_code;
        public string base_unit_code
        {
            get { return _base_unit_code; }
            set { _base_unit_code = value; RaisePropertyChanged("base_unit_code"); }
        }

        private Nullable<decimal> _qty;
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set { _qty = value; RaisePropertyChanged("qty"); }
        }

        private string _asset_type_nm;
        public string asset_type_nm
        {
            get { return _asset_type_nm; }
            set { _asset_type_nm = value; RaisePropertyChanged("asset_type_nm"); }
        }

        private string _invstmnt_reason;
        public string invstmnt_reason
        {
            get { return _invstmnt_reason; }
            set { _invstmnt_reason = value; RaisePropertyChanged("invstmnt_reason"); }
        }

        private string _ind_inv;
        public string ind_inv
        {
            get { return _ind_inv; }
            set { _ind_inv = value; RaisePropertyChanged("ind_inv"); }
        }

        private Nullable<System.DateTime> _last_inv_dt;
        public Nullable<System.DateTime> last_inv_dt
        {
            get { return _last_inv_dt; }
            set { _last_inv_dt = value; RaisePropertyChanged("last_inv_dt"); }
        }

        private string _inv_specification;
        public string inv_specification
        {
            get { return _inv_specification; }
            set { _inv_specification = value; RaisePropertyChanged("inv_specification"); }
        }

        private string _prop_cls_key;
        public string prop_cls_key
        {
            get { return _prop_cls_key; }
            set { _prop_cls_key = value; RaisePropertyChanged("prop_cls_key"); }
        }

        private string _net_worth_tax;
        public string net_worth_tax
        {
            get { return _net_worth_tax; }
            set { _net_worth_tax = value; RaisePropertyChanged("net_worth_tax"); }
        }

        private Nullable<decimal> _net_worth_tax_val;
        public Nullable<decimal> net_worth_tax_val
        {
            get { return _net_worth_tax_val; }
            set { _net_worth_tax_val = value; RaisePropertyChanged("net_worth_tax_val"); }
        }

        private Nullable<decimal> _assessed_val;
        public Nullable<decimal> assessed_val
        {
            get { return _assessed_val; }
            set { _assessed_val = value; RaisePropertyChanged("assessed_val"); }
        }

        private Nullable<System.DateTime> _convynce_dt;
        public Nullable<System.DateTime> convynce_dt
        {
            get { return _convynce_dt; }
            set { _convynce_dt = value; RaisePropertyChanged("convynce_dt"); }
        }

        private Nullable<System.DateTime> _last_ntc_dt;
        public Nullable<System.DateTime> last_ntc_dt
        {
            get { return _last_ntc_dt; }

            set { _last_ntc_dt = value; RaisePropertyChanged("last_ntc_dt"); }
        }

        private string _tax_code;
        public string tax_code
        {
            get { return _tax_code; }
            set { _tax_code = value; RaisePropertyChanged("tax_code"); }
        }

        private Nullable<System.DateTime> _land_reg_of;
        public Nullable<System.DateTime> land_reg_of
        {
            get { return _land_reg_of; }
            set { _land_reg_of = value; RaisePropertyChanged("land_reg_of"); }
        }

        private Nullable<System.DateTime> _land_reg_entry_dt;
        public Nullable<System.DateTime> land_reg_entry_dt
        {
            get { return _land_reg_entry_dt; }
            set { _land_reg_entry_dt = value; RaisePropertyChanged("land_reg_entry_dt"); }
        }

        private string _land_reg_vol;
        public string land_reg_vol
        {
            get { return _land_reg_vol; }
            set { _land_reg_vol = value; RaisePropertyChanged("land_reg_vol"); }
        }

        private string _land_reg_pg;
        public string land_reg_pg
        {
            get { return _land_reg_pg; }
            set { _land_reg_pg = value; RaisePropertyChanged("land_reg_pg"); }
        }

        private string _lr_seq_no;
        public string lr_seq_no
        {
            get { return _lr_seq_no; }
            set { _lr_seq_no = value; RaisePropertyChanged("lr_seq_no"); }
        }

        private string _lr_map_no;
        public string lr_map_no
        {
            get { return _lr_map_no; }
            set { _lr_map_no = value; RaisePropertyChanged("lr_map_no"); }
        }

        private string _plot_no;
        public string plot_no
        {
            get { return _plot_no; }
            set { _plot_no = value; RaisePropertyChanged("plot_no"); }

        }

        private string _tax_offc;
        public string tax_offc
        {
            get { return _tax_offc; }
            set { _tax_offc = value; RaisePropertyChanged("tax_offc"); }
        }

        private string _municipality;
        public string municipality
        {
            get { return _municipality; }
            set { _municipality = value; RaisePropertyChanged("municipality"); }
        }

        private string _mnaul_val_reason;
        public string mnaul_val_reason
        {
            get { return _mnaul_val_reason; }
            set { _mnaul_val_reason = value; RaisePropertyChanged("mnaul_val_reason"); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private Nullable<decimal> _surface_area;
        public Nullable<decimal> surface_area
        {
            get { return _surface_area; }
            set { _surface_area = value; RaisePropertyChanged("surface_area"); }
        }

        private string _inv_no;
        public string inv_no
        {
            get { return _inv_no; }
            set { _inv_no = value; RaisePropertyChanged("inv_no"); }
        }

        private string _trdng_comp_id;
        public string trdng_comp_id
        {
            get { return _trdng_comp_id; }
            set { _trdng_comp_id = value; RaisePropertyChanged("trdng_comp_id"); }
        }

        private string _language;
        public string language
        {
            get { return _language; }
            set { _language = value; RaisePropertyChanged("language"); }
        }

        private string _asset_desc;
        public string asset_desc
        {
            get { return _asset_desc; }
            set { _asset_desc = value; RaisePropertyChanged("asset_desc"); }
        }

        private string _ind_lt_actv;
        public string ind_lt_actv
        {
            get { return _ind_lt_actv; }
            set { _ind_lt_actv = value; RaisePropertyChanged("ind_lt_actv"); }
        }

        private string _ind_lt_prop_val;
        public string ind_lt_prop_val
        {
            get { return _ind_lt_prop_val; }
            set { _ind_lt_prop_val = value; RaisePropertyChanged("ind_lt_prop_val"); }
        }

        private string _ind_tech_vieiw_lt;
        public string ind_tech_vieiw_lt
        {
            get { return _ind_tech_vieiw_lt; }
            set { _ind_tech_vieiw_lt = value; RaisePropertyChanged("ind_tech_vieiw_lt"); }
        }

        private string _ind_lt_actv1;
        public string ind_lt_actv1
        {
            get { return _ind_lt_actv1; }
            set { _ind_lt_actv1 = value; RaisePropertyChanged("ind_lt_actv1"); }
        }

        private string _ind_mfg_lt;
        public string ind_mfg_lt
        {
            get { return _ind_mfg_lt; }
            set { _ind_mfg_lt = value; RaisePropertyChanged("ind_mfg_lt"); }
        }

        private string _ind_lease_desc;
        public string ind_lease_desc
        {
            get { return _ind_lease_desc; }
            set { _ind_lease_desc = value; RaisePropertyChanged("ind_lease_desc"); }
        }

        private string _leasing_comp;
        public string leasing_comp
        {
            get { return _leasing_comp; }
            set { _leasing_comp = value; RaisePropertyChanged("leasing_comp"); }
        }

        private Nullable<System.DateTime> _leas_aggr_dt;
        public Nullable<System.DateTime> leas_aggr_dt
        {
            get { return _leas_aggr_dt; }
            set { _leas_aggr_dt = value; RaisePropertyChanged("leas_aggr_dt"); }
        }

        private Nullable<System.DateTime> _leas_aggr_ntc_dt;
        public Nullable<System.DateTime> leas_aggr_ntc_dt
        {
            get { return _leas_aggr_ntc_dt; }
            set { _leas_aggr_ntc_dt = value; RaisePropertyChanged("leas_aggr_ntc_dt"); }
        }

        private Nullable<System.DateTime> _leas_srt_dt;
        public Nullable<System.DateTime> leas_srt_dt
        {
            get { return _leas_srt_dt; }
            set { _leas_srt_dt = value; RaisePropertyChanged(" leas_srt_dt"); }
        }

        private Nullable<int> _tot_lease_yrs;
        public Nullable<int> tot_lease_yrs
        {
            get { return _tot_lease_yrs; }
            set { _tot_lease_yrs = value; RaisePropertyChanged("tot_lease_yrs"); }
        }

        private Nullable<int> _tot_lease_prd;
        public Nullable<int> tot_lease_prd
        {
            get { return _tot_lease_prd; }
            set { _tot_lease_prd = value; RaisePropertyChanged("tot_lease_prd"); }
        }

        private Nullable<int> _lease_pymnt_cycle;
        public Nullable<int> lease_pymnt_cycle
        {
            get { return _lease_pymnt_cycle; }
            set { _lease_pymnt_cycle = value; RaisePropertyChanged("lease_pymnt_cycle"); }
        }

        private Nullable<decimal> _prd_leas_pymnt_paid;
        public Nullable<decimal> prd_leas_pymnt_paid
        {
            get { return _prd_leas_pymnt_paid; }
            set { _prd_leas_pymnt_paid = value; RaisePropertyChanged("prd_leas_pymnt_paid"); }
        }

        private Nullable<decimal> _leas_base_val;
        public Nullable<decimal> leas_base_val
        {
            get { return _leas_base_val; }
            set { _leas_base_val = value; RaisePropertyChanged("leas_base_val"); }
        }

        private Nullable<decimal> _leas_asset_pur_price;
        public Nullable<decimal> leas_asset_pur_price
        {
            get { return _leas_asset_pur_price; }
            set { _leas_asset_pur_price = value; RaisePropertyChanged("leas_asset_pur_price"); }
        }


        private Nullable<decimal> _lease_mnth_intrst;
        public Nullable<decimal> lease_mnth_intrst
        {
            get { return _lease_mnth_intrst; }
            set { _lease_mnth_intrst = value; RaisePropertyChanged("lease_mnth_intrst"); }
        }

        private Nullable<decimal> _lease_intrst;
        public Nullable<decimal> lease_intrst
        {
            get { return _lease_intrst; }
            set { _lease_intrst = value; RaisePropertyChanged("lease_intrst"); }
        }

        private Nullable<System.DateTime> _leas_post_dt;
        public Nullable<System.DateTime> leas_post_dt
        {
            get { return _leas_post_dt; }
            set { _leas_post_dt = value; RaisePropertyChanged("leas_post_dt"); }
        }


        private Nullable<decimal> _tot_posted_leas_pymnt;
        public Nullable<decimal> tot_posted_leas_pymnt
        {
            get { return _tot_posted_leas_pymnt; }
            set { _tot_posted_leas_pymnt = value; RaisePropertyChanged("tot_posted_leas_pymnt"); }
        }

        private Nullable<decimal> _tot_posted_leas_prd;
        public Nullable<decimal> tot_posted_leas_prd
        {
            get { return _tot_posted_leas_prd; }
            set { _tot_posted_leas_prd = value; RaisePropertyChanged("tot_posted_leas_prd"); }
        }

        private Nullable<decimal> _tot_leas_liability;
        public Nullable<decimal> tot_leas_liability
        {
            get { return _tot_leas_liability; }
            set { _tot_leas_liability = value; RaisePropertyChanged("tot_leas_liability"); }
        }

        private Nullable<decimal> _tot_leas_pymnt;
        public Nullable<decimal> tot_leas_pymnt
        {
            get { return _tot_leas_pymnt; }
            set { _tot_leas_pymnt = value; RaisePropertyChanged("tot_leas_pymnt"); }
        }

        private string _leas_aggr_no;
        public string leas_aggr_no
        {
            get { return _leas_aggr_no; }
            set { _leas_aggr_no = value; RaisePropertyChanged("leas_aggr_no"); }
        }

        private string _lease_desc;
        public string lease_desc
        {
            get { return _lease_desc; }
            set { _lease_desc = value; RaisePropertyChanged("lease_desc"); }
        }

        private string _ind_cap_asset;
        public string ind_cap_asset
        {
            get { return _ind_cap_asset; }
            set { _ind_cap_asset = value; RaisePropertyChanged("ind_cap_asset"); }
        }

        private string _ind_reale;
        public string ind_reale
        {
            get { return _ind_reale; }
            set { _ind_reale = value; RaisePropertyChanged("ind_reale"); }
        }

        private string _obj_no;
        public string obj_no
        {
            get { return _obj_no; }
            set { _obj_no = value; RaisePropertyChanged("obj_no"); }
        }

        private string _leasing_type;
        public string leasing_type
        {
            get { return _leasing_type; }
            set { _leasing_type = value; RaisePropertyChanged("leasing_type"); }
        }

        private Nullable<bool> _adv_pymnt;
        public Nullable<bool> adv_pymnt
        {
            get { return _adv_pymnt; }
            set { _adv_pymnt = value; RaisePropertyChanged("adv_pymnt"); }
        }

        private string _wbs_elmnt_invst_proj;
        public string wbs_elmnt_invst_proj
        {
            get { return _wbs_elmnt_invst_proj; }
            set { _wbs_elmnt_invst_proj = value; RaisePropertyChanged("wbs_elmnt_invst_proj"); }
        }

        private string _ind_ignore_memo_val;
        public string ind_ignore_memo_val
        {
            get { return _ind_ignore_memo_val; }
            set { _ind_ignore_memo_val = value; RaisePropertyChanged("ind_ignore_memo_val"); }
        }

        private string _asset_aqui_used;
        public string asset_aqui_used
        {
            get { return _asset_aqui_used; }
            set { _asset_aqui_used = value; RaisePropertyChanged("asset_aqui_used"); }
        }

        private string _is_grp_asset;
        public string is_grp_asset
        {
            get { return _is_grp_asset; }
            set { _is_grp_asset = value; RaisePropertyChanged("is_grp_asset"); }
        }

        private string _auc_invst;
        public string auc_invst
        {
            get { return _auc_invst; }
            set { _auc_invst = value; RaisePropertyChanged("auc_invst"); }
        }

        private string _serial_no;
        public string serial_no
        {
            get { return _serial_no; }
            set { _serial_no = value; RaisePropertyChanged("serial_no"); }
        }

        private string _envrmnt_invst_reason;
        public string envrmnt_invst_reason
        {
            get { return _envrmnt_invst_reason; }
            set { _envrmnt_invst_reason = value; RaisePropertyChanged("envrmnt_invst_reason"); }
        }

        private Nullable<System.DateTime> _last_reval_dt;
        public Nullable<System.DateTime> last_reval_dt
        {
            get { return _last_reval_dt; }
            set { _last_reval_dt = value; RaisePropertyChanged("last_reval_dt"); }
        }

        private Nullable<System.DateTime> _last_reorg_dt;
        public Nullable<System.DateTime> last_reorg_dt
        {
            get { return _last_reorg_dt; }
            set { _last_reorg_dt = value; RaisePropertyChanged("last_reorg_dt"); }
        }

        private string _asset_td_val_param;
        public string asset_td_val_param
        {
            get { return _asset_td_val_param; }
            set { _asset_td_val_param = value; RaisePropertyChanged("asset_td_val_param"); }
        }

        private bool _active;
        public bool active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }

        private string _asset_name;
        public string asset_name
        {
            get { return _asset_name; }
            set { _asset_name = value; RaisePropertyChanged("asset_name"); }
        }

        private string _country_code;
        public string country_code
        {
            get { return _country_code; }
            set { _country_code = value; RaisePropertyChanged("country_code"); }
        }

        private Nullable<bool> _asset_acqui_used;
        public Nullable<bool> asset_acqui_used
        {
            get { return _asset_acqui_used; }
            set { _asset_acqui_used = value; RaisePropertyChanged("asset_acqui_used"); }
        }

        private Nullable<bool> _asset_acqui_new;
        public Nullable<bool> asset_acqui_new
        {
            get { return _asset_acqui_new; }
            set { _asset_acqui_new = value; RaisePropertyChanged("asset_acqui_new"); }
        }

        #region Scalar Variables ACC_M002
       
        private string _gl_name;
        public string gl_name
        {
            get { return _gl_name; }
            set
            {
                _gl_name = value;
                RaisePropertyChanged("gl_name");
            }
        }

        private string _leasing_comp_desc;
        public string leasing_comp_desc
        {
            get { return _leasing_comp_desc; }
            set { _leasing_comp_desc = value; RaisePropertyChanged("leasing_comp_desc"); }
        }

        private string _asset_class_desc;
        public string asset_class_desc
        {
            get { return _asset_class_desc; }
            set { _asset_class_desc = value; RaisePropertyChanged("asset_class_desc"); }
        }

        private string _vendor_code;
        public string vendor_code
        {
            get { return _vendor_code; }
            set
            {
                _vendor_code = value;
                RaisePropertyChanged("vendor_code");
            }
        }

        private bool _Fltr_active;
        public bool Fltr_active
        {
            get { return _Fltr_active; }
            set
            {
                if (_Fltr_active != value)
                {
                    _Fltr_active = value;
                    RaisePropertyChanged("Fltr_active");
                }
            }
        }

        private DateTime? _Fltr_FrmDate;
        public DateTime? Fltr_FrmDate   //FrmDate
        {
            get { return _Fltr_FrmDate; }
            set
            {
                if (_Fltr_FrmDate != value)
                {
                    _Fltr_FrmDate = value;
                    RaisePropertyChanged("Fltr_FrmDate");
                }
            }
        }

        private DateTime? _Fltr_ToDate;
        public DateTime? Fltr_ToDate    //ToDate
        {

            get { return _Fltr_ToDate; }
            set
            {
                if (_Fltr_ToDate != value)
                {
                    _Fltr_ToDate = value;
                    RaisePropertyChanged("Fltr_ToDate");
                }
            }
        }

        private string _fltr_t_status;
        public string fltr_t_status
        {
            get { return _fltr_t_status; }
            set
            {
                if (_fltr_t_status != value)
                {
                    _fltr_t_status = value; RaisePropertyChanged("fltr_t_status");
                }
            }
        }

        private string _fltr_t_display;
        public string fltr_t_display
        {
            get { return _fltr_t_display; }
            set
            {
                if (_fltr_t_display != value)
                {
                    _fltr_t_display = value; RaisePropertyChanged("fltr_t_display");
                }
            }
        }

        private string _fltr_location_Id;
        public string fltr_location_Id
        {
            get { return _fltr_location_Id; }
            set
            {
                if (_fltr_location_Id != value)
                {
                    _fltr_location_Id = value; RaisePropertyChanged("fltr_location_Id");
                }
            }
        }

        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; RaisePropertyChanged("ItemName"); }
        }

        private string _dep_area_desc;
        public string dep_area_desc
        {
            get { return _dep_area_desc; }
            set { _dep_area_desc = value; RaisePropertyChanged("dep_area_desc"); }
        }

        private string _fltr_AssetClass;
        public string fltr_AssetClass
        {
            get { return _fltr_AssetClass; }
            set
            {
                if (_fltr_AssetClass != value)
                {
                    _fltr_AssetClass = value; RaisePropertyChanged("fltr_AssetClass");
                }
            }
        }

        private string _fltr_AssetName;
        public string fltr_AssetName
        {
            get { return _fltr_AssetName; }
            set
            {
                if (_fltr_AssetName != value)
                {
                    _fltr_AssetName = value; RaisePropertyChanged("fltr_AssetName");
                }
            }
        }

        public string XmlDataDocument_ACC_M002_FLIP { get; set; }
        public string XmlDataDocument_ACC_M002_I1 { get; set; }
        public string XmlDataDocument_ACC_M002_H { get; set; }
        public string XmlDataDocument_ACC_M002_B { get; set; }
        #endregion

    }
    public class ACC_M002_B : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

      
        private string _asset_no;
        public string asset_no
        {
            get { return _asset_no; }
            set { _asset_no = value; RaisePropertyChanged("asset_no"); }
        }

        private string _asset_sub_no;
        public string asset_sub_no
        {
            get { return _asset_sub_no; }
            set { _asset_sub_no = value; RaisePropertyChanged("asset_sub_no"); }
        }

        private int _dep_area;
        public int dep_area
        {
            get { return _dep_area; }
            set { _dep_area = value; RaisePropertyChanged("dep_area"); }
        }

        private Nullable<System.DateTime> _vldty_end_dt;
        public Nullable<System.DateTime> vldty_end_dt
        {
            get { return _vldty_end_dt; }
            set { _vldty_end_dt = value; RaisePropertyChanged("vldty_end_dt"); }
        }

        private Nullable<System.DateTime> _vldty_bgn_dt;
        public Nullable<System.DateTime> vldty_bgn_dt
        {
            get { return _vldty_bgn_dt; }
            set { _vldty_bgn_dt = value; RaisePropertyChanged("_vldty_bgn_dt"); }
        }

        private string _ind_asset_dlt;
        public string ind_asset_dlt
        {
            get { return _ind_asset_dlt; }
            set { _ind_asset_dlt = value; RaisePropertyChanged("ind_asset_dlt"); }
        }

        private string _ind_asset_locked;
        public string ind_asset_locked
        {
            get { return _ind_asset_locked; }
            set { _ind_asset_locked = value; RaisePropertyChanged("ind_asset_locked"); }
        }

        private string _asset_amnt_qty_chk;
        public string asset_amnt_qty_chk
        {
            get { return _asset_amnt_qty_chk; }
            set { _asset_amnt_qty_chk = value; RaisePropertyChanged("asset_amnt_qty_chk"); }
        }

        private string _ind_dep_asset_tot;
        public string ind_dep_asset_tot
        {
            get { return _ind_dep_asset_tot; }
            set { _ind_dep_asset_tot = value; RaisePropertyChanged("ind_dep_asset_tot"); }
        }

        private Nullable<System.DateTime> _dep_cal_srt_dt;
        public Nullable<System.DateTime> dep_cal_srt_dt
        {
            get { return _dep_cal_srt_dt; }
            set { _dep_cal_srt_dt = value; RaisePropertyChanged("dep_cal_srt_dt"); }
        }

        private Nullable<System.DateTime> _int_cal_srt_dt;
        public Nullable<System.DateTime> int_cal_srt_dt
        {
            get { return _int_cal_srt_dt; }
            set { _int_cal_srt_dt = value; RaisePropertyChanged("int_cal_srt_dt"); }
        }

        private Nullable<System.DateTime> _spl_cal_srt_dt;
        public Nullable<System.DateTime> spl_cal_srt_dt
        {
            get { return _spl_cal_srt_dt; }
            set { _spl_cal_srt_dt = value; RaisePropertyChanged("spl_cal_srt_dt"); }
        }

        private string _invst_spprt_key;
        public string invst_spprt_key
        {
            get { return _invst_spprt_key; }
            set { _invst_spprt_key = value; RaisePropertyChanged("invst_spprt_key"); }
        }

        private string _dep_key;
        public string dep_key
        {
            get { return _dep_key; }
            set { _dep_key = value; RaisePropertyChanged("dep_key"); }
        }

        private Nullable<int> _planned_life_yrs;
        public Nullable<int> planned_life_yrs
        {
            get { return _planned_life_yrs; }
            set { _planned_life_yrs = value; RaisePropertyChanged("planned_life_yrs"); }
        }

        private Nullable<int> _planned_life_prd;
        public Nullable<int> planned_life_prd
        {
            get { return _planned_life_prd; }
            set { _planned_life_prd = value; RaisePropertyChanged("planned_life_prd"); }
        }

        private Nullable<decimal> _ord_dep_per_rt;
        public Nullable<decimal> ord_dep_per_rt
        {
            get { return _ord_dep_per_rt; }
            set { _ord_dep_per_rt = value; RaisePropertyChanged("ord_dep_per_rt"); }
        }

        private Nullable<decimal> _spl_dep_per_rt;
        public Nullable<decimal> spl_dep_per_rt
        {
            get { return _spl_dep_per_rt; }
            set { _spl_dep_per_rt = value; RaisePropertyChanged("spl_dep_per_rt"); }
        }

        private string _rplcmnt_indx_series;
        public string rplcmnt_indx_series
        {
            get { return _rplcmnt_indx_series; }
            set { _rplcmnt_indx_series = value; RaisePropertyChanged("rplcmnt_indx_series"); }
        }

        private string _rplcmnt_indx_series_age;
        public string rplcmnt_indx_series_age
        {
            get { return _rplcmnt_indx_series_age; }
            set { _rplcmnt_indx_series_age = value; RaisePropertyChanged("rplcmnt_indx_series_age"); }
        }

        private Nullable<decimal> _var_dep_portion;
        public Nullable<decimal> var_dep_portion
        {
            get { return _var_dep_portion; }
            set { _var_dep_portion = value; RaisePropertyChanged("var_dep_portion"); }
        }

        private Nullable<int> _chngovr_yr_dep_k;
        public Nullable<int> chngovr_yr_dep_k
        {
            get { return _chngovr_yr_dep_k; }
            set { _chngovr_yr_dep_k = value; RaisePropertyChanged("chngovr_yr_dep_k"); }
        }

        private int _orgnl_usfl_life_yrs;
        public int orgnl_usfl_life_yrs
        {
            get { return _orgnl_usfl_life_yrs; }
            set { _orgnl_usfl_life_yrs = value; RaisePropertyChanged("orgnl_usfl_life_yrs"); }
        }

        private Nullable<int> _orgnl_usfl_life_prd;
        public Nullable<int> orgnl_usfl_life_prd
        {
            get { return _orgnl_usfl_life_prd; }
            set { _orgnl_usfl_life_prd = value; RaisePropertyChanged("orgnl_usfl_life_prd"); }
        }

        private Nullable<decimal> _asset_scrap_val;
        public Nullable<decimal> asset_scrap_val
        {
            get { return _asset_scrap_val; }
            set { _asset_scrap_val = value; RaisePropertyChanged("asset_scrap_val"); }
        }

        private string _lst_fin_yr;
        public string lst_fin_yr
        {
            get { return _lst_fin_yr; }
            set { _lst_fin_yr = value; RaisePropertyChanged("lst_fin_yr"); }
        }

        private Nullable<int> _prd_scaling;
        public Nullable<int> prd_scaling
        {
            get { return _prd_scaling; }
            set { _prd_scaling = value; RaisePropertyChanged("prd_scaling"); }
        }

        private Nullable<int> _reval;
        public Nullable<int> reval
        {
            get { return _reval; }
            set { _reval = value; RaisePropertyChanged("reval"); }
        }

        private string _grp_asset;
        public string grp_asset
        {
            get { return _grp_asset; }
            set { _grp_asset = value; RaisePropertyChanged("grp_asset"); }
        }

        private string _grp_asset_subno;
        public string grp_asset_subno
        {
            get { return _grp_asset_subno; }
            set { _grp_asset_subno = value; RaisePropertyChanged("grp_asset_subno"); }
        }

        private string _asset_aqui_yr;
        public string asset_aqui_yr
        {
            get { return _asset_aqui_yr; }
            set { _asset_aqui_yr = value; RaisePropertyChanged("asset_aqui_yr"); }
        }

        private string _asset_aqui_mnth;
        public string asset_aqui_mnth
        {
            get { return _asset_aqui_mnth; }
            set { _asset_aqui_mnth = value; RaisePropertyChanged("asset_aqui_mnth"); }
        }

        private Nullable<System.DateTime> _oprtng_readiness_dt;
        public Nullable<System.DateTime> oprtng_readiness_dt
        {
            get { return _oprtng_readiness_dt; }
            set { _oprtng_readiness_dt = value; RaisePropertyChanged("oprtng_readiness_dt"); }
        }

        private Nullable<System.DateTime> _da_last_rtrmnt_val_dt;
        public Nullable<System.DateTime> da_last_rtrmnt_val_dt
        {
            get { return _da_last_rtrmnt_val_dt; }
            set { _da_last_rtrmnt_val_dt = value; RaisePropertyChanged("da_last_rtrmnt_val_dt"); }
        }

        private string _reval_key;
        public string reval_key
        {
            get { return _reval_key; }
            set { _reval_key = value; RaisePropertyChanged("reval_key"); }
        }

        private Nullable<System.DateTime> _last_reval_dt;
        public Nullable<System.DateTime> last_reval_dt
        {
            get { return _last_reval_dt; }
            set { _last_reval_dt = value; RaisePropertyChanged("last_reval_dt"); }
        }

        private string _last_indx_used;
        public string last_indx_used
        {
            get { return _last_indx_used; }
            set { _last_indx_used = value; RaisePropertyChanged("last_indx_used"); }
        }

        private Nullable<decimal> _scrap_val_per;
        public Nullable<decimal> scrap_val_per
        {
            get { return _scrap_val_per; }
            set { _scrap_val_per = value; RaisePropertyChanged("scrap_val_per"); }
        }

        private Nullable<int> _dk_chngovr_prd;
        public Nullable<int> dk_chngovr_prd
        {
            get { return _dk_chngovr_prd; }
            set { _dk_chngovr_prd = value; RaisePropertyChanged("dk_chngovr_prd"); }
        }

        private bool _active;
        public bool active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        
        //Scalar

        private string _dep_area_desc;
        public string dep_area_desc
        {
            get { return _dep_area_desc; }
            set { _dep_area_desc = value; RaisePropertyChanged("dep_area_desc"); }
        }

        private string _dep_key_desc;
        public string dep_key_desc
        {
            get { return _dep_key_desc; }
            set { _dep_key_desc = value; RaisePropertyChanged("dep_key_desc"); }
        }
        public string XmlDataDocument_ACC_M002_D_FLIP { get; set; }
    }
    public class ACC_M002_H : ObjectBase
    {
       

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _asset_no;
        public string asset_no
        {
            get { return _asset_no; }
            set { _asset_no = value; RaisePropertyChanged("asset_no"); }
        }

        private string _asset_sub_no;
        public string asset_sub_no
        {
            get { return _asset_sub_no; }
            set { _asset_sub_no = value; RaisePropertyChanged("asset_sub_no"); }
        }

        private Nullable<System.DateTime> _vldty_end_dt;
        public Nullable<System.DateTime> vldty_end_dt
        {
            get { return _vldty_end_dt; }
            set { _vldty_end_dt = value; RaisePropertyChanged("vldty_end_dt"); }
        }

        private Nullable<System.DateTime> _vldty_bgn_dt;
        public Nullable<System.DateTime> vldty_bgn_dt
        {
            get { return _vldty_bgn_dt; }
            set { _vldty_bgn_dt = value; RaisePropertyChanged("vldty_bgn_dt"); }
        }


        private string _buss_place;
        public string buss_place
        {
            get { return _buss_place; }
            set { _buss_place = value; RaisePropertyChanged("buss_place"); }
        }

        private string _plant;
        public string plant
        {
            get { return _plant; }
            set { _plant = value; RaisePropertyChanged("plant"); }
        }

        private string _activity_type;
        public string activity_type
        {
            get { return _activity_type; }
            set { _activity_type = value; RaisePropertyChanged("activity_type"); }
        }

        private Nullable<decimal> _shift_factor;
        public Nullable<decimal> shift_factor
        {
            get { return _shift_factor; }
            set { _shift_factor = value; RaisePropertyChanged("shift_factor"); }
        }

        private Nullable<bool> _ind_asst_shtdwn;
        public Nullable<bool> ind_asst_shtdwn
        {
            get { return _ind_asst_shtdwn; }
            set { _ind_asst_shtdwn = value; RaisePropertyChanged("ind_asst_shtdwn"); }
        }

        private string _asset_location;
        public string asset_location
        {
            get { return _asset_location; }
            set { _asset_location = value; RaisePropertyChanged("asset_location"); }
        }

        private string _int_order;
        public string int_order
        {
            get { return _int_order; }
            set { _int_order = value; RaisePropertyChanged("int_order"); }
        }

        private string _room;
        public string room
        {
            get { return _room; }
            set { _room = value; RaisePropertyChanged("room"); }
        }

        private string _mntnce_order;
        public string mntnce_order
        {
            get { return _mntnce_order; }
            set { _mntnce_order = value; RaisePropertyChanged("mntnce_order"); }
        }

        private string _fnctnl_lctn;
        public string fnctnl_lctn
        {
            get { return _fnctnl_lctn; }
            set { _fnctnl_lctn = value; RaisePropertyChanged("fnctnl_lctn"); }
        }

        private string _tax_Jurisdiction;
        public string tax_Jurisdiction
        {
            get { return _tax_Jurisdiction; }
            set { _tax_Jurisdiction = value; RaisePropertyChanged("tax_Jurisdiction"); }
        }

        private Nullable<int> _wbs_elmnt;
        public Nullable<int> wbs_elmnt
        {
            get { return _wbs_elmnt; }
            set { _wbs_elmnt = value; RaisePropertyChanged("wbs_elmnt"); }
        }

        private string _lcnce_plate_no;
        public string lcnce_plate_no
        {
            get { return _lcnce_plate_no; }
            set { _lcnce_plate_no = value; RaisePropertyChanged("lcnce_plate_no"); }
        }

        private string _prsnl_no;
        public string prsnl_no
        {
            get { return _prsnl_no; }
            set { _prsnl_no = value; RaisePropertyChanged("prsnl_no"); }
        }

        private string _cost_center;
        public string cost_center
        {
            get { return _cost_center; }
            set { _cost_center = value; RaisePropertyChanged("cost_center"); }
        }

        private string _funds_center;
        public string funds_center
        {
            get { return _funds_center; }
            set { _funds_center = value; RaisePropertyChanged("funds_center"); }
        }

        private string _fund;
        public string fund
        {
            get { return _fund; }
            set { _fund = value; RaisePropertyChanged("fund"); }
        }

        private string _fnctnl_area;
        public string fnctnl_area
        {
            get { return _fnctnl_area; }
            set { _fnctnl_area = value; RaisePropertyChanged("fnctnl_area"); }
        }

        private string _grnt;
        public string grnt
        {
            get { return _grnt; }
            set { _grnt = value; RaisePropertyChanged("grnt"); }
        }

        private string _funds_center_aaa;
        public string funds_center_aaa
        {
            get { return _funds_center_aaa; }
            set { _funds_center_aaa = value; RaisePropertyChanged("funds_center_aaa"); }
        }

        private string _fund_aaa;
        public string fund_aaa
        {
            get { return _fund_aaa; }
            set { _fund_aaa = value; RaisePropertyChanged("fund_aaa"); }
        }

        private string _fnctnl_area_aaa;
        public string fnctnl_area_aaa
        {
            get { return _fnctnl_area_aaa; }
            set { _fnctnl_area_aaa = value; RaisePropertyChanged("fnctnl_area_aaa"); }
        }

        private string _grnt_aaa;
        public string grnt_aaa
        {
            get { return _grnt_aaa; }
            set { _grnt_aaa = value; RaisePropertyChanged("grnt_aaa"); }
        }

        private string _int_key_reale;
        public string int_key_reale
        {
            get { return _int_key_reale; }
            set { _int_key_reale = value; RaisePropertyChanged("int_key_reale"); }
        }

        private Nullable<int> _wbs_elmnt_cost;
        public Nullable<int> wbs_elmnt_cost
        {
            get { return _wbs_elmnt_cost; }
            set { _wbs_elmnt_cost = value; RaisePropertyChanged("wbs_elmnt_cost"); }
        }
        private string _fm_bdgt_prd;
        public string fm_bdgt_prd
        {
            get { return _fm_bdgt_prd; }
            set { _fm_bdgt_prd = value; RaisePropertyChanged("fm_bdgt_prd"); }
        }

        private string _bdgt_prd_aaa;
        public string bdgt_prd_aaa
        {
            get { return _bdgt_prd_aaa; }
            set { _bdgt_prd_aaa = value; RaisePropertyChanged("bdgt_prd_aaa"); }
        }

        private string _profit_center;
        public string profit_center
        {
            get { return _profit_center; }
            set { _profit_center = value; RaisePropertyChanged("profit_center"); }
        }

        private bool _active;
        public bool active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }
        
        //scalar 
        private string _plantName;
        public string plantName
        {
            get { return _plantName; }
            set { _plantName = value; RaisePropertyChanged("plantName"); }
        }


    }
    public class ACC_M002_I1 : ObjectBase
    {

       
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _asset_no;
        public string asset_no
        {
            get { return _asset_no; }
            set { _asset_no = value; RaisePropertyChanged("asset_no"); }
        }

        private string _asset_sub_no;
        public string asset_sub_no
        {
            get { return _asset_sub_no; }
            set { _asset_sub_no = value; RaisePropertyChanged("asset_sub_no"); }
        }
        private Nullable<int> _seq_no;
        public Nullable<int> seq_no
        {
            get { return _seq_no; }
            set { _seq_no = value; RaisePropertyChanged("seq_no"); }
        }

        private string _insurance_type;
        public string insurance_type
        {
            get { return _insurance_type; }
            set { _insurance_type = value; RaisePropertyChanged("insurance_type"); }
        }

        private string _insu_indx_series;
        public string insu_indx_series
        {
            get { return _insu_indx_series; }
            set { _insu_indx_series = value; RaisePropertyChanged("insu_indx_series"); }
        }

        private Nullable<decimal> _base_insu_val;
        public Nullable<decimal> base_insu_val
        {
            get { return _base_insu_val; }
            set { _base_insu_val = value; RaisePropertyChanged("base_insu_val"); }
        }

        private Nullable<decimal> _base_insu_val1;
        public Nullable<decimal> base_insu_val1
        {
            get { return _base_insu_val1; }
            set { _base_insu_val1 = value; RaisePropertyChanged("base_insu_val1"); }
        }

        private string _insu_comp;
        public string insu_comp
        {
            get { return _insu_comp; }
            set { _insu_comp = value; RaisePropertyChanged("insu_comp"); }
        }

        private string _ind_updt_val_mnuly;
        public string ind_updt_val_mnuly
        {
            get { return _ind_updt_val_mnuly; }
            set { _ind_updt_val_mnuly = value; RaisePropertyChanged("ind_updt_val_mnuly"); }
        }

        private Nullable<decimal> _mnuly_insu_val;
        public Nullable<decimal> mnuly_insu_val
        {
            get { return _mnuly_insu_val; }
            set { _mnuly_insu_val = value; RaisePropertyChanged("mnuly_insu_val"); }
        }

        private string _fin_yr_imv;
        public string fin_yr_imv
        {
            get { return _fin_yr_imv; }
            set { _fin_yr_imv = value; RaisePropertyChanged("fin_yr_imv"); }
        }

        private string _old_fin_yr_imv;
        public string old_fin_yr_imv
        {
            get { return _old_fin_yr_imv; }
            set { _old_fin_yr_imv = value; RaisePropertyChanged("old_fin_yr_imv"); }
        }

        private Nullable<System.DateTime> _i_strt_dt;
        public Nullable<System.DateTime> i_strt_dt
        {
            get { return _i_strt_dt; }
            set { _i_strt_dt = value; RaisePropertyChanged("i_strt_dt"); }
        }

        private string _i_rate;
        public string i_rate
        {
            get { return _i_rate; }
            set { _i_rate = value; RaisePropertyChanged("i_rate"); }
        }

        private string _i_policy_no;
        public string i_policy_no
        {
            get { return _i_policy_no; }
            set { _i_policy_no = value; RaisePropertyChanged("i_policy_no"); }
        }

        private string _i_desc;
        public string i_desc
        {
            get { return _i_desc; }
            set { _i_desc = value; RaisePropertyChanged("i_desc"); }
        }

        private Nullable<int> _ap_seq_no;
        public Nullable<int> ap_seq_no
        {
            get { return _ap_seq_no; }
            set { _ap_seq_no = value; RaisePropertyChanged("ap_seq_no"); }
        }

        private bool _active;
        public bool active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }
        
        private string _asset_mgf;
        public string asset_mgf
        {
            get { return _asset_mgf; }
            set { _asset_mgf = value; RaisePropertyChanged("asset_mgf"); }
        }
    }
    public class ACC_M002_Flip
    {
        public string asset_no { get; set; }
        public string asset_class { get; set; }
        public string asset_name { get; set; }
        public string asset_sub_no { get; set; }
    }
    public class MultipleContext_ACC_M002
    {
        public List<ACC_M002> MasterList { get; set; }
        public List<ACC_M002_I1> InsuranceDataList { get; set; }
        public List<ACC_M002_H> AssetAllocationList { get; set; }
        public ObservableCollection<ACC_M002_B> AssetMaster_DepAreaList { get; set; }
        public List<ACC_M002_D> DepAreaAssiList { get; set; }
        public List<ACC_M002_L_P> AccDtrList { get; set; }
        public List<ACC_M002_C_P> AssetClassList { get; set; }
        public List<ADM_M022_P> InvetoryNoList { get; set; }
        public List<ACC_M002_Flip> FlipGridData { get; set; }
        public List<ACC_M001A_P> FinYearList { get; set; }
        public List<ADM_M003_C_P> BussAreaList { get; set; }
        public List<ACC_M019_P> CostCenterList { get; set; }
        public List<ADM_M028_P> PartyList { get; set; }
        public List<ADM_M012_P> CountryList { get; set; }
        public List<ACC_M002_K_P> DepKeyList { get; set; }
        public List<ACC_M002_R_P> DepAreaList { get; set; }
        // public List<ACC_M002_H> AnalysisGrpList { get; set; }
        // public List<ACC_M002_H> InternalOrderList { get; set; }
    }
}
