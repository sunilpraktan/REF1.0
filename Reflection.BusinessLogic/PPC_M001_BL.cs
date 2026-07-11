using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.CRM;
using Dapper;
using System.Collections.ObjectModel;
using Reflection.EF.HRMS.Production;




namespace Reflection.BusinessLogic
{
    public class PPC_M001_BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        MultipleContext_PPC_M001 MC = new MultipleContext_PPC_M001();

        PPC_M001 MasterEntity = new PPC_M001();

        public PPC_M001_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public PPC_M001_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PPC_M001_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //Master Data
                    var _MasterData = reader.Read<PPC_M001>().ToList();
                    MC.MasterData = _MasterData.ToList();
                    if (MC.MasterData.Count > 0)
                    {
                        MasterEntity = MC.MasterData[0];
                    }                    

                    //BackFlip Data
                    var _BackFlipEntity = reader.Read<PPC_M001_BackFlip>().ToList();
                    MC.BackFlipEntity = _BackFlipEntity.ToList();
                    
                    MasterEntity.XmlDataDocument_PPC_M001_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
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
                    var reader = conn.QueryMultiple("PPC_M001_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //Master Data
                    var _MasterData = reader.Read<PPC_M001>().ToList();
                    MC.MasterData = _MasterData.ToList();
                    if (MC.MasterData.Count > 0)
                    {
                        MasterEntity = MC.MasterData[0];
                    }                    

                    //BackFlip Data
                    var _BackFlipEntity = reader.Read<PPC_M001_BackFlip>().ToList();
                    MC.BackFlipEntity = _BackFlipEntity.ToList();
                    
                    MasterEntity.XmlDataDocument_PPC_M001_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
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
            MultipleContext_PPC_M001 MC = new MultipleContext_PPC_M001();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PPC_M001_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {

                        var _BackFlipEntity = reader.Read<PPC_M001_BackFlip>().ToList();
                        MC.BackFlipEntity = _BackFlipEntity.ToList();

                        var _Company = reader.Read<ADM_M002_P>().ToList();
                        MC.Company = _Company.ToList();

                        var _WCType = reader.Read<PPC_M001_A_P>().ToList();
                        MC.WCType = _WCType.ToList();

                        var _WCSubType = reader.Read<PPC_M001_B_P>().ToList();
                        MC.WCSubType = _WCSubType.ToList();

                        var _Make = reader.Read<ADM_M032_P>().ToList();
                        MC.Make = _Make.ToList();

                        var _Employee = reader.Read<ADM_M024_P>().ToList();
                        MC.Employee = _Employee.ToList();

                        var _WCCategory = reader.Read<PPC_M001_C_P>().ToList();
                        MC.WCCategory = _WCCategory.ToList();

                        var _WCPlace = reader.Read<PPC_M001_D_P>().ToList();
                        MC.WCPlace = _WCPlace.ToList();

                        var _WCCapacity = reader.Read<PPC_M001_E_P>().ToList();
                        MC.WCCapacity = _WCCapacity.ToList();

                        var _WCControlKey = reader.Read<PPC_M001_F_P>().ToList();
                        MC.WCControlKey = _WCControlKey.ToList();

                        var _WCGroup = reader.Read<PPC_M001_G_P>().ToList();
                        MC.WCGroup = _WCGroup.ToList();

                        var _Unit = reader.Read<ADM_M038_B_P>().ToList();
                        MC.Unit = _Unit.ToList();

                        var _Party = reader.Read<ADM_M028_P>().ToList();
                        MC.Party = _Party.ToList();

                        var _Location = reader.Read<ADM_M003_P>().ToList();
                        MC.Location = _Location.ToList();

                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var _MasterData = reader.Read<PPC_M001>().ToList();
                        MC.MasterData = _MasterData.ToList();                        
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

    public class MultipleContext_PPC_M001
    {
        public List<PPC_M001_BackFlip> BackFlipEntity { get; set; }
        public List<ADM_M002_P> Company { get; set; }
        public List<ADM_M032_P> Make { get; set; }
        public List<ADM_M024_P> Employee { get; set; }
        public List<PPC_M001> MasterData { get; set; }
        public List<PPC_M001_A_P> WCType { get; set; }
        public List<PPC_M001_B_P> WCSubType { get; set; }
        public List<PPC_M001_C_P> WCCategory { get; set; }
        public List<PPC_M001_D_P> WCPlace { get; set; }
        public List<PPC_M001_E_P> WCCapacity { get; set; }
        public List<PPC_M001_F_P> WCControlKey { get; set; }
        public List<PPC_M001_G_P> WCGroup { get; set; }
        public List<ADM_M038_B_P> Unit { get; set; }
        public List<ADM_M028_P> Party { get; set; }
        public List<ADM_M003_P> Location { get; set; }
    }

    public class PPC_M001_BackFlip
    {
        public string wc_code { get; set; }
        public string wc_tp_code { get; set; }
        public string wc_stp_code { get; set; }
        public string wc_cat { get; set; }
        public string place { get; set; }
        public string cap_code { get; set; }
        public string control_key { get; set; }
        public string gr_code { get; set; }
        public string location_Id { get; set; }
        public Nullable<System.DateTime> start_dt { get; set; }
        public string machinecode { get; set; }
        public string machinedesc { get; set; }

    }
}
