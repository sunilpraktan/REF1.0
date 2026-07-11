using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using Reflection.EF.CRM;
using System.Xml.Serialization;
using Reflection.EF.Admin;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ADM_M011BL : ReflectionBusinessLogic
    {
        
       
        private static string connectionString;
        static int obj = 0;      
        ADM_M011 aDM_M011 = new ADM_M011();
        public ADM_M011BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M011BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                aDM_M011 = (ADM_M011)ObjectSerializationService.XMLToObject(Request, aDM_M011);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M011Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var ParamVal = reader.Read<ADM_M011>().ToList();
                    List<ADM_M011> Parameter = ParamVal.ToList();
                    if (Parameter.Count > 0)
                    {
                        aDM_M011 = Parameter[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M011);
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
                aDM_M011 = (ADM_M011)ObjectSerializationService.XMLToObject(Request, aDM_M011);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ADM_M011Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                    {
                        return intOut.ToString();
                    }
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
        public string Delete(int Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ADM_M011Delete", new { @id = Request }, commandType: CommandType.StoredProcedure);
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

            MultipleContext_ADM_M011 MC = new MultipleContext_ADM_M011();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M011LoadAll", commandType: CommandType.StoredProcedure);

                    var ParamVal = reader.Read<ADM_M011>().ToList();
                    MC.Warehouse = ParamVal.ToList();

                    var loctn = reader.Read<ADM_M003_PopUp>().ToList();
                    MC.Locations = loctn.ToList();
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
    public class MultipleContext_ADM_M011
    {
        public List<ADM_M011> Warehouse { get; set; }//Warehouse Master
        public List<ADM_M003_PopUp> Locations { get; set; }//Location Master       
    }
}
