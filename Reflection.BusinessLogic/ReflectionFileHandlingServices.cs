using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Reflection.BusinessLogic
{
    public class ReflectionFileHandlingServices : ReflectionBusinessLogic
    {
        private static string connectionString;
        //public List<COM_T003> Attachments { get; set; }
        MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();
        public ReflectionFileHandlingServices(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
            //connectionString = System.Configuration.ConfigurationManager.AppSettings["strConnectionString"];
        }
        public ReflectionFileHandlingServices()
        {
            connectionString = base.ReflectionConnectionString;
            //connectionString = System.Configuration.ConfigurationManager.AppSettings["strConnectionString"];
        }
        public string UploadFiles(byte[] RequestStream, string Request, string RequestOption, string RequestPath, string FileName, string client, string comp_code)
        {
            string response = null;
            try
            {
                //string folderName = "ERP_Documents/" + RequestOption;
                string folderName = "";
                if (RequestOption.Split(',').Length > 1)
                {
                    folderName = "ERP_Documents/" + client + "/" + comp_code + "/" + RequestOption.Split(',')[0] + "/" + RequestOption.Split(',')[1];
                }
                else if (RequestOption.Split(',').Length == 1)
                {
                    folderName = "ERP_Documents/" + client + "/" + comp_code + "/" + RequestOption.Split(',')[0];
                }

                string PATH = HttpContext.Current.Server.MapPath("~/" + folderName);
                string filePath = PATH + "/" + FileName;
                if (!Directory.Exists(PATH))
                {
                    Directory.CreateDirectory(PATH);
                }
                MemoryStream stream = new MemoryStream(RequestStream);
                var fileStream = new FileStream(filePath, FileMode.CreateNew, FileAccess.ReadWrite);
                stream.CopyTo(fileStream);
                fileStream.Dispose();

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@doc_no", RequestOption.Split(',')[0].Replace("--", "/"), DbType.String, ParameterDirection.Input, 20);
                    param.Add("@file_name", FileName, DbType.String, null, 150);
                    if (RequestOption.Split(',').Length > 1)
                    {
                        param.Add("@url", RequestOption.Split(',')[0] + "/" + RequestOption.Split(',')[1] + "/" + FileName, DbType.String, null, 150);
                        param.Add("@resource_name", RequestOption.Split(',')[1], DbType.String, ParameterDirection.Input, 50);
                    }
                    else if (RequestOption.Split(',').Length == 1)
                    {
                        param.Add("@url", RequestOption + "/" + FileName, DbType.String, null, 150);
                        param.Add("@resource_name", null, DbType.String, ParameterDirection.Input, 50);
                    }

                    param.Add("@file_type", Path.GetExtension(filePath), DbType.String, null, 150);
                    param.Add("@file_size", null, DbType.String, null, 150);
                    param.Add("@UserId", null, DbType.String, ParameterDirection.Input, 20);
                    param.Add("@client", client, DbType.String, ParameterDirection.Input, 10);
                    param.Add("@comp_code", comp_code, DbType.String, ParameterDirection.Input, 10);

                    var reader = conn.QueryMultiple("AddFileData", param, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var documentDataFlipGrid = reader.Read<COM_T003>().ToList();
                    List<COM_T003> _FileListObj = documentDataFlipGrid.ToList();
                    //response = ObjectSerializationService<List<COM_T003>>.ObjectToStreamGeneric(_FileListObj);
                    //response = ObjectSerializationService<List<COM_T003>>.ObjectToStream(_FileListObj);

                    response = ObjectSerializationService.ObjectToXML(_FileListObj);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public static byte[] DownloadFiles(string Request, string RequestOption, string RequestPath, string FileName, string client, string comp_code)
        {
            byte[] response = null;
            try
            {
                string folderName = "ERP_Documents/" + client + "/" + comp_code + "/" + RequestOption;
                string PATH = HttpContext.Current.Server.MapPath("~/" + folderName);
                string filePath = PATH + "/" + FileName;

                if (RequestOption == "RDLC")
                {
                    filePath = RequestPath;
                }
                else
                {
                    folderName = "ERP_Documents/" + client + "/" + comp_code + "/" + RequestOption;
                    PATH = HttpContext.Current.Server.MapPath("~/" + folderName);
                    filePath = PATH + "/" + FileName;
                }

                if (File.Exists(filePath))
                {
                    response = File.ReadAllBytes(filePath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public string DeleteFiles(string Request, string RequestOption, string RequestPath, string FileName, string client, string comp_code)
        {

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int response = conn.Execute("COM_T003Delete", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    string folderName = "ERP_Documents/" + client + "/" + comp_code + "/" + FileName;
                    string PATH = HttpContext.Current.Server.MapPath("~/" + folderName);

                    if (File.Exists(PATH))
                    {
                        File.Delete(PATH);
                    }
                    string Folder = "ERP_Documents/" + client + "/" + comp_code + "/" + RequestOption;
                    Folder = HttpContext.Current.Server.MapPath("~/" + Folder);
                    if (!Directory.EnumerateFiles(Folder).Any())
                    {
                        Directory.Delete(Folder, false);
                    }
                    return response.ToString();
                }

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

        public string GetData1(string RequestValue, string RequestOption)
        {
            string RequestParameter = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("GetAttachmentsDetails", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    if (RequestParameter == "GetAllFiles")
                    {
                        var AttachmentVar = reader.Read<COM_T003>().ToList();
                        MCAttachments.Attachments = AttachmentVar.ToList();
                        strReturnData = ObjectSerializationService.ObjectToXML(MCAttachments.Attachments);
                        return strReturnData;
                    }
                }
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
        public byte[] GetData(string RequestValue, string RequestOption)
        {
            string RequestParameter = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("GetAttachmentsDetails", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    if (RequestParameter == "GetAllFiles")
                    {
                        var AttachmentVar = reader.Read<COM_T003>().ToList();
                        MCAttachments.Attachments = AttachmentVar.ToList();
                        strReturnData = ObjectSerializationService.ObjectToXML(MCAttachments.Attachments);
                        return ObjectSerializationService<MultipleContext_Attachments>.ObjectToStream(MCAttachments);
                    }
                }
                return ObjectSerializationService<MultipleContext_Attachments>.ObjectToStream(MCAttachments);
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("GetAttachmentsDetails", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                    {
                        MCAttachments.Attachments = reader.Read<COM_T003>().ToList();
                        strReturnData = ObjectSerializationService.ObjectToXML(MCAttachments);
                        return strReturnData;
                    }
                }
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

    public class MultipleContext_Attachments
    {
        public List<COM_T003> Attachments { get; set; }
    }
}
