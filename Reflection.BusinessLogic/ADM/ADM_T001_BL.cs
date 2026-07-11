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
    public class ADM_T001_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_DocApprove MC = new MultipleContext_DocApprove();
        Approval MasterEntity = new Approval();

        public ADM_T001_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_T001_BL()
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
                    var reader = conn.QueryMultiple("COM_T005_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.ApprovalList = reader.Read<Approval>().ToList();
                        MC.WorkFlowList = reader.Read<ADM_M043_P>().ToList();
                        MC.NotificationData = reader.Read<NotificationData>().ToList();
                        MC.Attachment = reader.Read<COM_T003>().ToList();
                        MC.DocDesc = reader.Read<ADM_M043_D_P>().ToList();
                        MC.Employees = reader.Read<ADM_M024_P>().ToList();
                        MC.StatusData = reader.Read<ADM_M0013>().ToList();
                    }
                    else if (RequestOption == "REFRESH_FILTER" || RequestOption == "REFRESH")
                    {
                        MC.ApprovalList = reader.Read<Approval>().ToList();
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
                    var reader = conn.QueryMultiple("COM_T005_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

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
                    var reader = conn.QueryMultiple("COM_T005_INS", new { @RequestApp = Request, @OutPara1 = "" }, commandType: CommandType.StoredProcedure);
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
