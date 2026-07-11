using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.CRM;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.Admin;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.ADM;
using Reflection.BusinessLogic.REF;

namespace Reflection.BusinessLogic
{
    public class SEL_T001BL : ReflectionBusinessLogic
    {

        private static string connectionString;

        SEL_T001 MasterEntity = new SEL_T001();
        //List<SEL_T001> MasterEntity = new List<SEL_T001>();
        MultipleContext_SEL_T001 MC = new MultipleContext_SEL_T001();
        ReflectionServices ServiceObject = new ReflectionServices();

        public SEL_T001BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public SEL_T001BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            MultipleContext_SEL_T001 MC = new MultipleContext_SEL_T001();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T001Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    //var FlipGridData = reader.Read<SEL_T001_Flip>().ToList();
                    //MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<SEL_T001>().ToList();
                    List<SEL_T001> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    var ItemsData = reader.Read<SEL_T001_A>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();
                    var TaxData = reader.Read<ACC_T006_B>().ToList();
                    MC.TaxEntity = TaxData.ToList();
                    var Schedule_B_Data = reader.Read<SEL_T002_A>().ToList();
                    MC.ScheduleDetailsEntity = Schedule_B_Data.ToList();
                    var Schedule_A_Data = reader.Read<SEL_T002>().ToList();
                    MC.ScheduleMasterEntity = Schedule_A_Data.ToList();
                    var TermsAndConditionEntity = reader.Read<SEL_T001_E>().ToList();
                    MC.TermsAndCondition = TermsAndConditionEntity.ToList();

                    var Licence_Data = reader.Read<ACC_T006_D>().ToList();
                    MC.LicenceEntity = Licence_Data.ToList();

                    MasterEntity.XmlDataDocument_SEL_T001_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_B = ObjectSerializationService.ObjectToXML(MC.TaxEntity);
                    MasterEntity.XmlDataDocument_SEL_T002 = ObjectSerializationService.ObjectToXML(MC.ScheduleMasterEntity);
                    MasterEntity.XmlDataDocument_SEL_T002_A = ObjectSerializationService.ObjectToXML(MC.ScheduleDetailsEntity);
                    //MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_SEL_T001_E = ObjectSerializationService.ObjectToXML(MC.TermsAndCondition);
                    MasterEntity.XmlDataDocument_ACC_T006_D = ObjectSerializationService.ObjectToXML(MC.LicenceEntity);
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
            MultipleContext_SEL_T001 MC = new MultipleContext_SEL_T001();

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T001Update", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    //var FlipGridData = reader.Read<SEL_T001_Flip>().ToList();
                    //MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<SEL_T001>().ToList();
                    List<SEL_T001> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    var ItemsData = reader.Read<SEL_T001_A>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();
                    var TaxData = reader.Read<ACC_T006_B>().ToList();
                    MC.TaxEntity = TaxData.ToList();
                    var Schedule_B_Data = reader.Read<SEL_T002_A>().ToList();
                    MC.ScheduleDetailsEntity = Schedule_B_Data.ToList();
                    var Schedule_A_Data = reader.Read<SEL_T002>().ToList();
                    MC.ScheduleMasterEntity = Schedule_A_Data.ToList();
                    var TermsAndConditionEntity = reader.Read<SEL_T001_E>().ToList();
                    MC.TermsAndCondition = TermsAndConditionEntity.ToList();
                    var Licence_Data = reader.Read<ACC_T006_D>().ToList();
                    MC.LicenceEntity = Licence_Data.ToList();

                    MasterEntity.XmlDataDocument_SEL_T001_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_B = ObjectSerializationService.ObjectToXML(MC.TaxEntity);
                    MasterEntity.XmlDataDocument_SEL_T002 = ObjectSerializationService.ObjectToXML(MC.ScheduleMasterEntity);
                    MasterEntity.XmlDataDocument_SEL_T002_A = ObjectSerializationService.ObjectToXML(MC.ScheduleDetailsEntity);
                    //MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_SEL_T001_E = ObjectSerializationService.ObjectToXML(MC.TermsAndCondition);
                    MasterEntity.XmlDataDocument_ACC_T006_D = ObjectSerializationService.ObjectToXML(MC.LicenceEntity);

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
        public string Delete(int Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("SEL_T001Delete", new { @id = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_SEL_T001 MC = new MultipleContext_SEL_T001();
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
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("SEL_T001LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var DocTypes = reader.Read<SYS_M002>().ToList();
                            MC.DocumentTypes = DocTypes.ToList();                          
                            var partyMaster = reader.Read<ADM_M028_P>().ToList();
                            MC.PartyMaster = partyMaster.ToList();
                            var transporter = reader.Read<ADM_M028_P>().ToList();
                            MC.Transporters = transporter.ToList();
                            var serviceProvider = reader.Read<ADM_M028_P>().ToList();
                            MC.ServiceProviders = serviceProvider.ToList();
                            var uom = reader.Read<ADM_M038_B_P>().ToList();
                            MC.UOM = uom.ToList();
                            var sellers = reader.Read<ADM_M024_P>().ToList();
                            MC.Sellers = sellers.ToList();
                            MC.TransportMode = reader.Read<SYS_M026>().ToList();
                            
                            var taxlist = reader.Read<ACC_M013_P>().ToList();
                            MC.TaxList = taxlist.ToList();
                            var glCode = reader.Read<ACC_M003_P>().ToList();
                            MC.GLCodes = glCode.ToList();
                            var payTerms = reader.Read<ACC_M007_P>().ToList();
                            MC.PayTerms = payTerms.ToList();
                            var currency = reader.Read<ADM_M037_P>().ToList();
                            MC.Currencys = currency.ToList();
                            var salesOrg = reader.Read<ADM_M001_A_P>().ToList();
                            MC.SalesOrg = salesOrg.ToList();
                            var salesGroup = reader.Read<ADM_M001_H_P>().ToList();
                            MC.SalesGroup = salesGroup.ToList();
                            var salesdiv = reader.Read<ADM_M001_D_P>().ToList();
                            MC.SalesDiv = salesdiv.ToList();
                            var itemlinecat = reader.Read<SYS_M003_P>().ToList();
                            MC.ItemLineCategory = itemlinecat.ToList();
                            var costCenter = reader.Read<ACC_M019_P>().ToList();
                            MC.Cost_Centers = costCenter.ToList();
                            
                            var ballTypes = reader.Read<ZADM_M002_P>().ToList();
                            MC.BallTypes = ballTypes.ToList();
                            var ilds = reader.Read<ZADM_M007_P>().ToList();
                            MC.ILDs = ilds.ToList();
                            var wireTypes = reader.Read<ZADM_M004_P>().ToList();
                            MC.WireTypes = wireTypes.ToList();
                            var ballDias = reader.Read<ZADM_M001_P>().ToList();
                            MC.BallDias = ballDias.ToList();
                            var inks = reader.Read<ZADM_M006_P>().ToList();
                            MC.Inks = inks.ToList();
                            var incoterms = reader.Read<ADM_M044_P>().ToList();
                            MC.Incoterms = incoterms.ToList();
                            var LicAdvance = reader.Read<ADM_M041_P>().ToList();
                            MC.LicenseAdvance = LicAdvance.ToList();
                            var LicEPCG = reader.Read<ADM_M041_P>().ToList();
                            MC.LicenseEPCG = LicEPCG.ToList();
                            var SOReferance = reader.Read<SEL_T001_P_RefDoc>().ToList();
                            MC.Sales_Order_Reference = SOReferance.ToList();
                            var countryMaster = reader.Read<ADM_M012_P>().ToList();
                            MC.CountryMaster = countryMaster.ToList();
                            var stateMaster = reader.Read<ADM_M013_P>().ToList();
                            MC.StateMaster = stateMaster.ToList();
                            var itemlistpopup = reader.Read<SEL_T001_P_SO_ItemsList>().ToList();
                            MC.ItemListPopup = itemlistpopup.ToList();
                            var NotificationData = reader.Read<NotificationData>().ToList();
                            MC.NotificationData = NotificationData.ToList();
                            var Grade = reader.Read<ADM_M045_P>().ToList();
                            MC.GradeCollection = Grade.ToList();
                            var termsCondition = reader.Read<CRM_M001_P>().ToList();
                            MC.TermsConditionCollection = termsCondition.ToList();
                            MC.UnitConversion = reader.Read<ADM_M038_C>().ToList();
                            MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                            MC.Trade_Types = reader.Read<SYS_M037>().ToList();
                            var bank = reader.Read<ACC_M004_P>().ToList();
                            MC.Banks = bank.ToList();
                            MC.hbList = reader.Read<ACC_M004_P>().ToList();
                            MC.ConditionTypeList = reader.Read<ACC_M003_O_P>().ToList();
                            MC.ParameterDetails = reader.Read<ADM_M031_P>().ToList();
                            MC.ParameterValueDetails = reader.Read<ADM_M030_P>().ToList();


                            var supplier = reader.Read<ADM_M028_P>().ToList();
                            MC.Supplier = supplier.ToList();
                            
                            
                            var ModelNo = reader.Read<ZADM_M009_P>().ToList();
                            MC.ModelNo = ModelNo.ToList();
                            var FinishGoodMaster = reader.Read<ZADM_M010>().ToList();
                            MC.FinishGoodMaster = FinishGoodMaster.ToList();
                            var ParameterTemp = reader.Read<ADM_M031_P>().ToList();
                            MC.ParameterList = ParameterTemp.ToList();
                            var ParamValueTemp = reader.Read<ADM_M030_P>().ToList();
                            MC.ParamValueList = ParamValueTemp.ToList();
                            var PackingTemp = reader.Read<ZADM_M017_P>().ToList();
                            MC.PackingList = PackingTemp.ToList();
                            
                            var LicenceTemp = reader.Read<ADM_M041_P>().ToList();
                            MC.LicenceList = LicenceTemp.ToList();
                            var BussinessPlaceTemp = reader.Read<ADM_M003_C_P>().ToList();
                            MC.BussinessPlaceList = BussinessPlaceTemp.ToList();
                            var make = reader.Read<ADM_M032_P>().ToList();
                            MC.Make = make.ToList();


                            var ScopeListTemp = reader.Read<ADM_M002_B>().ToList();
                            MC.ScopeList = ScopeListTemp.ToList();



                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadSoldToPartyDetails")
                        {
                            var partycontactinfo = reader.Read<ADM_M028_C_P>().ToList();
                            MC.PartysContactInfo = partycontactinfo.ToList();
                            var partysoldtoadd = reader.Read<ADM_M028_D>().ToList();
                            MC.PartysSoldToAddresses = partysoldtoadd.ToList();
                            var itemlistpopup = reader.Read<SEL_T001_P_SO_ItemsList>().ToList();
                            MC.ItemListPopup = itemlistpopup.ToList();
                            var TermsAndCondition = reader.Read<SEL_T001_E>().ToList();
                            MC.TermsAndCondition = TermsAndCondition.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadBackFlipData")
                        {
                            var DocDataFlipGrid = reader.Read<SEL_T001_Flip>().ToList();
                            MC.DocumentDataFlipGrid = DocDataFlipGrid.ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadShipToPartyDetails")
                        {
                            var partyshiptoaddress = reader.Read<ADM_M028_D>().ToList();
                            MC.PartysShipToAddresses = partyshiptoaddress.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadRefferingPartyDetails")
                        {
                            var partyshiptoaddress = reader.Read<ADM_M028_C_P>().ToList();
                            MC.RefPartyContactInfo = partyshiptoaddress.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                        {
                            var MasterData = reader.Read<SEL_T001>().ToList();
                            MC.MasterEntity = MasterData.ToList();
                            if (MC.MasterEntity.Count > 0)
                            {
                                MasterEntity = MC.MasterEntity[0];
                            }
                            MC.ItemsEntity = reader.Read<SEL_T001_A>().ToList();
                            MC.TaxEntity = reader.Read<ACC_T006_B>().ToList();
                            MC.ScheduleDetailsEntity = reader.Read<SEL_T002_A>().ToList();
                            MC.ScheduleMasterEntity = reader.Read<SEL_T002>().ToList();
                            MC.PartysContactInfo = reader.Read<ADM_M028_C_P>().ToList();
                            MC.PartysSoldToAddresses = reader.Read<ADM_M028_D>().ToList();
                            MC.PartysShipToAddresses = reader.Read<ADM_M028_D>().ToList();
                            MC.TermsAndCondition = reader.Read<SEL_T001_E>().ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "LoadDocumentWithDocumentNumber")
                        {
                            var MasterData = reader.Read<SEL_T001>().ToList();
                            MC.MasterEntity = MasterData.ToList();
                            if (MC.MasterEntity.Count > 0)
                            {
                                MasterEntity = MC.MasterEntity[0];
                            }
                            var ItemsData = reader.Read<SEL_T001_A>().ToList();
                            MC.ItemsEntity = ItemsData.ToList();
                            var TaxData = reader.Read<ACC_T006_B>().ToList();
                            MC.TaxEntity = TaxData.ToList();
                            var Schedule_B_Data = reader.Read<SEL_T002_A>().ToList();
                            MC.ScheduleDetailsEntity = Schedule_B_Data.ToList();
                            var Schedule_A_Data = reader.Read<SEL_T002>().ToList();
                            MC.ScheduleMasterEntity = Schedule_A_Data.ToList();
                            var Attachment = reader.Read<COM_T003>().ToList();
                            MC.Attachment = Attachment.ToList();
                            var TermsAndCondition = reader.Read<SEL_T001_E>().ToList();
                            MC.TermsAndCondition = TermsAndCondition.ToList();

                            var partycontactinfo = reader.Read<ADM_M028_C_P>().ToList();
                            MC.PartysContactInfo = partycontactinfo.ToList();

                            var partysoldtoadd = reader.Read<ADM_M028_D>().ToList();
                            MC.PartysSoldToAddresses = partysoldtoadd.ToList();

                            var partyshiptoaddress = reader.Read<ADM_M028_D>().ToList();
                            MC.PartysShipToAddresses = partyshiptoaddress.ToList();

                            var Licence_Data = reader.Read<ACC_T006_D>().ToList();
                            MC.LicenceEntity = Licence_Data.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }

                        else if (RequestOption == "SO_Report")
                        {
                            var MasterData = reader.Read<SEL_T001>().ToList();
                            MC.MasterEntity = MasterData.ToList();
                            MasterEntity = MC.MasterEntity[0];
                            var ItemsData = reader.Read<SEL_T001_A>().ToList();
                            MC.ItemsEntity = ItemsData.ToList();
                            var TaxData = reader.Read<ACC_T006_B>().ToList();
                            MC.TaxEntity = TaxData.ToList();
                            var ScheduleEntity = reader.Read<SEL_T002_A>().ToList();
                            MC.ScheduleDetailsEntity = ScheduleEntity.ToList();
                            MC.TermsAndCondition = reader.Read<SEL_T001_E>().ToList();

                            MC.Attachment = reader.Read<COM_T003>().ToList();// item image
                            if (MC.Attachment != null)
                            {
                                if (MC.Attachment.Count > 0)
                                {
                                    foreach (var item in MC.Attachment)
                                    {
                                        item.file_data = ServiceObject.ConvertImageToByteArray(item);
                                    }
                                }
                            }

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
        public byte[] GetData(string Request, string RequestOption)
        {
            MultipleContext_SEL_T001 MC = new MultipleContext_SEL_T001();

            string QueryOption = Request.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T001LoadAll", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    if (QueryOption == "LoadInitialData")
                    {
                        #region MyRegion

                        var DocTypes = reader.Read<SYS_M002>().ToList();
                        MC.DocumentTypes = DocTypes.ToList();
                        var DocDataFlipGrid = reader.Read<SEL_T001_Flip>().ToList();
                        MC.DocumentDataFlipGrid = DocDataFlipGrid.ToList();
                        var partyMaster = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyMaster = partyMaster.ToList();
                        var transporter = reader.Read<ADM_M028_P>().ToList();
                        MC.Transporters = transporter.ToList();
                        var serviceProvider = reader.Read<ADM_M028_P>().ToList();
                        MC.ServiceProviders = serviceProvider.ToList();
                        var uom = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UOM = uom.ToList();
                        var sellers = reader.Read<ADM_M024_P>().ToList();
                        MC.Sellers = sellers.ToList();
                        var journals = reader.Read<ACC_M005_P>().ToList();
                        MC.Journals = journals.ToList();
                        var taxlist = reader.Read<ACC_M013_P>().ToList();
                        MC.TaxList = taxlist.ToList();
                        var glCode = reader.Read<ACC_M003_P>().ToList();
                        MC.GLCodes = glCode.ToList();
                        var payTerms = reader.Read<ACC_M007_P>().ToList();
                        MC.PayTerms = payTerms.ToList();
                        var currency = reader.Read<ADM_M037_P>().ToList();
                        MC.Currencys = currency.ToList();
                        var salesOrg = reader.Read<ADM_M001_A_P>().ToList();
                        MC.SalesOrg = salesOrg.ToList();
                        var salesGroup = reader.Read<ADM_M001_H_P>().ToList();
                        MC.SalesGroup = salesGroup.ToList();
                        var salesdiv = reader.Read<ADM_M001_D_P>().ToList();
                        MC.SalesDiv = salesdiv.ToList();
                        var itemlinecat = reader.Read<SYS_M003_P>().ToList();
                        MC.ItemLineCategory = itemlinecat.ToList();
                        var costCenter = reader.Read<ACC_M019_P>().ToList();
                        MC.Cost_Centers = costCenter.ToList();
                        var bank = reader.Read<ACC_M004_P>().ToList();
                        MC.Banks = bank.ToList();
                        var ballTypes = reader.Read<ZADM_M002_P>().ToList();
                        MC.BallTypes = ballTypes.ToList();
                        var ilds = reader.Read<ZADM_M007_P>().ToList();
                        MC.ILDs = ilds.ToList();
                        var wireTypes = reader.Read<ZADM_M004_P>().ToList();
                        MC.WireTypes = wireTypes.ToList();
                        var ballDias = reader.Read<ZADM_M001_P>().ToList();
                        MC.BallDias = ballDias.ToList();
                        var inks = reader.Read<ZADM_M006_P>().ToList();
                        MC.Inks = inks.ToList();
                        var incoterms = reader.Read<ADM_M044_P>().ToList();
                        MC.Incoterms = incoterms.ToList();
                        var LicAdvance = reader.Read<ADM_M041_P>().ToList();
                        MC.LicenseAdvance = LicAdvance.ToList();
                        var LicEPCG = reader.Read<ADM_M041_P>().ToList();
                        MC.LicenseEPCG = LicEPCG.ToList();
                        var SOReferance = reader.Read<SEL_T001_P_RefDoc>().ToList();
                        MC.Sales_Order_Reference = SOReferance.ToList();
                        var countryMaster = reader.Read<ADM_M012_P>().ToList();
                        MC.CountryMaster = countryMaster.ToList();
                        var stateMaster = reader.Read<ADM_M013_P>().ToList();
                        MC.StateMaster = stateMaster.ToList();
                        var itemlistpopup = reader.Read<SEL_T001_P_SO_ItemsList>().ToList();
                        MC.ItemListPopup = itemlistpopup.ToList();
                        var NotificationData = reader.Read<NotificationData>().ToList();
                        MC.NotificationData = NotificationData.ToList();
                        var Grade = reader.Read<ADM_M045_P>().ToList();
                        MC.GradeCollection = Grade.ToList();
                        var termsCondition = reader.Read<CRM_M001_P>().ToList();
                        MC.TermsConditionCollection = termsCondition.ToList();
                        #endregion
                    }
                    else if (QueryOption == "LoadSoldToPartyDetails")
                    {
                        #region MyRegion

                        var partycontactinfo = reader.Read<ADM_M028_C_P>().ToList();
                        MC.PartysContactInfo = partycontactinfo.ToList();
                        var partysoldtoadd = reader.Read<ADM_M028_D>().ToList();
                        MC.PartysSoldToAddresses = partysoldtoadd.ToList();
                        var itemlistpopup = reader.Read<SEL_T001_P_SO_ItemsList>().ToList();
                        MC.ItemListPopup = itemlistpopup.ToList();
                        var TermsAndCondition = reader.Read<SEL_T001_E>().ToList();
                        MC.TermsAndCondition = TermsAndCondition.ToList();

                        #endregion
                    }
                    else if (QueryOption == "LoadShipToPartyDetails")
                    {
                        var partyshiptoaddress = reader.Read<ADM_M028_D>().ToList();
                        MC.PartysShipToAddresses = partyshiptoaddress.ToList();
                    }
                    else if (QueryOption == "LoadDocumentWithReferenceDocumentNumber")
                    {
                        #region MyRegion

                        var MasterData = reader.Read<SEL_T001>().ToList();
                        MC.MasterEntity = MasterData.ToList();
                        MasterEntity = MC.MasterEntity[0];
                        var ItemsData = reader.Read<SEL_T001_A>().ToList();
                        MC.ItemsEntity = ItemsData.ToList();
                        var TaxData = reader.Read<ACC_T006_B>().ToList();
                        MC.TaxEntity = TaxData.ToList();
                        var Schedule_B_Data = reader.Read<SEL_T002_A>().ToList();
                        MC.ScheduleDetailsEntity = Schedule_B_Data.ToList();
                        var Schedule_A_Data = reader.Read<SEL_T002>().ToList();
                        MC.ScheduleMasterEntity = Schedule_A_Data.ToList();
                        //var Attachment = reader.Read<COM_T003>().ToList();
                        //MC.Attachment = Attachment.ToList();
                        var TermsAndCondition = reader.Read<SEL_T001_E>().ToList();
                        MC.TermsAndCondition = TermsAndCondition.ToList();
                        #endregion
                    }
                    else if (QueryOption == "LoadDocumentWithDocumentNumber")
                    {
                        #region MyRegion

                        var MasterData = reader.Read<SEL_T001>().ToList();
                        MC.MasterEntity = MasterData.ToList();
                        MasterEntity = MC.MasterEntity[0];
                        var ItemsData = reader.Read<SEL_T001_A>().ToList();
                        MC.ItemsEntity = ItemsData.ToList();
                        var TaxData = reader.Read<ACC_T006_B>().ToList();
                        MC.TaxEntity = TaxData.ToList();
                        var Schedule_B_Data = reader.Read<SEL_T002_A>().ToList();
                        MC.ScheduleDetailsEntity = Schedule_B_Data.ToList();
                        var Schedule_A_Data = reader.Read<SEL_T002>().ToList();
                        MC.ScheduleMasterEntity = Schedule_A_Data.ToList();
                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();
                        var TermsAndCondition = reader.Read<SEL_T001_E>().ToList();
                        MC.TermsAndCondition = TermsAndCondition.ToList();

                        var partycontactinfo = reader.Read<ADM_M028_C_P>().ToList();
                        MC.PartysContactInfo = partycontactinfo.ToList();

                        var partysoldtoadd = reader.Read<ADM_M028_D>().ToList();
                        MC.PartysSoldToAddresses = partysoldtoadd.ToList();

                        var partyshiptoaddress = reader.Read<ADM_M028_D>().ToList();
                        MC.PartysShipToAddresses = partyshiptoaddress.ToList();


                        #endregion
                    }
                }
                return ObjectSerializationService<MultipleContext_SEL_T001>.ObjectToStream(MC);
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
        public byte[] Insert(byte[] RequestStream, string Request, string RequestOption)
        {
            MultipleContext_SEL_T001 MC = new MultipleContext_SEL_T001();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T001Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<SEL_T001_Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<SEL_T001>().ToList();
                    List<SEL_T001> Masterlist = MasterData.ToList();
                    MasterEntity = Masterlist[0];
                    var ItemsData = reader.Read<SEL_T001_A>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();
                    var TaxData = reader.Read<ACC_T006_B>().ToList();
                    MC.TaxEntity = TaxData.ToList();
                    var Schedule_B_Data = reader.Read<SEL_T002_A>().ToList();
                    MC.ScheduleDetailsEntity = Schedule_B_Data.ToList();
                    var Schedule_A_Data = reader.Read<SEL_T002>().ToList();
                    MC.ScheduleMasterEntity = Schedule_A_Data.ToList();
                    var TermsAndConditionEntity = reader.Read<SEL_T001_E>().ToList();
                    MC.TermsAndCondition = TermsAndConditionEntity.ToList();

                    MasterEntity.XmlDataDocument_SEL_T001_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_B = ObjectSerializationService.ObjectToXML(MC.TaxEntity);
                    MasterEntity.XmlDataDocument_SEL_T002 = ObjectSerializationService.ObjectToXML(MC.ScheduleMasterEntity);
                    MasterEntity.XmlDataDocument_SEL_T002_A = ObjectSerializationService.ObjectToXML(MC.ScheduleDetailsEntity);
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_SEL_T001_E = ObjectSerializationService.ObjectToXML(MC.TermsAndCondition);

                }
                return ObjectSerializationService<SEL_T001>.ObjectToStream(MasterEntity);
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
        public byte[] Update(byte[] RequestStream, string Request, string RequestOption)
        {
            MultipleContext_SEL_T001 MC = new MultipleContext_SEL_T001();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T001Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<SEL_T001_Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<SEL_T001>().ToList();
                    List<SEL_T001> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    var ItemsData = reader.Read<SEL_T001_A>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();
                    var TaxData = reader.Read<ACC_T006_B>().ToList();
                    MC.TaxEntity = TaxData.ToList();
                    var Schedule_B_Data = reader.Read<SEL_T002_A>().ToList();
                    MC.ScheduleDetailsEntity = Schedule_B_Data.ToList();
                    var Schedule_A_Data = reader.Read<SEL_T002>().ToList();
                    MC.ScheduleMasterEntity = Schedule_A_Data.ToList();
                    var TermsAndConditionEntity = reader.Read<SEL_T001_E>().ToList();
                    MC.TermsAndCondition = TermsAndConditionEntity.ToList();

                    MasterEntity.XmlDataDocument_SEL_T001_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_B = ObjectSerializationService.ObjectToXML(MC.TaxEntity);
                    MasterEntity.XmlDataDocument_SEL_T002 = ObjectSerializationService.ObjectToXML(MC.ScheduleMasterEntity);
                    MasterEntity.XmlDataDocument_SEL_T002_A = ObjectSerializationService.ObjectToXML(MC.ScheduleDetailsEntity);
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_SEL_T001_E = ObjectSerializationService.ObjectToXML(MC.TermsAndCondition);
                }
                return ObjectSerializationService<SEL_T001>.ObjectToStream(MasterEntity);
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
    public class MultipleContext_SEL_T001
    {
        public List<ADM_M0013> STATUS_LIST { get; set; }
        public List<STD_DOC_TYPE> DOC_TYPE_LIST { get; set; }
        public List<ACC_M003_P> AccountList { get; set; }
        public List<ADM_M012_P> CountryMaster { get; set; }
        public List<ADM_M013_P> StateMaster { get; set; }
        public List<SYS_M002> DocumentTypes { get; set; }
        public List<SEL_T001_Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<ADM_M028_P> Transporters { get; set; }
        public List<ADM_M028_P> ServiceProviders { get; set; }
        public List<ADM_M028_P> Supplier { get; set; }
        public List<ADM_M038_B_P> UOM { get; set; }
        public List<ADM_M024_P> Sellers { get; set; }
        public List<ACC_M005_P> Journals { get; set; }
        public List<ACC_M013_P> TaxList { get; set; }
        public List<ACC_M003_P> GLCodes { get; set; }
        public List<ACC_M007_P> PayTerms { get; set; }
        public List<ADM_M037_P> Currencys { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public List<ADM_M001_D_P> SalesDiv { get; set; }
        public List<SYS_M003_P> ItemLineCategory { get; set; }
        public List<ACC_M019_P> Cost_Centers { get; set; }
        public List<ACC_M004_P> Banks { get; set; }
        public List<ZADM_M002_P> BallTypes { get; set; }
        public List<ZADM_M007_P> ILDs { get; set; }
        public List<ZADM_M004_P> WireTypes { get; set; }
        public List<ZADM_M001_P> BallDias { get; set; }
        public List<ZADM_M006_P> Inks { get; set; }
        public List<SEL_T001> MasterEntity { get; set; }//Sales_Order
        public List<SEL_T001_A> ItemsEntity { get; set; }//Sales_Order_Items Details 
        public List<ACC_T006_B> TaxEntity { get; set; }//Tax_Details
        public List<SEL_T002> ScheduleMasterEntity { get; set; }
        public List<SEL_T002_A> ScheduleDetailsEntity { get; set; }
        public List<ADM_M028_C_P> PartysContactInfo { get; set; }
        public List<ADM_M028_D> PartysSoldToAddresses { get; set; }
        public List<ADM_M028_D> PartysShipToAddresses { get; set; }
        public List<SEL_T001_P_RefDoc> Sales_Order_Reference { get; set; }
        public List<SEL_T001_P_SO_ItemsList> ItemListPopup { get; set; }
        public List<CRM_M001_P> TermsConditionCollection { get; set; }
        public List<ADM_M044_P> Incoterms { get; set; }
        public List<ADM_M041_P> LicenseAdvance { get; set; }
        public List<ADM_M041_P> LicenseEPCG { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<SEL_T001_E> TermsAndCondition { get; set; }
        public List<ADM_M045_P> GradeCollection { get; set; }
        public List<ADM_M028_C_P> RefPartyContactInfo { get; set; }
        public List<ADM_M031_P> ParameterDetails { get; set; }
        public List<ADM_M030_P> ParameterValueDetails { get; set; }
        public List<ADM_M038_C> UnitConversion { get; set; }
        public List<ZADM_M009_P> ModelNo { get; set; }
        public List<ZADM_M010> FinishGoodMaster { get; set; }
        public List<ADM_M030_P> ParamValueList { get; set; }
        public List<ADM_M031_P> ParameterList { get; set; }
        public List<ZADM_M017_P> PackingList { get; set; }
        public List<SEL_T001_A> SalesData { get; set; }
        public List<ACC_M003_O_P> ConditionTypeList { get; set; }
        public List<GetItemDetailsEntity> UnitPriceList { get; set; }
        public List<GetItemDetailsEntity> QFRList { get; set; }
        public List<GetItemDetailsEntity> DispatchList { get; set; }
        public List<GetItemDetailsEntity> ProjectedDispList { get; set; }
        public List<ADM_M041_P> LicenceList { get; set; }
        public List<ACC_T006_D> LicenceEntity { get; set; }
        public List<ADM_M003_C_P> BussinessPlaceList { get; set; }
        public List<ADM_M032_P> Make { get; set; }
        public List<SYS_M026> TransportMode { get; set; }
        public List<SYS_M037> Trade_Types { get; set; }
        public List<ACC_M004_P> hbList { get; set; }
        public List<ADM_M002_B> ScopeList { get; set; }


    }
    
}
