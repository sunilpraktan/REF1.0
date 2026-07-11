using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.SCM;
using Dapper;
using Reflection.EF.Production;
using Reflection.EF.ADM;
using Reflection.EF.MM;

namespace Reflection.BusinessLogic
{
    public class MM_T003BL : ReflectionBusinessLogic
    {

        private static string connectionString;
        //MultipleContext_MM_T003 MC = new MultipleContext_MM_T003();
        MM_T003 mM_T003 = new MM_T003();
        public MM_T003BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MM_T003BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                string strReturnData = "";
                //IDbConnection conn = new SqlConnection(connectionString);
                //var reader = conn.QueryMultiple("MM_T003_AInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure,commandTimeout:0);

                //var FlipGridData = reader.Read<MM_T003Flip>().ToList();
                //MC.DocumentDataFlipGrid = FlipGridData.ToList();

                //var MasterData = reader.Read<MM_T003>().ToList();
                //MC.MasterEntity = MasterData.ToList();

                //if (MC.MasterEntity.Count > 0)
                //{
                //    mM_T003 = MC.MasterEntity[0];
                //}

                //var ItemData = reader.Read<MM_T003_A>().ToList();
                //MC.ItemsEntity = ItemData.ToList();

                //mM_T003 = MC.MasterEntity[0];
                //mM_T003.XmlDataDocument_MM_T003_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                //mM_T003.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
               
                //strReturnData = ObjectSerializationService.ObjectToXML(mM_T003);
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
                string strReturnData = "";
                //using (IDbConnection conn = new SqlConnection(connectionString))
                //{
                //    var reader = conn.QueryMultiple("MM_T003_AUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                //    var FlipGridData = reader.Read<MM_T003Flip>().ToList();
                //    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                //    var MasterData = reader.Read<MM_T003>().ToList();
                //    MC.MasterEntity = MasterData.ToList();

                //    if (MC.MasterEntity.Count > 0)
                //    {
                //        mM_T003 = MC.MasterEntity[0];
                //    }
                //    var ItemData = reader.Read<MM_T003_A>().ToList();
                //    MC.ItemsEntity = ItemData.ToList();

                //    mM_T003.XmlDataDocument_MM_T003_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                //    mM_T003.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                //}
                //strReturnData = ObjectSerializationService.ObjectToXML(mM_T003);
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
        public string UpdateStatus(string Request)
        {
            try
            {
                //mM_T003 = new MM_T003();
                //Request = (string)ObjectSerializationService.XMLToObject(Request, Request);
                //int reader;
                //using (IDbConnection conn = new SqlConnection(connectionString))
                //{
                //    reader = conn.Execute("MM_T003_AUpdateStatus", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                //}
                //string strReturnData = reader.ToString();
                string strReturnData = "";
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
                //using (IDbConnection conn = new SqlConnection(connectionString))
                //{
                //    int intOut = conn.Execute("MM_T003_ADelete", new { @req_no = Request }, commandType: CommandType.StoredProcedure);
                //    return intOut.ToString();
                //}
                int intOut=0;
                return intOut.ToString();
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            //MultipleContext_MM_T003 MC = new MultipleContext_MM_T003();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                //using (IDbConnection conn = new SqlConnection(connectionString))
                //{
                //    var reader = conn.QueryMultiple("MM_T003_ALoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                //    if (RequestOption == "LoadInitialData")
                //    {
                //        //var documentDataFlipGrid = reader.Read<MM_T003Flip>().ToList();
                //        //MC.DocumentDataFlipGrid = documentDataFlipGrid.ToList();

                //        var BOM = reader.Read<ENG_T001_P>().ToList();
                //        MC.BOMData = BOM.ToList();

                //        var prioritiesList = reader.Read<ADM_M040_P>().ToList();
                //        MC.PrioritiesList = prioritiesList.ToList();

                //        var requsterList = reader.Read<ADM_M024_P>().ToList();
                //        MC.RequsterList = requsterList.ToList();

                //        var deptList = reader.Read<ADM_M025_P>().ToList();
                //        MC.DeptList = deptList.ToList();

                //        var itemList = reader.Read<ADM_M022_P>().ToList();
                //        MC.ItemList = itemList.ToList();

                //        var parameterList = reader.Read<ADM_M031_P>().ToList();
                //        MC.ParameterList = parameterList.ToList();

                //        var paramValueList = reader.Read<ADM_M030_P>().ToList();
                //        MC.ParamValueList = paramValueList.ToList();

                //        var itemCategoryList = reader.Read<SYS_M008_P>().ToList();
                //        MC.ItemCategoryList = itemCategoryList.ToList();

                //        var unitList = reader.Read<ADM_M038_B_P>().ToList();
                //        MC.UnitList = unitList.ToList();

                //        var Machinelist = reader.Read<ZADM_M013_P>().ToList();
                //        MC.MachineList = Machinelist.ToList();

                //        var DocTypeList = reader.Read<SYS_M011_P>().ToList();
                //        MC.DocType = DocTypeList.ToList();

                //        MC.ProductionOrderList = reader.Read<EPR_T001>().ToList();
                //        //MC.OrderList = OrderData.ToList();

                //        var t_statusData = reader.Read<ADM_M0013>().ToList();
                //        MC.t_statusList = t_statusData.ToList();

                //        //var storeList = reader.Read<MM_M001>().ToList();
                //        //MC.StoreCodeList = storeList.ToList();

                //        var BatchList = reader.Read<MM_S003_P>().ToList();
                //        MC.batchList = BatchList.ToList();

                //        MC.MM_T003_SETTING = reader.Read<MM_T003_S>().ToList();
                //        //MC.EQUIPMENT_LIST = reader.Read<STD_LIST_BE>().ToList();

                //    }
                //    if (RequestOption == "LoadDocumentWithDocumentNumber")
                //    {

                //        var MasterData = reader.Read<MM_T003>().ToList();
                //        MC.MasterEntity = MasterData.ToList();

                //        var ItemData = reader.Read<MM_T003_A>().ToList();
                //        MC.ItemsEntity = ItemData.ToList();
                //    }

                //    if (RequestOption == "ExecuteReference")
                //    {
                //        var BomItem = reader.Read<MM_T003_A>().ToList();
                //        MC.ItemsEntity = BomItem.ToList();
                //    }
                //    if (RequestOption == "LoadBackFlipData")
                //    {
                //        var documentDataFlipGrid = reader.Read<MM_T003Flip>().ToList();
                //        MC.DocumentDataFlipGrid = documentDataFlipGrid.ToList();
                //    }

                //}
                //strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
    }
    //public class MultipleContext_MM_T003
    //{
    //    public List<STD_LIST_BE> BACK_FLIP_LIST { get; set; }
    //    public List<MM_T003Flip> DocumentDataFlipGrid { get; set; }
    //    public List<ADM_M040_P> PrioritiesList { get; set; }//Priority Master    
    //    public List<ADM_M024_P> RequsterList { get; set; }
    //    public List<ADM_M025_P> DeptList { get; set; }
    //    public List<ADM_M022_P> ItemList { get; set; }  //Item Master
    //    public List<ADM_M031_P> ParameterList { get; set; } //Parameter Master
    //    public List<ADM_M030_P> ParamValueList { get; set; }//Flute Master
    //    public List<SYS_M008_P> ItemCategoryList { get; set; }
    //    public List<ADM_M038_B_P> UnitList { get; set; }  //Unit Master
    //    public List<MM_M001_P> StoreList { get; set; }
    //    public List<MM_S003_P> batchList { get; set; }
    //    public List<MM_T003> MasterEntity { get; set; }
    //    public List<MM_T003_A> ItemsEntity { get; set; }
    //    public List<ZADM_M013_P> MachineList { get; set; }
    //    public List<SYS_M011_P> DocType { get; set; }
    //    public List<ENG_T001_P> BOMData { get; set; }
    //    public List<ENG_T001_A_P> BOMItems { get; set; }
    //    public List<EPR_T001_P> OrderList { get; set; }
    //    public List<ADM_M0013> t_statusList { get; set; }
    //    public List<MM_M001> StoreCodeList { get; set; }
    //    public List<MM_T003_S> MM_T003_SETTING { get; set; }
    //    public List<EPR_T001> ProductionOrderList { get; set; }
    //    public List<STD_LIST_BE> EQUIPMENT_LIST { get; set; }
    //    public List<ADM_M0002> COMPANY_LIST { get; set; }
    //    public List<ADM_M0003> LOCATION_LIST { get; set; }
    //    public List<MM_M0001> STORE_LIST { get; set; }
    //}
}
