using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF;
using Reflection.EF.Production;
using Reflection.EF.Communication;
using Reflection.EF.Production.ReportEntityProduction;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.ENG;

namespace Reflection.BusinessLogic
{
    // NOTE: Depricated
    public class ENG_T001BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ENG_T001 MC = new MultipleContext_ENG_T001();
        ENG_T001 masterEntity = new ENG_T001();
        public ENG_T001BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ENG_T001BL()
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
                    var reader = conn.QueryMultiple("ENG_T001Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<ENG_T001Flip>().ToList();
                    MC.DocumentDataFlipGrid = flipGridData.ToList();

                    var masterData = reader.Read<ENG_T001>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    var itemData = reader.Read<ENG_T001_A>().ToList();
                    MC.ItemsEntity = itemData.ToList();

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
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
                    var reader = conn.QueryMultiple("ENG_T001Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<ENG_T001Flip>().ToList();
                    MC.DocumentDataFlipGrid = flipGridData.ToList();

                    var masterData = reader.Read<ENG_T001>().ToList();
                    MC.MasterEntity = masterData.ToList();
                    masterEntity = MC.MasterEntity[0];

                    var itemData = reader.Read<ENG_T001_A>().ToList();
                    MC.ItemsEntity = itemData.ToList();

                    masterEntity.XmlDataDocument_ENG_T001_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
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
                    int intOut = conn.Execute("ENG_T001Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_ENG_T001 MC = new MultipleContext_ENG_T001();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ENG_T001LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var flipGridData = reader.Read<ENG_T001Flip>().ToList();
                        MC.DocumentDataFlipGrid = flipGridData.ToList();

                        var customerDetails = reader.Read<ADM_M028_P>().ToList();
                        MC.CustomerDetails = customerDetails.ToList();

                        var itemData = reader.Read<ADM_M022_POPUP>().ToList();
                        MC.ItemDetails = itemData.ToList();

                        var itemDatagrid = reader.Read<ADM_M022_POPUP>().ToList();
                        MC.ItemDetailsForGrid = itemDatagrid.ToList();

                        var parameterDetails = reader.Read<ADM_M031_P>().ToList();
                        MC.ParameterDetails = parameterDetails.ToList();

                        var parameterValueDetails = reader.Read<ADM_M030_P>().ToList();
                        MC.ParameterValueDetails = parameterValueDetails.ToList();

                        var uomDetails = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UOMDetails = uomDetails.ToList();

                        var bomDetails = reader.Read<SYS_M050>().ToList();
                        MC.BOMCategory = bomDetails.ToList();

                        var docTypeDetails = reader.Read<SYS_M013_P>().ToList();
                        MC.DocTypeDetails = docTypeDetails.ToList();

                        MC.Indicator_consumption = reader.Read<SYS_M040>().ToList();
                        MC.LineCategory = reader.Read<SYS_M041>().ToList();
                    }
                    if (RequestOption == "LoadDocumentByDocumentNumber")
                    {

                        var masterData = reader.Read<ENG_T001>().ToList();
                        MC.MasterEntity = masterData.ToList();

                        var itemData = reader.Read<ENG_T001_A>().ToList();
                        MC.ItemsEntity = itemData.ToList();

                        var attachmentData = reader.Read<COM_T003>().ToList();
                        MC.AttachmentData = attachmentData.ToList();
                    }
                    else if (RequestOption == "BM_Report")
                    {
                        var RptBillOfMaterialTemp = reader.Read<Rpt_BillOfMaterial>().ToList();
                        MC.RptBillOfMaterial = RptBillOfMaterialTemp.ToList();

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
    }
    public class MultipleContext_ENG_T001 // NOTE: Depricated, removed from Client project
    {
        public List<ENG_T001> MasterEntity { get; set; }
        public List<ENG_T001_A> ItemsEntity { get; set; }
        public List<ENG_T001Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> CustomerDetails { get; set; }
        public List<ADM_M022_POPUP> ItemDetails { get; set; }
        public List<ADM_M022_POPUP> ItemDetailsForGrid { get; set; }
        public List<ADM_M038_B_P> UOMDetails { get; set; }
        public List<SYS_M050> BOMCategory { get; set; }
        public List<SYS_M013_P> DocTypeDetails { get; set; }
        public List<ADM_M031_P> ParameterDetails { get; set; }
        public List<ADM_M030_P> ParameterValueDetails { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<Rpt_BillOfMaterial> RptBillOfMaterial { get; set; }
        public List<SYS_M040> Indicator_consumption { get; set; }
        public List<SYS_M041> LineCategory { get; set; }
    }
}

