using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Procurement;
using Reflection.EF.ReflectionSystem;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.Admin;
using Reflection.EF.COM;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic.PRO
{
    public class PRO_T001_BL : ReflectionBusinessLogic
    {
        PUR_T001_A MasterEntity = new PUR_T001_A();
        MultipleContext_PUR_T001_A MC = new MultipleContext_PUR_T001_A();
        //ObjectSerializationService objSer = new ObjectSerializationService();
        public PRO_T001_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                MC = (MultipleContext_PUR_T001_A)ObjectSerializationService.XMLToObject(Request, MC);
                MasterEntity = MC.Pur_Req[0];
                MasterEntity.XmlDataDocument_PUR_T001_B = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Details);
                MasterEntity.XmlDataDocument_PUR_T001_C = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Schedule);
                string request2 = ObjectSerializationService.ObjectToXML(MasterEntity);

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T001_INS", new { @Request = request2 }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    //MC.DocumentDataFlipGrid = reader.Read<PUR_T001_AFlip>().ToList();
                    MC.Pur_Req = reader.Read<PUR_T001_A>().ToList();
                    MC.Pur_Req_Details = reader.Read<PUR_T001_B>().ToList();
                    if (MC.Pur_Req.Count > 0)
                    {
                        MasterEntity = MC.Pur_Req[0];
                    }
                    MC.Pur_Req_Schedule = reader.Read<PUR_T001_C>().ToList();
                    MC.Attachment = reader.Read<COM_T003>().ToList();
                    MC.APPROVALS = reader.Read<ADM_M043_D>().ToList();
                    MC.WORKFLOW_LIST = reader.Read<COM_T011>().ToList();

                    //MasterEntity.XmlDataDocument_PUR_T001_B = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Details);
                    //MasterEntity.XmlDataDocument_PUR_T001_C = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Schedule);
                    ////MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                }
                //ReturnValue = ObjectSerializationService.ObjectToXML(MasterEntity);
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
        public string Update(string Request)
        {
            try
            {
                MC = (MultipleContext_PUR_T001_A)ObjectSerializationService.XMLToObject(Request, MC);
                MasterEntity = MC.Pur_Req[0];
                MasterEntity.XmlDataDocument_PUR_T001_B = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Details);
                MasterEntity.XmlDataDocument_PUR_T001_C = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Schedule);
                string request2 = ObjectSerializationService.ObjectToXML(MasterEntity);

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T001_UPD", new { @Request = request2 }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    //MC.DocumentDataFlipGrid = reader.Read<PUR_T001_AFlip>().ToList();
                    MC.Pur_Req = reader.Read<PUR_T001_A>().ToList();
                    MC.Pur_Req_Details = reader.Read<PUR_T001_B>().ToList();
                    if (MC.Pur_Req.Count > 0)
                    {
                        MasterEntity = MC.Pur_Req[0];
                    }
                    MC.Pur_Req_Schedule = reader.Read<PUR_T001_C>().ToList();
                    MC.Attachment = reader.Read<COM_T003>().ToList();
                    MC.APPROVALS = reader.Read<ADM_M043_D>().ToList();
                    MC.WORKFLOW_LIST = reader.Read<COM_T011>().ToList();

                    //MasterEntity.XmlDataDocument_PUR_T001_B = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Details);
                    //MasterEntity.XmlDataDocument_PUR_T001_C = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Schedule);
                    ////MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                }
                //ReturnValue = ObjectSerializationService.ObjectToXML(MasterEntity);
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
                    var reader = conn.QueryMultiple("PUR_T001_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        MC.Priorities = reader.Read<ADM_M040_P>().ToList();
                        MC.Employees = reader.Read<ADM_M024_P>().ToList();
                        MC.ItemList = reader.Read<ADM_M022_P>().ToList();
                        MC.ParameterList = reader.Read<ADM_M031_P>().ToList();
                        MC.ParamValueList = reader.Read<ADM_M030_P>().ToList();
                        MC.uoms = reader.Read<ADM_M038_B_P>().ToList();
                        MC.ItemCategoryList = reader.Read<SYS_M008_P>().ToList();
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.NotificationData = reader.Read<NotificationData>().ToList();
                        MC.SalesList = reader.Read<SEL_T001_P>().ToList();
                        MC.purchase_orgList = reader.Read<ADM_M001_M_P>().ToList();
                        MC.Purchase_groupList = reader.Read<ADM_M001_P_P>().ToList();
                        MC.BOM_List = reader.Read<ENG_T001_P>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.DepartmentList = reader.Read<ADM_M025_P>().ToList();
                        MC.Project = reader.Read<PRO_T001_P>().ToList();
                        MC.PRODUCTION_ORDER_OPERATIONS = reader.Read<STD_LIST_BE>().ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadBackFlipData")
                    {
                        MC.DocumentDataFlipGrid = reader.Read<PUR_T001_AFlip>().ToList();
                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadDocumentFromBackFilp")
                    {
                        MC.Pur_Req = reader.Read<PUR_T001_A>().ToList();
                        MC.Pur_Req_Details = reader.Read<PUR_T001_B>().ToList();
                        MC.Pur_Req_Schedule = reader.Read<PUR_T001_C>().ToList();
                        MC.Attachment = reader.Read<COM_T003>().ToList();
                        MC.APPROVALS = reader.Read<ADM_M043_D>().ToList();
                        MC.WORKFLOW_LIST = reader.Read<COM_T011>().ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        // string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
                        return ReturnValue;
                    }
                    else if (RequestOption == "CHECK_ITEM_EXISTS")
                    {
                        MC.PRODUCTION_ORDER_OPERATIONS = reader.Read<STD_LIST_BE>().ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        return ReturnValue;
                    }
                    else if (RequestOption == "GENERATE_PR_DATA")
                    {
                        MC.STANDARD_LIST = reader.Read<STD_LIST_BE>().ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
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
