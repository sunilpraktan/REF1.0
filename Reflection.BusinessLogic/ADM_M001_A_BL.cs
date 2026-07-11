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
    class ADM_M001_A_BL : ReflectionBusinessLogic
    {
        private static string connectionString;  
        MultipleContext_ADM_M001_A MC = new MultipleContext_ADM_M001_A();
        ADM_M001_A MasterEntity = new ADM_M001_A();

        public ADM_M001_A_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M001_A_BL()
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
                    var reader = conn.QueryMultiple("ADM_M001_A_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _SOList = reader.Read<ADM_M001_A>().ToList();
                        MC.SOList = _SOList.ToList();

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
            ADM_M001_A MasterEntity = new ADM_M001_A();
            MultipleContext_ADM_M001_A MC = new MultipleContext_ADM_M001_A();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M001_A_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _SOList = reader.Read<ADM_M001_A>().ToList();
                    MC.SOList = _SOList.ToList();
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
    public class MultipleContext_ADM_M001_A
    {
        public List<ADM_M001_A> SOList { get; set; }
        public List<ADM_M012_P> CountryList { get; set; }
        public List<ADM_M013_P> StateList { get; set; }
    }
}
