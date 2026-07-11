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
    class ADM_M003_C_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ADM_M003_C MC = new MultipleContext_ADM_M003_C();
        ADM_M001_F MasterEntity = new ADM_M001_F();

        public ADM_M003_C_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M003_C_BL()
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
                    var reader = conn.QueryMultiple("ADM_M003_C_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _BussinessPlaceList = reader.Read<ADM_M003_C>().ToList();
                        MC.BPList = _BussinessPlaceList.ToList();

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
            ADM_M003_C MasterEntity = new ADM_M003_C();
            MultipleContext_ADM_M003_C MC = new MultipleContext_ADM_M003_C();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M003_C_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _BussinessPlaceList = reader.Read<ADM_M003_C>().ToList();
                    MC.BPList = _BussinessPlaceList.ToList();
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
    public class MultipleContext_ADM_M003_C
    {
        public List<ADM_M003_C> BPList { get; set; }
        public List<ADM_M012_P> CountryList { get; set; }
        public List<ADM_M013_P> StateList { get; set; }
    }
}
