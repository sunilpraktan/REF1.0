using System;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_S : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _acc_pro;
        public string acc_pro
        {
            get { return _acc_pro; }
            set { _acc_pro = value; RaisePropertyChanged("acc_pro"); }
        }
        private string _acc_pro_desc;
        public string acc_pro_desc
        {
            get { return _acc_pro_desc; }
            set { _acc_pro_desc = value; RaisePropertyChanged("acc_pro_desc"); }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        
    }

    public class ACC_M003_S1 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _acc_pro;
        public string acc_pro
        {
            get { return _acc_pro; }
            set { _acc_pro = value; RaisePropertyChanged("acc_pro"); }
        }
        private string _con_type;
        public string con_type
        {
            get { return _con_type; }
            set { _con_type = value; RaisePropertyChanged("con_type"); }
        }
        private Nullable<int> _step;
        public Nullable<int> step
        {
            get { return _step; }
            set { _step = value; RaisePropertyChanged("step"); }
        }
        private Nullable<int> _sequence;
        public Nullable<int> sequence
        {
            get { return _sequence; }
            set { _sequence = value; RaisePropertyChanged("sequence"); }
        }
        private string _con_type_desc;
        public string con_type_desc
        {
            get { return _con_type_desc; }
            set { _con_type_desc = value; RaisePropertyChanged("con_type_desc"); }
        }
        
    }

    public class ACC_M003_S2 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        private string _acc_pro;
        public string acc_pro
        {
            get { return _acc_pro; }
            set { _acc_pro = value; RaisePropertyChanged("acc_pro"); }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type"); }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
    }
}
