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
using Reflection.EF.MM;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.Communication;
using Reflection.EF.GEN;

namespace Reflection.BusinessLogic.PPC
{
    public class EPR_T001_BL : ReflectionBusinessLogic
    {
        // SP reference : PMS_T008_BL
        EPR_T001 MasterEntity = new EPR_T001();
        MC_PPC_BE MC = new MC_PPC_BE();

        //MC_PMS_BE MC = new MC_PMS_BE();

        public EPR_T001_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T001_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                    MC.MasterEntity = reader.Read<EPR_T001>().ToList();
                    MC.OperationEntity = reader.Read<EPR_T001_A>().ToList();
                    MC.OperatopnDatesEntity = reader.Read<EPR_T001_B>().ToList();
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }
                    if (MC.OperationEntity.Count > 0)
                    {
                        MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.OperationEntity);
                    }
                    if (MC.OperatopnDatesEntity.Count > 0)
                    {
                        MasterEntity.XDOC_B = ObjectSerializationService.ObjectToXML(MC.OperatopnDatesEntity);
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

                    MC.MasterEntity = reader.Read<EPR_T001>().ToList();
                    MC.OperationEntity = reader.Read<EPR_T001_A>().ToList();
                    MC.OperatopnDatesEntity = reader.Read<EPR_T001_B>().ToList();
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }
                    if (MC.OperationEntity.Count > 0)
                    {
                        MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.OperationEntity);
                    }
                    if (MC.OperatopnDatesEntity.Count > 0)
                    {
                        MasterEntity.XDOC_B = ObjectSerializationService.ObjectToXML(MC.OperatopnDatesEntity);
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T001_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                   
                    if (RequestOption == "LOAD_INI_PPC")
                    {
                        MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.DOC_TYPE_LIST_NEW = reader.Read<ADM_M0010>().ToList();
                        MC.STD_ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.SHIFT_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.COST_CENTER_LIST = reader.Read<FICO_M0019>().ToList();
                        MC.PROFIT_CENTER_LIST = reader.Read<FICO_M0020>().ToList();
                        MC.STORE_LIST = reader.Read<MM_M0001>().ToList();
                        MC.WC_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.CONTROL_KEY_LIST = reader.Read<SYS_M051>().ToList();
                        MC.OPERATION_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.METHOD_LIST = reader.Read<STD_LIST_BE>().ToList(); // Inspection Method
                        MC.COMON_LIST = reader.Read<STD_LIST_BE>().ToList(); // Comunication Method
                        MC.NOTIFICATION_LIST = reader.Read<NotificationData>().ToList();
                        MC.GEN_CHAR_VALUE_LIST = reader.Read<GEN_T021>().ToList();
                        MC.CLASS_PROFILE_LIST = reader.Read<Classification>().ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LOAD_DOC_PPC_PMM")
                    {
                        MC.ORDER_LIST = reader.Read<EPR_T001>().ToList();
                        MC.OperationEntity = reader.Read<EPR_T001_A>().ToList();
                        MC.ACTIVITY_DATES_LIST = reader.Read<EPR_T001_B>().ToList();
                        MC.ROUTING_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.BOM_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.ApprovalData = reader.Read<ADM_M043_D>().ToList();
                        // Load document for Customer Servicablemateria order like Rapaire & maintantance or Calibration Testing
                        MC.SO_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.SO_ITEM_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.QN_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.SN_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.GM_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.EQUIPMENT_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.PMM_LIST = reader.Read<STD_LIST_BE>().ToList(); // Previous Maintainance & Calibration History, latest would be prefer to set last data and number of calibration document.
                        MC.DN_LIST = reader.Read<STD_LIST_BE>().ToList(); // Delivery details of customer equipment sent for the order.
                        MC.INVOICE_LIST = reader.Read<STD_LIST_BE>().ToList(); // Billing details for the order
                        MC.ASSET_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList();
                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.ORDER_LIST = reader.Read<EPR_T001>().ToList();
                        MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList(); // on second order because PMS_T008_BL have same section with less result. so made top 2 as common result.
                        MC.OperationEntity = reader.Read<EPR_T001_A>().ToList();
                        MC.ACTIVITY_DATES_LIST = reader.Read<EPR_T001_B>().ToList();
                    }
                    else if (RequestOption == "LoadBackFlipData")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "LoadProductionOrderChart")
                    {
                        MC.MasterEntity = reader.Read<EPR_T001>().ToList();
                    }
                    else if (RequestOption == "LoadData_For_Selected_ItemCode")
                    {
                        MC.ROUTING_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.BOM_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "Load_Operations_For_Selected_Routing")
                    {
                        MC.OperationEntity = reader.Read<EPR_T001_A>().ToList();
                    }
                    else if (RequestOption == "ORDER_HISTORY")
                    {
                        MC.STD_MIS_LIST  = reader.Read<STD_MIS_BE>().ToList();
                        MC.STD_MIS_LIST2 = reader.Read<STD_MIS_BE>().ToList();
                        MC.STD_MIS_LIST3 = reader.Read<STD_MIS_BE>().ToList();
                        MC.STD_MIS_LIST4 = reader.Read<STD_MIS_BE>().ToList();
                    }
                    else if (RequestOption == "TRACE_REPORT")
                    {
                        MC.STD_MIS_LIST = reader.Read<STD_MIS_BE>().ToList();
                    }
                    else if (RequestOption == "LOG_REPORT")
                    {
                        MC.STD_MIS_LIST = reader.Read<STD_MIS_BE>().ToList();
                    }
                    else if (RequestOption == "EXE_REF_DOC")
                    {
                        MC.MasterEntity = reader.Read<EPR_T001>().ToList();
                        MC.OperationEntity = reader.Read<EPR_T001_A>().ToList();
                        MC.ROUTING_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.BOM_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "EXECUTE_DOCUMENT")
                    {
                        MC.MasterEntity = reader.Read<EPR_T001>().ToList();
                        MC.OperationEntity = reader.Read<EPR_T001_A>().ToList();
                    }
                    else if (RequestOption == "LOAD_SO_FOR_PPC") // RM Sales order GRN for third party material for Repair, Maint & Quality services
                    {
                        MC.GRID_COLLECTION = reader.Read<STD_LIST_BE>().ToList();
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





        public string InsertOrg(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T001_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //MC.MILESTONE_LIST = reader.Read<PMS_T004>().ToList();
                    //if (MC.MILESTONE_LIST.Count > 0)
                    //{
                    //    //MasterEntity = MC.MILESTONE_LIST[0];
                    //}

                    ////MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Details);
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
        public string UpdateOrg(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("PMS_T004_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //MC.MILESTONE_LIST = reader.Read<PMS_T004>().ToList();
                    //if (MC.MILESTONE_LIST.Count > 0)
                    //{
                    //    //MasterEntity = MC.MILESTONE_LIST[0];
                    //}

                    ////MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Details);
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
        public string GetDataOrg(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T001_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                   
                    if (RequestOption == "LOAD_INI")
                    {
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        MC.COST_CENTER_LIST = reader.Read<FICO_M0019>().ToList();
                        MC.PROFIT_CENTER_LIST = reader.Read<FICO_M0020>().ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        //MC.PROJECT_LIST = reader.Read<PMS_T001>().ToList();
                        MC.ELEMENT_LIST = reader.Read<PMS_T002>().ToList();
                        //MC.MILESTONE_LIST = reader.Read<PMS_T004>().ToList();
                        //MC.TASK_LIST = reader.Read<EPR_T001>().ToList();
                        //MC.BACK_FLIP_LIST = reader.Read<EPR_T001_A>().ToList();
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
