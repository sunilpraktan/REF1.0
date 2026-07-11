using Dapper;
using Reflection.EF;
using Reflection.EF.Finance.ReportEntityFinance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class MIS_Tour_ManagementBL : ReflectionBusinessLogic
    {
        private static string connectionString;
        public MIS_Tour_ManagementBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_Tour_ManagementBL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        MultipleContextMIS_Tour_Management MC = new MultipleContextMIS_Tour_Management();
        private List<MIS_Tour_Voucher> _dsReport;
        public List<MIS_Tour_Voucher> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }
        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {

            MultipleContextMIS_Tour_Management MC = new MultipleContextMIS_Tour_Management();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";
            try
            {

                if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_Tour_Management", new { @request = strType }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var EmployeeMaster = reader.Read<ADM_M024_P>().ToList();
                            MC.EmployeeList = EmployeeMaster.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);

                        }
                        else if (RequestOption == "Report")
                        {
                            var MIS_Tour_Voucher = reader.Read<MIS_Tour_Voucher>().ToList();
                            dsReport = MIS_Tour_Voucher.ToList();
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

        public class MultipleContextMIS_Tour_Management
        {
            public List<ADM_M024_P> EmployeeList { get; set; }
            public List<ADM_M001_A_P> SalesOrg { get; set; }
            public List<ADM_M001_H_P> SalesGroup { get; set; }
            public List<MIS_Tour_Voucher> RptMIS_MIS_Tour_Voucher { get; set; }
           



        }
    }
}
