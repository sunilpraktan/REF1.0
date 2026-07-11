using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.ProjectManagement
{
    public class PRO_M005 : ObjectBase
    {

        private string _point_id;
        public string point_id
        {
            get { return _point_id; }
            set
            {
                if (_point_id != value)
                {
                    _point_id = value;
                    RaisePropertyChanged("point_id");
                }
            }
        }
              

        private string _point_description;
        public string point_description
        {
            get { return _point_description; }
            set
            {
                if (_point_description != value)
                {
                    _point_description = value;
                    RaisePropertyChanged("point_description");
                }
            }
        }
              

        private bool _active;
        public bool active
        {
            get { return _active; }
            set
            {
                if (_active = value)
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
             

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value;
                    RaisePropertyChanged("location_Id");
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
        

        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public class MultipleContext_PRO_M005
    {
        public List<PRO_M005> ProjectCheckListList { get; set; }
        //public List<COM_T003> Attachment { get; set; }
    }
}
