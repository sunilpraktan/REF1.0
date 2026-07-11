using Reflection.BusinessEntity.Finance;
using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class MIS_PaymentReports : ObjectBase
    {
        public string bill_doc { get; set; }
        public Nullable<System.DateTime> bill_date { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public Nullable<decimal> ass_value { get; set; }
        public Nullable<decimal> tax_amount { get; set; }
        public Nullable<decimal> invoice_amt { get; set; }
        public Nullable<decimal> net_pay_amt { get; set; }
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public Nullable<decimal> outstanding_amt { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<decimal> amount { get; set; }
        public string location_Id { get; set; }
        public string location { get; set; }
        public string EmpId { get; set; }
        public string seller_name { get; set; }
        public string ref_doc_no { get; set; }
        public string doc_type { get; set; }
        public string our_bank { get; set; }
        public string check_no { get; set; }
        public Nullable<decimal> goods_amt { get; set; }
        public Nullable<decimal> service_amt { get; set; }
        public Nullable<decimal> discount { get; set; }
        public Nullable<decimal> tds { get; set; }
        public string pay_method { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string City { get; set; }
        public string state_code { get; set; }
        public string country_code { get; set; }
        public string state_name { get; set; }
        public string country_name { get; set; }
        public string pincode { get; set; }
        public string doc_cat { get; set; }
        public string voucher_type { get; set; }
        public string po_no { get; set; }
        public Nullable<decimal> grand_total { get; set; }
        public Nullable<decimal> debit_amt { get; set; }
        public Nullable<decimal> credit_amt { get; set; }
        public Nullable<decimal> opening_amt { get; set; }
        public Nullable<decimal> closing_amt { get; set; }
        public Nullable<System.DateTime> post_date { get; set; }
        public string acc_type { get; set; }
        public string gl_code { get; set; }
        public string gl_name { get; set; }
        public string loc_curr_amt { get; set; }
        public string assign_no { get; set; }
        public string item_text { get; set; }
        public string unit_code { get; set; }
        public string qty_unit { get; set; }
        public string price_unit { get; set; }
        public string comp_code { get; set; }
        public string posting_period { get; set; }
        public string fin_year { get; set; }
        public Nullable<System.DateTime> ref_doc_date { get; set; }
        public string remark { get; set; }
        public string note { get; set; }
        public Nullable<decimal> bal { get; set; }
        public string sales_person { get; set; }
        public string site { get; set; }
        public Nullable<decimal> balance { get; set; }
        public Nullable<decimal> balance1 { get; set; }
        public Nullable<decimal> balance2 { get; set; }
        public Nullable<decimal> balance3 { get; set; }
        public Nullable<decimal> balance4 { get; set; }

    }

    public class ReportParameterFinance : ObjectBase
    {
        private Nullable<DateTime> _FromDate;
        public Nullable<DateTime> FromDate
        {
            get { return _FromDate; }
            set
            {
                _FromDate = value;
                RaisePropertyChanged("FromDate");
            }
        }

        private Nullable<DateTime> _ToDate;
        public Nullable<DateTime> ToDate
        {
            get { return _ToDate; }
            set
            {
                _ToDate = value;
                RaisePropertyChanged("ToDate");
            }
        }

        private Nullable<DateTime> _bank_date;
        public Nullable<DateTime> bank_date
        {
            get { return _bank_date; }
            set
            {
                _bank_date = value;
                RaisePropertyChanged("bank_date");
            }
        }

        private Nullable<DateTime> _bank_to_date;
        public Nullable<DateTime> bank_to_date
        {
            get { return _bank_to_date; }
            set
            {
                _bank_to_date = value;
                RaisePropertyChanged("bank_to_date");
            }
        }

        private string _ReportName;
        public string ReportName
        {
            get { return _ReportName; }
            set
            {
                _ReportName = value;
                RaisePropertyChanged("ReportName");
            }
        }

        private string _ReportCode;
        public string ReportCode
        {
            get { return _ReportCode; }
            set
            {
                _ReportCode = value;
                RaisePropertyChanged("ReportCode");
            }
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
        
        private bool _Customer;
        public bool Customer
        {
            get { return _Customer; }
            set
            {
                _Customer = value;
                RaisePropertyChanged("Customer");
            }
        }
        private bool _Supplier;
        public bool Supplier
        {
            get { return _Supplier; }
            set
            {
                _Supplier = value;
                RaisePropertyChanged("Supplier");
            }
        }

        private bool _transporter;
        public bool transporter
        {
            get { return _transporter; }
            set
            {
                _transporter = value;
                RaisePropertyChanged("transporter");
            }
        }


        private string _bank_code;
        public string bank_code
        {
            get { return _bank_code; }
            set
            {
                _bank_code = value;
                RaisePropertyChanged("bank_code");
            }
        }

        private string _bank_name;
        public string bank_name
        {
            get { return _bank_name; }
            set
            {
                _bank_name = value;
                RaisePropertyChanged("bank_name");
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
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("Location_Id");
            }
        }
        private string _LoctnNm;
        public string LoctnNm
        {
            get { return _LoctnNm; }
            set
            {
                _LoctnNm = value;
                RaisePropertyChanged("LoctnNm");
            }
        }

        private string _BalName;
        public string BalName
        {
            get { return _BalName; }
            set
            {
                _BalName = value;
                RaisePropertyChanged("BalName");
            }
        }

        private string _BalCode;
        public string BalCode
        {
            get { return _BalCode; }
            set
            {
                _BalCode = value;
                RaisePropertyChanged("BalCode");
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }
        private string _compName;
        public string CompName
        {
            get { return _compName; }
            set
            {
                _compName = value;
                RaisePropertyChanged("CompName");
            }
        }

        private string _EmpName;
        public string EmpName
        {
            get { return _EmpName; }
            set
            {
                _EmpName = value;
                RaisePropertyChanged("EmpName");
            }
        }

        private bool _active1;
        public bool active1
        {
            get { return _active1; }
            set
            {
                _active1 = value;
                RaisePropertyChanged("active1");
            }
        }

        private bool _active2;
        public bool active2
        {
            get { return _active2; }
            set
            {
                _active2 = value;
                RaisePropertyChanged("active2");
            }
        }

        private bool _active3;
        public bool active3
        {
            get { return _active3; }
            set
            {
                _active3 = value;
                RaisePropertyChanged("active3");
            }
        }

        private bool _active4;
        public bool active4
        {
            get { return _active4; }
            set
            {
                _active4 = value;
                RaisePropertyChanged("active4");
            }
        }

        private bool _active;
        public bool active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
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
        private Nullable<DateTime> _doc_date;
        public Nullable<DateTime> doc_date
        {
            get { return _doc_date; }
            set
            {
                _doc_date = value;
                RaisePropertyChanged("doc_date");
            }
        }

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

        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
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

    }
    public class MultipleContextMIS_FinanceReport
    {
        public List<ADM_M024_P> EmployeeList { get; set; }
        public List<ADM_M028_P> PartyDetails { get; set; }
        public List<ACC_M004_P> BankDetails { get; set; }
        public List<MIS_PaymentReports> MIS_PaymentReportsEntity { get; set; }
        public List<RptPaymentBalance> RptPaymentBalanceEntity { get; set; }
        public List<RptPaymentBalance1> RptPaymentBalanceEntity1 { get; set; }
        public List<RptPaymentBalance2> RptPaymentBalanceEntity2 { get; set; }
        public List<RptPaymentBalance3> RptPaymentBalanceEntity3 { get; set; }
        public List<RptPaymentBalance4> RptPaymentBalanceEntity4 { get; set; }
    }
}
