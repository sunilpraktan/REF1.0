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
    public class HRM_M016_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_HRM_M016 MC = new MultipleContext_HRM_M016();
        HRM_M016 MasterEntity = new HRM_M016();

        public HRM_M016_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public HRM_M016_BL()
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
                    var reader = conn.QueryMultiple("HRM_M016_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _BackFlipEntity = reader.Read<HRM_M016_BackFlip>().ToList();
                        MC.BackFlipEntity = _BackFlipEntity.ToList();

                        var _StatusList = reader.Read<ADM_M0013>().ToList();
                        MC.StatusList = _StatusList.ToList();
                   
                        var _ControlList = reader.Read<SYS_M028_P>().ToList();
                        MC.ControlList = _ControlList.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var _EquipmentList = reader.Read<HRM_M016>().ToList();
                        MC.EquipmentList = _EquipmentList.ToList();

                        var _ControlDescList = reader.Read<HRM_M016_A>().ToList();
                        MC.ControlDescList = _ControlDescList.ToList();
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
            HRM_M016 MasterEntity = new HRM_M016();
            MultipleContext_HRM_M016 MC = new MultipleContext_HRM_M016();

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("HRM_M016_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _EquipmentList = reader.Read<HRM_M016>().ToList();
                    MC.EquipmentList = _EquipmentList.ToList();
                    if (MC.EquipmentList.Count > 0)
                    {
                        MasterEntity = MC.EquipmentList[0];
                    }

                    //Detail Data
                    var _ControlDescList = reader.Read<HRM_M016_A>().ToList();
                    MC.ControlDescList = _ControlDescList.ToList();

                    //BackFlip Data
                    var _BackFlipEntity = reader.Read<HRM_M016_BackFlip>().ToList();
                    MC.BackFlipEntity = _BackFlipEntity.ToList();

                    MasterEntity.XmlDataDocument_HRM_M016_A = ObjectSerializationService.ObjectToXML(MC.ControlDescList);
                    MasterEntity.XmlDataDocument_HRM_M016_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);

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
            HRM_M016 MasterEntity = new HRM_M016();
            MultipleContext_HRM_M016 MC = new MultipleContext_HRM_M016();

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("HRM_M016_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _EquipmentList = reader.Read<HRM_M016>().ToList();
                    MC.EquipmentList = _EquipmentList.ToList();
                    if (MC.EquipmentList.Count > 0)
                    {
                        MasterEntity = MC.EquipmentList[0];
                    }

                    //Detail Data
                    var _ControlDescList = reader.Read<HRM_M016_A>().ToList();
                    MC.ControlDescList = _ControlDescList.ToList();

                    //BackFlip Data
                    var _BackFlipEntity = reader.Read<HRM_M016_BackFlip>().ToList();
                    MC.BackFlipEntity = _BackFlipEntity.ToList();

                    MasterEntity.XmlDataDocument_HRM_M016_A = ObjectSerializationService.ObjectToXML(MC.ControlDescList);
                    MasterEntity.XmlDataDocument_HRM_M016_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);

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
    public class HRM_M016_BackFlip
    {
        public string equ_id { get; set; }
        public string equ_name { get; set; }
        public string dev_code { get; set; }
        public string t_status { get; set; }
    }
    public class MultipleContext_HRM_M016
    {
        public List<HRM_M016> EquipmentList { get; set; }
        public List<HRM_M016_A> ControlDescList { get; set; }
        public List<HRM_M016_BackFlip> BackFlipEntity { get; set; }
        public List<ADM_M0013> StatusList { get; set; }
        public List<SYS_M028_P> ControlList { get; set; }
    }
}
