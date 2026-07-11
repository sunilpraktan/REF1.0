using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.Admin;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    class SYS_C0101_BL : ReflectionBusinessLogic
    {
        MC_SYS_BE MC = new MC_SYS_BE();
        SYS_C0101 MASTER_OBJ = new SYS_C0101();
        public SYS_C0101_BL()
        { }

        public string GetData(string Request, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = Request.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("SYS_C0101_GET", new { @request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.DOCTYPE_LIST = reader.Read<ADM_M0010>().ToList();
                    }
                    if (RequestOption == "LOAD_DOC")
                    {
                        MC.RPT_SETTING_LIST = reader.Read<SYS_C0101>().ToList();
                    }
                    
                    ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                }
                //if (RequestOption == "LOAD_INI" || RequestOption == "REPORT")
                //{

                //}
                return ReturnValue;
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
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("SYS_C0101_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var ResultObj = reader.Read<SYS_C0101>().ToList();
                    if(ResultObj.Count > 0)
                    {
                        MASTER_OBJ = ResultObj[0];
                    }
                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MASTER_OBJ);
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
        public string Update(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("SYS_C0101_UPD", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

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
