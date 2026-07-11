using System;

namespace Reflection.EF.ReflectionSystem
{
    public partial class SYS_M002 : ObjectBase
    {
        public int id { get; set; }
        public string doc_type { get; set; }
        public string doc_type_user { get; set; }
        public string doc_type_doc_no { get; set; }
        public string doc_desc { get; set; }
        public string doc_desc_user { get; set; }
        public string doc_cat { get; set; }
        public bool? default_doc { get; set; }
        public string delivery_type { get; set; }
        public string billing_type { get; set; }
        public string report_name { get; set; }
        public string doc_no_format { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public int range1 { get; set; }
        public int? range2 { get; set; }
        public int doc_no_digits { get; set; }
        public string TranCode { get; set; }
        public string report_no { get; set; }
        public string posting_key { get; set; }
        public bool acc_type_A { get; set; }
        public bool acc_type_B { get; set; }
        public bool acc_type_C { get; set; }
        public bool acc_type_D { get; set; }
        public bool acc_type_E { get; set; }
        public string ts_code_mi { get; set; }
        public string mov_tp_mi { get; set; }
        public string ind_digital { get; set; }


    }
    public partial class SYS_M015 : ObjectBase
    {
        public int? id { get; set; }
        public string doc_type { get; set; }
        public string doc_type_user { get; set; }
        public string doc_type_doc_no { get; set; }
        public string doc_desc { get; set; }
        public string doc_desc_user { get; set; }
        public string doc_cat { get; set; }
        public bool? default_doc { get; set; }
        public string delivery_type { get; set; }
        public string billing_type { get; set; }
        public string report_name { get; set; }
        public string doc_no_format { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public int? range1 { get; set; }
        public int? range2 { get; set; }
        public int? doc_no_digits { get; set; }
        public string TranCode { get; set; }
        public string report_no { get; set; }
        public string posting_key { get; set; }
        public bool? acc_type_A { get; set; }
        public bool? acc_type_B { get; set; }
        public bool? acc_type_C { get; set; }
        public bool? acc_type_D { get; set; }
        public bool? acc_type_E { get; set; }

    }

    public class SYS_DOC_CAT
    {
        public string doc_cat { get; set; }
        public string cat_name { get; set; }
        public string mov_tp { get; set; }
        public string ref_doc_cat { get; set; }
    }
    public class SYS_DOC_TYPE
    {
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string doc_desc { get; set; }
        public string mov_tp { get; set; }
    }
}

