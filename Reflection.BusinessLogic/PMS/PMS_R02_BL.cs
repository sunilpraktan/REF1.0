using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic.PMS
{
    public class PMS_R02_BL : ReflectionBusinessLogic
    {
        public PMS_R02_BL()
        { }
        public string GetData(string Request, string QueryOption, int intValue, string strValue)
        {

            STD_MIS_MC_BE MC = new STD_MIS_MC_BE();
            string RequestOption = Request.Split('!')[0];
            try
            {

                if (RequestOption == "LOAD_INI" || RequestOption == "REPORT" || RequestOption == "REPORT_R0002")
                {
                    using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                    {
                        var reader = conn.QueryMultiple("PMS_R02", new { @request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LOAD_INI")
                        {
                            MC.STANDARD_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.REPORT_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.SORT_ORDER_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                            MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                            MC.PARTY_LIST = reader.Read<STD_PARTY>().ToList();
                            MC.ORG_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.ORG_GROUP_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                            MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        }
                        else if (RequestOption == "REPORT")
                        {
                            MC.STD_MIS_LIST = reader.Read<STD_MIS_BE>().ToList();
                        }
                        else if (RequestOption == "REPORT_R0002")
                        {
                            //MC.STD_MIS_LIST = reader.Read<STD_MIS_BE>().ToList();
                            MC.STD_MIS_LIST = reader.Read<STD_MIS_BE>().ToList();
                            MC.STD_MIS_LIST2 = reader.Read<STD_MIS_BE>().ToList();
                            MC.STD_MIS_LIST3 = reader.Read<STD_MIS_BE>().ToList();
                            MC.STD_MIS_LIST4 = reader.Read<STD_MIS_BE>().ToList();
                            //MC.STD_MIS_LIST5 = reader.Read<STD_MIS_BE>().ToList();
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
