using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace Reflection.BusinessEntity
{
    public class ZCRM_T001_A : ObjectBase, IDataErrorInfo
    {
        private int _id;
        private string _inv_no;
        private Nullable<System.DateTime> _inv_dt;
        private string _wa_code;
        //private Nullable<int> _warehouse_id;
        private string _PartyId;
        // private Nullable<int> _supplier_id;
        private Nullable<decimal> _amount_total;
        private string _amt_in_word;
        private string _docket_no;
        private string _lrno;
        private Nullable<System.DateTime> _lrdt;
        private Nullable<decimal> _amount_untaxed;
        private string _store_code;
        //private Nullable<int> _stock_location_id { get; set; }
        private Nullable<decimal> _amount_taxed;
        private string _location_Id;
        private Nullable<bool> _active;
        private string _add_by;
        private Nullable<System.DateTime> _add_date;
        private string _editby;
        private Nullable<System.DateTime> _edit_date;
        private string _po_no;
        private Nullable<System.DateTime> _po_dt;
        private string _Customer_name;
        private string _Warehouse_Name;
        private string _Selectfile;
        private string _xdoc_ACC_T001_A;
        private string _xdoc_ACC_T001_B;
        private string _type;
        private bool _checkall;
        private bool _checkallcust;
        private bool _checkalldispatch;
        private bool _ackflag;
        private Nullable<System.DateTime> _ack_date;
        private Nullable<System.DateTime> _recd_date;
        private bool _dispachflag;
        private string _ItemCode;
        //private Nullable<int> _item_id;
        private string _unit_code;
        //private Nullable<int> _uom_id;
        private Nullable<decimal> _qty;
        private Nullable<decimal> _unit_price;
        private Nullable<decimal> _sub_total;
        private Nullable<decimal> _balqty;
        private string _item_code;
        private string _item_name;
        private string _unit_name;
        //private Nullable<decimal> _boxqty;
        private string _comp_code;

        //[Required(ErrorMessage = "Field 'Customer Name' is required.")]
        //[DisplayName("Customer Name")]


        public string Customer_name
        {
            get { return _Customer_name; }
            set
            {
                if (_Customer_name != value)
                {
                    _Customer_name = value;
                    RaisePropertyChanged("Customer_name");
                }
            }
        }

        //[Required(ErrorMessage = "Field 'Godown Name' is required.")]
        //[DisplayName("Godown Name")]


        public string Warehouse_Name
        {
            get { return _Warehouse_Name; }
            set
            {
                if (_Warehouse_Name != value)
                {
                    _Warehouse_Name = value;
                    RaisePropertyChanged("Warehouse_Name");
                }
            }
        }
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
        public string inv_no
        {
            get { return _inv_no; }
            set
            {
                if (_inv_no != value)
                {
                    _inv_no = value;
                    RaisePropertyChanged("inv_no");
                }
            }
        }
        public Nullable<System.DateTime> inv_dt
        {
            get { return _inv_dt; }
            set
            {
                if (_inv_dt != value)
                {
                    _inv_dt = value;
                    RaisePropertyChanged("inv_dt");
                }
            }
        }
        public string wa_code
        {
            get { return _wa_code; }
            set
            {
                if (_wa_code != value)
                {
                    _wa_code = value;
                    RaisePropertyChanged("wa_code");
                }
            }
        }
        public string PartyId
        {
            get { return _PartyId; }
            set
            {
                if (_PartyId != value)
                {
                    _PartyId = value;
                    RaisePropertyChanged("PartyId");
                }
            }
        }
        public Nullable<decimal> amount_total
        {
            get { return _amount_total; }
            set
            {
                if (_amount_total != value)
                {
                    _amount_total = value;
                    RaisePropertyChanged("amount_total");
                }
            }
        }
        public string amt_in_word
        {
            get { return _amt_in_word; }
            set
            {
                if (_amt_in_word != value)
                {
                    _amt_in_word = value;
                    RaisePropertyChanged("amt_in_word");
                }
            }

        }
        public string docket_no
        {
            get { return _docket_no; }
            set
            {
                if (_docket_no != value)
                {
                    _docket_no = value;
                    RaisePropertyChanged("docket_no");
                }
            }
        }
        public string lrno
        {
            get { return _lrno; }
            set
            {
                if (_lrno != value)
                {
                    _lrno = value;
                    RaisePropertyChanged("lrno");
                }
            }

        }
        public Nullable<System.DateTime> lrdt
        {
            get { return _lrdt; }
            set
            {
                if (_lrdt != value)
                {
                    _lrdt = value;
                    RaisePropertyChanged("lrdt");
                }
            }
        }
        public Nullable<decimal> amount_untaxed
        {
            get { return _amount_untaxed; }
            set
            {
                if (_amount_untaxed != value)
                {
                    _amount_untaxed = value;
                    RaisePropertyChanged("amount_untaxed");
                }
            }
        }

        public string store_code
        {
            get { return _store_code; }
            set
            {
                if (_store_code != value)
                {
                    _store_code = value;
                    RaisePropertyChanged("store_code");
                }
            }
        }
        public Nullable<decimal> amount_taxed
        {
            get { return _amount_taxed; }
            set
            {
                if (_amount_taxed != value)
                {
                    _amount_taxed = value;
                    RaisePropertyChanged("amount_taxed");
                }
            }
        }
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
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value;
                    RaisePropertyChanged("active");
                }
            }
        }
        public string add_by
        {
            get { return _add_by; }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value;
                    RaisePropertyChanged("add_by");
                }
            }
        }
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value;
                    RaisePropertyChanged("add_date");
                }
            }
        }
        public string editby
        {
            get { return _editby; }
            set
            {
                if (_editby != value)
                {
                    _editby = value;
                    RaisePropertyChanged("editby");
                }
            }
        }
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value;
                    RaisePropertyChanged("edit_date");
                }
            }
        }
        public string po_no
        {
            get { return _po_no; }
            set
            {
                if (_po_no != value)
                {
                    _po_no = value;
                    RaisePropertyChanged("po_no");
                }
            }
        }
        public Nullable<System.DateTime> po_dt
        {
            get { return _po_dt; }
            set
            {
                if (_po_dt != value)
                {
                    _po_dt = value;
                    RaisePropertyChanged("po_dt");
                }
            }
        }
        public string Selectfile
        {
            get { return _Selectfile; }
            set
            {
                if (_Selectfile != value)
                {
                    _Selectfile = value;
                    RaisePropertyChanged("Selectfile");
                }
            }
        }
        public string xdoc_ACC_T001_A
        {
            get { return _xdoc_ACC_T001_A; }
            set
            {
                if (_xdoc_ACC_T001_A != value)
                {
                    _xdoc_ACC_T001_A = value;
                    RaisePropertyChanged("xdoc_ACC_T001_A");
                }
            }
        }
        public string xdoc_ACC_T001_B
        {
            get { return _xdoc_ACC_T001_B; }
            set
            {
                if (_xdoc_ACC_T001_B != value)
                {
                    _xdoc_ACC_T001_B = value;
                    RaisePropertyChanged("xdoc_ACC_T001_B");
                }
            }              
        }
        public bool checkallcust
        {
            get { return _checkallcust; }
            set
            {
                if (_checkallcust = value)
                {
                    _checkallcust = value;
                    RaisePropertyChanged("checkallcust");
                }
            }             
        }
        public bool checkall
        {
            get { return _checkall; }
            set
            {
                if (_checkall != value)
                {
                    _checkall = value;
                    RaisePropertyChanged("checkall");
                }
            }               
        }
        public bool checkalldispatch
        {
            get { return _checkalldispatch; }
            set
            {
                if (_checkalldispatch != value)
                {
                    _checkalldispatch = value;
                    RaisePropertyChanged("checkalldispatch");
                }
            }

        }
        public string type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    RaisePropertyChanged("type");
                }
            }

        }
        public bool ackflag
        {
            get { return _ackflag; }
            set
            {
                if (_ackflag != value)
                {
                    _ackflag = value;
                    RaisePropertyChanged("ackflag");
                }
            }
        }
        public Nullable<DateTime> ack_date
        {
            get { return _ack_date; }
            set
            {
                if (_ack_date != value)
                {
                    _ack_date = value;
                    RaisePropertyChanged("ack_date");
                }
            }
        }
        public Nullable<DateTime> recd_date
        {
            get { return _recd_date; }
            set
            {
                if (_recd_date != value)
                {
                    _recd_date = value;
                    RaisePropertyChanged("recd_date");
                }
            }
        }
        public bool dispachflag
        {
            get { return _dispachflag; }
            set
            {
                if (_dispachflag != value)
                {
                    _dispachflag = value;
                    RaisePropertyChanged("dispachflag");
                }
            }              
        }
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                if (_ItemCode != value)
                {
                    _ItemCode = value;
                    RaisePropertyChanged("ItemCode");
                }
            }               
        }
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                if (_unit_code != value)
                {
                    _unit_code = value;
                    RaisePropertyChanged("unit_code");
                }
            }
        }
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set
            {
                if (_qty != value)
                {
                    _qty = value;
                    RaisePropertyChanged("qty");
                }
            }
        }
        public Nullable<decimal> unit_price
        {
            get { return _unit_price; }
            set
            {
                if (_unit_price != value)
                {
                    _unit_price = value;
                    RaisePropertyChanged("unit_price");
                }
            }
        }
        public Nullable<decimal> sub_total
        {
            get { return _sub_total; }
            set
            {
                if (_sub_total != value)
                {
                    _sub_total = value;
                    RaisePropertyChanged("sub_total");
                }
            }
        }
        public Nullable<decimal> balqty
        {
            get { return _balqty; }
            set
            {
                if (_balqty != value)
                {
                    _balqty = value;
                    RaisePropertyChanged("balqty");
                }
            }
        }
        public string item_code
        {
            get { return _item_code; }
            set
            {
                if (_item_code != value)
                {
                    _item_code = value;
                    RaisePropertyChanged("item_code");
                }
            }
        }
        public string item_name
        {
            get { return _item_name; }
            set
            {
                if (_item_name != value)
                {
                    _item_name = value;
                    RaisePropertyChanged("item_name");
                }
            }
        }
        public string unit_name
        {
            get { return _unit_name; }
            set
            {
                if (_unit_name != value)
                {
                    _unit_name = value;
                    RaisePropertyChanged("unit_name");
                }
            }
        }
        private string _sono;
        public string sono
        {
            get { return _sono; }
            set
            {
                if (_sono != value)
                {
                    _sono = value; RaisePropertyChanged("sono");
                }
            }
        }
        private string _sch_no;
        public string sch_no
        {
            get { return _sch_no; }
            set {
                if (_sch_no != value)
                {
                    _sch_no = value; RaisePropertyChanged("sch_no");
                }
            }                
        }


        //public Nullable<decimal> boxqty
        //{
        //    get { return _boxqty; }
        //    set
        //    {
        //        _boxqty = value;
        //        RaisePropertyChanged("boxqty");
        //    }

        //}

        //-------------------------------------------------------------------------
        string IDataErrorInfo.Error
        {
            get { throw new NotImplementedException(); }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }
    }
    public class ZCRM_T001_B : ObjectBase
    {
        private int _id;
        public int id { get { return _id; }
            set {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
                

        private Nullable<int> _inv_id { get; set; }

        public Nullable<int> inv_id { get { return _inv_id; }
            set
            {
                if (_inv_id != value)
                {
                    _inv_id = value; RaisePropertyChanged("inv_id");
                }
            }
        }
                

        private string _ItemCode { get; set; }
        public string ItemCode { get { return _ItemCode; }
            set
            {
                if (_ItemCode != value)
                {
                    _ItemCode = value; RaisePropertyChanged("ItemCode");
                }
            }
        }
                

        private Nullable<int> _uom_id { get; set; }
        public Nullable<int> uom_id { get { return _uom_id; }
            set
            {
                if (_uom_id != value)
                {
                    _uom_id = value; RaisePropertyChanged("_uom_id");
                }
            }
        }
                

        private Nullable<int> _make_id { get; set; }
        public Nullable<int> make_id { get { return _make_id; }
            set
            {
                if (_make_id != value)
                {
                    _make_id = value; RaisePropertyChanged("make_id");
                }
            }
        }
              
        private Nullable<decimal> _qty { get; set; }
        public Nullable<decimal> qty { get { return _qty; }
            set
            {
                if (_qty != value)
                {
                    _qty = value; RaisePropertyChanged("qty");
                }
            }
        }
              

        private Nullable<decimal> _unit_price { get; set; }
        public Nullable<decimal> unit_price { get { return _unit_price; }
            set
            {
                if (_unit_price != value)
                {
                    _unit_price = value; RaisePropertyChanged("unit_price");
                }
            }
        }
               

        private Nullable<int> _tax_id { get; set; }
        public Nullable<int> tax_id { get { return _tax_id; }
            set
            {
                if (_tax_id != value)
                {
                    _tax_id = value; RaisePropertyChanged("tax_id");
                }
            }
        }
                
        private Nullable<decimal> _discount { get; set; }
        public Nullable<decimal> discount { get { return _discount; }
            set
            {
                if (_discount != value)
                {
                    _discount = value; RaisePropertyChanged("discount");
                }
            }
        }
                


        private Nullable<decimal> _sub_total { get; set; }
        public Nullable<decimal> sub_total { get { return _sub_total; }
            set
            {
                if (_sub_total != value)
                {
                    _sub_total = value; RaisePropertyChanged("sub_total");
                }
            }
        }
                


        private Nullable<decimal> _nopkgs { get; set; }
        public Nullable<decimal> nopkgs { get { return _nopkgs; }
            set
            {
                if (_nopkgs != value)
                {
                    _nopkgs = value; RaisePropertyChanged("nopkgs");
                }
            }
        }
                


        private Nullable<decimal> _qtypkg { get; set; }
        public Nullable<decimal> qtypkg { get { return _qtypkg; }
            set
            {
                if (_qtypkg != value)
                {
                    _qtypkg = value; RaisePropertyChanged("qtypkg");
                }
            }
        }
            

        private Nullable<int> _account_analytic_id { get; set; }
        public Nullable<int> account_analytic_id { get { return _account_analytic_id; }
            set
            {
                if (_account_analytic_id != value)
                {
                    _account_analytic_id = value; RaisePropertyChanged("account_analytic_id");
                }
            }
        }  

        public string _status { get; set; }
        public string status { get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value; RaisePropertyChanged("status");
                }
            }
        }
                

        public string _location_Id { get; set; }
        public string location_id { get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
                }
            }
        }
              
        public Nullable<bool> _active { get; set; }
        public Nullable<bool> active { get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }
               

        //public Nullable<int> _add_by { get; set; }
        //public Nullable<int> add_by { get { return _add_by; } set { _add_by = value; RaisePropertyChanged("add_by"); } }

        public Nullable<System.DateTime> _add_date { get; set; }
        public Nullable<System.DateTime> add_date { get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");
                }
            }
        }
                

        //public Nullable<int> _edit_by { get; set; }
        //public Nullable<int> edit_by { get { return _edit_by; } set { _edit_by = value; RaisePropertyChanged("edit_by"); } }
        //public Nullable<System.DateTime> _edit_date { get; set; }
        //public Nullable<System.DateTime> edit_date { get { return _edit_date; } set { _edit_date = value; RaisePropertyChanged("edit_date"); } }


    }
    public class ENVELOPE : ObjectBase
    {

        private bool _isexist;
        public bool isexist { get { return _isexist; }
            set
            {
                if (_isexist = value)
                {
                    _isexist = value; RaisePropertyChanged("isexist");
                }
            }
        }
               
        private string _Customer_name;
        public string Customer_name { get { return _Customer_name; }
            set
            {
                if (_Customer_name != value)
                {
                    _Customer_name = value; RaisePropertyChanged("Customer_name");
                }
            }
        }  
        private string _inv_no { get; set; }
        public string inv_no { get { return _inv_no; }
            set
            {
                if (_inv_no != value)
                {
                    _inv_no = value; RaisePropertyChanged("inv_no");
                }
            }
        }
            
        private string _inv_dt { get; set; }
        public string inv_dt { get { return _inv_dt; }
            set
            {
                if (_inv_dt != value)
                {
                    _inv_dt = value; RaisePropertyChanged("inv_dt");
                }
            }
        }
            
        private string _pono { get; set; }
        public string pono { get { return _pono; }
            set
            {
                if (_pono != value)
                {
                    _pono = value; RaisePropertyChanged("pono");
                }
            }
        } 
        private string _po_dt { get; set; }
        public string po_dt { get { return _po_dt; }
            set
            {
                if (_po_dt != value)
                {
                    _po_dt = value; RaisePropertyChanged("po_dt");
                }
            }
        }
                
        private string _MDPARTNO { get; set; }
        public string MDPARTNO { get { return _MDPARTNO; }
            set
            {
                if (_MDPARTNO != value)
                {
                    _MDPARTNO = value; RaisePropertyChanged("MDPARTNO");
                }
            }
        }
               
        private string _MDITEMSHWETANAME;
        public string MDITEMSHWETANAME
        {
            get { return _MDITEMSHWETANAME; }
            set
            {
                if (_MDITEMSHWETANAME != value)
                {
                    _MDITEMSHWETANAME = value; RaisePropertyChanged("MDPARTNO");
                }
            }
               
        }
        private string _item_name { get; set; }
        public string item_name { get { return _item_name; }
            set
            {
                if (_item_name != value)
                {
                    _item_name = value; RaisePropertyChanged("item_name");
                }
            }
        }
               
        private string _unit_name { get; set; }
        public string unit_name { get { return _unit_name; }
            set {
                if (_unit_name != value)
                {
                    _unit_name = value; RaisePropertyChanged("unit_name");
                }
            }
        }
                
        private string _qty { get; set; }
        public string qty { get { return _qty; }
            set
            {
                if (_qty != value)
                {
                    _qty = value; RaisePropertyChanged("qty");
                }
            }
        }
                
        private string _unit_price { get; set; }
        public string unit_price { get { return _unit_price; }
            set {
                if (_unit_price != value)
                {
                    _unit_price = value; RaisePropertyChanged("unit_price");
                }
            }
        }
                
        private string _sub_total { get; set; }
        public string sub_total { get { return _sub_total; }
            set {
                if (_sub_total != value)
                {
                    _sub_total = value; RaisePropertyChanged("sub_total");
                }
            }
        }
               
        private string _amount_total { get; set; }
        public string amount_total { get { return _amount_total; }
            set
            {
                if (_amount_total != value)
                {
                    _amount_total = value; RaisePropertyChanged("amount_total");
                }
            }
        }
        private string _boxqty { get; set; }
        public string boxqty { get { return _boxqty; }
            set
            {
                if (_boxqty != value)
                {
                    _boxqty = value; RaisePropertyChanged("boxqty");
                }
            }
        }
               
        private string _docket_no { get; set; }
        public string docket_no
        {
            get { return _docket_no; }
            set
            {
                if (_docket_no != value)
                {
                    _docket_no = value;
                    RaisePropertyChanged("docket_no");
                }
            }
        }
        private bool _Checkcust;
        public bool Checkcust { get { return _Checkcust; }
            set
            {
                if (_Checkcust != value)
                {
                    _Checkcust = value; RaisePropertyChanged("Checkcust");
                }
            }
        }
                
        private bool _selectall;
        public bool selectall
        {
            get { return _selectall; }
            set
            {
                if (_selectall = value)
                {
                    _selectall = value;
                    RaisePropertyChanged("selectall");
                }
            }
        }
        private string _sono;
        public string sono
        {
            get { return _sono; }
            set
            {
                if (_sono != value)
                {
                    _sono = value;
                    RaisePropertyChanged("sono");
                }
            }
               
        }
        private string _wa_code;
        public string wa_code
        {
            get { return _wa_code; }
            set
            {
                if (_wa_code != value)
                {
                    _wa_code = value;
                    RaisePropertyChanged("wa_code");
                }
            }               
        }
        private string _Warehouse_Name;
        public string Warehouse_Name
        {
            get { return _Warehouse_Name; }
            set
            {
                if (_Warehouse_Name != value)
                {
                    _Warehouse_Name = value;
                    RaisePropertyChanged("Warehouse_Name");
                }
            }             
        }
        public string company_id { get; set; }
        private string _sch_no;
        public string sch_no
        {
            get { return _sch_no; }
            set
            {
                if (_sch_no != value)
                {
                    _sch_no = value;
                    RaisePropertyChanged("sch_no");
                }
            }               
        }
        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set
            {
                if (_PartyId != value)
                {
                    _PartyId = value;
                    RaisePropertyChanged("PartyId");
                }
            }              
        }
        private bool _checkallcust;
        public bool checkallcust
        {
            get { return _checkallcust; }
            set
            {
                if (_checkallcust = value)
                {
                    _checkallcust = value;
                    RaisePropertyChanged("checkallcust");
                }
            }              
        }
    }
    public class ADM_M003_PopUpwarehouse : ObjectBase
    {
        [DisplayName("ID")]
        //public string wa_code { get; set; }
        public string warehouse_id { get; set; }

        [DisplayName("Warehouse Name")]
        public string Warehouse_Name { get; set; }


    }
    public class PLC : ObjectBase
    {
        //public Nullable<int> ItemId { get; set; }
        //public Nullable<int> unit_id { get; set; }
        public string ItemId { get; set; }
        public string unit_id { get; set; }

        public string CstmrItmCod { get; set; }

    }
    public class DCStock
    {

        public string CustPartno { get; set; }
        public string item_code { get; set; }

        public string item_name { get; set; }


        public Nullable<decimal> godownstock { get; set; }


        public bool check { get; set; }

    }
    public class InvoiceStock
    {

        public Nullable<int> id { get; set; }
        public Nullable<int> inv_id { get; set; }

        public string uom_id { get; set; }
        public string item_id { get; set; }

        public string item_code { get; set; }

        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> Invoicesqty { get; set; }
        public Nullable<decimal> dispatchqty { get; set; }
        public Nullable<decimal> dcqty { get; set; }

        public Nullable<decimal> ackqty { get; set; }

        public string inv_no { get; set; }
        public string inv_dt { get; set; }

        public Nullable<decimal> boxqty { get; set; }
        public string docket_no { get; set; }


        public string item_name { get; set; }

        public Nullable<decimal> godownstock { get; set; }

        public bool check { get; set; }

        public string CustPartno { get; set; }
    }
    public class CRM_T001B_PopUp_PUR : ObjectBase
    {
        [DisplayName("Requisition No.")]
        public string req_no { get; set; }
        public int id { get; set; }
        [DisplayName("Item Code")]
        public string ItemCode { get; set; }

        public string ItemName { get; set; }
        public int SubCategCod { get; set; }
        public string CustCode { get; set; }
        public string CustDecrName { get; set; }
        public Nullable<int> unit_id { get; set; }

        public string unit_name { get; set; }
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

        public Nullable<int> requsition_id { get; set; }
        public Nullable<decimal> appr_qty { get; set; }

        public Nullable<decimal> rate { get; set; }

        public string stockingunit { get; set; }
    }
    public class MultipleContextACC_T001_A
    {
        public ObservableCollection<ZCRM_T001_A> InvoiceMaster { get; set; }

        public ObservableCollection<ZCRM_T001_A> InvoiceDetails { get; set; }
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

        public ObservableCollection<DCStock> DCStock { get; set; }

        public ObservableCollection<InvoiceStock> InvoiceStock { get; set; }
        public List<PPC_T001_PopUp> custSoPoList { get; set; }//for customer sono and pono list
        public List<PPC_T001_PopUp> custSoPoWithItemsList { get; set; }//for customer sono and pono list WITH ITEMSpublic List<PPC_T001_PopUp> ScheduleList { get; set; } 
        public List<PPC_T001_PopUp> ScheduleList { get; set; }
        public List<PPC_T001_PopUp> ScheduleListWithItems { get; set; }
    }
}