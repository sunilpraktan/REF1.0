using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Reflection.EF.Admin
{
    public class GenericPartialClasses_Admin
    {

    }

    public partial class ZADM_M009
    {
        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public partial class ADM_M009 //Role Master
    {
        public string XmlDataDocument { get; set; }
    }
    public partial class ADM_M010 //User Master
    {
        public string XmlDataDocument { get; set; }
    }
    public partial class ADM_M028
    {
        public string XmlDocument { get; set; }
        public string XmlDataDocument_ADM_M028_C { get; set; }
        public string XmlDataDocument_ADM_M028_D { get; set; }
        public string XmlDataDocument_ADM_M028FLIP { get; set; }

    }
    public partial class ADM_M028_F
    {        
        public string XmlDataDocument_ADM_M028_G { get; set; }
        public string XmlDataDocument_ADM_M028_F_Flip { get; set; }
    }
    public partial class ADM_M036 //User Master
    {
        public string XmlDataDocument { get; set; }
    }       
    public partial class ACC_T001A
    {
        public string xdoc_ACC_T001_A { get; set; }
        public string xdoc_ACC_T001_B { get; set; }
    }
    public partial class ADM_M038
    {
        public int Index { get; set; }
        public string XmlDataDocument { get; set; }
    }

    public partial class ADM_M032Flip
    {
        public int MakeCode { get; set; }
        public string Make { get; set; }
        public string Descriptn { get; set; }
        public string make_type { get; set; }

    }
    public partial class ADM_M032
    {
        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public partial class ADM_M022
    {
        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public partial class ZADM_M010
    {
        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public partial class ZADM_M008Flip
    {
        public string total_len { get; set; }
        public string details { get; set; }
        public int tot_len_id { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }

    }
  
    public partial class ZADM_M008
    {
        public string XmlDataDocument_FlipGrid { get; set; }
    }

    public class ADM_M038_Delete
    {
        public int Index { get; set; }
        public int id { get; set; }
    }
    public partial class ADM_M043
    {
        public string XmlDataDocument_ADM_M043_A { get; set; }
    }
    public partial class ZADM_M026
    {
        public string XmlDataDocument_FlipGrid { get; set; }
        public string XmlDataDocument_ItemsEntity { get; set; }
    }
    public partial class ZADM_M027
    {
        public string XmlDataDocument_ZADM_M027 { get; set; }
        public string XmlDataDocument_ZADM_M027_A { get; set; }
    }    
    //public partial class ACC_M007
    //{
    //    public string XmlDataDocument_ACC_M007FLIP { get; set; }
    //    public string XmlDataDocument_ACC_M007B { get; set; }
    //}
    public partial class ENG_T003
    {
        public string XmlDataDocument_ENG_T003FLIP { get; set; }       
    }
    public partial class ADM_M053
    {
        public string XmlDocument { get; set; }
        public string XmlDataDocument_ADM_M055 { get; set; }
        public string XmlDataDocument_ADM_M057 { get; set; }
        public string XmlDataDocument_ADM_M053Flip { get; set; }

    }
    public partial class ADM_M054
    {
        public string XmlDocument { get; set; }
        public string XmlDataDocument_ADM_M055 { get; set; }
        public string XmlDataDocument_ADM_M057 { get; set; }
        public string XmlDataDocument_ADM_M054Flip { get; set; }

    }
    public partial class ADM_M002_A
    {        
        public string XmlDataDocument_ADM_M002_A_Flip { get; set; }
    }
    public partial class ADM_M058
    {        
        public string XmlDataDocument_ADM_M058_A { get; set; }
        public string XmlDataDocument_ADM_M058_Flip { get; set; }
    }
}
