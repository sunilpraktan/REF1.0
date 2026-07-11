using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.QMS;
using Dapper;
namespace Reflection.BusinessLogic
{
    public class QMS_M021BL : ReflectionBusinessLogic
    {        
        private static string connectionString;
        
        static int obj = 0;
     
        QMS_M021 qMS_M002 = new QMS_M021();
        public QMS_M021BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M021BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                qMS_M002 = (QMS_M021)ObjectSerializationService.XMLToObject(Request, qMS_M002);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M021Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var StockLoctntmp = reader.Read<QMS_M021>().ToList();
                    List<QMS_M021> StockLoctn = StockLoctntmp.ToList();
                    if (StockLoctn.Count > 0)
                    {
                        qMS_M002 = StockLoctn[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(qMS_M002);
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
                qMS_M002 = (QMS_M021)ObjectSerializationService.XMLToObject(Request, qMS_M002);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("QMS_M021Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);
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
        public string Delete(int Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("QMS_M021Delete", new { @id = Request }, commandType: CommandType.StoredProcedure);
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
            string strData = "";
            try
            {
                //List<QMS_M002> param = new List<QMS_M002>();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M021LoadAll", commandType: CommandType.StoredProcedure);
                    {
                       var param = reader.Read<QMS_M021>().ToList();
                       strData = ObjectSerializationService.ObjectToXML(param);
                    }             
                }
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
    }
}
