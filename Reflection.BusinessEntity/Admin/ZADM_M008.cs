using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class ZADM_M008 :ObjectBase
    {
        private int _tot_len_id;
        private string _total_len;
        private string _total_len_tolce_plus;
        private string _total_len_tolce_mins;
        private string _details;
        private string _add_by;
        private Nullable<System.DateTime> _add_date;
        private string _edit_by;
        private Nullable<System.DateTime> _edit_date;

        public int tot_len_id
        {

            get { return _tot_len_id; }
            set
            {
                _tot_len_id = value;
                RaisePropertyChanged("tot_len_id");
            }
        }
        public string total_len
        {
            get { return _total_len; }
            set
            {
                _total_len = value;
                RaisePropertyChanged("total_len");
            }
        }
        public string total_len_tolce_plus
        {
            get { return _total_len_tolce_plus; }
            set
            {
                _total_len_tolce_plus = value;
                RaisePropertyChanged("total_len_tolce_plus");
            }
        }
        public string total_len_tolce_mins
        {
            get { return _total_len_tolce_mins; }
            set
            {
                _total_len_tolce_mins = value;
                RaisePropertyChanged("total_len_tolce_mins");
            }
        }

        public string details
        {
            get { return _details; }
            set
            {
                _details = value;
                RaisePropertyChanged("details");
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
        public string XmlDataDocument_FlipGrid { get; set; }

        //string IDataErrorInfo.Error
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //string IDataErrorInfo.this[string columnName]
        //{
        //    get { throw new NotImplementedException(); }
        //}
    }

    public class MultipleContext_ZADM_M008
    {
        public List<ZADM_M008> MasterEntity { get; set; }
        public List<ZADM_M008Flip> FlipGridData { get; set; }
    }
}
