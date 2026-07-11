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
using Reflection.EF.Finance;

namespace Reflection.BusinessLogic
{
    public class MIS_Finance_DayBook_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        public MIS_Finance_DayBook_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_Finance_DayBook_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {
            MultipleContextMIS_Finance_DayBook MC = new MultipleContextMIS_Finance_DayBook();
            MultipleContextMIS_Finance_DayBook MCTemp = new MultipleContextMIS_Finance_DayBook();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MIS_Finance_DayBook", new { @request = strType }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _AccGroupList = reader.Read<ACC_M003_A_P>().ToList();
                        MC.AccGroupList = _AccGroupList.ToList();

                        var _AccLedgerList = reader.Read<ACC_M003_P>().ToList();
                        MC.AccLedgerList = _AccLedgerList.ToList();

                        var _DocCategoryList = reader.Read<SYS_M014_P>().ToList();
                        MC.DocCategoryList = _DocCategoryList.ToList();

                        var _LocationList = reader.Read<ADM_M003_P>().ToList();
                        MC.LocationList = _LocationList.ToList();

                        var _CompanyList = reader.Read<ADM_M002_P>().ToList();
                        MC.CompanyList = _CompanyList.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "DayBookReport")
                    {
                        var _DayBookList = reader.Read<MIS_LedgerReport>().ToList();
                        MC.DayBookList = _DayBookList.ToList();

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

        public class MultipleContextMIS_Finance_DayBook
        {
            public List<MIS_LedgerReport> DayBookList { get; set; }
            public List<ACC_M003_A_P> AccGroupList { get; set; }
            public List<ACC_M003_P> AccLedgerList { get; set; }
            public List<SYS_M014_P> DocCategoryList { get; set; }
            public List<ADM_M003_P> LocationList { get; set; }
            public List<ADM_M002_P> CompanyList { get; set; }
        }
    }
}
