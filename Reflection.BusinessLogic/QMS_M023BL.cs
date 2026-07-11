using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.QMS;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class QMS_M023BL : ReflectionBusinessLogic
    {
        
        private static string connectionString;
        
        static int obj = 0;
   
        QMS_M023 qMS_M004 = new QMS_M023();
        public QMS_M023BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M023BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                qMS_M004 = (QMS_M023)ObjectSerializationService.XMLToObject(Request, qMS_M004);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M004Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var methodtmp = reader.Read<QMS_M023>().ToList();
                    List<QMS_M023> Inspmethod = methodtmp.ToList();
                    if (Inspmethod.Count > 0)
                    {
                        qMS_M004 = Inspmethod[0];
                    }
                   
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(qMS_M004);
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
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("QMS_M004Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);
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
                    int intOut = conn.Execute("QMS_M004Delete", new { @id = Request }, commandType: CommandType.StoredProcedure);
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

            MultipleContext_QMS_M004 MC = new MultipleContext_QMS_M004();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M004LoadAll",  commandType: CommandType.StoredProcedure);

                    var Inspmethodtmp = reader.Read<QMS_M023>().ToList();
                    MC.Inspection_method = Inspmethodtmp.ToList();
                
                    var Qulificationtmp = reader.Read<QMS_M003_PopUp>().ToList();
                    MC.Inspector_Qualification = Qulificationtmp.ToList();

                   
                }
                string strData = ObjectSerializationService.ObjectToXML(MC);
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
        public class MultipleContext_QMS_M004
        {
            public List<QMS_M023> Inspection_method { get; set; }//Inspection_method
            public List<QMS_M003_PopUp> Inspector_Qualification { get; set; }//Inspector_Qualification 

        }
    }
}
