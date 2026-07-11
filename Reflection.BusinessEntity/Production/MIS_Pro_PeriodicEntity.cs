using System;
using System.Collections.Generic;


namespace Reflection.BusinessEntity.Production
{
    public class MIS_Pro_PeriodicEntity : ObjectBase
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


        // Add by Priya

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
        private int _machine_id;
        public int machine_id
        {
            get { return _machine_id; }
            set
            {
                _machine_id = value;
                RaisePropertyChanged("machine_id");
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


        private string _itemTypeNm;
        public string ItemTypeNm
        {
            get { return _itemTypeNm; }
            set
            {
                _itemTypeNm = value;
                RaisePropertyChanged("itemTypeNm");
            }
        }
        private string _itemTypeCd;
        public string ItemTypeCd
        {
            get { return _itemTypeCd; }
            set
            {
                _itemTypeCd = value;
                RaisePropertyChanged("ItemTypeCd");
            }
        }

        private string _subItemTpCd;
        public string SubItemTpCd
        {
            get { return _subItemTpCd; }
            set
            {
                _subItemTpCd = value;
                RaisePropertyChanged("SubItemTpCd");
            }
        }
        private string _subItemTpNm;
        public string SubItemTpNm
        {
            get { return _subItemTpNm; }
            set
            {
                _subItemTpNm = value;
                RaisePropertyChanged("SubItemTpNm");
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

        private string _ball_type;
        public string ball_type
        {
            get { return _ball_type; }
            set
            {
                _ball_type = value;
                RaisePropertyChanged("ball_type");
            }
        }

        private int _ball_type_id;
        public int ball_type_id
        {
            get { return _ball_type_id; }
            set
            {
                _ball_type_id = value;
                RaisePropertyChanged("ball_type_id");
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

        private string _ild_type;
        public string ild_type
        {
            get { return _ild_type; }
            set
            {
                _ild_type = value;
                RaisePropertyChanged("ild_type");
            }
        }


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

        private string _shift;
        public string shift
        {
            get { return _shift; }
            set
            {
                _shift = value;
                RaisePropertyChanged("shift");
            }
        }
        private string _grade_code;
        public string grade_code
        {
            get { return _grade_code; }
            set
            {
                _grade_code = value;
                RaisePropertyChanged("grade_code");
            }
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

        private string _BlankCode;
        public string BlankCode
        {
            get { return _BlankCode; }
            set
            {
                _BlankCode = value;
                RaisePropertyChanged("BlankCode");
            }
        }

        private string _Blank;
        public string Blank
        {
            get { return _Blank; }
            set
            {
                _Blank = value;
                RaisePropertyChanged("Blank");
            }
        }


        private string _SalesAccount;
        public string SalesAccount
        {
            get { return _SalesAccount; }
            set
            {
                _SalesAccount = value;
                RaisePropertyChanged("SalesAccount");
            }
        }

        private string _SalesAccCd;
        public string SalesAccCd
        {
            get { return _SalesAccCd; }
            set
            {
                _SalesAccCd = value;
                RaisePropertyChanged("_SalesAccCd");
            }
        }

        private string _OrderByName;
        public string OrderByName
        {
            get { return _OrderByName; }
            set
            {
                _OrderByName = value;
                RaisePropertyChanged("OrderByName");
            }
        }
        private string _OrderByCode;
        public string OrderByCode
        {
            get { return _OrderByCode; }
            set
            {
                _OrderByCode = value;
                RaisePropertyChanged("OrderByCode");
            }
        }

        private string _RptFormatCode;
        public string RptFormatCode
        {
            get { return _RptFormatCode; }
            set
            {
                _RptFormatCode = value;
                RaisePropertyChanged("RptFormatCode");
            }
        }
        private string _RptFormatNm;
        public string RptFormatNm
        {
            get { return _RptFormatNm; }
            set
            {
                _RptFormatNm = value;
                RaisePropertyChanged("RptFormatNm");
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

        private string _local_export;
        public string local_export
        {
            get { return _local_export; }
            set
            {
                _local_export = value;
                RaisePropertyChanged("local_export");
            }
        }

        private string _average_wt_no;
        public string average_wt_no
        {
            get { return _average_wt_no; }
            set
            {
                _average_wt_no = value;
                RaisePropertyChanged("average_wt_no");
            }
        }

        private Nullable<DateTime> _average_wt_dt;
        public Nullable<DateTime> average_wt_dt
        {
            get { return _average_wt_dt; }
            set
            {
                _average_wt_dt = value;
                RaisePropertyChanged("average_wt_dt");
            }
        }

        private string _Month;
        public string Month
        {
            get { return _Month; }
            set
            {
                _Month = value;
                RaisePropertyChanged("Month");
            }
        }
        private string _Year;
        public string Year
        {
            get { return _Year; }
            set
            {
                _Year = value;
                RaisePropertyChanged("Year");
            }
        }
        private Nullable<DateTime> _Date;
        public Nullable<DateTime> Date
        {
            get { return _Date; }
            set
            {
                _Date = value;
                RaisePropertyChanged("Date");
            }
        }
        private string _Header1;
        public string Header1
        {
            get { return _Header1; }
            set
            {
                _Header1 = value;
                RaisePropertyChanged("Header1");
            }
        }
        private Nullable<decimal> _avg_blank_wt;
        public Nullable<decimal> avg_blank_wt
        {
            get { return _avg_blank_wt; }
            set
            {
                _avg_blank_wt = value;
                RaisePropertyChanged("avg_blank_wt");
            }
        }
        private string _Plant;
        public string Plant
        {
            get { return _Plant; }
            set
            {
                _Plant = value;
                RaisePropertyChanged("Plant");
            }
        }
    }

    //Added by Priya
    public class MultipleContext_MIS_Pro_PeriodicEntity
    {
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<ADM_M022_P> ItemDetails { get; set; }
        public List<ADM_M024_P> Employee { get; set; }
        public List<ADM_M038_B_P> UnitDetails { get; set; }
        public List<ZADM_M013_P> machineDetails { get; set; }
        public List<ADM_M018_P> CategoryDetails { get; set; }
        public List<ADM_M019_P> SubCategoryDetails { get; set; }
        public List<ADM_M015_P> ItemTyDetails { get; set; }
        public List<ADM_M016_P> SubItemTyDetails { get; set; }
        public List<ZADM_M004_P> WireTypeDetails { get; set; }
        public List<ZADM_M002_P> BallTypeDetails { get; set; }
        public List<ZADM_M007_P> ILDDetails { get; set; }
        public List<ZADM_M006_P> InkDetails { get; set; }
        public List<ADM_M042_P> ShiftDetails { get; set; }
        public List<ADM_M045_P> GradeDetails { get; set; }
        public List<ACC_M013_P> FormTyDetails { get; set; }
        public List<SEL_T001_P> SalesTyDetails { get; set; }
        public List<Rpt_MIS_Periodic1> RptGoodsIssueList { get; set; }
        public List<ADM_M002_P> CompanyList { get; set; }
        public List<ADM_M003_P> LoacationList { get; set; }
        public List<ZSCM_T001_A_P> AvgWeightList { get; set; }

    }
}
