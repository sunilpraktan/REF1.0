using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.QMS
{ 
    public class QMS_M010 : ObjectBase
    {
         
        private string _tr_code;
        public string tr_code
        {
            get { return _tr_code; }
            set { _tr_code = value; RaisePropertyChanged("tr_code"); }
        }

        private string _tr_name;
        public string tr_name
        {
            get { return _tr_name; }
            set { _tr_name = value; RaisePropertyChanged("tr_name"); }
        }

        private string _tr_desc;
        public string tr_desc
        {
            get { return _tr_desc; }
            set { _tr_desc = value; RaisePropertyChanged("tr_desc"); }
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

        private string _uncertainty;
        public string uncertainty
        {
            get { return _uncertainty; }
            set { _uncertainty = value; RaisePropertyChanged("uncertainty"); }
        }

        public string XmlDataDocument_QMS_M010FLIP { get; set; }
    }

    public class MultipleContext_QMS_M010
    {
        public List<QMS_M010> MasterEntity { get; set; }
        public List<QMS_M010> FlipGridData { get; set; }
        public List<COM_T003> Attachment { get; set; }
    }
}
