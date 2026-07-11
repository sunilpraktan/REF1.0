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
    public class ADM_M025BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        ADM_M025 MasterEntity = new ADM_M025();
        MultipleContext_ADM_M025 MC = new MultipleContext_ADM_M025();

        public ADM_M025BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M025BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_ADM_M025 MC = new MultipleContext_ADM_M025();
            string RequestOption = RequestValue.Split('!')[0];

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M025LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var BackFlipList = reader.Read<ADM_M025_Flip>().ToList();
                            MC.BackFlipList = BackFlipList.ToList();

                            var Departmenthead = reader.Read<ADM_M024_P>().ToList();
                            MC.DepartmentHead = Departmenthead.ToList();

                        }
                        else if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var MasterList = reader.Read<ADM_M025>().ToList();
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
            MultipleContext_ADM_M025 MC = new MultipleContext_ADM_M025();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M025Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<ADM_M025>().ToList();
                    List<ADM_M025> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var BackFlipList = reader.Read<ADM_M025_Flip>().ToList();
                    MC.BackFlipList = BackFlipList.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.BackFlipList);

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
            MultipleContext_ADM_M025 MC = new MultipleContext_ADM_M025();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M025Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<ADM_M025>().ToList();
                    List<ADM_M025> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var BackFlipList = reader.Read<ADM_M025_Flip>().ToList();
                    MC.BackFlipList = BackFlipList.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.BackFlipList);
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
    public class MultipleContext_ADM_M025
    {
        public List<ADM_M025> MasterEntity { get; set; }
        public List<ADM_M025_Flip> BackFlipList { get; set; }
        public List<ADM_M024_P> DepartmentHead { get; set; }
    }
}
