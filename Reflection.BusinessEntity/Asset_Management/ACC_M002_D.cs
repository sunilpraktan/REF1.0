using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Asset_Management
{
    public class ACC_M002_D : ObjectBase
    {
        private int _dep_area;
        public int dep_area
        {
            get { return _dep_area; }
            set { _dep_area = value; RaisePropertyChanged("dep_area"); }
        }

        private string _cod;
        public string cod
        {
            get { return _cod; }
            set { _cod = value; RaisePropertyChanged("cod"); }
        }

        private string _asset_class;
        public string asset_class
        {
            get { return _asset_class; }
            set { _asset_class = value; RaisePropertyChanged("asset_class"); }
        }

        private Nullable<System.DateTime> _vldty_end_dt;
        public Nullable<System.DateTime> vldty_end_dt
        {
            get { return _vldty_end_dt; }
            set { _vldty_end_dt = value; RaisePropertyChanged("vldty_end_dt"); }
        }

        private Nullable<System.DateTime> _vldty_strt_dt;
        public Nullable<System.DateTime> vldty_strt_dt
        {
            get { return _vldty_strt_dt; }
            set { _vldty_strt_dt = value; RaisePropertyChanged("vldty_strt_dt"); }
        }

        private Nullable<bool> _ind_asset_class_lock;
        public Nullable<bool> ind_asset_class_lock
        {
            get { return _ind_asset_class_lock; }
            set { _ind_asset_class_lock = value; RaisePropertyChanged("ind_asset_class_lock"); }
        }


        private Nullable<bool> _ind_dlt;
        public Nullable<bool> ind_dlt
        {
            get { return _ind_dlt; }
            set { _ind_dlt = value; RaisePropertyChanged("ind_dlt"); }
        }

        private string _acc_dtr;
        public string acc_dtr
        {
            get { return _acc_dtr; }
            set { _acc_dtr = value; RaisePropertyChanged("acc_dtr"); }
        }

        private string _low_value_asset_chk;
        public string low_value_asset_chk
        {
            get { return _low_value_asset_chk; }
            set { _low_value_asset_chk = value; RaisePropertyChanged("low_value_asset_chk"); }
        }

        private Nullable<int> _min_life_yrs;
        public Nullable<int> min_life_yrs
        {
            get { return _min_life_yrs; }
            set { _min_life_yrs = value; RaisePropertyChanged("min_life_yrs"); }
        }

        private Nullable<int> _min_life_prd;
        public Nullable<int> min_life_prd
        {
            get { return _min_life_prd; }
            set { _min_life_prd = value; RaisePropertyChanged("min_life_prd"); }
        }

        private Nullable<int> _max_life_yrs;
        public Nullable<int> max_life_yrs
        {
            get { return _max_life_yrs; }
            set { _max_life_yrs = value; RaisePropertyChanged("max_life_yrs"); }
        }

        private Nullable<int> _max_life_prd;
        public Nullable<int> max_life_prd
        {
            get { return _max_life_prd; }
            set { _max_life_prd = value; RaisePropertyChanged("max_life_prd"); }
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

        private Nullable<decimal> _dep_per_rt;
        public Nullable<decimal> dep_per_rt
        {
            get { return _dep_per_rt; }
            set { _dep_per_rt = value; RaisePropertyChanged("dep_per_rt"); }
        }

        private Nullable<decimal> _spl_dep_per_rt;
        public Nullable<decimal> spl_dep_per_rt
        {
            get { return _spl_dep_per_rt; }
            set { _spl_dep_per_rt = value; RaisePropertyChanged("spl_dep_per_rt"); }
        }

        private string _replcmnt_val_indx;
        public string replcmnt_val_indx
        {
            get { return _replcmnt_val_indx; }
            set { _replcmnt_val_indx = value; RaisePropertyChanged("replcmnt_val_indx"); }
        }

        private string _replcmnt_val_indx_age;
        public string replcmnt_val_indx_age
        {
            get { return _replcmnt_val_indx_age; }
            set { _replcmnt_val_indx_age = value; RaisePropertyChanged("replcmnt_val_indx_age"); }
        }

        private string _dep_portion;
        public string dep_portion
        {
            get { return _dep_portion; }
            set { _dep_portion = value; RaisePropertyChanged("dep_portion"); }
        }

        private Nullable<bool> _ind_tot_dep;
        public Nullable<bool> ind_tot_dep
        {
            get { return _ind_tot_dep; }
            set { _ind_tot_dep = value; RaisePropertyChanged("ind_tot_dep"); }
        }

        private Nullable<bool> _ind_da_deactive;
        public Nullable<bool> ind_da_deactive
        {
            get { return _ind_da_deactive; }
            set { _ind_da_deactive = value; RaisePropertyChanged("ind_da_deactive"); }
        }

        private string _group_asset;
        public string group_asset
        {
            get { return _group_asset; }
            set { _group_asset = value; RaisePropertyChanged("group_asset"); }
        }

        private string _reval_key;
        public string reval_key
        {
            get { return _reval_key; }
            set { _reval_key = value; RaisePropertyChanged("reval_key"); }
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

        private string _cod_desc;
        public string cod_desc
        {
            get { return _cod_desc; }
            set { _cod_desc = value; RaisePropertyChanged("cod_desc"); }
        }

        public string XmlDataDocument_ACC_M002_D_FLIP { get; set; }
    }

    public class ACC_M002_D_Flip  //Asset Class And Area Assignment Flip
    {
        public string asset_class { get; set; }
        public int dep_area { get; set; }
        public string dep_key { get; set; }
    }

    public class MultipleContext_ACC_M002_D
    {
        public List<ACC_M002_D_Flip> FlipGridData { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<ACC_M002_D> MasterList { get; set; }
        public List<ACC_M002_C_P> AssetClassList { get; set; }
        public List<ACC_M002_R_P> DepAreaList { get; set; }
        public List<ACC_M002_K_P> DepKeyList { get; set; }
        public List<ACC_M002_J_P> CODList { get; set; }

    }
}
