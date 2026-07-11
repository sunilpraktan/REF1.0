using System;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_K : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                { _id = value; RaisePropertyChanged("id"); }
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
        private string _acc_cat;
        public string acc_cat
        {
            get { return _acc_cat; }
            set
            {
                if (_acc_cat != value)
                { _acc_cat = value; RaisePropertyChanged("acc_cat"); }
            }
        }
        private string _short_name;
        public string short_name
        {
            get { return _short_name; }
            set
            {
                if (_short_name != value)
                { _short_name = value; RaisePropertyChanged("short_name"); }
            }
        }
        private string _cat_desc;
        public string cat_desc
        {
            get { return _cat_desc; }
            set
            {
                if (_cat_desc != value)
                { _cat_desc = value; RaisePropertyChanged("cat_desc"); }
            }
        }


        //scalar
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
        public class MultipleContext_ACC_M003_K
    {
        public ObservableCollection<ACC_M003_K> CATList { get; set; }
       

    }
}
