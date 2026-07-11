using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M004_B : ObjectBase
    {
        private string _hb_acc;
        public string hb_acc
        {
            get { return _hb_acc; }
            set
            {
                if (_hb_acc != value)
                {
                    _hb_acc = value;
                    RaisePropertyChanged("hb_acc");
                }
            }
        }
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
        private string _acc_id;
        public string acc_id
        {
            get { return _acc_id; }
            set
            {
                if (_acc_id != value)
                {
                    _acc_id = value;
                    RaisePropertyChanged("acc_id");
                }
            }
        }
        private string _acc_no;
        public string acc_no
        {
            get { return _acc_no; }
            set
            {
                if (_acc_no != value)
                {
                    _acc_no = value;
                    RaisePropertyChanged("acc_no");
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
                    _curr_code = value;
                    RaisePropertyChanged("curr_code");
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
        private string _recon_acc;
        public string recon_acc
        {
            get { return _recon_acc; }
            set
            {
                if (_recon_acc != value)
                {
                    _recon_acc = value;

                    RaisePropertyChanged("recon_acc");
                }
            }
        }
        private string _ind_default;
        public string ind_default
        {
            get { return _ind_default; }
            set
            {
                if (_ind_default != value)
                {
                    _ind_default = value;

                    RaisePropertyChanged("ind_default");
                }
            }
        }
        //Scalar
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
        private string _curr_name;
        public string curr_name
        {
            get { return _curr_name; }
            set
            {
                if (_curr_name != value)
                {
                    _curr_name = value;
                    RaisePropertyChanged("curr_name");
                }
            }
        }
    }
    public class MultipleContext_ACC_M004_B
    {
        public ObservableCollection<ACC_M004_B> CompBankAccList { get; set; }
        public List<ACC_M004_P> BankCodeList { get; set; }
        public List<ACC_M004_A_P> BankKeyList { get; set; }
        public List<ADM_M037_P> CurrencyList { get; set; }
    }
}
