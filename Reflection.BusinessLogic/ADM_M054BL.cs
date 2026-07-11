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

    public class ADM_M054BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        ADM_M054 MasterEntity = new ADM_M054();
        MultipleContext_ADM_M054 MC = new MultipleContext_ADM_M054();

        public ADM_M054BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M054BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MasterEntity = (ADM_M054)ObjectSerializationService.XMLToObject(Request, MasterEntity);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M054Insert", new { @Request = Request,@Photo = MasterEntity.photo, }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ADM_M054Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var Contact = reader.Read<ADM_M054>().ToList();
                    List<ADM_M054> ContactList = Contact.ToList();
                    if (ContactList.Count > 0)
                    {
                        MasterEntity = ContactList[0];
                    }

                    var Address = reader.Read<ADM_M055>().ToList();
                    MC.AddressEntity = Address.ToList();

                    var Communication = reader.Read<ADM_M057>().ToList();
                    MC.CommunicationEntity = Communication.ToList();

                    MasterEntity.XmlDataDocument_ADM_M055 = ObjectSerializationService.ObjectToXML(MC.AddressEntity);
                    MasterEntity.XmlDataDocument_ADM_M057 = ObjectSerializationService.ObjectToXML(MC.CommunicationEntity);
                    MasterEntity.XmlDataDocument_ADM_M054Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
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
                MasterEntity = (ADM_M054)ObjectSerializationService.XMLToObject(Request, MasterEntity);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M054Update", new { @Request = Request, @Photo = MasterEntity.photo }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ADM_M054Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var Contact = reader.Read<ADM_M054>().ToList();
                    List<ADM_M054> ContactList = Contact.ToList();
                    if (ContactList.Count > 0)
                    {
                        MasterEntity = ContactList[0];
                    }

                    var Address = reader.Read<ADM_M055>().ToList();
                    MC.AddressEntity = Address.ToList();

                    var Communication = reader.Read<ADM_M057>().ToList();
                    MC.CommunicationEntity = Communication.ToList();

                    MasterEntity.XmlDataDocument_ADM_M055 = ObjectSerializationService.ObjectToXML(MC.AddressEntity);
                    MasterEntity.XmlDataDocument_ADM_M057 = ObjectSerializationService.ObjectToXML(MC.CommunicationEntity);
                    MasterEntity.XmlDataDocument_ADM_M054Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
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
                    var reader = conn.QueryMultiple("ADM_M054LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var FlipGridData = reader.Read<ADM_M054Flip>().ToList();
                        MC.DocumentDataFlipGrid = FlipGridData.ToList();

                        var PartyData = reader.Read<ADM_M053_P>().ToList();
                        MC.PartyList = PartyData.ToList();

                        var SalutationData = reader.Read<ADM_M050_P>().ToList();
                        MC.SalutationList = SalutationData.ToList();

                        var DepartmentData = reader.Read<ADM_M025_P>().ToList();
                        MC.DepartmentList = DepartmentData.ToList();

                        var DesignationList = reader.Read<ADM_M026_P>().ToList();
                        MC.DesignationList = DesignationList.ToList();

                        var StateData = reader.Read<ADM_M013_P>().ToList();
                        MC.State = StateData.ToList();

                        var CountryData = reader.Read<ADM_M012_P>().ToList();
                        MC.Country = CountryData.ToList();

                        var TypeData = reader.Read<ADM_M057_A_P>().ToList();
                        MC.TypeList = TypeData.ToList();

                    }
                    else if (RequestOption == "LoadInitialBackFlipData")
                    {
                        var FlipGridData = reader.Read<ADM_M054Flip>().ToList();
                        MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {

                        var MasterData = reader.Read<ADM_M054>().ToList();
                        MC.MasterEntity = MasterData.ToList();

                        var Address = reader.Read<ADM_M055>().ToList();
                        MC.AddressEntity = Address.ToList();

                        var Communication = reader.Read<ADM_M057>().ToList();
                        MC.CommunicationEntity = Communication.ToList();
                    }
                    else if (RequestOption == "Party_Report")
                    {
                        var PartyDetailData = reader.Read<ADM_M054Rpt>().ToList();
                        MC.ADM_M054RptList = PartyDetailData.ToList();

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
        public class MultipleContext_ADM_M054
        {
            public List<ADM_M054Flip> DocumentDataFlipGrid { get; set; }
            public List<ADM_M054> MasterEntity { get; set; }
            public List<ADM_M055> AddressEntity { get; set; }
            public List<ADM_M057> CommunicationEntity { get; set; }
            public List<ADM_M054Rpt> ADM_M054RptList { get; set; }
            public List<ADM_M053_P> PartyList { get; set; }
            public List<ADM_M050_P> SalutationList { get; set; }
            public List<ADM_M025_P> DepartmentList { get; set; }
            public List<ADM_M026_P> DesignationList { get; set; }
            public List<ADM_M013_P> State { get; set; }
            public List<ADM_M012_P> Country { get; set; }
            public List<ADM_M057_A_P> TypeList { get; set; }

        }
    }
}
