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

namespace Reflection.BusinessLogic.QMS
{
    public class QMS_M0034_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        QMS_M0034 MasterEntity = new QMS_M0034();
        MC_QMS_M0034 MC = new MC_QMS_M0034();

        public QMS_M0034_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M0034_BL()
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
                    var reader = conn.QueryMultiple("QMS_M0034_GET", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.TYPE_LIST = reader.Read<STD_LIST_BE>().ToList(); // Sample type List
                        MC.VALUE_LIST = reader.Read<STD_LIST_BE>().ToList(); // Valuation Mode
                        MC.KEY_DATA_LIST = reader.Read<STD_LIST_BE>().ToList(); // Inspection Severity
                        MC.PARA_TYPE_LIST = reader.Read<STD_LIST_BE>().ToList(); // Sample Scheme

                    }
                    else if (RequestOption == "LOAD_DOCUMENT")
                    {
                        MC.MASTER_LIST = reader.Read<QMS_M0034>().ToList();

                    }
                    else if (RequestOption == "LOAD_BACKFLIP")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();

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
                    var reader = conn.QueryMultiple("QMS_M0034_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.MASTER_LIST = reader.Read<QMS_M0034>().ToList();
                    MasterEntity = MC.MASTER_LIST[0];

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
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M0034_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    MC.MASTER_LIST = reader.Read<QMS_M0034>().ToList();
                    MasterEntity = MC.MASTER_LIST[0];
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

    public class MC_QMS_M0034 : MC_QMS_BE
    {
        public List<QMS_M0034> MASTER_LIST { get; set; }
    }
}
