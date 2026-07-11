using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Reflection.BusinessEntity
{
    public class PPC_T001 : ObjectBase
    {
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
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
            }
        }


        private Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set
            {
             
                _doc_date = value;              
                RaisePropertyChanged("doc_date");
            }
        }

        private string _item_code;
        [Required(ErrorMessage = "Field 'Item Cart' is required.")]
        [DisplayName("Item Cart")]
        public string item_code
        {
            get { return _item_code; }
            set
            {
                _item_code = value;
                RaisePropertyChanged("item_code");
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

        private string _sku;
        public string sku
        {
            get { return _sku; }
            set
            {
                _sku = value;
                RaisePropertyChanged("sku");
            }
        }

        private string _plan_no;
        public string plan_no
        {
            get { return _plan_no; }
            set
            {
                _plan_no = value;
                RaisePropertyChanged("plan_no");
            }
        }

        private string _carton_no;
        public string carton_no
        {
            get { return _carton_no; }
            set
            {
                _carton_no = value;
                RaisePropertyChanged("carton_no");
            }
        }

        private string _carton_name;
        public string carton_name
        {
            get { return _carton_name; }
            set
            {
                _carton_name = value;
                RaisePropertyChanged("carton_name");
            }
        }

        private Nullable<int> _week_no;
        public Nullable<int> week_no
        {
            get { return _week_no; }
            set
            {
                _week_no = value;
                RaisePropertyChanged("week_no");
            }
        }

        private decimal _jc_qty;
        public decimal jc_qty
        {
            get { return _jc_qty; }
            set
            {
                _jc_qty = value;
                RaisePropertyChanged("jc_qty");
            }
        }

        private string _so_no;
        [Required(ErrorMessage = "Field 'Sales Order' is required.")]
        [DisplayName("Sales Order")]
        public string so_no
        {
            get { return _so_no; }
            set
            {
                _so_no = value;
                RaisePropertyChanged("so_no");
            }
        }

        private string _so_item_no;
        public string so_item_no
        {
            get { return _so_item_no; }
            set
            {
                _so_item_no = value;
                RaisePropertyChanged("so_item_no");
            }
        }

        private Nullable<System.DateTime> _start_date;
        public Nullable<System.DateTime> start_date
        {
            get { return _start_date; }
            set
            {
                _start_date = value;
                RaisePropertyChanged("start_date");
            }
        }

        private Nullable<System.DateTime> _end_date;
        public Nullable<System.DateTime> end_date
        {
            get { return _end_date; }
            set
            {
                _end_date = value;
                RaisePropertyChanged("end_date");
            }
        }

        private Nullable<bool> _inprocess;
        public Nullable<bool> inprocess
        {
            get { return _inprocess; }
            set
            {
                _inprocess = value;
                RaisePropertyChanged("inprocess");
            }
        }

        private Nullable<bool> _close;
        public Nullable<bool> close
        {
            get { return _close; }
            set
            {
                _close = value;
                RaisePropertyChanged("close");
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

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }


        private string _plant_id;
        public string plant_id
        {
            get { return _plant_id; }
            set
            {
                _plant_id = value;
                RaisePropertyChanged("plant_id");
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

        private Nullable<int> _edit_by;
        public Nullable<int> edit_by
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

        public string XmlDataDocument_PPC_T001 { get; set; }

    }

    public class MultipleContext_PPC_T001
    {
        public List<PPC_T001> JobCartList { get; set; } //jobCart      
        public List<SEL_T001_Popup> ItemList { get; set; }//itemcode
        public List<SEL_T001_PopUp_Deli_Note> SoNoList { get; set; }//SoNo       
        public ObservableCollection<PPC_T001> JobCartDetails { get; set; } //jobCartDetails
       
        
    }
}
