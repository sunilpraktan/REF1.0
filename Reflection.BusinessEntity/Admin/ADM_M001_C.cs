using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M001_C : ObjectBase
    {
        private string _dc_code;
        public string dc_code
        {
            get { return _dc_code; }
            set
            {
                if (_dc_code != value)
                {
                    _dc_code = value;
                    RaisePropertyChanged("dc_code");
                }
            }
        }
       private string _dc_name;
        public string dc_name
        {
            get { return _dc_name; }
            set
            {
                if (_dc_name != value)
                {
                    _dc_name = value;
                    RaisePropertyChanged("dc_name");
                }
            }
        }
        private string _dc_desc;
        public string dc_desc
        {
            get { return _dc_desc; }
            set
            {
                if (_dc_desc != value)
                {
                    _dc_desc = value;
                    RaisePropertyChanged("dc_desc");
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
        
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value;
                    RaisePropertyChanged("lang_key");
                }
            }
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
                if (_Click != value)
                {
                    _Click = value;
                    RaisePropertyChanged("Click");
                }
            }
        }
    }
        public class MultipleContext_ADM_M001_C
        {
            public ObservableCollection<ADM_M001_C> DCList { get; set; }
        }
}

