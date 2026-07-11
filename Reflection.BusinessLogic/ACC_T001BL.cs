using Dapper;
using Reflection.EF;
using Reflection.EF.Admin;
using Reflection.EF.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Reflection.EF.ReflectionSystem;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    public class ACC_T001BL : ReflectionBusinessLogic
    {

        private static string connectionString;
        ACC_T001 MasterEntity = new ACC_T001();
        MultipleContext_ACC_T001 MC = new MultipleContext_ACC_T001();
        public ACC_T001BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_T001BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            MultipleContext_ACC_T001 MC = new MultipleContext_ACC_T001();

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {

                    var reader = conn.QueryMultiple("ACC_T001Insert", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<ACC_T001>().ToList();
                    List<ACC_T001> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    var ItemsData = reader.Read<ACC_T001_A>().ToList();
                    MC.DetailEntity = ItemsData.ToList();

                    var BackFlip = reader.Read<ACC_T001_Flip>().ToList();
                    MC.DocumentDataFlipGrid = BackFlip.ToList();


                    MasterEntity.XmlDataDocument_ACC_T001_A = ObjectSerializationService.ObjectToXML(MC.DetailEntity);
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
            MultipleContext_ACC_T001 MC = new MultipleContext_ACC_T001();

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_T001Update", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<ACC_T001>().ToList();
                    List<ACC_T001> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    var DetailEntity = reader.Read<ACC_T001_A>().ToList();
                    MC.DetailEntity = DetailEntity.ToList();

                    var BackFlip = reader.Read<ACC_T001_Flip>().ToList();
                    MC.DocumentDataFlipGrid = BackFlip.ToList();

                    MasterEntity.XmlDataDocument_ACC_T001_A = ObjectSerializationService.ObjectToXML(MC.DetailEntity);
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
                    int intOut = conn.Execute("SEL_T001Delete", new { @id = Request }, commandType: CommandType.StoredProcedure);
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

            MultipleContext_ACC_T001 MC = new MultipleContext_ACC_T001();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_T001LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var BackFlip = reader.Read<ACC_T001_Flip>().ToList();
                        MC.DocumentDataFlipGrid = BackFlip.ToList();

                        var PartyMaster = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyMaster = PartyMaster.ToList();

                        var BankMaster = reader.Read<ACC_M004_P>().ToList();
                        MC.BanksMaster = BankMaster.ToList();

                        var Currancy = reader.Read<ADM_M037_P>().ToList();
                        MC.Currencys = Currancy.ToList();

                        var CompanyMaster = reader.Read<ADM_M002_P>().ToList();
                        MC.CompanyMaster = CompanyMaster.ToList();

                        var GLCode = reader.Read<ACC_M003_P>().ToList();
                        MC.GLCodes = GLCode.ToList();

                        var SalesPurchaseInvoice = reader.Read<SEL_T003_P>().ToList();
                        MC.SalesPurchaseInvoice = SalesPurchaseInvoice.ToList();

                        var CountryMaster = reader.Read<ADM_M012_P>().ToList();
                        MC.CountryMaster = CountryMaster.ToList();

                        var StateMaster = reader.Read<ADM_M013_P>().ToList();
                        MC.StateMaster = StateMaster.ToList();

                        var salesperson = reader.Read<ADM_M024_P>().ToList();
                        MC.SalesPerson = salesperson.ToList();




                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }

                    if (RequestOption == "LoadPartyAddress")
                    {

                        var PartyAddress = reader.Read<ADM_M028_D>().ToList();
                        MC.AddressMaster = PartyAddress.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }

                    else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                    {

                        var MasterData = reader.Read<ACC_T001>().ToList();
                        MC.MasterEntity = MasterData.ToList();
                        if (MC.MasterEntity.Count > 0)
                        {
                            MasterEntity = MC.MasterEntity[0];
                        }
                        var PaymentDetail = reader.Read<ACC_T001_A>().ToList();
                        MC.DetailEntity = PaymentDetail.ToList();

                        MasterEntity.XmlDataDocument_ACC_T001_A = ObjectSerializationService.ObjectToXML(MC.DetailEntity);

                        strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
                        return strReturnData;
                    }
                    else if (RequestOption == "LoadSalesPurchaseInvoice")
                    {

                        var SalesPurchaseInvoice = reader.Read<SEL_T003_P>().ToList();
                        MC.SalesPurchaseInvoice = SalesPurchaseInvoice.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }

                    else if (RequestOption == "Rpt_PaymentEntry")
                    {
                        var RptPaymentEntry = reader.Read<RptPaymentEntry>().ToList();
                        MC.RptPaymentEntry = RptPaymentEntry.ToList();

                        var RptPaymentEntryItem = reader.Read<RptPaymentEntryItem>().ToList();
                        MC.RptPaymentEntryItem = RptPaymentEntryItem.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;
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
    public class MultipleContext_ACC_T001
    {
        public List<ADM_M0013> STATUS_LIST { get; set; }
        public List<ACC_T001_Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<ACC_M004_P> BanksMaster { get; set; }
        public List<ADM_M037_P> Currencys { get; set; }
        public List<ADM_M002_P> CompanyMaster { get; set; }
        public List<ACC_M003_P> GLCodes { get; set; }
        public List<ACC_M028_P> SpecialGLCodes { get; set; }
        public List<SEL_T003_P> SalesPurchaseInvoice { get; set; }
        public List<ACC_T001> MasterEntity { get; set; }
        public List<SEL_T001_P> SalesOrderList { get; set; }
        public List<ACC_T001_A> DetailEntity { get; set; }
        public List<ADM_M028_D> AddressMaster { get; set; }
        public List<ADM_M012_P> CountryMaster { get; set; }
        public List<ADM_M013_P> StateMaster { get; set; }
        public List<ADM_M024_P> SalesPerson { get; set; }
        public List<RptPaymentEntry> RptPaymentEntry { get; set; }
        public List<RptPaymentEntryItem> RptPaymentEntryItem { get; set; }
        public List<SYS_M015> doc_typeList { get; set; }
        //Added by Priya
        public List<ACC_M004_B_P> OurBankAccNoList { get; set; }
        public List<ACC_M027_P> PayMethodList { get; set; }
        public List<SYS_M027_P> ReasonList { get; set; }
        public List<ACC_M020_P> ProfitCenterList { get; set; }
        public List<ADM_M028_E_P> PartyBankAccNoList { get; set; }
        public List<ACC_T001_A> OpenDocumentNoList { get; set; }
        public List<SYS_M015> DocumentTypes { get; set; }
        public List<ACC_T001_B> OpenItems { get; set; }
        public List<ACC_T001_C> PAYMENT_ALLOCATION { get; set; }
        public List<STD_LIST_BE> PAYMENT_MODE_LIST { get; set; }
    }
}
