using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;


namespace Reflection.BusinessLogic
{
    public class ZADM_M012BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        static int obj = 0;
       
        ZADM_M012 zADM_M012 = new ZADM_M012();
        public ZADM_M012BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZADM_M012BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        #region Insert
        public string Insert(string Request)
        {
            try
            {
                zADM_M012 = (ZADM_M012)ObjectSerializationService.XMLToObject(Request, zADM_M012);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M012Insert", new
                    {
                        @machine_subtype = zADM_M012.machine_subtype,
                        @remark = zADM_M012.remark,
                        @add_by = zADM_M012.add_by
                    }, commandType: CommandType.StoredProcedure);

                    var machine = reader.Read<ZADM_M012>().ToList();
                    List<ZADM_M012> machineList = machine.ToList();
                    if (machineList.Count > 0)
                    {
                        zADM_M012 = machineList[0];
                    }                 
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(zADM_M012);
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

        #endregion

        #region Getdata
        public string GetData()
        {
            string strValue = "";
            try
            {
                //List<ZADM_M012> total = new List<ZADM_M012>();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M012LoadAll", commandType: CommandType.StoredProcedure);
                    {
                        var total = reader.Read<ZADM_M011>().ToList();
                        strValue = ObjectSerializationService.ObjectToXML(total);
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
                zADM_M012 = (ZADM_M012)ObjectSerializationService.XMLToObject(Request, zADM_M012);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZADM_M012Update", new
                    {
                        zADM_M012.machine_subtype_id,
                        zADM_M012.machine_subtype,
                        zADM_M012.remark,
                        zADM_M012.add_by
                    }, commandType: CommandType.StoredProcedure);

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
        #region Delete
        public string Delete(int Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZADM_M012Delete", new { @machine_subtype_id = Request }, commandType: CommandType.StoredProcedure);
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
