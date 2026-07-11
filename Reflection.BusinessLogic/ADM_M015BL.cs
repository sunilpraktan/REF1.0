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

namespace Reflection.BusinessLogic
{
    public class ADM_M015BL : ReflectionBusinessLogic
    {

       
        ADM_M015 aDM_M015 = new ADM_M015();
        private static string connectionString;
        public ADM_M015BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M015BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                aDM_M015 = (ADM_M015)ObjectSerializationService.XMLToObject(Request, aDM_M015);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M015Insert",
                    new
                    {
                        @ItemTypeCd = aDM_M015.ItemTypeCd,
                        @ItemTypeNm = aDM_M015.ItemTypeNm,
                        @SubCatCode = aDM_M015.SubCatCode,
                        @user_source1 = aDM_M015.user_source1,
                        @user_source2 = aDM_M015.user_source2,
                        @add_by = (object)aDM_M015.add_by ?? DBNull.Value,
                        @comp_code = "",
                        @client = aDM_M015.client,
                        @lang_key = aDM_M015.lang_key
                    }, commandType: CommandType.StoredProcedure);

                    var itmtp = reader.Read<ADM_M015>().ToList();
                    List<ADM_M015> itmtp1 = itmtp.ToList();
                    if (itmtp1.Count > 0)
                    {
                        aDM_M015 = itmtp1[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M015);
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

                aDM_M015 = (ADM_M015)ObjectSerializationService.XMLToObject(Request, aDM_M015);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M015Update",
                    new
                    {
                        @ItemTypeCd = aDM_M015.ItemTypeCd,
                        @ItemTypeNm = aDM_M015.ItemTypeNm,
                        @SubCatCode = aDM_M015.SubCatCode,
                        @user_source1 = aDM_M015.user_source1,
                        @user_source2 = aDM_M015.user_source2,
                        @editby = (object)aDM_M015.editby ?? DBNull.Value
                    }, commandType: CommandType.StoredProcedure);

                    var itmtp = reader.Read<ADM_M015>().ToList();
                    List<ADM_M015> itmtp1 = itmtp.ToList();
                    if (itmtp1.Count > 0)
                    {
                        aDM_M015 = itmtp1[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M015);
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
                    int intOut = conn.Execute("ADM_M015Delete", new { @ItemTypeCd = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_ADM_M015 MC = new MultipleContext_ADM_M015();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M015LoadAll", commandType: CommandType.StoredProcedure);

                    var ItemTypeList1 = reader.Read<ADM_M015>().ToList();
                    MC.ItemTypeList = ItemTypeList1.ToList();

                    var SubCategoryList1 = reader.Read<ADM_M019_P>().ToList();
                    MC.SubCategoryList = SubCategoryList1.ToList();
                }
                string strData = ObjectSerializationService.ObjectToXML(MC);
                return strData;
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
    public class MultipleContext_ADM_M015
    {
        public List<ADM_M015> ItemTypeList { get; set; }  //SubItmTp Master    
        public List<ADM_M019_P> SubCategoryList { get; set; }  //Sub catagory Master       
    }
}
