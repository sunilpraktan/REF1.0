using System;
using System.Collections.Generic;


namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M022 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

       
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

        private string _description;
        public string description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("description");
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
        private string _abbreviation;
        public string abbreviation
        {
            get { return _abbreviation; }
            set
            {
                _abbreviation = value;
                RaisePropertyChanged("abbreviation");
            }

        }

        private string _EmpId;
        public string EmpId
        {
            get { return _EmpId; }
            set
            {
                _EmpId = value;
                RaisePropertyChanged("EmpId");
            }

        }

        private string _qua_spe;
        public string qua_spe
        {
            get { return _qua_spe; }
            set
            {
                _qua_spe = value;
                RaisePropertyChanged("qua_spe");
            }

        }

        private Nullable<System.DateTime> _from_date;
        public Nullable<System.DateTime> from_date
        {
            get { return _from_date; }
            set
            {
                _from_date = value;
                RaisePropertyChanged("from_date");
            }

        }

        private Nullable<System.DateTime> _to_date;
        public Nullable<System.DateTime> to_date
        {
            get { return _to_date; }
            set
            {
                _to_date = value;
                RaisePropertyChanged("to_date");
            }

        }

        private string _institution;
        public string institution
        {
            get { return _institution; }
            set
            {
                _institution = value;
                RaisePropertyChanged("institution");
            }

        }

        private string _marks;
        public string marks
        {
            get { return _marks; }
            set
            {
                _marks = value;
                RaisePropertyChanged("marks");
            }

        }

        private string _qua_grade;
        public string qua_grade
        {
            get { return _qua_grade; }
            set
            {
                _qua_grade = value;
                RaisePropertyChanged("qua_grade");
            }

        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set
            {
                _remark = value;
                RaisePropertyChanged("remark");
            }

        }

        public string XmlDataDocument_QMS_M022_Flip { get; set; }
    }

    public class MultipleContext_QMS_M022
    {
        public List<QMS_M022_Flip> BackFlipData { get; set; }
        public List<QMS_M022> MasterEntity { get; set; }
    }
}
