using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public class ZADM_M007 : ObjectBase, IDataErrorInfo
    {
        private int _ild_id ;
        private string _ild_type;
        private string _ild;
        private string _tip_type;
        private Nullable<decimal> _min_val;
        private Nullable<decimal> _max_val;
        private Nullable<decimal> _avg_min;
        private string _desc;
        private Nullable<System.DateTime> _edit_date;
        private string _edit_by;
        private string _add_by;
        private Nullable<decimal> _avg_max;
        private string _show_ild;
        public int ild_id
        {
            get { return _ild_id; }
            set
            {
               
                {
                    _ild_id = value;

                    RaisePropertyChanged("ild_id");
                }
            }
        }


        [Required(ErrorMessage = "Field 'ILD' is required.")]
        [DisplayName("ILD")]
         
        public string ild 
        {
            get { return _ild; }
            set
            {
              
                {
                    _ild = value;
                    RaisePropertyChanged("ild");
                }

            }
        }
       
      
      
        public string ild_type
        {
            get { return _ild_type; }
            set
            {
             
                {
                    _ild_type = value;
                    RaisePropertyChanged("ild_type");
                }

            }
        }
        [Required(ErrorMessage = "Field 'Tip Type' is required.")]
        [DisplayName("Tip Type")]
        public string tip_type
        {
            get { return _tip_type; }
            set
            {
               
                {
                    _tip_type = value;
                    RaisePropertyChanged("tip_type");
                }

            }
        }
       

        public Nullable<decimal> min_val
        {
            get { return _min_val; }
            set
            {
               
                {
                    _min_val = value;
                    RaisePropertyChanged("min_val");
                }

            }
        }

        public Nullable<decimal> max_val
        {
            get { return _max_val; }
            set
            {
               
                {
                    _max_val = value;
                    RaisePropertyChanged("max_val");
                }

            }
        }

        public Nullable<decimal> avg_max
        {
            get { return _avg_max; }
            set
            {
              
                {
                    _avg_max = value;
                    RaisePropertyChanged("avg_max");
                }

            }
        }

        public Nullable<decimal> avg_min
        {
            get { return _avg_min; }
            set
            {
                {
                    _avg_min = value;
                    RaisePropertyChanged("avg_min");
                }

            }
        }
     
        public string desc
        {
            get { return _desc; }
            set
            {
              
                {
                    _desc = value;
                    RaisePropertyChanged("desc");
                }

            }
        }

        public string add_by
        {
            get { return _add_by; }
            set
            {
              
                {
                    _add_by = value;
                    RaisePropertyChanged("add_by");
                }

            }
        }
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
              
                {
                    _add_date = value;
                    RaisePropertyChanged("add_date");
                }

            }
        }

        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                
                {
                    _edit_by = value;
                    RaisePropertyChanged("edit_by");
                }

            }
        }
        
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
               
                {
                    _edit_date = value;
                    RaisePropertyChanged("edit_date");
                }

            }
        }

        public string show_ild
        {
            get { return _show_ild; }
            set
            {

                {
                    _show_ild = value;
                    RaisePropertyChanged("show_ild");
                }

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
