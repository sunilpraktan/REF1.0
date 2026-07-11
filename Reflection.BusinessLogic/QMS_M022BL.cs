using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.QMS;
using Dapper;
using Reflection.EF;

namespace Reflection.BusinessLogic
{
    public class QMS_M022BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        QMS_M022 masterEntity = new QMS_M022();
        MultipleContext_QMS_M022 MC = new MultipleContext_QMS_M022();

        public QMS_M022BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M022BL()
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
                    var reader = conn.QueryMultiple("QMS_M022_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var BackFlip = reader.Read<QMS_M022_Flip>().ToList();
                        MC.BackFlipData = BackFlip.ToList();

                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var Masterdata = reader.Read<QMS_M022>().ToList();
                        MC.MasterEntity = Masterdata.ToList();
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
                    var reader = conn.QueryMultiple("QMS_M022_Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var BackFlip = reader.Read<QMS_M022_Flip>().ToList();
                    MC.BackFlipData = BackFlip.ToList();

                    var masterData = reader.Read<QMS_M022>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_QMS_M022_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);
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
                    var reader = conn.QueryMultiple("QMS_M022_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlip = reader.Read<QMS_M022_Flip>().ToList();
                    MC.BackFlipData = BackFlip.ToList();

                    var masterData = reader.Read<QMS_M022>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_QMS_M022_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);
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

    public class MultipleContext_QMS_M022
    {
        public List<QMS_M022_Flip> BackFlipData { get; set; }
        public List<QMS_M022> MasterEntity { get; set; }
    }
}

