using Dapper;
using Reflection.EF;
using Reflection.EF.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class ADM_M003_BBL : ReflectionBusinessLogic
    {
        private static string connectionString;
        ADM_M003_B MasterEntity = new ADM_M003_B();
        MultipleContext_ADM_M003_B MC = new MultipleContext_ADM_M003_B();
        public ADM_M003_BBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M003_BBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M003_BLoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var BackFlipList = reader.Read<ADM_M003_B_Flip>().ToList();
                            MC.BackFlipList = BackFlipList.ToList();

                            var LocationList = reader.Read<ADM_M003_P>().ToList();
                            MC.LocationList = LocationList.ToList();

                            var CountryList = reader.Read<ADM_M012_P>().ToList();
                            MC.CountryList = CountryList.ToList();

                            var StateList = reader.Read<ADM_M013_P>().ToList();
                            MC.StateList = StateList.ToList();

                            var ActivityList = reader.Read<ADM_M004_P>().ToList();
                            MC.ActivityList = ActivityList.ToList();

                            var CompanyList = reader.Read<ADM_M002_P>().ToList();
                            MC.CompanyList = CompanyList.ToList();

                            var Contper = reader.Read<ADM_M024_P>().ToList();
                            MC.ContactPerson = Contper.ToList();


                        }
                       else if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var MasterList = reader.Read<ADM_M003_B>().ToList();
                            MC.MasterEntity = MasterList.ToList();
                        }
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;
                    }
                }
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
        public string Insert(string Request)
        {            
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M003_BInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlipList = reader.Read<ADM_M003_B_Flip>().ToList();
                    MC.BackFlipList = BackFlipList.ToList();

                    var MasterData = reader.Read<ADM_M003_B>().ToList();
                    List<ADM_M003_B> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                }
                MasterEntity.XMLDataDocument_ADM_M003_B = ObjectSerializationService.ObjectToXML(MC.BackFlipList);
                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M003_BUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<ADM_M003_B>().ToList();
                    List<ADM_M003_B> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                }
                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
    }
    public class MultipleContext_ADM_M003_B
    {
        public List<ADM_M003_B> MasterEntity { get; set; }
        public List<ADM_M003_B_Flip> BackFlipList { get; set; }
        public List<ADM_M003_P> LocationList {get;set;}
        public List<ADM_M012_P> CountryList { get; set; }
        public List<ADM_M013_P> StateList { get; set; }
        public List<ADM_M004_P> ActivityList { get; set; }
        public List<ADM_M002_P> CompanyList { get; set; }
        public List<ADM_M024_P> ContactPerson { get; set; }
    }
}
