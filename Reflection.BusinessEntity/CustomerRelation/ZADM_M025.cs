using System;


namespace Reflection.BusinessEntity
{
    public partial class ZADM_M025
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public System.DateTime doc_date { get; set; }
        public Nullable<decimal> sumtotalarea { get; set; }
        public Nullable<decimal> sumtotalwaste { get; set; }
        public System.DateTime add_date { get; set; }
        public Nullable<DateTime> edit_date { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string add_by { get; set; }
        public string editby { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }

        public string cust_name { get; set; }
        public string site_name { get; set; }
        public string po_no { get; set; }
        public Nullable<DateTime> po_date { get; set; }

        public string approved_by { get; set; }
        public string mes_taken_by { get; set; }
        public string mobile_no { get; set; }
        public string email_id { get; set; }
        public string designation { get; set; }
        public string remark { get; set; }
        public string LoctnNm { get; set; }

    }
    public partial class ZADM_M025_A
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public Nullable<decimal> width { get; set; }
        public Nullable<decimal> height { get; set; }
        public Nullable<int> panna { get; set; }
        public Nullable<decimal> pannavalue { get; set; }
        public Nullable<decimal> roundup { get; set; }
        public Nullable<decimal> totalwidth { get; set; }
        public Nullable<decimal> extraheight { get; set; }
        public Nullable<decimal> totalheight { get; set; }
        public Nullable<decimal> totalactualarea { get; set; }
        public Nullable<decimal> totalwastage { get; set; }
        public string unit_code { get; set; }
        public string area_name { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> bal_piece_width { get; set; }
        public Nullable<decimal> bal_piece_height { get; set; }
        public Nullable<decimal> total_bal_piece { get; set; }


    }
    public  class ZADM_M025_Flip
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public System.DateTime doc_date { get; set; }

        public string doc_cat { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public Nullable<decimal> width { get; set; }
        public Nullable<decimal> height { get; set; }
        public Nullable<int> panna { get; set; }
        public Nullable<decimal> pannavalue { get; set; }
        public Nullable<decimal> totalactualarea { get; set; }
        public Nullable<decimal> totalwastage { get; set; }
        public Nullable<decimal> sumtotalarea { get; set; }
        public Nullable<decimal> sumtotalwaste { get; set; }
        public string unit_code { get; set; }



    }

}
