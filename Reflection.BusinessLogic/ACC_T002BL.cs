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
    class ACC_T002BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        ACC_T002 MasterEntity = new ACC_T002();
        MultipleContext_ACC_T002 MC = new MultipleContext_ACC_T002();

        public ACC_T002BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_T002BL()
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
                    var reader = conn.QueryMultiple("ACC_T002Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlip = reader.Read<ACC_T002_Flip>().ToList();
                    MC.FlipGridData = BackFlip.ToList();

                    var MasterData = reader.Read<ACC_T002>().ToList();
                    List<ACC_T002> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var DetailData = reader.Read<ACC_T002_A>().ToList();
                    MC.DetailData = DetailData.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
                    MasterEntity.XmlDataDocument_ACC_T002_A = ObjectSerializationService.ObjectToXML(MC.DetailData);
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
                    var reader = conn.QueryMultiple("ACC_T002Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlip = reader.Read<ACC_T002_Flip>().ToList();
                    MC.FlipGridData = BackFlip.ToList();

                    var MasterData = reader.Read<ACC_T002>().ToList();
                    List<ACC_T002> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var DetailData = reader.Read<ACC_T002_A>().ToList();
                    MC.DetailData = DetailData.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
                    MasterEntity.XmlDataDocument_ACC_T002_A = ObjectSerializationService.ObjectToXML(MC.DetailData);
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
                    int intOut = conn.Execute("ACC_T002Delete", new { @id = Request }, commandType: CommandType.StoredProcedure);
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
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_T002LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

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

                        var jetype = reader.Read<ACC_M022>().ToList();
                        MC.JEType = jetype.ToList();

                        var vend = reader.Read<VendorPopup>().ToList();
                        MC.Vendors = vend.ToList();

                        var _PaymentMethodList = reader.Read<ACC_M027_P>().ToList();
                        MC.PaymentMethodList = _PaymentMethodList.ToList();

                        var _GeneralLedgerList = reader.Read<General_Ledger_P>().ToList();
                        MC.GeneralLedgerList = _GeneralLedgerList.ToList();

                        var _PostingKeyList = reader.Read<ACC_M003_Q_P>().ToList();
                        MC.PostingKeyList = _PostingKeyList.ToList();

                        var _t_statusList = reader.Read<ADM_M0013>().ToList();
                        MC.t_statusList = _t_statusList.ToList();

                        var _GLCodeMaster_Contra = reader.Read<ACC_M003_P>().ToList();
                        MC.GLCodeMaster_Contra = _GLCodeMaster_Contra.ToList();

                        var _GLCodeMaster_Cash = reader.Read<ACC_M003_P>().ToList();
                        MC.GLCodeMaster_Cash = _GLCodeMaster_Cash.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var MasterData = reader.Read<ACC_T002>().ToList();
                        MC.MasterData = MasterData.ToList();

                        var DetailData = reader.Read<ACC_T002_A>().ToList();
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
    public class MultipleContext_ACC_T002
    {
        public List<ACC_T002> MasterData { get; set; }
        public List<ACC_T002_A> DetailData { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<ADM_M037_P> CurrencyMaster { get; set; }
        public List<ACC_M003_P> GLCodeMaster { get; set; }
        public List<ACC_M019_P> CostCenterMaster { get; set; }
        public List<ACC_T002_Flip> FlipGridData { get; set; }
        public List<SEL_T003_PUR_T005_RefDoc> RefDocData { get; set; }
        public List<ACC_M022> JEType { get; set; }
        public List<ACC_M004_P> BanksMaster { get; set; }
        public List<VendorPopup> Vendors { get; set; }
        public List<ACC_M027_P> PaymentMethodList { get; set; }
        public List<General_Ledger_P> GeneralLedgerList { get; set; }
        public List<ACC_M003_Q_P> PostingKeyList { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<ACC_M003_P> GLCodeMaster_Contra { get; set; } //GL Code pop up for contra vaoucher
        public List<ACC_M003_P> GLCodeMaster_Cash { get; set; }//GL Code pop up for cash vaoucher
    }
}
