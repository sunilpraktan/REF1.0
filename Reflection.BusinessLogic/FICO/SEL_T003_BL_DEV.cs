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
using Reflection.EF.GEN;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic.FICO
{
    public class SEL_T003_BL_DEV : ReflectionBusinessLogic
    {
        SEL_T003 MasterEntity = new SEL_T003();
        MC_SEL_T003 MC = new MC_SEL_T003();

        public SEL_T003_BL_DEV()
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
                    MC.ConditionEntity = reader.Read<ACC_T006_C>().ToList();
                    MC.TermsAndCondition = reader.Read<GEN_T011>().ToList();

                    MasterEntity.XmlDataDocument_SEL_T003_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = ObjectSerializationService.ObjectToXML(MC.ConditionEntity);
                    MasterEntity.XDOC_TC = ObjectSerializationService.ObjectToXML(MC.TermsAndCondition);
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
                    MC.ConditionEntity = reader.Read<ACC_T006_C>().ToList();
                    MC.TermsAndCondition = reader.Read<GEN_T011>().ToList();

                    MasterEntity.XmlDataDocument_SEL_T003_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = ObjectSerializationService.ObjectToXML(MC.ConditionEntity);
                    MasterEntity.XDOC_TC = ObjectSerializationService.ObjectToXML(MC.TermsAndCondition);
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
                            MC.ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                            MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                            MC.PARTY_LIST = reader.Read<STD_PARTY>().ToList();
                            //MC.CP_LIST = reader.Read<GEN_M0021>().ToList();
                            //MC.CN_LIST = reader.Read<GEN_M0031>().ToList();
                            //MC.ADDRESS_LIST = reader.Read<GEN_M0011>().ToList();
                            MC.TAX_LIST = reader.Read<ACC_M013>().ToList();
                            MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                            MC.BANK_ACCOUNT_LIST = reader.Read<FICO_M0004>().ToList();
                            MC.PAYTERM_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.CONDITION_LIST = reader.Read<ADM_M0051>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LOAD_BACKFLIP")
                        {
                            MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();

                            ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LOAD_DOCUMENT")// for backflip
                        {

                            MC.MasterEntity = reader.Read<SEL_T003>().ToList();
                            MC.ItemsEntity = reader.Read<SEL_T003_A>().ToList();
                            MC.ConditionEntity = reader.Read<ACC_T006_C>().ToList();
                            MC.TermsAndCondition = reader.Read<GEN_T011>().ToList();
                            MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList(); // NOTE: May be not required in POS

                            // NOTE: following is exist in current BL and SP. check which is to keep or remove in new BL & SP
                            //MC.ItemListPopup = reader.Read<SEL_T003_P_SI_ItemsList>().ToList();//this is load from sold to party
                            //MC.PartysSoldToAddresses = reader.Read<ADM_M028_D_P>().ToList();
                            //MC.CustCatlogNo = reader.Read<CRM_T001A_P>().ToList();
                            //MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                            //MC.withholdinglist = reader.Read<ACC_M025_P>().ToList();

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



}
