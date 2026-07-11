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
   public class QMS_M043_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        QMS_M043 masterEntity = new QMS_M043();
        MultipleContext_QMS_M043 MC = new MultipleContext_QMS_M043();

        public QMS_M043_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M043_BL()
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
                    var reader = conn.QueryMultiple("QMS_M043_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var BackFlip = reader.Read<QMS_M043_Flip>().ToList();
                        MC.BackFlipData = BackFlip.ToList();

                        var UnitData = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UnitMaster = UnitData.ToList();

                        var Container = reader.Read<QMS_M044_P>().ToList();
                        MC.SampleContainer = Container.ToList();

                        var Severity = reader.Read<QMS_M038_P>().ToList();
                        MC.InspSeverity = Severity.ToList();

                        var Scheme = reader.Read<QMS_M035_P>().ToList();
                        MC.SampleScheme = Scheme.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var MasterData = reader.Read<QMS_M043>().ToList();
                        MC.MasterEntity = MasterData.ToList();

                        var ItemsData = reader.Read<QMS_M043_A>().ToList();
                        MC.DetailEntity = ItemsData.ToList();
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
                    var reader = conn.QueryMultiple("QMS_M043_Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var BackFlip = reader.Read<QMS_M043_Flip>().ToList();
                    MC.BackFlipData = BackFlip.ToList();

                    var masterData = reader.Read<QMS_M043>().ToList();
                    List<QMS_M043> MasterList = masterData.ToList();

                    if (MasterList.Count > 0)
                    {
                        masterEntity = MasterList[0];
                    }

                    var ItemsData = reader.Read<QMS_M043_A>().ToList();
                    MC.DetailEntity = ItemsData.ToList();

                    masterEntity.XmlDataDocument_QMS_M043_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);
                    masterEntity.XmlDataDocument_QMS_M043_A = ObjectSerializationService.ObjectToXML(MC.DetailEntity);
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
                    var reader = conn.QueryMultiple("QMS_M043_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlip = reader.Read<QMS_M043_Flip>().ToList();
                    MC.BackFlipData = BackFlip.ToList();

                    var masterData = reader.Read<QMS_M043>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    var ItemData = reader.Read<QMS_M043_A>().ToList();
                    MC.DetailEntity = ItemData.ToList();

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_QMS_M043_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);
                    masterEntity.XmlDataDocument_QMS_M043_A = ObjectSerializationService.ObjectToXML(MC.DetailEntity);
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

    public class MultipleContext_QMS_M043
    {
        public List<QMS_M043_Flip> BackFlipData { get; set; }
        public List<ADM_M038_B_P> UnitMaster { get; set; }
        public List<QMS_M044_P> SampleContainer { get; set; }
        public List<QMS_M038_P> InspSeverity { get; set; }
        public List<QMS_M035_P> SampleScheme { get; set; }
        public List<QMS_M043> MasterEntity { get; set; }
        public List<QMS_M043_A> DetailEntity { get; set; }
    }
}
