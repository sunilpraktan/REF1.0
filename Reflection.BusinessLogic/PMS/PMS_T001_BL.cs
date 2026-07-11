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
    public class PMS_T001_BL : ReflectionBusinessLogic
    {
        PMS_T001 MasterEntity = new PMS_T001();
        MC_PMS_BE MC = new MC_PMS_BE();
        public PMS_T001_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("PMS_T001_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    MC.PROJECT_LIST = reader.Read<PMS_T001>().ToList();
                    if (MC.PROJECT_LIST.Count > 0)
                    {
                        MasterEntity = MC.PROJECT_LIST[0];
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
                    var reader = conn.QueryMultiple("PMS_T001_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    MC.PROJECT_LIST = reader.Read<PMS_T001>().ToList();
                    if (MC.PROJECT_LIST.Count > 0)
                    {
                        MasterEntity = MC.PROJECT_LIST[0];
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
                    var reader = conn.QueryMultiple("PMS_T001_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.PARTY_LIST = reader.Read<STD_PARTY>().ToList();
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        MC.TYPE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.CURR_LIST = reader.Read<FICO_M0033>().ToList();
                        //MC.NOTIFICATION_LIST = reader.Read<NotificationData>().ToList();
                        MC.STANDARD_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.VALUE_LIST = reader.Read<STD_LIST_BE>().ToList();


                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LOAD_BACKFLIP")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "LOAD_TREE_DATA")
                    {
                        //MC.PROJECT_LIST = reader.Read<PMS_T001>().ToList();
                        MC.TREE_LIST_VIEW = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.PROJECT_LIST = reader.Read<PMS_T001>().ToList();
                        MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList();
                        MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO2")
                    {
                        MC.PROJECT_LIST = reader.Read<PMS_T001>().ToList();
                        MC.ELEMENT_LIST = reader.Read<PMS_T002>().ToList();
                        //MC.SCHEDULE_LIST = reader.Read<PMS_T006>().ToList();
                        MC.MILESTONE_LIST = reader.Read<PMS_T004>().ToList();
                        MC.TASK_LIST = reader.Read<EPR_T001>().ToList();
                        MC.ACTIVITY_LIST = reader.Read<EPR_T001_A>().ToList();
                        //MC.ACTIVITY_DATES_LIST = reader.Read<EPR_T001_B>().ToList();
                        MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList();
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
