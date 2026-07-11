using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public partial class ZADM_M004 : ObjectBase, IDataErrorInfo
    {
        private int _wire_type_id;
        public int wire_type_id
        {
            get { return _wire_type_id; }
            set
            {
                _wire_type_id = value;
                RaisePropertyChanged("wire_type_id");
            }
        }
        private string _wire_type;
        [Required(ErrorMessage = "Field 'Wire Type' is required.")]
        public string wire_type
        {
            get { return _wire_type; }
            set
            {
                _wire_type = value;
                RaisePropertyChanged("wire_type");
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
        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                _edit_by = value;
                RaisePropertyChanged("edit_by");
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
