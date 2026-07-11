using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public class ZADM_M018 : ObjectBase
    {

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("id");
                }
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value;
                    RaisePropertyChanged("comp_code");
                }
            }
        }

        private string _plant;
        public string plant
        {
            get { return _plant; }
            set
            {
                if (_plant != value)
                {
                    _plant = value; RaisePropertyChanged("plant");
                }
            }
        }

        private string _entry_no;
        public string entry_no
        {
            get { return _entry_no; }
            set
            {
                if (_entry_no != value)
                {
                    _entry_no = value; RaisePropertyChanged("entry_no");
                }
            }
        }

        private DateTime _entry_dt;
        public DateTime entry_dt
        {
            get { return _entry_dt; }
            set
            {
                if (_entry_dt != value)
                { 
                _entry_dt = value; RaisePropertyChanged("entry_dt");
            }
        }
    }
			
		 private string _trans_type;
        public string trans_type
        {
            get { return _trans_type; }
            set {
                if (_trans_type != value)
                {
                    _trans_type = value; RaisePropertyChanged("trans_type");
                }
            }
        }
               
					
        private Nullable<int> _party_id;
        [Required(ErrorMessage = "Field 'Party' is required.")]
        [DisplayName("Party")]
        public Nullable<int> party_id
        {
            get { return _party_id; }
            set
            {
                if (_party_id != value)
                {
                    _party_id = value;
                    RaisePropertyChanged("party_id");
                }
            }
        }
                
		 
        private string _item_code;
        public string item_code
        {
            get { return _item_code; }
            set {
                if (_item_code != value)
                {
                    _item_code = value; RaisePropertyChanged("item_code");
                }
            }
        }
              
			
		private string _ink;
        public string ink
        {
            get { return _ink; }
            set
            {
                if (_ink != value)
                {
                    _ink = value; RaisePropertyChanged("ink");
                }
            }
        }

        private string _ild;
         public string ild
        {
            get { return _ild; }
            set {
                if (_ild != value)
                {
                    _ild = value; RaisePropertyChanged("ild");
                }
            }
        }
                 
			
	    private string _grade;
        public string grade
        {
            get { return _grade; }
            set {
                if (_grade != value)
                {                   
                   _grade = value; RaisePropertyChanged("grade");
                }
            }
        }
               
		private Nullable<decimal> _amt;
        public Nullable<decimal> amt
        {
            get { return _amt; }
            set
            {
                if (_amt != value)
                {
                    _amt = value;
                    RaisePropertyChanged("amt");
                }
            }
        } 

         private string _acc_type;
        public string acc_type
        {
            get { return _acc_type; }
            set
            {
                if (_acc_type != value)
                {
                    _acc_type = value; RaisePropertyChanged("acc_type");
                }
            }
        }	   
			
	    private string _debit_credit;
        public string debit_credit
        {
            get { return _debit_credit; }
            set
            {
                if (_debit_credit != value)
                {
                    _debit_credit = value; RaisePropertyChanged("debit_credit");
                }
            }
        }
					 
	    private string _note;
        public string note
        {
            get { return _note; }
            set
            {
                if (_note != value)
                {
                    _note = value; RaisePropertyChanged("note");
                }
            }
        }
               

        private string _location_Id;
       [Required(ErrorMessage = "Field 'Consignee' is required.")]
        [DisplayName("Consignee")]
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value;
                    RaisePropertyChanged("location_Id");
                }
            }
        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }
                

        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");
                }
            }
        }
                

        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                if (_edit_by != value)
                {
                    _edit_by = value; RaisePropertyChanged("edit_by");
                }
            }
        } 

        //XML doc 
        public string XmlDataDocument_ZADM_M018 { get; set; }

        ////Scalr 
        private string _PlantName;
        public string PlantName
        {
            get { return _PlantName; }
            set {
                if (_PlantName != value)
                {
                    _PlantName = value; RaisePropertyChanged("PlantName");
                }
            }
        }
                

        private string _PartyName;
        public string PartyName
        {
            get { return _PartyName; }
            set
            {
                if (_PartyName != value)
                {
                    _PartyName = value; RaisePropertyChanged("PartyName");
                }
            }
        }
    }

    public class MultipleContext_ZADM_M018
    {
        public List<ZADM_M018> DebitCreditDetails { get; set; } //ZADM_M018
        public ObservableCollection<ZADM_M018> GoodsDetails { get; set; }  // ZADM_M018
        public List<ADM_M028_PopUp> Customer { get; set; } //Customer /Party
        public List<ADM_M022_ESSEM_PopUp> Product { get; set; } //Product /Item         
        public List<ZADM_M006_PopUp> INK { get; set; }     //INK
        public List<ZADM_M007_PopUp> ILD { get; set; }    //ILD
        public List<ADM_M003_PopUp1> plant { get; set; }  //Plant/Location Master    
       
       
    }
}
