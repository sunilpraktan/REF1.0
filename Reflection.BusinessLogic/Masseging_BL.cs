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
    public class Masseging_BL : ReflectionBusinessLogic
    {      
        private static string connectionString;
        public Masseging_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public Masseging_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MultipleContext_Masseging MC = new MultipleContext_Masseging();
                MC = (MultipleContext_Masseging)ObjectSerializationService.XMLToObject(Request, MC);
                string Request1 = ObjectSerializationService.ObjectToXML(MC.ComposedMassege[0]);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("COM_T002_H_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                }
                string strReturnData ="" ;//ObjectSerializationService.ObjectToXML(aDM_M034);
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
        public string GetData(string Request, string strType)
        {
            try
            {
                MultipleContext_Masseging MC = new MultipleContext_Masseging();

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("Msg_LoadAll", new
                    {
                        @Request = Request,
                        @check = strType
                    }, commandType: CommandType.StoredProcedure);

                    if (strType == "LoadAll")
                    {
                        var m = reader.Read<Msg_LoadAll_Result>().ToList();
                        MC.MessagesList = m.ToList();

                        var FollowerListToadd1 = reader.Read<ADM_M024_PopUp_FollowerListToadd>().ToList();
                        MC.FollowerListToadd = FollowerListToadd1.ToList();
                    }
                    else if (strType == "LoadInboxDetails")
                    {
                        var m = reader.Read<Msg_LoadAll_Result>().ToList();
                        MC.MessagesList = m.ToList();
                    }
                    else if (strType == "LoadToDoDetails")
                    {
                        var m = reader.Read<Msg_LoadAll_Result>().ToList();
                        MC.MessagesList = m.ToList();
                    }
                    else if (strType == "LoadTomeDetails")
                    {
                        //var m = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<Msg_LoadAll_Result>(reader);
                        //MC.MessagesList = m.ToList();
                    }
                }
                string strData = ObjectSerializationService.ObjectToXML(MC);           
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
        }
    }
    public class MultipleContext_Masseging
    {
        public List<Msg_LoadAll_Result> MessagesList { get; set; }
        public List<COM_T002_A> ComposedMassege { get; set; }
        public List<ADM_M024_PopUp_FollowerListToadd> FollowerListToadd { get; set; }
    }
}
