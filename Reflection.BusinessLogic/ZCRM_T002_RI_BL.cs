using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using Reflection.EF.Production;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    public class ZCRM_T002_RI_BL : ReflectionBusinessLogic
    {
       
        private static string connectionString;
        ZCRM_T002 MasterEntity = new ZCRM_T002();
        MultipleContext_ZCRM_T002 MC = new MultipleContext_ZCRM_T002();

        public ZCRM_T002_RI_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZCRM_T002_RI_BL()
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
                    var reader = conn.QueryMultiple("ZCRM_T002Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ZCRM_T004_RI_Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<ZCRM_T002>().ToList();
                    List<ZCRM_T002> Masterlist = MasterData.ToList();
                    MasterEntity = Masterlist[0];

                    var Defectentity = reader.Read<ZCRM_T002_A>().ToList();
                    MC.DefectEntity = Defectentity.ToList();

                    MasterEntity.XmlDataDocument_ZCRM_T002_Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_ZCRM_T002_A = ObjectSerializationService.ObjectToXML(MC.DefectEntity);
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
                    var reader = conn.QueryMultiple("ZCRM_T002Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ZCRM_T004_RI_Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<ZCRM_T002>().ToList();
                    List<ZCRM_T002> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var Defectentity = reader.Read<ZCRM_T002_A>().ToList();
                    MC.DefectEntity = Defectentity.ToList();

                    //MasterEntity.XmlDataDocument_ZCRM_T002_Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_ZCRM_T002_A = ObjectSerializationService.ObjectToXML(MC.DefectEntity);
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
                    int intOut = conn.Execute("ZCRM_T002Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
                    var reader = conn.QueryMultiple("ZCRM_T002LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);


                    if (RequestOption == "LoadInitialData")
                    {
                       

                        var DocTypeinfo = reader.Read<SYS_M002>().ToList();
                        MC.DocTypeInfo = DocTypeinfo.ToList();

                        var RefDocType = reader.Read<SYS_M013_P>().ToList();
                        MC.RefDocTypeData = RefDocType.ToList();

                        var machineList = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineList = machineList.ToList();

                        var empList = reader.Read<ADM_M024_P>().ToList();
                        MC.EmpList = empList.ToList();
                        
                        var defectList = reader.Read<ZADM_M016_P>().ToList();
                        MC.DefectList = defectList.ToList();

                        var ShiftData = reader.Read<ADM_M042_P>().ToList();
                        MC.ShiftMaster = ShiftData.ToList();

                        var unit = reader.Read<ADM_M038_B_P>().ToList();
                        MC.unitList = unit.ToList();

                        var parameter = reader.Read<ENG_T003_P>().ToList();
                        MC.Parameters = parameter.ToList();

                        var Barcode = reader.Read<Ref_Doc_no>().ToList();
                        MC.BatchDetails = Barcode.ToList();

                        var t_statusData = reader.Read<ADM_M0013>().ToList();
                        MC.t_statusList = t_statusData.ToList();

                        var Grade = reader.Read<ADM_M030_P>().ToList();
                        MC.GradeList = Grade.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

                    }
                    else if (RequestOption == "LoadMachineDetails")
                    {
                        var itemList = reader.Read<EPR_T001_P>().ToList();
                        MC.ItemList = itemList.ToList();                        

                        var machinShiftList = reader.Read<ECRM_T003_A_P>().ToList();
                        MC.MachinShiftList = machinShiftList.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

                    }
                    else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                    {
                        var MasterData = reader.Read<ZCRM_T002>();
                        MC.MasterEntity = MasterData.ToList();
         
                        var Defectentity = reader.Read<ZCRM_T002_A>().ToList();
                        MC.DefectEntity = Defectentity.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.AttachmentData = Attachment.ToList();

                        var Sodetails = reader.Read<Ref_Doc_no>().ToList();
                        MC.SODetails = Sodetails.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;
                    }
                    else if (RequestOption == "RescanBarcode")
                    {
                        var rescanbarcode = reader.Read<ZCRM_T002>().ToList();
                        MC.RescanBarcode = rescanbarcode.ToList();

                        var sodetails = reader.Read<Ref_Doc_no>().ToList();
                        MC.SODetails = sodetails.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;
                    }
                    else if(RequestOption == "LoadFromFilters")
                    {
                        var FlipGridData = reader.Read<ZCRM_T004_RI_Flip>().ToList();
                        MC.DocumentDataFlipGrid = FlipGridData.ToList();

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


        public class MultipleContext_ZCRM_T002
        {
            public List<ZCRM_T004_RI_Flip> DocumentDataFlipGrid { get; set; }
            public List<ADM_M024_P> EmpList { get; set; }
            public List<ZADM_M013_P> MachineList { get; set; }
            public List<ZADM_M016_P> DefectList { get; set; }
            public List<ADM_M038_B_P> unitList { get; set; }
            public List<EPR_T001_P> ItemList { get; set; }
            public List<ECRM_T003_A_P> MachinShiftList { get; set; }
            public List<ZCRM_T002> MasterEntity { get; set; }
            public List<Ref_Doc_no> BatchDetails { get; set; }
            public List<ADM_M042_P> ShiftMaster { get; set; }
            public List<SYS_M013_P> RefDocTypeData { get; set; }
            public List<ENG_T003_P> Parameters { get; set; }
            public List<ZCRM_T002_A> DefectEntity { get; set; }
            public List<COM_T003> AttachmentData { get; set; }
            public List<ZCRM_T002> RescanBarcode { get; set; }
            public List<SYS_M002> DocTypeInfo { get; set; }
            public List<Ref_Doc_no> SODetails { get; set; }
            public List<ADM_M0013> t_statusList { get; set; }
            public List<ADM_M030_P> GradeList { get; set; }
        }
    }
}
