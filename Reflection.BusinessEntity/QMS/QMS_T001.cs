using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_T001 : ObjectBase
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

        private string _lab_code;
        public string lab_code
        {
            get { return _lab_code; }
            set
            {
                _lab_code = value;
                RaisePropertyChanged("lab_code");
            }
        }

        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set
            {
                _barcode = value;
                RaisePropertyChanged("barcode");
            }
        }

        private string _test_code;
        public string test_code
        {
            get { return _test_code; }
            set
            {
                _test_code = value;
                RaisePropertyChanged("test_code");
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

        private string _rig_code;
        public string rig_code
        {
            get { return _rig_code; }
            set
            {
                _rig_code = value;
                RaisePropertyChanged("rig_code");
            }
        }

        private string _tr_code;
        public string tr_code
        {
            get { return _tr_code; }
            set
            {
                _tr_code = value;
                RaisePropertyChanged("tr_code");
            }
        }

        private string _temperature;
        public string temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                RaisePropertyChanged("temperature");
            }
        }

        private string _humidity;
        public string humidity
        {
            get { return _humidity; }
            set
            {
                _humidity = value;
                RaisePropertyChanged("humidity");
            }
        }

        private string _remark1;
        public string remark1
        {
            get { return _remark1; }
            set
            {
                _remark1 = value;
                RaisePropertyChanged("remark1");
            }
        }

        private string _remark2;
        public string remark2
        {
            get { return _remark2; }
            set
            {
                _remark2 = value;
                RaisePropertyChanged("remark2");
            }
        }

        private string _remark3;
        public string remark3
        {
            get { return _remark3; }
            set
            {
                _remark3 = value;
                RaisePropertyChanged("remark3");
            }
        }

        private string _master_inst;
        public string master_inst
        {
            get { return _master_inst; }
            set
            {
                _master_inst = value;
                RaisePropertyChanged("master_inst");
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

        private string _cal_type;
        public string cal_type
        {
            get { return _cal_type; }
            set
            {
                _cal_type = value;
                RaisePropertyChanged("cal_type");
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

        private int _ContInfoId;
        public int ContInfoId
        {
            get { return _ContInfoId; }
            set
            {
                _ContInfoId = value;
                RaisePropertyChanged("ContInfoId");
            }
        }

        private DateTime? _cal_date;
        public DateTime? cal_date
        {
            get { return _cal_date; }
            set
            {
                _cal_date = value;
                RaisePropertyChanged("cal_date");
            }
        }

        private DateTime? _last_date;
        public DateTime? last_date
        {
            get { return _last_date; }
            set
            {
                _last_date = value;
                RaisePropertyChanged("last_date");
            }
        }

        private int _cal_freq;
        public int cal_freq
        {
            get { return _cal_freq; }
            set
            {
                _cal_freq = value;
                RaisePropertyChanged("cal_freq");
            }
        }

        private string _cal_period;
        public string cal_period
        {
            get { return _cal_period; }
            set
            {
                _cal_period = value;
                RaisePropertyChanged("cal_period");
            }
        }

        private DateTime? _next_date;
        public DateTime? next_date
        {
            get { return _next_date; }
            set
            {
                _next_date = value;
                RaisePropertyChanged("next_date");
            }
        }

        #region Default Fields
        private string _u_remark1;
        public string u_remark1
        {
            get { return _u_remark1; }
            set
            {
                _u_remark1 = value;
                RaisePropertyChanged("u_remark1");
            }
        }

        private string _u_remark2;
        public string u_remark2
        {
            get { return _u_remark2; }
            set
            {
                _u_remark2 = value;
                RaisePropertyChanged("u_remark2");
            }
        }

        private string _u_remark3;
        public string u_remark3
        {
            get { return _u_remark3; }
            set
            {
                _u_remark3 = value;
                RaisePropertyChanged("u_remark3");
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

        private DateTime _add_date;
        public DateTime add_date
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

        

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                _lang_key = value;
                RaisePropertyChanged("lang_key");
            }
        }

        #endregion

        private string _start_temp;
        public string start_temp
        {
            get { return _start_temp; }
            set
            {
                _start_temp = value;
                RaisePropertyChanged("start_temp");
            }
        }

        private string _end_temp;
        public string end_temp
        {
            get { return _end_temp; }
            set
            {
                _end_temp = value;
                RaisePropertyChanged("end_temp");
            }
        }

        private string _start_time;
        public string start_time
        {
            get { return _start_time; }
            set
            {
                _start_time = value;
                RaisePropertyChanged("start_time");
            }
        }

        private string _end_time;
        public string end_time
        {
            get { return _end_time; }
            set
            {
                _end_time = value;
                RaisePropertyChanged("end_time");
            }
        }

        private DateTime? _doc_date;
        public DateTime? doc_date
        {
            get { return _doc_date; }
            set
            {
                _doc_date = value;
                RaisePropertyChanged("doc_date");
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

        private string _inst_code;
        public string inst_code
        {
            get { return _inst_code; }
            set
            {
                _inst_code = value;
                RaisePropertyChanged("inst_code");
            }
        }

        private string _inst_name;
        public string inst_name
        {
            get { return _inst_name; }
            set
            {
                _inst_name = value;
                RaisePropertyChanged("inst_name");
            }
        }

        private string _serv_type;
        public string serv_type
        {
            get { return _serv_type; }
            set
            {
                _serv_type = value;
                RaisePropertyChanged("serv_type");
            }
        }

        private string _insp_lot_no;
        public string insp_lot_no
        {
            get { return _insp_lot_no; }
            set
            {
                _insp_lot_no = value;
                RaisePropertyChanged("insp_lot_no");
            }
        }
        private decimal? _resolution;
        public decimal? resolution
        {
            get { return _resolution; }
            set
            {
                _resolution = value;
                RaisePropertyChanged("resolution");
            }
        }
        private string _middle_temp;
        public string middle_temp
        {
            get { return _middle_temp; }
            set
            {
                _middle_temp = value;
                RaisePropertyChanged("middle_temp");
            }
        }
        private string _authEmpId;
        public string authEmpId
        {
            get { return _authEmpId; }
            set
            {
                _authEmpId = value;
                RaisePropertyChanged("authEmpId");
            }
        }
        private string _siteEmpId;
        public string siteEmpId
        {
            get { return _siteEmpId; }
            set
            {
                _siteEmpId = value;
                RaisePropertyChanged("siteEmpId");
            }
        }
        //scalar
        private string _test_name;
        public string test_name
        {
            get { return _test_name; }
            set
            {
                _test_name = value;
                RaisePropertyChanged("test_name");
            }
        }

        private string _inst_id;
        public string inst_id
        {
            get { return _inst_id; }
            set
            {
                _inst_id = value;
                RaisePropertyChanged("inst_id");
            }
        }

        private string _inst_make;
        public string inst_make
        {
            get { return _inst_make; }
            set
            {
                _inst_make = value;
                RaisePropertyChanged("inst_make");
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

        private decimal? _least_count;
        public decimal? least_count
        {
            get { return _least_count; }
            set
            {
                _least_count = value;
                RaisePropertyChanged("least_count");
            }
        }

        private string _range;
        public string range
        {
            get { return _range; }
            set
            {
                _range = value;
                RaisePropertyChanged("range");
            }
        }

        private decimal? _accuracy_up;
        public decimal? accuracy_up
        {
            get { return _accuracy_up; }
            set
            {
                _accuracy_up = value;
                RaisePropertyChanged("_accuracy_up");
            }
        }

        private string _cont_per_name;
        public string cont_per_name
        {
            get { return _cont_per_name; }
            set
            {
                _cont_per_name = value;
                RaisePropertyChanged("cont_per_name");
            }
        }

        private string _EmpNm;
        public string EmpNm
        {
            get { return _EmpNm; }
            set
            {
                _EmpNm = value;
                RaisePropertyChanged("EmpNm");
            }
        }

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

        private string _rig_name;
        public string rig_name
        {
            get { return _rig_name; }
            set
            {
                _rig_name = value;
                RaisePropertyChanged("rig_name");
            }
        }

        private string _lab_name;
        public string lab_name
        {
            get { return _lab_name; }
            set
            {
                _lab_name = value;
                RaisePropertyChanged("lab_name");
            }
        }

        private DateTime? _FromDate;
        public DateTime? FromDate
        {
            get { return _FromDate; }
            set
            {
                _FromDate = value;
                RaisePropertyChanged("FromDate");
            }
        }
        private DateTime? _ToDate;
        public DateTime? ToDate
        {
            get { return _ToDate; }
            set
            {
                _ToDate = value;
                RaisePropertyChanged("ToDate");
            }
        }
        public string TranCode { get; set; }
        private bool _Select;
        public bool Select
        {
            get
            {
                return _Select;
            }
            set
            {
                _Select = value;
                RaisePropertyChanged("Select");
            }
        }
        private string _to_mail_id;
        public string to_mail_id
        {
            get { return _to_mail_id; }
            set
            {
                _to_mail_id = value;
                RaisePropertyChanged("to_mail_id");
            }
        }
        private string _master_inst_name;
        public string master_inst_name
        {
            get { return _master_inst_name; }
            set
            {
                _master_inst_name = value;
                RaisePropertyChanged("master_inst_name");
            }
        }
        private string _inst_cond;
        public string inst_cond
        {
            get { return _inst_cond; }
            set
            {
                _inst_cond = value;
                RaisePropertyChanged("inst_cond");
            }
        }
        private string _cust_name;
        public string cust_name
        {
            get { return _cust_name; }
            set
            {
                _cust_name = value;
                RaisePropertyChanged("cust_name");
            }
        }
        private string _BenchValue;
        public string BenchValue
        {
            get { return _BenchValue; }
            set
            {
                if (_BenchValue != value)
                {
                    _BenchValue = value;
                    RaisePropertyChanged("BenchValue");
                }
            }
        }
        private string _insp_cat;
        public string insp_cat
        {
            get { return _insp_cat; }
            set
            {
                _insp_cat = value;
                RaisePropertyChanged("insp_cat");
            }
        }
        //private bool? _copy;
        //public bool? copy
        //{
        //    get { return _copy; }
        //    set
        //    {
        //        _copy = value;
        //        RaisePropertyChanged("copy", ModelEntityUpdated);
        //    }
        //}
        private string _authEmpNm;
        public string authEmpNm
        {
            get { return _authEmpNm; }
            set
            {
                _authEmpNm = value;
                RaisePropertyChanged("authEmpNm");
            }
        }
        public decimal? _avg_value;
        public decimal? avg_value
        {
            get { return _avg_value; }
            set
            {
                _avg_value = value;
                RaisePropertyChanged("avg_value");
            }
        }
        public decimal? _dev_value;
        public decimal? dev_value
        {
            get { return _dev_value; }
            set
            {
                _dev_value = value;
                RaisePropertyChanged("dev_value");
            }
        }
        public decimal? _dev_mean_value;
        public decimal? dev_mean_value
        {
            get { return _dev_mean_value; }
            set
            {
                _dev_mean_value = value;
                RaisePropertyChanged("dev_mean_value");
            }
        }
        public int? _degree_of_frdm;
        public int? degree_of_frdm
        {
            get { return _degree_of_frdm; }
            set
            {
                _degree_of_frdm = value;
                RaisePropertyChanged("degree_of_frdm");
            }
        }
        public decimal? _combine_uncertainty;
        public decimal? combine_uncertainty
        {
            get { return _combine_uncertainty; }
            set
            {
                _combine_uncertainty = value;
                RaisePropertyChanged("combine_uncertainty");
            }
        }
        public decimal? _eff_degree_of_frdm;
        public decimal? eff_degree_of_frdm
        {
            get { return _eff_degree_of_frdm; }
            set
            {
                _eff_degree_of_frdm = value;
                RaisePropertyChanged("eff_degree_of_frdm");
            }
        }
        public decimal? _coverage_factor;
        public decimal? coverage_factor
        {
            get { return _coverage_factor; }
            set
            {
                _coverage_factor = value;
                RaisePropertyChanged("coverage_factor");
            }
        }
        public string _conf_level;
        public string conf_level
        {
            get { return _conf_level; }
            set
            {
                _conf_level = value;
                RaisePropertyChanged("conf_level");
            }
        }
        public decimal? _expanded_uncertainty;
        public decimal? expanded_uncertainty
        {
            get { return _expanded_uncertainty; }
            set
            {
                _expanded_uncertainty = value;
                RaisePropertyChanged("expanded_uncertainty");
            }
        }
        public decimal? _expanded_uncertainty_per;
        public decimal? expanded_uncertainty_per
        {
            get { return _expanded_uncertainty_per; }
            set
            {
                _expanded_uncertainty_per = value;
                RaisePropertyChanged("expanded_uncertainty_per");
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
        private string _range_unit;
        public string range_unit
        {
            get { return _range_unit; }
            set { _range_unit = value; RaisePropertyChanged("range_unit"); }
        }

        private string _accuracy_up_unit;
        public string accuracy_up_unit
        {
            get { return _accuracy_up_unit; }
            set { _accuracy_up_unit = value; RaisePropertyChanged("accuracy_up_unit"); }
        }

        private string _least_count_unit;
        public string least_count_unit
        {
            get { return _least_count_unit; }
            set { _least_count_unit = value; RaisePropertyChanged("least_count_unit"); }
        }

        private string _resolution_unit;
        public string resolution_unit
        {
            get { return _resolution_unit; }
            set { _resolution_unit = value; RaisePropertyChanged("resolution_unit"); }
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
        public string authEmp_desig { get; set; }
        public string wi_desc { get; set; }
        private string _report_no;
        public string report_no
        {
            get { return _report_no; }
            set { _report_no = value; RaisePropertyChanged("report_no"); }
        }
        private string _siteEmpNm;
        public string siteEmpNm
        {
            get { return _siteEmpNm; }
            set
            {
                _siteEmpNm = value;
                RaisePropertyChanged("siteEmpNm");
            }
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
        public string bill_address { get; set; }
        // Xml Documents Variables
        public string XmlDataDocument_QMS_T001Flip { get; set; }
        public string XmlDataDocument_QMS_T001_A { get; set; }
        public string XmlDataDocument_QMS_T001_B { get; set; }
        public string XmlDataDocument_QMS_T001_C { get; set; }
        public string XmlDataDocument_QMS_M003_B { get; set; }
        public string XmlDataDocument_QMS_M009_B { get; set; }
        public string XmlDataDocument_QMS_M009_C { get; set; }
        public string XmlDataDocument_QMS_M009_D { get; set; }
        public string XmlDataDocument_QMS_M009_E_M { get; set; }
        public string XmlDataDocument_QMS_M009_E_I { get; set; }
        public string XmlDataDocument_QMS_T001_E { get; set; }
        public string XmlDataDocument_QMS_T001_F { get; set; }
        public string XmlDataDocument_QMS_M009_J { get; set; }
    }

    public class QMS_T001_A : ObjectBase
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
        private string _tr_code;
        public string tr_code
        {
            get { return _tr_code; }
            set
            {
                _tr_code = value;
                RaisePropertyChanged("tr_code");
            }
        }
        private string _uncertainty;
        public string uncertainty
        {
            get { return _uncertainty; }
            set
            {
                _uncertainty = value;
                RaisePropertyChanged("uncertainty");
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

        #region Default Fields
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

        private DateTime _add_date;
        public DateTime add_date
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

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                _lang_key = value;
                RaisePropertyChanged("lang_key");
            }
        }

        
        #endregion

        //Scalar
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
        private string _range;
        public string range
        {
            get { return _range; }
            set
            {
                _range = value;
                RaisePropertyChanged("range");
            }
        }
        private decimal? _resolution;
        public decimal? resolution
        {
            get { return _resolution; }
            set
            {
                _resolution = value;
                RaisePropertyChanged("resolution");
            }
        }
        private decimal? _accuracy_up;
        public decimal? accuracy_up
        {
            get { return _accuracy_up; }
            set
            {
                _accuracy_up = value;
                RaisePropertyChanged("accuracy_up");
            }
        }
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
        private string _inst_make;
        public string inst_make
        {
            get { return _inst_make; }
            set
            {
                _inst_make = value;
                RaisePropertyChanged("inst_make");
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
        private string _cal_src;
        public string cal_src
        {
            get { return _cal_src; }
            set
            {
                _cal_src = value;
                RaisePropertyChanged("cal_src");
            }
        }
        public decimal? accuracy_down { get; set; }
        public decimal? least_count { get; set; }
        public decimal? upper_range { get; set; }
        public decimal? lower_range { get; set; }
        private string _report_parameter1;
        public string report_parameter1
        {
            get { return _report_parameter1; }
            set
            {
                _report_parameter1 = value;
                RaisePropertyChanged("report_parameter1");
            }
        }
        //private string _report_parameter2;
        //public string report_parameter2
        //{
        //    get { return _report_parameter2; }
        //    set
        //    {
        //        _report_parameter2 = value;
        //        RaisePropertyChanged("report_parameter2");
        //    }
        //}
    }

    public class QMS_T001_B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _tm_id;
        public int tm_id
        {
            get { return _tm_id; }
            set
            {
                _tm_id = value;
                RaisePropertyChanged("tm_id");
            }
        }

        private string _test_type_code;
        public string test_type_code
        {
            get { return _test_type_code; }
            set
            {
                _test_type_code = value;
                RaisePropertyChanged("test_type_code");
            }
        }

        private int? _seq_no;
        public int? seq_no
        {
            get { return _seq_no; }
            set
            {
                _seq_no = value;
                RaisePropertyChanged("seq_no");
            }
        }

        private int? _value_id1;
        public int? value_id1
        {
            get { return _value_id1; }
            set
            {
                if (_value_id1 != value)
                {
                    _value_id1 = value;
                    RaisePropertyChanged("value_id1", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id2;
        public int? value_id2
        {
            get { return _value_id2; }
            set
            {
                if (_value_id2 != value)
                {
                    _value_id2 = value;
                    RaisePropertyChanged("value_id2", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id3;
        public int? value_id3
        {
            get { return _value_id3; }
            set
            {
                if (_value_id3 != value)
                {
                    _value_id3 = value;
                    RaisePropertyChanged("value_id3", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id4;
        public int? value_id4
        {
            get { return _value_id4; }
            set
            {
                if (_value_id4 != value)
                {
                    _value_id4 = value;
                    RaisePropertyChanged("value_id4", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id5;
        public int? value_id5
        {
            get { return _value_id5; }
            set
            {
                if (_value_id5 != value)
                {
                    _value_id5 = value;
                    RaisePropertyChanged("value_id5", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id6;
        public int? value_id6
        {
            get { return _value_id6; }
            set
            {
                if (_value_id6 != value)
                {
                    _value_id6 = value;
                    RaisePropertyChanged("value_id6", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id7;
        public int? value_id7
        {
            get { return _value_id7; }
            set
            {
                if (_value_id7 != value)
                {
                    _value_id7 = value;
                    RaisePropertyChanged("value_id7", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id8;
        public int? value_id8
        {
            get { return _value_id8; }
            set
            {
                if (_value_id8 != value)
                {
                    _value_id8 = value;
                    RaisePropertyChanged("value_id8", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id9;
        public int? value_id9
        {
            get { return _value_id9; }
            set
            {
                if (_value_id9 != value)
                {
                    _value_id9 = value;
                    RaisePropertyChanged("value_id9", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id10;
        public int? value_id10
        {
            get { return _value_id10; }
            set
            {
                if (_value_id10 != value)
                {
                    _value_id10 = value;
                    RaisePropertyChanged("value_id10", ModelEntityUpdated);
                }
            }
        }

        private decimal? _value1;
        public decimal? value1
        {
            get { return _value1; }
            set
            {
                if (_value1.ToString() != value.ToString())
                {
                    _value1 = value;
                    RaisePropertyChanged("value1", ModelEntityUpdated);
                    //RaisePropertyChanged("value1");
                }
            }
        }

        private decimal? _value2;
        public decimal? value2
        {
            get { return _value2; }
            set
            {
                if (_value2.ToString() != value.ToString())
                {
                    _value2 = value;
                    RaisePropertyChanged("value2", ModelEntityUpdated);
                    //RaisePropertyChanged("value2");
                }
            }
        }

        private decimal? _value3;
        public decimal? value3
        {
            get { return _value3; }
            set
            {
                if (_value3.ToString() != value.ToString())
                {
                    _value3 = value;
                    RaisePropertyChanged("value3", ModelEntityUpdated);
                }
            }
        }

        private decimal? _value4;
        public decimal? value4
        {
            get { return _value4; }
            set
            {
                if (_value4.ToString() != value.ToString())
                {
                    _value4 = value;
                    RaisePropertyChanged("value4", ModelEntityUpdated);
                }
            }
        }

        private decimal? _value5;
        public decimal? value5
        {
            get { return _value5; }
            set
            {
                if (_value5.ToString() != value.ToString())
                {
                    _value5 = value;
                    RaisePropertyChanged("value5", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value6;
        public Nullable<decimal> value6
        {
            get { return _value6; }
            set
            {
                if (_value6.ToString() != value.ToString())
                {
                    _value6 = value;
                    RaisePropertyChanged("value6", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value7;
        public Nullable<decimal> value7
        {
            get { return _value7; }
            set
            {
                if (_value7.ToString() != value.ToString())
                {
                    _value7 = value;
                    RaisePropertyChanged("value7", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value8;
        public Nullable<decimal> value8
        {
            get { return _value8; }
            set
            {
                if (_value8.ToString() != value.ToString())
                {
                    _value8 = value;
                    RaisePropertyChanged("value8", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value9;
        public Nullable<decimal> value9
        {
            get { return _value9; }
            set
            {
                if (_value9.ToString() != value.ToString())
                {
                    _value9 = value;
                    RaisePropertyChanged("value9", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value10;
        public Nullable<decimal> value10
        {
            get { return _value10; }
            set
            {
                if (_value10.ToString() != value.ToString())
                {
                    _value10 = value;
                    RaisePropertyChanged("value10", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value11;
        public Nullable<decimal> value11
        {
            get { return _value11; }
            set
            {
                if (_value11.ToString() != value.ToString())
                {
                    _value11 = value;
                    RaisePropertyChanged("value11", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value12;
        public Nullable<decimal> value12
        {
            get { return _value12; }
            set
            {
                if (_value12.ToString() != value.ToString())
                {
                    _value12 = value;
                    RaisePropertyChanged("value12", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value13;
        public Nullable<decimal> value13
        {
            get { return _value13; }
            set
            {
                if (_value13.ToString() != value.ToString())
                {
                    _value13 = value;
                    RaisePropertyChanged("value13", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value14;
        public Nullable<decimal> value14
        {
            get { return _value14; }
            set
            {
                if (_value14.ToString() != value.ToString())
                {
                    _value14 = value;
                    RaisePropertyChanged("value14", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value15;
        public Nullable<decimal> value15
        {
            get { return _value15; }
            set
            {
                if (_value15.ToString() != value.ToString())
                {
                    _value15 = value;
                    RaisePropertyChanged("value15", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value16;
        public Nullable<decimal> value16
        {
            get { return _value16; }
            set
            {
                if (_value16.ToString() != value.ToString())
                {
                    _value16 = value;
                    RaisePropertyChanged("value16", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value17;
        public Nullable<decimal> value17
        {
            get { return _value17; }
            set
            {
                if (_value17.ToString() != value.ToString())
                {
                    _value17 = value;
                    RaisePropertyChanged("value17", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value18;
        public Nullable<decimal> value18
        {
            get { return _value18; }
            set
            {
                if (_value18.ToString() != value.ToString())
                {
                    _value18 = value;
                    RaisePropertyChanged("value18", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value19;
        public Nullable<decimal> value19
        {
            get { return _value19; }
            set
            {
                if (_value19.ToString() != value.ToString())
                {
                    _value19 = value;
                    RaisePropertyChanged("value19", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value20;
        public Nullable<decimal> value20
        {
            get { return _value20; }
            set
            {
                if (_value20.ToString() != value.ToString())
                {
                    _value20 = value;
                    RaisePropertyChanged("value20", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value21;
        public Nullable<decimal> value21
        {
            get { return _value21; }
            set
            {
                if (_value21.ToString() != value.ToString())
                {
                    _value21 = value;
                    RaisePropertyChanged("value21", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value22;
        public Nullable<decimal> value22
        {
            get { return _value22; }
            set
            {
                if (_value22.ToString() != value.ToString())
                {
                    _value22 = value;
                    RaisePropertyChanged("value22", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value23;
        public Nullable<decimal> value23
        {
            get { return _value23; }
            set
            {
                if (_value23.ToString() != value.ToString())
                {
                    _value23 = value;
                    RaisePropertyChanged("value23", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value24;
        public Nullable<decimal> value24
        {
            get { return _value24; }
            set
            {
                if (_value24.ToString() != value.ToString())
                {
                    _value24 = value;
                    RaisePropertyChanged("value24", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value25;
        public Nullable<decimal> value25
        {
            get { return _value25; }
            set
            {
                if (_value25.ToString() != value.ToString())
                {
                    _value25 = value;
                    RaisePropertyChanged("value25", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value26;
        public Nullable<decimal> value26
        {
            get { return _value26; }
            set
            {
                if (_value26.ToString() != value.ToString())
                {
                    _value26 = value;
                    RaisePropertyChanged("value26", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value27;
        public Nullable<decimal> value27
        {
            get { return _value27; }
            set
            {
                if (_value27.ToString() != value.ToString())
                {
                    _value27 = value;
                    RaisePropertyChanged("value27", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value28;
        public Nullable<decimal> value28
        {
            get { return _value28; }
            set
            {
                if (_value28.ToString() != value.ToString())
                {
                    _value28 = value;
                    RaisePropertyChanged("value28", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value29;
        public Nullable<decimal> value29
        {
            get { return _value29; }
            set
            {
                if (_value29.ToString() != value.ToString())
                {
                    _value29 = value;
                    RaisePropertyChanged("value29", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value30;
        public Nullable<decimal> value30
        {
            get { return _value30; }
            set
            {
                if (_value30.ToString() != value.ToString())
                {
                    _value30 = value;
                    RaisePropertyChanged("value30", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value31;
        public Nullable<decimal> value31
        {
            get { return _value31; }
            set
            {
                if (_value31.ToString() != value.ToString())
                {
                    _value31 = value;
                    RaisePropertyChanged("value31", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value32;
        public Nullable<decimal> value32
        {
            get { return _value32; }
            set
            {
                if (_value32.ToString() != value.ToString())
                {
                    _value32 = value;
                    RaisePropertyChanged("value32", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value33;
        public Nullable<decimal> value33
        {
            get { return _value33; }
            set
            {
                if (_value33.ToString() != value.ToString())
                {
                    _value33 = value;
                    RaisePropertyChanged("value33", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value34;
        public Nullable<decimal> value34
        {
            get { return _value34; }
            set
            {
                if (_value34.ToString() != value.ToString())
                {
                    _value34 = value;
                    RaisePropertyChanged("value34", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value35;
        public Nullable<decimal> value35
        {
            get { return _value35; }
            set
            {
                if (_value35.ToString() != value.ToString())
                {
                    _value35 = value;
                    RaisePropertyChanged("value35", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value36;
        public Nullable<decimal> value36
        {
            get { return _value36; }
            set
            {
                if (_value36.ToString() != value.ToString())
                {
                    _value36 = value;
                    RaisePropertyChanged("value36", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value37;
        public Nullable<decimal> value37
        {
            get { return _value37; }
            set
            {
                if (_value37.ToString() != value.ToString())
                {
                    _value37 = value;
                    RaisePropertyChanged("value37", ModelEntityUpdated);
                }
            }
        }


        private Nullable<decimal> _value38;
        public Nullable<decimal> value38
        {
            get { return _value38; }
            set
            {
                if (_value38.ToString() != value.ToString())
                {
                    _value38 = value;
                    RaisePropertyChanged("value38", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value39;
        public Nullable<decimal> value39
        {
            get { return _value39; }
            set
            {
                if (_value39.ToString() != value.ToString())
                {
                    _value39 = value;
                    RaisePropertyChanged("value39", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value40;
        public Nullable<decimal> value40
        {
            get { return _value40; }
            set
            {
                if (_value40.ToString() != value.ToString())
                {
                    _value40 = value;
                    RaisePropertyChanged("value40", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value41;
        public Nullable<decimal> value41
        {
            get { return _value41; }
            set
            {
                if (_value41.ToString() != value.ToString())
                {
                    _value41 = value;
                    RaisePropertyChanged("value41", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value42;
        public Nullable<decimal> value42
        {
            get { return _value42; }
            set
            {
                if (_value42.ToString() != value.ToString())
                {
                    _value42 = value;
                    RaisePropertyChanged("value42", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value43;
        public Nullable<decimal> value43
        {
            get { return _value43; }
            set
            {
                if (_value43.ToString() != value.ToString())
                {
                    _value43 = value;
                    RaisePropertyChanged("value43", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value44;
        public Nullable<decimal> value44
        {
            get { return _value44; }
            set
            {
                if (_value44.ToString() != value.ToString())
                {
                    _value44 = value;
                    RaisePropertyChanged("value44", ModelEntityUpdated);
                }
            }
        }

        private decimal? _value45;
        public decimal? value45
        {
            get { return _value45; }
            set
            {
                if (_value45.ToString() != value.ToString())
                {
                    _value45 = value;
                    RaisePropertyChanged("value45", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value46;
        public Nullable<decimal> value46
        {
            get { return _value46; }
            set
            {
                if (_value46.ToString() != value.ToString())
                {
                    _value46 = value;
                    RaisePropertyChanged("value46", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value47;
        public Nullable<decimal> value47
        {
            get { return _value47; }
            set
            {
                if (_value47.ToString() != value.ToString())
                {
                    _value47 = value;
                    RaisePropertyChanged("value47", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value48;
        public Nullable<decimal> value48
        {
            get { return _value48; }
            set
            {
                if (_value48.ToString() != value.ToString())
                {
                    _value48 = value;
                    RaisePropertyChanged("value48", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value49;
        public Nullable<decimal> value49
        {
            get { return _value49; }
            set
            {
                if (_value49.ToString() != value.ToString())
                {
                    _value49 = value;
                    RaisePropertyChanged("value49", ModelEntityUpdated);
                }

            }
        }

        private Nullable<decimal> _value50;
        public Nullable<decimal> value50
        {
            get { return _value50; }
            set
            {
                if (_value50.ToString() != value.ToString())
                {
                    _value50 = value;
                    RaisePropertyChanged("value50", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value51;
        public Nullable<decimal> value51
        {
            get { return _value51; }
            set
            {
                if (_value51.ToString() != value.ToString())
                {
                    _value51 = value;
                    RaisePropertyChanged("value51", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value52;
        public Nullable<decimal> value52
        {
            get { return _value52; }
            set
            {
                if (_value52.ToString() != value.ToString())
                {
                    _value52 = value;
                    RaisePropertyChanged("value52", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value53;
        public Nullable<decimal> value53
        {
            get { return _value53; }
            set
            {
                if (_value53.ToString() != value.ToString())
                {
                    _value53 = value;
                    RaisePropertyChanged("value53", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value54;
        public Nullable<decimal> value54
        {
            get { return _value54; }
            set
            {
                if (_value54.ToString() != value.ToString())
                {
                    _value54 = value;
                    RaisePropertyChanged("value54", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value55;
        public Nullable<decimal> value55
        {
            get { return _value55; }
            set
            {
                if (_value55.ToString() != value.ToString())
                {
                    _value55 = value;
                    RaisePropertyChanged("value55", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value56;
        public Nullable<decimal> value56
        {
            get { return _value56; }
            set
            {
                if (_value56.ToString() != value.ToString())
                {
                    _value56 = value;
                    RaisePropertyChanged("value56", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value57;
        public Nullable<decimal> value57
        {
            get { return _value57; }
            set
            {
                if (_value57.ToString() != value.ToString())
                {
                    _value57 = value;
                    RaisePropertyChanged("value57", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value58;
        public Nullable<decimal> value58
        {
            get { return _value58; }
            set
            {
                if (_value58.ToString() != value.ToString())
                {
                    _value58 = value;
                    RaisePropertyChanged("value58", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value59;
        public Nullable<decimal> value59
        {
            get { return _value59; }
            set
            {
                if (_value59.ToString() != value.ToString())
                {
                    _value59 = value;
                    RaisePropertyChanged("value59", ModelEntityUpdated);
                    //RaisePropertyChanged("value59");
                }
            }
        }

        private Nullable<decimal> _value60;
        public Nullable<decimal> value60
        {
            get { return _value60; }
            set
            {
                if (_value60.ToString() != value.ToString())
                {
                    _value60 = value;
                    RaisePropertyChanged("value60", ModelEntityUpdated);
                    //RaisePropertyChanged("value60");
                }
            }
        }

        private Nullable<decimal> _u_value1;
        public Nullable<decimal> u_value1
        {
            get { return _u_value1; }
            set
            {
                _u_value1 = value;
                RaisePropertyChanged("u_value1");
            }
        }

        private Nullable<decimal> _u_value2;
        public Nullable<decimal> u_value2
        {
            get { return _u_value2; }
            set
            {
                _u_value2 = value;
                RaisePropertyChanged("u_value2");
            }
        }

        private Nullable<decimal> _u_value3;
        public Nullable<decimal> u_value3
        {
            get { return _u_value3; }
            set
            {
                _u_value3 = value;
                RaisePropertyChanged("u_value3");
            }
        }

        private Nullable<decimal> _u_value4;
        public Nullable<decimal> u_value4
        {
            get { return _u_value4; }
            set
            {
                _u_value4 = value;
                RaisePropertyChanged("u_value4");
            }
        }

        private Nullable<decimal> _u_value5;
        public Nullable<decimal> u_value5
        {
            get { return _u_value5; }
            set
            {
                _u_value5 = value;
                RaisePropertyChanged("u_value5");
            }
        }

        private Nullable<decimal> _u_value6;
        public Nullable<decimal> u_value6
        {
            get { return _u_value6; }
            set
            {
                _u_value6 = value;
                RaisePropertyChanged("u_value6");
            }
        }

        private Nullable<decimal> _u_value7;
        public Nullable<decimal> u_value7
        {
            get { return _u_value7; }
            set
            {
                _u_value7 = value;
                RaisePropertyChanged("u_value7");
            }
        }

        private Nullable<decimal> _u_value8;
        public Nullable<decimal> u_value8
        {
            get { return _u_value8; }
            set
            {
                _u_value8 = value;
                RaisePropertyChanged("u_value8");
            }
        }

        private Nullable<decimal> _u_value9;
        public Nullable<decimal> u_value9
        {
            get { return _u_value9; }
            set
            {
                _u_value9 = value;
                RaisePropertyChanged("u_value9");
            }
        }
        private Nullable<decimal> _u_value10;
        public Nullable<decimal> u_value10
        {
            get { return _u_value10; }
            set
            {
                _u_value10 = value;
                RaisePropertyChanged("u_value10");
            }
        }

        private Nullable<decimal> _u_value11;
        public Nullable<decimal> u_value11
        {
            get { return _u_value11; }
            set
            {
                _u_value11 = value;
                RaisePropertyChanged("u_value11");
            }
        }

        private Nullable<decimal> _u_value12;
        public Nullable<decimal> u_value12
        {
            get { return _u_value12; }
            set
            {
                _u_value12 = value;
                RaisePropertyChanged("u_value12");
            }
        }

        private Nullable<decimal> _u_value13;
        public Nullable<decimal> u_value13
        {
            get { return _u_value13; }
            set
            {
                _u_value13 = value;
                RaisePropertyChanged("u_value13");
            }
        }

        private Nullable<decimal> _u_value14;
        public Nullable<decimal> u_value14
        {
            get { return _u_value14; }
            set
            {
                _u_value14 = value;
                RaisePropertyChanged("u_value14");
            }
        }

        private Nullable<decimal> _u_value15;
        public Nullable<decimal> u_value15
        {
            get { return _u_value15; }
            set
            {
                _u_value15 = value;
                RaisePropertyChanged("u_value15");
            }
        }

        private Nullable<decimal> _u_value16;
        public Nullable<decimal> u_value16
        {
            get { return _u_value16; }
            set
            {
                _u_value16 = value;
                RaisePropertyChanged("u_value16");
            }
        }

        private Nullable<decimal> _u_value17;
        public Nullable<decimal> u_value17
        {
            get { return _u_value17; }
            set
            {
                _u_value17 = value;
                RaisePropertyChanged("u_value17");
            }
        }

        private Nullable<decimal> _u_value18;
        public Nullable<decimal> u_value18
        {
            get { return _u_value18; }
            set
            {
                _u_value18 = value;
                RaisePropertyChanged("u_value18");
            }
        }

        private Nullable<decimal> _u_value19;
        public Nullable<decimal> u_value19
        {
            get { return _u_value19; }
            set
            {
                _u_value19 = value;
                RaisePropertyChanged("u_value19");
            }
        }

        private Nullable<decimal> _u_value20;
        public Nullable<decimal> u_value20
        {
            get { return _u_value20; }
            set
            {
                _u_value20 = value;
                RaisePropertyChanged("u_value20");
            }
        }

        private Nullable<decimal> _u_value21;
        public Nullable<decimal> u_value21
        {
            get { return _u_value21; }
            set
            {
                _u_value21 = value;
                RaisePropertyChanged("u_value21");
            }
        }

        private Nullable<decimal> _u_value22;
        public Nullable<decimal> u_value22
        {
            get { return _u_value22; }
            set
            {
                _u_value22 = value;
                RaisePropertyChanged("u_value22");
            }
        }

        private Nullable<decimal> _u_value23;
        public Nullable<decimal> u_value23
        {
            get { return _u_value23; }
            set
            {
                _u_value23 = value;
                RaisePropertyChanged("u_value23");
            }
        }

        private Nullable<decimal> _u_value24;
        public Nullable<decimal> u_value24
        {
            get { return _u_value24; }
            set
            {
                _u_value24 = value;
                RaisePropertyChanged("u_value24");
            }
        }

        private Nullable<decimal> _u_value25;
        public Nullable<decimal> u_value25
        {
            get { return _u_value25; }
            set
            {
                _u_value25 = value;
                RaisePropertyChanged("u_value25");
            }
        }

        private Nullable<decimal> _u_value26;
        public Nullable<decimal> u_value26
        {
            get { return _u_value26; }
            set
            {
                _u_value26 = value;
                RaisePropertyChanged("u_value26");
            }
        }

        private Nullable<decimal> _u_value27;
        public Nullable<decimal> u_value27
        {
            get { return _u_value27; }
            set
            {
                _u_value27 = value;
                RaisePropertyChanged("u_value27");
            }
        }

        private Nullable<decimal> _u_value28;
        public Nullable<decimal> u_value28
        {
            get { return _u_value28; }
            set
            {
                _u_value28 = value;
                RaisePropertyChanged("u_value28");
            }
        }

        private Nullable<decimal> _u_value29;
        public Nullable<decimal> u_value29
        {
            get { return _u_value29; }
            set
            {
                _u_value29 = value;
                RaisePropertyChanged("u_value29");
            }
        }

        private Nullable<decimal> _u_value30;
        public Nullable<decimal> u_value30
        {
            get { return _u_value30; }
            set
            {
                _u_value30 = value;
                RaisePropertyChanged("u_value30");
            }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private string _master_inst;
        public string master_inst
        {
            get { return _master_inst; }
            set { _master_inst = value; RaisePropertyChanged("master_inst"); }
        }

        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
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

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }

        private decimal? _value61;
        public decimal? value61
        {
            get { return _value61; }
            set
            {
                _value61 = value;
                RaisePropertyChanged("value61");
            }
        }

        private decimal? _value62;
        public decimal? value62
        {
            get { return _value62; }
            set
            {
                _value62 = value;
                RaisePropertyChanged("value62");
            }
        }
        private decimal? _value63;
        public decimal? value63
        {
            get { return _value63; }
            set
            {
                _value63 = value;
                RaisePropertyChanged("value63");
            }
        }

        private decimal? _value64;
        public decimal? value64
        {
            get { return _value64; }
            set
            {
                _value64 = value;
                RaisePropertyChanged("value64");
            }
        }
        private decimal? _value65;
        public decimal? value65
        {
            get { return _value65; }
            set
            {
                _value65 = value;
                RaisePropertyChanged("value65");
            }
        }

        private decimal? _value66;
        public decimal? value66
        {
            get { return _value66; }
            set
            {
                _value66 = value;
                RaisePropertyChanged("value66");
            }
        }
        private decimal? _value67;
        public decimal? value67
        {
            get { return _value67; }
            set
            {
                _value67 = value;
                RaisePropertyChanged("value67");
            }
        }

        private decimal? _value68;
        public decimal? value68
        {
            get { return _value68; }
            set
            {
                _value68 = value;
                RaisePropertyChanged("value68");
            }
        }
        private decimal? _value69;
        public decimal? value69
        {
            get { return _value69; }
            set
            {
                _value69 = value;
                RaisePropertyChanged("value69");
            }
        }

        private decimal? _value70;
        public decimal? value70
        {
            get { return _value70; }
            set
            {
                _value70 = value;
                RaisePropertyChanged("value70");
            }
        }
        private decimal? _dev_value;
        public decimal? dev_value
        {
            get { return _dev_value; }
            set
            {
                _dev_value = value;
                RaisePropertyChanged("dev_value");
            }
        }

        private decimal? _dev_mean_value;
        public decimal? dev_mean_value
        {
            get { return _dev_mean_value; }
            set
            {
                _dev_mean_value = value;
                RaisePropertyChanged("dev_mean_value");
            }
        }

        private decimal? _dev_per_value;
        public decimal? dev_per_value
        {
            get { return _dev_per_value; }
            set
            {
                _dev_per_value = value;
                RaisePropertyChanged("dev_per_value");
            }
        }

        private int? _degree_of_frdm;
        public int? degree_of_frdm
        {
            get { return _degree_of_frdm; }
            set
            {
                _degree_of_frdm = value;
                RaisePropertyChanged("degree_of_frdm");
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

        private string _column_value1;
        public string column_value1
        {
            get { return _column_value1; }
            set
            {
                if (value != _column_value1)
                {
                    _column_value1 = value;
                    RaisePropertyChanged("column_value1");
                }
            }
        }

        private string _column_value2;
        public string column_value2
        {
            get { return _column_value2; }
            set
            {
                if (value != _column_value2)
                {
                    _column_value2 = value;
                    RaisePropertyChanged("column_value2");
                }
            }
        }

        private string _column_value3;
        public string column_value3
        {
            get { return _column_value3; }
            set
            {
                if (value != _column_value3)
                {
                    _column_value3 = value;
                    RaisePropertyChanged("column_value3");
                }
            }
        }

        private string _column_value4;
        public string column_value4
        {
            get { return _column_value4; }
            set
            {
                _column_value4 = value;
                RaisePropertyChanged("column_value4");
            }
        }

        private string _column_value5;
        public string column_value5
        {
            get { return _column_value5; }
            set
            {
                _column_value5 = value;
                RaisePropertyChanged("column_value5");
            }
        }

        private string _column_value6;
        public string column_value6
        {
            get { return _column_value6; }
            set
            {
                _column_value6 = value;
                RaisePropertyChanged("column_value6");
            }
        }

        private string _column_value7;
        public string column_value7
        {
            get { return _column_value7; }
            set
            {
                _column_value7 = value;
                RaisePropertyChanged("column_value7");
            }
        }

        private string _column_value8;
        public string column_value8
        {
            get { return _column_value8; }
            set
            {
                _column_value8 = value;
                RaisePropertyChanged("column_value8");
            }
        }

        private string _column_value9;
        public string column_value9
        {
            get { return _column_value9; }
            set
            {
                _column_value9 = value;
                RaisePropertyChanged("column_value9");
            }
        }

        private string _column_value10;
        public string column_value10
        {
            get { return _column_value10; }
            set
            {
                _column_value10 = value;
                RaisePropertyChanged("column_value10");
            }
        }
        public decimal? _m_uncertainty;
        public decimal? m_uncertainty
        {
            get { return _m_uncertainty; }
            set
            {
                _m_uncertainty = value;
                RaisePropertyChanged("m_uncertainty");
            }
        }
        public decimal? _m_accuracy;
        public decimal? m_accuracy
        {
            get { return _m_accuracy; }
            set
            {
                _m_accuracy = value;
                RaisePropertyChanged("m_accuracy");
            }
        }
        public decimal? _m_resolution;
        public decimal? m_resolution
        {
            get { return _m_resolution; }
            set
            {
                _m_resolution = value;
                RaisePropertyChanged("m_resolution");
            }
        }
        public decimal? _coverage_factor;
        public decimal? coverage_factor
        {
            get { return _coverage_factor; }
            set
            {
                _coverage_factor = value;
                RaisePropertyChanged("coverage_factor");
            }
        }
        public string _conf_level;
        public string conf_level
        {
            get { return _conf_level; }
            set
            {
                _conf_level = value;
                RaisePropertyChanged("conf_level");
            }
        }
        private bool _select31;
        public bool select31
        {
            get { return _select31; }
            set
            {
                if (_select31 != value)
                {
                    _select31 = value;
                    RaisePropertyChanged("select31", ModelEntityUpdated);
                }
            }
        }

        private bool _select32;
        public bool select32
        {
            get { return _select32; }
            set
            {
                if (_select32 != value)
                {
                    _select32 = value;
                    RaisePropertyChanged("select32", ModelEntityUpdated);
                }
            }
        }

        private bool _select33;
        public bool select33
        {
            get { return _select33; }
            set
            {
                if (_select33 != value)
                {
                    _select33 = value;
                    RaisePropertyChanged("select33", ModelEntityUpdated);
                }
            }
        }

        private bool _select34;
        public bool select34
        {
            get { return _select34; }
            set
            {
                if (_select34 != value)
                {
                    _select34 = value;
                    RaisePropertyChanged("select34", ModelEntityUpdated);
                }
            }
        }
        private bool _select35;
        public bool select35
        {
            get { return _select35; }
            set
            {
                if (_select35 != value)
                {
                    _select35 = value;
                    RaisePropertyChanged("select35", ModelEntityUpdated);
                }
            }
        }
        private bool _select36;
        public bool select36
        {
            get { return _select36; }
            set
            {
                if (_select36 != value)
                {
                    _select36 = value;
                    RaisePropertyChanged("select36", ModelEntityUpdated);
                }
            }
        }
        private bool _select37;
        public bool select37
        {
            get { return _select37; }
            set
            {
                if (_select37 != value)
                {
                    _select37 = value;
                    RaisePropertyChanged("select37", ModelEntityUpdated);
                }
            }
        }
        private bool _select38;
        public bool select38
        {
            get { return _select38; }
            set
            {
                if (_select38 != value)
                {
                    _select38 = value;
                    RaisePropertyChanged("select38", ModelEntityUpdated);
                }
            }
        }
        private bool _select39;
        public bool select39
        {
            get { return _select39; }
            set
            {
                if (_select39 != value)
                {
                    _select39 = value;
                    RaisePropertyChanged("select39", ModelEntityUpdated);
                }
            }
        }
        private bool _select40;
        public bool select40
        {
            get { return _select40; }
            set
            {
                if (_select40 != value)
                {
                    _select40 = value;
                    RaisePropertyChanged("select40", ModelEntityUpdated);
                }
            }
        }
        private bool _select41;
        public bool select41
        {
            get { return _select41; }
            set
            {
                if (_select41 != value)
                {
                    _select41 = value;
                    RaisePropertyChanged("select41", ModelEntityUpdated);
                }
            }
        }
        private bool _select42;
        public bool select42
        {
            get { return _select42; }
            set
            {
                if (_select42 != value)
                {
                    _select42 = value;
                    RaisePropertyChanged("select42", ModelEntityUpdated);
                }
            }
        }
        private bool _select43;
        public bool select43
        {
            get { return _select43; }
            set
            {
                if (_select43 != value)
                {
                    _select43 = value;
                    RaisePropertyChanged("select43", ModelEntityUpdated);
                }
            }
        }
        private bool _select44;
        public bool select44
        {
            get { return _select44; }
            set
            {
                if (_select44 != value)
                {
                    _select44 = value;
                    RaisePropertyChanged("select44", ModelEntityUpdated);
                }
            }
        }
        private bool _select45;
        public bool select45
        {
            get { return _select45; }
            set
            {
                if (_select45 != value)
                {
                    _select45 = value;
                    RaisePropertyChanged("select45", ModelEntityUpdated);
                }
            }
        }
        private bool _select46;
        public bool select46
        {
            get { return _select46; }
            set
            {
                if (_select46 != value)
                {
                    _select46 = value;
                    RaisePropertyChanged("select46", ModelEntityUpdated);
                }
            }
        }
        private bool _select47;
        public bool select47
        {
            get { return _select47; }
            set
            {
                if (_select47 != value)
                {
                    _select47 = value;
                    RaisePropertyChanged("select47", ModelEntityUpdated);
                }
            }
        }
        private bool _select48;
        public bool select48
        {
            get { return _select48; }
            set
            {
                if (_select48 != value)
                {
                    _select48 = value;
                    RaisePropertyChanged("select48", ModelEntityUpdated);
                }
            }
        }
        private bool _select49;
        public bool select49
        {
            get { return _select49; }
            set
            {
                if (_select49 != value)
                {
                    _select49 = value;
                    RaisePropertyChanged("select49", ModelEntityUpdated);
                }
            }
        }
        private bool _select50;
        public bool select50
        {
            get { return _select50; }
            set
            {
                if (_select50 != value)
                {
                    _select50 = value;
                    RaisePropertyChanged("select50", ModelEntityUpdated);
                }
            }
        }
        private decimal? _sensitivity_coeff;
        public decimal? sensitivity_coeff
        {
            get { return _sensitivity_coeff; }
            set
            {
                if (_sensitivity_coeff != value)
                {
                    _sensitivity_coeff = value;
                    RaisePropertyChanged("sensitivity_coeff");
                }
            }
        }
        private decimal? _combine_uncertainty;
        public decimal? combine_uncertainty
        {
            get { return _combine_uncertainty; }
            set
            {
                if (_combine_uncertainty != value)
                {
                    _combine_uncertainty = value;
                    RaisePropertyChanged("combine_uncertainty");
                }
            }
        }
        private decimal? _eff_degree_of_frdm;
        public decimal? eff_degree_of_frdm
        {
            get { return _eff_degree_of_frdm; }
            set
            {
                if (_eff_degree_of_frdm != value)
                {
                    _eff_degree_of_frdm = value;
                    RaisePropertyChanged("eff_degree_of_frdm");
                }
            }
        }
        private decimal? _expanded_uncertainty;
        public decimal? expanded_uncertainty
        {
            get { return _expanded_uncertainty; }
            set
            {
                if (_expanded_uncertainty != value)
                {
                    _expanded_uncertainty = value;
                    RaisePropertyChanged("expanded_uncertainty");
                }
            }
        }
        private decimal? _expanded_uncertainty_per;
        public decimal? expanded_uncertainty_per
        {
            get { return _expanded_uncertainty_per; }
            set
            {
                if (_expanded_uncertainty_per != value)
                {
                    _expanded_uncertainty_per = value;
                    RaisePropertyChanged("expanded_uncertainty_per");
                }
            }
        }
        
        //Scalar
        private string _hdr_name;
        public string hdr_name
        {
            get { return _hdr_name; }
            set
            {
                _hdr_name = value;
                RaisePropertyChanged("hdr_name");
            }
        }

        private string _test_type_name;
        public string test_type_name
        {
            get { return _test_type_name; }
            set
            {
                _test_type_name = value;
                RaisePropertyChanged("test_type_name");
            }
        }

        private int? _deletion_id;
        public int? deletion_id
        {
            get { return _deletion_id; }
            set { _deletion_id = value; RaisePropertyChanged("deletion_id"); }
        }

        private string _master_inst_name;
        public string master_inst_name
        {
            get { return _master_inst_name; }
            set { _master_inst_name = value; RaisePropertyChanged("master_inst_name"); }
        }
        private byte[] _image1;
        public byte[] image1
        {
            get { return _image1; }
            set { _image1 = value; RaisePropertyChanged("image1"); }
        }
        private byte[] _image2;
        public byte[] image2
        {
            get { return _image2; }
            set { _image2 = value; RaisePropertyChanged("image2"); }
        }
        private byte[] _image3;
        public byte[] image3
        {
            get { return _image3; }
            set { _image3 = value; RaisePropertyChanged("image3"); }
        }
    }

    public class QMS_T001_C : ObjectBase
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

        private string _test_type_code;
        public string test_type_code
        {
            get { return _test_type_code; }
            set
            {
                _test_type_code = value;
                RaisePropertyChanged("test_type_code");
            }
        }

        private Nullable<decimal> _value1;
        public Nullable<decimal> value1
        {
            get { return _value1; }
            set
            {
                _value1 = value;
                RaisePropertyChanged("value1", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value2;
        public Nullable<decimal> value2
        {
            get { return _value2; }
            set
            {
                _value2 = value;
                RaisePropertyChanged("value2", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value3;
        public Nullable<decimal> value3
        {
            get { return _value3; }
            set
            {
                _value3 = value;
                RaisePropertyChanged("value3", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value4;
        public Nullable<decimal> value4
        {
            get { return _value4; }
            set
            {
                _value4 = value;
                RaisePropertyChanged("value4", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value5;
        public Nullable<decimal> value5
        {
            get { return _value5; }
            set
            {
                _value5 = value;
                RaisePropertyChanged("value5", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value6;
        public Nullable<decimal> value6
        {
            get { return _value6; }
            set
            {
                _value6 = value;
                RaisePropertyChanged("value6", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value7;
        public Nullable<decimal> value7
        {
            get { return _value7; }
            set
            {
                _value7 = value;
                RaisePropertyChanged("value7", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value8;
        public Nullable<decimal> value8
        {
            get { return _value8; }
            set
            {
                _value8 = value;
                RaisePropertyChanged("value8", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value9;
        public Nullable<decimal> value9
        {
            get { return _value9; }
            set
            {
                _value9 = value;
                RaisePropertyChanged("value9", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value10;
        public Nullable<decimal> value10
        {
            get { return _value10; }
            set
            {
                _value10 = value;
                RaisePropertyChanged("value10", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value11;
        public Nullable<decimal> value11
        {
            get { return _value11; }
            set
            {
                _value11 = value;
                RaisePropertyChanged("value11", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value12;
        public Nullable<decimal> value12
        {
            get { return _value12; }
            set
            {
                _value12 = value;
                RaisePropertyChanged("value12", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value13;
        public Nullable<decimal> value13
        {
            get { return _value13; }
            set
            {
                _value13 = value;
                RaisePropertyChanged("value13", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value14;
        public Nullable<decimal> value14
        {
            get { return _value14; }
            set
            {
                _value14 = value;
                RaisePropertyChanged("value14", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value15;
        public Nullable<decimal> value15
        {
            get { return _value15; }
            set
            {
                _value15 = value;
                RaisePropertyChanged("value15", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value16;
        public Nullable<decimal> value16
        {
            get { return _value16; }
            set
            {
                _value16 = value;
                RaisePropertyChanged("value16", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value17;
        public Nullable<decimal> value17
        {
            get { return _value17; }
            set
            {
                _value17 = value;
                RaisePropertyChanged("value17", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value18;
        public Nullable<decimal> value18
        {
            get { return _value18; }
            set
            {
                _value18 = value;
                RaisePropertyChanged("value18", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value19;
        public Nullable<decimal> value19
        {
            get { return _value19; }
            set
            {
                _value19 = value;
                RaisePropertyChanged("value19", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value20;
        public Nullable<decimal> value20
        {
            get { return _value20; }
            set
            {
                _value20 = value;
                RaisePropertyChanged("value20", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _u_value1;
        public Nullable<decimal> u_value1
        {
            get { return _u_value1; }
            set
            {
                _u_value1 = value;
                RaisePropertyChanged("u_value1");
            }
        }

        private Nullable<decimal> _u_value2;
        public Nullable<decimal> u_value2
        {
            get { return _u_value2; }
            set
            {
                _u_value2 = value;
                RaisePropertyChanged("u_value2");
            }
        }

        private Nullable<decimal> _u_value3;
        public Nullable<decimal> u_value3
        {
            get { return _u_value3; }
            set
            {
                _u_value3 = value;
                RaisePropertyChanged("u_value3");
            }
        }

        private Nullable<decimal> _u_value4;
        public Nullable<decimal> u_value4
        {
            get { return _u_value4; }
            set
            {
                _u_value4 = value;
                RaisePropertyChanged("u_value4");
            }
        }

        private Nullable<decimal> _u_value5;
        public Nullable<decimal> u_value5
        {
            get { return _u_value5; }
            set
            {
                _u_value5 = value;
                RaisePropertyChanged("u_value5");
            }
        }

        private Nullable<decimal> _u_value6;
        public Nullable<decimal> u_value6
        {
            get { return _u_value6; }
            set
            {
                _u_value6 = value;
                RaisePropertyChanged("u_value6");
            }
        }

        private Nullable<decimal> _u_value7;
        public Nullable<decimal> u_value7
        {
            get { return _u_value7; }
            set
            {
                _u_value7 = value;
                RaisePropertyChanged("u_value7");
            }
        }

        private Nullable<decimal> _u_value8;
        public Nullable<decimal> u_value8
        {
            get { return _u_value8; }
            set
            {
                _u_value8 = value;
                RaisePropertyChanged("u_value8");
            }
        }

        private Nullable<decimal> _u_value9;
        public Nullable<decimal> u_value9
        {
            get { return _u_value9; }
            set
            {
                _u_value9 = value;
                RaisePropertyChanged("u_value9");
            }
        }

        private Nullable<decimal> _u_value10;
        public Nullable<decimal> u_value10
        {
            get { return _u_value10; }
            set
            {
                _u_value10 = value;
                RaisePropertyChanged("u_value10");
            }
        }

        private Nullable<decimal> _l_value;
        public Nullable<decimal> l_value
        {
            get { return _l_value; }
            set
            {
                _l_value = value;
                RaisePropertyChanged("l_value", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _h_value;
        public Nullable<decimal> h_value
        {
            get { return _h_value; }
            set
            {
                _h_value = value;
                RaisePropertyChanged("h_value", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _std_value;
        public Nullable<decimal> std_value
        {
            get { return _std_value; }
            set
            {
                _std_value = value;
                RaisePropertyChanged("std_value", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _value61;
        public Nullable<decimal> value61
        {
            get { return _value61; }
            set
            {
                _value61 = value;
                RaisePropertyChanged("value61");
            }
        }

        private Nullable<decimal> _value62;
        public Nullable<decimal> value62
        {
            get { return _value62; }
            set
            {
                _value62 = value;
                RaisePropertyChanged("value62");
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


        private string _error_code;
        public string error_code
        {
            get { return _error_code; }
            set
            {
                _error_code = value;
                RaisePropertyChanged("error_code");
            }
        }


        private string _u_remark1;
        public string u_remark1
        {
            get { return _u_remark1; }
            set
            {
                _u_remark1 = value;
                RaisePropertyChanged("u_remark1");
            }
        }


        private string _u_remark2;
        public string u_remark2
        {
            get { return _u_remark2; }
            set
            {
                _u_remark2 = value;
                RaisePropertyChanged("u_remark2");
            }
        }


        private string _u_remark3;
        public string u_remark3
        {
            get { return _u_remark3; }
            set
            {
                _u_remark3 = value;
                RaisePropertyChanged("u_remark3");
            }
        }


        private string _master_inst;
        public string master_inst
        {
            get { return _master_inst; }
            set
            {
                _master_inst = value;
                RaisePropertyChanged("master_inst");
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


        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                _lang_key = value;
                RaisePropertyChanged("lang_key");
            }
        }

        
    }

    public class QMS_T001_D : ObjectBase
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

        private string _para_code;
        public string para_code
        {
            get { return _para_code; }
            set
            {
                _para_code = value;
                RaisePropertyChanged("para_code");
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

        //scalar

        private string _para_name;
        public string para_name
        {
            get { return _para_name; }
            set
            {
                _para_name = value;
                RaisePropertyChanged("para_name");
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

        private string _unit_value;
        public string unit_value
        {
            get { return _unit_value; }
            set
            {
                _unit_value = value;
                RaisePropertyChanged("unit_value");
            }
        }

        private string _para_value;
        public string para_value
        {
            get { return _para_value; }
            set
            {
                _para_value = value;
                RaisePropertyChanged("para_value");
            }
        }
        //Scalar
        private bool? _allow_null;
        public bool? allow_null
        {
            get { return _allow_null; }
            set { _allow_null = value; RaisePropertyChanged("allow_null"); }
        }
    }

    public class QMS_T001_E : ObjectBase
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

        private string _tl_code;
        public string tl_code
        {
            get { return _tl_code; }
            set
            {
                _tl_code = value;
                RaisePropertyChanged("tl_code");
            }
        }
        private bool? _task_done;
        public bool? task_done
        {
            get { return _task_done; }
            set
            {
                _task_done = value;
                RaisePropertyChanged("task_done");
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
        // Scalar
        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set
            {
                _short_text = value;
                RaisePropertyChanged("short_text");
            }
        }
    }

    public class QMS_T001_F : ObjectBase
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
        private string _test_type_code;
        public string test_type_code
        {
            get { return _test_type_code; }
            set { _test_type_code = value; RaisePropertyChanged("test_type_code"); }
        }
        private string _env_code;
        public string env_code
        {
            get { return _env_code; }
            set { _env_code = value; RaisePropertyChanged("env_code"); }
        }
        private string _env_name;
        public string env_name
        {
            get { return _env_name; }
            set { _env_name = value; RaisePropertyChanged("env_name"); }
        }
        private decimal? _std_value;
        public decimal? std_value
        {
            get { return _std_value; }
            set { _std_value = value; RaisePropertyChanged("std_value"); }
        }
        private decimal? _upper_value;
        public decimal? upper_value
        {
            get { return _upper_value; }
            set { _upper_value = value; RaisePropertyChanged("upper_value"); }
        }
        private decimal? _lower_value;
        public decimal? lower_value
        {
            get { return _lower_value; }
            set { _lower_value = value; RaisePropertyChanged("lower_value"); }
        }
        private decimal? _r_std_value;
        public decimal? r_std_value
        {
            get { return _r_std_value; }
            set { _r_std_value = value; RaisePropertyChanged("r_std_value", ModelEntityUpdated); }
        }
        private string _std_value_unit;
        public string std_value_unit
        {
            get { return _std_value_unit; }
            set { _std_value_unit = value; RaisePropertyChanged("std_value_unit"); }
        }
        private decimal? _resolution;
        public decimal? resolution
        {
            get { return _resolution; }
            set { _resolution = value; RaisePropertyChanged("resolution"); }
        }
        private string _resolution_unit;
        public string resolution_unit
        {
            get { return _resolution_unit; }
            set { _resolution_unit = value; RaisePropertyChanged("lower_value"); }
        }
        private decimal? _variation;
        public decimal? variation
        {
            get { return _variation; }
            set
            {
                _variation = value;
                RaisePropertyChanged("variation", ModelEntityUpdated);
            }
        }

        private decimal? _variation_per;
        public decimal? variation_per
        {
            get { return _variation_per; }
            set
            {
                _variation_per = value;
                RaisePropertyChanged("variation_per");
            }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
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
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }
        
        //Scalar
        private int _deletion_id;
        public int deletion_id
        {
            get { return _deletion_id; }
            set { _deletion_id = value; RaisePropertyChanged("deletion_id"); }
        }
    }
    public class MultipleContext_QMS_T001 : ObjectBase
    {
        public List<SYS_M002> DocTypeInfo { get; set; }
        public List<QMS_T001Flip> DocumentDataFlipGrid { get; set; } //DataGridCollection        
        public List<ADM_M038_B_P> UnitCode { get; set; }  //UOM List
        public List<QMS_M003_P> EqCode { get; set; } // Equipement Code List
        public List<ADM_M024_P> Employees { get; set; } //Responsible Person
        //public List<Inst_Pur_Details_P> PurOrder { get; set; } //PO Number
        public List<QMS_T002> RefDocCollection { get; set; }    // Ref Doc Collection  
        public List<QMS_M009_A> TestCode { get; set; }    // Test Code Collection  
        public List<QMS_M024Flip> TaskList { get; set; }    // TaskList Collection  
        private List<QMS_M009_B> _TestType;
        public List<QMS_M009_B> TestType
        {
            get { return _TestType; }
            set
            {
                _TestType = value;
                RaisePropertyChanged("TestType");
            }
        }    // TestType Collection  
        public List<QMS_M009_C> BenchHeader { get; set; }    // BenchHeader Collection  
        public List<QMS_M009_D> HeaderValue { get; set; }    // HeaderValue Collection  
        public List<QMS_M009_E> MasterHeader { get; set; }    // MasterHeader Collection  
        public List<QMS_M009_E> UnitHeader { get; set; }    // UnitHeader Collection  
        public List<QMS_M009_F> Parameter { get; set; }
        public List<QMS_M009_J> MasterValueEntity { get; set; }  //Default Master Readings
        public List<QMS_M009_K> EnvConditionEntity { get; set; }  //Default Environment Conditions
        public List<QMS_M010_P> Tracibility { get; set; }
        public List<QMS_M008_P> Rig { get; set; }
        public List<QMS_T001> MasterEntity { get; set; }
        public ObservableCollection<QMS_T001_B> TestTypeEntity { get; set; }
        public ObservableCollection<QMS_M003_B> ParameterEntity { get; set; }
        public ObservableCollection<QMS_T001_E> TaskListEntity { get; set; }
        public ObservableCollection<QMS_T001_F> EnvCondEntity { get; set; }
        public List<RptTestType> RptDatasheet { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public ObservableCollection<QMS_T001_A> MasterEquipment { get; set; }
        public List<QMS_M011> FormulaDetails { get; set; }
        public List<QMS_M017> StdEnvCond { get; set; }
        public List<QMS_M016> CovFactorChart { get; set; }
        public List<QMS_T004> UncertaintyScope { get; set; }
    }

    // Report Entity for QMS_T001_B(Datasheet Table)
    public class RptTestType
    {
        public int tm_id { get; set; }
        public string doc_no { get; set; }
        public string test_type_code { get; set; }
        public int? seq_no { get; set; }
        public int? value_id1 { get; set; }
        public int? value_id2 { get; set; }
        public int? value_id3 { get; set; }
        public int? value_id4 { get; set; }
        public int? value_id5 { get; set; }
        public int? value_id6 { get; set; }
        public int? value_id7 { get; set; }
        public int? value_id8 { get; set; }
        public int? value_id9 { get; set; }
        public int? value_id10 { get; set; }
        public decimal? value1 { get; set; }
        public decimal? value2 { get; set; }
        public decimal? value3 { get; set; }
        public decimal? value4 { get; set; }
        public decimal? value5 { get; set; }
        public decimal? value6 { get; set; }
        public decimal? value7 { get; set; }
        public decimal? value8 { get; set; }
        public decimal? value9 { get; set; }
        public decimal? value10 { get; set; }
        public decimal? value11 { get; set; }
        public decimal? value12 { get; set; }
        public decimal? value13 { get; set; }
        public decimal? value14 { get; set; }
        public decimal? value15 { get; set; }
        public decimal? value16 { get; set; }
        public decimal? value17 { get; set; }
        public decimal? value18 { get; set; }
        public decimal? value19 { get; set; }
        public decimal? value20 { get; set; }
        public decimal? value21 { get; set; }
        public decimal? value22 { get; set; }
        public decimal? value23 { get; set; }
        public decimal? value24 { get; set; }
        public decimal? value25 { get; set; }
        public decimal? value26 { get; set; }
        public decimal? value27 { get; set; }
        public decimal? value28 { get; set; }
        public decimal? value29 { get; set; }
        public decimal? value30 { get; set; }
        public decimal? value31 { get; set; }
        public decimal? value32 { get; set; }
        public decimal? value33 { get; set; }
        public decimal? value34 { get; set; }
        public decimal? value35 { get; set; }
        public decimal? value36 { get; set; }
        public decimal? value37 { get; set; }
        public decimal? value38 { get; set; }
        public decimal? value39 { get; set; }
        public decimal? value40 { get; set; }
        public decimal? value41 { get; set; }
        public decimal? value42 { get; set; }
        public decimal? value43 { get; set; }
        public decimal? value44 { get; set; }
        public decimal? value45 { get; set; }
        public decimal? value46 { get; set; }
        public decimal? value47 { get; set; }
        public decimal? value48 { get; set; }
        public decimal? value49 { get; set; }
        public decimal? value50 { get; set; }
        public decimal? value51 { get; set; }
        public decimal? value52 { get; set; }
        public decimal? value53 { get; set; }
        public decimal? value54 { get; set; }
        public decimal? value55 { get; set; }
        public decimal? value56 { get; set; }
        public decimal? value57 { get; set; }
        public decimal? value58 { get; set; }
        public decimal? value59 { get; set; }
        public decimal? value60 { get; set; }
        public decimal? value61 { get; set; }
        public decimal? value62 { get; set; }
        public decimal? u_value1 { get; set; }
        public decimal? u_value2 { get; set; }
        public decimal? u_value3 { get; set; }
        public decimal? u_value4 { get; set; }
        public decimal? u_value5 { get; set; }
        public decimal? u_value6 { get; set; }
        public decimal? u_value7 { get; set; }
        public decimal? u_value8 { get; set; }
        public decimal? u_value9 { get; set; }
        public decimal? u_value10 { get; set; }
        public decimal? u_value11 { get; set; }
        public decimal? u_value12 { get; set; }
        public decimal? u_value13 { get; set; }
        public decimal? u_value14 { get; set; }
        public decimal? u_value15 { get; set; }
        public decimal? u_value16 { get; set; }
        public decimal? u_value17 { get; set; }
        public decimal? u_value18 { get; set; }
        public decimal? u_value19 { get; set; }
        public decimal? u_value20 { get; set; }
        public decimal? u_value21 { get; set; }
        public decimal? u_value22 { get; set; }
        public decimal? u_value23 { get; set; }
        public decimal? u_value24 { get; set; }
        public decimal? u_value25 { get; set; }
        public decimal? u_value26 { get; set; }
        public decimal? u_value27 { get; set; }
        public decimal? u_value28 { get; set; }
        public decimal? u_value29 { get; set; }
        public decimal? u_value30 { get; set; }
        public string unit_code { get; set; }
        public string master_inst { get; set; }
        public bool? active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public decimal? value63 { get; set; }
        public decimal? value64 { get; set; }
        public decimal? value65 { get; set; }
        public decimal? value66 { get; set; }
        public decimal? value67 { get; set; }
        public decimal? value68 { get; set; }
        public decimal? value69 { get; set; }
        public decimal? value70 { get; set; }
        public decimal? m_uncertainty { get; set; }
        public decimal? m_accuracy { get; set; }
        public decimal? m_resolution { get; set; }
        public decimal? coverage_factor { get; set; }
        public string conf_level { get; set; }
        public bool select31 { get; set; }
        public bool select32 { get; set; }
        public bool select33 { get; set; }
        public bool select34 { get; set; }
        public bool select35 { get; set; }
        public bool select36 { get; set; }
        public bool select37 { get; set; }
        public bool select38 { get; set; }
        public bool select39 { get; set; }
        public bool select40 { get; set; }
        public bool select41 { get; set; }
        public bool select42 { get; set; }
        public bool select43 { get; set; }
        public bool select44 { get; set; }
        public bool select45 { get; set; }
        public bool select46 { get; set; }
        public bool select47 { get; set; }
        public bool select48 { get; set; }
        public bool select49 { get; set; }
        public bool select50 { get; set; }
        public decimal? sensitivity_coeff { get; set; }
        public decimal? combine_uncertainty { get; set; }
        public decimal? eff_degree_of_frdm { get; set; }
        public decimal? expanded_uncertainty { get; set; }
        public decimal? expanded_uncertainty_per { get; set; }
        //Scalar
        public string test_type_name { get; set; }
        public decimal? dev_value { get; set; }
        public decimal? dev_mean_value { get; set; }
        public decimal? dev_per_value { get; set; }
        public int? degree_of_frdm { get; set; }
        public string remark { get; set; }
        public string column_value1 { get; set; }
        public string column_value2 { get; set; }
        public string column_value3 { get; set; }
        public string column_value4 { get; set; }
        public string column_value5 { get; set; }
        public string column_value6 { get; set; }
        public string column_value7 { get; set; }
        public string column_value8 { get; set; }
        public string column_value9 { get; set; }
        public string column_value10 { get; set; }
        public string formula_code { get; set; }


        // Header names
        public int hdr_id { get; set; }
        public string hdr_name1 { get; set; }
        public string hdr_name2 { get; set; }
        public string hdr_name3 { get; set; }
        public string hdr_name4 { get; set; }
        public string hdr_name5 { get; set; }
        public string hdr_name6 { get; set; }
        public string hdr_name7 { get; set; }
        public string hdr_name8 { get; set; }
        public string hdr_name9 { get; set; }
        public string hdr_name10 { get; set; }
        public string op_hdr1 { get; set; }
        public string op_hdr2 { get; set; }
        public string op_hdr3 { get; set; }
        public string value_header1 { get; set; }
        public string value_header2 { get; set; }
        public string value_header3 { get; set; }
        public string value_header4 { get; set; }
        public string value_header5 { get; set; }
        public string value_header6 { get; set; }
        public string value_header7 { get; set; }
        public string value_header8 { get; set; }
        public string value_header9 { get; set; }
        public string value_header10 { get; set; }
        public string value_header11 { get; set; }
        public string value_header12 { get; set; }
        public string value_header13 { get; set; }
        public string value_header14 { get; set; }
        public string value_header15 { get; set; }
        public string value_header16 { get; set; }
        public string value_header17 { get; set; }
        public string value_header18 { get; set; }
        public string value_header19 { get; set; }
        public string value_header20 { get; set; }
        public string value_header31 { get; set; }
        public string value_header32 { get; set; }
        public string value_header33 { get; set; }
        public string value_header34 { get; set; }
        public string value_header35 { get; set; }
        public string value_header36 { get; set; }
        public string value_header37 { get; set; }
        public string value_header38 { get; set; }
        public string value_header39 { get; set; }
        public string value_header40 { get; set; }
        public string value_header41 { get; set; }
        public string value_header42 { get; set; }
        public string value_header43 { get; set; }
        public string value_header44 { get; set; }
        public string value_header45 { get; set; }
        public string value_header46 { get; set; }
        public string value_header47 { get; set; }
        public string value_header48 { get; set; }
        public string value_header49 { get; set; }
        public string value_header50 { get; set; }
    }
    public class QMS_T001_B_UNC : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _tm_id;
        public int tm_id
        {
            get { return _tm_id; }
            set
            {
                _tm_id = value;
                RaisePropertyChanged("tm_id");
            }
        }

        private string _test_type_code;
        public string test_type_code
        {
            get { return _test_type_code; }
            set
            {
                _test_type_code = value;
                RaisePropertyChanged("test_type_code");
            }
        }

        private int? _seq_no;
        public int? seq_no
        {
            get { return _seq_no; }
            set
            {
                _seq_no = value;
                RaisePropertyChanged("seq_no");
            }
        }

        private int? _value_id1;
        public int? value_id1
        {
            get { return _value_id1; }
            set
            {
                if (_value_id1 != value)
                {
                    _value_id1 = value;
                    RaisePropertyChanged("value_id1", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id2;
        public int? value_id2
        {
            get { return _value_id2; }
            set
            {
                if (_value_id2 != value)
                {
                    _value_id2 = value;
                    RaisePropertyChanged("value_id2", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id3;
        public int? value_id3
        {
            get { return _value_id3; }
            set
            {
                if (_value_id3 != value)
                {
                    _value_id3 = value;
                    RaisePropertyChanged("value_id3", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id4;
        public int? value_id4
        {
            get { return _value_id4; }
            set
            {
                if (_value_id4 != value)
                {
                    _value_id4 = value;
                    RaisePropertyChanged("value_id4", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id5;
        public int? value_id5
        {
            get { return _value_id5; }
            set
            {
                if (_value_id5 != value)
                {
                    _value_id5 = value;
                    RaisePropertyChanged("value_id5", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id6;
        public int? value_id6
        {
            get { return _value_id6; }
            set
            {
                if (_value_id6 != value)
                {
                    _value_id6 = value;
                    RaisePropertyChanged("value_id6", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id7;
        public int? value_id7
        {
            get { return _value_id7; }
            set
            {
                if (_value_id7 != value)
                {
                    _value_id7 = value;
                    RaisePropertyChanged("value_id7", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id8;
        public int? value_id8
        {
            get { return _value_id8; }
            set
            {
                if (_value_id8 != value)
                {
                    _value_id8 = value;
                    RaisePropertyChanged("value_id8", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id9;
        public int? value_id9
        {
            get { return _value_id9; }
            set
            {
                if (_value_id9 != value)
                {
                    _value_id9 = value;
                    RaisePropertyChanged("value_id9", ModelEntityUpdated);
                }
            }
        }

        private int? _value_id10;
        public int? value_id10
        {
            get { return _value_id10; }
            set
            {
                if (_value_id10 != value)
                {
                    _value_id10 = value;
                    RaisePropertyChanged("value_id10", ModelEntityUpdated);
                }
            }
        }

        private decimal? _value1;
        public decimal? value1
        {
            get { return _value1; }
            set
            {
                if (_value1.ToString() != value.ToString())
                {
                    _value1 = value;
                    RaisePropertyChanged("value1", ModelEntityUpdated);
                }
            }
        }

        private decimal? _value2;
        public decimal? value2
        {
            get { return _value2; }
            set
            {
                if (_value2.ToString() != value.ToString())
                {
                    _value2 = value;
                    RaisePropertyChanged("value2", ModelEntityUpdated);
                }
            }
        }

        private decimal? _value3;
        public decimal? value3
        {
            get { return _value3; }
            set
            {
                if (_value3.ToString() != value.ToString())
                {
                    _value3 = value;
                    RaisePropertyChanged("value3", ModelEntityUpdated);
                }
            }
        }

        private decimal? _value4;
        public decimal? value4
        {
            get { return _value4; }
            set
            {
                if (_value4.ToString() != value.ToString())
                {
                    _value4 = value;
                    RaisePropertyChanged("value4", ModelEntityUpdated);
                }
            }
        }

        private decimal? _value5;
        public decimal? value5
        {
            get { return _value5; }
            set
            {
                if (_value5.ToString() != value.ToString())
                {
                    _value5 = value;
                    RaisePropertyChanged("value5", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value6;
        public Nullable<decimal> value6
        {
            get { return _value6; }
            set
            {
                if (_value6.ToString() != value.ToString())
                {
                    _value6 = value;
                    RaisePropertyChanged("value6", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value7;
        public Nullable<decimal> value7
        {
            get { return _value7; }
            set
            {
                if (_value7.ToString() != value.ToString())
                {
                    _value7 = value;
                    RaisePropertyChanged("value7", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value8;
        public Nullable<decimal> value8
        {
            get { return _value8; }
            set
            {
                if (_value8.ToString() != value.ToString())
                {
                    _value8 = value;
                    RaisePropertyChanged("value8", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value9;
        public Nullable<decimal> value9
        {
            get { return _value9; }
            set
            {
                if (_value9.ToString() != value.ToString())
                {
                    _value9 = value;
                    RaisePropertyChanged("value9", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value10;
        public Nullable<decimal> value10
        {
            get { return _value10; }
            set
            {
                if (_value10.ToString() != value.ToString())
                {
                    _value10 = value;
                    RaisePropertyChanged("value10", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value11;
        public Nullable<decimal> value11
        {
            get { return _value11; }
            set
            {
                if (_value11.ToString() != value.ToString())
                {
                    _value11 = value;
                    RaisePropertyChanged("value11", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value12;
        public Nullable<decimal> value12
        {
            get { return _value12; }
            set
            {
                if (_value12.ToString() != value.ToString())
                {
                    _value12 = value;
                    RaisePropertyChanged("value12", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value13;
        public Nullable<decimal> value13
        {
            get { return _value13; }
            set
            {
                if (_value13.ToString() != value.ToString())
                {
                    _value13 = value;
                    RaisePropertyChanged("value13", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value14;
        public Nullable<decimal> value14
        {
            get { return _value14; }
            set
            {
                if (_value14.ToString() != value.ToString())
                {
                    _value14 = value;
                    RaisePropertyChanged("value14", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value15;
        public Nullable<decimal> value15
        {
            get { return _value15; }
            set
            {
                if (_value15.ToString() != value.ToString())
                {
                    _value15 = value;
                    RaisePropertyChanged("value15", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value16;
        public Nullable<decimal> value16
        {
            get { return _value16; }
            set
            {
                if (_value16.ToString() != value.ToString())
                {
                    _value16 = value;
                    RaisePropertyChanged("value16", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value17;
        public Nullable<decimal> value17
        {
            get { return _value17; }
            set
            {
                if (_value17.ToString() != value.ToString())
                {
                    _value17 = value;
                    RaisePropertyChanged("value17", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value18;
        public Nullable<decimal> value18
        {
            get { return _value18; }
            set
            {
                if (_value18.ToString() != value.ToString())
                {
                    _value18 = value;
                    RaisePropertyChanged("value18", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value19;
        public Nullable<decimal> value19
        {
            get { return _value19; }
            set
            {
                if (_value19.ToString() != value.ToString())
                {
                    _value19 = value;
                    RaisePropertyChanged("value19", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value20;
        public Nullable<decimal> value20
        {
            get { return _value20; }
            set
            {
                if (_value20.ToString() != value.ToString())
                {
                    _value20 = value;
                    RaisePropertyChanged("value20", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value21;
        public Nullable<decimal> value21
        {
            get { return _value21; }
            set
            {
                if (_value21.ToString() != value.ToString())
                {
                    _value21 = value;
                    RaisePropertyChanged("value21", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value22;
        public Nullable<decimal> value22
        {
            get { return _value22; }
            set
            {
                if (_value22.ToString() != value.ToString())
                {
                    _value22 = value;
                    RaisePropertyChanged("value22", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value23;
        public Nullable<decimal> value23
        {
            get { return _value23; }
            set
            {
                if (_value23.ToString() != value.ToString())
                {
                    _value23 = value;
                    RaisePropertyChanged("value23", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value24;
        public Nullable<decimal> value24
        {
            get { return _value24; }
            set
            {
                if (_value24.ToString() != value.ToString())
                {
                    _value24 = value;
                    RaisePropertyChanged("value24", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value25;
        public Nullable<decimal> value25
        {
            get { return _value25; }
            set
            {
                if (_value25.ToString() != value.ToString())
                {
                    _value25 = value;
                    RaisePropertyChanged("value25", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value26;
        public Nullable<decimal> value26
        {
            get { return _value26; }
            set
            {
                if (_value26.ToString() != value.ToString())
                {
                    _value26 = value;
                    RaisePropertyChanged("value26", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value27;
        public Nullable<decimal> value27
        {
            get { return _value27; }
            set
            {
                if (_value27.ToString() != value.ToString())
                {
                    _value27 = value;
                    RaisePropertyChanged("value27", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value28;
        public Nullable<decimal> value28
        {
            get { return _value28; }
            set
            {
                if (_value28.ToString() != value.ToString())
                {
                    _value28 = value;
                    RaisePropertyChanged("value28", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value29;
        public Nullable<decimal> value29
        {
            get { return _value29; }
            set
            {
                if (_value29.ToString() != value.ToString())
                {
                    _value29 = value;
                    RaisePropertyChanged("value29", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value30;
        public Nullable<decimal> value30
        {
            get { return _value30; }
            set
            {
                if (_value30.ToString() != value.ToString())
                {
                    _value30 = value;
                    RaisePropertyChanged("value30", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value31;
        public Nullable<decimal> value31
        {
            get { return _value31; }
            set
            {
                if (_value31.ToString() != value.ToString())
                {
                    _value31 = value;
                    //RaisePropertyChanged("value31", ModelEntityUpdated);
                    RaisePropertyChanged("value31");
                }
            }
        }

        private Nullable<decimal> _value32;
        public Nullable<decimal> value32
        {
            get { return _value32; }
            set
            {
                if (_value32.ToString() != value.ToString())
                {
                    _value32 = value;
                    //RaisePropertyChanged("value32", ModelEntityUpdated);
                    RaisePropertyChanged("value32");
                }
            }
        }

        private Nullable<decimal> _value33;
        public Nullable<decimal> value33
        {
            get { return _value33; }
            set
            {
                if (_value33.ToString() != value.ToString())
                {
                    _value33 = value;
                    //RaisePropertyChanged("value33", ModelEntityUpdated);
                    RaisePropertyChanged("value33");
                }
            }
        }

        private Nullable<decimal> _value34;
        public Nullable<decimal> value34
        {
            get { return _value34; }
            set
            {
                if (_value34.ToString() != value.ToString())
                {
                    _value34 = value;
                    //RaisePropertyChanged("value34", ModelEntityUpdated);
                    RaisePropertyChanged("value34");
                }
            }
        }

        private Nullable<decimal> _value35;
        public Nullable<decimal> value35
        {
            get { return _value35; }
            set
            {
                if (_value35.ToString() != value.ToString())
                {
                    _value35 = value;
                    //RaisePropertyChanged("value35", ModelEntityUpdated);
                    RaisePropertyChanged("value35");
                }
            }
        }

        private Nullable<decimal> _value36;
        public Nullable<decimal> value36
        {
            get { return _value36; }
            set
            {
                if (_value36.ToString() != value.ToString())
                {
                    _value36 = value;
                    //RaisePropertyChanged("value36", ModelEntityUpdated);
                    RaisePropertyChanged("value36");
                }
            }
        }

        private Nullable<decimal> _value37;
        public Nullable<decimal> value37
        {
            get { return _value37; }
            set
            {
                if (_value37.ToString() != value.ToString())
                {
                    _value37 = value;
                    //RaisePropertyChanged("value37", ModelEntityUpdated);
                    RaisePropertyChanged("value37");
                }
            }
        }


        private Nullable<decimal> _value38;
        public Nullable<decimal> value38
        {
            get { return _value38; }
            set
            {
                if (_value38.ToString() != value.ToString())
                {
                    _value38 = value;
                    //RaisePropertyChanged("value38", ModelEntityUpdated);
                    RaisePropertyChanged("value38");
                }
            }
        }

        private Nullable<decimal> _value39;
        public Nullable<decimal> value39
        {
            get { return _value39; }
            set
            {
                if (_value39.ToString() != value.ToString())
                {
                    _value39 = value;
                    //RaisePropertyChanged("value39", ModelEntityUpdated);
                    RaisePropertyChanged("value39");
                }
            }
        }

        private Nullable<decimal> _value40;
        public Nullable<decimal> value40
        {
            get { return _value40; }
            set
            {
                if (_value40.ToString() != value.ToString())
                {
                    _value40 = value;
                    //RaisePropertyChanged("value40", ModelEntityUpdated);
                    RaisePropertyChanged("value40");
                }
            }
        }

        private Nullable<decimal> _value41;
        public Nullable<decimal> value41
        {
            get { return _value41; }
            set
            {
                if (_value41.ToString() != value.ToString())
                {
                    _value41 = value;
                    //RaisePropertyChanged("value41", ModelEntityUpdated);
                    RaisePropertyChanged("value41");
                }
            }
        }

        private Nullable<decimal> _value42;
        public Nullable<decimal> value42
        {
            get { return _value42; }
            set
            {
                if (_value42.ToString() != value.ToString())
                {
                    _value42 = value;
                    //RaisePropertyChanged("value42", ModelEntityUpdated);
                    RaisePropertyChanged("value42");
                }
            }
        }

        private Nullable<decimal> _value43;
        public Nullable<decimal> value43
        {
            get { return _value43; }
            set
            {
                if (_value43.ToString() != value.ToString())
                {
                    _value43 = value;
                    //RaisePropertyChanged("value43", ModelEntityUpdated);
                    RaisePropertyChanged("value43");
                }
            }
        }

        private Nullable<decimal> _value44;
        public Nullable<decimal> value44
        {
            get { return _value44; }
            set
            {
                if (_value44.ToString() != value.ToString())
                {
                    _value44 = value;
                    //RaisePropertyChanged("value44", ModelEntityUpdated);
                    RaisePropertyChanged("value44");
                }
            }
        }

        private decimal? _value45;
        public decimal? value45
        {
            get { return _value45; }
            set
            {
                if (_value45.ToString() != value.ToString())
                {
                    _value45 = value;
                    //RaisePropertyChanged("value45", ModelEntityUpdated);
                    RaisePropertyChanged("value45");
                }
            }
        }

        private Nullable<decimal> _value46;
        public Nullable<decimal> value46
        {
            get { return _value46; }
            set
            {
                if (_value46.ToString() != value.ToString())
                {
                    _value46 = value;
                    //RaisePropertyChanged("value46", ModelEntityUpdated);
                    RaisePropertyChanged("value46");
                }
            }
        }

        private Nullable<decimal> _value47;
        public Nullable<decimal> value47
        {
            get { return _value47; }
            set
            {
                if (_value47.ToString() != value.ToString())
                {
                    _value47 = value;
                    //RaisePropertyChanged("value47", ModelEntityUpdated);
                    RaisePropertyChanged("value47");
                }
            }
        }

        private Nullable<decimal> _value48;
        public Nullable<decimal> value48
        {
            get { return _value48; }
            set
            {
                if (_value48.ToString() != value.ToString())
                {
                    _value48 = value;
                    //RaisePropertyChanged("value48", ModelEntityUpdated);
                    RaisePropertyChanged("value48");
                }
            }
        }

        private Nullable<decimal> _value49;
        public Nullable<decimal> value49
        {
            get { return _value49; }
            set
            {
                if (_value49.ToString() != value.ToString())
                {
                    _value49 = value;
                    //RaisePropertyChanged("value49", ModelEntityUpdated);
                    RaisePropertyChanged("value49");
                }

            }
        }

        private Nullable<decimal> _value50;
        public Nullable<decimal> value50
        {
            get { return _value50; }
            set
            {
                if (_value50.ToString() != value.ToString())
                {
                    _value50 = value;
                    //RaisePropertyChanged("value50", ModelEntityUpdated);
                    RaisePropertyChanged("value50");
                }
            }
        }

        private Nullable<decimal> _value51;
        public Nullable<decimal> value51
        {
            get { return _value51; }
            set
            {
                if (_value51.ToString() != value.ToString())
                {
                    _value51 = value;
                    //RaisePropertyChanged("value51", ModelEntityUpdated);
                    RaisePropertyChanged("value51");
                }
            }
        }

        private Nullable<decimal> _value52;
        public Nullable<decimal> value52
        {
            get { return _value52; }
            set
            {
                if (_value52.ToString() != value.ToString())
                {
                    _value52 = value;
                    //RaisePropertyChanged("value52", ModelEntityUpdated);
                    RaisePropertyChanged("value52");
                }
            }
        }

        private Nullable<decimal> _value53;
        public Nullable<decimal> value53
        {
            get { return _value53; }
            set
            {
                if (_value53.ToString() != value.ToString())
                {
                    _value53 = value;
                    //RaisePropertyChanged("value53", ModelEntityUpdated);
                    RaisePropertyChanged("value53");
                }
            }
        }
        private Nullable<decimal> _value54;
        public Nullable<decimal> value54
        {
            get { return _value54; }
            set
            {
                if (_value54.ToString() != value.ToString())
                {
                    _value54 = value;
                    RaisePropertyChanged("value54", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value55;
        public Nullable<decimal> value55
        {
            get { return _value55; }
            set
            {
                if (_value55.ToString() != value.ToString())
                {
                    _value55 = value;
                    RaisePropertyChanged("value55", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value56;
        public Nullable<decimal> value56
        {
            get { return _value56; }
            set
            {
                if (_value56.ToString() != value.ToString())
                {
                    _value56 = value;
                    RaisePropertyChanged("value56", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value57;
        public Nullable<decimal> value57
        {
            get { return _value57; }
            set
            {
                if (_value57.ToString() != value.ToString())
                {
                    _value57 = value;
                    RaisePropertyChanged("value57", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value58;
        public Nullable<decimal> value58
        {
            get { return _value58; }
            set
            {
                if (_value58.ToString() != value.ToString())
                {
                    _value58 = value;
                    RaisePropertyChanged("value58", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _value59;
        public Nullable<decimal> value59
        {
            get { return _value59; }
            set
            {
                if (_value59.ToString() != value.ToString())
                {
                    _value59 = value;
                    //RaisePropertyChanged("value59", ModelEntityUpdated);
                    RaisePropertyChanged("value59");
                }
            }
        }

        private Nullable<decimal> _value60;
        public Nullable<decimal> value60
        {
            get { return _value60; }
            set
            {
                if (_value60.ToString() != value.ToString())
                {
                    _value60 = value;
                    //RaisePropertyChanged("value60", ModelEntityUpdated);
                    RaisePropertyChanged("value60");
                }
            }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private string _master_inst;
        public string master_inst
        {
            get { return _master_inst; }
            set { _master_inst = value; RaisePropertyChanged("master_inst"); }
        }

        private decimal? _value61;
        public decimal? value61
        {
            get { return _value61; }
            set
            {
                _value61 = value;
                RaisePropertyChanged("value61");
            }
        }

        private decimal? _value62;
        public decimal? value62
        {
            get { return _value62; }
            set
            {
                _value62 = value;
                RaisePropertyChanged("value62");
            }
        }
        private decimal? _value63;
        public decimal? value63
        {
            get { return _value63; }
            set
            {
                _value63 = value;
                RaisePropertyChanged("value63");
            }
        }

        private decimal? _value64;
        public decimal? value64
        {
            get { return _value64; }
            set
            {
                _value64 = value;
                RaisePropertyChanged("value64");
            }
        }
        private decimal? _value65;
        public decimal? value65
        {
            get { return _value65; }
            set
            {
                _value65 = value;
                RaisePropertyChanged("value65");
            }
        }

        private decimal? _value66;
        public decimal? value66
        {
            get { return _value66; }
            set
            {
                _value66 = value;
                RaisePropertyChanged("value66");
            }
        }
        private decimal? _value67;
        public decimal? value67
        {
            get { return _value67; }
            set
            {
                _value67 = value;
                RaisePropertyChanged("value67");
            }
        }

        private decimal? _value68;
        public decimal? value68
        {
            get { return _value68; }
            set
            {
                _value68 = value;
                RaisePropertyChanged("value68");
            }
        }
        private decimal? _value69;
        public decimal? value69
        {
            get { return _value69; }
            set
            {
                _value69 = value;
                RaisePropertyChanged("value69");
            }
        }

        private decimal? _value70;
        public decimal? value70
        {
            get { return _value70; }
            set
            {
                _value70 = value;
                RaisePropertyChanged("value70");
            }
        }
        private decimal? _dev_value;
        public decimal? dev_value
        {
            get { return _dev_value; }
            set
            {
                _dev_value = value;
                RaisePropertyChanged("dev_value");
            }
        }

        private decimal? _dev_mean_value;
        public decimal? dev_mean_value
        {
            get { return _dev_mean_value; }
            set
            {
                _dev_mean_value = value;
                RaisePropertyChanged("dev_mean_value");
            }
        }

        private decimal? _dev_per_value;
        public decimal? dev_per_value
        {
            get { return _dev_per_value; }
            set
            {
                _dev_per_value = value;
                RaisePropertyChanged("dev_per_value");
            }
        }

        private int? _degree_of_frdm;
        public int? degree_of_frdm
        {
            get { return _degree_of_frdm; }
            set
            {
                _degree_of_frdm = value;
                RaisePropertyChanged("degree_of_frdm");
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

        private string _column_value1;
        public string column_value1
        {
            get { return _column_value1; }
            set
            {
                if (value != _column_value1)
                {
                    _column_value1 = value;
                    RaisePropertyChanged("column_value1");
                }
            }
        }

        private string _column_value2;
        public string column_value2
        {
            get { return _column_value2; }
            set
            {
                if (value != _column_value2)
                {
                    _column_value2 = value;
                    RaisePropertyChanged("column_value2");
                }
            }
        }

        private string _column_value3;
        public string column_value3
        {
            get { return _column_value3; }
            set
            {
                if (value != _column_value3)
                {
                    _column_value3 = value;
                    RaisePropertyChanged("column_value3");
                }
            }
        }

        private string _column_value4;
        public string column_value4
        {
            get { return _column_value4; }
            set
            {
                _column_value4 = value;
                RaisePropertyChanged("column_value4");
            }
        }

        private string _column_value5;
        public string column_value5
        {
            get { return _column_value5; }
            set
            {
                _column_value5 = value;
                RaisePropertyChanged("column_value5");
            }
        }

        private string _column_value6;
        public string column_value6
        {
            get { return _column_value6; }
            set
            {
                _column_value6 = value;
                RaisePropertyChanged("column_value6");
            }
        }

        private string _column_value7;
        public string column_value7
        {
            get { return _column_value7; }
            set
            {
                _column_value7 = value;
                RaisePropertyChanged("column_value7");
            }
        }

        private string _column_value8;
        public string column_value8
        {
            get { return _column_value8; }
            set
            {
                _column_value8 = value;
                RaisePropertyChanged("column_value8");
            }
        }

        private string _column_value9;
        public string column_value9
        {
            get { return _column_value9; }
            set
            {
                _column_value9 = value;
                RaisePropertyChanged("column_value9");
            }
        }

        private string _column_value10;
        public string column_value10
        {
            get { return _column_value10; }
            set
            {
                _column_value10 = value;
                RaisePropertyChanged("column_value10");
            }
        }
        public decimal? _m_uncertainty;
        public decimal? m_uncertainty
        {
            get { return _m_uncertainty; }
            set
            {
                _m_uncertainty = value;
                RaisePropertyChanged("m_uncertainty");
            }
        }
        public decimal? _m_accuracy;
        public decimal? m_accuracy
        {
            get { return _m_accuracy; }
            set
            {
                _m_accuracy = value;
                RaisePropertyChanged("m_accuracy");
            }
        }
        public decimal? _m_resolution;
        public decimal? m_resolution
        {
            get { return _m_resolution; }
            set
            {
                _m_resolution = value;
                RaisePropertyChanged("m_resolution");
            }
        }
        public decimal? _coverage_factor;
        public decimal? coverage_factor
        {
            get { return _coverage_factor; }
            set
            {
                _coverage_factor = value;
                RaisePropertyChanged("coverage_factor");
            }
        }
        public string _conf_level;
        public string conf_level
        {
            get { return _conf_level; }
            set
            {
                _conf_level = value;
                RaisePropertyChanged("conf_level");
            }
        }
        //Scalar
        private int? _deletion_id;
        public int? deletion_id
        {
            get { return _deletion_id; }
            set { _deletion_id = value; RaisePropertyChanged("deletion_id"); }
        }

        private byte[] _image1;
        public byte[] image1
        {
            get { return _image1; }
            set { _image1 = value; RaisePropertyChanged("image1"); }
        }
        private byte[] _image2;
        public byte[] image2
        {
            get { return _image2; }
            set { _image2 = value; RaisePropertyChanged("image2"); }
        }
        private byte[] _image3;
        public byte[] image3
        {
            get { return _image3; }
            set { _image3 = value; RaisePropertyChanged("image3"); }
        }
        private bool _select31;
        public bool select31
        {
            get { return _select31; }
            set
            {
                if (_select31 != value)
                {
                    _select31 = value;
                    RaisePropertyChanged("select31", ModelEntityUpdated);
                }
            }
        }

        private bool _select32;
        public bool select32
        {
            get { return _select32; }
            set
            {
                if (_select32 != value)
                {
                    _select32 = value;
                    RaisePropertyChanged("select32", ModelEntityUpdated);
                }
            }
        }

        private bool _select33;
        public bool select33
        {
            get { return _select33; }
            set
            {
                if (_select33 != value)
                {
                    _select33 = value;
                    RaisePropertyChanged("select33", ModelEntityUpdated);
                }
            }
        }

        private bool _select34;
        public bool select34
        {
            get { return _select34; }
            set
            {
                if (_select34 != value)
                {
                    _select34 = value;
                    RaisePropertyChanged("select34", ModelEntityUpdated);
                }
            }
        }
        private bool _select35;
        public bool select35
        {
            get { return _select35; }
            set
            {
                if (_select35 != value)
                {
                    _select35 = value;
                    RaisePropertyChanged("select35", ModelEntityUpdated);
                }
            }
        }
        private bool _select36;
        public bool select36
        {
            get { return _select36; }
            set
            {
                if (_select36 != value)
                {
                    _select36 = value;
                    RaisePropertyChanged("select36", ModelEntityUpdated);
                }
            }
        }
        private bool _select37;
        public bool select37
        {
            get { return _select37; }
            set
            {
                if (_select37 != value)
                {
                    _select37 = value;
                    RaisePropertyChanged("select37", ModelEntityUpdated);
                }
            }
        }
        private bool _select38;
        public bool select38
        {
            get { return _select38; }
            set
            {
                if (_select38 != value)
                {
                    _select38 = value;
                    RaisePropertyChanged("select38", ModelEntityUpdated);
                }
            }
        }
        private bool _select39;
        public bool select39
        {
            get { return _select39; }
            set
            {
                if (_select39 != value)
                {
                    _select39 = value;
                    RaisePropertyChanged("select39", ModelEntityUpdated);
                }
            }
        }
        private bool _select40;
        public bool select40
        {
            get { return _select40; }
            set
            {
                if (_select40 != value)
                {
                    _select40 = value;
                    RaisePropertyChanged("select40", ModelEntityUpdated);
                }
            }
        }
        private bool _select41;
        public bool select41
        {
            get { return _select41; }
            set
            {
                if (_select41 != value)
                {
                    _select41 = value;
                    RaisePropertyChanged("select41", ModelEntityUpdated);
                }
            }
        }
        private bool _select42;
        public bool select42
        {
            get { return _select42; }
            set
            {
                if (_select42 != value)
                {
                    _select42 = value;
                    RaisePropertyChanged("select42", ModelEntityUpdated);
                }
            }
        }
        private bool _select43;
        public bool select43
        {
            get { return _select43; }
            set
            {
                if (_select43 != value)
                {
                    _select43 = value;
                    RaisePropertyChanged("select43", ModelEntityUpdated);
                }
            }
        }
        private bool _select44;
        public bool select44
        {
            get { return _select44; }
            set
            {
                if (_select44 != value)
                {
                    _select44 = value;
                    RaisePropertyChanged("select44", ModelEntityUpdated);
                }
            }
        }
        private bool _select45;
        public bool select45
        {
            get { return _select45; }
            set
            {
                if (_select45 != value)
                {
                    _select45 = value;
                    RaisePropertyChanged("select45", ModelEntityUpdated);
                }
            }
        }
        private bool _select46;
        public bool select46
        {
            get { return _select46; }
            set
            {
                if (_select46 != value)
                {
                    _select46 = value;
                    RaisePropertyChanged("select46", ModelEntityUpdated);
                }
            }
        }
        private bool _select47;
        public bool select47
        {
            get { return _select47; }
            set
            {
                if (_select47 != value)
                {
                    _select47 = value;
                    RaisePropertyChanged("select47", ModelEntityUpdated);
                }
            }
        }
        private bool _select48;
        public bool select48
        {
            get { return _select48; }
            set
            {
                if (_select48 != value)
                {
                    _select48 = value;
                    RaisePropertyChanged("select48", ModelEntityUpdated);
                }
            }
        }
        private bool _select49;
        public bool select49
        {
            get { return _select49; }
            set
            {
                if (_select49 != value)
                {
                    _select49 = value;
                    RaisePropertyChanged("select49", ModelEntityUpdated);
                }
            }
        }
        private bool _select50;
        public bool select50
        {
            get { return _select50; }
            set
            {
                if (_select50 != value)
                {
                    _select50 = value;
                    RaisePropertyChanged("select50", ModelEntityUpdated);
                }
            }
        }
    }
}
