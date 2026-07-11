using System;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_H :ObjectBase  //Account Group Master
    {   

        private string _acc_group;
        public string acc_group
        {
            get { return _acc_group; }
            set {
                if (_acc_group != value)
                {
                    _acc_group = value; RaisePropertyChanged("acc_group");
                } }
        }

        private string _group_desc;
        public string group_desc
        {
            get { return _group_desc; }
            set {
                if (_group_desc != value)
                {
                    _group_desc = value; RaisePropertyChanged("group_desc");
                }
            }
        }

        

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if(_comp_code!=value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }
        private string _acc_group_type;
        public string acc_group_type
        {
            get { return _acc_group_type; }
            set
            {
                if (_acc_group_type != value)
                {
                    _acc_group_type = value; RaisePropertyChanged("acc_group_type");
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

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value; RaisePropertyChanged("client");
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
        
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                { _location_Id = value; RaisePropertyChanged("location_Id"); }
            }
        }
        private bool _Click;
        public bool Click
        {
            get
            {
                return _Click;
            }
            set
            {
                if (_Click != value)
                {
                    _Click = value;
                    RaisePropertyChanged("Click");
                }
            }
        }
    }
    public class MultipleContext_ACC_M003_H
    {
        public ObservableCollection<ACC_M003_H> AccountGroupList { get; set; }
    }

}
