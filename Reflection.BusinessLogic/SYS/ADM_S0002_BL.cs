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
    class ADM_S0002_BL : ReflectionBusinessLogic
    {
        MC_SYS_BE MC = new MC_SYS_BE();
        SYS_AUTH MASTER_OBJ = new SYS_AUTH();
        public ADM_S0002_BL()
        { }

        public string GetData(string Request, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = Request.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_S0011_GET", new { @request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.ROLE_LIST = reader.Read<SYS_AUTH>().ToList();
                        MC.TS_CODE_LIST = reader.Read<SYS_AUTH>().ToList();
                        MC.STD_AUTH_LIST = reader.Read<SYS_AUTH>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                    }
                    if (RequestOption == "LOAD_DOCUMENT")
                    {
                        MC.ROLE_LIST = reader.Read<SYS_AUTH>().ToList();
                        MC.ROLE_TSCODE_LIST = reader.Read<SYS_AUTH>().ToList();
                        MC.TSCODE_AUTH_LIST = reader.Read<SYS_AUTH>().ToList();
                    }
                    else if (RequestOption == "REPORT")
                    {
                        MC.STD_AUTH_LIST = reader.Read<SYS_AUTH>().ToList();
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
                    var reader = conn.QueryMultiple("ADM_S0011_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.ROLE_LIST = reader.Read<SYS_AUTH>().ToList();
                    if (MC.ROLE_LIST.Count > 0)
                    {
                        MASTER_OBJ = MC.ROLE_LIST[0];
                    }
                    MC.ROLE_TSCODE_LIST = reader.Read<SYS_AUTH>().ToList();
                    MC.TSCODE_AUTH_LIST = reader.Read<SYS_AUTH>().ToList();

                    MASTER_OBJ.XML_DOC_A = ObjectSerializationService.ObjectToXML(MC.ROLE_TSCODE_LIST);
                    MASTER_OBJ.XML_DOC_B = ObjectSerializationService.ObjectToXML(MC.TSCODE_AUTH_LIST);
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
                    var reader = conn.QueryMultiple("ADM_S0011_UPD", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.ROLE_LIST = reader.Read<SYS_AUTH>().ToList();
                    if (MC.ROLE_LIST.Count > 0)
                    {
                        MASTER_OBJ = MC.ROLE_LIST[0];
                    }
                    MC.ROLE_TSCODE_LIST = reader.Read<SYS_AUTH>().ToList();

                    MASTER_OBJ.XML_DOC_A = ObjectSerializationService.ObjectToXML(MC.ROLE_TSCODE_LIST);
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
