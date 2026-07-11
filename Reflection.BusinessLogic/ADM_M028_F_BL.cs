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
    public class ADM_M028_F_BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        MultipleContext_ADM_M028_F MC = new MultipleContext_ADM_M028_F();

        ADM_M028_F MasterEntity = new ADM_M028_F();

        public ADM_M028_F_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public ADM_M028_F_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M028_F_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //Master Data
                    var Master = reader.Read<ADM_M028_F>().ToList();
                    MC.MasterData = Master.ToList();
                    if (MC.MasterData.Count > 0)
                    {
                        MasterEntity = MC.MasterData[0];
                    }

                    //Detail Data
                    var Detail = reader.Read<ADM_M028_G>().ToList();
                    MC.DetailData = Detail.ToList();

                    //BackFlip Data
                    var dataGrid = reader.Read<ADM_M028_F_BackFlip>().ToList();
                    MC.BackFlipEntity = dataGrid.ToList();

                    MasterEntity.XmlDataDocument_ADM_M028_G = ObjectSerializationService.ObjectToXML(MC.DetailData);
                    MasterEntity.XmlDataDocument_ADM_M028_F_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
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
                    var reader = conn.QueryMultiple("ADM_M028_F_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //Master Data
                    var Master = reader.Read<ADM_M028_F>().ToList();
                    MC.MasterData = Master.ToList();
                    if (MC.MasterData.Count > 0)
                    {
                        MasterEntity = MC.MasterData[0];
                    }

                    //Detail Data
                    var Detail = reader.Read<ADM_M028_G>().ToList();
                    MC.DetailData = Detail.ToList();

                    //BackFlip Data
                    var dataGrid = reader.Read<ADM_M028_F_BackFlip>().ToList();
                    MC.BackFlipEntity = dataGrid.ToList();

                    MasterEntity.XmlDataDocument_ADM_M028_G = ObjectSerializationService.ObjectToXML(MC.DetailData);
                    MasterEntity.XmlDataDocument_ADM_M028_F_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
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
        
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_ADM_M028_F MC = new MultipleContext_ADM_M028_F();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M028_F_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {

                        var BackFlipEntity = reader.Read<ADM_M028_F_BackFlip>().ToList();
                        MC.BackFlipEntity = BackFlipEntity.ToList();

                        var _PartyType = reader.Read<ADM_M028_B_P>().ToList();
                        MC.PartyType = _PartyType.ToList();

                        var _Group = reader.Read<ADM_M028_A_P>().ToList();
                        MC.Group = _Group.ToList();

                        var _Country = reader.Read<ADM_M012_P>().ToList();
                        MC.Country = _Country.ToList();

                        var _State = reader.Read<ADM_M013_P>().ToList();
                        MC.State = _State.ToList();

                        var _Salutation = reader.Read<ADM_M050_P>().ToList();
                        MC.Salutation = _Salutation.ToList();

                        var _Departments = reader.Read<ADM_M025_P>().ToList();
                        MC.Department = _Departments.ToList();

                        var _Designations = reader.Read<ADM_M026_P>().ToList();
                        MC.Designation = _Designations.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var MasterEntity = reader.Read<ADM_M028_F>().ToList();
                        MC.MasterData = MasterEntity.ToList();

                        var DetailEntity = reader.Read<ADM_M028_G>().ToList();
                        MC.DetailData = DetailEntity.ToList();
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
    public class MultipleContext_ADM_M028_F
    {
        public List<ADM_M028_F_BackFlip> BackFlipEntity { get; set; }
        public List<ADM_M028_F> MasterData { get; set; }
        public List<ADM_M028_G> DetailData { get; set; }
        public List<ADM_M028_B_P> PartyType { get; set; }
        public List<ADM_M028_A_P> Group { get; set; }
        public List<ADM_M012_P> Country { get; set; }
        public List<ADM_M013_P> State { get; set; }
        public List<ADM_M025_P> Department { get; set; }
        public List<ADM_M026_P> Designation { get; set; }
        public List<ADM_M050_P> Salutation { get; set; }
    }
    public class ADM_M028_F_BackFlip
    {
        public string party_id { get; set; }
        public int id { get; set; }
        public string party_name { get; set; }
        public string abbreviation { get; set; }
        public string location { get; set; }
        public string party_type { get; set; }
        public string party_group { get; set; }
        public string buss_type { get; set; }
        public string phone_no { get; set; }
        public string phone_ext { get; set; }
        public string fax_no { get; set; }
        public string email_id { get; set; }
        public string webside { get; set; }
        public Nullable<int> sr_no { get; set; }
        public string address_type { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string land_mark { get; set; }
        public string city { get; set; }
        public string country_code { get; set; }
        public string state_code { get; set; }
        public string pin { get; set; }
        public string acc_group { get; set; }
        public string region { get; set; }
        public string corr_reg_no { get; set; }
        public string gst_reg_no { get; set; }
        public string cust_type { get; set; }
        public string tax_lassification { get; set; }
    }
}
