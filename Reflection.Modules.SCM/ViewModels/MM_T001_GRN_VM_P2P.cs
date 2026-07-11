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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Reflection.ReportingServices;

namespace Reflection.Modules.SCM.ViewModels
{
    public class MM_T001_GRN_VM_P2P : WorkspaceViewModel<MM_T001>
    {
        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = MasterEntity.HasErrors;
        }
        #region . Variable Declaration And Object .
        bool NewRecord = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        WebServiceRepository<MM_T001> repository = new WebServiceRepository<MM_T001>();
        WebServiceRepository<MC_MM_T001> repository_MC = new WebServiceRepository<MC_MM_T001>();

        ObjectSerializationService obj = new ObjectSerializationService();
        MC_MM_T001 _MC = new MC_MM_T001();
        public MC_MM_T001 MC
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

        MC_MM_T001 _MCTemp = new MC_MM_T001();
        public MC_MM_T001 MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value;

                    RaisePropertyChanged("MCTemp");
                }
            }
        }

        private MM_T001 _MasterEntity;
        public MM_T001 MasterEntity
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

        private ObservableCollection<MM_T001_A> _ItemDetailsEntity;
        public ObservableCollection<MM_T001_A> ItemDetailsEntity
        {
            get
            {
                return _ItemDetailsEntity;
            }
            set
            {
                if (_ItemDetailsEntity != value)
                {
                    _ItemDetailsEntity = value;
                    RaisePropertyChanged("ItemDetailsEntity");
                }
            }
        }

        private ObservableCollection<MM_T001_B> _BatchDetailsEntity;
        public ObservableCollection<MM_T001_B> BatchDetailsEntity
        {
            get
            {
                return _BatchDetailsEntity;
            }
            set
            {
                if (_BatchDetailsEntity != value)
                {
                    _BatchDetailsEntity = value;
                    RaisePropertyChanged("BatchDetailsEntity");
                }
            }
        }

        private ObservableCollection<MM_T001_C> _POAllocationEntity;
        public ObservableCollection<MM_T001_C> POAllocationEntity
        {
            get
            {
                return _POAllocationEntity;
            }
            set
            {
                if (_POAllocationEntity != value)
                {
                    _POAllocationEntity = value;
                    RaisePropertyChanged("POAllocationEntity");
                }
            }
        }

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
                    FilterBatchDataGrid();
                    FilterPoAllocationDataGrid();
                }
            }
        }

        private int _dgSelectedIndexBatch;
        public int dgSelectedIndexBatch
        {
            get
            {
                return _dgSelectedIndexBatch;
            }
            set
            {
                if (_dgSelectedIndexBatch != value)
                {
                    _dgSelectedIndexBatch = value;
                    RaisePropertyChanged("dgSelectedIndexBatch");
                }
            }
        }

        private int _dgSelectedIndexPOAllocation;
        public int dgSelectedIndexPOAllocation
        {
            get
            {
                return _dgSelectedIndexPOAllocation;
            }
            set
            {
                if (_dgSelectedIndexPOAllocation != value)
                {
                    _dgSelectedIndexPOAllocation = value;
                    RaisePropertyChanged("dgSelectedIndexPOAllocation");
                }
            }
        }

        private List<ADM_M031_P> _SelectedParaValueCollection = new List<ADM_M031_P>();
        public List<ADM_M031_P> SelectedParaValueCollection
        {
            get { return _SelectedParaValueCollection; }
            set
            {
                if (_SelectedParaValueCollection != value)
                {
                    _SelectedParaValueCollection = value;
                    RaisePropertyChanged("SelectedParaValueCollection");
                }
            }
        }

        public List<ADM_M003> _PlantList = new List<ADM_M003>();
        private List<ADM_M003> PlantList
        {
            get { return _PlantList; }
            set
            {
                if (_PlantList != value)
                {
                    _PlantList = value;
                }
            }
        }

        private List<PUR_T002_A_P> _DistinctRefDocNo = new List<PUR_T002_A_P>();
        public List<PUR_T002_A_P> DistinctRefDocNo
        {
            get { return _DistinctRefDocNo; }
            set
            {
                if (_DistinctRefDocNo != value)
                {
                    _DistinctRefDocNo = value;
                }
            }
        }

        private List<MM_M001> _StoreLocList = new List<MM_M001>();
        public List<MM_M001> StoreLocList
        {
            get { return _StoreLocList; }
            set
            {
                if (_StoreLocList != value)
                {
                    _StoreLocList = value;
                }
            }
        }

        private List<MM_T001_FLIP> _FlipGridData;
        public List<MM_T001_FLIP> FlipGridData
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

        private bool _parameter;
        public bool parameter
        {
            get { return _parameter; }
            set
            {
                if (_parameter != value)
                {
                    _parameter = value;
                    RaisePropertyChanged("parameter");
                }
            }
        }
        private bool _RefDocLoad;
        public bool RefDocLoad
        {
            get { return _RefDocLoad; }
            set
            {
                if (_RefDocLoad != value)
                {
                    _RefDocLoad = value;
                    RaisePropertyChanged("RefDocLoad");
                }
            }
        }

        private bool _MoveFlag;   //movement type enable disable
        public bool MoveFlag
        {
            get { return _MoveFlag; }
            set { _MoveFlag = value; RaisePropertyChanged("MoveFlag"); }
        }

        string store_location;

        private List<ADM_M031_P> _ParameterTemp = new List<ADM_M031_P>();
        public List<ADM_M031_P> ParameterTemp
        {
            get { return _ParameterTemp; }
            set
            {
                if (_ParameterTemp != value)
                {
                    _ParameterTemp = value;
                }
            }
        }

        public List<ADM_M001_M_P> _PurchaseOrganisationList;
        public List<ADM_M001_M_P> PurchaseOrganisationList
        {
            get
            {
                return _PurchaseOrganisationList;
            }
            set
            {
                _PurchaseOrganisationList = value;
                RaisePropertyChanged("PurchaseOrganisationList");
            }
        }

        public List<ADM_M001_P_P> _PurchaseGroupList;
        public List<ADM_M001_P_P> PurchaseGroupList
        {
            get
            {
                return _PurchaseGroupList;
            }
            set
            {
                _PurchaseGroupList = value;
                RaisePropertyChanged("PurchaseGroupList");
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

        #region . StringList Variables .

        List<string> _StringListSupplier;
        public List<string> StringListSupplier
        {
            get { return _StringListSupplier; }
            set
            {
                if (_StringListSupplier != value)
                {
                    _StringListSupplier = value;
                }
            }
        }

        List<string> _StringListTransporter;
        public List<string> StringListTransporter
        {
            get { return _StringListTransporter; }
            set
            {
                if (_StringListTransporter != value)
                {
                    _StringListTransporter = value;
                }
            }
        }

        List<string> _StringListMovType;
        public List<string> StringListMovType
        {
            get { return _StringListMovType; }
            set
            {
                if (_StringListMovType != value)
                {
                    _StringListMovType = value;
                }
            }
        }

        List<string> _StringListRefDocType;
        public List<string> StringListRefDocType
        {
            get { return _StringListRefDocType; }
            set
            {
                if (_StringListRefDocType != value)
                {
                    _StringListRefDocType = value;
                }
            }
        }

        List<string> _StringListRefDocNo;
        public List<string> StringListRefDocNo
        {
            get { return _StringListRefDocNo; }
            set
            {
                if (_StringListRefDocNo != value)
                {
                    _StringListRefDocNo = value;
                }
            }
        }

        List<string> _StringListItem;
        public List<string> StringListItem
        {
            get { return _StringListItem; }
            set
            {
                if (_StringListItem != value)
                {
                    _StringListItem = value;
                }
            }
        }

        List<string> _StringListUom;
        public List<string> StringListUom
        {
            get { return _StringListUom; }
            set
            {
                if (_StringListUom != value)
                {
                    _StringListUom = value;
                }
            }
        }

        List<string> _StringListStoreLoc;
        public List<string> StringListStoreLoc
        {
            get { return _StringListStoreLoc; }
            set
            {
                if (_StringListStoreLoc != value)
                {
                    _StringListStoreLoc = value;
                }
            }
        }

        List<string> _StringListItemCat;
        public List<string> StringListItemCat
        {
            get { return _StringListItemCat; }
            set
            {
                if (_StringListItemCat != value)
                {
                    _StringListItemCat = value;
                }
            }
        }

        List<string> _StringListPlant;
        public List<string> StringListPlant
        {
            get { return _StringListPlant; }
            set
            {
                if (_StringListPlant != value)
                {
                    _StringListPlant = value;
                }
            }
        }

        List<string> _StringListSendingPlant;
        public List<string> StringListSendingPlant
        {
            get { return _StringListSendingPlant; }
            set
            {
                if (_StringListSendingPlant != value)
                {
                    _StringListSendingPlant = value;
                }
            }
        }

        List<string> _StringListReceivingPlant;
        public List<string> StringListReceivingPlant
        {
            get { return _StringListReceivingPlant; }
            set
            {
                if (_StringListReceivingPlant != value)
                {
                    _StringListReceivingPlant = value;
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

        #endregion

        #region . ICollectionView .
        private ICollectionView _NotificationDataCollection;
        public ICollectionView NotificationDataCollection
        {
            get { return _NotificationDataCollection; }
            set { _NotificationDataCollection = value; RaisePropertyChanged("NotificationDataCollection"); }
        }

        private ICollectionView _AttachmentCollection;
        public ICollectionView AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set { _AttachmentCollection = value; RaisePropertyChanged("AttachmentCollection"); }
        }

        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }

        private ICollectionView _SupplierCollection;
        public ICollectionView SupplierCollection
        {
            get { return _SupplierCollection; }
            set { _SupplierCollection = value; RaisePropertyChanged("SupplierCollection"); }
        }

        private ICollectionView _TransporterPartyCollection;
        public ICollectionView TransporterPartyCollection
        {
            get { return _TransporterPartyCollection; }
            set { _TransporterPartyCollection = value; RaisePropertyChanged("TransporterPartyCollection"); }
        }

        private ICollectionView _MovementTypeCollection;
        public ICollectionView MovementTypeCollection
        {
            get { return _MovementTypeCollection; }
            set { _MovementTypeCollection = value; RaisePropertyChanged("MovementTypeCollection"); }
        }

        private ICollectionView _RefDocTypeCollection;
        public ICollectionView RefDocTypeCollection
        {
            get { return _RefDocTypeCollection; }
            set { _RefDocTypeCollection = value; RaisePropertyChanged("RefDocTypeCollection"); }
        }

        private ICollectionView _RefDocNoCollection;
        public ICollectionView RefDocNoCollection
        {
            get { return _RefDocNoCollection; }
            set { _RefDocNoCollection = value; RaisePropertyChanged("RefDocNoCollection"); }
        }

        private ICollectionView _ItemCollection;
        public ICollectionView ItemCollection
        {
            get { return _ItemCollection; }
            set { _ItemCollection = value; RaisePropertyChanged("ItemCollection"); }
        }
        private ICollectionView _UOMCollection;
        public ICollectionView UOMCollection
        {
            get { return _UOMCollection; }
            set { _UOMCollection = value; RaisePropertyChanged("UOMCollection"); }
        }
        private ICollectionView _StoreLocCollection;
        public ICollectionView StoreLocCollection
        {
            get { return _StoreLocCollection; }
            set { _StoreLocCollection = value; RaisePropertyChanged("StoreLocCollection"); }
        }
        private ICollectionView _ItemCatCollection;
        public ICollectionView ItemCatCollection
        {
            get { return _ItemCatCollection; }
            set { _ItemCatCollection = value; RaisePropertyChanged("ItemCatCollection"); }
        }

        private ICollectionView _PlantCollection;
        public ICollectionView PlantCollection
        {
            get { return _PlantCollection; }
            set { _PlantCollection = value; RaisePropertyChanged("PlantCollection"); }
        }

        private ICollectionView _ParameterCollection;
        public ICollectionView ParameterCollection
        {
            get { return _ParameterCollection; }
            set
            {
                _ParameterCollection = value;
                RaisePropertyChanged("ParameterCollection");
            }
        }

        private ICollectionView _ParameterValueCollection;
        public ICollectionView ParameterValueCollection
        {
            get { return _ParameterValueCollection; }
            set
            {
                _ParameterValueCollection = value;
                RaisePropertyChanged("ParameterValueCollection");
            }
        }

        private ICollectionView _POCollection;
        public ICollectionView POCollection
        {
            get { return _POCollection; }
            set { _POCollection = value; RaisePropertyChanged("POCollection"); }
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
        private ICollectionView _DataGridView1;
        public ICollectionView DataGridView1
        {
            get { return _DataGridView1; }
            set
            {
                _DataGridView1 = value;
                RaisePropertyChanged("DataGridView1");
            }
        }
        private ICollectionView _SendingPlant;
        public ICollectionView SendingPlant
        {
            get { return _SendingPlant; }
            set
            {
                _SendingPlant = value;
                RaisePropertyChanged("SendingPlant");
            }
        }
        private ICollectionView _ReceivingPlant;
        public ICollectionView ReceivingPlant
        {
            get { return _ReceivingPlant; }
            set
            {
                _ReceivingPlant = value;
                RaisePropertyChanged("ReceivingPlant");
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
        #endregion

        #region . Relay Commands .
        public RelayCommand<object> CommandSendingPlant { get; private set; }
        public RelayCommand<object> CommandRecPlant { get; private set; }
        public RelayCommand<object> CommandTransporterParty { get; private set; }
        public RelayCommand<object> CommandMovementType { get; private set; }
        public RelayCommand<object> CommandRedDocType { get; private set; }
        public RelayCommand<object> CommandRefDocNo { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByRefDocNo { get; private set; }
        public RelayCommand ExportCommand { get; private set; }
        public RelayCommand<object> CommandPurchaseOrg { get; private set; }
        public RelayCommand<object> CommandPurchaseGroup { get; private set; }
        // Item Details
        public RelayCommand<object> CommandInsertItem { get; private set; }
        public RelayCommand<object> CommandUOM { get; private set; }
        public RelayCommand<object> CommandPlant { get; private set; }
        public RelayCommand<object> CommandStoreLoc { get; private set; }
        public RelayCommand<object> CommandItemCat { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowItem { get; private set; }
        public RelayCommand<IList> CreatePOCollectionCommand { get; private set; }
        public RelayCommand BatchSplitClick { get; private set; }
        public RelayCommand<IList> SelectionChangeCommandItemDetails { get; private set; }
        public RelayCommand<object> ActiveInActiveChangeCommand { get; private set; }
        // Parameter Commands
        public RelayCommand<IList> CollectionChangedCommand { get; private set; }
        public RelayCommand<IList> SelectionChangedParaValCommand { get; private set; }

        //Batch
        public RelayCommand<object> BatchDataGridRowDeleteCommand { get; private set; }

        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }

        // PO Allocation
        public RelayCommand<object> CommandPO { get; private set; }
        public RelayCommand<object> PoAllocationDataGridRowDeleteCommand { get; private set; }
        public RelayCommand cmdLoadRecords { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region . Constructor .
        public MM_T001_GRN_VM_P2P(string ts_code)
                : base()
            {
            this.ts_code_vm = ts_code;
            RefDocLoad = true;
            parameter = false;
            MoveFlag = true;
            // MM_T001.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            MC = new MC_MM_T001();
            MCTemp = new MC_MM_T001();
            MasterEntity = new MM_T001();
            ItemDetailsEntity = new ObservableCollection<MM_T001_A>();
            BatchDetailsEntity = new ObservableCollection<MM_T001_B>();
            POAllocationEntity = new ObservableCollection<MM_T001_C>();
            MasterEntity.ValidateAsync().Wait();

            MM_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            MM_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Batch);
            //ItemDetailsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            BatchDetailsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
        //  POAllocationEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForPoAllocation);


           
            LoadInitialData();
        }
        public MM_T001_GRN_VM_P2P(string ts_code,string doc_no)
                : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            RefDocLoad = true;
            parameter = false;
            MoveFlag = true;
            // MM_T001.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            MC = new MC_MM_T001();
            MCTemp = new MC_MM_T001();
            MasterEntity = new MM_T001();
            ItemDetailsEntity = new ObservableCollection<MM_T001_A>();
            BatchDetailsEntity = new ObservableCollection<MM_T001_B>();
            POAllocationEntity = new ObservableCollection<MM_T001_C>();
            MasterEntity.ValidateAsync().Wait();

            MM_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            MM_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Batch);
            //ItemDetailsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            BatchDetailsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
            //  POAllocationEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForPoAllocation);

            LoadInitialData();
        }
        #endregion

        #region . User Defined Functions .

        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = "GR";
            MasterEntity.doc_type = "GR";
            MasterEntity.doc_code = "GR";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.dept_code = AppSessionState.dept_code;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            
            MasterEntity.t_status = "001";
            MasterEntity.t_display = (from o in MC.t_statusList where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();

            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.post_date = DateTime.Now;
            MasterEntity.fin_year = "15-16";
            MasterEntity.posting_period = "1";
            MasterEntity.mov_tp = "106";
            MasterEntity.mov_name = "Plant to Plant Transfer";      
            MasterEntity.bf_FromDate = DateTime.Now;
            MasterEntity.bf_ToDate = DateTime.Now;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.EmpId = AppSessionState.EmpId;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
        }
        private void LoadInitialData()
        {
            try
            {
                MasterEntity.doc_cat = "GR";
                MasterEntity.doc_type = "GR";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + "106" + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "GoodsReceiptNote", "SCM", "LoadAll", 0, "");

                #region . Command Initialization .
                //ExportCommand = new RelayCommand(() => { OnExportAction(); });
                CommandSendingPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertSendingPlant(items); });
                CommandRecPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertRecPlant(items); });
                CommandTransporterParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertTransporterParty(items); });
                CommandMovementType = new RelayCommand<object>(items => { if (items == null) { return; } InsertMovementType(items); });
                CommandRedDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertRedDocType(items); });
                CommandRefDocNo = new RelayCommand<object>(items => { if (items == null) { return; } InsertRefDocNo(items); });
                CommandLoadDocumentByRefDocNo = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByRefDocNo(items); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
                CommandPurchaseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseOrg(items); });
                CommandPurchaseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseGroup(items); });

                // Item Details
                CommandInsertItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertDataGridRow_Item(items, true, true, true); });
                CommandUOM = new RelayCommand<object>(items => { if (items == null) { return; } InsertUOM(items, false, true, true); });
                CommandPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items, false, true, true); });
                CommandStoreLoc = new RelayCommand<object>(items => { if (items == null) { return; } InsertStoreLoc(items, false, true, true); });
                CommandItemCat = new RelayCommand<object>(items => { if (items == null) { return; } InsertItemCat(items, false, true, true); });
                CommandDeleteDataGridRowItem = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_Item(items); });
                CreatePOCollectionCommand = new RelayCommand<IList>(items => { if (items == null) { return; } CreatePOCollectionMethod(items); });
                BatchSplitClick = new RelayCommand(() => { BatchSplit(); });
                SelectionChangeCommandItemDetails = new RelayCommand<IList>(items => { if (items == null) { return; } ItemDetailsSelectionChangedMethod(items); });
                ActiveInActiveChangeCommand = new RelayCommand<object>(items => { if (items == null) { return; } ItemActiveInActiveMethod(items); });
                // Item Description Parameter
                CollectionChangedCommand = new RelayCommand<IList>(items => { if (items == null) { return; } CollectionChanged(items); });
                SelectionChangedParaValCommand = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedParaValue(items); });

                //Batch
                BatchDataGridRowDeleteCommand = new RelayCommand<object>(items => { if (items == null) { return; } DeleteBatchDataGridRow_Item(items); });

                //PO Allocation
                CommandPO = new RelayCommand<object>(items => { if (items == null) { return; } InsertDataGridRow_POAllocation(items, true, true, true); });
                PoAllocationDataGridRowDeleteCommand = new RelayCommand<object>(items => { if (items == null) { return; } DeletePoAllocationDataGridRow_Item(items); });
                cmdLoadRecords = new RelayCommand(() => { LoadRecords(); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion

                FlipGridData = MC.FlipGridList;
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_BackFlip);

                SupplierCollection = CollectionViewSource.GetDefaultView(MC.PartyList);
                SupplierCollection.Filter = new Predicate<object>(Filter_SupplierParty);
                StringListSupplier = MC.PartyList.Select(x => x.PartyId).ToList();

                TransporterPartyCollection = CollectionViewSource.GetDefaultView(MC.TransporterList);
                TransporterPartyCollection.Filter = new Predicate<object>(Filter_TransParty);
                StringListTransporter = MC.TransporterList.Select(x => x.PartyId).ToList();

                MovementTypeCollection = CollectionViewSource.GetDefaultView(MC.MovementTypeList);
                MovementTypeCollection.Filter = new Predicate<object>(Filter_MovType);
                StringListMovType = MC.MovementTypeList.Select(x => x.mov_tp).ToList();

                RefDocTypeCollection = CollectionViewSource.GetDefaultView(MC.DocTypeList);
                //RefDocTypeCollection.Filter = new Predicate<object>();
                StringListRefDocType = MC.DocTypeList.Select(x => x.doc_type_user).ToList();

                DistinctRefDocNo = MC.SourceDocNoList.GroupBy(PUR_T002_A_P => PUR_T002_A_P.po_no).Select(g => g.First()).ToList();
                RefDocNoCollection = CollectionViewSource.GetDefaultView(DistinctRefDocNo.ToList());
                RefDocNoCollection.Filter = new Predicate<object>(Filter_RefDocNo);
                StringListRefDocNo = MC.SourceDocNoList.Select(x => x.po_no).ToList();

                ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
                ItemCollection.Filter = new Predicate<object>(Filter_Item);
                StringListItem = MC.ItemList.Select(x => x.ItemCode).ToList();

                UOMCollection = CollectionViewSource.GetDefaultView(MC.UOMList);
                UOMCollection.Filter = new Predicate<object>(Filter_UOM);
                StringListUom = MC.UOMList.Select(x => x.unit_code).ToList();

                StoreLocList = (List<MM_M001>)AppSessionState.store_location;
                StoreLocCollection = CollectionViewSource.GetDefaultView(StoreLocList);
                StoreLocCollection.Filter = new Predicate<object>(Filter_StoreLoc);
                //store_location = (from o in StoreLocList
                //                  where o.location_Id == AppSessionState.location_Id //&& o.default_storage_loc == Convert.ToBoolean(1)
                //                  select o.store_code).ToList()[0];
                //StringListStoreLoc = StoreLocList.Select(x => x.store_code).ToList();
                StoreLocList = (List<MM_M001>)AppSessionState.store_location;
                //store_location = (from o in StoreLocList
                //                  where o.location_Id == AppSessionState.location_Id //&& o.default_storage_loc == Convert.ToBoolean(1)
                //                  select o.store_code).ToList()[0];
                if ((from o in StoreLocList
                     where o.location_Id == AppSessionState.location_Id //&& o.default_storage_loc == Convert.ToBoolean(1)
                     select o.store_code).ToList().Count == 1)
                {
                    store_location = (from o in StoreLocList where o.location_Id == AppSessionState.location_Id select o.store_code).ToList()[0];
                }

                ItemCatCollection = CollectionViewSource.GetDefaultView(MC.ItemCatList);
                ItemCatCollection.Filter = new Predicate<object>(Filter_ItemCategory);
                StringListItemCat = MC.ItemCatList.Select(x => x.item_cat).ToList();

                PlantList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(PlantList);
                PlantCollection.Filter = new Predicate<object>(Filter_Plant);
                StringListPlant = PlantList.Select(x => x.location_Id).ToList();

                SendingPlant = CollectionViewSource.GetDefaultView(PlantList);
                SendingPlant.Filter = new Predicate<object>(Filter_SendingPlant);
                StringListSendingPlant = PlantList.Select(x => x.location_Id).ToList();

                ReceivingPlant = CollectionViewSource.GetDefaultView(PlantList);
                ReceivingPlant.Filter = new Predicate<object>(Filter_RecPlant);
                StringListReceivingPlant = PlantList.Select(x => x.location_Id).ToList();

                NotificationDataCollection = CollectionViewSource.GetDefaultView(MC.NotificationData);

                PurchaseOrganisationList = (List<ADM_M001_M_P>)AppSessionState.ADM_M001_M_List;
                po_orgCollection = CollectionViewSource.GetDefaultView(PurchaseOrganisationList);
                po_orgCollection.Filter = new Predicate<object>(Purorg_Filter);
                StringListPurchaseOrg = PurchaseOrganisationList.Select(x => x.po_code).ToList();

                if (PurchaseOrganisationList.Count != 0)
                {
                    if (PurchaseOrganisationList.Count == 1)
                    {
                        MasterEntity.po_code = PurchaseOrganisationList[0].po_code;
                        MasterEntity.pur_org = PurchaseOrganisationList[0].pur_org;
                    }
                }
                else
                {
                    MasterEntity.po_code = "";
                }

                PurchaseGroupList = (List<ADM_M001_P_P>)AppSessionState.ADM_M001_P_List;
                Purchase_groupCollection = CollectionViewSource.GetDefaultView(PurchaseGroupList);
                Purchase_groupCollection.Filter = new Predicate<object>(Purchase_grp_Filter);
                StringListPurchaseGroup = PurchaseGroupList.Select(x => x.pg_code).ToList();

                if (PurchaseGroupList.Count != 0)
                {
                    if (PurchaseGroupList.Count == 1)
                    {
                        MasterEntity.pg_code = PurchaseGroupList[0].pg_code;
                        MasterEntity.pg_name = PurchaseGroupList[0].pg_name;
                    }
                }
                else
                {
                    MasterEntity.pg_code = "";
                }

                DefaultValues();
                MasterEntity.source_doc_type = "TO";
                MasterEntity.source_doc_cat = "TO";
                MasterEntity.rec_plant = AppSessionState.location_Id;
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
        private void LoadDocumentByRefDocNo(object InputValue)   // this method is little complicated and lengthy need to optimize : pending optimization
        {
            try
            {

                if (MasterEntity.source_doc_no != null || MasterEntity.source_doc_no != "")
                {
                    if (MasterEntity.source_doc_no == InputValue.ToString())
                    {
                        string transmodetemp = MasterEntity.tr_mode;

                        string RequestParameterData = "OrderLoad" + "!@" + InputValue.ToString() + "!@" + MasterEntity.source_doc_cat;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MCTemp, RequestParameterData, "GoodsReceiptNote", "SCM", "OrderLoad", 0, "");

                        if (MCTemp.GRNMasterList.Count > 0)
                        {
                            MasterEntity = new MM_T001();
                            ItemDetailsEntity = new ObservableCollection<MM_T001_A>();
                            BatchDetailsEntity = new ObservableCollection<MM_T001_B>();
                            POAllocationEntity = new ObservableCollection<MM_T001_C>();

                            MasterEntity = MCTemp.GRNMasterList[0];
                            DefaultValues();
                            MasterEntity.source_doc_cat = MCTemp.GRNMasterList[0].source_doc_cat;
                            MasterEntity.source_doc_type = MCTemp.GRNMasterList[0].source_doc_type;

                            MasterEntity.location_Id = MCTemp.GRNMasterList[0].rec_plant;
                            MasterEntity.rec_plant = MCTemp.GRNMasterList[0].rec_plant;
                            MasterEntity.recplantnm = MCTemp.GRNMasterList[0].recplantnm;
                            MasterEntity.tr_mode = transmodetemp;

                            ItemDetailsEntity = MCTemp.ItemDetailsList;
                            BatchDetailsEntity = MCTemp.BatchDetailsList;

                            foreach (var o in MCTemp.ItemDetailsList)
                            {
                                //var InputValueIfExists = ItemDetailsEntity.Where(X => X.ItemCode == o.ItemCode && X.sku == o.sku).FirstOrDefault(); // Prefer Primary Key for this instruction.
                                //int IndexOfExistValue = ItemDetailsEntity.IndexOf(ItemDetailsEntity.Where(X => X.ItemCode == o.ItemCode && X.sku == o.sku).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                                //if (IndexOfExistValue == -1)
                                //{
                                //    o.add_by = AppSessionState.UserID;
                                //    o.editby = AppSessionState.UserID;
                                //    o.location_Id = MasterEntity.location_Id;
                                //    o.comp_code = AppSessionState.comp_code;
                                //    o.store_code = store_location;

                                //    o.t_status = "001";
                                //    o.t_display = (from o1 in MC.t_statusList where o1.t_status == MasterEntity.t_status select o1.t_display).FirstOrDefault();

                                //    o.doc_type = "GR";
                                //    o.doc_cat = "GR";
                                //    o.doc_date = MasterEntity.doc_date;
                                //    o.source_doc_type = MasterEntity.source_doc_type;
                                //    o.line_id = ItemDetailsEntity.Count + 1;
                                //    o.client = AppSessionState.client;
                                //    //o.order_doc_item_id = 

                                //    ItemDetailsEntity.Add(o);

                                //}

                                o.add_by = AppSessionState.UserID;
                                o.editby = AppSessionState.UserID;
                                o.comp_code = AppSessionState.comp_code;

                                //o.t_status = "001";
                                o.t_display = (from o1 in MC.t_statusList where o1.t_status == MasterEntity.t_status select o1.t_display).FirstOrDefault();

                              
                                //o.doc_date = MasterEntity.doc_date;
                                //o.source_doc_type = MasterEntity.source_doc_type;
                                //o.line_id = ItemDetailsEntity.Count + 1;
                                //o.client = AppSessionState.client;


                                var InputValueIfExists1 = POAllocationEntity.Where(X => X.ItemCode == o.ItemCode && X.sku == o.sku && X.po_no == o.source_doc_no).FirstOrDefault(); // Prefer Primary Key for this instruction.
                                int IndexOfExistValue1 = POAllocationEntity.IndexOf(POAllocationEntity.Where(X => X.ItemCode == o.ItemCode && X.sku == o.sku && X.po_no == o.source_doc_no).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                                if (IndexOfExistValue1 == -1)
                                {
                                    POAllocationEntity.Add(new MM_T001_C()
                                    {
                                        doc_no = MasterEntity.doc_no,
                                        ItemCode = o.ItemCode,
                                        po_no = o.po_no,
                                        sku = o.sku,
                                        po_qty = Convert.ToDecimal(o.po_qty),
                                        allocated_qty = Convert.ToDecimal(o.po_qty),
                                        active = true,
                                        add_by = AppSessionState.UserID,
                                        comp_code = AppSessionState.comp_code,
                                        location_Id = MasterEntity.location_Id
                                    });
                                }
                            }
                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Invalid Reference Doc Number!", this.Title);
                        showMessageService.ShowMessage();
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Reference Document Number!", this.Title);
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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {

                MM_T001_FLIP ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<MM_T001_FLIP>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<MM_T001_FLIP>().ToList()[0];
                        NewRecord = false; MoveFlag = false;
                        parameter = false; RefDocLoad = false;
                        string RequestParameterData = "GRNDetails" + "!@" + ParameterEntityObject.doc_no;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MCTemp, RequestParameterData, "GoodsReceiptNote", "SCM", "GRNDetails", 0, "");
                        SelectedTabControlIndex = 0;
                        MasterEntity = MCTemp.GRNMasterList[0];
                        ItemDetailsEntity = MCTemp.ItemDetailsList;
                        BatchDetailsEntity = MCTemp.BatchDetailsList;
                        POAllocationEntity = MCTemp.POAllocDetailsList;
                        MasterEntity.ts_code = ts_code_vm;

                        AttachmentCollection = CollectionViewSource.GetDefaultView(MC.Attachment);
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
        private void LoadRecords()
        {
            if (MasterEntity.bf_FromDate == null || MasterEntity.bf_ToDate == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select From Date And To Date Before Loading");
                showMessageService.ShowMessage();
            }
            else
            {
                MasterEntity.doc_cat = "GR";
                MasterEntity.doc_type = "GR";

                string Request = "LoadRecordsofSelectedDate" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + "106" + "!@" + AppSessionState.EmpId + "!@" + Convert.ToDateTime(MasterEntity.bf_FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.bf_ToDate).ToString("MM/dd/yyyy");
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MCTemp, Request, "GoodsReceiptNote", "SCM", "LoadRecordsofSelectedDate", 0, "");

                FlipGridData = MCTemp.FlipGridList;
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_BackFlip);

            }
        }
        private void InsertSendingPlant(object InputValue)
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
                            { POPUPEntityObject = PlantList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.sending_plant = POPUPEntityObject.location_Id;
                    MasterEntity.sendplantnm = POPUPEntityObject.LoctnNm;
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
                            { POPUPEntityObject = PlantList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
        private void InsertTransporterParty(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.TransporterList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.tr_party = POPUPEntityObject.PartyId;
                    MasterEntity.tranp_agency_name = POPUPEntityObject.PartyNm;
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
        private void InsertMovementType(object InputValue)
        {
            try
            {

                string Request = "";
                MM_M004_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.MovementTypeList.Where(x => x.mov_tp.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M004_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.mov_tp = POPUPEntityObject.mov_tp;
                    MasterEntity.mov_name = POPUPEntityObject.mov_tp_name;
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
        private void InsertRedDocType(object InputValue)
        {
            try
            {

                string Request = "";
                SYS_M007_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.DocTypeList.Where(x => x.doc_type_user.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M007_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.source_doc_type = POPUPEntityObject.doc_type_user;     // source doc contains user doc type           
                    MasterEntity.source_doc_cat = POPUPEntityObject.doc_cat;
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
        private void InsertRefDocNo(object InputValue)
        {
            try
            {

                string Request = "";
                PUR_T002_A_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.SourceDocNoList.Where(x => x.po_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PUR_T002_A_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.source_doc_no = POPUPEntityObject.po_no;
                    MasterEntity.source_doc_cat = POPUPEntityObject.doc_cat;
                    MasterEntity.source_doc_type = POPUPEntityObject.doc_type;
                    
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
        private void InsertPurchaseOrg(object InputValue)
        {
            try
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
                            { POPUPEntityObject = PurchaseOrganisationList.Where(x => x.po_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_M_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.po_code = POPUPEntityObject.po_code;
                    MasterEntity.pur_org = POPUPEntityObject.pur_org;
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
        private void InsertPurchaseGroup(object InputValue)
        {
            try
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
                            { POPUPEntityObject = PurchaseGroupList.Where(x => x.pg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_P_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.pg_code = POPUPEntityObject.pg_code;
                    MasterEntity.pg_name = POPUPEntityObject.pg_name;
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
        // Item Details Functions
        private void InsertDataGridRow_Item(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                ADM_M022_P POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.ItemPopupList.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemDetailsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemDetailsEntity.IndexOf(ItemDetailsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemDetailsEntity.Count == dgSelectedIndexItem)
                    {
                        ItemDetailsEntity.Add(new MM_T001_A()
                        {
                            id = 0,
                            ItemCode = POPUPEntityObject.ItemCode,
                            description = POPUPEntityObject.ItemName,
                            unit_code = POPUPEntityObject.unit_code,
                            StockUnt = POPUPEntityObject.StockUnt,
                            SubCatCode = POPUPEntityObject.SubCatCode,
                            source_doc_no = MasterEntity.source_doc_no,
                            source_doc_type = MasterEntity.source_doc_type,
                            line_id = 0,
                            PartyId = MasterEntity.PartyId,
                            comp_code = AppSessionState.comp_code,
                            location_Id = MasterEntity.rec_plant,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,
                            fin_year = "15-16",
                            posting_period = "1",
                            
                            t_status = "001",
                            t_display = (from o1 in MC.t_statusList where o1.t_status == MasterEntity.t_status select o1.t_display).FirstOrDefault(),

                            active = true,
                            batch_split = false,
                            store_code = store_location,
                            debcr_ind = "C"
                        });
                    }
                    else if (dgSelectedIndexItem >= 0 && ItemDetailsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemDetailsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
                            ItemDetailsEntity[dgSelectedIndexItem].description = POPUPEntityObject.ItemName;
                            ItemDetailsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                            ItemDetailsEntity[dgSelectedIndexItem].qty = POPUPEntityObject.qty;
                            ItemDetailsEntity[dgSelectedIndexItem].StockUnt = POPUPEntityObject.StockUnt;
                            ItemDetailsEntity[dgSelectedIndexItem].SubCatCode = POPUPEntityObject.SubCatCode;
                            ItemDetailsEntity[dgSelectedIndexItem].source_doc_no = MasterEntity.source_doc_no;
                            ItemDetailsEntity[dgSelectedIndexItem].source_doc_type = MasterEntity.source_doc_type;

                            ItemDetailsEntity[dgSelectedIndexItem].active = true;
                            ItemDetailsEntity[dgSelectedIndexItem].line_id = 0;
                            ItemDetailsEntity[dgSelectedIndexItem].PartyId = MasterEntity.PartyId;
                            ItemDetailsEntity[dgSelectedIndexItem].batch_split = false;
                            ItemDetailsEntity[dgSelectedIndexItem].store_code = store_location;
                            //ItemDetailsEntity[dgSelectedIndexItem].debcr_ind = "C";
                        }
                        else if (ItemDetailsEntity[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].ItemCode = "";
                            ItemDetailsEntity[dgSelectedIndexItem].description = "";
                        }
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
        private void InsertUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                //AppSessionState.StringListValue = StringListUom;
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
                        { POPUPEntityObject = MC.UOMList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemDetailsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemDetailsEntity.IndexOf(ItemDetailsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemDetailsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemDetailsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (ItemDetailsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].unit_code = "";
                        }
                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
                for (int i = ItemDetailsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemDetailsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemDetailsEntity[i].ComparePropertiesTo(newObj) == true && ItemDetailsEntity.Count > 1)
                    {
                        ItemDetailsEntity.RemoveAt(i);
                        if (ItemDetailsEntity.Count == 0)
                        {
                            ItemDetailsEntity.Add(newObj);
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
        
        private void InsertPlant(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                //AppSessionState.StringListValue = StringListUom;
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
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
                        { POPUPEntityObject = PlantList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M003>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemDetailsEntity.Where(X => X.location_Id == POPUPEntityObject.location_Id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemDetailsEntity.IndexOf(ItemDetailsEntity.Where(X => X.location_Id == POPUPEntityObject.location_Id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemDetailsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemDetailsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].location_Id = POPUPEntityObject.location_Id;
                        }
                        else if (ItemDetailsEntity[dgSelectedIndexItem].location_Id != POPUPEntityObject.location_Id)
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].location_Id = "";
                        }
                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
                for (int i = ItemDetailsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemDetailsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemDetailsEntity[i].ComparePropertiesTo(newObj) == true && ItemDetailsEntity.Count > 1)
                    {
                        ItemDetailsEntity.RemoveAt(i);
                        if (ItemDetailsEntity.Count == 0)
                        {
                            ItemDetailsEntity.Add(newObj);
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
        
        private void InsertStoreLoc(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                //AppSessionState.StringListValue = StringListUom;
                string Request = "";
                MM_M001 POPUPEntityObject = null;
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
                        { POPUPEntityObject = StoreLocList.Where(x => x.store_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<MM_M001>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M001>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemDetailsEntity.Where(X => X.store_code == POPUPEntityObject.store_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemDetailsEntity.IndexOf(ItemDetailsEntity.Where(X => X.store_code == POPUPEntityObject.store_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemDetailsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemDetailsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].store_code = POPUPEntityObject.store_code;
                        }
                        else if (ItemDetailsEntity[dgSelectedIndexItem].store_code != POPUPEntityObject.store_code)
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].store_code = "";
                        }
                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
                for (int i = ItemDetailsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemDetailsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemDetailsEntity[i].ComparePropertiesTo(newObj) == true && ItemDetailsEntity.Count > 1)
                    {
                        ItemDetailsEntity.RemoveAt(i);
                        if (ItemDetailsEntity.Count == 0)
                        {
                            ItemDetailsEntity.Add(newObj);
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
        private void InsertItemCat(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                //AppSessionState.StringListValue = StringListUom;
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
                        { POPUPEntityObject = MC.ItemCatList.Where(x => x.item_cat.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    var InputValueIfExists = ItemDetailsEntity.Where(X => X.item_cat == POPUPEntityObject.item_cat).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemDetailsEntity.IndexOf(ItemDetailsEntity.Where(X => X.item_cat == POPUPEntityObject.item_cat).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemDetailsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemDetailsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].item_cat = POPUPEntityObject.item_cat;
                        }
                        else if (ItemDetailsEntity[dgSelectedIndexItem].item_cat != POPUPEntityObject.item_cat)
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].item_cat = "";
                        }
                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
                for (int i = ItemDetailsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemDetailsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemDetailsEntity[i].ComparePropertiesTo(newObj) == true && ItemDetailsEntity.Count > 1)
                    {
                        ItemDetailsEntity.RemoveAt(i);
                        if (ItemDetailsEntity.Count == 0)
                        {
                            ItemDetailsEntity.Add(newObj);
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
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            try
            {
                if (sender.ToString() == "qty" && dgSelectedIndexItem != -1 && dgSelectedIndexItem < ItemDetailsEntity.Count)
                {
                    var InputValueIfExists2 = POAllocationEntity.Where(X => X.ItemCode == ItemDetailsEntity[dgSelectedIndexItem].ItemCode && X.sku == ItemDetailsEntity[dgSelectedIndexItem].sku && X.po_no == ItemDetailsEntity[dgSelectedIndexItem].source_doc_no).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue2 = POAllocationEntity.IndexOf(POAllocationEntity.Where(X => X.ItemCode == ItemDetailsEntity[dgSelectedIndexItem].ItemCode && X.sku == ItemDetailsEntity[dgSelectedIndexItem].sku && X.po_no == ItemDetailsEntity[dgSelectedIndexItem].source_doc_no).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (IndexOfExistValue2 != -1)
                    {
                        POAllocationEntity[IndexOfExistValue2].allocated_qty = Convert.ToDecimal(ItemDetailsEntity[dgSelectedIndexItem].qty);
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
                if (ItemDetailsEntity.Count > i && ItemDetailsEntity[i].id == 0)
                {
                    if (BatchDetailsEntity.Count > 0)
                    {
                        //  before Deleting Item Its Batches Will be removed 

                        for (int j = BatchDetailsEntity.Count - 1; j >= 0; j--)
                        {
                            if (ItemDetailsEntity[i].ItemCode == BatchDetailsEntity[j].ItemCode && ItemDetailsEntity[i].sku == BatchDetailsEntity[j].sku)
                            {
                                BatchDetailsEntity.Remove(BatchDetailsEntity[j]);
                            }
                        }
                    }

                    if (POAllocationEntity.Count > 0)
                    {
                        //  before Deleting Item PO Allocation of the Item Will be removed 
                        for (int j = POAllocationEntity.Count - 1; j >= 0; j--)
                        {
                            if (ItemDetailsEntity[i].ItemCode == POAllocationEntity[j].ItemCode && ItemDetailsEntity[i].sku == POAllocationEntity[j].sku)
                            {
                                POAllocationEntity.Remove(POAllocationEntity[j]);
                            }
                        }
                    }
                    //  Now Item Will be Removed From Item Details
                    ItemDetailsEntity.RemoveAt(i);
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
        private void CreatePOCollectionMethod(IList InputValue)
        {
            if (dgSelectedIndexItem != -1 && ItemDetailsEntity.Count > 0 && MC.SourceDocNoList.Count > 0 && dgSelectedIndexItem < ItemDetailsEntity.Count)
            {
                var pocollectiontemp = (from o in MC.SourceDocNoList where o.ItemCode == ItemDetailsEntity[dgSelectedIndexItem].ItemCode && o.sku == ItemDetailsEntity[dgSelectedIndexItem].sku select o).ToList();
                POCollection = CollectionViewSource.GetDefaultView(pocollectiontemp.ToList());
            }
        }
        private void BatchSplit()
        {
            if (dgSelectedIndexItem != -1 && ItemDetailsEntity.Count > 0)
            {
                if (ItemDetailsEntity[dgSelectedIndexItem].batch_split == true)
                {
                    batchdatagrid = true; // if batch split checkbox is checked then only batchsplit is allowed
                }
                else
                {
                    batchdatagrid = false;
                }
            }
        }
        private void ItemDetailsSelectionChangedMethod(IList InputList)
        {
            IList list = InputList as IList;
            try
            {
                if (dgSelectedIndexItem != -1 && ItemDetailsEntity.Count > 0 && ItemDetailsEntity.Count > dgSelectedIndexItem)
                {
                    List<MM_T001_A> selectedlist = list.Cast<MM_T001_A>().ToList();

                    if (selectedlist.Count > 0)
                    {
                        if (ItemDetailsEntity[dgSelectedIndexItem].batch_split == true)
                        {
                            batchdatagrid = true; // if batch split checkbox is checked then only batchsplit is allowed
                        }
                        else
                        {
                            batchdatagrid = false;
                        }

                        if (ItemDetailsEntity[dgSelectedIndexItem].id == 0 && ItemDetailsEntity[dgSelectedIndexItem].StockUnt == true)
                        {
                            parameter = true;
                        }
                        else
                        {
                            parameter = false;
                        }
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
        //private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        //{

        //}

        //Batch Details Functions
        private void FilterBatchDataGrid()
        {
            try
            {
                if (BatchDetailsEntity != null && BatchDetailsEntity.Count > 0 && dgSelectedIndexItem < BatchDetailsEntity.Count && dgSelectedIndexItem >= 0)
                {
                    DataGridView = CollectionViewSource.GetDefaultView(BatchDetailsEntity);
                    if (ItemDetailsEntity[dgSelectedIndexItem].sku == null)
                    {
                        DataGridView.Filter = adv => ((MM_T001_B)adv).ItemCode.Equals(ItemDetailsEntity[dgSelectedIndexItem].ItemCode);
                    }
                    else
                    {
                        DataGridView.Filter = adv => ((MM_T001_B)adv).ItemCode.Equals(ItemDetailsEntity[dgSelectedIndexItem].ItemCode) && ((MM_T001_B)adv).sku.Equals(ItemDetailsEntity[dgSelectedIndexItem].sku);
                    }

                    DataGridView.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }
        private void FilterPoAllocationDataGrid()
        {
            try
            {
                if (POAllocationEntity != null && POAllocationEntity.Count > 0 && dgSelectedIndexItem < POAllocationEntity.Count && dgSelectedIndexItem >= 0)
                {
                    DataGridView1 = CollectionViewSource.GetDefaultView(POAllocationEntity);
                    if (ItemDetailsEntity[dgSelectedIndexItem].sku == null)
                    {
                        DataGridView1.Filter = adv => ((MM_T001_C)adv).ItemCode.Equals(ItemDetailsEntity[dgSelectedIndexItem].ItemCode);
                    }
                    else
                    {
                        DataGridView1.Filter = adv => ((MM_T001_C)adv).ItemCode.Equals(ItemDetailsEntity[dgSelectedIndexItem].ItemCode) && ((MM_T001_C)adv).sku.Equals(ItemDetailsEntity[dgSelectedIndexItem].sku);
                    }

                    DataGridView1.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }
        void ModelUpdated_Batch(object sender, EventArgs e)
        {
            try
            {

                //This will get called when the property of an object inside the collection changes
                if (sender.ToString() == "para2" || sender.ToString() == "para3" || sender.ToString() == "para4")
                {
                    foreach (var o in BatchDetailsEntity)
                    {
                        if (o.para2 != null && o.para3 != null && o.para4 != null)
                        {
                            //o.para1 = Math.Round(o.para1, 4, MidpointRounding.AwayFromZero);
                            //o.para2 = Math.Round(o.para2, 4, MidpointRounding.AwayFromZero);
                            //o.para3 = Math.Round(o.para3, 4, MidpointRounding.AwayFromZero);
                            //o.para4 = Math.Round(o.para4, 4, MidpointRounding.AwayFromZero);
                            //o.para5 = Math.Round(o.para5, 4, MidpointRounding.AwayFromZero);

                            o.para1 = Convert.ToDecimal(o.para3 / o.para2);
                            o.para5 = Convert.ToDecimal(o.para3 * o.para4);

                        }
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
        private void CollectionChangedNotifyForBatch(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {

                ////////////////////////////////////Temp Test
                //if (e.NewItems != null && e.NewItems.Count != 0)
                //    foreach (PUR_T004_B item in e.NewItems)
                //        item.PropertyChanged += this.Schedule_PropertyChanged;

                //if (e.OldItems != null && e.OldItems.Count != 0)
                //    foreach (PUR_T004_B item in e.OldItems)
                //        item.PropertyChanged -= this.Schedule_PropertyChanged;

                /////////////////////////////////Temp Test End
                if (e.Action == NotifyCollectionChangedAction.Add && ItemDetailsEntity.Count > 0) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (MM_T001_B item in e.NewItems)
                    {
                        //Adde items Schedules Default Values from Items Entity
                        if (dgSelectedIndexItem <= ItemDetailsEntity.Count)
                        {
                            item.ItemCode = ItemDetailsEntity[dgSelectedIndexItem].ItemCode;
                            item.sku = ItemDetailsEntity[dgSelectedIndexItem].sku;
                            item.active = true;
                            item.add_by = AppSessionState.UserID;
                            item.comp_code = AppSessionState.comp_code;
                            item.doc_no = MasterEntity.doc_no;
                            item.editby = AppSessionState.UserID;
                            item.fin_year = "15-16";
                            item.posting_period = "1";
                            item.item_line_id = dgSelectedIndexItem;
                            item.location_Id = AppSessionState.location_Id;
                            item.pono = ItemDetailsEntity[dgSelectedIndexItem].source_doc_no;
                            
                            item.t_status = "001";
                            item.t_display = (from o in MC.t_statusList where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();

                            item.unit_code = ItemDetailsEntity[dgSelectedIndexItem].unit_code;
                            item.store_code = ItemDetailsEntity[dgSelectedIndexItem].store_code;
                        }

                        //      item.PropertyChanged += EntityViewModelPropertyChanged;
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

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }

        }

        private void DeleteBatchDataGridRow_Item(object InputValue)
        {
            int i = (int)InputValue;
            if (BatchDetailsEntity.Count > i && BatchDetailsEntity[i].id == 0)
            {
                BatchDetailsEntity.RemoveAt(i);
            }
        }
        private void ItemActiveInActiveMethod(object InputValue)
        {
            try
            {

                int i = (int)InputValue;
                if (ItemDetailsEntity.Count >= i && ItemDetailsEntity[i].id != 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.OkCancel;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("If You Inactivate The Item Its All Batches and Allocation Will be Inactivate\n Click Ok to Continue ", this.Title);
                    showMessageService.ShowMessage();

                    if (showMessageService.ShowMessage() == DialogResult.Ok)
                    {
                        if (ItemDetailsEntity[i].active == false)
                        {
                            // All Batches of Inactivated item are Inactivated
                            foreach (var item in BatchDetailsEntity)
                            {
                                if (item.ItemCode == ItemDetailsEntity[i].ItemCode && item.sku == ItemDetailsEntity[i].sku && item.active == true)
                                {
                                    item.active = false;
                                }
                            }
                            // Allocation of Inactivated item is Inactivated
                            foreach (var item in POAllocationEntity)
                            {
                                if (item.ItemCode == ItemDetailsEntity[i].ItemCode && item.sku == ItemDetailsEntity[i].sku && item.active == true)
                                {
                                    item.active = false;
                                }
                            }
                        }
                    }
                    else if (showMessageService.ShowMessage() == DialogResult.Cancel)
                    {
                        ItemDetailsEntity[i].active = true;
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
        private void InsertDataGridRow_POAllocation(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                PUR_T002_A_P POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.SourceDocNoList.Where(x => x.po_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PUR_T002_A_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = POAllocationEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = POAllocationEntity.IndexOf(POAllocationEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && POAllocationEntity.Count == dgSelectedIndexPOAllocation)
                    {
                        POAllocationEntity.Add(new MM_T001_C()
                        {
                            id = 0,
                            ItemCode = ItemDetailsEntity[dgSelectedIndexItem].ItemCode,
                            sku = ItemDetailsEntity[dgSelectedIndexItem].sku,
                            po_no = POPUPEntityObject.po_no,
                            po_qty = Convert.ToDecimal(POPUPEntityObject.qty),
                            comp_code = AppSessionState.comp_code,
                            location_Id = AppSessionState.location_Id,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,
                            active = true,
                            doc_no = MasterEntity.doc_no
                        });
                    }
                    else if (dgSelectedIndexPOAllocation >= 0 && POAllocationEntity.Count > dgSelectedIndexPOAllocation) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (POAllocationEntity[dgSelectedIndexPOAllocation].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            POAllocationEntity[dgSelectedIndexPOAllocation].ItemCode = ItemDetailsEntity[dgSelectedIndexItem].ItemCode;
                            POAllocationEntity[dgSelectedIndexPOAllocation].sku = ItemDetailsEntity[dgSelectedIndexItem].sku;
                            POAllocationEntity[dgSelectedIndexPOAllocation].po_no = POPUPEntityObject.po_no;
                            POAllocationEntity[dgSelectedIndexPOAllocation].po_qty = Convert.ToDecimal(POPUPEntityObject.qty);
                            POAllocationEntity[dgSelectedIndexPOAllocation].active = true;
                            POAllocationEntity[dgSelectedIndexPOAllocation].comp_code = AppSessionState.comp_code;
                            POAllocationEntity[dgSelectedIndexPOAllocation].location_Id = AppSessionState.location_Id;
                            POAllocationEntity[dgSelectedIndexPOAllocation].add_by = AppSessionState.UserID;
                            POAllocationEntity[dgSelectedIndexPOAllocation].editby = AppSessionState.UserID;
                            POAllocationEntity[dgSelectedIndexPOAllocation].doc_no = MasterEntity.doc_no;
                        }
                        else if (POAllocationEntity[dgSelectedIndexPOAllocation].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            POAllocationEntity[dgSelectedIndexPOAllocation].po_no = "";
                        }
                    }
                }

                #region Clear Empty Row
                MM_T001_C newObj = new MM_T001_C();
                for (int i = POAllocationEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = POAllocationEntity[i].ComparePropertiesTo(newObj);
                    if (POAllocationEntity[i].ComparePropertiesTo(newObj) == true && POAllocationEntity.Count > 1)
                    {
                        POAllocationEntity.RemoveAt(i);
                        if (POAllocationEntity.Count == 0)
                        {
                            POAllocationEntity.Add(newObj);
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
        private void DeletePoAllocationDataGridRow_Item(object InputValue)
        {
            int i = (int)InputValue;
            if (POAllocationEntity.Count > i && POAllocationEntity[i].id == 0)
            {
                POAllocationEntity.RemoveAt(i);
            }
        }
        //private void CollectionChangedNotifyForPoAllocation(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    ////////////////////////////////////Temp Test
        //    if (e.NewItems != null && e.NewItems.Count != 0)
        //        foreach (MM_T001_C item in e.NewItems)
        //            item.PropertyChanged += this.PoAllocation_PropertyChanged;

        //    if (e.OldItems != null && e.OldItems.Count != 0)
        //        foreach (MM_T001_C item in e.OldItems)
        //            item.PropertyChanged -= this.PoAllocation_PropertyChanged;
        //}
        //void PoAllocation_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName == "allocated_qty")
        //    {
        //        if (POAllocationEntity[dgSelectedIndexPOAllocation].allocated_qty > POAllocationEntity[dgSelectedIndexPOAllocation].po_qty)
        //        {
        //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //            showMessageService.ButtonSetup = DialogButton.Ok;
        //            showMessageService.Caption = "Validation";
        //            showMessageService.Text = String.Format("Allocated Quantity Must be Less than PO Quantity", this.Title);
        //            showMessageService.ShowMessage();
        //        }
        //    }
        //    //if (ItemDetailsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
        //    //{
        //    //    this.ErrorExist = ItemDetailsEntity[dgSelectedIndexItem].HasErrors;
        //    //}
        //}

        // below 4 methods are for Parameters and Parameter Values
        private void CollectionChanged(IList DataList)
        {
            IList list = DataList as IList;
            int a = dgSelectedIndexItem;
            string[] TempSkuList = new string[100];
            List<string> TempParaValueList = new List<string>();
            try
            {
                if (dgSelectedIndexItem != -1)   // This Condition is used to avoid error index out of range
                {
                    if (ItemDetailsEntity[dgSelectedIndexItem].id == 0 && ItemDetailsEntity.Count > 0 && dgSelectedIndexItem < ItemDetailsEntity.Count && dgSelectedIndexItem != -1)
                    {
                        List<MM_T001_A> SelectedRowlist = list.Cast<MM_T001_A>().ToList();

                        if (SelectedRowlist[0].StockUnt == true)
                        {
                            var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();
                            ParameterTemp = paramlist.ToList();

                            if (paramlist.Count > 0 && ItemDetailsEntity[dgSelectedIndexItem].sku != "" && ItemDetailsEntity[dgSelectedIndexItem].sku != null)
                            {
                                TempSkuList = ItemDetailsEntity[dgSelectedIndexItem].sku.Split('/');

                                for (int i = 0; i < paramlist.Count; i++)
                                {
                                    if (TempSkuList.Count() > i)
                                    {
                                        TempParaValueList = (from o in MC.ParamValueList where o.value_code == TempSkuList[i] select o.parametervalue).ToList();
                                        if (TempParaValueList.Count > 0)
                                        {
                                            paramlist[i].parametervalue = TempParaValueList[0];
                                        }
                                    }
                                }

                                ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                            }
                            else
                            {
                                foreach (var o in ParameterTemp)
                                {
                                    o.parametervalue = null; o.value_code = null;
                                }
                                ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                            }
                            //-------------------------------

                            if (paramlist.Count > 0) //&& SelectedParaValueCollection.Count != paramlist.Count)
                            {
                                SelectedParaValueCollection = new List<ADM_M031_P>();

                                for (int i = 0; i < paramlist.Count; i++)
                                {
                                    SelectedParaValueCollection.Add(new ADM_M031_P()
                                    {
                                        // ItemCode = SelectedRowlist[0].ItemCode,
                                        dgselectedindex = dgSelectedIndexItem,
                                        //  value_code = SelectedParaValueList[0].value_code,
                                        para_code = paramlist[i].para_code,
                                        para_name = paramlist[i].para_name

                                    });
                                }


                                if (ItemDetailsEntity[dgSelectedIndexItem].sku_desc != null)
                                {
                                    SelectedParaValueCollection = ParameterCollection.Cast<ADM_M031_P>().ToList();

                                    foreach (var o in SelectedParaValueCollection)
                                    {
                                        o.dgselectedindex = dgSelectedIndexItem;
                                        foreach (var p in MC.ParamValueList)
                                        {
                                            if (o.para_code == p.para_code && o.parametervalue == p.parametervalue)
                                            {
                                                o.value_code = p.value_code;
                                            }
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {
                            ParameterCollection = CollectionViewSource.GetDefaultView(TempParaValueList);
                        }
                    }
                    else if (ItemDetailsEntity[dgSelectedIndexItem].id != 0 && ItemDetailsEntity.Count > 0 && dgSelectedIndexItem < ItemDetailsEntity.Count)
                    {
                        List<MM_T001_A> SelectedRowlist = list.Cast<MM_T001_A>().ToList();
                        //string[] TempSkuList = new string[100];
                        //List<string> TempParaValueList = new List<string>();

                        //if (SelectedRowlist[0].StockUnt == true)
                        //{
                        //    var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();
                        //    if (paramlist.Count > 0 && ItemDetailsEntity[dgSelectedIndexItem].sku != "" && ItemDetailsEntity[dgSelectedIndexItem].sku != null)
                        //    {
                        //        TempSkuList = ItemDetailsEntity[dgSelectedIndexItem].sku.Split('/');

                        //        for (int i = 0; i < paramlist.Count; i++)
                        //        {
                        //            TempParaValueList = (from o in MC.ParamValueList where o.value_code == TempSkuList[i] select o.parametervalue).ToList();
                        //            paramlist[i].parametervalue = TempParaValueList[0];
                        //        }

                        //        ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                        //    }
                        //}
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
        private void GetSelectedParaValue(IList parameter)
        {
            try
            {
                IList list = parameter as IList;
                List<ADM_M031_P> SelectedParaValueList = list.Cast<ADM_M031_P>().ToList();
                //  int a = ParadgSelectedIndex;
                int b = dgSelectedIndexItem;
                if (dgSelectedIndexItem != -1 && SelectedParaValueList.Count > 0 && ItemDetailsEntity[dgSelectedIndexItem].StockUnt == true)
                {
                    if (ItemDetailsEntity[dgSelectedIndexItem].id == 0)
                    {
                        #region 
                        if (SelectedParaValueList.Count > 0 && SelectedParaValueList[0].parametervalue != null && SelectedParaValueList[0].parametervalue != "")// && SelectedParaValueCollection.dgselectedindex.contains)
                        {
                            for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                            {
                                if (SelectedParaValueCollection[i].para_code == SelectedParaValueList[0].para_code && SelectedParaValueCollection[i].dgselectedindex == dgSelectedIndexItem)
                                {
                                    SelectedParaValueCollection[i].parametervalue = SelectedParaValueList[0].parametervalue;

                                    var paravaluetemp = (from o in MC.ParamValueList where o.para_code == SelectedParaValueCollection[i].para_code && o.parametervalue == SelectedParaValueCollection[i].parametervalue select o).ToList();

                                    if (paravaluetemp.Count > 0)
                                    {
                                        SelectedParaValueCollection[i].value_code = paravaluetemp[0].value_code;
                                    }
                                }
                            }

                            // SKU Description
                            GetSkuDescription();

                            //Function for calculating SKU
                            CalculateSku();
                        }
                        #endregion
                    }
                    else if (ItemDetailsEntity[dgSelectedIndexItem].id != 0)
                    {

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
        private void GetSkuDescription()
        {
            try
            {

                if (ItemDetailsEntity[dgSelectedIndexItem].sku_desc == null || ItemDetailsEntity[dgSelectedIndexItem].sku_desc == "")
                {
                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if ((ItemDetailsEntity[dgSelectedIndexItem].sku_desc == "" || ItemDetailsEntity[dgSelectedIndexItem].sku_desc == null) && (SelectedParaValueCollection[i].parametervalue ?? "").Trim() != "NA")
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                        else if ((SelectedParaValueCollection[i].parametervalue ?? "").Trim() != "NA")
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].sku_desc = ItemDetailsEntity[dgSelectedIndexItem].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                    }
                }
                else
                {
                    ItemDetailsEntity[dgSelectedIndexItem].sku_desc = "";

                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if ((ItemDetailsEntity[dgSelectedIndexItem].sku_desc == "" || ItemDetailsEntity[dgSelectedIndexItem].sku_desc == null) && (SelectedParaValueCollection[i].parametervalue ?? "").Trim() != "NA")
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                        else if ((SelectedParaValueCollection[i].parametervalue ?? "").Trim() != "NA")
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].sku_desc = ItemDetailsEntity[dgSelectedIndexItem].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
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
        private void CalculateSku()
        {
            try
            {

                if (ItemDetailsEntity[dgSelectedIndexItem].StockUnt == true && (ItemDetailsEntity[dgSelectedIndexItem].sku == null || ItemDetailsEntity[dgSelectedIndexItem].sku == ""))
                {
                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (ItemDetailsEntity[dgSelectedIndexItem].sku == "" || ItemDetailsEntity[dgSelectedIndexItem].sku == null)
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].sku = SelectedParaValueCollection[i].value_code;
                        }
                        else
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].sku = ItemDetailsEntity[dgSelectedIndexItem].sku + "/" + SelectedParaValueCollection[i].value_code;
                        }
                    }
                }
                else if(ItemDetailsEntity[dgSelectedIndexItem].StockUnt == true)
                {
                    ItemDetailsEntity[dgSelectedIndexItem].sku = "";

                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (ItemDetailsEntity[dgSelectedIndexItem].sku == "" || ItemDetailsEntity[dgSelectedIndexItem].sku == null)
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].sku = SelectedParaValueCollection[i].value_code;
                        }
                        else
                        {
                            ItemDetailsEntity[dgSelectedIndexItem].sku = ItemDetailsEntity[dgSelectedIndexItem].sku + "/" + SelectedParaValueCollection[i].value_code;
                        }

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

        #endregion
        private bool Validations()
        {
            if (MasterEntity.sending_plant == null || MasterEntity.sending_plant == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Validation";
                showMessageService.Text = String.Format("Please Enter Supplying Plant");
                showMessageService.ShowMessage();
                return false;
            }

            if (MasterEntity.rec_plant == null || MasterEntity.rec_plant == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Validation";
                showMessageService.Text = String.Format("Please Enter Receiving Plant");
                showMessageService.ShowMessage();
                return false;
            }

            if (MasterEntity.sending_plant == MasterEntity.rec_plant)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Validation";
                showMessageService.Text = String.Format("Supplying Plant and Receiving Plant Cannot Be Same");
                showMessageService.ShowMessage();
                return false;
            }
            if (ItemDetailsEntity.Count < 1)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Validation";
                showMessageService.Text = String.Format("Item Details Must Have At Least One Item ");
                showMessageService.ShowMessage();
                return false;
            }
            //if (MasterEntity.po_code == null || MasterEntity.po_code == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Validation";
            //    showMessageService.Text = String.Format("Please Select Purchase Organization(PO Code) in Shipping And Org Data Tab");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            //if (MasterEntity.pg_code == null || MasterEntity.pg_code == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Validation";
            //    showMessageService.Text = String.Format("Please Select Purchase Group(PG Code) in Shipping And Org Data Tab");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            #region . Validation for Item Duplication, null Unit Code and Null or 0 Quantity For All Active Items .
            // Validation for Quantity Item Duplication and Unit Code For Item Details
            foreach (var o in ItemDetailsEntity)
            {
                int flag = 0;
                if (o.active == true)
                {    // Item Duplication Validation
                    foreach (var p in ItemDetailsEntity)
                    {
                        if (o.ItemCode == p.ItemCode && o.sku == p.sku && p.active == true)
                        {
                            flag++;
                        }
                    }
                    if (flag > 1)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemDetailsEntity.IndexOf(o));
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
                        showMessageService.Text = String.Format("Quantity cannot be null or 0 for item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemDetailsEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                    if (o.unit_code == null || o.unit_code == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemDetailsEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                    if (o.location_Id == null || o.location_Id == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Valid Plant for the item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemDetailsEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                    if (o.store_code == null || o.store_code == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Valid Store Code for the item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemDetailsEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                    if (o.location_Id != MasterEntity.rec_plant)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Plant should be equal to receiving plant for the item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemDetailsEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;

                    }
                }
                #region . Parameter Validation .
                // Validation For All Parameter Values Selected or Not

                if (o.StockUnt == true && o.active == true)
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
                                    showMessageService.Text = String.Format("All Parameters of item {0} of Index {1} are not selected..!!! \n Check Parameter at index {2} is selected or not.", o.ItemCode, ItemDetailsEntity.IndexOf(o), SkuList.ToList().IndexOf(item));
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
                            showMessageService.Text = String.Format("All Parameters of item {0} of Index {1} are not selected\n If you can see All Parameter Value Selected Please Select the Same Values Again ", o.ItemCode, ItemDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }
                    }

                }
                #endregion
            }

            #endregion

            #region . Item Quantity Batch Quantity Validation.
            //Validation For Item Quantity Equal To Sum of Quantities of All Active Batches Of the Item 
            //bool breakfor = false;
            for (int i = 0; i < ItemDetailsEntity.Count; i++)
            {
                decimal temp = 0;
                int flag = 0;

                if (ItemDetailsEntity[i].active == true && ItemDetailsEntity[i].batch_split == true)
                {
                    for (int j = 0; j < BatchDetailsEntity.Count; j++)
                    {
                        if (ItemDetailsEntity[i].ItemCode == BatchDetailsEntity[j].ItemCode && ItemDetailsEntity[i].sku == BatchDetailsEntity[j].sku && BatchDetailsEntity[j].active == true)
                        {
                            temp = temp + Convert.ToDecimal(BatchDetailsEntity[j].rec_qty);
                            flag = 1;
                        }
                    }

                    if (ItemDetailsEntity[i].qty != temp && flag == 1)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Item Quantity is Not Equal to Sum of All Item Batches Quantities\n for Item {0} At Index {1}", ItemDetailsEntity[i].ItemCode, i);
                        showMessageService.ShowMessage();
                        //breakfor = false;
                        return false;
                    }
                }
            }
            #endregion

            #region . PO Allocation Validation .

            foreach (var q in POAllocationEntity)
            {
                if (q.allocated_qty == 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Validation : PO Allocation";
                    showMessageService.Text = String.Format(" Please Enter Quantity Greater Than 0 For PO {0} At Index {1}", q.po_no, POAllocationEntity.IndexOf(q));
                    showMessageService.ShowMessage();
                    return false;
                }
            }

            #endregion

            return true;
        }

        #region . Command Actions .
        protected override void OnSaveAction(InquiryActionResult<MM_T001> result)
        {
            try
            {
                if (Validations() == true)
                {
                    MasterEntity.PartyId = "";
                    MasterEntity.location_Id = AppSessionState.location_Id;
                    MasterEntity.comp_code = AppSessionState.comp_code;
                    MasterEntity.XmlDataDocument_MM_T001_A = obj.ObjectToXML(ItemDetailsEntity);
                    MasterEntity.XmlDataDocument_MM_T001_B = obj.ObjectToXML(BatchDetailsEntity);
                    MasterEntity.XmlDataDocument_MM_T001_C = obj.ObjectToXML(POAllocationEntity);

                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<MM_T001>(MasterEntity, "GoodsReceiptNote", "SCM");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<MM_T001>(MasterEntity, "GoodsReceiptNote", "SCM");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    NewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                    parameter = false; // After Save Parameter Popup Should not Open Hence Disabling this Variable
                    RefDocLoad = false; //  after save cannot load documents again
                    MoveFlag = false;  // after save movement type cannot be changed
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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            MasterEntity.ts_code = ts_code_vm;
            if (MasterEntity.XmlDataDocument_MM_T001_A != null)
            {
                MC.ItemDetailsList = (ObservableCollection<MM_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_MM_T001_A, MC.ItemDetailsList);
                ItemDetailsEntity.Clear();
                ItemDetailsEntity = MC.ItemDetailsList;
            }
            else
            {
                MC.ItemDetailsList = new ObservableCollection<MM_T001_A>();
            }

            if (MasterEntity.XmlDataDocument_MM_T001_B != null)
            {
                MC.BatchDetailsList = (ObservableCollection<MM_T001_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_MM_T001_B, MC.BatchDetailsList);
                BatchDetailsEntity.Clear();
                BatchDetailsEntity = MC.BatchDetailsList;
            }
            else
            {
                MC.BatchDetailsList = new ObservableCollection<MM_T001_B>();
            }

            if (MasterEntity.XmlDataDocument_MM_T001_C != null)
            {
                MC.POAllocDetailsList = (ObservableCollection<MM_T001_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_MM_T001_C, MC.POAllocDetailsList);
                POAllocationEntity.Clear();
                POAllocationEntity = MC.POAllocDetailsList;
            }
            else
            {
                MC.POAllocDetailsList = new ObservableCollection<MM_T001_C>();
            }

            if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.FlipGridList = (List<MM_T001_FLIP>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.FlipGridList);
                FlipGridData.Add(MC.FlipGridList[0]);
                FlipDataGridCollection.Refresh();
            }
        }
        protected override void OnCreateAction(InquiryActionResult<MM_T001> result)
        {
            try
            {
                NewRecord = true; parameter = false; RefDocLoad = true; MoveFlag = true;
                MasterEntity = new MM_T001();
                ItemDetailsEntity = new ObservableCollection<MM_T001_A>();
                BatchDetailsEntity = new ObservableCollection<MM_T001_B>();
                POAllocationEntity = new ObservableCollection<MM_T001_C>();
                MasterEntity.ValidateAsync().Wait();
                DefaultValues();
                MasterEntity.rec_plant = AppSessionState.location_Id;

                if (PurchaseOrganisationList.Count != 0)
                {
                    if (PurchaseOrganisationList.Count == 1)
                    {
                        MasterEntity.po_code = PurchaseOrganisationList[0].po_code;
                        MasterEntity.pur_org = PurchaseOrganisationList[0].pur_org;
                    }
                }
                else
                {
                    MasterEntity.po_code = "";
                }
                if (PurchaseGroupList.Count != 0)
                {
                    if (PurchaseGroupList.Count == 1)
                    {
                        MasterEntity.pg_code = PurchaseGroupList[0].pg_code;
                        MasterEntity.pg_name = PurchaseGroupList[0].pg_name;
                    }
                }
                else
                {
                    MasterEntity.pg_code = "";
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
        protected override void OnRemoveAction(InquiryActionResult<MM_T001> result)
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
                string response = repository.Delete(MasterEntity.doc_no, "GoodsReceiptNote", "SCM");
                //FlipGridData.Remove(MasterEntity); Temp
                MasterEntity = new MM_T001();
                ItemDetailsEntity = new ObservableCollection<MM_T001_A>();
                BatchDetailsEntity = new ObservableCollection<MM_T001_B>();
                _FlipDataGridCollection.Refresh();
                DefaultValues();
                MasterEntity.rec_plant = AppSessionState.location_Id;
                NewRecord = true;
                parameter = false; RefDocLoad = true; MoveFlag = true;
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<MM_T001> result)
        {
        }
        protected override void OnFevoriteAction(InquiryActionResult<MM_T001> result)
        {
        }
        protected override void OnFlipAction(InquiryActionResult<MM_T001> result)
        {
        }
        protected override void OnHelpAction(InquiryActionResult<MM_T001> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<MM_T001> result)
        {
            if (MasterEntity.doc_no == null || MasterEntity.doc_no == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("You must have to save the record first..Then print it", this.Title);
                showMessageService.ShowMessage();
            }
            else
            {
                string Request = "Rpt_GRN" + "!@" + MasterEntity.doc_no + "!@" + MasterEntity.mov_tp;
               
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MCTemp, Request, "GoodsReceiptNote", "SCM", "LoadAll", 0, "");

                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];
      

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[0] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[1] = Result;

                objDataSource[2] = MCTemp.RptGRN;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsGRN_P2P";

                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\SCM\\GRN_P2P.rdlc", "GRN_P2P");

            }
        }
        protected override void OnDocumentAction()
        {
            
        }
        protected override void OnRefreshCommand(InquiryActionResult<MM_T001> result)
        {
            LoadInitialData();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void OnExportAction()
        {
            //try
            //{
            //    List<MM_T001> Export_List = new List<MM_T001>();
            //    foreach (var o in FlipDataGridCollection)
            //    {
            //        MM_T001 Data = o as MM_T001;
            //        Export_List.Add(Data);
            //    }

            //    //--------------------------------------

            //    ExportToExcel<MM_T001, List<MM_T001>> export = new ExportToExcel<MM_T001, List<MM_T001>>();
            //    ICollectionView view = CollectionViewSource.GetDefaultView(Export_List);
            //    export.dataToPrint = (List<MM_T001>)view.SourceCollection;

            //    export.GenerateReport();
            //}
            //catch (Exception ex)
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format(ex.Message, this.Title);
            //    showMessageService.ShowMessage();
            //}

        }

        #region . Filter Function .

        #region . BackFlip .
        private string _filterString_BackFlip; //vendor
        public string FilterString_BackFlip
        {
            get { return _filterString_BackFlip; }
            set
            {
                _filterString_BackFlip = value;
                RaisePropertyChanged("FilterString_BackFlip");
                FilterCollection_BackFlip();
            }
        }
        private void FilterCollection_BackFlip()
        {
            if (FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_BackFlip(object obj)
        {
            var data = obj as MM_T001_FLIP;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BackFlip))
                {
                    return (data.mov_name != null && data.mov_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()) ||
                        data.vendor != null && data.vendor.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()) ||
                        data.sendplantnm != null && data.sendplantnm.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()) ||
                        data.recplantnm != null && data.recplantnm.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()) ||
                        data.source_doc_no != null && data.source_doc_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()) ||
                        data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()) ||
                        data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion       

        #region . Supplier Party .
        private string _filterString_SupplierParty; //vendor
        public string FilterString_SupplierParty
        {
            get { return _filterString_SupplierParty; }
            set
            {
                _filterString_SupplierParty = value;
                RaisePropertyChanged("FilterString_SupplierParty");
                FilterCollection_SupplierParty();
            }
        }
        private void FilterCollection_SupplierParty()
        {
            if (SupplierCollection != null)
            {
                _SupplierCollection.Refresh();
            }
        }
        public bool Filter_SupplierParty(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SupplierParty))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_SupplierParty.ToLower()) ||
                        data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_SupplierParty.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Sending Plant .
        private string _filterString_SendingPlant;
        public string FilterString_SendingPlant
        {
            get { return _filterString_SendingPlant; }
            set
            {
                _filterString_SendingPlant = value;
                RaisePropertyChanged("FilterString_SendingPlant");
                FilterCollection_SendingPlant();
            }
        }
        private void FilterCollection_SendingPlant()
        {
            if (SendingPlant != null)
            {
                SendingPlant.Refresh();
            }
        }
        public bool Filter_SendingPlant(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SendingPlant))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_SendingPlant.ToLower()) ||
                        data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_SendingPlant.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Rec Plant .
        private string _filterString_RecPlant;
        public string FilterString_RecPlant
        {
            get { return _filterString_RecPlant; }
            set
            {
                _filterString_RecPlant = value;
                RaisePropertyChanged("FilterString_RecPlant");
                FilterCollection_Plant();
            }
        }
        private void FilterCollection_RecPlant()
        {
            if (ReceivingPlant != null)
            {
                ReceivingPlant.Refresh();
            }
        }
        public bool Filter_RecPlant(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_RecPlant))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_RecPlant.ToLower()) ||
                        data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_RecPlant.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Transporter Party .
        private string _filterString_TransParty; //Transporter
        public string FilterString_TransParty
        {
            get { return _filterString_TransParty; }
            set
            {
                _filterString_TransParty = value;
                RaisePropertyChanged("FilterString_TransParty");
                FilterCollection_TransParty();
            }
        }
        private void FilterCollection_TransParty()
        {
            if (TransporterPartyCollection != null)
            {
                _TransporterPartyCollection.Refresh();
            }
        }
        public bool Filter_TransParty(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_TransParty))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_TransParty.ToLower()) ||
                        data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_TransParty.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Movement Type .
        private string _filterString_MovType; //Transporter
        public string FilterString_MovType
        {
            get { return _filterString_MovType; }
            set
            {
                _filterString_MovType = value;
                RaisePropertyChanged("FilterString_MovType");
                FilterCollection_MovType();
            }
        }
        private void FilterCollection_MovType()
        {
            if (MovementTypeCollection != null)
            {
                _MovementTypeCollection.Refresh();
            }
        }
        public bool Filter_MovType(object obj)
        {
            var data = obj as MM_M004_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_MovType))
                {
                    return (data.mov_tp_name != null && data.mov_tp_name.ToString().ToLower().Contains(_filterString_MovType.ToLower()) ||
                        data.mov_tp != null && data.mov_tp.ToString().ToLower().Contains(_filterString_MovType.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Ref Doc No .
        private string _filterString_RefDocNo; //Transporter
        public string FilterString_RefDocNo
        {
            get { return _filterString_RefDocNo; }
            set
            {
                _filterString_RefDocNo = value;
                RaisePropertyChanged("FilterString_RefDocNo");
                FilterCollection_RefDocNo();
            }
        }
        private void FilterCollection_RefDocNo()
        {
            if (RefDocNoCollection != null)
            {
                _RefDocNoCollection.Refresh();
            }
        }
        public bool Filter_RefDocNo(object obj)
        {
            var data = obj as PUR_T002_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_RefDocNo))
                {
                    return (data.po_no != null && data.po_no.ToString().ToLower().Contains(_filterString_RefDocNo.ToLower())||
                            data.supplantnm != null && data.supplantnm.ToString().ToLower().Contains(_filterString_RefDocNo.ToLower()) ||
                            data.recplantnm != null && data.recplantnm.ToString().ToLower().Contains(_filterString_RefDocNo.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Item .
        private string _filterString_Item; //Transporter
        public string FilterString_Item
        {
            get { return _filterString_Item; }
            set
            {
                _filterString_Item = value;
                RaisePropertyChanged("FilterString_Item");
                FilterCollection_Item();
            }
        }
        private void FilterCollection_Item()
        {
            if (ItemCollection != null)
            {
                _ItemCollection.Refresh();
            }
        }
        public bool Filter_Item(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Item))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
                        data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
                        data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
                        data.StockUnt != null && data.StockUnt.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
                        data.SubCatName != null && data.SubCatName.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
                        data.CatName != null && data.CatName.ToString().ToLower().Contains(_filterString_Item.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . UOM .
        private string _filterString_UOM;
        public string FilterString_UOM
        {
            get { return _filterString_UOM; }
            set
            {
                _filterString_UOM = value;
                RaisePropertyChanged("FilterString_UOM");
                FilterCollection_UOM();
            }
        }
        private void FilterCollection_UOM()
        {
            if (UOMCollection != null)
            {
                _UOMCollection.Refresh();
            }
        }
        public bool Filter_UOM(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_UOM))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_UOM.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Store Loc .
        private string _filterString_StoreLoc;
        public string FilterString_StoreLoc
        {
            get { return _filterString_StoreLoc; }
            set
            {
                _filterString_StoreLoc = value;
                RaisePropertyChanged("FilterString_StoreLoc");
                FilterCollection_StoreLoc();
            }
        }
        private void FilterCollection_StoreLoc()
        {
            if (StoreLocCollection != null)
            {
                _StoreLocCollection.Refresh();
            }
        }
        public bool Filter_StoreLoc(object obj)
        {
            var data = obj as MM_M001;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_StoreLoc))
                {
                    return (data.store_code != null && data.store_code.ToString().ToLower().Contains(_filterString_StoreLoc.ToLower()) ||
                        data.store_name != null && data.store_name.ToString().ToLower().Contains(_filterString_StoreLoc.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Item Category .
        private string _filterString_ItemCat;
        public string FilterString_ItemCat
        {
            get { return _filterString_ItemCat; }
            set
            {
                _filterString_ItemCat = value;
                RaisePropertyChanged("FilterString_ItemCat");
                FilterCollection_ItemCat();
            }
        }
        private void FilterCollection_ItemCat()
        {
            if (ItemCatCollection != null)
            {
                _ItemCatCollection.Refresh();
            }
        }
        public bool Filter_ItemCategory(object obj)
        {
            var data = obj as SYS_M008_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ItemCat))
                {
                    return (data.item_cat != null && data.item_cat.ToString().ToLower().Contains(_filterString_ItemCat.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Plant .
        private string _filterString_Plant;
        public string FilterString_Plant
        {
            get { return _filterString_Plant; }
            set
            {
                _filterString_Plant = value;
                RaisePropertyChanged("FilterString_Plant");
                FilterCollection_Plant();
            }
        }
        private void FilterCollection_Plant()
        {
            if (PlantCollection != null)
            {
                PlantCollection.Refresh();
            }
        }
        public bool Filter_Plant(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Plant))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_Plant.ToLower()) ||
                        data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_Plant.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region PO Code
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

        #endregion

        #region PG Code
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

        
        #endregion
        #endregion
    }
}
