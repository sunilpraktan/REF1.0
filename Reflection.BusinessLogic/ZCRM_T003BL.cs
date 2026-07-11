using Reflection.EF;
using Reflection.EF.Production;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    public  class ZCRM_T003BL : ReflectionBusinessLogic
    {
        
        private static string connectionString;
        ZCRM_T003 MasterEntity = new ZCRM_T003();
        MultipleContext_ZCRM_T003 MC = new MultipleContext_ZCRM_T003();

        public ZCRM_T003BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZCRM_T003BL()
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
                    var reader = conn.QueryMultiple("ZCRM_T003Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<ZCRM_T003>().ToList();
                    MC.MasterEntity = MasterData.ToList();
                    MasterEntity = MC.MasterEntity[0];

                    var Defectentity = reader.Read<ZCRM_T003_A>().ToList();
                    MC.DefectEntity = Defectentity.ToList();

                    var FlipGridData = reader.Read<ZCRM_T003_BackFlip>().ToList();
                    MC.BackFlipEntity = FlipGridData.ToList();
                    
                    MasterEntity.BackFlipEntity = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
                    MasterEntity.XmlDataDocument_ZCRM_T003_A = ObjectSerializationService.ObjectToXML(MC.DefectEntity);
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
                    var reader = conn.QueryMultiple("ZCRM_T003Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                    
                    var MasterData = reader.Read<ZCRM_T003>().ToList();
                    MC.MasterEntity = MasterData.ToList();
                    MasterEntity = MC.MasterEntity[0];

                    var Defectentity = reader.Read<ZCRM_T003_A>().ToList();
                    MC.DefectEntity = Defectentity.ToList();


                    var FlipGridData = reader.Read<ZCRM_T003_BackFlip>().ToList();
                    MC.BackFlipEntity = FlipGridData.ToList();

                    MasterEntity.BackFlipEntity = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
                    MasterEntity.XmlDataDocument_ZCRM_T003_A = ObjectSerializationService.ObjectToXML(MC.DefectEntity);
                   
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
                    int intOut = conn.Execute("ZCRM_T003Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
                    var reader = conn.QueryMultiple("ZCRM_T003LoadAll", new { @Request = RequestValue },commandTimeout:0 ,commandType: CommandType.StoredProcedure);
                    
                    if (RequestOption == "LoadInitialData")
                    {
                      

                        var DocTypeinfo = reader.Read<SYS_M002>().ToList();
                        MC.DocTypeInfo = DocTypeinfo.ToList();

                        var RefDocType = reader.Read<SYS_M013_P>().ToList();
                        MC.Ref_DocTypeData = RefDocType.ToList();
 
                        var Empdata = reader.Read<ADM_M024_P>().ToList();
                        MC.EmployeeMaster = Empdata.ToList();

                        var ShiftData = reader.Read<ADM_M042_P>().ToList();
                        MC.ShiftMaster = ShiftData.ToList();

                        var barcodedetails = reader.Read<ZCRM_T003_Batch>().ToList();
                        MC.BarcodeDetails = barcodedetails.ToList();

                        var Defect = reader.Read<ZADM_M016_P>().ToList();
                        MC.DefectData = Defect.ToList();

                        var Parameter = reader.Read<ENG_T003_P>().ToList();
                        MC.ParameterData = Parameter.ToList();

                        var t_statusData = reader.Read<ADM_M0013>().ToList();
                        MC.t_statusList = t_statusData.ToList();

                        var Grade = reader.Read<ADM_M030_P>().ToList();
                        MC.GradeList = Grade.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                   
                    else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                    {
                        #region LoadDocumentWithReferenceDocumentNumber

                        var MasterData = reader.Read<ZCRM_T003>().ToList();
                        MC.MasterEntity = MasterData.ToList();

                        var Defectentity = reader.Read<ZCRM_T003_A>().ToList();
                        MC.DefectEntity = Defectentity.ToList();

                        var attachmentData = reader.Read<COM_T003>().ToList();
                        MC.AttachmentData = attachmentData.ToList();

                        var orderdetails = reader.Read<ZCRM_T003_Batch>().ToList();
                        MC.SODetails = orderdetails.ToList();
                        
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;

                        #endregion
                    }
                    else if(RequestOption == "RescanBarcode")
                    {
                        var rescanbarcode = reader.Read<ZCRM_T003>().ToList();
                        MC.RescanBarcode = rescanbarcode.ToList();

                        var orderdetails = reader.Read<ZCRM_T003_Batch>().ToList();
                        MC.SODetails = orderdetails.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadFromFilters")
                    {
                        var documentDataFlipGrid = reader.Read<ZCRM_T003_BackFlip>().ToList();
                        MC.BackFlipEntity = documentDataFlipGrid.ToList();

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

        public class MultipleContext_ZCRM_T003
        {
            public List<ZCRM_T003_BackFlip> BackFlipEntity { get; set; }
            public List<ZCRM_T003> MasterEntity { get; set; }
            public List<ZCRM_T003_A> DefectEntity { get; set; }
            public List<ZADM_M013_P> MachinMaster { get; set; }
            public List<ADM_M024_P> EmployeeMaster { get; set; }
            public List<EPR_T001_P> ItemDetail { get; set; }
            public List<ECRM_T003_A_P> MachinShift { get; set; }
            public List<ZCRM_T003_Batch> BarcodeDetails { get; set; }
            public List<COM_T003> AttachmentData { get; set; }
            public List<SYS_M013_P> Ref_DocTypeData { get; set; }
            public List<ADM_M042_P> ShiftMaster { get; set; }
            public List<ZADM_M016_P> DefectData { get; set; }
            public List <ENG_T003_P> ParameterData { get; set; }
            public List<SYS_M002> DocTypeInfo { get; set; }
            public List<ZCRM_T003> RescanBarcode { get; set; }
            public List<ZCRM_T003_Batch> SODetails { get; set; }
            public List<ADM_M0013> t_statusList { get; set; }
            public List<ADM_M030_P> GradeList { get; set; }
        }


    }
}
