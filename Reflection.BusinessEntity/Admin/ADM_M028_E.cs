using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Reflection.BusinessEntity.Admin
{
    public  class ADM_M028_E : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("id");

                }
            }
        }
        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set
            {
                if (_PartyId != value)
                {
                    _PartyId = value;
                    RaisePropertyChanged("PartyId");
                }
            }
        }
        private string _bank_code;
        public string bank_code
        {
            get { return _bank_code; }
            set
            {
                if (_bank_code != value)
                {
                    _bank_code = value;
                    RaisePropertyChanged("bank_code");
                }
            }
        }
        private string _branch;
        public string branch
        {
            get { return _branch; }
            set
            {
                if (_branch != value)
                {
                    _branch = value;
                    RaisePropertyChanged("branch");
                }
            }
        }
        private string _ifsccode;
        public string ifsccode
        {
            get { return _ifsccode; }
            set
            {
                if (_ifsccode != value)
                {
                    _ifsccode = value;
                    RaisePropertyChanged("ifsccode");
                }
            }
        }

        private string _acc_number;
        public string acc_number
        {
            get { return _acc_number; }
            set
            {
                if (_acc_number != value)
                {
                    _acc_number = value;
                    RaisePropertyChanged("acc_number");
                }
            }
        }
        private string _swift_code;
        public string swift_code
        {
            get { return _swift_code; }
            set
            {
                if (_swift_code != value)
                {
                    _swift_code = value;
                    RaisePropertyChanged("swift_code");
                }
            }
        }
        private string _acc_holder_name;
        public string acc_holder_name
        {
            get { return _acc_holder_name; }
            set
            {
                if (_acc_holder_name != value)
                {
                    _acc_holder_name = value;
                    RaisePropertyChanged("acc_holder_name");

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
                    RaisePropertyChanged("location_Id");
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
        private string _gl_code;
        public string gl_code
        {
            get { return _gl_code; }
            set
            {
                if (_gl_code != value)
                {
                    _gl_code = value;
                    RaisePropertyChanged("gl_code");
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
        private System.DateTime _add_date;
        public System.DateTime add_date
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
        private string _t_status;

        public string t_status
        {
            get { return _t_status; }
            set
            {
                if (_t_status != value)
                {
                    _t_status = value;

                    RaisePropertyChanged("t_status");
                }
            }

        }
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
       
        private string _lang_key;

        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value;
                    RaisePropertyChanged("lang_key");
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
                    RaisePropertyChanged("country_code");
                }
            }
        }
        private string _iban_no;
        public string iban_no
        {
            get { return _iban_no; }
            set
            {
                if (_iban_no != value)
                {
                    _iban_no = value;
                    RaisePropertyChanged("iban_no");
                }
            }
        }
        private string _pb_code;

        public string pb_code
        {
            get { return _pb_code; }
            set
            {
                if(_pb_code != value)
                {
                    _pb_code = value;
                    RaisePropertyChanged("pb_code");
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
        private string _CntryName;
        public string CntryName
        {
            get { return _CntryName; }
            set
            {
                if(_CntryName != value)
                {
                    _CntryName = value;
                    RaisePropertyChanged("CntryName");

                }
            }
        }
        private string _bank_name;
        public string bank_name
        {
            get { return _bank_name; }
            set
            {
                if (_bank_name != value)
                {
                    _bank_name = value;
                    RaisePropertyChanged("bank_name");
                }
            }
        }
        private string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set
            {
                _PartyNm = value;
                RaisePropertyChanged("PartyNm");
            }
        }



    }
    public class MultipleContext_ADM_M028_E
    {
        public ObservableCollection<ADM_M028_E> PartyList { get; set; } //Details Entity List 

        public List<ADM_M012_P> CountryList { get; set; }

        public List<ACC_M004_P> BankcodeList { get; set; }

        public List<ADM_M028_P> PartyIDList { get; set; }



    }


}
