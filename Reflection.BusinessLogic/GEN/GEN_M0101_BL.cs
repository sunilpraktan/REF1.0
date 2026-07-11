using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.GEN;
using Reflection.EF.FICO;
using Reflection.EF.General;
using System.Collections.Generic;
using Reflection.EF.Admin;
using Reflection.EF.COM;
using Reflection.EF.Communication;
using Reflection.EF.Procurement;

namespace Reflection.BusinessLogic.GEN
{
    public class GEN_M0101_BL : ReflectionBusinessLogic
    {
        //STD_MC_BE MC = new STD_MC_BE();
        GEN_M0101_MC MC = new GEN_M0101_MC();

        GEN_M0101 OBJ_GEN_M0101 = new GEN_M0101();
        public GEN_M0101_BL()
        {
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            try
            {
                string RequestOption = RequestValue.Split('!')[0];

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("GEN_M0101_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.STYLE_LIST = reader.Read<GEN_M0101>().ToList();
                        MC.MASTER_ENTITY_LIST = MC.STYLE_LIST;
                        
                        //MC_GEN.STYLE_LIST = reader.Read<GEN_M0101>().ToList();
                        //return ObjectSerializationService.ObjectToXML(MC_GEN);
                    }
                    else if (RequestOption == "LOAD_STYLE")
                    {
                        MC.STYLE_LIST = reader.Read<GEN_M0101>().ToList();
                        //return ObjectSerializationService.ObjectToXML(MC);
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

        public string Insert(string Request)
        {
            try
            {
                //MC = (STD_MC_BE)ObjectSerializationService.XMLToObject(Request, MC);
                //MC.request = ObjectSerializationService.ObjectToXML(MC.GEN_CHAR_VALUE_LIST);

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("GEN_M0101_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.STYLE_LIST = reader.Read<GEN_M0101>().ToList();
                    //if (MC.STYLE_LIST.Count > 0)
                    //{
                    //    OBJ_GEN_M0101 = MC.STYLE_LIST[0];
                    //}
                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                //ReturnValue = ObjectSerializationService.ObjectToXML(OBJ_GEN_M0101);
                return ReturnValue;
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
}
