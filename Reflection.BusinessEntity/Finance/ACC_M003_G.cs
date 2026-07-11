using System;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_G : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _value_group;
        public string value_group
        {
            get { return _value_group; }
            set { _value_group = value; RaisePropertyChanged("value_group"); }
        }

        private string _val_area;
        public string val_area
        {
            get { return _val_area; }
            set { _val_area = value; RaisePropertyChanged("val_area"); }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        private string _coa_key;
        public string coa_key
        {
            get { return _coa_key; }
            set { _coa_key = value; RaisePropertyChanged("coa_key"); }
        }
        
    }
}
