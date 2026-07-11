using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public class ZADM_M014 : ObjectBase,IDataErrorInfo
    {
        private int _writingtest_id;
        private string _tip_type;
        private string _writspeed;
        private string _paperfeed;
        private Nullable<int> _machine_id;
        private string _effwt;
        private string _arialrotation;
        private string _papertype;
        private string _remarks;
        private string _angle;
        private string _weight;
        private string _add_by;
        private Nullable<System.DateTime> _add_date;
        private string _edit_by;
        private Nullable<System.DateTime> _edit_date;
        private string _Machine;

        public int writingtest_id
        {
            get { return _writingtest_id; }
            set
            {
                _writingtest_id = value;
                RaisePropertyChanged("writingtest_id");
            }
        }

        [Required(ErrorMessage = "Field 'Tip Type' is required.")]
        [DisplayName("Tip Type")]
        public string tip_type
        {
            get { return _tip_type; }
            set
            {
                _tip_type = value;
                RaisePropertyChanged("tip_type");
            }
        }

        public string writspeed
        {
            get { return _writspeed; }
            set
            {
                _writspeed = value;
                RaisePropertyChanged("writspeed");
            }
        }

        public string paperfeed
        {
            get { return _paperfeed; }
            set
            {
                _paperfeed = value;
                RaisePropertyChanged("paperfeed");
            }
        }

        public Nullable<int> machine_id
        {
            get { return _machine_id; }
            set
            {
                _machine_id = value;
                RaisePropertyChanged("machine_id");
            }
        }

        public string effwt
        {
            get { return _effwt; }
            set
            {
                _effwt = value;
                RaisePropertyChanged("effwt");
            }
        }

        public string arialrotation
        {
            get { return _arialrotation; }
            set
            {
                _arialrotation = value;
                RaisePropertyChanged("arialrotation");
            }
        }

        public string papertype
        {
            get { return _papertype; }
            set
            {
                _papertype = value;
                RaisePropertyChanged("papertype");
            }
        }

        public string remarks
        {
            get { return _remarks; }
            set
            {
                _remarks = value;
                RaisePropertyChanged("remarks");
            }
        }

        public string angle
        {
            get { return _angle; }
            set
            {
                _angle = value;
                RaisePropertyChanged("angle");
            }
        }
        public string weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                RaisePropertyChanged("weight");
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

        public string Machine
        {
            get { return _Machine; }
            set 
            {
                _Machine = value;
                RaisePropertyChanged("Machine");
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

    public class MultipleContext_ZADM_M014
    {
        public List<ZADM_M014> WritingTestMaster_1 { get; set; }   //Machine Master   
        public ObservableCollection<ZADM_M013_PopUp> MachineMaster_1 { get; set; }  //Machine Master  
    }
   
}
