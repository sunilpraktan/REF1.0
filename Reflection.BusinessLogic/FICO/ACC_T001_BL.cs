using Dapper;
using Reflection.EF;
using Reflection.EF.ADM;
using Reflection.EF.Finance;
using Reflection.EF.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Reflection.BusinessLogic.FICO
{
    public class ACC_T001_BL : ReflectionBusinessLogic
    {
        ACC_T001 MasterEntity = new ACC_T001();
        MultipleContext_ACC_T001 MC = new MultipleContext_ACC_T001();
        public ACC_T001_BL()
        {
        }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {

                    var reader = conn.QueryMultiple("ACC_T001_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    List<ACC_T001> Masterlist = reader.Read<ACC_T001>().ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    MC.DetailEntity = reader.Read<ACC_T001_A>().ToList();
                    MC.PAYMENT_ALLOCATION = reader.Read<ACC_T001_C>().ToList();
                    MasterEntity.XmlDataDocument_ACC_T001_A = ObjectSerializationService.ObjectToXML(MC.DetailEntity);
                    MasterEntity.XmlDataDocument_ACC_T001_C = ObjectSerializationService.ObjectToXML(MC.PAYMENT_ALLOCATION);

                }
                return ObjectSerializationService.ObjectToXML(MasterEntity);
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
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ACC_T001_UPD", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    List<ACC_T001> Masterlist = reader.Read<ACC_T001>().ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    MC.DetailEntity = reader.Read<ACC_T001_A>().ToList();
                    MC.PAYMENT_ALLOCATION = reader.Read<ACC_T001_C>().ToList();
                    MasterEntity.XmlDataDocument_ACC_T001_A = ObjectSerializationService.ObjectToXML(MC.DetailEntity);
                    MasterEntity.XmlDataDocument_ACC_T001_C = ObjectSerializationService.ObjectToXML(MC.PAYMENT_ALLOCATION);
                }
                return ObjectSerializationService.ObjectToXML(MasterEntity);
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
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    int intOut = conn.Execute("ACC_T001_DEL", new { @id = Request }, commandType: CommandType.StoredProcedure);
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
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            try
            {
                string RequestOption = RequestValue.Split('!')[0];
                string RequestOption2 = "";
                if (RequestValue.Split('!').Count() >= 5)
                {
                    RequestOption2 = RequestValue.Split('!')[4];
                }
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ACC_T001_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI" || RequestOption == "LoadInitialData")
                    {
                        MC.PartyMaster = reader.Read<ADM_M028_P>().ToList();
                        MC.DocumentTypes = reader.Read<SYS_M015>().ToList();
                        MC.CompanyMaster = reader.Read<ADM_M002_P>().ToList();
                        MC.Currencys = reader.Read<ADM_M037_P>().ToList();
                        MC.GLCodes = reader.Read<ACC_M003_P>().ToList();
                        MC.SpecialGLCodes = reader.Read<ACC_M028_P>().ToList();
                        MC.PAYMENT_MODE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.ProfitCenterList = reader.Read<ACC_M020_P>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LOAD_INI_POS")
                    {
                        MC.DocumentTypes = reader.Read<SYS_M015>().ToList();
                        MC.CompanyMaster = reader.Read<ADM_M002_P>().ToList();
                        MC.Currencys = reader.Read<ADM_M037_P>().ToList();
                        MC.GLCodes = reader.Read<ACC_M003_P>().ToList();
                        MC.PAYMENT_MODE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LOAD_OPEN_DOCS" || RequestOption == "LoadOpenDocumentsOnPartySelection")
                    {
                        MC.DetailEntity = reader.Read<ACC_T001_A>().ToList();
                        MC.SalesOrderList = reader.Read<SEL_T001_P>().ToList();
                        MC.PAYMENT_ALLOCATION = reader.Read<ACC_T001_C>().ToList();
                        MC.PartyMaster = reader.Read<ADM_M028_P>().ToList(); // for POS only. it load party here not in LOAD_INI because cannot load all customer in POS.
                        if (RequestOption2 == "@AR" || RequestOption2 == "@AM")
                        {
                            MC.OpenItems = reader.Read<ACC_T001_B>().ToList();
                        }
                        
                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LOAD_DOC_DOC_NO" || RequestOption == "LoadDocumentWithDocumentNumber")
                    {
                        var MasterData = reader.Read<ACC_T001>().ToList();
                        MC.MasterEntity = MasterData.ToList();
                        if (MC.MasterEntity.Count > 0)
                        {
                            MasterEntity = MC.MasterEntity[0];
                        }
                        //MC.DetailEntity = reader.Read<ACC_T001_A>().ToList();
                        //MC.PAYMENT_ALLOCATION = reader.Read<ACC_T001_C>().ToList();
                        //MasterEntity.XmlDataDocument_ACC_T001_A = ObjectSerializationService.ObjectToXML(MC.DetailEntity);
                        //MasterEntity.XmlDataDocument_ACC_T001_C = ObjectSerializationService.ObjectToXML(MC.PAYMENT_ALLOCATION);
                        MC.DetailEntity = reader.Read<ACC_T001_A>().ToList();
                        MC.PAYMENT_ALLOCATION = reader.Read<ACC_T001_C>().ToList();
                        //if (RequestOption2 == "@AR" || RequestOption2 == "@AM")
                        //{
                        //    MC.OpenItems = reader.Read<ACC_T001_A>().ToList();
                        //    MasterEntity.XmlDataDocument_ACC_T001_B = ObjectSerializationService.ObjectToXML(MC.OpenItems);
                        //}
                        MasterEntity.XmlDataDocument_ACC_T001_A = ObjectSerializationService.ObjectToXML(MC.DetailEntity);
                        MasterEntity.XmlDataDocument_ACC_T001_C = ObjectSerializationService.ObjectToXML(MC.PAYMENT_ALLOCATION);


                        ReturnValue = ObjectSerializationService.ObjectToXML(MasterEntity);
                    }
                    else if (RequestOption == "LOAD_BACKFLIP" || RequestOption == "LoadBackFlipData")
                    {
                        MC.DocumentDataFlipGrid = reader.Read<ACC_T001_Flip>().ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadSalesPurchaseInvoice")
                    {
                        MC.SalesPurchaseInvoice = reader.Read<SEL_T003_P>().ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "Rpt_PaymentEntry")
                    {
                        MC.RptPaymentEntry = reader.Read<RptPaymentEntry>().ToList();
                        MC.RptPaymentEntryItem = reader.Read<RptPaymentEntryItem>().ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                }
                
                return ReturnValue;
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


}
