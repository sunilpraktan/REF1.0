using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M007 : ObjectBase
    {            
        private string _wi_code;
        public string wi_code
        {
            get { return _wi_code; }
            set
            {
                _wi_code = value; RaisePropertyChanged("wi_code");
            }
        }

        private string _wi_desc;
        public string wi_desc
        {
            get { return _wi_desc; }
            set
            {
                _wi_desc = value; RaisePropertyChanged("wi_desc");
            }
        }
        private string _wi_no;
        public string wi_no
        {
            get { return _wi_no; }
            set
            {
                _wi_no = value; RaisePropertyChanged("wi_no");
            }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value; RaisePropertyChanged("active");
            }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                _t_status = value; RaisePropertyChanged("t_status");
            }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value; RaisePropertyChanged("add_by");
            }
        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value; RaisePropertyChanged("add_date");
            }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value; RaisePropertyChanged("editby");
            }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value; RaisePropertyChanged("edit_date");
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value; RaisePropertyChanged("location_Id");
            }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value; RaisePropertyChanged("comp_code");
            }
        }
      
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                _lang_key = value; RaisePropertyChanged("lang_key");
            }
        }
        
        public string XmlDataDocument_FlipGrid { get; set; }       
    }
    public class MultipleContext_QMS_M007
    {
        public List<QMS_M007> MasterEntity { get; set; }
        public List<QMS_M007Flip> FlipGridData { get; set; }
        public List<COM_T003> Attachment { get; set; }
    }
}
