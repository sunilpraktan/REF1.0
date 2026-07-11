using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.PMS;
using Reflection.EF.ADM;
using Reflection.EF.Admin;
using Reflection.EF.Production;
using Reflection.EF.FICO;
using Reflection.EF.Communication;
using Reflection.EF.PMM;

namespace Reflection.BusinessLogic.COM
{
    public class COM_M0002_BL : ReflectionBusinessLogic
    {
        STD_BE_A MasterEntity = new STD_BE_A();
        MC_GEN_BE MC = new MC_GEN_BE();
        public COM_M0002_BL()
        { }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("COM_M0002_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.STD_ENTITY_COL = reader.Read<STD_BE_A>().ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }

                    ReturnValue = ObjectSerializationService.ObjectToXML(MC);

                }
                return ReturnValue;
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
            return ReturnValue;
        }
        public string Update(string Request)
        {
            return ReturnValue;
        }

    }
}
