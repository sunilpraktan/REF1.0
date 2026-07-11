using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.WebServices.Gateway;
using System.Collections.ObjectModel;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using System.Reflection;
using Reflection.Presentation.Services;
using System.Collections.Specialized;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;


namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class PUR_T002_VMRFQ //: WindowViewModel<PUR_T002_A>, INotifyPropertyChanged
    {
       // #region .  .


       // bool blNew = true;
       // WebServiceRepository<PUR_T002_A> repository = new WebServiceRepository<PUR_T002_A>();
       // WebServiceRepository<MultipleContext_PUR_T002_A> repository_MC = new WebServiceRepository<MultipleContext_PUR_T002_A>();
       // WebServiceRepository<COM_T002_B_Delete> repository_B = new WebServiceRepository<COM_T002_B_Delete>();
       // WebServiceRepository<COM_T002_A_PopUp> repository_COM_T002_A_PopUp = new WebServiceRepository<COM_T002_A_PopUp>();
       // MultipleContext_PUR_T002_A _MC = new MultipleContext_PUR_T002_A();
       // public MultipleContext_PUR_T002_A MC
       // {
       //     get { return _MC; }
       //     set
       //     {
       //         if (_MC != value)
       //         {
       //             _MC = value;

       //             RaisePropertyChanged("MC");
       //         }
       //     }
       // }
       // void Model_ItemUpdated(object sender, EventArgs e)
       // {
       //     this.ErrorExist = SelectedPUR_T002_A.HasErrors;
       // }
       // MultipleContext_PUR_T002_A MC_temp = new MultipleContext_PUR_T002_A();

       // private string _filterString_AllPOData;
       // private string _filterString_party;     
       // private string _filterString_Buyer;
       // private string _filterString_Item;
       // private string _filterString_payterms;
       // private string _filterString_warehouse;
       // private string _filterString_uom;
       // private string _filterString_billaddr;
       // private string _filterString_deladdr;
       // private string _filterString_scheduleItem;     
       // private string _FilterStringSchrecby;

       // decimal tax = 0;
       // string taxval = "";

       // private int _dgSelectedIndex;
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
       //             RaisePropertyChanged("dgSelectedIndex");
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
       //             RaisePropertyChanged("dgSelectedIndex1");
       //         }
       //     }
       // }
       // private int _dgSelectedIndex2;
       // public int dgSelectedIndex2
       // {
       //     get
       //     {
       //         return _dgSelectedIndex2;
       //     }
       //     set
       //     {
       //         if (_dgSelectedIndex2 != value)
       //         {

       //             _dgSelectedIndex2 = value;
       //             RaisePropertyChanged("dgSelectedIndex2");
       //         }
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
       //             RaisePropertyChanged("SelectedTabIndex");

       //             if (SelectedTabIndex == 2)
       //             {
                        
       //             }

       //         }
       //     }
       // }

       // private Dictionary<string, object> _items;

       // public Dictionary<string, object> Items
       // {
       //     get { return _items; }
       //     set
       //     {
       //         if (_items != value)
       //         {
       //             _items = value;
       //             RaisePropertyChanged("Items");
       //         }
       //     }
       // }


       // private ObservableCollection<PUR_T002_B> _dgPOItems;
       // public ObservableCollection<PUR_T002_B> dgPOItems
       // {
       //     get
       //     {
       //         //this.ErrorExist = _dgPOItems.;
       //         return _dgPOItems;
       //     }
       //     set
       //     {
       //         if (_dgPOItems != value)
       //         {
       //             _dgPOItems = value;

       //             RaisePropertyChanged("dgPOItems");

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


       //             RaisePropertyChanged("dgReportMaster");

       //         }
       //     }
       // }

        
      
       // private Dictionary<string, object> _selectedItems;
       // public Dictionary<string, object> SelectedItems
       // {
       //     get
       //     {
       //         return _selectedItems;
       //     }
       //     set
       //     {
       //         _selectedItems = value;
       //         RaisePropertyChanged("SelectedItems");
       //     }
       // }
       // private PUR_T002_A _SelectedPUR_T002_A;
       // public PUR_T002_A SelectedPUR_T002_A
       // {
       //     get
       //     {
       //         this.ErrorExist = _SelectedPUR_T002_A.HasErrors;
       //         return _SelectedPUR_T002_A;
       //     }
       //     set
       //     {
       //         if (_SelectedPUR_T002_A != value)
       //         {
       //             _SelectedPUR_T002_A = value;
       //             this.ErrorExist = _SelectedPUR_T002_A.HasErrors;
       //             RaisePropertyChanged("SelectedPUR_T002_A");
       //             value.BeginEdit();
       //         }
       //     }
       // }

       
        

       // private List<PUR_T002_A> _SelectedList;
       // public List<PUR_T002_A> SelectedList
       // {
       //     get { return _SelectedList; }
       //     set
       //     {
       //         if (_SelectedList != value)
       //         {
       //             _SelectedList = value;


       //             RaisePropertyChanged("SelectedList");

       //         }
       //     }
       // }

       // ObservableCollection<ADM_M034_PopUp> _SelectedParmetersFrom = new ObservableCollection<ADM_M034_PopUp>();
       // public ObservableCollection<ADM_M034_PopUp> SelectedParmetersFrom
       // {
       //     get { return _SelectedParmetersFrom; }
       //     set
       //     {
       //         if (_SelectedParmetersFrom != value)
       //         {
       //             _SelectedParmetersFrom = value;

       //             this.RaisePropertyChanged("SelectedParmetersFrom");

       //         }
       //     }
       // }


       // ObservableCollection<ADM_M034_PopUp> _TempParmeters = new ObservableCollection<ADM_M034_PopUp>();
       // public ObservableCollection<ADM_M034_PopUp> TempParmeters
       // {
       //     get { return _TempParmeters; }
       //     set
       //     {
       //         if (_TempParmeters != value)
       //         {
       //             _TempParmeters = value;

       //             this.RaisePropertyChanged("TempParmeters");
       //         }
       //     }
       // }


       // List<CRM_T001B_PopUp_PUR> _ItemList = new List<CRM_T001B_PopUp_PUR>();
       // public List<CRM_T001B_PopUp_PUR> ItemList
       // {
       //     get { return _ItemList; }
       //     set
       //     {
       //         if (_ItemList != value)
       //         {
       //             _ItemList = value;

       //             RaisePropertyChanged("ItemList");
       //         }
       //     }
       // }

       // private ObservableCollection<SupplierCatalogueRange> __RateFromSupplierCatalogueCollection;
       // public ObservableCollection<SupplierCatalogueRange> RateFromSupplierCatalogueCollection
       // {
       //     get { return __RateFromSupplierCatalogueCollection; }
       //     set
       //     {
       //         if (__RateFromSupplierCatalogueCollection != value)
       //         {
       //             __RateFromSupplierCatalogueCollection = value;

       //             RaisePropertyChanged("_RateFromSupplierCatalogueCollection");

       //         }
       //     }
       // }
       // private ObservableCollection<ADM_M031_PopUp> __ParameterCodeCollection;
       // public ObservableCollection<ADM_M031_PopUp> ParameterCodeCollection
       // {
       //     get { return __ParameterCodeCollection; }
       //     set
       //     {
       //         if (__ParameterCodeCollection != value)
       //         {
       //             __ParameterCodeCollection = value;

       //             RaisePropertyChanged("ParameterCodeCollection");

       //         }
       //     }
       // }
       // private ICollectionView _dgPOItemsForParameterval;
       // public ICollectionView dgPOItemsForParameterval
       // {
       //     get { return _dgPOItemsForParameterval; }
       //     set
       //     {
       //         _dgPOItemsForParameterval = value;
       //         RaisePropertyChanged("dgPOItemsForParameterval");
       //     }
       // }

       
       
       // List<CRM_T001B_PopUp_PUR> _RequisitionItemList = new List<CRM_T001B_PopUp_PUR>();
       // public List<CRM_T001B_PopUp_PUR> RequisitionItemList
       // {
       //     get { return _RequisitionItemList; }
       //     set
       //     {
       //         if (_RequisitionItemList != value)
       //         {
       //             _RequisitionItemList = value;

       //             RaisePropertyChanged("RequisitionItemList");
       //         }
       //     }
       // }
       // List<CRM_T001B_PopUp_PUR> _SuppCatalogItemList = new List<CRM_T001B_PopUp_PUR>();
       // public List<CRM_T001B_PopUp_PUR> SuppCatalogItemList
       // {
       //     get { return _SuppCatalogItemList; }
       //     set
       //     {
       //         if (_SuppCatalogItemList != value)
       //         {
       //             _SuppCatalogItemList = value;

       //             RaisePropertyChanged("SuppCatalogItemList");
       //         }
       //     }
       // }
       // #endregion

       // #region ParameterList
       // private List<ADM_M034_PopUp> _SelectedParmeters = new List<ADM_M034_PopUp>();
       // public List<ADM_M034_PopUp> SelectedParmeters
       // {
       //     get { return _SelectedParmeters; }
       //     set
       //     {
       //         if (_SelectedParmeters != value)
       //         {
       //             _SelectedParmeters = value;

       //             RaisePropertyChanged("SelectedParmeters");
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
       //         RaisePropertyChanged("ParamList");
       //     }
       // }

       // private ObservableCollection<ADM_M030_P> _ParamValuesList;
       // public ObservableCollection<ADM_M030_P> ParamValuesList
       // {
       //     get { return _ParamValuesList; }
       //     set
       //     {
       //         _ParamValuesList = value;
       //         RaisePropertyChanged("ParamValuesList");
       //     }
       // }




       // private ObservableCollection<ADM_M030_P> _ParamitemList;
       // public ObservableCollection<ADM_M030_P> ParamitemList
       // {
       //     get { return _ParamitemList; }
       //     set
       //     {
       //         _ParamitemList = value;
       //         RaisePropertyChanged("ParamitemList");
       //     }
       // }
       // private ObservableCollection<ADM_M030_P> _ParamitemList1;
       // public ObservableCollection<ADM_M030_P> ParamitemList1
       // {
       //     get { return _ParamitemList1; }
       //     set
       //     {
       //         _ParamitemList1 = value;
       //         RaisePropertyChanged("ParamitemList1");
       //     }
       // }
       // private ObservableCollection<ADM_M030_P> _ParamclearList;
       // public ObservableCollection<ADM_M030_P> ParamclearList
       // {
       //     get { return _ParamclearList; }
       //     set
       //     {
       //         _ParamclearList = value;
       //         RaisePropertyChanged("ParamclearList");
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

       //             RaisePropertyChanged("FluteList");
       //         }
       //     }
       // }
       // public string _Flute;
       // public string Flute
       // {
       //     get
       //     {
       //         return this._Flute;
       //     }
       //     set
       //     {
       //         if ((this._Flute != value))
       //         {
       //             this._Flute = value;
       //             RaisePropertyChanged("Flute");
       //         }
       //     }
       // }

       // List<ADM_M030_P> _IndexList = new List<ADM_M030_P>();
       // public List<ADM_M030_P> IndexList
       // {
       //     get { return _IndexList; }
       //     set
       //     {
       //         if (_IndexList != value)
       //         {
       //             _IndexList = value;

       //             RaisePropertyChanged("IndexList");
       //         }
       //     }
       // }
       // public string _Shade;
       // public string Shade
       // {
       //     get
       //     {
       //         return this._Shade;
       //     }
       //     set
       //     {
       //         if ((this._Shade != value))
       //         {
       //             this._Shade = value;
       //             RaisePropertyChanged("Shade");
       //         }
       //     }
       // }
       // List<ParameterSelection> _MakeList = new List<ParameterSelection>();
       // public List<ParameterSelection> MakeList
       // {
       //     get { return _MakeList; }
       //     set
       //     {
       //         if (_MakeList != value)
       //         {
       //             _MakeList = value;

       //             RaisePropertyChanged("MakeList");
       //         }
       //     }
       // }
       // public string _Make;
       // public string Make
       // {
       //     get
       //     {
       //         return this._Make;
       //     }
       //     set
       //     {
       //         if ((this._Make != value))
       //         {
       //             this._Make = value;
       //             RaisePropertyChanged("Make");
       //         }
       //     }
       // }

       // List<ADM_M033_P> _ColourList = new List<ADM_M033_P>();
       // public List<ADM_M033_P> ColourList
       // {
       //     get { return _ColourList; }
       //     set
       //     {
       //         if (_ColourList != value)
       //         {
       //             _ColourList = value;

       //             RaisePropertyChanged("ColourList");
       //         }
       //     }
       // }
       // public string _Colour;
       // public string Colour
       // {
       //     get
       //     {
       //         return this._Colour;
       //     }
       //     set
       //     {
       //         if ((this._Colour != value))
       //         {
       //             this._Colour = value;
       //             RaisePropertyChanged("Colour");
       //         }
       //     }
       // }

       // #endregion

       // #region ICollection


       // private ICollectionView _dataGridCollection;
       // public ICollectionView DataGridCollection
       // {
       //     get { return _dataGridCollection; }
       //     set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
       // }
       // private ICollectionView _partyCollection;
       // public ICollectionView PartyCollection
       // {
       //     get { return _partyCollection; }
       //     set { _partyCollection = value; RaisePropertyChanged("PartyCollection"); }
       // }
       // private ICollectionView _buyerCollection;
       // public ICollectionView BuyerCollection
       // {
       //     get { return _buyerCollection; }
       //     set { _buyerCollection = value; RaisePropertyChanged("BuyerCollection"); }
       // }
       // private ICollectionView _uomCollection;
       // public ICollectionView UomCollection
       // {
       //     get { return _uomCollection; }
       //     set { _uomCollection = value; RaisePropertyChanged("UomCollection"); }
       // }
       // private ICollectionView _itemCollection;
       // public ICollectionView ItemCollection
       // {
       //     get { return _itemCollection; }
       //     set { _itemCollection = value; RaisePropertyChanged("ItemCollection"); }
       // }

       // private ICollectionView _RequisitionItemCollection;
       // public ICollectionView RequisitionItemCollection
       // {
       //     get { return _RequisitionItemCollection; }
       //     set { _RequisitionItemCollection = value; RaisePropertyChanged("RequisitionItemCollection"); }
       // }

       // private ICollectionView _billAddrCollection;
       // public ICollectionView BilAdderCollection
       // {
       //     get { return _billAddrCollection; }
       //     set { _billAddrCollection = value; RaisePropertyChanged("BilAdderCollection"); }
       // }
       // private ICollectionView _delAddrCollection;
       // public ICollectionView DelAddrCollection
       // {
       //     get { return _delAddrCollection; }
       //     set { _delAddrCollection = value; RaisePropertyChanged("DelAddrCollection"); }
       // }

       // private ICollectionView _paytermCollection;
       // public ICollectionView PayTermCollection
       // {
       //     get { return _paytermCollection; }
       //     set { _paytermCollection = value; RaisePropertyChanged("PayTermCollection"); }
       // }


       // private ICollectionView _warehouseCollection;
       // public ICollectionView warehouseCollection
       // {
       //     get { return _warehouseCollection; }
       //     set { _warehouseCollection = value; RaisePropertyChanged("warehouseCollection"); }
       // }


       // private ICollectionView _validatedByCollection;
       // public ICollectionView validatedByCollection
       // {
       //     get { return _validatedByCollection; }
       //     set { _validatedByCollection = value; RaisePropertyChanged("validatedByCollection"); }
       // }

       // private ICollectionView _ParameterCollection;
       // public ICollectionView ParameterCollection
       // {
       //     get { return _ParameterCollection; }
       //     set
       //     {
       //         _ParameterCollection = value;
       //         RaisePropertyChanged("ParameterCollection")
       //        ;
       //     }
       // }


       // private ICollectionView _TotalParameterCollection;
       // public ICollectionView TotalParameterCollection
       // {
       //     get { return _TotalParameterCollection; }
       //     set
       //     {
       //         _TotalParameterCollection = value;
       //         RaisePropertyChanged("TotalParameterCollection")
       //        ;
       //     }
       // }

       // private ICollectionView _RequisitionCollection;
       // public ICollectionView RequisitionCollection
       // {
       //     get { return _RequisitionCollection; }
       //     set { _RequisitionCollection = value; RaisePropertyChanged("RequisitionCollection"); }
       // }


       // private ICollectionView _ParameterCollection1;
       // public ICollectionView ParameterCollection1
       // {
       //     get { return _ParameterCollection1; }
       //     set { _ParameterCollection1 = value; RaisePropertyChanged("ParameterCollection1"); }
       // }

       // //----------------
       // private ICollectionView _doc_typeCollection;
       // public ICollectionView doc_typeCollection
       // {
       //     get { return _doc_typeCollection; }
       //     set
       //     {
       //         _doc_typeCollection = value;
       //         RaisePropertyChanged("doc_typeCollection");
       //     }
       // }
       // private ICollectionView _currencyCollection;
       // public ICollectionView currencyCollection
       // {
       //     get { return _currencyCollection; }
       //     set
       //     {
       //         _currencyCollection = value;
       //         RaisePropertyChanged("currencyCollection");
       //     }
       // }
       // private ICollectionView _reference_docCollection;
       // public ICollectionView reference_docCollection
       // {
       //     get { return _reference_docCollection; }
       //     set
       //     {
       //         _reference_docCollection = value;
       //         RaisePropertyChanged("reference_docCollection");
       //     }
       // }
       // private ICollectionView _po_orgCollection;
       // public ICollectionView po_orgCollection
       // {
       //     get { return _po_orgCollection; }
       //     set
       //     {
       //         _po_orgCollection = value;
       //         RaisePropertyChanged("po_orgCollection");
       //     }
       // }
       // private ICollectionView _distribution_channelCollection;
       // public ICollectionView distribution_channelCollection
       // {
       //     get { return _distribution_channelCollection; }
       //     set
       //     {
       //         _distribution_channelCollection = value;
       //         RaisePropertyChanged("distribution_channelCollection");
       //     }
       // }
       // private ICollectionView _sales_divisionCollection;
       // public ICollectionView sales_divisionCollection
       // {
       //     get { return _sales_divisionCollection; }
       //     set
       //     {
       //         _sales_divisionCollection = value;
       //         RaisePropertyChanged("sales_divisionCollection");
       //     }
       // }
       // private ICollectionView _sales_personCollection;
       // public ICollectionView sales_personCollection
       // {
       //     get { return _sales_personCollection; }
       //     set
       //     {
       //         _sales_personCollection = value;
       //         RaisePropertyChanged("sales_personCollection");
       //     }
       // }
       // private ICollectionView _sales_officeCollection;
       // public ICollectionView sales_officeCollection
       // {
       //     get { return _sales_officeCollection; }
       //     set
       //     {
       //         _sales_officeCollection = value;
       //         RaisePropertyChanged("sales_officeCollection");
       //     }
       // }
       // private ICollectionView _sales_groupCollection;
       // public ICollectionView sales_groupCollection
       // {
       //     get { return _sales_groupCollection; }
       //     set
       //     {
       //         _sales_groupCollection = value;
       //         RaisePropertyChanged("sales_groupCollection");
       //     }
       // }
       // private ICollectionView _storage_locCollection;
       // public ICollectionView storage_locCollection
       // {
       //     get { return _storage_locCollection; }
       //     set
       //     {
       //         _storage_locCollection = value;
       //         RaisePropertyChanged("storage_locCollection");
       //     }
       // }
       // private ICollectionView _storage_locItemCollection;
       // public ICollectionView storage_locItemCollection
       // {
       //     get { return _storage_locItemCollection; }
       //     set
       //     {
       //         _storage_locItemCollection = value;
       //         RaisePropertyChanged("storage_locItemCollection");
       //     }
       // }
       // private ICollectionView _cost_centerCollection;
       // public ICollectionView cost_centerCollection
       // {
       //     get { return _cost_centerCollection; }
       //     set
       //     {
       //         _cost_centerCollection = value;
       //         RaisePropertyChanged("cost_centerCollection");
       //     }
       // }
       // private ICollectionView _journalCollection;
       // public ICollectionView journalCollection
       // {
       //     get { return _journalCollection; }
       //     set
       //     {
       //         _journalCollection = value;
       //         RaisePropertyChanged("journalCollection");
       //     }
       // }
       // private ICollectionView _wtunitCollection;
       // public ICollectionView wtunitCollection
       // {
       //     get { return _wtunitCollection; }
       //     set
       //     {
       //         _wtunitCollection = value;
       //         RaisePropertyChanged("wtunitCollection");
       //     }
       // }
       // private ICollectionView _volumeunitCollection;
       // public ICollectionView volumeunitCollection
       // {
       //     get { return _volumeunitCollection; }
       //     set
       //     {
       //         _volumeunitCollection = value;
       //         RaisePropertyChanged("volumeunitCollection");
       //     }
       // }
       // private ICollectionView _itemcategoryCollection;
       // public ICollectionView itemcategoryCollection
       // {
       //     get { return _itemcategoryCollection; }
       //     set
       //     {
       //         _itemcategoryCollection = value;
       //         RaisePropertyChanged("itemcategoryCollection");
       //     }
       // }
       // private ObservableCollection<PUR_T004_B> _dgPOdeliveryschedule;
       // public ObservableCollection<PUR_T004_B> dgPOdeliveryschedule
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

       //             RaisePropertyChanged("dgPOdeliveryschedule");


       //         }
       //     }
       // }

       // #endregion

       // # region RelayCommands
       // public RelayCommand<DateTime> SelectionChangedCommandDate
       // {
       //     get;
       //     private set;
       // }
       
       // public RelayCommand<IList> ValidatedBy_SelectionChanged
       // {
       //     get;
       //     private set;
       // }
       // private RelayCommand _ExportCommand;
       // public RelayCommand ExportCommand
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> DeleteItemCommand
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> DeleteScheduleCommand
       // {
       //     get;
       //     private set;
       // }

       // public RelayCommand<Boolean> CheckedCommand
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<Boolean> ActiveCommand
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

     

       // public RelayCommand<IList> ParameterPopupCommand1
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



       // public RelayCommand<IList> ItemCellChangedCommand
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> ReqCellChangedCommand
       // {
       //     get;
       //     private set;
       // }
        
       // public RelayCommand<IList> ParameterNameCommand
       // {
       //     get;
       //     private set;
       // }


       // public RelayCommand<IList> SelectionChangedCommand
       // {
       //     get;
       //     private set;
       // }

        

       // public RelayCommand<IList> SelectionChangedCommandParty
       // {
       //     get;
       //     private set;
       // }

       // public RelayCommand<IList> paytermSelectionChangedCommand
       // {
       //     get;
       //     private set;
       // }

       // public RelayCommand<IList> WarehouseSelectionChangedCommand
       // {
       //     get;
       //     private set;
       // }

      
       // public RelayCommand<IList> CollectionChangedMethod
       // {
       //     get;
       //     private set;
       // }


       // public RelayCommand<IList> SelectionChangedCommandBuyer
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandItem
       // {
       //     get;
       //     private set;
       // }

       // public RelayCommand<IList> SelectionChangedCommandItemfordelivery
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandUom
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> billAddressSelectionChangedCommand
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> delAddressSelectionChangedCommand
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> CellChangedCommand
       // {
       //     get;
       //     private set;
       // }
       // public RelayCommand<IList> SelectionChangedCommandCmbo
       // {
       //     get;
       //     private set;
       // }


       // public RelayCommand<ADM_M030_P> ParameterSelectionChangedCommand
       // {
       //     get;
       //     private set;
       // }
       // //
       // public RelayCommand<IList> SelectedCommand_doc_type { get; private set; }
       // public RelayCommand<IList> SelectedCommand_currency { get; private set; }
       // public RelayCommand<IList> SelectedCommand_reference_doc { get; private set; }
       // public RelayCommand<IList> SelectedCommand_po_org { get; private set; }
       // public RelayCommand<IList> SelectedCommand_distribution { get; private set; }
       // public RelayCommand<IList> SelectedCommand_sales_division { get; private set; }
       // public RelayCommand<IList> SelectedCommand_sales_person { get; private set; }
       // public RelayCommand<IList> SelectedCommand_sales_office { get; private set; }
       // public RelayCommand<IList> SelectedCommand_sales_group { get; private set; }
       // public RelayCommand<IList> SelectedCommand_storage_loc { get; private set; }
       // public RelayCommand<IList> SelectedCommand_storage_loc_item { get; private set; }
       // public RelayCommand<IList> SelectedCommand_cost_center { get; private set; }
       // public RelayCommand<IList> SelectedCommand_Journal { get; private set; }
       // public RelayCommand<IList> SelectedCommand_wtunit { get; private set; }
       // public RelayCommand<IList> SelectedCommand_volumeunit { get; private set; }
       // public RelayCommand<IList> SelectedCommand_itemcategory { get; private set; }
       // public RelayCommand<IList> dgSelectionChanged
       // {
       //     get;
       //     private set;
       // }

       // #endregion

       // #region . Constructor .
       // public PUR_T002_VMRFQ()
       //     : base()
       // {
       //     dgPOdeliveryschedule = new ObservableCollection<PUR_T004_B>();
       //     SelectedPUR_T002_A = new PUR_T002_A();
       //     MC = new MultipleContext_PUR_T002_A();
       //     dgPOItems = new ObservableCollection<PUR_T002_B>();
       //     SelectedList = new List<PUR_T002_A>();
       //     MC.POItemsDetails = new ObservableCollection<PUR_T002_B>();
       //     SelectedPUR_T002_A.ValidateAsync().Wait();
       //     TempParmeters = new ObservableCollection<ADM_M034_PopUp>();
       //     FluteList = new List<ADM_M030_P>();
       //     IndexList = new List<ADM_M030_P>();
       //     MakeList = new List<ParameterSelection>();
       //     ColourList = new List<ADM_M033_P>();
       //     SelectedParmeters = new List<ADM_M034_PopUp>();
       //     ParamValuesList = new ObservableCollection<ADM_M030_P>();
       //     ParamitemList = new ObservableCollection<ADM_M030_P>();               
       //     //------------------------------LOGGING WINDOW
       //     docMessageData = new ObservableCollection<COM_T002_A_PopUp>();
       //     docFollowersData = new ObservableCollection<COM_T002_B_PopUp>();
       //     FollowerUserListToadd = new List<ADM_M024_PopUp_FollowerListToadd>();
       //     FollowerPartyListToadd = new List<ADM_M024_PopUp_FollowerListToadd>();
       //     //------------------------------LOGGING WINDOW
       //     ExportCommand = new RelayCommand(Export);
       //     PUR_T002_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
       //     SelectionChangedCommandDate = new RelayCommand<DateTime>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }

       //         GetSelectedBarcode(items);
       //     });



       //     ItemCellChangedCommand = new RelayCommand<IList>(
       //          items =>
       //          {
       //              if (items == null)
       //              {
       //                  return;
       //              }
       //              ButtonBChecked(items);
       //          });


       //     ReqCellChangedCommand = new RelayCommand<IList>(
       //          items =>
       //          {
       //              if (items == null)
       //              {
       //                  return;
       //              }
       //              ButtonAChecked(items);
       //          });




          



           




           



       //     CollectionChangedMethod = new RelayCommand<IList>(
       //      items =>
       //      {
       //          if (items == null)
       //          {
       //              return;
       //          }
       //          CollectionChanged(items);

       //      });


       //     SelectionChangedCommand = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }
       //         DetailsOfSelectedPO(items);

       //     });

       //     paytermSelectionChangedCommand = new RelayCommand<IList>(
       //      items =>
       //      {
       //          if (items == null)
       //          {
       //              return;
       //          }
       //          GetPayTerms(items);

       //      });
       //     SelectionChangedCommandParty = new RelayCommand<IList>(
       //      items =>
       //      {
       //          if (items == null)
       //          {
       //              return;
       //          }
       //          GetSelectedParty(items);

       //      });
       //     SelectionChangedCommandBuyer = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }
       //         GetSelectedBuyer(items);

       //     });

       //     WarehouseSelectionChangedCommand = new RelayCommand<IList>(
       //    items =>
       //    {
       //        if (items == null)
       //        {
       //            return;
       //        }
       //        AddWarehouse(items);

       //    });            


       //     SelectionChangedCommandItem = new RelayCommand<IList>(
       //    items =>
       //    {
       //        if (items == null)
       //        {
       //            return;
       //        }
       //        AddSelectedItemToCollection(items);

       //    });
       //     SelectionChangedCommandUom = new RelayCommand<IList>(
       //items =>
       //{
       //    if (items == null)
       //    {
       //        return;
       //    }
       //    AddSelectedUnitToCollection(items);
       //});
       //     billAddressSelectionChangedCommand = new RelayCommand<IList>(
       //       items =>
       //       {
       //           if (items == null)
       //           {
       //               return;
       //           }
       //           SelectBillAddress(items);
       //       });
       //     delAddressSelectionChangedCommand = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }
       //         SelectedDelAddress(items);
       //     });
       //     CellChangedCommand = new RelayCommand<IList>(
       //     items =>
       //     {
       //         if (items == null)
       //         {
       //             return;
       //         }
       //         CellChangeUpdate(items);
       //     });
       //     ValidatedBy_SelectionChanged = new RelayCommand<IList>(
       //       items =>
       //       {
       //           if (items == null)
       //           {
       //               return;
       //           }

       //           GetSelectedValidatedby(items);
       //       });

       //     ParameterSelectionChangedCommand = new RelayCommand<ADM_M030_P>(
       //         items =>
       //         {
       //             if (items == null)
       //             {
       //                 return;
       //             }
       //             GetSelectedParameter(items);
       //         }
       //         );

       //     ParameterPopupCommand = new RelayCommand<IList>(
       //            items =>
       //            {
       //                if (items == null)
       //                {
       //                    return;
       //                }
       //                ParameterPopupClosed(items);
       //            }
       //            );

       //     DeleteItemCommand = new RelayCommand<IList>(
       // items =>
       // {
       //     if (items == null)
       //     {
       //         return;
       //     }

       //     getSelectedRow(items);

       // });
            
       //     dgSelectionChanged = new RelayCommand<IList>(
       //   items =>
       //   {
       //       if (items == null)
       //       {
       //           return;
       //       }
       //       GetSelectedChanged(items);
       //   });
       //     SelectedCommand_doc_type = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_doc_type(items); });
       //     SelectedCommand_currency = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_currency(items); });
       //     SelectedCommand_reference_doc = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_reference_doc(items); });
       //     SelectedCommand_po_org = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_sales_org(items); });
       //     SelectedCommand_sales_group = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_sales_group(items); });
       //     SelectedCommand_storage_loc = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_storage_loc(items); });
       //     SelectedCommand_storage_loc_item = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_storage_loc_item(items); });
       //     SelectedCommand_cost_center = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_cost_center(items); });
       //     SelectedCommand_Journal = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_journal(items); });
       //     SelectedCommand_wtunit = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_wtunit(items); });
       //     SelectedCommand_volumeunit = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_volumeunit(items); });
       //     SelectedCommand_itemcategory = new RelayCommand<IList>(items => { if (items == null) { return; } getSelectedRow_itemcategory(items); });

       //     #region "Logging Window"
       //     SendMessage = new RelayCommand<object>(
       //        doc_id =>
       //        {
       //            if (doc_id == null)
       //            { return; }
       //            SendMessageData(doc_id);
       //        });
       //     CommandToAddFollower = new RelayCommand<object>(
       //         doc_id =>
       //         {
       //             if (doc_id == null)
       //             { return; }
       //             AddSelecdtedFollower(doc_id);
       //         });
       //     //---------------------------------------------
       //     DeleteFollower = new RelayCommand<object>(
       //        data =>
       //        {
       //            if (data == null)
       //            { return; }
       //            DeleteSelectedFollower(data);
       //        });
       //     MarkStarred = new RelayCommand<int>(
       //         data =>
       //         {
       //             //if (data == null)
       //             //{ return; }
       //             AddToDoList(data);
       //         });
       //     MarkSetBackToDo = new RelayCommand<int>(
       //       data =>
       //       {
       //           //if (data == null)
       //           //{ return; }
       //           AddBackToDo(data);
       //       });
       //     #endregion


       //     SelectedPUR_T002_A.po_date = DateTime.Now;
       //     SelectedPUR_T002_A.doc_cat = "RF";
       //     SelectedPUR_T002_A.doc_type = "RF";
       //     SelectedPUR_T002_A.quotation_date = DateTime.Now;
       //     SelectedPUR_T002_A.quotation_validity = DateTime.Now;           
       //     SelectedPUR_T002_A.valid_from_date = DateTime.Now;
       //     SelectedPUR_T002_A.valid_to_date = DateTime.Now;
       //     SelectedPUR_T002_A.doc_desc = "a";

       //     SelectedPUR_T002_A.del_address_id = "";
       //     SelectedPUR_T002_A.del_address_type = "da";
       //     SelectedPUR_T002_A.bill_address_id = "";
       //     SelectedPUR_T002_A.bill_address_type = "ba";
       //     SelectedPUR_T002_A.journal_id = 0;
       //     SelectedPUR_T002_A.journal_name = "j";
       //     SelectedPUR_T002_A.j_code = "J01";

       //     LoadInitialData();
       //     Items = new Dictionary<string, object>();
       //     SelectedItems = new Dictionary<string, object>();
       //     Items.Clear();
       // }

       // private void GetSelectedChanged(IList items)
       // {
       //     try
       //     {
       //         if (items.Count > 0 && dgSelectedIndex != -1 && dgPOItems.Count > dgSelectedIndex)
       //         {
       //             if (MC.itemList.Count() > 0)
       //             {
       //                 ItemList = new List<CRM_T001B_PopUp_PUR>();

       //             }
       //             else { dgPOItems = new ObservableCollection<PUR_T002_B>(); }


       //         }
       //         else { dgPOItems = new ObservableCollection<PUR_T002_B>(); }
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
       // private void getSelectedRow(IList SelectedItems)
       // {
       //     IList list = SelectedItems as IList;
       //     List<PUR_T002_B> GetSelectedPur_Req_Details = list.Cast<PUR_T002_B>().ToList();

       //     if (GetSelectedPur_Req_Details.Count > 0)
       //     {
       //         //var q = SelectedList.Where(X => X.id == GetSelectedPur_Req_Details[0].req_id).FirstOrDefault();
       //         int x = dgPOItems.IndexOf(dgPOItems.Where(X => X.item_id == GetSelectedPur_Req_Details[0].item_id).Where(X => X.stocking_unit1 == GetSelectedPur_Req_Details[0].stocking_unit1).FirstOrDefault());

       //         //if (SelectedPUR_T002_A.id == 0 && GetSelectedPur_Req_Details[0].po_id == null)
       //         //{
       //         if (GetSelectedPur_Req_Details[0].id == 0)
       //         {
       //             if (x >= 0 && x != -1)
       //             {
       //                 dgPOItems.RemoveAt(x);
       //             }
       //             MC.itemList.ToList().ForEach(t => t.Select = false);
       //         }
       //     }
       // }
       // #endregion

       // #region . PopMethods .

       // private void getSelectedRow_sales_group(IList items)
       // {
       //     try
       //     {
       //         List<ADM_M001_P_Popup> items1 = items.Cast<ADM_M001_P_Popup>().ToList();
       //         if (items1.Count() > 0)
       //         {
       //             SelectedPUR_T002_A.pg_code = items1[0].pg_code;
       //             SelectedPUR_T002_A.pg_name = items1[0].pg_name;
       //         }
       //     }
       //     catch { }
       // }

       // private void getSelectedRow_sales_org(IList items)
       // {
       //     try
       //     {
       //         List<ADM_M001_M_Popup> items1 = items.Cast<ADM_M001_M_Popup>().ToList();
       //         if (items1.Count() > 0)
       //         {
       //             SelectedPUR_T002_A.po_code = items1[0].po_code;
       //             SelectedPUR_T002_A.pur_org_name = items1[0].pur_org;
       //         }
       //     }
       //     catch { }
       // }

       // private void getSelectedRow_reference_doc(IList items)
       // {
       //     try
       //     {

       //     }
       //     catch { }
       // }

       // private void getSelectedRow_currency(IList items)
       // {
       //     try
       //     {
       //         List<ADM_M037_Popup> items1 = items.Cast<ADM_M037_Popup>().ToList();
       //         if (items1.Count() > 0)
       //         {
       //             SelectedPUR_T002_A.doc_currency = items1[0].id;
       //             SelectedPUR_T002_A.currency_name = items1[0].curr_name;
       //         }
       //     }
       //     catch { }
       // }

       // private void getSelectedRow_doc_type(IList items)
       // {
       //     try
       //     {
       //         List<SYS_M007_Popup> items1 = items.Cast<SYS_M007_Popup>().ToList();
       //         if (items1.Count() > 0)
       //         {
       //             SelectedPUR_T002_A.doc_type = items1[0].doc_type;
       //             SelectedPUR_T002_A.doc_desc = items1[0].doc_desc;
       //         }
       //     }
       //     catch { }
       // }

       // private void getSelectedRow_storage_loc(IList items)
       // {
       //     try
       //     {
       //         List<MM_M001_PopUp> items1 = items.Cast<MM_M001_PopUp>().ToList();
       //         if (items1.Count() > 0)
       //         {
       //             SelectedPUR_T002_A.stock_location_id = items1[0].store_code;
       //             SelectedPUR_T002_A.stock_location_name = items1[0].store_name;
       //         }
       //     }
       //     catch { }
       // }

       // private void getSelectedRow_cost_center(IList items)
       // {
       //     try
       //     {
       //         List<ACC_M019_Popup> items1 = items.Cast<ACC_M019_Popup>().ToList();
       //         if (items1.Count() > 0)
       //         {
       //             SelectedPUR_T002_A.cost_center = items1[0].cost_center;
       //             SelectedPUR_T002_A.cost_center_name = items1[0].cost_center;
       //         }
       //     }
       //     catch { }
       // }

       // private void getSelectedRow_journal(IList items)
       // {
       //     try
       //     {
       //         List<ACC_M005_PopUp> items1 = items.Cast<ACC_M005_PopUp>().ToList();
       //         if (items1.Count() > 0)
       //         {
       //             SelectedPUR_T002_A.journal_id = items1[0].id;
       //             SelectedPUR_T002_A.journal_name = items1[0].journal_name;
       //         }
       //     }
       //     catch { }
       // }
       // private void getSelectedRow_storage_loc_item(IList items)
       // {
       //     try
       //     {
       //         List<MM_M001_PopUp> items1 = items.Cast<MM_M001_PopUp>().ToList();
       //         if (items1.Count() > 0)
       //         {
       //             if (dgPOItems.Count > 0 && dgSelectedIndex != -1 && dgPOItems.Count > dgSelectedIndex)
       //             {
       //                 //dgPOItems[dgSelectedIndex].storage_loc = items1[0].store_code;
       //                 //dgPOItems[dgSelectedIndex].storage_loc_name = items1[0].store_name;
       //             }
       //         }
       //     }
       //     catch { }
       // }
       // private void getSelectedRow_wtunit(IList items)
       // {
       //     try
       //     {
       //         List<ADM_M038_B_PopUp> items1 = items.Cast<ADM_M038_B_PopUp>().ToList();
       //         if (items1.Count() > 0)
       //         {
       //             if (dgPOItems.Count > 0 && dgSelectedIndex != -1 && dgPOItems.Count > dgSelectedIndex)
       //             {
       //                 //dgPOItems[dgSelectedIndex].wt_unit = items1[0].id;
       //                 //dgPOItems[dgSelectedIndex].weight_unit_name = items1[0].unit_name;
       //             }
       //         }
       //     }
       //     catch { }
       // }

       // private void getSelectedRow_volumeunit(IList items)
       // {
       //     try
       //     {
       //         List<ADM_M038_B_PopUp> items1 = items.Cast<ADM_M038_B_PopUp>().ToList();
       //         if (items1.Count() > 0)
       //         {
       //             if (dgPOItems.Count > 0 && dgSelectedIndex != -1 && dgPOItems.Count > dgSelectedIndex)
       //             {
       //                 //dgPOItems[dgSelectedIndex].volume_unit = items1[0].id;
       //                 //dgPOItems[dgSelectedIndex].volume_unit_name = items1[0].unit_name;
       //             }
       //         }
       //     }
       //     catch { }
       // }

       // private void getSelectedRow_itemcategory(IList items)
       // {
       //     try
       //     {
       //         List<SYS_M003_PopUp> items1 = items.Cast<SYS_M003_PopUp>().ToList();
       //         if (items1.Count() > 0)
       //         {
       //             if (dgPOItems.Count > 0 && dgSelectedIndex != -1 && dgPOItems.Count > dgSelectedIndex)
       //             {
       //                 dgPOItems[dgSelectedIndex].item_cat_id = items1[0].sditem_cat_code;
       //                 //dgPOItems[dgSelectedIndex].item_cat_id = items1[0].item_cat_desc;
       //             }
       //         }
       //     }
       //     catch { }
       // }


       // #endregion

       // #region "Logging Functions"

       // #region "LoggingData"

       // WebServiceRepository<Multiple_Complex_COM_T002> repository_COM = new WebServiceRepository<Multiple_Complex_COM_T002>();

       // //------------------Dictionary
       // private Dictionary<string, object> _userList;
       // private Dictionary<string, object> _selected_userList;
       // public Dictionary<string, object> userList
       // {
       //     get { return _userList; }
       //     set
       //     {
       //         if (_userList != value)
       //         {
       //             _userList = value;
       //             RaisePropertyChanged("userList");
       //         }
       //     }
       // }
       // public Dictionary<string, object> selected_userList
       // {
       //     get
       //     {
       //         return _selected_userList;
       //     }
       //     set
       //     {
       //         _selected_userList = value;
       //         NotifyPropertyChanged("selected_userList");
       //     }
       // }
       // private Dictionary<string, object> _partyList;
       // private Dictionary<string, object> _selected_partyList;
       // public Dictionary<string, object> partyList
       // {
       //     get { return _partyList; }
       //     set
       //     {
       //         if (_partyList != value)
       //         {
       //             _partyList = value;
       //             RaisePropertyChanged("partyList");
       //         }
       //     }
       // }
       // public Dictionary<string, object> selected_partyList
       // {
       //     get
       //     {
       //         return _selected_partyList;
       //     }
       //     set
       //     {
       //         _selected_partyList = value;
       //         NotifyPropertyChanged("selected_partyList");
       //     }
       // }
       // //----------------------------
       // private string _follower_cnt;
       // public string follower_cnt
       // {
       //     get { return _follower_cnt; }
       //     set
       //     {
       //         if (_follower_cnt != value)
       //         {
       //             _follower_cnt = value;
       //             RaisePropertyChanged("follower_cnt");
       //         }
       //     }
       // }
       // public RelayCommand<object> SendMessage { get; private set; }
       // public RelayCommand<object> CommandToAddFollower { get; private set; }
       // //---------------------------
       // public RelayCommand<object> DeleteFollower { get; private set; }
       // public RelayCommand<int> MarkStarred { get; private set; }
       // public RelayCommand<int> MarkSetBackToDo { get; private set; }
       // //---------------------------
       // private ObservableCollection<COM_T002_A_PopUp> _docMessageData;
       // public ObservableCollection<COM_T002_A_PopUp> docMessageData
       // {
       //     get { return _docMessageData; }
       //     set { _docMessageData = value; RaisePropertyChanged("docMessageData"); }
       // }

       // private ObservableCollection<COM_T002_B_PopUp> _docFollowersData;
       // public ObservableCollection<COM_T002_B_PopUp> docFollowersData
       // {
       //     get { return _docFollowersData; }
       //     set { _docFollowersData = value; RaisePropertyChanged("docFollowersData"); }
       // }
       // //-----------------------------
       // private List<ADM_M024_PopUp_FollowerListToadd> _FollowerUserListToadd;
       // public List<ADM_M024_PopUp_FollowerListToadd> FollowerUserListToadd
       // {
       //     get { return _FollowerUserListToadd; }
       //     set
       //     {
       //         if (_FollowerUserListToadd != value)
       //         {
       //             _FollowerUserListToadd = value;
       //             RaisePropertyChanged("FollowerUserListToadd");
       //         }
       //     }
       // }

       // private List<ADM_M024_PopUp_FollowerListToadd> _FollowerPartyListToadd;
       // public List<ADM_M024_PopUp_FollowerListToadd> FollowerPartyListToadd
       // {
       //     get { return _FollowerPartyListToadd; }
       //     set
       //     {
       //         if (_FollowerPartyListToadd != value)
       //         {
       //             _FollowerPartyListToadd = value;
       //             RaisePropertyChanged("FollowerPartyListToadd");
       //         }
       //     }
       // }

       // private List<COM_T002_A> _Selected_Temp = new List<COM_T002_A>();
       // public List<COM_T002_A> Selected_Temp
       // {
       //     get { return _Selected_Temp; }
       //     set
       //     {
       //         if (_Selected_Temp != value)
       //         {
       //             _Selected_Temp = value;

       //             RaisePropertyChanged("Selected_Temp");
       //         }
       //     }
       // }
       // //-------------------------
       // private COM_T002_A _SelectedMessage = new COM_T002_A();
       // public COM_T002_A SelectedMessage
       // {
       //     get { return _SelectedMessage; }
       //     set
       //     {
       //         if (_SelectedMessage != value)
       //         {
       //             _SelectedMessage = value;

       //             RaisePropertyChanged("SelectedMessage");
       //         }
       //     }
       // }

       // private COM_T002_A _Selected_NewFollowerMessage = new COM_T002_A();
       // public COM_T002_A Selected_NewFollowerMessage
       // {
       //     get { return _Selected_NewFollowerMessage; }
       //     set
       //     {
       //         if (_Selected_NewFollowerMessage != value)
       //         {
       //             _Selected_NewFollowerMessage = value;

       //             RaisePropertyChanged("Selected_NewFollowerMessage");
       //         }
       //     }
       // }

       // #endregion

       // private void LoadAllFollowers()
       // {
       //     var temp_data = (from data in MC.FollowerListToadd where data.type == "user" select data).ToList();
       //     FollowerUserListToadd = (List<ADM_M024_PopUp_FollowerListToadd>)temp_data.ToList();
       //     var temp_data1 = (from data in MC.FollowerListToadd where data.type == "party" select data).ToList();
       //     FollowerPartyListToadd = (List<ADM_M024_PopUp_FollowerListToadd>)temp_data1.ToList();

       //     userList = new Dictionary<string, object>();
       //     userList.Clear();
       //     if (FollowerUserListToadd != null)
       //     { userList = FollowerUserListToadd.ToDictionary(X => X.id.ToString(), X => (object)X.name); }

       //     partyList = new Dictionary<string, object>();
       //     partyList.Clear();
       //     if (FollowerPartyListToadd != null)
       //     { partyList = FollowerPartyListToadd.ToDictionary(X => X.id.ToString(), X => (object)X.name); }

       // }
       // private void LoadSelectedDocData()
       // {
       //     docMessageData = MC_temp.documentMessagesList;
       //     docFollowersData = MC_temp.documentFollowersList;
       //     if (docFollowersData != null)
       //     {
       //         follower_cnt = docFollowersData.Count().ToString() + " Follower";
       //     }
       // }
       // private void ClearAll()
       // {
       //     SelectedMessage = new COM_T002_A();
       //     Selected_NewFollowerMessage = new COM_T002_A();
       //     follower_cnt = "";
       //     docFollowersData = new ObservableCollection<COM_T002_B_PopUp>();
       //     docMessageData = new ObservableCollection<COM_T002_A_PopUp>();
       //     //var temp_data = (from data in MC_CRM_T001A.FollowerListToadd where data.type == "user" select data).ToList();
       //     //FollowerUserListToadd = (List<ADM_M024_PopUp_FollowerListToadd>)temp_data.ToList();
       //     //userList.Clear();
       //     //if (FollowerUserListToadd != null)
       //     //{ userList = FollowerUserListToadd.ToDictionary(X => X.id.ToString(), X => (object)X.name); }

       // }
       // private string AddExistingFollower(COM_T002_A obj)
       // {
       //     List<string> arr_user = new List<string>();
       //     foreach (var item in docFollowersData)
       //     {
       //         if ((obj.user_id != null))
       //         {
       //             if ((obj.user_id != ""))
       //             {
       //                 arr_user = obj.user_id.Split(',').ToList();
       //             }
       //         }

       //         if (obj.user_id == null && item.follower_type == "user")
       //         {
       //             obj.user_id = item.follower_id.ToString();
       //         }
       //         else if ((obj.user_id == ""))
       //         {
       //             obj.user_id = item.follower_id.ToString();
       //         }
       //         else
       //         {
       //             int i = 0;
       //             foreach (var t in arr_user)
       //             {
       //                 if (Convert.ToInt32(t) != item.follower_id && i != 1 && item.follower_type == "user" && !arr_user.Contains(item.follower_id.ToString()))
       //                 {
       //                     i = 1;
       //                     obj.user_id = obj.user_id + "," + item.follower_id;
       //                 }
       //                 else if (Convert.ToInt32(t) == item.follower_id)
       //                 {
       //                     i = 1;
       //                 }
       //             }
       //         }
       //     }
       //     if (obj.user_id.Remove(obj.user_id.Length - 1) == ",")
       //     {
       //         obj.user_id = SelectedMessage.user_id.Remove(obj.user_id.Length - 1);
       //     }
       //     return obj.user_id;
       // }
       // //------------------------------
       // private void SendMessageData(object doc_data)
       // {
       //     List<string> str = doc_data.ToString().Split('/').ToList<string>();
       //     try
       //     {
       //         if (Convert.ToInt32(str[0]) != 0)
       //         {
       //             Multiple_Complex_COM_T002 MCtemp = new Multiple_Complex_COM_T002();

       //             if ((SelectedMessage.user_id != null || SelectedMessage.party_id != null) && (SelectedMessage.doc_id != null || SelectedMessage.doc_id != 0))
       //             {
       //                 SelectedMessage.doc_id = Convert.ToInt32(str[0]);
       //                 SelectedMessage.doc_type = str[1];
       //                 SelectedMessage.doc_name = str[2];
       //                 SelectedMessage.msg_category = "Comment";
       //                 SelectedMessage.author_id = AppSessionState.UserID;
       //                 SelectedMessage.add_by = AppSessionState.UserID.ToString();

       //                 SelectedMessage.user_id = AddExistingFollower(SelectedMessage);

       //                 Selected_Temp.Add(SelectedMessage);
       //                 MCtemp.followersMessagesList = Selected_Temp;

       //                 MCtemp = repository_COM.SaveWithReturnDomainObject<Multiple_Complex_COM_T002>(MCtemp, "LoggingControl", "Communication");
       //                 if (MCtemp.documentFollowersList != null && MCtemp.documentMessagesList != null)
       //                 {
       //                     foreach (var item in MCtemp.documentFollowersList)
       //                     {
       //                         docFollowersData.Add(item);
       //                     }
       //                     foreach (var item in MCtemp.documentMessagesList)
       //                     {
       //                         docMessageData.Add(item);
       //                     }
       //                     IEnumerable<COM_T002_A_PopUp> toUse = docMessageData
       //                     .Select(color => color)
       //                     .OrderByDescending(cc => cc.id)
       //                     .ToList();
       //                     docMessageData = new ObservableCollection<COM_T002_A_PopUp>(toUse.ToList());
       //                     //---------------------------Send Mail
       //                     getMailstring(SelectedMessage);

       //                     follower_cnt = docFollowersData.Count() + " Follower";
       //                 }
       //                 SelectedMessage = new COM_T002_A();
       //                 MCtemp.followersMessagesList = new List<COM_T002_A>();
       //                 Selected_Temp = new List<COM_T002_A>();
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

       // private void GetSelectedBarcode(DateTime barcode)
       // {
       //     try
       //     {
       //         if (barcode.ToString() != "")
       //         {
       //         }
       //         string strExp;
       //         string strSort;
       //         DateTime Barcodevalue = Convert.ToDateTime(barcode.ToString().Trim());
       //         //if (SelectedPUR_T002_A.po_date == null)
       //         //{

       //         //}
       //         //else
       //         //{
       //         //    DateTime values = Convert.ToDateTime(SelectedPUR_T002_A.po_date.ToString().Trim());
       //         //}
       //         //if (values == Barcodevalue)
       //         //{
       //         //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //         //    showMessageService.ButtonSetup = DialogButton.Ok;
       //         //    showMessageService.Caption = "Message";
       //         //    showMessageService.Text = String.Format("PO Date and PO Expiration Date Are Same", this.Title);
       //         //    showMessageService.ShowMessage();
       //         //}

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
       // private void AddSelecdtedFollower(object doc_data)
       // {
       //     List<string> str = doc_data.ToString().Split('/').ToList<string>();
       //     try
       //     {
       //         if (Convert.ToInt32(str[0]) != 0)
       //         {
       //             if ((Selected_NewFollowerMessage.user_id != null || Selected_NewFollowerMessage.party_id != null) && (Selected_NewFollowerMessage.doc_id != null || Selected_NewFollowerMessage.doc_id != 0))
       //             {
       //                 Selected_NewFollowerMessage.doc_id = Convert.ToInt32(str[0]);
       //                 Selected_NewFollowerMessage.doc_type = str[1];
       //                 Selected_NewFollowerMessage.doc_name = str[2];
       //                 Selected_NewFollowerMessage.msg_category = "Email";
       //                 Selected_NewFollowerMessage.author_id = AppSessionState.UserID;
       //                 Selected_NewFollowerMessage.add_by = AppSessionState.UserID.ToString();
       //                 Selected_NewFollowerMessage.subject = "Invitation to Follow " + Selected_NewFollowerMessage.doc_name;

       //                 Selected_NewFollowerMessage.user_id = AddExistingFollower(Selected_NewFollowerMessage);
       //                 Multiple_Complex_COM_T002 MCtemp = new Multiple_Complex_COM_T002();

       //                 Selected_Temp.Add(Selected_NewFollowerMessage);
       //                 MCtemp.followersMessagesList = Selected_Temp;

       //                 MCtemp = repository_COM.SaveWithReturnDomainObject<Multiple_Complex_COM_T002>(MCtemp, "LoggingControl", "Communication");
       //                 if (MCtemp.documentFollowersList != null && MCtemp.documentMessagesList != null)
       //                 {
       //                     foreach (var item in MCtemp.documentFollowersList)
       //                     {
       //                         docFollowersData.Add(item);
       //                     }
       //                     foreach (var item in MCtemp.documentMessagesList)
       //                     {
       //                         docMessageData.Add(item);
       //                     }
       //                     IEnumerable<COM_T002_A_PopUp> toUse = docMessageData
       //                     .Select(color => color)
       //                     .OrderByDescending(cc => cc.id)
       //                     .ToList();
       //                     docMessageData = new ObservableCollection<COM_T002_A_PopUp>(toUse.ToList());
       //                     //---------------------------Send Mail
       //                     getMailstring(Selected_NewFollowerMessage);

       //                     follower_cnt = docFollowersData.Count().ToString() + " Follower";
       //                 }
       //                 selected_partyList = selected_partyList;
       //                 selected_partyList = new Dictionary<string, object>();
       //                 selected_userList = new Dictionary<string, object>();

       //                 Selected_NewFollowerMessage = new COM_T002_A();
       //                 MCtemp.followersMessagesList = new List<COM_T002_A>();
       //                 Selected_Temp = new List<COM_T002_A>();
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
       // private void getMailstring(COM_T002_A obj)
       // {
       //     try
       //     {
       //         int i = 0;
       //         string str_mail = "";
       //         if (obj.user_id != "" && obj.user_id != null)
       //         {
       //             foreach (var temp in obj.user_id.Split(','))
       //             {
       //                 var mail = FollowerUserListToadd.Where(x => x.id.ToString() == temp).FirstOrDefault();
       //                 if (mail != null)
       //                 {
       //                     if ((str_mail == "") && (mail.email_id != null && mail.email_id != ""))
       //                     { str_mail = mail.email_id; }
       //                     else
       //                     {
       //                         if ((mail.email_id != null && mail.email_id != "") || mail != null)
       //                         { str_mail = str_mail + "," + mail.email_id; }
       //                     }
       //                     i++;
       //                 }
       //             }
       //             if (obj.party_id != "" && obj.party_id != null)
       //             {
       //                 foreach (var temp in obj.party_id.Split(','))
       //                 {
       //                     var mail = FollowerPartyListToadd.Where(x => x.id.ToString() == temp).FirstOrDefault();
       //                     if (mail != null)
       //                     {
       //                         if ((str_mail == "") && (mail.email_id != null && mail.email_id != ""))
       //                         { str_mail = mail.email_id; }
       //                         else
       //                         {
       //                             if (mail.email_id != null && mail.email_id != "")
       //                             { str_mail = str_mail + "," + mail.email_id; }
       //                         }
       //                     }
       //                 }
       //             }
       //         }
       //         else
       //         {
       //             if (obj.party_id != "" && obj.party_id != null)
       //             {
       //                 foreach (var temp in obj.party_id.Split(','))
       //                 {
       //                     var mail = FollowerPartyListToadd.Where(x => x.id.ToString() == temp).FirstOrDefault();
       //                     if (mail != null)
       //                     {
       //                         if (((str_mail) == "" && (mail.email_id != null && mail.email_id != "")) || mail != null)
       //                         { str_mail = mail.email_id; }
       //                         else
       //                         {
       //                             if ((mail.email_id != null && mail.email_id != "") || mail != null)
       //                             { str_mail = str_mail + "," + mail.email_id; }
       //                         }
       //                     }
       //                 }
       //             }
       //         }

       //         //string str_mail = getMailstring();
       //         //str_mail = "";
       //         //Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, "gcharushilaship_termsgmail.com", str_mail, str_mail, "Good Morning", "Hello", ""); 
       //         Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, AppSessionState.MailAccount.MailID, str_mail, "", obj.subject, obj.msg_body, "");
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
       // //-------------------------------
       // private void DeleteSelectedFollower(object data)
       // {
       //     List<string> str = data.ToString().Split('/').ToList<string>();
       //     if (Convert.ToInt32(str[2]) != AppSessionState.UserID)
       //     {
       //         ObjectSerializationService objSerialization = new ObjectSerializationService();
       //         COM_T002_B_Delete cOM_T002 = new COM_T002_B_Delete();

       //         cOM_T002.doc_id = Convert.ToInt32(str[0]);
       //         cOM_T002.doc_type = str[1];
       //         cOM_T002.follower_id = Convert.ToInt32(str[2]);
       //         cOM_T002.follower_type = str[3];
       //         cOM_T002.add_by = AppSessionState.UserID;
       //         string XmlData_CRM_T002 = new ObjectSerializationService().ObjectToXML(cOM_T002);
       //         string response = repository_B.Delete(XmlData_CRM_T002, "LoggingControl", "Communication");

       //         if (response == "1")
       //         {
       //             var toRemove = docFollowersData.Where(x => x.follower_id == cOM_T002.follower_id && x.follower_type == cOM_T002.follower_type).ToList();
       //             foreach (var itm in toRemove)
       //                 docFollowersData.Remove(itm);
       //         }
       //     }
       // }
       // private void AddToDoList(int msgid)
       // {
       //     if (msgid != 0)
       //     {
       //         COM_T002_A_PopUp cOM_T002_A = new COM_T002_A_PopUp();
       //         var data = (from d in docMessageData where d.id == msgid select d).FirstOrDefault();
       //         var index = docMessageData.IndexOf(docMessageData.Where(X => X.id == msgid).FirstOrDefault());
       //         cOM_T002_A = (COM_T002_A_PopUp)data;
       //         cOM_T002_A.add_by = AppSessionState.UserID.ToString();
       //         if (cOM_T002_A.starred == null)
       //         {
       //             cOM_T002_A.starred = true;
       //             cOM_T002_A.msg_read = false;
       //         }
       //         else if (cOM_T002_A.starred == false)
       //         {
       //             cOM_T002_A.starred = true;
       //         }
       //         else if (cOM_T002_A.starred == true)
       //         {
       //             cOM_T002_A.starred = false;
       //         }
       //         //cOM_T002_A.starred = !(cOM_T002_A.starred);

       //         cOM_T002_A = repository_COM_T002_A_PopUp.UpdateWithReturnDomainObject<COM_T002_A_PopUp>(cOM_T002_A, "LoggingControl", "Communication");
       //         docMessageData[index].starred = cOM_T002_A.starred;
       //     }
       // }
       // private void AddBackToDo(int msgid)
       // {
       //     if (msgid != 0)
       //     {
       //         COM_T002_A_PopUp cOM_T002_A = new COM_T002_A_PopUp();

       //         var data = (from d in docMessageData where d.id == msgid select d).FirstOrDefault();
       //         var index = docMessageData.IndexOf(docMessageData.Where(X => X.id == msgid).FirstOrDefault());
       //         cOM_T002_A = (COM_T002_A_PopUp)data;
       //         cOM_T002_A.add_by = AppSessionState.UserID.ToString();
       //         //cOM_T002_A.msg_read = !(cOM_T002_A.msg_read);
       //         if (cOM_T002_A.msg_read == null)
       //         {
       //             cOM_T002_A.starred = false;
       //             cOM_T002_A.msg_read = false;
       //         }
       //         else if (cOM_T002_A.msg_read == false)
       //         {
       //             cOM_T002_A.msg_read = true;
       //         }
       //         else if (cOM_T002_A.msg_read == true)
       //         {
       //             cOM_T002_A.msg_read = false;
       //         }

       //         cOM_T002_A = repository_COM_T002_A_PopUp.UpdateWithReturnDomainObject<COM_T002_A_PopUp>(cOM_T002_A, "LoggingControl", "Communication");
       //         docMessageData[index].msg_read = cOM_T002_A.msg_read;
       //     }
       // }
       // //------------------------------
       // private void OnSave(int i, string XmlData_C0M_T002A, string XmlData_C0M_T002B, ObservableCollection<COM_T002_A_PopUp> docMsgList, ObservableCollection<COM_T002_B_PopUp> docFolloList)
       // {
       //     docMsgList = (ObservableCollection<COM_T002_A_PopUp>)new ObjectSerializationService().XMLToObject(XmlData_C0M_T002A, docMsgList);

       //     foreach (var item in docMsgList)
       //     {
       //         docMessageData.Add(item);
       //     }
       //     //--------Sorting in descending order
       //     IEnumerable<COM_T002_A_PopUp> toUse = docMessageData
       //         .Select(color => color)
       //         .OrderByDescending(cc => cc.id)
       //         .ToList();
       //     docMessageData = new ObservableCollection<COM_T002_A_PopUp>(toUse.ToList());

       //     if (i == 1)
       //     {
       //         docFolloList = (ObservableCollection<COM_T002_B_PopUp>)new ObjectSerializationService().XMLToObject(XmlData_C0M_T002B, docFolloList);
       //         foreach (var item in docFolloList)
       //         {
       //             docFollowersData.Add(item);
       //         }
       //     }
       //     follower_cnt = docFollowersData.Count() + " Follower";
       // }
       // #endregion

       // #region . User Defined Function .
       // private void LoadInitialData()
       // {
       //     try
       //     {

       //         ////---------------------------------
       //         //DelAddrCollection and bill adrr filter
       //         ////---------------------------------
       //         // ObjectSerializationService obj = new ObjectSerializationService();
       //         //string company = AppSessionState.CompanyID.ToString() + "@" + AppSessionState.Location.ToString() + "@" + SelectedPUR_T002_A.doc_cat; 
       //         SelectedPUR_T002_A.doc_cat = "RF";
       //         string company = AppSessionState.Company + "@" + AppSessionState.Location.ToString() + "@" + SelectedPUR_T002_A.doc_cat;
       //         MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MC, "PUR_T002_A_Data", "PurchaseOrder", "CRM", "LoadAll", 0, company);
       //         SelectedPUR_T002_A.del_address_id = "";
       //         SelectedPUR_T002_A.del_address_type = "da";
       //         SelectedPUR_T002_A.bill_address_id = "";
       //         SelectedPUR_T002_A.bill_address_type = "ba";
       //         SelectedPUR_T002_A.journal_id = 0;
       //         SelectedPUR_T002_A.journal_name = "j";
       //         SelectedPUR_T002_A.j_code = "J01";
       //         SelectedList = MC.PODetails;

       //         FluteList = MC.FluteList;

       //         DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
       //         DataGridCollection.Filter = new Predicate<object>(Filter);

       //         BuyerCollection = CollectionViewSource.GetDefaultView(MC.BuyerList.ToList());
       //         BuyerCollection.Filter = new Predicate<object>(FilterBuyer);

       //         PartyCollection = CollectionViewSource.GetDefaultView(MC.partyList);
       //         PartyCollection.Filter = new Predicate<object>(FilterParty);

       //         PayTermCollection = CollectionViewSource.GetDefaultView(MC.PayTerms.ToList());
       //         PayTermCollection.Filter = new Predicate<object>(FilterPayTerms);

       //         warehouseCollection = CollectionViewSource.GetDefaultView(MC.WarehouseList);
       //         warehouseCollection.Filter = new Predicate<object>(FilterCollectionWarehouse);


       //         UomCollection = CollectionViewSource.GetDefaultView(MC.unitList.ToList());
       //         UomCollection.Filter = new Predicate<object>(FilterUom);

       //         validatedByCollection = CollectionViewSource.GetDefaultView(MC.BuyerList.ToList());
       //         validatedByCollection.Filter = new Predicate<object>(Filtervalidator);

       //         //19jan
       //         doc_typeCollection = CollectionViewSource.GetDefaultView(MC.doc_typeList);
       //         doc_typeCollection.Filter = new Predicate<object>(doctype_Filter);

       //         currencyCollection = CollectionViewSource.GetDefaultView(MC.currencyList);
       //         currencyCollection.Filter = new Predicate<object>(currency_Filter);

       //         reference_docCollection = CollectionViewSource.GetDefaultView(MC.reference_docList);
       //         reference_docCollection.Filter = new Predicate<object>(refdocno_Filter);

       //         po_orgCollection = CollectionViewSource.GetDefaultView(MC.purchase_orgList);
       //         po_orgCollection.Filter = new Predicate<object>(Purorg_Filter);

       //         sales_groupCollection = CollectionViewSource.GetDefaultView(MC.Purchase_groupList);
       //         sales_groupCollection.Filter = new Predicate<object>(sales_grp_Filter);

       //         storage_locCollection = CollectionViewSource.GetDefaultView(MC.storage_locList.ToList());
       //         storage_locCollection.Filter = new Predicate<object>(storage_loc_Filter);

       //         cost_centerCollection = CollectionViewSource.GetDefaultView(MC.cost_centerList);
       //         cost_centerCollection.Filter = new Predicate<object>(cost_center_Filter);

       //         journalCollection = CollectionViewSource.GetDefaultView(MC.journalList);
       //         journalCollection.Filter = new Predicate<object>(journal_Filter);

       //         DelAddrCollection = CollectionViewSource.GetDefaultView(MC.deladdrList.ToList());
       //         DelAddrCollection.Filter = new Predicate<object>(Filterdeladdr);

       //         BilAdderCollection = CollectionViewSource.GetDefaultView(MC.billaddrList.ToList());
       //         BilAdderCollection.Filter = new Predicate<object>(Filterbilladdr);

       //         wtunitCollection = CollectionViewSource.GetDefaultView(MC.unitList.ToList());
       //         wtunitCollection.Filter = new Predicate<object>(Filterwtunit);

       //         volumeunitCollection = CollectionViewSource.GetDefaultView(MC.unitList.ToList());
       //         volumeunitCollection.Filter = new Predicate<object>(Filtervolumeunit);

       //         itemcategoryCollection = CollectionViewSource.GetDefaultView(MC.itemcatList);
       //         itemcategoryCollection.Filter = new Predicate<object>(Filteritemcategory);

       //         ItemCollection = CollectionViewSource.GetDefaultView(MC.itemList);
       //         ItemCollection.Filter = new Predicate<object>(FilterItem);


       //         try
       //         {
       //             if (MC.PayTerms.Count == 1)
       //             {
       //                 SelectedPUR_T002_A.p_term = MC.PayTerms[0].p_term;
       //                 SelectedPUR_T002_A.pay_term_id = MC.PayTerms[0].id;
       //             }
       //             if (MC.WarehouseList.Count == 1)
       //             {
       //                 SelectedPUR_T002_A.warehouse_name = MC.WarehouseList[0].wa_name;
       //                 SelectedPUR_T002_A.warehouse_id = MC.WarehouseList[0].wa_code;
       //             }
       //         }
       //         catch
       //         {

       //         }


       //         //------------------LOGGING CONTROL  
       //         LoadAllFollowers();
       //         //------------------LOGGING CONTROL     
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
       //         SelectedPUR_T002_A.validator = Selectedpartylist[0].id;
       //         SelectedPUR_T002_A.validator_name = Selectedpartylist[0].EmpLName;
       //     }
       // }
       // private void DetailsOfSelectedPO(IList DataList)
       // {
       //     IList list = DataList as IList;


       //     List<PUR_T002_A> tSelectedPOList = list.Cast<PUR_T002_A>().ToList();
       //     if (tSelectedPOList.Count > 0)
       //     {
       //         SelectedPUR_T002_A = (PUR_T002_A)tSelectedPOList[0];
       //         string supplierid = "";

       //         supplierid = Convert.ToString(SelectedPUR_T002_A.PartyId) + "@" + AppSessionState.Company.ToString() + "@" + AppSessionState.Location.ToString() + "@" + SelectedPUR_T002_A.po_no;
       //         MC_temp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MC_temp, "PUR_T002_A_Data", "PurchaseOrder", "CRM", "LoadPODetails", 0, supplierid);
       //         RateFromSupplierCatalogueCollection = MC_temp.SupplierCatalogueRange;
       //         MC.POItemsDetails = MC_temp.POItemsDetails;
       //         MC.ParamvalList = MC_temp.ParamvalList;
       //         MC.POtaxDetails = MC_temp.POtaxDetails;
       //         FluteList = MC.FluteList;
       //         //dgPOdeliveryschedule = MC_temp.Deliveryschedule;// new chk
       //         ParameterCodeCollection = MC_temp.ParameterCodeList;
       //         try
       //         {
       //             var RequisitionItem = (from o in MC_temp.itemList
       //                                    where o.req_no != null//0//requsition_id
       //                                    select o).ToList();

       //             SelectedPUR_T002_A.ButtonAIsChecked = true;
       //             foreach (var item in dgPOItems)
       //             {
       //                 dgPOItems.Where(i => i.item_id == item.item_id).Where(i => i.stockingunit == item.stockingunit).ToList().ForEach(L => L.stocking_unit1 = item.stockingunit);
       //             }

       //         }
       //         catch
       //         {

       //         }
       //         try
       //         {

       //             dgPOItemsForParameterval = CollectionViewSource.GetDefaultView(MC_temp.POtaxDetails);
       //             for (int i = 0; i < dgPOItemsForParameterval.Cast<PUR_T002_C>().ToList().Count(); i++)
       //             {

       //             }
       //             dgPOItems = new ObservableCollection<PUR_T002_B>();
       //             dgPOItems = MC.POItemsDetails;
       //             foreach (var item in dgPOItems)
       //             {
       //                 dgPOItems.Where(i => i.item_id == item.item_id).Where(i => i.stockingunit == item.stockingunit).ToList().ForEach(L => L.stocking_unit1 = item.stockingunit);
       //             }
       //         }
       //         catch
       //         {

       //         }
       //         //------------------LOGGING CONTROL       
       //         LoadSelectedDocData();
       //         //------------------LOGGING CONTROL     

       //         blNew = false;

       //         Update();


       //     }

       // }
       // private void GetPayTerms(IList BuyerList)
       // {
       //     IList list = BuyerList as IList;
       //     List<ACC_M007_PopUp> Selectedbuyerlist = list.Cast<ACC_M007_PopUp>().ToList();
       //     if (Selectedbuyerlist.Count > 0)
       //     {
       //         SelectedPUR_T002_A.pay_term_id = Selectedbuyerlist[0].id;
       //         SelectedPUR_T002_A.p_term = Selectedbuyerlist[0].p_term;
       //     }
       // }
       // private void GetSelectedParty(IList partyList)
       // {
       //     try
       //     {
       //         IList list = partyList as IList;
       //         List<ADM_M028_PopUp> SelectedPartyDetailsTemp = list.Cast<ADM_M028_PopUp>().ToList();
       //         if (SelectedPartyDetailsTemp.Count > 0)
       //         {

       //             if (SelectedPUR_T002_A.id > 0)
       //             {
       //                 IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //                 showMessageService.ButtonSetup = DialogButton.Ok;
       //                 showMessageService.Caption = "Party Selection";
       //                 showMessageService.Text =
       //                     String.Format("Can not change party'{0}'", this.Title);
       //                 showMessageService.ShowMessage();
       //             }
       //             else if (SelectedPUR_T002_A.id == 0)
       //             {


       //                 //dgPOItems = new ObservableCollection<PUR_T002_B>();
       //                 //dgPOTotalTaxValues = new ObservableCollection<PUR_T002_C>();
       //                 //SelectedSEL_T001 = new SEL_T001();
       //                 //SelectedPUR_T002_A.amount_total = 0;
       //                 //SelectedPUR_T002_A.amount_tax = 0;
       //                 //SelectedPUR_T002_A.amount_untaxed = 0;

       //                 //SelectedPUR_T002_A.amt_in_words = "";

       //                 SelectedPUR_T002_A.supplier_id = Convert.ToInt32(SelectedPartyDetailsTemp[0].id);
       //                 //SelectedPUR_T002_A.supplier = SelectedPartyDetailsTemp[0].PartyNm;
       //                 SelectedPUR_T002_A.PartyId = SelectedPartyDetailsTemp[0].PartyId;
       //                 SelectedPUR_T002_A.party_name = SelectedPartyDetailsTemp[0].PartyNm;
       //                 SelectedPUR_T002_A.EmailID = SelectedPartyDetailsTemp[0].EmailId;

       //                 foreach (var listItem in MC.itemList.ToList())
       //                     listItem.Select = false;

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
       // //private void AssignParty(IList partyList)
       // //{
       // //    IList list = partyList as IList;
       // //    List<ADM_M028_PopUp> Selectedpartylist = list.Cast<ADM_M028_PopUp>().ToList();
       // //    if (Selectedpartylist.Count > 0)
       // //    {
       // //        SelectedPUR_T002_A.supplier_id = Selectedpartylist[0].id;
       // //        SelectedPUR_T002_A.supplier = Selectedpartylist[0].PartyNm;
       // //        string company = AppSessionState.CompanyID.ToString();
       // //        MC_temp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MC_temp, "PUR_T002_A_Data", "PurchaseOrder", "CRM", "LoadPartyDetails", Selectedpartylist[0].id, company);

       // //        try
       // //        {
       // //            //----------------------------------------------------------------
       // //            //sorted items of requisition
       // //            var RequisitionItem = (from o in MC_temp.itemList
       // //                                   where o.requsition_id == 0
       // //                                   select o).ToList();

       // //            //to take distinct itmes from list
       // //            var result = (List<CRM_T001B_PopUp_PUR>)RequisitionItem.GroupBy(test => test.ItemCode)
       // //           .Select(grp => grp.First())
       // //           .ToList();

       // //            SuppCatalogItemList = (List<CRM_T001B_PopUp_PUR>)result;
       // //            //ItemCollection = CollectionViewSource.GetDefaultView(SuppCatalogItemList);//26/09/2015
       // //            //ItemCollection.Filter = new Predicate<object>(FilterItem);

       // //            //sorted items of supplier catalog
       // //            RequisitionItem = (from o in MC_temp.itemList
       // //                               where o.requsition_id != 0
       // //                               select o).ToList();

       // //            RequisitionItemList = (List<CRM_T001B_PopUp_PUR>)RequisitionItem;
       // //            //----------------------------------------------------------------




       // //            if (MC_temp.currencyListPartyWise.ToList() != null && MC_temp.currencyListPartyWise.ToList().Count == 1)
       // //            {
       // //                SelectedPUR_T002_A.doc_currency = MC_temp.currencyListPartyWise[0].id;
       // //                SelectedPUR_T002_A.currency_name = MC_temp.currencyListPartyWise[0].curr_name;
       // //            }
       // //            else
       // //            {
       // //                SelectedPUR_T002_A.doc_currency = null;
       // //                SelectedPUR_T002_A.currency_name = "";
       // //            }
       // //            SelectedPUR_T002_A.ButtonAIsChecked = true;
       // //        }
       // //        catch
       // //        { }

       // //        if (MC.purchase_orgList.Count() > 0)
       // //        {
       // //            SelectedPUR_T002_A.sales_org = MC.purchase_orgList[0].po_code;
       // //            SelectedPUR_T002_A.pur_org_name = MC.purchase_orgList[0].pur_org;
       // //        }
       // //        if (MC.PayTerms.Count() > 0)
       // //        {
       // //            SelectedPUR_T002_A.pay_term_id = MC.PayTerms[0].id;
       // //            SelectedPUR_T002_A.p_term = MC.PayTerms[0].p_term;
       // //        }

       // //        reference_docCollection = CollectionViewSource.GetDefaultView(MC.reference_docList);
       // //        reference_docCollection.Filter = new Predicate<object>(refdocno_Filter);

       // //        RateFromSupplierCatalogueCollection = MC_temp.SupplierCatalogueRange;
       // //        ParameterCodeCollection = MC_temp.ParameterCodeList;
       // //        //DelAddrCollection = CollectionViewSource.GetDefaultView(MC_temp.AddressList.ToList());
       // //        //DelAddrCollection.Filter = new Predicate<object>(Filterdeladdr);
       // //        //BilAdderCollection = CollectionViewSource.GetDefaultView(MC_temp.AddressList.ToList());
       // //        //BilAdderCollection.Filter = new Predicate<object>(Filterdeladdr);

       // //        if (MC_temp.AddressList.Count == 1)
       // //        {
       // //            //SelectedPUR_T002_A.bill_address_type = MC_temp.AddressList[0].AddType;
       // //            //SelectedPUR_T002_A.bill_address_id = MC_temp.AddressList[0].id;
       // //            //SelectedPUR_T002_A.del_address_id = MC_temp.AddressList[0].id;
       // //            //SelectedPUR_T002_A.del_address_type = MC_temp.AddressList[0].AddType;
       // //        }
       // //    }
       // //}
       // private void AddWarehouse(IList BuyerList)
       // {
       //     IList list = BuyerList as IList;
       //     List<MM_M002_PopUp> Selectedbuyerlist = list.Cast<MM_M002_PopUp>().ToList();
       //     if (Selectedbuyerlist.Count > 0)
       //     {
       //         SelectedPUR_T002_A.warehouse_id = Selectedbuyerlist[0].wa_code;
       //         SelectedPUR_T002_A.warehouse_name = Selectedbuyerlist[0].wa_name;
       //     }
       // }
       // private void GetSelectedBuyer(IList BuyerList)
       // {
       //     IList list = BuyerList as IList;
       //     List<ADM_M024_PopUp> Selectedbuyerlist = list.Cast<ADM_M024_PopUp>().ToList();
       //     if (Selectedbuyerlist.Count > 0)
       //     {
       //         SelectedPUR_T002_A.buyer_id = Selectedbuyerlist[0].id;
       //         SelectedPUR_T002_A.EmpId = Selectedbuyerlist[0].EmpId;
       //         SelectedPUR_T002_A.EmpName = Selectedbuyerlist[0].EmpLName;
       //     }
       // }
       // private void AddSelectedItemToCollection(IList ItmList)
       // {
       //     try
       //     {
       //         int itemId = 0;
       //         if (dgSelectedIndex != -1 && ItmList.Count > 0)
       //         {
       //             IList list = ItmList as IList;
       //             List<CRM_T001B_PopUp_PUR> SelectedCatItmDetails = list.Cast<CRM_T001B_PopUp_PUR>().ToList();
       //             if (SelectedCatItmDetails.Count > 0 || SelectedPUR_T002_A.supplier_id != null)
       //             {
       //                 itemId = SelectedCatItmDetails[0].id;
       //                 var q = dgPOItems.Where(X => X.item_id == SelectedCatItmDetails[0].id && X.stocking_unit1 == SelectedCatItmDetails[0].stockingunit).FirstOrDefault();
       //                 var q2 = dgPOItems.Where(X => X.item_id == SelectedCatItmDetails[0].id && X.stocking_unit1 == SelectedCatItmDetails[0].stockingunit);
       //                 var q1 = dgPOItems.Where(X => X.req_no == SelectedCatItmDetails[0].req_no).FirstOrDefault();
       //                 int x = dgPOItems.IndexOf(dgPOItems.Where(X => X.item_id == SelectedCatItmDetails[0].id && X.stocking_unit1 == SelectedCatItmDetails[0].stockingunit).FirstOrDefault());


       //                 var DuplicateItems = (from o in dgPOItems
       //                                       where o.item_id == SelectedCatItmDetails[0].id
       //                                       select o).ToList();


       //                 if (SelectedCatItmDetails[0].Select == true && dgPOItems.Count == dgSelectedIndex && q == null)
       //                 {
       //                     //string[] values1 = SelectedCatItmDetails[0].ItemName.Split('\t');

       //                     dgPOItems.Add(new PUR_T002_B()
       //                     {
       //                         Stockble = SelectedCatItmDetails[0].Stockble,
       //                         tax_id = SelectedCatItmDetails[0].tax_id,
       //                         stockingunit = SelectedCatItmDetails[0].stockingunit,
       //                         stocking_unit1 = SelectedCatItmDetails[0].stockingunit,
       //                         status = "Draft",
       //                         SubCategCod = (SelectedCatItmDetails[0].SubCategCod),
       //                         active = true,
       //                         unit_price = Convert.ToDecimal(SelectedCatItmDetails[0].rate),
       //                         qty = Convert.ToDecimal(SelectedCatItmDetails[0].appr_qty),
       //                         ReqisitionNo = SelectedCatItmDetails[0].req_no,
       //                         req_no = SelectedCatItmDetails[0].req_no,
       //                         item_id = SelectedCatItmDetails[0].id,
       //                         item_name = SelectedCatItmDetails[0].ItemName,
       //                         uom_id = Convert.ToInt32(SelectedCatItmDetails[0].unit_id),
       //                         unit_code = SelectedCatItmDetails[0].unit_code,
       //                         //unit_code = SelectedCatItmDetails[0].unit_name, 
       //                         ItemCode = SelectedCatItmDetails[0].ItemCode,
       //                         temp_itemCode_withSKU = SelectedCatItmDetails[0].ItemCode
       //                     });
       //                     // item_code = SelectedCatItmDetails[0].ItemCode,
       //                     try
       //                     {
       //                         //if (Selectedpartylist[0].stockingunit != "")
       //                         {
       //                             string[] values1 = SelectedCatItmDetails[0].ItemName.Split('\t');
       //                             string Reqstockingunit = "";
       //                             string[] values = SelectedCatItmDetails[0].stockingunit.Split('/');
       //                             for (int y = values.Count() - 1; y >= 0; y--)
       //                             {
       //                                 var stockingunit = (from o in FluteList
       //                                                     where o.code == Convert.ToInt32(values[y].ToString())
       //                                                     select o).ToList();
       //                                 {
       //                                     Reqstockingunit = Reqstockingunit + "\t" + ":" + stockingunit[0].Type + ":" + stockingunit[0].code;
       //                                 }
       //                             }
       //                             dgPOItems.Where(l => l.item_id == SelectedCatItmDetails[0].id).ToList().Where(l => l.stockingunit == SelectedCatItmDetails[0].stockingunit).ToList().ForEach(i => i.description = (""));
       //                             dgPOItems.Where(l => l.item_id == SelectedCatItmDetails[0].id).Where(l => l.stockingunit == SelectedCatItmDetails[0].stockingunit).ToList().ForEach(i => i.description = (values1[0] + Reqstockingunit));
       //                             foreach (var item in dgPOItems)
       //                             {
       //                                 dgPOItems.Where(i => i.item_id == item.item_id).Where(i => i.stockingunit == item.stockingunit).ToList().ForEach(L => L.stocking_unit1 = item.stockingunit);
       //                             }
       //                         }
       //                     }
       //                     catch
       //                     {

       //                     }
       //                     //try
       //                     //{

       //                     //    SelectedPUR_T002_A.reference = SelectedCatItmDetails[0].req_ref;                               
       //                     //    if (SelectedCatItmDetails[0].appr_qty != 0 && SelectedCatItmDetails[0].rate != 0)
       //                     //    {                                   
       //                     //        dgPOItems.Where(l => l.item_id == SelectedCatItmDetails[0].id).ToList().Where(i => i.stockingunit == SelectedCatItmDetails[0].stockingunit).ToList().ForEach(i => i.sub_total = Convert.ToDecimal(SelectedCatItmDetails[0].appr_qty * SelectedCatItmDetails[0].rate));
       //                     //        SelectedPUR_T002_A.amount_untaxed = dgPOItems.Sum(t => t.sub_total);
       //                     //        SelectedPUR_T002_A.amount_total = SelectedPUR_T002_A.amount_untaxed + SelectedPUR_T002_A.amount_tax;
       //                     //        double amount = Convert.ToDouble(SelectedPUR_T002_A.amount_total);
       //                     //        NumberToEnglish num = new NumberToEnglish();
       //                     //        SelectedPUR_T002_A.amt_in_words = num.AmountInWords(Convert.ToDecimal(amount));

       //                     //    }
       //                     //}
       //                     //catch
       //                     //{

       //                     //}


       //                 }
       //                 else if (SelectedCatItmDetails[0].Select == false && q != null && dgPOItems[x].id == 0)
       //                 {
       //                     if (x >= 0)
       //                     {
       //                         dgPOItems.RemoveAt(x);

       //                     }
       //                 }
       //                 else if (SelectedCatItmDetails[0].Select == true && (q == null)) // && r != null && r >= 0)
       //                 {
       //                     dgPOItems[dgSelectedIndex].item_id = SelectedCatItmDetails[0].id;
       //                     //dgPOItems[dgSelectedIndex].item_code = SelectedCatItmDetails[0].temp_itemCode_withSKU;
       //                     dgPOItems[dgSelectedIndex].temp_itemCode_withSKU = SelectedCatItmDetails[0].ItemCode;
       //                     dgPOItems[dgSelectedIndex].item_name = SelectedCatItmDetails[0].ItemName;
       //                     dgPOItems[dgSelectedIndex].uom_id = Convert.ToInt32(SelectedCatItmDetails[0].unit_id);
       //                     dgPOItems[dgSelectedIndex].unit_code = SelectedCatItmDetails[0].unit_name;
       //                     dgPOItems[dgSelectedIndex].req_no = SelectedCatItmDetails[0].req_no;
       //                     dgPOItems[dgSelectedIndex].ReqisitionNo = SelectedCatItmDetails[0].req_no;
       //                     dgPOItems[dgSelectedIndex].ItemCode = SelectedCatItmDetails[0].ItemCode;

       //                 }
       //                 else if (SelectedCatItmDetails[0].Select == true && q == null) // && r != null && r >= 0)
       //                 {
       //                     dgPOItems[dgSelectedIndex].item_id = SelectedCatItmDetails[0].id;
       //                     // dgPOItems[dgSelectedIndex].item_code = SelectedCatItmDetails[0].ItemCode;
       //                     dgPOItems[dgSelectedIndex].temp_itemCode_withSKU = SelectedCatItmDetails[0].ItemCode;
       //                     dgPOItems[dgSelectedIndex].item_name = SelectedCatItmDetails[0].ItemName;
       //                     dgPOItems[dgSelectedIndex].uom_id = Convert.ToInt32(SelectedCatItmDetails[0].unit_id);
       //                     dgPOItems[dgSelectedIndex].unit_code = SelectedCatItmDetails[0].unit_name;
       //                     dgPOItems[dgSelectedIndex].req_no = SelectedCatItmDetails[0].req_no;
       //                     dgPOItems[dgSelectedIndex].ReqisitionNo = SelectedCatItmDetails[0].req_no;
       //                     dgPOItems[dgSelectedIndex].ItemCode = SelectedCatItmDetails[0].ItemCode;

       //                 }
       //                 try
       //                 {
       //                     // TaxTableCalculation();//26/09/2015    

       //                 }
       //                 catch
       //                 {

       //                 }
       //             }
       //             if (dgPOItems.Count() > 0 && SelectedPUR_T002_A.ButtonAIsChecked == true)
       //             {
       //                 SuppCatalogItemList.Where(t => t.id == itemId).ToList().ForEach(t => t.Select = false);
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
       // private void AddSelectedUnitToCollection(IList unitList)
       // {
       //     IList list = unitList as IList;
       //     List<ADM_M038_B_PopUp> Selectedunitlist = list.Cast<ADM_M038_B_PopUp>().ToList();
       //     if (Selectedunitlist.Count > 0)
       //     {
       //         if (dgPOItems.Count > 0 && dgSelectedIndex != -1 && dgPOItems.Count > dgSelectedIndex)
       //         {
       //             dgPOItems[dgSelectedIndex].uom_id = Selectedunitlist[0].id;
       //             dgPOItems[dgSelectedIndex].unit_code = Selectedunitlist[0].unit_name;
       //         }
       //     }
       // }
       // private void SelectBillAddress(IList billaddr)
       // {
       //     IList list = billaddr as IList;
       //     List<ADM_M002_PopUp> GetSelecteddelbilladdrTemp = list.Cast<ADM_M002_PopUp>().ToList();
       //     if (GetSelecteddelbilladdrTemp.Count > 0)
       //     {
       //         SelectedPUR_T002_A.bill_address_id = GetSelecteddelbilladdrTemp[0].Comp_Id;
       //         SelectedPUR_T002_A.bill_address_type = GetSelecteddelbilladdrTemp[0].CompName;
       //     }
       // }
       // private void SelectedDelAddress(IList deladdr)
       // {
       //     IList list = deladdr as IList;
       //     List<ADM_M003_Location_PopUp> GetSelecteddeladdrTemp = list.Cast<ADM_M003_Location_PopUp>().ToList();
       //     if (GetSelecteddeladdrTemp.Count > 0)
       //     {
       //         SelectedPUR_T002_A.del_address_id = GetSelecteddeladdrTemp[0].Location_Id;
       //         SelectedPUR_T002_A.del_address_type = GetSelecteddeladdrTemp[0].LoctnNm;
       //     }
       // }
       // private void CellChangeUpdate(IList DataList)
       // {

       //     try
       //     {
       //         if (dgPOItems.Count > 0)
       //         {
       //             //var distinctItems = (from o in dgPOItems where o.ItemCode == dgPOItems[dgSelectedIndex].ItemCode select o).ToList();
       //             //if (distinctItems.Count > 1)
       //             //{
       //             //}
       //             //else 
       //             //{
       //             //    dgPOItems.Add(dgPOItems[dgSelectedIndex]);
       //             //}
       //         }
       //         //if (dgSelectedIndex != -1 && dgPOItems.Count > dgSelectedIndex)
       //         //{

       //         //    if (dgPOItems[dgSelectedIndex].ItemCode == null)
       //         //    {
       //         //        if (MC.itemList.Count > 0)
       //         //        {

       //         //            int x = MC.itemList.IndexOf(MC.itemList.Where(X => X.ItemCode == dgPOItems[dgSelectedIndex].ItemCode).FirstOrDefault());
       //         //            dgPOItems[dgSelectedIndex].ItemCode = (MC.itemList[x].ItemCode);
       //         //        }
       //         //    }
       //         //}
       //         //*********************************************************************
       //         //else { I = new ObservableCollection<CRM_T001B_PopUp_PUR>(); }

       //         //IList list = DataList as IList;
       //         //List<PUR_T002_B> SelectedItemsDetailsTemp = list.Cast<PUR_T002_B>().ToList();

       //         //dgPOItems[dgSelectedIndex].ItemCode = SelectedItemsDetailsTemp[0].ItemCode;
       //         //try
       //         //{
       //         //    IList list = DataList as IList;
       //         //    if (list == null) return;
       //         //    SelectedItemsDetailsTemp = list.Cast<PUR_T002_B>().ToList();
       //         //}
       //         //catch (Exception e) { }

       //         //if (SelectedItemsDetailsTemp.Count > 0)
       //         //{
       //         //    PUR_T002_B SelectedPUR_T002_B = (PUR_T002_B)SelectedItemsDetailsTemp[0];
       //         //    {
       //         //        if (dgPOItems[dgSelectedIndex].discount == null)
       //         //        {
       //         //            dgPOItems[dgSelectedIndex].discount = 0;
       //         //        }
       //         //        if (dgPOItems[dgSelectedIndex].unit_price == null)
       //         //        {
       //         //            dgPOItems[dgSelectedIndex].unit_price = 0;
       //         //        }
       //         //        if (dgPOItems[dgSelectedIndex].qty == null)
       //         //        {
       //         //            dgPOItems[dgSelectedIndex].qty = 0;
       //         //        }
       //         //        dgPOItems[dgSelectedIndex].sub_total = ((dgPOItems[dgSelectedIndex].qty * dgPOItems[dgSelectedIndex].unit_price) - (dgPOItems[dgSelectedIndex].qty * dgPOItems[dgSelectedIndex].unit_price) * dgPOItems[dgSelectedIndex].discount / 100);
       //         //        SelectedPUR_T002_A.amount_untaxed = dgPOItems.Sum(t => t.sub_total);
       //         //        SelectedPUR_T002_A.amount_total = SelectedPUR_T002_A.amount_untaxed + SelectedPUR_T002_A.amount_tax;
       //         //        try
       //         //        {
       //         //            string tempTax = SelectedItemsDetailsTemp[dgSelectedIndex].tax_id;
       //         //            SelectedItems = GetDict(tempTax);
       //         //        }
       //         //        catch
       //         //        {

       //         //        }
       //         //        TaxRowCalculation();

       //         //    }

       //         //}
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
       // private void ButtonAChecked(IList partyList)
       // {
       //     try
       //     {
       //         //var RequisitionItem = (from o in MC_temp.itemList
       //         //                       where o.requsition_id != 0
       //         //                       select o).ToList();

       //         //MC.itemList = (List<CRM_T001B_PopUp_PUR>)RequisitionItem;

       //         //ItemCollection = CollectionViewSource.GetDefaultView(RequisitionItemList);//26/09/2015
       //         //ItemCollection.Filter = new Predicate<object>(FilterItem);
       //         //try
       //         //{

       //         //    for (int i = 0; i <= dgPOItems.Count() - 1; i++)
       //         //    {
       //         //        MC_temp.itemList.Where(t => t.id == dgPOItems[i].item_id && t.stockingunit == dgPOItems[i]._stocking_unit1 && t.requsition_id != 0 && t.requsition_id == dgPOItems[i].requsition_id).ToList().ForEach(t => t.Select = true);
       //         //    }
       //         //   // MC_temp.itemList.Where(t => t.id == dgPOItems[dgSelectedIndex - 1].item_id && t.Stockble == true).ToList().ForEach(t => t.Select = false);

       //         //}
       //         //catch
       //         //{

       //         //}

       //     }
       //     catch
       //     {

       //     }
       // }
       // private void ButtonBChecked(IList partyList)
       // {
       //     try
       //     {
       //         //        var RequisitionItem = (from o in MC_temp.itemList
       //         //                               where o.requsition_id == 0
       //         //                               select o).ToList();


       //         //ItemCollection = CollectionViewSource.GetDefaultView(SuppCatalogItemList);//26/09/2015
       //         //    ItemCollection.Filter = new Predicate<object>(FilterItem);
       //         //    try
       //         //    {
       //         //        for (int i = 0; i <= dgPOItems.Count() - 1; i++)
       //         //        {
       //         //            MC_temp.itemList.Where(t => t.id == dgPOItems[i].item_id && t.Stockble == true && t.requsition_id == 0).ToList().ForEach(t => t.Select = false );
       //         //            MC_temp.itemList.Where(t => t.id == dgPOItems[i].item_id && t.Stockble == false && t.requsition_id == 0).ToList().ForEach(t => t.Select = true );
       //         //        }
       //         //        //MC_temp.itemList.Where(t => t.id == dgPOItems[dgSelectedIndex - 1].item_id && t.stockingunit == dgPOItems[dgSelectedIndex - 1]._stocking_unit1).ToList().ForEach(t => t.Select = false);
       //         //    }
       //         //    catch
       //         //    {

       //         //    }
       //     }
       //     catch
       //     {

       //     }
       // }


       // #endregion

       // #region · Command Actions ·
       // protected override void OnSaveAction(InquiryActionResult<PUR_T002_A> result)
       // {
       //     try
       //     {
       //         if (dgPOItems.Count > 0)
       //         {
       //             this.SelectedPUR_T002_A.EndEdit();

       //             SelectedPUR_T002_A.UserId = AppSessionState.UserCode;
       //             SelectedPUR_T002_A.comp_code = (AppSessionState.Company);
       //             SelectedPUR_T002_A.location_id = (AppSessionState.Location);

       //             SelectedPUR_T002_A.add_by = AppSessionState.UserID;
       //             SelectedPUR_T002_A.plant_id = (AppSessionState.Location);
       //             SelectedPUR_T002_A.company_id = (AppSessionState.CompanyID);
       //             SelectedPUR_T002_A.transacion_type = "Purchase Inquiry";

       //             ObjectSerializationService obj = new ObjectSerializationService();
       //             ADM_M030_P productData1 = new ADM_M030_P();
       //             ADM_M030_P productData = new ADM_M030_P();
       //             StockingUnitCalculation();
       //             try
       //             {
       //                 SelectedPUR_T002_A.scheduleNo = dgPOdeliveryschedule[0].sch_no;
       //             }
       //             catch
       //             {

       //             }
       //             try
       //             {
       //                 for (int i = 0; i < dgPOItems.Count; i++)
       //                 {
       //                     string replace = "";
       //                     if (dgPOItems[i].item_name.Contains("NA"))
       //                     {
       //                         string[] splititem = new string[50];
       //                         splititem = dgPOItems[i].item_name.Split('\t');


       //                         for (int y = 0; y < splititem.Count(); y++)
       //                         {

       //                             if ((!splititem[y].Contains("NA")))
       //                             {
       //                                 if (replace == "")
       //                                 {
       //                                     replace = splititem[y];
       //                                 }
       //                                 else
       //                                 {
       //                                     replace = replace + "\t" + splititem[y];
       //                                 }
       //                             }

       //                         }
       //                         dgPOItems[i].item_name = "";
       //                         dgPOItems[i].item_name = replace;
       //                     }

       //                 }
       //             }
       //             catch
       //             {

       //             }
       //             for (int i = 0; i < dgPOItems.Count(); i++)
       //             {
       //                 if (dgPOItems[i].line_id == null)
       //                 { dgPOItems[i].line_id = 0; }
       //                 if (dgPOItems[i].unit_name == null)
       //                 { dgPOItems[i].unit_name = "kg"; }



       //             }


       //             foreach (var listItem in dgPOdeliveryschedule.ToList())
       //                 if (listItem.rec_qty == null)
       //                     listItem.rec_qty = 0;

       //             SelectedPUR_T002_A.XmlDataDocument_PUR_T002_B = obj.ObjectToXML(dgPOItems);


       //             SelectedPUR_T002_A.XmlDataDocument_PUR_T002_F = obj.ObjectToXML(dgPOdeliveryschedule);
       //             //SelectedPUR_T002_A.XmlDataDocument_PUR_T002_G = obj.ObjectToXML(dgscheduledmaster);
       //             if (ValidateControls() == true)
       //             {
       //                 int i = 0;
       //                 if (blNew == true)
       //                 {
       //                     SelectedPUR_T002_A = repository.SaveWithReturnDomainObject<PUR_T002_A>(SelectedPUR_T002_A, "PurchaseOrder", "CRM");
       //                     SelectedList.Add(SelectedPUR_T002_A);
       //                     blNew = false;
       //                 }
       //                 else if (blNew == false)
       //                 {
       //                     SelectedPUR_T002_A = repository.UpdateWithReturnDomainObject<PUR_T002_A>(SelectedPUR_T002_A, "PurchaseOrder", "CRM");
       //                 }

       //                 if (SelectedPUR_T002_A.XmlDataDocument_PUR_T002_B != null)
       //                 {


       //                     MC.ParamvalList = MC.ParamvalList;

       //                     MC.POItemsDetails = (ObservableCollection<PUR_T002_B>)new ObjectSerializationService().XMLToObject(SelectedPUR_T002_A.XmlDataDocument_PUR_T002_B, MC.POItemsDetails);

       //                     dgPOItems = new ObservableCollection<PUR_T002_B>();
       //                     dgPOItems = MC.POItemsDetails;
       //                     foreach (var item in dgPOItems)
       //                     {
       //                         dgPOItems.Where(o => o.item_id == item.item_id).Where(o => o.stockingunit == item.stockingunit).ToList().ForEach(o => o.stocking_unit1 = item.stockingunit);
       //                     }

       //                     Update();
       //                 }
       //                 else
       //                 {
       //                     MC.POItemsDetails = new ObservableCollection<PUR_T002_B>();
       //                 }
       //                 //--------------------------LOGGING 
       //                 SelectedPUR_T002_A.doc_cat = "RF";
       //                 SelectedPUR_T002_A.doc_type = "RF";
       //                 OnSave(i, SelectedPUR_T002_A.XmlData_C0M_T002A, SelectedPUR_T002_A.XmlData_C0M_T002B, MC.documentMessagesList, MC.documentFollowersList);
       //                 //--------------------------LOGGING 
       //                 _dataGridCollection.Refresh();
       //             }
       //             else
       //             {
       //             }
       //         }
       //         else
       //         {
       //             IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //             showMessageService.ButtonSetup = DialogButton.Ok;
       //             showMessageService.Caption = "Message";
       //             showMessageService.Text = String.Format("Please Select Items", this.Title);
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
       // protected override void OnCreateAction(InquiryActionResult<PUR_T002_A> result)
       // {
       //     blNew = true;



       //     MC.POItemsDetails = new ObservableCollection<PUR_T002_B>();
       //     ParamitemList = new ObservableCollection<ADM_M030_P>();
       //     ParamclearList = new ObservableCollection<ADM_M030_P>();
       //     ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);
       //     dgPOItems.Clear();
       //     ParamitemList1 = new ObservableCollection<ADM_M030_P>();
       //     _dataGridCollection.Refresh();
       //     foreach (var listItem in MC.itemList.ToList())
       //         listItem.Select = false;
       //     SelectedPUR_T002_A.ValidateAsync().Wait();
       //     try
       //     {
       //         SelectedPUR_T002_A = new PUR_T002_A();
       //     }
       //     catch
       //     {

       //     }
       //     SelectedPUR_T002_A.po_date = DateTime.Now;

       //     //--------------------------LOGGING 
       //     ClearAll();
       //     //--------------------------LOGGING 
       //     SelectedPUR_T002_A.po_date = DateTime.Now;
       //     SelectedPUR_T002_A.doc_cat = "RF";
       //     SelectedPUR_T002_A.doc_type = "RF";
       //     SelectedPUR_T002_A.quotation_date = DateTime.Now;
       //     SelectedPUR_T002_A.quotation_validity = DateTime.Now;
       //     SelectedPUR_T002_A.valid_from_date = DateTime.Now;
       //     SelectedPUR_T002_A.valid_to_date = DateTime.Now;
       //     SelectedPUR_T002_A.doc_desc = "a";

       //     SelectedPUR_T002_A.del_address_id = "";
       //     SelectedPUR_T002_A.del_address_type = "da";
       //     SelectedPUR_T002_A.bill_address_id = "";
       //     SelectedPUR_T002_A.bill_address_type = "ba";
       //     SelectedPUR_T002_A.journal_id = 0;
       //     SelectedPUR_T002_A.journal_name = "j";
       //     SelectedPUR_T002_A.j_code = "J01";
       // }

       // protected override void OnRemoveAction(InquiryActionResult<PUR_T002_A> result)
       // {
       //     IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //     showMessageService.ButtonSetup = DialogButton.Ok;
       //     showMessageService.Caption = "Delete Changes";
       //     showMessageService.Text =
       //         String.Format(
       //             "This record will be Deleted forever '{0}'",
       //                 this.Title);

       //     if (showMessageService.ShowMessage() == DialogResult.Ok)
       //     {
       //         this.SelectedPUR_T002_A.EndEdit();
       //         string response = repository.Delete(SelectedPUR_T002_A.po_no, "PurchaseOrder", "CRM");
       //         SelectedList.Remove(SelectedPUR_T002_A);
       //         SelectedPUR_T002_A = new PUR_T002_A();
       //         dgPOItems = new ObservableCollection<PUR_T002_B>();
       //         //--------------------------LOGGING 
       //         ClearAll();
       //         //--------------------------LOGGING 
       //         _dataGridCollection.Refresh();
       //     }
       // }
       // protected override void OnDiscardAction(InquiryActionResult<PUR_T002_A> result)
       // {
       //     SelectedPUR_T002_A.CancelEdit();
       // }
       // protected override void OnFevoriteAction(InquiryActionResult<PUR_T002_A> result)
       // {
       //     SelectedList = SelectedList;
       // }
       // protected override void OnFlipAction(InquiryActionResult<PUR_T002_A> result)
       // {
       //     SelectedList = SelectedList;
       //     SelectedPUR_T002_A = SelectedPUR_T002_A;

       // }
       // protected override void OnHelpAction(InquiryActionResult<PUR_T002_A> result)
       // {
       //     SelectedList = SelectedList;
       //     SelectedPUR_T002_A = SelectedPUR_T002_A;
       // }
       // protected override void OnPrintAction(InquiryActionResult<PUR_T002_A> result)
       // {
       //     MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MC, "PUR_T002_A_Data", "PurchaseOrder", "CRM", "PurchaseOrder", SelectedPUR_T002_A.id, "");
       //     dgReportMaster = MC.PurchaseOrder_SingleReport;
       //     object[] objDS = new object[2];
       //     objDS[0] = MC.PurchaseOrder_SingleReport;
       //     objDS[1] = MC.PurchaseOrder_SingleReportTax;
       //     try
       //     {
       //         MC.ParamvalList = MC_temp.ParamvalList;
       //         FluteList = MC.FluteList;
       //     }
       //     catch
       //     {

       //     }
       //     ReportManager ReportManager = new ReportingServices.ReportManager();
       //     ReportManager.DisplayReport(objDS, "dsPurchaseOrder", "\\Procurment\\PurchaseOrder.rdlc");
       // }

       // private void Export()
       // {

       //     string str_mail = SelectedPUR_T002_A.EmailID;
       //     AppSessionState.MailAccount.MailID = str_mail;

       //     ReportManager ReportManager = new ReportingServices.ReportManager();
       //     MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MC, "PUR_T002_A_Data", "PurchaseOrder", "CRM", "PurchaseOrder", SelectedPUR_T002_A.id, "");
       //     object[] objDS = new object[2];
       //     objDS[0] = MC.PurchaseOrder_SingleReport;
       //     objDS[1] = MC.PurchaseOrder_SingleReportTax;
       //     string pdffile = "PurchaseOrder";
       //     string dataset1 = "dsPurchaseOrder";
       //     string dataset2 = "dsPurchaseOrder1";
       //     string subject = "Purchase Order";
       //     string Message = "<h1>Purchase Order!</h1><p>Dear Sir!</p><p>This is the Purchase Order. </p><p>-M/s. Shweta Printpack Pvt. Ltd. </p>";
       //     //AppSessionState.MailAccount.MailID = MailID[0].EmailId;
       //     {

       //         ReportManager.Mail(str_mail, objDS, "dsPurchaseOrder", "\\Procurment\\PurchaseOrder.rdlc", dataset1, dataset2, pdffile, subject, Message);
       //         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //         showMessageService.ButtonSetup = DialogButton.Ok;
       //         showMessageService.Caption = "Message";
       //         showMessageService.Text = String.Format("Mail Send Successfully", this.Title);
       //         showMessageService.ShowMessage();
       //     }

       //     //ReportDataSource rds = new ReportDataSource("dslogisticdata", MC.PeriodicReportGodownToPartyMaster);          
       //     //Warning[] warnings;
       //     //string[] streamIds;
       //     //string mimeType = string.Empty;
       //     //string encoding = string.Empty;
       //     //string extension = string.Empty;

       //     //// Setup the report viewer object and get the array of bytes
       //     //ReportViewer viewer = new ReportViewer();
       //     //viewer.ProcessingMode = ProcessingMode.Local;
       //     //viewer.LocalReport.ReportPath = "\\Admin\\StockTransferFromGodownToParty.rdlc";
       //     //viewer.LocalReport.DataSources.Add(rds); // Add datasource here

       //     //string filename = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "StockTransferFromGodownToParty.PDF");

       //     //byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

       //     //using (FileStream fs = File.Create(filename))
       //     //{
       //     //    fs.Write(bytes, 0, bytes.Length);
       //     //    fs.Close();
       //     //}
       //     //string str_mail = "";
       //     // var MailID = (from o in  MC.partyDetails
       //     //                                         where o.id == SelectedParameter.supplier_id
       //     //                                         select o).ToList();

       //     // //AppSessionState.MailAccount.MailID = MailID[0].EmailId;    

       //     //Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, AppSessionState.MailAccount.MailID, str_mail, str_mail, "Wearhouse Stock Statement", "<h1>Stock Update!</h1><p>Dear Sir!</p><p>This is the updated statement of stock available for you at our Wearhouse. </p><p>-M/s. Shweta Printpack Pvt. Ltd. </p>", filename); 


       // }




       // //protected override void OnExportAction(InquiryActionResult<PUR_T002_A> result)
       // //{
       // //    try
       // //    {
       // //        List<PUR_T002_A> Export_List = new List<PUR_T002_A>();
       // //        foreach (var o in DataGridCollection)
       // //        {
       // //            PUR_T002_A Data = o as PUR_T002_A;
       // //            Export_List.Add(Data);
       // //        }

       // //        //--------------------------------------

       // //        ExportToExcel<PUR_T002_A, List<PUR_T002_A>> export = new ExportToExcel<PUR_T002_A, List<PUR_T002_A>>();
       // //        ICollectionView view = CollectionViewSource.GetDefaultView(Export_List);
       // //        export.dataToPrint = (List<PUR_T002_A>)view.SourceCollection;

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
       // private bool ValidateControls()
       // {
       //     try
       //     {
       //         int i = 0;               
       //         string[] values = new string[50];               
       //         try
       //         {
       //             if (i == 0)
       //             {
       //                 for (int y = 0; y < dgPOItems.Count; y++)
       //                 {
       //                     if (dgPOItems[y].qty <= 0)
       //                     {
       //                         i = 1;
       //                         IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
       //                         showMessageService.ButtonSetup = DialogButton.Ok;
       //                         showMessageService.Caption = "Message";
       //                         showMessageService.Text = String.Format("Can not save item with zero quantity for Inquiry", this.Title);
       //                         showMessageService.ShowMessage();
       //                         break;
       //                     }                           
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
       //             //for (int y = 0; y < dgPOItems.Count; y++)
       //             //{
       //             try
       //             {
       //                 description1 = dgPOItems[dgSelectedIndex].description.ToString();
       //                 values = description1.Split('\t');
       //             }
       //             catch
       //             {

       //             }

       //             try
       //             {
       //                 int item_id = Convert.ToInt32(dgPOItems[dgSelectedIndex].item_id);
       //                 int subcatcode = Convert.ToInt32(dgPOItems[dgSelectedIndex].SubCategCod);
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

       // #endregion

       // #region Methods

       // public event PropertyChangedEventHandler PropertyChanged;
       // private void RaisePropertyChanged(string propertyname)
       // {
       //     if (PropertyChanged != null)
       //     {
       //         PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
       //     }
       // }

       // private void StockingUnitCalculation()
       // {
       //     string description = "";
       //     int count = 0;

       //     for (int y = 0; y < dgPOItems.Count; y++)
       //     {
       //         try
       //         {
       //             description = dgPOItems[y].description.ToString();
       //             if (dgPOItems[y].temp_itemCode_withSKU.Contains(":"))
       //             {
       //                 string[] splititem = new string[50];
       //                 splititem = dgPOItems[y].temp_itemCode_withSKU.Split(':');
       //                 dgPOItems[y].temp_itemCode_withSKU = splititem[0];

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
       //                             dgPOItems[y].temp_itemCode_withSKU = dgPOItems[y].temp_itemCode_withSKU + ":" + itemcode2;

       //                         }
       //                         else
       //                         {
       //                             dgPOItems[y].temp_itemCode_withSKU = dgPOItems[y].temp_itemCode_withSKU + "/" + itemcode2;

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

       // #region "Filetr String"
       // //po filter
       // public string FilterString_AllPOData
       // {
       //     get { return _filterString_AllPOData; }
       //     set
       //     {
       //         _filterString_AllPOData = value;
       //         RaisePropertyChanged("FilterString_AllPOData");
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
       //     var data = obj as PUR_T002_A;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_AllPOData))
       //         {
       //             return (data.po_no != null && data.po_no.ToString().ToLower().Contains(_filterString_AllPOData.ToLower())) ||
       //                 (data.po_date != null && data.po_date.ToString().ToLower().Contains(_filterString_AllPOData.ToLower())) ||
       //                 (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterString_AllPOData.ToLower())) ||
       //                 (data.status_po != null && data.status_po.ToString().ToLower().Contains(_filterString_AllPOData.ToLower())) ||
       //                 (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_AllPOData.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //party filter
       // public string FilterString_party
       // {
       //     get { return _filterString_party; }
       //     set
       //     {
       //         _filterString_party = value;
       //         RaisePropertyChanged("FilterString_party");
       //         FilterCollectionParty();
       //     }
       // }
       // private void FilterCollectionParty()
       // {
       //     if (_partyCollection != null)
       //     {
       //         _partyCollection.Refresh();
       //     }
       // }
       // public bool FilterParty(object obj)
       // {
       //     var data = obj as ADM_M028_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_party))
       //         {
       //             return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_party.ToLower()) ||
       //                 data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_party.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //buyer filter
       // public string FilterString_buyer
       // {
       //     get { return _filterString_Buyer; }
       //     set
       //     {
       //         _filterString_Buyer = value;
       //         RaisePropertyChanged("FilterString_buyer");
       //         FilterCollectionbuyer();
       //     }
       // }
       // private void FilterCollectionbuyer()
       // {
       //     if (_buyerCollection != null)
       //     {
       //         _buyerCollection.Refresh();
       //     }
            
       // }
       // public bool FilterBuyer(object obj)
       // {
       //     var data = obj as ADM_M024_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_Buyer))
       //         {
       //             return (data.EmpLName != null && data.EmpLName.ToString().ToLower().Contains(_filterString_Buyer.ToLower()) ||
       //                 data.EmpMName != null && data.EmpMName.ToString().ToLower().Contains(_filterString_Buyer.ToLower()) ||
       //                 data.EmpFName != null && data.EmpFName.ToString().ToLower().Contains(_filterString_Buyer.ToLower()) ||
       //                  data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterString_Buyer.ToLower()) );
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //buyer filter
       // public string FilterStringSchrecby
       // {
       //     get { return _FilterStringSchrecby; }
       //     set
       //     {
       //         _FilterStringSchrecby = value;
       //         RaisePropertyChanged("FilterStringSchrecby");
       //         FilterCollectionvalidator();
       //     }
       // }
       // private void FilterCollectionvalidator()
       // {
       //     if (_validatedByCollection != null)
       //     {
       //         _validatedByCollection.Refresh();
       //     }
       // }
       // //validator

       // public bool Filtervalidator(object obj)
       // {
       //     var data = obj as ADM_M024_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_FilterStringSchrecby))
       //         {
       //             return (data.EmpLName != null && data.EmpLName.ToString().ToLower().Contains(_FilterStringSchrecby.ToLower())
       //                 ||
       //                 data.EmpMName != null && data.EmpMName.ToString().ToLower().Contains(_FilterStringSchrecby.ToLower()) ||
       //                 data.EmpFName != null && data.EmpFName.ToString().ToLower().Contains(_FilterStringSchrecby.ToLower())
       //                 );
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //item filter
       // public string FilterString_Item
       // {
       //     get { return _filterString_Item; }
       //     set
       //     {
       //         _filterString_Item = value;
       //         RaisePropertyChanged("FilterString_Item");
       //         FilterCollectionItem();
       //     }
       // }
       // private void FilterCollectionItem()
       // {
       //     if (_itemCollection != null)
       //     {
       //         _itemCollection.Refresh();
       //     }
       // }
       // public bool FilterItem(object obj)
       // {
       //     var data = obj as CRM_T001B_PopUp_PUR;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_Item))
       //         {
       //             return (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
       //                    (data.SubCategCod != null && data.SubCategCod.ToString().ToLower().Contains(_filterString_Item.ToLower())) ||
       //                     (data.req_no != null && data.req_no.ToString().ToLower().Contains(_filterString_Item.ToLower())) ||
       //                     data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_Item.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //warehouse
       // public string FilterString_Warehouse
       // {
       //     get { return _filterString_warehouse; }
       //     set
       //     {
       //         _filterString_warehouse = value;
       //         RaisePropertyChanged("FilterString_Warehouse");
       //         FilterCollectionWarehouse();
       //     }
       // }
       // private void FilterCollectionWarehouse()
       // {
       //     if (_warehouseCollection != null)
       //     {
       //         _warehouseCollection.Refresh();
       //     }
       // }
       // public bool FilterCollectionWarehouse(object obj)
       // {
       //     var data = obj as MM_M002_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_warehouse))
       //         {
       //             return (data.wa_code != null && data.wa_code.ToString().ToLower().Contains(_filterString_warehouse.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //payterm
       // public string FilterString_Payterms
       // {
       //     get { return _filterString_payterms; }
       //     set
       //     {
       //         _filterString_payterms = value;
       //         RaisePropertyChanged("FilterString_Payterms");
       //         FilterCollectionPayTerm();
       //     }
       // }
       // private void FilterCollectionPayTerm()
       // {
       //     if (_paytermCollection != null)
       //     {
       //         _paytermCollection.Refresh();
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

       // public string FilterString_scheduleItem
       // {
       //     get { return _filterString_scheduleItem; }
       //     set
       //     {
       //         _filterString_scheduleItem = value;
       //         RaisePropertyChanged("_FilterString_scheduleItem");
       //         FilterCollectionscheduleItem();
       //     }
       // }
       // private void FilterCollectionscheduleItem()
       // {
       //     if (_itemCollection != null)
       //     {
       //         _itemCollection.Refresh();
       //     }
       // }
       // public bool FilterscheduleItem(object obj)
       // {
       //     var data = obj as PurchaseOrder_deliveryschedule;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_scheduleItem))
       //         {
       //             return (data.item_name != null && data.item_name.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
       //                    (data.item_code != null && data.item_code.ToString().ToLower().Contains(_filterString_Item.ToLower())));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //del addr
       // public string FilterString_deladdr
       // {
       //     get { return _filterString_deladdr; }
       //     set
       //     {
       //         _filterString_deladdr = value;
       //         RaisePropertyChanged("FilterString_deladdr");
       //         FilterCollectiondeladdr();
       //     }
       // }
       // private void FilterCollectiondeladdr()
       // {
       //     if (_delAddrCollection != null)
       //     {
       //         _delAddrCollection.Refresh();
       //     }
       //     else if (_billAddrCollection != null)
       //     {
       //         _billAddrCollection.Refresh();
       //     }

       // }
       // public bool Filterdeladdr(object obj)
       // {
       //     var data = obj as ADM_M003_Location_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_deladdr))
       //         {
       //             return (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_deladdr.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //bill addr


       // public string FilterString_billaddr
       // {
       //     get { return _filterString_billaddr; }
       //     set
       //     {
       //         _filterString_billaddr = value;
       //         RaisePropertyChanged("FilterString_billaddr");
       //         FilterCollectionbilladdr();
       //     }
       // }
       // private void FilterCollectionbilladdr()
       // {
       //     if (_billAddrCollection != null)
       //     {
       //         _billAddrCollection.Refresh();
       //     }
       //     else if (_billAddrCollection != null)
       //     {
       //         _billAddrCollection.Refresh();
       //     }

       // }
       // public bool Filterbilladdr(object obj)
       // {
       //     var data = obj as ADM_M002_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_billaddr))
       //         {
       //             return (data.CompName != null && data.CompName.ToString().ToLower().Contains(_filterString_billaddr.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }

       // //unit filter _filterString_uom
       // public string FilterString_uom
       // {
       //     get { return _filterString_uom; }
       //     set
       //     {
       //         _filterString_uom = value;
       //         RaisePropertyChanged("FilterString_uom");
       //         FilterCollectionuom();
       //     }
       // }
       // private void FilterCollectionuom()
       // {
       //     if (_uomCollection != null)
       //     {
       //         _uomCollection.Refresh();
       //     }
       // }
       // public bool FilterUom(object obj)
       // {
       //     var data = obj as ADM_M038_B_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_uom))
       //         {
       //             return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterString_uom.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
        
       // //ParameterFilter
       // private string _ParameterFilter;
       // public string ParameterFilter
       // {
       //     get { return _ParameterFilter; }
       //     set
       //     {
       //         _ParameterFilter = value;
       //         RaisePropertyChanged("ParameterFilter");
       //         ParameterFilterCollection();
       //     }
       // }
       // private void ParameterFilterCollection()
       // {
       //     if (_ParameterCollection != null)
       //     {
       //         _ParameterCollection.Refresh();
       //     }
       // }
       // public bool FilterParam(object obj)
       // {
       //     var data = obj as ADM_M034_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_ParameterFilter))
       //         {
       //             return (data.SubCatCode.ToString() != null && data.SubCatCode.ToString().ToLower().Contains(_ParameterFilter.ToLower()));
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
       //         RaisePropertyChanged("FilterString_doctype");
       //         FilterCollection_doctype();
       //     }
       // }
       // public bool doctype_Filter(object obj)
       // {
       //     var data = obj as SYS_M007_Popup;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_doctype))
       //         {
       //             return (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterString_doctype.ToLower()) ||
       //                 data.doc_desc != null && data.doc_desc.ToString().ToLower().Contains(_filterString_doctype.ToLower()));

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
       //         RaisePropertyChanged("FilterString_currency");
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
       //             return (data.curr_code != null && data.curr_code.ToString().ToLower().Contains(_filterString_currency.ToLower()));

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
       //         RaisePropertyChanged("FilterString_refdocno");
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
       //             return (data.sono != null && data.sono.ToString().ToLower().Contains(_filterString_refdocno.ToLower()));

       //         }
       //         return true;
       //     }
       //     return false;
       // }

       // //Sale Organisation
       // //private void FilterCollection_saleorg()
       // //{
       // //    if (po_orgCollection != null)
       // //    {
       // //        po_orgCollection.Refresh();
       // //    }
       // //}
       // //private string _filterString_saleorg;
       // //public string FilterString_saleorg
       // //{
       // //    get { return _filterString_saleorg; }
       // //    set
       // //    {
       // //        _filterString_saleorg = value;
       // //        RaisePropertyChanged("FilterString_saleorg");
       // //        FilterCollection_refdocno();
       // //    }
       // //}
       // //public bool saleorg_Filter(object obj)
       // //{
       // //    var data = obj as ADM_M001_A_Popup;
       // //    if (data != null)
       // //    {
       // //        if (!string.IsNullOrEmpty(_filterString_saleorg))
       // //        {
       // //            return (data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString_saleorg.ToLower()));
       // //        }
       // //        return true;
       // //    }
       // //    return false;
       // //}
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
       //         RaisePropertyChanged("FilterString_saledivision");
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
       //             return (data.div_name != null && data.div_name.ToString().ToLower().Contains(_filterString_saledivision.ToLower()));
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
       //         RaisePropertyChanged("FilterString_distChannel");
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
       //             return (data.dc_name != null && data.dc_name.ToString().ToLower().Contains(_filterString_distChannel.ToLower()));
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
       //         RaisePropertyChanged("FilterString_sales_person");
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
       //             return (data.name != null && data.name.ToString().ToLower().Contains(_filterString_sales_person.ToLower()));
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
       //         RaisePropertyChanged("FilterString_sales_ofc");
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
       //             return (data.sales_off != null && data.sales_off.ToString().ToLower().Contains(_filterString_sales_ofc.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //Purchase Group
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
       //         RaisePropertyChanged("FilterString_sales_grp");
       //         FilterCollection_sales_grp();
       //     }
       // }
       // public bool sales_grp_Filter(object obj)
       // {
       //     var data = obj as ADM_M001_P_Popup;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_sales_grp))
       //         {
       //             return (data.pg_code != null && data.pg_code.ToString().ToLower().Contains(_filterString_sales_grp.ToLower())) ||
       //                 (data.pg_name != null && data.pg_name.ToString().ToLower().Contains(_filterString_sales_grp.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //Storage Location
       // private void FilterCollection_storage_loc()
       // {
       //     if (_storage_locCollection != null)
       //     {
       //         _storage_locCollection.Refresh();
       //     }
       // }
       // private string _filterString_storage_loc;
       // public string FilterString_storage_loc
       // {
       //     get { return _filterString_storage_loc; }
       //     set
       //     {
       //         _filterString_storage_loc = value;
       //         RaisePropertyChanged("FilterString_storage_loc");
       //         FilterCollection_storage_loc();
       //     }
       // }
       // public bool storage_loc_Filter(object obj)
       // {
       //     var data = obj as MM_M001_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_storage_loc))
       //         {
       //             return (data.store_code != null && data.store_code.ToString().ToLower().Contains(_filterString_storage_loc.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //Cost Center
       // private void FilterCollection_cost_center()
       // {
       //     if (cost_centerCollection != null)
       //     {
       //         cost_centerCollection.Refresh();
       //     }
       // }
       // private string _filterString_cost_center;
       // public string FilterString_cost_center
       // {
       //     get { return _filterString_cost_center; }
       //     set
       //     {
       //         _filterString_cost_center = value;
       //         RaisePropertyChanged("FilterString_cost_center");
       //         FilterCollection_cost_center();
       //     }
       // }
       // public bool cost_center_Filter(object obj)
       // {
       //     var data = obj as ACC_M019_Popup;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_cost_center))
       //         {
       //             return (data.cost_center != null && data.cost_center.ToString().ToLower().Contains(_filterString_cost_center.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }

       // //journal
       // private void FilterCollection_journal()
       // {
       //     if (journalCollection != null)
       //     {
       //         journalCollection.Refresh();
       //     }
       // }
       // private string _filterString_journal;
       // public string FilterString_journal
       // {
       //     get { return _filterString_journal; }
       //     set
       //     {
       //         _filterString_journal = value;
       //         RaisePropertyChanged("FilterString_journal");
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
       //             return (data.journal_name != null && data.journal_name.ToString().ToLower().Contains(_filterString_journal.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //wtunit
       // private string _filterString_wtunit;
       // public string FilterString_wtunit
       // {
       //     get { return _filterString_wtunit; }
       //     set
       //     {
       //         _filterString_wtunit = value;
       //         RaisePropertyChanged("FilterString_wtunit");
       //         FilterCollectionwtunit();
       //     }
       // }
       // private void FilterCollectionwtunit()
       // {
       //     if (_wtunitCollection != null)
       //     {
       //         _wtunitCollection.Refresh();
       //     }
       // }
       // public bool Filterwtunit(object obj)
       // {
       //     var data = obj as ADM_M038_B_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_wtunit))
       //         {
       //             return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_wtunit.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //volumeunit
       // private string _filterString_volumeunit;
       // public string FilterString_volumeunit
       // {
       //     get { return _filterString_volumeunit; }
       //     set
       //     {
       //         _filterString_volumeunit = value;
       //         RaisePropertyChanged("FilterString_volumeunit");
       //         FilterCollectionvolumeunit();
       //     }
       // }
       // private void FilterCollectionvolumeunit()
       // {
       //     if (_volumeunitCollection != null)
       //     {
       //         _volumeunitCollection.Refresh();
       //     }
       // }
       // public bool Filtervolumeunit(object obj)
       // {
       //     var data = obj as ADM_M038_B_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_volumeunit))
       //         {
       //             return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_volumeunit.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }
       // //itemcategory
       // private string _filterString_itemcategory;
       // public string FilterString_itemcategory
       // {
       //     get { return _filterString_itemcategory; }
       //     set
       //     {
       //         _filterString_itemcategory = value;
       //         RaisePropertyChanged("FilterString_itemcategory");
       //         FilterCollectionitemcategory();
       //     }
       // }
       // private void FilterCollectionitemcategory()
       // {
       //     if (_itemcategoryCollection != null)
       //     {
       //         _itemcategoryCollection.Refresh();
       //     }
       // }
       // public bool Filteritemcategory(object obj)
       // {
       //     var data = obj as SYS_M003_PopUp;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_itemcategory))
       //         {
       //             return (data.sditem_cat_code != null && data.sditem_cat_code.ToString().ToLower().Contains(_filterString_itemcategory.ToLower()) ||
       //                 data.item_cat_desc != null && data.item_cat_desc.ToString().ToLower().Contains(_filterString_itemcategory.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }

       // //Purchase Organisation
       // private void FilterCollection_Purorg()
       // {
       //     if (po_orgCollection != null)
       //     {
       //         po_orgCollection.Refresh();
       //     }
       // }
       // private string _filterString_Purorg;
       // public string FilterString_Purorg
       // {
       //     get { return _filterString_Purorg; }
       //     set
       //     {
       //         _filterString_Purorg = value;
       //         RaisePropertyChanged("FilterString_Purorg");
       //         FilterCollection_Purorg();
       //     }
       // }
       // public bool Purorg_Filter(object obj)
       // {
       //     var data = obj as ADM_M001_M_Popup;
       //     if (data != null)
       //     {
       //         if (!string.IsNullOrEmpty(_filterString_Purorg))
       //         {
       //             return (data.po_code != null && data.po_code.ToString().ToLower().Contains(_filterString_Purorg.ToLower())) ||
       //                 (data.pur_org != null && data.pur_org.ToString().ToLower().Contains(_filterString_Purorg.ToLower()));
       //         }
       //         return true;
       //     }
       //     return false;
       // }    
       // #endregion
       // #region "Parameter"
       // private void ParameterPopupClosed(IList param)
       // {

       //     string strData = "";
       //     string strData1 = "";
       //     ADM_M030_P productData = new ADM_M030_P();
       //     ADM_M030_P productData1 = new ADM_M030_P();
       //     IList list = param as IList;
       //     List<ADM_M030_P> Selectedpartylist = list.Cast<ADM_M030_P>().ToList();

       //     {
       //         if (dgPOItems[dgSelectedIndex].description != null)
       //         {
       //             if (Selectedpartylist.Count > 0 && dgPOItems[dgSelectedIndex].description.Contains('\t'))
       //             {
       //                 if (Selectedpartylist[0].Name != null || dgPOItems[dgSelectedIndex].item_id != null)
       //                 {
       //                     try
       //                     {
       //                         if (Selectedpartylist[0].item_id == dgPOItems[dgSelectedIndex].item_id)
       //                         {

       //                             if (param.Count > 0)
       //                             {
       //                                 try
       //                                 {

       //                                     if (Selectedpartylist[0].Type != "" || Selectedpartylist[0].Type != null)
       //                                     {
       //                                         int itemid = Convert.ToInt32(dgPOItems[dgSelectedIndex].item_id);
       //                                         try
       //                                         {
       //                                             for (int e = 0; e < ParamitemList.Count; e++)
       //                                             {
       //                                                 if (itemid == ParamitemList[e].item_id)
       //                                                 {
       //                                                     if (Selectedpartylist[0].Type == ParamitemList[e].Type)
       //                                                     {
       //                                                         ParamitemList.Where(l => l.Type == Selectedpartylist[0].Type).Where(l => l.item_id == itemid).Where(l => l.stockunit == dgPOItems[dgSelectedIndex].stocking_unit1)
       //                                                         .ToList().ForEach(i => i.Name = Selectedpartylist[0].Name);

       //                                                         ParamitemList.Where(l => l.Type == Selectedpartylist[0].Type).Where(l => l.item_id == itemid).Where(l => l.stockunit == dgPOItems[dgSelectedIndex].stocking_unit1)
       //                                                       .ToList().ForEach(i => i.code = 1);

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
       //                                         item1 = dgPOItems[dgSelectedIndex].item_name.ToString();
       //                                         description = dgPOItems[dgSelectedIndex].description.ToString();
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
       //                                         try
       //                                         {
       //                                             if (description.Contains(Selectedpartylist[0].Type))
       //                                             {
       //                                                 string test8 = description.Substring(0, description.IndexOf(Selectedpartylist[0].Type + ":"));
       //                                                 string y1 = description.Substring(0, description.IndexOf(Selectedpartylist[0].Type + ":"));
       //                                                 string z1 = description.Replace(y1, "");
       //                                                 split = z1.Split(':');
       //                                                 //string test2 = description.Replace(split[1], code + "\t");
       //                                                 string test2 = description.Replace(Selectedpartylist[0].Type + ":" + split[1], Selectedpartylist[0].Type + ":" + code + "\t");
       //                                                 try
       //                                                 {
       //                                                     {
       //                                                         strData1 = "";
       //                                                         string[] stockvalues = new string[50];
       //                                                         stockvalues = test2.Split('\t');
       //                                                         for (int r = 0; r < stockvalues.Count(); r++)
       //                                                         {
       //                                                             if (stockvalues[r] != "")
       //                                                             {
       //                                                                 if (r == 0)
       //                                                                 {
       //                                                                     strData1 = stockvalues[0];
       //                                                                 }
       //                                                                 else
       //                                                                 {
       //                                                                     strData1 = strData1 + "\t" + stockvalues[r];
       //                                                                 }
       //                                                             }
       //                                                         }

       //                                                     }
       //                                                 }
       //                                                 catch
       //                                                 {

       //                                                 }


       //                                             }
       //                                             dgPOItems[dgSelectedIndex].item_name = (strData);
       //                                             dgPOItems[dgSelectedIndex].description = (strData1);
       //                                         }
       //                                         catch
       //                                         {

       //                                         }
       //                                         //dgPOItems.Where(l => l.item_id == dgPOItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_name = (strData));
       //                                         //dgPOItems.Where(l => l.item_id == dgPOItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.description = (strData1));
       //                                     }
       //                                     else
       //                                     {
       //                                         dgPOItems[dgSelectedIndex].item_name = (dgPOItems[dgSelectedIndex].item_name + "\t" + ":" + strData);
       //                                         dgPOItems[dgSelectedIndex].description = (dgPOItems[dgSelectedIndex].description + "\t" + ":" + strData1);

       //                                         //dgPOItems.Where(l => l.item_id == dgPOItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_name = (i.item_name + "\t" + ":" + strData));
       //                                         //dgPOItems.Where(l => l.item_id == dgPOItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.description = (i.description + "\t" + ":" + strData1));
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
       //             //for (int y = 0; y < dgPOItems.Count; y++)
       //             {
       //                 try
       //                 {
       //                     description1 = dgPOItems[dgSelectedIndex].description.ToString();
       //                     values = description1.Split('\t');
       //                 }
       //                 catch
       //                 {

       //                 }

       //                 try
       //                 {
       //                     int item_id = Convert.ToInt32(dgPOItems[dgSelectedIndex].item_id);
       //                     int subcatcode = Convert.ToInt32(dgPOItems[dgSelectedIndex].SubCategCod);
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
       //                     //if ((values.Count() - 1) == ParameterType.Count)
       //                     //{
       //                     //    i = 0;

       //                     //}
       //                     //else
       //                     //{
       //                     //    i = 1;
       //                     //    break;
       //                     //}

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
       // private void StockingUnitCalculation123()
       // {
       //     string description = "";
       //     int count = 0;

       //     //for (int y = 0; y < dgcatalogItem.Count; y++)
       //     {
       //         try
       //         {
       //             description = dgPOItems[dgSelectedIndex].description.ToString();

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
       //                     int index = dgPOItems[dgSelectedIndex].ItemcodeStockUnit.IndexOf(':');
       //                     if (index != -1)
       //                     {
       //                         dgPOItems[dgSelectedIndex].ItemcodeStockUnit = dgPOItems[dgSelectedIndex].ItemcodeStockUnit.Substring(0, index - 1);
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
       //                                 dgPOItems[dgSelectedIndex].ItemcodeStockUnit = dgPOItems[dgSelectedIndex].ItemcodeStockUnit + ":" + 0;
       //                             }
       //                             else
       //                             {
       //                                 dgPOItems[dgSelectedIndex].ItemcodeStockUnit = dgPOItems[dgSelectedIndex].ItemcodeStockUnit + ":" + itemcode2;
       //                             }
       //                         }
       //                         else
       //                         {
       //                             if (itemcode2.Contains('-') || itemcode2.Contains('_') || itemcode2.Contains(':') || itemcode2.Contains(','))
       //                             {
       //                                 dgPOItems[dgSelectedIndex].ItemcodeStockUnit = dgPOItems[dgSelectedIndex].ItemcodeStockUnit + "/" + 0;
       //                             }
       //                             else
       //                             {
       //                                 dgPOItems[dgSelectedIndex].ItemcodeStockUnit = dgPOItems[dgSelectedIndex].ItemcodeStockUnit + "/" + itemcode2;
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
       //                 stockvalues = dgPOItems[dgSelectedIndex].ItemcodeStockUnit.Split(':');
       //                 string test = "";
       //                 dgPOItems[dgSelectedIndex].stocking_unit1 = stockvalues[1];
       //                 ParamitemList.Where(l => l.item_id == dgPOItems[dgSelectedIndex].item_id).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.stockunit = stockvalues[1]);

       //             }
       //             count = 0;
       //         }
       //         catch
       //         {

       //         }


       //     }
       // }
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

       //     foreach (var item in SelectedParmetersFrom)
       //     {

       //     }
       //     dgPOItems.Where(l => l.CatParamName == productData.Type).ToList().ForEach(i => i.item_name = (i.item_name + "\t" + strData));

       // }
       // private void CollectionChanged(IList DataList)
       // {
       //     IList list = DataList as IList;
       //     try
       //     {
       //         List<PUR_T002_B> Selectedpartylist = list.Cast<PUR_T002_B>().ToList();
       //         if (Selectedpartylist[0].Stockble == true)
       //         {
       //             ParamitemList1 = new ObservableCollection<ADM_M030_P>();
       //             TotalParameterCollection = CollectionViewSource.GetDefaultView(MC.ParamvalList);
       //             if (ParamValuesList.Count == 0)
       //             {
       //                 for (int i = 0; i < TotalParameterCollection.Cast<ADM_M030_P>().ToList().Count(); i++)
       //                 {
       //                     ParamValuesList.Add(TotalParameterCollection.Cast<ADM_M030_P>().ElementAt(i));
       //                 }
       //             }
       //             if (dgPOItems[dgSelectedIndex].id == 0 || dgPOItems[dgSelectedIndex].id == null)
       //             {
       //                 if (dgPOItems.Count > 0)
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
       //                                             ParamitemList.Add(new ADM_M030_P() { count = dgSelectedIndex, stockunit = dgPOItems[dgSelectedIndex].stocking_unit1, Name = ParameterType[r].Name, item_id = item_id, SubCatCode = ParameterType[r].SubCatCode, Type = ParameterType[r].Type });

       //                                         }

       //                                     }
       //                                     try
       //                                     {
       //                                         string Reqstockingunit = "";
       //                                         string Reqstockingunit1 = "";

       //                                         string[] values1 = dgPOItems[dgSelectedIndex].description.Split('\t');

       //                                         string[] values = Selectedpartylist[0].stockingunit.Split('/');
       //                                         try
       //                                         {

       //                                             for (int y = values.Count() - 1; y >= 0; y--)
       //                                             {
       //                                                 var stockingunit = (from o in FluteList
       //                                                                     where o.code == Convert.ToInt32(values[y].ToString())
       //                                                                     select o).ToList();
       //                                                 {
       //                                                     Reqstockingunit = Reqstockingunit + "\t" + ":" + stockingunit[0].Type + ":" + stockingunit[0].code;
       //                                                     Reqstockingunit1 = Reqstockingunit1 + "\t" + ":" + stockingunit[0].Type + ":" + stockingunit[0].Name;
       //                                                 }


       //                                             }
       //                                             dgPOItems.Where(l => l.item_id == dgPOItems[dgSelectedIndex].item_id).Where(l => l.stockingunit == dgPOItems[dgSelectedIndex].stockingunit).ToList().ForEach(i => i.description = (""));
       //                                             dgPOItems.Where(l => l.item_id == dgPOItems[dgSelectedIndex].item_id).Where(l => l.stockingunit == dgPOItems[dgSelectedIndex].stockingunit).ToList().ForEach(i => i.description = (values1[0] + Reqstockingunit));

       //                                             dgPOItems.Where(l => l.item_id == dgPOItems[dgSelectedIndex].item_id).Where(l => l.stockingunit == dgPOItems[dgSelectedIndex].stockingunit).ToList().ForEach(i => i.item_name = (""));
       //                                             dgPOItems.Where(l => l.item_id == dgPOItems[dgSelectedIndex].item_id).Where(l => l.stockingunit == dgPOItems[dgSelectedIndex].stockingunit).ToList().ForEach(i => i.item_name = (values1[0] + Reqstockingunit1));



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
       //                                                 if (dgPOItems[dgSelectedIndex].stocking_unit1 == "" || dgPOItems[dgSelectedIndex].stocking_unit1 == null)
       //                                                 {
       //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.Name = "");
       //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.stockunit = "");
       //                                                 }
       //                                                 else
       //                                                 {
       //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.Name = ParameterCollectionMethod[0].Name);
       //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.stockunit = dgPOItems[dgSelectedIndex].stocking_unit1);
       //                                                 }
       //                                             }
       //                                             else
       //                                             {
       //                                                 if (dgPOItems[dgSelectedIndex].stocking_unit1 == "" || dgPOItems[dgSelectedIndex].stocking_unit1 == null)
       //                                                 {
       //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.Name = "");
       //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.stockunit = "");
       //                                                 }
       //                                                 else
       //                                                 {
       //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.Name = Parameter[0].Name);
       //                                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.count == dgSelectedIndex).ToList().ForEach(i => i.stockunit = dgPOItems[dgSelectedIndex].stocking_unit1);
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

       //                                     if (dgPOItems[dgSelectedIndex].description == null || dgPOItems[dgSelectedIndex].description == "")
       //                                     {
       //                                         //17Jan
       //                                         //MC_temp.itemList = ItemCollection.Cast<CRM_T001B_PopUp_PUR>().ToList();
       //                                         //string tnm = (from data in MC_temp.itemList where data.id == dgPOItems[dgSelectedIndex].item_id select data.ItemName).ToList()[0].ToString();
       //                                         string tnm = (from data in ItemCollection.Cast<CRM_T001B_PopUp_PUR>().ToList() where data.id == dgPOItems[dgSelectedIndex].item_id select data.ItemName).ToList()[0].ToString();

       //                                         //dgPOItems.Where(l => l.item_id == dgPOItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_name = "");
       //                                         //dgPOItems.Where(l => l.item_id == dgPOItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.description = "");
       //                                         dgPOItems[dgSelectedIndex].item_name = "";
       //                                         dgPOItems[dgSelectedIndex].description = "";
       //                                         //-17Jan
       //                                         for (int y = 0; y < ParamitemList1.Count; y++)
       //                                         {
       //                                             if (y == 0)
       //                                             {
       //                                                 //dgPOItems.Where(l => l.item_id == dgPOItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.item_name = tnm +"\t" + ":" + ParamitemList1[y].Type + ":");
       //                                                 //dgPOItems.Where(l => l.item_id == dgPOItems[dgSelectedIndex].item_id).ToList().ForEach(i => i.description = tnm +"\t" + ":" + ParamitemList1[y].Type + ":");
       //                                                 dgPOItems[dgSelectedIndex].item_name = tnm + "\t" + ":" + ParamitemList1[y].Type + ":";
       //                                                 dgPOItems[dgSelectedIndex].description = tnm + "\t" + ":" + ParamitemList1[y].Type + ":";

       //                                             }
       //                                             else
       //                                             {
       //                                                 dgPOItems[dgSelectedIndex].item_name = dgPOItems[dgSelectedIndex].item_name + "\t" + ":" + ParamitemList1[y].Type + ":";
       //                                                 dgPOItems[dgSelectedIndex].description = dgPOItems[dgSelectedIndex].description + "\t" + ":" + ParamitemList1[y].Type + ":";
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
       //             else if (dgPOItems[dgSelectedIndex].id != 0 || dgPOItems[dgSelectedIndex].id != null)
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
       //                                         where o.item_id == item_id && o.stockunit == dgPOItems[dgSelectedIndex].stockingunit
       //                                         select o).ToList();
       //                         if (itemlist.Count == 0)
       //                         {
       //                             {
       //                                 for (int r = 0; r < ParameterType.Count; r++)
       //                                 {
       //                                     ParamitemList.Add(new ADM_M030_P() { stockunit = dgPOItems[dgSelectedIndex].stockingunit, Name = ParameterType[r].Name, item_id = item_id, SubCatCode = ParameterType[r].SubCatCode, Type = ParameterType[r].Type });
       //                                 }
       //                             }
       //                         }
       //                         try
       //                         {
       //                             string[] values = Selectedpartylist[0].stockingunit.Split('/');
       //                             int count = values.Length;
       //                             for (int r = 0; r < count; r++)
       //                             {
       //                                 var ParameterCollectionMethod = (from o in FluteList
       //                                                                  where o.code == Convert.ToInt32(values[r].ToString())
       //                                                                  select o).ToList();
       //                                 var Parameter = (from o in ParamitemList
       //                                                  where o.Type == (ParameterCollectionMethod[0].Type) && o.stockunit == dgPOItems[dgSelectedIndex].stockingunit
       //                                                  select o).ToList();
       //                                 if (Parameter[0].code == 0)
       //                                 {
       //                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.stockunit == dgPOItems[dgSelectedIndex].stockingunit).ToList().ForEach(i => i.Name = ParameterCollectionMethod[0].Name);
       //                                 }
       //                                 else
       //                                 {
       //                                     ParamitemList.Where(l => l.Type == ParameterCollectionMethod[0].Type).Where(l => l.stockunit == dgPOItems[dgSelectedIndex].stockingunit).ToList().ForEach(i => i.Name = Parameter[0].Name);
       //                                 }
       //                             }
       //                         }
       //                         catch
       //                         {

       //                         }
       //                         ParameterCollection = CollectionViewSource.GetDefaultView(ParamclearList);
       //                         for (int r = 0; r < ParamitemList.Count; r++)
       //                         {
       //                             if (ParamitemList[r].item_id == item_id && ParamitemList[r].stockunit == dgPOItems[dgSelectedIndex].stockingunit)
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
       //                                      where o.po_line_id == MC.POtaxDetails[u].po_line_id
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

       //                 dgPOItems.Where(l => l.item_id == MC.POtaxDetails[u].item_id).Where(l => l.stocking_unit1 == MC.POtaxDetails[u].stocking_unit1).ToList().ForEach(i => i.taxamount = (taxvalue));
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
       //     for (int y = 0; y < dgPOItems.Count; y++)
       //     {

       //         try
       //         {
       //             parametervale = "";
       //             parametercode = "";
       //             string stockingunit = dgPOItems[y].stockingunit;
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
                  
       //             dgPOItems.Where(l => l.item_id == dgPOItems[y].item_id).Where(l => l.stockingunit == dgPOItems[y].stockingunit).ToList().ForEach(i => i.description = (i.temp_itemCode_withSKU + "\t:" + parametercode));
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
       // }
       // #endregion          
    }
}
