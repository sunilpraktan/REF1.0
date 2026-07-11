using Reflection.BusinessEntity.SCM;
using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.SCM
{   
    public class MIS_FinStatement : ObjectBase
    {
        private Nullable<DateTime> _FromDate;
        public Nullable<DateTime> FromDate
        {
            get { return _FromDate; }
            set
            {
                _FromDate = value;
                RaisePropertyChanged("FromDate");
            }
        }

        private Nullable<DateTime> _ToDate;
        public Nullable<DateTime> ToDate
        {
            get { return _ToDate; }
            set
            {
                _ToDate = value;
                RaisePropertyChanged("ToDate");
            }
        }
        private string _Remark;
        public string Remark
        {
            get { return _Remark; }
            set
            {
                _Remark = value;
                RaisePropertyChanged("Remark");
            }
        }

        private string _Duration;
        public string Duration
        {
            get { return _Duration; }
            set
            {
                _Duration = value;
                RaisePropertyChanged("Duration");
            }
        }
        private string _ReportName;
        public string ReportName
        {
            get { return _ReportName; }
            set
            {
                _ReportName = value;
                RaisePropertyChanged("ReportName");
            }
        }

        private string _ReportCode;
        public string ReportCode
        {
            get { return _ReportCode; }
            set
            {
                _ReportCode = value;
                RaisePropertyChanged("ReportCode");
            }
        }

        private string _MatConditionCode;
        public string MatConditionCode
        {
            get { return _MatConditionCode; }
            set
            {

                _MatConditionCode = value;
                RaisePropertyChanged("MatConditionCode");

            }
        }
        private string _MatConditionValue;
        public string MatConditionValue
        {
            get { return _MatConditionValue; }
            set
            {

                _MatConditionValue = value;
                RaisePropertyChanged("MatConditionValue");

            }
        }

        private string _CurUnCur;
        public string CurUnCur
        {
            get { return _CurUnCur; }
            set
            {

                _CurUnCur = value;
                RaisePropertyChanged("CurUnCur");

            }
        }
        private string _CurUnCurCode;
        public string CurUnCurCode
        {
            get { return _CurUnCurCode; }
            set
            {

                _CurUnCurCode = value;
                RaisePropertyChanged("CurUnCurCode");

            }
        }

        private string _ImportLocalCode;
        public string ImportLocalCode
        {
            get { return _ImportLocalCode; }
            set
            {

                _ImportLocalCode = value;
                RaisePropertyChanged("ImportLocalCode");
            }
        }
        private string _ImportLocalValue;
        public string ImportLocalValue
        {
            get { return _ImportLocalValue; }
            set
            {

                _ImportLocalValue = value;
                RaisePropertyChanged("ImportLocalValue");
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
        private string _LoctnNm;
        public string LoctnNm
        {
            get { return _LoctnNm; }
            set
            {
                _LoctnNm = value;
                RaisePropertyChanged("LoctnNm");
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
        private string _compName;
        public string CompName
        {
            get { return _compName; }
            set
            {
                _compName = value;
                RaisePropertyChanged("CompName");
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

        private string _para1;
        public string para1
        {
            get { return _para1; }
            set
            {
                _para1 = value;
                RaisePropertyChanged("para1");
            }
        }

        private string _para2;
        public string para2
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

        private string _unit_name;
        public string unit_name
        {
            get { return _unit_name; }
            set
            {
                _unit_name = value;
                RaisePropertyChanged("unit_name");
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

        private string _CatCode;
        public string CatCode
        {
            get { return _CatCode; }
            set
            {
                _CatCode = value;
                RaisePropertyChanged("CatCode");
            }
        }
        private string _CatName;
        public string CatName
        {
            get { return _CatName; }
            set
            {
                _CatName = value;
                RaisePropertyChanged("CatName");
            }
        }

        private string _SubCatName;
        public string SubCatName
        {
            get { return _SubCatName; }
            set
            {
                _SubCatName = value;
                RaisePropertyChanged("SubCatName");
            }
        }

        private string _SubCatCode;
        public string SubCatCode
        {
            get { return _SubCatCode; }
            set
            {
                _SubCatCode = value;
                RaisePropertyChanged("SubCatCode");
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

        private string _wire_type;
        public string wire_type
        {
            get { return _wire_type; }
            set
            {
                _wire_type = value;
                RaisePropertyChanged("wire_type");
            }
        }

        private int _wire_type_id;
        public int wire_type_id
        {
            get { return _wire_type_id; }
            set
            {
                _wire_type_id = value;
                RaisePropertyChanged("wire_type_id");
            }
        }

        private string _wire_size;
        public string wire_size
        {
            get { return _wire_size; }
            set
            {
                _wire_size = value;
                RaisePropertyChanged("wire_size");
            }
        }

        private string _wire_size_id;
        public string wire_size_id
        {
            get { return _wire_size_id; }
            set
            {
                _wire_size_id = value;
                RaisePropertyChanged("wire_size_id");
            }
        }

        private string _TipType;
        public string TipType
        {
            get { return _TipType; }
            set
            {
                _TipType = value;
                RaisePropertyChanged("TipType");
            }
        }

        private string _TipCode;
        public string TipCode
        {
            get { return _TipCode; }
            set
            {
                _TipCode = value;
                RaisePropertyChanged("TipCode");
            }
        }
        private string _ReportType;
        public string ReportType
        {
            get { return _ReportType; }
            set
            {
                _ReportType = value;
                RaisePropertyChanged("ReportType");
            }
        }

    
        private bool _Select;//scaler
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
        //sku
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
        private string _parametervalue;
        public string parametervalue
        {
            get { return _parametervalue; }
            set
            {
                _parametervalue = value;
                RaisePropertyChanged("parametervalue");
            }
        }
        private string _SubCatCode1;
        public string SubCatCode1
        {
            get { return _SubCatCode1; }
            set
            {
                _SubCatCode1 = value;
                RaisePropertyChanged("SubCatCode1");
            }
        }
       
        //Fin yr and Posting Period
        private string _short_desc;
        public string short_desc
        {
            get { return _short_desc; }
            set
            {
                _short_desc = value;
                RaisePropertyChanged("short_desc");
            }
        }
        private string _long_desc;
        public string long_desc
        {
            get { return _long_desc; }
            set
            {
                _long_desc = value;
                RaisePropertyChanged("long_desc");
            }
        }

        private int _post_year;
        public int post_year
        {
            get { return _post_year; }
            set
            {
                _post_year = value;
                RaisePropertyChanged("post_year");
            }
        }
        private int _post_per;
        public int post_per
        {
            get { return _post_per; }
            set
            {
                _post_per = value;
                RaisePropertyChanged("post_per");
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

        
        private string _mctype;
        public string mctype
        {
            get { return _mctype; }
            set
            {
                _mctype = value;
                RaisePropertyChanged("mctype");
            }
        }
     

    }
    public class MultipleContext_MIS_FinStatement
    {

        public List<ADM_M018_P> CategoryDetails { get; set; }
        public List<ADM_M019_P> SubCategoryDetails { get; set; }
        public List<ADM_M038_B_P> UnitDetails { get; set; }
        public List<ADM_M031_P> ParameterList { get; set; }
        public List<ADM_M030_P> ParamValueList { get; set; }
        public List<ACC_M001A_P> FinYear { get; set; }
        public List<ACC_M001A_P> PostPeriod { get; set; }
        public List<ZADM_M010_P> TipTypes { get; set; }
        public List<ZADM_M004_P> WireTypeDetails { get; set; }
        public List<UptoDateFG> UpToDateFGList { get; set; }
        public List<UptoDateFG> PreviousUptoDateFG { get; set; }
        public List<UptoDateTotal> UptoDateTotal { get; set; }
        public List<UptoDateTS> PreviousUptoDateTS { get; set; }
        public List<UptoDateTotalTS> UptoDateTotalTS { get; set; }
        public List<UptoDateTS> CurrrentUptoDateTS { get; set; }
        public List<MIS_RptFinStatement> FinReportData { get; set; }
        public List<ZADM_M003_P> WireSizeDetails { get; set; }
        public List<ADM_M022_P> ItemDetails { get; set; }

    }


}

