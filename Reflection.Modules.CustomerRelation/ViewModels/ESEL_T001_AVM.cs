using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using System.Windows;
using Reflection.ReportingServices;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class ESEL_T001_AVM : WorkspaceViewModel<ESEL_T001_A>
    {
        bool isNewRecord = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        WebServiceRepository<ESEL_T001_A> repository = new WebServiceRepository<ESEL_T001_A>();
        WebServiceRepository<MultipleContext_ESEL_T001_A> repository_MC = new WebServiceRepository<MultipleContext_ESEL_T001_A>();
        WebServiceRepository<MultipleContext_ESEL_T001_A> repository_MCTemp = new WebServiceRepository<MultipleContext_ESEL_T001_A>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(ESEL_T001_AVM));
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
        private AutoSuggestTextViewModel<dynamic> _ASMasterEntity { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASMasterEntity
        {
            get { return _ASMasterEntity; }
            set
            {
                if (_ASMasterEntity != value)
                {
                    _ASMasterEntity = value; RaisePropertyChanged("ASMasterEntity");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDatagridItem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDatagridItem
        {
            get { return _ASDatagridItem; }
            set
            {
                if (_ASDatagridItem != value)
                {
                    _ASDatagridItem = value; RaisePropertyChanged("ASDatagridItem");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASFormType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFormType
        {
            get { return _ASFormType; }
            set
            {
                if (_ASFormType != value)
                {
                    _ASFormType = value; RaisePropertyChanged("ASFormType");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASFormTypeReport { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFormTypeReport
        {
            get { return _ASFormTypeReport; }
            set
            {
                if (_ASFormTypeReport != value)
                {
                    _ASFormTypeReport = value; RaisePropertyChanged("ASFormTypeReport");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASCustomerReport { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCustomerReport
        {
            get { return _ASCustomerReport; }
            set
            {
                if (_ASCustomerReport != value)
                {
                    _ASCustomerReport = value; RaisePropertyChanged("ASCustomerReport");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASCustomer { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCustomer
        {
            get { return _ASCustomer; }
            set
            {
                if (_ASCustomer != value)
                {
                    _ASCustomer = value; RaisePropertyChanged("ASCustomer");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASFinYear { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFinYear
        {
            get { return _ASFinYear; }
            set
            {
                if (_ASFinYear != value)
                {
                    _ASFinYear = value; RaisePropertyChanged("ASFinYear");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASFinYearReport { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFinYearReport
        {
            get { return _ASFinYearReport; }
            set
            {
                if (_ASFinYearReport != value)
                {
                    _ASFinYearReport = value; RaisePropertyChanged("ASFinYearReport");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASInvoiceNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASInvoiceNo
        {
            get { return _ASInvoiceNo; }
            set
            {
                if (_ASInvoiceNo != value)
                {
                    _ASInvoiceNo = value; RaisePropertyChanged("ASInvoiceNo");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASQuarter { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASQuarter
        {
            get { return _ASQuarter; }
            set
            {
                if (_ASQuarter != value)
                {
                    _ASQuarter = value; RaisePropertyChanged("ASQuarter");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASQuarterReport { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASQuarterReport
        {
            get { return _ASQuarterReport; }
            set
            {
                if (_ASQuarterReport != value)
                {
                    _ASQuarterReport = value; RaisePropertyChanged("ASQuarterReport");
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
                    if (SourceName == "entry_no")
                    { ASDefault = ASDatagridItem; }
                }
            }
        }

        #endregion

        #region Declarations

        private MultipleContext_ESEL_T001_A _MC;
        public MultipleContext_ESEL_T001_A MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ESEL_T001_A _MCTemp;
        public MultipleContext_ESEL_T001_A MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_ESEL_T001_A _MCTemp1;
        public MultipleContext_ESEL_T001_A MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private MultipleContext_ESEL_T001_A _MCTemp2;
        public MultipleContext_ESEL_T001_A MCTemp2
        {
            get { return _MCTemp2; }
            set { _MCTemp2 = value; RaisePropertyChanged("MCTemp2"); }
        }

        private ESEL_T001_A _MasterEntity;
        public ESEL_T001_A MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private ObservableCollection<ESEL_T001_B> _DetailEntity;
        public ObservableCollection<ESEL_T001_B> DetailEntity
        {
            get { return _DetailEntity; }
            set
            {
                if (_DetailEntity != value)
                {
                    _DetailEntity = value;
                    RaisePropertyChanged("DetailEntity");
                }
            }
        }

        private ICollectionView _ReportEntity;
        public ICollectionView ReportEntity
        {
            get { return _ReportEntity; }
            set
            {
                if (_ReportEntity != value)
                {
                    _ReportEntity = value;
                    RaisePropertyChanged("ReportEntity");
                }
            }
        }        

        private List<ESEL_T001_A_BackFlip> _FlipGridData;
        public List<ESEL_T001_A_BackFlip> FlipGridData
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

        public List<SEL_T003_P> _DetailListForPopup;
        public List<SEL_T003_P> DetailListForPopup
        {
            get
            {
                return _DetailListForPopup;
            }
            set
            {
                _DetailListForPopup = value;
                RaisePropertyChanged("DetailListForPopup");
            }
        }

        private int _dgSelectedIndexDetail;
        public int dgSelectedIndexDetail
        {
            get
            { return _dgSelectedIndexDetail; }
            set
            {
                if (_dgSelectedIndexDetail != value)
                {
                    _dgSelectedIndexDetail = value;
                    RaisePropertyChanged("dgSelectedIndexDetail");
                }
            }
        }

        private int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _SelectedTabControlIndex; }
            set
            {
                if (_SelectedTabControlIndex != value)
                {
                    _SelectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ICollectionView _popupInvoiceCollection;
        public ICollectionView PopupInvoiceCollection
        {
            get { return _popupInvoiceCollection; }
            set { _popupInvoiceCollection = value; RaisePropertyChanged("PopupInvoiceCollection"); }
        }

        private List<string> _StringListDetail;
        public List<string> StringListDetail
        {
            get { return _StringListDetail; }
            set
            {
                if (_StringListDetail != value)
                {
                    _StringListDetail = value;
                }
            }
        }

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set
            {
                if (_AttachmentCollection != value)
                {
                    _AttachmentCollection = value;
                    RaisePropertyChanged("AttachmentCollection");
                }
            }
        }
        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdAddCustomer { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdPrintReport { get; private set; }
        public RelayCommand<object> CmdAddCustomerReport { get; private set; }
        public RelayCommand<object> CmdAddFormType { get; private set; }
        public RelayCommand<object> CmdAddFormTypeReport { get; private set; }
        public RelayCommand<object> cmdInsertQuarter { get; private set; }
        public RelayCommand<object> cmdInsertQuarterReport { get; private set; }
        public RelayCommand<object> CmdAddInvoice { get; private set; }
        public RelayCommand<object> CmdAddFinYear { get; private set; }
        public RelayCommand<object> CmdAddFinYearReport { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowDetail { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdLoadInvoice { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdLoadInvoiceReport { get; private set; }

        #endregion

        #region Event Handler

        #endregion

        #region Constructor
        public ESEL_T001_AVM() : base()
        {
            MasterEntity = new ESEL_T001_A();
            DetailEntity = new ObservableCollection<ESEL_T001_B>();
            MC = new MultipleContext_ESEL_T001_A();
            MCTemp = new MultipleContext_ESEL_T001_A();
            MCTemp1 = new MultipleContext_ESEL_T001_A();
            MCTemp2 = new MultipleContext_ESEL_T001_A();
            ESEL_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Detail);
            LoadInitialData();
        }
        public ESEL_T001_AVM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new ESEL_T001_A();
            DetailEntity = new ObservableCollection<ESEL_T001_B>();
            MC = new MultipleContext_ESEL_T001_A();
            MCTemp = new MultipleContext_ESEL_T001_A();
            MCTemp1 = new MultipleContext_ESEL_T001_A();
            MCTemp2 = new MultipleContext_ESEL_T001_A();
            ESEL_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Detail);
            LoadInitialData();
        }
        public ESEL_T001_AVM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new ESEL_T001_A();
            DetailEntity = new ObservableCollection<ESEL_T001_B>();
            MC = new MultipleContext_ESEL_T001_A();
            MCTemp = new MultipleContext_ESEL_T001_A();
            MCTemp1 = new MultipleContext_ESEL_T001_A();
            MCTemp2 = new MultipleContext_ESEL_T001_A();
            ESEL_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Detail);
            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ESEL_T001_A>(MC, Request, "FormReceivedFrmCustomer", "CRM", "LoadInitialData", 0, "");
                #region Commands
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
                CmdAddCustomer = new RelayCommand<object>(items => { if (items == null) { return; } InsertCustomer(items); });
                CmdAddCustomerReport = new RelayCommand<object>(items => { if (items == null) { return; } InsertCustomerReport(items); });
                CmdAddFormType = new RelayCommand<object>(items => { if (items == null) { return; } InsertFormType(items); });
                CmdAddFormTypeReport = new RelayCommand<object>(items => { if (items == null) { return; } InsertFormTypeReport(items); });
                cmdInsertQuarter = new RelayCommand<object>(items => { if (items == null) { return; } InsertQuarter(items); });
                cmdInsertQuarterReport = new RelayCommand<object>(items => { if (items == null) { return; } InsertQuarterReport(items); });
                CmdAddFinYear = new RelayCommand<object>(items => { if (items == null) { return; } InsertFinYear(items); });
                CmdAddFinYearReport = new RelayCommand<object>(items => { if (items == null) { return; } InsertFinYearReport(items); });
                CmdAddInvoice = new RelayCommand<object>(items => { if (items == null) { return; } InsertInvoice(items, true, true, true); });
                CmdDeleteDataGridRowDetail = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail(items); });
                cmdLoadInvoice = new GalaSoft.MvvmLight.Command.RelayCommand(() => { LoadInvoice(); });
                cmdPrintReport = new GalaSoft.MvvmLight.Command.RelayCommand(() => { PrintReport(); });
                cmdLoadInvoiceReport = new GalaSoft.MvvmLight.Command.RelayCommand(() => { LoadPendingInvoice(); });
                #endregion
                FlipGridData = MC.BackFlipEntity;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                //For Data Grid PopUp
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P)x).bill_doc);
                TheFilter = (o, prefix) => ((SEL_T003_P)o).bill_doc.ToLower().Contains(prefix);
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.Invoice, TheFilter, SuggestedValue, "inv_no", "bill_doc", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                //ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P)x).PartyId);
                TheFilter = (o, prefix) => ((SEL_T003_P)o).PartyId.ToLower().Contains(prefix) || ((SEL_T003_P)o).PartyName.ToLower().Contains(prefix);
                ASCustomer = new AutoSuggestTextViewModel<dynamic>(MC.Customer, TheFilter, SuggestedValue, "PartyId", true);
                ASCustomer.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P)x).PartyId);
                TheFilter = (o, prefix) => ((SEL_T003_P)o).PartyId.ToLower().Contains(prefix) || ((SEL_T003_P)o).PartyName.ToLower().Contains(prefix);
                ASCustomerReport = new AutoSuggestTextViewModel<dynamic>(MC.CustomerInReport, TheFilter, SuggestedValue, "PartyId", true);
                ASCustomerReport.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M013_P)x).description.ToString());
                TheFilter = (o, prefix) => ((ACC_M013_P)o).description.ToString().ToLower().Contains(prefix);
                ASFormType = new AutoSuggestTextViewModel<dynamic>(MC.FormType, TheFilter, SuggestedValue, "description", true);
                ASFormType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M013_P)x).description.ToString());
                TheFilter = (o, prefix) => ((ACC_M013_P)o).description.ToString().ToLower().Contains(prefix);
                ASFormTypeReport = new AutoSuggestTextViewModel<dynamic>(MC.FormType, TheFilter, SuggestedValue, "description", true);
                ASFormTypeReport.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M001A_P)x).qtr);
                TheFilter = (o, prefix) => ((ACC_M001A_P)o).qtr.ToLower().Contains(prefix);
                ASQuarter = new AutoSuggestTextViewModel<dynamic>(MC.Quarter, TheFilter, SuggestedValue, "qtr", true);
                ASQuarter.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M001A_P)x).qtr);
                TheFilter = (o, prefix) => ((ACC_M001A_P)o).qtr.ToLower().Contains(prefix);
                ASQuarterReport = new AutoSuggestTextViewModel<dynamic>(MC.QuarterInReport, TheFilter, SuggestedValue, "qtr", true);
                ASQuarterReport.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M001A_P)x).fin_year);
                TheFilter = (o, prefix) => ((ACC_M001A_P)o).fin_year.ToLower().Contains(prefix);
                ASFinYear = new AutoSuggestTextViewModel<dynamic>(MC.FinYear, TheFilter, SuggestedValue, "fin_year", true);
                ASFinYear.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M001A_P)x).fin_year);
                TheFilter = (o, prefix) => ((ACC_M001A_P)o).fin_year.ToLower().Contains(prefix);
                ASFinYearReport = new AutoSuggestTextViewModel<dynamic>(MC.FinYear, TheFilter, SuggestedValue, "fin_year", true);
                ASFinYearReport.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P)x).bill_doc);
                TheFilter = (o, prefix) => ((SEL_T003_P)o).bill_doc.ToLower().Contains(prefix);
                ASInvoiceNo = new AutoSuggestTextViewModel<dynamic>(MC.Invoice, TheFilter, SuggestedValue, "inv_no", "bill_doc", true);
                ASInvoiceNo.AutoSuggestVM.IsEmptyValueAllowed = true;
                //ASInvoiceNo.AutoSuggestVM.IsFreeTextAllowed = true;

                DefaultValues();
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
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.entry_dt = DateTime.Now;
            MasterEntity.active = true;
            MasterEntity.doc_cat = "FR";
            MasterEntity.doc_type = "FR";
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            ESEL_T001_A_BackFlip ParameterEntityObject = new ESEL_T001_A_BackFlip();

            try
            {
                if (((IEnumerable)ParameterObject).Cast<ESEL_T001_A_BackFlip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ESEL_T001_A_BackFlip>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + ParameterEntityObject.entry_no;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ESEL_T001_A>(MCTemp, Request, "FormReceivedFrmCustomer", "CRM", "LoadDocumentByDocumentNumber", 0, "");

                    if (MCTemp.MasterData.Count > 0)
                    {
                        MasterEntity = MCTemp.MasterData[0];
                    }
                    DetailEntity = MCTemp.DetailData;
                    //SetBusinessEntitiesAfterLoad("Save", "");

                }
                isNewRecord = false;
                SelectedTabControlIndex = 0;
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage("ESEL_T001_AVM");
                Messenger.Default.Send<NotificationMessage>(msg);
                SetPopupSuggestionDataAfterLoad();
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
        private void InsertCustomer(object InputValue)
        {
            string Request = "";
            SEL_T003_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Customer.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<SEL_T003_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T003_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.PartyId = POPUPEntityObject.PartyId;
                    MasterEntity.PartyNm = POPUPEntityObject.PartyName;
                }
            }
            catch (Exception ex) { }
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
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
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
        private void InsertCustomerReport(object InputValue)
        {
            string Request = "";
            SEL_T003_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Customer.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<SEL_T003_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T003_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.PartyIdReport = POPUPEntityObject.PartyId;
                    MasterEntity.PartyNmReport = POPUPEntityObject.PartyName;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertFormType(object InputValue)
        {
            string Request = "";
            ACC_M013_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.FormType.Where(x => x.description.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M013_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M013_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.frm_type = POPUPEntityObject.id;
                MasterEntity.description = POPUPEntityObject.description;
            }
        }
        private void InsertFormTypeReport(object InputValue)
        {
            string Request = "";
            ACC_M013_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.FormType.Where(x => x.description.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M013_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M013_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.frm_typeReport = POPUPEntityObject.id;
                MasterEntity.descriptionReport = POPUPEntityObject.description;
            }
        }
        private void InsertQuarter(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M001A_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.Quarter.Where(x => x.qtr.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.qtr = POPUPEntityObject.qtr;
                    //MasterEntity.fin_year = POPUPEntityObject.fin_year;
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
        private void InsertQuarterReport(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M001A_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.Quarter.Where(x => x.qtr.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.qtrReport = POPUPEntityObject.qtr;
                    //MasterEntity.fin_year = POPUPEntityObject.fin_year;
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
        private void InsertFinYear(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M001A_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.FinYear.Where(x => x.fin_year.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.fin_year = POPUPEntityObject.fin_year;
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
        private void InsertFinYearReport(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M001A_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.FinYear.Where(x => x.fin_year.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.fin_yearReport = POPUPEntityObject.fin_year;
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
        private void InsertInvoice(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                SEL_T003_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = DetailListForPopup.Where(x => x.bill_doc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T003_P>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = DetailEntity.Where(x => x.inv_no == POPUPEntityObject.bill_doc).FirstOrDefault();
                    int IndexOfExistValue = DetailEntity.IndexOf(DetailEntity.Where(X => X.inv_no == POPUPEntityObject.bill_doc).FirstOrDefault());
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && DetailEntity.Count == dgSelectedIndexDetail)
                    {
                        DetailEntity.Add(new ESEL_T001_B()
                        {
                            id = 0,
                            inv_no = POPUPEntityObject.bill_doc,
                            inv_dt = POPUPEntityObject.doc_date,
                            val_of_goods = POPUPEntityObject.ass_value,
                            tax = POPUPEntityObject.tax_amount,
                            total = POPUPEntityObject.invoice_amt,
                            //total_form = POPUPEntityObject.sub_total,
                            //remark = POPUPEntityObject.,

                            active = true,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,

                        });

                    }
                    else if (dgSelectedIndexDetail >= 0 && DetailEntity.Count > dgSelectedIndexDetail)
                    {
                        if (DetailEntity[dgSelectedIndexDetail].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                        {
                            DetailEntity[dgSelectedIndexDetail].inv_no = POPUPEntityObject.bill_doc;
                            DetailEntity[dgSelectedIndexDetail].inv_dt = POPUPEntityObject.doc_date;
                            DetailEntity[dgSelectedIndexDetail].val_of_goods = POPUPEntityObject.ass_value;
                            DetailEntity[dgSelectedIndexDetail].tax = POPUPEntityObject.tax_amount;
                            DetailEntity[dgSelectedIndexDetail].total = POPUPEntityObject.invoice_amt;

                            DetailEntity[dgSelectedIndexDetail].location_Id = AppSessionState.location_Id;
                            DetailEntity[dgSelectedIndexDetail].comp_code = AppSessionState.comp_code;
                            DetailEntity[dgSelectedIndexDetail].add_by = AppSessionState.UserID;
                            DetailEntity[dgSelectedIndexDetail].active = true;
                        }
                        else if (DetailEntity[dgSelectedIndexDetail].inv_no != POPUPEntityObject.bill_doc)
                        {
                            DetailEntity[dgSelectedIndexDetail].inv_no = "";
                        }


                    }
                }
                #region Clear Empty Row
                ESEL_T001_B newObj = new ESEL_T001_B();
                for (int i = DetailEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = DetailEntity[i].ComparePropertiesTo(newObj);
                    if (DetailEntity[i].ComparePropertiesTo(newObj) == true && DetailEntity.Count > 1)
                    {
                        DetailEntity.RemoveAt(i);
                        if (DetailEntity.Count == 0)
                        {
                            DetailEntity.Add(newObj);
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

        private void LoadInvoice()
        {
            try
            {
                if (Validation1() == true)
                {
                    var Request = "LoadInvoiceDetail" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.PartyId + "!@" + MasterEntity.frm_type + "!@" + MasterEntity.fin_year + "!@" + MasterEntity.qtr;
                    MCTemp1 = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ESEL_T001_A>(MCTemp1, Request, "FormReceivedFrmCustomer", "CRM", "", 0, "");

                    PopupInvoiceCollection = CollectionViewSource.GetDefaultView(MCTemp1.Invoice);
                    PopupInvoiceCollection.Filter = new Predicate<object>(Filter_DetailListPopup);
                    StringListDetail = MCTemp1.Invoice.Select(x => x.bill_doc).ToList();
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

        private void PrintReport()
        {
            try
            {
                string ReportName = "";
                ReportName = "FormReceivedFrmCustomer(Pending).rdlc";
                
                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[0] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[1] = Result;

                objDataSource[2] = MCTemp2.Invoice;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsInvoice";

                ReportManager ReportManager = new ReportManager();

                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, "FormReceivedFrmCustomer");

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

        private void LoadPendingInvoice()
        {
            try
            {
                if (Validation2() == true)
                {
                    var Request = "LoadInvoiceDetail" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.PartyIdReport + "!@" + MasterEntity.frm_typeReport + "!@" + MasterEntity.fin_yearReport + "!@" + MasterEntity.qtrReport;
                    MCTemp2 = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ESEL_T001_A>(MCTemp2, Request, "FormReceivedFrmCustomer", "CRM", "", 0, "");

                    ReportEntity = CollectionViewSource.GetDefaultView(MCTemp2.Invoice);

                    //PopupInvoiceCollection = CollectionViewSource.GetDefaultView(MCTemp2.PendingInvoice);
                    //PopupInvoiceCollection.Filter = new Predicate<object>(Filter_DetailListPopup);
                    //StringListDetail = MCTemp2.PendingInvoice.Select(x => x.bill_doc).ToList();
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

        private bool Validation1()
        {
            if (MasterEntity.PartyId == null || MasterEntity.PartyId == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Customer...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.description == null || MasterEntity.description == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Form Type can not be Null or Zero...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.fin_year == null || MasterEntity.fin_year == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Financial Year...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.qtr == null || MasterEntity.qtr == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please select Quarter...");
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }

        private bool Validation2()
        {
            if (MasterEntity.PartyIdReport == null || MasterEntity.PartyIdReport == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Customer...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.descriptionReport == null || MasterEntity.descriptionReport == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Form Type can not be Null or Zero...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.fin_yearReport == null || MasterEntity.fin_yearReport == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Financial Year...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.qtrReport == null || MasterEntity.qtrReport == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please select Quarter...");
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }

        private void DeleteDataGridRowDetail(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (DetailEntity.Count > i && DetailEntity[dgSelectedIndexDetail].id == 0)
                {
                    DetailEntity.RemoveAt(i);
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
                if (MasterEntity.XmlDataDocument_ESEL_T001_B != null)
                {
                    DetailEntity.Clear();
                    MC.DetailData = (ObservableCollection<ESEL_T001_B>)obj.XMLToObject(MasterEntity.XmlDataDocument_ESEL_T001_B, MC.DetailData);
                    DetailEntity = MC.DetailData;
                }
                else
                {
                    MC.DetailData = new ObservableCollection<ESEL_T001_B>();
                }
                if (MasterEntity.XmlDataDocument_ESEL_T001_Flip != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.BackFlipEntity = (List<ESEL_T001_A_BackFlip>)obj.XMLToObject(MasterEntity.XmlDataDocument_ESEL_T001_Flip, MC.BackFlipEntity);
                    FlipGridData.Add(MC.BackFlipEntity[0]);
                    DataGridCollection.Refresh();
                }
                MasterEntity.ts_code = ts_code_vm;
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
        private bool Validation()
        {
            if (MasterEntity.PartyId == null || MasterEntity.PartyId == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Customer...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.description == null || MasterEntity.description == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Form Type can not be Null or Zero...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.qtr == null || MasterEntity.qtr == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please select Quarter...");
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }
        private void SetPopupSuggestionDataAfterLoad()
        {
            ASCustomer.AutoSuggestVM.Suggestion = MC.Customer.Find(x => x.PartyId == MasterEntity.PartyId);
            ASFormType.AutoSuggestVM.Suggestion = MC.FormType.Find(x => x.description == MasterEntity.description);
            ASQuarter.AutoSuggestVM.Suggestion = MC.Quarter.Find(x => x.qtr == MasterEntity.qtr);
            ASFinYear.AutoSuggestVM.Suggestion = MC.FinYear.Find(x => x.fin_year == MasterEntity.fin_year);
            //ASInvoiceNo.AutoSuggestVM.Suggestion = MC.Invoice.Find(x => x.bill_doc == DetailEntity.inv_no);
        }
        #endregion

        #region ModelEntityUpdated

        void ModelUpdated_Detail(object sender, EventArgs e)
        {
            if (sender.ToString() == "total" || sender.ToString() == "total_form" )
            {
                CalculateTotalInvAmt(true);
            }
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
        }        

        private void CalculateTotalInvAmt(bool compute)
        {
            try
            {
                if (compute == true)
                {
                    decimal? total = 0;
                    decimal? total_form = 0;
                    decimal? total_inv_amt = 0;
                    if (DetailEntity.Count != null && DetailEntity.Count > 0 && dgSelectedIndexDetail >= 0 && dgSelectedIndexDetail < DetailEntity.Count)
                    {
                        if ((DetailEntity[dgSelectedIndexDetail].total > 0 || DetailEntity[dgSelectedIndexDetail].total_form > 0) && DetailEntity[dgSelectedIndexDetail].active != false)
                        {
                            DetailEntity[dgSelectedIndexDetail].total_inv_amt = (Convert.ToDecimal(DetailEntity[dgSelectedIndexDetail].total) - Convert.ToDecimal(DetailEntity[dgSelectedIndexDetail].total_form));
                            //DetailEntity[dgSelectedIndexDetail].total_inv_amt = Convert.ToDecimal(DetailEntity[dgSelectedIndexDetail].total_inv_amt);
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
        #endregion

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<ESEL_T001_A> result)
        {
            try
            {
                MasterEntity.editby = AppSessionState.UserID;
                MasterEntity.XmlDataDocument_ESEL_T001_B = obj.ObjectToXML(DetailEntity);
                this.MasterEntity.EndEdit();
                if (Validation() == true)
                {
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ESEL_T001_A>(MasterEntity, "FormReceivedFrmCustomer", "CRM");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ESEL_T001_A>(MasterEntity, "FormReceivedFrmCustomer", "CRM");
                    }

                    if (MasterEntity.entry_no != null && isNewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    if (MasterEntity.entry_no != null && isNewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    isNewRecord = false;
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
        protected override void OnDocumentAction()
        {
            //if (!string.IsNullOrEmpty(MasterEntity.ItemCode))
            //{            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            //    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.ItemCode.Replace("/", "--"), DocumentList = MCTemp.Attachment });
            //}
        }
        protected override void OnRefreshCommand(InquiryActionResult<ESEL_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ESEL_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ESEL_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ESEL_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ESEL_T001_A> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ESEL_T001_A> result)
        {
            isNewRecord = true;
            MasterEntity = new ESEL_T001_A();
            DetailEntity = new ObservableCollection<ESEL_T001_B>();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ESEL_T001_A> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
                //string response = repository.Delete(MasterEntity.SrNo, "FormReceivedFrmCustomer", "CRM");  
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ESEL_T001_A> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ESEL_T001_A> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ESEL_T001_A> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ESEL_T001_A> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ESEL_T001_A> result)
        {
            try
            {
                
                string ReportName = "FormReceivedFrmCustomer.rdlc";
                string Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + MasterEntity.entry_no;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ESEL_T001_A>(MCTemp, Request, "FormReceivedFrmCustomer", "CRM", "LoadDocumentByDocumentNumber", 0, "");

                object[] objDataSource = new object[4];
                string[] objDataSourceName = new string[4];

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[0] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[1] = Result;

                objDataSource[2] = MCTemp.MasterData;
                objDataSource[3] = MCTemp.DetailData;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsMasterEntity";
                objDataSourceName[3] = "dsDetailEntity";

                ReportManager ReportManager = new ReportManager();

                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, "FormReceivedFrmCustomer");

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

        #region Filters

        #region Filters For DataGrid

        private string _filterString;
        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                RaisePropertyChanged("FilterString");
                FilterCollection();
            }
        }
        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ESEL_T001_A_BackFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.entry_no != null && data.entry_no.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.PartyName != null && data.PartyName.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.post_period != null && data.post_period.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.fin_year != null && data.fin_year.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.qtr != null && data.qtr.ToString().ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }


        private string _filterString_DetailListPopup;
        public string FilterString_DetailListPopup
        {
            get { return _filterString_DetailListPopup; }
            set
            {
                _filterString_DetailListPopup = value;
                RaisePropertyChanged("FilterString_DetailListPopup");
                FilterCollection_DetailListPopup();
            }
        }
        private void FilterCollection_DetailListPopup()
        {
            if (_popupInvoiceCollection != null)
            {
                _popupInvoiceCollection.Refresh();
            }
        }
        public bool Filter_DetailListPopup(object obj)
        {
            var data = obj as SEL_T003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_DetailListPopup))
                {
                    return data.bill_doc != null && data.bill_doc.ToString().ToLower().Contains(_filterString_DetailListPopup.ToLower());

                }
                return true;
            }
            return false;
        }

        


        #endregion

        #endregion
    }
}
