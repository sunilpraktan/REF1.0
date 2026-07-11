using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using System.Collections.Specialized;
using Reflection.ReportingServices;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.MM.ViewModels
{
    public class MM_T003_VM : WorkspaceViewModel<MM_T001>
    {
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(MM_T003_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _AS_GATE_ENTRY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_GATE_ENTRY
        {
            get { return _AS_GATE_ENTRY; }
            set
            {
                if (_AS_GATE_ENTRY != value)
                {
                    _AS_GATE_ENTRY = value; RaisePropertyChanged("AS_GATE_ENTRY");
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
        private AutoSuggestTextViewModel<dynamic> _AS_REC_PLANT_PARTY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_REC_PLANT_PARTY
        {
            get { return _AS_REC_PLANT_PARTY; }
            set
            {
                if (_AS_REC_PLANT_PARTY != value)
                {
                    _AS_REC_PLANT_PARTY = value; RaisePropertyChanged("AS_REC_PLANT_PARTY");
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
        private AutoSuggestTextViewModel<dynamic> _ASSendingPlant { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSendingPlant
        {
            get { return _ASSendingPlant; }
            set
            {
                if (_ASSendingPlant != value)
                {
                    _ASSendingPlant = value; RaisePropertyChanged("ASSendingPlant");
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
        private AutoSuggestTextViewModel<dynamic> _ASDOC_CAT { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDOC_CAT
        {
            get { return _ASDOC_CAT; }
            set
            {
                if (_ASDOC_CAT != value)
                {
                    _ASDOC_CAT = value; RaisePropertyChanged("ASDOC_CAT");
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
        private AutoSuggestTextViewModel<dynamic> _ASMovType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASMovType
        {
            get { return _ASMovType; }
            set
            {
                if (_ASMovType != value)
                {
                    _ASMovType = value; RaisePropertyChanged("ASMovType");
                }
            }
        }

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
                    if (SourceName == "unit_code")
                    { ASDefault = ASUOM; }

                }
            }
        }

        #endregion
        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = MasterEntity.HasErrors;
        }
        #region . Variable Declaration And Object .
        bool NewRecord = true;
        WebServiceRepository<MM_T001> repository = new WebServiceRepository<MM_T001>();
        WebServiceRepository<MC_MM_T001> repository_MC = new WebServiceRepository<MC_MM_T001>();

        ObjectSerializationService obj = new ObjectSerializationService();
        MC_MM_T001 _MC = new MC_MM_T001();
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
        public string doc_type_vm { get; set; }
        public string ref_doc_cat_vm { get; set; }
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
        private STD_LIST_BE _STD_LIST_OBJECT;
        public STD_LIST_BE STD_LIST_OBJECT
        {
            get
            {
                return _STD_LIST_OBJECT;
            }
            set
            {
                if (_STD_LIST_OBJECT != value)
                {
                    _STD_LIST_OBJECT = value;
                    RaisePropertyChanged("STD_LIST_OBJECT");
                }
            }
        }
        private RequestParameters _RequestPara;
        public RequestParameters RequestPara
        {
            get { return _RequestPara; }
            set
            {
                if (_RequestPara != value)
                {
                    _RequestPara = value;

                    RaisePropertyChanged("RequestPara");
                }
            }
        }
        private List<GRN_DOC_CAT> GRN_DOCCAT;
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
        private MM_T001_A _SelectedItemObject;
        public MM_T001_A SelectedItemObject
        {
            get
            {
                return _SelectedItemObject;
            }
            set
            {
                if (_SelectedItemObject != value)
                {
                    _SelectedItemObject = value;
                    RaisePropertyChanged("SelectedItemObject");
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
                    BatchDetailsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
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

        private bool _MoveFlag;   //movement type enable disable
        public bool MoveFlag
        {
            get { return _MoveFlag; }
            set { _MoveFlag = value; RaisePropertyChanged("MoveFlag"); }
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
        #region . StringList Variables .
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
        #endregion
        #region . ICollectionView .
        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }
        private ICollectionView _ReferenceDocPOCollection;
        public ICollectionView ReferenceDocPOCollection
        {
            get { return _ReferenceDocPOCollection; }
            set { _ReferenceDocPOCollection = value; RaisePropertyChanged("ReferenceDocPOCollection"); }
        }
        private ICollectionView _FilteredPOCollection;
        public ICollectionView FilteredPOCollection
        {
            get { return _FilteredPOCollection; }
            set { _FilteredPOCollection = value; RaisePropertyChanged("FilteredPOCollection"); }
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
        #endregion
        #region . Relay Commands .
        public RelayCommand<object> cmdAddSelectedRef { get; private set; }
        public RelayCommand<object> cmdTransport_Mode { get; private set; }
        public RelayCommand<object> cmdTransporter { get; private set; }
        public RelayCommand<object> cmdMovementType { get; private set; }
        public RelayCommand<object> CommandRefDocNo { get; private set; }
        public RelayCommand<object> cmdExecuteReferenceDocument { get; private set; }
        public RelayCommand ExportCommand { get; private set; }
        public RelayCommand<object> CommandUOM { get; private set; }
        public RelayCommand<object> CommandPlant { get; private set; }
        public RelayCommand<object> cmdStoreLocation { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowItem { get; private set; }
        public RelayCommand<IList> CreatePOCollectionCommand { get; private set; }
        public RelayCommand BatchSplitClick { get; private set; }
        public RelayCommand<IList> SelectionChangeCommandItemDetails { get; private set; }
        public RelayCommand<object> ActiveInActiveChangeCommand { get; private set; }
        public RelayCommand<object> BatchDataGridRowDeleteCommand { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> CommandPO { get; private set; }
        public RelayCommand<object> PoAllocationDataGridRowDeleteCommand { get; private set; }
        public RelayCommand<object> CommandLoadHistory { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> cmdPrintInspectionReport { get; private set; }
        #endregion

        #region . Constructor .
        public MM_T003_VM(string doc_cat, string ts_code) : base()
        {
            MoveFlag = true;
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            // MM_T001.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            MC = new MC_MM_T001();
            MCTemp = new MC_MM_T001();
            RequestPara = new RequestParameters();
            MasterEntity = new MM_T001();
            ItemDetailsEntity = new ObservableCollection<MM_T001_A>();
            BatchDetailsEntity = new ObservableCollection<MM_T001_B>();
            POAllocationEntity = new ObservableCollection<MM_T001_C>();
            MasterEntity.ValidateAsync().Wait();
            MM_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            MM_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Batch);
            GRN_DOCCAT = new List<GRN_DOC_CAT>();
            BatchDetailsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
            CommandInitialization();
            LoadInitialData(doc_cat_vm, null);
        }
        public MM_T003_VM(string doc_cat, string ts_code, string doc_no) : base()
        {
            MoveFlag = true;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            this.doc_cat_vm = doc_cat;
            MC = new MC_MM_T001();
            MCTemp = new MC_MM_T001();
            RequestPara = new RequestParameters();
            MasterEntity = new MM_T001();
            ItemDetailsEntity = new ObservableCollection<MM_T001_A>();
            BatchDetailsEntity = new ObservableCollection<MM_T001_B>();
            POAllocationEntity = new ObservableCollection<MM_T001_C>();
            MasterEntity.ValidateAsync().Wait();
            MM_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            MM_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Batch);
            GRN_DOCCAT = new List<GRN_DOC_CAT>();
            BatchDetailsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
            CommandInitialization();
            LoadInitialData(doc_cat_vm, null);
        }
        public MM_T003_VM(string doc_cat, string ts_code, STD_LIST_BE STD_LIST_OBJ) : base()
        {
            MoveFlag = true;
            STD_LIST_OBJECT = new STD_LIST_BE();
            STD_LIST_OBJECT = STD_LIST_OBJ;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = STD_LIST_OBJ.doc_no;
            this.doc_cat_vm = STD_LIST_OBJ.doc_cat ?? doc_cat;
            this.doc_type_vm = STD_LIST_OBJ.doc_type ?? doc_cat;
            this.ref_doc_cat_vm = STD_LIST_OBJ.ref_doc_cat;
            RequestPara = new RequestParameters();
            MC = new MC_MM_T001();
            MCTemp = new MC_MM_T001();
            MasterEntity = new MM_T001();
            
            ItemDetailsEntity = new ObservableCollection<MM_T001_A>();
            BatchDetailsEntity = new ObservableCollection<MM_T001_B>();
            MasterEntity.ValidateAsync().Wait();
            MM_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            MM_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Batch);
            GRN_DOCCAT = new List<GRN_DOC_CAT>();
            BatchDetailsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
            CommandInitialization();
            LoadInitialData(doc_cat_vm, null);
        }
        #endregion

        #region . User Defined Functions .
        private void DefaultValues(string doc_cat_info)
        {
            MasterEntity.doc_cat = this.doc_cat_vm;
            MasterEntity.doc_type = this.doc_cat_vm;
            MasterEntity.doc_code = this.doc_cat_vm;
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.dept_code = AppSessionState.dept_code;
            MasterEntity.active = true;
            MasterEntity.t_status = (from o in MC.STATUS_LIST where o.t_sequence == 1 select o).ToList()[0].t_status;
            MasterEntity.t_display = (from o in MC.STATUS_LIST where o.t_sequence == 1 select o).ToList()[0].t_display;
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.post_date = DateTime.Now;
            MasterEntity.client = AppSessionState.client;
            RequestPara.doc_cat = "GR";
            
            RequestPara.active = true;
            RequestPara.FromDate = DateTime.Now.AddMonths(-1);
            RequestPara.ToDate = DateTime.Now;
            RequestPara.doc_type = MasterEntity.doc_type;
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        private void LoadInitialData(string doc_cat_info, string ReferenceDoc)
        {
            try
            {//"101,118,119,115,117,127,128" 
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + this.doc_cat_vm + "!@" + AppSessionState.EmpId;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "MM_T001_BL_GR", "MM", "LoadAll", 0, "");

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).doc_no);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).doc_no ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((STD_LIST_BE)o).party_name ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                AS_GATE_ENTRY = new AutoSuggestTextViewModel<dynamic>(MC.GATE_ENTRY_LIST, TheFilter, SuggestedValue, "doc_no", true);
                AS_GATE_ENTRY.AutoSuggestVM.IsEmptyValueAllowed = true;AS_GATE_ENTRY.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.UOMList, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => ((ADM_M003)o).location_Id.ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPlant = new AutoSuggestTextViewModel<dynamic>((List<ADM_M003>)AppSessionState.ADM_M003_List, TheFilter, SuggestedValue, "location_Id", true);
                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => ((ADM_M003)o).location_Id.ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSendingPlant = new AutoSuggestTextViewModel<dynamic>((List<ADM_M003>)AppSessionState.ADM_M003_List, TheFilter, SuggestedValue, "location_Id", true);
                ASSendingPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M001_P)x).store_code);
                TheFilter = (o, prefix) => ((MM_M001_P)o).store_code.ToLower().Contains(prefix.ToLower()) || (((MM_M001_P)o).store_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASStore = new AutoSuggestTextViewModel<dynamic>(MC.StoreCodeList, TheFilter, SuggestedValue, "store_code", "store_code", true);
                ASStore.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTransporter = new AutoSuggestTextViewModel<dynamic>(MC.TransporterList, TheFilter, SuggestedValue, "PartyId", true);
                ASTransporter.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M026)x).tr_mode);
                TheFilter = (o, prefix) => (((SYS_M026)o).tr_mode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M026)o).tr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTRMode = new AutoSuggestTextViewModel<dynamic>(MC.TransportMode, TheFilter, SuggestedValue, "tr_mode", true);
                ASTRMode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASStatus = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                ASStatus.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUOM = new AutoSuggestTextViewModel<dynamic>(MC.UOMList, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUOM.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASWTUOM = new AutoSuggestTextViewModel<dynamic>(MC.UOMList, TheFilter, SuggestedValue, "unit_code", true);
                ASWTUOM.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUOMVOL = new AutoSuggestTextViewModel<dynamic>(MC.UOMList, TheFilter, SuggestedValue, "unit_code", true);
                ASUOMVOL.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M004_P)x).mov_tp);
                TheFilter = (o, prefix) => (((MM_M004_P)o).mov_tp ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((MM_M004_P)o).mov_tp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASMovType = new AutoSuggestTextViewModel<dynamic>(MC.MovementTypeList, TheFilter, SuggestedValue, "mov_tp", true);
                ASMovType.AutoSuggestVM.IsEmptyValueAllowed = true;

                ReferenceDocPOCollection = CollectionViewSource.GetDefaultView(MC.SourceDocNoList.ToList());
                ReferenceDocPOCollection.Filter = new Predicate<object>(Filter_RefDocNo);
                StringListRefDocNo = MC.SourceDocNoList.Select(x => x.po_no).ToList();
                DefaultValues(doc_cat_vm);
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
        //private void RefreshRefence(string doc_cat_info, string ReferenceDoc)
        //{
        //    try
        //    {//"101,118,119,115,117,127,128" 
        //        string Request = "RefreshData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + this.doc_cat_vm + "!@" + AppSessionState.EmpId;
        //        MC = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "MM_T001_BL_GR", "MM", "LoadAll", 0, "");

        //        ReferenceDocPOCollection = CollectionViewSource.GetDefaultView(MC.SourceDocNoList.ToList());
        //        ReferenceDocPOCollection.Filter = new Predicate<object>(Filter_RefDocNo);
        //        StringListRefDocNo = MC.SourceDocNoList.Select(x => x.po_no).ToList();
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

        private void CreateDocument(STD_LIST_BE STD_LIST_OBJ)
        {
            try
            {//"101,118,119,115,117,127,128" 
                string Request = "EXECUTE_GRN" + "!@" + AppSessionState.client + "!@" + STD_LIST_OBJ.comp_code + "!@" + STD_LIST_OBJ.location_id + "!@" + STD_LIST_OBJ.doc_cat + "!@" + STD_LIST_OBJ.doc_type + "!@" + STD_LIST_OBJ.ref_doc_no + "!@" + STD_LIST_OBJ.ref_doc_cat + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "MM_T001_BL", "MM", "LoadAll", 0, "");

                MasterEntity = new MM_T001();
                ItemDetailsEntity = new ObservableCollection<MM_T001_A>();
                BatchDetailsEntity = new ObservableCollection<MM_T001_B>();

                MasterEntity = MC.MASTER_ENTITY_LIST[0];
                ItemDetailsEntity = MC.ITEMS_ENTITY_LIST;
                //BatchDetailsEntity = MC.BATCH_ENTITY_LIST;
                foreach (var item in MC.BATCH_ENTITY_LIST)
                {
                    foreach (var itemObj in MC.ITEMS_ENTITY_LIST) // NOTS: if item match then assign items line_id value to batch sr_line_no. This will not work if same item for different Purpose then also it will assign same line_id to columns. i.e. if sample/speciman object is same but need seperately then it will not assign seperatly, it will assign same line_id to both batch row. there is no relation with the help of group indicator other wise it will first check if both are from same group then ok but if not then it should assign seperate line_id as per MM_T001_A line_id value.
                    {
                        if (itemObj.ItemCode == item.ItemCode)
                        {
                            if (itemObj.line_id > 0)
                            {
                                dgSelectedIndexItem = itemObj.line_id - 1;
                            }
                            item.sr_line_no = itemObj.line_id;
                        }
                    }

                    BatchDetailsEntity.Add(item);
                }
                
                //Popup list
                //MC.StoreCodeList, MC.TransporterList, MC.TransportMode, MC.MovementTypeList

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
        
        private void CommandInitialization()
        {
            try
            {
                #region . Command Initialization .
                cmdAddSelectedRef = new RelayCommand<object>(items => { if (items == null) { return; } AddSelectedRef(items); });
                cmdTransport_Mode = new RelayCommand<object>(items => { if (items == null) { return; } InsertTransport_Mode(items); });
                cmdTransporter = new RelayCommand<object>(items => { if (items == null) { return; } InsertTransporterParty(items); });
                cmdMovementType = new RelayCommand<object>(items => { if (items == null) { return; } InsertMovementType(items); });
                CommandRefDocNo = new RelayCommand<object>(items => { if (items == null) { return; } InsertRefDocNo(items); });
                cmdExecuteReferenceDocument = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteReferenceDocument(items); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
                CommandUOM = new RelayCommand<object>(items => { if (items == null) { return; } InsertUOM(items, false, true, true); });
                CommandPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items, false, true, true); });
                cmdStoreLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertStoreLoc(items, false, true, true); });
                CommandDeleteDataGridRowItem = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_Item(items); });
                CreatePOCollectionCommand = new RelayCommand<IList>(items => { if (items == null) { return; } CreatePOCollectionMethod(items); });
                BatchSplitClick = new RelayCommand(() => { BatchSplit(); });
                SelectionChangeCommandItemDetails = new RelayCommand<IList>(items => { if (items == null) { return; } ItemDetailsSelectionChangedMethod(items); });
                ActiveInActiveChangeCommand = new RelayCommand<object>(items => { if (items == null) { return; } ItemActiveInActiveMethod(items); });
                BatchDataGridRowDeleteCommand = new RelayCommand<object>(items => { if (items == null) { return; } DeleteBatchDataGridRow_Item(items); });
                CommandPO = new RelayCommand<object>(items => { if (items == null) { return; } InsertDataGridRow_POAllocation(items, true, true, true); });
                PoAllocationDataGridRowDeleteCommand = new RelayCommand<object>(items => { if (items == null) { return; } DeletePoAllocationDataGridRow_Item(items); });
                CommandLoadHistory = new RelayCommand<object>(items => { if (items == null) { return; } Load_BackFlip_Data(); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });
                cmdPrintInspectionReport = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } PrintInspectionReport(cmdPara); });
                #endregion

            }
            catch (Exception ex)
            {}
        }

        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                MM_T001_FLIP ParameterEntityObject = null;
                if (ParameterObject.GetType() == typeof(string))
                {
                    Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + ParameterObject.ToString();
                }
                else
                {
                    if (((IEnumerable)ParameterObject).Cast<MM_T001_FLIP>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<MM_T001_FLIP>().ToList()[0];

                        Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.client + "!@" + ParameterEntityObject.comp_code + "!@" + ParameterEntityObject.location_Id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + ParameterEntityObject.doc_no;
                    }
                }
                NewRecord = false;
                MoveFlag = false;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MCTemp, Request, "MM_T001_BL_GR", "MM", "LoadDocumentByDocumentNumber", 0, "");
                SelectedTabControlIndex = 0;
                MasterEntity = MCTemp.GRNMasterList[0];
                ItemDetailsEntity = MCTemp.ItemDetailsList;
                BatchDetailsEntity = MCTemp.BatchDetailsList;
                POAllocationEntity = MCTemp.POAllocDetailsList;
                FilterString_RefDocNo = MasterEntity.PartyId; // when load from backflip it will show po by filtered vendor
                MasterEntity.ts_code = ts_code_vm;
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
        private void Load_BackFlip_Data()
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "Load_BackFlip_Data" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (RequestPara.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + (string.IsNullOrWhiteSpace(RequestPara.doc_cat) ? this.doc_cat_vm : RequestPara.doc_cat) + "!@" + (string.IsNullOrWhiteSpace(RequestPara.doc_type) ? MasterEntity.doc_type : RequestPara.doc_type) + "!@" + AppSessionState.EmpId + "!@" + RequestPara.PartyId + "!@" + RequestPara.t_status + "!@" + RequestPara.active + "!@" + Convert.ToDateTime(RequestPara.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(RequestPara.ToDate).ToString("MM/dd/yyyy");
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MCTemp, Request, "MM_T001_BL_GR", "MM", "Load_BackFlip_Data", 0, "");

                MC.FlipGridList = MCTemp.FlipGridList;
                FlipGridData = MCTemp.FlipGridList;
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_BackFlip);

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
        private void ExecuteReferenceDocument(object InputValue)   // this method is little complicated and lengthy need to optimize : pending optimization
        {
            try
            {
                CursorControl.SetBusyState();
                if (RequestPara.doc_no != null || RequestPara.doc_no != "")
                {
                    string Request = "ExecuteReferenceDocument" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID + "!@" + RequestPara.doc_no + "!@" + RequestPara.doc_cat + "!@" + RequestPara.ref_doc;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MCTemp, Request, "MM_T001_BL_GR", "MM", "ExecuteReferenceDocument", 0, "");

                    if (MCTemp.GRNMasterList.Count > 0)
                    {
                        MasterEntity = MCTemp.GRNMasterList[0];
                        ItemDetailsEntity = MCTemp.ItemDetailsList;
                        BatchDetailsEntity = MCTemp.BatchDetailsList;
                        POAllocationEntity = MCTemp.POAllocDetailsList;
                        MasterEntity.ts_code = ts_code_vm;
                    }
                    Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        private void AddSelectedRef(object InputValue)
        {
            try
            {
                PUR_T002_A_P POPUPEntityObject = null;
                string Request;
                RequestPara.doc_no = null;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.SourceDocNoList.Where(x => x.po_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<PUR_T002_A_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PUR_T002_A_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {


                    if (POPUPEntityObject.doc_cat == "RT" || POPUPEntityObject.doc_cat == "TO" || POPUPEntityObject.doc_cat == "PO" || POPUPEntityObject.doc_cat == "OP" || POPUPEntityObject.doc_cat == "NP" || POPUPEntityObject.doc_cat == "DT" || POPUPEntityObject.doc_cat == "SO")
                    {
                        // Clear Other reference.
                        var refdocData = (from o in MC.SourceDocNoList where o.doc_cat != POPUPEntityObject.doc_cat select o);
                        if (refdocData != null)
                        {
                            foreach (var item in refdocData)
                            {
                                item.Select = false;
                            }
                        }
                        if (POPUPEntityObject.Select == true)
                        {
                            RequestPara.doc_cat = POPUPEntityObject.doc_cat;
                            RequestPara.doc_type = POPUPEntityObject.doc_type;
                            RequestPara.doc_no = "";
                            var refdocTO = from o in MC.SourceDocNoList
                                           where o.PartyId == POPUPEntityObject.PartyId
                                           && o.doc_cat == POPUPEntityObject.doc_cat
                                           select o;
                            ReferenceDocPOCollection = CollectionViewSource.GetDefaultView(refdocTO);
                            ReferenceDocPOCollection.Filter = new Predicate<object>(Filter_RefDocNo);
                        }
                        else // if user uncheck all records then it should be relist all records.
                        {
                            List<PUR_T002_A_P> refdocTOR = (from o in MC.SourceDocNoList where o.doc_cat == POPUPEntityObject.doc_cat && o.Select == true select o).ToList();
                            if (refdocTOR.Count == 0)
                            {
                                ReferenceDocPOCollection = CollectionViewSource.GetDefaultView(MC.SourceDocNoList);
                                ReferenceDocPOCollection.Filter = new Predicate<object>(Filter_RefDocNo);
                            }
                        }
                        List<PUR_T002_A_P> refdocTOM = (from o in MC.SourceDocNoList where o.doc_cat == RequestPara.doc_cat && o.Select == true select o).ToList();
                        foreach (var item in refdocTOM)
                        {
                            if (item.Select == true)
                            {
                                RequestPara.doc_no = RequestPara.doc_no + "," + item.po_no;
                                RequestPara.ref_doc = item.delivery_no;
                            }
                        }

                        if(RequestPara.doc_no != null)
                        {
                            RequestPara.doc_no = RequestPara.doc_no.ToString().TrimStart(new char[] { ',' });
                        }
                    }
                }
            }
            catch (Exception Ex) { }
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
                    MasterEntity.tr_name = POPUPEntityObject.tr_name;
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
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
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
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            try
            {

                if (sender.ToString() == "qty" && dgSelectedIndexItem != -1 && dgSelectedIndexItem < ItemDetailsEntity.Count && POAllocationEntity != null)
                {
                    var InputValueIfExists2 = POAllocationEntity.Where(X => X.ItemCode == ItemDetailsEntity[dgSelectedIndexItem].ItemCode && X.sku == ItemDetailsEntity[dgSelectedIndexItem].sku && X.po_no == ItemDetailsEntity[dgSelectedIndexItem].source_doc_no).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue2 = POAllocationEntity.IndexOf(POAllocationEntity.Where(X => X.ItemCode == ItemDetailsEntity[dgSelectedIndexItem].ItemCode && X.sku == ItemDetailsEntity[dgSelectedIndexItem].sku && X.po_no == ItemDetailsEntity[dgSelectedIndexItem].source_doc_no).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (IndexOfExistValue2 != -1)
                    {
                        POAllocationEntity[IndexOfExistValue2].rec_qty = Convert.ToDecimal(ItemDetailsEntity[dgSelectedIndexItem].qty);
                    }
                }

                if ((sender.ToString() == "qty" || sender.ToString() == "unit_price") && dgSelectedIndexItem != -1 && ItemDetailsEntity != null && ItemDetailsEntity.Count > 0 && dgSelectedIndexItem < ItemDetailsEntity.Count)
                {
                    ItemDetailsEntity[dgSelectedIndexItem].amt_loc = ItemDetailsEntity[dgSelectedIndexItem].qty * ItemDetailsEntity[dgSelectedIndexItem].unit_price;
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
                        {
                            POPUPEntityObject = ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
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
                string Request = "";
                MM_M001_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.StoreCodeList.Where(x => x.store_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<MM_M001_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M001_P>().ToList()[0];
                    }
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    if (dgSelectedIndexItem >= 0 && ItemDetailsEntity.Count > dgSelectedIndexItem)
                    {
                        ItemDetailsEntity[dgSelectedIndexItem].store_code = POPUPEntityObject.store_code;
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
            try
            {
                if (dgSelectedIndexItem != -1 && ItemDetailsEntity.Count > 0 && MC.SourceDocNoList.Count > 0 && dgSelectedIndexItem < ItemDetailsEntity.Count)
                {
                    var pocollectiontemp = (from o in MC.SourceDocNoList where o.ItemCode == ItemDetailsEntity[dgSelectedIndexItem].ItemCode && o.sku == ItemDetailsEntity[dgSelectedIndexItem].sku select o).ToList();
                    FilteredPOCollection = CollectionViewSource.GetDefaultView(pocollectiontemp.ToList());
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
            try
            {
                IList list = InputList as IList;
                if (dgSelectedIndexItem != -1 && ItemDetailsEntity.Count > 0 && ItemDetailsEntity.Count > dgSelectedIndexItem)
                {
                    List<MM_T001_A> selectedlist = list.Cast<MM_T001_A>().ToList();

                    if (selectedlist.Count > 0)
                    {
                        SelectedItemObject = selectedlist[0];
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
                if (e.Action == NotifyCollectionChangedAction.Add && ItemDetailsEntity.Count > 0) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (MM_T001_B item in e.NewItems)
                    {
                        //Adde items Schedules Default Values from Items Entity
                        if (dgSelectedIndexItem <= ItemDetailsEntity.Count)
                        {
                            item.item_line_id = ItemDetailsEntity[dgSelectedIndexItem].id;
                            item.doc_no = MasterEntity.doc_no;
                            item.ItemCode = ItemDetailsEntity[dgSelectedIndexItem].ItemCode;
                            item.sr_line_no = ItemDetailsEntity[dgSelectedIndexItem].line_id;
                            item.qty = item.qty ?? ItemDetailsEntity[dgSelectedIndexItem].qty;
                            item.rec_qty = item.rec_qty ?? ItemDetailsEntity[dgSelectedIndexItem].qty;
                            item.unit_code = ItemDetailsEntity[dgSelectedIndexItem].unit_code;
                            item.description = ItemDetailsEntity[dgSelectedIndexItem].description;
                            item.t_status = ItemDetailsEntity[dgSelectedIndexItem].t_status;
                            item.location_Id = ItemDetailsEntity[dgSelectedIndexItem].location_Id;
                            item.comp_code = ItemDetailsEntity[dgSelectedIndexItem].comp_code;
                            item.wa_code = ItemDetailsEntity[dgSelectedIndexItem].wa_code;
                            item.store_code = ItemDetailsEntity[dgSelectedIndexItem].store_code;
                            item.active = ItemDetailsEntity[dgSelectedIndexItem].active;
                            item.add_by = AppSessionState.UserID;
                            item.editby = AppSessionState.UserID;
                            item.sku = ItemDetailsEntity[dgSelectedIndexItem].sku;
                            item.pono = ItemDetailsEntity[dgSelectedIndexItem].po_no;
                            item.t_display = (from o in MC.STATUS_LIST where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
                        }
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
            if (BatchDetailsEntity.Count > i && BatchDetailsEntity[i].id != 0 && NewRecord==true) //  if advance batch true then check for this condition and remove.
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
                            comp_code = AppSessionState.OBJ_COMPANY.comp_code,
                            location_Id = AppSessionState.OBJ_LOCATION.location_id,
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
                            POAllocationEntity[dgSelectedIndexPOAllocation].comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                            POAllocationEntity[dgSelectedIndexPOAllocation].location_Id = AppSessionState.OBJ_LOCATION.location_id;
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
        //Validation Function
        private bool Validations()
        {
            try
            {
                if (MasterEntity.mov_tp == null || MasterEntity.mov_tp == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Validation";
                    showMessageService.Text = String.Format("Please select Movement Type");
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
                if (MasterEntity.mov_tp == "101")
                {
                    if (MasterEntity.source_doc_no == null || MasterEntity.source_doc_no == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation";
                        showMessageService.Text = String.Format("Reference Document Number is Not Selected For Movement type Goods Receipt Of Purchase Order");
                        showMessageService.ShowMessage();
                        return false;
                    }
                }

                if (MasterEntity.mov_tp == "117")
                {
                    if (MasterEntity.source_doc_no == null || MasterEntity.source_doc_no == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation";
                        showMessageService.Text = String.Format("Reference Document Number is Not Selected For Movement type Goods Receipt Of Purchase Order");
                        showMessageService.ShowMessage();
                        return false;
                    }
                }

                #region . Validation for Item Duplication, null Unit Code and Null or 0 Quantity For All Active Items .
                // Validation for Quantity Item Duplication and Unit Code For Item Details
                foreach (var o in ItemDetailsEntity)
                {
                    int flag = 0;
                    if (o.active == true)
                    {    // Item Duplication Validation
                        foreach (var p in ItemDetailsEntity)
                        {
                            if (o.line_id == p.line_id && p.active == true)
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
                            showMessageService.Text = String.Format("Please Enter Valid Location for the item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.store_code == null || o.store_code == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Enter Valid Storage Location for the item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemDetailsEntity.IndexOf(o));
                            showMessageService.ShowMessage();
                            return false;
                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("No ItemCode is Present at Index {0} \n Delete This Blank Row", ItemDetailsEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }
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
                            if (ItemDetailsEntity[i].ItemCode == BatchDetailsEntity[j].ItemCode && ItemDetailsEntity[i].sku == BatchDetailsEntity[j].sku && BatchDetailsEntity[j].active == true && ItemDetailsEntity[i].line_id == BatchDetailsEntity[j].sr_line_no && ItemDetailsEntity[i].id == BatchDetailsEntity[j].item_line_id)
                            {
                                temp = temp + Convert.ToDecimal(BatchDetailsEntity[j].qty);
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
                            return false;
                        }
                    }
                }
                #endregion
                #region . PO Allocation Validation .
                if (POAllocationEntity != null)
                {
                    foreach (var q in POAllocationEntity)
                    {
                        if (q.rec_qty == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Validation : PO Allocation";
                            showMessageService.Text = String.Format(" Please Enter Quantity Greater Than 0 For PO/Ref/Challan {0} At Index {1}", q.po_no, POAllocationEntity.IndexOf(q));
                            showMessageService.ShowMessage();
                            return false;
                        }
                    }
                }
                #endregion
                return true;
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
                return false;
            }

        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                }
                else if (STD_LIST_OBJECT != null)
                {
                    CreateDocument(STD_LIST_OBJECT);
                }
                else
                {
                    DefaultValues(doc_cat_vm);
                    GRN_DOCCAT.Add(new GRN_DOC_CAT { doc_cat = "GR", cat_desc = "Goods Receipt" });
                    GRN_DOCCAT.Add(new GRN_DOC_CAT { doc_cat = "GT", cat_desc = "Goods Receipt P2P" });
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((GRN_DOC_CAT)x).doc_cat);
                    TheFilter = (o, prefix) => (((GRN_DOC_CAT)o).doc_cat ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((GRN_DOC_CAT)o).cat_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASDOC_CAT = new AutoSuggestTextViewModel<dynamic>(GRN_DOCCAT, TheFilter, SuggestedValue, "doc_cat", true);
                    ASDOC_CAT.AutoSuggestVM.IsEmptyValueAllowed = false;
                }
                
                //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        #region . Command Actions .
        protected override void OnSaveAction(InquiryActionResult<MM_T001> result)
        {
            try
            {
                if (Validations() == true)
                {
                    MasterEntity.XmlDataDocument_MM_T001_A = obj.ObjectToXML(ItemDetailsEntity);
                    MasterEntity.XmlDataDocument_MM_T001_B = obj.ObjectToXML(BatchDetailsEntity);
                    if (POAllocationEntity != null)
                    {
                        MasterEntity.XmlDataDocument_MM_T001_C = obj.ObjectToXML(POAllocationEntity);
                    }
                    Logging();
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<MM_T001>(MasterEntity, "MM_T001_BL_GR", "MM");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<MM_T001>(MasterEntity, "MM_T001_BL_GR", "MM");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    NewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                    MoveFlag = false;  // after save movement type cannot be changed
                    RemoveRefDoc();
                    
                    
                    Messenger.Default.Send<NotificationMessage>(new NotificationMessage(MasterEntity,"REFRESH_RMGR_LIST")); // This will call Sample Collection VM (MM_T018_VM) for update list data on GRN done.
                    //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(STD_LIST_OBJECT, "REFRESH_RMGR_LIST")); // This will call Sample Collection VM (MM_T018_VM) for update list data on GRN done.

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Record created successfully!", this.Title);
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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
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
                    
                    if (BatchDetailsEntity != null)
                    {
                        BatchDetailsEntity.Clear();
                    }
                    if (MC.BatchDetailsList != null)
                    {
                        BatchDetailsEntity = MC.BatchDetailsList;
                    }
                }
                else
                {
                    MC.BatchDetailsList = new ObservableCollection<MM_T001_B>();
                }

                if (MasterEntity.XmlDataDocument_MM_T001_C != null)
                {
                    MC.POAllocDetailsList = (ObservableCollection<MM_T001_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_MM_T001_C, MC.POAllocDetailsList);
                    if (POAllocationEntity != null)
                    {
                        POAllocationEntity.Clear();
                    }
                    if (MC.POAllocDetailsList != null)
                    {
                        POAllocationEntity = MC.POAllocDetailsList;
                    }
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
                if (MC.SourceDocNoList != null)
                {
                    MC.SourceDocNoList.RemoveAll(X => X.Select == true);
                    ReferenceDocPOCollection = CollectionViewSource.GetDefaultView(MC.SourceDocNoList.ToList());
                    ReferenceDocPOCollection.Filter = new Predicate<object>(Filter_RefDocNo);
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
        protected override void OnCreateAction(InquiryActionResult<MM_T001> result)
        {
            try
            {
                NewRecord = true; MoveFlag = true;
                MasterEntity = new MM_T001();
                ItemDetailsEntity = new ObservableCollection<MM_T001_A>();
                BatchDetailsEntity = new ObservableCollection<MM_T001_B>();
                POAllocationEntity = new ObservableCollection<MM_T001_C>();
                MasterEntity.ValidateAsync().Wait();
                DefaultValues(doc_cat_vm);
                FilterString_RefDocNo = "";
            }
            catch (Exception ex)
            { }
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
                POAllocationEntity = new ObservableCollection<MM_T001_C>();
                _FlipDataGridCollection.Refresh();
                NewRecord = true;
                FilterString_RefDocNo = "";
                MoveFlag = true;
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<MM_T001> result)
        { }
        protected override void OnFevoriteAction(InquiryActionResult<MM_T001> result)
        { }
        protected override void OnFlipAction(InquiryActionResult<MM_T001> result)
        {
            string Request = "RefreshData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + this.doc_cat_vm + "!@" + AppSessionState.EmpId;
            MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "MM_T001_BL_GR", "MM", "RefreshData", 0, "");
            MC.SourceDocNoList = MCTemp.SourceDocNoList;
            if (NewRecord == false)
            {
                FilterString_RefDocNo = MasterEntity.PartyId; // when load from backflip it will show po by filtered vendor
            }
            else
            {
                FilterString_RefDocNo = "";
            }
        }
        protected override void OnHelpAction(InquiryActionResult<MM_T001> result)
        { }
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
                string Request = "Rpt_GRN" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_no + "!@" + MasterEntity.mov_tp;

                MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MCTemp, Request, "MM_T001_BL_GR", "MM", "LoadAll", 0, "");
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
                objDataSourceName[2] = "dsGRN";
                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\SCM\\GRN.rdlc", "GRN");
            }
        }
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            {
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.Attachment, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<MM_T001> result)
        {
            string Request = "RefreshData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + this.doc_cat_vm + "!@" + AppSessionState.EmpId;
            MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "MM_T001_BL_GR", "MM", "RefreshData", 0, "");
            MC.SourceDocNoList = MCTemp.SourceDocNoList;
            if (NewRecord == false)
            {
                FilterString_RefDocNo = MasterEntity.PartyId; // when load from backflip it will show po by filtered vendor
            }
            else
            {
                FilterString_RefDocNo = "";
            }
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
        { }
        private void OpenDocumentViewer(object InputValue)
        {
            WebServiceRepository<MultipleContext_Attachments> repository_MCAttachments = new WebServiceRepository<MultipleContext_Attachments>();
            List<COM_T003> Attachments = new List<COM_T003>();
            MM_T001_A EntityObjectParameter = new MM_T001_A();
            MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();
            try
            {
                if (InputValue != null)
                {
                    EntityObjectParameter = ((IEnumerable)InputValue).Cast<MM_T001_A>().ToList()[0];
                }
                string Request = "GetAllFiles" + "!@" + AppSessionState.client + "!@" + (EntityObjectParameter.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (EntityObjectParameter.location_Id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + (doc_cat_vm ?? "") + "!@" + doc_cat_vm + "!@" + EntityObjectParameter.doc_no + "!@" + EntityObjectParameter.id.ToString();
                MCAttachments = repository_MCAttachments.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(EntityObjectParameter.ItemCode))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), Row_ID = EntityObjectParameter.id.ToString(), DocumentList = MCAttachments.Attachments, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
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


        private STD_MIS_MC_BE _MC_TEMP = new STD_MIS_MC_BE();
        public STD_MIS_MC_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set { if (_MC_TEMP != value) { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); } }
        }
        private void PrintInspectionReport(object InputValue)
        {
            
            try
            {
                CursorControl.SetBusyState();
                object[] objDataSource = new object[7];
                string[] objDataSourceName = new string[7];
                if (SelectedItemObject != null)
                {
                    // QMS section hardcoded
                    WebServiceRepository<STD_MIS_MC_BE> repository_MC = new WebServiceRepository<STD_MIS_MC_BE>();
                    string RequestParameter = "REPORT" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@!@" + MasterEntity.doc_no + "!@R0012!@!@" + MasterEntity.doc_no + "!@" + MasterEntity.doc_no + "!@" + (SelectedItemObject.asset_no ?? "");
                    MC_TEMP = repository_MC.GetDataWithReturnDomainObject<STD_MC_BE>(MC_TEMP, RequestParameter, "QMS_R02_BL", "QMS", " ", 0, "");

                    var obj_comp = AppSessionState.COMPANY_LIST.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    var obj_loc = AppSessionState.LOCATION_LIST.Where(loc => loc.location_id == MasterEntity.location_Id).ToList();
                    var obj_doc_type = MC.DOCTYPE_LIST.Where(x => x.doc_type == MasterEntity.doc_type).ToList();

                    if (MC.MasterEntity != null)
                    {
                        if (MC.MasterEntity.Count > 0)
                        {
                            MC.MasterEntity.Clear();
                            MC.MasterEntity.Add(MasterEntity);
                        }
                        else
                        {
                            MC.MasterEntity.Add(MasterEntity);
                        }
                    }

                    objDataSource[0] = obj_comp;
                    objDataSource[1] = obj_loc;
                    objDataSource[2] = MC.MasterEntity;
                    objDataSource[3] = ItemDetailsEntity;
                    objDataSource[4] = BatchDetailsEntity;
                    objDataSource[5] = MC_TEMP.STD_MIS_LIST;
                    objDataSource[6] = obj_doc_type;

                    objDataSourceName[0] = "dsCompany";
                    objDataSourceName[1] = "dsLocation";
                    objDataSourceName[2] = "dsMaster";
                    objDataSourceName[3] = "dsItems";
                    objDataSourceName[4] = "dsBatch";
                    objDataSourceName[5] = "dsMIS_1";
                    objDataSourceName[6] = "dsDocument";
                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\TXN\\GR_D001.rdlc", "GRN");
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Selecte Item for report generation", this.Title);
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
                        data.source_doc_no != null && data.source_doc_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()) ||
                        data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()) ||
                        data.com_inv_no != null && data.com_inv_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()) ||
                        data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()));
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
            if (ReferenceDocPOCollection != null)
            {
                _ReferenceDocPOCollection.Refresh();
            }
        }
        public bool Filter_RefDocNo(object obj)
        {
            var data = obj as PUR_T002_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_RefDocNo))
                {
                    return (data.po_no != null && data.po_no.ToString().ToLower().Contains(_filterString_RefDocNo.ToLower()) ||
                    data.SupplierNm != null && data.SupplierNm.ToString().ToLower().Contains(_filterString_RefDocNo.ToLower()) ||
                    data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_RefDocNo.ToLower()));
                }
                return true;
            }
            return false;
        }


        #endregion
        #endregion
    }
}
