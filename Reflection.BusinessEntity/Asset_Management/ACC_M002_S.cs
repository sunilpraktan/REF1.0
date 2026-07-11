using System;


namespace Reflection.BusinessEntity.Asset_Management
{
    public class ACC_M002_S : ObjectBase
    {
      
        private string _cod;
        public string cod
        {
            get { return _cod; }
            set { _cod = value; RaisePropertyChanged("cod"); }
        }
        private int _dep_area;
        public int dep_area
        {
            get { return _dep_area; }
            set { _dep_area = value; RaisePropertyChanged("dep_area"); }
        }
        private int _dep_area_val;
        public int dep_area_val
        {
            get { return _dep_area_val; }
            set { _dep_area_val = value; RaisePropertyChanged("dep_area_val"); }
        }
        private Nullable<int> _trnsfr_dep_da;
        public Nullable<int> trnsfr_dep_da
        {
            get { return _trnsfr_dep_da; }
            set { _trnsfr_dep_da = value; RaisePropertyChanged("trnsfr_dep_da"); }
        }
        private bool _ind_cal_rpl_val;
        public bool ind_cal_rpl_val
        {
            get { return _ind_cal_rpl_val; }
            set { _ind_cal_rpl_val = value; RaisePropertyChanged("ind_cal_rpl_val"); }
        }
        private bool _idntcl_trnsfr_val;
        public bool idntcl_trnsfr_val
        {
            get { return _idntcl_trnsfr_val; }
            set { _idntcl_trnsfr_val = value; RaisePropertyChanged("idntcl_trnsfr_val"); }
        }
        private string _idntcl_dt_copied;
        public string idntcl_dt_copied
        {
            get { return _idntcl_dt_copied; }
            set { _idntcl_dt_copied = value; RaisePropertyChanged("idntcl_dt_copied"); }
        }
        private string _dep_cal_seq;
        public string dep_cal_seq
        {
            get { return _dep_cal_seq; }
            set { _dep_cal_seq = value; RaisePropertyChanged("dep_cal_seq"); }
        }
        private bool _ind_mng_acq_yr;
        public bool ind_mng_acq_yr
        {
            get { return _ind_mng_acq_yr; }
            set { _ind_mng_acq_yr = value; RaisePropertyChanged("ind_mng_acq_yr"); }
        }
        private bool _ind_mng_curr;
        public bool ind_mng_curr
        {
            get { return _ind_mng_curr; }
            set { _ind_mng_curr = value; RaisePropertyChanged("ind_mng_curr"); }
        }
        private bool _ind_dpnt_da_exists;
        public bool ind_dpnt_da_exists
        {
            get { return _ind_dpnt_da_exists; }
            set { _ind_dpnt_da_exists = value; RaisePropertyChanged("ind_dpnt_da_exists"); }
        }
        private bool _ind_trnsfr_hist_val;
        public bool ind_trnsfr_hist_val
        {
            get { return _ind_trnsfr_hist_val; }
            set { _ind_trnsfr_hist_val = value; RaisePropertyChanged("ind_trnsfr_hist_val"); }
        }
        private string _consolidtn_vrsn;
        public string consolidtn_vrsn
        {
            get { return _consolidtn_vrsn; }
            set { _consolidtn_vrsn = value; RaisePropertyChanged("consolidtn_vrsn"); }
        }
        private string _sub_grp;
        public string sub_grp
        {
            get { return _sub_grp; }
            set { _sub_grp = value; RaisePropertyChanged("sub_grp"); }
        }
        private Nullable<int> _loc_curr_no;
        public Nullable<int> loc_curr_no
        {
            get { return _loc_curr_no; }
            set { _loc_curr_no = value; RaisePropertyChanged("loc_curr_no"); }
        }
        private string _curr_type;
        public string curr_type
        {
            get { return _curr_type; }
            set { _curr_type = value; RaisePropertyChanged("curr_type"); }
        }
        private string _stndztn_da;
        public string stndztn_da
        {
            get { return _stndztn_da; }
            set { _stndztn_da = value; RaisePropertyChanged("stndztn_da"); }
        }
        private string _cap_vrsn;
        public string cap_vrsn
        {
            get { return _cap_vrsn; }
            set { _cap_vrsn = value; RaisePropertyChanged("cap_vrsn"); }
        }
        private bool _qty_updt_rlvnt;
        public bool qty_updt_rlvnt
        {
            get { return _qty_updt_rlvnt; }
            set { _qty_updt_rlvnt = value; RaisePropertyChanged("qty_updt_rlvnt"); }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
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
        
    }
}
