using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Reflection.BusinessEntity.Admin
{
    public  class ACC_M019 : ObjectBase
    {
        private string _cost_center;
        public string cost_center
        {
            get { return _cost_center; }
            set
            {
                if (_cost_center != value)
                {
                    _cost_center = value; RaisePropertyChanged("cost_center");
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
        private string _cost_center_Desc;
        public string cost_center_Desc
        {
            get { return _cost_center_Desc; }
            set
            {
                if (_cost_center_Desc != value)
                {
                    _cost_center_Desc = value; RaisePropertyChanged("cost_center_Desc");
                }

            }
        }
        private int _cc_mgr;
        public int cc_mgr
        {
            get { return _cc_mgr; }
            set
            {
                if (_cc_mgr != value)
                {
                    _cc_mgr = value; RaisePropertyChanged("cc_mgr");
                }

            }
        }
        private string _cc_dept_code;
        public string cc_dept_code
        {
            get { return _cc_dept_code; }
            set
            {
                if (_cc_dept_code != value)
                {
                    _cc_dept_code = value; RaisePropertyChanged("cc_dept_code");
                }

            }
        }
        private int _cc_category;
        public int cc_category
        {
            get { return _cc_category; }
            set
            {
                if (_cc_category != value)
                {
                    _cc_category = value; RaisePropertyChanged("cc_category");
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
        private string _cc_curr_code;
        public string cc_curr_code
        {
            get { return _cc_curr_code; }
            set
            {
                if (_cc_curr_code != value)
                {
                    _cc_curr_code = value; RaisePropertyChanged("cc_curr_code");
                }

            }
        }
        private string _cc_profit_center;
        public string cc_profit_center
        {
            get { return _cc_profit_center; }
            set
            {
                if (_cc_profit_center != value)
                {
                    _cc_profit_center = value; RaisePropertyChanged("cc_profit_center");
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
        //scalar
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
        private string _dept_code;
        public string dept_code
        {
            get { return _dept_code; }
            set
            {
                if (_dept_code != value)
                {
                    _dept_code = value; RaisePropertyChanged("DeptName");
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











    }
    public class MultipleContext_ACC_M019
    {
        public ObservableCollection<ACC_M019> CostList { get; set; }
        public List<ADM_M025_P> DepartmentList { get; set; }
        public List<ADM_M037_P> CurrencyList { get; set; }
        public List<ACC_M020_P> ProfitList { get; set; }
    }
}
