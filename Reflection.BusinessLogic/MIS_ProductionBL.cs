using Reflection.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class MIS_ProductionBL : ReflectionBusinessLogic
    {
        MultipleContext_MIS_Production MC = new MultipleContext_MIS_Production();
        
        private static string connectionString;
        public MIS_ProductionBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_ProductionBL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        //private List<MIS_SCM_ReportEntity> _dsReport;
        //public List<MIS_SCM_ReportEntity> dsReport
        //{
        //    get { return _dsReport; }
        //    set
        //    {
        //        _dsReport = value;
        //    }
        //}

        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_MIS_Production MC = new MultipleContext_MIS_Production();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";

            try
            {

               if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_PRO_RptEntry", new { @request = strType }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            MC.ItemDetails = reader.Read<ADM_M022_P>().ToList();                          
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);                          

                            MC.machineDetails = reader.Read<ZADM_M013_P>().ToList();                         
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                      
                        }

                        else if (RequestOption == "Report")
                        {

                            //var rptGoodsIssueList= reader.Read<MIS_SCM_ReportEntity>().ToList(); 
                            //dsReport = rptGoodsIssueList.ToList();

                            //if (!reader.Read())
                            //{
                            //    reader.Close();
                            //}
                            //strReturnData = ObjectSerializationService.ObjectToXML(dsReport);
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

        public class MultipleContext_MIS_Production
        {          
            public List<ADM_M022_P> ItemDetails { get; set; }     
            public List<ZADM_M013_P> machineDetails { get; set; }
            
        }
    }
}
