
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Reflection.EF.Admin;
using System.Data;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ZADM_M001BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        ZADM_M001 ZaDM_M001 = new ZADM_M001();
       
        public ZADM_M001BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public ZADM_M001BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                ZaDM_M001 = (ZADM_M001)ObjectSerializationService.XMLToObject(Request, ZaDM_M001);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M001Insert", new
                    {
                        //@ball_dia_id = ZaDM_M001.ball_dia_id,
                        @ball_dia = ZaDM_M001.ball_dia,
                        @add_by = ZaDM_M001.add_by
                    }, commandType: CommandType.StoredProcedure);

                    var Item1 = reader.Read<ZADM_M001>().ToList();
                    List<ZADM_M001> Item = Item1.ToList();

                    string strReturnData = ObjectSerializationService.ObjectToXML(Item[0]);
                    return strReturnData;
                }
                //return intOut.ToString();
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
                ZaDM_M001 = (ZADM_M001)ObjectSerializationService.XMLToObject(Request, ZaDM_M001);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intout = conn.Execute("ZADM_M001Update", new
                    {
                        @ball_dia_id = ZaDM_M001.ball_dia_id,
                        @ball_dia = ZaDM_M001.ball_dia,
                        @add_by = ZaDM_M001.add_by
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
                    int intOut = conn.Execute("ZADM_M001Delete", new { @ball_dia_id = Request }, commandType: CommandType.StoredProcedure);
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
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M001LoadAll", commandType: CommandType.StoredProcedure);
                    {
                        var Ball = reader.Read<ZADM_M001>().ToList();
                        strValue = ObjectSerializationService.ObjectToXML(Ball);
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

