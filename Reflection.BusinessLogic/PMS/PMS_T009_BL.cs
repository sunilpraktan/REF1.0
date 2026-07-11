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
using Reflection.EF.HRMS.Production;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic.PMS
{
    public class PMS_T009_BL : ReflectionBusinessLogic
    {
        EPR_T001 OrderEntity = new EPR_T001();
        EPR_T001_A MasterEntity = new EPR_T001_A();
        MC_PMS_BE MC = new MC_PMS_BE();
        public PMS_T009_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T001_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                    //MC.TASK_LIST = reader.Read<EPR_T001>().ToList();
                    //MC.ACTIVITY_LIST = reader.Read<EPR_T001_A>().ToList();
                    //MC.ACTIVITY_DATES_LIST = reader.Read<EPR_T001_B>().ToList();
                    //MC.DEPENDENCY_LIST = reader.Read<EPR_T001_C>().ToList();
                    if (MC.TASK_LIST.Count > 0)
                    {
                        OrderEntity = MC.TASK_LIST[0];
                    }
                    if (MC.ACTIVITY_LIST.Count > 0)
                    {
                        OrderEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ACTIVITY_LIST);
                    }
                    if (MC.ACTIVITY_DATES_LIST.Count > 0)
                    {
                        OrderEntity.XDOC_B = ObjectSerializationService.ObjectToXML(MC.ACTIVITY_DATES_LIST);
                    }
                    if (MC.DEPENDENCY_LIST.Count > 0)
                    {
                        OrderEntity.XDOC_C = ObjectSerializationService.ObjectToXML(MC.DEPENDENCY_LIST);
                    }
                }
                ReturnValue = ObjectSerializationService.ObjectToXML(OrderEntity);
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
                    MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList();
                    MC.ACTIVITY_LIST = reader.Read<EPR_T001_A>().ToList();
                    MC.ACTIVITY_DATES_LIST = reader.Read<EPR_T001_B>().ToList();
                    MC.DEPENDENCY_LIST = reader.Read<EPR_T001_C>().ToList();
                    if (MC.TASK_LIST.Count > 0)
                    {
                        OrderEntity = MC.TASK_LIST[0];
                    }
                    if (MC.ACTIVITY_LIST.Count > 0)
                    {
                        OrderEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ACTIVITY_LIST);
                    }
                    if (MC.ACTIVITY_DATES_LIST.Count > 0)
                    {
                        OrderEntity.XDOC_B = ObjectSerializationService.ObjectToXML(MC.ACTIVITY_DATES_LIST);
                    }
                    if (MC.DEPENDENCY_LIST.Count > 0)
                    {
                        OrderEntity.XDOC_C = ObjectSerializationService.ObjectToXML(MC.DEPENDENCY_LIST);
                    }

                }
                ReturnValue = ObjectSerializationService.ObjectToXML(OrderEntity);
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

                    if (RequestOption == "LOAD_INI_ACTIVITY")
                    {
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        MC.COST_CENTER_LIST = reader.Read<FICO_M0019>().ToList();
                        MC.PROFIT_CENTER_LIST = reader.Read<FICO_M0020>().ToList();
                        MC.WC_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.CONTROL_KEY_LIST = reader.Read<SYS_M051>().ToList();
                        MC.OPERATION_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.PRIORITY_LIST = reader.Read<ADM_M0040>().ToList();
                        MC.TASK_LIST = reader.Read<EPR_T001>().ToList();
                        MC.ACTIVITY_LIST = reader.Read<EPR_T001_A>().ToList();
                        MC.ACTIVITY_DATES_LIST = reader.Read<EPR_T001_B>().ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LOAD_ACTIVITY")
                    {
                        MC.ACTIVITY_LIST = reader.Read<EPR_T001_A>().ToList();
                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.TASK_LIST = reader.Read<EPR_T001>().ToList();
                        MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList(); // on second order because PMS_T008_BL have same section with less result. so made top 2 as common result.
                        MC.ACTIVITY_LIST = reader.Read<EPR_T001_A>().ToList();
                        MC.ACTIVITY_DATES_LIST = reader.Read<EPR_T001_B>().ToList();
                        MC.DEPENDENCY_LIST = reader.Read<EPR_T001_C>().ToList();
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
