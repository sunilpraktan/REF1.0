using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.ProjectManagement
{
    public class PRO_M004 : ObjectBase
    {
      
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
               
   
        private string _role_name;
        public string role_name
        {
            get { return _role_name; }
            set
            {
                if (_role_name != value)
                {
                    _role_name = value;
                    RaisePropertyChanged("role_name");
                }
            }
        }
               
      
        private bool _active;
        public bool active
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
    public class MultipleContext_PRO_M004
    {
        public List<PRO_M004> ProjectRoleList { get; set; }
        //public List<COM_T003> Attachment { get; set; }
    }
}
