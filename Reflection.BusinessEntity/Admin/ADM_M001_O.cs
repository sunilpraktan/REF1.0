using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M001_O : ObjectBase
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
        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set
            {
                if (_po_code != value)
                {
                    _po_code = value;
                    RaisePropertyChanged("po_code");
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
                    _location_Id = value;
                    RaisePropertyChanged("location_Id");
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

        //Scalar

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {if (_comp_code != value)
                {
                    _comp_code = value;
                    RaisePropertyChanged("comp_code");
                }
            }
        }

        private string _LoctnNm;
       

        public string LoctnNm
        {
            get { return _LoctnNm; }
            set
            {
                if (_LoctnNm != value)
                {
                    _LoctnNm = value;
                    RaisePropertyChanged("LoctnNm");
                }
            }
        }
        private string _pur_org;
        public string pur_org
        {
            get { return _pur_org; }
            set
            {
                if(_pur_org !=value)
                {
                    _pur_org = value;
                    RaisePropertyChanged("pur_org");
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

    public class MultipleContext_ADM_M001_O
    {
        public ObservableCollection <ADM_M001_O> POCode  { get; set; }
        public List<ADM_M001_M_P> PurOrg { get; set; }
        public List<ADM_M003_P>Location { get; set; }
    }
}
