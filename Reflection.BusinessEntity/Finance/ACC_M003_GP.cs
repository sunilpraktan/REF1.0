namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_GP : ObjectBase //table is deleted from database
    {
        private string  _group_code_i;
        public string group_code_i
        {
            get { return _group_code_i; }

            set { _group_code_i = value; RaisePropertyChanged("group_code_i"); }
        }
        private string _group_desc;
        public string group_desc
        {
            get { return _group_desc; }

            set { _group_desc = value; RaisePropertyChanged("group_desc"); }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }

            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }

            set { _location_Id  = value; RaisePropertyChanged("location_Id"); }
        }
    }
}
