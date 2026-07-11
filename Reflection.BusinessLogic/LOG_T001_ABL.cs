using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Xml.Serialization;
using Reflection.EF.SCM;
using Reflection.EF.SCM.ReportEntitySCM;
using Dapper;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.CRM.ReportEntityCRM;
using Reflection.EF.Production;
using Reflection.EF.Communication;
using Reflection.EF.Admin;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{//11/8
    public class LOG_T001_ABL : ReflectionBusinessLogic
    {

        private static string connectionString;

        LOG_T001_A log_T001_A = new LOG_T001_A();
        public LOG_T001_ABL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public LOG_T001_ABL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MultipleContext_LOG_T001_A MC = new MultipleContext_LOG_T001_A();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("LOG_T001_A_STD_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure,commandTimeout:0);

                    var DelNoteTemp = reader.Read<LOG_T001_A>().ToList();
                    MC.Delivery_Note = DelNoteTemp.ToList();

                    var DelNoteDetail = reader.Read<LOG_T001_B>().ToList();
                    MC.DelNoteItemDetails = DelNoteDetail.ToList();

                    var BatchDetailsTemp = reader.Read<LOG_T001_C>().ToList();
                    MC.ItemBatchDetails = BatchDetailsTemp.ToList();

                    var BackFlipTemp = reader.Read<LOG_T001_A_FLIP>().ToList();
                    MC.FlipGridList = BackFlipTemp.ToList();

                    log_T001_A = MC.Delivery_Note[0];
                    log_T001_A.XmlDataDocument_LOG_T001_B = ObjectSerializationService.ObjectToXML(MC.DelNoteItemDetails);
                    log_T001_A.XmlDataDocument_LOG_T001_C = ObjectSerializationService.ObjectToXML(MC.ItemBatchDetails);
                    log_T001_A.XmlDataDocument_LOG_T001_D = ObjectSerializationService.ObjectToXML(MC.FlipGridList);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(log_T001_A);
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
        public string Insert_Post(string Request)
        {
            try
            {
                int reader;
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    reader = conn.Execute("MM_T001_STD_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure, commandTimeout: 300);
                }
                string strReturnData = reader.ToString(); //ObjectSerializationService.ObjectToXML(reader);              
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
            try
            {
                MultipleContext_LOG_T001_A MC = new MultipleContext_LOG_T001_A();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("LOG_T001_A_STD_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var DelNoteTemp = reader.Read<LOG_T001_A>().ToList();
                    MC.Delivery_Note = DelNoteTemp.ToList();

                    var DelNoteDetail = reader.Read<LOG_T001_B>().ToList();
                    MC.DelNoteItemDetails = DelNoteDetail.ToList();

                    var BatchDetailsTemp = reader.Read<LOG_T001_C>().ToList();
                    MC.ItemBatchDetails = BatchDetailsTemp.ToList();

                    var BackFlipTemp = reader.Read<LOG_T001_A_FLIP>().ToList();
                    MC.FlipGridList = BackFlipTemp.ToList();

                    if (MC.Delivery_Note.Count > 0)
                    {
                        log_T001_A = MC.Delivery_Note[0];
                    }

                    log_T001_A.XmlDataDocument_LOG_T001_B = ObjectSerializationService.ObjectToXML(MC.DelNoteItemDetails);
                    log_T001_A.XmlDataDocument_LOG_T001_C = ObjectSerializationService.ObjectToXML(MC.ItemBatchDetails);
                    log_T001_A.XmlDataDocument_LOG_T001_D = ObjectSerializationService.ObjectToXML(MC.FlipGridList);
                }

                string strReturnData = ObjectSerializationService.ObjectToXML(log_T001_A);
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
                    int intOut = conn.Execute("LOG_T001_ADelete", new { @delivery_no = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_LOG_T001_A MC = new MultipleContext_LOG_T001_A();
            string RequestOption = strValue.Split('!')[0];
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    if (RequestOption == "LoadInitialDataNew")
                    {
                        var reader = conn.QueryMultiple("LOG_T001_A_STD_LoadAll", new { @request = strValue }, commandType: CommandType.StoredProcedure);
                        var PartyTemp = reader.Read<ADM_M028_P>().ToList(); // Temp = temporary variable
                        MC.PartyList = PartyTemp.ToList();

                        var PartyAddressTemp = reader.Read<ADM_M028_D_P>().ToList();
                        MC.PartyAddressList = PartyAddressTemp.ToList();

                        var PartyContactTemp = reader.Read<ADM_M028_C_P>().ToList();
                        MC.PartyContactList = PartyContactTemp.ToList();

                        var OrderTemp = reader.Read<Order_No_P>().ToList();
                        MC.OrderList = OrderTemp.ToList();

                        var DelTypeTemp = reader.Read<SYS_M005_P>().ToList();
                        MC.DeliveryTypeList = DelTypeTemp.ToList();

                        var DocTypeTemp = reader.Read<SYS_M002_P>();
                        MC.DocTypeList = DocTypeTemp.ToList();

                        var PartyTransTemp = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyTranList = PartyTransTemp.ToList();

                        var CurrencyTemp = reader.Read<ADM_M037_P>().ToList();
                        MC.CurrencyList = CurrencyTemp.ToList();

                        var SalesOrgtemp = reader.Read<ADM_M001_A_P>().ToList();
                        MC.SalesOrgList = SalesOrgtemp.ToList();

                        var DistributionChannelTemp = reader.Read<ADM_M001_C_P>().ToList();
                        MC.DistributionChannelList = DistributionChannelTemp.ToList();

                        var SalesDivTemp = reader.Read<ADM_M001_D_P>().ToList();
                        MC.SalesDivisionList = SalesDivTemp.ToList();

                        var SalesOffTemp = reader.Read<ADM_M001_I_P>().ToList();
                        MC.SalesOfficeList = SalesOffTemp.ToList();

                        var SalesGrpTemp = reader.Read<ADM_M001_H_P>().ToList();
                        MC.SalesGroupList = SalesGrpTemp.ToList();

                        var StoreLocTemp = reader.Read<MM_M001_P>().ToList();
                        MC.StoreLocList = StoreLocTemp.ToList();

                        var ItemCatTemp = reader.Read<SYS_M003_P>().ToList();
                        MC.ItemCategoryList = ItemCatTemp.ToList();

                        var UomTemp = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UomList = UomTemp.ToList();

                        var CountryTemp = reader.Read<ADM_M012_P>().ToList();
                        MC.CountryList = CountryTemp.ToList();

                        var licListTemp = reader.Read<ADM_M037_P>().ToList();
                        MC.licList = licListTemp.ToList();

                        var ItemTemp = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList = ItemTemp.ToList();

                        var Settings = reader.Read<EPR_T003_S>().ToList();
                        MC.SettingsList = Settings.ToList();

                        var ParameterTemp = reader.Read<ADM_M031_P>().ToList();
                        MC.ParameterList = ParameterTemp.ToList();

                        var ParamValueTemp = reader.Read<ADM_M030_P>().ToList();
                        MC.ParamValueList = ParamValueTemp.ToList();

                        var BatchTemp = reader.Read<MM_S003_P>().ToList();
                        MC.BatchesList = BatchTemp.ToList();

                        var DelNoteTemp = reader.Read<LOG_T001_A_FLIP>().ToList();
                        MC.FlipGridList = DelNoteTemp.ToList();

                        var SellerList = reader.Read<ADM_M024_P>().ToList();
                        MC.SellerList = SellerList.ToList();

                        var DocCatList = reader.Read<SYS_M002>().ToList();
                        MC.DocCategoryList = DocCatList.ToList();

                        var Incoterms = reader.Read<ADM_M044_P>().ToList();
                        MC.IncoTermsList = Incoterms.ToList();

                        var Confactor = reader.Read<ADM_M038_C_P>().ToList();
                        MC.ConFactorList = Confactor.ToList();

                        var reservetemp = reader.Read<MM_T001_P>().ToList();
                        MC.ReserveDateList = reservetemp.ToList();

                        var Report_DataDetails2 = reader.Read<Report_Data_P>().ToList();
                        MC.Report_DataList2 = Report_DataDetails2.ToList();

                        var t_statusData = reader.Read<ADM_M0013>().ToList();
                        MC.t_statusList = t_statusData.ToList();
                        MC.STD_PLANT_PARTY_LIST = reader.Read<STD_PARTY>().ToList();
                    }
                    else
                    {
                        var reader = conn.QueryMultiple("LOG_T001_ALoadAll", new { @request = strValue }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var PartyTemp = reader.Read<ADM_M028_P>().ToList(); // Temp = temporary variable
                            MC.PartyList = PartyTemp.ToList();

                            var PartyAddressTemp = reader.Read<ADM_M028_D_P>().ToList();
                            MC.PartyAddressList = PartyAddressTemp.ToList();

                            var PartyContactTemp = reader.Read<ADM_M028_C_P>().ToList();
                            MC.PartyContactList = PartyContactTemp.ToList();

                            var OrderTemp = reader.Read<Order_No_P>().ToList();
                            MC.OrderList = OrderTemp.ToList();

                            var DelTypeTemp = reader.Read<SYS_M005_P>().ToList();
                            MC.DeliveryTypeList = DelTypeTemp.ToList();

                            var DocTypeTemp = reader.Read<SYS_M002_P>();
                            MC.DocTypeList = DocTypeTemp.ToList();
                            MC.TransportMode = reader.Read<SYS_M026>().ToList();
                            var PartyTransTemp = reader.Read<ADM_M028_P>().ToList();
                            MC.PartyTranList = PartyTransTemp.ToList();

                            var CurrencyTemp = reader.Read<ADM_M037_P>().ToList();
                            MC.CurrencyList = CurrencyTemp.ToList();

                            var SalesOrgtemp = reader.Read<ADM_M001_A_P>().ToList();
                            MC.SalesOrgList = SalesOrgtemp.ToList();

                            var DistributionChannelTemp = reader.Read<ADM_M001_C_P>().ToList();
                            MC.DistributionChannelList = DistributionChannelTemp.ToList();

                            var SalesDivTemp = reader.Read<ADM_M001_D_P>().ToList();
                            MC.SalesDivisionList = SalesDivTemp.ToList();

                            var SalesOffTemp = reader.Read<ADM_M001_I_P>().ToList();
                            MC.SalesOfficeList = SalesOffTemp.ToList();

                            var SalesGrpTemp = reader.Read<ADM_M001_H_P>().ToList();
                            MC.SalesGroupList = SalesGrpTemp.ToList();

                            var StoreLocTemp = reader.Read<MM_M001_P>().ToList();
                            MC.StoreLocList = StoreLocTemp.ToList();

                            var ItemCatTemp = reader.Read<SYS_M003_P>().ToList();
                            MC.ItemCategoryList = ItemCatTemp.ToList();

                            var UomTemp = reader.Read<ADM_M038_B_P>().ToList();
                            MC.UomList = UomTemp.ToList();

                            var CountryTemp = reader.Read<ADM_M012_P>().ToList();
                            MC.CountryList = CountryTemp.ToList();

                            var licListTemp = reader.Read<ADM_M037_P>().ToList();
                            MC.licList = licListTemp.ToList();

                            var ItemTemp = reader.Read<ADM_M022_P>().ToList();
                            MC.ItemList = ItemTemp.ToList();

                            var Settings = reader.Read<EPR_T003_S>().ToList();
                            MC.SettingsList = Settings.ToList();

                            var ParameterTemp = reader.Read<ADM_M031_P>().ToList();
                            MC.ParameterList = ParameterTemp.ToList();

                            var ParamValueTemp = reader.Read<ADM_M030_P>().ToList();
                            MC.ParamValueList = ParamValueTemp.ToList();

                            var CartonsTemp = reader.Read<EPR_T003_A_P>().ToList();
                            MC.CartonsList = CartonsTemp.ToList();

                            var DelNoteTemp = reader.Read<LOG_T001_A_FLIP>().ToList();
                            MC.FlipGridList = DelNoteTemp.ToList();

                            var SellerList = reader.Read<ADM_M024_P>().ToList();
                            MC.SellerList = SellerList.ToList();

                            var DocCatList = reader.Read<SYS_M002>().ToList();
                            MC.DocCategoryList = DocCatList.ToList();

                            var Incoterms = reader.Read<ADM_M044_P>().ToList();
                            MC.IncoTermsList = Incoterms.ToList();

                            var Confactor = reader.Read<ADM_M038_C_P>().ToList();
                            MC.ConFactorList = Confactor.ToList();

                            //var reservetemp = reader.Read<MM_T001_P>().ToList();
                            //MC.ReserveDateList = reservetemp.ToList();

                            var Report_DataDetails2 = reader.Read<Report_Data_P>().ToList();
                            MC.Report_DataList2 = Report_DataDetails2.ToList();

                            var t_statusData = reader.Read<ADM_M0013>().ToList();
                            MC.t_statusList = t_statusData.ToList();

                        }
                        else if (RequestOption == "RefreshBatchCollection")
                        {
                            var CartonsTemp = reader.Read<EPR_T003_A_P>().ToList();
                            MC.CartonsList = CartonsTemp.ToList();
                        }
                        else if (RequestOption == "LoadRecordsofSelectedDate")
                        {
                            var DelNoteTemp = reader.Read<LOG_T001_A_FLIP>().ToList();
                            MC.FlipGridList = DelNoteTemp.ToList();


                            var attachment = reader.Read<COM_T003>().ToList();
                            MC.Attachment = attachment.ToList();

                        }
                        else if (RequestOption == "DelNoteDetails")
                        {
                            var DelNoteTemp = reader.Read<LOG_T001_A>().ToList();
                            MC.Delivery_Note = DelNoteTemp.ToList();

                            var Del_NotDetl = reader.Read<LOG_T001_B>().ToList();
                            MC.DelNoteItemDetails = Del_NotDetl.ToList();

                            var BatchDetailsTemp = reader.Read<LOG_T001_C>().ToList();
                            MC.ItemBatchDetails = BatchDetailsTemp.ToList();
                        }
                        else if (RequestOption == "OrderDetails")
                        {
                            var OrderDetailsTemp = reader.Read<OrderDetails_P>().ToList();
                            MC.OrderDataList = OrderDetailsTemp.ToList();

                            var OrderItemsTemp = reader.Read<ADM_M022_P>().ToList();
                            MC.ItemList = OrderItemsTemp.ToList();
                        }
                        else if (RequestOption == "DN_Report")
                        {
                            var RptDeliveryNoteTemp = reader.Read<RptDeliveryNote>().ToList();
                            MC.RptDeliveryNoteList = RptDeliveryNoteTemp.ToList();
                        }
                        else if (RequestOption == "DN_PackingList")
                        {
                            var RptPackingListTemp = reader.Read<RptPackingList>().ToList();
                            MC.RptPackingListList = RptPackingListTemp.ToList();
                        }
                        else if (RequestOption == "DN_Report1" || RequestOption == "DN_Report2")
                        {
                            var RptDeliveryNoteTemp = reader.Read<RptDeliveryNote>().ToList();
                            MC.RptDeliveryNoteList = RptDeliveryNoteTemp.ToList();

                            var RptSalesInvoiceTax = reader.Read<RptSalesInvoiceTax>().ToList();
                            MC.RptSalesInvoiceTax = RptSalesInvoiceTax.ToList();

                        }
                        else if (RequestOption == "DispatchReport")
                        {
                            var RptDeliveryNoteTemp = reader.Read<RptDeliveryNote>().ToList();
                            MC.RptDeliveryNoteList = RptDeliveryNoteTemp.ToList();
                        }
                        else if (RequestOption == "LoadInitialDataWith_DN_From_Dispatch_Order")
                        {

                            var PartyTransTemp = reader.Read<ADM_M028_P>().ToList();
                            MC.PartyTranList = PartyTransTemp.ToList();

                            var UomTemp = reader.Read<ADM_M038_B_P>().ToList();
                            MC.UomList = UomTemp.ToList();

                            var StoreLocTemp = reader.Read<MM_M001_P>().ToList();
                            MC.StoreLocList = StoreLocTemp.ToList();

                            var Settings = reader.Read<EPR_T003_S>().ToList();
                            MC.SettingsList = Settings.ToList();

                            var CartonsTemp = reader.Read<EPR_T003_A_P>().ToList();
                            MC.CartonsList = CartonsTemp.ToList();

                            var DNMaster = reader.Read<LOG_T001_A>().ToList();
                            MC.Delivery_Note = DNMaster.ToList();

                            var DNItem = reader.Read<LOG_T001_B>().ToList();
                            MC.DelNoteItemDetails = DNItem.ToList();

                            var DocCatList = reader.Read<SYS_M002>().ToList();
                            MC.DocCategoryList = DocCatList.ToList();

                            var PartyAddressTemp = reader.Read<ADM_M028_D_P>().ToList();
                            MC.PartyAddressList = PartyAddressTemp.ToList();

                            var PartyContactTemp = reader.Read<ADM_M028_C_P>().ToList();
                            MC.PartyContactList = PartyContactTemp.ToList();

                            MC.TransportMode = reader.Read<SYS_M026>().ToList();
                        }
                    }
                }
                strData = ObjectSerializationService.ObjectToXML(MC);
                return strData;
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
    public class MultipleContext_LOG_T001_A
    {
        public List<ADM_M028_P> PartyList { get; set; }//Party_Master
        public List<ADM_M028_D_P> PartyAddressList { get; set; }
        public List<ADM_M028_C_P> PartyContactList { get; set; }
        public List<Order_No_P> OrderList { get; set; }//Reference Doc List
        public List<SYS_M005_P> DeliveryTypeList { get; set; }//delivery_type
        public List<SYS_M002_P> DocTypeList { get; set; }
        public List<ADM_M028_P> PartyTranList { get; set; }// PartySupplier
        public List<ADM_M037_P> CurrencyList { get; set; }//Currency Master
        public List<ADM_M001_A_P> SalesOrgList { get; set; }
        public List<ADM_M001_C_P> DistributionChannelList { get; set; }
        public List<ADM_M001_D_P> SalesDivisionList { get; set; }
        public List<ADM_M001_I_P> SalesOfficeList { get; set; }
        public List<ADM_M001_H_P> SalesGroupList { get; set; }
        public List<MM_M001_P> StoreLocList { get; set; }//Store_Loc
        public List<SYS_M003_P> ItemCategoryList { get; set; }//Item Master
        public List<ADM_M038_B_P> UomList { get; set; }// UOM_Master  
        public List<ADM_M012_P> CountryList { get; set; }  //Country Master     
        public List<ADM_M037_P> licList { get; set; }
        public List<ADM_M022_P> ItemList { get; set; } // Order Item Details
        public List<ADM_M030_P> ParamValueList { get; set; }//Flute Master
        public List<ADM_M031_P> ParameterList { get; set; } //Parameter Master
        public List<OrderDetails_P> OrderDataList { get; set; } // Order Load
        public List<MM_S003_P> BatchesList { get; set; } // Already Exist item Batches (like Batch Master)
        public List<LOG_T001_A> Delivery_Note { get; set; } //Delivery_Note Master Transaction List
        public List<LOG_T001_A_FLIP> FlipGridList { get; set; }
        public List<LOG_T001_B> DelNoteItemDetails { get; set; }
        public List<LOG_T001_C> ItemBatchDetails { get; set; }
        public List<ADM_M038_C_P> ConFactorList { get; set; }
        public List<RptDeliveryNote> RptDeliveryNoteList { get; set; }
        public List<RptPackingList> RptPackingListList { get; set; }
        public List<EPR_T003_A_P> CartonsList { get; set; }
        public List<ADM_M024_P> SellerList { get; set; }
        public List<SYS_M002> DocCategoryList { get; set; }
        public List<ADM_M044_P> IncoTermsList { get; set; }
        public List<RptSalesInvoiceTax> RptSalesInvoiceTax { get; set; }
        public List<MM_T001_P> ReserveDateList { get; set; }
        public List<EPR_T003_S> SettingsList { get; set; }
        public List<Report_Data_P> Report_DataList2 { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<SYS_M026> TransportMode { get; set; }
        public List<OrderItemData> OrderItems { get; set; }
        public List<MM_S003_P> HandlingUnitList { get; set; }
        public List<EWayBill_document> EB_BillLists { get; set; }
        public List<EWayBill_itemList> EB_ItemList { get; set; }
        public List<STD_PARTY> STD_PLANT_PARTY_LIST { get; set; }
        public List<STD_MIS_BE> Batch_List { get; set; }
        public List<STD_LIST_BE> RESERVATION_LIST { get; set; }

    }

}
