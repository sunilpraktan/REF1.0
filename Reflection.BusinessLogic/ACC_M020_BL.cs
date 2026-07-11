using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;


namespace Reflection.BusinessLogic
{
    public class ACC_M020_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ACC_M020 MC = new MultipleContext_ACC_M020();
        ACC_M020 MasterEntity = new ACC_M020();

        public ACC_M020_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M020_BL()
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
                    var reader = conn.QueryMultiple("ACC_M020_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _ProfitList = reader.Read<ACC_M020>().ToList();
                        MC.ProfitList = _ProfitList.ToList();

                        var _DepartmentList = reader.Read<ADM_M025_P>().ToList();
                        MC.DepartmentList = _DepartmentList.ToList();

                        var _CurrencyList = reader.Read<ADM_M037_P>().ToList();
                        MC.CurrencyList = _CurrencyList.ToList();
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
            ACC_M020 MasterEntity = new ACC_M020();
            MultipleContext_ACC_M020 MC = new MultipleContext_ACC_M020();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M020_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _ProfitList = reader.Read<ACC_M020>().ToList();
                    MC.ProfitList = _ProfitList.ToList();

                }
                strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M020_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _ProfitList = reader.Read<ACC_M020>().ToList();
                    MC.ProfitList = _ProfitList.ToList();


                }
                strReturnData = ObjectSerializationService.ObjectToXML(MC);
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

    }



    public class MultipleContext_ACC_M020
    {
        public List<ACC_M020> ProfitList { get; set; }
        public List<ADM_M025_P> DepartmentList { get; set; }
        public List<ADM_M037_P> CurrencyList { get; set; }
    }
}
