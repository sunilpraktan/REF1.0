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
    public class FICO_T006_VM : WorkspaceViewModel<ACC_T001>
    {
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_T006_VM));
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
        public string doc_type_vm { get; set; }
        NumberToEnglish num = new NumberToEnglish();
        WebServiceRepository<ACC_T001> repository = new WebServiceRepository<ACC_T001>();
        WebServiceRepository<MultipleContext_ACC_T001> repository_MC = new WebServiceRepository<MultipleContext_ACC_T001>();
        WebServiceRepository<MultipleContext_ACC_T001> repository_MCTemp = new WebServiceRepository<MultipleContext_ACC_T001>();
        WebServiceRepository<MultipleContext_ACC_T001> repository_MCTemp2 = new WebServiceRepository<MultipleContext_ACC_T001>();
        WebServiceRepository<MultipleContext_ACC_T001> repository_MCTemp3 = new WebServiceRepository<MultipleContext_ACC_T001>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private STD_LIST_BE _STD_LIST_OBJECT;
        public STD_LIST_BE STD_LIST_OBJECT
        {
            get
            {
                return _STD_LIST_OBJECT;
            }
            set
            {
                if (_STD_LIST_OBJECT != value)
                {
                    _STD_LIST_OBJECT = value;
                    RaisePropertyChanged("STD_LIST_OBJECT");
                }
            }
        }

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
        public RelayCommand<object> cmdSelectionChanged_OpenItem { get; private set; }
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

        public RelayCommand<object> cmdSavePayment { get; private set; } // POS
        public RelayCommand<object> cmdPrintReceipt { get; private set; } // POS
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor for ViewModel
        /// </summary>
        /// <param name="NA"></param>
        public FICO_T006_VM(string doc_cat, string ts_code) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.doc_type_vm = doc_cat;
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
            InitializedCommands();
            LoadInitialData("ERP");
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public FICO_T006_VM(string doc_cat, string ts_code, string doc_no) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.doc_type_vm = doc_cat;
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
            InitializedCommands();
            LoadInitialData("ERP");
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public FICO_T006_VM(string doc_cat, string ts_code,string doc_no,string source) : base() // POS constructor
        {
            this.doc_cat_vm = doc_cat;
            this.doc_type_vm = doc_cat;
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
            InitializedCommands();
            LoadInitialData(source);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public FICO_T006_VM(string ts_code, STD_LIST_BE STD_LIST_OBJ) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = STD_LIST_OBJ.doc_no;
            this.doc_cat_vm = STD_LIST_OBJ.doc_cat;
            this.doc_type_vm = STD_LIST_OBJ.doc_type;
            this.doc_no_vm = STD_LIST_OBJ.doc_no;
            STD_LIST_OBJECT = new STD_LIST_BE();
            STD_LIST_OBJECT = STD_LIST_OBJ;
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
            InitializedCommands();
            LoadInitialData("ERP");
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
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
        private void InsertPayMethod(object InputValue)
        {
            STD_LIST_BE POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    string Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PAYMENT_MODE_LIST.Where(x => x.pay_mode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                }
                if (POPUPEntityObject != null) //&& MasterEntity.PartyId != POPUPEntityObject.PartyId) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.pay_method = POPUPEntityObject.pay_mode;
                    if (MC.GLCodes != null && !string.IsNullOrWhiteSpace(POPUPEntityObject.ledger_gen_c))
                    {
                        if (MC.GLCodes != null)
                        {
                            if (MC.GLCodes.Count > 0)
                            {
                                ACC_M003_P OBJ_GL = MC.GLCodes.Where(x => x.ledger_gen == POPUPEntityObject.ledger_gen_c).FirstOrDefault();
                                if (OBJ_GL != null)
                                {
                                    MasterEntity.gl_code = OBJ_GL.gl_code;
                                    MasterEntity.GlName = OBJ_GL.gl_name;
                                    MasterEntity.hb_acc = OBJ_GL.hb_acc;
                                    MasterEntity.hb_code = OBJ_GL.hb_code;
                                    MasterEntity.our_hb_name = OBJ_GL.bank_name;
                                    MasterEntity.ledger_gen = OBJ_GL.ledger_gen;
                                    MasterEntity.bank_gl_code = OBJ_GL.gl_code;
                                    MasterEntity.bank_gl_name = OBJ_GL.gl_name;
                                    MasterEntity.header_text = OBJ_GL.gl_name;
                                }
                            }
                        }
                    }
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
        { }
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
                if (STD_LIST_OBJECT != null)
                {
                    if (STD_LIST_OBJECT.type_code == "PAY_PROCESS")
                    {
                        // cmdPartyLedger Section start NOTE: make single for manual process like cmdPartyLedger and auto. now temporary create seperate code. merge when standard set.
                        MasterEntity.PartyId = STD_LIST_OBJECT.party_code;
                        MasterEntity.PartyNm = STD_LIST_OBJECT.party_name;
                        MasterEntity.curr_code = STD_LIST_OBJECT.curr_code;
                        MasterEntity.doc_cat = STD_LIST_OBJECT.doc_cat;
                        MasterEntity.doc_type = STD_LIST_OBJECT.doc_type;

                        string Request = "LOAD_OPEN_DOCS" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id.ToString() + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.PartyId + "!@" + Convert.ToDateTime(MasterEntity.doc_date).ToString("MM/dd/yyyy");
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_T001>(MCTemp, Request, "ACC_T001_BL", "FICO", "LoadAll", 0, "ACC_T001_BL");
                        OpenItemList = MCTemp.DetailEntity;
                        MC.PAYMENT_ALLOCATION = MCTemp.PAYMENT_ALLOCATION;
                        OpenItemListAdvance = MCTemp.OpenItems;
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P)x).sono);
                        TheFilter = (o, prefix) => (((SEL_T001_P)o).sono ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASOrderDocument = new AutoSuggestTextViewModel<dynamic>(MCTemp.SalesOrderList, TheFilter, SuggestedValue, "sono", true);
                        ASOrderDocument.AutoSuggestVM.IsEmptyValueAllowed = true;
                        MC.SalesOrderList = MCTemp.SalesOrderList;

                        // cmdPartyLedger Section End

                        var SelectedInvoice = (from o in OpenItemList where o.bill_doc == STD_LIST_OBJECT.ref_doc_no select o).ToList();
                        SelectOpenItem(SelectedInvoice);
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private void SelectionChanged_OpenItem(object InputValue)
        {
            try
            {
                if (((ACC_T001_A)InputValue).Select == true)
                {
                    SelectedClearedItem = (ACC_T001_A)InputValue;
                }
            }
            catch (Exception ex) { }
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

                    string Request = "LOAD_OPEN_DOCS" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id.ToString() + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.PartyId + "!@" + Convert.ToDateTime(MasterEntity.doc_date).ToString("MM/dd/yyyy");
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_T001>(MCTemp, Request, "ACC_T001_BL", "FICO", "LoadAll", 0, "ACC_T001_BL");
                    OpenItemList = MCTemp.DetailEntity;
                    MC.PAYMENT_ALLOCATION = MCTemp.PAYMENT_ALLOCATION;
                    OpenItemListAdvance = MCTemp.OpenItems;
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P)x).sono);
                    TheFilter = (o, prefix) => (((SEL_T001_P)o).sono ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASOrderDocument = new AutoSuggestTextViewModel<dynamic>(MCTemp.SalesOrderList, TheFilter, SuggestedValue, "sono", true);
                    ASOrderDocument.AutoSuggestVM.IsEmptyValueAllowed = true;
                    MC.SalesOrderList = MCTemp.SalesOrderList;
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
                    POPUPEntityObject.Select = true;
                    if (POPUPEntityObject.Select == true)
                    {
                        SelectedClearedItem = POPUPEntityObject;
                        //SelectedClearedItem.net_pay_amt = POPUPEntityObject.net_payable_amt; // NOTE: commented because replace by below line to avoide index base code.
                        SelectedClearedItem.net_pay_amt = POPUPEntityObject.net_payable_amt;
                        MasterEntity.amount = OpenItemList.Where(x => x.Select == true).Sum(x => x.net_pay_amt);

                        if (isNewRecord == true)
                        {
                            foreach (var item in MC.PAYMENT_ALLOCATION)
                            {
                                if (item.bill_doc == SelectedClearedItem.bill_doc)
                                {
                                    AllocationList.Add(item);
                                }
                            }
                            if (AllocationList != null)
                            {
                                if (AllocationList.Where(x => x.bill_doc == SelectedClearedItem.bill_doc).ToList().Count == 1)
                                {
                                    AllocationList.Where(x => x.bill_doc == SelectedClearedItem.bill_doc).ToList()[0].amount = (decimal)SelectedClearedItem.net_pay_amt;
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
                                    if (item.bill_doc == SelectedClearedItem.bill_doc)
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
                    Request = "LOAD_DOC_DOC_NO" + "!@" + AppSessionState.client + "!@" + ParameterEntityObject.comp_code + "!@" + ParameterEntityObject.doc_no;
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
                    Logging();
                    List<ACC_T001_A> SelectedOpenItems = (from o in OpenItemList where o.Select == true select o).ToList();
                    MasterEntity.XmlDataDocument_ACC_T001_A = obj.ObjectToXML(SelectedOpenItems);
                    MasterEntity.XmlDataDocument_ACC_T001_C = obj.ObjectToXML(AllocationList);
                    
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
                List<ACC_T001_A> SelectedOpenItems = (from o in OpenItemList where o.Select == true select o).ToList();
                List<ACC_T001> MasterEntityList = new List<ACC_T001>();
                MasterEntityList.Add(MasterEntity);

                object[] objDataSource = new object[4];
                string[] objDataSourceName = new string[4];
                objDataSource[0] = MasterEntityList;
                objDataSource[1] = SelectedOpenItems;
                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[2] = CmpResult;
                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[3] = Result;
                objDataSourceName[0] = "dsMaster";
                objDataSourceName[1] = "dsItem";
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
        //protected override void OnPrintAction(InquiryActionResult<ACC_T001> result)
        //{
        //    string Request = "Rpt_PaymentEntry" + "!@" + MasterEntity.doc_no + "!@" + MasterEntity.doc_type;
        //    try
        //    {
        //        MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextACC_T001_A>(MC, Request, "ACC_T001_BL", "FICO", "LoadAll", 0, "ACC_T001_BL");
        //        object[] objDataSource = new object[4];
        //        string[] objDataSourceName = new string[4];
        //        objDataSource[0] = MC.RptPaymentEntry;
        //        objDataSource[1] = MC.RptPaymentEntryItem;
        //        List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
        //        var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
        //        objDataSource[2] = CmpResult;
        //        List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
        //        var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
        //        objDataSource[3] = Result;
        //        objDataSourceName[0] = "dsRptPaymentEntry";
        //        objDataSourceName[1] = "dsRptPaymentEntryItem";
        //        objDataSourceName[2] = "dsCompany";
        //        objDataSourceName[3] = "dsLocation";
        //        ReportManager ReportManager = new ReportManager();
        //        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Finance\\PaymentEntry.rdlc", getParametersList(), "ACC_T001_BL");
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
        //    }
        //}
        protected override void OnDocumentAction()
        { }
        protected override void OnRefreshCommand(InquiryActionResult<ACC_T001> result)
        {
            LoadInitialData("ERP");
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

                if(MasterEntity.amount.HasValue)
                {
                    MasterEntity.received_amt = MasterEntity.amount;
                    MasterEntity.change_amt = MasterEntity.amount - MasterEntity.received_amt;
                }
            }
            if (sender.ToString() == "received_amt")
            {
                if (MasterEntity.received_amt.HasValue)
                {
                    MasterEntity.change_amt = MasterEntity.amount - MasterEntity.received_amt;
                }
            }    
            this.ErrorExist = MasterEntity.HasErrors;
        }
        private void ModelUpdated_Item(object sender, EventArgs e)//This will get called when the property of an object changes
        {
            if ((sender.ToString() == "Select" || sender.ToString() == "cash_disc1" || sender.ToString() == "amt_withhold_tax" || sender.ToString() == "net_pay_amt") && dgSelectedIndexPayment >= 0)
            {
                if (OpenItemList != null)
                {
                    if (OpenItemList.Count > 0)
                    {
                        if (SelectedClearedItem.amount_doc_curr.HasValue && SelectedClearedItem.Select == true)
                        {
                            decimal Exch_Rate_Doc = SelectedClearedItem.doc_exch_rate;
                            decimal Exch_Rate_Current = MasterEntity.exch_rate;
                            decimal DocumentAmount = SelectedClearedItem.net_payable_amt;
                            decimal DocumentAmountLocal = DocumentAmount * Exch_Rate_Doc;
                            //decimal NetPayableAmount = SelectedClearedItem.net_payable_amt ?? 0;
                            //decimal NetPayableAmountLocal = NetPayableAmount * Exch_Rate_Doc;
                            decimal TotalWTaxAmt = SelectedClearedItem.amt_withhold_tax ?? 0;
                            //decimal TotalWTaxAmtLocal = TotalWTaxAmt * Exch_Rate_Doc;
                            decimal TotalCashDiscount = SelectedClearedItem.cash_disc1 ?? 0;
                            //decimal TotalCashDiscountLocal = TotalCashDiscount * Exch_Rate_Doc;
                            decimal NetPaidAmount = SelectedClearedItem.net_pay_amt ?? 0;
                            //decimal NetPaidAmountLocal = NetPaidAmount * Exch_Rate_Doc;
                            decimal TotatFluctuation_amt = (NetPaidAmount * Exch_Rate_Doc) - (NetPaidAmount * Exch_Rate_Current);

                            //SelectedClearedItem.net_payable_amt = DocumentAmount - TotalCashDiscount - TotalWTaxAmt;
                            if (sender.ToString() != "net_pay_amt")
                            {
                                SelectedClearedItem.net_pay_amt = DocumentAmount - TotalCashDiscount - TotalWTaxAmt;
                            }
                            NetPaidAmount = SelectedClearedItem.net_pay_amt ?? 0;
                            SelectedClearedItem.bal_amt = SelectedClearedItem.net_payable_amt - (NetPaidAmount + TotalCashDiscount + TotalWTaxAmt);
                            SelectedClearedItem.loss_real1 = TotatFluctuation_amt;
                            SelectedClearedItem.value_diff = TotatFluctuation_amt;
                            SelectedClearedItem.amount_loc_curr = SelectedClearedItem.net_payable_amt * Exch_Rate_Doc;
                            SelectedClearedItem.amount_ledger = NetPaidAmount;
                            SelectedClearedItem.amt_withhold_tax_loc = TotalWTaxAmt * Exch_Rate_Doc;
                            SelectedClearedItem.cd_loc_curr = TotalCashDiscount * Exch_Rate_Doc;
                            SelectedClearedItem.cd_doc_curr = TotalCashDiscount;
                            SelectedClearedItem.cur_exch_rate = Exch_Rate_Current;
                            SelectedClearedItem.ex_rate_diff = Exch_Rate_Current - Exch_Rate_Doc;
                            SelectedClearedItem.ref_doc_no = SelectedClearedItem.doc_no;
                            MasterEntity.amount = OpenItemList.Where(x => x.Select == true).Sum(x => x.net_pay_amt);

                            if (AllocationList != null)
                            {
                                if (AllocationList.Where(x => x.bill_doc == SelectedClearedItem.bill_doc).ToList().Count == 1)
                                {
                                    AllocationList.Where(x => x.bill_doc == SelectedClearedItem.bill_doc).ToList()[0].amount = (decimal)SelectedClearedItem.net_pay_amt;
                                }
                            }
                        }
                    }
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
                MasterEntity.client = AppSessionState.client;

                if (MC.PAYMENT_MODE_LIST != null)
                {
                    if (MC.PAYMENT_MODE_LIST.Count > 0)
                    {
                        STD_LIST_BE PM_OBJ = MC.PAYMENT_MODE_LIST.Where(x => x.ind_default == "1").FirstOrDefault();
                        if(PM_OBJ != null)
                        {
                            MasterEntity.pay_method = PM_OBJ.pay_mode;
                            MasterEntity.pay_method_desc = PM_OBJ.text_name;

                            if (MC.GLCodes != null)
                            {
                                if (MC.GLCodes.Count > 0)
                                {
                                    ACC_M003_P OBJ_GL = MC.GLCodes.Where(x => x.ledger_gen == PM_OBJ.ledger_gen_c).FirstOrDefault();
                                    if (OBJ_GL != null)
                                    {
                                        MasterEntity.gl_code = OBJ_GL.gl_code;
                                        MasterEntity.GlName = OBJ_GL.gl_name;
                                        MasterEntity.hb_acc = OBJ_GL.hb_acc;
                                        MasterEntity.hb_code = OBJ_GL.hb_code;
                                        MasterEntity.our_hb_name = OBJ_GL.bank_name;
                                        MasterEntity.ledger_gen = OBJ_GL.ledger_gen;
                                        MasterEntity.bank_gl_code = OBJ_GL.gl_code;
                                        MasterEntity.bank_gl_name = OBJ_GL.gl_name;
                                        MasterEntity.header_text = OBJ_GL.gl_name;
                                    }
                                }
                            }
                        }
                    }
                }

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
        private void InitializedCommands()
        {
            try
            {
                #region Command Initialisation //
                cmdSelectionChanged_OpenItem = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_OpenItem(items); });
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
                cmdPrintReceipt = new RelayCommand<object>(items => { if (items == null) { return; } PrintReceipt(items); });
                cmdSavePayment = new RelayCommand<object>(items => { if (items == null) { return; } SavePayment(items); });
                #endregion

            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private void LoadInitialData(string source)
        {
            try
            {
                
                string Request;
                if(source == "ERP")
                {
                    Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id.ToString() + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID;
                }
                else
                {
                    Request = "LOAD_INI_POS" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id.ToString() + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID;
                }
                
                
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

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).pay_mode);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).pay_mode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).text_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPayMethod = new AutoSuggestTextViewModel<dynamic>(MC.PAYMENT_MODE_LIST, TheFilter, SuggestedValue, "pay_mode", true);
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
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + RequestPara.location_id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type ?? doc_cat_vm ?? RequestPara.doc_type + "!@" + RequestPara.emp_id + "!@" + RequestPara.userid + "!@" + RequestPara.active + "!@" + RequestPara.t_status + "!@" + RequestPara.PartyId + "!@" + Convert.ToDateTime(RequestPara.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(RequestPara.ToDate).ToString("MM/dd/yyyy");
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
                MasterEntity.ts_code = ts_code_vm;
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
                if (!MasterEntity.amount.HasValue)
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Payment amount value not correct"); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.bank_gl_code == null || MasterEntity.bank_gl_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format("GL Account Is Required"); showMessageService.ShowMessage();
                    return false;
                }
                if (OpenItemList.Count == 0 && string.IsNullOrWhiteSpace(MasterEntity.ind_spl_gl) == true)
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Open Item Not Exists,document cannot be post without special indicator"); sms.ShowMessage();
                    return false;
                }
                if (!string.IsNullOrWhiteSpace(MasterEntity.ind_spl_gl) && string.IsNullOrWhiteSpace(MasterEntity.order_no))
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Input Sales/Purchase reference document for Advance Payment"); sms.ShowMessage();
                    return false;
                }
                if (OpenItemList.Count > 0)
                {
                    if (OpenItemList.Where(x => x.Select == true).ToList().Count() == 0 && string.IsNullOrWhiteSpace(MasterEntity.ind_spl_gl) == true)
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Open Item Not selected,document cannot be post without special indicator"); sms.ShowMessage();
                        return false;
                    }
                }

                if (OpenItemList.Count > 0)
                {
                    if (MasterEntity.amount != MasterEntity.total_amt_paid)
                    {
                        //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        //showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format("Amount Must be equal to SUM Of Paid Amount"); showMessageService.ShowMessage();
                        //return false;
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
            return true;
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "POS_PAY") // This is combination of InsertPartyLedger & SelectOpenItem specific to POS
            {
                SEL_T003 OBJ_INV = (SEL_T003)msg.Sender;

                string Request = "LOAD_OPEN_DOCS" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id.ToString() + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + OBJ_INV.PartyId + "!@" + Convert.ToDateTime(MasterEntity.doc_date).ToString("MM/dd/yyyy") + "!@" + OBJ_INV.bill_doc;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_T001>(MCTemp, Request, "ACC_T001_BL", "FICO", "LoadAll", 0, "ACC_T001_BL");
                OpenItemList = MCTemp.DetailEntity;
                MC.PAYMENT_ALLOCATION = MCTemp.PAYMENT_ALLOCATION;
                OpenItemListAdvance = MCTemp.OpenItems;

                MC.SalesOrderList = MCTemp.SalesOrderList;

                if (MCTemp.PartyMaster != null && OpenItemList != null)
                {
                    if (MCTemp.PartyMaster.Count > 0 && OpenItemList.Count > 0)
                    {
                        DefaultValues();
                        MasterEntity.PartyId = MCTemp.PartyMaster[0].PartyId;
                        MasterEntity.PartyNm = MCTemp.PartyMaster[0].PartyNm;
                        MasterEntity.curr_code = MCTemp.PartyMaster[0].curr_code ?? AppSessionState.CntryCurncy;
                        MasterEntity.party_bank_name = MCTemp.PartyMaster[0].bank_name;
                        MasterEntity.swift_code = MCTemp.PartyMaster[0].swift_code;
                        MasterEntity.ifsc_code = MCTemp.PartyMaster[0].ifsccode;
                        MasterEntity.header_text = MCTemp.PartyMaster[0].gl_name;
                        MasterEntity.curr_code = MCTemp.PartyMaster[0].curr_code;
                        MasterEntity.bank_party = MCTemp.PartyMaster[0].bank_code;
                        MasterEntity.bank_acc_no = MCTemp.PartyMaster[0].acc_number;

                        isNewRecord = true;
                        // Commented because it is linked with payment mode in default value function. as per commented in NOTE.
                        //MasterEntity.ledger_gen = MC.GLCodes.Where(x => x.ind_default == true).ToList()[0].ledger_gen; // NOTE: Default Bank/Cash Ledger, it should be link with mode of payment wether it is cash or check or upi
                        //InsertCompanyLedger(MasterEntity.ledger_gen);
                        OpenItemList[0].Select = true;
                        SelectOpenItem(OpenItemList);
                    }


                }


            }

            if (msg.Notification == "PAY_CLEAR") // This is combination of InsertPartyLedger & SelectOpenItem specific to POS
            {
                InquiryActionResult<ACC_T001> result = new WindowViewModel<ACC_T001>.InquiryActionResult<ACC_T001>();
                OnCreateAction(result);
            }
        }

        private void SavePayment(object InputValue)
        {
            InquiryActionResult<ACC_T001> result = new WindowViewModel<ACC_T001>.InquiryActionResult<ACC_T001>();
            OnSaveAction(result);
            if(!string.IsNullOrWhiteSpace(MasterEntity.doc_no)) // Update inventory after save payment successfully.
            {
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(MasterEntity, "POS_POST_STOCK"));
            }
                
        }
        private void PrintReceipt(object InputValue)
        {
            InquiryActionResult<ACC_T001> result = new WindowViewModel<ACC_T001>.InquiryActionResult<ACC_T001>();
            OnPrintAction(result);
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
