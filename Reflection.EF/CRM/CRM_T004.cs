using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class CRM_T004 : ObjectBase
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public System.DateTime doc_date { get; set; }
        public Nullable<System.DateTime> clouser_date { get; set; }
        public string EmpId { get; set; }
      
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string client { get; set; }
        public string language { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public string plant { get; set; }
        public string company { get; set; }
        public string EmpName { get; set; }//scaler field
        public string monthyear { get; set; }  
        public string CompanyNm { get; set; }
        public string LocationNm { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
    }

    public partial class CRM_T004_A
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string week_no { get; set; }
        public Nullable<System.DateTime> week_date { get; set; }
        public string PartyId { get; set; }  
        public string PartyType { get; set; }
        public string project_name { get; set; }
        public string site_location { get; set; }
        public Nullable<System.DateTime> project_date { get; set; }
        public Nullable<decimal> value1 { get; set; }
        public string value2 { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string t_status { get; set; }
        public string remark { get; set; }
        public int prevoius { get; set; }
        public int first { get; set; }
        public string parent_no { get; set; }
        public Nullable<decimal> area { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<bool> active { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public string PartyNm { get; set; }//scaler field
        public string ref_doc_type { get; set; }
        public string ref_doc_cat { get; set; }
        public Nullable<System.DateTime> ref_doc_date { get; set; }
        public string ref_doc_no { get; set; }
        


    }
}
