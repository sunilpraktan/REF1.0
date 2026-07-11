    using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ReflectionServiceHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReflectionService" in both code and config file together.
    [ServiceContract]
    public interface IReflectionService
    {

        [OperationContract]
        [FaultContract(typeof(ServiceFaultContract))]
        string Insert(string Request, string RequestOption, string Module, string strType, int intValue, string strValue);

        [OperationContract]
        [FaultContract(typeof(ServiceFaultContract))]
        byte[] InsertWithCompression(byte[] RequestStream, string Request, string RequestOption, string RequestPath);


        [OperationContract]
        [FaultContract(typeof(ServiceFaultContract))]
        string Update(string Request, string RequestOption, string Module, string strType, int intValue, string strValue);

        [OperationContract]
        [FaultContract(typeof(ServiceFaultContract))]
        byte[] UpdateWithCompression(byte[] RequestStream, string Request, string RequestOption,string RequestPath);


        [OperationContract(Name = "DeleteWithString")]
        [FaultContract(typeof(ServiceFaultContract))]
        string Delete(string Request, string RequestOption, string Module);

        [OperationContract(Name="DeleteWithNumeric")]
        [FaultContract(typeof(ServiceFaultContract))]
        string Delete(int Request, string RequestOption, string Module);

        [OperationContract(Name = "GetData")]
        [FaultContract(typeof(ServiceFaultContract))]
        byte[] GetData(string Request, string RequestOption, string RequestPath);

        [OperationContract(Name = "GetDataWithCompression1")]
        [FaultContract(typeof(ServiceFaultContract))]
        byte[] GetDataWithCompression(string Request, string RequestOption, string Module, string strType, int intValue, string strValue, string doc_code, string comp_code, string location_Id, string add_by, string request1, string request2, string request3, string request4, string request5);

        [OperationContract(Name = "GetDataWithCompression")]
        [FaultContract(typeof(ServiceFaultContract))]
        byte[] GetDataWithCompression(string Request, string RequestOption, string Module,string strType,int intValue,string strValue);

        [OperationContract(Name = "UploadFiles")]
        [FaultContract(typeof(ServiceFaultContract))]
        byte[] UploadFiles(byte[] RequestStream, string Request, string RequestOption, string RequestPath, string FileName, string client, string comp_code);

        [OperationContract(Name = "DownloadFiles")]
        [FaultContract(typeof(ServiceFaultContract))]
        byte[] DownloadFiles(string Request, string RequestOption, string RequestPath, string FileName, string client, string comp_code);

        [OperationContract(Name = "DeleteFiles")]
        [FaultContract(typeof(ServiceFaultContract))]
        string DeleteFiles(string Request, string RequestOption, string RequestPath, string FileName, string client, string comp_code);

    }
}
