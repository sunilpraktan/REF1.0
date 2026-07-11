using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M024 : ObjectBase
    {
        public int id { get; set; }
        public string EmpId { get; set; }
        public string EmpLName { get; set; }
        public string EmpFName { get; set; }
        public string EmpMName { get; set; }
        public string EmpPermtAdd { get; set; }
        public string EmpTempAdd { get; set; }
        public string EmpMobNo { get; set; }
        public string EmpPhNo { get; set; }
        public string EmpPhExt { get; set; }
        public string EmpFaxNo { get; set; }
        public string EmpEmailId { get; set; }
        public string dept_code { get; set; }
        public string desig_code { get; set; }
        public string location_Id { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public byte[] Photo { get; set; }
        public string DesigName { get; set; }
        public string DeptName { get; set; }
        public string LoctnNm { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string sales_org { get; set; }
        public string sg_name { get; set; }
        public string pur_org { get; set; }
        public string pg_name { get; set; }
        public byte[] digi_sign { get; set; }
        public string comp_code { get; set; }
        public string CompName { get; set; }
        public string lang_key { get; set; }
        public string emp_type { get; set; }
        public string empl_type_name { get; set; }
        public string XmlDataDocument_ADM_M024_A { get; set; }
        public string XmlDataDocument_ADM_M024_B { get; set; }
        public string XmlDataDocument_ADM_M024_C { get; set; }
        public string XmlDataDocument_ADM_M024BackFlip { get; set; }

        //HRM Childs
        public string XmlDataDocument_HRM_M001_D { get; set; }
     

        //Added by Karishma

        public string sal_code { get; set; }
        public string alias_name { get; set; }
        public Nullable<System.DateTime> emp_dob { get; set; }
        public string emp_pob { get; set; }
        public string emp_cob { get; set; }
        public string reli_code { get; set; }
        public string cast_code { get; set; }
        public string cat_code { get; set; }
        public string gender { get; set; }
        public string blood_group { get; set; }
        public Nullable<System.DateTime> emp_dom { get; set; }
        public string marital_status { get; set; }
        public string nation_code { get; set; }
        public string nation_code1 { get; set; }
        public string phy_dis { get; set; }
        public bool ind_phy_dis { get; set; }
        public string height_val { get; set; }
        public string height_unit { get; set; }
        public string weight_val { get; set; }
        public string weight_unit { get; set; }
        public Nullable<System.DateTime> join_date { get; set; }
        public string applicant_id { get; set; }
        public string t_status { get; set; }
        public string remark { get; set; }

        //Scaler

        public string sal_desc { get; set; }
        public string CntryName { get; set; }
        public string reli_name { get; set; }
        public string cast_name { get; set; }
        public string cat_name { get; set; }
        public string nation_desc { get; set; }
        public string phy_dis_nm { get; set; }
        public string t_name { get; set; }

    }
    public partial class ADM_M024_A
    {
        public int id { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string EmpId { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public bool? default_org_code { get; set; }

    }
    public partial class ADM_M024_B
    {
        public int id { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string EmpId { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public bool? active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public bool? default_org_code { get; set; }
    }
    public partial class ADM_M024_C
    {
        public int id { get; set; }
        public string EmpId { get; set; }
        public string PartyId { get; set; }
        public bool active { get; set; }
        // Scalar
        public string PartyNm { get; set; }
        public string Location { get; set; }
        public string PartyType { get; set; }
        public string grpNm { get; set; }

    }

    //Classes for HRM Module

    public partial class HRM_M001_D  //Language known Details
    {
        public int id { get; set; }
        public string EmpId { get; set; }
        public string language_key { get; set; }
        public bool readable { get; set; }
        public bool write { get; set; }
        public bool speak { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string remark { get; set; }

        //Scaler

        public string language_desc { get; set; }
    }



}
