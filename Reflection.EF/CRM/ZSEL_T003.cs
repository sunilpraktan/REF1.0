using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class ZSEL_T003 : ObjectBase
    {
        public string sr_no { get; set; }
        public int id { get; set; }
        public string party_id { get; set; }
        public string cust_name { get; set; }
        public string cust_id { get; set; }
        public string invoice_no { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<decimal> taxable_value { get; set; }
        public string gst_no { get; set; }
        public string gst { get; set; }
        public string cgst { get; set; }
        public string sgst { get; set; }
        public string igst { get; set; }
        public Nullable<decimal> gst_p { get; set; }
        public Nullable<decimal> cgst_p { get; set; }
        public Nullable<decimal> sgst_p { get; set; }
        public Nullable<decimal> igst_p { get; set; }
        public Nullable<decimal> gst_amt { get; set; }
        public Nullable<decimal> cgst_amt { get; set; }
        public Nullable<decimal> sgst_amt { get; set; }
        public Nullable<decimal> igst_amt { get; set; }
        public string hsn_code { get; set; }
        public string buss_place { get; set; }
        public string supply_type { get; set; }
        public string invoice_type { get; set; }
        public string rev_charge { get; set; }
        public string e_comm { get; set; }
        public string section { get; set; }
        public Nullable<decimal> cess_amt { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> rate { get; set; }
        public string item { get; set; }
        public Nullable<bool> gst_no_ind { get; set; }
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

        //Scalar
        public string party_name { get; set; }
        public Nullable<System.DateTime> from_dt { get; set; }
        public Nullable<System.DateTime> to_dt { get; set; }
        public string plc_name { get; set; }
        public Nullable<decimal> total_gst_amt { get; set; }
    }
    public class MultipleContext_ZSEL_T003
    {
        public List<ZSEL_T003_BackFlip> BackFlipEntity { get; set; }
        public List<ZSEL_T003> MasterData { get; set; }
        public List<ZSEL_T003> DetailData { get; set; }
        public List<ADM_M028_P> Party { get; set; }
        public List<ZSEL_T003_P> CustomerName { get; set; }
        public List<ZSEL_T003_P> PartyForFilter { get; set; }
        public List<ZSEL_T003_A_P> HSNCode { get; set; }
        public List<ADM_M003_C_P> BussPlace { get; set; }        
    }
    public class ZSEL_T003_BackFlip
    {
        public string sr_no { get; set; }
        public int id { get; set; }
        public string party_id { get; set; }
        public string cust_name { get; set; }
        public string cust_id { get; set; }
        public string invoice_no { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<decimal> taxable_value { get; set; }
        public string gst_no { get; set; }
        public string gst { get; set; }
        public string cgst { get; set; }
        public string sgst { get; set; }
        public string igst { get; set; }
        public Nullable<decimal> gst_p { get; set; }
        public Nullable<decimal> cgst_p { get; set; }
        public Nullable<decimal> sgst_p { get; set; }
        public Nullable<decimal> igst_p { get; set; }
        public Nullable<decimal> gst_amt { get; set; }
        public Nullable<decimal> cgst_amt { get; set; }
        public Nullable<decimal> sgst_amt { get; set; }
        public Nullable<decimal> igst_amt { get; set; }
        public string hsn_code { get; set; }
        public string buss_place { get; set; }
        public string supply_type { get; set; }
        public string invoice_type { get; set; }
        public string rev_charge { get; set; }
        public string e_comm { get; set; }
        public string section { get; set; }
        public Nullable<decimal> cess_amt { get; set; }
        public string remark { get; set; }

        //Scalar
        public string party_name { get; set; }
    }
}
