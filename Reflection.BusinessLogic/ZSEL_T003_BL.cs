using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.CRM;
using Dapper;
using System.Collections.ObjectModel;

namespace Reflection.BusinessLogic
{
    public class ZSEL_T003_BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        MultipleContext_ZSEL_T003 MC = new MultipleContext_ZSEL_T003();

        ZSEL_T003 MasterEntity = new ZSEL_T003();
        public ZSEL_T003_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZSEL_T003_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZSEL_T003_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //Master Data
                    var Master = reader.Read<ZSEL_T003>().ToList();
                    MC.MasterData = Master.ToList();
                    if (MC.MasterData.Count > 0)
                    {
                        MasterEntity = MC.MasterData[0];
                    }

                    //Detail Data
                    var _DetailData = reader.Read<ZSEL_T003>().ToList();
                    MC.DetailData = _DetailData.ToList();

                    //BackFlip Data
                    //var dataGrid = reader.Read<ZSEL_T003_BackFlip>().ToList();
                    //MC.BackFlipEntity = dataGrid.ToList();

                    MasterEntity.XmlDataDocument_ZSEL_T003 = ObjectSerializationService.ObjectToXML(MC.DetailData);
                    //MasterEntity.XmlDataDocument_ZSEL_T003_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
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
            MultipleContext_ZSEL_T003 MC = new MultipleContext_ZSEL_T003();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZSEL_T003_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        //var _BackFlipEntity = reader.Read<ZSEL_T003_BackFlip>().ToList();
                        //MC.BackFlipEntity = _BackFlipEntity.ToList();

                        var _Party = reader.Read<ADM_M028_P>().ToList();
                        MC.Party = _Party.ToList();

                        var _CustomerName = reader.Read<ZSEL_T003_P>().ToList();
                        MC.CustomerName = _CustomerName.ToList();

                        var _HSNCode = reader.Read<ZSEL_T003_A_P>().ToList();
                        MC.HSNCode = _HSNCode.ToList();

                        var _PartyForFilter = reader.Read<ZSEL_T003_P>().ToList();
                        MC.PartyForFilter = _PartyForFilter.ToList();

                        var _BussPlace = reader.Read<ADM_M003_C_P>().ToList();
                        MC.BussPlace = _BussPlace.ToList();
                        
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var _MasterEntity = reader.Read<ZSEL_T003>().ToList();
                        MC.MasterData = _MasterEntity.ToList();

                        var _DetailEntity = reader.Read<ZSEL_T003>().ToList();
                        MC.DetailData = _DetailEntity.ToList();
                    }
                    else if (RequestOption == "LoadMasterRecordFromFilter")
                    {
                        var _BackFlipEntity = reader.Read<ZSEL_T003_BackFlip>().ToList();
                        MC.BackFlipEntity = _BackFlipEntity.ToList();
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

    public class MultipleContext_ZSEL_T003
    {
        public List<ZSEL_T003_BackFlip> BackFlipEntity { get; set; }
        public List<ZSEL_T003> MasterData { get; set; }
        public List<ZSEL_T003> DetailData { get; set; }
        public List<ADM_M028_P> Party { get; set; }
        public List<ZSEL_T003_P> CustomerName { get; set; }
        public List<ZSEL_T003_P> PartyForFilter { get; set; }        
        public List<ZSEL_T003_A_P> HSNCode { get; set; }
        public List<ADM_M003_C_P> BussPlace { get; set; }       
        public List<ACC_M013_P> Tax { get; set; }        
    }

    public class ZSEL_T003_BackFlip
    {
        public string sr_no { get; set; }
        public int id { get; set; }
        public string party_id { get; set; }
        public string cust_name { get; set; }
        public string cust_id { get; set; }
        public string invoice_no { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<decimal> taxable_value { get; set; }
        public string gst_no { get; set; }
        public string gst { get; set; }
        public string cgst { get; set; }
        public string sgst { get; set; }
        public string igst { get; set; }
        public Nullable<decimal> gst_p { get; set; }
        public Nullable<decimal> cgst_p { get; set; }
        public Nullable<decimal> sgst_p { get; set; }
        public Nullable<decimal> igst_p { get; set; }
        public Nullable<decimal> gst_amt { get; set; }
        public Nullable<decimal> cgst_amt { get; set; }
        public Nullable<decimal> sgst_amt { get; set; }
        public Nullable<decimal> igst_amt { get; set; }
        public string hsn_code { get; set; }
        public string buss_place { get; set; }
        public string supply_type { get; set; }
        public string invoice_type { get; set; }
        public string rev_charge { get; set; }
        public string e_comm { get; set; }
        public string section { get; set; }
        public Nullable<decimal> cess_amt { get; set; }
        public string remark { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }

        //Scalar
        public string party_name { get; set; }
    }
}
