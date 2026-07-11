using System;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M030_J : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value; RaisePropertyChanged("id");
            }
        }
        

        private string _catlog_code;
        public string catlog_code
        {
            get { return _catlog_code; }
            set
            {
                _catlog_code = value;
                RaisePropertyChanged("catlog_code");
            }
        }

        private string _qm_para_group;
        public string qm_para_group
        {
            get { return _qm_para_group; }
            set
            {
                _qm_para_group = value;
                RaisePropertyChanged("qm_para_group");
            }
        }

        private string _record_use;
        public string record_use
        {
            get { return _record_use; }
            set
            {
                _record_use = value;
                RaisePropertyChanged("record_use");
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }

        
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                _lang_key = value;
                RaisePropertyChanged("lang_key");
            }
        }

        private Nullable<System.DateTime> _valid_from;
        public Nullable<System.DateTime> valid_from
        {
            get { return _valid_from; }
            set
            {
                _valid_from = value;
                RaisePropertyChanged("valid_from");
            }
        }

        private string _desc;
        public string desc
        {
            get { return _desc; }
            set
            {
                _desc = value;
                RaisePropertyChanged("desc");
            }
        }

        public string XmlDataDocument_FlipGrid { get; set; }

        //Scalar
        private string _CatlogName { get; set; }
        public string CatlogName
        {
            get { return _CatlogName; }
            set
            {
                _CatlogName = value;
                RaisePropertyChanged("CatlogName");
            }
        }
    }

    
}
