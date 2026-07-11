using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Reflection.BusinessEntity.HRMS
{
    public class HRM_M015 : ObjectBase
    {
        private string _ter_id;
        public string ter_id
        {
            get { return _ter_id; }
            set
            {
                if (_ter_id != value)
                {
                    _ter_id = value; RaisePropertyChanged("ter_id");
                }
            }
        }
        private string _ter_desc;
        public string ter_desc
        {
            get { return _ter_desc; }
            set
            {
                if (_ter_desc != value)
                {
                    _ter_desc = value; RaisePropertyChanged("ter_desc");
                }
            }
        }
        private string _ter_shrt_nm;
        public string ter_shrt_nm
        {
            get { return _ter_shrt_nm; }
            set
            {
                if (_ter_shrt_nm != value)
                {
                    _ter_shrt_nm = value; RaisePropertyChanged("ter_shrt_nm");
                }
            }
        }
        private string _ter_location;
        public string ter_location
        {
            get { return _ter_location; }
            set
            {
                if (_ter_location != value)
                {
                    _ter_location = value; RaisePropertyChanged("ter_location");
                }
            }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                if (_t_status != value)
                {
                    _t_status = value; RaisePropertyChanged("t_status");
                }
            }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");
                }
            }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                if (_editby != value)
                {
                    _editby = value; RaisePropertyChanged("editby");
                }
            }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");
                }
            }
        }
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value; RaisePropertyChanged("lang_key");
                }
            }
        }
        
        private string _remark;
        public string remark
        {
            get { return _remark; }
            set
            {
                if (_remark != value)
                {
                    _remark = value;
                    RaisePropertyChanged("remark");
                }
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
                }
            }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }
     
        //Scaller

        private string _t_name;
        public string t_name
        {
            get { return _t_name; }
            set
            {
                if (_t_name != value)
                {
                    _t_name = value; RaisePropertyChanged("t_name");
                }
            }
        }
        public string XmlDataDocument_HRM_M015_A { get; set; }
        public string XmlDataDocument_HRM_M015_Flip { get; set; }

        
    }
    public class HRM_M015_A : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
        private string _ter_id;
        public string ter_id
        {
            get { return _ter_id; }
            set
            {
                if (_ter_id != value)
                {
                    _ter_id = value; RaisePropertyChanged("ter_id");
                }
            }
        }
        private string _equ_id;
        public string equ_id
        {
            get { return _equ_id; }
            set
            {
                if (_equ_id != value)
                {
                    _equ_id = value; RaisePropertyChanged("equ_id");
                }
            }
        }
        private string _ind_inout;
        public string ind_inout
        {
            get { return _ind_inout; }
            set
            {
                if (_ind_inout != value)
                {
                    _ind_inout = value; RaisePropertyChanged("ind_inout");
                }
            }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                if (_t_status != value)
                {
                    _t_status = value; RaisePropertyChanged("t_status");
                }
            }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");
                }
            }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                if (_editby != value)
                {
                    _editby = value; RaisePropertyChanged("editby");
                }
            }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");
                }
            }
        }
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value; RaisePropertyChanged("lang_key");
                }
            }
        }
        
        private string _remark;
        public string remark
        {
            get { return _remark; }
            set
            {
                if (_remark != value)
                {
                    _remark = value;
                    RaisePropertyChanged("remark");
                }
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
                }
            }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }
       
        //Scaller

        private string _t_name;
        public string t_name
        {
            get { return _t_name; }
            set
            {
                if (_t_name != value)
                {
                    _t_name = value; RaisePropertyChanged("t_name");
                }
            }
        }
    }



    public class MultipleContext_HRM_M015
    {
        public List<HRM_M015_BackFlip> BackFlipEntity { get; set; }
        public List<HRM_M015> MasterData { get; set; }
        public ObservableCollection<HRM_M015_A> DetailData { get; set; }
        public List<ADM.ADM_M0013> StatusList { get; set; }
    }
    public class HRM_M015_BackFlip
    {
        public string ter_id { get; set; }
        public string ter_desc { get; set; }
        public string ter_shrt_nm { get; set; }
        public string ter_location { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string t_name { get; set; }
    }
}
