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
    public class ACC_M003_A_BL : ReflectionBusinessLogic
    {
        private static String connectionString;
        ACC_M003_A MasterEntity = new ACC_M003_A();
        MultipleContext_ACC_M003_A MC = new MultipleContext_ACC_M003_A();

        public ACC_M003_A_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M003_A_BL()
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
                    var reader = conn.QueryMultiple("ACC_M003_A_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    if (RequestOption == "LoadInitialData")
                    {
                        var _AccGrouplist = reader.Read<ACC_M003_A>().ToList();
                        MC.AccGrouplist = _AccGrouplist.ToList();

                        var _GrpCategoryList = reader.Read<ACC_M003_C_P>().ToList();
                        MC.GrpCategoryList = _GrpCategoryList.ToList();

                        var _Coalist = reader.Read<ACC_M026_P>().ToList();
                        MC.COAKeyList = _Coalist.ToList();
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
            //ACC_M003_A MasterEntity = new ACC_M003_A();
           // MultipleContext_ACC_M003_A MC = new MultipleContext_ACC_M003_A();

            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var Reader = conn.QueryMultiple("ACC_M003_A_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _AccGrouplist = Reader.Read<ACC_M003_A>().ToList();
                        MC.AccGrouplist = _AccGrouplist.ToList();
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
    public class MultipleContext_ACC_M003_A
    {
        public List<ACC_M003_A> AccGrouplist { get; set; }
        public List<ACC_M003_C_P> GrpCategoryList { get; set; }
        public List<ACC_M026_P> COAKeyList { get; set; }
    }
}