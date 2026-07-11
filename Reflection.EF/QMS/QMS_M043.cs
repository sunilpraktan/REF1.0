using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
    public partial class QMS_M043 : ObjectBase
    {
        public string sd_no { get; set; }
        public Nullable<int> version_no { get; set; }
        public Nullable<System.DateTime> valid_from { get; set; }
        public Nullable<int> sample_size { get; set; }
        public Nullable<bool> ind_use_sdp { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string Location_Id { get; set; }
        public string t_status { get; set; }
        public string lang_key { get; set; }
        public string comp_code { get; set; }
        public string XmlDataDocument_QMS_M043_A { get; set; }
        public string XmlDataDocument_QMS_M043_Flip { get; set; }
    }

    public partial class QMS_M043_A
    {
        public int id { get; set; }
        public string sd_no { get; set; }
        public Nullable<int> version_no { get; set; }
        public Nullable<int> Item_no { get; set; }
        public string lot_container { get; set; }
        public string u_part_samp_no { get; set; }
        public string samp_container_pr { get; set; }
        public string sample_scheme_pr { get; set; }
        public string insp_sever_pr { get; set; }
        public string aql_value_pr { get; set; }
        public Nullable<int> fix_no_pr { get; set; }
        public Nullable<int> size_factor_pr { get; set; }
        public string formula_pr { get; set; }
        public string samp_container_res { get; set; }
        public Nullable<int> samp_no_res { get; set; }
        public Nullable<int> samp_size_res { get; set; }
        public string unit_code_res { get; set; }
        public string samp_container_pool { get; set; }
        public string sample_scheme_pool { get; set; }
        public string insp_sever_pool { get; set; }
        public string aql_value_pool { get; set; }
        public string fix_no_pool { get; set; }
        public Nullable<int> size_factor_pool { get; set; }
        public string formula_pool { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string Location_Id { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string t_status { get; set; }
        public string lang_key { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }

    }
}
