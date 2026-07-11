using Dapper;
using Reflection.EF;
using Reflection.EF.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class MIS_Finance3BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        private List<ACC_T006_A> _dsReport;

        public List<ACC_T006_A> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }

        public MIS_Finance3BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public MIS_Finance3BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {
            MultipleContextMIS_Finance3 MC = new MultipleContextMIS_Finance3();
            string RequestOption = strType.Split('!')[0];
            string RequestOption1 = strType.Split('!')[1];
            string strReturnData = "";
            try
            {

                if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_Finance3", new { @request = strType }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var jetype = reader.Read<ACC_M022>().ToList();
                            MC.JEType = jetype.ToList();
                             
                            var vend = reader.Read<VendorPopup>().ToList();
                            MC.Vendors = vend.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "Report")

                        {
                            var RptMIS_Finance3 = reader.Read<ACC_T006_A>().ToList();
                            MC.MIS_FinanceReportsEntity = RptMIS_Finance3.ToList();

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


    }

    public class MultipleContextMIS_Finance3
    {
        public List<ADM_M024_P> EmployeeList { get; set; }
        public List<ADM_M028_P> PartyDetails { get; set; }
        public List<ACC_M004_P> BankDetails { get; set; }
        public List<ACC_M022> JEType { get; set; }
        public List<VendorPopup> Vendors { get; set; }
        public List<ACC_T006_A> MIS_FinanceReportsEntity { get; set; }
        
    }
}
