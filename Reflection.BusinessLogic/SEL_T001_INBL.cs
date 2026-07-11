using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.CRM;
using Dapper;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.Admin;
using Reflection.EF.Communication;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    public class SEL_T001_INBL : ReflectionBusinessLogic
    {

        private static string connectionString;
        SEL_T001 MasterEntity = new SEL_T001();
        MultipleContext_SEL_T001 MC = new MultipleContext_SEL_T001();

        public SEL_T001_INBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public SEL_T001_INBL()
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

                    var reader = conn.QueryMultiple("SEL_T001Insert", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

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

                    MasterEntity.XmlDataDocument_SEL_T001_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_SEL_T002_A = ObjectSerializationService.ObjectToXML(MC.ScheduleDetailsEntity);

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

                    var reader = conn.QueryMultiple("SEL_T001Update", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

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

                    MasterEntity.XmlDataDocument_SEL_T001_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_SEL_T002_A = ObjectSerializationService.ObjectToXML(MC.ScheduleDetailsEntity);

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
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T001LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

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

                        var UnitConversion = reader.Read<ADM_M038_C>().ToList();
                        MC.UnitConversion = UnitConversion.ToList();

                        

                        var t_statusData = reader.Read<ADM_M0013>().ToList();
                        MC.STATUS_LIST = t_statusData.ToList();

                        MC.Trade_Types = reader.Read<SYS_M037>().ToList();
                        var bank = reader.Read<ACC_M004_P>().ToList();
                        MC.Banks = bank.ToList();

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
                    else if (RequestOption == "LoadDocumentWithDocumentNumber")
                    {
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

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;
                    }
                    
                    else if (RequestOption == "LoadSODetails")
                    {

                    }

                    else if (RequestOption == "LoadBackFlipData")
                    {
                        var documentDataFlipGrid = reader.Read<SEL_T001_Flip>().ToList();
                        MC.DocumentDataFlipGrid = documentDataFlipGrid.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
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

}
