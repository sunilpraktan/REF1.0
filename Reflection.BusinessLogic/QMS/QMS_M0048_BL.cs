using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.ADM;
using Reflection.EF.Admin;
using Reflection.EF.QMS;
namespace Reflection.BusinessLogic.QMS
{
    public class QMS_M0048_BL : ReflectionBusinessLogic
    {
        MC_QMS_M0048 MC = new MC_QMS_M0048();
        public QMS_M0048_BL()
        {

        }
        public string Insert(string Request)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M0048_INS", new { Request = Request }, commandTimeout: 300, commandType: CommandType.StoredProcedure);
                    MC.MASTER_LIST = reader.Read<QMS_M0048>().ToList();
                }
                return ObjectSerializationService.ObjectToXML(MC);

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
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M0048_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure, commandTimeout: 600);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.MASTER_LIST = reader.Read<QMS_M0048>().ToList();

                    }

                }
                strData = ObjectSerializationService.ObjectToXML(MC);

                return strData;
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
    }


    public class MC_QMS_M0048 : MC_QMS_BE
    {
        public List<QMS_M0048> MASTER_LIST { get; set; }
    }
}



