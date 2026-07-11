using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.Project_Management;

namespace Reflection.BusinessLogic
{
    public class RND_T010BL : ReflectionBusinessLogic
    {
     
        static List<RND_T010_B_Flip> RND_T010_B_staticList = new List<RND_T010_B_Flip>();        
        private static string connectionString;
        private static string connectionStringforInsert_RND_T010_B;
        static string strConn;
        static int MaxID;
        RND_T010 MasterEntity = new RND_T010();        
        MultipleContext_RND_T010 MC = new MultipleContext_RND_T010();
     
        public RND_T010BL(string BusinessEntity)
        {
            connectionString = strConn;
        }
        public RND_T010BL()
        {             
             connectionString = base.ReflectionConnectionString;
             connectionStringforInsert_RND_T010_B = base.ReflectionConnectionString;
        }
        public string InsertAdmin(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("RND_T010_AInsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var admin = reader.Read<RND_T010_A>().ToList();
                    MC.AdminEntity = admin.ToList();

                    MasterEntity.XmlDataDocument_RND_T010_A = ObjectSerializationService.ObjectToXML(MC.AdminEntity);                    
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
        public string InsertDAS_DashBoard(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionStringforInsert_RND_T010_B))
                {
                    //Request = MasterEntity.XmlDataDocument_RND_T010_B;
                    var reader = conn.QueryMultiple("RND_T010_BInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _DashBoardEntity = reader.Read<RND_T010_B_Flip>().ToList();
                    MC.DashBoardEntity = _DashBoardEntity.ToList();
                }
                //string strReturnData = ObjectSerializationService.ObjectToXML(MC);
                string strReturnData = "";
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
            try
            {
                MultipleContext_RND_T010 MC = new MultipleContext_RND_T010();
                string RequestOption = RequestValue.Split('!')[0];
                string strReturnData = "";

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("RND_T010LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var admin = reader.Read<RND_T010_A>().ToList();
                        MC.AdminEntity = admin.ToList();

                        var _TestBedNo = reader.Read<RND_T010_A_P>().ToList();
                        MC.TestBedNo = _TestBedNo.ToList();

                        var _DAS_DashBoard = reader.Read<RND_T010_B_P>().ToList();
                        MC.DAS_DashBoard = _DAS_DashBoard.ToList();
                    }
                    else if (RequestOption == "LoadDAS_DashBoardFromFilter")
                    {                       
                        var dashBoard = reader.Read<RND_T010_B_Flip>().ToList();
                        MC.DashBoardEntity = dashBoard.ToList();                                               
                    }
                    else if (RequestOption == "LoadTBsConnection")
                    {
                        var admin = reader.Read<RND_T010_A>().ToList();
                        MC.AdminEntity = admin.ToList();                        

                        foreach (var a in MC.AdminEntity)
                        {
                            strConn = "Data Source=" + a.ip_address + "; Initial Catalog=" + a.db + ";Persist Security Info=True;User ID=" + a.user_id + ";Password=" + a.password + "; ";
                           
                            connectionString = strConn;

                            MaxID = a.max_id;

                            ReflectionProjectManagementBL newReflectionProjectManagementBL = new ReflectionProjectManagementBL();

                            newReflectionProjectManagementBL.GetDataFromBL("DAS_DashBoardFromBL", "LoadDAS_DashBoardFromVariousTBsConnection");                           
                        }                                              
                    }
                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    return strReturnData;
                }
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
        public string GetDataOfDashBoardFromTBsConnection(string NewRequestOption)
        {
            try
            {
                MultipleContext_RND_T010 MC = new MultipleContext_RND_T010();
                
                string RequestOption = NewRequestOption + "!@" + MaxID;
                string strReturnData = "";

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("RND_T010LoadAll", new { @Request = RequestOption }, commandType: CommandType.StoredProcedure);
                    
                    if (NewRequestOption == "LoadDAS_DashBoardFromVariousTBsConnection")
                    {
                        var dashBoard = reader.Read<RND_T010_B_Flip>().ToList();
                        MC.DashBoardEntity = dashBoard.ToList();
                    }                    

                    MasterEntity.XmlDataDocument_RND_T010_B = ObjectSerializationService.ObjectToXML(MC.DashBoardEntity);
                    InsertDAS_DashBoard(MasterEntity.XmlDataDocument_RND_T010_B);                  

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
        public class MultipleContext_RND_T010
        {
            public List<RND_T010> MasterEntity { get; set; }  
            public List<RND_T010_A> AdminEntity { get; set; }           
            public List<RND_T010_B_Flip> DashBoardEntity { get; set; }
            public List<RND_T010_A_P> TestBedNo { get; set; }
            public List<RND_T010_B_P> DAS_DashBoard { get; set; }
        }
        public class RND_T010_B_Flip
        {
            public int id { get; set; }
            public int Pn { get; set; }
            public string f_name { get; set; }
            public string E_Speed_000 { get; set; }
            public string E_Torque_001 { get; set; }
            public string SFCReset_002 { get; set; }
            public string L_Weight_003 { get; set; }
            public string L_Time_004 { get; set; }
            public string F_Weight_005 { get; set; }
            public string T_WtrOut_006 { get; set; }
            public string T_Exhaust_007 { get; set; }
            public string P_LubOil_008 { get; set; }
            public string Not_Prog_009 { get; set; }
            public string Not_Prog_010 { get; set; }
            public string Not_Prog_011 { get; set; }
            public string Not_Prog_012 { get; set; }
            public string Not_Prog_013 { get; set; }
            public string Not_Prog_014 { get; set; }
            public string Not_Prog_015 { get; set; }
            public string Not_Prog_016 { get; set; }
            public string Not_Prog_017 { get; set; }
            public string Not_Prog_018 { get; set; }
            public string Not_Prog_019 { get; set; }
            public string Not_Prog_020 { get; set; }
            public string Not_Prog_021 { get; set; }
            public string Not_Prog_022 { get; set; }
            public string Not_Prog_023 { get; set; }
            public string Not_Prog_024 { get; set; }
            public string Not_Prog_025 { get; set; }
            public string Not_Prog_026 { get; set; }
            public string Not_Prog_027 { get; set; }
            public string Not_Prog_028 { get; set; }
            public string Not_Prog_029 { get; set; }
            public string Not_Prog_030 { get; set; }
            public string P_Ambient_031 { get; set; }
            public string P_WtrIn_032 { get; set; }
            public string P_WtrOut_033 { get; set; }
            public string Not_Prog_034 { get; set; }
            public string Not_Prog_035 { get; set; }
            public string Not_Prog_036 { get; set; }
            public string Not_Prog_037 { get; set; }
            public string Not_Prog_038 { get; set; }
            public string Not_Prog_039 { get; set; }
            public string Not_Prog_040 { get; set; }
            public string Not_Prog_041 { get; set; }
            public string Not_Prog_042 { get; set; }
            public string Not_Prog_043 { get; set; }
            public string Not_Prog_044 { get; set; }
            public string Not_Prog_045 { get; set; }
            public string Not_Prog_046 { get; set; }
            public string Not_Prog_047 { get; set; }
            public string Not_Prog_048 { get; set; }
            public string Not_Prog_049 { get; set; }
            public string Not_Prog_050 { get; set; }
            public string Not_Prog_051 { get; set; }
            public string Not_Prog_052 { get; set; }
            public string Not_Prog_053 { get; set; }
            public string Not_Prog_054 { get; set; }
            public string Not_Prog_055 { get; set; }
            public string Not_Prog_056 { get; set; }
            public string Not_Prog_057 { get; set; }
            public string Not_Prog_058 { get; set; }
            public string Not_Prog_059 { get; set; }
            public string Not_Prog_060 { get; set; }
            public string Not_Prog_061 { get; set; }
            public string Not_Prog_062 { get; set; }
            public string Not_Prog_063 { get; set; }
            public string Not_Prog_064 { get; set; }
            public string Not_Prog_065 { get; set; }
            public string Not_Prog_066 { get; set; }
            public string Not_Prog_067 { get; set; }
            public string Not_Prog_068 { get; set; }
            public string Not_Prog_069 { get; set; }
            public string Not_Prog_070 { get; set; }
            public string Not_Prog_071 { get; set; }
            public string Not_Prog_072 { get; set; }
            public string Not_Prog_073 { get; set; }
            public string Not_Prog_074 { get; set; }
            public string Not_Prog_075 { get; set; }
            public string Not_Prog_076 { get; set; }
            public string Not_Prog_077 { get; set; }
            public string Not_Prog_078 { get; set; }
            public string Not_Prog_079 { get; set; }
            public string Not_Prog_080 { get; set; }
            public string Not_Prog_081 { get; set; }
            public string Not_Prog_082 { get; set; }
            public string Not_Prog_083 { get; set; }
            public string Not_Prog_084 { get; set; }
            public string Not_Prog_085 { get; set; }
            public string NotProg_086 { get; set; }
            public string T_WI_PID_087 { get; set; }
            public string T_WO_PID_088 { get; set; }
            public string T_HTnkPID_089 { get; set; }
            public string T_PID4_090 { get; set; }
            public string Not_Prog_091 { get; set; }
            public string Not_Prog_092 { get; set; }
            public string Not_Prog_093 { get; set; }
            public string Not_Prog_094 { get; set; }
            public string Not_Prog_095 { get; set; }
            public string Not_Prog_096 { get; set; }
            public string Not_Prog_097 { get; set; }
            public string Not_Prog_098 { get; set; }
            public string Not_Prog_099 { get; set; }
            public string Not_Prog_100 { get; set; }
            public string SmkValue_101 { get; set; }
            public string BlowBy_102 { get; set; }
            public string SFCWt_103 { get; set; }
            public string F_Time_104 { get; set; }
            public string C_Factor_105 { get; set; }
            public string AvgTrq_106 { get; set; }
            public string NC_Power_107 { get; set; }
            public string NC_SFC_108 { get; set; }
            public string Inj_Qty_109 { get; set; }
            public string C_Trque_110 { get; set; }
            public string C_Power_111 { get; set; }
            public string C_SFC_112 { get; set; }
            public string F_Flow_113 { get; set; }
            public string Fuel_Flow_114 { get; set; }
            public string A_Power_hp_115 { get; set; }
            public string C_Power_hp_116 { get; set; }
            public string A_SFC_hp_117 { get; set; }
            public string C_SFC_hp_118 { get; set; }
            public string DiffPress_119 { get; set; }
            public string Not_Prog_120 { get; set; }
            public string Not_Prog_121 { get; set; }
            public string Not_Prog_122 { get; set; }
            public string Strt_Tm_123 { get; set; }
            public string ToTal_Hrs_124 { get; set; }
            public string Alarm_125 { get; set; }
            public string tb_code { get; set; }
            public int tb_rowId { get; set; }
            public string ip_address { get; set; }
            public string project { get; set; }
            public string eng_model { get; set; }
            public string eng_no { get; set; }
            public string test_type { get; set; }           
        }
    }
}