using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace Reflection.BusinessLogic.COM
{
    public class COM_R05_BL : ReflectionBusinessLogic
    {
        public COM_R05_BL()
        { }
        public string GetData(string Request, string QueryOption, int intValue, string strValue)
        {

            STD_MC_BE MC = new STD_MC_BE();
            string RequestOption = Request.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("COM_R05", new { @request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.NOTIFICATION_LIST = reader.Read<NotificationData>().ToList();
                        MC.STANDARD_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    base.ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                }
                return base.ReturnValue;
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
