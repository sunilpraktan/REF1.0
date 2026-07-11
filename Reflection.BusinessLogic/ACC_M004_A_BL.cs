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
    public class ACC_M004_A_BL : ReflectionBusinessLogic
    {
        private static String connectionString;
        ACC_M004_A MasterEntity = new ACC_M004_A();
        MultipleContext_ACC_M004_A MC = new MultipleContext_ACC_M004_A();

        public ACC_M004_A_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M004_A_BL()
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
                    var reader = conn.QueryMultiple("ACC_M004_A_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    if (RequestOption == "LoadInitialData")
                    {
                        var _CompBankAccList = reader.Read<ACC_M004_A>().ToList();
                        MC.CompBankAccList = _CompBankAccList.ToList();

                        var _BankCodeList = reader.Read<ACC_M004_P>().ToList();
                        MC.BankCodeList = _BankCodeList.ToList();

                        var _CountryList = reader.Read<ADM_M012_P>().ToList();
                        MC.CountryList = _CountryList.ToList();
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
                        var reader = conn.QueryMultiple("ACC_M004_A_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _CompBankAccList = reader.Read<ACC_M004_A>().ToList();
                        MC.CompBankAccList = _CompBankAccList.ToList();
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
    public class MultipleContext_ACC_M004_A
    {
        public List<ACC_M004_A> CompBankAccList { get; set; }
        public List<ACC_M004_P> BankCodeList { get; set; }
        public List<ADM_M012_P> CountryList { get; set; }
    }
}
