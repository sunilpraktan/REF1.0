using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public class ZADM_M011 : ObjectBase , IDataErrorInfo
    {

        private int _machine_type_id;
        private string _machine_type;
        private string _remark;
        private string _add_by;
        private Nullable<System.DateTime> _add_date;
        private string _edit_by;
        private Nullable<System.DateTime> _edit_date;

        public int machine_type_id
        {
            get { return _machine_type_id; }
            set
            {
                _machine_type_id = value;
                RaisePropertyChanged("machine_type_id");
            }
        }

        [Required(ErrorMessage = "Field 'Machine Type' is required.")]
        [DisplayName("Machine Type")]
        public string machine_type
        {
            get { return _machine_type; }
            set
            {
                _machine_type = value;
                RaisePropertyChanged("machine_type");
            }
        }

        public string remark
        {
            get { return _remark; }
            set
            {
                _remark = value;
                RaisePropertyChanged("remark");
            }
        }

        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }

        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }

        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                _edit_by = value;
                RaisePropertyChanged("edit_by");
            }
        }

        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }

        string IDataErrorInfo.Error
        {
            get { throw new NotImplementedException(); }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }
    }
}
