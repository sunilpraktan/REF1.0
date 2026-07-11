using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;
using Reflection.EF.Finance;
using Reflection.EF.Communication;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    public class ADM_M028BL : ReflectionBusinessLogic
    {              
        private static string connectionString;
        ADM_M028 MasterEntity = new ADM_M028();
        MultipleContext_ADM_M028 MC = new MultipleContext_ADM_M028();

        public ADM_M028BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M028BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M028Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ADM_M028Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var PartyI = reader.Read<ADM_M028>().ToList();
                    List<ADM_M028> PartyList = PartyI.ToList();
                    if (PartyList.Count > 0)
                    {
                        MasterEntity = PartyList[0];
                    }

                    var address = reader.Read<ADM_M028_D>().ToList();
                    MC.AddressEntity = address.ToList();

                    var contactperson = reader.Read<ADM_M028_C>().ToList();
                    MC.ContactEntity = contactperson.ToList();

                    MasterEntity.XmlDataDocument_ADM_M028_D = ObjectSerializationService.ObjectToXML(MC.AddressEntity);
                    MasterEntity.XmlDataDocument_ADM_M028_C = ObjectSerializationService.ObjectToXML(MC.ContactEntity);
                    MasterEntity.XmlDataDocument_ADM_M028FLIP = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
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
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M028Update", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var PartyI = reader.Read<ADM_M028>().ToList();
                    List<ADM_M028> PartyList = PartyI.ToList();
                    if (PartyList.Count > 0)
                    {
                        MasterEntity = PartyList[0];
                    }

                    var address = reader.Read<ADM_M028_D>().ToList();
                    MC.AddressEntity = address.ToList();

                    var contactperson = reader.Read<ADM_M028_C>().ToList();
                    MC.ContactEntity = contactperson.ToList();

                    MasterEntity.XmlDataDocument_ADM_M028_D = ObjectSerializationService.ObjectToXML(MC.AddressEntity);
                    MasterEntity.XmlDataDocument_ADM_M028_C = ObjectSerializationService.ObjectToXML(MC.ContactEntity);
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
                    var reader = conn.QueryMultiple("ADM_M028LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var PartyMs = reader.Read<ADM_M028Flip>().ToList();
                        MC.DocumentDataFlipGrid = PartyMs.ToList();

                        var Employee = reader.Read<ADM_M024_P>().ToList();
                        MC.Employees = Employee.ToList();

                        var locations = reader.Read<ADM_M003_P>().ToList();
                        MC.Locations = locations.ToList();

                        var currencys = reader.Read<ADM_M037_P>().ToList();
                        MC.Currency = currencys.ToList();

                        var country = reader.Read<ADM_M012_P>().ToList();
                        MC.Country = country.ToList();

                        var state = reader.Read<ADM_M013_P>().ToList();
                        MC.State = state.ToList();

                        var department = reader.Read<ADM_M025_P>().ToList();
                        MC.Departments = department.ToList();

                        var designation = reader.Read<ADM_M026_P>().ToList();
                        MC.Designations = designation.ToList();

                        var partytype = reader.Read<ADM_M028_B_P>().ToList();
                        MC.PartyType = partytype.ToList();

                        var group = reader.Read<ADM_M028_A_P>().ToList();
                        MC.Group = group.ToList();

                        var _AccountingGroup = reader.Read<ACC_M003_H>().ToList();
                        MC.AccountingGroupList  = _AccountingGroup.ToList();

                        var _ReconAccountList = reader.Read<ACC_M003_P>().ToList();
                        MC.ReconAccountList = _ReconAccountList.ToList();

                        var _BusinessPlace = reader.Read<ADM_M003_C_P>().ToList();
                        MC.BusinessPlace = _BusinessPlace.ToList();

                        var _TaxCategory = reader.Read<ACC_M013_A_P>().ToList();
                        MC.TaxCategory = _TaxCategory.ToList();

                        var _AccountGroup = reader.Read<ACC_M013_B_P>().ToList();
                        MC.AccountGroup = _AccountGroup.ToList();

                        var _BussGroupList = reader.Read<ADM_M028_J_P>().ToList();
                        MC.BussGroupList = _BussGroupList.ToList();

                        var payTerms = reader.Read<ACC_M007_P>().ToList();
                        MC.PayTerms = payTerms.ToList();
                    }

                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var MasterData = reader.Read<ADM_M028>().ToList();
                        MC.MasterEntity = MasterData.ToList();

                        var addressmaster = reader.Read<ADM_M028_D>().ToList();
                        MC.AddressEntity = addressmaster.ToList();

                        var contactmaster = reader.Read<ADM_M028_C>().ToList();
                        MC.ContactEntity = contactmaster.ToList();

                        var AttachmentList = reader.Read<COM_T003>().ToList();
                        MC.AttachmentList = AttachmentList.ToList();
                    }
                    else if (RequestOption == "Party_Report")
                    {
                        var PartyDetailData = reader.Read<RptParty>().ToList();
                        MC.RptPartyList = PartyDetailData.ToList();
                    }
                    else if (RequestOption == "LoadBackFlipData")
                    {
                        var PartyMs = reader.Read<ADM_M028Flip>().ToList();
                        MC.DocumentDataFlipGrid = PartyMs.ToList();
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
    }
    public class MultipleContext_ADM_M028 : MC_ADM_BE
    {
        //public List<STD_PARTY> PARTY_LIST { get; set; }
        //public List<ACC_M013> TAX_LIST { get; set; }
        //public List<ADM_M0002> COMPANY_LIST { get; set; }
        //public List<STD_LIST_BE> BACK_FLIP_LIST { get; set; }
        public List<ADM_M028Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M024_P> Employees { get; set; }
        public List<ADM_M003_P> Locations { get; set; }
        public List<ADM_M037_P> Currency { get; set; }
        public List<ADM_M012_P> Country { get; set; }
        public List<ADM_M013_P> State { get; set; }
        public List<ADM_M025_P> Departments { get; set; }
        public List<ADM_M026_P> Designations { get; set; }
        public List<ADM_M028_B_P> PartyType { get; set; }
        public List<ADM_M028_A_P> Group { get; set; }
        public List<ACC_M003_P> ReconAccountList { get; set; }
        public List<ADM_M028_D> AddressEntity { get; set; }
        public List<ADM_M028_C> ContactEntity { get; set; }
        public List<ADM_M028> MasterEntity { get; set; }
        public List<ACC_M003_H> AccountingGroupList { get; set; }
        public List<RptParty> RptPartyList { get; set; }
        public List<ADM_M003_C_P> BusinessPlace { get; set; }
        public List<ACC_M013_A_P> TaxCategory { get; set; }
        public List<ACC_M013_B_P> AccountGroup { get; set; }
        public List<ADM_M028_J_P> BussGroupList { get; set; }
        public List<ACC_M007_P> PayTerms { get; set; }
        public List<COM_T003> AttachmentList { get; set; }
    }
}
