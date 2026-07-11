using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M003 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        private string _inst_code;
        public string inst_code
        {
            get { return _inst_code; }
            set { _inst_code = value; RaisePropertyChanged("inst_code"); }
        }
        private string _inst_name;
        public string inst_name
        {
            get { return _inst_name; }
            set { _inst_name = value; RaisePropertyChanged("inst_name"); }
        }
        private string _CatCode;
        public string CatCode
        {
            get { return _CatCode; }
            set { _CatCode = value; RaisePropertyChanged("CatCode"); }
        }
        private string _SubCatCode;
        public string SubCatCode
        {
            get { return _SubCatCode; }
            set { _SubCatCode = value; RaisePropertyChanged("SubCatCode"); }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private string _inst_make;
        public string inst_make
        {
            get { return _inst_make; }
            set { _inst_make = value; RaisePropertyChanged("inst_make"); }
        }
        private string _range;
        public string range
        {
            get { return _range; }
            set { _range = value; RaisePropertyChanged("range"); }
        }
        private string _maint_src;
        public string maint_src
        {
            get { return _maint_src; }
            set { _maint_src = value; RaisePropertyChanged("maint_src"); }
        }
        private string _rig_code;
        public string rig_code
        {
            get { return _rig_code; }
            set { _rig_code = value; RaisePropertyChanged("rig_code"); }
        }
        private string _cal_src;
        public string cal_src
        {
            get { return _cal_src; }
            set { _cal_src = value; RaisePropertyChanged("cal_src"); }
        }
        private string _cd_name;
        public string cd_name
        {
            get { return _cd_name; }
            set { _cd_name = value; RaisePropertyChanged("cd_name"); }
        }
        private decimal? _accuracy_up;
        public decimal? accuracy_up
        {
            get { return _accuracy_up; }
            set { _accuracy_up = value; RaisePropertyChanged("accuracy_up"); }
        }
        private decimal? _least_cnt;
        public decimal? least_cnt
        {
            get { return _least_cnt; }
            set { _least_cnt = value; RaisePropertyChanged("least_cnt"); }
        }
        private decimal? _calfreq;
        public decimal? calfreq
        {
            get { return _calfreq; }
            set { _calfreq = value; RaisePropertyChanged("calfreq", ModelEntityUpdated); }
        }
        private string _calperiod;
        public string calperiod
        {
            get { return _calperiod; }
            set { _calperiod = value; RaisePropertyChanged("calperiod", ModelEntityUpdated); }
        }
        private string _cal_inst;
        public string cal_inst
        {
            get { return _cal_inst; }
            set { _cal_inst = value; RaisePropertyChanged("cal_inst"); }
        }
        private string _cal_cat;
        public string cal_cat
        {
            get { return _cal_cat; }
            set { _cal_cat = value; RaisePropertyChanged("cal_cat"); }
        }
        private decimal? _appr_cost;
        public decimal? appr_cost
        {
            get { return _appr_cost; }
            set { _appr_cost = value; RaisePropertyChanged("appr_cost"); }
        }
        private string _tech_spec;
        public string tech_spec
        {
            get { return _tech_spec; }
            set { _tech_spec = value; RaisePropertyChanged("tech_spec"); }
        }
        private DateTime? _pur_date;
        public DateTime? pur_date
        {
            get { return _pur_date; }
            set { _pur_date = value; RaisePropertyChanged("pur_date"); }
        }
        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set { _po_no = value; RaisePropertyChanged("po_no"); }
        }
        private string _req_no;
        public string req_no
        {
            get { return _req_no; }
            set { _req_no = value; RaisePropertyChanged("req_no"); }
        }
        private string _bdgt_type;
        public string bdgt_type
        {
            get { return _bdgt_type; }
            set { _bdgt_type = value; RaisePropertyChanged("bdgt_type"); }
        }
        private string _cal_rpt;
        public string cal_rpt
        {
            get { return _cal_rpt; }
            set { _cal_rpt = value; RaisePropertyChanged("cal_rpt"); }
        }
        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set { _PartyId = value; RaisePropertyChanged("PartyId"); }
        }
        private string _inv_no;
        public string inv_no
        {
            get { return _inv_no; }
            set { _inv_no = value; RaisePropertyChanged("inv_no"); }
        }
        private string _cal_agency;
        public string cal_agency
        {
            get { return _cal_agency; }
            set { _cal_agency = value; RaisePropertyChanged("cal_agency"); }
        }
        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set { _barcode = value; RaisePropertyChanged("barcode"); }
        }
        private string _lab_code;
        public string lab_code
        {
            get { return _lab_code; }
            set { _lab_code = value; RaisePropertyChanged("lab_code"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private DateTime _add_date;
        public DateTime add_date
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
        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
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
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        private string _language;
        public string language
        {
            get { return _language; }
            set
            {
                _language = value;
                RaisePropertyChanged("language");
            }
        }
     
        private decimal? _weight;
        public decimal? weight
        {
            get { return _weight; }
            set { _weight = value; RaisePropertyChanged("weight"); }
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
        
        private string _inst_srno;
        public string inst_srno
        {
            get { return _inst_srno; }
            set
            {
                _inst_srno = value;
                RaisePropertyChanged("inst_srno");
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
        private string _cal_status;
        public string cal_status
        {
            get { return _cal_status; }
            set
            {
                _cal_status = value;
                RaisePropertyChanged("cal_status");
            }
        }
        private DateTime _cal_lastdate;
        public DateTime cal_lastdate
        {
            get { return _cal_lastdate; }
            set
            {
                _cal_lastdate = value;
                RaisePropertyChanged("cal_lastdate", ModelEntityUpdated);
            }
        }
        private DateTime? _due_date;
        public DateTime? due_date
        {
            get { return _due_date; }
            set
            {
                _due_date = value;
                RaisePropertyChanged("due_date");
            }
        }
        private DateTime? _next_date;
        public DateTime? next_date
        {
            get { return _next_date; }
            set
            {
                _next_date = value;
                RaisePropertyChanged("next_date", ModelEntityUpdated);
            }
        }

        private bool? _sick_bit;
        public bool? sick_bit
        {
            get { return _sick_bit; }
            set
            {
                _sick_bit = value;
                RaisePropertyChanged("sick_bit");
            }
        }
        private string _email;
        public string email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged("email");
            }
        }
        private string _model_no;
        public string model_no
        {
            get { return _model_no; }
            set
            {
                _model_no = value;
                RaisePropertyChanged("model_no");
            }
        }
        private DateTime? _warranty_date;
        public DateTime? warranty_date
        {
            get { return _warranty_date; }
            set
            {
                _warranty_date = value;
                RaisePropertyChanged("warranty_date");
            }
        }
        private string _make_year;
        public string make_year
        {
            get { return _make_year; }
            set { _make_year = value; RaisePropertyChanged("make_year"); }
        }
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode"); }
        }

        private decimal? _upper_range;
        public decimal? upper_range
        {
            get { return _upper_range; }
            set { _upper_range = value; RaisePropertyChanged("upper_range"); }
        }

        private decimal? _lower_range;
        public decimal? lower_range
        {
            get { return _lower_range; }
            set { _lower_range = value; RaisePropertyChanged("lower_range"); }
        }
        private string _range_unit;
        public string range_unit
        {
            get { return _range_unit; }
            set { _range_unit = value; RaisePropertyChanged("range_unit"); }
        }
        private string _upper_range_unit;
        public string upper_range_unit
        {
            get { return _upper_range_unit; }
            set { _upper_range_unit = value; RaisePropertyChanged("upper_range_unit"); }
        }
        private string _lower_range_unit;
        public string lower_range_unit
        {
            get { return _lower_range_unit; }
            set { _lower_range_unit = value; RaisePropertyChanged("lower_range_unit"); }
        }
        private string _accuracy_up_unit;
        public string accuracy_up_unit
        {
            get { return _accuracy_up_unit; }
            set { _accuracy_up_unit = value; RaisePropertyChanged("accuracy_up_unit"); }
        }
        private string _resolution_unit;
        public string resolution_unit
        {
            get { return _resolution_unit; }
            set { _resolution_unit = value; RaisePropertyChanged("resolution_unit"); }
        }
        private string _least_count_unit;
        public string least_count_unit
        {
            get { return _least_count_unit; }
            set { _least_count_unit = value; RaisePropertyChanged("least_count_unit"); }
        }
        private decimal? _uncertainty;
        public decimal? uncertainty
        {
            get { return _uncertainty; }
            set { _uncertainty = value; RaisePropertyChanged("uncertainty"); }
        }
        private string _uncertainty_unit;
        public string uncertainty_unit
        {
            get { return _uncertainty_unit; }
            set { _uncertainty_unit = value; RaisePropertyChanged("uncertainty_unit"); }
        }
        private decimal? _accuracy_down;
        public decimal? accuracy_down
        {
            get { return _accuracy_down; }
            set { _accuracy_down = value; RaisePropertyChanged("accuracy_down"); }
        }
        private string _accuracy_down_unit;
        public string accuracy_down_unit
        {
            get { return _accuracy_down_unit; }
            set { _accuracy_down_unit = value; RaisePropertyChanged("accuracy_down_unit"); }
        }

        // Scalar       
        private string _lab_name;
        public string lab_name
        {
            get { return _lab_name; }
            set { _lab_name = value; RaisePropertyChanged("lab_name"); }
        }
        private string _CatName;
        public string CatName
        {
            get { return _CatName; }
            set { _CatName = value; RaisePropertyChanged("CatName"); }
        }
        private string _SubCatName;
        public string SubCatName
        {
            get { return _SubCatName; }
            set { _SubCatName = value; RaisePropertyChanged("SubCatName"); }
        }
        private string _rig_name;
        public string rig_name
        {
            get { return _rig_name; }
            set { _rig_name = value; RaisePropertyChanged("rig_name"); }
        }
        private string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set { _PartyNm = value; RaisePropertyChanged("PartyNm"); }
        }
        private string _cal_inst_name;
        public string cal_inst_name
        {
            get { return _cal_inst_name; }
            set { _cal_inst_name = value; RaisePropertyChanged("cal_inst_name"); }
        }
        private DateTime? _po_date;
        public DateTime? po_date
        {
            get { return _po_date; }
            set { _po_date = value; RaisePropertyChanged("po_date"); }
        }
        private DateTime? _date_start;
        public DateTime? date_start
        {
            get { return _date_start; }
            set { _date_start = value; RaisePropertyChanged("date_start"); }
        }
        private DateTime? _inv_date;
        public DateTime? inv_date
        {
            get { return _inv_date; }
            set { _inv_date = value; RaisePropertyChanged("inv_date"); }
        }
        private string _EmpName;
        public string EmpName
        {
            get { return _EmpName; }
            set { _EmpName = value; RaisePropertyChanged("EmpName"); }
        }
        private string _location;
        public string location
        {
            get { return _location; }
            set { _location = value; RaisePropertyChanged("location"); }
        }
        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; RaisePropertyChanged("ItemName"); }
        }
        private string _inst_id;
        public string inst_id
        {
            get { return _inst_id; }
            set { _inst_id = value; RaisePropertyChanged("inst_id"); }
        }

        private string _tr_code;
        public string tr_code
        {
            get { return _tr_code; }
            set { _tr_code = value; RaisePropertyChanged("tr_code"); }
        }

        private decimal? _resolution;
        public decimal? resolution
        {
            get { return _resolution; }
            set { _resolution = value; RaisePropertyChanged("resolution"); }
        }
        //Scalar
        private string _tr_name;
        public string tr_name
        {
            get { return _tr_name; }
            set
            {
                _tr_name = value;
                RaisePropertyChanged("tr_name");
            }
        }

        public string XmlDataDocument_QMS_M003_A { get; set; }
        public string XmlDataDocument_QMS_M003_B { get; set; }
        public string XmlDataDocument_QMS_M003FLIP { get; set; }

    }
    public class QMS_M003_A : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        private string _ItemScope;
        public string ItemScope
        {
            get { return _ItemScope; }
            set { _ItemScope = value; RaisePropertyChanged("ItemScope"); }
        }
        private string _ItemType { get; set; }
        public string ItemType
        {
            get { return _ItemType; }
            set { _ItemType = value; RaisePropertyChanged("ItemType"); }
        }
        private string _inst_code;
        public string inst_code
        {
            get { return _inst_code; }
            set { _inst_code = value; RaisePropertyChanged("inst_code"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private DateTime _add_date;
        public DateTime add_date
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
        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
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
        private string _language;
        public string language
        {
            get { return _language; }
            set
            {
                _language = value;
                RaisePropertyChanged("language");
            }
        }
      
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode"); }
        }
        // Scalar

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
    }
    public class QMS_M003_B : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        private string _inst_code;
        public string inst_code
        {
            get { return _inst_code; }
            set { _inst_code = value; RaisePropertyChanged("inst_code"); }
        }
        private string _para_code;
        public string para_code
        {
            get { return _para_code; }
            set { _para_code = value; RaisePropertyChanged("para_code"); }
        }
        private string _para_value { get; set; }
        public string para_value
        {
            get { return _para_value; }
            set { _para_value = value; RaisePropertyChanged("para_value"); }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }
        private DateTime? _valid_from;
        public DateTime? valid_from
        {
            get { return _valid_from; }
            set
            {
                _valid_from = value;
                RaisePropertyChanged("valid_from");
            }
        }
        private DateTime? _valid_to;
        public DateTime? valid_to
        {
            get { return _valid_to; }
            set
            {
                _valid_to = value;
                RaisePropertyChanged("valid_to");
            }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private DateTime _add_date;
        public DateTime add_date
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
        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
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
        private string _language;
        public string language
        {
            get { return _language; }
            set
            {
                _language = value;
                RaisePropertyChanged("language");
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
        private string _para_type;
        public string para_type
        {
            get { return _para_type; }
            set
            {
                _para_type = value;
                RaisePropertyChanged("para_type");
            }
        }
        private string _value_code;
        public string value_code
        {
            get { return _value_code; }
            set
            {
                _value_code = value;
                RaisePropertyChanged("value_code");
            }
        }
        //scalar
        private string _para_name;
        public string para_name
        {
            get { return _para_name; }
            set { _para_name = value; RaisePropertyChanged("para_name"); }
        }
        private bool? _allow_null;
        public bool? allow_null
        {
            get { return _allow_null; }
            set { _allow_null = value; RaisePropertyChanged("allow_null"); }
        }
    }
    public class MultipleContext_QMS_M003
    {
        public List<QMS_M003Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M003_B_P> Laboratory { get; set; }  //labrotory Master   
        public List<ADM_M018_P> Cat { get; set; }  //group Master
        public List<ADM_M019_P> SubCat { get; set; }  //subgroup Master
        public List<QMS_M008_P> Rig { get; set; }  //rig Master
        public List<Inst_Pur_Details_P> PurOrder { get; set; } //PO Number
        public List<Inst_Pur_Details_P> ReqNo { get; set; } //Requisition Number
        public List<Inst_Pur_Details_P> PurInvoice { get; set; } //PI Number
        public List<ADM_M028_P> Supplier { get; set; }  //Party Master  
        public List<QMS_M003_P> CalInst { get; set; }
        public List<ADM_M022_P> AccItem { get; set; }  //Accessories from item Master
        public List<QMS_M004_P> AccScope { get; set; } // Accessory scope
        public List<ADM_M024_P> Employees { get; set; } // Responsible Person
        public List<COM_T003> Attachment { get; set; } // Attachment Collection
        public List<QMS_M010_P> Tracibility { get; set; }
        public List<ADM_M038_B_P> UnitMaster { get; set; } //Unit Master
        public List<QMS_M009_F> ParameterCode { get; set; } //Parameter Master
        public List<QMS_M003> MasterEntity { get; set; }  //Intrument Master
        public ObservableCollection<QMS_M003_A> Accessory { get; set; }  //Accessory Master
        public ObservableCollection<QMS_M003_B> DetailEntity { get; set; }  //Parameter Master
    }
    public class QMS_CAL : ObjectBase
    {
        public string doc_no { get; set; }
        public string test_code { get; set; }
        public string inst_code { get; set; }
        public DateTime? cal_lastdate { get; set; }
        public DateTime? next_date { get; set; }
        public string cal_type { get; set; }
        public string PartyId { get; set; }
        public string po_no { get; set; }
        public string t_status { get; set; }
        public string status_remark { get; set; }
        public string ref_doc_no { get; set; }
        //Scalar
        public string PartyNm { get; set; }
        public string inst_name { get; set; }
        public string test_name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
