using System;
using System.ComponentModel;

namespace Reflection.BusinessEntity
{
    public class MM_T001_GRN_PopUp//Currency Master
    {
        public int id { get; set; }
        [DisplayName("GRN No.")]
        public string doc_no { get; set; }
        public string reference { get; set; }
        public string grndate { get; set; }
    }
    //public class ADM_M007_PopUp
    //{
    //    public int UserTypCode { get; set; }
    //    [DisplayName("User Type")]
    //    public string UserTyp { get; set; }
    //    public Nullable<System.DateTime> AddDate { get; set; }
    //    public string EditBy { get; set; }
    //    public Nullable<System.DateTime> EditDate { get; set; }
    //} 
    public class  ADM_M034_PopUp
            {
                public string para_code { get; set; }
                public string SubCatCode { get; set; }
                public int id { get; set; }
                public string Type { get; set; }
            }
    public class ZACC_T001_WireSize
    {
        public string WireSize { get; set; }
    }

    public class ZACC_T001_WireType
    {
        public string WireType { get; set; }
    }

    public class ZACC_T001_BallType
    {
        public string BallType { get; set; }
    }

    public class ZACC_T001_TipLength
    {
        public string TipLength { get; set; }
    }

    public class ZACC_T001_Unit
    {
        public string Unit { get; set; }
    }

    public class ZACC_T001_Pre_Year
    {
        public string Pre_Year { get; set; }
    }
    public class SYS_M007_Popup //Document Type (po/quat)
    {
        public int id { get; set; }
        public Nullable<int> company_id { get; set; }        
        public string doc_type { get; set; }
        public string doc_type_user { get; set; }       
        public string doc_desc { get; set; }
        public string doc_cat { get; set; }
        public string display_doc_type { get; set; }
        public Nullable<bool> default_dc { get; set; }
        public string delivery_type { get; set; }
        public string billing_type { get; set; }
        public string report_name { get; set; }  
    }
    public class ADM_M001_M_Popup//po organisation
    {
        public string po_code { get; set; }
        [DisplayName("PO Organisation")]
        public string pur_org { get; set; }
    }    
    public class ADM_M001_P_Popup//---Purchase Group
    {
        public string pg_code { get; set; }
        public string pg_name { get; set; }
    }
    public class ADM_M003_PopUp1
    {
        public string pg_code { get; set; }
        public string pg_name { get; set; }
    }

    public class ADM_M003_PopUp : ObjectBase 
    {
        [DisplayName("")]
        public string location_Id { get; set; }
        [DisplayName("Plant Code")]
        public string plant_code { get; set; } 

        [DisplayName("Location Name")]
        public string LoctnNm { get; set; }
        internal bool _Select { get; set; }
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
                }
            }
        }
        
    }
    public class ADM_M003_Location_PopUp
    {
        public string Location_Id { get; set; }
        public string LoctnNm { get; set; }
    }
    public class SYS_M002_Popup //Document Type
    {
        public string display_doc_type { get; set; }
        [DisplayName("Document Type")]
        public string doc_type { get; set; }
        [DisplayName("Description")]
        public string sdoc_type { get; set; }
    }
    public class ADM_M037_Popup//Currency Master
    {
        public int id { get; set; }
        [DisplayName("Currency")]
        public string curr_code { get; set; }

        public string curr_name { get; set; }
    }
    public class SEL_T001_Popup : ObjectBase//Reference doc no's
    {
        public int id { get; set; }
        [DisplayName("Ref. Doc. no.")]
        public string sono { get; set; }
        [DisplayName("Customer PO. no.")]
        public string cust_ref { get; set; }
        //[DisplayName("Item Description")]
        public string Description { get; set; }
        public string doc_type_id { get; set; }
        internal bool _Select { get; set; }
        [DisplayName("")]
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
                }
            }
        }
        public int item_id { get; set; }
        //[DisplayName("Item Code")]
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public decimal quantity { get; set; }
        public decimal bal_qty { get; set; }
        public decimal acc_qty { get; set; }
        public Nullable<System.DateTime> po_date { get; set; }//take as ref_doc_date
    }
    public class ADM_M001_A_Popup//Sale Organisation
    {
        [DisplayName("Sale Organisation")]
        public string so_code { get; set; }
        public string sales_org { get; set; }
    }
    public class ESO_T001_PopUp // Sorting
    {
        public DateTime prod_dt { get; set; }
        public string mc_code { get; set; }
    }
    public class ADM_M001_C_Popup//--Distribution Channel
    {
        [DisplayName("Distribution Channel")]
        public string dc_code { get; set; }
        public string dc_name { get; set; }
    }
    public class ADM_M001_D_Popup//---Sales Division
    {
        [DisplayName("Sales Division")]
        public string div_code { get; set; }
        public string div_name { get; set; }
    }
    public class ADM_M024_Popup//---Sales Person
    {
        public int id { get; set; }
        [DisplayName("Contact Person")]
        public string name { get; set; }
        public string EmpId { get; set; }
        
    }
    public class ADM_M001_I_Popup//---Sales Office
    {
        [DisplayName("Sales Office")]
        public string soff_code { get; set; }

        public string sales_off { get; set; }
    }
    public class ADM_M001_H_Popup//---Sales Group
    {
        [DisplayName("Sales Group")]
        public string sg_code { get; set; }

        public string sg_name { get; set; }
    }
    public class ACC_M019_Popup//---Cost Center
    {

        public int cc_profit_center { get; set; }
        public int id { get; set; }
        [DisplayName("Cost Center")]
        public string cost_center { get; set; }
    }
    public class ACC_M019_CostCenterPopup//---Cost Center
    {
        public string cost_center { get; set; }
        public string cost_center_Desc { get; set; }
    }

    public class ACC_M020_Popup//---Profit Center
    {
        public int id { get; set; }
        [DisplayName("Profit Center")]
        public string profit_center { get; set; }
    }
    public class MM_M002_PopUp
    {
        public int id { get; set; }
        [DisplayName("Warehouse")]
        public string wa_code { get; set; }

        public string wa_name { get; set; }

    }
    public class MM_M001_PopUp
    {
        public int id { get; set; }
        [DisplayName("Storage Location")]
        public string store_code { get; set; }

        public string store_name { get; set; }

    }
    public class ADM_M002_PopUp
    {
        public string Comp_Id { get; set; }
        public string CompName { get; set; }
        public int Location_Id { get; set; }
        public string comp { get; set; }
        public string comp_code { get; set; }
    }
    public class SYS_M003_PopUp
    {
        [DisplayName("Item category")]
        public string sditem_cat_code { get; set; }

        public string item_cat_desc { get; set; }
    }
    public class SYS_M008_PopUp//Item Category
    {
        public string item_cat { get; set; }
        public string cat_desc { get; set; }
    }
    public class SYS_M005_PopUp
    {
        [DisplayName("Document Type ")]
        public string delivery_type { get; set; }

        public string del_desc { get; set; }

    }


    public class ADM_M025_Popup//Department Master
    {
        public int id { get; set; }
        public string dept_code { get; set; }

        [DisplayName("Department Name")]
        public string DeptName { get; set; }
    }

    public class ADM_M018_Popup
    {
        public int id { get; set; }

        public string Category { get; set; }
    }
    public class ADM_M019_Popup
    {
        public int id { get; set; }

        public string ItemType { get; set; }
    }
    public class Batch_Popup
    {

        public string Batch { get; set; }
    }
    public class MM_M004_Popup
    {
        [DisplayName("Movement Code")]
        public string mov_tp { get; set; }
        [DisplayName("Movement Description")]
        public string mov_name { get; set; }

    }

    public class CRM_T002B_PopUp_GRN : ObjectBase
    {
        public int id { get; set; }//ADM_M022 SrNo as id
        public string ItemCode { get; set; }//ADM_M022
        [DisplayName("PO No.")]
        public string pono { get; set; }//PUR_T002_B
        public string ItemName { get; set; }//ADM_M022       
        [DisplayName("Item Code")]
        public string customer_code { get; set; }//CRM_T001B CstmrItmCod as 
        [DisplayName("Item Name")]
        public string customer_description { get; set; }//CRM_T001B CstmrItmDesc as
        public string description { get; set; }
        public Nullable<int> unit_id { get; set; } //ADM_M038_B
        public string unit_code { get; set; }
        [DisplayName("Unit Name")]
        public string unit_name { get; set; }//ADM_M038_B
        public int party_id { get; set; }//ADM_M038_B
        public int SubCategCod { get; set; }//ADM_M022
        public Nullable<bool> Stockble { get; set; }
        public string stockingunit { get; set; }//ADM_M022
        public int poid { get; set; }//PUR_T002_B
        public int po_lineid { get; set; }//PUR_T002_B
        public Nullable<decimal> bal_qty { get; set; }//PUR_T002_B
        public Nullable<decimal> poqty { get; set; }//PUR_T002_B
        public string item_cat { get; set; }
        internal bool _Select { get; set; }
        [DisplayName("")]
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
                }
            }
        }
    }
    //public class CRM_T002B_PopUp_GRN : ObjectBase
    //{
    //    public int id { get; set; }//ADM_M022 SrNo as id
    //    public string ItemCode { get; set; }//ADM_M022
    //    [DisplayName("PO No.")]
    //    public string pono { get; set; }//PUR_T002_B
    //    public string ItemName { get; set; }//ADM_M022       
    //    [DisplayName("Item Code")]
    //    public string customer_code { get; set; }//CRM_T001B CstmrItmCod as 
    //    [DisplayName("Item Name")]
    //    public string customer_description { get; set; }//CRM_T001B CstmrItmDesc as
    //    public string description { get; set; }
    //    public Nullable<int> unit_id { get; set; } //ADM_M038_B     
    //    [DisplayName("Unit Name")]
    //    public string unit_name { get; set; }//ADM_M038_B
    //    public int party_id { get; set; }//ADM_M038_B
    //    public int SubCategCod { get; set; }//ADM_M022
    //    public Nullable<bool> Stockble { get; set; }
    //    public string stockingunit { get; set; }//ADM_M022
    //    public int poid { get; set; }//PUR_T002_B
    //    public int po_lineid { get; set; }//PUR_T002_B
    //    public Nullable<decimal> bal_qty { get; set; }//PUR_T002_B
    //    public Nullable<decimal> poqty { get; set; }//PUR_T002_B
    //    public string item_cat { get; set; }

    //    internal bool _Select { get; set; }
    //    [DisplayName("")]
    //    public bool Select
    //    {
    //        get { return _Select; }
    //        set
    //        {
    //            if (_Select != value)
    //            {
    //                _Select = value;

    //                RaisePropertyChanged("Select");
    //            }
    //        }
    //    }
    //}


    public class ADM_M012_PopUp
    {
        public int CntryCode { get; set; }
        //[DisplayName("Country Name")]
        public string CntryName { get; set; }
        public string country_code { get; set; }
    }
    public class ADM_M013_PopUp
    {
        public int StatCode { get; set; }
        //[DisplayName("State Name")]
        public string StatName { get; set; }
        public int CntryCode { get; set; }
        public string state_code { get; set; }
        public string country_code { get; set; }
    }
    public class SEL_T001_BPopUp
    {
        public int id { get; set; }
        public int so_id { get; set; }
        [DisplayName("item_id")]
        public int item_id { get; set; }
        public decimal conversn_fact { get; set; }

    }
    public class ADM_M022_PopUp_SO : ObjectBase
    {
        public int SrNo { get; set; }
        [DisplayName("SO NO")]
        public string sono { get; set; }
        [DisplayName("Item Code")]
        public string ItemCode { get; set; }
        [DisplayName("Item Name")]
        public string ItemName { get; set; }
        public int SubCategCod { get; set; }
        public int unit_id { get; set; }
        [DisplayName("Unit Name")]
        public string unit_name { get; set; }
        public string unit_code { get; set; }
        public int item_id { get; set; }
        public string Description { get; set; }
        internal bool _Select { get; set; }
        [DisplayName("")]
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
                }
            }
        }
        private string _stockingunit;
        public string stockingunit { get { return _stockingunit; } set { _stockingunit = value; RaisePropertyChanged("stockingunit"); } }
        public decimal quantity { get; set; }

        public decimal rate { get; set; }
        public bool Stockble { get; set; }
        public string ild { get; set; }
        public string ink { get; set; }
        public string grade { get; set; }
        public string gross_wt { get; set; }
        public string net_wt { get; set; }
        public Nullable<int> wt_unit { get; set; }
        public string volume { get; set; }
        public Nullable<int> volume_unit { get; set; }
        public string doc_type { get; set; }

    }
    public class SEL_T001_PopUp_Deli_Note : ObjectBase//SO For Delivery Note
    {
        public int id { get; set; }
        [DisplayName("SO NO ")]
        public string sono { get; set; }
        public string doc_type_id { get; set; }
        internal bool _Select { get; set; }
        [DisplayName("")]
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
                }
            }
        }
        public Nullable<bool> active { get; set; }
        public string doc_category_id { get; set; }
        public string ref_doc_no { get; set; }
        public string sales_org { get; set; }
        public string sales_div { get; set; }
        public string warehouse_id { get; set; }
        public string distribution_channel { get; set; }
        public string sales_grp { get; set; }
        public string sales_office { get; set; }
        public string business_area { get; set; }
        public Nullable<int> cost_center_id { get; set; }
        public string plant_id { get; set; }
        public Nullable<int> bill_address_id { get; set; }
        public Nullable<int> del_address { get; set; }
        public string InvicAdd { get; set; }
        public string DelAdd { get; set; }
        public string ship_mode { get; set; }
        public string port_load { get; set; } 
        public string port_desc { get; set; }
        public string stock_location_id { get; set; }  
        public string stock_location { get; set; }       
        public string cost_center { get; set; }
        public Nullable<decimal> gross_wt { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public Nullable<decimal> volume { get; set; }
        public Nullable<int> weightunitid { get; set; }
        public Nullable<int> volumeunitid { get; set; }
        public string doc_type { get; set; }
    }
    public class Order_No_Popup // for delivery note
    {
        public string order_no { get; set; }
        public string doc_category_id { get; set; }
        public string doc_type_id { get; set; }
    }
    public class OrderDetails // for delivery note
    {
        public int bill_address_id { get; set; }
        public int del_address { get; set; }
        public string sales_org { get; set; }
        public string sales_div { get; set; }
        public string sold_to_party { get; set; }
        public string distribution_channel { get; set; }
        public string sales_grp { get; set; }
        public string sales_office { get; set; }
        public string business_area { get; set; }
        public string ship_to_party { get; set; }
        public string pre_carrage { get; set; }
        public string pre_carrage_place { get; set; }
        public string country_code { get; set; }
        public string cf_agent_cd { get; set; }
        public string lic_cod { get; set; }
        public string adv_lic_cd { get; set; }
        public string org_country_cd { get; set; }
        public string transporter_cd { get; set; }
        public string ship_mode { get; set; }
        public string port_desc { get; set; }
        public string final_dest { get; set; }
        public string ship_terms { get; set; }
        public string ship_mark { get; set; }
        public string port_load { get; set; }
    }
        
    public class ItemDetails:ObjectBase // for delivery note item details
    {
        public string item_code { get; set; }
        public string Description { get; set; }
        public decimal quantity { get; set; }
        public string unit_code { get; set; }

        private bool _Select;
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
    }
            }
        }

    }
    public class ADM_M037_Popup_PartyWise//Currency Master
    {
        public int id { get; set; }
        public string curr_code { get; set; }
        public string curr_name { get; set; }
        public Nullable<decimal> rate { get; set; }
    }

    public class TSK_T001_B_Folder
    {
        public int id { get; set; }
        public string folder_name { get; set; }
    }
    public class MM_T001_A_PopUp_PUR : ObjectBase
    {
        [DisplayName("GRN No.")]
        public string grnno { get; set; }//ADM_M038_B  

        [DisplayName("PO No.")]
        public string po_no { get; set; }

        public string doc_no { get; set; }//ADM_M022  
        public Nullable<int> grn_id { get; set; }//ADM_M022 SrNo as id
        [DisplayName("Item Code")]
        public string ItemCode { get; set; }//ADM_M022

        [DisplayName("Item Name")]
        public string ItemName { get; set; }//ADM_M022

        public Nullable<int> SubCategCod { get; set; }//ADM_M022
        public string CustCode { get; set; }//CRM_T001B CstmrItmCod as 
        public string CustDecrName { get; set; }//CRM_T001B CstmrItmDesc as

        [DisplayName("Approved Qty")]
        public Nullable<decimal> appr_qty { get; set; }

        [DisplayName("Rate")]
        public Nullable<decimal> rate { get; set; }
        public string stockingunit { get; set; }//ADM_M022
        public string tax_id { get; set; }
        public Nullable<int> unit_id { get; set; } //ADM_M038_B     
        public string unit_name { get; set; }//ADM_M038_B 
        public Nullable<int> item_id { get; set; } //ADM_M038_B  

        internal bool _Select { get; set; }
        [DisplayName("")]
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
                }
            }
        }

        public Nullable<decimal> amount_total { get; set; }

        public Nullable<decimal> amount_untaxed { get; set; }
        public Nullable<decimal> amount_tax { get; set; }

        public string amt_in_words { get; set; }
        public string item_cat { get; set; }
        public Nullable<decimal> sub_total { get; set; }

        public string invoiceNo { get; set; }
        public Nullable<DateTime> Invoicedate { get; set; }
        public string challanno { get; set; }
        public Nullable<DateTime> challandate { get; set; }
        public string bill_ladding { get; set; }
        public Nullable<int> pay_term_id { get; set; }
        public string p_term { get; set; }
        public string doc_cat { get; set; }
        public string entry_time { get; set; }
        public Nullable<DateTime> post_date { get; set; }
        public Nullable<int> company_id { get; set; }
        public string companyname { get; set; }
    }

    public class PUR_T002_A_popup
    {
        public int id { get; set; }
        public string po_no { get; set; }
        public int supplier_id { get; set; }
    }

   
    public class PUR_T005_Popup//Reference doc no's
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string doc_type { get; set; }
    }

    public class ZADM_M013_Popup1     //Machine Type
    {
        [DisplayName("Machine Type")]
        public string mctype { get; set; }
    }

    public class ZADM_M013_PopUp          //Machine 
    {
        public Nullable<int> machine_id { get; set; }

        [DisplayName("Machine")]
        public string machinecode { get; set; }
        public string mctype { get; set; }
        public string Engineer { get; set; }
        public Nullable<int> Engineer_id { get; set; }
    }
    public class ZADM_M013_PopUp_Engineer          //Engineer From MachineMasterand emp
    {     
        public string Engineer { get; set; }
        public Nullable<int> Engineer_id { get; set; }
    }
    public class ZADM_M006_PopUp //INK Master
    {
        public int ink_id { get; set; }
        [DisplayName("INK")]
        public string ink { get; set; }
        public string desc { get; set; }
        public string make { get; set; }

    }

    public class ZADM_M007_PopUp //ILD Master
    {
        public int ild_id { get; set; }
        [DisplayName("ILD")]
        public string ild { get; set; }
        [DisplayName("Tip Type")]
        public string tip_type { get; set; }
    }

    public class SYS_M001_PopUp //Document Category
    {
        [DisplayName("Document Category")]
        public string doc_cat { get; set; }
    }

    public class ZADM_M016_PopUp : ObjectBase //Defect Master
    {
        //public Nullable<decimal> dfctcda { get; set; }     
        public int id { get; set; }
        [DisplayName("Product Defect")]
        public string dfctdsc { get; set; }
        [DisplayName("Scope")]
        public string scope { get; set; }
        //public int dftcdu { get; set; }  
        internal bool _Select { get; set; }
        [DisplayName("")]
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
                }
            }
        }

    }

    public class ZADM_M009_PopUp : ObjectBase  //model details
    {
        public int model_id { get; set; }
        [DisplayName("Model No")]
        public string modelno { get; set; }
        public string model_no { get; set; }
        public string basicmodel { get; set; }
        [DisplayName("Description")]
        public string modeldesc { get; set; }
        internal bool _Select { get; set; }
        [DisplayName("")]
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
                }
            }
        }

    }

    public class ZADM_M002_PopUp  //Ball Type
    {
        //public int ball_type_id { get; set; }
        [DisplayName("Ball Type")]
        public string ball_type { get; set; }

    }

    public class ZADM_M001_PopUp  //BallDia
    {
        public int ball_dia_id { get; set; }
        [DisplayName("Ball Dia")]
        public decimal Ball_dia { get; set; }
        public decimal ball_dia { get; set; }
    }

    public class ADM_M028_PopUp1 //Ink Supplier
    {
        public int id { get; set; }
        [DisplayName("Party Code")]
        public string PartyCode { get; set; }
        [DisplayName("Party Name")]
        public string PartyNm { get; set; }

        public bool Customer { get; set; }

        public bool Supplier { get; set; }
    }

    public class ADM_M022_ESSEM_PopUp : ObjectBase
    {
        public int SrNo { get; set; }
        [DisplayName("Item Code")]
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string shanklen { get; set; }
        public string needle_dia { get; set; }
        public string needlelen { get; set; }
        public string tip_type { get; set; }
        public string prdct_code { get; set; }
        public int Model_id { get; set; }
        public string ModelCode { get; set; }
        public string wire_material { get; set; }
        public string wire_dia { get; set; }
        public string grade { get; set; }
        internal bool _Select { get; set; }
        [DisplayName("")]
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
                }
            }
        }

    }

    public class ADM_M028_PopUp
    {
        public int id { get; set; }
        [DisplayName("Party ID")]
        public string PartyId { get; set; }

        [DisplayName("Party Name")]
        public string PartyNm { get; set; }

        public string EmailId { get; set; }

        public string Currency { get; set; }

        public string curr_code { get; set; }
        public string contryNm { get; set; }
        public string PersnEmailId { get; set; }
    }

    public class EPR_T001_PopUp //ILDChart AND Maschine Master
    {
        public int id { get; set; }
        public int machine_id { get; set; }
        public string machinecode { get; set; }
        public string machinedesc { get; set; }
        public string machine_type { get; set; }
        public Nullable<int> model_id { get; set; }
        public string model_no { get; set; }
        public string item_code { get; set; }
        public string ink { get; set; }
        public Nullable<System.DateTime> start_dt { get; set; }

    }
    public class LOG_T00_PopUp_Sale : ObjectBase
    {
        [DisplayName("Source Doc.no")]
        public string grnno { get; set; }//ADM_M038_B    

        public string doc_no { get; set; }//ADM_M022  
        public Nullable<int> dc_id { get; set; }//ADM_M022 SrNo as id
        [DisplayName("Item Code")]
        public string ItemCode { get; set; }//ADM_M022
        [DisplayName("Item Name")]
        public string ItemName { get; set; }//ADM_M022
        public string so_no { get; set; }
        public string SubCategCod { get; set; }//ADM_M022
        public string CustCode { get; set; }//CRM_T001B CstmrItmCod as 
        public string CustDecrName { get; set; }//CRM_T001B CstmrItmDesc as
        [DisplayName("Appr qty.")]
        public Nullable<decimal> appr_qty { get; set; }
        public bool Stockble { get; set; }
        public Nullable<decimal> rate { get; set; }
        public string sku { get; set; }//ADM_M022
        public string tax_id { get; set; }
        public Nullable<int> unit_id { get; set; } //ADM_M038_B     
        public string unit_code { get; set; } //ADM_M038_B     
        public string unit_name { get; set; }//ADM_M038_B    
        public Nullable<int> item_id { get; set; } //ADM_M038_B  
        public Nullable<decimal> amount_total { get; set; }
        public Nullable<decimal> amount_untaxed { get; set; }
        public Nullable<decimal> amount_tax { get; set; }
        public string amt_in_words { get; set; }
        public string item_cat { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public string marks { get; set; }
        public string container_no { get; set; }
        public string range_no { get; set; }

        //public string invoiceNo { get; set; }
        //public Nullable<DateTime> Invoicedate { get; set; }
        public string challanno { get; set; }
        public Nullable<DateTime> challandate { get; set; }
        //public string bill_ladding { get; set; }
        public Nullable<int> pay_term_id { get; set; }
        public string p_term { get; set; }
        public string doc_cat { get; set; }
        public string entry_time { get; set; }//string
        public Nullable<DateTime> post_date { get; set; }
        //public string company_id { get; set; }
        //public string companyname { get; set; }

        public Nullable<decimal> net_wt { get; set; }//
        public Nullable<decimal> gross_wt { get; set; }///
        public string wt_unit { get; set; }//
        public string wt_unit_nm { get; set; }//
        public Nullable<decimal> volume { get; set; }//
        public string  volume_unit { get; set; }//
        public string vol_unit_nm { get; set; }//
        public string ladding_bill { get; set; }//
        public Nullable<DateTime> ladding_date { get; set; }//
        //public string delivery_no { get; set; }
        //public Nullable<DateTime> delivery_date { get; set; }
        public string shipment_mode { get; set; }//
        public string no_of_packages_A { get; set; }//
        public Nullable<int> transporter { get; set; }
        public Nullable<int> no_of_pkgs { get; set; }//done
        public string kind_of_pkgs { get; set; }//done
        public Nullable<int> prod_descr_id { get; set; }//
        public string prod_descr_nm { get; set; }//done
        public string consignee { get; set; }//
        public string consignee_nm { get; set; }//


        public string pre_carrage { get; set; }//
        public string pre_carrage_place { get; set; }//

        public string port_load { get; set; }//
        public string port_desc { get; set; }//
        public string port_final { get; set; }
        public string final_dest { get; set; }//
        public string ship_terms { get; set; }//
        public Nullable<int> cf_agent_id { get; set; }//
        public string  cf_agent_id1 { get; set; }//
        public string cf_agent_nm { get; set; }//
        public Nullable<int> epcg_id { get; set; }//
        public string epcg_nm { get; set; }//
        public Nullable<int> adv_lic_id { get; set; }//
        public string adv_lic_nm { get; set; }//
        public Nullable<int> doc_curr_id { get; set; }//
        public string doc_curr_nm { get; set; }//
        public string transporter_id { get; set; }//
        public string transporter_nm { get; set; }//        
        public string warehouse { get; set; }//
        public string so_code { get; set; }// 
        public string div_code { get; set; }// 
        public string dc_code { get; set; }//         
        public string dest_country { get; set; }// 
        public string dest_country_nm { get; set; }// 
        public string cost_center { get; set; }// 
        public string cost_center_nm { get; set; }// 
        public string fiscal_pos { get; set; }// 
        public string journal { get; set; }// 
        public string  org_country_cd { get; set; }//
        public string pack_rem { get; set; }
        public string ship_mark { get; set; }//
        public string vess_flight { get; set; }//
        public decimal net_weight { get; set; }
        public decimal wt_goods { get; set; }
        public Nullable<decimal> item_volume { get; set; }
        public string type { get; set; }

        public string container { get; set; }
        public string curr_code { get; set; }
        public string currency { get; set; }
        public string buyer_nm { get; set; }
        public Nullable<int> buyer { get; set; }     
        public string buyer1 { get; set; }
        public Nullable<decimal> discount { get; set; }
        internal bool _Select { get; set; }
        [DisplayName("")]
        public bool Select//
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
                }
            }
        }

    }

    public class EPR_T001_PopUp_Lot //Conv Lot From ILDChart 
    {
        public int id { get; set; }
        public string MachineCode { get; set; }
        public Nullable<int> Conv_lot { get; set; }
        public string Status { get; set; }
        public Nullable<int> model_id { get; set; }
        public string model_no { get; set; }
        public string item_code { get; set; }
        public Nullable<int> party_id { get; set; }
        public string PartyNm { get; set; }
        public string shift { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public Nullable<System.DateTime> start_dt { get; set; }
        public decimal min_val { get; set; }
        public decimal max_val { get; set; }
        public string shank_len { get; set; }
        public Nullable<decimal> shank_dia { get; set; }
        public string needle_dia { get; set; }
        public string needle { get; set; }
        public string total_len { get; set; }
        public Nullable<decimal> amnild { get; set; }
        public Nullable<decimal> amxild { get; set; }
        public Nullable<decimal> aavild { get; set; }

    }
    public class ECR_T004_PopUp_Lot //Conv Lot From ILDChart 
    {
        public int id { get; set; }
        public string MachineCode { get; set; }
        public Nullable<int> Conv_lot { get; set; }
        public string Status { get; set; }
        public Nullable<int> model_id { get; set; }
        public string model_no { get; set; }
        public string item_code { get; set; }
        public string ItemName { get; set; }
        public Nullable<int> party_id { get; set; }
        public string PartyId { get; set; }//newly  added
        public string PartyNm { get; set; }
        public string shift { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public Nullable<System.DateTime> start_dt { get; set; }
        public decimal min_val { get; set; }
        public decimal max_val { get; set; }
        public string shank_len { get; set; }
        public string shank_dia { get; set; }
        public string needle_dia { get; set; }
        public string needle { get; set; }
        public string total_len { get; set; }
        public Nullable<decimal> amnild { get; set; }
        public Nullable<decimal> amxild { get; set; }
        public Nullable<decimal> aavild { get; set; }

        public string ballout { get; set; }
        public string ShankChamfer { get; set; }

    }
    public partial class ECRM_T003_B_PopUp//Wrting TestDetails
    {
        public int id { get; set; }
        public Nullable<int> wtid { get; set; }
        public string refilno { get; set; }
        public int tm { get; set; }
    }
    public class PPC_T001_PopUp // JobCart
    {
        [DisplayName("Job Cart")]
        public string doc_no { get; set; }
        public string ItemCode { get; set; }
        public string so_no { get; set; }
        public decimal jc_qty { get; set; }
        public decimal bal_qty { get; set; }
        public string unit_code { get; set; }
        public string unit_name { get; set; }
        public string description { get; set; }
        public string sku { get; set; }
        public string source_doc_no { get; set; }
        public string batch_no { get; set; }
        public bool Select { get; set; }
        public string SubCategCod { get; set; }
        public Nullable<bool> Stockable { get; set; }
        public string item_srno { get; set; }
        public string sch_no { get; set; }
        public string PartyId { get; set; }
        public Nullable<System.DateTime> ref_date { get; set; }
    }

    public class SEL_T003_A_Popup : ObjectBase //invoice
    {
        public int id { get; set; }
        public int sold_party { get; set; }
        public int form_type { get; set; }
        public int fin_year { get; set; }
        [DisplayName("Invoice No")]
        public string bill_doc { get; set; }
        [DisplayName("Invoice Date")]
        public DateTime doc_date { get; set; }
        [DisplayName("Values Of Goods")]
        public decimal sub_total { get; set; }
        [DisplayName("Tax Amount")]
        public decimal tax_amount { get; set; }
        [DisplayName("Invoice Amount")]
        public decimal invoice_amt { get; set; }
        public string PartyName { get; set; }
        public string Period { get; set; }
        internal bool _Select { get; set; }
        [DisplayName("")]
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
                }
            }
        }

        public int adv_lic { get; set; }  //advance Licence No
        public string adv_lic_nm { get; set; }  //advance Licence No
        public int epcg { get; set; }     //EPCG Licence No
        public string epcg_nm { get; set; }     //EPCG Licence No
        public string doc_curr { get; set; } //Currency
        public decimal exc_rate { get; set; } //Exchange Rate
        public int cf_agent { get; set; }  //C&F Agent Id
        public string cf_agent_nm { get; set; }  //C&F Agent Name
        public string trans_mode { get; set; } //Dispach Mode
        public int dest_con { get; set; }    //Final Destination Country
        public string dest_con_nm { get; set; }  //Final Destination Country name
        public string port_final { get; set; } //Final Destination Port
        public decimal wt_gross { get; set; }
        public decimal wt_net { get; set; }
        public string lr_no { get; set; }      //Bill Of ladding
        public DateTime lr_date { get; set; } //Bill Of ladding Date

    }
    
    //public class ESO_T001_PopUp // Sorting
    //{
    //    public DateTime prod_dt { get; set; }
    //    public string mc_code { get; set; }
    //}
    public class EPR_T003_A_PopUp : ObjectBase//Carton Packing
    {
        [DisplayName("Carton No")]
        public string carton_no { get; set; }
        [DisplayName("Product")]
        public string itemcode { get; set; }
        public Nullable<int> unit_id { get; set; }
        [DisplayName("Unit")]
        public string UOM { get; set; }
        public decimal tot_qty { get; set; }
        public string note { get; set; }
        public string barcode { get; set; }
        [DisplayName("Batch No")]
        public string batch_no { get; set; }
        public decimal net_wt { get; set; }
        public decimal gross_wt { get; set; }
        public string ItemName { get; set; }
        public int Srno { get; set; }
        public string stockingunit { get; set; }
        public Nullable<decimal> bal_qty { get; set; }
        [DisplayName("INK")]
        public string INK { get; set; }
        [DisplayName("ILD")]
        public string ILD { get; set; }
        [DisplayName("GRADE")]
        public string GRADE { get; set; }
        public int id { get; set; }
        internal bool _Select { get; set; }
        [DisplayName("")]
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
                }
            }
        }

    }

    //public class ESO_T001_PopUp // Sorting
    //{
    //    public DateTime prod_dt { get; set; }
    //    public string mc_code { get; set; }
    //}

    public class ZADM_M017_Popup : ObjectBase          //Packing Unit
    {
        public int packing_id { get; set; }
        [DisplayName("Packing Unit")]
        public string pkgunit { get; set; }
    }
    public class ADM_M028_PopUp_Deli_Note
    {
        public int id { get; set; }
        [DisplayName("Party Name")]
        public string PartyNm { get; set; }
        public Nullable<bool> Supplier { get; set; }
        public string PartyId { get; set; }
    }
    public class ACC_M004_Popup          //Bank
    {
        public int id { get; set; }
        [DisplayName("Bank Name")]
        public string bank_name { get; set; }
        [DisplayName("Branch")]
        public string branch { get; set; }
        public string bank_code { get; set; }
        public string comp_code { get; set; }
    }
    public class MM_S003_PopUp //Batch Stock
    {
        //[DisplayName("Batch No")]
        public string batch_no { get; set; }
        //[DisplayName("Item Code")]
        public string item_code { get; set; }
        public string item_id { get; set; }
        public string sku { get; set; }
        public string unit_Name { get; set; }
        public int uom { get; set; }
        public bool Select { get; set; }
        public string item_Name { get; set; }
        public int SubCategCod { get; set; }
        public bool Stockable { get; set; }
        public int item_srno { get; set; }
        public string so_no { get; set; }
        public decimal packetWt { get; set; }

    }
    public class MM_S003_PopUpBatch //Batch 
    {
        public string batch_no { get; set; }
        public string item_id { get; set; }
        public string sku { get; set; }
        public string item_Name { get; set; }
       
        public bool Stockable { get; set; }
        public decimal packetWt { get; set; }

    }
    public class ZADM_M019_Popup
    {
        public string airline { get; set; }
    }
    public class ZADM_M022_Popup
    {
        public string CPN { get; set; }
        public string PNO { get; set; }
    }
    public class ADM_M021_PopUp : ObjectBase
    {
        public int id { get; set; }
        [DisplayName("Material Code")]
        public string MateCode { get; set; }
        [DisplayName("Description")]
        public string MateName { get; set; }
        internal bool _Select { get; set; }
        [DisplayName("")]
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
                }
            }
        }

    }

    public class ECRM_T003_A_PopUp //Writing Test 
    {
        public string prdct_code { get; set; }
    }
    public class ECRM_T004_A_PopUp //PDI Entry 
    {
        public Nullable<int> party { get; set; }
        public string PartyNm { get; set; }
    }
    public class MM_M005_PopUp // Stock Chart
    {
        public int QuantID { get; set; }
        public int QuantNumber { get; set; }
        [DisplayName("Quant Name")]
        public string QuantName { get; set; }
    }
    public class MM_M007_PopUp // StockJournal
    {        
            public int trnsID { get; set; }
            public string ItemCode { get; set; }
            public string sku { get; set; }
            public string batch_no { get; set; }
            public Nullable<decimal> Qty { get; set; }
            public string TrnsType { get; set; }           
            public string item_Name { get; set; }
            public bool Stockable { get; set; }
            public int SubCategCod { get; set; }
            private string _SourceLoc;
            public string SourceLoc { get; set; }
            private string _DestLoc;
            public string DestLoc { get; set; }
        
    }
    public class PRO_M001_Popup     //Category master, phasemaster, project transaction,task dependancy
    {
        public int id { get; set; }
        public string sid { get; set; }
        public string name { get; set; }
        //public string Phase_Name { get; set; }
        public string prj_id { get; set; }

        public Nullable<int> sequence { get; set; }
        public string status { get; set; }
    }
   

    public class PRO_M003_Popup : ObjectBase
    {
        public int PhaseId { get; set; }
        public string phase_name { get; set; }
        public int sequence { get; set; }
        public string description { get; set; }

        private bool _Select { get; set; }
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
                }
            }
        }
    }

    public partial class EPR_T002_PopUp
    {
        public string ItemCode { get; set; }
        public string batch_no { get; set; }
        public string unit_code { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> qty { get; set; }
        //public Nullable<decimal> a_qty { get; set; }
        //public Nullable<decimal> b_qty { get; set; }
        //public Nullable<decimal> c_qty { get; set; }
        public bool Select { get; set; }
    }
    public partial class MM_T003_PopUp
    {
        public Nullable<int> id { get; set; }
        public Nullable<int> req_id { get; set; } 
        public string req_no { get; set; }
        public string Emp_code { get; set; }
        public Nullable<int> Emp_id { get; set; }
        public string EmpNm { get; set; }
        public Nullable<int> dept { get; set; }
        public string dept_code { get; set; }
        public string Dept_Name { get; set; }
        public Nullable<int> item_id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string stockingunit { get; set; }
        public Nullable<int> uom_id { get; set; }
        public string unit_code { get; set; }
        public string UOMNm { get; set; }
        public decimal qty { get; set; }
        public Nullable<int> SubCategCod { get; set; }
        public Nullable<bool> Stockble { get; set; }
        public Nullable<System.DateTime> expected_date { get; set; }
        public string req_ref { get; set; } 
        public string location { get; set; }
        public string store_loc { get; set; }
    }
    public class MM_T001_IssueNOPOPup//issueno
    {
        public string doc_no { get; set; }
        public string EmpId { get; set; }
        public string EmpNm { get; set; }
        public string recipient { get; set; }
        public string dept { get; set; }
        public string dept_code { get; set; }
        public string Dept_Name { get; set; }
        public string item_id { get; set; }
        public string ItemName { get; set; }
        public string stockingunit { get; set; }
        public string amt_loc { get; set; }
        public decimal qty { get; set; }
        public string challan_qty { get; set; }
        public string uom { get; set; }
        //public Nullable<int> uom_id { get; set; }
        public string unit_code { get; set; }
        public string unit_price { get; set; }
        public string party_cd { get; set; }
        public string SubCategCod { get; set; }
        public Nullable<bool> Stockble { get; set; }
        public Nullable<System.DateTime> expected_date { get; set; }
        public string location { get; set; }
        public string store_loc { get; set; }     
    }
   
    public class ADM_M042_Popup    // shift
    {
        public string shift { get; set; }
    }
    public class RequestParameter
    {
        public string RquestType { get; set; }
        public string plant { get; set; }
        public string  company { get; set; }
        public string party { get; set; }
        public string id { get; set; }
    }
    public class soListForPlan : ObjectBase
    {
        internal bool _Select { get; set; }
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
                }
            }
        }
        public int id { get; set; }
        public string sono { get; set; }
        public string plant_id { get; set; }
        public int company_id { get; set; }       
        public string customer_code { get; set; }
        public string customer_name { get; set; }
        public int item_id { get; set; }
        public string ItemCode { get; set; }
        public int machine_id { get; set; }
        public string machine_no { get; set; }
        public string stocking_unit { get; set; }
        public int item_line_id { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public Nullable<int> uom { get; set; }
        public string uom_name { get; set; }
        public Nullable<int> model_id { get; set; }
        public string model_no { get; set; }
        public string model_description { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string ball_make { get; set; }
        public string wire_make { get; set; }
        public Nullable<decimal> producedQty { get; set; }
        public Nullable<decimal> balanceQty { get; set; }
        public string orderConfirmDate { get; set; }
    }

    public class PRO_M004_Popup
    {
        public int role_id { get; set; }
        public string RoleCode { get; set; }
        public string role_name { get; set; }
    }
    public class ADM_M008B_PopUp : ObjectBase
    {
        public int id { get; set; }
        public string TranCode { get; set; }
        public string TranName { get; set; }
        internal bool _Select { get; set; }
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
                }
            }
        }        

    }
    public class PUR_T002_A_PopUp //Load Qtn Data on PO using Reference doc no's
    {
        public string po_no { get; set; }
        public Nullable<System.DateTime> po_date { get; set; }
        public string address { get; set; }
        public string supplier_ref { get; set; }
        public Nullable<int> validator { get; set; }
        public string validator_code { get; set; }
        public Nullable<int> del_address_id { get; set; }
        public Nullable<int> bill_address_id { get; set; }
        public string plant_id { get; set; }
        public string comp_code { get; set; }
        public Nullable<int> doc_currency { get; set; }
        public string curr_code { get; set; }
        public Nullable<int> pay_term_id { get; set; }
        public string p_term_code { get; set; }
        public string terms_cond { get; set; }
        public string notes { get; set; }
        public Nullable<System.DateTime> valid_from_date { get; set; }
        public Nullable<System.DateTime> valid_to_date { get; set; }
        public Nullable<System.DateTime> quotation_validity { get; set; }
        public Nullable<System.DateTime> min_planned_date { get; set; }
        public string version { get; set; }
        public string status_po { get; set; }
        public string sales_org { get; set; }
        public string pg_code { get; set; }
        public Nullable<int> supplier_id { get; set; }
        public string PartyId { get; set; }
        public string doc_type { get; set; }
        public Nullable<decimal> amount_tax { get; set; }
        public Nullable<decimal> amount_untaxed { get; set; }
        public Nullable<decimal> amount_total { get; set; }
        public string amt_in_words { get; set; }
    }

   
    
    public class Item_PopUp_PO
    {
        public string ItemCode { get; set; }//ADM_M022
        public string ItemName { get; set; }//ADM_M022
        public string CatCode { get; set; }//CRM_T001B CstmrItmCod as 
        public string SubCategCod { get; set; }//ADM_M022
        public string unit_code { get; set; }
        public Nullable<bool> Stockble { get; set; }
        public string PartyId { get; set; }
        public string cstmr_itemcode { get; set; }
        public string cstmr_itemdescr { get; set; }
        public Nullable<decimal> b_rate { get; set; }
        public string stocking_unit { get; set; }
        public string tax_id { get; set; }
        public string Catlog_UOM { get; set; }
        public string sku_desc { get; set; }
        public Nullable<decimal> Req_QTY { get; set; }
        public Nullable<decimal> Req_Approve_qty { get; set; }
        public string Req_NO { get; set; }
        public string req_type { get; set; }
        public string item_cat_id { get; set; }
        public string req_ref { get; set; }
        public Nullable<decimal> Rate_Suggested { get; set; }
        public Nullable<decimal> Rate_Catlog { get; set; }
    }
    public class Para_PopUp
    {
        public int code { get; set; }
        public int id { get; set; }
        public string Type { get; set; }
        public string SubCatCode { get; set; }
        public int Srno { get; set; }
        public int count { get; set; }
        public string ItemCode { get; set; }
        public string Name { get; set; }
        public string sku { get; set; }
        public string subcatcode { get; set; }        
    }
    public class ADM_M030_PopUp
    {
        public int code { get; set; }
        public int count { get; set; }
        public string paramcode { get; set; }
        public string parametervalue { get; set; }
        public string Name { get; set; }
        public string SubCatCode { get; set; }

        public string Type { get; set; }

        public string selectedValue { get; set; }

        public Nullable<int> selectedindex { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
    }
    public class ParameterSelection
    {
        public int code { get; set; }
        public string parametervalue { get; set; }

        public string type { get; set; }

        public int Srno { get; set; }
    }

    public class ACC_M013_PopUp_TaxAccount
    {

        [DisplayName("Tax Account")]
        public string taxaccount { get; set; }

        public Nullable<int> accountcollectdid { get; set; }

    }
    public class Parameter_PopUp
    {
        public int id { get; set; }
        public string Type { get; set; }
        public string CatParamCode { get; set; }
        public string CatParamName { get; set; }
        public string SubCat_Code { get; set; }
        public string SubCatCode { get; set; }
        public string SubCatCd { get; set; }
        public string Name { get; set; }

        public int item_id { get; set; }

        public int selectedindex { get; set; }

        public int code { get; set; }
        public bool StockUnt { get; set; }
    }
    public class ACC_M005_PopUp
    {
        public int id { get; set; }
        [DisplayName("Journal Name")]
        public string journal_name { get; set; }
        [DisplayName("Journal Code")]
        public string j_code { get; set; }
    }
    public class PurchaseOrder_deliveryschedule : ObjectBase
    {
        [DisplayName("")]
        public string item_code { get; set; }
        public string ItemCode { get; set; }
        //public string ItemCode { get; set; }
        [DisplayName("Item Name")]
        public string item_name { get; set; }

        [DisplayName("")]
        public Nullable<int> item_id { get; set; }
        [DisplayName("")]
        public Nullable<int> po_id { get; set; }
        [DisplayName("Customer Item Code")]
        public string CustCode { get; set; }

        [DisplayName("Customer Item Desc")]
        public string CustDecrName { get; set; }

        [DisplayName("Quantity")]
        public Nullable<decimal> qty { get; set; }

        [DisplayName("")]

        internal bool _ScheduleSelect { get; set; }




        public bool ScheduleSelect
        {
            get { return _ScheduleSelect; }
            set
            {

                _ScheduleSelect = value;

                RaisePropertyChanged("ScheduleSelect");

            }
        }

        public string _sku;
        public string sku { get { return _sku; } set { _sku = value; RaisePropertyChanged("sku"); } }
    }
    public partial class SupplierCatalogueRange
    {
        public string stocking_unit { get; set; }

        public Nullable<int> item_id { get; set; }
        public string ItemCode { get; set; }
        public Nullable<decimal> range1 { get; set; }
        public Nullable<decimal> range2 { get; set; }
        public Nullable<decimal> gsm_range1 { get; set; }
        public Nullable<decimal> gsm_range2 { get; set; }
        public Nullable<decimal> chop_range1 { get; set; }
        public Nullable<decimal> chop_range2 { get; set; }
        public Nullable<decimal> deckle_range1 { get; set; }
        public Nullable<decimal> deckle_range2 { get; set; }

        public Nullable<decimal> b_rate { get; set; }

        public string range { get; set; }
        public string tax_id { get; set; }
        public Nullable<int> parameter_id { get; set; }

    }
    public class ADM_M033_PopUp
    {
        public string ColurCode { get; set; }
        [DisplayName("Colour")]
        public string Colour { get; set; }
    }
    public class ADM_M031_PopUp
    {
        public int id { get; set; }
        public string CatParamName { get; set; }

    }
    public class ADM_M029_PopUp
    {
        public int id { get; set; }
        [DisplayName("Address Type")]
        public string AddType { get; set; }
        public string Party_Id { get; set; }
        public string Location { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
    }
    public class ADM_M011_PopUp
    {
        public int id { get; set; }
        public string warehouse_name { get; set; }
        public string ProductName { get; set; }

    }
    public class ADM_M027_PopUp1
    {
        public int ContInfoId { get; set; }
        public string PersnLName { get; set; }
        public string PersnFName { get; set; }
        public string PersnMName { get; set; }

    }
    public class ACC_M013_PopUp
    {
        public int id { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }

        public string t_type { get; set; }
        public Nullable<Boolean> include_base_amount { get; set; }
        public Nullable<Boolean> child_depend { get; set; }
        public Nullable<Int32> parent_id { get; set; }

        public string taxaccount { get; set; }

        public Nullable<int> accountcollectdid { get; set; }

        public Nullable<Boolean> Price_include { get; set; }

    }
    public class ADM_M027_PopUp
    {
        public int ContInfoId { get; set; }
        public string PersnLName { get; set; }
        public string PersnFName { get; set; }
        public string PersnMName { get; set; }

    }
    public class ADM_M029_PopUp1
    {
        public int id { get; set; }
        public string Location { get; set; }
        public string AddType { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
    }
}


