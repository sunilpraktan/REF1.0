using Dapper;
using Reflection.EF;
using Reflection.EF.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    class ACC_M003_Y_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ACC_M003_Y MC = new MultipleContext_ACC_M003_Y();
        ACC_M003_Y MasterEntity = new ACC_M003_Y();

        public ACC_M003_Y_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M003_Y_BL()
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
                    var reader = conn.QueryMultiple("ACC_M003_Y_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _RevenueList = reader.Read<ACC_M003_Y>().ToList();
                        MC.RevenueList = _RevenueList.ToList();

                        var _ApplicationList = reader.Read<ACC_M003_J_P>().ToList();
                        MC.ApplicationList = _ApplicationList.ToList();

                        var _ConTypeList = reader.Read<ACC_M003_S1_P>().ToList();
                        MC.ConTypeList = _ConTypeList.ToList();

                        var _COAKeyList = reader.Read<ACC_M026_P>().ToList();
                        MC.COAKeyList = _COAKeyList.ToList();

                        var _SGCodeList = reader.Read<ADM_M001_H_P>().ToList();
                        MC.SGCodeList = _SGCodeList.ToList();

                        var _SOCodeList = reader.Read<ADM_M001_A_P>().ToList();
                        MC.SOCodeList = _SOCodeList.ToList();

                        var _PartyAccGroupList = reader.Read<ACC_M003_H_P>().ToList();
                        MC.PartyAccGroupList = _PartyAccGroupList.ToList();

                        var _ItemAccGroupList = reader.Read<ACC_M003_H_P>().ToList();
                        MC.ItemAccGroupList = _ItemAccGroupList.ToList();

                        var _TransKeyCodeList = reader.Read<ACC_M003_E_P>().ToList();
                        MC.TransKeyCodeList = _TransKeyCodeList.ToList();

                        var _DebitGLCodeList = reader.Read<ACC_M003_P>().ToList();
                        MC.DebitGLCodeList = _DebitGLCodeList.ToList();

                        var _CreditGLCodeList = reader.Read<ACC_M003_P>().ToList();
                        MC.CreditGLCodeList = _CreditGLCodeList.ToList();

                        var _ItemCatList = reader.Read<SYS_M003_P>().ToList();
                        MC.ItemCatList = _ItemCatList.ToList();

                        var _DocCatList = reader.Read<SYS_M001_P>().ToList();
                        MC.DocCatList = _DocCatList.ToList();

                        var _DocTypeList = reader.Read<SYS_M002_P>().ToList();
                        MC.DocTypeList = _DocTypeList.ToList();
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
            ACC_M003_Y MasterEntity = new ACC_M003_Y();
            MultipleContext_ACC_M003_Y MC = new MultipleContext_ACC_M003_Y();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M003_Y_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _RevenueList = reader.Read<ACC_M003_Y>().ToList();
                    MC.RevenueList = _RevenueList.ToList();
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

            //            var DetailData = reader.Read<ACC_M003_T>().ToList();
            //            MC.AccountDeterminationList = DetailData.ToList();

            //            MasterEntity.XmlDataDocument_ACC_M003_T = ObjectSerializationService.ObjectToXML(MC.AccountDeterminationList);
            //        }

            //        strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
    public class MultipleContext_ACC_M003_Y
    {
        public List<ACC_M003_Y> RevenueList { get; set; }
        public List<ACC_M003_J_P> ApplicationList { get; set; }
        public List<ACC_M003_S1_P> ConTypeList { get; set; }
        public List<ACC_M026_P> COAKeyList { get; set; }
        public List<ADM_M001_H_P> SGCodeList { get; set; }
        public List<ADM_M001_A_P> SOCodeList { get; set; }
        public List<ACC_M003_H_P> PartyAccGroupList { get; set; }
        public List<ACC_M003_H_P> ItemAccGroupList { get; set; }
        public List<ACC_M003_E_P> TransKeyCodeList { get; set; }
        public List<ACC_M003_P> DebitGLCodeList { get; set; }
        public List<ACC_M003_P> CreditGLCodeList { get; set; }
        public List<SYS_M003_P> ItemCatList { get; set; }
        public List<SYS_M001_P> DocCatList { get; set; }
        public List<SYS_M002_P> DocTypeList { get; set; }
    }
}
