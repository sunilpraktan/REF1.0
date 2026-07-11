//using Dapper;
//using Reflection.EF;
//using Reflection.EF.QMS;
//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;

//namespace Reflection.BusinessLogic
//{
//    public class QMS_T003_IP_UD_BL : ReflectionBusinessLogic
//    {
//        private static string connectionString;
//        QMS_T003 MasterEntity = new QMS_T003();
//        MultipleContext_QMS_T003 MC = new MultipleContext_QMS_T003();

//        public QMS_T003_IP_UD_BL(string BusinessEntity)
//        {
//            connectionString = base.ReflectionConnectionString;
//        }
//        public QMS_T003_IP_UD_BL()
//        {
//            connectionString = base.ReflectionConnectionString;
//        }
//        public string Insert(string Request)
//        {
//            try
//            {
//                using (IDbConnection conn = new SqlConnection(connectionString))
//                {
//                    var reader = conn.QueryMultiple("QMS_T003_IP_U_Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

//                    //MC.Insp_process_RR1 = reader.Read<QMS_T003_A>().ToList();
//                    ////MC.Insp_process_RR2 = reader.Read<QMS_T003_B>().ToList();
//                    //MC.Insp_process_RR3 = reader.Read<QMS_T003_C>().ToList();

//                    //MasterEntity.XmlDocument_QMS_T003_A = ObjectSerializationService.ObjectToXML(MC.Insp_process_RR1);
//                    //MasterEntity.XmlDocument_QMS_T003_C = ObjectSerializationService.ObjectToXML(MC.Insp_process_RR3);
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
