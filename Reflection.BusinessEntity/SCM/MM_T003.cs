using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.MM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public class MM_T003 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated); }
        }
        private DateTime? _doc_date;
        public DateTime? doc_date
        {
            get { return _doc_date; }
            set { _doc_date = value; RaisePropertyChanged("doc_date", ModelEntityUpdated); }
        }
        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set { _location_id = value; RaisePropertyChanged("location_id"); }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat", ModelEntityUpdated); }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type", ModelEntityUpdated); }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set { _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat", ModelEntityUpdated); }
        }
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set { _ref_doc_no = value; RaisePropertyChanged("ref_doc_no", ModelEntityUpdated); }
        }
        private string _pr_code;
        public string pr_code
        {
            get { return _pr_code; }
            set { _pr_code = value; RaisePropertyChanged("pr_code", ModelEntityUpdated); }
        }
        private string _origin;
        public string origin
        {
            get { return _origin; }
            set { _origin = value; RaisePropertyChanged("origin", ModelEntityUpdated); }
        }
        private string _req_type;
        public string req_type
        {
            get { return _req_type; }
            set { _req_type = value; RaisePropertyChanged("req_type", ModelEntityUpdated); }
        }
        private DateTime? _deadline;
        public DateTime? deadline
        {
            get { return _deadline; }
            set { _deadline = value; RaisePropertyChanged("deadline", ModelEntityUpdated); }
        }
        private string _wa_code;
        public string wa_code
        {
            get { return _wa_code; }
            set { _wa_code = value; RaisePropertyChanged("wa_code", ModelEntityUpdated); }
        }
        private string _emp_id;
        public string emp_id
        {
            get { return _emp_id; }
            set
            {
                if (_emp_id != value)
                {
                    _emp_id = value; RaisePropertyChanged("emp_id", ModelEntityUpdated);
                }
            }
        }
        private string _dept_code;
        public string dept_code
        {
            get { return _dept_code; }
            set { _dept_code = value; RaisePropertyChanged("dept_code", ModelEntityUpdated); }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated); }
        }
        private string _note;
        public string note
        {
            get { return _note; }
            set { _note = value; RaisePropertyChanged("note", ModelEntityUpdated); }
        }
        private string _active;
        public string active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active", ModelEntityUpdated); }
        }

        private DateTime? _from_date;
        public DateTime? from_date
        {
            get { return _from_date; }
            set
            {
                _from_date = value;
                RaisePropertyChanged("from_date");
            }
        }
        private DateTime? _to_date;
        public DateTime? to_date
        {
            get { return _to_date; }
            set
            {
                _to_date = value;
                RaisePropertyChanged("to_date");
            }
        }
        private string _from_time;
        public string from_time
        {
            get { return _from_time; }
            set { _from_time = value; RaisePropertyChanged("from_time", ModelEntityUpdated); }
        }
        private string _to_time;
        public string to_time
        {
            get { return _to_time; }
            set { _to_time = value; RaisePropertyChanged("to_time", ModelEntityUpdated); }
        }

        // Scalar Fields
        private string _bom_no;
        public string bom_no
        {
            get { return _bom_no; }
            set { _bom_no = value; RaisePropertyChanged("bom_no"); }
        }
        private string _pri_name;
        public string pri_name
        {
            get { return _pri_name; }
            set { _pri_name = value; RaisePropertyChanged("pri_name", ModelEntityUpdated); }
        }
        private string _emp_name;
        public string emp_name
        {
            get { return _emp_name; }
            set
            {
                _emp_name = value;
                RaisePropertyChanged("emp_name", ModelEntityUpdated);
            }
        }
        private string _dept_name;
        public string dept_name
        {
            get { return _dept_name; }
            set
            {
                _dept_name = value;
                RaisePropertyChanged("dept_name", ModelEntityUpdated);
            }
        }
        private string _doc_type_name;
        public string doc_type_name
        {
            get { return _doc_type_name; }
            set { _doc_type_name = value; RaisePropertyChanged("doc_type_name"); }
        }
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set { _t_display = value; RaisePropertyChanged("t_display"); }
        }
        private decimal? _order_qty;
        public decimal? order_qty
        {
            get { return _order_qty; }
            set { _order_qty = value; RaisePropertyChanged("order_qty"); }
        }
        public string XDOC_A { get; set; }
    }
    public class MM_T003_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int? _id;
        public int? id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated); }
        }

        private string _item_code;
        public string item_code
        {
            get { return _item_code; }
            set { _item_code = value; RaisePropertyChanged("item_code", ModelEntityUpdated); }
        }

        private string _item_name;
        public string item_name
        {
            get { return _item_name; }
            set { _item_name = value; RaisePropertyChanged("item_name", ModelEntityUpdated); }
        }

        private string _sku;
        public string sku
        {
            get { return _sku; }
            set { _sku = value; RaisePropertyChanged("sku", ModelEntityUpdated); }
        }

        private string _sku_desc;
        public string sku_desc
        {
            get { return _sku_desc; }
            set { _sku_desc = value; RaisePropertyChanged("sku_desc", ModelEntityUpdated); }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat", ModelEntityUpdated); }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type", ModelEntityUpdated); }
        }

        private decimal? _qty;
        public decimal? qty
        {
            get { return _qty; }
            set { _qty = value; RaisePropertyChanged("qty", ModelEntityUpdated); }
        }

        private decimal? _appr_qty;
        public decimal? appr_qty
        {
            get { return _appr_qty; }
            set { _appr_qty = value; RaisePropertyChanged("appr_qty", ModelEntityUpdated); }
        }

        private decimal? _cost;
        public decimal? cost
        {
            get { return _cost; }
            set { _cost = value; RaisePropertyChanged("cost", ModelEntityUpdated); }
        }

        private DateTime? _expected_date;
        public DateTime? expected_date
        {
            get { return _expected_date; }
            set { _expected_date = value; RaisePropertyChanged("expected_date", ModelEntityUpdated); }
        }

        private string _note;
        public string note
        {
            get { return _note; }
            set { _note = value; RaisePropertyChanged("note", ModelEntityUpdated); }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated); }
        }
        private string _active;
        public string active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active", ModelEntityUpdated); }
        }
      
        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set { _location_id = value; RaisePropertyChanged("location_id"); }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _item_cat;
        public string item_cat
        {
            get { return _item_cat; }
            set { _item_cat = value; RaisePropertyChanged("item_cat", ModelEntityUpdated); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated); }
        }
        private int? _line_id;
        public int? line_id
        {
            get { return _line_id; }
            set { _line_id = value; RaisePropertyChanged("line_id"); }
        }
        private int? _order_item_row_id;
        public int? order_item_row_id
        {
            get { return _order_item_row_id; }
            set { _order_item_row_id = value; RaisePropertyChanged("order_item_row_id"); }
        }
        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set { _order_no = value; RaisePropertyChanged("order_no"); }
        }
        private string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set { _store_code = value; RaisePropertyChanged("store_code"); }
        }
        private string _batch_no;
        public string batch_no
        {
            get { return _batch_no; }
            set { _batch_no = value; RaisePropertyChanged("batch_no"); }
        }
        private string _wc_code;
        public string wc_code
        {
            get { return _wc_code; }
            set { _wc_code = value; RaisePropertyChanged("wc_code"); }
        }
        private string _equip_no;
        public string equip_no
        {
            get { return _equip_no; }
            set { _equip_no = value; RaisePropertyChanged("equip_no"); }
        }
        private decimal? _equip_counter;
        public decimal? equip_counter
        {
            get { return _equip_counter; }
            set { _equip_counter = value; RaisePropertyChanged("equip_counter"); }
        }
        private string _counter_unit;
        public string counter_unit
        {
            get { return _counter_unit; }
            set { _counter_unit = value; RaisePropertyChanged("counter_unit"); }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set { _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat"); }
        }
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set { _ref_doc_no = value; RaisePropertyChanged("ref_doc_no"); }
        }
        private int? _re_item_row_id;
        public int? re_item_row_id
        {
            get { return _re_item_row_id; }
            set { _re_item_row_id = value; RaisePropertyChanged("re_item_row_id"); }
        }
        private DateTime? _from_date;
        public DateTime? from_date
        {
            get { return _from_date; }
            set
            {
                _from_date = value;
                RaisePropertyChanged("from_date");
            }
        }
        private DateTime? _to_date;
        public DateTime? to_date
        {
            get { return _to_date; }
            set
            {
                _to_date = value;
                RaisePropertyChanged("to_date");
            }
        }
        private string _from_time;
        public string from_time
        {
            get { return _from_time; }
            set { _from_time = value; RaisePropertyChanged("from_time", ModelEntityUpdated); }
        }
        private string _to_time;
        public string to_time
        {
            get { return _to_time; }
            set { _to_time = value; RaisePropertyChanged("to_time", ModelEntityUpdated); }
        }

        // Scalar Fields
        private string _ind_vc; 
        public string ind_vc
        {
            get { return _ind_vc; }
            set
            {
                _ind_vc = value;
                RaisePropertyChanged("ind_vc");
            }
        }
        private string _sub_cat { get; set; }
        public string sub_cat
        {
            get { return _sub_cat; }
            set { _sub_cat = value; RaisePropertyChanged("sub_cat"); }
        }
        private decimal? _issue_qty;
        public decimal? issue_qty
        {
            get { return _issue_qty; }
            set { _issue_qty = value; RaisePropertyChanged("issue_qty"); }
        }
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set { _t_display = value; RaisePropertyChanged("t_display"); }
        }
        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set { _short_text = value; RaisePropertyChanged("short_text"); }
        }
    }
    public partial class MM_T003_S
    {
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string ind_ack { get; set; }
        public string ind_store_code { get; set; }
        public string ind_batch_no { get; set; }

    }


    //public class MultipleContext_MM_T003
    //{
    //    public List<STD_LIST_BE> BACK_FLIP_LIST { get; set; }
    //    public List<MM_T003Flip> DocumentDataFlipGrid { get; set; }
    //    public List<ADM_M040_P> PrioritiesList { get; set; }//Priority Master    
    //    public List<ADM_M024_P> RequsterList { get; set; }
    //    public List<ADM_M025_P> DeptList { get; set; }
    //    public List<ADM_M022_P> ItemList { get; set; }  //Item Master
    //    public List<ADM_M031_P> ParameterList { get; set; } //Parameter Master
    //    public List<ADM_M030_P> ParamValueList { get; set; }//Flute Master
    //    public List<SYS_M008_P> ItemCategoryList { get; set; }
    //    public List<ADM_M038_B_P> UnitList { get; set; }  //Unit Master
    //    public List<MM_M001_P> StoreList { get; set; }
    //    public List<MM_S003_P> batchList { get; set; }
    //    public List<MM_T003> MasterEntity { get; set; }
    //    public ObservableCollection<MM_T003_A> ItemsEntity { get; set; }
    //    public List<ENG_T001_A_P> BOMItems { get; set; }
    //    public List<ZADM_M013_P> MachineList { get; set; }
    //    public List<SYS_M011_P> DocType { get; set; }
    //    public List<ENG_T001_P> BOMData { get; set; }
    //    public List<EPR_T001_P> OrderList { get; set; }
    //    public List<ADM_M0013> t_statusList { get; set; }
    //    public List<MM_M001> StoreCodeList { get; set; }
    //    public List<MM_T003_S> MM_T003_SETTING { get; set; }
    //    public List<EPR_T001> ProductionOrderList { get; set; }
    //    public List<STD_LIST_BE> EQUIPMENT_LIST { get; set; }
    //    public List<ADM_M0002> COMPANY_LIST { get; set; }
    //    public List<ADM_M0003> LOCATION_LIST { get; set; }
    //    public List<MM_M0001> STORE_LIST { get; set; }
    //}

    //public class MM_T003Flip
    //{
    //    public string req_no { get; set; }
    //    public Nullable<DateTime> date_start { get; set; }
    //    public string Requester_Nm { get; set; }
    //    public string priorityNm { get; set; }
    //    public string Dept_Name { get; set; }
    //    public Nullable<DateTime> deadline { get; set; }
    //    public string req_type { get; set; }
    //    public string t_display { get; set; }
    //    public string comp_code { get; set; }
    //    public string location_id { get; set; }
    //    public string doc_cat { get; set; }
    //    public string doc_type { get; set; }

    //}


}
