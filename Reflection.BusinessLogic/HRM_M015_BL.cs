using Dapper;
using Reflection.EF;
using Reflection.EF.ADM;
using Reflection.EF.Admin;
using Reflection.EF.HRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class HRM_M015_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_HRM_M015 MC = new MultipleContext_HRM_M015();
        HRM_M015 MasterEntity = new HRM_M015();

        public HRM_M015_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public HRM_M015_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("HRM_M015_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _BackFlipEntity = reader.Read<HRM_M015_BackFlip>().ToList();
                        MC.BackFlipEntity = _BackFlipEntity.ToList();

                        var _statuslist= reader.Read<ADM_M0013>().ToList();
                        MC.StatusList = _statuslist.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var _MasterData = reader.Read<HRM_M015>().ToList();
                        MC.MasterData = _MasterData.ToList();

                        var _DetailData = reader.Read<HRM_M015_A>().ToList();
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

        public string Insert(string Request)
        {

           
            HRM_M015 MasterEntity = new HRM_M015();
            MultipleContext_HRM_M015 MC = new MultipleContext_HRM_M015();

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("HRM_M015_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _MasterData = reader.Read<HRM_M015>().ToList();
                    MC.MasterData = _MasterData.ToList();
                    if (MC.MasterData.Count > 0)
                    {
                        MasterEntity = MC.MasterData[0];
                    }

                    //Detail Data
                    var _DetailData = reader.Read<HRM_M015_A>().ToList();
                    MC.DetailData = _DetailData.ToList();

                    //BackFlip Data
                    var _BackFlipEntity = reader.Read<HRM_M015_BackFlip>().ToList();
                    MC.BackFlipEntity = _BackFlipEntity.ToList();

                    MasterEntity.XmlDataDocument_HRM_M015_A = ObjectSerializationService.ObjectToXML(MC.DetailData);
                    MasterEntity.XmlDataDocument_HRM_M015_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
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
                    var reader = conn.QueryMultiple("HRM_M015_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //Master Data
                    var _MasterData = reader.Read<HRM_M015>().ToList();
                    MC.MasterData = _MasterData.ToList();
                    if (MC.MasterData.Count > 0)
                    {
                        MasterEntity = MC.MasterData[0];
                    }

                    //Detail Data
                    var _DetailData = reader.Read<HRM_M015_A>().ToList();
                    MC.DetailData = _DetailData.ToList();

                    //BackFlip Data
                    var _BackFlipEntity = reader.Read<HRM_M015_BackFlip>().ToList();
                    MC.BackFlipEntity = _BackFlipEntity.ToList();

                    MasterEntity.XmlDataDocument_HRM_M015_A = ObjectSerializationService.ObjectToXML(MC.DetailData);
                    MasterEntity.XmlDataDocument_HRM_M015_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
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

    }
    public class MultipleContext_HRM_M015
    {
        public List<HRM_M015_BackFlip> BackFlipEntity { get; set; }
        public List<HRM_M015> MasterData { get; set; }
        public List<HRM_M015_A> DetailData { get; set; }
        public List<ADM_M0013> StatusList { get; set; }
    }

    public class HRM_M015_BackFlip
    {
        public string ter_id { get; set; }
        public string ter_desc { get; set; }
        public string ter_shrt_nm { get; set; }
        public string ter_location { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string t_name { get; set; }
    }
}
