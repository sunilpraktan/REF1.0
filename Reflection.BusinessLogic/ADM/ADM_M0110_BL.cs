using Dapper;
using Reflection.EF.ADM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Reflection.BusinessLogic.ADM
{
   public class ADM_M0110_BL:ReflectionBusinessLogic
    {
        MC_ADM_M0110 MC = new MC_ADM_M0110();
        public ADM_M0110_BL()
        {

        }
        public string Insert(string Request, string requestOption)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M0110_INS", new { Request = Request }, commandTimeout: 300, commandType: CommandType.StoredProcedure);
                    MC.MASTER_LIST = reader.Read<ADM_M0110>().ToList();
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
                    var reader = conn.QueryMultiple("ADM_M0110_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure, commandTimeout: 600);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.MASTER_LIST = reader.Read<ADM_M0110>().ToList();

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



    public class MC_ADM_M0110 : EF.MC_ADM_BE
    {
       
        public List <ADM_M0110> MASTER_LIST { get; set; }
    }
}


