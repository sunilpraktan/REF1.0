using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Asset_Management
{
    public class ACC_M002_C : ObjectBase
    { 
       
        private string _asset_name;
        public string asset_name
        {
            get { return _asset_name; }
            set { _asset_name = value; RaisePropertyChanged("asset_name"); }
        }

        private string _asset_class;
        public string asset_class
        {
            get { return _asset_class; }
            set { _asset_class = value; RaisePropertyChanged("asset_class"); }
        }

        private Nullable<bool> _ind_asset_dlt;
        public Nullable<bool> ind_asset_dlt
        {
            get { return _ind_asset_dlt; }
            set { _ind_asset_dlt = value; RaisePropertyChanged("ind_asset_dlt"); }
        }

        private Nullable<bool> _ind_asset_block;
        public Nullable<bool> ind_asset_block
        {
            get { return _ind_asset_block; }
            set { _ind_asset_block = value; RaisePropertyChanged("ind_asset_block"); }
        }

        private Nullable<bool> _auc_settlmt;
        public Nullable<bool> auc_settlmt
        {
            get { return _auc_settlmt; }
            set { _auc_settlmt = value; RaisePropertyChanged("auc_settlmt"); }
        }

        private string _acc_dtr;
        public string acc_dtr
        {
            get { return _acc_dtr; }
            set { _acc_dtr = value; RaisePropertyChanged("acc_dtr"); }
        }

        private string _athrztn_grp;
        public string athrztn_grp
        {
            get { return _athrztn_grp; }
            set { _athrztn_grp = value; RaisePropertyChanged("athrztn_grp"); }
        }

        private string _buss_area;
        public string buss_area
        {
            get { return _buss_area; }
            set { _buss_area = value; RaisePropertyChanged("buss_area"); }
        }

        private string _cost_center;
        public string cost_center
        {
            get { return _cost_center; }
            set { _cost_center = value; RaisePropertyChanged("cost_center"); }
        }

        private string _activity_type;
        public string activity_type
        {
            get { return _activity_type; }
            set { _activity_type = value; RaisePropertyChanged("activity_type"); }
        }

        private string _ind_hist_mgm;
        public string ind_hist_mgm
        {
            get
            { return _ind_hist_mgm; }
            set { _ind_hist_mgm = value; RaisePropertyChanged("ind_hist_mgm"); }
        }


        private string _sorting_key;
        public string sorting_key
        {
            get { return _sorting_key; }
            set { _sorting_key = value; RaisePropertyChanged("sorting_key"); }
        }

        private string _ind_compet;
        public string ind_compet
        {
            get { return _ind_compet; }
            set { _ind_compet = value; RaisePropertyChanged("ind_compet"); }
        }

        private string _ind_matchcode;
        public string ind_matchcode
        {
            get { return _ind_matchcode; }
            set { _ind_matchcode = value; RaisePropertyChanged("ind_matchcode"); }
        }

        private string _country_code;
        public string country_code
        {
            get { return _country_code; }
            set { _country_code = value; RaisePropertyChanged("country_code"); }
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

        private string _Asset_super_no;
        public string Asset_super_no
        {
            get { return _Asset_super_no; }
            set { _Asset_super_no = value; RaisePropertyChanged("Asset_super_no"); }
        }

        private string _ind_property;
        public string ind_property
        {
            get { return _ind_property; }
            set { _ind_property = value; RaisePropertyChanged("ind_property"); }
        }

        private string _prop_cls_key;
        public string prop_cls_key
        {
            get { return _prop_cls_key; }
            set { _prop_cls_key = value; RaisePropertyChanged("prop_cls_key"); }
        }

        private Nullable<bool> _net_worth_tax;
        public Nullable<bool> net_worth_tax
        {
            get { return _net_worth_tax; }
            set { _net_worth_tax = value; RaisePropertyChanged("net_worth_tax"); }
        }

        private string _invst_spprt_key;
        public string invst_spprt_key
        {
            get { return _invst_spprt_key; }
            set { _invst_spprt_key = value; RaisePropertyChanged("invst_spprt_key"); }
        }

        private string _invst_reason;
        public string invst_reason
        {
            get { return _invst_reason; }
            set { _invst_reason = value; RaisePropertyChanged("invst_reason"); }
        }

        private string _asset_mfg;
        public string asset_mfg
        {
            get { return _asset_mfg; }
            set { _asset_mfg = value; RaisePropertyChanged("asset_mfg"); }
        }

        private string _base_unit_code;
        public string base_unit_code
        {
            get { return _base_unit_code; }
            set { _base_unit_code = value; RaisePropertyChanged("base_unit_code"); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private Nullable<bool> _ind_inv;
        public Nullable<bool> ind_inv
        {
            get { return _ind_inv; }
            set { _ind_inv = value; RaisePropertyChanged("ind_inv"); }
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

        private string _asset_cat;
        public string asset_cat
        {
            get { return _asset_cat; }
            set { _asset_cat = value; RaisePropertyChanged("asset_cat"); }
        }

        private Nullable<bool> _asset_assgnmnt;
        public Nullable<bool> asset_assgnmnt
        {
            get { return _asset_assgnmnt; }
            set { _asset_assgnmnt = value; RaisePropertyChanged("asset_assgnmnt"); }
        }

        private Nullable<bool> _ind_cap_asset;
        public Nullable<bool> ind_cap_asset
        {
            get { return _ind_cap_asset; }
            set { _ind_cap_asset = value; RaisePropertyChanged("ind_cap_asset"); }
        }

        private string _leasing_comp;
        public string leasing_comp
        {
            get { return _leasing_comp; }
            set { _leasing_comp = value; RaisePropertyChanged("leasing_comp"); }
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

        private Nullable<decimal> _lease_mnth_intrst;
        public Nullable<decimal> lease_mnth_intrst
        {
            get { return _lease_mnth_intrst; }
            set { _lease_mnth_intrst = value; RaisePropertyChanged("lease_mnth_intrst"); }
        }

        private Nullable<decimal> _tot_lease_pymnts;
        public Nullable<decimal> tot_lease_pymnts
        {
            get { return _tot_lease_pymnts; }
            set { _tot_lease_pymnts = value; RaisePropertyChanged("tot_lease_pymnts"); }
        }

        private string _lease_desc;
        public string lease_desc
        {
            get { return _lease_desc; }
            set { _lease_desc = value; RaisePropertyChanged("lease_desc"); }
        }

        private string _ind_reale;
        public string ind_reale
        {
            get { return _ind_reale; }
            set { _ind_reale = value; RaisePropertyChanged("ind_reale"); }
        }

        private Nullable<bool> _ind_grp_asset;
        public Nullable<bool> ind_grp_asset
        {
            get { return _ind_grp_asset; }
            set { _ind_grp_asset = value; RaisePropertyChanged("ind_grp_asset"); }
        }

        private Nullable<bool> _auc_invst;
        public Nullable<bool> auc_invst
        {
            get { return _auc_invst; }
            set { _auc_invst = value; RaisePropertyChanged("auc_invst"); }
        }

        private string _leasing_type;
        public string leasing_type
        {
            get { return _leasing_type; }
            set { _leasing_type = value; RaisePropertyChanged("leasing_type"); }
        }

        private string _cap_key;
        public string cap_key
        {
            get { return _cap_key; }
            set { _cap_key = value; RaisePropertyChanged("cap_key"); }
        }

        private string _asset_desc;
        public string asset_desc
        {
            get { return _asset_desc; }
            set { _asset_desc = value; RaisePropertyChanged("asset_desc"); }
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
        
        #region Scalar : ACC_M002_C 

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

        private string _acc_dtr_desc;
        public string acc_dtr_desc
        {
            get { return _acc_dtr_desc; }
            set { _acc_dtr_desc = value; RaisePropertyChanged("acc_dtr_desc"); }
        }

        private string _unit_name;
        public string unit_name
        {
            get { return _unit_name; }
            set { _unit_name = value; RaisePropertyChanged("unit_name"); }
        }
        public string XmlDataDocument_ACC_M002_C_FLIP { get; set; }

        #endregion
    }
    public class ACC_M002_C_Flip  //Asset Class Master Flip
    {
        public string asset_class { get; set; }
        public string asset_name { get; set; }
        public string asset_desc { get; set; }
    }
    public class MultipleContext_ACC_M002_C
    {
        public List<ACC_M002_C> MasterList { get; set; }
        public List<ACC_M002_C_Flip> FlipGridData { get; set; }
        public List<ADM_M038_B_P> BaseUnitList { get; set; }
        public List<ACC_M002_L_P> AccDtrList { get; set; }

    }
}
