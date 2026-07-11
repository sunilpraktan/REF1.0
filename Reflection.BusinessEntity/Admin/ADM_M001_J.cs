using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M001_J:ObjectBase 
    {
       
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

        private string _soff_code;
        public string soff_code
        {
            get { return _soff_code; }
            set
            {
                if (_soff_code != value)
                {
                    _soff_code = value; RaisePropertyChanged("soff_code");
                }

            }
        }
        private string _sg_code;
        public string sg_code
        {
            get { return _sg_code; }
            set
            {
                if (_sg_code != value)
                {
                    _sg_code = value; RaisePropertyChanged("sg_code");
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
                    _active = value; RaisePropertyChanged("active");
                }

            }
        }
        public string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value; RaisePropertyChanged("lang_key");
                }

            }
        }

        //Scalar
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
        private string _sg_name;

        public string sg_name
        {
            get
            {
                return _sg_name;
            }
            set
            {
                if (_sg_name != value)
                {
                    _sg_name = value;
                    RaisePropertyChanged("sg_name");
                }
            }
        }
        private string _sales_off;
        public string sales_off
        {
            get
            {
                return _sales_off;
            }
            set
            {
                if (_sales_off != value)
                {
                    _sales_off = value;
                    RaisePropertyChanged("sales_off");
                }
            }
        }



    }

    public class MultipleContext_ADM_M001_J
    {
        public ObservableCollection<ADM_M001_J> AssignSalesGrouptoSalesOfficeList { get; set; }
        public List<ADM_M001_I_P> SOList { get; set; }
        public List<ADM_M001_H_P> SGList { get; set; }

    }
}
