using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_N : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _pricing_pro;
        public string pricing_pro
        {
            get { return _pricing_pro; }
            set { _pricing_pro = value; RaisePropertyChanged("pricing_pro"); }
        }        

        private string _condition_type;
        public string condition_type
        {
            get { return _condition_type; }
            set { _condition_type = value; RaisePropertyChanged("condition_type"); }
        }

        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged("name"); }
        }

        private string _trns_key_code;
        public string trns_key_code
        {
            get { return _trns_key_code; }
            set { _trns_key_code = value; RaisePropertyChanged("trns_key_code"); }
        }

        private string _key_value;
        public string key_value
        {
            get { return _key_value; }
            set { _key_value = value; RaisePropertyChanged("key_value"); }
        }

        private string _mod_group;
        public string mod_group
        {
            get { return _mod_group; }
            set { _mod_group = value; RaisePropertyChanged("mod_group"); }
        }

        private string _trans_scope;
        public string trans_scope
        {
            get { return _trans_scope; }
            set { _trans_scope = value; RaisePropertyChanged("trans_scope"); }
        }

        private Nullable <int> _step;
        public Nullable<int> step
        {
            get { return _step; }
            set { _step = value; RaisePropertyChanged("step"); }
        }

        private string _acc_pro;
        public string acc_pro
        {
            get { return _acc_pro; }
            set { _acc_pro = value; RaisePropertyChanged("acc_pro"); }
        }

        //Scalar        
        private string _condition_desc;
        public string condition_desc
        {
            get { return _condition_desc; }
            set { _condition_desc = value; RaisePropertyChanged("condition_desc"); }
        }

        private string _trns_key_desc;
        public string trns_key_desc
        {
            get { return _trns_key_desc; }
            set { _trns_key_desc = value; RaisePropertyChanged("trns_key_desc"); }
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
                _Click = value;
                RaisePropertyChanged("Click");
            }
        }

    }

    public class MultipleContext_ACC_M003_N
    {
        //public List<ACC_M003_X> MasterEntity { get; set; }        
        public ObservableCollection<ACC_M003_N> PricingProEntity { get; set; }
        public List<ACC_M003_O_P> ConditionType { get; set; }
        public List<ACC_M003_E_P> TransactionKey { get; set; }
    }
}
