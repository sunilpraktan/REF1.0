using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_E : ObjectBase
    { 

        private string _trns_key_code;
        public string trns_key_code
        {
            get { return _trns_key_code; }
            set { _trns_key_code = value; RaisePropertyChanged("trns_key_code"); }
        }

        private string _mod_group;
        public string mod_group
        {
            get { return _mod_group; }
            set { _mod_group = value; RaisePropertyChanged("mod_group"); }
        }

        private string _trns_code;
        public string trns_code
        { get { return _trns_code; }
            set { _trns_code = value; RaisePropertyChanged("trns_code"); }
        }

        private string _t_field1;
        public string t_field1
        {
            get { return _t_field1; }
            set { _t_field1 = value; RaisePropertyChanged("t_field1"); }
        }

        private string _t_field2;
        public string t_field2
        {
            get { return _t_field2; }
            set { _t_field2 = value; RaisePropertyChanged("t_field2"); }
        }

        private string _t_field3;
        public string t_field3
        {
            get { return _t_field3; }
            set { _t_field3 = value; RaisePropertyChanged("t_field3"); }
        }

        private string _fun1;  
        public string fun1
        {
            get { return _fun1; }
            set { _fun1 = value; RaisePropertyChanged("fun1"); }
        }

        private string _fun2;
        public string fun2
        {
            get { return _fun2; }
            set { _fun2 = value; RaisePropertyChanged("fun2"); }
        }


        private string _fun3;
        public string fun3
        {
            get { return _fun3; }
            set { _fun3 = value; RaisePropertyChanged("fun3"); }
        }

        private string _module;
        public string module
        {
            get { return _module; }
            set { _module = value; RaisePropertyChanged("module"); }
        }

        private Nullable<bool> _ind_acc_det;
        public Nullable<bool> ind_acc_det
        {
            get { return _ind_acc_det; }
            set { _ind_acc_det = value; RaisePropertyChanged("ind_acc_det"); }
        }

        private string _trns_key_desc;
        public string trns_key_desc
        {
            get { return _trns_key_desc; }
            set { _trns_key_desc = value; RaisePropertyChanged("trns_key_desc"); }
        }
        //Scalar 

        private string _TranCode;
        public string TranCode
        {
            get { return _TranCode; }
            set { _TranCode = value; RaisePropertyChanged("TranCode"); }
        }

        private string _COA_Key;
        public string COA_Key
        {
            get { return _COA_Key; }
            set { _COA_Key = value; RaisePropertyChanged("COA_Key"); }
        }

        private string _comp_code_P;
        public string comp_code_P
        {
            get { return _comp_code_P; }
            set { _comp_code_P = value; RaisePropertyChanged("comp_code_P"); }
        }
    }
    public class MultipleContext_ACC_M003_E
    {
        public List<ACC_M003_E> MasterEntityList { get; set; }
        public List<ACC_M003_E1> ModuleGroupMaster { get; set; }
        public List<ACC_M003_D_P> COAKeyList { get; set; }
    }
}
