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
    public class ADM_M013BL : ReflectionBusinessLogic
    {

       
        static int obj = 0;
        private static string connectionString;
        ADM_M013 aDM_M013 = new ADM_M013();

        public ADM_M013BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M013BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            try
            {
                aDM_M013 = (ADM_M013)ObjectSerializationService.XMLToObject(Request, aDM_M013);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M013Insert", new
                    {
                        @StatAbbre = aDM_M013.StatAbbre,
                        @state_code = aDM_M013.state_code,
                        @StatName = aDM_M013.StatName,
                        @country_code = aDM_M013.country_code,
                        @user_source1 = aDM_M013.user_source1,
                        @user_source2 = aDM_M013.user_source2,
                        @add_by = (object)aDM_M013.add_by ?? DBNull.Value
                    },  commandType: CommandType.StoredProcedure);

                    var subcat = reader.Read<ADM_M013>().ToList();
                    List<ADM_M013> subcatList = subcat.ToList();
                    if (subcatList.Count > 0)
                    {
                        aDM_M013 = subcatList[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M013);
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

                aDM_M013 = (ADM_M013)ObjectSerializationService.XMLToObject(Request, aDM_M013);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M013Update", new
                    {
                        @StatAbbre = aDM_M013.StatAbbre,
                        @state_code = aDM_M013.state_code,
                        @StatName = aDM_M013.StatName,
                        @country_code = aDM_M013.country_code,
                        @user_source1 = aDM_M013.user_source1,
                        @user_source2 = aDM_M013.user_source2,
                        @add_by = (object)aDM_M013.add_by ?? DBNull.Value
                    }, commandType: CommandType.StoredProcedure);

                    var subcat = reader.Read<ADM_M013>().ToList();
                    List<ADM_M013> subcatList = subcat.ToList();
                    if (subcatList.Count > 0)
                    {
                        aDM_M013 = subcatList[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M013);
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
                    int intOut = conn.Execute("ADM_M013Delete", new { @state_code = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_ADM_M013 MC = new MultipleContext_ADM_M013();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M013LoadAll", commandType: CommandType.StoredProcedure);

                    var State1 = reader.Read<ADM_M013>().ToList();
                    MC.State_1 = State1.ToList();

                    var Country1 = reader.Read<ADM_M012_P>().ToList();
                    MC.Country_1 = Country1.ToList();
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

    public class MultipleContext_ADM_M013
    {
        public List<ADM_M013> State_1 { get; set; }  //State Master    
        public List<ADM_M012_P> Country_1 { get; set; }  //Country Master             
    }

}
