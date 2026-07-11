using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M001_Q : ObjectBase
    {
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
        
        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set
            {
                if (_po_code != value)
                {
                    _po_code = value; RaisePropertyChanged("po_code");
                }
            }
        }

        private string _pg_code;
        public string pg_code
        {
            get { return _pg_code; }
            set
            {
                if (_pg_code != value)
                {
                    _pg_code = value; RaisePropertyChanged("pg_code");
                }
            }
        }

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }

        //scalar
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
        private string _pur_org;
        public string pur_org
        {
            get { return _pur_org; }
            set
            {
                if (_pur_org != value)
                {
                    _pur_org = value; RaisePropertyChanged("pur_org");
                }
            }
        }
        private string _pg_name;
        public string pg_name
        {
            get { return _pg_name; }
            set
            {
                if (_pg_name != value)
                {
                    _pg_name = value; RaisePropertyChanged("pg_name");
                }
            }
        }


    }
    public class MultipleContext_ADM_M001_Q
    {
        public ObservableCollection<ADM_M001_Q> APList { get; set; }
        public List<ADM_M001_P_P> PGList { get; set; }

        public List<ADM_M001_M_P> POList { get; set; }

    }
}
