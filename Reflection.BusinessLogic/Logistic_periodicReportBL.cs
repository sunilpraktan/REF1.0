using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Web;
using System.Data;
using Reflection.EF.CRM;
using Reflection.EF.SCM;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class Logistic_periodicReportBL : ReflectionBusinessLogic
    {     
        
        static int obj = 0;
        private static string connectionString;
        Logistic_periodicReport aCC_T001_A = new Logistic_periodicReport();

        public Logistic_periodicReportBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public Logistic_periodicReportBL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string strType, int intValue, string strValue)
        {
            MultipleContextLogistic_periodicReport MC = new MultipleContextLogistic_periodicReport();

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZRPT_Logistic", new
                    {
                        @request = strValue,
                        @Type = strType
                    }, commandType: CommandType.StoredProcedure);

                    if (strType == "Logistic_periodicReport")
                    {
                        var PeriodicReportMaster = reader.Read<Logistic_periodicReport>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();

                        var PeriodicReportGodownToPartyMaster = reader.Read<Logistic_periodicReport>().ToList();
                        MC.PeriodicReportGodownToPartyMaster = PeriodicReportGodownToPartyMaster.ToList();

                        var ItemStock = reader.Read<ItemPeriodicReportStock>().ToList();
                        MC.ItemStock = ItemStock.ToList();
                    }
                    if (strType == "Logistic_periodicPartyData")
                    {
                        var Party = reader.Read<ADM_M028_PopUp_Report>().ToList();
                        MC.partyDetails = Party.ToList();
                     
                        var Location = reader.Read<ADM_M003_PopUpwarehouse>().ToList();
                        MC.LocationDetails = Location.ToList();
                     }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MC);
                return strReturnData;
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
        public class MultipleContextLogistic_periodicReport
        {
            public List<Logistic_periodicReport> PeriodicReportMaster { get; set; }
            public List<Logistic_periodicReport> PeriodicReportGodownToPartyMaster { get; set; }
            public List<ADM_M028_PopUp_Report> partyDetails { get; set; }
            public List<ItemPeriodicReportStock> ItemStock { get; set; }
            public List<ADM_M003_PopUpwarehouse> LocationDetails { get; set; }
        }
    }
}
