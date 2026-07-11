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
    public class MIS_ApprovalBL : ReflectionBusinessLogic
    {
        private static string connectionString;
        List<Approval> ApprovalList = new List<Approval>();

        public MIS_ApprovalBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_ApprovalBL()
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
                    var reader = conn.QueryMultiple("MIS_Approval", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var approvardata = reader.Read<Approval>().ToList();
                        ApprovalList = approvardata.ToList();
                    }
                    else if (RequestOption == "Report")
                    {
                        var approvardata = reader.Read<Approval>().ToList();
                        ApprovalList = approvardata.ToList();
                    }
                    string strData = ObjectSerializationService.ObjectToXML(ApprovalList);
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
            return null;
        }
        public string Insert(string Request)
        {
            return null;
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
