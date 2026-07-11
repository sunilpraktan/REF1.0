using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Reflection.BusinessEntity
{
    public class MultipleContext_Attachments : ObjectBase
    {
        public List<COM_T003> Attachments { get; set; }
    }
    

    [Serializable]
    public class FileObject : INotifyPropertyChanged
    {
        #region Private Fields

        private string _filePath;
        private int _index;
        private bool _isUploaded;
        private string _newFileName;

        #endregion

        #region Properties
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                    OnPropertyChanged("FilePath");
                }
            }
        }

        public int Index
        {
            get { return _index; }
            set
            {
                if (_index != value)
                {
                    _index = value;
                    OnPropertyChanged("Index");
                }
            }
        }

        public bool IsUploaded
        {
            get { return _isUploaded; }
            set
            {
                if (_isUploaded != value)
                {
                    _isUploaded = value;
                    OnPropertyChanged("IsUploaded");
                }
            }
        }

        public string NewFileName
        {
            get { return _newFileName; }
            set
            {
                if (_newFileName != value)
                {
                    _newFileName = value;
                    OnPropertyChanged("NewFileName");
                }
            }
        }

        #endregion

        public FileObject()
        { }

        public FileObject(int index, string filePath)
        {
            _filePath = filePath;
            _index = index;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public class COM_T003 : INotifyPropertyChanged
    {
        private int? _id;
        public int? id
        {
            get { return _id; }
            set
            { _id = value; RaisePropertyChanged("id"); }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }

        private string _description;
        public string description
        {
            get { return _description; }
            set
            { _description = value; RaisePropertyChanged("description"); }
        }

        private string _file_name;
        public string file_name
        {
            get { return _file_name; }
            set
            { _file_name = value; RaisePropertyChanged("file_name"); }
        }

        private string _url;
        public string url
        {
            get { return _url; }
            set
            { _url = value; RaisePropertyChanged("url"); }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            { _doc_type = value; RaisePropertyChanged("doc_type"); }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }

        private string _resource_name;
        public string resource_name
        {
            get { return _resource_name; }
            set
            { _resource_name = value; RaisePropertyChanged("resource_name"); }
        }

        private string _file_type;
        public string file_type
        {
            get { return _file_type; }
            set
            { _file_type = value; RaisePropertyChanged("file_type"); }
        }

        private Nullable<int> _resource_id;
        public Nullable<int> resource_id
        {
            get { return _resource_id; }
            set
            { _resource_id = value; RaisePropertyChanged("resource_id"); }
        }

        private string _file_size;
        public string file_size
        {
            get { return _file_size; }
            set
            { _file_size = value; RaisePropertyChanged("file_size"); }
        }

        private byte[] _file_data;
        public byte[] file_data
        {
            get { return _file_data; }
            set
            { _file_data = value; RaisePropertyChanged("file_data"); }
        }

        private string _stored_file_name;
        public string stored_file_name
        {
            get { return _stored_file_name; }
            set
            { _stored_file_name = value; RaisePropertyChanged("stored_file_name"); }
        }

        private string _f_name;
        public string f_name
        {
            get { return _f_name; }
            set
            { _f_name = value; RaisePropertyChanged("f_name"); }
        }

        private string _containt_type;
        public string containt_type
        {
            get { return _containt_type; }
            set
            { _containt_type = value; RaisePropertyChanged("containt_type"); }
        }

        private Nullable<int> _partner_id;
        public Nullable<int> partner_id
        {
            get { return _partner_id; }
            set
            { _partner_id = value; RaisePropertyChanged("partner_id"); }
        }

        private string _UserId;
        public string UserId
        {
            get { return _UserId; }
            set
            { _UserId = value; RaisePropertyChanged("UserId"); }
        }

        private Nullable<int> _parent_id;
        public Nullable<int> parent_id
        {
            get { return _parent_id; }
            set
            { _parent_id = value; RaisePropertyChanged("parent_id"); }
        }

        private string _file_index;
        public string file_index
        {
            get { return _file_index; }
            set
            { _file_index = value; RaisePropertyChanged("file_index"); }
        }

        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            { _add_date = value; RaisePropertyChanged("add_date"); }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            { _editby = value; RaisePropertyChanged("editby"); }
        }
        private string _newFileName;
        public string NewFileName
        {
            get { return _newFileName; }
            set
            { _newFileName = value; RaisePropertyChanged("NewFileName"); }
        }
        private bool _isUploaded;
        public bool IsUploaded
        {
            get { return _isUploaded; }
            set
            { _isUploaded = value; RaisePropertyChanged("IsUploaded"); }
        }

        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                    RaisePropertyChanged("FilePath");
                }
            }
        }

        private int? _index;
        public int? Index
        {
            get { return _index; }
            set
            {
                if (_index != value)
                {
                    _index = value;
                    RaisePropertyChanged("Index");
                }
            }
        }
        private string _client;
        public string client
        {
            get { return _client; }
            set
            {
                if (_client != value)
                {
                    _client = value;
                    RaisePropertyChanged("client");
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
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public class COM_T002_B
    {
        public int id { get; set; }
        public string doc_type { get; set; }
        public Nullable<int> doc_id { get; set; }
        public Nullable<int> follower_id { get; set; }
        public string follower_type { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string edit_by { get; set; }
    }
    
    
    public class COM_T002_A_Message_Data
    {
        public int id { get; set; }
        public int from_id { get; set; }
        public int to_id { get; set; }
        public string subject { get; set; }
        public string msg_body { get; set; }
        public string doc_type { get; set; }
        public DateTime doc_name { get; set; }
        public int msg_date { get; set; }
        public int msg_id { get; set; }
        public int parent_id { get; set; }
        public int doc_id { get; set; }
        public int author_id { get; set; }
        public byte[] photo { get; set; }
    }
    
}
