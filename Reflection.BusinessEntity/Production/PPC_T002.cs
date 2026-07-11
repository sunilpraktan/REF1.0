using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public class PPC_T002_A : ObjectBase    
    {

        private string _fromtime;
        public string fromtime
        {
            get { return _fromtime; }
            set { _fromtime = value; RaisePropertyChanged("fromtime"); }
        }

        private string _totime;
        public string totime
        {
            get { return _totime; }
            set { _totime = value; RaisePropertyChanged("totime"); }
        }


        private int _id { get; set; }
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }

        private string _entryno;
        public string entryno
        {
            get { return _entryno; }
            set { _entryno = value; RaisePropertyChanged("entryno"); }
        }

        private Nullable<System.DateTime> _entrydt;
        public Nullable<System.DateTime> entrydt
        {
            get { return _entrydt; }
            set { _entrydt = value; RaisePropertyChanged("entrydt"); }
        }

        private string _entrytype;
        public string entrytype
        {
            get { return _entrytype; }
            set { _entrytype = value; RaisePropertyChanged("entrytype"); }
        }

        private string _type;
        public string type
        {
            get { return _type; }
            set { _type = value; RaisePropertyChanged("type"); }
        }

        private string _itemcode;
        public string itemcode
        {
            get { return _itemcode; }
            set { _itemcode = value; RaisePropertyChanged("itemcode"); }
        }

        private string _sku;
        public string sku
        {
            get { return _sku; }
            set { _sku = value; RaisePropertyChanged("sku"); }
        }

        private  Nullable<int> _operation_seq { get; set; }
        public Nullable<int> operation_seq
        {
            get { return _operation_seq; }
            set
            {
                _operation_seq = value;
                RaisePropertyChanged("operation_seq");
            }
        }

        private string _operation;
        public string operation
        {
            get { return _operation; }
            set { _operation = value; RaisePropertyChanged("operation"); }
        }
        private string _jobcard { get; set; }
        [Required(ErrorMessage = "Field 'Job Cart' is required.")]
        [DisplayName("Job Cart")]
        public string jobcard
        {
            get { return _jobcard; }
            set
            {
                _jobcard = value;
                RaisePropertyChanged("jobcard");
            }
        }
        private Nullable<int> _machine_id { get; set; }
        [Required(ErrorMessage = "Field 'Machine No' is required.")]
        [DisplayName("Machine No")]
        public Nullable<int> machine_id
        {
            get { return _machine_id; }
            set
            {
                _machine_id = value;
                RaisePropertyChanged("machine_id");
            }
        }

        private string _itemdesc;
        public string itemdesc
        {
            get { return _itemdesc; }
            set { _itemdesc = value; RaisePropertyChanged("itemdesc"); }
        }
        private Nullable<int> _unit { get; set; }
        public Nullable<int> unit
        {
            get { return _unit; }
            set
            {
                _unit = value;
                RaisePropertyChanged("unit");
            }
        }

        private string _operator1;
        public string operator1
        {
            get { return _operator1; }
            set { _operator1 = value; RaisePropertyChanged("operator1"); }
        }

        private string _operator2;
        public string operator2
        {
            get { return _operator2; }
            set { _operator2 = value; RaisePropertyChanged("operator2"); }
        }

        private Nullable<decimal> _bal_qty;
        public Nullable<decimal> bal_qty
        {
            get { return _bal_qty; }
            set { _bal_qty = value; RaisePropertyChanged("bal_qty"); }
        }

        private Nullable<decimal> _prod_qty;
        public Nullable<decimal> prod_qty
        {
            get { return _prod_qty; }
            set { _prod_qty = value; RaisePropertyChanged("prod_qty"); }
        }

        private Nullable<decimal> _rejtn_qty;
        public Nullable<decimal> rejtn_qty
        {
            get { return _rejtn_qty; }
            set { _rejtn_qty = value; RaisePropertyChanged("rejtn_qty"); }
        }

        private Nullable<decimal> _usable_prod_qty;
        public Nullable<decimal> usable_prod_qty
        {
            get { return _usable_prod_qty; }
            set { _usable_prod_qty = value; RaisePropertyChanged("usable_prod_qty"); }
        }

        private Nullable<System.DateTime> _fromdate;
        public Nullable<System.DateTime> fromdate
        {
            get { return _fromdate; }
            set { _fromdate = value; RaisePropertyChanged("fromdate"); }
        }       

        private Nullable<System.DateTime> _todate;
        public Nullable<System.DateTime> todate
        {
            get { return _todate; }
            set { _todate = value; RaisePropertyChanged("todate"); }
        }

       

        private string _activity;
        public string activity
        {
            get { return _activity; }
            set { _activity = value; RaisePropertyChanged("activity"); }
        }

        private string _makecode;
        public string makecode
        {
            get { return _makecode; }
            set { _makecode = value; RaisePropertyChanged("makecode"); }
        }

        private Nullable<decimal> _convfact;
        public Nullable<decimal> convfact
        {
            get { return _convfact; }
            set { _convfact = value; RaisePropertyChanged("convfact"); }
        }

        private string _shifsup;
        public string shifsup
        {
            get { return _shifsup; }
            set { _shifsup = value; RaisePropertyChanged("shifsup"); }
        }

        private string _brkdreas;
        public string brkdreas
        {
            get { return _brkdreas; }
            set { _brkdreas = value; RaisePropertyChanged("brkdreas"); }
        }

        private string _dwntime;
        public string dwntime
        {
            get { return _dwntime; }
            set { _dwntime = value; RaisePropertyChanged("dwntime"); }
        }

        private string _shifcode;
        public string shifcode
        {
            get { return _shifcode; }
            set { _shifcode = value; RaisePropertyChanged("shifcode"); }
        }

        private string _partno;
        public string partno
        {
            get { return _partno; }
            set { _partno = value; RaisePropertyChanged("partno"); }
        }

        private string _stkcode;
        public string stkcode
        {
            get { return _stkcode; }
            set { _stkcode = value; RaisePropertyChanged("stkcode"); }
        }

        private Nullable<bool> _chkshet;
        public Nullable<bool> chkshet
        {
            get { return _chkshet; }
            set
            {
                _chkshet = value;
                RaisePropertyChanged("chkshet");
            }

        }

        private Nullable<bool> _toolcard;
        public Nullable<bool> toolcard
        {
            get { return _toolcard; }
            set
            {
                _toolcard = value;
                RaisePropertyChanged("toolcard");
            }

        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }

        private string  _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }

        private Nullable<int> _edit_by;
        public Nullable<int> edit_by
        {
            get { return _edit_by; }
            set { _edit_by = value; RaisePropertyChanged("edit_by"); }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }

        //XML doc 
        public string XmlDataDocument_PPC_T002 { get; set; }

        //Scalar
        private string _MachineCode;
        public string MachineCode
        {
            get { return _MachineCode; }
            set { _MachineCode = value; RaisePropertyChanged("MachineCode"); }
        }

        private bool _Select { get; set; }
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;
                    RaisePropertyChanged("Select");
                }
            }
        }


        private string _unit_name;
        public string unit_name
        {
            get { return _unit_name; }
            set { _unit_name = value; RaisePropertyChanged("unit_name"); }
        }
        
        
    }

    public class MultipleContext_PPC_T002
    {
        public List<PPC_T002_A> Details { get; set; }   //PPC_T002_A
        public ObservableCollection<PPC_T002_A> GoodsDetails { get; set; }  // 
        public List<ZADM_M013_PopUp> Machine { get; set; }  //Machine Master
        public List<PPC_T001_PopUp> JobCart { get; set; }  //Job Cart

    }
}
