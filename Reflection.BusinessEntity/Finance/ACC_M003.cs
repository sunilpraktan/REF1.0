using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003 : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                { _id = value; RaisePropertyChanged("id"); }
            }
        }
        private string _acc_code;
        public string acc_code
        {
            get { return _acc_code; }
            set
            {
                if (_acc_code != value)
                { _acc_code = value; RaisePropertyChanged("acc_code"); }
            }
        }

        private Nullable<int> _parent_left;
        public Nullable<int> parent_left
        {
            get { return _parent_left; }
            set
            {
                if (_parent_left != value)
                { _parent_left = value; RaisePropertyChanged("parent_left"); }
            }
        }

        private Nullable<int> _parent_right;
        public Nullable<int> parent_right
        {
            get { return _parent_right; }
            set
            {
                if (_parent_right != value)
                { _parent_right = value; RaisePropertyChanged("parent_right"); }
            }
        }
        private string _p_code;
        public string p_code
        {
            get { return _p_code; }
            set
            {
                if (_p_code != value)
                { _p_code = value; RaisePropertyChanged("p_code"); }
            }
        }
        private Nullable<bool> _reconcile;
        public Nullable<bool> reconcile
        {
            get { return _reconcile; }
            set
            {
                if (_reconcile != value)
                { _reconcile = value; RaisePropertyChanged("reconcile"); }
            }
        }
        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                if (_curr_code != value)
                { _curr_code = value; RaisePropertyChanged("curr_code"); }
            }
        }
        private Nullable<int> _user_type;
        public Nullable<int> user_type
        {
            get { return _user_type; }
            set
            {
                if (_user_type != value)
                { _user_type = value; RaisePropertyChanged("user_type"); }
            }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                { _active = value; RaisePropertyChanged("active"); }
            }
        }
        private string _p_name;
        public string p_name
        {
            get { return _p_name; }
            set
            {
                if (_p_name != value)
                { _p_name = value; RaisePropertyChanged("p_name"); }
            }
        }
        private Nullable<int> _p_level;
        public Nullable<int> p_level
        {
            get { return _p_level; }
            set
            {
                if (_p_level != value)
                { _p_level = value; RaisePropertyChanged("p_level"); }
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                { _location_Id = value; RaisePropertyChanged("location_Id"); }
            }
        }
        private string _shortcut;
        public string shortcut
        {
            get { return _shortcut; }
            set
            {
                if (_shortcut != value)
                { _shortcut = value; RaisePropertyChanged("shortcut"); }
            }
        }
        private string _p_note;
        public string p_note
        {
            get { return _p_note; }
            set
            {
                if (_p_note != value)
                { _p_note = value; RaisePropertyChanged("p_note"); }
            }
        }
        private Nullable<int> _parent_id;
        public Nullable<int> parent_id
        {
            get { return _parent_id; }
            set
            {
                if (_parent_id != value)
                { _parent_id = value; RaisePropertyChanged("parent_id"); }
            }
        }
        private string _currency_mode;
        public string currency_mode
        {
            get { return _currency_mode; }
            set
            {
                if (_currency_mode != value)
                { _currency_mode = value; RaisePropertyChanged("currency_mode"); }
            }
        }
        private string _p_type;
        public string p_type
        {
            get { return _p_type; }
            set
            {
                if (_p_type != value)
                { _p_type = value; RaisePropertyChanged("p_type"); }
            }
        }
        
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");
                }
            }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");
                }
            }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                if (_editby != value)
                {
                    _editby = value; RaisePropertyChanged("editby");
                }
            }
        }
        private string _ac_group_code;
        public string ac_group_code
        {
            get { return _ac_group_code; }
            set
            {
                if (_ac_group_code != value)
                {
                    _ac_group_code = value; RaisePropertyChanged("ac_group_code");
                }
            }
        }
        private string _ac_sg_code;
        public string ac_sg_code
        {
            get { return _ac_sg_code; }
            set
            {
                if (_ac_sg_code != value)
                {
                    _ac_sg_code = value; RaisePropertyChanged("ac_sg_code");
                }
            }
        }
        private Nullable<int> _seq_no;
        public Nullable<int> seq_no
        {
            get { return _seq_no; }
            set
            {
                if (_seq_no != value)
                {
                    _seq_no = value; RaisePropertyChanged("seq_no");
                }
            }
        }
        private string _par_gl_code;
        public string par_gl_code
        {
            get { return _par_gl_code; }
            set
            {
                if (_par_gl_code != value)
                {
                    _par_gl_code = value; RaisePropertyChanged("par_gl_code");
                }
            }
        }
        private string _acc_type;
        public string acc_type
        {
            get { return _acc_type; }
            set
            {
                if (_acc_type != value)
                {
                    _acc_type = value; RaisePropertyChanged("acc_type");
                }
            }
        }
        private string _sundry_type;
        public string sundry_type
        {
            get { return _sundry_type; }
            set
            {
                if (_sundry_type != value)
                {
                    _sundry_type = value; RaisePropertyChanged("sundry_type");
                }
            }
        }
        private string _Posting;
        public string Posting
        {
            get { return _Posting; }
            set
            {
                if (_Posting != value)
                {
                    _Posting = value; RaisePropertyChanged("Posting");
                }
            }
        }
        private string _to_inc;
        public string to_inc
        {
            get { return _to_inc; }
            set
            {
                if (_to_inc != value)
                {
                    _to_inc = value; RaisePropertyChanged("to_inc");
                }
            }
        }
        private string _code_format;
        public string code_format
        {
            get { return _code_format; }
            set
            {
                if (_code_format != value)
                {
                    _code_format = value; RaisePropertyChanged("code_format");
                }
            }
        }
        private string _short_desc;
        public string short_desc
        {
            get { return _short_desc; }
            set
            {
                if (_short_desc != value)
                {
                    _short_desc = value; RaisePropertyChanged("short_desc");
                }
            }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }

        
        private string _language;
        public string language
        {
            get { return _language; }
            set
            {
                if (_language != value)
                {
                    _language = value; RaisePropertyChanged("language");
                }
            }
        }
        private string _gl_code;
        public string gl_code
        {
            get { return _gl_code; }
            set
            {
                if (_gl_code != value)
                {
                    _gl_code = value; RaisePropertyChanged("gl_code");
                }
            }
        }
        private string _group_cat;
        public string group_cat
        {
            get { return _group_cat; }
            set
            {
                if (_group_cat != value)
                {
                    _group_cat = value; RaisePropertyChanged("group_cat");
                }
            }
        }
        private string _ind_bal;
        public string ind_bal
        {
            get { return _ind_bal; }
            set
            {
                if (_ind_bal != value)
                {
                    _ind_bal = value; RaisePropertyChanged("ind_bal");
                }
            }
        }

        private string _ind_sp_gl_code;
        public string ind_sp_gl_code
        {
            get { return _ind_sp_gl_code; }
            set
            {
                if (_ind_sp_gl_code != value)
                {
                    _ind_sp_gl_code = value; RaisePropertyChanged("ind_sp_gl_code");
                }
            }
        }

        private string _ind_pl;
        public string ind_pl
        {
            get { return _ind_pl; }
            set
            {
                if (_ind_pl != value)
                {
                    _ind_pl = value; RaisePropertyChanged("ind_pl");
                }
            }
        }
        private string _house_bank_key;
        public string house_bank_key
        {
            get { return _house_bank_key; }
            set
            {
                if (_house_bank_key != value)
                {
                    _house_bank_key = value; RaisePropertyChanged("house_bank_key");
                }
            }
        }
        private string _exch_rate_key;
        public string exch_rate_key
        {
            get { return _exch_rate_key; }
            set
            {
                if (_exch_rate_key != value)
                {
                    _exch_rate_key = value; RaisePropertyChanged("exch_rate_key");
                }
            }
        }
        private string _tol_group;
        public string tol_group
        {
            get { return _tol_group; }
            set
            {
                if (_tol_group != value)
                {
                    _tol_group = value; RaisePropertyChanged("tol_group");
                }
            }
        }
        private string _ind_wo_tax;
        public string ind_wo_tax
        {
            get { return _ind_wo_tax; }
            set
            {
                if (_ind_wo_tax != value)
                {
                    _ind_wo_tax = value; RaisePropertyChanged("ind_wo_tax");
                }
            }
        }
        private string _ind_recon;
        public string ind_recon
        {
            get { return _ind_recon; }
            set
            {
                if (_ind_recon != value)
                {
                    _ind_recon = value; RaisePropertyChanged("ind_recon");
                }
            }
        }
        private string _ind_pending_item;
        public string ind_pending_item
        {
            get { return _ind_pending_item; }
            set
            {
                if (_ind_pending_item != value)
                {
                    _ind_pending_item = value; RaisePropertyChanged("ind_pending_item");
                }
            }
        }
        private string _ind_line_item;
        public string ind_line_item
        {
            get { return _ind_line_item; }
            set
            {
                if (_ind_line_item != value)
                {
                    _ind_line_item = value; RaisePropertyChanged("ind_line_item"); 
                }
            }
        }
        private string _ind_cash_flow;
        public string ind_cash_flow
        {
            get { return _ind_cash_flow; }
            set
            {
                if (_ind_cash_flow != value)
                {
                    _ind_cash_flow = value; RaisePropertyChanged("ind_cash_flow"); 
                }
            }
        }

        private string _ind_cash_receipt;
        public string ind_cash_receipt
        {
            get { return _ind_cash_receipt; }
            set
            {
                if (_ind_cash_receipt != value)
                {
                    _ind_cash_receipt = value; RaisePropertyChanged("ind_cash_receipt");
                }
            }
        }

        private string _ind_block;
        public string ind_block
        {
            get { return _ind_block; }
            set
            {
                if (_ind_block != value)
                {
                    _ind_block = value; RaisePropertyChanged("ind_block");
                }
            }
        }
        //Scaller

        private string _curr_name;
        public string curr_name
        {
            get { return _curr_name; }
            set
            {
                if (_curr_name != value)
                {
                    _curr_name = value; RaisePropertyChanged("curr_name");
                }
            }
        }
        private string _bank_name;
        public string bank_name
        {
            get { return _bank_name; }
            set
            {
                if (_bank_name != value)
                {
                    _bank_name = value; RaisePropertyChanged("bank_name");
                }
            }
        }

        private string _ac_group_name;
        public string ac_group_name
        {
            get { return _ac_group_name; }
            set
            {
                if (_ac_group_name != value)
                {
                    _ac_group_name = value; RaisePropertyChanged("ac_group_name");
                }
            }
        }
        private string _ac_sg_name;
        public string ac_sg_name
        {
            get { return _ac_sg_name; }
            set
            {
                if (_ac_sg_name != value)
                {
                    _ac_sg_name = value; RaisePropertyChanged("ac_sg_name");
                }
            }
        }
        private string _group_cat_name;
        public string group_cat_name
        {
            get { return _group_cat_name; }
            set
            {
                if (_group_cat_name != value)
                {
                    _group_cat_name = value; RaisePropertyChanged("group_cat_name");
                }
            }
        }
    }
    public class MultipleContext_ACC_M003
    {
        public List<ACC_M003> AccLedgerList { get; set; }
        public List<ADM_M037_P> CurrencyList { get; set; }
        public List<ACC_M003_A_P> AccGroupList { get; set; }
        public List<ACC_M004_A_P> BankKeyList { get; set; }
        public List<ACC_M003_B_P> AccGroupSubList { get; set; }
        public List<ACC_M003_C_P> GrpCatList { get; set; }
    }
}
