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
using System.Collections.ObjectModel;

namespace Reflection.BusinessLogic
{
    public class ADM_M001_O1_BL : ReflectionBusinessLogic
    {

        private static String connectionString;
        MultipleContext_ADM_M001_O MC = new MultipleContext_ADM_M001_O();
        ADM_M001_O MasterEntity = new ADM_M001_O();


        public ADM_M001_O1_BL(String BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public ADM_M001_O1_BL()
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
                    var reader = conn.QueryMultiple("ADM_M001_O_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var POCode = reader.Read<ADM_M001_O>().ToList();
                        MC.POCode = POCode.ToList();

                        var PurOrg = reader.Read<ADM_M001_M_P>().ToList();
                        MC.PurOrg = PurOrg .ToList();

                        var Location = reader.Read<ADM_M003_P>().ToList();
                        MC.Location = Location.ToList();

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
            ADM_M001_O MasterEntity = new ADM_M001_O();
            MultipleContext_ADM_M001_O MC = new MultipleContext_ADM_M001_O();
            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ADM_M001_O_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var POCode = reader.Read<ADM_M001_O>().ToList();
                        MC.POCode = POCode.ToList();
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


    public class MultipleContext_ADM_M001_O
    {
        public List<ADM_M001_O> POCode  { get; set; }
        public List<ADM_M001_M_P> PurOrg { get; set; }
        public List<ADM_M003_P> Location { get; set; }

    }


}

