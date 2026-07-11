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
    public class ADM_M012BL : ReflectionBusinessLogic
    {
        
        static int obj = 0;
        private static string connectionString;
        ADM_M012 aDM_M012 = new ADM_M012();
        public ADM_M012BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M012BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        #region Insert
        public string Insert(string Request)
        {
            try
            {
                aDM_M012 = (ADM_M012)ObjectSerializationService.XMLToObject(Request, aDM_M012);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M012Insert", new { @country_code= aDM_M012.country_code , @CntryName = aDM_M012.CntryName,
                    @CntryAbbre = aDM_M012.CntryAbbre, @CntryCurncy = aDM_M012.CntryCurncy, @CntryFlag = aDM_M012.CntryFlag ,
                    @user_source1 = aDM_M012.user_source1 , @user_source2 = aDM_M012.user_source2 ,@add_by = aDM_M012.add_by }, commandType: CommandType.StoredProcedure);

                    var cntry = reader.Read<ADM_M012>();
                    List<ADM_M012> cntryList = cntry.ToList();
                    if (cntryList.Count > 0)
                    {
                        aDM_M012 = cntryList[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M012);
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

        #endregion

        #region Getdata
        public string GetData()
        {
            string strValue = "";
            try
            {
                List<ADM_M012> dept = new List<ADM_M012>();
                //dept = dbContext.ADM_M012LoadAll().ToList();
                
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M012LoadAll", commandType: CommandType.StoredProcedure);

                    dept = reader.Read<ADM_M012>().ToList();
                }
                 
          
                strValue = ObjectSerializationService.ObjectToXML(dept);
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

            return strValue;
        }
        #endregion

        #region Update
        public string Update(string Request)
        {
            try
            {
                aDM_M012 = (ADM_M012)ObjectSerializationService.XMLToObject(Request, aDM_M012);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M012Update", new
                    {              
                        @country_code = aDM_M012.country_code,
                        @CntryName = aDM_M012.CntryName,
                        @CntryAbbre = aDM_M012.CntryAbbre,
                        @CntryCurncy = aDM_M012.CntryCurncy,
                        @CntryFlag = aDM_M012.CntryFlag,
                        @user_source1 = aDM_M012.user_source1,
                        @user_source2 = aDM_M012.user_source2,
                        @editby = aDM_M012.editby
                    }, commandType: CommandType.StoredProcedure);

                    var cntry = reader.Read<ADM_M012>().ToList();
                    List<ADM_M012> cntryList = cntry.ToList();
                    if (cntryList.Count > 0)
                    {
                        aDM_M012 = cntryList[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M012);
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
        #endregion

        #region Delete
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ADM_M012Delete", new { @country_code = Request }, commandType: CommandType.StoredProcedure);
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
        #endregion
    }
}