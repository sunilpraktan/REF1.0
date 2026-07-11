using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ZADM_M005BL : ReflectionBusinessLogic
    {
        private static string connectionString;        
        static int obj = 0;
       
        ZADM_M005 zADM_M005 = new ZADM_M005();
        public ZADM_M005BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZADM_M005BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        #region Insert
        public string Insert(string Request)
    {
        try
        {
            zADM_M005 = (ZADM_M005)ObjectSerializationService.XMLToObject(Request, zADM_M005);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M005Insert", new
                    {
                        @usedin = zADM_M005.usedin,
                        @add_by = zADM_M005.add_by
                    }, commandType: CommandType.StoredProcedure);

                    var machine = reader.Read<ZADM_M005>().ToList();
                    List<ZADM_M005> machineList = machine.ToList();
                    if (machineList.Count > 0)
                    {
                        zADM_M005 = machineList[0];
                    }

                    string strReturnData = ObjectSerializationService.ObjectToXML(zADM_M005);
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
                    var reader = conn.QueryMultiple("ZADM_M005LoadAll", commandType: CommandType.StoredProcedure);
                    {
                        var machine = reader.Read<ZADM_M005>().ToList();
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
            zADM_M005 = (ZADM_M005)ObjectSerializationService.XMLToObject(Request, zADM_M005);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intout = conn.Execute("ZADM_M005Update", new
                    {
                        @usedin_id = zADM_M005.usedin_id,
                        @usedin = zADM_M005.usedin,
                        @add_by = zADM_M005.add_by
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
            throw new CreateException(ex.InnerException.Message , ex);
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
                    int intOut = conn.Execute("ZADM_M005Delete", new { @usedin_id = Request }, commandType: CommandType.StoredProcedure);
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
