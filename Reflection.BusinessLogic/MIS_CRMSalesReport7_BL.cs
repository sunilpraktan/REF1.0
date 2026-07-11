using Dapper;
using Reflection.EF;
using Reflection.EF.CRM.ReportEntityCRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
   public class MIS_CRMSalesReport7_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        public MIS_CRMSalesReport7_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_CRMSalesReport7_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        MultipleContextMISReports7 MC = new MultipleContextMISReports7();
        private List<MIS_CRM_SalesEntity7> _dsReport;
        public List<MIS_CRM_SalesEntity7> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }
        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {
            MultipleContextMISReports7 MC = new MultipleContextMISReports7();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";
            try
            {

                if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_CRM_SalesPeriodic7", new { @request = strType }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            
                            var partyData = reader.Read<ADM_M028_P>().ToList();
                            MC.partyDetails = partyData.ToList();

                            
                            var ItemData = reader.Read<ADM_M022_P>().ToList();
                            MC.ItemDetails = ItemData.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);

                        }
                        else if (RequestOption == "Report")
                        {
                            var RptMIS_CRMSales7 = reader.Read<MIS_CRM_SalesEntity7>().ToList();
                            dsReport = RptMIS_CRMSales7.ToList();
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
        public class MultipleContextMISReports7
        {
            public List<ADM_M028_P> partyDetails { get; set; }
            public List<ADM_M022_P> ItemDetails { get; set; }
            public List<ADM_M024_P> Employee { get; set; }
            public List<MIS_CRM_SalesEntity7> RptMIS_CRMSales_List { get; set; }

            public List<ADM_M028_B_P> PartyType;

        }
    }
}
