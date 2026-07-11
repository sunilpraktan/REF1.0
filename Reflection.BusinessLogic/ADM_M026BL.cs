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
    public class ADM_M026BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        ADM_M026 MasterEntity = new ADM_M026();
        MultipleContext_ADM_M026 MC = new MultipleContext_ADM_M026();

        public ADM_M026BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M026BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_ADM_M026 MC = new MultipleContext_ADM_M026();
            string RequestOption = RequestValue.Split('!')[0];

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M026LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var BackFlipList = reader.Read<ADM_M026_Flip>().ToList();
                            MC.BackFlipList = BackFlipList.ToList();

                        }
                        else if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var MasterList = reader.Read<ADM_M026>().ToList();
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
            MultipleContext_ADM_M026 MC = new MultipleContext_ADM_M026();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M026Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<ADM_M026>().ToList();
                    List<ADM_M026> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var BackFlipList = reader.Read<ADM_M026_Flip>().ToList();
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
            MultipleContext_ADM_M026 MC = new MultipleContext_ADM_M026();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M026Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<ADM_M026>().ToList();
                    List<ADM_M026> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var BackFlipList = reader.Read<ADM_M026_Flip>().ToList();
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
    public class MultipleContext_ADM_M026
    {
        public List<ADM_M026> MasterEntity { get; set; }
        public List<ADM_M026_Flip> BackFlipList { get; set; }
    }
    //public class ADM_M026BL
    //{
    //    private static string connectionString;
    //    static int obj = 0;

    //    ADM_M026 aDM_M026 = new ADM_M026();
    //    public ADM_M026BL(string BusinessEntity)
    //    {
    //        connectionString = System.Configuration.ConfigurationManager.AppSettings["strConnectionString"];
    //    }
    //    public ADM_M026BL()
    //    {
    //        connectionString = System.Configuration.ConfigurationManager.AppSettings["strConnectionString"];
    //    }
    //    #region Insert
    //    public string Insert(string Request)
    //    {
    //        try
    //        {
    //            aDM_M026 = (ADM_M026)ObjectSerializationService.XMLToObject(Request, aDM_M026);
    //            using (IDbConnection conn = new SqlConnection(connectionString))
    //            {
    //                var reader = conn.QueryMultiple("ADM_M026Insert", new
    //                {
    //                    @desig_code = aDM_M026.desig_code,
    //                    @DesigName = aDM_M026.DesigName,
    //                    @add_by = aDM_M026.add_by
    //                }, commandType: CommandType.StoredProcedure);

    //                var desig = reader.Read<ADM_M026>().ToList();
    //                List<ADM_M026> desigList = desig.ToList();
    //                if (desigList.Count > 0)
    //                {
    //                    aDM_M026 = desigList[0];
    //                }                 
    //            }
    //            string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M026);
    //            return strReturnData;
    //        }
    //        catch (SqlException ex)
    //        {
    //            throw new CreateException(ex.ErrorCode, ex.Message, ex);
    //        }
    //        catch (CreateException ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //    }

    //    #endregion
    //    #region Getdata
    //    public string GetData()
    //    {
    //        string strValue = "";
    //        try
    //        {
    //            List<ADM_M026> dept = new List<ADM_M026>();

    //            using (IDbConnection conn = new SqlConnection(connectionString))
    //            {
    //                var reader = conn.QueryMultiple("ADM_M026LoadAll", commandType: CommandType.StoredProcedure);

    //                dept = reader.Read<ADM_M026>().ToList();
    //            }
    //            strValue = ObjectSerializationService.ObjectToXML(dept);
    //        }
    //        catch (SqlException ex)
    //        {
    //            throw new CreateException(ex.ErrorCode, ex.Message, ex);
    //        }
    //        catch (DivideByZeroException ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }

    //        return strValue;
    //    }
    //    #endregion
    //    #region Update
    //    public string Update(string Request)
    //    {
    //        try
    //        {
    //            aDM_M026 = (ADM_M026)ObjectSerializationService.XMLToObject(Request, aDM_M026);
    //            using (IDbConnection conn = new SqlConnection(connectionString))
    //            {
    //                int intOut = conn.Execute("ADM_M026Update", new
    //                {
    //                    aDM_M026.desig_code,
    //                    aDM_M026.DesigName,
    //                    aDM_M026.add_by
    //                }, commandType: CommandType.StoredProcedure);
    //                return intOut.ToString();
    //            }
    //        }
    //        catch (SqlException ex)
    //        {
    //            throw new CreateException(ex.ErrorCode, ex.Message, ex);
    //        }
    //        catch (CreateException ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }

    //    }
    //    #endregion
    //    #region Delete
    //    public string Delete(string Request)
    //    {
    //        try
    //        {
    //            using (IDbConnection conn = new SqlConnection(connectionString))
    //            {
    //                int intOut = conn.Execute("ADM_M026Delete", new { @desig_code = Request }, commandType: CommandType.StoredProcedure);

    //                return intOut.ToString();
    //            }                       
    //        }
    //        catch (SqlException ex)
    //        {
    //            throw new CreateException(ex.ErrorCode, ex.Message, ex);
    //        }
    //        catch (CreateException ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //    }
    //    #endregion
    //}
}
