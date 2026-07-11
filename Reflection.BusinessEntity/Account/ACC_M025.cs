using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Reflection.BusinessEntity.Account
{
    public class ACC_M025 : ObjectBase
    {
        private bool _active;
        public bool active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value;

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
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value;

                    RaisePropertyChanged("_location_Id");
                }
            }
        }
        private DateTime _add_date;
        public DateTime add_date
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
     
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value;
                    RaisePropertyChanged("comp_code");
                }
            }
        }
        private string _wtax_code;

        public string wtax_code
        {
            get { return _wtax_code; }
            set
            {
                if (_wtax_code != value)
                {
                    _wtax_code = value;
                    RaisePropertyChanged("wtax_code");
                }
            }

        }

        private string _wtax_ncode;

        public string wtax_ncode
        {
            get { return _wtax_ncode; }
            set
            {
                if (_wtax_ncode != value)
                {
                    _wtax_ncode = value;
                    RaisePropertyChanged("_wtax_ncode");
                }
            }
         }

        private string _wtax_key;
         
        public string wtax_key
        {
            get { return _wtax_key; }
            set
            {
                if (_wtax_key != value)
                {
                    _wtax_key = value;
                    RaisePropertyChanged("_wtax_key");
                }
            }

        }
        private string _ind_wtax_type;

        public string ind_wtax_type
        {
            get { return _ind_wtax_type; }
            set
            {
                if (_ind_wtax_type != value)
                {
                    _ind_wtax_type = value;
                    RaisePropertyChanged("_ind_wtax_type");
                }
            }

        }

        private decimal _wtax_per;

        public decimal wtax_per
        {
            get { return _wtax_per; }
            set
            {
                if (_wtax_per != value)
                {
                    _wtax_per = value;
                    RaisePropertyChanged("_wtax_per");
                }
            }


        }
        private decimal _wtax_rate;

        public decimal wtax_rate
        {
            get { return _wtax_rate; }
            set
            {
                if (_wtax_rate != value)
                {
                    _wtax_rate = value;
                    RaisePropertyChanged("_wtax_rate");
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
                    _country_code = value;
                    RaisePropertyChanged("_country_code");
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
                    _lang_key = value;
                    RaisePropertyChanged("_lang_key");
                }
            }

        }
        
        //scalar
        private string _CntryName;

        public string  CntryName
        {
            get { return _CntryName; }
            set
            {
                if (_CntryName != value)
                {
                    _CntryName = value;
                    RaisePropertyChanged("_CntryName");
                }
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
        private string _wtax_type;

        public string wtax_type
        {
            get { return _wtax_type; }
            set
            {
                if (_wtax_type != value)
                {
                    _wtax_type = value;
                    RaisePropertyChanged("_wtax_type");
                }
            }
        }

    }

    public class MultipleContext_ACC_M025
    {
        public ObservableCollection<ACC_M025> TaxList { get; set; }  //Details Entity List
        public List<ADM_M012_P> CountryList { get; set;}
        public List<ACC_M025_A_P> withholdingtaxtypeList { get; set; }

    }
}
