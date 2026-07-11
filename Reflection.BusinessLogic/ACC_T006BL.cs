using Dapper;
using Reflection.EF;
using Reflection.EF.ADM;
using Reflection.EF.Communication;
using Reflection.EF.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    class ACC_T006BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        ACC_T006 MasterEntity = new ACC_T006();
        MultipleContext_ACC_T006 MC = new MultipleContext_ACC_T006();

        public ACC_T006BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_T006BL()
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
                    var reader = conn.QueryMultiple("ACC_T006_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlip = reader.Read<ACC_T002_Flip>().ToList();
                    MC.FlipGridData = BackFlip.ToList();

                    var MasterData = reader.Read<ACC_T006>().ToList();
                    List<ACC_T006> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var DetailData = reader.Read<ACC_T006_A>().ToList();
                    MC.DetailData = DetailData.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
                    MasterEntity.XmlDataDocument_ACC_T006_A = ObjectSerializationService.ObjectToXML(MC.DetailData);
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
                    var reader = conn.QueryMultiple("ACC_T006_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlip = reader.Read<ACC_T002_Flip>().ToList();
                    MC.FlipGridData = BackFlip.ToList();

                    var MasterData = reader.Read<ACC_T006>().ToList();
                    List<ACC_T006> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var DetailData = reader.Read<ACC_T006_A>().ToList();
                    MC.DetailData = DetailData.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
                    MasterEntity.XmlDataDocument_ACC_T006_A = ObjectSerializationService.ObjectToXML(MC.DetailData);
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
                    int intOut = conn.Execute("ACC_T006_DEL", new { @id = Request }, commandType: CommandType.StoredProcedure);
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
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                if (RequestOption == "GetLedgerView")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ACC_T006_GET_LGR", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                        var MasterData = reader.Read<ACC_T006>().ToList();
                        MC.MasterData = MasterData.ToList();

                        var DetailData = reader.Read<ACC_T006_A>().ToList();
                        MC.DetailData = DetailData.ToList();
                    }
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    return strReturnData;
                }

                else
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ACC_T006_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            //var FlipGridData = reader.Read<ACC_T002_Flip>().ToList();
                            //MC.FlipGridData = FlipGridData.ToList();

                            var PartyMaster = reader.Read<ADM_M028_P>().ToList();
                            MC.PartyMaster = PartyMaster.ToList();

                            var RefDocData = reader.Read<SEL_T003_PUR_T005_RefDoc>().ToList();
                            MC.RefDocData = RefDocData.ToList();

                            var CurrencyMaster = reader.Read<ADM_M037_P>().ToList();
                            MC.CurrencyMaster = CurrencyMaster.ToList();

                            var GLCodeMaster = reader.Read<ACC_M003_P>().ToList();
                            MC.GLCodeMaster = GLCodeMaster.ToList();

                            var CostCenterMaster = reader.Read<ACC_M019_P>().ToList();
                            MC.CostCenterMaster = CostCenterMaster.ToList();

                            var BankMaster = reader.Read<ACC_M004_P>().ToList();
                            MC.BanksMaster = BankMaster.ToList();

                            var _GeneralLedgerList = reader.Read<General_Ledger_P>().ToList();
                            MC.GeneralLedgerList = _GeneralLedgerList.ToList();

                            var _PostingKeyList = reader.Read<ACC_M003_Q_P>().ToList();
                            MC.PostingKeyList = _PostingKeyList.ToList();

                            var t_statusData = reader.Read<ADM_M0013>().ToList();
                            MC.t_statusList = t_statusData.ToList();

                            var _DocTypeList = reader.Read<SYS_M015_P>().ToList();
                            MC.DocTypeList = _DocTypeList.ToList();

                            var _PayMethodList = reader.Read<ACC_M027_P>().ToList();
                            MC.PayMethodList = _PayMethodList.ToList();
                        }
                        else if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var MasterData = reader.Read<ACC_T006>().ToList();
                            MC.MasterData = MasterData.ToList();

                            var DetailData = reader.Read<ACC_T006_A>().ToList();
                            MC.DetailData = DetailData.ToList();

                            var Attachment = reader.Read<COM_T003>().ToList();
                            MC.AttachmentData = Attachment.ToList();
                        }
                        else if (RequestOption == "LoadHistory")
                        {
                            var BackFlip = reader.Read<ACC_T002_Flip>().ToList();
                            MC.FlipGridData = BackFlip.ToList();
                        }
                    }
                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    return strReturnData;
                }
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
    public class MultipleContext_ACC_T006 : MC_FICO_BE
    {
        //public List<ADM_M0013> STATUS_LIST { get; set; }
        //public List<STD_DOC_TYPE> DOC_TYPE_LIST { get; set; }
        public List<ACC_T006> MasterData { get; set; }
        public List<ACC_T006_A> DetailData { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<ADM_M037_P> CurrencyMaster { get; set; }
        public List<ACC_M003_P> GLCodeMaster { get; set; }
        public List<ACC_M019_P> CostCenterMaster { get; set; }
        public List<ACC_M022> JEType { get; set; }
        public List<VendorPopup> VendorDetails { get; set; }
        public List<ACC_T002_Flip> FlipGridData { get; set; }
        public List<SEL_T003_PUR_T005_RefDoc> RefDocData { get; set; }
        public List<ACC_M004_P> BanksMaster { get; set; }
        public List<ACC_M001A_P> PostingPeriodMaster { get; set; }
        public List<ACC_M001A_P> FinYearMaster { get; set; }
        public List<General_Ledger_P> GeneralLedgerList { get; set; }
        public List<ACC_M003_Q_P> PostingKeyList { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<SYS_M015_P> DocTypeList { get; set; }
        public List<ACC_M027_P> PayMethodList { get; set; }
    }
}
