using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public class CRM_T002A :ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
      
        private int _id;
        public int id
        { get { return _id; } set { _id = value; RaisePropertyChanged("id"); } }

        private string _supp_cat_code;
        public string supp_cat_code
        { get { return _supp_cat_code; } set { _supp_cat_code = value; RaisePropertyChanged("supp_cat_code"); } }
        private Nullable<System.DateTime> _cat_date;
        public Nullable<System.DateTime> cat_date
        { get { return _cat_date; } set { _cat_date = value; RaisePropertyChanged("cat_date"); } }
        private string _PartyId;
        public string PartyId
        { get { return _PartyId; } set { _PartyId = value; RaisePropertyChanged("PartyId"); } }
        private Nullable<System.DateTime> _from_date;
        public Nullable<System.DateTime> from_date
        { get { return _from_date; } set { _from_date = value; RaisePropertyChanged("from_date"); } }
        private Nullable<System.DateTime> _to_date;
        public Nullable<System.DateTime> to_date
        { get { return _to_date; } set { _to_date = value; RaisePropertyChanged("to_date"); } }
        private string _remark;
        public string remark
        { get { return _remark; } set { _remark = value; RaisePropertyChanged("remark"); } }
        private string _location_Id;
        public string location_Id
        { get { return _location_Id; } set { _location_Id = value; RaisePropertyChanged("location_Id"); } }
        private string _fin_year;
        public string fin_year
        { get { return _fin_year; } set { _fin_year = value; RaisePropertyChanged("fin_year"); } }
        private string _posting_period;
        public string posting_period
        { get { return _posting_period; } set { _posting_period = value; RaisePropertyChanged("posting_period"); } }
        private Nullable<bool> _active;
        public Nullable<bool> active
        { get { return _active; } set { _active = value; RaisePropertyChanged("active"); } }

        private string _add_by;
        public string add_by
        { get { return _add_by; } set { _add_by = value; RaisePropertyChanged("add_by"); } }
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        { get { return _add_date; } set { _add_date = value; RaisePropertyChanged("add_date"); } }
        private string _editby;
        public string editby
        { get { return _editby; } set { _editby = value; RaisePropertyChanged("editby"); } }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        { get { return _edit_date; } set { _edit_date = value; RaisePropertyChanged("edit_date"); } }
        private string _comp_code;
        public string comp_code
        { get { return _comp_code; } set { _comp_code = value; RaisePropertyChanged("comp_code"); } }
        private string _description;
        public string description
        { get { return _description; } set { _description = value; RaisePropertyChanged("description"); } }
        private string _so_code;
        public string so_code
        { get { return _so_code; } set { _so_code = value; RaisePropertyChanged("so_code"); } }
        private string _po_code;
        public string po_code
        { get { return _po_code; } set { _po_code = value; RaisePropertyChanged("po_code"); } }

        private string _party_name;
        [Required(ErrorMessage = "Field 'party_name' is required.")]
        [DisplayName("Party Name")]
        public string party_name { get { return _party_name; } set { _party_name = value; RaisePropertyChanged("party_name"); } }

        public string XmlData_CRM_T002B { get; set; }
        public string XmlData_CRM_T002D { get; set; }       //tax
        public string XmlDataDocument_FlipGrid { get; set; }

    }
    //--------------------------------CRM_T002B--------------------
    public class CRM_T002B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        public int id
        { get { return _id; } set { _id = value; RaisePropertyChanged("id"); } }
        private string _supp_cat_code;
        public string supp_cat_code
        { get { return _supp_cat_code; } set { _supp_cat_code = value; RaisePropertyChanged("supp_cat_code"); } }

        private Nullable<int> _ref_srno;
        public Nullable<int> ref_srno
        { get { return _ref_srno; } set { _ref_srno = value; RaisePropertyChanged("ref_srno"); } }
        private string _ItemCode;
        public string ItemCode
        { get { return _ItemCode; } set { _ItemCode = value; RaisePropertyChanged("ItemCode"); } }
        private string _unit_code;
        public string unit_code
        { get { return _unit_code; } set { _unit_code = value; RaisePropertyChanged("unit_code"); } }
        private string _PartyId;
        public string PartyId
        { get { return _PartyId; } set { _PartyId = value; RaisePropertyChanged("PartyId"); } }
        private string _cstmr_itemcode;
        public string cstmr_itemcode
        { get { return _cstmr_itemcode; } set { _cstmr_itemcode = value; RaisePropertyChanged("cstmr_itemcode"); } }
        private string _cstmr_itemdescr;
        public string cstmr_itemdescr
        { get { return _cstmr_itemdescr; } set { _cstmr_itemdescr = value; RaisePropertyChanged("cstmr_itemdescr"); } }
        private Nullable<int> _lead_type;
        public Nullable<int> lead_type
        { get { return _lead_type; } set { _lead_type = value; RaisePropertyChanged("lead_type"); } }
        private decimal _min_ordrval;
        public decimal min_ordrval
        { get { return _min_ordrval; } set { _min_ordrval = value; RaisePropertyChanged("min_ordrval"); } }
        private decimal _min_qty;
        public decimal min_qty
        { get { return _min_qty; } set { _min_qty = value; RaisePropertyChanged("min_qty"); } }
        private decimal _max_qty;
        public decimal max_qty
        { get { return _max_qty; } set { _max_qty = value; RaisePropertyChanged("max_qty"); } }
        private decimal _b_rate;
        public decimal b_rate
        { get { return _b_rate; } set { _b_rate = value; RaisePropertyChanged("_b_rate"); } }
        private decimal _price_list;
        public decimal price_list
        { get { return _price_list; } set { _price_list = value; RaisePropertyChanged("price_list"); } }
        private decimal _mrp;
        public decimal mrp
        { get { return _mrp; } set { _mrp = value; RaisePropertyChanged("mrp"); } }
        private decimal _higher_limit;
        public decimal higher_limit
        { get { return _higher_limit; } set { _higher_limit = value; RaisePropertyChanged("higher_limit"); } }
        private decimal _lower_limit;
        public decimal lower_limit
        { get { return _lower_limit; } set { _lower_limit = value; RaisePropertyChanged("lower_limit"); } }
        private string _rmrk;
        public string rmrk
        { get { return _rmrk; } set { _rmrk = value; RaisePropertyChanged("rmrk"); } }
        private Nullable<bool> _active;
        public Nullable<bool> active
        { get { return _active; } set { _active = value; RaisePropertyChanged("active"); } }
        private string _add_by;
        public string add_by
        { get { return _add_by; } set { _add_by = value; RaisePropertyChanged("add_by"); } }
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        { get { return _add_date; } set { _add_date = value; RaisePropertyChanged("add_date"); } }
        private string _editby;
        public string editby
        { get { return _editby; } set { _editby = value; RaisePropertyChanged("editby"); } }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        { get { return _edit_date; } set { _edit_date = value; RaisePropertyChanged("_edit_date"); } }
        private string _description;
        public string description
        { get { return _description; } set { _description = value; RaisePropertyChanged("description"); } }
        private string _sku;
        public string sku
        { get { return _sku; } set { _sku = value; RaisePropertyChanged("sku"); } }
        private string _tax_id;
        public string tax_id
        { get { return _tax_id; } set { _tax_id = value; RaisePropertyChanged("tax_id"); } }
        private string _location_Id;
        public string location_Id
        { get { return _location_Id; } set { _location_Id = value; RaisePropertyChanged("location_Id"); } }
        private string _comp_code;
        public string comp_code
        { get { return _comp_code; } set { _comp_code = value; RaisePropertyChanged("comp_code"); } }

        private string _fin_year;
        public string fin_year
        { get { return _fin_year; } set { _fin_year = value; RaisePropertyChanged("fin_year"); } }

        private string _posting_period;
        public string posting_period
        { get { return _posting_period; } set { _posting_period = value; RaisePropertyChanged("posting_period"); } }

        private string _item_name;
        public string item_name { get { return _item_name; } set { _item_name = value; RaisePropertyChanged("item_name"); } }
        private string _unit_name;
        public string unit_name
        { get { return _unit_name; } set { _unit_name = value; RaisePropertyChanged("unit_name"); } }
        private string _SubCategCod;
        public string SubCategCod
        { get { return _SubCategCod; } set { _SubCategCod = value; RaisePropertyChanged("SubCategCod"); } }
        private Nullable<bool> _StockUnt;
        public Nullable<bool> StockUnt
        { get { return _StockUnt; } set { _StockUnt = value; RaisePropertyChanged("StockUnt"); } }
        private string _sku_desc;
        public string sku_desc
        {
            get { return _sku_desc; }
            set { _sku_desc = value; RaisePropertyChanged("sku_desc"); }
        }
    }
   
    public class CRM_T002C
    {
        public int id { get; set; }
        public Nullable<int> line_id { get; set; }
        public Nullable<decimal> range1 { get; set; }
        public Nullable<decimal> range2 { get; set; }
        public Nullable<int> parameter_id { get; set; }
    }
    public class CRM_T002D
    {
        public int id { get; set; }
        public Nullable<int> line_id { get; set; }
        public Nullable<int> tax_id { get; set; }
    }
    public class MultipleContextCRM_T002
    {
        public List<CRM_T002AFlip> CRM_T002ADataFlipGrid { get; set; }
        public List<ADM_M028_P> party_master { get; set; }                       //Party Master
        public List<ADM_M022_P> item_master { get; set; }                        //Item Master
        public List<ADM_M038_B_P> unit_master { get; set; }                      // Unit Master
        public List<ACC_M013_P> Tax_Master { get; set; }                          // Tax master
        public List<ADM_M031_P> ParameterList { get; set; }                      //Parameter Master
        public List<ADM_M030_P> ParamValueList { get; set; }                     //Flute Master
        public List<CRM_T002A> supplier_catalog_Master { get; set; }            // CRM_T002A Master Details
        public ObservableCollection<CRM_T002B> supplier_catalog_details { get; set; }            // CRM_T002B Details
        //public List<CRM_T002C> supplier_catalog_range { get; set; }              //CRM_T002C Range
        public ObservableCollection<CRM_T002D> supplier_catalog_tax_details { get; set; }         //CRM_T002D Tax_Details

     

    }
    public class CRM_T002AFlip
    {
        public string supp_cat_code { get; set; }
        public Nullable<System.DateTime> cat_date { get; set; }
        public string PartyId { get; set; }
        public Nullable<System.DateTime> from_date { get; set; }
        public Nullable<System.DateTime> to_date { get; set; }
        public string remark { get; set; }
        public string location_Id { get; set; }
        public string fin_year { get; set; }
        public Nullable<bool> active { get; set; }
        public string comp_code { get; set; }
        public string description { get; set; }
        public string so_code { get; set; }
        public string po_code { get; set; }
        public string party_name { get; set; }
    }
}
