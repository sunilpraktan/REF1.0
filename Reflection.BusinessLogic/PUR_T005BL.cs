using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF;
using Reflection.EF.Procurement;
using Dapper;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.Communication;
using Reflection.EF.CRM;
using Reflection.EF.Admin;
using Reflection.EF.ADM;

// Created by Mayuri
namespace Reflection.BusinessLogic
{
    public class PUR_T005BL : ReflectionBusinessLogic
    {

        private static string connectionString;


        PUR_T005 MasterEntity = new PUR_T005();
        MultipleContext_PUR_T005 MC = new MultipleContext_PUR_T005();
        public PUR_T005BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public PUR_T005BL()
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
                    var reader = conn.QueryMultiple("PUR_T005Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<PUR_T005_Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<PUR_T005>().ToList();
                    MC.MasterEntity = MasterData.ToList();
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }

                    var ItemsData = reader.Read<PUR_T005_A>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();

                    var TaxData = reader.Read<ACC_T006_C>().ToList();
                    MC.TaxEntity = TaxData.ToList();

                    var Licence_Data = reader.Read<ACC_T006_D>().ToList();
                    MC.LicenceEntity = Licence_Data.ToList();

                    MasterEntity.XmlDataDocument_PUR_T005_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = ObjectSerializationService.ObjectToXML(MC.TaxEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_D = ObjectSerializationService.ObjectToXML(MC.LicenceEntity);

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
            string strReturnData = "";
            try
            {

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T005Update", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<PUR_T005_Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<PUR_T005>().ToList();
                    List<PUR_T005> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var ItemsData = reader.Read<PUR_T005_A>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();

                    var TaxData = reader.Read<ACC_T006_C>().ToList();
                    MC.TaxEntity = TaxData.ToList();

                    var Licence_Data = reader.Read<ACC_T006_D>().ToList();
                    MC.LicenceEntity = Licence_Data.ToList();

                    MasterEntity.XmlDataDocument_PUR_T005_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = ObjectSerializationService.ObjectToXML(MC.TaxEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_D = ObjectSerializationService.ObjectToXML(MC.LicenceEntity);
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
                int intOut;
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    intOut = conn.Execute("PUR_T005Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
                }
                return intOut.ToString();
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
                if (strValue == "GetItemPriceData")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("GetSalesData", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "GetItemPrice")
                        {
                            var UnitPriceList = reader.Read<GetItemDetailsEntity>().ToList();
                            MC.UnitPriceList = UnitPriceList.ToList();
                            var QFRList = reader.Read<GetItemDetailsEntity>().ToList();
                            MC.QFRList = QFRList.ToList();
                            var DispatchList = reader.Read<GetItemDetailsEntity>().ToList();
                            MC.DispatchList = DispatchList.ToList();
                            var ProjectedDispList = reader.Read<GetItemDetailsEntity>().ToList();
                            MC.ProjectedDispList = ProjectedDispList.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }

                    }
                }
                else
                {
                    if (RequestOption != "ValidateInvoice" && RequestOption != "Trace_Report")
                    {
                        using (IDbConnection conn = new SqlConnection(connectionString))
                        {
                            var reader = conn.QueryMultiple("PUR_T005LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                            if (RequestOption == "LoadInitialData")
                            {
                                var purchase_InvoiceList = reader.Read<PUR_T005_P_RefDoc>().ToList();
                                MC.Purchase_Invoice_Reference = purchase_InvoiceList.ToList();

                                var taxList = reader.Read<ACC_M013_P>().ToList();
                                MC.TaxList = taxList.ToList();

                                var bankList = reader.Read<ACC_M004_P>().ToList();
                                MC.BankList = bankList.ToList();

                                var payMethod = reader.Read<ACC_M021_P>().ToList();
                                MC.PayMethod = payMethod.ToList();

                                var NotificationData = reader.Read<NotificationData>().ToList();
                                MC.NotificationData = NotificationData.ToList();

                                var ConditionTypeTemp = reader.Read<ACC_M003_O_P>().ToList();
                                MC.ConditionTypeList = ConditionTypeTemp.ToList();

                                var LicenceTemp = reader.Read<ADM_M041_P>().ToList();
                                MC.LicenceList = LicenceTemp.ToList();

                                var BussinessPlaceTemp = reader.Read<ADM_M003_C_P>().ToList();
                                MC.BussinessPlaceList = BussinessPlaceTemp.ToList();

                                var t_statusData = reader.Read<ADM_M0013>().ToList();
                                MC.t_statusList = t_statusData.ToList();

                                var cost_Centers = reader.Read<ACC_M019_P>().ToList();
                                MC.Cost_Centers = cost_Centers.ToList();

                                var ItemData = reader.Read<PUR_T005_P_PI_ItemsList>().ToList();
                                MC.ItemListPopup = ItemData.ToList();

                                MC.Trade_Types = reader.Read<SYS_M037>().ToList();

                            }
                            else if (RequestOption == "LoadFromSupplierPartyDetails")
                            {
                                var itemListPopup = reader.Read<PUR_T005_P_PI_ItemsList>().ToList();
                                MC.ItemListPopup = itemListPopup.ToList();

                                var partybanks = reader.Read<ACC_M004_P>().ToList();
                                MC.PartyBanks = partybanks.ToList();

                                //var Withholdinglist = reader.Read<ACC_M025_P>().ToList();
                                //MC.withholdinglist = Withholdinglist.ToList();
                            }
                            else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")// Load from Back Flip
                            {
                                var MasterData = reader.Read<PUR_T005>().ToList();
                                MC.MasterEntity = MasterData.ToList();

                                var ItemsData = reader.Read<PUR_T005_A>().ToList();
                                MC.ItemsEntity = ItemsData.ToList();

                                var TaxData = reader.Read<ACC_T006_C>().ToList();
                                MC.TaxEntity = TaxData.ToList();

                                // Item Detail
                                var itemListPopup = reader.Read<PUR_T005_P_PI_ItemsList>().ToList();
                                MC.ItemListPopup = itemListPopup.ToList();

                                var Attachment = reader.Read<COM_T003>().ToList();
                                MC.Attachment = Attachment.ToList();

                                var Licence_Data = reader.Read<ACC_T006_D>().ToList();
                                MC.LicenceEntity = Licence_Data.ToList();

                                var Withholdinglist = reader.Read<ACC_M025_P>().ToList();
                                MC.withholdinglist = Withholdinglist.ToList();

                            }
                            else if (RequestOption == "LoadDocumentFromGRNumber")  // Load from PO and GRN Number
                            {
                                var MasterData = reader.Read<PUR_T005>().ToList();
                                MC.MasterEntity = MasterData.ToList();

                                var ItemsData = reader.Read<PUR_T005_A>().ToList();
                                MC.ItemsEntity = ItemsData.ToList();

                                var Withholdinglist = reader.Read<ACC_M025_P>().ToList();
                                MC.withholdinglist = Withholdinglist.ToList();

                            }
                            else if (RequestOption == "LoadDocumentFromPOReferneceNo")  // Load from PO and GRN Number
                            {
                                var MasterData = reader.Read<PUR_T005>().ToList();
                                MC.MasterEntity = MasterData.ToList();

                                var ItemsData = reader.Read<PUR_T005_A>().ToList();
                                MC.ItemsEntity = ItemsData.ToList();

                                //var Withholdinglist = reader.Read<ACC_M025_P>().ToList();
                                //MC.withholdinglist = Withholdinglist.ToList();

                            }
                            else if (RequestOption == "LoadFromDateToDate")
                            {
                                var FlipGridData = reader.Read<PUR_T005_Flip>().ToList();
                                MC.DocumentDataFlipGrid = FlipGridData.ToList();
                            }
                            else if (RequestOption == "LoadGRN")
                            {
                                var itemListPopup = reader.Read<PUR_T005_P_PI_ItemsList>().ToList();
                                MC.ItemListPopup = itemListPopup.ToList();
                            }
                            else if (RequestOption == "LoadPO")
                            {
                                var itemListPopup = reader.Read<PUR_T005_P_PI_ItemsList>().ToList();
                                MC.ItemListPopup = itemListPopup.ToList();
                            }
                            else if (RequestOption == "LoadHistory")
                            {
                                var FlipGridData = reader.Read<PUR_T005_Flip>().ToList();
                                MC.DocumentDataFlipGrid = FlipGridData.ToList();
                            }
                            else if (RequestOption == "LoadWithoutReference")
                            {
                                var cost_Centers = reader.Read<ACC_M019_P>().ToList();
                                MC.Cost_Centers = cost_Centers.ToList();

                                var currencyList = reader.Read<ADM_M037_P>().ToList();
                                MC.CurrencyList = currencyList.ToList();

                                var parameterList = reader.Read<ADM_M031_P>().ToList();
                                MC.ParameterList = parameterList.ToList();

                                var paramValueList = reader.Read<ADM_M030_P>().ToList();
                                MC.ParamValueList = paramValueList.ToList();
                            }
                        }
                    }
                    else if (RequestOption == "ValidateInvoice")
                    {
                        using (IDbConnection conn = new SqlConnection(connectionString))
                        {
                            var reader = conn.QueryMultiple("PUR_T005_VALD", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                            MC.MasterEntity = reader.Read<PUR_T005>().ToList();
                            return ObjectSerializationService.ObjectToXML(MC);
                        }
                    }
                    else if (RequestOption == "Trace_Report")
                    {
                        using (IDbConnection conn = new SqlConnection(connectionString))
                        {
                            RequestValue = RequestValue.Split('!')[1];
                            var reader = conn.QueryMultiple("PUR_T005_TRACE", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                            MC.TraceList = reader.Read<InvoiceTraceEntity>().ToList();
                            return ObjectSerializationService.ObjectToXML(MC);
                        }
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
    public class MultipleContext_PUR_T005
    {
        public List<STD_DOC_TYPE> DOC_TYPE_LIST { get; set; }
        public List<SYS_M025> STATUS_LIST { get; set; }
        public List<ACC_M013> TAX_LIST { get; set; }
        public List<STD_LIST_BE> REF_DOC_LIST { get; set; }
        public List<STD_LIST_BE> BACK_FLIP_LIST { get; set; }
        public List<PUR_T005_Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<PUR_T005_P_RefDoc> Purchase_Invoice_Reference { get; set; }
        public List<ACC_M013_P> TaxList { get; set; }
        public List<ACC_M019_P> Cost_Centers { get; set; }
        public List<ACC_M005_P> Journals { get; set; }
        public List<ADM_M001_M_P> Purchase_orgList { get; set; }
        public List<ADM_M001_P_P> Purchase_groupList { get; set; }
        public List<ADM_M037_P> CurrencyList { get; set; }
        public List<ACC_M004_P> BankList { get; set; }
        public List<ACC_M004_P> PartyBanks { get; set; }
        public List<ADM_M031_P> ParameterList { get; set; } //Parameter Master
        public List<ADM_M030_P> ParamValueList { get; set; }
        public List<SYS_M003_P> ItemCategoryList { get; set; }
        public List<ADM_M038_B_P> UnitList { get; set; }
        public List<ACC_M007_P> PayTerms { get; set; }
        public List<ACC_M021_P> PayMethod { get; set; }
        public List<ACC_M013_P> FormType { get; set; }
        public List<ACC_M003_P> AccountList { get; set; }
        public List<PUR_T005_P_PI_ItemsList> ItemListPopup { get; set; }
        public List<PUR_T005> MasterEntity { get; set; }
        public List<PUR_T005_A> ItemsEntity { get; set; }
        public List<ACC_T006_C> TaxEntity { get; set; }
        public List<SYS_M007> doc_typeList { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }

        public List<ADM_M044_P> Incoterms { get; set; }
        public List<ADM_M041_P> LicenseAdvance { get; set; }
        public List<ADM_M041_P> LicenseEPCG { get; set; }
        public List<ADM_M028_P> ServiceProviders { get; set; }
        public List<SYS_M007_P> DocTypeData { get; set; }
        public List<ACC_M003_O_P> ConditionTypeList { get; set; }
        public List<ADM_M041_P> LicenceList { get; set; }
        public List<ACC_T006_D> LicenceEntity { get; set; }
        public List<ADM_M003_C_P> BussinessPlaceList { get; set; }
        public List<GetItemDetailsEntity> UnitPriceList { get; set; }
        public List<GetItemDetailsEntity> QFRList { get; set; }
        public List<GetItemDetailsEntity> DispatchList { get; set; }
        public List<GetItemDetailsEntity> ProjectedDispList { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<ACC_M025_P> withholdinglist { get; set; }
        public List<InvoiceTraceEntity> TraceList { get; set; }
        public List<SYS_M037> Trade_Types { get; set; }
    }
}
