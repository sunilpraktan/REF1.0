using Dapper;
using Reflection.EF;
using Reflection.EF.Communication;
using Reflection.EF.CRM;
using Reflection.EF.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class SEL_T001_SSEBL : ReflectionBusinessLogic
    {

        private static string connectionString;

        SEL_T001 MasterEntity = new SEL_T001();

        MultipleContext_SEL_T001SSE MC = new MultipleContext_SEL_T001SSE();
        public SEL_T001_SSEBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public SEL_T001_SSEBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {

            string RequestOption = RequestValue.Split('!')[0];

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T001_SSELoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var FlipGridData = reader.Read<SEL_T001SSE_Flip>().ToList();
                        MC.DocumentDataFlipGrid = FlipGridData.ToList();
                        var NotificationData = reader.Read<NotificationData>().ToList();
                        MC.NotificationData = NotificationData.ToList();
                    }
                    if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var MasterData = reader.Read<SEL_T001>().ToList();
                        MC.MasterEntity = MasterData.ToList();
                        MasterEntity = MC.MasterEntity[0];
                        var ItemsData = reader.Read<SEL_T001_A>().ToList();
                        MC.ItemsEntity = ItemsData.ToList();
                        var Schedule_B_Data = reader.Read<SEL_T002_A>().ToList();
                        MC.ScheduleDetailsEntity = Schedule_B_Data.ToList();
                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();
                        var Schedule_A_Data = reader.Read<SEL_T002>().ToList();
                        MC.ScheduleMasterEntity = Schedule_A_Data.ToList();
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

        public string UpdateStatusSO(string Request)
        {
            try
            {
                Request = (string)ObjectSerializationService.XMLToObject(Request, Request);
                int reader;
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    reader = conn.Execute("SEL_T001_SSEUpdateStatus", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                }
                string strReturnData = reader.ToString();
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
        public string UpdateStatusSODone(string Request)
        {
            try
            {
                Request = (string)ObjectSerializationService.XMLToObject(Request, Request);
                int reader;
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    reader = conn.Execute("SEL_T001_SSEUpdateStatus", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                }
                string strReturnData = reader.ToString();
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
        public class MultipleContext_SEL_T001SSE
        {
            public List<SEL_T001SSE_Flip> DocumentDataFlipGrid { get; set; }
            public List<SEL_T001> MasterEntity { get; set; }//Sales_Order
            public List<SEL_T001_A> ItemsEntity { get; set; }//Sales_Order_Items Details 
            public List<SEL_T002> ScheduleMasterEntity { get; set; }
            public List<SEL_T002_A> ScheduleDetailsEntity { get; set; }
            public List<COM_T003> Attachment { get; set; }
            public List<NotificationData> NotificationData { get; set; }
            public List<SYS_M037> Trade_Types { get; set; }
        }
    }
}
