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
    class ADM_M001_D_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ADM_M001_D MC = new MultipleContext_ADM_M001_D();
        ADM_M001_D MasterEntity = new ADM_M001_D();

        public ADM_M001_D_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M001_D_BL()
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
                    var reader = conn.QueryMultiple("ADM_M001_D_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _SDlist = reader.Read<ADM_M001_D>().ToList();
                        MC.SDlist = _SDlist.ToList();
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
            ADM_M001_D MasterEntity = new ADM_M001_D();
            MultipleContext_ADM_M001_D MC = new MultipleContext_ADM_M001_D();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M001_D_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _SDlist = reader.Read<ADM_M001_D>().ToList();
                    MC.SDlist = _SDlist.ToList();
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
}
public class MultipleContext_ADM_M001_D
{
    public List<ADM_M001_D> SDlist { get; set; }
}