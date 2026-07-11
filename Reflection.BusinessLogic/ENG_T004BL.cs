using Dapper;
using Reflection.BusinessLogic.REF;
using Reflection.EF;
using Reflection.EF.Communication;
using Reflection.EF.CRM.ReportEntityCRM;
using Reflection.EF.Production;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Reflection.BusinessLogic
{
    class ENG_T004BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        ENG_T004 MasterEntity = new ENG_T004();
        MultipleContext_ENG_T004 MC = new MultipleContext_ENG_T004();
        ReflectionServices ServiceObject = new ReflectionServices();

        public ENG_T004BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ENG_T004BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            MultipleContext_ENG_T004 MC = new MultipleContext_ENG_T004();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ENG_T004Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackflipList = reader.Read<ENG_T004_P>().ToList();
                    MC.BackflipList = BackflipList.ToList();

                    var MasterData = reader.Read<ENG_T004>().ToList();
                    List<ENG_T004> Masterlist = MasterData.ToList();
                    if(Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }                  

                    var ParaDetailEntity = reader.Read<ENG_T004_A>().ToList();
                    MC.ParaDetailEntity = ParaDetailEntity.ToList();

                    var ControlParaDetailEntity = reader.Read<ENG_T004_B>().ToList();
                    MC.ControlParaDetailEntity = ControlParaDetailEntity.ToList();

                    var References = reader.Read<ENG_T004_C>().ToList();
                    MC.ReferencesList = References.ToList();

                    var PartyListtemp = reader.Read<ENG_T004_D>().ToList();
                    MC.PartyList = PartyListtemp.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.BackflipList);
                    MasterEntity.XmlDataDocument_ENG_T004_A = ObjectSerializationService.ObjectToXML(MC.ParaDetailEntity);
                    MasterEntity.XmlDataDocument_ENG_T004_B = ObjectSerializationService.ObjectToXML(MC.ControlParaDetailEntity);
                    MasterEntity.XmlDataDocument_ENG_T004_C = ObjectSerializationService.ObjectToXML(MC.ReferencesList);
                    MasterEntity.XmlDataDocument_ENG_T004_D = ObjectSerializationService.ObjectToXML(MC.PartyList);
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
            try
            {
                MultipleContext_ENG_T004 MC = new MultipleContext_ENG_T004();
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ENG_T004Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackflipList = reader.Read<ENG_T004_P>().ToList();
                    MC.BackflipList = BackflipList.ToList();

                    var MasterData = reader.Read<ENG_T004>().ToList();
                    List<ENG_T004> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var ParaDetailEntity = reader.Read<ENG_T004_A>().ToList();
                    MC.ParaDetailEntity = ParaDetailEntity.ToList();

                    var ControlParaDetailEntity = reader.Read<ENG_T004_B>().ToList();
                    MC.ControlParaDetailEntity = ControlParaDetailEntity.ToList();

                    var References = reader.Read<ENG_T004_C>().ToList();
                    MC.ReferencesList = References.ToList();

                    var PartyListtemp = reader.Read<ENG_T004_D>().ToList();
                    MC.PartyList = PartyListtemp.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.BackflipList);
                    MasterEntity.XmlDataDocument_ENG_T004_A = ObjectSerializationService.ObjectToXML(MC.ParaDetailEntity);
                    MasterEntity.XmlDataDocument_ENG_T004_B = ObjectSerializationService.ObjectToXML(MC.ControlParaDetailEntity);
                    MasterEntity.XmlDataDocument_ENG_T004_C = ObjectSerializationService.ObjectToXML(MC.ReferencesList);
                    MasterEntity.XmlDataDocument_ENG_T004_D = ObjectSerializationService.ObjectToXML(MC.PartyList);
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
            MultipleContext_ENG_T004 MC = new MultipleContext_ENG_T004();
            string RequestOption = RequestValue.Split('!')[0];

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ENG_T004LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var BackflipList = reader.Read<ENG_T004_P>().ToList();
                            MC.BackflipList = BackflipList.ToList();

                            var ItemMaster = reader.Read<ADM_M022_P>().ToList();
                            MC.ItemList = ItemMaster.ToList();

                            var Ink = reader.Read<ZADM_M006_P>().ToList();
                            MC.Ink = Ink.ToList();

                            var ILD = reader.Read<ZADM_M007_P>().ToList();
                            MC.ILD = ILD.ToList();

                            var MachineList = reader.Read<ZADM_M013_P>().ToList();
                            MC.MachineList = MachineList.ToList();

                            var UnitList = reader.Read<ADM_M038_B_P>().ToList();
                            MC.UnitList = UnitList.ToList();

                            var ModelList = reader.Read<ZADM_M009_P>().ToList();
                            MC.ModelList = ModelList.ToList();
                            
                            

                            var SpecificationTypeList = reader.Read<ENG_T002>().ToList();
                            MC.SpecificationTypeList = SpecificationTypeList.ToList();

                            var SpecificationParaList = reader.Read<ENG_T003>().ToList();
                            MC.SpecificationParaList = SpecificationParaList.ToList();

                            //var BallMakeList = reader.Read<ADM_M032_P>().ToList();
                            //MC.BallMakeList = BallMakeList.ToList();

                            //var WireMakeList = reader.Read<ADM_M032_P>().ToList();
                            //MC.WireMakeList = WireMakeList.ToList();

                            var WireTypeList = reader.Read<ZADM_M004_P>().ToList();
                            MC.WireTypeList = WireTypeList.ToList();

                            var GradeList = reader.Read<ADM_M045_P>().ToList();
                            MC.GradeList = GradeList.ToList();

                            //var MakeList = reader.Read<ADM_M032_P>().ToList();
                            //MC.MakeList = MakeList.ToList();                          

                            var paramValueList = reader.Read<ADM_M030_P>().ToList();
                            MC.ParamValueList = paramValueList.ToList();

                            var BallDiaList = reader.Read<ZADM_M001_P>().ToList();
                            MC.BallDiaList = BallDiaList.ToList();

                            var WireDiaList = reader.Read<ZADM_M003_P>().ToList();
                            MC.WireDiaList = WireDiaList.ToList();

                            var Working = reader.Read<ENG_T003>().ToList();
                            MC.WorkingList = Working.ToList();

                            var Instrument = reader.Read<ENG_T003>().ToList();
                            MC.InstrumentList = Instrument.ToList();

                            var _CustomerList = reader.Read<ADM_M028_P>().ToList();
                            MC.CustomerList = _CustomerList.ToList();

                            var _Ref_ILD = reader.Read<ZADM_M007_P>().ToList();
                            MC.Ref_ILD = _Ref_ILD.ToList();

                            var stationNoList = reader.Read<ADM_M030_P>().ToList();
                            MC.StationNoList = stationNoList.ToList();

                            var PartyMastertemp = reader.Read<ADM_M028_P>().ToList();
                            MC.PartyMaster = PartyMastertemp.ToList();
                        }
                        else if (RequestOption == "LoadTDSFilterView")
                        {
                            var _BackflipList = reader.Read<ENG_T004_P>().ToList();
                            MC.BackflipList = _BackflipList.ToList();
                        }
                        if (RequestOption == "LoadItemDetails")
                        {
                            var SelectedParameterDetails = reader.Read<ENG_T004_A>().ToList();
                            MC.SelectedParameterDetails = SelectedParameterDetails.ToList();

                            var SelectedItemDetails = reader.Read<ENG_T004_B>().ToList();
                            MC.SelectedItemDetails = SelectedItemDetails.ToList();
                        }
                        if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var MasterList = reader.Read<ENG_T004>().ToList();
                            MC.MasterEntity = MasterList.ToList();

                            var ParaDetailEntity = reader.Read<ENG_T004_A>().ToList();
                            MC.ParaDetailEntity = ParaDetailEntity.ToList();

                            var ControlParaDetailEntity = reader.Read<ENG_T004_B>().ToList();
                            MC.ControlParaDetailEntity = ControlParaDetailEntity.ToList();

                            var References = reader.Read<ENG_T004_C>().ToList();
                            MC.ReferencesList = References.ToList();

                            var PartyListtemp = reader.Read<ENG_T004_D>().ToList();
                            MC.PartyList = PartyListtemp.ToList();

                            var Attachment = reader.Read<COM_T003>().ToList();
                            MC.Attachment = Attachment.ToList();
                        }
                        if (RequestOption == "Rpt_TDS")
                        {
                            var MasterList = reader.Read<ENG_T004>().ToList();
                            MC.MasterEntity = MasterList.ToList();

                            var RptWire_Ball_details = reader.Read<RptTDS>().ToList();
                            MC.RptWire_Ball_details = RptWire_Ball_details.ToList();

                            var RptToolsDetails = reader.Read<RptTools>().ToList();
                            MC.RptToolsDetails = RptToolsDetails.ToList();

                            var RptDrillsDetails = reader.Read<RptDrills>().ToList();
                            MC.RptDrillsDetails = RptDrillsDetails.ToList();

                            var RptSparesDetails = reader.Read<RptSpares>().ToList();
                            MC.RptSparesDetails = RptSparesDetails.ToList();

                            MC.MediaList = reader.Read<COM_T003>().ToList();
                            if(MC.MediaList != null)
                            {
                                if(MC.MediaList.Count > 0)
                                {
                                    foreach (var item in MC.MediaList)
                                    {
                                        item.file_data = ServiceObject.ConvertImageToByteArray(item);
                                    }
                                }
                            }
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
    public class MultipleContext_ENG_T004
    {
        public List<COM_T003> MediaList { get; set; }
        public List<ENG_T004> MasterEntity { get;set;}
        public List<ENG_T004_A>ParaDetailEntity{get;set;}
        public List<ENG_T004_B> ControlParaDetailEntity { get; set; }     
        public List<ENG_T004_P> BackflipList { get; set; }
        public List<ADM_M022_P> ItemList { get; set; } //Item Master
        public List<ADM_M038_B_P> UnitList { get; set; } //Unit Master
        public List<ZADM_M007_P> ILD { get; set; } //ILD Master
        public List<ZADM_M006_P> Ink { get; set; }  //Ink Master
        public List<ZADM_M013_P> MachineList { get; set; } //Machine Master
        public List<ZADM_M009_P> ModelList { get; set; } //Model Master
        public List<ADM_M030_P> StationNoList { get; set; }//station type master
        public List<ENG_T002> SpecificationTypeList { get; set; }//specification type master
        public List<ENG_T003> SpecificationParaList { get; set; }//specification Parameter master
        public List<ENG_T003> WorkingList { get; set; }//working list
        public List<ENG_T003> InstrumentList { get; set; }//instrument list



        //public List<ADM_M032_P> BallMakeList { get; set;}
        //public List<ADM_M032_P> WireMakeList { get; set; }
        public List<ZADM_M004_P> WireTypeList { get; set; }
        public List<ADM_M045_P> GradeList { get; set; }
        //public List<ADM_M032_P>MakeList{get;set;}
        public List<ADM_M030_P> ParamValueList { get; set; } //Flute Master
        public List<COM_T003> Attachment { get; set; }
        public List<ENG_T004_A> SelectedParameterDetails { get; set; }
        public List<ENG_T004_B> SelectedItemDetails { get; set; }
        public List<ZADM_M001_P> BallDiaList { get; set; }
        public List<ZADM_M003_P> WireDiaList { get; set; }
        public List<ENG_T004_C> ReferencesList { get; set; }
        public List<COM_T003_Files> AttachmentFiles { get; set; }
        public List<ADM_M028_P> CustomerList { get; set; } //Customer Master
        public List<ZADM_M007_P> Ref_ILD { get; set; } //ILD Master
        public List<ENG_T004_D> PartyList { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; } //Party Master

        //Reports
        public List<RptTools> RptToolsDetails { get; set; }
        public List<RptTDS> RptWire_Ball_details { get; set; }
        public List<RptDrills> RptDrillsDetails { get; set; }
        public List<RptSpares> RptSparesDetails { get; set;}
}

}
