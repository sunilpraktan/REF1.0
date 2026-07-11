using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity
{
    public class COM_T002
    {
    }
    public class COM_T002_A : ObjectBase
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
        private Nullable<int> _from_id;
        public Nullable<int> from_id
        {
            get { return _from_id; }
            set
            {
                if (_from_id != value)
                {
                    _from_id = value; RaisePropertyChanged("from_id");
                }
            }
        }
        private string _to_id;
        public string to_id
        {
            get { return _to_id; }
            set
            {
                if (_to_id != value)
                {
                    _to_id = value; RaisePropertyChanged("to_id");
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
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                if (_msg_body != value)
                {
                    _doc_type = value; RaisePropertyChanged("doc_type");
                }
            }
        }
        private string _doc_name;
        public string doc_name
        {
            get { return _doc_name; }
            set
            {
                if (_doc_name != value)
                { _doc_name = value; RaisePropertyChanged("doc_name"); }
            }
        }
        private Nullable<System.DateTime> _msg_date;
        public Nullable<System.DateTime> msg_date
        {
            get { return _msg_date; }
            set
            {
                if (_msg_date != value)
                {
                    _msg_date = value; RaisePropertyChanged("msg_date");
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
        private string _msg_id;
        public string msg_id
        {
            get { return _msg_id; }
            set
            {
                if (_msg_id != value)
                {
                    _msg_id = value; RaisePropertyChanged("msg_id");
                }
            }
        }
        private Nullable<int> _parent_id;
        public Nullable<int> parent_id
        {
            get { return _parent_id; }
            set
            {
                if (_parent_id != value)
                {
                    _parent_id = value; RaisePropertyChanged("parent_id");
                }
            }
        }
        private Nullable<int> _doc_id;
        public Nullable<int> doc_id
        {
            get { return _doc_id; }
            set
            {
                if (_doc_id != value)
                {
                    _doc_id = value; RaisePropertyChanged("doc_id");
                }
            }
        }
        private Nullable<int> _msg_type_id;
        public Nullable<int> msg_type_id
        {
            get { return _msg_type_id; }
            set
            {
                if (_msg_type_id != value)
                {
                    _msg_type_id = value; RaisePropertyChanged("msg_type_id");
                }
            }
        }
        private string _author_id;
        public string author_id
        {
            get { return _author_id; }
            set
            {
                if (_author_id != value)
                {
                    _author_id = value; RaisePropertyChanged("author_id");
                }
            }
        }
        private string _msg_category;
        public string msg_category
        {
            get { return _msg_category; }
            set
            {
                if (_msg_category != value)
                {
                    _msg_category = value; RaisePropertyChanged("msg_category");
                }
            }
        }
        private string _sender_email;
        public string sender_email
        {
            get { return _sender_email; }
            set
            {
                if (_sender_email != value)
                {
                    _sender_email = value; RaisePropertyChanged("sender_email");
                }
            }
        }
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                if (add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");
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
                    _add_by = value; RaisePropertyChanged("add_by");
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
                    _edit_date = value; RaisePropertyChanged("edit_date");
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
                    _edit_by = value; RaisePropertyChanged("edit_by");
                }
            }
        }
        //-----------------------------------
        private string _party_id;
        public string party_id
        {
            get { return _party_id; }
            set
            {
                if (_party_id != value)
                {
                    _party_id = value; RaisePropertyChanged("party_id");
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
        private byte[] _Photo;
        public byte[] Photo
        {
            get { return _Photo; }
            set
            {
                if (_Photo != value)
                {
                    _Photo = value; RaisePropertyChanged("Photo");
                }
            }
        }
    }
    public class COM_T002_A_PopUp : ObjectBase
    {//
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
        private int _author_id;
        public int author_id
        {
            get { return _author_id; }
            set
            {
                if (_author_id != value)
                {
                    _author_id = value; RaisePropertyChanged("author_id");
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
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }
        private Nullable<bool> _msg_read;
        public Nullable<bool> msg_read
        {
            get { return _msg_read; }
            set
            {
                if (_msg_read != value)
                {
                    _msg_read = value; RaisePropertyChanged("msg_read");
                }
            }
        }
        private Nullable<bool> _starred;
        public Nullable<bool> starred
        {
            get { return _starred; }
            set
            {
                if (_starred != value)
                {
                    _starred = value; RaisePropertyChanged("starred");
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
        private byte[] _Photo;
        public byte[] Photo
        {
            get { return _Photo; }
            set
            {
                if (_Photo != value)
                {
                    _Photo = value; RaisePropertyChanged("Photo");
                }
            }
        }
        private string _sent_to;
        public string sent_to
        {
            get { return _sent_to; }
            set
            {
                if (_sent_to != value)
                {
                    _sent_to = value; RaisePropertyChanged("sent_to");
                }
            }
        }
    }
    public class COM_T002_B_PopUp
    {
        public int id { get; set; }
        public Nullable<int> follower_id { get; set; }
        public string follower_type { get; set; }
        public string name { get; set; }
        public byte[] Photo { get; set; }
    }
    public class ADM_M024_PopUp_FollowerListToadd
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email_id { get; set; }
        public string type { get; set; }
        public Nullable<int> type_id { get; set; }
        public byte[] photo { get; set; }
    }
    public class COM_T002_B_Delete // COM_T002_B  COM_T002_C
    {
        public int follower_id { get; set; }
        public string follower_type { get; set; }
        public int doc_id { get; set; }
        public string doc_type { get; set; }
        public int add_by { get; set; }
        public int check { get; set; }     
    }  

    public class Multiple_Complex_COM_T002
    {
        public List<COM_T002_A> followersMessagesList { get; set; }
        public ObservableCollection<COM_T002_A_PopUp> documentMessagesList { get; set; }
        public ObservableCollection<COM_T002_B_PopUp> documentFollowersList { get; set; }
        public List<ADM_M024_PopUp_FollowerListToadd> FollowerListToadd { get; set; }
    }
    //-------------------------------
    public class Msg_LoadAll_Result : ObjectBase
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
        private string _msg_body;
        public string msg_body
        {
            get { return _msg_body; }
            set
            {
                if (_msg_body != value)
                { _msg_body = value; RaisePropertyChanged("msg_body"); }
            }
        }
        private int _author_id;
        public int author_id
        {
            get { return _author_id; }
            set
            {
                if (_author_id != value)
                {
                    _author_id = value; RaisePropertyChanged("author_id");
                }
            }
        }
        private int _parent_id;
        public int parent_id
        {
            get { return _parent_id; }
            set
            {
                if (_parent_id != value)
                { _parent_id = value; RaisePropertyChanged("parent_id"); }
            }
        }
        private string _msg_category;
        public string msg_category
        {
            get { return _msg_category; }
            set
            {
                if (_msg_category != value)
                {
                    _msg_category = value; RaisePropertyChanged("msg_category");
                }
            }
        }
        private string _sender_email;
        public string sender_email
        {
            get { return _sender_email; }
            set
            {
                if (_sender_email != value)
                {
                    _sender_email = value; RaisePropertyChanged("sender_email");
                }
            }
        }
        private Nullable<bool> _msg_read;
        public Nullable<bool> msg_read
        {
            get { return _msg_read; }
            set
            {
                if (_msg_read != value)
                {
                    _msg_read = value; RaisePropertyChanged("msg_read");
                }
            }
        }
        private Nullable<bool> _starred;
        public Nullable<bool> starred
        {
            get { return _starred; }
            set
            {
                if (_starred != value)
                { _starred = value; RaisePropertyChanged("starred"); }
            }
        }
        private string _follower_id;
        public string follower_id
        {
            get { return _follower_id; }
            set
            {
                if (_follower_id != value)
                {
                    _follower_id = value; RaisePropertyChanged("follower_id");
                }
            }
        }
        public byte[] _Photo;
        public byte[] Photo
        {
            get { return _Photo; }
            set
            {
                if (_Photo != value)
                {
                    _Photo = value; RaisePropertyChanged("Photo");
                }
            }
        }
        private string _check;
        public string check
        {
            get { return _check; }
            set
            {
                if (_check != value)
                {
                    _check = value; RaisePropertyChanged("check");
                }
            }
        }
        private string _sent_to;
        public string sent_to
        {
            get { return _sent_to; }
            set
            {
                if (_sent_to != value)
                {
                    _sent_to = value; RaisePropertyChanged("sent_to");
                }
            }
        }
        private string _sent_to_id;
        public string sent_to_id
        {
            get { return _sent_to_id; }
            set
            {
                if (_sent_to_id != value)
                {
                    _sent_to_id = value; RaisePropertyChanged("sent_to_id");
                }
            }
        }
        private int _doc_id;
        public int doc_id
        {
            get { return _doc_id; }
            set
            {
                if (_doc_id != value)
                {
                    _doc_id = value; RaisePropertyChanged("doc_id");
                }
            }
        }
        private string _doc_name;
        public string doc_name
        {
            get { return _doc_name; }
            set
            {
                if (_doc_name != value)
                {
                    _doc_name = value; RaisePropertyChanged("doc_name");
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
    }
    public class MultipleContext_Masseging
    {
        public ObservableCollection<Msg_LoadAll_Result> MessagesList { get; set; }
        public List<COM_T002_A> Composed_or_RplyMassege{ get; set; }     
        public List<ADM_M024_PopUp_FollowerListToadd> FollowerListToadd { get; set; }
        public string compose_or_reply { get; set; }     
       
    }
}
