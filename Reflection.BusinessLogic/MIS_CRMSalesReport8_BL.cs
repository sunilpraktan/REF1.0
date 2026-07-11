using Reflection.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Reflection.EF.CRM.ReportEntityCRM;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class MIS_CRMSalesReport8_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        public MIS_CRMSalesReport8_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_CRMSalesReport8_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        MultipleContextMISReports3 MC = new MultipleContextMISReports3();
        private List<MIS_CRM_SalesEntity3> _dsReport;
        public List<MIS_CRM_SalesEntity3> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }
        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {

            MultipleContextMISReports3 MC = new MultipleContextMISReports3();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";
            try
            {

                if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_CRM_SalesPeriodic8", new { @request = strType }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var EmployeeMaster = reader.Read<ADM_M024_P>().ToList();
                            MC.EmployeeList = EmployeeMaster.ToList();

                            var partyData = reader.Read<ADM_M028_P>().ToList();
                            MC.partyDetails = partyData.ToList();

                            var ItemData = reader.Read<ADM_M022_P>().ToList();
                            MC.ItemDetails = ItemData.ToList();

                            var DocCat = reader.Read<SYS_M001_P>().ToList();
                            MC.DocCatDetails = DocCat.ToList();


                            strReturnData = ObjectSerializationService.ObjectToXML(MC);

                        }
                        else if (RequestOption == "Report")
                        {
                            var RptMIS_CRMSales3 = reader.Read<MIS_CRM_SalesEntity3>().ToList();
                            dsReport = RptMIS_CRMSales3.ToList();
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

        public class MultipleContextMISReports3
        {
            public List<ADM_M024_P> EmployeeList { get; set; }
            public List<ADM_M028_P> partyDetails { get; set; }
            public List<ADM_M022_P> ItemDetails { get; set; }
            public List<SYS_M001_P> DocCatDetails { get; set; }
            public List<ADM_M001_A_P> SalesOrg { get; set; }
            public List<ADM_M001_H_P> SalesGroup { get; set; }
            public List<MIS_CRM_SalesEntity3> RptMIS_CRMSales_List { get; set; }
            public List<ADM_M028_B_P> PartyType;



        }
    }
}
