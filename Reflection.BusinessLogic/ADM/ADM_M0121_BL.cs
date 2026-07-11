using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;
using Reflection.EF.Finance;
using Reflection.EF.Communication;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic.ADM
{
    public class ADM_M0121_BL : ReflectionBusinessLogic
    {
        Classification MASTER_ENTITY = new Classification();
        Classification_MC MC = new Classification_MC();

        public ADM_M0121_BL()
        {
        }
        public string Insert(string Request, string RequestOption)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M0121_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    List<Classification> CHAR_LIST = reader.Read<Classification>().ToList();
                    if (CHAR_LIST.Count > 0)
                    {
                        MASTER_ENTITY = CHAR_LIST[0];
                    }

                    MC.CHAR_VALUE_OBV_LIST = reader.Read<Classification>().ToList();

                    MASTER_ENTITY.XDOC_A = ObjectSerializationService.ObjectToXML(MC.CHAR_VALUE_OBV_LIST);
                }
                return ObjectSerializationService.ObjectToXML(MASTER_ENTITY);
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
        public string Update(string Request, string RequestOption)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M0121_UPD", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    List<Classification> CHAR_LIST = reader.Read<Classification>().ToList();
                    if (CHAR_LIST.Count > 0)
                    {
                        MASTER_ENTITY = CHAR_LIST[0];
                    }

                    MC.CHAR_VALUE_OBV_LIST = reader.Read<Classification>().ToList();

                    MASTER_ENTITY.XDOC_A = ObjectSerializationService.ObjectToXML(MC.CHAR_VALUE_OBV_LIST);
                }
                return ObjectSerializationService.ObjectToXML(MASTER_ENTITY);
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
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    int intOut = 0; //conn.Execute("ADM_M028Delete", new { @PartyId = Request }, commandType: CommandType.StoredProcedure);
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
            try
            {
                string RequestOption = RequestValue.Split('!')[0];

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M0121_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.DATA_TYPE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.VALUE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.CURRENCY_LIST = reader.Read<ADM_M037>().ToList();
                        MC.CLASS_TYPE_LIST = reader.Read<Classification>().ToList();
                        MC.CHAR_LIST = reader.Read<Classification>().ToList();
                        
                    }

                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.MASTER_LIST = reader.Read<Classification>().ToList();
                        MC.CHAR_VALUE_OBV_LIST = reader.Read<Classification>().ToList();
                    }
                    else if (RequestOption == "LOAD_BACKFLIP")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                }
                return ObjectSerializationService.ObjectToXML(MC);
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
