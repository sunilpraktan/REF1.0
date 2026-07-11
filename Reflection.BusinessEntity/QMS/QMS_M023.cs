using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M023 : ObjectBase
    {
    
        public static event EventHandler ModelEntityUpdated = delegate { };

       

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }
        private int _qualification_id;
        public int qualification_id
        {
            get { return _qualification_id; }
            set
            {
                _qualification_id = value;
                RaisePropertyChanged("qualification_id");
            }
        }
        private string _descriptn_short;
       [Required(ErrorMessage = "Field 'Method Name' is required.")]       
        public string descriptn_short
        {
            get { return _descriptn_short; }
            set
            {
                _descriptn_short = value;
                RaisePropertyChanged("descriptn_short", ModelEntityUpdated);
            }
        }
        private string _descriptn_long;
        public string descriptn_long
        {
            get { return _descriptn_long; }
            set
            {
                _descriptn_long = value;
                RaisePropertyChanged("descriptn_long");
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
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
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
        private string _qualification;       
        public string qualification
        {
            get { return _qualification; }
            set
            {
                _qualification = value;
                RaisePropertyChanged("qualification");
            }
        }       
    }
    public class MultipleContext_QMS_M023
    {
        public List<QMS_M023> Inspection_method { get; set; }//Inspection_method
        public List<QMS_M023_PopUp> Inspector_Qualification { get; set; }//Inspector_Qualification 

    }
    public class QMS_M023_PopUp
    {
        public int id { get; set; }

        [DisplayName("Qulification Name")]
        public string qualification { get; set; }

    }
}
