using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Reflection.BusinessEntity
{
    public class ADM_M009 : ObjectBase
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
        private string _RoleCode;
        public string RoleCode
        {
            get { return _RoleCode; }
            set
            {
                if (_RoleCode != value)
                {
                    _RoleCode = value;
                    RaisePropertyChanged("Role Code", ModelEntityUpdated);
                }
            }
        }
        private string _RoleName;
        public string RoleName
        {
            get { return _RoleName; }
            set
            {
                if (_RoleName != value)
                {
                    _RoleName = value;
                    RaisePropertyChanged("RoleName", ModelEntityUpdated);
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
        public string XmlDataDocument { get; set; }

    }

    public class ADM_M009B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _SrNo;
        public int SrNo
        {
            get { return _SrNo; }
            set
            {
                if (_SrNo != value)
                {
                    _SrNo = value;
                    RaisePropertyChanged("SrNo");
                }
            }
        }
        private int _deletion_id;
        public int deletion_id
        {
            get { return _deletion_id; }
            set
            {
                if (_deletion_id != value)
                {
                    _deletion_id = value;
                    RaisePropertyChanged("deletion_id");
                }
            }
        }
        private string _RoleCode;
        public string RoleCode
        {
            get { return _RoleCode; }
            set
            {
                if (_RoleCode != value)
                {
                    _RoleCode = value;
                    RaisePropertyChanged("RoleCode");
                }
            }
        }
        private string _TranCode;
        public string TranCode
        {
            get { return _TranCode; }
            set
            {
                if (_TranCode != value)
                {
                    _TranCode = value;
                    RaisePropertyChanged("TranCode");
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

        private string _AuthFldCod;
        public string AuthFldCod
        {
            get { return _AuthFldCod; }
            set
            {
                if (_AuthFldCod != value)
                {
                    _AuthFldCod = value;
                    RaisePropertyChanged("AuthFldCod");
                }
            }
        }
        private string _AuthFldNm;
        public string AuthFldNm
        {
            get { return _AuthFldNm; }
            set
            {
                if (_AuthFldNm != value)
                {
                    _AuthFldNm = value;
                    RaisePropertyChanged("AuthFldNm");
                }
            }
        }
        private string _LoctnCode;
        public string LoctnCode
        {
            get { return _LoctnCode; }
            set
            {
                if (_LoctnCode != value)
                {
                    _LoctnCode = value;
                    RaisePropertyChanged("LoctnCode");
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
        private string _Tran_Code;
        public string Tran_Code
        {
            get { return _Tran_Code; }
            set
            {
                if (_Tran_Code != value)
                {
                    _Tran_Code = value;
                    RaisePropertyChanged("Tran_Code");
                }
            }
        }

      
    }
    public class MultipleContext_ADM_M009B
    {
        public List<ADM_M009> RoleData { get; set; }//Role Master
        public ObservableCollection<ADM_M009B> RolDetails { get; set; } //RoleDetails
        public List<ADM_M003_P> Locations { get; set; }//Location Master
        public List<ADM_M005_P> Authorisations { get; set; }//Authorisation Master
        public List<ADM_M008B_P> Transactions { get; set; } //View Master
    }
}
