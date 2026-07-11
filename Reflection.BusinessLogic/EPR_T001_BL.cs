using Dapper;
using Reflection.EF;
using Reflection.EF.Communication;
using Reflection.EF.Production;
using Reflection.EF.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF.Admin;
using Reflection.EF.ADM;

// Mayuri
namespace Reflection.BusinessLogic
{
    public class EPR_T001_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        EPR_T001_New MasterEntity = new EPR_T001_New();
        MultipleContext_EPR_T001_Conv MC = new MultipleContext_EPR_T001_Conv();
        public EPR_T001_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public EPR_T001_BL()
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
                    var reader = conn.QueryMultiple("EPR_T001_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<EPR_T001_Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<EPR_T001_New>().ToList();
                    List<EPR_T001_New> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    MasterEntity.XmlDataDocument_EPR_T001_Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
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
                    var reader = conn.QueryMultiple("EPR_T001_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<EPR_T001_Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<EPR_T001_New>().ToList();
                    List<EPR_T001_New> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    MasterEntity.XmlDataDocument_EPR_T001_Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
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
            MultipleContext_EPR_T001_Conv MC = new MultipleContext_EPR_T001_Conv();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                if (RequestOption != "ConversionNoteRpt")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("EPR_T001LoadAllFeedback", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var documentDataFlipGrid = reader.Read<EPR_T001_Flip>().ToList();
                            MC.DocumentDataFlipGrid = documentDataFlipGrid.ToList();

                            var machineList = reader.Read<PPC_M001_P>().ToList();
                            MC.MachineList_CN = machineList.ToList();

                            var productionPlannList = reader.Read<PPC_T004_A_P>().ToList();
                            MC.ProductionPlanningList = productionPlannList.ToList();

                            var ModelList = reader.Read<ZADM_M009_P>().ToList();
                            MC.ModelMasterList = ModelList.ToList();

                            var INKList = reader.Read<ZADM_M006_P>().ToList();
                            MC.INKMasterList = INKList.ToList();

                            var WireList = reader.Read<ADM_M032_P>().ToList();
                            MC.WireMakeList = WireList.ToList();

                            var wireSize = reader.Read<ZADM_M003_P>().ToList();
                            MC.WireSizeList = wireSize.ToList();

                            var partyList = reader.Read<ADM_M028_P>().ToList();
                            MC.PartyList = partyList.ToList();

                            var ILDList = reader.Read<ZADM_M007_P>().ToList();
                            MC.ILDMasterList = ILDList.ToList();

                            var BallMake = reader.Read<ADM_M032_P>().ToList();
                            MC.BallMakeList = BallMake.ToList();

                            var product = reader.Read<ADM_M022_P_ESSEM>().ToList();
                            MC.ItemList = product.ToList();

                            var pkgunit = reader.Read<ZADM_M017_P>().ToList();
                            MC.PkgUnitList = pkgunit.ToList();

                            var DocumentTypesTemp = reader.Read<SYS_M013_P>().ToList();
                            MC.DocumentTypes = DocumentTypesTemp.ToList();

                            var Shift = reader.Read<ADM_M042_P>().ToList();
                            MC.Shift = Shift.ToList();

                        }
                        else if (RequestOption == "LoadPreviousMachine")
                        {
                            var masterEntityPrev = reader.Read<EPR_T001_New>().ToList();
                            MC.MasterEntityPrev = masterEntityPrev.ToList();
                        }
                        else if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var masterEntity = reader.Read<EPR_T001_New>().ToList();
                            MC.MasterEntity = masterEntity.ToList();

                            var masterEntityPrev = reader.Read<EPR_T001_New>().ToList();
                            MC.MasterEntityPrev = masterEntityPrev.ToList();

                            var ApprovalDataVar = reader.Read<ADM_M043_D>().ToList();
                            MC.ApprovalData = ApprovalDataVar.ToList();

                            var Attachment = reader.Read<COM_T003>().ToList();
                            MC.AttachmentData = Attachment.ToList();

                        }
                        else if (RequestOption == "LoadFeedbackRpt")
                        {
                            var feedback = reader.Read<ECRM_T002_AFeedbackRpt>().ToList();
                            MC.RptFeedback = feedback.ToList();
                        }
                        else if (RequestOption == "LoadFeedbackRpt2")
                        {
                            var feedback = reader.Read<ECRM_T002_AFeedbackRpt>().ToList();
                            MC.RptFeedback = feedback.ToList();
                        }
                        else if (RequestOption == "LoadFromDateToDate")
                        {
                            var Loadfromdate = reader.Read<EPR_T001_Flip>().ToList();
                            MC.DocumentDataFlipGrid = Loadfromdate.ToList();
                        }
                        else if (RequestOption == "LoadILD")
                        {
                            var masterEntity = reader.Read<EPR_T001_New>().ToList();
                            MC.MasterEntity = masterEntity.ToList();
                        }
                    }
                }
                else if (RequestOption == "ConversionNoteRpt")
                {
                    RequestValue = RequestValue.Replace("ConversionNoteRpt!@", "");
                    using (IDbConnection conn1 = new SqlConnection(connectionString))
                    {
                        var reader1 = conn1.QueryMultiple("RPT_EPR_T001", new
                        {
                            @request_type = "RPTConversion",
                            @id = 0,
                            @request = RequestValue
                        }, commandType: CommandType.StoredProcedure);

                        var RPTINK = reader1.Read<RPT_EPR_T001>().ToList();
                        MC.RPTINK = RPTINK.ToList();

                        var Rptapproval = reader1.Read<RPT_Approval>().ToList();
                        MC.Rptapproval = Rptapproval.ToList();

                        var _AttachmentData = reader1.Read<COM_T003>().ToList();
                        MC.AttachmentData = _AttachmentData.ToList();

                        var DocumentTypesTemp = reader1.Read<SYS_M013_P>().ToList();
                        MC.DocumentTypes = DocumentTypesTemp.ToList();
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
        public string GetData2(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_EPR_T001_Conv MC = new MultipleContext_EPR_T001_Conv();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T001_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        //var documentDataFlipGrid = reader.Read<EPR_T001_Flip>().ToList();
                        //MC.DocumentDataFlipGrid = documentDataFlipGrid.ToList();

                        var machineList = reader.Read<PPC_M001_P>().ToList();
                        MC.MachineList_CN = machineList.ToList();

                        var productionPlannList = reader.Read<PPC_T004_A_P>().ToList();
                        MC.ProductionPlanningList = productionPlannList.ToList();

                        var ModelList = reader.Read<ZADM_M009_P>().ToList();
                        MC.ModelMasterList = ModelList.ToList();

                        var INKList = reader.Read<ZADM_M006_P>().ToList();
                        MC.INKMasterList = INKList.ToList();

                        var WireList = reader.Read<ADM_M032_P>().ToList();
                        MC.WireMakeList = WireList.ToList();

                        var wireSize = reader.Read<ZADM_M003_P>().ToList();
                        MC.WireSizeList = wireSize.ToList();

                        var partyList = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyList = partyList.ToList();

                        var ILDList = reader.Read<ZADM_M007_P>().ToList();
                        MC.ILDMasterList = ILDList.ToList();

                        var BallMake = reader.Read<ADM_M032_P>().ToList();
                        MC.BallMakeList = BallMake.ToList();

                        var product = reader.Read<ADM_M022_P_ESSEM>().ToList();
                        MC.ItemList = product.ToList();

                        var pkgunit = reader.Read<ZADM_M017_P>().ToList();
                        MC.PkgUnitList = pkgunit.ToList();

                        var DocumentTypesTemp = reader.Read<SYS_M013_P>().ToList();
                        MC.DocumentTypes = DocumentTypesTemp.ToList();

                        var Shift = reader.Read<ADM_M042_P>().ToList();
                        MC.Shift = Shift.ToList();

                        var BallDia = reader.Read<ZADM_M001_P>().ToList();
                        MC.BallDia = BallDia.ToList();

                        var SalesOrder = reader.Read<SEL_T001_P>().ToList();
                        MC.SalesOrder = SalesOrder.ToList();

                        var masterEntityPrev = reader.Read<EPR_T001_New>().ToList();
                        MC.MasterEntityPrev = masterEntityPrev.ToList();

                        var t_statusdata = reader.Read<ADM_M0013>().ToList();
                        MC.t_StatusList = t_statusdata.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var masterEntity = reader.Read<EPR_T001_New>().ToList();
                        MC.MasterEntity = masterEntity.ToList();

                        var masterEntityPrev = reader.Read<EPR_T001_New>().ToList();
                        MC.MasterEntityPrev = masterEntityPrev.ToList();

                        var ApprovalDataVar = reader.Read<ADM_M043_D>().ToList();
                        MC.ApprovalData = ApprovalDataVar.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.AttachmentData = Attachment.ToList();

                    }
                    else if (RequestOption == "LoadHistory")
                    {
                        var documentDataFlipGrid = reader.Read<EPR_T001_Flip>().ToList();
                        MC.DocumentDataFlipGrid = documentDataFlipGrid.ToList();
                    }
                    else if (RequestOption == "LoadFeedbackRpt")
                    {
                        var feedback = reader.Read<ECRM_T002_AFeedbackRpt>().ToList();
                        MC.RptFeedback = feedback.ToList();
                    }
                    else if (RequestOption == "LoadFeedbackRpt2")
                    {
                        var feedback = reader.Read<ECRM_T002_AFeedbackRpt>().ToList();
                        MC.RptFeedback = feedback.ToList();
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

        public string Delete(string Request)
        {
            try
            {
                int intOut;
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    intOut = conn.Execute("PUR_T005Delete", new { @order_no = Request }, commandType: CommandType.StoredProcedure);
                }
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
    }
    public class MultipleContext_EPR_T001_Conv
    {
        public List<EPR_T001_New> ILDChart2 { get; set; } // adding  ILD chart
        public List<EPR_T001_Flip> DocumentDataFlipGrid { get; set; }
        public List<PPC_M001_P> MachineList_CN { get; set; }
        public List<ZADM_M013_P> MachineList { get; set; }
        public List<PPC_T004_A_P> ProductionPlanningList { get; set; }
        public List<ZADM_M009_P> ModelMasterList { get; set; }
        public List<ZADM_M006_P> INKMasterList { get; set; }
        public List<ADM_M032_P> WireMakeList { get; set; }
        public List<ZADM_M003_P> WireSizeList { get; set; }
        public List<ADM_M028_P> PartyList { get; set; }
        public List<ZADM_M007_P> ILDMasterList { get; set; }
        public List<ADM_M032_P> BallMakeList { get; set; }
        public List<ZADM_M001_P> BallDia { get; set; } //Ball Dia
        public List<ADM_M022_P_ESSEM> ItemList { get; set; } //Product or item master        
        public List<ZADM_M017_P> PkgUnitList { get; set; }
        public List<ZADM_M002_P> BallTypeList { get; set; }
        public List<ADM_M042_P> Shift { get; set; }
        public List<EPR_T001_New> MasterEntity { get; set; }
        public List<EPR_T001_New> MasterEntityPrev { get; set; }
        public List<ECRM_T002_AFeedbackRpt> RptFeedback { get; set; }
        public List<SYS_M013_P> DocumentTypes { get; set; }
        public List<SEL_T001_P> SalesOrder { get; set; } // Order No / sales Doc.no
        public List<RPT_EPR_T001> RPTINK { get; set; }
        public List<RPT_Approval> Rptapproval { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<ADM_M043_D> ApprovalData { get; set; }
        public List<ADM_M0013> t_StatusList { get; set; } //Transaction Status Master
        public List<SYS_M002> DocTypeInfo { get; set; }
    }
}
