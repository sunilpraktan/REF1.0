using Reflection.EF.Project_Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Reflection.EF.Admin;
using Reflection.EF;
using Reflection.EF.CRM;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic
{
   public class ZCRM_T004_ABL : ReflectionBusinessLogic
    {
        private static string connectionString;
        ZCRM_T004_A MasterEntity = new ZCRM_T004_A();
        MultipleContext_ZCRM_T004_A MC = new MultipleContext_ZCRM_T004_A();
        public ZCRM_T004_ABL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZCRM_T004_ABL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZCRM_T004_ALoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var documentDataFlipGrid = reader.Read<ZCRM_T004_AFlip>().ToList();
                        MC.DocumentDataFlipGrid = documentDataFlipGrid.ToList();

                        var TenderDoc = reader.Read<ZCRM_T004_P>().ToList();
                        MC.TenderDocDetails = TenderDoc.ToList();

                        var DocCat = reader.Read<ZADM_M023_P>().ToList();
                        MC.TenderDocCatDetails = DocCat.ToList();
                       
                        var SubDocCat = reader.Read<ZADM_M024_P>().ToList();
                        MC.SubDocCatDetails = SubDocCat.ToList();
                      
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var MasterData = reader.Read<ZCRM_T004_A>().ToList();
                        MC.DocumentMaster = MasterData.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
        public string Insert(string Request)
        {
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZCRM_T004_AInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ZCRM_T004_AFlip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<ZCRM_T004_A>().ToList();
                    List<ZCRM_T004_A> Masterlist = MasterData.ToList();
                    MasterEntity = Masterlist[0];

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);

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
                    var reader = conn.QueryMultiple("ZCRM_T004_AUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ZCRM_T004_AFlip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<ZCRM_T004_A>().ToList();
                    List<ZCRM_T004_A> Masterlist = MasterData.ToList();
                    MasterEntity = Masterlist[0];
                }
                strReturnData = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
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
        public string Delete(int Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZCRM_T004_ADelete", new { @id = Request }, commandType: CommandType.StoredProcedure);
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
        public class MultipleContext_ZCRM_T004_A
        {
            public List<ZCRM_T004_AFlip> DocumentDataFlipGrid { get; set; }
            public List<ZCRM_T004_P> TenderDocDetails { get; set; }
            public List<ZADM_M023_P> TenderDocCatDetails { get; set; }
            public List<ZADM_M024_P> SubDocCatDetails { get; set; }          
            public List<ZCRM_T004_A> DocumentMaster { get; set; }
            public List<COM_T003> Attachment { get; set; }

        }
    }
}
