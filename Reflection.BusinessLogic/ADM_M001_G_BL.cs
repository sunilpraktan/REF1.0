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
    public class ADM_M001_G_BL : ReflectionBusinessLogic
    {
        private static String connectionString;
        MultipleContext_ADM_M001_G MC = new MultipleContext_ADM_M001_G();
        ADM_M001_G MasterEntity = new ADM_M001_G();

        public ADM_M001_G_BL(String BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public ADM_M001_G_BL()
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
                    var reader = conn.QueryMultiple("ADM_M001_G_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _SPList = reader.Read<ADM_M001_G>().ToList();
                        MC.SPList = _SPList.ToList();

                        var _SOList = reader.Read<ADM_M001_A_P>().ToList();
                        MC.SOList = _SOList.ToList();

                        var _DCList = reader.Read<ADM_M001_C_P>().ToList();
                        MC.DCList = _DCList.ToList();

                        var _PntList = reader.Read<ADM_M003_P>().ToList();
                        MC.PntList = _PntList.ToList();

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
            ADM_M001_G MasterEntity = new ADM_M001_G();
            MultipleContext_ADM_M001_G MC = new MultipleContext_ADM_M001_G();
            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader=Conn.QueryMultiple("ADM_M001_G_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _SPList = reader.Read<ADM_M001_G>().ToList();
                        MC.SPList = _SPList.ToList();
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
    public class MultipleContext_ADM_M001_G
    {
        public List<ADM_M001_G> SPList { get; set; }
        public List<ADM_M001_A_P> SOList { get; set; }
        public List<ADM_M001_C_P> DCList { get; set; }
        public List<ADM_M003_P> PntList { get; set; }
    }
}