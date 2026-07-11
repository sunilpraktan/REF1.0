using Dapper;
using Reflection.EF.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Reflection.EF;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
   public class SYS_M025_BL : ReflectionBusinessLogic
    {
        MultipleContext_SYS_M025 MC = new MultipleContext_SYS_M025();
        private static string connectionString;
        SYS_M025 MasterEntity = new SYS_M025();

        public SYS_M025_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public SYS_M025_BL()
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
                    var reader = conn.QueryMultiple("SYS_M025_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _Statuslist = reader.Read<SYS_M025>().ToList();
                        MC.Statuslist = _Statuslist.ToList();

                        var _Documentlist = reader.Read<SYS_M002_P>().ToList();
                        MC.Documentlist = _Documentlist.ToList();


                        var _Tlist = reader.Read<ADM_M0013>().ToList();
                        MC.Tlist = _Tlist.ToList();


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
        public string Insert(string Request)
        {
            string strReturnData = "";
           
            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("SYS_M025_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _Statuslist = reader.Read<SYS_M025>().ToList();
                        MC.Statuslist = _Statuslist.ToList();
                    }
                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
    }
    public class MultipleContext_SYS_M025
    {

        public List <SYS_M025> Statuslist { get; set; }
        public List<SYS_M002_P> Documentlist { get; set; }

        public List<ADM_M0013> Tlist { get; set; }


    }
}
