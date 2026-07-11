using System;
using System.Collections.Generic;


namespace Reflection.BusinessEntity.Asset_Management
{
    public class ACC_M002_R : ObjectBase
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

        private Nullable<bool> _ind_store_rda;
        public Nullable<bool> ind_store_rda
        {
            get { return _ind_store_rda; }
            set { _ind_store_rda = value; RaisePropertyChanged("ind_store_rda"); }
        }

        private Nullable<bool> _real_da;
        public Nullable<bool> real_da
        {
            get { return _real_da; }
            set { _real_da = value; RaisePropertyChanged("real_da"); }
        }

        private Nullable<int> _pro_of_real_da;
        public Nullable<int> pro_of_real_da
        {
            get { return _pro_of_real_da; }
            set { _pro_of_real_da = value; RaisePropertyChanged("pro_of_real_da"); }
        }

        private string _gl_acc_posting;
        public string gl_acc_posting
        {
            get { return _gl_acc_posting; }
            set { _gl_acc_posting = value; RaisePropertyChanged("gl_acc_posting"); }
        }

        private Nullable<bool> _ind_da_ok;
        public Nullable<bool> ind_da_ok
        {
            get { return _ind_da_ok; }
            set { _ind_da_ok = value; RaisePropertyChanged("_ind_da_ok"); }

        }

        private Nullable<bool> _aa_da_fr_rpt;
        public Nullable<bool> aa_da_fr_rpt
        {
            get { return _aa_da_fr_rpt; }
            set { _aa_da_fr_rpt = value; RaisePropertyChanged("aa_da_fr_rpt"); }
        }

        private Nullable<int> _da_used;
        public Nullable<int> da_used
        {
            get { return _da_used; }
            set { _da_used = value; RaisePropertyChanged("da_used"); }
        }

        private string _cross_sys_da;
        public string cross_sys_da
        {
            get { return _cross_sys_da; }
            set { _cross_sys_da = value; RaisePropertyChanged("cross_sys_da"); }
        }

        private string _trgt_ldgr_grp;
        public string trgt_ldgr_grp
        {
            get { return _trgt_ldgr_grp; }
            set { _trgt_ldgr_grp = value; RaisePropertyChanged("trgt_ldgr_grp"); }
        }

        private Nullable<bool> _treat_dda_as_ra;
        public Nullable<bool> treat_dda_as_ra
        {
            get { return _treat_dda_as_ra; }
            set { _treat_dda_as_ra = value; RaisePropertyChanged("treat_dda_as_ra"); }
        }

        private Nullable<int> _acc_dtr_da;
        public Nullable<int> acc_dtr_da
        {
            get { return _acc_dtr_da; }
            set { _acc_dtr_da = value; RaisePropertyChanged("acc_dtr_da"); }
        }

        private string _da_purpose;
        public string da_purpose
        {
            get { return _da_purpose; }
            set { _da_purpose = value; RaisePropertyChanged("da_purpose"); }
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
        
        private string _dep_area_desc;
        public string dep_area_desc
        {
            get { return _dep_area_desc; }
            set { _dep_area_desc = value; RaisePropertyChanged("dep_area_desc"); }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }

        private string _gl_code;
        public string gl_code
        {
            get { return _gl_code; }
            set { _gl_code = value; RaisePropertyChanged("gl_code"); }
        }

        //Scalar 
        public string XmlDataDocument_FlipGrid { get; set; }

        private string _cod_desc;
        public string cod_desc
        {
            get { return _cod_desc; }
            set { _cod_desc = value; RaisePropertyChanged("cod_desc"); }
        }

        private string _gl_desc;
        public string gl_desc
        {
            get { return _gl_desc; }
            set { _gl_desc = value; RaisePropertyChanged("gl_desc"); }
        }

    }
    public class ACC_M002_R_Flip  //Asset Area Master Flip
    {
        public string cod { get; set; }
        public int dep_area { get; set; }
        public string dep_area_desc { get; set; }
    }
    public class MultipleContext_ACC_M002_R
    {
        public List<ACC_M002_R_Flip> FlipGridData { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<ACC_M002_R> MasterList { get; set; }
        public List<ACC_M003_P> GL_CodeList { get; set; }
        public List<ACC_M002_J_P> CODList { get; set; }

    }
}
