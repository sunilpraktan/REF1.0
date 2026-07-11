
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;
using Reflection.EF.Production;
using Reflection.EF.Production.ReportEntityProduction;
using Dapper;
using Reflection.EF.Admin;
using Reflection.EF.HRMS.Production;
using Reflection.EF.ReflectionSystem;

namespace Reflection.BusinessLogic
{
    public class EPR_T002BL : ReflectionBusinessLogic
    {//test

        private static string connectionString;
        EPR_T002 EPR_T002 = new EPR_T002();
        public string MasterEntity;

        public EPR_T002BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public EPR_T002BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            try
            {
                int reader;
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    reader = conn.Execute("EPR_T002Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                }

                string strReturnData = reader.ToString();
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
        public string Insert_MergeLabel(string Request)
        {
            try
            {
                int reader;
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    reader = conn.Execute("EPR_T002_MergeInsert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                }

                string strReturnData = reader.ToString();
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
        public string Update_ProdEntrySearch(string Request)
        {
            try
            {
                int reader;
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    reader = conn.Execute("EPR_T002_D_PESearchUpdate", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                }

                string strReturnData = reader.ToString();
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
        public string Update_Label(string Request)
        {
            try
            {
                int reader;
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    reader = conn.Execute("EPR_T002_LabelUpdate", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                }

                string strReturnData = reader.ToString();
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
        public string Update(string Request)    //Production Entry Flag Update
        {
            try
            {
                int reader;
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    reader = conn.Execute("EPR_T002Update", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                }

                string strReturnData = reader.ToString();
                return strReturnData;

                //Request = (string)ObjectSerializationService.XMLToObject(Request, Request);
                //int reader;
                //using (IDbConnection conn = new SqlConnection(connectionString))
                //{
                //    reader = conn.Execute("EPR_T002Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                //}


                //string strReturnData = reader.ToString();
                //return strReturnData;

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

                string strReturnData = "";
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
        public byte[] GetData(string Request, string RequestOption)
        {
            string QueryOption = Request.Split('!')[0];
            MultipleContext_EPR_T002 MC = new MultipleContext_EPR_T002();
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T002LoadAll", new { @request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (QueryOption == "LoadInitialData")   // For Label Generation
                    {
                        var UnitListTemp = reader.Read<ADM_M038_B_P>().ToList(); // Temp = temporary variable
                        MC.UnitList = UnitListTemp.ToList();

                        var PkgUnitListTemp = reader.Read<ZADM_M017_P>().ToList();
                        MC.PkgUnitList = PkgUnitListTemp.ToList();

                        var CustProdListTemp = reader.Read<ZADM_M020_P>().ToList();
                        MC.CustomerProductList = CustProdListTemp.ToList();

                        var BallMakeTemp = reader.Read<ADM_M032_P>().ToList();
                        MC.BallMakeList = BallMakeTemp.ToList();

                        var WireMakeTemp = reader.Read<ADM_M032_P>().ToList();
                        MC.WireMakeList = WireMakeTemp.ToList();

                        var ShiftListTemp = reader.Read<ADM_M042_P>().ToList();
                        MC.ShiftList = ShiftListTemp.ToList();

                        var PartyListTemp = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyList = PartyListTemp.ToList();

                        var Emplisttemp = reader.Read<ADM_M024_P>().ToList();
                        MC.EmployeeList = Emplisttemp.ToList();

                        var Settinglisttemp = reader.Read<EPR_T002_S>().ToList();
                        MC.SettingsList = Settinglisttemp.ToList();

                        var machinetemp = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineList2 = machinetemp.ToList();

                        var producttemp = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList2 = producttemp.ToList();

                        var MachineListTemp = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineList = MachineListTemp.ToList();

                        var BPkgUnitListTemp = reader.Read<ZADM_M017_P>().ToList();
                        MC.BPkgUnitList = BPkgUnitListTemp.ToList();

                        var ItemListTemp = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList = ItemListTemp.ToList();

                        var InkListTemp = reader.Read<ZADM_M006_P>().ToList();
                        MC.InkList = InkListTemp.ToList();

                        var IldListTemp = reader.Read<ZADM_M007_P>().ToList();
                        MC.IldList = IldListTemp.ToList();

                    }
                    else if (QueryOption == "LoadInitialDataForPE")        //For Production Entry Barcode Scan
                    {
                        var LabelGenBackFlipListTemp = reader.Read<EPR_T002_Flip>().ToList();
                        MC.LabelGenBackFlipList = LabelGenBackFlipListTemp.ToList();

                        var ShiftListTemp = reader.Read<ADM_M042_P>().ToList();
                        MC.ShiftList = ShiftListTemp.ToList();

                        var MachineListTemp = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineList = MachineListTemp.ToList();

                        var BPkgUnitListTemp = reader.Read<ZADM_M017_P>().ToList();
                        MC.BPkgUnitList = BPkgUnitListTemp.ToList();

                        var ItemListTemp = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList = ItemListTemp.ToList();

                        var InkListTemp = reader.Read<ZADM_M006_P>().ToList();
                        MC.InkList = InkListTemp.ToList();

                        var IldListTemp = reader.Read<ZADM_M007_P>().ToList();
                        MC.IldList = IldListTemp.ToList();
                    }
                    else if (QueryOption == "LoadInitialDataForMergeLabel")
                    {
                        var ItemListTemp = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList = ItemListTemp.ToList();

                        var InkListTemp = reader.Read<ZADM_M006_P>().ToList();
                        MC.InkList = InkListTemp.ToList();

                        var IldListTemp = reader.Read<ZADM_M007_P>().ToList();
                        MC.IldList = IldListTemp.ToList();

                        var MachineListTemp = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineList = MachineListTemp.ToList();

                        var PkgUnitListTemp = reader.Read<ZADM_M017_P>().ToList();
                        MC.PkgUnitList = PkgUnitListTemp.ToList();

                        var PartyListTemp = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyList = PartyListTemp.ToList();

                        var Emplisttemp = reader.Read<ADM_M024_P>().ToList();
                        MC.EmployeeList = Emplisttemp.ToList();

                        var Settinglisttemp = reader.Read<EPR_T002_S>().ToList();
                        MC.SettingsList = Settinglisttemp.ToList();

                        var Shifttemp = reader.Read<ADM_M042_P>().ToList();
                        MC.ShiftList = Shifttemp.ToList();

                        var BPkgUnitListTemp = reader.Read<ZADM_M017_P>().ToList();
                        MC.BPkgUnitList = BPkgUnitListTemp.ToList();
                    }
                    else if (QueryOption == "LoadIldDetails")
                    {
                        var LabelGenerationFromILDTemp = reader.Read<EPR_T002>().ToList();
                        MC.LabelGenerationFromILD = LabelGenerationFromILDTemp.ToList();

                    }
                    else if (QueryOption == "LoadIldDetailsForPE")
                    {
                        var LabelGenerationFromILDTemp = reader.Read<EPR_T002>().ToList();
                        MC.LabelGenerationFromILD = LabelGenerationFromILDTemp.ToList();
                    }
                    else if (QueryOption == "LoadLGDetails")
                    {
                        var LabelGenBackFlipListTemp = reader.Read<EPR_T002_Flip>().ToList();
                        MC.LabelGenBackFlipList = LabelGenBackFlipListTemp.ToList();

                        var RptLabelGenListTemp = reader.Read<RptLabelGen>().ToList();
                        MC.RptLabelGenList = RptLabelGenListTemp.ToList();
                    }
                    else if (QueryOption == "LoadProdCounterEntry")
                    {
                        var ProductionCounterEntryListTemp = reader.Read<EPR_T002>().ToList();
                        MC.ProductionCounterEntryList = ProductionCounterEntryListTemp.ToList();
                    }
                    else if (QueryOption == "LoadForMergingLabel")
                    {
                        var IncompleteLabelListTemp = reader.Read<EPR_T002_Flip>().ToList();
                        MC.IncompleteLabelList = IncompleteLabelListTemp.ToList();
                    }
                    else if (QueryOption == "LoadInitialDataForLabelUpdate")
                    {
                        var InkListTemp = reader.Read<ZADM_M006_P>().ToList();
                        MC.InkList = InkListTemp.ToList();

                        var IldListTemp = reader.Read<ZADM_M007_P>().ToList();
                        MC.IldList = IldListTemp.ToList();

                    }
                    else if (QueryOption == "LoadLabelGenMaster")
                    {
                        var LabelGenerationListTemp = reader.Read<EPR_T002>().ToList();
                        MC.LabelGenerationList = LabelGenerationListTemp.ToList();
                    }


                }
                return ObjectSerializationService<MultipleContext_EPR_T002>.ObjectToStream(MC);

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
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            MultipleContext_EPR_T002 MC = new MultipleContext_EPR_T002();
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T002LoadAll", new { @request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")   // For Label Generation
                    {
                        var UnitListTemp = reader.Read<ADM_M038_B_P>().ToList(); // Temp = temporary variable
                        MC.UnitList = UnitListTemp.ToList();

                        var PkgUnitListTemp = reader.Read<ZADM_M017_P>().ToList();
                        MC.PkgUnitList = PkgUnitListTemp.ToList();

                        var CustProdListTemp = reader.Read<ZADM_M020_P>().ToList();
                        MC.CustomerProductList = CustProdListTemp.ToList();

                        var InkListTemp = reader.Read<ZADM_M006_P>().ToList();
                        MC.InkList = InkListTemp.ToList();

                        var IldListTemp = reader.Read<ZADM_M007_P>().ToList();
                        MC.IldList = IldListTemp.ToList();

                        var BallMakeTemp = reader.Read<ADM_M032_P>().ToList();
                        MC.BallMakeList = BallMakeTemp.ToList();

                        var WireMakeTemp = reader.Read<ADM_M032_P>().ToList();
                        MC.WireMakeList = WireMakeTemp.ToList();

                        var ShiftListTemp = reader.Read<ADM_M042_P>().ToList();
                        MC.ShiftList = ShiftListTemp.ToList();

                        var PartyListTemp = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyList = PartyListTemp.ToList();

                        var Emplisttemp = reader.Read<ADM_M024_P>().ToList();
                        MC.EmployeeList = Emplisttemp.ToList();

                        var inchargetemp = reader.Read<ADM_M024_P>().ToList();
                        MC.SInchargeList = inchargetemp.ToList();

                        var Settinglisttemp = reader.Read<EPR_T002_S>().ToList();
                        MC.SettingsList = Settinglisttemp.ToList();

                        var machinetemp = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineList2 = machinetemp.ToList();

                        var producttemp = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList2 = producttemp.ToList();

                        var gradetemp = reader.Read<ADM_M030_P>().ToList();
                        MC.GradeList = gradetemp.ToList();

                        var bdrtemp = reader.Read<PMT_M001_P>().ToList();
                        MC.BreakdownReasonList = bdrtemp.ToList();

                        var MachineListTemp = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineList = MachineListTemp.ToList();

                        var BPkgUnitListTemp = reader.Read<ZADM_M017_P>().ToList();
                        MC.BPkgUnitList = BPkgUnitListTemp.ToList();

                        var ItemListTemp = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList = ItemListTemp.ToList();

                        var BInkListTemp = reader.Read<ZADM_M006_P>().ToList();
                        MC.BInkList = BInkListTemp.ToList();

                        var BIldListTemp = reader.Read<ZADM_M007_P>().ToList();
                        MC.BIldList = BIldListTemp.ToList();

                        var Report = reader.Read<RptUltrasonicLabelGen>().ToList();
                        MC.RptUltraLabelList = Report.ToList();

                        var Remark = reader.Read<ADM_M066>().ToList();
                        MC.Remarks = Remark.ToList();

                        var MachineListMaster = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineListMaster = MachineListMaster.ToList();


                    }
                    else if (RequestOption == "LoadInitialDataForPE")        //For Production Entry Barcode Scan
                    {
                        var LabelGenBackFlipListTemp = reader.Read<EPR_T002_Flip>().ToList();
                        MC.LabelGenBackFlipList = LabelGenBackFlipListTemp.ToList();

                        var ShiftListTemp = reader.Read<ADM_M042_P>().ToList();
                        MC.ShiftList = ShiftListTemp.ToList();

                        var MachineListTemp = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineList = MachineListTemp.ToList();

                        var BPkgUnitListTemp = reader.Read<ZADM_M017_P>().ToList();
                        MC.BPkgUnitList = BPkgUnitListTemp.ToList();

                        var ItemListTemp = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList = ItemListTemp.ToList();

                        var InkListTemp = reader.Read<ZADM_M006_P>().ToList();
                        MC.InkList = InkListTemp.ToList();

                        var IldListTemp = reader.Read<ZADM_M007_P>().ToList();
                        MC.IldList = IldListTemp.ToList();

                        var Settinglisttemp = reader.Read<EPR_T002_S>().ToList();
                        MC.SettingsList = Settinglisttemp.ToList();
                    }
                    else if (RequestOption == "LoadInitialDataForMergeLabel")
                    {
                        var ItemListTemp = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList = ItemListTemp.ToList();

                        var InkListTemp = reader.Read<ZADM_M006_P>().ToList();
                        MC.InkList = InkListTemp.ToList();

                        var IldListTemp = reader.Read<ZADM_M007_P>().ToList();
                        MC.IldList = IldListTemp.ToList();

                        var MachineListTemp = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineList = MachineListTemp.ToList();

                        var PkgUnitListTemp = reader.Read<ZADM_M017_P>().ToList();
                        MC.PkgUnitList = PkgUnitListTemp.ToList();

                        var PartyListTemp = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyList = PartyListTemp.ToList();

                        var Emplisttemp = reader.Read<ADM_M024_P>().ToList();
                        MC.EmployeeList = Emplisttemp.ToList();

                        var Settinglisttemp = reader.Read<EPR_T002_S>().ToList();
                        MC.SettingsList = Settinglisttemp.ToList();

                        var Shifttemp = reader.Read<ADM_M042_P>().ToList();
                        MC.ShiftList = Shifttemp.ToList();

                        var BPkgUnitListTemp = reader.Read<ZADM_M017_P>().ToList();
                        MC.BPkgUnitList = BPkgUnitListTemp.ToList();

                        var gradetemp = reader.Read<ADM_M030_P>().ToList();
                        MC.GradeList = gradetemp.ToList();

                        var CustProdListTemp = reader.Read<ZADM_M020_P>().ToList();
                        MC.CustomerProductList = CustProdListTemp.ToList();
                    }
                    else if (RequestOption == "LoadIldDetails")
                    {
                        var LabelGenerationFromILDTemp = reader.Read<EPR_T002>().ToList();
                        MC.LabelGenerationFromILD = LabelGenerationFromILDTemp.ToList();

                        var PdiDupBarcode = reader.Read<ECRM_T004_P>().ToList();
                        MC.PDIDupBarcodeList = PdiDupBarcode.ToList();
                    }
                    else if (RequestOption == "LoadIldDetailsForPE")
                    {
                        var LabelGenerationFromILDTemp = reader.Read<EPR_T002>().ToList();
                        MC.LabelGenerationFromILD = LabelGenerationFromILDTemp.ToList();
                    }
                    else if (RequestOption == "LoadLGDetails")
                    {
                        var LabelGenBackFlipListTemp = reader.Read<EPR_T002_Flip>().ToList();
                        MC.LabelGenBackFlipList = LabelGenBackFlipListTemp.ToList();

                        var RptLabelGenListTemp = reader.Read<RptLabelGen>().ToList();
                        MC.RptLabelGenList = RptLabelGenListTemp.ToList();
                    }
                    else if (RequestOption == "LoadProdCounterEntry")
                    {
                        var ProductionCounterEntryListTemp = reader.Read<EPR_T002>().ToList();
                        MC.ProductionCounterEntryList = ProductionCounterEntryListTemp.ToList();
                    }
                    else if (RequestOption == "LoadForMergingLabel")
                    {
                        var IncompleteLabelListTemp = reader.Read<EPR_T002_Flip>().ToList();
                        MC.IncompleteLabelList = IncompleteLabelListTemp.ToList();
                    }
                    else if (RequestOption == "LoadInitialDataForLabelUpdate")
                    {
                        var InkListTemp = reader.Read<ZADM_M006_P>().ToList();
                        MC.InkList = InkListTemp.ToList();

                        var IldListTemp = reader.Read<ZADM_M007_P>().ToList();
                        MC.IldList = IldListTemp.ToList();

                        var CustProdListTemp = reader.Read<ZADM_M020_P>().ToList();
                        MC.CustomerProductList = CustProdListTemp.ToList();

                        var BallMakeTemp = reader.Read<ADM_M032_P>().ToList();
                        MC.BallMakeList = BallMakeTemp.ToList();

                        var WireMakeTemp = reader.Read<ADM_M032_P>().ToList();
                        MC.WireMakeList = WireMakeTemp.ToList();

                        var MachineTemp = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineList = MachineTemp.ToList();
                    }
                    else if (RequestOption == "LoadLabelGenMaster")
                    {
                        var LabelGenerationListTemp = reader.Read<EPR_T002>().ToList();
                        MC.LabelGenerationList = LabelGenerationListTemp.ToList();
                    }
                    else if (RequestOption == "LoadInitialDataForProductionSearchEntry")
                    {
                        var inktemp = reader.Read<ZADM_M006_P>().ToList();
                        MC.InkList = inktemp.ToList();

                        var ildtemp = reader.Read<ZADM_M007_P>().ToList();
                        MC.IldList = ildtemp.ToList();

                        var MachineListMaster = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineListMaster = MachineListMaster.ToList();
                    }
                    else if (RequestOption == "LoadProductionSearchEntry")
                    {
                        var LabelGenerationListTemp = reader.Read<EPR_T002>().ToList();
                        MC.LabelGenerationList = LabelGenerationListTemp.ToList();
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
    }

    public class MultipleContext_EPR_T002
    {
        public List<ADM_M038_B_P> UnitList { get; set; }
        public List<ZADM_M017_P> PkgUnitList { get; set; }
        public List<ZADM_M020_P> CustomerProductList { get; set; }
        public List<ADM_M032_P> BallMakeList { get; set; }
        public List<ADM_M032_P> WireMakeList { get; set; }
        public List<ADM_M042_P> ShiftList { get; set; }
        public List<ADM_M028_P> PartyList { get; set; }
        public List<ADM_M024_P> EmployeeList { get; set; }
        public List<EPR_T002_S> SettingsList { get; set; }
        public List<ZADM_M013_P> MachineList { get; set; }
        public List<ZADM_M013_P> MachineList2 { get; set; }
        public List<ZADM_M017_P> BPkgUnitList { get; set; }     // B = BackFlip, Need Different List Coz of Diff Data
        public List<ADM_M022_P> ItemList { get; set; }
        public List<ADM_M022_P> ItemList2 { get; set; }
        public List<ZADM_M006_P> InkList { get; set; }
        public List<ZADM_M007_P> IldList { get; set; }
        public List<ZADM_M006_P> BInkList { get; set; }
        public List<ZADM_M007_P> BIldList { get; set; }
        public List<EPR_T002> LabelGenerationFromILD { get; set; }
        public List<EPR_T002> LabelGenerationList { get; set; }
        public List<EPR_T002_Flip> LabelGenBackFlipList { get; set; }   // master detail join
        public List<RptLabelGen> RptLabelGenList { get; set; }
        public List<EPR_T002> ProductionCounterEntryList { get; set; }
        public List<EPR_T002_Flip> IncompleteLabelList { get; set; }
        public List<ADM_M030_P> GradeList { get; set; }
        public List<PMT_M001_P> BreakdownReasonList { get; set; }
        public List<ADM_M024_P> SInchargeList { get; set; }
        public List<ECRM_T004_P> PDIDupBarcodeList { get; set; }
        public List<RptUltrasonicLabelGen> RptUltraLabelList { get; set; }
        public List<ADM_M066> Remarks { get; set; }
        public List<EPR_T001> ProductionOrderList { get; set; }
        public List<OperationList> OperationsList { get; set; }
        public List<PPC_M001> WorkCenterList { get; set; }
        public List<EPR_T002> OrderExecutionList { get; set; }
        public List<SYS_M052> RecordTypeList { get; set; }
        public List<PPC_M003> VarReasonList { get; set; }
        public List<MIS_STD_PPC_1> MIS_STD_PPC_1_LIST { get; set; }
        public List<ZADM_M013_P> MachineListMaster { get; set; }
        public List<ADM_M028_P> Customer { get; set; }
        public List<STD_DOC_TYPE> DOC_TYPE_LIST { get; set; }
        public List<EPR_T002> REWORK_ORDER_LIST { get; set; }
    }
}
