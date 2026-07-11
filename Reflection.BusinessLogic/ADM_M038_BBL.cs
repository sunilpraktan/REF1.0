using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;

using System.Data.SqlClient;

using System.Data.Common;
using System.Data;
using Reflection.EF.CRM;
using System.Xml.Serialization;
using Reflection.EF.Admin;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ADM_M038_BBL : ReflectionBusinessLogic
    {             
        static int obj = 0;
        private static string connectionString;

        ADM_M038_B aDM_M038_B = new ADM_M038_B();
        public ADM_M038_BBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M038_BBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MultipleContext_ADM_M038_B mc = new MultipleContext_ADM_M038_B();
                aDM_M038_B = (ADM_M038_B)ObjectSerializationService.XMLToObject(Request, aDM_M038_B);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M038_BInsert", new
                    {
                        @Request = Request

                    }, commandType: CommandType.StoredProcedure);

                    var uom = reader.Read<ADM_M038_B>().ToList();
                    aDM_M038_B = new ADM_M038_B();
                    mc.UOM_Master = uom.ToList();
                    aDM_M038_B = mc.UOM_Master[0];
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M038_B);
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
                MultipleContext_ADM_M038_B mc = new MultipleContext_ADM_M038_B();
                aDM_M038_B = (ADM_M038_B)ObjectSerializationService.XMLToObject(Request, aDM_M038_B);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M038_BUpdate", new
                    {
                        @Request = Request

                    }, commandType: CommandType.StoredProcedure);

                    var uom = reader.Read<ADM_M038_B>().ToList();
                    aDM_M038_B = new ADM_M038_B();
                    mc.UOM_Master = uom.ToList();
                    if (mc.UOM_Master.Count > 0)
                    {
                        aDM_M038_B = mc.UOM_Master[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M038_B);
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
                    int intOut = conn.Execute("ADM_M038_BDelete", new { @unit_code = Request }, commandType: CommandType.StoredProcedure);

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
                MultipleContext_ADM_M038_B MC = new MultipleContext_ADM_M038_B();
                string strData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M038_BLoadAll", commandType: CommandType.StoredProcedure);

                    var uom = reader.Read<ADM_M038_B>().ToList();
                    MC.UOM_Master = uom.ToList();

                    var meascls = reader.Read<ADM_M038_A_P>().ToList();
                    MC.Measur_Cls = meascls.ToList();
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
    public class MultipleContext_ADM_M038_B
    {
        public List<ADM_M038_B> UOM_Master { get; set; }//UOM Master    
        public List<ADM_M038_A_P> Measur_Cls { get; set; }//Measurement Class       
    }
}