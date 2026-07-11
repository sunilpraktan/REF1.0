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
using System.Windows.Controls;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.Finance;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0006_VM : WorkspaceViewModel<ACC_M003>
    {
        bool isNewRecord = true;

        WebServiceRepository<ACC_M003> repository = new WebServiceRepository<ACC_M003>();
        WebServiceRepository<MultipleContext_ACC_M003> repository_MC = new WebServiceRepository<MultipleContext_ACC_M003>();
        WebServiceRepository<MultipleContext_ACC_M003> repository_MCTemp = new WebServiceRepository<MultipleContext_ACC_M003>();
        ObjectSerializationService obj = new ObjectSerializationService();


        #region AutoSuggest Initialization
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_M0006_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

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
                }
            }
        }


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
        private AutoSuggestTextViewModel<dynamic> _ASBankKey { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBankKey
        {
            get { return _ASBankKey; }
            set
            {
                if (_ASBankKey != value)
                {
                    _ASBankKey = value; RaisePropertyChanged("ASBankKey");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAccGrp { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccGrp
        {
            get { return _ASAccGrp; }
            set
            {
                if (_ASAccGrp != value)
                {
                    _ASAccGrp = value; RaisePropertyChanged("ASAccGrp");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAccSubGrp { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccSubGrp
        {
            get { return _ASAccSubGrp; }
            set
            {
                if (_ASAccSubGrp != value)
                {
                    _ASAccSubGrp = value; RaisePropertyChanged("ASAccSubGrp");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASGrpCategory { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGrpCategory
        {
            get { return _ASGrpCategory; }
            set
            {
                if (_ASGrpCategory != value)
                {
                    _ASGrpCategory = value; RaisePropertyChanged("ASGrpCategory");
                }
            }
        }

        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }

        public RelayCommand<object> CmdCurrency { get; private set; }
        public RelayCommand<object> CmdBankKey { get; private set; }
        public RelayCommand<object> CmdAddGrp { get; private set; }
        public RelayCommand<object> CmdAccSubGrp { get; private set; }
        public RelayCommand<object> CmdGrpCategoty { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        #endregion

        #region Variable Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private ACC_M003 _MasterEntity;
        public ACC_M003 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                    RaisePropertyChanged("MasterEntity");
                    value.BeginEdit();
                }
            }
        }

        private MultipleContext_ACC_M003 _MC;
        public MultipleContext_ACC_M003 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }



        private List<ACC_M003> _AccLedgerData;
        public List<ACC_M003> AccLedgerData
        {
            get { return _AccLedgerData; }
            set
            {
                if (_AccLedgerData != value)
                {
                    _AccLedgerData = value;
                    RaisePropertyChanged("AccLedgerData");
                }
            }
        }

        private ICollectionView _AccLedgerEntity;
        public ICollectionView AccLedgerEntity
        {
            get { return _AccLedgerEntity; }
            set
            {
                if (_AccLedgerEntity != value)
                {
                    _AccLedgerEntity = value;
                    RaisePropertyChanged("AccLedgerEntity");
                }
            }
        }
        private List<ACC_M003_B_P> _subgroup;
        public List<ACC_M003_B_P> subgroup
        {
            get { return _subgroup; }
            set
            {
                if (_subgroup != value)
                {
                    _subgroup = value;
                    RaisePropertyChanged("subgroup");
                }
            }
        }
        private List<ACC_M004_A_P> _bankkey;
        public List<ACC_M004_A_P> bankkey
        {
            get { return _bankkey; }
            set
            {
                if (_bankkey != value)
                {
                    _bankkey = value;
                    RaisePropertyChanged("bankkey");
                }
            }
        }
        private List<ACC_M003> _SelectedList;
        public List<ACC_M003> SelectedList
        {
            get
            {
                return _SelectedList;
            }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;
                    RaisePropertyChanged("SelectedList");
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
        #endregion


        #region Constructor
        public FICO_M0006_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new ACC_M003();
            MC = new MultipleContext_ACC_M003();
            LoadInitialData();
        }
        public FICO_M0006_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new ACC_M003();
            MC = new MultipleContext_ACC_M003();
            LoadInitialData();
        }

        #endregion

        #region User Defined Methods
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.active = true;
            MasterEntity.reconcile = false;
            // MasterEntity.ind_bal = false;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;
        }

        private bool Validation()
        {
            foreach (var o in AccLedgerData)
            {
                if (o.gl_code == null || o.gl_code == "")
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter G/L Code");

                    showMessageService.ShowMessage();
                    return false;
                }
            }

            return true;
        }
        private void LoadInitialData()
        {
            try
            {
                #region Commands
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CmdCurrency = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrency(items); });
                CmdBankKey = new RelayCommand<object>(items => { if (items == null) { return; } InsertBankKey(items); });
                CmdAddGrp = new RelayCommand<object>(items => { if (items == null) { return; } InsertGroup(items); });
                CmdAccSubGrp = new RelayCommand<object>(items => { if (items == null) { return; } InsertSubGroup(items); });
                CmdGrpCategoty = new RelayCommand<object>(items => { if (items == null) { return; } InsertGrpCategory(items); });
                CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });

                #endregion
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M003>(MC, Request, "AccountLedger", "Finance", "LoadInitialData", 0, "");



                AccLedgerData = MC.AccLedgerList;
                SelectedList = AccLedgerData.ToList();

                AccLedgerEntity = CollectionViewSource.GetDefaultView(MC.AccLedgerList);
                AccLedgerEntity.Filter = new Predicate<object>(Filter);

                #region AutoSuggest Initalization
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M037_P)o).curr_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCurrency = new AutoSuggestTextViewModel<dynamic>(MC.CurrencyList, TheFilter, SuggestedValue, "curr_code", true);
                ASCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M004_A_P)x).bank_key ?? "");
                TheFilter = (o, prefix) => (((ACC_M004_A_P)o).bank_key ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M004_A_P)o).bank_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASBankKey = new AutoSuggestTextViewModel<dynamic>(MC.BankKeyList, TheFilter, SuggestedValue, "bank_key", true);
                ASBankKey.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_A_P)x).ac_group_code ?? "");
                TheFilter = (o, prefix) => (((ACC_M003_A_P)o).ac_group_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_A_P)o).ac_group_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASAccGrp = new AutoSuggestTextViewModel<dynamic>(MC.AccGroupList, TheFilter, SuggestedValue, "ac_group_code", true);
                ASAccGrp.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_C_P)x).group_cat_name ?? "");
                TheFilter = (o, prefix) => (((ACC_M003_C_P)o).group_cat ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_C_P)o).group_cat_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASGrpCategory = new AutoSuggestTextViewModel<dynamic>(MC.GrpCatList, TheFilter, SuggestedValue, "group_cat_name", true);
                ASGrpCategory.AutoSuggestVM.IsEmptyValueAllowed = true;

                DefaultValues();
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
                            { POPUPEntityObject = MC.CurrencyList.Where(x => x.curr_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M037_P>().ToList()[0];
                    }

                    if (POPUPEntityObject != null)
                    {
                        MasterEntity.curr_code = POPUPEntityObject.curr_code;
                        MasterEntity.curr_name = POPUPEntityObject.curr_name;
                    }
                }
                catch (Exception ex) { }
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
        private void InsertBankKey(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M004_A_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.BankKeyList.Where(x => x.bank_key.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M004_A_P>().ToList()[0];
                    }

                    if (POPUPEntityObject != null)
                    {
                        MasterEntity.house_bank_key = POPUPEntityObject.bank_key;
                        MasterEntity.bank_name = POPUPEntityObject.bank_name;
                    }
                }
                catch (Exception ex) { }
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
        private void InsertGroup(object InputValue)
        {
            string Request = "";
            ACC_M003_A_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.AccGroupList.Where(x => x.ac_group_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M003_A_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_A_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ac_group_code = POPUPEntityObject.ac_group_code;
                    MasterEntity.ac_group_name = POPUPEntityObject.ac_group_name;

                    subgroup = (from o in MC.AccGroupSubList
                                where o.parent_group_code == POPUPEntityObject.ac_group_code
                                select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_B_P)x).ac_group_name ?? "");
                    TheFilter = (o, prefix) => (((ACC_M003_B_P)o).ac_group_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M003_B_P)o).ac_group_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    ASAccSubGrp = new AutoSuggestTextViewModel<dynamic>(subgroup, TheFilter, SuggestedValue, "ac_group_code", true);
                    ASAccSubGrp.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASAccSubGrp.AutoSuggestVM.IsFreeTextAllowed = true;

                }
                var msg = new NotificationMessage("FICO_M0006_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex) { }
        }
        private void InsertSubGroup(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_B_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.AccGroupSubList.Where(x => x.ac_group_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_B_P>().ToList()[0];
                    }

                    if (POPUPEntityObject != null)
                    {
                        MasterEntity.ac_sg_code = POPUPEntityObject.ac_group_code;
                        MasterEntity.ac_sg_name = POPUPEntityObject.ac_group_name;
                    }
                }
                catch (Exception ex) { }
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
        private void InsertGrpCategory(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_C_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.GrpCatList.Where(x => x.group_cat_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_C_P>().ToList()[0];
                    }

                    if (POPUPEntityObject != null)
                    {
                        MasterEntity.group_cat = POPUPEntityObject.group_cat;
                        MasterEntity.group_cat_name = POPUPEntityObject.group_cat_name;
                    }
                }
                catch (Exception ex) { }
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

        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                ACC_M003 ParameterEntityObject = null;


                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<ACC_M003>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ACC_M003>().ToList()[0];


                        if (MC.AccLedgerList.Count > 0)
                        {
                            MasterEntity = ParameterEntityObject;

                        }



                        SelectedTabControlIndex = 0;
                        isNewRecord = false;
                        MasterEntity.ts_code = ts_code_vm;

                        var msg = new NotificationMessage("FICO_M0006_VM");
                        Messenger.Default.Send<NotificationMessage>(msg);
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
        string strReturn = "";
        protected override void OnSaveAction(InquiryActionResult<ACC_M003> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.editby = AppSessionState.UserID;
                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ACC_M003>(MasterEntity, "AccountLedger", "Finance");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ACC_M003>(MasterEntity, "AccountLedger", "Finance");
                    }

                    if (MasterEntity.gl_code != null && isNewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    else if (MasterEntity.gl_code != null && isNewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    isNewRecord = false;
                    var msg = new NotificationMessage("ACC_M003");
                    Messenger.Default.Send<NotificationMessage>(msg);
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

        protected override void OnDocumentAction()
        {
        }
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M003> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ACC_M003> result)
        {

            MasterEntity = new ACC_M003();
            var msg = new NotificationMessage("FICO_M0006_VM");
            Messenger.Default.Send<NotificationMessage>(msg);

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_M003> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ACC_M003> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M003> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ACC_M003> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ACC_M003> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ACC_M003> result)
        {

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
            if (AccLedgerEntity != null)
            {
                AccLedgerEntity.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ACC_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.gl_code != null && data.gl_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.p_name != null && data.p_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.acc_type != null && data.acc_type.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.ac_group_code != null && data.ac_group_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.ac_sg_code != null && data.ac_sg_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                             data.group_cat != null && data.group_cat.ToString().ToLower().Contains(_filterString.ToLower())
                             );
                }
                return true;
            }
            return false;
        }





        #endregion

        #endregion
    }
}
