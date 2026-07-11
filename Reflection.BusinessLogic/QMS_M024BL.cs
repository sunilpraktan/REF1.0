using Dapper;
using Reflection.EF;
using Reflection.EF.Communication;
using Reflection.EF.QMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Reflection.BusinessLogic
{
    public class QMS_M024BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        QMS_M024 MasterEntity = new QMS_M024();
        MultipleContext_QMS_M024 MC = new MultipleContext_QMS_M024();
        public QMS_M024BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M024BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M024Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<QMS_M024Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var masterList = reader.Read<QMS_M024>().ToList();
                    List<QMS_M024> MasterList = masterList.ToList();
                    if (MasterList.Count > 0)
                    {
                        MasterEntity = MasterList[0];
                    }
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M024Update", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<QMS_M024Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var masterList = reader.Read<QMS_M024>().ToList();
                    List<QMS_M024> MasterList = masterList.ToList();
                    if (MasterList.Count > 0)
                    {
                        MasterEntity = MasterList[0];
                    }
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = 0; //conn.Execute("QMS_M024Delete", new { @srNo = Request }, commandType: CommandType.StoredProcedure);
                    return intOut.ToString();
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            try
            {
                string RequestOption = RequestValue.Split('!')[0];
                string strReturnData = "";

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M024LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var calview = reader.Read<QMS_M024Flip>().ToList();
                        MC.DocumentDataFlipGrid = calview.ToList();                      
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var masterEntity = reader.Read<QMS_M024>().ToList();
                        MC.MasterEntity = masterEntity.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();
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
        public class MultipleContext_QMS_M024
        {
            public List<QMS_M024Flip> DocumentDataFlipGrid { get; set; } //DataGridCollection        
            public List<QMS_M024> MasterEntity { get; set; }
            public List<COM_T003> Attachment { get; set; } // Attachment Collection
        }
    }
}
