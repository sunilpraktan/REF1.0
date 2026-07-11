using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;

using System.Data;
using Reflection.EF.Admin;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ADM_M031BL : ReflectionBusinessLogic
    {        
        static int obj = 0;
        private static string connectionString;
 
        ADM_M031 ADM_M031 = new ADM_M031();
        public ADM_M031BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M031BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        #region Insert
        public string Insert(string Request)
        {
            try
            {
                ADM_M031 = (ADM_M031)ObjectSerializationService.XMLToObject(Request, ADM_M031);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M031Insert", new
                    {
                        @para_code = ADM_M031.para_code,
                        @para_name = ADM_M031.para_name,
                        @add_by = ADM_M031.add_by,
                    }, commandType: CommandType.StoredProcedure);

                    var machine = reader.Read<ADM_M031>().ToList();
                    List<ADM_M031> machineList = machine.ToList();
                    if (machineList.Count > 0)
                    {
                        ADM_M031 = machineList[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(ADM_M031);
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
                List<ADM_M031> machine = new List<ADM_M031>();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M031LoadAll", commandType: CommandType.StoredProcedure);
                    machine = reader.Read<ADM_M031>().ToList();
                }
                strValue = ObjectSerializationService.ObjectToXML(machine);
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
                ADM_M031 = (ADM_M031)ObjectSerializationService.XMLToObject(Request, ADM_M031);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ADM_M031Update", new
                    {
                        ADM_M031.para_code,
                        ADM_M031.para_name,
                        ADM_M031.active,
                        ADM_M031.editby
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
                throw new CreateException(ex.InnerException.Message, ex);
            }

        }
        #endregion

        #region Delete

        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ADM_M031Delete", new { @para_code = Request }, commandType: CommandType.StoredProcedure);

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
