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
    public class ADM_M001_J_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ADM_M001_J MC = new MultipleContext_ADM_M001_J();
        ADM_M001_J MasterEntity = new ADM_M001_J();
        public ADM_M001_J_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M001_J_BL()
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
                    var reader = conn.QueryMultiple("ADM_M001_J_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    if (RequestOption == "LoadInitialData")
                    {
                        var _AssignSalesGrouptoSalesOfficeList = reader.Read<ADM_M001_J>().ToList();
                        MC.AssignSalesGrouptoSalesOfficeList = _AssignSalesGrouptoSalesOfficeList.ToList();

                        var _SOList = reader.Read<ADM_M001_I_P>().ToList();
                        MC.SOList = _SOList.ToList();

                        var _SGList = reader.Read<ADM_M001_H_P>().ToList();
                        MC.SGList = _SGList.ToList();
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
            ADM_M001_J MasterEntity = new ADM_M001_J();
            MultipleContext_ADM_M001_J MC = new MultipleContext_ADM_M001_J();
            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ADM_M001_J_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _AssignSalesGrouptoSalesOfficeList = reader.Read<ADM_M001_J>().ToList();
                        MC.AssignSalesGrouptoSalesOfficeList = _AssignSalesGrouptoSalesOfficeList.ToList();
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
      


        public class MultipleContext_ADM_M001_J
        {
            public List<ADM_M001_J> AssignSalesGrouptoSalesOfficeList { get; set; }
            public List<ADM_M001_I_P> SOList { get; set; }
            public List<ADM_M001_H_P> SGList { get; set; }

        }
    }
}
