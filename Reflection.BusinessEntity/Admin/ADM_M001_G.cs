using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M001_G : ObjectBase
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

        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set
            {
                if (_so_code != value)
                {
                    _so_code = value; RaisePropertyChanged("so_code");
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

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
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

        private string _sales_org;
        public string sales_org
        {
            get
            {
                return _sales_org;
            }
            set
            {
                if (_sales_org != value)
                {
                    _sales_org = value;
                    RaisePropertyChanged("sales_org ");
                }
            }
        }


        private string _dc_name;
        public string dc_name
        {
            get
            {
                return _dc_name;
            }
            set
            {
                if (_dc_name != value)
                {
                    _dc_name = value;
                    RaisePropertyChanged("dc_name");
                }
            }
        }
        private string _LoctnNm;
        public string LoctnNm
        {
            get
            {
                return _LoctnNm;
            }
            set
            {
                if (_LoctnNm != value)
                {
                    _LoctnNm = value;
                    RaisePropertyChanged("LoctnNm");
                }
            }
        }


    }
    public class MultipleContext_ADM_M001_G
    {
        public ObservableCollection<ADM_M001_G> SPList { get; set; }
        public List<ADM_M001_A_P> SOList { get; set; }
        public List<ADM_M001_C_P> DCList { get; set; }
        public List<ADM_M003_P> PntList { get; set; }
    }
}
