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

namespace Reflection.BusinessLogic.PMS
{
    public class PMS_T004_BL : ReflectionBusinessLogic
    {
        PMS_T004 MasterEntity = new PMS_T004();
        MC_PMS_BE MC = new MC_PMS_BE();
        public PMS_T004_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("PMS_T004_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    MC.MILESTONE_LIST = reader.Read<PMS_T004>().ToList();
                    if (MC.MILESTONE_LIST.Count > 0)
                    {
                        MasterEntity = MC.MILESTONE_LIST[0];
                    }

                    //MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Details);
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
                    var reader = conn.QueryMultiple("PMS_T004_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    MC.MILESTONE_LIST = reader.Read<PMS_T004>().ToList();
                    if (MC.MILESTONE_LIST.Count > 0)
                    {
                        MasterEntity = MC.MILESTONE_LIST[0];
                    }

                    //MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Details);
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
                    var reader = conn.QueryMultiple("PMS_T004_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.MILESTONE_LIST = reader.Read<PMS_T004>().ToList();
                        MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList();
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
