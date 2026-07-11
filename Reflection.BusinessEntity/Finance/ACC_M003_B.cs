using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_B : ObjectBase
    {
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set {
                if (_active != value)
                {
                    RaisePropertyChanged("active");
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
                    _add_by = value;

                    RaisePropertyChanged("add_by");
                }
            }
        }
        private Nullable<System.DateTime>_add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value;
                    RaisePropertyChanged("add_date");
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
                    _edit_date = value;

                    RaisePropertyChanged("edit_date");
                }
            }
        }
        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                if (_edit_by != value)
                {
                    _edit_by = value;

                    RaisePropertyChanged("edit_by");
                }
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
                    _id = value;
                    RaisePropertyChanged("_id");
                }
            }
        }
        private string _ac_sg_code;
        public string ac_sg_code
        {
            get { return _ac_sg_code; }
            set
            {
                if (_ac_sg_code != value)
                {
                    _ac_sg_code = value;
                    RaisePropertyChanged("_ac_sg_code");
                }
            }
        }

        private string _ac_group_code;
        public string ac_group_code
        {
            get { return _ac_group_code; }
            set
            {
                if (_ac_group_code != value)
                {
                    _ac_group_code = value;
                    RaisePropertyChanged("_ac_group_code");
                }
            }
        }
        private string _ac_sg_name;
        public string ac_sg_name
        {
            get { return _ac_sg_name; }
            set
            {
                if (_ac_sg_name != value)
                {
                    _ac_sg_name = value;
                    RaisePropertyChanged("_ac_sg_name");
                }
            }
        }
        private Nullable<int> _sg_parent_Id;
        public Nullable<int> sg_parent_Id
        {
            get { return _sg_parent_Id; }
            set
            {
                if (_sg_parent_Id != value)
                {
                    _sg_parent_Id = value;
                    RaisePropertyChanged("_sg_parent_Id");
                }
            }
        }
        private string _sg_parent_code;
        public string sg_parent_code
        {
            get { return _sg_parent_code; }
            set
            {
                if (_sg_parent_code != value)
                {
                    _sg_parent_code = value;
                    RaisePropertyChanged("_sg_parent_code");
                }
            }
        }
        private string _s_desc;
        public string s_desc
        {
            get { return _s_desc; }
            set
            {
                if (_s_desc != value)
                {
                    _s_desc = value;
                    RaisePropertyChanged("_s_desc");
                }
            }
        }
        private Nullable<int> _seq_no;
        public Nullable<int> seq_no
        {
            get { return _seq_no; }
            set
            {
                if (_seq_no != value)
                {
                    _seq_no = value;
                    RaisePropertyChanged("_seq_no");
                }
            }
        }
        private string _code_format;
        public string code_format
        {
            get { return _code_format; }
            set
            {
                if (_code_format != value)
                {
                    _code_format = value;
                    RaisePropertyChanged("_code_format");
                }
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
                _Click = value;
                RaisePropertyChanged("Click");
            }
        }

        private string _ac_group_name;
        public string ac_group_name
        {
            get { return _ac_group_name; }
            set
            {
                if (_ac_group_name != value)
                {
                    _ac_group_name = value;
                    RaisePropertyChanged("ac_group_name");
                }
            }
        }




    }
    public class MultipleContext_ACC_M003_B
    {
        public ObservableCollection<ACC_M003_B> ACList { get; set;}
        public List<ACC_M003_B_P> IDList { get; set; }

        public List<ACC_M003_A_P> SGList { get; set; }

    }
}
