using Reflection.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Reflection.BusinessEntity.SCM;

namespace Reflection.BusinessLogic
{
    public class MIS_SCM_Report3BL : ReflectionBusinessLogic
    {
        MultipleContext_MIS_SCM_Report1 MC = new MultipleContext_MIS_SCM_Report1();
        private static string ConnectionString;
        public MIS_SCM_Report3BL(string BusinessEntity)
        {
            ConnectionString = base.ReflectionConnectionString;
        }
        public MIS_SCM_Report3BL()
        {
            ConnectionString = base.ReflectionConnectionString;
        }


        private List<MIS_SCM_ReportEntity> _dsReport;
        public List<MIS_SCM_ReportEntity> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_MIS_SCM_Report1 MC = new MultipleContext_MIS_SCM_Report1();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    var reader = conn.QueryMultiple("MIS_SCM_Report3", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var PartyList = reader.Read<ADM_M028_P>().ToList();
                            MC.PartyMaster = PartyList.ToList();

                            var ItemList = reader.Read<ADM_M022_P>().ToList();
                            MC.ItemDetails = ItemList.ToList();

                            var EmployeeList = reader.Read<ADM_M024_P>().ToList();
                            MC.Employee = EmployeeList.ToList();

                            var UnitList = reader.Read<ADM_M038_B_P>().ToList();
                            MC.UnitDetails = UnitList.ToList();

                            var MachineList = reader.Read<ZADM_M013_P>().ToList();
                            MC.machineDetails = MachineList.ToList();

                            var CategoryList = reader.Read<ADM_M018_P>().ToList();
                            MC.CategoryDetails = CategoryList.ToList();

                            var SubCategoryList = reader.Read<ADM_M019_P>().ToList();
                            MC.SubCategoryDetails = SubCategoryList.ToList();

                            var ItemTyList = reader.Read<ADM_M015_P>().ToList();
                            MC.ItemTyDetails = ItemTyList.ToList();

                            var SubItemTyList = reader.Read<ADM_M016_P>().ToList();
                            MC.SubItemTyDetails = SubItemTyList.ToList();

                            var parameterList = reader.Read<ADM_M031_P>().ToList();
                            MC.ParameterList = parameterList.ToList();

                            var paramValueList = reader.Read<ADM_M030_P>().ToList();
                            MC.ParamValueList = paramValueList.ToList();

                            var DeptData = reader.Read<ADM_M025_P>().ToList();
                            MC.DepartmentDetails = DeptData.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "Report")
                        {
                            var rptGoodsIssueList = reader.Read<MIS_SCM_ReportEntity>().ToList();
                            dsReport = rptGoodsIssueList.ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(dsReport);
                        }
                    }
                }
                return strReturnData;
            }
            catch (SqlException ex)
            {
                throw new CreateException(ex.ErrorCode, ex.Message, ex);
            }
            catch (DivideByZeroException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new CreateException(ex.Message, ex);
            }
        }
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
}
