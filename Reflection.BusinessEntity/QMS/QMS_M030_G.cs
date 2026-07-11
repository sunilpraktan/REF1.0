using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M030_G : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _insp_method;
        public string insp_method
        {
            get { return _insp_method; }
            set
            {
                _insp_method = value;
                RaisePropertyChanged("insp_method");
            }
        }

        private string _version_no;
        public string version_no
        {
            get { return _version_no; }
            set
            {
                _version_no = value;
                RaisePropertyChanged("version_no");
            }
        }

        private Nullable<System.DateTime> _valid_from;
        public Nullable<System.DateTime> valid_from
        {
            get { return _valid_from; }
            set
            {
                _valid_from = value;
                RaisePropertyChanged("valid_from");
            }
        }

        private string _inspector_qualification;
        public string inspector_qualification
        {
            get { return _inspector_qualification; }
            set
            {
                _inspector_qualification = value;
                RaisePropertyChanged("inspector_qualification");
            }
        }

        private string _method_desc;
        public string method_desc
        {
            get { return _method_desc; }
            set
            {
                _method_desc = value;
                RaisePropertyChanged("method_desc");
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
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

        private System.DateTime _add_date;
        public System.DateTime add_date
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

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                _lang_key = value;
                RaisePropertyChanged("lang_key");
            }
        }

        public string XmlDataDocument_QMS_M030_G_Flip { get; set; }
        //Scalar
        private string _qualiDesc { get; set; }

        public string qualiDesc
        {
            get { return _qualiDesc; }
            set
            {
                _qualiDesc = value;
                RaisePropertyChanged("qualiDesc");
            }
        }
    }

    public class MultipleContext_QMS_M030_G
    {
        public List<QMS_M030_G_Flip> BackFlipData { get; set; }
        public List<QMS_M030_G> MasterEntity { get; set; }
        public List<QMS_M022_P> QualificationMaster { get; set; }
        public List<COM_T003> Attachment { get; set; }

    }
}
