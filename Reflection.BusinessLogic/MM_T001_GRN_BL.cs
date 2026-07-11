using Reflection.EF;
using Reflection.EF.Procurement;
using Reflection.EF.SCM;
using Reflection.EF.SCM.ReportEntitySCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.ReflectionSystem;

namespace Reflection.BusinessLogic
{
    public class MM_T001_GRN_BL : ReflectionBusinessLogic
    {

        private static string connectionString;
        MM_T001 MasterEntity = new MM_T001();
        public MM_T001_GRN_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MM_T001_GRN_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {

                    MC_MM_T001 MC = new MC_MM_T001();
                    MasterEntity = new MM_T001();
                    var reader = conn.QueryMultiple("MM_T001_GRN_Insert", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    var MasterTemp = reader.Read<MM_T001>().ToList();
                    MC.GRNMasterList = MasterTemp.ToList();


                    var ItemDetailsTemp = reader.Read<MM_T001_A>().ToList();
                    MC.ItemDetailsList = ItemDetailsTemp.ToList();


                    var BatchDetailsTemp = reader.Read<MM_T001_B>().ToList();
                    MC.BatchDetailsList = BatchDetailsTemp.ToList();


                    var POAllocDetailsTemp = reader.Read<MM_T001_C>().ToList();
                    MC.POAllocDetailsList = POAllocDetailsTemp.ToList();


                    var BackFlipTemp = reader.Read<MM_T001_FLIP>().ToList();
                    MC.FlipGridList = BackFlipTemp.ToList();

                    MasterEntity = MC.GRNMasterList[0];
                    MasterEntity.XmlDataDocument_MM_T001_A = ObjectSerializationService.ObjectToXML(MC.ItemDetailsList);
                    MasterEntity.XmlDataDocument_MM_T001_B = ObjectSerializationService.ObjectToXML(MC.BatchDetailsList);
                    MasterEntity.XmlDataDocument_MM_T001_C = ObjectSerializationService.ObjectToXML(MC.POAllocDetailsList);
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.FlipGridList);

                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
                MasterEntity = new MM_T001();
                MC_MM_T001 MC = new MC_MM_T001();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MM_T001_GRN_Update", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    var MasterTemp = reader.Read<MM_T001>().ToList();
                    MC.GRNMasterList = MasterTemp.ToList();


                    var ItemDetailsTemp = reader.Read<MM_T001_A>().ToList();
                    MC.ItemDetailsList = ItemDetailsTemp.ToList();


                    var BatchDetailsTemp = reader.Read<MM_T001_B>().ToList();
                    MC.BatchDetailsList = BatchDetailsTemp.ToList();


                    var POAllocDetailsTemp = reader.Read<MM_T001_C>().ToList();
                    MC.POAllocDetailsList = POAllocDetailsTemp.ToList();

                    if (MC.GRNMasterList.Count > 0)
                    {
                        MasterEntity = MC.GRNMasterList[0];
                    }

                    MasterEntity.XmlDataDocument_MM_T001_A = ObjectSerializationService.ObjectToXML(MC.ItemDetailsList);
                    MasterEntity.XmlDataDocument_MM_T001_B = ObjectSerializationService.ObjectToXML(MC.BatchDetailsList);
                    MasterEntity.XmlDataDocument_MM_T001_C = ObjectSerializationService.ObjectToXML(MC.POAllocDetailsList);

                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
                    int intOut = conn.Execute("MM_T001_MI_Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
            MC_MM_T001 MC = new MC_MM_T001();
            string RequestOption = RequestValue.Split('!')[0];

            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MM_T001_GRN_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {

                        var partyList = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyList = partyList.ToList();

                        var transporterList = reader.Read<ADM_M028_P>().ToList();
                        MC.TransporterList = transporterList.ToList();

                        var movementTypeList = reader.Read<MM_M004_P>().ToList();
                        MC.MovementTypeList = movementTypeList.ToList();

                        var docTypeList = reader.Read<SYS_M007_P>().ToList();
                        MC.DocTypeList = docTypeList.ToList();

                        var sourceDocNoList = reader.Read<PUR_T002_A_P>().ToList();
                        MC.SourceDocNoList = sourceDocNoList.ToList();

                        var itemList = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemPopupList = itemList.ToList();

                        var uOMList = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UOMList = uOMList.ToList();

                        var storeCodeList = reader.Read<MM_M001_P>().ToList();
                        MC.StoreCodeList = storeCodeList.ToList();

                        //var itemCatList = reader.Read<SYS_M008_P>().ToList();
                        //MC.ItemCatList = itemCatList.ToList();

                        var parameterList = reader.Read<ADM_M031_P>().ToList();
                        MC.ParameterList = parameterList.ToList();

                        var paramValueList = reader.Read<ADM_M030_P>().ToList();
                        MC.ParamValueList = paramValueList.ToList();

                        //var flipGridList = reader.Read<MM_T001_GRN_FLIP>().ToList();
                        //MC.FlipGridList = flipGridList.ToList();

                        var notificationData = reader.Read<NotificationData>().ToList();
                        MC.NotificationData = notificationData.ToList();

                        var t_statusData = reader.Read<SYS_M025>().ToList();
                        MC.t_statusList = t_statusData.ToList();

                        MC.TransportMode = reader.Read<SYS_M026>().ToList();

                    }
                    else if (RequestOption == "LoadRecordsofSelectedDate")
                    {
                        var flipGridList = reader.Read<MM_T001_FLIP>().ToList();
                        MC.FlipGridList = flipGridList.ToList();
                    }
                    else if (RequestOption == "GRNDetails")
                    {
                        var gRNMasterList = reader.Read<MM_T001>().ToList();
                        MC.GRNMasterList = gRNMasterList.ToList();

                        var itemDetailsList = reader.Read<MM_T001_A>().ToList();
                        MC.ItemDetailsList = itemDetailsList.ToList();

                        var batchDetailsList = reader.Read<MM_T001_B>().ToList();
                        MC.BatchDetailsList = batchDetailsList.ToList();

                        var pOAllocDetailsList = reader.Read<MM_T001_C>().ToList();
                        MC.POAllocDetailsList = pOAllocDetailsList.ToList();

                        var attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = attachment.ToList();

                    }
                    else if (RequestOption == "OrderLoad")
                    {
                        var gRNMasterList = reader.Read<MM_T001>().ToList();
                        MC.GRNMasterList = gRNMasterList.ToList();
                        var itemDetailsList = reader.Read<MM_T001_A>().ToList();
                        MC.ItemDetailsList = itemDetailsList.ToList();

                        var itemBatchDetails = reader.Read<MM_T001_B>().ToList();
                        MC.BatchDetailsList = itemBatchDetails.ToList();

                    }
                    else if (RequestOption == "Rpt_GRN")
                    {
                        MC.RptGRN = reader.Read<RptGRN>().ToList();
                    }

                    else if (RequestOption == "Opening_Stock")
                    {
                        var rptGRN = reader.Read<RptGRN>().ToList();
                        MC.RptGRN = rptGRN.ToList();

                    }
                    else if (RequestOption == "LoadHistory")
                    {
                        var documentDataFlipGrid = reader.Read<MM_T001_FLIP>().ToList();
                        MC.FlipGridList = documentDataFlipGrid.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                }
                strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
