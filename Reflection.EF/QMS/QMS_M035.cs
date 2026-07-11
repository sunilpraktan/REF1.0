using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
    public partial class QMS_M035 : ObjectBase
    {
        public string sample_scheme { get; set; }
        public string desc { get; set; }
        public string ind_attr_insp { get; set; }
        public string ind_var_insp { get; set; }
        public string without_val_para { get; set; }
        public string ind_lot_based_insp { get; set; }
        public string interval_rel_insp { get; set; }
        public string ind_item_level_para { get; set; }
        public string ind_aql_val { get; set; }
        public string ind_sc_used { get; set; }
        public string intd_sc_not_used { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string t_status { get; set; }
        public string lang_key { get; set; }
        public Nullable<int> aql_value { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string XmlDataDocument_QMS_M035_Flip { get; set; }
        public string XmlDataDocument_QMS_M035_A { get; set; }
    }

    public partial class QMS_M035_A
    {
        public int id { get; set; }
        public string sample_scheme { get; set; }
        public Nullable<int> sample_item_counter { get; set; }
        public string insp_severity { get; set; }
        public Nullable<int> lot_size { get; set; }
        public Nullable<int> no_of_units { get; set; }
        public Nullable<int> no_of_samples { get; set; }
        public Nullable<int> accept_no { get; set; }
        public Nullable<int> reject_no { get; set; }
        public Nullable<int> accept_no2 { get; set; }
        public Nullable<int> reject_no2 { get; set; }
        public Nullable<int> accept_no3 { get; set; }
        public Nullable<int> reject_no3 { get; set; }
        public Nullable<int> accept_no4 { get; set; }
        public Nullable<int> reject_no4 { get; set; }
        public Nullable<int> accept_no5 { get; set; }
        public Nullable<int> reject_no5 { get; set; }
        public Nullable<int> accept_no6 { get; set; }
        public Nullable<int> reject_no6 { get; set; }
        public Nullable<int> accept_no7 { get; set; }
        public Nullable<int> reject_no7 { get; set; }
        public string k_factor { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string t_status { get; set; }
        public string lang_key { get; set; }
        public string client { get; set; }
        public Nullable<int> sample_size { get; set; }
    }
}
