using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using Reflection.EF.Admin;
using System.Data;
using Dapper;
using Reflection.EF.General;

namespace Reflection.BusinessLogic
{
    public class REF_T001BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        REF_T001 objREF_T001 = new REF_T001();
        List<REF_T001> listLogData = new List<REF_T001>();

        public REF_T001BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public REF_T001BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            return "";
        }
        public string Update(string Request)
        {
            return "";
        }
        public string Delete(string Request)
        {
            return "";
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("Get_TS_Code_info", new { @request = strValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        
                    }
                    else if (RequestOption == "LoggingData")
                    {
                        var logData = reader.Read<REF_T001>().ToList();
                        listLogData = logData.ToList();
                    }
                    string strData = ObjectSerializationService.ObjectToXML(listLogData);
                    return strData;
                }
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
}
