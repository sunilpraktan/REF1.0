using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF;
using Reflection.EF.Finance;
using System.Collections.ObjectModel;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic
{
    public class ACC_T005BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ACC_T005 MC = new MultipleContext_ACC_T005();
        MultipleContext_ACC_T005 MCTemp = new MultipleContext_ACC_T005();
        ACC_T005 masterEntity = new ACC_T005();
        public ACC_T005BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_T005BL()
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
                    var reader = conn.QueryMultiple("ACC_T005Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<ACC_T005_Flip>().ToList();
                    MC.DocumentDataFlipGrid = flipGridData.ToList();

                    var masterData = reader.Read<ACC_T005>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    var itemData = reader.Read<ACC_T005_A>().ToList();
                    MC.ItemsEntity = itemData.ToList();


                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_ACC_T005_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);

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
                    var reader = conn.QueryMultiple("ACC_T005Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<ACC_T005_Flip>().ToList();
                    MC.DocumentDataFlipGrid = flipGridData.ToList();

                    var masterData = reader.Read<ACC_T005>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    var itemData = reader.Read<ACC_T005_A>().ToList();
                    MC.ItemsEntity = itemData.ToList();

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_ACC_T005_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);

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
                    int intOut = conn.Execute("ACC_T005Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
                    var reader = conn.QueryMultiple("ACC_T005LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var flipGridData = reader.Read<ACC_T005_Flip>().ToList();
                        MC.DocumentDataFlipGrid = flipGridData.ToList();

                        var customerDetails = reader.Read<ADM_M028_P>().ToList();
                        MC.CustomerDetails = customerDetails.ToList();

                        var salesOrderAndQuotation = reader.Read<SEL_T001_QN>().ToList();
                        MC.SalesOrderAndQuotation = salesOrderAndQuotation.ToList();

                        var empData = reader.Read<ADM_M024_POP>().ToList();
                        MC.EmpDetails = empData.ToList();

                        var headDatagrid = reader.Read<ACC_T003_B_P>().ToList();
                        MC.HeadDetailsForGrid = headDatagrid.ToList();

                        var glcodeDetails = reader.Read<ACC_M003_P>().ToList();
                        MC.GlcodeDetails = glcodeDetails.ToList();

                        var location = reader.Read<ADM_M003_P>().ToList();
                        MC.LocationMaster = location.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {

                        var masterData = reader.Read<ACC_T005>().ToList();
                        MCTemp.MasterEntity = masterData.ToList();

                        var itemData = reader.Read<ACC_T005_A>().ToList();
                        MCTemp.ItemsEntity = itemData.ToList();

                        //var Attachment = reader.Read<COM_T003>().ToList();
                        //MCTemp.Attachment = Attachment.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MCTemp);
                    }
                    else if (RequestOption == "LoadSOAndQuotationDetails")
                    {
                        var salesOrderAndQuotation = reader.Read<SEL_T001_QN>().ToList();
                        MC.SalesOrderAndQuotation = salesOrderAndQuotation.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);                 
                    }
                    else if(RequestOption== "LoadExpectedPaymentRpt")
                    {

                        var masterData = reader.Read<ACC_T005>().ToList();
                        MCTemp.MasterEntity = masterData.ToList();

                        var itemData = reader.Read<ACC_T005_A>().ToList();
                        MCTemp.ItemsEntity = itemData.ToList();

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
    public class MultipleContext_ACC_T005
    {
        public List<ACC_T005> MasterEntity { get; set; }
        public List<ACC_T005_A> ItemsEntity { get; set; }
        public List<ACC_T005_Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> CustomerDetails { get; set; }
        public List<ACC_T003_B_P> HeadDetailsForGrid { get; set; }
        public List<ACC_M003_P> GlcodeDetails { get; set; }
        public List<ADM_M003_P> LocationMaster { get; set; }
        public List<ADM_M024_POP> EmpDetails { get; set; }
        public List<SEL_T001_QN> SalesOrderAndQuotation { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public List<ACC_T005Rpt> ExpectedPaymentRpt { get; set; }
        public List<COM_T003> Attachment { get; set; }
    }
}
