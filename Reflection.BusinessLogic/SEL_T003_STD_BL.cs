using System;
using System.Linq;
using Reflection.EF.CRM;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.CRM.ReportEntityCRM;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.Finance;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    public class SEL_T003_STD_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        SEL_T003 MasterEntity = new SEL_T003();
        public SEL_T003_STD_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public SEL_T003_STD_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T003Insert", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    MultipleContext_SEL_T003 MC = new MultipleContext_SEL_T003();

                    MC.DocumentDataFlipGrid = reader.Read<SEL_T003Flip>().ToList();
                    MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                    MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                    MC.TaxEntity = reader.Read<ACC_T006_C>().ToList(); ;
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }
                    MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                    MasterEntity.XmlDataDocument_SEL_T003_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = ObjectSerializationService.ObjectToXML(MC.TaxEntity);
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_ACC_T006_D = ObjectSerializationService.ObjectToXML(MC.LicenceEntity);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T003Update", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    MultipleContext_SEL_T003 MC = new MultipleContext_SEL_T003();

                    MC.DocumentDataFlipGrid = reader.Read<SEL_T003Flip>().ToList();
                    MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                    MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                    MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }
                    MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                    MasterEntity.XmlDataDocument_SEL_T003_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = ObjectSerializationService.ObjectToXML(MC.TaxEntity);
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_ACC_T006_D = ObjectSerializationService.ObjectToXML(MC.LicenceEntity);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
                    int intOut = conn.Execute("SEL_T003Delete", new { @bill_doc = Request }, commandType: CommandType.StoredProcedure);
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
            try
            {
                MultipleContext_SEL_T003 MC = new MultipleContext_SEL_T003();
                string RequestOption = RequestValue.Split('!')[0];
                string strReturnData = "";

                if (RequestOption != "ValidateInvoice")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("SEL_T003_STD_LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            MC.PartyMaster = reader.Read<ADM_M028_P>().ToList();
                            MC.Sales_Invoice_Reference = reader.Read<SEL_T003_P_RefDoc>().ToList();
                            MC.TaxList = reader.Read<ACC_M013_P>().ToList();
                            MC.BanksList = reader.Read<ACC_M004_P>().ToList();
                            MC.CurrencysList = reader.Read<ADM_M037_P>().ToList();
                            MC.ServiceProviders = reader.Read<ADM_M028_P>().ToList();
                            MC.LicenseAdvance = reader.Read<ADM_M041_P>().ToList();
                            MC.LicenseEPCG = reader.Read<ADM_M041_P>().ToList();
                            MC.CountryList = reader.Read<ADM_M012_P>().ToList();
                            MC.Product_Description = reader.Read<ADM_M020_P>().ToList();
                            MC.PayTerms = reader.Read<ACC_M007_P>().ToList();
                            MC.Cost_Centers = reader.Read<ACC_M019_P>().ToList();
                            MC.UnitList = reader.Read<ADM_M038_B_P>().ToList();
                            MC.doc_typeList = reader.Read<SYS_M002>().ToList();
                            MC.NotificationData = reader.Read<NotificationData>().ToList();
                            MC.DocCategoryList = reader.Read<SYS_M002>().ToList();
                            MC.ConditionTypeList = reader.Read<ACC_M003_O_P>().ToList();
                            MC.LicenceList = reader.Read<ADM_M041_P>().ToList();
                            MC.BussinessPlaceList = reader.Read<ADM_M003_C_P>().ToList();
                            MC.Report_DataList2 = reader.Read<Report_Data_P>().ToList();
                            MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                            MC.GSTDeclaration = reader.Read<ADM_M063_P>().ToList();
                            MC.Invoice = reader.Read<SEL_T003_P>().ToList();
                            MC.TransportMode = reader.Read<SYS_M026>().ToList();
                            MC.Trade_Types = reader.Read<SYS_M037>().ToList();
                            MC.hbList = reader.Read<ACC_M004_P>().ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadFromSoldToPartyDetails")
                        {
                            MC.PartysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();
                            MC.CustCatlogNo = reader.Read<CRM_T001A_P>().ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadFromCatlogNo")
                        {
                            MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadHistory")
                        {
                            MC.DocumentDataFlipGrid = reader.Read<SEL_T003Flip>().ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadBackFlipData")
                        {
                            MC.DocumentDataFlipGrid = reader.Read<SEL_T003Flip>().ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadDelivery")
                        {
                            MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadSalesOrder")
                        {
                            MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadDocumentFromDeliveryNo")
                        {
                            MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                            MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                            MC.PartysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.withholdinglist = reader.Read<ACC_M025_P>().ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")// for Referance document
                        {
                            MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                            MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                            MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                            MC.Attachment = reader.Read<COM_T003>().ToList();
                            MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();//this is load from sold to party
                            MC.PartysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.CustCatlogNo = reader.Read<CRM_T001A_P>().ToList();
                            MC.withholdinglist = reader.Read<ACC_M025_P>().ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "LoadDocumentWithDocumentNumber")
                        {
                            MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                            MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                            MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                            MC.Attachment = reader.Read<COM_T003>().ToList();
                            MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();
                            MC.PartysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.CustCatlogNo = reader.Read<CRM_T001A_P>().ToList();
                            MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                            MC.withholdinglist = reader.Read<ACC_M025_P>().ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "LoadDocumentFromSalesOrderReferneceNo")
                        {
                            MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                            MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                            MC.PartysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.withholdinglist = reader.Read<ACC_M025_P>().ToList();
                            MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "LoadDocumentFromSalesOrderDeliverySchedule")
                        {
                            MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                            MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                            MC.PartysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.withholdinglist = reader.Read<ACC_M025_P>().ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "SI_Report")
                        {
                            MC.RptSalesInvoice = reader.Read<RptSalesInvoice>().ToList();
                            MC.RptSalesInvoiceItem = reader.Read<RptSalesInvoiceItem>().ToList();
                            MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                            MC.ScheduleItemsEntity = reader.Read<SEL_T002_A>().ToList();
                            MC.PaymentDetail = reader.Read<ACC_T001_A>().ToList();
                            MC.Report_DataList = reader.Read<Report_Data_P>().ToList();
                            MC.CalcValues = reader.Read<ADM_M058_A_P>().ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "Item_packingDetail")
                        {
                            MC.RptItemPackingDetailList = reader.Read<RptItemPackingDetail>().ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "BatchDetail" || RequestOption == "WeightPackingDetail")
                        {
                            MC.RptBatchDetailList = reader.Read<RptBatchDetail>().ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "BatchSummary")
                        {
                            MC.RptBatchDetailList = reader.Read<RptBatchDetail>().ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "BatchDetail2")
                        {
                            MC.RptBatchDetailList = reader.Read<RptBatchDetail>().ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "Refresh")
                        {
                            MC.Sales_Invoice_Reference = reader.Read<SEL_T003_P_RefDoc>().ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        return strReturnData;
                    }
                }
                else if (RequestOption == "ValidateInvoice")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("SEL_T003Validate", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                        MC.MasterEntity = reader.Read<SEL_T003>().ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;
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
}
