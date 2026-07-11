using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Web;
using Reflection.EF.CRM;
using System.Data;
using Dapper;
using Reflection.EF.ReflectionSystem;

namespace Reflection.BusinessLogic
{
  public class ECRM_T001_ABL : ReflectionBusinessLogic
    {
       
        private static string connectionString;

        ECRM_T001_A MasterEntity = new ECRM_T001_A();
        MultipleContext_ECRM_T001_A MC = new MultipleContext_ECRM_T001_A();

        public ECRM_T001_ABL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ECRM_T001_ABL()
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
                    var reader = conn.QueryMultiple("ECRM_T001_AInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ECRM_T001_A_Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<ECRM_T001_A>().ToList();
                    List<ECRM_T001_A> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var ItemsData = reader.Read<ECRM_T001_B>().ToList();
                    MC.ItemsDetails = ItemsData.ToList();

                    MasterEntity.XmlDataDocument_ECRM_T001_A_Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_ECRM_T001_B = ObjectSerializationService.ObjectToXML(MC.ItemsDetails);

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
                    var reader = conn.QueryMultiple("ECRM_T001_AUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ECRM_T001_A_Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<ECRM_T001_A>().ToList();
                    List<ECRM_T001_A> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var ItemsData = reader.Read<ECRM_T001_B>().ToList();
                    MC.ItemsDetails = ItemsData.ToList();

                    MasterEntity.XmlDataDocument_ECRM_T001_A_Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_ECRM_T001_B = ObjectSerializationService.ObjectToXML(MC.ItemsDetails);

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
                    int intOut = conn.Execute("ECRM_T001_ADelete", new { @sa_no = Request }, commandType: CommandType.StoredProcedure);
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
                    var reader = conn.QueryMultiple("ECRM_T001_ALoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        //var FlipGridData = reader.Read<ECRM_T001_A_Flip>().ToList();
                        //MC.DocumentDataFlipGrid = FlipGridData.ToList();

                        var unitList = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UnitList = unitList.ToList();

                        var salesOrg = reader.Read<ADM_M001_A_P>().ToList();
                        MC.SalesOrg = salesOrg.ToList();

                        var salesGroup = reader.Read<ADM_M001_H_P>().ToList();
                        MC.SalesGroup = salesGroup.ToList();

                        var documentTypes = reader.Read<SYS_M002>().ToList();
                        MC.DocumentTypes = documentTypes.ToList();

                        var _SampleFrmList = reader.Read<ADM_M028_P>().ToList();
                        MC.SampleFrmList = _SampleFrmList.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                       
                    }
                       else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                    {
                        var MasterData =reader.Read<ECRM_T001_A>().ToList();
                        MC.MasterDetails = MasterData.ToList();               
                        var ItemsData = reader.Read<ECRM_T001_B>().ToList();
                        MC.ItemsDetails = ItemsData.ToList();
             
                    }
                    else if (RequestOption == "rptSampleAnalysis")
                    {
                        var SampleAnaRpt = reader.Read<SalesInvoice_SingleReport>().ToList();
                        MC.RptSampleAnalysis = SampleAnaRpt.ToList();
                        //var SampleA_Details1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<Reflection.BusinessLogic.SEL_T003BL.SalesInvoice_SingleReport>(reader).ToList();
                        //MC.RptSalesAnalysis = SampleA_Details1.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;
                    }
                    else if (RequestOption == "LoadBackFlipData")
                    {
                        var FlipGridData = reader.Read<ECRM_T001_A_Flip>().ToList();
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
    }
  public class MultipleContext_ECRM_T001_A
  {
        public List<ECRM_T001_A_Flip> DocumentDataFlipGrid { get; set; }
        public List<ECRM_T001_A> MasterDetails { get; set; }                       
        public List<ECRM_T001_B> ItemsDetails { get; set; }                                 
        public List<ADM_M038_B_P> UnitList { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M028_P> SampleFrmList { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public List<SalesInvoice_SingleReport> RptSampleAnalysis { get; set; }
        public List<SYS_M002> DocumentTypes { get; set; }

    }
}
