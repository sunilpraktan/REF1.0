using Reflection.EF.Finance;
using Reflection.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Reflection.EF.Finance.ReportEntityFinance;
using System.Data;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class MIS_FinancePaymentBL : ReflectionBusinessLogic
    {
        private static string connectionString;
       
        private List<MIS_PaymentReports> _dsReport;
        public List<MIS_PaymentReports> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }
        public MIS_FinancePaymentBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_FinancePaymentBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {
            MultipleContextMIS_FinanceReport MC = new MultipleContextMIS_FinanceReport();
            string RequestOption = strType.Split('!')[0];
            string RequestOption1 = strType.Split('!')[1];
            string strReturnData = "";
            try
            {
               
                if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_Finance_Payment", new { @request = strType },commandTimeout:500, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var emp = reader.Read<ADM_M024_P>().ToList();
                            MC.EmployeeList = emp.ToList();

                            var partyData = reader.Read<ADM_M028_P>().ToList();
                            MC.PartyDetails = partyData.ToList();

                            var bankData = reader.Read<ACC_M004_P>().ToList();
                            MC.BankDetails = bankData.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "Report")

                         {
                            if (RequestOption1 == "@R002" || RequestOption1 == "@R003")
                            {

                                var RptMIS_FinancePayment1 = reader.Read<RptPaymentBalance>().ToList();
                                MC.RptPaymentBalanceEntity = RptMIS_FinancePayment1.ToList();

                                var RptMIS_FinancePayment2 = reader.Read<RptPaymentBalance1>().ToList();
                                MC.RptPaymentBalanceEntity1 = RptMIS_FinancePayment2.ToList();

                                var RptMIS_FinancePayment3 = reader.Read<RptPaymentBalance2>().ToList();
                                MC.RptPaymentBalanceEntity2 = RptMIS_FinancePayment3.ToList();

                                var RptMIS_FinancePayment4 = reader.Read<RptPaymentBalance3>().ToList();
                                MC.RptPaymentBalanceEntity3 = RptMIS_FinancePayment4.ToList();

                                var RptMIS_FinancePayment5 = reader.Read<RptPaymentBalance4>().ToList();
                                MC.RptPaymentBalanceEntity4 = RptMIS_FinancePayment5.ToList();

                            }
                            else
                            {
                                var RptMIS_FinancePayment = reader.Read<MIS_PaymentReports>().ToList();
                                MC.MIS_PaymentReportsEntity = RptMIS_FinancePayment.ToList();
                            }
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);



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
        public class MultipleContextMIS_FinanceReport
        {
            public List<ADM_M024_P> EmployeeList { get; set; }
            public List<ADM_M028_P> PartyDetails { get; set; }
            public List<ACC_M004_P> BankDetails { get; set; }
            public List<MIS_PaymentReports> MIS_PaymentReportsEntity { get; set; }
            public List<RptPaymentBalance> RptPaymentBalanceEntity { get; set; }
            public List<RptPaymentBalance1> RptPaymentBalanceEntity1 { get; set; }
            public List<RptPaymentBalance2> RptPaymentBalanceEntity2 { get; set; }
            public List<RptPaymentBalance3> RptPaymentBalanceEntity3 { get; set; }
            public List<RptPaymentBalance4> RptPaymentBalanceEntity4 { get; set; }
        }
    }
}
