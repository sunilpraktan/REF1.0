using Reflection.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Reflection.EF.Production.ReportEntityProduction;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class MIS_Pro_PeriodicBL : ReflectionBusinessLogic
    {
        MultipleContext_MIS_Pro_PeriodicEntity MC = new MultipleContext_MIS_Pro_PeriodicEntity();
        private static string ConnectionString;
        public MIS_Pro_PeriodicBL(string BusinessEntity)
        {
            ConnectionString = base.ReflectionConnectionString;
        }
        public MIS_Pro_PeriodicBL()
        {
            ConnectionString = base.ReflectionConnectionString;
        }
       
        private List<Rpt_MIS_Periodic1> _dsReport;
        public List<Rpt_MIS_Periodic1> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_MIS_Pro_PeriodicEntity MC = new MultipleContext_MIS_Pro_PeriodicEntity();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    var reader = conn.QueryMultiple("MIS_PRO_Periodic", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

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
                         
                            var WireTyList = reader.Read<ZADM_M004_P>().ToList();
                            MC.WireTypeDetails = WireTyList.ToList();

                            var BallTyList = reader.Read<ZADM_M002_P>().ToList();
                            MC.BallTypeDetails = BallTyList.ToList();

                            var ILDTyList = reader.Read<ZADM_M007_P>().ToList();
                            MC.ILDDetails = ILDTyList.ToList();

                            var InkList = reader.Read<ZADM_M006_P>().ToList();
                            MC.InkDetails = InkList.ToList();

                            var ShiftList = reader.Read<ADM_M042_P>().ToList();
                            MC.ShiftDetails = ShiftList.ToList();

                            var GradeList = reader.Read<ADM_M045_P>().ToList();
                            MC.GradeDetails = GradeList.ToList();

                            var FormTyList = reader.Read<ACC_M013_P>().ToList();
                            MC.FormTyDetails = FormTyList.ToList();

                            var SalesTyList = reader.Read<SEL_T001_P>().ToList();
                            MC.SalesTyDetails= SalesTyList.ToList();

                            var compList = reader.Read<ADM_M002_P>().ToList();
                            MC.CompanyList = compList.ToList();

                            var locationList = reader.Read<ADM_M003_P>().ToList();
                            MC.LoacationList = locationList.ToList();

                            var AvgWeight = reader.Read<ZSCM_T001_A_P>().ToList();
                            MC.AvgWeightList = AvgWeight.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);

                        }

                        else if (RequestOption == "Report")
                        {
                            var rptProductionList = reader.Read<Rpt_MIS_Periodic1>().ToList();
                            dsReport = rptProductionList.ToList();
                          
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
}
