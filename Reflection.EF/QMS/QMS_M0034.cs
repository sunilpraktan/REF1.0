using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
    public partial class QMS_M0034 : ObjectBase
    {
        public string sp_code { get; set; }
        public string sp_desc { get; set; }
        public string sample_type { get; set; }
        public string sp_type_desc { get; set; }
        public string valuation_mode { get; set; }
        public string multi_sample { get; set; }
        public Nullable<int> multi_sample_no { get; set; }
        public Nullable<int> no_of_units { get; set; }
        public Nullable<int> accept_no { get; set; }
        public string k_factor { get; set; }
        public string sp_used { get; set; }
        public string sample_scheme { get; set; }
        public string insp_severity { get; set; }
        public decimal? sample_size { get; set; }
        public Nullable<decimal> accept_no_per { get; set; }
        public string ind_insp_point { get; set; }
        public Nullable<int> insp_freq { get; set; }
        public Nullable<int> aql_value { get; set; }
        public string control_chart_type { get; set; }
        public string comp_code { get; set; }
        public string active { get; set; }
        public string location_id { get; set; }
        public string t_status { get; set; }
        public string lang_key { get; set; }
        //public string XmlDataDocument_QMS_M034_Flip { get; set; }
        public string sample_size_uom { get; set; }
        //Scalar
        public string scheme_name { get; set; }
        public string severity_name { get; set; }
        public string mode_name { get; set; }
        public string type_name { get; set; } // sample_type_name
    }
}
