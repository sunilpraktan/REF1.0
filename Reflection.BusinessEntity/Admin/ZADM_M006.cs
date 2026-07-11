using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public class ZADM_M006 : ObjectBase, IDataErrorInfo
    {
        private int _ink_id;
        public int ink_id
        {
            get { return _ink_id; }
            set
            {
                if (_ink_id != value)
                {
                    _ink_id = value;

                    RaisePropertyChanged("ink_id");
                }
            }
        }
        private string _ink;
        //[Required(ErrorMessage = "Field 'Ink' is required.")]       
        public string ink
        {
            get { return _ink; }
            set
            {
                if (_ink != value)
                {
                    _ink = value;

                    RaisePropertyChanged("ink");
                }
            }
        }
        private Nullable<int> _make_id;
        public Nullable<int> make_id
        {
            get { return _make_id; }
            set
            {
                if (_make_id != value)
                {
                    _make_id = value;

                    RaisePropertyChanged("make_id");
                }
            }
        }
        private string _desc;
        public string desc
        {
            get { return _desc; }
            set
            {
                if (_desc != value)
                {
                    _desc = value;

                    RaisePropertyChanged("desc");
                }
            }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value;

                    RaisePropertyChanged("add_by");
                }
            }
        }
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value;

                    RaisePropertyChanged("add_date");
                }
            }
        }
        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                if (_edit_by != value)
                {
                    _edit_by = value;

                    RaisePropertyChanged("edit_by");
                }
            }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value;

                    RaisePropertyChanged("edit_date");
                }
            }
        }
        private string _Make;
        public string Make
        {
            get { return _Make; }
            set
            {
                if (_Make != value)
                {
                    _Make = value;

                    RaisePropertyChanged("Make");
                }
            }
        }
        private string _viscosity;
        public string viscosity
        {
            get { return _viscosity; }
            set
            {
                if (_viscosity != value)
                {
                    _viscosity = value;

                    RaisePropertyChanged("viscosity");
                }
            }
        }
        string IDataErrorInfo.Error
        {
            get { throw new NotImplementedException(); }
        }
        string IDataErrorInfo.this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }
    }
    public class MultipleContext_ZADM_M006
    {
        public List<ZADM_M006> Ink_Master { get; set; }//Ink Master    
        public ObservableCollection<ADM_M032_P> Make_Dtls { get; set; }//Make Master        
    }
    //public class ADM_M032_P
    //{
    //    public int MakeCode { get; set; }
    //    [DisplayName("Make")]
    //    public string Make { get; set; }      

    //}
}
