//using Dapper;
//using Reflection.EF;
//using Reflection.EF.QMS;
//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;

//namespace Reflection.BusinessLogic
//{
//    public class QMS_T003_IP_DR_BL : ReflectionBusinessLogic
//    {
//        private static string connectionString;
//        QMS_T003 MasterEntity = new QMS_T003();
//        MultipleContext_QMS_T003 MC = new MultipleContext_QMS_T003();

//        public QMS_T003_IP_DR_BL(string BusinessEntity)
//        {
//            connectionString = base.ReflectionConnectionString;
//        }
//        public QMS_T003_IP_DR_BL()
//        {
//            connectionString = base.ReflectionConnectionString;
//        }
//        public string Insert(string Request)
//        {
//            try
//            {
//                using (IDbConnection conn = new SqlConnection(connectionString))
//                {
//                    var reader = conn.QueryMultiple("QMS_T003_IP_N_Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

//                    MC.Defect_Data = reader.Read<QMS_T003_N>().ToList();

//                    MasterEntity.XDOC_N = ObjectSerializationService.ObjectToXML(MC.Defect_Data);
//                }
//                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
//                return strReturnData;
//            }
//            catch (SqlException ex)
//            {
//                throw new CreateException(ex.ErrorCode, ex.Message, ex);
//            }
//            catch (CreateException ex)
//            {
//                throw new CreateException(ex.Message, ex);
//            }
//            catch (Exception ex)
//            {
//                throw new CreateException(ex.Message, ex);
//            }
//        }
//    }
//}
