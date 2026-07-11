using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF.Procurement;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF;
using Reflection.EF.ReflectionSystem;
using Dapper;
using Reflection.EF.CRM;

namespace Reflection.BusinessLogic
{
    public class PUR_T002StoBL : ReflectionBusinessLogic
    {

        
        private static string connectionString;

        MultipleContext_PUR_T002_A MC = new MultipleContext_PUR_T002_A();
        PUR_T002_A MasterEntity = new PUR_T002_A();
        public PUR_T002StoBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public PUR_T002StoBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
           
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T002Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<PUR_T002_AFlip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();
                    var MasterData = reader.Read<PUR_T002_A>().ToList();
                    MC.DocumentMaster = MasterData.ToList();
                    if (MC.DocumentMaster.Count > 0)
                    {
                        MasterEntity = MC.DocumentMaster[0];
                    }
               
                    var ItemsData = reader.Read<PUR_T002_B>().ToList();
                    MC.DocumentItems = ItemsData.ToList();
                    var TaxData = reader.Read<ACC_T006_B>().ToList();
                    MC.DocumentTaxDetails = TaxData.ToList();
                    var Schedule_B_Data = reader.Read<PUR_T004_B>().ToList();
                    MC.DocumentScheduleDetails = Schedule_B_Data.ToList();
                    var Schedule_A_Data = reader.Read<PUR_T004_A>().ToList();
                    MC.DocumentScheduleMaster = Schedule_A_Data.ToList();


                    MasterEntity.XmlDataDocument_PUR_T002_B = ObjectSerializationService.ObjectToXML(MC.DocumentItems);
                    MasterEntity.XmlDataDocument_ACC_T006_B = ObjectSerializationService.ObjectToXML(MC.DocumentTaxDetails);
                    MasterEntity.XmlDataDocument_PUR_T004_B = ObjectSerializationService.ObjectToXML(MC.DocumentScheduleDetails);
                    MasterEntity.XmlDataDocument_PUR_T004_A = ObjectSerializationService.ObjectToXML(MC.DocumentScheduleMaster);
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
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
            //MultipleContext_PUR_T002_A MC = new MultipleContext_PUR_T002_A();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T002Update", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                   
                    var MasterData = reader.Read<PUR_T002_A>().ToList();
                    MC.DocumentMaster = MasterData.ToList();
                    if (MC.DocumentMaster.Count > 0)
                    {
                        MasterEntity = MC.DocumentMaster[0];
                    }
                    var ItemsData = reader.Read<PUR_T002_B>().ToList();
                    MC.DocumentItems = ItemsData.ToList();
                    var TaxData = reader.Read<ACC_T006_B>().ToList();
                    MC.DocumentTaxDetails = TaxData.ToList();
                    var Schedule_B_Data = reader.Read<PUR_T004_B>().ToList();
                    MC.DocumentScheduleDetails = Schedule_B_Data.ToList();
                    var Schedule_A_Data = reader.Read<PUR_T004_A>().ToList();
                    MC.DocumentScheduleMaster = Schedule_A_Data.ToList();

                    MasterEntity.XmlDataDocument_PUR_T002_B = ObjectSerializationService.ObjectToXML(MC.DocumentItems);
                    MasterEntity.XmlDataDocument_ACC_T006_B = ObjectSerializationService.ObjectToXML(MC.DocumentTaxDetails);
                    MasterEntity.XmlDataDocument_PUR_T004_B = ObjectSerializationService.ObjectToXML(MC.DocumentScheduleDetails);
                    MasterEntity.XmlDataDocument_PUR_T004_A = ObjectSerializationService.ObjectToXML(MC.DocumentScheduleMaster);

                    strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
                    return strReturnData;
                }
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
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("PUR_T002Delete", new { @po_no = Request }, commandType: CommandType.StoredProcedure);
                    return intOut.ToString();
                }

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
            //MultipleContext_PUR_T002_A MC = new MultipleContext_PUR_T002_A();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T002STOLoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var DocDataFlipGrid = reader.Read<PUR_T002_AFlip>().ToList();
                        MC.DocumentDataFlipGrid = DocDataFlipGrid.ToList();

                        var UnitList = reader.Read<ADM_M038_B_P>().ToList();
                        MC.unitList = UnitList.ToList();
                        var BuyerList = reader.Read<ADM_M024_P>().ToList();
                        MC.BuyerList = BuyerList.ToList();
                        var journalList = reader.Read<ACC_M005_P>().ToList();
                        MC.journalList = journalList.ToList();
                        var TaxList = reader.Read<ACC_M013_P>().ToList();
                        MC.TaxList = TaxList.ToList();
                        var AccountList = reader.Read<ACC_M003_P>().ToList();
                        MC.AccountList = AccountList.ToList();
                        var PayTerms = reader.Read<ACC_M007_P>().ToList();
                        MC.PayTerms = PayTerms.ToList();
                        var WarehouseList = reader.Read<MM_M002_P>().ToList();
                        MC.WarehouseList = WarehouseList.ToList();
                        var doc_typeList = reader.Read<SYS_M007>().ToList();
                        MC.doc_typeList = doc_typeList.ToList();
                        var currencyList = reader.Read<ADM_M037_P>().ToList();
                        MC.currencyList = currencyList.ToList();
                        var reference_docList = reader.Read<PUR_T002_P_RefeDoc>().ToList();
                        MC.reference_docList = reference_docList.ToList();
                        var purchase_orgList = reader.Read<ADM_M001_M_P>().ToList();
                        MC.purchase_orgList = purchase_orgList.ToList();
                        var Purchase_groupList = reader.Read<ADM_M001_P_P>().ToList();
                        MC.Purchase_groupList = Purchase_groupList.ToList();
                        var storage_locList = reader.Read<MM_M001_P>().ToList();
                        MC.storage_locList = storage_locList.ToList();
                        var cost_centerList = reader.Read<ACC_M019_P>().ToList();
                        MC.cost_centerList = cost_centerList.ToList();
                        var billaddrList = reader.Read<ADM_M002_P>().ToList();
                        MC.billaddrList = billaddrList.ToList();
                        var deladdrList = reader.Read<ADM_M003_P>().ToList();
                        MC.deladdrList = deladdrList.ToList();
                        var itemcatList = reader.Read<SYS_M008_P>().ToList();
                        MC.itemcatList = itemcatList.ToList();
                        var ItemList = reader.Read<PUR_T002_P_PR_ItemsList>().ToList();
                        MC.ItemListForPopup = ItemList.ToList();
                        MC.Trade_Types = reader.Read<SYS_M037>().ToList();
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                    {
                        var MasterData = reader.Read<PUR_T002_A>().ToList();
                        MC.DocumentMaster = MasterData.ToList();
                        MasterEntity = MC.DocumentMaster[0];
                        var ItemsData = reader.Read<PUR_T002_B>().ToList();
                        MC.DocumentItems = ItemsData.ToList();
                        var TaxData = reader.Read<ACC_T006_B>().ToList();
                        MC.DocumentTaxDetails = TaxData.ToList();
                        var Schedule_B_Data = reader.Read<PUR_T004_B>().ToList();
                        MC.DocumentScheduleDetails = Schedule_B_Data.ToList();
                        var Schedule_A_Data = reader.Read<PUR_T004_A>().ToList();
                        MC.DocumentScheduleMaster = Schedule_A_Data.ToList();

                        MasterEntity.XmlDataDocument_PUR_T002_B = ObjectSerializationService.ObjectToXML(MC.DocumentItems);
                        MasterEntity.XmlDataDocument_ACC_T006_B = ObjectSerializationService.ObjectToXML(MC.DocumentTaxDetails);
                        MasterEntity.XmlDataDocument_PUR_T004_B = ObjectSerializationService.ObjectToXML(MC.DocumentScheduleDetails);
                        MasterEntity.XmlDataDocument_PUR_T004_A = ObjectSerializationService.ObjectToXML(MC.DocumentScheduleMaster);

                        strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
                        return strReturnData;
                    }
                    else if (RequestOption == "LoadPODetails")
                    {

                    }
                }
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

        public class MultipleContext_PUR_T002_A
        {
            public List<PUR_T002_AFlip> DocumentDataFlipGrid { get; set; }
            public List<ADM_M028_P> partyList { get; set; }
            public List<ADM_M038_B_P> unitList { get; set; }
            public List<ADM_M024_P> BuyerList { get; set; }
            public List<ACC_M005_P> journalList { get; set; }
            public List<ACC_M013_P> TaxList { get; set; }
            public List<ACC_M003_P> AccountList { get; set; }
            public List<ACC_M007_P> PayTerms { get; set; }
            public List<MM_M002_P> WarehouseList { get; set; }
            public List<SYS_M007> doc_typeList { get; set; }
            public List<ADM_M037_P> currencyList { get; set; }
            public List<PUR_T002_P_RefeDoc> reference_docList { get; set; }
            public List<ADM_M001_M_P> purchase_orgList { get; set; }
            public List<ADM_M001_P_P> Purchase_groupList { get; set; }
            public List<MM_M001_P> storage_locList { get; set; }
            public List<ACC_M019_P> cost_centerList { get; set; }
            public List<ADM_M002_P> billaddrList { get; set; }
            public List<ADM_M003_P> deladdrList { get; set; }
            public List<SYS_M008_P> itemcatList { get; set; }
            public List<PUR_T002_P_PR_ItemsList> ItemListForPopup { get; set; }
            public List<PUR_T002_A> DocumentMaster { get; set; }
            public List<PUR_T002_B> DocumentItems { get; set; }
            public List<PUR_T002_C> DocumentTax { get; set; }
            public List<ACC_T006_B> DocumentTaxDetails { get; set; }
            public List<PUR_T004_A> DocumentScheduleMaster { get; set; }
            public List<PUR_T004_B> DocumentScheduleDetails { get; set; }
            public List<SYS_M037> Trade_Types { get; set; }

        }
    }
   
}
