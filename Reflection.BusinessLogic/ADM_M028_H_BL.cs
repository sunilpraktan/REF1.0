using System;
using Dapper;
using Reflection.EF.Admin;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Reflection.EF;

namespace Reflection.BusinessLogic
{
    public class ADM_M028_H_BL : ReflectionBusinessLogic
    {
        MultipleContext_ADM_M028_H MC = new MultipleContext_ADM_M028_H();

        private static string connectionString;
        ADM_M028_H MasterEntity = new ADM_M028_H();

        public ADM_M028_H_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M028_H_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string RequestValue, string strType, int intValue, string srtValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M028_H_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    if (RequestOption == "LoadInitialData")
                    {
                        var _PartyConList = reader.Read<ADM_M028_H>().ToList();
                        MC.PartyConList = _PartyConList.ToList();

                        var _PartyIDList = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyIDList = _PartyIDList.ToList();
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
                        var reader = conn.QueryMultiple("ADM_M028_H_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _PartyConList = reader.Read<ADM_M028_H>().ToList();
                        MC.PartyConList = _PartyConList.ToList();
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
    public class MultipleContext_ADM_M028_H
    {
        public List<ADM_M028_H> PartyConList { get; set; }
        public List<ADM_M028_P> PartyIDList { get; set; }
    }
}
