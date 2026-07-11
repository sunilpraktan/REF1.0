using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.BusinessEntity.CustomerRelation;

namespace Reflection.BusinessEntity
{
    public class MIS_CRM_SalesEntity1 
    {
        public string sono { get; set; }
        public DateTime? sodate { get; set; }
        public string cust_ref { get; set; }
        public DateTime? cust_ref_date { get; set; }
        public string PartyNm { get; set; }
        public string location { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public string unit_code { get; set; }
        public string doc_type_user { get; set; }
        public string doc_desc_user { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public decimal? quantity { get; set; }
        public decimal? unit_price { get; set; }
        public decimal? untax_amt { get; set; }
        public decimal? sub_total { get; set; }
        public decimal? po_bal_qty { get; set; }
        public decimal? po_bal_value { get; set; }
        public decimal? despatch_qty { get; set; }
        public decimal? despatch_value { get; set; }
        public decimal? po_qty { get; set; }
        public decimal? po_req_qty { get; set; }
        public decimal? sch_qty { get; set; }
        public decimal? confirm_qty { get; set; }
        public decimal? sch_value { get; set; }
        public decimal? bal_sch_qty { get; set; }
        public decimal? bal_sch_value { get; set; }
        public decimal? invoice_qty { get; set; }
        public decimal? invoice_value { get; set; }
        public decimal? bal_qty { get; set; }
        public decimal? req_qty { get; set; }
        public DateTime? exp_date { get; set; }
        public DateTime? sch_date { get; set; }
        public DateTime? sch_rec_date { get; set; }
        public DateTime? confirm_date { get; set; }
        public DateTime? invoice_date { get; set; }
        public DateTime? deliverd_date { get; set; }
        public DateTime? ack_date { get; set; }
        public bool SFlag { get; set; }
        public string sch_no { get; set; }
        public string invoice_no { get; set; }
        public string ackflag { get; set; }
        public int lead_time { get; set; }
        public string t_status { get; set; }
        public string delivery_status { get; set; }
        public string remark { get; set; }
        public DateTime? sch_date_A { get; set; }
        public decimal? qty { get; set; }
        public string ASSIGN { get; set; }
        public string PartyId { get; set; }
        public string po_no { get; set; }
        public decimal? po_bal_Uptoqty { get; set; }
        public decimal? po_Value_Uptovalue { get; set; }
        public decimal? so_qty { get; set; }
        public decimal? so_value { get; set; }
        public decimal? so_uptoqty { get; set; }
        public decimal? so_uptoValue { get; set; }
        public decimal? so_bal_qty { get; set; }
        public decimal? so_bal_Value { get; set; }
        public decimal? sch_Value { get; set; }
        public decimal? sch_uptoqty { get; set; }
        public decimal? sch_uptoValue { get; set; }
        public decimal? req_Value { get; set; }
        public decimal? req_uptoqty { get; set; }
        public decimal? req_uptoValue { get; set; }
        public decimal? req_Bal_Qty { get; set; }
        public decimal? req_Bal_Value { get; set; }
        public decimal? despatch_uptoqty { get; set; }
        public decimal? despatch_uptovalue { get; set; }
        public int? date_diff { get; set; }
        public string reference { get; set; }
        public string curr_code { get; set; }

    }
    public class MIS_CRM_SalesEntity2
    {
        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string act_action { get; set; }
        public string owner { get; set; }
        public string place { get; set; }
        public string address { get; set; }
        public string act_desc { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public bool? visiblity_user { get; set; }
        public string other_participants { get; set; }
        public string priority { get; set; }
        public DateTime? start_date { get; set; }
        public string from_time { get; set; }
        public DateTime? end_date { get; set; }
        public string to_time { get; set; }
        public DateTime? close_date { get; set; }
        public string duration { get; set; }
        public string stage_id { get; set; }
        public string cat_id { get; set; }
        public string section_id { get; set; }
        public string note { get; set; }
        public string lead_id { get; set; }
        public string lead_title { get; set; }
        public string sono { get; set; }
        public string contact_person { get; set; }
        public string person_number { get; set; }
        public string EmailId { get; set; }
        public string activity_type { get; set; }
        public bool? active { get; set; }
        public string act_summary { get; set; }
        public DateTime? act_date { get; set; }
        public string act_time { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public DateTime? add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string parent_activity { get; set; }
        public string action_type { get; set; }
        public string fin_year { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string posting_period { get; set; }
        public string s_status { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public string EmpName { get; set; }
        public string project_name { get; set; }
        public string project_location { get; set; }
        public string location { get; set; }


        public string doc_noA { get; set; }
        public DateTime? doc_dateA { get; set; }
        public string doc_typeA { get; set; }
        public string doc_catA { get; set; }
        public string act_actionA { get; set; }
        public string ownerA { get; set; }
        public string placeA { get; set; }
        public string addressA { get; set; }
        public string act_descA { get; set; }
        public string PartyIdA { get; set; }
        public string party_nameA { get; set; }
        public bool? visiblity_userA { get; set; }
        public string other_participantsA { get; set; }
        public string priorityA { get; set; }
        public DateTime? start_dateA { get; set; }
        public string from_timeA { get; set; }
        public DateTime? end_dateA { get; set; }
        public string to_timeA { get; set; }
        public DateTime? close_dateA { get; set; }
        public string durationA { get; set; }
        public string stage_idA { get; set; }
        public string cat_idA { get; set; }
        public string section_idA { get; set; }
        public string noteA { get; set; }
        public string lead_idA { get; set; }
        public string lead_titleA { get; set; }
        public string sonoA { get; set; }
        public string contact_personA { get; set; }
        public string person_numberA { get; set; }
        public string activity_typeA { get; set; }
        public bool? activeA { get; set; }
        public string act_summaryA { get; set; }
        public DateTime? act_dateA { get; set; }
        public string act_timeA { get; set; }
        public string t_statusA { get; set; }
        public string add_byA { get; set; }
        public DateTime? add_dateA { get; set; }
        public string editbyA { get; set; }
        public DateTime? edit_dateA { get; set; }
        public string parent_activityA { get; set; }
        public string action_typeA { get; set; }
        public string fin_yearA { get; set; }
        public string location_IdA { get; set; }
        public string comp_codeA { get; set; }
        public string posting_periodA { get; set; }
        public string s_statusA { get; set; }
        public string so_codeA { get; set; }
        public string sg_codeA { get; set; }
        public string EmpNameA { get; set; }
        public string locationA { get; set; }



        public string doc_noB { get; set; }
        public DateTime? doc_dateB { get; set; }
        public string doc_typeB { get; set; }
        public string doc_catB { get; set; }
        public string act_actionB { get; set; }
        public string ownerB { get; set; }
        public string placeB { get; set; }
        public string addressB { get; set; }
        public string act_descB { get; set; }
        public string PartyIdB { get; set; }
        public string party_nameB { get; set; }
        public bool? visiblity_userB { get; set; }
        public string other_participantsB { get; set; }
        public string priorityB { get; set; }
        public DateTime? start_dateB { get; set; }
        public string from_timeB { get; set; }
        public DateTime? end_dateB { get; set; }
        public string to_timeB { get; set; }
        public DateTime? close_dateB { get; set; }
        public string durationB { get; set; }
        public string stage_idB { get; set; }
        public string cat_idB { get; set; }
        public string section_idB { get; set; }
        public string noteB { get; set; }
        public string lead_idB { get; set; }
        public string lead_titleB { get; set; }
        public string sonoB { get; set; }
        public string contact_personB { get; set; }
        public string person_numberB { get; set; }
        public string activity_typeB { get; set; }
        public bool? activeB { get; set; }
        public string act_summaryB { get; set; }
        public DateTime? act_dateB { get; set; }
        public string act_timeB { get; set; }
        public string t_statusB { get; set; }
        public string add_byB { get; set; }
        public DateTime? add_dateB { get; set; }
        public string editbyB { get; set; }
        public DateTime? edit_dateB { get; set; }
        public string parent_activityB { get; set; }
        public string action_typeB { get; set; }
        public string fin_yearB { get; set; }
        public string location_IdB { get; set; }
        public string comp_codeB { get; set; }
        public string posting_periodB { get; set; }
        public string s_statusB { get; set; }
        public string so_codeB { get; set; }
        public string sg_codeB { get; set; }
        public string EmpNameB { get; set; }
        public string locationB { get; set; }


        public string PartyNm { get; set; }
        public string PartyType { get; set; }
        public string ContPersnNm { get; set; }
        public string PersnEmailId { get; set; }
        public string PersnMobNo { get; set; }
        public string comp_codeC { get; set; }
        public string comp_name { get; set; }
        public string Location { get; set; }
        public string CmsnrtAdd { get; set; }
        public string WebSite { get; set; }
        public string persnNm { get; set; }
        public string PersnMobNoB { get; set; }
        public string PersnEmailIdB { get; set; }
        public string LocationB { get; set; }

        public string architect_grade { get; set; }
        public string prospectus { get; set; }
        public decimal? No_of_visits { get; set; }

        public string week_no { get; set; }
        public DateTime? week_date { get; set; }
        public string site_location { get; set; }
        public DateTime? project_date { get; set; }
        public decimal? value1 { get; set; }
        public decimal? value2 { get; set; }
        public string remark { get; set; }
        public int prevoius { get; set; }
        public int first { get; set; }
        public string parent_no { get; set; }
        public decimal? area { get; set; }
        public string unit_code { get; set; }
        public string ASSIGN { get; set; }
        public string Status_of_visit { get; set; }

        //weekly closure
        public int No_of_opp_Recv { get; set; }
        public int No_of_opp_Hand { get; set; }
        public int No_of_Sales_meet_done { get; set; }
        public int No_of_BD_meet_done { get; set; }
        public int No_of_Client_meet_done { get; set; }
        public int No_of_Client_Visited_Progress { get; set; }

        public int No_of_Fin { get; set; }
        public decimal? Value_of_Fin { get; set; }
        public int No_of_Qtn { get; set; }
        public decimal? value_of_Qtn { get; set; }
        public int No_of_Cancelled_Qtn { get; set; }
        public decimal? value_of_Cancelled_Qtn { get; set; }
        public int No_of_Fin_Qtn { get; set; }
        public decimal? Value_of_Fin_Qtn { get; set; }
        public int No_of_pre_closg_Qtn { get; set; }
        public decimal? value_of_pre_closg_Qtn { get; set; }
        public decimal? Coll_of_Week { get; set; }
        public decimal? Sales_target { get; set; }
        public int Opp_won { get; set; }
        public decimal? Value_Opp_won { get; set; }
        public int No_of_opp_Lost { get; set; }
        public decimal? Value_of_opp_Lost { get; set; }
        public string status_remark { get; set; }
        public int No_of_Fin_Carry_frd { get; set; }
        public decimal? Value_of_Fin_Carry_frd { get; set; }
        public string Order_no { get; set; }
        public string Inq_no { get; set; }
        public string Quotation_no { get; set; }
        public decimal? Quotation_Amt { get; set; }
        public decimal? payment { get; set; }
        public DateTime? pay_expected_date { get; set; }

        public decimal? so_Amt { get; set; }
        public decimal? Rev_Amt { get; set; }
        private decimal? value_of_exp { get; set; }
        public int No_of_Qtn_winq { get; set; }
        public int No_of_Qtn_woinq { get; set; }
        public int Value_of_Qtn_winq { get; set; }
        public int Value_of_Qtn_woinq { get; set; }

        //Expected Payment (Summary)

        public string Inquiry_no { get; set; }   
        public decimal? Inquiry_amt { get; set; }
        public decimal? Inquiry_payment { get; set; }
        public string Lead { get; set; }   
        public decimal? Quotation_amt { get; set; }
        public decimal? Quotation_payment { get; set; }
        public string Quotation_status { get; set; }
        public string So_no { get; set; }
        public decimal? So_amt { get; set; }
        public decimal? So_payment { get; set; }
        public string So_status { get; set; }
        public string Sales_person { get; set; }
        public string Party_id { get; set; }
        public string Party_name { get; set; }
        public decimal? TotalPayment { get; set; }
        public string Emp_Id { get; set; }
 

    }
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
        public DateTime? valid_from_date { get; set; }
        public DateTime? valid_to_date { get; set; }
        public string reference { get; set; }

    }
    public class MIS_CRM_SalesEntity5
    {
        public string sono { get; set; }
        public DateTime? sodate { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string location { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string unit_code { get; set; }
        public decimal? quantity { get; set; }
        public decimal? unit_price { get; set; }
        public decimal? sub_total { get; set; }
        public decimal? tax_amount { get; set; }
        public decimal? total_amount { get; set; }
        public string tax_name { get; set; }
        public Decimal? amount { get; set; }
        public Decimal? base_amount { get; set; }
        public string CatCode { get; set; }
        public string SubCatCode { get; set; }
        public string ItemTypeCd { get; set; }
        public string SubItemTpCd { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string grade_code { get; set; }
        public Nullable<int> ball_type_id { get; set; }
        public string ball_type { get; set; }
        public Nullable<int> wire_type_id { get; set; }
        public string wire_type { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public string local_export { get; set; }
        public string bill_doc { get; set; }
        public DateTime? bill_date { get; set; }
        public string credit_debit { get; set; }
        public decimal? invoice_amt { get; set; }
        public decimal? ass_value { get; set; }

    }
    public class MIS_CRM_SalesEntity6
    {
        public string bill_doc { get; set; }
        public DateTime? bill_date { get; set; }
        public DateTime? doc_date { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string location { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string unit_code { get; set; }
        public decimal? qty { get; set; }
        public decimal? unit_price { get; set; }
        public decimal? subtotal { get; set; }
        public decimal? tax_amount { get; set; }
        public decimal? total_amount { get; set; }
        public string tax_name { get; set; }
        public decimal? amount { get; set; }
        public decimal? base_amount { get; set; }
        public string CatCode { get; set; }
        public string SubCatCode { get; set; }
        public string ItemTypeCd { get; set; }
        public string SubItemTpCd { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string grade_code { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public string sales_type { get; set; }
        public string acc_type { get; set; }
        public string local_export { get; set; }
        public string ind_trade { get; set; }
        public Nullable<int> ball_type_id { get; set; }
        public string ball_type { get; set; }
        public Nullable<int> wire_type_id { get; set; }
        public string wire_type { get; set; }
        public int? model_id { get; set; }
        public string modeldesc { get; set; }
        public string ref_doc_no { get; set; }
        public int? para1 { get; set; }
        public string tip_type { get; set; }
        public string doc_no { get; set; }
        public string del_note { get; set; }
        public DateTime? del_note_date { get; set; }
        public string ref_doc { get; set; }
        public DateTime? ref_doc_date { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public decimal? total_qty { get; set; }
        public Nullable<int> NoOfPkgs { get; set; }
        public decimal? Ls_qty { get; set; }
        public decimal? Ls_value { get; set; }
        public decimal? IUT_qty { get; set; }
        public decimal? IUT_value { get; set; }
        public decimal? EX_qty { get; set; }
        public decimal? EX_value { get; set; }
        public decimal? Cons_qty { get; set; }
        public decimal? Cons_value { get; set; }
        public string batch_no { get; set; }
        public string form_type { get; set; }
        public decimal? discount { get; set; }
        public decimal? invoice_amt { get; set; }
        public string transporter { get; set; }
        public string lr_no { get; set; }

        public string order_no { get; set; }
        public string barch_no2 { get; set; }
        public string party_code { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string batch_no2 { get; set; }
        public string wc_code { get; set; }
        public DateTime? prod_date { get; set; }
        public string shift { get; set; }

    }
    public class MIS_CRM_SalesEntity7
    {
        public string order_no { get; set; }
        public string quotation_no { get; set; }
        public string invoice_no { get; set; }
        public string party_ref_no { get; set; }
        public string po_no { get; set; }
        public string cr_no { get; set; }
        public DateTime? order_date { get; set; }
        public DateTime? quotation_date { get; set; }
        public DateTime? invoice_date { get; set; }
        public DateTime? party_ref_date { get; set; }
        public DateTime? po_date { get; set; }
        public DateTime? cr_date { get; set; }
        public string party_id { get; set; }
        public string curr_code { get; set; }
        public string ex_rate { get; set; }
        public string ref_doc_no { get; set; }
        public int? ref_item_row_id { get; set; }
        public decimal? order_unit_price { get; set; }
        public decimal? quotation_unit_price { get; set; }
        public decimal? invoice_unit_price { get; set; }
        public decimal? po_unit_price { get; set; }
        public decimal? cr_unit_price { get; set; }
        public decimal? order_qty { get; set; }
        public decimal? quotation_qty { get; set; }
        public decimal? invoice_qty { get; set; }
        public decimal? po_qty { get; set; }
        public decimal? cr_qty { get; set; }
        public decimal? order_sub_total { get; set; }
        public decimal? quotation_sub_total { get; set; }
        public decimal? invoice_sub_total { get; set; }
        public decimal? po_sub_total { get; set; }
        public decimal? cr_sub_total { get; set; }
        public decimal? order_tax_amount { get; set; }
        public decimal? quotation_tax_amount { get; set; }
        public decimal? invoice_tax_amount { get; set; }
        public decimal? po_tax_amount { get; set; }
        public decimal? cr_tax_amount { get; set; }
        public string sg_name { get; set; }
        public string party_name { get; set; }
        public string party_location { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }


        public string sono { get; set; }
        public DateTime? sodate { get; set; }
        public string cust_ref { get; set; }
        public DateTime? cust_ref_date { get; set; }
        public string PartyNm { get; set; }
        public string location { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public string unit_code { get; set; }
        public string doc_type_user { get; set; }
        public string doc_desc_user { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public decimal? quantity { get; set; }
        public decimal? unit_price { get; set; }
        public decimal? untax_amt { get; set; }
        public decimal? sub_total { get; set; }
        public decimal? po_bal_qty { get; set; }
        public decimal? po_bal_value { get; set; }
        public decimal? despatch_qty { get; set; }
        public decimal? despatch_value { get; set; }
        public decimal? po_req_qty { get; set; }
        public decimal? sch_qty { get; set; }
        public decimal? confirm_qty { get; set; }
        public decimal? sch_value { get; set; }
        public decimal? bal_sch_qty { get; set; }
        public decimal? bal_sch_value { get; set; }

        public decimal? invoice_value { get; set; }
        public decimal? bal_qty { get; set; }
        public decimal? req_qty { get; set; }
        public DateTime? exp_date { get; set; }
        public DateTime? sch_date { get; set; }
        public DateTime? sch_rec_date { get; set; }
        public DateTime? confirm_date { get; set; }
        public DateTime? deliverd_date { get; set; }
        public DateTime? ack_date { get; set; }
        public bool? SFlag { get; set; }
        public string sch_no { get; set; }
        public string ackflag { get; set; }
        public int? lead_time { get; set; }
        public string t_status { get; set; }
        public string delivery_status { get; set; }
        public string seller_name { get; set; }
        public DateTime? sch_date_A { get; set; }
        public decimal? wastage_qty { get; set; }
        public decimal? wastage_value { get; set; }
        public string sg_code { get; set; }
        public string so_code { get; set; }
        public string sales_org { get; set; }
        public decimal? value1 { get; set; }
        public decimal? value2 { get; set; }
        public decimal? value3 { get; set; }
        public decimal? value4 { get; set; }
        public decimal? value5 { get; set; }
        public decimal? value6 { get; set; }
        public decimal? value7 { get; set; }
        public decimal? value8 { get; set; }
    }
    public class MIS_CRM_PurchaseEntity
    {
        public string doc_no { get; set; }
        public string ref_doc_no { get; set; }
        public System.DateTime doc_date { get; set; }
        public System.DateTime po_date { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public string buyer { get; set; }
        public Nullable<decimal> amount_untaxed { get; set; }
        public Nullable<decimal> amount_tax { get; set; }
        public Nullable<decimal> amount_total { get; set; }
        public Nullable<decimal> roundup_total { get; set; }
        public string po_code { get; set; }
        public Nullable<System.DateTime> order_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string country_nm { get; set; }
        public string pincode { get; set; }
        public string catalogue_code { get; set; }
        public string t_status { get; set; }
        public string transacion_type { get; set; }
        public string curr_code { get; set; }
        public Nullable<System.DateTime> date_approve { get; set; }
        public string supplying_plant { get; set; }
        public string supplier_ref { get; set; }
        public Nullable<bool> shipped { get; set; }
        public Nullable<System.DateTime> shipped_date { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string ItemCode { get; set; }
        public string description { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public string dcat_name { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public string buyer_name { get; set; }
        public string seller_name { get; set; }
        public Nullable<decimal> po_qty { get; set; }
        public Nullable<decimal> ReceivedQty { get; set; }
        public Nullable<decimal> BalanceQty { get; set; }
        public Nullable<decimal> exch_rate { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<System.DateTime> expected_date { get; set; }
        public string inv_no { get; set; }
        public System.DateTime? inv_date { get; set; }
        public Nullable<decimal> extra_charges { get; set; }
        public string tax_name { get; set; }
        public string close_ref_no { get; set; }
        public Nullable<System.DateTime> close_ref_date { get; set; }
        public string status_remark { get; set; }
        public System.DateTime? valid_from_date { get; set; }
        public System.DateTime? valid_to_date { get; set; }
        public string shipping_address { get; set; }
        public string project { get; set; }
    }
    public class MIS_InsuranceRptEntity
    {
        public DateTime? doc_date { get; set; }
        public string doc_no { get; set; }
        public string transporter { get; set; }
    
        public string lr_no { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Cover { get; set; }
        public Decimal? bal_insurance { get; set; }
        public Decimal? qty { get; set; }
        public Decimal? inv_value { get; set; }
        public Decimal? tax_value { get; set; }
        public Decimal? total_inv_value { get; set; }
        public Decimal? per_inv_val { get; set; }
        public Decimal? tot_per__inv_val { get; set; }
        public Decimal? undecl_insurance { get; set; }
        
        public string PartyId { get; set; }
        public string PartyNm { get; set; }

        public string location_Id { get; set; }
        public string LoctnNm { get; set; }
        public string store_code { get; set; }
        public string store_name { get; set; }
        public bool default_storage_loc { get; set; }
        public string comp_code { get; set; }
        public string ItemCode { get; set; }
        public string description { get; set; }
        public string unit_code { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string Grade { get; set; }

        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string para5 { get; set; }
        public string Type { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string value3 { get; set; }
        public string value4 { get; set; }
        public string value5 { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string remark { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string doc_type_user { get; set; }
        public string doc_desc_user { get; set; }
        public string EmpId { get; set; }
   
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public Decimal? unit_price { get; set; }
        public Decimal? amount { get; set; }


        public string ItemTypeCd { get; set; }
        public string SubItemTpCd { get; set; }
        public string t_status { get; set; }
        public DateTime? post_date { get; set; }
        public string po_no { get; set; }
        public DateTime? po_date { get; set; }
        public string sono { get; set; }
        public DateTime? so_date { get; set; }
        public string mat_con { get; set; }
        public Nullable<int> var1 { get; set; }
        public Decimal? opening { get; set; }
        public Decimal? purchase { get; set; }
        public Decimal? consumption { get; set; }
        public Decimal? ret { get; set; }
        public Decimal? exchange { get; set; }
        public Decimal? sales { get; set; }
        public Decimal? closing { get; set; }


        public Decimal? TotalQty { get; set; }
        public Decimal? TotalAmt { get; set; }

        public Decimal? quantity { get; set; }
        public string wire_type { get; set; }
        public string tip_type { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public Decimal? stock_total { get; set; }
        public Decimal? Reorder { get; set; }


    }
   

    //Sales Inquiry
    public class RptMIS_CRMDatewiseSales1
    {
        public string Inq_sono { get; set; }
        public DateTime? Inq_sodate { get; set; }
        public string Inq_doc_type { get; set; }
        public string Inq_doc_cat { get; set; }
        public string Inq_PartyId { get; set; }
        public string Inq_party_name { get; set; }
        public string Inq_location_Id { get; set; }
        public string Inq_comp_code { get; set; }
        public string Inq_EmpId { get; set; }
        public string Inq_ItemCode { get; set; }
        public string Inq_Description { get; set; }
        public decimal? Inq_quantity { get; set; }
        public decimal? Inq_unit_price { get; set; }
        public decimal? Inq_amount { get; set; }
        public string Inq_buyer_name { get; set; }
        public string Inq_unit_code { get; set; }
        public string Inq_seller_name { get; set; }
        public string Inq_ref_doc_no { get; set; }
        public string Inq_PartyNm { get; set; }
        public decimal? Inq_tax_amount { get; set; }
        public decimal? Inq_sub_total { get; set; }
        public decimal? Inq_roundup_total { get; set; }

    }
    //Sales Inquiry
    public class RptMIS_CRMDatewiseSales2N
    {
        public string Inq_sono { get; set; }
        public DateTime? Inq_sodate { get; set; }
        public string Inq_doc_type { get; set; }
        public string Inq_doc_cat { get; set; }
        public string Inq_PartyId { get; set; }
        public string Inq_party_name { get; set; }
        public string Inq_location_Id { get; set; }
        public string Inq_comp_code { get; set; }
        public string Inq_EmpId { get; set; }
        public string Inq_ItemCode { get; set; }
        public string Inq_Description { get; set; }
        public decimal? Inq_quantity { get; set; }
        public decimal? Inq_unit_price { get; set; }
        public decimal? Inq_amount { get; set; }
        public string Inq_buyer_name { get; set; }
        public string Inq_unit_code { get; set; }
        public string Inq_seller_name { get; set; }
        public string Inq_ref_doc_no { get; set; }
        public string Inq_PartyNm { get; set; }
        public decimal? Inq_tax_amount { get; set; }
        public decimal? Inq_sub_total { get; set; }
        public decimal? Inq_roundup_total { get; set; }

    }
    //CRM Activity
    public class RptMIS_CRMDatewiseSales3
    {
        public string Activity_doc_no { get; set; }
        public DateTime? Activity_doc_date { get; set; }
        public string Activity_doc_type { get; set; }
        public string Activity_doc_cat { get; set; }
        public string Activity_act_action { get; set; }
        public string Activity_owner { get; set; }
        public string Activity_place { get; set; }
        public string Activity_address { get; set; }
        public string Activity_act_desc { get; set; }
        public string Activity_PartyId { get; set; }
        public string Activity_party_name { get; set; }
        public DateTime? Activity_start_date { get; set; }
        public string Activity_from_time { get; set; }
        public DateTime? Activity_end_date { get; set; }
        public string Activity_to_time { get; set; }
        public DateTime? Activity_close_date { get; set; }
        public string Activity_duration { get; set; }
        public string Activity_note { get; set; }
        public string Activity_sono { get; set; }
        public string Activity_contact_person { get; set; }
        public string Activity_person_number { get; set; }
        public string Activity_activity_type { get; set; }
        public bool? Activity_active { get; set; }
        public string Activity_t_status { get; set; }
        public string Activity_add_by { get; set; }
        public DateTime? Activity_add_date { get; set; }
        public string Activity_editby { get; set; }
        public DateTime? Activity_edit_date { get; set; }
        public string Activity_parent_activity { get; set; }
        public string Activity_action_type { get; set; }
        public string Activity_fin_year { get; set; }
        public string Activity_location_Id { get; set; }
        public string Activity_comp_code { get; set; }
        public string Activity_EmpName { get; set; }
        public string Activity_project_name { get; set; }
        public string Activity_project_location { get; set; }
        public string Activity_location { get; set; }


        public string Activity_PartyNm { get; set; }
        public string Activity_PartyType { get; set; }
        public string Activity_comp_name { get; set; }

        public string Activity_architect_grade { get; set; }
        public string Activity_prospectus { get; set; }
        public string site_location { get; set; }
        public DateTime? Activity_project_date { get; set; }
        public string Activity_remark { get; set; }
        public decimal? Activity_area { get; set; }


    }
    //CRM Activity2
    public class RptMIS_CRMDatewiseSales4N
    {
        public string Activity_doc_no { get; set; }
        public DateTime? Activity_doc_date { get; set; }
        public string Activity_doc_type { get; set; }
        public string Activity_doc_cat { get; set; }
        public string Activity_act_action { get; set; }
        public string Activity_owner { get; set; }
        public string Activity_place { get; set; }
        public string Activity_address { get; set; }
        public string Activity_act_desc { get; set; }
        public string Activity_PartyId { get; set; }
        public string Activity_party_name { get; set; }
        public DateTime? Activity_start_date { get; set; }
        public string Activity_from_time { get; set; }
        public DateTime? Activity_end_date { get; set; }
        public string Activity_to_time { get; set; }
        public DateTime? Activity_close_date { get; set; }
        public string Activity_duration { get; set; }
        public string Activity_note { get; set; }
        public string Activity_sono { get; set; }
        public string Activity_contact_person { get; set; }
        public string Activity_person_number { get; set; }
        public string Activity_activity_type { get; set; }
        public bool? Activity_active { get; set; }
        public string Activity_t_status { get; set; }
        public string Activity_add_by { get; set; }
        public DateTime? Activity_add_date { get; set; }
        public string Activity_editby { get; set; }
        public DateTime? Activity_edit_date { get; set; }
        public string Activity_parent_activity { get; set; }
        public string Activity_action_type { get; set; }
        public string Activity_fin_year { get; set; }
        public string Activity_location_Id { get; set; }
        public string Activity_comp_code { get; set; }
        public string Activity_EmpName { get; set; }
        public string Activity_project_name { get; set; }
        public string Activity_project_location { get; set; }
        public string Activity_location { get; set; }


        public string Activity_PartyNm { get; set; }
        public string Activity_PartyType { get; set; }
        public string Activity_comp_name { get; set; }

        public string Activity_architect_grade { get; set; }
        public string Activity_prospectus { get; set; }
        public string site_location { get; set; }
        public DateTime? Activity_project_date { get; set; }
        public string Activity_remark { get; set; }
        public decimal? Activity_area { get; set; }


    }
    //CRM Activity3
    public class RptMIS_CRMDatewiseSales5N
    {
        public string Activity_doc_no { get; set; }
        public DateTime? Activity_doc_date { get; set; }
        public string Activity_doc_type { get; set; }
        public string Activity_doc_cat { get; set; }
        public string Activity_act_action { get; set; }
        public string Activity_owner { get; set; }
        public string Activity_place { get; set; }
        public string Activity_address { get; set; }
        public string Activity_act_desc { get; set; }
        public string Activity_PartyId { get; set; }
        public string Activity_party_name { get; set; }
        public DateTime? Activity_start_date { get; set; }
        public string Activity_from_time { get; set; }
        public DateTime? Activity_end_date { get; set; }
        public string Activity_to_time { get; set; }
        public DateTime? Activity_close_date { get; set; }
        public string Activity_duration { get; set; }
        public string Activity_note { get; set; }
        public string Activity_sono { get; set; }
        public string Activity_contact_person { get; set; }
        public string Activity_person_number { get; set; }
        public string Activity_activity_type { get; set; }
        public bool? Activity_active { get; set; }
        public string Activity_t_status { get; set; }
        public string Activity_add_by { get; set; }
        public DateTime? Activity_add_date { get; set; }
        public string Activity_editby { get; set; }
        public DateTime? Activity_edit_date { get; set; }
        public string Activity_parent_activity { get; set; }
        public string Activity_action_type { get; set; }
        public string Activity_fin_year { get; set; }
        public string Activity_location_Id { get; set; }
        public string Activity_comp_code { get; set; }
        public string Activity_EmpName { get; set; }
        public string Activity_project_name { get; set; }
        public string Activity_project_location { get; set; }
        public string Activity_location { get; set; }


        public string Activity_PartyNm { get; set; }
        public string Activity_PartyType { get; set; }
        public string Activity_comp_name { get; set; }

        public string Activity_architect_grade { get; set; }
        public string Activity_prospectus { get; set; }
        public string site_location { get; set; }
        public DateTime? Activity_project_date { get; set; }
        public string Activity_remark { get; set; }
        public decimal? Activity_area { get; set; }


    }
    //Sales Quotation+value
    public class RptMIS_CRMDatewiseSales6
    {
        public string Qtn_sono { get; set; }
        public DateTime? Qtn_sodate { get; set; }
        public string Qtn_doc_type { get; set; }
        public string Qtn_doc_cat { get; set; }
        public string Qtn_PartyId { get; set; }
        public string Qtn_party_name { get; set; }
        public string Qtn_location_Id { get; set; }
        public string Qtn_comp_code { get; set; }
        public string Qtn_EmpId { get; set; }
        public string Qtn_ItemCode { get; set; }
        public string Qtn_Description { get; set; }
        public decimal? Qtn_quantity { get; set; }
        public decimal? Qtn_unit_price { get; set; }
        public decimal? Qtn_amount { get; set; }
        public string Qtn_buyer_name { get; set; }
        public string Qtn_unit_code { get; set; }
        public string Qtn_seller_name { get; set; }
        public string Qtn_ref_doc_no { get; set; }
        public string Qtn_PartyNm { get; set; }
        public decimal? Qtn_tax_amount { get; set; }
        public decimal? Qtn_sub_total { get; set; }
        public decimal? Qtn_roundup_total { get; set; }

    }
    //Sales No of Final Quotation+value
    public class RptMIS_CRMDatewiseSales7N
    {
        public string Qtn_sono { get; set; }
        public DateTime? Qtn_sodate { get; set; }
        public string Qtn_doc_type { get; set; }
        public string Qtn_doc_cat { get; set; }
        public string Qtn_PartyId { get; set; }
        public string Qtn_party_name { get; set; }
        public string Qtn_location_Id { get; set; }
        public string Qtn_comp_code { get; set; }
        public string Qtn_EmpId { get; set; }
        public string Qtn_ItemCode { get; set; }
        public string Qtn_Description { get; set; }
        public decimal? Qtn_quantity { get; set; }
        public decimal? Qtn_unit_price { get; set; }
        public decimal? Qtn_amount { get; set; }
        public string Qtn_buyer_name { get; set; }
        public string Qtn_unit_code { get; set; }
        public string Qtn_seller_name { get; set; }
        public string Qtn_ref_doc_no { get; set; }
        public string Qtn_PartyNm { get; set; }
        public decimal? Qtn_tax_amount { get; set; }
        public decimal? Qtn_sub_total { get; set; }
        public decimal? Qtn_roundup_total { get; set; }

    }
    //Sales No of Fin Quotation+value
    public class RptMIS_CRMDatewiseSales7N2
    {
        public string Qtn_sono { get; set; }
        public DateTime? Qtn_sodate { get; set; }
        public DateTime? Qtn_date { get; set; }
        public string Qtn_doc_type { get; set; }
        public string Qtn_doc_cat { get; set; }
        public string Qtn_PartyId { get; set; }
        public string Qtn_party_name { get; set; }
        public string Qtn_location_Id { get; set; }
        public string Qtn_comp_code { get; set; }
        public string Qtn_EmpId { get; set; }
        public string Qtn_ItemCode { get; set; }
        public string Qtn_Description { get; set; }
        public decimal? Qtn_quantity { get; set; }
        public decimal? Qtn_unit_price { get; set; }
        public decimal? Qtn_amount { get; set; }
        public string Qtn_buyer_name { get; set; }
        public string Qtn_unit_code { get; set; }
        public string Qtn_seller_name { get; set; }
        public string Qtn_ref_doc_no { get; set; }
        public string Qtn_PartyNm { get; set; }
        public decimal? Qtn_tax_amount { get; set; }
        public decimal? Qtn_sub_total { get; set; }
        public decimal? Qtn_roundup_total { get; set; }

    }

    //Sales No of Cancelled Quotation+value
    public class RptMIS_CRMDatewiseSales7N3
    {
        public string Qtn_sono { get; set; }
        public DateTime? Qtn_sodate { get; set; }
        public DateTime? sodate { get; set; }
        public string Qtn_doc_type { get; set; }
        public string Qtn_doc_cat { get; set; }
        public string Qtn_PartyId { get; set; }
        public string Qtn_party_name { get; set; }
        public string Qtn_location_Id { get; set; }
        public string Qtn_comp_code { get; set; }
        public string Qtn_EmpId { get; set; }
        public string Qtn_ItemCode { get; set; }
        public string Qtn_Description { get; set; }
        public decimal? Qtn_quantity { get; set; }
        public decimal? Qtn_unit_price { get; set; }
        public decimal? Qtn_amount { get; set; }
        public string Qtn_buyer_name { get; set; }
        public string Qtn_unit_code { get; set; }
        public string Qtn_seller_name { get; set; }
        public string Qtn_ref_doc_no { get; set; }
        public string Qtn_PartyNm { get; set; }
        public decimal? Qtn_tax_amount { get; set; }
        public decimal? Qtn_sub_total { get; set; }
        public decimal? Qtn_roundup_total { get; set; }

    }

    //No_of_pre_closg_Qtn+value
    public class RptMIS_CRMDatewiseSales8N
    {
        public string Qtn_sono { get; set; }
        public DateTime? Qtn_sodate { get; set; }
        public string Qtn_doc_type { get; set; }
        public string Qtn_doc_cat { get; set; }
        public string Qtn_PartyId { get; set; }
        public string Qtn_party_name { get; set; }
        public string Qtn_location_Id { get; set; }
        public string Qtn_comp_code { get; set; }
        public string Qtn_EmpId { get; set; }
        public string Qtn_ItemCode { get; set; }
        public string Qtn_Description { get; set; }
        public decimal? Qtn_quantity { get; set; }
        public decimal? Qtn_unit_price { get; set; }
        public decimal? Qtn_amount { get; set; }
        public string Qtn_buyer_name { get; set; }
        public string Qtn_unit_code { get; set; }
        public string Qtn_seller_name { get; set; }
        public string Qtn_ref_doc_no { get; set; }
        public string Qtn_PartyNm { get; set; }
        public decimal? Qtn_tax_amount { get; set; }
        public decimal? Qtn_sub_total { get; set; }
        public decimal? Qtn_roundup_total { get; set; }

    }

    //Coll_of_Week
    public class RptMIS_CRMDatewiseSales9
    {
        public string Acc_doc_no { get; set; }
        public DateTime? Acc_doc_date { get; set; }
        public string Acc_doc_type { get; set; }
        public string Acc_doc_cat { get; set; }
        public string Acc_PartyId { get; set; }
        public string Acc_party_name { get; set; }
        public string Acc_location_Id { get; set; }
        public string Acc_comp_code { get; set; }
        public string Acc_EmpId { get; set; }
        public string Acc_ItemCode { get; set; }
        public string Acc_Description { get; set; }
        public decimal? Acc_quantity { get; set; }
        public decimal? Acc_unit_price { get; set; }
        public decimal? Acc_amount { get; set; }
        public string Acc_buyer_name { get; set; }
        public string Acc_unit_code { get; set; }
        public string Acc_seller_name { get; set; }
        public string Acc_ref_doc_no { get; set; }
        public string Acc_PartyNm { get; set; }
        public decimal? Acc_tax_amount { get; set; }
        public decimal? Acc_sub_total { get; set; }
        public decimal? Acc_roundup_total { get; set; }

    }

    //Sales order+value
    public class RptMIS_CRMDatewiseSales10
    {
        public string SO_sono { get; set; }
        public DateTime? SO_sodate { get; set; }
        public string SO_doc_type { get; set; }
        public string SO_doc_cat { get; set; }
        public string SO_PartyId { get; set; }
        public string SO_party_name { get; set; }
        public string SO_location_Id { get; set; }
        public string SO_comp_code { get; set; }
        public string SO_EmpId { get; set; }
        public string SO_ItemCode { get; set; }
        public string SO_Description { get; set; }
        public decimal? SO_quantity { get; set; }
        public decimal? SO_unit_price { get; set; }
        public decimal? SO_amount { get; set; }
        public string SO_buyer_name { get; set; }
        public string SO_unit_code { get; set; }
        public string SO_seller_name { get; set; }
        public string SO_ref_doc_no { get; set; }
        public string SO_PartyNm { get; set; }
        public decimal? SO_tax_amount { get; set; }
        public decimal? SO_sub_total { get; set; }
        public decimal? SO_roundup_total { get; set; }

    }

    //Sales Inquiry Lost+value
    public class RptMIS_CRMDatewiseSales11N
    {
        public string Inq_sono { get; set; }
        public DateTime? Inq_sodate { get; set; }
        public string Inq_doc_type { get; set; }
        public string Inq_doc_cat { get; set; }
        public string Inq_PartyId { get; set; }
        public string Inq_party_name { get; set; }
        public string Inq_location_Id { get; set; }
        public string Inq_comp_code { get; set; }
        public string Inq_EmpId { get; set; }
        public string Inq_ItemCode { get; set; }
        public string Inq_Description { get; set; }
        public decimal? Inq_quantity { get; set; }
        public decimal? Inq_unit_price { get; set; }
        public decimal? Inq_amount { get; set; }
        public string Inq_buyer_name { get; set; }
        public string Inq_unit_code { get; set; }
        public string Inq_seller_name { get; set; }
        public string Inq_ref_doc_no { get; set; }
        public string Inq_PartyNm { get; set; }
        public decimal? Inq_tax_amount { get; set; }
        public decimal? Inq_sub_total { get; set; }
        public decimal? Inq_roundup_total { get; set; }

    }

    //Sales Quotation No_of_Fin_Carry_frd
    public class RptMIS_CRMDatewiseSales12
    {
        public string Qtn_sono { get; set; }
        public DateTime? Qtn_sodate { get; set; }
        public string Qtn_doc_type { get; set; }
        public string Qtn_doc_cat { get; set; }
        public string Qtn_PartyId { get; set; }
        public string Qtn_party_name { get; set; }
        public string Qtn_location_Id { get; set; }
        public string Qtn_comp_code { get; set; }
        public string Qtn_EmpId { get; set; }
        public string Qtn_ItemCode { get; set; }
        public string Qtn_Description { get; set; }
        public decimal? Qtn_quantity { get; set; }
        public decimal? Qtn_unit_price { get; set; }
        public decimal? Qtn_amount { get; set; }
        public string Qtn_buyer_name { get; set; }
        public string Qtn_unit_code { get; set; }
        public string Qtn_seller_name { get; set; }
        public string Qtn_ref_doc_no { get; set; }
        public string Qtn_PartyNm { get; set; }
        public decimal? Qtn_tax_amount { get; set; }
        public decimal? Qtn_sub_total { get; set; }
        public decimal? Qtn_roundup_total { get; set; }

    }
    //Expence Voucher
    public class RptMIS_CRMDatewiseSales13
    {
        public string Exp_doc_no { get; set; }
        public DateTime? Exp_doc_date { get; set; }
        public string Exp_doc_type { get; set; }
        public string Exp_doc_cat { get; set; }

        public string Exp_PartyId { get; set; }
        public decimal? Exp_advance { get; set; }
        public string Exp_EmpName { get; set; }
        public string Exp_location { get; set; }
        public string Exp_additional_person { get; set; }
        public decimal? Exp_bal_amount { get; set; }
        public decimal? Exp_grand_total { get; set; }
        public string Exp_CustomerNm { get; set; }
        public string Exp_transport_mode { get; set; }
        public string Exp_food_expense { get; set; }
        public decimal? Exp_food_exp_amt { get; set; }
        public string Exp_misc_detail { get; set; }
        public decimal? Exp_misc_amt { get; set; }
        public string Exp_print_stat { get; set; }
        public decimal? Exp_print_stat_amt { get; set; }
        public string Exp_other_expense { get; set; }
        public decimal? Exp_other_exp_amt { get; set; }
        public Nullable<int> Exp_agevar { get; set; }

        public string Exp_travel_from { get; set; }
        public string Exp_travel_to { get; set; }
        public decimal? Exp_dist_in_km { get; set; }
        public decimal? Exp_approved_amt { get; set; }
    }
    //Local Conveyance
    public class RptMIS_CRMDatewiseSales14
    {
        public string LC_doc_no { get; set; }
        public DateTime? LC_doc_date { get; set; }
        public string LC_doc_type { get; set; }
        public string LC_doc_cat { get; set; }

        public string LC_PartyId { get; set; }
        public decimal? LC_advance { get; set; }
        public string LC_EmpName { get; set; }
        public string LC_location { get; set; }
        public string LC_additional_person { get; set; }
        public decimal? LC_bal_amount { get; set; }
        public decimal? LC_grand_total { get; set; }
        public string LC_CustomerNm { get; set; }
        public string LC_transport_mode { get; set; }
        public string LC_food_expense { get; set; }
        public decimal? LC_food_exp_amt { get; set; }
        public string LC_misc_detail { get; set; }
        public decimal? LC_misc_amt { get; set; }
        public string LC_print_stat { get; set; }
        public decimal? LC_print_stat_amt { get; set; }
        public string LC_other_expense { get; set; }
        public decimal? LC_other_exp_amt { get; set; }
        public Nullable<int> LC_agevar { get; set; }

        public string LC_travel_from { get; set; }
        public string LC_travel_to { get; set; }
        public decimal? LC_dist_in_km { get; set; }
        public decimal? LC_approved_amt { get; set; }
    }

    //Sales Quotation with inquiry+value
    public class RptMIS_CRMDatewiseSales16
    {
        public string Qtn_sono { get; set; }
        public DateTime? Qtn_sodate { get; set; }
        public string Qtn_doc_type { get; set; }
        public string Qtn_doc_cat { get; set; }
        public string Qtn_PartyId { get; set; }
        public string Qtn_party_name { get; set; }
        public string Qtn_location_Id { get; set; }
        public string Qtn_comp_code { get; set; }
        public string Qtn_EmpId { get; set; }
        public string Qtn_ItemCode { get; set; }
        public string Qtn_Description { get; set; }
        public decimal? Qtn_quantity { get; set; }
        public decimal? Qtn_unit_price { get; set; }
        public decimal? Qtn_amount { get; set; }
        public string Qtn_buyer_name { get; set; }
        public string Qtn_unit_code { get; set; }
        public string Qtn_seller_name { get; set; }
        public string Qtn_ref_doc_no { get; set; }
        public string Qtn_PartyNm { get; set; }
        public decimal? Qtn_tax_amount { get; set; }
        public decimal? Qtn_sub_total { get; set; }
        public decimal? Qtn_roundup_total { get; set; }

    }

    //Sales Quotation without inquiry+value
    public class RptMIS_CRMDatewiseSales17
    {
        public string Qtn_sono { get; set; }
        public DateTime? Qtn_sodate { get; set; }
        public string Qtn_doc_type { get; set; }
        public string Qtn_doc_cat { get; set; }
        public string Qtn_PartyId { get; set; }
        public string Qtn_party_name { get; set; }
        public string Qtn_location_Id { get; set; }
        public string Qtn_comp_code { get; set; }
        public string Qtn_EmpId { get; set; }
        public string Qtn_ItemCode { get; set; }
        public string Qtn_Description { get; set; }
        public decimal? Qtn_quantity { get; set; }
        public decimal? Qtn_unit_price { get; set; }
        public decimal? Qtn_amount { get; set; }
        public string Qtn_buyer_name { get; set; }
        public string Qtn_unit_code { get; set; }
        public string Qtn_seller_name { get; set; }
        public string Qtn_ref_doc_no { get; set; }
        public string Qtn_PartyNm { get; set; }
        public decimal? Qtn_tax_amount { get; set; }
        public decimal? Qtn_sub_total { get; set; }
        public decimal? Qtn_roundup_total { get; set; }

    }



}
