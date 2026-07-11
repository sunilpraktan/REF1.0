using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;

namespace Reflection.Modules.CustomerRelation.ViewModels
{  //test  
    public class SEL_T001_VM_StockTransfer //: WindowViewModel<SEL_T001>, INotifyPropertyChanged
    {
       // bool blNew = true;
       // WebServiceRepository<SEL_T001> repository = new WebServiceRepository<SEL_T001>();
       // WebServiceRepository<MultipleContext_SEL_T001> repositoryM = new WebServiceRepository<MultipleContext_SEL_T001>();
       // MultipleContext_SEL_T001 MCTemp = new MultipleContext_SEL_T001();
       // MultipleContext_SEL_T001 MCParty = new MultipleContext_SEL_T001();

       // private ICollectionView _dataGridCollection;
       // private string _filterString;

       // private string _filterStringLoctn;
       // private string _filterStringEmp;
       // private string _filterStringParty;
       // private string _filterStringAdd;
       // private string _filterStringBuyer;
       // private string _filterStringItems;
       // private string _filterStringuom;
       // private string _filterStringTax;
       // private string _filterString_tax;
       // private string _filterString_payterms;
       // private string _filterString_Buyer;
       // private string _filterStringvalidatedby;

       // private string _partyemail;
       // public string partyemail
       // {
       //     get { return _partyemail; }
       //     set
       //     {
       //         _partyemail = value;
       //         RaisePropertychanged("partyemail");
       //     }
       // }
       // private string _buyeremail;
       // public string buyeremail
       // {
       //     get { return _buyeremail; }
       //     set
       //     {
       //         _buyeremail = value;
       //         RaisePropertychanged("buyeremail");
       //     }
       // }


       // private int _dgSelectedIndex;
       // private Dictionary<string, object> _items;
       // private Dictionary<string, object> _selectedItems;

       // #region Methods
       // public event PropertyChangedEventHandler PropertyChanged;
       // public void RaisePropertychanged(string propertyName)
       // {
       //     // take a copy to prevent thread issues
       //     PropertyChangedEventHandler handler = PropertyChanged;
       //     if (handler != null)
       //     {
       //         handler(this, new PropertyChangedEventArgs(propertyName));
       //     }
       // }

       // #endregion

       // #region ICollection
       // public ICollectionView DataGridCollection
       // {
       //     get { return _dataGridCollection; }
       //     set { _dataGridCollection = value; RaisePropertychanged("DataGridCollection"); }
       // }
       // private ICollectionView _LoctnCollection;
       // public ICollectionView LoctnCollection
       // {
       //     get { return _LoctnCollection; }
       //     set
       //     {
       //         _LoctnCollection = value;

       //         RaisePropertychanged("LoctnCollection");
       //     }
       // }
       // private ICollectionView _EmpCollection;
       // public ICollectionView EmpCollection
       // {
       //     get { return _EmpCollection; }
       //     set
       //     {
       //         _EmpCollection = value;

       //         RaisePropertychanged("EmpCollection");
       //     }
       // }

       // private ICollectionView _PartyCollection;
       // public ICollectionView PartyCollection
       // {
       //     get { return _PartyCollection; }
       //     set
       //     {
       //         _PartyCollection = value;
       //         RaisePropertychanged("PartyCollection");
       //     }
       // }

       // private ICollectionView _ShipPartyCollection;
       // public ICollectionView ShipPartyCollection
       // {
       //     get { return _ShipPartyCollection; }
       //     set
       //     {
       //         _ShipPartyCollection = value;
       //         RaisePropertychanged("ShipPartyCollection");
       //     }
       // }

       // private ICollectionView _JournalCollection;
       // public ICollectionView JournalCollection
       // {
       //     get { return _JournalCollection; }
       //     set
       //     {
       //         _JournalCollection = value;

       //         RaisePropertychanged("JournalCollection");
       //     }
       // }

       // private ICollectionView _InvcAddCollection;
       // public ICollectionView InvcAddCollection
       // {
       //     get { return _InvcAddCollection; }
       //     set
       //     {
       //         _InvcAddCollection = value;

       //         RaisePropertychanged("InvcAddCollection");
       //     }
       // }
       // private ICollectionView _DelAddCollection;
       // public ICollectionView DelAddCollection
       // {
       //     get { return _DelAddCollection; }
       //     set
       //     {
       //         _DelAddCollection = value;

       //         RaisePropertychanged("DelAddCollection");
       //     }
       // }
       // private ICollectionView _BuyerCollection;
       // public ICollectionView BuyerCollection
       // {
       //     get { return _BuyerCollection; }
       //     set
       //     {
       //         _BuyerCollection = value;

       //         RaisePropertychanged("BuyerCollection");
       //     }
       // }

       // private ICollectionView _ValidatedbyCollection;
       // public ICollectionView ValidatedbyCollection
       // {
       //     get { return _ValidatedbyCollection; }
       //     set
       //     {
       //         _ValidatedbyCollection = value;
       //         RaisePropertychanged("ValidatedbyCollection");
       //     }
       // }
       // private ICollectionView _ItemsCollection;
       // public ICollectionView ItemsCollection
       // {
       //     get { return _ItemsCollection; }
       //     set
       //     {
       //         _ItemsCollection = value;

       //         RaisePropertychanged("ItemsCollection");
       //     }
       // }

       // private ICollectionView _uomCollection;
       // public ICollectionView uomCollection
       // {
       //     get { return _uomCollection; }
       //     set
       //     {
       //         _uomCollection = value;

       //         RaisePropertychanged("uomCollection");
       //     }
       // }
       // private ICollectionView _PaytmCollection;
       // public ICollectionView PaytmCollection
       // {
       //     get { return _PaytmCollection; }
       //     set
       //     {
       //         _PaytmCollection = value;

       //         RaisePropertychanged("PaytmCollection");
       //     }
       // }

       // private ICollectionView _validatedByCollection;
       // public ICollectionView validatedByCollection
       // {
       //     get { return _validatedByCollection; }
       //     set { _validatedByCollection = value; RaisePropertychanged("validatedByCollection"); }
       // }
       // private ICollectionView _TaxCollection;
       // public ICollectionView TaxCollection
       // {
       //     get { return _TaxCollection; }
       //     set
       //     {
       //         _TaxCollection = value;

       //         RaisePropertychanged("TaxCollection");
       //     }
       // }

       // private ICollectionView _dgPOItemsForParameterval;
       // public ICollectionView dgPOItemsForParameterval
       // {
       //     get { return _dgPOItemsForParameterval; }
       //     set
       //     {
       //         _dgPOItemsForParameterval = value;
       //         RaisePropertychanged("dgPOItemsForParameterval");
       //     }
       // }

       // private ICollectionView _TotalParameterCollection;
       // public ICollectionView TotalParameterCollection
       // {
       //     get { return _TotalParameterCollection; }
       //     set
       //     {
       //         _TotalParameterCollection = value;
       //         RaisePropertychanged("TotalParameterCollection")
       //        ;
       //     }
       // }

       // private ICollectionView _dgPOItemsFortaxval;
       // public ICollectionView dgPOItemsFortaxval
       // {
       //     get { return _dgPOItemsFortaxval; }
       //     set
       //     {
       //         _dgPOItemsFortaxval = value;
       //         RaisePropertychanged("dgPOItemsFortaxval");
       //     }
       // }

       // //
       // private ICollectionView _doc_typeCollection;
       // public ICollectionView doc_typeCollection
       // {
       //     get { return _doc_typeCollection; }
       //     set
       //     {
       //         _doc_typeCollection = value;
       //         RaisePropertychanged("doc_typeCollection");
       //     }
       // }
       // private ICollectionView _doc_CategoryCollection;
       // public ICollectionView doc_CategoryCollection
       // {
       //     get { return _doc_CategoryCollection; }
       //     set
       //     {
       //         _doc_CategoryCollection = value;
       //         RaisePropertychanged("doc_CategoryCollection");
       //     }
       // }

       // private ICollectionView _doc_SubCategoryCollection;
       // public ICollectionView doc_SubCategoryCollection
       // {
       //     get { return _doc_SubCategoryCollection; }
       //     set
       //     {
       //         _doc_SubCategoryCollection = value;
       //         RaisePropertychanged("doc_SubCategoryCollection");
       //     }
       // }
       // private ICollectionView _currencyCollection;
       // public ICollectionView currencyCollection
       // {
       //     get { return _currencyCollection; }
       //     set
       //     {
       //         _currencyCollection = value;
       //         RaisePropertychanged("currencyCollection");
       //     }
       // }
       // private ICollectionView _reference_docCollection;
       // public ICollectionView reference_docCollection
       // {
       //     get { return _reference_docCollection; }
       //     set
       //     {
       //         _reference_docCollection = value;
       //         RaisePropertychanged("reference_docCollection");
       //     }
       // }
       // private ICollectionView _sales_orgCollection;
       // public ICollectionView sales_orgCollection
       // {
       //     get { return _sales_orgCollection; }
       //     set
       //     {
       //         _sales_orgCollection = value;
       //         RaisePropertychanged("sales_orgCollection");
       //     }
       // }
       // private ICollectionView _distribution_channelCollection;
       // public ICollectionView distribution_channelCollection
       // {
       //     get { return _distribution_channelCollection; }
       //     set
       //     {
       //         _distribution_channelCollection = value;
       //         RaisePropertychanged("distribution_channelCollection");
       //     }
       // }
       // private ICollectionView _sales_divisionCollection;
       // public ICollectionView sales_divisionCollection
       // {
       //     get { return _sales_divisionCollection; }
       //     set
       //     {
       //         _sales_divisionCollection = value;
       //         RaisePropertychanged("sales_divisionCollection");
       //     }
       // }
       // private ICollectionView _sales_personCollection;
       // public ICollectionView sales_personCollection
       // {
       //     get { return _sales_personCollection; }
       //     set
       //     {
       //         _sales_personCollection = value;
       //         RaisePropertychanged("sales_personCollection");
       //     }
       // }
       // private ICollectionView _sales_officeCollection;
       // public ICollectionView sales_officeCollection
       // {
       //     get { return _sales_officeCollection; }
       //     set
       //     {
       //         _sales_officeCollection = value;
       //         RaisePropertychanged("sales_officeCollection");
       //     }
       // }
       // private ICollectionView _sales_groupCollection;
       // public ICollectionView sales_groupCollection
       // {
       //     get { return _sales_groupCollection; }
       //     set
       //     {
       //         _sales_groupCollection = value;
       //         RaisePropertychanged("sales_groupCollection");
       //     }
       // }

       // private ICollectionView _cost_centerCollection;
       // public ICollectionView cost_centerCollection
       // {
       //     get { return _cost_centerCollection; }
       //     set
       //     {
       //         _cost_centerCollection = value;
       //         RaisePropertychanged("cost_centerCollection");
       //     }
       // }
       // private ICollectionView _profit_centerCollection;
       // public ICollectionView profit_centerCollection
       // {
       //     get { return _profit_centerCollection; }
       //     set
       //     {
       //         _profit_centerCollection = value;
       //         RaisePropertychanged("profit_centerCollection");
       //     }
       // }


       // private ICollectionView _stock_locationCollection;
       // public ICollectionView stock_locationCollection
       // {
       //     get { return _stock_locationCollection; }
       //     set
       //     {
       //         _stock_locationCollection = value;
       //         RaisePropertychanged("stock_locationCollection");
       //     }
       // }

       // private ICollectionView _warehouse_locationCollection;
       // public ICollectionView warehouse_locationCollection
       // {
       //     get { return _warehouse_locationCollection; }
       //     set
       //     {
       //         _warehouse_locationCollection = value;
       //         RaisePropertychanged("warehouse_locationCollection");
       //     }
       // }

       // private int _selectedTabIndex;
       // public int SelectedTabIndex
       // {
       //     get { return _selectedTabIndex; }
       //     set
       //     {
       //         if (_selectedTabIndex != value)
       //         {
       //             _selectedTabIndex = value;
       //             RaisePropertychanged("SelectedTabIndex");

       //             if (SelectedTabIndex == 2)
       //             {
       //                 LoadSelectedTab();
       //             }

       //         }
       //     }
       // }
       // #endregion

       // #region RelayCommand
       // public RelayCommand<IList> ValidatedBy_SelectionChanged
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandTotalTax
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<object> TaxPopupCommand
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> ParameterPopupCommand
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> DeleteItemCommand
       // {
       //     get;
       //     private set;
       // }

       // public RelayCommand<IList> TaxChangedCommand
       // {
       //     get;
       //     private set;
       // }

       // public RelayCommand<IList> ParameterPopupCommand1
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> ScheduleCellChangedCommand
       // {
       //     get;
       //     private set;
       // }


       // public RelayCommand<IList> CheckedCommand
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionCommand_reference_doc
       // {
       //     get;
       //     private set;
       // }

       // public RelayCommand<IList> ParameterNameCommand
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionCommand_doc_type
       // {
       //     get;
       //     private set;
       // }

       // public RelayCommand<IList> SelectionChangedCommandTax
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommand
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandLoctn
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandEmp
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandParty
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandShipToParty
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandPartyTo
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandDelAdd
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<Boolean> ActiveCommand
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandInvicAdd
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandProfitCentre
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectedCammand_sales_group
       // {
       //     get;
       //     private set;
       // }

       // public RelayCommand<IList> SelectionChangedCommandCostCentre
       // {
       //     get;
       //     private set;
       // }

       // public RelayCommand<IList> SelectedCommand_sales_division
       // {
       //     get;
       //     private set;
       // }

       // public RelayCommand<IList> SelectedCammand_sales_person
       // {
       //     get;
       //     private set;
       // }

       // public RelayCommand<IList> SelectedCammand_distribution_channel
       // {
       //     get;
       //     private set;
       // }

       // public RelayCommand<IList> SelectedCommand_itemcategory
       // {
       //     get;
       //     private set;
       // }


       // public RelayCommand<IList> SelectedCammand_sales_office
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandCurrency
       // {
       //     get;
       //     private set;
       // }
       // private RelayCommand _buttonInvoiceCommand;
       // public RelayCommand ButtonInvoiceCommand
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand ButtonProductCommand
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandBuyer
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandItems
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommanduom
       // {
       //     get;
       //     private set;
       // }
       // private RelayCommand _buttonClickCommand;
       // public RelayCommand ButtonClickCommand
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandstoragecollection
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandWarehousecollection
       // {
       //     get;
       //     private set;
       // }

       // public RelayCommand<IList> CollectionChangedMethod
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandJournal
       // {
       //     get;
       //     private set;
       // }


       // public RelayCommand<IList> SelectionChangedCommandPayTm
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandSOdetails
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandForTax
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandStorageLocation
       // {
       //     get;
       //     private set;
       // }

       // public RelayCommand<IList> SelectionChangedCommandDestinationWarehouse
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandweightuom
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandVolumetuom
       // {
       //     get;
       //     private set;
       // }


       // public RelayCommand<IList> SelectionChangedCommandQuotn
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectedCommand_sales_org
       // {
       //     get;
       //     private set;
       // }

       // public RelayCommand<IList> CellChangedCommand
       // {
       //     get;
       //     private set;
       // }

       // public RelayCommand TestCommand { get; private set; }
       // public RelayCommand<IList> SelectionChangedCommandItemfordelivery
       // {
       //     get;
       //     private set;
       // }

       // #endregion

       // #region SEL_T001
       // private List<SEL_T001> _SelectedList;
       // public List<SEL_T001> SelectedList
       // {
       //     get { return _SelectedList; }
       //     set
       //     {
       //         if (_SelectedList != value)
       //         {
       //             _SelectedList = value;

       //             //if (PropertyChanged != null)
       //             //{
       //             RaisePropertychanged("SelectedList");

       //             //}
       //         }
       //     }
       // }
       // private ObservableCollection<Inquiry_PopUp> _EnquiryList;
       // public ObservableCollection<Inquiry_PopUp> EnquiryList
       // {
       //     get { return _EnquiryList; }
       //     set
       //     {
       //         _EnquiryList = value;
       //         RaisePropertychanged("EnquiryList");
       //     }
       // }

       // private ObservableCollection<SEL_T002_B> _EnquiryschList;
       // public ObservableCollection<SEL_T002_B> EnquiryschList
       // {
       //     get { return _EnquiryschList; }
       //     set
       //     {
       //         _EnquiryschList = value;
       //         RaisePropertychanged("EnquiryschList");
       //     }
       // }



       // private SEL_T001 _SelectedSEL_T001;
       // public SEL_T001 SelectedSEL_T001
       // {
       //     get
       //     {
       //         this.ErrorExist = _SelectedSEL_T001.HasErrors;
       //         return _SelectedSEL_T001;
       //     }
       //     set
       //     {
       //         if (_SelectedSEL_T001 != value)
       //         {
       //             _SelectedSEL_T001 = value;
       //             this.ErrorExist = _SelectedSEL_T001.HasErrors;
       //             RaisePropertychanged("SelectedSEL_T001");
       //             value.BeginEdit();
       //         }
       //     }
       // }
       // #endregion

       // #region SEL_T001_B

       // private ObservableCollection<SalesOrder_deliveryschedule> _dgPOschedule;
       // public ObservableCollection<SalesOrder_deliveryschedule> dgPOschedule
       // {
       //     get { return _dgPOschedule; }
       //     set
       //     {
       //         if (_dgPOschedule != value)
       //         {
       //             _dgPOschedule = value;

       //             RaisePropertychanged("dgPOschedule");

       //         }
       //     }
       // }
       // private ObservableCollection<SEL_T001_Popup> _dgrefdocno;
       // public ObservableCollection<SEL_T001_Popup> dgrefdocno
       // {
       //     get { return _dgrefdocno; }
       //     set
       //     {
       //         if (_dgrefdocno != value)
       //         {
       //             _dgrefdocno = value;

       //             RaisePropertychanged("dgrefdocno");

       //         }
       //     }
       // }




       // private ObservableCollection<ACC_M019_Popup> _dgcost_center;
       // public ObservableCollection<ACC_M019_Popup> dgcost_center
       // {
       //     get { return _dgcost_center; }
       //     set
       //     {
       //         if (_dgcost_center != value)
       //         {
       //             _dgcost_center = value;

       //             RaisePropertychanged("dgcost_center");

       //         }
       //     }
       // }



       // private ObservableCollection<PurchaseOrder_SingleReport> _dgReportMaster;
       // public ObservableCollection<PurchaseOrder_SingleReport> dgReportMaster
       // {
       //     get { return _dgReportMaster; }
       //     set
       //     {
       //         if (_dgReportMaster != value)
       //         {
       //             _dgReportMaster = value;


       //             RaisePropertychanged("dgReportMaster");

       //         }
       //     }
       // }


       // private ObservableCollection<SEL_T001_C> _dgPOTaxValues;
       // public ObservableCollection<SEL_T001_C> dgPOTaxValues
       // {
       //     get
       //     {
       //         return _dgPOTaxValues;

       //     }
       //     set
       //     {
       //         if (_dgPOTaxValues != value)
       //         {

       //             _dgPOTaxValues = value;

       //             RaisePropertychanged("dgPOTaxValues");


       //         }
       //     }
       // }





       // private ObservableCollection<ACC_M013_P> _dgPOTaxAccount;
       // public ObservableCollection<ACC_M013_P> dgPOTaxAccount
       // {
       //     get
       //     {
       //         return _dgPOTaxAccount;

       //     }
       //     set
       //     {
       //         if (_dgPOTaxAccount != value)
       //         {

       //             _dgPOTaxAccount = value;

       //             RaisePropertychanged("dgPOTaxAccount");


       //         }
       //     }
       // }


       // private ObservableCollection<SEL_T002_B> _dgPOdeliveryschedule;
       // public ObservableCollection<SEL_T002_B> dgPOdeliveryschedule
       // {
       //     get
       //     {
       //         return _dgPOdeliveryschedule;

       //     }
       //     set
       //     {
       //         if (_dgPOdeliveryschedule != value)
       //         {

       //             _dgPOdeliveryschedule = value;

       //             RaisePropertychanged("dgPOdeliveryschedule");


       //         }
       //     }
       // }


       // private ObservableCollection<SEL_T001_C> _dgPOTotalTaxValues;
       // public ObservableCollection<SEL_T001_C> dgPOTotalTaxValues
       // {
       //     get
       //     {
       //         return _dgPOTotalTaxValues;
       //     }
       //     set
       //     {
       //         if (_dgPOTotalTaxValues != value)
       //         {

       //             _dgPOTotalTaxValues = value;
       //             RaisePropertychanged("dgPOTotalTaxValues");

       //         }
       //     }
       // }
       // private ObservableCollection<SEL_T001_C> _dgPOTaxValues1;
       // public ObservableCollection<SEL_T001_C> dgPOTaxValues1
       // {
       //     get
       //     {
       //         return _dgPOTaxValues1;

       //     }
       //     set
       //     {
       //         if (_dgPOTaxValues1 != value)
       //         {

       //             _dgPOTaxValues1 = value;

       //             RaisePropertychanged("dgPOTaxValues1");

       //         }
       //     }
       // }
       // private ObservableCollection<SEL_T001_C> _dgPOTaxValues2;
       // public ObservableCollection<SEL_T001_C> dgPOTaxValues2
       // {
       //     get
       //     {
       //         return _dgPOTaxValues2;

       //     }
       //     set
       //     {
       //         if (_dgPOTaxValues2 != value)
       //         {

       //             _dgPOTaxValues2 = value;

       //             RaisePropertychanged("dgPOTaxValues2");

       //         }
       //     }
       // }
       // private ObservableCollection<SEL_T001_C> _dgPOTaxValues3;
       // public ObservableCollection<SEL_T001_C> dgPOTaxValues3
       // {
       //     get
       //     {
       //         return _dgPOTaxValues3;

       //     }
       //     set
       //     {
       //         if (_dgPOTaxValues3 != value)
       //         {

       //             _dgPOTaxValues3 = value;
       //             RaisePropertychanged("dgPOTaxValues3");

       //         }
       //     }
       // }


       // private static ObservableCollection<SEL_T001_B> _SO_Dtails = new ObservableCollection<SEL_T001_B>();
       // public ObservableCollection<SEL_T001_B> SO_Dtails
       // {
       //     get { return _SO_Dtails; }
       //     set
       //     {
       //         if (_SO_Dtails != value)
       //         {
       //             _SO_Dtails = value;
       //             RaisePropertychanged("SO_Dtails");
       //         }
       //     }
       // }

       // private ObservableCollection<SEL_T002> _dgscheduledmaster;
       // public ObservableCollection<SEL_T002> dgscheduledmaster
       // {
       //     get
       //     {

       //         return _dgscheduledmaster;
       //     }
       //     set
       //     {
       //         if (_dgscheduledmaster != value)
       //         {
       //             _dgscheduledmaster = value;
       //             RaisePropertychanged("dgscheduledmaster");

       //         }
       //     }
       // }
       // private ObservableCollection<ADM_M034_PopUp> _ParamList;
       // public ObservableCollection<ADM_M034_PopUp> ParamList
       // {
       //     get { return _ParamList; }
       //     set
       //     {
       //         _ParamList = value;
       //         RaisePropertychanged("ParamList");
       //     }
       // }

       // private ObservableCollection<ADM_M030_P> _ParamValuesList;//new
       // public ObservableCollection<ADM_M030_P> ParamValuesList
       // {
       //     get { return _ParamValuesList; }
       //     set
       //     {
       //         _ParamValuesList = value;
       //         RaisePropertychanged("ParamValuesList");
       //     }
       // }//new




       // private ObservableCollection<ADM_M030_P> _ParamitemList;
       // public ObservableCollection<ADM_M030_P> ParamitemList
       // {
       //     get { return _ParamitemList; }
       //     set
       //     {
       //         _ParamitemList = value;
       //         RaisePropertychanged("ParamitemList");
       //     }
       // }
       // private ObservableCollection<ADM_M030_P> _ParamitemList1;
       // public ObservableCollection<ADM_M030_P> ParamitemList1
       // {
       //     get { return _ParamitemList1; }
       //     set
       //     {
       //         _ParamitemList1 = value;
       //         RaisePropertychanged("ParamitemList1");
       //     }
       // }
       // private ObservableCollection<ADM_M030_P> _ParamclearList;
       // public ObservableCollection<ADM_M030_P> ParamclearList
       // {
       //     get { return _ParamclearList; }
       //     set
       //     {
       //         _ParamclearList = value;
       //         RaisePropertychanged("ParamclearList");
       //     }
       // }

       // List<ADM_M030_P> _FluteList = new List<ADM_M030_P>();
       // public List<ADM_M030_P> FluteList
       // {
       //     get { return _FluteList; }
       //     set
       //     {
       //         if (_FluteList != value)
       //         {
       //             _FluteList = value;

       //             RaisePropertychanged("FluteList");
       //         }
       //     }
       // }
       // private List<ACC_M013_PopUp> _SelectedChildTaxList;
       // public List<ACC_M013_PopUp> SelectedChildTaxList
       // {
       //     get { return _SelectedChildTaxList; }
       //     set
       //     {
       //         if (_SelectedTaxList != value)
       //         {
       //             _SelectedChildTaxList = value;
       //             RaisePropertychanged("SelectedChildTaxList");

       //         }
       //     }
       // }

       // public SEL_T001_B _SelectedSEL_T001_B { get; private set; }
       // public SEL_T001_B SelectedSEL_T001_B
       // {
       //     get { return _SelectedSEL_T001_B; }
       //     set
       //     {
       //         if (_SelectedSEL_T001_B != value)
       //         {
       //             _SelectedSEL_T001_B = value;
       //             RaisePropertychanged("SelectedSEL_T001_B");
       //             // value.BeginEdit();
       //         }
       //     }
       // }
       // private List<SEL_T001_B> _SelectedSEL_T001_B_List;
       // public List<SEL_T001_B> SelectedSEL_T001_B_List
       // {
       //     get
       //     {
       //         return _SelectedSEL_T001_B_List;
       //     }
       //     set
       //     {
       //         _SelectedSEL_T001_B_List = value;
       //         RaisePropertychanged("SelectedSEL_T001_B_List");
       //     }
       // }

       // private ICollectionView _ParameterCollection;
       // public ICollectionView ParameterCollection
       // {
       //     get { return _ParameterCollection; }
       //     set
       //     {
       //         _ParameterCollection = value;
       //         RaisePropertychanged("ParameterCollection")
       //        ;
       //     }
       // }

       // #endregion

       // #region SEL_T001_C
       // private static ObservableCollection<SEL_T001_C> _Tax_Dtails = new ObservableCollection<SEL_T001_C>();
       // public ObservableCollection<SEL_T001_C> Tax_Dtails
       // {
       //     get { return _Tax_Dtails; }
       //     set
       //     {
       //         if (_Tax_Dtails != value)
       //         {
       //             _Tax_Dtails = value;

       //             RaisePropertychanged("Tax_Dtails");
       //         }
       //     }
       // }
       // public SEL_T001_C _SelectedSEL_T001_C { get; private set; }
       // public SEL_T001_C SelectedSEL_T001_C
       // {
       //     get { return _SelectedSEL_T001_C; }
       //     set
       //     {
       //         if (_SelectedSEL_T001_C != value)
       //         {
       //             _SelectedSEL_T001_C = value;
       //             RaisePropertychanged("SelectedSEL_T001_C");
       //             // value.BeginEdit();
       //         }
       //     }
       // }

       // #endregion

       // #region ADM_M003_PopUp
       // public ADM_M003_PopUp _SelectedLoctnDtls { get; private set; }
       // public ADM_M003_PopUp SelectedLoctnDtls
       // {
       //     get { return _SelectedLoctnDtls; }
       //     set
       //     {
       //         if (_SelectedLoctnDtls != value)
       //         {
       //             _SelectedLoctnDtls = value;
       //             RaisePropertychanged("SelectedLoctnDtls");
       //         }
       //     }
       // }
       // private ObservableCollection<ADM_M003_PopUp> _LoctnList;
       // public ObservableCollection<ADM_M003_PopUp> LoctnList
       // {
       //     get { return _LoctnList; }
       //     set
       //     {
       //         _LoctnList = value;
       //         RaisePropertychanged("LoctnList");
       //     }
       // }

       // private List<ADM_M003_PopUp> _SelectedLoctnList;
       // public List<ADM_M003_PopUp> SelectedLoctnList
       // {
       //     get { return _SelectedLoctnList; }
       //     set
       //     {
       //         if (_SelectedLoctnList != value)
       //         {
       //             _SelectedLoctnList = value;

       //             //if (PropertyChanged != null)
       //             //{
       //             RaisePropertychanged("SelectedLoctnList");
       //             //}
       //         }
       //     }
       // }
       // #endregion

       // #region ADM_M024_PopUp
       // private List<ADM_M024_PopUp> _SelectedListOfEmpDtls;
       // public List<ADM_M024_PopUp> SelectedListOfEmpDtls
       // {
       //     get { return _SelectedListOfEmpDtls; }
       //     set
       //     {
       //         if (_SelectedListOfEmpDtls != value)
       //         {
       //             _SelectedListOfEmpDtls = value;
       //             RaisePropertychanged("SelectedListOfEmpDtls");
       //         }
       //     }
       // }
       // private ObservableCollection<ADM_M024_PopUp> _EmpList;
       // public ObservableCollection<ADM_M024_PopUp> EmpList
       // {
       //     get { return _EmpList; }
       //     set
       //     {
       //         _EmpList = value;
       //         RaisePropertychanged("EmpList");
       //     }
       // }

       // private ADM_M024_PopUp _SelectedEmpList;
       // public ADM_M024_PopUp SelectedEmpList
       // {
       //     get { return _SelectedEmpList; }
       //     set
       //     {
       //         if (_SelectedEmpList != value)
       //         {
       //             _SelectedEmpList = value;

       //             //if (PropertyChanged != null)
       //             //{
       //             RaisePropertychanged("SelectedEmpList");
       //             //}
       //         }
       //     }
       // }
       // #endregion

       // #region ADM_M029_PopUp1
       // public ADM_M029_PopUp1 _SelectedAddDtls { get; private set; }
       // public ADM_M029_PopUp1 SelectedAddDtls
       // {
       //     get { return _SelectedAddDtls; }
       //     set
       //     {
       //         if (_SelectedAddDtls != value)
       //         {
       //             _SelectedAddDtls = value;
       //             RaisePropertychanged("SelectedAddDtls");
       //         }
       //     }
       // }
       // private ObservableCollection<ADM_M029_PopUp1> _AddList;
       // public ObservableCollection<ADM_M029_PopUp1> AddList
       // {
       //     get { return _AddList; }
       //     set
       //     {
       //         _AddList = value;
       //         RaisePropertychanged("AddList");
       //     }
       // }
       // private ObservableCollection<ADM_M029_PopUp1> _AddListNew;
       // public ObservableCollection<ADM_M029_PopUp1> AddListNew
       // {
       //     get { return _AddListNew; }
       //     set
       //     {
       //         _AddListNew = value;
       //         RaisePropertychanged("AddListNew");
       //     }
       // }

       // private List<ADM_M029_PopUp1> _SelectedAddList;
       // public List<ADM_M029_PopUp1> SelectedAddList
       // {
       //     get { return _SelectedAddList; }
       //     set
       //     {
       //         if (_SelectedAddList != value)
       //         {
       //             _SelectedAddList = value;

       //             //if (PropertyChanged != null)
       //             //{
       //             RaisePropertychanged("SelectedAddList");
       //             //}
       //         }
       //     }
       // }
       // #endregion

       // #region ADM_M038_B_PopUp
       // public ADM_M038_B_PopUp _SelectedUomDtls { get; private set; }
       // public ADM_M038_B_PopUp SelectedUomDtls
       // {
       //     get { return _SelectedUomDtls; }
       //     set
       //     {
       //         if (_SelectedUomDtls != value)
       //         {
       //             _SelectedUomDtls = value;
       //             RaisePropertychanged("SelectedUomDtls");
       //         }
       //     }
       // }
       // private ObservableCollection<ADM_M038_B_PopUp> _UomList;
       // public ObservableCollection<ADM_M038_B_PopUp> UomList
       // {
       //     get { return _UomList; }
       //     set
       //     {
       //         _UomList = value;
       //         RaisePropertychanged("UomList");
       //     }
       // }

       // private List<ADM_M038_B_PopUp> _SelectedUomList;
       // public List<ADM_M038_B_PopUp> SelectedUomList
       // {
       //     get { return _SelectedUomList; }
       //     set
       //     {
       //         if (_SelectedUomList != value)
       //         {
       //             _SelectedUomList = value;

       //             //if (PropertyChanged != null)
       //             //{
       //             RaisePropertychanged("SelectedUomList");
       //             //}
       //         }
       //     }
       // }
       // #endregion

       // #region ACC_M007_PopUp
       // public ACC_M007_PopUp _SelectedPayTmDtls { get; private set; }
       // public ACC_M007_PopUp SelectedPayTmDtls
       // {
       //     get { return _SelectedPayTmDtls; }
       //     set
       //     {
       //         if (_SelectedPayTmDtls != value)
       //         {
       //             _SelectedPayTmDtls = value;
       //             RaisePropertychanged("SelectedPayTmDtls");
       //         }
       //     }
       // }
       // private ObservableCollection<ACC_M007_PopUp> _PayTmList;
       // public ObservableCollection<ACC_M007_PopUp> PayTmList
       // {
       //     get { return _PayTmList; }
       //     set
       //     {
       //         _PayTmList = value;
       //         RaisePropertychanged("PayTmList");
       //     }
       // }

       // private List<ACC_M007_PopUp> _SelectedPayTmList;
       // public List<ACC_M007_PopUp> SelectedPayTmList
       // {
       //     get { return _SelectedPayTmList; }
       //     set
       //     {
       //         if (_SelectedPayTmList != value)
       //         {
       //             _SelectedPayTmList = value;

       //             //if (PropertyChanged != null)
       //             //{
       //             RaisePropertychanged("SelectedPayTmList");
       //             //}
       //         }
       //     }
       // }
       // #endregion

       // #region ACC_M013_PopUp
       // private ACC_M013_PopUp _SelectedTaxDtls;
       // public ACC_M013_PopUp SelectedTaxDtls
       // {
       //     get { return _SelectedTaxDtls; }
       //     set
       //     {
       //         if (_SelectedTaxDtls != value)
       //         {
       //             _SelectedTaxDtls = value;
       //             RaisePropertychanged("SelectedTaxDtls");
       //         }
       //     }
       // }
       // private ObservableCollection<ACC_M013_PopUp> _TaxList;
       // public ObservableCollection<ACC_M013_PopUp> TaxList
       // {
       //     get { return _TaxList; }
       //     set
       //     {
       //         _TaxList = value;
       //         RaisePropertychanged("TaxList");
       //     }
       // }
       // private List<ACC_M013_PopUp> _SelectedTaxList;
       // public List<ACC_M013_PopUp> SelectedTaxList
       // {
       //     get { return _SelectedTaxList; }
       //     set
       //     {
       //         if (_SelectedTaxList != value)
       //         {
       //             _SelectedTaxList = value;

       //             //if (PropertyChanged != null)
       //             //{
       //             RaisePropertychanged("SelectedTaxList");
       //             //}
       //         }
       //     }
       // }
       // #endregion

       // #region ADM_M028_PopUp
       // private List<ADM_M028_PopUp> _SelectedListOfPartyDtls;
       // public List<ADM_M028_PopUp> SelectedListOfPartyDtls
       // {
       //     get { return _SelectedListOfPartyDtls; }
       //     set
       //     {
       //         if (_SelectedListOfPartyDtls != value)
       //         {
       //             _SelectedListOfPartyDtls = value;
       //             RaisePropertychanged("SelectedListOfPartyDtls");
       //         }
       //     }
       // }
       // private ObservableCollection<ADM_M028_PopUp> _PartyList;
       // public ObservableCollection<ADM_M028_PopUp> PartyList
       // {
       //     get { return _PartyList; }
       //     set
       //     {
       //         _PartyList = value;
       //         RaisePropertychanged("PartyList");
       //     }
       // }

       // private ADM_M028_PopUp _SelectedPartyList;
       // public ADM_M028_PopUp SelectedPartyList
       // {
       //     get { return _SelectedPartyList; }
       //     set
       //     {
       //         if (_SelectedPartyList != value)
       //         {
       //             _SelectedPartyList = value;

       //             //if (PropertyChanged != null)
       //             //{
       //             RaisePropertychanged("SelectedPartyList");
       //             //}
       //         }
       //     }
       // }
       // #endregion

       // #region ADM_M027_PopUp1
       // private List<ADM_M027_PopUp1> _SelectedListOfBuyerDtls;
       // public List<ADM_M027_PopUp1> SelectedListOfBuyerDtls
       // {
       //     get { return _SelectedListOfBuyerDtls; }
       //     set
       //     {
       //         if (_SelectedListOfBuyerDtls != value)
       //         {
       //             _SelectedListOfBuyerDtls = value;
       //             RaisePropertychanged("SelectedListOfBuyerDtls");
       //         }
       //     }
       // }
       // private ObservableCollection<ADM_M027_PopUp1> _BuyerList;
       // public ObservableCollection<ADM_M027_PopUp1> BuyerList
       // {
       //     get { return _BuyerList; }
       //     set
       //     {
       //         _BuyerList = value;
       //         RaisePropertychanged("BuyerList");
       //     }
       // }

       // private ADM_M027_PopUp1 _SelectedBuyerList;
       // public ADM_M027_PopUp1 SelectedBuyerList
       // {
       //     get { return _SelectedBuyerList; }
       //     set
       //     {
       //         if (_SelectedBuyerList != value)
       //         {
       //             _SelectedBuyerList = value;

       //             //if (PropertyChanged != null)
       //             //{
       //             RaisePropertychanged("SelectedBuyerList");
       //             //}
       //         }
       //     }
       // }
       // #endregion

       // #region CRM_T001B_ItemPopup_sale
       // public CRM_T001B_ItemPopup_sale _SelectedCatItemsDtls { get; private set; }
       // public CRM_T001B_ItemPopup_sale SelectedCatItemsDtls
       // {
       //     get { return _SelectedCatItemsDtls; }
       //     set
       //     {
       //         if (_SelectedCatItemsDtls != value)
       //         {
       //             _SelectedCatItemsDtls = value;
       //             RaisePropertychanged("SelectedCatItemsDtls");
       //         }
       //     }
       // }
       // private ObservableCollection<CRM_T001B_ItemPopup_sale> _CatItemsList;
       // public ObservableCollection<CRM_T001B_ItemPopup_sale> CatItemsList
       // {
       //     get { return _CatItemsList; }
       //     set
       //     {
       //         _CatItemsList = value;
       //         RaisePropertychanged("CatItemsList");
       //     }
       // }
       // private List<CRM_T001B_ItemPopup_sale> _SelectedCatItemsList;
       // public List<CRM_T001B_ItemPopup_sale> SelectedCatItemsList
       // {
       //     get { return _SelectedCatItemsList; }
       //     set
       //     {
       //         if (_SelectedCatItemsList != value)
       //         {
       //             _SelectedCatItemsList = value;

       //             //if (PropertyChanged != null)
       //             //{
       //             RaisePropertychanged("SelectedCatItemsList");
       //             //}
       //         }
       //     }
       // }
       // #endregion

       // private COM_T002_A _Selected_NewFollowerMessage = new COM_T002_A();
       // public COM_T002_A Selected_NewFollowerMessage
       // {
       //     get { return _Selected_NewFollowerMessage; }
       //     set
       //     {
       //         if (_Selected_NewFollowerMessage != value)
       //         {
       //             _Selected_NewFollowerMessage = value;

       //             RaisePropertychanged("Selected_NewFollowerMessage");
       //         }
       //     }
       // }

       // private Nullable<decimal> _tax_amt;
       // public Nullable<decimal> tax_amt
       // {
       //     get { return _tax_amt; }
       //     set
       //     {
       //         if (_tax_amt != value)
       //         {
       //             _tax_amt = value;

       //             RaisePropertychanged("tax_amt");
       //         }
       //     }
       // }
       // private Nullable<decimal> _untax_amt;
       // public Nullable<decimal> untax_amt
       // {
       //     get { return _untax_amt; }
       //     set
       //     {
       //         if (_untax_amt != value)
       //         {
       //             _untax_amt = value;

       //             RaisePropertychanged("untax_amt");
       //         }
       //     }
       // }
       // private Nullable<decimal> _total_amt;
       // public Nullable<decimal> total_amt
       // {
       //     get { return _total_amt; }
       //     set
       //     {
       //         if (_total_amt != value)
       //         {
       //             _total_amt = value;

       //             RaisePropertychanged("total_amt");
       //         }
       //     }
       // }
       // string _tax_id;
       // public string tax_id
       // {
       //     get { return _tax_id; }
       //     set
       //     {
       //         if (_tax_id != value)
       //         {
       //             _tax_id = value;

       //             RaisePropertychanged("tax_id");
       //         }
       //     }
       // }
       // public Dictionary<string, object> Items
       // {
       //     get { return _items; }
       //     set
       //     {
       //         if (_items != value)
       //         {
       //             _items = value;
       //             RaisePropertychanged("Items");
       //         }
       //     }
       // }
       // public Dictionary<string, object> SelectedItems
       // {
       //     get
       //     {
       //         return _selectedItems;
       //     }
       //     set
       //     {
       //         _selectedItems = value;
       //         NotifyPropertyChanged("SelectedItems");
       //     }
       // }
       // public int dgSelectedIndex
       // {
       //     get
       //     {
       //         return _dgSelectedIndex;
       //     }
       //     set
       //     {
       //         if (_dgSelectedIndex != value)
       //         {
       //             _dgSelectedIndex = value;
       //             RaisePropertychanged("dgSelectedIndex");
       //         }
       //     }
       // }
       // private int _dgSelectedIndex1;
       // public int dgSelectedIndex1
       // {
       //     get
       //     {
       //         return _dgSelectedIndex1;
       //     }
       //     set
       //     {
       //         if (_dgSelectedIndex1 != value)
       //         {

       //             _dgSelectedIndex1 = value;
       //             RaisePropertychanged("dgSelectedIndex1");
       //         }
       //     }
       // }
       // MultipleContext_SEL_T001 _MC = new MultipleContext_SEL_T001();
       // public MultipleContext_SEL_T001 MC
       // {
       //     get { return _MC; }
       //     set
       //     {
       //         if (_MC != value)
       //         {
       //             _MC = value;

       //             RaisePropertychanged("MC");
       //         }
       //     }
       // }
       // public SEL_T001_VM_StockTransfer()
       //     : base()
       // {

       //     SelectedList = new List<SEL_T001>();
       //     SelectedSEL_T001 = new SEL_T001();
       //     SO_Dtails = new ObservableCollection<SEL_T001_B>();
       //     Tax_Dtails = new ObservableCollection<SEL_T001_C>();
       //     SelectedLoctnDtls = new ADM_M003_PopUp();
       //     SelectedLoctnList = new List<ADM_M003_PopUp>();
       //     SelectedAddList = new List<ADM_M029_PopUp1>();
       //     SelectedListOfEmpDtls = new List<ADM_M024_PopUp>();
       //     SelectedListOfPartyDtls = new List<ADM_M028_PopUp>();
       //     EmpList = new ObservableCollection<ADM_M024_PopUp>();
       //     BuyerList = new ObservableCollection<ADM_M027_PopUp1>();
       //     PartyList = new ObservableCollection<ADM_M028_PopUp>();
       //     UomList = new ObservableCollection<ADM_M038_B_PopUp>();
       //     PayTmList = new ObservableCollection<ACC_M007_PopUp>();
       //     TaxList = new ObservableCollection<ACC_M013_PopUp>();
       //     CatItemsList = new ObservableCollection<CRM_T001B_ItemPopup_sale>();
       //     SelectedEmpList = new ADM_M024_PopUp();
       //     SelectedPartyList = new ADM_M028_PopUp();
       //     SelectedUomList = new List<ADM_M038_B_PopUp>();
       //     SelectedSEL_T001.ValidateAsync().Wait();
       //     Selected_NewFollowerMessage = new COM_T002_A();
       //     MC = new MultipleContext_SEL_T001();
       //     dgPOdeliveryschedule = new ObservableCollection<SEL_T002_B>();
       //     dgPOschedule = new ObservableCollection<SalesOrder_deliveryschedule>();
       //     FluteList = new List<ADM_M030_P>();
       //     ParamValuesList = new ObservableCollection<ADM_M030_P>();//new
       //     ParamitemList = new ObservableCollection<ADM_M030_P>();
       //     dgPOTaxValues = new ObservableCollection<SEL_T001_C>();
       //     dgPOTaxValues1 = new ObservableCollection<SEL_T001_C>();
       //     dgPOTotalTaxValues = new ObservableCollection<SEL_T001_C>();
       //     dgPOTaxValues2 = new ObservableCollection<SEL_T001_C>();
       //     dgPOTaxValues3 = new ObservableCollection<SEL_T001_C>();
       //     dgscheduledmaster = new ObservableCollection<SEL_T002>();
       //     SelectedChildTaxList = new List<ACC_M013_PopUp>();
       //     dgcost_center = new ObservableCollection<ACC_M019_Popup>();
       //     EnquiryList = new ObservableCollection<Inquiry_PopUp>();
       //     EnquiryschList = new ObservableCollection<SEL_T002_B>();
       //     ButtonInvoiceCommand = new RelayCommand(RowWiseTaxesLoad);
       //     ButtonProductCommand = new RelayCommand(LoadNo);
       //     ActiveCommand = new RelayCommand<bool>(Active);
       //     ButtonClickCommand = new RelayCommand(Load);
       //     ValidatedBy_SelectionChanged = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedValidatedby(items);
       //     });


       //     ParameterPopupCommand = new RelayCommand<IList>(
       //           items =>
       //           {
       //               if (items == null)
       //               {
       //                   return;
       //               }
       //               ParameterPopupClosed(items);
       //           }
       //           );

       //     CheckedCommand = new RelayCommand<IList>(
       //           items =>
       //           {
       //               if (items == null)
       //               {
       //                   return;
       //               }
       //               checkstatus(items);
       //           }
       //           );

       //     SelectionCommand_reference_doc = new RelayCommand<IList>(
       //           items =>
       //           {
       //               if (items == null)
       //               {
       //                   return;
       //               }
       //               DocNo(items);
       //           }
       //           );

       //     SelectionChangedCommandTotalTax = new RelayCommand<IList>(
       //      items =>
       //      {
       //          if (items == null)
       //          {
       //              return;
       //          }
       //          TableTaxEdit(items);

       //      });
       //     TaxChangedCommand = new RelayCommand<IList>(
       //   items =>
       //   {
       //       if (items == null)
       //       {
       //           return;
       //       }
       //       TaxEdit(items);

       //   });



       //     SelectionChangedCommandForTax = new RelayCommand<IList>(
       //items =>
       //{
       //    if (items == null)
       //    {
       //        return;
       //    }
       //    TaxCellChanged(items);

       //});

       //     ScheduleCellChangedCommand = new RelayCommand<IList>(
       //items =>
       //{
       //    if (items == null)
       //    {
       //        return;
       //    }
       //    ScheduleCellChanged(items);

       //});
       //     TaxPopupCommand = new RelayCommand<object>(
       //    items =>
       //    {
       //        if (items == null)
       //        {
       //            return;
       //        }
       //        TaxCalculationChanged(items);

       //    });
       //     SelectionChangedCommandItemfordelivery = new RelayCommand<IList>(
       //   items =>
       //   {
       //       if (items == null)
       //       {
       //           return;
       //       }
       //       AddSelectedItemTodeliveryschedule(items);

       //   });
       //     SelectionChangedCommand = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }
       //         GetSelectedList(items);
       //     });
       //     SelectionChangedCommandLoctn = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedLoctnDetails(items);
       //     });
       //     SelectionChangedCommandEmp = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedEmpDetails(items);
       //     });
       //     SelectionChangedCommandParty = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedPartyDetails(items);
       //     });

       //     SelectionChangedCommandShipToParty = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedShiptoPartyDetails(items);
       //     });


       //     SelectionChangedCommandPartyTo = new RelayCommand<IList>(
       //  items =>
       //  {
       //      if (items == null)
       //      {
       //          return;
       //      }

       //      GetSelectedSoldToPartyDetails(items);
       //  });
       //     SelectionChangedCommandDelAdd = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedDelAddDetails(items);
       //     });
       //     SelectionChangedCommandInvicAdd = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedInvicAddDetails(items);
       //     });

       //     SelectionChangedCommandProfitCentre = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedProfitCentreDetails(items);
       //     });


       //     SelectedCommand_sales_org = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedSalesOrgnisationDetails(items);
       //     });

       //     SelectedCammand_sales_group = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedSalesGroup(items);
       //     });

       //     SelectionChangedCommandStorageLocation = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedStorageLocationDetails(items);
       //     });
       //     SelectionChangedCommandDestinationWarehouse = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedWarehouseLocationDetails(items);
       //     });
       //     SelectedCammand_sales_person = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedSalePersonDetails(items);
       //     });

       //     SelectionChangedCommandCostCentre = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedCostCentreDetails(items);
       //     });

       //     SelectedCommand_sales_division = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedSalesDivisionDetails(items);
       //     });



       //     SelectedCammand_distribution_channel = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelecteddistributionchannelDetails(items);
       //     });

       //     SelectedCommand_itemcategory = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedItemcategoryDetails(items);
       //     });



       //     SelectedCammand_sales_office = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedSalesOfficeDetails(items);
       //     });

       //     SelectionChangedCommandCurrency = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedCurrencyDetails(items);
       //     });

       //     SelectionChangedCommandBuyer = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedBuyerDetails(items);
       //     });
       //     SelectionChangedCommandItems = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedItemsDetails(items);
       //     });

       //     SelectionChangedCommandweightuom = new RelayCommand<IList>(
       //    items =>
       //    {
       //        if (items == null)
       //        {
       //            return;
       //        }

       //        GetSelectedWeightUomDetails(items);
       //    });
       //     SelectionChangedCommandVolumetuom = new RelayCommand<IList>(
       //    items =>
       //    {
       //        if (items == null)
       //        {
       //            return;
       //        }

       //        GetSelectedVolumeUomDetails(items);
       //    });
       //     SelectionChangedCommanduom = new RelayCommand<IList>(
       //    items =>
       //    {
       //        if (items == null)
       //        {
       //            return;
       //        }

       //        GetSelectedUomDetails(items);
       //    });


       //     SelectionChangedCommandWarehousecollection = new RelayCommand<IList>(
       //   items =>
       //   {
       //       if (items == null)
       //       {
       //           return;
       //       }

       //       GetSelectedWarehouseDetails(items);
       //   });



       //     SelectionChangedCommandstoragecollection = new RelayCommand<IList>(
       //    items =>
       //    {
       //        if (items == null)
       //        {
       //            return;
       //        }

       //        GetSelectedStorageDetails(items);
       //    });

       //     SelectionChangedCommandJournal = new RelayCommand<IList>(
       //    items =>
       //    {
       //        if (items == null)
       //        {
       //            return;
       //        }

       //        GetSelectedJournalDetails(items);
       //    });
       //     SelectionChangedCommandPayTm = new RelayCommand<IList>(
       //    items =>
       //    {
       //        if (items == null)
       //        {
       //            return;
       //        }

       //        GetSelectedPayTmDetails(items);
       //    });
       //     SelectionChangedCommandTax = new RelayCommand<IList>(
       //    items =>
       //    {
       //        if (items == null)
       //        {
       //            return;
       //        }

       //        GetSelectedTaxDetails(items);
       //    });

       //     SelectionCommand_doc_type = new RelayCommand<IList>(
       //    items =>
       //    {
       //        if (items == null)
       //        {
       //            return;
       //        }

       //        GetSelectedDocTypeDetails(items);
       //    });

       //     SelectionChangedCommandSOdetails = new RelayCommand<IList>(
       //    items =>
       //    {
       //        if (items == null)
       //        {
       //            return;
       //        }

       //        GetSelectedSOList(items);

       //    });
       //     DeleteItemCommand = new RelayCommand<IList>(
       //        items =>
       //        {
       //            if (items == null)
       //            {
       //                return;
       //            }

       //            getSelectedRow(items);

       //        });

       //     CollectionChangedMethod = new RelayCommand<IList>(
       //      items =>
       //      {
       //          if (items == null)
       //          {
       //              return;
       //          }
       //          CollectionChanged(items);

       //      });
       //     CellChangedCommand = new RelayCommand<IList>(
       // items =>
       // {
       //     if (items == null)
       //     {
       //         return;
       //     }
       //     CellChangeUpdate(items);
       // });


       //     LoadInitialData();
       //     Items = new Dictionary<string, object>();
       //     SelectedItems = new Dictionary<string, object>();
       //     Items.Clear();

       //     Items = SelectedTaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);

       //     AddList = AddListNew;
       //     SelectedSEL_T001.sodate = DateTime.Now;
       //     SelectedSEL_T001.sales_org = "aa";
       //     SelectedSEL_T001.stock_location_id = "aa";
       //     SelectedSEL_T001.doc_currency = 0;
       //     SelectedSEL_T001.customer_id = 0;
       //     SelectedSEL_T001.doc_type_id = "ST";
       //     //SO_Dtails[dgSelectedIndex].quantity = 0;
       //     //SO_Dtails[dgSelectedIndex].unit_price = 0;
       //     //SO_Dtails[dgSelectedIndex].item_code = "";
       //     //SO_Dtails[dgSelectedIndex].UOMNm = "";
       //     //SO_Dtails[dgSelectedIndex].item_cat_id = "";
       //     //so_id
       // }

       // #region . User Defined Function .
       // Dictionary<string, object> GetDict(string f)
       // {
       //     if (string.IsNullOrEmpty(f) || string.IsNullOrWhiteSpace(f)) return null;
       //     Dictionary<string, object> d = new Dictionary<string, object>();

       //     string[] tokens = f.Split(new char[] { '/', ':', ',' },
       //         StringSplitOptions.RemoveEmptyEntries);
       //     for (int i = 0; i < tokens.Length; i += 1)
       //     {
       //         string name = tokens[i];
       //         if (d.ContainsKey(name))
       //         {
       //             //d[name] += count;
       //         }
       //         else
       //         {
       //             d.Add(name, "");
       //         }
       //     }
       //     return d;
       // }
       // private void Submit()
       // {
       //     foreach (KeyValuePair<string, object> s in SelectedItems)
       //         MessageBox.Show(s.Key);
       // }
       // private void GetSelectedList(IList DataList)
       // {
       //     IList list = DataList as IList;
       //     List<SEL_T001> tSelectedItemsList = list.Cast<SEL_T001>().ToList();
       //     if (tSelectedItemsList.Count > 0)
       //     {
       //         SelectedSEL_T001 = (SEL_T001)tSelectedItemsList[0];
       //         blNew = false;
       //     }
       // }
       // private void GetSelectedSOList(IList SOList)
       // {
       //     try
       //     {
       //         IList list = SOList as IList;

       //         List<SEL_T001> SelectedSOList = list.Cast<SEL_T001>().ToList();

       //         if (SelectedSOList.Count > 0)
       //         {
       //             SelectedSEL_T001 = (SEL_T001)SelectedSOList[0];
       //             string supplierid = "";
       //             string supplierid1 = Convert.ToString(SelectedSOList[0].customer_id);
       //             supplierid = supplierid1 + "@" + AppSessionState.comp_code.ToString() + "@" + AppSessionState.location_Id;

       //             MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, "SEL_T001_Data", "SalesOrderMaster", "CRM", "LoadSODetails", SelectedSEL_T001.id, supplierid);
       //             if (SelectedSEL_T001 != null)
       //             {
       //                 MC.SO_Dtails = MCTemp.SO_Dtails;

       //                 MC.SO_Dtails = MCTemp.SO_Dtails;
       //                 MC.ParamvalList = MCTemp.ParamvalList;
       //                 MC.POtaxDetails = MCTemp.POtaxDetails;
       //                 dgPOTotalTaxValues = new ObservableCollection<SEL_T001_C>();
       //                 dgPOTotalTaxValues = MCTemp.POTotaltaxDetails;
       //                 FluteList = MC.FluteList;
       //                 dgPOdeliveryschedule = MCTemp.Deliveryschedule;
       //                 dgPOschedule = MCTemp.PurchaseOrder_deliveryschedule;
       //                 dgscheduledmaster = MCTemp.DeliveryscheduleMaster;

       //                 SO_Dtails = new ObservableCollection<SEL_T001_B>();
       //                 SO_Dtails = MC.SO_Dtails;
       //                 InvcAddCollection = CollectionViewSource.GetDefaultView(MCTemp.addresses.ToList());
       //                 InvcAddCollection.Filter = new Predicate<object>(AddFilter);
       //                 DelAddCollection = CollectionViewSource.GetDefaultView(MCTemp.addresses.ToList());
       //                 DelAddCollection.Filter = new Predicate<object>(AddFilter);

       //                 BuyerCollection = CollectionViewSource.GetDefaultView(MCTemp.Contacts);
       //                 BuyerCollection.Filter = new Predicate<object>(BuyerFilter);
       //                 foreach (var itm in SO_Dtails.ToList())
       //                 {
       //                     var item = MCTemp.CatItems.FirstOrDefault(X => X.ItemId == itm.item_id);
       //                     if (item != null)
       //                     {
       //                         item.Select = true;
       //                     }
       //                 }
       //                 ItemsCollection = CollectionViewSource.GetDefaultView(MCTemp.CatItems);
       //                 ItemsCollection.Filter = new Predicate<object>(ItemsFilter);

       //                 uomCollection = CollectionViewSource.GetDefaultView(MCTemp.uoms);
       //                 uomCollection.Filter = new Predicate<object>(uomFilter);
       //                 foreach (var item in SO_Dtails)
       //                 {
       //                     SO_Dtails.Where(i => i.item_id == item.item_id).Where(i => i.stocking_unit == item.stocking_unit).ToList().ForEach(L => L.stocking_unit1 = item.stocking_unit);
       //                 }

       //                 blNew = false;
       //                 Update();
       //                 updateDescription();
       //                 try
       //                 {
       //                     TaxTableCalculation();
       //                 }
       //                 catch
       //                 {

       //                 }
       //             }
       //         }
       //     }
       //     catch (Exception ex)
       //     {
       //         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //         showMessageService.ButtonSetup = DialogButton.Ok;
       //         showMessageService.Caption = "Message";
       //         showMessageService.Text = String.Format(ex.Message, this.Title);
       //         showMessageService.ShowMessage();
       //     }
       // }
       // private void GetSelectedLoctnDetails(IList LoctnList)
       // {
       //     IList list = LoctnList as IList;
       //     List<ADM_M003_PopUp> GetSelectedLoctnDetailsTemp = list.Cast<ADM_M003_PopUp>().ToList();
       //     if (GetSelectedLoctnDetailsTemp.Count > 0)
       //     {
       //         SelectedSEL_T001.order_to = GetSelectedLoctnDetailsTemp[0].location_Id;
       //         SelectedSEL_T001.LoctnNm = GetSelectedLoctnDetailsTemp[0].LoctnNm;
       //     }

       // }
       // private void GetSelectedEmpDetails(IList EmpList)
       // {
       //     IList list = EmpList as IList;
       //     List<ADM_M024_PopUp> SelectedEmpDetailsTemp = list.Cast<ADM_M024_PopUp>().ToList();
       //     if (SelectedEmpDetailsTemp.Count > 0)
       //     {
       //         //SelectedSEL_T001.salesman = SelectedEmpDetailsTemp[0].id;
       //         SelectedSEL_T001.EmpNm = SelectedEmpDetailsTemp[0].EmpLName;
       //     }

       // }
       // private void GetSelectedSoldToPartyDetails(IList PartyList)
       // {
       //     try
       //     {
       //         IList list = PartyList as IList;
       //         List<ADM_M028_PopUp> SelectedPartyDetailsTemp = list.Cast<ADM_M028_PopUp>().ToList();
       //         if (SelectedPartyDetailsTemp.Count > 0)
       //         {

       //             if (SelectedSEL_T001.id > 0)
       //             {
       //                 IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //                 showMessageService.ButtonSetup = DialogButton.Ok;
       //                 showMessageService.Caption = "Party Selection";
       //                 showMessageService.Text =
       //                     String.Format("Can not change party'{0}'", this.Title);
       //                 showMessageService.ShowMessage();
       //             }
       //             else if (SelectedSEL_T001.id == 0)
       //             {
       //                 if (SO_Dtails.Count > 0)
       //                 {
       //                     IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //                     showMessageService.ButtonSetup = DialogButton.Ok;
       //                     showMessageService.Caption = "Party Selection";
       //                     showMessageService.Text =
       //                         String.Format(
       //                             "If You Change The Party Items Will be removed'{0}'",
       //                                 this.Title);

       //                     if (showMessageService.ShowMessage() == DialogResult.Ok)
       //                     {

       //                         SO_Dtails = new ObservableCollection<SEL_T001_B>();
       //                         //SelectedSEL_T001 = new SEL_T001();
       //                         SelectedSEL_T001.total_amt = 0;
       //                         SelectedSEL_T001.buyer = 0;
       //                         SelectedSEL_T001.ContPersnNm = null;
       //                         SelectedSEL_T001.InvicAdd = null;
       //                         SelectedSEL_T001.DelAdd = null;
       //                         //SelectedSEL_T001.Invoice_address = null;
       //                         SelectedSEL_T001.del_address = null;
       //                         SelectedSEL_T001.customer_id = Convert.ToInt32(SelectedPartyDetailsTemp[0].id);
       //                         SelectedSEL_T001.PartyNm = SelectedPartyDetailsTemp[0].PartyNm;
       //                         SelectedSEL_T001.EmailID = SelectedPartyDetailsTemp[0].EmailId;

       //                         MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, "SEL_T001_Data", "SalesOrderMaster", "CRM", "PartyLoad", SelectedPartyDetailsTemp[0].id, "");

       //                         InvcAddCollection = CollectionViewSource.GetDefaultView(MCTemp.addresses.ToList());
       //                         InvcAddCollection.Filter = new Predicate<object>(AddFilter);
                                
       //                         BuyerCollection = CollectionViewSource.GetDefaultView(MCTemp.Contacts);
       //                         BuyerCollection.Filter = new Predicate<object>(BuyerFilter);

       //                         ItemsCollection = CollectionViewSource.GetDefaultView(MCTemp.CatItems);
       //                         ItemsCollection.Filter = new Predicate<object>(ItemsFilter);
       //                         if (MCTemp.addresses.ToList() != null && MCTemp.addresses.ToList().Count == 1)
       //                         {
       //                             SelectedSEL_T001.InvicAdd = MCTemp.addresses.ToList()[0].AddType;                                 
       //                            // SelectedSEL_T001.Invoice_address = MCTemp.addresses.ToList()[0].id;                                 
       //                         }
       //                         else
       //                         {
       //                             SelectedSEL_T001.InvicAdd = null;                                   
       //                            // SelectedSEL_T001.Invoice_address = null;                                   
       //                         }
       //                     }
       //                 }
       //                 else if (SO_Dtails.Count == 0)
       //                 {
       //                     SO_Dtails = new ObservableCollection<SEL_T001_B>();
       //                     //SelectedSEL_T001 = new SEL_T001();
       //                     SelectedSEL_T001.customer_id = Convert.ToInt32(SelectedPartyDetailsTemp[0].id);
       //                     SelectedSEL_T001.PartyNm = SelectedPartyDetailsTemp[0].PartyNm;
       //                     partyemail = SelectedPartyDetailsTemp[0].EmailId;

       //                     MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, "SEL_T001_Data", "SalesOrderMaster", "CRM", "PartyLoad", SelectedPartyDetailsTemp[0].id, "");
       //                     InvcAddCollection = CollectionViewSource.GetDefaultView(MCTemp.addresses.ToList());
       //                     InvcAddCollection.Filter = new Predicate<object>(AddFilter);                          

       //                     BuyerCollection = CollectionViewSource.GetDefaultView(MCTemp.Contacts);
       //                     BuyerCollection.Filter = new Predicate<object>(BuyerFilter);

       //                     ItemsCollection = CollectionViewSource.GetDefaultView(MCTemp.CatItems);
       //                     ItemsCollection.Filter = new Predicate<object>(ItemsFilter);
       //                     if (MCTemp.addresses.ToList() != null && MCTemp.addresses.ToList().Count == 1)
       //                     {
       //                         SelectedSEL_T001.InvicAdd = MCTemp.addresses.ToList()[0].AddType;                              
       //                        // SelectedSEL_T001.Invoice_address = MCTemp.addresses.ToList()[0].id;                               
       //                     }
       //                     else
       //                     {
       //                         SelectedSEL_T001.InvicAdd = null;                             
       //                        // SelectedSEL_T001.Invoice_address = null;                               
       //                     }
       //                 }
       //             }
       //             uomCollection = CollectionViewSource.GetDefaultView(MC.uoms);
       //             uomCollection.Filter = new Predicate<object>(uomFilter);
       //         }

       //     }
       //     catch (Exception ex)
       //     {
       //         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //         showMessageService.ButtonSetup = DialogButton.Ok;
       //         showMessageService.Caption = "Message";
       //         showMessageService.Text = String.Format(ex.Message, this.Title);
       //         showMessageService.ShowMessage();
       //     }
       // }
       // private void GetSelectedValidatedby(IList partyList)
       // {
       //     IList list = partyList as IList;
       //     List<ADM_M024_PopUp> Selectedpartylist = list.Cast<ADM_M024_PopUp>().ToList();
       //     if (Selectedpartylist.Count > 0)
       //     {
       //         SelectedSEL_T001.EmpId  = Selectedpartylist[0].EmpId ;
       //         SelectedSEL_T001.validator_name = Selectedpartylist[0].EmpLName;
       //     }
       // }
       // private void DocNo(IList partyList)
       // {
       //     IList list = partyList as IList;
       //     List<SEL_T001_Popup> Selectedpartylist = list.Cast<SEL_T001_Popup>().ToList();
       //     if (Selectedpartylist.Count > 0)
       //     {
       //         SelectedSEL_T001.ref_doc_no = Selectedpartylist[0].sono;
       //     }
       // }
       // private void GetSelectedShiptoPartyDetails(IList partyList)
       // {
       //     IList list = partyList as IList;
       //     List<ADM_M028_PopUp> Selectedpartylist = list.Cast<ADM_M028_PopUp>().ToList();
       //     if (Selectedpartylist.Count > 0)
       //     {
       //         SelectedSEL_T001.ship_to = Selectedpartylist[0].id;
       //         SelectedSEL_T001.ship_to_party = Selectedpartylist[0].PartyNm;

       //         DelAddCollection = CollectionViewSource.GetDefaultView(MCTemp.addresses.ToList());
       //         DelAddCollection.Filter = new Predicate<object>(AddFilter);
                
              
       //         if (MCTemp.addresses.ToList() != null && MCTemp.addresses.ToList().Count == 1)
       //         {
       //             SelectedSEL_T001.DelAdd = MCTemp.addresses.ToList()[0].AddType;
       //             SelectedSEL_T001.del_address = MCTemp.addresses.ToList()[0].id;
       //         }
       //         else
       //         {
       //             SelectedSEL_T001.DelAdd = null;
       //             SelectedSEL_T001.del_address = null;
       //         }

       //     }
       // }
       // private void getSelectedRow(IList SelectedItems)
       // {
       //     IList list = SelectedItems as IList;
       //     List<SEL_T002_B> GetSelectedPur_Req_Details = list.Cast<SEL_T002_B>().ToList();

       //     if (GetSelectedPur_Req_Details.Count > 0)
       //     {
       //         //var q = SelectedList.Where(X => X.id == GetSelectedPur_Req_Details[0].req_id).FirstOrDefault();
       //         int x = dgPOdeliveryschedule.IndexOf(dgPOdeliveryschedule.Where(X => X.item == GetSelectedPur_Req_Details[0].item)
       //             .Where(X => X.stockingunit == GetSelectedPur_Req_Details[0].stockingunit)
       //                            .Where(X => X.count == GetSelectedPur_Req_Details[0].count).FirstOrDefault());

       //         //if (SelectedPUR_T002_A.id == 0 && GetSelectedPur_Req_Details[0].po_id == null)
       //         //{
       //         if (GetSelectedPur_Req_Details[0].id == 0)
       //         {
       //             if (x >= 0 && x != -1)
       //             {
       //                 dgPOdeliveryschedule.RemoveAt(x);
       //             }
       //             try
       //             {
       //                 ScheduleCellChanged(SelectedItems);
       //             }
       //             catch
       //             {

       //             }
       //             //MC.itemList.ToList().ForEach(t => t.Select = false);
       //         }

       //     }

       // }
       // private void GetSelectedPartyDetails(IList PartyList)
       // {
       //     try
       //     {
       //         IList list = PartyList as IList;
       //         List<ADM_M028_PopUp> SelectedPartyDetailsTemp = list.Cast<ADM_M028_PopUp>().ToList();
       //         if (SelectedPartyDetailsTemp.Count > 0)
       //         {
       //             if (SelectedSEL_T001.id > 0)
       //             {
       //                 IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //                 showMessageService.ButtonSetup = DialogButton.Ok;
       //                 showMessageService.Caption = "Party Selection";
       //                 showMessageService.Text = String.Format("Can not change party'{0}'", this.Title);
       //                 showMessageService.ShowMessage();
       //             }
       //             else if (SelectedSEL_T001.id == 0)
       //             {
       //                 if (SO_Dtails.Count > 0)
       //                 {
       //                     IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //                     showMessageService.ButtonSetup = DialogButton.Ok;
       //                     showMessageService.Caption = "Party Selection";
       //                     showMessageService.Text = String.Format("If You Change The Party Items Will be removed'{0}'", this.Title);

       //                     if (showMessageService.ShowMessage() == DialogResult.Ok)
       //                     {

       //                         SO_Dtails = new ObservableCollection<SEL_T001_B>();
       //                         dgPOTotalTaxValues = new ObservableCollection<SEL_T001_C>();
       //                         //SelectedSEL_T001 = new SEL_T001();
       //                         SelectedSEL_T001.total_amt = 0;
       //                         SelectedSEL_T001.untax_amt = 0;
       //                         SelectedSEL_T001.tax_amt = 0;
       //                         SelectedSEL_T001.amt_inword = "";
       //                         SelectedSEL_T001.buyer = 0;
       //                         SelectedSEL_T001.ContPersnNm = null;
       //                         SelectedSEL_T001.InvicAdd = null;
       //                         SelectedSEL_T001.DelAdd = null;
       //                         //SelectedSEL_T001.Invoice_address = null;
       //                         SelectedSEL_T001.del_address = null;
       //                         SelectedSEL_T001.customer_id = Convert.ToInt32(SelectedPartyDetailsTemp[0].id);
       //                         SelectedSEL_T001.PartyNm = SelectedPartyDetailsTemp[0].PartyNm;
       //                         partyemail = SelectedPartyDetailsTemp[0].EmailId;
       //                         string company = "";
       //                         company = AppSessionState.comp_code.ToString();
       //                         MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, "SEL_T001_Data", "SalesOrderMaster", "CRM", "PartyLoad", SelectedPartyDetailsTemp[0].id, AppSessionState.comp_code.ToString());

       //                         InvcAddCollection = CollectionViewSource.GetDefaultView(MCTemp.addresses.ToList());
       //                         InvcAddCollection.Filter = new Predicate<object>(AddFilter);
       //                         DelAddCollection = CollectionViewSource.GetDefaultView(MCTemp.addresses.ToList());
       //                         DelAddCollection.Filter = new Predicate<object>(AddFilter);

       //                         BuyerCollection = CollectionViewSource.GetDefaultView(MCTemp.Contacts);
       //                         BuyerCollection.Filter = new Predicate<object>(BuyerFilter);

       //                         ItemsCollection = CollectionViewSource.GetDefaultView(MCTemp.CatItems);
       //                         ItemsCollection.Filter = new Predicate<object>(ItemsFilter);
       //                         if (MCTemp.addresses.ToList() != null && MCTemp.addresses.ToList().Count == 1)
       //                         {
       //                             SelectedSEL_T001.InvicAdd = MCTemp.addresses.ToList()[0].AddType;
       //                             SelectedSEL_T001.DelAdd = MCTemp.addresses.ToList()[0].AddType;
       //                             SelectedSEL_T001.bill_address_id = MCTemp.addresses.ToList()[0].id;
       //                             SelectedSEL_T001.del_address = MCTemp.addresses.ToList()[0].id;
       //                         }
       //                         else
       //                         {
       //                             SelectedSEL_T001.InvicAdd = null;
       //                             SelectedSEL_T001.DelAdd = null;
       //                             SelectedSEL_T001.bill_address_id = null;
       //                             SelectedSEL_T001.del_address = null;
       //                         }

       //                         try
       //                         {
       //                             if (MCTemp.currencyListPartyWise.ToList() != null && MCTemp.currencyListPartyWise.ToList().Count == 1)
       //                             {
       //                                 SelectedSEL_T001.doc_currency = MCTemp.currencyListPartyWise[0].id;
       //                                 SelectedSEL_T001.doc_currency_name = MCTemp.currencyListPartyWise[0].curr_name;

       //                             }
       //                             else
       //                             {
       //                                 SelectedSEL_T001.doc_currency = null;
       //                                 SelectedSEL_T001.doc_currency_name = "";

       //                             }
       //                         }
       //                         catch
       //                         {

       //                         }

       //                     }
       //                 }
       //                 else if (SO_Dtails.Count == 0)
       //                 {
       //                     SO_Dtails = new ObservableCollection<SEL_T001_B>();
       //                     //SelectedSEL_T001 = new SEL_T001();
       //                     SelectedSEL_T001.customer_id = Convert.ToInt32(SelectedPartyDetailsTemp[0].id);
       //                     SelectedSEL_T001.PartyNm = SelectedPartyDetailsTemp[0].PartyNm;
       //                     partyemail = SelectedPartyDetailsTemp[0].EmailId;

       //                     MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, "SEL_T001_Data", "SalesOrderMaster", "CRM", "PartyLoad", SelectedPartyDetailsTemp[0].id, AppSessionState.comp_code.ToString());
       //                     InvcAddCollection = CollectionViewSource.GetDefaultView(MCTemp.addresses.ToList());
       //                     InvcAddCollection.Filter = new Predicate<object>(AddFilter);
       //                     DelAddCollection = CollectionViewSource.GetDefaultView(MCTemp.addresses.ToList());
       //                     DelAddCollection.Filter = new Predicate<object>(AddFilter);

       //                     BuyerCollection = CollectionViewSource.GetDefaultView(MCTemp.Contacts);
       //                     BuyerCollection.Filter = new Predicate<object>(BuyerFilter);

       //                     ItemsCollection = CollectionViewSource.GetDefaultView(MCTemp.CatItems);
       //                     ItemsCollection.Filter = new Predicate<object>(ItemsFilter);

       //                     if (MCTemp.addresses.ToList() != null && MCTemp.addresses.ToList().Count == 1)
       //                     {
       //                         SelectedSEL_T001.InvicAdd = MCTemp.addresses.ToList()[0].AddType;
       //                         SelectedSEL_T001.DelAdd = MCTemp.addresses.ToList()[0].AddType;
       //                         SelectedSEL_T001.bill_address_id = MCTemp.addresses.ToList()[0].id;
       //                         SelectedSEL_T001.del_address = MCTemp.addresses.ToList()[0].id;


       //                     }
       //                     else
       //                     {
       //                         SelectedSEL_T001.InvicAdd = null;
       //                         SelectedSEL_T001.DelAdd = null;
       //                         SelectedSEL_T001.bill_address_id = null;
       //                         SelectedSEL_T001.del_address = null;
       //                     }
       //                     try
       //                     {
       //                         if (MCTemp.currencyListPartyWise.ToList() != null && MCTemp.currencyListPartyWise.ToList().Count == 1)
       //                         {
       //                             SelectedSEL_T001.doc_currency = MCTemp.currencyListPartyWise[0].id;
       //                             SelectedSEL_T001.doc_currency_name = MCTemp.currencyListPartyWise[0].curr_name;

       //                         }
       //                         else
       //                         {
       //                             SelectedSEL_T001.doc_currency = null;
       //                             SelectedSEL_T001.doc_currency_name = "";

       //                         }
       //                     }
       //                     catch
       //                     {

       //                     }
       //                 }
       //             }
       //             uomCollection = CollectionViewSource.GetDefaultView(MC.uoms);
       //             uomCollection.Filter = new Predicate<object>(uomFilter);
       //         }

       //     }
       //     catch (Exception ex)
       //     {
       //         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //         showMessageService.ButtonSetup = DialogButton.Ok;
       //         showMessageService.Caption = "Message";
       //         showMessageService.Text = String.Format(ex.Message, this.Title);
       //         showMessageService.ShowMessage();
       //     }
       // }
       // private void GetSelectedBuyerDetails(IList BuyerList)
       // {
       //     IList list = BuyerList as IList;
       //     List<ADM_M027_PopUp1> SelectedBuyerDetailsTemp = list.Cast<ADM_M027_PopUp1>().ToList();

       //     if (SelectedBuyerDetailsTemp.Count > 0)
       //     {
       //         SelectedSEL_T001.buyer = SelectedBuyerDetailsTemp[0].ContInfoId;
       //         SelectedSEL_T001.ContPersnNm = SelectedBuyerDetailsTemp[0].PersnLName;
       //         buyeremail = SelectedBuyerDetailsTemp[0].PersnFName;//get buyers mail
       //     }
       // }
       // private void GetSelectedDelAddDetails(IList AddList)
       // {
       //     IList list = AddList as IList;
       //     List<ADM_M029_PopUp1> GetSelectedAddDetailsTemp = list.Cast<ADM_M029_PopUp1>().ToList();
       //     if (GetSelectedAddDetailsTemp.Count > 0)
       //     {
       //         SelectedSEL_T001.del_address = Convert.ToInt32(GetSelectedAddDetailsTemp[0].id);
       //         SelectedSEL_T001.DelAdd = GetSelectedAddDetailsTemp[0].AddType;
       //     }

       // }
       // private void GetSelectedInvicAddDetails(IList AddList)
       // {
       //     IList list = AddList as IList;
       //     List<ADM_M029_PopUp1> GetSelectedAddDetailsTemp = list.Cast<ADM_M029_PopUp1>().ToList();
       //     if (GetSelectedAddDetailsTemp.Count > 0)
       //     {
       //         //SelectedSEL_T001.Invoice_address = Convert.ToInt32(GetSelectedAddDetailsTemp[0].id);
       //         SelectedSEL_T001.InvicAdd = GetSelectedAddDetailsTemp[0].AddType;
       //     }

       // }
       // private void GetSelectedProfitCentreDetails(IList AddList)
       // {
       //     IList list = AddList as IList;
       //     List<ACC_M020_Popup> GetSelectedProfitCentreDetailsTemp = list.Cast<ACC_M020_Popup>().ToList();
       //     if (GetSelectedProfitCentreDetailsTemp.Count > 0)
       //     {
       //         //SelectedSEL_T001.profit_center_id = Convert.ToInt32(GetSelectedProfitCentreDetailsTemp[0].id);
       //         SelectedSEL_T001.profit_center = GetSelectedProfitCentreDetailsTemp[0].profit_center;
       //     }
       //     try
       //     {
       //         if (SelectedSEL_T001.profit_center != "")
       //         {
       //             foreach (var item in MC.Cost_centreList)
       //             {
       //                 //if (item.cc_profit_center == SelectedSEL_T001.profit_center_id)
       //                 //{
       //                 //    dgcost_center.Add(new ACC_M019_Popup { id = item.id, cost_center = item.cost_center, cc_profit_center = item.cc_profit_center });
       //                 //}
       //             }

       //         }
       //         cost_centerCollection = CollectionViewSource.GetDefaultView(dgcost_center);
       //     }
       //     catch
       //     {

       //     }

       // }
       // private void GetSelectedWarehouseLocationDetails(IList AddList)
       // {
       //     IList list = AddList as IList;
       //     List<MM_M002_PopUp> GetSelectedCostCentreDetailsTemp = list.Cast<MM_M002_PopUp>().ToList();
       //     if (GetSelectedCostCentreDetailsTemp.Count > 0)
       //     {

       //         SelectedSEL_T001.warehouse_id = (GetSelectedCostCentreDetailsTemp[0].wa_code);
       //         SelectedSEL_T001.warehouse = GetSelectedCostCentreDetailsTemp[0].wa_name;

       //     }

       // }
       // private void GetSelectedStorageLocationDetails(IList AddList)
       // {
       //     IList list = AddList as IList;
       //     List<MM_M001_PopUp> GetSelectedCostCentreDetailsTemp = list.Cast<MM_M001_PopUp>().ToList();
       //     if (GetSelectedCostCentreDetailsTemp.Count > 0)
       //     {

       //         SelectedSEL_T001.stock_location_id = (GetSelectedCostCentreDetailsTemp[0].store_code);
       //         SelectedSEL_T001.stock_location = GetSelectedCostCentreDetailsTemp[0].store_name;

       //     }

       // }
       // private void GetSelectedSalesGroup(IList AddList)
       // {
       //     IList list = AddList as IList;
       //     List<ADM_M001_H_Popup> GetSelectedCostCentreDetailsTemp = list.Cast<ADM_M001_H_Popup>().ToList();
       //     if (GetSelectedCostCentreDetailsTemp.Count > 0)
       //     {

       //         SelectedSEL_T001.sales_grp = (GetSelectedCostCentreDetailsTemp[0].sg_code);
       //         SelectedSEL_T001.sales_grp_person = GetSelectedCostCentreDetailsTemp[0].sg_name;

       //     }

       // }
       // private void GetSelectedSalesOrgnisationDetails(IList AddList)
       // {
       //     IList list = AddList as IList;
       //     List<ADM_M001_A_Popup> GetSelectedCostCentreDetailsTemp = list.Cast<ADM_M001_A_Popup>().ToList();
       //     if (GetSelectedCostCentreDetailsTemp.Count > 0)
       //     {

       //         SelectedSEL_T001.sales_org = (GetSelectedCostCentreDetailsTemp[0].so_code);
       //         SelectedSEL_T001.sales_org_name = GetSelectedCostCentreDetailsTemp[0].sales_org;

       //     }

       // }
       // private void GetSelectedCostCentreDetails(IList AddList)
       // {
       //     IList list = AddList as IList;
       //     List<ACC_M019_Popup> GetSelectedCostCentreDetailsTemp = list.Cast<ACC_M019_Popup>().ToList();
       //     if (GetSelectedCostCentreDetailsTemp.Count > 0)
       //     {

       //         SelectedSEL_T001.cost_center_id = (GetSelectedCostCentreDetailsTemp[0].id);
       //         SelectedSEL_T001.cost_center = GetSelectedCostCentreDetailsTemp[0].cost_center;

       //     }

       // }
       // private void GetSelectedSalesDivisionDetails(IList AddList)
       // {
       //     IList list = AddList as IList;
       //     List<ADM_M001_D_Popup> GetSelectedCostCentreDetailsTemp = list.Cast<ADM_M001_D_Popup>().ToList();
       //     if (GetSelectedCostCentreDetailsTemp.Count > 0)
       //     {

       //         SelectedSEL_T001.sales_div = (GetSelectedCostCentreDetailsTemp[0].div_code);
       //         SelectedSEL_T001.sales_div_name = GetSelectedCostCentreDetailsTemp[0].div_name;

       //     }

       // }
       // private void GetSelectedSalePersonDetails(IList AddList)
       // {
       //     IList list = AddList as IList;
       //     List<ADM_M024_Popup> GetSelectedCostCentreDetailsTemp = list.Cast<ADM_M024_Popup>().ToList();
       //     if (GetSelectedCostCentreDetailsTemp.Count > 0)
       //     {

       //         SelectedSEL_T001.sales_person = Convert.ToInt32(GetSelectedCostCentreDetailsTemp[0].id);
       //         SelectedSEL_T001.sales_person_name = GetSelectedCostCentreDetailsTemp[0].name;

       //     }

       // }
       // private void GetSelectedItemcategoryDetails(IList AddList)
       // {
       //     try
       //     {
       //         List<SYS_M003_PopUp> items1 = AddList.Cast<SYS_M003_PopUp>().ToList();
       //         if (items1.Count() > 0)
       //         {
       //             if (SO_Dtails.Count > 0 && dgSelectedIndex != -1 && SO_Dtails.Count > dgSelectedIndex)
       //             {
       //                 SO_Dtails[dgSelectedIndex].item_cat_id = items1[0].sditem_cat_code;
       //                 SO_Dtails[dgSelectedIndex].item_cat_id = items1[0].sditem_cat_code;
       //             }
       //         }
       //     }
       //     catch { }

       // }
       // private void GetSelecteddistributionchannelDetails(IList AddList)
       // {
       //     IList list = AddList as IList;
       //     List<ADM_M001_C_Popup> GetSelectedCostCentreDetailsTemp = list.Cast<ADM_M001_C_Popup>().ToList();
       //     if (GetSelectedCostCentreDetailsTemp.Count > 0)
       //     {

       //         SelectedSEL_T001.distribution_channel = (GetSelectedCostCentreDetailsTemp[0].dc_code);
       //         SelectedSEL_T001.distribution_channel_name = GetSelectedCostCentreDetailsTemp[0].dc_name;

       //     }

       // }
       // private void GetSelectedCurrencyDetails(IList AddList)
       // {
       //     IList list = AddList as IList;
       //     List<ADM_M037_Popup> GetSelectedCostCentreDetailsTemp = list.Cast<ADM_M037_Popup>().ToList();
       //     if (GetSelectedCostCentreDetailsTemp.Count > 0)
       //     {

       //         SelectedSEL_T001.doc_currency = (GetSelectedCostCentreDetailsTemp[0].id);
       //         SelectedSEL_T001.doc_currency_name = GetSelectedCostCentreDetailsTemp[0].curr_name;

       //     }

       // }
       // private void GetSelectedSalesOfficeDetails(IList AddList)
       // {
       //     IList list = AddList as IList;
       //     List<ADM_M001_I_Popup> GetSelectedCostCentreDetailsTemp = list.Cast<ADM_M001_I_Popup>().ToList();
       //     if (GetSelectedCostCentreDetailsTemp.Count > 0)
       //     {

       //         //SelectedSEL_T001.sales_office = (GetSelectedCostCentreDetailsTemp[0].soff_code);
       //         SelectedSEL_T001.sales_office_person = GetSelectedCostCentreDetailsTemp[0].sales_off;

       //     }

       // }
       // private void AddItems(IList ItemsList)
       // {
       //     IList list = ItemsList as IList;
       //     List<CRM_T001B_ItemPopup_sale> SelectedItemsDetailsTemp = list.Cast<CRM_T001B_ItemPopup_sale>().ToList();

       //     if (SelectedItemsDetailsTemp.Count > 0)
       //     {
       //         SelectedSEL_T001_B.item_id = Convert.ToInt32(SelectedItemsDetailsTemp[0].Srno);
       //     }
       // }
       // private void GetSelectedItemsDetails(IList ItemsList)
       // {
       //     try
       //     {
       //         if (dgSelectedIndex != -1 && ItemsList.Count > 0)
       //         {
       //             IList list = ItemsList as IList;
       //             List<CRM_T001B_ItemPopup_sale> SelectedItemsDetailsTemp = list.Cast<CRM_T001B_ItemPopup_sale>().ToList();
       //             if (SelectedItemsDetailsTemp.Count > 0)
       //             {
       //                 if (SO_Dtails != null)
       //                 {
       //                     var q = SO_Dtails.Where(X => X.item_id == SelectedItemsDetailsTemp[0].Srno).FirstOrDefault();
       //                     int x = SO_Dtails.IndexOf(SO_Dtails.Where(X => X.item_id == SelectedItemsDetailsTemp[0].Srno).FirstOrDefault());

       //                     if (x == -1 && q == null && SO_Dtails.Count == dgSelectedIndex && SelectedItemsDetailsTemp[0].Select == true)
       //                     {
       //                         SelectedCatItemsDtls = (CRM_T001B_ItemPopup_sale)SelectedItemsDetailsTemp[0];
       //                         SO_Dtails.Add(new SEL_T001_B()
       //                         {
       //                             item_id = SelectedItemsDetailsTemp[0].Srno,
       //                             item_code = SelectedItemsDetailsTemp[0].CstmrItmCod,
       //                             Description = SelectedItemsDetailsTemp[0].CstmrItmDesc,
       //                             uom = SelectedItemsDetailsTemp[0].UnitCode,
       //                             UOMNm = SelectedItemsDetailsTemp[0].unit_name,
       //                             unit_price = SelectedItemsDetailsTemp[0].Brate,
       //                             item_name = SelectedItemsDetailsTemp[0].CstmrItmDesc,
       //                             Stockable = Convert.ToBoolean(SelectedItemsDetailsTemp[0].Stockble),
       //                             SubCategCod = SelectedItemsDetailsTemp[0].SubCategCod,
       //                             tax_id = SelectedItemsDetailsTemp[0].tax_id,
       //                             active = true
       //                         });
       //                         SO_Dtails.Where(l => l.item_id == SelectedItemsDetailsTemp[0].ItemId).ToList().ForEach(i => i.Description = (""));
       //                     }
       //                     else if (SelectedItemsDetailsTemp[0].Select == false && q != null && SO_Dtails[x].id == 0)//&& SO_Dtails[x].id == 0
       //                     {
       //                         if (x >= 0)
       //                         {
       //                             SO_Dtails.RemoveAt(x);
       //                         }
       //                     }
       //                     else if (SelectedItemsDetailsTemp[0].Select == true && q == null && SO_Dtails[x].id == 0) // && r != null && r >= 0)
       //                     {
       //                         if (SO_Dtails[dgSelectedIndex].item_id != SelectedItemsDetailsTemp[0].Srno)
       //                         {
       //                             int popUpItemIndex = MCTemp.CatItems.IndexOf(MCTemp.CatItems.Where(o => o.Srno == SO_Dtails[dgSelectedIndex].item_id).FirstOrDefault());
       //                             MCTemp.CatItems.Where(o => o.Srno == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(t => t.Select = false);
       //                         }
       //                         SO_Dtails[dgSelectedIndex].item_id = SelectedItemsDetailsTemp[0].Srno;
       //                         SO_Dtails[dgSelectedIndex].item_code = SelectedItemsDetailsTemp[0].CstmrItmCod;
       //                         SO_Dtails[dgSelectedIndex].Description = SelectedItemsDetailsTemp[0].CstmrItmDesc;
       //                         SO_Dtails[dgSelectedIndex].uom = SelectedItemsDetailsTemp[0].UnitCode;
       //                         SO_Dtails[dgSelectedIndex].UOMNm = SelectedItemsDetailsTemp[0].unit_name;
       //                         SO_Dtails[dgSelectedIndex].unit_price = SelectedItemsDetailsTemp[0].Brate;
       //                         SO_Dtails[dgSelectedIndex].item_name = SelectedItemsDetailsTemp[0].CstmrItmDesc;
       //                         SO_Dtails[dgSelectedIndex].Stockable = Convert.ToBoolean(SelectedItemsDetailsTemp[0].Stockble);
       //                         SO_Dtails[dgSelectedIndex].SubCategCod = SelectedItemsDetailsTemp[0].SubCategCod;
       //                         SO_Dtails[dgSelectedIndex].SubCategCod = SelectedItemsDetailsTemp[0].tax_id;
       //                         SO_Dtails[dgSelectedIndex].active = true;


       //                     }
       //                 }
       //                 uomCollection = CollectionViewSource.GetDefaultView(MC.uoms);
       //                 uomCollection.Filter = new Predicate<object>(uomFilter);
       //                 //try
       //                 //{

       //                 //    MCTemp.CatItems.Where(t => t.ItemId == SO_Dtails[dgSelectedIndex - 1].item_id).ToList().ForEach(t => t.Select = false);

       //                 //}
       //                 //catch
       //                 //{

       //                 //}
       //             }
       //         }


       //     }
       //     catch (Exception ex)
       //     {
       //         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //         showMessageService.ButtonSetup = DialogButton.Ok;
       //         showMessageService.Caption = "Message";
       //         showMessageService.Text = String.Format(ex.Message, this.Title);
       //         showMessageService.ShowMessage();
       //     }

       // }
       // private void GetSelectedStorageDetails(IList UomList)
       // {
       //     try
       //     {
       //         IList list = UomList as IList;
       //         List<MM_M001_PopUp> SelectedUomDetailsTemp = list.Cast<MM_M001_PopUp>().ToList();

       //         if (SelectedUomDetailsTemp.Count > 0 && dgSelectedIndex != -1)
       //         {

       //             if (SO_Dtails.Count() > dgSelectedIndex)
       //             {
       //                 SO_Dtails[dgSelectedIndex].storage_loc = SelectedUomDetailsTemp[0].store_code;
       //                 SO_Dtails[dgSelectedIndex].storage_location = SelectedUomDetailsTemp[0].store_name;
       //             }

       //         }
       //     }
       //     catch (Exception ex)
       //     {
       //         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //         showMessageService.ButtonSetup = DialogButton.Ok;
       //         showMessageService.Caption = "Message";
       //         showMessageService.Text = String.Format(ex.Message, this.Title);
       //         showMessageService.ShowMessage();
       //     }
       // }
       // private void GetSelectedWarehouseDetails(IList UomList)
       // {
       //     try
       //     {
       //         IList list = UomList as IList;
       //         List<MM_M002_PopUp> SelectedUomDetailsTemp = list.Cast<MM_M002_PopUp>().ToList();

       //         if (SelectedUomDetailsTemp.Count > 0 && dgSelectedIndex != -1)
       //         {

       //             if (SO_Dtails.Count() > dgSelectedIndex)
       //             {
       //                 SO_Dtails[dgSelectedIndex].warehouse_id = SelectedUomDetailsTemp[0].wa_code;
       //                 SO_Dtails[dgSelectedIndex].warehouse = SelectedUomDetailsTemp[0].wa_name;
       //             }

       //         }
       //     }
       //     catch (Exception ex)
       //     {
       //         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //         showMessageService.ButtonSetup = DialogButton.Ok;
       //         showMessageService.Caption = "Message";
       //         showMessageService.Text = String.Format(ex.Message, this.Title);
       //         showMessageService.ShowMessage();
       //     }
       // }
       // private void GetSelectedUomDetails(IList UomList)
       // {
       //     try
       //     {
       //         IList list = UomList as IList;
       //         List<ADM_M038_B_PopUp> SelectedUomDetailsTemp = list.Cast<ADM_M038_B_PopUp>().ToList();

       //         if (SelectedUomDetailsTemp.Count > 0 && dgSelectedIndex != -1)
       //         {
       //             var q = SO_Dtails.Where(X => X.uom == SelectedUomDetailsTemp[0].id).FirstOrDefault();

       //             if (q != null)
       //             {
       //                 if (SO_Dtails.Count() > dgSelectedIndex)
       //                 {
       //                     SO_Dtails[dgSelectedIndex].uom = SelectedUomDetailsTemp[0].id;
       //                     SO_Dtails[dgSelectedIndex].UOMNm = SelectedUomDetailsTemp[0].unit_name;
       //                 }
       //             }
       //             else
       //             {
       //                 if (SO_Dtails.Count() <= dgSelectedIndex)
       //                 {
       //                     SO_Dtails.Add(new SEL_T001_B() { uom = SelectedUomDetailsTemp[0].id, UOMNm = SelectedUomDetailsTemp[0].unit_name });
       //                 }
       //                 else
       //                 {
       //                     SO_Dtails[dgSelectedIndex].uom = SelectedUomDetailsTemp[0].id;
       //                     SO_Dtails[dgSelectedIndex].UOMNm = SelectedUomDetailsTemp[0].unit_name;
       //                 }
       //             }
       //         }
       //     }
       //     catch (Exception ex)
       //     {
       //         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //         showMessageService.ButtonSetup = DialogButton.Ok;
       //         showMessageService.Caption = "Message";
       //         showMessageService.Text = String.Format(ex.Message, this.Title);
       //         showMessageService.ShowMessage();
       //     }
       // }
       // private void GetSelectedJournalDetails(IList PayTmList)
       // {
       //     IList list = PayTmList as IList;
       //     List<ACC_M005_PopUp> SelectedPayTmDetailsTemp = list.Cast<ACC_M005_PopUp>().ToList();

       //     if (SelectedPayTmDetailsTemp.Count > 0)
       //     {
       //         SelectedSEL_T001.journal_id = SelectedPayTmDetailsTemp[0].id;
       //         SelectedSEL_T001.journal_name = SelectedPayTmDetailsTemp[0].journal_name;
       //     }
       // }
       // private void GetSelectedVolumeUomDetails(IList PayTmList)
       // {
       //     IList list = PayTmList as IList;
       //     List<ADM_M038_B_PopUp> SelectedPayTmDetailsTemp = list.Cast<ADM_M038_B_PopUp>().ToList();

       //     if (SelectedPayTmDetailsTemp.Count > 0)
       //     {
       //         SelectedSEL_T001.volumeunitid = SelectedPayTmDetailsTemp[0].id;
       //         SelectedSEL_T001.volumeunit = SelectedPayTmDetailsTemp[0].unit_name;
       //     }
       // }
       // private void GetSelectedWeightUomDetails(IList PayTmList)
       // {
       //     IList list = PayTmList as IList;
       //     List<ADM_M038_B_PopUp> SelectedPayTmDetailsTemp = list.Cast<ADM_M038_B_PopUp>().ToList();

       //     if (SelectedPayTmDetailsTemp.Count > 0)
       //     {
       //         SelectedSEL_T001.weightunitid = SelectedPayTmDetailsTemp[0].id;
       //         SelectedSEL_T001.weightunit = SelectedPayTmDetailsTemp[0].unit_name;
       //     }
       // }
       // private void GetSelectedPayTmDetails(IList PayTmList)
       // {
       //     IList list = PayTmList as IList;
       //     List<ACC_M007_PopUp> SelectedPayTmDetailsTemp = list.Cast<ACC_M007_PopUp>().ToList();

       //     if (SelectedPayTmDetailsTemp.Count > 0)
       //     {
       //         SelectedSEL_T001.p_term_code = SelectedPayTmDetailsTemp[0].p_term_code;
       //         SelectedSEL_T001.p_term = SelectedPayTmDetailsTemp[0].p_term;
       //     }
       // }
       // private void GetSelectedDocTypeDetails(IList TaxList)
       // {
       //     IList list = TaxList as IList;
       //     List<SYS_M002_Popup> SelectedTaxDetailsTemp = list.Cast<SYS_M002_Popup>().ToList();
       //     if (SelectedTaxDetailsTemp.Count > 0)
       //     {
       //         SelectedSEL_T001.doc_type_id = SelectedTaxDetailsTemp[0].doc_type;

       //     }
       // }
       // private void GetSelectedTaxDetails(IList TaxList)
       // {
       //     IList list = TaxList as IList;
       //     List<ACC_M013_PopUp> SelectedTaxDetailsTemp = list.Cast<ACC_M013_PopUp>().ToList();
       //     if (SelectedTaxDetailsTemp.Count > 0)
       //     {
       //         var q = SO_Dtails.Where(X => X.tax_id == SelectedTaxDetailsTemp[0].description).FirstOrDefault();
       //         var r = SelectedTaxDetailsTemp.IndexOf(SelectedTaxDetailsTemp.Where(X => X.description == SelectedTaxDetailsTemp[0].description).FirstOrDefault());

       //     }
       // }
       // private void CellChangeUpdate(IList DataList)
       // {
       //     IList list = DataList as IList;
       //     if (list == null) return;
       //     List<SEL_T001_B> SelectedItemsDetailsTemp = list.Cast<SEL_T001_B>().ToList();
       //     if (dgSelectedIndex != -1 && SO_Dtails.Count > 0 && SO_Dtails.Count > dgSelectedIndex)
       //     {
       //         if (SO_Dtails[dgSelectedIndex].item_id != null)
       //         {
       //             SO_Dtails[dgSelectedIndex].sub_total = ((SO_Dtails[dgSelectedIndex].quantity * SO_Dtails[dgSelectedIndex].unit_price) - (SO_Dtails[dgSelectedIndex].quantity * SO_Dtails[dgSelectedIndex].unit_price) * SO_Dtails[dgSelectedIndex].discount / 100);

       //             SelectedSEL_T001.untax_amt = SO_Dtails.Sum(t => t.sub_total);
       //             SelectedSEL_T001.total_amt = SelectedSEL_T001.untax_amt + SelectedSEL_T001.tax_amt;
       //         }
       //         else { SO_Dtails[dgSelectedIndex] = null; }
       //     }
       //     try
       //     {
       //         string tempTax = SelectedItemsDetailsTemp[dgSelectedIndex].tax_id;
       //         SelectedItems = GetDict(tempTax);
       //     }
       //     catch
       //     {

       //     }
       //     TaxRowCalculation();

       // }
       // private void Load()
       // {

       //     //if ((SelectedSEL_T001.ref_doc_no == "") || (SelectedSEL_T001.ref_doc_no == null))
       //     //{
       //     //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //     //    showMessageService.ButtonSetup = DialogButton.Ok;
       //     //    showMessageService.Caption = "Message";
       //     //    showMessageService.Text = String.Format("Please Select Ref. Doc .No. First..", this.Title);
       //     //    showMessageService.ShowMessage();
       //     //}
       //     //else
       //     //{
       //         try
       //         {                    
       //             string company = AppSessionState.comp_code.ToString() + "@" + AppSessionState.location_Id.ToString() + "@" + SelectedSEL_T001.ref_doc_no;
       //             MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MC, "SEL_T001_Data", "SalesOrderMaster", "CRM", "Enquiry-QuotationDetailsForSO", 0, company);

       //             EnquiryList = new ObservableCollection<Inquiry_PopUp>();
       //             EnquiryList = new ObservableCollection<Inquiry_PopUp>(MC.InqDetailsList);

       //             EnquiryschList = new ObservableCollection<SEL_T002_B>();
       //             EnquiryschList = new ObservableCollection<SEL_T002_B>(MC.Deliveryschedule);
       //             FluteList = MC.FluteList;
       //             var itemlist = (from o in EnquiryList
       //                             where o.doc_no == SelectedSEL_T001.ref_doc_no
       //                             select o).ToList();

       //             SO_Dtails = new ObservableCollection<SEL_T001_B>();
       //             foreach (var item in itemlist)
       //             {
       //                 SO_Dtails.Add(new SEL_T001_B
       //                 {
       //                     sub_total = Convert.ToDecimal(item.sub_total),
       //                     item_cat_id = item.item_cat_id,
       //                     item_id = item.item_id,
       //                     item_code = item.CstmrItmCod,
       //                     item_name = item.CstmrItmDesc,
       //                     //item_code = item.ItemName,//new
       //                     //item_name = item.Description,//new
       //                     uom = item.uom,
       //                     UOMNm = item.UOMNm,
       //                     unit_price = Convert.ToDecimal(item.unit_price),
       //                     quantity = Convert.ToDecimal(item.quantity),
       //                     tax_id = item.tax_id,
       //                     SubCategCod = Convert.ToString(item.SubCategCod),
       //                     stocking_unit = item.stocking_unit,
       //                     stocking_unit1 = item.stocking_unit,
       //                     discount = Convert.ToDecimal(item.discount),
       //                     Stockable = Convert.ToBoolean(item.Stockable),
       //                     active = true
       //                 });
       //                 if (SelectedSEL_T001.customer_id == null)
       //                 {
       //                     SelectedSEL_T001.customer_id = item.customer_id;
       //                     SelectedSEL_T001.PartyNm = item.PartyNm;
       //                 }

       //                 SelectedSEL_T001.amt_inword = item.amt_inword;
       //                 SelectedSEL_T001.tax_amt = item.tax_amt;
       //                 SelectedSEL_T001.untax_amt = item.untax_amt;
       //                 SelectedSEL_T001.total_amt = item.total_amt;

       //                 SelectedSEL_T001.bill_address_id = item.bill_address_id;
       //                 SelectedSEL_T001.InvicAdd = item.InvicAdd;
       //                 SelectedSEL_T001.business_area = item.business_area;
       //                 SelectedSEL_T001.buyer = item.buyer;
       //                 SelectedSEL_T001.ContPersnNm = item.ContPersnNm;
       //                 SelectedSEL_T001.cost_center = item.cost_center;
       //                 SelectedSEL_T001.cost_center_id = item.cost_center_id;

       //                 SelectedSEL_T001.del_address = item.del_address;
       //                 SelectedSEL_T001.DelAdd = item.DelAdd;

       //                 SelectedSEL_T001.distribution_channel = item.distribution_channel;
       //                 SelectedSEL_T001.distribution_channel_name = item.distribution_channel_name;

       //                 SelectedSEL_T001.doc_currency = item.doc_currency;

       //                 SelectedSEL_T001.doc_currency_name = item.doc_currency_name;

       //                 SelectedSEL_T001.expect_date = item.expect_date;


       //                 SelectedSEL_T001.invoice_method = item.invoice_method;
       //                 SelectedSEL_T001.journal_id = item.journal_id;
       //                 SelectedSEL_T001.journal_name = item.journal_name;
       //                 SelectedSEL_T001.min_planned_date = item.min_planned_date;

       //                 SelectedSEL_T001.p_term = item.p_term;
       //                 SelectedSEL_T001.p_term_code = item.p_term ;
       //                 SelectedSEL_T001.profit_center = item.profit_center;


       //                 SelectedSEL_T001.sales_div = item.sales_div;
       //                 SelectedSEL_T001.sales_div_name = item.sales_div_name;

       //                 SelectedSEL_T001.sales_grp = item.sales_grp;
       //                 SelectedSEL_T001.sales_grp_person = item.sales_grp_person;
       //                 SelectedSEL_T001.sales_office = item.sales_office;
       //                 SelectedSEL_T001.sales_office_person = item.sales_office_person;
       //                 SelectedSEL_T001.sales_org = item.sales_org;
       //                 SelectedSEL_T001.sales_org_name = item.sales_org_name;
       //                 SelectedSEL_T001.sales_person = item.sales_person;
       //                 SelectedSEL_T001.sales_person_name = item.sales_person_name;
       //                 SelectedSEL_T001.ship_to = item.ship_to;
       //                 SelectedSEL_T001.ship_to_party = item.ship_to_party;
       //                // SelectedSEL_T001.shipped = item.shipped;
       //                 SelectedSEL_T001.shipped_date = item.shipped_date;

       //                 SelectedSEL_T001.stock_location = item.stock_location;
       //                 SelectedSEL_T001.stock_location_id = item.stock_location_id;

       //                 SelectedSEL_T001.warehouse_id = item.warehouse_id;
       //                 SelectedSEL_T001.warehouse = item.warehouse;

       //                 try
       //                 {
       //                     //if (Selectedpartylist[0].stockingunit != "")
       //                     {
       //                         string[] values1 = item.ItemName.Split('\t');
       //                         string Reqstockingunit = "";
       //                         string[] values = item.stocking_unit.Split('/');
       //                         for (int y = values.Count() - 1; y >= 0; y--)
       //                         {
       //                             var stockingunit = (from o in FluteList
       //                                                 where o.code == Convert.ToInt32(values[y].ToString())
       //                                                 select o).ToList();
       //                             {
       //                                 Reqstockingunit = Reqstockingunit + "\t" + ":" + stockingunit[0].Type + ":" + stockingunit[0].code;
       //                             }
       //                         }
       //                         SO_Dtails.Where(l => l.item_id == item.item_id).ToList().ForEach(i => i.Description = (""));
       //                         SO_Dtails.Where(l => l.item_id == item.item_id).ToList().ForEach(i => i.Description = (values1[0] + Reqstockingunit));
       //                     }



       //                 }
       //                 catch
       //                 {

       //                 }
       //                 Update();
       //             }
       //             try
       //             {
       //                 dgPOdeliveryschedule = new ObservableCollection<SEL_T002_B>();
       //                 dgPOdeliveryschedule = EnquiryschList;
       //             }
       //             catch
       //             {

       //             }
       //             try
       //             {
       //                 TaxTableCalculation();
       //             }
       //             catch
       //             {

       //             }

       //         }
       //         catch
       //         {

       //         }
       //     //}


       // }
       // private void LoadInitialData()
       // {
       //     try
       //     {
       //         string company = AppSessionState.comp_code.ToString() + "@" + AppSessionState.location_Id.ToString();
       //         MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MC, "SEL_T001_Data", "SalesOrderMaster", "CRM", "LoadAll_StockTransfer", 0, company);
       //         SelectedList = MC.Sales_Order;
       //         //AddListNew = MC.addresses;

       //         //20 Aug
       //         doc_typeCollection = CollectionViewSource.GetDefaultView(MC.DocTypeList);
       //         doc_typeCollection.Filter = new Predicate<object>(doctype_Filter);

       //         doc_SubCategoryCollection = CollectionViewSource.GetDefaultView(MC.DocsubCategoryList);
       //         doc_SubCategoryCollection.Filter = new Predicate<object>(docsubtype_Filter);

       //         doc_CategoryCollection = CollectionViewSource.GetDefaultView(MC.DocCategoryList);

       //         currencyCollection = CollectionViewSource.GetDefaultView(MC.currencyList);
       //         currencyCollection.Filter = new Predicate<object>(currency_Filter);

       //         reference_docCollection = CollectionViewSource.GetDefaultView(MC.DocNoList);
       //         reference_docCollection.Filter = new Predicate<object>(refdocno_Filter);

       //         dgrefdocno = new ObservableCollection<SEL_T001_Popup>(MC.DocNoList);
       //         //reference_docCollection = CollectionViewSource.GetDefaultView(MC.reference_docList);
       //         //reference_docCollection.Filter  = new Predicate<object>(refdocno_Filter);

       //         sales_orgCollection = CollectionViewSource.GetDefaultView(MC.sales_orgList);
       //         sales_orgCollection.Filter = new Predicate<object>(saleorg_Filter);

       //         distribution_channelCollection = CollectionViewSource.GetDefaultView(MC.distribution_channelList);
       //         distribution_channelCollection.Filter = new Predicate<object>(distChannel_Filter);

       //         sales_divisionCollection = CollectionViewSource.GetDefaultView(MC.sales_divisionList);
       //         sales_divisionCollection.Filter = new Predicate<object>(saledivision_Filter);

       //         sales_personCollection = CollectionViewSource.GetDefaultView(MC.sales_personList);
       //         sales_personCollection.Filter = new Predicate<object>(sales_person_Filter);

       //         sales_officeCollection = CollectionViewSource.GetDefaultView(MC.sales_officeList);
       //         sales_officeCollection.Filter = new Predicate<object>(sales_ofc_Filter);

       //         sales_groupCollection = CollectionViewSource.GetDefaultView(MC.sales_groupList);
       //         sales_groupCollection.Filter = new Predicate<object>(sales_grp_Filter);

       //         cost_centerCollection = CollectionViewSource.GetDefaultView(MC.Cost_centreList);
       //         cost_centerCollection.Filter = new Predicate<object>(cost_centre_Filter);

       //         JournalCollection = CollectionViewSource.GetDefaultView(MC.journalList);
       //         JournalCollection.Filter = new Predicate<object>(journal_Filter);

       //         profit_centerCollection = CollectionViewSource.GetDefaultView(MC.Profit_centreList);
       //         profit_centerCollection.Filter = new Predicate<object>(profit_centre_Filter);

       //         stock_locationCollection = CollectionViewSource.GetDefaultView(MC.Storage_locationList);
       //         stock_locationCollection.Filter = new Predicate<object>(StorageLocation_Filter);

       //         warehouse_locationCollection = CollectionViewSource.GetDefaultView(MC.WarehouseList);
       //         warehouse_locationCollection.Filter = new Predicate<object>(Warehouse_Filter);


       //         DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
       //         DataGridCollection.Filter = new Predicate<object>(Filter);

       //         PartyCollection = CollectionViewSource.GetDefaultView(MC.Parties.ToList());
       //         PartyCollection.Filter = new Predicate<object>(PartyFilter);

       //         ShipPartyCollection = CollectionViewSource.GetDefaultView(MC.Parties.ToList());
       //         ShipPartyCollection.Filter = new Predicate<object>(shipPartyFilter);

       //         LoctnCollection = CollectionViewSource.GetDefaultView(MC.Locations);
       //         LoctnCollection.Filter = new Predicate<object>(LoctnFilter);

       //         EmpCollection = CollectionViewSource.GetDefaultView(MC.Employees);
       //         EmpCollection.Filter = new Predicate<object>(EmpFilter);

       //         PaytmCollection = CollectionViewSource.GetDefaultView(MC.PayTerms);

       //         ValidatedbyCollection = CollectionViewSource.GetDefaultView(MC.ValidatorByList);
       //         ValidatedbyCollection.Filter = new Predicate<object>(ValidatorFilter);

       //         if (MC.PayTerms.ToList() != null && MC.PayTerms.ToList().Count == 1)
       //         {
       //             SelectedSEL_T001.p_term = MC.PayTerms.ToList()[0].p_term;
       //             SelectedSEL_T001.p_term_code = MC.PayTerms.ToList()[0].p_term_code;

       //         }
       //         else
       //         {
       //             SelectedSEL_T001.p_term = null;
       //             SelectedSEL_T001.p_term_code = null;

       //         }
       //         PaytmCollection.Filter = new Predicate<object>(FilterPayTerms);

       //         TaxCollection = CollectionViewSource.GetDefaultView(MC.TaxList);
       //         try
       //         {

       //             SelectedChildTaxList = MC.TaxList;
       //             var TaxList = (from o in MC.TaxList
       //                            where o.parent_id == null
       //                            select o).ToList();

       //             SelectedTaxList = TaxList;
       //         }
       //         catch
       //         {
       //             SelectedTaxList = MC.TaxList;
       //         }

       //         dgPOItemsFortaxval = CollectionViewSource.GetDefaultView(MC.TaxAccountList);
       //         dgPOItemsFortaxval.Filter = new Predicate<object>(Filtertax);

       //     }
       //     catch (Exception ex)
       //     {
       //         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //         showMessageService.ButtonSetup = DialogButton.Ok;
       //         showMessageService.Caption = "Message";
       //         showMessageService.Text = String.Format(ex.Message, this.Title);
       //         showMessageService.ShowMessage();
       //     }
       // }
       // private void getMailstring()
       // {
       //     try
       //     {
       //         COM_T002_A obj = new COM_T002_A();

       //         obj.subject = "Sales Order ( " + SelectedSEL_T001.sono + " )";
       //         string TEST1 = "<HTML><BODY>";
       //         TEST1 = TEST1 + "<P>Dear sir,";
       //         TEST1 = TEST1 + "<P>Sales Order generated with document no . " + SelectedSEL_T001.sono + " on date . " + Convert.ToDateTime(SelectedSEL_T001.sodate).ToString("mm/dd/yyyy") + "<p> List of items in sales order :";
       //         TEST1 = TEST1 + "";
       //         TEST1 = TEST1 + "<table border=0,cellspacing =10><tr><th>Item Name</th><th>Item Qty </th></tr>";
       //         for (int i = 0; SO_Dtails.Count() > i; i++)
       //         {
       //             TEST1 = TEST1 + "<tr><td>" + SO_Dtails[i].item_name + "</td>" + "<td align=right>" + SO_Dtails[i].quantity + "</td></tr>";
       //         }
       //         TEST1 = TEST1 + "</table></br></br></br></br></br></br> <p>Thank You<p>" + AppSessionState.MailAccount.DisplayName;
       //         TEST1 = TEST1 + "</BODY></HTML>";

       //         if (SelectedSEL_T001.EmailID == null)
       //         { SelectedSEL_T001.EmailID = ""; }
       //         if (buyeremail == null)
       //         { buyeremail = ""; }

       //         string str_mail = SelectedSEL_T001.EmailID;

       //         Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, str_mail, buyeremail, "", obj.subject, TEST1, "");
       //     }
       //     catch (Exception ex)
       //     {
       //         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //         showMessageService.ButtonSetup = DialogButton.Ok;
       //         showMessageService.Caption = "Message";
       //         showMessageService.Text = String.Format(ex.Message, this.Title);
       //         showMessageService.ShowMessage();
       //     }
       // }
       // #endregion

       // #region · Command Actions ·
       // private IEnumerable<T> MakeMeEnumerable<T>(T Entity)
       // {
       //     yield return Entity;
       // }
       // protected override void OnSaveAction(InquiryActionResult<SEL_T001> result)
       // {
       //     try
       //     {
       //         if (SO_Dtails.Count > 0)
       //         {                    
       //                 if (ValidateControls() == true)
       //                 {
       //                     SelectedSEL_T001.add_by = AppSessionState.UserID.ToString();
       //                     SelectedSEL_T001.location_Id = AppSessionState.location_Id;
       //                     SelectedSEL_T001.comp_code = AppSessionState.comp_code;
       //                     SelectedSEL_T001.doc_category_id = "ST";
       //                     SelectedSEL_T001.doc_type_id = "ST";
       //                     ObjectSerializationService objSer = new ObjectSerializationService();
       //                     try
       //                     {
       //                         StockingUnitCalculation();
       //                     }
       //                     catch { }
       //                     SelectedSEL_T001.XmlDataDocument_SEL_T001_B = objSer.ObjectToXML(SO_Dtails);
       //                     SelectedSEL_T001.XmlDataDocument_SEL_T001_C = objSer.ObjectToXML(Tax_Dtails);
       //                     SelectedSEL_T001.XmlDataDocument_SEL_T001_E = objSer.ObjectToXML(dgPOTaxValues1);
       //                     SelectedSEL_T001.XmlDataDocument_SEL_T001_D = objSer.ObjectToXML(dgPOTotalTaxValues);
       //                     SelectedSEL_T001.XmlDataDocument_SEL_T001_F = objSer.ObjectToXML(dgPOdeliveryschedule);
       //                     SelectedSEL_T001.XmlDataDocument_SEL_T001_G = objSer.ObjectToXML(dgscheduledmaster);


       //                     if (blNew == true)
       //                     {
       //                         SelectedSEL_T001 = repository.SaveWithReturnDomainObject<SEL_T001>(SelectedSEL_T001, "SalesOrderMaster", "CRM");
       //                         SelectedList.Insert(0, SelectedSEL_T001);
       //                         this.SelectedSEL_T001.EndEdit();
       //                         _dataGridCollection.Refresh();
       //                         //---------------------------Send Mail                           
       //                         getMailstring();

       //                         blNew = false;
       //                     }
       //                     else if (blNew == false)
       //                     {
       //                         SelectedSEL_T001 = repository.UpdateWithReturnDomainObject<SEL_T001>(SelectedSEL_T001, "SalesOrderMaster", "CRM");
       //                         this.SelectedSEL_T001.EndEdit();
       //                         _dataGridCollection.Refresh();
       //                     }
       //                     if (SelectedSEL_T001.XmlDataDocument_SEL_T001_B != null)
       //                     {
       //                         dgPOTaxValues = new ObservableCollection<SEL_T001_C>();
       //                         dgPOTaxValues1 = new ObservableCollection<SEL_T001_C>();
       //                         dgPOTotalTaxValues = new ObservableCollection<SEL_T001_C>();
       //                         dgPOTaxValues1 = MC.POtaxDetails;
       //                         dgPOItemsForParameterval = CollectionViewSource.GetDefaultView(dgPOTaxValues1);
       //                         dgPOschedule = new ObservableCollection<SalesOrder_deliveryschedule>();
       //                         MC.ParamvalList = MC.ParamvalList;
       //                         for (int i = 0; i < dgPOItemsForParameterval.Cast<SEL_T001_C>().ToList().Count(); i++)
       //                         {
       //                             dgPOTaxValues.Add(dgPOItemsForParameterval.Cast<SEL_T001_C>().ElementAt(i));
       //                         }

       //                         dgscheduledmaster = (ObservableCollection<SEL_T002>)new ObjectSerializationService().XMLToObject(SelectedSEL_T001.XmlDataDocument_SEL_T001_J, MC.DeliveryscheduleMaster);

       //                         MC.SO_Dtails = (ObservableCollection<SEL_T001_B>)new ObjectSerializationService().XMLToObject(SelectedSEL_T001.XmlDataDocument_SEL_T001_B, MC.SO_Dtails);
       //                         MC.PurchaseOrder_deliveryschedule = (ObservableCollection<SalesOrder_deliveryschedule>)new ObjectSerializationService().XMLToObject(SelectedSEL_T001.XmlDataDocument_SEL_T001_H, MC.PurchaseOrder_deliveryschedule);
       //                         MC.Deliveryschedule = (ObservableCollection<SEL_T002_B>)new ObjectSerializationService().XMLToObject(SelectedSEL_T001.XmlDataDocument_SEL_T001_F, MC.Deliveryschedule);
       //                         dgPOdeliveryschedule = MC.Deliveryschedule;
       //                         MC.POTotaltaxDetails = (ObservableCollection<SEL_T001_C>)new ObjectSerializationService().XMLToObject(SelectedSEL_T001.XmlDataDocument_SEL_T001_I, MC.POTotaltaxDetails);
       //                         dgPOschedule = MC.PurchaseOrder_deliveryschedule;
       //                         dgPOTotalTaxValues = MC.POTotaltaxDetails;

       //                         SO_Dtails = new ObservableCollection<SEL_T001_B>();
       //                         SO_Dtails = MC.SO_Dtails;


       //                         try
       //                         {
       //                             foreach (var item in SO_Dtails)
       //                             {
       //                                 SO_Dtails.Where(i => i.min_planned_date == Convert.ToDateTime("01/01/1900")).ToList().ForEach(L => L.min_planned_date = null);
       //                             }

       //                         }
       //                         catch
       //                         {

       //                         }
       //                         foreach (var item in SO_Dtails)
       //                         {
       //                             SO_Dtails.Where(i => i.item_id == item.item_id).Where(i => i.stocking_unit == item.stocking_unit).ToList().ForEach(L => L.stocking_unit1 = item.stocking_unit);
       //                         }
       //                         try
       //                         {
       //                             TaxTableCalculation();
       //                         }
       //                         catch
       //                         {

       //                         }
       //                         Update();
       //                     }
       //                     else
       //                     {
       //                         MCTemp.SO_Dtails = new ObservableCollection<SEL_T001_B>();
       //                         MCTemp.Tax_Dtails = new ObservableCollection<SEL_T001_C>();
       //                     }
       //                     //try
       //                     //{
       //                     //    if (SelectedSEL_T001.ref_doc_no.Contains("IN"))
       //                     //    {
       //                     //        SelectedSEL_T001.ref_doc_type = "Sales Enquiry";
       //                     //    }
       //                     //    if (SelectedSEL_T001.ref_doc_no.Contains("QT"))
       //                     //    {
       //                     //        SelectedSEL_T001.ref_doc_type = "Sales Quotation";
       //                     //    }
       //                     //}
       //                     //catch
       //                     //{

       //                     //}
       //                     _dataGridCollection.Refresh();
       //                 }
                   
       //         }
       //         else
       //         {
       //             IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //             showMessageService.ButtonSetup = DialogButton.Ok;
       //             showMessageService.Caption = "Message";
       //             showMessageService.Text = String.Format("Please Select All Parameter Value", this.Title);
       //             showMessageService.ShowMessage();
       //         }
       //     }
       //     catch (Exception ex)
       //     {
       //         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //         showMessageService.ButtonSetup = DialogButton.Ok;
       //         showMessageService.Caption = "Message";
       //         showMessageService.Text = String.Format(ex.Message, this.Title);
       //         showMessageService.ShowMessage();
       //     }
       // }
       // protected override void OnCreateAction(InquiryActionResult<SEL_T001> result)
       // {

       //     blNew = true;
       //     SelectedSEL_T001 = new SEL_T001();
            
       //     dgPOdeliveryschedule = new ObservableCollection<SEL_T002_B>();
       //     dgPOschedule = new ObservableCollection<SalesOrder_deliveryschedule>();
       //     SO_Dtails = new ObservableCollection<SEL_T001_B>();
       //     Tax_Dtails = new ObservableCollection<SEL_T001_C>();
       //     CatItemsList = new ObservableCollection<CRM_T001B_ItemPopup_sale>();
       //     MCTemp.addresses = new List<ADM_M029_PopUp1>();
       //     InvcAddCollection = CollectionViewSource.GetDefaultView(MCTemp.addresses.ToList());
       //     DelAddCollection = CollectionViewSource.GetDefaultView(MCTemp.addresses.ToList());
       //     //ShipPartyCollection = CollectionViewSource.GetDefaultView(MC.Parties.ToList());
       //     //PartyCollection = CollectionViewSource.GetDefaultView(MC.Parties.ToList());
       //     reference_docCollection = CollectionViewSource.GetDefaultView(MC.DocNoList);
       //     BuyerCollection = CollectionViewSource.GetDefaultView(MCTemp.Contacts);
       //     //LoctnCollection = CollectionViewSource.GetDefaultView(MC.Locations); 
       //     MCTemp.Contacts = new List<ADM_M027_PopUp1>();
       //     BuyerCollection = CollectionViewSource.GetDefaultView(MCTemp.Contacts);
       //     MCTemp.CatItems = new List<CRM_T001B_ItemPopup_sale>();
       //     dgPOTaxValues1 = new ObservableCollection<SEL_T001_C>();
       //     dgPOTotalTaxValues = new ObservableCollection<SEL_T001_C>();
       //     dgPOTaxValues2 = new ObservableCollection<SEL_T001_C>();
       //     dgPOTaxValues3 = new ObservableCollection<SEL_T001_C>();
       //     ParamitemList = new ObservableCollection<ADM_M030_P>();
       //     dgPOTaxValues = new ObservableCollection<SEL_T001_C>();
       //     ParamclearList = new ObservableCollection<ADM_M030_P>();
       //     ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);
       //     ParamitemList1 = new ObservableCollection<ADM_M030_P>();
       //     ItemsCollection = CollectionViewSource.GetDefaultView(MCTemp.CatItems);
       //     dgscheduledmaster = new ObservableCollection<SEL_T002>();
       //     EnquiryList = new ObservableCollection<Inquiry_PopUp>();
       //     EnquiryschList = new ObservableCollection<SEL_T002_B>();
       //     _dataGridCollection.Refresh();
       //     SelectedSEL_T001.sodate = DateTime.Now;
       //     SelectedSEL_T001.ValidateAsync().Wait();

       // }
       // protected override void OnRemoveAction(InquiryActionResult<SEL_T001> result)
       // {
       //     IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //     showMessageService.ButtonSetup = DialogButton.Ok;
       //     showMessageService.Caption = "Delete Changes";
       //     showMessageService.Text =
       //         String.Format(
       //             "This record will delete forever '{0}'",
       //                 this.Title);

       //     if (showMessageService.ShowMessage() == DialogResult.Ok)
       //     {
       //         this.SelectedSEL_T001.CancelEdit();
       //         string response = repository.Delete(SelectedSEL_T001.id, "SalesOrderMaster", "CRM");
       //         SelectedList.Remove(SelectedSEL_T001);
       //         _dataGridCollection.Refresh();
       //         SelectedSEL_T001 = new SEL_T001();
       //         SO_Dtails = new ObservableCollection<SEL_T001_B>();
       //     }
       // }
       // protected override void OnDiscardAction(InquiryActionResult<SEL_T001> result)
       // {
       //     SelectedSEL_T001.CancelEdit();
       // }
       // protected override void OnFevoriteAction(InquiryActionResult<SEL_T001> result)
       // {
       //     SelectedList = SelectedList;
       // }
       // protected override void OnFlipAction(InquiryActionResult<SEL_T001> result)
       // {
       //     SelectedList = SelectedList;
       //     SelectedSEL_T001 = SelectedSEL_T001;
       // }
       // protected override void OnHelpAction(InquiryActionResult<SEL_T001> result)
       // {
       //     SelectedList = SelectedList;
       //     SelectedSEL_T001 = SelectedSEL_T001;
       // }
       // protected override void OnPrintAction(InquiryActionResult<SEL_T001> result)
       // {
       //     SelectedList = SelectedList;
       //     SelectedSEL_T001 = SelectedSEL_T001;
       // }
       // //protected override void OnExportAction(InquiryActionResult<SEL_T001> result)
       // //{
       // //    try
       // //    {
       // //        List<SEL_T001> Export_List = new List<SEL_T001>();
       // //        foreach (var o in DataGridCollection)
       // //        {
       // //            SEL_T001 Data = o as SEL_T001;
       // //            Export_List.Add(Data);
       // //        }

       // //        //--------------------------------------

       // //        ExportToExcel<SEL_T001, List<SEL_T001>> export = new ExportToExcel<SEL_T001, List<SEL_T001>>();
       // //        ICollectionView view = CollectionViewSource.GetDefaultView(Export_List);
       // //        export.dataToPrint = (List<SEL_T001>)view.SourceCollection;

       // //        export.GenerateReport();
       // //    }
       // //    catch (Exception ex)
       // //    {
       // //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       // //        showMessageService.ButtonSetup = DialogButton.Ok;
       // //        showMessageService.Caption = "Message";
       // //        showMessageService.Text = String.Format(ex.Message, this.Title);
       // //        showMessageService.ShowMessage();
       // //    }

       // //}
       // #endregion

       // #region . Filters .

       // #region Filters For Loctn
       // private void FilterCollectionLoctn()
       // {
       //     if (_LoctnCollection != null)
       //     {
       //         _LoctnCollection.Refresh();
       //     }
       // }
       // public string FilterStringLoctn
       // {
       //     get { return _filterStringLoctn; }
       //     set
       //     {
       //         _filterStringLoctn = value;
       //         RaisePropertychanged("FilterStringLoctn");
       //         FilterCollectionLoctn();
       //     }
       // }
       // public bool LoctnFilter(object obj)
       // {
       //     var data = obj as ADM_M003_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterStringLoctn))
       //         {
       //             return (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterStringLoctn.ToLower()));

       //         }
       //         return true;
       //     }
       //     return false;
       // }

       // #endregion

       // #region Filters For sold to party
       // private void FilterCollectionParty()
       // {
       //     if (_PartyCollection != null)
       //     {
       //         _PartyCollection.Refresh();
       //     }
       // }
       // public string FilterStringParty
       // {
       //     get { return _filterStringParty; }
       //     set
       //     {
       //         _filterStringParty = value;
       //         RaisePropertychanged("FilterStringParty");
       //         FilterCollectionParty();
       //     }
       // }
       // public bool PartyFilter(object obj)
       // {
       //     var data = obj as ADM_M028_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterStringParty))
       //         {
       //             return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterStringParty.ToLower()));

       //         }
       //         return true;
       //     }
       //     return false;
       // }

       // #endregion


       // #region Filters For ship to party
       // private void FilterCollectionShipParty()
       // {
       //     if (_ShipPartyCollection != null)
       //     {
       //         _ShipPartyCollection.Refresh();
       //     }
       // }

       // private string _filterStringShipParty;
       // public string FilterStringShipParty
       // {
       //     get { return _filterStringShipParty; }
       //     set
       //     {
       //         _filterStringShipParty = value;
       //         RaisePropertychanged("FilterStringShipParty");
       //         FilterCollectionShipParty();
       //     }
       // }
       // public bool shipPartyFilter(object obj)
       // {
       //     var data = obj as ADM_M028_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterStringShipParty))
       //         {
       //             return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterStringShipParty.ToLower()));

       //         }
       //         return true;
       //     }
       //     return false;
       // }

       // #endregion


       // #region Filters For Add
       // private void FilterCollectionAdd()
       // {
       //     if (_InvcAddCollection != null)
       //     {
       //         _InvcAddCollection.Refresh();
       //     }
       //     if (_DelAddCollection != null)
       //     {
       //         _DelAddCollection.Refresh();
       //     }

       // }
       // public string FilterStringAdd
       // {
       //     get { return _filterStringAdd; }
       //     set
       //     {
       //         _filterStringAdd = value;
       //         RaisePropertychanged("FilterStringAdd");
       //         FilterCollectionAdd();
       //     }
       // }
       // public bool AddFilter(object obj)
       // {
       //     var data = obj as ADM_M029_PopUp1;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterStringAdd))
       //         {
       //             return (data.Add1 != null && data.Add1.ToLower().Contains(_filterStringAdd.ToLower()) ||
       //                    (data.Location != null) && data.Location.ToLower().Contains(_filterStringAdd.ToLower()) ||
       //                    (data.AddType != null) && data.AddType.ToLower().Contains(_filterStringAdd.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // #endregion

       // #region Filters For Buyer
       // private void FilterCollectionBuyer()
       // {
       //     if (_BuyerCollection != null)
       //     {
       //         _BuyerCollection.Refresh();
       //     }
       // }
       // public string FilterStringBuyer
       // {
       //     get { return _filterStringBuyer; }
       //     set
       //     {
       //         _filterStringBuyer = value;
       //         RaisePropertychanged("FilterStringBuyer");
       //         FilterCollectionBuyer();
       //     }
       // }
       // public bool BuyerFilter(object obj)
       // {
       //     var data = obj as ADM_M027_PopUp1;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterStringBuyer))
       //         {
       //             return (data.PersnLName != null && data.PersnLName.ToLower().Contains(_filterStringBuyer.ToLower())) ||
       //                 (data.PersnFName != null && data.PersnFName.ToLower().Contains(_filterStringBuyer.ToLower())) ||
       //                 (data.PersnMName != null && data.PersnMName.ToLower().Contains(_filterStringBuyer.ToLower()));


       //         }
       //         return true;
       //     }
       //     return false;
       // }



       // private void FilterCollectionValidatedBy()
       // {
       //     if (_ValidatedbyCollection != null)
       //     {
       //         _ValidatedbyCollection.Refresh();
       //     }
       // }
       // public string FilterStringvalidatedby
       // {
       //     get { return _filterStringvalidatedby; }
       //     set
       //     {
       //         _filterStringvalidatedby = value;
       //         RaisePropertychanged("FilterStringvalidatedby");
       //         FilterCollectionValidatedBy();
       //     }
       // }

       // private void Active(bool select)
       // {

       //     try
       //     {
       //         TaxTableCalculation();
       //         TaxRowCalculation();

       //     }
       //     catch
       //     {

       //     }


       // }
       // public bool ValidatorFilter(object obj)
       // {
       //     var data = obj as ADM_M024_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterStringvalidatedby))
       //         {
       //             return (data.EmpFName != null && data.EmpFName.ToLower().Contains(_filterStringvalidatedby.ToLower()))
       //              ;


       //         }
       //         return true;
       //     }
       //     return false;
       // }


       // private string _filterString_itemcategory;
       // public string FilterString_itemcategory
       // {
       //     get { return _filterString_itemcategory; }
       //     set
       //     {
       //         _filterString_itemcategory = value;
       //         RaisePropertychanged("_filterString_itemcategory");
       //         FilterCollectionitemcategory();
       //     }
       // }
       // private void FilterCollectionitemcategory()
       // {
       //     if (doc_SubCategoryCollection != null)
       //     {
       //         doc_SubCategoryCollection.Refresh();
       //     }
       // }
       // public bool Filteritemcategory(object obj)
       // {
       //     var data = obj as SYS_M003_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_itemcategory))
       //         {
       //             return (data.sditem_cat_code != null && data.sditem_cat_code.ToString().ToLower().Contains(_filterString_itemcategory.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }

       // #endregion

       // #region Filters For Emp
       // private void FilterCollectionEmp()
       // {
       //     if (_EmpCollection != null)
       //     {
       //         _EmpCollection.Refresh();
       //     }
       // }
       // public string FilterStringEmp
       // {
       //     get { return _filterStringEmp; }
       //     set
       //     {
       //         _filterStringEmp = value;
       //         RaisePropertychanged("FilterStringEmp");
       //         FilterCollectionEmp();
       //     }
       // }
       // public bool EmpFilter(object obj)
       // {
       //     var data = obj as ADM_M024_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterStringEmp))
       //         {
       //             return (data.EmpLName != null && data.EmpLName.ToLower().Contains(_filterStringEmp.ToLower())) ||
       //                     (data.EmpFName != null && data.EmpFName.ToLower().Contains(_filterStringEmp.ToLower())) ||
       //                     (data.EmpMName != null && data.EmpMName.ToLower().Contains(_filterStringEmp.ToLower()));

       //         }
       //         return true;
       //     }
       //     return false;
       // }

       // #endregion

       // #region Filters For Items
       // private void FilterCollectionItems()
       // {
       //     if (_ItemsCollection != null)
       //     {
       //         _ItemsCollection.Refresh();
       //     }
       // }
       // public string FilterStringItems
       // {
       //     get { return _filterStringItems; }
       //     set
       //     {
       //         _filterStringItems = value;
       //         RaisePropertychanged("FilterStringItems");
       //         FilterCollectionItems();
       //     }
       // }
       // public bool ItemsFilter(object obj)
       // {
       //     var data = obj as CRM_T001B_ItemPopup_sale;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterStringItems))
       //         {
       //             return ((data.ItemCode != null) && data.ItemCode.ToLower().Contains(_filterStringItems.ToLower())) ||
       //                    (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterStringItems.ToLower())) ||
       //                    (data.CstmrItmCod != null && data.CstmrItmCod.ToString().ToLower().Contains(_filterStringItems.ToLower())) ||
       //                    (data.CstmrItmDesc != null && data.CstmrItmDesc.ToString().ToLower().Contains(_filterStringItems.ToLower())) ||
       //                    (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringItems.ToLower()));

       //         }
       //         return true;
       //     }
       //     return false;
       // }

       // #endregion

       // #region Filters For uom
       // private void FilterCollectionuom()
       // {
       //     if (_uomCollection != null)
       //     {
       //         _uomCollection.Refresh();
       //     }
       // }
       // public string FilterStringuom
       // {
       //     get { return _filterStringuom; }
       //     set
       //     {
       //         _filterStringuom = value;
       //         RaisePropertychanged("FilterStringuom");
       //         FilterCollectionuom();
       //     }
       // }
       // public bool uomFilter(object obj)
       // {
       //     var data = obj as ADM_M038_B_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterStringuom))
       //         {
       //             return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringuom.ToLower()));

       //         }
       //         return true;
       //     }
       //     return false;
       // }

       // #endregion

       // #region Filters For Tax

       // public string FilterString_tax
       // {
       //     get { return _filterString_tax; }
       //     set
       //     {
       //         _filterString_tax = value;
       //         RaisePropertychanged("FilterString_tax");
       //         FilterCollectiontax();
       //     }
       // }
       // private void FilterCollectiontax()
       // {
       //     if (_dgPOItemsFortaxval != null)
       //     {
       //         _dgPOItemsFortaxval.Refresh();
       //     }
       // }
       // public bool Filtertax(object obj)
       // {
       //     var data = obj as ACC_M013_P;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_tax))
       //         {
       //             return (data.taxaccount != null && data.taxaccount.ToString().ToLower().Contains(_filterString_tax.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //private void FilterCollectionTax()
       // //{
       // //    if (_TaxCollection != null)
       // //    {
       // //        _TaxCollection.Refresh();
       // //    }
       // //}
       // //public string FilterStringTax
       // //{
       // //    get { return _filterStringTax; }
       // //    set
       // //    {
       // //        _filterStringTax = value;
       // //        RaisePropertychanged("FilterStringTax");
       // //        FilterCollectionTax();
       // //    }
       // //}
       // //public bool TaxFilter(object obj)
       // //{
       // //    var data = obj as ACC_M013_PopUp;
       // //    if (data != null)
       // //    {
       // //        if (!string.IsNullOrEmpty(_filterStringTax))
       // //        {
       // //            return (data.description != null && data.description.ToString().ToLower().Contains(_filterStringTax.ToLower()));
       // //        }
       // //        return true;
       // //    }
       // //    return false;
       // //}

       // #endregion

       // public string FilterString_Payterms
       // {
       //     get { return _filterString_payterms; }
       //     set
       //     {
       //         _filterString_payterms = value;
       //         RaisePropertychanged("_filterString_payterms");
       //         FilterCollectionPayTerm();
       //     }
       // }
       // private void FilterCollectionPayTerm()
       // {
       //     if (_PaytmCollection != null)
       //     {
       //         _PaytmCollection.Refresh();
       //     }
       // }
       // public bool FilterPayTerms(object obj)
       // {
       //     var data = obj as ACC_M007_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_payterms))
       //         {
       //             return (data.p_term != null && data.p_term.ToString().ToLower().Contains(_filterString_payterms.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }

       // //Document Type
       // private void FilterCollection_doctype()
       // {
       //     if (_doc_typeCollection != null)
       //     {
       //         _doc_typeCollection.Refresh();
       //     }
       // }
       // private string _filterString_doctype;
       // public string FilterString_doctype
       // {
       //     get { return _filterString_doctype; }
       //     set
       //     {
       //         _filterString_doctype = value;
       //         RaisePropertychanged("FilterString_doctype");
       //         FilterCollection_doctype();
       //     }
       // }
       // public bool doctype_Filter(object obj)
       // {
       //     var data = obj as SYS_M002_Popup;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_doctype))
       //         {
       //             return (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterString_doctype.ToLower()) ||
       //                 data.sdoc_type != null && data.sdoc_type.ToString().ToLower().Contains(_filterString_doctype.ToLower()));

       //         }
       //         return true;
       //     }
       //     return false;
       // }



       // private void FilterCollection_docsubcategory()
       // {
       //     if (doc_SubCategoryCollection != null)
       //     {
       //         doc_SubCategoryCollection.Refresh();
       //     }
       // }
       // private string _filterString_doctsubcatype;
       // public string FilterString_docsubtype
       // {
       //     get { return _filterString_doctsubcatype; }
       //     set
       //     {
       //         _filterString_doctsubcatype = value;
       //         RaisePropertychanged("FilterString_docsubtype");
       //         FilterCollection_docsubcategory();
       //     }
       // }
       // public bool docsubtype_Filter(object obj)
       // {
       //     var data = obj as SYS_M003_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_doctsubcatype))
       //         {
       //             return (data.sditem_cat_code != null && data.sditem_cat_code.ToString().ToLower().Contains(_filterString_doctype.ToLower()));

       //         }
       //         return true;
       //     }
       //     return false;
       // }

       // ////Currency Master
       // private void FilterCollection_currency()
       // {
       //     if (_currencyCollection != null)
       //     {
       //         _currencyCollection.Refresh();
       //     }
       // }
       // private string _filterString_currency;
       // public string FilterString_currency
       // {
       //     get { return _filterString_currency; }
       //     set
       //     {
       //         _filterString_currency = value;
       //         RaisePropertychanged("FilterString_currency");
       //         FilterCollection_currency();
       //     }
       // }
       // public bool currency_Filter(object obj)
       // {
       //     var data = obj as ADM_M037_Popup;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_currency))
       //         {
       //             return (data.id != null && data.id.ToString().ToLower().Contains(_filterString_currency.ToLower()) ||
       //                 data.curr_name != null && data.curr_name.ToString().ToLower().Contains(_filterString_currency.ToLower()));

       //         }
       //         return true;
       //     }
       //     return false;
       // }

       // //Reference doc no's
       // private void FilterCollection_refdocno()
       // {
       //     if (_currencyCollection != null)
       //     {
       //         _currencyCollection.Refresh();
       //     }
       // }
       // private string _filterString_refdocno;
       // public string FilterString_refdocno
       // {
       //     get { return _filterString_refdocno; }
       //     set
       //     {
       //         _filterString_refdocno = value;
       //         RaisePropertychanged("FilterString_refdocno");
       //         FilterCollection_refdocno();
       //     }
       // }
       // public bool refdocno_Filter(object obj)
       // {
       //     var data = obj as SEL_T001_Popup;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_refdocno))
       //         {
       //             return (data.id != null && data.id.ToString().ToLower().Contains(_filterString_refdocno.ToLower()) ||
       //                 data.sono != null && data.sono.ToString().ToLower().Contains(_filterString_refdocno.ToLower()));

       //         }
       //         return true;
       //     }
       //     return false;
       // }

       // //Sale Organisation
       // private void FilterCollection_saleorg()
       // {
       //     if (sales_orgCollection != null)
       //     {
       //         sales_orgCollection.Refresh();
       //     }
       // }
       // private string _filterString_saleorg;
       // public string FilterString_saleorg
       // {
       //     get { return _filterString_saleorg; }
       //     set
       //     {
       //         _filterString_saleorg = value;
       //         RaisePropertychanged("FilterString_saleorg");
       //         FilterCollection_refdocno();
       //     }
       // }
       // public bool saleorg_Filter(object obj)
       // {
       //     var data = obj as ADM_M001_A_Popup;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_saleorg))
       //         {
       //             return (data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString_saleorg.ToLower()) ||
       //                 data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString_saleorg.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //Sales Division
       // private void FilterCollection_saledivision()
       // {
       //     if (sales_divisionCollection != null)
       //     {
       //         sales_divisionCollection.Refresh();
       //     }
       // }
       // private string _filterString_saledivision;
       // public string FilterString_saledivision
       // {
       //     get { return _filterString_saledivision; }
       //     set
       //     {
       //         _filterString_saledivision = value;
       //         RaisePropertychanged("FilterString_saledivision");
       //         FilterCollection_saledivision();
       //     }
       // }
       // public bool saledivision_Filter(object obj)
       // {
       //     var data = obj as ADM_M001_D_Popup;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_saledivision))
       //         {
       //             return (data.div_code != null && data.div_code.ToString().ToLower().Contains(_filterString_saledivision.ToLower()) ||
       //                 data.div_name != null && data.div_name.ToString().ToLower().Contains(_filterString_saledivision.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //Distribution Channel
       // private void FilterCollection_distChannel()
       // {
       //     if (distribution_channelCollection != null)
       //     {
       //         distribution_channelCollection.Refresh();
       //     }
       // }
       // private string _filterString_distChannel;
       // public string FilterString_distChannel
       // {
       //     get { return _filterString_distChannel; }
       //     set
       //     {
       //         _filterString_distChannel = value;
       //         RaisePropertychanged("FilterString_distChannel");
       //         FilterCollection_distChannel();
       //     }
       // }
       // public bool distChannel_Filter(object obj)
       // {
       //     var data = obj as ADM_M001_C_Popup;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_distChannel))
       //         {
       //             return (data.dc_code != null && data.dc_code.ToString().ToLower().Contains(_filterString_distChannel.ToLower()) ||
       //                 data.dc_name != null && data.dc_name.ToString().ToLower().Contains(_filterString_distChannel.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //Sales Person
       // private void FilterCollection_sales_person()
       // {
       //     if (sales_personCollection != null)
       //     {
       //         sales_personCollection.Refresh();
       //     }
       // }
       // private string _filterString_sales_person;
       // public string FilterString_sales_person
       // {
       //     get { return _filterString_sales_person; }
       //     set
       //     {
       //         _filterString_sales_person = value;
       //         RaisePropertychanged("FilterString_sales_person");
       //         FilterCollection_sales_person();
       //     }
       // }
       // public bool sales_person_Filter(object obj)
       // {
       //     var data = obj as ADM_M024_Popup;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_sales_person))
       //         {
       //             return (data.id != null && data.id.ToString().ToLower().Contains(_filterString_sales_person.ToLower()) ||
       //                 data.name != null && data.name.ToString().ToLower().Contains(_filterString_sales_person.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //Sales Office
       // private void FilterCollection_sales_ofc()
       // {
       //     if (sales_officeCollection != null)
       //     {
       //         sales_officeCollection.Refresh();
       //     }
       // }
       // private string _filterString_sales_ofc;
       // public string FilterString_sales_ofc
       // {
       //     get { return _filterString_sales_ofc; }
       //     set
       //     {
       //         _filterString_sales_ofc = value;
       //         RaisePropertychanged("FilterString_sales_ofc");
       //         FilterCollection_sales_ofc();
       //     }
       // }
       // public bool sales_ofc_Filter(object obj)
       // {
       //     var data = obj as ADM_M001_I_Popup;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_sales_ofc))
       //         {
       //             return (data.soff_code != null && data.soff_code.ToString().ToLower().Contains(_filterString_sales_ofc.ToLower()) ||
       //                 data.sales_off != null && data.sales_off.ToString().ToLower().Contains(_filterString_sales_ofc.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //Sales Group
       // private void FilterCollection_sales_grp()
       // {
       //     if (sales_groupCollection != null)
       //     {
       //         sales_groupCollection.Refresh();
       //     }
       // }
       // private string _filterString_sales_grp;
       // public string FilterString_sales_grp
       // {
       //     get { return _filterString_sales_grp; }
       //     set
       //     {
       //         _filterString_sales_grp = value;
       //         RaisePropertychanged("FilterString_sales_grp");
       //         FilterCollection_sales_grp();
       //     }
       // }
       // public bool sales_grp_Filter(object obj)
       // {
       //     var data = obj as ADM_M001_H_Popup;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_sales_grp))
       //         {
       //             return (data.sg_code != null && data.sg_code.ToString().ToLower().Contains(_filterString_sales_grp.ToLower()) ||
       //                 data.sg_name != null && data.sg_name.ToString().ToLower().Contains(_filterString_sales_grp.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }


       // // cost_centre
       // private void FilterCollection_cost_centre()
       // {
       //     if (cost_centerCollection != null)
       //     {
       //         cost_centerCollection.Refresh();
       //     }
       // }
       // private string _filterString_cost_centre;
       // public string FilterString_cost_centre
       // {
       //     get { return _filterString_cost_centre; }
       //     set
       //     {
       //         _filterString_cost_centre = value;
       //         RaisePropertychanged("FilterString_cost_centre");
       //         FilterCollection_cost_centre();
       //     }
       // }
       // public bool cost_centre_Filter(object obj)
       // {
       //     var data = obj as ACC_M019_Popup;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_cost_centre))
       //         {
       //             return (data.id != null && data.id.ToString().ToLower().Contains(_filterString_cost_centre.ToLower()) ||
       //                 data.cost_center != null && data.cost_center.ToString().ToLower().Contains(_filterString_cost_centre.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }











       // private void FilterCollection_journal()
       // {
       //     if (JournalCollection != null)
       //     {
       //         JournalCollection.Refresh();
       //     }
       // }
       // private string _filterString_journal;
       // public string FilterString_journal
       // {
       //     get { return _filterString_journal; }
       //     set
       //     {
       //         _filterString_journal = value;
       //         RaisePropertychanged("FilterString_journal");
       //         FilterCollection_journal();
       //     }
       // }
       // public bool journal_Filter(object obj)
       // {
       //     var data = obj as ACC_M005_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_journal))
       //         {
       //             return (data.id != null && data.id.ToString().ToLower().Contains(_filterString_cost_centre.ToLower()) ||
       //                 data.journal_name != null && data.journal_name.ToString().ToLower().Contains(_filterString_cost_centre.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }






       // private void FilterCollection_Storage_Location()
       // {
       //     if (stock_locationCollection != null)
       //     {
       //         stock_locationCollection.Refresh();
       //     }
       // }
       // private string _filterString_stock_location;
       // public string FilterString_stock_location
       // {
       //     get { return _filterString_stock_location; }
       //     set
       //     {
       //         _filterString_stock_location = value;
       //         RaisePropertychanged("FilterString_stock_location");
       //         FilterCollection_Storage_Location();
       //     }
       // }
       // public bool StorageLocation_Filter(object obj)
       // {
       //     var data = obj as MM_M001_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_stock_location))
       //         {
       //             return (data.store_code != null && data.store_code.ToString().ToLower().Contains(_filterString_stock_location.ToLower()) ||
       //                 data.store_name != null && data.store_name.ToString().ToLower().Contains(_filterString_stock_location.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }






       // private void FilterCollection_Warehouse_Location()
       // {
       //     if (stock_locationCollection != null)
       //     {
       //         stock_locationCollection.Refresh();
       //     }
       // }
       // private string _filterString_Warehouse_location;
       // public string FilterString_Warehouse_location
       // {
       //     get { return _filterString_Warehouse_location; }
       //     set
       //     {
       //         _filterString_Warehouse_location = value;
       //         RaisePropertychanged("FilterString_Warehouse_location");
       //         FilterCollection_Warehouse_Location();
       //     }
       // }
       // public bool Warehouse_Filter(object obj)
       // {
       //     var data = obj as MM_M002_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_Warehouse_location))
       //         {
       //             return (data.wa_code != null && data.wa_code.ToString().ToLower().Contains(_filterString_Warehouse_location.ToLower()) ||
       //                 data.wa_name != null && data.wa_name.ToString().ToLower().Contains(_filterString_Warehouse_location.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }



       // private void FilterCollection_profit_centre()
       // {
       //     if (profit_centerCollection != null)
       //     {
       //         profit_centerCollection.Refresh();
       //     }
       // }
       // private string _filterString_profit_centre;
       // public string FilterString_profit_centre
       // {
       //     get { return _filterString_profit_centre; }
       //     set
       //     {
       //         _filterString_profit_centre = value;
       //         RaisePropertychanged("FilterString_profit_centre");
       //         FilterCollection_profit_centre();
       //     }
       // }
       // public bool profit_centre_Filter(object obj)
       // {
       //     var data = obj as ACC_M020_Popup;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_profit_centre))
       //         {
       //             return (data.id != null && data.id.ToString().ToLower().Contains(_filterString_profit_centre.ToLower()) ||
       //                 data.profit_center != null && data.profit_center.ToString().ToLower().Contains(_filterString_profit_centre.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // #endregion

       // #region "Filter for Back Content Datagrid"
       // public string FilterString
       // {
       //     get { return _filterString; }
       //     set
       //     {
       //         _filterString = value;
       //         RaisePropertychanged("FilterString");
       //         FilterCollection();
       //     }
       // }
       // private void FilterCollection()
       // {
       //     if (_dataGridCollection != null)
       //     {
       //         _dataGridCollection.Refresh();
       //     }
       // }
       // public bool Filter(object obj)
       // {
       //     var data = obj as SEL_T001;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString))
       //         {
       //             return (data.sono != null && data.sono.ToLower().Contains(_filterString.ToLower())) ||
       //             (data.sodate != null && data.sodate.ToString().ToLower().Contains(_filterString.ToLower())) ||
       //             (data.cust_ref != null && data.cust_ref.ToLower().Contains(_filterString.ToLower())) ||
       //             (data.cust_ref_date != null && data.cust_ref_date.ToString().ToLower().Contains(_filterString.ToLower())) ||
       //             (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString.ToLower())) ||
       //             (data.total_amt != null && data.total_amt.ToString().ToLower().Contains(_filterString.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // #endregion

       // #region "Tax Calculation"


       // private void check(bool select)
       // {
       //     TaxRowCalculation();

       // }
       // private void TaxCalculationChanged(object select)
       // {
       //     try
       //     {
       //         string tempTax = SO_Dtails[dgSelectedIndex].tax_id;

       //     }
       //     catch
       //     {

       //     }
       //     TaxRowCalculation();
       // }
       // private void TaxEdit(IList DataList)
       // {

       //     IList list = DataList as IList;
       //     List<SEL_T001_C> Selectedpartylist = list.Cast<SEL_T001_C>().ToList();
       //     try
       //     {
       //         if (Selectedpartylist[0].description != null)
       //         {
       //             dgPOTotalTaxValues.Where(l => l.description == Selectedpartylist[0].description).ToList().ForEach(i => i.tax_id = 0);
       //             dgPOTotalTaxValues.Where(l => l.description == Selectedpartylist[0].description).ToList().ForEach(i => i.base_amount = 0);
       //             dgPOTotalTaxValues.Where(l => l.description == Selectedpartylist[0].description).ToList().ForEach(i => i.tax_amount = Selectedpartylist[0].tax_amount);

       //         }
       //         try
       //         {
       //             TaxDeletedValuesTableCalculation();
       //         }
       //         catch
       //         {

       //         }

       //     }
       //     catch
       //     {

       //     }


       // }
       // private void TaxCellChanged(IList DataList)
       // {
       //     IList list = DataList as IList;
       //     List<ACC_M013_P> Selectedpartylist = list.Cast<ACC_M013_P>().ToList();
       //     try
       //     {
       //         dgPOTotalTaxValues[dgSelectedIndex1].accountcollectdid = Selectedpartylist[0].accountcollectdid;
       //         dgPOTotalTaxValues[dgSelectedIndex1].taxaccount = Selectedpartylist[0].taxaccount;

       //     }
       //     catch
       //     {

       //     }

       // }
       // private void TableTaxEdit(IList DataList)
       // {

       //     IList list = DataList as IList;
       //     List<ACC_M013_PopUp> Selectedpartylist = list.Cast<ACC_M013_PopUp>().ToList();
       //     try
       //     {
       //         var q = dgPOTotalTaxValues.Where(X => X.tax_id == Selectedpartylist[0].id).FirstOrDefault();
       //         int x = dgPOTotalTaxValues.IndexOf(dgPOTotalTaxValues.Where(X => X.tax_id == Selectedpartylist[0].id).FirstOrDefault());
       //         if ((q == null) && Selectedpartylist[0].SelectTax == true && dgPOTotalTaxValues.Count == dgSelectedIndex1)
       //         {
       //             dgPOTotalTaxValues.Insert(dgSelectedIndex1, new SEL_T001_C()
       //             {
       //                 item_id = 0,
       //                 id = 0,
       //                 so_line_id = 0,
       //                 tax_amount = 0,
       //                 base_amount = 0,
       //                 tax_id = Selectedpartylist[0].id,
       //                 description = Selectedpartylist[0].description
       //             }
       //         );

       //         }
       //         else if (Selectedpartylist[0].SelectTax == false && q != null)
       //         {
       //             if (x >= 0)
       //             {
       //                 dgPOTotalTaxValues.RemoveAt(x);

       //             }
       //         }

       //     }
       //     catch
       //     {

       //     }

       // }



       // private void TaxDeletedValuesTableCalculation()
       // {
       //     if (dgPOTotalTaxValues.Count > 0)
       //     {
       //         decimal amount_taxed = 0;
       //         for (int u = 0; u < dgPOTotalTaxValues.Count; u++)
       //         {
       //             amount_taxed = amount_taxed + Convert.ToDecimal(dgPOTotalTaxValues[u].tax_amount);
       //         }
       //         for (int i = 0; i < SO_Dtails.Count; i++)
       //         {
       //             SelectedSEL_T001.untax_amt = SO_Dtails.Sum(t => t.sub_total);
       //         }
       //         SelectedSEL_T001.tax_amt = amount_taxed;
       //         SelectedSEL_T001.total_amt = amount_taxed + SelectedSEL_T001.untax_amt;
       //         try
       //         {
       //             decimal rounding = Convert.ToDecimal(SelectedSEL_T001.total_amt);
       //             SelectedSEL_T001.total_amt = Convert.ToDecimal((Convert.ToString(Math.Round(rounding, 2))));
       //         }
       //         catch
       //         {

       //         }
       //         try
       //         {
       //             double amount = Convert.ToDouble(SelectedSEL_T001.total_amt);
       //             NumberToEnglish num = new NumberToEnglish();
       //             SelectedSEL_T001.amt_inword = num.AmountInWords(Convert.ToDecimal(amount));
       //         }
       //         catch
       //         {

       //         }
       //     }

       // }
       // // We dont have taxamount field in database so after save all calculation done here //
       // private void TaxTableCalculation()
       // {

       //     List<SEL_T001_B> SelectedItemsDetailsTemp = new List<SEL_T001_B>();
       //     dgPOTaxValues3 = new ObservableCollection<SEL_T001_C>();
       //     dgPOTaxValues = new ObservableCollection<SEL_T001_C>();
       //     dgPOTaxValues3 = new ObservableCollection<SEL_T001_C>();
       //     dgPOTaxValues1 = new ObservableCollection<SEL_T001_C>();

       //     for (int s = 0; s <= SO_Dtails.Count - 1; s++)
       //     {
       //         if (SO_Dtails[s].unit_price != 0 && SO_Dtails[s].quantity != 0)
       //         {
       //             if ((SO_Dtails[s].active == true))
       //             {
       //                 string a = SO_Dtails[s].tax_id;
       //                 int length = 0;
       //                 int count = 0;
       //                 string b = "";

       //                 var __list = new List<PUR_T002_C>();
       //                 if (a != null)
       //                 {
       //                     length = a.Length;
       //                 }
       //                 try
       //                 {

       //                     string taxval = SO_Dtails[s].tax_id;
       //                     int taxvalcount = -1;
       //                     double taxupdatvalues;
       //                     double parenttaxvalues = 0;
       //                     int z = s;
       //                     string[] split = new string[25];
       //                     split = SO_Dtails[s].tax_id.Split(',');
       //                     for (int y = 0; y < split.Count(); y++)
       //                     //while (length != 0)
       //                     {
       //                         //if (a.Contains(","))
       //                         //{

       //                         a = split[y];
       //                         //}

       //                         var myItem = (from o in SelectedChildTaxList
       //                                       where o.id == Convert.ToInt32(a)
       //                                       select o).ToList();

       //                         if (myItem[0].t_type.ToString() == "Percentage" && myItem[0].child_depend == false)
       //                         {
       //                             taxupdatvalues = Convert.ToDouble(((SO_Dtails[s].sub_total) * myItem[0].amount) / 100);
       //                             dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal(Convert.ToString(Math.Round(taxupdatvalues, 2))), base_amount = SO_Dtails[s].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                             dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });

       //                         }
       //                         else if (myItem[0].t_type == "Percentage" && myItem[0].child_depend == true)
       //                         {
       //                             var parentdetails = (from o in SelectedChildTaxList
       //                                                  where o.id == myItem[0].parent_id
       //                                                  select o).ToList();
       //                             var parentdetailstaxamt = (from o in dgPOTaxValues
       //                                                        where o.tax_id == parentdetails[0].id
       //                                                        select o).ToList();

       //                             var parentdetailstaxamt1 = (from o in dgPOTaxValues
       //                                                         where o.item_id == SO_Dtails[s].item_id
       //                                                         select o).ToList();


       //                             if (parentdetailstaxamt.Count > 0 && parentdetailstaxamt1.Count == 0)
       //                             {
       //                                 parenttaxvalues = Convert.ToDouble(((SO_Dtails[s].sub_total) * parentdetails[0].amount) / 100);
       //                                 taxupdatvalues = parenttaxvalues;
       //                                 dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = Convert.ToInt32(parentdetailstaxamt[0].tax_id), description = parentdetailstaxamt[0].description });
       //                                 dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = Convert.ToInt32(parentdetailstaxamt[0].tax_id), description = parentdetailstaxamt[0].description });
       //                             }
       //                             else if (parentdetailstaxamt1.Count == 0)
       //                             {
       //                                 decimal amt = parentdetails[0].amount;
       //                                 parenttaxvalues = Convert.ToDouble(((SO_Dtails[s].sub_total) * amt) / 100);
       //                                 taxupdatvalues = parenttaxvalues;
       //                                 dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = 0, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = parentdetails[0].id, description = parentdetails[0].description });
       //                                 dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = 0, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = parentdetails[0].id, description = parentdetails[0].description });


       //                             }

       //                             if (parentdetailstaxamt1.Count > 0)
       //                             {
       //                                 taxupdatvalues = (Convert.ToDouble(parentdetailstaxamt1[0].tax_amount) * Convert.ToDouble(parentdetails[0].amount)) / 100;
       //                                 dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                                 dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                             }
       //                             else if (parentdetailstaxamt1.Count == 0)
       //                             {
       //                                 taxupdatvalues = (parenttaxvalues * Convert.ToDouble(parentdetails[0].amount)) / 100;
       //                                 dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                                 dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });

       //                             }


       //                         }



       //                         var parentdetails123 = (from o in SelectedChildTaxList
       //                                                 where o.parent_id == myItem[0].id
       //                                                 select o).ToList();

       //                         if (myItem[0].t_type == "Percentage" && parentdetails123.Count > 0)
       //                         {

       //                             parenttaxvalues = Convert.ToDouble(((SO_Dtails[s].sub_total) * myItem[0].amount) / 100);
       //                             dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(parenttaxvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                             dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(parenttaxvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });


       //                             for (int r = 0; r < parentdetails123.Count; r++)
       //                             {
       //                                 if (parentdetails123[r].t_type == "Percentage")
       //                                 {
       //                                     taxupdatvalues = (Convert.ToDouble(parentdetails123[r].amount) * Convert.ToDouble(parenttaxvalues)) / 100;
       //                                     dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = parentdetails123[r].taxaccount, accountcollectdid = parentdetails123[r].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = Convert.ToDecimal(parenttaxvalues), tax_id = parentdetails123[r].id, description = parentdetails123[r].description });
       //                                     dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = parentdetails123[r].taxaccount, accountcollectdid = parentdetails123[r].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = Convert.ToDecimal(parenttaxvalues), tax_id = parentdetails123[r].id, description = parentdetails123[r].description });
       //                                 }
       //                             }



       //                         }

       //                         else if (myItem[0].t_type == "Fixed Amount" && myItem[0].child_depend == true)
       //                         {
       //                             var parentdetails = (from o in dgPOTaxValues
       //                                                  where o.tax_id == myItem[0].parent_id
       //                                                  select o).ToList();

       //                             var parentdetails1 = (from o in SelectedChildTaxList
       //                                                   where o.id == myItem[0].parent_id
       //                                                   select o).ToList();


       //                             if (parentdetails.Count > 0)
       //                             {
       //                                 taxupdatvalues = (Convert.ToDouble(myItem[0].amount) * Convert.ToDouble(parentdetails[0].base_amount)) / 100;
       //                             }
       //                             else
       //                             {
       //                                 decimal amt = parentdetails1[0].amount;
       //                                 taxupdatvalues = Convert.ToDouble(amt);
       //                                 dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = 0, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = parentdetails1[0].id, description = parentdetails1[0].description });
       //                                 dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = 0, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = parentdetails1[0].id, description = parentdetails1[0].description });
       //                             }

       //                             dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                             dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                         }
       //                         else if (myItem[0].t_type == "Fixed Amount" && myItem[0].child_depend == false)
       //                         {

       //                             taxupdatvalues = Convert.ToDouble(myItem[0].amount);

       //                             dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                             dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                         }
       //                         else if (myItem[0].Price_include == true)
       //                         {
       //                             double formula = 0;
       //                             double formulavalues = 0;
       //                             taxupdatvalues = Convert.ToDouble(myItem[0].amount);
       //                             formula = (Convert.ToDouble(SO_Dtails[s].sub_total) / (Convert.ToDouble(taxupdatvalues / 100) + 1));
       //                             formulavalues = Convert.ToDouble(formula * Convert.ToDouble(taxupdatvalues / 100));
       //                             dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, base_amount = Convert.ToDecimal((Convert.ToString(Math.Round(formula, 2)))), taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(formulavalues, 2)))), tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                             dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, base_amount = Convert.ToDecimal((Convert.ToString(Math.Round(formula, 2)))), taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(formulavalues, 2)))), tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                             SO_Dtails.Where(l => l.item_id == SO_Dtails[s].item_id).ToList().ForEach(i => i.sub_total = Convert.ToDecimal((Convert.ToString(Math.Round(formula, 2)))));
       //                         }
       //                         else if (myItem[0].Price_include == false)
       //                         {
       //                             double vatcalculate = 0;
       //                             double vatsum = 0;

       //                             var BaseAmount = (from data in dgPOTaxValues3
       //                                               where (data.item_id == SO_Dtails[s].item_id
       //                                                   && data.stocking_unit1 == SO_Dtails[s].stocking_unit1 && data.include_base_amount == true)
       //                                               select data.tax_amount).Sum();

       //                             taxupdatvalues = Convert.ToDouble(myItem[0].amount);
       //                             vatsum = ((Convert.ToDouble(SO_Dtails[s].sub_total)) + (Convert.ToDouble(BaseAmount)));
       //                             vatcalculate = (vatsum * taxupdatvalues) / 100;

       //                             dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(vatcalculate, 2)))), base_amount = Convert.ToDecimal(vatsum), tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                             dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[s].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(vatcalculate, 2)))), base_amount = Convert.ToDecimal(vatsum), tax_id = Convert.ToInt32(a), description = myItem[0].description });

       //                         }
       //                         //else if (myItem[0].Price_include == false)
       //                         //{
       //                         //    try
       //                         //    {
       //                         //        decimal vatcst = 0;
       //                         //        {
       //                         //            var BasicExcise = (from data in dgPOTaxValues3 where data.description == "Basic Excise Duty" select data.tax_amount).Sum();
       //                         //            var cess = (from data in dgPOTaxValues3 where data.description == "Education CEss" select data.tax_amount).Sum();
       //                         //            var hcess = (from data in dgPOTaxValues3 where data.description == "Secondary Higher Edu. Cess" select data.tax_amount).Sum();
       //                         //            vatcst = Convert.ToDecimal(BasicExcise + cess + hcess);
       //                         //            parenttaxvalues = Convert.ToDouble(((SelectedPUR_T002_A.amount_untaxed + vatcst) * myItem[0].amount) / 100);
       //                         //            dgPOTaxValues.Add(new PUR_T002_C() { taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, po_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(parenttaxvalues, 2)))), base_amount = (SelectedPUR_T002_A.amount_untaxed + SelectedPUR_T002_A.amount_tax), tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                         //            dgPOTaxValues3.Add(new PUR_T002_C() { taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, po_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(parenttaxvalues, 2)))), base_amount = (SelectedPUR_T002_A.amount_untaxed + SelectedPUR_T002_A.amount_tax), tax_id = Convert.ToInt32(a), description = myItem[0].description });

       //                         //        }
       //                         //    }
       //                         //    catch
       //                         //    {

       //                         //    }

       //                         //}

       //                         else
       //                         {

       //                             taxupdatvalues = Convert.ToDouble(((SO_Dtails[s].sub_total) * myItem[0].amount) / 100);
       //                             dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description, stocking_unit1 = "" });
       //                             dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[s].item_id, id = 0, so_line_id = SO_Dtails[s].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[s].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description, stocking_unit1 = "" });
       //                         }

       //                         //if (b == "")
       //                         //{
       //                         //    b = b + a;
       //                         //}
       //                         //else
       //                         //{
       //                         //    b = b + ',' + a;
       //                         //}
       //                         //if (b.ToString() != SO_Dtails[s].tax_id.ToString())
       //                         //{
       //                         //    a = SO_Dtails[s].tax_id.Replace(b + ',', "");
       //                         //}
       //                         //else
       //                         //{
       //                         //    a = SO_Dtails[s].tax_id.Replace(b, "");
       //                         //}


       //                         //length = a.Length;

       //                     }


       //                 }
       //                 catch
       //                 {

       //                 }
       //             }
       //         }

       //     }
       //     try
       //     {
       //         decimal total_amt1 = 0;
       //         decimal basic_amount = 0;

       //         for (int m = dgPOTaxValues3.Count - 1; m >= 0; m--)
       //         {

       //             var totaltaxvalue1 = (from o in dgPOTaxValues3
       //                                   where o.tax_id == dgPOTaxValues3[m].tax_id
       //                                   select o).ToList();

       //             for (int q = dgPOTaxValues3.Count; q >= 0; q--)
       //             {
       //                 try
       //                 {
       //                     int x7 = dgPOTaxValues3.IndexOf(dgPOTaxValues3.Where(X => X.tax_id == totaltaxvalue1[0].tax_id).FirstOrDefault());
       //                     if (x7 != null)
       //                     {
       //                         dgPOTaxValues3.RemoveAt(x7);
       //                         m = dgPOTaxValues3.Count;
       //                     }
       //                 }
       //                 catch
       //                 {

       //                 }
       //             }


       //             for (int y = 0; y < totaltaxvalue1.Count; y++)
       //             {
       //                 total_amt1 = total_amt1 + Convert.ToDecimal(totaltaxvalue1[y].tax_amount);
       //                 basic_amount = basic_amount + Convert.ToDecimal(totaltaxvalue1[y].base_amount);
       //             }

       //             for (int r = dgPOTotalTaxValues.Count; r > 0; r--)
       //             {

       //                 int x2 = dgPOTotalTaxValues.IndexOf(dgPOTotalTaxValues.Where(X => X.tax_id == totaltaxvalue1[0].tax_id).FirstOrDefault());
       //                 if (x2 != null)
       //                 {

       //                     try
       //                     {
       //                         dgPOTotalTaxValues.RemoveAt(x2);
       //                     }
       //                     catch
       //                     {

       //                     }

       //                 }
       //             }
       //             dgPOTotalTaxValues.Add(new SEL_T001_C()
       //             {

       //                 item_id = totaltaxvalue1[0].item_id,
       //                 id = 0,
       //                 so_line_id = totaltaxvalue1[0].so_line_id,
       //                 tax_amount = total_amt1,
       //                 base_amount = Convert.ToDecimal((Convert.ToString(Math.Round(basic_amount, 2)))),
       //                 tax_id = totaltaxvalue1[0].tax_id,
       //                 description = totaltaxvalue1[0].description,
       //                 taxaccount = totaltaxvalue1[0].taxaccount,
       //                 accountcollectdid = totaltaxvalue1[0].accountcollectdid,
       //                 stocking_unit1 = totaltaxvalue1[0].stocking_unit1

       //             });
       //             total_amt1 = 0;
       //             basic_amount = 0;

       //         }
       //     }
       //     catch
       //     {

       //     }
       //     try
       //     {

       //         decimal amount_taxed = 0;
       //         for (int u = 0; u < dgPOTotalTaxValues.Count; u++)
       //         {
       //             amount_taxed = amount_taxed + Convert.ToDecimal(dgPOTotalTaxValues[u].tax_amount);
       //         }
       //         for (int i = 0; i < SO_Dtails.Count; i++)
       //         {
       //             //SO_Dtails[i].sub_total = ((SO_Dtails[i].qty * SO_Dtails[i].unit_price));
       //             SelectedSEL_T001.untax_amt = SO_Dtails.Sum(t => t.sub_total);
       //         }
       //         SelectedSEL_T001.tax_amt = amount_taxed;
       //         SelectedSEL_T001.total_amt = amount_taxed + SelectedSEL_T001.untax_amt;
       //         try
       //         {
       //             decimal rounding = Convert.ToDecimal(SelectedSEL_T001.total_amt);
       //             SelectedSEL_T001.total_amt = Convert.ToDecimal((Convert.ToString(Math.Round(rounding, 2))));
       //         }
       //         catch
       //         {

       //         }
       //         try
       //         {
       //             double amount = Convert.ToDouble(SelectedSEL_T001.total_amt);
       //             NumberToEnglish num = new NumberToEnglish();
       //             SelectedSEL_T001.amt_inword = num.AmountInWords(Convert.ToDecimal(amount));
       //         }
       //         catch
       //         {

       //         }
       //     }
       //     catch
       //     {

       //     }
       // }

       // //RowWise Calculation//



       // private void TaxRowCalculation()
       // {
       //     List<SEL_T001_B> SelectedItemsDetailsTemp = new List<SEL_T001_B>();
       //     try
       //     {
       //         int item_id = Convert.ToInt32(SO_Dtails[dgSelectedIndex].item_id);
       //         string stockunit = SO_Dtails[dgSelectedIndex].stocking_unit1;


       //         dgPOTaxValues3 = new ObservableCollection<SEL_T001_C>();


       //         for (int r = dgPOTaxValues.Count; r > 0; r--)
       //         {
       //             int x3 = dgPOTaxValues.IndexOf(dgPOTaxValues.Where(X => X.item_id == item_id).Where(X => X.stocking_unit1 == stockunit).FirstOrDefault());
       //             if (x3 != null)
       //             {

       //                 try
       //                 {
       //                     dgPOTaxValues.RemoveAt(x3);

       //                 }
       //                 catch
       //                 {

       //                 }
       //             }
       //         }
       //         for (int r = dgPOTaxValues3.Count; r > 0; r--)
       //         {
       //             int x4 = dgPOTaxValues3.IndexOf(dgPOTaxValues3.Where(X => X.item_id == item_id).Where(X => X.stocking_unit1 == stockunit).FirstOrDefault());
       //             if (x4 != null)
       //             {

       //                 try
       //                 {
       //                     dgPOTaxValues3.RemoveAt(x4);

       //                 }
       //                 catch
       //                 {

       //                 }
       //             }
       //         }
       //         for (int r = dgPOTaxValues1.Count; r > 0; r--)
       //         {
       //             int x5 = dgPOTaxValues1.IndexOf(dgPOTaxValues1.Where(X => X.item_id == item_id).Where(X => X.stocking_unit1 == stockunit).FirstOrDefault());
       //             if (x5 != null)
       //             {
       //                 try
       //                 {
       //                     dgPOTaxValues1.RemoveAt(x5);

       //                 }
       //                 catch
       //                 {

       //                 }
       //             }
       //         }

       //         dgPOItemsForParameterval = CollectionViewSource.GetDefaultView(dgPOTaxValues);
       //         for (int i = 0; i < dgPOItemsForParameterval.Cast<SEL_T001_C>().ToList().Count(); i++)
       //         {
       //             dgPOTaxValues3.Add(dgPOItemsForParameterval.Cast<SEL_T001_C>().ElementAt(i));

       //         }
       //         for (int r = dgPOTotalTaxValues.Count; r > 0; r--)
       //         {
       //             int x2 = dgPOTotalTaxValues.IndexOf(dgPOTotalTaxValues.Where(X => X.item_id == item_id).Where(X => X.stocking_unit1 == stockunit).FirstOrDefault());
       //             if (x2 != null)
       //             {

       //                 try
       //                 {
       //                     dgPOTotalTaxValues.RemoveAt(x2);
       //                 }
       //                 catch
       //                 {

       //                 }
       //                 try
       //                 {
       //                     int x8 = dgPOTotalTaxValues.IndexOf(dgPOTotalTaxValues.Where(X => X.description == null).FirstOrDefault());
       //                     dgPOTotalTaxValues.RemoveAt(x8);
       //                 }
       //                 catch
       //                 {

       //                 }
       //             }
       //         }
       //     }
       //     catch
       //     {

       //     }
       //     try
       //     {



       //         if (SO_Dtails[dgSelectedIndex] != null)
       //         {
       //             if (SO_Dtails[dgSelectedIndex].unit_price != 0 && SO_Dtails[dgSelectedIndex].quantity != 0)
       //             {

       //                 string a = SO_Dtails[dgSelectedIndex].tax_id;
       //                 int length = 0;
       //                 int count = 0;
       //                 string b = "";

       //                 var __list = new List<SEL_T001_C>();
       //                 if (a != null)
       //                 {
       //                     length = a.Length;
       //                 }
       //                 try
       //                 {
       //                     if (SO_Dtails[dgSelectedIndex].active == true)
       //                     {
       //                         string taxval = SO_Dtails[dgSelectedIndex].tax_id;
       //                         int taxvalcount = -1;
       //                         double taxupdatvalues;
       //                         double parenttaxvalues = 0;
       //                         int z = dgSelectedIndex;
       //                         string[] split = new string[25];
       //                         split = SO_Dtails[dgSelectedIndex].tax_id.Split(',');
       //                         for (int y = 0; y < split.Count(); y++)
       //                         {
       //                             //if (a.Contains(","))
       //                             //{

       //                             a = split[y];
       //                             //}

       //                             var myItem = (from o in SelectedChildTaxList
       //                                           where o.id == Convert.ToInt32(a)
       //                                           select o).ToList();

       //                             if (myItem[0].t_type.ToString() == "Percentage" && myItem[0].child_depend == false)
       //                             {
       //                                 taxupdatvalues = Convert.ToDouble(((SO_Dtails[dgSelectedIndex].sub_total) * myItem[0].amount) / 100);
       //                                 dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal(Convert.ToString(Math.Round(taxupdatvalues, 2))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                                 dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });

       //                             }
       //                             else if (myItem[0].t_type == "Percentage" && myItem[0].child_depend == true)
       //                             {
       //                                 var parentdetails = (from o in SelectedChildTaxList
       //                                                      where o.id == myItem[0].parent_id
       //                                                      select o).ToList();
       //                                 var parentdetailstaxamt = (from o in dgPOTaxValues
       //                                                            where o.tax_id == parentdetails[0].id
       //                                                            select o).ToList();

       //                                 var parentdetailstaxamt1 = (from o in dgPOTaxValues
       //                                                             where o.item_id == SO_Dtails[dgSelectedIndex].item_id
       //                                                             select o).ToList();
       //                                 if (parentdetailstaxamt.Count > 0 && parentdetailstaxamt1.Count == 0)
       //                                 {
       //                                     parenttaxvalues = Convert.ToDouble(((SO_Dtails[dgSelectedIndex].sub_total) * parentdetails[0].amount) / 100);
       //                                     taxupdatvalues = parenttaxvalues;
       //                                     dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = Convert.ToInt32(parentdetailstaxamt[0].tax_id), description = parentdetailstaxamt[0].description });
       //                                     dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = Convert.ToInt32(parentdetailstaxamt[0].tax_id), description = parentdetailstaxamt[0].description });
       //                                 }
       //                                 else if (parentdetailstaxamt1.Count == 0)
       //                                 {
       //                                     decimal amt = parentdetails[0].amount;
       //                                     parenttaxvalues = Convert.ToDouble(((SO_Dtails[dgSelectedIndex].sub_total) * amt) / 100);
       //                                     taxupdatvalues = parenttaxvalues;
       //                                     dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = 0, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = parentdetails[0].id, description = parentdetails[0].description });
       //                                     dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = 0, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = parentdetails[0].id, description = parentdetails[0].description });


       //                                 }
       //                                 if (parentdetailstaxamt1.Count > 0)
       //                                 {
       //                                     taxupdatvalues = (Convert.ToDouble(parentdetailstaxamt1[0].tax_amount) * Convert.ToDouble(parentdetails[0].amount)) / 100;
       //                                     dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                                     dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                                 }
       //                                 else if (parentdetailstaxamt1.Count == 0)
       //                                 {
       //                                     taxupdatvalues = (parenttaxvalues * Convert.ToDouble(parentdetails[0].amount)) / 100;
       //                                     dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                                     dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });

       //                                 }


       //                             }
       //                             var parentdetails123 = (from o in SelectedChildTaxList
       //                                                     where o.parent_id == myItem[0].id
       //                                                     select o).ToList();

       //                             if (myItem[0].t_type == "Percentage" && parentdetails123.Count > 0)
       //                             {

       //                                 parenttaxvalues = Convert.ToDouble(((SO_Dtails[dgSelectedIndex].sub_total) * myItem[0].amount) / 100);
       //                                 dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(parenttaxvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                                 dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(parenttaxvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });


       //                                 for (int r = 0; r < parentdetails123.Count; r++)
       //                                 {
       //                                     if (parentdetails123[r].t_type == "Percentage")
       //                                     {
       //                                         taxupdatvalues = (Convert.ToDouble(parentdetails123[r].amount) * Convert.ToDouble(parenttaxvalues)) / 100;
       //                                         dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = parentdetails123[r].taxaccount, accountcollectdid = parentdetails123[r].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = Convert.ToDecimal(parenttaxvalues), tax_id = parentdetails123[r].id, description = parentdetails123[r].description });
       //                                         dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = parentdetails123[r].taxaccount, accountcollectdid = parentdetails123[r].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = Convert.ToDecimal(parenttaxvalues), tax_id = parentdetails123[r].id, description = parentdetails123[r].description });
       //                                     }
       //                                 }
       //                             }

       //                             else if (myItem[0].t_type == "Fixed Amount" && myItem[0].child_depend == true)
       //                             {
       //                                 var parentdetails = (from o in dgPOTaxValues
       //                                                      where o.tax_id == myItem[0].parent_id
       //                                                      select o).ToList();

       //                                 var parentdetails1 = (from o in SelectedChildTaxList
       //                                                       where o.id == myItem[0].parent_id
       //                                                       select o).ToList();


       //                                 if (parentdetails.Count > 0)
       //                                 {
       //                                     taxupdatvalues = (Convert.ToDouble(myItem[0].amount) * Convert.ToDouble(parentdetails[0].base_amount)) / 100;
       //                                 }
       //                                 else
       //                                 {
       //                                     decimal amt = parentdetails1[0].amount;
       //                                     taxupdatvalues = Convert.ToDouble(amt);
       //                                     dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = 0, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = parentdetails1[0].id, description = parentdetails1[0].description });
       //                                     dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = 0, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = parentdetails1[0].id, description = parentdetails1[0].description });
       //                                 }

       //                                 dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                                 dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                             }
       //                             else if (myItem[0].t_type == "Fixed Amount" && myItem[0].child_depend == false)
       //                             {

       //                                 taxupdatvalues = Convert.ToDouble(myItem[0].amount);

       //                                 dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                                 dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                             }
       //                             else if (myItem[0].Price_include == true)
       //                             {
       //                                 double formula = 0;
       //                                 double formulavalues = 0;
       //                                 taxupdatvalues = Convert.ToDouble(myItem[0].amount);
       //                                 formula = (Convert.ToDouble(SO_Dtails[dgSelectedIndex].sub_total) / (Convert.ToDouble(taxupdatvalues / 100) + 1));
       //                                 formulavalues = Convert.ToDouble(formula * Convert.ToDouble(taxupdatvalues / 100));
       //                                 dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, base_amount = Convert.ToDecimal((Convert.ToString(Math.Round(formula, 2)))), taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(formulavalues, 2)))), tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                                 dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, base_amount = Convert.ToDecimal((Convert.ToString(Math.Round(formula, 2)))), taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(formulavalues, 2)))), tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                                 SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.sub_total = Convert.ToDecimal((Convert.ToString(Math.Round(formula, 2)))));
       //                             }
       //                             else if (myItem[0].Price_include == false)
       //                             {
       //                                 double vatcalculate = 0;
       //                                 double vatsum = 0;

       //                                 var BaseAmount = (from data in dgPOTaxValues3
       //                                                   where (data.item_id == SO_Dtails[dgSelectedIndex].item_id
       //                                                       && data.stocking_unit1 == SO_Dtails[dgSelectedIndex].stocking_unit1 && data.include_base_amount == true)
       //                                                   select data.tax_amount).Sum();

       //                                 taxupdatvalues = Convert.ToDouble(myItem[0].amount);
       //                                 vatsum = ((Convert.ToDouble(SO_Dtails[dgSelectedIndex].sub_total)) + (Convert.ToDouble(BaseAmount)));
       //                                 vatcalculate = (vatsum * taxupdatvalues) / 100;

       //                                 dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(vatcalculate, 2)))), base_amount = Convert.ToDecimal(vatsum), tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                                 dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(vatcalculate, 2)))), base_amount = Convert.ToDecimal(vatsum), tax_id = Convert.ToInt32(a), description = myItem[0].description });

       //                             }

       //                             //else if (myItem[0].Price_include == false)
       //                             //{
       //                             //    try
       //                             //    {
       //                             //        decimal vatcst = 0;
       //                             //        {
       //                             //            var BasicExcise = (from data in dgPOTaxValues3 where data.description == "Basic Excise Duty" select data.tax_amount).Sum();
       //                             //            var cess = (from data in dgPOTaxValues3 where data.description == "Education CEss" select data.tax_amount).Sum();
       //                             //            var hcess = (from data in dgPOTaxValues3 where data.description == "Secondary Higher Edu. Cess" select data.tax_amount).Sum();
       //                             //            vatcst = Convert.ToDecimal(BasicExcise + cess + hcess);
       //                             //            parenttaxvalues = Convert.ToDouble(((SelectedPUR_T002_A.amount_untaxed + vatcst) * myItem[0].amount) / 100);
       //                             //            dgPOTaxValues.Add(new PUR_T002_C() { taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, po_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(parenttaxvalues, 2)))), base_amount = (SelectedPUR_T002_A.amount_untaxed + SelectedPUR_T002_A.amount_tax), tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                             //            dgPOTaxValues3.Add(new PUR_T002_C() { taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, po_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(parenttaxvalues, 2)))), base_amount = (SelectedPUR_T002_A.amount_untaxed + SelectedPUR_T002_A.amount_tax), tax_id = Convert.ToInt32(a), description = myItem[0].description });

       //                             //        }
       //                             //    }
       //                             //    catch
       //                             //    {

       //                             //    }

       //                             //}
       //                             else
       //                             {

       //                                 taxupdatvalues = Convert.ToDouble(((SO_Dtails[dgSelectedIndex].sub_total) * myItem[0].amount) / 100);
       //                                 dgPOTaxValues.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                                 dgPOTaxValues3.Add(new SEL_T001_C() { include_base_amount = Convert.ToBoolean(myItem[0].include_base_amount), stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, taxaccount = myItem[0].taxaccount, accountcollectdid = myItem[0].accountcollectdid, item_id = SO_Dtails[dgSelectedIndex].item_id, id = 0, so_line_id = SO_Dtails[dgSelectedIndex].item_id, tax_amount = Convert.ToDecimal((Convert.ToString(Math.Round(taxupdatvalues, 2)))), base_amount = SO_Dtails[dgSelectedIndex].sub_total, tax_id = Convert.ToInt32(a), description = myItem[0].description });
       //                             }

       //                             //if (b == "")
       //                             //{
       //                             //    b = b + a;
       //                             //}
       //                             //else
       //                             //{
       //                             //    b = b + ',' + a;
       //                             //}
       //                             //if (b.ToString() != SO_Dtails[dgSelectedIndex].tax_id.ToString())
       //                             //{
       //                             //    a = SO_Dtails[dgSelectedIndex].tax_id.Replace(b + ',', "");
       //                             //}
       //                             //else
       //                             //{
       //                             //    a = SO_Dtails[dgSelectedIndex].tax_id.Replace(b, "");
       //                             //}


       //                             //length = a.Length;

       //                         }
       //                     }
       //                 }
       //                 catch
       //                 {

       //                 }

       //                 decimal total_amt1 = 0;
       //                 decimal basic_amount = 0;



       //                 {
       //                     for (int m = dgPOTaxValues3.Count - 1; m >= 0; m--)
       //                     {

       //                         var totaltaxvalue1 = (from o in dgPOTaxValues3
       //                                               where o.tax_id == dgPOTaxValues3[m].tax_id
       //                                               select o).ToList();

       //                         for (int q = dgPOTaxValues3.Count; q >= 0; q--)
       //                         {
       //                             try
       //                             {
       //                                 int x7 = dgPOTaxValues3.IndexOf(dgPOTaxValues3.Where(X => X.tax_id == totaltaxvalue1[0].tax_id).FirstOrDefault());
       //                                 if (x7 != null)
       //                                 {
       //                                     dgPOTaxValues3.RemoveAt(x7);
       //                                     m = dgPOTaxValues3.Count;
       //                                 }
       //                             }
       //                             catch
       //                             {

       //                             }
       //                         }


       //                         for (int y = 0; y < totaltaxvalue1.Count; y++)
       //                         {
       //                             total_amt1 = total_amt1 + Convert.ToDecimal(totaltaxvalue1[y].tax_amount);
       //                             basic_amount = basic_amount + Convert.ToDecimal(totaltaxvalue1[y].base_amount);
       //                         }

       //                         for (int r = dgPOTotalTaxValues.Count; r > 0; r--)
       //                         {

       //                             int x2 = dgPOTotalTaxValues.IndexOf(dgPOTotalTaxValues.Where(X => X.tax_id == totaltaxvalue1[0].tax_id).FirstOrDefault());
       //                             if (x2 != null)
       //                             {

       //                                 try
       //                                 {
       //                                     dgPOTotalTaxValues.RemoveAt(x2);
       //                                 }
       //                                 catch
       //                                 {

       //                                 }

       //                             }
       //                         }
       //                         dgPOTotalTaxValues.Add(new SEL_T001_C()
       //                         {

       //                             item_id = SO_Dtails[dgSelectedIndex].item_id,
       //                             id = 0,
       //                             so_line_id = SO_Dtails[dgSelectedIndex].item_id,
       //                             tax_amount = total_amt1,
       //                             base_amount = Convert.ToDecimal((Convert.ToString(Math.Round(basic_amount, 2)))),
       //                             tax_id = totaltaxvalue1[0].tax_id,
       //                             description = totaltaxvalue1[0].description,
       //                             taxaccount = totaltaxvalue1[0].taxaccount,
       //                             accountcollectdid = totaltaxvalue1[0].accountcollectdid,
       //                             stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1


       //                         });
       //                         total_amt1 = 0;
       //                         basic_amount = 0;

       //                     }


       //                 }
       //             }


       //             decimal amount_taxed = 0;
       //             for (int u = 0; u < dgPOTotalTaxValues.Count; u++)
       //             {
       //                 amount_taxed = amount_taxed + Convert.ToDecimal(dgPOTotalTaxValues[u].tax_amount);
       //             }
       //             for (int i = 0; i < SO_Dtails.Count; i++)
       //             {
       //                 //SO_Dtails[i].sub_total = ((SO_Dtails[i].qty * SO_Dtails[i].unit_price));
       //                 SelectedSEL_T001.untax_amt = SO_Dtails.Sum(t => t.sub_total);
       //             }
       //             SelectedSEL_T001.tax_amt = amount_taxed;
       //             SelectedSEL_T001.total_amt = amount_taxed + SelectedSEL_T001.untax_amt;
       //             try
       //             {
       //                 decimal rounding = Convert.ToDecimal(SelectedSEL_T001.total_amt);
       //                 SelectedSEL_T001.total_amt = Convert.ToDecimal((Convert.ToString(Math.Round(rounding, 2))));
       //             }
       //             catch
       //             {

       //             }
       //             try
       //             {
       //                 double amount = Convert.ToDouble(SelectedSEL_T001.total_amt);
       //                 NumberToEnglish num = new NumberToEnglish();
       //                 SelectedSEL_T001.amt_inword = num.AmountInWords(Convert.ToDecimal(amount));
       //             }
       //             catch
       //             {

       //             }
       //         }
       //     }
       //     catch
       //     {

       //     }
       // }


       // private void LoadNo()
       // {
       //     //if ((SelectedSEL_T001.ref_doc_type == "") || (SelectedSEL_T001.ref_doc_type == null))
       //     //{

       //     //    reference_docCollection = CollectionViewSource.GetDefaultView(null);
       //     //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //     //    showMessageService.ButtonSetup = DialogButton.Ok;
       //     //    showMessageService.Caption = "Message";
       //     //    showMessageService.Text = String.Format("Please Select Ref. Doc Type First..", this.Title);
       //     //    showMessageService.ShowMessage();
       //     //}
       //     //else
       //     //{
       //         string company = AppSessionState.comp_code.ToString() + "@" + AppSessionState.location_Id.ToString() + "@" + SelectedSEL_T001.ref_doc_no;
       //         MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MC, "SEL_T001_Data", "SalesOrderMaster", "CRM", "Enquiry-Quotation-SODetailsNO", 0, company);
               
       //         dgrefdocno = new ObservableCollection<SEL_T001_Popup>(MC.DocNoList);               
       //         //if (SelectedSEL_T001.ref_doc_type == "Sales Order")
       //         //{
       //             var parentdetails = (from o in dgrefdocno
       //                                  where o.doc_type_id == "SO" && o.item_id == SelectedSEL_T001.customer_id
       //                                  select o).ToList();
       //             reference_docCollection = CollectionViewSource.GetDefaultView(parentdetails);
       //         //}
       //     //}
       //     //SelectedSEL_T001.ref_doc_no = null;
       // }
       // private void RowWiseTaxesLoad()
       // {

       //     TaxRowCalculation();
       //     try
       //     {

       //         for (int j = 0; j < dgPOTaxValues.Count; j++)
       //         {
       //             if (dgPOTaxValues[j].item_id == SO_Dtails[dgSelectedIndex].item_id && dgPOTaxValues[j].stocking_unit1 == SO_Dtails[dgSelectedIndex].stocking_unit1)
       //             {
       //                 var parentdetails = (from o in dgPOTaxValues
       //                                      where o.item_id == SO_Dtails[dgSelectedIndex].item_id && o.stocking_unit1 == SO_Dtails[dgSelectedIndex].stocking_unit1
       //                                      select o).ToList();
       //                 dgPOTaxValues2 = new ObservableCollection<SEL_T001_C>();
       //                 for (int i = 0; i < parentdetails.Count; i++)
       //                 {
       //                     if (Convert.ToDouble(parentdetails[i].base_amount) != 0.0)
       //                     {
       //                         dgPOTaxValues2.Add(new SEL_T001_C() { stocking_unit1 = SO_Dtails[dgSelectedIndex].stocking_unit1, id = 0, so_line_id = 0, tax_amount = parentdetails[i].tax_amount, base_amount = parentdetails[i].base_amount, tax_id = parentdetails[i].tax_id, description = parentdetails[i].description });
       //                     }
       //                 }
       //                 break;
       //             }
       //             else
       //             {
       //                 dgPOTaxValues2 = new ObservableCollection<SEL_T001_C>();
       //             }
       //         }
       //     }
       //     catch
       //     {

       //     }


       // }
       // #endregion "Tax Calculation"

       // #region "Schedule"
       // private void ScheduleCellChanged(IList DataList)
       // {

       //     IList list = DataList as IList;

       //     try
       //     {
       //         List<SEL_T002_B> Selectedpartylist = list.Cast<SEL_T002_B>().ToList();
       //         decimal qty = 0;
       //         if (SelectedSEL_T001.doc_type_id != "OP")
       //         {
       //             int x2 = dgPOdeliveryschedule.IndexOf(dgPOdeliveryschedule.Where(X => X.item == Selectedpartylist[0].item).Where(X => X.stockingunit == Selectedpartylist[0].stockingunit).FirstOrDefault());

       //             if (dgPOdeliveryschedule.Count > 0)
       //             {
       //                 //for (int y = 0; y < dgPOdeliveryschedule.Count; y++)
       //                 {
       //                     if (Selectedpartylist[0].item == dgPOdeliveryschedule[x2].item && Selectedpartylist[0].stockingunit == dgPOdeliveryschedule[x2].stockingunit)
       //                     {
       //                         if (Selectedpartylist[0].sch_qty_po_required > dgPOdeliveryschedule[x2].sch_qty)
       //                         {
       //                             qty = Convert.ToDecimal(Selectedpartylist[0].sch_qty_po_required - dgPOdeliveryschedule[x2].sch_qty);
       //                         }
       //                         else
       //                         {
       //                             qty = Convert.ToDecimal(dgPOdeliveryschedule[x2].sch_qty - Selectedpartylist[0].sch_qty_po_required);
       //                         }

       //                     }
       //                     else
       //                     {
       //                         qty = Convert.ToDecimal(Selectedpartylist[0].sch_qty);

       //                     }


       //                     if (qty > dgPOdeliveryschedule[x2].sch_qty_po_required)
       //                     {
       //                         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //                         showMessageService.ButtonSetup = DialogButton.Ok;
       //                         showMessageService.Caption = "Message";
       //                         showMessageService.Text = String.Format("Schedule Quantity Is Greater than PO Quantity", this.Title);
       //                         showMessageService.ShowMessage();
       //                         if (dgPOdeliveryschedule[x2].sch_qty_po_required < qty)
       //                         {
       //                             dgPOdeliveryschedule[x2].sch_qty = dgPOdeliveryschedule[x2].sch_qty_po_required;
       //                         }

       //                         dgPOschedule[x2].ScheduleSelect = true;
       //                     }
       //                     else
       //                     {
       //                         if (Selectedpartylist[0].item == dgPOdeliveryschedule[x2].item && Selectedpartylist[0].stockingunit == dgPOdeliveryschedule[x2].stockingunit)
       //                         {
       //                             var ParameterType = (from o in dgPOdeliveryschedule
       //                                                  where o.item == Selectedpartylist[0].item && o.stockingunit == Selectedpartylist[0].stockingunit
       //                                                  select o).ToList();

       //                             dgPOschedule.Where(l => l.item == ParameterType[0].item).Where(l => l.stockingunit == ParameterType[0].stockingunit).ToList().ForEach(i => i.ScheduleSelect = false);

       //                         }

       //                     }
       //                 }

       //             }
       //         }
       //     }
       //     catch
       //     {

       //     }


       // }

       // private void checkstatus(IList ItmList)
       // {
       //     IList list = ItmList as IList;
       //     List<SEL_T002_B> Selectedpartylist = list.Cast<SEL_T002_B>().ToList();
       //     if (Selectedpartylist[0].active == false)
       //     {
       //         dgPOdeliveryschedule.Where(l => l.id == Selectedpartylist[0].id).ToList().ForEach(i => i.active = false);
       //     }

       // }

       // private void AddSelectedItemTodeliveryschedule(IList ItmList)
       // {
       //     if (dgSelectedIndex != -1 && ItmList.Count > 0)
       //     {
       //         IList list = ItmList as IList;
       //         List<SalesOrder_deliveryschedule> SelectedCatItmDetails = list.Cast<SalesOrder_deliveryschedule>().ToList();
       //         decimal qty = 0;

       //         var item = (from o in SO_Dtails
       //                     where o.item_id == SelectedCatItmDetails[0].item && o.stocking_unit1 == SelectedCatItmDetails[0].stockingunit
       //                     select o).ToList();

       //         if (item.Count > 0)
       //         {
       //             qty = item[0].quantity;
       //         }
       //         var count = (from data in dgPOdeliveryschedule
       //                      where data.item == SelectedCatItmDetails[0].item && data.stockingunit == SelectedCatItmDetails[0].stockingunit
       //                      select data.item).Count();

       //         //var count1 = (from o in dgPOdeliveryschedule
       //         //              where o.item_id == SelectedCatItmDetails[0].item_id && o.count == dgPOdeliveryschedule[dgSelectedIndex2].count
       //         //              select o).ToList();                

       //         int deletecount = -1;

       //         //deletecount = count1[0].count;


       //         if (SelectedCatItmDetails.Count > 0)
       //         {
       //             for (int y = 0; y < dgPOdeliveryschedule.Count; y++)
       //             {

       //                 if (dgPOdeliveryschedule[y].item == SelectedCatItmDetails[0].item && dgPOdeliveryschedule[y].stockingunit == SelectedCatItmDetails[0].stockingunit)
       //                 {
       //                     qty = qty - Convert.ToDecimal(dgPOdeliveryschedule[y].confirm_qty);

       //                 }


       //             }
       //             if (qty > SelectedCatItmDetails[0].qty && SelectedCatItmDetails[0].ScheduleSelect == true)
       //             {
       //                 dgPOdeliveryschedule.Add(new SEL_T002_B()
       //                 {
       //                     item = Convert.ToInt32(SelectedCatItmDetails[0].item),
       //                     sch_qty_po_required = item[0].quantity,
       //                     sch_qty = qty,
       //                     so_id = (SelectedCatItmDetails[0].po_id),
       //                     cust_code = (SelectedCatItmDetails[0].cust_code),
       //                     cust_descr = (SelectedCatItmDetails[0].cust_descr),
       //                     so_qty = item[0].quantity,
       //                     count = count,
       //                     stockingunit = (SelectedCatItmDetails[0].stockingunit)

       //                 });
       //             }
       //             else if (qty < SelectedCatItmDetails[0].qty && SelectedCatItmDetails[0].ScheduleSelect == true)
       //             {

       //                 dgPOdeliveryschedule.Add(new SEL_T002_B()
       //                 {
       //                     item = Convert.ToInt32(SelectedCatItmDetails[0].item),
       //                     sch_qty_po_required = item[0].quantity,
       //                     sch_qty = qty,
       //                     so_id = (SelectedCatItmDetails[0].po_id),
       //                     cust_code = (SelectedCatItmDetails[0].cust_code),
       //                     cust_descr = (SelectedCatItmDetails[0].cust_descr),
       //                     so_qty = item[0].quantity,
       //                     count = count,
       //                     stockingunit = (SelectedCatItmDetails[0].stockingunit)
       //                 });
       //             }
       //             else if (qty == SelectedCatItmDetails[0].qty && SelectedCatItmDetails[0].ScheduleSelect == true)
       //             {


       //                 dgPOdeliveryschedule.Add(new SEL_T002_B()
       //                 {
       //                     item = Convert.ToInt32(SelectedCatItmDetails[0].item),
       //                     sch_qty_po_required = item[0].quantity,
       //                     sch_qty = Convert.ToDecimal(SelectedCatItmDetails[0].qty),
       //                     so_id = (SelectedCatItmDetails[0].po_id),
       //                     cust_code = (SelectedCatItmDetails[0].cust_code),
       //                     cust_descr = (SelectedCatItmDetails[0].cust_descr),
       //                     so_qty = item[0].quantity,
       //                     count = count,
       //                     stockingunit = (SelectedCatItmDetails[0].stockingunit)
       //                 });
       //             }



       //         }
       //         if (dgscheduledmaster.Count == 0)
       //         {
       //             dgscheduledmaster.Add(new SEL_T002()
       //             {
       //                 sch_no = "",
       //                 sch_mode = "SO",
       //                 sch_by = AppSessionState.UserID

       //             }
       //                 );
       //         }
       //     }

       // }

       // #endregion "Schedule"

       // #region "Parameter"
       // private void ParameterPopupClosed(IList param)
       // {

       //     string strData = "";
       //     string strData1 = "";
       //     ADM_M030_P productData = new ADM_M030_P();
       //     ADM_M030_P productData1 = new ADM_M030_P();
       //     IList list = param as IList;
       //     List<ADM_M030_P> Selectedpartylist = list.Cast<ADM_M030_P>().ToList();
       //     if (dgSelectedIndex != -1)
       //     {
       //         if (SO_Dtails[dgSelectedIndex].Description != null)
       //         {
       //             if (Selectedpartylist.Count > 0 && SO_Dtails[dgSelectedIndex].Description.Contains('\t'))
       //             {
       //                 if (Selectedpartylist[0].Name != null || SO_Dtails[dgSelectedIndex].item_id != null)
       //                 {
       //                     try
       //                     {
       //                         if (Selectedpartylist[0].item_id == SO_Dtails[dgSelectedIndex].item_id)
       //                         {

       //                             if (param.Count > 0)
       //                             {
       //                                 try
       //                                 {

       //                                     if (Selectedpartylist[0].Type != "" || Selectedpartylist[0].Type != null)
       //                                     {
       //                                         int itemid = Convert.ToInt32(SO_Dtails[dgSelectedIndex].item_id);
       //                                         try
       //                                         {
       //                                             for (int e = 0; e < ParamitemList.Count; e++)
       //                                             {
       //                                                 if (itemid == ParamitemList[e].item_id)
       //                                                 {
       //                                                     if (Selectedpartylist[0].Type == ParamitemList[e].Type)
       //                                                     {
       //                                                         ParamitemList.Where(l => l.Type == Selectedpartylist[0].Type).Where(l => l.item_id == itemid).Where(l => l.stockunit == SO_Dtails[dgSelectedIndex].stocking_unit1)
       //                                                         .ToList().ForEach(i => i.Name = Selectedpartylist[0].Name);

       //                                                         ParamitemList.Where(l => l.Type == Selectedpartylist[0].Type).Where(l => l.item_id == itemid).Where(l => l.stockunit == SO_Dtails[dgSelectedIndex].stocking_unit1)
       //                                                       .ToList().ForEach(i => i.code = dgSelectedIndex);

       //                                                     }
       //                                                 }
       //                                             }
       //                                         }
       //                                         catch
       //                                         {

       //                                         }
       //                                     }
       //                                     string code = "";
       //                                     foreach (var item in FluteList)
       //                                     {
       //                                         if (item.Name == Selectedpartylist[0].Name && item.Type == Selectedpartylist[0].Type)
       //                                         {
       //                                             strData = strData + " , " + item.Type + ":" + item.Name;
       //                                             strData = strData.Trim(new Char[] { ',', ' ', '.', '/', '\t' });
       //                                             strData1 = strData1 + " , " + item.Type + ":" + item.code;
       //                                             strData1 = strData1.Trim(new Char[] { ',', ' ', '.', '/', '\t' });
       //                                             code = Convert.ToString(item.code);
       //                                         }

       //                                     }
       //                                     string item1 = "";
       //                                     string description = "";
       //                                     try
       //                                     {
       //                                         item1 = SO_Dtails[dgSelectedIndex].item_name.ToString();
       //                                         description = SO_Dtails[dgSelectedIndex].Description.ToString();
       //                                     }
       //                                     catch
       //                                     {

       //                                     }
       //                                     string[] split = new string[50];
       //                                     string test = "";
       //                                     string test1 = "";
       //                                     if (item1.Contains("\t:" + Selectedpartylist[0].Type + ":"))
       //                                     {
       //                                         test = item1.Substring(0, item1.IndexOf(Selectedpartylist[0].Type + ":"));
       //                                         string y = item1.Substring(0, item1.IndexOf(Selectedpartylist[0].Type + ":"));
       //                                         string z = item1.Replace(y, "");
       //                                         split = z.Split(':');
       //                                         //test1 = item1.Replace(split[1], Selectedpartylist[0].Name + "\t");
       //                                         test1 = item1.Replace(Selectedpartylist[0].Type + ":" + split[1], Selectedpartylist[0].Type + ":" + Selectedpartylist[0].Name + "\t");

       //                                         strData = test1;
       //                                         if (description.Contains(Selectedpartylist[0].Type))
       //                                         {
       //                                             string test8 = description.Substring(0, description.IndexOf(Selectedpartylist[0].Type + ":"));
       //                                             string y1 = description.Substring(0, description.IndexOf(Selectedpartylist[0].Type + ":"));
       //                                             string z1 = description.Replace(y1, "");
       //                                             split = z1.Split(':');
       //                                             //string test2 = description.Replace(split[1], code + "\t");
       //                                             string test2 = description.Replace(Selectedpartylist[0].Type + ":" + split[1], Selectedpartylist[0].Type + ":" + code + "\t");
       //                                             try
       //                                             {
       //                                                 {
       //                                                     strData1 = "";
       //                                                     string[] stockvalues = new string[50];
       //                                                     stockvalues = test2.Split('\t');
       //                                                     for (int r = 0; r < stockvalues.Count(); r++)
       //                                                     {
       //                                                         if (stockvalues[r] != "")
       //                                                         {
       //                                                             if (r == 0)
       //                                                             {
       //                                                                 strData1 = stockvalues[0];
       //                                                             }
       //                                                             else
       //                                                             {
       //                                                                 strData1 = strData1 + "\t" + stockvalues[r];
       //                                                             }
       //                                                         }
       //                                                     }

       //                                                 }
       //                                             }
       //                                             catch
       //                                             {

       //                                             }


       //                                         }
       //                                         SO_Dtails[dgSelectedIndex].item_name = (strData);
       //                                         SO_Dtails[dgSelectedIndex].Description = (strData1);
       //                                         //SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_name = (strData));
       //                                         //SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.description = (strData1));
       //                                     }
       //                                     else
       //                                     {
       //                                         SO_Dtails[dgSelectedIndex].item_name = (SO_Dtails[dgSelectedIndex].item_name + "\t" + ":" + strData);
       //                                         SO_Dtails[dgSelectedIndex].Description = (SO_Dtails[dgSelectedIndex].Description + "\t" + ":" + strData1);

       //                                         //SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_name = (i.item_name + "\t" + ":" + strData));
       //                                         //SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.description = (i.description + "\t" + ":" + strData1));
       //                                     }
       //                                 }
       //                                 catch
       //                                 {

       //                                 }
       //                             }
       //                         }
       //                     }
       //                     catch
       //                     {

       //                     }
       //                     //try
       //                     //{
       //                     //    if (ValidateControlsRate() == true)
       //                     //    {
       //                     //        StockingUnitCalculationGorSupplierCatalogueRate();
       //                     //    }
       //                     //}
       //                     //catch
       //                     //{

       //                     //}
       //                     try
       //                     {
       //                         if (ValidateControls123() == true)
       //                         {
       //                             StockingUnitCalculation123();
       //                         }

       //                     }
       //                     catch
       //                     {

       //                     }
       //                 }

       //             }
       //         }
       //     }

       // }

       // private void StockingUnitCalculation123()
       // {
       //     string description = "";
       //     int count = 0;

       //     //for (int y = 0; y < dgcatalogItem.Count; y++)
       //     {
       //         try
       //         {
       //             description = SO_Dtails[dgSelectedIndex].Description.ToString();

       //         }
       //         catch
       //         {

       //         }
       //         string stockingunit = "";

       //         try
       //         {
       //             {

       //                 try
       //                 {
       //                     int index = SO_Dtails[dgSelectedIndex].ItemcodeStockUnit.IndexOf(':');
       //                     if (index != -1)
       //                     {
       //                         SO_Dtails[dgSelectedIndex].ItemcodeStockUnit = SO_Dtails[dgSelectedIndex].ItemcodeStockUnit.Substring(0, index - 1);
       //                     }
       //                 }
       //                 catch
       //                 {

       //                 }
       //                 while (description.Contains("\t"))
       //                 {
       //                     try
       //                     {

       //                         string itemcode = description.Substring(0, description.LastIndexOf(":"));
       //                         string itemcode1 = description.Replace(itemcode, "");
       //                         string itemcode2 = itemcode1.Replace(":", "");
       //                         if (count == 0)
       //                         {
       //                             if (itemcode2.Contains('-') || itemcode2.Contains('_') || itemcode2.Contains(':') || itemcode2.Contains(','))
       //                             {
       //                                 SO_Dtails[dgSelectedIndex].ItemcodeStockUnit = SO_Dtails[dgSelectedIndex].ItemcodeStockUnit + ":" + 0;
       //                             }
       //                             else
       //                             {
       //                                 SO_Dtails[dgSelectedIndex].ItemcodeStockUnit = SO_Dtails[dgSelectedIndex].ItemcodeStockUnit + ":" + itemcode2;
       //                             }
       //                         }
       //                         else
       //                         {
       //                             if (itemcode2.Contains('-') || itemcode2.Contains('_') || itemcode2.Contains(':') || itemcode2.Contains(','))
       //                             {
       //                                 SO_Dtails[dgSelectedIndex].ItemcodeStockUnit = SO_Dtails[dgSelectedIndex].ItemcodeStockUnit + "/" + 0;
       //                             }
       //                             else
       //                             {
       //                                 SO_Dtails[dgSelectedIndex].ItemcodeStockUnit = SO_Dtails[dgSelectedIndex].ItemcodeStockUnit + "/" + itemcode2;
       //                             }
       //                         }



       //                         string itemcode3 = itemcode.Substring(0, description.LastIndexOf("\t"));
       //                         description = itemcode3;
       //                         count++;
       //                     }
       //                     catch
       //                     {
       //                         break;
       //                     }
       //                 }
       //                 string[] stockvalues = new string[50];
       //                 stockvalues = SO_Dtails[dgSelectedIndex].ItemcodeStockUnit.Split(':');
       //                 string test = "";
       //                 SO_Dtails[dgSelectedIndex].stocking_unit1 = stockvalues[1];
       //                 SO_Dtails[dgSelectedIndex].stocking_unit = stockvalues[1];

       //                 ParamitemList.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.stockunit = stockvalues[1]);

       //             }
       //             count = 0;
       //         }
       //         catch
       //         {

       //         }


       //     }
       // }
       // private bool ValidateControls123()
       // {
       //     try
       //     {
       //         int i = 0;
       //         int count1 = 0;
       //         string[] values = new string[50];
       //         string description1 = "";
       //         try
       //         {
       //             //for (int y = 0; y < SO_Dtails.Count; y++)
       //             {
       //                 try
       //                 {
       //                     description1 = SO_Dtails[dgSelectedIndex].Description.ToString();
       //                     values = description1.Split('\t');
       //                 }
       //                 catch
       //                 {

       //                 }

       //                 try
       //                 {
       //                     int item_id = Convert.ToInt32(SO_Dtails[dgSelectedIndex].item_id);
       //                     int subcatcode = Convert.ToInt32(SO_Dtails[dgSelectedIndex].SubCategCod);
       //                     var ParameterType = (from o in MC.ParamvalList
       //                                          where o.SubCatCode == subcatcode
       //                                          select o).ToList();

       //                     for (int i1 = 0; i1 < values.Count(); i1++)
       //                     {
       //                         string[] val = values[i1].Split(':');
       //                         try
       //                         {
       //                             if (i1 != 0)
       //                             {
       //                                 if (val[2].ToString() != "")
       //                                 {
       //                                     i = 0;
       //                                 }
       //                                 else
       //                                 {
       //                                     i = 1;
       //                                     break;
       //                                 }
       //                             }
       //                         }
       //                         catch
       //                         {

       //                         }
       //                     }

       //                 }
       //                 catch
       //                 {

       //                 }
       //             }

       //         }
       //         catch (Exception ex)
       //         {

       //         }

       //         if (i == 0)
       //         {
       //             return true;
       //         }
       //         else
       //         {
       //             return false;
       //         }
       //     }
       //     catch (Exception ex)
       //     {
       //         return true;
       //     }
       // }
       // //private void ParameterPopupClosed(IList param)
       // //{

       // //    string strData = "";
       // //    string strData1 = "";
       // //    ADM_M030_P productData = new ADM_M030_P();
       // //    ADM_M030_P productData1 = new ADM_M030_P();
       // //    IList list = param as IList;
       // //    List<ADM_M030_P> Selectedpartylist = list.Cast<ADM_M030_P>().ToList();
       // //    if (Selectedpartylist.Count > 0)
       // //    {
       // //        if (Selectedpartylist[0].Name != null)
       // //        {
       // //            try
       // //            {
       // //                if (Selectedpartylist[0].item_id == SO_Dtails[dgSelectedIndex].item_id)
       // //                {

       // //                    if (param.Count > 0)
       // //                    {
       // //                        try
       // //                        {

       // //                            if (Selectedpartylist[0].Type != "" || Selectedpartylist[0].Type != null)
       // //                            {
       // //                                int itemid = Convert.ToInt32(SO_Dtails[dgSelectedIndex].item_id);
       // //                                try
       // //                                {
       // //                                    for (int e = 0; e < ParamitemList.Count; e++)
       // //                                    {
       // //                                        if (itemid == ParamitemList[e].item_id)
       // //                                        {
       // //                                            if (Selectedpartylist[0].Type == ParamitemList[e].Type)
       // //                                            {
       // //                                                ParamitemList.Where(l => l.Type == Selectedpartylist[0].Type).Where(l => l.item_id == itemid)
       // //                                                .ToList().ForEach(i => i.Name = Selectedpartylist[0].Name);

       // //                                                ParamitemList.Where(l => l.Type == Selectedpartylist[0].Type).Where(l => l.item_id == itemid)
       // //                                              .ToList().ForEach(i => i.code = 1);

       // //                                            }
       // //                                        }
       // //                                    }
       // //                                }
       // //                                catch
       // //                                {

       // //                                }
       // //                            }
       // //                            string code = "";
       // //                            foreach (var item in FluteList)
       // //                            {
       // //                                if (item.Name == Selectedpartylist[0].Name)
       // //                                {
       // //                                    strData = strData + " , " + item.Type + ":" + item.Name;
       // //                                    strData = strData.Trim(new Char[] { ',', ' ', '.', '/', '\t' });
       // //                                    strData1 = strData1 + " , " + item.Type + ":" + item.code;
       // //                                    strData1 = strData1.Trim(new Char[] { ',', ' ', '.', '/', '\t' });
       // //                                    code = Convert.ToString(item.code);
       // //                                }

       // //                            }
       // //                            string item1 = "";
       // //                            string description = "";
       // //                            try
       // //                            {
       // //                                item1 = SO_Dtails[dgSelectedIndex].item_name.ToString();
       // //                                description = SO_Dtails[dgSelectedIndex].Description.ToString();
       // //                            }
       // //                            catch
       // //                            {

       // //                            }
       // //                            string[] split = new string[50];
       // //                            string test = "";
       // //                            string test1 = "";
       // //                            if (item1.Contains("\t:" + Selectedpartylist[0].Type + ":"))
       // //                            {

       // //                                //item1.Insert()
       // //                                test = item1.Substring(0, item1.IndexOf(Selectedpartylist[0].Type + ":"));
       // //                                string y = item1.Substring(0, item1.IndexOf(Selectedpartylist[0].Type + ":"));
       // //                                string z = item1.Replace(y, "");
       // //                                split = z.Split(':');
       // //                                //test1 = item1.Replace(split[1], Selectedpartylist[0].Name + "\t");
       // //                                test1 = item1.Replace(Selectedpartylist[0].Type + ":" + split[1], Selectedpartylist[0].Type + ":" + Selectedpartylist[0].Name + "\t");
       // //                                strData = test1;

       // //                                if (description.Contains(Selectedpartylist[0].Type))
       // //                                {
       // //                                    string test8 = description.Substring(0, description.IndexOf(Selectedpartylist[0].Type + ":"));
       // //                                    string y1 = description.Substring(0, description.IndexOf(Selectedpartylist[0].Type + ":"));
       // //                                    string z1 = description.Replace(y1, "");
       // //                                    split = z1.Split(':');
       // //                                    //string test2 = description.Replace(split[1], code + "\t");
       // //                                    string test2 = description.Replace(Selectedpartylist[0].Type + ":" + split[1], Selectedpartylist[0].Type + ":" + code + "\t");

       // //                                    try
       // //                                    {

       // //                                        {
       // //                                            strData1 = "";
       // //                                            string[] stockvalues = new string[50];
       // //                                            stockvalues = test2.Split('\t');
       // //                                            for (int r = 0; r < stockvalues.Count(); r++)
       // //                                            {
       // //                                                if (stockvalues[r] != "")
       // //                                                {
       // //                                                    if (r == 0)
       // //                                                    {
       // //                                                        strData1 = stockvalues[0];
       // //                                                    }
       // //                                                    else
       // //                                                    {
       // //                                                        strData1 = strData1 + "\t" + stockvalues[r];
       // //                                                    }
       // //                                                }
       // //                                            }

       // //                                        }
       // //                                    }
       // //                                    catch
       // //                                    {

       // //                                    }


       // //                                }

       // //                                SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_name = (strData));
       // //                                SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.Description = (strData1));
       // //                            }
       // //                            else
       // //                            {

       // //                                SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_name = (i.item_name + "\t" + ":" + strData));
       // //                                SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.Description = (i.Description + "\t" + ":" + strData1));
       // //                            }
       // //                        }
       // //                        catch
       // //                        {

       // //                        }
       // //                    }
       // //                }
       // //            }
       // //            catch
       // //            {

       // //            }
       // //        }
       // //    }

       // //}
       // private void GetSelectedParameter(ADM_M030_P param)
       // {
       //     string strData = "";
       //     ADM_M030_P productData = new ADM_M030_P();

       //     FluteList = FluteList;
       //     if (param != null)
       //     {
       //         IList list = param as IList;
       //         List<ADM_M030_P> ItemsList = list.Cast<ADM_M030_P>().ToList();

       //         if (ItemsList.Count > 0)
       //         {
       //             productData = (ADM_M030_P)ItemsList[0];
       //         }
       //     }

       //     SO_Dtails.Where(l => l._CatParamName == productData.Type).ToList().ForEach(i => i.item_name = (i.item_name + "\t" + strData));

       // }

       // private void CollectionChanged(IList DataList)
       // {
       //     IList list = DataList as IList;
       //     try
       //     {
       //         List<SEL_T001_B> Selectedpartylist = list.Cast<SEL_T001_B>().ToList();
       //         if (Selectedpartylist[0].Stockable == true)
       //         {
       //             ParamitemList1 = new ObservableCollection<ADM_M030_P>();
       //             TotalParameterCollection = CollectionViewSource.GetDefaultView(MC.ParamvalList);
       //             if (ParamValuesList.Count == 0)
       //             {
       //                 for (int i = 0; i < TotalParameterCollection.Cast<ADM_M030_P>().ToList().Count(); i++)//*ADM_M030_P//new
       //                 {
       //                     ParamValuesList.Add(TotalParameterCollection.Cast<ADM_M030_P>().ElementAt(i));//*ADM_M030_P//new
       //                 }
       //             }
       //             if (SO_Dtails[dgSelectedIndex].id == 0 || SO_Dtails[dgSelectedIndex].id == null)
       //             {
       //                 if (SO_Dtails.Count > 0)
       //                 {
       //                     {

       //                         {
       //                             if (dgSelectedIndex != -1)
       //                             {
       //                                 try
       //                                 {

       //                                     int item_id = Convert.ToInt32(Selectedpartylist[0].item_id);
       //                                     int subcatcode = Convert.ToInt32(Selectedpartylist[0].SubCategCod);
       //                                     FluteList = MC.FluteList;
       //                                     var ParameterType = (from o in ParamValuesList
       //                                                          where o.SubCatCode == subcatcode
       //                                                          select o).ToList();

       //                                     var itemlist = (from o in ParamitemList
       //                                                     where o.item_id == item_id && o.count == dgSelectedIndex
       //                                                     select o).ToList();
       //                                     if (itemlist.Count == 0)
       //                                     {

       //                                         for (int r = 0; r < ParameterType.Count; r++)
       //                                         {
       //                                             ParamitemList.Add(new ADM_M030_P() { count = dgSelectedIndex, stockunit = SO_Dtails[dgSelectedIndex].stocking_unit1, Name = ParameterType[r].Name, item_id = item_id, SubCatCode = ParameterType[r].SubCatCode, Type = ParameterType[r].Type });

       //                                         }

       //                                     }
       //                                     try
       //                                     {
       //                                         string Reqstockingunit = "";
       //                                         string[] values1 = SO_Dtails[dgSelectedIndex].Description.Split('\t');
       //                                         string[] values = Selectedpartylist[0].stocking_unit.Split('/');
       //                                         try
       //                                         {

       //                                             for (int y = values.Count() - 1; y >= 0; y--)
       //                                             {
       //                                                 var stockingunit = (from o in FluteList
       //                                                                     where o.code == Convert.ToInt32(values[y].ToString())
       //                                                                     select o).ToList();
       //                                                 {
       //                                                     Reqstockingunit = Reqstockingunit + "\t" + ":" + stockingunit[0].Type + ":" + stockingunit[0].code;
       //                                                 }


       //                                             }
       //                                             SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.Description = (""));
       //                                             SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.Description = (values1[0] + Reqstockingunit));

       //                                         }
       //                                         catch
       //                                         {

       //                                         }
       //                                         int count = values.Length;
       //                                         for (int r = 0; r < count; r++)
       //                                         {
       //                                             var ParameterCollectionMethod = (from o in FluteList
       //                                                                              where o.code == Convert.ToInt32(values[r].ToString())
       //                                                                              select o).ToList();
       //                                             var Parameter = (from o in ParamitemList
       //                                                              where o.Type == (ParameterCollectionMethod[0].Type)
       //                                                              select o).ToList();


       //                                             if (Parameter[0].code == 0)
       //                                             {
       //                                                 if (SO_Dtails[dgSelectedIndex].stocking_unit1 == "" || SO_Dtails[dgSelectedIndex].stocking_unit1 == null)
       //                                                 {
       //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.Name = "");
       //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.stockunit = "");
       //                                                 }
       //                                                 else
       //                                                 {
       //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.Name = ParameterCollectionMethod[0].Name);
       //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.stockunit = SO_Dtails[dgSelectedIndex].stocking_unit1);
       //                                                 }
       //                                             }
       //                                             else
       //                                             {
       //                                                 if (SO_Dtails[dgSelectedIndex].stocking_unit1 == "" || SO_Dtails[dgSelectedIndex].stocking_unit1 == null)
       //                                                 {
       //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.Name = "");
       //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.stockunit = "");
       //                                                 }
       //                                                 else
       //                                                 {
       //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.Name = Parameter[0].Name);
       //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.stockunit = SO_Dtails[dgSelectedIndex].stocking_unit1);
       //                                                 }
       //                                             }
       //                                         }
       //                                     }
       //                                     catch
       //                                     {

       //                                     }
       //                                     ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);
       //                                     for (int r = 0; r < ParamitemList.Count; r++)
       //                                     {
       //                                         if (ParamitemList[r].item_id == item_id && ParamitemList[r].count == dgSelectedIndex)
       //                                         {
       //                                             ParamitemList1.Add(new ADM_M030_P() { Name = ParamitemList[r].Name, item_id = ParamitemList[r].item_id, SubCatCode = ParamitemList[r].SubCatCode, Type = ParamitemList[r].Type });
       //                                             ParameterCollection = CollectionViewSource.GetDefaultView(ParamitemList1);
       //                                         }
       //                                     }

       //                                     if (SO_Dtails[dgSelectedIndex].Description == null || SO_Dtails[dgSelectedIndex].Description == "")
       //                                     {
       //                                         //17Jan
       //                                         MCTemp.CatItems = ItemsCollection.Cast<CRM_T001B_ItemPopup_sale>().ToList();
       //                                         string tnm = (from data in MCTemp.CatItems where data.Srno == SO_Dtails[dgSelectedIndex].item_id select data.ItemName).ToList()[0].ToString();
       //                                         //SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_name = "");
       //                                         //SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.description = "");
       //                                         tnm = SO_Dtails[dgSelectedIndex].item_name;
       //                                         SO_Dtails[dgSelectedIndex].item_name = "";
       //                                         SO_Dtails[dgSelectedIndex].Description = "";
       //                                         //-17Jan
       //                                         for (int y = 0; y < ParamitemList1.Count; y++)
       //                                         {
       //                                             if (y == 0)
       //                                             {
       //                                                 //SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_name = tnm +"\t" + ":" + ParamitemList1[y].Type + ":");
       //                                                 //SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.description = tnm +"\t" + ":" + ParamitemList1[y].Type + ":");
       //                                                 SO_Dtails[dgSelectedIndex].item_name = tnm + "\t" + ":" + ParamitemList1[y].Type + ":";
       //                                                 SO_Dtails[dgSelectedIndex].Description = tnm + "\t" + ":" + ParamitemList1[y].Type + ":";

       //                                             }
       //                                             else
       //                                             {
       //                                                 SO_Dtails[dgSelectedIndex].item_name = SO_Dtails[dgSelectedIndex].item_name + "\t" + ":" + ParamitemList1[y].Type + ":";
       //                                                 SO_Dtails[dgSelectedIndex].Description = SO_Dtails[dgSelectedIndex].Description + "\t" + ":" + ParamitemList1[y].Type + ":";
       //                                             }
       //                                         }
       //                                     }
       //                                     else
       //                                     {

       //                                     }
       //                                 }
       //                                 catch
       //                                 {

       //                                 }

       //                             }
       //                         }
       //                     }
       //                 }
       //             }
       //             else if (SO_Dtails[dgSelectedIndex].id != 0 || SO_Dtails[dgSelectedIndex].id != null)
       //             {

       //                 if (dgSelectedIndex != -1)
       //                 {
       //                     try
       //                     {
       //                         int item_id = Convert.ToInt32(Selectedpartylist[0].item_id);
       //                         int subcatcode = Convert.ToInt32(Selectedpartylist[0].SubCategCod);
       //                         FluteList = MC.FluteList;
       //                         var ParameterType = (from o in ParamValuesList
       //                                              where o.SubCatCode == subcatcode
       //                                              select o).ToList();
       //                         var itemlist = (from o in ParamitemList
       //                                         where o.item_id == item_id && o.stockunit == SO_Dtails[dgSelectedIndex].stocking_unit
       //                                         select o).ToList();
       //                         if (itemlist.Count == 0)
       //                         {
       //                             {
       //                                 for (int r = 0; r < ParameterType.Count; r++)
       //                                 {
       //                                     ParamitemList.Add(new ADM_M030_P() { stockunit = SO_Dtails[dgSelectedIndex].stocking_unit, Name = ParameterType[r].Name, item_id = item_id, SubCatCode = ParameterType[r].SubCatCode, Type = ParameterType[r].Type });
       //                                 }
       //                             }
       //                         }
       //                         try
       //                         {
       //                             string[] values = Selectedpartylist[0].stocking_unit.Split('/');
       //                             int count = values.Length;
       //                             for (int r = 0; r < count; r++)
       //                             {
       //                                 var ParameterCollectionMethod = (from o in FluteList
       //                                                                  where o.code == Convert.ToInt32(values[r].ToString())
       //                                                                  select o).ToList();
       //                                 var Parameter = (from o in ParamitemList
       //                                                  where o.Type == (ParameterCollectionMethod[0].Type) && o.stockunit == SO_Dtails[dgSelectedIndex].stocking_unit
       //                                                  select o).ToList();
       //                                 if (Parameter[0].code == 0)
       //                                 {
       //                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.stockunit == SO_Dtails[dgSelectedIndex].stocking_unit).ToList().ForEach(i => i.Name = ParameterCollectionMethod[0].Name);
       //                                 }
       //                                 else
       //                                 {
       //                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.stockunit == SO_Dtails[dgSelectedIndex].stocking_unit).ToList().ForEach(i => i.Name = Parameter[0].Name);
       //                                 }
       //                             }
       //                         }
       //                         catch
       //                         {

       //                         }
       //                         ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);
       //                         for (int r = 0; r < ParamitemList.Count; r++)
       //                         {
       //                             if (ParamitemList[r].item_id == item_id && ParamitemList[r].stockunit == SO_Dtails[dgSelectedIndex].stocking_unit)
       //                             {
       //                                 ParamitemList1.Add(new ADM_M030_P() { Name = ParamitemList[r].Name, item_id = ParamitemList[r].item_id, SubCatCode = ParamitemList[r].SubCatCode, Type = ParamitemList[r].Type });
       //                                 ParameterCollection = CollectionViewSource.GetDefaultView(ParamitemList1);
       //                             }
       //                         }

       //                     }
       //                     catch
       //                     { }
       //                 }
       //             }
       //         }

       //         else
       //         {
       //             ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);
       //         }
       //     }
       //     catch
       //     {

       //     }
       // }


       // //private void CollectionChanged(IList DataList)
       // //{
       // //    IList list = DataList as IList;           
       // //    try
       // //    {               
       // //        List<SEL_T001_B> Selectedpartylist = list.Cast<SEL_T001_B>().ToList();


       // //        if (Selectedpartylist[0].Stockable == true)
       // //        {
       // //            ParamitemList1 = new ObservableCollection<ADM_M030_P>();
       // //            TotalParameterCollection = CollectionViewSource.GetDefaultView(MC.ParamvalList);
       // //            if (ParamValuesList.Count == 0)
       // //            {
       // //                for (int i = 0; i < TotalParameterCollection.Cast<ADM_M030_P>().ToList().Count(); i++)
       // //                {
       // //                    ParamValuesList.Add(TotalParameterCollection.Cast<ADM_M030_P>().ElementAt(i));
       // //                }
       // //            }
       // //            if (blNew == true)
       // //            {
       // //                if (SO_Dtails.Count > 0)
       // //                {
       // //                    {

       // //                        {
       // //                            if (dgSelectedIndex != -1)
       // //                            {
       // //                                try
       // //                                {

       // //                                    int item_id = Convert.ToInt32(Selectedpartylist[0].item_id);
       // //                                    int subcatcode = Convert.ToInt32(Selectedpartylist[0].SubCategCod);
       // //                                    FluteList = MC.FluteList;
       // //                                    var ParameterType = (from o in ParamValuesList
       // //                                                         where o.SubCatCode == subcatcode
       // //                                                         select o).ToList();

       // //                                    var itemlist = (from o in ParamitemList
       // //                                                    where o.item_id == item_id
       // //                                                    select o).ToList();
       // //                                    if (itemlist.Count == 0)
       // //                                    {

       // //                                        for (int r = 0; r < ParameterType.Count; r++)
       // //                                        {
       // //                                            ParamitemList.Add(new ADM_M030_P() { Name = ParameterType[r].Name, item_id = item_id, SubCatCode = ParameterType[r].SubCatCode, Type = ParameterType[r].Type });

       // //                                        }

       // //                                    }
       // //                                    try
       // //                                    {
       // //                                        string Reqstockingunit = "";
       // //                                        string[] values1 = SO_Dtails[dgSelectedIndex].Description.Split('\t');
       // //                                        string[] values = Selectedpartylist[0].stockingunit.Split('/');
       // //                                        try
       // //                                        {

       // //                                            for (int y = values.Count() - 1; y >= 0; y--)
       // //                                            {
       // //                                                var stockingunit = (from o in FluteList
       // //                                                                    where o.code == Convert.ToInt32(values[y].ToString())
       // //                                                                    select o).ToList();
       // //                                                {
       // //                                                    Reqstockingunit = Reqstockingunit + "\t" + ":" + stockingunit[0].Type + ":" + stockingunit[0].code;
       // //                                                }


       // //                                            }
       // //                                            SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.Description = (""));
       // //                                            SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.Description = (values1[0] + Reqstockingunit));

       // //                                        }
       // //                                        catch
       // //                                        {

       // //                                        }
       // //                                        int count = values.Length;
       // //                                        for (int r = 0; r < count; r++)
       // //                                        {
       // //                                            var ParameterCollectionMethod = (from o in FluteList
       // //                                                                             where o.code == Convert.ToInt32(values[r].ToString())
       // //                                                                             select o).ToList();
       // //                                            var Parameter = (from o in ParamitemList
       // //                                                             where o.Type == (ParameterCollectionMethod[0].Type)
       // //                                                             select o).ToList();
       // //                                            if (Parameter[0].code == 0)
       // //                                            {
       // //                                                ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.Name = ParameterCollectionMethod[0].Name);
       // //                                            }
       // //                                            else
       // //                                            {
       // //                                                ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.Name = Parameter[0].Name);
       // //                                            }
       // //                                        }
       // //                                    }
       // //                                    catch
       // //                                    {

       // //                                    }
       // //                                    ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);
       // //                                    for (int r = 0; r < ParamitemList.Count; r++)
       // //                                    {
       // //                                        if (ParamitemList[r].item_id == item_id)
       // //                                        {
       // //                                            ParamitemList1.Add(new ADM_M030_P() { Name = ParamitemList[r].Name, item_id = ParamitemList[r].item_id, SubCatCode = ParamitemList[r].SubCatCode, Type = ParamitemList[r].Type });
       // //                                            ParameterCollection = CollectionViewSource.GetDefaultView(ParamitemList1);
       // //                                        }
       // //                                    }
       // //                                    if (SO_Dtails[dgSelectedIndex].Description == null || SO_Dtails[dgSelectedIndex].Description == "")
       // //                                    {
       // //                                        //17Jan

       // //                                        string tnm = (from data in MCTemp.CatItems where data.ItemId == SO_Dtails[dgSelectedIndex].item_id select data.ItemName).ToList()[0].ToString();
       // //                                        SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_name = "");
       // //                                        SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.Description = "");

       // //                                        //-17Jan
       // //                                        for (int y = 0; y < ParamitemList1.Count; y++)
       // //                                        {
       // //                                            if (y == 0)
       // //                                            {
       // //                                                SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_name = tnm + "\t" + ":" + ParamitemList1[y].Type + ":");
       // //                                                SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.Description = tnm + "\t" + ":" + ParamitemList1[y].Type + ":");
       // //                                            }
       // //                                            else
       // //                                            {
       // //                                                SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_name = SO_Dtails[dgSelectedIndex].item_name + "\t" + ":" + ParamitemList1[y].Type + ":");
       // //                                                SO_Dtails.Where(l => l.item_id == SO_Dtails[dgSelectedIndex].item_id).ToList().ForEach(i => i.Description = SO_Dtails[dgSelectedIndex].Description + "\t" + ":" + ParamitemList1[y].Type + ":");
       // //                                            }
       // //                                        }
       // //                                    }
       // //                                }
       // //                                catch
       // //                                {

       // //                                }

       // //                            }
       // //                        }
       // //                    }
       // //                }
       // //            }
       // //            else
       // //            {

       // //                if (dgSelectedIndex != -1)
       // //                {
       // //                    try
       // //                    {
       // //                        int item_id = Convert.ToInt32(Selectedpartylist[0].item_id);
       // //                        int subcatcode = Convert.ToInt32(Selectedpartylist[0].SubCategCod);
       // //                        FluteList = MC.FluteList;
       // //                        var ParameterType = (from o in ParamValuesList
       // //                                             where o.SubCatCode == subcatcode
       // //                                             select o).ToList();
       // //                        var itemlist = (from o in ParamitemList
       // //                                        where o.item_id == item_id
       // //                                        select o).ToList();
       // //                        if (itemlist.Count == 0)
       // //                        {
       // //                            {
       // //                                for (int r = 0; r < ParameterType.Count; r++)
       // //                                {
       // //                                    ParamitemList.Add(new ADM_M030_P() { Name = ParameterType[r].Name, item_id = item_id, SubCatCode = ParameterType[r].SubCatCode, Type = ParameterType[r].Type });
       // //                                }
       // //                            }
       // //                        }
       // //                        try
       // //                        {
       // //                            string[] values = Selectedpartylist[0].stockingunit.Split('/');
       // //                            int count = values.Length;
       // //                            for (int r = 0; r < count; r++)
       // //                            {
       // //                                var ParameterCollectionMethod = (from o in FluteList
       // //                                                                 where o.code == Convert.ToInt32(values[r].ToString())
       // //                                                                 select o).ToList();
       // //                                var Parameter = (from o in ParamitemList
       // //                                                 where o.Type == (ParameterCollectionMethod[0].Type)
       // //                                                 select o).ToList();
       // //                                if (Parameter[0].code == 0)
       // //                                {
       // //                                    ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.Name = ParameterCollectionMethod[0].Name);
       // //                                }
       // //                                else
       // //                                {
       // //                                    ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).ToList().ForEach(i => i.Name = Parameter[0].Name);
       // //                                }
       // //                            }
       // //                        }
       // //                        catch
       // //                        {

       // //                        }
       // //                        ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);
       // //                        for (int r = 0; r < ParamitemList.Count; r++)
       // //                        {
       // //                            if (ParamitemList[r].item_id == item_id)
       // //                            {
       // //                                ParamitemList1.Add(new ADM_M030_P() { Name = ParamitemList[r].Name, item_id = ParamitemList[r].item_id, SubCatCode = ParamitemList[r].SubCatCode, Type = ParamitemList[r].Type });
       // //                                ParameterCollection = CollectionViewSource.GetDefaultView(ParamitemList1);
       // //                            }
       // //                        }

       // //                    }
       // //                    catch
       // //                    { }
       // //                }
       // //            }
       // //        }
       // //        else
       // //        {
       // //            ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);     
       // //        }
       // //    }
       // //    catch
       // //    {

       // //    }

       // //}

       // // This Function after save method for collecting parameter collection values
       // private void Update()
       // {
       //     if (blNew == false)
       //     {

       //         string taxvalue = "";
       //         try
       //         {
       //             for (int u = 0; u < MC.POtaxDetails.Count; u++)
       //             {
       //                 var ParameterType = (from o in MC.POtaxDetails
       //                                      where o.so_line_id == MC.POtaxDetails[u].so_line_id
       //                                      select o).ToList();

       //                 for (int y = 0; y < ParameterType.Count; y++)
       //                 {
       //                     if (y == 0)
       //                     {
       //                         taxvalue = Convert.ToString(ParameterType[y].tax_amount);
       //                     }
       //                     else
       //                     {
       //                         taxvalue = taxvalue + "," + Convert.ToString(ParameterType[y].tax_amount);
       //                     }
       //                 }

       //                 SO_Dtails.Where(l => l.item_id == MC.POtaxDetails[u].item_id).Where(l => l.stocking_unit1 == MC.POtaxDetails[u].stocking_unit1).ToList().ForEach(i => i.taxamount = (taxvalue));
       //                 u = u + ParameterType.Count - 1;
       //                 taxvalue = "";
       //             }

       //         }
       //         catch
       //         {

       //         }



       //     }

       //     string parametervale = "";
       //     string parametercode = "";
       //     for (int y = 0; y < SO_Dtails.Count; y++)
       //     {

       //         try
       //         {
       //             parametervale = "";
       //             parametercode = "";
       //             string stockingunit = SO_Dtails[y].stocking_unit;
       //             string[] tokens = stockingunit.Split('/');
       //             int count = tokens.Length;
       //             while (count > 0)
       //             {
       //                 string value = tokens[count - 1];
       //                 if (value != "")
       //                 {
       //                     var myItem = (from o in MC.FluteList
       //                                   where o.code == Convert.ToInt32(value)
       //                                   select o).ToList();
       //                     if (parametervale == "")
       //                     {
       //                         parametervale = myItem[0].Type + ":" + myItem[0].Name;
       //                         parametercode = myItem[0].Type + ":" + Convert.ToInt32(tokens[count - 1].ToString());
       //                     }
       //                     else
       //                     {
       //                         parametervale = parametervale + "\t:" + myItem[0].Type + ":" + myItem[0].Name;
       //                         parametercode = parametercode + "\t:" + myItem[0].Type + ":" + Convert.ToInt32(tokens[count - 1].ToString());
       //                     }
       //                 }
       //                 count = count - 1;
       //             }
       //             //dgPOItems.Where(l => l.item_id == dgPOItems[y].item_id).ToList().ForEach(i => i.item_name = (i.item_name + "\t" + parametervale));
       //             SO_Dtails.Where(l => l.item_id == SO_Dtails[y].item_id).Where(l => l.stocking_unit == SO_Dtails[y].stocking_unit).ToList().ForEach(i => i.Description = (i.item_code + "\t:" + parametercode));
       //             try
       //             {
       //                 for (int u = 0; u < ParamitemList.Count; u++)
       //                 {
       //                     ParamitemList[u].code = 0;
       //                 }

       //             }
       //             catch
       //             {

       //             }
       //         }
       //         catch
       //         {

       //         }
       //     }

       //     decimal total_amt2 = 0;
       //     decimal basic_amount1 = 0;

       //     try
       //     {
       //         decimal amount_taxed = 0;
       //         for (int u = 0; u < dgPOTotalTaxValues.Count; u++)
       //         {
       //             amount_taxed = amount_taxed + Convert.ToDecimal(dgPOTotalTaxValues[u].tax_amount);
       //         }
       //         for (int i = 0; i < SO_Dtails.Count; i++)
       //         {
       //             SO_Dtails[i].sub_total = ((SO_Dtails[i].quantity * SO_Dtails[i].unit_price));
       //             SO_Dtails[i].sub_total = ((SO_Dtails[i].quantity * SO_Dtails[i].unit_price) - (SO_Dtails[i].quantity * SO_Dtails[i].unit_price) * SO_Dtails[i].discount / 100);
       //             SelectedSEL_T001.untax_amt = SO_Dtails.Sum(t => t.sub_total);
       //         }


       //         SelectedSEL_T001.tax_amt = amount_taxed;
       //         SelectedSEL_T001.total_amt = amount_taxed + SelectedSEL_T001.untax_amt;
       //     }
       //     catch
       //     {

       //     }



       // }
       // private void updateDescription()
       // {
       //     string parametervale = "";
       //     string parametercode = "";
       //     for (int y = 0; y < SO_Dtails.Count; y++)
       //     {

       //         try
       //         {
       //             parametervale = "";
       //             parametercode = "";
       //             string stockingunit = SO_Dtails[y].stocking_unit;
       //             string[] tokens = stockingunit.Split('/');
       //             int count = tokens.Length;
       //             while (count > 0)
       //             {
       //                 string value = tokens[count - 1];
       //                 if (value != "")
       //                 {
       //                     var myItem = (from o in MC.FluteList
       //                                   where o.code == Convert.ToInt32(value)
       //                                   select o).ToList();
       //                     if (parametervale == "")
       //                     {
       //                         parametervale = myItem[0].Type + ":" + myItem[0].Name;
       //                         parametercode = myItem[0].Type + ":" + Convert.ToInt32(tokens[count - 1].ToString());
       //                     }
       //                     else
       //                     {
       //                         parametervale = parametervale + "\t:" + myItem[0].Type + ":" + myItem[0].Name;
       //                         parametercode = parametercode + "\t:" + myItem[0].Type + ":" + Convert.ToInt32(tokens[count - 1].ToString());
       //                     }
       //                 }
       //                 count = count - 1;
       //             }
       //             if (SO_Dtails[y].ItemName != "" || SO_Dtails[y] != null)
       //             {
       //                 string t_itemname = SO_Dtails[y].Description.Substring(0, SO_Dtails[y].Description.IndexOf("\t"));                        
       //                 SO_Dtails[y].ItemName = t_itemname + "\t:" + parametercode;
       //             }

       //         }
       //         catch
       //         {

       //         }
       //     }
       // }

       // private void StockingUnitCalculation()
       // {
       //     string description = "";
       //     int count = 0;

       //     for (int y = 0; y < SO_Dtails.Count; y++)
       //     {
       //         try
       //         {
       //             description = SO_Dtails[y].Description.ToString();
       //             if (SO_Dtails[y].item_code.Contains(":"))
       //             {
       //                 string[] splititem = new string[50];
       //                 splititem = SO_Dtails[y].item_code.Split(':');
       //                 SO_Dtails.Where(l => l.item_id == SO_Dtails[y].item_id)
       //                                              .ToList().ForEach(i => i.item_code = splititem[0]);

       //             }
       //         }
       //         catch
       //         {

       //         }
       //         string stockingunit = "";

       //         try
       //         {

       //             {
       //                 while (description.Contains("\t"))
       //                 {
       //                     try
       //                     {
       //                         string itemcode = description.Substring(0, description.LastIndexOf(":"));
       //                         string itemcode1 = description.Replace(itemcode, "");
       //                         string itemcode2 = itemcode1.Replace(":", "");
       //                         if (count == 0)
       //                         {
       //                             SO_Dtails[y].item_code = SO_Dtails[y].item_code + ":" + itemcode2;

       //                         }
       //                         else
       //                         {
       //                             SO_Dtails[y].item_code = SO_Dtails[y].item_code + "/" + itemcode2;

       //                         }
       //                         string itemcode3 = itemcode.Substring(0, description.LastIndexOf("\t"));
       //                         description = itemcode3;
       //                         count++;
       //                     }
       //                     catch
       //                     {
       //                         break;
       //                     }
       //                 }
       //             }
       //             count = 0;
       //         }
       //         catch
       //         {

       //         }

       //     }


       // }
       // #endregion

       // # region Tabchanged
       // private void LoadSelectedTab()
       // {
       //     try
       //     {


       //         if (SelectedTabIndex == 2)
       //         {
       //             foreach (var item in SO_Dtails)
       //             {
       //                 foreach (var item1 in dgPOschedule)
       //                 {
       //                     if (item.item_id == item1.item)
       //                     {
       //                         //if (item.qty != item1.qty)
       //                         //{
       //                         //    dgPOschedule.Where(l => l.item_id == item.item_id).ToList().ForEach(i => i.qty = (item.qty));
       //                         //    dgPOschedule.Where(l => l.item_id == item.item_id).ToList().ForEach(i => i.ScheduleSelect = false);

       //                         //    int x2 = dgPOdeliveryschedule.IndexOf(dgPOdeliveryschedule.Where(X => X.item_id != item.item_id).FirstOrDefault());
       //                         //    if (x2 != null)
       //                         //    {
       //                         //        try
       //                         //        {
       //                         //            dgPOdeliveryschedule.RemoveAt(x2 - 1);
       //                         //        }
       //                         //        catch
       //                         //        {

       //                         //        }
       //                         //    }
       //                         //}
       //                     }


       //                 }
       //             }
       //             var ParameterType = (from o in SO_Dtails
       //                                  where o.so_id == 0
       //                                  select o).ToList();

       //             foreach (var items in ParameterType)
       //             {
       //                 if (SelectedSEL_T001.doc_type_id != "OP")
       //                 {
       //                     if (items.quantity != 0)
       //                     {
       //                         var DuplicateItems = (from o in dgPOschedule
       //                                               where o.item == items.item_id && o.stockingunit == items.stocking_unit1
       //                                               select o).ToList();
       //                         if (DuplicateItems.Count == 0)
       //                         {
       //                             dgPOschedule.Add(new SalesOrder_deliveryschedule()
       //                             {
       //                                 item = (items.item_id),
       //                                 qty = items.quantity,
       //                                 po_id = 0,
       //                                 cust_code = items.item_code,
       //                                 cust_descr = items.item_name,
       //                                 ScheduleSelect = false,
       //                                 stockingunit = items.stocking_unit1


       //                             });
       //                         }

       //                     }
       //                     else
       //                     {
       //                         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //                         showMessageService.ButtonSetup = DialogButton.Ok;
       //                         showMessageService.Caption = "Message";
       //                         showMessageService.Text = String.Format("Quantity Should Be Greater Than 0", this.Title);
       //                         showMessageService.ShowMessage();
       //                         SelectedTabIndex = 1;
       //                         break;
       //                     }
       //                 }
       //                 else
       //                 {
       //                     var DuplicateItems = (from o in dgPOschedule
       //                                           where o.item == items.item_id && o.stockingunit == items.stocking_unit1
       //                                           select o).ToList();
       //                     if (DuplicateItems.Count == 0)
       //                     {
       //                         dgPOschedule.Add(new SalesOrder_deliveryschedule()
       //                         {
       //                             item = (items.item_id),
       //                             qty = items.quantity,
       //                             po_id = 0,
       //                             cust_code = items.item_code,
       //                             cust_descr = items.item_name,
       //                             ScheduleSelect = false,
       //                             stockingunit = items.stocking_unit1


       //                         });
       //                     }

       //                 }
       //             }

       //         }

       //     }
       //     catch (Exception ex)
       //     {
       //         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //         showMessageService.ButtonSetup = DialogButton.Ok;
       //         showMessageService.Caption = "Message";
       //         showMessageService.Text = String.Format(ex.Message, this.Title);
       //         showMessageService.ShowMessage();
       //     }
       // }
       // private bool ValidateControlsRate()
       // {
       //     try
       //     {
       //         int i = 0;
       //         int count1 = 0;
       //         string[] values = new string[50];
       //         string description1 = "";
       //         try
       //         {
       //             //for (int y = 0; y < SO_Dtails.Count; y++)
       //             //{
       //             try
       //             {
       //                 description1 = SO_Dtails[dgSelectedIndex].Description.ToString();
       //                 values = description1.Split('\t');
       //             }
       //             catch
       //             {

       //             }

       //             try
       //             {
       //                 int item_id = Convert.ToInt32(SO_Dtails[dgSelectedIndex].item_id);
       //                 int subcatcode = Convert.ToInt32(SO_Dtails[dgSelectedIndex].SubCategCod);
       //                 var ParameterType = (from o in MC.ParamvalList
       //                                      where o.SubCatCode == subcatcode
       //                                      select o).ToList();
       //                 for (int i1 = 0; i1 < values.Count(); i1++)
       //                 {
       //                     string[] val = values[i1].Split(':');
       //                     try
       //                     {
       //                         if (i1 != 0)
       //                         {
       //                             if (val[2].ToString() != "")
       //                             {
       //                                 i = 0;
       //                             }
       //                             else
       //                             {
       //                                 i = 1;
       //                                 break;
       //                             }
       //                         }
       //                     }
       //                     catch
       //                     {

       //                     }
       //                 }
       //                 //if ((values.Count() - 1) == ParameterType.Count)
       //                 //{
       //                 //    i = 0;

       //                 //}
       //                 //else
       //                 //{
       //                 //    i = 1;
       //                 //    break;
       //                 //}

       //             }
       //             catch
       //             {

       //             }
       //             //  }

       //         }
       //         catch (Exception ex)
       //         {

       //         }

       //         if (i == 0)
       //         {
       //             return true;
       //         }
       //         else
       //         {
       //             return false;
       //         }
       //     }
       //     catch (Exception ex)
       //     {
       //         return true;
       //     }
       // }
       // private bool ValidateControls()
       // {
       //     try
       //     {
       //         int i = 0;
       //         int count1 = 0;
       //         string[] values = new string[50];
       //         string description1 = "";

       //         try
       //         {
       //             for (int y = 0; y < SO_Dtails.Count; y++)
       //             {
       //                 try
       //                 {
       //                     description1 = SO_Dtails[y].Description.ToString();
       //                     values = description1.Split('\t');
       //                 }
       //                 catch
       //                 {

       //                 }

       //                 try
       //                 {
       //                     if (SO_Dtails[y].Stockable == true)
       //                     {
       //                         int item_id = Convert.ToInt32(SO_Dtails[y].item_id);
       //                         int subcatcode = Convert.ToInt32(SO_Dtails[y].SubCategCod);
       //                         var ParameterType = (from o in MC.ParamvalList
       //                                              where o.SubCatCode == subcatcode
       //                                              select o).ToList();
       //                         for (int i1 = 0; i1 < values.Count(); i1++)
       //                         {
       //                             string[] val = values[i1].Split(':');
       //                             try
       //                             {
       //                                 if (i1 != 0)
       //                                 {
       //                                     if (val[2].ToString() != "")
       //                                     {
       //                                         i = 0;
       //                                     }
       //                                     else
       //                                     {
       //                                         i = 1;
       //                                         break;
       //                                     }
       //                                 }
       //                             }
       //                             catch
       //                             {

       //                             }
       //                         }
       //                     }
       //                     else
       //                     {
       //                         i = 0;
       //                     }
       //                 }
       //                 catch
       //                 {
       //                     i = 1;
       //                     break;
       //                 }
       //             }

       //             if (i == 0)
       //             {
       //                 for (int y = 0; y < SO_Dtails.Count; y++)
       //                 {
       //                     if (SelectedSEL_T001.doc_type_id == "ST")
       //                     {
       //                         if (SO_Dtails[y].quantity <= 0)
       //                         {
       //                             i = 1;
       //                             IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //                             showMessageService.ButtonSetup = DialogButton.Ok;
       //                             showMessageService.Caption = "Message";
       //                             showMessageService.Text = String.Format("Can not save item with zero quantity for Transfer Order", this.Title);
       //                             showMessageService.ShowMessage();
       //                             break;
       //                         }
       //                     }
       //                 }
       //             }
       //         }
       //         catch (Exception ex)
       //         {
       //             i = 1;
       //         }
       //         if (i == 0)
       //         {
       //             return true;
       //         }
       //         else
       //         {
       //             return false;
       //         }
       //     }
       //     catch (Exception ex)
       //     {
       //         return true;
       //     }
       // }
       // #endregion


    }
}
