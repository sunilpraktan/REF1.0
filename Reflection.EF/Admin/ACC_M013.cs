using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ACC_M013 : ObjectBase
    {
        public int id { get; set; }
        public Nullable<int> ref_base_code_id { get; set; }
        public string domain { get; set; }
        public string description { get; set; }
        public Nullable<int> ref_tax_code_id { get; set; }
        public int sequence { get; set; }
        public Nullable<int> account_paid_id { get; set; }
        public Nullable<decimal> ref_base_sign { get; set; }
        public string type_tax_use { get; set; }
        public Nullable<int> base_code_id { get; set; }
        public Nullable<decimal> base_sign { get; set; }
        public Nullable<bool> child_depend { get; set; }
        public Nullable<bool> include_base_amount { get; set; }
        public Nullable<int> account_analytic_collected_id { get; set; }
        public Nullable<int> account_analytic_paid_id { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<decimal> ref_tax_sign { get; set; }
        public string applicable_type { get; set; }
        public Nullable<int> account_collected_id { get; set; }
        public string location_Id { get; set; }
        public string t_name { get; set; }
        public Nullable<int> tax_code_id { get; set; }
        public Nullable<int> parent_id { get; set; }
        public decimal amount { get; set; }
        public string python_compute { get; set; }
        public Nullable<decimal> tax_sign { get; set; }
        public string python_compute_inv { get; set; }
        public string python_applicable { get; set; }
        public string t_type { get; set; }
        public Nullable<bool> price_include { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string edit_by { get; set; }
        public string tax_code { get; set; }

        //scalar fields

        public string p_name { get; set; }

        public string p_code { get; set; }

        public string t_code { get; set; }
        
        public string AccBaseCd { get; set; }
        public string AccTaxCd { get; set; }
        public string RefBaseCd { get; set; }
        public string RefTaxCd { get; set; }
        public string InvocTaxAcc { get; set; }
        public string RefTaxAcc { get; set; }
    }

}
