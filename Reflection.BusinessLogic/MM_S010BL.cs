using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Reflection.EF.CRM;
using System.Data.SqlClient;
using Reflection.EF.SCM;
using System.Data;
using Reflection.EF.Admin;
using Reflection.EF;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic
{
    class MM_S010BL : ReflectionBusinessLogic
    {
       
        private static string connectionString;

        MM_S010 MasterEntity = new MM_S010();
        MultipleContext_MM_S010 MC = new MultipleContext_MM_S010();
        public MM_S010BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MM_S010BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            MultipleContext_MM_S010 MC = new MultipleContext_MM_S010();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    
                    var reader = conn.QueryMultiple("MM_S010Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure, commandTimeout: 0);

                    var backflip = reader.Read<MM_S010_BackFlip>().ToList();
                    MC.BackFlipEntity = backflip.ToList();

                    var MasterData = reader.Read<MM_S010>().ToList();
                    List<MM_S010> Masterlist = MasterData.ToList();
                    MasterEntity = Masterlist[0];

                    var ItemsData = reader.Read<MM_S010_A>().ToList();
                    MC.ItemEntity = ItemsData.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
                    MasterEntity.XmlDataDocument_MM_S010_A = ObjectSerializationService.ObjectToXML(MC.ItemEntity);
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
            MultipleContext_MM_S010 MC = new MultipleContext_MM_S010();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MM_S010Update", new { @Request = Request }, commandType: CommandType.StoredProcedure, commandTimeout: 0);

                    var FlipGridData = reader.Read<MM_S010_BackFlip>().ToList();
                    MC.BackFlipEntity = FlipGridData.ToList();

                    var MasterData = reader.Read<MM_S010>().ToList();
                    List<MM_S010> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    var ItemsData = reader.Read<MM_S010_A>().ToList();
                    MC.ItemEntity = ItemsData.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
                    MasterEntity.XmlDataDocument_MM_S010_A = ObjectSerializationService.ObjectToXML(MC.ItemEntity);
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
       {
            MultipleContext_MM_S010 MC = new MultipleContext_MM_S010();
            string RequestOption = RequestValue.Split('!')[0];

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MM_S010_Essem_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure, commandTimeout: 0);
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var backflipdata = reader.Read<MM_S010_BackFlip>().ToList();
                            MC.BackFlipEntity = backflipdata.ToList();

                            var CategoryList = reader.Read<ADM_M018_P>().ToList();
                            MC.CategoryList = CategoryList.ToList();

                            var SubCategoryList = reader.Read<ADM_M019_P>().ToList();
                            MC.SubCategoryList = SubCategoryList.ToList();

                            var ItemTypeList = reader.Read<ADM_M015_P>().ToList();
                            MC.ItemTypeList = ItemTypeList.ToList();

                            var SubItemTypeList = reader.Read<ADM_M016_P>().ToList();
                            MC.SubItemTypeList = SubItemTypeList.ToList();

                            //var ItemList = reader.Read<ADM_M022_P>().AsList();
                            //MC.itemsList = ItemList.ToList();

                            //var itemsListFG = reader.Read<ADM_M022_P>().AsList();
                            //MC.itemsListFG = itemsListFG.ToList();

                            var UOMList = reader.Read<ADM_M038_B_P>().ToList();
                            MC.UOMList = UOMList.ToList();

                            var ParameterList = reader.Read<ADM_M031_P>().ToList();
                            MC.ParameterList = ParameterList.ToList();

                            var ParamValueList = reader.Read<ADM_M030_P>().ToList();
                            MC.ParamValueList = ParamValueList.ToList();

                            var PostPeriod = reader.Read<ACC_M001A_P>().ToList();
                            MC.PostPeriod = PostPeriod.ToList();

                            var InkData = reader.Read<ZADM_M006_P>().ToList();
                            MC.InkDetails = InkData.ToList();

                            var IldData = reader.Read<ZADM_M007_P>().ToList();
                            MC.IldDetails = IldData.ToList();

                            var GradeData = reader.Read<ADM_M045_P>().ToList();
                            MC.GradeDetails = GradeData.ToList();
                        }
                        if (RequestOption == "LoadItemDetails")
                        {
                            var ItemList = reader.Read<MM_S010_A>().ToList();
                            MC.ItemEntity = ItemList.ToList();
                        }
                        if (RequestOption == "LoadDocumentByDocumentNumber")
                        { 
                            var MasterData = reader.Read<MM_S010>().ToList();
                            MC.MasterEntity = MasterData.ToList();

                            if (MC.MasterEntity.Count >0)
                            {
                                MasterEntity = MC.MasterEntity[0];
                            }
                     
                            var ItemsData = reader.Read<MM_S010_A>().ToList();
                            MC.ItemEntity = ItemsData.ToList();

                            var Attachment = reader.Read<COM_T003>().ToList();
                            MC.AttachmentData = Attachment.ToList();
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

        public string GetData1(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_MM_S010 MC = new MultipleContext_MM_S010();
            string RequestOption = RequestValue.Split('!')[0];

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MM_S010LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure, commandTimeout: 0);
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var backflipdata = reader.Read<MM_S010_BackFlip>().ToList();
                            MC.BackFlipEntity = backflipdata.ToList();

                            var CategoryList = reader.Read<ADM_M018_P>().ToList();
                            MC.CategoryList = CategoryList.ToList();

                            var SubCategoryList = reader.Read<ADM_M019_P>().ToList();
                            MC.SubCategoryList = SubCategoryList.ToList();

                            var ItemTypeList = reader.Read<ADM_M015_P>().ToList();
                            MC.ItemTypeList = ItemTypeList.ToList();

                            var SubItemTypeList = reader.Read<ADM_M016_P>().ToList();
                            MC.SubItemTypeList = SubItemTypeList.ToList();

                            //var ItemList = reader.Read<ADM_M022_P>().AsList();
                            //MC.itemsList = ItemList.ToList();

                            //var itemsListFG = reader.Read<ADM_M022_P>().AsList();
                            //MC.itemsListFG = itemsListFG.ToList();

                            var UOMList = reader.Read<ADM_M038_B_P>().ToList();
                            MC.UOMList = UOMList.ToList();

                            var ParameterList = reader.Read<ADM_M031_P>().ToList();
                            MC.ParameterList = ParameterList.ToList();

                            var ParamValueList = reader.Read<ADM_M030_P>().ToList();
                            MC.ParamValueList = ParamValueList.ToList();

                            var PostPeriod = reader.Read<ACC_M001A_P>().ToList();
                            MC.PostPeriod = PostPeriod.ToList();

                            var InkData = reader.Read<ZADM_M006_P>().ToList();
                            MC.InkDetails = InkData.ToList();

                            var IldData = reader.Read<ZADM_M007_P>().ToList();
                            MC.IldDetails = IldData.ToList();

                            var GradeData = reader.Read<ADM_M045_P>().ToList();
                            MC.GradeDetails = GradeData.ToList();
                        }
                        if (RequestOption == "LoadItemDetails")
                        {
                            var ItemList = reader.Read<MM_S010_A>().ToList();
                            MC.ItemEntity = ItemList.ToList();
                        }
                        if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var MasterData = reader.Read<MM_S010>().ToList();
                            MC.MasterEntity = MasterData.ToList();

                            if (MC.MasterEntity.Count > 0)
                            {
                                MasterEntity = MC.MasterEntity[0];
                            }

                            var ItemsData = reader.Read<MM_S010_A>().ToList();
                            MC.ItemEntity = ItemsData.ToList();

                            var Attachment = reader.Read<COM_T003>().ToList();
                            MC.AttachmentData = Attachment.ToList();
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
    }
    
    public class MultipleContext_MM_S010
    {
        public List<MM_S010_BackFlip> BackFlipEntity { get; set; }
        public List<MM_S010> MasterEntity { get; set; }
        public List<MM_S010_A> ItemEntity { get; set; }
        public List<MM_S010_A> ItemEntityPop { get; set; }
        public List<ADM_M018_P> CategoryList { get; set; }
        public List<ADM_M019_P> SubCategoryList { get; set; }
        public List<ADM_M015_P> ItemTypeList { get; set; }
        public List<ADM_M016_P> SubItemTypeList { get; set; }  
        public List<ADM_M038_B_P> UOMList { get; set; }        
        public List<ADM_M003_P> PlantList { get; set; }        
        public List<MM_M001_P> StorageLocationList { get; set; } //Storage Location Master
        public List<ADM_M002_P> CompanyList {get;set;}
        public List<ADM_M022_P> itemsList { get; set; }  //Item Master
        public List<ADM_M022_P> itemsListFG { get; set; }  //Item Master
        public List<ADM_M030_P> ParamValueList { get; set; }//Parameter Value Master
        public List<ADM_M031_P> ParameterList { get; set; } //Parameter Master
        public List<ACC_M001A_P> FinYear { get; set; }
        public List<ACC_M001A_P> PostPeriod { get; set; }
        public List<ZADM_M006_P> InkDetails { get; set; }
        public List<ZADM_M007_P> IldDetails { get; set; }
        public List<ADM_M045_P> GradeDetails { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
    }
 }
