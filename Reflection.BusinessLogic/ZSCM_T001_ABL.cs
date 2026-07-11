using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.SCM;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ZSCM_T001_ABL : ReflectionBusinessLogic
    {            
        static int obj = 0;
     
        ZSCM_T001_A zSCM_T001_A = new ZSCM_T001_A();
        private static string connectionString;
        public ZSCM_T001_ABL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZSCM_T001_ABL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            try
            {
                MultipleContext_ZSCM_T001_A MC = new MultipleContext_ZSCM_T001_A();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZSCM_T001_AInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var AvgWt = reader.Read<ZSCM_T001_A>().ToList();
                    zSCM_T001_A = new ZSCM_T001_A();
                    MC.Avg_Wt = AvgWt.ToList();

                    var AvgWtDtl = reader.Read<ZSCM_T001_B>().ToList();
                    zSCM_T001_A = new ZSCM_T001_A();
                    MC.Avg_Wt_Details = AvgWtDtl.ToList();

                    zSCM_T001_A = MC.Avg_Wt[0];
                    zSCM_T001_A.XmlDataDocument_ZSCM_T001_B = ObjectSerializationService.ObjectToXML(MC.Avg_Wt_Details);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(zSCM_T001_A);
                return strReturnData;
            }
            catch (SqlException ex)
            {
                throw new CreateException(ex.ErrorCode, ex.Message, ex);
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new CreateException(ex.Message, ex);
            }
        }
        public string Update(string Request)
        {
            try
            {
                MultipleContext_ZSCM_T001_A MC = new MultipleContext_ZSCM_T001_A();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZSCM_T001_AUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var AvgWt = reader.Read<ZSCM_T001_A>().ToList();
                    zSCM_T001_A = new ZSCM_T001_A();
                    MC.Avg_Wt = AvgWt.ToList();

                    var AvgWtDtl = reader.Read<ZSCM_T001_B>().ToList();
                    zSCM_T001_A = new ZSCM_T001_A();
                    MC.Avg_Wt_Details = AvgWtDtl.ToList();

                    zSCM_T001_A = MC.Avg_Wt[0];
                    zSCM_T001_A.XmlDataDocument_ZSCM_T001_B = ObjectSerializationService.ObjectToXML(MC.Avg_Wt_Details);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(zSCM_T001_A);
                return strReturnData;

            }
            catch (SqlException ex)
            {
                throw new CreateException(ex.ErrorCode, ex.Message, ex);
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new CreateException(ex.Message, ex);
            }
        }
        public string Delete(int Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ADM_M030Delete", new { id = Request }, commandType: CommandType.StoredProcedure);

                    return intOut.ToString();
                }             
            }
            catch (SqlException ex)
            {
                throw new CreateException(ex.ErrorCode, ex.Message, ex);
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new CreateException(ex.Message, ex);
            }
        }
        public string GetData(string strType, int intValue, string strValue)
        {
            MultipleContext_ZSCM_T001_A MC = new MultipleContext_ZSCM_T001_A();
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZSCM_T001_ALoadAll", new
                    {
                        @param = strType,
                        @id = intValue,
                        @request = strValue
                    }, commandType: CommandType.StoredProcedure);

                    if (strType == "LoadAll")
                    {
                        var AvgWt = reader.Read<ZSCM_T001_A>().ToList();
                        MC.Avg_Wt = AvgWt.ToList();

                        var AvgWtDtl = reader.Read<ZSCM_T001_B>().ToList();
                        MC.Avg_Wt_Details = AvgWtDtl.ToList();

                        var wiresize = reader.Read<ZADM_M003_P>().ToList();
                        MC.wiresize = wiresize.ToList();

                        var wiretype = reader.Read<ZADM_M004_P>().ToList();
                        MC.wiretype = wiretype.ToList();

                        var totlen = reader.Read<ZADM_M008_P>().ToList();
                        MC.TotLength = totlen.ToList();

                        var make = reader.Read<ADM_M0032_P>().ToList();
                        MC.Make = make.ToList();

                        var Month = reader.Read<ZSCM_T001_A_Mon>().ToList();
                        MC.Month = Month.ToList();

                        var Year =reader.Read<ZSCM_T001_A_YR>().ToList();
                        MC.Year = Year.ToList();
                    }
                    if (strType == "LoadDetails")
                    {
                        var AvgWtDtl = reader.Read<ZSCM_T001_B>().ToList();
                        MC.Avg_Wt_Details = AvgWtDtl.ToList();
                    }
                    if (strType == "LoadRPT_Details")
                    {
                        var AvgB_Wt_Rpt =reader.Read<ZSCM_T001_A_Rpt>().ToList();
                        MC.AvgB_Wt_Rpt = AvgB_Wt_Rpt.ToList();
                    }
                }
                strData = ObjectSerializationService.ObjectToXML(MC);
                return strData;
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
        public class MultipleContext_ZSCM_T001_A
        {
            public List<ZSCM_T001_A> Avg_Wt { get; set; }//Average Blank Weight
            public List<ZSCM_T001_B> Avg_Wt_Details { get; set; }//Average Blank Weight Detaild
            public List<ZADM_M003_P> wiresize { get; set; }//Wire Size Master       
            public List<ZADM_M004_P> wiretype { get; set; }//Wire Type Master
            public List<ZADM_M008_P> TotLength { get; set; }//Total Length Master
            public List<ADM_M0032_P> Make { get; set; }// Make Master
            public List<ZSCM_T001_A_Mon> Month { get; set; }//Month Year From Average Blank Weight
            public List<ZSCM_T001_A_YR> Year { get; set; }//Month Year From Average Blank Weight
            public List<ZSCM_T001_A_Rpt> AvgB_Wt_Rpt { get; set; }//Month Year From Average Blank Weight
        }
    }
}
