using Reflection.EF.ADM;
using Reflection.EF.Admin;
using Reflection.EF.COM;
using Reflection.EF.Communication;
using Reflection.EF.CRM;
using Reflection.EF.ENG;
using Reflection.EF.FICO;
using Reflection.EF.Finance;
using Reflection.EF.GEN;
using Reflection.EF.MM;
using Reflection.EF.PMM;
using Reflection.EF.PMS;
using Reflection.EF.Procurement;
using Reflection.EF.Production;
using Reflection.EF.QMS;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.SCM;
using Reflection.EF.SDM;
using System.Collections.Generic;

namespace Reflection.EF
{
    // NOTE:  for General and other entity fields, we can create once base entity for generela and one module specific entity in which base entity will get inherited. in this way we can avoide big single entity for all ERP. we will do this on last module not now, because now it is not that big.
    // First we will create this entities to avoide and delete BusinessEntityForPopUp. creat one class and keep on adding all classes fields in this new class, once done then think about above comment.
    public class STD_MC_BE
    {
        public string request { get; set; }
        public List<STD_LIST_BE> MATERIAL_LIST { get; set; }
        public List<COM_T011> WORKFLOW_LIST { get; set; }
        public List<STD_LIST_BE> COMON_LIST { get; set; }
        public List<STD_LIST_BE> COMON_LIST1 { get; set; }
        public List<STD_LIST_BE> COMON_LIST2 { get; set; }
        public List<STD_BE_A> STD_BE_LIST { get; set; }
        public List<STD_LIST_BE> GRID_COLLECTION { get; set; } // Main Grid of the screen, whare no other cection on screen like inspection due or RM GRN
        public List<STD_LIST_BE> BACK_FLIP_LIST { get; set; }
        public List<STD_LIST_BE> REF_DOC_LIST { get; set; }
        public List<STD_LIST_BE> BATCH_CODE_LIST { get; set; }
        public List<ACC_M013> TAX_LIST { get; set; }
        public List<ADM_M037> CURRENCY_LIST { get; set; } //Depricated
        public List<FICO_M0033> CURR_LIST { get; set; }
        public List<UOMS> UOM_LIST { get; set; }
        public List<UOMS> UOM_CONVERSION_LIST { get; set; }
        public List<STD_DOC_CAT> DOC_CAT_LIST { get; set; }
        public List<STD_DOC_CAT> REF_DOC_CAT_LIST { get; set; }
        public List<STD_DOC_TYPE> DOC_TYPE_LIST { get; set; }
        public List<ADM_M0010> DOC_TYPE_LIST_NEW { get; set; }
        public List<STD_DOC_TYPE> REF_DOC_TYPE_LIST { get; set; }
        public List<COM_T003> ATTACHMENT_LIST { get; set; }
        public List<ADM_M0013> STATUS_LIST { get; set; }
        public List<STD_ITEM> STD_ITEM_LIST { get; set; }
        public List<STD_ITEM> ITEM_LIST { get; set; }
        public List<STD_ITEM> COMPONANT_LIST { get; set; }
        public List<STD_ITEM> BATCH_LIST { get; set; }
        public List<STD_ITEM> STD_ITEM_HU_LIST { get; set; }
        public List<STD_MIS_BE> STD_MIS_LIST { get; set; }
        public List<STD_MIS_BE> STD_MIS_LIST2 { get; set; }
        public List<STD_MIS_BE> STD_MIS_LIST3 { get; set; }
        public List<STD_MIS_BE> STD_MIS_LIST4 { get; set; }
        public List<STD_MIS_BE> STD_MIS_LIST5 { get; set; }
        public List<STD_MIS_BE> STD_MIS_LIST6 { get; set; }
        public List<STD_DOC_TYPE_SETTINGS> DOC_TYPE_SETTINGS_LIST { get; set; }
        public List<STD_PERSONNEL> STD_PERSONNEL_LIST { get; set; }
        public List<MM_M0001> STORE_LIST { get; set; }
        public List<NotificationData> NOTIFICATION_LIST { get; set; }
        public List<POSTING_KEY_DR_CR> POSTING_KEY_DR_CR_LIST { get; set; }
        public List<ADM_M0071> PARAMETERS_LIST { get; set; } // SKU's Parameters List. Reserve for seperate Entity otherwise use "PARAMETERS_VALUES_LIST" object.
        public List<ADM_M0071> PARAMETERS_VALUES_LIST { get; set; } // SKU's Parameters and its Values
        public List<ADM_M0002> COMPANY_LIST { get; set; }
        public List<ADM_M0003> LOCATION_LIST { get; set; }
        public List<ADM_M018> ITEM_CAT_LIST { get; set; }
        public List<ADM_M019> ITEM_SUBCAT_LIST { get; set; }
        public List<ADM_M015> ITEM_TYPE_LIST { get; set; }
        public List<ADM_M016> ITEM_SUBTYPE_LIST { get; set; }
        public List<STD_LIST_BE> POSTING_PERIOD_LIST { get; set; }
        public List<STD_LIST_BE> FIN_YEAR_LIST { get; set; }
        public List<STD_PARTY> PARTY_LIST { get; set; }
        public List<GEN_M0011> ADDRESS_LIST { get; set; }
        public List<GEN_M0021> CP_LIST { get; set; } // Contact person List
        public List<GEN_M0031> CN_LIST { get; set; } // Contact person contact number List
        public List<STD_PARTY> PARTY_CONTACT_LIST { get; set; }
        public List<STD_PARTY> BILLING_ADDRESS_LIST { get; set; }
        public List<STD_PARTY> SHIPPING_ADDRESS_LIST { get; set; }
        public List<STD_LIST_BE> ORG_LIST { get; set; }
        public List<STD_LIST_BE> ORG_GROUP_LIST { get; set; }
        public List<STD_PERSONNEL> PERSONNEL_LIST { get; set; }
        public List<STD_LIST_BE> TRADE_INDICATOR { get; set; }
        public List<STD_LIST_BE> COUNTRY_LIST { get; set; }
        public List<STD_LIST_BE> STATE_LIST { get; set; }
        public List<STD_LIST_BE> INCOTERM_LIST { get; set; }
        public List<STD_LIST_BE> PARTY_TYPE_LIST { get; set; }
        public List<STD_LIST_BE> RECORD_TYPE_LIST { get; set; }
        public List<STD_LIST_BE> WC_LIST { get; set; } // Work Center List
        public List<STD_LIST_BE> SHIFT_LIST { get; set; }
        public List<STD_LIST_BE> OPERATION_LIST { get; set; }
        public List<STD_LIST_BE> STANDARD_LIST { get; set; }
        public List<STD_LIST_BE> REASON_LIST { get; set; }
        public List<STD_LIST_BE> VALUE_LIST { get; set; }
        public List<STD_LIST_BE> OBJECT_TYPE_LIST { get; set; }
        public List<STD_LIST_BE> OBJECT_LIST { get; set; }
        public List<Classification> CLASS_TYPE_LIST { get; set; }
        public List<Classification> CLASS_LIST { get; set; } // NOTE: Depricated, remoe all places and use VC_CLASS_LIST
        public List<STD_LIST_BE> VC_CLASS_LIST { get; set; } // NOTE: rename to CLASS_LIST once all reference remove for CLASS_LIST old
        public List<Classification> CHAR_LIST { get; set; } // NOTE: Depricated, remoe all places and use CHARACTRISTICS_LIST
        public List<STD_LIST_BE> CHARACTRISTICS_LIST { get; set; } // NOTE: rename to CHAR_LIST once all reference remove for CHAR_LIST old
        public List<Classification> CHAR_VALUE_LIST { get; set; }
        public List<STD_LIST_BE> CHAR_GROUP_LIST { get; set; }
        public List<ADM_M0126> VC_LIST { get; set; } // List for Variant Configuration (VC Code) List
        public List<ADM_M0127> VC_VALUE_LIST { get; set; } // List for Variant Configuration values
        public List<Classification> CLASS_PROFILE_LIST { get; set; }
        public List<Classification> CLASS_GROUP_LIST { get; set; }
        public List<STD_LIST_BE> KEY_DATA_LIST { get; set; }
        public List<STD_FICO_BE> CONDITION_TYPE_LIST { get; set; }
        public List<STD_LIST_BE> GROUP_LIST { get; set; }
        public List<STD_LIST_BE> TYPE_LIST { get; set; }
        public List<STD_LIST_BE> CATEGORY_LIST { get; set; }
        public List<STD_LIST_BE> BOM_LIST { get; set; }
        public List<STD_LIST_BE> BOM_CAT_LIST { get; set; }
        public List<STD_LIST_BE> ROUTING_LIST { get; set; }
        public List<STD_LIST_BE> PARA_TYPE_LIST { get; set; } //public List<QMS_M032_P> ParaTypeMaster { get; set; }
        public List<STD_LIST_BE> LINE_CAT_LIST { get; set; } // Line Category
        public List<STD_LIST_BE> METHOD_LIST { get; set; }  //public List<QMS_M030_G_P> InspMethod { get; set; }
        public List<STD_LIST_BE> PROCEDURE_LIST { get; set; }  // public List<QMS_M034_P> SampleProcedure { get; set; }
        public List<STD_LIST_BE> QUALIFICATION_LIST { get; set; } //public List<QMS_M022_P> QualiMaster { get; set; }
        public List<STD_LIST_BE> USAGE_LIST { get; set; }   // public List<SYS_M048> UsageMaster { get; set; }
        public List<STD_LIST_BE> IND_CONS_LIST { get; set; } //Indicator_consumption
        public List<STD_LIST_BE> MASTER_TASK_LIST { get; set; }
        public List<STD_LIST_BE> EQUIPMENT_LIST { get; set; }
        public List<STD_LIST_BE> PAYTERM_LIST { get; set; }
        public List<STD_LIST_BE> STD_PROFILE_LIST { get; set; }
        public List<STD_LIST_BE> ACTION_LIST { get; set; }
        public List<STD_LIST_BE> GEN_TASK_LIST { get; set; }
        public List<ADM_M0010> DOCTYPE_LIST { get; set; }
        public List<STD_LIST_BE> REPORT_LIST { get; set; } // Same as from STD_MIS_MC_BE
        public List<ADM_M0051> CONDITION_LIST { get; set; } // depricated
        public List<ADM_M0051> TC_LIST { get; set; } // Remove CONDITION_LIST and use this
        public List<STD_LIST_BE> GL_LIST { get; set; }
        public List<ADM_M043_D> ApprovalData { get; set; } // NOTE: replace this with standard Entity and Table
        public List<STD_LIST_BE> DEFAULT_VALUE_LIST { get; set; }
        public List<ENG_T005_B> CHAR_SPECS_LIST { get; set; }
        public List<ADM_M0111> MASTER_CHAR_LIST { get; set; }
        public List<STD_LIST_BE> DEPT_LIST { get; set; }
        public List<GEN_T021> GEN_CHAR_VALUE_LIST { get; set; } // This is for Template for new transaction. 
        public List<STD_LIST_BE> SUB_GROUP_LIST { get; set; }
        public List<STD_LIST_BE> REGION_LIST { get; set; }
        public List<STD_LIST_BE> ASSET_LIST { get; set; }
        public List<STD_LIST_BE> PRICE_LIST { get; set; }
        public List<GEN_M0101> STYLE_LIST { get; set; }
        public List<SYS_C0101> RPT_SETTING { get; set; }
        public List<Test_Header> TEST_HEADER { get; set; }
    }
    public class MC_SYS_BE : STD_MC_BE
    {
        public List<SYS_AUTH> USER_LIST { get; set; } // Standard List of Users
        public List<SYS_AUTH> USER_TYPE_LIST { get; set; } // Standard List of Users Type
        public List<SYS_AUTH> TS_CODE_LIST { get; set; } // Standard List of TS Codes
        public List<SYS_AUTH> ROLE_LIST { get; set; } // List of User Roles
        public List<SYS_AUTH> ROLE_USER_LIST { get; set; } // Assignemnt of User to Role 
        public List<SYS_AUTH> ROLE_TSCODE_LIST { get; set; } // Assignemnt of TS Code to User Role List
        public List<SYS_AUTH> STD_AUTH_LIST { get; set; } // Standard Authorisation list like Create, Modify, Delete, View, Print etc...
        public List<SYS_AUTH> TSCODE_AUTH_LIST { get; set; } // Assignment of Authorisdation to User Role and TS Code.

        public List<SYS_C0101> RPT_SETTING_LIST { get; set; } // Report setting List
    }
    public class MC_SDM_BE : STD_MC_BE
    {
        public List<STD_PARTY> SUPPLIER_LIST { get; set; }
        public List<SYS_M026> TR_MODE_LIST { get; set; }
        //public List<STD_LIST_BE> GL_LIST { get; set; }
        public List<STD_LIST_BE> PAY_TERM_LIST { get; set; }
        //public List<ADM_M013_P> STATE_LIST { get; set; }
        public List<FICO_M0004> BANK_ACCOUNT_LIST { get; set; }
        public List<STD_PARTY> OTHER_CONTACT_LIST { get; set; }
        public List<PMS_T002> ELEMENT_LIST { get; set; }
        public List<ADM_M041_P> LicenceList { get; set; }
        public List<ACC_M003_O_P> ConditionTypeList { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<SEL_T001> MasterEntity { get; set; }//Sales_Order
        public List<SEL_T001_A> ItemsEntity { get; set; }//Sales_Order_Items Details 
        public List<GEN_T011> TermsAndCondition { get; set; }
        public List<ACC_T006_B> TaxEntity { get; set; }//Tax_Details
        public List<SEL_T002> ScheduleMasterEntity { get; set; }
        public List<SEL_T002_A> ScheduleDetailsEntity { get; set; }
        public List<ACC_T006_D> LicenceEntity { get; set; }
        public List<SEL_T001_PART> PartnerEntity { get; set; }//Sales_Order_Partner Details 
        public List<STD_LIST_BE> PF_CODE_LIST { get; set; }
        public List<ACC_T021> BillingPlanEntity { get; set; }

    }
    public class MC_FICO_BE : STD_MC_BE
    {
        public List<FICO_M0004> BANK_LIST { get; set; }
        public List<FICO_M0004> BANK_ACCOUNT_LIST { get; set; }
        public List<STD_LIST_BE> PAYMENT_METHOD_LIST { get; set; }
        public List<FICO_M0019> COST_CENTER_LIST { get; set; }
        public List<FICO_M0020> PROFIT_CENTER_LIST { get; set; }
        public List<STD_FICO_BE> LICENCE_LIST { get; set; }
        public List<STD_FICO_BE> WITHHOLDING_LIST { get; set; }
        public List<InvoiceTraceEntity> TraceList { get; set; } // NOTE: Replace with Standard Entity
        public List<ACC_M003> GL_ACCOUNT_LIST { get; set; }
        public List<FICO_M0033> CURR_OC_LIST { get; set; }
        public List<FICO_M0004> AC_TYPE_LIST { get; set; }

    }
    public class MC_MM_BE : STD_MC_BE
    {
        public List<ADM_M0040> PRIORITY_LIST { get; set; }
        public List<STD_LIST_BE> DEPARTMENT_LIST { get; set; }
        public List<STD_LIST_BE> ORDER_LIST { get; set; }
        public List<STD_LIST_BE> INDENT_ORDER_LIST { get; set; }
        public List<STD_LIST_BE> PROJECT_LIST { get; set; }
        public List<MM_T003_S> MM_SETTING_LIST { get; set; }
        public List<MM_M0004> MOV_TYPE_LIST { get; set; }
        public List<SYS_M026> TR_MODE_LIST { get; set; }
        public List<MM_M0011> DOC_ITEM_CAT_LIST { get; set; }

    }
    public class MC_ADM_BE : STD_MC_BE
    {
        public List<STD_LIST_BE> DATA_TYPE_LIST { get; set; }
    }
    public class MC_GEN_BE : STD_MC_BE
    {
        public List<STD_BE_A> STD_ENTITY_LIST { get; set; }
        public List<STD_BE_A> STD_ENTITY_COL { get; set; }
        public List<STD_BE_A> STD_MASTER_LIST { get; set; }
        public List<STD_BE_A> MasterEntity { get; set; }
        public List<STD_BE_A> ItemsEntity { get; set; }

    }
    //public class MC_GENERIC_BE : STD_MC_BE
    //{
    //    public List<STD_BE_A> STD_ENTITY_LIST { get; set; }
    //    public List<STD_BE_A> STD_ENTITY_COL { get; set; }
    //    public List<STD_BE_A> STD_MASTER_LIST { get; set; }
    //    public List<STD_BE_A> MasterEntity { get; set; }
    //    public List<STD_BE_A> ItemsEntity { get; set; }

    //}
    public class STD_MIS_MC_BE : STD_MC_BE
    {
        public List<STD_LIST_BE> REGION_LIST { get; set; }
        public List<STD_LIST_BE> CUSTOMER_GROUP_LIST { get; set; }
        public List<STD_LIST_BE> SORT_ORDER_LIST { get; set; }

    }
    public class MC_PMS_BE : STD_MC_BE
    {
        public List<PMS_T001> PROJECT_LIST { get; set; }
        public List<PMS_T002> ELEMENT_LIST { get; set; }
        public List<PMS_T004> MILESTONE_LIST { get; set; }
        public List<PMS_T006> SCHEDULE_LIST { get; set; }
        public List<ADM_M0040> PRIORITY_LIST { get; set; }
        public List<EPR_T001> TASK_LIST { get; set; }
        public List<EPR_T001_A> ACTIVITY_LIST { get; set; }
        public List<EPR_T001_B> ACTIVITY_DATES_LIST { get; set; }
        public List<STD_LIST_BE> TREE_LIST_VIEW { get; set; }
        public List<FICO_M0019> COST_CENTER_LIST { get; set; }
        public List<FICO_M0020> PROFIT_CENTER_LIST { get; set; }
        public List<SYS_M051> CONTROL_KEY_LIST { get; set; }
        public List<STD_LIST_BE> PHASE_LIST { get; set; }
        public List<STD_LIST_BE> TASK_STD_LIST { get; set; }
        public List<EPR_T001_C> DEPENDENCY_LIST { get; set; }
        

    }
    public class MC_PPC_BE : STD_MC_BE
    {
        public List<EPR_T001> MasterEntity { get; set; }
        public List<EPR_T001_A> OperationEntity { get; set; }
        public List<EPR_T001_B> OperatopnDatesEntity { get; set; }
        public List<EPR_T001> ORDER_LIST { get; set; }
        public List<SYS_M051> CONTROL_KEY_LIST { get; set; }
        public List<PMS_T001> PROJECT_LIST { get; set; }
        public List<PMS_T002> ELEMENT_LIST { get; set; }
        public List<ADM_M0040> PRIORITY_LIST { get; set; }
        public List<EPR_T001> TASK_LIST { get; set; }
        public List<EPR_T001_A> ACTIVITY_LIST { get; set; }
        public List<EPR_T001_B> ACTIVITY_DATES_LIST { get; set; }
        public List<FICO_M0019> COST_CENTER_LIST { get; set; }
        public List<FICO_M0020> PROFIT_CENTER_LIST { get; set; }
        public List<STD_LIST_BE> PHASE_LIST { get; set; }
        public List<STD_LIST_BE> TASK_STD_LIST { get; set; }
        public List<EPR_T002> CONFIRMATION_LIST { get; set; }

        public List<STD_LIST_BE> SO_LIST { get; set; } // SD Order List
        public List<STD_LIST_BE> SO_ITEM_LIST { get; set; } // SD Order List
        public List<STD_LIST_BE> QN_LIST { get; set; } // Quotation list
        public List<STD_LIST_BE> SN_LIST { get; set; } // Inquiry List
        public List<STD_LIST_BE> DN_LIST { get; set; } // Delivery info
        public List<STD_LIST_BE> GM_LIST { get; set; } // Goods Movement List
        public List<STD_LIST_BE> INVOICE_LIST { get; set; } // Invoice List
        public List<STD_LIST_BE> ACCOUNT_LIST { get; set; } // Bank Account info
        public List<STD_LIST_BE> PMM_LIST { get; set; } // Maintainence History info
        public List<EPR_T001_C> DEPENDENCY_LIST { get; set; }


    }
    public class MC_PMM_BE : STD_MC_BE
    {
        public List<PMM_M0001> EQUIPMENT_MASTER_LIST { get; set; } // Equipment List
        public List<PMM_M0021> FLEET_LIST { get; set; } // Fleet List
        public List<PMM_T005> MEASUREMENT_LIST { get; set; }
        public List<ENG_M0005> MEASUREMENT_POINT_LIST { get; set; }
        public List<STD_LIST_BE> FUNC_LOCATION_LIST { get; set; }
        public List<STD_DOC_TYPE> ORDER_CAT_LIST { get; set; }
        public List<STD_LIST_BE> PLAN_CAT_LIST { get; set; }
        public List<STD_LIST_BE> STRATEGY_LIST { get; set; }
        public List<STD_LIST_BE> MP_LIST { get; set; } // Measuring Point List

    }
    public class MC_ENG_BE : STD_MC_BE
    {
        public List<ENG_T001> MasterEntity { get; set; }
        public List<ENG_T001_A> ItemsEntity { get; set; }
        public List<ENG_T001_C> BOMAssignmentEntity { get; set; }
        public List<ENG_T005> MasterEntityTask { get; set; }
        public List<ENG_T005_R> ComponantEntity { get; set; }
        public List<ENG_T005_A> OperationEntity { get; set; }
        public List<ENG_T005_B> CharEntity { get; set; }
        public List<ENG_T005_C> SelectedSetEntity { get; set; }
        public List<ENG_T005_M> AssignmentEntity { get; set; }
        public List<PMM_T005> MEASUREMENT_LIST { get; set; }
        public List<ENG_M0005> MEASUREMENT_POINT_LIST { get; set; }
        public List<ENG_T005_B> VCHAR_LIST { get; set; }
        public List<ENG_T001_C> BOMItemAssignmentEntity { get; set; }

    }
    public class MC_COM_BE : STD_MC_BE
    {
        public List<STD_LIST_BE> NOT_TYPE_LIST { get; set; } // Notification Type
        public List<STD_LIST_BE> FUNC_LOCATION_LIST { get; set; }
    }
    public class MC_QMS_BE : STD_MC_BE
    {
        public List<QMS_T003> INSP_LOT_LIST { get; set; }
        public List<STD_LIST_BE> LOT_ORIGIN { get; set; }
        public List<QMS_M0003> FUNCTION_LOCATION_LIST { get; set; }
        public List<STD_LIST_BE> FUNC_LOCATION_LIST { get; set; }
        public List<QMS_M0002> INSPECTION_METHOD_LIST { get; set; }
        public List<QMS_M0047> INSP_TYPE_LOT_ORG { get; set; }
        //public List<QMS_P002_P> LotOriginMaster { get; set; }
        //public List<QMS_M033_A> Profile_Values { get; set; }
        //public List<QMS_T003_U> Usage_Decision { get; set; }
        //public List<QMS_M048> Folloup_Action { get; set; }

    }
}
