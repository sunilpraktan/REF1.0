using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M001_A : ObjectBase
    {
        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set {
                if (_so_code != value)
                { _so_code = value; RaisePropertyChanged("so_code"); }
            }
        }

        private int _id;
        public int id
        {
            get { return _id; }
            set {
                if (_id != value)
                { _id = value; RaisePropertyChanged("id"); }
            }
        }

        private string _sales_org;
        public string sales_org
        {
            get { return _sales_org; }
            set
            {
                if (_sales_org != value)
                {
                    _sales_org = value; RaisePropertyChanged("sales_org");
                }
            }
        }

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set {
                if (_curr_code != value)
                {
                    _curr_code = value; RaisePropertyChanged("curr_code");
                }
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set {
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

        private string _lang;
        public string lang
        {
            get { return _lang; }
            set
            {
                if (_lang != value)
                {
                    _lang = value; RaisePropertyChanged("lang");
                }
            }
        }

        private string _phone;
        public string phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value; RaisePropertyChanged("phone");
                }
            }
        }

        private string _ph_ext;
        public string ph_ext
        {
            get { return _ph_ext; }
            set
            {
                if (_ph_ext != value)
                {
                    _ph_ext = value; RaisePropertyChanged("ph_ext");
                }

            }
        }

        private string _fax;
        public string fax
        {
            get { return _fax; }
            set
            {
                if (_fax != value)
                {
                    _fax = value; RaisePropertyChanged("fax");
                }
            }
        }

        private string _fax_ext;
        public string fax_ext
        {
            get { return _fax_ext; }
            set
            {
                if (_fax_ext != value)
                {
                    _fax_ext = value; RaisePropertyChanged("fax_ext");
                }
            }
        }

        private string _email;
        public string email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value; RaisePropertyChanged("email");
                }
            }
        }

        private string _notes;
        public string notes
        {
            get { return _notes; }
            set
            {
                if (_notes != value)
                {
                    _notes = value; RaisePropertyChanged("notes");
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

        private string _pg_code;
        public string pg_code
        {
            get { return _pg_code; }
            set
            {
                if (_pg_code != value)
                {
                    _pg_code = value; RaisePropertyChanged("pg_code");
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
            set {
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
    public class MultipleContext_ADM_M001_A
    {
        public ObservableCollection<ADM_M001_A> SOList { get; set; }
        public List<ADM_M012_P> CountryList { get; set; }
        public List<ADM_M013_P> StateList { get; set; }        
    }
}
