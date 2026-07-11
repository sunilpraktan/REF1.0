using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;



namespace Reflection.BusinessEntity
{//
    public class ADM_M002 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };


        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value;
                    RaisePropertyChanged("comp_code"); RaisePropertyChanged(" comp_code", ModelEntityUpdated);
                }
            }
        }

        private string _CompName;
        public string CompName
        {
            get { return _CompName; }
            set
            {
                if (_CompName != value)
                {
                    _CompName = value;
                    RaisePropertyChanged("CompName");
                    RaisePropertyChanged("CompName", ModelEntityUpdated);
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
      
        private string _ManuScop;
        public string ManuScop
        {
            get { return _ManuScop; }
            set
            {
                if (_ManuScop != value)
                {
                    _ManuScop = value;
                    RaisePropertyChanged("ManuScop");
                }
            }
        }
        private string _CompAbbre;
        public string CompAbbre
        {
            get { return _CompAbbre; }
            set
            {
                if (_CompAbbre != value)
                {
                    _CompAbbre = value;
                    RaisePropertyChanged("CompAbbre");
                    RaisePropertyChanged("CompAbbre", ModelEntityUpdated);
                }
            }
        }

        private byte[] _CompLogo;

        public byte[] CompLogo
        {
            get { return _CompLogo; }
            set
            {
                if (_CompLogo != value)
                {
                    _CompLogo = value; RaisePropertyChanged("CompLogo");
                }
            }
        }

        private string _Add1;
        public string Add1
        {
            get { return _Add1; }
            set
            {
                if (_Add1 != value)
                {
                    _Add1 = value;
                    RaisePropertyChanged("Add1");
                }
            }
        }
        private string _Add2;
        public string Add2
        {
            get { return _Add2; }
            set
            {
                if (_Add2 != value)
                {
                    _Add2 = value;
                    RaisePropertyChanged("Add2");
                }
            }
        }
        private string _City;
        public string City
        {
            get { return _City; }
            set
            {
                if (_City != value)
                {
                    _City = value;
                    RaisePropertyChanged("City");
                }
            }
        }
        private string _state_code;
        public string state_code
        {
            get { return _state_code; }
            set
            {
                if (_state_code != value)
                {
                    _state_code = value;
                    RaisePropertyChanged("state_code");
                }
            }
        }
        private string _country_code;
        public string country_code
        {
            get { return _country_code; }
            set
            {
                if (_country_code != value)
                {
                    _country_code = value;
                    RaisePropertyChanged("country_code");
                }
            }
        }
        private string _PinCode;

        public string PinCode
        {
            get { return _PinCode; }
            set
            {
                if (_PinCode != value)
                {
                    _PinCode = value;
                    RaisePropertyChanged("PinCode");
                }
            }
        }
        private string _PhOffi;

        public string PhOffi
        {
            get { return _PhOffi; }
            set
            {
                if (_PhOffi != value)
                {
                    _PhOffi = value;
                    RaisePropertyChanged("PhOffi");
                }
            }
        }
        private string _PhOffiExt;

        public string PhOffiExt
        {
            get { return _PhOffiExt; }
            set
            {
                if (_PhOffiExt != value)
                {
                    _PhOffiExt = value;
                    RaisePropertyChanged("PhOffiExt");
                }
            }
        }
        private string _FaxNo;
        public string FaxNo
        {
            get { return _FaxNo; }
            set
            {
                if (_FaxNo != value)
                {
                    _FaxNo = value;
                    RaisePropertyChanged("FaxNo");
                }
            }
        }
        private string _FaxNoExt;
        public string FaxNoExt
        {
            get { return _FaxNoExt; }
            set
            {
                if (_FaxNoExt != value)
                {
                    _FaxNoExt = value;
                    RaisePropertyChanged("FaxNoExt");
                }
            }
        }
        private string _MailId;
        public string MailId
        { get { return _MailId; } set {
                if (_MailId != value)
                {
                    _MailId = value; RaisePropertyChanged("MailId");
                }
            }
        }

        private string _WebSite;
        public string WebSite
        {
            get { return _WebSite; }
            set
            {
                if (_WebSite != value)
                {
                    _WebSite = value; RaisePropertyChanged("WebSite");
                }
            }
        }
        private string _ContPerNm;
        public string ContPerNm
        {
            get { return _ContPerNm; }
            set
            {
                if (_ContPerNm != value)
                {
                    _ContPerNm = value;
                    RaisePropertyChanged("ContPerNm");
                }
            }
        }
        private string _desig_code;
        public string desig_code { get { return _desig_code; } set {
                if (_desig_code != value)
                {
                    _desig_code = value; RaisePropertyChanged("desig_code");
                }
            }
        }
        private string _PrsnlMobNo;

        public string PrsnlMobNo
        {
            get { return _PrsnlMobNo; }
            set
            {
                if (_PrsnlMobNo != value)
                {
                    _PrsnlMobNo = value;
                    RaisePropertyChanged("PrsnlMobNo");
                }
            }
        }
        private string _Regino;
        public string Regino { get { return _Regino; } set {
                if (_Regino != value)
                {
                    _Regino = value; RaisePropertyChanged("Regino");
                }
            }
        }
        private string _RegiAdd1;
        public string RegiAdd1 { get { return _RegiAdd1; } set {
                if (_RegiAdd1 != value)
                {
                    _RegiAdd1 = value; RaisePropertyChanged("RegiAdd1");
                }
            }
        }
        private string _RegiAdd2;
        public string RegiAdd2 { get { return _RegiAdd2; }
            set {
                if (_RegiAdd2 != value)
                {
                    _RegiAdd2 = value; RaisePropertyChanged("RegiAdd2");
                }
            }
        }
        private string _RegiCity;
        public string RegiCity { get { return _RegiCity; }
            set {
                if (_RegiCity != value)
                {
                    _RegiCity = value; RaisePropertyChanged("RegiCity");
                }
            }
        }
        private string _reg_state;
        public string reg_state { get { return _reg_state; }
            set {
                if (_reg_state != value)
                {
                    _reg_state = value; RaisePropertyChanged("reg_state");
                }
            }
        }
        private string _reg_country;
        public string reg_country { get { return _reg_country; }
            set {
                if (_reg_country != value)
                {
                    _reg_country = value; RaisePropertyChanged("reg_country");
                }
            }
        }
        private string _RegiPinCod;
        public string RegiPinCod { get { return _RegiPinCod; }
            set {
                if (_RegiPinCod != value)
                {
                    _RegiPinCod = value; RaisePropertyChanged("RegiPinCod");
                }
            }
        }


        private string _CorporateNo;

        public string CorporateNo
        {
            get { return _CorporateNo; }
            set
            {
                if (_CorporateNo != value)
                {
                    _CorporateNo = value; RaisePropertyChanged("CorporateNo");
                }
            }
        }
        private string _CentralExNo;

        public string CentralExNo
        {
            get { return _CentralExNo; }
            set
            {
                if (_CentralExNo != value)
                {
                    _CentralExNo = value; RaisePropertyChanged("CentralExNo");
                }
            }
        }
        private DateTime? _CentralExDate;

        public DateTime? CentralExDate
        {
            get { return _CentralExDate; }
            set
            {
                if (_CentralExDate != value)
                {
                    _CentralExDate = value; RaisePropertyChanged(" CentralExDate");
                }
            }
        }
        private string _CSTNo;
        public string CSTNo { get { return _CSTNo; }
            set {
                if (_CSTNo != value)
                {
                    _CSTNo = value; RaisePropertyChanged("CSTNo");
                }
            }
        }
        private DateTime? _CSTDate;
        public DateTime? CSTDate { get { return _CSTDate; }
            set {
                if (_CSTDate != value)
                {
                    _CSTDate = value; RaisePropertyChanged("CSTDate");
                }
            }
        }
        private string _VATNo;
        public string VATNo { get { return _VATNo; }
            set {
                if (_VATNo != value)
                {
                    _VATNo = value; RaisePropertyChanged("VATNo");
                }
            }
        }
        private DateTime? _VATDate;

        public DateTime? VATDate { get { return _VATDate; }
            set {
                if (_VATDate != value)
                {
                    _VATDate = value; RaisePropertyChanged("VATDate");
                }
            }
        }
        private string _TNo;

        public string TNo { get { return _TNo; }
            set {
                if (_TNo != value)
                {
                    _TNo = value; RaisePropertyChanged("TNo");
                }
            }
        }
        private DateTime? _TDate;

        public DateTime? TDate { get { return _TDate; } set {
                if (_TDate != value)
                {
                    _TDate = value; RaisePropertyChanged("TDate");
                }
            }
        }
        private string _STNo;

        public string STNo { get { return _STNo; }
            set {
                if (_STNo != value)
                {
                    _STNo = value; RaisePropertyChanged("STNo");
                }
            }
        }
        private DateTime? _STDate;

        public DateTime? STDate { get { return _STDate; }
            set {
                if (_STDate != value)
                {
                    _STDate = value; RaisePropertyChanged("STDate");
                }
            }
        }
        private string _EccCode;

        public string EccCode
        {
            get { return _EccCode; }
            set
            {
                if (_EccCode != value)
                {
                    _EccCode = value; RaisePropertyChanged("EccCode");
                }
            }
        }
        private string _CINno;

        public string CINno
        {
            get { return _CINno; }
            set
            {
                if (_CINno != value)
                {
                    _CINno = value;
                    RaisePropertyChanged("CINno");
                }
            }
        }
        private string _Range;

        public string Range { get { return _Range; }
            set {
                if (_Range != value)
                {
                    _Range = value; RaisePropertyChanged("Range");
                }
            }
        }
        private string _CeRange;

        public string CeRange { get { return _CeRange; }
            set {
                if (_CeRange != value)
                {
                    _CeRange = value; RaisePropertyChanged("CeRange");
                }
            }
        }
        private string _RngOffAdd1;

        public string RngOffAdd1 { get { return _RngOffAdd1; }
            set {
                 if (_RngOffAdd1 != value)
                { 
                      _RngOffAdd1 = value; RaisePropertyChanged("RngOffAdd1");
                }
            }
        }
        private string _RngOffAdd2;

        public string RngOffAdd2 { get { return _RngOffAdd2; }
            set {
                if (_RngOffAdd2 != value)
                {
                    _RngOffAdd2 = value; RaisePropertyChanged("RngOffAdd2");
                }
            }
        }
        private string _Juri;

        public string Juri { get { return _Juri; }
            set {
                if (_RngOffAdd2 != value)
                {
                    _Juri = value; RaisePropertyChanged("Juri");
                }
            }
        }
        private string _Cmsnrt;

        public string Cmsnrt { get { return _Cmsnrt; }
            set {
                if (_Cmsnrt != value)
                {
                    _Cmsnrt = value; RaisePropertyChanged("Cmsnrt");
                }
            }
        }
        private string _CmsnrtAdd;

        public string CmsnrtAdd { get { return _CmsnrtAdd; }
            set {
                if (_CmsnrtAdd != value)
                {
                    _CmsnrtAdd = value; RaisePropertyChanged("CmsnrtAdd");
                }
            }
        }
        private string _PanNo;

        public string PanNo { get { return _PanNo; }
            set {
                if (_PanNo != value)
                {
                    _PanNo = value; RaisePropertyChanged("PanNo");
                }
            }
        }
        private string _div_code;
        public string div_code { get { return _div_code; }
            set {
                if (_div_code != value)
                {
                    _div_code = value; RaisePropertyChanged("div_code");
                }
            }
        }
        private string _PfAccNo;

        public string PfAccNo
        {
            get { return _PfAccNo; }
            set
            {
                if (_PfAccNo != value)
                {
                    _PfAccNo = value; RaisePropertyChanged("PfAccNo");
                }
            }
        }
        private string _LWelfNo;

        public string LWelfNo
        {
            get { return _LWelfNo; }
            set
            {
                if (_PfAccNo != value)
                {
                    _LWelfNo = value; RaisePropertyChanged("LWelfNo");
                }
            }
        }
        private string _p_term_code;

        public string p_term_code
        {
            get { return _p_term_code; }
            set
            {
                if (_p_term_code != value)
                {
                    _p_term_code = value; RaisePropertyChanged("p_term_code");
                }
            }
        }
        private string _FinYr;

        public string FinYr
        {
            get { return _FinYr; }
            set
            {
                if (_FinYr != value)
                {
                    _FinYr = value; RaisePropertyChanged("FinYr");
                }
            }
        }
        
        private string _add_by;
        public string add_by { get { return _add_by; }
            set {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }
        private DateTime? _add_date;

        public DateTime? add_date
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
        private string _editby;

        public string editby { get { return _editby; }
            set {
                if (_editby != value)
                {
                    _editby = value; RaisePropertyChanged("editby");
                }
            }
        }
        private DateTime? _edit_date;

        public DateTime? edit_date { get { return _edit_date; }
            set {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");
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

        private string _iec_code;

        public string iec_code
        {
            get { return _iec_code; }
            set
            {
                if (_iec_code != value)
                {
                    _iec_code = value;
                    RaisePropertyChanged("iec_code");
                }
            }
        }

        private string _ic_code;
        public string ic_code
        {
            get { return _ic_code; }
            set
            {
                if (_ic_code != value)
                {
                    _ic_code = value;
                    RaisePropertyChanged("ic_code");
                }
            }
        }

        private string _service_tax_no;
        public string service_tax_no
        {
            get { return _service_tax_no; }
            set
            {
                if (_service_tax_no != value)
                {
                    _service_tax_no = value;
                    RaisePropertyChanged("service_tax_no");
                }
            }
        }
        private string _gstinno;
        public string gstinno
        {
            get { return _gstinno; }
            set
            {
                if (_gstinno != value)
                {
                    _gstinno = value;
                    RaisePropertyChanged("gstinno");
                }
            }
        }
        private string _buss_place;
        public string buss_place
        {
            get { return _buss_place; }
            set
            {
                if (_buss_place != value)
                {
                    _buss_place = value;
                    RaisePropertyChanged("buss_place");
                }
            }
        }
        public DateTime? _gstindate;
        public DateTime? gstindate
        {
            get { return _gstindate; }

            set
            {
                if (_gstindate != value)
                {
                    _gstindate = value; RaisePropertyChanged("gstindate");
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
                    _lang_key = value;
                    RaisePropertyChanged("lang_key");
                }
            }
        }
        private string _CountryName;
        public string CountryName
        {
            get { return _CountryName; }
            set
            {
                if (_CountryName != value)
                {
                    _CountryName = value;
                    RaisePropertyChanged("CountryName");
                }
            }
        }
        private string _StateName;
        public string StateName
        {
            get { return _StateName; }
            set
            {
                if (_StateName != value)
                {
                    _StateName = value;
                    RaisePropertyChanged("StateName");
                }
            }
        }
        private string _GroupName;
        public string GroupName
        {
            get { return _GroupName; }
            set
            {
                if (_GroupName != value)
                {
                    _GroupName = value;
                    RaisePropertyChanged("GroupName");
                }
            }
        }
        private string _DesignationName;
        public string DesignationName
        {
            get { return _DesignationName; }
            set
            {
                if (_DesignationName != value)
                {
                    _DesignationName = value;
                    RaisePropertyChanged("DesignationName");
                }
            }
        }
        private string _EmployeeName;
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set
            {
                if (_EmployeeName != value)
                {
                    _EmployeeName = value;
                    RaisePropertyChanged("EmployeeName");
                }
            }
        }
        private string _regCountryName;
        public string regCountryName
        {
            get { return _regCountryName; }
            set
            {
                if (_regCountryName != value)
                {
                    _regCountryName = value;
                    RaisePropertyChanged("regCountryName");
                }
            }
        }
        private string _regStateName;
        public string regStateName
        {
            get { return _regStateName; }
            set
            {
                if (_regStateName != value)
                {
                    _regStateName = value;
                    RaisePropertyChanged("regStateName");

                }
            }
        }
        private string _bin_no;
        public string bin_no
        {
            get { return _bin_no; }
            set
            {
                if (_bin_no != value)
                {
                    _bin_no = value;
                    RaisePropertyChanged("bin_no");
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

        private string _curr_name;
        public string curr_name
        {
            get { return _curr_name; }
            set
            {
                if (_curr_name != value)
                {
                    _curr_name = value;
                    RaisePropertyChanged("curr_name");
                }
            }
        }
        private string _plc_name;
        public string plc_name
        {
            get { return _plc_name; }
            set
            {
                if (_plc_name != value)
                {
                    _plc_name = value;
                    RaisePropertyChanged("plc_name");
                }
            }
        }
        private string _bisness_state_code;
        public string bisness_state_code
        {
            get { return _bisness_state_code; }
            set
            {
                if (_bisness_state_code != value)
                {
                    _bisness_state_code = value;
                    RaisePropertyChanged("bisness_state_code");
                }
            }
        }

        private byte[] _CompLogo2;

        public byte[] CompLogo2
        {
            get { return _CompLogo2; }
            set
            {
                if (_CompLogo2 != value)
                {
                    _CompLogo2 = value; RaisePropertyChanged("CompLogo2");
                }
            }
        }

        private string _comp_name;
        public string comp_name
        {
            get { return _comp_name; }
            set
            {
                if (_comp_name != value)
                {
                    _comp_name = value;
                    RaisePropertyChanged("comp_name");
                }
            }
        }

        private string _abrv;
        public string abrv
        {
            get { return _abrv; }
            set
            {
                if (_abrv != value)
                {
                    _abrv = value;
                    RaisePropertyChanged("abrv");
                }
            }
        }
        public string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set
            {
                if (_location_id != value)
                {
                    _location_id = value;
                    RaisePropertyChanged("location_id");
                }
            }
        }

        public string back_color { get; set; }
        public string four_color { get; set; }
        public string font_family { get; set; }
        public string font_size { get; set; }
        public string ind_underline { get; set; }
        public string ind_italic { get; set; }
        public string tax_reg_no { get; set; }
        public string address { get; set; }
    }

    public class MultipleContext2
    {
        public List<ADM_M002> CompanyMaster { get; set; }
        public ObservableCollection<ADM_M012_P> Kntry { get; set; }
        public ObservableCollection<ADM_M013_P> Shtate { get; set; }
        public ObservableCollection<ADM_M001_PG> GroupCode { get; set; }
        public ObservableCollection<ADM_M024_P> Employee { get; set; }
        public ObservableCollection<ADM_M026_P> Designation { get; set; }
        public ObservableCollection<ADM_M037_P> Currency { get; set; }
        public List<ADM_M003_C_P> BusinessPlace { get; set; }
    }


}
