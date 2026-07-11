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
{
    public class LOG_T001_A_STD_BL : ReflectionBusinessLogic
    {

        private static string connectionString;

        LOG_T001_A log_T001_A = new LOG_T001_A();
        public LOG_T001_A_STD_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public LOG_T001_A_STD_BL()
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
                    var reader = conn.QueryMultiple("LOG_T001_A_STD_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure, commandTimeout: 0);

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
                    var reader = conn.QueryMultiple("LOG_T001_A_STD_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure, commandTimeout: 0);

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
                    var reader = conn.QueryMultiple("LOG_T001_A_STD_LoadAll", new { @request = strValue }, commandType: CommandType.StoredProcedure, commandTimeout: 300);
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
                        MC.ConFactorList = reader.Read<ADM_M038_C_P>().ToList();
                        MC.TransportMode = reader.Read<SYS_M026>().ToList();
                        MC.t_statusList = reader.Read<ADM_M0013>().ToList();
                        MC.Delivery_Note = reader.Read<LOG_T001_A>().ToList();
                        MC.DelNoteItemDetails = reader.Read<LOG_T001_B>().ToList();
                        //MC.BatchesList = reader.Read<MM_S003_P>().ToList();
                        MC.DocCategoryList = reader.Read<SYS_M002>().ToList();
                        //MC.HandlingUnitList = reader.Read<MM_S003_P>().ToList();
                        MC.RESERVATION_LIST = reader.Read<STD_LIST_BE>().ToList();
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
                    else if (RequestOption == "DN_BatchList")
                    {
                        MC.Batch_List = reader.Read<STD_MIS_BE>().ToList();
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
}
