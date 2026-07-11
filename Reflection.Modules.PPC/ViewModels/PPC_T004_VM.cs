using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.BusinessEntity.Production;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Collections.Specialized;
using Reflection.Presentation.Common;

namespace Reflection.Modules.PPC.ViewModels
{
    public class PPC_T004_VM : WorkspaceViewModel<EPR_T001>
    {
        #region Private Local Variable Declaration
        IShowMessageViewService sms;
        private bool isNewRecord = true;
        private bool _EntityChangeEnable { get; set; }
        private bool EntityChangeEnable
        {
            get { return _EntityChangeEnable; }
            set
            {
                if (_EntityChangeEnable != value)
                { _EntityChangeEnable = value; RaisePropertyChanged("EntityChangeEnable"); }
            }
        }
        private string ts_code_vm { get; set; }
        private string doc_no_vm { get; set; }
        private string doc_cat_vm { get; set; }
        private string SelectedReferenceDocuments;

        WebServiceRepository<EPR_T001> REPO = new WebServiceRepository<EPR_T001>();
        WebServiceRepository<MultipleContext_EPR_T001> REPO_MC = new WebServiceRepository<MultipleContext_EPR_T001>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_EPR_T001 _MC = new MultipleContext_EPR_T001();
        public MultipleContext_EPR_T001 MC
        {
            get { return _MC; }
            set { if (_MC != value) { _MC = value; RaisePropertyChanged("MC"); } }
        }
        private MultipleContext_EPR_T001 _MCTemp = new MultipleContext_EPR_T001();
        public MultipleContext_EPR_T001 MCTemp
        {
            get { return _MCTemp; }
            set { if (_MCTemp != value) { _MCTemp = value; RaisePropertyChanged("MCTemp"); } }
        }
        List<PPC_T004_A> ReferenceDocFilteredList = new List<PPC_T004_A>(); // Reference document filtered collection store here.

        private EPR_T001 _MasterEntity;
        public EPR_T001 MasterEntity
        {
            get { return _MasterEntity; }
            set { if (_MasterEntity != value) { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); } }
        }
        private ObservableCollection<EPR_T001_A> _EPR_T001_A_OBJ_OC;
        public ObservableCollection<EPR_T001_A> EPR_T001_A_OBJ_OC
        {
            get
            {
                return _EPR_T001_A_OBJ_OC;
            }
            set
            {
                if (_EPR_T001_A_OBJ_OC != value)
                {
                    _EPR_T001_A_OBJ_OC = value;
                    EPR_T001_A_OBJ_OC.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
                    RaisePropertyChanged("EPR_T001_A_OBJ_OC");
                }
            }
        }
        private EPR_T001_A _EPR_T001_A_OBJ;
        public EPR_T001_A EPR_T001_A_OBJ
        {
            get { return _EPR_T001_A_OBJ; }
            set { if (_EPR_T001_A_OBJ != value) { _EPR_T001_A_OBJ = value; RaisePropertyChanged("EPR_T001_A_OBJ"); } }
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
        private ICollectionView _ReferenceDocCollection;
        public ICollectionView ReferenceDocCollection
        {
            get { return _ReferenceDocCollection; }
            set { _ReferenceDocCollection = value; RaisePropertyChanged("ReferenceDocCollection"); }
        }
        private ICollectionView _DataGridCollectionBackFlip;
        public ICollectionView DataGridCollectionBackFlip
        {
            get { return _DataGridCollectionBackFlip; }
            set { _DataGridCollectionBackFlip = value; RaisePropertyChanged("DataGridCollectionBackFlip"); }
        }
        private ICollectionView _ProductionOrderChart;
        public ICollectionView ProductionOrderChart
        {
            get { return _ProductionOrderChart; }
            set { _ProductionOrderChart = value; RaisePropertyChanged("ProductionOrderChart"); }
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
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }

        }
        #endregion
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PPC_T004_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
        private AutoSuggestTextViewModel<dynamic> _ASDocType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocType
        {
            get { return _ASDocType; }
            set
            {
                if (_ASDocType != value)
                {
                    _ASDocType = value; RaisePropertyChanged("ASDocType");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASItem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItem
        {
            get { return _ASItem; }
            set
            {
                if (_ASItem != value)
                {
                    _ASItem = value; RaisePropertyChanged("ASItem");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASLocationID { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLocationID
        {
            get { return _ASLocationID; }
            set
            {
                if (_ASLocationID != value)
                {
                    _ASLocationID = value; RaisePropertyChanged("ASLocationID");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASPlant_PLAN { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPlant_PLAN
        {
            get { return _ASPlant_PLAN; }
            set
            {
                if (_ASPlant_PLAN != value)
                {
                    _ASPlant_PLAN = value; RaisePropertyChanged("ASPlant_PLAN");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASUOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUOM
        {
            get { return _ASUOM; }
            set
            {
                if (_ASUOM != value)
                {
                    _ASUOM = value; RaisePropertyChanged("ASUOM");
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
        private AutoSuggestTextViewModel<dynamic> _ASShift { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASShift
        {
            get { return _ASShift; }
            set
            {
                if (_ASShift != value)
                {
                    _ASShift = value; RaisePropertyChanged("ASShift");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASProfitCenter { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASProfitCenter
        {
            get { return _ASProfitCenter; }
            set
            {
                if (_ASProfitCenter != value)
                {
                    _ASProfitCenter = value; RaisePropertyChanged("ASProfitCenter");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASCostCenter { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCostCenter
        {
            get { return _ASCostCenter; }
            set
            {
                if (_ASCostCenter != value)
                {
                    _ASCostCenter = value; RaisePropertyChanged("ASCostCenter");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASRouting { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRouting
        {
            get { return _ASRouting; }
            set
            {
                if (_ASRouting != value)
                {
                    _ASRouting = value; RaisePropertyChanged("ASRouting");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASBOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBOM
        {
            get { return _ASBOM; }
            set
            {
                if (_ASBOM != value)
                {
                    _ASBOM = value; RaisePropertyChanged("ASBOM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASEmployee { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEmployee
        {
            get { return _ASEmployee; }
            set
            {
                if (_ASEmployee != value)
                {
                    _ASEmployee = value; RaisePropertyChanged("ASEmployee");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASStoreCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASStoreCode
        {
            get { return _ASStoreCode; }
            set
            {
                if (_ASStoreCode != value)
                {
                    _ASStoreCode = value; RaisePropertyChanged("ASStoreCode");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ORDER_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ORDER_TYPE
        {
            get { return _AS_ORDER_TYPE; }
            set
            {
                if (_AS_ORDER_TYPE != value)
                {
                    _AS_ORDER_TYPE = value; RaisePropertyChanged("AS_ORDER_TYPE");
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
        private AutoSuggestTextViewModel<dynamic> _AS_CONTROL_KEY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CONTROL_KEY
        {
            get { return _AS_CONTROL_KEY; }
            set
            {
                if (_AS_CONTROL_KEY != value)
                {
                    _AS_CONTROL_KEY = value; RaisePropertyChanged("AS_CONTROL_KEY");
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
                    if (SourceName == "wc_code")
                    {
                        if (EPR_T001_A_OBJ != null && MC.WorkCenter.Count > 0)
                        {
                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_P)x).wc_code ?? "");
                            TheFilter = (o, prefix) => (((PPC_M001_P)o).wc_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((PPC_M001_P)o).machinedesc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            AS_WORK_CENTER = new AutoSuggestTextViewModel<dynamic>(MC.WorkCenter.Where(x => x.location_Id == EPR_T001_A_OBJ.location_id).ToList(), TheFilter, SuggestedValue, "wc_code", "wc_code", true);
                            AS_WORK_CENTER.AutoSuggestVM.IsEmptyValueAllowed = true;
                        }
                        ASDefault = AS_WORK_CENTER;
                    }
                    else if (SourceName == "control_key")
                    { ASDefault = AS_CONTROL_KEY; }
                    else if (SourceName == "location_id")
                    { ASDefault = ASPlant_PLAN; }
                    else if (SourceName == "op_code")
                    { ASDefault = AS_OPERATIONS; }


                }
            }
        }

        #endregion
        #region Relay Command
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdReferenceDocumentSelection { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdLoadBackFlipData { get; private set; }
        public RelayCommand<object> cmdProductionOrderChart { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_EPR_T001_A { get; private set; }
        public RelayCommand<object> cmdExecuteReferenceDocuments { get; private set; }
        public RelayCommand<object> cmdOperation { get; private set; }
        public RelayCommand<object> cmdInsertItemCode { get; private set; }
        public RelayCommand<object> cmdInsertProdcutionPlant { get; private set; }
        public RelayCommand<object> cmdInsertStoreCode { get; private set; }
        public RelayCommand<object> cmdOperationEntityRowDelete { get; private set; }
        public RelayCommand<object> cmdInsertRouting { get; private set; }
        #endregion

        #region Abstract Command
        protected override void OnCreateAction(InquiryActionResult<EPR_T001> result)
        {
            MasterEntity = new EPR_T001();
            EPR_T001_A_OBJ = new EPR_T001_A();
            EPR_T001_A_OBJ_OC = new ObservableCollection<EPR_T001_A>();
            EPR_T001_A_OBJ_OC.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
            DefaultValues();
            isNewRecord = true;
            if (MC.DocumentTypes.Count > 0)
            {
                if (MC.DocumentTypes.Where(x => x.doc_type == doc_cat_vm).ToList().Count > 0)
                {
                    MasterEntity.ind_batch = MC.DocumentTypes.Where(x => x.doc_type == doc_cat_vm).ToList()[0].ind_batch;
                }
                else
                {
                    MasterEntity.ind_batch = "A";
                }
            }
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
        }
        protected override void OnDiscardAction(InquiryActionResult<EPR_T001> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<EPR_T001> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<EPR_T001> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<EPR_T001> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<EPR_T001> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<EPR_T001> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<EPR_T001> result)
        {
            CursorControl.SetBusyState();
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.XmlDataDocument_EPR_T001_A = obj.ObjectToXML(EPR_T001_A_OBJ_OC);

                    if (isNewRecord == true)
                    {
                        MasterEntity = REPO.SaveWithReturnDomainObject<EPR_T001>(MasterEntity, "Production_Order_STD", "Production");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = REPO.UpdateWithReturnDomainObject<EPR_T001>(MasterEntity, "Production_Order_STD", "Production");
                    }


                    Logging();
                    SetBusinessEntitiesAfterLoad("Save", "");
                    RemoveSelectedReferenceDocuments();
                    isNewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                    Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
                    if (MasterEntity.order_no != null || MasterEntity.order_no != "")
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok;
                        sms.Caption = "Message";
                        sms.Text = String.Format("Record saved Successfully ........");
                        sms.ShowMessage();
                    }
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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XmlDataDocument_EPR_T001_A != null)
            {
                EPR_T001_A_OBJ_OC.Clear();
                EPR_T001_A_OBJ_OC = (ObservableCollection<EPR_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_EPR_T001_A, MC.OperationEntity);
            }
            else
            {
                MC.OperationEntity = new ObservableCollection<EPR_T001_A>();
            }

            MasterEntity.ts_code = ts_code_vm;
        }

        #endregion
        #region Constructor
        public PPC_T004_VM(string ts_code, string doc_cat) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            EPR_T001.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MultipleContext_EPR_T001();
            MCTemp = new MultipleContext_EPR_T001();
            RequestPara = new RequestParameters();
            MasterEntity = new EPR_T001();
            EPR_T001_A_OBJ = new EPR_T001_A();
            EPR_T001_A_OBJ_OC = new ObservableCollection<EPR_T001_A>();
            EPR_T001_A_OBJ_OC.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
            sms = this.GetViewService<IShowMessageViewService>();
            InitializeCommands();
        }
        public PPC_T004_VM(string ts_code, string doc_cat, string doc_no) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            EPR_T001.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MultipleContext_EPR_T001();
            MCTemp = new MultipleContext_EPR_T001();
            RequestPara = new RequestParameters();
            MasterEntity = new EPR_T001();
            EPR_T001_A_OBJ = new EPR_T001_A();
            EPR_T001_A_OBJ_OC = new ObservableCollection<EPR_T001_A>();
            EPR_T001_A_OBJ_OC.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
            sms = this.GetViewService<IShowMessageViewService>();
            InitializeCommands();
        }
        #endregion
        #region Standard Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + AppSessionState.EmpId;
                MC = REPO_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MC, Request, "Production_Order_STD", "Production", " ", 0, "");

                #region Autosuggest

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M013_P)x).doc_type);
                TheFilter = (o, prefix) => (((SYS_M013_P)o).doc_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M013_P)o).doc_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDocType = new AutoSuggestTextViewModel<dynamic>(MC.DocumentTypes, TheFilter, SuggestedValue, "doc_type", true);
                ASDocType.AutoSuggestVM.IsEmptyValueAllowed = false; ASDocType.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P1)x).ItemCode);
                TheFilter = (o, prefix) => (((ADM_M022_P1)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M022_P1)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASItem = new AutoSuggestTextViewModel<dynamic>(MC.ItemMaster, TheFilter, SuggestedValue, "ItemCode", true);
                ASItem.AutoSuggestVM.IsEmptyValueAllowed = false; ASItem.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM, TheFilter, SuggestedValue, "unit_code", true);
                ASUOM.AutoSuggestVM.IsEmptyValueAllowed = false; ASUOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASLocationID = new AutoSuggestTextViewModel<dynamic>((List<ADM_M003>)AppSessionState.ADM_M003_List, TheFilter, SuggestedValue, "location_Id", true);
                ASLocationID.AutoSuggestVM.IsEmptyValueAllowed = false; ASLocationID.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPlant_PLAN = new AutoSuggestTextViewModel<dynamic>((List<ADM_M003>)AppSessionState.ADM_M003_List, TheFilter, SuggestedValue, "location_Id", true);
                ASPlant_PLAN.AutoSuggestVM.IsEmptyValueAllowed = true; ASPlant_PLAN.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M042_P)x).shift);
                TheFilter = (o, prefix) => (((ADM_M042_P)o).shift ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASShift = new AutoSuggestTextViewModel<dynamic>(MC.ShiftList, TheFilter, SuggestedValue, "shift", true);
                ASShift.AutoSuggestVM.IsEmptyValueAllowed = true; ASShift.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASEmployee = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeList, TheFilter, SuggestedValue, "EmpId", true);
                ASEmployee.AutoSuggestVM.IsEmptyValueAllowed = true; ASEmployee.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M025)x).t_status);
                TheFilter = (o, prefix) => (((SYS_M025)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M025)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASStatus = new AutoSuggestTextViewModel<dynamic>(MC.StatusList, TheFilter, SuggestedValue, "t_status", true);
                ASStatus.AutoSuggestVM.IsEmptyValueAllowed = false; ASStatus.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M020_P)x).profit_center);
                TheFilter = (o, prefix) => (((ACC_M020_P)o).profit_center ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M020_P)o).profit_center_Desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASProfitCenter = new AutoSuggestTextViewModel<dynamic>(MC.ProfitCenterList, TheFilter, SuggestedValue, "profit_center", true);
                ASProfitCenter.AutoSuggestVM.IsEmptyValueAllowed = true; ASProfitCenter.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M019_P)x).cost_center);
                TheFilter = (o, prefix) => (((ACC_M019_P)o).cost_center ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M019_P)o).cost_center_Desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCostCenter = new AutoSuggestTextViewModel<dynamic>(MC.CostCenterList, TheFilter, SuggestedValue, "cost_center", true);
                ASCostCenter.AutoSuggestVM.IsEmptyValueAllowed = true; ASCostCenter.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M019_P)x).cost_center);
                TheFilter = (o, prefix) => (((ACC_M019_P)o).cost_center ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M019_P)o).cost_center_Desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCostCenter = new AutoSuggestTextViewModel<dynamic>(MC.CostCenterList, TheFilter, SuggestedValue, "cost_center", true);
                ASCostCenter.AutoSuggestVM.IsEmptyValueAllowed = true; ASCostCenter.AutoSuggestVM.IsFreeTextAllowed = false;



                List<ORDER_TYPE> OT_LIST = new List<ORDER_TYPE>();
                ORDER_TYPE OT = new ORDER_TYPE();
                OT.order_type = "N";
                OT.order_type_name = "New Order";
                OT_LIST.Add(OT);
                ORDER_TYPE OT2 = new ORDER_TYPE();
                OT2.order_type = "R";
                OT2.order_type_name = "Rework Order";
                OT_LIST.Add(OT2);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ORDER_TYPE)x).order_type);
                TheFilter = (o, prefix) => (((ORDER_TYPE)o).order_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ORDER_TYPE)o).order_type_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ORDER_TYPE = new AutoSuggestTextViewModel<dynamic>(OT_LIST, TheFilter, SuggestedValue, "order_type", true);
                AS_ORDER_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ORDER_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M051)x).control_key ?? "");
                TheFilter = (o, prefix) => (((SYS_M051)o).control_key ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((SYS_M051)o).control_key_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_CONTROL_KEY = new AutoSuggestTextViewModel<dynamic>(MC.ControlKeyMaster, TheFilter, SuggestedValue, "control_key", "control_key", true);
                AS_CONTROL_KEY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_CONTROL_KEY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M002)x).op_code);
                TheFilter = (o, prefix) => (((PPC_M002)o).op_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PPC_M002)o).op_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OPERATIONS = new AutoSuggestTextViewModel<dynamic>(MC.OperationList, TheFilter, SuggestedValue, "op_code", "op_code", true);
                AS_OPERATIONS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OPERATIONS.AutoSuggestVM.IsFreeTextAllowed = false;

                #endregion
                if (MC.DocumentTypes.Count > 0)
                {
                    if (MC.DocumentTypes.Where(x => x.doc_type == doc_cat_vm).ToList().Count > 0)
                    {
                        MasterEntity.ind_batch = MC.DocumentTypes.Where(x => x.doc_type == doc_cat_vm).ToList()[0].ind_batch;
                    }
                    else
                    {
                        MasterEntity.ind_batch = "A";
                    }
                }

                ReferenceDocCollection = CollectionViewSource.GetDefaultView(MC.REF_DOC_LIST);
                ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                List<ADM_M003> LocationList = ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(item => item.comp_code == AppSessionState.OBJ_COMPANY.comp_code).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASLocationID = new AutoSuggestTextViewModel<dynamic>(LocationList, TheFilter, SuggestedValue, "location_Id", true);
                ASLocationID.AutoSuggestVM.IsEmptyValueAllowed = true;
                if (LocationList.Count == 1)
                {
                    MasterEntity.location_Id = LocationList[0].location_Id;
                }
                else if (LocationList.Exists(x => x.location_Id.Equals(MasterEntity.location_Id)) == false || string.IsNullOrWhiteSpace(MasterEntity.location_Id) == true)
                {
                    MasterEntity.location_Id = null;
                }

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
                SelectedTabControlIndex = 0;
                EPR_T001 POPUPEntityObject = null;
                SelectedReferenceDocuments = null;
                string Request;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MCTemp.BackFlipList.Where(x => x.order_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<EPR_T001>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<EPR_T001>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    SelectedReferenceDocuments = POPUPEntityObject.id.ToString();
                    Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + POPUPEntityObject.order_no;
                    MCTemp = REPO_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTemp, Request, "Production_Order_STD", "Production", " ", 0, "");

                    if (MCTemp.MasterEntity.Count > 0)
                    {
                        MasterEntity = MCTemp.MasterEntity[0];
                        EPR_T001_A_OBJ_OC = MCTemp.OperationEntity;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M030_P)x).plan_no);
                        TheFilter = (o, prefix) => (((QMS_M030_P)o).plan_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((QMS_M030_P)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASRouting = new AutoSuggestTextViewModel<dynamic>(MCTemp.RoutingList, TheFilter, SuggestedValue, "plan_no", true);
                        ASRouting.AutoSuggestVM.IsEmptyValueAllowed = false; ASRouting.AutoSuggestVM.IsFreeTextAllowed = false;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENG_T001_P)x).bom_no);
                        TheFilter = (o, prefix) => (((ENG_T001_P)o).bom_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ENG_T001_P)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASBOM = new AutoSuggestTextViewModel<dynamic>(MCTemp.BOMList, TheFilter, SuggestedValue, "bom_no", true);
                        ASBOM.AutoSuggestVM.IsEmptyValueAllowed = false; ASBOM.AutoSuggestVM.IsFreeTextAllowed = false;

                    }

                }
                MasterEntity.ts_code = ts_code_vm;
                isNewRecord = false;
                EntityChangeEnable = true;
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void InitializeCommands()
        {
            cmdExecuteReferenceDocuments = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteReferenceDocuments(items); });
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEventCall(items); });
            cmdReferenceDocumentSelection = new RelayCommand<object>(items => { if (items == null) { return; } CollectSelectedReferenceDocuments(items); });
            cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items); });
            cmdLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });
            cmdSelectionChanged_EPR_T001_A = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_EPR_T001_A(items); });
            cmdOperation = new RelayCommand<object>(items => { if (items == null) { return; } InsertOperation(items); });
            cmdInsertItemCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertItemCode(items); });
            cmdInsertProdcutionPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertProdcutionPlant(items); });
            cmdInsertStoreCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertStoreCode(items); });
            cmdOperationEntityRowDelete = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteOperationEntityRow(cmdPara); });
            cmdInsertRouting = new RelayCommand<object>(items => { if (items == null) { return; } InsertRouting(items); });
        }
        private void DefaultValues()
        {
            try
            {
                EntityChangeEnable = true;
                MasterEntity.doc_cat = this.doc_cat_vm;
                MasterEntity.doc_type = doc_cat_vm;
                MasterEntity.order_type = "N";
                MasterEntity.t_status = "001";
                MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                MasterEntity.active = true;
                MasterEntity.doc_date = DateTime.UtcNow;
                MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;

                DateTime d = DateTime.UtcNow;
                d = d.AddMonths(-1);
                RequestPara.FromDate = d;
                RequestPara.ToDate = DateTime.UtcNow;
                RequestPara.active = true;
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
            foreach (var o in EPR_T001_A_OBJ_OC)
            {
                int flag = 0;
                if (o.id == 0)
                {
                    foreach (var p in EPR_T001_A_OBJ_OC)
                    {
                        if (o.line_id == p.line_id && (o.operation_no?.ToString() ?? "") == (p.operation_no?.ToString() ?? ""))
                        {
                            flag++;
                        }
                    }
                    if (flag > 1)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Duplicate Operation Sequence and number cannot be Allowed or 0 for the item {0} and Parameter {1}", o.line_id, o.operation_desc); sms.ShowMessage();
                        return false;
                    }
                }
                if (!o.line_id.HasValue || string.IsNullOrWhiteSpace(o.operation_no) || o.line_id == 0 || string.IsNullOrWhiteSpace(o.location_id))
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Operation Sequence and number cannot be null or 0 for the item {0} and Parameter {1}", o.line_id, o.operation_desc); sms.ShowMessage();
                    return false;
                }
            }
            if (EPR_T001_A_OBJ_OC == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Operation Data required.");
                showMessageService.ShowMessage();

                return false;
            }
            if (EPR_T001_A_OBJ_OC != null)
            {
                if (EPR_T001_A_OBJ_OC.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Operation Data required.");
                    showMessageService.ShowMessage();
                    return false;
                }

            }
            if (!MasterEntity.doc_date.HasValue)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Order Document Date required.");
                showMessageService.ShowMessage();

                return false;
            }
            if (!MasterEntity.start_dt.HasValue)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Manufacturing Start Date required.");
                showMessageService.ShowMessage();

                return false;
            }
            if (!MasterEntity.end_dt.HasValue)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Manufacturing Finish Date required.");
                showMessageService.ShowMessage();

                return false;
            }
            if (!MasterEntity.sch_start_date.HasValue)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Manufacturing Scheduled Start Date required.");
                showMessageService.ShowMessage();

                return false;
            }
            if (!MasterEntity.sch_end_date.HasValue)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Manufacturing Scheduled Finish Date required.");
                showMessageService.ShowMessage();

                return false;
            }
            if (MasterEntity.routing_no == null || MasterEntity.routing_no == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Routing Information Is Required");
                showMessageService.ShowMessage();

                return false;
            }
            if (MasterEntity.bom_no == null || MasterEntity.bom_no == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Bill of Material is Required");
                showMessageService.ShowMessage();

                return false;
            }
            if (MasterEntity.doc_type == null || MasterEntity.doc_type == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Order Type is Required");
                showMessageService.ShowMessage();

                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.store_code))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Store Core is Required");
                showMessageService.ShowMessage();

                return false;
            }
            return true;
        }
        private void RemoveSelectedReferenceDocuments()
        {
            try
            {
                if (SelectedReferenceDocuments != null)
                {
                    List<string> DocList = SelectedReferenceDocuments.Split(',').ToList();
                    foreach (var item in DocList)
                    {
                        MC.REF_DOC_LIST.RemoveAll(X => X.order_no.ToString() == item);
                    }
                    ReferenceDocCollection = CollectionViewSource.GetDefaultView(MC.REF_DOC_LIST);
                    ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void CollectSelectedReferenceDocuments(object InputValue)
        {
            try
            {
                STD_LIST_BE POPUPEntityObject = null;
                SelectedReferenceDocuments = null;
                string Request;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.REF_DOC_LIST.Where(x => x.search_key1.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    SelectedReferenceDocuments = POPUPEntityObject.order_no.ToString();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void SelectionChanged_EPR_T001_A(object InputValue)
        {
            try
            {
                EPR_T001_A_OBJ = (EPR_T001_A)InputValue;
            }
            catch (Exception ex) { }
        }
        private void LoadBackFlipData(object InputValue)
        {
            try
            {
                EntityChangeEnable = false;
                string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + RequestPara.comp_code + "!@" + RequestPara.location_Id + "!@" + doc_cat_vm + "!@" + (Utilities.NullIf(RequestPara.doc_type) ?? "") + "!@" + (Utilities.NullIf(RequestPara.t_status) ?? "") + "!@" + RequestPara.active + "!@" + (Utilities.NullIf(RequestPara.EmpId) ?? AppSessionState.EmpId) + "!@" + Utilities.NullIf(RequestPara.PartyId) + "!@" + Convert.ToDateTime(RequestPara.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(RequestPara.ToDate).ToString("MM/dd/yyyy");
                MCTemp = REPO_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, Request, "Production_Order_STD", "Production", "LoadAll", 0, "");

                DataGridCollectionBackFlip = CollectionViewSource.GetDefaultView(MCTemp.BackFlipList.ToList());
                DataGridCollectionBackFlip.Filter = new Predicate<object>(Filter_BackFlip);
                EntityChangeEnable = true;
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }

        #endregion
        #region EntityChangeNotification Section
        void Model_MasterEntityChange(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {

                    //if (sender.ToString() == "comp_code")
                    //{

                    //}
                    //if (sender.ToString() == "location_Id" && string.IsNullOrWhiteSpace(MasterEntity.location_Id) == false)
                    //{

                    //}
                    //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        #endregion
        #region Command_Function
        private void ExecuteReferenceDocuments(object inputValue)
        {
            EntityChangeEnable = false;
            string ObjVlaue = (string)inputValue;
            string Request = "ExecuteReferenceDocuments" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + SelectedReferenceDocuments + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + ObjVlaue;
            MCTemp = REPO_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTemp, Request, "Production_Order_STD", "Production", " ", 0, "");

            if (MCTemp.MasterEntity.Count > 0)
            {
                MasterEntity = MCTemp.MasterEntity[0];
                EPR_T001_A_OBJ_OC = MCTemp.OperationEntity;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M030_P)x).plan_no);
                TheFilter = (o, prefix) => (((QMS_M030_P)o).plan_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((QMS_M030_P)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASRouting = new AutoSuggestTextViewModel<dynamic>(MCTemp.RoutingList, TheFilter, SuggestedValue, "plan_no", true);
                ASRouting.AutoSuggestVM.IsEmptyValueAllowed = false; ASRouting.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENG_T001_P)x).doc_no);
                TheFilter = (o, prefix) => (((ENG_T001_P)o).doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ENG_T001_P)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASBOM = new AutoSuggestTextViewModel<dynamic>(MCTemp.BOMList, TheFilter, SuggestedValue, "doc_no", true);
                ASBOM.AutoSuggestVM.IsEmptyValueAllowed = true; ASBOM.AutoSuggestVM.IsFreeTextAllowed = false;

                STD_LIST_BE obj_Temp = MC.REF_DOC_LIST.Where(x => x.order_no.Equals(SelectedReferenceDocuments, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                MasterEntity.qty = obj_Temp.order_qty;
            }
            EntityChangeEnable = true;
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
                    DefaultValues();
                    LoadInitialData();
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertOperation(object InputValue)
        {
            try
            {
                string Request = "";
                PPC_M002 POPUPEntityObject = null;

                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.OperationList.Where(x => x.op_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<PPC_M002>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_M002>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    EPR_T001_A_OBJ.op_code = POPUPEntityObject.op_code;
                    EPR_T001_A_OBJ.operation_desc = POPUPEntityObject.op_desc;
                }
                //else
                //{
                //    EPR_T001_A_OBJ.op_code = null;
                //    EPR_T001_A_OBJ.operation_desc = null;
                //}
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertItemCode(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M022_P1 POPUPEntityObject = null;

                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.ItemMaster.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M022_P1>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P1>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                    MasterEntity.ItemName = POPUPEntityObject.ItemName;
                    MasterEntity.unit_code = POPUPEntityObject.unit_code;

                    EntityChangeEnable = false;
                    string Request2 = "LoadData_For_Selected_ItemCode" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + MasterEntity.ItemCode;
                    MCTemp = REPO_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTemp, Request2, "Production_Order_STD", "Production", " ", 0, "");

                    MC.BOMList = MCTemp.BOMList;
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENG_T001_P)x).bom_no);
                    TheFilter = (o, prefix) => (((ENG_T001_P)o).bom_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ENG_T001_P)o).bom_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASBOM = new AutoSuggestTextViewModel<dynamic>(MCTemp.BOMList, TheFilter, SuggestedValue, "bom_no", true);
                    ASBOM.AutoSuggestVM.IsEmptyValueAllowed = true; ASBOM.AutoSuggestVM.IsFreeTextAllowed = false;
                    if (MCTemp.BOMList.Count == 1)
                    {
                        MasterEntity.bom_no = MCTemp.BOMList[0].bom_no;
                    }
                    else if (MCTemp.BOMList.Exists(x => x.bom_no.Equals(MasterEntity.bom_no)) == false || string.IsNullOrWhiteSpace(MasterEntity.location_Id) == true)
                    {
                        MasterEntity.bom_no = null;
                    }

                    MC.RoutingList = MCTemp.RoutingList;
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M030_P)x).plan_no);
                    TheFilter = (o, prefix) => (((QMS_M030_P)o).plan_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((QMS_M030_P)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASRouting = new AutoSuggestTextViewModel<dynamic>(MCTemp.RoutingList, TheFilter, SuggestedValue, "plan_no", true);
                    ASRouting.AutoSuggestVM.IsEmptyValueAllowed = false; ASRouting.AutoSuggestVM.IsFreeTextAllowed = false;
                    if (MCTemp.RoutingList.Count == 1)
                    {
                        MasterEntity.routing_no = MCTemp.RoutingList[0].plan_no;

                        string Request3 = "Load_Operations_For_Selected_Routing" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.routing_no;
                        MCTemp = REPO_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTemp, Request3, "Production_Order_STD", "Production", " ", 0, "");

                        if (MCTemp.OperationEntity != null)
                        {
                            if (MCTemp.OperationEntity.Count > 0)
                            {
                                EPR_T001_A_OBJ_OC = MCTemp.OperationEntity;
                            }
                        }
                    }
                    else if (MCTemp.RoutingList.Exists(x => x.plan_no.Equals(MasterEntity.routing_no)) == false || string.IsNullOrWhiteSpace(MasterEntity.routing_no) == true)
                    {
                        MasterEntity.routing_no = null;
                    }


                    EntityChangeEnable = true;
                }
                //else
                //{
                //    //IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Selected Item Not exists", this.Title); sms.ShowMessage();
                //    MasterEntity.ItemCode = null;
                //    MasterEntity.ItemName = null;
                //}
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertProdcutionPlant(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;

                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            List<ADM_M003> LocationList = ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(item => item.comp_code == MasterEntity.comp_code).ToList();
                            POPUPEntityObject = LocationList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
                    MasterEntity.location_Id = POPUPEntityObject.location_Id;

                    List<MM_M001_P> StoreList = (MC.StoreCodeList.Where(item => item.location_Id == MasterEntity.location_Id).ToList());
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M001_P)x).store_code);
                    TheFilter = (o, prefix) => (((MM_M001_P)o).store_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((MM_M001_P)o).store_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASStoreCode = new AutoSuggestTextViewModel<dynamic>(MC.StoreCodeList, TheFilter, SuggestedValue, "store_code", true);
                    ASStoreCode.AutoSuggestVM.IsEmptyValueAllowed = true; ASStoreCode.AutoSuggestVM.IsFreeTextAllowed = false;
                    if (StoreList.Count == 1)
                    {
                        MasterEntity.store_code = StoreList[0].store_code;
                    }
                    else if (StoreList.Exists(x => x.store_code.Equals(MasterEntity.store_code)) == false || string.IsNullOrWhiteSpace(MasterEntity.store_code) == true)
                    {
                        MasterEntity.store_code = null;
                    }

                }
                //else
                //{
                //    //IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Selected Plant not exists.", this.Title); sms.ShowMessage();
                //    MasterEntity.location_Id = null;
                //}
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void DeleteOperationEntityRow(object InputValue)
        {
            try
            {
                if (EPR_T001_A_OBJ_OC != null && EPR_T001_A_OBJ != null)
                {
                    if (EPR_T001_A_OBJ.id == 0)
                    {
                        EPR_T001_A_OBJ_OC.Remove(EPR_T001_A_OBJ);
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertStoreCode(object InputValue)
        {
            try
            {
                string Request = "";
                MM_M001_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            List<MM_M001_P> StoreList = (MC.StoreCodeList.Where(item => item.location_Id == MasterEntity.location_Id).ToList());
                            POPUPEntityObject = StoreList.Where(x => x.store_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
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

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.store_code = POPUPEntityObject.store_code;
                }
                //else
                //{
                //    //IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Selected Storeage Location not exists.", this.Title); sms.ShowMessage();
                //    MasterEntity.store_code = null;
                //}
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertRouting(object InputValue)
        {
            try
            {
                string Request = "";
                QMS_M030_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.RoutingList.Where(x => x.plan_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<QMS_M030_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M030_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (MasterEntity.routing_no != POPUPEntityObject.plan_no || EPR_T001_A_OBJ_OC.Count == 0)
                    {
                        MasterEntity.routing_no = POPUPEntityObject.plan_no;

                        EntityChangeEnable = false;
                        string Request2 = "Load_Operations_For_Selected_Routing" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.routing_no;
                        MCTemp = REPO_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTemp, Request2, "Production_Order_STD", "Production", " ", 0, "");

                        if (MCTemp.OperationEntity != null)
                        {
                            if (MCTemp.OperationEntity.Count > 0)
                            {
                                EPR_T001_A_OBJ_OC = MCTemp.OperationEntity;
                            }
                        }
                    }
                    EntityChangeEnable = true;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        #endregion
        #region FilterMethods
        // Filter BackFlip
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
            if (_DataGridCollectionBackFlip != null)
            {
                _DataGridCollectionBackFlip.Refresh();
            }
        }
        public bool Filter_BackFlip(object obj)
        {
            var data = obj as EPR_T001;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BackFlip))
                {
                    return (data.order_no != null && data.order_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.start_dt.ToString() != null && data.start_dt.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.prod_plan != null && data.prod_plan.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           //(data.routing_no != null && data.routing_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           //(data.emm_id != null && data.emm_id.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.t_display != null && data.t_display.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()));
                }
                return true;
            }
            return false;

        }

        // Filter ReferenceDoc
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
            if (_ReferenceDocCollection != null)
            {
                _ReferenceDocCollection.Refresh();
            }
        }
        public bool Filter_ReferenceDoc(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_ReferenceDoc))
                {
                    return (data.order_no != null && data.order_no.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.doc_date.ToString() != null && data.doc_date.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.location_id != null && data.location_id.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.item_code != null && data.item_code.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.item_name != null && data.item_name.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.order_no != null && data.order_no.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())
                       );
                }
                return true;
            }
            return false;
        }

        // Filter Order Chart
        private string _FilterString_Order_Chart;
        public string FilterString_Order_Chart
        {
            get { return _FilterString_Order_Chart; }
            set
            {
                _FilterString_Order_Chart = value;
                RaisePropertyChanged("FilterString_Order_Chart");
                FilterCollection_Order_Chart();
            }
        }
        private void FilterCollection_Order_Chart()
        {
            if (_ProductionOrderChart != null)
            {
                _ProductionOrderChart.Refresh();
            }
        }
        public bool Filter_Order_Chart(object obj)
        {
            var data = obj as EPR_T001;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_Order_Chart))
                {
                    return (data.order_no != null && data.order_no.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.doc_date.ToString() != null && data.doc_date.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.planning_plant != null && data.planning_plant.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.routing_no != null && data.routing_no.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.bom_no != null && data.bom_no.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.t_status != null && data.t_status.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.t_display != null && data.t_display.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.start_dt.ToString() != null && data.start_dt.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.end_dt.ToString() != null && data.end_dt.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower())
                       );
                }
                return true;
            }
            return false;
        }


        #endregion

        #region Collection Change Event
        private void CollectionChangedNotifyForOperationEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {

                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (EPR_T001_A item in e.NewItems)
                    {
                        item.line_id = EPR_T001_A_OBJ_OC.Count;
                        item.userid = AppSessionState.UserID;
                        item.add_date = System.DateTime.Now;
                        item.comp_code = MasterEntity.comp_code;
                        item.client = AppSessionState.client;
                        item.t_status = "001";
                        item.plan_no = EPR_T001_A_OBJ.bom_no;
                        item.task_list_type = "R";
                        item.active = true;
                        item.control_key = "01";
                        item.group_counter = "1";
                        item.id = 0;
                        item.no_of_emp = 1;
                        //item.operation_row_id = "R"; // Fetch from New Order data for rework order.
                        item.op_seq = EPR_T001_A_OBJ_OC.Count;
                        item.order_no = EPR_T001_A_OBJ.order_no;
                        item.plan_counter = 1;
                        //item.ref_line_id = EPR_T001_A_OBJ.order_no; // Fetch from New Order data for rework order.
                        item.scrap_factor = 0;


                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {

                }
            }
            catch (Exception ex)
            { }
        }
        #endregion
    }
}