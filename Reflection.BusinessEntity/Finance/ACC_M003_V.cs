namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_V : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }

        private string _value_class;
        public string value_class
        {
            get { return _value_class; }
            set
            {
                _value_class = value;
                RaisePropertyChanged("value_class");
            }
        }

        private string _value_class_desc;
        public string value_class_desc
        {
            get { return _value_class_desc; }
            set
            {
                _value_class_desc = value;
                RaisePropertyChanged("value_class_desc");
            }
        }

        private string _acc_cat;
        public string acc_cat
        {
            get { return _acc_cat; }
            set
            {
                _acc_cat = value;
                RaisePropertyChanged("acc_cat");
            }
        }

    }
}
