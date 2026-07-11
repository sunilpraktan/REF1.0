using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using Reflection.EF.Admin;
using Dapper;
using System.IO;
using Reflection.EF.Communication;
using Reflection.EF.Finance;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    public class ADM_M022BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        ADM_M022 MasterEntity = new ADM_M022();
        MultipleContext_ADM_M022 MC = new MultipleContext_ADM_M022();

        public ADM_M022BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M022BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_ADM_M022 MC = new MultipleContext_ADM_M022();
            string RequestOption = RequestValue.Split('!')[0];

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MM_M0022_GET", new { @Request = RequestValue }, commandTimeout:0, commandType: CommandType.StoredProcedure);
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                            MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();

                            var CategoryList = reader.Read<ADM_M018_P>().ToList();
                            MC.CategoryList = CategoryList.ToList();

                            var SubCategoryList = reader.Read<ADM_M019_P>().ToList();
                            MC.SubCategoryList = SubCategoryList.ToList();

                            var ItemTypeList = reader.Read<ADM_M015_P>().ToList();
                            MC.ItemTypeList = ItemTypeList.ToList();

                            var SubItemTypeList = reader.Read<ADM_M016_P>().ToList();
                            MC.SubItemTypeList = SubItemTypeList.ToList();

                            var PartyList = reader.Read<ADM_M028_P>().ToList();
                            MC.PartyList = PartyList.ToList();

                            var UnitList = reader.Read<ADM_M038_B_P>().ToList();
                            MC.UnitList = UnitList.ToList();

                            var ProductList = reader.Read<ADM_M020_P>().ToList();
                            MC.ProductList = ProductList.ToList();

                            var MaterialList = reader.Read<ADM_M021_P>().ToList();
                            MC.MaterialList = MaterialList.ToList();

                            var _ValuationClassList = reader.Read<ACC_M003_V>().ToList();
                            MC.ValuationClassList = _ValuationClassList.ToList();

                            var _AccountingGroupList = reader.Read<ACC_M003_H>().ToList();
                            MC.AccountingGroupList = _AccountingGroupList.ToList();

                            var _ReconAccountList = reader.Read<ACC_M003_P>().ToList();
                            MC.ReconAccountList = _ReconAccountList.ToList();

                            var _materialGroup = reader.Read<ADM_M052_P>().ToList();
                            MC.MaterialGroup = _materialGroup.ToList();

                            var _taxCategory = reader.Read<ACC_M013_A_P>().ToList();
                            MC.TaxCategory = _taxCategory.ToList();

                            var ControlKey = reader.Read<SYS_M051>().ToList();
                            MC.ControlKeyMaster = ControlKey.ToList();

                            var QmSystem = reader.Read<QMS_M041_P>().ToList();
                            MC.QMSystemMaster = QmSystem.ToList();

                            var CertiType = reader.Read<QMS_M042_P>().ToList();
                            MC.CertificateType = CertiType.ToList();

                            MC.ItemGroupExport = reader.Read<ADM_M022_B>().ToList();
                        }
                        else if(RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            MC.MasterEntity = reader.Read<ADM_M022>().ToList();
                            MC.AttachmentList = reader.Read<COM_T003>().ToList();
                        }
                        else if(RequestOption == "Items_Report")
                        {
                            MC.MasterEntity = reader.Read<ADM_M022>().ToList();
                        }
                        else if (RequestOption == "LOAD_BACKFLIP")
                        {
                            MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
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
            MultipleContext_ADM_M022 MC = new MultipleContext_ADM_M022();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MM_M0022_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    List<ADM_M022> Masterlist = reader.Read<ADM_M022>().ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
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
            MultipleContext_ADM_M022 MC = new MultipleContext_ADM_M022();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MM_M0022_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    List<ADM_M022> Masterlist = reader.Read<ADM_M022>().ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
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

        //private static string connectionString;

        //static int obj = 0;

        //ADM_M022 aDM_M022 = new ADM_M022();

        //public ADM_M022BL(string BusinessEntity)
        //{
        //    connectionString = System.Configuration.ConfigurationManager.AppSettings["strConnectionString"];
        //}
        //public ADM_M022BL()
        //{
        //    connectionString = System.Configuration.ConfigurationManager.AppSettings["strConnectionString"];
        //}
        //public string Insert(string Request)
        //{
        //    try
        //    {
        //        using (IDbConnection conn = new SqlConnection(connectionString))
        //        {
        //            var reader = conn.QueryMultiple("ADM_M022Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

        //            var Item1 = reader.Read<ADM_M022>().ToList();
        //            List<ADM_M022> ItemList = Item1.ToList();
        //            if (ItemList.Count > 0)
        //            {
        //                aDM_M022 = ItemList[0];
        //            }
        //        }
        //        string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M022);
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
        //public string Update(string Request)
        //{
        //    try
        //    {
        //        using (IDbConnection conn = new SqlConnection(connectionString))
        //        {
        //            var reader = conn.QueryMultiple("ADM_M022Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

        //            var Item1 = reader.Read<ADM_M022>().ToList();
        //            List<ADM_M022> ItemList = Item1.ToList();
        //            if (ItemList.Count > 0)
        //            {
        //                aDM_M022 = ItemList[0];
        //            }
        //        }
        //        string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M022);
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
        //public string Delete(string Request)
        //{
        //    try
        //    {
        //        using (IDbConnection conn = new SqlConnection(connectionString))
        //        {
        //            int intOut = conn.Execute("ADM_M022Delete", new { @ItemCode = Request }, commandType: CommandType.StoredProcedure);
        //            return intOut.ToString();
        //        }

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
        //public string GetData(string strType, int intValue, string strValue)
        //{
        //    MultipleContext_ADM_M022 MC = new MultipleContext_ADM_M022();
        //    try
        //    {
        //        using (IDbConnection conn = new SqlConnection(connectionString))
        //        {
        //            var reader = conn.QueryMultiple("ADM_M022LoadAll", new { @comp_code = strValue, @strType = strType }, commandType: CommandType.StoredProcedure);
        //            if (strType == "LoadInitialData")
        //            {
        //                var Category = reader.Read<ADM_M018_P>().ToList();
        //                MC.Category = Category.ToList();
        //                var SubCategory = reader.Read<ADM_M019_P>().ToList();
        //                MC.SubCategory = SubCategory.ToList();
        //                var ItmTyp = reader.Read<ADM_M015_P>().ToList();
        //                MC.ItmTyp = ItmTyp.ToList();
        //                var SubItmTyp = reader.Read<ADM_M016_P>().ToList();
        //                MC.SubItmTyp = SubItmTyp.ToList();
        //                var ProdNm = reader.Read<ADM_M020_P>().ToList();
        //                MC.ProdNm = ProdNm.ToList();
        //                var Commdty = reader.Read<ADM_M014_P>().ToList();
        //                MC.Commdty = Commdty.ToList();
        //                var Matrl = reader.Read<ADM_M021_P>().ToList();
        //                MC.Matrl = Matrl.ToList();
        //                var Asset = reader.Read<ADM_M017_P>().ToList();
        //                MC.Asset = Asset.ToList();
        //                var UOM = reader.Read<ADM_M038_B_P>().ToList();
        //                MC.UOM = UOM.ToList();
        //                var RgMaster = reader.Read<ADM_M023_P>().ToList();
        //                MC.RgMaster = RgMaster.ToList();
        //                var party = reader.Read<ADM_M028_P>().ToList();
        //                MC.partylist = party.ToList();

        //            }
        //            else if(strType=="LoadBackFlip")
        //            {
        //                var ItemMstr = reader.Read<ADM_M022>().ToList();
        //                MC.ItemMstr = ItemMstr.ToList();
        //            }
        //            else if (strType == "LoadAttachment")
        //            {
        //                var Attachment = reader.Read<COM_T003>().ToList();
        //                MC.Attachment = Attachment.ToList();
        //            }
        //        }

        //        string strData = ObjectSerializationService.ObjectToXML(MC);
        //        return strData;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new CreateException(ex.ErrorCode, ex.Message, ex);
        //    }
        //    catch (DivideByZeroException ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //}      
    }
    public class MultipleContext_ADM_M022
    {
        public List<ADM_M0002> COMPANY_LIST { get; set; }
        public List<ADM_M0003> LOCATION_LIST { get; set; }
        public List<STD_LIST_BE> BACK_FLIP_LIST { get; set; }
        public List<ADM_M022_Flip> BackflipList { get; set; }  //BackFlip List
        public List<ADM_M022> MasterEntity { get; set; }
        public List<ADM_M018_P> CategoryList { get; set; }  //Category Master
        public List<ADM_M019_P> SubCategoryList { get; set; }  //Sub Category Master
        public List<ADM_M015_P> ItemTypeList { get; set; }  //Item Type Master
        public List<ADM_M016_P> SubItemTypeList { get; set; }  //Sub Item Type Master
        public List<ADM_M020_P> ProductList { get; set; }  //Product Name Master
        public List<ADM_M014_P> CommodityList { get; set; }  //Commodity Master
        public List<ADM_M021_P> MaterialList { get; set; }  //Material Master
        public List<ADM_M017_P> AssetList { get; set; }  //Asset Master
        public List<ADM_M038_B_P> UnitList { get; set; }  //UOM Master
        public List<ADM_M023_P> RgGroupList { get; set; }  //RG Group Master
        public List<ADM_M028_P> PartyList { get; set; }  //Party Master
        public List<ACC_M003_V> ValuationClassList { get; set; }
        public List<ACC_M003_P> ReconAccountList { get; set; }
        public List<ACC_M003_H> AccountingGroupList { get; set; }
        public List<COM_T003> AttachmentList { get; set; }
        public List<ADM_M052_P> MaterialGroup { get; set; } //Material Group
        public List<ACC_M013_A_P> TaxCategory { get; set; } //Tax Category 
        public List<SYS_M051> ControlKeyMaster { get; set; }
        public List<QMS_M041_P> QMSystemMaster { get; set; }
        public List<QMS_M042_P> CertificateType { get; set; }
        public List<ADM_M022_B> ItemGroupExport { get; set; }
    }
    public class ADM_M052_P
    {
        public string gst_item_group { get; set; }
        public string gst_item_group_Nm { get; set; }
    }
}
