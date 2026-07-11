using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.GEN;
using Reflection.EF.FICO;
using Reflection.EF.General;
using System.Collections.Generic;

namespace Reflection.BusinessLogic.GEN
{
    public class REF_T001_BL : ReflectionBusinessLogic
    {
        REF_T001 MasterEntity = new REF_T001();
        List<REF_T001> MasterList = new List<REF_T001>();
        MC_REF_T001 MC = new MC_REF_T001();
        public REF_T001_BL()
        {
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            try
            {
                string RequestOption = RequestValue.Split('!')[0];

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("REF_T001_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "GET_TSCODE" || RequestOption == "VIEW_DOC") // NOTE: remove any one which is not proper
                    {
                        MasterList = reader.Read<REF_T001>().ToList();
                    }
                }
                return ObjectSerializationService.ObjectToXML(MasterList);
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
