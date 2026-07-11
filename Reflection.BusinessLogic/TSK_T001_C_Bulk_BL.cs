using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using Reflection.EF.CRM;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
   public class TSK_T001_C_Bulk_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        TSK_T001_C BulkActivityEntity = new TSK_T001_C();
        MultipleContext_TSK_T001_C_Bulk MC = new MultipleContext_TSK_T001_C_Bulk();
        List<TSK_T001_C> RequestList;
        public TSK_T001_C_Bulk_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public TSK_T001_C_Bulk_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        //public string Insert(string Request)
        //{
        //    string strReturnData = "";
        //    try
        //    {

        //        using (IDbConnection conn = new SqlConnection(connectionString))
        //        {

        //            var reader = conn.QueryMultiple("TSK_T001_CBulk_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

        //            var _BulkActivityEntity = reader.Read<TSK_T001_C>().ToList();
        //            MC.BulkActivityEntity = _BulkActivityEntity.ToList();

        //        }
        //        strReturnData = ObjectSerializationService.ObjectToXML(MC);
        //        return strReturnData;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new CreateException(ex.ErrorCode, ex.Message, ex);
        //    }
        //    catch (CreateException ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //}

        public string Insert(string Request)
        {
            string strReturnData = "";
            try
            {

                using (IDbConnection conn = new SqlConnection(connectionString))
                {

                    var reader = conn.QueryMultiple("TSK_T001_CBulk_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<TSK_T001_C>().ToList();
                    RequestList = MasterData.ToList();
                    //if (Masterlist.Count > 0)
                    //{
                    //    BulkActivityEntity = Masterlist[0];
                    //}

                }
                strReturnData = ObjectSerializationService.ObjectToXML(RequestList);
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
            string strReturnData = "";
            { 
                return strReturnData;
            }
           
        }
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("TSK_T001_CBulk_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var PartyMaster = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyMaster = PartyMaster.ToList();

                        var EmployeeMaster = reader.Read<ADM_M024_P>().ToList();
                        MC.EmployeeMaster = EmployeeMaster.ToList();

               
                        var SalesInquiryMaster = reader.Read<SEL_T001_P>().ToList();
                        MC.SalesInquiryMaster = SalesInquiryMaster.ToList();

                        var SeheduleNumber = reader.Read<TSK_T001_C_P>().ToList();
                        MC.SheduleNumber = SeheduleNumber.ToList();

                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.PARAMETERS_VALUES_LIST = reader.Read<ADM_M0071>().ToList();
                        MC.ACTIVITY_TYPE_LIST = reader.Read<STD_LIST_BE>().ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

                    }

                    else if (RequestOption == "LoadDocWithParentActNo")
                    {
                        var _BulkActivityEntity = reader.Read<TSK_T001_C>().ToList();
                        MC.BulkActivityEntity = _BulkActivityEntity.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;
                    }
                    else if (RequestOption == "LoadPartyDetail")
                    {
                        var ContactInfo = reader.Read<ADM_M028_D_P>().ToList();
                        MC.ContactInfo = ContactInfo.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;

                    }
                    else if (RequestOption == "LoadData")
                    {
                        var ItemsData = reader.Read<TSK_T001_C>().ToList();
                        MC.BulkActivityEntity = ItemsData.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LOAD_ATTACHMENTS")
                    {
                        MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                }
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
        public class MultipleContext_TSK_T001_C_Bulk
        {
            public List<COM_T003> ATTACHMENT_LIST { get; set; }
            public List<STD_LIST_BE> ACTIVITY_TYPE_LIST { get; set; }

            public List<TSK_T001_C_BackFlip> BackFlipEntity { get; set; }
            public List<TSK_T001_C> MasterEntity { get; set; }
            public List<ADM_M028_P> PartyMaster { get; set; }
            public List<ADM_M024_P> EmployeeMaster { get; set; }
            public List<SEL_T001_P> SalesInquiryMaster { get; set; }
            public List<TSK_T001_C_P> SheduleNumber { get; set; }
            public List<COM_T003> Attachment { get; set; }
            public List<NotificationData> NotificationData { get; set; }
            public List<ADM_M028_D_P> ContactInfo { get; set; }
            public List<SEL_T001_QN> SalesOrderAndQuotation { get; set; }
            public List<TSK_T001_C> BulkActivityEntity { get; set; }
            public List<ADM_M0013> STATUS_LIST { get; set; }
            public List<ADM_M0071> PARAMETERS_VALUES_LIST { get; set; }

        }
    }
}
