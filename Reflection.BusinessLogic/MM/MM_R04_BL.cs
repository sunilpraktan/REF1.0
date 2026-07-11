using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.Admin;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.ADM;
using Reflection.EF.MM;

namespace Reflection.BusinessLogic.MM
{
    public class MM_R04_BL : ReflectionBusinessLogic
    {
        public MM_R04_BL()
        { }
        public string GetData(string Request, string QueryOption, int intValue, string strValue)
        {

            STD_MIS_MC_BE MC = new STD_MIS_MC_BE();
            string RequestOption = Request.Split('!')[0];
            try
            {

                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_R04", new { @request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.REPORT_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.STORE_LIST = reader.Read<MM_M0001>().ToList();
                        MC.STD_ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                        MC.ITEM_CAT_LIST = reader.Read<ADM_M018>().ToList();
                        MC.ITEM_SUBCAT_LIST = reader.Read<ADM_M019>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.ASSET_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "REPORT")
                    {
                        MC.STD_MIS_LIST = reader.Read<STD_MIS_BE>().ToList();
                    }
                    else
                    {
                        MC.STD_MIS_LIST = reader.Read<STD_MIS_BE>().ToList();
                    }
                    base.ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                }
                return base.ReturnValue;
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
