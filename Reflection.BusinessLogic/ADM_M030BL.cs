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
    public class ADM_M030BL : ReflectionBusinessLogic
    {
        private static String connectionString;
        ADM_M030 MasterEntity = new ADM_M030();
        MultipleContext_ADM_M030 MC = new MultipleContext_ADM_M030();
                       
        public ADM_M030BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M030BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {                                
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M030Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var ParamVal = reader.Read<ADM_M030>().ToList();
                    MC.ParameterValue = ParamVal.ToList();
                    
                    MasterEntity.XmlDataDocument_ADM_M030 = ObjectSerializationService.ObjectToXML(MC.ParameterValue);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M030Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var ParamVal = reader.Read<ADM_M030>();
                    List<ADM_M030> Parameter = ParamVal.ToList();
                    if (Parameter.Count > 0)
                    {
                        MasterEntity = Parameter[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
                    int intOut = 0;  //conn.Execute("ADM_M030Delete", new { @value_code = Request }, commandType: CommandType.StoredProcedure);
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {

            MultipleContext_ADM_M030 MC = new MultipleContext_ADM_M030();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M030LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var ParamVal = reader.Read<ADM_M030>().ToList();
                    MC.ParameterValue = ParamVal.ToList();

                    var Param = reader.Read<ADM_M031_P>().ToList();
                    MC.ParamList = Param.ToList();

                    var UnitList = reader.Read<ADM_M038_B_P>().ToList();
                    MC.UnitList = UnitList.ToList();
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
    public class MultipleContext_ADM_M030
    {
        public List<ADM_M030> ParameterValue { get; set; }  //Parameter Value Master
        public List<ADM_M031_P> ParamList { get; set; } //Parameter Master    
        public List<ADM_M038_B_P> UnitList { get; set; }    //Parameter Master   
    }
}
