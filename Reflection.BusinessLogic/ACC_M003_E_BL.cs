using Dapper;
using Reflection.EF;
using Reflection.EF.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Reflection.BusinessLogic
{
   public class ACC_M003_E_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ACC_M003_E MC = new MultipleContext_ACC_M003_E();
        ACC_M003_E MasterEntity = new ACC_M003_E();

        public ACC_M003_E_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M003_E_BL()
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
                    var reader = conn.QueryMultiple("ACC_M003_E_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _MasterEntityList = reader.Read<ACC_M003_E>().ToList();
                        MC.MasterEntityList = _MasterEntityList.ToList();

                        var _ModuleGroupMaster = reader.Read<ACC_M003_E1>().ToList();
                        MC.ModuleGroupMaster = _ModuleGroupMaster.ToList();

                        var _COAKeyList = reader.Read<ACC_M003_D_P>().ToList();
                        MC.COAKeyList = _COAKeyList.ToList();

                    }
                    else if (RequestOption == "FilterGL_AccountDeterminationData")
                    {
                        //var _DataGridListTemp = reader.Read<ACC_M003_E>().ToList();
                        //MC.DataGridList = _DataGridListTemp.ToList();
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
    }

    public class MultipleContext_ACC_M003_E
    {
        public List<ACC_M003_E> MasterEntityList { get; set; }
        public List<ACC_M003_E1> ModuleGroupMaster { get; set; }
        public List<ACC_M003_D_P> COAKeyList { get; set; }
    }
}
