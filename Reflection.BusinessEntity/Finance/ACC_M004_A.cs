using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M004_A : ObjectBase
    {
        private string _hb_code;
        public string hb_code
        {
            get { return _hb_code; }
            set
            {
                if (_hb_code != value)
                {
                    _hb_code = value;
                    RaisePropertyChanged("hb_code");
                }
            }
        }
        private string _bank_key;
        public string bank_key
        {
            get { return _bank_key; }
            set
            {
                if (_bank_key != value)
                {
                    _bank_key = value;
                    RaisePropertyChanged("bank_key");
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
                    RaisePropertyChanged("_ifsccode");
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
        private Nullable<bool> _active;
        public Nullable<bool> active
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
        private string _invoice_details;
        public string invoice_details
        {
            get { return _invoice_details; }
            set
            {
                if (_invoice_details != value)
                {
                    _invoice_details = value;

                    RaisePropertyChanged("invoice_details");
                }
            }
        }

        //Scalar
        private string _CntryName;
        public string CntryName
        {
            get { return _CntryName; }
            set
            {
                if (_CntryName != value)
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
        private string _bk_abbriviation;
        public string bk_abbriviation
        {
            get { return _bk_abbriviation; }
            set
            {
                if (_bk_abbriviation != value)
                {
                    _bk_abbriviation = value;
                    RaisePropertyChanged("bk_abbriviation");
                }
            }
        }
    }
    public class MultipleContext_ACC_M004_A
    {
        public ObservableCollection<ACC_M004_A> CompBankAccList { get; set; }
        public List<ACC_M004_P> BankCodeList { get; set; }
        public List<ADM_M012_P> CountryList { get; set; }
    }
}
