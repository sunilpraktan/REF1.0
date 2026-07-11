using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.ADM;
using Reflection.EF.Admin;

namespace Reflection.BusinessLogic.QMS
{
    public class ADM_R02_BL : ReflectionBusinessLogic
    {
        public ADM_R02_BL()
        { }
        public string GetData(string Request, string QueryOption, int intValue, string strValue)
        {

            STD_MIS_MC_BE MC = new STD_MIS_MC_BE();
            string RequestOption = Request.Split('!')[0];
            try
            {

                if (RequestOption == "LOAD_INI" || RequestOption == "REPORT")
                {
                    using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                    {
                        var reader = conn.QueryMultiple("ADM_R02", new { @request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LOAD_INI")
                        {
                            MC.REPORT_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.SORT_ORDER_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                            MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                            MC.ORG_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.ORG_GROUP_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.ITEM_CAT_LIST = reader.Read<ADM_M018>().ToList();
                            MC.ITEM_SUBCAT_LIST = reader.Read<ADM_M019>().ToList();
                            MC.ITEM_TYPE_LIST = reader.Read<ADM_M015>().ToList();
                            MC.ITEM_SUBTYPE_LIST = reader.Read<ADM_M016>().ToList();
                            MC.CURRENCY_LIST = reader.Read<ADM_M037>().ToList();
                            MC.UOM_LIST = reader.Read<UOMS>().ToList();
                            MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        }
                        else if (RequestOption == "REPORT")
                        {
                            MC.STD_MIS_LIST = reader.Read<STD_MIS_BE>().ToList();
                        }
                        base.ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
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
