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
    public class MIS_Finance4BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        MultipleContextMIS_Finance4 MC = new MultipleContextMIS_Finance4();
        private List<RptLedgerView> _dsReport;
        public List<RptLedgerView> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }

        public MIS_Finance4BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public MIS_Finance4BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {
            MultipleContextMIS_Finance4 MC = new MultipleContextMIS_Finance4();
            string RequestOption = strType.Split('!')[0];
            string RequestOption1 = strType.Split('!')[1];
            string strReturnData = "";
            try
            {

                if (RequestOption == "LoadInitialData" || RequestOption == "Load")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_Finance4", new { @request = strType }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var DocCat = reader.Read<SYS_M014_P>().ToList();
                            MC.DocCatDetails = DocCat.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "Load")

                        {
                            var LoadLedgerViewList = reader.Read<RptLedgerView>().ToList();
                            MC.LedgerViewList = LoadLedgerViewList.ToList();

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

    public class MultipleContextMIS_Finance4
    {
        public List<SYS_M014_P> DocCatDetails { get; set; }
        public List<RptLedgerView> LedgerViewList { get; set; }

    }
}
