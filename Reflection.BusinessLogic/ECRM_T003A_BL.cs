using Dapper;
using Reflection.EF;
using Reflection.EF.ADM;
using Reflection.EF.Communication;
using Reflection.EF.CRM;
using Reflection.EF.Production;
using Reflection.EF.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class ECRM_T003A_BL :ReflectionBusinessLogic
    {
        private static string connectionString;
        ECRM_T003_A_New MasterEntity = new ECRM_T003_A_New();
        MultipleContext_ECRM_T003 MC = new MultipleContext_ECRM_T003();
        public ECRM_T003A_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ECRM_T003A_BL()
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
                    var reader = conn.QueryMultiple("ECRM_T003_A_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //var FlipGridData = reader.Read<ECRM_T003_AFlip>().ToList();
                    //MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<ECRM_T003_A_New>().ToList();
                    List<ECRM_T003_A_New> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var itemdata = reader.Read<ECRM_T003_B_New>().ToList();
                    List<ECRM_T003_B_New> Items = itemdata.ToList();
                    MC.ItemEntity = Items.ToList();

                    var DefectData = reader.Read<ECRM_T003_D_New>().ToList();
                    MC.DefectEntity = DefectData.ToList();

                    // MasterEntity.XmlDataDocument_ECRM_T003_AFlip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_ECRM_T003_B = ObjectSerializationService.ObjectToXML(MC.ItemEntity);
                    MasterEntity.XmlDataDocument_ECRM_T003_D = ObjectSerializationService.ObjectToXML(MC.DefectEntity);
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
                    var reader = conn.QueryMultiple("ECRM_T003_A_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //var FlipGridData = reader.Read<ECRM_T003_AFlip>().ToList();
                    //MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<ECRM_T003_A_New>().ToList();
                    List<ECRM_T003_A_New> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var itemdata = reader.Read<ECRM_T003_B_New>().ToList();
                    List<ECRM_T003_B_New> Items = itemdata.ToList();
                    MC.ItemEntity = Items.ToList();

                    var DefectData = reader.Read<ECRM_T003_D_New>().ToList();
                    MC.DefectEntity = DefectData.ToList();

                    //MasterEntity.XmlDataDocument_ECRM_T003_AFlip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_ECRM_T003_B = ObjectSerializationService.ObjectToXML(MC.ItemEntity);
                    MasterEntity.XmlDataDocument_ECRM_T003_D = ObjectSerializationService.ObjectToXML(MC.DefectEntity);
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ECRM_T003ALoadAll", new { @Request = RequestValue }, commandTimeout : 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        //var documentDataFlipGrid = reader.Read<ECRM_T003_AFlip>().ToList();
                        //MC.DocumentDataFlipGrid = documentDataFlipGrid.ToList();

                        var DocTypeinfo = reader.Read<SYS_M002>().ToList();
                        MC.DocTypeInfo = DocTypeinfo.ToList();

                        var MachineCode = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineCodeList = MachineCode.ToList();

                        var items = reader.Read<ADM_M022_P_ESSEM>().ToList();
                        MC.ItemList = items.ToList();

                        var ild = reader.Read<ZADM_M007_P>().ToList();
                        MC.ILD = ild.ToList();

                        var mod = reader.Read<ZADM_M009_P>().ToList();
                        MC.Models = mod.ToList();

                        var PartyData = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyMaster = PartyData.ToList();

                        var ink = reader.Read<ZADM_M006_P>().ToList();
                        MC.INK = ink.ToList();

                        var defects = reader.Read<ZADM_M016_P>().ToList();
                        MC.DefectList = defects.ToList();

                        var parameters = reader.Read<ENG_T003_P>().ToList();
                        MC.ParameterMaster = parameters.ToList();

                        var Sono = reader.Read<SEL_T001_P>().ToList();
                        MC.SalesOrderData = Sono.ToList();

                        var sample = reader.Read<ECRM_T001_A_P>().ToList();
                        MC.SampleData = sample.ToList();

                        var WTMachine = reader.Read<ZADM_M013_P>().ToList();
                        MC.WTMachineData = WTMachine.ToList();

                        var Item = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemData = Item.ToList();

                        var shifts = reader.Read<ADM_M042_P>().ToList();
                        MC.Shift = shifts.ToList();

                        var emp = reader.Read<ADM_M024_P>().ToList();
                        MC.EmpList = emp.ToList();

                        var testtype = reader.Read<ECRM_T003_C_P>().ToList();
                        MC.TestType = testtype.ToList();

                        var RefDoctype = reader.Read<SYS_M013_P>().ToList();
                        MC.RefDocType = RefDoctype.ToList();

                        var TipTypedata = reader.Read<ZADM_M007_P>().ToList();
                        MC.TipTypeData = TipTypedata.ToList();

                        var BallMake = reader.Read<ADM_M032_P>().ToList();
                        MC.BallMakeData = BallMake.ToList();

                        var WireMake = reader.Read<ADM_M032_P1>().ToList();
                        MC.WireMakeData = WireMake.ToList();

                        var BallSize = reader.Read<ZADM_M001_P>().ToList();
                        MC.BallSizeData = BallSize.ToList();

                        var WireSize = reader.Read<ZADM_M003_P>().ToList();
                        MC.WireSizeData = WireSize.ToList();

                        var InkData = reader.Read<ZADM_M006_P>().ToList();
                        MC.InkMaster = InkData.ToList();

                        var DocType = reader.Read<SYS_M013_P>().ToList();
                        MC.DocTypeData = DocType.ToList();

                        var UnitData = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UnitMaster = UnitData.ToList();

                        var Barcode = reader.Read<PPC_T003_Batch>().ToList();
                        MC.BatchDetails = Barcode.ToList();

                        var t_statusData = reader.Read<ADM_M0013>().ToList();
                        MC.t_statusList = t_statusData.ToList();

                        var Grade = reader.Read<ADM_M030_P>().ToList();
                        MC.GradeList = Grade.ToList();

                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var MasterData = reader.Read<ECRM_T003_A_New>().ToList();
                        MC.MasterEntity = MasterData.ToList();

                        var ItemData = reader.Read<ECRM_T003_B_New>().ToList();
                        MC.ItemEntity = ItemData.ToList();

                        var DefectData = reader.Read<ECRM_T003_D_New>().ToList();
                        MC.DefectEntity = DefectData.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.AttachmentData = Attachment.ToList();

                        var Sodetails = reader.Read<PPC_T003_Batch>().ToList();
                        MC.SODetails = Sodetails.ToList();
                    }
                    else if (RequestOption == "LoadMachineNo")
                    {
                        var MasterData = reader.Read<ECRM_T003_A_New>().ToList();
                        MC.MasterEntity = MasterData.ToList();
                    }
                    else if (RequestOption == "LoadFromDateToDate")
                    {
                        var documentDataFlipGrid = reader.Read<ECRM_T003_AFlip>().ToList();
                        MC.DocumentDataFlipGrid = documentDataFlipGrid.ToList();
                    }

                    else if (RequestOption == "RescanBarcode")
                    {
                        var rescanbarcode = reader.Read<ECRM_T003_A_New>().ToList();
                        MC.RescanBarcode = rescanbarcode.ToList();

                        var sodetails = reader.Read<PPC_T003_Batch>().ToList();
                        MC.SODetails = sodetails.ToList();
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
        public class MultipleContext_ECRM_T003
        {
            public List<ECRM_T003_AFlip> DocumentDataFlipGrid { get; set; }// BF data
            public List<ZADM_M013_P> MachineCodeList { get; set; }//Machine details 
            public List<ADM_M022_P_ESSEM> ItemList { get; set; }//Item Master  
            public List<ZADM_M007_P> ILD { get; set; }//ILD Master
            public List<ZADM_M009_P> Models { get; set; }//Model Master
            public List<ZADM_M006_P> INK { get; set; }//Ink Master 
            public List<ZADM_M016_P> DefectList { get; set; }// Defect Master
            public List<ADM_M042_P> Shift { get; set; }// Shift Master           
            public List<ADM_M024_P> EmpList { get; set; } // Employee Master
            public List<ECRM_T003_C_P> TestType { get; set; } // Test TYpe master
            public List<PPC_T003_Batch> BatchDetails { get; set; }
            public List<ECRM_T003_A_New> MasterEntity { get; set; }// Master data
            public List<ECRM_T003_B_New> ItemEntity { get; set; }  // Load Item Data
            public List<ECRM_T003_D_New> DefectEntity { get; set; } //Load Defect Data
            public List<ADM_M028_P> PartyMaster { get; set; }// Load Party Data
            public List<ENG_T003_P> ParameterMaster { get; set; } // Load Parameter data
            public List<SEL_T001_P> SalesOrderData { get; set; } //sales order data
            public List<ECRM_T001_A_P> SampleData { get; set; } //Load Sample Analysis Data
            public List<ZADM_M013_P> WTMachineData { get; set; } // Load Writing Test Machine Data
            public List<ADM_M022_P> ItemData { get; set; } // Load  Items(papers) Data 
            public List<SYS_M013_P> RefDocType { get; set; } // Load Ref Doc Type Data
            public List<COM_T003> AttachmentData { get; set; } //Load Attachment Data
            public List<ZADM_M007_P> TipTypeData { get; set; } // Load Tip type Data
            public List<ADM_M032_P> BallMakeData { get; set; } // Load Ball make Data
            public List<ZADM_M001_P> BallSizeData { get; set; } // Load Ball Size Data
            public List<ZADM_M003_P> WireSizeData { get; set; } // Load Wire Size Data
            public List<ZADM_M006_P> InkMaster { get; set; } //Load Ink Master
            public List<SYS_M013_P> DocTypeData { get; set; } // Load Doc Type Data
            public List<ADM_M032_P1> WireMakeData { get; set; }// Load Wire Make Data
            public List<SYS_M002> DocTypeInfo { get; set; }
            public List<ECRM_T003_A_New> RescanBarcode { get; set; }
            public List<ADM_M038_B_P> UnitMaster { get; set; }
            public List<PPC_T003_Batch> SODetails { get; set; }
            public List<ADM_M0013> t_statusList { get; set; }
            public List<ADM_M030_P> GradeList { get; set; }
        }
    }
}
