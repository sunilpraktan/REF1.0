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
using Reflection.EF.FICO;
using Reflection.EF.ADM;
using Reflection.EF.GEN;

namespace Reflection.BusinessLogic.FICO
{
    public class SEL_T003_BL : ReflectionBusinessLogic
    {
        SEL_T003 MasterEntity = new SEL_T003();
        MultipleContext_SEL_T003 MC = new MultipleContext_SEL_T003();

        public SEL_T003_BL()
        {
        }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T003_INS", new { @Request = Request }, commandTimeout: 6000, commandType: CommandType.StoredProcedure);

                    MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }
                    MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                    MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                    MC.TermsAndCondition = reader.Read<GEN_T011>().ToList();
                    MC.Attachment = reader.Read<COM_T003>().ToList();
                    MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();//this is load from sold to party
                    MC.PartysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                    MC.CustCatlogNo = reader.Read<CRM_T001A_P>().ToList();
                    MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                    MC.withholdinglist = reader.Read<ACC_M025_P>().ToList();

                    ////MC.DocumentDataFlipGrid = reader.Read<SEL_T003Flip>().ToList();
                    //MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                    //MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                    //MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                    //if (MC.MasterEntity.Count > 0)
                    //{
                    //    MasterEntity = MC.MasterEntity[0];
                    //}
                    //MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();

                    MasterEntity.XmlDataDocument_SEL_T003_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = ObjectSerializationService.ObjectToXML(MC.TaxEntity);
                    MasterEntity.XDOC_TC = ObjectSerializationService.ObjectToXML(MC.TermsAndCondition);
                    //MasterEntity.at = ObjectSerializationService.ObjectToXML(MC.Attachment);
                    //MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_ACC_T006_D = ObjectSerializationService.ObjectToXML(MC.LicenceEntity);
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
                    var reader = conn.QueryMultiple("SEL_T003_UPD", new { @Request = Request }, commandTimeout: 6000, commandType: CommandType.StoredProcedure);

                    MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }
                    MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                    MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                    MC.TermsAndCondition = reader.Read<GEN_T011>().ToList();
                    MC.Attachment = reader.Read<COM_T003>().ToList();
                    MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();//this is load from sold to party
                    MC.PartysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                    MC.CustCatlogNo = reader.Read<CRM_T001A_P>().ToList();
                    MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                    MC.withholdinglist = reader.Read<ACC_M025_P>().ToList();

                    ////MC.DocumentDataFlipGrid = reader.Read<SEL_T003Flip>().ToList();
                    //MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                    //MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                    //MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                    //if (MC.MasterEntity.Count > 0)
                    //{
                    //    MasterEntity = MC.MasterEntity[0];
                    //}
                    //MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();

                    MasterEntity.XmlDataDocument_SEL_T003_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = ObjectSerializationService.ObjectToXML(MC.TaxEntity);
                    MasterEntity.XDOC_TC = ObjectSerializationService.ObjectToXML(MC.TermsAndCondition);
                    //MasterEntity.at = ObjectSerializationService.ObjectToXML(MC.Attachment);
                    //MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_ACC_T006_D = ObjectSerializationService.ObjectToXML(MC.LicenceEntity);
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
                    int intOut = conn.Execute("SEL_T003_DEL", new { @request = Request }, commandType: CommandType.StoredProcedure);
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
                
                string RequestOption = RequestValue.Split('!')[0];

                if (RequestOption != "ValidateInvoice" && RequestOption != "RevertValidation")
                {
                    using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                    {
                        var reader = conn.QueryMultiple("SEL_T003_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LOAD_INI_POS")
                        {
                            #region LoadInitialData

                            MC.STD_ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                            MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                            MC.PARTY_LIST = reader.Read<STD_PARTY>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);

                            #endregion
                        }
                        else if (RequestOption == "LOAD_INI")
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
                            MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
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
                            MC.CONDITION_LIST = reader.Read<ADM_M0051>().ToList();
                            MC.Transporters = reader.Read<ADM_M028_P>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);

                            #endregion
                        }
                        else if (RequestOption == "LOAD_INI_STD")
                        {
                            MC.Sales_Invoice_Reference = reader.Read<SEL_T003_P_RefDoc>().ToList();
                            MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                            MC.TaxList = reader.Read<ACC_M013_P>().ToList();
                            MC.NotificationData = reader.Read<NotificationData>().ToList();
                            MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadFromSoldToPartyDetails")
                        {
                            MC.PartysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();
                            MC.CustCatlogNo = reader.Read<CRM_T001A_P>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);

                        }
                        else if (RequestOption == "LoadFromCatlogNo")
                        {
                            MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadHistory")
                        {
                            MC.DocumentDataFlipGrid = reader.Read<SEL_T003Flip>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LOAD_BACKFLIP")
                        {
                            MC.DocumentDataFlipGrid = reader.Read<SEL_T003Flip>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadDelivery")
                        {
                            MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();
                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadSalesOrder")
                        {
                            var itemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();
                            MC.ItemListPopup = itemListPopup.ToList();
                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadDocumentFromDeliveryNo")//|| RequestOption == "LoadDocumentFromSalesOrderReferneceNo")// for delivery no as referance doc no
                        {
                            MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                            MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                            MC.PartysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.withholdinglist = reader.Read<ACC_M025_P>().ToList();
                            MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();//this is load from sold to party

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
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

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LOAD_DOCUMENT")// for backflip
                        {
                            MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                            MC.ItemsEntity  = reader.Read<SEL_T003_A>().ToList();
                            MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                            MC.TermsAndCondition = reader.Read<GEN_T011>().ToList();
                            MC.Attachment = reader.Read<COM_T003>().ToList();
                            MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();//this is load from sold to party
                            MC.PartysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.CustCatlogNo = reader.Read<CRM_T001A_P>().ToList();
                            MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                            MC.withholdinglist = reader.Read<ACC_M025_P>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadDocumentFromSalesOrderReferneceNo")// here 3 else if of IN LoadFromSalesOrderReferneceNo and LoadDocumentWithReferenceDocumentNumber and LoadFromBackFilpDetails not necessary this will check in one we can check multiple option using or
                        {
                            MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                            MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                            MC.PartysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.withholdinglist = reader.Read<ACC_M025_P>().ToList();
                            MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "ExecuteBillingPlan")
                        {
                            MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                            MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                            MC.PartysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.withholdinglist = reader.Read<ACC_M025_P>().ToList();
                            MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadDocumentFromSalesOrderDeliverySchedule")
                        {
                            MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                            MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                            MC.PartysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.withholdinglist = reader.Read<ACC_M025_P>().ToList();
                            MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "SI_Report")
                        {
                            MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                            MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                            MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                            MC.ScheduleItemsEntity = reader.Read<SEL_T002_A>().ToList();
                            MC.PaymentDetail = reader.Read<ACC_T001_A>().ToList();
                            MC.Report_DataList = reader.Read<Report_Data_P>().ToList();
                            MC.CalcValues = reader.Read<ADM_M058_A_P>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "Item_packingDetail")
                        {
                            MC.RptItemPackingDetailList = reader.Read<RptItemPackingDetail>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "BatchDetail" || RequestOption == "WeightPackingDetail")
                        {
                            MC.RptBatchDetailList = reader.Read<RptBatchDetail>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "BatchSummary")
                        {
                            MC.RptBatchDetailList = reader.Read<RptBatchDetail>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "BatchDetail2")
                        {
                            MC.RptBatchDetailList = reader.Read<RptBatchDetail>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "Refresh")
                        {
                            MC.Sales_Invoice_Reference = reader.Read<SEL_T003_P_RefDoc>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "JSON_EXPORT")
                        {
                            MC.EB_BillLists = reader.Read<EWayBill_document>().ToList();
                            MC.EB_ItemList = reader.Read<EWayBill_itemList>().ToList();
                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "SHIPMARK_PRINT")
                        {
                            MC.STD_MIS_LIST = reader.Read<STD_MIS_BE>().ToList();
                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        return ReturnValue;
                    }
                }
                else if (RequestOption == "ValidateInvoice")
                {
                    using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                    {
                        var reader = conn.QueryMultiple("SEL_T003_VALD", new { @Request = RequestValue }, commandTimeout: 6000, commandType: CommandType.StoredProcedure);

                        MC.MasterEntity = reader.Read<SEL_T003>().ToList();

                        return ObjectSerializationService.ObjectToXML(MC);
                    }
                }
                else if (RequestOption == "RevertValidation")
                {
                    using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                    {
                        var reader = conn.QueryMultiple("SEL_T003_VALR", new { @Request = RequestValue }, commandTimeout: 6000, commandType: CommandType.StoredProcedure);

                        MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                        return ObjectSerializationService.ObjectToXML(MC);
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


    public class MC_SEL_T003 : MC_FICO_BE
    {
        public List<SEL_T003> MasterEntity { get; set; }
        public List<SEL_T003_A> ItemsEntity { get; set; }
        public List<ACC_T006_C> ConditionEntity { get; set; }
        public List<GEN_T011> TermsAndCondition { get; set; }

    }

}
