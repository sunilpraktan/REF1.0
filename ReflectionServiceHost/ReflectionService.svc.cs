using Reflection.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ReflectionServiceHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReflectionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ReflectionService.svc or ReflectionService.svc.cs at the Solution Explorer and start debugging.
    public class ReflectionService : IReflectionService
    {
        public string Insert(string Request, string RequestOption, string Module, string strType, int intValue, string strValue)
        {
            string strReturnVal = "";
            try
            {
                IReflectionService ad = new ServiceAdapter();
                strReturnVal = ad.Insert(Request, RequestOption, Module, strType, intValue, strValue);
            }
            catch(CreateException ex)
            {
                HandleException(ex, ex.ErrorCode, ex.Message);
            }
            return strReturnVal;
        }
        public byte[] InsertWithCompression(byte[] RequestStream, string Request, string RequestOption, string RequestPath)
        {
            byte[] strReturnVal = null;
            try
            {
                IReflectionService ad = new ServiceAdapter();
                strReturnVal = ad.InsertWithCompression(RequestStream,Request, RequestOption, RequestPath);
            }
            catch (CreateException ex)
            {
                HandleException(ex, ex.ErrorCode, ex.Message);
            }
            return strReturnVal;
        }

        public string Update(string Request, string RequestOption, string Module, string strType, int intValue, string strValue)
        {
            string strReturnVal = "";
            try
            {
                IReflectionService ad = new ServiceAdapter();
                strReturnVal = ad.Update(Request, RequestOption, Module, strType, intValue, strValue);
            }
            catch (CreateException ex)
            {
                HandleException(ex, ex.ErrorCode, ex.Message);
            }
            return strReturnVal;
        }
        public byte[] UpdateWithCompression(byte[] RequestStream, string Request, string RequestOption, string RequestPath)
        {
            byte[] strReturnVal = null;
            try
            {
                IReflectionService ad = new ServiceAdapter();
                strReturnVal = ad.UpdateWithCompression(RequestStream, Request, RequestOption, RequestPath);
            }
            catch (CreateException ex)
            {
                HandleException(ex, ex.ErrorCode, ex.Message);
            }
            return strReturnVal;
        }

        public string Delete(string Request, string RequestOption, string Module)
        {
            string strReturnVal = "";
            try
            {
                IReflectionService ad = new ServiceAdapter();
                strReturnVal = ad.Delete(Request, RequestOption, Module);
            }
            catch (CreateException ex)
            {
                HandleException(ex, ex.ErrorCode, ex.Message);
            }
            return strReturnVal;
        }

        public string Delete(int Request, string RequestOption, string Module)
        {
            string strReturnVal = "";
            try
            {
                IReflectionService ad = new ServiceAdapter();
                strReturnVal = ad.Delete(Request, RequestOption, Module);
            }
            catch (CreateException ex)
            {
                HandleException(ex, ex.ErrorCode, ex.Message);
            }
            return strReturnVal;
        }

        public byte[] GetData(string Request, string RequestOption, string RequestPath)
        {
            byte[] strReturnVal = null;
            try
            {
                IReflectionService ad = new ServiceAdapter();
                strReturnVal = ad.GetData(Request, RequestOption, RequestPath);
            }
            catch (CreateException ex)
            {
               HandleException(ex, ex.ErrorCode, ex.Message);
            }

            return strReturnVal;
        }

        public byte[] GetDataWithCompression(string Request, string RequestOption, string Module, string strType, int intValue, string strValue, string doc_code, string comp_code, string location_Id, string add_by, string request1, string request2, string request3, string request4, string request5)
        {
            byte[] strReturnVal = null;
            try
            {
                IReflectionService ad = new ServiceAdapter();
                strReturnVal = ad.GetDataWithCompression(Request, RequestOption, Module, strType, intValue, strValue, doc_code, comp_code, location_Id, add_by, request1, request2, request3, request4, request5);
            }
            catch (CreateException ex)
            {
                HandleException(ex, ex.ErrorCode, ex.Message);
            }

            return strReturnVal;
        }

        public byte[] GetDataWithCompression(string Request, string RequestOption, string Module, string strType, int intValue, string strValue)
      {
            byte[] strReturnVal = null;
            try
            {
                IReflectionService ad = new ServiceAdapter();
                strReturnVal = ad.GetDataWithCompression(Request, RequestOption, Module, strType, intValue, strValue);
            }
            catch (CreateException ex)
            {
                HandleException(ex, ex.ErrorCode, ex.Message);
            }

            return strReturnVal;
        }

        public byte[] UploadFiles(byte[] RequestStream, string Request, string RequestOption, string RequestPath, string FileName, string client, string comp_code)
        {
            byte[] strReturnVal = null;
            try
            {
                IReflectionService ad = new ServiceAdapter();
                strReturnVal = ad.UploadFiles(RequestStream, Request, RequestOption, RequestPath, FileName, client, comp_code);
            }
            catch (CreateException ex)
            {
                HandleException(ex, ex.ErrorCode, ex.Message);
            }
            return strReturnVal;
        }
        public byte[] DownloadFiles(string Request, string RequestOption, string RequestPath, string FileName, string client, string comp_code)
        {
            byte[] strReturnVal = null;
            try
            {
                IReflectionService ad = new ServiceAdapter();
                strReturnVal = ad.DownloadFiles(Request, RequestOption, RequestPath, FileName, client, comp_code);
            }
            catch (CreateException ex)
            {
                HandleException(ex, ex.ErrorCode, ex.Message);
            }
            return strReturnVal;
        }
        public string DeleteFiles(string Request, string RequestOption, string RequestPath, string FileName, string client, string comp_code)
        {
            string strReturnVal = null;
            try
            {
                IReflectionService ad = new ServiceAdapter();
                strReturnVal = ad.DeleteFiles(Request, RequestOption, RequestPath, FileName, client, comp_code);
            }
            catch (CreateException ex)
            {
                HandleException(ex, ex.ErrorCode, ex.Message);
            }
            return strReturnVal;
        }

        private static void HandleException(Exception ex, int errorId, string errorMessage)
        {

            ServiceFaultContract fault = new ServiceFaultContract();
            fault.ErrorID = errorId;
            fault.ErrorMessage = "Reflection Error Message: " + errorMessage;
            
          throw new FaultException<ServiceFaultContract>(fault, new FaultReason(new FaultReasonText(fault.ErrorMessage, CultureInfo.CurrentCulture)));

        }

    }
}
