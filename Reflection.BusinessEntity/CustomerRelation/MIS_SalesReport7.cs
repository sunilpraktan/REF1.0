using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.CustomerRelation
{
    public class MIS_SalesReport7 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        public string inv_no { get; set; }
        public string InvoiceDate { get; set; }
        private string _act_desc;
        public string act_desc
        {
            get
            {
                return _act_desc;
            }

            set
            {
                if (_act_desc != value)
                {
                    _act_desc = value; RaisePropertyChanged("act_desc");
                }
            }
        }

        private string _Godown;
        public string Godown
        {
            get { return _Godown; }
            set
            {
                if (_Godown != value)
                {
                    _Godown = value;
                    RaisePropertyChanged("Godown");
                }
            }
        }
        private string _Customer;
        public string Customer
        {
            get { return _Customer; }
            set
            {
                if (_Customer != value)
                {
                    _Customer = value;
                    RaisePropertyChanged("Customer");
                }
            }
        }
        private string _add_by;
        public string add_by
        {
            get
            {
                return _add_by;
            }

            set
            {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }
        public string docket_no { get; set; }
        public Nullable<decimal> amount_untaxed { get; set; }
        public Nullable<decimal> amount_taxed { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string pono { get; set; }
        public string PODate { get; set; }
        public Nullable<decimal> DispatchQty { get; set; }
        public Nullable<decimal> INVQty { get; set; }
        public Nullable<decimal> balqty { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public Nullable<decimal> boxqty { get; set; }
        public string ItemCode { get; set; }
        public string item_name { get; set; }
        public string unit_name { get; set; }
        public string ackDate { get; set; }
        public Nullable<decimal> ReceivedQty { get; set; }
        public Nullable<decimal> BalanceQty1 { get; set; }
        private Nullable<Int32> _supplier_id;
        public Nullable<Int32> supplier_id
        {
            get { return _supplier_id; }
            set
            {
                if (_supplier_id != value)
                {
                    _supplier_id = value;
                    RaisePropertyChanged("supplier_id");
                }
            }
        }
        private string _warehouse_id;
        public string warehouse_id
        {
            get { return _warehouse_id; }
            set
            {
                if (_warehouse_id != value)
                {
                    _warehouse_id = value;
                    RaisePropertyChanged("warehouse_id");
                }
            }
        }

        private string _CustItemCode;
        public string CustItemCode
        {
            get { return _CustItemCode; }
            set
            {
                if (_CustItemCode != value)
                {
                    _CustItemCode = value;
                    RaisePropertyChanged("CustItemCode");
                }
            }
        }

        private string _CustItemDesc;
        public string CustItemDesc
        {
            get { return _CustItemDesc; }
            set
            {
                if (_CustItemDesc != value)
                {
                    _CustItemDesc = value;
                    RaisePropertyChanged("CustItemDesc");
                }
            }
        }

    }
    public class MISReportParameter : ObjectBase
    {
        private Nullable<DateTime> _FromDate;
        public Nullable<DateTime> FromDate
        {
            get { return _FromDate; }
            set
            {
                if (_FromDate != value)
                {
                    _FromDate = value;
                    RaisePropertyChanged("FromDate");
                }
            }
        }
        private Nullable<DateTime> _Todate;
        public Nullable<DateTime> Todate
        {
            get { return _Todate; }
            set
            {
                if (_Todate != value)
                {
                    _Todate = value;
                    RaisePropertyChanged("Todate");
                }
            }
        }
        //act_desc
        private string _ReportType;
        public string ReportType
        {
            get { return _ReportType; }
            set
            {
                if (_ReportType != value)
                {
                    _ReportType = value;
                    RaisePropertyChanged("ReportType");
                }
            }
        }
        private string _Godown;
        public string Godown
        {
            get { return _Godown; }
            set
            {
                if (_Godown != value)
                {
                    _Godown = value;
                    RaisePropertyChanged("Godown");
                }
            }
        }
    }
    public class MultipleContextMISReports7
        {
            public List<ADM_M028_P> partyDetails { get; set; }
            public List<ADM_M022_P> ItemDetails { get; set; }
            public List<ADM_M024_P> Employee { get; set; }
            public List<ADM_M001_A_P> SalesOrg { get; set; }
            public List<ADM_M001_H_P> SalesGroup { get; set; }
            public List<MIS_CRM_SalesEntity7> RptMIS_CRMSales_List { get; set; }

            public List<ADM_M028_B_P> PartyType;

        }
    
}
