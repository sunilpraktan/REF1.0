using Dapper;
using Reflection.EF;
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
   public class QMS_M030_G_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        QMS_M030_G masterEntity = new QMS_M030_G();
        MultipleContext_QMS_M030_G MC = new MultipleContext_QMS_M030_G();

        public QMS_M030_G_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M030_G_BL()
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
                    var reader = conn.QueryMultiple("QMS_M030_G_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var BackFlip = reader.Read<QMS_M030_G_Flip>().ToList();
                        MC.BackFlipData = BackFlip.ToList();

                        var qualification = reader.Read<QMS_M022_P>().ToList();
                        MC.QualificationMaster = qualification.ToList();
 
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var MasterData = reader.Read<QMS_M030_G>().ToList();
                        MC.MasterEntity = MasterData.ToList();

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
                    var reader = conn.QueryMultiple("QMS_M030_G_Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var BackFlip = reader.Read<QMS_M030_G_Flip>().ToList();
                    MC.BackFlipData = BackFlip.ToList();

                    var masterData = reader.Read<QMS_M030_G>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_QMS_M030_G_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);


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
                    var reader = conn.QueryMultiple("QMS_M030_G_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlip = reader.Read<QMS_M030_G_Flip>().ToList();
                    MC.BackFlipData = BackFlip.ToList();

                    var masterData = reader.Read<QMS_M030_G>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_QMS_M030_G_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);
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

    public class MultipleContext_QMS_M030_G
    {
        public List<QMS_M030_G_Flip> BackFlipData { get; set; }
        public List<QMS_M030_G> MasterEntity { get; set; }
        public List<QMS_M022_P> QualificationMaster { get; set; }
        public List<COM_T003> Attachment { get; set; }

    }
}
