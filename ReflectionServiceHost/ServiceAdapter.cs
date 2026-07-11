using Reflection.BusinessLogic;
using System;
using System.IO;
using System.Reflection;

namespace ReflectionServiceHost
{
    public class ServiceAdapter : IReflectionService
    {
        public string Insert(string Request, string RequestOption, string Module, string strType, int intValue, string strValue)
        {

            try
            {
                ReflectionWebServiceBL BL = new ReflectionWebServiceBL();
                return BL.Insert(Request, RequestOption, Module, strType, intValue, strValue);
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            
        }
        public byte[] InsertWithCompression(byte[] RequestStream, string Request, string RequestOption, string RequestPath)
        {
            byte[] byteReturnValue = null;
            try
            {
                /* // -- Code by kalpesh
                string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin\\Reflection.BusinessLogic.dll"); // this one is path option
                Assembly assembly = Assembly.LoadFile(path1);
                Type type = assembly.GetType(RequestPath);
                if (type != null)
                {
                    string RequestData = ReflectionComprassion.DeCompressData(RequestStream);
                    dynamic instance = Activator.CreateInstance(type);
                    byteReturnValue = instance.Insert(RequestStream, RequestData, RequestOption);
                    byteReturnValue = ReflectionComprassion.CompressByteData(byteReturnValue);
                }
                // -- Code ends here */
                string RequestData = ReflectionComprassion.DeCompressData(RequestStream);
                byte[] strReturnValue = ReflectionServiceRepository.InvokeInsertMethod(null, RequestData, RequestOption, RequestPath);
                byteReturnValue = ReflectionComprassion.CompressByteData(strReturnValue);
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return byteReturnValue;
        }
        public string Update(string Request, string RequestOption, string Module, string strType, int intValue, string strValue)
        {
            try
            {
                ReflectionWebServiceBL BL = new ReflectionWebServiceBL();
                return BL.Update(Request, RequestOption, Module, strType, intValue, strValue);
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
        }
        public byte[] UpdateWithCompression(byte[] RequestStream, string Request, string RequestOption, string RequestPath)
        {
            byte[] byteReturnValue = null;
            try
            {
                /* // -- Code by kalpesh
               string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin\\Reflection.BusinessLogic.dll"); 
               Assembly assembly = Assembly.LoadFile(path1);
               Type type = assembly.GetType(RequestPath);
               if (type != null)
               {
                   string RequestData = ReflectionComprassion.DeCompressData(RequestStream);
                   dynamic instance = Activator.CreateInstance(type);
                   byteReturnValue = instance.Update(RequestStream, RequestData, RequestOption);
                   byteReturnValue = ReflectionComprassion.CompressByteData(byteReturnValue);
               }
               // -- Code ends here */

                string RequestData = ReflectionComprassion.DeCompressData(RequestStream);
                byte[] strReturnValue = ReflectionServiceRepository.InvokeUpdateMethod(null, RequestData, RequestOption, RequestPath);
                byteReturnValue = ReflectionComprassion.CompressByteData(strReturnValue);
            }
            catch (CreateException ex)
           {
               throw new CreateException(ex.Message, ex);
           }
           return byteReturnValue;
       }
        public string Delete(string Request, string RequestOption, string Module)
       {
           try
           {
               ReflectionWebServiceBL BL = new ReflectionWebServiceBL();
               return BL.Delete(Request, RequestOption, Module);
           }
           catch (CreateException ex)
           {
               throw new CreateException(ex.Message, ex);
           }
       }
        public string Delete(int Request, string RequestOption, string Module)
       {
           try
           {
               ReflectionWebServiceBL BL = new ReflectionWebServiceBL();
               return BL.Delete(Request, RequestOption, Module);
           }
           catch (CreateException ex)
           {
               throw new CreateException(ex.Message, ex);
           }
       }
        public byte[] GetData(string Request, string RequestOption, string RequestPath)
       {
           byte[] byteReturnValue = null;
           try
           {
               /* // -- Code By Kalpesh
               string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin\\Reflection.BusinessLogic.dll"); // this one is path option
               Assembly assembly = Assembly.LoadFile(path1);
               Type type = assembly.GetType(RequestPath);
               if (type != null)
               {
                   dynamic instance = Activator.CreateInstance(type);
                   byteReturnValue = instance.GetData(Request, RequestOption);
                   byteReturnValue = ReflectionComprassion.CompressByteData(byteReturnValue);
               }
               // -- Code ends here */
                byte[] response = ReflectionServiceRepository.InvokeGetDataMethod(Request, RequestOption, RequestPath);
                byteReturnValue = ReflectionComprassion.CompressByteData(response);
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return byteReturnValue;
        }

        public byte[] GetDataWithCompression(string Request, string RequestOption, string Module, string strType, int intValue, string strValue, string doc_code, string comp_code, string location_Id, string add_by, string request1, string request2, string request3, string request4, string request5)
        {
            byte[] byteReturnValue = null;
            try
            {
                ReflectionWebServiceBL BL = new ReflectionWebServiceBL();
                string strReturnValue = BL.GetData(Request, RequestOption, Module, strType, intValue, strValue, doc_code, comp_code, location_Id, add_by, request1, request2, request3, request4, request5);
                byteReturnValue = ReflectionComprassion.CompressData(strReturnValue);
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return byteReturnValue;
        }

        public byte[] GetDataWithCompression(string Request, string RequestOption, string Module, string strType, int intValue, string strValue)
        {
            byte[] byteReturnValue = null;
            try
            {
                ReflectionWebServiceBL BL = new ReflectionWebServiceBL();
                string strReturnValue = BL.GetData(Request, RequestOption, Module, strType, intValue, strValue);
                byteReturnValue = ReflectionComprassion.CompressData(strReturnValue);
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return byteReturnValue;
        }

        public byte[] UploadFiles(byte[] RequestStream, string Request, string RequestOption, string RequestPath, string FileName, string client, string comp_code)
        {
            byte[] strReturnVal = null;
            try
            {
                byte[] RequestData = ReflectionComprassion.DeCompressByteData(RequestStream);
                ReflectionFileHandlingServices rfs = new ReflectionFileHandlingServices();
                //byte[] byteReturnValue = rfs.UploadFiles(RequestData, Request, RequestOption, RequestPath, FileName);
                //strReturnVal = ReflectionComprassion.CompressByteData(byteReturnValue);
                string byteReturnValue = rfs.UploadFiles(RequestData, Request, RequestOption, RequestPath, FileName, client, comp_code);
                strReturnVal = ReflectionComprassion.CompressData(byteReturnValue);
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strReturnVal;
        }
        public byte[] DownloadFiles(string Request, string RequestOption, string RequestPath, string FileName, string client, string comp_code)
        {
            byte[] Response = null;
            try
            {
                byte[] strReturnVal = ReflectionFileHandlingServices.DownloadFiles(Request, RequestOption, RequestPath, FileName, client, comp_code);
                Response = ReflectionComprassion.CompressByteData(strReturnVal);
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return Response;
        }
        public string DeleteFiles(string Request, string RequestOption, string RequestPath, string FileName, string client, string comp_code)
        {
            string strReturnVal = null;
            try
            {
                ReflectionFileHandlingServices obj = new ReflectionFileHandlingServices();
                strReturnVal = obj.DeleteFiles(Request, RequestOption, RequestPath, FileName, client, comp_code);
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            return strReturnVal;
        }

    }

}