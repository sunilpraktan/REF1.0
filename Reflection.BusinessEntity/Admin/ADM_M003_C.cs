using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M003_C : ObjectBase
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

        private string _buss_place;
        public string buss_place
        {
            get { return _buss_place; }
            set
            {
                if (_buss_place != value)
                {
                    _buss_place = value; RaisePropertyChanged("buss_place");
                }
            }
        }

        private string _plc_name;
        public string plc_name
        {
            get { return _plc_name; }
            set
            {
                if (_plc_name != value)
                {
                    _plc_name = value; RaisePropertyChanged("plc_name");
                }
            }
        }

        private string _plc_desc;
        public string plc_desc
        {
            get { return _plc_desc; }
            set
            {
                if (_plc_desc != value)
                {
                    _plc_desc = value; RaisePropertyChanged("plc_desc");
                }
            }
        }

        private string _state_tax_code;
        public string state_tax_code
        {
            get { return _state_tax_code; }
            set
            {
                if (_state_tax_code != value)
                {
                    _state_tax_code = value; RaisePropertyChanged("state_tax_code");
                }
            }
        }

        private string _state_code;
        public string state_code
        {
            get { return _state_code; }
            set
            {
                if (_state_code != value)
                {
                    _state_code = value; RaisePropertyChanged("state_code");
                }
            }
        }

        private string _country_code;
        public string country_code
        {
            get { return _country_code; }
            set
            {
                if (_country_code != value)
                {
                    _country_code = value; RaisePropertyChanged("country_code");
                }
            }
        }

        #region Default Fields
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value; RaisePropertyChanged("active");
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

        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                _edit_by = value; RaisePropertyChanged("edit_by");
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value; RaisePropertyChanged("edit_date");
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

        #endregion

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
    public class MultipleContext_ADM_M003_C
    {
        public ObservableCollection<ADM_M003_C> BPList { get; set; }
        public List<ADM_M012_P> CountryList { get; set; }
        public List<ADM_M013_P> StateList { get; set; }
    }
}
