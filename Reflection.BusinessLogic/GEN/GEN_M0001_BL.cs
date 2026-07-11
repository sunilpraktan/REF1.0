using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.GEN;
using Reflection.EF.FICO;

namespace Reflection.BusinessLogic.GEN
{
    public class GEN_M0001_BL : ReflectionBusinessLogic
    {
        GEN_M0001 MasterEntity = new GEN_M0001();
        MC_GEN_M0001 MC = new MC_GEN_M0001();

        public GEN_M0001_BL()
        {
        }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("GEN_M0001_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    List<GEN_M0001> PartyList = reader.Read<GEN_M0001>().ToList();
                    if (PartyList.Count > 0)
                    {
                        MasterEntity = PartyList[0];
                    }

                    MC.ADDRESS_M_LIST = reader.Read<GEN_M0011>().ToList();
                    MC.CP_M_LIST = reader.Read<GEN_M0021>().ToList();
                    MC.CN_M_LIST = reader.Read<GEN_M0031>().ToList();

                    MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ADDRESS_M_LIST);
                    MasterEntity.XDOC_B = ObjectSerializationService.ObjectToXML(MC.CP_M_LIST);
                    MasterEntity.XDOC_C = ObjectSerializationService.ObjectToXML(MC.CN_M_LIST);
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
        public string Update(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("GEN_M0001_UPD", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    List<GEN_M0001> PartyList = reader.Read<GEN_M0001>().ToList();
                    if (PartyList.Count > 0)
                    {
                        MasterEntity = PartyList[0];
                    }

                    MC.ADDRESS_M_LIST = reader.Read<GEN_M0011>().ToList();
                    MC.CP_M_LIST = reader.Read<GEN_M0021>().ToList();
                    MC.CN_M_LIST = reader.Read<GEN_M0031>().ToList();

                    MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ADDRESS_M_LIST);
                    MasterEntity.XDOC_B = ObjectSerializationService.ObjectToXML(MC.CP_M_LIST);
                    MasterEntity.XDOC_C = ObjectSerializationService.ObjectToXML(MC.CN_M_LIST);
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
                    var reader = conn.QueryMultiple("GEN_M0001_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.COUNTRY_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.STATE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.CURR_LIST = reader.Read<FICO_M0033>().ToList();
                        MC.TYPE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.PAYTERM_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.GROUP_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.GL_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.COMON_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.COMON_LIST1 = reader.Read<STD_LIST_BE>().ToList();
                        MC.CN_M_LIST_TEMP = reader.Read<GEN_M0031>().ToList();
                        MC.CATEGORY_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.DEFAULT_VALUE_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.PARTY_M_LIST = reader.Read<GEN_M0001>().ToList();
                        MC.ADDRESS_M_LIST = reader.Read<GEN_M0011>().ToList();
                        MC.CP_M_LIST = reader.Read<GEN_M0021>().ToList();
                        MC.CN_M_LIST = reader.Read<GEN_M0031>().ToList();
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
