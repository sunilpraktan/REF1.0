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
    public class ADM_M001_H_BL : ReflectionBusinessLogic
    {
        public static string connectionString;
        MultipleContextADM_M001_H MC = new MultipleContextADM_M001_H();
        ADM_M001_H MasterEntity = new ADM_M001_H();
        
        public ADM_M001_H_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public ADM_M001_H_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M001_H_InsertUpdate", new {@Request = Request},commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    var SalesGroup = reader.Read<ADM_M001_H>().ToList();
                    MC.SalesGroupList = SalesGroup.ToList();
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MC);
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

        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M001_H_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var SalesGroup = reader.Read<ADM_M001_H>().ToList();
                        MC.SalesGroupList = SalesGroup.ToList();

                        var SalesOrg = reader.Read<ADM_M001_A_P>().ToList();
                        MC.SalesOrgList = SalesOrg.ToList();

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

    }

    public class MultipleContextADM_M001_H
    {
        public List<ADM_M001_H> SalesGroupList { get; set; }
        public List<ADM_M001_A_P> SalesOrgList { get; set; }
        
    }
        
}
