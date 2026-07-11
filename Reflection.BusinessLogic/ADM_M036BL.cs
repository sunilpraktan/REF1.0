using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;

using System.Data;
using Reflection.EF.Admin;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ADM_M036BL : ReflectionBusinessLogic
    {
        
        ADM_M036 aDM_M036 = new ADM_M036();
        private static string connectionString;
        public ADM_M036BL(string BusinessEntity)
        { connectionString = base.ReflectionConnectionString; }
        public ADM_M036BL()
        { connectionString = base.ReflectionConnectionString; }
        public string Insert(string Request)
        {
            try
            {
                aDM_M036 = (ADM_M036)ObjectSerializationService.XMLToObject(Request, aDM_M036);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M036Insert", new
                    {
                        @location_Id = aDM_M036.location_Id,
                        @add_by = aDM_M036.add_by,    //(object)aDM_M036.add_by  ?? DBNull.Value),
                        @XmlDocument = aDM_M036.XmlDataDocument
                    }, commandType: CommandType.StoredProcedure);

                    var itmtp = reader.Read<ADM_M036>().ToList();
                    List<ADM_M036> itmtp1 = itmtp.ToList();

                    aDM_M036.XmlDataDocument = ObjectSerializationService.ObjectToXML(itmtp1);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M036);
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
                aDM_M036 = (ADM_M036)ObjectSerializationService.XMLToObject(Request, aDM_M036);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M036Update", new
                    {
                        @location_Id = aDM_M036.location_Id,
                        @add_by = aDM_M036.add_by,    //(object)aDM_M036.add_by  ?? DBNull.Value),
                        @XmlDocument = aDM_M036.XmlDataDocument
                    }, commandType: CommandType.StoredProcedure);

                    var itmtp = reader.Read<ADM_M036>().ToList();
                    List<ADM_M036> itmtp1 = itmtp.ToList();

                    aDM_M036.XmlDataDocument = ObjectSerializationService.ObjectToXML(itmtp1);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M036);
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
                    int intOut = conn.Execute("ADM_M036Delete", new { @id = Request }, commandType: CommandType.StoredProcedure);

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
        public string GetData()
        {
            MultipleContext_ADM_M036 MC = new MultipleContext_ADM_M036();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M036LoadComboData", commandType: CommandType.StoredProcedure);

                    var location = reader.Read<ADM_M003_popup1>().ToList();
                    MC.location_master = location.ToList();

                    var item = reader.Read<ADM_M022_P>().ToList();
                    MC.item_master = item.ToList();
                }
                string strData = ObjectSerializationService.ObjectToXML(MC);
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
        public string GetData(int intValue)
        {
            ADM_M036 aDM_M036 = new ADM_M036();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M036LoadAll", new
                    {
                        @location_id = intValue
                    }, commandType: CommandType.StoredProcedure);

                    var itmtp = reader.Read<ADM_M036>().ToList();

                    List<ADM_M036> allocation = itmtp.ToList();
                    aDM_M036.XmlDataDocument = ObjectSerializationService.ObjectToXML(allocation);
                }              
                string strData = ObjectSerializationService.ObjectToXML(aDM_M036);
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
    public class MultipleContext_ADM_M036
    {
        //public List<ADM_M036> allocation_master { get; set; }  //SubItmTp Master    
        public List<ADM_M003_popup1> location_master { get; set; }  //ItmTp Master       
        public List<ADM_M022_P> item_master { get; set; }  //ItmTp Master    
    }
    public class ADM_M003_popup1
    {
        public int Location_Id { get; set; }
        public string LoctnCode { get; set; }
        public string LoctnNm { get; set; }
        public string LoctnAbbre { get; set; }
        public Nullable<int> CompCode { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string City { get; set; }
        public Nullable<int> StatCode { get; set; }
        public Nullable<int> CntryCode { get; set; }
        public string PinCode { get; set; }
        public string PhOffi { get; set; }
        public string PhOffiExt { get; set; }
        public string FaxNo { get; set; }
        public string MailId { get; set; }
        public string CentCode { get; set; }
        public Nullable<int> ActivtCode { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public string EditBy { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public Nullable<bool> AiSts { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string ActivityName { get; set; }
        public string CompanyName { get; set; }
    }
}
