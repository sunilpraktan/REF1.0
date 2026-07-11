using Reflection.EF;
using Reflection.EF.QMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Reflection.EF.Production.ReportEntityProduction;
using Reflection.EF.Communication;
using Reflection.EF.ReflectionSystem;

namespace Reflection.BusinessLogic
{
    public class To_Be_CheckBL : ReflectionBusinessLogic
    {
        private static string connectionString;
        TO_BE_CHECK MasterEntity = new TO_BE_CHECK();

        public To_Be_CheckBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public To_Be_CheckBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_To_Be_Check MC = new MultipleContext_To_Be_Check();
            string RequestOption = strValue.Split('!')[0];

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("TO_BE_CHECK_LoadAll", new { @request = strValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var doc_typeList = reader.Read<SYS_M013>().ToList();
                        MC.doc_typeList = doc_typeList.ToList();

                        var masterEntity = reader.Read<TO_BE_CHECK>().ToList();
                        MC.MasterEntity = masterEntity.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    if (RequestOption == "LoadInitialDataPending")
                    {
                        var masterEntity = reader.Read<TO_BE_CHECK>().ToList();
                        MC.MasterEntity = masterEntity.ToList();

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
    public class MultipleContext_To_Be_Check
    {
        
        public List<SYS_M013> doc_typeList { get; set; }
        public List<TO_BE_CHECK> MasterEntity { get; set; }
       
    }
}
