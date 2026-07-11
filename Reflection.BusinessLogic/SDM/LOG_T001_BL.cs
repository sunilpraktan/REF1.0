using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.SCM;
using Reflection.EF.SCM.ReportEntitySCM;
using Dapper;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.CRM.ReportEntityCRM;
using Reflection.EF.Production;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic.SDM
{
    public class LOG_T001_BL : ReflectionBusinessLogic
    {
        LOG_T001_A MasterEntity = new LOG_T001_A();
        MultipleContext_LOG_T001_A MC = new MultipleContext_LOG_T001_A();
        public LOG_T001_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("LOG_T001_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure, commandTimeout: 0);

                    var DelNoteTemp = reader.Read<LOG_T001_A>().ToList();
                    MC.Delivery_Note = DelNoteTemp.ToList();

                    var DelNoteDetail = reader.Read<LOG_T001_B>().ToList();
                    MC.DelNoteItemDetails = DelNoteDetail.ToList();

                    var BatchDetailsTemp = reader.Read<LOG_T001_C>().ToList();
                    MC.ItemBatchDetails = BatchDetailsTemp.ToList();

                    var BackFlipTemp = reader.Read<LOG_T001_A_FLIP>().ToList();
                    MC.FlipGridList = BackFlipTemp.ToList();

                    MasterEntity = MC.Delivery_Note[0];
                    MasterEntity.XmlDataDocument_LOG_T001_B = ObjectSerializationService.ObjectToXML(MC.DelNoteItemDetails);
                    MasterEntity.XmlDataDocument_LOG_T001_C = ObjectSerializationService.ObjectToXML(MC.ItemBatchDetails);
                    MasterEntity.XmlDataDocument_LOG_T001_D = ObjectSerializationService.ObjectToXML(MC.FlipGridList);
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
        public string Insert_Post(string Request)
        {
            try
            {
                int reader;
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    reader = conn.Execute("MM_T001_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure, commandTimeout: 300);
                }
                ReturnValue = reader.ToString(); //ObjectSerializationService.ObjectToXML(reader);              
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
                    var reader = conn.QueryMultiple("LOG_T001_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

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
                        MasterEntity = MC.Delivery_Note[0];
                    }

                    MasterEntity.XmlDataDocument_LOG_T001_B = ObjectSerializationService.ObjectToXML(MC.DelNoteItemDetails);
                    MasterEntity.XmlDataDocument_LOG_T001_C = ObjectSerializationService.ObjectToXML(MC.ItemBatchDetails);
                    MasterEntity.XmlDataDocument_LOG_T001_D = ObjectSerializationService.ObjectToXML(MC.FlipGridList);
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
                    int intOut = conn.Execute("LOG_T001_DEL", new { @delivery_no = Request }, commandType: CommandType.StoredProcedure);
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
            string RequestOption = strValue.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("LOG_T001_GET", new { @request = strValue }, commandType: CommandType.StoredProcedure, commandTimeout: 300);
                    if (RequestOption == "LoadInitialData")
                    {
                        MC.OrderList = reader.Read<Order_No_P>().ToList();
                        MC.OrderItems = reader.Read<OrderItemData>().ToList();
                        MC.TransportMode = reader.Read<SYS_M026>().ToList();
                        MC.PartyTranList = reader.Read<ADM_M028_P>().ToList();
                        MC.StoreLocList = reader.Read<MM_M001_P>().ToList();
                        MC.UomList = reader.Read<ADM_M038_B_P>().ToList();
                        MC.t_statusList = reader.Read<ADM_M0013>().ToList();
                        MC.SettingsList = reader.Read<EPR_T003_S>().ToList();
                        MC.ConFactorList = reader.Read<ADM_M038_C_P>().ToList();
                        MC.Report_DataList2 = reader.Read<Report_Data_P>().ToList();
                        MC.DocCategoryList = reader.Read<SYS_M002>().ToList();
                        MC.STD_PLANT_PARTY_LIST = reader.Read<STD_PARTY>().ToList();
                    }
                    else if (RequestOption == "REFRESH_REFERENCE")
                    {
                        MC.OrderList = reader.Read<Order_No_P>().ToList();
                    }
                    else if (RequestOption == "LoadDocumentFromDocumentNumber")
                    {
                        MC.Delivery_Note = reader.Read<LOG_T001_A>().ToList();
                        MC.DelNoteItemDetails = reader.Read<LOG_T001_B>().ToList();
                        MC.ItemBatchDetails = reader.Read<LOG_T001_C>().ToList();
                        MC.BatchesList = reader.Read<MM_S003_P>().ToList();
                    }
                    else if (RequestOption == "LoadInitialDataWith_DN_From_Dispatch_Order")
                    {
                        MC.PartyTranList = reader.Read<ADM_M028_P>().ToList();
                        MC.UomList = reader.Read<ADM_M038_B_P>().ToList();
                        MC.StoreLocList = reader.Read<MM_M001_P>().ToList();
                        MC.SettingsList = reader.Read<EPR_T003_S>().ToList();
                        MC.TransportMode = reader.Read<SYS_M026>().ToList();
                        MC.t_statusList = reader.Read<ADM_M0013>().ToList();
                        MC.Delivery_Note = reader.Read<LOG_T001_A>().ToList();
                        MC.DelNoteItemDetails = reader.Read<LOG_T001_B>().ToList();
                        //MC.BatchesList = reader.Read<MM_S003_P>().ToList();
                        MC.DocCategoryList = reader.Read<SYS_M002>().ToList();
                        //MC.HandlingUnitList = reader.Read<MM_S003_P>().ToList();

                    }
                    else if (RequestOption == "Load_BackFlip_Data")
                    {
                        MC.FlipGridList = reader.Read<LOG_T001_A_FLIP>().ToList();
                    }
                    else if (RequestOption == "ExecuteReferenceDocument")
                    {
                        MC.Delivery_Note = reader.Read<LOG_T001_A>().ToList();
                        MC.DelNoteItemDetails = reader.Read<LOG_T001_B>().ToList();
                        MC.BatchesList = reader.Read<MM_S003_P>().ToList();
                        MC.HandlingUnitList = reader.Read<MM_S003_P>().ToList();
                    }
                    else if (RequestOption == "RefreshBatchCollection")
                    {
                        MC.BatchesList = reader.Read<MM_S003_P>().ToList();
                        MC.HandlingUnitList = reader.Read<MM_S003_P>().ToList();
                    }
                    else if (RequestOption == "DN_Report")
                    {
                        MC.RptDeliveryNoteList = reader.Read<RptDeliveryNote>().ToList();
                    }
                    else if (RequestOption == "DN_PackingList")
                    {
                        MC.RptPackingListList = reader.Read<RptPackingList>().ToList();
                    }
                    else if (RequestOption == "DN_Report1" || RequestOption == "DN_Report2")
                    {
                        MC.RptDeliveryNoteList = reader.Read<RptDeliveryNote>().ToList();
                        MC.RptSalesInvoiceTax = reader.Read<RptSalesInvoiceTax>().ToList();
                    }
                    else if (RequestOption == "LoadInitialDataWithoutReference")
                    {
                        MC.PartyList = reader.Read<ADM_M028_P>().ToList(); // Temp = temporary variable
                        MC.PartyAddressList = reader.Read<ADM_M028_D_P>().ToList();
                        MC.PartyContactList = reader.Read<ADM_M028_C_P>().ToList();
                        MC.OrderList = reader.Read<Order_No_P>().ToList();
                        MC.DeliveryTypeList = reader.Read<SYS_M005_P>().ToList();
                        MC.DocTypeList = reader.Read<SYS_M002_P>().ToList();
                        MC.PartyTranList = reader.Read<ADM_M028_P>().ToList();
                        MC.CurrencyList = reader.Read<ADM_M037_P>().ToList();
                        MC.SalesOrgList = reader.Read<ADM_M001_A_P>().ToList();
                        MC.DistributionChannelList = reader.Read<ADM_M001_C_P>().ToList();
                        MC.SalesDivisionList = reader.Read<ADM_M001_D_P>().ToList();
                        MC.SalesOfficeList = reader.Read<ADM_M001_I_P>().ToList();
                        MC.SalesGroupList = reader.Read<ADM_M001_H_P>().ToList();
                        MC.StoreLocList = reader.Read<MM_M001_P>().ToList();
                        MC.ItemCategoryList = reader.Read<SYS_M003_P>().ToList();
                        MC.UomList = reader.Read<ADM_M038_B_P>().ToList();
                        MC.CountryList = reader.Read<ADM_M012_P>().ToList();
                        MC.licList = reader.Read<ADM_M037_P>().ToList();
                        MC.ItemList = reader.Read<ADM_M022_P>().ToList();
                        MC.SettingsList = reader.Read<EPR_T003_S>().ToList();
                        MC.ParameterList = reader.Read<ADM_M031_P>().ToList();
                        MC.ParamValueList = reader.Read<ADM_M030_P>().ToList();
                        MC.CartonsList = reader.Read<EPR_T003_A_P>().ToList();
                        MC.FlipGridList = reader.Read<LOG_T001_A_FLIP>().ToList();
                        MC.SellerList = reader.Read<ADM_M024_P>().ToList();
                        MC.DocCategoryList = reader.Read<SYS_M002>().ToList();
                        MC.IncoTermsList = reader.Read<ADM_M044_P>().ToList();
                        MC.ConFactorList = reader.Read<ADM_M038_C_P>().ToList();
                        MC.ReserveDateList = reader.Read<MM_T001_P>().ToList();
                        MC.Report_DataList2 = reader.Read<Report_Data_P>().ToList();
                        MC.t_statusList = reader.Read<ADM_M0013>().ToList();
                    }
                    else if (RequestOption == "JSON_EXPORT_DN")
                    {
                        MC.EB_BillLists = reader.Read<EWayBill_document>().ToList();
                        MC.EB_ItemList = reader.Read<EWayBill_itemList>().ToList();
                    }
                    else if (RequestOption == "LoadHandlingUnits")
                    {
                        MC.HandlingUnitList = reader.Read<MM_S003_P>().ToList();
                    }
                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MC);
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
