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
using Reflection.EF.Admin;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    public class SEL_T003BL_CD : ReflectionBusinessLogic
    {

        private static string connectionString;

        SEL_T003 MasterEntity = new SEL_T003();
        MultipleContext_SEL_T003 MC = new MultipleContext_SEL_T003();
        public SEL_T003BL_CD(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public SEL_T003BL_CD()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            MultipleContext_SEL_T003 MC = new MultipleContext_SEL_T003();
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T003Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var DocumentDataFlipGrid = reader.Read<SEL_T003Flip>().ToList();
                    MC.DocumentDataFlipGrid = DocumentDataFlipGrid.ToList();

                    var MasterData = reader.Read<SEL_T003>().ToList();
                    MC.MasterEntity = MasterData.ToList();
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }

                    var ItemsData = reader.Read<SEL_T003_A>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();

                    var TaxData = reader.Read<ACC_T006_C>().ToList();
                    MC.TaxEntity = TaxData.ToList();

                    MasterEntity.XmlDataDocument_SEL_T003_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = ObjectSerializationService.ObjectToXML(MC.TaxEntity);
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
            MultipleContext_SEL_T003 MC = new MultipleContext_SEL_T003();

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T003Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);


                    var DocumentDataFlipGrid = reader.Read<SEL_T003Flip>().ToList();
                    MC.DocumentDataFlipGrid = DocumentDataFlipGrid.ToList();

                    var MasterData = reader.Read<SEL_T003>().ToList();
                    MC.MasterEntity = MasterData.ToList();
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }

                    var ItemsData = reader.Read<SEL_T003_A>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();

                    var TaxData = reader.Read<ACC_T006_C>().ToList();
                    MC.TaxEntity = TaxData.ToList();


                    //MasterEntity = MC.MasterEntity[0];
                    MasterEntity.XmlDataDocument_SEL_T003_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = ObjectSerializationService.ObjectToXML(MC.TaxEntity);
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
            MultipleContext_SEL_T003 MC = new MultipleContext_SEL_T003();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                if (RequestOption == "LoadInitialData_STD" || RequestOption == "ExecuteReferenceDocuments" || RequestOption == "LoadDocumentWithDocumentNumber_STD" || RequestOption == "LoadHistory_STD")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("SEL_T003LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                        if (RequestOption == "LoadInitialData_STD")
                        {
                            MC.Sales_Invoice_Reference = reader.Read<SEL_T003_P_RefDoc>().ToList();
                            MC.doc_typeList = reader.Read<SYS_M002>().ToList();
                            MC.TaxList = reader.Read<ACC_M013_P>().ToList();
                            MC.NotificationData = reader.Read<NotificationData>().ToList();
                            MC.t_statusList = reader.Read<ADM_M0013>().ToList();
                        }
                        else if (RequestOption == "ExecuteReferenceDocuments")
                        {
                            MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                            MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                            MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                        }
                        else if (RequestOption == "LoadDocumentWithDocumentNumber_STD")
                        {
                            MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                            MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                            MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                            MC.Attachment = reader.Read<COM_T003>().ToList();
                        }
                        else if (RequestOption == "LoadHistory_STD")
                        {
                            MC.DocumentDataFlipGrid = reader.Read<SEL_T003Flip>().ToList();
                        }
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                }
                else if (RequestOption != "ValidateInvoice")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("SEL_T003LoadAll_CD", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var DocumentDataFlipGrid = reader.Read<SEL_T003Flip>().ToList();
                            MC.DocumentDataFlipGrid = DocumentDataFlipGrid.ToList();
                            var PartyMaster = reader.Read<ADM_M028_P>().ToList();
                            MC.PartyMaster = PartyMaster.ToList();
                            var Sales_Invoice_Reference = reader.Read<SEL_T003_P_RefDoc>().ToList();
                            MC.Sales_Invoice_Reference = Sales_Invoice_Reference.ToList();
                            var CurrencysList = reader.Read<ADM_M037_P>().ToList();
                            MC.CurrencysList = CurrencysList.ToList();
                            var PayTerms = reader.Read<ACC_M007_P>().ToList();
                            MC.PayTerms = PayTerms.ToList();
                            var SalesOrg = reader.Read<ADM_M001_A_P>().ToList();
                            MC.SalesOrg = SalesOrg.ToList();
                            var SalesGroup = reader.Read<ADM_M001_H_P>().ToList();
                            MC.SalesGroup = SalesGroup.ToList();
                            var Cost_Centers = reader.Read<ACC_M019_P>().ToList();
                            MC.Cost_Centers = Cost_Centers.ToList();
                            var Journals = reader.Read<ACC_M005_P>().ToList();
                            MC.Journals = Journals.ToList();

                            var parameterList = reader.Read<ADM_M031_P>().ToList();
                            MC.ParameterList = parameterList.ToList();

                            var paramValueList = reader.Read<ADM_M030_P>().ToList();
                            MC.ParamValueList = paramValueList.ToList();

                            var UnitList = reader.Read<ADM_M038_B_P>().ToList();
                            MC.UnitList = UnitList.ToList();
                            var doc_typeList = reader.Read<SYS_M002>().ToList();
                            MC.doc_typeList = doc_typeList.ToList();
                            var TaxList = reader.Read<ACC_M013_P>().ToList();
                            MC.TaxList = TaxList.ToList();
                            var NotificationData = reader.Read<NotificationData>().ToList();
                            MC.NotificationData = NotificationData.ToList();

                            var AccountList = reader.Read<ACC_M003_P>().ToList();
                            MC.AccountList = AccountList.ToList();

                            var inks = reader.Read<ZADM_M006_P>().ToList();
                            MC.Inks = inks.ToList();

                            var iLDs = reader.Read<ZADM_M007_P>().ToList();
                            MC.ILDs = iLDs.ToList();

                            var SalesPerson1 = reader.Read<ADM_M024_P>().ToList();
                            MC.SalesPerson = SalesPerson1.ToList();

                            //var paramValueList = reader.Read<ADM_M030_P>().ToList();
                            //MC.ParamValueList = paramValueList.ToList();

                            var ConditionTypeTemp = reader.Read<ACC_M003_O_P>().ToList();
                            MC.ConditionTypeList = ConditionTypeTemp.ToList();

                            var t_statusData = reader.Read<ADM_M0013>().ToList();
                            MC.t_statusList = t_statusData.ToList();
                            MC.Trade_Types = reader.Read<SYS_M037>().ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);

                        }
                        else if (RequestOption == "LoadFromSoldToPartyDetails")
                        {

                            var PartysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.PartysSoldToAddresses = PartysSoldToAddresses.ToList();
                            var ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();
                            MC.ItemListPopup = ItemListPopup.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);

                        }
                        else if (RequestOption == "LoadDocumentFromSalesOrderReferneceNo")
                        {

                            var MasterData = reader.Read<SEL_T003>().ToList();
                            MC.MasterEntity = MasterData.ToList();
                            var ItemDetails = reader.Read<SEL_T003_A>().ToList();
                            MC.ItemsEntity = ItemDetails.ToList();
                            //var TaxData = reader.Read<ACC_T006_C>().ToList();
                            //MC.TaxEntity = TaxData.ToList();
                            //var itemdata = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();
                            //MC.ItemListPopup = itemdata.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;

                        }
                        else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                        {

                            var MasterData = reader.Read<SEL_T003>().ToList();
                            MC.MasterEntity = MasterData.ToList();
                            var ItemDetails = reader.Read<SEL_T003_A>().ToList();
                            MC.ItemsEntity = ItemDetails.ToList();
                            var TaxData = reader.Read<ACC_T006_C>().ToList();
                            MC.TaxEntity = TaxData.ToList();
                            var ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();
                            MC.ItemListPopup = ItemListPopup.ToList();
                            var PartysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            MC.PartysSoldToAddresses = PartysSoldToAddresses.ToList();
                            var CustCatlogNo = reader.Read<CRM_T001A_P>().ToList();
                            MC.CustCatlogNo = CustCatlogNo.ToList();
                            var Attachment = reader.Read<COM_T003>().ToList();
                            MC.Attachment = Attachment.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "LoadBackFlipData")
                        {
                            var DocDataFlipGrid = reader.Read<SEL_T003Flip>().ToList();
                            MC.DocumentDataFlipGrid = DocDataFlipGrid.ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "CD_Report")
                        {
                            var RptSIReportTemp = reader.Read<RptSalesInvoice>().ToList();
                            MC.RptSalesInvoice = RptSIReportTemp.ToList();

                            var RptSIReportTempItem = reader.Read<RptSalesInvoiceItem>().ToList();
                            MC.RptSalesInvoiceItem = RptSIReportTempItem.ToList();

                            var RptSIReportTempTax = reader.Read<ACC_T006_C>().ToList();
                            MC.TaxEntity = RptSIReportTempTax.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "LoadSODetails")
                        {

                        }
                        else if (RequestOption == "LoadHistory")
                        {
                            MC.DocumentDataFlipGrid = reader.Read<SEL_T003Flip>().ToList();
                        }
                    }
                }
                else if (RequestOption == "ValidateInvoice")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("SEL_T003Validate", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                        var MasterData = reader.Read<SEL_T003>().ToList();
                        MC.MasterEntity = MasterData.ToList();

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
        public class MultipleContext_SEL_T003
        {
            public List<SEL_T003Flip> DocumentDataFlipGrid { get; set; }
            public List<ADM_M028_P> PartyMaster { get; set; }
            public List<SEL_T003_P_RefDoc> Sales_Invoice_Reference { get; set; }
            public List<ACC_M013_P> TaxList { get; set; }
            public List<ADM_M037_P> CurrencysList { get; set; }
            public List<ACC_M004_P> BanksList { get; set; }
            public List<ADM_M028_P> ServiceProviders { get; set; }
            public List<ADM_M041_P> LicenseAdvance { get; set; }
            public List<ADM_M041_P> LicenseEPCG { get; set; }
            public List<ADM_M020_P> Product_Description { get; set; }
            public List<ADM_M012_P> CountryList { get; set; }
            public List<ADM_M028_P> Transporters { get; set; }
            public List<MM_M002_P> GodownList { get; set; }
            public List<ACC_M007_P> PayTerms { get; set; }
            public List<ADM_M001_A_P> SalesOrg { get; set; }
            public List<ADM_M001_H_P> SalesGroup { get; set; }
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
            public List<COM_T003> Attachment { get; set; }
            public List<NotificationData> NotificationData { get; set; }

            public List<ACC_M003_P> AccountList { get; set; }
            public List<ADM_M024_P> SalesPerson { get; set; }
            public List<ACC_M003_O_P> ConditionTypeList { get; set; }
            public List<ADM_M0013> t_statusList { get; set; }
            public List<SYS_M037> Trade_Types { get; set; }

        }

    }
}
