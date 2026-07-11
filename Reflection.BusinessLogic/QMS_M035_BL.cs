using Dapper;
using Reflection.EF;
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
   public class QMS_M035_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        QMS_M035 masterEntity = new QMS_M035();
        MultipleContext_QMS_M035 MC = new MultipleContext_QMS_M035();

        public QMS_M035_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M035_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            try
            {
                string RequestOption = RequestValue.Split('!')[0];
                string strReturnData = "";

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M035_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var severityData = reader.Read<QMS_M038_P>().ToList();
                        MC.SeverityMaster = severityData.ToList();

                        var BackFlip = reader.Read<QMS_M035_Flip>().ToList();
                        MC.BackFlipData = BackFlip.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var MasterData = reader.Read<QMS_M035>().ToList();
                        MC.MasterEntity = MasterData.ToList();

                        var ItemsData = reader.Read<QMS_M035_A>().ToList();
                        MC.ItemsEntity = ItemsData.ToList();
                    }
                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    return strReturnData;
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
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M035_Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var BackFlip = reader.Read<QMS_M035_Flip>().ToList();
                    MC.BackFlipData = BackFlip.ToList();

                    var masterData = reader.Read<QMS_M035>().ToList();
                    List<QMS_M035> MasterList = masterData.ToList();
                    if (MasterList.Count > 0)
                    {
                        masterEntity = MasterList[0];
                    }
                    var ItemsData = reader.Read<QMS_M035_A>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();

                    masterEntity.XmlDataDocument_QMS_M035_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);
                    masterEntity.XmlDataDocument_QMS_M035_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);

                }
                string strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
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
            try
            {
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M035_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlip = reader.Read<QMS_M035_Flip>().ToList();
                    MC.BackFlipData = BackFlip.ToList();

                    var masterData = reader.Read<QMS_M035>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    var ItemData = reader.Read<QMS_M035_A>().ToList();
                    MC.ItemsEntity = ItemData.ToList();

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_QMS_M035_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);
                    masterEntity.XmlDataDocument_QMS_M035_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                }
                strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
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

    public class MultipleContext_QMS_M035
    {
        public List<QMS_M038_P> SeverityMaster { get; set; }
        public List<QMS_M035_Flip> BackFlipData { get; set; }
        public List<QMS_M035> MasterEntity { get; set; }
        public List<QMS_M035_A> ItemsEntity { get; set; }
    }
}
