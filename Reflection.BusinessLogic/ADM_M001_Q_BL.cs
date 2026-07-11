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
   public class ADM_M001_Q_BL : ReflectionBusinessLogic
    {
        private static String connectionString;
        MultipleContext_ADM_M001_Q MC = new MultipleContext_ADM_M001_Q();
        ADM_M001_Q MasterEntity = new ADM_M001_Q();

        public ADM_M001_Q_BL()
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
                    var reader = conn.QueryMultiple("ADM_M001_Q_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _APList = reader.Read<ADM_M001_Q>().ToList();
                        MC.APList = _APList.ToList();

                        var _PGList = reader.Read<ADM_M001_P_P>().ToList();
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
            ADM_M001_Q MasterEntity = new ADM_M001_Q();
            MultipleContext_ADM_M001_Q MC = new MultipleContext_ADM_M001_Q();
            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ADM_M001_Q_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _APList = reader.Read<ADM_M001_Q>().ToList();
                        MC.APList = _APList.ToList();
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

    public class MultipleContext_ADM_M001_Q
    {
        public List <ADM_M001_Q> APList { get; set; }
        public List<ADM_M001_P_P> PGList { get; set; }

        public List<ADM_M001_M_P> POList { get; set; }

    }
}
