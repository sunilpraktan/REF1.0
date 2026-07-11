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

namespace Reflection.BusinessLogic
{
    public class CRM_T003BL:ReflectionBusinessLogic
    {
        private static string connectionString;

        CRM_T003 MasterEntity = new CRM_T003();
        MultipleContext_CRM_T003 MC = new MultipleContext_CRM_T003();

        public CRM_T003BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public CRM_T003BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            MultipleContext_CRM_T003 MC = new MultipleContext_CRM_T003();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("CRM_T003Insert", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<CRM_T003_Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<CRM_T003>().ToList();
                    List<CRM_T003> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    var ItemsData = reader.Read<CRM_T003_A>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();

                    var LeadDistbnData = reader.Read<CRM_T003_B>().ToList();
                    MC.LeadDistbnEntity = LeadDistbnData.ToList();

                    var LeadPartyData = reader.Read<CRM_T003_C>().ToList();
                    MC.LeadPartyEntity = LeadPartyData.ToList();

                    var LeadContactData = reader.Read<CRM_T003_D>().ToList();
                    MC.LeadContactEntity = LeadContactData.ToList();

                    MasterEntity.XmlDataDocument_CRM_T003_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_CRM_T003_B = ObjectSerializationService.ObjectToXML(MC.LeadDistbnEntity);
                    MasterEntity.XmlDataDocument_CRM_T003_C= ObjectSerializationService.ObjectToXML(MC.LeadPartyEntity);
                    MasterEntity.XmlDataDocument_CRM_T003_D = ObjectSerializationService.ObjectToXML(MC.LeadContactEntity);
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
            MultipleContext_CRM_T003 MC = new MultipleContext_CRM_T003();

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("CRM_T003Update", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<CRM_T003_Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<CRM_T003>().ToList();
                    List<CRM_T003> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    var ItemsData = reader.Read<CRM_T003_A>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();

                    var LeadDistbnData = reader.Read<CRM_T003_B>().ToList();
                    MC.LeadDistbnEntity = LeadDistbnData.ToList();

                    var LeadPartyData = reader.Read<CRM_T003_C>().ToList();
                    MC.LeadPartyEntity = LeadPartyData.ToList();

                    var LeadContactData = reader.Read<CRM_T003_D>().ToList();
                    MC.LeadContactEntity = LeadContactData.ToList();

                    MasterEntity.XmlDataDocument_CRM_T003_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_CRM_T003_B = ObjectSerializationService.ObjectToXML(MC.LeadDistbnEntity);
                    MasterEntity.XmlDataDocument_CRM_T003_C = ObjectSerializationService.ObjectToXML(MC.LeadPartyEntity);
                    MasterEntity.XmlDataDocument_CRM_T003_D = ObjectSerializationService.ObjectToXML(MC.LeadContactEntity);
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
        public string Delete(int Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("CRM_T003Delete", new { @id = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_CRM_T003 MC = new MultipleContext_CRM_T003();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                if (strValue == "GetItemPriceData")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("GetSalesData", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

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
                        var reader = conn.QueryMultiple("CRM_T003LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var DocTypes = reader.Read<SYS_M002>().ToList();
                            MC.DocumentTypes = DocTypes.ToList();
                            var Referance = reader.Read<CRM_M003_P_RefDoc>().ToList();
                            MC.ReferenceList = Referance.ToList();
                            var FlipGridData = reader.Read<CRM_T003_Flip>().ToList();
                            MC.DocumentDataFlipGrid = FlipGridData.ToList();
                            var PartyMasterData = reader.Read<ADM_M053_P>().ToList();
                            MC.PartyMaster = PartyMasterData.ToList();
                            var BuyerData = reader.Read<ADM_M054_P>().ToList();
                            MC.BuyerList = BuyerData.ToList();
                            var PriorityData = reader.Read<ADM_M040_P>().ToList();
                            MC.PriorityList = PriorityData.ToList();
                            var CurrencyData = reader.Read<ADM_M037_P>().ToList();
                            MC.Currencys = CurrencyData.ToList();
                            var StatusValueData = reader.Read<CRM_M002_P>().ToList();
                            MC.StatusValueList = StatusValueData.ToList();
                            var OriginData = reader.Read<CRM_M005_P>().ToList();
                            MC.OriginList = OriginData.ToList();
                            var IndTypeData = reader.Read<SYS_P004_P>().ToList();
                            MC.IndustryTyList = IndTypeData.ToList();
                            var PrefContactData = reader.Read<ADM_M057_A_P>().ToList();
                            MC.PrefContactList = PrefContactData.ToList();

                            var ItemlistData = reader.Read<CRM_T003_ItemsList>().ToList();
                            MC.ItemListPopup = ItemlistData.ToList();
                            var UOMData = reader.Read<ADM_M038_B_P>().ToList();
                            MC.UOM = UOMData.ToList();
                            var EmployeeData = reader.Read<ADM_M024_P>().ToList();
                            MC.EmployeeList = EmployeeData.ToList();
                            var DistbnChannel = reader.Read<ADM_M001_C_P>().ToList();
                            MC.DistributionChannel = DistbnChannel.ToList();
                            var CostCenterData = reader.Read<ACC_M019_P>().ToList();
                            MC.Cost_Centers = CostCenterData.ToList();
                            var RoleData = reader.Read<CRM_M009_P>().ToList();
                            MC.RoleList = RoleData.ToList();

                            var NotificationData = reader.Read<NotificationData>().ToList();
                            MC.NotificationData = NotificationData.ToList();
                           

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }                      
                        else if (RequestOption == "LoadBackFlipData")
                        {
                            var DocDataFlipGrid = reader.Read<CRM_T003_Flip>().ToList();
                            MC.DocumentDataFlipGrid = DocDataFlipGrid.ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }                                      
                        else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                        {
                            var MasterData = reader.Read<CRM_T003>().ToList();
                            MC.MasterEntity = MasterData.ToList();
                            if (MC.MasterEntity.Count > 0)
                            {
                                MasterEntity = MC.MasterEntity[0];
                            }
                            var ItemsData = reader.Read<CRM_T003_A>().ToList();
                            MC.ItemsEntity = ItemsData.ToList();

                            var LeadDistbnData = reader.Read<CRM_T003_B>().ToList();
                            MC.LeadDistbnEntity = LeadDistbnData.ToList();

                            var LeadPartyData = reader.Read<CRM_T003_C>().ToList();
                            MC.LeadPartyEntity = LeadPartyData.ToList();

                            var LeadContactData = reader.Read<CRM_T003_D>().ToList();
                            MC.LeadContactEntity = LeadContactData.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "LoadDocumentWithDocumentNumber")
                        {
                            var MasterData = reader.Read<CRM_T003>().ToList();
                            MC.MasterEntity = MasterData.ToList();
                            if (MC.MasterEntity.Count > 0)
                            {
                                MasterEntity = MC.MasterEntity[0];
                            }
                            var ItemsData = reader.Read<CRM_T003_A>().ToList();
                            MC.ItemsEntity = ItemsData.ToList();

                            var LeadDistbnData = reader.Read<CRM_T003_B>().ToList();
                            MC.LeadDistbnEntity = LeadDistbnData.ToList();

                            var LeadPartyData = reader.Read<CRM_T003_C>().ToList();
                            MC.LeadPartyEntity = LeadPartyData.ToList();

                            var LeadContactData = reader.Read<CRM_T003_D>().ToList();
                            MC.LeadContactEntity = LeadContactData.ToList();

                            var Attachment = reader.Read<COM_T003>().ToList();
                            MC.Attachment = Attachment.ToList();


                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            return strReturnData;
                        }
                        else if (RequestOption == "Lead_Report")
                        {
                            var MasterData = reader.Read<CRM_T003>().ToList();
                            MC.MasterEntity = MasterData.ToList();
                            MasterEntity = MC.MasterEntity[0];

                            var ItemsData = reader.Read<CRM_T003_A>().ToList();
                            MC.ItemsEntity = ItemsData.ToList();
                           
                            var LeadDistbnData = reader.Read<CRM_T003_B>().ToList();
                            MC.LeadDistbnEntity = LeadDistbnData.ToList();

                            var LeadPartyData = reader.Read<CRM_T003_C>().ToList();
                            MC.LeadPartyEntity = LeadPartyData.ToList();

                            var LeadContactData = reader.Read<CRM_T003_D>().ToList();
                            MC.LeadContactEntity = LeadContactData.ToList();

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

    public class MultipleContext_CRM_T003
    {
        public List<SYS_M002> DocumentTypes { get; set; }
        public List<CRM_M003_P_RefDoc> ReferenceList { get; set; }
        public List<CRM_T003_Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M053_P> PartyMaster { get; set; }
        public List<ADM_M054_P> BuyerList{ get; set; }
        public List<ADM_M040_P> PriorityList { get; set; }
        public List<ADM_M037_P> Currencys { get; set; }
        public List<CRM_M002_P> StatusValueList { get; set; }
        public List<CRM_M005_P> OriginList { get; set; }
        public List<SYS_P004_P> IndustryTyList { get; set; }
        public List<ADM_M057_A_P> PrefContactList { get; set; }
        public List<CRM_T003_ItemsList> ItemListPopup { get; set; }        
        public List<ADM_M038_B_P> UOM { get; set; }
        public List<ADM_M024_P> EmployeeList { get; set; }    
        public List<CRM_M009_P> RoleList { get; set; }
        public List<ADM_M001_C_P> DistributionChannel { get; set; }
        public List<ACC_M019_P> Cost_Centers { get; set; } 
        
        public List<CRM_T003> MasterEntity { get; set; }
        public List<CRM_T003_A> ItemsEntity { get; set; }           
        public List<CRM_T003_B> LeadDistbnEntity { get; set; }
        public List<CRM_T003_C> LeadPartyEntity { get; set; }
        public List<CRM_T003_D> LeadContactEntity { get; set; }
        public List<ADM_M053> PartyEntityList { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }         
        public List<GetItemDetailsEntity> UnitPriceList { get; set; }
        public List<GetItemDetailsEntity> QFRList { get; set; }
        public List<GetItemDetailsEntity> DispatchList { get; set; }
        public List<GetItemDetailsEntity> ProjectedDispList { get; set; }
    }
}
