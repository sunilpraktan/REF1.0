using Dapper;
using Reflection.BusinessEntity;
using Reflection.EF;
using Reflection.EF.Settings;
using Reflection.EF.Admin;
using Reflection.EF.CRM.ReportEntityCRM;
using Reflection.EF.SCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Reflection.EF.Finance;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    public class UserVerificationBL : ReflectionBusinessLogic
    {
        private static string connectionString;
        static int obj = 0;
        ADM_M010 aDM_M010 = new ADM_M010();
        public UserVerificationBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public UserVerificationBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string Request)
        {
            string strData = "";
            MContext_Authontication MCL = new MContext_Authontication();
            try
            {
                aDM_M010 = (ADM_M010)ObjectSerializationService.XMLToObject(Request, aDM_M010);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    //var reader = conn.QueryMultiple("USER_AUTHORISATION", new { @UserID = aDM_M010.UserId, @Password = aDM_M010.Password, @client = aDM_M010.EmpNm }, commandType: CommandType.StoredProcedure, commandTimeout: 300);
                    var reader = conn.QueryMultiple("SP_USER_AUTHORISATION", new { @request = aDM_M010.user_source1 }, commandType: CommandType.StoredProcedure, commandTimeout: 300);

                    MCL.Authorisations = reader.Read<SYS_AUTH>().ToList();
                    MCL.USER_AUTHORISATIONS = reader.Read<SYS_AUTH>().ToList();
                    MCL.Permissions = reader.Read<SYS_AUTH>().ToList();
                    MCL.UserData = reader.Read<ADM_M010>().ToList();
                    MCL.AccountData = reader.Read<COM_T002_G>().ToList();

                    List<ADM_M003_P> obj = new List<ADM_M003_P>();
                    var compcode = reader.Read<ADM_M003_P>().ToList();
                    obj = compcode.ToList();

                    MCL.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                    MCL.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                    MCL.ADM_M002_List = reader.Read<ADM_M002>().ToList();
                    MCL.ADM_M003_List = reader.Read<ADM_M003>().ToList();
                    MCL.StorageLocation = reader.Read<MM_M001>().ToList();

                    if (obj.Count > 0)
                    {
                        MCL.comp_code = obj[0].comp_code;
                        MCL.location_Id = obj[0].location_Id;
                        MCL.so_code = obj[0].so_code;
                        MCL.sg_code = obj[0].sg_code;
                        MCL.po_code = obj[0].po_code;
                        MCL.pg_code = obj[0].pg_code;
                        MCL.EmpId = obj[0].EmpId;
                        MCL.EmpName = obj[0].EmpName;
                        MCL.EmpEmailId = obj[0].EmpEmailId;
                        MCL.store_code = obj[0].store_code;
                    }
                    MCL.SalesOrganisation = reader.Read<ADM_M001_A_P>().ToList();
                    MCL.SalesGroup = reader.Read<ADM_M001_H_P>().ToList();
                    MCL.PurchasOrganisation = reader.Read<ADM_M001_M_P>().ToList();
                    MCL.PurchaseGroup = reader.Read<ADM_M001_P_P>().ToList();
                    MCL.UserLevelSetting = reader.Read<UserLevelSettings>().ToList();
                    MCL.Popup_alerts = reader.Read<SYS_M018>().ToList();
                    MCL.Setting = reader.Read<SYS_C005>().ToList();
                    MCL.RoundupMethods = reader.Read<SYS_C006_A>().ToList();
                    MCL.FieldFormats = reader.Read<SYS_C005>().ToList();
                    MCL.CurrencyList = reader.Read<ADM_M037>().ToList();
                    MCL.MODULE_LIST = reader.Read<ADM_S0001>().ToList();

                    strData = ObjectSerializationService.ObjectToXML(MCL);
                }
                return strData;
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
            //return strValue;
        }

    }
    public class MContext_Authontication
    {
        public List<ADM_S0001> MODULE_LIST { get; set; }
        public List<ADM_M0002> COMPANY_LIST { get; set; }
        public List<ADM_M0003> LOCATION_LIST { get; set; }
        public List<SYS_AUTH> USER_AUTHORISATIONS { get; set; }
        public List<SYS_AUTH> Authorisations { get; set; }
        public List<SYS_AUTH> Permissions { get; set; }// Create, Modify, View.....etc
        public List<ADM_M010> UserData { get; set; }
        public List<COM_T002_G> AccountData { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string EmpId { get; set; }
        public string EmpEmailId { get; set; }
        public string EmpName { get; set; }
        public string store_code { get; set; }
        public List<ADM_M002> ADM_M002_List { get; set; }
        public List<ADM_M003> ADM_M003_List { get; set; }
        public List<MM_M001> StorageLocation { get; set; }

        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public List<ADM_M001_A_P> SalesOrganisation { get; set; }
        public List<ADM_M001_P_P> PurchaseGroup { get; set; }
        public List<ADM_M001_M_P> PurchasOrganisation { get; set; }
        public List<UserLevelSettings> UserLevelSetting { get; set; }
        public List<SYS_M018> Popup_alerts { get; set; }
        public List<ADM_M037> CurrencyList { get; set; }

        //G/L Account Determination preload data start
        public List<ACC_M003_D> ACC_M003_D_List { get; set; }
        public List<ACC_M003_E> ACC_M003_E_List { get; set; }
        public List<ACC_M003_F> ACC_M003_F_List { get; set; }
        public List<ACC_M003_G> ACC_M003_G_List { get; set; }
        public List<ACC_M003_X_Variant> Account_Variant_Mov_Type { get; set; }
        public List<ACC_M003_Y_Acc_Determination> GL_Acc_Determination_Material { get; set; }
        public List<ACC_M003_N> ACC_M003_N_List { get; set; }
        public List<ACC_M003_S2> ACC_M003_S2_List { get; set; }
        public List<ACC_M003_Y_Acc_Determination> GL_Acc_Determination_Application { get; set; }
        public List<ACC_M003_Q> ACC_M003_Q_List { get; set; }
        //G/L Account Determination preload data End
        public List<SYS_C005> Setting { get; set; }
        public List<SYS_C006_A> RoundupMethods { get; set; }
        public List<SYS_C005> FieldFormats { get; set; }
    }
}
