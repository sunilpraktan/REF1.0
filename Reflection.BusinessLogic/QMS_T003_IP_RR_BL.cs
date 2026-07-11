//using Dapper;
//using Reflection.EF;
//using Reflection.EF.QMS;
//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;

//namespace Reflection.BusinessLogic
//{
//    public class QMS_T003_IP_RR_BL : ReflectionBusinessLogic
//    {
//        private static string connectionString;
//        QMS_T003 MasterEntity = new QMS_T003();
//        MultipleContext_QMS_T003 MC = new MultipleContext_QMS_T003();

//        public QMS_T003_IP_RR_BL(string BusinessEntity)
//        {
//            connectionString = base.ReflectionConnectionString;
//        }
//        public QMS_T003_IP_RR_BL()
//        {
//            connectionString = base.ReflectionConnectionString;
//        }
//        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
//        {
//            try
//            {
//                string RequestOption = RequestValue.Split('!')[0];
//                string strReturnData = "";

//                using (IDbConnection conn = new SqlConnection(connectionString))
//                {
//                    var reader = conn.QueryMultiple("QMS_T003_IP_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
//                    if (RequestOption == "LoadInitialData_RR")
//                    {
//                        MC.Insp_process_RR1 = reader.Read<QMS_T003_A>().ToList();
//                        //MC.Insp_process_RR2 = reader.Read<QMS_T003_B>().ToList();
//                        MC.Insp_process_RR3 = reader.Read<QMS_T003_C>().ToList();
//                        MC.Profile_Values = reader.Read<QMS_M033_A>().ToList();
//                    }
//                    if (RequestOption == "LoadInitialData_DR")
//                    {
//                        MC.Profile_Values = reader.Read<QMS_M033_A>().ToList();
//                        MC.Defect_Data = reader.Read<QMS_T003_N>().ToList();
//                    }
//                    if (RequestOption == "LoadInitialData_UD")
//                    {
//                        MC.Profile_Values = reader.Read<QMS_M033_A>().ToList();
//                        MC.Folloup_Action = reader.Read<QMS_M048>().ToList();
//                        MC.StorageLocations = reader.Read<MM_M001_P>().ToList();
//                        MC.Usage_Decision = reader.Read<QMS_T003_U>().ToList();
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
//        public string Insert(string Request)
//        {
//            try
//            {
//                using (IDbConnection conn = new SqlConnection(connectionString))
//                {
//                    var reader = conn.QueryMultiple("QMS_T003_IP_A_Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

//                    MC.Insp_process_RR1 = reader.Read<QMS_T003_A>().ToList();
//                    //MC.Insp_process_RR2 = reader.Read<QMS_T003_B>().ToList();
//                    MC.Insp_process_RR3 = reader.Read<QMS_T003_C>().ToList();

//                    MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.Insp_process_RR1);
//                    MasterEntity.XDOC_C = ObjectSerializationService.ObjectToXML(MC.Insp_process_RR3);
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
