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
    public class ACC_M003_F_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ACC_M003_F MC = new MultipleContext_ACC_M003_F();
     //   ACC_M003_F MasterEntity = new ACC_M003_F();

        public ACC_M003_F_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M003_F_BL()
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
                    var reader = conn.QueryMultiple("ACC_M003_F_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadPostingRulesforKey")
                    {
                        var _MasterEntityList = reader.Read<ACC_M003_F>().ToList();
                        MC.MasterEntityList = _MasterEntityList.ToList();

                        var _TransactionEventKeyMaster = reader.Read<ACC_M003_E>().ToList();
                        MC.TransactionEventKeyMaster = _TransactionEventKeyMaster.ToList();

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
        public string Update(string Request)
        {
            ACC_M003_F MasterEntity = new ACC_M003_F();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M003_F_InsertUpdate", new { @request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<ACC_M003_F>().ToList();
                    List<ACC_M003_F> Masterlist = MasterData.ToList();

                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                      
                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
                return strReturnData;
            }
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
    public class MultipleContext_ACC_M003_F
    {
        public List<ACC_M003_F> MasterEntityList { get; set; }
        public List<ACC_M003_E> TransactionEventKeyMaster { get; set; }
    }
}
