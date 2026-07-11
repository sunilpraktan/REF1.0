using Dapper;
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
    class ACC_M003_X_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ACC_M003_X MC = new MultipleContext_ACC_M003_X();
        ACC_M003_X MasterEntity = new ACC_M003_X();

        public ACC_M003_X_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M003_X_BL()
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
                    var reader = conn.QueryMultiple("ACC_M003_XLoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _TransactionKey = reader.Read<ACC_M003_X>().ToList();
                        MC.TransactionKeyEntity = _TransactionKey.ToList();                        
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
            ACC_M003_X MasterEntity = new ACC_M003_X();
            MultipleContext_ACC_M003_X MC = new MultipleContext_ACC_M003_X();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M003_XInsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var TK = reader.Read<ACC_M003_X>().ToList();
                    MC.TransactionKeyEntity = TK.ToList();
                    
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
        public string Update(string Request)
        {
            string strReturnData = "";
            //    ACC_M003_T MasterEntity = new ACC_M003_T();
            //    MultipleContext_ACC_M003_T MC = new MultipleContext_ACC_M003_T();
            //    try
            //    {
            //        using (IDbConnection conn = new SqlConnection(connectionString))
            //        {

            //            var reader = conn.QueryMultiple("ACC_M003_TInsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

            //            var DetailData = reader.Read<ACC_M003_T>().ToList();
            //            MC.AccountDeterminationList = DetailData.ToList();

            //            MasterEntity.XmlDataDocument_ACC_M003_T = ObjectSerializationService.ObjectToXML(MC.AccountDeterminationList);
            //        }

            //        strReturnData = ObjectSerializationService.ObjectToXML(MC);
            return strReturnData;


        //    }
        //    catch (SqlException ex)
        //    {

        //        throw new CreateException(ex.ErrorCode, ex.Message, ex);
        //    }
        //    catch (CreateException ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        }
    }
    public class MultipleContext_ACC_M003_X
    {
        //public List<ACC_M003_X> MasterEntity { get; set; }
        public List<ACC_M003_X> TransactionKeyEntity { get; set; }
    }    
}
