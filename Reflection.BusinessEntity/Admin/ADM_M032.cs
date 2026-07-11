using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class ADM_M032 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _MakeCode;
        public int MakeCode
        {
            get { return _MakeCode; }
            set
            {
                _MakeCode = value;
                RaisePropertyChanged("MakeCode");
            }
        }

        private string _Make;
        public string Make
        {
            get { return _Make; }
            set
            {
                _Make = value;
                RaisePropertyChanged("Make");
            }
        }

        private string _Descriptn;
        public string Descriptn
        {
            get { return _Descriptn; }
            set
            {
                _Descriptn = value;
                RaisePropertyChanged("Descriptn");
            }
        }

        private string _Maketype;
        public string make_type
        {
            get { return _Maketype; }
            set
            {
                _Maketype = value;
                RaisePropertyChanged("Maketype");
            }
        }

        private string _ink;
        public string ink
        {
            get { return _ink; }
            set
            {
                _ink = value;
                RaisePropertyChanged("ink");
            }
        }

        private string _location_id;
        public string location_Id
        {
            get { return _location_id; }
            set
            {
                _location_id = value;
                RaisePropertyChanged("location_id");
            }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }

        private System.DateTime _add_date { get; set; }
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }

        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public class MultipleContext_ADM_M032
    {
        public List<ADM_M032> MasterEntity { get; set; }
        public List<ADM_M032Flip> FlipGridData { get; set; }
    }
}

