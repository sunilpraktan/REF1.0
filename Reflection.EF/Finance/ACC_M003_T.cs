using System;

namespace Reflection.EF.Finance
{
   public partial class ACC_M003_T //Account Determination Entity Class
    {
        public int id { get; set; }
        public string trns_key_code { get; set; }       
        public string gl_code_d { get; set; }
        public string gl_code_c { get; set; }    
        public string coa_key { get; set; }      
        public string value_group { get; set; }
        public string acc_var { get; set; }    
        public string value_class { get; set; }
        public string client { get; set; }
        public string tax_code { get; set; }
        public string buss_place { get; set; }
        public string comp_code { get; set; }
       
        //scalar
        public string TranCode { get; set; }
        public string doc_desc { get; set; }
        public string group_desc { get; set; }     
        public string gl_desc { get; set; }
        public string gl_desc_c { get; set; }
        public string gl_desc_d { get; set; }
        public string tax_code_desc { get; set; }
        public string buss_Place_desc { get; set; }
        public string XmlDataDocument_ACC_M003_T { get; set; }
    }
}
