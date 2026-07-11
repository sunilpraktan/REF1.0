using Dapper;
using Reflection.BusinessLogic.ADM;
using Reflection.EF.Admin;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Reflection.BusinessLogic.HRM
{
    public class HRM_M0002_BL : ReflectionBusinessLogic
    {
        MC_ADM_M0025 MC = new MC_ADM_M0025();
        public HRM_M0002_BL()
        {

        }
        public string Insert(string Request, string requestOption)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("HRM_M0002_INS", new { Request = Request }, commandTimeout: 300, commandType: CommandType.StoredProcedure);
                    MC.MASTER_LIST = reader.Read<ADM_M025>().ToList();
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
                    var reader = conn.QueryMultiple("HRM_M0002_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure, commandTimeout: 600);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.MASTER_LIST = reader.Read<ADM_M025>().ToList();

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



    
}



