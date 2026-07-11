using Reflection.EF;
using Dapper;
using Reflection.EF.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Reflection.BusinessLogic
{
    class ADM_M041_B_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        ADM_M041_B MasterEntity = new ADM_M041_B();
        MultipleContext_ADM_M041_B MC = new MultipleContext_ADM_M041_B();
        public ADM_M041_B_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M041_B_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {

            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M041_B_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var flipGridData = reader.Read<ADM_M041_B_Flip>().ToList();
                        MC.FlipGridData = flipGridData.ToList();

                        var wireDia = reader.Read<ZADM_M003_P>().ToList();
                        MC.WireDia = wireDia.ToList();

                        var wireType = reader.Read<ZADM_M004_P>().ToList();
                        MC.WireType = wireType.ToList();

                        var ballDia = reader.Read<ZADM_M001_P>().ToList();
                        MC.BallDia = ballDia.ToList();

                        var ballType = reader.Read<ZADM_M002_P>().ToList();
                        MC.BallType = ballType.ToList();

                       

                    }
                    if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var masterData = reader.Read<ADM_M041_B>().ToList();
                        MC.MasterEntity = masterData.ToList();
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
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M041_B_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlipList = reader.Read<ADM_M041_B_Flip>().ToList();
                    MC.FlipGridData = BackFlipList.ToList();

                    var MasterData = reader.Read<ADM_M041_B>().ToList();
                    MC.MasterEntity = MasterData.ToList();
                    if (MC.MasterEntity.Count > 0)

                    {
                        MasterEntity = MC.MasterEntity[0];
                    }

                    MasterEntity.XmlDataDocument_ADM_M041_B = ObjectSerializationService.ObjectToXML(MC.MasterEntity);
                    MasterEntity.XmlDataDocument_ADM_M041_B_Flip = ObjectSerializationService.ObjectToXML(MC.FlipGridData);


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
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M041_B_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlipList = reader.Read<ADM_M041_B_Flip>().ToList();
                    MC.FlipGridData = BackFlipList.ToList();

                    var MasterData = reader.Read<ADM_M041_B>().ToList();
                    List<ADM_M041_B> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
               
                    MasterEntity.XmlDataDocument_ADM_M041_B_Flip = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
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

    public class MultipleContext_ADM_M041_B
    {
        public List<ADM_M041_B_Flip> FlipGridData { get; set; }// BackFlip
        public List<ADM_M041_B> MasterEntity { get; set; }// MasterEntity
        public List<ZADM_M003_P> WireDia { get; set; }// wire Diameter
        public List<ZADM_M004_P> WireType { get; set; }// wire Type
        public List<ZADM_M001_P> BallDia { get; set; }// Ball Dia Type
        public List<ZADM_M002_P> BallType { get; set; }// Ball Type

    }

    public class ADM_M041_B_Flip
    {
        public int id { get; set; }
        public string sion_no { get; set; }
        public string sion_desc { get; set; }
        public string imp_wire_type { get; set; }
        public string imp_wire_dia { get; set; }
        public string imp_ball_type { get; set; }
        public string imp_ball_dia { get; set; }
        public string t_status { get; set; }

    }
    }

   
