using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF;
using Reflection.EF.CRM;
using System.Collections.ObjectModel;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic
{
    public class SEL_T099BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        MultipleContext_SEL_T099 MC = new MultipleContext_SEL_T099();
        MultipleContext_SEL_T099 MCTemp = new MultipleContext_SEL_T099();

        SEL_T099 masterEntity = new SEL_T099();
        public SEL_T099BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public SEL_T099BL()
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
                    var reader = conn.QueryMultiple("SEL_T099Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<SEL_T099_Flip>().ToList();
                    MC.DocumentDataFlipGrid = flipGridData.ToList();

                    var masterData = reader.Read<SEL_T099>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    var itemData = reader.Read<SEL_T099_A>().ToList();
                    MC.ItemsEntity = itemData.ToList();


                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_SEL_T099_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);

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
                    var reader = conn.QueryMultiple("SEL_T099Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<SEL_T099_Flip>().ToList();
                    MC.DocumentDataFlipGrid = flipGridData.ToList();

                    var masterData = reader.Read<SEL_T099>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    var itemData = reader.Read<SEL_T099_A>().ToList();
                    MC.ItemsEntity = itemData.ToList();


                    if (MC.MasterEntity.Count > 0)
                    {
                        masterEntity = MC.MasterEntity[0];
                    }
                    masterEntity.XmlDataDocument_SEL_T099_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);

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
                    int intOut = conn.Execute("SEL_T099Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_SEL_T099 MC = new MultipleContext_SEL_T099();
            MultipleContext_SEL_T099 MCTemp = new MultipleContext_SEL_T099();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T099LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var flipGridData = reader.Read<SEL_T099_Flip>().ToList();
                        MC.DocumentDataFlipGrid = flipGridData.ToList();

                        var customerDetails = reader.Read<ADM_M028_P>().ToList();
                        MC.CustomerDetails = customerDetails.ToList();

                        var invoiceNoDetails = reader.Read<SEL_T003_POP>().ToList();
                        MC.InvoiceNoDetails = invoiceNoDetails.ToList();

                        var itemDetails = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemDetails = itemDetails.ToList();

                        var uomDetails = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UomDetails = uomDetails.ToList();
                      
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {

                        var masterData = reader.Read<SEL_T099>().ToList();
                        MCTemp.MasterEntity = masterData.ToList();

                        var itemData = reader.Read<SEL_T099_A>().ToList();
                        MCTemp.ItemsEntity = itemData.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MCTemp.Attachment = Attachment.ToList();

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
    public class MultipleContext_SEL_T099
    {
        public List<SEL_T099> MasterEntity { get; set; }
        public List<SEL_T099_A> ItemsEntity { get; set; }
        public List<SEL_T099_Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> CustomerDetails { get; set; }
        public List<SEL_T003_POP> InvoiceNoDetails { get; set; }
        public List<ADM_M022_P> ItemDetails { get; set; }
        public List<ADM_M038_B_P> UomDetails { get; set; }
        public List<COM_T003> Attachment { get; set; }
    }
}
