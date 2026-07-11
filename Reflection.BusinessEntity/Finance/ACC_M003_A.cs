using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_A : ObjectBase
    {
        private string _ac_group_code;
        public string ac_group_code
        {
            get { return _ac_group_code; }
            set
            {
                if (_ac_group_code != value)
                {
                    _ac_group_code = value;
                    RaisePropertyChanged("ac_group_code");
                }
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
        private string _group_cat;
        public string group_cat
        {
            get { return _group_cat; }
            set
            {
                if (_group_cat != value)
                {
                    _group_cat = value;
                    RaisePropertyChanged("group_cat");
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
                    RaisePropertyChanged("s_desc");
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
                    RaisePropertyChanged("seq_no");
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
                    RaisePropertyChanged("code_format");
                }
            }
        }
        private string _coa_key;
        public string coa_key
        {
            get { return _coa_key; }
            set
            {
                if (_coa_key != value)
                {
                    _coa_key = value;
                    RaisePropertyChanged("coa_key");
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
        private Nullable<System.DateTime> _add_date;
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
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                if (_editby != value)
                {
                    _editby = value;

                    RaisePropertyChanged("editby");
                }
            }
        }
       
        private string _parent_group_code;
        public string parent_group_code
        {
            get { return _parent_group_code; }
            set
            {
                if (_parent_group_code != value)
                {
                    _parent_group_code = value;
                    RaisePropertyChanged("parent_group_code");
                }
            }
        }

        //Scalar
        private string _group_cat_name;
        public string group_cat_name
        {
            get { return _group_cat_name; }
            set
            {
                if (_group_cat_name != value)
                {
                    _group_cat_name = value;
                    RaisePropertyChanged("group_cat_name");
                }
            }
        }
    }
    public class MultipleContext_ACC_M003_A
    {
        public ObservableCollection<ACC_M003_A> AccGrouplist { get; set; }

        public List<ACC_M003_C_P> GrpCategoryList { get; set; }
        public List<ACC_M026_P> COAKeyList { get; set; }

    }
}