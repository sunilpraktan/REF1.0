using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.VMS;
using Dapper;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class VMS_T001_BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        MultipleContext_VMS_T001 MC = new MultipleContext_VMS_T001();

        VMS_T001 MasterEntity = new VMS_T001();
        VMS_T001_B AddVisitor = new VMS_T001_B();

        public VMS_T001_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public VMS_T001_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("VMS_T001_Insert", new { @Request = Request, @v_image = MasterEntity.v_image, @v_sign = MasterEntity.v_sign, @v_thumb1 = MasterEntity.v_thumb1, @v_thumb2 = MasterEntity.v_thumb2, @v_retina = MasterEntity.v_retina, @v_palm = MasterEntity.v_palm, @av_image = AddVisitor.av_image, @av_sign = AddVisitor.av_sign, @av_thumb1 = AddVisitor.av_thumb1, @av_thumb2 = AddVisitor.av_thumb2, @av_retina = AddVisitor.av_retina, @av_palm = AddVisitor.av_palm }, commandType: CommandType.StoredProcedure);

                    //BackFlip Data
                    var _BackFlipEntity = reader.Read<VMS_T001_BackFlip>().ToList();
                    MC.BackFlipEntity = _BackFlipEntity.ToList();

                    //Master Data
                    var _MasterData = reader.Read<VMS_T001>().ToList();
                    MC.MasterData = _MasterData.ToList();
                    if (MC.MasterData.Count > 0)
                    {
                        MasterEntity = MC.MasterData[0];
                    }

                    //Detail_A Data-----Accesory
                    var _DetailData_A = reader.Read<VMS_T001_A>().ToList();
                    MC.DetailData_A = _DetailData_A.ToList();

                    //Detail_B Data----Additional Visitor
                    var _DetailData_B = reader.Read<VMS_T001_B>().ToList();
                    MC.DetailData_B = _DetailData_B.ToList();

                    //Detail_C Data----Visitor Vehicle
                    var _DetailData_C = reader.Read<VMS_T001_C>().ToList();
                    MC.DetailData_C = _DetailData_C.ToList();

                    //Detail_D Data----Additional Host
                    var _DetailData_D = reader.Read<VMS_T001_D>().ToList();
                    MC.DetailData_D = _DetailData_D.ToList();

                    //Detail_E Data----Visitor Document
                    var _DetailData_E = reader.Read<VMS_T001_E>().ToList();
                    MC.DetailData_E = _DetailData_E.ToList();

                    //Detail_X Data----Visitor Facility
                    var _DetailData_X = reader.Read<VMS_M004_A>().ToList();
                    MC.DetailData_X = _DetailData_X.ToList();
                    
                    MasterEntity.XmlDataDocument_VMS_T001_A = ObjectSerializationService.ObjectToXML(MC.DetailData_A);
                    MasterEntity.XmlDataDocument_VMS_T001_B = ObjectSerializationService.ObjectToXML(MC.DetailData_B);
                    MasterEntity.XmlDataDocument_VMS_T001_C = ObjectSerializationService.ObjectToXML(MC.DetailData_C);
                    MasterEntity.XmlDataDocument_VMS_T001_D = ObjectSerializationService.ObjectToXML(MC.DetailData_D);
                    MasterEntity.XmlDataDocument_VMS_T001_E = ObjectSerializationService.ObjectToXML(MC.DetailData_E);
                    MasterEntity.XmlDataDocument_VMS_M004_A = ObjectSerializationService.ObjectToXML(MC.DetailData_X);
                    MasterEntity.XmlDataDocument_VMS_T001_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
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
                    var reader = conn.QueryMultiple("VMS_T001_Update", new { @Request = Request, @v_image = MasterEntity.v_image, @v_sign = MasterEntity.v_sign, @v_thumb1 = MasterEntity.v_thumb1, @v_thumb2 = MasterEntity.v_thumb2, @v_retina = MasterEntity.v_retina, @v_palm = MasterEntity.v_palm, @av_image = AddVisitor.av_image, @av_sign = AddVisitor.av_sign, @av_thumb1 = AddVisitor.av_thumb1, @av_thumb2 = AddVisitor.av_thumb2, @av_retina = AddVisitor.av_retina, @av_palm = AddVisitor.av_palm }, commandType: CommandType.StoredProcedure);

                    //BackFlip Data
                    var _BackFlipEntity = reader.Read<VMS_T001_BackFlip>().ToList();
                    MC.BackFlipEntity = _BackFlipEntity.ToList();

                    //Master Data
                    var Master = reader.Read<VMS_T001>().ToList();
                    MC.MasterData = Master.ToList();
                    if (MC.MasterData.Count > 0)
                    {
                        MasterEntity = MC.MasterData[0];
                    }

                    //Detail_A Data-----Accesory
                    var _DetailData_A = reader.Read<VMS_T001_A>().ToList();
                    MC.DetailData_A = _DetailData_A.ToList();

                    //Detail_B Data----Additional Visitor
                    var _DetailData_B = reader.Read<VMS_T001_B>().ToList();
                    MC.DetailData_B = _DetailData_B.ToList();

                    //Detail_C Data----Visitor Vehicle
                    var _DetailData_C = reader.Read<VMS_T001_C>().ToList();
                    MC.DetailData_C = _DetailData_C.ToList();

                    //Detail_D Data----Additional Host
                    var _DetailData_D = reader.Read<VMS_T001_D>().ToList();
                    MC.DetailData_D = _DetailData_D.ToList();

                    //Detail_E Data----Visitor Document
                    var _DetailData_E = reader.Read<VMS_T001_E>().ToList();
                    MC.DetailData_E = _DetailData_E.ToList();

                    //Detail_X Data----Visitor Facility
                    var _DetailData_X = reader.Read<VMS_M004_A>().ToList();
                    MC.DetailData_X = _DetailData_X.ToList();                    

                    MasterEntity.XmlDataDocument_VMS_T001_A = ObjectSerializationService.ObjectToXML(MC.DetailData_A);
                    MasterEntity.XmlDataDocument_VMS_T001_B = ObjectSerializationService.ObjectToXML(MC.DetailData_B);
                    MasterEntity.XmlDataDocument_VMS_T001_C = ObjectSerializationService.ObjectToXML(MC.DetailData_C);
                    MasterEntity.XmlDataDocument_VMS_T001_D = ObjectSerializationService.ObjectToXML(MC.DetailData_D);
                    MasterEntity.XmlDataDocument_VMS_T001_E = ObjectSerializationService.ObjectToXML(MC.DetailData_E);
                    MasterEntity.XmlDataDocument_VMS_M004_A = ObjectSerializationService.ObjectToXML(MC.DetailData_X);
                    MasterEntity.XmlDataDocument_VMS_T001_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_VMS_T001 MC = new MultipleContext_VMS_T001();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    
                    var reader = conn.QueryMultiple("VMS_T001_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _BackFlipEntity = reader.Read<VMS_T001_BackFlip>().ToList();
                        MC.BackFlipEntity = _BackFlipEntity.ToList();

                        var _Salutation = reader.Read<ADM_M050_P>().ToList();
                        MC.Salutation = _Salutation.ToList();

                        var _VCategory = reader.Read<VMS_M001_P>().ToList();
                        MC.VCategory = _VCategory.ToList();

                        var _VCompany = reader.Read<ADM_M028_P>().ToList();
                        MC.VCompany = _VCompany.ToList();

                        var _State = reader.Read<ADM_M013_P>().ToList();
                        MC.State = _State.ToList();

                        var _Country = reader.Read<ADM_M012_P>().ToList();
                        MC.Country = _Country.ToList();
                        
                        var _Nationality = reader.Read<ADM_M051_P>().ToList();
                        MC.Nationality = _Nationality.ToList();                        

                        var _VisitPurpose = reader.Read<VMS_M002_P>().ToList();
                        MC.VisitPurpose = _VisitPurpose.ToList();

                        var _MeetingPlace = reader.Read<VMS_M003_P>().ToList();
                        MC.MeetingPlace = _MeetingPlace.ToList();

                        var _VFacility = reader.Read<VMS_M004_P>().ToList();
                        MC.VFacility = _VFacility.ToList();

                        var _GuestHouse = reader.Read<VMS_M005_P>().ToList();
                        MC.GuestHouse = _GuestHouse.ToList();

                        var _VDocument = reader.Read<VMS_M006_P>().ToList();
                        MC.VDocument = _VDocument.ToList();

                        var _VMaterialCategory = reader.Read<VMS_M007_P>().ToList();
                        MC.VMaterialCategory = _VMaterialCategory.ToList();

                        var _VMaterialType = reader.Read<VMS_M008_P>().ToList();
                        MC.VMaterialType = _VMaterialType.ToList();

                        var _HEmployee = reader.Read<ADM_M024_P>().ToList();
                        MC.HEmployee = _HEmployee.ToList();

                        var _EntryGateNo = reader.Read<HRM_M015_P>().ToList();
                        MC.EntryGateNo = _EntryGateNo.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var _MasterData = reader.Read<VMS_T001>().ToList();
                        MC.MasterData = _MasterData.ToList();

                        var _DetailData_A = reader.Read<VMS_T001_A>().ToList();
                        MC.DetailData_A = _DetailData_A.ToList();

                        var _DetailData_B = reader.Read<VMS_T001_B>().ToList();
                        MC.DetailData_B = _DetailData_B.ToList();

                        var _DetailData_C = reader.Read<VMS_T001_C>().ToList();
                        MC.DetailData_C = _DetailData_C.ToList();

                        var _DetailData_D = reader.Read<VMS_T001_D>().ToList();
                        MC.DetailData_D = _DetailData_D.ToList();

                        var _DetailData_E = reader.Read<VMS_T001_E>().ToList();
                        MC.DetailData_E = _DetailData_E.ToList();

                        var _DetailData_X = reader.Read<VMS_M004_A>().ToList();
                        MC.DetailData_X = _DetailData_X.ToList();
                    }
                    else if (RequestOption == "LoadDocumentWithDocumentNumber")
                    {
                        var _MasterData = reader.Read<VMS_T001>().ToList();
                        MC.MasterData = _MasterData.ToList();

                        var _DetailData_A = reader.Read<VMS_T001_A>().ToList();
                        MC.DetailData_A = _DetailData_A.ToList();

                        var _DetailData_B = reader.Read<VMS_T001_B>().ToList();
                        MC.DetailData_B = _DetailData_B.ToList();

                        var _DetailData_C = reader.Read<VMS_T001_C>().ToList();
                        MC.DetailData_C = _DetailData_C.ToList();

                        var _DetailData_D = reader.Read<VMS_T001_D>().ToList();
                        MC.DetailData_D = _DetailData_D.ToList();

                        var _DetailData_E = reader.Read<VMS_T001_E>().ToList();
                        MC.DetailData_E = _DetailData_E.ToList();

                        var _DetailData_X = reader.Read<VMS_M004_A>().ToList();
                        MC.DetailData_X = _DetailData_X.ToList();
                    }
                    else if (RequestOption == "LoadVisitorValidData")
                    {
                        var _MasterData = reader.Read<VMS_T001>().ToList();
                        MC.MasterData = _MasterData.ToList();                        
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
    }
    public class MultipleContext_VMS_T001
    {
        public List<VMS_T001_BackFlip> BackFlipEntity { get; set; }
        public List<VMS_T001> MasterData { get; set; }
        public List<VMS_T001_A> DetailData_A { get; set; }
        public List<VMS_T001_B> DetailData_B { get; set; }
        public List<VMS_T001_C> DetailData_C { get; set; }
        public List<VMS_T001_D> DetailData_D { get; set; }
        public List<VMS_T001_E> DetailData_E { get; set; }
        public List<VMS_M004_A> DetailData_X { get; set; }
        public List<ADM_M050_P> Salutation { get; set; }
        public List<VMS_M001_P> VCategory { get; set; }
        public List<ADM_M028_P> VCompany { get; set; }
        public List<ADM_M013_P> State { get; set; }
        public List<ADM_M012_P> Country { get; set; }
        public List<ADM_M051_P> Nationality { get; set; }
        public List<VMS_M002_P> VisitPurpose { get; set; }
        public List<VMS_M003_P> MeetingPlace { get; set; }
        public List<VMS_M004_P> VFacility { get; set; }
        public List<VMS_M005_P> GuestHouse { get; set; }
        public List<VMS_M006_P> VDocument { get; set; }
        public List<VMS_M007_P> VMaterialCategory { get; set; }
        public List<VMS_M008_P> VMaterialType { get; set; }
        public List<ADM_M024_P> HEmployee { get; set; }
        public List<HRM_M015_P> EntryGateNo { get; set; }
    }
    public class VMS_T001_BackFlip
    {
        public string app_id { get; set; }
        public string sal_code { get; set; }
        public string v_first_nm { get; set; }
        public string v_mid_nm { get; set; }
        public string v_last_nm { get; set; }
        public string v_gender { get; set; }
        public Nullable<System.DateTime> v_dob { get; set; }
        public string v_party_id { get; set; }
        public string v_party_name { get; set; }
        public string gate_no { get; set; }
        public string v_religion { get; set; }
        public string v_cat_code { get; set; }
        public string v_email { get; set; }
        public string v_phno1 { get; set; }
        public string v_phno2 { get; set; }
        public string v_emg_no { get; set; }
        public string v_nation { get; set; }
        public string v_address { get; set; }
        public string country_code { get; set; }
        public string state_code { get; set; }
        public string v_city { get; set; }
        public string v_pin { get; set; }
        public byte[] v_thumb1 { get; set; }
        public byte[] v_thumb2 { get; set; }
        public byte[] v_retina { get; set; }
        public byte[] v_palm { get; set; }
        public byte[] v_image { get; set; }
        public byte[] v_sign { get; set; }
        public string v_off_no { get; set; }
        public string v_off_ext_no { get; set; }
        public Nullable<int> add_v_no { get; set; }
        public string v_language { get; set; }
        public string visit_desc { get; set; }
        public string vp_code { get; set; }
        public string meet_sub { get; set; }
        public string meet_desc { get; set; }
        public string app_by { get; set; }
        public Nullable<System.DateTime> pro_dt_frm { get; set; }
        public Nullable<System.DateTime> pro_dt_to { get; set; }
        public string pro_tm_frm { get; set; }
        public string pro_tm_to { get; set; }
        public Nullable<System.DateTime> sch_dt_frm { get; set; }
        public Nullable<System.DateTime> sch_dt_to { get; set; }
        public string sch_tm_frm { get; set; }
        public string sch_tm_to { get; set; }
        public Nullable<System.DateTime> meet_dt_frm { get; set; }
        public Nullable<System.DateTime> meet_dt_to { get; set; }
        public Nullable<System.DateTime> valid_dt_frm { get; set; }
        public Nullable<System.DateTime> valid_dt_to { get; set; }
        public string valid_tm_frm { get; set; }
        public string valid_tm_to { get; set; }
        public Nullable<System.DateTime> acc_dt_frm { get; set; }
        public Nullable<System.DateTime> acc_dt_to { get; set; }
        public string acc_tm_frm { get; set; }
        public string acc_tm_to { get; set; }
        public string gst_house_code { get; set; }
        public Nullable<bool> acc_int { get; set; }
        public Nullable<bool> acc_ext { get; set; }
        public Nullable<bool> acc_paid { get; set; }
        public Nullable<bool> acc_free { get; set; }
        public string acc_build_no { get; set; }
        public string acc_room_no { get; set; }
        public string acc_place_id { get; set; }
        public string acc_agency_id { get; set; }
        public string acc_room_desc { get; set; }
        public string h_name { get; set; }
        public string h_emp_id { get; set; }
        public string h_phone_no { get; set; }
        public string h_landline { get; set; }
        public string h_ext_no { get; set; }
        public string h_email { get; set; }
        public string h_work_place { get; set; }
        public Nullable<int> add_h_no { get; set; }
        public string h_chkout_remark { get; set; }
        public Nullable<bool> h_chkout_enable { get; set; }
        public string h_ra_define { get; set; }
        public string v_rfid_card_no { get; set; }
        public string bl_code { get; set; }
        public Nullable<bool> bl_status { get; set; }
        public string bl_remark { get; set; }
        public Nullable<bool> chk_in { get; set; }
        public Nullable<bool> chk_out { get; set; }
        public string dept { get; set; }
        public string ref_by { get; set; }
        public string v_pass_no { get; set; }
        public string v_badge_no { get; set; }
        public string v_book_entry_no { get; set; }
        public string escort { get; set; }
        public string security_clear { get; set; }
        public string security_remark { get; set; }
        public string place_code { get; set; }
        public Nullable<bool> sms_notify { get; set; }
        public Nullable<bool> email_notify { get; set; }
        public Nullable<bool> phone_notify { get; set; }
        public string remark { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
    }
}
