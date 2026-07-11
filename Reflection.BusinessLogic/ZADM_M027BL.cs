using Dapper;
using Reflection.EF;
using Reflection.EF.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class ZADM_M027BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        ZADM_M027 MasterEntity = new ZADM_M027();
        MultipleContext_ZADM_M027 MC = new MultipleContext_ZADM_M027();

        public ZADM_M027BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZADM_M027BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            String strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M027Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure, commandTimeout: 0);

                    //var Flipgriddata = reader.Read<ZADM_M027Flip>().ToList();
                    //MC.DocumentDataFlipGrid = Flipgriddata.ToList();

                    var MasterData = reader.Read<ZADM_M027>().ToList();
                    MC.MasterEntity = MasterData.ToList();
                  
                    var ItemData = reader.Read<ZADM_M027_A>().ToList();
                    MC.ItemEntity = ItemData.ToList();
                   
                    //MasterEntity.XmlDataDocument_ZADM_M027FLIP = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_ZADM_M027 = ObjectSerializationService.ObjectToXML(MC.MasterEntity);
                    MasterEntity.XmlDataDocument_ZADM_M027_A = ObjectSerializationService.ObjectToXML(MC.ItemEntity);
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
            String strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M027Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //var Flipgriddata = reader.Read<ZADM_M027Flip>().ToList();
                    //MC.DocumentDataFlipGrid = Flipgriddata.ToList();

                    var MasterData = reader.Read<ZADM_M027>().ToList();
                    MC.MasterEntity = MasterData.ToList();
                    
                    var ItemData = reader.Read<ZADM_M027_A>().ToList();
                    MC.ItemEntity = ItemData.ToList();
                    
                    //MasterEntity.XmlDataDocument_ZADM_M027FLIP = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_ZADM_M027 = ObjectSerializationService.ObjectToXML(MC.MasterEntity);
                    MasterEntity.XmlDataDocument_ZADM_M027_A = ObjectSerializationService.ObjectToXML(MC.ItemEntity);
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M027LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if(RequestOption == "LoadInitialData")
                    {
                        //var flipGridData = reader.Read<ZADM_M027Flip>().ToList();
                        //MC.DocumentDataFlipGrid = flipGridData.ToList();

                        var wiresize = reader.Read<ZADM_M003_P>().ToList();
                        MC.WireSizeList = wiresize.ToList();

                        var wiretype = reader.Read<ZADM_M004_P>().ToList();
                        MC.WireTypeList = wiretype.ToList();

                        var balltype = reader.Read<ZADM_M002_P>().ToList();
                        MC.BallTypeList = balltype.ToList();

                        var tiplen = reader.Read<ZADM_M008_P>().ToList();
                        MC.TotalLenList = tiplen.ToList();

                        var unitlist = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UnitList = unitlist.ToList();

                        var date = reader.Read<ACC_M001A_P>().ToList();
                        MC.DateList = date.ToList();

                    }

                    if(RequestOption == "LoadDataByMonthAndYear")
                    {
                        var masterdata = reader.Read<ZADM_M027>().ToList();
                        MC.MasterEntity = masterdata.ToList();

                        var itemdata = reader.Read<ZADM_M027_A>().ToList();
                        MC.ItemEntity = itemdata.ToList();
                    }

                    string strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZADM_M027Delete", new { @Request = Request }, commandType: CommandType.StoredProcedure);
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
        public class MultipleContext_ZADM_M027
        {
            public List<ZADM_M027Flip> DocumentDataFlipGrid { get; set; } //BF data
            public List<ZADM_M003_P> WireSizeList { get; set; } //wiresize popup
            public List<ZADM_M004_P> WireTypeList { get; set; } //wiretype popup
            public List<ZADM_M002_P> BallTypeList { get; set; } //Balltype popup
            public List<ZADM_M008_P> TotalLenList { get; set; } //TipLen popup
            public List<ADM_M038_B_P> UnitList { get; set; } //UOM popup
            public List<ACC_M001A_P> DateList { get; set; } // date popup
            public List<ZADM_M027_A> ItemEntity { get; set; } //Detail table
            public List<ZADM_M027> MasterEntity { get; set; } //Master table

        }
    }
    
}
