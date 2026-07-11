using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using System.Collections.ObjectModel;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using Reflection.Presentation.Services;
using System.Collections.Specialized;
using Reflection.BusinessEntity;

namespace Reflection.Modules.Procurement.ViewModels
{
    public class PUR_T002_AVM_Internal : WorkspaceViewModel<PUR_T002_A>
    {
        #region Declaration
        bool NewRecord = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        NumberToEnglish num = new NumberToEnglish();
        WebServiceRepository<PUR_T002_A> repository = new WebServiceRepository<PUR_T002_A>();
        WebServiceRepository<MultipleContext_PUR_T002_A> repository_MC = new WebServiceRepository<MultipleContext_PUR_T002_A>();
        WebServiceRepository<PUR_T002_P_PR_ItemsList> repositoryItemList = new WebServiceRepository<PUR_T002_P_PR_ItemsList>();
        ObjectSerializationService obj = new ObjectSerializationService();
        MultipleContext_PUR_T002_A _MC = new MultipleContext_PUR_T002_A();
        public MultipleContext_PUR_T002_A MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value;

                    RaisePropertyChanged("MC");
                }
            }
        }

        MultipleContext_PUR_T002_A _MCTemp = new MultipleContext_PUR_T002_A();
        public MultipleContext_PUR_T002_A MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value;

                    RaisePropertyChanged("MC");
                }
            }
        }
        private PUR_T002_A _MasterEntity;
        public PUR_T002_A MasterEntity
        {
            get
            {
                return _MasterEntity;
            }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged(nameof(MasterEntity));
                    value.BeginEdit();
                }
            }
        }

        private PUR_T002_A _MasterEntityTemp;
        public PUR_T002_A MasterEntityTemp
        {
            get
            {
                return _MasterEntityTemp;
            }
            set
            {
                if (_MasterEntityTemp != value)
                {
                    _MasterEntityTemp = value;
                    RaisePropertyChanged("MasterEntityTemp");
                    value.BeginEdit();
                }
            }
        }

        public List<PUR_T002_P_PR_ItemsList> _ItemListForPopup;
        public List<PUR_T002_P_PR_ItemsList> ItemListForPopup
        {
            get
            {
                return _ItemListForPopup;
            }
            set
            {
                _ItemListForPopup = value;
                RaisePropertyChanged("ItemListForPopup");
            }
        }

        private ObservableCollection<PUR_T002_B> _dgItemsEntity;
        public ObservableCollection<PUR_T002_B> dgItemsEntity
        {
            get
            {
                return _dgItemsEntity;
            }
            set
            {
                if (_dgItemsEntity != value)
                {
                    _dgItemsEntity = value;
                    dgItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("dgItemsEntity");
                }
            }
        }

        private PUR_T004_A _ScheduleEntity;
        public PUR_T004_A ScheduleEntity
        {
            get
            {
                return _ScheduleEntity;
            }
            set
            {
                if (_ScheduleEntity != value)
                {
                    _ScheduleEntity = value;
                    RaisePropertyChanged("ScheduleEntity");
                }
            }
        }

        private ObservableCollection<PUR_T004_B> _dgItemScheduleEntity;
        public ObservableCollection<PUR_T004_B> dgItemScheduleEntity
        {
            get
            {
                return _dgItemScheduleEntity;
            }
            set
            {
                if (_dgItemScheduleEntity != value)
                {
                    _dgItemScheduleEntity = value;
                    // NotifyCollectionChangedEventHandler added to call CollectionChangedNotifyForSchedule function evry time. which will not work after one time use earlier.
                    _dgItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
                    RaisePropertyChanged("dgItemScheduleEntity");
                }
            }
        }

        //Pending assignment of dgTotalTaxSummury
        private ObservableCollection<PUR_T002_C> _dgTotalTaxSummury;
        public ObservableCollection<PUR_T002_C> dgTotalTaxSummury
        {
            get
            {
                return _dgTotalTaxSummury;
            }
            set
            {
                if (_dgTotalTaxSummury != value)
                {
                    _dgTotalTaxSummury = value;
                    RaisePropertyChanged("dgTotalTaxSummury");

                }
            }
        }

        private ObservableCollection<ACC_T006_B> _TotalDocumentTaxes;
        public ObservableCollection<ACC_T006_B> TotalDocumentTaxes
        {
            get
            {
                return _TotalDocumentTaxes;
            }
            set
            {
                _TotalDocumentTaxes = value;
                TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
                RaisePropertyChanged("TotalDocumentTaxes");
            }
        }

        private ObservableCollection<ACC_T006_B> _TotalDocumentTaxesSummury;
        public ObservableCollection<ACC_T006_B> TotalDocumentTaxesSummury
        {
            get
            {
                return _TotalDocumentTaxesSummury;
            }
            set
            {
                _TotalDocumentTaxesSummury = value;
                RaisePropertyChanged("TotalDocumentTaxesSummury");
            }
        }

        private ObservableCollection<ACC_T006_B> _TotalDocumentTaxesItem;
        public ObservableCollection<ACC_T006_B> TotalDocumentTaxesItem
        {
            get
            {
                return _TotalDocumentTaxesItem;
            }
            set
            {
                _TotalDocumentTaxesItem = value;
                RaisePropertyChanged("TotalDocumentTaxesItem");
            }
        }
        #endregion

        #region Temp Variables
        private ICollectionView _dataGridview;
        public ICollectionView DataGridView
        {
            get { return _dataGridview; }
            set { _dataGridview = value; RaisePropertyChanged("DataGridView"); }
        }

        // Selected Index for Items DataGrid
        private int _dgSelectedIndexItem;
        public int dgSelectedIndexItem
        {
            get
            {
                return _dgSelectedIndexItem;
            }
            set
            {
                if (_dgSelectedIndexItem != value)
                {
                    _dgSelectedIndexItem = value;
                    RaisePropertyChanged("dgSelectedIndexItem");
                    FilterScheduleDataGrid();
                    if (TotalDocumentTaxesItem.Count > 0)
                    {
                        TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>(TotalDocumentTaxes.Where(tax => tax.ItemCode == dgItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == dgItemsEntity[dgSelectedIndexItem].sku && tax.item_line_id == dgItemsEntity[dgSelectedIndexItem].id));
                    }
                }
            }
        }

        // Selected Index for Items DataGrid 
        private int _dgSelectedIndexItemSchedule;
        public int dgSelectedIndexItemSchedule
        {
            get
            {
                return _dgSelectedIndexItemSchedule;
            }
            set
            {
                if (_dgSelectedIndexItemSchedule != value)
                {
                    _dgSelectedIndexItemSchedule = value;
                    RaisePropertyChanged("dgSelectedIndexItemSchedule");
                }
            }
        }

        private int _dgSelectedIndex;
        public int dgSelectedIndex
        {
            get
            {
                return _dgSelectedIndex;
            }
            set
            {
                if (_dgSelectedIndex != value)
                {

                    _dgSelectedIndex = value;
                    RaisePropertyChanged("dgSelectedIndex");
                }
            }
        }

        private int _dgSelectedIndexTaxSummury;
        public int dgSelectedIndexTaxSummury
        {
            get
            {
                return _dgSelectedIndexTaxSummury;
            }
            set
            {
                if (_dgSelectedIndexTaxSummury != value)
                {

                    _dgSelectedIndexTaxSummury = value;
                    RaisePropertyChanged("dgSelectedIndexTaxSummury");
                }
            }
        }

        private int _dgSelectedIndexSchedule;
        public int dgSelectedIndexSchedule
        {
            get
            {
                return _dgSelectedIndexSchedule;
            }
            set
            {
                if (_dgSelectedIndexSchedule != value)
                {

                    _dgSelectedIndexSchedule = value;
                    RaisePropertyChanged("dgSelectedIndexSchedule");
                }
            }
        }

        private List<PUR_T002_AFlip> _FlipGridData;
        public List<PUR_T002_AFlip> FlipGridData
        {
            get { return _FlipGridData; }
            set
            {
                if (_FlipGridData != value)
                {
                    _FlipGridData = value;

                    RaisePropertyChanged("FlipGridData");

                }
            }
        }
        private Dictionary<string, object> _taxDictonery;
        public Dictionary<string, object> TaxDictonery
        {
            get { return _taxDictonery; }
            set
            {
                if (_taxDictonery != value)
                {
                    _taxDictonery = value;
                    RaisePropertyChanged("TaxDictonery");
                }
            }
        }

        private Dictionary<string, object> _taxDictoneryParent;
        public Dictionary<string, object> TaxDictoneryParent
        {
            get { return _taxDictoneryParent; }
            set
            {
                if (_taxDictoneryParent != value)
                {
                    _taxDictoneryParent = value;
                    RaisePropertyChanged("TaxDictoneryParent");
                }
            }
        }

        // Pending Assignment of SelectedTaxList
        private List<ACC_M013_P> _SelectedTaxList;
        public List<ACC_M013_P> SelectedTaxList
        {
            get { return _SelectedTaxList; }
            set
            {
                if (_SelectedTaxList != value)
                {
                    _SelectedTaxList = value;
                    RaisePropertyChanged("SelectedTaxList");
                }
            }
        }

        // Pending assignment
        private List<ACC_M013_PopUp> _SelectedChildTaxList;
        public List<ACC_M013_PopUp> SelectedChildTaxList
        {
            get { return _SelectedChildTaxList; }
            set
            {
                if (_SelectedChildTaxList != value)
                {
                    _SelectedChildTaxList = value;

                    //if (PropertyChanged != null)
                    //{
                    RaisePropertyChanged("SelectedChildTaxList");
                    //}
                }
            }
        }

        //Pending Assignment of dgSelectedIndex
        private string _LocalVariable;
        public string LocalVariable
        {
            get
            {
                return _LocalVariable;
            }
            set
            {
                if (_LocalVariable != value)
                {

                    _LocalVariable = value;
                    RaisePropertyChanged("LocalVariable");
                }
            }
        }
        //Pending Assignment of dgSelectedIndex
        private bool _ErrorValue;
        public bool ErrorValue
        {
            get
            {
                return _ErrorValue;
            }
            set
            {
                if (_ErrorValue != value)
                {

                    _ErrorValue = value;
                    this.ErrorExist = _ErrorValue;
                    RaisePropertyChanged("ErrorValue");
                }
            }
        }
        public List<ADM_M003> _ObjSupply = new List<ADM_M003>();
        private List<ADM_M003> ObjSupply
        {
            get { return _ObjSupply; }
            set
            {
                if (_ObjSupply != value)
                {
                    _ObjSupply = value;
                }
            }
        }
        private int _selectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _selectedTabControlIndex; }
            set
            {
                if (_selectedTabControlIndex != value)
                {
                    _selectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }
        #endregion

        #region ICollection

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _partyCollection;
        public ICollectionView PartyCollection
        {
            get { return _partyCollection; }
            set { _partyCollection = value; RaisePropertyChanged("PartyCollection"); }
        }
        private ICollectionView _uomCollection;
        public ICollectionView UomCollection
        {
            get { return _uomCollection; }
            set { _uomCollection = value; RaisePropertyChanged("UomCollection"); }
        }
        private ICollectionView _buyerCollection;
        public ICollectionView BuyerCollection
        {
            get { return _buyerCollection; }
            set { _buyerCollection = value; RaisePropertyChanged("BuyerCollection"); }
        }
        private ICollectionView _suppCollection;
        public ICollectionView SuppCollection
        {
            get { return _suppCollection; }
            set { _suppCollection = value; RaisePropertyChanged("SuppCollection"); }
        }
        private ICollectionView _journalCollection;
        public ICollectionView journalCollection
        {
            get { return _journalCollection; }
            set
            {
                _journalCollection = value;
                RaisePropertyChanged("journalCollection");
            }
        }
        private ICollectionView _paytermCollection;
        public ICollectionView PayTermCollection
        {
            get { return _paytermCollection; }
            set { _paytermCollection = value; RaisePropertyChanged("PayTermCollection"); }
        }
        private ICollectionView _warehouseCollection;
        public ICollectionView warehouseCollection
        {
            get { return _warehouseCollection; }
            set { _warehouseCollection = value; RaisePropertyChanged("warehouseCollection"); }
        }
        private ICollectionView _doc_typeCollection;
        public ICollectionView doc_typeCollection
        {
            get { return _doc_typeCollection; }
            set
            {
                _doc_typeCollection = value;
                RaisePropertyChanged("doc_typeCollection");
            }
        }
        private ICollectionView _currencyCollection;
        public ICollectionView currencyCollection
        {
            get { return _currencyCollection; }
            set
            {
                _currencyCollection = value;
                RaisePropertyChanged("currencyCollection");
            }
        }
        private ICollectionView _po_orgCollection;
        public ICollectionView po_orgCollection
        {
            get { return _po_orgCollection; }
            set
            {
                _po_orgCollection = value;
                RaisePropertyChanged("po_orgCollection");
            }
        }
        private ICollectionView _pur_groupCollection;
        public ICollectionView Purchase_groupCollection
        {
            get { return _pur_groupCollection; }
            set
            {
                _pur_groupCollection = value;
                RaisePropertyChanged("Purchase_groupCollection");
            }
        }
        private ICollectionView _storage_locCollection;
        public ICollectionView storage_locCollection
        {
            get { return _storage_locCollection; }
            set
            {
                _storage_locCollection = value;
                RaisePropertyChanged("storage_locCollection");
            }
        }
        private ICollectionView _cost_centerCollection;
        public ICollectionView cost_centerCollection
        {
            get { return _cost_centerCollection; }
            set
            {
                _cost_centerCollection = value;
                RaisePropertyChanged("cost_centerCollection");
            }
        }
        private ICollectionView _billAddrCollection;
        public ICollectionView BilAdderCollection
        {
            get { return _billAddrCollection; }
            set { _billAddrCollection = value; RaisePropertyChanged("BilAdderCollection"); }
        }
        private ICollectionView _delAddrCollection;
        public ICollectionView DelAddrCollection
        {
            get { return _delAddrCollection; }
            set { _delAddrCollection = value; RaisePropertyChanged("DelAddrCollection"); }
        }
        private ICollectionView _itemcategoryCollection;
        public ICollectionView itemcategoryCollection
        {
            get { return _itemcategoryCollection; }
            set
            {
                _itemcategoryCollection = value;
                RaisePropertyChanged("itemcategoryCollection");
            }
        }
        private ICollectionView _validatedByCollection;
        public ICollectionView validatedByCollection
        {
            get { return _validatedByCollection; }
            set { _validatedByCollection = value; RaisePropertyChanged("validatedByCollection"); }
        }
        private ICollectionView _dgPOItemsFortaxval;
        public ICollectionView dgPOItemsFortaxval
        {
            get { return _dgPOItemsFortaxval; }
            set
            {
                _dgPOItemsFortaxval = value;
                RaisePropertyChanged("dgPOItemsFortaxval");
            }
        }

        private ICollectionView _ReferenceDocCollection;
        public ICollectionView ReferenceDocCollection
        {
            get { return _ReferenceDocCollection; }
            set { _ReferenceDocCollection = value; RaisePropertyChanged("ReferenceDocCollection"); }
        }

        // Pending assignment of ItemCollection
        private ICollectionView _itemCollection;
        public ICollectionView ItemCollection
        {
            get { return _itemCollection; }
            set { _itemCollection = value; RaisePropertyChanged("ItemCollection"); }
        }

        private ICollectionView _supplyingPlantCollection;
        public ICollectionView SupplyingPlantCollection
        {
            get { return _supplyingPlantCollection; }
            set { _supplyingPlantCollection = value; RaisePropertyChanged("SupplyingPlantCollection"); }
        }

        private ICollectionView _receivingPlantCollection;
        public ICollectionView ReceivingPlantCollection
        {
            get { return _receivingPlantCollection; }
            set { _receivingPlantCollection = value; RaisePropertyChanged("ReceivingPlantCollectoion"); }
        }
        private bool _isTabChangeAllowed = true;
        public bool isTabChangeAllowed
        {
            get { return _isTabChangeAllowed; }
            set
            {
                if (_isTabChangeAllowed != value)
                {
                    _isTabChangeAllowed = value; RaisePropertyChanged("isTabChangeAllowed");
                }
            }
        }
        #endregion

        #region StringList Variables

        List<string> _srtValue;
        public List<string> StringListValue
        {
            get { return _srtValue; }
            set
            {
                if (_srtValue != value)
                {
                    _srtValue = value;
                }
            }
        }

        List<string> _strListDocType;
        public List<string> StringListDocumentTypes
        {
            get { return _strListDocType; }
            set
            {
                if (_strListDocType != value)
                {
                    _strListDocType = value;
                }
            }
        }

        List<string> _strListBuyer;
        public List<string> StringListBuyer
        {
            get { return _strListBuyer; }
            set
            {
                if (_strListBuyer != value)
                {
                    _strListBuyer = value;
                }
            }
        }

        List<string> _strListSupplier;
        public List<string> StringListSupplier
        {
            get { return _strListSupplier; }
            set
            {
                if (_strListSupplier != value)
                {
                    _strListSupplier = value;
                }
            }
        }


        List<string> _strListCurrency;
        public List<string> StringListCurrency
        {
            get { return _strListCurrency; }
            set
            {
                if (_strListCurrency != value)
                {
                    _strListCurrency = value;
                }
            }
        }

        List<string> _strListPayTerms;
        public List<string> StringListPayTerms
        {
            get { return _strListPayTerms; }
            set
            {
                if (_strListPayTerms != value)
                {
                    _strListPayTerms = value;
                }
            }
        }

        List<string> _strListPurchaseOrg;
        public List<string> StringListPurchaseOrg
        {
            get { return _strListPurchaseOrg; }
            set
            {
                if (_strListPurchaseOrg != value)
                {
                    _strListPurchaseOrg = value;
                }
            }
        }

        List<string> _strListPurchaseGroup;
        public List<string> StringListPurchaseGroup
        {
            get { return _strListPurchaseGroup; }
            set
            {
                if (_strListPurchaseGroup != value)
                {
                    _strListPurchaseGroup = value;
                }
            }
        }

        List<string> _strListPurchaseWearhouse;
        public List<string> StringListPurchaseWearhouse
        {
            get { return _strListPurchaseWearhouse; }
            set
            {
                if (_strListPurchaseWearhouse != value)
                {
                    _strListPurchaseWearhouse = value;
                }
            }
        }

        List<string> _strListPurchaseStorageLocation;
        public List<string> StringListPurchaseStorageLocation
        {
            get { return _strListPurchaseStorageLocation; }
            set
            {
                if (_strListPurchaseStorageLocation != value)
                {
                    _strListPurchaseStorageLocation = value;
                }
            }
        }

        List<string> _strListDeliveryAddress;
        public List<string> StringListDeliveryAddress
        {
            get { return _strListDeliveryAddress; }
            set
            {
                if (_strListDeliveryAddress != value)
                {
                    _strListDeliveryAddress = value;
                }
            }
        }

        List<string> _strListCostCenter;
        public List<string> StringListCostCenter
        {
            get { return _strListCostCenter; }
            set
            {
                if (_strListCostCenter != value)
                {
                    _strListCostCenter = value;
                }
            }
        }



        List<string> _stringListUOM;
        public List<string> StringListUOM
        {
            get { return _stringListUOM; }
            set
            {
                if (_stringListUOM != value)
                {
                    _stringListUOM = value;
                }
            }
        }

        List<string> _stringListItemCategory;
        public List<string> StringListItemCategory
        {
            get { return _stringListItemCategory; }
            set
            {
                if (_stringListItemCategory != value)
                {
                    _stringListItemCategory = value;
                }
            }
        }

        List<string> _stringListItems;
        public List<string> StringListItems
        {
            get { return _stringListItems; }
            set
            {
                if (_stringListItems != value)
                {
                    _stringListItems = value;
                }
            }
        }
        List<string> _StringListTaxAcc;
        public List<string> StringListTaxAcc
        {
            get { return _StringListTaxAcc; }
            set
            {
                if (_StringListTaxAcc != value)
                {
                    _StringListTaxAcc = value;
                }
            }
        }

        List<string> _strListSupplyingPlant;
        public List<string> StringListSupplyingPlant
        {
            get { return _strListSupplyingPlant; }
            set
            {
                if (_strListSupplyingPlant != value)
                {
                    _strListSupplyingPlant = value;
                }
            }
        }
        List<string> _strListReceivingPlant;
        public List<string> StringListReceivingPlant
        {
            get { return _strListReceivingPlant; }
            set
            {
                if (_strListReceivingPlant != value)
                {
                    _strListReceivingPlant = value;
                }
            }
        }


        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand CommandLoadDocumentFromSource { get; private set; }
        public RelayCommand<Boolean> CommandActiveInactiveCheck { get; private set; }
        public RelayCommand<object> SelectionChangedCommandParty { get; private set; }
        public RelayCommand<object> SelectionChangedCommandDocType { get; private set; }
        public RelayCommand<object> SelectionChangedCommandBuyer { get; private set; }
        public RelayCommand<object> SelectionChangedCommandSupplier { get; private set; }
        public RelayCommand<object> SelectionChangedCommandValidator { get; private set; }
        public RelayCommand<object> SelectionChangedCommandCurrency { get; private set; }
        public RelayCommand<object> SelectionChangedCommandPayTerms { get; private set; }
        public RelayCommand<object> SelectionChangedCommandPurchaseOrg { get; private set; }
        public RelayCommand<object> SelectionChangedCommandPurchaseGroup { get; private set; }
        public RelayCommand<object> SelectionChangedCommandWearhouse { get; private set; }
        public RelayCommand<object> SelectionChangedCommandStorageLocation { get; private set; }
        public RelayCommand<object> SelectionChangedCommandDeliveryAddress { get; private set; }
        public RelayCommand<object> SelectionChangedCommandCostCenter { get; private set; }
        public RelayCommand<object> SelectionChangedReferenceDocumentType { get; private set; }
        public RelayCommand<object> SelectionChangedReferenceDocumentNumber { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> SelectionChangedCommandSupplyingPlant { get; private set; }
        public RelayCommand<object> SelectionChangedCommandReceivingPlant { get; private set; }

        //DataGrid Record addtion commands 
        public RelayCommand<object> CommandAddItem { get; private set; }
        public RelayCommand<object> CommandAddUOM { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CommandAddItemCategory { get; private set; }
        public RelayCommand<object> CommandDeleteScheduleItem { get; private set; }

        public RelayCommand<object> CommandAddSelectedTax { get; private set; }
        public RelayCommand<object> cmdDeleteTax { get; private set; }
        public RelayCommand<object> ManualTaxChangedCommand { get; private set; }




        #endregion

        #region Constructor
        private static PUR_T002_AVM_Internal Expose_ViewModel;
        public static PUR_T002_AVM_Internal SharedViewModel()
        {
            return Expose_ViewModel ?? (Expose_ViewModel = new PUR_T002_AVM_Internal(null));
        }
        public PUR_T002_AVM_Internal(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntityTemp = new PUR_T002_A(); // pending assignment
            MasterEntity = new PUR_T002_A();
            ItemListForPopup = new List<PUR_T002_P_PR_ItemsList>();
            dgItemsEntity = new ObservableCollection<PUR_T002_B>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            dgTotalTaxSummury = new ObservableCollection<PUR_T002_C>();
            ScheduleEntity = new PUR_T004_A();
            dgItemScheduleEntity = new ObservableCollection<PUR_T004_B>();
            FlipGridData = new List<PUR_T002_AFlip>();
            MC = new MultipleContext_PUR_T002_A();
            MCTemp = new MultipleContext_PUR_T002_A();
            MasterEntity.ValidateAsync().Wait();
            PUR_T002_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            PUR_T002_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            PUR_T004_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Schedule);
            dgItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            dgItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
            LoadInitialData();
            DefaultValues();
        }
        public PUR_T002_AVM_Internal(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntityTemp = new PUR_T002_A(); // pending assignment
            MasterEntity = new PUR_T002_A();
            ItemListForPopup = new List<PUR_T002_P_PR_ItemsList>();
            dgItemsEntity = new ObservableCollection<PUR_T002_B>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            dgTotalTaxSummury = new ObservableCollection<PUR_T002_C>();
            ScheduleEntity = new PUR_T004_A();
            dgItemScheduleEntity = new ObservableCollection<PUR_T004_B>();
            FlipGridData = new List<PUR_T002_AFlip>();
            MC = new MultipleContext_PUR_T002_A();
            MCTemp = new MultipleContext_PUR_T002_A();
            MasterEntity.ValidateAsync().Wait();
            PUR_T002_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            PUR_T002_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            PUR_T004_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Schedule);
            dgItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            dgItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
            LoadInitialData();
            DefaultValues();
        }
        #endregion

        #region LoadInitial
        private void LoadInitialData()
        {
            try
            {
                #region Command Initialisation
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CommandLoadDocumentFromSource = new RelayCommand(() => LoadSourceDocument());
                CommandActiveInactiveCheck = new RelayCommand<bool>(CheckActiveStatus);
                // Pending Task for Commands : change name of existing commands Name to start with Command.
                SelectionChangedCommandParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, NewRecord); });
                SelectionChangedCommandDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocType(items); });
                SelectionChangedCommandBuyer = new RelayCommand<object>(items => { if (items == null) { return; } InsertBuyer(items); });
                SelectionChangedCommandSupplier = new RelayCommand<object>(items => { if (items == null) { return; } InsertSupplier(items); });
                SelectionChangedCommandValidator = new RelayCommand<object>(items => { if (items == null) { return; } InsertValidator(items); });
                SelectionChangedCommandCurrency = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrency(items); });
                SelectionChangedCommandPayTerms = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayTerm(items); });
                SelectionChangedCommandPurchaseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseOrg(items); });
                SelectionChangedCommandPurchaseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseGroup(items); });
                SelectionChangedCommandWearhouse = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseWearhouse(items); });
                SelectionChangedCommandStorageLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseStorageLocation(items); });
                SelectionChangedCommandDeliveryAddress = new RelayCommand<object>(items => { if (items == null) { return; } InsertDeliveryAddress(items); });
                SelectionChangedCommandCostCenter = new RelayCommand<object>(items => { if (items == null) { return; } InsertCostCenter(items); });
                SelectionChangedReferenceDocumentType = new RelayCommand<object>(items => { if (items == null) { return; } FilterReferenceDocumentNumbers(items); }); // Pending Assignment
                SelectionChangedReferenceDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } InsertReferenceDocumentNumber(items); });
                //CommandLoadDocumentByByDocumentNumber = new RelayCommand(LoadDocumentByDocumentNumber);
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CommandAddItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Item(cmdPara, true, true, true); });
                CommandAddItemCategory = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_ItemCategory(cmdPara, false, true, true); });
                CommandAddUOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_UOM(cmdPara, false, true, true); });
                CommandDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
                SelectionChangedCommandSupplyingPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertSupplyingPlant(items); });
                SelectionChangedCommandReceivingPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertReceivingPlant(items); });
                CommandDeleteScheduleItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_ItemSchedule(cmdPara); });
                cmdDeleteTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteTax(cmdPara); });

                CommandAddSelectedTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSelectedTax(cmdPara); });
                ManualTaxChangedCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertManualTaxChangedCommand(cmdPara); });

                #endregion
                MasterEntity.doc_cat = "IJ";
                MasterEntity.doc_type = "IJ";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MC, Request, "StockTransferOrder", "Procurement", "LoadAll", 0, "");

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                PartyCollection = CollectionViewSource.GetDefaultView(MC.partyList);
                PartyCollection.Filter = new Predicate<object>(FilterParty);
                StringListValue = MC.partyList.Select(x => x.PartyId).ToList();

                UomCollection = CollectionViewSource.GetDefaultView(MC.unitList.ToList());
                UomCollection.Filter = new Predicate<object>(FilterUom);
                StringListUOM = MC.unitList.Select(x => x.unit_code).ToList();

                BuyerCollection = CollectionViewSource.GetDefaultView(MC.BuyerList.ToList());
                BuyerCollection.Filter = new Predicate<object>(FilterBuyer);
                StringListBuyer = MC.BuyerList.Select(x => x.EmpId).ToList();

                SuppCollection = CollectionViewSource.GetDefaultView(MC.BuyerList.ToList());
                SuppCollection.Filter = new Predicate<object>(FilterBuyer);
                StringListSupplier = MC.BuyerList.Select(x => x.EmpId).ToList();

                journalCollection = CollectionViewSource.GetDefaultView(MC.journalList);
                journalCollection.Filter = new Predicate<object>(journal_Filter);

                PayTermCollection = CollectionViewSource.GetDefaultView(MC.PayTerms.ToList());
                PayTermCollection.Filter = new Predicate<object>(FilterPayTerms);
                StringListPayTerms = MC.PayTerms.Select(x => x.p_term_code).ToList();

                warehouseCollection = CollectionViewSource.GetDefaultView(MC.WarehouseList);
                warehouseCollection.Filter = new Predicate<object>(FilterCollectionWarehouse);
                StringListPurchaseWearhouse = MC.WarehouseList.Select(x => x.wa_code).ToList();

                doc_typeCollection = CollectionViewSource.GetDefaultView(MC.doc_typeList);
                doc_typeCollection.Filter = new Predicate<object>(doctype_Filter);
                StringListDocumentTypes = MC.doc_typeList.Select(x => x.doc_type).ToList();

                currencyCollection = CollectionViewSource.GetDefaultView(MC.currencyList);
                currencyCollection.Filter = new Predicate<object>(currency_Filter);
                StringListCurrency = MC.currencyList.Select(x => x.curr_code).ToList();

                po_orgCollection = CollectionViewSource.GetDefaultView(MC.purchase_orgList);
                po_orgCollection.Filter = new Predicate<object>(Purorg_Filter);
                StringListPurchaseOrg = MC.purchase_orgList.Select(x => x.po_code).ToList();

                Purchase_groupCollection = CollectionViewSource.GetDefaultView(MC.Purchase_groupList);
                Purchase_groupCollection.Filter = new Predicate<object>(Purchase_grp_Filter);
                StringListPurchaseGroup = MC.Purchase_groupList.Select(x => x.pg_code).ToList();

                storage_locCollection = CollectionViewSource.GetDefaultView(MC.storage_locList.ToList());
                storage_locCollection.Filter = new Predicate<object>(storage_loc_Filter);
                StringListPurchaseStorageLocation = MC.storage_locList.Select(x => x.store_code).ToList();

                cost_centerCollection = CollectionViewSource.GetDefaultView(MC.cost_centerList);
                cost_centerCollection.Filter = new Predicate<object>(cost_center_Filter);
                StringListCostCenter = MC.cost_centerList.Select(x => x.cost_center).ToList();

                BilAdderCollection = CollectionViewSource.GetDefaultView(MC.billaddrList.ToList());
                BilAdderCollection.Filter = new Predicate<object>(Filterbilladdr);


                DelAddrCollection = CollectionViewSource.GetDefaultView(MC.deladdrList.ToList());
                DelAddrCollection.Filter = new Predicate<object>(Filterdeladdr);
                StringListDeliveryAddress = MC.deladdrList.Select(x => x.location_Id).ToList();

                itemcategoryCollection = CollectionViewSource.GetDefaultView(MC.itemcatList);
                itemcategoryCollection.Filter = new Predicate<object>(Filteritemcategory);
                StringListItemCategory = MC.itemcatList.Select(x => x.item_cat).ToList();

                ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListForPopup);
                ItemCollection.Filter = new Predicate<object>(FilterItem);
                StringListItems = MC.ItemListForPopup.Select(x => x.ItemCode).ToList();

                validatedByCollection = CollectionViewSource.GetDefaultView(MC.BuyerList.ToList());
                validatedByCollection.Filter = new Predicate<object>(Filtervalidator);



                dgPOItemsFortaxval = CollectionViewSource.GetDefaultView(MC.AccountList);
                dgPOItemsFortaxval.Filter = new Predicate<object>(FiltertaxAcc);
                StringListTaxAcc = MC.AccountList.Select(x => x.acc_code).ToList();

                ObjSupply = (List<ADM_M003>)AppSessionState.ADM_M003_List;

                SupplyingPlantCollection = CollectionViewSource.GetDefaultView(ObjSupply.ToList());
                SupplyingPlantCollection.Filter = new Predicate<object>(FilterSupplyingPlant);
                StringListSupplyingPlant = ObjSupply.Select(x => x.location_Id).ToList();

                ReceivingPlantCollection = CollectionViewSource.GetDefaultView(ObjSupply.ToList());
                ReceivingPlantCollection.Filter = new Predicate<object>(FilterReceivingPlant);
                StringListReceivingPlant = ObjSupply.Select(x => x.location_Id).ToList();


                //string locname = (from o in Object where o.location_Id == AppSessionState.location_Id select o.LoctnNm).ToString();

                //foreach (var item in ObjSupply)
                //{
                //    if (AppSessionState.location_Id == item.location_Id)
                //    {
                //        MasterEntity.rec_plant = item.LoctnNm;
                //    }
                //}

                TaxDictonery = new Dictionary<string, object>();

                TaxDictonery.Clear();
                TaxDictonery = MC.TaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);

                var TaxListParent = (from o in MC.TaxList
                                     where o.parent_id == null
                                     select o).ToList();
                SelectedTaxList = TaxListParent;
                TaxDictoneryParent = SelectedTaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);

                ReferenceDocCollection = CollectionViewSource.GetDefaultView(MC.reference_docList);
                ReferenceDocCollection.Filter = new Predicate<object>(FilterRefDocNo);
                StringListItemCategory = MC.itemcatList.Select(x => x.item_cat).ToList();

                

            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        #endregion

        #region User Defined Functions
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.doc_cat = "IJ";
            MasterEntity.doc_type = "IJ";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.del_address_id = AppSessionState.location_Id;
            MasterEntity.bill_address_id = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.rel_sts = "Open";
            MasterEntity.t_status = "Draft";
            MasterEntity.po_no = "";
            MasterEntity.po_date = DateTime.Now;
            MasterEntity.shipped = false;
            MasterEntity.version = "v1.0";
            ScheduleEntity.t_status = "Draft";
            ScheduleEntity.sch_date = DateTime.Now;
            ScheduleEntity.active = true;
            ScheduleEntity.add_by = AppSessionState.UserID;
            ScheduleEntity.comp_code = AppSessionState.comp_code;
            ScheduleEntity.location_Id = AppSessionState.location_Id;
            ScheduleEntity.id = 0;
            ScheduleEntity.PartyId = MasterEntity.PartyId;

        }
        private void TaxComputation(bool Compute)
        {
            try
            {
                if (Compute == true)
                {
                    decimal? PreviousTaxValueForBasePrice = 0;
                    decimal? BasePrice = 0;
                    decimal? TaxAmount = 0;
                    decimal? BasicItemAmount = 0;
                    decimal? TaxValue = 0;
                    decimal? TaxtTotal = 0;
                    decimal? UnTaxTotal = 0;
                    decimal? GrandTotal = 0;

                    if (dgItemsEntity != null && dgItemsEntity.Count > 0 && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < dgItemsEntity.Count) //Condition satisfy only if Items collection is not empty.
                    {
                        if (dgItemsEntity[dgSelectedIndexItem].qty > 0 && dgItemsEntity[dgSelectedIndexItem].unit_price > 0 && dgItemsEntity[dgSelectedIndexItem].active != false) // Must not null or empty.
                        {
                            dgItemsEntity[dgSelectedIndexItem].sub_total = dgItemsEntity[dgSelectedIndexItem].qty * dgItemsEntity[dgSelectedIndexItem].unit_price;
                        }
                        #region Remove previously assign Taxes to apply new for perticuler item row.
                        //if (TotalDocumentTaxes.Count > 0 && dgItemsEntity[dgSelectedIndexItem].tax_id != null) // Remove previously assign Taxes to apply new for perticuler item row.//Condition satisfy only if Selected Item not null.
                        if (dgItemsEntity[dgSelectedIndexItem].tax_id != null && dgItemsEntity[dgSelectedIndexItem].active == true) // Remove previously assign Taxes to apply new for perticuler item row.//Condition satisfy only if Selected Item not null.
                        {
                            if (!String.IsNullOrEmpty(dgItemsEntity[dgSelectedIndexItem].tax_id.Trim()) && dgItemsEntity[dgSelectedIndexItem].active != false) //Condition satisfy only if Selected Item having Tax assigned.
                            {
                                List<ACC_T006_B> copy = new List<ACC_T006_B>();
                                copy = TotalDocumentTaxes.ToList();
                                foreach (var tax in copy)
                                {
                                    if (tax.ItemCode == dgItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == dgItemsEntity[dgSelectedIndexItem].sku)
                                    {
                                        TotalDocumentTaxes.Remove(tax);
                                    }
                                }
                                #region Tax Not Null

                                List<ACC_M013_P> TaxListTemp = new List<ACC_M013_P>();
                                string[] TaxArray = dgItemsEntity[dgSelectedIndexItem].tax_id.Trim().Split(',');
                                foreach (string SingleTax in TaxArray) // select all Taxes & Child Taxes which is applicablt for Item.
                                {
                                    foreach (ACC_M013_P PickTax in MC.TaxList)
                                    {
                                        if (PickTax.id == Convert.ToInt32(SingleTax) || PickTax.parent_id == Convert.ToInt32(SingleTax))
                                        {
                                            TaxListTemp.Add(PickTax); // collection of All Parent and Child Taxes applicable for current Item.
                                        }
                                    }
                                }
                                // pending check index
                                int?[] TaxListForBaseInclude = new int?[TaxListTemp.Count];
                                for (int i = 0; i < TaxListTemp.Count; i++) // Collect Taxes having property Include_base = true.
                                {
                                    if (TaxListTemp[i].include_base_amount == true)
                                    {
                                        TaxListForBaseInclude[i] = (int?)TaxListTemp[i].id;
                                    }
                                }
                                TaxListTemp = TaxListTemp.OrderBy(tax => tax.sequence).ToList(); // Set ascending order of Taxex by sequence column to get Base amount for next/current Tax. Base Amount = Sub Total + Previous Tax Amount. (Previous Tax= Having column Include_Base_amount = True)
                                if (TaxListTemp.Count > 0)
                                {
                                    foreach (ACC_M013_P SingleTax in TaxListTemp) // Foreach Loop for Computation of Induvidual Tax as per the proerties in Tax Master.
                                    {
                                        PreviousTaxValueForBasePrice = 0;
                                        BasePrice = 0;
                                        TaxAmount = 0;
                                        BasicItemAmount = 0;
                                        TaxValue = 0;
                                        TaxtTotal = 0;
                                        UnTaxTotal = 0;
                                        GrandTotal = 0;
                                        #region Percentage
                                        if (SingleTax.t_type == "Percentage" && SingleTax.amount > 0)
                                        {
                                            if (SingleTax.Price_include == true)
                                            {
                                                TaxValue = (SingleTax.amount) / 100 + 1;
                                                BasePrice = dgItemsEntity[dgSelectedIndexItem].sub_total / TaxValue;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = dgItemsEntity[dgSelectedIndexItem].sub_total - BasicItemAmount;
                                            }
                                            else if (SingleTax.Price_include == false)
                                            {
                                                TaxValue = (SingleTax.amount) / 100;
                                                if (TaxListForBaseInclude.Length > 0)
                                                {
                                                    PreviousTaxValueForBasePrice = TotalDocumentTaxes.Where(tax => tax.sequence < SingleTax.sequence && tax.ItemCode == dgItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == dgItemsEntity[dgSelectedIndexItem].sku && tax.item_line_id == dgItemsEntity[dgSelectedIndexItem].id && tax.tax_code_id.In(TaxListForBaseInclude)).Sum(tax => tax.tax_amount); // Get Base amount for Calculation.
                                                }
                                                if (SingleTax.parent_id != null) // Collect Base price for This single child Tax.
                                                {
                                                    BasePrice = TotalDocumentTaxes.Where(tax => tax.tax_code_id == SingleTax.parent_id && tax.ItemCode == dgItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == dgItemsEntity[dgSelectedIndexItem].sku && tax.item_line_id == dgItemsEntity[dgSelectedIndexItem].id).Single().tax_amount;
                                                }
                                                else // Collect Base Price for this parent Tax.
                                                {
                                                    BasePrice = dgItemsEntity[dgSelectedIndexItem].sub_total + PreviousTaxValueForBasePrice;
                                                }
                                                BasicItemAmount = dgItemsEntity[dgSelectedIndexItem].sub_total;
                                                TaxAmount = BasePrice * TaxValue;
                                            }
                                        }
                                        #endregion
                                        #region Fixed Amount
                                        else if (SingleTax.t_type == "Fixed Amount" && SingleTax.amount > 0)
                                        {
                                            TaxValue = SingleTax.amount;
                                            if (SingleTax.Price_include == true)
                                            {
                                                BasePrice = dgItemsEntity[dgSelectedIndexItem].sub_total - TaxValue;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = dgItemsEntity[dgSelectedIndexItem].sub_total - BasicItemAmount;
                                            }
                                            else if (SingleTax.Price_include == false)
                                            {
                                                BasePrice = dgItemsEntity[dgSelectedIndexItem].sub_total;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = TaxValue;
                                            }
                                        }
                                        #endregion

                                        TotalDocumentTaxes.Add(new ACC_T006_B() { id = 0, tax_amount = TaxAmount, account_id = 0, sequence = SingleTax.sequence, doc_no = MasterEntity.po_no, manual = "Auto", base_amount = BasePrice, amount = SingleTax.amount, tax_code_id = SingleTax.id, account_analytic_id = 0, base_code_id = SingleTax.id, tax_name = SingleTax.description, gl_code = "", ItemCode = dgItemsEntity[dgSelectedIndexItem].ItemCode, sku = dgItemsEntity[dgSelectedIndexItem].sku, item_line_id = dgItemsEntity[dgSelectedIndexItem].id, fin_year = "2015", active = true, location_Id = AppSessionState.location_Id, comp_code = AppSessionState.comp_code });
                                    }

                                }

                                #endregion


                            }
                        }

                        else if (dgItemsEntity[dgSelectedIndexItem].tax_id != null && dgItemsEntity[dgSelectedIndexItem].active == false) // Remove previously assign Taxes from TotalDocumentTaxes if removed from Item.//Condition satisfy only if Selected Item not null and Active status is false.
                        {
                            List<ACC_T006_B> copy = new List<ACC_T006_B>();
                            copy = TotalDocumentTaxes.ToList();
                            foreach (var tax in copy)
                            {
                                if (tax.ItemCode == dgItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == dgItemsEntity[dgSelectedIndexItem].sku)
                                {
                                    TotalDocumentTaxes.Remove(tax);
                                }
                            }
                        }
                        #region Final Computation

                        //TaxtTotal = TotalDocumentTaxes.Sum(x => x.tax_amount);
                        TaxtTotal = TotalDocumentTaxes.Where(item => item.active != false).Sum(item => item.tax_amount);
                        MasterEntity.amount_tax = TaxtTotal;
                        //UnTaxTotal = dgItemsEntity.Sum(x => x.sub_total);
                        UnTaxTotal = dgItemsEntity.Where(item => item.active != false).Sum(item => item.sub_total);
                        MasterEntity.amount_untaxed = UnTaxTotal;
                        GrandTotal = UnTaxTotal + TaxtTotal;
                        MasterEntity.amount_total = GrandTotal;
                        MasterEntity.roundup_total = decimal.Round((decimal)GrandTotal);
                        MasterEntity.round_up = MasterEntity.roundup_total - GrandTotal;
                        if (MasterEntity.roundup_total > 0)
                        {
                            ADM_M037 curr_obj = new ADM_M037();
                            curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                            MasterEntity.amt_in_words = num.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word);
                        }
                        else
                        { MasterEntity.amt_in_words = ""; }

                        //var GroupByTaxQuery = from wo in TotalDocumentTaxes
                        //                      group wo by wo.tax_name  // tax_code_id replace with tax_name due to manual Tax integration.
                        //            into g
                        //                      select new ACC_T006_B
                        //                      {
                        //                          id = g.First().id,
                        //                          tax_amount = g.Sum(wo => wo.tax_amount),
                        //                          base_amount = g.Sum(wo => wo.base_amount),
                        //                          tax_code_id = g.First().tax_code_id,
                        //                          tax_name = g.First().tax_name,
                        //                          gl_code = g.First().gl_code,
                        //                          active = g.First().active,
                        //                          account_id = g.First().account_id,
                        //                      };
                        //TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>(GroupByTaxQuery.OrderBy(tax => tax.tax_name));
                        #endregion
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private bool Validation()
        {
            try
            {
                if (dgItemsEntity.Count < 1)
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("please select Item ........");
                    showMessageService.ShowMessage();
                    return false;
                }

                if (MasterEntity.rec_plant == null || MasterEntity.rec_plant == "" && MasterEntity.supplying_plant == null || MasterEntity.supplying_plant == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please select Receiving And Supplying Plant...");
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.rec_plant == MasterEntity.supplying_plant)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please select Receiving And Supplying Plant is Different...");
                    showMessageService.ShowMessage();
                    return false;
                }
                // Validation for record modification depends on workflow and status
                foreach (var o in MC.doc_typeList)
                {

                    if (o.doc_type == MasterEntity.doc_type && o.Workflow_id_temp != null)
                    {
                        if (MasterEntity.t_status == "APPROVED" || MasterEntity.t_status == "RELEASED")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("You cannot edit record once it is Approved");
                            showMessageService.ShowMessage();
                            return false;
                        }

                    }

                }

                // Validation for Quantity Item Duplication and Unit Code For Item Details
                foreach (var o in dgItemsEntity)
                {
                    int flag = 0;
                    if (o.id == 0)
                    {
                        foreach (var p in dgItemsEntity)
                        {
                            if (o.ItemCode == p.ItemCode && o.sku == p.sku)
                            {
                                flag++;
                            }
                        }
                        if (flag > 1)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();
                            return false;
                        }
                    }

                    if (o.ItemCode != null && o.ItemCode != "" && o.description != null)
                    {
                        if (o.qty == null || o.qty == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.unit_code == null || o.unit_code == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();
                            return false;
                        }

                    }
                }

                //Validation For Item Quantity Equal To Sum of Quantities of All Batches Of the Item 
                bool breakfor = false;
                for (int i = 0; i < dgItemsEntity.Count; i++)
                {
                    decimal temp = 0;
                    int flag = 0;

                    for (int j = 0; j < dgItemScheduleEntity.Count; j++)
                    {
                        if (dgItemsEntity[i].ItemCode == dgItemScheduleEntity[j].ItemCode && dgItemsEntity[i].sku == dgItemScheduleEntity[j].sku)
                        {
                            temp = temp + Convert.ToDecimal(dgItemScheduleEntity[j].qty);
                            flag = 1;
                        }
                    }

                    if (dgItemsEntity[i].qty != temp && flag == 1)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Item Quantity is Not Equal to Sum of All Item Batches Quantities for Item {0} Parameter :{1} ", dgItemsEntity[i].ItemCode, dgItemsEntity[i].sku_desc);
                        showMessageService.ShowMessage();
                        breakfor = false;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

            return true;
        }
        #endregion

        #region Event Handler
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "qty" || e.PropertyName == "tax_id" || e.PropertyName == "active")
            {
                TaxComputation(true);
            }
            if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = dgItemsEntity[dgSelectedIndexItem].HasErrors;
            }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (PUR_T002_B item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (PUR_T002_B item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (PUR_T002_B item in e.NewItems)
                    {
                        //Added items
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                    if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
                    }
                }

                if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    this.ErrorExist = false; /* = MasterEntity.HasErrors;*/
                    if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = false; /* dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    PUR_T002_B temp = (PUR_T002_B)e.OldItems[0];
                    foreach (var itemToRemove in dgItemScheduleEntity.Where(x => (x.ItemCode == temp.ItemCode && x.id == 0 && x.sku == temp.sku)).ToList())
                    {
                        dgItemScheduleEntity.Remove(itemToRemove);
                    }
                    if (TotalDocumentTaxes.Count > 0) // Remove Taxes deleted item.
                    {
                        List<ACC_T006_B> copy = new List<ACC_T006_B>();
                        copy = TotalDocumentTaxes.ToList();
                        foreach (var tax in copy)
                        {
                            if (tax.ItemCode == temp.ItemCode && tax.sku == temp.sku && tax.item_line_id == temp.id)
                            {
                                TotalDocumentTaxes.Remove(tax);
                            }
                        }
                        TaxComputation(true);
                    }

                    // option for Multiple condition where clause
                    //Accounts.Where(acc => !(acc.ColA == "X" || (acc.ColA == "Y" && acc.ColB == "T"))).ToArray();
                    //OR
                    //Accounts
                    //        .Where(acc => !(acc.ColA == "X"))
                    //        .Where(acc => !(acc.ColA == "Y" && acc.ColB == "T"))
                    //        .ToArray();
                    foreach (PUR_T002_B item in e.OldItems)
                    {
                        item.PropertyChanged -= EntityViewModelPropertyChanged;
                    }
                    if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist =  false; /*dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Move)
                {
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }

        private void CollectionChangedNotifyForTotalTaxes(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (ACC_T006_B item in e.NewItems)
                        item.PropertyChanged += this.Schedule_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (ACC_T006_B item in e.OldItems)
                        item.PropertyChanged -= this.Schedule_PropertyChanged;

                /////////////////////////////////Temp Test End
                if (e.Action == NotifyCollectionChangedAction.Add && dgItemsEntity.Count > 0) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (ACC_T006_B item in e.NewItems)
                    {

                        if (item.tax_code_id > 0)
                        { item.manual = "Auto"; }
                        else { item.manual = "Manual"; item.sequence = 100; }
                        if (item.tax_name == null || item.tax_name.Trim() == "")
                        { item.tax_name = "CASH"; }
                        item.active = true;
                        item.location_Id = AppSessionState.location_Id;
                        item.comp_code = AppSessionState.comp_code;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                { }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                { }
                if (e.Action == NotifyCollectionChangedAction.Move)
                { }
                int c = TotalDocumentTaxes.Count();
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        void Schedule_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "qty")
                {
                    #region Check Schedule Qty Total should not exceed PO Qty.
                    //Check Schedule Qty Total should not exceed PO Qty.
                    decimal? TotalQtyOfScheduleForItem = 0;
                    TotalQtyOfScheduleForItem = dgItemScheduleEntity.Where(item => item.ItemCode == dgItemsEntity[dgSelectedIndexItem].ItemCode && item.sku == dgItemsEntity[dgSelectedIndexItem].sku).Sum(item => item.qty);
                    decimal? POQty = dgItemsEntity[dgSelectedIndexItem].qty;  // pending error : index > count
                    if (TotalQtyOfScheduleForItem > POQty)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "TO Schedule Information";
                        showMessageService.Text = String.Format("Schedule quantity exceeding TO limit. extra Quantity will required additional Purchase Order", this.Title);
                        showMessageService.ShowMessage();
                    }
                    #endregion
                }
                if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = false; /* dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void CollectionChangedNotifyForSchedule(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (PUR_T004_B item in e.NewItems)
                        item.PropertyChanged += this.Schedule_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (PUR_T004_B item in e.OldItems)
                        item.PropertyChanged -= this.Schedule_PropertyChanged;

                /////////////////////////////////Temp Test End
                if (e.Action == NotifyCollectionChangedAction.Add && dgItemsEntity.Count > 0) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (PUR_T004_B item in e.NewItems)
                    {
                        //Adde items Schedules Default Values from Items Entity

                        item.ItemCode = dgItemsEntity[dgSelectedIndexItem].ItemCode;
                        item.sku = dgItemsEntity[dgSelectedIndexItem].sku;
                        item.po_no = dgItemsEntity[dgSelectedIndexItem].po_no;
                        item.rec_qty = 0;
                        item.t_status = "Draft";
                        item.active = true;
                        item.editby = AppSessionState.UserID;
                        item.location_Id = AppSessionState.location_Id;
                        item.comp_code = AppSessionState.comp_code;
                        item.rate = 0;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                }

                if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    //dgItemScheduleEntity.Remove(x => x.)
                    //PUR_T002_B temp = (PUR_T002_B)e.NewItems[0];
                    //foreach (var itemToRemove in dgItemScheduleEntity.Where(x => x.ItemCode == temp.ItemCode).ToList())
                    //{
                    //    dgItemScheduleEntity.Remove(itemToRemove);
                    //}
                }
                if (e.Action == NotifyCollectionChangedAction.Move)
                {
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /* MasterEntity.HasErrors;*/
            if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = false; /*dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
            }

        }
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            LocalVariable = MasterEntity.PartyId;
            this.ErrorExist = false; /*= MasterEntity.HasErrors;*/
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            if (sender.ToString() == "qty" || sender.ToString() == "unit_price" || sender.ToString() == "tax_id" || sender.ToString() == "active")
            {
                TaxComputation(true);
            }
            this.ErrorExist = MasterEntity.HasErrors;
            if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = false; /* dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
            }

        }
        void ModelUpdated_Schedule(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
        }
        #endregion

        #region Command Handler
        private void Invoke_Reference_Document(object InputValue)
        {
            try
            {
                string Request = "";
                ReflectionFunctionService objRef = new ReflectionFunctionService();
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = MasterEntity.client + "!@" + MasterEntity.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    //isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                    AppSessionState.ViewOtherRecordAllowed = true;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void InsertParty(object InputValue, bool OverrideValue)
        {
            //ADM_M028_PopUp
            //string Request = "";
            //string RequestParameterData = "";
            //ADM_M028_P POPUPEntityObject = null;
            ////IEnumerable<ADM_M028_PopUp> BEType = new List<ADM_M028_PopUp>(); Garbej
            //#region Command Parameter Read Section
            //try
            //{
            //    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
            //    if (InputValue.GetType() == typeof(string) && InputValue != null)
            //    {
            //        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
            //        Request = InputValue.ToString();
            //        if (Request.Length > 0)
            //        {
            //            try
            //            { POPUPEntityObject = MC.partyList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
            //            catch (Exception ex) { }
            //        }
            //    }
            //    else if (InputValue != null)
            //    {
            //        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
            //    }
            //}
            //catch (Exception ex) { }

            //#endregion
            //if (POPUPEntityObject != null) //&& MasterEntity.PartyId != POPUPEntityObject.PartyId) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
            //{
            //    if (String.IsNullOrEmpty(MasterEntity.po_no) != true || String.IsNullOrWhiteSpace(MasterEntity.po_no) != true) //Condition: Only enter in the code block if ENtity Not null. Means It is in Edit Mode.
            //    {
            //        if (dgItemsEntity.Count > 0 && NewRecord == false)
            //        {
            //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //            showMessageService.ButtonSetup = DialogButton.Ok;
            //            showMessageService.Caption = "Party Change Information";
            //            showMessageService.Text = String.Format("Can not change party'{0}' in edit mode", this.Title);
            //            showMessageService.ShowMessage();
            //        }
            //    }
            //    else if (NewRecord == true && dgItemsEntity.Count > 0)
            //    {
            //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //        showMessageService.ButtonSetup = DialogButton.Ok;
            //        showMessageService.Caption = "Party Selection";
            //        showMessageService.Text = String.Format("If You Change The Party Items Will be removed'{0}'", this.Title);
            //        if (showMessageService.ShowMessage() == DialogResult.Ok)
            //        {
            //            MasterEntity.PartyId = POPUPEntityObject.PartyId;
            //            MasterEntity.party_name = POPUPEntityObject.PartyNm;
            //            MasterEntity.curr_code = POPUPEntityObject.curr_code;
            //            RequestParameterData = "LoadPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + "PO" + "!@" + "PO" + "!@" + MasterEntity.PartyId;
            //            ItemListForPopup = repositoryItemList.GetDataWithReturnDomainObject<PUR_T002_P_PR_ItemsList>(ItemListForPopup, RequestParameterData, "PurchaseOrder", "Procurement");
            //            StringListItems = ItemListForPopup.Select(x => x.ItemCode).ToList();
            //            dgItemsEntity.Clear();
            //            dgItemScheduleEntity.Clear();
            //        }
            //    }
            //    else
            //    {
            //        MasterEntity.PartyId = POPUPEntityObject.PartyId;
            //        MasterEntity.party_name = POPUPEntityObject.PartyNm;
            //        MasterEntity.curr_code = POPUPEntityObject.curr_code;

            //        RequestParameterData = "LoadPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + "TO" + "!@" + "TO" + "!@" + MasterEntity.PartyId;
            //        ItemListForPopup = repositoryItemList.GetDataWithReturnDomainObject<PUR_T002_P_PR_ItemsList>(ItemListForPopup, RequestParameterData, "PurchaseOrder", "Procurement");
            //        StringListItems = ItemListForPopup.Select(x => x.ItemCode).ToList();
            //    }
            //}

        }
        private void InsertDocType(object InputValue)
        {
            string Request = "";
            SYS_M007 POPUPEntityObject = null;
            IEnumerable<SYS_M007> BEType = new List<SYS_M007>();
            #region Command Parameter Read Section
            try
            {
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.doc_typeList.Where(x => x.doc_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M007>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null && MasterEntity.display_doc_type != POPUPEntityObject.doc_type) // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (String.IsNullOrEmpty(MasterEntity.po_no) != true || String.IsNullOrWhiteSpace(MasterEntity.po_no) != true) // Only enter in the code block if ENtity Not null.
                    {
                        if (dgItemsEntity.Count > 0 && NewRecord == false)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Party Change Information";
                            showMessageService.Text = String.Format("Can not change Document Type '{0}' in edit mode", this.Title);
                            showMessageService.ShowMessage();
                        }
                    }
                    else if (NewRecord == true && dgItemsEntity.Count > 0)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Party Selection";
                        showMessageService.Text = String.Format("If You Change The Document Type some data Will be removed'{0}'", this.Title);
                        if (showMessageService.ShowMessage() == DialogResult.Ok)
                        {
                            MasterEntity.doc_type = POPUPEntityObject.doc_type;
                            //  MasterEntity.display_doc_type = POPUPEntityObject.display_doc_type;
                            MasterEntity.doc_desc = POPUPEntityObject.doc_desc;
                        }
                    }
                    else
                    {
                        MasterEntity.doc_type = POPUPEntityObject.doc_type;
                        // MasterEntity.display_doc_type = POPUPEntityObject.display_doc_type;
                        MasterEntity.doc_desc = POPUPEntityObject.doc_desc;

                    }
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        private void InsertBuyer(object InputValue)
        {
            string Request = "";
            ADM_M024_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BuyerList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }

                #endregion
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    MasterEntity.buyer = POPUPEntityObject.EmpId;
                    MasterEntity.BuyerName = POPUPEntityObject.EmpLName;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        private void InsertSupplier(object InputValue)
        {
            string Request = "";
            ADM_M024_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BuyerList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }

                #endregion
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    MasterEntity.supplier_EmpId = POPUPEntityObject.EmpId;
                    MasterEntity.supplier_EmpName = POPUPEntityObject.EmpLName;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        private void InsertSelectedTax(object InputValue)
        {
            string Request = "";
            ACC_M003_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.AccountList.Where(x => x.acc_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_P>().ToList()[0];
                }

                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (TotalDocumentTaxes.Count == dgSelectedIndexTaxSummury && dgSelectedIndexTaxSummury >= 0)
                    {
                        TotalDocumentTaxes.Add(new ACC_T006_B()
                        {

                            gl_code = POPUPEntityObject.acc_code


                        });

                    }
                    else if (TotalDocumentTaxes.Count > dgSelectedIndexTaxSummury)
                    {
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].gl_code = POPUPEntityObject.acc_code;

                    }
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertSupplyingPlant(object InputValue)
        {

            string Request = "";
            ADM_M003 POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = ObjSupply.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                }

                #endregion
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    MasterEntity.supplying_plant = POPUPEntityObject.location_Id;
                    MasterEntity.supplyingplant_name = POPUPEntityObject.LoctnNm;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        private void InsertReceivingPlant(object InputValue)
        {
            string Request = "";
            ADM_M003 POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = ObjSupply.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                }

                #endregion
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    MasterEntity.rec_plant = POPUPEntityObject.location_Id;
                    MasterEntity.rec_plant_name = POPUPEntityObject.LoctnNm;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        private void InsertValidator(object InputValue)
        {
            string Request = "";
            ADM_M024_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BuyerList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.validator_code = POPUPEntityObject.EmpId;
                    MasterEntity.validator_name = POPUPEntityObject.EmpLName;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertCurrency(object InputValue)
        {
            //ADM_M028_PopUp
            string Request = "";
            ADM_M037_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.currencyList.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M037_P>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.curr_code = POPUPEntityObject.curr_code;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        private void InsertPayTerm(object InputValue)
        {
            //ADM_M028_PopUp
            string Request = "";
            ACC_M007_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PayTerms.Where(x => x.p_term_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M007_P>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.p_term_code = POPUPEntityObject.p_term_code;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertPurchaseOrg(object InputValue)
        {
            //ADM_M028_PopUp
            string Request = "";
            ADM_M001_M_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.purchase_orgList.Where(x => x.po_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_M_P>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.po_code = POPUPEntityObject.po_code;
                    MasterEntity.pur_org = POPUPEntityObject.pur_org;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertPurchaseGroup(object InputValue)
        {
            //ADM_M028_PopUp
            string Request = "";
            ADM_M001_P_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Purchase_groupList.Where(x => x.pg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_P_P>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.pg_code = POPUPEntityObject.pg_code;
                    MasterEntity.pg_name = POPUPEntityObject.pg_name;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertPurchaseWearhouse(object InputValue)
        {
            //ADM_M028_PopUp
            string Request = "";
            MM_M002_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WarehouseList.Where(x => x.wa_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M002_P>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.wa_code = POPUPEntityObject.wa_code;
                    MasterEntity.wa_name = POPUPEntityObject.wa_name;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        private void InsertPurchaseStorageLocation(object InputValue)
        {
            //ADM_M028_PopUp
            string Request = "";
            MM_M001_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.storage_locList.Where(x => x.store_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M001_P>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.stock_location_id = POPUPEntityObject.store_code;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        private void InsertDeliveryAddress(object InputValue)
        {
            //ADM_M028_PopUp
            string Request = "";
            ADM_M003_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.deladdrList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_P>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.del_address_id = POPUPEntityObject.location_Id;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertCostCenter(object InputValue)
        {
            //ADM_M028_PopUp
            string Request = "";
            ACC_M019_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.cost_centerList.Where(x => x.cost_center.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M019_P>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.cost_center = POPUPEntityObject.cost_center;
                    MasterEntity.cost_center_Desc = POPUPEntityObject.cost_center_Desc;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        private void InsertReferenceDocumentNumber(object InputValue)
        {
            //PUR_T002_P_RefeDoc
            string Request = "";
            PUR_T002_P_RefeDoc POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.reference_docList.Where(x => x.po_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PUR_T002_P_RefeDoc>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.ref_doc_no = POPUPEntityObject.po_no;
                    MasterEntity.ref_doc_date = POPUPEntityObject.po_date;
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }

        //
        // Summary:
        //     This Method load Document Data for Reference document and for Flip DataGrid.
        //     Call for two seperate purpose
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                PUR_T002_AFlip ParameterEntityObject = null;
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    if (ParameterObject.ToString() == "ReferenceDocument")
                    {
                        if (String.IsNullOrEmpty(MasterEntity.ref_doc_no))
                        {
                            return;
                        }
                        ParametersStringValue = MasterEntity.ref_doc_no;
                        ParameterReference = ParameterObject.ToString();
                    }
                    else if (ParameterReference == "DocumentNumber")
                    {
                        ParametersStringValue = ParameterObject.ToString().Trim();
                    }

                    if (ParametersStringValue.Length > 0)
                    {
                        try
                        { Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParametersStringValue; }
                        catch (Exception ex) { }
                    }
                }
                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<PUR_T002_AFlip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<PUR_T002_AFlip>().ToList()[0];
                        Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParameterEntityObject.po_no;
                        NewRecord = false;
                        string RequestParameterData = "LoadDocumentWithReferenceDocumentNumber" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + "TO" + "!@" + "TO" + "!@" + MasterEntity.location_Id;
                        //ItemListForPopup = repositoryItemList.GetDataWithReturnDomainObject<PUR_T002_P_PR_ItemsList>(ItemListForPopup, RequestParameterData, "StockTransferOrder", "Procurement");
                        //StringListItems = ItemListForPopup.Select(x => x.ItemCode).ToList();
                    }
                }
                MasterEntity = new PUR_T002_A();
                MasterEntity = repository.GetDataWithReturnDomainObject<PUR_T002_A>(MasterEntity, Request, "StockTransferOrder", "Procurement", "LoadDocumentWithReferenceDocumentNumber", 0, "");

                if (ParameterReference == "ReferenceDocument")
                {
                    MasterEntity.ref_doc_no = MasterEntity.po_no;
                    MasterEntity.ref_doc_date = MasterEntity.po_date;
                    MasterEntity.ref_doc_type = MasterEntity.doc_type;
                    MasterEntity.shipped = false;
                    MasterEntity.shipped_date = null;
                    MasterEntity.doc_cat = "TO";
                    MasterEntity.doc_type = "TO";
                    MasterEntity.doc_type_user = "TO";
                    MasterEntity.display_doc_type = "TO";
                    MasterEntity.doc_desc = "Stock Transfer Order";
                    MasterEntity.po_no = "";
                    MasterEntity.po_date = DateTime.Now;
                    MasterEntity.add_by = AppSessionState.UserID;
                    MasterEntity.editby = AppSessionState.UserID;
                    MasterEntity.active = true;
                    MasterEntity.rel_sts = "Open";
                    MasterEntity.t_status = "Draft";
                    MasterEntity.shipped = false;
                    MasterEntity.version = "v1.0";
                    ScheduleEntity.t_status = "Draft";
                    ScheduleEntity.sch_date = DateTime.Now;
                    ScheduleEntity.active = true;
                    ScheduleEntity.add_by = AppSessionState.UserID;
                    ScheduleEntity.id = 0;
                    NewRecord = true;
                }
                SelectedTabControlIndex = 0;
                SetBusinessEntitiesAfterLoad(ParametersStringValue, "");
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }

        /// <summary>
        /// Use this method as extension over a string, which actually does both; first trimming and then checking for IsNullOrEmpty
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        //public static bool IsNullorEmpty(this String val)
        //{
        //    if (val != null)
        //    {
        //        return string.IsNullOrEmpty(val.Trim());
        //    }
        //    return true;
        //}
        // Pending assignment of LoadSourceDocument() Method.
        private void LoadSourceDocument()
        {
            // Load another previous record from database for provided Document number and generate new document.
        }
        private void CheckActiveStatus(bool select)
        {
            //Check weather Status of DataGrid Record is Active or Not. If changes encounter then update other functions accordingly to update Entitoes.

            try
            {
                //TaxTableCalculation();
                //TaxRowCalculation();
            }
            catch { }
        }

        #endregion

        #region Validation Region


        #pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        #endregion

        #region Abstract Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<PUR_T002_A> result)
        {
            try
            {
                if (Validation() == true)
                {
                    //DefaultValues();
                    MasterEntity.XmlDataDocument_PUR_T002_B = obj.ObjectToXML(dgItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_B = obj.ObjectToXML(TotalDocumentTaxes);
                    //ScheduleEntity.PartyId = MasterEntity.PartyId; // cannot assign in default values method because Party not assign at that moment.
                    MasterEntity.XmlDataDocument_PUR_T004_A = obj.ObjectToXML(ScheduleEntity);
                    MasterEntity.XmlDataDocument_PUR_T004_B = obj.ObjectToXML(dgItemScheduleEntity);
                    //ScheduleEntity.XmlDataDocument_PUR_T004_B = obj.ObjectToXML(dgItemScheduleEntity);
                    //MasterEntity.XmlDataDocument_PUR_T004_A = obj.ObjectToXML(ScheduleEntity);

                    this.MasterEntity.EndEdit();
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PUR_T002_A>(MasterEntity, "StockTransferOrder", "Procurement");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<PUR_T002_A>(MasterEntity, "StockTransferOrder", "Procurement");
                        //MasterEntity = repository.SaveWithReturnDomainObject<PUR_T002_A>(MasterEntity, "PurchaseOrder", "Procurement");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    NewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_PUR_T002_B != null)
                {
                    //MC.DocumentItems = (ObservableCollection<PUR_T002_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PUR_T002_B, MC.DocumentItems);
                    //dgItemsEntity.Clear();
                    //dgItemsEntity = MC.DocumentItems;

                    dgItemsEntity.Clear();
                    dgItemsEntity = (ObservableCollection<PUR_T002_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PUR_T002_B, MC.DocumentItems);
                    MasterEntity = MasterEntity;
                }
                else
                {
                    MC.DocumentItems = new ObservableCollection<PUR_T002_B>();
                }
                if (MasterEntity.XmlDataDocument_ACC_T006_B != null)
                {
                    MC.DocumentTaxDetails = (ObservableCollection<ACC_T006_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T006_B, MC.DocumentTaxDetails);
                    TotalDocumentTaxes.Clear();
                    TotalDocumentTaxes = MC.DocumentTaxDetails;
                    //var GroupByTaxQuery = from wo in TotalDocumentTaxes
                    //                      group wo by wo.tax_name  // tax_code_id replace with tax_name due to manual Tax integration.
                    //            into g
                    //                      select new ACC_T006_B
                    //                      {
                    //                          id = g.First().id,
                    //                          tax_amount = g.Sum(wo => wo.tax_amount),
                    //                          base_amount = g.Sum(wo => wo.base_amount),
                    //                          tax_code_id = g.First().tax_code_id,
                    //                          tax_name = g.First().tax_name,
                    //                          gl_code = g.First().gl_code,
                    //                          active = g.First().active,
                    //                          account_id = g.First().account_id,
                    //                      };
                    //TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>(GroupByTaxQuery.OrderBy(tax => tax.tax_name));
                }
                else
                {
                    MC.DocumentTaxDetails = new ObservableCollection<ACC_T006_B>();
                }
                if (MasterEntity.XmlDataDocument_PUR_T004_A != null)
                {
                    List<PUR_T004_A> ScheduleEntityList = new List<PUR_T004_A>();
                    ScheduleEntityList = (List<PUR_T004_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PUR_T004_A, ScheduleEntityList);
                    if (ScheduleEntityList.Count > 0)
                    {
                        ScheduleEntity = ScheduleEntityList[0];
                    }
                }
                else
                {
                    ScheduleEntity = new PUR_T004_A();
                }
                if (MasterEntity.XmlDataDocument_PUR_T004_B != null)
                {
                    MC.DocumentScheduleDetails = (ObservableCollection<PUR_T004_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PUR_T004_B, MC.DocumentScheduleDetails);
                    dgItemScheduleEntity.Clear();
                    dgItemScheduleEntity = MC.DocumentScheduleDetails;
                }
                else
                {
                    MC.DocumentScheduleDetails = new ObservableCollection<PUR_T004_B>();
                }
                if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<PUR_T002_AFlip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                    DataGridCollection.Refresh();
                    DataGridCollection.SortDescriptions.Add(new SortDescription("po_no", ListSortDirection.Descending));

                }
                MasterEntity.ts_code = ts_code_vm;
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        protected override void OnCreateAction(InquiryActionResult<PUR_T002_A> result)
        {
            NewRecord = true;
            MasterEntity = new PUR_T002_A();
            MasterEntity.ValidateAsync().Wait();
            dgItemsEntity = new ObservableCollection<PUR_T002_B>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            dgTotalTaxSummury = new ObservableCollection<PUR_T002_C>();
            ScheduleEntity = new PUR_T004_A();
            dgItemScheduleEntity = new ObservableCollection<PUR_T004_B>();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<PUR_T002_A> result)
        {
            try
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Delete Changes";
                showMessageService.Text =
                    String.Format(
                        "This record will be Deleted forever '{0}'",
                            this.Title);
                if (showMessageService.ShowMessage() == DialogResult.Ok)
                {
                    this.MasterEntity.EndEdit();
                    string response = repository.Delete(MasterEntity.po_no, "StockTransferOrder", "Procurement");
                    //FlipGridData.Remove(MasterEntity); Temp
                    MasterEntity = new PUR_T002_A();
                    dgItemsEntity = new ObservableCollection<PUR_T002_B>();
                    _dataGridCollection.Refresh();
                    NewRecord = true;

                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<PUR_T002_A> result)
        {
            MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<PUR_T002_A> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<PUR_T002_A> result)
        {


        }
        protected override void OnHelpAction(InquiryActionResult<PUR_T002_A> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<PUR_T002_A> result)
        {


        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<PUR_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PUR_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PUR_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PUR_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PUR_T002_A> result)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Filters

        private string _filterString_FlipGrid;
        public string FilterString_FlipGrid
        {
            get { return _filterString_FlipGrid; }
            set
            {
                _filterString_FlipGrid = value;
                RaisePropertyChanged("FilterString_FlipGrid");
                FilterCollection();
            }
        }
        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as PUR_T002_AFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.po_no != null && data.po_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.po_date != null && data.po_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                         (data.Buyer_Name != null && data.Buyer_Name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                         (data.supplyingplant_name != null && data.supplyingplant_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                         (data.rec_plant_name != null && data.rec_plant_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.party_name != null && data.party_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_party;
        public string FilterString_party
        {
            get { return _filterString_party; }
            set
            {
                _filterString_party = value;
                RaisePropertyChanged("FilterString_party");
                FilterCollectionParty();
            }
        }
        private void FilterCollectionParty()
        {
            if (_partyCollection != null)
            {
                _partyCollection.Refresh();
            }
        }
        public bool FilterParty(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_party))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_party.ToLower()) ||
                        data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_party.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_uom;
        public string FilterString_uom
        {
            get { return _filterString_uom; }
            set
            {
                _filterString_uom = value;
                RaisePropertyChanged("FilterString_uom");
                FilterCollectionuom();
            }
        }
        private void FilterCollectionuom()
        {
            if (_uomCollection != null)
            {
                _uomCollection.Refresh();
            }
        }
        public bool FilterUom(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_uom))
                {
                    return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterString_uom.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_Buyer;
        public string FilterString_buyer
        {
            get { return _filterString_Buyer; }
            set
            {
                _filterString_Buyer = value;
                RaisePropertyChanged("FilterString_buyer");
                FilterCollectionbuyer();
            }
        }
        private void FilterCollectionbuyer()
        {
            if (_buyerCollection != null)
            {
                _buyerCollection.Refresh();
            }
        }
        public bool FilterBuyer(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Buyer))
                {
                    return (data.EmpLName != null && data.EmpLName.ToString().ToLower().Contains(_filterString_Buyer.ToLower()) ||
                         data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterString_Buyer.ToLower())
                        );
                }
                return true;
            }
            return false;
        }

        private string _filterString_journal;
        public string FilterString_journal
        {
            get { return _filterString_journal; }
            set
            {
                _filterString_journal = value;
                RaisePropertyChanged("FilterString_journal");
                FilterCollection_journal();
            }
        }
        private void FilterCollection_journal()
        {
            if (journalCollection != null)
            {
                journalCollection.Refresh();
            }
        }
        public bool journal_Filter(object obj)
        {
            var data = obj as ACC_M005_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_journal))
                {
                    return (data.j_name != null && data.j_name.ToString().ToLower().Contains(_filterString_journal.ToLower()) ||
                         data.j_code != null && data.j_code.ToString().ToLower().Contains(_filterString_journal.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_payterms;
        public string FilterString_Payterms
        {
            get { return _filterString_payterms; }
            set
            {
                _filterString_payterms = value;
                RaisePropertyChanged("FilterString_Payterms");
                FilterCollectionPayTerm();
            }
        }
        private void FilterCollectionPayTerm()
        {
            if (_paytermCollection != null)
            {
                _paytermCollection.Refresh();
            }
        }
        public bool FilterPayTerms(object obj)
        {
            var data = obj as ACC_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_payterms))
                {
                    return (data.p_term != null && data.p_term.ToString().ToLower().Contains(_filterString_payterms.ToLower()) ||
                        data.p_term_code != null && data.p_term_code.ToString().ToLower().Contains(_filterString_payterms.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_warehouse;
        public string FilterString_Warehouse
        {
            get { return _filterString_warehouse; }
            set
            {
                _filterString_warehouse = value;
                RaisePropertyChanged("FilterString_Warehouse");
                FilterCollectionWarehouse();
            }
        }
        private void FilterCollectionWarehouse()
        {
            if (_warehouseCollection != null)
            {
                _warehouseCollection.Refresh();
            }
        }
        public bool FilterCollectionWarehouse(object obj)
        {
            var data = obj as MM_M002_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_warehouse))
                {
                    return (data.wa_code != null && data.wa_code.ToString().ToLower().Contains(_filterString_warehouse.ToLower()) ||
                       data.wa_name != null && data.wa_name.ToString().ToLower().Contains(_filterString_warehouse.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_doctype;
        public string FilterString_doctype
        {
            get { return _filterString_doctype; }
            set
            {
                _filterString_doctype = value;
                RaisePropertyChanged("FilterString_doctype");
                FilterCollection_doctype();
            }
        }
        private void FilterCollection_doctype()
        {
            if (_doc_typeCollection != null)
            {
                _doc_typeCollection.Refresh();
            }
        }
        public bool doctype_Filter(object obj)
        {
            var data = obj as SYS_M007;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_doctype))
                {
                    return (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterString_doctype.ToLower())) ||
                        (data.doc_desc != null && data.doc_desc.ToString().ToLower().Contains(_filterString_doctype.ToLower())) ||
                         (data.doc_type_user != null && data.doc_type_user.ToString().ToLower().Contains(_filterString_doctype.ToLower()));
                    // || (data.display_doc_type != null && data.display_doc_type.ToString().ToLower().Contains(_filterString_doctype.ToLower()));

                }
                return true;
            }
            return false;
        }

        private string _filterString_currency;
        public string FilterString_currency
        {
            get { return _filterString_currency; }
            set
            {
                _filterString_currency = value;
                RaisePropertyChanged("FilterString_currency");
                FilterCollection_currency();
            }
        }
        private void FilterCollection_currency()
        {
            if (_currencyCollection != null)
            {
                _currencyCollection.Refresh();
            }
        }
        public bool currency_Filter(object obj)
        {
            var data = obj as ADM_M037_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_currency))
                {
                    return (data.curr_code != null && data.curr_code.ToString().ToLower().Contains(_filterString_currency.ToLower())) ||
                       (data.curr_name != null && data.curr_name.ToString().ToLower().Contains(_filterString_currency.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_PurOrg;
        public string FilterString_PurOrg
        {
            get { return _filterString_PurOrg; }
            set
            {
                _filterString_PurOrg = value;
                RaisePropertyChanged("FilterString_PurOrg");
                FilterCollection_PurOrg();
            }
        }
        private void FilterCollection_PurOrg()
        {
            if (po_orgCollection != null)
            {
                po_orgCollection.Refresh();
            }
        }
        public bool Purorg_Filter(object obj)
        {
            var data = obj as ADM_M001_M_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_PurOrg))
                {
                    return (data.po_code != null && data.po_code.ToString().ToLower().Contains(_filterString_PurOrg.ToLower())) ||
                       (data.pur_org != null && data.pur_org.ToString().ToLower().Contains(_filterString_PurOrg.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_pur_grp;
        public string FilterString_pur_grp
        {
            get { return _filterString_pur_grp; }
            set
            {
                _filterString_pur_grp = value;
                RaisePropertyChanged("FilterString_pur_grp");
                FilterCollection_pur_grp();
            }
        }
        private void FilterCollection_pur_grp()
        {
            if (Purchase_groupCollection != null)
            {
                Purchase_groupCollection.Refresh();
            }
        }
        public bool Purchase_grp_Filter(object obj)
        {
            var data = obj as ADM_M001_P_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_pur_grp))
                {
                    return (data.pg_code != null && data.pg_code.ToString().ToLower().Contains(_filterString_pur_grp.ToLower())) ||
                        (data.pg_name != null && data.pg_name.ToString().ToLower().Contains(_filterString_pur_grp.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_storage_loc;
        public string FilterString_storage_loc
        {
            get { return _filterString_storage_loc; }
            set
            {
                _filterString_storage_loc = value;
                RaisePropertyChanged("FilterString_storage_loc");
                FilterCollection_storage_loc();
            }
        }
        private void FilterCollection_storage_loc()
        {
            if (_storage_locCollection != null)
            {
                _storage_locCollection.Refresh();
            }
        }
        public bool storage_loc_Filter(object obj)
        {
            var data = obj as MM_M001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_storage_loc))
                {
                    return (data.store_code != null && data.store_code.ToString().ToLower().Contains(_filterString_storage_loc.ToLower())) ||
                        (data.store_name != null && data.store_name.ToString().ToLower().Contains(_filterString_storage_loc.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_cost_center;
        public string FilterString_cost_center
        {
            get { return _filterString_cost_center; }
            set
            {
                _filterString_cost_center = value;
                RaisePropertyChanged("FilterString_cost_center");
                FilterCollection_cost_center();
            }
        }
        private void FilterCollection_cost_center()
        {
            if (cost_centerCollection != null)
            {
                cost_centerCollection.Refresh();
            }
        }
        public bool cost_center_Filter(object obj)
        {
            var data = obj as ACC_M019_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_cost_center))
                {
                    return (data.cost_center != null && data.cost_center.ToString().ToLower().Contains(_filterString_cost_center.ToLower())) ||
                        (data.cost_center_Desc != null && data.cost_center_Desc.ToString().ToLower().Contains(_filterString_cost_center.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_billaddr;
        public string FilterString_billaddr
        {
            get { return _filterString_billaddr; }
            set
            {
                _filterString_billaddr = value;
                RaisePropertyChanged("FilterString_billaddr");
                FilterCollectionbilladdr();
            }
        }
        private void FilterCollectionbilladdr()
        {
            if (_billAddrCollection != null)
            {
                _billAddrCollection.Refresh();
            }
            else if (_billAddrCollection != null)
            {
                _billAddrCollection.Refresh();
            }

        }
        public bool Filterbilladdr(object obj)
        {
            var data = obj as ADM_M002_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_billaddr))
                {
                    return (data.CompName != null && data.CompName.ToString().ToLower().Contains(_filterString_billaddr.ToLower()) ||
                         data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterString_billaddr.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_deladdr;
        public string FilterString_deladdr
        {
            get { return _filterString_deladdr; }
            set
            {
                _filterString_deladdr = value;
                RaisePropertyChanged("FilterString_deladdr");
                FilterCollectiondeladdr();
            }
        }
        private void FilterCollectiondeladdr()
        {
            if (_delAddrCollection != null)
            {
                _delAddrCollection.Refresh();
            }
            else if (_billAddrCollection != null)
            {
                _billAddrCollection.Refresh();
            }

        }
        public bool Filterdeladdr(object obj)
        {
            var data = obj as ADM_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_deladdr))
                {
                    return (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_deladdr.ToLower()) ||
                        data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_deladdr.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_itemcategory;
        public string FilterString_itemcategory
        {
            get { return _filterString_itemcategory; }
            set
            {
                _filterString_itemcategory = value;
                RaisePropertyChanged("_filterString_itemcategory");
                FilterCollectionitemcategory();
            }
        }
        private void FilterCollectionitemcategory()
        {
            if (_itemcategoryCollection != null)
            {
                _itemcategoryCollection.Refresh();
            }
        }
        public bool Filteritemcategory(object obj)
        {
            var data = obj as SYS_M008_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_itemcategory))
                {
                    return (data.item_cat != null && data.item_cat.ToString().ToLower().Contains(_filterString_itemcategory.ToLower()) ||
                        data.cat_desc != null && data.cat_desc.ToString().ToLower().Contains(_filterString_itemcategory.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _FilterStringValidator;
        public string FilterStringValidator
        {
            get { return _FilterStringValidator; }
            set
            {
                _FilterStringValidator = value;
                RaisePropertyChanged("FilterStringValidator");
                FilterCollectionvalidator();
            }
        }
        private void FilterCollectionvalidator()
        {
            if (_validatedByCollection != null)
            {
                _validatedByCollection.Refresh();
            }
        }
        public bool Filtervalidator(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringValidator))
                {
                    return (data.EmpLName != null && data.EmpLName.ToString().ToLower().Contains(_FilterStringValidator.ToLower()) ||
                        data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_FilterStringValidator.ToLower())
                       );
                }
                return true;
            }
            return false;
        }



        private string _filterString_Item;
        public string FilterString_Item
        {
            get { return _filterString_Item; }
            set
            {
                _filterString_Item = value;
                RaisePropertyChanged("FilterString_Item");
                FilterCollectionItem();
            }
        }
        private void FilterCollectionItem()
        {
            if (_itemCollection != null)
            {
                _itemCollection.Refresh();
            }
        }
        public bool FilterItem(object obj)
        {
            var data = obj as PUR_T002_P_PR_ItemsList;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Item))
                {
                    return (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
                           (data.SubCatCode != null && data.SubCatCode.ToString().ToLower().Contains(_filterString_Item.ToLower())) ||
                            (data.Req_NO != null && data.Req_NO.ToString().ToLower().Contains(_filterString_Item.ToLower())) ||
                            data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_Item.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_scheduleItem;
        public string FilterString_scheduleItem
        {
            get { return _filterString_scheduleItem; }
            set
            {
                _filterString_scheduleItem = value;
                RaisePropertyChanged("_FilterString_scheduleItem");
                FilterCollectionscheduleItem();
            }
        }
        private void FilterCollectionscheduleItem()
        {
            if (_itemCollection != null)
            {
                _itemCollection.Refresh();
            }
        }
        // Pending Issue
        public bool FilterscheduleItem(object obj)
        {
            //var data = obj as PurchaseOrder_deliveryschedule;
            //if (data != null)
            //{
            //    if (!string.IsNullOrEmpty(_filterString_scheduleItem))
            //    {
            //        return (data.item_name != null && data.item_name.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
            //               (data.item_code != null && data.item_code.ToString().ToLower().Contains(_filterString_Item.ToLower())));
            //    }
            //    return true;
            //}
            return false;
        }

        // Pending Integration of FilterString_RefDocNo
        private string _filterString_refdocno;
        public string FilterString_RefDocNo
        {
            get { return _filterString_refdocno; }
            set
            {
                _filterString_refdocno = value;
                RaisePropertyChanged("FilterString_RefDocNo");
                FilterCollectionRefDocNo();
            }
        }
        private void FilterCollectionRefDocNo()
        {
            if (_ReferenceDocCollection != null)
            {
                _ReferenceDocCollection.Refresh();
            }
        }
        public bool FilterRefDocNo(object obj)
        {
            var data = obj as PUR_T002_P_RefeDoc;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_refdocno))
                {
                    if (_filterString_refdocno == "0")
                        _filterString_refdocno = "QP";
                    else if (_filterString_refdocno == "1")
                        _filterString_refdocno = "RF";
                    else if (_filterString_refdocno == "2")
                        _filterString_refdocno = "";

                    return (data.po_no != null && data.po_no.ToString().ToLower().Contains(_filterString_refdocno.ToLower()) ||
                          (data.quotation_no != null && data.quotation_no.ToString().ToLower().Contains(_filterString_refdocno.ToLower())) ||
                           (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_filterString_refdocno.ToLower())) ||
                           (data.party_name != null && data.party_name.ToString().ToLower().Contains(_filterString_refdocno.ToLower())) ||
                           data.partyId != null && data.partyId.ToString().ToLower().Contains(_filterString_refdocno.ToLower()));

                }
                return true;
            }
            return false;
        }

        public bool FilterSupplyingPlant(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_deladdr))
                {
                    return (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_deladdr.ToLower()) ||
                        data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_deladdr.ToLower()));
                }
                return true;
            }
            return false;
        }

        public bool FilterReceivingPlant(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_deladdr))
                {
                    return (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_deladdr.ToLower()) ||
                        data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_deladdr.ToLower()));
                }
                return true;
            }
            return false;
        }


        #region . TaxAccount Filter.
        private string _FilterString_tax;
        public string FilterString_tax
        {
            get { return _FilterString_tax; }
            set
            {
                _FilterString_tax = value;
                RaisePropertyChanged("FilterString_tax");
                FilterCollectiontaxAcc();
            }
        }
        private void FilterCollectiontaxAcc()
        {
            if (_dgPOItemsFortaxval != null)
            {
                _dgPOItemsFortaxval.Refresh();
            }
        }
        public bool FiltertaxAcc(object obj)
        {
            var data = obj as ACC_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_tax))
                {
                    return (data.acc_code != null && data.acc_code.ToString().ToLower().Contains(_FilterString_tax.ToLower())) ||
                           (data.p_name != null && data.p_name.ToString().ToLower().Contains(_FilterString_tax.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        //pending delete if not use
        private void FilterReferenceDocumentNumbers(object InputValue)
        {


        }
        #endregion

        #region DataGrid Functions - Items DataGrid
        private void InsertDataGridRow_Item(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                PUR_T002_P_PR_ItemsList POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = ItemListForPopup.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PUR_T002_P_PR_ItemsList>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = dgItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = dgItemsEntity.IndexOf(dgItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && dgItemsEntity.Count == dgSelectedIndexItem)
                    {
                        dgItemsEntity.Add(new PUR_T002_B()
                        {
                            id = 0,
                            ItemCode = POPUPEntityObject.ItemCode,
                            description = POPUPEntityObject.ItemName,
                            active = true,
                            line_id = 0,
                            location_Id = AppSessionState.location_Id,
                            PartyId = MasterEntity.PartyId,
                            pur_req_no = POPUPEntityObject.Req_NO,
                            pur_req_item = POPUPEntityObject.Pur_Req_Item_id,
                            qty = POPUPEntityObject.Req_Approve_qty,
                            quotation_no = MasterEntity.quotation_no,
                            ref_doc_no = MasterEntity.ref_doc_no,
                            ref_doc_type = MasterEntity.ref_doc_type,
                            sku = POPUPEntityObject.sku,
                            sku_desc = POPUPEntityObject.sku_desc,
                            tax_id = POPUPEntityObject.tax_id,
                            unit_code = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM,
                            unit_price = POPUPEntityObject.b_rate,
                            comp_code = AppSessionState.comp_code,
                            item_cat = POPUPEntityObject.item_cat,
                            t_status = "Draft"
                        });
                    }
                    else if (dgSelectedIndexItem >= 0 && dgItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (dgItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            dgItemsEntity[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
                            dgItemsEntity[dgSelectedIndexItem].description = POPUPEntityObject.ItemName;
                            dgItemsEntity[dgSelectedIndexItem].active = true;
                            dgItemsEntity[dgSelectedIndexItem].line_id = 0;
                            dgItemsEntity[dgSelectedIndexItem].pur_req_no = POPUPEntityObject.Req_NO;
                            dgItemsEntity[dgSelectedIndexItem].PartyId = MasterEntity.PartyId;
                            dgItemsEntity[dgSelectedIndexItem].qty = POPUPEntityObject.Req_Approve_qty;
                            dgItemsEntity[dgSelectedIndexItem].quotation_no = MasterEntity.quotation_no;
                            dgItemsEntity[dgSelectedIndexItem].ref_doc_no = MasterEntity.ref_doc_no;
                            dgItemsEntity[dgSelectedIndexItem].ref_doc_type = MasterEntity.ref_doc_type;
                            dgItemsEntity[dgSelectedIndexItem].sku = POPUPEntityObject.sku;
                            dgItemsEntity[dgSelectedIndexItem].sku_desc = POPUPEntityObject.sku_desc;
                            dgItemsEntity[dgSelectedIndexItem].tax_id = POPUPEntityObject.tax_id;
                            dgItemsEntity[dgSelectedIndexItem].unit_code = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM;
                            dgItemsEntity[dgSelectedIndexItem].unit_price = POPUPEntityObject.b_rate;
                            dgItemsEntity[dgSelectedIndexItem].item_cat = POPUPEntityObject.item_cat;
                        }
                        else if (dgItemsEntity[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            dgItemsEntity[dgSelectedIndexItem].ItemCode = "";
                            dgItemsEntity[dgSelectedIndexItem].description = "";
                        }
                    }
                }
                #region Clear Empty Row
                PUR_T002_B newObj = new PUR_T002_B();
                for (int i = dgItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = dgItemsEntity[i].ComparePropertiesTo(newObj);
                    if (dgItemsEntity[i].ComparePropertiesTo(newObj) == true && dgItemsEntity.Count > 1)
                    {
                        dgItemsEntity.RemoveAt(i);
                        if (dgItemsEntity.Count == 0)
                        {
                            dgItemsEntity.Add(newObj);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }

        }
        private void InsertDataGridRow_UOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                //AppSessionState.StringListValue = StringListUOM;
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.unitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = dgItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = dgItemsEntity.IndexOf(dgItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && dgItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (dgItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            dgItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (dgItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                        {
                            dgItemsEntity[dgSelectedIndexItem].unit_code = "";
                        }
                    }
                }
                #region Clear Empty Row
                PUR_T002_B newObj = new PUR_T002_B();
                for (int i = dgItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = dgItemsEntity[i].ComparePropertiesTo(newObj);
                    if (dgItemsEntity[i].ComparePropertiesTo(newObj) == true && dgItemsEntity.Count > 1)
                    {
                        dgItemsEntity.RemoveAt(i);
                        if (dgItemsEntity.Count == 0)
                        {
                            dgItemsEntity.Add(newObj);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (dgItemsEntity.Count > i)
                {
                    dgItemsEntity.RemoveAt(i);
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }

        private void DeleteTax(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (TotalDocumentTaxes.Count > i)
                {
                    //TotalDocumentTaxes.Remove(TotalDocumentTaxes.Where(x => x.tax_name == TotalDocumentTaxes[i].tax_name).Single());
                    List<ACC_T006_B> copyLocal = new List<ACC_T006_B>();
                    copyLocal = TotalDocumentTaxes.ToList();
                    foreach (var tax in copyLocal)
                    {
                        if (tax.tax_name == TotalDocumentTaxes[i].tax_name && tax.manual == "Manual")
                        {
                            TotalDocumentTaxes.Remove(tax);
                        }
                    }
                    TaxComputation(true);
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void DeleteDataGridRow_ItemSchedule(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (dgItemScheduleEntity.Count > i)
                {
                    dgItemScheduleEntity.RemoveAt(i);
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void InsertManualTaxChangedCommand(object InputValue)
        {
            TaxComputation(true);
        }
        private void InsertDataGridRow_ItemCategory(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                SYS_M008_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.itemcatList.Where(x => x.item_cat.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SYS_M008_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M008_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = dgItemsEntity.Where(X => X.item_cat == POPUPEntityObject.item_cat).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = dgItemsEntity.IndexOf(dgItemsEntity.Where(X => X.item_cat == POPUPEntityObject.item_cat).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && dgItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (dgItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            dgItemsEntity[dgSelectedIndexItem].item_cat = POPUPEntityObject.item_cat;
                        }
                        else if (dgItemsEntity[dgSelectedIndexItem].item_cat != POPUPEntityObject.item_cat)
                        {
                            dgItemsEntity[dgSelectedIndexItem].item_cat = "";
                        }
                    }
                }
                #region Clear Empty Row
                PUR_T002_B newObj = new PUR_T002_B();
                for (int i = dgItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = dgItemsEntity[i].ComparePropertiesTo(newObj);
                    if (dgItemsEntity[i].ComparePropertiesTo(newObj) == true && dgItemsEntity.Count > 1)
                    {
                        dgItemsEntity.RemoveAt(i);
                        if (dgItemsEntity.Count == 0)
                        {
                            dgItemsEntity.Add(newObj);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void InsertDataGridRow_ItemSchedule(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                PUR_T002_B POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = dgItemsEntity.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PUR_T002_B>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = dgItemScheduleEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = dgItemScheduleEntity.IndexOf(dgItemScheduleEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                    var FilteredScheduled = (from o in dgItemScheduleEntity where o.ItemCode == dgItemsEntity[dgSelectedIndexItem].ItemCode && o.id == dgItemsEntity[dgSelectedIndexItem].id && o.sku == dgItemsEntity[dgSelectedIndexItem].sku select o).ToList(); //Filter Count (Identification of New Blank Row) : Count of scheduled records for selected item of Item DataGrid. It should be equal to the Selected Index of the Schedule DataGrid to indicate the cursor on the new row of DataGrid..
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && dgItemScheduleEntity.Count == dgSelectedIndexItemSchedule)
                    {
                        dgItemScheduleEntity.Add(new PUR_T004_B()
                        {
                            id = 0,
                            ItemCode = POPUPEntityObject.ItemCode,
                            sku = POPUPEntityObject.sku,
                            active = true,
                            line_id = 0,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            po_no = MasterEntity.po_no,
                            qty = POPUPEntityObject.qty,
                            rate = POPUPEntityObject.unit_price
                        });
                    }
                    else if (dgSelectedIndexItem >= 0 && dgItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (dgItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            dgItemScheduleEntity[dgSelectedIndexItemSchedule].id = 0;
                            dgItemScheduleEntity[dgSelectedIndexItemSchedule].ItemCode = POPUPEntityObject.ItemCode;
                            dgItemScheduleEntity[dgSelectedIndexItemSchedule].sku = POPUPEntityObject.sku;
                            dgItemScheduleEntity[dgSelectedIndexItemSchedule].location_Id = AppSessionState.location_Id;
                            dgItemScheduleEntity[dgSelectedIndexItemSchedule].comp_code = AppSessionState.comp_code;
                            dgItemScheduleEntity[dgSelectedIndexItemSchedule].qty = POPUPEntityObject.qty;
                            dgItemScheduleEntity[dgSelectedIndexItemSchedule].rate = POPUPEntityObject.unit_price;
                        }
                    }
                }
                #region Clear Empty Row
                PUR_T004_B newObj = new PUR_T004_B();
                for (int i = dgItemScheduleEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = dgItemsEntity[i].ComparePropertiesTo(newObj);
                    if (dgItemScheduleEntity[i].ComparePropertiesTo(newObj) == true && dgItemScheduleEntity.Count > 1)
                    {
                        dgItemScheduleEntity.RemoveAt(i);
                        if (dgItemScheduleEntity.Count == 0)
                        {
                            dgItemScheduleEntity.Add(newObj);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }

        // FilterScheduleDataGrid : Filter for Schedule Items as per selected item in dgItemsEntity. This filter is work for ObserverableCollection.
        private void FilterScheduleDataGrid()
        {
            try
            {
                if (dgItemScheduleEntity != null && dgItemScheduleEntity.Count > 0 && dgSelectedIndexItem < dgItemScheduleEntity.Count && dgSelectedIndexItem >= 0)
                {
                    DataGridView = CollectionViewSource.GetDefaultView(dgItemScheduleEntity);
                    DataGridView.Filter = adv => ((PUR_T004_B)adv).ItemCode.Equals(dgItemsEntity[dgSelectedIndexItem].ItemCode);
                    DataGridView.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }

        



        #endregion
    }
}
    

