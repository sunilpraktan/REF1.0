using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF.Communication;
using Reflection.EF;
using Dapper;
using Reflection.EF.Project_Management;
using System.Data;
using System.Data.SqlClient;

namespace Reflection.BusinessLogic
{
    class PRO_M003BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        PRO_M003 MasterEntity = new PRO_M003();
        MultipleContext_PRO_M003 MC = new MultipleContext_PRO_M003();

        public PRO_M003BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public PRO_M003BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_PRO_M003 MC = new MultipleContext_PRO_M003();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PRO_M003LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var PhaseTemp = reader.Read<PRO_M003>().ToList();
                        MC.PhaseList  = PhaseTemp.ToList();
                    }                 

                }
                strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
        public string Insert(string Request)
        {
            MultipleContext_PRO_M003 MC = new MultipleContext_PRO_M003();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PRO_M003Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var PhaseData = reader.Read<PRO_M003>().ToList();
                    MC.PhaseList = PhaseData.ToList();

                    MasterEntity = MC.PhaseList[0];

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.PhaseList);

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
        public string Update(string Request)
        {
            MultipleContext_PRO_M003 MC = new MultipleContext_PRO_M003();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PRO_M003Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var PhaseData = reader.Read<PRO_M003>().ToList();
                    List<PRO_M003> Masterlist = PhaseData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }                  

                   // MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.PhaseList);
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
    public class MultipleContext_PRO_M003
    {
        public List<PRO_M003> PhaseList { get; set; }
        public List<COM_T003> Attachment { get; set; }
    }
}
