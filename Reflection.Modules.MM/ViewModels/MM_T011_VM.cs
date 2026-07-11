using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.ReportingServices;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;
using System.Collections.Specialized;
using System.Windows;
using Reflection.BusinessEntity.MM;
using Reflection.BusinessEntity.ADM;
using Reflection.Presentation.Common;
using System.Threading.Tasks;

namespace Reflection.Modules.MM.ViewModels
{
    public class MM_T011_VM : WorkspaceViewModel<MM_T001>
    {

        #region Variable Declaration

        bool NewRecord = true;
        WebServiceRepository<MM_T001> REPOSITORY_OBJ = new WebServiceRepository<MM_T001>();
        WebServiceRepository<MC_MM_T001> REPOSITORY_OBJ_TEMP = new WebServiceRepository<MC_MM_T001>();
        MC_MM_T001 MC_TEMP = new MC_MM_T001();
        MC_MM_T001 MC = new MC_MM_T001();
        ObjectSerializationService SERIALIZATION_OBJ = new ObjectSerializationService();
        IShowMessageViewService sms;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }

        private string _Barcode;
        public string Barcode
        {
            get
            {
                return _Barcode;
            }
            set
            {
                if (_Barcode != value)
                {
                    _Barcode = value;
                    RaisePropertyChanged("Barcode");
                }
            }
        }
        private int _MainTabIndex;
        public int MainTabIndex
        {
            get { return _MainTabIndex; }
            set
            {
                if (_MainTabIndex != value)
                {
                    _MainTabIndex = value;
                    RaisePropertyChanged("MainTabIndex");
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
        private ObservableCollection<MM_T001_A> _ItemsEntity;
        public ObservableCollection<MM_T001_A> ItemsEntity
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
        private ObservableCollection<MM_T001_B> _BatchEntity;
        public ObservableCollection<MM_T001_B> BatchEntity
        {
            get { return _BatchEntity; }
            set
            {
                if (_BatchEntity != value)
                {
                    _BatchEntity = value;
                    _BatchEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
                    RaisePropertyChanged("BatchEntity");
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
        private MM_T001_A _ITEM_ENTITY_OBJ;
        public MM_T001_A ITEM_ENTITY_OBJ
        {
            get
            {
                return _ITEM_ENTITY_OBJ;
            }
            set
            {
                if (_ITEM_ENTITY_OBJ != value)
                {
                    _ITEM_ENTITY_OBJ = value;
                    RaisePropertyChanged(nameof(ITEM_ENTITY_OBJ));
                }
            }
        }
        private MM_T001_B _BATCH_ENTITY_OBJ;
        public MM_T001_B BATCH_ENTITY_OBJ
        {
            get
            {
                return _BATCH_ENTITY_OBJ;
            }
            set
            {
                if (_BATCH_ENTITY_OBJ != value)
                {
                    _BATCH_ENTITY_OBJ = value;
                    RaisePropertyChanged(nameof(BATCH_ENTITY_OBJ));
                }
            }
        }
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

        #endregion

        #region Autosuggest Initialization

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(MM_T011_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

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
        private DataGridCellInfo _cellInfoBatch;
        public DataGridCellInfo CellInfoBatch
        {
            get { return _cellInfoBatch; }
            set
            {
                _cellInfoBatch = value;
                SetAutoTextSourceBatch(_cellInfoBatch);
                RaisePropertyChanged("CellInfoBatch");
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

                    if (SourceName == "item_code")
                    { AS_DEFAULT = AS_ITEM; }
                    else if (SourceName == "unit_code")
                    { AS_DEFAULT = AS_UOM; }
                    else if (SourceName == "wc_code")
                    { AS_DEFAULT = AS_WORK_CENTER; }
                    else if (SourceName == "batch_no")
                    { AS_DEFAULT = AS_BATCH; }
                    else if (SourceName == "store_code")
                    { AS_DEFAULT = AS_STORE; }
                    else if (SourceName == "comp_code")
                    { AS_DEFAULT = AS_COMPANY_ITEM; }
                    else if (SourceName == "location_id")
                    { AS_DEFAULT = AS_LOCATION_ITEM; }
                    else if (SourceName == "mov_tp")
                    { AS_DEFAULT = AS_MOV_TYPE; }
                    else if (SourceName == "debcr_ind")
                    { AS_DEFAULT = AS_LOCATION_ITEM; }
                }
            }
        }
        private void SetAutoTextSourceBatch(DataGridCellInfo dgCellInfo)
        {
            if (dgCellInfo != null)
            {
                var column = dgCellInfo.Column as DataGridColumn;
                if (column != null)
                {
                    string headerName = column.Header.ToString();
                    string SourceName = column.SortMemberPath.ToString();
                   if (SourceName == "batch_no")
                    { _AS_DEFAULT_2 = AS_BATCH; }
                    else if (SourceName == "store_code")
                    { _AS_DEFAULT_2 = AS_STORE; }
                    else if (SourceName == "location_Id")
                    { _AS_DEFAULT_2 = AS_LOCATION; }

                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT
        {
            get { return _AS_DEFAULT; }
            set
            {
                if (_AS_DEFAULT != value)
                {
                    _AS_DEFAULT = value; RaisePropertyChanged("AS_DEFAULT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT_2 { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT_2
        {
            get { return _AS_DEFAULT_2; }
            set
            {
                if (_AS_DEFAULT_2 != value)
                {
                    _AS_DEFAULT_2 = value; RaisePropertyChanged("AS_DEFAULT_2");
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
        private AutoSuggestTextViewModel<dynamic> _AS_COMPANY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_COMPANY
        {
            get { return _AS_COMPANY; }
            set
            {
                if (_AS_COMPANY != value)
                {
                    _AS_COMPANY = value; RaisePropertyChanged("AS_COMPANY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_COMPANY_ITEM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_COMPANY_ITEM
        {
            get { return _AS_COMPANY_ITEM; }
            set
            {
                if (_AS_COMPANY_ITEM != value)
                {
                    _AS_COMPANY_ITEM = value; RaisePropertyChanged("AS_COMPANY_ITEM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_LOCATION { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_LOCATION
        {
            get { return _AS_LOCATION; }
            set
            {
                if (_AS_LOCATION != value)
                {
                    _AS_LOCATION = value; RaisePropertyChanged("AS_LOCATION");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_LOCATION_ITEM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_LOCATION_ITEM
        {
            get { return _AS_LOCATION_ITEM; }
            set
            {
                if (_AS_LOCATION_ITEM != value)
                {
                    _AS_LOCATION_ITEM = value; RaisePropertyChanged("AS_LOCATION_ITEM");
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
        private AutoSuggestTextViewModel<dynamic> _AS_REF_PARTY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_REF_PARTY
        {
            get { return _AS_REF_PARTY; }
            set
            {
                if (_AS_REF_PARTY != value)
                {
                    _AS_REF_PARTY = value; RaisePropertyChanged("AS_REF_PARTY");
                }
            }
        }
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
        private AutoSuggestTextViewModel<dynamic> _AS_STORE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_STORE
        {
            get { return _AS_STORE; }
            set
            {
                if (_AS_STORE != value)
                {
                    _AS_STORE = value; RaisePropertyChanged("AS_STORE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_PERSONNEL { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PERSONNEL
        {
            get { return _AS_PERSONNEL; }
            set
            {
                if (_AS_PERSONNEL != value)
                {
                    _AS_PERSONNEL = value; RaisePropertyChanged("AS_PERSONNEL");
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
        private AutoSuggestTextViewModel<dynamic> _AS_UOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM
        {
            get { return _AS_UOM; }
            set
            {
                if (_AS_UOM != value)
                {
                    _AS_UOM = value; RaisePropertyChanged("AS_UOM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ORDERS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ORDERS
        {
            get { return _AS_ORDERS; }
            set
            {
                if (_AS_ORDERS != value)
                {
                    _AS_ORDERS = value; RaisePropertyChanged("AS_ORDERS");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_WORK_CENTER { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_WORK_CENTER
        {
            get { return _AS_WORK_CENTER; }
            set
            {
                if (_AS_WORK_CENTER != value)
                {
                    _AS_WORK_CENTER = value; RaisePropertyChanged("AS_WORK_CENTER");
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
        private AutoSuggestTextViewModel<dynamic> _AS_PROJECT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PROJECT
        {
            get { return _AS_PROJECT; }
            set
            {
                if (_AS_PROJECT != value)
                {
                    _AS_PROJECT = value; RaisePropertyChanged("AS_PROJECT");
                }
            }
        }


        #endregion

        #region ICollection
        private ICollectionView _REF_DOC_COLLECTION;
        public ICollectionView REF_DOC_COLLECTION
        {
            get { return _REF_DOC_COLLECTION; }
            set { _REF_DOC_COLLECTION = value; RaisePropertyChanged("REF_DOC_COLLECTION"); }
        }
        private ICollectionView _PARA_COLLECTION;
        public ICollectionView PARA_COLLECTION
        {
            get { return _PARA_COLLECTION; }
            set
            {
                _PARA_COLLECTION = value;
                RaisePropertyChanged("PARA_COLLECTION");
            }
        }
        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }
        private ICollectionView _ITEM_COLLECTION;
        public ICollectionView ITEM_COLLECTION
        {
            get { return _ITEM_COLLECTION; }
            set { _ITEM_COLLECTION = value; RaisePropertyChanged("ITEM_COLLECTION"); }
        }

        #endregion

        #region RelayCommand

        public RelayCommand<object> cmdSelectionChanged_MM_T001 { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_MM_T001_A { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_MM_T001_B { get; private set; }
        public RelayCommand<object> cmdInsertStoreCode { get; private set; }
        public RelayCommand<object> cmdInsertCompany { get; private set; }
        public RelayCommand<object> cmdInsertCompanyItem { get; private set; }
        public RelayCommand<object> cmdInsertLocation { get; private set; }
        public RelayCommand<object> cmdInsertLocationItem { get; private set; }
        public RelayCommand<object> cmdInsertMovementType { get; private set; }
        public RelayCommand<object> cmdInsertMovementTypeItem { get; private set; }
        public RelayCommand<object> cmdInsertMaterial { get; private set; }
        public RelayCommand<object> cmdInsertUnit { get; private set; }
        public RelayCommand<object> cmdDataGridRowDelete { get; private set; }
        public RelayCommand<object> cmdDataGridRowDeleteBatch { get; private set; }
        public RelayCommand<object> cmdSelectionChangedItem { get; private set; }
        public RelayCommand<object> cmdInsertBatch { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdInsertPersonnel { get; private set; }
        public RelayCommand<object> cmdInsertWorkCenter { get; private set; }
        public RelayCommand<object> cmdExecuteReference { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdInsertOrder { get; private set; }
        public RelayCommand<object> cmdSelectReferenceDocument { get; private set; }

        #endregion

        #region . Constructor .
        public MM_T011_VM(string doc_cat, string ts_code)
            : base()
        {
            sms = GetViewService<IShowMessageViewService>();
            ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            MasterEntity = new MM_T001();
            ItemsEntity = new ObservableCollection<MM_T001_A>();
            BatchEntity = new ObservableCollection<MM_T001_B>();
            ITEM_ENTITY_OBJ = new MM_T001_A();
            BATCH_ENTITY_OBJ = new MM_T001_B();
            MM_T001.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Master);
            MM_T001_A.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Item);
            MM_T001_B.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Batch);
            MC_TEMP = new MC_MM_T001();
            MC = new MC_MM_T001();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            BatchEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
            CommandInitialisation();
            LoadInitialData();
        }
        public MM_T011_VM(string doc_cat, string ts_code, string doc_no)
            : base()
        {
            ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            doc_no_vm = doc_no;
            sms = GetViewService<IShowMessageViewService>();
            ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            MasterEntity = new MM_T001();
            ItemsEntity = new ObservableCollection<MM_T001_A>();
            BatchEntity = new ObservableCollection<MM_T001_B>();
            ITEM_ENTITY_OBJ = new MM_T001_A();
            BATCH_ENTITY_OBJ = new MM_T001_B();
            MM_T001.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Master);
            MM_T001_A.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Item);
            MC_TEMP = new MC_MM_T001();
            MC = new MC_MM_T001();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            BatchEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
            CommandInitialisation();
            LoadInitialData();
           
        }

        #endregion

        #region Command Functions

        private void SelectionChangedItem(object InputValue)
        {
            try
            {
                if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<MM_T001_A>().ToList().Count > 0)
                    {
                        ITEM_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<MM_T001_A>().ToList()[0];

                        List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == ITEM_ENTITY_OBJ.comp_code).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                        TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        AS_LOCATION_ITEM = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_Id", "location_id", true);
                        AS_LOCATION_ITEM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_LOCATION_ITEM.AutoSuggestVM.IsFreeTextAllowed = false;

                        List<MM_M0001> STORE_LIST_OBJ = MC.STORE_LIST.Where(x => x.comp_code == ITEM_ENTITY_OBJ.comp_code && x.location_id == ITEM_ENTITY_OBJ.location_Id).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
                        TheFilter = (o, prefix) => ((MM_M0001)o).store_code.ToLower().Contains(prefix.ToLower()) || ((MM_M0001)o).store_name.ToLower().Contains(prefix.ToLower());
                        AS_STORE = new AutoSuggestTextViewModel<dynamic>(STORE_LIST_OBJ, TheFilter, SuggestedValue, "store_code", "store_code", true);
                        AS_STORE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STORE.AutoSuggestVM.IsFreeTextAllowed = false;

                        List<STD_LIST_BE> WORK_CENTER_LIST_OBJ = MC.WC_LIST.Where(x => x.comp_code == ITEM_ENTITY_OBJ.comp_code && x.location_id == ITEM_ENTITY_OBJ.location_Id).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).wc_code);
                        TheFilter = (o, prefix) => ((STD_LIST_BE)o).wc_code.ToLower().Contains(prefix.ToLower()) || ((STD_LIST_BE)o).wc_name.ToLower().Contains(prefix.ToLower());
                        AS_WORK_CENTER = new AutoSuggestTextViewModel<dynamic>(WORK_CENTER_LIST_OBJ, TheFilter, SuggestedValue, "wc_code", "wc_code", true);
                        AS_WORK_CENTER.AutoSuggestVM.IsEmptyValueAllowed = true; AS_WORK_CENTER.AutoSuggestVM.IsFreeTextAllowed = false;

                        //NOTE: Also load Batch Data on change of SKU also.
                        List<STD_ITEM> BATCH_LIST_OBJ = MC.BATCH_LIST.Where(x => x.item_code == ITEM_ENTITY_OBJ.ItemCode && (x.sku ?? "") == (ITEM_ENTITY_OBJ.sku ?? "") && x.store_code == ITEM_ENTITY_OBJ.store_code).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).batch_no);
                        TheFilter = (o, prefix) => (((STD_ITEM)o).batch_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).batch_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        AS_BATCH = new AutoSuggestTextViewModel<dynamic>(BATCH_LIST_OBJ, TheFilter, SuggestedValue, "batch_no", "batch_no", true);
                        AS_BATCH.AutoSuggestVM.IsEmptyValueAllowed = true; AS_BATCH.AutoSuggestVM.IsFreeTextAllowed = true;
                    }
                }
            }
            catch (Exception ex)
            { /*sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();*/ }
        }
        private void InsertBatchItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                STD_ITEM POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUP_ENTITY_OBJ = MC.BATCH_LIST.Where(x => x.batch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.item_code.Equals(ITEM_ENTITY_OBJ.ItemCode) == true && (x.sku ?? "").Equals((ITEM_ENTITY_OBJ.sku ?? "")) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_ITEM>().Count() > 0)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                    }
                }

                #endregion

                if (POPUP_ENTITY_OBJ != null && ITEM_ENTITY_OBJ != null && !string.IsNullOrWhiteSpace(ITEM_ENTITY_OBJ.ItemCode))
                {
                    ITEM_ENTITY_OBJ.batch_no = POPUP_ENTITY_OBJ.batch_no;
                    BATCH_ENTITY_OBJ.ItemCode = POPUP_ENTITY_OBJ.item_code;
                    BATCH_ENTITY_OBJ.store_code = POPUP_ENTITY_OBJ.store_code;
                    BATCH_ENTITY_OBJ.unit_code = ITEM_ENTITY_OBJ.unit_code;
                    BATCH_ENTITY_OBJ.sr_line_no = ITEM_ENTITY_OBJ.line_id;
                    BATCH_ENTITY_OBJ.item_line_id = ITEM_ENTITY_OBJ.id;
                    if (!BATCH_ENTITY_OBJ.qty.HasValue || BATCH_ENTITY_OBJ.qty == 0)
                    {
                        BATCH_ENTITY_OBJ.qty = (ITEM_ENTITY_OBJ.qty >= POPUP_ENTITY_OBJ.qty) ? POPUP_ENTITY_OBJ.qty : ITEM_ENTITY_OBJ.qty;
                    }
                    BATCH_ENTITY_OBJ.comp_code = BATCH_ENTITY_OBJ.comp_code;
                    BATCH_ENTITY_OBJ.location_Id = BATCH_ENTITY_OBJ.location_Id;
                    BATCH_ENTITY_OBJ.userid = AppSessionState.UserID;
                    BATCH_ENTITY_OBJ.add_by = AppSessionState.UserID;
                    BATCH_ENTITY_OBJ.sku = BATCH_ENTITY_OBJ.sku;
                    BATCH_ENTITY_OBJ.t_status = BATCH_ENTITY_OBJ.t_status;
                    BATCH_ENTITY_OBJ.active = true;
                    BATCH_ENTITY_OBJ.client = AppSessionState.client;
                    BATCH_ENTITY_OBJ.ref_batch_row_id = BATCH_ENTITY_OBJ.id;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }

        }
        private void LoadBackFlipData(object para)
        {
            string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + (REQ_PARA_OBJ.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (REQ_PARA_OBJ.doc_type ?? doc_cat_vm) + "!@" + (REQ_PARA_OBJ.active ?? true).ToString()  + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID;
            MC_TEMP = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<MM_T001>(MC_TEMP, Request, "MM_T001_BL_NEW", "MM", "", 0, "");

            BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC_TEMP.BACK_FLIP_LIST);
            BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);
            //BACKFLIP_COLLECTION.Refresh();

            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
        }
        private void InsertMovementType(object InputValue)
        {
            try
            {
                string Request = "";
                MM_M0004 POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            {
                                POPUP_ENTITY_OBJ = MC.MOV_TYPE_LIST.Where(x => x.mov_tp.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<MM_M0004>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUP_ENTITY_OBJ != null)
                {
                    MasterEntity.mov_tp = POPUP_ENTITY_OBJ.mov_tp;
                    MasterEntity.mov_name = POPUP_ENTITY_OBJ.mov_tp_name;
                    MasterEntity.posting_key = POPUP_ENTITY_OBJ.post_key_ref;

                    //if (MasterEntity.mov_tp == "114")
                    //{
                    //    var ORDER_LIST_OBJ = (from o in MC.ORDER_LIST where o.doc_cat == "SO" select o).ToList();
                    //    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).order_no);
                    //    TheFilter = (o, prefix) => ((STD_LIST_BE)o).order_no.ToLower().Contains(prefix.ToLower()) || ((STD_LIST_BE)o).item_code.ToLower().Contains(prefix.ToLower());
                    //    AS_ORDERS = new AutoSuggestTextViewModel<dynamic>(ORDER_LIST_OBJ, TheFilter, SuggestedValue, "order_doc_no", "order_no", true);
                    //    AS_ORDERS.AutoSuggestVM.IsEmptyValueAllowed = true;
                    //}
                    //else if (MasterEntity.mov_tp == "104")
                    //{
                    //    var ORDER_LIST_OBJ = (from o in MC.ORDER_LIST where o.doc_cat == "PJ" select o).ToList();
                    //    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).order_no);
                    //    TheFilter = (o, prefix) => ((STD_LIST_BE)o).order_no.ToLower().Contains(prefix.ToLower()) || ((STD_LIST_BE)o).item_code.ToLower().Contains(prefix.ToLower());
                    //    AS_ORDERS = new AutoSuggestTextViewModel<dynamic>(ORDER_LIST_OBJ, TheFilter, SuggestedValue, "order_doc_no", "order_no", true);
                    //    AS_ORDERS.AutoSuggestVM.IsEmptyValueAllowed = true;
                    //}
                    //else if (MasterEntity.mov_tp == "103")
                    //{
                    //    var ORDER_LIST_OBJ = (from o in MC.ORDER_LIST where (o.doc_cat == "OR" || o.doc_cat == "OR") select o).ToList();
                    //    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).order_no);
                    //    TheFilter = (o, prefix) => ((STD_LIST_BE)o).order_no.ToLower().Contains(prefix.ToLower()) || ((STD_LIST_BE)o).item_code.ToLower().Contains(prefix.ToLower());
                    //    AS_ORDERS = new AutoSuggestTextViewModel<dynamic>(ORDER_LIST_OBJ, TheFilter, SuggestedValue, "order_doc_no", "order_no", true);
                    //    AS_ORDERS.AutoSuggestVM.IsEmptyValueAllowed = true;
                    //}

                }

            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }

        }
        private void InsertMovementTypeItem(object InputValue)
        {
            try
            {
                string Request = "";
                MM_M0004 POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            {
                                POPUP_ENTITY_OBJ = MC.MOV_TYPE_LIST.Where(x => x.mov_tp.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<MM_M0004>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUP_ENTITY_OBJ != null)
                {
                    ITEM_ENTITY_OBJ.mov_tp = POPUP_ENTITY_OBJ.mov_tp;
                    ITEM_ENTITY_OBJ.debcr_ind = POPUP_ENTITY_OBJ.debit_credit;
                    ITEM_ENTITY_OBJ.posting_key = POPUP_ENTITY_OBJ.post_key_ref;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }

        }
        private void SelectReferenceDocument(object InputValue)
        {
            try
            {
                STD_LIST_BE POPUPEntityObject = null;
                string Request;
                REQ_PARA_OBJ.doc_no = null;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.REF_DOC_LIST.Where(x => x.ref_doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    // Clear Other reference.
                    var REF_DOC_TEMP = (from o in MC.REF_DOC_LIST where o.ref_doc_cat != POPUPEntityObject.ref_doc_cat select o);
                    if (REF_DOC_TEMP != null)
                    {
                        foreach (var item in REF_DOC_TEMP)
                        {
                            item.selected = false;
                        }
                    }
                    if (POPUPEntityObject.selected == true)
                    {
                        REQ_PARA_OBJ.doc_cat = POPUPEntityObject.ref_doc_cat;
                        REQ_PARA_OBJ.doc_type = POPUPEntityObject.ref_doc_type;
                        REQ_PARA_OBJ.doc_no = "";
                        var REF_TEMP = from o in MC.REF_DOC_LIST
                                       where o.party_code == POPUPEntityObject.party_code && o.ref_doc_cat == POPUPEntityObject.ref_doc_cat
                                             && o.ref_doc_type == POPUPEntityObject.ref_doc_type
                                       select o;

                        REF_DOC_COLLECTION = CollectionViewSource.GetDefaultView(REF_TEMP);
                        REF_DOC_COLLECTION.Filter = adv => ((STD_LIST_BE)adv).ref_doc_no != null;
                        REF_DOC_COLLECTION.Refresh();
                    }
                    else // if user uncheck all records then it should be relist all records.
                    {
                        List<STD_LIST_BE> REF_SELECT_COUNT = (from o in MC.REF_DOC_LIST where o.ref_doc_cat == POPUPEntityObject.ref_doc_cat && o.selected == true select o).ToList();
                        if (REF_SELECT_COUNT.Count == 0)
                        {
                            REF_DOC_COLLECTION = CollectionViewSource.GetDefaultView(MC.REF_DOC_LIST);
                            REF_DOC_COLLECTION.Filter = adv => ((STD_LIST_BE)adv).ref_doc_no != null;
                            REF_DOC_COLLECTION.Refresh();
                        }
                    }
                    List<STD_LIST_BE> REF_SELECT = (from o in MC.REF_DOC_LIST where o.ref_doc_cat == REQ_PARA_OBJ.doc_cat && o.selected == true select o).ToList();
                    foreach (var item in REF_SELECT)
                    {
                        if (item.selected == true)
                        {
                            if (!string.IsNullOrWhiteSpace(item.control_key))
                            {
                                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Asset return is pending for document number : " + item.control_key, this.Title); sms.ShowMessage();
                            }
                            REQ_PARA_OBJ.doc_no = REQ_PARA_OBJ.doc_no + "," + item.ref_doc_no;
                            MasterEntity.ref_doc = item.ref_doc_no;
                            MasterEntity.order_doc_no = item.ref_doc_no;
                            MasterEntity.bom_no = item.bom_no;
                            MasterEntity.qty = item.order_qty;
                        }
                    }

                    REQ_PARA_OBJ.doc_no = REQ_PARA_OBJ.doc_no.ToString().TrimStart(new char[] { ',' });
                }
            }
            catch (Exception Ex) { }
        }
        private void InsertOrder(object InputValue)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            {
                                POPUP_ENTITY_OBJ = MC.ORDER_LIST.Where(x => x.order_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUP_ENTITY_OBJ != null)
                {
                    MasterEntity.order_doc_no = POPUP_ENTITY_OBJ.order_no;
                    MasterEntity.bom_no = POPUP_ENTITY_OBJ.bom_no;
                    MasterEntity.qty = POPUP_ENTITY_OBJ.order_qty;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertPersonnel(object InputValue)
        {
            try
            {
                string Request = "";
                STD_PERSONNEL POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUP_ENTITY_OBJ = MC.PERSONNEL_LIST.Where(x => x.emp_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<STD_PERSONNEL>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                //if (POPUP_ENTITY_OBJ != null && MasterEntity.EmpId != POPUP_ENTITY_OBJ.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUP_ENTITY_OBJ != null)
                {
                    MasterEntity.EmpId = POPUP_ENTITY_OBJ.emp_id;
                    MasterEntity.Req_Name = POPUP_ENTITY_OBJ.emp_name;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertCompany(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0002 POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUP_ENTITY_OBJ = MC.COMPANY_LIST.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<ADM_M0002>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUP_ENTITY_OBJ != null)
                {
                    MasterEntity.comp_code = POPUP_ENTITY_OBJ.comp_code;

                    List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == MasterEntity.comp_code).ToList();
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                    TheFilter = (o, prefix) => ((ADM_M0003)o).location_id.ToLower().Contains(prefix.ToLower()) || ((ADM_M0003)o).location_name.ToLower().Contains(prefix.ToLower());
                    AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", true);
                    AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = false; AS_LOCATION.AutoSuggestVM.IsFreeTextAllowed = false;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertCompanyItem(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0002 POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUP_ENTITY_OBJ = MC.COMPANY_LIST.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<ADM_M0002>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUP_ENTITY_OBJ != null)
                {
                    ITEM_ENTITY_OBJ.comp_code = POPUP_ENTITY_OBJ.comp_code;
                    ITEM_ENTITY_OBJ.location_Id = null;

                    List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == ITEM_ENTITY_OBJ.comp_code).ToList();
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                    TheFilter = (o, prefix) => ((ADM_M0003)o).location_id.ToLower().Contains(prefix.ToLower()) || ((ADM_M0003)o).location_name.ToLower().Contains(prefix.ToLower());
                    AS_LOCATION_ITEM = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", true);
                    AS_LOCATION_ITEM.AutoSuggestVM.IsEmptyValueAllowed = false; AS_LOCATION_ITEM.AutoSuggestVM.IsFreeTextAllowed = false;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertLocation(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0003 POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUP_ENTITY_OBJ = MC.LOCATION_LIST.Where(x => x.location_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.comp_code == MasterEntity.comp_code).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<ADM_M0003>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUP_ENTITY_OBJ != null)
                {
                    MasterEntity.location_Id = POPUP_ENTITY_OBJ.location_id;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertLocationItem(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M0003 POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUP_ENTITY_OBJ = MC.LOCATION_LIST.Where(x => x.location_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.comp_code == ITEM_ENTITY_OBJ.comp_code).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<ADM_M0003>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUP_ENTITY_OBJ != null)
                {
                    ITEM_ENTITY_OBJ.location_Id = POPUP_ENTITY_OBJ.location_id;

                    List<MM_M0001> STORE_LIST_OBJ = MC.STORE_LIST.Where(x => x.comp_code == ITEM_ENTITY_OBJ.comp_code && x.location_id == ITEM_ENTITY_OBJ.location_Id).ToList();
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
                    TheFilter = (o, prefix) => ((MM_M0001)o).store_code.ToLower().Contains(prefix.ToLower()) || ((MM_M0001)o).store_name.ToLower().Contains(prefix.ToLower());
                    AS_STORE = new AutoSuggestTextViewModel<dynamic>(STORE_LIST_OBJ, TheFilter, SuggestedValue, "store_code", "store_code", true);
                    AS_STORE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STORE.AutoSuggestVM.IsFreeTextAllowed = false;

                    List<STD_LIST_BE> WORK_CENTER_LIST_OBJ = MC.WC_LIST.Where(x => x.comp_code == ITEM_ENTITY_OBJ.comp_code && x.location_id == ITEM_ENTITY_OBJ.location_Id).ToList();
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).wc_code);
                    TheFilter = (o, prefix) => ((STD_LIST_BE)o).wc_code.ToLower().Contains(prefix.ToLower()) || ((STD_LIST_BE)o).wc_name.ToLower().Contains(prefix.ToLower());
                    AS_WORK_CENTER = new AutoSuggestTextViewModel<dynamic>(WORK_CENTER_LIST_OBJ, TheFilter, SuggestedValue, "wc_code", "wc_code", true);
                    AS_WORK_CENTER.AutoSuggestVM.IsEmptyValueAllowed = true; AS_WORK_CENTER.AutoSuggestVM.IsFreeTextAllowed = false;

                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                UOMS POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUP_ENTITY_OBJ = MC.UOM_LIST.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<UOMS>().ToList()[0];
                    }
                }
                #endregion

                if (POPUP_ENTITY_OBJ != null)
                {
                    ITEM_ENTITY_OBJ.unit_code = POPUP_ENTITY_OBJ.unit_code;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertWorkCenter(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUP_ENTITY_OBJ = MC.WC_LIST.Where(x => x.wc_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.location_id==MasterEntity.location_Id && x.comp_code==MasterEntity.comp_code).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                #endregion
                if (POPUP_ENTITY_OBJ != null) 
                {
                    ITEM_ENTITY_OBJ.wc_code = POPUP_ENTITY_OBJ.wc_code;
                    ITEM_ENTITY_OBJ.machinecode = POPUP_ENTITY_OBJ.wc_code;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertStoreCode(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                MM_M0001 POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUP_ENTITY_OBJ = MC.STORE_LIST.Where(x => x.store_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.location_id == ITEM_ENTITY_OBJ.location_Id && x.comp_code == ITEM_ENTITY_OBJ.comp_code).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<MM_M001>().Count() > 0)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<MM_M0001>().ToList()[0];
                    }
                }
                #endregion
                if (POPUP_ENTITY_OBJ != null) // Only enter in the code block if ENtity Not null.
                {
                    ITEM_ENTITY_OBJ.store_code = POPUP_ENTITY_OBJ.store_code;

                    //NOTE: Also load Batch Data on change of SKU also.
                    List<STD_ITEM> BATCH_LIST_OBJ = MC.BATCH_LIST.Where(x => x.item_code == ITEM_ENTITY_OBJ.ItemCode && (x.sku ?? "") == (ITEM_ENTITY_OBJ.sku ?? "") && x.store_code == ITEM_ENTITY_OBJ.store_code).ToList();
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).batch_no);
                    TheFilter = (o, prefix) => (((STD_ITEM)o).batch_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).batch_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    AS_BATCH = new AutoSuggestTextViewModel<dynamic>(BATCH_LIST_OBJ, TheFilter, SuggestedValue, "batch_no", "batch_no", true);
                    AS_BATCH.AutoSuggestVM.IsEmptyValueAllowed = true; AS_BATCH.AutoSuggestVM.IsFreeTextAllowed = true;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertMaterial(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify) // NOTE: do not allow to add Material without MasterEntity fields like comp_code,Location etc.
        {
            try
            {
                string Request = "";
                STD_ITEM POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUP_ENTITY_OBJ = MC.STD_ITEM_LIST.Where(x => x.item_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_ITEM>().Count() > 0)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                    }
                }
                #endregion
                if (POPUP_ENTITY_OBJ != null && ITEM_ENTITY_OBJ != null) // Only enter in the code block if ENtity Not null.
                {
                    if (ITEM_ENTITY_OBJ.line_id == 0)
                    {
                        ITEM_ENTITY_OBJ.line_id = ItemsEntity.Count;
                    }
                    ITEM_ENTITY_OBJ.ItemCode = POPUP_ENTITY_OBJ.item_code;
                    ITEM_ENTITY_OBJ.description = POPUP_ENTITY_OBJ.item_name;
                    ITEM_ENTITY_OBJ.unit_code = POPUP_ENTITY_OBJ.unit_code;
                    ITEM_ENTITY_OBJ.StockUnt = Convert.ToBoolean(POPUP_ENTITY_OBJ.ind_sku);
                    ITEM_ENTITY_OBJ.active = true;
                    ITEM_ENTITY_OBJ.SubCatCode = POPUP_ENTITY_OBJ.item_subcat;
                    ITEM_ENTITY_OBJ.location_Id = MasterEntity.location_Id;
                    ITEM_ENTITY_OBJ.comp_code = MasterEntity.comp_code;
                    ITEM_ENTITY_OBJ.client = AppSessionState.client;
                    ITEM_ENTITY_OBJ.add_by = AppSessionState.UserID;
                    ITEM_ENTITY_OBJ.store_code = null; // store_location; // add as above
                    ITEM_ENTITY_OBJ.qty = POPUP_ENTITY_OBJ.qty;
                    ITEM_ENTITY_OBJ.order_doc_no = MasterEntity.order_doc_no;
                    ITEM_ENTITY_OBJ.debcr_ind = (from o in MC.MOV_TYPE_LIST where o.mov_tp == MasterEntity.mov_tp select o.debit_credit).FirstOrDefault();
                    ITEM_ENTITY_OBJ.order_no = MasterEntity.order_doc_no;
                    ITEM_ENTITY_OBJ.source_doc_no = MasterEntity.ref_doc ?? MasterEntity.order_doc_no;
                    ITEM_ENTITY_OBJ.doc_cat = MasterEntity.doc_cat;
                    ITEM_ENTITY_OBJ.doc_type = MasterEntity.doc_type;
                    ITEM_ENTITY_OBJ.doc_date = MasterEntity.doc_date;
                    ITEM_ENTITY_OBJ.mov_tp = MasterEntity.mov_tp;
                    ITEM_ENTITY_OBJ.post_date = MasterEntity.post_date;
                    ITEM_ENTITY_OBJ.order_no = MasterEntity.order_doc_no;
                    ITEM_ENTITY_OBJ.t_status = MasterEntity.t_status;
                    ITEM_ENTITY_OBJ.t_display = MasterEntity.t_display;

                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }

        #endregion

        #region Change Notification
        void ModelChangeNotification_Master(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {
                    if (sender.ToString() == "comp_code") // AS_LOCATION as per comp_code logic shift to InserCompany Function
                    {
                        List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == MasterEntity.comp_code).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                        TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", true);
                        AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = true; AS_LOCATION.AutoSuggestVM.IsFreeTextAllowed = false;
                        if (LOC_LIST_OBJ.Count == 1)
                        {
                            MasterEntity.location_Id = LOC_LIST_OBJ[0].location_id;
                        }
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        void ModelChangeNotification_Item(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {
                    if (sender.ToString() == "comp_code") // AS_LOCATION as per comp_code logic shift to InserCompany Function
                    {
                        List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == ITEM_ENTITY_OBJ.comp_code).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                        TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        AS_LOCATION_ITEM = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_Id","location_id", true);
                        AS_LOCATION_ITEM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_LOCATION_ITEM.AutoSuggestVM.IsFreeTextAllowed = false;
                        if (LOC_LIST_OBJ.Count == 1)
                        {
                            ITEM_ENTITY_OBJ.location_Id = LOC_LIST_OBJ[0].location_id;
                        }
                    }
                    if (sender.ToString() == "location_Id") // AS_STORE & AS_WORK_CENTER as per comp_code & Location_id logic shift to InserLocation Function
                    {
                        List<MM_M0001> STORE_LIST_OBJ = MC.STORE_LIST.Where(x => x.comp_code == ITEM_ENTITY_OBJ.comp_code && x.location_id == ITEM_ENTITY_OBJ.location_Id).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
                        TheFilter = (o, prefix) => ((MM_M0001)o).store_code.ToLower().Contains(prefix.ToLower()) || ((MM_M0001)o).store_name.ToLower().Contains(prefix.ToLower());
                        AS_STORE = new AutoSuggestTextViewModel<dynamic>(STORE_LIST_OBJ, TheFilter, SuggestedValue, "store_code", "store_code", true);
                        AS_STORE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STORE.AutoSuggestVM.IsFreeTextAllowed = false;

                        List<STD_LIST_BE> WORK_CENTER_LIST_OBJ = MC.WC_LIST.Where(x => x.comp_code == ITEM_ENTITY_OBJ.comp_code && x.location_id == ITEM_ENTITY_OBJ.location_Id).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).wc_code);
                        TheFilter = (o, prefix) => ((STD_LIST_BE)o).wc_code.ToLower().Contains(prefix.ToLower()) || ((STD_LIST_BE)o).wc_name.ToLower().Contains(prefix.ToLower());
                        AS_WORK_CENTER = new AutoSuggestTextViewModel<dynamic>(WORK_CENTER_LIST_OBJ, TheFilter, SuggestedValue, "wc_code", "wc_code", true);
                        AS_WORK_CENTER.AutoSuggestVM.IsEmptyValueAllowed = true; AS_WORK_CENTER.AutoSuggestVM.IsFreeTextAllowed = false;
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        void ModelChangeNotification_Batch(object sender, EventArgs e)
        {}
        private void CollectionChangedNotifyForBatch(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && BatchEntity.Count > 0) // Batch can only enable to add if items exists in Items Entity.
            {
                try
                {
                    foreach (MM_T001_B item in e.NewItems)
                    {
                    }
                }
                catch (Exception ex)
                { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
            }
            if (e.Action == NotifyCollectionChangedAction.Replace)
            { }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            { }
            if (e.Action == NotifyCollectionChangedAction.Move)
            { }
        }
        #endregion

        #region . User Defined Function.
        private void CommandInitialisation()
        {
            cmdInsertPersonnel = new RelayCommand<object>(items => { if (items == null) { return; } InsertPersonnel(items); });
            cmdInsertMovementType = new RelayCommand<object>(items => { if (items == null) { return; } InsertMovementType(items); });
            cmdInsertMovementTypeItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertMovementTypeItem(items); });
            cmdInsertMaterial = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMaterial(cmdPara, true, true, true); });
            cmdInsertUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara, false, true, true); });
            cmdInsertStoreCode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertStoreCode(cmdPara, false, true, true); });
            cmdInsertBatch = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBatchItem(cmdPara, false, true, true); });
            cmdInsertOrder = new RelayCommand<object>(items => { if (items == null) { return; } InsertOrder(items); });
            cmdDataGridRowDelete = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_Item(items); });
            cmdDataGridRowDeleteBatch = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_ItemBatch(items); });
            cmdSelectionChangedItem = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChangedItem(items); });
            cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            cmdInsertWorkCenter = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWorkCenter(cmdPara, false, true, true); });
            cmdLoadBackFlip = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });
            cmdInsertCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdInsertCompanyItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompanyItem(items); });
            cmdInsertLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocation(items); });
            cmdInsertLocationItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocationItem(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdExecuteReference = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteReference(items); });
            cmdSelectReferenceDocument = new RelayCommand<object>(items => { if (items == null) { return; } SelectReferenceDocument(items); });
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI_" + doc_cat_vm + "!@" + AppSessionState.client + "!@" + (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (MasterEntity.location_Id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? doc_cat_vm) + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm;
                MC = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "MM_T001_BL_NEW", "MM", Request, 0, "LOAD_INI");

                #region AutoSuggest Initialization

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => ((UOMS)o).unit_code.ToLower().Contains(prefix.ToLower());
                AS_DEFAULT = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "item_code", true);
                AS_DEFAULT.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => ((UOMS)o).unit_code.ToLower().Contains(prefix.ToLower());
                AS_DEFAULT_2 = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "item_code", true);
                AS_DEFAULT_2.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                TheFilter = (o, prefix) => ((STD_ITEM)o).item_code.ToLower().Contains(prefix.ToLower()) || ((STD_ITEM)o).item_name.ToLower().Contains(prefix.ToLower());
                AS_ITEM = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "ItemCode", "item_code", true);
                AS_ITEM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ITEM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                TheFilter = (o, prefix) => ((ADM_M0002)o).comp_code.ToLower().Contains(prefix.ToLower()) || ((ADM_M0002)o).comp_name.ToLower().Contains(prefix.ToLower());
                AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", "comp_code", true);
                AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = false; AS_COMPANY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                TheFilter = (o, prefix) => ((ADM_M0002)o).comp_code.ToLower().Contains(prefix.ToLower()) || ((ADM_M0002)o).comp_name.ToLower().Contains(prefix.ToLower());
                AS_COMPANY_ITEM = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", "comp_code", true);
                AS_COMPANY_ITEM.AutoSuggestVM.IsEmptyValueAllowed = false; AS_COMPANY_ITEM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0004)x).mov_tp);
                TheFilter = (o, prefix) => ((MM_M0004)o).mov_tp.ToLower().Contains(prefix.ToLower()) || ((MM_M0004)o).mov_tp_name.ToLower().Contains(prefix.ToLower());
                AS_MOV_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.MOV_TYPE_LIST, TheFilter, SuggestedValue, "mov_tp", "mov_tp", true);
                AS_MOV_TYPE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_MOV_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => ((STD_PERSONNEL)o).emp_id.ToLower().Contains(prefix.ToLower()) || ((STD_PERSONNEL)o).emp_name.ToLower().Contains(prefix.ToLower());
                AS_PERSONNEL = new AutoSuggestTextViewModel<dynamic>(MC.PERSONNEL_LIST, TheFilter, SuggestedValue, "emp_id", true);
                AS_PERSONNEL.AutoSuggestVM.IsEmptyValueAllowed = true; AS_PERSONNEL.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => ((UOMS)o).unit_code.ToLower().Contains(prefix.ToLower()) || ((UOMS)o).unit_name.ToLower().Contains(prefix.ToLower());
                AS_UOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                AS_UOM.AutoSuggestVM.IsEmptyValueAllowed = false; AS_UOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).project_id);
                TheFilter = (o, prefix) => ((STD_LIST_BE)o).project_id.ToLower().Contains(prefix.ToLower()) || ((STD_LIST_BE)o).project_name.ToLower().Contains(prefix.ToLower());
                AS_PROJECT = new AutoSuggestTextViewModel<dynamic>(MC.PROJECT_LIST, TheFilter, SuggestedValue, "project_id", true);
                AS_PROJECT.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => ((ADM_M0013)o).t_status.ToLower().Contains(prefix.ToLower()) || ((ADM_M0013)o).t_display.ToLower().Contains(prefix.ToLower());
                AS_STATUS = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                AS_STATUS.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STATUS.AutoSuggestVM.IsFreeTextAllowed = false;

                //List<MM_M0001> STORE_LIST_OBJ = MC.STORE_LIST.Where(x => x.comp_code == MasterEntity.comp_code && x.location_id == MasterEntity.location_Id).ToList();
                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
                //TheFilter = (o, prefix) => ((MM_M0001)o).store_code.ToLower().Contains(prefix.ToLower()) || ((MM_M0001)o).store_name.ToLower().Contains(prefix.ToLower());
                //AS_STORE = new AutoSuggestTextViewModel<dynamic>(STORE_LIST_OBJ, TheFilter, SuggestedValue, "store_code", "store_code", true);
                //AS_STORE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STORE.AutoSuggestVM.IsFreeTextAllowed = false;

                //List<STD_PPC_BE> WORK_CENTER_LIST_OBJ = MC.WORK_CENTER_LIST.Where(x => x.comp_code == MasterEntity.comp_code && x.location_id == MasterEntity.location_Id).ToList();
                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PPC_BE)x).wc_code);
                //TheFilter = (o, prefix) => ((STD_PPC_BE)o).wc_code.ToLower().Contains(prefix.ToLower()) || ((STD_PPC_BE)o).wc_name.ToLower().Contains(prefix.ToLower());
                //AS_WORK_CENTER = new AutoSuggestTextViewModel<dynamic>(WORK_CENTER_LIST_OBJ, TheFilter, SuggestedValue, "wc_code", "wc_code", true);
                //AS_WORK_CENTER.AutoSuggestVM.IsEmptyValueAllowed = true; AS_WORK_CENTER.AutoSuggestVM.IsFreeTextAllowed = false;

                #endregion

                #region Collections
                REF_DOC_COLLECTION = CollectionViewSource.GetDefaultView(MC.REF_DOC_LIST);
                REF_DOC_COLLECTION.Filter = new Predicate<object>(FLTR_REF_DOC);
                #endregion

            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        // FilterScheduleDataGrid : Filter for Schedule Items as per selected item in dgItemsEntity. This filter is work for ObserverableCollection.
        // Shift this logic in SelectedItem Change function command.
        private void FilterBatchDataGrid()
        {
            try
            {
                if (BatchEntity != null && BatchEntity.Count > 0 && dgSelectedIndexItem <= BatchEntity.Count && dgSelectedIndexItem >= 0)
                {
                    //DataGridView = CollectionViewSource.GetDefaultView(BatchEntity);
                    //DataGridView.Filter = adv => ((MM_T001_B)adv).sr_line_no.Equals(ItemsEntity[dgSelectedIndexItem].line_id);
                    //DataGridView.Refresh();
                }
            }
            catch
            {

            }

        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                STD_LIST_BE ParameterEntityObject = null;
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    ParametersStringValue = ParameterObject.ToString().Trim();
                    if (ParametersStringValue.Length > 0)
                    {
                        if (ParametersStringValue == "ReferenceDocument")
                        {
                        }
                    }
                }
                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];
                        Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + (REQ_PARA_OBJ.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (REQ_PARA_OBJ.doc_type ?? doc_cat_vm) + "!@"  + ParameterEntityObject.doc_no;
                        MC_TEMP = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<MC_MM_T001>(MC_TEMP, Request, "MM_T001_BL_NEW", "MM", Request, 0, "LOAD_DOC_BY_DOC_NO");
                        
                        //NOTE: Decide following code
                        //AttachmentCollection = CollectionViewSource.GetDefaultView(MC.ATTACHMENT_LIST); // NOTE: teporary commented.
                        //MoveFlag = false;
                        //LockAfterSave = false;
                    }
                }
                EntityChangeEnable = false;
                if (MC_TEMP.MASTER_ENTITY_LIST != null)
                {
                    if (MC_TEMP.MASTER_ENTITY_LIST.Count > 0)
                    {
                        MasterEntity = MC_TEMP.MASTER_ENTITY_LIST[0];

                        if (MC_TEMP.ITEMS_ENTITY_LIST != null)
                        {
                            if (MC_TEMP.ITEMS_ENTITY_LIST.Count > 0)
                            {
                                ItemsEntity.Clear();
                                ItemsEntity = MC_TEMP.ITEMS_ENTITY_LIST;
                            }
                            else
                            {
                                ItemsEntity = new ObservableCollection<MM_T001_A>();
                            }
                        }
                        if (MC_TEMP.BATCH_ENTITY_LIST != null)
                        {
                            if (MC_TEMP.BATCH_ENTITY_LIST.Count > 0)
                            {
                                BatchEntity.Clear();
                                BatchEntity = MC_TEMP.BATCH_ENTITY_LIST;
                            }
                            else
                            {
                                BatchEntity = new ObservableCollection<MM_T001_B>();
                            }
                        }
                        if (MC_TEMP.ATTACHMENT_LIST != null)
                        {
                            if (MC_TEMP.ATTACHMENT_LIST.Count > 0)
                            {
                                MC.ATTACHMENT_LIST.Clear();
                                MC.ATTACHMENT_LIST = MC_TEMP.ATTACHMENT_LIST;
                            }
                            else
                            {
                                MC.ATTACHMENT_LIST = new List<COM_T003>();
                            }
                        }
                    }
                }

                NewRecord = false;
                MasterEntity.ts_code = ts_code_vm;
                MainTabIndex = 0;
                EntityChangeEnable = false;
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        // below 4 methods are for Parameters and Parameter Values
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {

                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ItemsEntity[dgSelectedIndexItem].id == 0)
                {
                    for (int j = BatchEntity.Count - 1; j >= 0; j--)
                    {
                        if (ItemsEntity[i].ItemCode == BatchEntity[j].ItemCode && ItemsEntity[i].sku == BatchEntity[j].sku)
                        {
                            BatchEntity.Remove(BatchEntity[j]);
                        }
                    }
                    ItemsEntity.RemoveAt(i);
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void DeleteDataGridRow_ItemBatch(object InputValue)
        {
            if (BATCH_ENTITY_OBJ != null && BatchEntity != null)
            {
                int i = (int)InputValue;
                if (BatchEntity.Count > i && BATCH_ENTITY_OBJ.id == 0)
                {
                    BatchEntity.RemoveAt(i);
                }
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
                DefaultValues();
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
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
        private void ExecuteReference(object para)
        {
            if (!string.IsNullOrWhiteSpace(REQ_PARA_OBJ.doc_no))
            {
                //string Request = "EXEC_REF_DOC" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.order_doc_no + "!@" + MasterEntity.bom_no + "!@" + MasterEntity.qty.ToString() + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId;
                string Request = "EXEC_REF_DOC" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + REQ_PARA_OBJ.doc_no + "!@" + REQ_PARA_OBJ.doc_cat + "!@" + REQ_PARA_OBJ.doc_type + "!@" + MasterEntity.bom_no + "!@" + MasterEntity.qty.ToString() + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm;
                MC_TEMP = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<MC_MM_T001>(MC_TEMP, Request, "MM_T001_BL", "MM", "LoadAll", 0, "");
                if (MC_TEMP.MASTER_ENTITY_LIST.Count > 0)
                {
                    MasterEntity = MC_TEMP.MASTER_ENTITY_LIST[0];
                    ItemsEntity = MC_TEMP.ITEMS_ENTITY_LIST;//NOTE: if loading batch Table data then add Item Line id to the batch record in SQL Query.
                    MasterEntity.ts_code = ts_code_vm;
                }
            }
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            //if (!string.IsNullOrWhiteSpace(MasterEntity.order_doc_no) && !string.IsNullOrWhiteSpace(MasterEntity.bom_no) && MasterEntity.qty.HasValue)
            //{
            //    string Request = "EXEC_REF_DOC" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.order_doc_no + "!@" + MasterEntity.bom_no + "!@" + MasterEntity.qty.ToString() + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId;
            //    MC_TEMP = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<MC_MM_T001>(MC_TEMP, Request, "MM_T001_STD", "SCM", "LoadAll", 0, "");
            //    MasterEntity = MC_TEMP.MASTER_ENTITY_LIST[0];
            //    ItemsEntity = MC_TEMP.ITEMS_ENTITY_LIST;//NOTE: if loading batch Table data then add Item Line id to the batch record in SQL Query.
            //    MasterEntity.ts_code = ts_code_vm;
            //}
        }
        private void DefaultValues()
        {
            EntityChangeEnable = true;
            MasterEntity.doc_cat = doc_cat_vm;
            MasterEntity.doc_code = doc_cat_vm;
            MasterEntity.doc_type = doc_cat_vm;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.active = true;
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.post_date = DateTime.Now;
            MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
            MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();
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
        private bool Validation()
        {
            //NOTE: Batch Validation : qty should not exceed of Batch and also total batches qty not exceed then items qty.
            //NOTE: do not allow seperate comp_code and Location in MasterEntity and all child entities as per doc_cat. or add all columns in all child.
            if (string.IsNullOrWhiteSpace(MasterEntity.comp_code))//when form is blank and we save the record
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Company........"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.location_Id))//when form is blank and we save the record
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Plant/Location........"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.mov_tp))//when form is blank and we save the record
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Movement Type........"); sms.ShowMessage();
                return false;
            }
            if (ItemsEntity.Count < 1)//when form is blank and we save the record
            {
                sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Insert Item........");sms.ShowMessage();
                return false;
            }
            else if (MasterEntity.mov_tp == "" || MasterEntity.mov_tp == null)//when form is blank and we save the record
            {
                sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Select Movement Type");sms.ShowMessage();
                return false;
            }
            else
            {
                if (MasterEntity.mov_tp == "114")
                {
                    if (MasterEntity.order_doc_no == null || MasterEntity.order_doc_no == "")
                    {
                        sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Please Select Order No");sms.ShowMessage();
                        return false;
                    }
                }
                // Validation for Quantity Item Duplication and Unit Code For Item Details
                foreach (var o in ItemsEntity)
                {
                    if (o.ItemCode != null && o.ItemCode != "" && o.description != null)
                    {
                        int flag = 0; //duplicate entry is allowed so commented : pending delete
                        if (o.id == 0)
                        {
                            foreach (var p in ItemsEntity)
                            {
                                if (o.ItemCode == p.ItemCode && o.sku == p.sku && o.machine_id == p.machine_id)
                                {
                                    flag++;
                                }
                            }
                            if (flag > 1)
                            {
                                sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1} and machine {2}", o.ItemCode, o.sku_desc, o.machinecode);sms.ShowMessage();
                                return false;
                            }
                        }
                        #region . Parameter Validation .
                        // Validation For All Parameter Values Selected or Not
                        //if (o.StockUnt == true && o.id == 0)
                        //{
                        //    var paralist = (from p in MC.PARAMETERS_LIST where p.SubCatCode == o.SubCatCode select p).ToList();
                        //    if (paralist.Count > 0)
                        //    {
                        //        string[] SkuList = new string[100];           //string array
                        //        List<string> SkuListt = new List<string>();    // stringlist

                        //        if (o.sku != null && o.sku != "")
                        //        {
                        //            SkuList = o.sku.Split('/');
                        //            SkuListt = SkuList.ToList();

                        //            foreach (var item in SkuList)
                        //            {
                        //                if (item == "")
                        //                {
                        //                    sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Parameter Validation";sms.Text = String.Format("All Parameters of item {0} of index {1} are not selected..!!! \n Check Parameter at index {2} is selected or not. \n ", o.ItemCode, ItemsEntity.IndexOf(o), SkuList.ToList().IndexOf(item));sms.ShowMessage();
                        //                    return false;
                        //                }
                        //            }
                        //        }
                        //        else
                        //        {
                        //            sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Parameter Validation";sms.Text = String.Format("All Parameters of item {0} of index {1} are not selected\n If you can see All Parameter Value Selected Please Select the Same Values Again ", o.ItemCode, ItemsEntity.IndexOf(o));sms.ShowMessage();
                        //            return false;
                        //        }
                        //    }
                        //}
                        #endregion

                        if (string.IsNullOrWhiteSpace(o.mov_tp))
                        {
                            sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Movement Type cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);sms.ShowMessage();
                            return false;
                        }
                        if (string.IsNullOrWhiteSpace(o.debcr_ind) || (o.debcr_ind != "D" && o.debcr_ind != "C" && o.debcr_ind != "N"))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Debit/Credit Indicator cannot be null or invalid for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc); sms.ShowMessage();
                            return false;
                        }
                        if (o.qty == null || o.qty == 0 || o.qty.HasValue == false)
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc); sms.ShowMessage();
                            return false;
                        }
                        if (string.IsNullOrWhiteSpace(o.unit_code))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc); sms.ShowMessage();
                            return false;
                        }
                        if (string.IsNullOrWhiteSpace(o.location_Id))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Enter Valid Location/Plant code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc); sms.ShowMessage();
                            return false;
                        }
                        if (string.IsNullOrWhiteSpace(o.comp_code))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Enter Valid Company code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc); sms.ShowMessage();
                            return false;
                        }
                        if (string.IsNullOrWhiteSpace(o.store_code))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Store code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc); sms.ShowMessage();
                            return false;
                        }
                       
                        if (MC.BATCH_LIST != null && MC.BATCH_LIST.Count > 0)
                        {
                            var BatchDataItem = MC.BATCH_LIST.Where(x => x.ItemCode == o.ItemCode && x.location_id == o.location_Id && x.client == o.client && x.store_code == o.store_code).ToList();
                            var BatchDataTab = BatchEntity.Where(x => x.ItemCode == o.ItemCode && x.location_Id == o.location_Id && x.client == o.client && x.store_code == o.store_code && string.IsNullOrWhiteSpace(x.batch_no) == false).ToList();
                            if (BatchDataItem.Count > 0 && BatchDataTab.Count == 0)
                            {
                                sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Invalid or Empty Batch Number");sms.ShowMessage();
                                return false;
                            }
                        }
                    }
                    else
                    {
                        sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("please select Item ........");sms.ShowMessage();
                        return false;
                    }
                }
                //Validation for Entered Batch Quantity More than Stock Quantity
                for (int a = 0; a < BatchEntity.Count; a++)
                {
                    for (int b = 0; b < MC.BATCH_LIST.Count; b++)
                    {
                        if (BatchEntity[a].batch_no == MC.BATCH_LIST[b].batch_no && BatchEntity[a].ItemCode == MC.BATCH_LIST[b].ItemCode)
                        {
                            if (BatchEntity[a].rec_qty > MC.BATCH_LIST[b].stock_total)
                            {
                                sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Batch {0} Quantity {1} Exceeds Batch Capacity/RemainingCapacity {2} ", BatchEntity[a].batch_no, BatchEntity[a].rec_qty, MC.BATCH_LIST[b].stock_total);sms.ShowMessage();
                                return false;
                            }
                        }
                    }
                }
                //Validation For Item Quantity Equal To Sum of Quantities of All Batches Of the Item 
                for (int i = 0; i < ItemsEntity.Count; i++)
                {
                    decimal temp = 0;
                    int flag = 0;
                    for (int j = 0; j < BatchEntity.Count; j++)
                    {
                        if (ItemsEntity[i].line_id == BatchEntity[j].sr_line_no)
                        {
                            temp = temp + Convert.ToDecimal(BatchEntity[j].qty);
                            flag = 1;
                        }
                    }
                    if (ItemsEntity[i].qty != temp && flag == 1)
                    {
                        sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Item Quantity is Not Equal to Sum of All Item Batches Quantities for Item {0} sku :{1} ", ItemsEntity[i].ItemCode, ItemsEntity[i].sku_desc);sms.ShowMessage();
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion
        #region Filters
        private string _FLTR_STR_REF_DOC;
        public string FLTR_STR_REF_DOC
        {
            get { return _FLTR_STR_REF_DOC; }
            set
            {
                _FLTR_STR_REF_DOC = value;
                RaisePropertyChanged("FLTR_STR_REF_DOC");
                FLTR_COLL_REF_DOC();
            }
        }

        private void FLTR_COLL_REF_DOC()
        {
            if (REF_DOC_COLLECTION != null)
            {
                REF_DOC_COLLECTION.Refresh();
            }
        }
        public bool FLTR_REF_DOC(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FLTR_STR_REF_DOC))
                {
                    return (data.ref_doc_no != null && data.ref_doc_no.ToLower().Contains(FLTR_STR_REF_DOC.ToLower()) ||
                           data.ref_doc_date != null && data.ref_doc_date.ToString().ToLower().Contains(FLTR_STR_REF_DOC.ToLower()) ||
                           data.party_code != null && data.party_code.ToLower().Contains(FLTR_STR_REF_DOC.ToLower()) ||
                           data.party_name != null && data.party_name.ToLower().Contains(FLTR_STR_REF_DOC.ToLower()) ||
                           data.ref_doc_cat != null && data.ref_doc_cat.ToLower().Contains(FLTR_STR_REF_DOC.ToLower()) ||
                           data.party_ref_no != null && data.party_ref_no.ToLower().Contains(FLTR_STR_REF_DOC.ToLower()) ||
                           data.emp_name != null && data.emp_name.ToLower().Contains(FLTR_STR_REF_DOC.ToLower())
                       );
                }
                return true;
            }
            return false;
        }


        private string _FLTR_STR_BACKFLIP;
        public string FLTR_STR_BACKFLIP
        {
            get { return _FLTR_STR_BACKFLIP; }
            set
            {
                _FLTR_STR_BACKFLIP = value;
                RaisePropertyChanged("FLTR_STR_BACKFLIP");
                FLTR_COLL_BACKFLIP();
            }
        }
        private void FLTR_COLL_BACKFLIP()
        {
            if (BACKFLIP_COLLECTION != null)
            {
                BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool FLTR_BACKFLIP(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FLTR_STR_REF_DOC))
                {
                    return (data.doc_no != null && data.doc_no.ToLower().Contains(FLTR_STR_REF_DOC.ToLower()) ||
                           data.doc_date != null && data.doc_date.ToString().ToLower().Contains(FLTR_STR_REF_DOC.ToLower()) ||
                           data.party_code != null && data.party_code.ToLower().Contains(FLTR_STR_REF_DOC.ToLower()) ||
                           data.party_name != null && data.party_name.ToLower().Contains(FLTR_STR_REF_DOC.ToLower()) ||
                           data.doc_cat != null && data.ref_doc_cat.ToLower().Contains(FLTR_STR_REF_DOC.ToLower()) ||
                           data.mov_tp != null && data.mov_tp.ToLower().Contains(FLTR_STR_REF_DOC.ToLower()) ||
                           data.mov_tp_name != null && data.mov_tp_name.ToLower().Contains(FLTR_STR_REF_DOC.ToLower()) ||
                           data.location_id != null && data.location_id.ToLower().Contains(FLTR_STR_REF_DOC.ToLower()) ||
                           data.comp_code != null && data.comp_code.ToLower().Contains(FLTR_STR_REF_DOC.ToLower()) ||
                           data.post_date != null && data.post_date.ToString().ToLower().Contains(FLTR_STR_REF_DOC.ToLower()) ||
                           data.emp_name != null && data.emp_name.ToLower().Contains(FLTR_STR_REF_DOC.ToLower())
                       );
                }
                return true;
            }
            return false;
        }




        #endregion

        #region · Command Actions ·


        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", AppSessionState.Name);
            }
            catch (Exception ex)
            { }
            return result;
        }
        // Make This function for Item lelev check and remove.

        #endregion
        private void RemoveReferenceDocuments()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(MasterEntity.ref_doc) == false && MC.REF_DOC_LIST != null)
                {
                    if (MC.REF_DOC_LIST.Count > 0)
                    {
                        MC.REF_DOC_LIST.Remove(MC.REF_DOC_LIST.Single(s => s.ref_doc_no == MasterEntity.ref_doc));
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }

        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            MasterEntity.ts_code = ts_code_vm;
            if (MasterEntity.XmlDataDocument_MM_T001_A != null)
            {
                MC.ITEMS_ENTITY_LIST = (ObservableCollection<MM_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_MM_T001_A, ItemsEntity);
                ItemsEntity.Clear();
                ItemsEntity = MC.ITEMS_ENTITY_LIST;
            }
            else
            {
                MC.ITEMS_ENTITY_LIST = new ObservableCollection<MM_T001_A>();
            }
            if (MasterEntity.XmlDataDocument_MM_T001_B != null)
            {
                MC.BATCH_ENTITY_LIST = (ObservableCollection<MM_T001_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_MM_T001_B, BatchEntity);
                BatchEntity.Clear();
                BatchEntity = MC.BATCH_ENTITY_LIST; // NOTE: add se_line_no with item Line id if required. it was done in old VM
            }
            else
            {
                MC.BATCH_ENTITY_LIST = new ObservableCollection<MM_T001_B>();
            }
            if (MasterEntity.XML_DOC_ATTACHMENT != null)
            {
                MC.ATTACHMENT_LIST = (List<COM_T003>)new ObjectSerializationService().XMLToObject(MasterEntity.XML_DOC_ATTACHMENT, MC.ATTACHMENT_LIST);
            }
            if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.BACK_FLIP_LIST = (List<STD_LIST_BE>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.BACK_FLIP_LIST);
            }
        }

        #region Abstract Commands

        protected override void OnSaveAction(InquiryActionResult<MM_T001> result)
        {
            try
            {
                CursorControl.SetBusyState();
                MasterEntity.XmlDataDocument_MM_T001_A = SERIALIZATION_OBJ.ObjectToXML(ItemsEntity);
                MasterEntity.XmlDataDocument_MM_T001_B = SERIALIZATION_OBJ.ObjectToXML(BatchEntity);
                Logging();
                this.MasterEntity.EndEdit();
                
                if (Validation() == true)
                {
                    if (NewRecord == true)
                    {
                        MasterEntity = REPOSITORY_OBJ.SaveWithReturnDomainObject<MM_T001>(MasterEntity, "MM_T001_BL_NEW", "MM");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = REPOSITORY_OBJ.UpdateWithReturnDomainObject<MM_T001>(MasterEntity, "MM_T001_BL_NEW", "MM");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    NewRecord = false;
                    RemoveReferenceDocuments();
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        protected override void OnCreateAction(InquiryActionResult<MM_T001> result)
        {
            NewRecord = true;
            MasterEntity = new MM_T001();
            ItemsEntity = new ObservableCollection<MM_T001_A>();
            BatchEntity = new ObservableCollection<MM_T001_B>();
            ITEM_ENTITY_OBJ = new MM_T001_A();
            BATCH_ENTITY_OBJ = new MM_T001_B();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<MM_T001> result)
        {
            sms.ButtonSetup = DialogButton.Ok;
            sms.Caption = "Delete Changes";
            sms.Text = String.Format("This record will delete forever '{0}'", this.Title);

            if (sms.ShowMessage() == DialogResult.Ok)
            {
                this.MasterEntity.CancelEdit();
                string response = REPOSITORY_OBJ.Delete(MasterEntity.doc_no, "MM_T001_BL_NEW", "MM");
                MasterEntity = new MM_T001();
                ItemsEntity = new ObservableCollection<MM_T001_A>();
                BatchEntity = new ObservableCollection<MM_T001_B>();
                NewRecord = true;
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<MM_T001> result)
        {
            MasterEntity.CancelEdit();
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
            try
            {
                string Request = "MaterialIssue" + "!@" + MasterEntity.doc_no;
                MC_TEMP = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<MC_MM_T001>(MC_TEMP, Request, "MM_T001_BL_NEW", "MM", Request, 0, "");

                object[] objDataSource = new object[5];
                string[] objDataSourceName = new string[5];

                objDataSource[0] = MC_TEMP.MASTER_ENTITY_LIST;
                objDataSource[1] = MC_TEMP.ITEMS_ENTITY_LIST;
                objDataSource[2] = MC_TEMP.BATCH_ENTITY_LIST;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[3] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[4] = Result;

                objDataSourceName[0] = "dsDocumentMaster";
                objDataSourceName[1] = "dsGoodsA";
                objDataSourceName[2] = "dsItemBatchDetails";
                objDataSourceName[3] = "dsCompany";
                objDataSourceName[4] = "dsLocation";

                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\SCM\\MaterialIssue.rdlc", getParametersList(), "");
            }
            catch (Exception ex) { }
        }
        protected override void OnDocumentAction()
        {
        }
        protected override void OnRefreshCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
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
       
    }
}



// Use same function od load inital data to call from change of company and location.
// DO not allow mov type to change after save. xaml have MoveFlag binding;