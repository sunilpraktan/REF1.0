using Reflection.EF;
using Dapper;
using Reflection.EF.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace Reflection.BusinessLogic
{
    public class ADM_M041BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        ADM_M041 MasterEntity = new ADM_M041();
        MultipleContext_ADM_M041 MC = new MultipleContext_ADM_M041();
        public ADM_M041BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M041BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {

            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M041_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var flipGridData = reader.Read<ADM_M041Flip>().ToList();
                        MC.FlipGridData = flipGridData.ToList();

                        var licenseType = reader.Read<ADM_M041_A>().ToList();
                        MC.LicenseType = licenseType.ToList();

                        var sionNo = reader.Read<ADM_M041_B_P>().ToList();
                        MC.SionNo = sionNo.ToList();

                        var LicCat = reader.Read<ADM_M041_D_P>().ToList();
                        MC.LicenseCatMaster = LicCat.ToList();

                        var ItemGroupData = reader.Read<ADM_M022_B_P>().ToList();
                        MC.ItemGroupMaster = ItemGroupData.ToList();

                        var IncotermsData = reader.Read<ADM_M044_P>().ToList();
                        MC.Incoterms = IncotermsData.ToList();

                        var CurrencyData = reader.Read<ADM_M037_P>().ToList();
                        MC.Currency = CurrencyData.ToList();

                        var UnitData = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UnitMaster = UnitData.ToList();

                    }
                    if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var masterData = reader.Read<ADM_M041>().ToList();
                        MC.MasterEntity = masterData.ToList();

                        var ItemsData = reader.Read<ADM_M041_C>().ToList();
                        MC.ItemsEntity = ItemsData.ToList();
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

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M041_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlipList = reader.Read<ADM_M041Flip>().ToList();
                    MC.FlipGridData = BackFlipList.ToList();

                    var MasterData = reader.Read<ADM_M041>().ToList();
                    MC.MasterEntity = MasterData.ToList();

                    MasterEntity = MC.MasterEntity[0];

                    var ItemData = reader.Read<ADM_M041_C>().ToList();
                    MC.ItemsEntity = ItemData.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
                    MasterEntity.XmlDataDocument_ADM_M041_C = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
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

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M041_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlipList = reader.Read<ADM_M041Flip>().ToList();
                    MC.FlipGridData = BackFlipList.ToList();

                    var MasterData = reader.Read<ADM_M041>().ToList();
                    List<ADM_M041> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var ItemData = reader.Read<ADM_M041_C>().ToList();
                    MC.ItemsEntity = ItemData.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
                    MasterEntity.XmlDataDocument_ADM_M041_C = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
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
    public class MultipleContext_ADM_M041
    {
        public List<ADM_M041Flip> FlipGridData { get; set; }
        public List<ADM_M041> MasterEntity { get; set; }
        public List<ADM_M041_A> LicenseType { get; set; }
        public List<ADM_M041_B_P> SionNo { get; set; }
        public List<ADM_M041_D_P> LicenseCatMaster { get; set; }
        public List<ADM_M022_B_P> ItemGroupMaster { get; set; }
        public List<ADM_M041_C> ItemsEntity { get; set; }
        public List<ADM_M044_P> Incoterms { get; set; }
        public List<ADM_M037_P> Currency { get; set; }
        public List<ADM_M038_B_P> UnitMaster { get; set; }
        //public List<ADM_M002> Company { get; set; }
    }

}
