using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Procurement;
using Reflection.EF.ReflectionSystem;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.CRM;
using Reflection.EF.Admin;
using Reflection.EF.ADM;
using Reflection.EF.GEN;

namespace Reflection.BusinessLogic.PRO
{
    public class PRO_T002_BL : ReflectionBusinessLogic
    {
        MultipleContext_PUR_T002_A MC = new MultipleContext_PUR_T002_A();
        PUR_T002_A MasterEntity = new PUR_T002_A();
        PUR_T002_B ItemEntity = new PUR_T002_B();
        public PRO_T002_BL()
        { }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string doc_cat = "";
            if (RequestValue.Split('!').Count() >= 5)
            {
                doc_cat = RequestValue.Split('!')[4];
            }

            try
            {
                if (strValue == "GetItemPriceData")
                {
                    using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
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

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                            return ReturnValue;
                        }

                    }
                }
                else
                {
                    using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                    {
                        var reader = conn.QueryMultiple("PUR_T002_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            MC.partyList = reader.Read<ADM_M028_P>().ToList();
                            MC.unitList = reader.Read<ADM_M038_B_P>().ToList();
                            MC.BuyerList = reader.Read<ADM_M024_P>().ToList();
                            MC.TaxList = reader.Read<ACC_M013_P>().ToList();
                            MC.PayTerms = reader.Read<ACC_M007_P>().ToList();
                            MC.PAY_TERMD = reader.Read<ACC_M007_A>().ToList();
                            MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                            MC.CURRENCY_LIST = reader.Read<ADM_M037>().ToList();
                            MC.reference_docList = reader.Read<PUR_T002_P_RefeDoc>().ToList();
                            MC.cost_centerList = reader.Read<ACC_M019_P>().ToList();
                            MC.itemcatList = reader.Read<SYS_M008_P>().ToList();
                            MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                            MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                            MC.NotificationData = reader.Read<NotificationData>().ToList();
                            //MC.TermsConditionCollection = reader.Read<MM_M008_P>().ToList();
                            MC.CONDITION_LIST = reader.Read<ADM_M0051>().ToList();
                            //MC.RequisitionItem = reader.Read<Purchase_Requision_Data>().ToList(); // NOTE: depricated, use PR_LIST instead.
                            MC.PR_LIST = reader.Read<STD_LIST_BE>().ToList(); // NOTE: replace RequisitionItem with this list
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
                            MC.PARAMETERS_VALUES_LIST = reader.Read<ADM_M0071>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadBackFlipData")
                        {
                            var DocDataFlipGrid = reader.Read<PUR_T002_AFlip>().ToList();
                            MC.DocumentDataFlipGrid = DocDataFlipGrid.ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "ExplodeBOM")
                        {
                            MC.STD_LIST_OBJ = reader.Read<STD_LIST_BE>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadPartyDetails")
                        {
                            MC.CONDITION_LIST = reader.Read<ADM_M0051>().ToList();
                            MC.ContactPerson = reader.Read<ADM_M028_C_P>().ToList();
                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadItemsForComponant")
                        {
                            MC.ItemListForComponant = reader.Read<STD_ITEM>().ToList();
                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "CreateDocumentFromRequisitionItemNumber")
                        {
                            MC.DocumentMaster = reader.Read<PUR_T002_A>().ToList();
                            MC.DocumentItems = reader.Read<PUR_T002_B>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadDocumentFromRequisitionnumber")
                        {
                            MC.DocumentItems = reader.Read<PUR_T002_B>().ToList();
                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
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

                            //var TermsAndConditionEntity = reader.Read<PUR_T002_H>().ToList();
                            //MC.TermsAndCondition = TermsAndConditionEntity.ToList();
                            MC.TCondition = reader.Read<GEN_T011>().ToList();

                            var LicenceData = reader.Read<ACC_T006_D>().ToList();
                            MC.LicenceEntity = LicenceData.ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LOAD_DOC_BY_DOC_NO") //For Flip
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
                            //MC.TermsAndCondition = reader.Read<PUR_T002_H>().ToList();
                            MC.TCondition = reader.Read<GEN_T011>().ToList();
                            MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                            MC.ApprovalData = reader.Read<ADM_M043_D>().ToList();
                            MC.ComponantList = reader.Read<PUR_T002_C>().ToList();
                            MC.ContactPerson = reader.Read<ADM_M028_C_P>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
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

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "GET_CATLOG")
                        {
                            MC.CATALOG_LIST = reader.Read<ADM_M0061_A>().ToList();
                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "GET_KEY_DATA")
                        {
                            MC.KEY_DATA_LIST = reader.Read<STD_LIST_BE>().ToList();
                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
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
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T002_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

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
                    MC.TCondition = reader.Read<GEN_T011>().ToList();
                    MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                    MC.ApprovalData = reader.Read<ADM_M043_D>().ToList();
                    MC.ComponantList = reader.Read<PUR_T002_C>().ToList();
                    MC.ContactPerson = reader.Read<ADM_M028_C_P>().ToList();

                    MasterEntity.XmlDataDocument_PUR_T002_B = ObjectSerializationService.ObjectToXML(MC.DocumentItems);
                    MasterEntity.XmlDataDocument_ACC_T006_B = ObjectSerializationService.ObjectToXML(MC.DocumentTaxDetails);
                    MasterEntity.XmlDataDocument_PUR_T004_B = ObjectSerializationService.ObjectToXML(MC.DocumentScheduleDetails);
                    MasterEntity.XmlDataDocument_PUR_T004_A = ObjectSerializationService.ObjectToXML(MC.DocumentScheduleMaster);
                    //Attachment data not Required
                    MasterEntity.XDOC_TC = ObjectSerializationService.ObjectToXML(MC.TCondition);
                    MasterEntity.XmlDataDocument_ACC_T006_D = ObjectSerializationService.ObjectToXML(MC.LicenceEntity);
                    //Approval data not Required
                    MasterEntity.XmlDataDocument_PUR_T002_C = ObjectSerializationService.ObjectToXML(MC.ComponantList);
                    //ContactPerson data not Required

                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MasterEntity);
                return ReturnValue;
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
                    var reader = conn.QueryMultiple("PUR_T002_UPD", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

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
                    MC.TCondition = reader.Read<GEN_T011>().ToList();
                    MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                    MC.ApprovalData = reader.Read<ADM_M043_D>().ToList();
                    MC.ComponantList = reader.Read<PUR_T002_C>().ToList();
                    MC.ContactPerson = reader.Read<ADM_M028_C_P>().ToList();

                    MasterEntity.XmlDataDocument_PUR_T002_B = ObjectSerializationService.ObjectToXML(MC.DocumentItems);
                    MasterEntity.XmlDataDocument_ACC_T006_B = ObjectSerializationService.ObjectToXML(MC.DocumentTaxDetails);
                    MasterEntity.XmlDataDocument_PUR_T004_B = ObjectSerializationService.ObjectToXML(MC.DocumentScheduleDetails);
                    MasterEntity.XmlDataDocument_PUR_T004_A = ObjectSerializationService.ObjectToXML(MC.DocumentScheduleMaster);
                    //Attachment data not Required
                    MasterEntity.XDOC_TC = ObjectSerializationService.ObjectToXML(MC.TCondition);
                    MasterEntity.XmlDataDocument_ACC_T006_D = ObjectSerializationService.ObjectToXML(MC.LicenceEntity);
                    //Approval data not Required
                    MasterEntity.XmlDataDocument_PUR_T002_C = ObjectSerializationService.ObjectToXML(MC.ComponantList);
                    //ContactPerson data not Required
                    
                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MasterEntity);
                return ReturnValue;
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
                    int intOut = conn.Execute("PUR_T002_DEL", new { @po_no = Request }, commandType: CommandType.StoredProcedure);
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
        
    }
}
