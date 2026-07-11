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
using Reflection.BusinessEntity.PPC;
using Reflection.Presentation.Common;
using System.Threading.Tasks;

namespace Reflection.Modules.MM.ViewModels
{
    public class MM_T013_VM : WorkspaceViewModel<MM_T005>
    {

        #region Variable Declaration

        bool NewRecord = true;
        WebServiceRepository<MM_T005> REPOSITORY_OBJ = new WebServiceRepository<MM_T005>();
        WebServiceRepository<MC_MM_T005> REPOSITORY_OBJ_TEMP = new WebServiceRepository<MC_MM_T005>();
        MC_MM_T005 MC_TEMP = new MC_MM_T005();
        MC_MM_T005 MC = new MC_MM_T005();
        ObjectSerializationService SERIALIZATION_OBJ = new ObjectSerializationService();
        IShowMessageViewService sms;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }


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

        private MM_T005 _MasterEntity;
        public MM_T005 MasterEntity
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
        private ObservableCollection<MM_T005_A> _ItemsEntity;
        public ObservableCollection<MM_T005_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                    _ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }
        private ObservableCollection<MM_T005_B> _BatchEntity;
        public ObservableCollection<MM_T005_B> BatchEntity
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

        private STD_LIST_BE _REF_DOC_OBJ;
        public STD_LIST_BE REF_DOC_OBJ
        {
            get
            {
                return _REF_DOC_OBJ;
            }
            set
            {
                if (_REF_DOC_OBJ != value)
                {
                    _REF_DOC_OBJ = value;
                    RaisePropertyChanged(nameof(REF_DOC_OBJ));
                }
            }
        }


        private MM_T005_A _ITEM_ENTITY_OBJ;
        public MM_T005_A ITEM_ENTITY_OBJ
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
        private MM_T005_B _BATCH_ENTITY_OBJ;
        public MM_T005_B BATCH_ENTITY_OBJ
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

        #region Autosuggest Initialization

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(MM_T013_VM));
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
                    else if (SourceName == "batch_no")
                    { AS_DEFAULT = AS_BATCH; }
                    else if (SourceName == "store_code")
                    { AS_DEFAULT = AS_STORE; }
                    else if (SourceName == "location_id")
                    { AS_DEFAULT = AS_LOCATION_ITEM; }
                    else if (SourceName == "mov_tp")
                    { AS_DEFAULT = AS_MOV_TYPE; }
                    else if (SourceName == "op_no")
                    { AS_DEFAULT = AS_OPERATIONS; }
                    else if (SourceName == "curr_code")
                    { AS_DEFAULT = AS_CURRENCY; }
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
                    else if (SourceName == "location_id")
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
        private AutoSuggestTextViewModel<dynamic> _AS_CUSTOMER { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CUSTOMER
        {
            get { return _AS_CUSTOMER; }
            set
            {
                if (_AS_CUSTOMER != value)
                {
                    _AS_CUSTOMER = value; RaisePropertyChanged("AS_CUSTOMER");
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
        private AutoSuggestTextViewModel<dynamic> _AS_RES_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_RES_TYPE
        {
            get { return _AS_RES_TYPE; }
            set
            {
                if (_AS_RES_TYPE != value)
                {
                    _AS_RES_TYPE = value; RaisePropertyChanged("AS_RES_TYPE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ORIGIN { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ORIGIN
        {
            get { return _AS_ORIGIN; }
            set
            {
                if (_AS_ORIGIN != value)
                {
                    _AS_ORIGIN = value; RaisePropertyChanged("AS_ORIGIN");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_CURRENCY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CURRENCY
        {
            get { return _AS_CURRENCY; }
            set
            {
                if (_AS_CURRENCY != value)
                {
                    _AS_CURRENCY = value; RaisePropertyChanged("AS_CURRENCY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_OPERATIONS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_OPERATIONS
        {
            get { return _AS_OPERATIONS; }
            set
            {
                if (_AS_OPERATIONS != value)
                {
                    _AS_OPERATIONS = value; RaisePropertyChanged("AS_OPERATIONS");
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

        #endregion

        #region RelayCommand

        public RelayCommand<object> cmdSelectionChanged_MM_T005 { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_MM_T005_A { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_MM_T005_B { get; private set; }
        public RelayCommand<object> cmdInsertStoreCode { get; private set; }
        //public RelayCommand<object> cmdInsertCompany { get; private set; }
        //public RelayCommand<object> cmdInsertLocation { get; private set; }
        //public RelayCommand<object> cmdInsertLocationItem { get; private set; }
        public RelayCommand<object> cmdInsertMovementType { get; private set; }
        public RelayCommand<object> cmdInsertMovementTypeItem { get; private set; }
        public RelayCommand<object> cmdInsertMaterial { get; private set; }
        public RelayCommand<object> cmdInsertUnit { get; private set; }
        public RelayCommand<object> cmdDataGridRowDelete { get; private set; }
        public RelayCommand<object> cmdDataGridRowDeleteBatch { get; private set; }
        public RelayCommand<object> cmdSelectionChangedItem { get; private set; }
        public RelayCommand<object> cmdInsertBatch { get; private set; }
        public RelayCommand<object> cmdLoadBackFlipData { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdSelectReference { get; private set; }
        public RelayCommand<object> cmdExecuteReference { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdInsertOrder { get; private set; }
        public RelayCommand<object> cmdInsertStatus { get; private set; }

        #endregion

        #region . Constructor .
        public MM_T013_VM(string ts_code, string doc_cat)
            : base()
        {
            sms = GetViewService<IShowMessageViewService>();
            ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            MasterEntity = new MM_T005();
            ItemsEntity = new ObservableCollection<MM_T005_A>();
            BatchEntity = new ObservableCollection<MM_T005_B>();
            ITEM_ENTITY_OBJ = new MM_T005_A();
            BATCH_ENTITY_OBJ = new MM_T005_B();
            MM_T005.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Master);
            MM_T005_A.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Item);
            MM_T005_B.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Batch);
            MC_TEMP = new MC_MM_T005();
            MC = new MC_MM_T005();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            BatchEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
            CommandInitialisation();

            REQUEST_PARA.from_date = DateTime.Now;
            REQUEST_PARA.to_date = DateTime.Now;
            REQUEST_PARA.active_code = "1";

        }
        public MM_T013_VM(string ts_code, string doc_cat, string doc_no)
            : base()
        {
            ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            doc_no_vm = doc_no;
            sms = GetViewService<IShowMessageViewService>();
            ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            MasterEntity = new MM_T005();
            ItemsEntity = new ObservableCollection<MM_T005_A>();
            BatchEntity = new ObservableCollection<MM_T005_B>();
            ITEM_ENTITY_OBJ = new MM_T005_A();
            BATCH_ENTITY_OBJ = new MM_T005_B();
            MM_T005.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Master);
            MM_T005_A.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Item);
            MC_TEMP = new MC_MM_T005();
            MC = new MC_MM_T005();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            BatchEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
            CommandInitialisation();
            

        }
        public MM_T013_VM(string ts_code, string doc_cat, STD_LIST_BE REF_DOC)
            : base()
        {
            ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            REF_DOC_OBJ = REF_DOC;
            sms = GetViewService<IShowMessageViewService>();
            ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            MasterEntity = new MM_T005();
            ItemsEntity = new ObservableCollection<MM_T005_A>();
            BatchEntity = new ObservableCollection<MM_T005_B>();
            ITEM_ENTITY_OBJ = new MM_T005_A();
            BATCH_ENTITY_OBJ = new MM_T005_B();
            MM_T005.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Master);
            MM_T005_A.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Item);
            MC_TEMP = new MC_MM_T005();
            MC = new MC_MM_T005();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            BatchEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
            CommandInitialisation();
            
            //LoadDocumentFromReference(REF_DOC_OBJ);

        }

        #endregion

        #region Command Functions

        private void SelectionChangedItem(object InputValue)
        {
            try
            {
                if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<MM_T005_A>().ToList().Count > 0)
                    {
                        ITEM_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<MM_T005_A>().ToList()[0];
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
                            POPUP_ENTITY_OBJ = MC.BATCH_LIST.Where(x => x.batch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.item_code.Equals(ITEM_ENTITY_OBJ.item_code) == true && (x.sku ?? "").Equals((ITEM_ENTITY_OBJ.sku ?? "")) == true).ToList()[0];
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

                if (POPUP_ENTITY_OBJ != null && ITEM_ENTITY_OBJ != null && !string.IsNullOrWhiteSpace(ITEM_ENTITY_OBJ.item_code))
                {
                    ITEM_ENTITY_OBJ.batch_no = POPUP_ENTITY_OBJ.batch_no;
                    BATCH_ENTITY_OBJ.item_code = POPUP_ENTITY_OBJ.item_code;
                    BATCH_ENTITY_OBJ.store_code = POPUP_ENTITY_OBJ.store_code;
                    BATCH_ENTITY_OBJ.unit_code = ITEM_ENTITY_OBJ.unit_code;
                    BATCH_ENTITY_OBJ.item_line_id = ITEM_ENTITY_OBJ.line_id;
                    BATCH_ENTITY_OBJ.item_line_id = ITEM_ENTITY_OBJ.id;
                    if (!BATCH_ENTITY_OBJ.qty.HasValue || BATCH_ENTITY_OBJ.qty == 0)
                    {
                        BATCH_ENTITY_OBJ.qty = (ITEM_ENTITY_OBJ.qty >= POPUP_ENTITY_OBJ.qty) ? POPUP_ENTITY_OBJ.qty : ITEM_ENTITY_OBJ.qty;
                    }
                    BATCH_ENTITY_OBJ.comp_code = BATCH_ENTITY_OBJ.comp_code;
                    BATCH_ENTITY_OBJ.location_id = BATCH_ENTITY_OBJ.location_id;
                    BATCH_ENTITY_OBJ.userid = AppSessionState.UserID;
                    BATCH_ENTITY_OBJ.sku = BATCH_ENTITY_OBJ.sku;
                    BATCH_ENTITY_OBJ.t_status = BATCH_ENTITY_OBJ.t_status;
                    BATCH_ENTITY_OBJ.active = "1";
                    BATCH_ENTITY_OBJ.client = AppSessionState.client;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }

        }
        private void LoadBackFlipData(object para)
        {
            CursorControl.SetBusyState();
            string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + REQUEST_PARA.comp_code + "!@" + REQUEST_PARA.location_id + "!@" + doc_cat_vm + "!@" + (REQUEST_PARA.doc_type ?? doc_cat_vm) + "!@" + (REQUEST_PARA.active_code ?? "1").ToString() + "!@" + Convert.ToDateTime(REQUEST_PARA.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQUEST_PARA.to_date).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID;
            MC_TEMP = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<MM_T005>(MC_TEMP, Request, "MM_T005_BL", "MM", "", 0, "");

            BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC_TEMP.BACK_FLIP_LIST);
            BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);
            //BACKFLIP_COLLECTION.Refresh();
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
                    MasterEntity.mov_type_name = POPUP_ENTITY_OBJ.mov_tp_name;
                    //MasterEntity.posting_key = POPUP_ENTITY_OBJ.post_key_ref;

                    if (MasterEntity.mov_tp == "114")
                    {
                        var ORDER_LIST_OBJ = (from o in MC.ORDER_LIST where o.doc_cat == "SO" select o).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).order_no);
                        TheFilter = (o, prefix) => ((STD_LIST_BE)o).order_no.ToLower().Contains(prefix.ToLower()) || ((STD_LIST_BE)o).item_code.ToLower().Contains(prefix.ToLower());
                        AS_ORDERS = new AutoSuggestTextViewModel<dynamic>(ORDER_LIST_OBJ, TheFilter, SuggestedValue, "order_doc_no", "order_no", true);
                        AS_ORDERS.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                    else if (MasterEntity.mov_tp == "104")
                    {
                        var ORDER_LIST_OBJ = (from o in MC.ORDER_LIST where o.doc_cat == "PJ" select o).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).order_no);
                        TheFilter = (o, prefix) => ((STD_LIST_BE)o).order_no.ToLower().Contains(prefix.ToLower()) || ((STD_LIST_BE)o).item_code.ToLower().Contains(prefix.ToLower());
                        AS_ORDERS = new AutoSuggestTextViewModel<dynamic>(ORDER_LIST_OBJ, TheFilter, SuggestedValue, "order_doc_no", "order_no", true);
                        AS_ORDERS.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                    else if (MasterEntity.mov_tp == "103")
                    {
                        var ORDER_LIST_OBJ = (from o in MC.ORDER_LIST where (o.doc_cat == "OR" || o.doc_cat == "OR") select o).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).order_no);
                        TheFilter = (o, prefix) => ((STD_LIST_BE)o).order_no.ToLower().Contains(prefix.ToLower()) || ((STD_LIST_BE)o).item_code.ToLower().Contains(prefix.ToLower());
                        AS_ORDERS = new AutoSuggestTextViewModel<dynamic>(ORDER_LIST_OBJ, TheFilter, SuggestedValue, "order_doc_no", "order_no", true);
                        AS_ORDERS.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }

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
                    ITEM_ENTITY_OBJ.ind_dc = POPUP_ENTITY_OBJ.debit_credit;
                    //ITEM_ENTITY_OBJ.posting_key = POPUP_ENTITY_OBJ.post_key_ref;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }

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
                    MasterEntity.order_no = POPUP_ENTITY_OBJ.order_no;
                    MasterEntity.order_item_row_id = POPUP_ENTITY_OBJ.order_item_row_id;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        //private void InsertCompany(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M0002 POPUP_ENTITY_OBJ = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUP_ENTITY_OBJ = MC.COMPANY_LIST.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null)
        //            {
        //                POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<ADM_M0002>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }

        //        #endregion
        //        if (POPUP_ENTITY_OBJ != null)
        //        {
                    

        //            List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == MasterEntity.comp_code).ToList();
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
        //            TheFilter = (o, prefix) => ((ADM_M0003)o).location_id.ToLower().Contains(prefix.ToLower()) || ((ADM_M0003)o).location_name.ToLower().Contains(prefix.ToLower());
        //            AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", true);
        //            AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = false; AS_LOCATION.AutoSuggestVM.IsFreeTextAllowed = false;
        //            if (LOC_LIST_OBJ.Count == 1)
        //            {
        //                MasterEntity.location_id = LOC_LIST_OBJ[0].location_id;

        //                List<MM_M0001> STORE_LIST_OBJ = MC.STORE_LIST.Where(x => x.comp_code == ITEM_ENTITY_OBJ.comp_code && x.location_id == ITEM_ENTITY_OBJ.location_id).ToList();
        //                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
        //                TheFilter = (o, prefix) => ((MM_M0001)o).store_code.ToLower().Contains(prefix.ToLower()) || ((MM_M0001)o).store_name.ToLower().Contains(prefix.ToLower());
        //                AS_STORE = new AutoSuggestTextViewModel<dynamic>(STORE_LIST_OBJ, TheFilter, SuggestedValue, "store_code", "store_code", true);
        //                AS_STORE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STORE.AutoSuggestVM.IsFreeTextAllowed = false;

        //                //NOTE: Also load Batch Data on change of SKU also.
        //                List<STD_ITEM> BATCH_LIST_OBJ = MC.BATCH_LIST.Where(x => x.item_code == ITEM_ENTITY_OBJ.item_code && (x.sku ?? "") == (ITEM_ENTITY_OBJ.sku ?? "") && x.store_code == ITEM_ENTITY_OBJ.store_code).ToList();
        //                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).batch_no);
        //                TheFilter = (o, prefix) => (((STD_ITEM)o).batch_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).batch_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //                AS_BATCH = new AutoSuggestTextViewModel<dynamic>(BATCH_LIST_OBJ, TheFilter, SuggestedValue, "batch_no", "batch_no", true);
        //                AS_BATCH.AutoSuggestVM.IsEmptyValueAllowed = true; AS_BATCH.AutoSuggestVM.IsFreeTextAllowed = true;

        //            }

        //            List<ADM_M0003> LOC_LIST_ITEM_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == MasterEntity.comp_code).ToList();
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
        //            TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //            AS_LOCATION_ITEM = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_ITEM_OBJ, TheFilter, SuggestedValue, "location_id", "location_id", true);
        //            AS_LOCATION_ITEM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_LOCATION_ITEM.AutoSuggestVM.IsFreeTextAllowed = false;
        //            if (LOC_LIST_ITEM_OBJ.Count == 1)
        //            {
        //                ITEM_ENTITY_OBJ.location_id = LOC_LIST_OBJ[0].location_id;

        //                List<MM_M0001> STORE_LIST_OBJ = MC.STORE_LIST.Where(x => x.comp_code == ITEM_ENTITY_OBJ.comp_code && x.location_id == ITEM_ENTITY_OBJ.location_id).ToList();
        //                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
        //                TheFilter = (o, prefix) => ((MM_M0001)o).store_code.ToLower().Contains(prefix.ToLower()) || ((MM_M0001)o).store_name.ToLower().Contains(prefix.ToLower());
        //                AS_STORE = new AutoSuggestTextViewModel<dynamic>(STORE_LIST_OBJ, TheFilter, SuggestedValue, "store_code", "store_code", true);
        //                AS_STORE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STORE.AutoSuggestVM.IsFreeTextAllowed = false;

        //                //NOTE: Also load Batch Data on change of SKU also.
        //                List<STD_ITEM> BATCH_LIST_OBJ = MC.BATCH_LIST.Where(x => x.item_code == ITEM_ENTITY_OBJ.item_code && (x.sku ?? "") == (ITEM_ENTITY_OBJ.sku ?? "") && x.store_code == ITEM_ENTITY_OBJ.store_code).ToList();
        //                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).batch_no);
        //                TheFilter = (o, prefix) => (((STD_ITEM)o).batch_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).batch_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //                AS_BATCH = new AutoSuggestTextViewModel<dynamic>(BATCH_LIST_OBJ, TheFilter, SuggestedValue, "batch_no", "batch_no", true);
        //                AS_BATCH.AutoSuggestVM.IsEmptyValueAllowed = true; AS_BATCH.AutoSuggestVM.IsFreeTextAllowed = true;

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        //}
        //private void InsertLocation(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M0003 POPUP_ENTITY_OBJ = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUP_ENTITY_OBJ = MC.LOCATION_LIST.Where(x => x.location_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.comp_code == MasterEntity.comp_code).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null)
        //            {
        //                POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<ADM_M0003>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }
        //        #endregion
        //        if (POPUP_ENTITY_OBJ != null)
        //        {
        //            MasterEntity.location_id = POPUP_ENTITY_OBJ.location_id;

        //            List<MM_M0001> STORE_LIST_OBJ = MC.STORE_LIST.Where(x => x.comp_code == MasterEntity.comp_code && x.location_id == MasterEntity.location_id).ToList();
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
        //            TheFilter = (o, prefix) => ((MM_M0001)o).store_code.ToLower().Contains(prefix.ToLower()) || ((MM_M0001)o).store_name.ToLower().Contains(prefix.ToLower());
        //            AS_STORE = new AutoSuggestTextViewModel<dynamic>(STORE_LIST_OBJ, TheFilter, SuggestedValue, "store_code", "store_code", true);
        //            AS_STORE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STORE.AutoSuggestVM.IsFreeTextAllowed = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        //}
        //private void InsertLocationItem(object InputValue)
        //{
        //    try
        //    {

        //        string Request = "";
        //        ADM_M0003 POPUP_ENTITY_OBJ = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUP_ENTITY_OBJ = MC.LOCATION_LIST.Where(x => x.location_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.comp_code == ITEM_ENTITY_OBJ.comp_code).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null)
        //            {
        //                POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<ADM_M0003>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }
        //        #endregion
        //        if (POPUP_ENTITY_OBJ != null)
        //        {
        //            ITEM_ENTITY_OBJ.location_id = POPUP_ENTITY_OBJ.location_id;

        //            List<MM_M0001> STORE_LIST_OBJ = MC.STORE_LIST.Where(x => x.comp_code == ITEM_ENTITY_OBJ.comp_code && x.location_id == ITEM_ENTITY_OBJ.location_id).ToList();
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
        //            TheFilter = (o, prefix) => ((MM_M0001)o).store_code.ToLower().Contains(prefix.ToLower()) || ((MM_M0001)o).store_name.ToLower().Contains(prefix.ToLower());
        //            AS_STORE = new AutoSuggestTextViewModel<dynamic>(STORE_LIST_OBJ, TheFilter, SuggestedValue, "store_code", "store_code", true);
        //            AS_STORE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STORE.AutoSuggestVM.IsFreeTextAllowed = false;

        //            //NOTE: Also load Batch Data on change of SKU also.
        //            List<STD_ITEM> BATCH_LIST_OBJ = MC.BATCH_LIST.Where(x => x.item_code == ITEM_ENTITY_OBJ.item_code && (x.sku ?? "") == (ITEM_ENTITY_OBJ.sku ?? "") && x.store_code == ITEM_ENTITY_OBJ.store_code).ToList();
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).batch_no);
        //            TheFilter = (o, prefix) => (((STD_ITEM)o).batch_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).batch_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //            AS_BATCH = new AutoSuggestTextViewModel<dynamic>(BATCH_LIST_OBJ, TheFilter, SuggestedValue, "batch_no", "batch_no", true);
        //            AS_BATCH.AutoSuggestVM.IsEmptyValueAllowed = true; AS_BATCH.AutoSuggestVM.IsFreeTextAllowed = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        //}
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
                            POPUP_ENTITY_OBJ = MC.STORE_LIST.Where(x => x.store_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.location_id == ITEM_ENTITY_OBJ.location_id && x.comp_code == ITEM_ENTITY_OBJ.comp_code).ToList()[0];
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
                    List<STD_ITEM> BATCH_LIST_OBJ = MC.BATCH_LIST.Where(x => x.item_code == ITEM_ENTITY_OBJ.item_code && (x.sku ?? "") == (ITEM_ENTITY_OBJ.sku ?? "") && x.store_code == ITEM_ENTITY_OBJ.store_code).ToList();
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
                    ITEM_ENTITY_OBJ.item_code = POPUP_ENTITY_OBJ.item_code;
                    ITEM_ENTITY_OBJ.bom_item_text = POPUP_ENTITY_OBJ.item_name;
                    ITEM_ENTITY_OBJ.unit_code = POPUP_ENTITY_OBJ.unit_code;
                    ITEM_ENTITY_OBJ.active = "1";
                    ITEM_ENTITY_OBJ.location_id = MasterEntity.location_id;
                    ITEM_ENTITY_OBJ.comp_code = MasterEntity.comp_code;
                    ITEM_ENTITY_OBJ.client = AppSessionState.client;
                    ITEM_ENTITY_OBJ.store_code = null; // store_location; // add as above
                    ITEM_ENTITY_OBJ.qty = POPUP_ENTITY_OBJ.qty;
                    ITEM_ENTITY_OBJ.order_no = MasterEntity.order_no;
                    ITEM_ENTITY_OBJ.ind_dc = (from o in MC.MOV_TYPE_LIST where o.mov_tp == MasterEntity.mov_tp select o.debit_credit).FirstOrDefault();
                    ITEM_ENTITY_OBJ.mov_tp = MasterEntity.mov_tp;
                    ITEM_ENTITY_OBJ.t_status = MasterEntity.t_status;
                    ITEM_ENTITY_OBJ.t_display = MasterEntity.t_display;
                    ITEM_ENTITY_OBJ.ind_dc = "D";
                    if (REF_DOC_OBJ != null)
                    {
                        ITEM_ENTITY_OBJ.plan_order_no = REF_DOC_OBJ.order_no;
                        ITEM_ENTITY_OBJ.order_no = REF_DOC_OBJ.order_no;
                        ITEM_ENTITY_OBJ.order_item_row_id = REF_DOC_OBJ.ref_row_id;
                        ITEM_ENTITY_OBJ.project_id = REF_DOC_OBJ.project_id;
                        ITEM_ENTITY_OBJ.element_id = REF_DOC_OBJ.element_id;
                        ITEM_ENTITY_OBJ.store_code = REF_DOC_OBJ.store_code;
                        ITEM_ENTITY_OBJ.bom_no = REF_DOC_OBJ.bom_no;
                        ITEM_ENTITY_OBJ.bom_item_row_id = REF_DOC_OBJ.bom_item_row_id;
                        ITEM_ENTITY_OBJ.op_no = REF_DOC_OBJ.op_no;
                        ITEM_ENTITY_OBJ.project_id = REF_DOC_OBJ.project_id;
                        ITEM_ENTITY_OBJ.element_id = REF_DOC_OBJ.element_id;
                        ITEM_ENTITY_OBJ.store_code = REF_DOC_OBJ.store_code;
                    }

                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertStatus(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0013 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.STATUS_LIST.Where(x => x.t_status.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0013>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.t_status = POPUPEntityObject.t_status;
                    MasterEntity.t_display = POPUPEntityObject.t_display;
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
                            MasterEntity.location_id = LOC_LIST_OBJ[0].location_id;
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
                        AS_LOCATION_ITEM = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", "location_id", true);
                        AS_LOCATION_ITEM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_LOCATION_ITEM.AutoSuggestVM.IsFreeTextAllowed = false;
                        if (LOC_LIST_OBJ.Count == 1)
                        {
                            ITEM_ENTITY_OBJ.location_id = LOC_LIST_OBJ[0].location_id;
                        }
                    }
                    if (sender.ToString() == "location_id") // AS_STORE & AS_WORK_CENTER as per comp_code & Location_id logic shift to InserLocation Function
                    {
                        List<MM_M0001> STORE_LIST_OBJ = MC.STORE_LIST.Where(x => x.comp_code == ITEM_ENTITY_OBJ.comp_code && x.location_id == ITEM_ENTITY_OBJ.location_id).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
                        TheFilter = (o, prefix) => ((MM_M0001)o).store_code.ToLower().Contains(prefix.ToLower()) || ((MM_M0001)o).store_name.ToLower().Contains(prefix.ToLower());
                        AS_STORE = new AutoSuggestTextViewModel<dynamic>(STORE_LIST_OBJ, TheFilter, SuggestedValue, "store_code", "store_code", true);
                        AS_STORE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STORE.AutoSuggestVM.IsFreeTextAllowed = false;

                       }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        void ModelChangeNotification_Batch(object sender, EventArgs e)
        { }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add) 
            {
                try
                {
                    foreach (MM_T005_A item in e.NewItems)
                    {
                        item.client = AppSessionState.client;
                        item.t_status = "01";
                        item.comp_code = MasterEntity.comp_code;
                        item.location_id = MasterEntity.location_id;
                        item.res_type = MasterEntity.res_type;
                        item.rec_type = MasterEntity.rec_type;
                        item.active = "1";
                        item.curr_code = AppSessionState.curr_code;
                        if (item.line_id == 0 || !item.line_id.HasValue)
                        {
                            item.line_id = ItemsEntity.Count;
                        }
                        item.mov_tp = MasterEntity.mov_tp;
                        item.plant = MasterEntity.location_id;
                        item.store_code = MasterEntity.store_code;

                        if (REF_DOC_OBJ != null)
                        {
                            if (!string.IsNullOrWhiteSpace(REF_DOC_OBJ.order_no))
                            {
                                item.order_no = REF_DOC_OBJ.order_no;
                                //item.bom_cat = REF_DOC_OBJ.bo;
                                item.bom_exp_no = REF_DOC_OBJ.bom_exp_no;
                                item.bom_no = REF_DOC_OBJ.bom_no;
                            }
                        }
                        if (MC.STORE_LIST != null && string.IsNullOrWhiteSpace(item.store_code))
                        {
                            if (MC.STORE_LIST.Count == 1)
                            {
                                item.store_code = MC.STORE_LIST[0].store_code;
                            }
                        }

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
        private void CollectionChangedNotifyForBatch(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && BatchEntity.Count > 0) // Batch can only enable to add if items exists in Items Entity.
            {
                try
                {
                    foreach (MM_T005_B item in e.NewItems)
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
            cmdLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });
            //cmdInsertCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            //cmdInsertLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocation(items); });
            //cmdInsertLocationItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocationItem(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdSelectReference = new RelayCommand<object>(items => { if (items == null) { return; } SelectReference(items); });
            cmdExecuteReference = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteReference(items); });
            cmdInsertStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertStatus(items); });
        }
        private void LoadInitialData()
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? doc_cat_vm) + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm;
                MC = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<MC_MM_T005>(MC, Request, "MM_T005_BL", "MM", Request, 0, "LOAD_INI");

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
                AS_ITEM = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "item_code", "item_code", true);
                AS_ITEM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ITEM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                TheFilter = (o, prefix) => ((ADM_M0002)o).comp_code.ToLower().Contains(prefix.ToLower()) || ((ADM_M0002)o).comp_name.ToLower().Contains(prefix.ToLower());
                AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", "comp_code", true);
                AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = false; AS_COMPANY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0004)x).mov_tp);
                TheFilter = (o, prefix) => ((MM_M0004)o).mov_tp.ToLower().Contains(prefix.ToLower()) || ((MM_M0004)o).mov_tp_name.ToLower().Contains(prefix.ToLower());
                AS_MOV_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.MOV_TYPE_LIST, TheFilter, SuggestedValue, "mov_tp", "mov_tp", true);
                AS_MOV_TYPE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_MOV_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

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

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037)x).curr_code);
                TheFilter = (o, prefix) => ((ADM_M037)o).curr_code.ToLower().Contains(prefix.ToLower()) || ((ADM_M037)o).curr_name.ToLower().Contains(prefix.ToLower());
                AS_CURRENCY = new AutoSuggestTextViewModel<dynamic>(MC.CURRENCY_LIST, TheFilter, SuggestedValue, "curr_code", true);
                AS_CURRENCY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_CURRENCY.AutoSuggestVM.IsFreeTextAllowed = true;


                List<ADM_M0003> LOC_LIST_OBJ = AppSessionState.LOCATION_LIST.Where(item => item.comp_code == AppSessionState.OBJ_COMPANY.comp_code).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                TheFilter = (o, prefix) => ((ADM_M0003)o).location_id.ToLower().Contains(prefix.ToLower()) || ((ADM_M0003)o).location_name.ToLower().Contains(prefix.ToLower());
                AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", true);
                AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = false; AS_LOCATION.AutoSuggestVM.IsFreeTextAllowed = false;

                List<MM_M0001> STORE_LIST_OBJ = MC.STORE_LIST.Where(x => x.comp_code == AppSessionState.OBJ_COMPANY.comp_code && x.location_id == AppSessionState.OBJ_LOCATION.location_id).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
                TheFilter = (o, prefix) => ((MM_M0001)o).store_code.ToLower().Contains(prefix.ToLower()) || ((MM_M0001)o).store_name.ToLower().Contains(prefix.ToLower());
                AS_STORE = new AutoSuggestTextViewModel<dynamic>(STORE_LIST_OBJ, TheFilter, SuggestedValue, "store_code", "store_code", true);
                AS_STORE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STORE.AutoSuggestVM.IsFreeTextAllowed = false;

                List<ADM_M0003> LOC_LIST_ITEM_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == AppSessionState.OBJ_COMPANY.comp_code).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_LOCATION_ITEM = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_ITEM_OBJ, TheFilter, SuggestedValue, "location_id", "location_id", true);
                AS_LOCATION_ITEM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_LOCATION_ITEM.AutoSuggestVM.IsFreeTextAllowed = false;
                
                


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
                    //DataGridView.Filter = adv => ((MM_T005_B)adv).sr_line_no.Equals(ItemsEntity[dgSelectedIndexItem].line_id);
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
                        Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + ParameterEntityObject.comp_code + "!@" + ParameterEntityObject.location_id + "!@" + ParameterEntityObject.doc_cat + "!@" + ParameterEntityObject.doc_type + "!@" + ParameterEntityObject.doc_no + "!@" + ParameterEntityObject.ref_doc_cat + "!@" + ParameterEntityObject.ref_doc_no;
                        MC_TEMP = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<MC_MM_T005>(MC_TEMP, Request, "MM_T005_BL", "MM", Request, 0, "LOAD_DOC_BY_DOC_NO");

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
                                ItemsEntity = new ObservableCollection<MM_T005_A>();
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
                                BatchEntity = new ObservableCollection<MM_T005_B>();
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
        /* Commenting because same can be done from regular method
        private void LoadDocumentFromReference(STD_LIST_BE ParameterObject)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "";
                if (ParameterObject != null)
                {
                    if (!string.IsNullOrWhiteSpace(ParameterObject.order_no))
                    {
                        Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + ParameterObject.comp_code + "!@" + ParameterObject.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + ParameterObject.order_no + "!@" + ParameterObject.ref_doc_cat + "!@" + ParameterObject.ref_doc_type;
                        MC_TEMP = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<MC_MM_T005>(MC_TEMP, Request, "MM_T005_BL", "MM", Request, 0, "LOAD_DOC_BY_REF_DOC_NO");
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
                                ItemsEntity = new ObservableCollection<MM_T005_A>();
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
                                BatchEntity = new ObservableCollection<MM_T005_B>();
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
        */
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {

                int i = (int)InputValue;
                if (ItemsEntity.Count > i && (ItemsEntity[dgSelectedIndexItem].id == 0 || ItemsEntity[dgSelectedIndexItem].id == null))
                {
                    for (int j = BatchEntity.Count - 1; j >= 0; j--)
                    {
                        if (ItemsEntity[i].id == BatchEntity[j].item_row_id && ItemsEntity[i].line_id == BatchEntity[j].item_line_id)
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
                else if (REF_DOC_OBJ != null)
                {
                    List<STD_LIST_BE> STD_LIST_OBJ = new List<STD_LIST_BE>();
                    STD_LIST_OBJ.Add(REF_DOC_OBJ);
                    LoadDocumentByDocumentNumber(STD_LIST_OBJ, "DocumentNo");
                }
                MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
                MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                LoadInitialData();
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
        private void SelectReference(object para)
        {
            if (MC.REF_DOC_LIST != null)
            {
                foreach(STD_LIST_BE item in MC.REF_DOC_LIST)
                {
                    if(item.selected == true)
                    {
                        MasterEntity.order_no = item.ref_doc_no;
                        MasterEntity.ref_doc_cat = item.ref_doc_cat;
                        MasterEntity.ref_doc_type = item.ref_doc_type;
                        MasterEntity.ref_doc_no = item.ref_doc_no;
                        MasterEntity.client = AppSessionState.client;
                        MasterEntity.comp_code = item.comp_code;
                        MasterEntity.location_id = item.location_id;
                    }
                }
                
            }
        }
        private void ExecuteReference(object para)
        {
            if (!string.IsNullOrWhiteSpace(MasterEntity.ref_doc_no))
            {
                string Request = "";
                if (REF_DOC_OBJ != null) // call this if use REF_DOC_OBJ from PPC/PMM Order.
                {
                    Request = "EXEC_REF_DOC" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.ref_doc_no + "!@" + MasterEntity.ref_doc_cat + "!@" + MasterEntity.ref_doc_type + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + REF_DOC_OBJ.routing_no + "!@" + REF_DOC_OBJ.bom_no;
                }
                else // This is from self made transaction
                {
                    Request = "EXEC_REF_DOC" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.ref_doc_no + "!@" + MasterEntity.ref_doc_cat + "!@" + MasterEntity.ref_doc_type + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@!@";
                }
                    
                MC_TEMP = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<MC_MM_T005>(MC_TEMP, Request, "MM_T005_BL", "MM", "LoadAll", 0, "");
                if(MC_TEMP.MASTER_ENTITY_LIST != null)
                {
                    if(MC_TEMP.MASTER_ENTITY_LIST.Count > 0)
                    {
                        MasterEntity = MC_TEMP.MASTER_ENTITY_LIST[0];
                        ItemsEntity = MC_TEMP.ITEMS_ENTITY_LIST;//NOTE: if loading batch Table data then add Item Line id to the batch record in SQL Query.
                        BatchEntity = MC_TEMP.BATCH_ENTITY_LIST;
                        MasterEntity.ts_code = ts_code_vm;
                        NewRecord = true;
                    }
                }
                else
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record not found for the reference document", this.Title); sms.ShowMessage();
                }
            }
            else
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Select reference document", this.Title); sms.ShowMessage();
            }
        }
        private void ProductionOrderAssignemnt()
        {
            if(REF_DOC_OBJ != null)
            {
                if (!string.IsNullOrWhiteSpace(REF_DOC_OBJ.order_no))
                {
                    MasterEntity.order_no = REF_DOC_OBJ.order_no;
                    MasterEntity.ref_doc_cat = REF_DOC_OBJ.ref_doc_cat;
                    MasterEntity.ref_doc_type = REF_DOC_OBJ.ref_doc_type;
                    MasterEntity.ref_doc_no = REF_DOC_OBJ.ref_doc_no;
                    MasterEntity.mov_tp = "114";
                    MasterEntity.mov_type_name = "Reservation Against Order";
                    MasterEntity.order_item_row_id = REF_DOC_OBJ.order_item_row_id;
                    MasterEntity.bom_exp_no = REF_DOC_OBJ.bom_exp_no;
                    MasterEntity.rec_type = "OR";
                    MasterEntity.res_type = "RR";
                    MasterEntity.location_id = REF_DOC_OBJ.location_id;
                    MasterEntity.comp_code = REF_DOC_OBJ.comp_code;
                   
                }
            }
            
        }
        private void DefaultValues()
        {
            EntityChangeEnable = true;
            MasterEntity.doc_cat = doc_cat_vm;
            MasterEntity.doc_type = doc_cat_vm;
            MasterEntity.res_type = "RR";
            MasterEntity.active = "1";
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.res_date = DateTime.Now;
            MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
            MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();

            List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == MasterEntity.comp_code).ToList();
            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
            TheFilter = (o, prefix) => ((ADM_M0003)o).location_id.ToLower().Contains(prefix.ToLower()) || ((ADM_M0003)o).location_name.ToLower().Contains(prefix.ToLower());
            AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", true);
            AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = false; AS_LOCATION.AutoSuggestVM.IsFreeTextAllowed = false;
            if (LOC_LIST_OBJ.Count == 1)
            {
                MasterEntity.location_id = LOC_LIST_OBJ[0].location_id;
            }

            List<ADM_M0003> LOC_LIST_ITEM_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == MasterEntity.comp_code).ToList();
            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
            TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
            AS_LOCATION_ITEM = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_ITEM_OBJ, TheFilter, SuggestedValue, "location_id", "location_id", true);
            AS_LOCATION_ITEM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_LOCATION_ITEM.AutoSuggestVM.IsFreeTextAllowed = false;
            if (LOC_LIST_ITEM_OBJ.Count == 1)
            {
                ITEM_ENTITY_OBJ.location_id = LOC_LIST_OBJ[0].location_id;
            }

            ProductionOrderAssignemnt();
        }
        private void Logging()
        {
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;

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
            if (string.IsNullOrWhiteSpace(MasterEntity.location_id))//when form is blank and we save the record
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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Item........"); sms.ShowMessage();
                return false;
            }
            else if (MasterEntity.mov_tp == "" || MasterEntity.mov_tp == null)//when form is blank and we save the record
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Select Movement Type"); sms.ShowMessage();
                return false;
            }
            else
            {
                if (MasterEntity.mov_tp == "114")
                {
                    if (string.IsNullOrWhiteSpace(MasterEntity.ref_doc_no))
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Order No"); sms.ShowMessage();
                        return false;
                    }
                }
                // Validation for Quantity Item Duplication and Unit Code For Item Details
                foreach (var o in ItemsEntity)
                {
                    if (o.item_code != null && o.item_code != "" && o.bom_item_text != null)
                    {
                        int flag = 0; //duplicate entry is allowed so commented : pending delete
                        if (o.id == 0)
                        {
                            foreach (var p in ItemsEntity)
                            {
                                if (o.item_code == p.item_code && o.sku == p.sku && o.line_id == p.line_id && o.id == p.id)
                                {
                                    flag++;
                                }
                            }
                            if (flag > 1)
                            {
                                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1} and machine {2}", o.item_code, o.sku, o.bom_item_text); sms.ShowMessage();
                                return false;
                            }
                        }
                       
                        if (string.IsNullOrWhiteSpace(o.ind_dc) && (o.ind_dc != "D" || o.ind_dc != "C" || o.ind_dc != "N"))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Debit/Credit Indicator cannot be null or invalid for the item {0} and Parameter {1}", o.item_code, o.sku); sms.ShowMessage();
                            return false;
                        }
                        if (o.qty == null || o.qty == 0 || o.qty.HasValue == false)
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.item_code, o.sku); sms.ShowMessage();
                            return false;
                        }
                        if (string.IsNullOrWhiteSpace(o.unit_code))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1}", o.item_code, o.sku); sms.ShowMessage();
                            return false;
                        }
                        if (string.IsNullOrWhiteSpace(o.location_id))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Enter Valid Location/Plant code for the item {0} and Parameter {1}", o.item_code, o.sku); sms.ShowMessage();
                            return false;
                        }
                        if (string.IsNullOrWhiteSpace(o.comp_code))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Enter Valid Company code for the item {0} and Parameter {1}", o.item_code, o.sku); sms.ShowMessage();
                            return false;
                        }
                        if (string.IsNullOrWhiteSpace(o.store_code))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Store code for the item {0} and Parameter {1}", o.item_code, o.sku); sms.ShowMessage();
                            return false;
                        }

                        if (MC.BATCH_LIST != null && MC.BATCH_LIST.Count > 0)
                        {
                            var BatchDataItem = MC.BATCH_LIST.Where(x => x.item_code == o.item_code && x.location_id == o.location_id && x.client == o.client && x.store_code == o.store_code).ToList();
                            var BatchDataTab = BatchEntity.Where(x => x.item_code == o.item_code && x.location_id == o.location_id && x.client == o.client && x.store_code == o.store_code && string.IsNullOrWhiteSpace(x.batch_no) == false).ToList();
                            if (BatchDataItem.Count() > 0 && BatchDataTab.Count == 0)
                            {
                                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Invalid or Empty Batch Number"); sms.ShowMessage();
                                return false;
                            }
                        }
                    }
                    else
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("please select Item ........"); sms.ShowMessage();
                        return false;
                    }
                }
                //Validation for Entered Batch Quantity More than Stock Quantity
                for (int a = 0; a < BatchEntity.Count; a++)
                {
                    for (int b = 0; b < MC.BATCH_LIST.Count; b++)
                    {
                        if (BatchEntity[a].batch_no == MC.BATCH_LIST[b].batch_no && BatchEntity[a].item_code == MC.BATCH_LIST[b].item_code)
                        {
                            if (BatchEntity[a].qty > MC.BATCH_LIST[b].stock_total)
                            {
                                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Batch {0} Quantity {1} Exceeds Batch Capacity/RemainingCapacity {2} ", BatchEntity[a].batch_no, BatchEntity[a].qty, MC.BATCH_LIST[b].stock_total); sms.ShowMessage();
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
                        if (ItemsEntity[i].line_id == BatchEntity[j].item_line_id)
                        {
                            temp = temp + Convert.ToDecimal(BatchEntity[j].qty);
                            flag = 1;
                        }
                    }
                    if (ItemsEntity[i].qty != temp && flag == 1)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Item Quantity is Not Equal to Sum of All Item Batches Quantities for Item {0} sku :{1} ", ItemsEntity[i].item_code, ItemsEntity[i].sku); sms.ShowMessage();
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
                if (!string.IsNullOrEmpty(FLTR_STR_BACKFLIP))
                {
                    return (data.doc_no != null && data.doc_no.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.doc_date != null && data.doc_date.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.party_code != null && data.party_code.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.party_name != null && data.party_name.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.doc_cat != null && (data.ref_doc_cat??"").ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.mov_tp != null && data.mov_tp.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.mov_tp_name != null && data.mov_tp_name.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.location_id != null && data.location_id.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.comp_code != null && data.comp_code.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.post_date != null && data.post_date.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.emp_name != null && data.emp_name.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())
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
                if (string.IsNullOrWhiteSpace(MasterEntity.ref_doc_no) == false && MC.REF_DOC_LIST != null)
                {
                    if (MC.REF_DOC_LIST.Count > 0)
                    {
                        MC.REF_DOC_LIST.Remove(MC.REF_DOC_LIST.Single(s => s.ref_doc_no == MasterEntity.ref_doc_no));
                    }
                }
            }
            catch (Exception ex)
            { //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); 
            }

        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XDOC_A != null)
            {
                MC.ITEMS_ENTITY_LIST = (ObservableCollection<MM_T005_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_A, ItemsEntity);
                ItemsEntity.Clear();
                if (MC.ITEMS_ENTITY_LIST.Count > 0)
                {
                    ItemsEntity = MC.ITEMS_ENTITY_LIST;
                }
            }
            else
            {
                MC.ITEMS_ENTITY_LIST = new ObservableCollection<MM_T005_A>();
            }
            if (MasterEntity.XDOC_B != null)
            {
                MC.BATCH_ENTITY_LIST = (ObservableCollection<MM_T005_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_B, BatchEntity);
                BatchEntity.Clear();
                if(MC.BATCH_ENTITY_LIST.Count > 0)
                {
                    BatchEntity = MC.BATCH_ENTITY_LIST; // NOTE: add se_line_no with item Line id if required. it was done in old VM
                }
            }
            else
            {
                MC.BATCH_ENTITY_LIST = new ObservableCollection<MM_T005_B>();
            }
        }

        #region Abstract Commands
        public string ConvertDataTableToHTML()
        {
            string html = "<table>";
            //add header row
            html += "<tr bgcolor=#e0e0eb>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Item Code </span></strong></p> </td>";
            html += "<td width=10%> <p><strong><span style=color:#000080;> Item Name </span></strong></p> </td>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Quantity </span></strong></p> </td>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Unit </span></strong></p> </td>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Unit Price </span></strong></p> </td>";
            html += "</tr>";

            foreach (var item in ItemsEntity)
            {
                html += "<tr bgcolor=#d9e6f2>";
                html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.item_code + "</p></span></strong></p> </td>";
                html += "<td width=10%> <p><strong><span style=color:#000080;> " + item.bom_item_text + "</span></strong></p> </td>";
                html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.qty.ToString() + "</span></strong></p> </td>";
                html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.unit_code + "</span></strong></p> </td>";
                //html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.unit_price.ToString() + "</span></strong></p> </td>";
                html += "<td width=5%> <p><strong><span style=color:#000080;> " + (item.unit_price.HasValue ? decimal.Round(item.unit_price.Value, 2).ToString() : "") + "</span></strong></p> </td>";
                html += "</tr>";
            }
            html += "</table>";

            return html;
        }
        private void NotifyMessage(string AlertName, string operation)
        {
            try
            {
                List<NotificationData> objNotifyData = new List<NotificationData>();
                List<NotificationData> objNotifyDataTemp = new List<NotificationData>();
                NotificationData objNotifyDataObject = new NotificationData();
                string xx = ConvertDataTableToHTML();
                objNotifyDataTemp = MC.NOTIFICATION_LIST.Where(x => x.alert_name == AlertName).ToList();
                objNotifyDataTemp[0].CopyPropertiesTo<NotificationData>(objNotifyDataObject);
                objNotifyData.Add(objNotifyDataObject);
                foreach (NotificationData VarData in objNotifyData)
                {
                    List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("[EMP]",AppSessionState.Name),
                        new KeyValuePair<string, string>("[DOC]", MC.DOC_TYPE_LIST.Where(x=>x.doc_type == MasterEntity.doc_type).ToList()[0].doc_type_name),
                        new KeyValuePair<string, string>("[OPR]", MasterEntity.doc_cat),
                        new KeyValuePair<string, string>("[DOCNO]", MasterEntity.doc_no),
                        new KeyValuePair<string, string>("[Comp]","M/s: " + AppSessionState.CompanyName),
                        new KeyValuePair<string, string>("[TSTS]", MasterEntity.t_display),
                        new KeyValuePair<string, string>("[Attn]",VarData.EmpName),
                        new KeyValuePair<string, string>("[CUST]",MasterEntity.recipient_name),
                        new KeyValuePair<string, string>("[CUR]",AppSessionState.curr_code),
                        //new KeyValuePair<string, string>("[OVAL]",MasterEntity.roundup_total.ToString()),
                        new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.doc_date.ToString()),
                        new KeyValuePair<string, string>("[MODDT]", DateTime.Now.ToString()),
                        new KeyValuePair<string, string>("[PREF]", (MasterEntity.ref_doc_no ?? "").ToString() + " Dated: " + (MasterEntity.doc_date?.ToShortDateString())), //MasterEntity.cust_ref_date.HasValue ? MasterEntity.cust_ref_date.Value.ToString() : string.Empty;
                        //new KeyValuePair<string, string>("[INCO]", ((MasterEntity.incoterms ?? "") + ", " + (MasterEntity.incoterm2 ?? ""))),
                        new KeyValuePair<string, string>("[ITEM_TABLE]", xx),
                    };

                    foreach (KeyValuePair<string, string> kvp in kvpList)
                    {
                        VarData.subject = VarData.subject.Replace(kvp.Key, kvp.Value);
                        VarData.msg_body = VarData.msg_body.Replace(kvp.Key, kvp.Value);
                    }
                    VarData.cc_mail_id = (VarData.cc_mail_id ?? "") + ";" + (AppSessionState.EmpEmailId ?? "");
                    Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, VarData.to_mail_id, VarData.cc_mail_id, VarData.bcc_mail_id, VarData.subject, VarData.msg_body, null);
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnSaveAction(InquiryActionResult<MM_T005> result)
        {
            try
            {
                CursorControl.SetBusyState();
                MasterEntity.XDOC_A = SERIALIZATION_OBJ.ObjectToXML(ItemsEntity);
                MasterEntity.XDOC_B = SERIALIZATION_OBJ.ObjectToXML(BatchEntity);
                Logging();
                if (string.IsNullOrWhiteSpace(MasterEntity.doc_no))
                {
                    NewRecord = true;
                }
                else
                {
                    NewRecord = false;
                }

                this.MasterEntity.EndEdit();

                if (Validation() == true)
                {
                    if (NewRecord == true)
                    {
                        MasterEntity = REPOSITORY_OBJ.SaveWithReturnDomainObject<MM_T005>(MasterEntity, "MM_T005_BL", "MM");
                        if (MasterEntity.doc_no != null && MC.NOTIFICATION_LIST.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                        {
                            NotifyMessage("OnInsert", "Created");
                        }
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = REPOSITORY_OBJ.UpdateWithReturnDomainObject<MM_T005>(MasterEntity, "MM_T005_BL", "MM");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    NewRecord = false;
                    RemoveReferenceDocuments();
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        protected override void OnCreateAction(InquiryActionResult<MM_T005> result)
        {
            NewRecord = true;
            MasterEntity = new MM_T005();
            ItemsEntity = new ObservableCollection<MM_T005_A>();
            BatchEntity = new ObservableCollection<MM_T005_B>();
            ITEM_ENTITY_OBJ = new MM_T005_A();
            BATCH_ENTITY_OBJ = new MM_T005_B();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<MM_T005> result)
        {
            sms.ButtonSetup = DialogButton.Ok;
            sms.Caption = "Delete Changes";
            sms.Text = String.Format("This record will delete forever '{0}'", this.Title);

            if (sms.ShowMessage() == DialogResult.Ok)
            {
                this.MasterEntity.CancelEdit();
                string response = REPOSITORY_OBJ.Delete(MasterEntity.doc_no, "MM_T005_BL", "MM");
                MasterEntity = new MM_T005();
                ItemsEntity = new ObservableCollection<MM_T005_A>();
                BatchEntity = new ObservableCollection<MM_T005_B>();
                NewRecord = true;
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<MM_T005> result)
        {
            MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<MM_T005> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<MM_T005> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<MM_T005> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<MM_T005> result)
        {
            try
            {
                string Request = "MaterialIssue" + "!@" + MasterEntity.doc_no;
                MC_TEMP = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<MC_MM_T005>(MC_TEMP, Request, "MM_T005_BL_NEW", "MM", Request, 0, "");

                object[] objDataSource = new object[5];
                string[] objDataSourceName = new string[5];

                objDataSource[0] = MC_TEMP.MASTER_ENTITY_LIST;
                objDataSource[1] = MC_TEMP.ITEMS_ENTITY_LIST;
                objDataSource[2] = MC_TEMP.BATCH_ENTITY_LIST;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[3] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_id == MasterEntity.location_id).ToList();
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
        protected override void OnRefreshCommand(InquiryActionResult<MM_T005> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnLedgerViewCommand(InquiryActionResult<MM_T005> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnValidateCommand(InquiryActionResult<MM_T005> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnTraceCommand(InquiryActionResult<MM_T005> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnMailCommand(InquiryActionResult<MM_T005> result)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}



// Use same function od load inital data to call from change of company and location.
// DO not allow mov type to change after save. xaml have MoveFlag binding;