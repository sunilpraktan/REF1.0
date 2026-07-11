using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public  class ADM_M001_K : ObjectBase
    {
        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set {
                if (_so_code != value)
                {
                    _so_code = value; RaisePropertyChanged("so_code");
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
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");

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
                    _lang_key = value; RaisePropertyChanged("lang_key");
                }
            }
        }
        private string _dc_code;
        public string dc_code
        {
            get { return _dc_code; }
            set
            {
                if (_dc_code != value)
                {
                    _dc_code = value; RaisePropertyChanged("dc_code");
                }
            }
        }
        private string _div_code;
        public string div_code
        {
            get { return _div_code; }
            set
            {
                if (_div_code != value)
                {
                    _div_code = value; RaisePropertyChanged("div_code");
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
        private string _CompName;
        public string CompName
        {
            get { return _CompName; }
            set {
                if (_CompName != value)
                {
                    _CompName = value; RaisePropertyChanged("CompName");

                }
            }
        }
        private string _sales_org;
        public string sales_org
        {
            get { return _sales_org; }
            set {
                if (_sales_org != value)
                {
                    _sales_org = value; RaisePropertyChanged("sales_org");

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

    }
    public class MultipleContext_ADM_M001_K
    {
        public ObservableCollection<ADM_M001_K> SAList { get; set; }
        public List<ADM_M002_P> CCList { get; set; }
        public List<ADM_M001_A_P> SOList { get; set; }
        public List<ADM_M001_C_P> DCList { get; set; }
        public List<ADM_M001_D_P> DivList { get; set; }
    }
}
