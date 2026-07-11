using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Reflection.EF.CRM.ReportEntityCRM;
using Reflection.EF;
using Reflection.EF.Procurement;

namespace Reflection.BusinessLogic
{
    public class MIS_CRM_Purchase1BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        public MIS_CRM_Purchase1BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_CRM_Purchase1BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        MultipleContextMIS_CRM_Purchase MC = new MultipleContextMIS_CRM_Purchase();
        private List<MIS_CRM_PurchaseEntity> _dsReport;
        public List<MIS_CRM_PurchaseEntity> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }
        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {
            MultipleContextMIS_CRM_Purchase MC = new MultipleContextMIS_CRM_Purchase();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";
            try
            {
                if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_CRM_Purchase1", new { @request = strType }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var EmployeeMaster = reader.Read<ADM_M024_P>().ToList();
                            MC.EmployeeList = EmployeeMaster.ToList();

                            var partyData = reader.Read<ADM_M028_P>().ToList();
                            MC.partyDetails = partyData.ToList();

                            var ItemData = reader.Read<ADM_M022_P>().ToList();
                            MC.ItemDetails = ItemData.ToList();

                            var StatusData = reader.Read<PUR_T001_A>().ToList();
                            MC.StatusDetails = StatusData.ToList();

                            var DocNoData = reader.Read<PUR_T002_A_P>().ToList();
                            MC.DocNoList = DocNoData.ToList();

                            var currencyList = reader.Read<ADM_M037_P>().ToList();
                            MC.CurrencyList = currencyList.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "Report")
                        {
                            var RptMIS_CRMPurchase = reader.Read<MIS_CRM_PurchaseEntity>().ToList();
                            dsReport = RptMIS_CRMPurchase.ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(dsReport);
                        }
                    }
                }
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
        public class MultipleContextMIS_CRM_Purchase
        {
            public List<ADM_M024_P> EmployeeList { get; set; }
            public List<ADM_M028_P> partyDetails { get; set; }
            public List<ADM_M022_P> ItemDetails { get; set; }
            public List<PUR_T001_A> StatusDetails { get; set; }
            public List<ADM_M028_B_P> PartyType;
            public List<PUR_T002_A_P> DocNoList { get; set; }
            public List<ADM_M037_P> CurrencyList { get; set; }
        }
    }
}
