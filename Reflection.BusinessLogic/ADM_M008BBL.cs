using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using Reflection.EF.Admin;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ADM_M008BBL : ReflectionBusinessLogic
    {
              
        private static string connectionString;
        static int obj = 0;
        ADM_M008B aDM_M008B = new ADM_M008B();

        public ADM_M008BBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M008BBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MultipleContext_ADM_M008B MC = new MultipleContext_ADM_M008B();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M008BInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var views = reader.Read<ADM_M008B>().ToList();                  
                    MC.Transactions = views.ToList();
                    aDM_M008B = MC.Transactions[0];
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M008B);
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
            try
            {
                MultipleContext_ADM_M008B MC = new MultipleContext_ADM_M008B();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M008BUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                    var views = reader.Read<ADM_M008B>().ToList();             
                    MC.Transactions = views.ToList();

                    aDM_M008B = MC.Transactions[0];
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M008B);
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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ADM_M008BDelete", new { @TranCode = Request }, commandType: CommandType.StoredProcedure);

                    return intOut.ToString();
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
        public string GetData()
        {
            try
            {
                MultipleContext_ADM_M008B MC = new MultipleContext_ADM_M008B();
                string strData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M008BLoadAll", commandType: CommandType.StoredProcedure);

                    var Transaction = reader.Read<ADM_M008B>().ToList();
                    MC.Transactions = Transaction.ToList();

                    var Location = reader.Read<ADM_M003_P>().ToList();
                    MC.Locations = Location.ToList();

                    var UserType = reader.Read<ADM_M007_P>().ToList();
                    MC.UserTypes = UserType.ToList();
                }
                strData = ObjectSerializationService.ObjectToXML(MC);
                return strData;
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
        public class MultipleContext_ADM_M008B
        {
            public List<ADM_M008B> Transactions { get; set; } //View Master
            public List<ADM_M003_P> Locations { get; set; }//Location Master
            public List<ADM_M007_P> UserTypes { get; set; }//User Type Master
        }
    }
}
