using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Reflection.BusinessEntity
{
    public class ADM_M010 : ObjectBase
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
        private string _UserId;
        public string UserId
        {
            get { return _UserId; }
            set
            {
                if (_UserId != value)
                {
                    _UserId = value;
                    RaisePropertyChanged("UserId"); RaisePropertyChanged(" UserId", ModelEntityUpdated);
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
        private string _user_type;
        public string user_type
        {
            get { return _user_type; }
            set
            {
                if (_user_type != value)
                {
                    _user_type = value;
                    RaisePropertyChanged("user_type", ModelEntityUpdated);
                }
            }
        }
        private string _user_level;
        public string user_level
        {
            get { return _user_level; }
            set
            {
                if (_user_level != value)
                {
                    _user_level = value;
                    RaisePropertyChanged("user_level", ModelEntityUpdated);
                }
            }
        }
        private string _user_type_name;
        public string user_type_name
        {
            get { return _user_type_name; }
            set
            {
                if (_user_type_name != value)
                {
                    _user_type_name = value;
                    RaisePropertyChanged("user_type_name", ModelEntityUpdated);
                }
            }
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    RaisePropertyChanged("Password"); RaisePropertyChanged(" Password", ModelEntityUpdated);
                }
            }
        }
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }
        private string _EmpId;
        public string EmpId
        {
            get { return _EmpId; }
            set
            {
                if (_EmpId != value)
                {
                    _EmpId = value;
                    RaisePropertyChanged("EmpId");
                }
            }
        }
        private Nullable<bool> _LogSts;
        public Nullable<bool> LogSts
        {
            get { return _LogSts; }
            set
            {
                if (_LogSts != value)
                {
                    _LogSts = value;
                    RaisePropertyChanged("LogSts");
                }
            }
        }
        private Nullable<System.DateTime> _ValidFrm;
        public Nullable<System.DateTime> ValidFrm
        {
            get { return _ValidFrm; }
            set
            {
                if (_ValidFrm != value)
                {
                    _ValidFrm = value;
                    RaisePropertyChanged("ValidFrm");
                }
            }
        }
        private Nullable<System.DateTime> _ValidTo;
        public Nullable<System.DateTime> ValidTo
        {
            get { return _ValidTo; }
            set
            {
                if (_ValidTo != value)
                {
                    _ValidTo = value;
                    RaisePropertyChanged("ValidTo");
                }
            }
        }
        private Nullable<bool> _UserBlkSts;
        public Nullable<bool> UserBlkSts
        {
            get { return _UserBlkSts; }
            set
            {
                if (_UserBlkSts != value)
                {
                    _UserBlkSts = value;
                    RaisePropertyChanged("UserBlkSts");
                }
            }
        }
        private Nullable<bool> _LockStat;
        public Nullable<bool> LockStat
        {
            get { return _LockStat; }
            set
            {
                if (_LockStat != value)
                {
                    _LockStat = value;
                    RaisePropertyChanged("LockStat");
                }
            }
        }
        private string _LockBy;
        public string LockBy
        {
            get { return _LockBy; }
            set
            {
                if (_LockBy != value)
                {
                    _LockBy = value;
                    RaisePropertyChanged("LockBy");
                }
            }
        }
        private Nullable<System.DateTime> _LockDate;
        public Nullable<System.DateTime> LockDate
        {
            get { return _LockDate; }
            set
            {
                if (_LockDate != value)
                {
                    _LockDate = value;
                    RaisePropertyChanged("LockDate");
                }
            }
        }
        private string _UnlockBy;
        public string UnlockBy
        {
            get { return _UnlockBy; }
            set
            {
                if (_UnlockBy != value)
                {
                    _UnlockBy = value;
                    RaisePropertyChanged("UnlockBy");
                }
            }
        }
        private Nullable<System.DateTime> _UnlockDate;
        public Nullable<System.DateTime> UnlockDate
        {
            get { return _UnlockDate; }
            set
            {
                if (_UnlockDate != value)
                {
                    _UnlockDate = value;
                    RaisePropertyChanged("UnlockDate");
                }
            }
        }
        private byte[] _Photo;
        public byte[] Photo
        {
            get { return _Photo; }
            set
            {
                if (_Photo != value)
                {
                    _Photo = value;
                    RaisePropertyChanged("Photo");
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

       
        private string _EmpNm;
        public string EmpNm
        {
            get { return _EmpNm; }
            set
            {
                if (_EmpNm != value)
                {
                    _EmpNm = value;
                    RaisePropertyChanged("EmpNm");
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

        private string _EmpEmailId;
        public string EmpEmailId
        {
            get { return _EmpEmailId; }
            set
            {
                if (_EmpEmailId != value)
                {
                    _EmpEmailId = value;
                    RaisePropertyChanged("EmpEmailId");
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
        private string _CompName;
        public string CompName
        {
            get { return _CompName; }
            set
            {
                if (_CompName != value)
                {
                    _CompName = value; RaisePropertyChanged("CompName");
                }
            }
        }
        private string _dept_code;
        public string dept_code
        {
            get { return _dept_code; }
            set
            {
                if (_dept_code != value)
                {
                    _dept_code = value; RaisePropertyChanged("dept_code");
                }
            }
        }
        private byte[] _digi_sign;
        public byte[] digi_sign
        {
            get { return _digi_sign; }
            set
            {
                if (_digi_sign != value)
                {
                    _digi_sign = value;
                    RaisePropertyChanged("digi_sign");
                }
            }
        }
        public string XmlDataDocument { get; set; }
    }
    public class ADM_M010B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _SrNo { get; set; }
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
        private string _UserId;

        public string UserId
        {
            get { return _UserId; }
            set
            {
                if (_UserId != value)
                {
                    _UserId = value;

                    RaisePropertyChanged("UserId");
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
        private string _ValdtTyp;
        public string ValdtTyp
        {
            get { return _ValdtTyp; }
            set
            {
                if (_ValdtTyp != value)
                {
                    _ValdtTyp = value;

                    RaisePropertyChanged("ValdtTyp");
                }
            }
        }
        private Nullable<System.DateTime> _ValidFrm;

        public Nullable<System.DateTime> ValidFrm
        {
            get { return _ValidFrm; }
            set
            {
                if (_ValidFrm != value)
                {
                    _ValidFrm = value;

                    RaisePropertyChanged("ValidFrm");
                }
            }
        }
        private Nullable<System.DateTime> _ValidTo;

        public Nullable<System.DateTime> ValidTo
        {
            get { return _ValidTo; }
            set
            {
                if (_ValidTo != value)
                {
                    _ValidTo = value;

                    RaisePropertyChanged("ValidTo");
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
        public string _editby;
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
        
        private string _RoleName;
        public string RoleName
        {
            get { return _RoleName; }
            set
            {
                if (_RoleName != value)
                {
                    _RoleName = value;
                    RaisePropertyChanged("RoleName");
                }
            }
        }

    }
    public class MultipleContext_ADM_M010
    {
        public List<ADM_M010> Users { get; set; }//UserMaster
        public ObservableCollection<ADM_M010B> UserDtls { get; set; }
        public ObservableCollection<ADM_M007_P> UserTypes { get; set; }//UserTypeMaster
        public ObservableCollection<ADM_M009_P> RoleData { get; set; }//RoleMaster
        public ObservableCollection<ADM_M024_P> Employees { get; set; }//Employee_Master 
    }





}
