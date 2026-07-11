using Reflection.BusinessEntity.SCM;
using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class RequestParameters : ObjectBase // NOTE: Make this call static so that no instance required in each VM.
    {
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

        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set
            {
                _location_id = value;
                RaisePropertyChanged("location_id");
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
        private string _location;
        public string location
        {
            get { return _location; }
            set
            {
                _location = value;
                RaisePropertyChanged("location");
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
        private string _comp_name;
        public string comp_name
        {
            get { return _comp_name; }
            set
            {
                _comp_name = value;
                RaisePropertyChanged("comp_name");
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
        private string _doc_type_user;
        public string doc_type_user
        {
            get { return _doc_type_user; }
            set
            {
                _doc_type_user = value;
                RaisePropertyChanged("doc_type_user");
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
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set
            {
                _t_display = value;
                RaisePropertyChanged("t_display");
            }
        }

        private string _emp_name;
        public string emp_name
        {
            get { return _emp_name; }
            set
            {
                _emp_name = value;
                RaisePropertyChanged("emp_name");
            }
        }

        private string _emp_id;
        public string emp_id //EmpId
        {
            get { return _emp_id; }
            set
            {
                _emp_id = value;
                RaisePropertyChanged("emp_id");
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

        private string _wc_code;
        public string wc_code
        {
            get { return _wc_code; }
            set
            {
                _wc_code = value;
                RaisePropertyChanged("wc_code");
            }
        }

        private string _cat_code;
        public string cat_code
        {
            get { return _cat_code; }
            set
            {
                _cat_code = value;
                RaisePropertyChanged("cat_code");
            }
        }
        private string _cat_name;
        public string cat_name
        {
            get { return _cat_name; }
            set
            {
                _cat_name = value;
                RaisePropertyChanged("cat_name");
            }
        }

        private string _sub_cat_name;
        public string sub_cat_name
        {
            get { return _sub_cat_name; }
            set
            {
                _sub_cat_name = value;
                RaisePropertyChanged("sub_cat_name");
            }
        }

        private string _sub_cat_code;
        public string sub_cat_code
        {
            get { return _sub_cat_code; }
            set
            {
                _sub_cat_code = value;
                RaisePropertyChanged("sub_cat_code");
            }
        }

        private string _item_type_name;
        public string item_type_name
        {
            get { return _item_type_name; }
            set
            {
                _item_type_name = value;
                RaisePropertyChanged("item_type_name");
            }
        }
        private string _user_id;
        public string user_id
        {
            get { return _user_id; }
            set
            {
                _user_id = value;
                RaisePropertyChanged("user_id");
            }
        }
        private string _item_type_code;
        public string item_type_code
        {
            get { return _item_type_code; }
            set
            {
                _item_type_code = value;
                RaisePropertyChanged("item_type_code");
            }
        }

        private string _sub_item_type_code;
        public string sub_item_type_code
        {
            get { return _sub_item_type_code; }
            set
            {
                _sub_item_type_code = value;
                RaisePropertyChanged("sub_item_type_code");
            }
        }
        private string _sub_item_type_name;
        public string sub_item_type_name
        {
            get { return _sub_item_type_name; }
            set
            {
                _sub_item_type_name = value;
                RaisePropertyChanged("sub_item_type_name");
            }
        }

        private string _report_type;
        public string report_type
        {
            get { return _report_type; }
            set
            {
                _report_type = value;
                RaisePropertyChanged("report_type");
            }
        }

        private string _order_by;
        public string order_by
        {
            get { return _order_by; }
            set
            {
                _order_by = value;
                RaisePropertyChanged("order_by");
            }
        }

        private bool _select;
        public bool select
        {
            get { return _select; }
            set
            {
                if (_select != value)
                {
                    _select = value;
                    RaisePropertyChanged("select");
                }
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

        private string _org_code;
        public string org_code
        {
            get { return _org_code; }
            set
            {
                _org_code = value;
                RaisePropertyChanged("org_code");
            }
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
        private string _From;
        public string From
        {
            get { return _From; }
            set
            {
                _From = value;
                RaisePropertyChanged("From");
            }
        }
        private string _To;
        public string To
        {
            get { return _To; }
            set
            {
                _To = value;
                RaisePropertyChanged("To");
            }
        }
        private Nullable<bool> _Customer;
        public Nullable<bool> Customer
        {
            get { return _Customer; }
            set
            {
                _Customer = value;
                RaisePropertyChanged("Customer");
            }
        }
        private Nullable<bool> _Supplier;
        public Nullable<bool> Supplier
        {
            get { return _Supplier; }
            set { _Supplier = value; RaisePropertyChanged("Supplier"); }
        }

    }
    public class ReportParameters : ObjectBase
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

        private string _Grap_Type;
        public string Grap_Type
        {
            get { return _Grap_Type; }
            set
            {
                _Grap_Type = value;
                RaisePropertyChanged("Grap_Type");
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



    }



    //Added by Priya
    public class MultipleContext_MIS_SCM_Report1
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
        public List<MIS_SCM_ReportEntity> RptGoodsIssueList { get; set; }
        public List<ADM_M031_P> ParameterList { get; set; }
        public List<ADM_M030_P> ParamValueList { get; set; }
        public List<ADM_M025_P> DepartmentDetails { get; set; }




    }
}
