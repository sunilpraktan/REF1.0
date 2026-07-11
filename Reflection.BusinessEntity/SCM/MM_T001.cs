using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.BusinessEntity.SCM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Reflection.BusinessEntity
{
    public class MM_T001 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

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

        private Nullable<int> _id;
        public Nullable<int> id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
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
                    RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
            }
        }
        private Nullable<System.DateTime> _doc_edate;
        public Nullable<System.DateTime> doc_edate
        {
            get { return _doc_edate; }
            set { _doc_edate = value; RaisePropertyChanged("doc_edate"); }
        }

        private Nullable<System.DateTime> _doc_date;
        [Required(ErrorMessage = "Field 'Document Date' is required.")]
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set
            {
                _doc_date = value;
                RaisePropertyChanged("doc_date");
            }
        }


        private Nullable<int> _doc_year;
        public Nullable<int> doc_year
        {
            get
            {
                return _doc_year;
            }

            set
            {
                _doc_year = value;
                RaisePropertyChanged("doc_year");
            }
        }



        private string _ge_no;
        public string ge_no
        {
            get
            {
                return _ge_no;
            }

            set
            {
                _ge_no = value;
                RaisePropertyChanged("ge_no");
            }
        }

        private Nullable<System.DateTime> _ge_date;
        public Nullable<System.DateTime> ge_date
        {
            get
            {
                return _ge_date;
            }

            set
            {
                _ge_date = value;
                RaisePropertyChanged("ge_date");
            }
        }

        private string _doc_code;
        public string doc_code
        {
            get { return _doc_code; }
            set
            {
                _doc_code = value;
                RaisePropertyChanged("doc_code");
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

        private string _source_doc_cat;
        public string source_doc_cat
        {
            get { return _source_doc_cat; }
            set
            {
                _source_doc_cat = value;
                RaisePropertyChanged("source_doc_cat");
            }
        }

        private string _source_doc_type;
        public string source_doc_type
        {
            get { return _source_doc_type; }
            set
            {
                _source_doc_type = value;
                RaisePropertyChanged("source_doc_type");
            }
        }

        private string _source_doc_no;
        public string source_doc_no
        {
            get { return _source_doc_no; }
            set
            {
                _source_doc_no = value;
                RaisePropertyChanged("source_doc_no");
            }
        }

        private string _vendor;
        public string vendor
        {
            get { return _vendor; }
            set
            {
                _vendor = value;
                RaisePropertyChanged("vendor");
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
        private Nullable<System.DateTime> _post_date;
        [Required(ErrorMessage = "Field 'Posting Date' is required.")]
        public Nullable<System.DateTime> post_date
        {
            get { return _post_date; }
            set
            {
                _post_date = value;
                RaisePropertyChanged("post_date");
            }
        }

        private string _bill_ladding;
        public string bill_ladding
        {
            get
            {
                return _bill_ladding;
            }

            set
            {
                _bill_ladding = value;
                RaisePropertyChanged("bill_ladding");
            }
        }

        private Nullable<System.DateTime> _bill_ladding_dt;
        public Nullable<System.DateTime> bill_ladding_dt
        {
            get
            {
                return _bill_ladding_dt;
            }

            set
            {
                _bill_ladding_dt = value;
                RaisePropertyChanged("bill_ladding_dt");
            }
        }

        private string _grgi_slip_no;
        public string grgi_slip_no
        {
            get
            {
                return _grgi_slip_no;
            }

            set
            {
                _grgi_slip_no = value;
                RaisePropertyChanged("grgi_slip_no");
            }
        }

        private string _del_note;
        public string del_note
        {
            get
            {
                return _del_note;
            }

            set
            {
                _del_note = value;
                RaisePropertyChanged("del_note");
            }
        }

        private Nullable<System.DateTime> _del_note_date;
        public Nullable<System.DateTime> del_note_date
        {
            get
            {
                return _del_note_date;
            }

            set
            {
                _del_note_date = value;
                RaisePropertyChanged("del_note_date");
            }
        }

        private Nullable<System.DateTime> _receipt_date;
        public Nullable<System.DateTime> receipt_date
        {
            get
            {
                return _receipt_date;
            }

            set
            {
                _receipt_date = value;
                RaisePropertyChanged("receipt_date");
            }
        }

        private string _tr_mode;
        public string tr_mode
        {
            get
            {
                return _tr_mode;
            }

            set
            {
                _tr_mode = value;
                RaisePropertyChanged("tr_mode");
            }
        }
        private string _tr_party;
        public string tr_party
        {
            get { return _tr_party; }
            set
            {
                _tr_party = value;
                RaisePropertyChanged("tr_party");
            }
        }
        private string _tr_type;
        public string tr_type
        {
            get { return _tr_type; }
            set
            {
                _tr_type = value;
                RaisePropertyChanged("tr_type");
            }
        }
        private Nullable<System.TimeSpan> _entry_time;
        public Nullable<System.TimeSpan> entry_time
        {
            get
            {
                return _entry_time;
            }

            set
            {
                _entry_time = value;
                RaisePropertyChanged("entry_time");
            }
        }

        private string _ref_doc;
        public string ref_doc
        {
            get { return _ref_doc; }
            set
            {
                _ref_doc = value;
                RaisePropertyChanged("ref_doc");
            }
        }


        private string _order_doc_type;
        public string order_doc_type
        {
            get { return _order_doc_type; }
            set
            {
                _order_doc_type = value;
                RaisePropertyChanged("order_doc_type");
            }
        }

        private string _order_doc_no;
        public string order_doc_no
        {
            get { return _order_doc_no; }
            set
            {
                _order_doc_no = value;
                RaisePropertyChanged("order_doc_no");
            }
        }


        private Nullable<System.DateTime> _ref_doc_date;
        public Nullable<System.DateTime> ref_doc_date
        {
            get
            {
                return _ref_doc_date;
            }

            set
            {
                _ref_doc_date = value;
                RaisePropertyChanged("ref_doc_date");
            }
        }
        private string _time_zone;
        public string time_zone
        {
            get
            {
                return _time_zone;
            }

            set
            {
                _time_zone = value;
                RaisePropertyChanged("time_zone");
            }
        }

        private string _mov_tp;
        [Required(ErrorMessage = "Field 'Movement Type' is required.")]

        public string mov_tp
        {
            get { return _mov_tp; }
            set
            {
                _mov_tp = value;
                RaisePropertyChanged("mov_tp", ModelEntityUpdated);
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

        private string _dept_code;
        public string dept_code
        {
            get { return _dept_code; }
            set
            {
                _dept_code = value;
                RaisePropertyChanged("dept_code");
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

        private string _notes;
        public string notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                RaisePropertyChanged("notes");
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

        private string _t_status;
        public string t_status
        {
            get
            {
                return _t_status;
            }

            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value;
                    RaisePropertyChanged("location_Id", ModelEntityUpdated);
                }
            }
        }
        private string _vehicle_no;
        public string vehicle_no
        {
            get
            {
                return _vehicle_no;
            }

            set
            {
                _vehicle_no = value;
                RaisePropertyChanged("vehicle_no");
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

        private string _cash_credit_pur;
        public string cash_credit_pur
        {
            get { return _cash_credit_pur; }
            set
            {
                _cash_credit_pur = value;
                RaisePropertyChanged("cash_credit_pur");
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

        private string _mov_name;
        public string mov_name
        {
            get { return _mov_name; }
            set
            {
                _mov_name = value;
                RaisePropertyChanged("mov_name");
            }
        }
        private string _Req_Name;
        public string Req_Name
        {
            get { return _Req_Name; }
            set
            {
                _Req_Name = value;
                RaisePropertyChanged("Req_Name");
            }
        }
        private string _Dept_Name;
        public string Dept_Name
        {
            get { return _Dept_Name; }
            set
            {
                _Dept_Name = value;
                RaisePropertyChanged("Dept_Name");
            }
        }

        private string _tranp_agency_name;
        public string tranp_agency_name
        {
            get { return _tranp_agency_name; }
            set
            {
                _tranp_agency_name = value;
                RaisePropertyChanged("tranp_agency_name");
            }
        }


        private string _PlantName;
        public string PlantName
        {
            get { return _PlantName; }
            set
            {
                _PlantName = value;
                RaisePropertyChanged("PlantName");
            }
        }


        private string _vendor_name;
        [DisplayName("Vendor Number")]
        public string vendor_name
        {
            get { return _vendor_name; }
            set
            {
                _vendor_name = value;
                RaisePropertyChanged("vendor_name");
            }
        }
        private string _sending_plant;
        public string sending_plant
        {
            get { return _sending_plant; }
            set
            {
                _sending_plant = value;
                RaisePropertyChanged("sending_plant");
            }
        }

        private string _rec_plant;
        public string rec_plant
        {
            get { return _rec_plant; }
            set
            {
                _rec_plant = value;
                RaisePropertyChanged("rec_plant");
            }
        }

        private string _sendplantnm;
        public string sendplantnm
        {
            get { return _sendplantnm; }
            set
            {
                _sendplantnm = value;
                RaisePropertyChanged("sendplantnm");
            }
        }

        private string _recplantnm;
        public string recplantnm
        {
            get { return _recplantnm; }
            set
            {
                _recplantnm = value;
                RaisePropertyChanged("recplantnm");
            }
        }

        //scalar
        private int _ink_id;
        public int ink_id
        {
            get { return _ink_id; }
            set
            {
                _ink_id = value;
                RaisePropertyChanged("ink_id");
            }
        }

        private string _ink;
        public string ink
        {
            get { return _ink; }
            set
            {
                _ink = value;
                RaisePropertyChanged("ink");
            }
        }

        private int _ild_id;
        public int ild_id
        {
            get { return _ild_id; }
            set
            {
                _ild_id = value;
                RaisePropertyChanged("ild_id");
            }
        }

        private string _ild;
        public string ild
        {
            get { return _ild; }
            set
            {
                _ild = value;
                RaisePropertyChanged("ild");
            }
        }

        private Nullable<System.DateTime> _From_Date;
        public Nullable<System.DateTime> From_Date
        {
            get { return _From_Date; }
            set
            {
                _From_Date = value;
                RaisePropertyChanged("From_Date");
            }
        }

        private Nullable<System.DateTime> _ProdDate;
        public Nullable<System.DateTime> ProdDate
        {
            get { return _ProdDate; }
            set
            {
                _ProdDate = value;
                RaisePropertyChanged("ProdDate");
            }
        }

        private Nullable<System.DateTime> _ToDate;
        public Nullable<System.DateTime> ToDate
        {
            get { return _ToDate; }
            set
            {
                _ToDate = value;
                RaisePropertyChanged("ToDate");
            }
        }

        private string _Grade;
        public string Grade
        {
            get { return _Grade; }
            set
            {
                _Grade = value;
                RaisePropertyChanged("Grade");
            }
        }

        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set
            {
                _po_code = value;
                RaisePropertyChanged("po_code");
            }
        }

        private string _pg_code;
        public string pg_code
        {
            get { return _pg_code; }
            set
            {
                _pg_code = value;
                RaisePropertyChanged("pg_code");
            }
        }

        private string _pur_org;
        public string pur_org
        {
            get { return _pur_org; }
            set
            {
                _pur_org = value;
                RaisePropertyChanged("pur_org");
            }
        }

        private string _pg_name;
        public string pg_name
        {
            get { return _pg_name; }
            set
            {
                _pg_name = value;
                RaisePropertyChanged("pg_name");
            }
        }

        private string _doc_history_no;
        public string doc_history_no
        {
            get { return _doc_history_no; }
            set { _doc_history_no = value; RaisePropertyChanged("doc_history_no"); }
        }

        private string _com_inv_no;
        public string com_inv_no
        {
            get { return _com_inv_no; }
            set { _com_inv_no = value; RaisePropertyChanged("com_inv_no"); }
        }


        //New Fields Added on 12/12/2016

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set { _curr_code = value; RaisePropertyChanged("curr_code"); }
        }

        private Nullable<decimal> _amt_doccurr;
        public Nullable<decimal> amt_doccurr
        {
            get { return _amt_doccurr; }
            set { _amt_doccurr = value; RaisePropertyChanged("amt_doccurr"); }
        }

        private Nullable<decimal> _amt_loccurr;
        public Nullable<decimal> amt_loccurr
        {
            get { return _amt_loccurr; }
            set { _amt_loccurr = value; RaisePropertyChanged("amt_loccurr"); }
        }

        private Nullable<decimal> _ex_rate;
        public Nullable<decimal> ex_rate
        {
            get { return _ex_rate; }
            set { _ex_rate = value; RaisePropertyChanged("ex_rate"); }
        }

        private Nullable<bool> _debcr_ind;
        public Nullable<bool> debcr_ind
        {
            get { return _debcr_ind; }
            set { _debcr_ind = value; RaisePropertyChanged("debcr_ind"); }
        }

        private string _gl_code;
        public string gl_code
        {
            get { return _gl_code; }
            set { _gl_code = value; RaisePropertyChanged("gl_code"); }
        }

        private string _posting_key;
        public string posting_key
        {
            get { return _posting_key; }
            set { _posting_key = value; RaisePropertyChanged("posting_key"); }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }

        private string _status_remark;
        public string status_remark
        {
            get { return _status_remark; }
            set { _status_remark = value; RaisePropertyChanged("status_remark"); }
        }

        private string _way_bill_no;
        public string way_bill_no
        {
            get { return _way_bill_no; }
            set { _way_bill_no = value; RaisePropertyChanged("way_bill_no"); }
        }

        private Nullable<System.DateTime> _way_bill_date;
        public Nullable<System.DateTime> way_bill_date
        {
            get { return _way_bill_date; }
            set { _way_bill_date = value; RaisePropertyChanged("way_bill_date"); }
        }

        private Nullable<decimal> _way_bill_value;
        public Nullable<decimal> way_bill_value
        {
            get { return _way_bill_value; }
            set { _way_bill_value = value; RaisePropertyChanged("way_bill_value"); }
        }

        private string _project_id;
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

        private string _project_loc;
        public string project_loc
        {
            get { return _project_loc; }
            set { _project_loc = value; RaisePropertyChanged("project_loc"); }
        }

        private string _sono;
        public string sono
        {
            get { return _sono; }
            set { _sono = value; RaisePropertyChanged("sono"); }
        }

        private string _bom_no;
        public string bom_no
        {
            get { return _bom_no; }
            set { _bom_no = value; RaisePropertyChanged("bom_no"); }
        }
        private string _t_display;
        public string t_display
        {
            get
            {
                return _t_display;
            }

            set
            {
                _t_display = value;
                RaisePropertyChanged("t_display");
            }
        }
        private DateTime _bf_FromDate;
        public DateTime bf_FromDate
        {
            get { return _bf_FromDate; }
            set
            {
                if (_bf_FromDate != value)
                {
                    _bf_FromDate = value;
                    RaisePropertyChanged("bf_FromDate");
                }
            }
        }

        private DateTime _bf_ToDate;
        public DateTime bf_ToDate
        {
            get { return _bf_ToDate; }
            set
            {
                if (_bf_ToDate != value)
                {
                    _bf_ToDate = value;
                    RaisePropertyChanged("bf_ToDate");
                }
            }
        }

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
        #region //Filter Search Variables
        private DateTime? _Fltr_FrmDate;
        public DateTime? Fltr_FrmDate   //Production FrmDate
        {
            get { return _Fltr_FrmDate; }
            set
            {
                if (_Fltr_FrmDate != value)
                {
                    _Fltr_FrmDate = value;
                    RaisePropertyChanged("Fltr_FrmDate");
                }
            }
        }
        private DateTime? _Fltr_ToDate;
        public DateTime? Fltr_ToDate    //Production ToDate
        {

            get { return _Fltr_ToDate; }
            set
            {
                if (_Fltr_ToDate != value)
                {
                    _Fltr_ToDate = value;
                    RaisePropertyChanged("Fltr_ToDate");
                }
            }
        }
        private string _Fltr_t_status;
        public string Fltr_t_status
        {
            get { return _Fltr_t_status; }
            set
            {
                if (_Fltr_t_status != value)
                {
                    _Fltr_t_status = value;
                    RaisePropertyChanged("Fltr_t_status");
                }
            }
        }
        private string _Fltr_t_display;
        public string Fltr_t_display
        {
            get { return _Fltr_t_display; }
            set
            {
                if (_Fltr_t_display != value)
                {
                    _Fltr_t_display = value;
                    RaisePropertyChanged("Fltr_t_display");
                }
            }
        }
        private string _Fltr_doc_type;
        public string Fltr_doc_type
        {
            get { return _Fltr_doc_type; }
            set
            {
                if (_Fltr_doc_type != value)
                {
                    _Fltr_doc_type = value;
                    RaisePropertyChanged("Fltr_doc_type");
                }
            }
        }
        private bool _Fltr_active;
        public bool Fltr_active
        {
            get { return _Fltr_active; }
            set
            {
                if (_Fltr_active != value)
                {
                    _Fltr_active = value;
                    RaisePropertyChanged("Fltr_active");
                }
            }
        }
        private string _Fltr_PartyId;
        public string Fltr_PartyId
        {
            get { return _Fltr_PartyId; }
            set
            {
                if (_Fltr_PartyId != value)
                {
                    _Fltr_PartyId = value;
                    RaisePropertyChanged("Fltr_PartyId");
                }
            }
        }
        private string _Fltr_PartyNm;
        public string Fltr_PartyNm
        {
            get { return _Fltr_PartyNm; }
            set
            {
                if (_Fltr_PartyNm != value)
                {
                    _Fltr_PartyNm = value;
                    RaisePropertyChanged("Fltr_PartyNm");
                }
            }
        }
        #endregion
        private string _tr_name;
        public string tr_name
        {
            get
            {
                return _tr_name;
            }

            set
            {
                _tr_name = value;
                RaisePropertyChanged("tr_name");
            }
        }
        private decimal? _qty;
        public decimal? qty
        {
            get { return _qty; }
            set { _qty = value; RaisePropertyChanged("qty"); }
        }
        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set
            {
                if (_barcode != value)
                {
                    _barcode = value;
                    RaisePropertyChanged("barcode");
                }
            }
        }
        public string XmlDataDocument_MM_T001 { get; set; }
        public string XmlDataDocument_MM_T001_A { get; set; }
        public string XmlDataDocument_MM_T001_B { get; set; }
        public string XmlDataDocument_MM_T001_C { get; set; }
        public string XML_DOC_ATTACHMENT { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }

        public string party_address { get; set; }
        public string billing_address { get; set; }
        public string delivery_address { get; set; }
        public string add_code_del { get; set; }
        public string add_code_bil { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public string party_name { get; set; }
        public string doc_type_name { get; set; }
        public string released_by { get; set; }

    }
    public class MM_T001_A : ObjectBase
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
        private int _line_id;
        public int line_id
        {
            get { return _line_id; }
            set
            {
                _line_id = value;
                RaisePropertyChanged("line_id");
            }
        }
        private Nullable<int> _sr_no;
        [DisplayName("SrNo.")]
        public Nullable<int> sr_no
        {
            get { return _sr_no; }
            set { _sr_no = value; RaisePropertyChanged("sr_no"); }
        }
        private string _group_code;
        public string group_code
        {
            get { return _group_code; }
            set
            {
                _group_code = value;
                RaisePropertyChanged("group_code");
            }
        }
        private string _group_company;
        public string group_company
        {
            get { return _group_company; }
            set
            {
                _group_company = value;
                RaisePropertyChanged("group_company");
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
        private Nullable<int> _doc_year;
        public Nullable<int> doc_year
        {
            get { return _doc_year; }
            set { _doc_year = value; RaisePropertyChanged("doc_year"); }
        }
        private Nullable<System.DateTime> _doc_edate;
        public Nullable<System.DateTime> doc_edate
        {
            get { return _doc_edate; }
            set { _doc_edate = value; RaisePropertyChanged("doc_edate"); }
        }
        private Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set { _doc_date = value; RaisePropertyChanged("doc_date"); }
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

        private string _mov_tp;
        public string mov_tp
        {
            get { return _mov_tp; }
            set
            {
                _mov_tp = value;
                RaisePropertyChanged("mov_tp");
            }
        }


        private string _wa_code;
        public string wa_code
        {
            get { return _wa_code; }
            set
            {
                _wa_code = value;
                RaisePropertyChanged("wa_code");
            }
        }
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

        private string _store_bin_code;
        public string store_bin_code
        {
            get { return _store_bin_code; }
            set
            {
                _store_bin_code = value;
                RaisePropertyChanged("store_bin_code");
            }
        }

        private string _mat_no;
        public string mat_no
        {
            get { return _mat_no; }
            set
            {
                _mat_no = value;
                RaisePropertyChanged("mat_no");
            }
        }

        private string _mov_ind;
        public string mov_ind
        {
            get { return _mov_ind; }
            set
            {
                _mov_ind = value;
                RaisePropertyChanged("mov_ind");
            }
        }

        private Nullable<int> _wear_mov_tp;
        public Nullable<int> wear_mov_tp
        {
            get
            {
                return _wear_mov_tp;
            }

            set
            {
                _wear_mov_tp = value;
                RaisePropertyChanged("wear_mov_tp");
            }
        }

        private string _wh_mov_no;
        public string wh_mov_no
        {
            get { return _wh_mov_no; }
            set
            {
                _wh_mov_no = value;
                RaisePropertyChanged("wh_mov_no");
            }
        }

        private string _sp_stock_ind;
        public string sp_stock_ind
        {
            get { return _sp_stock_ind; }
            set
            {
                _sp_stock_ind = value;
                RaisePropertyChanged("sp_stock_ind");
            }
        }

        private string _stock_type;
        public string stock_type
        {
            get { return _stock_type; }
            set
            {
                _stock_type = value;
                RaisePropertyChanged("stock_type");
            }
        }
        private Nullable<decimal> _c_factor;
        public Nullable<decimal> c_factor
        {
            get { return _c_factor; }
            set
            {
                _c_factor = value;
                RaisePropertyChanged("c_factor");
            }
        }
        private string _batch_no;
        public string batch_no
        {
            get { return _batch_no; }
            set
            {
                _batch_no = value;
                RaisePropertyChanged("batch_no");
            }
        }

        private Nullable<bool> _batch_split;
        public Nullable<bool> batch_split
        {
            get { return _batch_split; }
            set
            {
                _batch_split = value;
                RaisePropertyChanged("batch_split");
            }
        }

        private string _batch_rus;
        public string batch_rus
        {
            get
            {
                return _batch_rus;
            }

            set
            {
                _batch_rus = value;
                RaisePropertyChanged("batch_rus");
            }
        }

        private string _ItemCode;
        [Required(ErrorMessage = "Field 'Item' is required.")]
        [DisplayName("Item")]
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                _ItemCode = value; RaisePropertyChanged("ItemCode");
                RaisePropertyChanged("ItemCode", ModelEntityUpdated);
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

        private string _sku_desc;
        public string sku_desc
        {
            get { return _sku_desc; }
            set
            {
                _sku_desc = value;
                RaisePropertyChanged("sku_desc");
            }
        }
        private string _vendor;
        public string vendor
        {
            get
            {
                return _vendor;
            }

            set
            {
                _vendor = value;
                RaisePropertyChanged("vendor");
            }
        }

        private string _PartyId;
        public string PartyId
        {
            get
            {
                return _PartyId;
            }

            set
            {
                _PartyId = value;
                RaisePropertyChanged("PartyId");
            }
        }

        private string _sono;
        public string sono
        {
            get { return _sono; }
            set
            {
                _sono = value;
                RaisePropertyChanged("sono");
            }
        }

        private string _so_item_cd;
        public string so_item_cd
        {
            get { return _so_item_cd; }
            set
            {
                _so_item_cd = value;
                RaisePropertyChanged("so_item_cd");
            }
        }
        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                _curr_code = value;
                RaisePropertyChanged("curr_code");
            }
        }
        private Nullable<decimal> _amt_loc;
        public Nullable<decimal> amt_loc
        {
            get { return _amt_loc; }
            set
            {
                _amt_loc = value;
                RaisePropertyChanged("amt_loc", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _qty;
        [Required(ErrorMessage = "Field 'Quantity' is required.")]
        [ValidInteger(ErrorMessage = "Invalid Numeric data")]
        //[DisplayName("Quantity")]
        public Nullable<decimal> qty  // Nullable<decimal>
        {
            get { return _qty; }
            set
            {
                _qty = value; RaisePropertyChanged("qty");
                RaisePropertyChanged("qty", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _challan_qty;
        public Nullable<decimal> challan_qty
        {
            get { return _challan_qty; }
            set
            {
                _challan_qty = value;
                RaisePropertyChanged("challan_qty");
            }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                _unit_code = value;
                RaisePropertyChanged("unit_code");
            }
        }
        private Nullable<decimal> _unit_price;
        public Nullable<decimal> unit_price
        {
            get { return _unit_price; }
            set
            {
                _unit_price = value;
                RaisePropertyChanged("unit_price", ModelEntityUpdated);
            }
        }

        private string _debcr_ind;
        public string debcr_ind
        {
            get { return _debcr_ind; }
            set
            {
                _debcr_ind = value;
                RaisePropertyChanged("debcr_ind");
            }
        }

        private string _delv_completed_ind;
        public string delv_completed_ind
        {
            get { return _delv_completed_ind; }
            set
            {
                _delv_completed_ind = value;
                RaisePropertyChanged("delv_completed_ind");
            }
        }

        private string _source_doc_type;
        public string source_doc_type
        {
            get { return _source_doc_type; }
            set
            {
                _source_doc_type = value;
                RaisePropertyChanged("source_doc_type");
            }
        }

        private string _source_doc_no;
        public string source_doc_no
        {
            get
            {
                return _source_doc_no;
            }

            set
            {
                _source_doc_no = value;
                RaisePropertyChanged("source_doc_no");
            }
        }

        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set
            {
                _po_no = value;
                RaisePropertyChanged("po_no");
            }
        }

        private Nullable<int> _po_line_no;
        public Nullable<int> po_line_no
        {
            get { return _po_line_no; }
            set
            {
                _po_line_no = value;
                RaisePropertyChanged("po_line_no");
            }
        }

        private string _fin_year_rd;
        public string fin_year_rd
        {
            get
            {
                return _fin_year_rd;
            }

            set
            {
                _fin_year_rd = value;
                RaisePropertyChanged("fin_year_rd");
            }
        }

        private string _ref_doc_no;
        public string ref_doc_no
        {
            get
            {
                return _ref_doc_no;
            }

            set
            {
                _ref_doc_no = value;
                RaisePropertyChanged("ref_doc_no");
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

        private string _order_doc_type;
        public string order_doc_type
        {
            get { return _order_doc_type; }
            set
            {
                _order_doc_type = value;
                RaisePropertyChanged("order_doc_type");
            }
        }

        private string _order_doc_no;
        public string order_doc_no
        {
            get { return _order_doc_no; }
            set
            {
                _order_doc_no = value;
                RaisePropertyChanged("order_doc_no");
            }
        }
        private string _ref_doc_item_cd;
        public string ref_doc_item_cd
        {
            get { return _ref_doc_item_cd; }
            set
            {
                _ref_doc_item_cd = value;
                RaisePropertyChanged("ref_doc_item_cd");
            }
        }
        private string _mat_doc_no;
        public string mat_doc_no
        {
            get
            {
                return _mat_doc_no;
            }

            set
            {
                _mat_doc_no = value;
                RaisePropertyChanged("mat_doc_no");
            }
        }
        private string _mat_doc_item_cd;
        public string mat_doc_item_cd
        {
            get { return _mat_doc_item_cd; }
            set
            {
                _mat_doc_item_cd = value;
                RaisePropertyChanged("mat_doc_item_cd");
            }
        }
        private string _receipient_party_cd;
        public string receipient_party_cd
        {
            get { return _receipient_party_cd; }
            set
            {
                _receipient_party_cd = value;
                RaisePropertyChanged("receipient_party_cd");
            }
        }
        private string _bus_area;
        public string bus_area
        {
            get { return _bus_area; }
            set
            {
                _bus_area = value;
                RaisePropertyChanged("bus_area");
            }
        }

        private string _cost_center;
        public string cost_center
        {
            get { return _cost_center; }
            set
            {
                _cost_center = value;
                RaisePropertyChanged("cost_center");
            }
        }

        private string _profit_center;
        public string profit_center
        {
            get
            {
                return _profit_center;
            }

            set
            {
                _profit_center = value;
                RaisePropertyChanged("profit_center");
            }
        }
        private string _order_no;
        public string order_no
        {
            get
            {
                return _order_no;
            }

            set
            {
                _order_no = value;
                RaisePropertyChanged("order_no");
            }
        }

        private string _asset_no;
        public string asset_no
        {
            get
            {
                return _asset_no;
            }

            set
            {
                _asset_no = value;
                RaisePropertyChanged("asset_no");
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

        private string _per_posting;
        public string per_posting
        {
            get { return _per_posting; }
            set
            {
                _per_posting = value;
                RaisePropertyChanged("per_posting");
            }
        }

        private string _acc_doc_no;
        public string acc_doc_no
        {
            get
            {
                return _acc_doc_no;
            }

            set
            {
                _acc_doc_no = value;
                RaisePropertyChanged("acc_doc_no");
            }
        }

        private Nullable<int> _acc_doc_line;
        public Nullable<int> acc_doc_line
        {
            get
            {
                return _acc_doc_line;
            }

            set
            {
                _acc_doc_line = value;
                RaisePropertyChanged("acc_doc_line");

            }
        }

        private string _res_no;
        public string res_no
        {
            get
            {
                return _res_no;
            }

            set
            {
                _res_no = value;
                RaisePropertyChanged("res_no");
            }
        }

        private Nullable<int> _res_line;
        public Nullable<int> Res_line
        {
            get
            {
                return _res_line;
            }

            set
            {
                _res_line = value;
                RaisePropertyChanged("Res_line");
            }
        }

        private string _ri_item;
        public string ri_item
        {
            get { return _ri_item; }
            set
            {
                _ri_item = value;
                RaisePropertyChanged("ri_item");
            }
        }

        private string _ri_sku;
        public string ri_sku
        {
            get { return _ri_sku; }
            set
            {
                _ri_sku = value;
                RaisePropertyChanged("ri_sku");
            }
        }
        private string _ri_unit_cd;
        public string ri_unit_cd
        {
            get { return _ri_unit_cd; }
            set
            {
                _ri_unit_cd = value;
                RaisePropertyChanged("ri_unit_cd");
            }
        }

        private Nullable<decimal> _ri_qty;
        public Nullable<decimal> ri_qty
        {
            get { return _ri_qty; }
            set
            {
                _ri_qty = value;
                RaisePropertyChanged("ri_qty");
            }
        }

        private string _ri_plant;
        public string ri_plant
        {
            get { return _ri_plant; }
            set
            {
                _ri_plant = value;
                RaisePropertyChanged("ri_plant");
            }
        }
        private string _ri_wa_code;
        public string ri_wa_code
        {
            get { return _ri_wa_code; }
            set
            {
                _ri_wa_code = value;
                RaisePropertyChanged("ri_wa_code");
            }
        }
        private string _ri_store_code;
        public string ri_store_code
        {
            get { return _ri_store_code; }
            set { _ri_store_code = value; RaisePropertyChanged("ri_store_code"); }
        }
        private Nullable<int> _ir_bin;
        public Nullable<int> ir_bin
        {
            get
            {
                return _ir_bin;
            }

            set
            {
                _ir_bin = value;
                RaisePropertyChanged("ir_bin");
            }
        }

        private string _ir_batch;
        public string ir_batch
        {
            get
            {
                return _ir_batch;
            }

            set
            {
                _ir_batch = value;
                RaisePropertyChanged("ir_batch");

            }
        }

        private string _sts_tbatch;
        public string sts_tbatch
        {
            get
            {
                return _sts_tbatch;
            }

            set
            {
                _sts_tbatch = value;
                RaisePropertyChanged("sts_tbatch");

            }
        }

        private string _tr_req_no;
        public string tr_req_no
        {
            get
            {
                return _tr_req_no;
            }

            set
            {
                _tr_req_no = value;
                RaisePropertyChanged("tr_req_no");
            }
        }


        private string _tr_req_item_cd;
        public string tr_req_item_cd
        {
            get { return _tr_req_item_cd; }
            set
            {
                _tr_req_item_cd = value;
                RaisePropertyChanged("tr_req_item_cd");
            }
        }
        private string _to_no;
        public string to_no
        {
            get
            {
                return _to_no;
            }

            set
            {
                _to_no = value;
                RaisePropertyChanged("to_no");
            }
        }

        private string _cons_post;
        public string cons_post
        {
            get { return _cons_post; }
            set
            {
                _cons_post = value;
                RaisePropertyChanged("cons_post");
            }
        }

        private string _receipt_ind;
        public string receipt_ind
        {
            get { return _receipt_ind; }
            set
            {
                _receipt_ind = value;
                RaisePropertyChanged("receipt_ind");
            }
        }

        private string _gl_acc_no;
        public string gl_acc_no
        {
            get
            {
                return _gl_acc_no;
            }

            set
            {
                _gl_acc_no = value;
                RaisePropertyChanged("gl_acc_no");
            }
        }

        private Nullable<System.DateTime> _shelf_life_date;
        public Nullable<System.DateTime> shelf_life_date
        {
            get
            {
                return _shelf_life_date;
            }

            set
            {
                _shelf_life_date = value;
                RaisePropertyChanged("shelf_life_date");
            }
        }

        private string _gr_insp_sts;
        public string gr_insp_sts
        {
            get { return _gr_insp_sts; }
            set
            {
                _gr_insp_sts = value;
                RaisePropertyChanged("gr_insp_sts");
            }
        }


        private string _storage_tp;
        public string storage_tp
        {
            get { return _storage_tp; }
            set
            {
                _storage_tp = value;
                RaisePropertyChanged("storage_tp");
            }
        }

        private string _stock_cat;
        public string stock_cat
        {
            get { return _stock_cat; }
            set
            {
                _stock_cat = value;
                RaisePropertyChanged("stock_cat");
            }
        }
        private string _wm_mov_tp_cd;
        public string wm_mov_tp_cd
        {
            get { return _wm_mov_tp_cd; }
            set
            {
                _wm_mov_tp_cd = value;
                RaisePropertyChanged("wm_mov_tp_cd");
            }
        }
        private Nullable<int> _mov_reason;
        public Nullable<int> mov_reason
        {
            get { return _mov_reason; }
            set
            {
                _mov_reason = value;
                RaisePropertyChanged("mov_reason");
            }
        }

        private Nullable<int> _tax_code;
        public Nullable<int> tax_code
        {
            get
            {
                return _tax_code;
            }

            set
            {
                _tax_code = value;
                RaisePropertyChanged("tax_code");
            }
        }

        private string _tax_jur;
        public string tax_jur
        {
            get
            {
                return _tax_jur;
            }

            set
            {
                _tax_jur = value;
                RaisePropertyChanged("tax_jur");
            }
        }

        private Nullable<System.DateTime> _mfg_date;
        public Nullable<System.DateTime> mfg_date
        {
            get
            {
                return _mfg_date;
            }

            set
            {
                _mfg_date = value;
                RaisePropertyChanged("mfg_date");
            }
        }

        private string _note;
        public string note
        {
            get
            {
                return _note;
            }

            set
            {
                _note = value;
                RaisePropertyChanged("note");
            }
        }

        private Nullable<int> _machine_id;
        public Nullable<int> machine_id
        {
            get { return _machine_id; }
            set
            {
                _machine_id = value;
                RaisePropertyChanged("machine_id");
            }
        }

        private string _mat_con;
        public string mat_con
        {
            get
            {
                return _mat_con;
            }

            set
            {
                _mat_con = value;
                RaisePropertyChanged("mat_con");
            }
        }

        private string _para1;
        public string para1
        {
            get
            {
                return _para1;
            }

            set
            {
                _para1 = value;
                RaisePropertyChanged("para1");
            }
        }

        private string _para2;
        public string para2
        {
            get
            {
                return _para2;
            }

            set
            {
                _para2 = value;
                RaisePropertyChanged("para2");

            }
        }

        private string _para3;
        public string para3
        {
            get
            {
                return _para3;
            }

            set
            {
                _para3 = value;
                RaisePropertyChanged("para3");
            }
        }

        private string _para4;
        public string para4
        {
            get
            {
                return _para4;
            }

            set
            {
                _para4 = value;
                RaisePropertyChanged("para4");
            }
        }

        private string _para5;
        public string para5
        {
            get
            {
                return _para5;
            }

            set
            {
                _para5 = value;
                RaisePropertyChanged("para5");
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
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
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
        private string _item_cat;
        public string item_cat
        {
            get { return _item_cat; }
            set
            {
                _item_cat = value;
                RaisePropertyChanged("item_cat");
            }
        }
        private Nullable<bool> _item_ok;
        public Nullable<bool> item_ok
        {
            get { return _item_ok; }
            set
            {
                _item_ok = value;
                RaisePropertyChanged("item_ok");
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

        private string _location_Id;
        [Required(ErrorMessage = "Field 'Plant' is required.")]
        [DisplayName("Plant")]
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }
        private string _vendor_batch_no;
        public string vendor_batch_no
        {
            get { return _vendor_batch_no; }
            set
            {
                _vendor_batch_no = value;
                RaisePropertyChanged("vendor_batch_no");
            }
        }
        private Nullable<decimal> _para6;
        public Nullable<decimal> para6
        {
            get { return _para6; }
            set
            {
                _para6 = value;
                RaisePropertyChanged("para6");
                RaisePropertyChanged("para6", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _para7;
        public Nullable<decimal> para7
        {
            get { return _para7; }
            set
            {
                _para7 = value;
                RaisePropertyChanged("para7");
            }
        }

        
        private string _cash_credit_pur;
        public string cash_credit_pur
        {
            get { return _cash_credit_pur; }
            set
            {
                _cash_credit_pur = value;
                RaisePropertyChanged("cash_credit_pur");
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

        private Nullable<bool> _StockUnt;
        public Nullable<bool> StockUnt
        {
            get { return _StockUnt; }
            set { _StockUnt = value; RaisePropertyChanged("StockUnt"); }
        }


        private string _unit_name;
        public string unit_Name
        {
            get { return _unit_name; }
            set
            {
                _unit_name = value;
                RaisePropertyChanged("unit_Name");
            }
        }

        private string _cost_center_Nm;
        public string cost_center_Nm
        {
            get { return _cost_center_Nm; }
            set
            {
                _cost_center_Nm = value;
                RaisePropertyChanged("cost_center_Nm");
            }
        }

        private string _SubCatCode;
        public string SubCatCode
        {
            get { return _SubCatCode; }

            set { _SubCatCode = value; RaisePropertyChanged("SubCatCode"); }
        }

        private string _Plant_Name;
        public string Plant_Name
        {
            get { return _Plant_Name; }
            set
            {
                _Plant_Name = value;
                RaisePropertyChanged("Plant_Name");
            }
        }
        private string _CompName;
        public string CompName
        {
            get { return _CompName; }
            set
            {
                _CompName = value;
                RaisePropertyChanged("CompName");
            }
        }
        private string _machinecode;
        public string machinecode
        {
            get { return _machinecode; }
            set
            {
                _machinecode = value;
                RaisePropertyChanged("machinecode");
            }
        }
        private Nullable<decimal> _po_qty;
        public Nullable<decimal> po_qty
        {
            get { return _po_qty; }
            set
            {
                _po_qty = value;
                RaisePropertyChanged("po_qty");
            }
        }

        private string _SubCategCod;
        public string SubCategCod
        {
            get { return _SubCategCod; }

            set { _SubCategCod = value; RaisePropertyChanged("SubCategCod"); }
        }


        //New Fields Added on 12/12/2016

        private Nullable<int> _ref_item_line_id;
        public Nullable<int> ref_item_line_id
        {
            get { return _ref_item_line_id; }
            set { _ref_item_line_id = value; RaisePropertyChanged("ref_item_line_id"); }
        }

        private string _bom_no;
        public string bom_no
        {
            get { return _bom_no; }
            set { _bom_no = value; RaisePropertyChanged("bom_no"); }
        }


        private string _status_remark;
        public string status_remark
        {
            get { return _status_remark; }
            set { _status_remark = value; RaisePropertyChanged("status_remark"); }
        }

        private Nullable<int> _source_doc_itemline_id;
        public Nullable<int> source_doc_itemline_id
        {
            get { return _source_doc_itemline_id; }
            set { _source_doc_itemline_id = value; RaisePropertyChanged("source_doc_itemline_id"); }
        }

        private Nullable<int> _order_doc_item_id;
        public Nullable<int> order_doc_item_id
        {
            get { return _order_doc_item_id; }
            set { _order_doc_item_id = value; RaisePropertyChanged("order_doc_item_id"); }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }

        private Nullable<System.DateTime> _post_date;
        public Nullable<System.DateTime> post_date
        {
            get { return _post_date; }
            set { _post_date = value; RaisePropertyChanged("post_date"); }
        }

        private string _project_id;
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

        private string _project_loc;
        public string project_loc
        {
            get { return _project_loc; }
            set { _project_loc = value; RaisePropertyChanged("project_loc"); }
        }

        private string _wc_code;
        public string wc_code
        {
            get { return _wc_code; }
            set { _wc_code = value; RaisePropertyChanged("wc_code"); }
        }

        private int? _ref_doc_item_row_id;
        public int? ref_doc_item_row_id
        {
            get { return _ref_doc_item_row_id; }
            set { _ref_doc_item_row_id = value; RaisePropertyChanged("ref_doc_item_row_id"); }
        }

        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set { _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat"); }
        }
        private int? _po_item_row_id;
        public int? po_item_row_id
        {
            get { return _po_item_row_id; }
            set { _po_item_row_id = value; RaisePropertyChanged("po_item_row_id"); }
        }
        private int? _req_item_row_id;
        public int? req_item_row_id
        {
            get { return _req_item_row_id; }
            set { _req_item_row_id = value; RaisePropertyChanged("req_item_row_id"); }
        }
        private int? _so_item_row_id;
        public int? so_item_row_id
        {
            get { return _so_item_row_id; }
            set { _so_item_row_id = value; RaisePropertyChanged("so_item_row_id"); }
        }
        private string _order_doc_cat;
        public string order_doc_cat
        {
            get { return _order_doc_cat; }
            set { _order_doc_cat = value; RaisePropertyChanged("order_doc_cat"); }
        }
        private int? _dn_item_row_id;
        public int? dn_item_row_id
        {
            get { return _dn_item_row_id; }
            set { _dn_item_row_id = value; RaisePropertyChanged("dn_item_row_id"); }
        }
        private string _posting_key;
        public string posting_key
        {
            get { return _posting_key; }
            set { _posting_key = value; RaisePropertyChanged("posting_key"); }
        }
        //scalar
        private decimal? _IssuedQty;
        public decimal? IssuedQty
        {
            get { return _IssuedQty; }
            set { _IssuedQty = value; RaisePropertyChanged("IssuedQty"); }
        }


        private string _ItemNm;
        public string ItemNm
        {
            get { return _ItemNm; }

            set { _ItemNm = value; RaisePropertyChanged("ItemNm"); }
        }

        private string _t_display;
        public string t_display
        {
            get
            {
                return _t_display;
            }
            set
            {
                _t_display = value;
                RaisePropertyChanged("t_display");
            }
        }

        //private Nullable<decimal> _tip_ave_wt;
        //public Nullable<decimal> tip_ave_wt
        //{
        //    get { return _tip_ave_wt; }

        //    set { _tip_ave_wt = value; RaisePropertyChanged("tip_ave_wt"); }
        //}



        //private string _item_codeD;
        //public string item_codeD
        //{
        //    get { return _item_codeD; }
        //    set
        //    {
        //        _item_codeD = value;
        //        RaisePropertyChanged("item_codeD");
        //    }
        //}

        //private string _item_NameD;
        //public string item_NameD
        //{
        //    get { return _item_NameD; }
        //    set
        //    {
        //        _item_NameD = value;
        //        RaisePropertyChanged("item_NameD");
        //    }
        //}

        //private string _unit_NameD;
        //public string unit_NameD
        //{
        //    get { return _unit_NameD; }
        //    set
        //    {
        //        _unit_NameD = value;
        //        RaisePropertyChanged("unit_NameD");
        //    }
        //}
        private string _textdata;
        public string textdata
        {
            get
            {
                return _textdata;
            }

            set
            {
                _textdata = value; RaisePropertyChanged("textdata");
            }
        }
        public string confirmation_no { get; set; }
        private string _barcode;
        public string barcode
        {
            get
            {
                return _barcode;
            }

            set
            {
                _barcode = value; RaisePropertyChanged("barcode");
            }
        }

        private string _store_name;
        public string store_name
        {
            get
            {
                return _store_name;
            }

            set
            {
                _store_name = value; RaisePropertyChanged("store_name");
            }
        }



        // Scallar
        public string equip_no { get; set; }
        public string equip_name { get; set; }
        public string manufacturer { get; set; }
        public string mfg_model { get; set; }
        public string mfg_srno { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public DateTime? return_date { get; set; }
        public string return_doc { get; set; }

    }
    public class MM_T001_B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _item_line_id;
        public int item_line_id
        {
            get { return _item_line_id; }
            set { _item_line_id = value; RaisePropertyChanged("item_line_id"); }
        }
        private string _sku;
        public string sku
        {
            get { return _sku; }
            set { _sku = value; RaisePropertyChanged("sku"); }
        }
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
        private Nullable<int> _sr_line_no { get; set; }
        public Nullable<int> sr_line_no
        {
            get { return _sr_line_no; }
            set { _sr_line_no = value; RaisePropertyChanged("sr_line_no"); }
        }
        private Nullable<int> _grn_id;
        public Nullable<int> grn_id
        {
            get { return _grn_id; }
            set
            {
                _grn_id = value;
                RaisePropertyChanged("grn_id");
            }
        }
        private string _batch_no;
        public string batch_no
        {
            get { return _batch_no; }
            set
            {
                _batch_no = value;
                RaisePropertyChanged("batch_no");
            }
        }
        private Nullable<decimal> _rec_qty;
        public Nullable<decimal> rec_qty
        {
            get { return _rec_qty; }
            set
            {
                _rec_qty = value;
                RaisePropertyChanged("rec_qty", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _qty;
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set
            {
                _qty = value;
                RaisePropertyChanged("qty");
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
        private string _t_status;
        public string t_status
        {
            get
            {
                return _t_status;
            }

            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
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
        private string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set
            {
                _store_code = value;
                RaisePropertyChanged("store_code");
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
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                _ItemCode = value;
                RaisePropertyChanged("ItemCode");
            }
        }
        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set
            {
                _ItemName = value;
                RaisePropertyChanged("ItemName");
            }
        }
        private string _UOMNmSplit;
        public string UOMNmSplit
        {
            get { return _UOMNmSplit; }
            set
            {
                _UOMNmSplit = value;
                RaisePropertyChanged("UOMNmSplit");
            }
        }
        private string _pono;
        public string pono
        {
            get { return _pono; }
            set
            {
                _pono = value;
                RaisePropertyChanged("pono");
            }
        }
        private string _vendor_batch_no;
        public string vendor_batch_no
        {
            get { return _vendor_batch_no; }
            set
            {
                _vendor_batch_no = value;
                RaisePropertyChanged("vendor_batch_no");
            }
        }
        private decimal? _para1;
        public decimal? para1
        {
            get { return _para1; }
            set
            {
                _para1 = value;
                RaisePropertyChanged("para1");
            }
        }
        private decimal? _para2;
        public decimal? para2
        {
            get { return _para2; }
            set
            {
                _para2 = value;
                RaisePropertyChanged("para2", ModelEntityUpdated);
            }
        }
        private decimal? _para3;
        public decimal? para3
        {
            get { return _para3; }
            set
            {
                _para3 = value;
                RaisePropertyChanged("para3", ModelEntityUpdated);
            }
        }
        private decimal? _para4;
        public decimal? para4
        {
            get { return _para4; }
            set
            {
                _para4 = value;
                RaisePropertyChanged("para4", ModelEntityUpdated);
            }
        }
        private decimal? _para5;
        public decimal? para5
        {
            get { return _para5; }
            set
            {
                _para5 = value;
                RaisePropertyChanged("para5");
            }
        }
        private Nullable<decimal> _para6;
        public Nullable<decimal> para6
        {
            get { return _para6; }
            set
            {
                _para6 = value;
                RaisePropertyChanged("para6");
            }
        }
        private Nullable<decimal> _para7;
        public Nullable<decimal> para7
        {
            get { return _para7; }
            set
            {
                _para7 = value;
                RaisePropertyChanged("para7");
            }
        }
        
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
        private string _wa_code;
        public string wa_code
        {
            get { return _wa_code; }
            set
            {
                _wa_code = value;
                RaisePropertyChanged("wa_code");
            }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                _unit_code = value;
                RaisePropertyChanged("unit_code");
            }
        }
        private string _comp_code;
        public string comp_code
        {
            get
            {
                return _comp_code;
            }

            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }
        private string _doc_no;
        public string doc_no
        {
            get
            {
                return _doc_no;
            }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
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

        //Scalar
        private string _t_display;
        public string t_display
        {
            get
            {
                return _t_display;
            }
            set
            {
                _t_display = value;
                RaisePropertyChanged("t_display");
            }
        }


        private int? _ref_batch_row_id;
        public int? ref_batch_row_id
        {
            get { return _ref_batch_row_id; }
            set { _ref_batch_row_id = value; RaisePropertyChanged("ref_batch_row_id"); }
        }

        public string confirmation_no { get; set; }
        public string barcode { get; set; }
        private string _pack_no;
        public string pack_no
        {
            get
            {
                return _pack_no;
            }
            set
            {
                _pack_no = value;
                RaisePropertyChanged("pack_no");
            }
        }
        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set { _order_no = value; RaisePropertyChanged("order_no"); }
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
        private int? _ref_item_row_id;
        public int? ref_item_row_id
        {
            get { return _ref_item_row_id; }
            set { _ref_item_row_id = value; RaisePropertyChanged("ref_item_row_id"); }
        }

        //Scalar
        private string _item_name;
        public string item_name
        {
            get
            {
                return _item_name;
            }
            set
            {
                _item_name = value;
                RaisePropertyChanged("item_name");
            }
        }

        private string _item_name_order;
        public string item_name_order
        {
            get
            {
                return _item_name_order;
            }
            set
            {
                _item_name_order = value;
                RaisePropertyChanged("item_name_order");
            }
        }

    }
    public class MM_T001_C : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private Nullable<int> _line_id;
        public Nullable<int> line_id
        {
            get { return _line_id; }
            set { _line_id = value; RaisePropertyChanged("line_id"); }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }

        private Nullable<int> _sr_line_no;
        public Nullable<int> sr_line_no
        {
            get
            {
                return _sr_line_no;
            }

            set
            {
                _sr_line_no = value;
                RaisePropertyChanged("sr_line_no");
            }
        }

        private string _ItemCode;
        public string ItemCode
        {
            get
            {
                return _ItemCode;
            }

            set
            {
                _ItemCode = value;
                RaisePropertyChanged("ItemCode");
            }
        }

        private string _sku;
        public string sku
        {
            get
            {
                return _sku;
            }

            set
            {
                _sku = value;
                RaisePropertyChanged("sku");
            }
        }

        private string _po_no;
        public string po_no
        {
            get
            {
                return _po_no;
            }

            set
            {
                _po_no = value;
                RaisePropertyChanged("po_no");
            }
        }

        private Nullable<int> _po_line_no;
        public Nullable<int> po_line_no
        {
            get
            {
                return _po_line_no;
            }

            set
            {
                _po_line_no = value;
                RaisePropertyChanged("po_line_no");
            }
        }

        private decimal _po_qty;
        public decimal po_qty
        {
            get
            {
                return _po_qty;
            }

            set
            {
                _po_qty = value;
                RaisePropertyChanged("po_qty");
            }
        }

        private Nullable<decimal> _rec_qty;
        public Nullable<decimal> rec_qty
        {
            get
            {
                return _rec_qty;
            }

            set
            {
                _rec_qty = value;
                RaisePropertyChanged("rec_qty");

            }
        }

        private decimal _allocated_qty;
        public decimal allocated_qty
        {
            get
            {
                return _allocated_qty;
            }

            set
            {
                _allocated_qty = value;
                RaisePropertyChanged("allocated_qty");
            }
        }

        private Nullable<decimal> _challan_qty;
        public Nullable<decimal> challan_qty
        {
            get
            {
                return _challan_qty;
            }

            set
            {
                _challan_qty = value;
                RaisePropertyChanged("challan_qty");
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get
            {
                return _location_Id;
            }

            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get
            {
                return _comp_code;
            }

            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }

        private string _t_status;
        public string t_status
        {
            get
            {
                return _t_status;
            }

            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get
            {
                return _active;
            }

            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get
            {
                return _add_date;
            }

            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }

        private string _add_by;
        public string add_by
        {
            get
            {
                return _add_by;
            }

            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get
            {
                return _edit_date;
            }

            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }

        private string _editby;
        public string editby
        {
            get
            {
                return _editby;
            }

            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }

        


        //Scalar
        private string _t_display;
        public string t_display
        {
            get
            {
                return _t_display;
            }
            set
            {
                _t_display = value;
                RaisePropertyChanged("t_display");
            }
        }
    }

    public class MM_T001Flip
    {
        public string doc_no { get; set; }
        public Nullable<DateTime> doc_date { get; set; }
        public Nullable<DateTime> post_date { get; set; }
        public string doc_type { get; set; }
        public string ref_doc { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string dept_code { get; set; }
        public string DeptName { get; set; }
        public string mov_tp { get; set; }
        public string mov_tp_name { get; set; }
        public string location_Id { get; set; }
        public string loctaionName { get; set; }
        public string comp_code { get; set; }
        public string t_status { get; set; }
    }
    public class ADM_M022_PopUp_Inst : ObjectBase
    {
        public int SrNo { get; set; }
        public int item_id { get; set; }
        [DisplayName("Item Code")]
        public string ItemCode { get; set; }
        [DisplayName("Item Name")]
        public string ItemName { get; set; }
        public int unit_id { get; set; }
        [DisplayName("Unit Name")]
        public string unit_name { get; set; }
        [DisplayName("Unit Code")]
        public string unit_code { get; set; }

        public string unit_abbrv { get; set; }
        public int SubCategCod { get; set; }
        public Nullable<bool> Stockable { get; set; }
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
        public int id { get; set; }
        public string so_no { get; set; }



    }
    public class RptGRN
    {
        public string doc_no { get; set; }
        public Nullable<DateTime> doc_date { get; set; }
        public string CSTNo { get; set; }
        public string VATNo { get; set; }
        public string PanNo { get; set; }
        public string service_tax_no { get; set; }
        public string mov_name { get; set; }
        public string transport_party { get; set; }
        public string ItemCode { get; set; }
        public string description { get; set; }
        public string sku_desc { get; set; }
        public string unit_code { get; set; }
        public decimal? qty { get; set; }
        public decimal? challan_qty { get; set; }
        public decimal? unit_price { get; set; }
        public Nullable<System.Decimal> Amount { get; set; }
        public string PartyNm { get; set; }
        public string notes { get; set; }
        public string ge_no { get; set; }
        public string ref_doc { get; set; }
        public string PartyAdd { get; set; }
        public string PlantNm { get; set; }
        public string PlantAdd { get; set; }
        public string Ref_Doc_No { get; set; }
        public string del_note { get; set; }
        public Nullable<DateTime> del_note_date { get; set; }
        public string bill_ladding { get; set; }
        public Nullable<DateTime> bill_ladding_dt { get; set; }
        public Nullable<DateTime> ge_date { get; set; }
        public Nullable<DateTime> ref_doc_date { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string city { get; set; }
        public string StatName { get; set; }
        public string CntryName { get; set; }
        public string PinCode { get; set; }
        public string sending_plant { get; set; }
        public string LoctnNm { get; set; }
        public string Add1L { get; set; }
        public string Add2L { get; set; }
        public string CityL { get; set; }
        public string PinCodeL { get; set; }
        public string state_code { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public string state_name { get; set; }
        public string PartyId { get; set; }
        public string vendor { get; set; }
        public string sku { get; set; }
        public string address { get; set; }
        public string transporter_name { get; set; }
        public string gstinno { get; set; }
        public Nullable<System.DateTime> gstindate { get; set; }
        public string soldto_buss_place { get; set; }
        public string hs_code { get; set; }
        public string rec_plant { get; set; }
        public string sending_plant_name { get; set; }
        public string rec_plant_name { get; set; }
        public string rec_plant_address { get; set; }
        public string batch_no { get; set; }

        //Waybill Details

        public string way_bill_no { get; set; }
        public Nullable<System.DateTime> way_bill_date { get; set; }
        public decimal? way_bill_value { get; set; }
        public string doc_format { get; set; }
        public string textdata { get; set; }
    }

    //public class MultipleContext_MM_T001_GC
    //{
    //    public List<MM_T001Flip> DocumentDataFlipGrid { get; set; }
    //    public List<MM_M004_P> MovementDetails { get; set; }
    //    public List<ZADM_M006_P> InkDetails { get; set; }
    //    public List<ZADM_M007_P> IldDetails { get; set; }
    //    public List<ADM_M045_P> GradeDetails { get; set; }
    //    public List<ADM_M022_POPUP> SourceItemDetails { get; set; }
    //    public List<ADM_M022_POPUP> RMItemDetails { get; set; }
    //    public List<ADM_M031_P> ParameterDetails { get; set; }
    //    public List<ADM_M030_P> ParameterValueDetails { get; set; }
    //    public List<ADM_M038_B_P> UOMDetails { get; set; }
    //    public List<MM_T001> MasterEntity { get; set; }
    //    public ObservableCollection<MM_T001_A> ItemsEntity { get; set; }
    //    public List<COM_T003> AttachmentData { get; set; }
    //    public List<ADM_M030_P> MakeDetails { get; set; }
    //    public List<ADM_M030_P> TypeDetails { get; set; }
    //    public List<ADM_M030_P> MaterialConditionDetails { get; set; }

    //}

    public class MC_MM_T001 : MC_MM_BE
    {
        public List<STD_LIST_BE> GATE_ENTRY_LIST { get; set; }
        public List<MM_T001> MASTER_ENTITY_LIST { get; set; }
        public ObservableCollection<MM_T001_A> ITEMS_ENTITY_LIST { get; set; }
        public ObservableCollection<MM_T001_B> BATCH_ENTITY_LIST { get; set; }


        public List<ADM_M028_P> PartyList { get; set; }
        public List<ADM_M028_P> TransporterList { get; set; }
        public List<MM_M004_P> MovementTypeList { get; set; }
        public List<SYS_M007_P> DocTypeList { get; set; } // PO Document Type List
        public List<SYS_DOC_CAT> DocCatList { get; set; }
        public List<SYS_DOC_CAT> ReferenceDocCatList { get; set; } // Need Reference doc_cat list
        public List<REF_DOC_MM_T001> ReferenceDocumentList { get; set; }   // Make Common for all Reference doc
        public List<ADM_M038_B_P> UOMList { get; set; }
        public List<MM_M001_P> StoreCodeList { get; set; }
        public List<ADM_M030_P> ParamValueList { get; set; } // Load this on Execute of Reference Document
        public List<ADM_M031_P> ParameterList { get; set; }
        public List<MM_T001_FLIP> FlipGridList { get; set; }  // Change to Standard
        public List<MM_T001> MasterList { get; set; }
        public ObservableCollection<MM_T001_A> ItemList { get; set; }
        public ObservableCollection<MM_T001_B> BatchList { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<SYS_M025> StatusList { get; set; }
        public List<SYS_M026> TransportMode { get; set; }
        public List<ADM_M024_POP> PersonnelList { get; set; }
        public List<ADM_M025_P> DepartmentList { get; set; }
        public List<PUR_T002_A_P> SourceDocNoList { get; set; }   // PO Number List
        public List<ADM_M022_P> ItemPopupList { get; set; }  // Item List
        public List<SYS_M008_P> ItemCatList { get; set; }  // Item Category List
        public List<MM_T001> GRNMasterList { get; set; }   // Goods Receipt Note List Master Transaction
        public ObservableCollection<MM_T001_A> ItemDetailsList { get; set; }  // Item Details List of GRN
        public ObservableCollection<MM_T001_B> BatchDetailsList { get; set; } // Batch Details List of GRN
        public ObservableCollection<MM_T001_C> POAllocDetailsList { get; set; } // PO Allocation Details List
        public List<PUR_T002_A> LoadDocList { get; set; } // PO LOAD LIST
        public List<PUR_T002_B> LoadPOItemsList { get; set; } // PO LOAD LIST
        public List<RptGRN> RptGRN { get; set; }
        public List<SYS_M025> t_statusList { get; set; }

        public List<MM_T001Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M024_P> Requster { get; set; }
        public List<ADM_M025_P> deptList { get; set; }  //Department Master   
        //public List<ADM_M003_P> plant { get; set; }  //Plant/Location Master
        public List<ADM_M022_P> items { get; set; }  //Item Master
        public List<ADM_M038_B_P> unitList { get; set; }  //Unit Master
        public List<MM_M001_P> store { get; set; }  //Storage Location Master
        public List<MM_S003_P> batchList { get; set; }
        public List<MM_T003_P> IndentOrIndentNoList { get; set; }//Indent Order
        public List<Order_No_P> OrderDocNoList { get; set; }
        public List<MM_T001> DocumentMaster { get; set; }  //Goods Issue
        public ObservableCollection<MM_T001_A> GoodsA { get; set; }  // MM_T001_A
        public ObservableCollection<MM_T001_B> ItemBatchDetails { get; set; }
        public List<ZADM_M013_P> MachineCodeList { get; set; }
        public List<EPR_T003_A_P> CartonsList { get; set; }
        public List<MaterialIssue> RptMaterialIssue { get; set; }  //Goods Issue
        public List<MaterialIssueItem> RptMaterialIssueItem { get; set; }  // MM_T001_A 
        public List<MaterialIssueBatch> RptMaterialIssueBatch { get; set; }
        public List<MM_T003_P> ReturnIndentNo { get; set; }

        public List<MM_M004_P> MovementDetails { get; set; }
        public List<ZADM_M006_P> InkDetails { get; set; }
        public List<ZADM_M007_P> IldDetails { get; set; }
        public List<ADM_M045_P> GradeDetails { get; set; }
        public List<ADM_M022_POPUP> SourceItemDetails { get; set; }
        public List<ADM_M022_POPUP> RMItemDetails { get; set; }
        public List<ADM_M031_P> ParameterDetails { get; set; }
        public List<ADM_M030_P> ParameterValueDetails { get; set; }
        public List<ADM_M038_B_P> UOMDetails { get; set; }
        public List<MM_T001> MasterEntity { get; set; }
        public ObservableCollection<MM_T001_A> ItemsEntity { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<ADM_M030_P> MakeDetails { get; set; }
        public List<ADM_M030_P> TypeDetails { get; set; }
        public List<ADM_M030_P> MaterialConditionDetails { get; set; }
        public List<PRO_T001_P> Project { get; set; }
    }
    public class MM_T001_FLIP // Standard Backflip Entity
    {
        public string doc_no { get; set; }
        public System.DateTime doc_date { get; set; }
        public System.DateTime post_date { get; set; }
        public string t_status { get; set; }
        public string source_doc_no { get; set; }
        public string mov_name { get; set; }
        public string vendor { get; set; }
        public string sendplantnm { get; set; }
        public string recplantnm { get; set; }
        public string com_inv_no { get; set; }
        public bool allocation { get; set; }
        public string mov_tp { get; set; }
        public string t_display { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string del_note { get; set; }
        public string ref_doc { get; set; }
        public string way_bill_no { get; set; }
        public string color_code { get; set; }
    }

    public class MC_MM_T001_STD : STD_MC_BE
    {
        public List<MM_M004> MOV_TYPE_LIST { get; set; }
        public List<SYS_M026> TRANSPORT_MODE_LIST { get; set; }
        public List<ADM_M028_P> TRANSPORTER_LIST { get; set; }
        public List<MM_T001> MASTER_BE_LIST { get; set; }
        public ObservableCollection<MM_T001_A> ITEM_BE_LIST { get; set; }
        public ObservableCollection<MM_T001_B> BATCH_BE_LIST { get; set; }
        public ObservableCollection<MM_T001_C> ALLOCATION_BE_LIST { get; set; }
    }
}

