using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace Reflection.BusinessEntity
{
    public class Logistic_periodicReport : ObjectBase
    {

       
        public string inv_no { get; set; }
        public string InvoiceDate { get; set; }

        private string _Godown;
        public string Godown
        {
            get { return _Godown; }
            set
            {
                _Godown = value;
                RaisePropertyChanged("Godown");
            }
        }


        private string _Customer;
        public string Customer
        {
            get { return _Customer; }
            set
            {
                _Customer = value;
                RaisePropertyChanged("Customer");
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
                _supplier_id = value;
                RaisePropertyChanged("supplier_id");
            }
        }
        private Nullable<Int32> _warehouse_id;
        public Nullable<Int32> warehouse_id
        {
            get { return _warehouse_id; }
            set
            {
                _warehouse_id = value;
                RaisePropertyChanged("warehouse_id");
            }
        }

        public string CustItemCode { get; set; }
        public string CustItemDesc { get; set; }
       
        
    }
    public class periodicReportParameter : ObjectBase
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

        private Nullable<DateTime> _Todate;
        public Nullable<DateTime> Todate
        {
            get { return _Todate; }
            set
            {
                _Todate = value;
                RaisePropertyChanged("Todate");
            }
        }

        private string _ReportType;
        public string ReportType
        {
            get { return _ReportType; }
            set
            {
                _ReportType = value;
                RaisePropertyChanged("ReportType");
            }
        }
        private string _Godown;
        public string Godown
        {
            get { return _Godown; }
            set
            {
                _Godown = value;
                RaisePropertyChanged("Godown");
            }
        }


    }
    public class ItemPeriodicReportStock : ObjectBase
    {

        private Nullable<Int32> _item_id;
        public Nullable<Int32> item_id
        {
            get { return _item_id; }
            set
            {
                _item_id = value;
                RaisePropertyChanged("item_id");
            }
        }

        public string item_code { get; set; }
        public string item_name { get; set; }
        public Nullable<decimal> cur_qty { get; set; }
    }
    public class ADM_M028_PopUp_Report
    {
        public int Id { get; set; }
        [DisplayName("Party Name")]
        public string PartyNm { get; set; }
        public string EmailId { get; set; }
    }
    public class ADM_M028_PopUp_rpt
    {
        public string PartyId { get; set; }
        [DisplayName("Party Name")]
        public string PartyNm { get; set; }
        public string EmailId { get; set; }
    }
    public class ADM_M028_PopUpMasterItemData
    {
        public int ItemId { get; set; }

        [DisplayName("Customer Item Code")]
        public string CstmrItmCod { get; set; }

        [DisplayName("Customer Item Name")]
        public string CstmrItmDesc { get; set; }
    }
    public class ADM_M028_PopUpMasterItem
    {
        public string ItemCode { get; set; }

        [DisplayName("Customer Item Code")]
        public string CstmrItmCod { get; set; }

        [DisplayName("Customer Item Name")]
        public string CstmrItmDesc { get; set; }
    }
    public partial class CompanyData
    {

        public string comp_code { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }

        public string PhoneOffice { get; set; }
        public string FaxNo { get; set; }
        public string Mailid { get; set; }

    }
  

    public class MultipleContextLogistic_periodicReport
    {
        public ObservableCollection<Logistic_periodicReport> PeriodicReportMaster { get; set; }

        public List<Logistic_periodicReport> PeriodicReportGodownToPartyMaster { get; set; }

        public List<ADM_M028_PopUp_Report> partyDetails { get; set; }

         public List<ItemPeriodicReportStock> ItemStock { get; set; }

         public List<ADM_M003_PopUpwarehouse> LocationDetails { get; set; }


    }
}
