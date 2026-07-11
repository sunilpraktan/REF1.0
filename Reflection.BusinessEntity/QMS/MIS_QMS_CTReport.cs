using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.QMS
{
    public class MIS_QMS_CTReport : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private DateTime? _FromDate;
        public DateTime? FromDate
        {
            get { return _FromDate; }
            set
            {
                if (_FromDate != value)
                {
                    _FromDate = value;
                    RaisePropertyChanged("FromDate");
                }               
            }
        }

        private string _insp_type_name;
        public string insp_type_name
        {
            get { return _insp_type_name; }
            set
            {
                if (_insp_type_name != value)
                {
                    _insp_type_name = value;
                    RaisePropertyChanged("insp_type_name");
                }               
            }
        }

        private string _insp_type;
        public string insp_type
        {
            get { return _insp_type; }
            set
            {
                if (_insp_type != value)
                {
                    _insp_type = value;
                    RaisePropertyChanged("insp_type");
                }              
            }
        }

        private string _test_code;
        public string test_code
        {
            get { return _test_code; }
            set
            {
                if (_test_code != value)
                {
                    _test_code = value;
                    RaisePropertyChanged("test_code");
                }               
            }
        }

        private string _inst_type;
        public string inst_type
        {
            get { return _inst_type; }
            set
            {
                if (_inst_type != value)
                {
                    _inst_type = value;
                    RaisePropertyChanged("inst_type");
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
                    _test_name = value;
                    RaisePropertyChanged("insp_type");
                }
            }              
        }

        private string _ReportType;
        public string ReportType
        {
            get { return _ReportType; }
            set
            {
                if (_ReportType != value)
                {
                    _ReportType = value;
                    RaisePropertyChanged("ReportType");
                }              
            }
        }


        private DateTime? _ToDate;
        public DateTime? ToDate
        {
            get { return _ToDate; }
            set
            {
                if (_ToDate != value)
                {
                    _ToDate = value;
                    RaisePropertyChanged("ToDate");
                }                
            }
        }      

        private string _ReportName;
        public string ReportName
        {
            get { return _ReportName; }
            set
            {
                if (_ReportName != value)
                {
                    _ReportName = value;
                    RaisePropertyChanged("ReportName");
                }
            }            
        }

        private string _ReportCode;
        public string ReportCode
        {
            get { return _ReportCode; }
            set
            {
                if (_ReportCode != value)
                {
                    _ReportCode = value;
                    RaisePropertyChanged("ReportCode");
                }
            }                
        }

        private string _inst_code;
        public string inst_code
        {
            get { return _inst_code; }
            set
            {
                if (_inst_code != value)
                {
                    _inst_code = value;
                    RaisePropertyChanged("inst_code");
                }
            }                         
        }

        private string _inst_name;
        public string inst_name
        {
            get { return _inst_name; }
            set
            {
                if (_inst_name != value)
                {
                    _inst_name = value;
                    RaisePropertyChanged("inst_name");
                }
            }                
        }

        private string _lab_code;
        public string lab_code
        {
            get { return _lab_code; }
            set
            {
                if (_lab_code != value)
                {
                    _lab_code = value;
                    RaisePropertyChanged("lab_code");
                }
            }
              
        }

        private string _lab_name;
        public string lab_name
        {
            get { return _lab_name; }
            set
            {
                if (_lab_name != value)
                {
                    _lab_name = value;
                    RaisePropertyChanged("lab_name");
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


        private string _comp_code;
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

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value;
                    RaisePropertyChanged("doc_no");
                }
            }             
        }
        private string _po_no;
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
    }

    public partial class RptMISInspection
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string lab_code { get; set; }
        public string barcode { get; set; }
        public string test_code { get; set; }
        public string ref_doc_no { get; set; }
        public string rig_code { get; set; }
        public string tr_code { get; set; }
        public string temperature { get; set; }
        public string humidity { get; set; }
        public string remark1 { get; set; }
        public string remark2 { get; set; }
        public string remark3 { get; set; }
        public string master_inst { get; set; }
        public string EmpId { get; set; }
        public string cal_type { get; set; }
        public string po_no { get; set; }
        public string PartyId { get; set; }
        public int ContInfoId { get; set; }
        public DateTime? cal_date { get; set; }
        public DateTime? last_date { get; set; }
        public int cal_freq { get; set; }
        public string cal_period { get; set; }
        public DateTime? next_date { get; set; }
        public string u_remark1 { get; set; }
        public string u_remark2 { get; set; }
        public string u_remark3 { get; set; }
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
        public string start_temp { get; set; }
        public string end_temp { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public DateTime? doc_date { get; set; }
        public DateTime? due_date { get; set; }
        public string PartyNm { get; set; }
        public string inst_code { get; set; }
        public string inst_name { get; set; }
        public string serv_type { get; set; }
        public string insp_lot_no { get; set; }
        public string resolution { get; set; }
        public string middle_temp { get; set; }
        public string inst_type { get; set; }
        //Scalar
        public string test_name { get; set; }
        public string inst_id { get; set; }
        public string inst_make { get; set; }
        public string inst_srno { get; set; }
        public string model_no { get; set; }
        public string least_count { get; set; }
        public string range { get; set; }
        public string accuracy { get; set; }
        public string cont_per_name { get; set; }
        public string EmpNm { get; set; }
        public string tr_name { get; set; }
        public string rig_name { get; set; }
        public string lab_name { get; set; }
        public string to_mail_id { get; set; }
        public string inst_cond { get; set; }
        public string approvernm { get; set; }
    }

    public class MultipleContextMIS_QMS_CT
    {
        public List<ADM_M003_B_P> Laboratory { get; set; }
        public List<QMS_M009Flip> TestCode { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<QMS_M003_P> Instrument { get; set; }
        public List<QMS_M013_P> InspType { get; set; }  //Insp type Master
        public List<RptMISInspection> RptMISInspectionList { get; set; }
    }
}
