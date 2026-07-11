//using Dapper;
//using Reflection.EF;
//using Reflection.EF.QMS;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Reflection.BusinessLogic
//{
//    // Depricated. Deletion Marked.
//   public class QMS_M034_BL : ReflectionBusinessLogic
//    {
//        private static string connectionString;
//        QMS_M0034 masterEntity = new QMS_M0034();
//        MultipleContext_QMS_M034 MC = new MultipleContext_QMS_M034();

//        public QMS_M034_BL(string BusinessEntity)
//        {
//            connectionString = base.ReflectionConnectionString;
//        }
//        public QMS_M034_BL()
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
//                    var reader = conn.QueryMultiple("QMS_M034_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

//                    if (RequestOption == "LoadInitialData")
//                    {
//                        var BackFlip = reader.Read<QMS_M034_Flip>().ToList();
//                        MC.BackFlipData = BackFlip.ToList();

//                        var sampletypedata = reader.Read<QMS_M037_P>().ToList();
//                        MC.SampleTypeMaster = sampletypedata.ToList();

//                        var valuationmodedata = reader.Read<QMS_M036_P>().ToList();
//                        MC.ValuationMode= valuationmodedata.ToList();

//                        var InspectionSeverity = reader.Read<QMS_M038_P>().ToList();
//                        MC.InspSeverity = InspectionSeverity.ToList();

//                        var sampleScheme = reader.Read<QMS_M035_P>().ToList();
//                        MC.SampleScheme = sampleScheme.ToList();
//                    }
//                    else if (RequestOption == "LoadDocumentByDocumentNumber")
//                    {
//                        var MasterData = reader.Read<QMS_M034>().ToList();
//                        MC.MasterEntity = MasterData.ToList();

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
//                    var reader = conn.QueryMultiple("QMS_M034_Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

//                    var BackFlip = reader.Read<QMS_M034_Flip>().ToList();
//                    MC.BackFlipData = BackFlip.ToList();

//                    var masterData = reader.Read<QMS_M034>().ToList();
//                    MC.MasterEntity = masterData.ToList();

//                    masterEntity = MC.MasterEntity[0];
//                    masterEntity.XmlDataDocument_QMS_M034_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);
                    

//                }
//                string strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
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

//        public string Update(string Request)
//        {
//            try
//            {
//                string strReturnData = "";
//                using (IDbConnection conn = new SqlConnection(connectionString))
//                {
//                    var reader = conn.QueryMultiple("QMS_M034_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

//                    var BackFlip = reader.Read<QMS_M034_Flip>().ToList();
//                    MC.BackFlipData = BackFlip.ToList();

//                    var masterData = reader.Read<QMS_M034>().ToList();
//                    MC.MasterEntity = masterData.ToList();

//                    masterEntity = MC.MasterEntity[0];
//                    masterEntity.XmlDataDocument_QMS_M034_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);
//                }
//                strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
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

//    public class MultipleContext_QMS_M034
//    {
//        public List<QMS_M034_Flip> BackFlipData { get; set; }
//        public List<QMS_M037_P> SampleTypeMaster { get; set; }
//        public List<QMS_M036_P> ValuationMode { get; set; }
//        public List<QMS_M038_P> InspSeverity { get; set; }
//        public List<QMS_M035_P> SampleScheme { get; set; }
//        public List<QMS_M0034> MasterEntity { get; set; }
//    }
//}
