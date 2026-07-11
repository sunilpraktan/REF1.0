using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.CRM;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ZACC_T001_ABL : ReflectionBusinessLogic
    {
        //GenericRepository<ZACC_T001_A> repository = new GenericRepository<ZACC_T001_A>();
        // CRMDBEntities dbContext = new CRMDBEntities();
        private static string connectionString;
        ZACC_T001_A ZACC_T001 = new ZACC_T001_A();
     
        public ZACC_T001_ABL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZACC_T001_ABL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MultipleContext_ZACC_T001_A MC = new MultipleContext_ZACC_T001_A();
                ZACC_T001 = new ZACC_T001_A();
                ZACC_T001 = (ZACC_T001_A)ObjectSerializationService.XMLToObject(Request, ZACC_T001);
              
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZACC_T001_AInsert", new { @add_by = ZACC_T001.add_by,
                        @xdoc = ZACC_T001.XmlDataDocument_ZACC_T001,
                        @Month= ZACC_T001.mon,
                        @Year= ZACC_T001.yr

                    }, commandType: CommandType.StoredProcedure);
                    var MonthYear = reader.Read<ZACC_T001>().ToList();
                    MC.MonthYear = MonthYear.ToList();
                   

                    var RateEntryDeatils = reader.Read<ZACC_T001_A>().ToList();
                    MC.RateEntryDeatils = RateEntryDeatils.ToList();
                   

                    if (MC.RateEntryDeatils.Count > 0)
                    {
                        ZACC_T001 = MC.RateEntryDeatils[0];
                    }
                    ZACC_T001.XmlDataDocument_ZACC_T001 = ObjectSerializationService.ObjectToXML(MC.RateEntryDeatils);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(ZACC_T001);
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
                ZACC_T001 = new ZACC_T001_A();
                MultipleContext_ZACC_T001_A MC = new MultipleContext_ZACC_T001_A();
                ZACC_T001 = (ZACC_T001_A)ObjectSerializationService.XMLToObject(Request, ZACC_T001);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZACC_T001_AUpdate", new
                    {
                        @add_by = ZACC_T001.add_by,
                        @xdoc = ZACC_T001.XmlDataDocument_ZACC_T001,
                        @Month = ZACC_T001.mon,
                        @Year = ZACC_T001.yr

                    }, commandType: CommandType.StoredProcedure);


                    var MonthYear = reader.Read<ZACC_T001>().ToList();
                    MC.MonthYear = MonthYear.ToList();

                    var RateEntryDeatils = reader.Read<ZACC_T001_A>().ToList();
                    MC.RateEntryDeatils = RateEntryDeatils.ToList();



                    if (MC.RateEntryDeatils.Count > 0)
                    {
                        ZACC_T001 = MC.RateEntryDeatils[0];
                    }
                    ZACC_T001.XmlDataDocument_ZACC_T001 = ObjectSerializationService.ObjectToXML(MC.RateEntryDeatils);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(ZACC_T001);
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
                    int intOut = conn.Execute("ZACC_T001_ADelete", new { @id = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_ZACC_T001_A MC = new MultipleContext_ZACC_T001_A();
            string strData = "";
            try
            {
               
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZACC_T001_ALoadAll", new
                    {
                         @request = strValue,
                     
                    }, commandType: CommandType.StoredProcedure);

                    if (strType == "LoadALL")
                    {
                        var MonthYear = reader.Read<ZACC_T001>().ToList();
                        MC.MonthYear = MonthYear.ToList();
                       

                        var RateEntryDeatils = reader.Read<ZACC_T001_A>().ToList();
                        MC.RateEntryDeatils = RateEntryDeatils.ToList();
                       

                        var WireSize = reader.Read<ZACC_T001_WireSize>().ToList();
                        MC.WireSize = WireSize.ToList();
                      

                        var WireType = reader.Read<ZACC_T001_WireType>().ToList();
                        MC.WireType = WireType.ToList();
                      

                        var BallType = reader.Read<ZACC_T001_BallType>().ToList();
                        MC.BallType = BallType.ToList();
                        

                        var TipLength = reader.Read<ZACC_T001_TipLength>().ToList();
                        MC.TipLength = TipLength.ToList();
                     

                        var Pre_Year = reader.Read<ZACC_T001_Pre_Year>().ToList();
                        MC.Pre_Year = Pre_Year.ToList();
                       

                        var Unit = reader.Read<ZACC_T001_Unit>().ToList();
                        MC.Unit = Unit.ToList();
                     
                    }
                    else if (strType == "LoadRateDetailData")
                    {
                        var RateEntryDeatils = reader.Read<ZACC_T001_A>().ToList();
                        MC.RateEntryDeatils = RateEntryDeatils.ToList();
                      
                    }
                    else if (strType == "LoadMonthYearData")
                    {
                        var MonthYear = reader.Read<ZACC_T001>().ToList();
                        MC.MonthYear = MonthYear.ToList();
                       

                        var RateEntryDeatils = reader.Read<ZACC_T001_A>().ToList();
                        MC.RateEntryDeatils = RateEntryDeatils.ToList();
                        
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
    }

    public class MultipleContext_ZACC_T001_A
    {
        public List<ZACC_T001_A> RateEntryDeatils { get; set; }
        public List<ZACC_T001> MonthYear { get; set; }
        public List<ZACC_T001_WireSize> WireSize { get; set; }
        public List<ZACC_T001_WireType> WireType { get; set; }
        public List<ZACC_T001_BallType> BallType { get; set; }
        public List<ZACC_T001_TipLength> TipLength { get; set; }
        public List<ZACC_T001_Pre_Year> Pre_Year { get; set; }
        public List<ZACC_T001_Unit> Unit { get; set; }

    }
}


