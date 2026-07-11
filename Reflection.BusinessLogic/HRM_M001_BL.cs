using Dapper;
using Reflection.EF;
using Reflection.EF.ADM;
using Reflection.EF.Admin;
using Reflection.EF.HRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class HRM_M001_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_HRM_M001 MC = new MultipleContext_HRM_M001();
        ADM_M024 MasterEntity = new ADM_M024();

        public HRM_M001_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public HRM_M001_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("HRM_M001_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _BackFlipEntity = reader.Read<ADM_M024_P>().ToList();
                        MC.BackFlipEntity = _BackFlipEntity.ToList();

                        var salList = reader.Read<ADM_M050_P>().ToList();
                        MC.SalList = salList.ToList();

                        var country = reader.Read<ADM_M012_P>().ToList();
                        MC.CountryList = country.ToList();

                        var religion = reader.Read<HRM_M010_P>().ToList();
                        MC.ReligionList = religion.ToList();

                        var cast = reader.Read<HRM_M012_P>().ToList();
                        MC.CastList = cast.ToList();

                        var cat = reader.Read<HRM_M011_P>().ToList();
                        MC.CatList = cat.ToList();

                        var nation = reader.Read<ADM_M051_P>().ToList();
                        MC.NationalityList = nation.ToList();

                        var phydis = reader.Read<HRM_M021_P>().ToList();
                        MC.PhyDisList = phydis.ToList();

                        var height = reader.Read<ADM_M038_B_P>().ToList();
                        MC.HeightList = height.ToList();

                        var weight = reader.Read<ADM_M038_B_P>().ToList();
                        MC.WeightList = weight.ToList();

                        var _statuslist = reader.Read<ADM_M0013>().ToList();
                        MC.StatusList = _statuslist.ToList();


                        //Pop up for childs

                        var _language = reader.Read<HRM_M022_P>().ToList();
                        MC.LanguageList = _language.ToList();

                    }
                    else if (RequestOption == "LoadWindowWithEmployeeId")
                    {
                        var _employees = reader.Read<ADM_M024>().ToList();
                        MC.Employees = _employees.ToList();
                        if (MC.Employees.Count > 0)
                        {
                            MasterEntity = MC.Employees[0];
                        }

                        var _language = reader.Read<HRM_M001_D>().ToList();
                        MC.LaguageKnown = _language.ToList();

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


        public string Insert(string Request)
        {
            MasterEntity = (ADM_M024)ObjectSerializationService.XMLToObject(Request, MasterEntity);
            //ADM_M024 MasterEntity = new ADM_M024();
            MultipleContext_HRM_M001 MC = new MultipleContext_HRM_M001();

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("HRM_M001_Insert", new
                    {
                        @Request = Request,
                        @digi_sign = MasterEntity.digi_sign,
                        @Photo =MasterEntity.Photo

                    }, commandType: CommandType.StoredProcedure);

                    var _BackFlipEntity = reader.Read<ADM_M024_P>().ToList();
                    MC.BackFlipEntity = _BackFlipEntity.ToList();

                    var _employees = reader.Read<ADM_M024>().ToList();
                    MC.Employees = _employees.ToList();

                    if (MC.Employees.Count > 0)
                    {
                        MasterEntity = MC.Employees[0];
                    }

                    //Detail Data
                    var _language = reader.Read<HRM_M001_D>().ToList();
                    MC.LaguageKnown = _language.ToList();

                    MasterEntity.XmlDataDocument_HRM_M001_D = ObjectSerializationService.ObjectToXML(MC.LaguageKnown);
                
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
                MasterEntity = (ADM_M024)ObjectSerializationService.XMLToObject(Request, MasterEntity);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("HRM_M001_Update", new
                    {
                        @Request = Request,
                        @Photo = MasterEntity.Photo,
                        @digi_sign = MasterEntity.digi_sign
                    }, commandType: CommandType.StoredProcedure);

                    var _BackFlipEntity = reader.Read<ADM_M024_P>().ToList();
                    MC.BackFlipEntity = _BackFlipEntity.ToList();

                    var _employees = reader.Read<ADM_M024>().ToList();
                    MC.Employees = _employees.ToList();

                    if (MC.Employees.Count > 0)
                    {
                        MasterEntity = MC.Employees[0];
                    }

                    //Detail Data
                    var _language = reader.Read<HRM_M001_D>().ToList();
                    MC.LaguageKnown = _language.ToList();

                    MasterEntity.XmlDataDocument_HRM_M001_D = ObjectSerializationService.ObjectToXML(MC.LaguageKnown);
                   

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



    }

    public class MultipleContext_HRM_M001
    {
        public List<ADM_M024_P> BackFlipEntity { get; set; }
        public List<ADM_M024> Employees { get; set; }
        public List<ADM_M050_P> SalList { get; set; }  //Popup for Salutation
        public List<ADM_M012_P> CountryList { get; set; }  //Popup for Country of Birth
        public List<HRM_M010_P> ReligionList { get; set; }  //Popup for Religion
        public List<HRM_M012_P> CastList { get; set; }  //Popup for Cast
        public List<HRM_M011_P> CatList { get; set; }  //Popup for Category of cast
        public List<ADM_M051_P> NationalityList { get; set; }  //Popup for Nationality
        public List<HRM_M021_P> PhyDisList { get; set; }  //Popup for Physical Disability
        public List<ADM_M038_B_P> HeightList { get; set; }  //Popup for Height
        public List<ADM_M038_B_P> WeightList { get; set; }  //Popup for Weight
        public List<ADM_M0013> StatusList { get; set; }  //Popup for Status

        //Details Data
        public List<HRM_M001_D> LaguageKnown { get; set; } // Language Known


        //Popup for childs
        public List<HRM_M022_P> LanguageList { get; set; }  //Popup for Language
    }
}
