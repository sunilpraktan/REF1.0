using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic

{
    public class ACC_M013BL : ReflectionBusinessLogic
    {
        private static String connectionString;
        ACC_M013 MasterEntity = new ACC_M013();
        MultipleContext_ACC_M013 MC = new MultipleContext_ACC_M013();
       

        public ACC_M013BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M013BL()
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
                    var reader = conn.QueryMultiple("ACC_M013LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    if (RequestOption == "LoadInitialData")
                    {
                        var taxMstr = reader.Read<ACC_M013>().ToList();
                        MC.Tax_Master = taxMstr.ToList();

                        //var ACC_AcDtl = reader.Read<ACC_M003_P>().ToList();
                        //MC.Acc_AccountDtls = ACC_AcDtl.ToList();

                        //var taxCd = reader.Read<ACC_M014_P>().ToList();
                        //MC.Acc_Tax_CodeDtls = taxCd.ToList();
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
            ACC_M013 MasterEntity = new ACC_M013();
            MultipleContext_ACC_M013 MC = new MultipleContext_ACC_M013();

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ACC_M013Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var taxMstr = reader.Read<ACC_M013>().ToList();
                        MC.Tax_Master = taxMstr.ToList();
                    }
                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
            string strReturnData = "";
            ACC_M013 MasterEntity = new ACC_M013();
            MultipleContext_ACC_M013 MC = new MultipleContext_ACC_M013();

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M013Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var taxMstr = reader.Read<ACC_M013>().ToList();
                    MC.Tax_Master = taxMstr.ToList();
                }
                strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
        public class MultipleContext_ACC_M013
        {
            public List<ACC_M013> Tax_Master { get; set; }//Tax_Master    
            public List<ACC_M003_P> Acc_AccountDtls { get; set; }//Acc_Account
            public List<ACC_M014_P> Acc_Tax_CodeDtls { get; set; }//Acc_Tax_Code 
        }
    }

