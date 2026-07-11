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
    public class PMS_T008_BL : ReflectionBusinessLogic
    {
        EPR_T001 MasterEntity = new EPR_T001();
        MC_PMS_BE MC = new MC_PMS_BE();
        public PMS_T008_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T001_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    MC.TASK_LIST = reader.Read<EPR_T001>().ToList();
                    if (MC.TASK_LIST.Count > 0)
                    {
                        MasterEntity = MC.TASK_LIST[0];
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
                    var reader = conn.QueryMultiple("EPR_T001_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    MC.TASK_LIST = reader.Read<EPR_T001>().ToList();
                    if (MC.TASK_LIST.Count > 0)
                    {
                        MasterEntity = MC.TASK_LIST[0];
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
                    var reader = conn.QueryMultiple("EPR_T001_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI_TASK")
                    {
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        MC.COST_CENTER_LIST = reader.Read<FICO_M0019>().ToList();
                        MC.PROFIT_CENTER_LIST = reader.Read<FICO_M0020>().ToList();
                        //MC.PHASE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        //MC.TASK_STD_LIST = reader.Read<STD_LIST_BE>().ToList();

                        //Load from sub SP result
                        MC.ELEMENT_LIST = reader.Read<PMS_T002>().ToList();
                        MC.SCHEDULE_LIST = reader.Read<PMS_T006>().ToList();
                        
                        

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LOAD_TASK")
                    {
                        MC.TASK_LIST = reader.Read<EPR_T001>().ToList();
                    }
                    
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.TASK_LIST = reader.Read<EPR_T001>().ToList();
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
