using Reflection.BusinessEntity.Finance;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.Presentation.Services;
using System.Windows.Data;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Collections.ObjectModel;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;
using Reflection.ReportingServices;
using Reflection.BusinessEntity.ADM;
using System.Collections.Specialized;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_T024_VM : WorkspaceViewModel<ACC_T006>
    {
        #region AutoSuggest TextBox Declaration Region


        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        #region AutoSuggest TextBox Declaration Region : Master

        private AutoSuggestTextViewModel<dynamic> _ASCurrency { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCurrency
        {
            get { return _ASCurrency; }
            set
            {
                if (_ASCurrency != value)
                {
                    _ASCurrency = value; RaisePropertyChanged("ASCurrency");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASComapny { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASComapny
        {
            get { return _ASComapny; }
            set
            {
                if (_ASComapny != value)
                {
                    _ASComapny = value; RaisePropertyChanged("ASComapny");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASLocation { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLocation
        {
            get { return _ASLocation; }
            set
            {
                if (_ASLocation != value)
                {
                    _ASLocation = value; RaisePropertyChanged("ASLocation");
                }
            }
        }

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

        private AutoSuggestTextViewModel<dynamic> _ASPayMethod { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPayMethod
        {
            get { return _ASPayMethod; }
            set
            {
                if (_ASPayMethod != value)
                {
                    _ASPayMethod = value; RaisePropertyChanged("ASPayMethod");
                }
            }
        }

        #endregion

        #region AutoSuggest TextBox Declaration Region : Datagrid

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

        private AutoSuggestTextViewModel<dynamic> _ASGeneralLedgerDetail { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGeneralLedgerDetail
        {
            get { return _ASGeneralLedgerDetail; }
            set
            {
                if (_ASGeneralLedgerDetail != value)
                {
                    _ASGeneralLedgerDetail = value; RaisePropertyChanged("ASGeneralLedgerDetail");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_RefDocNoDetail { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_RefDocNoDetail
        {
            get { return _AS_RefDocNoDetail; }
            set
            {
                if (_AS_RefDocNoDetail != value)
                {
                    _AS_RefDocNoDetail = value; RaisePropertyChanged("AS_RefDocNoDetail");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_CostCenter { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CostCenter
        {
            get { return _AS_CostCenter; }
            set
            {
                if (_AS_CostCenter != value)
                {
                    _AS_CostCenter = value; RaisePropertyChanged("AS_CostCenter");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPostingKeyDetail { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPostingKeyDetail
        {
            get { return _ASPostingKeyDetail; }
            set
            {
                if (_ASPostingKeyDetail != value)
                {
                    _ASPostingKeyDetail = value; RaisePropertyChanged("ASPostingKeyDetail");
                }
            }
        }

        #endregion

        #region AutoSuggest TextBox Declaration Region : View Tab

        private AutoSuggestTextViewModel<dynamic> _ASFltrt_status { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFltrt_status
        {
            get { return _ASFltrt_status; }
            set
            {
                if (_ASFltrt_status != value)
                {
                    _ASFltrt_status = value; RaisePropertyChanged("ASFltrt_status");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASLocationFilter { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLocationFilter
        {
            get { return _ASLocationFilter; }
            set
            {
                if (_ASLocationFilter != value)
                {
                    _ASLocationFilter = value; RaisePropertyChanged("ASLocationFilter");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDocTypeFilter { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocTypeFilter
        {
            get { return _ASDocTypeFilter; }
            set
            {
                if (_ASDocTypeFilter != value)
                {
                    _ASDocTypeFilter = value; RaisePropertyChanged("ASDocTypeFilter");
                }
            }
        }

        #endregion

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
            try
            {
                if (dgCellInfo != null)
                {
                    var column = dgCellInfo.Column as DataGridColumn;
                    if (column != null)
                    {
                        string headerName = column.Header.ToString();
                        string SourceName = column.SortMemberPath.ToString();

                        if (SourceName == "ledger_gen")
                        {
                            ASDefault = ASGeneralLedgerDetail;
                        }
                        else if (SourceName == "posting_key")
                        {
                            ASDefault = ASPostingKeyDetail;
                        }
                        else if (SourceName == "ref_doc_no")
                        {
                            ASDefault = AS_RefDocNoDetail;
                        }
                        else if (SourceName == "cost_center")
                        {
                            ASDefault = AS_CostCenter;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }

        #endregion

        #region Variable Declaration
        bool isNewRecord = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
        private string doc_type_vm { get; set; }
        WebServiceRepository<ACC_T006> repository = new WebServiceRepository<ACC_T006>();
        WebServiceRepository<MultipleContext_ACC_T006> repository_MC = new WebServiceRepository<MultipleContext_ACC_T006>();
        WebServiceRepository<MultipleContext_ACC_T006> repository_MCTemp = new WebServiceRepository<MultipleContext_ACC_T006>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_ACC_T006 _MC = new MultipleContext_ACC_T006();
        public MultipleContext_ACC_T006 MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value; RaisePropertyChanged("MC");
                }
            }
        }

        private MultipleContext_ACC_T006 _MCTemp = new MultipleContext_ACC_T006();
        public MultipleContext_ACC_T006 MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value; RaisePropertyChanged("MCTemp");
                }
            }
        }

        private MultipleContext_ACC_T006 _MCTemp1 = new MultipleContext_ACC_T006();
        public MultipleContext_ACC_T006 MCTemp1
        {
            get { return _MCTemp1; }
            set
            {
                if (_MCTemp1 != value)
                {
                    _MCTemp1 = value; RaisePropertyChanged("MCTemp1");
                }
            }
        }

        private ACC_T006 _MasterEntity;
        public ACC_T006 MasterEntity
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
        private ObservableCollection<ACC_T006_A> _DetailEntity;
        public ObservableCollection<ACC_T006_A> DetailEntity
        {
            get { return _DetailEntity; }
            set
            {
                if (_DetailEntity != value)
                {
                    _DetailEntity = value; RaisePropertyChanged("DetailEntity");
                    DetailEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                }
            }
        }

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }

        private int _dgSelectedIndexDetail;
        public int dgSelectedIndexDetail
        {
            get { return _dgSelectedIndexDetail; }
            set
            {
                if (_dgSelectedIndexDetail != value)
                {
                    _dgSelectedIndexDetail = value;
                    RaisePropertyChanged("dgSelectedIndexDetail");

                }
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

        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set
            {
                _AttachmentCollection = value;
                RaisePropertyChanged("AttachmentCollection");
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

        #region ICollection for Popup Control

        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }

        private ICollectionView _popupItemCollection;
        public ICollectionView PopupItemCollection
        {
            get { return _popupItemCollection; }
            set { _popupItemCollection = value; RaisePropertyChanged("PopupItemCollection"); }
        }
        #endregion    

        #region StringList Variables

        public List<ADM_M002> _CompList;
        public List<ADM_M002> CompList
        {
            get
            {
                return _CompList;
            }
            set
            {
                _CompList = value;
                RaisePropertyChanged("CompList");
            }
        }

        public List<ADM_M003> _locationList;
        public List<ADM_M003> LocationList
        {
            get
            {
                return _locationList;
            }
            set
            {
                _locationList = value;
                RaisePropertyChanged("LocationList");
            }
        }

        public List<ADM_M002> _CurrencyList;
        public List<ADM_M002> CurrencyList
        {
            get
            {
                return _CurrencyList;
            }
            set
            {
                _CurrencyList = value;
                RaisePropertyChanged("CurrencyList");
            }
        }

        public List<General_Ledger_P> _GenLedgerList;
        public List<General_Ledger_P> GenLedgerList
        {
            get
            {
                return _GenLedgerList;
            }
            set
            {
                _GenLedgerList = value;
                RaisePropertyChanged("GenLedgerList");
            }
        }
        #endregion

        #region  Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        #region  Relay Commands Declaration : Master

        public RelayCommand<object> CommandCompany { get; private set; }
        public RelayCommand<object> CommandLocation { get; private set; }
        public RelayCommand<object> cmdInsertCurrency { get; private set; }
        public RelayCommand<object> cmdInsertDocType { get; private set; }
        public RelayCommand<object> cmdInsertPayMethod { get; private set; }
        #endregion

        #region  Relay Commands Declaration : Datagrid
        public RelayCommand<object> CmdInsertGenLedgerDetail { get; private set; }
        public RelayCommand<object> cmdInsertPostingKeyDetail { get; private set; }
        public RelayCommand<object> cmdInsertRefDocNoDetail { get; private set; }
        public RelayCommand<object> cmdInsertCostCenterDetail { get; private set; }

        #endregion


        public RelayCommand<object> cmdLoadBackFlipData { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowDetail { get; private set; }
        public RelayCommand<object> cmdLoadDocument { get; private set; }
        public RelayCommand<object> CommandViewDocument { get; private set; }
        public RelayCommand<object> cmdExportGrid { get; private set; }

        #endregion

        #region Constructor
        public FICO_T024_VM(string ts_code) : base()
        {
            try
            {
                MasterEntity = new ACC_T006();
                DetailEntity = new ObservableCollection<ACC_T006_A>();
                REQUEST_PARA = new STD_REQ_PARA_BE();
                MC = new MultipleContext_ACC_T006();
                MCTemp = new MultipleContext_ACC_T006();
                MCTemp1 = new MultipleContext_ACC_T006();
                ACC_T006.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
                ACC_T006_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
                LoadInitialData();
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
        public FICO_T024_VM(string ts_code, string doc_cat) : base()
        {
            try
            {
                this.ts_code_vm = ts_code;
                this.doc_cat_vm = doc_cat;
                this.doc_type_vm = doc_cat;
                MasterEntity = new ACC_T006();
                DetailEntity = new ObservableCollection<ACC_T006_A>();
                DetailEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                REQUEST_PARA = new STD_REQ_PARA_BE();
                MC = new MultipleContext_ACC_T006();
                MCTemp = new MultipleContext_ACC_T006();
                MCTemp1 = new MultipleContext_ACC_T006();
                ACC_T006.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
                ACC_T006_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
                LoadInitialData();
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
        public FICO_T024_VM(string ts_code, string doc_cat, string doc_no) : base()
        {
            try
            {
                this.ts_code_vm = ts_code;
                this.doc_no_vm = doc_no;
                this.doc_cat_vm = doc_cat;
                this.doc_type_vm = doc_cat;
                MasterEntity = new ACC_T006();
                DetailEntity = new ObservableCollection<ACC_T006_A>();
                DetailEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                REQUEST_PARA = new STD_REQ_PARA_BE();
                MC = new MultipleContext_ACC_T006();
                MCTemp = new MultipleContext_ACC_T006();
                MCTemp1 = new MultipleContext_ACC_T006();
                ACC_T006.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
                ACC_T006_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
                LoadInitialData();
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

        #region Relay Command Actions 

        #region Relay Command Actions : Master

        private void InsertCurrency_Master(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M037_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.CurrencyMaster.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M037_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.curr_code = POPUPEntityObject.curr_code;
                    MasterEntity.curr_name = POPUPEntityObject.curr_name;

                    CurrencyList = (List<ADM_M002>)AppSessionState.ADM_M002_List;

                    if (MasterEntity.curr_code == CurrencyList[0].curr_code)
                    {
                        MasterEntity.exc_rate = 1.00M;
                    }

                    MasterEntity.curr_code = POPUPEntityObject.curr_code;
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
        private void InsertDocType_Master(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M015_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.DocTypeList.Where(x => x.doc_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M015_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.doc_type = POPUPEntityObject.doc_type;

                    //FilterGenLedgerPopUp();
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
        private void InsertPayMethod_Master(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M027_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PayMethodList.Where(x => x.pay_method.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M027_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.pay_method = POPUPEntityObject.pay_method;
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
        private void InsertCompany(object InputValue)
        {
            string Request = "";
            ADM_M002 POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = CompList.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002>().ToList()[0];
                }
                if (POPUPEntityObject != null) // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.comp_code = POPUPEntityObject.comp_code;
                    MasterEntity.compName = POPUPEntityObject.CompName;
                    MasterEntity.local_currency = POPUPEntityObject.curr_code;
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

            #endregion


        }
        private void InsertLocation(object InputValue)
        {
            string Request = "";
            ADM_M003 POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = LocationList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                }
                if (POPUPEntityObject != null) // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.location_Id = POPUPEntityObject.location_Id;


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

            #endregion

        }
        private void InsertGLCode(object InputValue)
        {
            string Request = "";
            ACC_M003_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.GLCodeMaster.Where(x => x.gl_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)  // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.gl_code = POPUPEntityObject.gl_code;
                    MasterEntity.GlName = POPUPEntityObject.gl_name;

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

            #endregion

        }
        private void InsertCurrency(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M037_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.CurrencyMaster.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M037_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M037_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.curr_code = POPUPEntityObject.curr_code;
                    MasterEntity.curr_name = POPUPEntityObject.curr_name;

                    CurrencyList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    if (MasterEntity.curr_code == CurrencyList[0].curr_code)
                    {
                        MasterEntity.exc_rate = 1.00M;
                    }

                    MasterEntity.curr_code = POPUPEntityObject.curr_code;
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

        #region Relay Command Actions : Datagrid

        private void InsertGeneralLedger(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                General_Ledger_P POPUPEntityObject = null;

                if (MasterEntity.doc_type != null && MasterEntity.doc_type != "")
                {

                    #region Command Parameter Read Section
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.GeneralLedgerList.Where(x => x.ledger_gen.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        if (((IEnumerable)InputValue).Cast<General_Ledger_P>().Count() > 0)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<General_Ledger_P>().ToList()[0];
                        }
                    }

                    #endregion

                    if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                    {
                        //var InputValueIfExists = DetailEntity.Where(X => X.gl_code == POPUPEntityObject.gl_name).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        //int IndexOfExistValue = DetailEntity.IndexOf(DetailEntity.Where(X => X.gl_code == POPUPEntityObject.gl_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                        if (NewRow == true && (AllowDuplicate == true) && DetailEntity.Count == dgSelectedIndexDetail)
                        {
                            DetailEntity.Add(new ACC_T006_A()
                            {
                                ledger_gen = POPUPEntityObject.ledger_gen,
                                ledger_gen_desc = POPUPEntityObject.ledger_gen_desc,
                                gl_code = POPUPEntityObject.gl_code,
                                acc_type = POPUPEntityObject.acc_type,
                                trns_key_code = "ADK",
                            });
                        }
                        else if (dgSelectedIndexDetail >= 0 && DetailEntity.Count > dgSelectedIndexDetail) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            if (DetailEntity[dgSelectedIndexDetail].id == 0) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                            {
                                DetailEntity[dgSelectedIndexDetail].line_id = 0;
                                DetailEntity[dgSelectedIndexDetail].ledger_gen = POPUPEntityObject.ledger_gen;
                                DetailEntity[dgSelectedIndexDetail].ledger_gen_desc = POPUPEntityObject.ledger_gen_desc;
                                DetailEntity[dgSelectedIndexDetail].gl_code = POPUPEntityObject.gl_code;
                                DetailEntity[dgSelectedIndexDetail].acc_type = POPUPEntityObject.acc_type;
                                DetailEntity[dgSelectedIndexDetail].active = true;
                                DetailEntity[dgSelectedIndexDetail].location_Id = AppSessionState.OBJ_LOCATION.location_id;
                                DetailEntity[dgSelectedIndexDetail].comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                                DetailEntity[dgSelectedIndexDetail].trns_key_code = "ADK";
                                DetailEntity[dgSelectedIndexDetail].curr_code = MasterEntity.curr_code;
                                DetailEntity[dgSelectedIndexDetail].exc_rate = MasterEntity.exc_rate;
                                DetailEntity[dgSelectedIndexDetail].local_curr_code = MasterEntity.local_currency;
                            }
                            else if (DetailEntity[dgSelectedIndexDetail].ledger_gen != POPUPEntityObject.ledger_gen)
                            {
                                DetailEntity[dgSelectedIndexDetail].ledger_gen = POPUPEntityObject.ledger_gen;
                                DetailEntity[dgSelectedIndexDetail].ledger_gen_desc = POPUPEntityObject.ledger_gen_desc;
                                DetailEntity[dgSelectedIndexDetail].gl_code = POPUPEntityObject.gl_code;
                                DetailEntity[dgSelectedIndexDetail].acc_type = POPUPEntityObject.acc_type;
                            }
                        }
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("please select Document Type...");
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
        private void InsertPostingKeyDetail(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_Q_P POPUPEntityObject = null;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PostingKeyList.Where(x => x.posting_key.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M003_Q_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_Q_P>().ToList()[0];
                    }
                }

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (dgSelectedIndexDetail >= 0 && DetailEntity.Count > dgSelectedIndexDetail) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        DetailEntity[dgSelectedIndexDetail].posting_key = POPUPEntityObject.posting_key;
                        DetailEntity[dgSelectedIndexDetail].dc_ind = POPUPEntityObject.ind_decr;
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
        private void InsertReferenceDocDetail(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                SEL_T003_PUR_T005_RefDoc POPUPEntityObject = null;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.RefDocData.Where(x => x.ref_doc_no.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SEL_T003_PUR_T005_RefDoc>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T003_PUR_T005_RefDoc>().ToList()[0];
                    }
                }

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (dgSelectedIndexDetail >= 0 && DetailEntity.Count > dgSelectedIndexDetail) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (DetailEntity[dgSelectedIndexDetail].id == 0) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            DetailEntity[dgSelectedIndexDetail].ref_doc_no = POPUPEntityObject.ref_doc_no;
                            DetailEntity[dgSelectedIndexDetail].ref_doc_type = POPUPEntityObject.ref_doc_type;
                        }
                        else if (DetailEntity[dgSelectedIndexDetail].ref_doc_no != POPUPEntityObject.ref_doc_no)
                        {
                            DetailEntity[dgSelectedIndexDetail].ref_doc_no = POPUPEntityObject.ref_doc_no;
                            DetailEntity[dgSelectedIndexDetail].ref_doc_type = POPUPEntityObject.ref_doc_type;
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
        private void InsertCostCenterDetail(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ACC_M019_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.CostCenterMaster.Where(x => x.cost_center.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M019_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M019_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (DetailEntity[dgSelectedIndexDetail].id == 0 && DetailEntity.Count > dgSelectedIndexDetail) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                    {
                        DetailEntity[dgSelectedIndexDetail].cost_center = POPUPEntityObject.cost_center;
                    }
                    else if (DetailEntity[dgSelectedIndexDetail].cost_center != POPUPEntityObject.cost_center)
                    {
                        DetailEntity[dgSelectedIndexDetail].cost_center = POPUPEntityObject.cost_center;
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

        #region Relay Command Actions : View Tab

        private void LoadBackFlipData()
        {
            try
            {
                CursorControl.SetBusyState();

                EntityChangeEnable = false;
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (REQUEST_PARA.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (Utilities.NullIf(REQUEST_PARA.doc_type ?? doc_cat_vm) ?? "") + "!@" + (Utilities.NullIf(REQUEST_PARA.emp_id) ?? "") + "!@" + REQUEST_PARA.active + "!@" + AppSessionState.UserID + "!@" + (REQUEST_PARA.t_status ?? "") + "!@" + (REQUEST_PARA.party_code ?? "") + "!@" + Convert.ToDateTime(REQUEST_PARA.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQUEST_PARA.to_date).ToString("MM/dd/yyyy");
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_T006>(MCTemp, Request, "ACC_T006_BL", "FICO", "LoadAll", 0, "");
                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MCTemp.BACK_FLIP_LIST);
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);
                EntityChangeEnable = true;

                var msg = new NotificationMessage(ts_code_vm);
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

        #endregion

        private void DeleteDataGridRowDetail(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (DetailEntity.Count > i && DetailEntity[dgSelectedIndexDetail].id == 0)
                {
                    DetailEntity[dgSelectedIndexDetail].active = false;
                    DetailEntity.RemoveAt(i);
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
        private void LoadDocumentByDocumentNumber(object ParameterObject)
        {
            try
            {
                STD_LIST_BE POPUPEntityObject = null;
                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];
                        string RequestParameterData = "LOAD_DOCUMENT" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + (POPUPEntityObject.doc_cat ?? this.doc_cat_vm) + "!@" + (POPUPEntityObject.doc_type ?? this.doc_cat_vm) + "!@" + POPUPEntityObject.doc_no;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_T006>(MC, RequestParameterData, "ACC_T006_BL", "FICO", "", 0, "");

                        if (MCTemp.MasterData.Count > 0)
                        {
                            MasterEntity = MCTemp.MasterData[0];
                        }

                        DetailEntity = MCTemp.DetailData;
                        if (MC.GeneralLedgerList != null && DetailEntity.Count > 0)
                        {
                            foreach (var item in DetailEntity)
                            {
                                item.ledger_gen_desc = (from o in MC.GeneralLedgerList
                                                        where o.ledger_gen == item.ledger_gen
                                                        select o.ledger_gen_desc).FirstOrDefault();
                            }
                        }


                    }
                    isNewRecord = false;
                    SelectedTabControlIndex = 0;

                    SetPopupSuggestionDataAfterLoad();
                }
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage(ts_code_vm);
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
        private void LoadBackFlipDocumentByDocumentNumber(object ParameterObject)
        {
            try
            {
                string ParametersStringValue = "";
                if (ParameterObject != null)
                {
                    if (ParameterObject.GetType() == typeof(string))
                    {
                        ParametersStringValue = ParameterObject.ToString().Trim();
                        string RequestParameterData = "LOAD_DOCUMENT" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + ParametersStringValue;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_T006>(MC, RequestParameterData, "ACC_T006_BL", "FICO", "", 0, "");

                        if (MCTemp.MasterData.Count > 0)
                        {
                            MasterEntity = MCTemp.MasterData[0];
                        }

                        DetailEntity = MCTemp.DetailData;
                        if (MC.GeneralLedgerList != null && DetailEntity.Count > 0)
                        {
                            foreach (var item in DetailEntity)
                            {
                                item.ledger_gen_desc = (from o in MC.GeneralLedgerList
                                                        where o.ledger_gen == item.ledger_gen
                                                        select o.ledger_gen_desc).FirstOrDefault();
                            }
                        }

                        if (MCTemp.AttachmentData != null)
                        {
                            AttachmentCollection = MCTemp.AttachmentData;
                        }
                        else
                        {
                            MCTemp.AttachmentData = new List<COM_T003>();
                        }
                    }
                    isNewRecord = false;
                    SelectedTabControlIndex = 0;

                    SetPopupSuggestionDataAfterLoad();
                }
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage(ts_code_vm);
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

        private void SetPopupSuggestionDataAfterLoad()
        {
            try
            {
                ASPayMethod.AutoSuggestVM.Suggestion = MC.PayMethodList.Find(x => x.pay_method == MasterEntity.pay_method);
                ASDocType.AutoSuggestVM.Suggestion = MC.DocTypeList.Find(x => x.doc_type == MasterEntity.doc_type);
                ASCurrency.AutoSuggestVM.Suggestion = MC.CurrencyMaster.Find(x => x.curr_code == MasterEntity.curr_code);
                ASComapny.AutoSuggestVM.Suggestion = CompList.Find(x => x.comp_code == MasterEntity.comp_code);

                var LocList = (from o in LocationList where o.location_Id == AppSessionState.OBJ_LOCATION.location_id select o).ToList();
                ASLocation.AutoSuggestVM.Suggestion = LocList.Find(x => x.location_Id == MasterEntity.location_Id);

                LocList = (from o in LocationList where o.location_Id == AppSessionState.OBJ_LOCATION.location_id select o).ToList();
                ASLocationFilter.AutoSuggestVM.Suggestion = LocList.Find(x => x.location_Id == MasterEntity.location_Id);

                ASGeneralLedgerDetail.AutoSuggestVM.Suggestion = MC.GeneralLedgerList.Find(x => x.ledger_gen == MasterEntity.ledger_gen);
                ASPostingKeyDetail.AutoSuggestVM.Suggestion = MC.PostingKeyList.Find(x => x.posting_key == MasterEntity.posting_key);
                AS_RefDocNoDetail.AutoSuggestVM.Suggestion = MC.RefDocData.Find(x => x.ref_doc_no == MasterEntity.ref_doc_no);
                AS_CostCenter.AutoSuggestVM.Suggestion = MC.CostCenterMaster.Find(x => x.cost_center == MasterEntity.cost_center);

            }
            catch (Exception ex) { }
        }
        private void ViewDocument(object InputValue)
        {
            try
            {
                //SEL_T003_PUR_T005_RefDoc POPUPEntityObject = null;
                //UserAuthontication_Result userAuth = new UserAuthontication_Result();
                //if (InputValue != null && ((IEnumerable)InputValue).Cast<SEL_T003_PUR_T005_RefDoc>().Count() > 0)
                //{
                //    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T003_PUR_T005_RefDoc>().ToList()[0];
                //}

                //var docdetails = AppSessionState.UserAuthorisations.Where(X => X.TranCode == POPUPEntityObject.TranCode).FirstOrDefault();
                //userAuth = docdetails;
                //AppSessionState.UserAuthSingle = userAuth;
                //AppSessionState.ViewTitle = userAuth.DisTitl;
                //AppSessionState.TransValueType = POPUPEntityObject.ref_doc_no;
                //AppSessionState.TransId = userAuth.id.ToString();

                //if (userAuth.SbModCod != null && userAuth.SbModCod != "" && userAuth.ClsFileName != null && userAuth.ClsFileName != "")
                //{
                //    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.Nspace);
                //    Assembly assembly = Assembly.LoadFile(path1);
                //    Type type = assembly.GetType(userAuth.ClsFileName);
                //    if (type != null)
                //    {
                //        dynamic instance = Activator.CreateInstance(type);
                //        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                //    }
                //}
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
        private void ExportDocument(object InputValue)
        {
            try
            {

                // This is for List Collection
                ExportToExcelFromOC<ACC_T006_A, List<ACC_T006_A>> exportOC = new ExportToExcelFromOC<ACC_T006_A, List<ACC_T006_A>>();
                exportOC.OCCollectionData = DetailEntity;
                exportOC.GenerateReport();

                // This is for List ObservarableCollection
                ExportToExcel<STD_LIST_BE, List<STD_LIST_BE>> exportList = new ExportToExcel<STD_LIST_BE, List<STD_LIST_BE>>();
                exportList.ListCollectionData = MC.BACK_FLIP_LIST;
                exportList.GenerateReport();
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

        //might have to filter ledger general popup on selection of doc type may have to implement logic later 
        private void FilterGenLedgerPopUp()
        {
            try
            {
                if (MasterEntity.doc_type == "DD") //Accounting Document
                {
                    GenLedgerList = (from o in MC.GeneralLedgerList where o.ledger_gen_type == "glcode" || o.ledger_gen_type == "party" || o.ledger_gen_type == "bank" || o.ledger_gen_type == "employee" || o.ledger_gen_type == "cash" select o).ToList();
                }
                else if (MasterEntity.doc_type == "JV")  //Journal Voucher
                {
                    GenLedgerList = (from o in MC.GeneralLedgerList where o.ledger_gen_type == "glcode" || o.ledger_gen_type == "party" || o.ledger_gen_type == "employee" || o.ledger_gen_type == "cash" select o).ToList();
                }
                else if (MasterEntity.doc_type == "BV")  //Bank Voucher
                {
                    GenLedgerList = (from o in MC.GeneralLedgerList where o.ledger_gen_type == "glcode" || o.ledger_gen_type == "party" || o.ledger_gen_type == "bank" || o.ledger_gen_type == "employee" || o.ledger_gen_type == "cash" select o).ToList();
                }
                else if (MasterEntity.doc_type == "CE") //Contra Voucher
                {
                    GenLedgerList = (from o in MC.GeneralLedgerList where o.ledger_gen_type == "bank" || o.ledger_gen_type == "cash" select o).ToList();
                }
                else if (MasterEntity.doc_type == "CA") //Cash Voucher
                {
                    GenLedgerList = (from o in MC.GeneralLedgerList where o.ledger_gen_type == "glcode" || o.ledger_gen_type == "party" || o.ledger_gen_type == "bank" || o.ledger_gen_type == "employee" || o.ledger_gen_type == "cash" select o).ToList();
                }

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((General_Ledger_P)x).ledger_gen);
                TheFilter = (o, prefix) => (((General_Ledger_P)o).ledger_gen ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((General_Ledger_P)o).ledger_gen_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASGeneralLedgerDetail = new AutoSuggestTextViewModel<dynamic>(GenLedgerList, TheFilter, SuggestedValue, "ledger_gen", "ledger_gen", true);
                ASGeneralLedgerDetail.AutoSuggestVM.IsEmptyValueAllowed = true;

                //Default General Ledger Pop_Up for Detail Entity (Datagrid)
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((General_Ledger_P)x).ledger_gen);
                TheFilter = (o, prefix) => (((General_Ledger_P)o).ledger_gen ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((General_Ledger_P)o).gl_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(GenLedgerList, TheFilter, SuggestedValue, "ledger_gen", "ledger_gen", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                PopupItemCollection = CollectionViewSource.GetDefaultView(GenLedgerList);
                PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
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
        protected override void OnCreateAction(InquiryActionResult<ACC_T006> result)
        {
            try
            {
                isNewRecord = true;
                MasterEntity = new ACC_T006();
                DetailEntity = new ObservableCollection<ACC_T006_A>();
                DetailEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                DefaultValues();

                var msg = new NotificationMessage(ts_code_vm);
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex) { }
        }
        protected override void OnPrintAction(InquiryActionResult<ACC_T006> result)
        {
            CursorControl.SetBusyState();
            try
            {

                object[] objDataSource = new object[4];
                string[] objDataSourceName = new string[4];

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[0] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[1] = Result;
                MC.MasterData.Add(MasterEntity);

                objDataSource[2] = MC.MasterData;
                objDataSource[3] = DetailEntity;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsMaster";
                objDataSourceName[3] = "dsItem";

                ReportManager ReportManager = new ReportManager();

                var ReportStringList = (from o in MC.DOC_TYPE_LIST where o.doc_cat == MasterEntity.doc_type select o).ToList();

                string ReportDisplayName = MasterEntity.doc_no + "_" + MasterEntity.doc_date.ToShortDateString();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\TXN\\" + ReportStringList[0].report_name, getParametersList(), ReportDisplayName);
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
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", AppSessionState.Name);
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
            return result;
        }
        protected override void OnDocumentAction()
        {
            try
            {
                CursorControl.SetBusyState();

                if (!string.IsNullOrEmpty(MasterEntity.doc_no))
                {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.AttachmentData, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) });
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
        protected override void OnRefreshCommand(InquiryActionResult<ACC_T006> result)
        {
            LoadInitialData();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_T006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_T006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_T006> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_T006> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnSaveAction(InquiryActionResult<ACC_T006> result)
        {
            try
            {

                if (Validation() == true)
                {
                    Logging();
                    MasterEntity.doc_curr_amt = MasterEntity.credit;
                    MasterEntity.loc_curr_amt = MasterEntity.doc_curr_amt * MasterEntity.exc_rate;
                    MasterEntity.XmlDataDocument_ACC_T006_A = obj.ObjectToXML(DetailEntity);

                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ACC_T006>(MasterEntity, "ACC_T006_BL", "FICO");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ACC_T006>(MasterEntity, "ACC_T006_BL", "FICO");
                    }

                    if (MasterEntity.doc_no != null && isNewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully...");
                        showMessageService.ShowMessage();
                    }
                    else if (MasterEntity.doc_no != null && isNewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Updated Successfully...");
                        showMessageService.ShowMessage();
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    isNewRecord = false;
                }
                var msg = new NotificationMessage(ts_code_vm);
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
        protected override void OnRemoveAction(InquiryActionResult<ACC_T006> result)
        { }
        protected override void OnDiscardAction(InquiryActionResult<ACC_T006> result)
        { }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_T006> result)
        { }
        protected override void OnFlipAction(InquiryActionResult<ACC_T006> result)
        { }
        protected override void OnHelpAction(InquiryActionResult<ACC_T006> result)
        { }
        #endregion

        #region ModelEntityUpdated
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            try
            {
                if (sender.ToString() == "exc_rate" || sender.ToString() == "active")
                {
                    CalAmount();
                }
                this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            }
            catch (Exception ex) { }
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            try
            {
                if (sender.ToString() == "doc_curr_amt" || sender.ToString() == "exc_rate" || sender.ToString() == "posting_key" || sender.ToString() == "dc_ind" || sender.ToString() == "active")
                {
                    CalLocalAmount();
                    CalTotal();
                }
            }
            catch (Exception ex) { }
        }
        private void CalLocalAmount()
        {
            try
            {
                if (DetailEntity.Count > 0 && DetailEntity.Count > dgSelectedIndexDetail && dgSelectedIndexDetail >= 0)
                {
                    if (Convert.ToDecimal(MasterEntity.exc_rate) > 0)
                    {
                        if (DetailEntity[dgSelectedIndexDetail].active == true)
                        {
                            DetailEntity[dgSelectedIndexDetail].loc_curr_amt = Convert.ToDecimal(DetailEntity[dgSelectedIndexDetail].doc_curr_amt) * Convert.ToDecimal(MasterEntity.exc_rate);
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void CalTotal()
        {
            try
            {
                if (DetailEntity.Count > 0)
                {
                    MasterEntity.debit = 0;
                    MasterEntity.credit = 0;

                    foreach (var item in DetailEntity)
                    {
                        if (item.dc_ind == "D" && item.active == true)
                        {
                            MasterEntity.debit = MasterEntity.debit + Convert.ToDecimal(item.doc_curr_amt);
                        }
                        else if (item.dc_ind == "C" && item.active == true)
                        {
                            MasterEntity.credit = MasterEntity.credit + Convert.ToDecimal(item.doc_curr_amt);
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void CalAmount() // if exc_rate enter at last then do all calculations
        {
            try
            {
                if (DetailEntity.Count > 0)
                {
                    foreach (var item in DetailEntity)
                    {
                        if (item.active == true)
                        {
                            item.loc_curr_amt = item.doc_curr_amt * Convert.ToDecimal(MasterEntity.exc_rate);
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        #endregion

        #region User Defined Functions
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
                DefaultValues();
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    //LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    LoadBackFlipDocumentByDocumentNumber(doc_no_vm);
                    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
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
        private void DefaultValues()
        {
            try
            {

                MasterEntity.doc_cat = this.doc_cat_vm;
                MasterEntity.doc_type = this.doc_cat_vm;
                MasterEntity.active = true;
                MasterEntity.emp_id = AppSessionState.EmpId;
                MasterEntity.emp_name = AppSessionState.EmpName;
                //if (CompList.Count == 1)
                //{
                //    MasterEntity.comp_code = CompList[0].comp_code;
                //}

                MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;

                MasterEntity.doc_date = DateTime.Now;
                MasterEntity.post_date = DateTime.Now;

                MasterEntity.local_currency = AppSessionState.CntryCurncy;
                MasterEntity.curr_code = AppSessionState.CntryCurncy;

                MasterEntity.exc_rate = 1.00M;

                DateTime d = DateTime.UtcNow;
                d = d.AddMonths(-1);
                MasterEntity.Fltr_FrmDate = d;
                MasterEntity.Fltr_ToDate = DateTime.UtcNow;
                MasterEntity.Fltr_active = true;
                MasterEntity.fltr_docType = this.doc_cat_vm;

                var tempt_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o).ToList();

                MasterEntity.t_status = tempt_display[0].t_status;
                MasterEntity.t_display = tempt_display[0].t_display;
            }
            catch (Exception ex) { }
        }
        private void Logging()
        {
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;
        }
        private void LoadInitialData()
        {
            try
            {
                #region Command Initialisation

                #region .Command Initialisation : Master.
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });

                CommandCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
                CommandLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocation(items); });
                cmdInsertCurrency = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrency_Master(items); });
                cmdInsertDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocType_Master(items); });
                cmdInsertPayMethod = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayMethod_Master(items); });
                #endregion

                #region .Command Initialisation : Datagrid.

                CmdInsertGenLedgerDetail = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertGeneralLedger(cmdPara, true, true, true); });
                cmdInsertPostingKeyDetail = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPostingKeyDetail(cmdPara); });
                cmdInsertRefDocNoDetail = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertReferenceDocDetail(cmdPara, false, true, true); });
                cmdInsertCostCenterDetail = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCostCenterDetail(cmdPara, false, true, true); });

                #endregion

                cmdLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(); });
                cmdDeleteDataGridRowDetail = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowDetail(items); });
                cmdLoadDocument = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara); });
                CommandViewDocument = new RelayCommand<object>(items => { if (items == null) { return; } ViewDocument(items); });
                cmdExportGrid = new RelayCommand<object>(items => { if (items == null) { return; } ExportDocument(items); });
                #endregion
                MasterEntity.doc_type = doc_type_vm;
                MasterEntity.doc_cat = doc_cat_vm;

                string Request = "LOAD_INI_VR" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (MasterEntity.location_Id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.userid + "!@" + ts_code_vm;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_T006>(MC, Request, "ACC_T006_BL", "FICO", "LoadAll", 0, "");

                //FlipGridData = MC.FlipGridData.ToList();
                //var DocDataFlipFGrid = (from o in FlipGridData where o.doc_type == "DD" select o).ToList();
                //FlipDataGridCollection = CollectionViewSource.GetDefaultView(DocDataFlipFGrid);
                //FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                #region AutoSuggest Initialisation

                #region AutoSuggest Initialisation : Master

                CompList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CompanyList = (from o in CompList where o.comp_code == AppSessionState.OBJ_COMPANY.comp_code select o).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M002)o).CompName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASComapny = new AutoSuggestTextViewModel<dynamic>(CompanyList, TheFilter, SuggestedValue, "comp_code", true);
                ASComapny.AutoSuggestVM.IsEmptyValueAllowed = false;
                //ASComapny.AutoSuggestVM.IsFreeTextAllowed = true;

                LocationList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var LocList = (from o in LocationList where o.location_Id == AppSessionState.OBJ_LOCATION.location_id select o).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASLocation = new AutoSuggestTextViewModel<dynamic>(LocList, TheFilter, SuggestedValue, "location_Id", true);
                ASLocation.AutoSuggestVM.IsEmptyValueAllowed = true;
                //ASLocation.AutoSuggestVM.IsFreeTextAllowed = true;

                //Currency Pop_Up
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M037_P)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCurrency = new AutoSuggestTextViewModel<dynamic>(MC.CurrencyMaster, TheFilter, SuggestedValue, "curr_code", true);
                ASCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

                //DocType Pop_Up
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M015_P)x).doc_type);
                TheFilter = (o, prefix) => (((SYS_M015_P)o).doc_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M015_P)o).doc_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDocType = new AutoSuggestTextViewModel<dynamic>(MC.DocTypeList, TheFilter, SuggestedValue, "doc_type", true);
                ASDocType.AutoSuggestVM.IsEmptyValueAllowed = true;

                //Pay Method Pop_Up
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M027_P)x).pay_method);
                TheFilter = (o, prefix) => (((ACC_M027_P)o).pay_method ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M027_P)o).pay_method_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPayMethod = new AutoSuggestTextViewModel<dynamic>(MC.PayMethodList, TheFilter, SuggestedValue, "pay_method", true);
                ASPayMethod.AutoSuggestVM.IsEmptyValueAllowed = true;
                #endregion

                #region AutoSuggest Initialisation : View Tab

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASFltrt_status = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "fltr_t_display", true);
                ASFltrt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                LocationList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                LocList = (from o in LocationList where o.location_Id == AppSessionState.OBJ_LOCATION.location_id select o).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASLocationFilter = new AutoSuggestTextViewModel<dynamic>(LocList, TheFilter, SuggestedValue, "fltr_location_Id", true);
                ASLocationFilter.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASLocationFilter.AutoSuggestVM.IsFreeTextAllowed = true;

                //DocType Pop_Up
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M015_P)x).doc_type);
                TheFilter = (o, prefix) => (((SYS_M015_P)o).doc_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M015_P)o).doc_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDocTypeFilter = new AutoSuggestTextViewModel<dynamic>(MC.DocTypeList, TheFilter, SuggestedValue, "fltr_docType", true);
                ASDocTypeFilter.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion

                #region AutoSuggest Initialisation : Datagrid

                //RefDocNo Pop_Up for Detail Entity (Datagrid)

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_PUR_T005_RefDoc)x).ref_doc_no);
                TheFilter = (o, prefix) => (((SEL_T003_PUR_T005_RefDoc)o).ref_doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SEL_T003_PUR_T005_RefDoc)o).ref_doc_date.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                AS_RefDocNoDetail = new AutoSuggestTextViewModel<dynamic>(MC.RefDocData, TheFilter, SuggestedValue, "ref_doc_no", "ref_doc_no", false);
                AS_RefDocNoDetail.AutoSuggestVM.IsEmptyValueAllowed = true;

                //Cost Center Pop_Up for Detail Entity (Datagrid)
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M019_P)x).cost_center);
                TheFilter = (o, prefix) => (((ACC_M019_P)o).cost_center ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M019_P)o).cost_center_Desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_CostCenter = new AutoSuggestTextViewModel<dynamic>(MC.CostCenterMaster, TheFilter, SuggestedValue, "cost_center", "cost_center", true);
                AS_CostCenter.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_Q_P)x).posting_key);
                TheFilter = (o, prefix) => (((ACC_M003_Q_P)o).posting_key ?? "").ToString().ToLower().Contains(prefix) || (((ACC_M003_Q_P)o).ind_decr ?? "").ToString().ToLower().Contains(prefix);
                ASPostingKeyDetail = new AutoSuggestTextViewModel<dynamic>(MC.PostingKeyList, TheFilter, SuggestedValue, "posting_key", "posting_key", true);
                ASPostingKeyDetail.AutoSuggestVM.IsEmptyValueAllowed = true;

                //if (MasterEntity.doc_type == "DD")
                //{
                // GenLedgerList = (from o in MC.GeneralLedgerList where o.ledger_gen_type == "glcode" || o.ledger_gen_type == "party" || o.ledger_gen_type == "bank" || o.ledger_gen_type == "employee" select o).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((General_Ledger_P)x).ledger_gen);
                TheFilter = (o, prefix) => (((General_Ledger_P)o).ledger_gen ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((General_Ledger_P)o).ledger_gen_desc ?? "").ToString().ToLower().Contains(prefix.ToLower())
                                        || (((General_Ledger_P)o).gl_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((General_Ledger_P)o).gl_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASGeneralLedgerDetail = new AutoSuggestTextViewModel<dynamic>(MC.GeneralLedgerList, TheFilter, SuggestedValue, "ledger_gen", "ledger_gen", true);
                ASGeneralLedgerDetail.AutoSuggestVM.IsEmptyValueAllowed = true;

                //Default GL_Code Pop_Up for Detail Entity (Datagrid)
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((General_Ledger_P)x).ledger_gen);
                TheFilter = (o, prefix) => (((General_Ledger_P)o).ledger_gen ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((General_Ledger_P)o).gl_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.GeneralLedgerList, TheFilter, SuggestedValue, "ledger_gen", "ledger_gen", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                PopupItemCollection = CollectionViewSource.GetDefaultView(MC.GeneralLedgerList);
                PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                //}
                #endregion
                #endregion

                DefaultValues();
            }
            catch (Exception ex)
            { }
        }
        private bool Validation()
        {
            try
            {

                if (MasterEntity.exc_rate == null || MasterEntity.exc_rate == 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Exchange Rate...");
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (MasterEntity.doc_cat != "VR" && (MasterEntity.debit != MasterEntity.credit || MasterEntity.debit == null || MasterEntity.credit == null))
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter valid Debit or Credit...");
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (MasterEntity.comp_code == null || MasterEntity.comp_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Company Code...");
                    showMessageService.ShowMessage();
                    return false;
                }

                //if (DetailEntity.Count > 0)
                //{
                foreach (var o in DetailEntity)
                {
                    if (o.ledger_gen == null || o.ledger_gen == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("General Ledger cannot be null or Blank ");
                        showMessageService.ShowMessage();
                        return false;
                    }
                    else if (o.doc_curr_amt == null || o.doc_curr_amt == 0 || o.loc_curr_amt == null || o.loc_curr_amt == 0)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Amount cannot be null or 0");
                        showMessageService.ShowMessage();
                        return false;
                    }
                    else if (o.comp_code == null || o.comp_code == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Select Company code...");
                        showMessageService.ShowMessage();
                        return false;
                    }
                    else if (o.exc_rate == null || o.exc_rate == 0)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Exchange Rate...");
                        showMessageService.ShowMessage();
                        return false;
                    }
                    else if (o.posting_key == null || o.posting_key == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Posting key...");
                        showMessageService.ShowMessage();
                        return false;
                    }
                    else if ((o.cost_center == null || o.cost_center == "") && MC.CostCenterMaster.Count > 0)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Cost Center...");
                        showMessageService.ShowMessage();
                        return false;
                    }
                }
                //}
                //else
                //{
                //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //    showMessageService.ButtonSetup = DialogButton.Ok;
                //    showMessageService.Caption = "Message";
                //    showMessageService.Text = String.Format("Please select atleast 1 Item...");
                //    showMessageService.ShowMessage();
                //}
            }
            catch (Exception ex) { }
            return true;
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {

                if (MasterEntity.XmlDataDocument_ACC_T006_A != null)
                {
                    DetailEntity.Clear();
                    DetailEntity = (ObservableCollection<ACC_T006_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T006_A, MC.DetailData);
                    if (MC.GeneralLedgerList != null && DetailEntity.Count > 0)
                    {
                        foreach (var item in DetailEntity)
                        {
                            item.ledger_gen_desc = (from o in MC.GeneralLedgerList
                                                    where o.ledger_gen == item.ledger_gen
                                                    select o.ledger_gen_desc).FirstOrDefault();
                        }
                    }
                }
                else
                {
                    DetailEntity = new ObservableCollection<ACC_T006_A>();
                }


                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage(ts_code_vm);
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex)
            { }
        }

        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ACC_T006_A item in e.NewItems)
                    {
                        if (item.line_id == 0) // NOTE: This event calls twice and to protect this to increse same line_id twice, this if condition added on 14/12/2022, also update same logic to other VM. Also this logic added to check max value and then increase one, earlier it was assigning row count to new value but if there are 5 item and one deleted then it was assigning same number again.
                        {
                            int maxValue = DetailEntity.Max(x => x.line_id);
                            item.line_id = maxValue + 1;
                        }
                        else
                        {
                            item.line_id = 1;
                        }

                        item.id = 0;
                        if (doc_cat_vm == "VR")
                        {
                            item.posting_key = "31";
                            InsertPostingKeyDetail(item.posting_key);
                        }
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        item.active = true;
                        item.userid = AppSessionState.UserID;
                        item.t_status = MasterEntity.t_status;
                        item.t_display = MasterEntity.t_display;
                        item.curr_code = MasterEntity.curr_code;
                        item.exc_rate = MasterEntity.exc_rate;
                        item.local_curr_code = MasterEntity.local_currency;
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        #endregion

        #region  Filters

        #region Flipgrid
        private string _filterString_FlipGrid;
        public string FilterString_FlipGrid
        {
            get { return _filterString_FlipGrid; }
            set
            {
                _filterString_FlipGrid = value;
                RaisePropertyChanged("FilterString_FlipGrid");
                FilterCollection_FlipGrid();
            }
        }
        private void FilterCollection_FlipGrid()
        {
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as ACC_T002_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_FlipGrid))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.t_display != null && data.t_display.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region FilterMethods
        private string _FLTR_STR_BACKFLIP;
        public string FLTR_STR_BACKFLIP
        {
            get { return _FLTR_STR_BACKFLIP; }
            set
            {
                _FLTR_STR_BACKFLIP = value;
                RaisePropertyChanged("FLTR_STR_BACKFLIP");
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
        public bool FLTR_BACKFLIP(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FLTR_STR_BACKFLIP))
                {
                    return (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())) ||
                          (data.doc_title != null && data.doc_title.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())) ||
                          (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())) ||
                          (data.short_text != null && data.short_text.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())) ||
                          (data.emp_name != null && data.emp_name.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())) ||
                          (data.item_code != null && data.item_code.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())) ||
                          (data.item_name != null && data.item_name.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())) ||
                          (data.doc_date.ToString() != null && data.doc_date.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())) ||
                          (data.obj_no != null && data.obj_no.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())) ||
                          (data.obj_name != null && data.obj_name.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())) ||
                          (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())) ||
                          (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())) ||
                          (data.char_code != null && data.char_code.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())) ||
                          (data.char_name != null && data.char_name.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())) ||
                          (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()));
                }
                return true;
            }
            return false;

        }


        #endregion

        #region .General Ledger Popup.
        private string _filterString_ItemsListPopup;
        public string FilterString_ItemsListPopup
        {
            get { return _filterString_ItemsListPopup; }
            set
            {
                _filterString_ItemsListPopup = value;
                RaisePropertyChanged("FilterString_ItemsListPopup");
                FilterCollection_ItemsListPopup();
            }
        }
        private void FilterCollection_ItemsListPopup()
        {
            if (_popupItemCollection != null)
            {
                _popupItemCollection.Refresh();
            }
        }
        public bool Filter_ItemsListPopup(object obj)
        {
            var data = obj as General_Ledger_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ItemsListPopup))
                {
                    return (data.ledger_gen != null && data.ledger_gen.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower()) ||
                           (data.ledger_gen_desc != null && data.ledger_gen_desc.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            (data.gl_code != null && data.gl_code.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            data.acc_type != null && data.acc_type.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower()));
                }
                return true;
            }
            return false;
        }


        #endregion
        #endregion
    }
}
