using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class STD_REQ_PARA_BE : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _request;
        public string request
        {
            get { return _request; }
            set
            {
                if (_request != value)
                {
                    _request = value; RaisePropertyChanged("request");
                }
            }
        }

        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set
            {
                if (_barcode != value)
                {
                    _barcode = value;
                    RaisePropertyChanged("barcode");
                }
            }
        }

        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value;
                    RaisePropertyChanged("active");
                }
            }
        }
        private string _active_code;
        public string active_code
        {
            get { return _active_code; }
            set
            {
                if (_active_code != value)
                {
                    _active_code = value;
                    RaisePropertyChanged("active_code");
                }
            }
        }
        private DateTime? _from_date;
        public DateTime? from_date
        {
            get { return _from_date; }
            set
            {
                if (_from_date != value)
                {
                    _from_date = value;
                    RaisePropertyChanged("from_date");
                }
            }
        }

        private DateTime? _to_date;
        public DateTime? to_date
        {
            get { return _to_date; }
            set
            {
                if (_to_date != value)
                {
                    _to_date = value;
                    RaisePropertyChanged("to_date");
                }
            }
        }

        private DateTime? _from_date2;
        public DateTime? from_date2
        {
            get { return _from_date2; }
            set
            {
                if (_from_date2 != value)
                {
                    _from_date2 = value;
                    RaisePropertyChanged("from_date2");
                }
            }
        }

        private DateTime? _to_date2;
        public DateTime? to_date2
        {
            get { return _to_date2; }
            set
            {
                if (_to_date2 != value)
                {
                    _to_date2 = value;
                    RaisePropertyChanged("to_date2");
                }
            }
        }

        private string _report_name;
        public string report_name
        {
            get { return _report_name; }
            set
            {
                _report_name = value;
                RaisePropertyChanged("report_name");
            }
        }
        private string _report_code;
        public string report_code
        {
            get { return _report_code; }
            set
            {
                if (_report_code != value)
                {
                    _report_code = value;
                    RaisePropertyChanged("report_code");
                }
            }
        }
        private string _rpt_code;
        public string rpt_code
        {
            get { return _rpt_code; }
            set
            {
                if (_rpt_code != value)
                {
                    _rpt_code = value;
                    RaisePropertyChanged("rpt_code");
                }
            }
        }
        private string _obj_code;
        public string obj_code
        {
            get { return _obj_code; }
            set
            {
                if (_obj_code != value)
                {
                    _obj_code = value;
                    RaisePropertyChanged("obj_code");
                }
            }
        }
        private string _obj_name;
        public string obj_name
        {
            get { return _obj_name; }
            set
            {
                if (_obj_name != value)
                {
                    _obj_name = value;
                    RaisePropertyChanged("obj_name");
                }
            }
        }
        private string _view_code;
        public string view_code
        {
            get { return _view_code; }
            set
            {
                if (_view_code != value)
                {
                    _view_code = value;
                    RaisePropertyChanged("view_code");
                }
            }
        }
        private string _item_code;
        public string item_code
        {
            get { return _item_code; }
            set
            {
                if (_item_code != value)
                {
                    _item_code = value;
                    RaisePropertyChanged("item_code");
                }
            }
        }
        private string _sql_code;
        public string sql_code
        {
            get { return _sql_code; }
            set
            {
                if (_sql_code != value)
                {
                    _sql_code = value;
                    RaisePropertyChanged("sql_code", ModelEntityUpdated);
                }
            }
        }
        private string _sku;
        public string sku
        {
            get { return _sku; }
            set
            {
                if (_sku != value)
                {
                    _sku = value;
                    RaisePropertyChanged("sku");
                }
            }
        }
        private string _party_code;
        public string party_code
        {
            get { return _party_code; }
            set
            {
                if (_party_code != value)
                {
                    _party_code = value;
                    RaisePropertyChanged("party_code");
                }
            }
        }
        private string _add_code;
        public string add_code
        {
            get { return _add_code; }
            set
            {
                if (_add_code != value)
                {
                    _add_code = value;
                    RaisePropertyChanged("add_code");
                }
            }
        }
        private string _add_code_del;
        public string add_code_del
        {
            get { return _add_code_del; }
            set
            {
                if (_add_code_del != value)
                {
                    _add_code_del = value;
                    RaisePropertyChanged("add_code_del");
                }
            }
        }
        private string _cp_code;
        public string cp_code
        {
            get { return _cp_code; }
            set
            {
                if (_cp_code != value)
                {
                    _cp_code = value;
                    RaisePropertyChanged("cp_code");
                }
            }
        }
        private string _cn_code;
        public string cn_code
        {
            get { return _cn_code; }
            set
            {
                if (_cn_code != value)
                {
                    _cn_code = value;
                    RaisePropertyChanged("cn_code");
                }
            }
        }
        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set
            {
                if (_location_id != value)
                {
                    _location_id = value;
                    RaisePropertyChanged("location_id", ModelEntityUpdated);
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
                    _comp_code = value;
                    RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
            }
        }
        private string _comp_name;
        public string comp_name
        {
            get { return _comp_name; }
            set
            {
                _comp_name = value;
                RaisePropertyChanged("comp_name");
            }
        }
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
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
                    _doc_cat = value;
                    RaisePropertyChanged("doc_cat");
                }
            }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value;
                    RaisePropertyChanged("doc_type");
                }
            }
        }
        private string _doc_type_user;
        public string doc_type_user
        {
            get { return _doc_type_user; }
            set
            {
                _doc_type_user = value;
                RaisePropertyChanged("doc_type_user");
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
                    _t_status = value;
                    RaisePropertyChanged("t_status");
                }
            }
        }
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set
            {
                _t_display = value;
                RaisePropertyChanged("t_display");
            }
        }
        
        private string _emp_id;
        public string emp_id
        {
            get { return _emp_id; }
            set
            {
                if (_emp_id != value)
                {
                    _emp_id = value;
                    RaisePropertyChanged("emp_id");
                }
            }
        }
        private string _emp_id2;
        public string emp_id2
        {
            get { return _emp_id2; }
            set
            {
                if (_emp_id2 != value)
                {
                    _emp_id2 = value;
                    RaisePropertyChanged("emp_id2");
                }
            }
        }
        private string _emp_name;
        public string emp_name
        {
            get { return _emp_name; }
            set
            {
                if (_emp_name != value)
                {
                    _emp_name = value;
                    RaisePropertyChanged("emp_name");
                }
            }
        }
        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                if (_fin_year != value)
                {
                    _fin_year = value;
                    RaisePropertyChanged("fin_year", ModelEntityUpdated);
                }
            }
        }
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                if (_posting_period != value)
                {
                    _posting_period = value;
                    RaisePropertyChanged("posting_period", ModelEntityUpdated);
                }
            }
        }
        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set
            {
                if (_so_code != value)
                {
                    _so_code = value;
                    RaisePropertyChanged("so_code");
                }
            }
        }
        private string _sg_code;
        public string sg_code
        {
            get { return _sg_code; }
            set
            {
                if (_sg_code != value)
                {
                    _sg_code = value;
                    RaisePropertyChanged("sg_code");
                }
            }
        }
        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set
            {
                if (_po_code != value)
                {
                    _po_code = value;
                    RaisePropertyChanged("po_code");
                }
            }
        }
        private string _pg_code;
        public string pg_code
        {
            get { return _pg_code; }
            set
            {
                if (_pg_code != value)
                {
                    _pg_code = value;
                    RaisePropertyChanged("pg_code");
                }
            }
        }
        private string _curr_unit;
        public string curr_unit
        {
            get { return _curr_unit; }
            set
            {
                if (_curr_unit != value)
                {
                    _curr_unit = value;
                    RaisePropertyChanged("curr_unit");
                }
            }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                if (_unit_code != value)
                {
                    _unit_code = value;
                    RaisePropertyChanged("unit_code");
                }
            }
        }
        private string _ind_code;
        public string ind_code // This can use commonly for all indicators for name, if multiple required then use different.
        {
            get { return _ind_code; }
            set
            {
                if (_ind_code != value)
                {
                    _ind_code = value;
                    RaisePropertyChanged("ind_code");
                }
            }
        }
        private string _ind_name;
        public string ind_name // This can use commonly for all indicators for name, if multiple required then use different.
        {
            get { return _ind_name; }
            set
            {
                if (_ind_name != value)
                {
                    _ind_name = value;
                    RaisePropertyChanged("ind_name");
                }
            }
        }
        private string _wc_code;
        public string wc_code
        {
            get { return _wc_code; }
            set
            {
                if (_wc_code != value)
                {
                    _wc_code = value;
                    RaisePropertyChanged("wc_code");
                }
            }
        }

        private string _incoterm;
        public string incoterm
        {
            get { return _incoterm; }
            set
            {
                if (_incoterm != value)
                {
                    _incoterm = value;
                    RaisePropertyChanged("incoterm");
                }
            }
        }
        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                if (_curr_code != value)
                {
                    _curr_code = value;
                    RaisePropertyChanged("curr_code");
                }
            }
        }

        private string _cat_code;
        public string cat_code
        {
            get { return _cat_code; }
            set
            {
                if (_cat_code != value)
                {
                    _cat_code = value;
                    RaisePropertyChanged("cat_code", ModelEntityUpdated);
                }
            }
        }
        private string _cat_name;
        public string cat_name
        {
            get { return _cat_name; }
            set
            {
                _cat_name = value;
                RaisePropertyChanged("cat_name");
            }
        }
        private string _scat_code;
        public string scat_code
        {
            get { return _scat_code; }
            set
            {
                if (_scat_code != value)
                {
                    _scat_code = value;
                    RaisePropertyChanged("scat_code", ModelEntityUpdated);
                }
            }
        }
        private string _scat_name;
        public string scat_name
        {
            get { return _scat_name; }
            set
            {
                _scat_name = value;
                RaisePropertyChanged("scat_name");
            }
        }
        private string _report_type;
        public string report_type
        {
            get { return _report_type; }
            set
            {
                if (_report_type != value)
                {
                    _report_type = value;
                    RaisePropertyChanged("report_type");
                }
            }
        }
        private string _order_by;
        public string order_by
        {
            get { return _order_by; }
            set
            {
                _order_by = value;
                RaisePropertyChanged("order_by");
            }
        }
        private string _para_code;
        public string para_code
        {
            get { return _para_code; }
            set
            {
                if (_para_code != value)
                {
                    _para_code = value;
                    RaisePropertyChanged("para_code");
                }
            }
        }
        private string _para_name;
        public string para_name
        {
            get { return _para_name; }
            set
            {
                if (_para_name != value)
                {
                    _para_name = value;
                    RaisePropertyChanged("para_name", ModelEntityUpdated);
                }
            }
        }
        private string _value_code;
        public string value_code
        {
            get { return _value_code; }
            set
            {
                if (_value_code != value)
                {
                    _value_code = value;
                    RaisePropertyChanged("value_code", ModelEntityUpdated);
                }
            }
        }
        private string _parametervalue;
        public string parametervalue
        {
            get { return _parametervalue; }
            set
            {
                if (_parametervalue != value)
                {
                    _parametervalue = value;
                    RaisePropertyChanged("parametervalue", ModelEntityUpdated);
                }
            }
        }
        private string _ref_doc;
        public string ref_doc
        {
            get { return _ref_doc; }
            set
            {
                if (_ref_doc != value)
                {
                    _ref_doc = value;
                    RaisePropertyChanged("ref_doc", ModelEntityUpdated);
                }
            }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set
            {
                if (_ref_doc_cat != value)
                {
                    _ref_doc_cat = value;
                    RaisePropertyChanged("ref_doc_cat", ModelEntityUpdated);
                }
            }
        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set
            {
                if (_ref_doc_type != value)
                {
                    _ref_doc_type = value;
                    RaisePropertyChanged("ref_doc_type", ModelEntityUpdated);
                }
            }
        }

        private string _org_code;
        public string org_code
        {
            get { return _org_code; }
            set
            {
                if (_org_code != value)
                {
                    _org_code = value;
                    RaisePropertyChanged("org_code");
                }
            }
        }

        private string _group_code;
        public string group_code
        {
            get { return _group_code; }
            set
            {
                if (_group_code != value)
                {
                    _group_code = value;
                    RaisePropertyChanged("group_code");
                }
            }
        }
        private string _para1;
        public string para1
        {
            get { return _para1; }
            set
            {
                _para1 = value;
                RaisePropertyChanged("para1");
            }
        }

        private string _para2;
        public string para2
        {
            get { return _para2; }
            set
            {
                _para2 = value;
                RaisePropertyChanged("para2");
            }
        }

        private string _para3;
        public string para3
        {
            get { return _para3; }
            set
            {
                _para3 = value;
                RaisePropertyChanged("para3");
            }
        }
        private string _para4;
        public string para4
        {
            get { return _para4; }
            set
            {
                _para4 = value;
                RaisePropertyChanged("para4");
            }
        }
        private string _para5;
        public string para5
        {
            get { return _para5; }
            set
            {
                _para5 = value;
                RaisePropertyChanged("para5");
            }
        }
        private string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set
            {
                _store_code = value;
                RaisePropertyChanged("store_code", ModelEntityUpdated);
            }
        }
        private string _store_name;
        public string store_name
        {
            get { return _store_name; }
            set
            {
                _store_name = value;
                RaisePropertyChanged("store_name");
            }
        }

        private int? _moving_days;
        public int? moving_days // Movement of Materal within this Days limit will indicate that material is Fast moving and later will indicate slow Moving.
        {
            get { return _moving_days; }
            set
            {
                _moving_days = value;
                RaisePropertyChanged("moving_days");
            }
        }

        private string _item_cat;
        public string item_cat
        {
            get { return _item_cat; }
            set
            {
                if (_item_cat != value)
                {
                    _item_cat = value;
                    RaisePropertyChanged("item_cat", ModelEntityUpdated);
                }
            }
        }

        private string _item_cat_name;
        public string item_cat_name
        {
            get { return _item_cat_name; }
            set
            {
                _item_cat_name = value;
                RaisePropertyChanged("item_cat_name");
            }
        }

        private string _item_subcat;
        public string item_subcat
        {
            get { return _item_subcat; }
            set
            {
                if (_item_subcat != value)
                {
                    _item_subcat = value;
                    RaisePropertyChanged("item_subcat", ModelEntityUpdated);
                }
            }
        }

        private string _item_subcat_name;
        public string item_subcat_name
        {
            get { return _item_subcat_name; }
            set
            {
                _item_subcat_name = value;
                RaisePropertyChanged("item_subcat_name");
            }
        }

        private string _item_type;
        public string item_type
        {
            get { return _item_type; }
            set
            {
                if (_item_type != value)
                {
                    _item_type = value;
                    RaisePropertyChanged("item_type", ModelEntityUpdated);
                }
            }
        }

        private string _item_type_name;
        public string item_type_name
        {
            get { return _item_type_name; }
            set
            {
                _item_type_name = value;
                RaisePropertyChanged("item_type_name");
            }
        }

        private string _item_subtype;
        public string item_subtype
        {
            get { return _item_subtype; }
            set
            {
                if (_item_subtype != value)
                {
                    _item_subtype = value;
                    RaisePropertyChanged("item_subtype", ModelEntityUpdated);
                }
            }
        }

        private string _item_subtype_name;
        public string item_subtype_name
        {
            get { return _item_subtype_name; }
            set
            {
                _item_subtype_name = value;
                RaisePropertyChanged("item_subtype_name");
            }
        }
        private string _rpt_title;
        public string rpt_title
        {
            get { return _rpt_title; }
            set
            {
                if (_rpt_title != value)
                {
                    _rpt_title = value;
                    RaisePropertyChanged("rpt_title");
                }
            }
        }
        private string _rpt_name;
        public string rpt_name
        {
            get { return _rpt_name; }
            set
            {
                if (_rpt_name != value)
                {
                    _rpt_name = value;
                    RaisePropertyChanged("rpt_name");
                }
            }
        }
        private string _country_key;
        public string country_key
        {
            get { return _country_key; }
            set
            {
                if (_country_key != value)
                {
                    _country_key = value;
                    RaisePropertyChanged("country_key");
                }
            }
        }
        private string _country_name;
        public string country_name
        {
            get { return _country_name; }
            set
            {
                if (_country_name != value)
                {
                    _country_name = value;
                    RaisePropertyChanged("country_name");
                }
            }
        }
        private string _conf_type;
        public string conf_type
        {
            get { return _conf_type; }
            set
            {
                if (_conf_type != value)
                {
                    _conf_type = value;
                    RaisePropertyChanged("conf_type");
                }
            }
        }
        private string _record_type;
        public string record_type
        {
            get { return _record_type; }
            set
            {
                if (_record_type != value)
                {
                    _record_type = value;
                    RaisePropertyChanged("record_type");
                }
            }
        }
        private string _operation_no;
        public string operation_no
        {
            get { return _operation_no; }
            set
            {
                if (_operation_no != value)
                {
                    _operation_no = value;
                    RaisePropertyChanged("operation_no");
                }
            }
        }
        private string _sub_op_no;
        public string sub_op_no
        {
            get { return _sub_op_no; }
            set
            {
                if (_sub_op_no != value)
                {
                    _sub_op_no = value;
                    RaisePropertyChanged("sub_op_no");
                }
            }
        }
        private string _shift_code;
        public string shift_code
        {
            get { return _shift_code; }
            set
            {
                if (_shift_code != value)
                {
                    _shift_code = value;
                    RaisePropertyChanged("shift_code");
                }
            }
        }
        private string _var_reson;
        public string var_reson
        {
            get { return _var_reson; }
            set
            {
                if (_var_reson != value)
                {
                    _var_reson = value;
                    RaisePropertyChanged("var_reson");
                }
            }
        }
        private string _field_code;
        public string field_code // Database Column Field Code. Also use for Sort order column. This can use commonly for all indicators for name, if multiple required then use different.
        {
            get { return _field_code; }
            set
            {
                if (_field_code != value)
                {
                    _field_code = value;
                    RaisePropertyChanged("field_code");
                }
            }
        }

        private string _field_direction;
        public string field_direction // Database Column Field Code. Also use for Sort column Direction as Assending or Descending.
        {
            get { return _field_direction; }
            set
            {
                if (_field_direction != value)
                {
                    _field_direction = value;
                    RaisePropertyChanged("field_direction");
                }
            }
        }

        private string _equip_no;
        public string equip_no // Database Column Field Code. Also use for Sort column Direction as Assending or Descending.
        {
            get { return _equip_no; }
            set
            {
                if (_equip_no != value)
                {
                    _equip_no = value;
                    RaisePropertyChanged("equip_no");
                }
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", key_code);
        }
    }

}
