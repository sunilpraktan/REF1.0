using Reflection.EF;
using Reflection.EF.Communication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class COM_T002BL : ReflectionBusinessLogic
    {       
        private static string connectionString;
        public COM_T002BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public COM_T002BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                Multiple_Complex_COM_T002 MC = new Multiple_Complex_COM_T002();
                MC = (Multiple_Complex_COM_T002)ObjectSerializationService.XMLToObject(Request, MC);
                string Request1 = ObjectSerializationService.ObjectToXML(MC.followersMessagesList[0]);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("COM_T002_AInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var addedFollower = reader.Read<COM_T002_B_PopUp>().ToList();
                    MC.documentFollowersList = addedFollower.ToList();

                    var Msg = reader.Read<COM_T002_A_PopUp>().ToList();
                    MC.documentMessagesList = Msg.ToList();
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
                    var reader = conn.QueryMultiple("COM_T002C_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    COM_T002_A_PopUp cOM_T002_A_PopUp = new COM_T002_A_PopUp();
                    var Msg = reader.Read<COM_T002_A_PopUp>().ToList();
                    if (Msg.Count > 0)
                    {
                        cOM_T002_A_PopUp = Msg[0];
                    }

                    string strReturnData = ObjectSerializationService.ObjectToXML(cOM_T002_A_PopUp);
                    return strReturnData;
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
        public string Delete(string Request)
        {
            try
            {
                COM_T002_B_PopUp cOM_T002_B_PopUp = new COM_T002_B_PopUp();
                string strReturnData;
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("COM_T002B_Delete", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var Msg = reader.Read<COM_T002_B_PopUp>().ToList();
                    if (Msg.Count > 0)
                    { strReturnData = "1"; }
                    else
                    { strReturnData = "0"; }
                }
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

        //public string GetData()
        //{
        //    try
        //    {
        //        Multiple_Complex_COM_T002 CMC2 = new Multiple_Complex_COM_T002();
        //        //var cmd = dbContext.Database.Connection.CreateCommand();
        //        //cmd.CommandText = "COM_T002_LoadAll";
        //        //cmd.CommandType = CommandType.StoredProcedure;                
        //        //dbContext.Database.Connection.Open();
        //        //var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        //    //var CompanyMaster2 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<COM_T002_A_PopUp>(reader);
        //        //    //CMC2.DocumentMessagesList = CompanyMaster2.ToList();
        //        //    reader.NextResult();
        //        //    //var followerlisttoadd = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<COM_T002_B_PopUp>(reader);
        //        //    //CMC2.documentFollowersList = followerlisttoadd.ToList();
        //        //    reader.NextResult();
        //        //    var followerlist = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M024_PopUp_FollowerListToadd>(reader);
        //        //    CMC2.FollowerListToadd = followerlist.ToList();
        //        //if (!reader.Read())
        //        //{
        //        //    reader.Close();
        //        //}
        //        string strData = ObjectSerializationService.ObjectToXML(CMC2);
        //        return strData;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new CreateException(ex.ErrorCode, ex.Message, ex);
        //    }
        //    catch (DivideByZeroException ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //}
        public class Multiple_Complex_COM_T002
        {
            public List<COM_T002_A> followersMessagesList { get; set; }
            public List<COM_T002_A_PopUp> documentMessagesList { get; set; }
            public List<COM_T002_B_PopUp> documentFollowersList { get; set; }
            public List<ADM_M024_PopUp_FollowerListToadd> FollowerListToadd { get; set; }            
        }   
    }  
}
