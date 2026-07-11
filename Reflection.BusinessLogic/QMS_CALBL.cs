using Dapper;
using Reflection.EF;
using Reflection.EF.QMS;
using Reflection.EF.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Reflection.BusinessLogic
{
    public class QMS_CALBL : ReflectionBusinessLogic
    {
        private static string connectionString;
        QMS_T001BL.MultipleContext_QMS_T001 MC = new QMS_T001BL.MultipleContext_QMS_T001();

        public QMS_CALBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_CALBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                QMS_T002 MasterEntity = new QMS_T002();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_CALInsert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var masterList = reader.Read<QMS_T002>().ToList();
                    List<QMS_T002> MasterList = masterList.ToList();
                    if (MasterList.Count > 0)
                    {
                        MasterEntity = MasterList[0];
                    }
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
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_CALUpdate", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = 0; //conn.Execute("CAL_T001Delete", new { @srNo = Request }, commandType: CommandType.StoredProcedure);
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
            try
            {
                string RequestOption = RequestValue.Split('!')[0];
                string strReturnData = "";

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_CALLoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var docinfo = reader.Read<SYS_M002>().ToList();
                        MC.DocTypeInfo = docinfo.ToList();

                        var masterlist = reader.Read<QMS_T001>().ToList();
                        MC.MasterEntity = masterlist.ToList();

                        var notificationData = reader.Read<NotificationData>().ToList();
                        MC.NotificationData = notificationData.ToList();
                    }
                    else if (RequestOption == "LoadFromDateToDate")
                    {
                        var masterlist = reader.Read<QMS_T001>().ToList();
                        MC.MasterEntity = masterlist.ToList();
                    }
                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    return strReturnData;
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
    }
}
