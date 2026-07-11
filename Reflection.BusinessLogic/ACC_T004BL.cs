using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF;
using Reflection.EF.Finance;
using System.Collections.ObjectModel;
using Reflection.EF.Communication;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    public class ACC_T004BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ACC_T004 MC = new MultipleContext_ACC_T004();
        MultipleContext_ACC_T004 MCTemp = new MultipleContext_ACC_T004();
        ACC_T004 masterEntity = new ACC_T004();
        public ACC_T004BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_T004BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_T004Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _DocDataFlipGridList = reader.Read<ACC_T004_Flip>().ToList();
                    MC.DocDataFlipGridList = _DocDataFlipGridList.ToList();

                    var _MasterEntityList = reader.Read<ACC_T004>().ToList();
                    MC.MasterEntityList = _MasterEntityList.ToList();

                    var _ItemsEntityList = reader.Read<ACC_T004_A>().ToList();
                    MC.ItemsEntityList = _ItemsEntityList.ToList();
            
                    masterEntity = MC.MasterEntityList[0];
                    masterEntity.XmlDataDocument_ACC_T004_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntityList);
                    
                    masterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocDataFlipGridList);
                }
                strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
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
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_T004Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _DocDataFlipGridList = reader.Read<ACC_T004_Flip>().ToList();
                    MC.DocDataFlipGridList = _DocDataFlipGridList.ToList();

                    var _MasterEntityList = reader.Read<ACC_T004>().ToList();
                    MC.MasterEntityList = _MasterEntityList.ToList();

                    var _ItemsEntityList = reader.Read<ACC_T004_A>().ToList();
                    MC.ItemsEntityList = _ItemsEntityList.ToList();

                    if (MC.MasterEntityList.Count > 0)
                    {
                        masterEntity = MC.MasterEntityList[0];
                    }
                    masterEntity.XmlDataDocument_ACC_T004_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntityList);

                    masterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocDataFlipGridList);
                }
                strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
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
                    int intOut = conn.Execute("ACC_T004Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_ACC_T004 MC = new MultipleContext_ACC_T004();
            MultipleContext_ACC_T004 MCTemp = new MultipleContext_ACC_T004();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_T004LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        //var _flipGridData = reader.Read<ACC_T004_Flip>().ToList();
                        //MC.DocDataFlipGridList = _flipGridData.ToList();

                        var _finYear = reader.Read<ACC_M001A_P>().ToList();
                        MC.FinYearList = _finYear.ToList();

                        var _postPeriod = reader.Read<ACC_M001A_P>().ToList();
                        MC.PostPeriodList = _postPeriod.ToList();

                        var _GL_CodeDetailsList = reader.Read<ACC_M003_P>().ToList();
                        MC.GL_CodeDetailsList = _GL_CodeDetailsList.ToList();

                        var _CurrencyList = reader.Read<ADM_M037_P>().ToList();
                        MC.CurrencyList = _CurrencyList.ToList();

                        var _GeneralLedgerList = reader.Read<General_Ledger_P>().ToList();
                        MC.GeneralLedgerList = _GeneralLedgerList.ToList();

                        var _BillDocList = reader.Read<SEL_T003_P>().ToList();
                        MC.BillDocList = _BillDocList.ToList();

                        var t_statusData = reader.Read<ADM_M0013>().ToList();
                        MC.STATUS_LIST = t_statusData.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {

                        var masterData = reader.Read<ACC_T004>().ToList();
                        MCTemp.MasterEntityList = masterData.ToList();

                        var itemData = reader.Read<ACC_T004_A>().ToList();
                        MCTemp.ItemsEntityList = itemData.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MCTemp.AttachmentList = Attachment.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MCTemp);
                    }
                    else if (RequestOption == "LoadHistory")
                    {
                        var _DocDataFlipGridList = reader.Read<ACC_T004_Flip>().ToList();
                        MC.DocDataFlipGridList = _DocDataFlipGridList.ToList();

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

    public class MultipleContext_ACC_T004
    {
        public List<ADM_M0013> STATUS_LIST { get; set; }
        public List<ACC_T004> MasterEntityList { get; set; }
        public List<ACC_T004_A> ItemsEntityList { get; set; }
        public List<ACC_T004_Flip> DocDataFlipGridList { get; set; }
        public List<General_Ledger_P> GeneralLedgerList { get; set; }
        public List<ACC_M001A_P> FinYearList { get; set; }
        public List<ACC_M001A_P> PostPeriodList { get; set; }
        public List<ACC_M003_P> GL_CodeDetailsList { get; set; }
        public List<ADM_M037_P> CurrencyList { get; set; }
        public List<SEL_T003_P> BillDocList { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<COM_T003> AttachmentList { get; set; }
    }
}
