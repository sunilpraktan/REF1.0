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
using Reflection.EF.FICO;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic.FICO
{
    public class PUR_T005_BL : ReflectionBusinessLogic
    {
        PUR_T005 MasterEntity = new PUR_T005();
        MC_PUR_T005 MC = new MC_PUR_T005();
        public PUR_T005_BL()
        {
        }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T005_INS", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    MC.MasterEntity = reader.Read<PUR_T005>().ToList();
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }
                    MC.ItemsEntity = reader.Read<PUR_T005_A>().ToList();
                    MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                    MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                    MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList();
                    MC.WITHHOLDING_LIST = reader.Read<STD_FICO_BE>().ToList();

                    MasterEntity.XmlDataDocument_PUR_T005_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = ObjectSerializationService.ObjectToXML(MC.TaxEntity);
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
                    var reader = conn.QueryMultiple("PUR_T005_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    List<PUR_T005> Masterlist = reader.Read<PUR_T005>().ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    MC.ItemsEntity = reader.Read<PUR_T005_A>().ToList();
                    MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                    MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                    MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList();
                    MC.WITHHOLDING_LIST = reader.Read<STD_FICO_BE>().ToList();

                    MasterEntity.XmlDataDocument_PUR_T005_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = ObjectSerializationService.ObjectToXML(MC.TaxEntity);
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
                int intOut;
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    intOut = conn.Execute("PUR_T005_DEL", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
            try
            {
                if (RequestOption != "ValidateInvoice" && RequestOption != "Trace_Report")
                {
                    using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                    {
                        var reader = conn.QueryMultiple("PUR_T005_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LOAD_INI")
                        {
                            //MC.Purchase_Invoice_Reference = reader.Read<PUR_T005_P_RefDoc>().ToList();
                            MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList();
                            //MC.TaxList = reader.Read<ACC_M013_P>().ToList();
                            MC.TAX_LIST = reader.Read<ACC_M013>().ToList();
                            //MC.BankList = reader.Read<ACC_M004_P>().ToList();
                            //MC.BANK_ACCOUNT_LIST = reader.Read<FICO_M0004>().ToList(); // Hold
                            //MC.PayMethod = reader.Read<ACC_M021_P>().ToList();
                            //MC.PAYMENT_METHOD_LIST = reader.Read<STD_LIST_BE>().ToList(); // Hold
                            //MC.NotificationData = reader.Read<NotificationData>().ToList();
                            MC.NOTIFICATION_LIST = reader.Read<NotificationData>().ToList();
                            //MC.ConditionTypeList = reader.Read<ACC_M003_O_P>().ToList();
                            MC.CONDITION_TYPE_LIST = reader.Read<STD_FICO_BE>().ToList();
                            //MC.LicenceList = reader.Read<ADM_M041_P>().ToList();
                            MC.LICENCE_LIST = reader.Read<STD_FICO_BE>().ToList();
                            //MC.BussinessPlaceList = reader.Read<ADM_M003_C_P>().ToList(); //Removed
                            //MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList(); //Removed
                            MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList(); //Removed
                            //MC.Cost_Centers = reader.Read<ACC_M019_P>().ToList();
                            //MC.COST_CENTER_LIST = reader.Read<FICO_M0019>().ToList();// Removed
                            //MC.ItemListPopup = reader.Read<PUR_T005_P_PI_ItemsList>().ToList();
                            MC.STD_ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                            //MC.Trade_Types = reader.Read<SYS_M037>().ToList();  //Removed. Pick Automatically from SO.
                            MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();

                        }
                        else if (RequestOption == "EXECUTE_REFERENCE")
                        {
                            MC.MasterEntity = reader.Read<PUR_T005>().ToList();
                            MC.ItemsEntity = reader.Read<PUR_T005_A>().ToList();
                            MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                        }
                        else if (RequestOption == "LOAD_BACKFLIP")
                        {
                            MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                        }
                        else if (RequestOption == "LOAD_DOC_BY_DOC_NO")// Load from Back Flip
                        {
                            MC.MasterEntity = reader.Read<PUR_T005>().ToList();
                            MC.ItemsEntity = reader.Read<PUR_T005_A>().ToList();
                            MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                            MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList();
                            MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                            MC.WITHHOLDING_LIST = reader.Read<STD_FICO_BE>().ToList();
                        }


                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);


                        //else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")// Load from Back Flip
                        //{
                        //    MC.MasterEntity = reader.Read<PUR_T005>().ToList();
                        //    MC.ItemsEntity = reader.Read<PUR_T005_A>().ToList();
                        //    MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                        //    MC.ItemListPopup = reader.Read<PUR_T005_P_PI_ItemsList>().ToList();
                        //    MC.Attachment = reader.Read<COM_T003>().ToList();
                        //    MC.LicenceEntity = reader.Read<ACC_T006_D>().ToList();
                        //    MC.withholdinglist = reader.Read<ACC_M025_P>().ToList();
                        //}
                        //else if (RequestOption == "LoadDocumentFromGRNumber")  // Load from PO and GRN Number
                        //{
                        //    MC.MasterEntity = reader.Read<PUR_T005>().ToList();
                        //    MC.ItemsEntity = reader.Read<PUR_T005_A>().ToList();
                        //    MC.withholdinglist = reader.Read<ACC_M025_P>().ToList();
                        //}
                        //else if (RequestOption == "LoadDocumentFromPOReferneceNo")  // Load from PO and GRN Number
                        //{
                        //    MC.MasterEntity = reader.Read<PUR_T005>().ToList();
                        //    MC.ItemsEntity = reader.Read<PUR_T005_A>().ToList();
                        //}
                        //else if (RequestOption == "LoadFromDateToDate")
                        //{
                        //    MC.DocumentDataFlipGrid = reader.Read<PUR_T005_Flip>().ToList();
                        //}
                        //else if (RequestOption == "LoadGRN")
                        //{
                        //    MC.ItemListPopup = reader.Read<PUR_T005_P_PI_ItemsList>().ToList();
                        //}
                        //else if (RequestOption == "LoadPO")
                        //{
                        //    MC.ItemListPopup = reader.Read<PUR_T005_P_PI_ItemsList>().ToList();
                        //}
                        //else if (RequestOption == "LoadHistory")
                        //{
                        //    MC.DocumentDataFlipGrid = reader.Read<PUR_T005_Flip>().ToList();
                        //}
                        //else if (RequestOption == "LoadWithoutReference")
                        //{
                        //    MC.Cost_Centers = reader.Read<ACC_M019_P>().ToList();
                        //    MC.CurrencyList = reader.Read<ADM_M037_P>().ToList();
                        //    MC.ParameterList = reader.Read<ADM_M031_P>().ToList();
                        //    MC.ParamValueList = reader.Read<ADM_M030_P>().ToList();
                        //}

                        // This is from Standard Class. refer SP for more detail info
                        //else if (RequestOption == "LoadInitialData_STD")
                        //{
                        //    MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList();
                        //    MC.TAX_LIST = reader.Read<ACC_M013>().ToList();
                        //    MC.STATUS_LIST = reader.Read<SYS_M025>().ToList();
                        //    //MC.ItemList = reader.Read<STD_ITEM>().ToList();
                        //    //MC.UOMList = reader.Read<ADM_M038_B>().ToList();
                        //}



                        // This is from Standard Class. refer SP for more detail info End.
                    }
                }
                else if (RequestOption == "ValidateInvoice")
                {
                    using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                    {
                        var reader = conn.QueryMultiple("PUR_T005_VALD", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                        MC.MasterEntity = reader.Read<PUR_T005>().ToList();
                        return ObjectSerializationService.ObjectToXML(MC);
                    }
                }
                else if (RequestOption == "Trace_Report")
                {
                    using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                    {
                        RequestValue = RequestValue.Split('!')[1];
                        var reader = conn.QueryMultiple("PUR_T005_TRACE", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                        //MC.TraceList = reader.Read<InvoiceTraceEntity>().ToList();
                        return ObjectSerializationService.ObjectToXML(MC);
                    }
                }

                return ObjectSerializationService.ObjectToXML(MC);
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
