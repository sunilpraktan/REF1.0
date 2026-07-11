using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF;
using Reflection.EF.Admin;
using Reflection.EF.Communication;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ZADM_M009BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ZADM_M009 MC = new MultipleContext_ZADM_M009();
        MultipleContext_ZADM_M009 MCTemp = new MultipleContext_ZADM_M009();
        ZADM_M009 masterEntity = new ZADM_M009();

        static int obj = 0;
              
        public ZADM_M009BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZADM_M009BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M009Insert", new { @Request = Request, @drgflnm = masterEntity.drgflnm }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<ZADM_M009_Flip>().ToList();
                    MC.DocumentDataFlipGrid = flipGridData.ToList();

                    var masterData = reader.Read<ZADM_M009>().ToList();
                    MC.MasterEntity = masterData.ToList();                  

                    masterEntity = MC.MasterEntity[0];
                   
                    masterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                }
                strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
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
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M009Update", new { @Request = Request, @drgflnm = masterEntity.drgflnm }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<ZADM_M009_Flip>().ToList();
                    MC.DocumentDataFlipGrid = flipGridData.ToList();

                    var masterData = reader.Read<ZADM_M009>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    masterEntity = MC.MasterEntity[0];

                    masterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                }
                strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
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
                    int intOut = conn.Execute("ZADM_M009Delete", new { @model_id = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_ZADM_M009 MC = new MultipleContext_ZADM_M009();
            MultipleContext_ZADM_M009 MCTemp = new MultipleContext_ZADM_M009();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M009LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var flipGridData = reader.Read<ZADM_M009_Flip>().ToList();
                        MC.DocumentDataFlipGrid = flipGridData.ToList();
                      
                        var wiresize = reader.Read<ZADM_M003_PopUp>().ToList();
                        MC.wiresize = wiresize.ToList();

                      
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {

                        var masterData = reader.Read<ZADM_M009>().ToList();
                        MCTemp.MasterEntity = masterData.ToList();

                        var AttachmentList = reader.Read<COM_T003>().ToList();
                        MCTemp.AttachmentList = AttachmentList.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MCTemp);
                    }

                }

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
       
    }
    public class MultipleContext_ZADM_M009
    {
        public List<ZADM_M009> MasterEntity { get; set; }//Model Master
        public List<ZADM_M009_Flip> DocumentDataFlipGrid { get; set; } //Flip
        public List<ZADM_M003_PopUp> wiresize { get; set; }//Wiresize Master       
        public List<COM_T003> AttachmentList { get; set; }
    }
}
