using Dapper;
using Reflection.EF;
using Reflection.EF.ADM;
using Reflection.EF.Communication;
using Reflection.EF.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class ECRM_T004_ABL_New : ReflectionBusinessLogic
    {
        private static string connectionString;

        ECRM_T004_A MasterEntity = new ECRM_T004_A();
        MultipleContext_ECRM_T004_A_New MC = new MultipleContext_ECRM_T004_A_New();

        public ECRM_T004_ABL_New(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ECRM_T004_ABL_New()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_ECRM_T004_A_New MC = new MultipleContext_ECRM_T004_A_New();
            string RequestOption = RequestValue.Split('!')[0];

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ECRM_T004_A_LoadAll_New", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure, commandTimeout: 600);
                    {
                        if (RequestOption == "LoadInitialData")
                        {

                            var PartyData = reader.Read<ADM_M028_P>().ToList();
                            MC.PartyMaster = PartyData.ToList();

                            var ShiftData = reader.Read<ADM_M042_P>().ToList();
                            MC.ShiftMaster = ShiftData.ToList();

                            var Operator = reader.Read<ADM_M024_P>().ToList();
                            MC.OperatorData = Operator.ToList();

                            var Barcode = reader.Read<ECRM_T003_P>().ToList();
                            MC.BarcodeDetails = Barcode.ToList();

                            var Defects = reader.Read<ZADM_M016_P>().ToList();
                            MC.DefectMaster = Defects.ToList();

                            var Parameters = reader.Read<ENG_T003_P>().ToList();
                            MC.ParameterMaster = Parameters.ToList();

                            var t_statusData = reader.Read<ADM_M0013>().ToList();
                            MC.t_statusList = t_statusData.ToList();

                            var Grade = reader.Read<ADM_M030_P>().ToList();
                            MC.GradeList = Grade.ToList();

                        }
                        if (RequestOption == "LoadFromFilters")
                        {
                            var BackFlip = reader.Read<ECRM_T004_Aflip>().ToList();
                            MC.DocumentDataFlipGrid = BackFlip.ToList();
                        }

                        if (RequestOption == "LoadHistory")
                        {
                            var History = reader.Read<TransHistory>().ToList();
                            MC.TransactionHistory = History.ToList();
                        }

                        if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var MasterData = reader.Read<ECRM_T004_A>().ToList();
                            MC.MasterEntity = MasterData.ToList();

                            var DefectData = reader.Read<ECRM_T004_C>().ToList();
                            MC.DefectEntity = DefectData.ToList();

                            var History = reader.Read<TransHistory>().ToList();
                            MC.TransactionHistory = History.ToList();

                            var Attachment = reader.Read<COM_T003>().ToList();
                            MC.AttachmentData = Attachment.ToList();

                            var Sodetails = reader.Read<ECRM_T003_P>().ToList();
                            MC.SODetails = Sodetails.ToList();
                        }
                        if (RequestOption == "RescanBarcode")
                        {
                            var rescanbarcode = reader.Read<ECRM_T004_A>().ToList();
                            MC.RescanBarcode = rescanbarcode.ToList();

                            var sodetails = reader.Read<ECRM_T003_P>().ToList();
                            MC.SODetails = sodetails.ToList();

                            var History = reader.Read<TransHistory>().ToList();
                            MC.TransactionHistory = History.ToList();
                        }
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;
                    }
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
        public string Insert(string Request)
        {
            MultipleContext_ECRM_T004_A_New MC = new MultipleContext_ECRM_T004_A_New();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {

                    var reader = conn.QueryMultiple("ECRM_T004_AInsert_New", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<ECRM_T004_A>().ToList();
                    List<ECRM_T004_A> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var DefectData = reader.Read<ECRM_T004_C>().ToList();
                    MC.DefectEntity = DefectData.ToList();

                    MasterEntity.XmlDataDocument_ECRM_T004_C = ObjectSerializationService.ObjectToXML(MC.DefectEntity);
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
            MultipleContext_ECRM_T004_A_New MC = new MultipleContext_ECRM_T004_A_New();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ECRM_T004_AUpdate_New", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<ECRM_T004_A>().ToList();
                    List<ECRM_T004_A> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var DefectData = reader.Read<ECRM_T004_C>().ToList();
                    MC.DefectEntity = DefectData.ToList();

                    MasterEntity.XmlDataDocument_ECRM_T004_C = ObjectSerializationService.ObjectToXML(MC.DefectEntity);
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
    }

    public class MultipleContext_ECRM_T004_A_New
    {
        public List<ADM_M028_P> PartyMaster { get; set; } // Load Party Data
        public List<ADM_M042_P> ShiftMaster { get; set; } // Load Shift Data
        public List<ADM_M024_P> OperatorData { get; set; } //Load Operator Data
        public List<ECRM_T003_P> BarcodeDetails { get; set; }// Load Barcode Data
        public List<TransHistory> TransactionHistory { get; set; }//Load Transaction History
        public List<ECRM_T004_Aflip> DocumentDataFlipGrid { get; set; } //Load Backflip Data
        public List<ECRM_T004_A> MasterEntity { get; set; }
        public List<COM_T003> AttachmentData { get; set; } // Load Attachment Data
        public List<ZADM_M016_P> DefectMaster { get; set; } //Load Defect Data
        public List<ENG_T003_P> ParameterMaster { get; set; } //Load ParameterData
        public List<ECRM_T004_C> DefectEntity { get; set; }
        public List<ECRM_T004_A> RescanBarcode { get; set; }
        public List<ECRM_T003_P> SODetails { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<ADM_M030_P> GradeList { get; set; }

    }


}
