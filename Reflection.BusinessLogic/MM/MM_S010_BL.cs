using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using Reflection.EF.SCM;
using System.Data;
using Reflection.EF;
using Reflection.EF.Communication;
using Reflection.EF.MM;
using Reflection.EF.Admin;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic.MM
{
    public class MM_S010_BL : ReflectionBusinessLogic
    {
        MC_MM_S010 MC = new MC_MM_S010();
        public MM_S010_BL()
        { }
        
        public string Insert(string Request)
        {
            string strReturnData = "";
            try
            {
                MC = (MC_MM_S010)ObjectSerializationService.XMLToObject(Request, MC);
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_S010_INS", new { @Request = MC.request }, commandType: CommandType.StoredProcedure, commandTimeout: 0);

                    MC.MasterEntityList = reader.Read<MM_S010>().ToList();
                    MC.ItemEntityList = reader.Read<MM_S010_A>().ToList();
                }
                strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
            string strReturnData = "";
            try
            {
                MC = (MC_MM_S010)ObjectSerializationService.XMLToObject(Request, MC);
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_S010_UPD", new { @Request = MC.request }, commandType: CommandType.StoredProcedure, commandTimeout: 0);

                    MC.MasterEntityList = reader.Read<MM_S010>().ToList();
                    MC.ItemEntityList = reader.Read<MM_S010_A>().ToList();
                }
                strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
            string RequestOption = RequestValue.Split('!')[0];

            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_S010_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure, commandTimeout: 0);
                    {
                        if (RequestOption == "LOAD_INI")
                        {
                            MC.STORE_LIST = reader.Read<MM_M0001>().ToList();
                            MC.UOM_LIST = reader.Read<UOMS>().ToList();
                            MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                            MC.ITEM_CAT_LIST = reader.Read<ADM_M018>().ToList();
                            //MC.ITEM_SUBCAT_LIST = reader.Read<ADM_M019>().ToList();
                            //MC.ITEM_TYPE_LIST = reader.Read<ADM_M015>().ToList();
                            //MC.ITEM_SUBTYPE_LIST = reader.Read<ADM_M016>().ToList();
                            
                        }
                        else if (RequestOption == "LOAD_MATERIALS")
                        {
                            MC.ItemEntityList = reader.Read<MM_S010_A>().ToList();
                        }
                        else if (RequestOption == "LOAD_DOCUMENT")
                        {
                            MC.MasterEntityList = reader.Read<MM_S010>().ToList();
                            MC.ItemEntityList = reader.Read<MM_S010_A>().ToList();
                        }
                        else if (RequestOption == "LOAD_BACKFLIP")
                        {
                            MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                        }
                        return ObjectSerializationService.ObjectToXML(MC);
                    }
                }
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
