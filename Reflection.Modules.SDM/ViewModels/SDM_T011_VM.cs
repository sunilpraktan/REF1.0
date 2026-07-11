using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Reflection.ReportingServices;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.Presentation.Services.Convertors;
using System.Collections.Specialized;
using Reflection.BusinessEntity.ReflectionSystem;
using System.Reflection;
using System.IO;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.SDM.ViewModels
{
    public class SDM_T011_VM : WorkspaceViewModel<LOG_T001_A>
    {
        #region . Declaration .
        WebServiceRepository<LOG_T001_A> repository = new WebServiceRepository<LOG_T001_A>();
        WebServiceRepository<MM_T001> repositoryMI = new WebServiceRepository<MM_T001>();
        WebServiceRepository<MultipleContext_LOG_T001_A> repositoryM = new WebServiceRepository<MultipleContext_LOG_T001_A>();

        bool blNew = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
        public string ref_doc_cat_vm { get; set; }
        private bool _EntityChangeEnable;
        private bool EntityChangeEnable
        {
            get { return _EntityChangeEnable; }
            set
            {
                if (_EntityChangeEnable != value)
                {
                    _EntityChangeEnable = value; RaisePropertyChanged("EntityChangeEnable");
                }
            }
        }
        private string _scan_source;
        public string Scan_Source
        {
            get { return _scan_source; }
            set
            {
                if (_scan_source != value)
                {
                    _scan_source = value;
                    RaisePropertyChanged("Scan_Source");
                }
            }
        }
        private int _scan_length;
        public int Scan_Length
        {
            get { return _scan_length; }
            set
            {
                if (_scan_length != value)
                {
                    _scan_length = value;
                    RaisePropertyChanged("Scan_Length");
                }
            }
        }

        private bool _batchdatagrid;
        public bool batchdatagrid
        {
            get { return _batchdatagrid; }
            set
            {
                if (_batchdatagrid != value)
                {
                    _batchdatagrid = value;
                    RaisePropertyChanged("batchdatagrid");
                }
            }
        }

        private bool _split;
        public bool split
        {
            get { return _split; }
            set
            {
                if (_split != value)
                {
                    _split = value;
                    RaisePropertyChanged("split");
                }
            }
        }

        private decimal _required_qty;
        public decimal required_qty
        {
            get { return _required_qty; }
            set
            {
                if (_required_qty != value)
                {
                    _required_qty = value;
                    RaisePropertyChanged("required_qty");
                }
            }
        }
        private decimal _packed_qty;
        public decimal packed_qty
        {
            get { return _packed_qty; }
            set
            {
                if (_packed_qty != value)
                {
                    _packed_qty = value;
                    RaisePropertyChanged("packed_qty");
                }
            }
        }
        private decimal _bal_qty;
        public decimal bal_qty
        {
            get { return _bal_qty; }
            set
            {
                if (_bal_qty != value)
                {
                    _bal_qty = value;
                    RaisePropertyChanged("bal_qty");
                }
            }
        }

        private bool _post;
        public bool post
        {
            get { return _post; }
            set
            {
                if (_post != value)
                {
                    _post = value;
                    RaisePropertyChanged("post");
                }
            }
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


        private MultipleContext_LOG_T001_A _MC;
        public MultipleContext_LOG_T001_A MC
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

        MultipleContext_LOG_T001_A MCTemp = new MultipleContext_LOG_T001_A();

        private MultipleContext_LOG_T001_A _MCRefresh;
        public MultipleContext_LOG_T001_A MCRefresh
        {
            get { return _MCRefresh; }
            set
            {
                if (_MCRefresh != value)
                {
                    _MCRefresh = value;

                    RaisePropertyChanged("MCRefresh");
                }
            }
        }

        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set
            {
                if (_barcode != value)
                {
                    _barcode = value;
                    RaisePropertyChanged("barcode");
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

        private STD_REQ_PARA_BE _REQUEST_PARA;
        public STD_REQ_PARA_BE REQUEST_PARA
        {
            get { return _REQUEST_PARA; }
            set
            {
                if (_REQUEST_PARA != value)
                {
                    _REQUEST_PARA = value;

                    RaisePropertyChanged("REQUEST_PARA");
                }
            }
        }

        #endregion

        #region AutoSUggest

        private DataGridCellInfo _cellInfo;
        public DataGridCellInfo CellInfo
        {
            get { return _cellInfo; }
            set
            {
                _cellInfo = value;
                SetAutoTextSource(_cellInfo);
                RaisePropertyChanged("CellInfo");
            }
        }

        private void SetAutoTextSource(DataGridCellInfo dgCellInfo)
        {
            if (dgCellInfo != null)
            {
                var column = dgCellInfo.Column as DataGridColumn;
                if (column != null)
                {
                    string headerName = column.Header.ToString();
                    string SourceName = column.SortMemberPath.ToString();
                    if (SourceName == "batch_no")
                    { ASDefault = ASBatch; }
                    else if (SourceName == "store_code")
                    { ASDefault = ASStore; }
                    else if (SourceName == "location_Id")
                    { ASDefault = ASPlant; }
                    //else if (SourceName == "unit_code")
                    //{ ASDefault = ASUnit; }


                }
            }
        }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _AS_SUPPLIER { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_SUPPLIER
        {
            get { return _AS_SUPPLIER; }
            set
            {
                if (_AS_SUPPLIER != value)
                {
                    _AS_SUPPLIER = value; RaisePropertyChanged("AS_SUPPLIER");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_RECEIVER { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_RECEIVER
        {
            get { return _AS_RECEIVER; }
            set
            {
                if (_AS_RECEIVER != value)
                {
                    _AS_RECEIVER = value; RaisePropertyChanged("AS_RECEIVER");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPlant { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPlant
        {
            get { return _ASPlant; }
            set
            {
                if (_ASPlant != value)
                {
                    _ASPlant = value; RaisePropertyChanged("ASPlant");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASReceivingPlant { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASReceivingPlant
        {
            get { return _ASReceivingPlant; }
            set
            {
                if (_ASReceivingPlant != value)
                {
                    _ASReceivingPlant = value; RaisePropertyChanged("ASReceivingPlant");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASStore { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASStore
        {
            get { return _ASStore; }
            set
            {
                if (_ASStore != value)
                {
                    _ASStore = value; RaisePropertyChanged("ASStore");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDefault { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault
        {
            get { return _ASDefault; }
            set
            {
                if (_ASDefault != value)
                {
                    _ASDefault = value; RaisePropertyChanged("ASDefault");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBatch { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBatch
        {
            get { return _ASBatch; }
            set
            {
                if (_ASBatch != value)
                {
                    _ASBatch = value; RaisePropertyChanged("ASBatch");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASShipToParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASShipToParty
        {
            get { return _ASShipToParty; }
            set
            {
                if (_ASShipToParty != value)
                {
                    _ASShipToParty = value; RaisePropertyChanged("ASShipToParty");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASTransporter { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTransporter
        {
            get { return _ASTransporter; }
            set
            {
                if (_ASTransporter != value)
                {
                    _ASTransporter = value; RaisePropertyChanged("ASTransporter");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASTUOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUOM
        {
            get { return _ASTUOM; }
            set
            {
                if (_ASTUOM != value)
                {
                    _ASTUOM = value; RaisePropertyChanged("ASUOM");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASWTTUOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWTUOM
        {
            get { return _ASWTTUOM; }
            set
            {
                if (_ASWTTUOM != value)
                {
                    _ASWTTUOM = value; RaisePropertyChanged("ASWTUOM");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASTUOMVOL { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUOMVOL
        {
            get { return _ASTUOMVOL; }
            set
            {
                if (_ASTUOMVOL != value)
                {
                    _ASTUOMVOL = value; RaisePropertyChanged("ASUOMVOL");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASTRMode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTRMode
        {
            get { return _ASTRMode; }
            set
            {
                if (_ASTRMode != value)
                {
                    _ASTRMode = value; RaisePropertyChanged("ASTRMode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASStatus { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASStatus
        {
            get { return _ASStatus; }
            set
            {
                if (_ASStatus != value)
                {
                    _ASStatus = value; RaisePropertyChanged("ASStatus");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCF_Agent { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCF_Agent
        {
            get { return _ASCF_Agent; }
            set
            {
                if (_ASCF_Agent != value)
                {
                    _ASCF_Agent = value; RaisePropertyChanged("ASCF_Agent");
                }
            }
        }

        #endregion

        #region LOG_T001_A
        private LOG_T001_A _MasterEntity;
        public LOG_T001_A MasterEntity
        {
            get
            {
                this.ErrorExist = _MasterEntity.HasErrors;
                return _MasterEntity;
            }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    //        this.ErrorExist = _SelectedLOG_T001_A.HasErrors;
                    RaisePropertyChanged("MasterEntity");
                    value.BeginEdit();
                }
            }
        }

        private ObservableCollection<LOG_T001_B> _ItemsEntity;
        public ObservableCollection<LOG_T001_B> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }
        private LOG_T001_B _SelectedItemsEntity;
        public LOG_T001_B SelectedItemsEntity
        {
            get { return _SelectedItemsEntity; }
            set
            {
                if (_SelectedItemsEntity != value)
                {
                    _SelectedItemsEntity = value;
                    RaisePropertyChanged("SelectedItemsEntity");
                    FilterBatchDataGrid();
                    if (SelectedTabIndex == 1)
                    {
                        TabItemSelectionChanged(SelectedTabIndex);
                    }
                }
            }
        }
        private ObservableCollection<LOG_T001_C> _ItemBatchEntity;
        public ObservableCollection<LOG_T001_C> ItemBatchEntity
        {
            get { return _ItemBatchEntity; }
            set
            {
                if (_ItemBatchEntity != value)
                {
                    _ItemBatchEntity = value;
                    _ItemBatchEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyBatchGrid);
                    RaisePropertyChanged("ItemBatchEntity");
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
                    FilterBatchDataGrid();
                }
            }
        }
        private int _batchsplitSelectedIndex;
        public int batchsplitSelectedIndex
        {
            get
            {
                return _batchsplitSelectedIndex;
            }
            set
            {
                if (_batchsplitSelectedIndex != value)
                {
                    _batchsplitSelectedIndex = value;
                    RaisePropertyChanged("batchsplitSelectedIndex");
                }
            }
        }
        private int _SelectedTabIndex;
        public int SelectedTabIndex
        {
            get
            {
                return _SelectedTabIndex;
            }
            set
            {
                if (_SelectedTabIndex != value)
                {
                    _SelectedTabIndex = value;
                    RaisePropertyChanged("SelectedTabIndex");
                    if (SelectedTabIndex == 1)
                    {
                        TabItemSelectionChanged(SelectedTabIndex);
                    }
                }
            }
        }
        #endregion

        #region Dictionary for ComboList
        private Dictionary<string, object> _PrintOptionDictionary;
        public Dictionary<string, object> PrintOptionDictionary
        {
            get { return _PrintOptionDictionary; }
            set
            {
                if (_PrintOptionDictionary != value)
                {
                    _PrintOptionDictionary = value;
                    RaisePropertyChanged("PrintOptionDictionary");
                }
            }
        }

        #endregion

        #region Matrial Issue Object
        // Used For Goods Posting
        private MM_T001 _ObjectMM_T001;
        public MM_T001 ObjectMM_T001
        {
            get
            {
                return _ObjectMM_T001;
            }
            set
            {
                if (_ObjectMM_T001 != value)
                {
                    _ObjectMM_T001 = value;
                    RaisePropertyChanged("ObjectMM_T001");
                }
            }
        }

        private List<MM_T001_A> _ObjectMM_T001_A;
        public List<MM_T001_A> ObjectMM_T001_A
        {
            get { return _ObjectMM_T001_A; }
            set
            {
                if (_ObjectMM_T001_A != value)
                {
                    _ObjectMM_T001_A = value;

                    RaisePropertyChanged("ObjectMM_T001_A");

                }
            }
        }

        private List<MM_T001_B> _ObjectMM_T001_B;
        public List<MM_T001_B> ObjectMM_T001_B
        {
            get { return _ObjectMM_T001_B; }
            set
            {
                if (_ObjectMM_T001_B != value)
                {
                    _ObjectMM_T001_B = value;

                    RaisePropertyChanged("ObjectMM_T001_B");
                }
            }
        }

        #endregion

        #region . ICollectionView .
        private ICollectionView _FlipDeliveryNoteCollection;
        public ICollectionView FlipDeliveryNoteCollection
        {
            get { return _FlipDeliveryNoteCollection; }
            set
            {
                _FlipDeliveryNoteCollection = value;
                RaisePropertyChanged("FlipDeliveryNoteCollection");
            }
        }

        private ICollectionView _ReportDataCollection;
        public ICollectionView ReportDataCollection
        {
            get { return _ReportDataCollection; }
            set { _ReportDataCollection = value; RaisePropertyChanged("ReportDataCollection"); }
        }

        private ICollectionView _DataGridView;
        public ICollectionView DataGridView
        {
            get { return _DataGridView; }
            set
            {
                _DataGridView = value;
                RaisePropertyChanged("DataGridView");
            }
        }

        private ICollectionView _ReferenceDocSOCollection;
        public ICollectionView ReferenceDocSOCollection
        {
            get { return _ReferenceDocSOCollection; }
            set { _ReferenceDocSOCollection = value; RaisePropertyChanged("ReferenceDocSOCollection"); }
        }
        private ICollectionView _ReferenceDocMOCollection;
        public ICollectionView ReferenceDocMOCollection
        {
            get { return _ReferenceDocMOCollection; }
            set { _ReferenceDocMOCollection = value; RaisePropertyChanged("ReferenceDocMOCollection"); }
        }
        private ICollectionView _ReferenceDocTOCollection;
        public ICollectionView ReferenceDocTOCollection
        {
            get { return _ReferenceDocTOCollection; }
            set { _ReferenceDocTOCollection = value; RaisePropertyChanged("ReferenceDocTOCollection"); }
        }
        private ICollectionView _ReferenceDoc_TO_Item_Collection;
        public ICollectionView ReferenceDoc_TO_Item_Collection
        {
            get { return _ReferenceDoc_TO_Item_Collection; }
            set { _ReferenceDoc_TO_Item_Collection = value; RaisePropertyChanged("ReferenceDoc_TO_Item_Collection"); }
        }
        private ICollectionView _ReferenceDocSDCollection;
        public ICollectionView ReferenceDocSDCollection
        {
            get { return _ReferenceDocSDCollection; }
            set { _ReferenceDocSDCollection = value; RaisePropertyChanged("ReferenceDocSDCollection"); }
        }
        private ICollectionView _HUCollection;
        public ICollectionView HUCollection
        {
            get { return _HUCollection; }
            set { _HUCollection = value; RaisePropertyChanged("HUCollection"); }
        }
        private ICollectionView _ReferenceDocPOCollection;
        public ICollectionView ReferenceDocPOCollection
        {
            get { return _ReferenceDocPOCollection; }
            set { _ReferenceDocPOCollection = value; RaisePropertyChanged("ReferenceDocPOCollection"); }
        }
        private ICollectionView _ReferenceDocDOCollection;
        public ICollectionView ReferenceDocDOCollection
        {
            get { return _ReferenceDocDOCollection; }
            set { _ReferenceDocDOCollection = value; RaisePropertyChanged("ReferenceDocDOCollection"); }
        }
        public List<Order_No_P> _refdoctempa;
        public List<Order_No_P> refdoctempa
        {
            get
            {
                return _refdoctempa;
            }
            set
            {
                _refdoctempa = value;
                RaisePropertyChanged("refdoctempa");
            }
        }
        #endregion

        #region . Relay Command Declaration .
        public RelayCommand<object> cmdViewCurrentStock { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdSupplingPlant { get; private set; }
        public RelayCommand<object> cmdReceivingPlant { get; private set; }
        public RelayCommand<object> cmdStoreLocation { get; private set; }
        public RelayCommand<object> cmdTransporter { get; private set; }
        public RelayCommand<object> cmdTransport_Mode { get; private set; }
        public RelayCommand<object> cmdCF_Agent { get; private set; }
        public RelayCommand<object> cmdUOM { get; private set; }
        public RelayCommand<object> cmdWtUOM { get; private set; }
        public RelayCommand<object> cmdVolUOM { get; private set; }
        public RelayCommand<object> cmdExecuteReferenceDocument { get; private set; }
        public RelayCommand<object> ActiveInActiveChangeCommand { get; private set; }
        public RelayCommand<object> DataGridRowDeleteCommand { get; private set; }
        public RelayCommand<object> BatchDataGridRowDeleteCommand { get; private set; }
        public RelayCommand<IList> cmdLoadDocumentFromBackFlip { get; private set; }
        public RelayCommand<IList> cmdItemRowSelectionChanged { get; private set; }
        public RelayCommand<object> cmdInsertBatch { get; private set; }
        public RelayCommand<object> cmdInsertBatchForBatchGridItem { get; private set; }
        public RelayCommand<string> cmdBarcode { get; private set; }
        public RelayCommand PostBtnClickCommand { get; private set; }
        public RelayCommand ReportCommandPackingList { get; private set; }
        public RelayCommand BatchSplitClick { get; private set; }
        public RelayCommand WeightAndVolumeCalculationCommand { get; private set; }
        public RelayCommand WeightCalculationCommandC { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> cmdReportData { get; private set; }
        public RelayCommand<object> CommandLoadHistory { get; private set; }
        public RelayCommand<object> CmdAddSelectedRef { get; private set; }
        public RelayCommand<object> cmdReferenceSelection { get; private set; }
        public RelayCommand<object> cmdExecuteBatchInsert { get; private set; }
        public RelayCommand cmdExportJSONFile { get; private set; }
        public RelayCommand<object> cmdTabSelectionChanged { get; private set; }
        #endregion

        #region . Constructor .
        public SDM_T011_VM(string doc_cat, string ts_code) : base()
        {
            PrintOptionDictionary = new Dictionary<string, object>();
            PrintOptionDictionary.Add("Original for Recipient", "Original for Recipient");
            PrintOptionDictionary.Add("Duplicate for Supplier/Transporter", "Duplicate for Supplier/Transporter");
            PrintOptionDictionary.Add("Triplicate for Supplier", "Triplicate for Supplier");
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            LOG_T001_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            MasterEntity = new LOG_T001_A();
            MC = new MultipleContext_LOG_T001_A();
            MCRefresh = new MultipleContext_LOG_T001_A();
            MCTemp = new MultipleContext_LOG_T001_A();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            ItemsEntity = new ObservableCollection<LOG_T001_B>();
            ItemBatchEntity = new ObservableCollection<LOG_T001_C>();
            SelectedItemsEntity = new LOG_T001_B();
            LOG_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            LOG_T001_C.ModelEntityUpdated += new EventHandler(ModelUpdated_Batch);
            MasterEntity.ValidateAsync().Wait();
            CommandInitialization();
            LoadInitialData(doc_cat, null);
        }
        public SDM_T011_VM(string doc_cat, string ts_code, string doc_no) : base()
        {
            PrintOptionDictionary = new Dictionary<string, object>();
            PrintOptionDictionary.Add("Original for Recipient", "Original for Recipient");
            PrintOptionDictionary.Add("Duplicate for Supplier/Transporter", "Duplicate for Supplier/Transporter");
            PrintOptionDictionary.Add("Triplicate for Supplier", "Triplicate for Supplier");
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            this.doc_cat_vm = doc_cat;
            LOG_T001_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            MasterEntity = new LOG_T001_A();
            MC = new MultipleContext_LOG_T001_A();
            MCRefresh = new MultipleContext_LOG_T001_A();
            MCTemp = new MultipleContext_LOG_T001_A();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            ItemsEntity = new ObservableCollection<LOG_T001_B>();
            ItemBatchEntity = new ObservableCollection<LOG_T001_C>();
            SelectedItemsEntity = new LOG_T001_B();
            //TransporterParty = new List<ADM_M028_P>();
            LOG_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            LOG_T001_C.ModelEntityUpdated += new EventHandler(ModelUpdated_Batch);
            MasterEntity.ValidateAsync().Wait();
            CommandInitialization();
            LoadInitialData(doc_cat, null);
        }
        public SDM_T011_VM(string doc_cat, string ts_code, string doc_no, string ReferenceDoc) : base()
        {
            PrintOptionDictionary = new Dictionary<string, object>();
            PrintOptionDictionary.Add("Original for Recipient", "Original for Recipient");
            PrintOptionDictionary.Add("Duplicate for Supplier/Transporter", "Duplicate for Supplier/Transporter");
            PrintOptionDictionary.Add("Triplicate for Supplier", "Triplicate for Supplier");
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            this.doc_cat_vm = doc_cat;
            this.ref_doc_cat_vm = ReferenceDoc;
            LOG_T001_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            MasterEntity = new LOG_T001_A();
            MC = new MultipleContext_LOG_T001_A();
            MCRefresh = new MultipleContext_LOG_T001_A();
            MCTemp = new MultipleContext_LOG_T001_A();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            ItemsEntity = new ObservableCollection<LOG_T001_B>();
            ItemBatchEntity = new ObservableCollection<LOG_T001_C>();
            SelectedItemsEntity = new LOG_T001_B();
            //TransporterParty = new List<ADM_M028_P>();
            LOG_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            LOG_T001_C.ModelEntityUpdated += new EventHandler(ModelUpdated_Batch);
            MasterEntity.ValidateAsync().Wait();
            CommandInitialization();
            //LoadInitialData(doc_cat, ReferenceDoc);
        }

        #endregion

        #region . User Defined Functions .
        private void DefaultValues(string doc_cat_info)
        {
            try
            {
                EntityChangeEnable = true;
                post = true;
                blNew = true;
                post = true;
                batchdatagrid = false;
                MasterEntity.doc_cat = this.doc_cat_vm;
                MasterEntity.EmpId = AppSessionState.EmpId;
                MasterEntity.EmpName = AppSessionState.EmpName;
                MasterEntity.goods_issue = false;
                MasterEntity.lang_key = AppSessionState.UserLanguage;
                MasterEntity.pick_date = DateTime.Now;
                MasterEntity.pick_time = DateTime.Now.ToShortTimeString();
                MasterEntity.del_time = DateTime.Now.ToShortTimeString();
                MasterEntity.t_status = (from o in MC.t_statusList where o.ind_default == "1" select o.t_status).FirstOrDefault();
                MasterEntity.t_display = (from o in MC.t_statusList where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
                DateTime d = DateTime.UtcNow;
                d = d.AddMonths(-1);
                REQUEST_PARA.from_date = d;
                REQUEST_PARA.to_date = DateTime.UtcNow;
                REQUEST_PARA.active = true;

                // 16-02-2023 Now Commeted as we have fixed it with party master
                //if (doc_cat_info == "DT")// if P2P only ************* Change ********************
                //{
                //    MasterEntity.PartyId = MasterEntity.rec_plant; // old comment: we have to set this values as it is compulsory and in future we will have to add plant as party and assign plant to that party to process P2P transfer process.
                //    MasterEntity.ship_to_party = MasterEntity.rec_plant;
                //}
                //else // if Outbound Delivery ************* Change ********************
                //{
                //}

                //PrintOptionDictionary = new Dictionary<string, object>();
                //PrintOptionDictionary.Add("Original for Recipient", "Original for Recipient");
                //PrintOptionDictionary.Add("Duplicate for Supplier/Transporter", "Duplicate for Supplier/Transporter");
                //PrintOptionDictionary.Add("Triplicate for Supplier", "Triplicate for Supplier");
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        private void Logging()
        {
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;

            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;

            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
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
        private void ViewCurrentStock(object InputValue)
        {
            try
            {
                ReflectionFunctionService objRef = new ReflectionFunctionService();
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    AppSessionState.ViewTitle = "Current Stock";
                    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.SCM.dll");
                    Assembly assembly = Assembly.LoadFile(path1);
                    Type type = assembly.GetType("Reflection.Modules.SCM.Views.Current_Stock");
                    if (type != null)
                    {
                        dynamic instance = Activator.CreateInstance(type, "MMI01", InputValue);
                        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                    }
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
                if (doc_no_vm != null && ts_code_vm != null && this.ref_doc_cat_vm == null)
                {
                    EntityChangeEnable = false;
                    LoadDocumentFromDocumentNumber(doc_no_vm);
                    EntityChangeEnable = true;
                }
                else if (doc_no_vm != null && ts_code_vm != null && this.ref_doc_cat_vm != null)
                {
                    EntityChangeEnable = false;
                    LoadInitialData(doc_cat_vm, this.ref_doc_cat_vm);
                    EntityChangeEnable = true;
                }
                else
                {
                    DefaultValues(doc_cat_vm);
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        private void OpenDocumentViewer(object InputValue)
        {
            CursorControl.SetBusyState();
            WebServiceRepository<MultipleContext_Attachments> repository_MCAttachments = new WebServiceRepository<MultipleContext_Attachments>();
            List<COM_T003> Attachments = new List<COM_T003>();
            LOG_T001_B EntityObjectParameter = new LOG_T001_B();
            MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();
            try
            {
                if (InputValue != null)
                {
                    EntityObjectParameter = ((IEnumerable)InputValue).Cast<LOG_T001_B>().ToList()[0];
                }
                //string Request = "GetAllFiles" + "!@" + EntityObjectParameter.ItemCode;
                string Request = "GetAllFiles" + "!@" + AppSessionState.client + "!@" + (EntityObjectParameter.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (EntityObjectParameter.location_Id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@!@!@" + EntityObjectParameter.delivery_no + "!@" + EntityObjectParameter.id.ToString();
                //MCAttachments = repository_MCAttachments.GetData<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Reflection.BusinessLogic.ReflectionFileHandlingServices");
                MCAttachments = repository_MCAttachments.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(EntityObjectParameter.ItemCode))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.delivery_no.Replace("/", "--"), Row_ID = EntityObjectParameter.id.ToString(), DocumentList = MCAttachments.Attachments, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
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
        private void InsertReportData(object InputValue)
        {
            try
            {
                string Request = "";
                Report_Data_P POPUPEntityObject = null;

                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Report_DataList2.Where(x => x.data1.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<Report_Data_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }


                if (POPUPEntityObject != null)
                {
                    MasterEntity.data1 = POPUPEntityObject.data1;
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
        #region Command Parameter Read Section
        #endregion
        private void CommandInitialization()
        {
            #region COMMAND INITIALIZATION

            cmdViewCurrentStock = new RelayCommand<object>(items => { if (items == null) { return; } ViewCurrentStock(items); });
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdTransporter = new RelayCommand<object>(items => { if (items == null) { return; } InsertTransporter(items); });
            cmdTransport_Mode = new RelayCommand<object>(items => { if (items == null) { return; } InsertTransport_Mode(items); });
            cmdCF_Agent = new RelayCommand<object>(items => { if (items == null) { return; } InsertCF_Agent(items); });
            cmdUOM = new RelayCommand<object>(items => { if (items == null) { return; } InsertUOM(items, false, true, true); });
            cmdWtUOM = new RelayCommand<object>(items => { if (items == null) { return; } InsertWtUOM(items, false, true, true); });
            cmdVolUOM = new RelayCommand<object>(items => { if (items == null) { return; } InsertVolUOM(items, false, true, true); });
            cmdStoreLocation = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_StoreLocation(cmdPara, false, true, true); });
            DataGridRowDeleteCommand = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_Item(items); });
            BatchDataGridRowDeleteCommand = new RelayCommand<object>(items => { if (items == null) { return; } DeleteBatchDataGridRow_Item(items); });
            cmdLoadDocumentFromBackFlip = new RelayCommand<IList>(Items => { if (Items == null) { return; } LoadDocumentFromDocumentNumber(Items); });
            cmdItemRowSelectionChanged = new RelayCommand<IList>(Items => { if (Items == null) { return; } ItemRowSelectionChanged(Items); });
            cmdInsertBatch = new RelayCommand<object>(Items => { if (Items == null) { return; } InsertSelectedBatch(Items, false, true, true); });
            cmdInsertBatchForBatchGridItem = new RelayCommand<object>(Items => { if (Items == null) { return; } InsertBatchForBatchGridItem(Items, true, false, true); });
            cmdBarcode = new RelayCommand<string>(Items => { if (Items == null) { return; } ScanBarcode(Items); });
            PostBtnClickCommand = new RelayCommand(() => { Post(); });
            cmdExportJSONFile = new RelayCommand(() => { Export_To_JSON_FILE(); });
            ReportCommandPackingList = new RelayCommand(() => { PackingListReport(); });
            BatchSplitClick = new RelayCommand(() => { BatchSplit(); });
            WeightAndVolumeCalculationCommand = new RelayCommand(() => { CalculateWeightAndVolume(); });
            WeightCalculationCommandC = new RelayCommand(() => { CalculateWeightC(); });
            ActiveInActiveChangeCommand = new RelayCommand<object>(items => { if (items == null) { return; } ItemActiveInActiveMethod(items); });
            cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });
            cmdReportData = new RelayCommand<object>(items => { if (items == null) { return; } InsertReportData(items); });
            CommandLoadHistory = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(); });
            CmdAddSelectedRef = new RelayCommand<object>(items => { if (items == null) { return; } AddSelectedRef(items); });
            cmdReferenceSelection = new RelayCommand<object>(items => { if (items == null) { return; } ReferenceSelection(items); });
            cmdSupplingPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertSendingPlant(items); });
            cmdReceivingPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertRecPlant(items); });
            cmdExecuteReferenceDocument = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteReferenceDocument(items); });
            cmdExecuteBatchInsert = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteBatchInsert(items); });
            cmdTabSelectionChanged = new RelayCommand<object>(items => { if (items == null) { return; } TabItemSelectionChanged(items); });
            #endregion
        }
        private void LoadInitialData(string doc_cat_info, string ReferenceDoc)
        {
            try
            {
                CursorControl.SetBusyState();
                if (doc_cat_info == "DT" && ReferenceDoc == null)
                {
                    string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + this.ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code;
                    //string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id
                    //+ "!@" + MasterEntity.doc_type + "!@" + doc_cat_vm + "!@" + "TO" + "!@" + "ST" + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.client + "!@" + AppSessionState.client;
                    MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MC, Request, "LOG_T001_BL", "SDM", "LoadAll", 0, Request);
                }
                else if (doc_cat_info == "DN" && ReferenceDoc == null)
                {
                    string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + this.ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code;
                    //string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + MasterEntity.doc_type + "!@" + doc_cat_vm
                    //+ "!@" + "" + "!@" + "FD,OD,OC,SC,OR,RE,WR,RC" + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.client;
                    MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MC, Request, "LOG_T001_BL", "SDM", "LoadAll", 0, Request);

                }
                else if (doc_cat_info == "DN" && ReferenceDoc == "DO")
                {
                    string Request = "LoadInitialDataWith_DN_From_Dispatch_Order" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@" + this.doc_no_vm + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + this.ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code;
                    //string Request = "LoadInitialDataWith_DN_From_Dispatch_Order" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + MasterEntity.doc_type + "!@" + doc_cat_vm
                    //+ "!@" + this.doc_no_vm + "!@" + "FD,OD,OC,SC,OR,RE,WR,RC" + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.client;
                    MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MC, Request, "LOG_T001_BL", "SDM", "LoadAll", 0, Request);
                }
                else if (doc_cat_info == "ID" && ReferenceDoc == null) 
                {
                    string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + this.ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code;
                    MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MC, Request, "LOG_T001_BL", "SDM", "LoadAll", 0, Request);
                }

                var refdoctemp = (from o in MC.DocCategoryList where o.doc_type == "DN" || o.doc_type == "DE" || o.doc_type == "FD" select o).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).party_code);
                TheFilter = (o, prefix) => (((STD_PARTY)o).party_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).party_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_SUPPLIER = new AutoSuggestTextViewModel<dynamic>(MC.STD_PLANT_PARTY_LIST, TheFilter, SuggestedValue, "party_code", true);
                AS_SUPPLIER.AutoSuggestVM.IsEmptyValueAllowed = true; AS_SUPPLIER.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).party_code);
                TheFilter = (o, prefix) => (((STD_PARTY)o).party_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).party_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_RECEIVER = new AutoSuggestTextViewModel<dynamic>(MC.STD_PLANT_PARTY_LIST, TheFilter, SuggestedValue, "party_code", true);
                AS_RECEIVER.AutoSuggestVM.IsEmptyValueAllowed = true; AS_RECEIVER.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => ((ADM_M003)o).location_Id.ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPlant = new AutoSuggestTextViewModel<dynamic>((List<ADM_M003>)AppSessionState.ADM_M003_List, TheFilter, SuggestedValue, "location_Id", true);
                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => ((ADM_M003)o).location_Id.ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASReceivingPlant = new AutoSuggestTextViewModel<dynamic>((List<ADM_M003>)AppSessionState.ADM_M003_List, TheFilter, SuggestedValue, "location_Id", true);
                ASReceivingPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M001_P)x).store_code);
                TheFilter = (o, prefix) => ((MM_M001_P)o).store_code.ToLower().Contains(prefix.ToLower()) || (((MM_M001_P)o).store_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASStore = new AutoSuggestTextViewModel<dynamic>(MC.StoreLocList, TheFilter, SuggestedValue, "store_code", "store_code", true);
                ASStore.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTransporter = new AutoSuggestTextViewModel<dynamic>(MC.PartyTranList, TheFilter, SuggestedValue, "PartyId", true);
                ASTransporter.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCF_Agent = new AutoSuggestTextViewModel<dynamic>(MC.PartyTranList, TheFilter, SuggestedValue, "PartyId", true);
                ASCF_Agent.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M026)x).tr_mode);
                TheFilter = (o, prefix) => (((SYS_M026)o).tr_mode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M026)o).tr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTRMode = new AutoSuggestTextViewModel<dynamic>(MC.TransportMode, TheFilter, SuggestedValue, "tr_mode", true);
                ASTRMode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASStatus = new AutoSuggestTextViewModel<dynamic>(MC.t_statusList, TheFilter, SuggestedValue, "t_status", true);
                ASStatus.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUOM = new AutoSuggestTextViewModel<dynamic>(MC.UomList, TheFilter, SuggestedValue, "unit_code", true);
                ASUOM.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASWTUOM = new AutoSuggestTextViewModel<dynamic>(MC.UomList, TheFilter, SuggestedValue, "unit_code", true);
                ASWTUOM.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUOMVOL = new AutoSuggestTextViewModel<dynamic>(MC.UomList, TheFilter, SuggestedValue, "unit_code", true);
                ASUOMVOL.AutoSuggestVM.IsEmptyValueAllowed = true;

                FlipDeliveryNoteCollection = CollectionViewSource.GetDefaultView(MC.FlipGridList);
                FlipDeliveryNoteCollection.Filter = new Predicate<object>(FlipFilter);

                ReportDataCollection = CollectionViewSource.GetDefaultView(MC.Report_DataList2);
                ReportDataCollection.Filter = new Predicate<object>(Filter_ReportData);

                if (doc_cat_info == "DT")
                {
                    ReferenceDocTOCollection = CollectionViewSource.GetDefaultView(MC.OrderList);
                    ReferenceDocTOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                    ReferenceDoc_TO_Item_Collection = CollectionViewSource.GetDefaultView(MC.OrderItems);
                    ReferenceDoc_TO_Item_Collection.Filter = new Predicate<object>(Filter_ReferenceItem);
                }
                else
                {
                    var refdoc = (from o in MC.OrderList where o.doc_cat == "SO" || o.doc_cat == "OP" || o.doc_cat == "SR" select o).ToList();
                    ReferenceDocSOCollection = CollectionViewSource.GetDefaultView(refdoc);
                    ReferenceDocSOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                    refdoc = (from o in MC.OrderList where o.doc_cat == "MO" select o).ToList();

                    ReferenceDocMOCollection = CollectionViewSource.GetDefaultView(refdoc);
                    ReferenceDocMOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                    refdoc = (from o in MC.OrderList where o.doc_cat == "SD" select o).ToList();

                    ReferenceDocSDCollection = CollectionViewSource.GetDefaultView(refdoc);
                    ReferenceDocSDCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                    refdoc = (from o in MC.OrderList where o.doc_cat == "PO" || o.doc_cat == "NP" select o).ToList();

                    ReferenceDocPOCollection = CollectionViewSource.GetDefaultView(refdoc);
                    ReferenceDocPOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                }
                if (MC.SettingsList.Count > 0)
                {
                    Scan_Source = MC.SettingsList[0].scan_source;
                    Scan_Length = MC.SettingsList[0].min_length;
                }
                if (doc_cat_info == "DN" && ReferenceDoc == "DO")
                {
                    MasterEntity = MC.Delivery_Note[0];
                    ItemsEntity = MC.DelNoteItemDetails;
                    foreach (LOG_T001_B item in ItemsEntity)
                    {
                        EPR_T003_A objNew = new EPR_T003_A();
                        item.store_code = item.store_code;
                    }
                    DefaultValues(doc_cat_vm);
                }
                MasterEntity.PrintOption = "";
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

        private void RefreshRefence(string doc_cat_info, string ReferenceDoc)
        {
            try
            {
                CursorControl.SetBusyState();
                if (doc_cat_info == "DT" && ReferenceDoc == null)
                {
                    string Request = "REFRESH_REFERENCE" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + this.ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code;
                    //string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id
                    //+ "!@" + MasterEntity.doc_type + "!@" + doc_cat_vm + "!@" + "TO" + "!@" + "ST" + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.client + "!@" + AppSessionState.client;
                    MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MC, Request, "LOG_T001_BL", "SDM", "LoadAll", 0, Request);
                }
                else if (doc_cat_info == "DN" && ReferenceDoc == null)
                {
                    string Request = "REFRESH_REFERENCE" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + this.ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code;
                    //string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + MasterEntity.doc_type + "!@" + doc_cat_vm
                    //+ "!@" + "" + "!@" + "FD,OD,OC,SC,OR,RE,WR,RC" + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.client;
                    MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MC, Request, "LOG_T001_BL", "SDM", "LoadAll", 0, Request);

                }

                if (doc_cat_info == "DT")
                {
                    ReferenceDocTOCollection = CollectionViewSource.GetDefaultView(MC.OrderList);
                    ReferenceDocTOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                    ReferenceDoc_TO_Item_Collection = CollectionViewSource.GetDefaultView(MC.OrderItems);
                    ReferenceDoc_TO_Item_Collection.Filter = new Predicate<object>(Filter_ReferenceItem);
                }
                else
                {
                    var refdoc = (from o in MC.OrderList where o.doc_cat == "SO" || o.doc_cat == "OP" || o.doc_cat == "SR" select o).ToList();
                    ReferenceDocSOCollection = CollectionViewSource.GetDefaultView(refdoc);
                    ReferenceDocSOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                    refdoc = (from o in MC.OrderList where o.doc_cat == "MO" select o).ToList();

                    ReferenceDocMOCollection = CollectionViewSource.GetDefaultView(refdoc);
                    ReferenceDocMOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                    refdoc = (from o in MC.OrderList where o.doc_cat == "SD" select o).ToList();

                    ReferenceDocSDCollection = CollectionViewSource.GetDefaultView(refdoc);
                    ReferenceDocSDCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                    refdoc = (from o in MC.OrderList where o.doc_cat == "PO" || o.doc_cat == "NP" select o).ToList();

                    ReferenceDocPOCollection = CollectionViewSource.GetDefaultView(refdoc);
                    ReferenceDocPOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
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
        private void InsertSendingPlant(object InputValue)
        {
            try
            {

                string Request = "";
                STD_PARTY POPUPEntityObject = null;
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
                            {
                                POPUPEntityObject = MC.STD_PLANT_PARTY_LIST.Where(x => x.party_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.party_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.location_Id = POPUPEntityObject.location_id;
                    MasterEntity.supplantnm = POPUPEntityObject.party_name;
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
        private void InsertSendingPlantOld(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M003 POPUPEntityObject = null;
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
                            { POPUPEntityObject = ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.location_Id = POPUPEntityObject.location_Id;
                    MasterEntity.supplantnm = POPUPEntityObject.LoctnNm;
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
        private void InsertRecPlant(object InputValue)
        {
            try
            {
                string Request = "";
                STD_PARTY POPUPEntityObject = null;
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
                            {
                                POPUPEntityObject = MC.STD_PLANT_PARTY_LIST.Where(x => x.party_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.party_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.rec_plant = POPUPEntityObject.location_id;
                    MasterEntity.recplantnm = POPUPEntityObject.party_name;
                    MasterEntity.PartyId = POPUPEntityObject.party_code;
                    MasterEntity.ship_to_party = POPUPEntityObject.party_code;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertRecPlantOld2(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
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
                            { POPUPEntityObject = ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.rec_plant = POPUPEntityObject.location_Id;
                    MasterEntity.recplantnm = POPUPEntityObject.LoctnNm;
                    MasterEntity.PartyId = POPUPEntityObject.location_Id;
                    MasterEntity.ship_to_party = POPUPEntityObject.location_Id;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertRecPlantOld(object InputValue) // NOTE: Deprecated  
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
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
                            { POPUPEntityObject = ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.rec_plant = POPUPEntityObject.location_Id;
                    MasterEntity.recplantnm = POPUPEntityObject.LoctnNm;
                    MasterEntity.PartyId = POPUPEntityObject.location_Id;
                    MasterEntity.ship_to_party = POPUPEntityObject.location_Id;
                }
            }
            catch (Exception ex) { }
        }
        // GET details of BackFlip Selected Record
        private void LoadDocumentFromDocumentNumber(object InputValue)
        {
            try
            {
                EntityChangeEnable = false;
                string Request = "";
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<LOG_T001_A_FLIP>().ToList().Count > 0)
                {
                    Request = ((IEnumerable)InputValue).Cast<LOG_T001_A_FLIP>().ToList()[0].delivery_no;
                }
                #endregion

                if (Request != null && Request.Length > 0)
                {
                    Request = "LoadDocumentFromDocumentNumber" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@" + Request + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + this.ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code;
                    //Request = "LoadDocumentWithDocumentNumber" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@!@!@!@" + Request;
                    //Request = "LoadDocumentFromDocumentNumber" + "!@" + Request;
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp, Request, "LOG_T001_BL", "SDM", "LoadDocumentFromDocumentNumber", 0, Request);

                    MasterEntity = MCTemp.Delivery_Note[0];
                    ItemsEntity = MCTemp.DelNoteItemDetails;
                    ItemBatchEntity = MCTemp.ItemBatchDetails;
                    FilterBatchDataGrid();

                    blNew = false;
                    if ((bool)MasterEntity.goods_issue == true)
                    {
                        post = false;
                    }
                    else
                    {
                        post = true;
                    }

                    MasterEntity.ts_code = ts_code_vm;
                    SelectedTabControlIndex = 0;
                    MasterEntity.PrintOption = "";
                }
                EntityChangeEnable = true;
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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

        private void Post()
        {
            try
            {
                CursorControl.SetBusyState();
                if (MasterEntity.delivery_no != null && MasterEntity.delivery_no != "" && ItemsEntity.Count > 0)
                {
                    if (Validation() == true)
                    {
                        IShowMessageViewService showMessageService1 = this.GetViewService<IShowMessageViewService>();
                        showMessageService1.ButtonSetup = DialogButton.Ok;
                        showMessageService1.Caption = "Post : Warning";
                        showMessageService1.Text =
                            String.Format(
                                " You are Not Allowed To Change Posting Date and Delivery Type After Posting Delivery Note..\n Click Ok To Continue Posting Else Click On Cancel  '{0}'",
                                    this.Title);
                        if (showMessageService1.ShowMessage() == DialogResult.Ok)
                        {
                            ObjectMM_T001 = new MM_T001();
                            ObjectMM_T001.comp_code = MasterEntity.comp_code;
                            ObjectMM_T001.doc_date = MasterEntity.goods_issue_date ?? DateTime.Now;
                            ObjectMM_T001.doc_code = "DI";
                            ObjectMM_T001.doc_cat = "DI";
                            ObjectMM_T001.rec_plant = MasterEntity.rec_plant;
                            ObjectMM_T001.sending_plant = MasterEntity.location_Id;
                            ObjectMM_T001.source_doc_cat = MasterEntity.doc_cat;
                            ObjectMM_T001.source_doc_type = MasterEntity.doc_type;
                            ObjectMM_T001.source_doc_no = MasterEntity.delivery_no;
                            ObjectMM_T001.PartyId = MasterEntity.ship_to_party;
                            ObjectMM_T001.post_date = MasterEntity.goods_issue_date ?? DateTime.Now;
                            ObjectMM_T001.bill_ladding = MasterEntity.ladding_bill;
                            ObjectMM_T001.bill_ladding_dt = MasterEntity.ladding_date;
                            ObjectMM_T001.del_note = MasterEntity.delivery_no;
                            ObjectMM_T001.del_note_date = MasterEntity.delivery_date;
                            ObjectMM_T001.receipt_date = DateTime.Now;
                            ObjectMM_T001.tr_mode = MasterEntity.tr_mode;
                            ObjectMM_T001.tr_party = MasterEntity.tr_party;
                            ObjectMM_T001.tranp_agency_name = MasterEntity.transporternm;
                            //ObjectMM_T001.trns_type = MasterEntity.; // Note: similer field not exists yet.
                            ObjectMM_T001.entry_time = DateTime.Now.TimeOfDay;
                            ObjectMM_T001.ref_doc = MasterEntity.delivery_no;
                            ObjectMM_T001.order_doc_type = MasterEntity.ref_doc_type;
                            ObjectMM_T001.order_doc_no = MasterEntity.ref_docno;
                            ObjectMM_T001.ref_doc_date = MasterEntity.delivery_date;
                            //ObjectMM_T001.time_zone = // Note: not yet integrated
                            ObjectMM_T001.mov_tp = (from o in MC.DocCategoryList where o.doc_cat == MasterEntity.doc_cat select o.mov_tp_mi).FirstOrDefault(); //150 Goods Issue for Sale
                            ObjectMM_T001.EmpId = MasterEntity.EmpId;
                            //ObjectMM_T001.dept_code = AppSessionState.d; // Note: not exists
                            ObjectMM_T001.active = true;
                            ObjectMM_T001.add_by = AppSessionState.UserID;
                            ObjectMM_T001.userid = AppSessionState.UserID;
                            ObjectMM_T001.t_status = MasterEntity.t_status; // Note: set proper logic for this doc_cat. do not assign status of other doc_cat.
                            ObjectMM_T001.location_Id = MasterEntity.location_Id;
                            ObjectMM_T001.doc_type = "DI";
                            ObjectMM_T001.curr_code = MasterEntity.curr_code;
                            ObjectMM_T001.amt_doccurr = MasterEntity.net_value;
                            ObjectMM_T001.ex_rate = MasterEntity.exchange_rate;
                            ObjectMM_T001.client = AppSessionState.client;
                            ObjectMM_T001.lang_key = AppSessionState.UserLanguage;
                            //ObjectMM_T001.way_bill_no = MasterEntity.wa;// Note: not exists
                            //ObjectMM_T001.way_bill_date = MasterEntity.wa;// Note: not exists
                            //ObjectMM_T001.way_bill_value = MasterEntity.wa;// Note: not exists
                            ObjectMM_T001.ts_code = (from o in MC.DocCategoryList where o.doc_cat == MasterEntity.doc_cat select o.ts_code_mi).FirstOrDefault();

                            ObjectMM_T001_A = new List<MM_T001_A>();

                            foreach (var item in ItemsEntity)
                            {
                                if (item.active == true)
                                {
                                    ObjectMM_T001_A.Add(new MM_T001_A()
                                    {
                                        line_id = ObjectMM_T001_A.Count() + 1,
                                        comp_code = item.comp_code,
                                        doc_date = MasterEntity.goods_issue_date ?? DateTime.Now,
                                        doc_cat = "DI",
                                        doc_type = "DI",
                                        mov_tp = (from o in MC.DocCategoryList where o.doc_cat == MasterEntity.doc_cat select o.mov_tp_mi).FirstOrDefault(), //150 Goods Issue for Sale
                                        wa_code = item.wa_code,
                                        store_code = item.store_code,
                                        batch_no = item.batch_no,
                                        ItemCode = item.ItemCode,
                                        sku = item.sku,
                                        sku_desc = item.sku_desc,
                                        PartyId = MasterEntity.ship_to_party,
                                        sono = item.sono,
                                        so_item_cd = item.so_item_code,
                                        curr_code = item.curr_code,
                                        qty = item.qty,
                                        challan_qty = item.qty,
                                        unit_code = item.unit_code,
                                        unit_price = item.net_price,
                                        debcr_ind = "D",
                                        source_doc_type = MasterEntity.doc_type,
                                        source_doc_no = MasterEntity.delivery_no,
                                        ref_doc_no = MasterEntity.delivery_no,
                                        ref_doc_type = MasterEntity.doc_type,
                                        order_doc_type = item.ref_doc_type,
                                        order_doc_no = item.order_no,
                                        ref_doc_item_cd = item.ref_doc_item_code,
                                        cost_center = item.cost_center,
                                        profit_center = item.profit_center,
                                        order_no = MasterEntity.order_no,
                                        active = true,
                                        add_by = AppSessionState.UserID,
                                        item_cat = item.item_cat,
                                        item_ok = true,
                                        t_status = MasterEntity.t_status, // Note: set proper logic for this doc_cat. do not assign status of other doc_cat.,
                                        location_Id = item.location_Id,
                                        ri_plant = MasterEntity.rec_plant,
                                        vendor_batch_no = item.batch_no_ven,
                                        ref_item_line_id = item.ref_item_line_id,
                                        bom_no = item.bom_no,
                                        source_doc_itemline_id = item.ref_item_line_id,
                                        order_doc_item_id = item.order_item_row_id,
                                        lang_key = AppSessionState.UserLanguage,
                                        client = AppSessionState.client,
                                        post_date = MasterEntity.goods_issue_date ?? DateTime.Now,
                                        ref_doc_item_row_id = item.ref_item_row_id,
                                        ref_doc_cat = item.ref_doc_cat,
                                        so_item_row_id = item.so_item_row_id,
                                        order_doc_cat = item.order_doc_cat,
                                        dn_item_row_id = item.id,
                                    });

                                    ObjectMM_T001_B = new List<MM_T001_B>();

                                    foreach (var itemBatch in ItemBatchEntity)
                                    {
                                        if (item.active == true && item.id == itemBatch.del_item_row_id)
                                        {
                                            ObjectMM_T001_B.Add(new MM_T001_B()
                                            {
                                                grn_id = 0,
                                                item_line_id = itemBatch.line_id,
                                                ItemCode = itemBatch.ItemCode,
                                                sr_line_no = ObjectMM_T001_A.Count(),
                                                batch_no = itemBatch.batch_no,
                                                qty = itemBatch.qty,
                                                rec_qty = itemBatch.qty,
                                                unit_code = itemBatch.unit_code,
                                                t_status = ObjectMM_T001.t_status,
                                                location_Id = itemBatch.location_Id,
                                                comp_code = itemBatch.comp_code,
                                                wa_code = itemBatch.wa_code,
                                                store_code = itemBatch.store_code,
                                                active = true,
                                                add_by = AppSessionState.UserID,
                                                sku = itemBatch.sku,
                                                client = AppSessionState.client,
                                                ref_batch_row_id = itemBatch.id,
                                                pack_no = itemBatch.pack_no,

                                            });
                                        }
                                    }
                                }
                            }


                            ObjectSerializationService objSer = new ObjectSerializationService();
                            ObjectMM_T001.XmlDataDocument_MM_T001_A = objSer.ObjectToXML(ObjectMM_T001_A);
                            ObjectMM_T001.XmlDataDocument_MM_T001_B = objSer.ObjectToXML(ObjectMM_T001_B);

                            string reader = repositoryMI.Save<MM_T001>(ObjectMM_T001, "LOG_T001_BL_POST", "SDM");

                            int intreader = Convert.ToInt32(reader);

                            if (intreader > 0)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Posting Sucessful", this.Title);
                                showMessageService.ShowMessage();
                                post = false;
                                MasterEntity.goods_issue = true;
                                MasterEntity.t_status = (from o in MC.t_statusList where o.ind_goods_posting == "1" select o.t_display).FirstOrDefault();
                                MasterEntity.t_display = (from o in MC.t_statusList where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
                                MasterEntity.goods_issue = true;
                                MasterEntity.ts_code = ts_code_vm;
                            }
                            else
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Posting Unsuccessful", this.Title);
                                showMessageService.ShowMessage();
                                post = true;
                            }
                        }

                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Goods Posting";
                    showMessageService.Text = String.Format("Not Allowed to Post If Delivery Number is Not generated.\n Please Save the Record First And Then Click on Post \n Also At List 1 Item Must Be Added to Post the Note", this.Title);
                    showMessageService.ShowMessage();
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
        private void Export_To_JSON_FILE()
        {
            try
            {
                CursorControl.SetBusyState();
                ObjectSerializationService objSer = new ObjectSerializationService();
                EWayBill_document billLists = new EWayBill_document();
                EWayBill_itemList itemList = new EWayBill_itemList();
                string Request = "JSON_EXPORT_DN" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.delivery_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + this.ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code;
                //string Request = "JSON_EXPORT_DN" + "!@" + MasterEntity.delivery_no + "!@" + MasterEntity.doc_cat;
                MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp, Request, "LOG_T001_BL", "SDM", "LoadAll", 0, Request);
                IList<EWayBill_document2> billLists2 = new List<EWayBill_document2>();

                foreach (var item in MCTemp.EB_BillLists)
                {
                    EWayBill_document2 billListsObject = new EWayBill_document2();
                    billListsObject.actualFromStateCode = item.actualFromStateCode;
                    billListsObject.actualToStateCode = item.actualToStateCode;
                    billListsObject.cessValue = item.cessValue;
                    billListsObject.cgstValue = item.cgstValue;
                    billListsObject.docDate = item.docDate;
                    billListsObject.docNo = item.docNo;
                    billListsObject.docNo_ewayBill = item.docNo_ewayBill;
                    billListsObject.docType = item.docType;
                    billListsObject.errorCodes = item.errorCodes;
                    billListsObject.ewayBillDate = item.ewayBillDate;
                    billListsObject.ewayBillNo = item.ewayBillNo;
                    billListsObject.ewbNo = item.ewbNo;
                    billListsObject.fromAddr1 = item.fromAddr1;
                    billListsObject.fromAddr2 = item.fromAddr2;
                    billListsObject.fromGstin = item.fromGstin;
                    billListsObject.fromPincode = item.fromPincode;
                    billListsObject.fromPlace = item.fromPlace;
                    billListsObject.fromState = item.fromState;
                    billListsObject.fromStateCode = item.fromStateCode;
                    billListsObject.fromTrdName = item.fromTrdName;
                    billListsObject.igstValue = item.igstValue;
                    billListsObject.mainHsnCode = item.mainHsnCode;
                    billListsObject.OthValue = item.OthValue;
                    billListsObject.sgstValue = item.sgstValue;
                    billListsObject.Status = item.Status;
                    billListsObject.subSupplyType = item.subSupplyType;
                    billListsObject.supplyType = item.supplyType;
                    billListsObject.toAddr1 = item.toAddr1;
                    billListsObject.toAddr2 = item.toAddr2;
                    billListsObject.toGstin = item.toGstin;
                    billListsObject.toPincode = item.toPincode;
                    billListsObject.toPlace = item.toPlace;
                    billListsObject.toStateCode = item.toStateCode;
                    billListsObject.totalValue = item.totalValue;
                    billListsObject.totInvValue = item.totInvValue;
                    billListsObject.TotNonAdvolVal = item.TotNonAdvolVal;
                    billListsObject.toTrdName = item.toTrdName;
                    billListsObject.transDistance = item.transDistance;
                    billListsObject.transDocDate = item.transDocDate;
                    billListsObject.transDocNo = item.transDocNo;
                    billListsObject.transMode = item.transMode;
                    billListsObject.transporterId = item.transporterId;
                    billListsObject.transporterName = item.transporterName;
                    billListsObject.transType = item.transType;
                    billListsObject.tripSheetEwbBills = item.tripSheetEwbBills;
                    billListsObject.userGstin = item.userGstin;
                    billListsObject.vehicleNo = item.vehicleNo;
                    billListsObject.vehicleType = item.vehicleType;

                    billLists2.Add(billListsObject);
                }

                var model = new JsonModel
                {
                    Version = "1.0.1118",

                    billLists = billLists2
                };
                model.billLists[0].itemList = MCTemp.EB_ItemList;
                //var serializerSettings = new JsonSerializerSettings();
                //serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                //var json = JsonConvert.SerializeObject(model, serializerSettings);
                //string path = @"E:\" + MasterEntity.delivery_no.Replace("/", "--") + ".txt";
                //File.WriteAllText(path, json);


                string jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(model, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(@"C:\" + MasterEntity.delivery_no.Replace("/", "--") + ".txt", jsonObject);

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("JESON File exported successfully!", this.Title);
                showMessageService.ShowMessage();
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
        private void InsertTransport_Mode(object InputValue)
        {
            try
            {

                string Request = "";
                SYS_M026 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.TransportMode.Where(x => x.tr_mode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.tr_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<SYS_M026>().ToList().Count > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M026>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.tr_mode = POPUPEntityObject.tr_mode;
                    MasterEntity.shipment_mode = POPUPEntityObject.tr_name;
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
        private void InsertTransporter(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PartyTranList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList().Count > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.tr_party = POPUPEntityObject.PartyId;
                    MasterEntity.transporternm = POPUPEntityObject.PartyNm;
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
        private void InsertCF_Agent(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PartyTranList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.cf_agent_code = POPUPEntityObject.PartyId;
                    MasterEntity.cf_agentnm = POPUPEntityObject.PartyNm;
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

        private void InsertUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        { }
        private void InsertWtUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        { }
        private void InsertVolUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        { }
        private void InsertDataGridRow_StoreLocation(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            MM_M001_P POPUPEntityObject = null;

            #region Command Parameter Read Section
            // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    {
                        POPUPEntityObject = MC.StoreLocList.Where(x => x.store_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                    }
                    catch (Exception ex) { }
                }
            }
            else if (InputValue != null)
            {
                if (((IEnumerable)InputValue).Cast<MM_M001>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M001_P>().ToList()[0];
                }
            }
            if (POPUPEntityObject != null)
            {
                SelectedItemsEntity.store_code = POPUPEntityObject.store_code;
            }
            #endregion
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {
                    //This will get called when the property of an object inside the collection changes
                    if (sender.ToString() == "net_price" || sender.ToString() == "qty")
                    {
                        if (SelectedItemsEntity != null)
                        {
                            SelectedItemsEntity.net_value = SelectedItemsEntity.qty * SelectedItemsEntity.net_price;
                        }
                    }
                    if (sender.ToString() == "net_wt" || sender.ToString() == "gross_wt")
                    {
                        if (ItemsEntity != null && ItemsEntity.Count > 0 && dgSelectedIndex != -1 && dgSelectedIndex < ItemsEntity.Count)
                        {
                            MasterEntity.net_weight = ItemsEntity.Where(x => x.active == true).Sum(x => x.net_wt);
                            MasterEntity.wt_goods = ItemsEntity.Where(x => x.active == true).Sum(x => x.gross_wt);
                        }
                    }
                    if (sender.ToString() == "store_code")
                    {
                        if (SelectedItemsEntity != null)
                        {
                            var BatchTemp = (from o in MC.BatchesList where o.ItemCode == SelectedItemsEntity.ItemCode && (o.sku?.ToString() ?? "") == (SelectedItemsEntity.sku?.ToString() ?? "") && o.store_code == SelectedItemsEntity.store_code select o);
                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_S003_P)x).batch_no);
                            TheFilter = (o, prefix) => ((MM_S003_P)o).batch_no.ToLower().Contains(prefix.ToLower()) || ((MM_S003_P)o).store_code.ToString().Contains(prefix.ToLower());
                            ASBatch = new AutoSuggestTextViewModel<dynamic>(BatchTemp.ToList(), TheFilter, SuggestedValue, "batch_no", true);
                            ASBatch.AutoSuggestVM.IsEmptyValueAllowed = true;
                            if (BatchTemp.ToList().Count > 1)
                            {
                                split = true;   // if there are more than one batch for selected item then only batch split checkbox is allowed to check
                            }
                            else
                            {
                                split = false;
                            }
                            if (SelectedItemsEntity.split_allowed == true)
                            {
                                batchdatagrid = true; // if batch split checkbox is checked then only batchsplit is allowed
                            }
                            else
                            {
                                batchdatagrid = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        void ModelUpdated_Batch(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {
                    //This will get called when the property of an object inside the collection changes
                    if (sender.ToString() == "net_wt" || sender.ToString() == "gross_wt")
                    {
                        if (SelectedItemsEntity != null)// This function not required here as it is shifted to collection change notification section. this call before adding to cllection so function was not working.
                        {
                            decimal? net_wt = 0M;
                            decimal? gross_wt = 0M;
                            foreach (var o in ItemBatchEntity)
                            {
                                if (o.ItemCode == SelectedItemsEntity.ItemCode && o.line_id == SelectedItemsEntity.line_id) //&& !string.IsNullOrWhiteSpace(o.pack_no)
                                {
                                    net_wt = net_wt + o.net_wt;
                                    gross_wt = gross_wt + o.gross_wt;
                                    SelectedItemsEntity.net_wt = net_wt;
                                    SelectedItemsEntity.gross_wt = gross_wt;
                                }
                            }
                        }
                    }
                    if (sender.ToString() == "qty" && SelectedItemsEntity != null) // This function not required here as it is shifted to collection change notification section. this call before adding to cllection so function was not working.
                    {
                        required_qty = SelectedItemsEntity.qty;
                        packed_qty = Convert.ToDecimal(ItemBatchEntity.Where(x => x.line_id == SelectedItemsEntity.line_id).Sum(x => x.qty ?? 0));
                        bal_qty = required_qty - packed_qty;

                    }
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
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && SelectedItemsEntity.id == 0)
                {
                    // First Its Batches Will be removed And then Item  
                    ObservableCollection<LOG_T001_C> BatchTemp = ItemBatchEntity;

                    for (int j = ItemBatchEntity.Count - 1; j >= 0; j--)
                    {
                        if (SelectedItemsEntity.line_id == ItemBatchEntity[j].line_id)
                        {
                            ItemBatchEntity.Remove(ItemBatchEntity[j]);
                        }
                    }
                    ItemsEntity.RemoveAt(i);
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
        private void DeleteBatchDataGridRow_Item(object InputValue)
        {
            try
            {
                if (InputValue != null)
                {
                    LOG_T001_C SelectedBatchlist = new LOG_T001_C();
                    SelectedBatchlist = (LOG_T001_C)InputValue;

                    ItemBatchEntity.Remove(SelectedBatchlist);
                    ObservableCollection<LOG_T001_C> obj = ItemBatchEntity;
                    for (int i = ItemBatchEntity.Count - 1; i >= 0; i--)
                    {
                        if (!string.IsNullOrWhiteSpace(SelectedBatchlist.pack_no) && ItemBatchEntity[i].pack_no == SelectedBatchlist.pack_no)
                        {
                            ItemBatchEntity.RemoveAt(i);
                        }
                    }
                    //foreach (var item in obj)
                    //    {
                    //        if(!string.IsNullOrWhiteSpace(SelectedBatchlist.pack_no) && item.pack_no== SelectedBatchlist.pack_no)
                    //        {
                    //            ItemBatchEntity.Remove(item);
                    //        }
                    //    }
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
        private void ItemActiveInActiveMethod(object InputValue)
        {
            try
            {

                int i = (int)InputValue;
                if (ItemsEntity.Count >= i && ItemsEntity[i].id != 0)
                {
                    if (ItemsEntity[i].active == false)
                    {
                        foreach (var item in ItemBatchEntity)
                        {
                            if (item.ItemCode == ItemsEntity[i].ItemCode && item.sku == ItemsEntity[i].sku && item.active == true)
                            {
                                item.active = false;
                            }
                        }
                    }
                }
                else if (ItemsEntity[i].id == 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Item {0} is Unsaved item. It is Recommanded to Delete This Item rather than inactivating it ", this.Title);
                    showMessageService.ShowMessage();
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
        private void CollectionChangedNotifyBatchGrid(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && ItemsEntity.Count > 0 && SelectedItemsEntity != null) // Schedule can only enable to add if items exists in Items Entity.
            {
                try
                {
                    foreach (LOG_T001_C item in e.NewItems)
                    {
                        item.id = 0;
                        item.ItemCode = SelectedItemsEntity.ItemCode;
                        item.line_id = SelectedItemsEntity.line_id;
                        item.sku = SelectedItemsEntity.sku;
                        item.del_item_row_id = SelectedItemsEntity.id;
                        item.t_status = SelectedItemsEntity.t_status;
                        item.t_display = (from o in MC.t_statusList where o.t_status == item.t_status select o.t_display).FirstOrDefault();
                        item.active = true;
                        item.editby = AppSessionState.UserID;
                        item.location_Id = SelectedItemsEntity.location_Id;
                        item.comp_code = SelectedItemsEntity.comp_code;
                        item.unit_code = SelectedItemsEntity.unit_code;
                        item.client = AppSessionState.client;
                        item.store_code = item.store_code ?? SelectedItemsEntity.store_code;
                        item.gross_wt = item.gross_wt == 0 ? item.net_wt : item.gross_wt;
                    }

                    var groupedData = ItemBatchEntity.GroupBy(p => new { p.pack_no, p.line_id })
                                            .Select(g => new { pack_no = g.Key.pack_no, line_id = g.Key.line_id, stock_total = g.Sum(p => p.qty), count = g.Count() }).Where(x => x.line_id == SelectedItemsEntity.line_id);
                    int count = groupedData.Count();
                    if (count > 0)
                    {
                        SelectedItemsEntity.NoOfPkgs = count;
                    }

                    if (ItemBatchEntity.Count > 0 && SelectedItemsEntity != null)
                    {
                        required_qty = SelectedItemsEntity.qty;
                        packed_qty = Convert.ToDecimal(ItemBatchEntity.Where(x => x.line_id == SelectedItemsEntity.line_id).Sum(x => x.qty ?? 0));
                        bal_qty = required_qty - packed_qty;
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

            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
            }
            if (e.Action == NotifyCollectionChangedAction.Move)
            {

            }

            if (SelectedItemsEntity != null)
            {
                decimal? net_wt = 0M;
                decimal? gross_wt = 0M;
                foreach (var o in ItemBatchEntity)
                {
                    if (o.ItemCode == SelectedItemsEntity.ItemCode && o.line_id == SelectedItemsEntity.line_id) //&& !string.IsNullOrWhiteSpace(o.pack_no)
                    {
                        net_wt = net_wt + o.net_wt;
                        gross_wt = gross_wt + o.gross_wt;
                        SelectedItemsEntity.net_wt = net_wt;
                        SelectedItemsEntity.gross_wt = gross_wt;
                    }
                }

                required_qty = SelectedItemsEntity.qty;
                packed_qty = Convert.ToDecimal(ItemBatchEntity.Where(x => x.line_id == SelectedItemsEntity.line_id).Sum(x => x.qty ?? 0));
                bal_qty = required_qty - packed_qty;
            }
        }
        private void ItemRowSelectionChanged(IList BatchList) // NOTE: Currently not usefull so Avent trigger is commented in xaml.
        {
            IList list = BatchList as IList;
            try
            {
                List<LOG_T001_B> SelectedItemlist = list.Cast<LOG_T001_B>().ToList();
                SelectedItemsEntity = SelectedItemlist[0];
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void TabItemSelectionChanged(object param)
        {
            CursorControl.SetBusyState();
            int TabIndexValue = Convert.ToInt32(param);
            bool ServerTripRequired = true;
            try
            {
                if (TabIndexValue == 1 && EntityChangeEnable == true)
                {
                    if (SelectedItemsEntity != null)
                    {
                        if (MCTemp.HandlingUnitList != null)
                        {
                            if (MCTemp.HandlingUnitList.Count > 0)
                            {
                                if (MCTemp.HandlingUnitList.Where(x => x.ItemCode == SelectedItemsEntity.ItemCode && (x.sku ?? "") == (SelectedItemsEntity.sku ?? "")).ToList().Count > 0)
                                {
                                    ServerTripRequired = false;
                                }
                            }
                        }
                        if (MasterEntity.goods_issue == true)
                        {
                            ServerTripRequired = false;
                        }
                        if (ServerTripRequired == true && !string.IsNullOrWhiteSpace(SelectedItemsEntity.store_code) && !string.IsNullOrWhiteSpace(SelectedItemsEntity.ItemCode))
                        {
                            string Request = "LoadHandlingUnits" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + this.doc_cat_vm + "!@" + MasterEntity.delivery_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + this.ts_code_vm + "!@" + SelectedItemsEntity.sku + "!@" + AppSessionState.sg_code + "!@" + AppSessionState.sg_code + "!@" + SelectedItemsEntity.ItemCode + "!@!@!@!@!@" + SelectedItemsEntity.store_code + "!@" + SelectedItemsEntity.unit_code;
                            //string Request = "LoadHandlingUnits" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + SelectedItemsEntity.ItemCode + "!@" + SelectedItemsEntity.sku + "!@" + SelectedItemsEntity.store_code + "!@" + SelectedItemsEntity.unit_code;
                            MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp, Request, "LOG_T001_BL", "SDM", "LoadHandlingUnits", 0, Request);
                            if (MC.HandlingUnitList.Count > 0)
                            {
                                MC.HandlingUnitList.Clear();
                            }
                            if (MCTemp.HandlingUnitList.Count > 0)
                            {
                                var HUC = MCTemp.HandlingUnitList
                                  .GroupBy(t => new { t.pack_no, t.ItemCode, t.sku, t.unit_code, t.barcode })
                                  .Select(t => new { pack_no = t.Key.pack_no, barcode = t.Key.barcode, t.Key.unit_code, t.Key.ItemCode, t.Key.sku, stock_total = t.Sum(n => n.stock_total), batch_qty = t.Sum(u => u.batch_qty) }) //
                                  .Where(x => x.ItemCode == SelectedItemsEntity.ItemCode && (x.sku ?? "") == (SelectedItemsEntity.sku ?? "")).ToList(); //  && (x.sku ?? "") == (SelectedItemsEntity.sku ?? "")
                                //.Select(t => new { pack_no = t.Key.pack_no, t.Key.pack_qty, unit_code = t.Key.unit_code, t.Key.ItemCode, t.Key.sku, t.Key.location_id, t.Key.comp_code, t.Key.store_code, stock_total = t.Sum(n => n.stock_total), batch_qty = t.Sum(u => u.batch_qty) }) //
                                foreach (var item in HUC)
                                {
                                    MC.HandlingUnitList.Add(new MM_S003_P { pack_no = item.pack_no, barcode = item.barcode, pack_qty = item.batch_qty, unit_code = item.unit_code, ItemCode = item.ItemCode, sku = item.sku, stock_total = item.stock_total, batch_qty = item.batch_qty, Select = false });
                                }
                                HUCollection = CollectionViewSource.GetDefaultView(MC.HandlingUnitList);
                                HUCollection.Refresh();
                            }
                        }
                        else if (ServerTripRequired == true)
                        {
                            IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Select Storage Location", this.Title); sms.ShowMessage();
                            SelectedTabIndex = 0;
                        }
                    }
                    else
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Select Item First", this.Title); sms.ShowMessage();
                        SelectedTabIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                SelectedTabIndex = 0;
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void BatchSplit()
        {
            try
            {
                if (ItemsEntity.Count > 0 && SelectedItemsEntity != null)
                {
                    if (SelectedItemsEntity.split_allowed == true)
                    {
                        batchdatagrid = true; // if batch split checkbox is checked then only batchsplit is allowed
                    }
                    else
                    {
                        batchdatagrid = false;
                    }
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
        // used for batch up on Item Details Tab
        private void InsertSelectedBatch(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                MM_S003_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BatchesList.Where(x => x.batch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<MM_S003_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_S003_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.batch_no == POPUPEntityObject.batch_no).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.batch_no == POPUPEntityObject.batch_no).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && ItemsEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (SelectedItemsEntity.id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            var Batchtemp = (from o in ItemBatchEntity where o.ItemCode == POPUPEntityObject.ItemCode && o.sku == POPUPEntityObject.sku && o.batch_no == POPUPEntityObject.batch_no select o).ToList();

                            if (POPUPEntityObject.stock_total >= SelectedItemsEntity.qty)
                            {
                                if (Batchtemp.Count == 0)
                                {
                                    //SelectedItemsEntity.batch_no = POPUPEntityObject.batch_no;
                                    //SelectedItemsEntity.qty = Convert.ToDecimal(POPUPEntityObject.stock_total);

                                    ItemBatchEntity.Add(new LOG_T001_C()
                                    {
                                        ItemCode = POPUPEntityObject.ItemCode,
                                        batch_no = POPUPEntityObject.batch_no,
                                        pack_no = POPUPEntityObject.batch_no,
                                        store_code = POPUPEntityObject.store_code,
                                        unit_code = POPUPEntityObject.unit_code,
                                        qty = (SelectedItemsEntity.qty) >= POPUPEntityObject.stock_total ? Convert.ToDecimal(POPUPEntityObject.stock_total) : SelectedItemsEntity.qty,
                                        comp_code = SelectedItemsEntity.comp_code,
                                        location_Id = SelectedItemsEntity.location_Id,
                                        client = AppSessionState.client,
                                        add_by = AppSessionState.UserID,
                                        sku = POPUPEntityObject.sku,
                                        active = true,
                                        description = POPUPEntityObject.item_Name,
                                        del_item_row_id = SelectedItemsEntity.id,
                                        line_id = SelectedItemsEntity.line_id,
                                    });
                                }
                                else if (Batchtemp.Count == 1)
                                {
                                    var record = ItemBatchEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode && X.sku == POPUPEntityObject.sku && X.batch_no == POPUPEntityObject.batch_no).FirstOrDefault();
                                    int IndexOfrecord = ItemBatchEntity.IndexOf(ItemBatchEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode && X.sku == POPUPEntityObject.sku && X.batch_no == POPUPEntityObject.batch_no).FirstOrDefault());

                                    ItemBatchEntity[IndexOfrecord].ItemCode = POPUPEntityObject.ItemCode;
                                    ItemBatchEntity[IndexOfrecord].batch_no = POPUPEntityObject.batch_no;
                                    ItemBatchEntity[IndexOfrecord].store_code = SelectedItemsEntity.store_code;
                                    ItemBatchEntity[IndexOfrecord].unit_code = SelectedItemsEntity.unit_code;
                                    ItemBatchEntity[IndexOfrecord].qty = (SelectedItemsEntity.qty) >= POPUPEntityObject.stock_total ? Convert.ToDecimal(POPUPEntityObject.stock_total) : (SelectedItemsEntity.qty);
                                    ItemBatchEntity[IndexOfrecord].comp_code = SelectedItemsEntity.comp_code;
                                    ItemBatchEntity[IndexOfrecord].location_Id = SelectedItemsEntity.location_Id;
                                    ItemBatchEntity[IndexOfrecord].add_by = AppSessionState.UserID;
                                    ItemBatchEntity[IndexOfrecord].sku = POPUPEntityObject.sku;
                                    ItemBatchEntity[IndexOfrecord].active = true;
                                    ItemBatchEntity[IndexOfrecord].client = AppSessionState.client;
                                    ItemBatchEntity[IndexOfrecord].del_item_row_id = SelectedItemsEntity.id;
                                    ItemBatchEntity[IndexOfrecord].line_id = SelectedItemsEntity.line_id;

                                    SelectedItemsEntity.batch_no = POPUPEntityObject.batch_no;
                                    //SelectedItemsEntity.NoOfPkgs = 1;

                                }
                            }
                            else
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Batch Not Selected. Batch Available Quantity {0} is Less than Item Quantity {1}", POPUPEntityObject.stock_total, SelectedItemsEntity.qty);
                                showMessageService.ShowMessage();
                            }
                        }
                        else if (SelectedItemsEntity.batch_no != POPUPEntityObject.batch_no)
                        {
                            SelectedItemsEntity.batch_no = null;
                        }
                    }
                }
                #region Clear Empty Row
                LOG_T001_B newObj = new LOG_T001_B();
                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                    {
                        ItemsEntity.RemoveAt(i);
                        if (ItemsEntity.Count == 0)
                        {
                            ItemsEntity.Add(newObj);
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
        // used for batch popup on batch details tab
        private void InsertBatchForBatchGridItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                MM_S003_P BatchDetails = new MM_S003_P();

                #region Command Parameter Read Section

                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();

                    if (Request.Length > 0)
                    {
                        try
                        {
                            BatchDetails = MC.BatchesList.Where(x => x.batch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; BatchDetails.Select = true;
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<MM_S003_P>().ToList().Count > 0)
                {
                    BatchDetails = ((IEnumerable)InputValue).Cast<MM_S003_P>().ToList()[0];
                }

                #endregion

                if (BatchDetails != null)
                {
                    var InputValueIfExists = ItemBatchEntity.Where(X => X.batch_no == BatchDetails.batch_no).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemBatchEntity.IndexOf(ItemBatchEntity.Where(X => X.batch_no == BatchDetails.batch_no).FirstOrDefault()); // Prefer Primary Key for this instruction.

                    var FilteredBatch = (from o in ItemBatchEntity
                                         where o.ItemCode == SelectedItemsEntity.ItemCode &&
                  o.sku == SelectedItemsEntity.sku && o.line_id == SelectedItemsEntity.line_id
                                         select o).ToList();

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && FilteredBatch.Count == batchsplitSelectedIndex && BatchDetails.Select == true)
                    {

                        ItemBatchEntity.Add(new LOG_T001_C()
                        {
                            ItemCode = BatchDetails.ItemCode,
                            batch_no = BatchDetails.batch_no,
                            pack_no = BatchDetails.batch_no,
                            store_code = BatchDetails.store_code ?? SelectedItemsEntity.store_code,
                            unit_code = BatchDetails.unit_code,
                            qty = SelectedItemsEntity.qty >= BatchDetails.stock_total ? BatchDetails.stock_total : SelectedItemsEntity.qty,
                            comp_code = SelectedItemsEntity.comp_code,
                            location_Id = SelectedItemsEntity.location_Id,
                            add_by = AppSessionState.UserID,
                            sku = BatchDetails.sku,
                            active = true,
                            description = BatchDetails.item_Name,
                            del_item_row_id = SelectedItemsEntity.id,
                            line_id = SelectedItemsEntity.line_id,
                            client = AppSessionState.client

                        });
                    }
                    else if (batchsplitSelectedIndex >= 0 && BatchDetails.Select == true && ItemBatchEntity.Count > batchsplitSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        //if (ItemBatchEntity[batchsplitSelectedIndex].ItemCode == null && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        //{
                        ItemBatchEntity[batchsplitSelectedIndex].ItemCode = BatchDetails.ItemCode;
                        ItemBatchEntity[batchsplitSelectedIndex].batch_no = BatchDetails.batch_no;
                        ItemBatchEntity[batchsplitSelectedIndex].qty = SelectedItemsEntity.qty >= BatchDetails.stock_total ? BatchDetails.stock_total : SelectedItemsEntity.qty;
                        ItemBatchEntity[batchsplitSelectedIndex].store_code = SelectedItemsEntity.store_code;
                        ItemBatchEntity[batchsplitSelectedIndex].comp_code = SelectedItemsEntity.comp_code;
                        ItemBatchEntity[batchsplitSelectedIndex].location_Id = SelectedItemsEntity.location_Id;
                        ItemBatchEntity[batchsplitSelectedIndex].add_by = AppSessionState.UserID;
                        ItemBatchEntity[batchsplitSelectedIndex].unit_code = SelectedItemsEntity.unit_code;
                        ItemBatchEntity[batchsplitSelectedIndex].sku = BatchDetails.sku;
                        ItemBatchEntity[batchsplitSelectedIndex].active = true;
                        ItemBatchEntity[batchsplitSelectedIndex].description = BatchDetails.item_Name;
                        ItemBatchEntity[batchsplitSelectedIndex].del_item_row_id = SelectedItemsEntity.id;
                        ItemBatchEntity[batchsplitSelectedIndex].line_id = SelectedItemsEntity.line_id;
                        ItemBatchEntity[batchsplitSelectedIndex].client = AppSessionState.client;
                        //}
                        //else if (ItemBatchEntity[batchsplitSelectedIndex].batch_no != BatchDetails.batch_no)
                        //{
                        //    ItemBatchEntity[batchsplitSelectedIndex].batch_no = "";
                        //}
                    }
                }

                #region Clear Empty Row

                LOG_T001_C newObj = new LOG_T001_C();
                for (int i = ItemBatchEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemBatchEntity[i].ComparePropertiesTo(newObj);
                    if (ItemBatchEntity[i].ComparePropertiesTo(newObj) && ItemBatchEntity.Count > 1)
                    {
                        ItemBatchEntity.RemoveAt(i);
                        if (ItemBatchEntity.Count == 0)
                        {
                            ItemBatchEntity.Add(newObj);
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
        private void FilterBatchDataGrid()
        {
            try
            {
                if (ItemBatchEntity != null && ItemBatchEntity.Count > 0 && SelectedItemsEntity != null && ItemsEntity != null && ItemsEntity.Count > 0)
                {
                    DataGridView = CollectionViewSource.GetDefaultView(ItemBatchEntity);
                    if ((SelectedItemsEntity.sku ?? null) == null)
                    {
                        DataGridView.Filter = adv => ((LOG_T001_C)adv).ItemCode.Equals(SelectedItemsEntity.ItemCode) && ((LOG_T001_C)adv).line_id.Equals(SelectedItemsEntity.line_id); ;
                    }
                    else
                    {
                        DataGridView.Filter = adv => ((LOG_T001_C)adv).ItemCode.Equals(SelectedItemsEntity.ItemCode) && ((LOG_T001_C)adv).sku.Equals(SelectedItemsEntity.sku) && ((LOG_T001_C)adv).line_id.Equals(SelectedItemsEntity.line_id);
                    }
                    DataGridView.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }
        private void ExecuteReferenceDocument(object items) // pass reference doc selected entiry object as command paramater 
        {
            try
            {
                EntityChangeEnable = true;
                CursorControl.SetBusyState();
                if (items.GetType() == typeof(OrderItemData))
                {
                    OrderItemData objitems = new OrderItemData();
                    objitems = (OrderItemData)items;
                    REQUEST_PARA.doc_cat = objitems.doc_cat;
                }
                else if (items.GetType() == typeof(Order_No_P))
                {
                    Order_No_P objitems2 = new Order_No_P();
                    objitems2 = (Order_No_P)items;
                    REQUEST_PARA.doc_cat = objitems2.doc_cat;
                }

                if (REQUEST_PARA.doc_no == null || REQUEST_PARA.doc_no == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Order Selection";
                    showMessageService.Text = String.Format("Please Select Order No", this.Title);
                    showMessageService.ShowMessage();
                }
                else
                {
                    // string company = AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id.ToString() + "!@" + doc_type_Order + "!@" + MasterEntity.order_no;
                    string Request = "ExecuteReferenceDocument" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + this.doc_cat_vm + "!@" + REQUEST_PARA.doc_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + this.ts_code_vm + "!@" + REQUEST_PARA.doc_cat;
                    //string Request = "ExecuteReferenceDocument" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + items + "!@" + REQUEST_PARA.doc_no + "!@" + AppSessionState.EmpId;

                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp, Request, "LOG_T001_BL", "SDM", "ExecuteReferenceDocument", 0, Request);

                    if (MCTemp.Delivery_Note.Count > 0)
                    {
                        MC.BatchesList = MCTemp.BatchesList;
                        MasterEntity = MCTemp.Delivery_Note[0];
                        ItemsEntity = MCTemp.DelNoteItemDetails;
                        DefaultValues(doc_cat_vm);

                        REQUEST_PARA.doc_cat = doc_cat_vm; // NOTE: remove this, now added just because same  value binded in search popup of View section and it is setting Order doc_cat instead of DN doc_cat. Fiirst make seperate then remove this
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Loading Fail...!!!", this.Title);
                        showMessageService.ShowMessage();
                    }
                }
                EntityChangeEnable = true;
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        private void ExecuteBatchInsert(object items)
        {
            try
            {
                if (MC.HandlingUnitList != null)
                {
                    var FilteredBatch = MCTemp.HandlingUnitList.Where(a => MC.HandlingUnitList.Any(b => b.pack_no == a.pack_no && b.Select == true && a.ItemCode == b.ItemCode && (a.sku ?? "") == (b.sku ?? "") && a.ItemCode == SelectedItemsEntity.ItemCode && (a.sku ?? "") == (SelectedItemsEntity.sku ?? "")));
                    if (FilteredBatch.Count() > 0)
                    {
                        foreach (var item in FilteredBatch)
                        {
                            SelectedItemsEntity.weight_unit = item.weight_unit;
                            SelectedItemsEntity.volume_unit = item.volume_unit;
                            MasterEntity.weight_unit = item.weight_unit;
                            MasterEntity.volume_unit = item.volume_unit;

                            if (ItemBatchEntity.Where(x => x.line_id == SelectedItemsEntity.line_id && x.pack_no == item.pack_no && x.batch_no == item.batch_no && x.location_Id == item.location_id && x.comp_code == item.comp_code && x.store_code == item.store_code).ToList().Count > 0)
                            {
                                int Batchindex = ItemBatchEntity.IndexOf(ItemBatchEntity.Where(X => X.batch_no == item.batch_no && X.pack_no == item.pack_no).FirstOrDefault());
                                //ItemBatchEntity[batchsplitSelectedIndex].delivery_no = SelectedItemsEntity.delivery_no;
                                ItemBatchEntity[Batchindex].ItemCode = SelectedItemsEntity.ItemCode;
                                ItemBatchEntity[Batchindex].sku = SelectedItemsEntity.sku;
                                ItemBatchEntity[Batchindex].pack_no = item.pack_no;
                                ItemBatchEntity[Batchindex].batch_no = item.batch_no;
                                ItemBatchEntity[Batchindex].qty = item.batch_qty; // SelectedItemsEntity.qty >= item.batch_qty ? item.batch_qty : SelectedItemsEntity.qty;
                                ItemBatchEntity[Batchindex].unit_code = item.unit_code;
                                ItemBatchEntity[Batchindex].description = SelectedItemsEntity.Item_desc;
                                ItemBatchEntity[Batchindex].t_status = SelectedItemsEntity.t_status;
                                ItemBatchEntity[Batchindex].location_Id = SelectedItemsEntity.location_Id;
                                ItemBatchEntity[Batchindex].wa_code = SelectedItemsEntity.wa_code;
                                ItemBatchEntity[Batchindex].store_code = (item.store_code ?? SelectedItemsEntity.store_code);
                                ItemBatchEntity[Batchindex].active = SelectedItemsEntity.active;
                                ItemBatchEntity[Batchindex].add_by = AppSessionState.UserID;
                                ItemBatchEntity[Batchindex].editby = AppSessionState.UserID;
                                ItemBatchEntity[Batchindex].comp_code = SelectedItemsEntity.comp_code;
                                ItemBatchEntity[Batchindex].net_wt = item.net_wt;
                                ItemBatchEntity[Batchindex].gross_wt = ((item.gross_wt == 0 || item.gross_wt == null) ? item.net_wt : item.gross_wt);
                                ItemBatchEntity[Batchindex].client = AppSessionState.client;
                                ItemBatchEntity[Batchindex].del_item_row_id = SelectedItemsEntity.id;
                                ItemBatchEntity[Batchindex].line_id = SelectedItemsEntity.line_id;

                            }
                            else //if (batchsplitSelectedIndex >= 0 && BatchDetails.Select == true && ItemBatchEntity.Count > batchsplitSelectedIndex) 
                            {
                                SelectedItemsEntity.split_allowed = true;
                                batchdatagrid = true;
                                split = true;
                                if (ItemBatchEntity.Where(x => x.barcode == item.barcode && x.batch_no == item.batch_no).ToList().Count == 0)
                                {
                                    ItemBatchEntity.Add(new LOG_T001_C()
                                    {
                                        delivery_no = SelectedItemsEntity.delivery_no,
                                        ItemCode = item.ItemCode,
                                        sku = SelectedItemsEntity.sku,
                                        barcode = item.barcode,
                                        pack_no = item.pack_no,
                                        batch_no = item.batch_no,
                                        qty = item.batch_qty, //SelectedItemsEntity.qty >= item.batch_qty ? item.batch_qty : SelectedItemsEntity.qty,
                                        unit_code = item.unit_code,
                                        description = SelectedItemsEntity.Item_desc,
                                        t_status = SelectedItemsEntity.t_status,
                                        location_Id = SelectedItemsEntity.location_Id,
                                        wa_code = SelectedItemsEntity.wa_code,
                                        store_code = (item.store_code ?? SelectedItemsEntity.store_code),
                                        active = SelectedItemsEntity.active,
                                        add_by = AppSessionState.UserID,
                                        comp_code = SelectedItemsEntity.comp_code,
                                        net_wt = item.net_wt,
                                        gross_wt = ((item.gross_wt == 0 || item.gross_wt == null) ? item.net_wt : item.gross_wt),  //item.gross_wt ?? item.net_wt,
                                        client = AppSessionState.client,
                                        del_item_row_id = SelectedItemsEntity.id,
                                        line_id = SelectedItemsEntity.line_id,
                                    });
                                }
                            }
                        }

                        // this is logic for add all weight and volumn in Item Collection only single time per pack no if used carton or barcode scan. 
                        // here we ignore second time encounter of pack no.
                        var hashset = new HashSet<string>();
                        foreach (var hu_item in ItemBatchEntity)
                        {
                            if (!hashset.Add(hu_item.pack_no))
                            {
                                //hu_item.net_wt = 0;
                                //hu_item.gross_wt = 0;
                            }
                        }

                        if (ItemBatchEntity != null)
                        {
                            if (ItemBatchEntity.Count > 0)
                            {
                                var groupedData = ItemBatchEntity.GroupBy(p => new { p.pack_no, p.line_id })
                                            .Select(g => new { pack_no = g.Key.pack_no, line_id = g.Key.line_id, stock_total = g.Sum(p => p.qty), count = g.Count() }).Where(x => x.line_id == SelectedItemsEntity.line_id);
                                int count = groupedData.Count();
                                if (count > 0)
                                {
                                    SelectedItemsEntity.NoOfPkgs = count;
                                }
                                SelectedItemsEntity.container_no = "1 TO " + count.ToString();
                                SelectedItemsEntity.KindOfPkgs = "CARTON BOX " + "1 TO " + count.ToString();

                                CalculateWeightC();
                                CalculateWeightAndVolume();
                            }
                        }
                    }
                    else
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok;
                        sms.Caption = "Message";
                        sms.Text = String.Format("Invalid Scan for Barcode", this.Title);
                        sms.ShowMessage();
                    }
                }
                else
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                    sms.ButtonSetup = DialogButton.Ok;
                    sms.Caption = "Message";
                    sms.Text = String.Format("Packing Data not available for Selected Item", this.Title);
                    sms.ShowMessage();
                }
                barcode = "";
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
        private void ScanBarcode(string InputValue) // Note: Replace this function with Cartoon and Bach_no integration 
        {
            try
            {
                // NOTE: This function is same as Manual Selection of Handling unit in Function "ExecuteBatchInsert" only difference is Barcode in where clause instade of Pack_no. we can make same function for both event.
                string BarcodeValue = InputValue.ToString();
                if (BarcodeValue.Length > 9)
                {
                    if (MC.HandlingUnitList != null)
                    {
                        var FilteredBatch = MCTemp.HandlingUnitList.Where(a => MC.HandlingUnitList.Any(b => b.barcode == a.barcode && b.barcode == BarcodeValue && a.ItemCode == b.ItemCode && (a.sku ?? "") == (b.sku ?? "") && a.ItemCode == SelectedItemsEntity.ItemCode && (a.sku ?? "") == (SelectedItemsEntity.sku ?? "")));
                        if (FilteredBatch.Count() > 0)
                        {
                            foreach (var item in FilteredBatch)
                            {
                                item.Select = true;
                                SelectedItemsEntity.weight_unit = item.weight_unit;
                                SelectedItemsEntity.volume_unit = item.volume_unit;
                                MasterEntity.weight_unit = item.weight_unit;
                                MasterEntity.volume_unit = item.volume_unit;

                                if (ItemBatchEntity.Where(x => x.line_id == SelectedItemsEntity.line_id && x.pack_no == item.pack_no && x.batch_no == item.batch_no && x.location_Id == item.location_id && x.comp_code == item.comp_code && x.store_code == item.store_code).ToList().Count > 0)
                                {
                                    int Batchindex = ItemBatchEntity.IndexOf(ItemBatchEntity.Where(X => X.batch_no == item.batch_no && X.pack_no == item.pack_no).FirstOrDefault());
                                    //ItemBatchEntity[batchsplitSelectedIndex].delivery_no = SelectedItemsEntity.delivery_no;
                                    ItemBatchEntity[Batchindex].ItemCode = SelectedItemsEntity.ItemCode;
                                    ItemBatchEntity[Batchindex].sku = SelectedItemsEntity.sku;
                                    ItemBatchEntity[Batchindex].pack_no = item.pack_no;
                                    ItemBatchEntity[Batchindex].batch_no = item.batch_no;
                                    ItemBatchEntity[Batchindex].qty = item.batch_qty; // SelectedItemsEntity.qty >= item.batch_qty ? item.batch_qty : SelectedItemsEntity.qty;
                                    ItemBatchEntity[Batchindex].unit_code = item.unit_code;
                                    ItemBatchEntity[Batchindex].description = SelectedItemsEntity.Item_desc;
                                    ItemBatchEntity[Batchindex].t_status = SelectedItemsEntity.t_status;
                                    ItemBatchEntity[Batchindex].location_Id = SelectedItemsEntity.location_Id;
                                    ItemBatchEntity[Batchindex].wa_code = SelectedItemsEntity.wa_code;
                                    ItemBatchEntity[Batchindex].store_code = (item.store_code ?? SelectedItemsEntity.store_code);
                                    ItemBatchEntity[Batchindex].active = SelectedItemsEntity.active;
                                    ItemBatchEntity[Batchindex].add_by = AppSessionState.UserID;
                                    ItemBatchEntity[Batchindex].editby = AppSessionState.UserID;
                                    ItemBatchEntity[Batchindex].comp_code = SelectedItemsEntity.comp_code;
                                    ItemBatchEntity[Batchindex].net_wt = item.net_wt;
                                    ItemBatchEntity[Batchindex].gross_wt = ((item.gross_wt == 0 || item.gross_wt == null) ? item.net_wt : item.gross_wt);
                                    ItemBatchEntity[Batchindex].client = AppSessionState.client;
                                    ItemBatchEntity[Batchindex].del_item_row_id = SelectedItemsEntity.id;
                                    ItemBatchEntity[Batchindex].line_id = SelectedItemsEntity.line_id;

                                }
                                else //if (batchsplitSelectedIndex >= 0 && BatchDetails.Select == true && ItemBatchEntity.Count > batchsplitSelectedIndex) 
                                {
                                    SelectedItemsEntity.split_allowed = true;
                                    batchdatagrid = true;
                                    split = true;
                                    if (ItemBatchEntity.Where(x => x.barcode == item.barcode && x.batch_no == item.batch_no).ToList().Count == 0)
                                    {
                                        ItemBatchEntity.Add(new LOG_T001_C()
                                        {
                                            delivery_no = SelectedItemsEntity.delivery_no,
                                            ItemCode = item.ItemCode,
                                            sku = SelectedItemsEntity.sku,
                                            barcode = item.barcode,
                                            pack_no = item.pack_no,
                                            batch_no = item.batch_no,
                                            qty = item.batch_qty, //SelectedItemsEntity.qty >= item.batch_qty ? item.batch_qty : SelectedItemsEntity.qty,
                                            unit_code = item.unit_code,
                                            description = SelectedItemsEntity.Item_desc,
                                            t_status = SelectedItemsEntity.t_status,
                                            location_Id = SelectedItemsEntity.location_Id,
                                            wa_code = SelectedItemsEntity.wa_code,
                                            store_code = (item.store_code ?? SelectedItemsEntity.store_code),
                                            active = SelectedItemsEntity.active,
                                            add_by = AppSessionState.UserID,
                                            comp_code = SelectedItemsEntity.comp_code,
                                            net_wt = item.net_wt,
                                            gross_wt = ((item.gross_wt == 0 || item.gross_wt == null) ? item.net_wt : item.gross_wt),  //item.gross_wt ?? item.net_wt,
                                            client = AppSessionState.client,
                                            del_item_row_id = SelectedItemsEntity.id,
                                            line_id = SelectedItemsEntity.line_id,
                                        });
                                    }
                                }
                            }

                            // this is logic for add all weight and volumn in Item Collection only single time per pack no if used carton or barcode scan. 
                            // here we ignore second time encounter of pack no.
                            var hashset = new HashSet<string>();
                            foreach (var hu_item in ItemBatchEntity)
                            {
                                if (!hashset.Add(hu_item.pack_no))
                                {
                                    //hu_item.net_wt = 0;
                                    //hu_item.gross_wt = 0;
                                }
                            }
                            if (ItemBatchEntity != null)
                            {
                                if (ItemBatchEntity.Count > 0)
                                {
                                    var groupedData = ItemBatchEntity.GroupBy(p => new { p.pack_no, p.line_id })
                                            .Select(g => new { pack_no = g.Key.pack_no, line_id = g.Key.line_id, stock_total = g.Sum(p => p.qty), count = g.Count() }).Where(x => x.line_id == SelectedItemsEntity.line_id);
                                    int count = groupedData.Count();
                                    if (count > 0)
                                    {
                                        SelectedItemsEntity.NoOfPkgs = count;
                                    }
                                    SelectedItemsEntity.container_no = "1 TO " + count.ToString();
                                    SelectedItemsEntity.KindOfPkgs = "CARTON BOX " + "1 TO " + count.ToString();

                                    CalculateWeightC();
                                    CalculateWeightAndVolume();
                                }
                            }
                        }
                        else
                        {
                            IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                            sms.ButtonSetup = DialogButton.Ok;
                            sms.Caption = "Message";
                            sms.Text = String.Format("Invalid Scan for Barcode", this.Title);
                            sms.ShowMessage();
                        }
                    }
                    else
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok;
                        sms.Caption = "Message";
                        sms.Text = String.Format("Packing Data not available for Selected Item", this.Title);
                        sms.ShowMessage();
                    }
                    barcode = "";
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
        private void CalculateWeightC()
        {
            try
            {

                foreach (var o in ItemsEntity)
                {
                    o.net_wt = 0;
                    o.net_wt = Convert.ToDecimal(ItemBatchEntity.Where(x => x.ItemCode == o.ItemCode && (x.sku ?? "") == (o.sku ?? "") && x.line_id == o.line_id && x.active == true).Sum(x => x.net_wt));

                    o.gross_wt = 0;
                    o.gross_wt = Convert.ToDecimal(ItemBatchEntity.Where(x => x.ItemCode == o.ItemCode && (x.sku ?? "") == (o.sku ?? "") && x.line_id == o.line_id && x.active == true).Sum(x => x.gross_wt));

                    //o.NoOfPkgs = 0;
                    //o.NoOfPkgs = ItemBatchEntity.GroupBy(x => new { x.ItemCode, x.sku, x.line_id, x.pack_no, x.active })
                    //                                .Select(g => g.Key.ItemCode == o.ItemCode && (g.Key.sku ?? "") == (o.sku ?? "") && g.Key.line_id == o.line_id).Count();

                    if (AppSessionState.client == "1") // NOTE: only for Essem. we can remove this if client 1 not use this VM.
                    {
                        o.qty = 0;
                        o.qty = Convert.ToDecimal(ItemBatchEntity.Where(x => x.ItemCode == o.ItemCode && x.sku == o.sku && x.line_id == o.line_id && x.active == true).Sum(x => x.qty));
                    }

                    if (ItemBatchEntity.Select(x => x.ItemCode == o.ItemCode && (x.sku ?? "") == (o.sku ?? "") && x.line_id == o.line_id && x.active == true).Count() > 0)
                    {
                        //o.container_no = "1 TO "               + ItemBatchEntity.Select(x => x.ItemCode == o.ItemCode && x.sku == o.sku && x.line_id == o.line_id && x.active == true).Count();
                        //o.KindOfPkgs =( "CARTON BOX " + "1 TO " + ItemBatchEntity.Select(x => x.ItemCode == o.ItemCode && x.sku == o.sku && x.line_id == o.line_id && x.active == true).Count();
                        //+ System.Environment.NewLine 

                        o.container_no = "1 TO " + ItemBatchEntity.GroupBy(x => new { x.ItemCode, x.sku, x.line_id, x.pack_no, x.active })
                                                    .Select(g => g.Key.ItemCode == o.ItemCode && (g.Key.sku ?? "") == (o.sku ?? "") && g.Key.line_id == o.line_id).Count();
                        o.KindOfPkgs = "CARTON BOX " + "1 TO " + ItemBatchEntity.GroupBy(x => new { x.ItemCode, x.sku, x.line_id, x.pack_no, x.active })
                                                    .Select(g => g.Key.ItemCode == o.ItemCode && (g.Key.sku ?? "") == (o.sku ?? "") && g.Key.line_id == o.line_id).Count();



                    }
                }
                MasterEntity.no_of_packages = ItemsEntity.Where(x => x.active == true).Sum(x => x.NoOfPkgs);
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
        private void CalculateWeightAndVolume()
        {
            try
            {

                if (MasterEntity.gross_wt == null)
                {
                    MasterEntity.gross_wt = 0;
                }
                if (MasterEntity.volume == null)
                {
                    MasterEntity.volume = 0;
                }
                if (MasterEntity.net_wt == null)
                {
                    MasterEntity.net_wt = 0;
                }
                if (MasterEntity.net_value == null)
                {
                    MasterEntity.net_value = 0;
                }
                MasterEntity.volume = 0;
                MasterEntity.net_value = 0;
                MasterEntity.no_of_packages = 0;
                MasterEntity.net_wt = 0;
                MasterEntity.gross_wt = 0;

                foreach (var item in ItemsEntity)
                {
                    if (item.active == true)
                    {
                        MasterEntity.gross_wt = MasterEntity.gross_wt + item.gross_wt;
                        MasterEntity.volume = MasterEntity.volume + item.volume;
                        MasterEntity.net_wt = MasterEntity.net_wt + item.net_wt;
                        MasterEntity.net_value = MasterEntity.net_value + item.net_value;
                        MasterEntity.no_of_packages = MasterEntity.no_of_packages + item.NoOfPkgs;
                        MasterEntity.weight_unit = item.weight_unit;
                    }
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
        private void PackingListReport()
        {
            CursorControl.SetBusyState();
            try
            {
                if (post == false)
                {
                    string Request = "DN_PackingList" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.delivery_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@!@!@" + MasterEntity.ref_doc_cat;
                    //string Request = "DN_PackingList" + "!@" + MasterEntity.ref_doc_cat + "!@" + MasterEntity.delivery_no;
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp, Request, "LOG_T001_BL", "SDM", "LoadAll", 0, Request);

                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];
                    //MC.Delivery_Note.Clear();
                    //MC.Delivery_Note.Add(MasterEntity);          

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[0] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[1] = Result;

                    objDataSource[2] = MCTemp.RptPackingListList;

                    objDataSourceName[0] = "dsCompany";
                    objDataSourceName[1] = "dsLocation";
                    objDataSourceName[2] = "RptPackingList";


                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\PackingList3.rdlc", "PackingList");
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Goods Not Posted...!!! Cannot Print", this.Title);
                    showMessageService.ShowMessage();
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
        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = MasterEntity.HasErrors;
        }
        private void LoadBackFlipData()
        {
            try
            {
                EntityChangeEnable = false;
                CursorControl.SetBusyState();
                string Request = "Load_BackFlip_Data" + "!@" + AppSessionState.client + "!@" + (REQUEST_PARA.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + REQUEST_PARA.location_id + "!@" + (REQUEST_PARA.doc_cat ?? this.doc_cat_vm) + "!@" + (REQUEST_PARA.doc_type ?? this.doc_cat_vm) + "!@" + REQUEST_PARA.para1 + "!@" + AppSessionState.UserID + "!@" + REQUEST_PARA.emp_id + "!@" + this.ts_code_vm + "!@" + REQUEST_PARA.so_code + "!@" + REQUEST_PARA.sg_code + "!@" + REQUEST_PARA.party_code + "!@!@" + REQUEST_PARA.active + "!@" + REQUEST_PARA.t_status + "!@" + Convert.ToDateTime(REQUEST_PARA.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQUEST_PARA.to_date).ToString("MM/dd/yyyy");
                MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp, Request, "LOG_T001_BL", "SDM", "LoadAll", 0, Request);

                MC.FlipGridList = MCTemp.FlipGridList;
                FlipDeliveryNoteCollection = CollectionViewSource.GetDefaultView(MC.FlipGridList);
                FlipDeliveryNoteCollection.Filter = new Predicate<object>(FlipFilter);
                EntityChangeEnable = true;
                var msg = new NotificationMessage(this.ts_code_vm);
                Messenger.Default.Send<NotificationMessage>(msg);
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
        private void AddSelectedRef(object InputValue)
        {
            try
            {
                Order_No_P POPUPEntityObject = null;
                string Request;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.OrderList.Where(x => x.order_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<Order_No_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<Order_No_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    if (POPUPEntityObject.t_status != "09")
                    {

                        MasterEntity.ref_docno = POPUPEntityObject.order_no;
                        MasterEntity.order_no = POPUPEntityObject.order_no;
                        MasterEntity.ref_doc_cat = POPUPEntityObject.doc_cat;
                        MasterEntity.ref_doc_type = POPUPEntityObject.doc_type;
                        REQUEST_PARA.doc_no = null;

                        // Clear Other reference.
                        var refdocData = (from o in MC.OrderList where o.doc_cat != POPUPEntityObject.doc_cat select o);
                        if (refdocData != null)
                        {
                            foreach (var item in refdocData)
                            {
                                item.Select = false;
                            }
                        }

                        if (MasterEntity.ref_doc_cat == "TO" || MasterEntity.ref_doc_cat == "RT")
                        {

                            if (POPUPEntityObject.Select == true)
                            {
                                var refdocTO = from o in MC.OrderList
                                               where o.supplying_plant == POPUPEntityObject.supplying_plant
                                               && o.rec_plant == POPUPEntityObject.rec_plant
                                               && o.doc_cat == POPUPEntityObject.doc_cat
                                               select o;
                                ReferenceDocTOCollection = CollectionViewSource.GetDefaultView(refdocTO);
                                ReferenceDocTOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                            }
                            else // if user uncheck all records then it should be relist all records.
                            {
                                List<Order_No_P> refdocTOR = (from o in MC.OrderList where o.doc_cat == MasterEntity.ref_doc_cat && o.Select == true select o).ToList();
                                if (refdocTOR.Count == 0)
                                {
                                    List<Order_No_P> refdocTOL = (from o in MC.OrderList where o.doc_cat == MasterEntity.ref_doc_cat select o).ToList();
                                    ReferenceDocTOCollection = CollectionViewSource.GetDefaultView(refdocTOL);
                                    ReferenceDocTOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                                }
                            }
                            List<Order_No_P> refdocTOM = (from o in MC.OrderList where o.doc_cat == MasterEntity.ref_doc_cat && o.Select == true select o).ToList();
                            foreach (var item in refdocTOM)
                            {
                                if (item.Select == true)
                                {
                                    REQUEST_PARA.doc_no = REQUEST_PARA.doc_no + "," + item.order_no;
                                    //REQUEST_PARA.del = item.de;
                                }
                            }

                        }
                        if (doc_cat_vm != "DT")
                        {
                            var refdoctempa = (from o in MC.OrderList where o.doc_cat == POPUPEntityObject.doc_cat select o);
                            var refdoc = from o in refdoctempa
                                         where o.PartyId == POPUPEntityObject.PartyId
                                            && o.party_name == POPUPEntityObject.party_name
                                            && o.so_code == POPUPEntityObject.so_code
                                            && o.curr_code == POPUPEntityObject.curr_code
                                            && o.del_address == POPUPEntityObject.del_address
                                            && o.doc_cat == POPUPEntityObject.doc_cat
                                            && o.p_term_code == POPUPEntityObject.p_term_code
                                            && o.incoterms == POPUPEntityObject.incoterms
                                            && o.country_nm_s == POPUPEntityObject.country_nm_s
                                         select o;

                            List<Order_No_P> refdocTOR = (from o in MC.OrderList where o.doc_cat == MasterEntity.ref_doc_cat && o.Select == true select o).ToList();
                            if (MasterEntity.ref_doc_cat == "SO")
                            {
                                if (POPUPEntityObject.Select == true)
                                {
                                    ReferenceDocSOCollection = CollectionViewSource.GetDefaultView(refdoc);
                                    ReferenceDocSOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                                }
                                else // if user uncheck all records then it should be relist all records.
                                {
                                    if (refdocTOR.Count == 0)
                                    {
                                        List<Order_No_P> refdocTOL = (from o in MC.OrderList where o.doc_cat == MasterEntity.ref_doc_cat select o).ToList();
                                        ReferenceDocSOCollection = CollectionViewSource.GetDefaultView(refdocTOL);
                                        ReferenceDocSOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                                    }
                                }
                            }
                            else if (MasterEntity.ref_doc_cat == "DO")
                            {
                                if (POPUPEntityObject.Select == true)
                                {
                                    ReferenceDocDOCollection = CollectionViewSource.GetDefaultView(refdoc);
                                    ReferenceDocDOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                                }
                                else if (refdocTOR.Count == 0)
                                {
                                    List<Order_No_P> refdocTOL = (from o in MC.OrderList where o.doc_cat == MasterEntity.ref_doc_cat select o).ToList();
                                    ReferenceDocDOCollection = CollectionViewSource.GetDefaultView(refdocTOL);
                                    ReferenceDocDOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                                }
                            }
                            else if (MasterEntity.ref_doc_cat == "MO")
                            {
                                if (POPUPEntityObject.Select == true)
                                {
                                    ReferenceDocMOCollection = CollectionViewSource.GetDefaultView(refdoc);
                                    ReferenceDocMOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                                }
                                else if (refdocTOR.Count == 0)
                                {
                                    List<Order_No_P> refdocTOL = (from o in MC.OrderList where o.doc_cat == MasterEntity.ref_doc_cat select o).ToList();
                                    ReferenceDocMOCollection = CollectionViewSource.GetDefaultView(refdocTOL);
                                    ReferenceDocMOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                                }
                            }
                            else if (MasterEntity.ref_doc_cat == "SD")
                            {
                                List<Order_No_P> refdocSDR = (from o in MC.OrderList where o.doc_cat == MasterEntity.ref_doc_cat && o.Select == true select o).ToList();
                                if (POPUPEntityObject.Select == true)
                                {
                                    ReferenceDocSDCollection = CollectionViewSource.GetDefaultView(refdoc);
                                    ReferenceDocSDCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                                }
                                else if (refdocTOR.Count == 0)
                                {
                                    //refdoc = (from o in MC.OrderList where o.doc_cat == "SD" select o).ToList();
                                    List<Order_No_P> refdocTOL = (from o in MC.OrderList where o.doc_cat == MasterEntity.ref_doc_cat select o).ToList();
                                    ReferenceDocMOCollection = CollectionViewSource.GetDefaultView(refdocTOL);
                                    ReferenceDocMOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                                    ReferenceDocSDCollection = CollectionViewSource.GetDefaultView(refdocTOL);
                                    ReferenceDocSDCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                                }

                                
                            }
                            foreach (var item in refdoc)
                            {
                                if (item.Select == true && item.ind_executable != "N") // NOTE:(REF:DNSI) item.ind_executable will be satisfy only if payment term allowed indicator to false  and if true then payment must receied on or before the specified days. Payment check validation done in SQL quer which is not yet done. This logic is added in Invoice and Delivey note VM only.
                                {
                                    REQUEST_PARA.doc_no = REQUEST_PARA.doc_no + "," + item.order_no;
                                }
                                else if(item.Select == true && item.ind_executable == "N") // NOTE:(REF:DNSI)
                                {
                                    item.Select = false;

                                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                    showMessageService.ButtonSetup = DialogButton.Ok;
                                    showMessageService.Caption = "Message";
                                    showMessageService.Text = String.Format("You Cannot Proceed with this Document. System Remark : " + (item.short_text ?? "Credit Policy"));
                                    showMessageService.ShowMessage();
                                }
                            }

                        }
                        if(!string.IsNullOrWhiteSpace(REQUEST_PARA.doc_no))
                        {
                            REQUEST_PARA.doc_no = REQUEST_PARA.doc_no.ToString().TrimStart(new char[] { ',' });
                        }
                        

                        if (REQUEST_PARA.doc_no == "")
                        {
                            MasterEntity.ref_docno = null;
                            MasterEntity.ref_doc_cat = null;
                            MasterEntity.ref_doc_type = null;
                        }

                    }
                    else if (POPUPEntityObject.Select == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("This Document is Suspended. You Cannot Proceed with this Document.");
                        showMessageService.ShowMessage();
                    }
                }
            }
            catch (Exception Ex) { }
        }
        private void ReferenceSelection(object InputValue) // NOTE: make this function common for all reference button by sending parameter for difference collection and remove "AddSelectedRef". 
        {
            try
            {
                OrderItemData POPUPEntityObject = null;
                REQUEST_PARA.doc_no = "";
                string Request;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.OrderItems.Where(x => x.order_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<OrderItemData>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<OrderItemData>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    if (POPUPEntityObject.Select == true)
                    {
                        var refdocTO = from o in MC.OrderItems
                                       where o.supplying_plant == POPUPEntityObject.supplying_plant
                                       && o.rec_plant == POPUPEntityObject.rec_plant
                                       && o.doc_cat == POPUPEntityObject.doc_cat
                                       select o;
                        ReferenceDoc_TO_Item_Collection = CollectionViewSource.GetDefaultView(refdocTO);
                        ReferenceDoc_TO_Item_Collection.Filter = new Predicate<object>(Filter_ReferenceItem);
                    }
                    else // if user uncheck all records then it should be relist all records.
                    {
                        List<OrderItemData> refdocTOR = (from o in MC.OrderItems where (o.doc_cat == "TO" || o.doc_cat == "RT") && o.Select == true select o).ToList();
                        if (refdocTOR.Count == 0)
                        {
                            List<OrderItemData> refdocTOL = (from o in MC.OrderItems where (o.doc_cat == "TO" || o.doc_cat == "RT") select o).ToList();
                            ReferenceDoc_TO_Item_Collection = CollectionViewSource.GetDefaultView(refdocTOL);
                            ReferenceDoc_TO_Item_Collection.Filter = new Predicate<object>(Filter_ReferenceItem);
                        }
                    }
                    List<OrderItemData> refdocTOM = (from o in MC.OrderItems where (o.doc_cat == "TO" || o.doc_cat == "RT") && o.Select == true select o).ToList();
                    foreach (var item in refdocTOM)
                    {
                        if (item.Select == true)
                        {
                            REQUEST_PARA.doc_no = REQUEST_PARA.doc_no + "," + item.sch_item_row_id.ToString();
                        }
                    }
                    REQUEST_PARA.doc_no = REQUEST_PARA.doc_no.ToString().TrimStart(new char[] { ',' });
                }
            }
            catch (Exception Ex) { }
        }

        #endregion

        #region . Validation Function .
        private bool Validation()
        {
            if (MasterEntity.doc_type == null || MasterEntity.doc_type == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Validation";
                showMessageService.Text = String.Format("Please select Document Type");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.doc_cat == null || MasterEntity.doc_cat == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Validation";
                showMessageService.Text = String.Format("Please select Document Category");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.doc_cat == "DT" && MasterEntity.location_Id == MasterEntity.rec_plant)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Validation";
                showMessageService.Text = String.Format("Supplying and Receiving Plant should not be the same in case of Plant to Plant Transfer Delivery Note.");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.doc_cat == "DT" && (string.IsNullOrWhiteSpace(MasterEntity.location_Id) == true || string.IsNullOrWhiteSpace(MasterEntity.rec_plant) == true))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Validation";
                showMessageService.Text = String.Format("Supplying and Receiving Plant required in case of Plant to Plant Transfer Delivery Note.");
                showMessageService.ShowMessage();
                return false;
            }
            //if (REQUEST_PARA.doc_no == null || REQUEST_PARA.doc_no == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Validation";
            //    showMessageService.Text = String.Format("Please select Reference Document Number\n Reference Document Number is Compulsory for Delivery Note");
            //    showMessageService.ShowMessage();
            //    return false;
            //}

            if (REQUEST_PARA.doc_no != null && REQUEST_PARA.doc_no == "" && MasterEntity.doc_cat != "DT" && (MasterEntity.del_address == null || MasterEntity.del_address == 0))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Validation";
                showMessageService.Text = String.Format("Please Select Delivery Address in Organizational Data Tab. \n Make Sure that Party Master exists At Least One Address for Ship to party you have selected\n with Address type : Delivery Address");
                showMessageService.ShowMessage();
                return false;
            }



            #region . Validation for Item Duplication, null Unit Code and Null or 0 Quantity For All Active Unsaved Items .
            // Validation for Quantity Item Duplication and Unit Code For Item Details
            foreach (var o in ItemsEntity)
            {
                int flag = 0;
                if (o.id == 0 && o.active == true)
                {
                    foreach (var p in ItemsEntity)
                    {
                        if (o.line_id == p.line_id && o.ItemCode == p.ItemCode && o.sku == p.sku && o.ref_item_row_id == p.ref_item_row_id && o.ref_doc == p.ref_doc && o.order_no == p.order_no && p.active == true)
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

                if (o.ItemCode != null && o.ItemCode != "")
                {
                    if (o.qty == null || o.qty == 0)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Quantity cannot be null or 0 for item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
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

                    if (string.IsNullOrWhiteSpace(o.store_code)==true && (o.item_cat != "SVC" && o.item_cat_code != "SE"))
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Valid Store Code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                        showMessageService.ShowMessage();
                        return false;
                    }

                    //int IndexOfExistValue = MC.ReserveDateList.IndexOf(MC.ReserveDateList.Where(X => X.ItemCode == SelectedItemsEntity.ItemCode && X. ).FirstOrDefault()); // Prefer Primary Key for this instruction. 

                }

                #region . Parameter Validation .
                // Validation For All Parameter Values Selected or Not

                if (o.StockUnt == true && o.active == true && o.id == 0)
                {
                    var paralist = (from p in MC.ParameterList where p.SubCatCode == o.SubCatCode select p).ToList();

                    if (paralist.Count > 0)
                    {
                        string[] SkuList = new string[100];           //string array
                        List<string> SkuListt = new List<string>();    // stringlist

                        if (o.sku != null && o.sku != "")
                        {
                            SkuList = o.sku.Split('/');
                            SkuListt = SkuList.ToList();

                            foreach (var item in SkuList)
                            {
                                if (item == "")
                                {
                                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                    showMessageService.ButtonSetup = DialogButton.Ok;
                                    showMessageService.Caption = "Parameter Validation";
                                    showMessageService.Text = String.Format("All Parameters of item {0} are not selected..!!! \n If you can see All Parameter Values Selected Please Select the Same Values Again ", o.ItemCode);
                                    showMessageService.ShowMessage();
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Parameter Validation";
                            showMessageService.Text = String.Format("All Parameters of item {0} are not selected\n If you can see All Parameter Value Selected Please Select the Same Values Again ", o.ItemCode);
                            showMessageService.ShowMessage();
                            return false;
                        }
                    }

                }
                #endregion


                #region Reservation Alert

                if (o.id == 0 && o.active == true)
                {
                    STD_LIST_BE SL_OBJ = null;
                    try
                    {
                        SL_OBJ = MC.RESERVATION_LIST.Where(x => x.item_code.Equals(o.ItemCode, StringComparison.OrdinalIgnoreCase) == true || x.order_no.Equals(o.order_no, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                    }
                    catch (Exception ex) { }

                    if (SL_OBJ != null)
                    {
                        if (((SL_OBJ.stock_total ?? 0) - (SL_OBJ.stock_reserve ?? 0)) < o.qty)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Validation : Reservation Alert";
                            showMessageService.Text = String.Format("You are Using Stock Reserved For Different Order No...\n Are you sure do you want to use this Stock ? \n Click Ok To Continue and Use Stock else Click on Cancel ");
                            showMessageService.ShowMessage();

                            if (showMessageService.ShowMessage() == DialogResult.Cancel)
                            {
                                return false;
                            }
                        }
                    }
                }

                #endregion

            }

            #endregion

            #region . Active Batch Quantity Exceeds Capacity/Remaining Capacity of Stock Quantity.
            //Validation for Entered Batch Quantity More than Stock Quantity
            for (int a = 0; a < ItemBatchEntity.Count; a++)
            {
                for (int b = 0; b < MC.BatchesList.Count; b++)
                {
                    if (ItemBatchEntity[a].store_code == null || ItemBatchEntity[a].store_code == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Valid Store Code for the batch {0} of Item {1}", ItemBatchEntity[a].batch_no, ItemBatchEntity[a].ItemCode);
                        showMessageService.ShowMessage();
                        return false;
                    }

                    if (ItemBatchEntity[a].batch_no == MC.BatchesList[b].batch_no && ItemBatchEntity[a].active == true)
                    {
                        if (ItemBatchEntity[a].qty > MC.BatchesList[b].stock_total)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Batch {0} Quantity {1} Exceeds Batch Capacity/RemainingCapacity {2} ", ItemBatchEntity[a].batch_no, ItemBatchEntity[a].qty, MC.BatchesList[b].stock_total);
                            showMessageService.ShowMessage();
                            return false;
                        }
                    }
                }
            }
            #endregion

            #region . Item Quantity Batch Quantity Validation.
            //Validation For Item Quantity Equal To Sum of Quantities of All Active Batches Of the Item 
            //bool breakfor = false;
            for (int i = 0; i < ItemsEntity.Count; i++)
            {
                decimal temp = 0;
                int flag = 0;
                decimal item_qty = 0;
                decimal batch_qty = 0;

                if (ItemsEntity[i].active == true)
                {
                    for (int j = 0; j < ItemBatchEntity.Count; j++)
                    {
                        if (ItemsEntity[i].ItemCode == ItemBatchEntity[j].ItemCode && ItemsEntity[i].sku == ItemBatchEntity[j].sku && ItemsEntity[i].line_id == ItemBatchEntity[j].line_id && ItemBatchEntity[j].active == true && string.IsNullOrWhiteSpace(ItemBatchEntity[j].batch_no) == false)
                        {
                            temp = temp + Convert.ToDecimal(ItemBatchEntity[j].qty);
                            flag = 1;
                        }
                    }

                    if (ItemsEntity[i].qty != temp && flag == 1)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Item Quantity is Not Equal to Sum of All Item Batches Quantities\n for Item {0} Parameter :{1} ", ItemsEntity[i].ItemCode, ItemsEntity[i].sku_desc);
                        showMessageService.ShowMessage();
                        //breakfor = false;
                        return false;
                    }
                }

                //Checking Item quantity with total of batch qty for item if Batch is mandatory for item in master.
                if (ItemsEntity[i].ind_batch_req == "Y")
                {
                    item_qty = ItemsEntity[i].qty;
                    foreach (var item in ItemBatchEntity)
                    {
                        if (item.ItemCode == ItemsEntity[i].ItemCode)
                        {
                            batch_qty = batch_qty + (item.qty ?? 0);
                        }
                    }

                    if (item_qty != batch_qty)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Item Quantity is Not Equal to Sum of All Item Batches Quantities\n for Item {0} Parameter :{1} ", ItemsEntity[i].ItemCode, ItemsEntity[i].sku_desc);
                        showMessageService.ShowMessage();
                        //breakfor = false;
                        return false;
                    }
                }
            }
            //if (MasterEntity.doc_cat != "PO" && MasterEntity.doc_cat != "DT" && (MasterEntity.so_code == null || MasterEntity.so_code == ""))
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Field Sales Organisation Is Required");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            //if (MasterEntity.doc_cat != "PO" && MasterEntity.doc_cat != "DT" && (MasterEntity.sg_code == null || MasterEntity.sg_code == ""))
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Field Sales Group Is Required");
            //    showMessageService.ShowMessage();
            //    return false;
            //}


            #endregion

            if (MasterEntity.tr_mode == null || MasterEntity.tr_mode == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Warning";
                showMessageService.Text = String.Format("You Are Saving Document Without Shipment Mode ! ");
                showMessageService.ShowMessage();
            }
            else if (MasterEntity.tr_party == null || MasterEntity.tr_party == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Warning";
                showMessageService.Text = String.Format("You Are Saving Document Without Transporter ! ");
                showMessageService.ShowMessage();
            }
            else if ((MasterEntity.tr_party == null || MasterEntity.tr_party == "") && (MasterEntity.tr_mode == null || MasterEntity.tr_mode == ""))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Warning";
                showMessageService.Text = String.Format("You Are Saving Document Without Transporter and Shipment Mode ! ");
                showMessageService.ShowMessage();
            }
            return true;
        }

        #endregion

        #region . Command Actions .
        protected override void OnSaveAction(InquiryActionResult<LOG_T001_A> result)
        {
            try
            {
                CursorControl.SetBusyState();
                Logging();

                if (Validation() == true)// && (MasterEntity.t_status != "11" && MasterEntity.t_status != "11" && MasterEntity.t_status != "03"))
                {
                    ObjectSerializationService objSer = new ObjectSerializationService();
                    MasterEntity.XmlDataDocument_LOG_T001_B = objSer.ObjectToXML(ItemsEntity);
                    MasterEntity.XmlDataDocument_LOG_T001_C = objSer.ObjectToXML(ItemBatchEntity);

                    if (blNew == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<LOG_T001_A>(MasterEntity, "LOG_T001_BL", "SDM");

                        // Adding Insert Record to Flip Grid
                        if (MasterEntity.XmlDataDocument_LOG_T001_D != null && blNew == true)
                        {
                            MCTemp.FlipGridList = (List<LOG_T001_A_FLIP>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_LOG_T001_D, MC.FlipGridList);
                            MC.FlipGridList.Add(MCTemp.FlipGridList[0]);
                        }
                        blNew = false;
                    }
                    else if (blNew == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<LOG_T001_A>(MasterEntity, "LOG_T001_BL", "SDM");
                    }

                    // Getting Inserted and Updated Record of ITEM Details LOG_T001_B
                    if (MasterEntity.XmlDataDocument_LOG_T001_B != null)
                    {
                        MCTemp.DelNoteItemDetails = (ObservableCollection<LOG_T001_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_LOG_T001_B, MC.DelNoteItemDetails);
                    }
                    else
                    {
                        MCTemp.DelNoteItemDetails = new ObservableCollection<LOG_T001_B>();
                    }
                    ItemsEntity = MCTemp.DelNoteItemDetails;

                    // Getting Inserted and Updated Record of ITEM BATCH Details LOG_T001_C
                    if (MasterEntity.XmlDataDocument_LOG_T001_C != null)
                    {
                        MCTemp.ItemBatchDetails = (ObservableCollection<LOG_T001_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_LOG_T001_C, MC.ItemBatchDetails);
                    }
                    else
                    {
                        MCTemp.ItemBatchDetails = new ObservableCollection<LOG_T001_C>();
                    }
                    ItemBatchEntity = MCTemp.ItemBatchDetails;
                    MasterEntity.ts_code = ts_code_vm;
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Saved Successfully", this.Title);
                    showMessageService.ShowMessage();

                    RemoveRefDoc();
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
        private void RemoveRefDoc()
        {
            try
            {
                if (MasterEntity.order_no != null)
                {
                    if (!string.IsNullOrWhiteSpace(REQUEST_PARA.doc_no))
                    {
                        MC.OrderList.RemoveAll(X => REQUEST_PARA.doc_no.Contains(X.order_no));
                    }


                    if (this.doc_cat_vm == "DT")
                    {
                        foreach (var item in ItemsEntity)
                        {
                            MC.OrderList.RemoveAll(X => X.order_no == item.ref_doc && X.ItemCode == item.ItemCode);
                            MC.OrderItems.RemoveAll(X => X.order_no == item.ref_doc && X.ItemCode == item.ItemCode);
                            //MC.OrderItems.RemoveAll(X => X.order_no.Contains(MasterEntity.order_no));
                        }
                        ReferenceDoc_TO_Item_Collection = CollectionViewSource.GetDefaultView(MC.OrderItems);
                        ReferenceDoc_TO_Item_Collection.Filter = new Predicate<object>(Filter_ReferenceItem);
                    }


                    refdoctempa = (from o in MC.OrderList where (o.doc_cat == "SO" || o.doc_cat == "OP" || o.doc_cat == "SR" || o.doc_cat == "SD") select o).ToList();
                    ReferenceDocSOCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                    ReferenceDocSOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    refdoctempa = (from o in MC.OrderList where o.doc_cat == "DO" select o).ToList();
                    ReferenceDocTOCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                    ReferenceDocTOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    refdoctempa = (from o in MC.OrderList where o.doc_cat == "MO" select o).ToList();
                    ReferenceDocMOCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                    ReferenceDocMOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    refdoctempa = (from o in MC.OrderList where o.doc_cat == "SD" select o).ToList();
                    ReferenceDocSDCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                    ReferenceDocSDCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                }
                var msg = new NotificationMessage(this.ts_code_vm);
                Messenger.Default.Send<NotificationMessage>(msg);
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
        protected override void OnCreateAction(InquiryActionResult<LOG_T001_A> result)
        {
            MasterEntity = new LOG_T001_A();
            ItemsEntity = new ObservableCollection<LOG_T001_B>();
            ItemBatchEntity = new ObservableCollection<LOG_T001_C>();
            SelectedItemsEntity = new LOG_T001_B();
            DefaultValues(doc_cat_vm);
            MasterEntity.ValidateAsync().Wait();
        }
        protected override void OnRemoveAction(InquiryActionResult<LOG_T001_A> result)
        { }
        protected override void OnDiscardAction(InquiryActionResult<LOG_T001_A> result)
        {
            MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<LOG_T001_A> result)
        { }
        protected override void OnFlipAction(InquiryActionResult<LOG_T001_A> result)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "RefreshBatchCollection" + "!@" + AppSessionState.client + "!@" + (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (MasterEntity.location_Id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + this.doc_cat_vm + "!@" + REQUEST_PARA.para1 + "!@!@" + AppSessionState.UserID + "!@" + (MasterEntity.EmpId ?? AppSessionState.EmpId) + "!@" + this.ts_code_vm + "!@" + AppSessionState.sg_code + "!@" + (MasterEntity.sg_code ?? AppSessionState.sg_code) + "!@" + REQUEST_PARA.party_code + "!@!@" + REQUEST_PARA.active + "!@" + REQUEST_PARA.t_status + "!@" + Convert.ToDateTime(REQUEST_PARA.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQUEST_PARA.to_date).ToString("MM/dd/yyyy");

                MCRefresh = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MC, Request, "LOG_T001_BL", "SDM", "LoadAll", 0, Request);

                MC.CartonsList = MCRefresh.CartonsList;
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
        protected override void OnHelpAction(InquiryActionResult<LOG_T001_A> result)
        { }
        protected override void OnPrintAction(InquiryActionResult<LOG_T001_A> result)
        {
            try
            {
                CursorControl.SetBusyState();
                if (post == false)
                {
                    ReportManager ReportManager = new ReportManager();
                    object[] objDataSource = new object[5];
                    string[] objDataSourceName = new string[5];
                    string ReportName = "";


                    var CmpResult = AppSessionState.COMPANY_LIST.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[0] = CmpResult;

                    var Result = AppSessionState.LOCATION_LIST.Where(loc => loc.location_id == MasterEntity.location_Id).ToList();
                    objDataSource[1] = Result;

                    if (MC.Delivery_Note != null)
                    {
                        if (MC.Delivery_Note.Count > 0)
                        {
                            MC.Delivery_Note.Clear();
                            MC.Delivery_Note.Add(MasterEntity);
                        }
                        else
                        {
                            MC.Delivery_Note.Add(MasterEntity);
                        }
                    }

                    objDataSource[2] = MC.Delivery_Note;
                    objDataSource[3] = ItemsEntity;
                    objDataSource[4] = ItemBatchEntity;

                    objDataSourceName[0] = "dsCompany";
                    objDataSourceName[1] = "dsLocation";
                    objDataSourceName[2] = "dsMaster";
                    objDataSourceName[3] = "dsItems";
                    objDataSourceName[4] = "dsBatch";

                    if (MC.DocCategoryList != null)
                    {
                        if (MC.DocCategoryList.Count > 0)
                        {
                            var DOC_TYPE_OBJ = (from o in MC.DocCategoryList where o.doc_cat == doc_cat_vm && o.doc_type == MasterEntity.doc_type select o).FirstOrDefault();
                            if (DOC_TYPE_OBJ.ind_digital == "0")
                            {
                                ReportName = DOC_TYPE_OBJ.report_name.Split(',')[1];
                            }
                            else
                            {
                                ReportName = DOC_TYPE_OBJ.report_name.Split(',')[0];
                            }
                        }
                    }

                    string ReportDisplayName = (MasterEntity.ship_to_party ?? "") + "_" + MasterEntity.delivery_no + "_" + MasterEntity.delivery_date.Value.ToShortDateString();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\TXN\\" + ReportName, ReportDisplayName);

                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Goods Not Posted...!!! Cannot Print", this.Title);
                    showMessageService.ShowMessage();
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
        //protected override void OnPrintAction(InquiryActionResult<LOG_T001_A> result)
        //{
        //    try
        //    {
        //        CursorControl.SetBusyState();
        //        if (post == false)
        //        {
        //            string ReportName = "";
        //            string Request = "DN_Report" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + this.doc_cat_vm + "!@" + MasterEntity.delivery_no;
        //            //string Request = "DN_Report" + "!@" + MasterEntity.delivery_no;
        //            MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp, Request, "LOG_T001_BL", "SDM", "LoadAll", 0, Request);

        //            object[] objDataSource = new object[3];
        //            string[] objDataSourceName = new string[3];


        //            List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
        //            var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
        //            objDataSource[0] = CmpResult;

        //            List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
        //            var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
        //            objDataSource[1] = Result;

        //            objDataSource[2] = MCTemp.RptDeliveryNoteList;

        //            objDataSourceName[0] = "dsCompany";
        //            objDataSourceName[1] = "dsLocation";
        //            objDataSourceName[2] = "dsRptDeliveryNote";

        //            if (MasterEntity.doc_type == "DN" || MasterEntity.doc_type == "DE" || MasterEntity.doc_type == "FD" || MasterEntity.doc_type == "DT")
        //            {
        //                ReportName = (from o in MC.DocCategoryList where o.doc_type == "DN" || o.doc_type == "DT" select o.report_name).First().ToString();
        //            }

        //            ReportManager ReportManager = new ReportManager();
        //            if (MasterEntity.PrintOption != null && MasterEntity.PrintOption != "")
        //            {
        //                string Temp = MasterEntity.PrintOption;
        //                string[] Temp2 = Temp.Split(',');
        //                for (int i = 0; i < Temp2.Length; i++)
        //                {
        //                    Temp2[i] = Temp2[i].Trim();
        //                }

        //                foreach (var item in Temp2)
        //                {
        //                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(item), ReportName);
        //                }
        //            }
        //            else
        //            {
        //                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(), ReportName);
        //            }
        //        }
        //        else
        //        {
        //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //            showMessageService.ButtonSetup = DialogButton.Ok;
        //            showMessageService.Caption = "Message";
        //            showMessageService.Text = String.Format("Goods Not Posted...!!! Cannot Print", this.Title);
        //            showMessageService.ShowMessage();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();

        //    }

        //}
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", AppSessionState.Name);
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
            return result;
        }
        private Dictionary<string, string> getParametersList(string paraValue)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", AppSessionState.Name);
                result.Add("PrintOption", paraValue);
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
            return result;
        }
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.delivery_no))
            {
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.delivery_no.Replace("/", "--"), DocumentList = MCTemp.Attachment, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<LOG_T001_A> result)
        {
            RefreshRefence(doc_cat_vm, null);
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<LOG_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<LOG_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<LOG_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<LOG_T001_A> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region . Filters .

        #region Report Data

        private string _filterString_ReportData;
        public string FilterString_ReportData
        {
            get { return _filterString_ReportData; }
            set
            {
                _filterString_ReportData = value;
                RaisePropertyChanged("FilterString_ReportData");
                FilterCollection_ReportData();
            }
        }
        private void FilterCollection_ReportData()
        {
            if (_ReportDataCollection != null)
            {
                _ReportDataCollection.Refresh();
            }
        }
        public bool Filter_ReportData(object obj)
        {
            var data = obj as Report_Data_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ReportData))
                {
                    return (data.id != null && data.id.ToString().ToLower().Contains(_filterString_ReportData.ToLower()) ||
                            data.data1 != null && data.data1.ToString().ToLower().Contains(_filterString_ReportData.ToLower())
                        );
                }
                return true;
            }
            return false;
        }
        #endregion
        #region Filters for Flip Gatagrid

        private void FlipCollection()
        {
            if (_FlipDeliveryNoteCollection != null)
            {
                _FlipDeliveryNoteCollection.Refresh();
            }
        }
        private string _filterStringFlip;
        public string FilterStringFlip
        {
            get { return _filterStringFlip; }
            set
            {
                _filterStringFlip = value;
                RaisePropertyChanged("FilterStringFlip");
                FlipCollection();
            }
        }
        public bool FlipFilter(object obj)
        {
            var data = obj as LOG_T001_A_FLIP;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringFlip))
                {
                    return (data.delivery_no != null && data.delivery_no.ToLower().Contains(_filterStringFlip.ToLower())) ||
                           (data.delivery_date != null && data.delivery_date.ToString().ToLower().Contains(_filterStringFlip.ToLower())) ||
                           (data.soldpartynm != null && data.soldpartynm.ToString().ToLower().Contains(_filterStringFlip.ToLower())) ||
                           (data.order_no != null && data.order_no.ToLower().Contains(_filterStringFlip.ToLower())) ||
                           (data.t_status != null && data.t_status.ToLower().Contains(_filterStringFlip.ToLower())) ||
                           (data.yr_ref_no != null && data.yr_ref_no.ToLower().Contains(_filterStringFlip.ToLower())) ||
                           (data.del_desc != null && data.del_desc.ToLower().Contains(_filterStringFlip.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        private string _FilterString_ReferenceDoc;
        public string FilterString_ReferenceDoc
        {
            get { return _FilterString_ReferenceDoc; }
            set
            {
                _FilterString_ReferenceDoc = value;
                RaisePropertyChanged("FilterString_ReferenceDoc");
                FilterCollection_ReferenceDoc();
            }
        }
        private void FilterCollection_ReferenceDoc()
        {
            if (_ReferenceDocSOCollection != null)
            {
                _ReferenceDocSOCollection.Refresh();
            }
            if (_ReferenceDocTOCollection != null)
            {
                _ReferenceDocTOCollection.Refresh();
            }
            if (_ReferenceDocMOCollection != null)
            {
                _ReferenceDocMOCollection.Refresh();
            }
            if (_ReferenceDocSDCollection != null)
            {
                _ReferenceDocSDCollection.Refresh();
            }
            if (_ReferenceDoc_TO_Item_Collection != null)
            {
                _ReferenceDoc_TO_Item_Collection.Refresh();
            }
            if (_ReferenceDocPOCollection != null)
            {
                _ReferenceDocPOCollection.Refresh();
            }

        }
        public bool Filter_ReferenceDoc(object obj)
        {
            var data = obj as Order_No_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_ReferenceDoc))
                {
                    return (data.order_no != null && data.order_no.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.party_name != null && data.party_name.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.doc_cat != null && data.doc_cat.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.order_no != null && data.order_no.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.PartyId != null && data.PartyId.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.cust_ref != null && data.cust_ref.ToLower().Contains(_FilterString_ReferenceDoc.ToLower())
                       );
                }
                return true;
            }
            return false;
        }

        private string _FilterString_ReferenceItem;
        public string FilterString_ReferenceItem
        {
            get { return _FilterString_ReferenceItem; }
            set
            {
                _FilterString_ReferenceItem = value;
                RaisePropertyChanged("FilterString_ReferenceItem");
                FilterCollection_ReferenceDoc();
            }
        }
        private void FilterCollection_ReferenceItem()
        {

            if (_ReferenceDoc_TO_Item_Collection != null)
            {
                _ReferenceDoc_TO_Item_Collection.Refresh();
            }

        }
        public bool Filter_ReferenceItem(object obj)
        {
            var data2 = obj as OrderItemData;
            if (data2 != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_ReferenceItem))
                {
                    return (data2.order_no != null && data2.order_no.ToLower().Contains(_FilterString_ReferenceItem.ToLower()) ||
                           data2.doc_date != null && data2.doc_date.ToString().ToLower().Contains(_FilterString_ReferenceItem.ToLower()) ||
                           data2.party_name != null && data2.party_name.ToLower().Contains(_FilterString_ReferenceItem.ToLower()) ||
                           data2.doc_cat != null && data2.doc_cat.ToLower().Contains(_FilterString_ReferenceItem.ToLower()) ||
                           data2.ItemCode != null && data2.ItemCode.ToLower().Contains(_FilterString_ReferenceItem.ToLower()) ||
                           data2.description != null && data2.description.ToLower().Contains(_FilterString_ReferenceItem.ToLower()) ||
                           data2.order_no != null && data2.order_no.ToLower().Contains(_FilterString_ReferenceItem.ToLower()) ||
                           data2.PartyId != null && data2.PartyId.ToLower().Contains(_FilterString_ReferenceItem.ToLower()) ||
                           data2.cust_ref != null && data2.cust_ref.ToLower().Contains(_FilterString_ReferenceItem.ToLower())
                       );
                }
                return true;
            }
            return false;
        }

        //public bool Filter_ReferenceDoc(object obj)
        //{
        //    var data = obj as Order_No_P;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_FilterString_ReferenceDoc))
        //        {
        //            return (data.order_no != null && data.order_no.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
        //                   data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
        //                   data.party_name != null && data.party_name.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
        //                   data.doc_cat != null && data.doc_cat.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
        //                   data.order_no != null && data.order_no.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
        //                   data.PartyId != null && data.PartyId.ToLower().Contains(_FilterString_ReferenceDoc.ToLower())
        //               );
        //        }
        //        return true;
        //    }
        //    return false;
        //}
        //public bool Filter_ReferenceDoc(object obj)
        //{
        //    var data = obj as OrderItemData;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_FilterString_ReferenceDoc))
        //        {
        //            return (data.order_no != null && data.order_no.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
        //                   data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
        //                   data.party_name != null && data.party_name.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
        //                   data.doc_cat != null && data.doc_cat.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
        //                   data.ItemCode != null && data.ItemCode.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
        //                   data.description != null && data.description.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
        //                   data.order_no != null && data.order_no.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
        //                   data.PartyId != null && data.PartyId.ToLower().Contains(_FilterString_ReferenceDoc.ToLower())
        //               );
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        #endregion
    }
}
