using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
//using Reflection.BusinessEntity;

namespace Reflection.BusinessEntity
{
    public class ECRM_T002_A : ObjectBase
    {
        
        private int _id;
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
        private string _quality_feedback_no;
        public string quality_feedback_no
        {
            get { return _quality_feedback_no; }
            set
            {
                if (_quality_feedback_no != value)
                {
                    _quality_feedback_no = value;
                    RaisePropertyChanged("quality_feedback_no");

                }
            }
        }
        private Nullable<System.DateTime> _quality_feedback_date;
        public Nullable<System.DateTime> quality_feedback_date
        {
            get { return _quality_feedback_date; }
            set
            {
                if (_quality_feedback_date != value)
                {
                    _quality_feedback_date = value;
                    RaisePropertyChanged("quality_feedback_date");
                }

            }
        }
        private string _party_ref_no;
        public string party_ref_no
        {
            get { return _party_ref_no; }
            set
            {
                if (_party_ref_no != value)
                {
                    _party_ref_no = value;
                    RaisePropertyChanged("party_ref_no");
                }
            }
        }
        private Nullable<System.DateTime> _party_ref_date;
        public Nullable<System.DateTime> party_ref_date
        {
            get { return _party_ref_date; }
            set
            {

                if (_party_ref_date != value)
                {
                    _party_ref_date = value;
                    RaisePropertyChanged("party_ref_date");
                }

            }
        }
        private Nullable<int> _model_id;
        public Nullable<int> model_id
        {
            get { return _model_id; }
            set
            {
                if (_model_id != value)
                {
                    _model_id = value;
                    RaisePropertyChanged("model_id");
                }
            }
        }
        private string _product_name;
        //[Required(ErrorMessage = "Field 'Product' is required.")]

        public string product_name
        {
            get { return _product_name; }
            set
            {
                if (_product_name != value)
                {
                    _product_name = value;
                    RaisePropertyChanged("product_name");
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
        private int _ild_id;
        public int ild_id
        {
            get { return _ild_id; }
            set
            {
                if (_ild_id != value)
                {
                    _ild_id = value;
                    RaisePropertyChanged("ild_id");
                }
            }
        }
        private int _ink_id;
        public int ink_id
        {
            get { return _ink_id; }
            set
            {
                if (_ink_id != value)
                {
                    _ink_id = value;
                    RaisePropertyChanged("ink_id");
                }
            }
        }
        private string _ild;
        //[Required(ErrorMessage = "Field 'ILD' is required.")]
        [DisplayName("ILD")]
        public string ild
        {
            get { return _ild; }
            set
            {
                if (_ild != value)
                {
                    _ild = value;
                    RaisePropertyChanged("ild");
                }
            }
        }
        private string _ink;
        //[Required(ErrorMessage = "Field 'INK' is required.")]
        [DisplayName("INK")]
        public string ink
        {
            get { return _ink; }
            set
            {
                if (_ink != value)
                {
                    _ink = value;
                    RaisePropertyChanged("ink");
                }
            }
        }
        private string _ink_details;
        public string ink_details
        {
            get { return _ink_details; }
            set
            {
                if (_ink_details != value)
                {
                    _ink_details = value;
                    RaisePropertyChanged("ink_details");
                }
            }
        }
        private decimal _invoice_qty;
        public decimal invoice_qty
        {
            get { return _invoice_qty; }
            set
            {
                if (_invoice_qty != value)
                {
                    _invoice_qty = value;
                    RaisePropertyChanged("invoice_qty");
                }
            }
        }
        private decimal _defected_qty;
        public decimal defected_qty
        {
            get { return _defected_qty; }
            set
            {
                if (_defected_qty != value)
                {
                    _defected_qty = value;
                    RaisePropertyChanged("defected_qty");
                }
            }
        }
        private string _note;
        public string note
        {
            get { return _note; }
            set
            {
                if (_note != value)
                {
                    _note = value;
                    RaisePropertyChanged("note");
                }
            }
        }
        public Nullable<bool> rtqfr { get; set; }
        private string _rtqfr_no;
        public string rtqfr_no
        {
            get { return _rtqfr_no; }
            set
            {
                if (_rtqfr_no != value)
                {
                    _rtqfr_no = value;
                    RaisePropertyChanged("rtqfr_no");
                }
            }
        }
        private Nullable<System.DateTime> _rtqfr_date;
        public Nullable<System.DateTime> rtqfr_date
        {
            get { return _rtqfr_date; }
            set
            {
                if (_rtqfr_date != value)
                {
                    _rtqfr_date = value;
                    RaisePropertyChanged("rtqfr_date");
                }
            }
        }
        private Nullable<bool> _quality_feedback_flg;
        public Nullable<bool> quality_feedback_flg
        {
            get { return _quality_feedback_flg; }
            set
            {
                if (_quality_feedback_flg != value)
                {
                    _quality_feedback_flg = value;
                    RaisePropertyChanged("quality_feedback_flg");
                }
            }
        }
        private Nullable<System.DateTime> _rtqfradddt;
        public Nullable<System.DateTime> rtqfradddt
        {
            get { return _rtqfradddt; }
            set
            {
                if (_rtqfradddt != value)
                {
                    _rtqfradddt = value;
                    RaisePropertyChanged("rtqfradddt");
                }
            }
        }
        private string _rtqfreditby;
        public string rtqfreditby
        {
            get { return _rtqfreditby; }
            set
            {
                if (_rtqfreditby != value)
                {
                    _rtqfreditby = value;
                    RaisePropertyChanged("rtqfreditby");
                }
            }
        }
        private string _EmpId;
        public string EmpId
        {
            get { return _EmpId; }
            set
            {
                if (_EmpId != value)
                {
                    _EmpId = value;
                    RaisePropertyChanged("EmpId");
                }
            }
        }
        private Nullable<System.DateTime> _rtqfreditdt;
        public Nullable<System.DateTime> rtqfreditdt
        {
            get { return _rtqfreditdt; }
            set
            {
                if (_rtqfreditdt != value)
                {
                    _rtqfreditdt = value;
                    RaisePropertyChanged("rtqfreditdt");
                }
            }
        }
        private string _test_procedure;
        public string test_procedure
        {
            get { return _test_procedure; }
            set
            {
                if (_test_procedure != value)
                {
                    _test_procedure = value;
                    RaisePropertyChanged("test_procedure");
                }
            }
        }
        private string _test_procedure_result;
        public string test_procedure_result
        {
            get { return _test_procedure_result; }
            set
            {
                if (_test_procedure_result != value)
                {
                    _test_procedure_result = value;
                    RaisePropertyChanged("test_procedure_result");
                }
            }
        }
        private string _conclusion;
        public string conclusion
        {
            get { return _conclusion; }
            set
            {
                if (_conclusion != value)
                {
                    _conclusion = value;
                    RaisePropertyChanged("conclusion");
                }
            }
        }
        private string _invno;
        public string invno
        {
            get { return _invno; }
            set
            {
                if (_invno != value)
                {
                    _invno = value;
                    RaisePropertyChanged("invno");
                }
            }
        }
        private Nullable<System.DateTime> _invdt;
        public Nullable<System.DateTime> invdt
        {
            get { return _invdt; }
            set
            {
                if (_invdt != value)
                {
                    _invdt = value;
                    RaisePropertyChanged("invdt");
                }
            }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                if (_t_status != value)
                {
                    _t_status = value;
                    RaisePropertyChanged("t_status");
                }
            }
        }

        public string comp_code { get; set; }

        private string _location_Id;
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
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                if (_doc_cat != value)
                {
                    _doc_cat = value;
                    RaisePropertyChanged("doc_cat");
                }
            }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value;
                    RaisePropertyChanged("doc_type");
                }
            }
        }
        private Nullable<bool> _active;
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
        private string _add_by;
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

        private System.DateTime _add_date;
        public System.DateTime add_date
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
        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                if (_edit_by != value)
                {
                    _edit_by = value;
                    RaisePropertyChanged("edit_by");
                }
            }
        }
        public string editby { get; set; }
        private Nullable<System.DateTime> _edit_date;
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

        private string _cmplnt_RecvBy_cd;
        public string cmplnt_RecvBy_cd
        {
            get { return _cmplnt_RecvBy_cd; }
            set
            {
                if (_cmplnt_RecvBy_cd != value)
                {
                    _cmplnt_RecvBy_cd = value;
                    RaisePropertyChanged("cmplnt_RecvBy_cd");
                }
            }
        }

        private string _cmplnt_HandlBy_cd;
        public string cmplnt_HandlBy_cd
        {
            get { return _cmplnt_HandlBy_cd; }
            set
            {
                if (_cmplnt_HandlBy_cd != value)
                {
                    _cmplnt_HandlBy_cd = value;
                    RaisePropertyChanged("cmplnt_HandlBy_cd");
                }
            }
        }
        private decimal _sampl_qty;
        public decimal sampl_qty
        {
            get { return _sampl_qty; }
            set
            {
                if (_sampl_qty != value)
                {
                    _sampl_qty = value;
                    RaisePropertyChanged("sampl_qty");
                }
            }
        }
        private string _sample_status;
        public string sample_status
        {
            get { return _sample_status; }
            set
            {
                if (_sample_status != value)
                {
                    _sample_status = value;
                    RaisePropertyChanged("sample_status");
                }
            }
        }
        private string _sampl_mark;
        public string sampl_mark
        {
            get { return _sampl_mark; }
            set
            {
                if (_sampl_mark != value)
                {
                    _sampl_mark = value;
                    RaisePropertyChanged("sampl_mark");
                }
            }
        }
        private string _sampl_nm;
        public string sampl_nm
        {
            get { return _sampl_nm; }
            set
            {
                if (_sampl_nm != value)
                {
                    _sampl_nm = value;
                    RaisePropertyChanged("sampl_nm");
                }
            }
        }

        private string _ModelNm;
        public string ModelNm
        {
            get { return _ModelNm; }
            set
            {
                if (_ModelNm != value)
                {
                    _ModelNm = value;
                    RaisePropertyChanged("ModelNm");
                }
            }
        }
        private string _LoctnNm;
        public string LoctnNm
        {
            get { return _LoctnNm; }
            set
            {
                if (_LoctnNm != value)
                {
                    _LoctnNm = value;
                    RaisePropertyChanged("LoctnNm");
                }
            }
        }
        private string _PartyNm;

        public string PartyNm
        {
            get { return _PartyNm; }
            set
            {
                if (_PartyNm != value)
                {
                    _PartyNm = value;
                    RaisePropertyChanged("PartyNm");
                }
            }
        }
        private string _ItemCode;

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
        private string _corrective;
        public string corrective
        {
            get { return _corrective; }
            set
            {
                if (_corrective != value)
                {
                    _corrective = value;
                    RaisePropertyChanged("corrective");
                }
            }
        }
        private string _verification_effect;
        public string verification_effect
        {
            get { return _verification_effect; }
            set
            {
                if (_verification_effect != value)
                {
                    _verification_effect = value;
                    RaisePropertyChanged("verification_effect");
                }
            }
        }
        private string _suggestion;
        public string suggestion
        {
            get { return _suggestion; }
            set
            {
                if (_suggestion != value)
                {
                    _suggestion = value;
                    RaisePropertyChanged("suggestion");
                }
            }
        }
        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                if (_fin_year != value)
                {
                    _fin_year = value;
                    RaisePropertyChanged("fin_year");
                }
            }
        }
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                if (_posting_period != value)
                {
                    _posting_period = value;
                    RaisePropertyChanged("posting_period");
                }
            }
        }
        private string _cmplnt_HandlBy_Name;
        public string cmplnt_HandlBy_Name
        {
            get { return _cmplnt_HandlBy_Name; }
            set
            {
                if (_cmplnt_HandlBy_Name != value)
                {
                    _cmplnt_HandlBy_Name = value;
                    RaisePropertyChanged("cmplnt_HandlBy_Name");
                }
            }
        }
        private string _cmplnt_RecvBy_Name;
        public string cmplnt_RecvBy_Name
        {
            get { return _cmplnt_RecvBy_Name; }
            set
            {
                if (_cmplnt_RecvBy_Name != value)
                {
                    _cmplnt_RecvBy_Name = value;
                    RaisePropertyChanged("cmplnt_RecvBy_Name");
                }
            }
        }
        private string _imp_note;
        public string imp_note
        {
            get { return _imp_note; }
            set
            {
                if (_imp_note != value)
                {
                    _imp_note = value;
                    RaisePropertyChanged("imp_note");
                }
            }
        }
        private string _material;
        public string material
        {
            get { return _material; }
            set
            {
                if (_material != value)
                {
                    _material = value;
                    RaisePropertyChanged("material");
                }
            }
        }
        private string _cust_complaint;
        public string cust_complaint
        {
            get { return _cust_complaint; }
            set
            {
                if (_cust_complaint != value)
                {
                    _cust_complaint = value;
                    RaisePropertyChanged("cust_complaint");
                }
            }
        }
        private string _cust_req;
        public string cust_req
        {
            get { return _cust_req; }
            set
            {
                if (_cust_req != value)
                {
                    _cust_req = value;
                    RaisePropertyChanged("cust_req");
                }
            }
        }
        private string _sg_code;
        public string sg_code
        {
            get { return _sg_code; }
            set
            {
                if (_sg_code != value)
                {
                    _sg_code = value;
                    RaisePropertyChanged("sg_code");
                }
            }
        }
        private string _sales_org;
        public string sales_org
        {
            get { return _sales_org; }
            set
            {
                if (_sales_org != value)
                {

                    _sales_org = value;
                    RaisePropertyChanged("sales_org");
                }
            }
        }
        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set
            {
                if (_so_code != value)
                {
                    _so_code = value;
                    RaisePropertyChanged("so_code");
                }
            }
        }

        private string _sg_name;
        public string sg_name
        {
            get { return _sg_name; }
            set
            {
                if (_sg_name != value)
                {
                    _sg_name = value;
                    RaisePropertyChanged("sg_name");
                }
            }
        }
        private string _report_type;
        public string report_type
        {
            get { return _report_type; }
            set
            {
                if (_report_type != value)
                {
                    _report_type = value;
                    RaisePropertyChanged("report_type");
                }
            }
        }
        private string _unit_inv_qty;
        public string unit_inv_qty
        {
            get { return _unit_inv_qty; }
            set
            {
                if (_unit_inv_qty != value)
                {
                    _unit_inv_qty = value;
                    RaisePropertyChanged("unit_inv_qty");
                }
            }
        }
        private string _unit_defect_qty;
        public string unit_defect_qty
        {
            get { return _unit_defect_qty; }
            set
            {
                if (_unit_defect_qty != value)
                {
                    _unit_defect_qty = value;
                    RaisePropertyChanged("unit_defect_qty");
                }
            }
        }
        private int _cust_ink_id;
        public int cust_ink_id
        {
            get { return _cust_ink_id; }
            set
            {
                if (_cust_ink_id != value)
                {
                    _cust_ink_id = value;
                    RaisePropertyChanged("cust_ink_id");
                }
            }
        }
        private string _cust_ink;
        public string cust_ink
        {
            get { return _cust_ink; }
            set
            {
                if (_cust_ink != value)
                {
                    _cust_ink = value;
                    RaisePropertyChanged("cust_ink");
                }
            }
        }
        private bool? _copy;
        public bool? copy
        {
            get { return _copy; }
            set
            {
                if (_copy != value)
                {
                    _copy = value;
                    RaisePropertyChanged("copy");
                }
            }
        }
        private string _prepaper_name;
        public string prepaper_name
        {
            get { return _prepaper_name; }
            set
            {
                if (_prepaper_name != value)
                {
                    _prepaper_name = value; RaisePropertyChanged("prepaper_name");

                }
            }
        }
        private string _approver_name;
        public string approver_name
        {
            get { return _approver_name; }
            set
            {
                if (_approver_name != value)
                {
                    _approver_name = value; RaisePropertyChanged("approver_name");

                }
            }
        }

        private string _causes;
        public string causes
        {
            get { return _causes; }
            set
            {
                if (_causes != value)
                {
                    _causes = value; RaisePropertyChanged("causes");

                }
            }
        }
        private string _observation;
        public string observation
        {
            get { return _observation; }
            set
            {
                if (_observation != value)
                {
                    _observation = value; RaisePropertyChanged("observation");

                }
            }
        }
        private string _pre_tech_dir;
        public string pre_tech_dir
        {
            get { return _pre_tech_dir; }
            set
            {
                if (_pre_tech_dir != value)
                {
                    _pre_tech_dir = value; RaisePropertyChanged("pre_tech_dir");

                }
            }
        }
        private string _pre_unit_head;
        public string pre_unit_head
        {
            get { return _pre_unit_head; }
            set
            {
                if (_pre_unit_head != value)
                {
                    _pre_unit_head = value; RaisePropertyChanged("pre_unit_head");

                }
            }
        }
        private string _pre_QS;
        public string pre_QS
        {
            get { return _pre_QS; }
            set
            {
                if (_pre_QS != value)
                {
                    _pre_QS = value; RaisePropertyChanged("pre_QS");

                }
            }
        }
        private string _pre_others;
        public string pre_others
        {
            get { return _pre_others; }
            set
            {
                if (_pre_others != value)
                {
                    _pre_others = value; RaisePropertyChanged("pre_others");

                }
            }
        }
        private string _corrective_tech_dir;
        public string corrective_tech_dir
        {
            get { return _corrective_tech_dir; }
            set
            {
                if (_corrective_tech_dir != value)
                {
                    _corrective_tech_dir = value; RaisePropertyChanged("corrective_tech_dir");

                }
            }
        }
        private string _corrective_unit_head;
        public string corrective_unit_head
        {
            get { return _corrective_unit_head; }
            set
            {
                if (_corrective_unit_head != value)
                {
                    _corrective_unit_head = value; RaisePropertyChanged("corrective_unit_head");

                }
            }
        }
        private string _corrective_QS;
        public string corrective_QS
        {
            get { return _corrective_QS; }
            set
            {
                if (_corrective_QS != value)
                {
                    _corrective_QS = value; RaisePropertyChanged("corrective_QS");

                }
            }
        }
        private string _corrective_others;
        public string corrective_others
        {
            get { return _corrective_others; }
            set
            {
                if (_corrective_others != value)
                {
                    _corrective_others = value; RaisePropertyChanged("corrective_others");

                }
            }
        }
        private string _con_tech_dir;
        public string con_tech_dir
        {
            get { return _con_tech_dir; }
            set
            {
                if (_con_tech_dir != value)
                {
                    _con_tech_dir = value; RaisePropertyChanged("con_tech_dir");

                }
            }
        }
        private string _con_unit_head;
        public string con_unit_head
        {
            get { return _con_unit_head; }
            set
            {
                if (_con_unit_head != value)
                {
                    _con_unit_head = value; RaisePropertyChanged("con_unit_head");

                }
            }
        }
        private string _con_QS;
        public string con_QS
        {
            get { return _con_QS; }
            set
            {
                if (_con_QS != value)
                {
                    _con_QS = value; RaisePropertyChanged("con_QS");

                }
            }
        }
        private string _con_others;
        public string con_others
        {
            get { return _con_others; }
            set
            {
                if (_con_others != value)
                {
                    _con_others = value; RaisePropertyChanged("con_others");

                }
            }
        }
        private string _doc_name;
        public string doc_name
        {
            get { return _doc_name; }
            set { if (_doc_name != value) { _doc_type = value; RaisePropertyChanged("doc_name"); } }
        }
        private string _no_of_days;
        public string no_of_days
        {
            get { return _no_of_days; }
            set
            {
                if (_no_of_days != value)
                {
                    _no_of_days = value; RaisePropertyChanged("no_of_days");

                }
            }
        }
        private string _batch_no;
        public string batch_no
        {
            get { return _batch_no; }
            set
            {
                if (_batch_no != value)
                {
                    _batch_no = value; RaisePropertyChanged("batch_no");

                }
            }
        }
        private string _pmceo;
        public string pmceo
        {
            get { return _pmceo; }
            set
            {
                if (_pmceo != value)
                {
                    _pmceo = value; RaisePropertyChanged("pmceo");

                }
            }
        }
        public Nullable<System.DateTime> start_date1 { get; set; }
        public Nullable<System.DateTime> End_date { get; set; }
        private string _match_to_tds;
        public string match_to_tds
        {
            get { return _match_to_tds; }
            set
            {
                if (_match_to_tds != value)
                {
                    _match_to_tds = value; RaisePropertyChanged("match_to_tds");

                }
            }
        }
        private string _comment1;
        public string comment1
        {
            get { return _comment1; }
            set
            {
                if (_comment1 != value)
                {
                    _comment1 = value; RaisePropertyChanged("comment1");

                }
            }
        }
        private string _comment2;
        public string comment2
        {
            get { return _comment2; }
            set
            {
                if (_comment2 != value)
                {
                    _comment2 = value; RaisePropertyChanged("comment2");

                }
            }
        }
        private string _audit1;
        public string audit1
        {
            get { return _audit1; }
            set
            {
                if (_audit1 != value)
                {
                    _audit1 = value; RaisePropertyChanged("audit1");

                }
            }
        }
        private string _audit2;
        public string audit2
        {
            get { return _audit2; }
            set
            {
                if (_audit2 != value)
                {
                    _audit2 = value; RaisePropertyChanged("audit2");

                }
            }
        }
        private string _audit3;
        public string audit3
        {
            get { return _audit3; }
            set
            {
                if (_audit3 != value)
                {
                    _audit3 = value; RaisePropertyChanged("audit3");

                }
            }
        }
        public string XmlDataDocument_ECRM_T002_B { get; set; }
        public string XmlDataDocument_ECRM_T002_C { get; set; }

    }
    public class ECRM_T002_B : ObjectBase
    {
        private int _id;
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
       
        private string _quality_feedback_no;
        public string quality_feedback_no
        {
            get { return _quality_feedback_no; }
            set
            {
                if (_quality_feedback_no != value)
                {
                    _quality_feedback_no = value;
                    RaisePropertyChanged("quality_feedback_no");
                }
            }
        }
        private Nullable<int> _defect_id;

        public Nullable<int> defect_id
        {
            get { return _defect_id; }
            set {
                if (_defect_id != value)
                {
                    _defect_id = value; RaisePropertyChanged("defect_id");

                }
            }
        }

        private string _defect_description;
        public string defect_description
        {
            get { return _defect_description; }
            set
            {
                if (_defect_description != value)
                {
                    _defect_description = value;
                    RaisePropertyChanged("defect_description");
                }
            }
        }
        private decimal _no_of_sample;
        public decimal no_of_sample
        {
            get { return _no_of_sample; }
            set
            {
                if (_no_of_sample != value)
                {
                    _no_of_sample = value;
                    RaisePropertyChanged("no_of_sample");
                }
            }
        }
        private string _batch_no;
        public string batch_no
        {
            get { return _batch_no; }
            set
            {
                if (_batch_no != value)
                {
                    _batch_no = value;
                    RaisePropertyChanged("batch_no");
                }
            }
        }
        private string _observation_test;
        public string observation_test
        {
            get { return _observation_test; }
            set
            {
                if (_observation_test != value)
                {
                    _observation_test = value;
                    RaisePropertyChanged("observation_test");
                }
            }
        }
        private string _obsnqa;
        public string obsnqa
        {
            get { return _obsnqa; }
            set
            {
                if (_obsnqa != value)
                {
                    _obsnqa = value;
                    RaisePropertyChanged("obsnqa");
                }
            }
        }
        private string _result_of_test;
        public string result_of_test
        {
            get { return _result_of_test; }
            set
            {
                if (_result_of_test != value)
                {
                    _result_of_test = value;
                    RaisePropertyChanged("result_of_test");
                }
            }
        }
        private string _result_of_test_cust;
        public string result_of_test_cust
        {
            get { return _result_of_test_cust; }
            set
            {
                if (_result_of_test_cust != value)
                {
                    _result_of_test_cust = value;
                    RaisePropertyChanged("result_of_test_cust");
                }
            }
        }
        
       

        private string _causes;
        public string causes
        {
            get { return _causes; }
            set
            {
                if (_causes != value)
                {
                    _causes = value;
                    RaisePropertyChanged("causes");
                }
            }
        }
        private string _preven_actions;
        public string preven_actions
        {
            get { return _preven_actions; }
            set
            {
                if (_preven_actions != value)
                {
                    _preven_actions = value;
                    RaisePropertyChanged("preven_actions");
                }
            }
        }
        private string _observation;
        public string observation
        {
            get { return _observation; }
            set
            {
                if (_observation != value)
                {
                    _observation = value;
                    RaisePropertyChanged("observation");
                }
            }
        }
        
        private string _conclusion;
        public string conclusion
        {
            get { return _conclusion; }
            set
            {
                if (_conclusion != value)
                {
                    _conclusion = value;
                    RaisePropertyChanged("conclusion");
                }
            }
        }
        private string _in_house_rep;
        public string in_house_rep
        {
            get { return _in_house_rep; }
            set
            {
                if (_in_house_rep != value)
                {
                    _in_house_rep = value;
                    RaisePropertyChanged("in_house_rep");
                }
            }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                if (_doc_cat != value)
                {
                    _doc_cat = value;
                    RaisePropertyChanged("doc_cat");
                }
            }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value;
                    RaisePropertyChanged("doc_type");
                }
            }
        }
        private Nullable<bool> _active;
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
        private Nullable<bool> _active1;
        public Nullable<bool> active1
        {
            get { return _active1; }
            set
            {
                if (_active1 != value)
                {
                    _active1 = value;
                    RaisePropertyChanged("active1");
                }
            }
        }
        private string _add_by;
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
        private System.DateTime _add_date;
        public System.DateTime add_date
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
       
        private Nullable<System.DateTime> _edit_date;
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
        private bool _IsRTQFR;

        public bool IsRTQFR
        {
            get { return _IsRTQFR; }
            set {
                if (_IsRTQFR != value)
                {
                    _IsRTQFR = value; RaisePropertyChanged("IsRTQFR");

                }
            }
        }
        public string comp_code { get; set; }
        private string _location_Id;
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
        
        public string editby_cd { get; set; }
      
        private string _material;
        public string material
        {
            get { return _material; }
            set
            {
                if (_material != value)
                {
                    _material = value;
                    RaisePropertyChanged("material");
                }
            }
        }
        private Nullable<System.DateTime> _sam_rec_date;
        public Nullable<System.DateTime> sam_rec_date
        {
            get { return _sam_rec_date; }
            set
            {
                if (_sam_rec_date != value)
                {
                    _sam_rec_date = value;
                    RaisePropertyChanged("sam_rec_date");
                }

            }
        }
        private string _specification;
        public string specification
        {
            get { return _specification; }
            set
            {
                if (_specification != value)
                {
                    _specification = value;
                    RaisePropertyChanged("specification");
                }
            }
        }
        private string _ink;
        public string ink
        {
            get { return _ink; }
            set
            {
                if (_ink != value)
                {
                    _ink = value;
                    RaisePropertyChanged("ink");
                }
            }
        }
        private string _adapter;
        public string adapter
        {
            get { return _adapter; }
            set
            {
                if (_adapter != value)
                {
                    _adapter = value;
                    RaisePropertyChanged("adapter");
                }
            }
        }
        private string _con_sam;
        public string con_sam
        {
            get { return _con_sam; }
            set
            {
                if (_con_sam != value)
                {
                    _con_sam = value;
                    RaisePropertyChanged("con_sam");
                }
            }
        }
    }

    public class ECRM_T002_C : ObjectBase
    {
        private int _id;
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

        private string _quality_feedback_no;
        public string quality_feedback_no
        {
            get { return _quality_feedback_no; }
            set
            {
                if (_quality_feedback_no != value)
                {
                    _quality_feedback_no = value;
                    RaisePropertyChanged("quality_feedback_no");
                }
            }
        }
        private string _test_name;

        public string test_name
        {
            get { return _test_name; }
            set
            {
                if (_test_name != value)
                {
                    _test_name = value; RaisePropertyChanged("test_name");

                }
            }
        }

        private string _test_id;

        public string test_id
        {
            get { return _test_id; }
            set
            {
                if (_test_id != value)
                {
                    _test_id = value; RaisePropertyChanged("test_id");

                }
            }
        }

        private string _result;
        public string result
        {
            get { return _result; }
            set
            {
                if (_result != value)
                {
                    _result = value;
                    RaisePropertyChanged("result");
                }
            }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                if (_doc_cat != value)
                {
                    _doc_cat = value;
                    RaisePropertyChanged("doc_cat");
                }
            }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value;
                    RaisePropertyChanged("doc_type");
                }
            }
        }
        private Nullable<bool> _active;
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
        private string _add_by;
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
        private System.DateTime _add_date;
        public System.DateTime add_date
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
        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                if (_edit_by != value)
                {
                    _edit_by = value;
                    RaisePropertyChanged("edit_by");
                }
            }
        }
        private Nullable<System.DateTime> _edit_date;
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

        public string comp_code { get; set; }
        private string _location_Id;
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


    }
    public class MultipleContext_ECRM_T002_A
    {
        public List<ECRM_T002_A> QulityFeedback { get; set; }//QulityFeedback  
        public ObservableCollection<ECRM_T002_B> QFRDetails { get; set; }//QFR Details
        public ObservableCollection<ECRM_T002_C> testDetails { get; set; }//Test Procedure Details
        public List<ADM_M065_P>TestProcedure { get; set; } //Test Procedure Master
        public List<ECRM_T002_B_P> DefectList { get; set; } //Test Procedure Master
        public List<ZADM_M009_P> Models { get; set; }//Model Master
        public List<ADM_M022_P_ESSEM> Products { get; set; }//Item Master
        public List<ADM_M028_P> Parties { get; set; }//Party_Master
        public List<ZADM_M007_P> ILD { get; set; }//ILD Master  
        public List<ZADM_M006_P> INK { get; set; }//Ink Master 
        public List<ADM_M003_P> Plants { get; set; }//Plant_Master 
        public List<ADM_M024_P> Employees { get; set; }//Employee_Master 
        public List<ZADM_M016_P> Defect { get; set; }// Defect Master  
        public List <ADM_M032_P> MakeMaster { get; set; }//Make Master
        public List<ECRM_T002_A_P> QFRNo { get; set; }//QulityFeedbackno
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public ObservableCollection<SalesInvoice_SingleReport> rptQFR { get; set; }
        public List<ADM_M038_B_P> UnitMaster { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }


    }
}
