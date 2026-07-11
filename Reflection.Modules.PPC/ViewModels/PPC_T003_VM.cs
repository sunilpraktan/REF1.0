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
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.PPC.ViewModels
{
    public class PPC_T003_VM : WorkspaceViewModel<EPR_T001>
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
        private string doc_type_vm { get; set; }
        private string SelectedReferenceDocuments;

        WebServiceRepository<EPR_T001> repository = new WebServiceRepository<EPR_T001>();
        WebServiceRepository<MultipleContext_EPR_T001> repository_MC = new WebServiceRepository<MultipleContext_EPR_T001>();
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
            set { if (_MasterEntity != value) { _MasterEntity = value; RaisePropertyChanged(nameof(MasterEntity)); } }
        }
        private int _dgSelectedIndex;
        public int dgSelectedIndex
        {
            get { return _dgSelectedIndex; }
            set
            {
                if (_dgSelectedIndex != value)
                {
                    _dgSelectedIndex = value; RaisePropertyChanged("dgSelectedIndex");
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
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PPC_T003_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
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
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
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
        private void SetAutoTextSource(DataGridCellInfo dgCellInfo)
        {
            if (dgCellInfo != null)
            {
                var column = dgCellInfo.Column as DataGridColumn;
                if (column != null)
                {
                    string headerName = column.Header.ToString();
                    string SourceName = column.SortMemberPath.ToString();
                    if (SourceName == "t_status")
                    { ASDefault = ASStatus; }
                }
            }
        }
        #endregion
        #region Relay Command
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdProductionOrderChart { get; private set; }
        public RelayCommand<object> cmdSelectionChangedOrderChart { get; private set; }

        public GalaSoft.MvvmLight.Command.RelayCommand cmdExecuteReferenceDocuments { get; private set; }

        #endregion
        #region Abstract Command
        protected override void OnCreateAction(InquiryActionResult<EPR_T001> result)
        {
        }
        protected override void OnDiscardAction(InquiryActionResult<EPR_T001> result)
        {

        }
        protected override void OnDocumentAction()
        {

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
        protected override void OnRefreshCommand(InquiryActionResult<EPR_T001> result)
        {
            LoadInitialData();
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
        protected override void OnSaveAction(InquiryActionResult<EPR_T001> result)
        {
            CursorControl.SetBusyState();
            try
            {
                if (Validation() == true)
                {
                    Logging();
                    MasterEntity = repository.UpdateWithReturnDomainObject<EPR_T001>(MasterEntity, "Production_Order_Chart", "Production");
                    if (MasterEntity.order_no != null || MasterEntity.order_no != "")
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok;
                        sms.Caption = "Message";
                        sms.Text = String.Format("Record saved Successfully ........");
                        sms.ShowMessage();
                    }
                    MasterEntity.ts_code = ts_code_vm;
                    isNewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
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


        #endregion
        #region Constructor
        public PPC_T003_VM(string ts_code, string doc_cat, string doc_type) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.doc_type_vm = doc_type;
            this.ts_code_vm = ts_code;
            EPR_T001.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MultipleContext_EPR_T001();
            MCTemp = new MultipleContext_EPR_T001();
            RequestPara = new RequestParameters();
            MasterEntity = new EPR_T001();
            InitializeCommands();
        }
        public PPC_T003_VM(string ts_code, string doc_cat, string doc_type, string doc_no) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.doc_type_vm = doc_type;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            EPR_T001.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MultipleContext_EPR_T001();
            MCTemp = new MultipleContext_EPR_T001();
            RequestPara = new RequestParameters();
            MasterEntity = new EPR_T001();
            InitializeCommands();
        }
        #endregion
        #region Standard Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "Load_Production_Order_Chart" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + AppSessionState.EmpId;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MC, Request, "Production_Order_Chart", "Production", " ", 0, "");

                ProductionOrderChart = CollectionViewSource.GetDefaultView(MC.MasterEntity.ToList());
                ProductionOrderChart.Filter = new Predicate<object>(Filter_Order_Chart);

                #region Autosuggest


                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M042_P)x).shift);
                //TheFilter = (o, prefix) => (((ADM_M042_P)o).shift ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //ASShift = new AutoSuggestTextViewModel<dynamic>(MC.ShiftList, TheFilter, SuggestedValue, "shift", true);
                //ASShift.AutoSuggestVM.IsEmptyValueAllowed = true; ASShift.AutoSuggestVM.IsFreeTextAllowed = true;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                //TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //ASEmployee = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeList, TheFilter, SuggestedValue, "EmpId", true);
                //ASEmployee.AutoSuggestVM.IsEmptyValueAllowed = true; ASEmployee.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M025)x).t_status);
                TheFilter = (o, prefix) => (((SYS_M025)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M025)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASStatus = new AutoSuggestTextViewModel<dynamic>(MC.StatusList, TheFilter, SuggestedValue, "t_status", "t_status", true);
                ASStatus.AutoSuggestVM.IsEmptyValueAllowed = false; ASStatus.AutoSuggestVM.IsFreeTextAllowed = false;

                #endregion

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InitializeCommands()
        {
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEventCall(items); });
            cmdProductionOrderChart = new RelayCommand<object>(items => { if (items == null) { return; } LoadProductionOrderChart(items); });
            cmdSelectionChangedOrderChart = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChangedOrderChart(items); });
        }
        private void DefaultValues()
        {
            try
            {
                EntityChangeEnable = true;
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
            return true;
        }
        private void SelectionChangedOrderChart(object InputValue)
        {
            MasterEntity = (EPR_T001)InputValue;
        }
        private void LoadProductionOrderChart(object InputValue)
        {
            try
            {
                string Request = "Load_Production_Order_Chart" + "!@" + AppSessionState.client + "!@" + RequestPara.comp_code + "!@" + RequestPara.location_Id + "!@" + doc_cat_vm + "!@" + (Utilities.NullIf(RequestPara.doc_type) ?? "") + "!@" + (Utilities.NullIf(RequestPara.t_status) ?? "") + "!@" + RequestPara.active + "!@" + (Utilities.NullIf(RequestPara.EmpId) ?? AppSessionState.EmpId) + "!@" + Utilities.NullIf(RequestPara.PartyId) + "!@" + Convert.ToDateTime(RequestPara.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(RequestPara.ToDate).ToString("MM/dd/yyyy");
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MC, Request, "Production_Order_Chart", "Production", " ", 0, "");


                ProductionOrderChart = CollectionViewSource.GetDefaultView(MC.MasterEntity.ToList());
                ProductionOrderChart.Filter = new Predicate<object>(Filter_Order_Chart);
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
                    if (sender.ToString() == "ItemCode")
                    {
                    }
                    if (sender.ToString() == "t_status")
                    {
                        MasterEntity.t_display = MC.StatusList.Where(x => x.t_status == MasterEntity.t_status).ToList()[0].t_display;
                    }
                }
            }
            catch (Exception ex)
            {
            }
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
        #endregion
        #region FilterMethods

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
    }
}