using Dapper;
using Reflection.EF.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Reflection.EF;

namespace Reflection.BusinessLogic
{
    public class SYS_M023_BL : ReflectionBusinessLogic
    {
        MultipleContext_SYS_M023 MC = new MultipleContext_SYS_M023();
        private static string connectionString;
        SYS_M023 MasterEntity = new SYS_M023();

        public SYS_M023_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public SYS_M023_BL()
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
                    var reader = conn.QueryMultiple("SYS_M023_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _Itemlist = reader.Read<SYS_M023>().ToList();
                        MC.Itemlist = _Itemlist.ToList();

                        var _Documentlist = reader.Read<SYS_M002_P>().ToList();
                        MC.Documentlist = _Documentlist.ToList();


                        var _Categotylist = reader.Read<ADM_M018_P>().ToList();
                        MC.Categotylist = _Categotylist.ToList();


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
            //ACC_M025 MasterEntity = new ACC_M025();
            //MultipleContext_ACC_M025 MC = new MultipleContext_ACC_M025();
            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("SYS_M023_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _Itemlist = reader.Read<SYS_M023>().ToList();
                        MC.Itemlist = _Itemlist.ToList();
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

    public class MultipleContext_SYS_M023
    {

        public List<SYS_M023> Itemlist { get; set; }
        public List<SYS_M002_P> Documentlist { get; set; }

        public List<ADM_M018_P> Categotylist { get; set; }


    }
}
