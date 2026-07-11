using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    class ReflectionProcurementBL
    {
        public string Insert(string Request, string RequestOption)
        {
            string strValue = "";
            try
            {
                if (RequestOption == "TaskManager")
                {
                    //TSK_T001_ABL tSK_T001_ABL = new TSK_T001_ABL();
                    //strValue = tSK_T001_ABL.Insert(Request);
                }
                else if (RequestOption == "PurchaseOrder")
                {
                    PUR_T002BL pUR_T002BL = new PUR_T002BL();
                    strValue = pUR_T002BL.Insert(Request);
                }
                else if (RequestOption == "PurchaseReturnOrder")
                {
                    PUR_T002_PurchaseReturnBL PurchaseReturn = new PUR_T002_PurchaseReturnBL();
                    strValue = PurchaseReturn.Insert(Request);
                }
                else if (RequestOption == "PurchaseInvoice")
                {
                    PUR_T005BL pUR_T005BL = new PUR_T005BL();
                    strValue = pUR_T005BL.Insert(Request);
                }
                else if (RequestOption == "PurchaseRequisition")
                {
                    PUR_T001_ABL pUR_T001_ABL = new PUR_T001_ABL();
                    strValue = pUR_T001_ABL.Insert(Request);
                }

                else if (RequestOption == "PurchaseRequisitionCancel")
                {

                    PUR_T001_A_CANCELBL pUR_T001_A_CANCELBL = new PUR_T001_A_CANCELBL();
                    strValue = pUR_T001_A_CANCELBL.Update(Request);
                }
                else if (RequestOption == "StockTransferOrder")
                {
                    PUR_T002StoBL pUR_T002StoBL = new PUR_T002StoBL();
                    strValue = pUR_T002StoBL.Insert(Request);
                }
                else if (RequestOption == "PUR_T005_STD")
                {
                    PUR_T005_STD_BL pUR_T005_T005BL_CD = new PUR_T005_STD_BL();
                    strValue = pUR_T005_T005BL_CD.Insert(Request);
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
                if (RequestOption == "TaskManager")
                {
                    //TSK_T001_ABL tSK_T001_ABL = new TSK_T001_ABL();
                    //strValue = tSK_T001_ABL.Update(Request);
                }
                else if (RequestOption == "PurchaseOrder")
                {
                    PUR_T002BL pUR_T002BL = new PUR_T002BL();
                    strValue = pUR_T002BL.Update(Request);
                }
                else if (RequestOption == "PurchaseReturnOrder")
                {
                    PUR_T002_PurchaseReturnBL PurchaseReturn = new PUR_T002_PurchaseReturnBL();
                    strValue = PurchaseReturn.Update(Request);
                }
                else if (RequestOption == "PurchaseInvoice")
                {
                    PUR_T005BL pUR_T005BL = new PUR_T005BL();
                    strValue = pUR_T005BL.Update(Request);
                }
                else if (RequestOption == "PurchaseRequisition")
                {
                    PUR_T001_ABL pUR_T001_ABL = new PUR_T001_ABL();
                    strValue = pUR_T001_ABL.Update(Request);
                }
                else if (RequestOption == "StockTransferOrder")
                {
                    PUR_T002StoBL pUR_T002StoBL = new PUR_T002StoBL();
                    strValue = pUR_T002StoBL.Update(Request);
                }
                else if (RequestOption == "PUR_T005_STD")
                {
                    PUR_T005_STD_BL pUR_T005_T005BL_CD = new PUR_T005_STD_BL();
                    strValue = pUR_T005_T005BL_CD.Update(Request);
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
                if (RequestOption == "PurchaseOrder")
                {
                    PUR_T002BL pUR_T002BL = new PUR_T002BL();
                    strValue = pUR_T002BL.Delete(Request);
                }
                if (RequestOption == "PurchaseReturnOrder")
                {
                    PUR_T002_PurchaseReturnBL PurchaseReturn = new PUR_T002_PurchaseReturnBL();
                    strValue = PurchaseReturn.Delete(Request);
                }
                if (RequestOption == "PurchaseInvoice")
                {
                    PUR_T005BL pUR_T005BL = new PUR_T005BL();
                    strValue = pUR_T005BL.Delete(Request);
                }
                if (RequestOption == "PurchaseRequisition")
                {
                    PUR_T001_ABL pUR_T001_ABL = new PUR_T001_ABL();
                    strValue = pUR_T001_ABL.Delete(Request);
                }
                if (RequestOption == "StockTransferOrder")
                {
                    PUR_T002StoBL pUR_T002StoBL = new PUR_T002StoBL();
                    strValue = pUR_T002StoBL.Delete(Request);
                }


                //  return strValue;

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
                if (RequestOption == "TaskManager")
                {
                    //ADM_M001BL empBL = new ADM_M001BL();
                    //strValue = empBL.Delete(Request);
                }
                //else if (RequestOption == "UOM_Master")
                //{
                //    ADM_M038_BBL aDM_M038_BBL = new ADM_M038_BBL();
                //    strValue = aDM_M038_BBL.Delete(Request);
                //}


            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strValue;
        }

        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue)
        {
            string strval = "";
            try
            {
                if (RequestOption == "TaskManager")
                {
                    //TSK_T001_ABL tSK_T001_ABL = new TSK_T001_ABL();
                    //strval = tSK_T001_ABL.GetData(Request);
                }
                else if (RequestOption == "PurchaseOrder")
                {
                    PUR_T002BL pUR_T002BL = new PUR_T002BL();
                    strval = pUR_T002BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PurchaseReturnOrder")
                {
                    PUR_T002_PurchaseReturnBL PurchaseReturn = new PUR_T002_PurchaseReturnBL();
                    strval = PurchaseReturn.GetData(Request, strValue, intValue, strValue);
                }
                if (RequestOption == "PurchaseInvoice")
                {
                    PUR_T005BL pUR_T005BL = new PUR_T005BL();
                    strval = pUR_T005BL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PurchaseRequisition")
                {
                    PUR_T001_ABL pUR_T001_ABL = new PUR_T001_ABL();
                    strval = pUR_T001_ABL.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PurchaseRequisitionCancel")
                {
                    PUR_T001_A_CANCELBL pUR_T001_ABL = new PUR_T001_A_CANCELBL();
                    strval = pUR_T001_ABL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "StockTransferOrder")
                {
                    PUR_T002StoBL pUR_T002StoBL = new PUR_T002StoBL();
                    strval = pUR_T002StoBL.GetData(Request, strType, intValue, strValue);
                }

                else if (RequestOption == "PurchaseInvoiceDebitCredit")
                {
                    PUR_T005BL_CD pUR_T005_T005BL_CD = new PUR_T005BL_CD();
                    strval = pUR_T005_T005BL_CD.GetData(Request, strType, intValue, strValue);
                }
                else if (RequestOption == "PUR_T005_STD")
                {
                    PUR_T005_STD_BL pUR_T005_T005BL_CD = new PUR_T005_STD_BL();
                    strval = pUR_T005_T005BL_CD.GetData(Request, strType, intValue, strValue);
                }

                //else if (RequestOption == "PurchaseRequisition")
                //{
                //    PUR_T001_ABL pUR_T001_ABL = new PUR_T001_ABL();
                //    strval = pUR_T001_ABL.GetData(strType, intValue, strValue);
                //}
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strval;
        }

        public string GetData(string Request, string RequestOption, string strType, int intValue, string strValue, string doc_code, string company, string plant, string user, string request1, string request2, string request3, string request4, string request5)
        {
            string strValue1 = "";
            try
            {
                //if (RequestOption == "PurchaseRequisition")
                //{
                //    PUR_T001_ABL pUR_T001_ABL = new PUR_T001_ABL();
                //    strValue1 = pUR_T001_ABL.GetData(Request, strType, intValue, strValue, doc_code, company, plant, user, request1, request2, request3, request4, request5);
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
