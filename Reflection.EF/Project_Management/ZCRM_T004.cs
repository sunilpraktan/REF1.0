using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Project_Management
{
    public partial class ZCRM_T004 : ObjectBase
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string EmpId { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string tender_no { get; set; }
        public string tender_name { get; set; }
        public Nullable<System.DateTime> tender_date { get; set; }
        public string doc_name { get; set; }
        public string tender_desc { get; set; }
        public Nullable<System.DateTime> release_date { get; set; }
        public Nullable<System.DateTime> delivery_date { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> tender_value { get; set; }
        public Nullable<decimal> emd_amt { get; set; }
        public Nullable<bool> emd_ex { get; set; }
        public Nullable<bool> emd_status { get; set; }
        public Nullable<System.DateTime> emd_return_date { get; set; }
        public string abg { get; set; }
        public Nullable<decimal> abg_amt { get; set; }
        public Nullable<System.DateTime> abg_return_date { get; set; }
        public string release_mode { get; set; }
        public Nullable<int> abg_days { get; set; }
        public Nullable<bool> abg_status { get; set; }
        public Nullable<decimal> tender_form_fee { get; set; }
        public Nullable<decimal> insurance { get; set; }
        public Nullable<decimal> other { get; set; }
        public string t_status { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<int> ContInfoId { get; set; }
        public string contact_per_nm { get; set; }
        public string pay_mode { get; set; }
        public Nullable<decimal> emd_deduction { get; set; }
        public Nullable<decimal> received_amt { get; set; }
        public string deduction_resn { get; set; }
        public string t_display { get; set; }
        public string EmpName { get; set; }     
        public string LoctnNm { get; set; }
    }
    public partial class ZCRM_T004_A : ObjectBase
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string doc_name { get; set; }
        public string tender_no { get; set; }
        public string tender_name { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<System.DateTime> entry_date { get; set; }
        public Nullable<int> ContInfoId { get; set; }
        public string contact_per_nm { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string sub_doc_cat { get; set; }
        public string tender_doc_type { get; set; }
        public string tender_doc_cat { get; set; }
        public string sub_cat_desc { get; set; }
        public string cat_desc { get; set; }
        public string client { get; set; }

    }
}
