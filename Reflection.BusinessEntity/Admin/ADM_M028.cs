using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity.Admin;
using Reflection.BusinessEntity.Finance;
using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.Account;

namespace Reflection.BusinessEntity
{
    public class ADM_M028 : ObjectBase
    {     
        private int _id;       
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set
            {
                _PartyId = value;
                RaisePropertyChanged("PartyId");
            }
        }

        private string _PartyNm;       
        public string PartyNm
        {
            get { return _PartyNm; }
            set
            {
                _PartyNm = value;
                RaisePropertyChanged("PartyNm");
            }
        }

        private string _abbr;
        public string abbr
        {
            get { return _abbr; }
            set
            {
                _abbr = value;
                RaisePropertyChanged("abbr");
            }
        }

        private string _VendorCd;
        public string VendorCd
        {
            get { return _VendorCd; }
            set
            {
                _VendorCd = value;
                RaisePropertyChanged("VendorCd");
            }
        }

        private Nullable<bool> _transporter;
        public Nullable<bool> transporter
        {
            get { return _transporter; }
            set
            {
                _transporter = value;
                RaisePropertyChanged("transporter");
            }
        }

        private Nullable<bool> _Customer;
        public Nullable<bool> Customer
        {
            get { return _Customer; }
            set
            {
                _Customer = value;
                RaisePropertyChanged("Customer");
            }
        }

        private Nullable<bool> _Supplier;
        public Nullable<bool> Supplier
        {
            get { return _Supplier; }
            set { _Supplier = value; RaisePropertyChanged("Supplier"); }
        }

        private string _ManuScop;
        public string ManuScop
        {
            get { return _ManuScop; }
            set
            {
                _ManuScop = value;
                RaisePropertyChanged("ManuScop");
            }
        }

        private string _BusinesTyp;
        public string BusinesTyp
        {
            get { return _BusinesTyp; }
            set
            {
                _BusinesTyp = value;
                RaisePropertyChanged("BusinesTyp");
            }
        }
        private string _buss_type;
        public string buss_type
        {
            get { return _buss_type; }
            set
            {
                _buss_type = value;
                RaisePropertyChanged("buss_type");
            }
        }

        private string _PhNo;
        public string PhNo
        {
            get { return _PhNo; }
            set
            {
                _PhNo = value;
                RaisePropertyChanged("PhNo");
            }
        }

        private string _PhExt;
        public string PhExt
        {
            get { return _PhExt; }
            set
            {
                _PhExt = value;
                RaisePropertyChanged("PhExt");
            }
        }

        private string _FaxNo;
        public string FaxNo
        {
            get { return _FaxNo; }
            set
            {
                _FaxNo = value;
                RaisePropertyChanged("FaxNo");
            }
        }

        private string _EmailId;
        public string EmailId
        {
            get { return _EmailId; }
            set
            {
                _EmailId = value;
                RaisePropertyChanged("EmailId");
            }
        }

        private string _WebSite;
        public string WebSite
        {
            get { return _WebSite; }
            set
            {
                _WebSite = value;
                RaisePropertyChanged("WebSite");
            }
        }

        private string _ContPersnNm;
        public string ContPersnNm
        {
            get { return _ContPersnNm; }
            set
            {
                _ContPersnNm = value;
                RaisePropertyChanged("ContPerNm");
            }
        }

        private string _PersnMobNo;
        public string PersnMobNo
        {
            get { return _PersnMobNo; }
            set
            {
                _PersnMobNo = value;
                RaisePropertyChanged("_PersnMobNo");
            }
        }

        private string _PersnPhNo;
        public string PersnPhNo
        {
            get { return _PersnPhNo; }
            set
            {
                _PersnPhNo = value;
                RaisePropertyChanged("PersnPhNo");
            }
        }

        private string _PersnPhExt;
        public string PersnPhExt
        {
            get { return _PersnPhExt; }
            set
            {
                _PersnPhExt = value;
                RaisePropertyChanged("PersnPhExt");
            }
        }

        private string _PersnFaxNo;
        public string PersnFaxNo
        {
            get { return _PersnFaxNo; }
            set
            {
                _PersnFaxNo = value;
                RaisePropertyChanged("PersnFaxNo");
            }
        }

        private string _PersnEmailId;
        public string PersnEmailId
        {
            get { return _PersnEmailId; }
            set
            {
                _PersnEmailId = value;
                RaisePropertyChanged("PersnEmailId");
            }
        }

        private string _CSTNo;
        public string CSTNo
        {
            get { return _CSTNo; }
            set
            {
                _CSTNo = value;
                RaisePropertyChanged("CSTNo");
            }
        }

        private Nullable<System.DateTime> _CSTDate;
        public Nullable<System.DateTime> CSTDate
        {
            get { return _CSTDate; }
            set
            {
                _CSTDate = value;
                RaisePropertyChanged("CSTDate");
            }
        }

        private string _VATNo;
        public string VATNo
        {
            get { return _VATNo; }
            set
            {
                _VATNo = value;
                RaisePropertyChanged("VATNo");
            }
        }

        private Nullable<System.DateTime> _VATDate;
        public Nullable<System.DateTime> VATDate
        {
            get { return _VATDate; }
            set
            {
                _VATDate = value;
                RaisePropertyChanged("VATDate");
            }
        }

        private string _TNo;
        public string TNo
        {
            get { return _TNo; }
            set
            {
                _TNo = value;
                RaisePropertyChanged("TNo");
            }
        }

        private Nullable<System.DateTime> _TDate;
        public Nullable<System.DateTime> TDate
        {
            get { return _TDate; }
            set
            {
                _TDate = value;
                RaisePropertyChanged("TDate");
            }
        }

        private string _STNo;
        public string STNo
        {
            get { return _STNo; }
            set
            {
                _STNo = value;
                RaisePropertyChanged("STNo");
            }
        }

        private Nullable<System.DateTime> _STDate;
        public Nullable<System.DateTime> STDate
        {
            get { return _STDate; }
            set
            {
                _STDate = value;
                RaisePropertyChanged("STDate");
            }
        }

        private string _EccCode;
        public string EccCode { get { return _EccCode; } set { _EccCode = value; RaisePropertyChanged("EccCode"); } }

        private string _Range;
        public string Range { get { return _Range; } set { _Range = value; RaisePropertyChanged("Range"); } }

        private string _CeRange;    
        public string CeRange { get { return _CeRange; } set { _CeRange = value; RaisePropertyChanged("CeRange"); } }

        private string _RngOffAdd1;
        public string RngOffAdd1 { get { return _RngOffAdd1; } set { _RngOffAdd1 = value; RaisePropertyChanged("RngOffAdd1"); } }

        private string _RngOffAdd2;
        public string RngOffAdd2 { get { return _RngOffAdd2; } set { _RngOffAdd2 = value; RaisePropertyChanged("RngOffAdd2"); } }

        private string _Juri;
        public string Juri { get { return _Juri; } set { _Juri = value; RaisePropertyChanged("Juri"); } }

        private string _Cmsnrt;
        public string Cmsnrt { get { return _Cmsnrt; } set { _Cmsnrt = value; RaisePropertyChanged("Cmsnrt"); } }

        private string _CmsnrtAdd;
        public string CmsnrtAdd { get { return _CmsnrtAdd; } set { _CmsnrtAdd = value; RaisePropertyChanged("CmsnrtAdd"); } }

        private string _PanNo;
        public string PanNo { get { return _PanNo; } set { _PanNo = value; RaisePropertyChanged("PanNo"); } }

        private string _div_code;
        public string div_code { get { return _div_code; } set { _div_code = value; RaisePropertyChanged("div_code"); } }

        private string _PfAccNo;
        public string PfAccNo { get { return _PfAccNo; } set { _PfAccNo = value; RaisePropertyChanged("PfAccNo"); } }

        private string _p_term_code;
        public string p_term_code { get { return _p_term_code; } set { _p_term_code = value; RaisePropertyChanged("p_term_code"); } }

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                _curr_code = value;
                RaisePropertyChanged("curr_code");
            }
        }

        private string _FinYr;
        public string FinYr { get { return _FinYr; } set { _FinYr = value; RaisePropertyChanged("FinYr"); } }

        private string _TaxContPersnNm;
        public string TaxContPersnNm
        {
            get { return _TaxContPersnNm; }

            set
            {
                _TaxContPersnNm = value;
                RaisePropertyChanged("TaxContPersnNm");
            }
        }

        private string _TaxContPersnMobNo;
        public string TaxContPersnMobNo
        {
            get { return _TaxContPersnMobNo; }
            set
            {
                _TaxContPersnMobNo = value;
                RaisePropertyChanged("TaxContPersnMobNo");
            }
        }

        private string _acc_receivable;
        public string acc_receivable
        {
            get { return _acc_receivable; }
            set { _acc_receivable = value; RaisePropertyChanged("acc_receivable"); }
        }

        private string _acc_payable;
        public string acc_payable
        {
            get { return _acc_payable; }
            set { _acc_payable = value; RaisePropertyChanged("acc_payable"); }
        }

        private string _cust_pay_term;
        public string cust_pay_term
        {
            get { return _cust_pay_term; }
            set { _cust_pay_term = value; RaisePropertyChanged("cust_pay_term"); }
        }

        private string _supp_pay_term;
        public string supp_pay_term
        {
            get { return _supp_pay_term; }
            set { _supp_pay_term = value; RaisePropertyChanged("supp_pay_term"); }
        }

        private Nullable<decimal> _credit_limit;
        public Nullable<decimal> credit_limit
        {
            get { return _credit_limit; }
            set { _credit_limit = value; RaisePropertyChanged("credit_limit"); }
        }

        private Nullable<decimal> _debit_limit;
        public Nullable<decimal> debit_limit
        {
            get { return _debit_limit; }
            set { _debit_limit = value; RaisePropertyChanged("debit_limit"); }
        }

        private string _EmpNm;
        public string EmpNm
        {
            get { return _EmpNm; }
            set { _EmpNm = value; RaisePropertyChanged("EmpNm"); }
        }

        private Nullable<int> _fiscal_position;
        public Nullable<int> fiscal_position
        {
            get { return _fiscal_position; }
            set { _fiscal_position = value; RaisePropertyChanged("fiscal_position"); }
        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date { get { return _add_date; } set { _add_date = value; RaisePropertyChanged("add_date"); } }

        private string _editby;
        public string editby { get { return _editby; } set { _editby = value; RaisePropertyChanged("editby"); } }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date { get { return _edit_date; } set { _edit_date = value; RaisePropertyChanged("edit_date"); } }


        private string _Location;
        public string Location
        {
            get { return _Location; }
            set
            {
                _Location = value;
                RaisePropertyChanged("Location");
            }
        }
        private string _location_Id;
        public string location_Id { get { return _location_Id; } set { _location_Id = value; RaisePropertyChanged("location_Id"); } }

        private string _godown_location_name;
        public string godown_location_name { get { return _godown_location_name; } set { _godown_location_name = value; RaisePropertyChanged("godown_location_name"); } }

        private string _curr_name;
        public string curr_name { get { return _curr_name; } set { _curr_name = value; RaisePropertyChanged("curr_name"); } }

        private string _PartyType;
        public string PartyType
        {
            get { return _PartyType; }
            set
            {
                _PartyType = value;
                RaisePropertyChanged("PartyType");
            }
        }

        private string _desig_code;
        public string desig_code
        {
            get { return _desig_code; }
            set
            {
                _desig_code = value;
                RaisePropertyChanged("desig_code");
            }
        }
        
        private Nullable<int> _credit_days;
        public Nullable<int> credit_days
        {
            get { return _credit_days; }
            set
            {
                _credit_days = value;
                RaisePropertyChanged(" credit_days");
            }
        }

        private string _principle_party;
        public string principle_party
        {
            get { return _principle_party; }
            set
            {
                _principle_party = value;
                RaisePropertyChanged("principle_party");
            }
        }

        private string _TDS;
        public string TDS
        {
            get { return _TDS; }
            set
            {
                _TDS = value;
                RaisePropertyChanged("TDS");
            }
        }

        private string _group1;
        public string group1
        {
            get { return _group1; }
            set
            {
                _group1 = value;
                RaisePropertyChanged("group1");
            }
        }

        private string _EmpId;
        public string EmpId
        {
            get { return _EmpId; }
            set
            {
                _EmpId = value;
                RaisePropertyChanged("EmpId");

            }
        }

        private string _one_time_party;
        public string one_time_party
        {
            get { return _one_time_party; }
            set
            {
                _one_time_party = value;
                RaisePropertyChanged("one_time_party");
            }
        }

        private string _iec_code;
        public string iec_code
        {
            get { return _iec_code; }
            set
            {
                _iec_code = value;
                RaisePropertyChanged("iec_code");
            }
        }

        private string _service_tax_no;
        public string service_tax_no
        {
            get { return _service_tax_no; }
            set
            {
                _service_tax_no = value;
                RaisePropertyChanged("service_tax_no");
            }
        }

        private string _grpNm;
        public string grpNm
        {
            get
            {
                return _grpNm;
            }

            set
            {
                _grpNm = value;
                RaisePropertyChanged("grpNm");
            }
        }

        private string _PartyType_Nm;
        public string PartyType_Nm
        {
            get
            {
                return _PartyType_Nm;
            }
            set
            {
                _PartyType_Nm = value;
                RaisePropertyChanged("PartyType_Nm");
            }
        }

        private string _godown_location;
        public string godown_location
        {
            get
            {
                return _godown_location;
            }
            set
            {
                _godown_location = value;
                RaisePropertyChanged("godown_location");
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get
            {
                return _comp_code;
            }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }

        private string _acc_group;
        public string acc_group
        {
            get { return _acc_group; }
            set
            {
                _acc_group = value;RaisePropertyChanged("acc_group");
            }
        }

        private string _recon_acc;
        public string recon_acc
        {
            get { return _recon_acc; }

            set { _recon_acc = value; RaisePropertyChanged("recon_acc"); }
        }

        private string _gstinno;
        public string gstinno
        {
            get { return _gstinno; }

            set { _gstinno = value; RaisePropertyChanged("gstinno"); }
        }
        private string _buss_place;
        public string buss_place
        {
            get { return _buss_place; }

            set { _buss_place = value; RaisePropertyChanged("buss_place"); }
        }
        private string _tax_acc_group { get; set; }
        public string tax_acc_group
        {
            get { return _tax_acc_group; }

            set { _tax_acc_group = value; RaisePropertyChanged("tax_acc_group"); }
        }
        private string _tax_classification;
        public string tax_classification
        {
            get { return _tax_classification; }

            set { _tax_classification = value; RaisePropertyChanged("tax_classification"); }
        }
        //private Nullable<System.DateTime> _gstindate;
        //public Nullable<System.DateTime> gstindate
        //{
        //    get { return _gstindate; }
        //    set { _gstindate = value; RaisePropertyChanged("gstindate"); }
        //}
        private Nullable<System.DateTime> _gstindate;
        public Nullable<System.DateTime> gstindate
        {
            get { return _gstindate; }
            set
            {
                _gstindate = value;
                RaisePropertyChanged("gstindate");
            }
        }
        
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }
        private string _default_tax;
        public string default_tax
        {
            get { return _default_tax; }
            set { _default_tax = value; RaisePropertyChanged("default_tax"); }
        }
        //scalar 

        private string _gl_name;
        public string gl_name
        {
            get { return _gl_name; }

            set { _gl_name = value; RaisePropertyChanged("gl_name"); }
        }

        private string _group_desc;
        public string group_desc
        {
            get { return _group_desc; }
            set
            {
                _group_desc = value; RaisePropertyChanged("group_desc");
            }
        }

        private string _acc_group_type;
        public string acc_group_type
        {
            get { return _acc_group_type; }
            set
            {
                _acc_group_type = value; RaisePropertyChanged("acc_group_type");
            }
        }

        private string _plc_name;
        public string plc_name
        {
            get { return _plc_name; }
            set
            {
                _plc_name = value; RaisePropertyChanged("plc_name");
            }
        }

        private string _tax_acc_group_name;
        public string tax_acc_group_name
        {
            get { return _tax_acc_group_name; }
            set
            {
                _tax_acc_group_name = value; RaisePropertyChanged("tax_acc_group_name");
            }
        }

        private string _tax_indicator;
        public string tax_indicator
        {
            get { return _tax_indicator; }

            set { _tax_indicator = value; RaisePropertyChanged("tax_indicator"); }
        }

        private string _tax_indicator_desc;
        public string tax_indicator_desc
        {
            get { return _tax_indicator_desc; }

            set { _tax_indicator_desc = value; RaisePropertyChanged("tax_indicator_desc"); }
        }
       
        private string _p_term;
        public string p_term
        {
            get { return _p_term; }

            set { _p_term = value; RaisePropertyChanged("p_term"); }
        }
        private string _vendor_remark;
        public string vendor_remark
        {
            get { return _vendor_remark; }

            set { _vendor_remark = value; RaisePropertyChanged("vendor_remark"); }
        }
        private string _buss_type_name;
        public string buss_type_name
        {
            get { return _buss_type_name; }

            set { _buss_type_name = value; RaisePropertyChanged("buss_type_name"); }
        }
        private string _scope_name;
        public string scope_name
        {
            get { return _scope_name; }

            set { _scope_name = value; RaisePropertyChanged("scope_name"); }
        }
        private string _region_name;
        public string region_name
        {
            get { return _region_name; }

            set { _region_name = value; RaisePropertyChanged("region_name"); }
        }
        public string XmlDataDocument_ADM_M028_C { get; set; }
        public string XmlDataDocument_ADM_M028_D { get; set; }
        public string XmlDataDocument_ADM_M028FLIP { get; set; }
    }

    public class ADM_M028_C : ObjectBase
    {
        private int _ContInfoId;
        public int ContInfoId
        {
            get { return _ContInfoId; }
            set
            {
                _ContInfoId = value;
                RaisePropertyChanged("ContInfoId");
            }
        }
        private string _cp_code { get; set; }
        public string cp_code
        {
            get { return _cp_code; }
            set
            {
                _cp_code = value;
                RaisePropertyChanged("cp_code");
            }
        }
        private string _PartyId { get; set; }
        public string PartyId
        {
            get { return _PartyId; }
            set
            {
                _PartyId = value;
                RaisePropertyChanged("PartyId");
            }
        }

        private string _Location { get; set; }
        public string Location
        {
            get { return _Location; }
            set
            {
                _Location = value;
                RaisePropertyChanged("Location");
            }
        }
        private string _PersnFName { get; set; }       
        public string PersnFName
        {
            get { return _PersnFName; }
            set
            {
                _PersnFName = value;
                RaisePropertyChanged("PersnFName");
            }
        }

        private string _PersnMName { get; set; }
        public string PersnMName
        {
            get { return _PersnMName; }
            set
            {
                _PersnMName = value;
                RaisePropertyChanged("PersnMName");
            }
        }

        private string _PersnLName { get; set; }     
        public string PersnLName
        {
            get { return _PersnLName; }
            set
            {
                _PersnLName = value;
                RaisePropertyChanged("PersnLName");
            }
        }

        private string _dept_code { get; set; }
        public string dept_code
        {
            get { return _dept_code; }
            set
            {
                _dept_code = value;
                RaisePropertyChanged("dept_code");
            }
        }

        private string _desig_code { get; set; }
        public string desig_code
        {
            get { return _desig_code; }
            set
            {
                _desig_code = value;
                RaisePropertyChanged("desig_code");
            }
        }

        private Nullable<int> _Age { get; set; }
        public Nullable<int> Age
        {
            get { return _Age; }
            set
            {
                _Age = value;
                RaisePropertyChanged("Age");
            }
        }

        private string _Gender { get; set; }
        public string Gender
        {
            get { return _Gender; }
            set
            {
                _Gender = value;
                RaisePropertyChanged("Gender");
            }
        }

        private string _PersnMobNo { get; set; }
        public string PersnMobNo
        {
            get { return _PersnMobNo; }
            set
            {
                _PersnMobNo = value;
                RaisePropertyChanged("PersnMobNo");
            }
        }

        private string _PersnPhNo { get; set; }
        public string PersnPhNo
        {
            get { return _PersnPhNo; }
            set
            {
                _PersnPhNo = value;
                RaisePropertyChanged("PersnPhNo");
            }
        }

        private string _PersnPhExt { get; set; }
        public string PersnPhExt
        {
            get { return _PersnPhExt; }
            set
            {
                _PersnPhExt = value;
                RaisePropertyChanged("PersnPhExt");
            }
        }

        private string _PersnFaxNo { get; set; }
        public string PersnFaxNo
        {
            get { return _PersnFaxNo; }
            set
            {
                _PersnFaxNo = value;
                RaisePropertyChanged("PersnFaxNo");
            }
        }

        private string _PersnEmailId { get; set; }
        public string PersnEmailId
        {
            get { return _PersnEmailId; }
            set
            {
                _PersnEmailId = value;
                RaisePropertyChanged("PersnEmailId");
            }
        }

        private bool _active { get; set; }
        public bool active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }

        public string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }

        public Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }

        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged("title"); }
        }

        public string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set
            {
                _PartyNm = value;
                RaisePropertyChanged("PartyNm");
            }
        }

        public string _DeptName;
        public string DeptName
        {
            get { return _DeptName; }
            set
            {
                _DeptName = value;
                RaisePropertyChanged("DeptName");
            }
        }

        public string _DesigName;
        public string DesigName
        {
            get { return _DesigName; }
            set
            {
                _DesigName = value;
                RaisePropertyChanged("DesigName");
            }
        }

        private string _default_del;
        public string default_del
        {
            get { return _default_del; }
            set
            {
                _default_del = value; RaisePropertyChanged("default_del");

            }
        }

        private string _default_bil;
        public string default_bil
        {
            get { return _default_bil; }
            set
            {
                _default_bil = value; RaisePropertyChanged("default_bil");
            }
        }
    }

    public class ADM_M028_D : ObjectBase
    {
        private string _add_code;
        public string add_code
        {
            get { return _add_code; }
            set
            {
                _add_code = value;
                RaisePropertyChanged("add_code");
            }
        }
        private int _SrNo { get; set; }
        public int SrNo
        {
            get { return _SrNo; }
            set { _SrNo = value; RaisePropertyChanged("SrNo"); }
        }

        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set
            {
                _PartyId = value;
                RaisePropertyChanged("PartyId");
            }
        }

        private string _Location;       
        public string Location
        {
            get { return _Location; }
            set
            {
                _Location = value;
                RaisePropertyChanged("Location");
            }
        }

        private string _AddType;
        public string AddType
        {
            get { return _AddType; }
            set
            {
                _AddType = value;
                RaisePropertyChanged("AddType");
            }
        }

        private string _Add1;     
        public string Add1
        {
            get { return _Add1; }
            set
            {
                _Add1 = value;
                RaisePropertyChanged("Add1");
            }
        }

        private string _Add2;
        public string Add2
        {
            get { return _Add2; }
            set
            {
                _Add2 = value;
                RaisePropertyChanged("Add2");
            }
        }

        private string _LandMark;
        public string LandMark
        {
            get { return _LandMark; }
            set
            {
                _LandMark = value;
                RaisePropertyChanged("LandMark");
            }
        }

        private string _City;
        public string City
        {
            get { return _City; }
            set
            {
                _City = value;
                RaisePropertyChanged("City");
            }
        }

        private string _state_code;
        public string state_code
        {
            get { return _state_code; }
            set { _state_code = value; RaisePropertyChanged("state_code"); }
        }

        private string _country_code;
        public string country_code
        {
            get { return _country_code; }
            set { _country_code = value; RaisePropertyChanged("country_code"); }
        }

        private string _PinCode;
        public string PinCode
        {
            get { return _PinCode; }
            set
            {
                _PinCode = value;
                RaisePropertyChanged("PinCode");
            }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }

        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }

        private Nullable<bool>_active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        private string _gstinno;
        public string gstinno
        {
            get { return _gstinno; }
            set
            {
                _gstinno = value;
                RaisePropertyChanged("gstinno");
            }
        }
        private string _buss_place;
        public string buss_place
        {
            get { return _buss_place; }
            set
            {
                _buss_place = value;
                RaisePropertyChanged("buss_place");
            }
        }
        private Nullable<System.DateTime> _gstindate;
        public Nullable<System.DateTime> gstindate
        {
            get { return _gstindate; }
            set
            {
                _gstindate = value;
                RaisePropertyChanged("gstindate");
            }
        }

        private string _PartyNm { get; set; }
        public string PartyNm
        {
            get { return _PartyNm; }
            set
            {
                _PartyNm = value;
                RaisePropertyChanged("PartyNm");
            }
        }

        private string _CntryName;
        public string CntryName
        {
            get { return _CntryName; }
            set
            {
                _CntryName = value;
                RaisePropertyChanged("CntryName");
            }
        }

        private string _StatName;
        public string StatName
        {
            get { return _StatName; }
            set
            {
                _StatName = value;
                RaisePropertyChanged("StatName");
            }
        }

        private string _address_full;
        public string address_full
        {
            get { return _address_full; }
            set
            {
                _address_full = value;
                RaisePropertyChanged("address_full");
            }
        }
        private string _default_tax;
        public string default_tax
        {
            get { return _default_tax; }
            set { _default_tax = value; RaisePropertyChanged("default_tax"); }
        }

        private string _land_mark;
        public string land_mark
        {
            get { return _land_mark; }
            set { _land_mark = value; RaisePropertyChanged("land_mark"); }
        }

        private string _map_link;
        public string map_link
        {
            get { return _map_link; }
            set { _map_link = value; RaisePropertyChanged("map_link"); }
        }
    }

    public class MultipleContext_ADM_M028 : MC_ADM_BE
    {
        //public List<STD_PARTY> PARTY_LIST { get; set; }
        //public List<ACC_M013> TAX_LIST { get; set; }
        //public List<ADM_M0002> COMPANY_LIST { get; set; }
        //public List<STD_LIST_BE> BACK_FLIP_LIST { get; set; }
        public List<ADM_M028Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M024_P> Employees { get; set; }
        public List<ADM_M003_P> Locations { get; set; }
        public List<ADM_M037_P> Currency { get; set; }
        public List<ADM_M012_P> Country { get; set; }
        public List<ADM_M013_P> State { get; set; }
        public List<ADM_M025_P> Departments { get; set; }
        public List<ADM_M026_P> Designations { get; set; }
        public List<ADM_M028_B_P> PartyType { get; set; }
        public List<ADM_M028_A_P> Group { get; set; }
        public List<ACC_M003_P> ReconAccountList { get; set; }
        public ObservableCollection<ADM_M028_D> AddressEntity { get; set; }
        public ObservableCollection<ADM_M028_C> ContactEntity { get; set; }
        public List<ADM_M028> MasterEntity { get; set; }
        public List<ACC_M003_H> AccountingGroupList { get; set; }
        public List<RptParty> RptPartyList { get; set; }
        public List<ADM_M003_C_P> BusinessPlace { get; set; }
        public List<ACC_M013_A_P> TaxCategory { get; set; }
        public List<ACC_M013_B_P> AccountGroup { get; set; }
        public List<ADM_M028_J_P> BussGroupList { get; set; }
        public List<ACC_M007_P> PayTerms { get; set; }
        public List<COM_T003> AttachmentList { get; set; }
    }


}

