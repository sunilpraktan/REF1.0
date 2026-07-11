using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.WebServices.Gateway.ReflectionWebExecuter;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Configuration;
//using Salar.Bois;

namespace Reflection.WebServices.Gateway
{
    public class WebServiceRepository<TDomainObject> : IWebMethods<TDomainObject>
    {
        ReflectionWebExecuter.ReflectionServiceClient proxy = new ReflectionWebExecuter.ReflectionServiceClient();
        ObjectSerializationService objSerialization = new ObjectSerializationService();
        //proxy.InnerChannel.OperationTimeout = new TimeSpan(0, 30, 0);
        #region · Web Methods ·
        public string Save<T>(TDomainObject domainObj, string RequestOption, string Module)
        {
            string Response="";
            try
            {
                string request = objSerialization.ObjectToXML(domainObj);
                proxy.InnerChannel.OperationTimeout = new TimeSpan(0, 30, 0);
                Response = proxy.Insert(request, RequestOption, Module,"",0,"");
            }
            catch (FaultException<ServiceFaultContract> ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Response;
        }
        public TDomainObject SaveWithReturnDomainObject<T>(TDomainObject domainObj, string Request, string RequestOption, string RequestPath)
        {
            try
            {
                string RequestData = objSerialization.ObjectToXML(domainObj);
                byte[] RequestBytes = ReflectionComprassion.CompressData(RequestData);
                byte[] Response = proxy.InsertWithCompression(RequestBytes, Request, RequestOption, RequestPath);
                byte[] ResponseData = ReflectionComprassion.DeCompressByteData(Response);
                domainObj = (TDomainObject)ObjectSerializationService<TDomainObject>.StreamToObject<TDomainObject>(domainObj, ResponseData);

            }
            catch (FaultException<ServiceFaultContract> ex)
            {
               
               // throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
               // throw new Exception(ex.Message);
            }
            return domainObj;
        }

        public TDomainObject SaveWithReturnDomainObject<T>(TDomainObject domainObj, string RequestOption, string Module)
        {
            string Response = "";
            try
            {
                string request = objSerialization.ObjectToXML(domainObj);
                
                Response = proxy.Insert(request, RequestOption, Module, "", 0, "");
                domainObj = (TDomainObject)objSerialization.XMLToObject(Response, domainObj);
            }
            catch (FaultException<ServiceFaultContract> ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return domainObj;
        }

        public string Update<T>(TDomainObject domainObj, string RequestOption, string Module)
        {
            string Response = "";
            try
            {
                string request = objSerialization.ObjectToXML(domainObj);
                Response = proxy.Update(request, RequestOption, Module, "", 0, "");
            }
            catch (FaultException<ServiceFaultContract> ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Response;
        }

        public TDomainObject UpdateWithReturnDomainObject<T>(TDomainObject domainObj, string RequestOption, string Module)
        {
            string Response = "";
            try
            {
                string request = objSerialization.ObjectToXML(domainObj);
                Response = proxy.Update(request, RequestOption, Module, "", 0, "");
                domainObj = (TDomainObject)objSerialization.XMLToObject(Response, domainObj);
            }
            catch (FaultException<ServiceFaultContract> ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return domainObj;
        }
        public TDomainObject UpdateWithReturnDomainObject<T>(TDomainObject domainObj, string Request, string RequestOption, string RequestPath)
        {
            try
            {
                string RequestData = objSerialization.ObjectToXML(domainObj);
                byte[] RequestBytes = ReflectionComprassion.CompressData(RequestData);
                byte[] Response = proxy.UpdateWithCompression(RequestBytes, Request, RequestOption, RequestPath);
                byte[] ResponseData = ReflectionComprassion.DeCompressByteData(Response);
                domainObj = (TDomainObject)ObjectSerializationService<TDomainObject>.StreamToObject<TDomainObject>(domainObj, ResponseData);
            }
            catch (FaultException<ServiceFaultContract> ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return domainObj;
        }

        public string Delete(string request, string RequestOption, string Module)
        {
            string Response = proxy.DeleteWithString(request, RequestOption, Module);
            return Response;
        }

        public string Delete(int request, string RequestOption, string Module)
        {
           string Response = proxy.DeleteWithNumeric(request, RequestOption, Module);
           return Response;
        }

        public string GetData(string Request, string RequestOption, string Module)
        {
            throw new NotImplementedException();
        }
        public TDomainObject GetData<T>(TDomainObject domainObj, string Request, string RequestOption, string RequestPath)
        {
            byte[] Response = null;
            try
            {
                Response = proxy.GetData(Request, RequestOption, RequestPath);
                byte[] bitData = ReflectionComprassion.DeCompressByteData(Response);
                domainObj = (TDomainObject)ObjectSerializationService<TDomainObject>.StreamToObject<TDomainObject>(domainObj,bitData);
            }
            catch (FaultException<ServiceFaultContract> ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return domainObj;
        }
        public TDomainObject GetDataWithReturnDomainObject<T>(TDomainObject domainObj,string Request, string RequestOption, string Module, string strType, int intValue, string strValue)
        {
            byte[] Response = null;
            try
            {
                Response = proxy.GetDataWithCompression(Request, RequestOption, Module, strType, intValue, strValue);
                string str = ReflectionComprassion.DeCompressData(Response);
                domainObj = (TDomainObject)objSerialization.XMLToObject(str, domainObj);
            }
            catch (FaultException<ServiceFaultContract> ex)
            {
                 throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
            return domainObj;
        }
        public async Task<TDomainObject> GetDataWithReturnDomainObjectASynchronus<T>(TDomainObject domainObj, string Request, string RequestOption, string Module, string strType, int intValue, string strValue)
        {
            byte[] Response = null;
            try
            {
                Response = await proxy.GetDataWithCompressionAsync(Request, RequestOption, Module, strType, intValue, strValue);
                string str = ReflectionComprassion.DeCompressData(Response);
                domainObj = (TDomainObject)objSerialization.XMLToObject(str, domainObj);
            }
            catch (FaultException<ServiceFaultContract> ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return domainObj;
        }

        #endregion 

        public List<TDomainObject> GetDataWithReturnDomainObject(string request, string RequestOption, string Module)
        {
            throw new NotImplementedException();
        }

        public List<TDomainObject> GetDataWithReturnDomainObject<T>(List<TDomainObject> domainObj, string Request, string RequestOption, string Module)
        {
            byte[] Response = null;
            try
            {
                Response = proxy.GetDataWithCompression(Request, RequestOption, Module, "", 0, "");
                string str = ReflectionComprassion.DeCompressData(Response);
                domainObj = (List<TDomainObject>)objSerialization.XMLToObject(str, domainObj);
            }
            catch (FaultException<ServiceFaultContract> ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return domainObj;
        }

        public TDomainObject UploadFiles<T>(TDomainObject domainObj, byte[] RequestStream, string Request, string RequestOption, string RequestPath,string client,string comp_code)
        {
            try
            {
                //string RequestData = objSerialization.ObjectToXML(Request);
                byte[]  Response = proxy.UploadFiles(RequestStream, Request, RequestOption, RequestPath, Request, client, comp_code);
                //byte[] ResponseData = ReflectionComprassion.DeCompressByteData(Response);
                //domainObj = (TDomainObject)ObjectSerializationService<TDomainObject>.StreamToObject<TDomainObject>(domainObj, ResponseData);
                string str = ReflectionComprassion.DeCompressData(Response);
                domainObj = (TDomainObject)objSerialization.XMLToObject(str, domainObj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return domainObj;
        }

        public byte[] DownloadFile(string Request, string RequestOption, string RequestPath, string client, string comp_code)
        {
            byte[] ResponseData = null;
            try
            {
                byte[] Response = proxy.DownloadFiles(Request, RequestOption, RequestPath, Request, client, comp_code);
                ResponseData = ReflectionComprassion.DeCompressByteData(Response);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return ResponseData;
        }

        public string DeleteFiles(string Request, string RequestOption, string RequestPath, string FileName, string client, string comp_code)
        {            
            try
            {
                string Response = proxy.DeleteFiles(Request, RequestOption, RequestPath, FileName, client, comp_code);
                return Response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public string Save<T>(object divAsSolist, string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public string GetEndpointAddress() // Get Report Path
        {
            string address = null;
            ClientSection clientSettings = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;
            foreach (ChannelEndpointElement endpoint in clientSettings.Endpoints)
            {
                address = endpoint.Address.AbsoluteUri;
                address = address.Replace("ReflectionService.svc", "Reports");
            }

            return address;
        }
        public string GetRootDirectory() // Get Report Path
        {
            string address = null;
            ClientSection clientSettings = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;
            foreach (ChannelEndpointElement endpoint in clientSettings.Endpoints)
            {
                address = endpoint.Address.AbsoluteUri;
                address = address.Replace("ReflectionService.svc", "");
            }

            return address;
        }
    }
}

