using System;
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
  public class PRO_M001BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        PRO_M001 MasterEntity = new PRO_M001();
        MultipleContext_PRO_M001 MC = new MultipleContext_PRO_M001();

        public PRO_M001BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public PRO_M001BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_PRO_M001 MC = new MultipleContext_PRO_M001();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PRO_M001LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var ProjectCategoryTemp = reader.Read<PRO_M001>().ToList();
                        MC.ProjectCategoryList = ProjectCategoryTemp.ToList();

                      
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
            MultipleContext_PRO_M001 MC = new MultipleContext_PRO_M001();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PRO_M001Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var ProjectCategoryData = reader.Read<PRO_M001>().ToList();
                    MC.ProjectCategoryList = ProjectCategoryData.ToList();

                    MasterEntity = MC.ProjectCategoryList[0];

                   

                    MasterEntity.XmlDataDocument_DataGridView = ObjectSerializationService.ObjectToXML(MC.ProjectCategoryList);
                    

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
            MultipleContext_PRO_M001 MC = new MultipleContext_PRO_M001();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PRO_M001Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var ProjectCategoryData = reader.Read<PRO_M001>().ToList();
                    List<PRO_M001> Masterlist = ProjectCategoryData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                   
                    //  MasterEntity.XmlDataDocument_DataGridView = ObjectSerializationService.ObjectToXML(MC.PhaseList);
                    
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
    public class MultipleContext_PRO_M001
    {
        public List<PRO_M001> ProjectCategoryList { get; set; }
        
        //public List<COM_T003> Attachment { get; set; }
    }
}
