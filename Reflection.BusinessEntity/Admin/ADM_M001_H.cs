using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M001_H : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
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

        private string _sg_name;
        public string sg_name
        {
            get { return _sg_name; }
            set
            {
                if (_sg_name != value)
                {
                    _sg_name = value; RaisePropertyChanged("sg_name");
                }
            }
        }

        private string _sg_desc;
        public string sg_desc
        {
            get { return _sg_desc; }
            set
            {
                if (_sg_desc != value)
                {
                    _sg_desc = value; RaisePropertyChanged("sg_desc");
                }
            }
        }

        private bool? _active;
        public bool? active
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
    }

   public class MultipleContextADM_M001_H
    {
        public ObservableCollection<ADM_M001_H> SalesGroupList { get; set; }
        public List<ADM_M001_A_P> SalesOrgList { get; set; }

    }
}
