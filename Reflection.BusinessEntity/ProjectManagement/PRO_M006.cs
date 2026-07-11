namespace Reflection.BusinessEntity.ProjectManagement
{
    public class PRO_M006 : ObjectBase
    {
        private string _task_code;
        public string task_code
        {
            get { return _task_code; }
            set
            {
                if (_task_code != value)
                {
                    _task_code = value;
                    RaisePropertyChanged("task_code");
                }
            }
        }
        private string _task_nm;
        public string task_nm
        {
            get { return _task_nm; }
            set
            {
                if (_task_nm != value)
                {
                    _task_nm = value;
                    RaisePropertyChanged("task_nm");
                }
            }
        }
        private string _task_desc;
        public string task_desc
        {
            get { return _task_desc; }
            set
            {
                if (_task_desc != value)
                {
                    _task_desc = value;
                    RaisePropertyChanged("task_desc");
                }
            }
        }
        private bool _active;
        public bool active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value;
                    RaisePropertyChanged("active");
                }
            }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value;
                    RaisePropertyChanged("comp_code");
                }
            }
        }
       
    }
}
