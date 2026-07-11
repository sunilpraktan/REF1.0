using Dapper;
using Reflection.EF;
using Reflection.EF.Admin;
using Reflection.EF.Communication;
using Reflection.EF.QMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{ 
    class QMS_M007BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        QMS_M007 MasterEntity = new QMS_M007();
        MultipleContext_QMS_M007 MC = new MultipleContext_QMS_M007();

        public QMS_M007BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M007BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_QMS_M007 MC = new MultipleContext_QMS_M007();
            string RequestOption = RequestValue.Split('!')[0];

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M007_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var BackFlipList = reader.Read<QMS_M007Flip>().ToList();
                            MC.FlipGridData= BackFlipList.ToList();

                           
                        }
                        else if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var MasterList = reader.Read<QMS_M007>().ToList();
                            MC.MasterEntity = MasterList.ToList();

                            var Attachment = reader.Read<COM_T003>().ToList();
                            MC.Attachment = Attachment.ToList();
                        }
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
        public string Insert(string Request)
        {
            MultipleContext_QMS_M007 MC = new MultipleContext_QMS_M007();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M007_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlipList = reader.Read<QMS_M007Flip>().ToList();
                    MC.FlipGridData = BackFlipList.ToList();

                    var MasterData = reader.Read<QMS_M007>().ToList();
                    List<QMS_M007> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.FlipGridData);

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
            MultipleContext_QMS_M007 MC = new MultipleContext_QMS_M007();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M007_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlipList = reader.Read<QMS_M007Flip>().ToList();
                    MC.FlipGridData = BackFlipList.ToList();

                    var MasterData = reader.Read<QMS_M007>().ToList();
                    List<QMS_M007> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                   
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
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
    }

    public class MultipleContext_QMS_M007
    {
        public List<QMS_M007> MasterEntity { get; set; }
        public List<QMS_M007Flip> FlipGridData { get; set; }
        public List<COM_T003> Attachment { get; set; }
    }
}
