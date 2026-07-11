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
    public class ADM_M028_I_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ADM_M028_I MC = new MultipleContext_ADM_M028_I();
        ADM_M028_I masterEntity = new ADM_M028_I();

        public ADM_M028_I_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M028_I_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_ADM_M028_I MC = new MultipleContext_ADM_M028_I();
            MultipleContext_ADM_M028_I MCTemp = new MultipleContext_ADM_M028_I();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M028_I_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var flipGridData = reader.Read<ADM_M028_I_Flip>().ToList();
                        MC.DocumentDataFlipGrid = flipGridData.ToList();

                        var partyList = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyList = partyList.ToList();

                        var taxTypeCodeList = reader.Read<ACC_M025_P>().ToList();
                        MC.TaxTypeCodeList = taxTypeCodeList.ToList();

                        var taxTypeList = reader.Read<ACC_M025_A_P>().ToList();
                        MC.TaxTypeList = taxTypeList.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

                    }
                    if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var masterData = reader.Read<ADM_M028_I>().ToList();
                        MC.MasterEntity = masterData.ToList();
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
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M028_I_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //BackFlip Data
                    var _documentDataFlipGrid = reader.Read<ADM_M028_I_Flip>().ToList();
                    MC.DocumentDataFlipGrid = _documentDataFlipGrid.ToList();

                    //Master Data
                    var _MasterData = reader.Read<ADM_M028_I>().ToList();
                    MC.MasterEntity = _MasterData.ToList();
                   
                    //if (MC.MasterEntity.Count > 0)
                    //{
                    //    masterEntity = MC.MasterEntity[0];
                    //}

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_ADM_M028_I = ObjectSerializationService.ObjectToXML(MC.MasterEntity);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
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


        //public string Update(string Request)
        //{
        //    try
        //    {
        //        string strReturnData = "";
        //        using (IDbConnection conn = new SqlConnection(connectionString))
        //        {
        //            var reader = conn.QueryMultiple("ADM_M028_I_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

        //            var flipGridData = reader.Read<ADM_M028_I_Flip>().ToList();
        //            MC.DocumentDataFlipGrid = flipGridData.ToList();

        //            var masterData = reader.Read<ADM_M028_I>().ToList();
        //            MC.MasterEntity = masterData.ToList();

        //            masterEntity = MC.MasterEntity[0];
        //            masterEntity.XmlDataDocument_ADM_M028_I = ObjectSerializationService.ObjectToXML(MC.MasterEntity);
        //        }
        //        strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
        //        return strReturnData;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new CreateException(ex.ErrorCode, ex.Message, ex);
        //    }
        //    catch (CreateException ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //}
    }
    public class MultipleContext_ADM_M028_I
    {
        public List<ADM_M028_I_Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_I> MasterEntity { get; set; }
        public List<ADM_M028_P> PartyList { get; set; }
        public List<ACC_M025_P> TaxTypeCodeList { get; set; }
        public List<ACC_M025_A_P> TaxTypeList { get; set; }
    }
}
