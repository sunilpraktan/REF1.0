using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.Admin;
using Reflection.EF.ADM;
using System.Collections.Generic;

namespace Reflection.BusinessLogic
{
    class ADM_S0001_BL : ReflectionBusinessLogic
    {
        MC_SYS_BE MC = new MC_SYS_BE();
        SYS_AUTH MasterEntity = new SYS_AUTH();

        public ADM_S0001_BL()
        { }

        public string GetData(string Request, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = Request.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_S0001_GET", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.USER_LIST = reader.Read<SYS_AUTH>().ToList();
                        MC.USER_TYPE_LIST = reader.Read<SYS_AUTH>().ToList();
                        MC.ROLE_LIST = reader.Read<SYS_AUTH>().ToList();
                        MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.USER_LIST = reader.Read<SYS_AUTH>().ToList();
                        MC.ROLE_USER_LIST = reader.Read<SYS_AUTH>().ToList();
                    }

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                }

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
                MasterEntity = (SYS_AUTH)ObjectSerializationService.XMLToObject(Request, MasterEntity);
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_S0001_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    List<SYS_AUTH> MasterEntityList = reader.Read<SYS_AUTH>().ToList();
                    if (MasterEntityList.Count > 0)
                    {
                        MasterEntity = MasterEntityList[0];
                    }
                    MC.ROLE_TSCODE_LIST = reader.Read<SYS_AUTH>().ToList();
                    MasterEntity.XML_DOC_A = ObjectSerializationService.ObjectToXML(MC.ROLE_TSCODE_LIST);
                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MasterEntity);
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
                MasterEntity = (SYS_AUTH)ObjectSerializationService.XMLToObject(Request, MasterEntity);
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_S0001_UPD", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    List<SYS_AUTH> MasterEntityList = reader.Read<SYS_AUTH>().ToList();
                    if (MasterEntityList.Count > 0)
                    {
                        MasterEntity = MasterEntityList[0];
                    }
                    MC.ROLE_TSCODE_LIST = reader.Read<SYS_AUTH>().ToList();
                    MasterEntity.XML_DOC_A = ObjectSerializationService.ObjectToXML(MC.ROLE_TSCODE_LIST);
                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MasterEntity);
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
