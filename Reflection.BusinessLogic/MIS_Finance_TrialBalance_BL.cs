using Dapper;
using Reflection.EF;
using Reflection.EF.Finance.ReportEntityFinance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class MIS_Finance_TrialBalance_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        public MIS_Finance_TrialBalance_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_Finance_TrialBalance_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        private List<MIS_LedgerReport> _dsReport;
        public List<MIS_LedgerReport> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }

        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_MISTrialBalance MC = new MultipleContext_MISTrialBalance();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";
            try
            {

                if (RequestOption == "LoadInitialData")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_Finance_TrialBalance", new { @request = strType }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var _TrialBalanceList = reader.Read<MIS_LedgerReport>().ToList();

                            MC.TrialBalanceList = _TrialBalanceList.ToList();

                            var _CompanyList = reader.Read<ADM_M002_P>().ToList();
                            MC.CompanyList = _CompanyList.ToList();




                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
        public class MultipleContext_MISTrialBalance
        {
            public List<MIS_LedgerReport> TrialBalanceList { get; set; }
            public List<ADM_M002_P> CompanyList { get; set; }

        }
    }
}
