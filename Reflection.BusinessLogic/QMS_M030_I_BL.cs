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
    class QMS_M030_I_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        QMS_M030_I masterEntity = new QMS_M030_I();
        MultipleContext_QMS_M030_I MC = new MultipleContext_QMS_M030_I();

        public QMS_M030_I_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M030_I_BL()
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
                    var reader = conn.QueryMultiple("QMS_M030_I_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var BackFlip = reader.Read<QMS_M030_I_Flip>().ToList();
                        MC.BackFlipData = BackFlip.ToList();

                        var Qualification = reader.Read<QMS_M022_P>().ToList();
                        MC.QualiMaster = Qualification.ToList();

                        var UnitData = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UnitMaster = UnitData.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var MasterData = reader.Read<QMS_M030_I>().ToList();
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
                    var reader = conn.QueryMultiple("QMS_M030_I_Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var BackFlip = reader.Read<QMS_M030_I_Flip>().ToList();
                    MC.BackFlipData = BackFlip.ToList();

                    var MasterData = reader.Read<QMS_M030_I>().ToList();
                    MC.MasterEntity = MasterData.ToList();

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_QMS_M030_I_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);

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
                    var reader = conn.QueryMultiple("QMS_M030_I_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlip = reader.Read<QMS_M030_I_Flip>().ToList();
                    MC.BackFlipData = BackFlip.ToList();

                    var MasterData = reader.Read<QMS_M030_I>().ToList();
                    MC.MasterEntity = MasterData.ToList();

                    if(MC.MasterEntity.Count > 0)
                    {
                        masterEntity = MC.MasterEntity[0];
                    }
                    
                    masterEntity.XmlDataDocument_QMS_M030_I_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);

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

    public class MultipleContext_QMS_M030_I
    {
        public List<QMS_M030_I_Flip> BackFlipData { get; set; }
        public List<QMS_M022_P> QualiMaster { get; set; }
        public List<ADM_M038_B_P> UnitMaster { get; set; }
        public List<QMS_M030_I> MasterEntity { get; set; }
    }
}
