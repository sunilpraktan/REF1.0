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
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using Reflection.BusinessEntity.Finance;
using System.Windows.Controls;
using Reflection.Presentation.Controls;
using System.Windows;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Services.Convertors;
using GalaSoft.MvvmLight.Messaging;
using System.Reflection;
using Reflection.Presentation.Core.VirtualDesktops;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_T008_VM : WorkspaceViewModel<ACC_T001>
    {
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_T008_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
        private AutoSuggestTextViewModel<dynamic> _ASDocTypes { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocTypes
        {
            get { return _ASDocTypes; }
            set
            {
                if (_ASDocTypes != value)
                {
                    _ASDocTypes = value; RaisePropertyChanged("ASDocTypes");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASCompany { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCompany
        {
            get { return _ASCompany; }
            set
            {
                if (_ASCompany != value)
                {
                    _ASCompany = value; RaisePropertyChanged("ASCompany");
                }
            }
        }
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
        private AutoSuggestTextViewModel<dynamic> _ASPartyLedger { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPartyLedger
        {
            get { return _ASPartyLedger; }
            set
            {
                if (_ASPartyLedger != value)
                {
                    _ASPartyLedger = value; RaisePropertyChanged("ASPartyLedger");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASGeneralLedger { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGeneralLedger
        {
            get { return _ASGeneralLedger; }
            set
            {
                if (_ASGeneralLedger != value)
                {
                    _ASGeneralLedger = value; RaisePropertyChanged("ASGeneralLedger");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASSpecialGLCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSpecialGLCode
        {
            get { return _ASSpecialGLCode; }
            set
            {
                if (_ASSpecialGLCode != value)
                {
                    _ASSpecialGLCode = value; RaisePropertyChanged("ASSpecialGLCode");
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
        private AutoSuggestTextViewModel<dynamic> _ASOrderDocument { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASOrderDocument
        {
            get { return _ASOrderDocument; }
            set
            {
                if (_ASOrderDocument != value)
                {
                    _ASOrderDocument = value; RaisePropertyChanged("ASOrderDocument");
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
                    //if (SourceName == "ItemCode")
                    //{ ASDefault = ASItems; }
                }
            }
        }
        #endregion
        #region Variable Declaration
        private bool _isNewRecord;
        public bool isNewRecord
        {
            get
            {
                return _isNewRecord;
            }
            set
            {
                if (_isNewRecord != value)
                {
                    _isNewRecord = value;
                    RaisePropertyChanged("isNewRecord");
                }
            }
        }
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
        NumberToEnglish num = new NumberToEnglish();
        WebServiceRepository<ACC_T001> repository = new WebServiceRepository<ACC_T001>();
        WebServiceRepository<MultipleContext_ACC_T001> repository_MC = new WebServiceRepository<MultipleContext_ACC_T001>();
        WebServiceRepository<MultipleContext_ACC_T001> repository_MCTemp = new WebServiceRepository<MultipleContext_ACC_T001>();
        WebServiceRepository<MultipleContext_ACC_T001> repository_MCTemp2 = new WebServiceRepository<MultipleContext_ACC_T001>();
        WebServiceRepository<MultipleContext_ACC_T001> repository_MCTemp3 = new WebServiceRepository<MultipleContext_ACC_T001>();
        ObjectSerializationService obj = new ObjectSerializationService();
        private MultipleContext_ACC_T001 _MC = new MultipleContext_ACC_T001();
        public MultipleContext_ACC_T001 MC
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
        private MultipleContext_ACC_T001 _MCTemp = new MultipleContext_ACC_T001();
        public MultipleContext_ACC_T001 MCTemp
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
        private ACC_T001 _MasterEntity;
        public ACC_T001 MasterEntity
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

        private ObservableCollection<ACC_T001_A> _OpenItemList;
        public ObservableCollection<ACC_T001_A> OpenItemList
        {
            get
            {
                return _OpenItemList;
            }
            set
            {
                if (_OpenItemList != value)
                {
                    _OpenItemList = value;
                    RaisePropertyChanged("OpenItemList");
                }
            }
        }
        private ObservableCollection<ACC_T001_B> _OpenItemListAdvance;
        public ObservableCollection<ACC_T001_B> OpenItemListAdvance
        {
            get
            {
                return _OpenItemListAdvance;
            }
            set
            {
                if (_OpenItemListAdvance != value)
                {
                    _OpenItemListAdvance = value;
                    RaisePropertyChanged("OpenItemListAdvance");
                }
            }
        }
        private ACC_T001_B _SelectedOpenItem;
        public ACC_T001_B SelectedOpenItem
        {
            get
            {
                return _SelectedOpenItem;
            }
            set
            {
                if (_SelectedOpenItem != value)
                {
                    _SelectedOpenItem = value;
                    RaisePropertyChanged("SelectedOpenItem");
                }
            }
        }
        private ACC_T001_A _SelectedClearedItem;
        public ACC_T001_A SelectedClearedItem
        {
            get
            {
                return _SelectedClearedItem;
            }
            set
            {
                if (_SelectedClearedItem != value)
                {
                    _SelectedClearedItem = value;
                    RaisePropertyChanged("SelectedClearedItem");
                }
            }
        }
        private int _dgSelectedIndexPayment;
        public int dgSelectedIndexPayment
        {
            get
            {
                return _dgSelectedIndexPayment;
            }
            set
            {
                if (_dgSelectedIndexPayment != value)
                {
                    _dgSelectedIndexPayment = value;
                    RaisePropertyChanged("dgSelectedIndexPayment");

                }
            }
        }
        public int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get
            {
                return _SelectedTabControlIndex;
            }
            set
            {
                _SelectedTabControlIndex = value;
                RaisePropertyChanged("SelectedTabControlIndex");
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
        }
        private ICollectionView _OpenItemCollection;
        public ICollectionView OpenItemCollection
        {
            get { return _OpenItemCollection; }
            set { _OpenItemCollection = value; RaisePropertyChanged("OpenItemCollection"); }
        }
        private ObservableCollection<ACC_T001_C> _AllocationList;
        public ObservableCollection<ACC_T001_C> AllocationList
        {
            get
            {
                return _AllocationList;
            }
            set
            {
                if (_AllocationList != value)
                {
                    _AllocationList = value;
                    RaisePropertyChanged("AllocationList");
                }
            }
        }
        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
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
        #endregion
        #region Relay Commands Declaration
        public RelayCommand<object> cmdPartyLedger { get; private set; }
        public RelayCommand<object> cmdDocumentType { get; private set; }
        //public RelayCommand<object> cmdCompany { get; private set; }
        public RelayCommand<object> cmdCurrency { get; private set; }
        public RelayCommand<object> cmdCompanyLedger { get; private set; }
        public RelayCommand<object> cmdSpecialGLCode { get; private set; }
        public RelayCommand<object> cmdPayMethod { get; private set; }
        public RelayCommand<object> cmdProfitCenter { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdLoadBackFlipData { get; private set; }
        public RelayCommand<object> cmdStatus { get; private set; }
        public RelayCommand<object> cmdSelectOpenItem { get; private set; }
        public RelayCommand<object> cmdDGCellDoubleClick { get; private set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor for ViewModel
        /// </summary>
        /// <param name="NA"></param>
        public FICO_T008_VM(string doc_cat, string ts_code) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            MasterEntity = new ACC_T001();
            OpenItemList = new ObservableCollection<ACC_T001_A>();
            OpenItemListAdvance = new ObservableCollection<ACC_T001_B>();
            AllocationList = new ObservableCollection<ACC_T001_C>();
            SelectedOpenItem = new ACC_T001_B();
            SelectedClearedItem = new ACC_T001_A();
            MC = new MultipleContext_ACC_T001();
            MCTemp = new MultipleContext_ACC_T001();
            MasterEntity.ValidateAsync().Wait();
            ACC_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            ACC_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            RequestPara = new RequestParameters();
            LoadInitialData();
        }
        public FICO_T008_VM(string doc_cat, string ts_code, string doc_no) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new ACC_T001();
            OpenItemList = new ObservableCollection<ACC_T001_A>();
            OpenItemListAdvance = new ObservableCollection<ACC_T001_B>();
            AllocationList = new ObservableCollection<ACC_T001_C>();
            SelectedOpenItem = new ACC_T001_B();
            SelectedClearedItem = new ACC_T001_A();
            MC = new MultipleContext_ACC_T001();
            MCTemp = new MultipleContext_ACC_T001();
            MasterEntity.ValidateAsync().Wait();
            ACC_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            RequestPara = new RequestParameters();
            LoadInitialData();
        }
        #endregion
        #region Relay Command Actions ·
        private void InsertCurrency(object InputValue)
        {
            string Request = "";
            ADM_M037_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Currencys.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M037_P>().ToList()[0];
                }
                if (POPUPEntityObject != null) // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.curr_code = POPUPEntityObject.curr_code;
                    //MasterEntity.CurrName = POPUPEntityObject.curr_name;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private void InsertCompanyLedger(object InputValue)
        {
            string Request = "";
            ACC_M003_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.GLCodes.Where(x => x.ledger_gen.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    //MasterEntity.hb_acc_no = POPUPEntityObject.acc_no;
                    MasterEntity.hb_acc = POPUPEntityObject.hb_acc;
                    MasterEntity.hb_code = POPUPEntityObject.hb_code;
                    MasterEntity.our_hb_name = POPUPEntityObject.bank_name;
                    MasterEntity.ledger_gen = POPUPEntityObject.ledger_gen;
                    MasterEntity.bank_gl_code = POPUPEntityObject.gl_code;
                    MasterEntity.bank_gl_name = POPUPEntityObject.gl_name;
                    MasterEntity.header_text = POPUPEntityObject.gl_name;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private void InsertSpecialGLCode(object InputValue)
        {
            string Request = "";
            ACC_M028_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.SpecialGLCodes.Where(x => x.ind_spl_gl.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M028_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)  // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.ind_spl_gl = POPUPEntityObject.ind_spl_gl;
                    //MasterEntity.short_name = POPUPEntityObject.short_name;
                }
                if (isNewRecord == true && !string.IsNullOrWhiteSpace((MasterEntity.ind_spl_gl ?? "").Trim()))
                {
                    foreach (ACC_T001_A item in OpenItemList)
                    {
                        item.Select = false;
                    }
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(MasterEntity.ind_spl_gl, "Enable Open Documnets"));
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        //private void InsertCompany(object InputValue)
        //{
        //    string Request = "";
        //    ADM_M002 POPUPEntityObject = null;
        //    try
        //    {
        //        if (InputValue.GetType() == typeof(string) && InputValue != null)
        //        {
        //            Request = InputValue.ToString();
        //            if (Request.Length > 0)
        //            {
        //                try
        //                { POPUPEntityObject = ((List<ADM_M002>)AppSessionState.ADM_M002_List).ToList().Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                catch (Exception ex) { }
        //            }
        //        }
        //        else if (InputValue != null)
        //        {
        //            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002>().ToList()[0];
        //        }
        //        if (POPUPEntityObject != null) // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
        //        {
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;
        //            MasterEntity.compName = POPUPEntityObject.CompName;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
        //    }
        //}
        private void ClearOpenItems(object InputValue)
        {
            try
            {
                if (SelectedOpenItem != null && SelectedClearedItem != null)
                {
                    if (SelectedClearedItem.net_payable_amt > 0 && SelectedOpenItem.bal_amt.HasValue && SelectedOpenItem.net_payable_amt.HasValue && SelectedOpenItem.net_payable_amt > 0 && SelectedClearedItem.bal_amt > 0)
                    {
                        if (SelectedOpenItem.net_payable_amt <= SelectedClearedItem.net_payable_amt)
                        {
                            SelectedClearedItem.net_pay_amt = SelectedOpenItem.net_payable_amt;
                        }
                        else
                        {
                            SelectedClearedItem.net_pay_amt = SelectedClearedItem.net_payable_amt;
                        }
                        //SelectedClearedItem.sp_gltype = SelectedOpenItem.sp_gltype;
                        SelectedClearedItem.ref_doc_no = SelectedOpenItem.doc_no;
                        SelectedClearedItem.open_item_row_id = SelectedOpenItem.open_item_row_id;
                        //SelectedOpenItem.net_payable_amt = SelectedOpenItem.net_payable_amt - SelectedClearedItem.net_payable_amt;
                        SelectedClearedItem.Select = true;
                        MasterEntity.amount = SelectedClearedItem.net_pay_amt;

                        if (isNewRecord == true)
                        {
                            foreach (var item in MC.PAYMENT_ALLOCATION)
                            {
                                if (item.bill_doc == OpenItemList[dgSelectedIndexPayment].bill_doc)
                                {
                                    AllocationList.Add(item);
                                }
                            }
                            if (AllocationList != null)
                            {
                                if (AllocationList.Where(x => x.bill_doc == OpenItemList[dgSelectedIndexPayment].bill_doc).ToList().Count == 1)
                                {
                                    AllocationList.Where(x => x.bill_doc == OpenItemList[dgSelectedIndexPayment].bill_doc).ToList()[0].amount = (decimal)OpenItemList[dgSelectedIndexPayment].net_pay_amt;
                                }
                            }
                        }
                    }
                }
                else
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Select Open Document first to proceed clearing Pending Items", this.Title); sms.ShowMessage();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void Invoke_Reference_Document(object InputValue)
        {
            try
            {
                ReflectionFunctionService objRef = new ReflectionFunctionService();
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    string Request = MasterEntity.client + "!@" + MasterEntity.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
            }
            catch (Exception ex) { }
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
                else
                {
                    MasterEntity = new ACC_T001();
                    OpenItemList = new ObservableCollection<ACC_T001_A>();
                    OpenItemListAdvance = new ObservableCollection<ACC_T001_B>();
                    MasterEntity.ValidateAsync().Wait();
                    ACC_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
                    RequestPara = new RequestParameters();
                    isNewRecord = true;
                    DefaultValues();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertPartyLedger(object InputValue)
        {
            ADM_M028_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    string Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                }
                if (POPUPEntityObject != null && MasterEntity.PartyId != POPUPEntityObject.PartyId) //&& MasterEntity.PartyId != POPUPEntityObject.PartyId) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.PartyId = POPUPEntityObject.PartyId;
                    MasterEntity.PartyNm = POPUPEntityObject.PartyNm;
                    MasterEntity.curr_code = POPUPEntityObject.curr_code ?? AppSessionState.CntryCurncy;
                    //MasterEntity.party_acc_no = POPUPEntityObject.acc_number;
                    //MasterEntity.party_bank_code = POPUPEntityObject.bank_code;
                    MasterEntity.party_bank_name = POPUPEntityObject.bank_name;
                    MasterEntity.swift_code = POPUPEntityObject.swift_code;
                    MasterEntity.ifsc_code = POPUPEntityObject.ifsccode;
                    MasterEntity.header_text = POPUPEntityObject.gl_name;
                    MasterEntity.curr_code = POPUPEntityObject.curr_code;
                    MasterEntity.bank_party = POPUPEntityObject.bank_code;
                    MasterEntity.bank_acc_no = POPUPEntityObject.acc_number;

                    string Request = "LoadOpenDocumentsOnPartySelection" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id.ToString() + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.PartyId + "!@" + Convert.ToDateTime(MasterEntity.doc_date).ToString("MM/dd/yyyy");
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_T001>(MCTemp, Request, "ACC_T001_BL", "FICO", "LoadAll", 0, "ACC_T001_BL");
                    if (MCTemp.OpenItems.Count > 0)
                    {
                        OpenItemList = MCTemp.DetailEntity;
                        OpenItemListAdvance = MCTemp.OpenItems;
                        MC.PAYMENT_ALLOCATION = MCTemp.PAYMENT_ALLOCATION;
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P)x).sono);
                        TheFilter = (o, prefix) => (((SEL_T001_P)o).sono ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASOrderDocument = new AutoSuggestTextViewModel<dynamic>(MCTemp.SalesOrderList, TheFilter, SuggestedValue, "sono", true);
                        ASOrderDocument.AutoSuggestVM.IsEmptyValueAllowed = true;
                        MC.SalesOrderList = MCTemp.SalesOrderList;
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format("Open Advance Document not exists for the Party.", this.Title); showMessageService.ShowMessage();

                    }
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private void InsertDocumentType(object InputValue)
        {
            try
            {
                SYS_M015 POPUPEntityObject = null;
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        string Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.DocumentTypes.Where(x => x.doc_type_user.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M015>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                if (POPUPEntityObject != null) // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.doc_cat = POPUPEntityObject.doc_cat;
                    MasterEntity.doc_type = POPUPEntityObject.doc_type;
                    //MasterEntity.doc_type_user = POPUPEntityObject.doc_type_user;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private void InsertPayMethod(object InputValue)
        {
            ACC_M027_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    string Request = InputValue.ToString();
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
                if (POPUPEntityObject != null) //&& MasterEntity.PartyId != POPUPEntityObject.PartyId) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.pay_method = POPUPEntityObject.pay_method;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private void InsertProfitCenter(object InputValue)
        {
            ACC_M020_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    string Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ProfitCenterList.Where(x => x.profit_center.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.profit_center_Desc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M020_P>().ToList()[0];
                }
                if (POPUPEntityObject != null) //&& MasterEntity.PartyId != POPUPEntityObject.PartyId) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.profit_center = POPUPEntityObject.profit_center;
                    MasterEntity.profit_center_Desc = POPUPEntityObject.profit_center_Desc;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private void SelectOpenItem(object InputValue)
        {
            ACC_T001_A POPUPEntityObject = null;
            try
            {
                if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_T001_A>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    if (POPUPEntityObject.Select == true)
                    {
                        OpenItemList[dgSelectedIndexPayment].net_pay_amt = POPUPEntityObject.net_payable_amt;
                        //MasterEntity.amount = OpenItemList.Where(x => x.Select == true).Sum(x => x.net_pay_amt);

                        if (isNewRecord == true)
                        {
                            foreach (var item in MC.PAYMENT_ALLOCATION)
                            {
                                if (item.bill_doc == OpenItemList[dgSelectedIndexPayment].bill_doc)
                                {
                                    AllocationList.Add(item);
                                }
                            }
                            if (AllocationList != null)
                            {
                                if (AllocationList.Where(x => x.bill_doc == OpenItemList[dgSelectedIndexPayment].bill_doc).ToList().Count == 1)
                                {
                                    AllocationList.Where(x => x.bill_doc == OpenItemList[dgSelectedIndexPayment].bill_doc).ToList()[0].amount = (decimal)OpenItemList[dgSelectedIndexPayment].net_pay_amt;
                                }
                            }
                        }
                    }
                    if (POPUPEntityObject.Select == false)
                    {
                        MasterEntity.amount = OpenItemList.Where(x => x.Select == true).Sum(x => x.net_pay_amt);
                        if (isNewRecord == true && AllocationList != null)
                        {
                            if (AllocationList.Count > 0)
                            {
                                List<ACC_T001_C> RequestList = new List<ACC_T001_C>();
                                RequestList = AllocationList.ToList();
                                foreach (ACC_T001_C item in RequestList)
                                {
                                    if (item.bill_doc == OpenItemList[dgSelectedIndexPayment].bill_doc)
                                    {
                                        AllocationList.Remove(item);
                                    }
                                }
                            }
                        }
                        SelectedClearedItem = null;
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private void Insert_Status(object InputValue)
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
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            string ParametersStringValue = "";
            ACC_T001_Flip ParameterEntityObject = new ACC_T001_Flip();
            try
            {
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null)
                {
                    ParameterEntityObject.doc_no = ParameterObject.ToString();
                }
                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<ACC_T001_Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ACC_T001_Flip>().ToList()[0];
                    }
                }
                if (ParameterEntityObject != null)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ACC_T001_Flip>().ToList()[0];
                    Request = "LoadDocumentWithDocumentNumber" + "!@" + AppSessionState.client + "!@" + ParameterEntityObject.comp_code + "!@" + ParameterEntityObject.doc_no + "!@" + doc_cat_vm;
                    MasterEntity = new ACC_T001();
                    MasterEntity = repository.GetDataWithReturnDomainObject<ACC_T001>(MasterEntity, Request, "ACC_T001_BL", "FICO", "LoadDocumentWithReferenceDocumentNumber", 0, "ACC_T001_BL");
                }
                SetBusinessEntitiesAfterLoad(ParametersStringValue, "");//this function is always call for reading your Detail entity
                SelectedTabControlIndex = 0;
                isNewRecord = false;
                MasterEntity.ts_code = ts_code_vm;
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(MasterEntity.sp_gl_code, "Enable Open Documnets"));
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        #endregion
        #region Abstract Command Actions
        private IEnumerable<T> MakeMeEnumerable<T>(T Entity)
        {
            yield return Entity;
        }
        protected override void OnSaveAction(InquiryActionResult<ACC_T001> result)
        {
            try
            {
                if (Validation() == true)
                {
                    List<ACC_T001_A> SelectedOpenItems = (from o in OpenItemList where o.Select == true select o).ToList();
                    MasterEntity.XmlDataDocument_ACC_T001_A = obj.ObjectToXML(SelectedOpenItems);
                    MasterEntity.XmlDataDocument_ACC_T001_C = obj.ObjectToXML(AllocationList);
                    Logging();
                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ACC_T001>(MasterEntity, "ACC_T001_BL", "FICO");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ACC_T001>(MasterEntity, "ACC_T001_BL", "FICO");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.doc_no != null || MasterEntity.doc_no != "" && MasterEntity.active == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format("Record saved Successfully ........"); showMessageService.ShowMessage();
                    }
                    isNewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                    MasterEntity.ts_code = ts_code_vm;
                }

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        protected override void OnCreateAction(InquiryActionResult<ACC_T001> result)
        {
            try
            {
                isNewRecord = true;
                MasterEntity = new ACC_T001();
                OpenItemList = new ObservableCollection<ACC_T001_A>();
                OpenItemListAdvance = new ObservableCollection<ACC_T001_B>();
                AllocationList = new ObservableCollection<ACC_T001_C>();
                SelectedOpenItem = new ACC_T001_B();
                SelectedClearedItem = new ACC_T001_A();
                MasterEntity.ValidateAsync().Wait();
                DefaultValues();
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_T001> result)
        { }
        protected override void OnDiscardAction(InquiryActionResult<ACC_T001> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_T001> result)
        { }
        protected override void OnFlipAction(InquiryActionResult<ACC_T001> result)
        {
            try
            {
                object objParam = MasterEntity.doc_no;
                string userAuth = "Reflection.Modules.Finance.Views.LedgerView"; // this one is path option
                string path1 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.Finance.dll");
                Assembly assembly = Assembly.LoadFile(path1);
                Type type = assembly.GetType(userAuth);
                if (type != null)
                {
                    dynamic instance = Activator.CreateInstance(type, objParam);
                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected override void OnHelpAction(InquiryActionResult<ACC_T001> result)
        { }
        protected override void OnPrintAction(InquiryActionResult<ACC_T001> result)
        {
            string Request = "Rpt_PaymentEntry" + "!@" + MasterEntity.doc_no + "!@" + MasterEntity.doc_type;
            try
            {
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextACC_T001_A>(MC, Request, "ACC_T001_BL", "FICO", "LoadAll", 0, "ACC_T001_BL");
                object[] objDataSource = new object[4];
                string[] objDataSourceName = new string[4];
                objDataSource[0] = MC.RptPaymentEntry;
                objDataSource[1] = MC.RptPaymentEntryItem;
                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[2] = CmpResult;
                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[3] = Result;
                objDataSourceName[0] = "dsRptPaymentEntry";
                objDataSourceName[1] = "dsRptPaymentEntryItem";
                objDataSourceName[2] = "dsCompany";
                objDataSourceName[3] = "dsLocation";
                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Finance\\PaymentEntry.rdlc", getParametersList(), "ACC_T001_BL");
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        protected override void OnDocumentAction()
        { }
        protected override void OnRefreshCommand(InquiryActionResult<ACC_T001> result)
        {
            LoadInitialData();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_T001> result)
        {
            throw new NotImplementedException();
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
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
            return result;
        }
        #endregion
        #region Event Handler
        private void ModelUpdated_Master(object sender, EventArgs e)//This will get called when the property of an object changes
        {
            if (sender.ToString() == "amount" || sender.ToString() == "bank_charges" || sender.ToString() == "exch_rate")
            {
                if (MasterEntity.amount.HasValue)
                {
                    MasterEntity.local_amount = MasterEntity.amount * MasterEntity.exch_rate;
                    MasterEntity.local_bank_charges = MasterEntity.bank_charges * MasterEntity.exch_rate;
                    MasterEntity.amt_word = num.AmountInWords(Convert.ToDecimal(MasterEntity.amount));
                }
            }
            this.ErrorExist = MasterEntity.HasErrors;
        }
        private void ModelUpdated_Item(object sender, EventArgs e)//This will get called when the property of an object changes
        {
            if ((sender.ToString() == "Select" || sender.ToString() == "cash_disc1" || sender.ToString() == "amt_withhold_tax" || sender.ToString() == "net_pay_amt") && dgSelectedIndexPayment >= 0)
            {
                if (SelectedOpenItem != null)
                {
                    if (OpenItemList[dgSelectedIndexPayment].amount_doc_curr.HasValue && OpenItemList[dgSelectedIndexPayment].Select == true && SelectedOpenItem.net_payable_amt > 0 && OpenItemList[dgSelectedIndexPayment].bal_amt > 0)
                    {

                        decimal Exch_Rate_Doc = OpenItemList[dgSelectedIndexPayment].doc_exch_rate;
                        decimal Exch_Rate_Current = MasterEntity.exch_rate;
                        decimal DocumentAmount = OpenItemList[dgSelectedIndexPayment].net_payable_amt;
                        decimal DocumentAmountLocal = DocumentAmount * Exch_Rate_Doc;
                        //decimal NetPayableAmount = OpenItemList[dgSelectedIndexPayment].net_payable_amt ?? 0;
                        //decimal NetPayableAmountLocal = NetPayableAmount * Exch_Rate_Doc;
                        decimal TotalWTaxAmt = OpenItemList[dgSelectedIndexPayment].amt_withhold_tax ?? 0;
                        //decimal TotalWTaxAmtLocal = TotalWTaxAmt * Exch_Rate_Doc;
                        decimal TotalCashDiscount = OpenItemList[dgSelectedIndexPayment].cash_disc1 ?? 0;
                        //decimal TotalCashDiscountLocal = TotalCashDiscount * Exch_Rate_Doc;
                        decimal NetPaidAmount = OpenItemList[dgSelectedIndexPayment].net_pay_amt ?? 0;
                        //decimal NetPaidAmountLocal = NetPaidAmount * Exch_Rate_Doc;
                        decimal TotatFluctuation_amt = (NetPaidAmount * Exch_Rate_Doc) - (NetPaidAmount * Exch_Rate_Current);

                        OpenItemList[dgSelectedIndexPayment].net_payable_amt = DocumentAmount - TotalCashDiscount - TotalWTaxAmt;
                        OpenItemList[dgSelectedIndexPayment].bal_amt = OpenItemList[dgSelectedIndexPayment].net_payable_amt - NetPaidAmount;
                        OpenItemList[dgSelectedIndexPayment].loss_real1 = TotatFluctuation_amt;
                        OpenItemList[dgSelectedIndexPayment].value_diff = TotatFluctuation_amt;
                        OpenItemList[dgSelectedIndexPayment].amount_loc_curr = DocumentAmount * Exch_Rate_Doc;
                        OpenItemList[dgSelectedIndexPayment].amount_ledger = NetPaidAmount;
                        OpenItemList[dgSelectedIndexPayment].amt_withhold_tax_loc = TotalWTaxAmt * Exch_Rate_Doc;
                        OpenItemList[dgSelectedIndexPayment].cd_loc_curr = TotalCashDiscount * Exch_Rate_Doc;
                        OpenItemList[dgSelectedIndexPayment].cd_doc_curr = TotalCashDiscount;
                        OpenItemList[dgSelectedIndexPayment].cur_exch_rate = Exch_Rate_Current;
                        OpenItemList[dgSelectedIndexPayment].ex_rate_diff = Exch_Rate_Current - Exch_Rate_Doc;

                        //OpenItemList[dgSelectedIndexPayment].sp_gltype = SelectedOpenItem.sp_gltype;
                        OpenItemList[dgSelectedIndexPayment].ref_doc_no = SelectedOpenItem.doc_no;
                        OpenItemList[dgSelectedIndexPayment].open_item_row_id = SelectedOpenItem.open_item_row_id;
                        SelectedOpenItem.net_payable_amt = SelectedOpenItem.net_payable_amt - SelectedClearedItem.net_pay_amt;
                        MasterEntity.amount = SelectedClearedItem.net_pay_amt;

                        if (AllocationList != null)
                        {
                            if (AllocationList.Where(x => x.bill_doc == OpenItemList[dgSelectedIndexPayment].bill_doc).ToList().Count == 1)
                            {
                                AllocationList.Where(x => x.bill_doc == OpenItemList[dgSelectedIndexPayment].bill_doc).ToList()[0].amount = (decimal)SelectedClearedItem.net_pay_amt;
                            }
                        }
                    }
                }
                else
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Select Open Document first to proceed clearing Pending Items", this.Title); sms.ShowMessage();
                }
            }
        }
        #endregion
        #region User Defined Functions
        private void DefaultValues()
        {
            try
            {
                MasterEntity.doc_cat = this.doc_cat_vm;
                MasterEntity.doc_type = this.doc_cat_vm;
                MasterEntity.doc_date = System.DateTime.Now;
                MasterEntity.posting_date = System.DateTime.Now;
                MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                MasterEntity.active = true;
                MasterEntity.exch_rate = 1;
                MasterEntity.EmpId = AppSessionState.EmpId;
                MasterEntity.EmpName = AppSessionState.EmpName;
                MasterEntity.t_status = (from o in MC.STATUS_LIST where o.t_sequence == 1 select o).ToList()[0].t_status;
                MasterEntity.t_display = (from o in MC.STATUS_LIST where o.t_sequence == 1 select o).ToList()[0].t_display;
                MasterEntity.curr_code = ((List<ADM_M002>)AppSessionState.ADM_M002_List).ToList()[0].curr_code; // NOTE: use select statement for where comp_code = selected company instade of AppSessionState.CntryCurncy;
                //MasterEntity.comp_curr_code = ((List<ADM_M002>)AppSessionState.ADM_M002_List).ToList()[0].curr_code; // NOTE: use select statement for where comp_code = selected company instade of AppSessionState.CntryCurncy;
                MasterEntity.local_currency = ((List<ADM_M002>)AppSessionState.ADM_M002_List).ToList()[0].curr_code; // NOTE: use select statement for where comp_code = selected company instade of AppSessionState.CntryCurncy;
                DateTime d = DateTime.UtcNow;
                d = d.AddMonths(-1);
                RequestPara.FromDate = d;
                RequestPara.ToDate = DateTime.UtcNow;
                RequestPara.active = true;
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
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
        private void LoadInitialData()
        {
            try
            {
                #region Command Initialisation //
                cmdPartyLedger = new RelayCommand<object>(items => { if (items == null) { return; } InsertPartyLedger(items); });
                cmdDocumentType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocumentType(items); });
                //cmdCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
                cmdCurrency = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrency(items); });
                cmdCompanyLedger = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompanyLedger(items); });
                cmdSpecialGLCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertSpecialGLCode(items); });
                cmdPayMethod = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayMethod(items); });
                cmdProfitCenter = new RelayCommand<object>(items => { if (items == null) { return; } InsertProfitCenter(items); });
                cmdSelectOpenItem = new RelayCommand<object>(items => { if (items == null) { return; } SelectOpenItem(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, null); });
                cmdLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items, null); });
                cmdStatus = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_Status(cmdPara); });
                cmdDGCellDoubleClick = new RelayCommand<object>(items => { if (items == null) { return; } ClearOpenItems(items); });
                #endregion
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id.ToString() + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_T001>(MC, Request, "ACC_T001_BL", "FICO", "LoadAll", 0, "ACC_T001_BL");
                #region Autosuggest Popups             
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPartyLedger = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyId", true);
                ASPartyLedger.AutoSuggestVM.IsEmptyValueAllowed = false; ASPartyLedger.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M015)x).doc_type_user);
                TheFilter = (o, prefix) => (((SYS_M015)o).doc_type_user ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M015)o).doc_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDocTypes = new AutoSuggestTextViewModel<dynamic>(MC.DocumentTypes, TheFilter, SuggestedValue, "doc_type", true);
                ASDocTypes.AutoSuggestVM.IsEmptyValueAllowed = false; ASDocTypes.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M002)o).CompName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCompany = new AutoSuggestTextViewModel<dynamic>((List<ADM_M002>)AppSessionState.ADM_M002_List, TheFilter, SuggestedValue, "comp_code", true);
                ASCompany.AutoSuggestVM.IsEmptyValueAllowed = false; ASCompany.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M037_P)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCurrency = new AutoSuggestTextViewModel<dynamic>(MC.Currencys, TheFilter, SuggestedValue, "curr_code", true);
                ASCurrency.AutoSuggestVM.IsEmptyValueAllowed = false; ASCurrency.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).ledger_gen);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).ledger_gen ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASGeneralLedger = new AutoSuggestTextViewModel<dynamic>(MC.GLCodes, TheFilter, SuggestedValue, "ledger_gen", true);
                ASGeneralLedger.AutoSuggestVM.IsEmptyValueAllowed = false; ASGeneralLedger.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M028_P)x).ind_spl_gl);
                TheFilter = (o, prefix) => (((ACC_M028_P)o).ind_spl_gl ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M028_P)o).short_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSpecialGLCode = new AutoSuggestTextViewModel<dynamic>(MC.SpecialGLCodes, TheFilter, SuggestedValue, "ind_spl_gl", true);
                ASSpecialGLCode.AutoSuggestVM.IsEmptyValueAllowed = true; ASSpecialGLCode.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M027_P)x).pay_method);
                TheFilter = (o, prefix) => (((ACC_M027_P)o).pay_method ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M027_P)o).pay_method_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPayMethod = new AutoSuggestTextViewModel<dynamic>(MC.PayMethodList, TheFilter, SuggestedValue, "pay_method", true);
                ASPayMethod.AutoSuggestVM.IsEmptyValueAllowed = true; ASPayMethod.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M020_P)x).profit_center_Desc);
                TheFilter = (o, prefix) => (((ACC_M020_P)o).profit_center ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M020_P)o).profit_center_Desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASProfitCenter = new AutoSuggestTextViewModel<dynamic>(MC.ProfitCenterList, TheFilter, SuggestedValue, "profit_center_Desc", true);
                ASProfitCenter.AutoSuggestVM.IsEmptyValueAllowed = true; ASProfitCenter.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASStatus = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                ASStatus.AutoSuggestVM.IsEmptyValueAllowed = true; ASStatus.AutoSuggestVM.IsFreeTextAllowed = true;

                #endregion
                DefaultValues();
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private void LoadBackFlipData(object doc_cat, string ReferenceValue)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + RequestPara.location_id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type ?? doc_cat_vm ?? RequestPara.doc_type + "!@" + RequestPara.emp_id + "!@" + RequestPara.userid + "!@" + RequestPara.active + "!@" + RequestPara.t_status + "!@" + RequestPara.PartyId + "!@" + Convert.ToDateTime(RequestPara.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(RequestPara.ToDate).ToString("MM/dd/yyyy");
                MCTemp = repository_MCTemp3.GetDataWithReturnDomainObject<MultipleContext_ACC_T001>(MCTemp, Request, "ACC_T001_BL", "FICO", "LoadAll", 0, "ACC_T001_BL");
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(MCTemp.DocumentDataFlipGrid.ToList());
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_ACC_T001_A != null)
                {
                    OpenItemList = (ObservableCollection<ACC_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T001_A, MC.DetailEntity);
                }
                else
                {
                    OpenItemList = new ObservableCollection<ACC_T001_A>();
                }
                if (MasterEntity.XmlDataDocument_ACC_T001_C != null)
                {
                    AllocationList = (ObservableCollection<ACC_T001_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T001_C, MC.PAYMENT_ALLOCATION);
                }
                else
                {
                    AllocationList = new ObservableCollection<ACC_T001_C>();
                }
                if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<ACC_T001_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                }
                MasterEntity.ts_code = ts_code_vm;
                if (OpenItemListAdvance.Count > 0)
                {
                    OpenItemListAdvance.Clear();
                }
                //if (MasterEntity.XmlDataDocument_ACC_T001_B != null)
                //{
                //    OpenItemListAdvance = (ObservableCollection<ACC_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T001_B, MC.OpenItems);
                //}
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private bool Validation()
        {
            try
            {
                if (MasterEntity.comp_code == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format("Company is Required"); showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.doc_type == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format("Document Type Is Required"); showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.amount == 0 || !MasterEntity.amount.HasValue || MasterEntity.exch_rate == 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format("Amount and Exchange Rate Is Required"); showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.PartyId == null || MasterEntity.PartyId == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format("Party Is Required"); showMessageService.ShowMessage();
                    return false;
                }

            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
            return true;
        }
        #endregion
        #region Filters
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
            var data = obj as ACC_T001_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_FlipGrid))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.pay_method != null && data.pay_method.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.amount != null && data.amount.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.check_no != null && data.check_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.SalesPerson != null && data.SalesPerson.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.t_display != null && data.t_display.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }


        #endregion
    }
}
