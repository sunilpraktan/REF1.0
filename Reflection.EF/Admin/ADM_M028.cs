using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M028 : ObjectBase
    {
        public int id { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string abbr { get; set; }
        public string Location { get; set; }
        public string VendorCd { get; set; }
        public Nullable<bool> Customer { get; set; }
        public Nullable<bool> Supplier { get; set; }
        public Nullable<bool> transporter { get; set; }
        public string PartyType { get; set; }
        public string ManuScop { get; set; }
        public string BusinesTyp { get; set; }
        public string buss_type { get; set; }
        public string PhNo { get; set; }
        public string PhExt { get; set; }
        public string FaxNo { get; set; }
        public string EmailId { get; set; }
        public string WebSite { get; set; }
        public string ContPersnNm { get; set; }
        public string desig_code { get; set; }
        public string PersnMobNo { get; set; }
        public string PersnPhNo { get; set; }
        public string PersnPhExt { get; set; }
        public string PersnFaxNo { get; set; }
        public string PersnEmailId { get; set; }
        public string CSTNo { get; set; }
        public Nullable<System.DateTime> CSTDate { get; set; }
        public string VATNo { get; set; }
        public Nullable<System.DateTime> VATDate { get; set; }
        public string TNo { get; set; }
        public Nullable<System.DateTime> TDate { get; set; }
        public string STNo { get; set; }
        public Nullable<System.DateTime> STDate { get; set; }
        public string EccCode { get; set; }
        public string Range { get; set; }
        public string CeRange { get; set; }
        public string RngOffAdd1 { get; set; }
        public string RngOffAdd2 { get; set; }
        public string Juri { get; set; }
        public string Cmsnrt { get; set; }
        public string CmsnrtAdd { get; set; }
        public string PanNo { get; set; }
        public string PfAccNo { get; set; }
        public string p_term_code { get; set; }
        public string curr_code { get; set; }
        public string FinYr { get; set; }
        public string TaxContPersnNm { get; set; }
        public string TaxContPersnMobNo { get; set; }
        public string acc_receivable { get; set; }
        public string acc_payable { get; set; }
        public string cust_pay_term { get; set; }
        public string supp_pay_term { get; set; }
        public Nullable<decimal> credit_limit { get; set; }
        public Nullable<decimal> debit_limit { get; set; }
        public string EmpId { get; set; }
        public Nullable<int> fiscal_position { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<int> credit_days { get; set; }
        public string principle_party { get; set; }
        public string TDS { get; set; }
        public string group1 { get; set; }
        public string one_time_party { get; set; }
        public string iec_code { get; set; }
        public string service_tax_no { get; set; }
        public string div_code { get; set; }
        public string curr_name { get; set; }
        public string EmpNm { get; set; }
        public string godown_location_name { get; set; }
        public string location_Id { get; set; }
        public string grpNm { get; set; }
        public string PartyType_Nm { get; set; }
        public string godown_location { get; set; }
        public string comp_code { get; set; }
        public string acc_group { get; set; }
        public string group_desc { get; set; }
        public string acc_group_type { get; set; }
        public string recon_acc { get; set; }
        public string gstinno { get; set; }
        public string buss_place { get; set; }
        public string tax_acc_group { get; set; }
        public string tax_classification { get; set; }      
        public Nullable<System.DateTime> gstindate { get; set; }
        public string lang_key { get; set; }
        public string default_tax { get; set; }
        //Scalar
        public string gl_name { get; set; }
        public string plc_name { get; set; }
        public string tax_acc_group_name { get; set; }
        public string tax_indicator { get; set; }
        public string tax_indicator_desc { get; set; }
        public string p_term { get; set; }
        public string vendor_remark { get; set; }
        public string buss_type_name { get; set; }
        public string scope_name { get; set; }
        public string region_name { get; set; }

    }

    public partial class ADM_M028_D
    {
        public string add_code { get; set; }
        public int SrNo { get; set; }
        public string PartyId { get; set; }
        public string Location { get; set; }
        public string AddType { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string LandMark { get; set; }
        public string City { get; set; }
        public string state_code { get; set; }
        public string country_code { get; set; }
        public string PinCode { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<bool> active { get; set; }
        public string gstinno { get; set; }      
        public string buss_place { get; set; }
        public Nullable<System.DateTime> gstindate { get; set; }
        public string PartyNm { get; set; }
        public string CntryName { get; set; }
        public string StatName { get; set; }
        public string address_full { get; set; }
        public string default_tax { get; set; }
        public string land_mark { get; set; }
        public string map_link { get; set; }
    }

    public partial class ADM_M028_C
    {
        public string cp_code { get; set; }
        public int ContInfoId { get; set; }
        public string PartyId { get; set; }
        public string Location { get; set; }
        public string PersnFName { get; set; }
        public string PersnMName { get; set; }
        public string PersnLName { get; set; }
        public string dept_code { get; set; }
        public string desig_code { get; set; }
        public Nullable<int> Age { get; set; }
        public string Gender { get; set; }
        public string PersnMobNo { get; set; }
        public string PersnPhNo { get; set; }
        public string PersnPhExt { get; set; }
        public string PersnFaxNo { get; set; }
        public string PersnEmailId { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string title { get; set; }
        public Nullable<bool> default_del { get; set; }
        public Nullable<bool> default_bil { get; set; }
        public string PartyNm { get; set; }
        public string DeptName { get; set; }
        public string DesigName { get; set; }
    }

}
