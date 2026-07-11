using Dapper;
using Reflection.EF;
using Reflection.EF.CRM.ReportEntityCRM;
using Reflection.EF.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class MIS_CRMSalesReport6_BL : ReflectionBusinessLogic
    {
        MultipleContext_MIS_CRM_Sales6 MC = new MultipleContext_MIS_CRM_Sales6();
        private static string ConnectionString;
        public MIS_CRMSalesReport6_BL(string BusinessEntity)
        {
            ConnectionString = base.ReflectionConnectionString;
        }
        public MIS_CRMSalesReport6_BL()
        {
            ConnectionString = base.ReflectionConnectionString;
        }


        private List<MIS_CRM_SalesEntity6> _dsReport;
        public List<MIS_CRM_SalesEntity6> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_MIS_CRM_Sales6 MC = new MultipleContext_MIS_CRM_Sales6();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    var reader = conn.QueryMultiple("MIS_CRM_SalesPeriodic6", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

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

                            var GradeList = reader.Read<ADM_M045_P>().ToList();
                            MC.GradeDetails = GradeList.ToList();

                            var FormTyList = reader.Read<ACC_M013_P>().ToList();
                            MC.FormTyDetails = FormTyList.ToList();

                            var DocumentCat = reader.Read<SYS_M001_P>().ToList();
                            MC.DocumentCategory = DocumentCat.ToList();

                            //var salesOrg = reader.Read<ADM_M001_A_P>().ToList();
                            //MC.SalesOrg = salesOrg.ToList();

                            //var salesGroup = reader.Read<ADM_M001_H_P>().ToList();
                            //MC.SalesGroup = salesGroup.ToList();

                            MC.Trade_Types = reader.Read<SYS_M037>().ToList();


                            var DocumentList = reader.Read<SYS_M002_P>().ToList();
                            MC.DocumentTypes = DocumentList.ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);

                        }

                        else if (RequestOption == "Report")
                        {
                            var SalesReportDetails = reader.Read<MIS_CRM_SalesEntity6>().ToList();
                            dsReport = SalesReportDetails.ToList();
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
}
