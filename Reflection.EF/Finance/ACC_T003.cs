using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance
{
    public partial class ACC_T003 : ObjectBase
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string PartyId { get; set; }
        public string visit_details { get; set; }
        public Nullable<decimal> advance { get; set; }
        public string EmpId { get; set; }
        public string additional_person { get; set; }
        public string travel_from { get; set; }
        public string travel_to { get; set; }
        public string location { get; set; }
        public string area { get; set; }
        public Nullable<decimal> dist_in_km { get; set; }
        public string transport_mode { get; set; }
        public Nullable<decimal> bal_amount { get; set; }
        public Nullable<decimal> approved_amt { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string language { get; set; }
        public string CustomerNm { get; set; }
        public string EmpName { get; set; }
        public decimal? grand_total { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public string gl_code { get; set; }
        public string gl_name { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_type { get; set; }
        public string expense_no { get; set; }
        public Nullable<System.DateTime> from_date { get; set; }
        public Nullable<System.DateTime> to_date { get; set; }
        public string sales_org { get; set; }
        public string sg_name { get; set; }
        public string vendor_invno { get; set; }
        

    }  

    public partial class ACC_T003_A  //Expenses
    {
        public int id { get; set; }
        public string CustomerNm { get; set; }
        public string doc_no { get; set; }
        public Nullable<System.DateTime> expenses_date { get; set; }
        public string head_code { get; set; }
        public string description { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<decimal> standard_amt { get; set; }
        public Nullable<decimal> short_excess_amt { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public string remark { get; set; }
        public string transport_mode { get; set; }
        public Nullable<decimal> approved_amt { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string PartyId { get; set; }
        public string travel_from { get; set; }
        public string travel_to { get; set; }
        public Nullable<decimal> dist_in_km { get; set; }
        public string gl_code { get; set; }
        public string gl_name { get; set; }
        public string food_expense { get; set; }
        public Nullable<decimal> food_exp_amt { get; set; }
        public string misc_detail { get; set; }
        public Nullable<decimal> misc_amt { get; set; }
        public string print_stat { get; set; }
        public Nullable<decimal> print_stat_amt { get; set; }
        public string other_expense { get; set; }
        public Nullable<decimal> other_exp_amt { get; set; }
        public Nullable<decimal> budget_amt { get; set; }
        public string sono { get; set; }
        


    }

    public partial class ACC_T003_C //Employee
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string remark { get; set; }
        public bool active { get; set; }
        public string int_ext { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public Nullable<System.DateTime> from_date { get; set; }
        public Nullable<System.DateTime> to_date { get; set; }
        public Nullable<decimal> no_of_day { get; set; }
        public Nullable<decimal> day_charge { get; set; }
        public Nullable<decimal> total_amt { get; set; }
        public Nullable<decimal> expense_amt { get; set; }
        public Nullable<decimal> net_balance { get; set; }


    }

    public partial class ACC_T003_D //Work Order
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string work_order_no { get; set; }
        public string work_location { get; set; }
        public Nullable<System.DateTime> date_of_work { get; set; }
        public string work_desc { get; set; }
        public string remark { get; set; }
        public bool active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public Nullable<System.DateTime> from_date { get; set; }
        public Nullable<System.DateTime> to_date { get; set; }
        public string project_id { get; set; }
        public string project_name { get; set; }
    }

    public partial class ACC_T003_E //Transport 
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public Nullable<System.DateTime> date_of_journey { get; set; }
        public string trans_mode { get; set; }
        public string travel_from { get; set; }
        public string travel_to { get; set; }
        public string dist_in_km { get; set; }
        public Nullable<bool> own_vehicle { get; set; }
        public string transporter { get; set; }
        public string remark { get; set; }
        public bool active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public int vehicle_id { get; set; }
        public string vehicle_no { get; set; }
        public string oil_type { get; set; }
        public string driver_id { get; set; }
        public Nullable<System.DateTime> from_date { get; set; }
        public Nullable<System.DateTime> to_date { get; set; }
    }

    public partial class ACC_T003_F //Advance 
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public Nullable<System.DateTime> date_of_advance { get; set; }
        public string payment_mode { get; set; }
        public Nullable<decimal> amount { get; set; }
        public string remark { get; set; }
        public bool active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string paid_by { get; set; }
        public Nullable<decimal> paid_amt { get; set; }
        public Nullable<decimal> paid_by_amt { get; set; }
    }

    public partial class ACC_T003_G  //Commercial Invoice
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string com_inv_no { get; set; }
        public Nullable<decimal> amount { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string remark { get; set; }
        public Nullable<decimal> para1 { get; set; }
        public Nullable<int> para2 { get; set; }
        public string para3 { get; set; }
    }

}
