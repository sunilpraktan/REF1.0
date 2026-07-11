using Dapper;
using Reflection.EF;
using Reflection.EF.ADM;
using Reflection.EF.Admin;
using Reflection.EF.Communication;
using Reflection.EF.CRM;
using Reflection.EF.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Reflection.BusinessLogic
{
    public class SEL_T004BL : ReflectionBusinessLogic
    {
        
        private static string connectionString;
        SEL_T004 MasterEntity = new SEL_T004();
        public SEL_T004BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public SEL_T004BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            MultipleContext_SEL_T004 MC = new MultipleContext_SEL_T004();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T004_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                  
                    var FlipGridData = reader.Read<SEL_T004Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<SEL_T004>().ToList();
                    MC.MasterEntity = MasterData.ToList();

                    var ItemsData = reader.Read<SEL_T004_A>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();

                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }
                 
                    MasterEntity.XmlDataDocument_SEL_T004_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);

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
            MultipleContext_SEL_T004 MC = new MultipleContext_SEL_T004();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T004_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<SEL_T004>().ToList();
                    MC.MasterEntity = MasterData.ToList();

                    var ItemsData = reader.Read<SEL_T004_A>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();

                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }
                    MasterEntity.XmlDataDocument_SEL_T004_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
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
        public string UpdateStatusTO(string Request)
        {
            try
            {               
                Request = (string)ObjectSerializationService.XMLToObject(Request, Request);
                int reader;
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    reader = conn.Execute("SEL_T004UpdateStatus", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                }
                string strReturnData = reader.ToString();
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
                    int intOut = conn.Execute("SEL_T004Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_SEL_T004 MC = new MultipleContext_SEL_T004();
            string RequestOption = strValue.Split('!')[0];

            string strReturnData = "";
            try
            {          
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    //IEnumerable<dynamic> results = conn.Query(sql, new { @comp_code = "Sunil" }, commandType: CommandType.StoredProcedure);
                    var reader = conn.QueryMultiple("SEL_T004_LoadAll", new { @request = strValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var doc_typeList = reader.Read<SYS_M002_P>().ToList();
                        MC.doc_typeList = doc_typeList.ToList();
                        var NotificationData = reader.Read<NotificationData>().ToList();
                        MC.NotificationData = NotificationData.ToList();
                        var _Dispatch_Order_Reference = reader.Read<SEL_T003_P_RefDoc>().ToList();
                        MC.Dispatch_Order_Reference = _Dispatch_Order_Reference.ToList();
                        var t_statusData = reader.Read<ADM_M0013>().ToList();
                        MC.t_statusList = t_statusData.ToList();
                        var transporter = reader.Read<ADM_M028_P>().ToList();
                        MC.Transporters = transporter.ToList();
                        var _ShippingTypes = reader.Read<SYS_M026>().ToList();
                        MC.ShippingTypes = _ShippingTypes.ToList();


                        //var DocumentDataFlipGrid = reader.Read<SEL_T004Flip>().ToList();
                        //MC.DocumentDataFlipGrid = DocumentDataFlipGrid.ToList();

                        //var  uom = reader.Read<ADM_M038_B_P>().ToList();
                        //MC.uom = uom.ToList();

                        //var storage_loc = reader.Read<MM_M001_P>().ToList();
                        //MC.storage_loc = storage_loc.ToList();

                        //var DeliveryNoList = reader.Read<LOG_T001_A_P>().ToList();
                        //MC.DeliveryNoList = DeliveryNoList.ToList();

                        //var _PartyMaster = reader.Read<ADM_M028_P>().ToList();
                        //MC.PartyMaster = _PartyMaster.ToList();





                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

                    }
                    if (RequestOption == "LoadInitialDataPending")
                    {
                        var DocumentDataFlipGrid = reader.Read<SEL_T004Flip>().ToList();
                        MC.DocumentDataFlipGrid = DocumentDataFlipGrid.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadHistory")
                    {
                        var DocDataFlipGrid = reader.Read<SEL_T004Flip>().ToList();
                        MC.DocumentDataFlipGrid = DocDataFlipGrid.ToList();
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                    {
                        var MasterData = reader.Read<SEL_T004>().ToList();
                        MC.MasterEntity = MasterData.ToList();

                        var ItemDetails = reader.Read<SEL_T004_A>().ToList();
                        MC.ItemsEntity = ItemDetails.ToList();

                        var partyshiptoaddress = reader.Read<ADM_M028_D>().ToList();
                        MC.PartysShipToAddresses = partyshiptoaddress.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadDocumentFromBackFlip")
                    {
                        var MasterData = reader.Read<SEL_T004>().ToList();
                        MC.MasterEntity = MasterData.ToList();

                        var ItemDetails = reader.Read<SEL_T004_A>().ToList();
                        MC.ItemsEntity = ItemDetails.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();

                        var partyshiptoaddress = reader.Read<ADM_M028_D>().ToList();
                        MC.PartysShipToAddresses = partyshiptoaddress.ToList();

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
    public class MultipleContext_SEL_T004
    {
        public List<SEL_T004Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M038_B_P> uom { get; set; }
        public List<MM_M001_P> storage_loc { get; set; }
        public List<LOG_T001_A_P> DeliveryNoList { get; set; }
        public List<SEL_T004> MasterEntity { get; set; }
        public List<SEL_T004_A> ItemsEntity { get; set; }
        public List<Log_T001_A_ItemsList> ItemList { get; set; }
        public List<SYS_M002_P> doc_typeList { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<SEL_T003_P_RefDoc> Dispatch_Order_Reference { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<ADM_M028_P> Transporters { get; set; }
        public List<ADM_M024_P> Sellers { get; set; }
        public List<SYS_M026> ShippingTypes { get; set; }
        public List<ADM_M028_D> PartysShipToAddresses { get; set; }
    }
}
