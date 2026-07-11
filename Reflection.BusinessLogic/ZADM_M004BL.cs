using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ZADM_M004BL : ReflectionBusinessLogic
    {
        private static string connectionString;     
        static int obj = 0;
     
        ZADM_M004 ZADM_M004 = new ZADM_M004();
        public ZADM_M004BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZADM_M004BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        #region Insert
        public string Insert(string Request)
        {
            try
            {
                ZADM_M004 = (ZADM_M004)ObjectSerializationService.XMLToObject(Request, ZADM_M004);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M004Insert", new
                    {
                        @wire_type = ZADM_M004.wire_type,
                        @add_by = ZADM_M004.add_by
                    }, commandType: CommandType.StoredProcedure);

                    var machine = reader.Read<ZADM_M004>().ToList();
                    List<ZADM_M004> machineList = machine.ToList();
                    if (machineList.Count > 0)
                    {
                        ZADM_M004 = machineList[0];
                    }

                    string strReturnData = ObjectSerializationService.ObjectToXML(ZADM_M004);
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

        #endregion

        #region Getdata
        public string GetData()
        {
            string strValue = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M004LoadAll", commandType: CommandType.StoredProcedure);
                    {
                        var machine = reader.Read<ZADM_M004>().ToList();
                        strValue = ObjectSerializationService.ObjectToXML(machine);
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
        #endregion

        #region Update
        public string Update(string Request)
        {
            try
            {
                ZADM_M004 = (ZADM_M004)ObjectSerializationService.XMLToObject(Request, ZADM_M004);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intout = conn.Execute("ZADM_M004Update", new
                    {
                        @wire_type_id = ZADM_M004.wire_type_id,
                        @wire_type = ZADM_M004.wire_type,
                        @add_by = ZADM_M004.add_by
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
                throw new CreateException(ex.InnerException.Message, ex);
            }

        }
        #endregion

        #region Delete

        public string Delete(int Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZADM_M004Delete", new { @wire_type_id = Request }, commandType: CommandType.StoredProcedure);
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
        #endregion

    } 
}
