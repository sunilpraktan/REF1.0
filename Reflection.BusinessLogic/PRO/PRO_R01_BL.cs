using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace Reflection.BusinessLogic.PRO
{
    public class PRO_R01_BL : ReflectionBusinessLogic
    {
        public PRO_R01_BL()
        { }
        public string GetData(string Request, string QueryOption, int intValue, string strValue)
        {

            STD_MC_BE MC = new STD_MC_BE();
            string RequestOption = Request.Split('!')[0];
            try
            {

                if (RequestOption == "LOAD_INI" || RequestOption == "REPORT")
                {
                    using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                    {
                        var reader = conn.QueryMultiple("PRO_R01_SP", new { @request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LOAD_INI")
                        {
                            MC.STD_ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                        }
                        else if (RequestOption == "REPORT")
                        {
                            MC.STD_MIS_LIST = reader.Read<STD_MIS_BE>().ToList();
                        }
                        base.ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                }
                return base.ReturnValue;
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
