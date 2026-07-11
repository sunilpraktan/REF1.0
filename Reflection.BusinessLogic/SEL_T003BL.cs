using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF.CRM;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.CRM.ReportEntityCRM;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.SCM.ReportEntitySCM;
using Reflection.EF.Admin;
using Reflection.EF.Finance;
using Reflection.EF.SCM;
using Reflection.EF.GEN;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    public class SEL_T003BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        SEL_T003 MasterEntity = new SEL_T003();
        public SEL_T003BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public SEL_T003BL()
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

                    var FlipGridData = reader.Read<SEL_T003Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<SEL_T003>().ToList();
                    MC.MasterEntity = MasterData.ToList();

                    var ItemsData = reader.Read<SEL_T003_A>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();

                    var TaxData = reader.Read<ACC_T006_C>().ToList(); ;
                    MC.TaxEntity = TaxData.ToList();
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }

                    var Licence_Data = reader.Read<ACC_T006_D>().ToList();
                    MC.LicenceEntity = Licence_Data.ToList();

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

                    var FlipGridData = reader.Read<SEL_T003Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<SEL_T003>().ToList();
                    MC.MasterEntity = MasterData.ToList();

                    var ItemsData = reader.Read<SEL_T003_A>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();

                    var TaxData = reader.Read<ACC_T006_C>().ToList();
                    MC.TaxEntity = TaxData.ToList();
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }
                    var Licence_Data = reader.Read<ACC_T006_D>().ToList();
                    MC.LicenceEntity = Licence_Data.ToList();

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

                if (RequestOption != "ValidateInvoice" && RequestOption != "RevertValidation")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("SEL_T003LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            #region LoadInitialData
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
                            MC.Incoterm = reader.Read<ADM_M044_P>().ToList();
                            MC.Transporters = reader.Read<ADM_M028_P>().ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);

                            #endregion
                        }
                        else if (RequestOption == "LoadInitialData_STD")
                        {
                            MC.Sales_Invoice_Reference = reader.Read<SEL_T003_P_RefDoc>().ToList();
                            MC.doc_typeList = reader.Read<SYS_M002>().ToList();
                            MC.TaxList = reader.Read<ACC_M013_P>().ToList();
                            MC.NotificationData = reader.Read<NotificationData>().ToList();
                            MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadFromSoldToPartyDetails")
                        {
                            var partysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.PartysSoldToAddresses = partysSoldToAddresses.ToList();

                            var itemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();
                            MC.ItemListPopup = itemListPopup.ToList();

                            var custCatlogNo = reader.Read<CRM_T001A_P>().ToList();
                            MC.CustCatlogNo = custCatlogNo.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);

                        }
                        else if (RequestOption == "LoadFromCatlogNo")
                        {
                            var itemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();
                            MC.ItemListPopup = itemListPopup.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadHistory")
                        {
                            var documentDataFlipGrid = reader.Read<SEL_T003Flip>().ToList();
                            MC.DocumentDataFlipGrid = documentDataFlipGrid.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadBackFlipData")
                        {
                            var documentDataFlipGrid = reader.Read<SEL_T003Flip>().ToList();
                            MC.DocumentDataFlipGrid = documentDataFlipGrid.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadDelivery")
                        {
                            var itemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();
                            MC.ItemListPopup = itemListPopup.ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadSalesOrder")
                        {
                            var itemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();
                            MC.ItemListPopup = itemListPopup.ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadDocumentFromDeliveryNo")//|| RequestOption == "LoadDocumentFromSalesOrderReferneceNo")// for delivery no as referance doc no
                        {
                            #region LoadDocumentWithReferenceDocumentNumber
                            var MasterData = reader.Read<SEL_T003>().ToList();
                            MC.MasterEntity = MasterData.ToList();

                            var ItemDetails = reader.Read<SEL_T003_A>().ToList();
                            MC.ItemsEntity = ItemDetails.ToList();

                            var partysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.PartysSoldToAddresses = partysSoldToAddresses.ToList();

                            var Withholdinglist = reader.Read<ACC_M025_P>().ToList();
                            MC.withholdinglist = Withholdinglist.ToList();

                            var itemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();//this is load from sold to party
                            MC.ItemListPopup = itemListPopup.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                            #endregion
                        }
                        else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")// for Referance document
                        {
                            #region LoadFromBackFilpDetails
                            var MasterData = reader.Read<SEL_T003>().ToList();
                            MC.MasterEntity = MasterData.ToList();

                            var ItemDetails = reader.Read<SEL_T003_A>().ToList();
                            MC.ItemsEntity = ItemDetails.ToList();

                            var TaxData = reader.Read<ACC_T006_C>().ToList();
                            MC.TaxEntity = TaxData.ToList();

                            var attachment = reader.Read<COM_T003>().ToList();
                            MC.Attachment = attachment.ToList();

                            var itemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();//this is load from sold to party
                            MC.ItemListPopup = itemListPopup.ToList();

                            var partySoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.PartysSoldToAddresses = partySoldToAddresses.ToList();

                            var custCatlogNo = reader.Read<CRM_T001A_P>().ToList();
                            MC.CustCatlogNo = custCatlogNo.ToList();

                            var Withholdinglist = reader.Read<ACC_M025_P>().ToList();
                            MC.withholdinglist = Withholdinglist.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;

                            #endregion
                        }
                        else if (RequestOption == "LoadDocumentWithDocumentNumber")// for backflip
                        {
                            #region LoadFromBackFilpDetails
                            var MasterData = reader.Read<SEL_T003>().ToList();
                            MC.MasterEntity = MasterData.ToList();

                            var ItemDetails = reader.Read<SEL_T003_A>().ToList();
                            MC.ItemsEntity = ItemDetails.ToList();

                            var TaxData = reader.Read<ACC_T006_C>().ToList();
                            MC.TaxEntity = TaxData.ToList();

                            var attachment = reader.Read<COM_T003>().ToList();
                            MC.Attachment = attachment.ToList();

                            var itemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();//this is load from sold to party
                            MC.ItemListPopup = itemListPopup.ToList();

                            var partySoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.PartysSoldToAddresses = partySoldToAddresses.ToList();

                            var custCatlogNo = reader.Read<CRM_T001A_P>().ToList();
                            MC.CustCatlogNo = custCatlogNo.ToList();

                            var Licence_Data = reader.Read<ACC_T006_D>().ToList();
                            MC.LicenceEntity = Licence_Data.ToList();

                            var Withholdinglist = reader.Read<ACC_M025_P>().ToList();
                            MC.withholdinglist = Withholdinglist.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;

                            #endregion
                        }
                        else if (RequestOption == "LoadDocumentFromSalesOrderReferneceNo")// here 3 else if of IN LoadFromSalesOrderReferneceNo and LoadDocumentWithReferenceDocumentNumber and LoadFromBackFilpDetails not necessary this will check in one we can check multiple option using or
                        {
                            #region LoadFromSalesOrderReferneceNo
                            var MasterData = reader.Read<SEL_T003>().ToList();
                            MC.MasterEntity = MasterData.ToList();

                            var ItemDetails = reader.Read<SEL_T003_A>().ToList();
                            MC.ItemsEntity = ItemDetails.ToList();

                            var partysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.PartysSoldToAddresses = partysSoldToAddresses.ToList();

                            var Withholdinglist = reader.Read<ACC_M025_P>().ToList();
                            MC.withholdinglist = Withholdinglist.ToList();

                            var itemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();
                            MC.ItemListPopup = itemListPopup.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                            #endregion
                        }
                        else if (RequestOption == "LoadDocumentFromSalesOrderDeliverySchedule")
                        {
                            var MasterData = reader.Read<SEL_T003>().ToList();
                            MC.MasterEntity = MasterData.ToList();

                            var ItemDetails = reader.Read<SEL_T003_A>().ToList();
                            MC.ItemsEntity = ItemDetails.ToList();

                            var partysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.PartysSoldToAddresses = partysSoldToAddresses.ToList();

                            var Withholdinglist = reader.Read<ACC_M025_P>().ToList();
                            MC.withholdinglist = Withholdinglist.ToList();

                            var itemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();
                            MC.ItemListPopup = itemListPopup.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "SI_Report")
                        {
                            var RptSIReportTemp = reader.Read<RptSalesInvoice>().ToList();
                            MC.RptSalesInvoice = RptSIReportTemp.ToList();

                            var RptSIReportTempItem = reader.Read<RptSalesInvoiceItem>().ToList();
                            MC.RptSalesInvoiceItem = RptSIReportTempItem.ToList();

                            var RptSIReportTempTax = reader.Read<ACC_T006_C>().ToList();
                            MC.TaxEntity = RptSIReportTempTax.ToList();

                            var ItemSceduleDetail = reader.Read<SEL_T002_A>().ToList();
                            MC.ScheduleItemsEntity = ItemSceduleDetail.ToList();

                            var RptPaymentDetail = reader.Read<ACC_T001_A>().ToList();
                            MC.PaymentDetail = RptPaymentDetail.ToList();

                            var Report_DataDetails = reader.Read<Report_Data_P>().ToList();
                            MC.Report_DataList = Report_DataDetails.ToList();

                            var calc_value = reader.Read<ADM_M058_A_P>().ToList();
                            MC.CalcValues = calc_value.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "Item_packingDetail")
                        {
                            var RptItemPackingDetailTemp = reader.Read<RptItemPackingDetail>().ToList();
                            MC.RptItemPackingDetailList = RptItemPackingDetailTemp.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "BatchDetail" || RequestOption == "WeightPackingDetail")
                        {
                            var RptBatchDetailList = reader.Read<RptBatchDetail>().ToList();
                            MC.RptBatchDetailList = RptBatchDetailList.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "BatchSummary")
                        {
                            var RptBatchDetailList = reader.Read<RptBatchDetail>().ToList();
                            MC.RptBatchDetailList = RptBatchDetailList.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "BatchDetail2")
                        {
                            var RptBatchDetailList = reader.Read<RptBatchDetail>().ToList();
                            MC.RptBatchDetailList = RptBatchDetailList.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "Refresh")
                        {
                            var sales_Invoice_Reference = reader.Read<SEL_T003_P_RefDoc>().ToList();
                            MC.Sales_Invoice_Reference = sales_Invoice_Reference.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else
                        {

                        }
                        return strReturnData;
                    }
                }
                else if (RequestOption == "ValidateInvoice")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("SEL_T003_VALD", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                        var MasterData = reader.Read<SEL_T003>().ToList();
                        MC.MasterEntity = MasterData.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;
                    }
                }
                else if (RequestOption == "RevertValidation")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("SEL_T003_VALR", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

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
    public class MultipleContext_SEL_T003 
    {
        public List<ADM_M0013> STATUS_LIST { get; set; }
        public List<STD_PARTY> PARTY_LIST { get; set; }
        public List<STD_ITEM> STD_ITEM_LIST { get; set; }
        public List<STD_MIS_BE> STD_MIS_LIST { get; set; }
        public List<STD_DOC_TYPE> DOC_TYPE_LIST { get; set; }
        public List<ACC_M003_P> AccountList { get; set; }
        public List<SEL_T003Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<SEL_T003_P_RefDoc> Sales_Invoice_Reference { get; set; }
        public List<ACC_M013_P> TaxList { get; set; }
        public List<ADM_M037_P> CurrencysList { get; set; }
        public List<ACC_M004_P> BanksList { get; set; }
        public List<ACC_M025_P> withholdinglist { get; set; }
        public List<ADM_M028_P> ServiceProviders { get; set; }
        public List<ADM_M041_P> LicenseAdvance { get; set; }
        public List<ADM_M041_P> LicenseEPCG { get; set; }
        public List<ADM_M020_P> Product_Description { get; set; }
        public List<ADM_M012_P> CountryList { get; set; }
        public List<ADM_M028_P> Transporters { get; set; }
        public List<MM_M002_P> GodownList { get; set; }
        public List<ACC_M007_P> PayTerms { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_D_P> SalesDiv { get; set; }
        public List<ADM_M001_C_P> DistributionChannel { get; set; }
        public List<ACC_M019_P> Cost_Centers { get; set; }
        public List<ACC_M005_P> Journals { get; set; }
        public List<ADM_M031_P> ParameterList { get; set; } //Parameter Master
        public List<ADM_M030_P> ParamValueList { get; set; }
        public List<SYS_M003_P> ItemCategoryList { get; set; }
        public List<ADM_M038_B_P> UnitList { get; set; }
        public List<ZADM_M006_P> Inks { get; set; }
        public List<ZADM_M007_P> ILDs { get; set; }
        public List<ACC_M013_P> FormType { get; set; }
        public List<SEL_T003> MasterEntity { get; set; }
        public List<SEL_T003_A> ItemsEntity { get; set; }
        public List<ACC_T006_C> TaxEntity { get; set; }
        public List<ADM_M028_D_P> PartysSoldToAddresses { get; set; }
        public List<SEL_T003_P_SI_ItemsList> ItemListPopup { get; set; }
        public List<CRM_T001A_P> CustCatlogNo { get; set; }
        public List<SYS_M002> doc_typeList { get; set; }
        public List<RptSalesInvoice> RptSalesInvoice { get; set; }
        public List<RptSalesInvoiceItem> RptSalesInvoiceItem { get; set; }
        public List<RptSalesInvoiceTax> RptSalesInvoiceTax { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<ADM_M024_P> SalesPerson { get; set; }
        public List<SYS_M001_P> Export_Doc_Type { get; set; }
        public List<RptDeliveryNote> RptDeliveryNoteList { get; set; }
        public List<SYS_M002> DocCategoryList { get; set; }
        public List<RptItemPackingDetail> RptItemPackingDetailList { get; set; }
        public List<RptBatchDetail> RptBatchDetailList { get; set; }
        public List<ADM_M044_P> Incoterm { get; set; }
        public List<ADM_M038_C> UnitConversion { get; set; }
        public List<SEL_T002_A> ScheduleItemsEntity { get; set; }
        public List<ACC_T001_A> PaymentDetail { get; set; }
        public List<ACC_M003_O_P> ConditionTypeList { get; set; }
        public List<ADM_M041_P> LicenceList { get; set; }
        public List<ACC_T006_D> LicenceEntity { get; set; }
        public List<ADM_M003_C_P> BussinessPlaceList { get; set; }
        public List<Report_Data_P> Report_DataList { get; set; }
        public List<Report_Data_P> Report_DataList2 { get; set; }
        //public List<ADM_M0013> t_statusList { get; set; }
        public List<SEL_T003_P_RefDoc> SO_ReferenceList { get; set; }
        public List<ADM_M058_A_P> CalcValues { get; set; }
        public List<ADM_M063_P> GSTDeclaration { get; set; }
        public List<SEL_T003_P> Invoice { get; set; }
        public List<SYS_M026> TransportMode { get; set; }
        public List<SYS_M037> Trade_Types { get; set; }
        public List<ACC_M004_P> hbList { get; set; }
        public List<EWayBill_document> EB_BillLists { get; set; }
        public List<EWayBill_itemList> EB_ItemList { get; set; }
        public List<GEN_T011> TermsAndCondition { get; set; }
        public List<ADM_M0051> CONDITION_LIST { get; set; }
    }
}
