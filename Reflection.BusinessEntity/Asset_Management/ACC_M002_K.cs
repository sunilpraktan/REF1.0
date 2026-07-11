using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Asset_Management
{
    public class ACC_M002_K : ObjectBase
    {
        
        private string _dep_key;
        public string dep_key
        {
            get { return _dep_key; }
            set { _dep_key = value; RaisePropertyChanged("dep_key"); }
        }

        private string _cod;
        public string cod
        {
            get { return _cod; }
            set { _cod = value; RaisePropertyChanged("cod"); }
        }

        private string _dk_status;
        public string dk_status
        {
            get { return _dk_status; }
            set { _dk_status = value; RaisePropertyChanged("dk_status"); }
        }

        private string _mam;
        public string mam
        {
            get { return _mam; }
            set { _mam = value; RaisePropertyChanged("mam"); }
        }

        private string _cutoff_val_key;
        public string cutoff_val_key
        {
            get { return _cutoff_val_key; }
            set { _cutoff_val_key = value; RaisePropertyChanged("cutoff_val_key"); }
        }

        private string _ord_dep;
        public string ord_dep
        {
            get { return _ord_dep; }
            set { _ord_dep = value; RaisePropertyChanged("ord_dep"); }
        }

        private string _interest;
        public string interest
        {
            get { return _interest; }
            set { _interest = value; RaisePropertyChanged("interest"); }
        }

        private string _same_acq_yr;
        public string same_acq_yr
        {
            get { return _same_acq_yr; }
            set { _same_acq_yr = value; RaisePropertyChanged("same_acq_yr"); }
        }

        private string _pc_fin_yr;
        public string pc_fin_yr
        {
            get { return _pc_fin_yr; }
            set { _pc_fin_yr = value; RaisePropertyChanged("pc_fin_yr"); }
        }

        private Nullable<int> _tot_places;
        public Nullable<int> tot_places
        {
            get { return _tot_places; }
            set { _tot_places = value; RaisePropertyChanged("tot_places"); }
        }

        private string _dep_cal_day;
        public string dep_cal_day
        {
            get { return _dep_cal_day; }
            set { _dep_cal_day = value; RaisePropertyChanged("dep_cal_day"); }
        }

        private string _ind_reduce_dep;
        public string ind_reduce_dep
        {
            get { return _ind_reduce_dep; }
            set { _ind_reduce_dep = value; RaisePropertyChanged("ind_reduce_dep"); }
        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }

        private string _dep_key_desc;
        public string dep_key_desc
        {
            get { return _dep_key_desc; }
            set { _dep_key_desc = value; RaisePropertyChanged("dep_key_desc"); }
        }

        //Scalar 
        public string XmlDataDocument_FlipGrid { get; set; }

        private string _cod_desc;
        public string cod_desc
        {
            get { return _cod_desc; }
            set { _cod_desc = value; RaisePropertyChanged("cod_desc"); }
        }

    }
    public class ACC_M002_K_Flip  //Depreciation Key Master Flip
    {
        public string dep_key { get; set; }
        public string dk_status { get; set; }
        public string dep_key_desc { get; set; }
    }
    public class MultipleContext_ACC_M002_K
    {
        public List<ACC_M002_K_Flip> FlipGridData { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<ACC_M002_K> MasterList { get; set; }
        public List<ACC_M023_E_P> MaxAmountMethodList { get; set; }
        public List<ACC_M023_H_P> CutOffValList { get; set; }
        public List<ACC_M002_J_P> CODList { get; set; }
    }
}
