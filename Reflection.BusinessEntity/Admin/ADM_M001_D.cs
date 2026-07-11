using System;
using System.Collections.ObjectModel;


namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M001_D : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _div_code;
        public string div_code
        {
            get { return _div_code; }
            set
            {
                if (_div_code != value)
                {
                    _div_code = value;
                    RaisePropertyChanged("div_code");
                }
            }
        }
        
        private string _div_name;
        public string div_name
        {
            get { return _div_name; }
            set
            {
                if (_div_name != value)
                {
                    _div_name = value;
                    RaisePropertyChanged("div_name");
                }
            }
        }
        private string _div_desc;
        public string div_desc
        {
            get { return _div_desc; }
            set
            {
                if (_div_desc != value)
                {
                    _div_desc = value;
                    RaisePropertyChanged("div_desc");
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

        public class MultipleContext_ADM_M001_D
        {
            public ObservableCollection<ADM_M001_D> SDlist { get; set; }
        }
    
}
