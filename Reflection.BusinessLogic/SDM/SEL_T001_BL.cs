using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.Admin;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.CRM;
using System.Collections.Generic;
using Reflection.EF.Communication;
using Reflection.EF.FICO;
using Reflection.EF.ADM;
using Reflection.EF.PMS;
using Reflection.EF.GEN;
using Reflection.EF.COM;

namespace Reflection.BusinessLogic.SDM
{
    public class SEL_T001_BL : ReflectionBusinessLogic
    {
        SEL_T001 MasterEntity = new SEL_T001();
        MC_SDM_BE MC = new MC_SDM_BE();
        public SEL_T001_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T001_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    List<SEL_T001> Masterlist = reader.Read<SEL_T001>().ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    MC.ItemsEntity = reader.Read<SEL_T001_A>().ToList();
                    MC.TaxEntity = reader.Read<ACC_T006_B>().ToList();
                    MC.ScheduleDetailsEntity = reader.Read<SEL_T002_A>().ToList();
                    MC.ScheduleMasterEntity = reader.Read<SEL_T002>().ToList();
                    MC.TermsAndCondition = reader.Read<GEN_T011>().ToList();
                    MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                    MC.PartnerEntity = reader.Read<SEL_T001_PART>().ToList();
                    MC.WORKFLOW_LIST = reader.Read<COM_T011>().ToList();

                    MasterEntity.XmlDataDocument_SEL_T001_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_B = ObjectSerializationService.ObjectToXML(MC.TaxEntity);
                    MasterEntity.XmlDataDocument_SEL_T002 = ObjectSerializationService.ObjectToXML(MC.ScheduleMasterEntity);
                    MasterEntity.XmlDataDocument_SEL_T002_A = ObjectSerializationService.ObjectToXML(MC.ScheduleDetailsEntity);
                    MasterEntity.XDOC_TC = ObjectSerializationService.ObjectToXML(MC.TermsAndCondition);
                    MasterEntity.XmlDataDocument_ACC_T006_D = ObjectSerializationService.ObjectToXML(MC.LicenceEntity);
                    MasterEntity.XDOC_SEL_T001_PART = ObjectSerializationService.ObjectToXML(MC.PartnerEntity);
                    MasterEntity.XDOC_RS = ObjectSerializationService.ObjectToXML(MC.WORKFLOW_LIST);
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
                    var reader = conn.QueryMultiple("SEL_T001_UPD", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    List<SEL_T001> Masterlist = reader.Read<SEL_T001>().ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    MC.ItemsEntity = reader.Read<SEL_T001_A>().ToList();
                    MC.TaxEntity = reader.Read<ACC_T006_B>().ToList();
                    MC.ScheduleDetailsEntity = reader.Read<SEL_T002_A>().ToList();
                    MC.ScheduleMasterEntity = reader.Read<SEL_T002>().ToList();
                    MC.TermsAndCondition = reader.Read<GEN_T011>().ToList();
                    MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                    MC.PartnerEntity = reader.Read<SEL_T001_PART>().ToList();
                    MC.WORKFLOW_LIST = reader.Read<COM_T011>().ToList();

                    MasterEntity.XmlDataDocument_SEL_T001_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_B = ObjectSerializationService.ObjectToXML(MC.TaxEntity);
                    MasterEntity.XmlDataDocument_SEL_T002 = ObjectSerializationService.ObjectToXML(MC.ScheduleMasterEntity);
                    MasterEntity.XmlDataDocument_SEL_T002_A = ObjectSerializationService.ObjectToXML(MC.ScheduleDetailsEntity);
                    MasterEntity.XDOC_TC = ObjectSerializationService.ObjectToXML(MC.TermsAndCondition);
                    MasterEntity.XmlDataDocument_ACC_T006_D = ObjectSerializationService.ObjectToXML(MC.LicenceEntity);
                    MasterEntity.XDOC_SEL_T001_PART = ObjectSerializationService.ObjectToXML(MC.PartnerEntity);
                    MasterEntity.XDOC_RS = ObjectSerializationService.ObjectToXML(MC.WORKFLOW_LIST);

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
        public string Delete(int Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    int intOut = conn.Execute("SEL_T001_DEL", new { @id = Request }, commandType: CommandType.StoredProcedure);
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
            string RequestOption = RequestValue.Split('!')[0];
            try
            {
                if (strValue == "GetItemPriceData")
                {
                    using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                    {
                        var reader = conn.QueryMultiple("GetSalesData", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "GetItemPrice")
                        {
                            //var UnitPriceList = reader.Read<GetItemDetailsEntity>().ToList();
                            //MC.UnitPriceList = UnitPriceList.ToList();
                            //var QFRList = reader.Read<GetItemDetailsEntity>().ToList();
                            //MC.QFRList = QFRList.ToList();
                            //var DispatchList = reader.Read<GetItemDetailsEntity>().ToList();
                            //MC.DispatchList = DispatchList.ToList();
                            //var ProjectedDispList = reader.Read<GetItemDetailsEntity>().ToList();
                            //MC.ProjectedDispList = ProjectedDispList.ToList();

                            base.ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                            return base.ReturnValue;
                        }

                    }
                }
                else
                {
                    using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                    {
                        var reader = conn.QueryMultiple("SEL_T001_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LOAD_INI")
                        {
                            
                            MC.PARTY_LIST = reader.Read<STD_PARTY>().ToList();
                            MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                            MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                            MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                            MC.SUPPLIER_LIST = reader.Read<STD_PARTY>().ToList();
                            MC.UOM_LIST = reader.Read<UOMS>().ToList();
                            MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                            MC.TR_MODE_LIST = reader.Read<SYS_M026>().ToList();
                            MC.TAX_LIST = reader.Read<ACC_M013>().ToList();
                            MC.GL_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.PAY_TERM_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.CURRENCY_LIST = reader.Read<ADM_M037>().ToList();
                            MC.ORG_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.ORG_GROUP_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.LINE_CAT_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.INCOTERM_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.COUNTRY_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.STATE_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.UOM_CONVERSION_LIST = reader.Read<UOMS>().ToList();
                            MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                            MC.TRADE_INDICATOR = reader.Read<STD_LIST_BE>().ToList();
                            MC.BANK_ACCOUNT_LIST = reader.Read<FICO_M0004>().ToList();
                            MC.PARAMETERS_LIST = reader.Read<ADM_M0071>().ToList();
                            MC.PARAMETERS_VALUES_LIST = reader.Read<ADM_M0071>().ToList();
                            MC.LicenceList = reader.Read<ADM_M041_P>().ToList();
                            MC.ConditionTypeList = reader.Read<ACC_M003_O_P>().ToList();
                            MC.NotificationData = reader.Read<NotificationData>().ToList();
                            MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.ELEMENT_LIST = reader.Read<PMS_T002>().ToList();
                            MC.PF_CODE_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.TYPE_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.PARA_TYPE_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.CONDITION_LIST = reader.Read<ADM_M0051>().ToList();
                            MC.MASTER_TASK_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.SUPPLIER_LIST = reader.Read<STD_PARTY>().ToList();
                            MC.PRICE_LIST = reader.Read<STD_LIST_BE>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        if (RequestOption == "LOAD_DATA_FOR_COMPANY")
                        {

                            MC.PARTY_LIST = reader.Read<STD_PARTY>().ToList();
                            MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                            MC.SUPPLIER_LIST = reader.Read<STD_PARTY>().ToList();
                            MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                            MC.GL_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.PAY_TERM_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.CURRENCY_LIST = reader.Read<ADM_M037>().ToList();
                            MC.ORG_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.ORG_GROUP_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.LINE_CAT_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.INCOTERM_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.COUNTRY_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.STATE_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.UOM_CONVERSION_LIST = reader.Read<UOMS>().ToList();
                            MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                            MC.TRADE_INDICATOR = reader.Read<STD_LIST_BE>().ToList();
                            MC.BANK_ACCOUNT_LIST = reader.Read<FICO_M0004>().ToList();
                            MC.PARAMETERS_LIST = reader.Read<ADM_M0071>().ToList();
                            MC.PARAMETERS_VALUES_LIST = reader.Read<ADM_M0071>().ToList();
                            MC.LicenceList = reader.Read<ADM_M041_P>().ToList();
                            MC.ConditionTypeList = reader.Read<ACC_M003_O_P>().ToList();
                            MC.NotificationData = reader.Read<NotificationData>().ToList();
                            MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LOAD_SOLD_TO_PARTY")
                        {
                            MC.STD_ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                            MC.PARTY_CONTACT_LIST = reader.Read<STD_PARTY>().ToList();
                            MC.BILLING_ADDRESS_LIST = reader.Read<STD_PARTY>().ToList();
                            MC.CONDITION_LIST = reader.Read<ADM_M0051>().ToList();
                            

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LOAD_SHIP_TO_PARTY")
                        {
                            MC.SHIPPING_ADDRESS_LIST = reader.Read<STD_PARTY>().ToList();
                            MC.STD_ITEM_LIST = reader.Read<STD_ITEM>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LOAD_BACKFLIP")
                        {
                            MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LOAD_REFERING_PARTY")
                        {
                            MC.OTHER_CONTACT_LIST = reader.Read<STD_PARTY>().ToList();
                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "EXECUTE_DOC_BY_REF_DOC")
                        {
                            MC.MasterEntity = reader.Read<SEL_T001>().ToList();
                            if (MC.MasterEntity.Count > 0)
                            {
                                MasterEntity = MC.MasterEntity[0];
                            }
                            MC.ItemsEntity = reader.Read<SEL_T001_A>().ToList();
                            MC.TaxEntity = reader.Read<ACC_T006_B>().ToList();
                            MC.ScheduleDetailsEntity = reader.Read<SEL_T002_A>().ToList();
                            MC.ScheduleMasterEntity = reader.Read<SEL_T002>().ToList();
                            MC.TermsAndCondition = reader.Read<GEN_T011>().ToList();
                            MC.PartnerEntity = reader.Read<SEL_T001_PART>().ToList();
                            MC.PARTY_CONTACT_LIST = reader.Read<STD_PARTY>().ToList();
                            MC.BILLING_ADDRESS_LIST = reader.Read<STD_PARTY>().ToList();
                            MC.SHIPPING_ADDRESS_LIST = reader.Read<STD_PARTY>().ToList();
                            MC.CONDITION_LIST = reader.Read<ADM_M0051>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                        {
                            MC.MasterEntity = reader.Read<SEL_T001>().ToList();
                            if (MC.MasterEntity.Count > 0)
                            {
                                MasterEntity = MC.MasterEntity[0];
                            }
                            MC.ItemsEntity = reader.Read<SEL_T001_A>().ToList();
                            MC.TaxEntity = reader.Read<ACC_T006_B>().ToList();
                            MC.ScheduleDetailsEntity = reader.Read<SEL_T002_A>().ToList();
                            MC.ScheduleMasterEntity = reader.Read<SEL_T002>().ToList();
                            MC.TermsAndCondition = reader.Read<GEN_T011>().ToList();
                            MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                            MC.PartnerEntity = reader.Read<SEL_T001_PART>().ToList();
                            MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList();
                            MC.PARTY_CONTACT_LIST = reader.Read<STD_PARTY>().ToList();
                            MC.BILLING_ADDRESS_LIST = reader.Read<STD_PARTY>().ToList();
                            MC.SHIPPING_ADDRESS_LIST = reader.Read<STD_PARTY>().ToList();
                            MC.CONDITION_LIST = reader.Read<ADM_M0051>().ToList();
                            MC.WORKFLOW_LIST = reader.Read<COM_T011>().ToList();


                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "PRINT_DOCUMENT")
                        {
                            MC.MasterEntity = reader.Read<SEL_T001>().ToList();
                            MC.ItemsEntity = reader.Read<SEL_T001_A>().ToList();
                            MC.TaxEntity = reader.Read<ACC_T006_B>().ToList();
                            MC.ScheduleDetailsEntity = reader.Read<SEL_T002_A>().ToList();
                            MC.TermsAndCondition = reader.Read<GEN_T011>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        //else if (RequestOption == "GET_CATLOG")
                        //{
                        //    MC.CATALOG_LIST = reader.Read<ADM_M0061_A>().ToList();
                        //    ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        //}
                        else if (RequestOption == "GET_KEY_DATA")
                        {
                            MC.KEY_DATA_LIST = reader.Read<STD_LIST_BE>().ToList();
                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LOAD_PARTY_DATA")
                        {
                            MC.PARTY_CONTACT_LIST = reader.Read<STD_PARTY>().ToList();
                            MC.BILLING_ADDRESS_LIST = reader.Read<STD_PARTY>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "SDM_BOM_EXPLODE")
                        {
                            MC.BOM_LIST = reader.Read<STD_LIST_BE>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "CREATE_BILLING_PLAN")
                        {
                            MC.BillingPlanEntity = reader.Read<ACC_T021>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "GET_BOM_ITEM_LIST")
                        {
                            MC.STD_ITEM_LIST = reader.Read<STD_ITEM>().ToList();
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

        public string InsertImportedLead(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T001_IMP", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                    MC.MasterEntity = reader.Read<SEL_T001>().ToList();

                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MC);
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
    }
}
