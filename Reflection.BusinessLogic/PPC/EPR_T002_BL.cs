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
using System.Collections.Generic;

namespace Reflection.BusinessLogic.PMS
{
    public class EPR_T002_BL : ReflectionBusinessLogic
    {
        // SP reference : PMS_T008_BL
        EPR_T002 MasterEntity = new EPR_T002();
        MC_PPC_BE MC = new MC_PPC_BE();
        List<EPR_T002> MasterEntityList = new List<EPR_T002>();
        public EPR_T002_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    
                    var reader = conn.QueryMultiple("EPR_T002_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                    MasterEntityList = reader.Read<EPR_T002>().ToList();
                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MasterEntityList);
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
                    var reader = conn.QueryMultiple("EPR_T002_UPD", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                    MasterEntityList = reader.Read<EPR_T002>().ToList();
                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MasterEntityList);
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
                    int intOut = conn.Execute("EPR_T001_DEL", new { @req_no = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
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
                    var reader = conn.QueryMultiple("EPR_T002_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI_PMS_SINGLE")
                    {
                        MC.BATCH_CODE_LIST = reader.Read<STD_LIST_BE>().ToList(); // Barcode/Batchcode list
                        MC.ORDER_LIST = reader.Read<EPR_T001>().ToList();
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        MC.DOC_TYPE_SETTINGS_LIST = reader.Read<STD_DOC_TYPE_SETTINGS>().ToList();
                        MC.RECORD_TYPE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.REASON_LIST = reader.Read<STD_LIST_BE>().ToList(); // Var Reason List
                        MC.TYPE_LIST = reader.Read<STD_LIST_BE>().ToList(); // Confirmation Type List
                        MC.WC_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.SHIFT_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.NOTIFICATION_LIST = reader.Read<NotificationData>().ToList();

                    }
                    else if (RequestOption == "LOAD_INI_FAST") // NOTE: we can club with above if any logic
                    {
                        MC.ORDER_LIST = reader.Read<EPR_T001>().ToList();
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        MC.DOC_TYPE_SETTINGS_LIST = reader.Read<STD_DOC_TYPE_SETTINGS>().ToList();
                        MC.RECORD_TYPE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.REASON_LIST = reader.Read<STD_LIST_BE>().ToList(); // Var Reason List
                        MC.TYPE_LIST = reader.Read<STD_LIST_BE>().ToList(); // Confirmation Type List
                        MC.WC_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.SHIFT_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.NOTIFICATION_LIST = reader.Read<NotificationData>().ToList();
                    }
                    else if(RequestOption == "EXECUTE_REFERENCE_PMS_ORDER")
                    {
                        MC.OPERATION_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.DEPENDENCY_LIST = reader.Read<EPR_T001_C>().ToList();
                    }
                    if (RequestOption == "EXECUTE_REFERENCE_ORDER")
                    {
                        MC.ORDER_LIST = reader.Read<EPR_T001>().ToList();
                        MC.OPERATION_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    if (RequestOption == "BARCODE_SCAN")
                    {
                        MC.CONFIRMATION_LIST = reader.Read<EPR_T002>().ToList();
                        MC.OPERATION_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.ORDER_LIST = reader.Read<EPR_T001>().ToList();
                        MC.DEPENDENCY_LIST = reader.Read<EPR_T001_C>().ToList();
                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO" || RequestOption == "EXECUTE_ORDER_BY_OPNO")
                    {
                        MC.CONFIRMATION_LIST = reader.Read<EPR_T002>().ToList();
                    }
                    else if (RequestOption == "LOAD_BACKFLIP")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "LOAD_INI")
                    {
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        MC.COST_CENTER_LIST = reader.Read<FICO_M0019>().ToList();
                        MC.PROFIT_CENTER_LIST = reader.Read<FICO_M0020>().ToList();
                    }
                    
                    ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    MC = null;
                    reader.Dispose(); //CRITICAL NOTE: this is for testing OutOfMemoryException


                }
                return ReturnValue;
            }
            catch (SqlException ex)
            {
                throw new CreateException(ex.ErrorCode, ex.Message, ex);
            }
            catch (OutOfMemoryException ex) //CRITICAL NOTE: this is for testing OutOfMemoryException
            {
                throw new CreateException(ex.Message, ex);
            }
            catch (DivideByZeroException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            finally //CRITICAL NOTE: this is for testing OutOfMemoryException
            {
                ReturnValue = null;
            }


        }
    }
}
