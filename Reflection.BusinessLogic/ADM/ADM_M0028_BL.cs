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

namespace Reflection.BusinessLogic.ADM
{
    public class ADM_M0028_BL : ReflectionBusinessLogic
    {
        ADM_M028 MasterEntity = new ADM_M028();
        MultipleContext_ADM_M028 MC = new MultipleContext_ADM_M028();

        public ADM_M0028_BL()
        {
        }
        public string Insert(string Request, string RequestOption)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M0028_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

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
                return ObjectSerializationService.ObjectToXML(MasterEntity);
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
        public string Update(string Request, string RequestOption)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M0028_UPD", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

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
                return ObjectSerializationService.ObjectToXML(MasterEntity);
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
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
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

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M0028_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        MC.PARTY_LIST = reader.Read<STD_PARTY>().ToList();

                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();

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
                        MC.AccountingGroupList = _AccountingGroup.ToList();

                        var _ReconAccountList = reader.Read<ACC_M003_P>().ToList();
                        MC.ReconAccountList = _ReconAccountList.ToList();

                        var _BusinessPlace = reader.Read<ADM_M003_C_P>().ToList();
                        MC.BusinessPlace = _BusinessPlace.ToList();

                        var _TaxCategory = reader.Read<ACC_M013_A_P>().ToList();
                        MC.TaxCategory = _TaxCategory.ToList();

                        var _AccountGroup = reader.Read<ACC_M013_B_P>().ToList();
                        MC.AccountGroup = _AccountGroup.ToList();

                        //var _BussGroupList = reader.Read<ADM_M028_J_P>().ToList();
                        //MC.BussGroupList = _BussGroupList.ToList();

                        var payTerms = reader.Read<ACC_M007_P>().ToList();
                        MC.PayTerms = payTerms.ToList();

                        MC.TAX_LIST = reader.Read<ACC_M013>().ToList();

                        MC.GROUP_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.SUB_GROUP_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.REGION_LIST = reader.Read<STD_LIST_BE>().ToList();


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
                    else if (RequestOption == "LOAD_BACKFLIP")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "LOAD_PARTY")
                    {
                        MC.PARTY_LIST = reader.Read<STD_PARTY>().ToList();
                    }
                }
                return ObjectSerializationService.ObjectToXML(MC);
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
}
