using Dapper;
using Reflection.EF;
using Reflection.EF.Admin;
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
    public class QMS_M009_F_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_QMS_M009_F MC = new MultipleContext_QMS_M009_F();
        QMS_M009_F masterEntity = new QMS_M009_F();

        public QMS_M009_F_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M009_F_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_QMS_M009_F MC = new MultipleContext_QMS_M009_F();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M009_F_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var flipGridData = reader.Read<QMS_M009_FFlip>().ToList();
                        MC.FlipGridData = flipGridData.ToList();

                        var CatlogData = reader.Read<QMS_M032_P>().ToList();
                        MC.CatlogMaster = CatlogData.ToList();
                    }
                    if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var masterData = reader.Read<QMS_M009_F>().ToList();
                        MC.MasterEntity = masterData.ToList();
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
            try
            {
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M009_f_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<QMS_M009_FFlip>().ToList();
                    MC.FlipGridData = flipGridData.ToList();

                    var masterData = reader.Read<QMS_M009_F>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
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
        public string Update(string Request)
        {
            try
            {
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M009_F_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<QMS_M009_FFlip>().ToList();
                    MC.FlipGridData = flipGridData.ToList();

                    var masterData = reader.Read<QMS_M009_F>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
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

    public class MultipleContext_QMS_M009_F
    {
        public List<QMS_M009_FFlip> FlipGridData { get; set; }
        public List<QMS_M032_P> CatlogMaster { get; set; }
        public List<QMS_M009_F> MasterEntity { get; set; }
    }
}
