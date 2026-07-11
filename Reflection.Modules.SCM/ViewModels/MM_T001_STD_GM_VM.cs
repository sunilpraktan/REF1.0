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
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.MM;

namespace Reflection.Modules.SCM.ViewModels
{
    public class MM_T001_STD_GM_VM : WorkspaceViewModel<MM_T001>
    {
        #region . Variable Declaration And Object .
        private bool NewRecord = true;
        private bool EntityChangeEnable = true;

        private string ts_code_vm { get; set; }
        private string doc_no_vm { get; set; }
        private string doc_cat_vm { get; set; }

        WebServiceRepository<MM_T001> repository = new WebServiceRepository<MM_T001>();
        WebServiceRepository<MC_MM_T001_STD> repository_MC = new WebServiceRepository<MC_MM_T001_STD>();
        ObjectSerializationService obj = new ObjectSerializationService();
        IShowMessageViewService sms;

        MC_MM_T001_STD _MC = new MC_MM_T001_STD();
        public MC_MM_T001_STD MC
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

        MC_MM_T001_STD _MCTemp = new MC_MM_T001_STD();
        public MC_MM_T001_STD MCTemp
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
        private STD_REQ_PARA_BE _REQ_PARA_OBJ;
        public STD_REQ_PARA_BE REQ_PARA_OBJ
        {
            get { return _REQ_PARA_OBJ; }
            set
            {
                if (_REQ_PARA_OBJ != value)
                {
                    _REQ_PARA_OBJ = value;

                    RaisePropertyChanged("REQ_PARA_OBJ");
                }
            }
        }

        private ObservableCollection<MM_T001_A> _ItemsEntity;
        public ObservableCollection<MM_T001_A> ItemsEntity
        {
            get
            {
                return _ItemsEntity;
            }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }
        private MM_T001_A _MM_T001_A_OBJ;
        public MM_T001_A MM_T001_A_OBJ
        {
            get
            {
                return _MM_T001_A_OBJ;
            }
            set
            {
                if (_MM_T001_A_OBJ != value)
                {
                    _MM_T001_A_OBJ = value;
                    RaisePropertyChanged("MM_T001_A_OBJ");
                    FilterBatchDataGrid();
                    if (SelectedTabIndex == 1)
                    {
                        TabItemSelectionChanged(SelectedTabIndex);
                    }
                }
            }
        }
        private MM_T001_B _MM_T001_B_OBJ;
        public MM_T001_B MM_T001_B_OBJ
        {
            get
            {
                return _MM_T001_B_OBJ;
            }
            set
            {
                if (_MM_T001_B_OBJ != value)
                {
                    _MM_T001_B_OBJ = value;
                    RaisePropertyChanged("MM_T001_B_OBJ");
                }
            }
        }
        private decimal? _required_qty;
        public decimal? required_qty
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
        private decimal? _packed_qty;
        public decimal? packed_qty
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
        private decimal? _bal_qty;
        public decimal? bal_qty
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
        private ObservableCollection<MM_T001_B> _BatchEntity;
        public ObservableCollection<MM_T001_B> BatchEntity
        {
            get
            {
                return _BatchEntity;
            }
            set
            {
                if (_BatchEntity != value)
                {
                    _BatchEntity = value;
                    BatchEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
                    RaisePropertyChanged("BatchEntity");
                }
            }
        }
        private ICollectionView _PARAMETERS_COL_SELECTED;
        public ICollectionView PARAMETERS_COL_SELECTED
        {
            get { return _PARAMETERS_COL_SELECTED; }
            set
            {
                _PARAMETERS_COL_SELECTED = value;
                RaisePropertyChanged("PARAMETERS_COL_SELECTED");
            }
        }
        private List<ADM_M0071> _PARAMETERS_LIST_SELECTED;
        public List<ADM_M0071> PARAMETERS_LIST_SELECTED
        {
            get { return _PARAMETERS_LIST_SELECTED; }
            set
            {
                if (_PARAMETERS_LIST_SELECTED != value)
                {
                    _PARAMETERS_LIST_SELECTED = value;
                    RaisePropertyChanged("PARAMETERS_LIST_SELECTED");
                }
            }
        }
        private ADM_M0071 _PARAMETERS_OBJ;
        public ADM_M0071 PARAMETERS_OBJ
        {
            get { return _PARAMETERS_OBJ; }
            set
            {
                if (_PARAMETERS_OBJ != value)
                {
                    _PARAMETERS_OBJ = value;
                    RaisePropertyChanged("PARAMETERS_OBJ");
                    SelectionChangedParaValue("");
                }
            }
        }
        private ADM_M0071 _PARAMETERS_VALUE_OBJ;
        public ADM_M0071 PARAMETERS_VALUE_OBJ
        {
            get { return _PARAMETERS_VALUE_OBJ; }
            set
            {
                if (_PARAMETERS_VALUE_OBJ != value)
                {
                    _PARAMETERS_VALUE_OBJ = value;
                    RaisePropertyChanged("PARAMETERS_VALUE_OBJ");
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
                }
            }
        }

        //private List<STD_PARAMETERS_VALUES> _SelectedParaValueCollection = new List<STD_PARAMETERS_VALUES>();
        //public List<STD_PARAMETERS_VALUES> SelectedParaValueCollection
        //{
        //    get { return _SelectedParaValueCollection; }
        //    set
        //    {
        //        if (_SelectedParaValueCollection != value)
        //        {
        //            _SelectedParaValueCollection = value;
        //            RaisePropertyChanged("SelectedParaValueCollection");
        //        }
        //    }
        //}

        private List<STD_LIST_BE> _FlipGridData;
        public List<STD_LIST_BE> FlipGridData
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

        private bool _ind_Batch_Tab_Enabled;   // NOTE:This indicator will operate Batch Tab Visibility, Enable, readonly etc.. property as per require. i.e. Mov Type 107 is for Material Conversion so Batch tab not required to operate from user, user will use "batch_no" column of Item Grid. he will convert one by one entry if multiple batches required to transfer. right now we cannot give bulk conversion in single entry.
        public bool ind_Batch_Tab_Enabled
        {
            get { return _ind_Batch_Tab_Enabled; }
            set { _ind_Batch_Tab_Enabled = value; RaisePropertyChanged("ind_Batch_Tab_Enabled"); }
        }
        private int _SelectedTabIndex;
        public int SelectedTabIndex
        {
            get { return _SelectedTabIndex; }
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
        private int _SelectedTabIndexMain;
        public int SelectedTabIndexMain
        {
            get { return _SelectedTabIndexMain; }
            set
            {
                if (_SelectedTabIndexMain != value)
                {
                    _SelectedTabIndexMain = value;
                    RaisePropertyChanged("SelectedTabIndexMain");
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
        #region. AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(MM_T001_STD_GM_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
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
        private AutoSuggestTextViewModel<dynamic> _AS_DOC_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DOC_TYPE
        {
            get { return _AS_DOC_TYPE; }
            set
            {
                if (_AS_DOC_TYPE != value)
                {
                    _AS_DOC_TYPE = value; RaisePropertyChanged("AS_DOC_TYPE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ITEM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ITEM
        {
            get { return _AS_ITEM; }
            set
            {
                if (_AS_ITEM != value)
                {
                    _AS_ITEM = value; RaisePropertyChanged("AS_ITEM");
                }
            }
        }
        //private AutoSuggestTextViewModel<dynamic> _AS_REF_DOC_TYPE { get; set; }
        //public AutoSuggestTextViewModel<dynamic> AS_REF_DOC_TYPE
        //{
        //    get { return _AS_REF_DOC_TYPE; }
        //    set
        //    {
        //        if (_AS_REF_DOC_TYPE != value)
        //        {
        //            _AS_REF_DOC_TYPE = value; RaisePropertyChanged("AS_REF_DOC_TYPE");
        //        }
        //    }
        //}
        private AutoSuggestTextViewModel<dynamic> _AS_REF_DOC_CAT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_REF_DOC_CAT
        {
            get { return _AS_REF_DOC_CAT; }
            set
            {
                if (_AS_REF_DOC_CAT != value)
                {
                    _AS_REF_DOC_CAT = value; RaisePropertyChanged("AS_REF_DOC_CAT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_REF_DOC_LIST { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_REF_DOC_LIST
        {
            get { return _AS_REF_DOC_LIST; }
            set
            {
                if (_AS_REF_DOC_LIST != value)
                {
                    _AS_REF_DOC_LIST = value; RaisePropertyChanged("AS_REF_DOC_LIST");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_POSTING_KEY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_POSTING_KEY
        {
            get { return _AS_POSTING_KEY; }
            set
            {
                if (_AS_POSTING_KEY != value)
                {
                    _AS_POSTING_KEY = value; RaisePropertyChanged("AS_POSTING_KEY");
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
        private AutoSuggestTextViewModel<dynamic> _AS_STORAGE_LOCATION { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_STORAGE_LOCATION
        {
            get { return _AS_STORAGE_LOCATION; }
            set
            {
                if (_AS_STORAGE_LOCATION != value)
                {
                    _AS_STORAGE_LOCATION = value; RaisePropertyChanged("AS_STORAGE_LOCATION");
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
        private AutoSuggestTextViewModel<dynamic> _AS_STATUS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_STATUS
        {
            get { return _AS_STATUS; }
            set
            {
                if (_AS_STATUS != value)
                {
                    _AS_STATUS = value; RaisePropertyChanged("AS_STATUS");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_MOV_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_MOV_TYPE
        {
            get { return _AS_MOV_TYPE; }
            set
            {
                if (_AS_MOV_TYPE != value)
                {
                    _AS_MOV_TYPE = value; RaisePropertyChanged("AS_MOV_TYPE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASPersonnel { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPersonnel
        {
            get { return _ASPersonnel; }
            set
            {
                if (_ASPersonnel != value)
                {
                    _ASPersonnel = value; RaisePropertyChanged("ASPersonnel");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDepartment { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDepartment
        {
            get { return _ASDepartment; }
            set
            {
                if (_ASDepartment != value)
                {
                    _ASDepartment = value; RaisePropertyChanged("ASDepartment");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_BATCH { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_BATCH
        {
            get { return _AS_BATCH; }
            set
            {
                if (_AS_BATCH != value)
                {
                    _AS_BATCH = value; RaisePropertyChanged("AS_BATCH");
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
                    if (SourceName == "ItemCode")
                    { ASDefault = AS_ITEM; }
                    else if (SourceName == "unit_code")
                    { ASDefault = ASUOM; }
                    else if (SourceName == "store_code")
                    { ASDefault = AS_STORAGE_LOCATION; }
                    else if (SourceName == "batch_no")
                    {
                        List<STD_ITEM> OBJ_STD = new List<STD_ITEM>();
                        OBJ_STD = MC.BATCH_LIST.Where(x => x.store_code == MM_T001_A_OBJ.store_code && x.item_code == MM_T001_A_OBJ.ItemCode && x.comp_code == MM_T001_A_OBJ.comp_code).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).batch_no);
                        TheFilter = (o, prefix) => ((STD_ITEM)o).batch_no.ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).sku_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        AS_BATCH = new AutoSuggestTextViewModel<dynamic>(OBJ_STD, TheFilter, SuggestedValue, "batch_no", true);
                        AS_BATCH.AutoSuggestVM.IsEmptyValueAllowed = false; AS_BATCH.AutoSuggestVM.IsFreeTextAllowed = false;
                        ASDefault = AS_BATCH;
                    }


                }
            }
        }

        #endregion
        #region . ICollectionView .
        private ICollectionView _HUCollection;
        public ICollectionView HUCollection
        {
            get { return _HUCollection; }
            set { _HUCollection = value; RaisePropertyChanged("HUCollection"); }
        }
        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
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

        #endregion
        #region . Relay Commands .
        public RelayCommand<object> cmdInsertDocumentType { get; private set; }
        public RelayCommand<object> cmdInsertReferenceDocumentType { get; private set; }
        public RelayCommand<object> cmdInsertMovementType { get; private set; }
        public RelayCommand<object> cmdInsertItem { get; private set; }
        public RelayCommand<object> cmdInsertBatch { get; private set; }
        public RelayCommand<object> cmdExecuteReferenceDocument { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowBatch { get; private set; }
        public RelayCommand<object> cmdSelectionChangedItem { get; private set; }
        public RelayCommand<object> cmdSelectionChangedBatch { get; private set; }
        public RelayCommand<object> cmdSelectionChangedParaValue { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByNumber { get; private set; }
        public RelayCommand<object> cmdLoadBackFlipData { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdClick_SKU_ToggleButton { get; private set; }
        public RelayCommand<object> cmdExecuteBatchInsert { get; private set; }
        public RelayCommand BatchSplitClick { get; private set; }
        public RelayCommand<string> cmdBarcode { get; private set; }
        #endregion
        #region . Constructor .
        public MM_T001_STD_GM_VM(string ts_code) : base()
        {
            MoveFlag = true;
            this.ts_code_vm = ts_code;
            MC = new MC_MM_T001_STD();
            MCTemp = new MC_MM_T001_STD();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MasterEntity = new MM_T001();
            ItemsEntity = new ObservableCollection<MM_T001_A>();
            BatchEntity = new ObservableCollection<MM_T001_B>();
            MM_T001_A_OBJ = new MM_T001_A();
            MM_T001_B_OBJ = new MM_T001_B();
            PARAMETERS_VALUE_OBJ = new ADM_M0071();
            MM_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            MM_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            MM_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Batch);
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            BatchEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
            sms = this.GetViewService<IShowMessageViewService>();
            LoadInitialData(doc_cat_vm, null);
            InitialzeCommands();
        }
        public MM_T001_STD_GM_VM(string doc_cat, string ts_code) : base()
        {
            MoveFlag = true;
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            MC = new MC_MM_T001_STD();
            MCTemp = new MC_MM_T001_STD();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MasterEntity = new MM_T001();
            ItemsEntity = new ObservableCollection<MM_T001_A>();
            BatchEntity = new ObservableCollection<MM_T001_B>();
            MM_T001_A_OBJ = new MM_T001_A();
            MM_T001_B_OBJ = new MM_T001_B();
            PARAMETERS_VALUE_OBJ = new ADM_M0071();
            MM_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            MM_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            MM_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Batch);
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            BatchEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
            sms = this.GetViewService<IShowMessageViewService>();
            LoadInitialData(doc_cat_vm, null);
            InitialzeCommands();
        }
        public MM_T001_STD_GM_VM(string doc_cat, string ts_code, string doc_no) : base()
        {
            MoveFlag = true;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            this.doc_cat_vm = doc_cat;
            MC = new MC_MM_T001_STD();
            MCTemp = new MC_MM_T001_STD();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MasterEntity = new MM_T001();
            ItemsEntity = new ObservableCollection<MM_T001_A>();
            BatchEntity = new ObservableCollection<MM_T001_B>();
            MM_T001_A_OBJ = new MM_T001_A();
            MM_T001_B_OBJ = new MM_T001_B();
            PARAMETERS_VALUE_OBJ = new ADM_M0071();
            MM_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            MM_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            MM_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Batch);
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            BatchEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
            sms = this.GetViewService<IShowMessageViewService>();
            LoadInitialData(doc_cat_vm, null);
            InitialzeCommands();
        }
        #endregion
        private void InitialzeCommands()
        {
            cmdExecuteReferenceDocument = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteReferenceDocument(items); });
            cmdInsertDocumentType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocumentType(items); });
            cmdInsertReferenceDocumentType = new RelayCommand<object>(items => { if (items == null) { return; } InsertReferenceDocumentType(items); });
            cmdInsertMovementType = new RelayCommand<object>(items => { if (items == null) { return; } InsertMovementType(items); });
            cmdInsertItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
            cmdInsertBatch = new RelayCommand<object>(items => { if (items == null) { return; } InsertBatch(items); });
            cmdDeleteDataGridRowItem = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_Item(items); });
            cmdDeleteDataGridRowBatch = new RelayCommand<object>(items => { if (items == null) { return; } DeleteBatchDataGridRow_Item(items); });
            cmdSelectionChangedItem = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChangedItem(items); });
            cmdSelectionChangedBatch = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChangedBatch(items); });
            cmdSelectionChangedParaValue = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChangedParaValue(items); });
            cmdLoadDocumentByNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByNumber(items, "FlipGridReference"); });
            cmdLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } Load_BackFlip_Data(); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdClick_SKU_ToggleButton = new RelayCommand<object>(items => { if (items == null) { return; } Click_SKU_ToggleButton(items); });
            cmdExecuteBatchInsert = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteBatchInsert(items); });
            BatchSplitClick = new RelayCommand(() => { BatchSplit(); });
            cmdBarcode = new RelayCommand<string>(Items => { if (Items == null) { return; } ScanBarcode(Items); });
            sms = this.GetViewService<IShowMessageViewService>();
        }
        #region . User Defined Functions .
        private void DefaultValues(string doc_cat_info)
        {
            MasterEntity.doc_cat = this.doc_cat_vm;
            MasterEntity.doc_type = this.doc_cat_vm;
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.doc_code = this.doc_cat_vm;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.t_status = "001";
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.post_date = DateTime.Now;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.dept_code = AppSessionState.dept_code;
            REQ_PARA_OBJ.doc_type = MasterEntity.doc_type;
            REQ_PARA_OBJ.active = true;
            REQ_PARA_OBJ.from_date = DateTime.Now.AddMonths(-1);
            REQ_PARA_OBJ.to_date = DateTime.Now;
            REQ_PARA_OBJ.doc_type = MasterEntity.doc_type;
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
        }
        private void LoadInitialData(string doc_cat_info, string ReferenceDoc)
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + this.doc_cat_vm + "!@" + AppSessionState.EmpId;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001_STD>(MC, Request, "MM_T001_GM_STD", "SCM", "LoadAll", 0, "");

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).ItemCode);
                TheFilter = (o, prefix) => (((STD_ITEM)o).ItemCode ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((STD_ITEM)o).ItemName ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                TheFilter = (o, prefix) => ((STD_ITEM)o).item_code.ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ITEM = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "ItemCode", true);
                AS_ITEM.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ITEM.AutoSuggestVM.IsFreeTextAllowed = false;

                POSTING_KEY_DR_CR objPK = new POSTING_KEY_DR_CR();
                objPK.debcr_ind = "D";
                objPK.debcr_name = "Debit";
                objPK.posting_key = "32";
                MC.POSTING_KEY_DR_CR_LIST.Add(objPK);
                POSTING_KEY_DR_CR objPK2 = new POSTING_KEY_DR_CR();
                objPK2.debcr_ind = "C";
                objPK2.debcr_name = "Credit";
                objPK2.posting_key = "31";
                MC.POSTING_KEY_DR_CR_LIST.Add(objPK2);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((POSTING_KEY_DR_CR)x).debcr_ind);
                TheFilter = (o, prefix) => (((POSTING_KEY_DR_CR)o).debcr_ind ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((POSTING_KEY_DR_CR)o).debcr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_POSTING_KEY = new AutoSuggestTextViewModel<dynamic>(MC.POSTING_KEY_DR_CR_LIST, TheFilter, SuggestedValue, "debcr_ind", true);
                AS_POSTING_KEY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_POSTING_KEY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_DOC_TYPE)x).doc_cat);
                TheFilter = (o, prefix) => ((STD_DOC_TYPE)o).doc_type.ToLower().Contains(prefix.ToLower()) || (((STD_DOC_TYPE)o).doc_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_DOC_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.DOC_TYPE_LIST, TheFilter, SuggestedValue, "doc_type", true);
                AS_DOC_TYPE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_DOC_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_DOC_CAT)x).doc_cat);
                TheFilter = (o, prefix) => ((STD_DOC_CAT)o).doc_cat.ToLower().Contains(prefix.ToLower()) || (((STD_DOC_CAT)o).cat_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_REF_DOC_CAT = new AutoSuggestTextViewModel<dynamic>(MC.REF_DOC_CAT_LIST, TheFilter, SuggestedValue, "doc_cat", true);
                AS_REF_DOC_CAT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_REF_DOC_CAT.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).doc_no);
                TheFilter = (o, prefix) => ((STD_LIST_BE)o).doc_no.ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_REF_DOC_LIST = new AutoSuggestTextViewModel<dynamic>(MC.REF_DOC_LIST, TheFilter, SuggestedValue, "doc_cat", true);
                AS_REF_DOC_LIST.AutoSuggestVM.IsEmptyValueAllowed = false; AS_REF_DOC_LIST.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => ((ADM_M003)o).location_Id.ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPlant = new AutoSuggestTextViewModel<dynamic>((List<ADM_M003>)AppSessionState.ADM_M003_List, TheFilter, SuggestedValue, "location_Id", true);
                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => ((ADM_M003)o).location_Id.ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSendingPlant = new AutoSuggestTextViewModel<dynamic>((List<ADM_M003>)AppSessionState.ADM_M003_List, TheFilter, SuggestedValue, "location_Id", true);
                ASSendingPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
                TheFilter = (o, prefix) => ((MM_M0001)o).store_code.ToLower().Contains(prefix.ToLower()) || (((MM_M0001)o).store_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_STORAGE_LOCATION = new AutoSuggestTextViewModel<dynamic>(MC.STORE_LIST, TheFilter, SuggestedValue, "store_code", "store_code", true);
                AS_STORAGE_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTransporter = new AutoSuggestTextViewModel<dynamic>(MC.TRANSPORTER_LIST, TheFilter, SuggestedValue, "PartyId", true);
                ASTransporter.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M026)x).tr_mode);
                TheFilter = (o, prefix) => (((SYS_M026)o).tr_mode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M026)o).tr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTRMode = new AutoSuggestTextViewModel<dynamic>(MC.TRANSPORT_MODE_LIST, TheFilter, SuggestedValue, "tr_mode", true);
                ASTRMode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M025)x).t_status);
                TheFilter = (o, prefix) => (((SYS_M025)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M025)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_STATUS = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                AS_STATUS.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUOM.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASWTUOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                ASWTUOM.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUOMVOL = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                ASUOMVOL.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M004)x).mov_tp);
                TheFilter = (o, prefix) => (((MM_M004)o).mov_tp ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((MM_M004)o).mov_tp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_MOV_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.MOV_TYPE_LIST, TheFilter, SuggestedValue, "mov_tp", true);
                AS_MOV_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPersonnel = new AutoSuggestTextViewModel<dynamic>(MC.STD_PERSONNEL_LIST, TheFilter, SuggestedValue, "EmpId", true);
                ASPersonnel.AutoSuggestVM.IsEmptyValueAllowed = true; ASPersonnel.AutoSuggestVM.IsFreeTextAllowed = false;
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void ExecuteReferenceDocument(object InputValue)   // this method is little complicated and lengthy need to optimize : pending optimization
        {
            try
            {
                if (REQ_PARA_OBJ.doc_no != null || REQ_PARA_OBJ.doc_no != "")
                {
                    EntityChangeEnable = false;
                    string Request = "ExecuteReferenceDocument" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID + "!@" + (REQ_PARA_OBJ.doc_no ?? MasterEntity.ref_doc) + "!@" + REQ_PARA_OBJ.doc_cat;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001_STD>(MCTemp, Request, "MM_T001_GM_STD", "SCM", "ExecuteReferenceDocument", 0, "");

                    if (MCTemp.MASTER_BE_LIST.Count > 0)
                    {
                        MasterEntity = MCTemp.MASTER_BE_LIST[0];
                        ItemsEntity = MCTemp.ITEM_BE_LIST;
                        BatchEntity = MCTemp.BATCH_BE_LIST;
                        MasterEntity.ts_code = ts_code_vm;
                    }
                    EntityChangeEnable = true;
                }
                else
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Reference Document Number!", this.Title); sms.ShowMessage();
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertDocumentType(object InputValue)
        {
            try
            {
                string Request = "";
                STD_DOC_TYPE POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.DOC_TYPE_LIST.Where(x => x.doc_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.doc_desc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<STD_DOC_TYPE>().ToList().Count > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_DOC_TYPE>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.doc_type = POPUPEntityObject.doc_type;
                    MasterEntity.doc_cat = POPUPEntityObject.doc_cat;
                    MasterEntity.doc_code = POPUPEntityObject.doc_type;
                    doc_cat_vm = POPUPEntityObject.doc_cat;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertReferenceDocumentType(object InputValue)
        {
            try
            {
                string Request = "";
                STD_DOC_CAT POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.REF_DOC_CAT_LIST.Where(x => x.doc_cat.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.doc_cat.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<STD_DOC_CAT>().ToList().Count > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_DOC_CAT>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.source_doc_cat = POPUPEntityObject.doc_cat;
                    //MasterEntity.source_doc_type = POPUPEntityObject.doc_type;
                    REQ_PARA_OBJ.doc_cat = POPUPEntityObject.doc_cat;
                    //REQ_PARA_OBJ.doc_type = POPUPEntityObject.doc_type;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertMovementType(object InputValue)
        {
            try
            {
                string Request = "";
                MM_M004 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.MOV_TYPE_LIST.Where(x => x.mov_tp.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.mov_tp_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<MM_M004>().ToList().Count > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M004>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.mov_tp = POPUPEntityObject.mov_tp;
                    MasterEntity.mov_name = POPUPEntityObject.mov_tp_name;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertItem(object InputValue)
        {
            try
            {
                string Request = "";
                STD_ITEM POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.STD_ITEM_LIST.Where(x => x.item_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.item_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList().Count > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null && MM_T001_A_OBJ != null)
                {
                    MM_T001_A_OBJ.ItemCode = POPUPEntityObject.item_code;
                    MM_T001_A_OBJ.description = POPUPEntityObject.item_name;
                    MM_T001_A_OBJ.unit_code = POPUPEntityObject.unit_code;
                    MM_T001_A_OBJ.SubCatCode = POPUPEntityObject.item_subcat;
                    MM_T001_A_OBJ.StockUnt = POPUPEntityObject.ind_sku;

                    if (!MC.BATCH_LIST.Any(x => x.item_code == POPUPEntityObject.item_code))
                    {
                        Request = "Load_Batch_Data" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + this.doc_cat_vm + "!@" + MM_T001_A_OBJ.ItemCode + "!@" + MM_T001_A_OBJ.unit_code + "!@" + MM_T001_A_OBJ.store_code;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001_STD>(MC, Request, "MM_T001_GM_STD", "SCM", "LoadAll", 0, "");

                        foreach (var item in MCTemp.BATCH_LIST)
                        {
                            if (!MC.BATCH_LIST.Any(x => x.batch_no == item.batch_no))
                            {
                                MC.BATCH_LIST.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertBatch(object InputValue)
        {
            try
            {
                string Request = "";
                STD_ITEM POPUPEntityObject = null;

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
                            POPUPEntityObject = MC.BATCH_LIST.Where(x => x.batch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.item_code.Equals(MM_T001_A_OBJ.ItemCode) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_ITEM>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (MM_T001_A_OBJ != null && !string.IsNullOrWhiteSpace(POPUPEntityObject.batch_no) && !BatchEntity.Any(x => x.batch_no == POPUPEntityObject.batch_no))
                    {
                        MM_T001_A_OBJ.batch_no = POPUPEntityObject.batch_no;
                        BatchEntity.Add(new MM_T001_B()
                        {
                            ItemCode = POPUPEntityObject.ItemCode,
                            batch_no = POPUPEntityObject.batch_no,
                            store_code = POPUPEntityObject.store_code,
                            unit_code = POPUPEntityObject.unit_code,
                            sr_line_no = MM_T001_A_OBJ.line_id,
                            item_line_id = MM_T001_A_OBJ.id,
                            qty = (MM_T001_A_OBJ.qty) >= POPUPEntityObject.stock_total ? Convert.ToDecimal(POPUPEntityObject.stock_total) : MM_T001_A_OBJ.qty,
                            rec_qty = (MM_T001_A_OBJ.qty) >= POPUPEntityObject.stock_total ? Convert.ToDecimal(POPUPEntityObject.stock_total) : MM_T001_A_OBJ.qty,
                            comp_code = MM_T001_A_OBJ.comp_code,
                            location_Id = MM_T001_A_OBJ.location_Id,
                            add_by = AppSessionState.UserID,
                            sku = POPUPEntityObject.sku,
                            t_status = MM_T001_A_OBJ.t_status,
                            active = true

                        });
                    }
                    //else if (MM_T001_B_OBJ != null && string.IsNullOrWhiteSpace(POPUPEntityObject.batch_no)) // NOTE: This is commented because only addition will done , no update required, user can only change qty.
                    //{
                    //    MM_T001_A_OBJ.batch_no = POPUPEntityObject.batch_no;
                    //    MM_T001_B_OBJ.ItemCode = POPUPEntityObject.ItemCode;
                    //    MM_T001_B_OBJ.batch_no = POPUPEntityObject.batch_no;
                    //    MM_T001_B_OBJ.store_code = POPUPEntityObject.store_code;
                    //    MM_T001_B_OBJ.unit_code = POPUPEntityObject.unit_code;
                    //    MM_T001_B_OBJ.sr_line_no = MM_T001_A_OBJ.line_id;
                    //    MM_T001_B_OBJ.item_line_id = MM_T001_A_OBJ.id;
                    //    MM_T001_B_OBJ.qty = (MM_T001_A_OBJ.qty) >= POPUPEntityObject.stock_total ? Convert.ToDecimal(POPUPEntityObject.stock_total) : MM_T001_A_OBJ.qty;
                    //    MM_T001_B_OBJ.rec_qty = (MM_T001_A_OBJ.qty) >= POPUPEntityObject.stock_total ? Convert.ToDecimal(POPUPEntityObject.stock_total) : MM_T001_A_OBJ.qty;
                    //    MM_T001_B_OBJ.comp_code = MM_T001_A_OBJ.comp_code;
                    //    MM_T001_B_OBJ.location_Id = MM_T001_A_OBJ.location_Id;
                    //    MM_T001_B_OBJ.add_by = AppSessionState.UserID;
                    //    MM_T001_B_OBJ.sku = MM_T001_A_OBJ.sku;
                    //    MM_T001_B_OBJ.t_status = MM_T001_A_OBJ.t_status;
                    //    MM_T001_B_OBJ.active = true;
                    //    MM_T001_B_OBJ.client = AppSessionState.client;
                    //}
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void LoadDocumentByNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                EntityChangeEnable = false;
                string Request = "";
                STD_LIST_BE ParameterEntityObject = null;
                if (ParameterObject.GetType() == typeof(string))
                {
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterObject.ToString();
                }
                else
                {
                    if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];

                        Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.doc_no;
                    }
                }
                NewRecord = false;
                MoveFlag = false;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001_STD>(MCTemp, Request, "MM_T001_GM_STD", "SCM", "LoadDocumentByDocumentNumber", 0, "");
                SelectedTabIndexMain = 0;
                MasterEntity = MCTemp.MASTER_BE_LIST[0];
                ItemsEntity = MCTemp.ITEM_BE_LIST;
                BatchEntity = MCTemp.BATCH_BE_LIST;
                MasterEntity.ts_code = ts_code_vm;
                EntityChangeEnable = true;
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void Load_BackFlip_Data()
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "Load_BackFlip_Data" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.location_Id) + "!@" + REQ_PARA_OBJ.doc_cat + "!@" + REQ_PARA_OBJ.doc_type + "!@" + REQ_PARA_OBJ.emp_id + "!@" + REQ_PARA_OBJ.party_code + "!@" + REQ_PARA_OBJ.t_status + "!@" + REQ_PARA_OBJ.active + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy");
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MCTemp, Request, "MM_T001_GM_STD", "SCM", "Load_BackFlip_Data", 0, "");

                MC.BACK_FLIP_LIST = MCTemp.BACK_FLIP_LIST;
                FlipGridData = MCTemp.BACK_FLIP_LIST;
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_BackFlip);
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            try
            {
                if ((sender.ToString() == "qty" || sender.ToString() == "unit_price") && dgSelectedIndexItem != -1 && MM_T001_A_OBJ != null)
                {
                    MM_T001_A_OBJ.amt_loc = MM_T001_A_OBJ.qty * MM_T001_A_OBJ.unit_price;
                }
                if (MM_T001_A_OBJ.batch_split == true)
                {
                    batchdatagrid = true; // if batch split checkbox is checked then only batchsplit is allowed
                }
                else
                {
                    batchdatagrid = false;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            try
            {
                if ((sender.ToString() == "doc_type" || sender.ToString() == "unit_price") && dgSelectedIndexItem != -1 && MM_T001_A_OBJ != null)
                {
                    MM_T001_A_OBJ.amt_loc = MM_T001_A_OBJ.qty * MM_T001_A_OBJ.unit_price;
                }

                if (sender.ToString() == "mov_tp" && MasterEntity.mov_tp == "107")
                {
                    ind_Batch_Tab_Enabled = false;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ItemsEntity[i].id == 0)
                {
                    if (BatchEntity.Count > 0) //  before Deleting Item Its Batches Will be removed 
                    {
                        for (int j = BatchEntity.Count - 1; j >= 0; j--)
                        {
                            if (ItemsEntity[i].ItemCode == BatchEntity[j].ItemCode && ItemsEntity[i].sku == BatchEntity[j].sku)
                            {
                                BatchEntity.Remove(BatchEntity[j]);
                            }
                        }
                    }
                    ItemsEntity.RemoveAt(i);
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void BatchSplit()
        {
            if (MM_T001_A_OBJ != null && ItemsEntity.Count > 0)
            {
                if (MM_T001_A_OBJ.batch_split == true)
                {
                    batchdatagrid = true; // if batch split checkbox is checked then only batchsplit is allowed
                }
                else
                {
                    batchdatagrid = false;
                }
            }
        }
        
        private void SelectionChangedItem(object InputValue)
        {
            try
            {
                if (InputValue != null)
                {
                    MM_T001_A_OBJ = (MM_T001_A)InputValue;
                    FilterBatchDataGrid();
                    if (MM_T001_A_OBJ.batch_split == true)
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
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void SelectionChangedBatch(object InputValue)
        {
            try
            {
                if (InputValue != null)
                {
                    MM_T001_B_OBJ = (MM_T001_B)InputValue;
                }
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void FilterBatchDataGrid()
        {
            try
            {
                if (BatchEntity != null && BatchEntity.Count > 0 && MM_T001_A_OBJ != null && ItemsEntity != null && ItemsEntity.Count > 0)
                {
                    DataGridView = CollectionViewSource.GetDefaultView(BatchEntity);
                    if ((MM_T001_A_OBJ.sku ?? null) == null)
                    {
                        DataGridView.Filter = adv => ((MM_T001_B)adv).ItemCode.Equals(MM_T001_A_OBJ.ItemCode) && ((MM_T001_B)adv).sr_line_no.Equals(MM_T001_A_OBJ.line_id); ;
                    }
                    else
                    {
                        DataGridView.Filter = adv => ((MM_T001_B)adv).ItemCode.Equals(MM_T001_A_OBJ.ItemCode) && ((MM_T001_B)adv).sku.Equals(MM_T001_A_OBJ.sku) && ((MM_T001_B)adv).sr_line_no.Equals(MM_T001_A_OBJ.line_id);
                    }
                    DataGridView.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add && ItemsEntity.Count > 0) // can only enable to add if items exists in Items Entity.
                {
                    foreach (MM_T001_A item in e.NewItems)
                    {
                        item.line_id = ItemsEntity.Count;
                        item.comp_code = MasterEntity.comp_code;
                        item.location_Id = MasterEntity.location_Id;
                        item.doc_date = MasterEntity.doc_date;
                        item.doc_type = MasterEntity.doc_type;
                        item.doc_cat = MasterEntity.doc_cat;
                        item.mov_tp = MasterEntity.mov_tp;
                        item.curr_code = MasterEntity.curr_code;
                        item.source_doc_type = MasterEntity.source_doc_type;
                        item.source_doc_no = MasterEntity.source_doc_no;
                        item.ref_doc_no = MasterEntity.ref_doc;
                        item.ref_doc_type = MasterEntity.source_doc_type;
                        item.client = AppSessionState.client;
                        item.post_date = MasterEntity.post_date;
                        item.active = true;
                        item.add_by = AppSessionState.UserID;
                        item.editby = AppSessionState.UserID;
                        item.t_status = MasterEntity.t_status;
                        item.t_display = (from o in MC.STATUS_LIST where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
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
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void CollectionChangedNotifyForBatch(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add && ItemsEntity.Count > 0) // can only enable to add if items exists in Items Entity.
                {
                    foreach (MM_T001_B item in e.NewItems)
                    {
                        if (dgSelectedIndexItem <= ItemsEntity.Count)
                        {
                            item.grn_id = MM_T001_A_OBJ.id;
                            item.item_line_id = MM_T001_A_OBJ.id;
                            item.doc_no = MasterEntity.doc_no;
                            item.ItemCode = MM_T001_A_OBJ.ItemCode;
                            item.sr_line_no = MM_T001_A_OBJ.line_id;
                            //item.qty = MM_T001_A_OBJ.qty;
                            //item.rec_qty = MM_T001_A_OBJ.qty;
                            item.unit_code = MM_T001_A_OBJ.unit_code;
                            item.description = MM_T001_A_OBJ.description;
                            item.t_status = MM_T001_A_OBJ.t_status;
                            item.location_Id = MM_T001_A_OBJ.location_Id;
                            item.comp_code = MM_T001_A_OBJ.comp_code;
                            item.wa_code = MM_T001_A_OBJ.wa_code;
                            item.store_code = MM_T001_A_OBJ.store_code;
                            item.active = MM_T001_A_OBJ.active;
                            item.add_by = AppSessionState.UserID;
                            item.editby = AppSessionState.UserID;
                            item.sku = MM_T001_A_OBJ.sku;
                            item.pono = MM_T001_A_OBJ.po_no;
                            item.client = MM_T001_A_OBJ.client;
                            item.t_display = (from o in MC.STATUS_LIST where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();

                            if (BatchEntity.Count > 0 && MM_T001_A_OBJ != null)
                            {
                                required_qty = MM_T001_A_OBJ.qty;
                                packed_qty = Convert.ToDecimal(BatchEntity.Where(x => x.sr_line_no == MM_T001_A_OBJ.line_id).Sum(x => x.qty ?? 0));
                                bal_qty = required_qty - packed_qty;
                            }
                        }
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
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void DeleteBatchDataGridRow_Item(object InputValue)
        {
            int i = (int)InputValue;
            if (BatchEntity.Count > i && BatchEntity[i].id == 0)
            {
                BatchEntity.RemoveAt(i);
            }
        }
        private void ItemActiveInActiveMethod(object InputValue) // when active status is change of item
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count >= i && ItemsEntity[i].id != 0)
                {
                    sms.ButtonSetup = DialogButton.OkCancel; sms.Caption = "Message";
                    sms.Text = String.Format("If You Inactivate The Item Its All Batches and Allocation Will be Inactivate\n Click Ok to Continue ", this.Title);
                    sms.ShowMessage();
                    if (sms.ShowMessage() == DialogResult.Ok)
                    {
                        if (ItemsEntity[i].active == false)
                        {
                            // All Batches of Inactivated item are Inactivated
                            foreach (var item in BatchEntity)
                            {
                                if (item.ItemCode == ItemsEntity[i].ItemCode && item.sku == ItemsEntity[i].sku && item.active == true)
                                {
                                    item.active = false;
                                }
                            }
                        }
                    }
                    else if (sms.ShowMessage() == DialogResult.Cancel)
                    {
                        ItemsEntity[i].active = true;
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private bool Validations()
        {
            try
            {
                int ind_item_count = 0; // This will count items in grid and we can use this counter where counting required i.e. Mov type 126 : Material Conversion then only tow item for source and destination required with opposite debit credit indicator.
                int ind_debit_count = 0;
                int ind_credit_count = 0;
                if (string.IsNullOrWhiteSpace(MasterEntity.mov_tp))
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format("Please select Movement Type"); sms.ShowMessage();
                    return false;
                }
                if (ItemsEntity.Count < 1 && (MasterEntity.mov_tp == "111" || MasterEntity.mov_tp == "110" || MasterEntity.mov_tp == "126"))
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format("Item Details Must Have At Least two Item "); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.mov_tp == "101")
                {
                    if (MasterEntity.source_doc_no == null || MasterEntity.source_doc_no == "")
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format("Reference Document Number is Not Selected For Movement type Goods Receipt Of Purchase Order"); sms.ShowMessage();
                        return false;
                    }
                }
                if (MasterEntity.mov_tp == "117")
                {
                    if (MasterEntity.source_doc_no == null || MasterEntity.source_doc_no == "")
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format("Reference Document Number is Not Selected For Movement type Goods Receipt Of Purchase Order"); sms.ShowMessage();
                        return false;
                    }
                }
                if (MasterEntity.mov_tp == "107" && ItemsEntity.Count != 2)
                {
                    if (MasterEntity.source_doc_no == null || MasterEntity.source_doc_no == "")
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format("Required Source and Destination material. one to one record required to proceed"); sms.ShowMessage();
                        return false;
                    }
                }
                #region . Validation for Item Duplication, null Unit Code and Null or 0 Quantity For All Active Items .
                // Validation for Quantity Item Duplication and Unit Code For Item Details
                foreach (var o in ItemsEntity)
                {
                    int flag = 0;
                    ind_item_count++;
                    if (o.active == true)
                    {
                        foreach (var p in ItemsEntity)// Item Duplication Validation
                        {
                            if (o.line_id == p.line_id && p.active == true)
                            {
                                flag++;
                            }
                        }
                        if (flag > 1)
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemsEntity.IndexOf(o)); sms.ShowMessage();
                            return false;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(o.ItemCode))
                    {
                        if (!o.qty.HasValue || o.qty == 0)
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format("Quantity cannot be null or 0 for item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemsEntity.IndexOf(o)); sms.ShowMessage();
                            return false;
                        }
                        if (string.IsNullOrWhiteSpace(o.debcr_ind))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format("Please Enter Valid Debit Credit Indicator for the item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemsEntity.IndexOf(o)); sms.ShowMessage();
                            return false;
                        }
                        if (string.IsNullOrWhiteSpace(o.unit_code))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemsEntity.IndexOf(o)); sms.ShowMessage();
                            return false;
                        }
                        if (string.IsNullOrWhiteSpace(o.location_Id))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format("Please Enter Valid Location for the item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemsEntity.IndexOf(o)); sms.ShowMessage();
                            return false;
                        }
                        if (string.IsNullOrWhiteSpace(o.store_code))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format("Please Enter Valid Storage Location for the item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, ItemsEntity.IndexOf(o)); sms.ShowMessage();
                            return false;
                        }

                        // Validation For All Parameter Values Selected or Not
                        if (o.StockUnt == true && o.id == 0)
                        {
                            var paralist = (from p in MC.PARAMETERS_VALUES_LIST where p.SubCatCode == o.SubCatCode select p).ToList();

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
                                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Parameter Validation"; sms.Text = String.Format("All Parameters of item {0} of index {1} are not selected..!!! \n Check Parameter at index {2} is selected or not. \n ", o.ItemCode, ItemsEntity.IndexOf(o), SkuList.ToList().IndexOf(item)); sms.ShowMessage();
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Parameter Validation"; sms.Text = String.Format("All Parameters of item {0} of index {1} are not selected\n If you can see All Parameter Value Selected Please Select the Same Values Again ", o.ItemCode, ItemsEntity.IndexOf(o)); sms.ShowMessage();
                                    return false;
                                }
                            }

                        }
                    }
                    else
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format("No ItemCode is Present at Index {0} \n Delete This Blank Row", ItemsEntity.IndexOf(o)); sms.ShowMessage();
                        return false;
                    }
                    if (o.debcr_ind == "D")
                    {
                        ind_debit_count++;
                    }
                    if (o.debcr_ind == "C")
                    {
                        ind_credit_count++;
                    }
                }
                #endregion
                if (MasterEntity.mov_tp == "107" && ind_item_count != 2 && ind_debit_count != ind_credit_count)
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format("Cannot process Material conversion without Source and Destination Material, Debit and Credit Indicator"); sms.ShowMessage();
                    return false;
                }
                #region . Item Quantity Batch Quantity Validation.
                //Validation For Item Quantity Equal To Sum of Quantities of All Active Batches Of the Item 
                //bool breakfor = false;
                for (int i = 0; i < ItemsEntity.Count; i++)
                {
                    decimal temp = 0;
                    int flag = 0;
                    if (ItemsEntity[i].active == true && ItemsEntity[i].batch_split == true)
                    {
                        for (int j = 0; j < BatchEntity.Count; j++)
                        {
                            if (ItemsEntity[i].ItemCode == BatchEntity[j].ItemCode && ItemsEntity[i].sku == BatchEntity[j].sku && BatchEntity[j].active == true && ItemsEntity[i].line_id == BatchEntity[j].sr_line_no && ItemsEntity[i].id == BatchEntity[j].item_line_id)
                            {
                                temp = temp + Convert.ToDecimal(BatchEntity[j].qty);
                                flag = 1;
                            }
                        }
                        if (ItemsEntity[i].qty != temp && flag == 1)
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format("Item Quantity is Not Equal to Sum of All Item Batches Quantities\n for Item {0} At Index {1}", ItemsEntity[i].ItemCode, i); sms.ShowMessage();
                            return false;
                        }
                    }
                }
                #endregion
                return true;
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
                return false;
            }
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByNumber(doc_no_vm, "DocumentNo");
                }
                else
                {
                    DefaultValues(doc_cat_vm);
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void Invoke_Reference_Document(object InputValue)
        {
            try
            {
                string Request = "";
                ReflectionFunctionService objRef = new ReflectionFunctionService();
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = MasterEntity.client + "!@" + MasterEntity.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
            }
            catch (Exception ex) { }
        }
        void Model_MasterUpdated(object sender, EventArgs e)
        {
            try
            {
                if (sender.ToString() == "para2" || sender.ToString() == "para3" || sender.ToString() == "para4")
                {

                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        void ModelUpdated_Batch(object sender, EventArgs e)
        {
            try
            {
                //This will get called when the property of an object inside the collection changes
                if (sender.ToString() == "para2" || sender.ToString() == "para3" || sender.ToString() == "para4")
                {

                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void TabItemSelectionChanged(object param)
        {
            int TabIndexValue = Convert.ToInt32(param);
            bool ServerTripRequired = true;
            try
            {
                if (TabIndexValue == 1)
                {
                    if (MM_T001_A_OBJ != null)
                    {
                        if (MCTemp.STD_ITEM_HU_LIST != null)
                        {
                            if (MCTemp.STD_ITEM_HU_LIST.Count > 0)
                            {
                                if (MCTemp.STD_ITEM_HU_LIST.Where(x => x.ItemCode == MM_T001_A_OBJ.ItemCode && (x.sku ?? "") == (MM_T001_A_OBJ.sku ?? "")).ToList().Count > 0)
                                {
                                    ServerTripRequired = false;

                                    var HUC = MCTemp.STD_ITEM_HU_LIST
                                      .GroupBy(t => new { t.pack_no, t.ItemCode, t.sku, t.unit_code, t.barcode })
                                      .Select(t => new { pack_no = t.Key.pack_no, barcode = t.Key.barcode, t.Key.unit_code, t.Key.ItemCode, t.Key.sku, stock_total = t.Sum(n => n.stock_total), batch_qty = t.Sum(u => u.batch_qty) }) //
                                      .Where(x => x.ItemCode == MM_T001_A_OBJ.ItemCode && (x.sku ?? "") == (MM_T001_A_OBJ.sku ?? "")).ToList(); //  && (x.sku ?? "") == (MM_T001_A_OBJ.sku ?? "")
                                                                                                                                                //.Select(t => new { pack_no = t.Key.pack_no, t.Key.pack_qty, unit_code = t.Key.unit_code, t.Key.ItemCode, t.Key.sku, t.Key.location_id, t.Key.comp_code, t.Key.store_code, stock_total = t.Sum(n => n.stock_total), batch_qty = t.Sum(u => u.batch_qty) }) //
                                    foreach (var item in HUC)
                                    {
                                        MC.STD_ITEM_HU_LIST.Add(new STD_ITEM { pack_no = item.pack_no, barcode = item.barcode, pack_qty = item.batch_qty, unit_code = item.unit_code, ItemCode = item.ItemCode, sku = item.sku, stock_total = item.stock_total, batch_qty = item.batch_qty, selected = false });
                                    }
                                    HUCollection = CollectionViewSource.GetDefaultView(MC.STD_ITEM_HU_LIST);
                                    HUCollection.Filter = new Predicate<object>(FilterString_RefDoc);
                                    HUCollection.Refresh();
                                }

                            }
                        }
                        if (ServerTripRequired == true && !string.IsNullOrWhiteSpace(MM_T001_A_OBJ.store_code) && !string.IsNullOrWhiteSpace(MM_T001_A_OBJ.ItemCode) && MM_T001_A_OBJ.debcr_ind == "D")
                        {
                            string Request = "LoadHandlingUnits" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + this.doc_cat_vm + "!@" + MasterEntity.doc_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + this.ts_code_vm + "!@" + MM_T001_A_OBJ.sku + "!@" + AppSessionState.sg_code + "!@" + AppSessionState.sg_code + "!@" + MM_T001_A_OBJ.ItemCode + "!@!@!@!@!@" + MM_T001_A_OBJ.store_code + "!@" + MM_T001_A_OBJ.unit_code;
                            //string Request = "LoadHandlingUnits" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MM_T001_A_OBJ.ItemCode + "!@" + MM_T001_A_OBJ.sku + "!@" + MM_T001_A_OBJ.store_code + "!@" + MM_T001_A_OBJ.unit_code;
                            MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp, Request, "MM_T001_GM_STD", "SCM", "LoadAll", 0, Request);
                            if (MC.STD_ITEM_HU_LIST.Count > 0)
                            {
                                MC.STD_ITEM_HU_LIST.Clear();
                            }
                            if (MCTemp.STD_ITEM_HU_LIST.Count > 0)
                            {
                                var HUC = MCTemp.STD_ITEM_HU_LIST
                                  .GroupBy(t => new { t.pack_no, t.ItemCode, t.sku, t.unit_code, t.barcode })
                                  .Select(t => new { pack_no = t.Key.pack_no, barcode = t.Key.barcode, t.Key.unit_code, t.Key.ItemCode, t.Key.sku, stock_total = t.Sum(n => n.stock_total), batch_qty = t.Sum(u => u.batch_qty) }) //
                                  .Where(x => x.ItemCode == MM_T001_A_OBJ.ItemCode && (x.sku ?? "") == (MM_T001_A_OBJ.sku ?? "")).ToList(); //  && (x.sku ?? "") == (MM_T001_A_OBJ.sku ?? "")
                                //.Select(t => new { pack_no = t.Key.pack_no, t.Key.pack_qty, unit_code = t.Key.unit_code, t.Key.ItemCode, t.Key.sku, t.Key.location_id, t.Key.comp_code, t.Key.store_code, stock_total = t.Sum(n => n.stock_total), batch_qty = t.Sum(u => u.batch_qty) }) //
                                foreach (var item in HUC)
                                {
                                    MC.STD_ITEM_HU_LIST.Add(new STD_ITEM { pack_no = item.pack_no, barcode = item.barcode, pack_qty = item.batch_qty, unit_code = item.unit_code, ItemCode = item.ItemCode, sku = item.sku, stock_total = item.stock_total, batch_qty = item.batch_qty, selected = false });
                                }
                                HUCollection = CollectionViewSource.GetDefaultView(MC.STD_ITEM_HU_LIST);
                                HUCollection.Filter = new Predicate<object>(FilterString_RefDoc);
                                HUCollection.Refresh();
                            }
                        }
                        else if (ServerTripRequired == true && MM_T001_A_OBJ.debcr_ind == "D")
                        {
                            if (MC.STD_ITEM_HU_LIST != null)
                            {
                                if (MC.STD_ITEM_HU_LIST.Count > 0)
                                {
                                    MC.STD_ITEM_HU_LIST.Clear();
                                    ServerTripRequired = true;
                                    HUCollection = CollectionViewSource.GetDefaultView(MC.STD_ITEM_HU_LIST);
                                    HUCollection.Filter = new Predicate<object>(FilterString_RefDoc);
                                    HUCollection.Refresh();
                                }
                            }

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
        private void InsertBatchDataForDestinationMaterial() // This will copy Batch infor from Source to Destination item. Only Item and Row details will be change as per Destination Item.
        {
            try
            {
                if (BatchEntity != null && ItemsEntity.Count == 2)
                {
                    MM_T001_A MM_T001_A_OBJ_S = new MM_T001_A();
                    MM_T001_A MM_T001_A_OBJ_D = new MM_T001_A();
                    MM_T001_B MM_T001_B_OBJ_S = new MM_T001_B();
                    MM_T001_B MM_T001_B_OBJ_D = new MM_T001_B();

                   if(BatchEntity.Count > 0)
                    {
                        var BatchData = BatchEntity;
                        MM_T001_A_OBJ_S = ItemsEntity.Where(x => x.debcr_ind == "D").ToList()[0]; //x.line_id == item.sr_line_no && 
                        MM_T001_A_OBJ_D = ItemsEntity.Where(x => x.debcr_ind == "C").ToList()[0]; //x.line_id != MM_T001_A_OBJ_S.line_id && 

                        foreach (var item in BatchData.ToList())
                        {
                            if (MM_T001_A_OBJ_S.line_id== item.sr_line_no)
                            {
                                MM_T001_B_OBJ_S = item; // BatchData[0];
                            }
                            MM_T001_A_OBJ = MM_T001_A_OBJ_D;// It will call CollectionChangeEvent and add correct Values in that function.
                            MM_T001_B_OBJ_D.batch_no = MM_T001_B_OBJ_S.batch_no;
                            MM_T001_B_OBJ_D.qty = (MM_T001_B_OBJ_D.qty ?? 0) + MM_T001_B_OBJ_S.qty;
                            MM_T001_B_OBJ_D.rec_qty = (MM_T001_B_OBJ_D.rec_qty ?? 0) + MM_T001_B_OBJ_S.rec_qty;
                            MM_T001_B_OBJ_D.unit_code = MM_T001_B_OBJ_S.unit_code;
                            MM_T001_B_OBJ_D.pack_no = MM_T001_B_OBJ_S.pack_no;
                        }
                        BatchEntity.Add(MM_T001_B_OBJ_D);
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void ExecuteBatchInsert(object items)
        {
            try
            {
                MM_T001_A MM_T001_A_OBJ_S = new MM_T001_A();
                MM_T001_A MM_T001_A_OBJ_D = new MM_T001_A();
                var MM_T001_A_OBJ_Cr = new MM_T001_A();
                if (MasterEntity.doc_type=="MC" && ItemsEntity != null)
                {
                    if(ItemsEntity.Count > 1)
                    {
                        MM_T001_A_OBJ_Cr = ItemsEntity.Where(x => x.debcr_ind == "C").ToList()[0];
                    }
                    
                }
                if (MC.STD_ITEM_HU_LIST != null && !string.IsNullOrWhiteSpace(MasterEntity.mov_tp) && (MasterEntity.mov_tp != "107" || (MasterEntity.mov_tp=="107" && MM_T001_A_OBJ_Cr.debcr_ind == "C")))
                {
                    var FilteredBatch = MCTemp.STD_ITEM_HU_LIST.Where(a => MC.STD_ITEM_HU_LIST.Any(b => b.pack_no == a.pack_no && b.selected == true && a.ItemCode == b.ItemCode && (a.sku ?? "") == (b.sku ?? "") && a.ItemCode == MM_T001_A_OBJ.ItemCode && (a.sku ?? "") == (MM_T001_A_OBJ.sku ?? "")));
                    if (FilteredBatch.Count() > 0)
                    {
                        foreach (var item in FilteredBatch)
                        {
                            //MM_T001_A_OBJ.weight_unit = item.weight_unit;
                            //MM_T001_A_OBJ.volume_unit = item.volume_unit;
                            //MasterEntity.weight_unit = item.weight_unit;
                            //MasterEntity.volume_unit = item.volume_unit;

                            if (BatchEntity.Where(x => x.sr_line_no == MM_T001_A_OBJ.line_id && x.pack_no == item.pack_no && x.batch_no == item.batch_no && x.location_Id == item.location_id && x.comp_code == item.comp_code && x.store_code == item.store_code).ToList().Count > 0)
                            {
                                int Batchindex = BatchEntity.IndexOf(BatchEntity.Where(X => X.batch_no == item.batch_no && X.pack_no == item.pack_no).FirstOrDefault());
                                BatchEntity[Batchindex].grn_id = MM_T001_A_OBJ.id;
                                BatchEntity[Batchindex].item_line_id = MM_T001_A_OBJ.id;
                                BatchEntity[Batchindex].doc_no = MasterEntity.doc_no;
                                BatchEntity[Batchindex].ItemCode = MM_T001_A_OBJ.ItemCode;
                                BatchEntity[Batchindex].sr_line_no = MM_T001_A_OBJ.line_id;
                                BatchEntity[Batchindex].sku = MM_T001_A_OBJ.sku;
                                BatchEntity[Batchindex].pack_no = item.pack_no;
                                BatchEntity[Batchindex].batch_no = item.batch_no;
                                BatchEntity[Batchindex].qty = item.batch_qty; // MM_T001_A_OBJ.qty >= item.batch_qty ? item.batch_qty : MM_T001_A_OBJ.qty;
                                BatchEntity[Batchindex].rec_qty = item.req_qty;
                                BatchEntity[Batchindex].unit_code = item.unit_code;
                                BatchEntity[Batchindex].description = MM_T001_A_OBJ.description;
                                BatchEntity[Batchindex].t_status = MM_T001_A_OBJ.t_status;
                                BatchEntity[Batchindex].location_Id = MM_T001_A_OBJ.location_Id;
                                BatchEntity[Batchindex].wa_code = MM_T001_A_OBJ.wa_code;
                                BatchEntity[Batchindex].store_code = (item.store_code ?? MM_T001_A_OBJ.store_code);
                                BatchEntity[Batchindex].active = MM_T001_A_OBJ.active;
                                BatchEntity[Batchindex].add_by = AppSessionState.UserID;
                                BatchEntity[Batchindex].editby = AppSessionState.UserID;
                                BatchEntity[Batchindex].comp_code = MM_T001_A_OBJ.comp_code;
                                BatchEntity[Batchindex].pono = MM_T001_A_OBJ.po_no;
                                //BatchEntity[Batchindex].net_wt = item.net_wt;
                                //BatchEntity[Batchindex].gross_wt = ((item.gross_wt == 0 || item.gross_wt == null) ? item.net_wt : item.gross_wt);
                                BatchEntity[Batchindex].client = AppSessionState.client;

                            }
                            else //if (batchsplitSelectedIndex >= 0 && BatchDetails.Select == true && ItemBatchEntity.Count > batchsplitSelectedIndex) 
                            {
                                MM_T001_A_OBJ.batch_split = true;
                                batchdatagrid = true;
                                split = true;
                                if (BatchEntity.Where(x => x.barcode == item.barcode && x.batch_no == item.batch_no).ToList().Count == 0)
                                {
                                    BatchEntity.Add(new MM_T001_B()
                                    {
                                        doc_no = MM_T001_A_OBJ.doc_no,
                                        ItemCode = item.ItemCode,
                                        sku = MM_T001_A_OBJ.sku,
                                        barcode = item.barcode,
                                        pack_no = item.pack_no,
                                        batch_no = item.batch_no,
                                        qty = item.batch_qty, //MM_T001_A_OBJ.qty >= item.batch_qty ? item.batch_qty : MM_T001_A_OBJ.qty,
                                        unit_code = item.unit_code,
                                        description = MM_T001_A_OBJ.description,
                                        t_status = MM_T001_A_OBJ.t_status,
                                        location_Id = MM_T001_A_OBJ.location_Id,
                                        wa_code = MM_T001_A_OBJ.wa_code,
                                        store_code = (item.store_code ?? MM_T001_A_OBJ.store_code),
                                        active = MM_T001_A_OBJ.active,
                                        add_by = AppSessionState.UserID,
                                        comp_code = MM_T001_A_OBJ.comp_code,
                                        //net_wt = item.net_wt,
                                        //gross_wt = ((item.gross_wt == 0 || item.gross_wt == null) ? item.net_wt : item.gross_wt),  //item.gross_wt ?? item.net_wt,
                                        client = AppSessionState.client,
                                    });
                                }
                            }
                        }
                        if (MasterEntity.doc_type == "MC" && MasterEntity.mov_tp == "107" && ItemsEntity != null) // add Credit Batch entery if not exists
                        {
                            if (BatchEntity != null && ItemsEntity.Count == 2)
                            {
                                if (BatchEntity.Count > 0)
                                {
                                    var BatchData = BatchEntity;
                                    MM_T001_A_OBJ_S = ItemsEntity.Where(x => x.debcr_ind == "D").ToList()[0]; //x.line_id == item.sr_line_no && 
                                    MM_T001_A_OBJ_D = ItemsEntity.Where(x => x.debcr_ind == "C").ToList()[0]; //x.line_id != MM_T001_A_OBJ_S.line_id && 
                                    MM_T001_A_OBJ = MM_T001_A_OBJ_D;// reset Credit Item row for Item Addition and colection change event for default values. once added then reset first value.


                                    foreach (var item_B in BatchData.ToList())
                                    {
                                        if (BatchEntity.Where(x => x.sr_line_no == MM_T001_A_OBJ_D.line_id && x.item_line_id == MM_T001_A_OBJ_D.id && x.batch_no == item_B.batch_no && x.pack_no == item_B.pack_no && x.ItemCode == MM_T001_A_OBJ_D.ItemCode && (x.sku ?? "") == (MM_T001_A_OBJ_D.sku ?? "") && x.pack_no == item_B.pack_no).ToList().Count == 0)
                                        {
                                            MM_T001_B MM_T001_B_OBJ_S = new MM_T001_B();
                                            MM_T001_B MM_T001_B_OBJ_D = new MM_T001_B();
                                            MM_T001_B_OBJ.CopyPropertiesTo<MM_T001_B>(MM_T001_B_OBJ_D);
                                            item_B.CopyPropertiesTo<MM_T001_B>(MM_T001_B_OBJ_S);

                                            MM_T001_B_OBJ_D.ItemCode = MM_T001_A_OBJ_D.ItemCode;
                                            MM_T001_B_OBJ_D.sku = MM_T001_A_OBJ_D.sku;
                                            MM_T001_B_OBJ_D.sr_line_no = MM_T001_A_OBJ_D.line_id;
                                            MM_T001_B_OBJ_D.item_line_id = MM_T001_A_OBJ_D.id;
                                            MM_T001_B_OBJ_D.grn_id = MM_T001_A_OBJ_D.id;
                                            MM_T001_B_OBJ_D.location_Id = MM_T001_A_OBJ_D.location_Id;
                                            MM_T001_B_OBJ_D.store_code = item_B.store_code;
                                            MM_T001_B_OBJ_D.t_status = item_B.t_status;
                                            MM_T001_B_OBJ_D.unit_code = item_B.unit_code;
                                            MM_T001_B_OBJ_D.vendor_batch_no = item_B.vendor_batch_no;
                                            MM_T001_B_OBJ_D.wa_code = item_B.wa_code;
                                            MM_T001_B_OBJ_D.batch_no = item_B.batch_no;
                                            MM_T001_B_OBJ_D.qty = item_B.qty;
                                            MM_T001_B_OBJ_D.rec_qty = item_B.rec_qty;
                                            MM_T001_B_OBJ_D.unit_code = item_B.unit_code;
                                            MM_T001_B_OBJ_D.pack_no = item_B.pack_no;
                                            MM_T001_B_OBJ_D.user_source1 = item_B.batch_no;
                                            BatchEntity.Add(MM_T001_B_OBJ_D);
                                        }
                                    }
                                }
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
                    sms.Text = String.Format("Packing Data not available for Selected Item. Movment Type Not selected for Transaction or Credit Material Not exists for Material Conversion", this.Title);
                    sms.ShowMessage();
                }
                MM_T001_A_OBJ.barcode = "";
                MasterEntity.barcode = "";
                MM_T001_A_OBJ = MM_T001_A_OBJ_S;// reset Debit row as selected row.
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
                MM_T001_A MM_T001_A_OBJ_S = new MM_T001_A();
                MM_T001_A MM_T001_A_OBJ_D = new MM_T001_A();
                
                // NOTE: This function is same as Manual Selection of Handling unit in Function "ExecuteBatchInsert" only difference is Barcode in where clause instade of Pack_no. we can make same function for both event.
                string BarcodeValue = InputValue.ToString();
                if (BarcodeValue.Length > 9)
                {
                    var MM_T001_A_OBJ_Cr = new MM_T001_A();
                    if (MasterEntity.doc_type == "MC" && ItemsEntity != null)
                    {
                        if (ItemsEntity.Count > 1)
                        {
                            MM_T001_A_OBJ_Cr = ItemsEntity.Where(x => x.debcr_ind == "C").ToList()[0];
                        }

                    }

                    if (MC.STD_ITEM_HU_LIST != null && !string.IsNullOrWhiteSpace(MasterEntity.mov_tp) && (MasterEntity.mov_tp != "107" || (MasterEntity.mov_tp == "107" && MM_T001_A_OBJ_Cr.debcr_ind == "C")))
                    {
                        var FilteredBatch = MCTemp.STD_ITEM_HU_LIST.Where(a => MC.STD_ITEM_HU_LIST.Any(b => b.barcode == a.barcode && b.barcode == BarcodeValue && a.ItemCode == b.ItemCode && (a.sku ?? "") == (b.sku ?? "") && a.ItemCode == MM_T001_A_OBJ.ItemCode && (a.sku ?? "") == (MM_T001_A_OBJ.sku ?? "")));
                        if (FilteredBatch.Count() > 0)
                        {
                            foreach (var item in FilteredBatch)
                            {
                                item.selected = true;
                                //MM_T001_A_OBJ.weight_unit = item.weight_unit;
                                //MM_T001_A_OBJ.volume_unit = item.volume_unit;
                                //MasterEntity.weight_unit = item.weight_unit;
                                //MasterEntity.volume_unit = item.volume_unit;

                                if (BatchEntity.Where(x => x.sr_line_no == MM_T001_A_OBJ.line_id && x.pack_no == item.pack_no && x.batch_no == item.batch_no && x.location_Id == item.location_id && x.comp_code == item.comp_code && x.store_code == item.store_code).ToList().Count > 0)
                                {
                                    int Batchindex = BatchEntity.IndexOf(BatchEntity.Where(X => X.batch_no == item.batch_no && X.pack_no == item.pack_no).FirstOrDefault());
                                    //BatchEntity[batchsplitSelectedIndex].delivery_no = MM_T001_A_OBJ.delivery_no;
                                    BatchEntity[Batchindex].ItemCode = MM_T001_A_OBJ.ItemCode;
                                    BatchEntity[Batchindex].sku = MM_T001_A_OBJ.sku;
                                    BatchEntity[Batchindex].pack_no = item.pack_no;
                                    BatchEntity[Batchindex].batch_no = item.batch_no;
                                    BatchEntity[Batchindex].qty = item.batch_qty; // MM_T001_A_OBJ.qty >= item.batch_qty ? item.batch_qty : MM_T001_A_OBJ.qty;
                                    BatchEntity[Batchindex].unit_code = item.unit_code;
                                    BatchEntity[Batchindex].description = MM_T001_A_OBJ.description;
                                    BatchEntity[Batchindex].t_status = MM_T001_A_OBJ.t_status;
                                    BatchEntity[Batchindex].location_Id = MM_T001_A_OBJ.location_Id;
                                    BatchEntity[Batchindex].wa_code = MM_T001_A_OBJ.wa_code;
                                    BatchEntity[Batchindex].store_code = (item.store_code ?? MM_T001_A_OBJ.store_code);
                                    BatchEntity[Batchindex].active = MM_T001_A_OBJ.active;
                                    BatchEntity[Batchindex].add_by = AppSessionState.UserID;
                                    BatchEntity[Batchindex].editby = AppSessionState.UserID;
                                    BatchEntity[Batchindex].comp_code = MM_T001_A_OBJ.comp_code;
                                    BatchEntity[Batchindex].client = AppSessionState.client;
                                    BatchEntity[Batchindex].item_line_id = MM_T001_A_OBJ.id;
                                    BatchEntity[Batchindex].sr_line_no = MM_T001_A_OBJ.line_id;

                                }
                                else //if (batchsplitSelectedIndex >= 0 && BatchDetails.Select == true && BatchEntity.Count > batchsplitSelectedIndex) 
                                {
                                    MM_T001_A_OBJ.batch_split = true;
                                    batchdatagrid = true;
                                    split = true;
                                    if (BatchEntity.Where(x => x.barcode == item.barcode && x.batch_no == item.batch_no).ToList().Count == 0)
                                    {
                                        BatchEntity.Add(new MM_T001_B()
                                        {
                                            doc_no = MM_T001_A_OBJ.doc_no,
                                            ItemCode = item.ItemCode,
                                            sku = MM_T001_A_OBJ.sku,
                                            barcode = item.barcode,
                                            pack_no = item.pack_no,
                                            batch_no = item.batch_no,
                                            qty = item.batch_qty, //MM_T001_A_OBJ.qty >= item.batch_qty ? item.batch_qty : MM_T001_A_OBJ.qty,
                                            rec_qty = item.batch_qty,
                                            unit_code = item.unit_code,
                                            description = MM_T001_A_OBJ.description,
                                            t_status = MM_T001_A_OBJ.t_status,
                                            location_Id = MM_T001_A_OBJ.location_Id,
                                            wa_code = MM_T001_A_OBJ.wa_code,
                                            store_code = (item.store_code ?? MM_T001_A_OBJ.store_code),
                                            active = MM_T001_A_OBJ.active,
                                            add_by = AppSessionState.UserID,
                                            comp_code = MM_T001_A_OBJ.comp_code,
                                            client = AppSessionState.client,
                                            item_line_id = MM_T001_A_OBJ.id,
                                            sr_line_no = MM_T001_A_OBJ.line_id,
                                        });
                                    }
                                }
                            }
                            if (MasterEntity.doc_type == "MC" && MasterEntity.mov_tp == "107" && ItemsEntity != null) // add Credit Batch entery if not exists
                            {
                                if (BatchEntity != null && ItemsEntity.Count == 2)
                                {
                                    if (BatchEntity.Count > 0)
                                    {
                                        var BatchData = BatchEntity;
                                        MM_T001_A_OBJ_S = ItemsEntity.Where(x => x.debcr_ind == "D").ToList()[0]; //x.line_id == item.sr_line_no && 
                                        MM_T001_A_OBJ_D = ItemsEntity.Where(x => x.debcr_ind == "C").ToList()[0]; //x.line_id != MM_T001_A_OBJ_S.line_id && 
                                        MM_T001_A_OBJ = MM_T001_A_OBJ_D;// reset Credit Item row for Item Addition and colection change event for default values. once added then reset first value.
                                        
                                        
                                        foreach (var item_B in BatchData.ToList())
                                        {
                                            if (BatchEntity.Where(x => x.sr_line_no == MM_T001_A_OBJ_D.line_id && x.item_line_id == MM_T001_A_OBJ_D.id && x.batch_no == item_B.batch_no && x.pack_no == item_B.pack_no  && x.ItemCode== MM_T001_A_OBJ_D.ItemCode && (x.sku ?? "") == (MM_T001_A_OBJ_D.sku ?? "") && x.pack_no == item_B.pack_no).ToList().Count == 0)
                                            {
                                                MM_T001_B MM_T001_B_OBJ_S = new MM_T001_B();
                                                MM_T001_B MM_T001_B_OBJ_D = new MM_T001_B();
                                                MM_T001_B_OBJ.CopyPropertiesTo<MM_T001_B>(MM_T001_B_OBJ_D);
                                                item_B.CopyPropertiesTo<MM_T001_B>(MM_T001_B_OBJ_S);

                                                MM_T001_B_OBJ_D.ItemCode = MM_T001_A_OBJ_D.ItemCode;
                                                MM_T001_B_OBJ_D.sku = MM_T001_A_OBJ_D.sku;
                                                MM_T001_B_OBJ_D.sr_line_no = MM_T001_A_OBJ_D.line_id;
                                                MM_T001_B_OBJ_D.item_line_id = MM_T001_A_OBJ_D.id;
                                                MM_T001_B_OBJ_D.grn_id = MM_T001_A_OBJ_D.id;
                                                MM_T001_B_OBJ_D.location_Id = MM_T001_A_OBJ_D.location_Id;
                                                MM_T001_B_OBJ_D.store_code = item_B.store_code;
                                                MM_T001_B_OBJ_D.t_status = item_B.t_status;
                                                MM_T001_B_OBJ_D.unit_code = item_B.unit_code;
                                                MM_T001_B_OBJ_D.vendor_batch_no = item_B.vendor_batch_no;
                                                MM_T001_B_OBJ_D.wa_code = item_B.wa_code;
                                                MM_T001_B_OBJ_D.batch_no = item_B.batch_no;
                                                MM_T001_B_OBJ_D.qty = item_B.qty;
                                                MM_T001_B_OBJ_D.rec_qty = item_B.rec_qty;
                                                MM_T001_B_OBJ_D.unit_code = item_B.unit_code;
                                                MM_T001_B_OBJ_D.pack_no = item_B.pack_no;
                                                MM_T001_B_OBJ_D.user_source1 = item_B.batch_no;
                                                BatchEntity.Add(MM_T001_B_OBJ_D);
                                            }
                                        }
                                    }
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
                            BarcodeValue = "";
                            MM_T001_A_OBJ.barcode = "";
                        }
                    }
                    else
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok;
                        sms.Caption = "Message";
                        sms.Text = String.Format("Packing Data not available for Selected Item. Movment Type Not selected for Transaction or Credit Material Not exists for Material Conversion", this.Title);
                        sms.ShowMessage();
                    }
                    BarcodeValue = "";
                    MasterEntity.barcode = "";
                    MM_T001_A_OBJ.barcode = "";
                    MM_T001_A_OBJ = MM_T001_A_OBJ_S;// reset Debit row as selected row.
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
        #endregion
        #region SKU Region
        private void Click_SKU_ToggleButton(object InputValue)//this method is called when you click Item Description Toggle Button
        {
            string[] TempSkuList = new string[100];
            List<ADM_M0071> TempParaValueList = new List<ADM_M0071>();
            try
            {
                if (MM_T001_A_OBJ != null) // if Object is not null
                {
                    if (MM_T001_A_OBJ.id == 0 && MM_T001_A_OBJ.StockUnt == true) // if record is new and ind_sku is true.
                    {
                        PARAMETERS_LIST_SELECTED = (from o in MC.PARAMETERS_LIST where o.SubCatCode == MM_T001_A_OBJ.SubCatCode select o).ToList();// select those parameter which matches selected item subcat_code.
                        if (PARAMETERS_LIST_SELECTED.Count > 0 && !string.IsNullOrWhiteSpace(MM_T001_A_OBJ.sku)) // Assign already set values along with parameters.
                        {
                            TempSkuList = MM_T001_A_OBJ.sku.Split('/');
                            for (int i = 0; i < PARAMETERS_LIST_SELECTED.Count; i++)
                            {
                                TempParaValueList = (from o in MC.PARAMETERS_VALUES_LIST where o.value_code == TempSkuList[i] select o).ToList();
                                if (TempParaValueList.Count > 0)
                                {
                                    PARAMETERS_LIST_SELECTED[i] = TempParaValueList[0];
                                }
                            }
                            PARAMETERS_COL_SELECTED = CollectionViewSource.GetDefaultView(PARAMETERS_LIST_SELECTED);
                        }
                        else // Set null to all values of parameters for new entry.
                        {
                            foreach (var o in PARAMETERS_LIST_SELECTED)
                            {
                                o.parametervalue = null; o.value_code = null;
                            }
                            PARAMETERS_COL_SELECTED = CollectionViewSource.GetDefaultView(PARAMETERS_LIST_SELECTED);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void SelectionChangedParaValue(object obj)//IList parameter// this method called when you select parameter value from combobox
        {
            try
            {
                if (((IEnumerable)obj).Cast<ADM_M0071>().ToList().Count > 0)
                {
                    PARAMETERS_VALUE_OBJ = ((IEnumerable)obj).Cast<ADM_M0071>().ToList()[0];
                }

                if (MM_T001_A_OBJ != null && PARAMETERS_VALUE_OBJ != null && MM_T001_A_OBJ.StockUnt == true)
                {
                    if (MM_T001_A_OBJ.id == 0 && !string.IsNullOrWhiteSpace(PARAMETERS_VALUE_OBJ.parametervalue) && MM_T001_A_OBJ.StockUnt == true)
                    {
                        for (int i = 0; i < PARAMETERS_LIST_SELECTED.Count; i++)
                        {
                            if (PARAMETERS_LIST_SELECTED[i].para_code == PARAMETERS_VALUE_OBJ.para_code)
                            {
                                PARAMETERS_LIST_SELECTED[i].parametervalue = PARAMETERS_VALUE_OBJ.parametervalue;

                                var paravaluetemp = (from o in MC.PARAMETERS_VALUES_LIST where o.para_code == PARAMETERS_LIST_SELECTED[i].para_code && o.parametervalue == PARAMETERS_LIST_SELECTED[i].parametervalue select o).ToList();

                                if (paravaluetemp.Count > 0)
                                {
                                    PARAMETERS_LIST_SELECTED[i].value_code = paravaluetemp[0].value_code;
                                }
                            }
                        }

                        // SKU Description
                        GetSkuDescription();

                        //Function for calculating SKU
                        CalculateSku();
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void GetSkuDescription()
        {
            if (string.IsNullOrWhiteSpace(MM_T001_A_OBJ.sku_desc))
            {
                for (int i = 0; i < PARAMETERS_LIST_SELECTED.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(MM_T001_A_OBJ.sku_desc) && (String.IsNullOrEmpty(PARAMETERS_LIST_SELECTED[i].parametervalue) || PARAMETERS_LIST_SELECTED[i].parametervalue.Trim() != "NA"))
                    {
                        MM_T001_A_OBJ.sku_desc = PARAMETERS_LIST_SELECTED[i].para_name + ":" + PARAMETERS_LIST_SELECTED[i].parametervalue + "\t";
                    }
                    else if (String.IsNullOrEmpty(PARAMETERS_LIST_SELECTED[i].parametervalue) || PARAMETERS_LIST_SELECTED[i].parametervalue.Trim() != "NA")
                    {
                        MM_T001_A_OBJ.sku_desc = MM_T001_A_OBJ.sku_desc + PARAMETERS_LIST_SELECTED[i].para_name + ":" + PARAMETERS_LIST_SELECTED[i].parametervalue + "\t";
                    }
                }
            }
            else
            {
                MM_T001_A_OBJ.sku_desc = "";

                for (int i = 0; i < PARAMETERS_LIST_SELECTED.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(MM_T001_A_OBJ.sku_desc) && (String.IsNullOrEmpty(PARAMETERS_LIST_SELECTED[i].parametervalue) || PARAMETERS_LIST_SELECTED[i].parametervalue.Trim() != "NA"))
                    {
                        MM_T001_A_OBJ.sku_desc = PARAMETERS_LIST_SELECTED[i].para_name + ":" + PARAMETERS_LIST_SELECTED[i].parametervalue + "\t";
                    }
                    else if (String.IsNullOrEmpty(PARAMETERS_LIST_SELECTED[i].parametervalue) || PARAMETERS_LIST_SELECTED[i].parametervalue.Trim() != "NA")
                    {
                        MM_T001_A_OBJ.sku_desc = MM_T001_A_OBJ.sku_desc + PARAMETERS_LIST_SELECTED[i].para_name + ":" + PARAMETERS_LIST_SELECTED[i].parametervalue + "\t";
                    }
                }
            }
        }
        private void CalculateSku()
        { 
            if (string.IsNullOrWhiteSpace(MM_T001_A_OBJ.sku_desc) &&  MM_T001_A_OBJ.StockUnt == true)
            {
                for (int i = 0; i < PARAMETERS_LIST_SELECTED.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(MM_T001_A_OBJ.sku))
                    {
                        MM_T001_A_OBJ.sku = PARAMETERS_LIST_SELECTED[i].value_code;
                    }
                    else
                    {
                        MM_T001_A_OBJ.sku = MM_T001_A_OBJ.sku + "/" + PARAMETERS_LIST_SELECTED[i].value_code;
                    }
                }
            }
            else if(MM_T001_A_OBJ.StockUnt == true)
            {
                MM_T001_A_OBJ.sku = "";

                for (int i = 0; i < PARAMETERS_LIST_SELECTED.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(MM_T001_A_OBJ.sku_desc))
                    {
                        MM_T001_A_OBJ.sku = PARAMETERS_LIST_SELECTED[i].value_code;
                    }
                    else
                    {
                        MM_T001_A_OBJ.sku = MM_T001_A_OBJ.sku + "/" + PARAMETERS_LIST_SELECTED[i].value_code;
                    }
                }
            }
        }
        #endregion
        #region . Command Actions .
        protected override void OnSaveAction(InquiryActionResult<MM_T001> result)
        {
            try
            {
                if (Validations() == true)
                {
                    //if (MasterEntity.mov_tp == "107")
                    //{
                    //    InsertBatchDataForDestinationMaterial();
                    //}
                    MasterEntity.XmlDataDocument_MM_T001_A = obj.ObjectToXML(ItemsEntity);
                    MasterEntity.XmlDataDocument_MM_T001_B = obj.ObjectToXML(BatchEntity);

                    if (NewRecord == true)
                    {
                        //MCTemp = repository_MC.SaveWithReturnDomainObject<MC_MM_T001_STD>(MCTemp, "MM_T001_GM_STD", "SCM");
                        MasterEntity = repository.SaveWithReturnDomainObject<MM_T001>(MasterEntity, "MM_T001_GM_STD", "SCM");
                    }
                    else if (NewRecord == false)
                    {
                        //MCTemp = repository_MC.UpdateWithReturnDomainObject<MC_MM_T001_STD>(MCTemp, "MM_T001_GM_STD", "SCM");
                        MasterEntity = repository.UpdateWithReturnDomainObject<MM_T001>(MasterEntity, "MM_T001_GM_STD", "SCM");
                    }
                    NewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                    MoveFlag = false;  // after save movement type cannot be changed
                    SetBusinessEntitiesAfterLoad("Save", "");
                    RemoveReferenceDocuments();
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format("Record created successfully!"); sms.ShowMessage();
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                MasterEntity.ts_code = ts_code_vm;
                if (MasterEntity.XmlDataDocument_MM_T001_A != null)
                {
                    MC.ITEM_BE_LIST = (ObservableCollection<MM_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_MM_T001_A, MC.ITEM_BE_LIST);
                    ItemsEntity.Clear();
                    ItemsEntity = MC.ITEM_BE_LIST;
                }
                else
                {
                    ItemsEntity = new ObservableCollection<MM_T001_A>();
                }

                if (MasterEntity.XmlDataDocument_MM_T001_B != null)
                {
                    MC.BATCH_BE_LIST = (ObservableCollection<MM_T001_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_MM_T001_B, MC.BATCH_BE_LIST);
                    BatchEntity.Clear();
                    BatchEntity = MC.BATCH_BE_LIST;
                }
                else
                {
                    BatchEntity = new ObservableCollection<MM_T001_B>();
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void RemoveReferenceDocuments()
        {
            try
            {
                MC.REF_DOC_LIST.RemoveAll(X => X.doc_no == MasterEntity.ref_doc);
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnCreateAction(InquiryActionResult<MM_T001> result)
        {
            try
            {
                NewRecord = true; MoveFlag = true;
                MasterEntity = new MM_T001();
                ItemsEntity = new ObservableCollection<MM_T001_A>();
                BatchEntity = new ObservableCollection<MM_T001_B>();
                PARAMETERS_VALUE_OBJ = new ADM_M0071();
                MCTemp = new MC_MM_T001_STD();
                MM_T001_A_OBJ = new MM_T001_A();
                MM_T001_B_OBJ = new MM_T001_B();
                ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                BatchEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);

                DefaultValues(doc_cat_vm);

                if (MC.BATCH_LIST != null)
                {
                    if (MC.BATCH_LIST.Count > 0)
                    {
                        MC.BATCH_LIST.Clear();
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        protected override void OnRemoveAction(InquiryActionResult<MM_T001> result)
        {
            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Delete Changes"; sms.Text = String.Format("This record will be Deleted forever '{0}'", this.Title); sms.ShowMessage();
            if (sms.ShowMessage() == DialogResult.Ok)
            {
                this.MasterEntity.EndEdit();
                string response = repository.Delete(MasterEntity.doc_no, "GoodsReceiptNote", "SCM");
                //FlipGridData.Remove(MasterEntity); Temp
                MasterEntity = new MM_T001();
                ItemsEntity = new ObservableCollection<MM_T001_A>();
                BatchEntity = new ObservableCollection<MM_T001_B>();
                _FlipDataGridCollection.Refresh();
                NewRecord = true;
                MoveFlag = true;
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<MM_T001> result)
        { }
        protected override void OnFevoriteAction(InquiryActionResult<MM_T001> result)
        { }
        protected override void OnFlipAction(InquiryActionResult<MM_T001> result)
        {
            string Request = "RefreshData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + this.doc_cat_vm + "!@" + AppSessionState.EmpId;
            MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001_STD>(MC, Request, "MM_T001_STD", "SCM", "RefreshData", 0, "");
            MC.REF_DOC_LIST = MCTemp.REF_DOC_LIST;
        }
        protected override void OnHelpAction(InquiryActionResult<MM_T001> result)
        { }
        protected override void OnPrintAction(InquiryActionResult<MM_T001> result)
        {
            if (MasterEntity.doc_no == null || MasterEntity.doc_no == "")
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format("You must have to save the record first..Then print it", this.Title); sms.ShowMessage();
            }
            else
            { }
        }
        protected override void OnDocumentAction()
        { }
        protected override void OnRefreshCommand(InquiryActionResult<MM_T001> result)
        {
            LoadInitialData(doc_cat_vm,null);
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
        private void OnExportAction()
        { }
        #endregion

        #region . Filter Function .
        private string _filterString_BackFlip;
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
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BackFlip))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()) ||
                        data.mov_tp != null && data.mov_tp.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()) ||
                        data.mov_tp_name != null && data.mov_tp_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()) ||
                        data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()) ||
                        data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion
        #region . Filter Function .
        private string _FilterString_ReferenceDoc;
        public string FilterString_ReferenceDoc
        {
            get { return _FilterString_ReferenceDoc; }
            set
            {
                _FilterString_ReferenceDoc = value;
                RaisePropertyChanged("FilterString_ReferenceDocp");
                FilterCollection();
            }
        }
        private void FilterCollection()
        {
            if (HUCollection != null)
            {
                _HUCollection.Refresh();
            }
        }
        public bool FilterString_RefDoc(object obj)
        {
            var data = obj as STD_ITEM;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_ReferenceDoc))
                {
                    return (data.pack_no != null && data.pack_no.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                        data.pack_qty != null && data.pack_qty.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                        data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                        data.stock_total != null && data.stock_total.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion
    }
}
