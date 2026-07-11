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
    public class CRM_T004BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_CRM_T004 MC = new MultipleContext_CRM_T004();
        CRM_T004 masterEntity = new CRM_T004();
        public CRM_T004BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public CRM_T004BL()
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
                    var reader = conn.QueryMultiple("CRM_T004Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<CRM_T004_Flip>().ToList();
                    MC.DocumentDataFlipGrid = flipGridData.ToList();

                    var masterData = reader.Read<CRM_T004>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    var itemData = reader.Read<CRM_T004_A>().ToList();
                    MC.ItemsEntity = itemData.ToList();

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_CRM_T004_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
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
                    var reader = conn.QueryMultiple("CRM_T004Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<CRM_T004_Flip>().ToList();
                    MC.DocumentDataFlipGrid = flipGridData.ToList();

                    var masterData = reader.Read<CRM_T004>().ToList();
                    MC.MasterEntity = masterData.ToList();                   
                   
                    if (MC.MasterEntity.Count > 0)
                    {
                        masterEntity = MC.MasterEntity[0];
                    }
                    var itemData = reader.Read<CRM_T004_A>().ToList();
                    MC.ItemsEntity = itemData.ToList();

                    masterEntity.XmlDataDocument_CRM_T004_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
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
                    int intOut = conn.Execute("CRM_T004Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_CRM_T004 MC = new MultipleContext_CRM_T004();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("CRM_T004LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var flipGridData = reader.Read<CRM_T004_Flip>().ToList();
                        MC.DocumentDataFlipGrid = flipGridData.ToList();

                        var partyDetails = reader.Read<SEL_T003_POP>().ToList();
                        MC.PartyDetails = partyDetails.ToList();

                        var empData = reader.Read<ADM_M024_POP>().ToList();
                        MC.EmpDetails = empData.ToList();

                        var monthAndYear = reader.Read<ACC_M001A_P>().ToList();
                        MC.MonthAndYear = monthAndYear.ToList();

                        var partyType = reader.Read<ADM_M028_B_P>().ToList();
                        MC.PartyType = partyType.ToList();

                        var location = reader.Read<ADM_M003_P>().ToList();
                        MC.LocationDetails = location.ToList();

                        var company = reader.Read<ADM_M002_P>().ToList();
                        MC.CompanyDetails = company.ToList();

                        var uom = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UomDetails = uom.ToList();



                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {

                        var masterData = reader.Read<CRM_T004>().ToList();
                        MC.MasterEntity = masterData.ToList();

                        var itemData = reader.Read<CRM_T004_A>().ToList();
                        MC.ItemsEntity = itemData.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();
                    }
                    else if (RequestOption == "Load")
                    {

                        //var masterData = reader.Read<CRM_T004>().ToList();
                        //MC.MasterEntity = masterData.ToList();

                        var itemData = reader.Read<CRM_T004_A>().ToList();
                        MC.ItemsEntity = itemData.ToList();
                    }
                    else if (RequestOption == "LoadDataByMonthAndYear")
                    {

                        var masterData = reader.Read<CRM_T004>().ToList();
                        MC.MasterEntity = masterData.ToList();

                        var itemData = reader.Read<CRM_T004_A>().ToList();
                        MC.ItemsEntity = itemData.ToList();
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
    public class MultipleContext_CRM_T004
    {
        public List<CRM_T004> MasterEntity { get; set; }
        public List<CRM_T004_A> ItemsEntity { get; set; }
        public List<CRM_T004_Flip> DocumentDataFlipGrid { get; set; }
        public List<SEL_T003_POP> PartyDetails { get; set; }
        public List<ADM_M024_POP> EmpDetails { get; set; }
        public List<ACC_M001A_P> MonthAndYear { get; set; }
        public List<ADM_M028_B_P> PartyType { get; set; }
        public List<ADM_M003_P> LocationDetails { get; set; }
        public List<ADM_M002_P> CompanyDetails { get; set; }
        public List<ADM_M038_B_P> UomDetails { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public List<COM_T003> Attachment { get; set; }
    }
}
