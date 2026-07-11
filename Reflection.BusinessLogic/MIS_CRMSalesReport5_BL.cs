using Reflection.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Reflection.EF.CRM.ReportEntityCRM;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class MIS_CRMSalesReport5_BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        MultipleContextMISReports MC = new MultipleContextMISReports();
        private List<MIS_CRM_SalesEntity1> _dsReport;
        public List<MIS_CRM_SalesEntity1> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }
        private List<MIS_CRM_SalesEntity2> _dsReport2;
        public List<MIS_CRM_SalesEntity2> dsReport2
        {
            get { return _dsReport2; }
            set
            {
                _dsReport2 = value;
            }
        }
        public MIS_CRMSalesReport5_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_CRMSalesReport5_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {
            MultipleContextMISReports MC = new MultipleContextMISReports();
            string RequestOption = strType.Split('!')[0];
            string RequestOption1 = strType.Split('!')[1];
            string strReturnData = "";
            try
            {
                if (strValue == "MIS_CRM_Sales2")
                {
                    if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                    {
                        using (IDbConnection conn = new SqlConnection(connectionString))
                        {
                            var reader = conn.QueryMultiple("MIS_CRM_SalesPeriodic5", new { @request = strType }, commandType: CommandType.StoredProcedure);

                            if (RequestOption == "LoadInitialData")
                            {
                                var partyData = reader.Read<ADM_M028_P>().ToList();
                                MC.partyDetails = partyData.ToList();

                                var EmployeeData = reader.Read<ADM_M024_P>().ToList();
                                MC.Employee = EmployeeData.ToList();
                                strReturnData = ObjectSerializationService.ObjectToXML(MC);

                                var PartytypeData = reader.Read<ADM_M028_B_P>().ToList();
                                MC.PartyType = PartytypeData.ToList();
                                strReturnData = ObjectSerializationService.ObjectToXML(MC);

                                var group = reader.Read<ADM_M028_A_P>().ToList();
                                MC.Group = group.ToList();
                                strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            }
                            else if (RequestOption == "Report")
                            {
                                if (RequestOption1 == "@R026")
                                {
                                    var RptMIS_CRMSales1 = reader.Read<RptMIS_CRMDatewiseSales1>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List1 = RptMIS_CRMSales1.ToList();
                                    var RptMIS_CRMSales2 = reader.Read<RptMIS_CRMDatewiseSales2N>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List2 = RptMIS_CRMSales2.ToList();
                                    var RptMIS_CRMSales3 = reader.Read<RptMIS_CRMDatewiseSales3>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List3 = RptMIS_CRMSales3.ToList();
                                    var RptMIS_CRMSales4 = reader.Read<RptMIS_CRMDatewiseSales4N>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List4 = RptMIS_CRMSales4.ToList();
                                    var RptMIS_CRMSales5 = reader.Read<RptMIS_CRMDatewiseSales5N>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List5 = RptMIS_CRMSales5.ToList();
                                    var RptMIS_CRMSales6 = reader.Read<RptMIS_CRMDatewiseSales6>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List6 = RptMIS_CRMSales6.ToList();

                                    var RptMIS_CRMSales7 = reader.Read<RptMIS_CRMDatewiseSales7N>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List7 = RptMIS_CRMSales7.ToList();

                                    var RptMIS_CRMSales7N2 = reader.Read<RptMIS_CRMDatewiseSales7N2>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List7N2 = RptMIS_CRMSales7N2.ToList();

                                    var RptMIS_CRMSales7N3 = reader.Read<RptMIS_CRMDatewiseSales7N3>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List7N3 = RptMIS_CRMSales7N3.ToList();

                                    var RptMIS_CRMSales8 = reader.Read<RptMIS_CRMDatewiseSales8N>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List8 = RptMIS_CRMSales8.ToList();
                                    var RptMIS_CRMSales9 = reader.Read<RptMIS_CRMDatewiseSales9>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List9 = RptMIS_CRMSales9.ToList();
                                    var RptMIS_CRMSales10 = reader.Read<RptMIS_CRMDatewiseSales10>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List10 = RptMIS_CRMSales10.ToList();
                                    var RptMIS_CRMSales11 = reader.Read<RptMIS_CRMDatewiseSales11N>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List11 = RptMIS_CRMSales11.ToList();
                                    var RptMIS_CRMSales12 = reader.Read<RptMIS_CRMDatewiseSales12>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List12 = RptMIS_CRMSales12.ToList();
                                    var RptMIS_CRMSales13 = reader.Read<RptMIS_CRMDatewiseSales13>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List13 = RptMIS_CRMSales13.ToList();
                                    var RptMIS_CRMSales14 = reader.Read<RptMIS_CRMDatewiseSales14>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List14 = RptMIS_CRMSales14.ToList();
                                    var RptMIS_CRMSales16 = reader.Read<RptMIS_CRMDatewiseSales16>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List16 = RptMIS_CRMSales16.ToList();
                                    var RptMIS_CRMSales17 = reader.Read<RptMIS_CRMDatewiseSales17>().ToList();
                                    MC.RptMIS_CRMDatewiseSales_List17 = RptMIS_CRMSales17.ToList();


                                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
                                }
                                else
                                {
                                    var RptMIS_CRMSales2 = reader.Read<MIS_CRM_SalesEntity2>().ToList();
                                    MC.RptMIS_CRMSales_List2 = RptMIS_CRMSales2.ToList();
                                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
                                }
                            }

                        }

                    }
                }
                else
                {
                    if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                    {
                        using (IDbConnection conn = new SqlConnection(connectionString))
                        {
                            var reader = conn.QueryMultiple("MIS_CRM_SalesPeriodic5", new { @request = strType }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                            if (RequestOption == "LoadInitialData")
                            {
                                var partyData = reader.Read<ADM_M028_P>().ToList();
                                MC.partyDetails = partyData.ToList();

                                var ItemData = reader.Read<ADM_M022_P>().ToList();
                                MC.ItemDetails = ItemData.ToList();
                                strReturnData = ObjectSerializationService.ObjectToXML(MC);


                            }
                            else if (RequestOption == "Report")
                            {
                                var RptMIS_CRMSales1 = reader.Read<MIS_CRM_SalesEntity1>().ToList();
                                dsReport = RptMIS_CRMSales1.ToList();
                                strReturnData = ObjectSerializationService.ObjectToXML(dsReport);
                            }
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

        public class MultipleContextMISReports
        {
            public List<ADM_M028_P> partyDetails { get; set; }
            public List<ADM_M022_P> ItemDetails { get; set; }
            public List<ADM_M024_P> Employee { get; set; }
            public List<MIS_CRM_SalesEntity1> RptMIS_CRMSales_List { get; set; }
            public List<ADM_M028_B_P> PartyType { get; set; }
            public List<ADM_M028_A_P> Group { get; set; }
            public List<MIS_CRM_SalesEntity2> RptMIS_CRMSales_List2 { get; set; }
            public List<RptMIS_CRMDatewiseSales1> RptMIS_CRMDatewiseSales_List1 { get; set; }
            public List<RptMIS_CRMDatewiseSales2N> RptMIS_CRMDatewiseSales_List2 { get; set; }
            public List<RptMIS_CRMDatewiseSales3> RptMIS_CRMDatewiseSales_List3 { get; set; }
            public List<RptMIS_CRMDatewiseSales4N> RptMIS_CRMDatewiseSales_List4 { get; set; }
            public List<RptMIS_CRMDatewiseSales5N> RptMIS_CRMDatewiseSales_List5 { get; set; }
            public List<RptMIS_CRMDatewiseSales6> RptMIS_CRMDatewiseSales_List6 { get; set; }
            public List<RptMIS_CRMDatewiseSales7N> RptMIS_CRMDatewiseSales_List7 { get; set; }
            public List<RptMIS_CRMDatewiseSales7N2> RptMIS_CRMDatewiseSales_List7N2 { get; set; }
            public List<RptMIS_CRMDatewiseSales7N3> RptMIS_CRMDatewiseSales_List7N3 { get; set; }
            public List<RptMIS_CRMDatewiseSales8N> RptMIS_CRMDatewiseSales_List8 { get; set; }
            public List<RptMIS_CRMDatewiseSales9> RptMIS_CRMDatewiseSales_List9 { get; set; }
            public List<RptMIS_CRMDatewiseSales10> RptMIS_CRMDatewiseSales_List10 { get; set; }
            public List<RptMIS_CRMDatewiseSales11N> RptMIS_CRMDatewiseSales_List11 { get; set; }
            public List<RptMIS_CRMDatewiseSales12> RptMIS_CRMDatewiseSales_List12 { get; set; }
            public List<RptMIS_CRMDatewiseSales13> RptMIS_CRMDatewiseSales_List13 { get; set; }
            public List<RptMIS_CRMDatewiseSales14> RptMIS_CRMDatewiseSales_List14 { get; set; }
            public List<RptMIS_CRMDatewiseSales16> RptMIS_CRMDatewiseSales_List16 { get; set; }
            public List<RptMIS_CRMDatewiseSales17> RptMIS_CRMDatewiseSales_List17 { get; set; }
        }
    }
}
