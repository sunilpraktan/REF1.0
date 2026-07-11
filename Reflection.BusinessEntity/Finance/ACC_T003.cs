using Reflection.BusinessEntity.CustomerRelation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public partial class ACC_T003 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }

        private string _doc_cat;
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
        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set { _PartyId = value; RaisePropertyChanged("PartyId"); }

        }
        
        private string _visit_details;
        public string visit_details
        {
            get { return _visit_details; }
            set { _visit_details = value; RaisePropertyChanged("visit_details"); }
        }
        private Nullable<decimal> _advance;
        public Nullable<decimal> advance
        {
            get { return _advance; }
            set { _advance = value; RaisePropertyChanged("advance",ModelEntityUpdated); }
        }
        private string _EmpId;
        public string EmpId
        {
            get { return _EmpId; }
            set { _EmpId = value; RaisePropertyChanged("EmpId"); }
        }
        private string _additional_person;
        public string additional_person
        {
            get { return _additional_person; }
            set { _additional_person = value; RaisePropertyChanged("additional_person"); }
        }
        private string _travel_from;
        public string travel_from
        {

            get { return _travel_from; }
            set { _travel_from = value; RaisePropertyChanged("travel_from"); }
        }
        private string _travel_to;
        public string travel_to
        {
            get { return _travel_to; }
            set { _travel_to = value; RaisePropertyChanged("travel_to"); }
        }
        private string _location;
        public string location
        {
            get { return _location; }
            set { _location = value; RaisePropertyChanged("location"); }
        }
        private string _area;
        public string area
        {
            get { return _area; }
            set { _area = value; RaisePropertyChanged("area"); }
        }
        private Nullable<decimal> _dist_in_km;
        public Nullable<decimal> dist_in_km
        {
            get { return _dist_in_km; }
            set { _dist_in_km = value; RaisePropertyChanged("dist_in_km"); }
        }
        private string _transport_mode;
        public string transport_mode
        {
            get { return _transport_mode; }
            set { _transport_mode = value; RaisePropertyChanged("transport_mode"); }
        }
        private Nullable<decimal> _bal_amount;
        public Nullable<decimal> bal_amount
        {
            get { return _bal_amount; }
            set { _bal_amount = value; RaisePropertyChanged("bal_amount",ModelEntityUpdated); }
        }
        private Nullable<decimal> _approved_amt;
        public Nullable<decimal> approved_amt
        {
            get { return _approved_amt; }
            set { _approved_amt = value; RaisePropertyChanged("approved_amt",ModelEntityUpdated); }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active", ModelEntityUpdated); }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
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
        private string _language;
        public string language
        {
            get { return _language; }
            set { _language = value; RaisePropertyChanged("language"); }
        }

        private string _CustomerNm;
        public string CustomerNm
        {
            get { return _CustomerNm; }
            set { _CustomerNm = value; RaisePropertyChanged("CustomerNm"); }
        }

        private string _EmpName;
        public string EmpName
        {
            get { return _EmpName; }
            set { _EmpName = value; RaisePropertyChanged("EmpName"); }
        }
        
        private Nullable<decimal> _grand_total;
        public Nullable<decimal> grand_total
        {
            get { return _grand_total; }
            set { _grand_total = value; RaisePropertyChanged("grand_total", ModelEntityUpdated); }
        }
        //scalar fields
        private string _amt_in_words;
        public string amt_in_words
        {
            get { return _amt_in_words; }
            set
            {
                _amt_in_words = value;
                RaisePropertyChanged("amt_in_words", ModelEntityUpdated);
            }
        }
        private string _sg_code;
        public string sg_code
        {
            get { return _sg_code; }
            set
            {
                _sg_code = value;
                RaisePropertyChanged("sg_code");
            }
        }
        private string _sales_org;
        public string sales_org
        {
            get { return _sales_org; }
            set
            {
                _sales_org = value;
                RaisePropertyChanged("sales_org");
            }
        }
        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set
            {
                _so_code = value;
                RaisePropertyChanged("so_code");
            }
        }

        private string _sg_name;
        public string sg_name
        {
            get { return _sg_name; }
            set
            {
                _sg_name = value;
                RaisePropertyChanged("sg_name");
            }
        }
        private string _gl_code;
        public string gl_code
        {
            get { return _gl_code; }
            set
            {
                _gl_code = value;
                RaisePropertyChanged("gl_code");
            }
        }
        private string _gl_name;
        public string gl_name
        {
            get { return _gl_name; }
            set
            {
                _gl_name = value;
                RaisePropertyChanged("gl_name");
            }
        }
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set
            {
                _ref_doc_no = value;
                RaisePropertyChanged("ref_doc_no");
            }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set
            {
                _ref_doc_cat = value;
                RaisePropertyChanged("ref_doc_cat");
            }
        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set
            {
                _ref_doc_type = value;
                RaisePropertyChanged("ref_doc_type");
            }
        }
        private string _expense_no;
        public string expense_no
        {
            get { return _expense_no; }
            set
            {
                _expense_no = value;
                RaisePropertyChanged("expense_no");
            }
        }
        private Nullable<System.DateTime> _from_date;
        public Nullable<System.DateTime> from_date
        {
            get { return _from_date; }
            set
            {
                _from_date = value;
                RaisePropertyChanged("from_date");
            }
        }
        private Nullable<System.DateTime> _to_date;
        public Nullable<System.DateTime> to_date
        {
            get { return _to_date; }
            set
            {
                _to_date = value;
                RaisePropertyChanged("to_date");
            }
        }
        public string _vendor_invno;
        public string vendor_invno
        {
            get { return _vendor_invno; }
            set
            {
                _vendor_invno = value;
                RaisePropertyChanged("vendor_invno");
            }
        }
        private string _doc_desc;

        public string doc_desc
        {
            get { return _doc_desc; }
            set { _doc_desc = value; RaisePropertyChanged("doc_desc", ModelEntityUpdated); }
        }
        public string XmlDataDocument_ACC_T003_A { get; set; }
        public string XmlDataDocument_ACC_T003_C { get; set; }
        public string XmlDataDocument_ACC_T003_D { get; set; }
        public string XmlDataDocument_ACC_T003_E { get; set; }
        public string XmlDataDocument_ACC_T003_F { get; set; }
        public string XmlDataDocument_ACC_T003_G { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string XmlDataDocument_Approval { get; set; }
    }

    public partial class ACC_T003_A:ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("_id"); }
        }
        private string _CustomerNm;
        public string CustomerNm
        {
            get { return _CustomerNm; }
            set { _CustomerNm = value; RaisePropertyChanged("CustomerNm"); }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }
        private Nullable<System.DateTime> _expenses_date;
        public Nullable<System.DateTime> expenses_date
        {
            get { return _expenses_date; }
            set { _expenses_date = value; RaisePropertyChanged("expenses_date"); }
        }
        private string _head_code;
        public string head_code
        {
            get { return _head_code; }
            set { _head_code = value; RaisePropertyChanged("head_code"); }
        }
        private string _description;
        public string description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("description"); }
        }
        private Nullable<decimal> _amount;
        public Nullable<decimal> amount
        {
            get { return _amount; }
            set { _amount = value; RaisePropertyChanged("amount",ModelEntityUpdated); }
        }
        private Nullable<decimal> _standard_amt;
        public Nullable<decimal> standard_amt
        {
            get { return _standard_amt; }
            set { _standard_amt = value; RaisePropertyChanged("standard_amt",ModelEntityUpdated); }
        }
        private Nullable<decimal> _short_excess_amt;
        public Nullable<decimal> short_excess_amt
        {
            get { return _short_excess_amt; }
            set { _short_excess_amt = value; RaisePropertyChanged("short_excess_amt",ModelEntityUpdated); }
        }
        private Nullable<decimal> _qty;
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set { _qty = value; RaisePropertyChanged("qty",ModelEntityUpdated); }
        }
        private Nullable<decimal> _unit_price;
        public Nullable<decimal> unit_price
        {
            get { return _unit_price; }
            set { _unit_price = value; RaisePropertyChanged("unit_price",ModelEntityUpdated); }
        }
        private Nullable<decimal> _sub_total;
        public Nullable<decimal> sub_total
        {
            get { return _sub_total; }
            set { _sub_total = value; RaisePropertyChanged("sub_total", ModelEntityUpdated); }
        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set { _remark = value; RaisePropertyChanged("remark"); }
        }
        private string _transport_mode;
        public string transport_mode
        {
            get { return _transport_mode; }
            set { _transport_mode = value; RaisePropertyChanged("transport_mode"); }
        }
        private Nullable<decimal> _approved_amt;
        public Nullable<decimal> approved_amt
        {
            get { return _approved_amt; }
            set { _approved_amt = value; RaisePropertyChanged("approved_amt",ModelEntityUpdated); }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active", ModelEntityUpdated); }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
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
        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set { _PartyId = value; RaisePropertyChanged("PartyId"); }

        }
        private string _travel_from;
        public string travel_from
        {

            get { return _travel_from; }
            set { _travel_from = value; RaisePropertyChanged("travel_from"); }
        }
        private string _travel_to;
        public string travel_to
        {
            get { return _travel_to; }
            set { _travel_to = value; RaisePropertyChanged("travel_to"); }
        }
        private Nullable<decimal> _dist_in_km;
        public Nullable<decimal> dist_in_km
        {
            get { return _dist_in_km; }
            set { _dist_in_km = value; RaisePropertyChanged("dist_in_km"); }
        }
        private string _gl_code;
        public string gl_code
        {
            get { return _gl_code; }
            set
            {
                _gl_code = value;
                RaisePropertyChanged("gl_code");
            } 
        }
        private string _gl_name;
        public string gl_name
        {
            get { return _gl_name; }
            set
            {
                _gl_name = value;
                RaisePropertyChanged("gl_name");
            }
        }
        private string _food_expense;
        public string food_expense
        {
            get { return _food_expense; }
            set
            {
                _food_expense = value;
                RaisePropertyChanged("food_expense");
            }
        }
        private Nullable<decimal> _food_exp_amt;
        public Nullable<decimal> food_exp_amt
        {
            get { return _food_exp_amt; }
            set
            {
                _food_exp_amt = value;
                RaisePropertyChanged("food_exp_amt",ModelEntityUpdated);
            }
        }
        private string _misc_detail;
        public string misc_detail
        {
            get { return _misc_detail; }
            set
            {
                _misc_detail = value;
                RaisePropertyChanged("misc_detail");
            }
        }
        private Nullable<decimal> _misc_amt;
        public Nullable<decimal> misc_amt
        {
            get { return _misc_amt; }
            set
            {
                _misc_amt = value;
                RaisePropertyChanged("misc_amt", ModelEntityUpdated);
            }
        }
        private string _print_stat;
        public string print_stat
        {
            get { return _print_stat; }
            set
            {
                _print_stat = value;
                RaisePropertyChanged("print_stat");
            }
        }
        private Nullable<decimal> _print_stat_amt;
        public Nullable<decimal> print_stat_amt
        {
            get { return _print_stat_amt; }
            set
            {
                _print_stat_amt = value;
                RaisePropertyChanged("print_stat_amt", ModelEntityUpdated);
            }
        }
        private string _other_expense;
        public string other_expense
        {
            get { return _other_expense; }
            set
            {
                _other_expense = value;
                RaisePropertyChanged("other_expense");
            }
        }
        private Nullable<decimal> _other_exp_amt;
        public Nullable<decimal> other_exp_amt
        {
            get { return _other_exp_amt; }
            set
            {
                _other_exp_amt = value;
                RaisePropertyChanged("other_exp_amt", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _budget_amt;
        public Nullable<decimal> budget_amt
        {
            get { return _budget_amt; }
            set
            {
                _budget_amt = value;
                RaisePropertyChanged("budget_amt", ModelEntityUpdated);
            }
        }
        private string _sono;
        public string sono
        {
            get { return _sono; }
            set
            {
                _sono = value;
                RaisePropertyChanged("sono", ModelEntityUpdated);
            }
        }
    }

    public partial class ACC_T003_C :ObjectBase  //Employee
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
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
        private string _EmpId;
        public string EmpId
        {
            get { return _EmpId; }
            set
            {
                _EmpId = value;
                RaisePropertyChanged("EmpId");
            }
        }
        private string _EmpName;
        public string EmpName
        {
            get { return _EmpName; }
            set
            {
                _EmpName = value;
                RaisePropertyChanged("EmpName");
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
        private bool _active;
        public bool active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active", ModelEntityUpdated);
            }
        }
        private string _int_ext;
        public string int_ext
        {
            get { return _int_ext; }
            set
            {
                _int_ext = value;
                RaisePropertyChanged("int_ext");
            }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
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
        private Nullable<System.DateTime> _from_date;
        public Nullable<System.DateTime> from_date
        {
            get { return _from_date; }
            set { _from_date = value; RaisePropertyChanged("from_date"); }

        }
        private Nullable<System.DateTime> _to_date { get; set; }
        public Nullable<System.DateTime> to_date
        {
            get { return _to_date; }
            set { _to_date = value; RaisePropertyChanged("to_date"); }

        }
        private Nullable<decimal> _no_of_day;
        public Nullable<decimal> no_of_day
        {
            get { return _no_of_day; }
            set { _no_of_day = value; RaisePropertyChanged("no_of_day", ModelEntityUpdated); }


        }
        private Nullable<decimal> _day_charge;
        public Nullable<decimal> day_charge
        {
            get { return _day_charge; }
            set { _day_charge = value; RaisePropertyChanged("day_charge", ModelEntityUpdated); }


        }
        private Nullable<decimal> _total_amt;
        public Nullable<decimal> total_amt
        {
            get { return _total_amt; }
            set { _total_amt = value; RaisePropertyChanged("total_amt", ModelEntityUpdated); }


        }
        private Nullable<decimal> _expense_amt;
        public Nullable<decimal> expense_amt
        {
            get { return _expense_amt; }
            set { _expense_amt = value; RaisePropertyChanged("expense_amt", ModelEntityUpdated); }

        }
        private Nullable<decimal> _net_balance;
        public Nullable<decimal> net_balance
        {
            get { return _net_balance; }
            set { _net_balance = value; RaisePropertyChanged("net_balance", ModelEntityUpdated); }

        }
      
    }

    public partial class ACC_T003_D:ObjectBase  //Work Order
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
        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set
            {
                _PartyId = value;
                RaisePropertyChanged("PartyId");
            }
        }
        private string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set
            {
                _PartyNm = value;
                RaisePropertyChanged("PartyNm");
            }
        }
        private string _work_order_no;
        public string work_order_no
        {
            get { return _work_order_no; }
            set
            {
                _work_order_no = value;
                RaisePropertyChanged("work_order_no");
            }
        }
        private string _work_location;
        public string work_location
        {
            get { return _work_location; }
            set
            {
                _work_location = value;
                RaisePropertyChanged("work_location");
            }
        }
        private Nullable<System.DateTime> _date_of_work;
        public Nullable<System.DateTime> date_of_work
        {
            get { return _date_of_work; }
            set
            {
                _date_of_work = value;
                RaisePropertyChanged("date_of_work");
            }
        }
        private string _work_desc;
        public string work_desc
        {
            get { return _work_desc; }
            set
            {
                _work_desc = value;
                RaisePropertyChanged("work_desc");
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
        private bool _active;
        public bool active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
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
        private Nullable<System.DateTime> _from_date;
        public Nullable<System.DateTime> from_date
        {
            get { return _from_date; }
            set
            {
                _from_date = value;
                RaisePropertyChanged("from_date");
            }
        }
        private Nullable<System.DateTime> _to_date;
        public Nullable<System.DateTime> to_date
        {
            get { return _to_date; }
            set
            {
                _to_date = value;
                RaisePropertyChanged("to_date");
            }
        }
        private string _project_id { get; set; }
        public string project_id
        {
            get { return _project_id; }
            set { _project_id = value; RaisePropertyChanged("project_id"); }
        }
        private string _project_name;
        public string project_name
        {
            get { return _project_name; }
            set { _project_name = value; RaisePropertyChanged("project_name"); }
        }
    }

    public partial class ACC_T003_E:ObjectBase  //Transport 
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
        private Nullable<System.DateTime> _date_of_journey;
        public Nullable<System.DateTime> date_of_journey
        {
            get { return _date_of_journey; }
            set
            {
                _date_of_journey = value;
                RaisePropertyChanged("date_of_journey");
            }
        }
        private string _trans_mode;
        public string trans_mode
        {
            get { return _trans_mode; }
            set
            {
                _trans_mode = value;
                RaisePropertyChanged("trans_mode");
            }
        }
        private string _travel_from;
        public string travel_from
        {
            get { return _travel_from; }
            set
            {
                _travel_from = value;
                RaisePropertyChanged("travel_from");
            }
        }
        private string _travel_to;
        public string travel_to
        {
            get { return _travel_to; }
            set
            {
                _travel_to = value;
                RaisePropertyChanged("travel_to");
            }
        }
        private string _dist_in_km;
        public string dist_in_km
        {
            get { return _dist_in_km; }
            set
            {
                _dist_in_km = value;
                RaisePropertyChanged("dist_in_km");
            }
        }
        private Nullable<bool> _own_vehicle;
        public Nullable<bool> own_vehicle
        {
            get { return _own_vehicle; }
            set
            {
                _own_vehicle = value;
                RaisePropertyChanged("own_vehicle");
            }
        }
        private string _transporter;
        public string transporter
        {
            get { return _transporter; }
            set
            {
                _transporter = value;
                RaisePropertyChanged("transporter");
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
        private bool _active;
        public bool active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
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
        private int _vehicle_id;
        public int vehicle_id
        {
            get { return _vehicle_id; }
            set { _vehicle_id = value; RaisePropertyChanged("vehicle_id"); }

        }
        private string _vehicle_no;
        public string vehicle_no
        {
            get { return _vehicle_no; }
            set { _vehicle_no = value; RaisePropertyChanged("vehicle_no"); }

        }
        private string _oil_type;
        public string oil_type
        {
            get { return _oil_type; }
            set { _oil_type = value; RaisePropertyChanged("oil_type"); }

        }
        private string _driver_id;
        public string driver_id
        {
            get { return _driver_id; }
            set { _driver_id = value; RaisePropertyChanged("driver_id"); }

        }
        private Nullable<System.DateTime> _from_date;
        public Nullable<System.DateTime> from_date
        {
            get { return _from_date; }
            set
            {
                _from_date = value;
                RaisePropertyChanged("from_date");
            }
        }
        private Nullable<System.DateTime> _to_date;
        public Nullable<System.DateTime> to_date
        {
            get { return _to_date; }
            set
            {
                _to_date = value;
                RaisePropertyChanged("to_date");
            }
        }
    }

    public partial class ACC_T003_F:ObjectBase //Advance 
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
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
        private Nullable<System.DateTime> _date_of_advance;
        public Nullable<System.DateTime> date_of_advance
        {
            get { return _date_of_advance; }
            set
            {
                _date_of_advance = value;
                RaisePropertyChanged("date_of_advance");
            }
        }
        private string _payment_mode;
        public string payment_mode
        {
            get { return _payment_mode; }
            set
            {
                _payment_mode = value;
                RaisePropertyChanged("payment_mode");
            }
        }
        private Nullable<decimal> _amount;
        public Nullable<decimal> amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                RaisePropertyChanged("amount",ModelEntityUpdated);
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
        private bool _active;
        public bool active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active", ModelEntityUpdated);
            }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
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
        private string _paid_by;
        public string paid_by
        {
            get { return _paid_by; }
            set { _paid_by = value; RaisePropertyChanged("paid_by"); }

        }
        private Nullable<decimal> _paid_amt;
        public Nullable<decimal> paid_amt
        {
            get { return _paid_amt; }
            set { _paid_amt = value; RaisePropertyChanged("paid_amt", ModelEntityUpdated); }

        }
        private Nullable<decimal> _paid_by_amt;
        public Nullable<decimal> paid_by_amt
        {
            get { return _paid_by_amt; }
            set { _paid_by_amt = value; RaisePropertyChanged("paid_by_amt", ModelEntityUpdated); }

        }
    }

    public partial class ACC_T003_G :ObjectBase //Commercial Invoice
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

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
        private string _com_inv_no;
        public string com_inv_no
        {
            get { return _com_inv_no; }
            set
            {
                _com_inv_no = value;
                RaisePropertyChanged("com_inv_no");
            }
        }
        private Nullable<decimal> _amount;
        public Nullable<decimal> amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                RaisePropertyChanged("amount");
            }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat");
            }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type");
            }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
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
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
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
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
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
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }
        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period");
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
        private Nullable<decimal> _para1;
        public Nullable<decimal> para1
        {
            get { return _para1; }
            set
            {
                _para1 = value;
                RaisePropertyChanged("para1");
            }
        }
        private Nullable<int> _para2;
        public Nullable<int> para2
        {
            get { return _para2; }
            set
            {
                _para2 = value;
                RaisePropertyChanged("para2");
            }
        }
        private string _para3;
        public string para3
        {
            get { return _para3; }
            set
            {
                _para3 = value;
                RaisePropertyChanged("para3");
            }
        }
    }

    public class MultipleContext_ACC_T003
    {
        public List<ACC_T003> MasterEntity { get; set; }
        public ObservableCollection<ACC_T003_A> ItemsEntity { get; set; }
        public ObservableCollection<ACC_T003_C> Employee { get; set; }
        public ObservableCollection<ACC_T003_D> WorkOrder { get; set; }
        public ObservableCollection<ACC_T003_E> Transport { get; set; }
        public ObservableCollection<ACC_T003_F> Advance { get; set; }
        public ObservableCollection<ACC_T003_G> ComInvoice { get; set; }
        public List<SYS_M002> DocTypeInfo { get; set; }
        public List<ACC_T003_Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> CustomerDetails { get; set; }
        public List<ADM_M024_POP> EmpDetails { get; set; }
        public List<ACC_T003_B_P> HeadDetailsForGrid { get; set; }
        public List<ACC_M003_P> GlcodeDetails { get; set; }
        public List<ADM_M003_P> LocationMaster { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public List<ACC_T003_P> LocalConDetails { get; set; }
        public List<ACC_T003_H_POPUP> VehicleDetails { get; set; }
        public List<ADM_M024_POP> DriverDetails { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<SEL_T001_P> SalesList { get; set; }
        public List<Approval> ApprovalData { get; set; }
        public List<PRO_T001_P> Project { get; set; }
    }

}
