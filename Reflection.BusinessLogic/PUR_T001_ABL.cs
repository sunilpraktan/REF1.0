using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Procurement;
using Reflection.EF.ReflectionSystem;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.CRM;
using Reflection.EF.Admin;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    public class PUR_T001_ABL : ReflectionBusinessLogic
    {

        private static string connectionString;

        PUR_T001_A MasterEntity = new PUR_T001_A();
        public PUR_T001_ABL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public PUR_T001_ABL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MultipleContext_PUR_T001_A MC = new MultipleContext_PUR_T001_A();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T001_AInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFilptemp = reader.Read<PUR_T001_AFlip>().ToList();
                    MC.DocumentDataFlipGrid = BackFilptemp.ToList();

                    var MasterData = reader.Read<PUR_T001_A>().ToList();
                    MC.Pur_Req = MasterData.ToList();

                    var pur_reqDtl = reader.Read<PUR_T001_B>().ToList();
                    MC.Pur_Req_Details = pur_reqDtl.ToList();
                    if (MC.Pur_Req.Count > 0)
                    {
                        MasterEntity = MC.Pur_Req[0];
                    }

                    var pur_reqSchedule = reader.Read<PUR_T001_C>().ToList();
                    MC.Pur_Req_Schedule = pur_reqSchedule.ToList();

                    MasterEntity.XmlDataDocument_PUR_T001_B = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Details);
                    MasterEntity.XmlDataDocument_PUR_T001_C = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Schedule);
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
                return strReturnData;
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
                MultipleContext_PUR_T001_A MC = new MultipleContext_PUR_T001_A();

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T001_AUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFilptemp = reader.Read<PUR_T001_AFlip>().ToList();
                    MC.DocumentDataFlipGrid = BackFilptemp.ToList();

                    var MasterData = reader.Read<PUR_T001_A>().ToList();
                    MC.Pur_Req = MasterData.ToList();

                    var pur_reqDtl = reader.Read<PUR_T001_B>().ToList();
                    MC.Pur_Req_Details = pur_reqDtl.ToList();
                    if (MC.Pur_Req.Count > 0)
                    {
                        MasterEntity = MC.Pur_Req[0];
                    }

                    var pur_reqSchedule = reader.Read<PUR_T001_C>().ToList();
                    MC.Pur_Req_Schedule = pur_reqSchedule.ToList();

                    MasterEntity.XmlDataDocument_PUR_T001_B = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Details);
                    MasterEntity.XmlDataDocument_PUR_T001_C = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Schedule);
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
                return strReturnData;
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
                using (IDbConnection conn = new SqlConnection(connectionString))
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
            MultipleContext_PUR_T001_A MC = new MultipleContext_PUR_T001_A();
            string RequestOption = RequestValue.Split('!')[0];
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T001_ALoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        MC.Priorities = reader.Read<ADM_M040_P>().ToList();
                        MC.Employees = reader.Read<ADM_M024_P>().ToList();
                        MC.ItemList = reader.Read<ADM_M022_P>().ToList();
                        MC.ParameterList = reader.Read<ADM_M031_P>().ToList();
                        MC.ParamValueList = reader.Read<ADM_M030_P>().ToList();
                        MC.uoms = reader.Read<ADM_M038_B_P>().ToList();
                        MC.ItemCategoryList = reader.Read<SYS_M008_P>().ToList();
                        MC.doc_typeList = reader.Read<SYS_M007>().ToList();
                        MC.NotificationData = reader.Read<NotificationData>().ToList();
                        MC.SalesList = reader.Read<SEL_T001_P>().ToList();
                        MC.purchase_orgList = reader.Read<ADM_M001_M_P>().ToList();
                        MC.Purchase_groupList = reader.Read<ADM_M001_P_P>().ToList();
                        MC.BOM_List = reader.Read<ENG_T001_P>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.DepartmentList = reader.Read<ADM_M025_P>().ToList();
                        MC.Project = reader.Read<PRO_T001_P>().ToList();
                        MC.PRODUCTION_ORDER_OPERATIONS = reader.Read<STD_LIST_BE>().ToList();

                        strData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadBackFlipData")
                    {
                        var DocDataFlipGrid = reader.Read<PUR_T001_AFlip>().ToList();
                        MC.DocumentDataFlipGrid = DocDataFlipGrid.ToList();

                        strData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadDocumentFromBackFilp")
                    {
                        var MasterData = reader.Read<PUR_T001_A>().ToList();
                        MC.Pur_Req = MasterData.ToList();

                        var Pu_ReqDtl = reader.Read<PUR_T001_B>().ToList();
                        MC.Pur_Req_Details = Pu_ReqDtl.ToList();

                        var pur_reqSchedule = reader.Read<PUR_T001_C>().ToList();
                        MC.Pur_Req_Schedule = pur_reqSchedule.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();

                        MC.ApprovalData = reader.Read<ADM_M043_D>().ToList();

                        strData = ObjectSerializationService.ObjectToXML(MC);
                        // string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
                        return strData;
                    }
                }
                return strData;
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

        public byte[] GetData(string Request, string RequestOption)
        {
            MultipleContext_PUR_T001_A MC = new MultipleContext_PUR_T001_A();
            string QueryOption = Request.Split('!')[0];
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T001_ALoadAll", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    if (QueryOption == "LoadInitialData")
                    {
                        var documentDataFlipGrid = reader.Read<PUR_T001_AFlip>().ToList();
                        MC.DocumentDataFlipGrid = documentDataFlipGrid.ToList();
                        var priorities = reader.Read<ADM_M040_P>().ToList();
                        MC.Priorities = priorities.ToList();
                        var employees = reader.Read<ADM_M024_P>().ToList();
                        MC.Employees = employees.ToList();
                        var itemList = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList = itemList.ToList();
                        var parameterList = reader.Read<ADM_M031_P>().ToList();
                        MC.ParameterList = parameterList.ToList();
                        var paramValueList = reader.Read<ADM_M030_P>().ToList();
                        MC.ParamValueList = paramValueList.ToList();
                        var Uoms = reader.Read<ADM_M038_B_P>().ToList();
                        MC.uoms = Uoms.ToList();
                        var itemCategoryList = reader.Read<SYS_M008_P>().ToList();
                        MC.ItemCategoryList = itemCategoryList.ToList();
                        var Doc_typeList = reader.Read<SYS_M007>().ToList();
                        MC.doc_typeList = Doc_typeList.ToList();
                        var notificationData = reader.Read<NotificationData>().ToList();
                        MC.NotificationData = notificationData.ToList();


                    }
                    else if (QueryOption == "LoadDocumentFromBackFilp")
                    {
                        var MasterData = reader.Read<PUR_T001_A>().ToList();
                        MC.Pur_Req = MasterData.ToList();

                        var Pu_ReqDtl = reader.Read<PUR_T001_B>().ToList();
                        MC.Pur_Req_Details = Pu_ReqDtl.ToList();

                        var pur_reqSchedule = reader.Read<PUR_T001_C>().ToList();
                        MC.Pur_Req_Schedule = pur_reqSchedule.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();

                        MC.APPROVALS = reader.Read<ADM_M043_D>().ToList();

                    }
                }
                return ObjectSerializationService<MultipleContext_PUR_T001_A>.ObjectToStream(MC);
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
        public byte[] Insert(byte[] RequestStream, string Request, string RequestOption)
        {
            try
            {
                MultipleContext_PUR_T001_A MC = new MultipleContext_PUR_T001_A();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T001_AInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFilptemp = reader.Read<PUR_T001_AFlip>().ToList();
                    MC.DocumentDataFlipGrid = BackFilptemp.ToList();

                    var MasterData = reader.Read<PUR_T001_A>().ToList();
                    MC.Pur_Req = MasterData.ToList();

                    var pur_reqDtl = reader.Read<PUR_T001_B>().ToList();
                    MC.Pur_Req_Details = pur_reqDtl.ToList();

                    MasterEntity = MC.Pur_Req[0];
                    MasterEntity.XmlDataDocument_PUR_T001_B = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Details);
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                }
                return ObjectSerializationService<SEL_T001>.ObjectToStream(MasterEntity);
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
        public byte[] Update(byte[] RequestStream, string Request, string RequestOption)
        {
            try
            {
                MultipleContext_PUR_T001_A MC = new MultipleContext_PUR_T001_A();

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T001_AUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFilptemp = reader.Read<PUR_T001_AFlip>().ToList();
                    MC.DocumentDataFlipGrid = BackFilptemp.ToList();

                    var MasterData = reader.Read<PUR_T001_A>().ToList();
                    MC.Pur_Req = MasterData.ToList();

                    var pur_reqDtl = reader.Read<PUR_T001_B>().ToList();
                    MC.Pur_Req_Details = pur_reqDtl.ToList();

                    MasterEntity = MC.Pur_Req[0];
                    MasterEntity.XmlDataDocument_PUR_T001_B = ObjectSerializationService.ObjectToXML(MC.Pur_Req_Details);
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                }
                return ObjectSerializationService<SEL_T001>.ObjectToStream(MasterEntity);
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
    public class MultipleContext_PUR_T001_A : STD_MC_BE
    {
        public List<ADM_M043_D> APPROVALS { get; set; }
        //public List<STD_DOC_TYPE> DOC_TYPE_LIST { get; set; }
        public List<PUR_T001_AFlip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M040_P> Priorities { get; set; }//Priority Master        
        public List<ADM_M024_P> Employees { get; set; }//Employee_Master
        public List<ADM_M022_P> ItemList { get; set; }
        public List<ADM_M031_P> ParameterList { get; set; } //Parameter Master
        public List<ADM_M030_P> ParamValueList { get; set; }//Flute Master
        public List<ADM_M038_B_P> uoms { get; set; }// UOM_Master 
        public List<SYS_M008_P> ItemCategoryList { get; set; }
        public List<PUR_T001_A> Pur_Req { get; set; }//Purchase Requisition
        public List<PUR_T001_B> Pur_Req_Details { get; set; }//Purchase Requisition Items
        public List<PUR_T001_C> Pur_Req_Schedule { get; set; }//Purchase Requisition Items
        public List<SYS_M007> doc_typeList { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<PUR_T001_A> MasterEntity { get; set; }
        public List<PUR_T001_B> ItemsEntity { get; set; }
        public List<SEL_T001_P> SalesList { get; set; }
        public List<ADM_M001_M_P> purchase_orgList { get; set; }
        public List<ADM_M001_P_P> Purchase_groupList { get; set; }
        public List<ENG_T001_P> BOM_List { get; set; }
        //public List<ADM_M0013> t_statusList { get; set; }
        public List<ADM_M025_P> DepartmentList { get; set; }
        public List<PRO_T001_P> Project { get; set; }
        public List<STD_LIST_BE> PRODUCTION_ORDER_OPERATIONS { get; set; }
        //public List<ADM_M043_D> ApprovalData { get; set; }
    }
}
