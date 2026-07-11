using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using Reflection.EF.CRM;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic
{
    public class TSK_T001_CBL : ReflectionBusinessLogic
    {
        
        private static string connectionString;
        TSK_T001_C MasterEntity = new TSK_T001_C();
        MultipleContext_TSK_T001_C MC = new MultipleContext_TSK_T001_C();

        public TSK_T001_CBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public TSK_T001_CBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            string strReturnData = "";
            try
            {

                using (IDbConnection conn = new SqlConnection(connectionString))
                {

                    var reader = conn.QueryMultiple("TSK_T001_CInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<TSK_T001_C>().ToList();
                    List<TSK_T001_C> Masterlist = MasterData.ToList();
                    MasterEntity = Masterlist[0];


                     MC.BackFlipEntity = reader.Read<TSK_T001_C_BackFlip>().ToList();

                     MasterEntity.BackFlipEntity = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
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
        public string InsertEP(string Request)
        {
            string strReturnData = "";
            try
            {

                using (IDbConnection conn = new SqlConnection(connectionString))
                {

                    var reader = conn.QueryMultiple("TSK_T001_CEPInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var ItemsData = reader.Read<TSK_T001_C>().ToList();
                    MC.ItemEntity = ItemsData.ToList();

                    MasterEntity.XmlDataDocument_ItemsEntity = ObjectSerializationService.ObjectToXML(MC.ItemEntity);
                  
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
            string strReturnData = "";
            try
            {

                using (IDbConnection conn = new SqlConnection(connectionString))
                {

                    var reader = conn.QueryMultiple("TSK_T001_CUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<TSK_T001_C>().ToList();
                    List<TSK_T001_C> Masterlist = MasterData.ToList();
                    MasterEntity = Masterlist[0];

                    MC.BackFlipEntity = reader.Read<TSK_T001_C_BackFlip>().ToList();

                    MasterEntity.BackFlipEntity = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
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
                    int intOut = conn.Execute("TSK_T001_CDelete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("TSK_T001_CLoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                      
                        MC.BackFlipEntity = reader.Read<TSK_T001_C_BackFlip>().ToList();
                      
                        var PartyMaster = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyMaster = PartyMaster.ToList();

                        var EmployeeMaster = reader.Read<ADM_M024_P>().ToList();
                        MC.EmployeeMaster = EmployeeMaster.ToList();

                        var SalesInquiryMaster = reader.Read<SEL_T001_P>().ToList();
                        MC.SalesInquiryMaster = SalesInquiryMaster.ToList();

                        var SeheduleNumber = reader.Read<TSK_T001_C_P>().ToList();
                        MC.SheduleNumber = SeheduleNumber.ToList();

                        var UnvisitedPerson = reader.Read<ADM_M024_P>().ToList();
                        MC.UnvisitedList = UnvisitedPerson.ToList();

                        var ContactPersonData = reader.Read<ADM_M054_P>().ToList();
                        MC.BuyerList = ContactPersonData.ToList();

                        var ActicityCatData = reader.Read<CRM_M007_P>().ToList();
                        MC.ActicityCatList = ActicityCatData.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

                    }
                    if (RequestOption == "LoadInitialDataNewActivity")
                    {
                        var PartyMaster = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyMaster = PartyMaster.ToList();

                        var EmployeeMaster = reader.Read<ADM_M024_P>().ToList();
                        MC.EmployeeMaster = EmployeeMaster.ToList();

                        var SalesInquiryMaster = reader.Read<SEL_T001_P>().ToList();
                        MC.SalesInquiryMaster = SalesInquiryMaster.ToList();

                        var SeheduleNumber = reader.Read<TSK_T001_C_P>().ToList();
                        MC.SheduleNumber = SeheduleNumber.ToList();

                        var UnvisitedPerson = reader.Read<ADM_M024_P>().ToList();
                        MC.UnvisitedList = UnvisitedPerson.ToList();

                        var ContactPersonData = reader.Read<ADM_M054_P>().ToList();
                        MC.BuyerList = ContactPersonData.ToList();

                        var ActicityCatData = reader.Read<CRM_M007_P>().ToList();
                        MC.ActicityCatList = ActicityCatData.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

                    }
                    if (RequestOption == "LoadInitialDataActivity")
                    {
                        MC.BackFlipEntity = reader.Read<TSK_T001_C_BackFlip>().ToList();
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

                    }

                    else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                    {
                        #region LoadDocumentWithReferenceDocumentNumber

                        var MasterData = reader.Read<TSK_T001_C>().ToList();
                        List<TSK_T001_C> Masterlist = MasterData.ToList();
                        MasterEntity = Masterlist[0];

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
                        return strReturnData;

                        #endregion
                    }
                    else if (RequestOption == "LoadPartyDetail")
                    {
                        var ContactInfo = reader.Read<ADM_M028_D_P>().ToList();
                        MC.ContactInfo = ContactInfo.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;

                    }
                    else if (RequestOption == "LoadSOAndQuotationDetails")
                    {
                        var salesOrderAndQuotation = reader.Read<SEL_T001_QN>().ToList();
                        MC.SalesOrderAndQuotation = salesOrderAndQuotation.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;
                    }
                    else if (RequestOption == "LoadByParty")
                    {
                        var ItemsData = reader.Read<TSK_T001_C>().ToList();
                        MC.ItemEntity = ItemsData.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadBackFlipData")
                    {
                        MC.BackFlipEntity = reader.Read<TSK_T001_C_BackFlip>().ToList();
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

        public class MultipleContext_TSK_T001_C
        {
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
            public List<TSK_T001_C> ItemEntity { get; set; }
            public List<ADM_M024_P> UnvisitedList { get; set; }
            public List<ADM_M054_P> BuyerList { get; set; }
            public List<CRM_M007_P> ActicityCatList { get; set; }
        }
    }
}
