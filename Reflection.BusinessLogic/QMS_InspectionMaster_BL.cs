//using Dapper;
//using Reflection.EF;
//using Reflection.EF.QMS;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;

//namespace Reflection.BusinessLogic
//{
//    public class QMS_InspectionMaster_BL : ReflectionBusinessLogic
//    {
//        private static string connectionString;
//        QMS_T003 masterEntity = new QMS_T003();
//        MultipleContext_QMS_T003 MC = new MultipleContext_QMS_T003();
//        List<QMS_T003> MasterEntity = new List<QMS_T003>();

//        public QMS_InspectionMaster_BL(string BusinessEntity)
//        {
//            connectionString = base.ReflectionConnectionString;
//        }
//        public QMS_InspectionMaster_BL()
//        {
//            connectionString = base.ReflectionConnectionString;
//        }
//        public string GetData(string RequestValue)
//        {
//            try
//            {
//                string RequestOption = RequestValue.Split('!')[0];
//                string strReturnData = "";
                

//                using (IDbConnection conn = new SqlConnection(connectionString))
//                {
//                    var reader = conn.QueryMultiple("QMS_InspectionMaster_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

//                    if (RequestOption == "LoadInitialData")
//                    {
//                        MC.MasterEntity = reader.Read<QMS_T003>().ToList();
//                    }
//                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
//                    return strReturnData;
//                }
//            }
//            catch (SqlException ex)
//            {
//                throw new CreateException(ex.ErrorCode, ex.Message, ex);
//            }
//            catch (DivideByZeroException ex)
//            {
//                throw new CreateException(ex.Message, ex);
//            }
//            catch (Exception ex)
//            {
//                throw new CreateException(ex.Message, ex);
//            }
//        }
//        public string Update(string Request)
//        {
//            try
//            {
//                using (IDbConnection conn = new SqlConnection(connectionString))
//                {
//                    var reader = conn.QueryMultiple("QMS_InspectionMaster_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

//                    string strData = ObjectSerializationService.ObjectToXML(MC);
//                    return strData;
//                }
//            }
//            catch (SqlException ex)
//            {
//                throw new CreateException(ex.ErrorCode, ex.Message, ex);
//            }
//            catch (DivideByZeroException ex)
//            {
//                throw new CreateException(ex.Message, ex);
//            }
//            catch (Exception ex)
//            {
//                throw new CreateException(ex.Message, ex);
//            }
//        }
//    }

//    public class MC_QMS_InspectionMasterView
//    {
//        public List<QMS_T003> MasterEntity { get; set; }
//    }
//}
