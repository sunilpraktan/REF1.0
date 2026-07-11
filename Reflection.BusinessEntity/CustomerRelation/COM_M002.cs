namespace Reflection.BusinessEntity
{
    public class COM_M002 : ObjectBase
    {
        private string _alert_id ;
        public string alert_id
        {
            get { return _alert_id; }
            set
            {
                if (_alert_id!= value)
                {
                    _alert_id = value; RaisePropertyChanged("alert_id");
                }
            }
        }

        
        private string _alert_name;
        public string alert_name
        {
            get { return _alert_name; }
            set
            {
                if (_alert_name != value)
                {
                    _alert_name = value; RaisePropertyChanged("alert_name");
                }
            }
        }

        private string _trigger_point;
        public string trigger_point
        {
            get { return _trigger_point; }
            set
            {
                if (_trigger_point != value)
                {
                    _trigger_point = value; RaisePropertyChanged("trigger_point");
                }
            }
        }

        private string _description;
        public string description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value; RaisePropertyChanged("description");
                }
            }
        }

        private string _alert_type;
        public string alert_type
        {
            get { return _alert_type; }
            set
            {
                if (_alert_type != value)
                {
                    _alert_type = value; RaisePropertyChanged("alert_type");
                }
            }
        }

        private string _trigger_from;
        public string trigger_from
        {
            get { return _trigger_from; }
            set
            {
                if (_trigger_from != value)
                {
                    _trigger_from = value; RaisePropertyChanged("trigger_from");
                }
            }
        }

        private string _subject;
        public string subject
        {
            get { return _subject; }
            set
            {
                if (_subject != value)
                {
                    _subject = value; RaisePropertyChanged("subject");
                }
            }
        }

        private string _msg_body;
        public string msg_body
        {
            get { return _msg_body; }
            set
            {
                if (_msg_body != value)
                {
                    _msg_body = value; RaisePropertyChanged("msg_body");
                }
            }
        }

        private string _doc_req;
        public string doc_req
        {
            get { return _doc_req; }
            set
            {
                if (_doc_req != value)
                {
                    _doc_req = value; RaisePropertyChanged("doc_req");
                }
            }
        }
    }
  public class COM_M002_A : ObjectBase
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

        private string _alert_id;
        public string alert_id
        {
            get { return _alert_id; }
            set
            {
                if (_alert_id != value)
                {
                    _alert_id = value; RaisePropertyChanged("alert_id");
                }
            }
        }

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

        private string _user_type;
        public string user_type
        {
            get { return _user_type; }
            set
            {
                if (_user_type != value)
                {
                    _user_type = value; RaisePropertyChanged("user_type");
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
                    _EmpId = value; RaisePropertyChanged("EmpId");
                }
            }
        }

        private string _person_name;
        public string person_name
        {
            get { return _person_name; }
            set
            {
                if (_person_name != value)
                {
                    _person_name = value; RaisePropertyChanged("person_name");
                }
            }
        }

        private string _user_id;
        public string user_id
        {
            get { return _user_id; }
            set
            {
                if (_user_id!= value)
                {
                    _user_id = value; RaisePropertyChanged("user_id");
                }
            }
        }

        private string _to_mail_id;
        public string to_mail_id
        {
            get { return _to_mail_id; }
            set
            {
                if (_to_mail_id != value)
                {
                    _to_mail_id = value; RaisePropertyChanged("to_mail_id");
                }
            }
        }

        private string _cc_mail_id;
        public string cc_mail_id
        {
            get { return _cc_mail_id; }
            set
            {
                if (_cc_mail_id != value)
                {
                    _cc_mail_id = value; RaisePropertyChanged("cc_mail_id");
                }
            }
        }

        private string _bcc_mail_id;
        public string bcc_mail_id
        {
            get { return _bcc_mail_id; }
            set
            {
                if (_bcc_mail_id != value)
                {
                    _bcc_mail_id = value; RaisePropertyChanged("bcc_mail_id");
                }
            }
        }

        private string _trigger_point;
        public string trigger_point
        {
            get { return _trigger_point; }
            set
            {
                if (_trigger_point != value)
                {
                    _trigger_point = value; RaisePropertyChanged("trigger_point");
                }
            }
        }

        private string _alert_name;
        public string alert_name
        {
            get { return _alert_name; }
            set
            {
                if (_alert_name != value)
                {
                    _alert_name = value; RaisePropertyChanged("alert_name");
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
    }
  public class NotificationData : ObjectBase
    {
        private string _alert_id;
        public string alert_id
        {
            get { return _alert_id; }
            set
            {
                if (_alert_id != value)
                {
                    _alert_id = value; RaisePropertyChanged("alert_id");
                }
            }
        }

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

        private string _description;
        public string description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value; RaisePropertyChanged("description");
                }
            }
        }

        private string _alert_type;
        public string alert_type
        {
            get { return _alert_type; }
            set
            {
                if (_alert_type != value)
                {
                    _alert_type = value; RaisePropertyChanged("alert_type");
                }
            }
        }

        private string _trigger_from;
        public string trigger_from
        {
            get { return _trigger_from; }
            set
            {
                if (_trigger_from != value)
                {
                    _trigger_from = value; RaisePropertyChanged("trigger_from");
                }
            }
        }

        private string _subject;
        public string subject
        {
            get { return _subject; }
            set
            {
                if (_subject != value)
                {
                    _subject = value; RaisePropertyChanged("subject");
                }
            }
        }

        private string _msg_body;
        public string msg_body
        {
            get { return _msg_body; }
            set
            {
                if (_msg_body != value)
                {
                    _msg_body = value; RaisePropertyChanged("msg_body");
                }
            }
        }

        private string _doc_req;
        public string doc_req
        {
            get { return _doc_req; }
            set
            {
                if (_doc_req != value)
                {
                    _doc_req = value; RaisePropertyChanged("doc_req");
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
                    _user_type = value; RaisePropertyChanged("user_type");
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
                    _EmpId = value; RaisePropertyChanged("EmpId");
                }
            }
        }

        private string _person_name;
        public string person_name
        {
            get { return _person_name; }
            set
            {
                if (_person_name != value)
                {
                    _person_name = value; RaisePropertyChanged("person_name");
                }
            }
        }

        private string _user_id;
        public string user_id
        {
            get { return _user_id; }
            set
            {
                if (_user_id != value)
                {
                    _user_id = value; RaisePropertyChanged("user_id");
                }
            }
        }

        private string _to_mail_id;
        public string to_mail_id
        {
            get { return _to_mail_id; }
            set
            {
                if (_to_mail_id != value)
                {
                    _to_mail_id = value; RaisePropertyChanged("to_mail_id");
                }
            }
        }

        private string _cc_mail_id;
        public string cc_mail_id
        {
            get { return _cc_mail_id; }
            set
            {
                if (_cc_mail_id != value)
                {
                    _cc_mail_id = value; RaisePropertyChanged("cc_mail_id");
                }
            }
        }

        private string _bcc_mail_id;
        public string bcc_mail_id
        {
            get { return _bcc_mail_id; }
            set
            {
                if (_bcc_mail_id != value)
                {
                    _bcc_mail_id = value; RaisePropertyChanged("bcc_mail_id");
                }
            }
        }

        private string _trigger_point;
        public string trigger_point
        {
            get { return _trigger_point; }
            set
            {
                if (_trigger_point != value)
                {
                    _trigger_point = value; RaisePropertyChanged("trigger_point");
                }
            }
        }

        private string _alert_name;
        public string alert_name
        {
            get { return _alert_name; }
            set
            {
                if (_alert_name!= value)
                {
                    _alert_name = value; RaisePropertyChanged("alert_name");
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

        private string _type;
        public string type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value; RaisePropertyChanged("type");
                }
            }
        }

        private string _Authority;
        public string Authority
        {
            get { return _Authority; }
            set
            {
                if (_Authority != value)
                {
                    _Authority = value; RaisePropertyChanged("Authority");
                }
            }
        }

        private string _EmpName;
        public string EmpName
        {
            get { return _EmpName; }
            set
            {
                if (_EmpName != value)
                {
                    _EmpName = value; RaisePropertyChanged("EmpName");
                }
            }
        }
    }
 
}
