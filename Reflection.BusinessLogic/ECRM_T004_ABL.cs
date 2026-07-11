using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using Reflection.EF.CRM;
using System.Data;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ECRM_T004_ABL : ReflectionBusinessLogic
    {
        static int obj = 0;
        private static string connectionString;
        // ObjectParameter objpara = new ObjectParameter("id ", obj);
        ECRM_T004_A eCRM_T004A = new ECRM_T004_A();

        public ECRM_T004_ABL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ECRM_T004_ABL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            try
            {
                MultipleContext_ECRM_T004_A MC = new MultipleContext_ECRM_T004_A();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ECRM_T004_AInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var PDIEntryA = reader.Read<ECRM_T004_A>().ToList();
                    eCRM_T004A = new ECRM_T004_A();
                    MC.PDIEntry = PDIEntryA.ToList();

                    var PDIEntryDetailsB = reader.Read<ECRM_T004_B>().ToList();
                    eCRM_T004A = new ECRM_T004_A();
                    MC.PDIEntryDetails = PDIEntryDetailsB.ToList();

                    eCRM_T004A = MC.PDIEntry[0];
                    eCRM_T004A.XmlDataDocument_ECRM_T004_B = ObjectSerializationService.ObjectToXML(MC.PDIEntryDetails);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(eCRM_T004A);
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
                MultipleContext_ECRM_T004_A MC = new MultipleContext_ECRM_T004_A();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ECRM_T004_AUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var PDIEntryAA = reader.Read<ECRM_T004_A>().ToList();
                    eCRM_T004A = new ECRM_T004_A();
                    MC.PDIEntry = PDIEntryAA.ToList();

                    var PDIEntryDetailsBB = reader.Read<ECRM_T004_B>().ToList();
                    eCRM_T004A = new ECRM_T004_A();
                    MC.PDIEntryDetails = PDIEntryDetailsBB.ToList();

                    eCRM_T004A = MC.PDIEntry[0];
                    eCRM_T004A.XmlDataDocument_ECRM_T004_B = ObjectSerializationService.ObjectToXML(MC.PDIEntryDetails);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(eCRM_T004A);
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
        public string Delete(int Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ECRM_T004_ADelete", new { @id = Request }, commandType: CommandType.StoredProcedure);
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
        public string GetData(string strType, int intValue, string strValue)
        {
            MultipleContext_ECRM_T004_A MC = new MultipleContext_ECRM_T004_A();
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ECRM_T004_ALoadAll", new
                    {
                        @param = strType,
                        @PD_id = intValue,
                        @machine_Id = intValue,
                        @prodate = strValue,
                        @plant_id = strValue

                    }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (strType == "LoadAll")
                    {
                        var PDI_Entry = reader.Read<ECRM_T004_A>().ToList();
                        MC.PDIEntry = PDI_Entry.ToList();

                        var ILDCharts = reader.Read<EPR_T001_PopUp>().ToList();
                        MC.ILDChart = ILDCharts.ToList();

                        //var PDI_Entry_Details = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ECRM_T004_B>(reader).ToList();
                        //MC.PDIEntryDetails = PDI_Entry_Details.ToList();
                        //reader.NextResult();

                        //var MachineM = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ZADM_M013_PopUp>(reader).ToList();
                        //MC.Machine = MachineM.ToList();
                        //reader.NextResult();

                        //var Model = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ZADM_M009_PopUp>(reader).ToList();
                        //MC.ModelNo = Model.ToList();
                        //reader.NextResult();

                        //var Product1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M022_PopUp>(reader).ToList();
                        //MC.Product = Product1.ToList();
                        //reader.NextResult();

                        var CustomerForBack = reader.Read<ADM_M028_PopUp>().ToList();
                        MC.CustomerForBack = CustomerForBack.ToList();

                        //var Shiftmaster = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M042_P>(reader).ToList();
                        //MC.ShiftMaster = Shiftmaster.ToList();

                        var EmpMaster = reader.Read<ADM_M024_P>().ToList();
                        MC.EmpList = EmpMaster.ToList();

                        var Barcode = reader.Read<ECRM_T003_A>().ToList();
                        MC.BatchDetails = Barcode.ToList();
                    }
                    else if (strType == "PDIEntry_Details")
                    {
                        var PDI_Entry_Details = reader.Read<ECRM_T004_B>().ToList();
                        MC.PDIEntryDetails = PDI_Entry_Details.ToList();
                        // reader.NextResult();

                        //var Uom = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M038_B_PopUp>(reader).ToList();
                        //MC.Unit = Uom.ToList();
                    }
                    else if (strType == "Machine_Conversion_Data")
                    {
                        var Convlot = reader.Read<ECR_T004_PopUp_Lot>().ToList();
                        MC.ConvLot = Convlot.ToList();

                        var ShiftLot = reader.Read<ECR_T004_PopUp_Lot>().ToList();
                        MC.ShiftLot = ShiftLot.ToList();

                    }
                    else if (strType == "PDIEntryReport")
                    {
                        var PdiReport = reader.Read<PDIRpt_ECRM_T004_A>().ToList();
                        MC.PdiRpt = PdiReport.ToList();
                    }
                }
                strData = ObjectSerializationService.ObjectToXML(MC);
                return strData;
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
        public string GetData2(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_ECRM_T004_A MC = new MultipleContext_ECRM_T004_A();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ECRM_T004_A_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadQualityInterestRpt")
                    {
                        var PDIQualityInst = reader.Read<SEL_T001_PDIQualityInstRpt>().ToList();
                        MC.PDI_QualityInst = PDIQualityInst.ToList();

                    }
                    else if (RequestOption == "LoadBarcode")
                    {
                        var WritingTest = reader.Read<ECRM_T003_A>().ToList();
                        MC.WritingTestPopup = WritingTest.ToList();

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

        public class MultipleContext_ECRM_T004_A
        {
            public List<ECRM_T004_A> PDIEntry { get; set; }                          //PDI Entry    
            public List<EPR_T001_PopUp> ILDChart { get; set; }                       //ILDChart Master      
            public List<ZADM_M013_PopUp> Machine { get; set; } //Machine Master

            public List<ECR_T004_PopUp_Lot> ConvLot { get; set; }                    //Conv Lot From ILDChart  
            public List<ECRM_T004_B> PDIEntryDetails { get; set; }                   //PDI Entry Details
            public List<PDIRpt_ECRM_T004_A> PdiRpt { get; set; }                        // PDI Entry Report 
            public List<ADM_M028_PopUp> CustomerForBack { get; set; }
            public List<ECR_T004_PopUp_Lot> ShiftLot { get; set; }
            public List<ADM_M024_P> EmpList { get; set; }
            public List<SEL_T001_PDIQualityInstRpt> PDI_QualityInst { get; set; }
            //public List<ADM_M042_P> ShiftMaster { get; set; }
            //public List<ADM_M022_PopUp> Product { get; set; }                        // item  Master 
            //public List<ADM_M028_PopUp> Party { get; set; }                        // Party Master 
            public List<ECRM_T003_A> BatchDetails { get; set; }
            public List<ECRM_T003_A> WritingTestPopup { get; set; }
        }
    }
}
