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
    public class MIS_Finance_LedgerGroupwiseReportBL : ReflectionBusinessLogic
    {
        private static String connectionString;
        public MIS_Finance_LedgerGroupwiseReportBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_Finance_LedgerGroupwiseReportBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        MultipleContextMIS_FinanceLedgerReport MC = new MultipleContextMIS_FinanceLedgerReport();
        private List<MIS_LedgerReport> _dsReport;
        public List<MIS_LedgerReport> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
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
                    return strReturnData;
                }
                else if (RequestOption == "SubLedgerReport")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_Finance_LedgerDetail", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                        var _RptLedger = reader.Read<MIS_LedgerReport>().ToList();
                        MC.LedgerReportList = _RptLedger.ToList();
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    return strReturnData;
                }
                else if (RequestOption == "LoadInitialDataGroupReport")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_Finance_GroupReport", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

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
        public class MultipleContextMIS_FinanceLedgerReport
        {
            public List<MIS_LedgerReport> LedgerReportList { get; set; }
            public List<ACC_M003_A_P> AccGroupList { get; set; }
            public List<ACC_M003_P> AccLedgerList { get; set; }
        }
    }
   
}
