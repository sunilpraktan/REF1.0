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
    public class ZADM_M006BL : ReflectionBusinessLogic
    {
        private static string connectionString;       
        static int obj = 0;

        ZADM_M006 zADM_M006 = new ZADM_M006();
        public ZADM_M006BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZADM_M006BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MultipleContext_ZADM_M006 MC = new MultipleContext_ZADM_M006();
                zADM_M006 = (ZADM_M006)ObjectSerializationService.XMLToObject(Request, zADM_M006);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M006Insert", new
                    {
                        @ink = zADM_M006.ink,
                        @make_id = zADM_M006.make_id,
                        @desc = zADM_M006.desc,
                        @add_by = zADM_M006.add_by,
                        @viscosity = zADM_M006.viscosity
                    }, commandType: CommandType.StoredProcedure);

                    var taxMstr = reader.Read<ZADM_M006>().ToList();
                    zADM_M006 = new ZADM_M006();
                    MC.Ink_Master = taxMstr.ToList();
                    zADM_M006 = MC.Ink_Master[0];

                    string strReturnData = ObjectSerializationService.ObjectToXML(zADM_M006);
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
                zADM_M006 = (ZADM_M006)ObjectSerializationService.XMLToObject(Request, zADM_M006);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intout = conn.Execute("ZADM_M006Update", new
                    {
                        @ink_id = zADM_M006.ink_id,
                        @ink = zADM_M006.ink,
                        @make_id = zADM_M006.make_id,
                        @desc = zADM_M006.desc,
                        @add_by = zADM_M006.add_by,
                        @viscosity = zADM_M006.viscosity
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
                    int intOut = conn.Execute("ZADM_M006Delete", new { @ink_id = Request }, commandType: CommandType.StoredProcedure);
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
                MultipleContext_ZADM_M006 MC = new MultipleContext_ZADM_M006();
                string strData = "";

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M006LoadAll", commandType: CommandType.StoredProcedure);
                    {
                        var inkMstr = reader.Read<ZADM_M006>().ToList();
                        MC.Ink_Master = inkMstr.ToList();

                        var makeDtl = reader.Read<ADM_M032_P>().ToList();
                        MC.Make_Dtls = makeDtl.ToList();

                        strData = ObjectSerializationService.ObjectToXML(MC);
                        return strData;
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
        public class MultipleContext_ZADM_M006
        {
            public List<ZADM_M006> Ink_Master { get; set; }//Ink Master    
            public List<ADM_M032_P> Make_Dtls { get; set; }//Make Master        
        }
    }
}
