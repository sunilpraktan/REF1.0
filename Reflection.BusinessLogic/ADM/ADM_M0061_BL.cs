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
    public class ADM_M0061_BL : ReflectionBusinessLogic
    {
        ADM_M0061 MasterEntity = new ADM_M0061();
        ADM_M0061_MC MC = new ADM_M0061_MC();

        public ADM_M0061_BL()
        {
        }
        public string Insert(string Request, string RequestOption)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M0061_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    List<ADM_M0061> CATLOG_LIST = reader.Read<ADM_M0061>().ToList();
                    if (CATLOG_LIST.Count > 0)
                    {
                        MasterEntity = CATLOG_LIST[0];
                    }

                    MC.ITEM_ENTITY_LIST = reader.Read<ADM_M0061_A>().ToList();

                    MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ITEM_ENTITY_LIST);
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
        public string Update(string Request, string RequestOption)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M0061_UPD", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    List<ADM_M0061> CATLOG_LIST = reader.Read<ADM_M0061>().ToList();
                    if (CATLOG_LIST.Count > 0)
                    {
                        MasterEntity = CATLOG_LIST[0];
                    }

                    MC.ITEM_ENTITY_LIST = reader.Read<ADM_M0061_A>().ToList();

                    MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ITEM_ENTITY_LIST);
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
                    var reader = conn.QueryMultiple("ADM_M0061_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.STD_ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.CURRENCY_LIST = reader.Read<ADM_M037>().ToList();
                        MC.STANDARD_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.CATLOG_SETTING_LIST = reader.Read<ADM_M0061_A>().ToList();
                        MC.PARTY_LIST = reader.Read<STD_PARTY>().ToList();
                        MC.TAX_LIST = reader.Read<ACC_M013>().ToList();
                        MC.ORG_GROUP_LIST = reader.Read<STD_LIST_BE>().ToList();

                    }

                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.MASTER_ENTITY_LIST = reader.Read<ADM_M0061>().ToList();
                        MC.ITEM_ENTITY_LIST = reader.Read<ADM_M0061_A>().ToList();
                    }
                    else if (RequestOption == "LOAD_BACKFLIP")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "RUN_COSTING")
                    {
                        MC.ITEM_ENTITY_LIST = reader.Read<ADM_M0061_A>().ToList();
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
