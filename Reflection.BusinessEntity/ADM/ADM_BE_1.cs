using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.ADM
{

    public class ADM_M0002
    {
        public string client { get; set; }
        public string group_code { get; set; }
        public string comp_code { get; set; }
        public string comp_name { get; set; }
        public string abrv { get; set; }
        public string curr_code { get; set; }
        public string buss_place { get; set; }
        public string ctr_code { get; set; }
        public byte[] comp_logo { get; set; }

        public string add_code { get; set; } // NOTE: add this as column and maintain address in the address table.
        public string address { get; set; } // NOTE: Make this as scallar and user for address construction for display

        public string back_color { get; set; }
        public string four_color { get; set; }
        public string font_family { get; set; }
        public string font_size { get; set; }
        public string ind_underline { get; set; }
        public string ind_italic { get; set; }
        public string tax_reg_no { get; set; }
        public string logo_url { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", comp_code);
        }
    }
    public class ADM_M0003
    {
        public string client { get; set; }
        public string group_code { get; set; }
        public string comp_code { get; set; }
        public string comp_name { get; set; }
        public string abrv { get; set; }
        public string location_id { get; set; }
        public string location_name { get; set; }
        public string place { get; set; }
        public string city { get; set; }
        public string state_code { get; set; }
        public string state { get; set; }
        public string country_code { get; set; }
        public string ctr_code { get; set; }
        public string buss_place { get; set; }

        public string add_code { get; set; } // NOTE: add this as column and maintain address in the address table.
        public string address { get; set; } // NOTE: Make this as scallar and user for address construction for display
        public string tax_reg_no { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", location_id);
        }
    }
    public class ADM_M0010
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string doc_type { get; set; }
        public string type_name { get; set; }
        public string doc_type_name { get; set; }
        public string doc_type_user { get; set; }
        public string doc_type_doc_no { get; set; }
        public string doc_desc { get; set; }
        public string doc_desc_user { get; set; }
        public string doc_cat { get; set; }
        public bool? default_doc { get; set; }
        public string delivery_type { get; set; }
        public string billing_type { get; set; }
        public string report_name { get; set; }
        public string doc_no_format { get; set; }
        public string Workflow_id_temp { get; set; }
        public int? range1 { get; set; }
        public int? range2 { get; set; }
        public int? doc_no_digits { get; set; }
        public string ts_code { get; set; }
        public string ts_code_mi { get; set; }
        public string unit_code { get; set; } // Default Entry Unit. i.e. Hrs(Hourse) in case of Production Entry Time Ticket.
        public bool? auto_roundup { get; set; }
        public int? roundup_digits { get; set; }
        public string posting_key { get; set; }
        public string active { get; set; }

        public string format_no { get; set; } // Document format no
        public string issue_no { get; set; } // Document format issue no
        public DateTime? issue_date { get; set; } // Document format issue date
        public string rev_no { get; set; } // Document format revision no
        public DateTime? rev_date { get; set; } // Document format revision date
        public string ind_printf { get; set; }
        public string ind_digital { get; set; }
        public string ind_header { get; set; }
        public string date_type { get; set; }
        public string title { get; set; }
        public string store_code { get; set; } // default store code for POS invoice
        public string mov_tp_mi { get; set; } // default goods movement type for POS invoice
        public string ts_code_gr { get; set; } // default ts_code for Goods Receipt Note
        public string ts_code_si { get; set; } // default ts_code for invoice
        public string ts_code_or { get; set; }
        public string ind_default { get; set; }
        public int? valid_days { get; set; }

    }
    public class ADM_M0013 : ObjectBase
    {
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value; RaisePropertyChanged("doc_type");
                }
            }
        }
        private string _t_status;

        public string t_status
        {
            get { return _t_status; }
            set
            {
                if (_t_status != value)
                {
                    _t_status = value; RaisePropertyChanged("t_status");
                }
            }
        }
        private string _t_name;

        public string t_name
        {
            get { return _t_name; }
            set
            {
                if (_t_name != value)
                {
                    _t_name = value; RaisePropertyChanged("t_name");
                }
            }
        }
        private int? _id;
        public int? id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }

        }
        private int? _t_sequence;
        public int? t_sequence
        {
            get { return _t_sequence; }
            set
            {
                if (_t_sequence != value)
                {
                    _t_sequence = value; RaisePropertyChanged("t_sequence");
                }
            }

        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                if (_doc_cat != value)
                {
                    _doc_cat = value; RaisePropertyChanged("doc_cat");
                }
            }
        }
        private string _t_module;
        public string t_module
        {
            get { return _t_module; }
            set
            {
                if (_t_module != value)
                {
                    _t_module = value; RaisePropertyChanged("t_module");
                }
            }
        }
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set
            {
                if (_t_display != value)
                {
                    _t_display = value; RaisePropertyChanged("t_display");
                }
            }
        }
        private int? _t_weight;
        public int? t_weight
        {
            get { return _t_weight; }
            set
            {
                if (_t_weight != value)
                {
                    _t_weight = value; RaisePropertyChanged("t_weight");
                }
            }

        }
        private string _t_next;
        public string t_next
        {
            get { return _t_next; }
            set
            {
                if (_t_next != value)
                {
                    _t_next = value; RaisePropertyChanged("t_next");
                }
            }
        }
        private string _t_prev;
        public string t_prev
        {
            get { return _t_prev; }
            set
            {
                if (_t_prev != value)
                {
                    _t_prev = value; RaisePropertyChanged("t_prev");
                }
            }
        }
        private string _ind_draft;
        public string ind_draft
        {
            get { return _ind_draft; }
            set
            {
                if (_ind_draft != value)
                {
                    _ind_draft = value; RaisePropertyChanged("ind_draft");
                }
            }
        }
        private string _ind_closing;
        public string ind_closing
        {
            get { return _ind_closing; }
            set
            {
                if (_ind_closing != value)
                {
                    _ind_closing = value; RaisePropertyChanged("ind_closing");
                }
            }
        }
        private string _ind_close;
        public string ind_close
        {
            get { return _ind_close; }
            set
            {
                if (_ind_close != value)
                {
                    _ind_close = value; RaisePropertyChanged("ind_close");
                }
            }
        }
        private string _ind_closed;
        public string ind_closed
        {
            get { return _ind_closed; }
            set
            {
                if (_ind_closed != value)
                {
                    _ind_closed = value; RaisePropertyChanged("ind_closed");
                }
            }
        }
        private string _ind_custom;
        public string ind_custom
        {
            get { return _ind_custom; }
            set
            {
                if (_ind_custom != value)
                {
                    _ind_custom = value; RaisePropertyChanged("ind_custom");
                }
            }
        }
        private string _ind_manual;
        public string ind_manual
        {
            get { return _ind_manual; }
            set
            {
                if (_ind_manual != value)
                {
                    _ind_manual = value; RaisePropertyChanged("ind_manual");
                }
            }
        }
        private string _ind_doc_type;
        public string ind_doc_type
        {
            get { return _ind_doc_type; }
            set
            {
                if (_ind_doc_type != value)
                {
                    _ind_doc_type = value; RaisePropertyChanged("ind_doc_type");
                }
            }
        }
        private string _ind_change;
        public string ind_change
        {
            get { return _ind_change; }
            set
            {
                if (_ind_change != value)
                {
                    _ind_change = value; RaisePropertyChanged("ind_change");
                }
            }
        }
        private string _ind_cancel;
        public string ind_cancel
        {
            get { return _ind_cancel; }
            set
            {
                if (_ind_cancel != value)
                {
                    _ind_cancel = value; RaisePropertyChanged("ind_cancel");
                }
            }
        }
        private string _ind_modify;
        public string ind_modify
        {
            get { return _ind_modify; }
            set
            {
                if (_ind_modify != value)
                {
                    _ind_modify = value; RaisePropertyChanged("ind_modify");
                }
            }
        }
        private string _ind_valid;
        public string ind_valid
        {
            get { return _ind_valid; }
            set
            {
                if (_ind_valid != value)
                {
                    _ind_valid = value; RaisePropertyChanged("ind_valid");
                }
            }
        }
        private string _ind_validated;
        public string ind_validated
        {
            get { return _ind_validated; }
            set
            {
                if (_ind_validated != value)
                {
                    _ind_validated = value; RaisePropertyChanged("ind_validated");
                }
            }
        }
        private string _ind_active;
        public string ind_active
        {
            get { return _ind_active; }
            set
            {
                if (_ind_active != value)
                {
                    _ind_active = value; RaisePropertyChanged("ind_active");
                }
            }
        }
        private string _ind_default;
        public string ind_default
        {
            get { return _ind_default; }
            set
            {
                if (_ind_default != value)
                {
                    _ind_default = value; RaisePropertyChanged("ind_default");
                }
            }
        }
        private string _ind_goods_posting;
        public string ind_goods_posting
        {
            get { return _ind_goods_posting; }
            set
            {
                if (_ind_goods_posting != value)
                {
                    _ind_goods_posting = value; RaisePropertyChanged("ind_goods_posting");
                }
            }
        }
        private string _ind_released;
        public string ind_released
        {
            get { return _ind_released; }
            set
            {
                if (_ind_released != value)
                {
                    _ind_released = value; RaisePropertyChanged("ind_released");
                }
            }
        }

        private string _ind_ack;
        public string ind_ack
        {
            get { return _ind_ack; }
            set
            {
                if (_ind_ack != value)
                {
                    _ind_ack = value; RaisePropertyChanged("ind_ack");
                }
            }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value; RaisePropertyChanged("lang_key");
                }
            }
        }
        private string _active;
        public string active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }
        //scalar
        private bool? _Click;
        public bool? Click
        {
            get
            {
                return _Click;
            }
            set
            {
                if (_Click != value)
                {
                    _Click = value;
                    RaisePropertyChanged("Click");
                }
            }
        }
        private string _doc_desc_user;

        public string doc_desc_user
        {
            get { return _doc_desc_user; }
            set
            {
                if (_doc_desc_user != value)
                {
                    _doc_desc_user = value; RaisePropertyChanged("doc_desc_user");
                }
            }

        }

        public override string ToString()
        {
            return string.Format("{0}", t_status);
        }
    }
    public class ADM_M0018 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat");
            }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type");
            }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set
            {
                _ref_doc_cat = value;
                RaisePropertyChanged("ref_doc_cat");
            }
        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set
            {
                _ref_doc_type = value;
                RaisePropertyChanged("ref_doc_type");
            }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }
        private bool? _selected { get; set; }
        public bool? selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value; RaisePropertyChanged("selected");
                }
            }
        }
        private string _active;
        public string active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }

    }
    public class MC_ADM_M0018 : MC_ADM_BE
    {
        public ObservableCollection<ADM_M0018> MASTER_LIST { get; set; }
    }
    public class ADM_M0051 : ObjectBase
    {
        private bool? _selected;
        public bool? selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value; RaisePropertyChanged("selected");
                }
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _tc_code;
        public string tc_code
        {
            get { return _tc_code; }
            set { _tc_code = value; RaisePropertyChanged("tc_code"); }
        }

        private int? _seq_no;
        public int? seq_no
        {
            get { return _seq_no; }
            set { _seq_no = value; RaisePropertyChanged("seq_no"); }
        }
        private string _party_code;
        public string party_code
        {
            get { return _party_code; }
            set { _party_code = value; RaisePropertyChanged("party_code"); }
        }
        private string _org_code;
        public string org_code
        {
            get { return _org_code; }
            set { _org_code = value; RaisePropertyChanged("org_code"); }
        }

        private string _org_group;
        public string org_group
        {
            get { return _org_group; }
            set { _org_group = value; RaisePropertyChanged("org_group"); }
        }
        private string _tc_cat;
        public string tc_cat
        {
            get { return _tc_cat; }
            set { _tc_cat = value; RaisePropertyChanged("tc_cat"); }
        }
        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set { _short_text = value; RaisePropertyChanged("short_text"); }
        }

        private string _long_text;
        public string long_text
        {
            get { return _long_text; }
            set { _long_text = value; RaisePropertyChanged("long_text"); }
        }
        private string _ind_man;
        public string ind_man
        {
            get { return _ind_man; }
            set { _ind_man = value; RaisePropertyChanged("ind_man"); }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }
        private string _con_group;
        public string con_group
        {
            get { return _con_group; }
            set { _con_group = value; RaisePropertyChanged("con_group"); }
        }

        private string _group_code;
        public string group_code
        {
            get { return _group_code; }
            set { _group_code = value; RaisePropertyChanged("group_code"); }
        }

        private string _con_type;
        public string con_type
        {
            get { return _con_type; }
            set { _con_type = value; RaisePropertyChanged("con_type"); }
        }

        private string _active;
        public string active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        private string _tc_parent;
        public string tc_parent
        {
            get { return _tc_parent; }
            set { _tc_parent = value; RaisePropertyChanged("tc_parent"); }
        }
        private string _module_code;
        public string module_code
        {
            get { return _module_code; }
            set { _module_code = value; RaisePropertyChanged("module_code"); }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }
        }

        private string _con_type_name;
        public string con_type_name
        {
            get { return _con_type_name; }
            set { _con_type_name = value; RaisePropertyChanged("con_type_name"); }
        }
        private string _party_name;
        public string party_name
        {
            get { return _party_name; }
            set { _party_name = value; RaisePropertyChanged("party_name"); }
        }

    }
    public class ADM_M0071 : ObjectBase
    {
        public string para_code { get; set; }
        public string para_name { get; set; }
        public string para_value { get; set; }
        public string item_cat { get; set; }
        public string item_cat_name { get; set; }
        public string item_subcat { get; set; }
        public string item_subcat_name { get; set; }
        public string item_code { get; set; }
        public string sku { get; set; }
        public string ind_sku { get; set; }
        public string unit_code { get; set; }
        public int? _selectedindex;
        public int? selectedindex
        {
            get { return _selectedindex; }
            set { _selectedindex = value; }
        }
        public string _selectedValue;
        public string selectedValue
        {
            get { return _selectedValue; }
            set { _selectedValue = value; }
        }
        public override string ToString()
        {
            return string.Format("{0}", para_value);
        }
        // NOTE: Depricated 

        public string SubCatCode { get; set; }
        public string parametervalue { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string ItemCode { get; set; }
        public int? count { get; set; }
        public int? code { get; set; }
        public string stockunit { get; set; }
        public int? dgselectedindex { get; set; }

    }
    public class ADM_M0040 : ObjectBase //Priority Master
    {
        public string pr_code { get; set; }
        public string text_name { get; set; }
        public int? waitage { get; set; }
        public int? seq_no { get; set; }

    }

    public class ADM_M0110 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };


        private string _char_group;
        public string char_group
        {
            get { return _char_group; }
            set
            {
                _char_group = value;
                RaisePropertyChanged("char_group");
            }
        }


        private string _group_name;
        public string group_name
        {
            get { return _group_name; }
            set
            {
                _group_name = value;
                RaisePropertyChanged("group_name");
            }
        }
        private string _parent_group;
        public string parent_group
        {
            get { return _parent_group; }
            set
            {
                _parent_group = value;
                RaisePropertyChanged("parent_group");
            }
        }

        private bool? _selected { get; set; }
        public bool? selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value; RaisePropertyChanged("selected");
                }
            }
        }
        private string _active;
        public string active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
    }

    public class MC_ADM_M0110 : MC_ADM_BE
    {
        public ObservableCollection<ADM_M0110> MASTER_LIST { get; set; }
    }

    public class ADM_S0001 //subscribe module list purchased by client
    {
        public string module_code { get; set; }
        public string module_name { get; set; }
        public string parent_module { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }
    }

    public class ADM_M0051_MC : MC_ADM_BE
    {
        public List<ADM_M0051> MasterEntityList { get; set; }
    }

}
