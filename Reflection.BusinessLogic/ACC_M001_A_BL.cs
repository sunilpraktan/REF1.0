using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Finance;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ACC_M001_A_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        ACC_M001_A MasterEntity = new ACC_M001_A();
        MultipleContext_ACC_M001_A MC = new MultipleContext_ACC_M001_A();

        public ACC_M001_A_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M001_A_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string RequestValue, string strType, int intValue, string srtValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M001_A_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    if (RequestOption == "LoadInitialData")
                    {
                        var _PostPeriodList = reader.Read<ACC_M001_A>().ToList();
                        MC.PostPeriodList = _PostPeriodList.ToList();
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

        public string Insert(string Request)
        {
            string strReturnData = "";

            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ACC_M001_A_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _PostPeriodList = reader.Read<ACC_M001_A>().ToList();
                        MC.PostPeriodList = _PostPeriodList.ToList();
                    }

                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    return strReturnData;
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
    }
    public class MultipleContext_ACC_M001_A
    {
        public List<ACC_M001_A> PostPeriodList { get; set; }
    }
}
