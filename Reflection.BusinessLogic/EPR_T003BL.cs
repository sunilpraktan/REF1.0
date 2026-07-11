
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
using Dapper;
using Reflection.EF.Production.ReportEntityProduction;

namespace Reflection.BusinessLogic
{
    public class EPR_T003BL : ReflectionBusinessLogic
    {
               
        private static string connectionString;
        EPR_T003_A MasterEntity = new EPR_T003_A();

        public EPR_T003BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public EPR_T003BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MultipleContext_EPR_T003 MC = new MultipleContext_EPR_T003();

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003Insert", new { @Request = Request }, commandTimeout: 300, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<EPR_T003_A>().ToList();
                    List<EPR_T003_A> Masterlist = MasterData.ToList();

                    MasterEntity = Masterlist[0];
                    
                   
                    var DetailsData = reader.Read<EPR_T003_B>().ToList();
                    MC.LabelGeneratedEntity = DetailsData.ToList();

                    MasterEntity.XmlDataDocument_EPR_T003_B = ObjectSerializationService.ObjectToXML(MC.LabelGeneratedEntity);
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
        public string Insert2(string Request)
        {
            try
            {
                MultipleContext_EPR_T003 MC = new MultipleContext_EPR_T003();

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003Insert2", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<EPR_T003_A>().ToList();
                    List<EPR_T003_A> Masterlist = MasterData.ToList();
                    MasterEntity = Masterlist[0];
                    var DetailsData = reader.Read<EPR_T003_B>().ToList();
                    MC.LabelGeneratedEntity = DetailsData.ToList();

                    MasterEntity.XmlDataDocument_EPR_T003_B = ObjectSerializationService.ObjectToXML(MC.LabelGeneratedEntity);
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
                MultipleContext_EPR_T003 MC = new MultipleContext_EPR_T003();

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<EPR_T003_A>().ToList();
                    List<EPR_T003_A> Masterlist = MasterData.ToList();

                    if(Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    
                    var DetailsData = reader.Read<EPR_T003_B>().ToList();
                    MC.LabelGeneratedEntity = DetailsData.ToList();

                    MasterEntity.XmlDataDocument_EPR_T003_B = ObjectSerializationService.ObjectToXML(MC.LabelGeneratedEntity);
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
        public string Update2(string Request)
        {
            try
            {
                MultipleContext_EPR_T003 MC = new MultipleContext_EPR_T003();

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003Update2", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<EPR_T003_A>().ToList();
                    List<EPR_T003_A> Masterlist = MasterData.ToList();

                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var DetailsData = reader.Read<EPR_T003_B>().ToList();
                    MC.LabelGeneratedEntity = DetailsData.ToList();

                    MasterEntity.XmlDataDocument_EPR_T003_B = ObjectSerializationService.ObjectToXML(MC.LabelGeneratedEntity);
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

        public string Delete(int Request)
        {
            try
            {
                int intOut = 0;//dbContext.EPR_T003Delete(Request);
                return intOut.ToString();
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
            MultipleContext_EPR_T003 MC = new MultipleContext_EPR_T003();
            string QueryOption = Request.Split('!')[0];
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003LoadAll", new { @Request = Request, @strvalue = RequestOption }, commandType: CommandType.StoredProcedure, commandTimeout: 600);

                    if (QueryOption == "LoadInitialData")
                    {

                        var custprodname = reader.Read<ZADM_M020_P>().ToList();
                        MC.CustProdNameList = custprodname.ToList();

                        var descgoods = reader.Read<ADM_M020_P>().ToList();
                        MC.DescGoodsList = descgoods.ToList();                       

                        var itemlist = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList = itemlist.ToList();

                        var inklist = reader.Read<ZADM_M006_P>().ToList();
                        MC.InkList = inklist.ToList();

                        var ildlist = reader.Read<ZADM_M007_P>().ToList();
                        MC.IidList = ildlist.ToList();

                        var MachineListTemp = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineList = MachineListTemp.ToList();

                        var settinglist = reader.Read<EPR_T003_S>().ToList();
                        MC.SettingsList = settinglist.ToList();

                        if (RequestOption == "LC" || RequestOption == "EC")
                        {
                            var smallcarton = reader.Read<EPR_T003_A>().ToList();
                            MC.SmallCartonList = smallcarton.ToList();
                        }
                        else
                        {
                            var labelgenerated = reader.Read<EPR_T002_Flip>().ToList();
                            MC.LabelGeneratedList = labelgenerated.ToList();
                        }

                    }
                    else if (QueryOption == "LoadSmallCartons")
                    {
                        var backflip = reader.Read<EPR_T003_A>().ToList();
                        MC.MasterEntityList = backflip.ToList();

                        if (RequestOption == "LC" || RequestOption == "EC")
                        {
                            var localexport = reader.Read<RptLocalExportCarton>().ToList();
                            MC.RptLocalExportCartonList = localexport.ToList();

                            var batchdetails = reader.Read<RptCartonBatchDetails>().ToList();
                            MC.RptCartonBatchDetailsList = batchdetails.ToList();
                        }
                        else
                        {
                            var report = reader.Read<RptSmallCarton>().ToList();
                            MC.RptSmallCartonList = report.ToList();
                        }
                    }
                }
                return ObjectSerializationService<MultipleContext_EPR_T003>.ObjectToStream(MC);
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
            MultipleContext_EPR_T003 MC = new MultipleContext_EPR_T003();
            string RequestOption = RequestValue.Split('!')[0];
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003LoadAll", new { @Request = RequestValue, @strvalue = strValue }, commandType: CommandType.StoredProcedure, commandTimeout:600);

                    if (RequestOption == "LoadInitialData")
                    {
                        var custprodname = reader.Read<ZADM_M020_P>().ToList();
                        MC.CustProdNameList = custprodname.ToList();

                        var descgoods = reader.Read<ADM_M020_P>().ToList();
                        MC.DescGoodsList = descgoods.ToList();              
                      
                        var itemlist = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList = itemlist.ToList();

                        var inklist = reader.Read<ZADM_M006_P>().ToList();
                        MC.InkList = inklist.ToList();

                        var ildlist = reader.Read<ZADM_M007_P>().ToList();
                        MC.IidList = ildlist.ToList();

                        var MachineListTemp = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineList = MachineListTemp.ToList();

                        var settinglist = reader.Read<EPR_T003_S>().ToList();
                        MC.SettingsList = settinglist.ToList();

                        if (strValue == "LC" || strValue == "EC")
                        {
                            var smallcarton = reader.Read<EPR_T003_A>().ToList();
                            MC.SmallCartonList = smallcarton.ToList();
                        }
                        else
                        {
                            var labelgenerated = reader.Read<EPR_T002_Flip>().ToList();
                            MC.LabelGeneratedList = labelgenerated.ToList();
                        }

                    }
                    else if(RequestOption == "LoadInitialDataSampleCarton")
                    {
                        var itemmaster = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList2 = itemmaster.ToList();

                        var inkmaster = reader.Read<ZADM_M006_P>().ToList();
                        MC.InkList2 = inkmaster.ToList();

                        var ildmaster = reader.Read<ZADM_M007_P>().ToList();
                        MC.IidList2 = ildmaster.ToList();

                        var wiremake = reader.Read<ADM_M032_P>().ToList();
                        MC.WireMakeList = wiremake.ToList();

                        var ballmake = reader.Read<ADM_M032_P>().ToList();
                        MC.BallMakeList = ballmake.ToList();

                        var unitlist = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UnitList = unitlist.ToList();

                        var packingunit = reader.Read<ZADM_M017_P>().ToList();
                        MC.PackingUnitList = packingunit.ToList();

                        var settinglist = reader.Read<EPR_T003_S>().ToList();
                        MC.SettingsList = settinglist.ToList();

                        var itemlist = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList = itemlist.ToList();

                        var inklist = reader.Read<ZADM_M006_P>().ToList();
                        MC.InkList = inklist.ToList();

                        var ildlist = reader.Read<ZADM_M007_P>().ToList();
                        MC.IidList = ildlist.ToList();

                        var batchlist = reader.Read<EPR_T002_Flip>().ToList();
                        MC.LabelGeneratedList = batchlist.ToList();

                    }
                    else if (RequestOption == "LoadSmallCartons")  // Common Name used for all types of carton
                    {
                        var backflip = reader.Read<EPR_T003_A>().ToList();
                        MC.MasterEntityList = backflip.ToList();

                        if (strValue == "LC" || strValue == "EC")
                        {
                            var localexport = reader.Read<RptLocalExportCarton>().ToList();
                            MC.RptLocalExportCartonList = localexport.ToList();
                        }
                        else
                        {
                            var report = reader.Read<RptSmallCarton>().ToList();
                            MC.RptSmallCartonList = report.ToList();
                        }

                    }
                    else if (RequestOption == "SmallCartonBatchDetailsReport")
                    {
                        var report = reader.Read<RptSmallCarton>().ToList();
                        MC.RptSmallCartonList = report.ToList();
                    }
                    else if (RequestOption == "LocalExportBatchDetailsReport")
                    {
                        var batchdetails = reader.Read<RptCartonBatchDetails>().ToList();
                        MC.RptCartonBatchDetailsList = batchdetails.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNo")
                    {
                        var detailtemp = reader.Read<EPR_T003_B>().ToList();
                        MC.LabelGeneratedEntity = detailtemp.ToList();
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
        public string GetData2(string RequestValue, string strType, int intValue, string strValue)
        {
            MultipleContext_EPR_T003 MC = new MultipleContext_EPR_T003();
            string RequestOption = RequestValue.Split('!')[0];
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003LoadAll2", new { @Request = RequestValue, @strvalue = strValue }, commandType: CommandType.StoredProcedure, commandTimeout: 600);

                    if (RequestOption == "LoadInitialData")
                    {
                        var custprodname = reader.Read<ZADM_M020_P>().ToList();
                        MC.CustProdNameList = custprodname.ToList();

                        var descgoods = reader.Read<ADM_M020_P>().ToList();
                        MC.DescGoodsList = descgoods.ToList();

                        var itemlist = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList = itemlist.ToList();

                        var inklist = reader.Read<ZADM_M006_P>().ToList();
                        MC.InkList = inklist.ToList();

                        var ildlist = reader.Read<ZADM_M007_P>().ToList();
                        MC.IidList = ildlist.ToList();

                        var MachineListTemp = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineList = MachineListTemp.ToList();

                        var Emplisttemp = reader.Read<ADM_M024_P>().ToList();
                        MC.EmployeeList = Emplisttemp.ToList();

                        var settinglist = reader.Read<EPR_T003_S>().ToList();
                        MC.SettingsList = settinglist.ToList();

                        var labelgenerated = reader.Read<EPR_T002_Flip>().ToList();
                        MC.LabelGeneratedList = labelgenerated.ToList();

                        var gradetemp = reader.Read<ADM_M030_P>().ToList();
                        MC.GradeList = gradetemp.ToList();
                    }
                    else if (RequestOption == "LoadSmallCartons")   // Common Name used for all types of carton
                    {
                        var backflip = reader.Read<EPR_T003_A>().ToList();
                        MC.MasterEntityList = backflip.ToList();

                        //var localexport = reader.Read<RptLocalExportCarton>().ToList();
                        //MC.RptLocalExportCartonList = localexport.ToList();

                        var RptLabelGenListTemp = reader.Read<RptLabelGen>().ToList();
                        MC.RptLabelGenList = RptLabelGenListTemp.ToList();

                        var report = reader.Read<RptSmallCarton>().ToList();
                        MC.RptSmallCartonList = report.ToList();

                    }
                    else if (RequestOption == "LoadDocumentByDocumentNo")
                    {
                        var detailtemp = reader.Read<EPR_T003_B>().ToList();
                        MC.LabelGeneratedEntity = detailtemp.ToList();
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
        public string GetData_SearchLabel(string RequestValue, string strType, int intValue, string strValue)
        {
            MultipleContext_SearchLabel MCS = new MultipleContext_SearchLabel();
            string RequestOption = RequestValue.Split('!')[0];
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T002_SearchLabel", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure, commandTimeout: 600);

                    if (RequestOption == "Label")
                    {
                        #region For Label Logic
                        var labeldata = reader.Read<EPR_T002_Flip>().ToList();
                        MCS.LabelEntity = labeldata.ToList();

                        //var SettingsList = reader.Read<EPR_T003_S>().ToList();
                        //MCS.SettingsList = SettingsList.ToList();

                        if (MCS.LabelEntity.Count > 0)
                        {
                            if (MCS.LabelEntity[0].doc_type == "ML")
                            {
                                var mergedata = reader.Read<EPR_T002_B>().ToList();
                                MCS.MergeList = mergedata.ToList();
                            }
                            else if (MCS.LabelEntity[0].label_complete_stat == false)
                            {
                                var mergedata = reader.Read<EPR_T002_B>().ToList();
                                MCS.MergeList = mergedata.ToList();
                            }

                            if (MCS.LabelEntity[0].carton_cons_stat == true)
                            {
                                var smallcartondata = reader.Read<EPR_T003_A_Flip>().ToList();
                                MCS.SmallCartonEntity = smallcartondata.ToList();

                                if (MCS.SmallCartonEntity.Count > 0)
                                {
                                    if (MCS.SmallCartonEntity[0].carton_used_Flg == true)
                                    {
                                        var outercartondata = reader.Read<EPR_T003_A_Flip>().ToList();
                                        MCS.OuterCartonEntity = outercartondata.ToList();

                                        if (MCS.OuterCartonEntity.Count > 0)
                                        {
                                            if (MCS.OuterCartonEntity[0].carton_used_Flg == true)
                                            {
                                                var dispatchdata = reader.Read<LOG_T001_A_P>().ToList();
                                                MCS.DispatchEntity = dispatchdata.ToList();

                                                if (MCS.DispatchEntity.Count > 0)
                                                {
                                                    if (MCS.DispatchEntity[0].invoicemade == true)
                                                    {
                                                        var invoicedata = reader.Read<SEL_T003_P>().ToList();
                                                        MCS.InvoiceEntity = invoicedata.ToList();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    else if (RequestOption == "Carton")
                    {
                        var smallcartondata = reader.Read<EPR_T003_A_Flip>().ToList();
                        MCS.SmallCartonEntity = smallcartondata.ToList();

                        var smallcartondetails = reader.Read<EPR_T003_B>().ToList();
                        MCS.SmallCartonDetails = smallcartondetails.ToList();

                        //var SettingsList = reader.Read<EPR_T003_S>().ToList();
                        //MCS.SettingsList = SettingsList.ToList();

                        if (MCS.SmallCartonEntity.Count > 0)
                        {
                            #region Small Carton Wise Search Logic

                            if (MCS.SmallCartonEntity[0].doc_type == "SC" && MCS.SmallCartonEntity[0].carton_used_Flg == true)
                            {
                                var outercartondata = reader.Read<EPR_T003_A_Flip>().ToList();
                                MCS.OuterCartonEntity = outercartondata.ToList();

                                if (MCS.OuterCartonEntity.Count > 0)
                                {
                                    if (MCS.OuterCartonEntity[0].carton_used_Flg == true)
                                    {
                                        var dispatchdata = reader.Read<LOG_T001_A_P>().ToList();
                                        MCS.DispatchEntity = dispatchdata.ToList();

                                        if (MCS.DispatchEntity.Count > 0)
                                        {
                                            if (MCS.DispatchEntity[0].invoicemade == true)
                                            {
                                                var invoicedata = reader.Read<SEL_T003_P>().ToList();
                                                MCS.InvoiceEntity = invoicedata.ToList();
                                            }
                                        }
                                    }
                                }
                            }

                            #endregion

                            #region Outer Carton Wise Search Logic

                            else if (MCS.SmallCartonEntity[0].carton_used_Flg == true)
                            {
                                if (MCS.SmallCartonEntity[0].carton_used_Flg == true)
                                {
                                    var dispatchdata = reader.Read<LOG_T001_A_P>().ToList();
                                    MCS.DispatchEntity = dispatchdata.ToList();

                                    if (MCS.DispatchEntity.Count > 0)
                                    {
                                        if (MCS.DispatchEntity[0].invoicemade == true)
                                        {
                                            var invoicedata = reader.Read<SEL_T003_P>().ToList();
                                            MCS.InvoiceEntity = invoicedata.ToList();
                                        }
                                    }
                                }
                            }

                            #endregion
                        }
                    }           

                }
                strData = ObjectSerializationService.ObjectToXML(MCS);

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

    public class MultipleContext_EPR_T003
    {
        public List<ZADM_M020_P> CustProdNameList { get; set; }
        public List<ADM_M020_P> DescGoodsList { get; set; }
        public List<EPR_T002_Flip> LabelGeneratedList { get; set; }
        public List<EPR_T003_B> LabelGeneratedEntity { get; set; }
        public List<ADM_M022_P> ItemList { get; set; }
        public List<ZADM_M006_P> InkList { get; set; }
        public List<ZADM_M007_P> IidList { get; set; }
        public List<ADM_M022_P> ItemList2 { get; set; }
        public List<ZADM_M006_P> InkList2 { get; set; }
        public List<ZADM_M007_P> IidList2 { get; set; }
        public List<ADM_M032_P> WireMakeList { get; set; }
        public List<ADM_M032_P> BallMakeList { get; set; }
        public List<ZADM_M017_P> PackingUnitList { get; set; }
        public List<ADM_M038_B_P> UnitList { get; set; }
        public List<EPR_T003_S> SettingsList { get; set; }
        public List<EPR_T003_A> MasterEntityList { get; set; }
        public List<EPR_T003_A> SmallCartonList { get; set; }
        public List<EPR_T003_B> SmallCartonEntity { get; set; }
        public List<RptSmallCarton> RptSmallCartonList { get; set; }
        public List<RptLocalExportCarton> RptLocalExportCartonList { get; set; }      //Label of LOCal/Export Small Sticker
        public List<RptExportLabel> RptExportLabelList { get; set; }            // Big Sticker List
        public List<RptCartonPacking> RptCartonPackingList { get; set; }        //Palet/Batch details Report List
        public List<RptCartonBatchDetails> RptCartonBatchDetailsList { get; set; }
        public List<ZADM_M013_P> MachineList { get; set; }
        public List<ADM_M024_P> EmployeeList { get; set; }
        public List<RptLabelGen> RptLabelGenList { get; set; }
        public List<ADM_M030_P> GradeList { get; set; }

    }

    public class MultipleContext_SearchLabel
    {
        public string doc_type { get; set; }
        public List<EPR_T002_Flip> LabelEntity { get; set; }
        public List<EPR_T002_B> MergeList { get; set; }
        public List<EPR_T003_A_Flip> SmallCartonEntity { get; set; }
        public List<EPR_T003_B> SmallCartonDetails { get; set; }
        public List<EPR_T003_A_Flip> OuterCartonEntity { get; set; }
        public List<LOG_T001_A_P> DispatchEntity { get; set; }
        public List<SEL_T003_P> InvoiceEntity { get; set; }
        //public List<EPR_T003_S> SettingsList { get; set; }

    }
}
