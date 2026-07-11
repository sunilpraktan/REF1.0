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
    public class QMS_M0040_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        QMS_M0040 masterEntity = new QMS_M0040();
        MC_QMS_M0040 MC = new MC_QMS_M0040();

        public QMS_M0040_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M0040_BL()
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
                    var reader = conn.QueryMultiple("QMS_M0040_GET", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.InspType = reader.Read<QMS_M039_P>().ToList();
                        MC.ItemMaster = reader.Read<ADM_M022_P>().ToList();
                        MC.SampleProcedure = reader.Read<QMS_M034_P>().ToList();
                        MC.MasterEntity = reader.Read<QMS_M0040>().ToList();

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
                    var reader = conn.QueryMultiple("QMS_M0040_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    //var BackFlip = reader.Read<QMS_M040_Flip>().ToList();
                    //MC.BackFlipData = BackFlip.ToList();

                    var masterData = reader.Read<QMS_M0040>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    masterEntity = MC.MasterEntity[0];
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
                    var reader = conn.QueryMultiple("QMS_M0040_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //var BackFlip = reader.Read<QMS_M040_Flip>().ToList();
                    //MC.BackFlipData = BackFlip.ToList();

                    var masterData = reader.Read<QMS_M0040>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    masterEntity = MC.MasterEntity[0];
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

    public class MC_QMS_M0040
    {
        public List<QMS_M039_P> InspType { get; set; }
        public List<ADM_M022_P> ItemMaster { get; set; }
        public List<QMS_M034_P> SampleProcedure { get; set; }
        public List<QMS_M0040> MasterEntity { get; set; }
        public List<QMS_M040_Flip> BackFlipData { get; set; }

    }
}
