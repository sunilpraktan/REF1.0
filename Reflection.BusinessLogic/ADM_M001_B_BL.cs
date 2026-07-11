using Dapper;
using Reflection.EF;
using Reflection.EF.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class ADM_M001_B_BL:ReflectionBusinessLogic
    {

        private static String connectionString;
        MultipleContext_ADM_M001_B MC = new MultipleContext_ADM_M001_B();
        ADM_M001_B MasterEntity = new ADM_M001_B();


        public ADM_M001_B_BL(String BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public ADM_M001_B_BL()
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
                    var reader = conn.QueryMultiple("ADM_M001_BLoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _organizationassignlist = reader.Read<ADM_M001_B>().ToList();
                        MC.organizationassignlist = _organizationassignlist.ToList();

                        var _sorganizationlist = reader.Read<ADM_M001_A_P>().ToList();
                        MC.sorganizationlist = _sorganizationlist.ToList();

                        var _companylist = reader.Read<ADM_M002_P>().ToList();
                        MC.companylist = _companylist.ToList();

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
            ADM_M001_B MasterEntity = new ADM_M001_B();
            MultipleContext_ADM_M001_B MC = new MultipleContext_ADM_M001_B();
            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ADM_M001_BInsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _organizationassignlist = reader.Read<ADM_M001_B>().ToList();
                        MC.organizationassignlist = _organizationassignlist.ToList();
                    }
                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    return strReturnData;

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
            

}
    

    public class MultipleContext_ADM_M001_B
    {
        public List<ADM_M001_B> organizationassignlist { get; set; }
        public List<ADM_M001_A_P> sorganizationlist { get; set; }
        public List<ADM_M002_P> companylist { get; set; }
    }


}

