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
    class ACC_M003_I_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ACC_M003_I MC = new MultipleContext_ACC_M003_I();
        ACC_M003_I MasterEntity = new ACC_M003_I();

        public ACC_M003_I_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M003_I_BL()
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
                    var reader = conn.QueryMultiple("ACC_M003_I_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadDataforPostingKey")
                    {
                        var _PostingKey = reader.Read<ACC_M003_I>().ToList();
                        MC.PostingKey = _PostingKey.ToList();

                        var _PostingKeyMaster = reader.Read<ACC_M003_Q_P>().ToList();
                        MC.PostingKeyMaster = _PostingKeyMaster.ToList();
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
            ACC_M003_I MasterEntity = new ACC_M003_I();
            MultipleContext_ACC_M003_I MC = new MultipleContext_ACC_M003_I();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M003_I_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<ACC_M003_I>().ToList();
                    List<ACC_M003_I> Masterlist = MasterData.ToList();

                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                }
                //strReturnData = ObjectSerializationService.ObjectToXML(MC);
                //return strReturnData;
                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
    public class MultipleContext_ACC_M003_I
    {
        public List<ACC_M003_I> MasterEntityList { get; set; }
        public List<ACC_M003_I> PostingKey { get; set; }
        public List<ACC_M003_Q_P> PostingKeyMaster { get; set; }
    }
}
