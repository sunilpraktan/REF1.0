using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using Reflection.EF.Admin;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ADM_M009BL : ReflectionBusinessLogic
    {     
        
        private static string connectionString;
        static int obj = 0;
 
        ADM_M009 aDM_M009 = new ADM_M009();

        public ADM_M009BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M009BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MultipleContext_ADM_M009B mc = new MultipleContext_ADM_M009B();
                aDM_M009 = (ADM_M009)ObjectSerializationService.XMLToObject(Request, aDM_M009);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M009Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var RoleDat = reader.Read<ADM_M009>().ToList();    
                    mc.RoleData = RoleDat.ToList();

                    var RolDetail = reader.Read<ADM_M009B>().ToList();           
                    mc.RolDetails = RolDetail.ToList();

                    aDM_M009 = mc.RoleData[0];
                    aDM_M009.XmlDataDocument = ObjectSerializationService.ObjectToXML(mc.RolDetails);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M009);
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
                MultipleContext_ADM_M009B mc = new MultipleContext_ADM_M009B();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M009Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var RoleDat = reader.Read<ADM_M009>().ToList();
                    mc.RoleData = RoleDat.ToList();

                    var RolDetail = reader.Read<ADM_M009B>().ToList();
                    mc.RolDetails = RolDetail.ToList();
                    if (mc.RoleData.Count > 0)
                    {
                        aDM_M009 = mc.RoleData[0];
                    }
                    aDM_M009.XmlDataDocument = ObjectSerializationService.ObjectToXML(mc.RolDetails);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M009);
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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = 0; //conn.Execute("ADM_M009Delete", new { @RoleCode = Request }, commandType: CommandType.StoredProcedure);
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
            try
            {
                MultipleContext_ADM_M009B MC = new MultipleContext_ADM_M009B();
                string strData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M009LoadAll", commandType: CommandType.StoredProcedure);

                    var RolDat = reader.Read<ADM_M009>().ToList();
                    MC.RoleData = RolDat.ToList();

                    var RolDtlsData = reader.Read<ADM_M009B>().ToList();
                    MC.RolDetails = RolDtlsData.ToList();

                    var Location = reader.Read<ADM_M003_P>().ToList();
                    MC.Locations = Location.ToList();

                    var Authorisation = reader.Read<ADM_M005_P>().ToList();
                    MC.Authorisations = Authorisation.ToList();

                    var Transaction = reader.Read<ADM_M008B_P>().ToList();
                    MC.Transactions = Transaction.ToList();
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
        public class MultipleContext_ADM_M009B
        {
            public List<ADM_M009> RoleData { get; set; }//Role Master
            public List<ADM_M009B> RolDetails { get; set; } //RoleDetails
            public List<ADM_M003_P> Locations { get; set; }//Location Master
            public List<ADM_M005_P> Authorisations { get; set; }//Authorisation Master
            public List<ADM_M008B_P> Transactions { get; set; } //View Master
        }

    }
}
