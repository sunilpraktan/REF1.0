using Dapper;
using Reflection.EF;
using Reflection.EF.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    class BankReco_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        ACC_T006 MasterEntity = new ACC_T006();
        MultipleContext_ACC_T006 MC = new MultipleContext_ACC_T006();

        public BankReco_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public BankReco_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_T006_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialDataBankReco")
                    {
                        var banks = reader.Read<ACC_M004_P>().ToList();
                        MC.BanksMaster = banks.ToList();

                        var FinYear = reader.Read<ACC_M001A_P>().ToList();
                        MC.FinYearMaster = FinYear.ToList();

                        var PostingPeriod = reader.Read<ACC_M001A_P>().ToList();
                        MC.PostingPeriodMaster = PostingPeriod.ToList();
                    }

                    else if (RequestOption == "LoadBankRecoDetails")
                    {
                        var DetailData = reader.Read<ACC_T006_A>().ToList();
                        MC.DetailData = DetailData.ToList();
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

        public string Update(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_T006_BankReco", new { @request = Request }, commandType: CommandType.StoredProcedure);

                    string strData = "";
                    return strData;
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
    }

}
