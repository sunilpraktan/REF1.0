namespace Reflection.EF.Settings
{
    public class SYS_C005 : ObjectBase
    {
        public int id { get; set; }
        public string def_culture { get; set; }
        public string time_zone { get; set; }
        public string date_format { get; set; }
        public string date_separator { get; set; }
        public int decimal_digits { get; set; }
        public string round_up_method_code { get; set; }
        public bool value_suffix { get; set; }
        public string theme_code { get; set; }
        //public byte[] desktop_file { get; set; }
        public bool round_up { get; set; }
        public bool curr_notation { get; set; }
        public string doc_cat { get; set; }
        public string UserId { get; set; }
        public string field_name { get; set; }
        public bool active { get; set; }
        //Scalar
        public string date_sample { get; set; }
        public string def_culture_name { get; set; }
        public string decimal_format_code { get; set; }
        public string round_up_method_name { get; set; }
        public string sample_decimal_value { get; set; }
        public string sample_curr { get; set; }
        public string doc_desc { get; set; }
    }
}