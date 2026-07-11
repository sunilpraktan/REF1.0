namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_E1 : ObjectBase
    {
        private string _mod_group;
        public string mod_group
        {
            get { return _mod_group; }
            set { _mod_group = value; RaisePropertyChanged("mod_group"); }
        }

        private string _mod_group_desc;
        public string mod_group_desc
        {
            get { return _mod_group_desc; }
            set { _mod_group_desc = value; RaisePropertyChanged("mod_group_desc"); }
        }

    }
}
