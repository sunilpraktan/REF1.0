using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ZADM_M026 : ObjectBase
    {
        public int id { get; set; }
        public string supplier_id { get; set; }    
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string ink_code { get; set; }       
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string SupplierNm { get; set; }   
        public string ItemNm { get; set; }
        public string SubCatCode { get; set; }
        public Nullable<bool> StockUnt { get; set; }
        public string parametervalue { get; set; }     
        public string customer_id { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string CustomerNm { get; set; }
    }
}
