using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Reflection.BusinessEntity
{
    public class CRM_T001A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _CatNo;
        private string _cust_cat_no;
        private Nullable<System.DateTime> _CatDate;
        private string _PartyId;
        private Nullable<System.DateTime> _Fdate;
        private Nullable<System.DateTime> _Tdate;
        private string _remark;
        private string _location_Id;
        private string _comp_code;
        private string _fin_year;
        private string _posting_period;
        private bool? _active;
        private string _add_by;
        private System.DateTime _add_date;
        private string _editby;
        private DateTime? _edit_date;
        private string _description;
        private string _so_code;
        private string _po_code;
        private string _party_name;
        private bool? _generate_batch;

        public int CatNo
        {
            get { return _CatNo; }
            set
            {
                if (_CatNo != value)
                {
                    _CatNo = value; RaisePropertyChanged("CatNo");
                }
            }
        }

        public string cust_cat_no
        {
            get { return _cust_cat_no; }
            set
            {
                if (_cust_cat_no != value)
                {
                    _cust_cat_no = value; RaisePropertyChanged("cust_cat_no", ModelEntityUpdated);
                }
            }
        }
        public Nullable<System.DateTime> CatDate
        {
            get { return _CatDate; }
            set
            {
                if (_CatDate != value)
                {
                    _CatDate = value; RaisePropertyChanged("CatDate", ModelEntityUpdated);
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
                    _PartyId = value; RaisePropertyChanged("PartyId", ModelEntityUpdated);
                }
            }
        }
        public Nullable<System.DateTime> Fdate
        {
            get { return _Fdate; }
            set
            {
                if (_Fdate != value)
                {
                    _Fdate = value; RaisePropertyChanged("Fdate", ModelEntityUpdated);
                }
            }
        }

        public Nullable<System.DateTime> Tdate
        {
            get { return _Tdate; }
            set
            {
                if (_Tdate != value)
                {
                    _Tdate = value; RaisePropertyChanged("Tdate", ModelEntityUpdated);
                }
            }
        }
        public string remark
        {
            get { return _remark; }
            set
            {
                if (_remark != value)
                {
                    _remark = value; RaisePropertyChanged("remark", ModelEntityUpdated);
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
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
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
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
            }
        }

        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
                }
            }
        }

        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated);
                }
            }
        }

        public bool? active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
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
                    _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated);
                }
            }
        }

        public DateTime add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated);
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
                    _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated);
                }
            }
        }
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated);
                }
            }
        }

        public string description
        {
            get { return _description; }
            set
            { _description = value; RaisePropertyChanged("description", ModelEntityUpdated); }
        }
        public string so_code
        {
            get { return _so_code; }
            set
            {
                if (_so_code != value)
                {
                    _so_code = value; RaisePropertyChanged("so_code", ModelEntityUpdated);
                }
            }
        }

        public string po_code
        {
            get { return _po_code; }
            set
            {
                if (_po_code != value)
                {
                    _po_code = value; RaisePropertyChanged("po_code", ModelEntityUpdated);
                }
            }
        }


        public string party_name
        {
            get { return _party_name; }
            set
            {
                if (_party_name != value)
                {
                    _party_name = value; RaisePropertyChanged("party_name", ModelEntityUpdated);
                }
            }
        }

        public bool? generate_batch
        {
            get { return _generate_batch; }
            set
            {
                if (_generate_batch != value)
                {
                    _generate_batch = value; RaisePropertyChanged("generate_batch", ModelEntityUpdated);
                }
            }
        }
        
        public string XmlData_CRM_T001B { get; set; }
        public string XmlData_CRM_T001C { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }




    }
    public class CRM_T001B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        private string _cust_cat_no;
        private Nullable<int> _CatNo;
        public Nullable<int> _refsrno;
        private string _ItemCode;
        private string _unit_code;
        private string _PartyId;
        private string _CstmrItmCod;
        private string _CstmrItmDesc;
        private Nullable<int> _LeadTym;
        private decimal? _MinOrdrVal;
        private decimal? _MinQty;
        private decimal? _MaxQty;
        private decimal? _Brate;
        private decimal? _price_list;
        private decimal? _mrp;
        private decimal? _higher_limit;
        private decimal? _lower_limit;
        private string _Rmrk;
        private bool _active;
        private string _add_by;
        private System.DateTime _add_date;
        private string _editby;
        public DateTime? _edit_date;
        public string _tax_id;
        private string _location_Id;
        private string _comp_code;
        private string _fin_year;
        private string _posting_period;
        private string _description;
        private string _sku;
        private string _sku_desc;
        // private string _item_name;        
        private string _unit_name;
        //public int _SetQty;
       
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
        public string cust_cat_no
        {
            get { return _cust_cat_no; }
            set
            {
                if (_cust_cat_no != value)
                {
                    _cust_cat_no = value; RaisePropertyChanged("cust_cat_no", ModelEntityUpdated);
                }
            }
        }
        public int? CatNo
        {
            get { return _CatNo; }
            set
            {
                if (_CatNo != value)
                {
                    _CatNo = value; RaisePropertyChanged("CatNo", ModelEntityUpdated);
                }
            }
        }
        public Nullable<int> refsrno
        {
            get { return _refsrno; }
            set
            {
                if (_refsrno != value)
                {
                    _refsrno = value; RaisePropertyChanged("refsrno", ModelEntityUpdated);
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
                    _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated);
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
                    _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated);
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
                    _PartyId = value; RaisePropertyChanged("PartyId", ModelEntityUpdated);
                }
            }
        }
        public string CstmrItmCod
        {
            get { return _CstmrItmCod; }
            set
            {
                if (_CstmrItmCod != value)
                {
                    _CstmrItmCod = value; RaisePropertyChanged("CstmrItmCod", ModelEntityUpdated);
                }
            }
        }

        public string CstmrItmDesc
        {
            get { return _CstmrItmDesc; }
            set
            {
                if (_CstmrItmDesc != value)
                {
                    _CstmrItmDesc = value; RaisePropertyChanged("CstmrItmDesc", ModelEntityUpdated);
                }
            }
        }

        public int? LeadTym
        {
            get { return _LeadTym; }
            set
            {
                if (_LeadTym != value)
                {
                    _LeadTym = value; RaisePropertyChanged("LeadTym", ModelEntityUpdated);
                }
            }
        }

        public decimal? MinOrdrVal
        {
            get { return _MinOrdrVal; }
            set
            {
                if (_MinOrdrVal != value)
                {
                    _MinOrdrVal = value; RaisePropertyChanged("MinOrdrVal", ModelEntityUpdated);
                }
            }
        }

        public decimal? MinQty
        {
            get { return _MinQty; }
            set
            {
                if (_MinQty != value)
                {
                    _MinQty = value; RaisePropertyChanged("MinQty", ModelEntityUpdated);
                }
            }
        }

        public decimal? MaxQty
        {
            get { return _MaxQty; }
            set
            {
                if (_MaxQty != value)
                {
                    _MaxQty = value; RaisePropertyChanged("MaxQty", ModelEntityUpdated);
                }
            }
        }

        public decimal? Brate
        {
            get { return _Brate; }
            set
            {
                if (_Brate != value)
                {
                    _Brate = value; RaisePropertyChanged("Brate", ModelEntityUpdated);
                }
            }
        }

        public decimal? price_list
        {
            get { return _price_list; }
            set
            {
                if (_price_list != value)
                {
                    _price_list = value; RaisePropertyChanged("price_list", ModelEntityUpdated);
                }
            }
        }

        public decimal? mrp
        {
            get { return _mrp; }
            set
            {
                if (_mrp != value)
                {
                    _mrp = value; RaisePropertyChanged("mrp", ModelEntityUpdated);
                }
            }
        }

        public decimal? higher_limit
        {
            get { return _higher_limit; }
            set
            {
                if (_higher_limit != value)
                {
                    _higher_limit = value; RaisePropertyChanged("higher_limit", ModelEntityUpdated);
                }
            }
        }

        public decimal? lower_limit
        {
            get { return _lower_limit; }
            set
            {
                if (_lower_limit != value)
                {
                    _lower_limit = value; RaisePropertyChanged("lower_limit", ModelEntityUpdated);
                }
            }
        }

        public string Rmrk
        {
            get { return _Rmrk; }
            set
            {
                if (_Rmrk != value)
                {
                    _Rmrk = value; RaisePropertyChanged("Rmrk", ModelEntityUpdated);
                }
            }
        }
        public bool active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
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
                    _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated);
                }
            }
        }

        public DateTime add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated);
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
                    _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated);
                }
            }
        }

        public DateTime? edit_date
        {
            get { return _edit_date; }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated);
                }
            }
        }
        public string tax_id
        {
            get { return _tax_id; }
            set
            {
                if (_tax_id != value)
                {
                    _tax_id = value; RaisePropertyChanged("tax_id", ModelEntityUpdated);
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
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
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
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
            }
        }
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
                }
            }
        }

        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated);
                }
            }
        }


        public string description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value; RaisePropertyChanged("description", ModelEntityUpdated);
                }
            }
        }

        public string sku
        {
            get { return _sku; }
            set
            {
                if (_sku != value)
                {
                    _sku = value; RaisePropertyChanged("sku", ModelEntityUpdated);
                }
            }
        }
        public string sku_desc
        {
            get { return _sku_desc; }
            set
            {
                if (_sku_desc != value)
                {
                    _sku_desc = value; RaisePropertyChanged("sku_desc", ModelEntityUpdated);
                }
            }
        }
        //public string item_name
        //{
        //    get { return _item_name; }
        //    set
        //    { _item_name = value; RaisePropertyChanged("item_name", ModelEntityUpdated); }
        //}
        public string unit_name
        {
            get { return _unit_name; }
            set
            {
                if (_unit_name != value)
                {
                    _unit_name = value; RaisePropertyChanged("unit_name", ModelEntityUpdated);
                }
            }
        }
        
        //public int SetQty
        //{
        //    get { return _SetQty; }
        //    set
        //    { _SetQty = value; RaisePropertyChanged("SetQty", ModelEntityUpdated); }
        //}

    }
    public class CRM_T001C : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        private int _parent_id;
        private int _part_id;
        private string _ItemCode;
        private string _cstpart_code;
        private string _cstpart_name;
        public string _unit_code;
        private decimal? _quantity;
        private bool _active;
        private string _fin_year;
        private string _posting_period;
        private string _unit_name;
        private string _part_code;
        private int _parent_item_id;
        public string _part_name;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
        public int parent_id
        {
            get { return _parent_id; }
            set
            {
                if (_parent_id != value)
                {
                    _parent_id = value; RaisePropertyChanged("parent_id", ModelEntityUpdated);
                }
            }
        }
        public int part_id
        {
            get { return _part_id; }
            set
            {
                if (_part_id != value)
                {
                    _part_id = value; RaisePropertyChanged("part_id", ModelEntityUpdated);
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
                    _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated);
                }
            }
        }

        public string cstpart_code
        {
            get { return _cstpart_code; }
            set
            {
                if (_cstpart_code != value)
                {
                    _cstpart_code = value; RaisePropertyChanged("cstpart_code", ModelEntityUpdated);
                }
            }
        }
        public string cstpart_name
        {
            get { return _cstpart_name; }
            set
            {
                if (_cstpart_name != value)
                {
                    _cstpart_name = value; RaisePropertyChanged("cstpart_name", ModelEntityUpdated);
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
                    _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated);
                }
            }
        }
        public decimal? quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value; RaisePropertyChanged("quantity", ModelEntityUpdated);
                }
            }
        }

        public bool active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
                }
            }
        }
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
                }
            }
        }

        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated);
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
                    _unit_name = value; RaisePropertyChanged("unit_name", ModelEntityUpdated);
                }
            }
        }

        public string part_code
        {
            get { return _part_code; }
            set
            {
                if (_part_code != value)
                {
                    _part_code = value; RaisePropertyChanged("part_code", ModelEntityUpdated);
                }
            }
        }
        public int parent_item_id
        {
            get { return _parent_item_id; }
            set
            { _parent_item_id = value; RaisePropertyChanged("parent_item_id", ModelEntityUpdated); }
        }
        public string part_name
        {
            get { return _part_name; }
            set
            {
                if (_part_name != value)
                {
                    _part_name = value; RaisePropertyChanged("part_name", ModelEntityUpdated);
                }
            }
        }

        


    }
    public class MultipleContextCRM_T001A
    {
        public List<CRM_T001A_Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<ADM_M022_P> ItemMaster { get; set; }
        public List<ADM_M038_B_P> UnitMaster { get; set; }
        public List<CRM_T001A> MasterEntity { get; set; }
        public ObservableCollection<CRM_T001B> ItemsEntity { get; set; }
        //public List<CRM_T001C> catalogPartsDetails { get; set; }          
        public List<ACC_M013_P> Tax_Master { get; set; }// Tax master

    }
    public class CRM_T001A_Flip
    {
        public string cust_cat_no { get; set; }
        public Nullable<System.DateTime> CatDate { get; set; }
        public string PartyId { get; set; }
        public Nullable<System.DateTime> Fdate { get; set; }
        public Nullable<System.DateTime> Tdate { get; set; }
        public string remark { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string fin_year { get; set; }
        public bool active { get; set; }
        public string description { get; set; }
        public string so_code { get; set; }
        public string po_code { get; set; }
        public string party_name { get; set; }

    }
}