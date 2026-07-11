using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ZADM_M013BL : ReflectionBusinessLogic
    {        
        private static string connectionString;
        static int obj = 0;
       
        ZADM_M013 zADM_M013 = new ZADM_M013();

        public ZADM_M013BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZADM_M013BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        #region Insert
        public string Insert(string Request)
        {
            try
            {
                zADM_M013 = (ZADM_M013)ObjectSerializationService.XMLToObject(Request, zADM_M013);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M013Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var machine = reader.Read<ZADM_M013>().ToList();
                    List<ZADM_M013> machineList = machine.ToList();
                    if (machineList.Count > 0)
                    {
                        zADM_M013 = machineList[0];
                    }
                    //else
                    //{
                    //    zADM_M013=new ZADM_M013();
                    //}
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(zADM_M013);
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
        #endregion
        #region Get Data
        public string GetData()
        {
            MultipleContext_ZADM_M013 MC = new MultipleContext_ZADM_M013();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M013LoadAll", commandType: CommandType.StoredProcedure);

                    var MachineMaster =reader.Read<ZADM_M013>().ToList();
                    MC.MachineMaster_1 = MachineMaster.ToList();

                    var GroupCompanyMaster = reader.Read<ADM_M002_PopUp>().ToList();
                    MC.GroupCompanyMaster_1 = GroupCompanyMaster.ToList();

                    var MachineTypeMaster = reader.Read<ZADM_M011_PopUp>().ToList();
                    MC.MachineTypeMaster_1 = MachineTypeMaster.ToList();

                    var MachineSubTypeMaster = reader.Read<ZADM_M012_PopUp>().ToList();
                    MC.MachineSubTypeMaster_1 = MachineSubTypeMaster.ToList();

                    var MakeMaster = reader.Read<ADM_M032_PopUp>().ToList().ToList();
                    MC.MakeMaster_1 = MakeMaster.ToList();

                    var MachineCapacityMaster = reader.Read<ADM_M041_PopUp>().ToList();
                    MC.MachineCapacityMaster_1 = MachineCapacityMaster.ToList();

                    //var UOMMaster = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M038_B_PopUp>(reader);
                    //MC.UOMMaster_1 = UOMMaster.ToList();
                    //reader.NextResult();

                    var EmployeeMaster = reader.Read<ADM_M024_PopUp1>().ToList();
                    MC.EmployeeMaster_1 = EmployeeMaster.ToList();
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
        #endregion
        #region Update
        public string Update(string Request)
        {
            //try
            //{
            //    //zADM_M013 = (ZADM_M013)ObjectSerializationService.XMLToObject(Request, zADM_M013);
                //SqlParameter[] param = new SqlParameter[] 
                //{
                //    new SqlParameter("@Request",zADM_M013),                                                      
                //};             
                //var cmd = dbContext.Database.Connection.CreateCommand();
                //cmd.CommandText = "ZADM_M013Update";
                //cmd.CommandType = CommandType.StoredProcedure;
                ////cmd.Parameters.AddRange(param);
                //dbContext.Database.Connection.Open();
                //var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //MultipleContext_ZADM_M013 MC = new MultipleContext_ZADM_M013();

                //var MachineMaster = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ZADM_M013>(reader);
                //MC.MachineMaster_1 = MachineMaster.ToList();
                //reader.NextResult();

                //var POItemsDetailstemp = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<PUR_T002_B>(reader);
                //MC.POItemsDetails = POItemsDetailstemp.ToList();

                //zADM_M013 = MC.MachineMaster_1[0];
                ////zADM_M013 = ObjectSerializationService.ObjectToXML(MC.MachineMaster_1);
                //if (!reader.Read())
                //{
                //    reader.Close();
                //}
                //string strReturnData = ObjectSerializationService.ObjectToXML(zADM_M013);
                //return strReturnData;
            //}
            try
            {
                zADM_M013 = (ZADM_M013)ObjectSerializationService.XMLToObject(Request, zADM_M013);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZADM_M013Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);
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
        #endregion

        #region Delete
        public string Delete(int Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZADM_M013Delete", new { @machine_id = Request }, commandType: CommandType.StoredProcedure);
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
        #endregion
    }
    public class MultipleContext_ZADM_M013
    {
        public List<ZADM_M013> MachineMaster_1 { get; set; }   //Machine Master   
        public List<ADM_M002_PopUp> GroupCompanyMaster_1 { get; set; }  //Group Company Master 
        public List<ZADM_M011_PopUp> MachineTypeMaster_1 { get; set; }  //Machine Type Master  
        public List<ZADM_M012_PopUp> MachineSubTypeMaster_1 { get; set; }  //Machine Sub Type Master  
        public List<ADM_M032_PopUp> MakeMaster_1 { get; set; }  //Make Master  
        public List<ADM_M041_PopUp> MachineCapacityMaster_1 { get; set; }  //Machine Capacity Master  
       // public List<ADM_M038_B_PopUp> UOMMaster_1 { get; set; }  //Unit Of Measurement Master  
        public List<ADM_M024_PopUp1> EmployeeMaster_1 { get; set; } //Employee Master        
    }
}
