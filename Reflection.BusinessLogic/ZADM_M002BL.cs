using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Reflection.EF.Admin;
using System.Data;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ZADM_M002BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        ZADM_M002 ZaDM_M002 = new ZADM_M002();
       

        public ZADM_M002BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public ZADM_M002BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                ZaDM_M002 = (ZADM_M002)ObjectSerializationService.XMLToObject(Request, ZaDM_M002);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M002Insert", new
                    {
                        @ball_type = ZaDM_M002.ball_type,
                        @add_by = ZaDM_M002.add_by
                    }, commandType: CommandType.StoredProcedure);

                    var Item1 = reader.Read<ZADM_M002>().ToList();
                    List<ZADM_M002> Item = Item1.ToList();

                    string strReturnData = ObjectSerializationService.ObjectToXML(Item[0]);
                    return strReturnData;
                }
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
                ZaDM_M002 = (ZADM_M002)ObjectSerializationService.XMLToObject(Request, ZaDM_M002);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intout = conn.Execute("ZADM_M002Update", new
                    {
                        @ball_type_id = ZaDM_M002.ball_type_id,
                        @ball_type = ZaDM_M002.ball_type,
                        @add_by = ZaDM_M002.add_by
                    }, commandType: CommandType.StoredProcedure);

                    return intout.ToString();
                }
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

        public string Delete(int Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZADM_M002Delete", new { @ball_type_id = Request }, commandType: CommandType.StoredProcedure);
                    return intOut.ToString();
                }
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
        public string GetData()
        {
            string strValue = "";
            try
            {
               //List<ZADM_M002> BallType = new List<ZADM_M002>();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M002LoadAll", commandType: CommandType.StoredProcedure);
                    {
                        var BallType =reader.Read<ZADM_M002>().ToList();
                        strValue = ObjectSerializationService.ObjectToXML(BallType);
                    }
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

            return strValue;
        }
    }
}
