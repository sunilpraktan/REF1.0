using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class MM_T004 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        
        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set { _PartyId = value; RaisePropertyChanged("PartyId"); }
        }
        private string _PartyNm;

        public string PartyNm
        {
            get { return _PartyNm; }
            set { _PartyNm = value; RaisePropertyChanged("PartyNm"); }
        }
        private string _EmpId;
        public string EmpId
        {
            get { return _EmpId; }
            set { _EmpId = value; RaisePropertyChanged("EmpId"); }
        }
        private string _EmpNm;
        public string EmpNm
        {
            get { return _EmpNm; }
            set { _EmpNm = value; RaisePropertyChanged("EmpNm"); }
        }
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode"); }
        }
        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; RaisePropertyChanged("ItemName"); }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }
        private string _unit_name;
        public string unit_name
        {
            get { return _unit_name; }
            set { _unit_name = value; RaisePropertyChanged("unit_name"); }
        }
        private int? _ContInfoId;
        public int? ContInfoId
        {
            get { return _ContInfoId; }
            set { _ContInfoId = value; RaisePropertyChanged("ContInfoId"); }
        }
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; RaisePropertyChanged("address"); }
        }
        private string _phone_no;
        public string phone_no
        {
            get { return _phone_no; }
            set { _phone_no = value; RaisePropertyChanged("phone_no"); }
        }
        private DateTime? _entry_date;
        public DateTime? entry_date
        {
            get { return _entry_date; }
            set
            {
                _entry_date = value;
                RaisePropertyChanged("entry_date");
            }
        }
        private string _entry_time;
        public string entry_time
        {
            get { return _entry_time; }
            set { _entry_time = value; RaisePropertyChanged("entry_time"); }
        }
        private string _in_time;
        public string in_time
        {
            get { return _in_time; }
            set { _in_time = value; RaisePropertyChanged("in_time"); }
        }
        private string _out_time;
        public string out_time
        {
            get { return _out_time; }
            set { _out_time = value; RaisePropertyChanged("out_time"); }
        }
        private decimal? _qty;
        public decimal? qty
        {
            get { return _qty; }
            set { _qty = value; RaisePropertyChanged("qty"); }
        }
        private string _dept_code;
        public string dept_code
        {
            get { return _dept_code; }
            set { _dept_code = value; RaisePropertyChanged("dept_code"); }
        }
        private string _vehicle_no;
        public string vehicle_no
        {
            get { return _vehicle_no; }
            set { _vehicle_no = value; RaisePropertyChanged("vehicle_no"); }
        }
        private string _note;
        public string note
        {
            get { return _note; }
            set { _note = value; RaisePropertyChanged("note"); }
        }
        private string _remark;
        public string remark
        {
            get { return _remark; }
            set { _remark = value; RaisePropertyChanged("remark"); }
        }
        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set { _order_no = value; RaisePropertyChanged("order_no"); }
        }
        private DateTime? _order_date;
        public DateTime? order_date
        {
            get { return _order_date; }
            set { _order_date = value; RaisePropertyChanged("order_date"); }
        }
        private string _challan_no;
        public string challan_no
        {
            get { return _challan_no; }
            set { _challan_no = value; RaisePropertyChanged("challan_no"); }
        }
        private DateTime? _challan_date;
        public DateTime? challan_date
        {
            get { return _challan_date; }
            set { _challan_date = value; RaisePropertyChanged("challan_date"); }
        }
        private string _bill_no;
        public string bill_no
        {
            get { return _bill_no; }
            set { _bill_no = value; RaisePropertyChanged("bill_no"); }
        }
        private DateTime? _bill_date;
        public DateTime? bill_date
        {
            get { return _bill_date; }
            set { _bill_date = value; RaisePropertyChanged("bill_date"); }
        }
        private string _grn_no;
        public string grn_no
        {
            get { return _grn_no; }
            set { _grn_no = value; RaisePropertyChanged("grn_no"); }
        }
        private string _service_provider_id;
        public string service_provider_id
        {
            get { return _service_provider_id; }
            set { _service_provider_id = value; RaisePropertyChanged("service_provider_id"); }
        }
        private string _service_provider_nm;
        public string service_provider_nm
        {
            get { return _service_provider_nm; }
            set { _service_provider_nm = value; RaisePropertyChanged("service_provider_nm"); }
        }
        private string _gate_pass_no;
        public string gate_pass_no
        {
            get { return _gate_pass_no; }
            set { _gate_pass_no = value; RaisePropertyChanged("gate_pass_no"); }
        }
        private string _issued_by_id;
        public string issued_by_id
        {
            get { return _issued_by_id; }
            set { _issued_by_id = value; RaisePropertyChanged("issued_by_id"); }
        }
        private string _issued_by_nm;
        public string issued_by_nm
        {
            get { return _issued_by_nm; }
            set { _issued_by_nm = value; RaisePropertyChanged("issued_by_nm"); }
        }
        private string _issued_to_id;
        public string issued_to_id
        {
            get { return _issued_to_id; }
            set { _issued_to_id = value; RaisePropertyChanged("issued_to_id"); }
        }
        private string _issued_to_nm;
        public string issued_to_nm
        {
            get { return _issued_to_nm; }
            set { _issued_to_nm = value; RaisePropertyChanged("issued_to_nm"); }
        }
        private DateTime? _return_date;
        public DateTime? return_date
        {
            get { return _return_date; }
            set { _return_date = value; RaisePropertyChanged("return_date"); }
        }
        private string _authorised_by;
        public string authorised_by
        {
            get { return _authorised_by; }
            set { _authorised_by = value; RaisePropertyChanged("authorised_by"); }
        }
        private string _prepared_by;
        public string prepared_by
        {
            get { return _prepared_by; }
            set { _prepared_by = value; RaisePropertyChanged("prepared_by"); }
        }
        private string _received_by;
        public string received_by
        {
            get { return _received_by; }
            set { _received_by = value; RaisePropertyChanged("received_by"); }
        }
        private string _security_person;
        public string security_person
        {
            get { return _security_person; }
            set { _security_person = value; RaisePropertyChanged("security_person"); }
        }
        private string _driverNm;
        public string driverNm
        {
            get { return _driverNm; }
            set { _driverNm = value; RaisePropertyChanged("driverNm"); }
        }
        private string _duration;
        public string duration
        {
            get { return _duration; }
            set { _duration = value; RaisePropertyChanged("duration"); }
        }
        private string _reading_out;
        public string reading_out
        {
            get { return _reading_out; }
            set { _reading_out = value; RaisePropertyChanged("reading_out"); }
        }
        private string _reading_in;
        public string reading_in
        {
            get { return _reading_in; }
            set { _reading_in = value; RaisePropertyChanged("reading_in"); }
        }
        private string _distance;
        public string distance
        {
            get { return _distance; }
            set { _distance = value; RaisePropertyChanged("distance"); }
        }
        private string _place;
        public string place
        {
            get { return _place; }
            set { _place = value; RaisePropertyChanged("place"); }
        }
        private string _gate_no;
        public string gate_no
        {
            get { return _gate_no; }
            set { _gate_no = value; RaisePropertyChanged("gate_no"); }
        }
        private string _person_to_be_visited_id;
        public string person_to_be_visited_id
        {
            get { return _person_to_be_visited_id; }
            set { _person_to_be_visited_id = value; RaisePropertyChanged("person_to_be_visited_id"); }
        }
        private string _person_to_be_visited_nm;
        public string person_to_be_visited_nm
        {
            get { return _person_to_be_visited_nm; }
            set { _person_to_be_visited_nm = value; RaisePropertyChanged("person_to_be_visited_nm"); }
        }
        private string _no_of_person;
        public string no_of_person
        {
            get { return _no_of_person; }
            set { _no_of_person = value; RaisePropertyChanged("no_of_person"); }
        }
        private string _lrno;
        public string lrno
        {
            get { return _lrno; }
            set { _lrno = value; RaisePropertyChanged("lrno"); }
        }
        private DateTime? _lrdate;
        public DateTime? lrdate
        {
            get { return _lrdate; }
            set { _lrdate = value; RaisePropertyChanged("lrdate"); }
        }
        
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private DateTime? _add_date;
        public DateTime? add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }
        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set { _fin_year = value; RaisePropertyChanged("fin_year"); }
        }
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set { _posting_period = value; RaisePropertyChanged("posting_period"); }
        }
        private string _batch_no;
        public string batch_no
        {
            get { return _batch_no; }
            set { _batch_no = value; RaisePropertyChanged("batch_no"); }
        }
        private decimal? _weight;
        public decimal? weight
        {
            get { return _weight; }
            set { _weight = value; RaisePropertyChanged("weight"); }
        }
        private string _pod_no;
        public string pod_no
        {
            get { return _pod_no; }
            set { _pod_no = value; RaisePropertyChanged("pod_no"); }
        }
        private string _description;
        public string description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("description"); }
        }
        private string _purpose;
        public string purpose
        {
            get { return _purpose; }
            set { _purpose = value; RaisePropertyChanged("purpose"); }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        private string _doc_type { get; set; }
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type"); }
        }
        private string _doc_type_name { get; set; }
        public string doc_type_name
        {
            get { return _doc_type_name; }
            set { _doc_type_name = value; RaisePropertyChanged("doc_type_name"); }
        }
        private string _del_note_no;
        public string del_note_no
        {
            get { return _del_note_no; }
            set { _del_note_no = value; RaisePropertyChanged("del_note_no"); }
        }
        private DateTime? _del_note_date;
        public DateTime? del_note_date
        {
            get { return _del_note_date; }
            set { _del_note_date = value; RaisePropertyChanged("del_note_date"); }
        }
        private DateTime? _date_of_receipt;
        public DateTime? date_of_receipt
        {
            get { return _date_of_receipt; }
            set { _date_of_receipt = value; RaisePropertyChanged("date_of_receipt"); }
        }
        private DateTime? _posting_date;
        public DateTime? posting_date
        {
            get { return _posting_date; }
            set { _posting_date = value; RaisePropertyChanged("posting_date"); }
        }
        private string _trans_mode;
        public string trans_mode
        {
            get { return _trans_mode; }
            set { _trans_mode = value; RaisePropertyChanged("trans_mode"); }
        }
        private string _dept_Nm;
        public string dept_Nm
        {
            get { return _dept_Nm; }
            set { _dept_Nm = value; RaisePropertyChanged("dept_Nm"); }
        }
        private string _location;
        public string location
        {
            get { return _location; }
            set { _location = value; RaisePropertyChanged("location"); }
        }
        private string _material_order_for;
        public string material_order_for
        {
            get { return _material_order_for; }
            set { _material_order_for = value; RaisePropertyChanged("material_order_for"); }
        }
        private string _prepared_by_nm;
        public string prepared_by_nm
        {
            get { return _prepared_by_nm; }
            set { _prepared_by_nm = value; RaisePropertyChanged("prepared_by_nm"); }
        }
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set { _t_display = value; RaisePropertyChanged("t_display"); }
        }
        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public class MultipleContext_MM_T004
    {
        public List<SYS_M002> DocTypeInfo { get; set; }
        public List<MM_T004Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> partyList { get; set; }
        public List<ADM_M024_P> EmpList { get; set; }
        public List<ADM_M038_B_P> unitList { get; set; }
        public List<ADM_M025_P> deptList { get; set; }
        public List<ADM_M022_P> ItemList { get; set; }
        public List<ADM_M028_P> Transporters { get; set; }
        public List<ADM_M028_C_P> contactInfoMaster { get; set; }
        public List<MM_T004> DocumentMaster { get; set; }
        //public List<SYS_M007> doc_typeList { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<STD_DOC_TYPE> DOC_TYPE_LIST { get; set; }
    }
}
