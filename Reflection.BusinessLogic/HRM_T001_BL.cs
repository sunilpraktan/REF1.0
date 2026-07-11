using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Reflection.EF;
using Reflection.EF.Admin;
using Reflection.EF.HRMS;
using System.Data;
using System.Data.SqlClient;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    public class HRM_T001_BL : ReflectionBusinessLogic
    {
        private static String connectionString;
        HRM_T001 MasterEntity = new HRM_T001();
        MultipleContext_HRM_T001 MC = new MultipleContext_HRM_T001();


        public HRM_T001_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public HRM_T001_BL()
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
                    var reader = conn.QueryMultiple("HRM_T001_GET", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _BackFlipEntity = reader.Read<HRM_T001_BackFlip>().ToList();
                        MC.BackFlipEntity = _BackFlipEntity.ToList();

                        var _ReasonList = reader.Read<HRM_M009_P>().ToList();
                        MC.ReasonList = _ReasonList.ToList();

                        var _SubReasonList = reader.Read<HRM_M009_A_P>().ToList();
                        MC.SubReasonList = _SubReasonList.ToList();

                        var _DocTypeList = reader.Read<SYS_M022_P>().ToList();
                        MC.DocTypeList = _DocTypeList.ToList();

                        var _DocCategoryList = reader.Read<SYS_M021_P>().ToList();
                        MC.DocCategoryList = _DocCategoryList.ToList();
                     
                        var _RequestTypeList = reader.Read<HRM_M008_P>().ToList();
                        MC.RequestTypeList = _RequestTypeList.ToList();

                        var _SubRequestList = reader.Read<HRM_M008_A_P>().ToList();
                        MC.SubRequestList = _SubRequestList.ToList();

                        var _StatusList = reader.Read<ADM_M0013>().ToList();
                        MC.StatusList = _StatusList.ToList();

                        var _ObjectTypeList = reader.Read<SYS_M034_P>().ToList();
                        MC.ObjectTypeList = _ObjectTypeList.ToList();

                        var _DayTypeList = reader.Read<SYS_M033_P>().ToList();
                        MC.DayTypeList = _DayTypeList.ToList();               
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var _RequestList = reader.Read<HRM_T001>().ToList();
                        MC.RequestList = _RequestList.ToList();

                        var _DetailList = reader.Read<HRM_T001_A>().ToList();
                        MC.DetailList = _DetailList.ToList();

                        //var _HistoryList = reader.Read<HRM_T001_B>().ToList();
                        //MC.HistoryList = _HistoryList.ToList();
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

            string strReturnData = "";
            HRM_T001 MasterEntity = new HRM_T001();
            MultipleContext_HRM_T001 MC = new MultipleContext_HRM_T001();

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("HRM_T001_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _RequestList = reader.Read<HRM_T001>().ToList();
                    MC.RequestList = _RequestList.ToList();
                    if (MC.RequestList.Count > 0)
                    {
                        MasterEntity = MC.RequestList[0];
                    }

                    //Detail Data
                    var _DetailList = reader.Read<HRM_T001_A>().ToList();
                    MC.DetailList = _DetailList.ToList();

                    //BackFlip Data
                    var _BackFlipEntity = reader.Read<HRM_T001_BackFlip>().ToList();
                    MC.BackFlipEntity = _BackFlipEntity.ToList();

                    MasterEntity.XmlDataDocument_HRM_T001_A = ObjectSerializationService.ObjectToXML(MC.DetailList);
                    //MasterEntity.XmlDataDocument_HRM_T001_A = ObjectSerializationService.ObjectToXML(MC.HistoryList);
                    MasterEntity.XmlDataDocument_HRM_T001_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
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

            string strReturnData = "";
            HRM_T001 MasterEntity = new HRM_T001();
            MultipleContext_HRM_T001 MC = new MultipleContext_HRM_T001();

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("HRM_T001_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _RequestList = reader.Read<HRM_T001>().ToList();
                    MC.RequestList = _RequestList.ToList();
                    if (MC.RequestList.Count > 0)
                    {
                        MasterEntity = MC.RequestList[0];
                    }

                    //Detail Data
                    var _DetailList = reader.Read<HRM_T001_A>().ToList();
                    MC.DetailList = _DetailList.ToList();

                    //BackFlip Data
                    var _BackFlipEntity = reader.Read<HRM_T001_BackFlip>().ToList();
                    MC.BackFlipEntity = _BackFlipEntity.ToList();

                    MasterEntity.XmlDataDocument_HRM_T001_A = ObjectSerializationService.ObjectToXML(MC.DetailList);
                    MasterEntity.XmlDataDocument_HRM_T001_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
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
    public class MultipleContext_HRM_T001
    {
        public List<HRM_T001> RequestList { get; set; }
        public List<HRM_T001_A> DetailList { get; set; }
       // public List<HRM_T001_B> HistoryList { get; set; }
        public List<HRM_T001_BackFlip> BackFlipEntity { get; set; }
        public List<HRM_M009_P> ReasonList { get; set; }
        public List<HRM_M009_A_P> SubReasonList { get; set; }
        public List<SYS_M022_P> DocTypeList { get; set; }
        public List<SYS_M021_P> DocCategoryList { get; set; }  
        public List<HRM_M008_P> RequestTypeList { get; set; }
        public List<HRM_M008_A_P> SubRequestList { get; set; }
        public List<ADM_M0013> StatusList { get; set; }
        public List<SYS_M033_P> DayTypeList { get; set; }
        public List<SYS_M034_P>ObjectTypeList { get; set; }

    }
    public class HRM_T001_BackFlip
    {
        public string requestid { get; set; }
        public string request_type { get; set; }
        public string req_type_desc { get; set; }
        public string obj_type { get; set; }
        public string t_name { get; set; }
    }
}