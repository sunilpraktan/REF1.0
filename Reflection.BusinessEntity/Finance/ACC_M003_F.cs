using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_F : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        
        private string _coa_key;
        public string coa_key
        {
            get { return _coa_key; }
            set { _coa_key = value; RaisePropertyChanged("coa_key"); }
        }

        private string _mod_group;
        public string mod_group
        {
            get { return _mod_group; }
            set { _mod_group = value; RaisePropertyChanged("mod_group",ModelEntityUpdated); }
        }

        private string _trns_key_code;
        public string trns_key_code
        {
            get { return _trns_key_code; }
            set { _trns_key_code = value; RaisePropertyChanged("trns_key_code"); }
        }

        private Nullable<bool> _acc_var;
        public Nullable<bool> acc_var
        {
            get { return _acc_var; }
            set { _acc_var = value; RaisePropertyChanged("acc_var", ModelEntityUpdated); }
        }

        private Nullable<bool> _value_group;
        public Nullable<bool> value_group
        {
            get { return _value_group; }
            set { _value_group = value; RaisePropertyChanged("value_group", ModelEntityUpdated); }
        }

        private Nullable<bool> _value_class;
        public Nullable<bool> value_class
        {
            get { return _value_class; }
            set { _value_class = value; RaisePropertyChanged("value_class", ModelEntityUpdated); }
        }

        private Nullable<bool> _drcr;
        public Nullable<bool> drcr
        {
            get { return _drcr; }
            set { _drcr = value; RaisePropertyChanged("drcr",ModelEntityUpdated); }
        }

        private Nullable<bool> _tax_code;
        public Nullable<bool> tax_code
        {
            get { return _tax_code; }
            set { _tax_code = value; RaisePropertyChanged("tax_code", ModelEntityUpdated); }
        }

        private Nullable<bool> _buss_place;
        public Nullable<bool> buss_place
        {
            get { return _buss_place; }
            set { _buss_place = value; RaisePropertyChanged("buss_place", ModelEntityUpdated); }
        }

        //Scalar 

        private string _TranCode;
        public string TranCode
        {
            get { return _TranCode; }
            set { _TranCode = value; RaisePropertyChanged("TranCode"); }
        }
    }
   public  class MultipleContext_ACC_M003_F
    {
        public List<ACC_M003_F> MasterEntityList { get; set; }
        public List<ACC_M003_E> TransactionEventKeyMaster { get; set; }
    }
}
