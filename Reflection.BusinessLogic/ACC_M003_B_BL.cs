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
     public class ACC_M003_B_BL : ReflectionBusinessLogic
    {
        MultipleContext_ACC_M003_B MC = new MultipleContext_ACC_M003_B();

        private static string connectionString;
        ACC_M003_B MasterEntity = new ACC_M003_B();

        public ACC_M003_B_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M003_B_BL()
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
                    var reader = conn.QueryMultiple("ACC_M003_B_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _ACList = reader.Read<ACC_M003_B>().ToList();
                        MC.ACList = _ACList.ToList();

                        var _IDList = reader.Read<ACC_M003_B_P>().ToList();
                        MC.IDList = _IDList.ToList();


                        var _SGList = reader.Read<ACC_M003_A_P>().ToList();
                        MC.SGList = _SGList.ToList();


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
            //ACC_M025 MasterEntity = new ACC_M025();
            //MultipleContext_ACC_M025 MC = new MultipleContext_ACC_M025();
            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ACC_M003_B_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _ACList = reader.Read<ACC_M003_B>().ToList();
                        MC.ACList = _ACList.ToList();
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
    public class MultipleContext_ACC_M003_B
    {
        public List <ACC_M003_B> ACList { get; set; }
        public List<ACC_M003_B_P> IDList { get; set; }

        public List<ACC_M003_A_P> SGList { get; set; }

    }
}
