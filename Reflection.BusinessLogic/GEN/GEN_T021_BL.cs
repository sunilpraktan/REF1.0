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
using Reflection.EF.Admin;
using Reflection.EF.COM;
using Reflection.EF.Communication;
using Reflection.EF.Procurement;

namespace Reflection.BusinessLogic.GEN
{
    public class GEN_T021_BL : ReflectionBusinessLogic
    {
        STD_MC_BE MC = new STD_MC_BE();
        public GEN_T021_BL()
        {
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            try
            {
                string RequestOption = RequestValue.Split('!')[0];

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("GEN_T021_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_DOCUMENT") 
                    {
                        MC.GEN_CHAR_VALUE_LIST = reader.Read<GEN_T021>().ToList();
                    }
                }
                return ObjectSerializationService.ObjectToXML(MC);
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

        public string Insert(string Request)
        {
            try
            {
                MC = (STD_MC_BE)ObjectSerializationService.XMLToObject(Request, MC);
                MC.request = ObjectSerializationService.ObjectToXML(MC.GEN_CHAR_VALUE_LIST);

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("GEN_T021_INS", new { @Request = MC.request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.GEN_CHAR_VALUE_LIST = reader.Read<GEN_T021>().ToList();

                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                return ReturnValue;
            }
            catch (SqlException ex)
            {
                throw new CreateException(ex.ErrorCode, ex.Message, ex);
            }
            catch (CreateException ex)
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
