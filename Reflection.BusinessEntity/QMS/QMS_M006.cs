using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M006 : ObjectBase
    {
        private string _tp_code;
        public string tp_code
        { 
         get { return _tp_code; }
         set { _tp_code = value; RaisePropertyChanged("tp_code"); }
        }

        private string _tp_desc;
        public string tp_desc
        { 
            get { return _tp_desc; }
            set { _tp_desc = value; RaisePropertyChanged("tp_desc"); }
        }

        private string _tp_no;
        public string tp_no
        {
            get { return _tp_no; }
            set { _tp_no = value; RaisePropertyChanged("tp_no"); }
        }

        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }

        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }
        
       
        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public class MultipleContext_QMS_M006
    {
        public List<QMS_M006> MasterEntity { get; set; }
        public List<QMS_M006Flip> FlipGridData { get; set; }
        public List<COM_T003> Attachment { get; set; }
    }
}
