using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;
using Reflection.EF.Finance;

namespace Reflection.BusinessLogic
{
    public class ADM_M018BL : ReflectionBusinessLogic
    {

        private static string connectionString;
        ADM_M018 MasterEntity = new ADM_M018();
        MultipleContext_ADM_M018 MC = new MultipleContext_ADM_M018();

        public ADM_M018BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M018BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {

            string strReturnData = "";
            ADM_M018 MasterEntity = new ADM_M018();
            MultipleContext_ADM_M018 MC = new MultipleContext_ADM_M018();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M018Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _MasterData = reader.Read<ADM_M018>().ToList();
                    List<ADM_M018> Masterlist = _MasterData.ToList();
                
                    MasterEntity = Masterlist[0];

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
            string strReturnData = "";
            ADM_M018 MasterEntity = new ADM_M018();
            MultipleContext_ADM_M018 MC = new MultipleContext_ADM_M018();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {

                    var reader = conn.QueryMultiple("ADM_M018Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                    var MasterData = reader.Read<ADM_M018>().ToList();
                    List<ADM_M018> Masterlist = MasterData.ToList();

                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ADM_M018Delete", new { @CatCode = Request }, commandType: CommandType.StoredProcedure);
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
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            MultipleContext_ADM_M018 MC = new MultipleContext_ADM_M018();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M018LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _MasterList = reader.Read<ADM_M018>().ToList();
                        MC.MasterList = _MasterList.ToList();

                        var _AccountCategoryList = reader.Read<ACC_M003_K>().ToList();
                        MC.AccountCategoryList = _AccountCategoryList.ToList();
                    }

                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var _MasterList = reader.Read<ADM_M018>().ToList();
                        MC.MasterList = _MasterList.ToList();
                    }

                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
                }
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
    }

    public class MultipleContext_ADM_M018
    {
        public List<ADM_M018> MasterList { get; set; }
        public List<ACC_M003_K> AccountCategoryList { get; set; }
    }
}
