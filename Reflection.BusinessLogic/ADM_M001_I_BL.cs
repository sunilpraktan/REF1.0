using Dapper;
using Reflection.EF;
using Reflection.EF.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class ADM_M001_I_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ADM_M001_I MC = new MultipleContext_ADM_M001_I();
        ADM_M001_I MasterEntity = new ADM_M001_I();

        public ADM_M001_I_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M001_I_BL()
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
                    var reader = conn.QueryMultiple("ADM_M001_I_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _SalesOffList = reader.Read<ADM_M001_I>().ToList();
                        MC.SalesOffList = _SalesOffList.ToList();

                        var _CountryList = reader.Read<ADM_M012_P>().ToList();
                        MC.CountryList = _CountryList.ToList();

                        var _StateList = reader.Read<ADM_M013_P>().ToList();
                        MC.StateList = _StateList.ToList();       
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
            ADM_M001_I MasterEntity = new ADM_M001_I();
            MultipleContext_ADM_M001_I MC = new MultipleContext_ADM_M001_I();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M001_I_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _SalesOffList = reader.Read<ADM_M001_I>().ToList();
                    MC.SalesOffList = _SalesOffList.ToList();

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
                    var reader = conn.QueryMultiple("ADM_M001_I_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _SalesOffList = reader.Read<ADM_M001_I>().ToList();
                    MC.SalesOffList = _SalesOffList.ToList();

                    
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

    public class MultipleContext_ADM_M001_I
    {
        public List<ADM_M001_I> SalesOffList { get; set; }
        public List<ADM_M013_P> StateList { get; set; }
        public List<ADM_M012_P> CountryList { get; set; }
    }
}
