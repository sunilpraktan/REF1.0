using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity
{
    public class TranHistoryRptEntity
    {

        public string PartyNm { get; set; }
        public string ItemCode { get; set; }

        //Sales Activity
        public string Activity_doc_no { get; set; }
        public DateTime? Activity_doc_date { get; set; }

        //Sales Inquiry
        public string Inq_sono { get; set; }
        public DateTime? Inq_sodate { get; set; }
        public decimal? Inq_amount { get; set; }
        public string Inq_party_name { get; set; }
        public string Inq_ItemCode { get; set; }
        public string Inq_Description { get; set; }

        //Sales Quotation
        public string Qtn_sono { get; set; }
        public DateTime? Qtn_sodate { get; set; }
        public string Qtn_party_name { get; set; }
        public string Qtn_ItemCode { get; set; }
        public string Qtn_Description { get; set; }
        public decimal? Qtn_amount { get; set; }


        //Sales Order
        public string SO_sono { get; set; }
        public DateTime? SO_sodate { get; set; }
        public string SO_party_name { get; set; }
        public decimal? SO_amount { get; set; }
        public string SO_ItemCode { get; set; }
        public string SO_Description { get; set; }

        //Proforma Invoice
        public string Proforma_no { get; set; }
        public DateTime? Proforma_sodate { get; set; }
        public string Proforma_PartyNm { get; set; }
        public decimal? Proforma_amount { get; set; }
        public string Proforma_ItemCode { get; set; }
        public string Proforma_Description { get; set; }

        //Delivery Note
        public string Delivery_no { get; set; }
        public DateTime? Delivery_sodate { get; set; }
        public string Delivery_PartyNm { get; set; }
        public decimal? Delivery_amount { get; set; }
        public string Delivery_ItemCode { get; set; }
        public string Delivery_Description { get; set; }

        //Sales Invoice
        public string Sel_Inv_no { get; set; }
        public DateTime? Sel_Inv_sodate { get; set; }
        public string Sel_Inv_PartyNm { get; set; }
        public decimal? Sel_Inv_amount { get; set; }
        public string Sel_Inv_ItemCode { get; set; }
        public string Sel_Inv_Description { get; set; }

        //Payement Received
        public string Acc_doc_no { get; set; }
        public DateTime? Acc_doc_date { get; set; }
        public string Acc_party_name { get; set; }
        public decimal? Acc_amount { get; set; }
        public string Acc_ItemCode { get; set; }
        public string Acc_Description { get; set; }


        //Purchase order
        public string PO_doc_no { get; set; }
        public DateTime? PO_doc_date { get; set; }
        public string PO_party_name { get; set; }
        public decimal? PO_amount { get; set; }
        public string PO_ItemCode { get; set; }
        public string PO_Description { get; set; }

        //Purchase Requestion
        public string PR_doc_no { get; set; }
        public DateTime? PR_date { get; set; }
        public string PR_party_name { get; set; }
        public decimal? PR_amount { get; set; }
        public string PR_ItemCode { get; set; }
        public string PR_Description { get; set; }

        //Purchase Invoice
        public string PI_doc_no { get; set; }
        public DateTime? PI_date { get; set; }
        public string PI_party_name { get; set; }
        public decimal? PI_amount { get; set; }
        public string PI_ItemCode { get; set; }
        public string PI_Description { get; set; }

        //Payment Made
        public string PM_doc_no { get; set; }
        public DateTime? PM_date { get; set; }
        public string PM_party_name { get; set; }
        public decimal? PM_amount { get; set; }
        public string PM_ItemCode { get; set; }
        public string PM_Description { get; set; }
    }
}
