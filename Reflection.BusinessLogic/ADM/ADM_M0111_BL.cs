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
using Reflection.EF.QMS;

namespace Reflection.BusinessLogic.ADM
{
    public class ADM_M0111_BL : ReflectionBusinessLogic
    {
        ADM_M0111 MASTER_ENTITY = new ADM_M0111();
        ADM_M0111_MC MC = new ADM_M0111_MC();

        public ADM_M0111_BL()
        {
        }
        public string Insert(string Request, string RequestOption)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M0111_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    List<ADM_M0111> CHAR_LIST = reader.Read<ADM_M0111>().ToList();
                    if (CHAR_LIST.Count > 0)
                    {
                        MASTER_ENTITY = CHAR_LIST[0];
                    }

                    MC.CHAR_VALUE_OBV_LIST = reader.Read<ADM_M0112>().ToList();

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
                    var reader = conn.QueryMultiple("ADM_M0111_UPD", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    List<ADM_M0111> CHAR_LIST = reader.Read<ADM_M0111>().ToList();
                    if (CHAR_LIST.Count > 0)
                    {
                        MASTER_ENTITY = CHAR_LIST[0];
                    }

                    MC.CHAR_VALUE_OBV_LIST = reader.Read<ADM_M0112>().ToList();

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
                    var reader = conn.QueryMultiple("ADM_M0111_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.DATA_TYPE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.VALUE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.CURRENCY_LIST = reader.Read<ADM_M037>().ToList();
                        MC.GROUP_LIST = reader.Read<STD_LIST_BE>().ToList(); // Char Group List
                        MC.KEY_DATA_LIST = reader.Read<STD_LIST_BE>().ToList(); // System Master Char
                        MC.VC_CLASS_LIST = reader.Read<STD_LIST_BE>().ToList(); // Dependency class reference
                        MC.ProfileTypeList = reader.Read<QMS_M0032>().ToList(); // Profile/Catlog type
                    }

                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.MASTER_LIST = reader.Read<ADM_M0111>().ToList();
                        MC.CHAR_VALUE_OBV_LIST = reader.Read<ADM_M0112>().ToList();
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
