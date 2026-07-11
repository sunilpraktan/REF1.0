using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Data;
using Reflection.EF.Production;
using Dapper;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.ADM;
// Created by Mayuri for Sorting 2
namespace Reflection.BusinessLogic
{
    public class ESO_T001BL : ReflectionBusinessLogic
    {
        private static String connectionString;
        ESO_T001 MasterEntity = new ESO_T001();
        MultipleContext_ESO_T001_A MC = new MultipleContext_ESO_T001_A();
        public ESO_T001BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ESO_T001BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            String strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ESO_T001Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ESO_T001Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<ESO_T001>().ToList();
                    List<ESO_T001> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    var defdata = reader.Read<ESO_T001_A>().ToList();
                    List<ESO_T001_A> DefectList = defdata.ToList();
                    MC.SortingDetails = DefectList.ToList();

                    var Defectentity = reader.Read<ESO_T001_B>().ToList();
                    MC.DefectEntity = Defectentity.ToList();

                    MasterEntity.XmlDataDocument_ESO_T001FLIP = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_ESO_T001_A = ObjectSerializationService.ObjectToXML(MC.SortingDetails);
                    MasterEntity.XmlDataDocument_ESO_T001_B = ObjectSerializationService.ObjectToXML(MC.DefectEntity);
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
            String strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ESO_T001Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ESO_T001Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<ESO_T001>().ToList();
                    List<ESO_T001> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
               
                    var defdata = reader.Read<ESO_T001_A>().ToList();
                    List<ESO_T001_A> DefectList = defdata.ToList();
                    MC.SortingDetails = DefectList.ToList();

                    var Defectentity = reader.Read<ESO_T001_B>().ToList();
                    MC.DefectEntity = Defectentity.ToList();

                    MasterEntity.XmlDataDocument_ESO_T001FLIP = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_ESO_T001_A = ObjectSerializationService.ObjectToXML(MC.SortingDetails);
                    MasterEntity.XmlDataDocument_ESO_T001_B = ObjectSerializationService.ObjectToXML(MC.DefectEntity);
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
                    int intOut = conn.Execute("ESO_T001Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
                    var reader = conn.QueryMultiple("ESO_T001LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        MC.BatchDetails = reader.Read<PPC_T003_Batch>().ToList();

                        var DocTypeinfo = reader.Read<SYS_M002>().ToList();
                        MC.DocTypeInfo = DocTypeinfo.ToList();
                     
                        var MachineCode = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineCodeList = MachineCode.ToList();

                        var UOM = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UOMList = UOM.ToList();

                        var Defect = reader.Read<ZADM_M016_P>().ToList();
                        MC.DefectList = Defect.ToList();

                        var Shift = reader.Read<ADM_M042_P>().ToList();
                        MC.Shift = Shift.ToList();

                        var ShiftIncharge = reader.Read<ADM_M024_P>().ToList();
                        MC.ShiftIncharge = ShiftIncharge.ToList();

                        

                        var Engineers = reader.Read<ADM_M038_B_P>().ToList();
                        MC.Engineer = Engineers.ToList();

                        var sortby = reader.Read<ESO_T001Sort>().ToList();
                        MC.SortBy = sortby.ToList();

                        var machine = reader.Read<ESO_T001Sort>().ToList();
                        MC.Machine = machine.ToList();

                        var t_statusData = reader.Read<ADM_M0013>().ToList();
                        MC.t_statusList = t_statusData.ToList();

                        var Grade = reader.Read<ADM_M030_P>().ToList();
                        MC.GradeList = Grade.ToList();

                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var MasterData = reader.Read<ESO_T001>().ToList();
                        MC.MasterEntity = MasterData.ToList();

                        var ItemData = reader.Read<ESO_T001_A>().ToList();
                        MC.SortingDetails = ItemData.ToList();

                        var DefectData = reader.Read<ESO_T001_B>().ToList();
                        MC.DefectEntity = DefectData.ToList();

                        var Sodetails = reader.Read<PPC_T003_Batch>().ToList();
                        MC.SODetails = Sodetails.ToList();
                    }
                    else if (RequestOption == "LoadMachineDetail")
                    {
                        var MasterData = reader.Read<ESO_T001>().ToList();
                        MC.MasterEntity = MasterData.ToList();

                        var ItemData = reader.Read<ESO_T001_A>().ToList();
                        MC.SortingDetails = ItemData.ToList();

                        var Defectentity = reader.Read<ESO_T001_B>().ToList();
                        MC.DefectEntity = Defectentity.ToList();
                    }
                    else if (RequestOption == "LoadMachineColour")
                    {
                        var MachineCode = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineCodeList = MachineCode.ToList();
                    }
                    else if (RequestOption == "LoadFromDateToDate")
                    {
                        var FlipGridData = reader.Read<ESO_T001Flip>().ToList();
                        MC.DocumentDataFlipGrid = FlipGridData.ToList();
                    }
                    else if(RequestOption == "RescanBarcode")
                    {
                        var rescanbarcode = reader.Read<ESO_T001>().ToList();
                        MC.RescanBarcode = rescanbarcode.ToList();

                        var sodetails = reader.Read<PPC_T003_Batch>().ToList();
                        MC.SODetails = sodetails.ToList();
                    }
                    else if(RequestOption == "LoadFromFilters")
                    {
                        var FlipGridData = reader.Read<ESO_T001Flip>().ToList();
                        MC.DocumentDataFlipGrid = FlipGridData.ToList();
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
    public class MultipleContext_ESO_T001_A
    {
        public List<ESO_T001Flip> DocumentDataFlipGrid { get; set; }//BF data
        public List<ZADM_M013_P> MachineCodeList { get; set; }//Machine Details
        public List<ADM_M038_B_P> UOMList { get; set; }  //UOM List
        public List<ZADM_M016_P> DefectList { get; set; }  //Defect List
        public List<ADM_M042_P> Shift { get; set; }
        public List<ESO_T001_B> DefectEntity { get; set; }
        public List<ADM_M024_P> ShiftIncharge { get; set; }        
        public List<PPC_T003_Batch> BatchDetails { get; set; }
        public List<ADM_M038_B_P> Engineer { get; set; }
        public List<ESO_T001Sort> SortBy { get; set; }
        public List<ESO_T001> MasterEntity { get; set; }  // Load Doc Data
        public List<ESO_T001_A> SortingDetails { get; set; }  // Load Defect Data
        public List <SYS_M002> DocTypeInfo { get; set; }
        public List<PPC_T003_Batch> SODetails { get; set; }
        //------------------REPORT---------------------
        public List<ESO_T001_rpt> sorting_rpt { get; set; } //Sort   
        // Only for sorting transaction
        //public List<ESO_T001> Sorting { get; set; }//Sorting
        public List<PPC_T001_P> BatchNo { get; set; }
        public List<ESO_T001_P> SortList { get; set; } //Sort
        public List<ESO_T001Sort> Machine { get; set; }
        public List<ESO_T001> RescanBarcode { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<ADM_M030_P> GradeList { get; set; }

    }
   
}