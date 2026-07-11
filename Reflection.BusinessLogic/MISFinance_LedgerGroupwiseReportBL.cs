using System;
using System.Collections.Generic;
using Reflection.EF.Finance.ReportEntityFinance;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Data;
using Reflection.EF.Production;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class MISFinance_LedgerGroupwiseReportBL : ReflectionBusinessLogic
    {
        private static String connectionString;
        public MISFinance_LedgerGroupwiseReportBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MISFinance_LedgerGroupwiseReportBL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        MultipleContext_MISLedgerGroupwiseReport MC = new MultipleContext_MISLedgerGroupwiseReport();
        private List<MIS_LedgerReport> _dsReport;
        public List<MIS_LedgerReport> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }
        private List<MIS_LedgerReport> _dsLedger;
        public List<MIS_LedgerReport> dsLedger
        {
            get { return _dsLedger; }
            set
            {
                _dsLedger = value;
            }
        }



        public string GetData(string RequestValue, string strType, int intValue, string srtValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                if (RequestOption == "LoadInitialData")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_Finance_LedgerGroupwiseReport", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                        
                            var _RptGroupWise = reader.Read<MIS_LedgerReport>().ToList();
                            MC.LedgerReportList = _RptGroupWise.ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        
                       
                    }
                    return strReturnData;
                }
                else if (RequestOption == "LoadInitialDataLedgerDetail")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_Finance_LedgerDetail", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                        var _RptLedger = reader.Read<MIS_LedgerReport>().ToList();
                        MC.LedgerReportList = _RptLedger.ToList();
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
    }

    public class MultipleContext_MISLedgerGroupwiseReport
    {
        public List<MIS_LedgerReport> LedgerReportList { get; set; }
    }
    
}
