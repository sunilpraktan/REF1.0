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
    class ADM_M001_P_BL : ReflectionBusinessLogic
    {
    
        private static string connectionString;
        MultipleContext_ADM_M001_P MC = new MultipleContext_ADM_M001_P();
        ADM_M001_P MasterEntity = new ADM_M001_P();

        public ADM_M001_P_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M001_P_BL()
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
                    var reader = conn.QueryMultiple("ADM_M001_P_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _PGList = reader.Read<ADM_M001_P>().ToList();
                        MC.PGList = _PGList.ToList();

                        var _POList = reader.Read<ADM_M001_M_P>().ToList();
                        MC.POList = _POList.ToList();                        

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
            ADM_M001_P MasterEntity = new ADM_M001_P();
            MultipleContext_ADM_M001_P MC = new MultipleContext_ADM_M001_P();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M001_P_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _PGList = reader.Read<ADM_M001_P>().ToList();
                    MC.PGList = _PGList.ToList();
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
    public class MultipleContext_ADM_M001_P
    {
        public List<ADM_M001_P> PGList { get; set; }
        public List<ADM_M001_M_P> POList { get; set; }

    }
}
