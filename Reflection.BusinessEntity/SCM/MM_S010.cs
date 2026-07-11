using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Reflection.BusinessEntity.SCM
{
    public class MM_S010 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int? _id;
        public int? id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
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

        private string _store_code ;
        public string store_code
        {
            get { return _store_code; }
            set { _store_code = value; RaisePropertyChanged("store_code"); }
        }

        private string _wa_code ;
        public string wa_code
        {
            get { return _wa_code; }
            set { _wa_code = value; RaisePropertyChanged("wa_code"); }
        }

        private string _fin_year ;
        public string fin_year
        {
            get { return _fin_year; }
            set { _fin_year = value; RaisePropertyChanged("fin_year"); }
        }

        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set { _posting_period = value; RaisePropertyChanged("posting_period"); }
        }

        private string _trns_type ;
        public string trns_type
        {
            get { return _trns_type; }
            set { _trns_type = value; RaisePropertyChanged("trns_type"); }

        }

        private string _doc_no ;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }

        }

        private string _Grade;
        public string Grade
        {
            get { return _Grade; }
            set { _Grade = value; RaisePropertyChanged("Grade"); }

        }

        private string _doc_cat ;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }

        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type"); }

        }

        private Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set { _doc_date = value; RaisePropertyChanged("doc_date"); }

        }

        private string _sp_stock;
        public string sp_stock
        {
            get { return _sp_stock; }
            set { _sp_stock = value; RaisePropertyChanged("sp_stock"); }
        }

        private Nullable<System.DateTime> _plann_date;
        public Nullable<System.DateTime> plann_date
        {
            get { return _plann_date; }
            set { _plann_date = value; RaisePropertyChanged("plann_date"); }
        }

        private Nullable<System.DateTime> _last_count_date;
        public Nullable<System.DateTime> last_count_date
        {
            get { return _last_count_date; }
            set { _last_count_date = value; RaisePropertyChanged("last_count_date"); }
        }

        private Nullable<System.DateTime> _post_date ;
        public Nullable<System.DateTime> post_date
        {
            get { return _post_date; }
            set { _post_date = value; RaisePropertyChanged("post_date"); }
        }

        private Nullable<bool> _posting_block;
        public Nullable<bool> posting_block
        {
            get { return _posting_block; }
            set { _posting_block = value; RaisePropertyChanged("posting_block"); }
        }

        private string _count_sts;
        public string count_sts
        {
            get { return _count_sts; }
            set { _count_sts = value; RaisePropertyChanged("count_sts"); }
        }

        private string _ref_no;
        public string ref_no
        {
            get { return _ref_no; }
            set { _ref_no = value; RaisePropertyChanged("ref_no"); }
        }

        private string _freeze;
        public string freeze
        {
            get { return _freeze; }
            set { _freeze = value; RaisePropertyChanged("freeze"); }
        }

        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }

        //scalar variable
        private string _CatCode;
        public string CatCode
        {
            get { return _CatCode; }
            set { _CatCode = value; RaisePropertyChanged("CatCode"); }
        }

        private string _CatName;
        public string CatName
        {
            get { return _CatName; }
            set { _CatName = value; RaisePropertyChanged("CatName"); }
        }

        private string _SubCatCode;
        public string SubCatCode
        {
            get { return _SubCatCode; }
            set { _SubCatCode = value; RaisePropertyChanged("SubCatCode"); }
        }

        private string _SubCatName;
        public string SubCatName
        {
            get { return _SubCatName; }
            set { _SubCatName = value; RaisePropertyChanged("SubCatName"); }
        }

        private string _ItemTypeCd;
        public string ItemTypeCd
        {
            get { return _ItemTypeCd; }
            set { _ItemTypeCd = value; RaisePropertyChanged("ItemTypeCd"); }
        }

        private string _ItemTypeNm;
        public string ItemTypeNm
        {
            get { return _ItemTypeNm; }
            set { _ItemTypeNm = value; RaisePropertyChanged("ItemTypeNm"); }
        }

        private string _SubItemTpCd;
        public string SubItemTpCd
        {
            get { return _SubItemTpCd; }
            set { _SubItemTpCd = value; RaisePropertyChanged("SubItemTpCd"); }
        }

        private string _SubItemTpNm;
        public string SubItemTpNm
        {
            get { return _SubItemTpNm; }
            set { _SubItemTpNm = value; RaisePropertyChanged("SubItemTpNm"); }
        }

        private string _LoctnNm;
        public string LoctnNm
        {
            get { return _LoctnNm; }
            set { _LoctnNm = value; RaisePropertyChanged("LoctnNm"); }
        }

        private string _store_name;
        public string store_name
        {
            get { return _store_name; }
            set { _store_name = value; RaisePropertyChanged("store_name"); }
        }

        private string _CompName;
        public string CompName
        {
            get { return _CompName; }
            set { _CompName = value; RaisePropertyChanged("CompName"); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private bool? _ChkAll;
        public bool? ChkAll
        {
            get { return _ChkAll; }
            set { _ChkAll = value; RaisePropertyChanged("ChkAll"); }
        }

        private string _LoadItems;
        public string LoadItems
        {
            get { return _LoadItems; }
            set { _LoadItems = value; RaisePropertyChanged("LoadItems"); }
        }

        private int? _Count;
        public int? Count
        {
            get { return _Count; }
            set { _Count = value; RaisePropertyChanged("Count"); }
        }

        private bool? _ManualEntry;
        public bool? ManualEntry
        {
            get { return _ManualEntry; }
            set
            {
                _ManualEntry = value;
                RaisePropertyChanged("ManualEntry");
            }

        }

        private bool? _NewRecord;
        public bool? NewRecord
        {
            get { return _NewRecord; }
            set
            {
                _NewRecord = value;
                RaisePropertyChanged("NewRecord");
            }
        }

        private string _localimport;
        public string localimport
        {
            get { return _localimport; }
            set { _localimport = value; RaisePropertyChanged("localimport"); }
        }
        public string XmlDataDocument_MM_S010_A { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public class MM_S010_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _comp_code ;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _location_Id ;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }

        //private string _store_code;
        //public string store_code
        //{
        //    get { return _store_code; }
        //    set { _store_code = value; RaisePropertyChanged("store_code"); }
        //}

        private string _store_code;
        [Required(ErrorMessage = "Field 'Storage Location' is required.")]
        [DisplayName("Storage Location")]
        public string store_code
        {
            get { return _store_code; }
            set
            {
                _store_code = value;
                RaisePropertyChanged("store_code");
            }
        }

        private string _wa_code;
        public string wa_code
        {
            get { return _wa_code; }
            set { _wa_code = value; RaisePropertyChanged("wa_code"); }
        }

        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set { _fin_year = value; RaisePropertyChanged("fin_year"); }
        }

        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set { _posting_period = value; RaisePropertyChanged("posting_period"); }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }

        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode"); }
        }

        private string _sku;
        public string sku
        {
            get { return _sku; }
            set { _sku = value; RaisePropertyChanged("sku"); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private string _batch_no;
        public string batch_no
        {
            get { return _batch_no; }
            set { _batch_no = value; RaisePropertyChanged("batch_no"); }
        }

        private string _sp_stock;
        public string sp_stock
        {
            get { return _sp_stock; }
            set { _sp_stock = value; RaisePropertyChanged("sp_stock"); }
        }

        private string _store_type;
        public string store_type
        {
            get { return _store_type; }
            set { _store_type = value; RaisePropertyChanged("store_type"); }
        }

        private string _sono;
        public string sono
        {
            get { return _sono; }
            set { _sono = value; RaisePropertyChanged("sono"); }
        }

        private Nullable<int> _so_item_no;
        public Nullable<int> so_item_no
        {
            get { return _so_item_no; }
            set { _so_item_no = value; RaisePropertyChanged("so_item_no"); }
        }

        private string _sch_no;
        public string sch_no
        {
            get { return _sch_no; }
            set { _sch_no = value; RaisePropertyChanged("sch_no"); }
        }

        private string _vendor_accno;
        public string vendor_accno
        {
            get { return _vendor_accno; }
            set { _vendor_accno = value; RaisePropertyChanged("vendor_accno"); }
        }

        private string _customer_accno;
        public string customer_accno
        {
            get { return _customer_accno; }
            set { _customer_accno = value; RaisePropertyChanged("customer_accno"); }
        }

        private string _dist_diff;
        public string dist_diff
        {
            get { return _dist_diff; }
            set { _dist_diff = value; RaisePropertyChanged("dist_diff"); }
        }

        private Nullable<System.DateTime> _last_count_date;
        public Nullable<System.DateTime> last_count_date
        {
            get { return _last_count_date; }
            set { _last_count_date = value; RaisePropertyChanged("last_count_date"); }
        }

        private Nullable<System.DateTime> _post_date;
        public Nullable<System.DateTime> post_date
        {
            get { return _post_date; }
            set { _post_date = value; RaisePropertyChanged("post_date"); }
        }

        private string _ref_no;
        public string ref_no
        {
            get { return _ref_no; }
            set { _ref_no = value; RaisePropertyChanged("ref_no"); }
        }

        private Nullable<bool> _item_counted;
        public Nullable<bool> item_counted
        {
            get { return _item_counted; }
            set { _item_counted = value; RaisePropertyChanged("item_counted"); }
        }

        private Nullable<bool> _difference_posted;
        public Nullable<bool> difference_posted
        {
            get { return _difference_posted; }
            set { _difference_posted = value; RaisePropertyChanged("difference_posted"); }
        }

        private Nullable<bool> _item_delete;
        public Nullable<bool> item_delete
        {
            get { return _item_delete; }
            set { _item_delete = value; RaisePropertyChanged("item_delete"); }
        }

        private Nullable<decimal> _prebook_qty;
        public Nullable<decimal> prebook_qty
        {
            get { return _prebook_qty; }
            set { _prebook_qty = value; RaisePropertyChanged("prebook_qty", ModelEntityUpdated); }
        }

        private Nullable<bool> _zero_count;
        public Nullable<bool> zero_count
        {
            get { return _zero_count; }
            set { _zero_count = value; RaisePropertyChanged("zero_count"); }
        }

        private Nullable<decimal> _quantity;
        public Nullable<decimal> quantity
        {
            get { return _quantity; }
            set { _quantity = value; RaisePropertyChanged("quantity", ModelEntityUpdated); }
        }

        private string _base_unit_code;
        public string base_unit_code
        {
            get { return _base_unit_code; }
            set { _base_unit_code = value; RaisePropertyChanged("base_unit_code", ModelEntityUpdated); }
        }

        private Nullable<decimal> _qty_unit_entry;
        public Nullable<decimal> qty_unit_entry
        {
            get { return _qty_unit_entry; }
            set { _qty_unit_entry = value; RaisePropertyChanged("qty_unit_entry",ModelEntityUpdated); }
        }

        private string _entry_unit;
        public string entry_unit
        {
            get { return _entry_unit; }
            set { _entry_unit = value; RaisePropertyChanged("entry_unit"); }
        }

        private string _item_doc_no;
        public string item_doc_no
        {
            get { return _item_doc_no; }
            set { _item_doc_no = value; RaisePropertyChanged("item_doc_no"); }
        }

        private Nullable<int> _item_doc_year;
        public Nullable<int> item_doc_year
        {
            get { return _item_doc_year; }
            set { _item_doc_year = value; RaisePropertyChanged("item_doc_year"); }
        }

        private string _item_doc;
        public string item_doc
        {
            get { return _item_doc; }
            set { _item_doc = value; RaisePropertyChanged("item_doc");  }
        }

        private string _rec_doc_no;
        public string rec_doc_no
        {
            get { return _rec_doc_no;   }
            set { _rec_doc_no = value; RaisePropertyChanged("rec_doc_no");   }
        }

        private Nullable<decimal> _diff_amt;
        public decimal? diff_amt
        {
            get{ return _diff_amt;  }
            set{_diff_amt = value; RaisePropertyChanged("diff_amt");      }
        }

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code;}
            set { _curr_code = value; RaisePropertyChanged("curr_code"); }
        }

        private string _inv_ind;
        public string inv_ind
        {
            get  {  return _inv_ind;   }
            set  {  _inv_ind = value; RaisePropertyChanged("inv_ind"); }
        }

        private decimal? _sales_value;
        public decimal? sales_value
        {
            get { return _sales_value; }
            set { _sales_value = value; RaisePropertyChanged("sales_value"); }
        }

        private decimal? _ext_sales_value;
        public decimal? ext_sales_value
        {
            get { return _ext_sales_value; }
            set { _ext_sales_value = value; RaisePropertyChanged("ext_sales_value"); }
        }

        private decimal? _book_value_sp;
        public decimal? book_value_sp
        {
            get { return _book_value_sp; }
            set { _book_value_sp = value; RaisePropertyChanged("book_value_sp"); }
        }

        private string _value_ind;
        public string value_ind
        {
            get { return _value_ind; }
            set { _value_ind = value; RaisePropertyChanged("value_ind"); }
        }
        private decimal? _sales_value_ex;
        public decimal? sales_value_ex
        {
            get  {  return _sales_value_ex; }
            set  { _sales_value_ex = value; RaisePropertyChanged("sales_value_ex");  }
        }

        private decimal? _sales_value_diff;
        public decimal? sales_value_diff
        {
            get { return _sales_value_diff; }
            set { _sales_value_diff = value; RaisePropertyChanged("sales_value_diff"); }
        }

        private decimal? _sales_value_diff2;
        public decimal? sales_value_diff2
        {
            get { return _sales_value_diff2; }
            set { _sales_value_diff2 = value; RaisePropertyChanged("sales_value_diff2"); }
        }

        private decimal? _phy_count_value;
        public decimal? phy_count_value
        {
            get { return _phy_count_value; }
            set { _phy_count_value = value; RaisePropertyChanged("phy_count_value"); }
        }

        private decimal? _book_value;
        public decimal? book_value
        {
            get { return _book_value; }
            set { _book_value = value; RaisePropertyChanged("book_value"); }
        }

        private decimal? _qty_diff;
        public decimal? qty_diff
        {
            get { return _qty_diff; }
            set { _qty_diff = value; RaisePropertyChanged("qty_diff"); }
        }

        private decimal? _inv_diff;
        public decimal? inv_diff
        {
            get { return _inv_diff; }
            set { _inv_diff = value; RaisePropertyChanged("inv_diff"); }
        }

        private Nullable<System.DateTime> _count_date;
        public Nullable<System.DateTime> count_date
        {
            get { return _count_date; }
            set { _count_date = value; RaisePropertyChanged("count_date"); }
        }

        private Nullable<System.TimeSpan> _count_time;
        public Nullable<System.TimeSpan> count_time
        {
            get { return _count_time; }
            set { _count_time = value; RaisePropertyChanged("count_time"); }
        }


        private Nullable<System.DateTime> _freeze_date;
        public Nullable<System.DateTime> freeze_date
        {
            get { return _freeze_date; }
            set { _freeze_date = value; RaisePropertyChanged("freeze_date"); }
        }

        private Nullable<System.TimeSpan> _freeze_time;
        public Nullable<System.TimeSpan> freeze_time
        {
            get { return _freeze_time; }
            set { _freeze_time = value; RaisePropertyChanged("freeze_time"); }
        }

        private string _count_by;
        public string count_by
        {
            get { return _count_by; }
            set { _count_by = value; RaisePropertyChanged("count_by"); }
        }

        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }

        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }

        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }

        private Nullable<decimal> _shortage_access;
        public Nullable<decimal> shortage_access
        {
            get { return _shortage_access; }
            set { _shortage_access = value; RaisePropertyChanged("shortage_access"); }
        }

        private Nullable<decimal> _varience;
        public Nullable<decimal> varience
        {
            get { return _varience; }
            set { _varience = value; RaisePropertyChanged("varience"); }
        }

        private Nullable<decimal> _rate;
        public Nullable<decimal> rate
        {
            get { return _rate; }
            set { _rate = value; RaisePropertyChanged("rate", ModelEntityUpdated); }
        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set { _remark = value; RaisePropertyChanged("remark"); }
        }

        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; RaisePropertyChanged("ItemName"); }
        }

        private Nullable<bool> _StockUnt;
        public Nullable<bool> StockUnt
        {
            get { return _StockUnt; }
            set { _StockUnt = value; RaisePropertyChanged("StockUnt"); }
        }

        private string _SubCatCode;
        public string SubCatCode
        {
            get { return _SubCatCode; }
            set { _SubCatCode = value; RaisePropertyChanged("SubCatCode"); }
        }

        private string _sku_desc;
        public string sku_desc
        {
            get { return _sku_desc; }
            set { _sku_desc = value; RaisePropertyChanged("sku_desc"); }
        }

        private string _make;
        public string make
        {
            get { return _make; }
            set { _make = value; RaisePropertyChanged("make"); }
        }

        private string _grade;
        public string grade
        {
            get { return _grade; }
            set { _grade = value; RaisePropertyChanged("grade"); }
        }

        private string _type;
        public string type
        {
            get { return _type; }
            set { _type = value; RaisePropertyChanged("type"); }
        }

        private string _mat_cond;
        public string mat_cond
        {
            get { return _mat_cond; }
            set { _mat_cond = value; RaisePropertyChanged("mat_cond"); }
        }

        //scalar
        private Nullable<bool> _check;
        public bool? check
        {
            get
            {return _check;}
            set
            { _check = value; RaisePropertyChanged("check");}
        }

        private int? _ink_id;
        public int? ink_id
        {
            get{return _ink_id;}
            set{  _ink_id = value; RaisePropertyChanged("ink_id");}
        }

        private string _ink;
        public string ink
        {
            get { return _ink; }
            set { _ink = value; RaisePropertyChanged("ink"); }
        }

        private int? _ild_id;
        public int? ild_id
        {
            get { return _ild_id; }
            set { _ild_id = value; RaisePropertyChanged("ild_id"); }
        }

        private string _ild;
        public string ild
        {
            get { return _ild; }
            set { _ild = value; RaisePropertyChanged("ild"); }
        }

        private string _ItemTypeCd;
        public string ItemTypeCd
        {
            get { return _ItemTypeCd; }
            set { _ItemTypeCd = value; RaisePropertyChanged("ItemTypeCd"); }
        }

        private string _SubItemTpCd;
        public string SubItemTpCd
        {
            get { return _SubItemTpCd; }
            set { _SubItemTpCd = value; RaisePropertyChanged("SubItemTpCd"); }
        }

      
    }

    public class MM_S010_BackFlip
    {
        public string doc_no { get; set; }
        public Nullable<DateTime> doc_date { get; set; }
        public string t_status { get; set; }
        public Nullable<DateTime> plann_date { get; set; }
        public Nullable<DateTime> post_date { get; set; }
        public string location_Id { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string user_source1 { get; set; }

    }
    public class MultipleContext_MM_S010
    {
        public List<MM_S010_BackFlip> BackFlipEntity { get; set; }
        public List<MM_S010> MasterEntity { get; set; }
        public ObservableCollection<MM_S010_A> ItemEntity { get; set; }
        public List<MM_S010_A> ItemEntityPop { get; set; }
        public List<ADM_M018_P> CategoryList { get; set; }
        public List<ADM_M019_P> SubCategoryList { get; set; }
        public List<ADM_M015_P> ItemTypeList { get; set; }
        public List<ADM_M016_P> SubItemTypeList { get; set; }
        public List<ADM_M038_B_P> UOMList { get; set; }
        public List<ADM_M003_P> PlantList { get; set; }
        public List<MM_M001_P> StorageLocationList { get; set; } //Storage Location Master
        public List<ADM_M002_P> CompanyList { get; set; }
        public List<ADM_M022_P> itemsList { get; set; }  //Item Master
        public List<ADM_M022_P> itemsListFG { get; set; }  //Item Master
        public List<ADM_M030_P> ParamValueList { get; set; }//Parameter Value Master
        public List<ADM_M031_P> ParameterList { get; set; } //Parameter Master
        public List<ACC_M001A_P> FinYear { get; set; }
        public List<ACC_M001A_P> PostPeriod { get; set; }
        public List<ZADM_M006_P> InkDetails { get; set; }
        public List<ZADM_M007_P> IldDetails { get; set; }
        public List<ADM_M045_P> GradeDetails { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
    }
}
