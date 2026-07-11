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
    public class PRO_M001_ABL : ReflectionBusinessLogic
    {
        private static string connectionString;

        PRO_M001_A MasterEntity = new PRO_M001_A();
        MultipleContext_PRO_M001_A MC = new MultipleContext_PRO_M001_A();

        public PRO_M001_ABL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public PRO_M001_ABL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_PRO_M001_A MC = new MultipleContext_PRO_M001_A();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PRO_M001_ALoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var ProjectSubCategoryTemp = reader.Read<PRO_M001_A>().ToList();
                        MC.ProjectSubCategoryList = ProjectSubCategoryTemp.ToList();

                        var ProCatTemp = reader.Read<PRO_M001_P>().ToList();
                        MC.ProjectCategoryList = ProCatTemp.ToList();
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
            MultipleContext_PRO_M001_A MC = new MultipleContext_PRO_M001_A();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PRO_M001_AInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var ProjectSubCategoryData = reader.Read<PRO_M001_A>().ToList();
                    MC.ProjectSubCategoryList = ProjectSubCategoryData.ToList();

                    MasterEntity = MC.ProjectSubCategoryList[0];

                    MasterEntity.XmlDataDocument_DataGridView = ObjectSerializationService.ObjectToXML(MC.ProjectSubCategoryList);


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
                    var reader = conn.QueryMultiple("PRO_M001_AUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var ProjectSubCategoryData = reader.Read<PRO_M001_A>().ToList();
                    List<PRO_M001_A> Masterlist = ProjectSubCategoryData.ToList();
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
    public class MultipleContext_PRO_M001_A
    {
        public List<PRO_M001_A> ProjectSubCategoryList { get; set; }
        public List<PRO_M001_P> ProjectCategoryList { get; set; }
        //public List<COM_T003> Attachment { get; set; }
    }
}
