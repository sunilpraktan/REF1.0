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
    class QMS_M009_G_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_QMS_M009_G MC = new MultipleContext_QMS_M009_G();
        QMS_M009_G masterEntity = new QMS_M009_G();

        public QMS_M009_G_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M009_G_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_QMS_M009_G MC = new MultipleContext_QMS_M009_G();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M009_G_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var flipGridData = reader.Read<QMS_M009_GFlip>().ToList();
                        MC.FlipGridData = flipGridData.ToList();

                        var Groupcode = reader.Read<QMS_M009_F_P>().ToList();
                        MC.GroupCodeMaster = Groupcode.ToList();

                        var defectClass = reader.Read<QMS_M031_P>().ToList();
                        MC.DefectClass = defectClass.ToList();
                    }
                    if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var masterData = reader.Read<QMS_M009_G>().ToList();
                        MC.MasterEntity = masterData.ToList();
                    }

                    if(RequestOption == "LoadFromGroupAndCatlog")
                    {
                        var masterData = reader.Read<QMS_M009_G>().ToList();
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
                    var reader = conn.QueryMultiple("QMS_M009_G_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<QMS_M009_GFlip>().ToList();
                    MC.FlipGridData = flipGridData.ToList();

                    var masterData = reader.Read<QMS_M009_G>().ToList();
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
                    var reader = conn.QueryMultiple("QMS_M009_G_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<QMS_M009_GFlip>().ToList();
                    MC.FlipGridData = flipGridData.ToList();

                    var masterData = reader.Read<QMS_M009_G>().ToList();
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

    public class MultipleContext_QMS_M009_G
    {
        public List<QMS_M009_GFlip> FlipGridData { get; set; }
        public List<QMS_M009_F_P> GroupCodeMaster { get; set; }
        public List<QMS_M009_G> MasterEntity { get; set; }
        public List<QMS_M031_P> DefectClass { get; set; }
    }

    }
