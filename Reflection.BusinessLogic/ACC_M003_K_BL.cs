using Dapper;
using Reflection.EF.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Reflection.EF;

namespace Reflection.BusinessLogic
{
   public  class ACC_M003_K_BL : ReflectionBusinessLogic
    {
        MultipleContext_ACC_M003_K MC = new MultipleContext_ACC_M003_K();
        ACC_M003_K MasterEntity = new ACC_M003_K();

        private static string connectionString;


        public ACC_M003_K_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M003_K_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M003_K_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _CATList = reader.Read<ACC_M003_K>().ToList();
                        MC.CATList = _CATList.ToList();

                       

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
            MultipleContext_ACC_M003_K MC = new MultipleContext_ACC_M003_K();
            ACC_M003_K MasterEntity = new ACC_M003_K();

            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ACC_M003_K_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _CATList = reader.Read<ACC_M003_K>().ToList();
                        MC.CATList = _CATList.ToList();
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
    public class MultipleContext_ACC_M003_K
    {
        public List<ACC_M003_K> CATList { get; set; }


    }
}
