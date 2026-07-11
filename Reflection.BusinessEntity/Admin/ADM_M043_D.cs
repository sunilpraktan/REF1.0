using System;

namespace Reflection.BusinessEntity
{
    public class ADM_M043_D : ObjectBase
    {
        private string _id;

        public string id
        {
            get { return _id; }
            set {
                if (_id != value)
                { _id = value;
                    RaisePropertyChanged("id");
                }
            }
        }

        private string _doc_type;

        public string doc_type
        {
            get { return _doc_type; }
            set {
                if (_doc_type != value)
                {
                    _doc_type = value;
                    RaisePropertyChanged("doc_type");
                }
            }
        }

        private string _doc_no;
       public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value;
                    RaisePropertyChanged("doc_no");
                }
            }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_cat = value;
                    RaisePropertyChanged("doc_cat");
                }
            }
        }

        private string _workflow_id;
         public string workflow_id
        {
            get { return _workflow_id; }
            set
            {
                _workflow_id = value;
                RaisePropertyChanged("workflow_id");
            }
        }

         private string _approver_id;
         public string approver_id
         {
             get { return _approver_id; }
             set
             {
                 _approver_id = value;
                 RaisePropertyChanged("approver_id");
             }
         }

        private string _UserId;
        public string UserId
        {
            get { return _UserId; }
            set
            {
                _UserId = value;
                RaisePropertyChanged("UserId");
            }
        }

        private string _authority;
         public string authority
        {
            get { return _authority; }
            set
            {
                _authority = value;
                RaisePropertyChanged("authority");
            }
        }
        private string _appro_status;
        public string appro_status
        {
            get { return _appro_status; }
            set
            {
                _appro_status = value;
                RaisePropertyChanged("appro_status");
            }
        }

        private Nullable<System.DateTime> _appro_date;
         public Nullable<System.DateTime> appro_date
        {
             get { return _appro_date; }
             set
             {
                 _appro_date = value;
                 RaisePropertyChanged("appro_date");
             }
         }
       

         private string _read_status;
         public string read_status
         {
             get { return _read_status; }
             set
             {
                 _read_status = value;
                 RaisePropertyChanged("read_status");
             }
         }
        

         private Nullable<System.DateTime> _read_date;
         public Nullable<System.DateTime> read_date
         {
             get { return _read_date; }
             set
             {
                 _read_date = value;
                 RaisePropertyChanged("read_date");
             }
         }
         private string _remarks;
         public string remarks
         {
             get { return _remarks; }
             set
             {
                 _remarks = value;
                 RaisePropertyChanged("remarks");
             }
         }

         private string _ref_id;
         public string ref_id
         {
             get { return _ref_id; }
             set
             {
                 _ref_id = value;
                 RaisePropertyChanged("ref_id");
             }
         }

         private string _forward;
         public string forward
         {
             get { return _forward; }
             set
             {
                 _forward = value;
                 RaisePropertyChanged("forward");
             }
         }
         private int _level_no;
         public int level_no 
         {
             get { return _level_no; }
             set
             {
                 _level_no = value;
                 RaisePropertyChanged("level_no");
             }
         }

         private string _creator;

         public string creator
         {
             get { return _creator; }
             set { _creator = value;
             RaisePropertyChanged("creator");
             }
         }

        private Nullable<System.DateTime> _create_date;
        public Nullable<System.DateTime> create_date
        {
            get { return _create_date; }
            set
            {
                _create_date = value;
                RaisePropertyChanged("create_date");
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
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
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
        private string _note_subject;
        public string note_subject
        {
            get { return _note_subject; }
            set
            {
                if (_note_subject != value)
                {
                    _note_subject = value;
                    RaisePropertyChanged("note_subject");
                }
            }
        }
        private string _note_messagebody;
        public string note_messagebody
        {
            get { return _note_messagebody; }
            set
            {
                if (_note_messagebody != value)
                {
                    _note_messagebody = value;
                    RaisePropertyChanged("note_messagebody");
                }
            }
        }
        private string _approvar_remark;
        public string approvar_remark
        {
            get { return _approvar_remark; }
            set
            {
                if (_approvar_remark != value)
                {
                    _approvar_remark = value;
                    RaisePropertyChanged("approvar_remark");
                }
            }
        }
        private string _sender;
        public string sender
        {
            get { return _sender; }
            set
            {
                if (_sender != value)
                {
                    _sender = value;
                    RaisePropertyChanged("sender");
                }
            }
        }
        private string _record_src;
        public string record_src
        {
            get { return _record_src; }
            set
            {
                if (_record_src != value)
                {
                    _record_src = value;
                    RaisePropertyChanged("record_src");
                }
            }
        }
        private string _doc_info;
        public string doc_info
        {
            get { return _doc_info; }
            set
            {
                if (_doc_info != value)
                {
                    _doc_info = value;
                    RaisePropertyChanged("doc_info");
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
                    _comp_code = value;
                    RaisePropertyChanged("comp_code");
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

        private string _approvar_name;
        public string approvar_name
        {
            get { return _approvar_name; }
            set
            {
                if (_approvar_name != value)
                {
                    _approvar_name = value;
                    RaisePropertyChanged("approvar_name");
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
                    _dept_code = value;
                    RaisePropertyChanged("dept_code");
                }
            }
        }

        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set
            {
                if (_t_display != value)
                {
                    _t_display = value;
                    RaisePropertyChanged("t_display");
                }
            }
        }

        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set { _location_id = value; RaisePropertyChanged("location_id"); }
        }

        private string _org_code;
        public string org_code
        {
            get { return _org_code; }
            set { _org_code = value; RaisePropertyChanged("org_code"); }
        }

    }
}
