using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using Dapper;
using Reflection.EF;
using Reflection.EF.COM;

namespace Reflection.BusinessLogic.COM
{
    public class NotificationService : ReflectionBusinessLogic
    {
        MC_NOTIFY_BE MC = new MC_NOTIFY_BE();
        public NotificationService() { }
        public NotificationService(string name) { }



        public string SendNotification(string message)
        {
            try
            {
                return null;
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

        public string GetReceipentsList(string RequestValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("COM_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.NOTIFY_RECEPIENTS_LIST = reader.Read<COM_NOTIFY>().ToList();
                        MC.NOTIFICATION_LIST = reader.Read<NotificationData>().ToList();
                        //MC.NOTIFICATION_LIST = reader.Read<STD_MC_BE>().ToList();

                    }
                   
                    ReturnValue = ObjectSerializationService.ObjectToXML(MC);

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



