using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Reflection.EF;
using Reflection.EF.Finance.ReportEntityFinance;
using System.Data;
using System.Data.SqlClient;

namespace Reflection.BusinessLogic
{
    public class MIS_Finance_ProfitAndLoss_BL : ReflectionBusinessLogic
    {

        private static string connectionString;
        public MIS_Finance_ProfitAndLoss_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_Finance_ProfitAndLoss_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_MIS_ProfitAndLoss MC = new MultipleContext_MIS_ProfitAndLoss();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {

                    var reader = conn.QueryMultiple("MIS_Finance_ProfitLossReport", new { @request = strType }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _CompanyList = reader.Read<ADM_M002_P>().ToList();
                        MC.CompanyList = _CompanyList.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadProfitLossData")
                    {
                        var _ProfitLossList = reader.Read<MIS_LedgerReport>().ToList();

                        MC.ProfitLossList = _ProfitLossList.ToList();
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

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
        public class MultipleContext_MIS_ProfitAndLoss
        {
            public List<MIS_LedgerReport> ProfitLossList { get; set; }

            public List<ADM_M002_P> CompanyList { get; set; }
           

        }

    }
}
