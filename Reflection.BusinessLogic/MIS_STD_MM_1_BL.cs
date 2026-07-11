using Reflection.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Reflection.EF.Production.ReportEntityProduction;
using Dapper;
using Reflection.EF.Production;
using Reflection.EF.HRMS.Production;
using Reflection.EF.ReflectionSystem;

namespace Reflection.BusinessLogic
{
    public class MIS_STD_MM_1_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        public MIS_STD_MM_1_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_STD_MM_1_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {

            STD_MC_BE MC = new STD_MC_BE();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";
            try
            {

                if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_STD_MM_1", new { @request = strType }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            MC.STD_ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                        }
                        else if (RequestOption == "Report")
                        {
                            MC.STD_MIS_LIST = reader.Read<STD_MIS_BE>().ToList();
                        }
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
}
