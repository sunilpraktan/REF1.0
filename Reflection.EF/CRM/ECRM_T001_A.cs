using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class ECRM_T001_A : ObjectBase
    {
        public string client { get; set; }
        public int id { get; set; }
        public string sa_no { get; set; }
        public Nullable<System.DateTime> sa_date { get; set; }
        public string sample_frm { get; set; }
        public string sample_when { get; set; }
        public string purpose { get; set; }
        public string bkgrnd { get; set; }
        public string docktno { get; set; }
        public string disp_date { get; set; }
        public Nullable<bool> smoth { get; set; }
        public Nullable<bool> fadng { get; set; }
        public Nullable<bool> ild { get; set; }
        public Nullable<bool> gooping { get; set; }
        public Nullable<bool> skiping { get; set; }
        public Nullable<bool> deep_light { get; set; }
        public Nullable<bool> waviness { get; set; }
        public Nullable<bool> stat_lickage { get; set; }
        public Nullable<bool> wrt_length { get; set; }
        public string wrt_length_req { get; set; }
        public Nullable<bool> ch_ball { get; set; }
        public Nullable<bool> ch_matrl { get; set; }
        public Nullable<bool> prepare_digram { get; set; }
        public Nullable<bool> mch_esem_model { get; set; }
        public Nullable<bool> in_geometry { get; set; }
        public string other_req { get; set; }
        public string remark { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string doc_cat { get; set; }
        public string doc_code { get; set; }
        public string comp_code { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public Nullable<bool> active { get; set; }
        public string location_Id { get; set; }
        public string courier { get; set; }
        public string doc_type { get; set; }
        public string Plant_Nm { get; set; }
        public string sample_to_plant { get; set; }
        public string t_status { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public string sales_org { get; set; }
        public string sg_name { get; set; }
        public string needle_tip { get; set; }
        public string sample_ink { get; set; }
        public Nullable<System.DateTime> collection_Reciept_Date { get; set; }
        public string conclusion { get; set; }
        public string trans_type { get; set; }
        public Nullable<bool> other_req1 { get; set; }
        public string sender_name { get; set; }
        public string prepaper_name { get; set; }
        public string approver_name { get; set; }
        public Nullable<System.DateTime> sar_date { get; set; }
    }
    public partial class ECRM_T001_B
    {
        public int id { get; set; }
        public string description { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string sa_no { get; set; }
        public string unit_code { get; set; }
        public string comp_code { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string ItemCode { get; set; }
        public Nullable<bool> active { get; set; }
        public string location_Id { get; set; }
        public string editby { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string item_type { get; set; }
    }
}
