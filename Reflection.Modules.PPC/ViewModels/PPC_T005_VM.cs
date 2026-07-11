using GalaSoft.MvvmLight.Command;
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
using System.Globalization;
using Reflection.ReportingServices;
using Reflection.BusinessEntity.ADM;
using System.Threading.Tasks;

namespace Reflection.Modules.PPC.ViewModels
{
    public class PPC_T005_VM : WorkspaceViewModel<EPR_T002>
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
        private string _order_type;
        private string order_type
        {
            get { return _order_type; }
            set
            {
                if (_order_type != value)
                {
                    _order_type = value; RaisePropertyChanged("order_type");
                }
            }
        }
        private string ts_code_vm { get; set; }
        private string doc_no_vm { get; set; }
        private string doc_cat_vm { get; set; }

        private DateTime? _default_date;
        public DateTime? default_date
        {
            get { return _default_date; }
            set { if (_default_date != value) 
                { 
                    _default_date = value; RaisePropertyChanged("default_date"); 
                } 
            }
        }


        WebServiceRepository<List<EPR_T002>> repository = new WebServiceRepository<List<EPR_T002>>();
        WebServiceRepository<MC_PPC_BE> repository_MC = new WebServiceRepository<MC_PPC_BE>();
        ObjectSerializationService obj = new ObjectSerializationService();

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
        public EPR_T002 MasterEntity
        {
            get { return _MasterEntity; }
            set { if (_MasterEntity != value) { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); } }
        }
        private EPR_T001 _OrderEntity;
        public EPR_T001 OrderEntity
        {
            get { return _OrderEntity; }
            set { if (_OrderEntity != value) { _OrderEntity = value; RaisePropertyChanged("OrderEntity"); } }
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

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
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

        private IEnumerable<dynamic> _ORDER_LIST { get; set; }
        public IEnumerable<dynamic> ORDER_LIST
        {
            get { return _ORDER_LIST; }
            set
            {
                if (_ORDER_LIST != value)
                {
                    _ORDER_LIST = value; RaisePropertyChanged("ORDER_LIST");
                }
            }
        }
        private IEnumerable<dynamic> _BATCH_LIST { get; set; }
        public IEnumerable<dynamic> BATCH_LIST
        {
            get { return _BATCH_LIST; }
            set
            {
                if (_BATCH_LIST != value)
                {
                    _BATCH_LIST = value; RaisePropertyChanged("BATCH_LIST");
                }
            }
        }

        #endregion

        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PPC_T005_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
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
        private AutoSuggestTextViewModel<dynamic> _AS_EMPLOYEE { get; set; }
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
        private AutoSuggestTextViewModel<dynamic> _AS_INPUT_TYPE { get; set; }
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
        #region Relay Command
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdGetExecutionData { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdLoadBackFlipData { get; private set; }
        public RelayCommand<object> cmdBarcodeScan { get; private set; }
        public RelayCommand<object> cmdInsertOrderNumber { get; private set; }
        public RelayCommand<object> cmdInsertOperationNumber { get; private set; }

        #endregion
        #region Abstract Command
        protected override void OnCreateAction(InquiryActionResult<EPR_T002> result)
        {
            MasterEntity = new EPR_T002();
            RecordTypeSelected = new STD_LIST_BE();
            DefaultValues();
        }
        protected override void OnDiscardAction(InquiryActionResult<EPR_T002> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<EPR_T002> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<EPR_T002> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<EPR_T002> result)
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<EPR_T002> result)
        {
            LoadInitialData();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }
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
        {

        }
        protected override void OnSaveAction(InquiryActionResult<EPR_T002> result)
        {
            try
            {
                if (Validation() == true)
                {
                    Logging();
                    List<EPR_T002> MasterEntityList = new List<EPR_T002>();
                    if (isNewRecord == true)
                    {
                        
                        MasterEntityList.Add(MasterEntity);
                        MasterEntityList = repository.SaveWithReturnDomainObject<List<EPR_T002>>(MasterEntityList, "EPR_T002_BL", "PPC");
                        MasterEntity = MasterEntityList[0];
                        isNewRecord = false;
                        //isNewRecord = true;
                        if(MC.NOTIFICATION_LIST != null)
                        {
                            if (MC.NOTIFICATION_LIST.Count > 0 && !string.IsNullOrWhiteSpace(MasterEntity.doc_no) && MC.NOTIFICATION_LIST.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                            {
                                NotifyMessage("OnInsert", "Created");
                            }
                        }
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record Addred Successfully!", this.Title); sms.ShowMessage();

                        //NOTE: following 3 lines are not commented in old STD vm.
                        MasterEntity = new EPR_T002();
                        RecordTypeSelected = new STD_LIST_BE();
                        DefaultValues();

                        
                        

                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntityList.Add(MasterEntity);
                        MasterEntityList = repository.UpdateWithReturnDomainObject<EPR_T002>(MasterEntityList, "EPR_T002_BL", "PPC");
                        MasterEntity = MasterEntityList[0];
                        isNewRecord = false;
                    }
                    //MasterEntity.barcode_value = null;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }


        #endregion
        #region Constructor
        public PPC_T005_VM(string ts_code, string doc_cat) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            EPR_T002.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MC_PPC_BE();
            MCTEMP = new MC_PPC_BE();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MasterEntity = new EPR_T002();
            RecordTypeSelected = new STD_LIST_BE();
            OrderEntity = new EPR_T001();
            InitializeCommands();
        }
        public PPC_T005_VM(string ts_code, string doc_cat, string doc_no) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            EPR_T002.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MC_PPC_BE();
            MCTEMP = new MC_PPC_BE();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MasterEntity = new EPR_T002();
            RecordTypeSelected = new STD_LIST_BE();
            OrderEntity = new EPR_T001();
            InitializeCommands();
        }
        #endregion
        #region Standard Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI_PMS_SINGLE" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + AppSessionState.EmpId; // AppSessionState.EmpId + "SINGLE";
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MC, Request, "EPR_T002_BL", "PPC", " ", 0, "");

                ORDER_LIST = MC.ORDER_LIST;
                BATCH_LIST = MC.BATCH_CODE_LIST;
                #region Autosuggest

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((EPR_T001)x).order_no);
                TheFilter = (o, prefix) => (((EPR_T001)o).ref_doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).order_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).short_text ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).project_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).element_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).para1 ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).para2 ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((EPR_T001)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ORDERS = new AutoSuggestTextViewModel<dynamic>(MC.ORDER_LIST, TheFilter, SuggestedValue, "order_no", true);
                AS_ORDERS.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ORDERS.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).barcode ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).order_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).barcode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).batch_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_BARCODE = new AutoSuggestTextViewModel<dynamic>(MC.BATCH_CODE_LIST, TheFilter, SuggestedValue, "barcode", true);
                AS_BARCODE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_BARCODE.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(MC.LOCATION_LIST, TheFilter, SuggestedValue, "location_id", true);
                AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM.AutoSuggestVM.IsEmptyValueAllowed = false; AS_UOM.AutoSuggestVM.IsFreeTextAllowed = false;

                List<STD_PERSONNEL> EMP_OBJ = MC.PERSONNEL_LIST.Where(x => x.emp_type != "EMP").ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_EMPLOYEE = new AutoSuggestTextViewModel<dynamic>(EMP_OBJ, TheFilter, SuggestedValue, "emp_id", true);
                AS_EMPLOYEE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_EMPLOYEE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).record_type);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).record_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).type_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_RECORD_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.RECORD_TYPE_LIST, TheFilter, SuggestedValue, "record_type", true);
                AS_RECORD_TYPE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_RECORD_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).value_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).value_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_REASON = new AutoSuggestTextViewModel<dynamic>(MC.REASON_LIST, TheFilter, SuggestedValue, "value_code", true);
                AS_REASON.AutoSuggestVM.IsEmptyValueAllowed = true; AS_REASON.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).value_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).value_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_INPUT_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.TYPE_LIST, TheFilter, SuggestedValue, "value_code", true);
                AS_INPUT_TYPE.AutoSuggestVM.IsEmptyValueAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).wc_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).wc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).wc_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_WC = new AutoSuggestTextViewModel<dynamic>(MC.WC_LIST, TheFilter, SuggestedValue, "wc_code", true);
                AS_WC.AutoSuggestVM.IsEmptyValueAllowed = false; AS_WC.AutoSuggestVM.IsFreeTextAllowed = false;

                List<UOMS> TimeUOM = MC.UOM_LIST.Where(x => x.class_id == 3).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_TIME = new AutoSuggestTextViewModel<dynamic>(TimeUOM, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM_TIME.AutoSuggestVM.IsEmptyValueAllowed = false; AS_UOM_TIME.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).shift_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).shift_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).shift_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_SHIFT = new AutoSuggestTextViewModel<dynamic>(MC.SHIFT_LIST, TheFilter, SuggestedValue, "shift_code", true);
                AS_SHIFT.AutoSuggestVM.IsEmptyValueAllowed = true; AS_SHIFT.AutoSuggestVM.IsFreeTextAllowed = true;

                List<STD_PERSONNEL> EMP_OBJ_SI = MC.PERSONNEL_LIST.Where(x => x.emp_type == "EMP").ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_SHIFT_INCHARGE = new AutoSuggestTextViewModel<dynamic>(EMP_OBJ_SI, TheFilter, SuggestedValue, "emp_id", true);
                AS_SHIFT_INCHARGE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_SHIFT_INCHARGE.AutoSuggestVM.IsFreeTextAllowed = true;

                List<STD_PERSONNEL> EMP_OBJ_OPR = MC.PERSONNEL_LIST.Where(x => x.emp_type == "OPR" || x.emp_type == "EMP").ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OPERATOR = new AutoSuggestTextViewModel<dynamic>(EMP_OBJ_OPR, TheFilter, SuggestedValue, "emp_id", true);
                AS_OPERATOR.AutoSuggestVM.IsEmptyValueAllowed = true; AS_SHIFT_INCHARGE.AutoSuggestVM.IsFreeTextAllowed = true;

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
                SelectedTabControlIndex = 0;
                STD_LIST_BE POPUPEntityObject = null;
                string Request;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MCTEMP.BACK_FLIP_LIST.Where(x => x.doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + POPUPEntityObject.doc_no;
                    MCTEMP = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTEMP, Request, "EPR_T002_BL", "PPC", " ", 0, "");

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
            cmdLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });
            cmdBarcodeScan = new RelayCommand<object>(items => { if (items == null) { return; } BarcodeScan(items); });
            cmdInsertOrderNumber = new RelayCommand<object>(items => { if (items == null) { return; } InsertOrderNumber(items); });
            cmdInsertOperationNumber = new RelayCommand<object>(items => { if (items == null) { return; } InsertOperationNumber(items); });
        }
        private void DefaultValues()
        {
            try
            {
                EntityChangeEnable = true;
                if (doc_cat_vm == "02" || doc_cat_vm == "01")
                {
                    MasterEntity.record_type = "01";
                }
                else if (doc_cat_vm == "04")
                {
                    MasterEntity.record_type = "05";
                }
                else if (doc_cat_vm == "05")
                {
                    MasterEntity.record_type = "05";
                }
                
                //MasterEntity.barcode_value = null;
                order_type = "N";
                isNewRecord = true;
                MasterEntity.doc_cat = this.doc_cat_vm;
                MasterEntity.doc_type = doc_cat_vm;
                MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                MasterEntity.active = true;
                MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                MasterEntity.emp_id = AppSessionState.EmpId;
                //MasterEntity.m_operator = AppSessionState.EmpId;
                MasterEntity.conf_type = "P";
                MasterEntity.emp_no = 1;

                // shift default dates for continues entry, date should be fixed untill user change otherwise user have to change for every entery after.
                MasterEntity.prod_dt = (default_date ?? DateTime.UtcNow); // DateTime.UtcNow;
                MasterEntity.entry_dt =  DateTime.UtcNow;
                MasterEntity.post_date = default_date; // DateTime.UtcNow;
                MasterEntity.execution_start = default_date; // DateTime.UtcNow;
                MasterEntity.execution_finish = default_date; // DateTime.UtcNow;


                if (MC.DOC_TYPE_LIST != null)
                {
                    if (MC.DOC_TYPE_LIST.Count > 0)
                    {
                        MasterEntity.ac_work_uom = MC.DOC_TYPE_LIST[0].unit_code;
                    }
                }

                DateTime d = DateTime.UtcNow;
                d = d.AddMonths(-1);
                REQUEST_PARA.from_date = d;
                REQUEST_PARA.to_date = DateTime.UtcNow;
                REQUEST_PARA.active = true;
                REQUEST_PARA.location_id = AppSessionState.OBJ_LOCATION.location_id;
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
            if (MasterEntity.record_type == "01" && string.IsNullOrWhiteSpace(MasterEntity.order_no))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Order Number Is Required"); sms.ShowMessage();
                return false;
            }
            if (MasterEntity.order_type == "N" && MasterEntity.record_type == "01" && MasterEntity.operation_no == "10" && !string.IsNullOrWhiteSpace(MasterEntity.barcode) && isNewRecord == true)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Operation not allowed for generated Batch"); sms.ShowMessage();
                return false;
            }
            if (MasterEntity.record_type == "01" && MasterEntity.operation_no != "10" && string.IsNullOrWhiteSpace(MasterEntity.barcode) && isNewRecord == true)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Operation not allowed for new Batch record creation, Batch Number and barcode required for this operation"); sms.ShowMessage();
                return false;
            }
            if (MasterEntity.record_type == "01" && MasterEntity.operation_no != "10" && !string.IsNullOrWhiteSpace(MasterEntity.barcode) && !string.IsNullOrWhiteSpace(MasterEntity.batch_no) && MC.BATCH_CODE_LIST != null)
            {
                if (MC.BATCH_CODE_LIST.Count > 0)
                {
                    if (MC.BATCH_CODE_LIST.Where(x => x.barcode == MasterEntity.barcode && x.batch_no == MasterEntity.batch_no && x.order_no == MasterEntity.order_no).ToList().Count == 0)
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Batch Number or QR/Bar code not exists"); sms.ShowMessage();
                        return false;
                    }
                }
            //NOTE: now commented, use validation in SP.uncomment if required by logic
                if (((MasterEntity.yield ?? 0) + (MasterEntity.rework_qty ?? 0) + (MasterEntity.scrap_qty ?? 0)) > ((MasterEntity.batch_qty ?? 0) - ((MasterEntity.yield_total ?? 0) + (MasterEntity.rework_total ?? 0) + (MasterEntity.scrap_total ?? 0)))) // batch_bal_quantity
                {
                    if (MasterEntity.operation_no != "10" && MC.DOC_TYPE_SETTINGS_LIST[0].ind_check_qty=="1")
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Yield qty exceeded than batch qty. Total Balance for the operation is {0}", ((MasterEntity.yield ?? 0) + (MasterEntity.rework_qty ?? 0) + (MasterEntity.scrap_qty ?? 0) + (MasterEntity.batch_qty_balance ?? 0))); sms.ShowMessage();
                        return false;
                    }
                }
                if (MasterEntity.order_type == "N" && (((MasterEntity.yield ?? 0) + (MasterEntity.rework_qty ?? 0) + (MasterEntity.scrap_qty ?? 0)) > ((MasterEntity.prev_yield ?? 0) - ((MasterEntity.yield_total ?? 0) + (MasterEntity.rework_total ?? 0) + (MasterEntity.scrap_total ?? 0))))) // batch_bal_quantity
                {
                    if (MasterEntity.operation_no != "10" && MC.DOC_TYPE_SETTINGS_LIST[0].ind_check_qty == "1")
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Yield qty exceeded than Previous Yield. Total Balance for the operation is {0}", ((MasterEntity.yield ?? 0) + (MasterEntity.rework_qty ?? 0) + (MasterEntity.scrap_qty ?? 0) + (MasterEntity.op_bal_qty ?? 0))); sms.ShowMessage();
                        return false;
                    }
                }
            }

            if (MasterEntity.record_type == "01" && string.IsNullOrWhiteSpace(MasterEntity.ItemCode))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Item Code Is Required for Record Type Order Processing"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.record_type))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record Type Is Required"); sms.ShowMessage();
                return false;
            }
            if (MasterEntity.record_type == "01" && string.IsNullOrWhiteSpace(MasterEntity.unit_code))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Unit of Measurement Is Required for Record Type Order Processing."); sms.ShowMessage();
                return false;
            }
            if (MasterEntity.record_type == "01" && string.IsNullOrWhiteSpace(MasterEntity.record_type) && RecordTypeSelected.ind_qty == "Y" && ((MasterEntity.yield ?? 0) <= 0 && (MasterEntity.scrap_qty ?? 0) <= 0 && (MasterEntity.rework_qty ?? 0) <= 0))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Yeild or Scrap or Rework Quantity Is Required for Record Type Order Processing."); sms.ShowMessage();
                return false;
            }
            if (!string.IsNullOrWhiteSpace(MasterEntity.order_no) && string.IsNullOrWhiteSpace(MasterEntity.operation_no))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Operation Number is Required"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.conf_type))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Order Execution Type is Required"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.wc_code))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Work Center is Required"); sms.ShowMessage();
                return false;
            }
            if (MasterEntity.record_type == "01" && MasterEntity.yield.HasValue && string.IsNullOrWhiteSpace(MasterEntity.unit_code))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Unit of Measurement required Required"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.emp_id))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("User Name Required"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.m_operator))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Operator Name Required"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.shift_incharge))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Shift Incharge Required"); sms.ShowMessage();
                return false;
            }

            if (MC.DEPENDENCY_LIST != null)
            {
                if (MC.DEPENDENCY_LIST.Count > 0)
                {
                    var obj_dep = MC.DEPENDENCY_LIST.Where(x => x.op_doc == MasterEntity.doc_no_op && x.order_no == MasterEntity.order_no).ToList().FirstOrDefault();
                    if (obj_dep != null)
                    {
                        if (obj_dep.t_status != "03") // NOTE: hardcoded status
                        {
                            IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Dependency activity {0} from Order/Task no {1} required to finish before this activity confirmation.", obj_dep.op_doc_dep, obj_dep.order_no); sms.ShowMessage();
                            return false;
                        }
                    }
                }
            }

            return true;
        }
        private void LoadBackFlipData(object InputValue)
        {
            try
            {
                EntityChangeEnable = false;
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (REQUEST_PARA.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (Utilities.NullIf(REQUEST_PARA.doc_type ?? doc_cat_vm) ?? "") + "!@" + (Utilities.NullIf(REQUEST_PARA.t_status) ?? "") + "!@" + REQUEST_PARA.active + "!@" + (Utilities.NullIf(REQUEST_PARA.emp_id) ?? AppSessionState.EmpId) + "!@" + Convert.ToDateTime(REQUEST_PARA.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQUEST_PARA.to_date).ToString("MM/dd/yyyy");
                MCTEMP = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTEMP, Request, "EPR_T002_BL", "PPC", "LoadAll", 0, "");
                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MCTEMP.BACK_FLIP_LIST);
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(Filter_BackFlip);
                EntityChangeEnable = true;
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }

        private void BarcodeScan(object InputValue)
        {
            try
            {
                string Request = InputValue.ToString();
                string RequestBarcode = null;
                #region Command Parameter Read Section
                if (!string.IsNullOrWhiteSpace(Request)) //MasterEntity.barcode_value
                {
                    //if (MC.BATCH_CODE_LIST.Where(x => x.barcode == Request || x.batch_no == Request) != null) //MasterEntity.barcode_value
                    //{
                    //    if (MC.BATCH_CODE_LIST.Where(x => x.barcode == Request || x.batch_no == Request).ToList().Count > 0)
                    //    {
                    //        RequestBarcode = MC.BATCH_CODE_LIST.Where(x => x.barcode == MasterEntity.barcode_value).ToList()[0].barcode;
                    //    }
                    //}
                    RequestBarcode = MC.BATCH_CODE_LIST.Where(x => x.key_code == Request || x.batch_no == Request).ToList()[0].barcode; // Just to check existance of record for request
                }
                if (!string.IsNullOrWhiteSpace(Request) && !string.IsNullOrWhiteSpace(RequestBarcode)) // && MasterEntity.barcode_value != Request
                {
                    var order_data = MC.BATCH_CODE_LIST.Where(x => x.key_code == Request || x.batch_no == Request).ToList()[0]; // Used key_code not barcode because we need to get correct row because of duplicate barcode. RequestBarcode is just for chacking is barcode really exists or not, may be this is not required if key_code work but before entering this loop we need to make sure that inteded barcode exists as per key_code.
                    string Request2 = "BARCODE_SCAN" + "!@" + AppSessionState.client + "!@" + order_data.comp_code + "!@" + order_data.location_id + "!@" + doc_cat_vm + "!@" + (Utilities.NullIf(REQUEST_PARA.doc_type) ?? "") + "!@" + order_data.order_no + "!@" + (Utilities.NullIf(REQUEST_PARA.emp_id) ?? AppSessionState.EmpId) + "!@" + order_data.barcode + "!@" + AppSessionState.UserID + "!@" + order_data.batch_no;
                    MCTEMP = repository_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MCTEMP, Request2, "EPR_T002_BL", "PPC", "LoadAll", 0, "");
                    if (MCTEMP.CONFIRMATION_LIST.Count > 0)
                    {
                        MasterEntity = MCTEMP.CONFIRMATION_LIST[0];
                        MC.OPERATION_LIST = MCTEMP.OPERATION_LIST;
                        MC.DEPENDENCY_LIST = MCTEMP.DEPENDENCY_LIST;
                        if (MCTEMP.CONFIRMATION_LIST.Count > 1) // Count > 1 means Rework order exists, then user must select order from order popup. to select order nulber we set it null first.
                        {
                            MasterEntity.order_no = null;
                        }

                        if (!string.IsNullOrWhiteSpace(MasterEntity.order_no))
                        {
                            OrderEntity = new EPR_T001();
                            OrderEntity = MCTEMP.ORDER_LIST.Where(x => x.order_no == MasterEntity.order_no).ToList()[0];
                            //MOperationList = MC.OPERATION_LIST.Where(x => x.order_no == MasterEntity.order_no).ToList();
                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).operation_no);
                            TheFilter = (o, prefix) => (((STD_LIST_BE)o).operation_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).operation_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                            AS_OPERATIONS = new AutoSuggestTextViewModel<dynamic>(MC.OPERATION_LIST, TheFilter, SuggestedValue, "operation_no", true);
                            AS_OPERATIONS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OPERATIONS.AutoSuggestVM.IsFreeTextAllowed = false;

                            MasterEntity.prod_dt = (default_date ?? DateTime.UtcNow);
                            MasterEntity.order_no = MasterEntity.order_no;
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
                else
                {
                    if (RequestBarcode != null) // only enter in exception if issue is other than RequestBarcode null, because value not exists in batch data, but next error should get catch in exception.
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Data not exists for the input request", this.Title); sms.ShowMessage();
                    }
                    MasterEntity = new EPR_T002();
                }
                #endregion
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Data not exists for the input request", this.Title); sms.ShowMessage();
                MasterEntity = new EPR_T002();
            }
        }
        private void InsertOrderNumber(object InputValue)
        {
            try
            {
                string Request = "";
                EPR_T001 POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.ORDER_LIST.Where(x => x.ref_doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.ref_doc_no.Equals(MasterEntity.order_no, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<EPR_T001>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<EPR_T001>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null && string.IsNullOrWhiteSpace(MasterEntity.batch_no)) // if object null and MasterEntity.batch_no is null because batch null means entry of first operation else next operation and next operation cannot w/o batch no
                {
                    if (!string.IsNullOrWhiteSpace(POPUPEntityObject.ref_doc_no))
                    {
                        MasterEntity.order_no = POPUPEntityObject.ref_doc_no;
                        MasterEntity.ref_doc_no = POPUPEntityObject.ref_doc_no;
                        MasterEntity.comp_code = (POPUPEntityObject.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code);
                        MasterEntity.location_Id = (POPUPEntityObject.location_Id ?? AppSessionState.OBJ_LOCATION.location_id);
                        MasterEntity.routing_no = POPUPEntityObject.routing_no;
                        MasterEntity.unit_code = POPUPEntityObject.unit_code;
                        MasterEntity.store_code = POPUPEntityObject.store_code;
                        MasterEntity.order_type = POPUPEntityObject.order_type;
                        MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                        MasterEntity.ItemName = POPUPEntityObject.ItemName;
                        




                        string Request2 = "EXECUTE_REFERENCE_PMS_ORDER" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + (Utilities.NullIf(REQUEST_PARA.doc_type) ?? "") + "!@" + MasterEntity.order_no + "!@" + (Utilities.NullIf(REQUEST_PARA.emp_id) ?? AppSessionState.EmpId) + "!@" + MasterEntity.batch_no;
                        MCTEMP = repository_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MCTEMP, Request2, "EPR_T002_BL", "PPC", "LoadAll", 0, "");
                        MC.OPERATION_LIST = MCTEMP.OPERATION_LIST;
                        MC.DEPENDENCY_LIST = MCTEMP.DEPENDENCY_LIST;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).operation_no);
                        TheFilter = (o, prefix) => (((STD_LIST_BE)o).operation_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).operation_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        AS_OPERATIONS = new AutoSuggestTextViewModel<dynamic>(MC.OPERATION_LIST, TheFilter, SuggestedValue, "operation_no", true);
                        AS_OPERATIONS.AutoSuggestVM.IsEmptyValueAllowed = false; AS_OPERATIONS.AutoSuggestVM.IsFreeTextAllowed = false;

                        if (MC.OPERATION_LIST.Count == 1)
                        {
                            MasterEntity.operation_no = MC.OPERATION_LIST[0].operation_no;
                            MasterEntity.wc_code = MC.OPERATION_LIST[0].wc_code;
                            MasterEntity.fin_year = MC.OPERATION_LIST[0].wc_code;
                        }
                        else if (MC.OPERATION_LIST.Exists(x => x.operation_no.Equals(MasterEntity.operation_no)) == false || string.IsNullOrWhiteSpace(MasterEntity.operation_no) == true)
                        {
                            MasterEntity.operation_no = null;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void ExecuteReference(object InputValue)
        {

        }
        private void InsertOperationNumber(object InputValue)
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
                    if (((IEnumerable)InputValue).Cast<OperationList>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (!string.IsNullOrWhiteSpace(POPUPEntityObject.operation_no))
                    {
                        MasterEntity.operation_no = POPUPEntityObject.operation_no;
                        MasterEntity.wc_code = (POPUPEntityObject.wc_code ?? MasterEntity.wc_code); // MC.OPERATION_LIST.Where(x => x.operation_no == MasterEntity.operation_no).ToList()[0].wc_code;
                        MasterEntity.control_key = POPUPEntityObject.control_key;
                        MasterEntity.op_line_id = POPUPEntityObject.line_id; //NOTE: make changes of this fields in select query. earlier it was op_line_id
                        MasterEntity.op_seq = POPUPEntityObject.op_seq;
                        MasterEntity.batch_qty_balance = POPUPEntityObject.bal_qty; //(POPUPEntityObject.batch_qty ?? 0) - ((POPUPEntityObject.yield ?? 0)+ (POPUPEntityObject.rework_qty ?? 0)+ (POPUPEntityObject.scrap_qty ?? 0)); // This is to validate yield qty of batch should not exceed sum of qty of first operation for the same batch.
                        MasterEntity.yield_total = POPUPEntityObject.yield;
                        MasterEntity.prev_yield = POPUPEntityObject.prev_yield;
                        MasterEntity.rework_total = POPUPEntityObject.rework_qty;
                        MasterEntity.scrap_total = POPUPEntityObject.scrap_qty;
                        if (POPUPEntityObject.prev_yield.HasValue && POPUPEntityObject.prev_yield > 0)
                        {
                            MasterEntity.op_bal_qty = (POPUPEntityObject.prev_yield ?? 0) - ((POPUPEntityObject.yield ?? 0) + (POPUPEntityObject.rework_qty ?? 0) + (POPUPEntityObject.scrap_qty ?? 0));
                        }
                        else
                        {
                            MasterEntity.op_bal_qty = null;
                        }
                        MasterEntity.doc_no_op = POPUPEntityObject.doc_no;
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

        public string ConvertDataTableToHTML()
        {
            string html = "<table>";
            //add header row
            html += "<tr bgcolor=#e0e0eb>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Item Code </span></strong></p> </td>";
            html += "<td width=10%> <p><strong><span style=color:#000080;> Item Name </span></strong></p> </td>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Quantity </span></strong></p> </td>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Unit </span></strong></p> </td>";
            html += "</tr>";

            html += "<tr bgcolor=#d9e6f2>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> " + MasterEntity.ItemCode + "</p></span></strong></p> </td>";
            html += "<td width=10%> <p><strong><span style=color:#000080;> " + MasterEntity.ItemName + "</span></strong></p> </td>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> " + MasterEntity.yield.ToString() + "</span></strong></p> </td>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> " + MasterEntity.unit_code + "</span></strong></p> </td>";
            //html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.unit_price.ToString() + "</span></strong></p> </td>";
            //html += "<td width=5%> <p><strong><span style=color:#000080;> " + (item.unit_price.HasValue ? decimal.Round(item.unit_price.Value, 2).ToString() : "") + "</span></strong></p> </td>";
            html += "</tr>";

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
                        new KeyValuePair<string, string>("[DOC]", "Order Confirmation"),
                        new KeyValuePair<string, string>("[OPR]", operation),
                        new KeyValuePair<string, string>("[DOCNO]", MasterEntity.doc_no),
                        new KeyValuePair<string, string>("[Comp]","M/s: " +AppSessionState.CompanyName),
                        new KeyValuePair<string, string>("[TSTS]", MasterEntity.t_display),
                        new KeyValuePair<string, string>("[Attn]",VarData.EmpName),
                        new KeyValuePair<string, string>("[CUST]","M/s: " +  AppSessionState.OBJ_COMPANY.comp_name),
                        new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.prod_dt.ToString()),
                        new KeyValuePair<string, string>("[MODDT]", DateTime.Now.ToString()),
                        
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
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                    if (sender.ToString() == "record_type" && !string.IsNullOrWhiteSpace(MasterEntity.record_type))
                    {
                        RecordTypeSelected = MC.RECORD_TYPE_LIST.Where(x => x.record_type == MasterEntity.record_type).ToList()[0];
                    }
                    if (sender.ToString() == "shift" && !string.IsNullOrWhiteSpace(MasterEntity.shift))
                    {
                        STD_LIST_BE shift_obj = MC.SHIFT_LIST.Where(x => x.shift_code == MasterEntity.shift).ToList()[0];
                        MasterEntity.total_time = shift_obj.shift_hrs;
                        MasterEntity.starttime = shift_obj.start_time;
                        MasterEntity.endtime = shift_obj.end_time;

                        MasterEntity.ac_duration = Convert.ToDecimal(shift_obj.shift_hrs); //NOTE: This line Commented as per AVPL Requirement.
                        if (MasterEntity.ac_duration.HasValue)
                        {
                            MasterEntity.ac_work = (MasterEntity.ac_duration * (MasterEntity.emp_no ?? 1));
                        }

                    }
                    if ((sender.ToString() == "starttime" || sender.ToString() == "endtime") && !string.IsNullOrWhiteSpace(MasterEntity.starttime) && !string.IsNullOrWhiteSpace(MasterEntity.endtime))
                    {
                        DateTime dateTime1 = DateTime.ParseExact(MasterEntity.starttime, "HH:mm:ss", CultureInfo.InvariantCulture);
                        DateTime dateTime2 = DateTime.ParseExact(MasterEntity.endtime, "HH:mm:ss", CultureInfo.InvariantCulture);
                        MasterEntity.total_time = (dateTime2.TimeOfDay - dateTime1.TimeOfDay).ToString();
                    }
                    if (sender.ToString() == "ac_duration" && MasterEntity.ac_duration.HasValue)
                    {
                        MasterEntity.ac_work = (MasterEntity.ac_duration * (MasterEntity.emp_no ?? 1));
                    }
                    if (sender.ToString() == "ac_duration_uom" && !string.IsNullOrWhiteSpace(MasterEntity.ac_duration_uom))
                    {
                        MasterEntity.ac_work_uom = MasterEntity.ac_duration_uom;
                        MasterEntity.unit_code = (MasterEntity.unit_code ?? MasterEntity.ac_work_uom);
                    }
                    if (sender.ToString() == "prod_dt")
                    {
                        MasterEntity.execution_start = (MasterEntity.prod_dt ?? MasterEntity.entry_dt);
                        MasterEntity.execution_finish = (MasterEntity.prod_dt ?? MasterEntity.entry_dt);
                        //MasterEntity.post_date = (MasterEntity.prod_dt ?? MasterEntity.entry_dt);
                        default_date = MasterEntity.prod_dt;
                        //default_date = MasterEntity.prod_dt; // default date fix when user change.
                        //default_date = MasterEntity.entry_dt; // default date fix when user change.
                    }
                    if (sender.ToString() == "yield" || sender.ToString() == "scrap_qty" || sender.ToString() == "rework_qty")
                    {
                        if (MasterEntity.operation_no != "10")
                        {
                            MasterEntity.batch_qty_balance = MasterEntity.batch_qty - ((MasterEntity.yield_total ?? 0) + (MasterEntity.rework_total ?? 0) + (MasterEntity.scrap_total ?? 0) + (MasterEntity.yield ?? 0) + (MasterEntity.rework_qty ?? 0) + (MasterEntity.scrap_qty ?? 0));
                            MasterEntity.op_bal_qty = (MasterEntity.prev_yield ?? 0) - ((MasterEntity.yield_total ?? 0) + (MasterEntity.rework_total ?? 0) + (MasterEntity.scrap_total ?? 0) + (MasterEntity.yield ?? 0) + (MasterEntity.rework_qty ?? 0) + (MasterEntity.scrap_qty ?? 0));
                        }
                    }
                    if (sender.ToString() == "operation_no")
                    {
                        MasterEntity.yield = null;
                    }

                }
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

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ConfirmationTypes)x).conf_type);
                    TheFilter = (o, prefix) => (((ConfirmationTypes)o).conf_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ConfirmationTypes)o).conf_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    default_date = DateTime.UtcNow;
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
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BackFlip))
                {
                    return (data.order_no != null && data.order_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.location_id != null && data.location_id.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.operation_no != null && data.operation_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.emp_name != null && data.emp_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.item_code != null && data.item_code.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.item_name != null && data.item_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.doc_date.ToString() != null && data.doc_date.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.prod_dt.ToString() != null && data.prod_dt.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.record_type != null && data.record_type.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.element_name != null && data.element_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.project_name != null && data.project_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()));
                }
                return true;
            }
            return false;

        }


        #endregion
    }
}
