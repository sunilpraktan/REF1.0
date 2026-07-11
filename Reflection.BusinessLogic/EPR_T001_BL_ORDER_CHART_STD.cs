using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Production;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.ReflectionSystem;
using System.Collections.Generic;
namespace Reflection.BusinessLogic
{
    public class EPR_T001_BL_ORDER_CHART_STD : ReflectionBusinessLogic // NOTE: this BL is used for order chart VM. shift before deleting.
    {
        private static string connectionString;
        EPR_T001 MasterEntity = new EPR_T001();
        MultipleContext_EPR_T001 MC = new MultipleContext_EPR_T001();
        public EPR_T001_BL_ORDER_CHART_STD(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public EPR_T001_BL_ORDER_CHART_STD()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            String strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T001_Insert_STD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    List<EPR_T001> Masterlist = reader.Read<EPR_T001>().ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                }
                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
            String strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T001_Update_STD_ORDER_CHART", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    List<EPR_T001> Masterlist = reader.Read<EPR_T001>().ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                }

                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_EPR_T001 MC = new MultipleContext_EPR_T001();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T001_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "Load_Production_Order_Chart")
                    {
                        MC.MasterEntity = reader.Read<EPR_T001>().ToList();
                        MC.StatusList = reader.Read<SYS_M025>().ToList();
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
}
