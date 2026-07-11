using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class ReflectionCRMBL
    {    //  
        public string Insert(string Request, string RequestOption)
        {
            string strValue = "";
            try
            {
               if (RequestOption == "SalesOrderMaster")
               {
                    SEL_T001BL sEL_T001BL = new SEL_T001BL();
                    strValue = sEL_T001BL.Insert(Request);
               }
                if (RequestOption == "SalesLeadMaster")
                {
                    CRM_T003BL cRM_T003BL = new CRM_T003BL();
                    strValue = cRM_T003BL.Insert(Request);
                }

                if (RequestOption == "SalesReturnOrder")
                {
                    SEL_T001_SalesReturnBL SalesReturn = new SEL_T001_SalesReturnBL();
                    strValue = SalesReturn.Insert(Request);
                }
                if (RequestOption == "AreaCalculation")
                {
                    ZADM_M025BL ADM_M025 = new ZADM_M025BL();
                    strValue = ADM_M025.Insert(Request);
                }

                if (RequestOption == "SalesQuotation")
                {
                    SEL_T001_QNBL sEL_T001BL = new SEL_T001_QNBL();
                    strValue = sEL_T001BL.Insert(Request);
                }

                if (RequestOption == "CRMActivity")
                {
                   TSK_T001_CBL cRM_T004BL = new TSK_T001_CBL();
                    strValue = cRM_T004BL.Insert(Request);
                }

                else if (RequestOption == "Requirement")
               {
                   SEL_T002BLReq sEL_T002BLReq = new SEL_T002BLReq();
                   strValue = sEL_T002BLReq.Insert(Request);
               }
               //else if (RequestOption == "RateTransfer")
               //{
               //    ZACC_T001BL zACC_T001BL = new ZACC_T001BL();
               //    strValue = zACC_T001BL.Insert(Request);
               //}
               else if (RequestOption == "WritingTest")
               {
                   ECRM_T003_ABL eCRM_T003_ABL = new ECRM_T003_ABL();
                   strValue = eCRM_T003_ABL.Insert(Request);
               }
                else if (RequestOption == "ExpectedPayment")
                {
                    TSK_T001_CBL cRM_T004BL = new TSK_T001_CBL();
                    strValue = cRM_T004BL.InsertEP(Request);
                }
                else if (RequestOption == "Quality_Feedback")
               {
                   ECRM_T002_ABL eCRM_T002_ABL = new ECRM_T002_ABL();
                   strValue = eCRM_T002_ABL.Insert(Request);
               }
               else if (RequestOption == "Sample_Analysis")
               {
                   ECRM_T001_ABL eCRM_T001_ABL = new ECRM_T001_ABL();
                   strValue = eCRM_T001_ABL.Insert(Request);
               }
               else if (RequestOption == "PDI_Entry")
               {
                   ECRM_T004_ABL eCRM_T004_ABL = new ECRM_T004_ABL();
                   strValue = eCRM_T004_ABL.Insert(Request);
               }
             
              
               else if (RequestOption == "DeliverySchedule")
               {
                   SEL_T002BL sEL_T002BL = new SEL_T002BL();
                   strValue = sEL_T002BL.Insert(Request);
               }
               else if (RequestOption == "DeliveryScheduleSTD")
               {
                    SEL_T002_STD_BL sEL_T002BL = new SEL_T002_STD_BL();
                   strValue = sEL_T002BL.Insert(Request);
               }
               else if (RequestOption == "CompanyCatlog")
               {
                   CRM_T001ABL cRM_T001ABL = new CRM_T001ABL();
                   strValue = cRM_T001ABL.Insert(Request);
               }
               else if (RequestOption == "SupplierCatalog")
               {
                   CRM_T002BL cRM_T002BL = new CRM_T002BL();
                   strValue = cRM_T002BL.Insert(Request);
               }

               else if (RequestOption == "Closure")
                {
                    CRM_T004BL cRM_T004BL = new CRM_T004BL();
                    strValue = cRM_T004BL.Insert(Request);
                }
                else if (RequestOption == "Wastage_Entry")
                {
                    SEL_T099BL sEL_T099BL = new SEL_T099BL();
                    strValue = sEL_T099BL.Insert(Request);
                }
                else if (RequestOption == "AutoSalesInvoice")
               {
                   ZCRM_T001BL aCC_T001ABL = new ZCRM_T001BL();
                   strValue = aCC_T001ABL.Insert(Request);
               }
               else if (RequestOption == "DeliveryEntry")
               {
                   ZCRM_T001BL aCC_T001ABL = new ZCRM_T001BL();
                   strValue = aCC_T001ABL.Insert(Request);
               }
               //else if (RequestOption == "LoggingControl")
               //{
               //    COM_T002BL COM_T002BL = new COM_T002BL();
               //    strValue = COM_T002BL.Insert(Request);
               //}   
               else if (RequestOption == "SalesInvoice")
               {
                   SEL_T003BL sel_t003_ABL = new SEL_T003BL();
                   strValue = sel_t003_ABL.Insert(Request);
               }
            else if (RequestOption == "SEL_T003_STD")
            {
                SEL_T003_STD_BL sel_t003_ABL = new SEL_T003_STD_BL();
                strValue = sel_t003_ABL.Insert(Request);
            }
                else if (RequestOption == "SalesInvoiceDebitCredit")
                {
                    SEL_T003BL_CD sel_t003BL_cd = new SEL_T003BL_CD();
                    strValue = sel_t003BL_cd.Insert(Request);
                }
                else if (RequestOption == "SalesInquiry")
               {
                   SEL_T001_INBL sEL_T001BL = new SEL_T001_INBL();
                   strValue = sEL_T001BL.Insert(Request);
               }
              
               else if (RequestOption == "Sample_Request")
               {
                   SEL_T001BL sEL_T001BL = new SEL_T001BL();
                   strValue = sEL_T001BL.Insert(Request); 
               }
                else if (RequestOption == "Sample_Response")
                {
                    ECRM_T001_CBL eCRM_T001_CBL = new ECRM_T001_CBL();
                    strValue = eCRM_T001_CBL.Insert(Request);
                }
               // else if (RequestOption == "RateTransfer")
               //{
               //    ZACC_T001BL zACC_T001_ABL = new ZACC_T001BL();
               //    strValue = zACC_T001_ABL.Insert(Request);
               //}
                else if (RequestOption == "TransferOrder")
                {
                    SEL_T004BL SEL_T004BL = new SEL_T004BL();
                    strValue = SEL_T004BL.Insert(Request);
                }
                else if (RequestOption == "FormReceivedFrmCustomer")
                {
                    ESEL_T001_ABL eSEL_T001_ABL = new ESEL_T001_ABL();
                    strValue = eSEL_T001_ABL.Insert(Request);
                }
                else if (RequestOption == "CRM_ActivityBulk")
                {
                    TSK_T001_C_Bulk_BL _TSK_T001_C_Bulk_BL = new TSK_T001_C_Bulk_BL();
                    strValue = _TSK_T001_C_Bulk_BL.Insert(Request);
                }
                else if (RequestOption == "GST_Invoice")
                {
                    ZSEL_T003_BL _ZSEL_T003_BL = new ZSEL_T003_BL();
                    strValue = _ZSEL_T003_BL.Insert(Request);
                }
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }       
        public byte[] Insert(string Request, string RequestOption, string strType)
        {
            byte[] strValue;
            try
            {               

            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }


            return strValue = null;
        }
        public string Update(string Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                if (RequestOption == "SalesOrderMaster")
                {
                    SEL_T001BL sEL_T001BL = new SEL_T001BL();
                    strValue = sEL_T001BL.Update(Request);
                }
                if (RequestOption == "SalesLeadMaster")
                {
                    CRM_T003BL cRM_T003BL = new CRM_T003BL();
                    strValue = cRM_T003BL.Update(Request);
                }
                if (RequestOption == "SalesReturnOrder")
                {
                    SEL_T001_SalesReturnBL SalesReturn = new SEL_T001_SalesReturnBL();
                    strValue = SalesReturn.Update(Request);
                }

                if (RequestOption == "AreaCalculation")
                {
                    ZADM_M025BL ADM_M025 = new ZADM_M025BL();
                    strValue = ADM_M025.Update(Request);
                }
                if (RequestOption == "SalesQuotation")
                {
                    SEL_T001_QNBL sEL_T001BL = new SEL_T001_QNBL();
                    strValue = sEL_T001BL.Update(Request);
                }
                if (RequestOption == "CRMActivity")
                {
                    TSK_T001_CBL cRM_T004BL = new TSK_T001_CBL();
                    strValue = cRM_T004BL.Update(Request);
                }
                else if (RequestOption == "ExpectedPayment")
                {
                    TSK_T001_CBL cRM_T004BL = new TSK_T001_CBL();
                    strValue = cRM_T004BL.InsertEP(Request);
                }
                else if (RequestOption == "Requirement")
                {
                    SEL_T002BLReq sEL_T002BLReq = new SEL_T002BLReq();
                    strValue = sEL_T002BLReq.Update(Request);
                }
                else if (RequestOption == "ExpectedPayment")
                {
                    TSK_T001_CBL cRM_T004BL = new TSK_T001_CBL();
                    strValue = cRM_T004BL.InsertEP(Request);
                }
                else if (RequestOption == "Closure")
                {
                    CRM_T004BL cRM_T004BL = new CRM_T004BL();
                    strValue = cRM_T004BL.Update(Request);
                }
                else if (RequestOption == "Wastage_Entry")
                {
                    SEL_T099BL sEL_T099BL = new SEL_T099BL();
                    strValue = sEL_T099BL.Update(Request);
                }
                else if (RequestOption == "SO_Acknowledgement")
                {
                    SEL_T001BL sEL_T001BL = new SEL_T001BL();
                    strValue = sEL_T001BL.Update(Request);
                }
                //else if (RequestOption == "RateTransfer")
                //{
                //    ZACC_T001BL zACC_T001BL = new ZACC_T001BL();
                //    strValue = zACC_T001BL.Update(Request);
                //}
                             
                else if (RequestOption == "WritingTest")
                {
                    ECRM_T003_ABL eCRM_T003_ABL = new ECRM_T003_ABL();
                    strValue = eCRM_T003_ABL.Update(Request);
                }
                else if (RequestOption == "Quality_Feedback")
                {
                    ECRM_T002_ABL eCRM_T002_ABL = new ECRM_T002_ABL();
                    strValue = eCRM_T002_ABL.Update(Request);
                }
                else if (RequestOption == "Sample_Analysis")
                {
                    ECRM_T001_ABL eCRM_T001_ABL = new ECRM_T001_ABL();
                    strValue = eCRM_T001_ABL.Update(Request);
                }
                else if (RequestOption == "Sample_Response")
                {
                    ECRM_T001_CBL eCRM_T001_CBL = new ECRM_T001_CBL();
                    strValue = eCRM_T001_CBL.Update(Request);
                }
                else if (RequestOption == "PDI_Entry")
                {
                    ECRM_T004_ABL eCRM_T004_ABL = new ECRM_T004_ABL();
                    strValue = eCRM_T004_ABL.Update(Request);
                }                      
                else if (RequestOption == "DeliverySchedule")
                {
                    SEL_T002BL sEL_T002BL = new SEL_T002BL();
                    strValue = sEL_T002BL.Update(Request);
                }
                else if (RequestOption == "DeliveryScheduleSTD")
                {
                    SEL_T002_STD_BL sEL_T002BL = new SEL_T002_STD_BL();
                    strValue = sEL_T002BL.Update(Request);
                }
                else if (RequestOption == "CompanyCatlog")
                {
                    CRM_T001ABL cRM_T001ABL = new CRM_T001ABL();
                    strValue = cRM_T001ABL.Update(Request);
                }
                else if (RequestOption == "SupplierCatalog")
                {
                    CRM_T002BL cRM_T002BL = new CRM_T002BL();
                    strValue = cRM_T002BL.Update(Request);
                }
               
                else if (RequestOption == "AutoSalesInvoice")
                {
                    ZCRM_T001BL aCC_T001ABL = new ZCRM_T001BL();
                    strValue = aCC_T001ABL.Update(Request);
                }
                else if (RequestOption == "DeliveryEntry")
                {
                    ZCRM_T001BL aCC_T001ABL = new ZCRM_T001BL();
                    strValue = aCC_T001ABL.Update(Request);
                }
                else if (RequestOption == "SalesInquiry")
                {
                    SEL_T001_INBL sEL_T001BL = new SEL_T001_INBL();
                    strValue = sEL_T001BL.Update(Request);
                }
               
                else if (RequestOption == "Sample_Request")
                {
                    SEL_T001BL sEL_T001BL = new SEL_T001BL();
                    strValue = sEL_T001BL.Update(Request);
                }
                //else if (RequestOption == "RateTransfer")
                //{
                //    ZACC_T001BL zACC_T001_ABL = new ZACC_T001BL();
                //    strValue = zACC_T001_ABL.Update(Request);
                //}
                else if (RequestOption == "SalesInvoice")
                {
                    SEL_T003BL sel_t003_ABL = new SEL_T003BL();
                    strValue = sel_t003_ABL.Update(Request);
                }
                else if (RequestOption == "SEL_T003_STD")
                {
                    SEL_T003_STD_BL sel_t003_ABL = new SEL_T003_STD_BL();
                    strValue = sel_t003_ABL.Update(Request);
                }
                else if (RequestOption == "SalesInvoiceDebitCredit")
                {
                    SEL_T003BL_CD sel_t003BL_cd = new SEL_T003BL_CD();
                    strValue = sel_t003BL_cd.Update(Request);
                }
                else if (RequestOption == "TransferOrder")
                {
                    SEL_T004BL SEL_T004BL = new SEL_T004BL();
                    strValue = SEL_T004BL.Update(Request);
                }
                else if (RequestOption == "TransferOrderUpdateStatus")
                {
                    SEL_T004BL SEL_T004BL = new SEL_T004BL();
                    strValue = SEL_T004BL.UpdateStatusTO(Request);
                }
                else if (RequestOption == "SalesOrderUpdateStatus")
                {
                    SEL_T001_SSEBL sEL_T001_SSEBL = new SEL_T001_SSEBL();
                    strValue = sEL_T001_SSEBL.UpdateStatusSO(Request);
                }
                else if (RequestOption == "SalesOrderUpdateStatusDone")
                {
                    SEL_T001_SSEBL sEL_T001_SSEBL = new SEL_T001_SSEBL();
                    strValue = sEL_T001_SSEBL.UpdateStatusSODone(Request);
                }
                else if (RequestOption == "FormReceivedFrmCustomer")
                {
                    ESEL_T001_ABL eSEL_T001_ABL = new ESEL_T001_ABL();
                    strValue = eSEL_T001_ABL.Update(Request);
                }
                else if (RequestOption == "GST_Invoice")
                {
                    ZSEL_T003_BL _ZSEL_T003_BL = new ZSEL_T003_BL();
                    strValue = _ZSEL_T003_BL.Insert(Request);
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
                 if (RequestOption == "Quality_Feedback")
                {
                    ECRM_T002_ABL eCRM_T002_ABL = new ECRM_T002_ABL();
                    strValue = eCRM_T002_ABL.Delete(Request);
                }

                if (RequestOption == "AreaCalculation")
                {
                    ZADM_M025BL ADM_M025 = new ZADM_M025BL();
                    strValue = ADM_M025.Delete(Request);
                }

                if (RequestOption == "CRMActivity")
                {
                    TSK_T001_CBL cRM_T004BL = new TSK_T001_CBL();
                    strValue = cRM_T004BL.Delete(Request);
                }
                else if (RequestOption == "WritingTest")
                 {
                     ECRM_T003_ABL eCRM_T003_ABL = new ECRM_T003_ABL();
                     strValue = eCRM_T003_ABL.Delete(Request);
                 }
                else if (RequestOption == "Closure")
                {
                    CRM_T004BL cRM_T004BL = new CRM_T004BL();
                    strValue = cRM_T004BL.Delete(Request);
                }
                else if (RequestOption == "Wastage_Entry")
                {
                    SEL_T099BL sEL_T099BL = new SEL_T099BL();
                    strValue = sEL_T099BL.Delete(Request);
                }
                else if (RequestOption == "SalesInvoice")
                {
                    SEL_T003BL sel_t003_ABL = new SEL_T003BL();
                    strValue = sel_t003_ABL.Delete(Request);
                }
                else if (RequestOption == "SEL_T003_STD")
                {
                    SEL_T003_STD_BL sel_t003_ABL = new SEL_T003_STD_BL();
                    strValue = sel_t003_ABL.Delete(Request);
                }
                else if (RequestOption == "SalesInvoiceDebitCredit")
                {
                    SEL_T003BL_CD sel_t003BL_cd = new SEL_T003BL_CD();
                    strValue = sel_t003BL_cd.Delete(Request);
                }
                else if (RequestOption == "Sample_Analysis")
                {
                    ECRM_T001_ABL eCRM_T001_ABL = new ECRM_T001_ABL();
                    strValue = eCRM_T001_ABL.Delete(Request);
                }
                else if (RequestOption == "Sample_Response")
                {
                    ECRM_T001_CBL eCRM_T001_CBL = new ECRM_T001_CBL();
                    strValue = eCRM_T001_CBL.Delete(Request);
                }
                else if (RequestOption == "TransferOrder")
                {
                    SEL_T004BL SEL_T004BL = new SEL_T004BL();
                    strValue = SEL_T004BL.Delete(Request);
                }
                //else if (RequestOption == "DeliverySchedule")
                //{
                //    SEL_T002BL sEL_T002BL = new SEL_T002BL();
                //    strValue = sEL_T002BL.Delete(Request);
                //}
                else if (RequestOption == "SupplierCatalog")
                {
                    CRM_T002BL cRM_T002BL = new CRM_T002BL();
                    strValue = cRM_T002BL.Delete(Request);
                }

                //else if (RequestOption == "Requirement")
                //{
                //    SEL_T002BLReq sEL_T002BLReq = new SEL_T002BLReq();
                //    strValue = sEL_T002BLReq.Delete(Request);
                //}
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }


            return strValue;
        }
        public string Delete(int Request, int Request1, string RequestOption)
        {
            string strValue = "";
            try
            {
               
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
                if (RequestOption == "SalesOrderMaster")
                {
                    SEL_T001BL sEL_T001BL = new SEL_T001BL();
                    strValue = sEL_T001BL.Delete(Request);
                }
                if (RequestOption == "SalesQuotation")
                {
                    SEL_T001_QNBL sEL_T001BL = new SEL_T001_QNBL();
                    strValue = sEL_T001BL.Delete(Request);
                }

                //else if (RequestOption == "RateTransfer")
                //{
                //    ZACC_T001BL zACC_T001BL = new ZACC_T001BL();
                //    strValue = zACC_T001BL.Delete(Request);
                //}                
              
                else if (RequestOption == "PDI_Entry")
                {
                    ECRM_T004_ABL eCRM_T004_ABL = new ECRM_T004_ABL();
                    strValue = eCRM_T004_ABL.Delete(Request);
                }
                
                else if (RequestOption == "CompanyCatlog")
                {
                    CRM_T001ABL cRM_T001ABL = new CRM_T001ABL();
                    strValue = cRM_T001ABL.Delete(Request);
                }
               
                
                else if (RequestOption == "AutoSalesInvoice")
                {
                    ZCRM_T001BL aCC_T001ABL = new ZCRM_T001BL();
                    strValue = aCC_T001ABL.Delete(Request);
                }
                else if (RequestOption == "DeliveryEntry")
                {
                    ZCRM_T001BL aCC_T001ABL = new ZCRM_T001BL();
                    strValue = aCC_T001ABL.Delete(Request);
                }
                else if (RequestOption == "SalesInquiry") 
                {
                    SEL_T001_INBL sEL_T001BL = new SEL_T001_INBL();
                    strValue = sEL_T001BL.Delete(Request);
                }
                else if (RequestOption == "SalesQuotation") 
                {
                    SEL_T001BL sEL_T001BL = new SEL_T001BL();
                    strValue = sEL_T001BL.Delete(Request);
                }
                else if (RequestOption == "Sample_Request") 
                {
                    SEL_T001BL sEL_T001BL = new SEL_T001BL();
                    strValue = sEL_T001BL.Delete(Request);
                }
                //else if (RequestOption == "RateTransfer")
                //{
                //    ZACC_T001BL zACC_T001_ABL = new ZACC_T001BL();
                //    strValue = zACC_T001_ABL.Delete(Request);
                //}
             
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }
        public string  GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strValue1="";
            try
            {
                if (RequestOption == "SalesOrderMaster")
                {
                    SEL_T001BL sEL_T001BL = new SEL_T001BL();
                    strValue1 = sEL_T001BL.GetData(Request,strType, intValue, strValue);
                }
                if (RequestOption == "SalesLeadMaster")
                {
                    CRM_T003BL cRM_T003BL = new CRM_T003BL();
                    strValue1 = cRM_T003BL.GetData(Request, strType, intValue, strValue);
                }
                if (RequestOption == "SalesReturnOrder")
                {
                    SEL_T001_SalesReturnBL SalesReturn = new SEL_T001_SalesReturnBL();
                    strValue1 = SalesReturn.GetData(Request, strType, intValue, strValue);
                }
                if (RequestOption == "AreaCalculation")
                {
                    ZADM_M025BL ADM_M025 = new ZADM_M025BL();
                    strValue1 = ADM_M025.GetData(Request, strType, intValue, strValue);
                }
                if (RequestOption == "CRMActivity")
                {
                    TSK_T001_CBL cRM_T004BL = new TSK_T001_CBL();
                    strValue1 = cRM_T004BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "Requirement")
                {
                    SEL_T002BLReq sEL_T002BLReq = new SEL_T002BLReq();
                    strValue1 = sEL_T002BLReq.GetData(strType, intValue, strValue);
                }
                else if (RequestOption == "SO_Acknowledgement")
                {
                    SEL_T001BL sEL_T001BL = new SEL_T001BL();
                    strValue1 = sEL_T001BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "Closure")
                {
                    CRM_T004BL cRM_T004BL = new CRM_T004BL();
                    strValue1 = cRM_T004BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "Wastage_Entry")
                {
                    SEL_T099BL sEL_T099BL = new SEL_T099BL();
                    strValue1 = sEL_T099BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_Closure")
                {
                    MIS_ClosureBL mIS_ClosureBL = new MIS_ClosureBL();
                    strValue1 = mIS_ClosureBL.GetData(Request, strType, intValue, strValue);
                }
               
                else if (RequestOption == "WritingTest")
                {
                    ECRM_T003_ABL eCRM_T003_ABL = new ECRM_T003_ABL();
                    strValue1 = eCRM_T003_ABL.GetData(Request,strType, intValue, strValue);
                }
                else if (RequestOption == "WritingTest2")
                {
                    ECRM_T003A_BL eCRM_T003_ABL = new ECRM_T003A_BL();
                    strValue1 = eCRM_T003_ABL.GetData(Request, strType, intValue, strValue);
                }
                //else if (RequestOption == "Quality_Feedback")
                //{
                //    ECRM_T002_ABL eCRM_T002_ABL = new ECRM_T002_ABL();
                //    strValue1 = eCRM_T002_ABL.GetData(strType, intValue, strValue);
                //}
                else if (RequestOption == "Quality_Feedback")
                {
                    ECRM_T002_ABL eCRM_T002_ABL = new ECRM_T002_ABL();
                    strValue1 = eCRM_T002_ABL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PDI_Entry")
                {
                    ECRM_T004_ABL eCRM_T004_ABL = new ECRM_T004_ABL();
                    strValue1 = eCRM_T004_ABL.GetData(strType, intValue, strValue);
                }
                else if (RequestOption == "PDI_QualityInst")
                {
                    ECRM_T004_ABL eCRM_T004_ABL = new ECRM_T004_ABL();
                    strValue1 = eCRM_T004_ABL.GetData2(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "Sample_Analysis")
                {
                    ECRM_T001_ABL eCRM_T001_ABL = new ECRM_T001_ABL();
                    strValue1 = eCRM_T001_ABL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "Sample_Response")
                {
                    ECRM_T001_CBL eCRM_T001_CBL = new ECRM_T001_CBL();
                    strValue1 = eCRM_T001_CBL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "DeliverySchedule")
                {
                    SEL_T002BL sEL_T002BL = new SEL_T002BL();
                    strValue1 = sEL_T002BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "DeliveryScheduleSTD")
                {
                    SEL_T002_STD_BL sEL_T002BL = new SEL_T002_STD_BL();
                    strValue1 = sEL_T002BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "CompanyCatlog")
                {
                    CRM_T001ABL cRM_T001ABL = new CRM_T001ABL();
                    strValue1 = cRM_T001ABL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SupplierCatalog")
                {
                    CRM_T002BL cRM_T002BL = new CRM_T002BL();
                    strValue1 = cRM_T002BL.GetData(Request, strType, intValue,strValue);
                }
                
                
                else if (RequestOption == "AutoSalesInvoice")
                {
                    ZCRM_T001BL aCC_T001ABL = new ZCRM_T001BL();
                    strValue1 = aCC_T001ABL.GetData(strType, intValue, strValue);    
                }
                if (RequestOption == "DeliveryEntry")
                {
                    ZCRM_T001BL aCC_T001ABL = new ZCRM_T001BL();
                    strValue1 = aCC_T001ABL.GetData(strType, intValue, strValue);
                }
                else if (RequestOption == "AutoSalesInvoice2")
                {
                    ZCRM_T001_BL zCRM_T001_BL = new ZCRM_T001_BL();
                    strValue1 = zCRM_T001_BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "LoggingControl")
                {
                    //COM_T002BL COM_T002BL = new COM_T002BL();
                    //strValue1 = COM_T002BL.GetData();
                }
                else if (RequestOption == "SalesInvoice")
                {
                    SEL_T003BL sel_t003_ABL = new SEL_T003BL();
                    strValue1 = sel_t003_ABL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SEL_T003_STD")
                {
                    SEL_T003_STD_BL sel_t003_ABL = new SEL_T003_STD_BL();
                    strValue1 = sel_t003_ABL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SalesInvoiceDebitCredit")
                {
                    SEL_T003BL_CD sel_t003BL_cd = new SEL_T003BL_CD();
                    strValue1 = sel_t003BL_cd.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "Logistic_periodicReport")
                {
                    Logistic_periodicReportBL Logistic_periodicReportBL = new Logistic_periodicReportBL();
                    strValue1 = Logistic_periodicReportBL.GetData(strType, intValue, strValue);
                }
                else if (RequestOption == "SalesInquiry")
                {
                    SEL_T001_INBL sEL_T001BL = new SEL_T001_INBL();
                    strValue1 = sEL_T001BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SalesQuotation")
                {
                    SEL_T001_QNBL sEL_T001BL = new SEL_T001_QNBL();
                    strValue1 = sEL_T001BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SaleOrderReports")
                {
                    PeriodicReportBL PeriodicReportBL = new PeriodicReportBL();
                    strValue1 = PeriodicReportBL.GetData(strType, intValue, strValue);
                }
                else if (RequestOption == "PurchaseOrderReports")
                {
                    PeriodicReportBL PeriodicReportBL = new PeriodicReportBL();
                    strValue1 = PeriodicReportBL.GetData(strType, intValue, strValue);
                }
                else if (RequestOption == "Sample_Request")
                {
                    SEL_T001BL sEL_T001BL = new SEL_T001BL();
                    strValue1 = sEL_T001BL.GetData(Request, strType, intValue, strValue);
                }
                //else if (RequestOption == "RateTransfer")
                //{
                //    ZACC_T001BL zACC_T001_ABL = new ZACC_T001BL();
                //    strValue1 = zACC_T001_ABL.GetData(strType, strValue, intValue);
                //}
                else if (RequestOption == "MIS_CRMSalesReports")
                {
                    MIS_CRMSalesReportBL mIS_CRMSalesReport = new MIS_CRMSalesReportBL();
                    strValue1 = mIS_CRMSalesReport.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_CRMSalesReport3")
                {
                    MIS_CRMSalesReport3_BL mIS_CRMSalesReport3 = new MIS_CRMSalesReport3_BL();
                    strValue1 = mIS_CRMSalesReport3.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_CRM_SalesReport5")
                {
                    MIS_CRMSalesReport5_BL mIS_CRMSalesReport5 = new MIS_CRMSalesReport5_BL();
                    strValue1 = mIS_CRMSalesReport5.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "MIS_CRM_SalesReport6")
                {
                    MIS_CRMSalesReport6_BL mIS_CRMSalesReport6 = new MIS_CRMSalesReport6_BL();
                    strValue1 = mIS_CRMSalesReport6.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "MIS_CRM_SalesReport7")
                {
                    MIS_CRMSalesReport7_BL mIS_CRMSalesReport7 = new MIS_CRMSalesReport7_BL();
                    strValue1 = mIS_CRMSalesReport7.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "MIS_CRM_SalesPeriodic8")
                {
                    MIS_CRMSalesReport8_BL mIS_CRMSalesReport8 = new MIS_CRMSalesReport8_BL();
                    strValue1 = mIS_CRMSalesReport8.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_CRMPurchaseReport")
                {
                    MIS_CRM_PurchaseBL mIS_CRMPurchaseReport = new MIS_CRM_PurchaseBL();
                    strValue1 = mIS_CRMPurchaseReport.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_CRMPurchaseReport1")
                {
                    MIS_CRM_Purchase1BL mIS_CRMPurchaseReport1 = new MIS_CRM_Purchase1BL();
                    strValue1 = mIS_CRMPurchaseReport1.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_CRMPurchaseReport2")
                {
                    MIS_CRM_Purchase2BL mIS_CRMPurchaseReport2 = new MIS_CRM_Purchase2BL();
                    strValue1 = mIS_CRMPurchaseReport2.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "MIS_Sales_Insurance")
                {
                    MIS_Sales_InsuranceBL mIS_Sales_InsuranceBL = new MIS_Sales_InsuranceBL();
                    strValue1 = mIS_Sales_InsuranceBL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "TransferOrder")
                {
                    SEL_T004BL SEL_T004BL = new SEL_T004BL();
                    strValue1 = SEL_T004BL.GetData(Request, strType, intValue, strValue);
                }
                if (RequestOption == "SalesServiceEntry")
                {
                    SEL_T001_SSEBL sEL_T001BL = new SEL_T001_SSEBL();
                    strValue1 = sEL_T001BL.GetData(Request, strType, intValue, strValue);
                }
                if (RequestOption == "FormReceivedFrmCustomer")
                {
                    ESEL_T001_ABL esEL_T001aBL = new ESEL_T001_ABL();
                    strValue1 = esEL_T001aBL.GetData(Request, strType, intValue, strValue);
                }
                if (RequestOption == "RateTransfer")
                {
                    ZACC_T001_ABL eSEL_T001BL = new ZACC_T001_ABL();
                    strValue1 = eSEL_T001BL.GetData(strType, intValue, strValue);
                }
                if (RequestOption == "CRM_ActivityBulk")
                {
                    TSK_T001_C_Bulk_BL tSK_T001_C_Bulk_BL = new TSK_T001_C_Bulk_BL();
                    strValue1 = tSK_T001_C_Bulk_BL.GetData(Request,strType, intValue, strValue);
                }
                if (RequestOption == "GST_Invoice")
                {
                    ZSEL_T003_BL _ZSEL_T003_BL = new ZSEL_T003_BL();
                    strValue1 = _ZSEL_T003_BL.GetData(Request, strType, intValue, strValue);
                }
                if (RequestOption == "MIS_Approval")
                {
                    MIS_ApprovalBL MIS_ApprovalReport = new MIS_ApprovalBL();
                    strValue1 = MIS_ApprovalReport.GetData(Request, strType, intValue, strValue);
                }
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue1;
        }
        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue, string doc_code, string company, string plant, string user, string request1, string request2, string request3, string request4, string request5)
        {
            string strValue1 = "";
            try
            {
                if (RequestOption == "SalesOrderMaster")
                {
                    //SEL_T001BL sEL_T001BL = new SEL_T001BL();
                    //strValue1 = sEL_T001BL.GetData(Request, strType, intValue, strValue, doc_code, company, plant, user, request1, request2, request3, request4, request5);
                }
                else if (RequestOption == "Requirement")
                {
                    SEL_T002BLReq sEL_T002BLReq = new SEL_T002BLReq();
                    strValue1 = sEL_T002BLReq.GetData(strType, intValue, strValue);
                }

                if (RequestOption == "SalesReturnOrder")
                {
                    SEL_T001_SalesReturnBL SalesReturn = new SEL_T001_SalesReturnBL();
                    strValue1 = SalesReturn.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SO_Acknowledgement")
                {
                    SEL_T001BL sEL_T001BL = new SEL_T001BL();
                    strValue1 = sEL_T001BL.GetData(Request, strType, intValue, strValue);
                }
                //else if (RequestOption == "RateTransfer")
                //{
                //    ZACC_T001BL zACC_T001BL = new ZACC_T001BL();
                //    strValue1 = zACC_T001BL.GetData(strType, strValue, intValue);
                //}
                else if (RequestOption == "WritingTest")
                {
                    ECRM_T003_ABL eCRM_T003_ABL = new ECRM_T003_ABL();
                    strValue1 = eCRM_T003_ABL.GetData(Request,strType, intValue, strValue);
                }
                //else if (RequestOption == "Quality_Feedback")
                //{
                //    ECRM_T002_ABL eCRM_T002_ABL = new ECRM_T002_ABL();
                //    strValue1 = eCRM_T002_ABL.GetData(strType, intValue, strValue);
                //}
                else if (RequestOption == "Quality_Feedback")
                {
                    ECRM_T002_ABL eCRM_T002_ABL = new ECRM_T002_ABL();
                    strValue1 = eCRM_T002_ABL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PDI_Entry")
                {
                    ECRM_T004_ABL eCRM_T004_ABL = new ECRM_T004_ABL();
                    strValue1 = eCRM_T004_ABL.GetData(strType, intValue, strValue);
                }
               

                else if (RequestOption == "PurchaseRequisition")
                {
                    //PUR_T001_ABL pUR_T001_ABL = new PUR_T001_ABL();
                    //strValue1 = pUR_T001_ABL.GetData(strType, intValue, strValue);
                }
                else if (RequestOption == "DeliverySchedule")
                {
                    SEL_T002BL sEL_T002BL = new SEL_T002BL();
                    strValue1 = sEL_T002BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "DeliveryScheduleSTD")
                {
                    SEL_T002_STD_BL sEL_T002BL = new SEL_T002_STD_BL();
                    strValue1 = sEL_T002BL.GetData(Request, strType, intValue, strValue);
                }
                //else if (RequestOption == "CompanyCatlog")
                //{
                //    CRM_T001ABL cRM_T001ABL = new CRM_T001ABL();
                //    strValue1 = cRM_T001ABL.GetData(strType, intValue, strValue);
                //}

                //else if (RequestOption == "SupplierCatalog")
                //{
                //    CRM_T002BL cRM_T002BL = new CRM_T002BL();
                //    strValue1 = cRM_T002BL.GetData(strType, intValue, strValue);
                //}
                else if (RequestOption == "PurchaseOrder")
                {
                    PUR_T002BL pUR_T002BL = new PUR_T002BL();
                    //strValue1 = pUR_T002BL.GetData(Request,strType, intValue, strValue);
                }
               
                else if (RequestOption == "AutoSalesInvoice")
                {
                    ZCRM_T001BL aCC_T001ABL = new ZCRM_T001BL();
                    strValue1 = aCC_T001ABL.GetData(strType, intValue, strValue);
                }
                if (RequestOption == "DeliveryEntry")
                {
                    ZCRM_T001BL aCC_T001ABL = new ZCRM_T001BL();
                    strValue1 = aCC_T001ABL.GetData(strType, intValue, strValue);
                }
                //else if (RequestOption == "LoggingControl")
                //{
                //    COM_T002BL COM_T002BL = new COM_T002BL();
                //    strValue1 = COM_T002BL.GetData();
                //}
                else if (RequestOption == "SalesInvoice")
                {
                    //SEL_T003BL sel_t003_ABL = new SEL_T003BL();
                    //strValue1 = sel_t003_ABL.GetData(strType, intValue, strValue);
                }
                else if (RequestOption == "Logistic_periodicReport")
                {
                    Logistic_periodicReportBL Logistic_periodicReportBL = new Logistic_periodicReportBL();
                    strValue1 = Logistic_periodicReportBL.GetData(strType, intValue, strValue);
                }
                else if (RequestOption == "SalesInquiry")
                {
                    SEL_T001BL sEL_T001BL = new SEL_T001BL();
                    strValue1 = sEL_T001BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SalesQuotation")
                {
                    SEL_T001BL sEL_T001BL = new SEL_T001BL();
                    strValue1 = sEL_T001BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "SaleOrderReports")
                {
                    PeriodicReportBL PeriodicReportBL = new PeriodicReportBL();
                    strValue1 = PeriodicReportBL.GetData(strType, intValue, strValue);
                }
                else if (RequestOption == "PurchaseOrderReports")
                {
                    PeriodicReportBL PeriodicReportBL = new PeriodicReportBL();
                    strValue1 = PeriodicReportBL.GetData(strType, intValue, strValue);
                }
                else if (RequestOption == "Sample_Request")
                {
                    SEL_T001BL sEL_T001BL = new SEL_T001BL();
                    strValue1 = sEL_T001BL.GetData(Request, strType, intValue, strValue);
                }
               
                //else if (RequestOption == "RateTransfer")
                //{
                //    ZACC_T001BL zACC_T001_ABL = new ZACC_T001BL();
                //    strValue1 = zACC_T001_ABL.GetData(strType, strValue, intValue);
                //}

            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue1;
        }
        public byte[] GetDataWithReturnByte(string Request, string RequestOption)
        {
            byte[] strValue = null;
            try
            {               
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }

    }
}
