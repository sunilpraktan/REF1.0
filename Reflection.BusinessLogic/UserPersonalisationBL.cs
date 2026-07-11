using Dapper;
using Reflection.EF;
using Reflection.EF.Settings;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Reflection.BusinessLogic
{
    public class UserPersonalisationBL : ReflectionBusinessLogic
    {
        private static string connectionString;

        UserLevelSettings uset = new UserLevelSettings();
        public UserPersonalisationBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public UserPersonalisationBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public byte[] Insert(byte[] RequestStream, string Request, string RequestOption)
        {
            string strData = "";
            byte[] response = null;
            MContext_Authontication MCL = new MContext_Authontication();
            try
            {
                uset = (UserLevelSettings)ObjectSerializationService.XMLToObject(Request, uset);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int reader = conn.Execute("UserPersonalisation", new { @request = Request }, commandType: CommandType.StoredProcedure);
                    strData = "Saved Data Successfully!";
                }
                return response;
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
