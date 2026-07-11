
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace Reflection.BusinessEntity
{
    //public class ZCRM_T002_A : ObjectBase, IDataErrorInfo
    //{

    //    private int _id;
    //    private string _inv_no;
    //    private Nullable<System.DateTime> _inv_dt;
    //    private Nullable<int> _warehouse_id;
    //    private Nullable<int> _supplier_id;
    //    private Nullable<decimal> _amount_total;
    //    private string _amt_in_word;
    //    private string _docket_no;
    //    private string _lrno;
    //    private Nullable<System.DateTime> _lrdt;
    //    private Nullable<decimal> _amount_untaxed;
    //    private Nullable<int> _stock_location_id { get; set; }
    //    private Nullable<decimal> _amount_taxed;
    //    private Nullable<int> _location_id;
    //    private Nullable<bool> _active;
    //    private Nullable<int> _add_by;
    //    private Nullable<System.DateTime> _add_date;
    //    private Nullable<int> _edit_by;
    //    private Nullable<System.DateTime> _edit_date;
    //    private string _pono;
    //    private Nullable<System.DateTime> _po_dt;
    //    private string _Customer_name;
    //    private string _Warehouse_Name;
    //    private string _Selectfile;
    //    private string _xdoc_ACC_T001_A;
    //    private string _xdoc_ACC_T001_B;
    //    private bool _checkall;
    //    private string _type;


    //    [Required(ErrorMessage = "Field 'Customer Name' is required.")]
    //    [DisplayName("Customer Name")]


    //    public string Customer_name
    //    {
    //        get { return _Customer_name; }
    //        set
    //        {
    //            _Customer_name = value;
    //            RaisePropertyChanged("Customer_name");
    //        }

    //    }


    //    public string Warehouse_Name
    //    {
    //        get { return _Warehouse_Name; }
    //        set
    //        {
    //            _Warehouse_Name = value;
    //            RaisePropertyChanged("Warehouse_Name");
    //        }

    //    }
    //    public int id
    //    {
    //        get { return _id; }
    //        set
    //        {
    //            _id = value;
    //            RaisePropertyChanged("id");
    //        }

    //    }

    //    public string inv_no
    //    {
    //        get { return _inv_no; }
    //        set
    //        {
    //            _inv_no = value;
    //            RaisePropertyChanged("inv_no");
    //        }

    //    }


    //    public Nullable<System.DateTime> inv_dt
    //    {
    //        get { return _inv_dt; }
    //        set
    //        {
    //            _inv_dt = value;
    //            RaisePropertyChanged("inv_dt");
    //        }

    //    }


    //    public Nullable<int> warehouse_id
    //    {
    //        get { return _warehouse_id; }
    //        set
    //        {
    //            _warehouse_id = value;
    //            RaisePropertyChanged("warehouse_id");
    //        }

    //    }


    //    public Nullable<int> supplier_id
    //    {
    //        get { return _supplier_id; }
    //        set
    //        {
    //            _supplier_id = value;
    //            RaisePropertyChanged("supplier_id");
    //        }

    //    }




    //    public Nullable<decimal> amount_total
    //    {
    //        get { return _amount_total; }
    //        set
    //        {
    //            _amount_total = value;
    //            RaisePropertyChanged("amount_total");
    //        }

    //    }

    //    public string amt_in_word
    //    {
    //        get { return _amt_in_word; }
    //        set
    //        {
    //            _amt_in_word = value;
    //            RaisePropertyChanged("amt_in_word");
    //        }

    //    }




    //    public string docket_no
    //    {
    //        get { return _docket_no; }
    //        set
    //        {
    //            _docket_no = value;
    //            RaisePropertyChanged("docket_no");
    //        }

    //    }

    //    public string lrno
    //    {
    //        get { return _lrno; }
    //        set
    //        {
    //            _lrno = value;
    //            RaisePropertyChanged("lrno");
    //        }

    //    }

    //    public Nullable<System.DateTime> lrdt
    //    {
    //        get { return _lrdt; }
    //        set
    //        {
    //            _lrdt = value;
    //            RaisePropertyChanged("lrdt");
    //        }

    //    }

    //    public Nullable<decimal> amount_untaxed
    //    {
    //        get { return _amount_untaxed; }
    //        set
    //        {
    //            _amount_untaxed = value;
    //            RaisePropertyChanged("amount_untaxed");
    //        }

    //    }

    //    public Nullable<int> stock_location_id
    //    {
    //        get { return _stock_location_id; }
    //        set
    //        {
    //            _stock_location_id = value;
    //            RaisePropertyChanged("stock_location_id");
    //        }

    //    }

    //    public Nullable<decimal> amount_taxed
    //    {
    //        get { return _amount_taxed; }
    //        set
    //        {
    //            _amount_taxed = value;
    //            RaisePropertyChanged("amount_taxed");
    //        }

    //    }




    //    public Nullable<int> location_id
    //    {
    //        get { return _location_id; }
    //        set
    //        {
    //            _location_id = value;
    //            RaisePropertyChanged("location_id");
    //        }

    //    }

    //    public Nullable<bool> active
    //    {
    //        get { return _active; }
    //        set
    //        {
    //            _active = value;
    //            RaisePropertyChanged("active");
    //        }

    //    }

    //    public Nullable<int> add_by
    //    {
    //        get { return _add_by; }
    //        set
    //        {
    //            _add_by = value;
    //            RaisePropertyChanged("add_by");
    //        }

    //    }


    //    public Nullable<System.DateTime> add_date
    //    {
    //        get { return _add_date; }
    //        set
    //        {
    //            _add_date = value;
    //            RaisePropertyChanged("add_date");
    //        }

    //    }


    //    public Nullable<int> edit_by
    //    {
    //        get { return _edit_by; }
    //        set
    //        {
    //            _edit_by = value;
    //            RaisePropertyChanged("edit_by");
    //        }

    //    }


    //    public Nullable<System.DateTime> edit_date
    //    {
    //        get { return _edit_date; }
    //        set
    //        {
    //            _edit_date = value;
    //            RaisePropertyChanged("edit_date");
    //        }

    //    }


    //    public string pono
    //    {
    //        get { return _pono; }
    //        set
    //        {
    //            _pono = value;
    //            RaisePropertyChanged("pono");
    //        }

    //    }


    //    public Nullable<System.DateTime> po_dt
    //    {
    //        get { return _po_dt; }
    //        set
    //        {
    //            _po_dt = value;
    //            RaisePropertyChanged("po_dt");
    //        }

    //    }




    //    public string Selectfile
    //    {
    //        get { return _Selectfile; }
    //        set
    //        {
    //            _Selectfile = value;
    //            RaisePropertyChanged("Selectfile");
    //        }

    //    }





    //    public string xdoc_ACC_T001_A
    //    {
    //        get { return _xdoc_ACC_T001_A; }
    //        set
    //        {
    //            _xdoc_ACC_T001_A = value;
    //            RaisePropertyChanged("xdoc_ACC_T001_A");
    //        }

    //    }


    //    public string xdoc_ACC_T001_B
    //    {
    //        get { return _xdoc_ACC_T001_B; }
    //        set
    //        {
    //            _xdoc_ACC_T001_B = value;
    //            RaisePropertyChanged("xdoc_ACC_T001_B");
    //        }

    //    }

    //    public bool checkall
    //    {
    //        get { return _checkall; }
    //        set
    //        {
    //            _checkall = value;
    //            RaisePropertyChanged("checkall");
    //        }

    //    }

    //    public string type
    //    {
    //        get { return _type; }
    //        set
    //        {
    //            _type = value;
    //            RaisePropertyChanged("type");
    //        }

    //    }

    //    //-------------------------------------------------------------------------
    //    string IDataErrorInfo.Error
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    string IDataErrorInfo.this[string columnName]
    //    {
    //        get { throw new NotImplementedException(); }
    //    }
    //}
    public class ZCRM_T002_B : ObjectBase
    {
        private int _id;
        public int id { get { return _id; } set { _id = value; RaisePropertyChanged("id"); } }

        private Nullable<int> _inv_id { get; set; }

        public Nullable<int> inv_id { get { return _inv_id; } set { _inv_id = value; RaisePropertyChanged("inv_id"); } }

        private Nullable<int> _item_id { get; set; }
        public Nullable<int> item_id { get { return _item_id; } set { _item_id = value; RaisePropertyChanged("item_id"); } }

        private Nullable<int> _uom_id { get; set; }
        public Nullable<int> uom_id { get { return _uom_id; } set { _uom_id = value; RaisePropertyChanged("_uom_id"); } }

        private Nullable<int> _make_id { get; set; }
        public Nullable<int> make_id { get { return _make_id; } set { _make_id = value; RaisePropertyChanged("make_id"); } }
        private Nullable<decimal> _qty { get; set; }
        public Nullable<decimal> qty { get { return _qty; } set { _qty = value; RaisePropertyChanged("qty"); } }

        private Nullable<decimal> _unit_price { get; set; }
        public Nullable<decimal> unit_price { get { return _unit_price; } set { _unit_price = value; RaisePropertyChanged("unit_price"); } }

        private Nullable<int> _tax_id { get; set; }
        public Nullable<int> tax_id { get { return _tax_id; } set { _tax_id = value; RaisePropertyChanged("tax_id"); } }
        private Nullable<decimal> _discount { get; set; }
        public Nullable<decimal> discount { get { return _discount; } set { _discount = value; RaisePropertyChanged("discount"); } }


        private Nullable<decimal> _sub_total { get; set; }
        public Nullable<decimal> sub_total { get { return _sub_total; } set { _sub_total = value; RaisePropertyChanged("sub_total"); } }


        private Nullable<decimal> _nopkgs { get; set; }
        public Nullable<decimal> nopkgs { get { return _nopkgs; } set { _nopkgs = value; RaisePropertyChanged("nopkgs"); } }


        private Nullable<decimal> _qtypkg { get; set; }
        public Nullable<decimal> qtypkg { get { return _qtypkg; } set { _qtypkg = value; RaisePropertyChanged("qtypkg"); } }

        private Nullable<int> _account_analytic_id { get; set; }
        public Nullable<int> account_analytic_id { get { return _account_analytic_id; } set { _account_analytic_id = value; RaisePropertyChanged("account_analytic_id"); } }

        public string _status { get; set; }
        public string status { get { return _status; } set { _status = value; RaisePropertyChanged("status"); } }

        public Nullable<int> _location_id { get; set; }
        public Nullable<int> location_id { get { return _location_id; } set { _location_id = value; RaisePropertyChanged("location_id"); } }
        public Nullable<bool> _active { get; set; }
        public Nullable<bool> active { get { return _active; } set { _active = value; RaisePropertyChanged("active"); } }

        public Nullable<int> _add_by { get; set; }
        public Nullable<int> add_by { get { return _add_by; } set { _add_by = value; RaisePropertyChanged("add_by"); } }

        public Nullable<System.DateTime> _add_date { get; set; }
        public Nullable<System.DateTime> add_date { get { return _add_date; } set { _add_date = value; RaisePropertyChanged("add_date"); } }

        public Nullable<int> _edit_by { get; set; }
        public Nullable<int> edit_by { get { return _edit_by; } set { _edit_by = value; RaisePropertyChanged("edit_by"); } }
        public Nullable<System.DateTime> _edit_date { get; set; }
        public Nullable<System.DateTime> edit_date { get { return _edit_date; } set { _edit_date = value; RaisePropertyChanged("edit_date"); } }


    }

    public partial class DeliveryEntry : ObjectBase
    {


        public string inv_no { get; set; }


        public string inv_dt { get; set; }


        public Nullable<int> item_id { get; set; }

        public string item_code { get; set; }

        public string item_name { get; set; }

        public Nullable<int> uom_id { get; set; }


        public string unit_name { get; set; }


        public Nullable<decimal> qty { get; set; }

        public Nullable<decimal> unit_price { get; set; }

        public Nullable<decimal> balqty { get; set; }

        public Nullable<int> inv_id { get; set; }
        public Nullable<int> id { get; set; }

        public Nullable<bool> active { get; set; }
        private bool _check { get; set; }

        public bool check
        {
            get { return _check; }
            set
            {
                if (_check != value)
                {
                    _check = value;
                    RaisePropertyChanged("check");
                }
            }

        }

        private string _remark { get; set; }
        public string remark
        {
            get { return _remark; }
            set
            {
                if (_remark != value)
                {
                    _remark = value;
                    RaisePropertyChanged("remark");
                }
            }

        }

        public string docket_no { get; set; }

        public Nullable<decimal> boxqty { get; set; }


    }

    public partial class DeliveryEntryM : ObjectBase
    {


        public string inv_no { get; set; }


        public string inv_dt { get; set; }

        public Nullable<decimal> amount_total { get; set; }

        internal bool _Select { get; set; }
        [DisplayName("")]
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

        public Nullable<int> id { get; set; }
    }
 
    public class MultipleContextZCRM_T002A
    {

        public ObservableCollection<ZCRM_T001_A> InvoiceMaster { get; set; }

        public ObservableCollection<ZCRM_T001_B> InvoiceDetails { get; set; }
        public ObservableCollection<ADM_M028_PopUp> partyDetails { get; set; }

        public ObservableCollection<ADM_M003_PopUpwarehouse> LocationDetails { get; set; }
        public ObservableCollection<ADM_M022_PopUp> itemMaster { get; set; }
        public ObservableCollection<ADM_M038_B_PopUp> unitDetails { get; set; }

        public ObservableCollection<ENVELOPE> ENVELOPEDetails { get; set; }

        public ObservableCollection<PLC> PLC { get; set; }

        public List<ZCRM_T001_A> DCMaster { get; set; }

        public ObservableCollection<ZCRM_T002_B> DCDetails { get; set; }

        public ObservableCollection<DeliveryEntry> Details { get; set; }

        public ObservableCollection<DeliveryEntryM> MDetails { get; set; }


    }
}