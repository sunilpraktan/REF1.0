using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;



namespace Reflection.BusinessEntity.ReflectionSystem
{
    public partial class SYS_M023 : ObjectBase
    {

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value; RaisePropertyChanged("doc_type");
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
        private string _CatCode;
        public string CatCode
        {
            get { return _CatCode; }
            set
            {
                if (_CatCode != value)
                {
                    _CatCode = value; RaisePropertyChanged("CatCode");
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
                    _active = value; RaisePropertyChanged("active");
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
          private string _doc_desc_user;

         public string doc_desc_user
        {
            get { return _doc_desc_user; }
            set
            {
                if (_doc_desc_user != value)
                {
                    _doc_desc_user = value; RaisePropertyChanged("doc_desc_user");
                }
            }

         }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                if (_doc_cat != value)
                {
                    _doc_cat = value; RaisePropertyChanged("doc_cat");
                }
            }

        }


    }
    public class MultipleContext_SYS_M023
    {

        public ObservableCollection<SYS_M023> Itemlist { get; set; }
        public List<SYS_M002_P> Documentlist { get; set; }

        public List<ADM_M018_P> Categotylist { get; set; }


    }
}
