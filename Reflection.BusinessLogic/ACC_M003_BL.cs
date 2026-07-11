using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Finance;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ACC_M003_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ACC_M003 MC = new MultipleContext_ACC_M003();
        ACC_M003 MasterEntity = new ACC_M003();

        public ACC_M003_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M003_BL()
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
                    var reader = conn.QueryMultiple("ACC_M0003_GET", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _AccLedgerList = reader.Read<ACC_M003>().ToList();
                        MC.AccLedgerList = _AccLedgerList.ToList();

                        var _CurrencyList = reader.Read<ADM_M037_P>().ToList();
                        MC.CurrencyList = _CurrencyList.ToList();

                        var _AccGroupList = reader.Read<ACC_M003_A_P>().ToList();
                        MC.AccGroupList = _AccGroupList.ToList();

                        

                        var _AccGroupSubList = reader.Read<ACC_M003_B_P>().ToList();
                        MC.AccGroupSubList = _AccGroupSubList.ToList();

                        var _GrpCatList = reader.Read<ACC_M003_C_P>().ToList();
                        MC.GrpCatList = _GrpCatList.ToList();

                        var _BankKeyList = reader.Read<ACC_M004_A_P>().ToList();
                        MC.BankKeyList = _BankKeyList.ToList();
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
            ACC_M003 MasterEntity = new ACC_M003();
            MultipleContext_ACC_M003 MC = new MultipleContext_ACC_M003();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M0003_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    MC.AccLedgerList = reader.Read<ACC_M003>().ToList();
                    MasterEntity = MC.AccLedgerList[0];
                    //var _AccLedgerList = reader.Read<ACC_M003>().ToList();
                    //MC.AccLedgerList = _AccLedgerList.ToList();

                }
                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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

        public string Update(string Request)
        {
            try
            {
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M0003_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    MC.AccLedgerList = reader.Read<ACC_M003>().ToList();
                    MasterEntity = MC.AccLedgerList[0];
                }
                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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


    }

    public class MultipleContext_ACC_M003
    {
        public List<ACC_M003> AccLedgerList { get; set; }
        public List<ADM_M037_P> CurrencyList { get; set; }
        public List<ACC_M004_A_P> BankKeyList { get; set; }
        public List<ACC_M003_A_P> AccGroupList { get; set; }
        public List<ACC_M003_B_P> AccGroupSubList { get; set; }
        public List<ACC_M003_C_P> GrpCatList { get; set; }
    }
}
