using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using System.Collections.ObjectModel;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using Reflection.Presentation.Services;
using System.Collections.Specialized;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.BusinessEntity.Account;
using Reflection.Presentation.Common;

namespace Reflection.Modules.FICO.ViewModels
{
    // VM FOR cr & dr are same and we can keep only one for Credit & Debit Note
    public class FICO_T012_VM : WorkspaceViewModel<PUR_T005>
    {
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_T012_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
        private AutoSuggestTextViewModel<dynamic> _ASRefDocNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRefDocNo
        {
            get { return _ASRefDocNo; }
            set
            {
                if (_ASRefDocNo != value)
                {
                    _ASRefDocNo = value; RaisePropertyChanged("ASRefDocNo");
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
        private AutoSuggestTextViewModel<dynamic> _ASTaxacc { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTaxacc
        {
            get { return _ASTaxacc; }
            set
            {
                if (_ASTaxacc != value)
                {
                    _ASTaxacc = value; RaisePropertyChanged("ASTaxacc");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASItems { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItems
        {
            get { return _ASItems; }
            set
            {
                if (_ASItems != value)
                {
                    _ASItems = value; RaisePropertyChanged("ASItems");
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

        #endregion
        #region Variable Declaration
        bool NewRecord = true;
        public string ts_code_vm { get; set; }
        public string doc_cat_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string ref_doc_cat { get; set; }
        private bool EntityChangeEnable = true;
        private bool AutoRoundupEnable = true;
        private int _RoundUpDecimals;
        private int RoundUpDecimals
        {
            get { return _RoundUpDecimals; }
            set
            {
                if (_RoundUpDecimals != value)
                {
                    _RoundUpDecimals = value; RaisePropertyChanged("RoundUpDecimals");
                }
            }
        }
        WebServiceRepository<PUR_T005> repository = new WebServiceRepository<PUR_T005>();
        WebServiceRepository<MC_PUR_T005> repository_MC = new WebServiceRepository<MC_PUR_T005>();
        WebServiceRepository<MC_PUR_T005> repository_MCTemp = new WebServiceRepository<MC_PUR_T005>();
        ObjectSerializationService obj = new ObjectSerializationService();
        NUMBER_TO_WORDS_CONVERTER NOW_OBJ = new NUMBER_TO_WORDS_CONVERTER();
        IShowMessageViewService sms;

        private MC_PUR_T005 _MC = new MC_PUR_T005();
        public MC_PUR_T005 MC
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
        private MC_PUR_T005 _MCTemp = new MC_PUR_T005();
        public MC_PUR_T005 MCTemp
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
        private PUR_T005 _MasterEntity;
        public PUR_T005 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                    value.BeginEdit();
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
                    _RequestPara = value; RaisePropertyChanged("RequestPara");
                }
            }
        }

        private ObservableCollection<PUR_T005_A> _ItemsEntity;
        public ObservableCollection<PUR_T005_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value; RaisePropertyChanged("ItemsEntity");
                    //ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                }
            }
        }
        private ObservableCollection<ACC_T006_C> _TotalDocumentTaxes;
        public ObservableCollection<ACC_T006_C> TotalDocumentTaxes
        {
            get
            {
                return _TotalDocumentTaxes;
            }
            set
            {
                _TotalDocumentTaxes = value;
                TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
                RaisePropertyChanged("TotalDocumentTaxes");
            }
        }
        private PUR_T005_A _PUR_T005_A_OBJ;
        public PUR_T005_A PUR_T005_A_OBJ
        {
            get { return _PUR_T005_A_OBJ; }
            set
            {
                if (_PUR_T005_A_OBJ != value)
                {
                    _PUR_T005_A_OBJ = value; RaisePropertyChanged("PUR_T005_A_OBJ");
                }
            }
        }
        private ACC_T006_C _ACC_T006_C_OBJ;
        public ACC_T006_C ACC_T006_C_OBJ
        {
            get { return _ACC_T006_C_OBJ; }
            set
            {
                if (_ACC_T006_C_OBJ != value)
                {
                    _ACC_T006_C_OBJ = value; RaisePropertyChanged("ACC_T006_C_OBJ");
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
        #region List
        private List<STD_LIST_BE> _FlipGridData; // Flip DataGrid Data Source
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
        private List<ACC_M013> _SelectedTaxList; // Supporting for Filter Data Source for Parent Taxes. * can be remove.
        public List<ACC_M013> SelectedTaxList
        {
            get { return _SelectedTaxList; }
            set
            {
                if (_SelectedTaxList != value)
                {
                    _SelectedTaxList = value;
                    RaisePropertyChanged("SelectedTaxList");
                }
            }
        }
        #endregion
        #region Dictionary
        private Dictionary<string, object> _taxDictonery; // Tax Popup Data Source
        public Dictionary<string, object> TaxDictonery
        {
            get { return _taxDictonery; }
            set
            {
                if (_taxDictonery != value)
                {
                    _taxDictonery = value;
                    RaisePropertyChanged("TaxDictonery");
                }
            }
        }

        private Dictionary<string, object> _taxDictoneryParent; //Parant Tax List data Source for Popup
        public Dictionary<string, object> TaxDictoneryParent
        {
            get { return _taxDictoneryParent; }
            set
            {
                if (_taxDictoneryParent != value)
                {
                    _taxDictoneryParent = value;
                    RaisePropertyChanged("TaxDictoneryParent");
                }
            }
        }
        #endregion
        #region Collection
        private ICollectionView _ReferenceDocCollection;
        public ICollectionView ReferenceDocCollection
        {
            get { return _ReferenceDocCollection; }
            set { _ReferenceDocCollection = value; RaisePropertyChanged("ReferenceDocCollection"); }
        }
        private ICollectionView _dataGridviewFilter; // This DataGridView filter Schedule Lines for selected item. it will show only schedule for selected item.
        public ICollectionView DataGridViewFilter
        {
            get { return _dataGridviewFilter; }
            set { _dataGridviewFilter = value; RaisePropertyChanged("DataGridViewFilter"); }
        }
        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }
        #endregion
        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdExecuteReferenceDocuments { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdAddSelectedTax { get; private set; }
        public RelayCommand<object> cmdDeleteTax { get; private set; }
        public RelayCommand<object> cmdManualTaxChangedCommand { get; private set; }
        public RelayCommand<object> cmdTaxPopupCommand { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> cmdLoadBackFlipData { get; private set; }
        public RelayCommand<object> cmdOnSelectionOfReferenceDocuments { get; private set; }

        #endregion
        #region Constructor
        public FICO_T012_VM(string ts_code, string doc_cat) : base()
        {
            CursorControl.SetBusyState();
            IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            MC = new MC_PUR_T005();
            MasterEntity = new PUR_T005();
            MCTemp = new MC_PUR_T005();
            ItemsEntity = new ObservableCollection<PUR_T005_A>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            FlipGridData = new List<STD_LIST_BE>();
            RequestPara = new RequestParameters();
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            InitializeCommands();
            LoadInitialData();
        }
        public FICO_T012_VM(string ts_code, string doc_cat, string doc_no) : base()
        {
            CursorControl.SetBusyState();
            IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            this.doc_no_vm = doc_no;
            MC = new MC_PUR_T005();
            MasterEntity = new PUR_T005();
            MCTemp = new MC_PUR_T005();
            ItemsEntity = new ObservableCollection<PUR_T005_A>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            FlipGridData = new List<STD_LIST_BE>();
            RequestPara = new RequestParameters();
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            InitializeCommands();
            LoadInitialData();
        }
        #endregion
        #region LoadInitialData
        private void LoadInitialData()
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadInitialData_STD" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_PUR_T005>(MC, Request, "PUR_T005_BL", "FICO", "LoadAll", 0, "");

                ReferenceDocCollection = CollectionViewSource.GetDefaultView(MC.REF_DOC_LIST); //RefDocTempData = (from o in MC.ReferenceDocumentList where o.doc_cat == "GR" select o).ToList();
                ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M025)x).t_status);
                TheFilter = (o, prefix) => ((SYS_M025)o).t_status.ToString().ToLower().Contains(prefix.ToLower()) || ((SYS_M025)o).t_display.ToString().ToLower().Contains(prefix.ToLower());
                ASStatus = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", "t_status", true);
                ASStatus.AutoSuggestVM.IsEmptyValueAllowed = false; ASStatus.AutoSuggestVM.IsFreeTextAllowed = false;

                TaxDictonery = new Dictionary<string, object>();
                TaxDictonery.Clear();
                TaxDictonery = MC.TAX_LIST.ToDictionary(X => X.id.ToString(), X => (object)X.description);
                var TaxListParent = (from o in MC.TAX_LIST
                                     where o.parent_id == null
                                     select o).ToList();
                SelectedTaxList = TaxListParent;
                TaxDictoneryParent = SelectedTaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);

                // Following Popup Not required for Credit/Debit Note
                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                //TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //ASUOM = new AutoSuggestTextViewModel<dynamic>(MC.UOMList, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                //ASUOM.AutoSuggestVM.IsEmptyValueAllowed = true;ASUOM.AutoSuggestVM.IsFreeTextAllowed = false;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_SI_ItemsList)x).ItemCode);
                //TheFilter = (o, prefix) => ((SEL_T003_P_SI_ItemsList)o).ItemCode.ToString().ToLower().Contains(prefix.ToLower()) || ((SEL_T003_P_SI_ItemsList)o).ItemName.ToString().ToLower().Contains(prefix.ToLower());
                //ASItems = new AutoSuggestTextViewModel<dynamic>(MC.ItemList, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                //ASItems.AutoSuggestVM.IsEmptyValueAllowed = true;ASItems.AutoSuggestVM.IsFreeTextAllowed = false;
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InitializeCommands()
        {
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentWithDocumentNumber(cmdPara, "FlipGridReference"); });
            cmdDeleteTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteTax(cmdPara); });
            cmdManualTaxChangedCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertManualTaxChangedCommand(cmdPara); });
            cmdTaxPopupCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertManualTaxChangedCommand(cmdPara); });
            cmdLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items, null); });
            cmdOnSelectionOfReferenceDocuments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } SelectionOfReferenceDocuments(cmdPara, "FlipGridReference"); });
            cmdExecuteReferenceDocuments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ExecuteReferenceDocuments(cmdPara, "FlipGridReference"); });
        }
        private void OpenDocumentViewer(object InputValue)
        {
            WebServiceRepository<MultipleContext_Attachments> repository_MCAttachments = new WebServiceRepository<MultipleContext_Attachments>();
            List<COM_T003> Attachments = new List<COM_T003>();
            PUR_T005_A EntityObjectParameter = new PUR_T005_A();
            MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();
            try
            {
                if (InputValue != null)
                {
                    EntityObjectParameter = ((IEnumerable)InputValue).Cast<PUR_T005_A>().ToList()[0];
                }
                string Request = "GetAllFiles" + "!@" + EntityObjectParameter.ItemCode;
                //MCAttachments = repository_MCAttachments.GetData<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Reflection.BusinessLogic.ReflectionFileHandlingServices");
                MCAttachments = repository_MCAttachments.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(EntityObjectParameter.ItemCode))
                {

                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), Row_ID = EntityObjectParameter.id.ToString(), DocumentList = MCAttachments.Attachments, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) });
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
        #region Dafault and validation
        private void DefaultValues()
        {
            RoundUpDecimals = 2;
            MasterEntity.doc_cat = doc_cat_vm;
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.active = true;
            MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
            MasterEntity.t_display = (from o in MC.STATUS_LIST where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.post_date = DateTime.Now;
            MasterEntity.inv_rec_date = DateTime.Now;
            MasterEntity.entry_time = Convert.ToString(new TimeSpan());
            DateTime d = DateTime.UtcNow;
            d = d.AddMonths(-1);
            RequestPara.FromDate = d;
            RequestPara.ToDate = DateTime.UtcNow;
            RequestPara.active = true;
            RequestPara.doc_cat = doc_cat_vm;
            RequestPara.comp_code = MasterEntity.comp_code;
            RequestPara.emp_id = AppSessionState.EmpId;
        }
        private void Logging()
        {
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;

            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private bool validation()
        {
            try
            {
                if (MasterEntity.doc_type == null || MasterEntity.doc_type == "")
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please Select Doc Type......."); sms.ShowMessage();
                    return false;
                }

                if (MasterEntity.PartyId == null || MasterEntity.PartyId == "")
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please Select Party......."); sms.ShowMessage();

                    return false;
                }
                if (MasterEntity.post_date == null)
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please Select Posting Date......."); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.po_code == null || MasterEntity.po_code == "")
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please Select Purchase Organisation Code......."); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.pg_code == null || MasterEntity.pg_code == "")
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please Select Purchase Group Code......."); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.curr_code == null || MasterEntity.curr_code == " ")
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please Select Currency Code......."); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.local_currency == MasterEntity.curr_code)
                {
                    MasterEntity.exch_rate = 1;
                }
                if (MasterEntity.ind_trade == null || MasterEntity.ind_trade == "")
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Transation Type is Required"); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.exch_rate == null || MasterEntity.exch_rate == 0)
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please Select Exchange Rate"); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.buss_place == null || MasterEntity.buss_place == "")
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Business place is Required"); sms.ShowMessage();
                    return false;
                }
                if (ItemsEntity.Count < 1)//when form is blank and we save the record
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please Select Item"); sms.ShowMessage();
                    return false;
                }
                else
                {
                    foreach (var o in ItemsEntity)
                    {
                        if (o.ItemCode != null && o.ItemCode != "" && o.item_desc != null)
                        {
                            int flag = 0;
                            if (o.id == 0)
                            {
                                foreach (var p in ItemsEntity)
                                {
                                    if (o.ItemCode == p.ItemCode && o.sku == p.sku && o.ref_doc_no == p.ref_doc_no && o.po_no == p.po_no && p.active == true)
                                    {
                                        flag++;
                                    }
                                }
                                if (flag > 1)
                                {
                                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1}", o.ItemCode, o.sku_desc); sms.ShowMessage();
                                    return false;
                                }
                            }

                            if (o.qty == null || o.qty == 0)
                            {
                                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc); sms.ShowMessage();
                                return false;
                            }
                            if (o.unit_price == null || o.unit_price == 0)
                            {
                                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Unit Price cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc); sms.ShowMessage();
                                return false;
                            }
                            if (o.tax_id != null || o.tax_id != "")
                            {
                                if (TotalDocumentTaxes.Count > 0)
                                {
                                    for (int i = 0; i < TotalDocumentTaxes.Count; i++)
                                    {
                                        if (TotalDocumentTaxes[i].con_type == null || TotalDocumentTaxes[i].con_type == "")
                                        {

                                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Condition Type is Required for Tax {0} ", TotalDocumentTaxes[i].tax_name); sms.ShowMessage();
                                            return false;
                                        }
                                    }
                                }

                            }

                        }
                        else
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please Select Item"); sms.ShowMessage();
                            return false;
                        }
                    }
                }
                if (MasterEntity.t_status == "017")
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Invoice Validated..."); sms.ShowMessage();
                    return false;
                }
            }
            catch (Exception ex)
            {
            }
            return true;
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            try
            {
                //This will get called when the property of an object inside the collection changes
                if (sender.ToString() == "qty" || sender.ToString() == "unit_price" || sender.ToString() == "tax_id" || sender.ToString() == "active" || sender.ToString() == "discount_type" || sender.ToString() == "discount" || sender.ToString() == "discount_amt")
                {
                    Computation(true, 0, AutoRoundupEnable);//this is in use 
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion
        #region Relay Command Implementation
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
                    LoadDocumentWithDocumentNumber(doc_no_vm, "DocumentNo");
                    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                    AppSessionState.ViewOtherRecordAllowed = true;
                }
                else
                {
                    DefaultValues();
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
                if (ItemsEntity.Count > i && PUR_T005_A_OBJ.id == 0)
                {
                    ItemsEntity.RemoveAt(i);
                    Computation(true, 0, AutoRoundupEnable);
                }
            }
            catch (Exception ex) { }
        }
        private void LoadBackFlipData(object doc_cat, string ReferenceValue)
        {
            try
            {
                string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + (MasterEntity.doc_type ?? this.doc_cat_vm) + "!@!@!@" + AppSessionState.EmpId + "!@!@!@!@" + (RequestPara.PartyId ?? "") + "!@!@" + RequestPara.active + "!@" + RequestPara.t_status + "!@" + Convert.ToDateTime(RequestPara.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(RequestPara.ToDate).ToString("MM/dd/yyyy");
                // string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId; //+ "!@" + RequestPara.active + "!@" + RequestPara.t_status + "!@" + RequestPara.PartyId + "!@" + Convert.ToDateTime(RequestPara.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(RequestPara.ToDate).ToString("MM/dd/yyyy");
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_PUR_T005>(MCTemp, Request, "PUR_T005_BL", "FICO", "LoadAll", 0, "");

                FlipGridData = MC.BACK_FLIP_LIST.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private void InsertManualTaxChangedCommand(object InputValue)
        {
            Computation(true, 0, AutoRoundupEnable);
        }
        private void DeleteTax(object InputValue)
        {
            int i = (int)InputValue;
            if (TotalDocumentTaxes.Count > i)
            {
                //TotalDocumentTaxes.Remove(TotalDocumentTaxes.Where(x => x.tax_name == TotalDocumentTaxes[i].tax_name).Single());
                List<ACC_T006_C> copyLocal = new List<ACC_T006_C>();
                copyLocal = TotalDocumentTaxes.ToList();
                foreach (var tax in copyLocal)
                {
                    if (tax.tax_name == TotalDocumentTaxes[i].tax_name && tax.manual == "Manual")
                    {
                        TotalDocumentTaxes.Remove(tax);
                    }
                }
                Computation(true, 0, AutoRoundupEnable);
            }
        }
        private void LoadDocumentWithDocumentNumber(object ParameterObject, string ParameterReference)
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "";
                STD_LIST_BE ParameterEntityObject = null;
                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<PUR_T005_Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];
                        NewRecord = false;
                        Request = "LoadDocumentWithDocumentNumber" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + ParameterEntityObject.doc_no;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_PUR_T005>(MCTemp, Request, "PUR_T005_BL", "FICO", "", 0, "");
                        MasterEntity = MCTemp.MasterEntity[0];
                        ItemsEntity = MCTemp.ItemsEntity;
                        TotalDocumentTaxes = MCTemp.TaxEntity;
                        if (TotalDocumentTaxes.Count() != '0')
                        {
                            TotalDocumentTaxes = MCTemp.TaxEntity;
                        }
                        else
                        {
                            MC.TaxEntity = new ObservableCollection<ACC_T006_C>();
                        }
                        NewRecord = false;
                    }
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
                if (MasterEntity.ref_doc_no != null)
                {
                    MC.REF_DOC_LIST.RemoveAll(X => X.doc_no == MasterEntity.ref_doc_no);
                    ReferenceDocCollection = CollectionViewSource.GetDefaultView(MC.REF_DOC_LIST);
                    ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void SelectionOfReferenceDocuments(object InputValue, string para)
        {
            try
            {
                if (InputValue != null)
                {
                    RequestPara.doc_no = "";
                    STD_LIST_BE REF_OBJ = (STD_LIST_BE)InputValue;
                    var varRefDoc = from o in MC.REF_DOC_LIST
                                    where o.party_code == REF_OBJ.party_code
                                           && o.doc_cat == REF_OBJ.doc_cat
                                           && o.po_code == REF_OBJ.po_code
                                           && o.curr_code == REF_OBJ.curr_code
                                           && o.comp_code == REF_OBJ.comp_code
                                           && o.doc_cat == REF_OBJ.doc_cat
                                    select o;
                    int i = 0;
                    RequestPara.doc_cat = REF_OBJ.doc_cat;
                    foreach (var item in varRefDoc)
                    {
                        if (item.selected == true)
                        {
                            RequestPara.doc_no = RequestPara.doc_no + "," + item.doc_no;
                            i++;
                        }
                    }
                    RequestPara.doc_no = RequestPara.doc_no.ToString().TrimStart(new char[] { ',' });

                    if (i == 0)
                    {
                        ReferenceDocCollection = CollectionViewSource.GetDefaultView(MC.REF_DOC_LIST); //RefDocTempData = (from o in MC.ReferenceDocumentList where o.doc_cat == "GR" select o).ToList();
                        ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    }
                    else
                    {
                        ReferenceDocCollection = CollectionViewSource.GetDefaultView(varRefDoc);
                        ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void ExecuteReferenceDocuments(object ParameterObject, string ParameterReference)
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "";
                if (string.IsNullOrWhiteSpace(RequestPara.doc_no))
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Refernece Selection"; sms.Text = String.Format("Please Select Refernece No", this.Title); sms.ShowMessage();
                }
                else
                {
                    Request = "ExecuteReferenceDocuments" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID + "!@" + ts_code_vm + "!@" + RequestPara.doc_cat + "!@" + RequestPara.doc_no;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_PUR_T005>(MCTemp, Request, "PUR_T005_BL", "FICO", "", 0, "FlipData");

                    if (MCTemp.MasterEntity.Count > 0)
                    {
                        MasterEntity = MCTemp.MasterEntity[0];
                    }
                    else
                    {
                        MasterEntity = new PUR_T005();
                    }
                    if (MCTemp.ItemsEntity.Count > 0)
                    {
                        ItemsEntity = MCTemp.ItemsEntity;
                    }
                    else
                    {
                        ItemsEntity = new ObservableCollection<PUR_T005_A>();
                    }
                    if (TotalDocumentTaxes.Count() != '0')
                    {
                    }
                    else
                    {
                        MC.TaxEntity = new ObservableCollection<ACC_T006_C>();
                    }
                    RequestPara.doc_cat = "";
                    RequestPara.doc_no = "";
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        #endregion
        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<PUR_T005> result)
        {
            NewRecord = true;
            MasterEntity = new PUR_T005();
            MasterEntity.ValidateAsync().Wait();
            ItemsEntity = new ObservableCollection<PUR_T005_A>();
            ItemsEntity.Clear();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            DefaultValues();
        }
        protected override void OnDiscardAction(InquiryActionResult<PUR_T005> result)
        {
        }
        protected override void OnFevoriteAction(InquiryActionResult<PUR_T005> result)
        {
            try
            {
                if (MasterEntity.doc_no != null && MasterEntity.doc_no != "")
                {
                    if (MasterEntity.t_status != "017")
                    {
                        string Request = "ValidateInvoice" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.client + "!@" + MasterEntity.doc_no;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_PUR_T005>(MCTemp, Request, "PUR_T005_BL", "FICO", "LoadAll", 0, "");

                        if (MCTemp.MasterEntity.Count > 0)
                        {
                            if (MCTemp.MasterEntity[0].t_status == "017")
                            {
                                MasterEntity.t_status = MCTemp.MasterEntity[0].t_status;
                                MasterEntity.t_display = (from o in MC.STATUS_LIST where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Invoice Validate Succesfully...");
                                showMessageService.ShowMessage();
                            }
                        }
                    }
                    else if (MasterEntity.t_status == "017")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Invoice Validated...");
                        showMessageService.ShowMessage();
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
        protected override void OnFlipAction(InquiryActionResult<PUR_T005> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<PUR_T005> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<PUR_T005> result)
        {
        }
        protected override void OnDocumentAction()
        {
        }
        protected override void OnRefreshCommand(InquiryActionResult<PUR_T005> result)
        {
            LoadInitialData();
        }
        protected override void OnLedgerViewCommand(InquiryActionResult<PUR_T005> result)
        {
        }
        protected override void OnValidateCommand(InquiryActionResult<PUR_T005> result)
        {
        }
        protected override void OnTraceCommand(InquiryActionResult<PUR_T005> result)
        {
        }
        protected override void OnMailCommand(InquiryActionResult<PUR_T005> result)
        {
        }
        protected override void OnRemoveAction(InquiryActionResult<PUR_T005> result)
        {
            try
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Delete Changes"; sms.Text = String.Format("This record will delete forever '{0}'", this.Title);
                if (sms.ShowMessage() == DialogResult.Ok)
                {
                    this.MasterEntity.CancelEdit();
                    string response = repository.Delete(MasterEntity.doc_no, "PUR_T005_BL", "FICO");
                    MasterEntity = new PUR_T005();
                    ItemsEntity = new ObservableCollection<PUR_T005_A>();
                    NewRecord = true;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnSaveAction(InquiryActionResult<PUR_T005> result)
        {
            try
            {
                CursorControl.SetBusyState();
                if (validation() == true)
                {
                    MasterEntity.XmlDataDocument_PUR_T005_A = obj.ObjectToXML(ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = obj.ObjectToXML(TotalDocumentTaxes);
                    Logging();
                    this.MasterEntity.EndEdit();
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PUR_T005>(MasterEntity, "PUR_T005_BL", "FICO");
                        if (MasterEntity.doc_no != " " || MasterEntity.doc_no != null)
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Data Saved Successfully"); sms.ShowMessage();
                            RemoveReferenceDocuments();
                        }
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<PUR_T005>(MasterEntity, "PUR_T005_BL", "FICO");
                        if (MasterEntity.doc_no != " " || MasterEntity.doc_no != null)
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Data Updated Successfully"); sms.ShowMessage();
                        }
                    }
                    NewRecord = false;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        #endregion
        #region Filter
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
            var data = obj as PUR_T005_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.supplier_party_Nm != null && data.supplier_party_Nm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }

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
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.party_code != null && data.party_code.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.party_name != null && data.party_name.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())

                       );
                }
                return true;
            }
            return false;
        }
        #endregion
        #region TaxComputation Function
        private void Computation(bool Compute, int ItemRowIndex, bool AutoRoundUpFlag)
        {
            if (Compute == true)
            {
                decimal? PreviousTaxValueForBasePrice = 0;
                decimal? BasePrice = 0;
                decimal? TaxAmount = 0;
                decimal? BasicItemAmount = 0;
                decimal? TaxValue = 0;
                decimal? TaxtTotal = 0;
                decimal? UnTaxTotal = 0;
                decimal? GrandTotal = 0;
                decimal? net_value = 0;
                decimal? other_charges = 0;

                if (ItemsEntity != null && ItemsEntity.Count > 0 && ItemRowIndex >= 0 && ItemRowIndex < ItemsEntity.Count && PUR_T005_A_OBJ != null) //Condition satisfy only if Items collection is not empty.
                {
                    if (PUR_T005_A_OBJ.qty >= 0 && PUR_T005_A_OBJ.unit_price >= 0 && PUR_T005_A_OBJ.active != false) // Must not null or empty.
                    {
                        PUR_T005_A_OBJ.gross_value = Math.Round(((PUR_T005_A_OBJ.qty * PUR_T005_A_OBJ.unit_price) ?? 0), RoundUpDecimals);

                        if (PUR_T005_A_OBJ.discount_type == "F")    // Manual Discount value instead of percent.
                        {
                            PUR_T005_A_OBJ.discount = 0;
                            PUR_T005_A_OBJ.subtotal = (PUR_T005_A_OBJ.gross_value) - (PUR_T005_A_OBJ.discount_amt);
                        }
                        else
                        {
                            PUR_T005_A_OBJ.discount_amt = (PUR_T005_A_OBJ.gross_value * ((PUR_T005_A_OBJ.discount ?? 0) / 100));
                            PUR_T005_A_OBJ.discount_amt = decimal.Round((decimal)PUR_T005_A_OBJ.discount_amt, RoundUpDecimals);
                            PUR_T005_A_OBJ.subtotal = (PUR_T005_A_OBJ.gross_value - PUR_T005_A_OBJ.discount_amt);
                            PUR_T005_A_OBJ.subtotal = decimal.Round((decimal)(PUR_T005_A_OBJ.subtotal ?? 0), RoundUpDecimals);
                        }
                    }
                    #region Calculate Taxes for New/Edited Items row.
                    if (!String.IsNullOrEmpty(PUR_T005_A_OBJ.tax_id) && PUR_T005_A_OBJ.active == true) //Condition satisfy only if Selected Item not null and Taxes are applied.
                    {
                        #region Tax Not Null
                        List<ACC_M013> TaxListTemp = new List<ACC_M013>();
                        string[] TaxArray = PUR_T005_A_OBJ.tax_id.Trim().Split(',');
                        foreach (string SingleTax in TaxArray) // select all Taxes & Child Taxes which is applicablt for Item.
                        {
                            foreach (ACC_M013 PickTax in MC.TAX_LIST)
                            {
                                if (PickTax.id == Convert.ToInt32(SingleTax) || PickTax.parent_id == Convert.ToInt32(SingleTax))
                                {
                                    TaxListTemp.Add(PickTax); // collection of All Parent and Child Taxes applicable for current Item.
                                }
                            }
                        }
                        int?[] TaxListForBaseInclude = new int?[TaxListTemp.Count];
                        for (int i = 0; i < TaxListTemp.Count; i++) // Collect Taxes having property Include_base = true.
                        {
                            if (TaxListTemp[i].include_base_amount == true)
                            {
                                TaxListForBaseInclude[i] = (int?)TaxListTemp[i].id;
                            }
                        }
                        TaxListTemp = TaxListTemp.OrderBy(tax => tax.sequence).ToList(); // Set ascending order of Taxex by sequence column to get Base amount for next/current Tax. Base Amount = Sub Total + Previous Tax Amount. (Previous Tax= Having column Include_Base_amount = True)
                        if (TaxListTemp.Count > 0)
                        {
                            foreach (ACC_M013 SingleTax in TaxListTemp) // Foreach Loop for Computation of Induvidual Tax as per the proerties in Tax Master.
                            {
                                PreviousTaxValueForBasePrice = 0;
                                BasePrice = 0;
                                TaxAmount = 0;
                                BasicItemAmount = 0;
                                TaxValue = 0;
                                TaxtTotal = 0;
                                UnTaxTotal = 0;
                                GrandTotal = 0;
                                net_value = 0;
                                other_charges = 0;
                                #region Percentage
                                if (SingleTax.t_type == "Percentage" && SingleTax.amount > 0)
                                {
                                    if (SingleTax.price_include == true)
                                    {
                                        TaxValue = (SingleTax.amount) / 100 + 1;
                                        BasePrice = PUR_T005_A_OBJ.subtotal / TaxValue;
                                        BasicItemAmount = BasePrice;
                                        TaxAmount = PUR_T005_A_OBJ.subtotal - BasicItemAmount;
                                    }
                                    else if (SingleTax.price_include == false)
                                    {
                                        TaxValue = (SingleTax.amount) / 100;
                                        if (TaxListForBaseInclude.Length > 0)
                                        {
                                            PreviousTaxValueForBasePrice = TotalDocumentTaxes.Where(tax => tax.sequence < SingleTax.sequence && tax.item_line_id == PUR_T005_A_OBJ.line_id && tax.manual == "Auto" && tax.ItemCode == PUR_T005_A_OBJ.ItemCode && (tax.sku?.ToString() ?? "") == (PUR_T005_A_OBJ.sku?.ToString() ?? "") && tax.item_row_id == PUR_T005_A_OBJ.id && tax.tax_code_id.In(TaxListForBaseInclude)).Sum(tax => tax.tax_amount); // Get Base amount for Calculation.
                                        }
                                        if (SingleTax.parent_id != null) // Collect Base price for This single child Tax.
                                        {
                                            BasePrice = TotalDocumentTaxes.Where(tax => tax.tax_code_id == SingleTax.parent_id && tax.item_line_id == PUR_T005_A_OBJ.line_id && tax.manual == "Auto" && tax.ItemCode == PUR_T005_A_OBJ.ItemCode && (tax.sku?.ToString() ?? "") == (PUR_T005_A_OBJ.sku?.ToString() ?? "") && tax.item_row_id == PUR_T005_A_OBJ.id).Single().tax_amount;
                                        }
                                        else // Collect Base Price for this parent Tax.
                                        {
                                            BasePrice = PUR_T005_A_OBJ.subtotal + PreviousTaxValueForBasePrice;
                                        }
                                        BasicItemAmount = PUR_T005_A_OBJ.subtotal;
                                        TaxAmount = BasePrice * TaxValue;
                                    }
                                }
                                #endregion
                                #region Fixed Amount
                                else if (SingleTax.t_type == "Fixed Amount" && SingleTax.amount > 0)
                                {
                                    TaxValue = SingleTax.amount;
                                    if (SingleTax.price_include == true)
                                    {
                                        BasePrice = PUR_T005_A_OBJ.subtotal - TaxValue;
                                        BasicItemAmount = BasePrice;
                                        TaxAmount = PUR_T005_A_OBJ.subtotal - BasicItemAmount;
                                    }
                                    else if (SingleTax.price_include == false)
                                    {
                                        BasePrice = PUR_T005_A_OBJ.subtotal;
                                        BasicItemAmount = BasePrice;
                                        TaxAmount = TaxValue;
                                    }
                                }
                                #endregion
                                #region Insert/Update Tax
                                int TaxIndex = 0;
                                var TaxVar = TotalDocumentTaxes.FirstOrDefault(T => T.tax_code_id == SingleTax.id && T.ItemCode == PUR_T005_A_OBJ.ItemCode && (T.sku?.ToString() ?? "") == (PUR_T005_A_OBJ.sku?.ToString() ?? "") && (T.item_line_id ?? 0) == PUR_T005_A_OBJ.line_id && T.item_row_id == PUR_T005_A_OBJ.id && T.manual == "Auto");
                                TaxIndex = TotalDocumentTaxes.IndexOf(TaxVar);
                                if (TaxVar != null && TaxIndex >= 0)
                                {
                                    TotalDocumentTaxes[TaxIndex].manual = "Auto";
                                    TotalDocumentTaxes[TaxIndex].active = true;
                                    TotalDocumentTaxes[TaxIndex].tax_amount = TaxAmount;
                                    TotalDocumentTaxes[TaxIndex].account_id = 0;
                                    TotalDocumentTaxes[TaxIndex].sequence = SingleTax.sequence;
                                    TotalDocumentTaxes[TaxIndex].doc_no = MasterEntity.doc_no;
                                    TotalDocumentTaxes[TaxIndex].base_amount = BasePrice;
                                    TotalDocumentTaxes[TaxIndex].amount = SingleTax.amount;
                                    TotalDocumentTaxes[TaxIndex].tax_code_id = SingleTax.id;
                                    TotalDocumentTaxes[TaxIndex].account_analytic_id = 0;
                                    TotalDocumentTaxes[TaxIndex].base_code_id = SingleTax.id;
                                    TotalDocumentTaxes[TaxIndex].tax_name = SingleTax.description;
                                    TotalDocumentTaxes[TaxIndex].ItemCode = PUR_T005_A_OBJ.ItemCode;
                                    TotalDocumentTaxes[TaxIndex].sku = PUR_T005_A_OBJ.sku;
                                    TotalDocumentTaxes[TaxIndex].item_row_id = PUR_T005_A_OBJ.id;
                                    TotalDocumentTaxes[TaxIndex].item_line_id = PUR_T005_A_OBJ.line_id;
                                    //TotalDocumentTaxes[TaxIndex].fin_year = SingleTax.FinYear;
                                    TotalDocumentTaxes[TaxIndex].location_Id = MasterEntity.location_Id;
                                    TotalDocumentTaxes[TaxIndex].comp_code = MasterEntity.comp_code;
                                    TotalDocumentTaxes[TaxIndex].posting_period = MasterEntity.posting_period;
                                    TotalDocumentTaxes[TaxIndex].trns_key_code = "PTX";
                                    TotalDocumentTaxes[TaxIndex].con_value = TaxAmount;
                                    TotalDocumentTaxes[TaxIndex].tax_code = SingleTax.tax_code;
                                    TotalDocumentTaxes[TaxIndex].PartyId = MasterEntity.PartyId;
                                    TotalDocumentTaxes[TaxIndex].exch_rate = MasterEntity.exch_rate;
                                    TotalDocumentTaxes[TaxIndex].client = AppSessionState.client;
                                    TotalDocumentTaxes[TaxIndex].symbol = MasterEntity.symbol;
                                    TotalDocumentTaxes[TaxIndex].local_curr = AppSessionState.CntryCurncy;
                                }
                                else
                                {
                                    TotalDocumentTaxes.Add(new ACC_T006_C()
                                    {
                                        id = 0,
                                        tax_amount = TaxAmount,
                                        account_id = 0,
                                        sequence = SingleTax.sequence,
                                        doc_no = MasterEntity.doc_no,
                                        manual = "Auto",
                                        base_amount = BasePrice,
                                        amount = SingleTax.amount,
                                        tax_code_id = SingleTax.id,
                                        account_analytic_id = 0,
                                        base_code_id = SingleTax.id,
                                        tax_name = SingleTax.description,
                                        ItemCode = PUR_T005_A_OBJ.ItemCode,
                                        sku = PUR_T005_A_OBJ.sku,
                                        item_row_id = PUR_T005_A_OBJ.id,
                                        item_line_id = PUR_T005_A_OBJ.line_id,
                                        //fin_year = AppSessionState.FinYear,
                                        active = true,
                                        posting_period = MasterEntity.posting_period,
                                        location_Id = AppSessionState.OBJ_LOCATION.location_id,
                                        comp_code = AppSessionState.OBJ_COMPANY.comp_code,
                                        trns_key_code = "PTX",

                                        con_value = TaxAmount,
                                        tax_code = SingleTax.tax_code,
                                        PartyId = MasterEntity.PartyId,
                                        exch_rate = MasterEntity.exch_rate,
                                        client = AppSessionState.client,
                                        symbol = MasterEntity.symbol,
                                        local_curr = AppSessionState.CntryCurncy
                                    });
                                }
                                #endregion
                            }
                        }
                        #endregion
                        #region Remove Excluded Taxes.
                        string[] TaxArray2 = PUR_T005_A_OBJ.tax_id.Trim().Split(',');
                        List<ACC_T006_C> copy = new List<ACC_T006_C>();
                        copy = TotalDocumentTaxes.ToList();
                        foreach (var tax in copy)
                        {
                            bool DeleteFlag = true;
                            foreach (string SingleTax in TaxArray2)
                            {
                                if ((tax.tax_code_id.ToString() == SingleTax && tax.ItemCode == PUR_T005_A_OBJ.ItemCode && (tax.sku?.ToString() ?? "") == (PUR_T005_A_OBJ.sku?.ToString() ?? "") && tax.item_line_id == PUR_T005_A_OBJ.line_id && tax.item_row_id == PUR_T005_A_OBJ.id && tax.manual == "Auto") || tax.manual == "Manual")
                                {
                                    DeleteFlag = false;
                                    break;
                                }
                            }
                            if (!DeleteFlag) continue;
                            var ChildTaxVar = MC.TAX_LIST.FirstOrDefault(T => T.id == tax.tax_code_id);
                            if (ChildTaxVar.parent_id != null)
                            {
                                bool CheckChildParentFlag = true;
                                foreach (string SingleTax in TaxArray2)
                                {
                                    if (ChildTaxVar.parent_id.ToString() == SingleTax && tax.ItemCode == PUR_T005_A_OBJ.ItemCode && (tax.sku?.ToString() ?? "") == (PUR_T005_A_OBJ.sku?.ToString() ?? "") && tax.item_line_id == PUR_T005_A_OBJ.line_id && tax.item_row_id == PUR_T005_A_OBJ.id && tax.manual == "Auto")
                                    {
                                        CheckChildParentFlag = false;
                                        break;
                                    }
                                }
                                if (!CheckChildParentFlag) continue;
                                //var ParentTaxVar = TotalDocumentTaxes.FirstOrDefault(T => T.tax_code_id == ChildTaxVar.parent_id && T.ItemCode == PUR_T005_A_OBJ.ItemCode && (T.sku?.ToString() ?? "") == (PUR_T005_A_OBJ.sku?.ToString() ?? "") && T.line_id == PUR_T005_A_OBJ.line_id && T.item_line_id == PUR_T005_A_OBJ.id && T.manual == "Auto");
                                //if (ParentTaxVar == null)

                                if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == PUR_T005_A_OBJ.ItemCode && (tax.sku?.ToString() ?? "") == (PUR_T005_A_OBJ.sku?.ToString() ?? "") && tax.item_line_id == PUR_T005_A_OBJ.line_id && tax.item_row_id == PUR_T005_A_OBJ.id && tax.manual == "Auto")
                                {
                                    TotalDocumentTaxes.Remove(tax);
                                }
                            }
                            else if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == PUR_T005_A_OBJ.ItemCode && (tax.sku?.ToString() ?? "") == (PUR_T005_A_OBJ.sku?.ToString() ?? "") && tax.item_line_id == PUR_T005_A_OBJ.line_id && tax.item_row_id == PUR_T005_A_OBJ.id && tax.manual == "Auto")
                            {
                                TotalDocumentTaxes.Remove(tax);
                            }
                        }

                        #endregion

                    }
                    else //if (PUR_T005_A_OBJ.tax_id != null && PUR_T005_A_OBJ.active == false) // Remove previously assign Taxes from TotalDocumentTaxes if removed from Item.//Condition satisfy only if Selected Item not null and Active status is false.
                    {
                        List<ACC_T006_C> copy = new List<ACC_T006_C>();
                        copy = TotalDocumentTaxes.ToList();
                        foreach (var tax in copy)
                        {
                            if (tax.ItemCode == PUR_T005_A_OBJ.ItemCode && (tax.sku?.ToString() ?? "") == (PUR_T005_A_OBJ.sku?.ToString() ?? "") && tax.item_line_id == PUR_T005_A_OBJ.line_id && tax.item_row_id == PUR_T005_A_OBJ.id && tax.manual == "Auto")
                            {
                                if (tax.id == 0)
                                {
                                    TotalDocumentTaxes.Remove(tax);
                                }
                                else
                                {
                                    int Index = TotalDocumentTaxes.IndexOf(TotalDocumentTaxes.Where(X => X.ItemCode == PUR_T005_A_OBJ.ItemCode && (X.sku?.ToString() ?? "") == (PUR_T005_A_OBJ.sku?.ToString() ?? "") && X.item_line_id == PUR_T005_A_OBJ.line_id && X.item_row_id == PUR_T005_A_OBJ.id && X.manual == "Auto" && X.active == true).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                                    if (Index >= 0)
                                    {
                                        TotalDocumentTaxes.ElementAt(Index).active = false;
                                    }
                                }
                            }
                        }
                    }
                    #region Final Computation

                    if (PUR_T005_A_OBJ != null) // calculate items total Tax and get Net & Effective value of the item.
                    {
                        decimal? taxTotal = TotalDocumentTaxes.Where(x => x.item_row_id == PUR_T005_A_OBJ.id && x.item_line_id == PUR_T005_A_OBJ.line_id).Sum(x => x.con_value);
                        PUR_T005_A_OBJ.net_value = ((PUR_T005_A_OBJ.gross_value + Math.Round((taxTotal ?? 0), RoundUpDecimals)) - (PUR_T005_A_OBJ.discount_amt ?? 0));
                        PUR_T005_A_OBJ.effective_value = PUR_T005_A_OBJ.net_value;
                        PUR_T005_A_OBJ.tax_amount = taxTotal;
                    }

                    //TaxtTotal = TotalDocumentTaxes.Sum(x => x.tax_amount);
                    TaxtTotal = TotalDocumentTaxes.Where(item => item.active != false && item.manual == "Auto").Sum(item => item.tax_amount);
                    MasterEntity.tax_amount = TaxtTotal;
                 
                    //UnTaxTotal = ItemsEntity.Sum(x => x.sub_total);
                    UnTaxTotal = ItemsEntity.Where(item => item.active != false).Sum(item => item.subtotal);
                    MasterEntity.acc_amount = UnTaxTotal;

                    net_value = UnTaxTotal + TaxtTotal;
                    MasterEntity.net_value = net_value;
                    other_charges = TotalDocumentTaxes.Where(item => item.active != false && item.manual == "Manual").Sum(item => item.tax_amount);
                    MasterEntity.other_charges = other_charges;

                    GrandTotal = net_value + other_charges;
                    GrandTotal = decimal.Round((decimal)GrandTotal, 2);
                    MasterEntity.total = GrandTotal;

                    if (AutoRoundUpFlag == true)
                    {
                        MasterEntity.roundup_total = decimal.Round((decimal)GrandTotal);
                        MasterEntity.round_up = MasterEntity.roundup_total - GrandTotal;
                    }
                    else
                    {
                        MasterEntity.round_up = 0;
                        MasterEntity.roundup_total = GrandTotal + MasterEntity.round_up;
                    }
 
                    MasterEntity.gross_value = ItemsEntity.Where(item => item.active != false).Sum(item => item.qty * item.unit_price);

                    MasterEntity.effective_value = GrandTotal;
                    MasterEntity.disc_amt = MasterEntity.gross_value - UnTaxTotal;

                    if (MasterEntity.roundup_total > 0 && !string.IsNullOrWhiteSpace(MasterEntity.curr_code))
                    {
                        ADM_M037 curr_obj = new ADM_M037();
                        curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                        if (curr_obj.word_format == "F01" || string.IsNullOrWhiteSpace(curr_obj.word_format))
                        {
                            MasterEntity.amt_word = NUMBER_TO_WORDS_CONVERTER.AmountInWordsF01(MasterEntity.roundup_total.ToString(), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word, curr_obj.word_format, curr_obj.word_prefix, curr_obj.word_suffix);
                        }
                        else
                        {
                            MasterEntity.amt_word = NOW_OBJ.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word, curr_obj.word_format);
                        }
                    }
                    else
                    { MasterEntity.amt_word = ""; }
                    #endregion
                    #endregion
                }
            }
        }
        private void CollectionChangedNotifyForTotalTaxes(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add && ItemsEntity.Count > 0) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (ACC_T006_C item in e.NewItems)
                    {
                        if (item.tax_code_id > 0)
                        { item.manual = "Auto"; item.con_type = "TAXC"; }
                        else { item.manual = "Manual"; item.sequence = 100; }
                        if (item.tax_name == null || item.tax_name.Trim() == "")
                        { item.tax_name = "CASH"; }
                        item.active = true;
                        item.symbol = MasterEntity.symbol;
                        item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.exch_rate = MasterEntity.exch_rate;
                        item.local_curr = AppSessionState.CntryCurncy;
                        item.curr_code = MasterEntity.curr_code;
                        item.client = AppSessionState.client;
                        item.exch_rate = MasterEntity.exch_rate;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                { }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                { }
                if (e.Action == NotifyCollectionChangedAction.Move)
                { }
                int c = TotalDocumentTaxes.Count();
            }
            catch (Exception ex)
            {
            }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                { }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                { }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    PUR_T005_A temp = (PUR_T005_A)e.OldItems[0];
                    if (TotalDocumentTaxes.Count > 0) // Remove Taxes deleted item.
                    {
                        List<ACC_T006_C> copy = new List<ACC_T006_C>();
                        copy = TotalDocumentTaxes.ToList();
                        foreach (var tax in copy)
                        {
                            if (tax.ItemCode == temp.ItemCode && (tax.sku?.ToString() ?? "") == (temp.sku?.ToString() ?? "") && tax.item_row_id == temp.id)
                            {
                                TotalDocumentTaxes.Remove(tax);
                                Computation(true, 0, AutoRoundupEnable);
                            }
                        }
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Move)
                { }
            }
            catch (Exception ex)
            { }
        }
        #endregion
    }
}
