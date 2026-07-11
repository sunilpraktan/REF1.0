using Reflection.EF;
using Dapper;
using Reflection.EF.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF.Communication;
using Reflection.EF.QMS;

namespace Reflection.BusinessLogic
{
    class QMS_M006BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        QMS_M006 MasterEntity = new QMS_M006();
        MultipleContext_QMS_M006 MC = new MultipleContext_QMS_M006();

        public QMS_M006BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M006BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_QMS_M006 MC = new MultipleContext_QMS_M006();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M006_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var flipGridData = reader.Read<QMS_M006Flip>().ToList();
                        MC.FlipGridData = flipGridData.ToList();

                    }
                    if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var masterData = reader.Read<QMS_M006>().ToList();
                        MC.MasterEntity = masterData.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();
                    }

                }
                strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
        public string Insert(string Request)
        {
            MultipleContext_QMS_M006 MC = new MultipleContext_QMS_M006();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M006_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlipList = reader.Read<QMS_M006Flip>().ToList();
                    MC.FlipGridData = BackFlipList.ToList();

                    var MasterData = reader.Read<QMS_M006>().ToList();
                    MC.MasterEntity = MasterData.ToList();

                    MasterEntity = MC.MasterEntity[0];
 
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
            MultipleContext_QMS_M006 MC = new MultipleContext_QMS_M006();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M006_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<QMS_M006>().ToList();
                    List<QMS_M006> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var BackFlipList = reader.Read<QMS_M006Flip>().ToList();
                    MC.FlipGridData = BackFlipList.ToList();

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

    public class MultipleContext_QMS_M006
    {
        public List<QMS_M006> MasterEntity { get; set; }
        public List<QMS_M006Flip> FlipGridData { get; set; }
        public List<COM_T003> Attachment { get; set; }
    }
}
