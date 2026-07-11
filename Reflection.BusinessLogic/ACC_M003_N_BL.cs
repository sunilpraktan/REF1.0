using Dapper;
using Reflection.EF;
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
    class ACC_M003_N_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ACC_M003_N MC = new MultipleContext_ACC_M003_N();
        ACC_M003_N MasterEntity = new ACC_M003_N();

        public ACC_M003_N_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M003_N_BL()
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
                    var reader = conn.QueryMultiple("ACC_M003_NLoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _PricingProEntity = reader.Read<ACC_M003_N>().ToList();
                        MC.PricingProEntity = _PricingProEntity.ToList();

                        var _ConditionType = reader.Read<ACC_M003_O_P>().ToList();
                        MC.ConditionType = _ConditionType.ToList();

                        var _TransactionKey = reader.Read<ACC_M003_E_P>().ToList();
                        MC.TransactionKey = _TransactionKey.ToList();
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
            ACC_M003_N MasterEntity = new ACC_M003_N();
            MultipleContext_ACC_M003_N MC = new MultipleContext_ACC_M003_N();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M003_N_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _PricingProEntity = reader.Read<ACC_M003_N>().ToList();
                    MC.PricingProEntity = _PricingProEntity.ToList();

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
    public class MultipleContext_ACC_M003_N
    {
        //public List<ACC_M003_X> MasterEntity { get; set; }        
        public List<ACC_M003_N> PricingProEntity { get; set; }
        public List<ACC_M003_O_P> ConditionType { get; set; }
        public List<ACC_M003_E_P> TransactionKey { get; set; }
    }
}
