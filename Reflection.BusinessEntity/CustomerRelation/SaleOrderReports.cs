using System;
using System.Collections.Generic;


namespace Reflection.BusinessEntity
{
    public class SaleOrderReports : ObjectBase
    {
        public string inv_no { get; set; }
        public string InvoiceDate { get; set; }

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

        public string item_code { get; set; }
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

        public string CustItemCode { get; set; }
        public string CustItemDesc { get; set; }


    }

    public class MultipleContextPeriodicReport
    {
        public List<BalanceOFClosedPO> PeriodicReportMaster { get; set; }

        public List<ADM_M028_PopUp_Report> partyDetails { get; set; }

        public List<ItemPeriodicReportStock> ItemStock { get; set; }

        public List<ADM_M028_PopUpMasterItemData> ItemDetails { get; set; }

        //public List<CompanyData> companyDetails { get; set; }
    }
}
