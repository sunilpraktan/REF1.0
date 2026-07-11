using Reflection.EF;
using Reflection.EF.Production;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Reflection.EF.Production.ReportEntityProduction;
using Reflection.EF.Communication;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    public class PPC_T003BL : ReflectionBusinessLogic
    {
       
        private static string connectionString;

        PPC_T003 pPC_T003 = new PPC_T003();
        MultipleContext_PPC_T003 MC = new MultipleContext_PPC_T003();

         public PPC_T003BL(string BusinessEntity)
         {
            connectionString = base.ReflectionConnectionString;
         }
         public PPC_T003BL()
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
                    var reader = conn.QueryMultiple("PPC_T003Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<PPC_T003>().ToList();
                    MC.MasterEntity = MasterData.ToList();

                    var FlipGridData = reader.Read<PPC_T003_BackFlip>().ToList();
                    MC.BackFlipEntity = FlipGridData.ToList();
                    if (MC.MasterEntity.Count > 0)
                    {
                        pPC_T003 = MC.MasterEntity[0];
                    }
                  
                    pPC_T003.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);

                }
                strReturnData = ObjectSerializationService.ObjectToXML(pPC_T003);

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
                    var reader = conn.QueryMultiple("PPC_T003Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<PPC_T003>().ToList();
                    MC.MasterEntity = MasterData.ToList();

                    var FlipGridData = reader.Read<PPC_T003_BackFlip>().ToList();
                    MC.BackFlipEntity = FlipGridData.ToList();

                    if (MC.MasterEntity.Count > 0)
                    {
                        pPC_T003 = MC.MasterEntity[0];
                    }
                    pPC_T003.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
                }
                strReturnData = ObjectSerializationService.ObjectToXML(pPC_T003);
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
                    int intOut = conn.Execute("PPC_T003Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
                    var reader = conn.QueryMultiple("PPC_T003LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        #region LoadInitialData

                        var DocTypeinfo = reader.Read<SYS_M002>().ToList();
                        MC.DocTypeInfo = DocTypeinfo.ToList();

                        MC.Ref_DocTypeData = reader.Read<SYS_M013_P>().ToList();

                        MC.Ref_DocNoData = reader.Read<Ref_Doc_no>().ToList();

                        MC.MachineMaster = reader.Read<EPR_T001_P>().ToList();
                       
                        MC.EmployeeMaster = reader.Read<ADM_M024_P>().ToList();
                        
                        MC.ShiftMaster = reader.Read<ADM_M042_P>().ToList();

                        MC.UOMList = reader.Read<ADM_M038_B_P>().ToList();
                       
                        MC.RptUltraLabelList = reader.Read<RptUltrasonicLabelGen>().ToList();

                        var t_statusData = reader.Read<ADM_M0013>().ToList();
                        MC.t_statusList = t_statusData.ToList();

                        var Grade = reader.Read<ADM_M030_P>().ToList();
                        MC.GradeList = Grade.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        #endregion
                    }
                    else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                    {
                        #region LoadDocumentWithReferenceDocumentNumber

                        var MasterData = reader.Read<PPC_T003>().ToList();
                        MC.MasterEntity = MasterData.ToList();
                        //pPC_T003 = MC.MasterEntity[0];

                        var attachmentData = reader.Read<COM_T003>().ToList();
                        MC.AttachmentData = attachmentData.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;

                        #endregion
                    }
                    else if(RequestOption == "LoadData")
                    {
                       
                        var Masterdata = reader.Read<PPC_T003>().ToList();
                        MC.MasterEntity = Masterdata.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;
                    }
                    else if(RequestOption == "RescanBarcode")
                    {
                        var rescan = reader.Read<PPC_T003>().ToList();
                        MC.RescanBarcode = rescan.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;
                    }
                    else if (RequestOption == "LoadFromFilters")
                    {
                        MC.BackFlipEntity = reader.Read<PPC_T003_BackFlip>().ToList();

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

    public class MultipleContext_PPC_T003
   {
        public List<PPC_T003_BackFlip> BackFlipEntity { get; set; }
        public List<PPC_T003> MasterEntity { get; set; }
        public List<EPR_T001_P> MachineMaster { get; set; }
        public List<ADM_M024_P> EmployeeMaster { get; set; }
        public List<ADM_M042_P> ShiftMaster { get; set; }
        public List<ADM_M038_B_P> UOMList { get; set; }  //UOM List
        public List<RptUltrasonicLabelGen> RptUltraLabelList { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<SYS_M013_P> Ref_DocTypeData { get; set; }
        public List<Ref_Doc_no> Ref_DocNoData { get; set; }
        public List<PPC_T003> RescanBarcode { get; set; }
        public List<SYS_M002> DocTypeInfo { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<ADM_M030_P> GradeList { get; set; }
    }
    public class PPC_T003_BackFlip
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> prod_date { get; set; }
        public Nullable<System.DateTime> clean_date { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string batch_no { get; set; }
        public string machinecode { get; set; }
        public string shift1 { get; set; }
        public string shift_incharge { get; set; }
        public string m_operator { get; set; }
        public string EmpName { get; set; }
        public bool active { get; set; }
        public string barcode { get; set; }
        public decimal quantity { get; set; }
        public string t_display { get; set; }

    }
}
