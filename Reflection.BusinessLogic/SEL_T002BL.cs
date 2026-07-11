using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using Reflection.EF.CRM;
using System.Data;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.Admin;
using Reflection.EF.ReflectionSystem;

namespace Reflection.BusinessLogic
{
    public class SEL_T002BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        MultipleContext_SEL_T002 MC = new MultipleContext_SEL_T002();

        SEL_T002 MasterEntity = new SEL_T002();

        public SEL_T002BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public SEL_T002BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            MultipleContext_SEL_T002 MC = new MultipleContext_SEL_T002();


            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T002Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<SEL_T002>().ToList();
                    List<SEL_T002> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var ScheduleDetail = reader.Read<SEL_T002_A>().ToList();
                    MC.ItemsEntity = ScheduleDetail.ToList();

                    var SalesOrderSchedule = reader.Read<SEL_T002_BackFlip>().ToList();
                    MC.BackFlipEntity = SalesOrderSchedule.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
                    MasterEntity.XmlDataDocument_SEL_T002_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);


                }
                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
            MultipleContext_SEL_T002 MC = new MultipleContext_SEL_T002();

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T002Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<SEL_T002>().ToList();
                    List<SEL_T002> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var ScheduleDetail = reader.Read<SEL_T002_A>().ToList();
                    MC.ItemsEntity = ScheduleDetail.ToList();

                    var SalesOrderSchedule = reader.Read<SEL_T002_BackFlip>().ToList();
                    MC.BackFlipEntity = SalesOrderSchedule.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
                    MasterEntity.XmlDataDocument_SEL_T002_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);


                }
                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
                    int intOut = conn.Execute("SEL_T002Delete", new { @sch_no = Request }, commandType: CommandType.StoredProcedure);
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
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            MultipleContext_SEL_T002 MC = new MultipleContext_SEL_T002();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T002LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                       
                        var partyMaster1 = reader.Read<ADM_M028_sch_P>().ToList();
                        MC.PartyMaster = partyMaster1.ToList();
                        var employeeMaster = reader.Read<ADM_M024_P>().ToList();
                        MC.EmployeeEntity = employeeMaster.ToList();
                        var UnitMaster = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UOM = UnitMaster.ToList();
                        var SalesMaster = reader.Read<SEL_T001_P>().ToList();
                        MC.Reference_Docs = SalesMaster.ToList();
                        var RequirementNo = reader.Read<SEL_T002_Req_P>().ToList();
                        MC.Req_Details = RequirementNo.ToList();
                        var NotificationData = reader.Read<NotificationData>().ToList();
                        MC.NotificationData = NotificationData.ToList();
                        var SalesOrederList = reader.Read<SEL_T002_P_RefDoc>().ToList();
                        MC.ScheduleReference = SalesOrederList.ToList();
                        var t_statusData = reader.Read<SYS_M025>().ToList();
                        MC.t_statusList = t_statusData.ToList();
                        var UnitConversion = reader.Read<ADM_M038_C>().ToList();
                        MC.UnitConversion = UnitConversion.ToList();

                    }
                    else if (RequestOption == "LoadHistory")
                    {
                        var SalesOrderSchedule = reader.Read<SEL_T002_BackFlip>().ToList();
                        MC.BackFlipEntity = SalesOrderSchedule.ToList();
                    }
                    else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                    {

                        var MasterEntity = reader.Read<SEL_T002>().ToList();
                        MC.MasterEntity = MasterEntity.ToList();
                        var ItemSceduleDetail = reader.Read<SEL_T002_A>().ToList();
                        MC.ItemsEntity = ItemSceduleDetail.ToList();
                        var ItemMaster = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemsMaster = ItemMaster.ToList();
                        var SoDetails = reader.Read<SEL_T001_schedule_P>().ToList();
                        MC.so_schedule = SoDetails.ToList();
                        var ReqDetails = reader.Read<SEL_T002_Req_P>().ToList();
                        MC.Req_Details = ReqDetails.ToList();
                        var deliveryAddress = reader.Read<ADM_M028_D_Add>().ToList();
                        MC.DeliveryAddress = deliveryAddress.ToList();
                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();

                    }
                    else if (RequestOption == "LoadInitialDataForConfirmation")
                    {
                        var SalesOrderSchedule = reader.Read<SEL_T002_BackFlip>().ToList();
                        MC.BackFlipEntity = SalesOrderSchedule.ToList();
                        var NotificationData = reader.Read<NotificationData>().ToList();
                        MC.NotificationData = NotificationData.ToList();
                    }
                    else if (RequestOption == "LoadDocWithRefDocNoForConfirmation")
                    {
                        var MasterEntity = reader.Read<SEL_T002>().ToList();
                        MC.MasterEntity = MasterEntity.ToList();
                        var ItemSceduleDetail = reader.Read<SEL_T002_A>().ToList();
                        MC.ItemsEntity = ItemSceduleDetail.ToList();
                        var SoDetails = reader.Read<SEL_T001_schedule_P>().ToList();
                        MC.so_schedule = SoDetails.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();
                    }
                    else if (RequestOption == "LoadPartyDetails")
                    {

                        var ContactMaster = reader.Read<ADM_M028_C_P>().ToList();
                        MC.contactInfoMaster = ContactMaster.ToList();
                        var SoDetails = reader.Read<SEL_T001_schedule_P>().ToList();
                        MC.so_schedule = SoDetails.ToList();
                        var ReqDetails = reader.Read<SEL_T002_Req_P>().ToList();
                        MC.Req_Details = ReqDetails.ToList();
                        var ItemMaster = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemsMaster = ItemMaster.ToList();
                        var deliveryAddress = reader.Read<ADM_M028_D_Add>().ToList();
                        MC.DeliveryAddress = deliveryAddress.ToList();

                    }
                    else if (RequestOption == "LoadInitialDataForConfirmation")
                    {
                        var SalesOrderSchedule = reader.Read<SEL_T002_BackFlip>().ToList();
                        MC.BackFlipEntity = SalesOrderSchedule.ToList();
                        var NotificationData = reader.Read<NotificationData>().ToList();
                        MC.NotificationData = NotificationData.ToList();
                    }
                    else if (RequestOption == "LoadDocumentFromSOReferneceNo")
                    {
                        var MasterEntity = reader.Read<SEL_T002>().ToList();
                        MC.MasterEntity = MasterEntity.ToList();
                        var ItemEntity = reader.Read<SEL_T002_A>().ToList();
                        MC.ItemsEntity = ItemEntity.ToList();
                        var ContactMaster = reader.Read<ADM_M028_C_P>().ToList();
                        MC.contactInfoMaster = ContactMaster.ToList();
                        var SoDetails = reader.Read<SEL_T001_schedule_P>().ToList();
                        MC.so_schedule = SoDetails.ToList();
                        var ReqDetails = reader.Read<SEL_T002_Req_P>().ToList();
                        MC.Req_Details = ReqDetails.ToList();
                        var deliveryAddress = reader.Read<ADM_M028_D_Add>().ToList();
                        MC.DeliveryAddress = deliveryAddress.ToList();
                    }
                   
                }
                strReturnData = ObjectSerializationService.ObjectToXML(MC);
                return strReturnData;
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
    public class MultipleContext_SEL_T002
    {
        public List<SEL_T002> MasterEntity { get; set; }
        public List<SEL_T002_A> ItemsEntity { get; set; }
        public List<ADM_M028_sch_P> PartyMaster { get; set; }
        public List<ADM_M028_C_P> contactInfoMaster { get; set; }
        public List<ADM_M024_P> EmployeeEntity { get; set; }
        public List<ADM_M038_B_P> UOM { get; set; }
        public List<ADM_M022_P> ItemsMaster { get; set; }
        public List<SEL_T002_BackFlip> BackFlipEntity { get; set; }
        public List<SEL_T001_P> Reference_Docs { get; set; }
        public List<SEL_T001_schedule_P> so_schedule { get; set; }
        public List<SEL_T002_P> ReqNo { get; set; }
        public List<SEL_T002_Req_P> Req_Details { get; set; }
        public List<SEL_T002_P_RefDoc> ScheduleReference { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<ADM_M028_D_Add> DeliveryAddress { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<Delivery_Schedule> RptDelivery_Schedule { get; set; }
        public List<SYS_M025> t_statusList { get; set; }
        public List<ADM_M038_C> UnitConversion { get; set; }
        public List<SYS_M036> ScheduleMode { get; set; }
        public List<SYS_M026> TransportMode { get; set; }
        public List<ADM_M028_P> ServiceProviders { get; set; }
        public List<SEL_T001> SalesOrderMaster { get; set; }
        public List<SEL_T001_A> SalesOrderEntity { get; set; }

    }
}

