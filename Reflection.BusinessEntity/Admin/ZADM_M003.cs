using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public class ZADM_M003 : ObjectBase, IDataErrorInfo
    {
        private int _wire_size_id;
        public int wire_size_id
        {
            get { return _wire_size_id; }
            set
            {
                _wire_size_id = value;
                RaisePropertyChanged("wire_size_id");
            }
        }
        private decimal _wire_size;
        [Required(ErrorMessage = "Field 'Wire Size' is required.")]
        public decimal wire_size
        {
            get { return _wire_size; }
            set
            {
                _wire_size = value;
                RaisePropertyChanged("wire_size");
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
