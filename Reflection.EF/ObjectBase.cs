using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF
{
    public class ObjectBase
    {
        public string ts_code { get; set; }
        public string ts_name { get; set; }
        public string userid { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public string color_code { get; set; }
        public bool? auto_roundup { get; set; }
        public int? roundup_digits { get; set; }
        public DateTime? t_date { get; set; } // Transaction Date for add_date/edit_date
        public bool? copy { get; set; }
        public string ind_code { get; set; } // can be use as bool for active, True, False or any other purpose for Transaction. we can use for copy function also.
        public string ind_value { get; set; }
        //public string qr_code { get; set; } // commented because derived class have same value
        //public byte[] qr_image { get; set; } // commented because derived class have same value
        public string client { get; set; }
        //public string comp_code { get; set; }
        //public string location_Id { get; set; }
        //public string t_display { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        //public bool? active { get; set; }
        //public string t_status { get; set; }
        public string session_id { get; set; }
        public string search_key { get; set; } // Use this field to search reference record from popup with this key field to standardise pupup function.need to set value from SQL Query and then use this in LINQ query in VM Insert.... Function. REF Implementation : EPR_T001_VM_STD, CollectSelectedReferenceDocuments Function. Benifit: We can use different fields for common Selection Key value if Multiple UNION Queries exists just like example we will filter with record number values and after selection found using other fileds to set on Transaction BE.
        public string search_key1 { get; set; } // Use this field to search reference record from popup with this key field to standardise pupup function.need to set value from SQL Query and then use this in LINQ query in VM Insert.... Function. REF Implementation : EPR_T001_VM_STD, CollectSelectedReferenceDocuments Function. Benifit: We can use different fields for common Selection Key value if Multiple UNION Queries exists just like example we will filter with record number values and after selection found using other fileds to set on Transaction BE.
        public string search_key2 { get; set; } // Use this additional key if multiple filters exists. 

        public string value_key { get; set; }
        public string value_code { get; set; }
        public string value_name { get; set; }
        public string key_code { get; set; }// common master code field, use this for master popup loading to avoide too much fields declaration.
        public string key_name { get; set; }// common master code Description field, use this for master popup loading to avoide too much fields declaration.
        public string key_value { get; set; }
    }
}
