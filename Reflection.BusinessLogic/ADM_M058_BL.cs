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
    public class ADM_M058_BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        MultipleContext_ADM_M058 MC = new MultipleContext_ADM_M058();

        ADM_M058 MasterEntity = new ADM_M058();

        public ADM_M058_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public ADM_M058_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M058_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //Master Data
                    var _MasterData = reader.Read<ADM_M058>().ToList();
                    MC.MasterData = _MasterData.ToList();
                    if (MC.MasterData.Count > 0)
                    {
                        MasterEntity = MC.MasterData[0];
                    }

                    //Detail Data
                    var _DetailData = reader.Read<ADM_M058_A>().ToList();
                    MC.DetailData = _DetailData.ToList();

                    //BackFlip Data
                    var _BackFlipEntity = reader.Read<ADM_M058_BackFlip>().ToList();
                    MC.BackFlipEntity = _BackFlipEntity.ToList();
                
                    MasterEntity.XmlDataDocument_ADM_M058_A = ObjectSerializationService.ObjectToXML(MC.DetailData);
                    MasterEntity.XmlDataDocument_ADM_M058_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
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
                    var reader = conn.QueryMultiple("ADM_M058_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //Master Data
                    var _MasterData = reader.Read<ADM_M058>().ToList();
                    MC.MasterData = _MasterData.ToList();
                    if (MC.MasterData.Count > 0)
                    {
                        MasterEntity = MC.MasterData[0];
                    }

                    //Detail Data
                    var _DetailData = reader.Read<ADM_M058_A>().ToList();
                    MC.DetailData = _DetailData.ToList();

                    //BackFlip Data
                    var _BackFlipEntity = reader.Read<ADM_M058_BackFlip>().ToList();
                    MC.BackFlipEntity = _BackFlipEntity.ToList();

                    MasterEntity.XmlDataDocument_ADM_M058_A = ObjectSerializationService.ObjectToXML(MC.DetailData);
                    MasterEntity.XmlDataDocument_ADM_M058_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
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
            MultipleContext_ADM_M058 MC = new MultipleContext_ADM_M058();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M058_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _BackFlipEntity = reader.Read<ADM_M058_BackFlip>().ToList();
                        MC.BackFlipEntity = _BackFlipEntity.ToList();

                        var _Unit = reader.Read<ADM_M038_C_P>().ToList();
                        MC.Unit = _Unit.ToList();

                        var _Item = reader.Read<ADM_M022_P>().ToList();
                        MC.Item = _Item.ToList();
                       
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var _MasterData = reader.Read<ADM_M058>().ToList();
                        MC.MasterData = _MasterData.ToList();

                        var _DetailData = reader.Read<ADM_M058_A>().ToList();
                        MC.DetailData = _DetailData.ToList();
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
    public class MultipleContext_ADM_M058
    {
        public List<ADM_M058_BackFlip> BackFlipEntity { get; set; }
        public List<ADM_M058> MasterData { get; set; }
        public List<ADM_M058_A> DetailData { get; set; }        
        public List<ADM_M038_C_P> Unit { get; set; }
        public List<ADM_M022_P> Item { get; set; }        
    }
    public class ADM_M058_BackFlip
    {
        public string group_code { get; set; }
        public string group_name { get; set; }
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
    }
}
