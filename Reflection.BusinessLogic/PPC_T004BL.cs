using Reflection.EF;
using Reflection.EF.Production;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.Production.ReportEntityProduction;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
   public class PPC_T004BL : ReflectionBusinessLogic
    {
          private static string connectionString;

            PPC_T004 MasterEntity = new PPC_T004();
            MultipleContext_PPC_T004 MC = new MultipleContext_PPC_T004();

            public PPC_T004BL(string BusinessEntity)
            {
                connectionString = base.ReflectionConnectionString;
            }
            public PPC_T004BL()
            {
                connectionString = base.ReflectionConnectionString;
            }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
            {
                MultipleContext_PPC_T004 MC = new MultipleContext_PPC_T004();
                string RequestOption = RequestValue.Split('!')[0];

                string strReturnData = "";
                try
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("PPC_T004_LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                        {
                            if (RequestOption == "LoadInitialData")
                            {
                            //var BackflipList = reader.Read<PPC_T004_P>().ToList();
                            //MC.BackflipList = BackflipList.ToList();

                            MC.IldChartList = reader.Read<EPR_T001_P1>().ToList();

                            var SalesOrderList = reader.Read<SEL_T001_P1>().ToList();
                            MC.SalesOrderList = SalesOrderList.ToList();

                            var BallDiaList = reader.Read<ZADM_M001_P>().ToList();
                            MC.BallSizeList = BallDiaList.ToList();

                            var BallTypeList = reader.Read<ZADM_M002_P>().ToList();
                            MC.BallTypeList = BallTypeList.ToList();

                            var WireSizeList = reader.Read<ZADM_M003_P>().ToList();
                            MC.WireSizeList = WireSizeList.ToList();

                            var MachineList = reader.Read<PPC_M001_P>().ToList();
                            MC.MachineList = MachineList.ToList();

                            var UnitList = reader.Read<ADM_M038_B_P>().ToList();
                            MC.UnitList = UnitList.ToList();

                            var ItemMaster = reader.Read<ADM_M022_P>().ToList();
                            MC.ItemList = ItemMaster.ToList();

                            var InkList = reader.Read<ZADM_M006_P>().ToList();
                            MC.InkList = InkList.ToList();

                            var ILDList = reader.Read<ZADM_M007_P>().ToList();
                            MC.ILDList = ILDList.ToList();

                            var MakeList = reader.Read<ADM_M032_P>().ToList();
                            MC.MakeList = MakeList.ToList();

                            var WireTypeList = reader.Read<ZADM_M004_P>().ToList();
                            MC.WireTypeList = WireTypeList.ToList();

                            var BomNoList = reader.Read<ENG_T001_P>().ToList();
                            MC.BomNoList = BomNoList.ToList();

                            var _t_statusList = reader.Read<ADM_M0013>().ToList();
                            MC.t_statusList = _t_statusList.ToList();

                            var _soListIld = reader.Read<PPC_T004_B>().ToList();
                            MC.SoDetailsILDChart = _soListIld.ToList();

                            var DocCategory = reader.Read<SYS_M013>().ToList();
                            MC.DocCategoryList = DocCategory.ToList();

                            var pkgunit = reader.Read<ZADM_M017_P>().ToList();
                            MC.PkgUnitList = pkgunit.ToList();

                            var Store = reader.Read<MM_M001_P>().ToList();
                            MC.store = Store.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            }
                            if (RequestOption == "LoadDocumentByDocumentNumber")
                            {
                                var MaterEntity = reader.Read<PPC_T004>().ToList();
                                List<PPC_T004> Masterlist = MaterEntity.ToList();
                                MasterEntity = Masterlist[0];

                                var MachineEntity = reader.Read<PPC_T004_A>().ToList();
                                MC.MachineDetailEntity = MachineEntity.ToList();

                                var SoDetail = reader.Read<PPC_T004_B>().ToList();
                                MC.SoDetailEntity = SoDetail.ToList();

                                MasterEntity.xdoc_PPC_T004_A = ObjectSerializationService.ObjectToXML(MC.MachineDetailEntity);
                                MasterEntity.xdoc_PPC_T004_B = ObjectSerializationService.ObjectToXML(MC.SoDetailEntity);

                                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
                            }
                            else if (RequestOption == "LoadMRPReports")
                            {
                                var mrpReport = reader.Read<Rpt_BillOfMaterial>().ToList();
                                MC.MRPRpt = mrpReport.ToList();

                                strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            }
                            else if (RequestOption == "LoadAttachment")
                            {
                                var Attachment = reader.Read<COM_T003>().ToList();
                                MC.Attachment = Attachment.ToList();

                                strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            }
                            else if (RequestOption == "LoadHistory")
                            {
                                var BackflipList = reader.Read<PPC_T004_P>().ToList();
                                MC.BackflipList = BackflipList.ToList();
                           
                                strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            }
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
            public string Insert1(string Request)
            {
            
                try
                    {
                    Request = (string)ObjectSerializationService.XMLToObject(Request, Request);
                  
                    int reader;
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                    
                         reader = conn.Execute("PPC_T004_Cancel", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                    }

                    string strReturnData = reader.ToString();
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
            public string Insert(string Request)
            {
                MultipleContext_PPC_T004 MC = new MultipleContext_PPC_T004();
                string strReturnData = "";
                try
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("PPC_T004Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var BackflipList = reader.Read<PPC_T004_P>().ToList();
                        MC.BackflipList = BackflipList.ToList();

                        var SalesOrderList = reader.Read<SEL_T001_P1>().ToList();
                        MC.SalesOrderList = SalesOrderList.ToList();

                        var MasterData = reader.Read<PPC_T004>().ToList();
                        List<PPC_T004> Masterlist = MasterData.ToList();
                        if (Masterlist.Count > 0)
                        {
                            MasterEntity = Masterlist[0];
                        }

                        var MachineData = reader.Read<PPC_T004_A>().ToList();
                        MC.MachineDetailEntity = MachineData.ToList();

                        var SOData = reader.Read<PPC_T004_B>().ToList();
                        MC.SoDetailEntity = SOData.ToList();

                        MasterEntity.XmlDataDocument_BackFlip = ObjectSerializationService.ObjectToXML(MC.BackflipList);
                        MasterEntity.xdoc_SEL_T001_P1 = ObjectSerializationService.ObjectToXML(MC.SalesOrderList);
                        MasterEntity.xdoc_PPC_T004_A = ObjectSerializationService.ObjectToXML(MC.MachineDetailEntity);
                        MasterEntity.xdoc_PPC_T004_B = ObjectSerializationService.ObjectToXML(MC.SoDetailEntity);
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
                MultipleContext_PPC_T004 MC = new MultipleContext_PPC_T004();
                string strReturnData = "";
                try
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {

                        var reader = conn.QueryMultiple("PPC_T004Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var MasterData = reader.Read<PPC_T004>().ToList();
                        List<PPC_T004> Masterlist = MasterData.ToList();
                        if (Masterlist.Count > 0)
                        {
                            MasterEntity = Masterlist[0];
                        }

                        var MachineData = reader.Read<PPC_T004_A>().ToList();
                        MC.MachineDetailEntity = MachineData.ToList();

                        var SOData = reader.Read<PPC_T004_B>().ToList();
                        MC.SoDetailEntity = SOData.ToList();

                        MasterEntity.xdoc_PPC_T004_A = ObjectSerializationService.ObjectToXML(MC.MachineDetailEntity);
                        MasterEntity.xdoc_PPC_T004_B = ObjectSerializationService.ObjectToXML(MC.SoDetailEntity);

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
    public class MultipleContext_PPC_T004
    {
        public List<PPC_T004> MasterEntity { get; set; }
        public List<PPC_T004_A> MachineDetailEntity { get; set; }
        public List<PPC_T004_B> SoDetailEntity { get; set; }
        public List<PPC_T004_P> BackflipList { get; set; }
        public List<EPR_T001_P1> IldChartList { get; set; }
        public List<SEL_T001_P1> SalesOrderList { get; set; }
        public List<ZADM_M001_P> BallSizeList { get; set; }
        public List<ZADM_M002_P> BallTypeList { get; set; }
        public List<ZADM_M003_P> WireSizeList { get; set; }
        //public List<ZADM_M013_P> MachineList { get; set; }//old table Machine Master
        public List<PPC_M001_P> MachineList { get; set; }//New table Work Center ie M/c Master
        public List<ADM_M038_B_P> UnitList { get; set; }
        public List<ADM_M022_P> ItemList { get; set; } //Item Master
        public List<ZADM_M006_P> InkList { get; set; }  //Ink Master     
        public List<ZADM_M007_P> ILDList { get; set; } //ILD Master
        public List<ADM_M032_P> MakeList { get; set; } //Make Master  
        public List<ZADM_M004_P> WireTypeList { get; set; } //WireType Master             
        public List<ENG_T001_P> BomNoList { get; set; } //All BOM             
        //public List<EPR_T004_AMRPReportEntity> MRPRpt { get; set; }
        public List<Rpt_BillOfMaterial> MRPRpt { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<PPC_T004_B> SoDetailsILDChart { get; set; }
        public List<SYS_M013> DocCategoryList { get; set; }
        public List<ZADM_M017_P> PkgUnitList { get; set; }
        public List<MM_M001_P> store { get; set; }  //Storage Location Master
    }
}
