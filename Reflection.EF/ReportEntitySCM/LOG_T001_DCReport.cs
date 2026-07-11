using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM.ReportEntitySCM
{
    public class LOG_T001_DCReport
    {

        public int id { get; set; }
        public string delivery_no { get; set; }
        public string delivery_date { get; set; }
        public Nullable<int> ship_to { get; set; }
        public Nullable<int> sold_to { get; set; }
        public string doc_cat { get; set; }
        public string shipment_mode { get; set; }
        public string sold_toParty { get; set; }
        public string TransporterNm { get; set; }
        public string LoctnNm { get; set; }
        public string CompName { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string PhOffi { get; set; }
        public string FaxNo { get; set; }
        public string MailId { get; set; }
        public string VATNo { get; set; }
        public string CSTNo { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string PAdd1 { get; set; }
        public string PCity { get; set; }
        public string PartyPin { get; set; }
        public string PVATNo { get; set; }
        public string VATDate { get; set; }
        public string PCSTNo { get; set; }
        public string DelivryAdd { get; set; }

        public string CSTDate { get; set; }
        public string Prty_CntryName { get; set; }
        public string Pety_StatName { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string grade { get; set; }
        public string itemcode { get; set; }
        public string carton_no { get; set; }
        public string UOMNm { get; set; }
        public decimal qty { get; set; }
        public string invoicedate { get; set; }
        public string ladding_bill { get; set; }
        public string ladding_date { get; set; }

        public string bill_doc { get; set; }
        public string form_type { get; set; }

        public string Item_desc { get; set; }
        public int NoOfPkgs { get; set; }
        public string pack_no { get; set; }
        public string PrtyPhNo { get; set; }
        public string PrtyFaxNo { get; set; }
        public string CntryName { get; set; }
        public string dest_countryNm { get; set; }
        public string pre_carrage { get; set; }
        public string pre_carrage_place { get; set; }
        public string cf_agentNm { get; set; }
        public string vess_flight { get; set; }
        public string port_load { get; set; }
        public string port_desc { get; set; }
        public string port_final { get; set; }
        public string final_dest { get; set; }
        public string pack_rem { get; set; }
        public string marks { get; set; }
        public string container_no { get; set; }
        public string KindOfPkgs { get; set; }
        public Nullable<decimal> gross_wt { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public string ship_terms { get; set; }
        public string so_no { get; set; }
        public string ship_toParty { get; set; }
        public string CorporateNo { get; set; }
        public string CentralExNo { get; set; }
        public string CentralExDate { get; set; }
        public string regdoff { get; set; }
        public byte[] CompLogo { get; set; }


    }
}
