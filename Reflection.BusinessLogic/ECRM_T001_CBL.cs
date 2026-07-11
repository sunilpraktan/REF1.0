using Reflection.EF.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.Communication;


namespace Reflection.BusinessLogic
{
    public class ECRM_T001_CBL : ReflectionBusinessLogic
    {
       
        private static string connectionString;
        ECRM_T001_C MasterEntity = new ECRM_T001_C();
        MultipleContext_ECRM_T001_C MC = new MultipleContext_ECRM_T001_C();

        public ECRM_T001_CBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public ECRM_T001_CBL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ECRM_T001_CInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ECRM_T001_C_Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<ECRM_T001_C>().ToList();
                    List<ECRM_T001_C> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var ItemsData = reader.Read<ECRM_T001_D>().ToList();
                    MC.ItemsDetails = ItemsData.ToList();

                    MasterEntity.XmlDataDocument_ECRM_T001_C_Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_ECRM_T001_D = ObjectSerializationService.ObjectToXML(MC.ItemsDetails);

                }

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
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ECRM_T001_CUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ECRM_T001_C_Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<ECRM_T001_C>().ToList();
                    List<ECRM_T001_C> Masterlist = MasterData.ToList();
                    MasterEntity = Masterlist[0];

                    var ItemsData = reader.Read<ECRM_T001_D>().ToList();
                    MC.ItemsDetails = ItemsData.ToList();

                    MasterEntity.XmlDataDocument_ECRM_T001_C_Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_ECRM_T001_D = ObjectSerializationService.ObjectToXML(MC.ItemsDetails);

                }
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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ECRM_T001_CDelete", new { @sr_no = Request }, commandType: CommandType.StoredProcedure);
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ECRM_T001_CLoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        //var FlipGridData = reader.Read<ECRM_T001_C_Flip>().ToList();
                        //MC.DocumentDataFlipGrid = FlipGridData.ToList();
                        var sampleAnalysis = reader.Read<ECRM_T001_A_Sample>().ToList();
                        MC.SampleAnalysis = sampleAnalysis.ToList();
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

                    }
                    else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                    {
                        var MasterData = reader.Read<ECRM_T001_C>().ToList();
                        MC.MasterDetails = MasterData.ToList();
                        // MasterEntity = MC.MasterDetails[0];
                        var ItemsData = reader.Read<ECRM_T001_D>().ToList();
                        MC.ItemsDetails = ItemsData.ToList();
                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();
                    }
                    else if (RequestOption == "LoadBackFlipData")
                    {
                        var FlipGridData = reader.Read<ECRM_T001_C_Flip>().ToList();
                        MC.DocumentDataFlipGrid = FlipGridData.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
        public class MultipleContext_ECRM_T001_C
        {
            public List<ECRM_T001_C_Flip> DocumentDataFlipGrid { get; set; }
            public List<ECRM_T001_C> MasterDetails { get; set; }
            public List<ECRM_T001_D> ItemsDetails { get; set; }
            public List<ECRM_T001_A_Sample> SampleAnalysis { get; set; }
            public List<COM_T003> Attachment { get; set; }

        }

    }
}
