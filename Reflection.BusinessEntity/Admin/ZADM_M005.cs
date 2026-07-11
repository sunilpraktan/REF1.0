using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public class ZADM_M005 : ObjectBase, IDataErrorInfo
    {

        private int _usedin_id;
        private string _usedin;
        private string _add_by;
        private Nullable<System.DateTime> _add_date;
        private string _edit_by;
        private Nullable<System.DateTime> _edit_date;

        public int usedin_id
        {
            get { return _usedin_id; }
            set 
            {
                _usedin_id = value;
                RaisePropertyChanged("usedin_id");
            }
        }

        [Required(ErrorMessage = "Field 'Used In Machine Name' is required.")]
        [DisplayName("Used In Machine Name")]
        public string usedin
        {
            get { return _usedin; }
            set
            {
                _usedin = value;
                RaisePropertyChanged("usedin");
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
