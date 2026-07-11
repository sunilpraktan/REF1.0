using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance
{
    public partial class ACC_M003 : ObjectBase
    {
        public int id { get; set; }
        public string acc_code { get; set; }
        public Nullable<int> parent_left { get; set; }
        public Nullable<int> parent_right { get; set; }
        public string p_code { get; set; }
        public Nullable<bool> reconcile { get; set; }
        public string curr_code { get; set; }
        public Nullable<int> user_type { get; set; }
        public Nullable<bool> active { get; set; }
        public string p_name { get; set; }
        public Nullable<int> p_level { get; set; }
        public string location_Id { get; set; }
        public string shortcut { get; set; }
        public string p_note { get; set; }
        public Nullable<int> parent_id { get; set; }
        public string currency_mode { get; set; }
        public string p_type { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string ac_group_code { get; set; }
        public string ac_sg_code { get; set; }
        public Nullable<int> seq_no { get; set; }
        public string par_gl_code { get; set; }
        public string acc_type { get; set; }
        public string sundry_type { get; set; }
        public string Posting { get; set; }
        public string to_inc { get; set; }
        public string code_format { get; set; }
        public string short_desc { get; set; }
        public string comp_code { get; set; }
        public string language { get; set; }
        public string gl_code { get; set; }
        public string group_cat { get; set; }
        public string ind_bal { get; set; }
        public string ind_sp_gl_code { get; set; }
        public string ind_pl { get; set; }
        public string exch_rate_key { get; set; }
        public string house_bank_key { get; set; }
        public string tol_group { get; set; }
        public string ind_wo_tax { get; set; }
        public string ind_recon { get; set; }
        public string ind_pending_item { get; set; }
        public string ind_line_item { get; set; }
        public string ind_cash_flow { get; set; }
        public string ind_cash_receipt { get; set; }
        public string ind_block { get; set; }

        //Scaller
        public string curr_name { get; set; }
        public string bank_name { get; set; }
        public string ac_group_name { get; set; }
        public string ac_sg_name { get; set; }
        public string group_cat_name { get; set; }
    }
}
