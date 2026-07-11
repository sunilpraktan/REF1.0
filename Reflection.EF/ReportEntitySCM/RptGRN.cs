using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM.ReportEntitySCM
{
    public class RptGRN
    {
        public string doc_no { get; set; }
        public Nullable<DateTime> doc_date { get; set; }
        public string CSTNo { get; set; }
        public string VATNo { get; set; }
        public string PanNo { get; set; }
        public string service_tax_no { get; set; }
       public string mov_name { get; set; } 
        public string transport_party { get; set; }
        public string ItemCode { get; set; }
        public string description { get; set; }
        public string sku_desc { get; set; }
        public string unit_code { get; set; }
        public decimal? qty { get; set; }
        public decimal? challan_qty { get; set; }
        public decimal? unit_price { get; set; }
        public decimal? Amount { get; set; }
        public string PartyNm { get; set; }
        public string notes { get; set; }
        public string ge_no { get; set; }
        public string ref_doc { get; set; }
        public string PartyAdd { get; set; }
        public string PlantNm { get; set; }
        public string PlantAdd { get; set; }
        public string Ref_Doc_No { get; set; }
        public string del_note { get; set; }
        public Nullable<DateTime> del_note_date { get; set; }
        public string bill_ladding { get; set; }
        public Nullable<DateTime> bill_ladding_dt { get; set; }
        public Nullable<DateTime> ge_date { get; set; }
        public Nullable<DateTime> ref_doc_date { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string city { get; set; }
        public string StatName { get; set; }
        public string CntryName { get; set; }
        public string PinCode { get; set; }
        public string sending_plant { get; set; }
        public string LoctnNm { get; set; }
        public string Add1L { get; set; }
        public string Add2L { get; set; }
        public string CityL { get; set; }
        public string PinCodeL { get; set; }
        public string state_code { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public string state_name { get; set; }
        public string PartyId { get; set; }
        public string vendor { get; set; }
        public string sku { get; set; }
        public string address { get; set; }
        public string transporter_name { get; set; }
        public string gstinno { get; set; }
        public Nullable<System.DateTime> gstindate { get; set; }
        public string soldto_buss_place { get; set; }
        public string hs_code { get; set; }
        public string rec_plant { get; set; }
        public string sending_plant_name { get; set; }
        public string rec_plant_name { get; set; }
        public string rec_plant_address { get; set; }
        public string batch_no { get; set; }

        //Waybill Details

        public string way_bill_no { get; set; }
        public Nullable<System.DateTime> way_bill_date { get; set; }
        public decimal? way_bill_value { get; set; }
        public string doc_format { get; set; }
        public string textdata { get; set; }
    }
}
