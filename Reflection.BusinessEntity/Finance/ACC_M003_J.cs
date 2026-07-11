namespace Reflection.BusinessEntity.Finance
{
    class ACC_M003_J : ObjectBase
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

        private string _trans_scope;
        public string trans_scope
        {
            get { return _trans_scope; }
            set
            {
                _trans_scope = value;
                RaisePropertyChanged("trans_scope");
            }
        }

        private string _desc_app;
        public string desc_app
        {
            get { return _desc_app; }
            set
            {
                _desc_app = value;
                RaisePropertyChanged("desc_app");
            }
        }
    }
}
