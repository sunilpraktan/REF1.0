using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class ADM_M008B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
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
        private string _TranCode { get; set; }
        public string TranCode
        {
            get { return _TranCode; }
            set
            {
                if (_TranCode != value)
                {
                    _TranCode = value;
                    RaisePropertyChanged("TranCode"); RaisePropertyChanged("TranCode", ModelEntityUpdated);
                }
            }
        }

        private string _TranName;
        public string TranName
        {
            get { return _TranName; }
            set
            {
                if (_TranName != value)
                {
                    _TranName = value;
                    RaisePropertyChanged("TranName");
                }
            }
        }
        private string _MenuName;
        public string MenuName
        {
            get { return _MenuName; }
            set
            {
                if (_MenuName != value)
                {
                    _MenuName = value;
                    RaisePropertyChanged("MenuName");
                }
            }
        }
        private string _SbModCod;
        public string SbModCod
        {
            get { return _SbModCod; }
            set
            {
                if (_SbModCod != value)
                {
                    _SbModCod = value;
                    RaisePropertyChanged("SbModCod");
                }
            }
        }
        private Nullable<int> _UserTypCode;
        public Nullable<int> UserTypCode
        {
            get { return _UserTypCode; }
            set
            {
                if (_UserTypCode != value)
                {
                    _UserTypCode = value;
                    RaisePropertyChanged("UserTypCode");
                }
            }
        }


        private Nullable<int> _ParentId;

        public Nullable<int> ParentId
        {
            get { return _ParentId; }
            set
            {
                if (_ParentId != value)
                {
                    _ParentId = value;
                    RaisePropertyChanged("ParentId");
                }
            }
        }
        private Nullable<int> _ChildId;

        public Nullable<int> ChildId
        {
            get { return _ChildId; }
            set
            {
                if (_ChildId != value)
                {
                    _ChildId = value;
                    RaisePropertyChanged("ChildId");
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

        private string _DisTitl;
        public string DisTitl
        {
            get { return _DisTitl; }
            set
            {
                if (_DisTitl != value)
                {
                    _DisTitl = value;
                    RaisePropertyChanged("DisTitl");
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

        private System.DateTime _add_date;
        public System.DateTime add_date
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
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                if (_editby != value)
                {
                    _editby = value;
                    RaisePropertyChanged("editby");
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
        private string _UserTyp;
        public string UserTyp
        {
            get { return _UserTyp; }
            set
            {
                if (_UserTyp != value)
                {
                    _UserTyp = value;
                    RaisePropertyChanged("UserTyp");
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

        private string _Nspace;
        public string Nspace
        {
            get { return _Nspace; }
            set
            {
                if (_Nspace != value)
                {
                    _Nspace = value;
                    RaisePropertyChanged("Nspace");
                }
            }
        }
        private string _ClsFileName;
        public string ClsFileName
        {
            get { return _ClsFileName; }
            set
            {
                if (_ClsFileName != value)
                {
                    _ClsFileName = value;
                    RaisePropertyChanged("ClsFileName");
                }
            }
        }
        private string _Npath;
        public string Npath
        {
            get { return _Npath; }
            set
            {
                if (_Npath != value)
                {
                    _Npath = value;
                    RaisePropertyChanged("Npath");
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
    }
    public class MultipleContext_ADM_M008B
    {
        public List<ADM_M008B> Transactions { get; set; }
        public List<ADM_M003_P> Locations { get; set; }//Location Master
        public List<ADM_M007_P> UserTypes { get; set; } //User Type Master     

    }
}
