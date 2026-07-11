using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM.ReportEntityCRM
{
    public class MIS_CRM_SalesEntity3
    {
        public string Closed_By { get; set; }
        public string sono { get; set; }
        public DateTime? sodate { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string doc_desc_user { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string EmpId { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public decimal? quantity { get; set; }
        public decimal? unit_price { get; set; }
        public decimal? amount { get; set; }
        public string curr_code { get; set; }
        public string buyer_name { get; set; }
        public string unit_code { get; set; }
        public string seller_name { get; set; }
        public decimal? tax_amt { get; set; }
        public string project_name { get; set; }
        public string project_type { get; set; }
        public string bill_doc { get; set; }
        public string ref_doc_no { get; set; }
        public string PartyNm { get; set; }
        public decimal? tax_amount { get; set; }
        public decimal? sub_total { get; set; }
        public decimal? roundup_total { get; set; }
        public decimal? received_amt { get; set; }
        public decimal? outstanding_amt { get; set; }
        public string cust_ref { get; set; }
        public DateTime? cust_ref_date { get; set; }

        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public string site_name { get; set; }
        public string po_no { get; set; }
        public DateTime? po_date { get; set; }
        public Nullable<decimal> totalactualarea { get; set; }
        public Nullable<decimal> totalwastage { get; set; }
        public string mes_taken_by { get; set; }
        public string approved_by { get; set; }
        public string remark { get; set; }
        public Nullable<decimal> total_bal_piece { get; set; }
        public Nullable<decimal> sumtotalarea { get; set; }
        public Nullable<decimal> sumtotalwaste { get; set; }
        public string area_name { get; set; }
        public Nullable<decimal> width { get; set; }
        public Nullable<decimal> height { get; set; }
        public Nullable<int> panna { get; set; }
        public Nullable<decimal> pannavalue { get; set; }
        public Nullable<decimal> bal_piece_width { get; set; }
        public Nullable<decimal> bal_piece_height { get; set; }
        public Nullable<decimal> roundup { get; set; }
        public Nullable<decimal> totalwidth { get; set; }
        public Nullable<decimal> extraheight { get; set; }
        public Nullable<decimal> totalheight { get; set; }

        public string travel_from { get; set; }
        public string travel_to { get; set; }
        public decimal? dist_in_km { get; set; }
        public decimal? approved_amt { get; set; }
        public DateTime? expenses_date { get; set; }
        public string t_status { get; set; }
        public string doc_curr { get; set; }
        public string status_remark { get; set; }
        //Expence Voucher
        public decimal? advance { get; set; }
        public string EmpName { get; set; }
        public string location { get; set; }
        public string additional_person { get; set; }
        public decimal? bal_amount { get; set; }
        public decimal? grand_total { get; set; }
        public string CustomerNm { get; set; }
        public string transport_mode { get; set; }
        public string food_expense { get; set; }
        public decimal? food_exp_amt { get; set; }
        public string misc_detail { get; set; }
        public decimal? misc_amt { get; set; }
        public string print_stat { get; set; }
        public decimal? print_stat_amt { get; set; }
        public string other_expense { get; set; }
        public decimal? other_exp_amt { get; set; }
        public Nullable<int> agevar { get; set; }
        public string project_location { get; set; }
        public string Location { get; set; }
        public string competitor_name { get; set; }
        public decimal? extra_charges { get; set; }


        //Transaction History***************************************
        //Dispatch Order
        public decimal? so_qty { get; set; }
        public decimal? sch_qty { get; set; }
        public decimal? sch_bal_qty { get; set; }
        public decimal? do_qty { get; set; }
        public decimal? do_bal_qty { get; set; }
        

        //Sales Activity
        public string Activity_doc_no { get; set; }
        public DateTime? Activity_doc_date { get; set; }
        public string Act_party_name_A { get; set; }
        public string Activity_t_status { get; set; }

        //Sales Inquiry
        public string Inq_sono { get; set; }
        public DateTime? Inq_sodate { get; set; }
        public decimal? Inq_amount { get; set; }
        public string Inq_party_name { get; set; }
        public string Inq_ItemCode { get; set; }
        public string Inq_Description { get; set; }
        public string Inq_t_status { get; set; }
        public string Inq_unitcode { get; set; }

        //Sales Quotation
        public string Qtn_sono { get; set; }
        public DateTime? Qtn_sodate { get; set; }
        public string Qtn_party_name { get; set; }
        public string Qtn_ItemCode { get; set; }
        public string Qtn_Description { get; set; }
        public decimal? Qtn_amount { get; set; }
        public string Qtn_t_status { get; set; }
        public string Qtn_unitcode { get; set; }


        //Sales Order
        public string SO_sono { get; set; }
        public DateTime? SO_sodate { get; set; }
        public string SO_party_name { get; set; }
        public decimal? SO_amount { get; set; }
        public string SO_ItemCode { get; set; }
        public string SO_Description { get; set; }
        public string SO_t_status { get; set; }
        public string SO_unitcode { get; set; }


        //Proforma Invoice
        public string Proforma_no { get; set; }
        public DateTime? Proforma_sodate { get; set; }
        public string Proforma_PartyNm { get; set; }
        public decimal? Proforma_amount { get; set; }
        public string Proforma_ItemCode { get; set; }
        public string Proforma_Description { get; set; }
        public string Proforma_t_status { get; set; }
        public string Proforma_unitcode { get; set; }

        //Delivery Note
        public string Delivery_no { get; set; }
        public DateTime? Delivery_sodate { get; set; }
        public string Delivery_PartyNm { get; set; }
        public decimal? Delivery_amount { get; set; }
        public string Delivery_ItemCode { get; set; }
        public string Delivery_Description { get; set; }
        public string Delivery_t_status { get; set; }
        public string Delivery_unitcode { get; set; }

        //Sales Invoice
        public string Sel_Inv_no { get; set; }
        public DateTime? Sel_Inv_sodate { get; set; }
        public string Sel_Inv_PartyNm { get; set; }
        public decimal? Sel_Inv_amount { get; set; }
        public string Sel_Inv_ItemCode { get; set; }
        public string Sel_Inv_Description { get; set; }
        public string Sel_Inv_t_status { get; set; }
        public string Sel_Inv_unitcode { get; set; }

        //Payement Received
        public string Acc_doc_no { get; set; }
        public DateTime? Acc_doc_date { get; set; }
        public string Acc_party_name { get; set; }
        public decimal? Acc_amount { get; set; }
        public string Acc_ItemCode { get; set; }
        public string Acc_Description { get; set; }
        public string Acc_t_status { get; set; }


        //Purchase order
        public string PO_doc_no { get; set; }
        public DateTime? PO_doc_date { get; set; }
        public string PO_party_name { get; set; }
        public decimal? PO_amount { get; set; }
        public string PO_ItemCode { get; set; }
        public string PO_Description { get; set; }
        public string PO_t_status { get; set; }
        public string PO_unitcode { get; set; }

        //Purchase GRN
        public string GRN_doc_no { get; set; }
        public DateTime? GRN_doc_date { get; set; }
        public string GRN_party_name { get; set; }
        public decimal? GRN_amount { get; set; }
        public string GRN_ItemCode { get; set; }
        public string GRN_Description { get; set; }
        public string GRN_t_status { get; set; }
        public string GRN_unitcode { get; set; }

        //Purchase Requestion
        public string PR_doc_no { get; set; }
        public DateTime? PR_date { get; set; }
        public string PR_party_name { get; set; }
        public decimal? PR_amount { get; set; }
        public string PR_ItemCode { get; set; }
        public string PR_Description { get; set; }
        public string PR_t_status { get; set; }
        public string PR_unitcode { get; set; }

        //Purchase Invoice
        public string PI_doc_no { get; set; }
        public DateTime? PI_date { get; set; }
        public string PI_party_name { get; set; }
        public decimal? PI_amount { get; set; }
        public string PI_ItemCode { get; set; }
        public string PI_Description { get; set; }
        public string PI_t_status { get; set; }
        public string PI_unitcode { get; set; }

        //Payment Made
        public string PM_doc_no { get; set; }
        public DateTime? PM_date { get; set; }
        public string PM_party_name { get; set; }
        public decimal? PM_amount { get; set; }
        public string PM_ItemCode { get; set; }
        public string PM_Description { get; set; }
        public string PM_t_status { get; set; }

        //Expence Commercial
        public string Com_doc_no { get; set; }
        public DateTime? Com_doc_date { get; set; }
        public decimal? Com_grand_total { get; set; }
        public string Com_CustomerNm { get; set; }
        public string Com_t_status { get; set; }

        //Expence Voucher
        public string Exp_doc_no { get; set; }
        public DateTime? Exp_doc_date { get; set; }
        public decimal? Exp_grand_total { get; set; }
        public string Exp_CustomerNm { get; set; }
        public string Exp_t_status { get; set; }

        //Document history

        //Sales Activity
        public string Activity_doc_no_A { get; set; }
        public string Activity_doc_date_A { get; set; }
        public string Activity_t_status_A { get; set; }

        //Sales Inquiry
        public string Inq_sono_A { get; set; }
        public string Inq_sodate_A { get; set; }
        public string Inq_amount_A { get; set; }
        public string Inq_party_name_A { get; set; }
        public string Inq_ItemCode_A { get; set; }
        public string Inq_Description_A { get; set; }
        public string Inq_t_status_A { get; set; }

        //Sales Quotation
        public string Qtn_sono_A { get; set; }
        public string Qtn_sodate_A { get; set; }
        public string Qtn_party_name_A { get; set; }
        public string Qtn_ItemCode_A { get; set; }
        public string Qtn_Description_A { get; set; }
        public string Qtn_amount_A { get; set; }
        public string Qtn_t_status_A { get; set; }



        //Sales Order
        public string SO_sono_A { get; set; }
        public string SO_sodate_A { get; set; }
        public string SO_party_name_A { get; set; }
        public string SO_amount_A { get; set; }
        public string SO_ItemCode_A { get; set; }
        public string SO_Description_A { get; set; }
        public string SO_t_status_A { get; set; }


        //Proforma Invoice
        public string Proforma_no_A { get; set; }
        public string Proforma_sodate_A { get; set; }
        public string Proforma_PartyNm_A { get; set; }
        public string Proforma_amount_A { get; set; }
        public string Proforma_ItemCode_A { get; set; }
        public string Proforma_Description_A { get; set; }
        public string Proforma_t_status_A { get; set; }

        //Delivery Note
        public string Delivery_no_A { get; set; }
        public string Delivery_sodate_A { get; set; }
        public string Delivery_PartyNm_A { get; set; }
        public string Delivery_amount_A { get; set; }
        public string Delivery_ItemCode_A { get; set; }
        public string Delivery_Description_A { get; set; }
        public string Delivery_t_status_A { get; set; }

        //Sales Invoice
        public string Sel_Inv_no_A { get; set; }
        public string Sel_Inv_sodate_A { get; set; }
        public string Sel_Inv_PartyNm_A { get; set; }
        public string Sel_Inv_amount_A { get; set; }
        public string Sel_Inv_ItemCode_A { get; set; }
        public string Sel_Inv_Description_A { get; set; }
        public string Sel_Inv_t_status_A { get; set; }

        //Payement Received
        public string Acc_doc_no_A { get; set; }
        public string Acc_doc_date_A { get; set; }
        public string Acc_party_name_A { get; set; }
        public string Acc_amount_A { get; set; }
        public string Acc_ItemCode_A { get; set; }
        public string Acc_Description_A { get; set; }
        public string Acc_t_status_A { get; set; }


        //Purchase order
        public string PO_doc_no_A { get; set; }
        public string PO_doc_date_A { get; set; }
        public string PO_party_name_A { get; set; }
        public string PO_amount_A { get; set; }
        public string PO_ItemCode_A { get; set; }
        public string PO_Description_A { get; set; }
        public string PO_t_status_A { get; set; }

        //Purchase Requestion
        public string PR_doc_no_A { get; set; }
        public string PR_date_A { get; set; }
        public string PR_party_name_A { get; set; }
        public string PR_amount_A { get; set; }
        public string PR_ItemCode_A { get; set; }
        public string PR_Description_A { get; set; }
        public string PR_t_status_A { get; set; }

        //Purchase Invoice
        public string PI_doc_no_A { get; set; }
        public string PI_date_A { get; set; }
        public string PI_party_name_A { get; set; }
        public string PI_amount_A { get; set; }
        public string PI_ItemCode_A { get; set; }
        public string PI_Description_A { get; set; }
        public string PI_t_status_A { get; set; }

        //Payment Made
        public string PM_doc_no_A { get; set; }
        public string PM_date_A { get; set; }
        public string PM_party_name_A { get; set; }
        public string PM_amount_A { get; set; }
        public string PM_ItemCode_A { get; set; }
        public string PM_Description_A { get; set; }
        public string PM_t_status_A { get; set; }
        //Expence Voucher
        public string Exp_doc_no_A { get; set; }
        public string Exp_doc_date_A { get; set; }
        public string Exp_grand_total_A { get; set; }
        public string Exp_CustomerNm_A { get; set; }
        public string Exp_t_status_A { get; set; }

        //GST Report

        public DateTime? post_date { get; set; }
        public string gstinno { get; set; }
        public string buss_place_del { get; set; }
        public string state_code_del { get; set; }
        public string ProdNm { get; set; }
        public string hs_code { get; set; }
        public decimal? ass_value { get; set; }
        public decimal? CGST_Value { get; set; }
        public decimal? SGST_Value { get; set; }
        public decimal? IGST_Value { get; set; }
        public decimal? GST_Total { get; set; }
        public decimal? Invoice_Total { get; set; }
        public string state_code_bill { get; set; }
        public string t_display { get; set; }

        public string quotation_no { get; set; }
        public DateTime? quotation_date { get; set; }
        public string doc_status { get; set; }
        public string ItemName { get; set; }
        public decimal? Service_Value { get; set; }
        public decimal? Goods_Value { get; set; }
        public decimal? effective_value { get; set; }
        public decimal? Wastage { get; set; }
        public decimal? net_pay_amt { get; set; }
        public string reference { get; set; }

    }
}
