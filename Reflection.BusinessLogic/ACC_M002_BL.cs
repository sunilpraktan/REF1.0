using Reflection.EF;
using Reflection.EF.Asset_Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic
{
   public class ACC_M002_BL : ReflectionBusinessLogic
    {

        static int obj = 0;
        private static string ConnectionString;
        public ACC_M002_BL(string BusinessEntity)
        {
            ConnectionString = base.ReflectionConnectionString;
        }
        public ACC_M002_BL()
        {
            ConnectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            MultipleContext_ACC_M002 MC = new MultipleContext_ACC_M002();
            ACC_M002 MasterEntity = new ACC_M002();
            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M002_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<ACC_M002>().ToList();
                    List<ACC_M002> Masterlist = MasterData.ToList();
                    MasterEntity = Masterlist[0];

                    var InsuranceTemp = reader.Read<ACC_M002_I1>().ToList();
                    MC.InsuranceDataList = InsuranceTemp.ToList();

                    var AllocationTemp = reader.Read<ACC_M002_H>().ToList();
                    MC.AssetAllocationList = AllocationTemp.ToList();

                    var _AssetMaster_DepAreaList = reader.Read<ACC_M002_B>().ToList();
                    MC.AssetMaster_DepAreaList = _AssetMaster_DepAreaList.ToList();

                    var FlipData = reader.Read<ACC_M002_Flip>().ToList();
                    MC.FlipGridData = FlipData.ToList();

                    MasterEntity.XmlDataDocument_ACC_M002_I1 = ObjectSerializationService.ObjectToXML(MC.InsuranceDataList);
                    MasterEntity.XmlDataDocument_ACC_M002_H = ObjectSerializationService.ObjectToXML(MC.AssetAllocationList);
                    MasterEntity.XmlDataDocument_ACC_M002_FLIP = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
                    MasterEntity.XmlDataDocument_ACC_M002_B = ObjectSerializationService.ObjectToXML(MC.AssetMaster_DepAreaList);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
            MultipleContext_ACC_M002 MC = new MultipleContext_ACC_M002();
            ACC_M002 MasterEntity = new ACC_M002();

            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {

                    var reader = conn.QueryMultiple("ACC_M002_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<ACC_M002>().ToList();
                    List<ACC_M002> Masterlist = MasterData.ToList();

                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var InsuranceTemp = reader.Read<ACC_M002_I1>().ToList();
                    MC.InsuranceDataList = InsuranceTemp.ToList();

                    var AllocationTemp = reader.Read<ACC_M002_H>().ToList();
                    MC.AssetAllocationList = AllocationTemp.ToList();

                    var FlipData = reader.Read<ACC_M002_Flip>().ToList();
                    MC.FlipGridData = FlipData.ToList();

                    var _AssetMaster_DepAreaList = reader.Read<ACC_M002_B>().ToList();
                    MC.AssetMaster_DepAreaList = _AssetMaster_DepAreaList.ToList();

                    MasterEntity.XmlDataDocument_ACC_M002_I1 = ObjectSerializationService.ObjectToXML(MC.InsuranceDataList);
                    MasterEntity.XmlDataDocument_ACC_M002_H = ObjectSerializationService.ObjectToXML(MC.AssetAllocationList);
                    MasterEntity.XmlDataDocument_ACC_M002_FLIP = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
                    MasterEntity.XmlDataDocument_ACC_M002_B = ObjectSerializationService.ObjectToXML(MC.AssetMaster_DepAreaList);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            MultipleContext_ACC_M002 MC = new MultipleContext_ACC_M002();

            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M002_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var FlipGrid = reader.Read<ACC_M002_Flip>().ToList();
                        MC.FlipGridData = FlipGrid.ToList();

                        var _AccDtrList = reader.Read<ACC_M002_L_P>().ToList();
                        MC.AccDtrList = _AccDtrList.ToList();

                        var _AssetClassList = reader.Read<ACC_M002_C_P>().ToList();
                        MC.AssetClassList = _AssetClassList.ToList();

                        var _InvetoryNoList = reader.Read<ADM_M022_P>().ToList();
                        MC.InvetoryNoList = _InvetoryNoList.ToList();

                        var _FinYearList = reader.Read<ACC_M001A_P>().ToList();
                        MC.FinYearList = _FinYearList.ToList();

                        var _BussAreaList = reader.Read<ADM_M003_C_P>().ToList();
                        MC.BussAreaList = _BussAreaList.ToList();

                        var _CostCenterList = reader.Read<ACC_M019_P>().ToList();
                        MC.CostCenterList = _CostCenterList.ToList();

                        var _PartyList = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyList = _PartyList.ToList();

                        var _CountryList = reader.Read<ADM_M012_P>().ToList();
                        MC.CountryList = _CountryList.ToList();

                        var _DepAreaAssiList = reader.Read<ACC_M002_D>().ToList();
                        MC.DepAreaAssiList = _DepAreaAssiList.ToList();

                        var _DepKeyList = reader.Read<ACC_M002_K_P>().ToList();
                        MC.DepKeyList = _DepKeyList.ToList();

                        var _DepAreaList = reader.Read<ACC_M002_R_P>().ToList();
                        MC.DepAreaList = _DepAreaList.ToList();
                    }

                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var MasterData = reader.Read<ACC_M002>().ToList();
                        MC.MasterList = MasterData.ToList();

                        var InsuranceTemp = reader.Read<ACC_M002_I1>().ToList();
                        MC.InsuranceDataList = InsuranceTemp.ToList();

                        var AllocationTemp = reader.Read<ACC_M002_H>().ToList();
                        MC.AssetAllocationList = AllocationTemp.ToList();

                        var _AssetMaster_DepAreaList = reader.Read<ACC_M002_B>().ToList();
                        MC.AssetMaster_DepAreaList = _AssetMaster_DepAreaList.ToList();
                    }
                    else if (RequestOption == "LoadHistory")
                    {
                        var BackFlip = reader.Read<ACC_M002_Flip>().ToList();
                        MC.FlipGridData = BackFlip.ToList();
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
        public class MultipleContext_ACC_M002
        {
            public List<ACC_M002> MasterList { get; set; }
            public List<ACC_M002_I1> InsuranceDataList { get; set; }
            public List<ACC_M002_H> AssetAllocationList { get; set; }
            public List<ACC_M002_B> AssetMaster_DepAreaList { get; set; }
            public List<ACC_M002_D> DepAreaAssiList { get; set; }
            public List<ACC_M002_L_P> AccDtrList { get; set; }
            public List<ACC_M002_C_P> AssetClassList { get; set; }
            public List<ADM_M022_P> InvetoryNoList { get; set; }
            public List<ACC_M002_Flip> FlipGridData { get; set; }
            public List<ACC_M001A_P> FinYearList { get; set; }
            public List<ADM_M003_C_P> BussAreaList { get; set; }
            public List<ACC_M019_P> CostCenterList { get; set; }
            public List<ADM_M028_P> PartyList { get; set; }
            public List<ADM_M012_P> CountryList { get; set; }
            public List<ACC_M002_K_P> DepKeyList { get; set; }
            public List<ACC_M002_R_P> DepAreaList { get; set; }
            // public List<ACC_M002_H> AnalysisGrpList { get; set; }
            // public List<ACC_M002_H> InternalOrderList { get; set; }
        }
    }
}
