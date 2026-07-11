using Reflection.EF.Project_Management;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Reflection.EF.Admin;
using Reflection.EF;
using Reflection.EF.Communication;
using Reflection.EF.ReflectionSystem;


using Reflection.EF.Communication;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    public class ZCRM_T004BL : ReflectionBusinessLogic
    {  
        private static string connectionString;
        ZCRM_T004 MasterEntity = new ZCRM_T004();
        MultipleContext_ZCRM_T004 MC = new MultipleContext_ZCRM_T004();
        public ZCRM_T004BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZCRM_T004BL()
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
                    var reader = conn.QueryMultiple("ZCRM_T004Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ZCRM_T004Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<ZCRM_T004>().ToList();
                    List<ZCRM_T004> Masterlist = MasterData.ToList();
                    MasterEntity = Masterlist[0];


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
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZCRM_T004Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ZCRM_T004Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<ZCRM_T004>().ToList();
                    List<ZCRM_T004> Masterlist = MasterData.ToList();
                    MasterEntity = Masterlist[0];

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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZCRM_T004Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZCRM_T004LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {

                        MC.PartyMaster = reader.Read<ADM_M028_P>().ToList();

                        var itemList = reader.Read<ADM_M022_POPUP>().ToList();
                        MC.ItemList = itemList.ToList();

                        var unitList = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UnitList = unitList.ToList();

                        var paymethodList = reader.Read<ACC_M021_P>().ToList();
                        MC.PayMethodList = paymethodList.ToList();

                        var DocTypes = reader.Read<SYS_M002>().ToList();
                        MC.DocumentTypes = DocTypes.ToList();

                        var sellers = reader.Read<ADM_M024_P>().ToList();
                        MC.Sellers = sellers.ToList();

                        MC.t_statusList = reader.Read<ADM_M0013>().ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

                    }
                    else if (RequestOption == "LoadPartyDetails")
                    {
                        var contactMaster = reader.Read<ADM_M028_C_P>().ToList();
                        MC.ContactInfoMaster = contactMaster.ToList();

                        var partyAddress = reader.Read<ADM_M028_D>().ToList();
                        MC.PartyAddress = partyAddress.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var MasterData = reader.Read<ZCRM_T004>().ToList();
                        MC.DocumentMaster = MasterData.ToList();

                        var contactMaster = reader.Read<ADM_M028_C_P>().ToList();
                        MC.ContactInfoMaster = contactMaster.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadBackFlipData")
                    {
                        var documentDataFlipGrid = reader.Read<ZCRM_T004Flip>().ToList();
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
        public class MultipleContext_ZCRM_T004
        {
            public List<ZCRM_T004Flip> DocumentDataFlipGrid { get; set; }
            public List<ADM_M028_P> PartyMaster { get; set; }
            public List<ADM_M022_POPUP> ItemList { get; set; }
            public List<ADM_M038_B_P> UnitList { get; set; }
            public List<ADM_M028_C_P> ContactInfoMaster { get; set; }
            public List<ADM_M028_D> PartyAddress { get; set; }
            public List<ZCRM_T004> DocumentMaster { get; set; }
            public List<ACC_M021_P> PayMethodList { get; set; }
            public List<COM_T003> Attachment { get; set; }
            public List<SYS_M002> DocumentTypes { get; set; }
            public List<ADM_M024_P> Sellers { get; set; }
            public List<ADM_M0013> t_statusList { get; set; }
        }
    }
}
