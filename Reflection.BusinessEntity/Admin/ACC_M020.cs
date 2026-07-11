using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ACC_M020 : ObjectBase
    {
        private string _profit_center;
        public string profit_center
        {
            get { return _profit_center; }
            set
            {
                if (_profit_center != value)
                {
                    _profit_center = value; RaisePropertyChanged("profit_center");
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
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
        private string _profit_center_Desc;
        public string profit_center_Desc
        {
            get { return _profit_center_Desc; }
            set
            {
                if (_profit_center_Desc != value)
                {
                    _profit_center_Desc = value; RaisePropertyChanged("profit_center_Desc");
                }
            }
        }
        private string _pc_dept_code;
        public string pc_dept_code
        {
            get { return _pc_dept_code; }
            set
            {
                if (_pc_dept_code != value)
                {
                    _pc_dept_code = value; RaisePropertyChanged("pc_dept_code");
                }
            }
        }
        private int _pc_category;
        public int pc_category
        {
            get { return _pc_category; }
            set
            {
                if (_pc_category != value)
                {
                    _pc_category = value; RaisePropertyChanged("pc_category");
                }
            }
        }
        private Nullable<System.DateTime> _valid_from;
        public Nullable<System.DateTime> valid_from
        {
            get { return _valid_from; }
            set
            {
                if (_valid_from != value)
                {
                    _valid_from = value; RaisePropertyChanged("valid_from");
                }
            }
        }
        private Nullable<System.DateTime> _valid_to;
        public Nullable<System.DateTime> valid_to
        {
            get { return _valid_to; }
            set
            {
                if (_valid_to != value)
                {
                    _valid_to = value; RaisePropertyChanged("valid_to");
                }
            }
        }
        private string _pc_curr_code;
        public string pc_curr_code
        {
            get { return _pc_curr_code; }
            set
            {
                if (_pc_curr_code != value)
                {
                    _pc_curr_code = value; RaisePropertyChanged("pc_curr_code");
                }
            }
        }
        private int _pc_group;
        public int pc_group
        {
            get { return _pc_group; }
            set
            {
                if (_pc_group != value)
                {
                    _pc_group = value; RaisePropertyChanged("pc_group");
                }
            }
        }
        private int _pc_mgr;
        public int pc_mgr
        {
            get { return _pc_mgr; }
            set
            {
                if (_pc_mgr != value)
                {
                    _pc_mgr = value; RaisePropertyChanged("pc_mgr");
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
        private string _address;
        public string address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value; RaisePropertyChanged("address");
                }
            }
        }
        private string _city;
        public string city
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value; RaisePropertyChanged("city");
                }
            }
        }
        private string _district;
        public string district
        {
            get { return _district; }
            set
            {
                if (_district != value)
                {
                    _district = value; RaisePropertyChanged("district");
                }
            }
        }
        private string _pin;
        public string pin
        {
            get { return _pin; }
            set
            {
                if (_pin != value)
                {
                    _pin = value; RaisePropertyChanged("pin");
                }
            }
        }
        private string _region;
        public string region
        {
            get { return _region; }
            set
            {
                if (_region != value)
                {
                    _region = value; RaisePropertyChanged("region");
                }
            }
        }
        private string _phone_no;
        public string phone_no
        {
            get { return _phone_no; }
            set
            {
                if (_phone_no != value)
                {
                    _phone_no = value; RaisePropertyChanged("phone_no");
                }
            }
        }
        private string _fax_no;
        public string fax_no
        {
            get { return _fax_no; }
            set
            {
                if (_fax_no != value)
                {
                    _fax_no = value; RaisePropertyChanged("fax_no");
                }
            }
        }
        private string _cell_no;
        public string cell_no
        {
            get { return _cell_no; }
            set
            {
                if (_cell_no != value)
                {
                    _cell_no = value; RaisePropertyChanged("cell_no");
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

        //Scaler
        private string _dept_code;
        public string dept_code
        {
            get { return _dept_code; }
            set
            {
                if (_dept_code != value)
                {
                    _dept_code = value; RaisePropertyChanged("dept_code");
                }
            }
        }
        private string _DeptName;
        public string DeptName
        {
            get { return _DeptName; }
            set
            {
                if (_DeptName != value)
                {
                    _DeptName = value; RaisePropertyChanged("DeptName");
                }
            }
        }
        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                if (_curr_code != value)
                {
                    _curr_code = value; RaisePropertyChanged("curr_code");
                }
            }
        }
        private string _curr_name;
        public string curr_name
        {
            get { return _curr_name; }
            set
            {
                if (_curr_name != value)
                {
                    _curr_name = value; RaisePropertyChanged("curr_name");
                }
            }
        }
    }
    public class MultipleContext_ACC_M020
    {
        public ObservableCollection<ACC_M020> ProfitList { get; set; }
        public List<ADM_M025_P> DepartmentList { get; set; }
        public List<ADM_M037_P> CurrencyList { get; set; }
    }
}
