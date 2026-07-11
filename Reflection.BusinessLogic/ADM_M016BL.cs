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
    public class ADM_M016BL : ReflectionBusinessLogic
    {

        
        ADM_M016 aDM_M016 = new ADM_M016();
        private static string connectionString;
        public ADM_M016BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M016BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                aDM_M016 = (ADM_M016)ObjectSerializationService.XMLToObject(Request, aDM_M016);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M016Insert", new
                    {
                        @SubItemTpCd = aDM_M016.SubItemTpCd,
                        @SubItemTpNm = aDM_M016.SubItemTpNm,
                        @ItemTypeCd = aDM_M016.ItemTypeCd,
                        @user_source1 = aDM_M016.user_source1,
                        @user_source2 = aDM_M016.user_source2,
                        @add_by = (object)aDM_M016.add_by ?? DBNull.Value,
                        @comp_code = "",
                        @client = aDM_M016.client,
                        @lang_key = aDM_M016.lang_key
                    }, commandType: CommandType.StoredProcedure);

                    var subitmtp = reader.Read<ADM_M016>().ToList();
                    List<ADM_M016> subitmtpList = subitmtp.ToList();
                    if (subitmtpList.Count > 0)
                    {
                        aDM_M016 = subitmtpList[0];
                    }
                }      
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M016);
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
                aDM_M016 = (ADM_M016)ObjectSerializationService.XMLToObject(Request, aDM_M016);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M016Update", new
                    {
                        @SubItemTpCd = aDM_M016.SubItemTpCd,
                        @SubItemTpNm = aDM_M016.SubItemTpNm,
                        @ItemTypeCd = aDM_M016.ItemTypeCd,
                        @user_source1 = aDM_M016.user_source1,
                        @user_source2 = aDM_M016.user_source2,
                        @editby = (object)aDM_M016.editby ?? DBNull.Value
                    }, commandType: CommandType.StoredProcedure);

                    var subitmtp = reader.Read<ADM_M016>().ToList();
                    List<ADM_M016> subitmtpList = subitmtp.ToList();
                    if (subitmtpList.Count > 0)
                    {
                        aDM_M016 = subitmtpList[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M016);
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
                    int intOut = conn.Execute("ADM_M016Delete", new { @SubItemTpCd = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_ADM_M016 MC = new MultipleContext_ADM_M016();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M016LoadAll", commandType: CommandType.StoredProcedure);

                    var SubItmTp = reader.Read<ADM_M016>().ToList();
                    MC.SubItmTp = SubItmTp.ToList();

                    var ItmTp = reader.Read<ADM_M015_P>().ToList();
                    MC.ItmTp = ItmTp.ToList();
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

    public class MultipleContext_ADM_M016
    {
        public List<ADM_M016> SubItmTp { get; set; }  //SubItmTp Master    
        public List<ADM_M015_P> ItmTp { get; set; }  //ItmTp Master       
    }
}
