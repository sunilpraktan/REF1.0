using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.PMS
{
    public class PMS_T001 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _comp_code { get; set; }
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
        private string _project_id { get; set; }
        public string project_id
        {
            get { return _project_id; }
            set
            {
                if (_project_id != value)
                {
                    _project_id = value; RaisePropertyChanged("project_id");
                }
            }
        }
        private string _location_id { get; set; }
        public string location_id
        {
            get { return _location_id; }
            set
            {
                if (_location_id != value)
                {
                    _location_id = value; RaisePropertyChanged("location_id");
                }
            }
        }
        private int? _project_no { get; set; }
        public int? project_no
        {
            get { return _project_no; }
            set
            {
                if (_project_no != value)
                {
                    _project_no = value; RaisePropertyChanged("project_no");
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
        private string _project_name { get; set; }
        public string project_name
        {
            get { return _project_name; }
            set
            {
                if (_project_name != value)
                {
                    _project_name = value; RaisePropertyChanged("project_name");
                }
            }
        }
        private string _short_text { get; set; }
        public string short_text
        {
            get { return _short_text; }
            set
            {
                if (_short_text != value)
                {
                    _short_text = value; RaisePropertyChanged("short_text");
                }
            }
        }
        private string _obj_no { get; set; }
        public string obj_no
        {
            get { return _obj_no; }
            set
            {
                if (_obj_no != value)
                {
                    _obj_no = value; RaisePropertyChanged("obj_no");
                }
            }
        }
        private string _doc_cat { get; set; }
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
        private string _doc_type { get; set; }
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
        private string _pro_type { get; set; }
        public string pro_type
        {
            get { return _pro_type; }
            set
            {
                if (_pro_type != value)
                {
                    _pro_type = value; RaisePropertyChanged("pro_type");
                }
            }
        }
        private DateTime? _doc_date { get; set; }
        public DateTime? doc_date
        {
            get { return _doc_date; }
            set
            {
                if (_doc_date != value)
                {
                    _doc_date = value; RaisePropertyChanged("doc_date");
                }
            }
        }
        private string _ref_doc_no { get; set; }
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set
            {
                if (_ref_doc_no != value)
                {
                    _ref_doc_no = value; RaisePropertyChanged("ref_doc_no");
                }
            }
        }
        private string _ref_doc_cat { get; set; }
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set
            {
                if (_ref_doc_cat != value)
                {
                    _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat");
                }
            }
        }
        private string _order_no { get; set; }
        public string order_no
        {
            get { return _order_no; }
            set
            {
                if (_order_no != value)
                {
                    _order_no = value; RaisePropertyChanged("order_no");
                }
            }
        }
        private string _pcode_1 { get; set; }
        public string pcode_1
        {
            get { return _pcode_1; }
            set
            {
                if (_pcode_1 != value)
                {
                    _pcode_1 = value; RaisePropertyChanged("pcode_1");
                }
            }
        }
        private string _pcode_2 { get; set; }
        public string pcode_2
        {
            get { return _pcode_2; }
            set
            {
                if (_pcode_2 != value)
                {
                    _pcode_2 = value; RaisePropertyChanged("pcode_2");
                }
            }
        }
        private string _active { get; set; }
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
        private string _t_status { get; set; }
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
        private DateTime? _date_start { get; set; }
        public DateTime? date_start
        {
            get { return _date_start; }
            set
            {
                if (_date_start != value)
                {
                    _date_start = value; RaisePropertyChanged("date_start", ModelEntityUpdated);
                }
            }
        }
        private DateTime? _date_end { get; set; }
        public DateTime? date_end
        {
            get { return _date_end; }
            set
            {
                if (_date_end != value)
                {
                    _date_end = value; RaisePropertyChanged("date_end", ModelEntityUpdated);
                }
            }
        }
        private DateTime? _actual_start { get; set; }
        public DateTime? actual_start
        {
            get { return _actual_start; }
            set
            {
                if (_actual_start != value)
                {
                    _actual_start = value; RaisePropertyChanged("actual_start");
                }
            }
        }
        private DateTime? _actual_end { get; set; }
        public DateTime? actual_end
        {
            get { return _actual_end; }
            set
            {
                if (_actual_end != value)
                {
                    _actual_end = value; RaisePropertyChanged("actual_end");
                }
            }
        }
        private string _party_code { get; set; }
        public string party_code
        {
            get { return _party_code; }
            set
            {
                if (_party_code != value)
                {
                    _party_code = value; RaisePropertyChanged("party_code");
                }
            }
        }
        private string _lang_key { get; set; }
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
        private string _cc_code { get; set; }
        public string cc_code
        {
            get { return _cc_code; }
            set
            {
                if (_cc_code != value)
                {
                    _cc_code = value; RaisePropertyChanged("cc_code");
                }
            }
        }
        private string _pc_code { get; set; }
        public string pc_code
        {
            get { return _pc_code; }
            set
            {
                if (_pc_code != value)
                {
                    _pc_code = value; RaisePropertyChanged("pc_code");
                }
            }
        }
        private string _cost_object { get; set; }
        public string cost_object
        {
            get { return _cost_object; }
            set
            {
                if (_cost_object != value)
                {
                    _cost_object = value; RaisePropertyChanged("cost_object");
                }
            }
        }
        private string _curr_code { get; set; }
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                if (_curr_code != value)
                {
                    _curr_code = value; RaisePropertyChanged("curr_code");
                }
            }
        }
        private string _emp_id { get; set; }
        public string emp_id
        {
            get { return _emp_id; }
            set
            {
                if (_emp_id != value)
                {
                    _emp_id = value; RaisePropertyChanged("emp_id");
                }
            }
        }
        private string _emp_name { get; set; }
        public string emp_name
        {
            get { return _emp_name; }
            set
            {
                if (_emp_name != value)
                {
                    _emp_name = value; RaisePropertyChanged("emp_name");
                }
            }
        }
        private string _app_id { get; set; }
        public string app_id
        {
            get { return _app_id; }
            set
            {
                if (_app_id != value)
                {
                    _app_id = value; RaisePropertyChanged("app_id");
                }
            }
        }
        private string _app_desc { get; set; }
        public string app_desc
        {
            get { return _app_desc; }
            set
            {
                if (_app_desc != value)
                {
                    _app_desc = value; RaisePropertyChanged("app_desc");
                }
            }
        }
        private string _uom_time { get; set; }
        public string uom_time
        {
            get { return _uom_time; }
            set
            {
                if (_uom_time != value)
                {
                    _uom_time = value; RaisePropertyChanged("uom_time");
                }
            }
        }
        private string _pri_code { get; set; }
        public string pri_code
        {
            get { return _pri_code; }
            set
            {
                if (_pri_code != value)
                {
                    _pri_code = value; RaisePropertyChanged("pri_code");
                }
            }
        }
        private string _project_profile { get; set; }
        public string project_profile
        {
            get { return _project_profile; }
            set
            {
                if (_project_profile != value)
                {
                    _project_profile = value; RaisePropertyChanged("project_profile");
                }
            }
        }
        private string _task_profile { get; set; }
        public string task_profile
        {
            get { return _task_profile; }
            set
            {
                if (_task_profile != value)
                {
                    _task_profile = value; RaisePropertyChanged("task_profile");
                }
            }
        }
        private string _budget_profile { get; set; }
        public string budget_profile
        {
            get { return _budget_profile; }
            set
            {
                if (_budget_profile != value)
                {
                    _budget_profile = value; RaisePropertyChanged("budget_profile");
                }
            }
        }
        private string _para1 { get; set; }
        public string para1
        {
            get { return _para1; }
            set
            {
                if (_para1 != value)
                {
                    _para1 = value; RaisePropertyChanged("para1");
                }
            }
        }
        private string _para2 { get; set; }
        public string para2
        {
            get { return _para2; }
            set
            {
                if (_para2 != value)
                {
                    _para2 = value; RaisePropertyChanged("para2");
                }
            }
        }
        private string _org_code { get; set; }
        public string org_code
        {
            get { return _org_code; }
            set
            {
                if (_org_code != value)
                {
                    _org_code = value; RaisePropertyChanged("org_code");
                }
            }
        }
        private string _group_code { get; set; }
        public string group_code
        {
            get { return _group_code; }
            set
            {
                if (_group_code != value)
                {
                    _group_code = value; RaisePropertyChanged("group_code");
                }
            }
        }
        private string _ind_task { get; set; }
        public string ind_task
        {
            get { return _ind_task; }
            set
            {
                if (_ind_task != value)
                {
                    _ind_task = value; RaisePropertyChanged("ind_task");
                }
            }
        }
        private string _note { get; set; }
        public string note
        {
            get { return _note; }
            set
            {
                if (_note != value)
                {
                    _note = value; RaisePropertyChanged("note");
                }
            }
        }
        private string _std_code { get; set; }
        public string std_code
        {
            get { return _std_code; }
            set
            {
                if (_std_code != value)
                {
                    _std_code = value; RaisePropertyChanged("std_code");
                }
            }
        }

        private string _sub_std_code { get; set; }
        public string sub_std_code
        {
            get { return _sub_std_code; }
            set
            {
                if (_sub_std_code != value)
                {
                    _sub_std_code = value; RaisePropertyChanged("sub_std_code");
                }
            }
        }

        private decimal? _duration { get; set; }
        public decimal? duration
        {
            get { return _duration; }
            set
            {
                if (_duration != value)
                {
                    _duration = value; RaisePropertyChanged("duration");
                }
            }
        }

        private string _duration_unit { get; set; }
        public string duration_unit
        {
            get { return _duration_unit; }
            set
            {
                if (_duration_unit != value)
                {
                    _duration_unit = value; RaisePropertyChanged("duration_unit");
                }
            }
        }

        //GEN_T002 Fields
        private string _long_text { get; set; }
        public string long_text
        {
            get { return _long_text; }
            set
            {
                if (_long_text != value)
                {
                    _long_text = value; RaisePropertyChanged("long_text");
                }
            }
        }

        // Scalar Fields
        private string _std_name { get; set; }
        public string std_name
        {
            get { return _std_name; }
            set
            {
                if (_std_name != value)
                {
                    _std_name = value; RaisePropertyChanged("std_name");
                }
            }
        }

        private string _sub_std_name { get; set; }
        public string sub_std_name
        {
            get { return _sub_std_name; }
            set
            {
                if (_sub_std_name != value)
                {
                    _sub_std_name = value; RaisePropertyChanged("sub_std_name");
                }
            }
        }
        private string _party_name { get; set; }
        public string party_name
        {
            get { return _party_name; }
            set
            {
                if (_party_name != value)
                {
                    _party_name = value; RaisePropertyChanged("party_name");
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
        private string _type_name;
        public string type_name
        {
            get { return _type_name; }
            set
            {
                if (_type_name != value)
                {
                    _type_name = value; RaisePropertyChanged("type_name");
                }
            }
        }
        private bool? _ind_copy;
        public bool? ind_copy
        {
            get { return _ind_copy; }
            set
            {
                if (_ind_copy != value)
                {
                    _ind_copy = value; RaisePropertyChanged("ind_copy");
                }
            }
        }
        //private DateTime? _sch_date_max { get; set; }
        //public DateTime? sch_date_max
        //{
        //    get { return _sch_date_max; }
        //    set
        //    {
        //        if (_sch_date_max != value)
        //        {
        //            _sch_date_max = value; RaisePropertyChanged("sch_date_max");
        //        }
        //    }
        //}
        //private DateTime? _sch_date_min { get; set; }
        //public DateTime? sch_date_min
        //{
        //    get { return _sch_date_min; }
        //    set
        //    {
        //        if (_sch_date_min != value)
        //        {
        //            _sch_date_min = value; RaisePropertyChanged("sch_date_min");
        //        }
        //    }
        //}

    }

    public class PMS_T002 : ObjectBase
    {
        private string _comp_code { get; set; }
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
        private string _element_id { get; set; }
        public string element_id
        {
            get { return _element_id; }
            set
            {
                if (_element_id != value)
                {
                    _element_id = value; RaisePropertyChanged("element_id");
                }
            }
        }
        private string _location_id { get; set; }
        public string location_id
        {
            get { return _location_id; }
            set
            {
                if (_location_id != value)
                {
                    _location_id = value; RaisePropertyChanged("location_id");
                }
            }
        }
        private int? _element_no { get; set; }
        public int? element_no
        {
            get { return _element_no; }
            set
            {
                if (_element_no != value)
                {
                    _element_no = value; RaisePropertyChanged("element_no");
                }
            }
        }
        private string _element_name { get; set; }
        public string element_name
        {
            get { return _element_name; }
            set
            {
                if (_element_name != value)
                {
                    _element_name = value; RaisePropertyChanged("element_name");
                }
            }
        }
        private string _short_text { get; set; }
        public string short_text
        {
            get { return _short_text; }
            set
            {
                if (_short_text != value)
                {
                    _short_text = value; RaisePropertyChanged("short_text");
                }
            }
        }
        private int? _project_no { get; set; }
        public int? project_no
        {
            get { return _project_no; }
            set
            {
                if (_project_no != value)
                {
                    _project_no = value; RaisePropertyChanged("project_no");
                }
            }
        }
        private string _doc_cat { get; set; }
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
        private string _doc_type { get; set; }
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
        private string _pro_type { get; set; }
        public string pro_type
        {
            get { return _pro_type; }
            set
            {
                if (_pro_type != value)
                {
                    _pro_type = value; RaisePropertyChanged("pro_type");
                }
            }
        }
        private string _obj_no { get; set; }
        public string obj_no
        {
            get { return _obj_no; }
            set
            {
                if (_obj_no != value)
                {
                    _obj_no = value; RaisePropertyChanged("obj_no");
                }
            }
        }
        private DateTime? _doc_date { get; set; }
        public DateTime? doc_date
        {
            get { return _doc_date; }
            set
            {
                if (_doc_date != value)
                {
                    _doc_date = value; RaisePropertyChanged("doc_date");
                }
            }
        }
        private int? _no_of_emp { get; set; }
        public int? no_of_emp
        {
            get { return _no_of_emp; }
            set
            {
                if (_no_of_emp != value)
                {
                    _no_of_emp = value; RaisePropertyChanged("no_of_emp");
                }
            }
        }
        private string _emp_id { get; set; }
        public string emp_id
        {
            get { return _emp_id; }
            set
            {
                if (_emp_id != value)
                {
                    _emp_id = value; RaisePropertyChanged("emp_id");
                }
            }
        }
        private string _emp_name { get; set; }
        public string emp_name
        {
            get { return _emp_name; }
            set
            {
                if (_emp_name != value)
                {
                    _emp_name = value; RaisePropertyChanged("emp_name");
                }
            }
        }
        private string _app_id { get; set; }
        public string app_id
        {
            get { return _app_id; }
            set
            {
                if (_app_id != value)
                {
                    _app_id = value; RaisePropertyChanged("app_id");
                }
            }
        }
        private string _app_desc { get; set; }
        public string app_desc
        {
            get { return _app_desc; }
            set
            {
                if (_app_desc != value)
                {
                    _app_desc = value; RaisePropertyChanged("app_desc");
                }
            }
        }
        private string _cc_code { get; set; }
        public string cc_code
        {
            get { return _cc_code; }
            set
            {
                if (_cc_code != value)
                {
                    _cc_code = value; RaisePropertyChanged("cc_code");
                }
            }
        }
        private string _pc_code { get; set; }
        public string pc_code
        {
            get { return _pc_code; }
            set
            {
                if (_pc_code != value)
                {
                    _pc_code = value; RaisePropertyChanged("pc_code");
                }
            }
        }
        private string _ind_billing { get; set; }
        public string ind_billing
        {
            get { return _ind_billing; }
            set
            {
                if (_ind_billing != value)
                {
                    _ind_billing = value; RaisePropertyChanged("ind_billing");
                }
            }
        }
        private string _ind_task { get; set; }
        public string ind_task
        {
            get { return _ind_task; }
            set
            {
                if (_ind_task != value)
                {
                    _ind_task = value; RaisePropertyChanged("ind_task");
                }
            }
        }
        private string _pri_code { get; set; }
        public string pri_code
        {
            get { return _pri_code; }
            set
            {
                if (_pri_code != value)
                {
                    _pri_code = value; RaisePropertyChanged("pri_code");
                }
            }
        }
        private string _equipment_no { get; set; }
        public string equipment_no
        {
            get { return _equipment_no; }
            set
            {
                if (_equipment_no != value)
                {
                    _equipment_no = value; RaisePropertyChanged("equipment_no");
                }
            }
        }
        private string _curr_code { get; set; }
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                if (_curr_code != value)
                {
                    _curr_code = value; RaisePropertyChanged("curr_code");
                }
            }
        }
        private string _lang_key { get; set; }
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
        private decimal? _quantity { get; set; }
        public decimal? quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value; RaisePropertyChanged("quantity");
                }
            }
        }
        private string _unit_code { get; set; }
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                if (_unit_code != value)
                {
                    _unit_code = value; RaisePropertyChanged("unit_code");
                }
            }
        }
        private string _billing_plan { get; set; }
        public string billing_plan
        {
            get { return _billing_plan; }
            set
            {
                if (_billing_plan != value)
                {
                    _billing_plan = value; RaisePropertyChanged("billing_plan");
                }
            }
        }
        private string _place { get; set; }
        public string place
        {
            get { return _place; }
            set
            {
                if (_place != value)
                {
                    _place = value; RaisePropertyChanged("place");
                }
            }
        }
        private string _item_code { get; set; }
        public string item_code
        {
            get { return _item_code; }
            set
            {
                if (_item_code != value)
                {
                    _item_code = value; RaisePropertyChanged("item_code");
                }
            }
        }
        private string _active { get; set; }
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
        private string _t_status { get; set; }
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
        private string _element_profile { get; set; }
        public string element_profile
        {
            get { return _element_profile; }
            set
            {
                if (_element_profile != value)
                {
                    _element_profile = value; RaisePropertyChanged("_element_profile");
                }
            }
        }
        private string _ref_element_id { get; set; }
        public string ref_element_id
        {
            get { return _ref_element_id; }
            set
            {
                if (_ref_element_id != value)
                {
                    _ref_element_id = value; RaisePropertyChanged("ref_element_id");
                }
            }
        }
        private string _note { get; set; }
        public string note
        {
            get { return _note; }
            set
            {
                if (_note != value)
                {
                    _note = value; RaisePropertyChanged("note");
                }
            }
        }
        private string _parent_id { get; set; }
        public string parent_id
        {
            get { return _parent_id; }
            set
            {
                if (_parent_id != value)
                {
                    _parent_id = value; RaisePropertyChanged("parent_id");
                }
            }
        }
        private string _party_code { get; set; }
        public string party_code
        {
            get { return _party_code; }
            set
            {
                if (_party_code != value)
                {
                    _party_code = value; RaisePropertyChanged("party_code");
                }
            }
        }
        private string _std_code { get; set; }
        public string std_code
        {
            get { return _std_code; }
            set
            {
                if (_std_code != value)
                {
                    _std_code = value; RaisePropertyChanged("std_code");
                }
            }
        }

        private string _sub_std_code { get; set; }
        public string sub_std_code
        {
            get { return _sub_std_code; }
            set
            {
                if (_sub_std_code != value)
                {
                    _sub_std_code = value; RaisePropertyChanged("sub_std_code");
                }
            }
        }
        private int? _seq_no { get; set; }
        public int? seq_no
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
        private DateTime? _com_date { get; set; }
        public DateTime? com_date
        {
            get { return _com_date; }
            set
            {
                if (_com_date != value)
                {
                    _com_date = value; RaisePropertyChanged("com_date");
                }
            }
        }
        private string _com_rule { get; set; }
        public string com_rule
        {
            get { return _com_rule; }
            set
            {
                if (_com_rule != value)
                {
                    _com_rule = value; RaisePropertyChanged("com_rule");
                }
            }
        }

        //GEN_T002 Fields
        private string _long_text { get; set; }
        public string long_text
        {
            get { return _long_text; }
            set
            {
                if (_long_text != value)
                {
                    _long_text = value; RaisePropertyChanged("long_text");
                }
            }
        }

        //Scalar Fields
        private string _party_name { get; set; }
        public string party_name
        {
            get { return _party_name; }
            set
            {
                if (_party_name != value)
                {
                    _party_name = value; RaisePropertyChanged("party_name");
                }
            }
        }
        private string _project_name { get; set; }
        public string project_name
        {
            get { return _project_name; }
            set
            {
                if (_project_name != value)
                {
                    _project_name = value; RaisePropertyChanged("project_name");
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
        private string _project_id { get; set; }
        public string project_id
        {
            get { return _project_id; }
            set
            {
                if (_project_id != value)
                {
                    _project_id = value; RaisePropertyChanged("project_id");
                }
            }
        }

        private DateTime? _start_date { get; set; }
        public DateTime? start_date
        {
            get { return _start_date; }
            set
            {
                if (_start_date != value)
                {
                    _start_date = value; RaisePropertyChanged("start_date");
                }
            }
        }
        private DateTime? _end_date { get; set; }
        public DateTime? end_date
        {
            get { return _end_date; }
            set
            {
                if (_end_date != value)
                {
                    _end_date = value; RaisePropertyChanged("end_date");
                }
            }
        }

        private string _XDOC_A { get; set; }
        public string XDOC_A
        {
            get { return _XDOC_A; }
            set
            {
                if (_XDOC_A != value)
                {
                    _XDOC_A = value; RaisePropertyChanged("XDOC_A");
                }
            }
        }
        //private DateTime? _sch_date_max { get; set; }
        //public DateTime? sch_date_max
        //{
        //    get { return _sch_date_max; }
        //    set
        //    {
        //        if (_sch_date_max != value)
        //        {
        //            _sch_date_max = value; RaisePropertyChanged("sch_date_max");
        //        }
        //    }
        //}
        //private DateTime? _sch_date_min { get; set; }
        //public DateTime? sch_date_min
        //{
        //    get { return _sch_date_min; }
        //    set
        //    {
        //        if (_sch_date_min != value)
        //        {
        //            _sch_date_min = value; RaisePropertyChanged("sch_date_min");
        //        }
        //    }
        //}

        public override string ToString()
        {
            return string.Format("{0}", key_code);
        }
    }

    public class PMS_T003 : ObjectBase
    {
        private string _comp_code { get; set; }
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
        private int? _project_no { get; set; }
        public int? project_no
        {
            get { return _project_no; }
            set
            {
                if (_project_no != value)
                {
                    _project_no = value; RaisePropertyChanged("project_no");
                }
            }
        }
        private int? _element_no { get; set; }
        public int? element_no
        {
            get { return _element_no; }
            set
            {
                if (_element_no != value)
                {
                    _element_no = value; RaisePropertyChanged("element_no");
                }
            }
        }
        private int? _element_up { get; set; }
        public int? element_up
        {
            get { return _element_up; }
            set
            {
                if (_element_up != value)
                {
                    _element_up = value; RaisePropertyChanged("element_up");
                }
            }
        }
        private int? _element_down { get; set; }
        public int? element_down
        {
            get { return _element_down; }
            set
            {
                if (_element_down != value)
                {
                    _element_down = value; RaisePropertyChanged("element_down");
                }
            }
        }
        private int? _element_left { get; set; }
        public int? element_left
        {
            get { return _element_left; }
            set
            {
                if (_element_left != value)
                {
                    _element_left = value; RaisePropertyChanged("element_left");
                }
            }
        }
        private int? _element_right { get; set; }
        public int? element_right
        {
            get { return _element_right; }
            set
            {
                if (_element_right != value)
                {
                    _element_right = value; RaisePropertyChanged("element_right");
                }
            }
        }

    }

    public class PMS_T004 : ObjectBase
    {
        private string _comp_code { get; set; }
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
        private string _doc_no { get; set; }
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no");
                }
            }
        }
        private int? _milestone_no { get; set; }
        public int? milestone_no
        {
            get { return _milestone_no; }
            set
            {
                if (_milestone_no != value)
                {
                    _milestone_no = value; RaisePropertyChanged("milestone_no");
                }
            }
        }
        private string _short_text { get; set; }
        public string short_text
        {
            get { return _short_text; }
            set
            {
                if (_short_text != value)
                {
                    _short_text = value; RaisePropertyChanged("short_text");
                }
            }
        }
        private int? _plan_counter { get; set; }
        public int? plan_counter
        {
            get { return _plan_counter; }
            set
            {
                if (_plan_counter != value)
                {
                    _plan_counter = value; RaisePropertyChanged("plan_counter");
                }
            }
        }
        private int? _int_counter { get; set; }
        public int? int_counter
        {
            get { return _int_counter; }
            set
            {
                if (_int_counter != value)
                {
                    _int_counter = value; RaisePropertyChanged("int_counter");
                }
            }
        }
        private string _doc_cat { get; set; }
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
        private string _doc_type { get; set; }
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
        private DateTime? _doc_date { get; set; }
        public DateTime? doc_date
        {
            get { return _doc_date; }
            set
            {
                if (_doc_date != value)
                {
                    _doc_date = value; RaisePropertyChanged("doc_date");
                }
            }
        }
        private string _usage { get; set; }
        public string usage
        {
            get { return _usage; }
            set
            {
                if (_usage != value)
                {
                    _usage = value; RaisePropertyChanged("usage");
                }
            }
        }
        private string _task_list_type { get; set; }
        public string task_list_type
        {
            get { return _task_list_type; }
            set
            {
                if (_task_list_type != value)
                {
                    _task_list_type = value; RaisePropertyChanged("task_list_type");
                }
            }
        }
        private string _node_no { get; set; }
        public string node_no
        {
            get { return _node_no; }
            set
            {
                if (_node_no != value)
                {
                    _node_no = value; RaisePropertyChanged("node_no");
                }
            }
        }
        private string _tlgroup_key { get; set; }
        public string tlgroup_key
        {
            get { return _tlgroup_key; }
            set
            {
                if (_tlgroup_key != value)
                {
                    _tlgroup_key = value; RaisePropertyChanged("tlgroup_key");
                }
            }
        }
        private DateTime? _date_from { get; set; }
        public DateTime? date_from
        {
            get { return _date_from; }
            set
            {
                if (_date_from != value)
                {
                    _date_from = value; RaisePropertyChanged("date_from");
                }
            }
        }
        private string _order_cat { get; set; }
        public string order_cat
        {
            get { return _order_cat; }
            set
            {
                if (_order_cat != value)
                {
                    _order_cat = value; RaisePropertyChanged("order_cat");
                }
            }
        }
        private string _alt_order { get; set; }
        public string alt_order
        {
            get { return _alt_order; }
            set
            {
                if (_alt_order != value)
                {
                    _alt_order = value; RaisePropertyChanged("alt_order");
                }
            }
        }
        private string _routing_no { get; set; }
        public string routing_no
        {
            get { return _routing_no; }
            set
            {
                if (_routing_no != value)
                {
                    _routing_no = value; RaisePropertyChanged("routing_no");
                }
            }
        }
        private int? _int_counter_routing { get; set; }
        public int? int_counter_routing
        {
            get { return _int_counter_routing; }
            set
            {
                if (_int_counter_routing != value)
                {
                    _int_counter_routing = value; RaisePropertyChanged("int_counter_routing");
                }
            }
        }
        private string _element_id { get; set; }
        public string element_id
        {
            get { return _element_id; }
            set
            {
                if (_element_id != value)
                {
                    _element_id = value; RaisePropertyChanged("element_id");
                }
            }
        }
        private int? _element_no { get; set; }
        public int? element_no
        {
            get { return _element_no; }
            set
            {
                if (_element_no != value)
                {
                    _element_no = value; RaisePropertyChanged("element_no");
                }
            }
        }
        private DateTime? _date_schedule { get; set; }
        public DateTime? date_schedule
        {
            get { return _date_schedule; }
            set
            {
                if (_date_schedule != value)
                {
                    _date_schedule = value; RaisePropertyChanged("date_schedule");
                }
            }
        }
        private TimeSpan? _time_schedule { get; set; }
        public TimeSpan? time_schedule
        {
            get { return _time_schedule; }
            set
            {
                if (_time_schedule != value)
                {
                    _time_schedule = value; RaisePropertyChanged("time_schedule");
                }
            }
        }
        private DateTime? _date_schedule_f { get; set; }
        public DateTime? date_schedule_f
        {
            get { return _date_schedule_f; }
            set
            {
                if (_date_schedule_f != value)
                {
                    _date_schedule_f = value; RaisePropertyChanged("date_schedule_f");
                }
            }
        }
        private TimeSpan? _time_schedule_f { get; set; }
        public TimeSpan? time_schedule_f
        {
            get { return _time_schedule_f; }
            set
            {
                if (_time_schedule_f != value)
                {
                    _time_schedule_f = value; RaisePropertyChanged("time_schedule_f");
                }
            }
        }
        private DateTime? _date_fixed { get; set; }
        public DateTime? date_fixed
        {
            get { return _date_fixed; }
            set
            {
                if (_date_fixed != value)
                {
                    _date_fixed = value; RaisePropertyChanged("date_fixed");
                }
            }
        }
        private TimeSpan? _time_fixed { get; set; }
        public TimeSpan? time_fixed
        {
            get { return _time_fixed; }
            set
            {
                if (_time_fixed != value)
                {
                    _time_fixed = value; RaisePropertyChanged("time_fixed");
                }
            }
        }
        private DateTime? _date_fixed_f { get; set; }
        public DateTime? date_fixed_f
        {
            get { return _date_fixed_f; }
            set
            {
                if (_date_fixed_f != value)
                {
                    _date_fixed_f = value; RaisePropertyChanged("date_fixed_f");
                }
            }
        }
        private TimeSpan? _time_fixed_f { get; set; }
        public TimeSpan? time_fixed_f
        {
            get { return _time_fixed_f; }
            set
            {
                if (_time_fixed_f != value)
                {
                    _time_fixed_f = value; RaisePropertyChanged("time_fixed_f");
                }
            }
        }
        private DateTime? _date_actual_met { get; set; }
        public DateTime? date_actual_met
        {
            get { return _date_actual_met; }
            set
            {
                if (_date_actual_met != value)
                {
                    _date_actual_met = value; RaisePropertyChanged("date_actual_met");
                }
            }
        }
        private TimeSpan? _time_actual_met { get; set; }
        public TimeSpan? time_actual_met
        {
            get { return _time_actual_met; }
            set
            {
                if (_time_actual_met != value)
                {
                    _time_actual_met = value; RaisePropertyChanged("time_actual_met");
                }
            }
        }
        private string _ind_event { get; set; }
        public string ind_event
        {
            get { return _ind_event; }
            set
            {
                if (_ind_event != value)
                {
                    _ind_event = value; RaisePropertyChanged("ind_event");
                }
            }
        }
        private string _doc_no_confirm { get; set; }
        public string doc_no_confirm
        {
            get { return _doc_no_confirm; }
            set
            {
                if (_doc_no_confirm != value)
                {
                    _doc_no_confirm = value; RaisePropertyChanged("doc_no_confirm");
                }
            }
        }
        private int? _counter_confirm { get; set; }
        public int? counter_confirm
        {
            get { return _counter_confirm; }
            set
            {
                if (_counter_confirm != value)
                {
                    _counter_confirm = value; RaisePropertyChanged("counter_confirm");
                }
            }
        }
        private string _t_status { get; set; }
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
        private string _active { get; set; }
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
        private decimal? _per_project { get; set; }
        public decimal? per_project
        {
            get { return _per_project; }
            set
            {
                if (_per_project != value)
                {
                    _per_project = value; RaisePropertyChanged("per_project");
                }
            }
        }
        private decimal? _per_element { get; set; }
        public decimal? per_element
        {
            get { return _per_element; }
            set
            {
                if (_per_element != value)
                {
                    _per_element = value; RaisePropertyChanged("per_element");
                }
            }
        }
        private decimal? _per_task { get; set; }
        public decimal? per_task
        {
            get { return _per_task; }
            set
            {
                if (_per_task != value)
                {
                    _per_task = value; RaisePropertyChanged("per_task");
                }
            }
        }
        private decimal? _per_invoice { get; set; }
        public decimal? per_invoice
        {
            get { return _per_invoice; }
            set
            {
                if (_per_invoice != value)
                {
                    _per_invoice = value; RaisePropertyChanged("per_invoice");
                }
            }
        }
        private int? _op_row_id { get; set; }
        public int? op_row_id
        {
            get { return _op_row_id; }
            set
            {
                if (_op_row_id != value)
                {
                    _op_row_id = value; RaisePropertyChanged("op_row_id");
                }
            }
        }
        private string _order_doc_cat { get; set; }
        public string order_doc_cat
        {
            get { return _order_doc_cat; }
            set
            {
                if (_order_doc_cat != value)
                {
                    _order_doc_cat = value; RaisePropertyChanged("order_doc_cat");
                }
            }
        }
        private string _order_no { get; set; }
        public string order_no
        {
            get { return _order_no; }
            set
            {
                if (_order_no != value)
                {
                    _order_no = value; RaisePropertyChanged("order_no");
                }
            }
        }
        private int? _order_item_row_id { get; set; }
        public int? order_item_row_id
        {
            get { return _order_item_row_id; }
            set
            {
                if (_order_item_row_id != value)
                {
                    _order_item_row_id = value; RaisePropertyChanged("order_item_row_id");
                }
            }
        }
        private string _note { get; set; }
        public string note
        {
            get { return _note; }
            set
            {
                if (_note != value)
                {
                    _note = value; RaisePropertyChanged("note");
                }
            }
        }

        // Scalar Fields
        private string _project_id { get; set; }
        public string project_id
        {
            get { return _project_id; }
            set
            {
                if (_project_id != value)
                {
                    _project_id = value; RaisePropertyChanged("project_id");
                }
            }
        }
        private string _project_name { get; set; }
        public string project_name
        {
            get { return _project_name; }
            set
            {
                if (_project_name != value)
                {
                    _project_name = value; RaisePropertyChanged("project_name");
                }
            }
        }
        private string _t_display { get; set; }
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
        private string _element_name { get; set; }
        public string element_name
        {
            get { return _element_name; }
            set
            {
                if (_element_name != value)
                {
                    _element_name = value; RaisePropertyChanged("element_name");
                }
            }
        }

    }

    public class PMS_T005 : ObjectBase
    {
        private string comp_code { get; set; }


    }

    public class PMS_T006 : ObjectBase
    {
        private int? _id { get; set; }
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
        private string _comp_code { get; set; }
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
        private string _element_id { get; set; }
        public string element_id
        {
            get { return _element_id; }
            set
            {
                if (_element_id != value)
                {
                    _element_id = value; RaisePropertyChanged("element_id");
                }
            }
        }
        private int? _element_no { get; set; }
        public int? element_no
        {
            get { return _element_no; }
            set
            {
                if (_element_no != value)
                {
                    _element_no = value; RaisePropertyChanged("element_no");
                }
            }
        }
        private string _project_id { get; set; }
        public string project_id
        {
            get { return _project_id; }
            set
            {
                if (_project_id != value)
                {
                    _project_id = value; RaisePropertyChanged("project_id");
                }
            }
        }
        private int? _project_no { get; set; }
        public int? project_no
        {
            get { return _project_no; }
            set
            {
                if (_project_no != value)
                {
                    _project_no = value; RaisePropertyChanged("project_no");
                }
            }
        }
        private DateTime? _date_schedule { get; set; }
        public DateTime? date_schedule
        {
            get { return _date_schedule; }
            set
            {
                if (_date_schedule != value)
                {
                    _date_schedule = value; RaisePropertyChanged("date_schedule");
                }
            }
        }
        private DateTime? _date_forecast { get; set; }
        public DateTime? date_forecast
        {
            get { return _date_forecast; }
            set
            {
                if (_date_forecast != value)
                {
                    _date_forecast = value; RaisePropertyChanged("date_forecast");
                }
            }
        }
        private DateTime? _date_actual { get; set; }
        public DateTime? date_actual
        {
            get { return _date_actual; }
            set
            {
                if (_date_actual != value)
                {
                    _date_actual = value; RaisePropertyChanged("date_actual");
                }
            }
        }
        private DateTime? _date_finish { get; set; }
        public DateTime? date_finish
        {
            get { return _date_finish; }
            set
            {
                if (_date_finish != value)
                {
                    _date_finish = value; RaisePropertyChanged("date_finish");
                }
            }
        }
        private DateTime? _date_forecast_finish { get; set; }
        public DateTime? date_forecast_finish
        {
            get { return _date_forecast_finish; }
            set
            {
                if (_date_forecast_finish != value)
                {
                    _date_forecast_finish = value; RaisePropertyChanged("date_forecast_finish");
                }
            }
        }
        private DateTime? _date_actual_finish { get; set; }
        public DateTime? date_actual_finish
        {
            get { return _date_actual_finish; }
            set
            {
                if (_date_actual_finish != value)
                {
                    _date_actual_finish = value; RaisePropertyChanged("date_actual_finish");
                }
            }
        }
        private decimal? _length_schedule { get; set; }
        public decimal? length_schedule
        {
            get { return _length_schedule; }
            set
            {
                if (_length_schedule != value)
                {
                    _length_schedule = value; RaisePropertyChanged("length_schedule");
                }
            }
        }
        private decimal? _length_forecast { get; set; }
        public decimal? length_forecast
        {
            get { return _length_forecast; }
            set
            {
                if (_length_forecast != value)
                {
                    _length_forecast = value; RaisePropertyChanged("length_forecast");
                }
            }
        }
        private decimal? _length_actual { get; set; }
        public decimal? length_actual
        {
            get { return _length_actual; }
            set
            {
                if (_length_actual != value)
                {
                    _length_actual = value; RaisePropertyChanged("length_actual");
                }
            }
        }
        private string _uom_schedule { get; set; }
        public string uom_schedule
        {
            get { return _uom_schedule; }
            set
            {
                if (_uom_schedule != value)
                {
                    _uom_schedule = value; RaisePropertyChanged("uom_schedule");
                }
            }
        }
        private string _uom_forecast { get; set; }
        public string uom_forecast
        {
            get { return _uom_forecast; }
            set
            {
                if (_uom_forecast != value)
                {
                    _uom_forecast = value; RaisePropertyChanged("uom_forecast");
                }
            }
        }
        private string _uom_actual { get; set; }
        public string uom_actual
        {
            get { return _uom_actual; }
            set
            {
                if (_uom_actual != value)
                {
                    _uom_actual = value; RaisePropertyChanged("uom_actual");
                }
            }
        }
        private string _t_status { get; set; }
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
        private string _active { get; set; }
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

        private string _note { get; set; }
        public string note
        {
            get { return _note; }
            set
            {
                if (_note != value)
                {
                    _note = value; RaisePropertyChanged("note");
                }
            }
        }
        private string _ind_revised { get; set; }
        public string ind_revised
        {
            get { return _ind_revised; }
            set
            {
                if (_ind_revised != value)
                {
                    _ind_revised = value; RaisePropertyChanged("ind_revised");
                }
            }
        }
        private DateTime? _date_revised { get; set; }
        public DateTime? date_revised
        {
            get { return _date_revised; }
            set
            {
                if (_date_revised != value)
                {
                    _date_revised = value; RaisePropertyChanged("date_revised");
                }
            }
        }
        private string _ind_change { get; set; }
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
    }

    
}
