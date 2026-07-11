using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.ProjectManagement
{
    public class PRO_M003 : ObjectBase
    {
        private string _phase_id;
        public string phase_id
        {
            get { return _phase_id; }
            set {
                if (_phase_id != value)
                {
                    _phase_id = value; RaisePropertyChanged("phase_id");
                }
            }
        }
             

        private Nullable<bool> _fold;
        public Nullable<bool> fold
        {
            get { return _fold; }
            set {
                if (_fold != value)
                {
                    _fold = value; RaisePropertyChanged("fold");
                }
            }
        }
                


        private Nullable<bool> _case_default;
        public Nullable<bool> case_default
        {
            get { return _case_default; }
            set {
                if (_case_default != value)
                {
                    _case_default = value; RaisePropertyChanged("case_default");
                }
            }
        }
            

        private string _phase_name;
        public string phase_name
        {
            get { return _phase_name; }
            set {
                if (_phase_name != value)
                {
                    _phase_name = value; RaisePropertyChanged("phase_name");
                }
            }
        }
               

        private string _description;
        public string description
        {
            get { return _description; }
            set {
                if (_description != value)
                {
                    _description = value; RaisePropertyChanged("description");
                }
            }
        }
               


        private Nullable<int> _sequence;
        public Nullable<int> sequence
        {
            get { return _sequence; }
            set {
                if (_sequence != value)
                {
                    _sequence = value; RaisePropertyChanged("sequence");
                }
            }
        }
            

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }
              

        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");
                }
            }
        }
               

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set {
                if (_editby != value)
                {
                    _editby = value; RaisePropertyChanged("editby");
                }
            }
        }
               

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");
                }
            }
        }
               

        private bool _active;
        public bool active
        {
            get { return _active; }
            set {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
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

    public class MultipleContext_PRO_M003
    {
        public List<PRO_M003> PhaseList { get; set; }
        //public List<COM_T003> Attachment { get; set; }
    }
}
