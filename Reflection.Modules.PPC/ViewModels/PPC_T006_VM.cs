using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.Production;
using Reflection.ReportingServices;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Collections.Specialized;
using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;

namespace Reflection.Modules.PPC.ViewModels
{
    public class PPC_T006_VM : WorkspaceViewModel<EPR_T002>
    {
        #region Private Local Variable Declaration
        private bool isNewRecord = true;
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

        private string ts_code_vm { get; set; }
        private string doc_no_vm { get; set; }
        private string doc_cat_vm { get; set; }

        WebServiceRepository<List<EPR_T002>> repository = new WebServiceRepository<List<EPR_T002>>();
        WebServiceRepository<MC_PPC_BE> repository_MC = new WebServiceRepository<MC_PPC_BE>();
        ObjectSerializationService SER_OBJ = new ObjectSerializationService();

        private MC_PPC_BE _MC = new MC_PPC_BE();
        public MC_PPC_BE MC
        {
            get { return _MC; }
            set { if (_MC != value) { _MC = value; RaisePropertyChanged("MC"); } }
        }
        private MC_PPC_BE _MCTemp = new MC_PPC_BE();
        public MC_PPC_BE MCTEMP
        {
            get { return _MCTemp; }
            set { if (_MCTemp != value) { _MCTemp = value; RaisePropertyChanged("MCTEMP"); } }
        }

        private EPR_T002 _MasterEntity;
        public EPR_T002 MasterEntity //NOTE: Deprecated
        {
            get { return _MasterEntity; }
            set { if (_MasterEntity != value) { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); } }
        }
        private EPR_T002 _MasterEntityTemp;
        public EPR_T002 MasterEntityTemp
        {
            get { return _MasterEntityTemp; }
            set { if (_MasterEntityTemp != value) { _MasterEntityTemp = value; RaisePropertyChanged("MasterEntityTemp"); } }
        }
        private ObservableCollection<EPR_T002> _MasterEntity_List;
        public ObservableCollection<EPR_T002> MasterEntity_List
        {
            get { return _MasterEntity_List; }
            set
            {
                if (_MasterEntity_List != value)
                {
                    _MasterEntity_List = value;
                    MasterEntity_List.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForExecution);
                    RaisePropertyChanged("MasterEntity_List");
                }
            }
        }

        private ObservableCollection<EPR_T002> _MasterEntity_List_Temp;
        public ObservableCollection<EPR_T002> MasterEntity_List_Temp
        {
            get { return _MasterEntity_List_Temp; }
            set { if (_MasterEntity_List_Temp != value) { _MasterEntity_List_Temp = value; RaisePropertyChanged("MasterEntity_List_Temp"); } }
        }

        private EPR_T001 _OrderEntity;
        public EPR_T001 OrderEntity
        {
            get { return _OrderEntity; }
            set { if (_OrderEntity != value) { _OrderEntity = value; RaisePropertyChanged("OrderEntity"); } }
        }
        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }
        private List<ConfirmationTypes> ConfirmationTypesList;

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

        private STD_LIST_BE _RecordTypeSelected;
        public STD_LIST_BE RecordTypeSelected
        {
            get { return _RecordTypeSelected; }
            set
            {
                if (_RecordTypeSelected != value)
                {
                    _RecordTypeSelected = value;

                    RaisePropertyChanged("RecordTypeSelected");
                }
            }
        }

        private ICollectionView _ProductionCollection;
        public ICollectionView ProductionCollection
        {
            get { return _ProductionCollection; }
            set
            {
                _ProductionCollection = value;
                RaisePropertyChanged("ProductionCollection");
            }
        }

        private bool _NoFirstOperation;
        public bool NoFirstOperation
        {
            get { return _NoFirstOperation; }
            set
            {
                if (_NoFirstOperation != value)
                {
                    _NoFirstOperation = value; RaisePropertyChanged("NoFirstOperation");
                }
            }

        }

        private int _NewRowCount; // This variable will generate Multiple Records equivalant to variables value on execute of command. Default Value is 1.
        public int NewRowCount
        {
            get { return _NewRowCount; }
            set
            {
                if (_NewRowCount != value)
                {
                    _NewRowCount = value; RaisePropertyChanged("NewRowCount");
                }
            }
        }
        private decimal _BatchQty; // This is Batch Qty for each row is being created. it is qty that obtain by total qty devide by number of batches is required to create
        public decimal BatchQty
        {
            get { return _BatchQty; }
            set
            {
                if (_BatchQty != value)
                {
                    _BatchQty = value; RaisePropertyChanged("BatchQty");
                }
            }
        }
        private string _QR_Barcode; // This variable will help to insert record with the help of QR/Barcode.
        public string QR_Barcode
        {
            get { return _QR_Barcode; }
            set
            {
                if (_QR_Barcode != value)
                {
                    _QR_Barcode = value; RaisePropertyChanged("QR_Barcode");
                }
            }
        }
        private bool _Indicator_FinalData; // This variable will help to insert record with the help of QR/Barcode.
        public bool Indicator_FinalData
        {
            get { return _Indicator_FinalData; }
            set
            {
                if (_Indicator_FinalData != value)
                {
                    _Indicator_FinalData = value; RaisePropertyChanged("Indicator_FinalData");
                }
            }
        }

        private IEnumerable _ORDER_LIST;
        public IEnumerable ORDER_LIST
        {
            get { return _ORDER_LIST; }
            set { _ORDER_LIST = value; RaisePropertyChanged("ORDER_LIST"); }
        }

        #endregion
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PPC_T006_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
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
        private AutoSuggestTextViewModel<dynamic> _AS_BARCODE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_BARCODE
        {
            get { return _AS_BARCODE; }
            set
            {
                if (_AS_BARCODE != value)
                {
                    _AS_BARCODE = value; RaisePropertyChanged("AS_BARCODE");
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
        private AutoSuggestTextViewModel<dynamic> _AS_WC { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_WC
        {
            get { return _AS_WC; }
            set
            {
                if (_AS_WC != value)
                {
                    _AS_WC = value; RaisePropertyChanged("AS_WC");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_SHIFT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_SHIFT
        {
            get { return _AS_SHIFT; }
            set
            {
                if (_AS_SHIFT != value)
                {
                    _AS_SHIFT = value; RaisePropertyChanged("AS_SHIFT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_SHIFT_INCHARGE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_SHIFT_INCHARGE
        {
            get { return _AS_SHIFT_INCHARGE; }
            set
            {
                if (_AS_SHIFT_INCHARGE != value)
                {
                    _AS_SHIFT_INCHARGE = value; RaisePropertyChanged("AS_SHIFT_INCHARGE");
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
        private AutoSuggestTextViewModel<dynamic> _AS_UOM_TIME { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_TIME
        {
            get { return _AS_UOM_TIME; }
            set
            {
                if (_AS_UOM_TIME != value)
                {
                    _AS_UOM_TIME = value; RaisePropertyChanged("AS_UOM_TIME");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_OPERATOR { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_OPERATOR
        {
            get { return _AS_OPERATOR; }
            set
            {
                if (_AS_OPERATOR != value)
                {
                    _AS_OPERATOR = value; RaisePropertyChanged("AS_OPERATOR");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_EMPLOYEE { get; set; } // NOTE: not in use
        public AutoSuggestTextViewModel<dynamic> AS_EMPLOYEE
        {
            get { return _AS_EMPLOYEE; }
            set
            {
                if (_AS_EMPLOYEE != value)
                {
                    _AS_EMPLOYEE = value; RaisePropertyChanged("AS_EMPLOYEE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_INPUT_TYPE { get; set; } // NOTE: not in use
        public AutoSuggestTextViewModel<dynamic> AS_INPUT_TYPE
        {
            get { return _AS_INPUT_TYPE; }
            set
            {
                if (_AS_INPUT_TYPE != value)
                {
                    _AS_INPUT_TYPE = value; RaisePropertyChanged("AS_INPUT_TYPE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_RECORD_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_RECORD_TYPE
        {
            get { return _AS_RECORD_TYPE; }
            set
            {
                if (_AS_RECORD_TYPE != value)
                {
                    _AS_RECORD_TYPE = value; RaisePropertyChanged("AS_RECORD_TYPE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_REASON { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_REASON
        {
            get { return _AS_REASON; }
            set
            {
                if (_AS_REASON != value)
                {
                    _AS_REASON = value; RaisePropertyChanged("AS_REASON");
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
                    if (SourceName == "RecordType")
                    { AS_DEFAULT = AS_RECORD_TYPE; }
                    else if (SourceName == "order_no")
                    { AS_DEFAULT = AS_ORDERS; }
                    else if (SourceName == "operation_no")
                    { AS_DEFAULT = AS_OPERATIONS; }
                }
            }
        }
        #endregion
        #region Relay Command
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdGetExecutionData { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; } // NOTE: Deprecated
        public RelayCommand<object> cmdBarcodeScan { get; private set; }
        public RelayCommand<object> cmdCopyRow { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_MasterEntity { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_MasterEntity_Temp { get; private set; }
        public RelayCommand<object> cmdExecute { get; private set; }
        public RelayCommand cmdClear { get; private set; }
        public RelayCommand<object> cmdSelectAll { get; private set; }
        public RelayCommand<object> cmdInsertOrderNumber { get; private set; }
        public RelayCommand<object> cmdInsertOrderNumberTemp { get; private set; }
        public RelayCommand<object> cmdInsertOperation { get; private set; }
        public RelayCommand<object> cmdInsertOperationTemp { get; private set; }

        #endregion
        #region Abstract Command
        protected override void OnCreateAction(InquiryActionResult<EPR_T002> result)
        {
            MasterEntity = new EPR_T002();
            MasterEntityTemp = new EPR_T002();
            MasterEntity_List = new ObservableCollection<EPR_T002>();
            MasterEntity_List_Temp = new ObservableCollection<EPR_T002>();
            RecordTypeSelected = new STD_LIST_BE();
            DefaultValues();
        }
        protected override void OnDiscardAction(InquiryActionResult<EPR_T002> result)
        {}
        protected override void OnDocumentAction()
        {}
        protected override void OnFevoriteAction(InquiryActionResult<EPR_T002> result)
        {}
        protected override void OnFlipAction(InquiryActionResult<EPR_T002> result)
        {}
        protected override void OnHelpAction(InquiryActionResult<EPR_T002> result)
        {}
        protected override void OnPrintAction(InquiryActionResult<EPR_T002> result)
        {
            try
            {
                if (MasterEntity != null)
                {
                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];

                    QRCodeService QRGenerator = new QRCodeService();
                    MasterEntity.qr_batch = QRGenerator.RenderQrCodeForLabel(MasterEntity.barcode, 15, "");

                    List<EPR_T002> obj = new List<EPR_T002>();
                    obj.Add(MasterEntity);
                    objDataSource[0] = obj;
                    objDataSourceName[0] = "dsJobCard";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\" + "JOB_CARD_QR_BAR_Code.rdlc", "JOB_CARD_QR_BAR_Code.rdlc");
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Print Option", this.Title);
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
        protected override void OnRemoveAction(InquiryActionResult<EPR_T002> result)
        {}
        protected override void OnSaveAction(InquiryActionResult<EPR_T002> result)
        {
            try
            {
                List<EPR_T002> MasterEntityList = new List<EPR_T002>();
                if (isNewRecord == true)
                {
                    foreach (var o in MasterEntity_List)  //First Selected Rows Will be Added To New Collection
                    {
                        if (o.check == true)
                        {
                            MasterEntityList.Add(o); // NOTE: add Logging function before save
                        }
                    }

                    if (MasterEntityList.Count > 0)   // If At Least One Row is Selected The Only It Will Save
                    {
                        if (Validation() == true)
                        {
                            MasterEntityList = repository.SaveWithReturnDomainObject<List<EPR_T002>>(MasterEntityList, "EPR_T002_BL", "PPC");

                            if (MasterEntityList.Count > 0) // intreader is always greater than 0 if data is saved
                            {
                                MasterEntity_List.Clear();
                                foreach (var o in MasterEntityList)
                                {
                                    o.ts_code = ts_code_vm;
                                    MasterEntity_List.Add(o);
                                }
                                isNewRecord = false;
                                MasterEntity.barcode_value = null;
                                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record Addred Successfully!", this.Title); sms.ShowMessage();
                            }

                        }
                    }
                    else  // if No rows are selected it will give Message
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select At Least One Row", this.Title); sms.ShowMessage();
                    }
                    MasterEntity.ts_code = ts_code_vm;
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
        protected override void OnRefreshCommand(InquiryActionResult<EPR_T002> result)
        {
            LoadInitialData();
        }
        protected override void OnLedgerViewCommand(InquiryActionResult<EPR_T002> result)
        {}
        protected override void OnValidateCommand(InquiryActionResult<EPR_T002> result)
        {}
        protected override void OnTraceCommand(InquiryActionResult<EPR_T002> result)
        {}
        protected override void OnMailCommand(InquiryActionResult<EPR_T002> result)
        {}
        #endregion
        #region Constructor
        public PPC_T006_VM(string ts_code, string doc_cat) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            EPR_T002.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MC_PPC_BE();
            MCTEMP = new MC_PPC_BE();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MasterEntity = new EPR_T002();
            MasterEntityTemp = new EPR_T002();
            MasterEntity_List = new ObservableCollection<EPR_T002>();
            MasterEntity_List_Temp = new ObservableCollection<EPR_T002>();
            RecordTypeSelected = new STD_LIST_BE();
            OrderEntity = new EPR_T001();
            ConfirmationTypesList = new List<ConfirmationTypes>();
            InitializeCommands();
            MasterEntity_List.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForExecution);
        }
        public PPC_T006_VM(string ts_code, string doc_cat, string doc_no) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            EPR_T002.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MC_PPC_BE();
            MCTEMP = new MC_PPC_BE();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MasterEntity = new EPR_T002();
            MasterEntityTemp = new EPR_T002();
            MasterEntity_List = new ObservableCollection<EPR_T002>();
            MasterEntity_List_Temp = new ObservableCollection<EPR_T002>();
            RecordTypeSelected = new STD_LIST_BE();
            OrderEntity = new EPR_T001();
            ConfirmationTypesList = new List<ConfirmationTypes>();
            InitializeCommands();
            MasterEntity_List.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForExecution);
        }
        #endregion
        #region Standard Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI_FAST" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + AppSessionState.EmpId + "!@FAST";
                MC = repository_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MC, Request, "EPR_T002_BL", "PPC", " ", 0, "");

                ORDER_LIST = MC.ORDER_LIST;
                #region Autosuggest

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((EPR_T001)x).order_no);
                TheFilter = (o, prefix) => (((EPR_T001)o).ref_doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).order_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).short_text ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).project_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).element_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).para1 ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).para2 ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ORDERS = new AutoSuggestTextViewModel<dynamic>(MC.ORDER_LIST, TheFilter, SuggestedValue, "order_no", true);
                AS_ORDERS.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ORDERS.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).wc_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).wc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).wc_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).wc_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_WC = new AutoSuggestTextViewModel<dynamic>(MC.WC_LIST, TheFilter, SuggestedValue, "wc_code", true);
                AS_WC.AutoSuggestVM.IsEmptyValueAllowed = false; AS_WC.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).shift_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).shift_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_SHIFT = new AutoSuggestTextViewModel<dynamic>(MC.SHIFT_LIST, TheFilter, SuggestedValue, "shift_code", true);
                AS_SHIFT.AutoSuggestVM.IsEmptyValueAllowed = true; AS_SHIFT.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM.AutoSuggestVM.IsEmptyValueAllowed = false; AS_UOM.AutoSuggestVM.IsFreeTextAllowed = false;

                List<UOMS> TimeUOM = MC.UOM_LIST.Where(x => x.class_id == 3).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_TIME = new AutoSuggestTextViewModel<dynamic>(TimeUOM, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM_TIME.AutoSuggestVM.IsEmptyValueAllowed = false; AS_UOM_TIME.AutoSuggestVM.IsFreeTextAllowed = false;

                List<STD_PERSONNEL> empObj = MC.PERSONNEL_LIST.Where(x => x.emp_type == "EMP").ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_SHIFT_INCHARGE = new AutoSuggestTextViewModel<dynamic>(empObj, TheFilter, SuggestedValue, "shift_incharge", true);
                AS_SHIFT_INCHARGE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_SHIFT_INCHARGE.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_EMPLOYEE = new AutoSuggestTextViewModel<dynamic>(empObj, TheFilter, SuggestedValue, "emp_id", true);
                AS_EMPLOYEE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_EMPLOYEE.AutoSuggestVM.IsFreeTextAllowed = false;

                List<STD_PERSONNEL> optObj = MC.PERSONNEL_LIST.Where(x => x.emp_type == "OPR").ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OPERATOR = new AutoSuggestTextViewModel<dynamic>(optObj, TheFilter, SuggestedValue, "m_operator", true);
                AS_OPERATOR.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OPERATOR.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).record_type);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).record_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).type_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_RECORD_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.RECORD_TYPE_LIST, TheFilter, SuggestedValue, "record_type", true);
                AS_RECORD_TYPE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_RECORD_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).value_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).value_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_REASON = new AutoSuggestTextViewModel<dynamic>(MC.REASON_LIST, TheFilter, SuggestedValue, "value_code", true);
                AS_REASON.AutoSuggestVM.IsEmptyValueAllowed = true; AS_REASON.AutoSuggestVM.IsFreeTextAllowed = false;

                List<STD_LIST_BE> OperationsListObj = MC.OPERATION_LIST.GroupBy(item => new { item.operation_no, item.operation_desc }).Select(group => group.First()).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).operation_no);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).operation_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).operation_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OPERATIONS = new AutoSuggestTextViewModel<dynamic>(OperationsListObj, TheFilter, SuggestedValue, "operation_no", true);
                AS_OPERATIONS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OPERATIONS.AutoSuggestVM.IsFreeTextAllowed = false;


                #endregion
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void LoadDocumentByDocumentNumber(object InputValue)
        {
            try
            {
                EntityChangeEnable = false;
                EPR_T002 POPUPEntityObject = null;
                string Request;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MCTEMP.CONFIRMATION_LIST.Where(x => x.doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<EPR_T002>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<EPR_T002>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    EPR_T002 OBJ = new EPR_T002();
                    OBJ = MasterEntity;
                    Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client.ToString() + "!@" + POPUPEntityObject.comp_code.ToString() + "!@" + POPUPEntityObject.location_Id + "!@" + POPUPEntityObject.doc_cat + "!@" + POPUPEntityObject.doc_type + "!@" + POPUPEntityObject.doc_no;
                    MCTEMP = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTEMP, Request, "EPR_T002_BL", "PPC", " ", 0, "");
                    MasterEntity = OBJ;
                    if (MCTEMP.CONFIRMATION_LIST.Count > 0)
                    {
                        MasterEntity = MCTEMP.CONFIRMATION_LIST[0];
                    }
                }
                MasterEntity.ts_code = ts_code_vm;
                EntityChangeEnable = true;
                isNewRecord = false;
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void GetExecutionData(object InputValue)
        {
        }
        private void InitializeCommands()
        {
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEventCall(items); });
            cmdGetExecutionData = new RelayCommand<object>(items => { if (items == null) { return; } GetExecutionData(items); });
            cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items); });
            cmdBarcodeScan = new RelayCommand<object>(items => { if (items == null) { return; } BarcodeScan(items); });
            cmdCopyRow = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } CopyRow(cmdPara); });
            cmdSelectionChanged_MasterEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } SelectionChanged_MasterEntity(cmdPara); });
            cmdSelectionChanged_MasterEntity_Temp = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } SelectionChanged_MasterEntity_Temp(cmdPara); });
            cmdExecute = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ExecuteReference(cmdPara); });
            cmdClear = new RelayCommand(ClearData);
            cmdSelectAll = new RelayCommand<object>(items => { if (items == null) { return; } SelectAllRows(items); });
            cmdInsertOrderNumber = new RelayCommand<object>(items => { if (items == null) { return; } InsertOrderNumber(items); });
            cmdInsertOrderNumberTemp = new RelayCommand<object>(items => { if (items == null) { return; } InsertOrderNumberTemp(items); });
            cmdInsertOperation = new RelayCommand<object>(items => { if (items == null) { return; } InsertOperation(items); });
            cmdInsertOperationTemp = new RelayCommand<object>(items => { if (items == null) { return; } InsertOperationTemp(items); });

        }
        private void DefaultValues()
        {
            try
            {
                EntityChangeEnable = true;
                if (doc_cat_vm == "02" || doc_cat_vm == "01")
                {
                    MasterEntityTemp.record_type = "01";
                }
                else if (doc_cat_vm == "04")
                {
                    MasterEntity.record_type = "05";
                }
                else if (doc_cat_vm == "05")
                {
                    MasterEntity.record_type = "05";
                }

                MasterEntity.barcode_value = null;
                isNewRecord = true;
                MasterEntityTemp.ts_code = this.ts_code_vm;
                MasterEntityTemp.doc_cat = this.doc_cat_vm;
                MasterEntityTemp.doc_type = doc_cat_vm;
                MasterEntityTemp.add_by = AppSessionState.UserID;
                MasterEntity.userid = AppSessionState.UserID;
                MasterEntity.session_id = AppSessionState.session_id;
                MasterEntityTemp.client = AppSessionState.client;
                MasterEntityTemp.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                MasterEntityTemp.active = true;
                MasterEntityTemp.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                MasterEntityTemp.emp_id = AppSessionState.EmpId;
                //MasterEntityTemp.m_operator = AppSessionState.EmpId;
                MasterEntityTemp.conf_type = "P";
                MasterEntityTemp.emp_no = 1;
                MasterEntityTemp.prod_dt = DateTime.UtcNow;
                MasterEntityTemp.entry_dt = DateTime.UtcNow;
                MasterEntityTemp.post_date = DateTime.UtcNow;
                MasterEntityTemp.execution_start = DateTime.UtcNow;
                MasterEntityTemp.execution_finish = DateTime.UtcNow;
                MasterEntity_List_Temp.Add(MasterEntityTemp);

                DateTime d = DateTime.UtcNow;
                d = d.AddMonths(-1);
                REQUEST_PARA.from_date = d;
                REQUEST_PARA.to_date = DateTime.UtcNow;
                REQUEST_PARA.active = true;
                REQUEST_PARA.location_id = AppSessionState.OBJ_LOCATION.location_id;

                NewRowCount = 1;
                QR_Barcode = null;
                BatchQty = 0;
                Indicator_FinalData = false;

                if (MC.DOC_TYPE_LIST != null)
                {
                    if (MC.DOC_TYPE_LIST.Count > 0)
                    {
                        MasterEntityTemp.ac_work_uom = MC.DOC_TYPE_LIST[0].unit_code;
                        MasterEntity.ac_work_uom = MC.DOC_TYPE_LIST[0].unit_code;
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
        private bool Validation()
        {
            // Yield Quantity should not exceed Order Qty.
            // Yield Quantity should not exceed Previous Operation Qty.
            // Quantity should not allowed for Record type other than 01.

            foreach (var item in MasterEntity_List)  //First Selected Rows Will be Added To New Collection
            {
                if (item.check == true)
                {
                    if (item.record_type == "01" && string.IsNullOrWhiteSpace(item.order_no))
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Order Number Is Required"); sms.ShowMessage();
                        return false;
                    }
                    if (!item.ac_duration.HasValue || string.IsNullOrWhiteSpace(item.ac_duration_uom) || (item.ac_duration ?? 0) == 0)
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Actual Work Duration and Unit of Measurement of Work Required."); sms.ShowMessage();
                        return false;
                    }
                    if (item.record_type == "01" && item.operation_no == "10" && !string.IsNullOrWhiteSpace(item.barcode))
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Operation not allowed for generated Batch"); sms.ShowMessage();
                        return false;
                    }
                    if (item.record_type == "01" && item.operation_no != "10" && string.IsNullOrWhiteSpace(item.barcode))
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Operation not allowed for new Batch record creation, Batch Number and barcode required for this operation"); sms.ShowMessage();
                        return false;
                    }

                    if (item.record_type == "01" && string.IsNullOrWhiteSpace(item.ItemCode))
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Item Code Is Required for Record Type Order Processing"); sms.ShowMessage();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(item.record_type))
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record Type Is Required"); sms.ShowMessage();
                        return false;
                    }
                    if (item.record_type == "01" && string.IsNullOrWhiteSpace(item.unit_code))
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Unit of Measurement Is Required for Record Type Order Processing."); sms.ShowMessage();
                        return false;
                    }
                    if (item.record_type == "01" && string.IsNullOrWhiteSpace(item.record_type) && RecordTypeSelected.ind_qty == "Y" && ((item.yield ?? 0) <= 0 && (item.scrap_qty ?? 0) <= 0 && (item.rework_qty ?? 0) <= 0))
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Yeild or Scrap or Rework Quantity Is Required for Record Type Order Processing."); sms.ShowMessage();
                        return false;
                    }
                    if (!string.IsNullOrWhiteSpace(item.order_no) && string.IsNullOrWhiteSpace(item.operation_no))
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Operation Number is Required"); sms.ShowMessage();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(item.conf_type))
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Order Execution Type is Required"); sms.ShowMessage();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(item.wc_code))
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Work Center is Required"); sms.ShowMessage();
                        return false;
                    }
                    if (item.yield.HasValue && string.IsNullOrWhiteSpace(item.unit_code))
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Unit of Measurement required Required"); sms.ShowMessage();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(item.emp_id))
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("User Name Required"); sms.ShowMessage();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(item.m_operator))
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Operator Name Required"); sms.ShowMessage();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(item.shift_incharge))
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Shift Incharge Required"); sms.ShowMessage();
                        return false;
                    }
                }
            }


            return true;
        }
        private void CopyRow(object InputValue)
        {
            if (MasterEntity != null)
            {
                EPR_T002 objNew = new EPR_T002();
                MasterEntity.CopyPropertiesTo<EPR_T002>(objNew);
                MasterEntity_List.Add(objNew);
            }
        }
        private void BarcodeScan(object InputValue)
        {
            try
            {
                string Request = InputValue.ToString();
                string RequestBarcode = null;
                #region Command Parameter Read Section
                if (!string.IsNullOrWhiteSpace(MasterEntity.barcode_value))
                {
                    if (MC.BATCH_CODE_LIST.Where(x => x.barcode == MasterEntity.barcode_value) != null)
                    {
                        if (MC.BATCH_CODE_LIST.Where(x => x.barcode == MasterEntity.barcode_value).ToList().Count > 0)
                        {
                            RequestBarcode = MC.BATCH_CODE_LIST.Where(x => x.barcode == MasterEntity.barcode_value).ToList()[0].barcode;
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(Request) && !string.IsNullOrWhiteSpace(RequestBarcode))
                {
                    EPR_T002 OBJ = new EPR_T002();
                    OBJ = MasterEntity;
                    string Request2 = "BARCODE_SCAN" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + (Utilities.NullIf(REQUEST_PARA.doc_type) ?? "") + "!@" + "!@" + (Utilities.NullIf(REQUEST_PARA.emp_id) ?? AppSessionState.EmpId) + "!@" + Request + "!@" + AppSessionState.UserID;
                    MCTEMP = repository_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MCTEMP, Request2, "EPR_T002_BL", "PPC", "LoadAll", 0, "");
                    MasterEntity = OBJ;
                    if (MCTEMP.CONFIRMATION_LIST.Count > 0)
                    {
                        var ScanData = MasterEntity_List.Where(x => (x.barcode ?? "").Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList();
                        if (ScanData == null || ScanData.Count == 0) // Avoide Duplicate entry
                        {
                            if (MCTEMP.CONFIRMATION_LIST.Count > 1) // Count > 1 means Rework order exists, then user must select order from order popup. to select order nulber we set it null first.
                            {
                                var ObjRow = MCTEMP.CONFIRMATION_LIST[0];
                                ObjRow.order_no = null;
                                MasterEntity_List.Add(ObjRow);
                                MasterEntity = MCTEMP.CONFIRMATION_LIST[0];

                                SuggestedValue = new ValueConverter(x => x == null ? "" : ((EPR_T001)x).order_no);
                                TheFilter = (o, prefix) => (((EPR_T001)o).order_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                                AS_ORDERS = new AutoSuggestTextViewModel<dynamic>(MCTEMP.ORDER_LIST, TheFilter, SuggestedValue, "order_no", true);
                                AS_ORDERS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ORDERS.AutoSuggestVM.IsFreeTextAllowed = true;

                                if (MC.OPERATION_LIST != null) // Append operation if not exists in MC list.
                                {
                                    if (MC.OPERATION_LIST.Where(x => x.order_no == MasterEntity.order_no).ToList().Count == 0)
                                    {
                                        foreach (var item in MCTEMP.OPERATION_LIST)
                                        {
                                            MC.OPERATION_LIST.Add(item);
                                        }
                                    }
                                }
                                else
                                {
                                    MC.OPERATION_LIST = MCTEMP.OPERATION_LIST;
                                }

                                //var ObjPOList = new List<EPR_T001>();
                                //foreach (var item in MC.MIS_STD_PPC_1_LIST) // select Ordor numbers for New and Rework for selected Barcode.
                                //{
                                //    if(item.barcode == Request)
                                //    {
                                //        var OrderList = MC.ORDER_LIST.Where(x => x.ItemCode == item.item_code && x.ItemCode == MasterEntity.ItemCode && x.order_no == item.order_no).ToList();
                                //        foreach (var item2 in OrderList)
                                //        {
                                //            if (ObjPOList.Where(x => x.ItemCode == item.item_code && x.ItemCode == MasterEntity.ItemCode && x.order_no == item.order_no).ToList() == null)
                                //            {
                                //                ObjPOList.Add(item2);
                                //            }
                                //        }
                                //    }
                                //}
                                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((EPR_T001)x).order_no);
                                //TheFilter = (o, prefix) => (((EPR_T001)o).order_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                                //AS_ORDERS = new AutoSuggestTextViewModel<dynamic>(ObjPOList, TheFilter, SuggestedValue, "order_no", true);
                                //AS_ORDERS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ORDERS.AutoSuggestVM.IsFreeTextAllowed = true;
                            }
                            else
                            {
                                MasterEntity_List.Add(MCTEMP.CONFIRMATION_LIST[0]);
                                MasterEntity = MCTEMP.CONFIRMATION_LIST[0];
                                if (MC.OPERATION_LIST != null) // Append operation if not exists in MC list.
                                {
                                    if (MC.OPERATION_LIST.Where(x => x.order_no == MasterEntity.order_no).ToList().Count == 0)
                                    {
                                        foreach (var item in MCTEMP.OPERATION_LIST)
                                        {
                                            MC.OPERATION_LIST.Add(item);
                                        }
                                    }
                                }
                                else
                                {
                                    MC.OPERATION_LIST = MCTEMP.OPERATION_LIST;
                                }

                                var MOperationList = MC.OPERATION_LIST.Where(x => x.order_no == MasterEntity.order_no).ToList();
                                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).operation_no);
                                TheFilter = (o, prefix) => (((STD_LIST_BE)o).operation_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).operation_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                                AS_OPERATIONS = new AutoSuggestTextViewModel<dynamic>(MOperationList, TheFilter, SuggestedValue, "operation_no", true);
                                AS_OPERATIONS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OPERATIONS.AutoSuggestVM.IsFreeTextAllowed = false;

                                MasterEntity.ItemCode = OrderEntity.ItemCode;
                                MasterEntity.ItemName = OrderEntity.ItemName;
                                MasterEntity.location_Id = OrderEntity.location_Id;
                                MasterEntity.comp_code = OrderEntity.comp_code;
                                MasterEntity.routing_no = OrderEntity.routing_no;
                                MasterEntity.unit_code = OrderEntity.unit_code;
                                MasterEntity.store_code = OrderEntity.store_code;
                                MasterEntity.order_type = OrderEntity.order_type;
                                if (MC.OPERATION_LIST.Count == 1)
                                {
                                    MasterEntity.operation_no = MC.OPERATION_LIST[0].operation_no;
                                    MasterEntity.wc_code = MC.OPERATION_LIST[0].wc_code;
                                }
                                else if (MC.OPERATION_LIST.Exists(x => x.operation_no.Equals(MasterEntity.operation_no)) == false || string.IsNullOrWhiteSpace(MasterEntity.operation_no) == true)
                                {
                                    MasterEntity.operation_no = null;
                                }
                            }
                            MasterEntity.barcode_value = null;
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void SelectAllRows(object InputValue) // can be remove this function, we hahe include this code in Function of OK Button below the popup window.
        {
            try
            {
                if (MasterEntity_List != null)
                {
                    if (MasterEntity_List.Count > 0)
                    {
                        foreach (var item in MasterEntity_List)
                        {
                            item.check = !item.check;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void ClearData()
        {
            try
            {
                MasterEntity = new EPR_T002();
                // MasterEntityTemp = new EPR_T002();
                MasterEntity_List = new ObservableCollection<EPR_T002>();
                //MasterEntity_List_Temp = new ObservableCollection<EPR_T002>();
                RecordTypeSelected = new STD_LIST_BE();
                DefaultValues();
            }
            catch (Exception ex)
            { }
        }
        private void InsertOrderNumber(object InputValue)
        {
            try
            {
                List<STD_LIST_BE> MOperationList = new List<STD_LIST_BE>();
                EPR_T001 POPUPEntityObject = null;
                string Request = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0 && !string.IsNullOrWhiteSpace(Request))
                    {
                        try
                        {
                            POPUPEntityObject = MC.ORDER_LIST.Where(x => x.order_no == Request).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                #endregion
                #region Command Parameter Read Section
                if (POPUPEntityObject != null)
                {
                    EPR_T002 OBJ = new EPR_T002();
                    OBJ = MasterEntity;
                    string Request2 = "EXECUTE_REFERENCE_ORDER" + "!@" + AppSessionState.client + "!@" + POPUPEntityObject.comp_code + "!@" + POPUPEntityObject.location_Id + "!@" + doc_cat_vm + "!@" + (Utilities.NullIf(REQUEST_PARA.doc_type) ?? "") + "!@" + Request + "!@" + (Utilities.NullIf(REQUEST_PARA.emp_id) ?? AppSessionState.EmpId);
                    MCTEMP = repository_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MCTEMP, Request2, "EPR_T002_BL", "PPC", "LoadAll", 0, "");
                    MasterEntity = OBJ;
                    if (MCTEMP.ORDER_LIST.Count > 0)
                    {
                        OrderEntity = new EPR_T001();
                        OrderEntity = MCTEMP.ORDER_LIST[0];
                        if (MC.OPERATION_LIST != null) // Append operation if not exists in MC list.
                        {
                            if (MC.OPERATION_LIST.Where(x => x.order_no == POPUPEntityObject.order_no).ToList().Count == 0)
                            {
                                foreach (var item in MCTEMP.OPERATION_LIST)
                                {
                                    MC.OPERATION_LIST.Add(item);
                                }
                            }
                        }
                        else
                        {
                            MC.OPERATION_LIST = MCTEMP.OPERATION_LIST;
                        }

                        MOperationList = MC.OPERATION_LIST.Where(x => x.order_no == POPUPEntityObject.order_no).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).operation_no);
                        TheFilter = (o, prefix) => (((STD_LIST_BE)o).operation_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).operation_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        AS_OPERATIONS = new AutoSuggestTextViewModel<dynamic>(MOperationList, TheFilter, SuggestedValue, "operation_no", true);
                        AS_OPERATIONS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OPERATIONS.AutoSuggestVM.IsFreeTextAllowed = false;

                        MasterEntity.order_no = OrderEntity.order_no;
                        MasterEntity.ItemCode = OrderEntity.ItemCode;
                        MasterEntity.ItemName = OrderEntity.ItemName;
                        MasterEntity.location_Id = OrderEntity.location_Id;
                        MasterEntity.comp_code = OrderEntity.comp_code;
                        MasterEntity.routing_no = OrderEntity.routing_no;
                        MasterEntity.unit_code = OrderEntity.unit_code;
                        MasterEntity.store_code = OrderEntity.store_code;
                        MasterEntity.prev_batch = OrderEntity.prev_batch;

                        if (MOperationList.Count == 1)
                        {
                            MasterEntity.operation_no = MOperationList[0].operation_no;
                            MasterEntity.wc_code = MOperationList[0].wc_code;
                        }
                        else if (MOperationList.Exists(x => x.operation_no.Equals(MasterEntity.operation_no)) == false || string.IsNullOrWhiteSpace(MasterEntity.operation_no) == true)
                        {
                            MasterEntity.operation_no = null;
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertOrderNumberTemp(object InputValue)
        {
            try
            {
                List<STD_LIST_BE> MOperationList = new List<STD_LIST_BE>();
                EPR_T001 POPUPEntityObject = null;
                string Request = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0 && !string.IsNullOrWhiteSpace(Request))
                    {
                        try
                        {
                            POPUPEntityObject = MC.ORDER_LIST.Where(x => x.order_no == Request).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                #endregion
                #region Command Parameter Read Section
                if (POPUPEntityObject != null)
                {
                    EPR_T002 OBJ = new EPR_T002();
                    OBJ = MasterEntityTemp;
                    string Request2 = "EXECUTE_REFERENCE_ORDER" + "!@" + AppSessionState.client + "!@" + POPUPEntityObject.comp_code + "!@" + POPUPEntityObject.location_Id + "!@" + doc_cat_vm + "!@" + (Utilities.NullIf(REQUEST_PARA.doc_type) ?? "") + "!@" + Request + "!@" + (Utilities.NullIf(REQUEST_PARA.emp_id) ?? AppSessionState.EmpId);
                    MCTEMP = repository_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MCTEMP, Request2, "EPR_T002_BL", "PPC", "LoadAll", 0, "");
                    MasterEntityTemp = OBJ;
                    if (MCTEMP.ORDER_LIST.Count > 0)
                    {
                        OrderEntity = new EPR_T001();
                        OrderEntity = MCTEMP.ORDER_LIST[0];
                        if (MC.OPERATION_LIST != null) // Append operation if not exists in MC list.
                        {
                            if (MC.OPERATION_LIST.Where(x => x.order_no == POPUPEntityObject.order_no).ToList().Count == 0)
                            {
                                foreach (var item in MCTEMP.OPERATION_LIST)
                                {
                                    MC.OPERATION_LIST.Add(item);
                                }
                            }
                        }
                        else
                        {
                            MC.OPERATION_LIST = MCTEMP.OPERATION_LIST;
                        }
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).operation_no);
                        TheFilter = (o, prefix) => (((STD_LIST_BE)o).operation_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).operation_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        AS_OPERATIONS = new AutoSuggestTextViewModel<dynamic>(MC.OPERATION_LIST, TheFilter, SuggestedValue, "operation_no", true);
                        AS_OPERATIONS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OPERATIONS.AutoSuggestVM.IsFreeTextAllowed = false;

                        MasterEntityTemp.ItemCode = OrderEntity.ItemCode;
                        MasterEntityTemp.ItemName = OrderEntity.ItemName;
                        MasterEntityTemp.location_Id = OrderEntity.location_Id;
                        MasterEntityTemp.comp_code = OrderEntity.comp_code;
                        MasterEntityTemp.routing_no = OrderEntity.routing_no;
                        MasterEntityTemp.unit_code = OrderEntity.unit_code;
                        MasterEntityTemp.store_code = OrderEntity.store_code;
                        MasterEntityTemp.prev_batch = OrderEntity.prev_batch;
                        MasterEntityTemp.order_type = OrderEntity.order_type;
                        MasterEntityTemp.yield = OrderEntity.bal_qty;

                        if (MOperationList.Count == 1)
                        {
                            MasterEntityTemp.operation_no = MOperationList[0].operation_no;
                            MasterEntityTemp.wc_code = MOperationList[0].wc_code;
                        }
                        else if (MOperationList.Exists(x => x.operation_no.Equals(MasterEntityTemp.operation_no)) == false || string.IsNullOrWhiteSpace(MasterEntityTemp.operation_no) == true)
                        {
                            MasterEntityTemp.operation_no = null;
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertOrderNumberOld(object InputValue)
        {
            try
            {
                List<STD_LIST_BE> MOperationList = new List<STD_LIST_BE>();
                string Request = InputValue.ToString();
                #region Command Parameter Read Section
                if (!string.IsNullOrWhiteSpace(Request))
                {
                    var OrderEntityTemp = MC.ORDER_LIST.Where(x => x.order_no == Request).ToList();
                    if (OrderEntityTemp != null)
                    {
                        if (OrderEntityTemp.Count > 0)
                        {
                            var OrderEntity = OrderEntityTemp[0];
                            MasterEntity.order_no = Request;
                            if (!string.IsNullOrWhiteSpace(MasterEntity.order_no))
                            {
                                OrderEntity = new EPR_T001();
                                OrderEntity = MC.ORDER_LIST.Where(x => x.order_no == MasterEntity.order_no).ToList()[0];
                                MOperationList = MC.OPERATION_LIST.Where(x => x.order_no == MasterEntity.order_no).ToList();
                                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).operation_no);
                                TheFilter = (o, prefix) => (((STD_LIST_BE)o).operation_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).operation_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                                AS_OPERATIONS = new AutoSuggestTextViewModel<dynamic>(MOperationList, TheFilter, SuggestedValue, "operation_no", true);
                                AS_OPERATIONS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OPERATIONS.AutoSuggestVM.IsFreeTextAllowed = false;

                                MasterEntity.ItemCode = OrderEntity.ItemCode;
                                MasterEntity.ItemName = OrderEntity.ItemName;
                                MasterEntity.location_Id = OrderEntity.location_Id;
                                MasterEntity.comp_code = OrderEntity.comp_code;
                                MasterEntity.routing_no = OrderEntity.routing_no;
                                MasterEntity.unit_code = OrderEntity.unit_code;
                                MasterEntity.store_code = OrderEntity.store_code;
                                MasterEntity.order_type = OrderEntity.order_type;
                                MasterEntity.yield = OrderEntity.bal_qty;
                                if (MOperationList.Count == 1)
                                {
                                    MasterEntity.operation_no = MOperationList[0].operation_no;
                                    MasterEntity.wc_code = MOperationList[0].wc_code;
                                }
                                else if (MOperationList.Exists(x => x.operation_no.Equals(MasterEntity.operation_no)) == false || string.IsNullOrWhiteSpace(MasterEntity.operation_no) == true)
                                {
                                    MasterEntity.operation_no = null;
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertOrderNumberTempOld(object InputValue)
        {
            try
            {
                List<STD_LIST_BE> MOperationList = new List<STD_LIST_BE>();
                string Request = InputValue.ToString();
                #region Command Parameter Read Section
                if (!string.IsNullOrWhiteSpace(Request)) // for Temp Grid
                {
                    OrderEntity = new EPR_T001();
                    var OrderEntityVar = MC.ORDER_LIST.Where(x => x.order_no == Request).ToList();
                    if (OrderEntityVar != null)
                    {
                        if (OrderEntityVar.Count > 0)
                        {
                            OrderEntity = OrderEntityVar[0];
                            MOperationList = MC.OPERATION_LIST.Where(x => x.order_no == MasterEntityTemp.order_no).ToList();
                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).operation_no);
                            TheFilter = (o, prefix) => (((STD_LIST_BE)o).operation_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).operation_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                            AS_OPERATIONS = new AutoSuggestTextViewModel<dynamic>(MOperationList, TheFilter, SuggestedValue, "operation_no", true);
                            AS_OPERATIONS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OPERATIONS.AutoSuggestVM.IsFreeTextAllowed = false;

                            MasterEntityTemp.ItemCode = OrderEntity.ItemCode;
                            MasterEntityTemp.ItemName = OrderEntity.ItemName;
                            MasterEntityTemp.location_Id = OrderEntity.location_Id;
                            MasterEntityTemp.comp_code = OrderEntity.comp_code;
                            MasterEntityTemp.routing_no = OrderEntity.routing_no;
                            MasterEntityTemp.unit_code = OrderEntity.unit_code;
                            MasterEntityTemp.store_code = OrderEntity.store_code;
                            MasterEntityTemp.prev_batch = OrderEntity.prev_batch;
                            if (MOperationList.Count == 1)
                            {
                                MasterEntityTemp.operation_no = MOperationList[0].operation_no;
                                MasterEntityTemp.wc_code = MOperationList[0].wc_code;
                            }
                            else if (MOperationList.Exists(x => x.operation_no.Equals(MasterEntityTemp.operation_no)) == false || string.IsNullOrWhiteSpace(MasterEntityTemp.operation_no) == true)
                            {
                                MasterEntityTemp.operation_no = null;
                            }
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void ExecuteReference(object InputValue)
        {
            EntityChangeEnable = false;
            if (MasterEntity_List_Temp != null && MasterEntityTemp != null && NewRowCount > 0)
            {
                if (string.IsNullOrWhiteSpace(MasterEntityTemp.batch_no))
                {
                    MasterEntityTemp.batch_no = null;
                }
                if (string.IsNullOrWhiteSpace(MasterEntityTemp.prev_batch))
                {
                    MasterEntityTemp.prev_batch = null;
                }
                if (MasterEntity_List_Temp.Count > 0 && !string.IsNullOrWhiteSpace(MasterEntityTemp.prev_batch ?? MasterEntityTemp.batch_no) && MasterEntityTemp.operation_no == "10")
                {
                    if ((MasterEntityTemp.prev_batch ?? MasterEntityTemp.batch_no).Length > 4)
                    {
                        int numericValue;
                        if (Int32.TryParse((MasterEntityTemp.prev_batch ?? MasterEntityTemp.batch_no).Substring((MasterEntityTemp.prev_batch ?? MasterEntityTemp.batch_no).Length - 4), out numericValue))
                        {
                            int result = Convert.ToInt32((MasterEntityTemp.prev_batch ?? MasterEntityTemp.batch_no).Substring((MasterEntityTemp.prev_batch ?? MasterEntityTemp.batch_no).Length - 4));
                            result++;
                            for (int i = result; i < result + NewRowCount; i++)
                            {
                                EPR_T002 objNew = new EPR_T002();
                                MasterEntityTemp.CopyPropertiesTo<EPR_T002>(objNew);
                                if (!string.IsNullOrWhiteSpace(MasterEntityTemp.prev_batch ?? MasterEntityTemp.batch_no))
                                {
                                    objNew.batch_no = (MasterEntityTemp.prev_batch ?? MasterEntityTemp.batch_no).Remove((MasterEntityTemp.prev_batch ?? MasterEntityTemp.batch_no).Length - 4) + i.ToString().PadLeft(4, '0');
                                }
                                objNew.check = false;
                                MasterEntity_List.Add(objNew);
                            }
                        }
                        else
                        {
                            IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Last 6 digits of batch required numeric with 2 digits of Financial year and 4 digit numeric incremental number", this.Title); sms.ShowMessage();
                        }
                    }
                    else
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Batch Length is Short, minium 8 digit with last 6 digits include 2 digits of Financial year and 4 digit numeric incremental number required", this.Title); sms.ShowMessage();
                    }

                }
                else if (MasterEntity_List_Temp.Count > 0 && MasterEntityTemp.operation_no != "10")
                {
                    string Request = "EXECUTE_ORDER_BY_OPNO" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + MasterEntityTemp.order_no + "!@" + MasterEntityTemp.operation_no;
                    MCTEMP = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTEMP, Request, "EPR_T002_BL", "PPC", " ", 0, "");

                    if (MCTEMP.CONFIRMATION_LIST != null)
                    {
                        if (MCTEMP.CONFIRMATION_LIST.Count > 0)
                        {
                            MasterEntity_List.Clear();
                            foreach (var item in MCTEMP.CONFIRMATION_LIST)
                            {
                                EPR_T002 objNew = new EPR_T002();
                                MasterEntityTemp.CopyPropertiesTo<EPR_T002>(objNew);
                                objNew.check = false;
                                objNew.order_no = item.order_no;
                                objNew.unit_code = item.unit_code;
                                objNew.routing_no = item.routing_no;
                                objNew.barcode = item.barcode;
                                objNew.batch_no = item.batch_no;
                                objNew.operation_no = item.operation_no;
                                objNew.post_date = item.post_date;
                                objNew.add_date = item.add_date;
                                objNew.ItemCode = item.ItemCode;
                                objNew.ItemName = item.ItemName;
                                objNew.active = item.active;
                                objNew.yield = item.yield;
                                MasterEntity_List.Add(objNew);
                            }
                        }
                    }

                }
            }
            EntityChangeEnable = true;
        }
        private void SelectionChanged_MasterEntity(object InputValue)
        {
            if (!(InputValue == CollectionView.NewItemPlaceholder))
            {
                MasterEntity = (EPR_T002)InputValue;
                var OrderList = new List<EPR_T001>();
                if (MasterEntity.ItemCode == null)
                {
                    OrderList = MC.ORDER_LIST;
                }
                else
                {
                    OrderList = MC.ORDER_LIST.Where(x => x.ItemCode == MasterEntity.ItemCode).ToList();
                }
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((EPR_T001)x).order_no);
                TheFilter = (o, prefix) => (((EPR_T001)o).order_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ORDERS = new AutoSuggestTextViewModel<dynamic>(OrderList, TheFilter, SuggestedValue, "order_no", "order_no", true);
                AS_ORDERS.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ORDERS.AutoSuggestVM.IsFreeTextAllowed = false;

                var Operations = MC.OPERATION_LIST.Where(x => x.order_no == MasterEntity.order_no).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).operation_no);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).operation_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).operation_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OPERATIONS = new AutoSuggestTextViewModel<dynamic>(Operations, TheFilter, SuggestedValue, "operation_no", true);
                AS_OPERATIONS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OPERATIONS.AutoSuggestVM.IsFreeTextAllowed = false;
            }

        }
        private void SelectionChanged_MasterEntity_Temp(object InputValue)
        {
            if (!(InputValue == CollectionView.NewItemPlaceholder))
            {
                MasterEntityTemp = (EPR_T002)InputValue;
                var OrderList = new List<EPR_T001>();
                if (MasterEntity.ItemCode == null)
                {
                    OrderList = MC.ORDER_LIST;
                }
                else
                {
                    OrderList = MC.ORDER_LIST.Where(x => x.ItemCode == MasterEntityTemp.ItemCode).ToList();
                }
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((EPR_T001)x).order_no);
                TheFilter = (o, prefix) => (((EPR_T001)o).order_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ORDERS = new AutoSuggestTextViewModel<dynamic>(OrderList, TheFilter, SuggestedValue, "order_no", true);
                AS_ORDERS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ORDERS.AutoSuggestVM.IsFreeTextAllowed = true;

                var Operations = MC.OPERATION_LIST.Where(x => x.order_no == MasterEntityTemp.order_no).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).operation_no);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).operation_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).operation_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OPERATIONS = new AutoSuggestTextViewModel<dynamic>(Operations, TheFilter, SuggestedValue, "operation_no", true);
                AS_OPERATIONS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OPERATIONS.AutoSuggestVM.IsFreeTextAllowed = false;
            }
        }
        private void InsertOperation(object InputValue)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
                List<STD_LIST_BE> MOperationList = new List<STD_LIST_BE>();
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.OPERATION_LIST.Where(x => x.operation_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.order_no.Equals(MasterEntity.order_no, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null)
                {
                    if (!string.IsNullOrWhiteSpace(POPUPEntityObject.operation_no))
                    {
                        MasterEntity.operation_no = POPUPEntityObject.operation_no;
                        MasterEntity.wc_code = POPUPEntityObject.wc_code;
                        MasterEntity.control_key = POPUPEntityObject.control_key;
                        if (MasterEntity.operation_no == "10")
                        {
                            NoFirstOperation = false;
                        }
                        else
                        {
                            NoFirstOperation = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertOperationTemp(object InputValue)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
                List<STD_LIST_BE> MOperationList = new List<STD_LIST_BE>();
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.OPERATION_LIST.Where(x => x.operation_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.order_no.Equals(MasterEntityTemp.order_no, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (!string.IsNullOrWhiteSpace(POPUPEntityObject.operation_no))
                    {
                        MasterEntityTemp.operation_no = POPUPEntityObject.operation_no;
                        MasterEntityTemp.wc_code = POPUPEntityObject.wc_code;
                        MasterEntity.control_key = POPUPEntityObject.control_key;
                        if (MasterEntityTemp.operation_no == "10")
                        {
                            NoFirstOperation = false;
                        }
                        else
                        {
                            NoFirstOperation = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        #endregion
        #region EntityChangeNotification Section
        void Model_MasterEntityChange(object sender, EventArgs e) // NOTE: Deprecated
        {
            try
            {
                if (EntityChangeEnable == true)
                {
                    List<STD_LIST_BE> MOperationList = new List<STD_LIST_BE>();



                    if (sender.ToString() == "record_type" && !string.IsNullOrWhiteSpace(MasterEntity.record_type))
                    {
                        RecordTypeSelected = MC.RECORD_TYPE_LIST.Where(x => x.record_type == MasterEntity.record_type).ToList()[0];
                    }
                    if (sender.ToString() == "record_type" && !string.IsNullOrWhiteSpace(MasterEntityTemp.record_type))
                    {
                        RecordTypeSelected = MC.RECORD_TYPE_LIST.Where(x => x.record_type == MasterEntityTemp.record_type).ToList()[0];
                    }
                    if (sender.ToString() == "shift" && !string.IsNullOrWhiteSpace(MasterEntity.shift))
                    {
                        STD_LIST_BE shift_obj = MC.SHIFT_LIST.Where(x => x.shift_code == MasterEntity.shift).ToList()[0];
                        MasterEntity.total_time = shift_obj.shift_hrs;
                        MasterEntity.starttime = shift_obj.start_time;
                        MasterEntity.endtime = shift_obj.end_time;
                        MasterEntity.ac_duration = Convert.ToDecimal(shift_obj.shift_hrs);
                        if (MasterEntity.ac_duration.HasValue)
                        {
                            MasterEntity.ac_work = (MasterEntity.ac_duration * (MasterEntity.emp_no ?? 1));
                        }
                    }
                    if (sender.ToString() == "shift" && !string.IsNullOrWhiteSpace(MasterEntityTemp.shift))
                    {
                        STD_LIST_BE shift_obj = MC.SHIFT_LIST.Where(x => x.shift_code == MasterEntityTemp.shift).ToList()[0];
                        MasterEntityTemp.total_time = shift_obj.shift_hrs;
                        MasterEntityTemp.starttime = shift_obj.start_time;
                        MasterEntityTemp.endtime = shift_obj.end_time;
                        MasterEntityTemp.ac_duration = Convert.ToDecimal(shift_obj.shift_hrs);
                        if (MasterEntityTemp.ac_duration.HasValue)
                        {
                            MasterEntityTemp.ac_work = (MasterEntityTemp.ac_duration * (MasterEntityTemp.emp_no ?? 1));
                        }
                    }
                    if ((sender.ToString() == "starttime" || sender.ToString() == "endtime") && !string.IsNullOrWhiteSpace(MasterEntity.starttime) && !string.IsNullOrWhiteSpace(MasterEntity.endtime))
                    {
                        //DateTime dateTime1 = DateTime.ParseExact(MasterEntity.starttime, "HH:mm:ss", CultureInfo.InvariantCulture);
                        //DateTime dateTime2 = DateTime.ParseExact(MasterEntity.endtime, "HH:mm:ss", CultureInfo.InvariantCulture);
                        //MasterEntity.total_time = (dateTime2.TimeOfDay - dateTime1.TimeOfDay).ToString();
                        //MasterEntity.ac_duration = (dateTime2.TimeOfDay.Hours - dateTime1.TimeOfDay.Hours);
                    }
                    if ((sender.ToString() == "starttime" || sender.ToString() == "endtime") && !string.IsNullOrWhiteSpace(MasterEntityTemp.starttime) && !string.IsNullOrWhiteSpace(MasterEntityTemp.endtime))
                    {
                        //DateTime dateTime1 = DateTime.ParseExact(MasterEntityTemp.starttime, "HH:mm:ss", CultureInfo.InvariantCulture);
                        //DateTime dateTime2 = DateTime.ParseExact(MasterEntityTemp.endtime, "HH:mm:ss", CultureInfo.InvariantCulture);
                        //MasterEntityTemp.total_time = (dateTime2.TimeOfDay.Hours - dateTime1.TimeOfDay.Hours).ToString();
                        //MasterEntityTemp.ac_duration = (dateTime2.TimeOfDay.Hours - dateTime1.TimeOfDay.Hours);
                    }
                    if (sender.ToString() == "ac_duration" && MasterEntity.ac_duration.HasValue)
                    {
                        MasterEntity.ac_work = MasterEntity.ac_work = (MasterEntity.ac_duration * (MasterEntity.emp_no ?? 1));
                    }
                    if (sender.ToString() == "ac_duration" && MasterEntityTemp.ac_duration.HasValue)
                    {
                        MasterEntityTemp.ac_work = MasterEntityTemp.ac_work = (MasterEntityTemp.ac_duration * (MasterEntityTemp.emp_no ?? 1));
                    }
                    if (sender.ToString() == "ac_duration_uom" && !string.IsNullOrWhiteSpace(MasterEntity.ac_duration_uom))
                    {
                        MasterEntity.ac_work_uom = MasterEntity.ac_duration_uom;
                    }
                    if (sender.ToString() == "ac_duration_uom" && !string.IsNullOrWhiteSpace(MasterEntityTemp.ac_duration_uom))
                    {
                        MasterEntityTemp.ac_work_uom = MasterEntityTemp.ac_duration_uom;
                    }
                    if (sender.ToString() == "prod_dt" && !string.IsNullOrWhiteSpace(MasterEntity.shift))
                    {
                        MasterEntity.execution_start = MasterEntity.prod_dt;
                        MasterEntity.execution_finish = MasterEntity.prod_dt;
                        MasterEntity.post_date = MasterEntity.prod_dt;
                    }
                    if (sender.ToString() == "prod_dt" && !string.IsNullOrWhiteSpace(MasterEntityTemp.shift))
                    {
                        MasterEntityTemp.execution_start = MasterEntityTemp.prod_dt;
                        MasterEntityTemp.execution_finish = MasterEntityTemp.prod_dt;
                        MasterEntityTemp.post_date = MasterEntityTemp.prod_dt;
                    }
                    //if (sender.ToString() == "PartyId" && !string.IsNullOrWhiteSpace(MasterEntity.PartyId) && MC.Customer.Count > 0)
                    //{
                    //    MasterEntity.PartyNm = MC.Customer.Where(x => x.PartyId == MasterEntity.PartyId).ToList()[0].PartyNm;
                    //}
                    //if (sender.ToString() == "PartyId" && !string.IsNullOrWhiteSpace(MasterEntityTemp.PartyId) && MC.Customer.Count > 0)
                    //{
                    //    MasterEntityTemp.PartyNm = MC.Customer.Where(x => x.PartyId == MasterEntityTemp.PartyId).ToList()[0].PartyNm;
                    //}

                }
            }
            catch (Exception ex)
            { }
        }
        private void CollectionChangedNotifyForExecution(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (EPR_T002 item in e.NewItems)
                    {
                        item.doc_cat = this.doc_cat_vm;
                        item.doc_type = doc_cat_vm;
                        item.conf_type = item.conf_type ?? "P";
                        item.record_type = item.record_type ?? "04"; // NOTE: fix this value as per transaction
                        item.ts_code = this.ts_code_vm;
                        item.add_by = AppSessionState.UserID;
                        item.client = AppSessionState.client;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        item.userid = AppSessionState.UserID;
                        item.active = true;
                        item.emp_id = item.emp_id ?? AppSessionState.EmpId;
                        item.emp_no = 1;
                        item.prod_dt = item.prod_dt ?? DateTime.UtcNow;
                        item.entry_dt = item.entry_dt ?? DateTime.UtcNow;
                        item.post_date = item.post_date ?? DateTime.UtcNow;
                        item.execution_start = item.execution_start ?? DateTime.UtcNow;
                        item.execution_finish = item.execution_finish ?? DateTime.UtcNow;
                        item.operation_no = item.operation_no ?? MasterEntityTemp.operation_no;
                        item.wc_code = item.wc_code ?? MasterEntityTemp.wc_code;
                        item.shift = item.shift ?? MasterEntityTemp.shift;
                        item.shift_incharge = item.shift_incharge ?? MasterEntityTemp.shift_incharge;
                        item.m_operator = item.m_operator ?? MasterEntityTemp.m_operator;
                        item.ac_duration = item.ac_duration ?? MasterEntityTemp.ac_duration;
                        item.ac_duration_uom = item.ac_duration_uom ?? MasterEntityTemp.ac_duration_uom;

                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                { }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                { }
                if (e.Action == NotifyCollectionChangedAction.Move)
                { }
            }
            catch (Exception ex)
            { }
        }
        #endregion
        #region Command_Function

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
        private void WindowEventCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    //LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                }
                else
                {

                    LoadInitialData();

                    ConfirmationTypesList.Add(new ConfirmationTypes { conf_type = "P", conf_desc = "Partial Execution" });
                    ConfirmationTypesList.Add(new ConfirmationTypes { conf_type = "F", conf_desc = "Final Execution" });
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ConfirmationTypes)x).conf_type);
                    TheFilter = (o, prefix) => (((ConfirmationTypes)o).conf_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ConfirmationTypes)o).conf_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    AS_INPUT_TYPE = new AutoSuggestTextViewModel<dynamic>(ConfirmationTypesList, TheFilter, SuggestedValue, "conf_type", true);
                    AS_INPUT_TYPE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_INPUT_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;
                    DefaultValues();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        #endregion
        #region FilterMethods
        private string _FilterString_Search;
        public string FilterString_Search
        {
            get { return _FilterString_Search; }
            set
            {
                _FilterString_Search = value;
                RaisePropertyChanged("FilterString_Search");
                FilterProductionDataGrid();
            }
        }
        private void FilterProductionDataGrid()
        {
            try
            {
                if (MasterEntity_List != null && MasterEntity_List.Count > 0)
                {
                    ProductionCollection = CollectionViewSource.GetDefaultView(MasterEntity_List);
                    ProductionCollection.Filter = item => (((EPR_T002)item).batch_no ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).wc_code ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).ItemCode ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).ItemName ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).barcode ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).prod_dt.ToString() ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).order_no ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).operation_no ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).shift ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).yield.ToString() ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).scrap_qty.ToString() ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).rejection_qty.ToString() ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).unit_code ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).var_reson ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).m_operator ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).shift_incharge ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).location_Id ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).doc_no ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower())
                        || (((EPR_T002)item).record_type ?? "").ToString().ToLower().Contains(FilterString_Search.ToLower());

                    //|| (((EPR_T002)item).store_code ?? "").Contains(FilterString_Search)

                    ProductionCollection.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }


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
            if (_BACKFLIP_COLLECTION != null)
            {
                _BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool Filter_BackFlip(object obj)
        {
            var data = obj as EPR_T002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BackFlip))
                {
                    return (data.order_no != null && data.order_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.entry_dt.ToString() != null && data.entry_dt.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.prod_dt.ToString() != null && data.prod_dt.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.m_operator != null && data.m_operator.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.record_type != null && data.record_type.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()));
                }
                return true;
            }
            return false;

        }


        #endregion
    }
}
