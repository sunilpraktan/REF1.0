using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
    class GeneralPartialClasseQMS
    {
    }
    public partial class EQCR_T001_A
    {
        public string XmlDataDocument_EQCR_T001_B { get; set; }
        public string XmlDataDocument_EQCR_T001_C { get; set; }
    }
    public partial class QMS_T001
    {
        public string XmlDataDocument_QMS_T001Flip { get; set; }
        public string XmlDataDocument_QMS_T001_A { get; set; }
        public string XmlDataDocument_QMS_T001_B { get; set; }
        public string XmlDataDocument_QMS_T001_C { get; set; }
        public string XmlDataDocument_QMS_M003_B { get; set; }
        public string XmlDataDocument_QMS_M009_B { get; set; }
        public string XmlDataDocument_QMS_M009_C { get; set; }
        public string XmlDataDocument_QMS_M009_D { get; set; }
        public string XmlDataDocument_QMS_M009_E_M { get; set; }
        public string XmlDataDocument_QMS_M009_E_I { get; set; }
        public string XmlDataDocument_QMS_T001_E { get; set; }
        public string XmlDataDocument_QMS_T001_F { get; set; }
        public string XmlDataDocument_QMS_M009_J { get; set; }
    }
    public partial class QMS_T002
    {
        public string XmlDataDocument_QMS_T002_A { get; set; }
        public string XmlDataDocument_QMS_T002_B { get; set; }
        public string XmlDataDocument_QMS_T002_C { get; set; }
        public string XmlDataDocument_QMS_T002_D { get; set; }
        public string XmlDataDocument_QMS_T002Flip { get; set; }
    }
    public partial class QMS_M009_A //Test Identification Master
    {
        public string XmlDataDocument_QMS_M009Flip { get; set; }
        public string XmlDataDocument_QMS_M009_B { get; set; }
        public string XmlDataDocument_QMS_M009_C { get; set; }
        public string XmlDataDocument_QMS_M009_D { get; set; }
        public string XmlDataDocument_QMS_M009_E_M { get; set; }
        public string XmlDataDocument_QMS_M009_E_I { get; set; }
        public string XmlDataDocument_QMS_M009_F { get; set; }
        public string XmlDataDocument_QMS_M009_G { get; set; }
        public string XmlDataDocument_QMS_M009_H { get; set; }
        public string XmlDataDocument_QMS_M009_I { get; set; }
        public string XmlDataDocument_QMS_M009_J { get; set; }
        public string XmlDataDocument_QMS_M009_K { get; set; }
    }
    public partial class QMS_M002
    {
        public string XmlDataDocument_QMS_M002FLIP { get; set; }
    }
    public partial class QMS_M001
    {
        public string XmlDataDocument_QMS_M001FLIP { get; set; }
    }

    public partial class QMS_M009_FFlip
    {

        public string para_code { get; set; }
        public string para_name { get; set; }
        public string catlog_code { get; set; }
        public Nullable<System.DateTime> valid_from { get; set; }
        public string t_status { get; set; }
    }

    public partial class QMS_M009_GFlip
    {
        public string value_code { get; set; }
        public string para_value { get; set; }
        public string para_code { get; set; }
        public string para_type { get; set; }
        public string t_status { get; set; }
        public string para_name { get; set; }
        public string group_name { get; set; }
    }
    public partial class QMS_M030_J
    {
        public string XmlDataDocument_FlipGrid { get; set; }
    }
}
