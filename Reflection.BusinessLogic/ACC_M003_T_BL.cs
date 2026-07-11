using Dapper;
using Reflection.EF;
using Reflection.EF.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Reflection.BusinessLogic
{
   public class ACC_M003_T_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ACC_M003_T MC = new MultipleContext_ACC_M003_T();
        ACC_M003_T MasterEntity = new ACC_M003_T();

        public ACC_M003_T_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M003_T_BL()
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
                    var reader = conn.QueryMultiple("ACC_M003_TLoadAll", new { @Request = RequestValue },commandTimeout:600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadPostingDetreminationData")
                    {                       
                        var _postingDetreminationDataList = reader.Read<ACC_M003_T>().ToList();
                        MC.postingDetreminationDataList = _postingDetreminationDataList.ToList();

                        var _COA_KeyList = reader.Read<ACC_M026_P>().ToList();
                        MC.COA_KeyList = _COA_KeyList.ToList();

                        var _DetailEntityList = reader.Read<ACC_M003_T>().ToList();
                        MC.DetailEntityList = _DetailEntityList.ToList();

                        var _PostingKeyRulesList = reader.Read<ACC_M003_F>().ToList();
                        MC.PostingKeyRulesList = _PostingKeyRulesList.ToList();

                        var _AccountGroupList = reader.Read<ACC_M003_H>().ToList();
                        MC.AccountGroupList = _AccountGroupList.ToList();

                        var _ValueClassList = reader.Read<ACC_M003_V>().ToList();
                        MC.ValueClassList = _ValueClassList.ToList();

                        var _ValueGroupList = reader.Read<ACC_M003_G>().ToList();
                        MC.ValueGroupList = _ValueGroupList.ToList();

                        var _GLCodeDebitList = reader.Read<ACC_M003_P>().ToList();
                        MC.GLCodeDebitList = _GLCodeDebitList.ToList();

                        var _GLCodeCreditList = reader.Read<ACC_M003_P>().ToList();
                        MC.GLCodeCreditList = _GLCodeCreditList.ToList();

                        var _TaxCodeList = reader.Read<ACC_M013_P>().ToList();
                        MC.TaxCodeList = _TaxCodeList.ToList();

                        var _BussPlaceList = reader.Read<ADM_M003_C_P>().ToList();
                        MC.BussPlaceList = _BussPlaceList.ToList();

                    }
                    else if (RequestOption == "LoadDataAfterDefiningRules")
                    {
                        var _DetailEntityList = reader.Read<ACC_M003_T>().ToList();
                        MC.DetailEntityList = _DetailEntityList.ToList();

                        var _PostingKeyRulesList = reader.Read<ACC_M003_F>().ToList();
                        MC.PostingKeyRulesList = _PostingKeyRulesList.ToList();

                        var _AccountGroupList = reader.Read<ACC_M003_H>().ToList();
                        MC.AccountGroupList = _AccountGroupList.ToList();

                        var _ValueClassList = reader.Read<ACC_M003_V>().ToList();
                        MC.ValueClassList = _ValueClassList.ToList();

                        var _ValueGroupList = reader.Read<ACC_M003_G>().ToList();
                        MC.ValueGroupList = _ValueGroupList.ToList();

                        var _GLCodeDebitList = reader.Read<ACC_M003_P>().ToList();
                        MC.GLCodeDebitList = _GLCodeDebitList.ToList();

                        var _GLCodeCreditList = reader.Read<ACC_M003_P>().ToList();
                        MC.GLCodeCreditList = _GLCodeCreditList.ToList();

                        var _TaxCodeList = reader.Read<ACC_M013_P>().ToList();
                        MC.TaxCodeList = _TaxCodeList.ToList();

                        var _BussPlaceList = reader.Read<ADM_M003_C_P>().ToList();
                        MC.BussPlaceList = _BussPlaceList.ToList();
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
            ACC_M003_T MasterEntity = new ACC_M003_T();
            MultipleContext_ACC_M003_T MC = new MultipleContext_ACC_M003_T();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M003_TInsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _PricingProEntity = reader.Read<ACC_M003_T>().ToList();
                    MC.DetailEntityList = _PricingProEntity.ToList();

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
        //    ACC_M003_T MasterEntity = new ACC_M003_T();
        //    MultipleContext_ACC_M003_T MC = new MultipleContext_ACC_M003_T();
        //    try
        //    {
        //        using (IDbConnection conn = new SqlConnection(connectionString))
        //        {

        //            var reader = conn.QueryMultiple("ACC_M003_TInsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);  

        //            //var DetailData = reader.Read<ACC_M003_T>().ToList();
        //            //MC.AccountDeterminationList = DetailData.ToList();

        //          //  MasterEntity.XmlDataDocument_ACC_M003_T = ObjectSerializationService.ObjectToXML(MC.AccountDeterminationList);
        //        }

        //        strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
                return strReturnData;


        //    }
        //    catch (SqlException ex)
        //    {

        //        throw new CreateException(ex.ErrorCode, ex.Message, ex);
        //    }
        //    catch (CreateException ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        }
    }
    public class MultipleContext_ACC_M003_T
    {
        public List<ACC_M003_T> postingDetreminationDataList { get; set; }
        public List<ACC_M003_T> DetailEntityList { get; set; }
        public List<ACC_M003_P> GLCodeDebitList { get; set; }
        public List<ACC_M003_P> GLCodeCreditList { get; set; }
        public List<ACC_M026_P> COA_KeyList { get; set; }
        public List<ACC_M003_V> ValueClassList { get; set; }
        public List<ACC_M003_F> PostingKeyRulesList { get; set; }
        public List<ACC_M003_T> GL_CodeList { get; set; }
        public List<ACC_M003_H> AccountGroupList { get; set; }
        public List<ACC_M003_G> ValueGroupList { get; set; }
        public List<ACC_M013_P> TaxCodeList { get; set; }
        public List<ADM_M003_C_P> BussPlaceList { get; set; }
    }
}
