using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.CRM;
using Dapper;
using System.Collections.ObjectModel;

namespace Reflection.BusinessLogic
{
    public class ESEL_T001_ABL : ReflectionBusinessLogic
    {
        private static string connectionString;

        MultipleContext_ESEL_T001_A MC = new MultipleContext_ESEL_T001_A();

        ESEL_T001_A MasterEntity = new ESEL_T001_A();

        public ESEL_T001_ABL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public ESEL_T001_ABL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ESEL_T001_AInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                    
                    //Master Data
                    var Master = reader.Read<ESEL_T001_A>().ToList();
                    MC.MasterData = Master.ToList();
                    if (MC.MasterData.Count > 0)
                    {
                        MasterEntity = MC.MasterData[0];
                    }

                    //Detail Data
                    var Detail = reader.Read<ESEL_T001_B>().ToList();
                    MC.DetailData = Detail.ToList();

                    //BackFlip Data
                    var dataGrid = reader.Read<ESEL_T001_A_BackFlip>().ToList();
                    MC.BackFlipEntity = dataGrid.ToList();

                    MasterEntity.XmlDataDocument_ESEL_T001_B = ObjectSerializationService.ObjectToXML(MC.DetailData);
                    MasterEntity.XmlDataDocument_ESEL_T001_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
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
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ESEL_T001_AUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //Master Data
                    var Master = reader.Read<ESEL_T001_A>().ToList();
                    MC.MasterData = Master.ToList();
                    if (MC.MasterData.Count > 0)
                    {
                        MasterEntity = MC.MasterData[0];
                    }

                    //Detail Data
                    var Detail = reader.Read<ESEL_T001_B>().ToList();
                    MC.DetailData = Detail.ToList();

                    //BackFlip Data
                    var dataGrid = reader.Read<ESEL_T001_A_BackFlip>().ToList();
                    MC.BackFlipEntity = dataGrid.ToList();

                    MasterEntity.XmlDataDocument_ESEL_T001_B = ObjectSerializationService.ObjectToXML(MC.DetailData);
                    MasterEntity.XmlDataDocument_ESEL_T001_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
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
                    int intOut = 0; //conn.Execute("ESEL_T001_ADelete", new { @srNo = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_ESEL_T001_A MC = new MultipleContext_ESEL_T001_A();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ESEL_T001_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {

                        var BackFlipEntity = reader.Read<ESEL_T001_A_BackFlip>().ToList();
                        MC.BackFlipEntity = BackFlipEntity.ToList();

                        var FormType = reader.Read<ACC_M013_P>().ToList();
                        MC.FormType = FormType.ToList();

                        var Tax = reader.Read<ACC_M013_P>().ToList();
                        MC.TaxData = Tax.ToList();

                        var Customer = reader.Read<SEL_T003_P>().ToList();
                        MC.Customer = Customer.ToList();
                        
                        var PostPeriod = reader.Read<ACC_M001A_P>().ToList();
                        MC.PostPeriod = PostPeriod.ToList();

                        var Qtr = reader.Read<ACC_M001A_P>().ToList();
                        MC.Quarter = Qtr.ToList();

                        var FinancialYear = reader.Read<ACC_M001A_P>().ToList();
                        MC.FinYear = FinancialYear.ToList();

                        var Invoice = reader.Read<SEL_T003_P>().ToList();
                        MC.Invoice = Invoice.ToList();

                        var _CustomerInReport = reader.Read<SEL_T003_P>().ToList();
                        MC.CustomerInReport = _CustomerInReport.ToList();

                        var _QuarterInReport = reader.Read<ACC_M001A_P>().ToList();
                        MC.QuarterInReport = _QuarterInReport.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var MasterEntity = reader.Read<ESEL_T001_A>().ToList();
                        MC.MasterData = MasterEntity.ToList();

                        var DetailEntity = reader.Read<ESEL_T001_B>().ToList();
                        MC.DetailData = DetailEntity.ToList();
                    }
                    else if(RequestOption == "LoadInvoiceDetail")
                    {
                        var Invoice = reader.Read<SEL_T003_P>().ToList();
                        MC.Invoice = Invoice.ToList();
                    }
                    //else if (RequestOption == "LoadPendingInvoice")
                    //{
                    //    var pendingInvoice = reader.Read<SEL_T003_P>().ToList();
                    //    MC.PendingInvoice = pendingInvoice.ToList();
                    //}
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

    public class MultipleContext_ESEL_T001_A
    {
        public List<ESEL_T001_A_BackFlip> BackFlipEntity { get; set; }
        public List<ESEL_T001_A> MasterData { get; set; }
        public List<ESEL_T001_B> DetailData { get; set; }       
        public List<ACC_M013_P> FormType { get; set; }
        public List<SEL_T003_P> Customer { get; set; }        
        public List<ACC_M001A_P> FinYear { get; set; }
        public List<ACC_M001A_P> PostPeriod { get; set; }
        public List<SEL_T003_P> Invoice { get; set; }        
        public List<ACC_M013_P> TaxData { get; set; }
        public List<ACC_M001A_P> Quarter { get; set; }
        public List<SEL_T003_P> CustomerInReport { get; set; }
        public List<ACC_M001A_P> QuarterInReport { get; set; }
    }

    public class ESEL_T001_A_BackFlip
    {
        public string sch_no { get; set; }
        public string entry_no { get; set; }
        public string entry_dt { get; set; }
        public string frm_type { get; set; }
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public string serial_no { get; set; }
        public string post_period { get; set; }
        public string fin_year { get; set; }
        public string qtr { get; set; }

    }
}
