using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M001_P : ObjectBase
    {
        private string _pg_code;
        public string pg_code
        {
            get { return _pg_code; }
            set
            {
                if (_pg_code != value)
                { _pg_code = value; RaisePropertyChanged("pg_code"); }
            }
        }

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

        private string _pg_name;
        public string pg_name
        {
            get { return _pg_name; }
            set
            {
                if (_pg_name != value)
                {
                    _pg_name = value; RaisePropertyChanged("pg_name");
                }
            }
        }

        private string _pg_desc;
        public string pg_desc
        {
            get { return _pg_desc; }
            set {
                if (_pg_desc != value)
                {
                    _pg_desc = value; RaisePropertyChanged("pg_desc");
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

        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set
            {
                if (_po_code != value)
                {
                    _po_code = value; RaisePropertyChanged("po_code");
                }
            }
        }

        //Scalar
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
    public class MultipleContext_ADM_M001_P
    {
        public ObservableCollection<ADM_M001_P> PGList { get; set; }
        public List<ADM_M001_M_P> POList { get; set; }

    }
}
