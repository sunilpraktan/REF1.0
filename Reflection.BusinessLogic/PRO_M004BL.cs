using Dapper;
using Reflection.EF.Project_Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    class PRO_M004BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        PRO_M004 MasterEntity = new PRO_M004();
        MultipleContext_PRO_M004 MC = new MultipleContext_PRO_M004();

        public PRO_M004BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public PRO_M004BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_PRO_M004 MC = new MultipleContext_PRO_M004();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PRO_M004LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var ProjectRoleTemp = reader.Read<PRO_M004>().ToList();
                        MC.ProjectRoleList = ProjectRoleTemp.ToList();
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
            MultipleContext_PRO_M004 MC = new MultipleContext_PRO_M004();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PRO_M004Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var ProjectRoleData = reader.Read<PRO_M004>().ToList();
                    MC.ProjectRoleList = ProjectRoleData.ToList();

                    MasterEntity = MC.ProjectRoleList[0];

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.ProjectRoleList);

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
            MultipleContext_PRO_M004 MC = new MultipleContext_PRO_M004();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PRO_M004Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var ProjectRoleData = reader.Read<PRO_M004>().ToList();
                    List<PRO_M004> Masterlist = ProjectRoleData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    // MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.RoleList);
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

    public class MultipleContext_PRO_M004
    {
        public List<PRO_M004> ProjectRoleList { get; set; }
        //public List<COM_T003> Attachment { get; set; }
    }
}
