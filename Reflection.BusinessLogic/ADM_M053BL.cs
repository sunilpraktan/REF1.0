using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;
using Reflection.EF.Finance;

namespace Reflection.BusinessLogic
{
   
    public class ADM_M053BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        ADM_M053 MasterEntity = new ADM_M053();
        MultipleContext_ADM_M053 MC = new MultipleContext_ADM_M053();

        public ADM_M053BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M053BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MasterEntity = (ADM_M053)ObjectSerializationService.XMLToObject(Request, MasterEntity);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M053Insert", new { @Request = Request, @Photo = MasterEntity.photo}, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ADM_M053Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var GeneralParty = reader.Read<ADM_M053>().ToList();
                    List<ADM_M053> GeneralPartyList = GeneralParty.ToList();
                    if (GeneralPartyList.Count > 0)
                    {
                        MasterEntity = GeneralPartyList[0];
                    }

                    var Address = reader.Read<ADM_M055>().ToList();
                    MC.AddressEntity = Address.ToList();

                    var Communication = reader.Read<ADM_M057>().ToList();
                    MC.CommunicationEntity = Communication.ToList();

                    MasterEntity.XmlDataDocument_ADM_M055 = ObjectSerializationService.ObjectToXML(MC.AddressEntity);
                    MasterEntity.XmlDataDocument_ADM_M057 = ObjectSerializationService.ObjectToXML(MC.CommunicationEntity);
                    MasterEntity.XmlDataDocument_ADM_M053Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
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
            try
            {
                MasterEntity = (ADM_M053)ObjectSerializationService.XMLToObject(Request, MasterEntity);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M053Update", new { @Request = Request, @Photo = MasterEntity.photo}, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ADM_M053Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var GeneralParty = reader.Read<ADM_M053>().ToList();
                    List<ADM_M053> GeneralPartyList = GeneralParty.ToList();
                    if (GeneralPartyList.Count > 0)
                    {
                        MasterEntity = GeneralPartyList[0];
                    }

                    var Address = reader.Read<ADM_M055>().ToList();
                    MC.AddressEntity = Address.ToList();

                    var Communication = reader.Read<ADM_M057>().ToList();
                    MC.CommunicationEntity = Communication.ToList();

                    MasterEntity.XmlDataDocument_ADM_M055 = ObjectSerializationService.ObjectToXML(MC.AddressEntity);
                    MasterEntity.XmlDataDocument_ADM_M057 = ObjectSerializationService.ObjectToXML(MC.CommunicationEntity);
                    MasterEntity.XmlDataDocument_ADM_M053Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = 0; //conn.Execute("ADM_M028Delete", new { @PartyId = Request }, commandType: CommandType.StoredProcedure);
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
            try
            {
                string RequestOption = RequestValue.Split('!')[0];
                string strReturnData = "";

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M053LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var FlipGridData = reader.Read<ADM_M053Flip>().ToList();
                        MC.DocumentDataFlipGrid = FlipGridData.ToList();

                        var SalutationData = reader.Read<ADM_M050_P>().ToList();
                        MC.SalutationList = SalutationData.ToList();

                        var PartyTypeData = reader.Read<ADM_M028_B_P>().ToList();
                        MC.PartyType = PartyTypeData.ToList();

                        var PartyGroupData = reader.Read<ADM_M028_A_P>().ToList();
                        MC.Group = PartyGroupData.ToList();

                        var AccGroupData = reader.Read<ACC_M003_H_P>().ToList();
                        MC.AccountingGroupList = AccGroupData.ToList();

                        var RefContPersonData = reader.Read<ADM_M054_P>().ToList();
                        MC.RefContPersonList = RefContPersonData.ToList();

                        var StateData = reader.Read<ADM_M013_P>().ToList();
                        MC.State = StateData.ToList();

                        var CountryData = reader.Read<ADM_M012_P>().ToList();
                        MC.Country = CountryData.ToList();

                        var TypeData = reader.Read<ADM_M057_A_P>().ToList();
                        MC.TypeList = TypeData.ToList();

                    }
                    else if(RequestOption == "LoadInitialBackFlipData")
                    {
                        var FlipGridData = reader.Read<ADM_M053Flip>().ToList();
                        MC.DocumentDataFlipGrid = FlipGridData.ToList();                     

                    }

                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                       
                        var MasterData = reader.Read<ADM_M053>().ToList();
                        MC.MasterEntity = MasterData.ToList();

                        var Address = reader.Read<ADM_M055>().ToList();
                        MC.AddressEntity = Address.ToList();

                        var Communication = reader.Read<ADM_M057>().ToList();
                        MC.CommunicationEntity = Communication.ToList();
                    }
                    else if (RequestOption == "Party_Report")
                    {
                        var PartyDetailData = reader.Read<ADM_M053Rpt>().ToList();
                        MC.ADM_M053RptList = PartyDetailData.ToList();

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
        public class MultipleContext_ADM_M053
        {
            public List<ADM_M053Flip> DocumentDataFlipGrid { get; set; }
            public List<ADM_M053> MasterEntity { get; set; }
            public List<ADM_M055> AddressEntity { get; set; }
            public List<ADM_M057> CommunicationEntity { get; set; }
            public List<ADM_M053Rpt> ADM_M053RptList { get; set; }
            public List<ADM_M050_P> SalutationList { get; set; }
            public List<ADM_M028_B_P> PartyType { get; set; }
            public List<ADM_M028_A_P> Group { get; set; }
            public List<ACC_M003_H_P> AccountingGroupList { get; set; }
            public List<ADM_M054_P> RefContPersonList { get; set; }
            public List<ADM_M013_P> State { get; set; }
            public List<ADM_M012_P> Country { get; set; }
            public List<ADM_M057_A_P> TypeList { get; set; }

        }
    }
}
