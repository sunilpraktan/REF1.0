using System;
using System.Collections.Generic;
using Reflection.BusinessEntity.ReflectionSystem;

namespace Reflection.BusinessEntity.CustomerRelation
{
    public class MIS_SalesReport6 : ObjectBase
    {
        private Nullable<DateTime> _FromDate;
        public Nullable<DateTime> FromDate
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

        private Nullable<DateTime> _ToDate;
        public Nullable<DateTime> ToDate
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

        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set
            {
                if (_ItemName != value)
                {

                    _ItemName = value;
                    RaisePropertyChanged("ItemName");
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
        private string _compName;
        public string CompName
        {
            get { return _compName; }
            set
            {
                if (_compName != value)
                {
                    _compName = value;
                    RaisePropertyChanged("CompName");
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


        private string _doc_desc_user;
        public string doc_desc_user
        {
            get { return _doc_desc_user; }
            set
            {
                if (_doc_desc_user != value)
                {
                    _doc_desc_user = value;
                    RaisePropertyChanged("doc_desc_user");
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

        private string _para1;
        public string para1
        {
            get { return _para1; }
            set
            {
                if (_para1 != value)
                {
                    _para1 = value;
                    RaisePropertyChanged("para1");
                }
            }
        }

        private string _para7;
        public string para7
        {
            get { return _para7; }
            set
            {
                if (_para7 != value)
                {
                    _para7 = value;
                    RaisePropertyChanged("para7");
                }
            }
        }

        private string _para2;
        public string para2
        {
            get { return _para2; }
            set
            {
                if (_para2 != value)
                {
                    _para2 = value;
                    RaisePropertyChanged("para2");
                }
            }
        }

        private string _para3;
        public string para3
        {
            get { return _para3; }
            set
            {
                if (_para3 != value)
                {
                    _para3 = value;
                    RaisePropertyChanged("para3");
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




        private string _EmpName;
        public string EmpName
        {
            get { return _EmpName; }
            set
            {
                if (_EmpName != value)
                {
                    _EmpName = value;
                    RaisePropertyChanged("EmpName");
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
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                if (_unit_code != value)
                {
                    _unit_code = value;
                    RaisePropertyChanged("unit_code");
                }
            }
        }

        private string _unit_name;
        public string unit_name
        {
            get { return _unit_name; }
            set
            {
                if (_unit_name != value)
                {
                    _unit_name = value;
                    RaisePropertyChanged("unit_name");
                }
            }
        }


        private string _machinecode;
        public string machinecode
        {
            get { return _machinecode; }
            set
            {
                if (_machinecode != value)
                {
                    _machinecode = value;
                    RaisePropertyChanged("machinecode");
                }
            }
        }
        private int _machine_id;
        public int machine_id
        {
            get { return _machine_id; }
            set
            {
                if (_machine_id != value)
                {
                    _machine_id = value;
                    RaisePropertyChanged("machine_id");
                }
            }
        }

        private string _CatCode;
        public string CatCode
        {
            get { return _CatCode; }
            set
            {
                if (_CatCode != value)
                {
                    _CatCode = value;
                    RaisePropertyChanged("CatCode");

                }
            }
        }
        private string _CatName;
        public string CatName
        {
            get { return _CatName; }
            set
            {
                if (_CatName != value)
                {
                    _CatName = value;
                    RaisePropertyChanged("CatName");
                }
            }
        }

        private bool _active1;
        public bool active1
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



        private string _SubCatName;
        public string SubCatName
        {
            get { return _SubCatName; }
            set
            {
                if (_SubCatName != value)
                {
                    _SubCatName = value;
                    RaisePropertyChanged("SubCatName");
                }
            }
        }

        private string _SubCatCode;
        public string SubCatCode
        {
            get { return _SubCatCode; }
            set
            {
                if (_SubCatCode != value)
                {

                    _SubCatCode = value;
                    RaisePropertyChanged("SubCatCode");
                }
            }
        }


        private string _itemTypeNm;
        public string ItemTypeNm
        {
            get { return _itemTypeNm; }
            set
            {
                if (_itemTypeNm != value)
                {
                    _itemTypeNm = value;
                    RaisePropertyChanged("itemTypeNm");
                }
            }
        }
        private string _itemTypeCd;
        public string ItemTypeCd
        {
            get { return _itemTypeCd; }
            set
            {
                if (_itemTypeCd != value)
                {
                    _itemTypeCd = value;
                    RaisePropertyChanged("ItemTypeCd");
                }
            }
        }

        private string _subItemTpCd;
        public string SubItemTpCd
        {
            get { return _subItemTpCd; }
            set
            {
                if (_subItemTpCd != value)
                {
                    _subItemTpCd = value;
                    RaisePropertyChanged("SubItemTpCd");
                }
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
        private string _ind_trade;
        public string ind_trade
        {
            get { return _ind_trade; }
            set
            {
                _ind_trade = value;
                RaisePropertyChanged("ind_trade");
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

        private string _AccountType;
        public string AccountType
        {
            get { return _AccountType; }
            set
            {
                _AccountType = value;
                RaisePropertyChanged("RptFormatNm");
            }
        }

        private string _SalesType;
        public string SalesType
        {
            get { return _SalesType; }
            set
            {
                _SalesType = value;
                RaisePropertyChanged("RptFormatNm");
            }
        }
        private string _sales_org;
        public string sales_org
        {
            get
            {
                return _sales_org;
            }

            set
            {
                _sales_org = value;
                RaisePropertyChanged("sales_org");
            }
        }
        private string _sg_name;
        public string sg_name
        {
            get
            {
                return _sg_name;
            }

            set
            {
                _sg_name = value;
                RaisePropertyChanged("sg_name");
            }
        }




    }

    public class MultipleContext_MIS_CRM_Sales6
    {
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<ADM_M022_P> ItemDetails { get; set; }
        public List<ADM_M024_P> Employee { get; set; }
        public List<ADM_M038_B_P> UnitDetails { get; set; }
        public List<ADM_M018_P> CategoryDetails { get; set; }
        public List<ADM_M019_P> SubCategoryDetails { get; set; }
        public List<ADM_M015_P> ItemTyDetails { get; set; }
        public List<ADM_M016_P> SubItemTyDetails { get; set; }
        public List<ZADM_M004_P> WireTypeDetails { get; set; }
        public List<ZADM_M002_P> BallTypeDetails { get; set; }
        public List<ZADM_M007_P> ILDDetails { get; set; }
        public List<ZADM_M006_P> InkDetails { get; set; }
        public List<ADM_M045_P> GradeDetails { get; set; }
        public List<ACC_M013_P> FormTyDetails { get; set; }
        public List<SYS_M002_P> DocumentTypes { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public List<MIS_CRM_SalesEntity6> SalesReportDetails { get; set; }
        public List<SYS_M037> Trade_Types { get; set; }
        public List<SYS_M001_P> DocumentCategory { get; set; }

    }
}
