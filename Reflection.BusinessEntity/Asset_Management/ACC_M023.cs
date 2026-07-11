using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Asset_Management
{
    public class ACC_M023 : ObjectBase
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

        private string _dep_type;
        public string dep_type
        {
            get { return _dep_type; }
            set { _dep_type = value; RaisePropertyChanged("dep_type"); }
        }

        private string _dep_phase;
        public string dep_phase
        {
            get { return _dep_phase; }
            set { _dep_phase = value; RaisePropertyChanged("dep_phase"); }
        }

        private string _base_mthd;
        public string base_mthd
        {
            get { return _base_mthd; }
            set { _base_mthd = value; RaisePropertyChanged("base_mthd"); }
        }

        private string _dbm;
        public string dbm
        {
            get { return _dbm; }
            set { _dbm = value; RaisePropertyChanged("dbm"); }
        }

        private string _pcm;    
        public string pcm
        {
            get { return _pcm; }
            set { _pcm = value; RaisePropertyChanged("pcm"); }
        }

        private string _mm;
        public string mm
        {
            get { return _mm; }
            set { _mm = value; RaisePropertyChanged("mm"); }
        }

        private string _mam;
        public string mam
        {
            get { return _mam; }
            set { _mam = value; RaisePropertyChanged("mam"); }
        }

        private string _com;
        public string com
        {
            get { return _com; }
            set { _com = value; RaisePropertyChanged("com"); }
        }

        private Nullable<decimal> _nbv_dep_per;
        public Nullable<decimal> nbv_dep_per
        {
            get { return _nbv_dep_per; }
            set { _nbv_dep_per = value; RaisePropertyChanged("nbv_dep_per"); }
        }

        private string _mult_shft_efct;
        public string mult_shft_efct
        {
            get { return _mult_shft_efct; }
            set { _mult_shft_efct = value; RaisePropertyChanged("mult_shft_efct"); }
        }

        private string _scrp_val_efct;
        public string scrp_val_efct
        {
            get { return _scrp_val_efct; }
            set { _scrp_val_efct = value; RaisePropertyChanged("scrp_val_efct"); }
        }

        private string _cal_shtdwn; 
        public string cal_shtdwn
        {
            get { return _cal_shtdwn; }
            set { _cal_shtdwn = value; RaisePropertyChanged("cal_shtdwn"); }
        }

        private string _od_clsfctn;
        public string od_clsfctn
        {
            get { return _od_clsfctn; }
            set { _od_clsfctn = value; RaisePropertyChanged("od_clsfctn"); }
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

        private string _dep_asgn_no;
        public string dep_asgn_no
        {
            get { return _dep_asgn_no; }
            set { _dep_asgn_no = value; RaisePropertyChanged("dep_asgn_no"); }
        }
       
        //Scalar 

        public string XmlDataDocument_FlipGrid { get; set; }

        private string _base_mthd_desc;
        public string base_mthd_desc
        {
            get { return _base_mthd_desc; }
            set { _base_mthd_desc = value; RaisePropertyChanged("base_mthd_desc"); }
        }

        private string _dbm_desc;
        public string dbm_desc
        {
            get { return _dbm_desc; }
            set { _dbm_desc = value; RaisePropertyChanged("dbm_desc"); }
        }

        private string _pcm_desc;
        public string pcm_desc
        {
            get { return _pcm_desc; }
            set { _pcm_desc = value; RaisePropertyChanged("pcm_desc"); }
        }

        private string _mm_desc;
        public string mm_desc
        {
            get { return _mm_desc; }
            set { _mm_desc = value; RaisePropertyChanged("mm_desc"); }
        }

        private string _mam_desc;
        public string mam_desc
        {
            get { return _mam_desc; }
            set { _mam_desc = value; RaisePropertyChanged("mam_desc"); }
        }
        private string _cod_desc;
        public string cod_desc
        {
            get { return _cod_desc; }
            set { _cod_desc = value; RaisePropertyChanged("cod_desc"); }
        }
        private string _dep_key_desc;
        public string dep_key_desc
        {
            get { return _dep_key_desc; }
            set { _dep_key_desc = value; RaisePropertyChanged("dep_key_desc"); }
        }
    }
    public class ACC_M023_Flip
    {
        public string dep_key { get; set; }
        public string dep_type { get; set; }
        public string dep_phase { get; set; }
        public string base_mthd { get; set; }
        public string dbm { get; set; }
        public string pcm { get; set; }
        public string mm { get; set; }
        public string mam { get; set; }
        public string com { get; set; }
    }
    public class MultipleContext_ACC_M023
    {
        public List<ACC_M023_Flip> FlipGridData { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<ACC_M023> MasterList { get; set; }
        public List<ACC_M023_A_P> BaseMethodList { get; set; }
        public List<ACC_M023_B_P> DecliningBalList { get; set; }
        public List<ACC_M023_C_P> PeriodControlList { get; set; }
        public List<ACC_M023_D_P> MultilevelList { get; set; }
        public List<ACC_M002_J_P> CODList { get; set; }
        public List<ACC_M002_K_P> DepKeyList { get; set; }
    }
}
