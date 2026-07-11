using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ADM_M019BL : ReflectionBusinessLogic
    {

       
        static int obj = 0;
        private static string connectionString;
     
        ADM_M019 aDM_M019 = new ADM_M019();

        public ADM_M019BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M019BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            try
            {
                aDM_M019 = (ADM_M019)ObjectSerializationService.XMLToObject(Request, aDM_M019);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M019Insert", new
                    {
                        @SubCatCode = aDM_M019.SubCatCode,
                        @SubCatName = aDM_M019.SubCatName,
                        @CatCode = aDM_M019.CatCode,
                        @user_source1 = aDM_M019.user_source1,
                        @user_source2 = aDM_M019.user_source2,
                        @add_by = (object)aDM_M019.add_by ?? DBNull.Value,
                        @comp_code = "",
                        @client = aDM_M019.client,
                        @lang_key = aDM_M019.lang_key
                    }, commandType: CommandType.StoredProcedure);

                    var subcat = reader.Read<ADM_M019>().ToList();
                    List<ADM_M019> subcatList = subcat.ToList();
                    if (subcatList.Count > 0)
                    {
                        aDM_M019 = subcatList[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M019);
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
                aDM_M019 = (ADM_M019)ObjectSerializationService.XMLToObject(Request, aDM_M019);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M019Update", new
                    {
                        @SubCatCode = aDM_M019.SubCatCode,
                        @SubCatName = aDM_M019.SubCatName,
                        @CatCode = aDM_M019.CatCode,
                        @user_source1 = aDM_M019.user_source1,
                        @user_source2 = aDM_M019.user_source2,
                        @editby = (object)aDM_M019.editby ?? DBNull.Value
                    }, commandType: CommandType.StoredProcedure);

                    var subcat = reader.Read<ADM_M019>().ToList();
                    List<ADM_M019> subcatList = subcat.ToList();
                    if (subcatList.Count > 0)
                    {
                        aDM_M019 = subcatList[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M019);
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
                    int intOut = conn.Execute("ADM_M019Delete", new { @SubCatCode = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_ADM_M019 MC = new MultipleContext_ADM_M019();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M019LoadAll", commandType: CommandType.StoredProcedure);

                    var SubCategory1 = reader.Read<ADM_M019>().ToList();
                    MC.SubCategory_1 = SubCategory1.ToList();

                    var Category1 = reader.Read<ADM_M018_P>().ToList();
                    MC.Category_1 = Category1.ToList();
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

    public class MultipleContext_ADM_M019
    {
        public List<ADM_M019> SubCategory_1 { get; set; }  //Sub Category Master    
        public List<ADM_M018_P> Category_1 { get; set; }  //Category Master             
    }

}
