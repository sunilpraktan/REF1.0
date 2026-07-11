using Dapper;
using Reflection.EF;
using Reflection.EF.ADM;
using Reflection.EF.Communication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Reflection.BusinessLogic
{
    public class ApprovalBL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_DocApprove MC = new MultipleContext_DocApprove();
        Approval MasterEntity = new Approval();

        public ApprovalBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ApprovalBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            try
            {
                string RequestOption = RequestValue.Split('!')[0];

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M043_DLoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var approvardata = reader.Read<Approval>().ToList();
                        MC.ApprovalList = approvardata.ToList();

                        var WorkFlowList = reader.Read<ADM_M043_P>().ToList();
                        MC.WorkFlowList = WorkFlowList.ToList();

                        var NotificationData = reader.Read<NotificationData>().ToList();
                        MC.NotificationData = NotificationData.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();

                        var docdesc = reader.Read<ADM_M043_D_P>().ToList();
                        MC.DocDesc = docdesc.ToList();

                        var employee = reader.Read<ADM_M024_P>().ToList();
                        MC.Employees = employee.ToList();

                        var statusdata = reader.Read<ADM_M0013>().ToList();
                        MC.StatusData = statusdata.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByFilter")
                    {
                        var approvardata = reader.Read<Approval>().ToList();
                        MC.ApprovalList = approvardata.ToList();
                    }
                    else if (RequestOption == "RefreshApprovalData")
                    {
                        var approvardata = reader.Read<Approval>().ToList();
                        MC.ApprovalList = approvardata.ToList();
                    }
                    string strData = ObjectSerializationService.ObjectToXML(MC);
                    return strData;
                }
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
        public string Update(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M043_DUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //var ApprovalList = reader.Read<Approval>().ToList();
                    //MC.ApprovalList = ApprovalList.ToList();

                    string strData = ObjectSerializationService.ObjectToXML(MC);
                    return strData;
                }
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
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("CREATE_APPROVAL", new { @RequestApp = Request, @OutPara1 = "" }, commandType: CommandType.StoredProcedure);
                }
                string strReturnData = "";
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
        public class MultipleContext_DocApprove
        {
            public List<Approval> ApprovalList { get; set; }
            public List<ADM_M043_P> WorkFlowList { get; set; }
            public List<COM_T003> Attachment { get; set; }
            public List<NotificationData> NotificationData { get; set; }
            public List<ADM_M043_D_P> DocDesc { get; set; }
            public List<ADM_M024_P> Employees { get; set; }
            public List<ADM_M0013> StatusData { get; set; }
        }
    }
}
