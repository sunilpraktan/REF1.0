using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ZADM_M011BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        static int obj = 0;
       
        ZADM_M011 zADM_M011 = new ZADM_M011();
        public ZADM_M011BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZADM_M011BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        #region Insert
        public string Insert(string Request)
        {
            try
            {
                zADM_M011 = (ZADM_M011)ObjectSerializationService.XMLToObject(Request, zADM_M011);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M011Insert", new
                    {
                        @machine_type = zADM_M011.machine_type,
                        @remark = zADM_M011.remark,
                        @add_by = zADM_M011.add_by,
                    }, commandType: CommandType.StoredProcedure);

                    var machine = reader.Read<ZADM_M011>().ToList();
                    List<ZADM_M011> machineList = machine.ToList();
                    if (machineList.Count > 0)
                    {
                        zADM_M011 = machineList[0];
                    }
                    //else
                    //{
                    //    aDM_M018=new ADM_M018();
                    //}
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(zADM_M011);
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
                //List<ZADM_M011> total = new List<ZADM_M011>();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M011LoadAll", commandType: CommandType.StoredProcedure);
                    {
                        var total = reader.Read<ZADM_M011>().ToList();
                        strValue = ObjectSerializationService.ObjectToXML(total);
                    }
                }
                return strValue;
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
        #endregion
        #region Update
        public string Update(string Request)
        {
            try
            {
                zADM_M011 = (ZADM_M011)ObjectSerializationService.XMLToObject(Request, zADM_M011);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZADM_M011Update", new
                    {
                        zADM_M011.machine_type_id,
                        zADM_M011.machine_type,
                        zADM_M011.remark,
                        zADM_M011.add_by
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
                    int intOut = conn.Execute("ZADM_M011Delete", new { @machine_type_id = Request }, commandType: CommandType.StoredProcedure);
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
