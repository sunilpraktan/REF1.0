using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.PMS;
using Reflection.EF.ADM;
using Reflection.EF.Admin;
using Reflection.EF.Production;
using Reflection.EF.FICO;
using Reflection.EF.Communication;
using Reflection.EF.PMM;

namespace Reflection.BusinessLogic.PMM
{
    public class PMM_M0003_BL : ReflectionBusinessLogic
    {
        STD_BE_A MasterEntity = new STD_BE_A();
        MC_GEN_BE MC = new MC_GEN_BE();
        public PMM_M0003_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("PMM_M0003_INS_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    MC.STD_ENTITY_COL = reader.Read<STD_BE_A>().ToList();
                    if (MC.STD_ENTITY_COL.Count > 0)
                    {
                        MasterEntity = MC.STD_ENTITY_COL[0];
                    }
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
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("PMM_M0003_INS_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    MC.STD_ENTITY_COL = reader.Read<STD_BE_A>().ToList();
                    if (MC.STD_ENTITY_COL.Count > 0)
                    {
                        MasterEntity = MC.STD_ENTITY_COL[0];
                    }
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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    int intOut = conn.Execute("PUR_T001_ADelete", new { @req_no = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                    return intOut.ToString();
                }

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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("PMM_M0003_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.STD_ENTITY_COL = reader.Read<STD_BE_A>().ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
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
    }
}
