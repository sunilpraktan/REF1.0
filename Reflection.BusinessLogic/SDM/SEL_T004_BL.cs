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

namespace Reflection.BusinessLogic.SDM
{
    public class SEL_T004_BL : ReflectionBusinessLogic
    {
        SEL_T004 MasterEntity = new SEL_T004();
        MultipleContext_SEL_T004 MC = new MultipleContext_SEL_T004();

        public SEL_T004_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T004_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);

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
        public string Update(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T004_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

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
        public string UpdateStatusTO(string Request)
        {
            try
            {
                Request = (string)ObjectSerializationService.XMLToObject(Request, Request);
                int reader;
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    reader = conn.Execute("SEL_T004_UPD_STS", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                }
                ReturnValue = reader.ToString();
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
                    int intOut = conn.Execute("SEL_T004_DEL", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
                    //IEnumerable<dynamic> results = conn.Query(sql, new { @comp_code = "Sunil" }, commandType: CommandType.StoredProcedure);
                    var reader = conn.QueryMultiple("SEL_T004_GET", new { @request = strValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

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

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);

                    }
                    if (RequestOption == "LoadInitialDataPending")
                    {
                        var DocumentDataFlipGrid = reader.Read<SEL_T004Flip>().ToList();
                        MC.DocumentDataFlipGrid = DocumentDataFlipGrid.ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadHistory")
                    {
                        var DocDataFlipGrid = reader.Read<SEL_T004Flip>().ToList();
                        MC.DocumentDataFlipGrid = DocDataFlipGrid.ToList();
                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                    {
                        var MasterData = reader.Read<SEL_T004>().ToList();
                        MC.MasterEntity = MasterData.ToList();

                        var ItemDetails = reader.Read<SEL_T004_A>().ToList();
                        MC.ItemsEntity = ItemDetails.ToList();

                        var partyshiptoaddress = reader.Read<ADM_M028_D>().ToList();
                        MC.PartysShipToAddresses = partyshiptoaddress.ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
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

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
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
