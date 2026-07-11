using Dapper;
using Reflection.EF;
using Reflection.EF.Admin;
using Reflection.EF.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    class ACC_M003_D_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ACC_M003_D MC = new MultipleContext_ACC_M003_D();
        ACC_M003_D MasterEntity = new ACC_M003_D();

        public ACC_M003_D_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M003_D_BL()
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
                    var reader = conn.QueryMultiple("ACC_M003_D_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _CoaASToComplist = reader.Read<ACC_M003_D>().ToList();
                        MC.CoaASToComplist = _CoaASToComplist.ToList();

                        var _Coalist = reader.Read<ACC_M026_P>().ToList();
                        MC.Coalist = _Coalist.ToList();

                        var _comp_codelist = reader.Read<ADM_M001_A_P>().ToList();
                        MC.comp_codelist = _comp_codelist.ToList();

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
            ADM_M001_F MasterEntity = new ADM_M001_F();
            MultipleContext_ACC_M003_D MC = new MultipleContext_ACC_M003_D();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M003_D_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _CoaASToComplist = reader.Read<ACC_M003_D>().ToList();
                    MC.CoaASToComplist = _CoaASToComplist.ToList();
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
    public class MultipleContext_ACC_M003_D
    {
        public List<ACC_M003_D> CoaASToComplist { get; set; }
        public List<ACC_M026_P> Coalist { get; set; }
        public List<ADM_M001_A_P> comp_codelist { get; set; }
    }
}



