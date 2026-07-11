using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.Settings;

namespace Reflection.BusinessLogic
{
    public class SYS_S001BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        UserLevelSettings MasterEntity = new UserLevelSettings();
        MultipleContext_UserLevelSettings MC = new MultipleContext_UserLevelSettings();
        public SYS_S001BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public SYS_S001BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("UserPersonalisation", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var user = reader.Read<UserLevelSettings>().ToList();
                    List<UserLevelSettings> User = user.ToList();
                    if (User.Count > 0)
                    {
                        MasterEntity = User[0];
                    }
                    var SettingEntity = reader.Read<SYS_C005>().ToList();

                    var DocumentEntity = reader.Read<SYS_C005>().ToList();

                    MasterEntity.XmlDataDocument_SET_M005 = ObjectSerializationService.ObjectToXML(DocumentEntity);
                    MasterEntity.XmlDataDocument_SYS_C005 = ObjectSerializationService.ObjectToXML(SettingEntity);

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
                    var reader = conn.QueryMultiple("UserPersonalisation", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var user = reader.Read<UserLevelSettings>().ToList();
                    List<UserLevelSettings> User = user.ToList();
                    if (User.Count > 0)
                    {
                        MasterEntity = User[0];
                    }

                    var SettingEntity = reader.Read<SYS_C005>().ToList();

                    var DocumentEntity = reader.Read<SYS_C005>().ToList();

                    MasterEntity.XmlDataDocument_SYS_C005 = ObjectSerializationService.ObjectToXML(SettingEntity);
                    MasterEntity.XmlDataDocument_SET_M005 = ObjectSerializationService.ObjectToXML(DocumentEntity);
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
                    int intOut = 0; //conn.Execute("UserPersonalisation", new { @Request = Request }, commandType: CommandType.StoredProcedure);
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
                    if (RequestOption == "RESET_PASSWORD")
                    {
                        var reader = conn.QueryMultiple("SP_RESET_PASSWORD", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        var masterlist = reader.Read<SYS_AUTH>().ToList();
                        MC.AUTH_LIST = masterlist.ToList();

                    }
                    else
                    {
                        var reader = conn.QueryMultiple("UserLevelSettingsLoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var masterlist = reader.Read<UserLevelSettings>().ToList();
                            MC.MasterEntity = masterlist.ToList();

                            var them = reader.Read<SYS_C001_P>().ToList();
                            MC.Themes = them.ToList();

                            var lang = reader.Read<SYS_C002>().ToList();
                            MC.Language = lang.ToList();

                            var dates = reader.Read<SYS_C007>().ToList();
                            MC.DateFormats = dates.ToList();

                            var sett = reader.Read<SYS_C005>().ToList();
                            MC.SettingEntity = sett.ToList();

                            var rndup = reader.Read<SYS_C006>().ToList();
                            MC.RoundUpMethod = rndup.ToList();

                            var doccat = reader.Read<SYS_C011>().ToList();
                            MC.DocCategory = doccat.ToList();

                            var docfield = reader.Read<SYS_D001>().ToList();
                            MC.DocumentField = docfield.ToList();

                            var docentity = reader.Read<SYS_C005>().ToList();
                            MC.DocumentEntity = docentity.ToList();
                        }
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
        public class MultipleContext_UserLevelSettings
        {
            public List<SYS_C001_P> Themes { get; set; }
            public List<SYS_C002> Language { get; set; }
            public List<SYS_C007> DateFormats { get; set; }
            public List<SYS_C005> SettingEntity { get; set; }
            public List<SYS_C006> RoundUpMethod { get; set; }
            public List<SYS_C011> DocCategory { get; set; }
            public List<SYS_D001> DocumentField { get; set; }
            public List<UserLevelSettings> MasterEntity { get; set; }
            public List<SYS_C005> DocumentEntity { get; set; }
            public List<SYS_AUTH> AUTH_LIST { get; set; }
        }
    }
}