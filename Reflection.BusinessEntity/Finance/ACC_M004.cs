using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M004 : ObjectBase
    {
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
        private string _owner_name;
        public string owner_name
        {
            get { return _owner_name; }
            set
            {
                if (_owner_name != value)
                {
                    _owner_name = value;
                    RaisePropertyChanged("owner_name");
                }
            }
        }
        private Nullable<int> _p_sequence;
        public Nullable<int> p_sequence
        {
            get { return _p_sequence; }
            set
            {
                if (_p_sequence != value)
                {
                    _p_sequence = value;
                    RaisePropertyChanged("p_sequence");
                }
            }
        }
        private string _street;
        public string street
        {
            get { return _street; }
            set
            {
                if (_street != value)
                {
                    _street = value;
                    RaisePropertyChanged("street");
                }
            }
        }
        private Nullable<int> _partner_id;
        public Nullable<int> partner_id
        {
            get { return _partner_id; }
            set
            {
                if (_partner_id != value)
                {
                    _partner_id = value;
                    RaisePropertyChanged("partner_id");
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
        private Nullable<int> _bank;
        public Nullable<int> bank
        {
            get { return _bank; }
            set
            {
                if (_bank != value)
                {
                    _bank = value;
                    RaisePropertyChanged("bank");
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

        private string _city;
        public string city
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    RaisePropertyChanged("city");
                }
            }
        }
        private string _p_name;
        public string p_name
        {
            get { return _p_name; }
            set
            {
                if (_p_name != value)
                {
                    _p_name = value;
                    RaisePropertyChanged("p_name");
                }
            }
        }
        private string _zip;
        public string zip
        {
            get { return _zip; }
            set
            {
                if (_zip != value)
                {
                    _zip = value;
                    RaisePropertyChanged("zip");
                }
            }
        }
        private Nullable<bool> _footer;
        public Nullable<bool> footer
        {
            get { return _footer; }
            set
            {
                if (_footer != value)
                {
                    _footer = value;
                    RaisePropertyChanged("footer");
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
                    _state_code = value;
                    RaisePropertyChanged("state_code");
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
        private string _p_state;
        public string p_state
        {
            get { return _p_state; }
            set
            {
                if (_p_state != value)
                {
                    _p_state = value;
                    RaisePropertyChanged("p_state");
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
        private string _j_code;
        public string j_code
        {
            get { return _j_code; }
            set
            {
                if (_j_code != value)
                {
                    _j_code = value;
                    RaisePropertyChanged("j_code");
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
    }
    public class MultipleContext_ACC_M004
    {
        public ObservableCollection<ACC_M004> CompBankMasterList { get; set; }
        public List<ADM_M012_P> CountryList { get; set; }
    }
}
