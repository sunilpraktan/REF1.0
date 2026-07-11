using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using Reflection.EF.Admin;
using Dapper;


namespace Reflection.BusinessLogic
{
    public class ADM_M010BL : ReflectionBusinessLogic
    {        
        
        private static string connectionString;
        static int obj = 0;
        //ObjectParameter objpara = new ObjectParameter("id", obj);
        ADM_M010 aDM_M010 = new ADM_M010();
        public ADM_M010BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M010BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MultipleContext_ADM_M010 mc = new MultipleContext_ADM_M010();
                aDM_M010 = (ADM_M010)ObjectSerializationService.XMLToObject(Request, aDM_M010);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M010Insert", new
                    {
                        @UserId = aDM_M010.UserId,
                        @UserTypCode = aDM_M010.UserTypCode,
                        @Password = aDM_M010.Password,
                        @Title = aDM_M010.Title,
                        @EmpId = aDM_M010.EmpId,
                        @LogSts = aDM_M010.LogSts,
                        @ValidFrm = aDM_M010.ValidFrm,
                        @ValidTo = aDM_M010.ValidTo,
                        @UserBlkSts = aDM_M010.UserBlkSts,
                        @LockStat = aDM_M010.LockStat,
                        @LockBy = aDM_M010.LockBy,
                        @LockDate = aDM_M010.LockDate,
                        @UnlockBy = aDM_M010.UnlockBy,
                        @UnlockDate = aDM_M010.UnlockDate,
                        @Photo = aDM_M010.Photo,
                        @user_source1 = aDM_M010.user_source1,
                        @user_source2 = aDM_M010.user_source2,
                        @add_by = aDM_M010.add_by,
                        @comp_code = aDM_M010.comp_code,
                        @client = aDM_M010.client,
                        @lang_key = aDM_M010.lang_key,
                        @xdoc = aDM_M010.XmlDataDocument
                    }, commandType: CommandType.StoredProcedure);

                    var User = reader.Read<ADM_M010>().ToList();
                    aDM_M010 = new ADM_M010();
                    mc.Users = User.ToList();

                    var UserDtl = reader.Read<ADM_M010B>().ToList();
                    aDM_M010 = new ADM_M010();
                    mc.UserDtls = UserDtl.ToList();

                    aDM_M010 = mc.Users[0];
                    aDM_M010.XmlDataDocument = ObjectSerializationService.ObjectToXML(mc.UserDtls);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M010);
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
                ADM_M010 aDM_M010 = new ADM_M010();

                aDM_M010 = (ADM_M010)ObjectSerializationService.XMLToObject(Request, aDM_M010);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M010Update", new
                    {
                        @UserId = aDM_M010.UserId,
                        @user_type = aDM_M010.user_type,
                        @Password = aDM_M010.Password,
                        @Title = aDM_M010.Title,
                        @EmpId = aDM_M010.EmpId,
                        @LogSts = aDM_M010.LogSts,
                        @ValidFrm = aDM_M010.ValidFrm,
                        @ValidTo = aDM_M010.ValidTo,
                        @UserBlkSts = aDM_M010.UserBlkSts,
                        @LockStat = aDM_M010.LockStat,
                        @LockBy = aDM_M010.LockBy,
                        @LockDate = aDM_M010.LockDate,
                        @UnlockBy = aDM_M010.UnlockBy,
                        @UnlockDate = aDM_M010.UnlockDate,
                        @Photo = aDM_M010.Photo,
                        @active=aDM_M010.active,
                        @user_source1 = aDM_M010.user_source1,
                        @user_source2 = aDM_M010.user_source2,
                        @add_by = aDM_M010.add_by,
                        @add_date= aDM_M010.add_date,
                        @editby =aDM_M010.editby,
                        @edit_date= aDM_M010.edit_date,
                        @comp_code = aDM_M010.comp_code,
                        @client = aDM_M010.client,
                        @lang_key = aDM_M010.lang_key,
                        @xdoc = aDM_M010.XmlDataDocument
                    }, commandType: CommandType.StoredProcedure);

                    MultipleContext_ADM_M010 mc = new MultipleContext_ADM_M010();
                    var User = reader.Read<ADM_M010>().ToList();
                    aDM_M010 = new ADM_M010();
                    mc.Users = User.ToList();

                    var UserDtl = reader.Read<ADM_M010B>().ToList();
                    aDM_M010 = new ADM_M010();
                    mc.UserDtls = UserDtl.ToList();
                    if (mc.Users.Count > 0)
                    {
                        aDM_M010 = mc.Users[0];
                    }
                    aDM_M010.XmlDataDocument = ObjectSerializationService.ObjectToXML(mc.UserDtls);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M010);
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
                    int intOut = conn.Execute("ADM_M010Delete", new { @userId = Request }, commandType: CommandType.StoredProcedure);
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
        public string GetData()
        {
            try
            {
                MultipleContext_ADM_M010 MC = new MultipleContext_ADM_M010();
                string strData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M010LoadAll", commandType: CommandType.StoredProcedure);

                    var User = reader.Read<ADM_M010>().ToList();
                    MC.Users = User.ToList();

                    var UserDtl = reader.Read<ADM_M010B>().ToList();
                    MC.UserDtls = UserDtl.ToList();

                    var UserType = reader.Read<ADM_M007_P>().ToList();
                    MC.UserTypes = UserType.ToList();

                    var RoleDat = reader.Read<ADM_M009_P>().ToList();
                    MC.RoleData = RoleDat.ToList();

                    var Employee = reader.Read<ADM_M024_P>().ToList();
                    MC.Employees = Employee.ToList();
                }
                strData = ObjectSerializationService.ObjectToXML(MC);
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
    public class MultipleContext_ADM_M010
    {
        public List<ADM_M010> Users { get; set; }//UserMaster
        public List<ADM_M010B> UserDtls { get; set; }
        public List<ADM_M007_P> UserTypes { get; set; }//UserTypeMaster
        public List<ADM_M009_P> RoleData { get; set; }//RoleMaster
        public List<ADM_M024_P> Employees { get; set; }//Employee_Master 
    }
}
