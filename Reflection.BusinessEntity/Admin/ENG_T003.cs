using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Admin
{
    public class ENG_T003:ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
              _id = value;
                 RaisePropertyChanged("id");
               }
            }

        private string _spec_para_code;
        public string spec_para_code
        {
            get
            {
                return _spec_para_code;
            }
            set
            {
                _spec_para_code = value;
                RaisePropertyChanged("spec_para_code");
            }
        }



        private string _spec_type_code;
        public string spec_type_code
        {
            get
            {
                return _spec_type_code;
            }
            set
            {
                _spec_type_code = value;
                RaisePropertyChanged("spec_type_code");
            }
        }

        

        private string _para_details;
        public string para_details
        {

            get
            {
                return _para_details;
            }
            set
            {
                _para_details = value;
                RaisePropertyChanged("para_details");
            }
        }

        private string _parameter;
        public string parameter
        {
            get
            {
                return _parameter;
            }
                set
            {
                _parameter = value;
                RaisePropertyChanged("parameter");
            }
        }
        
        public string _posting_period;
        public string posting_period
        { get
            {
                return _posting_period;
            }
            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period");
            }
        }

        private string _fin_year;
        public string fin_year
        {
            get
            {
                return _fin_year;
            }
             set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }
        
        private DateTime _add_date;
        public DateTime add_date
        {
            get
            {
                return _add_date;
            }
             set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get
            {
                return _location_Id;
            }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get
            {
                return _comp_code;
            }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }


        private string _add_by; 
        public string add_by
        {
            get
            {
                return _add_by;
            }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }

        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get
            {
                return _edit_date;
            }
                 set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
          }

        private string _editby;
        public string editby
        {
            get
            {
                return _editby;
            }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }

        private bool? _active;
        public bool? active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
       

        private string _t_status;
        public string t_status
        {
            get
            {
                return _t_status;
            }
            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }
        private string _type;
        public string type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                RaisePropertyChanged("type");
            }
        }

        public string XmlDataDocument_ENG_T003FLIP { get; set; }

    }

    public class MultipleContext_ENG_T003
    {
        public List<ENG_T003Flip> DocumentDataFlipGrid { get; set; }//Back Flip data
        public List<ENG_T003> MasterList { get; set; }//Master list
        public List<ENG_T003> MasterEntity { get; set; }

    }


    public class ENG_T003Flip
    {
        public int id { get; set; }
        public string spec_para_code { get; set; }
        public string parameter { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
    }
}
