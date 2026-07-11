using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ZADM_M007BL : ReflectionBusinessLogic
    {
        private static string connectionString;      
        string strReturnData = "";
        static int obj = 0;
       
        ZADM_M007 zADM_M007 = new ZADM_M007();

        public ZADM_M007BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZADM_M007BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MultipleContextZADM_M007 MC = new MultipleContextZADM_M007();
                zADM_M007 = (ZADM_M007)ObjectSerializationService.XMLToObject(Request, zADM_M007);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M007Insert", new
                    {
                        @ild = zADM_M007.ild,
                        @ild_type = zADM_M007.ild_type,
                        @tip_type = zADM_M007.tip_type,
                        @min_val = zADM_M007.min_val,
                        @max_val = zADM_M007.max_val,
                        @avg_max = zADM_M007.avg_max,
                        @avg_min = zADM_M007.avg_min,
                        @desc = zADM_M007.desc,
                        @add_by = (object)zADM_M007.add_by ?? DBNull.Value,
                        @show_ild = zADM_M007.show_ild
                    }, commandType: CommandType.StoredProcedure);


                    var ild = reader.Read<ZADM_M007>().ToList();
                    zADM_M007 = new ZADM_M007();
                    MC.ilds = ild.ToList();
                    zADM_M007 = MC.ilds[0];

                    string strReturnData = ObjectSerializationService.ObjectToXML(zADM_M007);
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
                zADM_M007 = (ZADM_M007)ObjectSerializationService.XMLToObject(Request, zADM_M007);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZADM_M007Update", new
                    {
                        @ild_id = zADM_M007.ild_id,
                        @ild = zADM_M007.ild,
                        @ild_type = zADM_M007.ild_type,
                        @tip_type = zADM_M007.tip_type,
                        @min_val = zADM_M007.min_val,
                        @max_val = zADM_M007.max_val,
                        @avg_max = zADM_M007.avg_max,
                        @avg_min = zADM_M007.avg_min,
                        @desc = zADM_M007.desc,
                        @add_by = zADM_M007.add_by,
                        @show_ild = zADM_M007.show_ild
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
        public string Delete(int Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZADM_M007Delete", new { @ild_id = Request }, commandType: CommandType.StoredProcedure);
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
            try
            {
                MultipleContextZADM_M007 MC = new MultipleContextZADM_M007();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M007LoadAll", commandType: CommandType.StoredProcedure);
                    {
                        var ild = reader.Read<ZADM_M007>().ToList();
                        List<ZADM_M007> ilds = ild.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(ilds);
                        return strReturnData;
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
        }
        public class MultipleContextZADM_M007
        {
            public List<ZADM_M007> ilds { get; set; }
          
        }   
    }
}
