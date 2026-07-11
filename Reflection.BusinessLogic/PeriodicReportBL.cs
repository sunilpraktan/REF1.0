//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Reflection.BusinessLogic
//{
//    class PeriodicReportBL
//    {
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.CRM;
using Reflection.EF.SCM;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class PeriodicReportBL : ReflectionBusinessLogic
    {
        private static string connectionString;

        public PeriodicReportBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public PeriodicReportBL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string strType, int intValue, string strValue)
        {
            MultipleContextPeriodicReport MC = new MultipleContextPeriodicReport();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PeriodicReportData", new
                    {
                        @request = strValue,
                        @Type = strType,
                        @comp_id = intValue,
                    }, commandType: CommandType.StoredProcedure);


                    if (strType == "BalanceOFClosedPO")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();

                    }
                    if (strType == "BalancePOSchedule")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();

                    }
                    if (strType == "TotalScheduleReceived")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();

                    }
                    if (strType == "ScheduleWithoutPO")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();

                    }
                    if (strType == "SoVersesDelivery")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();

                    }

                    if (strType == "ScheduleVersesDelivery")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();

                    }
                    if (strType == "MasterData")
                    {
                        var Party = reader.Read<ADM_M028_PopUp_Report>().ToList();
                        MC.partyDetails = Party.ToList();

                        var Location = reader.Read<ADM_M028_PopUpMasterItemData>().ToList();
                        MC.ItemDetails = Location.ToList();

                        var companyDetails = reader.Read<CompanyData>().ToList();
                        MC.companyDetails = companyDetails.ToList();

                    }
                    if (strType == "MasterDataForPurchase")
                    {
                        var Party = reader.Read<ADM_M028_PopUp_Report>().ToList();
                        MC.partyDetails = Party.ToList();
                       

                        var Location = reader.Read<ADM_M028_PopUpMasterItemData>().ToList();
                        MC.ItemDetails = Location.ToList();
                     
                    }
                    if (strType == "BalanceOFClosedPurchasePO")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();
                      
                    }
                    if (strType == "ScheduleVersesDeliveryPurchase")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();
                        
                    }
                    if (strType == "TotalScheduleReceivedPurchase")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();
                      
                    }

                    if (strType == "CustomerWisePO")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();
                     
                    }

                    if (strType == "CustomerWisePOSchedule")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();
                        
                    }
                    if (strType == "CustomerWisePOSchedulestatus")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();
                      
                    }
                    if (strType == "RequirementWithoutPO")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();
                     
                    }
                    if (strType == "RequirementWithoutSchedule")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();
                        
                    }
                    if (strType == "RequirementWithoutPO_Schedule")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();
                      
                    }
                    if (strType == "SheduleWithoutSO")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();
                       
                    }
                    if (strType == "SheduleRptWithoutPO")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();
                      
                    }
                    if (strType == "SOWithoutPO")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();
                        
                    }
                    if (strType == "InvoiceWithoutPO")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();
                      
                    }
                    if (strType == "InvoicePOWithoutSO")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();
                        
                    }
                    if (strType == "POvsRequirementvsBalance")
                    {
                        var PeriodicReportMaster = reader.Read<BalanceOFClosedPO>().ToList();
                        MC.PeriodicReportMaster = PeriodicReportMaster.ToList();
                        
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


        public class MultipleContextPeriodicReport
        {
            public List<BalanceOFClosedPO> PeriodicReportMaster { get; set; }
            public List<ADM_M028_PopUp_Report> partyDetails { get; set; }
            public List<ItemPeriodicReportStock> ItemStock { get; set; }
            public List<ADM_M028_PopUpMasterItemData> ItemDetails { get; set; }
            public List<CompanyData> companyDetails { get; set; }

        }
    }
}

