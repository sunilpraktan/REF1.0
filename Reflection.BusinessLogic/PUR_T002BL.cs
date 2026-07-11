using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.Procurement;
using Reflection.EF;
using Reflection.EF.Admin;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.Communication;
using Reflection.EF.CRM;
using Reflection.EF.ADM;
using Reflection.EF.GEN;
//Created by Sunil
namespace Reflection.BusinessLogic
{
    public class PUR_T002BL : ReflectionBusinessLogic
    {

        private static string connectionString;

        PUR_T002_A MasterEntity = new PUR_T002_A();
        PUR_T002_B ItemEntity = new PUR_T002_B();
        public PUR_T002BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public PUR_T002BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            MultipleContext_PUR_T002_A MC = new MultipleContext_PUR_T002_A();

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T002Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                   
                    var MasterData = reader.Read<PUR_T002_A>().ToList();
                    MC.DocumentMaster = MasterData.ToList();
                    if (MC.DocumentMaster.Count > 0)
                    {
                        MasterEntity = MC.DocumentMaster[0];
                    }
                    var ItemsData = reader.Read<PUR_T002_B>().ToList();
                    MC.DocumentItems = ItemsData.ToList();
                    var TaxData = reader.Read<ACC_T006_B>().ToList();
                    MC.DocumentTaxDetails = TaxData.ToList();
                    var Schedule_B_Data = reader.Read<PUR_T004_B>().ToList();
                    MC.DocumentScheduleDetails = Schedule_B_Data.ToList();
                    var Schedule_A_Data = reader.Read<PUR_T004_A>().ToList();
                    MC.DocumentScheduleMaster = Schedule_A_Data.ToList();
                    var TermsAndConditionEntity = reader.Read<PUR_T002_H>().ToList();
                    MC.TermsAndCondition = TermsAndConditionEntity.ToList();
                    var LicenceData = reader.Read<ACC_T006_D>().ToList();
                    MC.LicenceEntity = LicenceData.ToList();
                    MC.ComponantList = reader.Read<PUR_T002_C>().ToList();

                    MasterEntity.XmlDataDocument_PUR_T002_B = ObjectSerializationService.ObjectToXML(MC.DocumentItems);
                    MasterEntity.XmlDataDocument_PUR_T002_C = ObjectSerializationService.ObjectToXML(MC.ComponantList);
                    MasterEntity.XmlDataDocument_ACC_T006_B = ObjectSerializationService.ObjectToXML(MC.DocumentTaxDetails);
                    MasterEntity.XmlDataDocument_PUR_T004_B = ObjectSerializationService.ObjectToXML(MC.DocumentScheduleDetails);
                    MasterEntity.XmlDataDocument_PUR_T004_A = ObjectSerializationService.ObjectToXML(MC.DocumentScheduleMaster);
                    MasterEntity.XmlDataDocument_ACC_T006_D = ObjectSerializationService.ObjectToXML(MC.LicenceEntity);
                    //MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_PUR_T002_H = ObjectSerializationService.ObjectToXML(MC.TermsAndCondition);
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

            MultipleContext_PUR_T002_A MC = new MultipleContext_PUR_T002_A();

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T002Update", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<PUR_T002_A>().ToList();
                    MC.DocumentMaster = MasterData.ToList();
                    if (MC.DocumentMaster.Count > 0)
                    {
                        MasterEntity = MC.DocumentMaster[0];
                    }
                    var ItemsData = reader.Read<PUR_T002_B>().ToList();
                    MC.DocumentItems = ItemsData.ToList();
                    var TaxData = reader.Read<ACC_T006_B>().ToList();
                    MC.DocumentTaxDetails = TaxData.ToList();
                    var Schedule_B_Data = reader.Read<PUR_T004_B>().ToList();
                    MC.DocumentScheduleDetails = Schedule_B_Data.ToList();
                    var Schedule_A_Data = reader.Read<PUR_T004_A>().ToList();
                    MC.DocumentScheduleMaster = Schedule_A_Data.ToList();

                    var TermsAndConditionEntity = reader.Read<PUR_T002_H>().ToList();
                    MC.TermsAndCondition = TermsAndConditionEntity.ToList();
                    var LicenceData = reader.Read<ACC_T006_D>().ToList();
                    MC.LicenceEntity = LicenceData.ToList();
                    MC.ComponantList = reader.Read<PUR_T002_C>().ToList();

                    MasterEntity.XmlDataDocument_PUR_T002_B = ObjectSerializationService.ObjectToXML(MC.DocumentItems);
                    MasterEntity.XmlDataDocument_PUR_T002_C = ObjectSerializationService.ObjectToXML(MC.ComponantList);
                    MasterEntity.XmlDataDocument_ACC_T006_B = ObjectSerializationService.ObjectToXML(MC.DocumentTaxDetails);
                    MasterEntity.XmlDataDocument_PUR_T004_B = ObjectSerializationService.ObjectToXML(MC.DocumentScheduleDetails);
                    MasterEntity.XmlDataDocument_PUR_T004_A = ObjectSerializationService.ObjectToXML(MC.DocumentScheduleMaster);
                    MasterEntity.XmlDataDocument_PUR_T002_H = ObjectSerializationService.ObjectToXML(MC.TermsAndCondition);
                    MasterEntity.XmlDataDocument_ACC_T006_D = ObjectSerializationService.ObjectToXML(MC.LicenceEntity);
                    strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
                    return strReturnData;
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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("PUR_T002Delete", new { @po_no = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_PUR_T002_A MC = new MultipleContext_PUR_T002_A();
            string RequestOption = RequestValue.Split('!')[0];
            string doc_cat = "";
            if (RequestValue.Split('!').Count() >= 5)
            {
                doc_cat = RequestValue.Split('!')[4];
            }
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
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("PUR_T002LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            MC.partyList = reader.Read<ADM_M028_P>().ToList();
                            MC.unitList = reader.Read<ADM_M038_B_P>().ToList();
                            MC.BuyerList = reader.Read<ADM_M024_P>().ToList();
                            MC.TaxList = reader.Read<ACC_M013_P>().ToList();
                            MC.PayTerms = reader.Read<ACC_M007_P>().ToList();
                            MC.doc_typeList = reader.Read<SYS_M007>().ToList();
                            MC.currencyList = reader.Read<ADM_M037_P>().ToList();
                            MC.reference_docList = reader.Read<PUR_T002_P_RefeDoc>().ToList();
                            MC.cost_centerList = reader.Read<ACC_M019_P>().ToList();
                            MC.itemcatList = reader.Read<SYS_M008_P>().ToList();
                            MC.NotificationData = reader.Read<NotificationData>().ToList();
                            MC.TermsConditionCollection = reader.Read<MM_M008_P>().ToList();
                            MC.RequisitionItem = reader.Read<Purchase_Requision_Data>().ToList();
                            MC.UnitConversion = reader.Read<ADM_M038_C>().ToList();
                            MC.Incoterms = reader.Read<ADM_M044_P>().ToList();
                            MC.LicenceList = reader.Read<ADM_M041_P>().ToList();
                            MC.ConditionTypeList = reader.Read<ACC_M003_O_P>().ToList();
                            MC.BussinessPlaceList = reader.Read<ADM_M003_C_P>().ToList();
                            MC.t_statusList = reader.Read<ADM_M0013>().ToList();
                            MC.Trade_Types = reader.Read<SYS_M037>().ToList();
                            MC.ItemListForPopup = reader.Read<PUR_T002_P_PR_ItemsList>().ToList();
                            MC.TransportMode = reader.Read<SYS_M026>().ToList();
                            MC.ScopeList = reader.Read<ADM_M002_B>().ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadBackFlipData")
                        {
                            var DocDataFlipGrid = reader.Read<PUR_T002_AFlip>().ToList();
                            MC.DocumentDataFlipGrid = DocDataFlipGrid.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "ExplodeBOM")
                        {
                            MC.STD_LIST_OBJ = reader.Read<STD_LIST_BE>().ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadPartyDetails")
                        {
                            MC.TermsAndCondition = reader.Read<PUR_T002_H>().ToList();
                            MC.ContactPerson = reader.Read<ADM_M028_C_P>().ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadItemsForComponant")
                        {
                            MC.ItemListForComponant = reader.Read<STD_ITEM>().ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "CreateDocumentFromRequisitionItemNumber")
                        {
                            MC.DocumentMaster = reader.Read<PUR_T002_A>().ToList();
                            MC.DocumentItems = reader.Read<PUR_T002_B>().ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadDocumentFromRequisitionnumber")
                        {
                            MC.DocumentItems = reader.Read<PUR_T002_B>().ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                        {
                            var MasterData = reader.Read<PUR_T002_A>().ToList();
                            MC.DocumentMaster = MasterData.ToList();
                            if (MC.DocumentMaster.Count > 0)
                            {
                                MasterEntity = MC.DocumentMaster[0];
                            }
                            var ItemsData = reader.Read<PUR_T002_B>().ToList();
                            MC.DocumentItems = ItemsData.ToList();
                            var TaxData = reader.Read<ACC_T006_B>().ToList();
                            MC.DocumentTaxDetails = TaxData.ToList();
                            var Schedule_B_Data = reader.Read<PUR_T004_B>().ToList();
                            MC.DocumentScheduleDetails = Schedule_B_Data.ToList();
                            var Schedule_A_Data = reader.Read<PUR_T004_A>().ToList();
                            MC.DocumentScheduleMaster = Schedule_A_Data.ToList();

                            var TermsAndConditionEntity = reader.Read<PUR_T002_H>().ToList();
                            MC.TermsAndCondition = TermsAndConditionEntity.ToList();

                            var LicenceData = reader.Read<ACC_T006_D>().ToList();
                            MC.LicenceEntity = LicenceData.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "LoadDocumentWithDocumentNumber") //For Flip
                        {
                            MC.DocumentMaster = reader.Read<PUR_T002_A>().ToList();
                            if (MC.DocumentMaster.Count > 0)
                            {
                                MasterEntity = MC.DocumentMaster[0];
                            }
                            MC.DocumentItems = reader.Read<PUR_T002_B>().ToList();
                            MC.DocumentTaxDetails = reader.Read<ACC_T006_B>().ToList();
                            MC.DocumentScheduleDetails = reader.Read<PUR_T004_B>().ToList();
                            MC.DocumentScheduleMaster = reader.Read<PUR_T004_A>().ToList();
                            MC.Attachment = reader.Read<COM_T003>().ToList();
                            MC.TermsAndCondition = reader.Read<PUR_T002_H>().ToList();
                            MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                            MC.ApprovalData = reader.Read<ADM_M043_D>().ToList();
                            MC.ComponantList = reader.Read<PUR_T002_C>().ToList();
                            MC.ContactPerson = reader.Read<ADM_M028_C_P>().ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "PO_Report") //For Flip
                        {
                            var MasterData = reader.Read<PUR_T002_A>().ToList();
                            MC.DocumentMaster = MasterData.ToList();

                            var ItemsData = reader.Read<RptPUR_T002_B>().ToList();
                            MC.RptDocumentItems = ItemsData.ToList();

                            var TaxData = reader.Read<ACC_T006_B>().ToList();
                            MC.DocumentTaxDetails = TaxData.ToList();

                            var Schedule_B_Data = reader.Read<PUR_T004_B>().ToList();
                            MC.DocumentScheduleDetails = Schedule_B_Data.ToList();

                            var TermsAndConditionEntity = reader.Read<PUR_T002_H>().ToList();
                            MC.TermsAndCondition = TermsAndConditionEntity.ToList();

                            var LicenceData = reader.Read<ACC_T006_D>().ToList();
                            MC.LicenceEntity = LicenceData.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
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
    public class MultipleContext_PUR_T002_A
    {
        public List<STD_LIST_BE> PR_LIST { get; set; }
        public List<ACC_M007_A> PAY_TERMD { get; set; }
        public List<ADM_M0071> PARAMETERS_VALUES_LIST { get; set; }
        public List<ADM_M0002> COMPANY_LIST { get; set; }
        public List<ADM_M0003> LOCATION_LIST { get; set; }
        public List<STD_LIST_BE> KEY_DATA_LIST { get; set; }
        public List<STD_DOC_TYPE> DOC_TYPE_LIST { get; set; }
        public List<PUR_T002_AFlip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> partyList { get; set; }
        public List<ADM_M038_B_P> unitList { get; set; }
        public List<ADM_M024_P> BuyerList { get; set; }
        public List<ACC_M005_P> journalList { get; set; }
        public List<ACC_M013_P> TaxList { get; set; }
        public List<ACC_M003_P> AccountList { get; set; }
        public List<ACC_M007_P> PayTerms { get; set; }
        public List<MM_M002_P> WarehouseList { get; set; }
        public List<SYS_M007> DocumentTypes { get; set; }
        public List<SYS_M007> doc_typeList { get; set; }
        public List<ADM_M037_P> currencyList { get; set; }
        public List<ADM_M037> CURRENCY_LIST { get; set; }
        public List<PUR_T002_P_RefeDoc> reference_docList { get; set; }
        public List<ADM_M001_M_P> purchase_orgList { get; set; }
        public List<ADM_M001_P_P> Purchase_groupList { get; set; }
        public List<MM_M001_P> storage_locList { get; set; }
        public List<ACC_M019_P> cost_centerList { get; set; }
        public List<ADM_M002_P> billaddrList { get; set; }
        public List<ADM_M003_P> deladdrList { get; set; }
        public List<SYS_M008_P> itemcatList { get; set; }
        public List<PUR_T002_P_PR_ItemsList> ItemListForPopup { get; set; }
        public List<PUR_T002_A> DocumentMaster { get; set; }
        public List<PUR_T002_B> DocumentItems { get; set; }
        public List<PUR_T002_C> DocumentTax { get; set; }
        public List<ACC_T006_B> DocumentTaxDetails { get; set; }
        public List<PUR_T004_A> DocumentScheduleMaster { get; set; }
        public List<PUR_T004_B> DocumentScheduleDetails { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<PUR_T002_H> TermsAndCondition { get; set; }
        public List<GEN_T011> TCondition { get; set; }
        public List<MM_M008_P> TermsConditionCollection { get; set; }
        public List<Purchase_Requision_Data> RequisitionItem { get; set; }
        public List<ADM_M028_C_P> ContactPerson { get; set; }
        public List<ACC_M013_P> FormType { get; set; }
        public List<ADM_M030_P> ParameterValue { get; set; }
        public List<ADM_M038_C> UnitConversion { get; set; }
        public List<ADM_M044_P> Incoterms { get; set; }
        public List<ADM_M041_P> LicenseAdvance { get; set; }
        public List<ADM_M041_P> LicenseEPCG { get; set; }
        public List<ADM_M041_P> LicenceList { get; set; }
        public List<ACC_T006_D> LicenceEntity { get; set; }
        public List<ADM_M003_C_P> BussinessPlaceList { get; set; }
        public List<ACC_M003_O_P> ConditionTypeList { get; set; }
        public List<GetItemDetailsEntity> UnitPriceList { get; set; }
        public List<GetItemDetailsEntity> QFRList { get; set; }
        public List<GetItemDetailsEntity> DispatchList { get; set; }
        public List<GetItemDetailsEntity> ProjectedDispList { get; set; }
        public List<ADM_M043_D> ApprovalData { get; set; }
        public List<RptPUR_T002_B> RptDocumentItems { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<SYS_M037> Trade_Types { get; set; }
        public List<PUR_T002_C> ComponantList { get; set; }
        public List<STD_ITEM> ItemListForComponant { get; set; }
        public List<STD_ITEM> STD_ITEM_LIST { get; set; }
        public List<STD_LIST_BE> STD_LIST_OBJ { get; set; }
        public List<SYS_M026> TransportMode { get; set; }
        public List<ADM_M002_B> ScopeList { get; set; }
        public List<ADM_M0051> CONDITION_LIST { get; set; }
        public List<ADM_M0061_A> CATALOG_LIST { get; set; }
    }
}

