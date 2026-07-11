using Dapper;
using Reflection.EF;
using Reflection.EF.ADM;
using Reflection.EF.Admin;
using Reflection.EF.CRM;
using Reflection.EF.Procurement;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.SDM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Reflection.BusinessLogic
{
    public class PUR_T005_STD_BL : ReflectionBusinessLogic
    {
        //private static string connectionString;
        PUR_T005 MasterEntity = new PUR_T005();
        MC_PUR_T005 MC = new MC_PUR_T005();
        //public PUR_T005_STD_BL(string BusinessEntity)
        //{
        //    connectionString = base.ReflectionConnectionString;
        //}
        //public PUR_T005_STD_BL()
        //{
        //    connectionString = base.ReflectionConnectionString;
        //}

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T005Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                    MC.MasterEntity = reader.Read<PUR_T005>().ToList();
                    MasterEntity = MC.MasterEntity[0];
                    MC.ItemsEntity = reader.Read<PUR_T005_A>().ToList();
                    MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                    MasterEntity.XmlDataDocument_PUR_T005_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = ObjectSerializationService.ObjectToXML(MC.TaxEntity);
                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MasterEntity);
                return ReturnValue;
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
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T005Update", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                    MC.MasterEntity = reader.Read<PUR_T005>().ToList();
                    MasterEntity = MC.MasterEntity[0];
                    MC.ItemsEntity = reader.Read<PUR_T005_A>().ToList();
                    MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                    MasterEntity.XmlDataDocument_PUR_T005_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = ObjectSerializationService.ObjectToXML(MC.TaxEntity);

                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MasterEntity);
                return ReturnValue;

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
        public string Delete(string Request)
        {
            try
            {
                int intOut;
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    intOut = conn.Execute("PUR_T005Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
                }
                return intOut.ToString();
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];

            try
            {
                if (RequestOption != "ValidateInvoice")
                {
                    using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                    {
                        var reader = conn.QueryMultiple("PUR_T005_STD_LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                        if (RequestOption == "LoadInitialData")
                        {
                            MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.TAX_LIST = reader.Read<ACC_M013>().ToList();
                            MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                            //MC.ItemList = reader.Read<STD_ITEM>().ToList();
                            //MC.UOMList = reader.Read<ADM_M038_B>().ToList();
                        }
                        else if (RequestOption == "ExecuteReferenceDocuments")
                        {
                            MC.MasterEntity = reader.Read<PUR_T005>().ToList();
                            MC.ItemsEntity = reader.Read<PUR_T005_A>().ToList();
                            MC.TaxEntity = reader.Read<ACC_T006_C>().ToList();
                        }
                        else if (RequestOption == "LoadBackFlipData")
                        {
                            MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                        }
                    }
                }
                else if (RequestOption == "ValidateInvoice")
                {
                    using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                    {
                        var reader = conn.QueryMultiple("PUR_T005Validate", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                        var MasterData = reader.Read<PUR_T005>().ToList();
                        MC.MasterEntity = MasterData.ToList();
                        return ObjectSerializationService.ObjectToXML(MC);
                    }
                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                return ReturnValue;
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
        public class MC_PUR_T005 : STD_MC_BE
        {
            public List<PUR_T005> MasterEntity { get; set; }
            public List<PUR_T005_A> ItemsEntity { get; set; }
            public List<ACC_T006_C> TaxEntity { get; set; }
        }
    }
}
