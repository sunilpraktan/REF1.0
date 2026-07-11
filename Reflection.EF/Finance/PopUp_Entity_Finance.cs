using System;

namespace Reflection.EF.Finance
{
    public class ACC_M003_X_Variant // Account variant according to Movement Types
    {
        public string mov_tp { get; set; }
        public Nullable<bool> val_update { get; set; }
        public Nullable<bool> qty_update { get; set; }
        public string key_value { get; set; }
        public string mov_ind { get; set; }
        public string cons_post { get; set; }
        public string item_cat { get; set; }
        public string sp_stock { get; set; }
        public string acc_var { get; set; }
        public string client { get; set; }
        public string tran_key_code { get; set; }
    }

    public class ACC_M003_T_Acc_Determination // G/L Account Determination for Inventory
    {
        public string trns_scope { get; set; }
        public string coa_key { get; set; }
        public string con_type { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string gl_code_c { get; set; }
        public string gl_code_d { get; set; }
        public string item_acc_group { get; set; }
        public string item_cat { get; set; }
        public string key_code { get; set; }
        public string key_sequence { get; set; }
        public string party_acc_group { get; set; }
        public string OrgCode { get; set; }
        public string OrgGroup { get; set; }
        public string trns_key_code { get; set; }
        public string acc_pro { get; set; }
        public string gl_name1 { get; set; }
        public string gl_name2 { get; set; }
        public string t_field1 { get; set; }
        public string t_field2 { get; set; }
        public string t_field3 { get; set; }
        public string fun1 { get; set; }
        public string fun2 { get; set; }
        public string fun3 { get; set; }
        public string dr_key { get; set; }
        public string cr_key { get; set; }
        public string sp_gl_ind { get; set; }
        // New addition 0n 30/07/2017 by sunil
        public string value_group { get; set; }
        public string value_class { get; set; }
        public string acc_var { get; set; }
        public string client { get; set; }
        public string mod_group { get; set; }
        public string trns_code { get; set; }
        public string tax_code { get; set; }
        public string buss_place { get; set; }

    }

    public class ACC_M003_Y_Acc_Determination // G/L Account Deternination main Table for Application Types. 
    {
        public string trns_scope { get; set; }
        public string coa_key { get; set; }
        public string con_type { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string gl_code_c { get; set; }
        public string gl_code_d { get; set; }
        public string item_acc_group { get; set; }
        public string item_cat { get; set; }
        public string key_code { get; set; }
        public string key_sequence { get; set; }
        public string party_acc_group { get; set; }
        public string OrgCode { get; set; }
        public string OrgGroup { get; set; }
        public string trns_key_code { get; set; }
        public string acc_pro { get; set; }
        public string gl_name1 { get; set; }
        public string gl_name2 { get; set; }
        public string t_field1 { get; set; }
        public string t_field2 { get; set; }
        public string t_field3 { get; set; }
        public string fun1 { get; set; }
        public string fun2 { get; set; }
        public string fun3 { get; set; }
        public string dr_key { get; set; }
        public string cr_key { get; set; }
        public string sp_gl_ind { get; set; }
        // New addition 0n 30/07/2017 by sunil
        public string value_group { get; set; }
        public string value_class { get; set; }
        public string acc_var { get; set; }
        public string client { get; set; }
        public string mod_group { get; set; }
        public string trns_code { get; set; }
        public string tax_code { get; set; }
        public string buss_place { get; set; }

    }

    public class PP_FICO_Ledger // Account variant according to Movement Types
    {
        public string gl_code { get; set; }
        public string gl_name { get; set; }
        public string ledger_gen { get; set; }
        public string ledger_gen_name { get; set; }
        public string recon_acc { get; set; }
        public string acc_type { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
    }
}
