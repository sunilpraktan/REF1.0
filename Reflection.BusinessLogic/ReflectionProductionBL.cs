using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class ReflectionProductionBL
    {
        public string MIS_Quality_Report { get; private set; }

        public string Insert(string Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                if (RequestOption == "ProcessInspection")
                {
                    ZCRM_T003BL PIBL = new ZCRM_T003BL();
                    strValue = PIBL.Insert(Request);
                }
                if (RequestOption == "ILDChart")
                {
                    EPR_T001BL ILdBL = new EPR_T001BL();
                    strValue = ILdBL.Insert(Request);
                }
                else if (RequestOption == "ConversionNote")
                {
                    EPR_T001BL ILdBL = new EPR_T001BL();
                    strValue = ILdBL.Insert(Request);
                }
                else if (RequestOption == "Production_Order_STD")
                {
                    EPR_T001_BL_STD EPR = new EPR_T001_BL_STD();
                    strValue = EPR.Insert(Request);
                }
                else if (RequestOption == "Production_Order_Chart")
                {
                    EPR_T001_BL_ORDER_CHART_STD EPR = new EPR_T001_BL_ORDER_CHART_STD();
                    strValue = EPR.Insert(Request);
                }
                else if (RequestOption == "ILDChart2")
                {
                    EPR_T001_BL ePR_T001_BL = new EPR_T001_BL();
                    strValue = ePR_T001_BL.Insert(Request);
                }
                else if (RequestOption == "ConversionNote2")
                {
                    EPR_T001_BL ePR_T001_BL = new EPR_T001_BL();
                    strValue = ePR_T001_BL.Insert(Request);
                }
                else if (RequestOption == "LabelGenerationMaster")
                {
                    EPR_T002BL ePR_T002BL = new EPR_T002BL();
                    strValue = ePR_T002BL.Insert(Request);
                }
                else if (RequestOption == "Production_Order_Execution_STD")
                {
                    EPR_T002_BL_STD ePR_T002BL = new EPR_T002_BL_STD();
                    strValue = ePR_T002BL.Insert(Request);
                }
                else if (RequestOption == "MergeLabel")
                {
                    EPR_T002BL ePR_T002BL = new EPR_T002BL();
                    strValue = ePR_T002BL.Insert_MergeLabel(Request);
                }
                else if (RequestOption == "Sorting2")
                {
                    ESO_T001BL eSO_T001BL = new ESO_T001BL();
                    strValue = eSO_T001BL.Insert(Request);
                }
                else if (RequestOption == "Sorting")
                {
                    ESO_T001_BL eSO_T001BL = new ESO_T001_BL();
                    strValue = eSO_T001BL.Insert(Request);
                }
                else if (RequestOption == "SmallCarton")
                {
                    EPR_T003BL eSO_T001BL = new EPR_T003BL();
                    strValue = eSO_T001BL.Insert(Request);
                }
                else if (RequestOption == "SampleLabel")
                {
                    EPR_T005_ABL ePR_T005_ABL = new EPR_T005_ABL();
                    strValue = ePR_T005_ABL.Insert(Request);
                }
                else if (RequestOption == "WritingTestForProduction")
                {
                    ECRM_T003_ABL eCRM_T003_ABL = new ECRM_T003_ABL();
                    strValue = eCRM_T003_ABL.Insert(Request);
                }
                else if (RequestOption == "WritingTestForProduction2")
                {
                    ECRM_T003A_BL eCRM_T003A_BL = new ECRM_T003A_BL();
                    strValue = eCRM_T003A_BL.Insert(Request);
                }
                else if (RequestOption == "ProductionEntryMultiple")
                {
                    PPC_T002BL eSO_T001BL = new PPC_T002BL();
                    strValue = eSO_T001BL.Insert(Request);
                }
                else if (RequestOption == "JobCart")
                {
                    PPC_T001BL pPC_T001BL = new PPC_T001BL();
                    strValue = pPC_T001BL.Insert(Request);
                }
                else if (RequestOption == "ProductionPlanning")
                {
                    PPC_T004BL pPC_T004BL = new PPC_T004BL();
                    strValue = pPC_T004BL.Insert(Request);
                }
                else if (RequestOption == "ProductionPlanninginsert")
                {
                    PPC_T004BL pPC_T004BL = new PPC_T004BL();
                    strValue = pPC_T004BL.Insert1(Request);
                }
                else if (RequestOption == "UltrasonicCleaning")
                {
                    PPC_T003BL pPC_T003BL = new PPC_T003BL();
                    strValue = pPC_T003BL.Insert(Request);
                }
                else if (RequestOption == "RandomInspection")
                {
                    ZCRM_T002_RI_BL zCRM_T002_RI_BL = new ZCRM_T002_RI_BL();
                    strValue = zCRM_T002_RI_BL.Insert(Request);
                }
                else if (RequestOption == "LocalExportCarton2")
                {
                    EPR_T003BL ePR_T003BL = new EPR_T003BL();
                    strValue = ePR_T003BL.Insert2(Request);
                }
                if (RequestOption == "TDS")
                {
                    ENG_T004BL eNG_T004BL = new ENG_T004BL();
                    strValue = eNG_T004BL.Insert(Request);
                }

                if (RequestOption == "PDI Entry 2")
                {
                    ECRM_T004_ABL_New eCRM_T004_ABL_New = new ECRM_T004_ABL_New();
                    strValue = eCRM_T004_ABL_New.Insert(Request);
                }
                if (RequestOption == "BreakDownReason")
                {
                    PMT_M001BL pMT_M001BL = new PMT_M001BL();
                    strValue = pMT_M001BL.Insert(Request);
                }
                else if (RequestOption == "WorkCenter")
                {
                    PPC_M001_BL workCenter = new PPC_M001_BL();
                    strValue = workCenter.Insert(Request);
                }

            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }
        public string Update(string Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                if (RequestOption == "ProcessInspection")
                {
                    ZCRM_T003BL PIBL = new ZCRM_T003BL();
                    strValue = PIBL.Update(Request);
                }
                if (RequestOption == "ILDChart")
                {
                    EPR_T001BL ILdBL = new EPR_T001BL();
                    strValue = ILdBL.Update(Request);
                }
                else if (RequestOption == "ConversionNote")
                {
                    EPR_T001BL ILdBL = new EPR_T001BL();
                    strValue = ILdBL.Update(Request);
                }
                else if (RequestOption == "Production_Order_STD")
                {
                    EPR_T001_BL_STD EPR = new EPR_T001_BL_STD();
                    strValue = EPR.Update(Request);
                }
                else if (RequestOption == "Production_Order_Chart")
                {
                    EPR_T001_BL_ORDER_CHART_STD EPR = new EPR_T001_BL_ORDER_CHART_STD();
                    strValue = EPR.Update(Request);
                }
                else if (RequestOption == "LabelGenerationMaster")
                {
                    EPR_T002BL ILdBL = new EPR_T002BL();
                    strValue = ILdBL.Update(Request);
                }
                else if (RequestOption == "Production_Order_Execution_STD")
                {
                    EPR_T002_BL_STD ePR_T002BL = new EPR_T002_BL_STD();
                    strValue = ePR_T002BL.Update(Request);
                }
                else if (RequestOption == "LabelUpdate")
                {
                    EPR_T002BL ILdBL = new EPR_T002BL();
                    strValue = ILdBL.Update_Label(Request);
                }
                else if (RequestOption == "ProductionEntrySearch")
                {
                    EPR_T002BL ILdBL = new EPR_T002BL();
                    strValue = ILdBL.Update_ProdEntrySearch(Request);
                }
                else if (RequestOption == "Sorting")
                {
                    ESO_T001_BL eSO_T001BL = new ESO_T001_BL();
                    strValue = eSO_T001BL.Update(Request);
                }
                else if (RequestOption == "ConversionNote2")
                {
                    EPR_T001_BL ePR_T001_BL = new EPR_T001_BL();
                    strValue = ePR_T001_BL.Update(Request);
                }
                else if (RequestOption == "SmallCarton")
                {
                    EPR_T003BL eSO_T001BL = new EPR_T003BL();
                    strValue = eSO_T001BL.Update(Request);
                }
                else if (RequestOption == "LocalExportCarton2")    // For CRI Different Procedure and Method
                {
                    EPR_T003BL eSO_T001BL = new EPR_T003BL();
                    strValue = eSO_T001BL.Update2(Request);
                }
                else if (RequestOption == "WritingTestForProduction")
                {
                    ECRM_T003_ABL eCRM_T003_ABL = new ECRM_T003_ABL();
                    strValue = eCRM_T003_ABL.Update(Request);
                }

                else if (RequestOption == "WritingTestForProduction2")
                {
                    ECRM_T003A_BL eCRM_T003A_BL = new ECRM_T003A_BL();
                    strValue = eCRM_T003A_BL.Update(Request);
                }
                else if (RequestOption == "SampleLabel")
                {
                    EPR_T005_ABL ePR_T005_ABL = new EPR_T005_ABL();
                    strValue = ePR_T005_ABL.Update(Request);
                }

                else if (RequestOption == "ProductionEntryMultiple")
                {
                    PPC_T002BL eSO_T001BL = new PPC_T002BL();
                    strValue = eSO_T001BL.Update(Request);
                }
                else if (RequestOption == "JobCart")
                {
                    PPC_T001BL pPC_T001BL = new PPC_T001BL();
                    strValue = pPC_T001BL.Update(Request);
                }
                else if (RequestOption == "ProductionPlanning")
                {
                    PPC_T004BL pPC_T004BL = new PPC_T004BL();
                    strValue = pPC_T004BL.Update(Request);
                }
                else if (RequestOption == "UltrasonicCleaning")
                {
                    PPC_T003BL pPC_T003BL = new PPC_T003BL();
                    strValue = pPC_T003BL.Update(Request);
                }
                else if (RequestOption == "RandomInspection")
                {
                    ZCRM_T002_RI_BL zCRM_T002_RI_BL = new ZCRM_T002_RI_BL();
                    strValue = zCRM_T002_RI_BL.Update(Request);
                }
                else if (RequestOption == "Sorting2")
                {
                    ESO_T001BL eSO_T001BL = new ESO_T001BL();
                    strValue = eSO_T001BL.Update(Request);
                }
                else if (RequestOption == "CancelStatusILDChart")
                {
                    EPR_T001BL sEL_T001_SSEBL = new EPR_T001BL();
                    strValue = sEL_T001_SSEBL.UpdateStatusCancel(Request);
                }
                else if (RequestOption == "StopStatusILDChart")
                {
                    EPR_T001BL sEL_T001_SSEBL = new EPR_T001BL();
                    strValue = sEL_T001_SSEBL.UpdateStatusStop(Request);
                }
                else if (RequestOption == "CurrentStatusILDChart")
                {
                    EPR_T001BL sEL_T001_SSEBL = new EPR_T001BL();
                    strValue = sEL_T001_SSEBL.UpdateStatusCurrent(Request);
                }
                else if (RequestOption == "TDS")
                {
                    ENG_T004BL eNG_T004BL = new ENG_T004BL();
                    strValue = eNG_T004BL.Update(Request);
                }
                if (RequestOption == "PDI Entry 2")
                {
                    ECRM_T004_ABL_New eCRM_T004_ABL_New = new ECRM_T004_ABL_New();
                    strValue = eCRM_T004_ABL_New.Update(Request);
                }
                if (RequestOption == "BreakDownReason")
                {
                    PMT_M001BL pMT_M001BL = new PMT_M001BL();
                    strValue = pMT_M001BL.Update(Request);
                }
                else if (RequestOption == "WorkCenter")
                {
                    PPC_M001_BL workCenter = new PPC_M001_BL();
                    strValue = workCenter.Update(Request);
                }

            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }

        public string Delete(int Request, string RequestOption)
        {
            string strValue = "";
            try
            {

                //if (RequestOption == "Sorting")
                //{
                //    ESO_T001BL eSO_T001BL = new ESO_T001BL();
                //    strValue = eSO_T001BL.Delete(Request);
                //}

                if (RequestOption == "JobCart")
                {
                    PPC_T001BL pPC_T001BL = new PPC_T001BL();
                    strValue = pPC_T001BL.Delete(Request);
                }


            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }

        public string Delete(string Request, string RequestOption)
        {
            string strValue = "";
            try
            {

                if (RequestOption == "ProcessInspection")
                {
                    ZCRM_T003BL PIBL = new ZCRM_T003BL();
                    strValue = PIBL.Delete(Request);
                }
                if (RequestOption == "ILDChart")
                {
                    EPR_T001BL ILdBL = new EPR_T001BL();
                    strValue = ILdBL.Delete(Request);
                }
                else if (RequestOption == "ConversionNote")
                {
                    EPR_T001BL ILdBL = new EPR_T001BL();
                    strValue = ILdBL.Delete(Request);
                }
                else if (RequestOption == "ConversionNote2")
                {
                    EPR_T001_BL ePR_T001_BL = new EPR_T001_BL();
                    strValue = ePR_T001_BL.Delete(Request);
                }
                else if (RequestOption == "LabelGenerationMaster")
                {
                    EPR_T002BL ILdBL = new EPR_T002BL();
                    strValue = ILdBL.Delete(Request);
                }
                else if (RequestOption == "SampleLabel")
                {
                    EPR_T005_ABL ePR_T005_ABL = new EPR_T005_ABL();
                    strValue = ePR_T005_ABL.Delete(Request);
                }
                else if (RequestOption == "ProductionEntryMultiple")
                {
                    PPC_T002BL ILdBL = new PPC_T002BL();
                    strValue = ILdBL.Delete(Request);
                }
                else if (RequestOption == "RandomInspection")
                {
                    ZCRM_T002_RI_BL zCRM_T002_RI_BL = new ZCRM_T002_RI_BL();
                    strValue = zCRM_T002_RI_BL.Delete(Request);
                }
                else if (RequestOption == "UltrasonicCleaning")
                {
                    PPC_T003BL pPC_T003BL = new PPC_T003BL();
                    strValue = pPC_T003BL.Delete(Request);
                }
                if (RequestOption == "JobCart")
                {
                    //PPC_T001BL pPC_T001BL = new PPC_T001BL();
                    //strValue = pPC_T001BL.Delete(Request);
                }
                else if (RequestOption == "Sorting2")
                {
                    ESO_T001BL eSO_T001BL = new ESO_T001BL();
                    strValue = eSO_T001BL.Delete(Request);
                }
                else if (RequestOption == "Sorting")
                {
                    ESO_T001BL eSO_T001BL = new ESO_T001BL();
                    strValue = eSO_T001BL.Delete(Request);
                }


            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }

        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strVal = "";
            try
            {

                if (RequestOption == "ProcessInspection")
                {
                    ZCRM_T003BL PIBL = new ZCRM_T003BL();
                    strVal = PIBL.GetData(Request, strType, intValue, strValue);
                }
                if (RequestOption == "ILDChart")
                {
                    EPR_T001BL eePR_T001BL = new EPR_T001BL();
                    strVal = eePR_T001BL.GetData(strType, strValue, intValue);
                }
                if (RequestOption == "ConversionNote")
                {
                    EPR_T001BL ILdBL = new EPR_T001BL();
                    strVal = ILdBL.GetData(strType, strValue, intValue);
                }
                if (RequestOption == "Production_Order_STD")
                {
                    EPR_T001_BL_STD EPR = new EPR_T001_BL_STD();
                    strVal = EPR.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "Production_Order_Chart")
                {
                    EPR_T001_BL_ORDER_CHART_STD EPR = new EPR_T001_BL_ORDER_CHART_STD();
                    strVal = EPR.GetData(Request, strType, intValue, strValue);
                }
                if (RequestOption == "ConversionNote2")
                {
                    EPR_T001_BL ePR_T001_BL = new EPR_T001_BL();
                    strVal = ePR_T001_BL.GetData(Request, strType, intValue, strValue);
                }
                if (RequestOption == "LoadConversionNote2_Data")
                {
                    EPR_T001_BL ePR_T001_BL = new EPR_T001_BL();
                    strVal = ePR_T001_BL.GetData2(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "LabelGenerationMaster")
                {
                    EPR_T002BL eePR_T001BL = new EPR_T002BL();
                    strVal = eePR_T001BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "Production_Order_Execution_STD")
                {
                    EPR_T002_BL_STD ePR_T002BL = new EPR_T002_BL_STD();
                    strVal = ePR_T002BL.GetData(Request, strType, intValue, strValue);
                }
                if (RequestOption == "SampleLabel")
                {
                    EPR_T005_ABL ePR_T005_ABL = new EPR_T005_ABL();
                    strVal = ePR_T005_ABL.GetData(Request, strType, intValue, strValue);
                }
                if (RequestOption == "ConversionNoteFeedback")
                {
                    EPR_T001BL ILdBL = new EPR_T001BL();
                    strVal = ILdBL.GetData2(Request, strType, intValue, strValue);
                }
                //else if (RequestOption == "Reports")
                //{
                //    EssemSingleReportsBL eSO_T001BL = new EssemSingleReportsBL();
                //    strVal = eSO_T001BL.GetData(strType, intValue, strValue);
                //}
                else if (RequestOption == "SmallCarton")
                {
                    EPR_T003BL ePR_T003BL = new EPR_T003BL();
                    strVal = ePR_T003BL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "WritingTestForProduction")
                {
                    ECRM_T003_ABL eCRM_T003_ABL = new ECRM_T003_ABL();
                    strVal = eCRM_T003_ABL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ProductionEntryMultiple")
                {
                    PPC_T002BL eSO_T001BL = new PPC_T002BL();
                    strVal = eSO_T001BL.GetData(strType, strValue, intValue);
                }
                else if (RequestOption == "JobCart")
                {
                    PPC_T001BL pPC_T001BL = new PPC_T001BL();
                    strVal = pPC_T001BL.GetData(strType, intValue, strValue);
                }
                else if (RequestOption == "ProductionPlanning")
                {
                    PPC_T004BL pPC_T004BL = new PPC_T004BL();
                    strVal = pPC_T004BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "RandomInspection")
                {
                    ZCRM_T002_RI_BL zCRM_T002_RI_BL = new ZCRM_T002_RI_BL();
                    strVal = zCRM_T002_RI_BL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "MIS_BOM_MRP")
                {
                    MIS_BOM_MRPBL bOM_Report = new MIS_BOM_MRPBL();
                    strVal = bOM_Report.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "UltrasonicCleaning")
                {
                    PPC_T003BL pPC_T003BL = new PPC_T003BL();
                    strVal = pPC_T003BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_Production_Reports")
                {
                    MIS_ProductionBL mIS_ProductionBL = new MIS_ProductionBL();
                    strVal = mIS_ProductionBL.GetData(Request, strType, intValue, strValue);

                }
                else if (RequestOption == "MIS_Pro_Periodics")
                {
                    MIS_Pro_PeriodicBL mIS_Pro_PeriodicBL = new MIS_Pro_PeriodicBL();
                    strVal = mIS_Pro_PeriodicBL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "MIS_Quality_Report")
                {
                    MIS_QualityBL mIS_QualityBL = new MIS_QualityBL();
                    strVal = mIS_QualityBL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "MIS_Pro_MFG")
                {
                    MIS_Pro_MFG_BL mIS_Pro_MFG_BL = new MIS_Pro_MFG_BL();
                    strVal = mIS_Pro_MFG_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "Sorting2")
                {
                    ESO_T001BL eSO_T001BL = new ESO_T001BL();
                    strVal = eSO_T001BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "TDS")
                {
                    ENG_T004BL eNG_T004BL = new ENG_T004BL();
                    strVal = eNG_T004BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SortingReport")
                {
                    ESO_T001ReportBL eSO_T001ReportBL = new ESO_T001ReportBL();
                    strVal = eSO_T001ReportBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "LocalExportCarton2")
                {
                    EPR_T003BL ePR_T003BL = new EPR_T003BL();
                    strVal = ePR_T003BL.GetData2(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SearchLabel")
                {
                    EPR_T003BL ePR_T003BL = new EPR_T003BL();
                    strVal = ePR_T003BL.GetData_SearchLabel(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PDI Entry 2")
                {
                    ECRM_T004_ABL_New eCRM_T004_ABL_New = new ECRM_T004_ABL_New();
                    strVal = eCRM_T004_ABL_New.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "BreakDownReason")
                {
                    PMT_M001BL pMT_M001BL = new PMT_M001BL();
                    strVal = pMT_M001BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "WorkCenter")
                {
                    PPC_M001_BL workCenter = new PPC_M001_BL();
                    strVal = workCenter.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_STD_PPC_1")
                {
                    MIS_STD_PPC_1_BL MIS_STD_PPC = new MIS_STD_PPC_1_BL();
                    strVal = MIS_STD_PPC.GetData(Request, strType, intValue, strValue);
                }
            }

            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strVal;
        }
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue, string doc_code, string company, string plant, string user, string request1, string request2, string request3, string request4, string request5)
        {
            string strValue1 = "";
            try
            {
                if (RequestOption == "Sorting")
                {
                    ESO_T001_BL eSO_T001BL = new ESO_T001_BL();
                    strValue1 = eSO_T001BL.GetData(Request, strType, intValue, strValue, doc_code, company, plant, user, request1, request2, request3, request4, request5);
                }
                else if (RequestOption == "SortingReport")
                {
                    ESO_T001_BL eSO_T001BL = new ESO_T001_BL();
                    strValue1 = eSO_T001BL.GetData(Request, strType, intValue, strValue, doc_code, company, plant, user, request1, request2, request3, request4, request5);
                }
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue1;
        }

    }
}
