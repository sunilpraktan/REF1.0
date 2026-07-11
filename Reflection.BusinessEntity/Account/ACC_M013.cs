using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Account
{
    public class ACC_M013 : ObjectBase
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
        private Nullable<int> _ref_base_code_id;
        public Nullable<int> ref_base_code_id
        {
            get { return _ref_base_code_id; }
            set
            {
                if (_ref_base_code_id != value)
                {
                    _ref_base_code_id = value;

                    RaisePropertyChanged("ref_base_code_id");
                }
            }
        }
        private string _domain;
        public string domain
        {
            get { return _domain; }
            set
            {
                if (_domain != value)
                {
                    _domain = value;

                    RaisePropertyChanged("domain");
                }
            }
        }
        private string _description;
        public string description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;

                    RaisePropertyChanged("description");
                }
            }
        }
        private Nullable<int> _ref_tax_code_id;
        public Nullable<int> ref_tax_code_id
        {
            get { return _ref_tax_code_id; }
            set
            {
                if (_ref_tax_code_id != value)
                {
                    _ref_tax_code_id = value;

                    RaisePropertyChanged("ref_tax_code_id");
                }
            }
        }
        private int _sequence;
        public int sequence
        {
            get { return _sequence; }
            set
            {
                if (_sequence != value)
                {
                    _sequence = value;

                    RaisePropertyChanged("sequence");
                }
            }
        }
        private Nullable<int> _account_paid_id;
        public Nullable<int> account_paid_id
        {
            get { return _account_paid_id; }
            set
            {
                if (_account_paid_id != value)
                {
                    _account_paid_id = value;

                    RaisePropertyChanged("account_paid_id");
                }
            }
        }
        private Nullable<decimal> _ref_base_sign;
        public Nullable<decimal> ref_base_sign
        {
            get { return _ref_base_sign; }
            set
            {
                if (_ref_base_sign != value)
                {
                    _ref_base_sign = value;

                    RaisePropertyChanged("ref_base_sign");
                }
            }
        }
        private string _type_tax_use;
        public string type_tax_use
        {
            get { return _type_tax_use; }
            set
            {
                if (_type_tax_use != value)
                {
                    _type_tax_use = value;

                    RaisePropertyChanged("type_tax_use");
                }
            }
        }
        private Nullable<int> _base_code_id;
        public Nullable<int> base_code_id
        {
            get { return _base_code_id; }
            set
            {
                if (_base_code_id != value)
                {
                    _base_code_id = value;

                    RaisePropertyChanged("base_code_id");
                }
            }
        }
        private Nullable<decimal> _base_sign;
        public Nullable<decimal> base_sign
        {
            get { return _base_sign; }
            set
            {
                if (_base_sign != value)
                {
                    _base_sign = value;

                    RaisePropertyChanged("base_sign");
                }
            }
        }
        private Nullable<bool> _child_depend;
        public Nullable<bool> child_depend
        {
            get { return _child_depend; }
            set
            {
                if (_child_depend != value)
                {
                    _child_depend = value;

                    RaisePropertyChanged("child_depend");
                }
            }
        }
        private Nullable<bool> _include_base_amount;
        public Nullable<bool> include_base_amount
        {
            get { return _include_base_amount; }
            set
            {
                if (_include_base_amount != value)
                {
                    _include_base_amount = value;

                    RaisePropertyChanged("include_base_amount");
                }
            }
        }
        private Nullable<int> _account_analytic_collected_id;
        public Nullable<int> account_analytic_collected_id
        {
            get { return _account_analytic_collected_id; }
            set
            {
                if (_account_analytic_collected_id != value)
                {
                    _account_analytic_collected_id = value;

                    RaisePropertyChanged("account_analytic_collected_id");
                }
            }
        }
        private Nullable<int> _account_analytic_paid_id;
        public Nullable<int> account_analytic_paid_id
        {
            get { return _account_analytic_paid_id; }
            set
            {
                if (_account_analytic_paid_id != value)
                {
                    _account_analytic_paid_id = value;

                    RaisePropertyChanged("account_analytic_paid_id");
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
        private Nullable<decimal> _ref_tax_sign;
        public Nullable<decimal> ref_tax_sign
        {
            get { return _ref_tax_sign; }
            set
            {
                if (_ref_tax_sign != value)
                {
                    _ref_tax_sign = value;

                    RaisePropertyChanged("ref_tax_sign");
                }
            }
        }
        private string _applicable_type;
        public string applicable_type
        {
            get { return _applicable_type; }
            set
            {
                if (_applicable_type != value)
                {
                    _applicable_type = value;

                    RaisePropertyChanged("applicable_type");
                }
            }
        }
        private Nullable<int> _account_collected_id;
        public Nullable<int> account_collected_id
        {
            get { return _account_collected_id; }
            set
            {
                if (_account_collected_id != value)
                {
                    _account_collected_id = value;

                    RaisePropertyChanged("account_collected_id");
                }
            }
        }
        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set
            {
                if (_location_id != value)
                {
                    _location_id = value;

                    RaisePropertyChanged("location_id");
                }
            }
        }
        private string _t_name;
        public string t_name
        {
            get { return _t_name; }
            set
            {
                if (_t_name != value)
                {
                    _t_name = value;

                    RaisePropertyChanged("t_name");
                }
            }
        }
        private Nullable<int> _tax_code_id;
        public Nullable<int> tax_code_id
        {
            get { return _tax_code_id; }
            set
            {
                if (_tax_code_id != value)
                {
                    _tax_code_id = value;

                    RaisePropertyChanged("tax_code_id");
                }
            }
        }
        private Nullable<int> _parent_id;
        public Nullable<int> parent_id
        {
            get { return _parent_id; }
            set
            {
                if (_parent_id != value)
                {
                    _parent_id = value;

                    RaisePropertyChanged("parent_id");
                }
            }
        }
        private decimal _amount;
        public decimal amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;

                    RaisePropertyChanged("amount");
                }
            }
        }
        private string _python_compute;
        public string python_compute
        {
            get { return _python_compute; }
            set
            {
                if (_python_compute != value)
                {
                    _python_compute = value;

                    RaisePropertyChanged("python_compute");
                }
            }
        }
        private Nullable<decimal> _tax_sign;
        public Nullable<decimal> tax_sign
        {
            get { return _tax_sign; }
            set
            {
                if (_tax_sign != value)
                {
                    _tax_sign = value;

                    RaisePropertyChanged("tax_sign");
                }
            }
        }
        private string _python_compute_inv;
        public string python_compute_inv
        {
            get { return _python_compute_inv; }
            set
            {
                if (_python_compute_inv != value)
                {
                    _python_compute_inv = value;

                    RaisePropertyChanged("python_compute_inv");
                }
            }
        }
        private string _python_applicable;
        public string python_applicable
        {
            get { return _python_applicable; }
            set
            {
                if (_python_applicable != value)
                {
                    _python_applicable = value;

                    RaisePropertyChanged("python_applicable");
                }
            }
        }
        private string _t_type;
        public string t_type
        {
            get { return _t_type; }
            set
            {
                if (_t_type != value)
                {
                    _t_type = value;

                    RaisePropertyChanged("t_type");
                }
            }
        }
        private Nullable<bool> _price_include;
        public Nullable<bool> price_include
        {
            get { return _price_include; }
            set
            {
                if (_price_include != value)
                {
                    _price_include = value;

                    RaisePropertyChanged("price_include");
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
        private string _tax_code;
        public string tax_code
        {
            get { return _tax_code; }
            set
            {
                if (_tax_code != value)
                {
                    _tax_code = value;

                    RaisePropertyChanged("tax_code");
                }
            }
        }
        private string _AccBaseCd;      
        public string AccBaseCd
        {
            get { return _AccBaseCd; }
            set
            {
                if (_AccBaseCd != value)
                {
                    _AccBaseCd = value;

                    RaisePropertyChanged("AccBaseCd");
                }
            }
        }
        private string _AccTaxCd;
        public string AccTaxCd
        {
            get { return _AccTaxCd; }
            set
            {
                if (_AccTaxCd != value)
                {
                    _AccTaxCd = value;

                    RaisePropertyChanged("AccTaxCd");
                }
            }
        }

        private string _RefBaseCd;
        public string RefBaseCd
        {
            get { return _RefBaseCd; }
            set
            {
                if (_RefBaseCd != value)
                {
                    _RefBaseCd = value;

                    RaisePropertyChanged("RefBaseCd");
                }
            }
        }
        private string _RefTaxCd;
        public string RefTaxCd
        {
            get { return _RefTaxCd; }
            set
            {
                if (_RefTaxCd != value)
                {
                    _RefTaxCd = value;

                    RaisePropertyChanged("RefTaxCd");
                }
            }
        }
        private string _InvocTaxAcc;
        public string InvocTaxAcc
        {
            get { return _InvocTaxAcc; }
            set
            {
                if (_InvocTaxAcc != value)
                {
                    _InvocTaxAcc = value;

                    RaisePropertyChanged("InvocTaxAcc");
                }
            }
        }
        private string _RefTaxAcc;
        public string RefTaxAcc
        {
            get { return _RefTaxAcc; }
            set
            {
                if (_RefTaxAcc != value)
                {
                    _RefTaxAcc = value;

                    RaisePropertyChanged("RefTaxAcc");
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

        private string _p_code;
        public string p_code
        {
            get { return _p_code; }
            set
            {
                if (_p_code != value)
                {
                    _p_code = value;

                    RaisePropertyChanged("p_code");
                }
            }
        }

        private string _t_code;
        public string t_code
        {
            get { return _t_code; }
            set
            {
                if (_t_code != value)
                {
                    _t_code = value;

                    RaisePropertyChanged("t_code");
                }
            }
        }

    }
    public class MultipleContext_ACC_M013
    {       
        public ObservableCollection<ACC_M013> Tax_Master { get; set; }//Tax_Master    
        public List<ACC_M003_P> Acc_AccountDtls { get; set; }//Acc_Account
        public List<ACC_M014_P> Acc_Tax_CodeDtls { get; set; }//Acc_Tax_Code 
    }

}
