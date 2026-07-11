using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M001_F : ObjectBase
    {

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("id");
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
                    _div_code = value;
                    RaisePropertyChanged("div_code");
                }
            }
        }

        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set
            {
                if (_so_code != value)
                {
                    _so_code = value;
                    RaisePropertyChanged("so_code");
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
        private Nullable<bool> _active;
        public Nullable<bool> active
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


        //Scalar

        private Nullable<bool> _select;
        public Nullable<bool> select
        {
           get{ return _select; }
            set
            {
                if (_select != value)
                {
                    _select = value;
                    RaisePropertyChanged("select");
                }
            }
        }
        private string _div_name;
        public string div_name
        {
           get{ return _div_name; }
            set
            {
                if (_div_name != value)
                {
                    _div_name = value;
                    RaisePropertyChanged("div_name");
                }
            }
        }
        
        private string _sales_org;
               public string sales_org
        {
            get { return _sales_org; }
            set
            {
                if (_sales_org != value)
                {
                    _sales_org = value;
                    RaisePropertyChanged("sales_org");
                }
            }
        }

        public bool Click { get; set; }

        
    }
    public class MultipleContext_ADM_M001_F
    {
        public ObservableCollection<ADM_M001_F> DivAsSolist { get; set; }
        public List<ADM_M001_D_P> divlist { get; set; }
        public List<ADM_M001_A_P> solist { get; set; }

    }
}

