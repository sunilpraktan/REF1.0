using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.ADM;
using Reflection.EF.Admin;
using System.Collections.Generic;
using Reflection.EF.MM;

namespace Reflection.BusinessLogic.MM
{
    public class MM_M0011_BL : ReflectionBusinessLogic
    {
        STD_BE_A MasterEntity = new STD_BE_A();
        MM_M0011_MC MC = new MM_M0011_MC();
        public MM_M0011_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_M0011_INS_UPD", new { @Request = Request }, commandTimeout: 300, commandType: CommandType.StoredProcedure);
                    MC.MASTER_ENTITY_LIST = reader.Read<MM_M0011>().ToList();
                }
                return ObjectSerializationService.ObjectToXML(MC);
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
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_M0011_INS_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                    MC.MASTER_ENTITY_LIST = reader.Read<MM_M0011>().ToList();
                }
                return ObjectSerializationService.ObjectToXML(MasterEntity);
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
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_M0011_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure, commandTimeout: 600);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.MASTER_ENTITY_LIST = reader.Read<MM_M0011>().ToList();
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                        MC.DOC_CAT_LIST = reader.Read<STD_DOC_CAT>().ToList();
                        MC.ITEM_CAT_LIST = reader.Read<ADM_M018>().ToList();
                    }
                    
                }
                strData = ObjectSerializationService.ObjectToXML(MC);

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

    public class MM_M0011_MC : STD_MC_BE
    {
        public List<MM_M0011> MASTER_ENTITY_LIST { get; set; }
    }
}
