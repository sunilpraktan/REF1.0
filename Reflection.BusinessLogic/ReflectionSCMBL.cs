using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class ReflectionSCMBL
    {
        public string Insert(string Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                if (RequestOption == "Average_Blank_Weight")
                {
                    ZSCM_T001_ABL zSCM_T001_ABL = new ZSCM_T001_ABL();
                    strValue = zSCM_T001_ABL.Insert(Request);
                }
                else if (RequestOption == "EPR_T003_STD")
                {
                    EPR_T003_STD_BL mM_T003BL = new EPR_T003_STD_BL();
                    strValue = mM_T003BL.Insert(Request);
                }
                else if (RequestOption == "EPR_T003_STD_HU")
                {
                    EPR_T003_STD_BL mM_T003BL = new EPR_T003_STD_BL();
                    strValue = mM_T003BL.Insert_HU(Request);
                }
                else if (RequestOption == "EPR_T003_STD_MERGE")
                {
                    EPR_T003_STD_BL mM_T003BL = new EPR_T003_STD_BL();
                    strValue = mM_T003BL.Insert_Merge(Request);
                }
                else if (RequestOption == "IndentOrder")
                {
                    MM_T003BL mM_T003BL = new MM_T003BL();
                    strValue = mM_T003BL.Insert(Request);
                }
                else if (RequestOption == "ProductConversion_Essem")
                {
                    MM_T001BL mM_T001BL = new MM_T001BL();
                    strValue = mM_T001BL.Insert(Request);
                }

                else if (RequestOption == "Goods_Receipt")
                {
                    MM_T001_MR_BL mM_T001BL = new MM_T001_MR_BL();
                    strValue = mM_T001BL.Insert(Request);
                }
                else if (RequestOption == "Goods_Issue")
                {
                    MM_T001_MI_BL mM_T001BL = new MM_T001_MI_BL();
                    strValue = mM_T001BL.Insert(Request);
                }

                //else if (RequestOption == "ProductConversion")
                //{
                //    MM_T001BL mM_T001BL = new MM_T001BL();
                //    strValue = mM_T001BL.Insert(Request);
                //}
                //else if (RequestOption == "Stock_Journal")
                //{
                //    MM_M007BL mM_M007BL = new MM_M007BL();
                //    strValue = mM_M007BL.Insert(Request);
                //}
                else if (RequestOption == "StockChecking")
                {
                    StockCheckingBL stockCheckingBL = new StockCheckingBL();
                    strValue = stockCheckingBL.Insert(Request);
                }
                else if (RequestOption == "DeliveryNote")
                {
                    LOG_T001_ABL log_T001_ABL = new LOG_T001_ABL();
                    strValue = log_T001_ABL.Insert(Request);
                }
                else if (RequestOption == "DeliveryNoteSTD")
                {
                    LOG_T001_A_STD_BL log_T001_ABL = new LOG_T001_A_STD_BL();
                    strValue = log_T001_ABL.Insert(Request);
                }
                else if (RequestOption == "DeliveryNotePost")
                {
                    LOG_T001_ABL log_T001_ABL = new LOG_T001_ABL();
                    strValue = log_T001_ABL.Insert_Post(Request);
                }
                else if (RequestOption == "DeliveryNotePostSTD")
                {
                    LOG_T001_A_STD_BL log_T001_ABL = new LOG_T001_A_STD_BL();
                    strValue = log_T001_ABL.Insert_Post(Request);
                }
                else if (RequestOption == "GoodsReceiptNote")
                {
                    MM_T001_GRN_BL mM_T001_GRN_BL = new MM_T001_GRN_BL();
                    strValue = mM_T001_GRN_BL.Insert(Request);
                }
                else if (RequestOption == "MM_T001_STD")
                {
                    MM_T001_STD_BL mM_T001_STD_BL = new MM_T001_STD_BL();
                    strValue = mM_T001_STD_BL.Insert(Request);
                }
                else if (RequestOption == "MM_T001_GM_STD")
                {
                    MM_T001_STD_GM_BL mM_T001_STD_BL = new MM_T001_STD_GM_BL();
                    strValue = mM_T001_STD_BL.Insert(Request);
                }
                else if (RequestOption == "GateEntry")
                {
                    MM_T004BL mM_T004BL = new MM_T004BL();
                    strValue = mM_T004BL.Insert(Request);
                }
                else if (RequestOption == "InwardOutward")
                {
                    MM_T004BL mM_T004BL = new MM_T004BL();
                    strValue = mM_T004BL.Insert(Request);
                }
                else if (RequestOption == "GatePass")
                {
                    MM_T004BL mM_T004BL = new MM_T004BL();
                    strValue = mM_T004BL.Insert(Request);
                }
                else if (RequestOption == "PhysicalStock")
                {
                    MM_S010BL mM_S010BL = new MM_S010BL();
                    strValue = mM_S010BL.Insert(Request);
                }
                else if (RequestOption == "MIS_FinStatement_InsertFG")
                {
                    MIS_FinStatementBL mIS_FinStatementBL = new MIS_FinStatementBL();
                    strValue = mIS_FinStatementBL.InsertFG(Request);
                }
                else if (RequestOption == "MIS_FinStatement_InsertTS")
                {
                    MIS_FinStatementBL mIS_FinStatementBL = new MIS_FinStatementBL();
                    strValue = mIS_FinStatementBL.InsertTS(Request);
                }
                else if (RequestOption == "Store_Location")
                {
                    MM_M001_BL _MM_M001_BL = new MM_M001_BL();
                    strValue = _MM_M001_BL.Insert(Request);
                }
                else if (RequestOption == "Waybill")
                {
                    GEN_T009_BL _GEN_T009_BL = new GEN_T009_BL();
                    strValue = _GEN_T009_BL.Insert(Request);
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
                if (RequestOption == "Average_Blank_Weight")
                {
                    ZSCM_T001_ABL zSCM_T001_ABL = new ZSCM_T001_ABL();
                    strValue = zSCM_T001_ABL.Update(Request);
                }
                else if (RequestOption == "EPR_T003_STD")
                {
                    EPR_T003_STD_BL mM_T003BL = new EPR_T003_STD_BL();
                    strValue = mM_T003BL.Update(Request);
                }
                else if (RequestOption == "EPR_T003_STD_HU")
                {
                    EPR_T003_STD_BL mM_T003BL = new EPR_T003_STD_BL();
                    strValue = mM_T003BL.Update_HU(Request);
                }
                else if (RequestOption == "IndentOrder")
                {
                    MM_T003BL mM_T003BL = new MM_T003BL();
                    strValue = mM_T003BL.Update(Request);
                }
                else if (RequestOption == "IndentOrderUpdateStatus")
                {
                    MM_T003BL mM_T003BL = new MM_T003BL();
                    strValue = mM_T003BL.UpdateStatus(Request);
                }
                else if (RequestOption == "ProductConversion_Essem")
                {
                    MM_T001BL mM_T001BL = new MM_T001BL();
                    strValue = mM_T001BL.Update(Request);
                }

                else if (RequestOption == "Goods_Receipt")
                {
                    MM_T001_MR_BL mM_T001BL = new MM_T001_MR_BL();
                    strValue = mM_T001BL.Update(Request);
                }
                else if (RequestOption == "Goods_Issue")
                {
                    MM_T001_MI_BL mM_T001BL = new MM_T001_MI_BL();
                    strValue = mM_T001BL.Update(Request);
                }
                //else if (RequestOption == "ProductConversion")
                //{
                //    MM_T001BL mM_T001BL = new MM_T001BL();
                //    strValue = mM_T001BL.Update(Request);
                //}
                //else if (RequestOption == "Stock_Journal")
                //{
                //    MM_M007BL mM_M007BL = new MM_M007BL();
                //    strValue = mM_M007BL.Update(Request);
                //}
                else if (RequestOption == "StockChecking")
                {
                    StockCheckingBL stockCheckingBL = new StockCheckingBL();
                    strValue = stockCheckingBL.Update(Request);
                }
                else if (RequestOption == "DeliveryNote")
                {
                    LOG_T001_ABL log_T001_ABL = new LOG_T001_ABL();
                    strValue = log_T001_ABL.Update(Request);
                }
                else if (RequestOption == "DeliveryNoteSTD")
                {
                    LOG_T001_A_STD_BL log_T001_ABL = new LOG_T001_A_STD_BL();
                    strValue = log_T001_ABL.Update(Request);
                }
                else if (RequestOption == "GoodsReceiptNote")
                {
                    MM_T001_GRN_BL mM_T001_GRN_BL = new MM_T001_GRN_BL();
                    strValue = mM_T001_GRN_BL.Update(Request);
                }
                else if (RequestOption == "MM_T001_STD")
                {
                    MM_T001_STD_BL mM_T001_STD_BL = new MM_T001_STD_BL();
                    strValue = mM_T001_STD_BL.Update(Request);
                }
                else if (RequestOption == "MM_T001_GM_STD")
                {
                    MM_T001_STD_GM_BL mM_T001_STD_BL = new MM_T001_STD_GM_BL();
                    strValue = mM_T001_STD_BL.Update(Request);
                }
                else if (RequestOption == "GateEntry")
                {
                    MM_T004BL mM_T004BL = new MM_T004BL();
                    strValue = mM_T004BL.Update(Request);
                }
                else if (RequestOption == "InwardOutward")
                {
                    MM_T004BL mM_T004BL = new MM_T004BL();
                    strValue = mM_T004BL.Update(Request);
                }
                else if (RequestOption == "GatePass")
                {
                    MM_T004BL mM_T004BL = new MM_T004BL();
                    strValue = mM_T004BL.Update(Request);
                }
                else if (RequestOption == "PhysicalStock")
                {
                    MM_S010BL mM_S010BL = new MM_S010BL();
                    strValue = mM_S010BL.Update(Request);
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
                if (RequestOption == "DeliveryNote")
                {
                    LOG_T001_ABL log_T001_ABL = new LOG_T001_ABL();
                    strValue = log_T001_ABL.Delete(Request);
                }
                else if (RequestOption == "DeliveryNoteSTD")
                {
                    LOG_T001_A_STD_BL log_T001_ABL = new LOG_T001_A_STD_BL();
                    strValue = log_T001_ABL.Delete(Request);
                }

                if (RequestOption == "Goods_Issue")
                {
                    MM_T001_MI_BL mM_T001BL = new MM_T001_MI_BL();
                    strValue = mM_T001BL.Delete(Request);

                }
                else if (RequestOption == "IndentOrder")
                {
                    MM_T003BL mM_T003BL = new MM_T003BL();
                    strValue = mM_T003BL.Delete(Request);
                }

                else if (RequestOption == "Goods_Receipt")
                {
                    MM_T001_MR_BL mM_T001BL = new MM_T001_MR_BL();
                    strValue = mM_T001BL.Delete(Request);
                }
                else if (RequestOption == "GoodsReceiptNote")
                {
                    MM_T001_GRN_BL mM_T001_GRN_BL = new MM_T001_GRN_BL();
                    strValue = mM_T001_GRN_BL.Delete(Request);
                }
                else if (RequestOption == "GateEntry")
                {
                    MM_T004BL mM_T004BL = new MM_T004BL();
                    strValue = mM_T004BL.Delete(Request);
                }
                else if (RequestOption == "InwardOutward")
                {
                    MM_T004BL mM_T004BL = new MM_T004BL();
                    strValue = mM_T004BL.Delete(Request);
                }
                else if (RequestOption == "GatePass")
                {
                    MM_T004BL mM_T004BL = new MM_T004BL();
                    strValue = mM_T004BL.Delete(Request);
                }
                else if (RequestOption == "ProductConversion_Essem")
                {
                    MM_T001BL mM_T001BL = new MM_T001BL();
                    strValue = mM_T001BL.Delete(Request);
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
                if (RequestOption == "Average_Blank_Weight")
                {
                    ZSCM_T001_ABL zSCM_T001_ABL = new ZSCM_T001_ABL();
                    strValue = zSCM_T001_ABL.Delete(Request);
                }

                //else if (RequestOption == "ProductConversion_Essem")
                //{
                //    MM_T001BL mM_T001BL = new MM_T001BL();
                //    strValue = mM_T001BL.Delete(Request);
                //}

                //else if (RequestOption == "ProductConversion")
                //{
                //    MM_T001BL mM_T001BL = new MM_T001BL();
                //    strValue = mM_T001BL.Delete(Request);
                //}
                //else if (RequestOption == "Stock_Journal")
                //{
                //    MM_M007BL mM_M007BL = new MM_M007BL();
                //    strValue = mM_M007BL.Delete(Request);
                //}
                else if (RequestOption == "StockChecking")
                {
                    StockCheckingBL stockCheckingBL = new StockCheckingBL();
                    strValue = stockCheckingBL.Delete(Request);
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
                if (RequestOption == "Average_Blank_Weight")
                {
                    ZSCM_T001_ABL zSCM_T001_ABL = new ZSCM_T001_ABL();
                    strVal = zSCM_T001_ABL.GetData(strType, intValue, strValue);
                }
                else if (RequestOption == "EPR_T003_STD")
                {
                    EPR_T003_STD_BL mM_T003BL = new EPR_T003_STD_BL();
                    strVal = mM_T003BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "ProductConversion_Essem")
                {
                    MM_T001BL mM_T001BL = new MM_T001BL();
                    strVal = mM_T001BL.GetData(Request, strType, intValue, strType);
                }
                else if (RequestOption == "Goods_Issue")
                {
                    MM_T001_MI_BL mM_T001BL = new MM_T001_MI_BL();
                    strVal = mM_T001BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "IndentOrder")
                {
                    MM_T003BL mM_T003BL = new MM_T003BL();
                    strVal = mM_T003BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "Goods_Receipt")
                {
                    MM_T001_MR_BL mM_T001BL = new MM_T001_MR_BL();
                    strVal = mM_T001BL.GetData(Request, strType, intValue, strValue);
                }

                //else if (RequestOption == "ProductConversion")
                //{
                //    MM_T001BL mM_T001BL = new MM_T001BL();
                //    strVal = mM_T001BL.GetData(strType, strValue, intValue);
                //}
                else if (RequestOption == "Current_Stock")
                {
                    CurrentStockBL mM_T001BL = new CurrentStockBL();
                    strVal = mM_T001BL.GetData(Request, strType, intValue, strValue);
                }
                //else if (RequestOption == "StockChart")
                //{
                //    MM_M005BL mM_M005BL = new MM_M005BL();
                //    strVal = mM_M005BL.GetData();
                //}
                //else if (RequestOption == "Stock_Journal")
                //{
                //    MM_M007BL mM_M007BL = new MM_M007BL();
                //    strVal = mM_M007BL.GetData();
                //}
                else if (RequestOption == "StockChecking")
                {
                    StockCheckingBL stockCheckingBL = new StockCheckingBL();
                    strVal = stockCheckingBL.GetData(strType, intValue, strValue);
                }
                else if (RequestOption == "DeliveryNote")
                {
                    LOG_T001_ABL log_T001_ABL = new LOG_T001_ABL();
                    strVal = log_T001_ABL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "DeliveryNoteSTD")
                {
                    LOG_T001_A_STD_BL log_T001_ABL = new LOG_T001_A_STD_BL();
                    strVal = log_T001_ABL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "GoodsReceiptNote")
                {
                    MM_T001_GRN_BL mM_T001_STD_BL = new MM_T001_GRN_BL();
                    strVal = mM_T001_STD_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MM_T001_STD")
                {
                    MM_T001_STD_BL mM_T001_STD_BL = new MM_T001_STD_BL();
                    strVal = mM_T001_STD_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MM_T001_GM_STD")
                {
                    MM_T001_STD_GM_BL mM_T001_STD_BL = new MM_T001_STD_GM_BL();
                    strVal = mM_T001_STD_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "GateEntry")
                {
                    MM_T004BL mM_T004BL = new MM_T004BL();
                    strVal = mM_T004BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "InwardOutward")
                {
                    MM_T004BL mM_T004BL = new MM_T004BL();
                    strVal = mM_T004BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "GatePass")
                {
                    MM_T004BL mM_T004BL = new MM_T004BL();
                    strVal = mM_T004BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_SCM_Reports")
                {
                    MIS_SCM_Report1BL mIS_SCM_Report1BL = new MIS_SCM_Report1BL();
                    strVal = mIS_SCM_Report1BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_SCM_Report3")
                {
                    MIS_SCM_Report3BL mIS_SCM_Report3BL = new MIS_SCM_Report3BL();
                    strVal = mIS_SCM_Report3BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_SCM_Report4")
                {
                    MIS_SCM_Report4BL mIS_SCM_Report4BL = new MIS_SCM_Report4BL();
                    strVal = mIS_SCM_Report4BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_SCM_Report5")
                {
                    MIS_SCM_Report5BL mIS_SCM_Report5BL = new MIS_SCM_Report5BL();
                    strVal = mIS_SCM_Report5BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_SCM")
                {
                    MIS_SCMBL mIS_SCMBL = new MIS_SCMBL();
                    strVal = mIS_SCMBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_FinStatement")
                {
                    MIS_FinStatementBL mIS_FinStatementBL = new MIS_FinStatementBL();
                    strVal = mIS_FinStatementBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_FinStatement_FG")
                {
                    MIS_FinStatementBL mIS_FinStatementBL = new MIS_FinStatementBL();
                    strVal = mIS_FinStatementBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_SCM_Store")
                {
                    MIS_SCM_StoreBL mIS_SCM_StoreBL = new MIS_SCM_StoreBL();
                    strVal = mIS_SCM_StoreBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_SCMIndentReport")
                {
                    MIS_SCM_IndentBL mIS_SCMIndentReport = new MIS_SCM_IndentBL();
                    strVal = mIS_SCMIndentReport.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PhysicalStock")
                {
                    MM_S010BL mM_S010BL = new MM_S010BL();
                    strVal = mM_S010BL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "PhysicalStock1")
                {
                    MM_S010BL mM_S010BL = new MM_S010BL();
                    strVal = mM_S010BL.GetData1(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "Store_Location")
                {
                    MM_M001_BL _MM_M001_BL = new MM_M001_BL();
                    strVal = _MM_M001_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "Waybill")
                {
                    GEN_T009_BL _GEN_T009_BL = new GEN_T009_BL();
                    strVal = _GEN_T009_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_STD_MM_1")
                {
                    MIS_STD_MM_1_BL _GEN_T009_BL = new MIS_STD_MM_1_BL();
                    strVal = _GEN_T009_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_STD_MM_2")
                {
                    MIS_STD_MM_2_BL _GEN_T009_BL = new MIS_STD_MM_2_BL();
                    strVal = _GEN_T009_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_STD_MM_3")
                {
                    MIS_STD_MM_3_BL _GEN_T009_BL = new MIS_STD_MM_3_BL();
                    strVal = _GEN_T009_BL.GetData(Request, strType, intValue, strValue);
                }
            }

            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strVal;
        }
    }

}
