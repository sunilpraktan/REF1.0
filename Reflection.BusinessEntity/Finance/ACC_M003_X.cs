using System;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_X : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _mov_tp;
        public string mov_tp
        {
            get { return _mov_tp; }
            set { _mov_tp = value; RaisePropertyChanged("mov_tp"); }
        }
        
        private Nullable<bool> _val_update;
        public Nullable<bool> val_update
        {
            get { return _val_update; }
            set { _val_update = value; RaisePropertyChanged("val_update"); }
        }
        
        private Nullable<bool> _qty_update;
        public Nullable<bool> qty_update
        {
            get { return _qty_update; }
            set { _qty_update = value; RaisePropertyChanged("qty_update"); }
        }
        
        private string _key_value;
        public string key_value
        {
            get { return _key_value; }
            set { _key_value = value; RaisePropertyChanged("key_value"); }
        }
       
        private string _mov_ind;
        public string mov_ind
        {
            get { return _mov_ind; }
            set { _mov_ind = value; RaisePropertyChanged("mov_ind"); }
        }
        
        private string _cons_post;
        public string cons_post
        {
            get { return _cons_post; }
            set { _cons_post = value; RaisePropertyChanged("cons_post"); }
        }

        private string _item_cat;
        public string item_cat
        {
            get { return _item_cat; }
            set { _item_cat = value; RaisePropertyChanged("item_cat"); }
        }

        private string _sp_stock;
        public string sp_stock
        {
            get { return _sp_stock; }
            set { _sp_stock = value; RaisePropertyChanged("sp_stock"); }
        }
        
        private string _acc_var;
        public string acc_var
        {
            get { return _acc_var; }
            set { _acc_var = value; RaisePropertyChanged("acc_var"); }
        }
        
       
        //Scalar        
        private string _tran_key;
        public string tran_key
        {
            get { return _tran_key; }
            set { _tran_key = value; RaisePropertyChanged("tran_key"); }
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
   
    public class MultipleContext_ACC_M003_X
    {
        //public List<ACC_M003_X> MasterEntity { get; set; }        
        public ObservableCollection<ACC_M003_X> TransactionKeyEntity { get; set; }
    }
}
