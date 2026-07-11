using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.Presentation.ViewModel;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.Finance;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using Reflection.Presentation.Services.Convertors;
using System.Collections;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.FICO;
using System.Collections.Specialized;
using System.Windows.Controls;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0021_VM : WorkspaceViewModel<FICO_M0004>
    {
        bool isNewRecord = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
        IShowMessageViewService sms;
        WebServiceRepository<List<FICO_M0004>> repository = new WebServiceRepository<List<FICO_M0004>>();
        WebServiceRepository<MC_FICO_M0004> repository_MC = new WebServiceRepository<MC_FICO_M0004>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        //public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_M0021_VM));
        //public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
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
        private AutoSuggestTextViewModel<dynamic> _AS_COMPANY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_COMPANY
        {
            get { return _AS_COMPANY; }
            set { _AS_COMPANY = value; }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_COUNTRY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_COUNTRY
        {
            get { return _AS_COUNTRY; }
            set { _AS_COUNTRY = value; }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_BANK { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_BANK
        {
            get { return _AS_BANK; }
            set { _AS_BANK = value; }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_AC_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_AC_TYPE
        {
            get { return _AS_AC_TYPE; }
            set { _AS_AC_TYPE = value; }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_CURRENCY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CURRENCY
        {
            get { return _AS_CURRENCY; }
            set { _AS_CURRENCY = value; }
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
                    if (SourceName == "comp_code")
                    { AS_DEFAULT = AS_COMPANY; }
                    else if (SourceName == "acc_type")
                    { AS_DEFAULT = AS_AC_TYPE; }
                    else if (SourceName == "curr_code")
                    { AS_DEFAULT = AS_CURRENCY; }
                    else if (SourceName == "ctry_code")
                    { AS_DEFAULT = AS_COUNTRY; }
                    else if (SourceName == "bank_code")
                    { AS_DEFAULT = AS_BANK; }
                    else if (SourceName == "hb_code")
                    { AS_DEFAULT = AS_BANK; }
                }
            }
        }

        #endregion

        #region Declarations       

        private MC_FICO_M0004 _MC;
        public MC_FICO_M0004 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MC_FICO_M0004 _MC_TEMP;
        public MC_FICO_M0004 MC_TEMP
        {
            get { return _MC_TEMP; }
            set { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); }
        }

        private FICO_M0004 _MasterEntity;
        public FICO_M0004 MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }
        private ObservableCollection<FICO_M0004> _ItemsEntity;
        public ObservableCollection<FICO_M0004> ItemsEntity
        {
            get
            {
                return _ItemsEntity;
            }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                    ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }
        private int _dgSelectedIndex;
        public int dgSelectedIndex
        {
            get
            { return _dgSelectedIndex; }
            set
            {
                if (_dgSelectedIndex != value)
                {
                    _dgSelectedIndex = value;
                    RaisePropertyChanged("dgSelectedIndex");
                }
            }
        }
        private FICO_M0004 _ItemEntityObject;
        public FICO_M0004 ItemEntityObject
        {
            get
            {
                return _ItemEntityObject;
            }
            set
            {
                if (_ItemEntityObject != value)
                {
                    _ItemEntityObject = value;
                    RaisePropertyChanged("ItemEntityObject");
                }
            }
        }

        private List<FICO_M0004> _SelectedList;
        public List<FICO_M0004> SelectedList
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

        private ICollectionView _ITEMS_COLLECTION_VIVE;
        public ICollectionView ITEMS_COLLECTION_VIVE
        {
            get { return _ITEMS_COLLECTION_VIVE; }
            set { _ITEMS_COLLECTION_VIVE = value; RaisePropertyChanged("ITEMS_COLLECTION_VIVE"); }
        }
        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdSelectionChanged_ITEM { get; private set; }
        public RelayCommand<object> cmdInsertBank { get; private set; }
        #endregion

        #region Constructor
        public FICO_M0021_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new FICO_M0004();
            ItemEntityObject = new FICO_M0004();
            SelectedList = new List<FICO_M0004>();
            ItemsEntity = new ObservableCollection<FICO_M0004>();
            MC = new MC_FICO_M0004();
            MC_TEMP = new MC_FICO_M0004();
            sms = this.GetViewService<IShowMessageViewService>();
            cmdSelectionChanged_ITEM = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_ITEM(items); });
            cmdInsertBank = new RelayCommand<object>(items => { if (items == null) { return; } InsertBank(items); });
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI_ACC" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_FICO_M0004>(MC, Request, "FICO_M0004_B_BL", "FICO", "LOAD_INI", 0, "");

                DefaultValues();
                AS_DEFAULT = new AutoSuggestTextViewModel<dynamic>(MC.INCOTERM_LIST, TheFilter, SuggestedValue, "incoterms", "incoterm", true);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix);
                AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", "comp_code", true);
                AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_COMPANY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).ctry_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).ctry_code ?? "").ToString().ToUpper().Contains(prefix) ||
                                           (((STD_LIST_BE)o).country_name ?? "").ToString().ToUpper().Contains(prefix);
                AS_COUNTRY = new AutoSuggestTextViewModel<dynamic>(MC.COUNTRY_LIST, TheFilter, SuggestedValue, "ctry_code", "ctry_code", true);
                AS_COUNTRY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_COUNTRY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037)o).curr_code ?? "").ToString().ToUpper().Contains(prefix) ||
                                           (((ADM_M037)o).curr_name ?? "").ToString().ToUpper().Contains(prefix);
                AS_CURRENCY = new AutoSuggestTextViewModel<dynamic>(MC.CURRENCY_LIST, TheFilter, SuggestedValue, "curr_code", "curr_code", true);
                AS_CURRENCY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_CURRENCY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((FICO_M0004)x).hb_code);
                TheFilter = (o, prefix) => (((FICO_M0004)o).hb_code ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((FICO_M0004)o).bank_name ?? "").ToString().ToLower().Contains(prefix);
                AS_BANK = new AutoSuggestTextViewModel<dynamic>(MC.BANK_LIST, TheFilter, SuggestedValue, "hb_code", "hb_code", true);
                AS_BANK.AutoSuggestVM.IsEmptyValueAllowed = true; AS_BANK.AutoSuggestVM.IsFreeTextAllowed = false;

                ItemsEntity = MC.MASTER_ENTITY_LIST;
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void DefaultValues()
        {
            MasterEntity.client = AppSessionState.client;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.userid = AppSessionState.UserID;
        }
        private bool Validation()
        {
            foreach (var o in ItemsEntity)
            {
                int flag = 0;
                if (o.selected == true)
                {
                    foreach (var p in ItemsEntity)
                    {
                        if (o.comp_code == p.comp_code && o.hb_code == p.hb_code && o.hb_acc == p.hb_acc)
                        {
                            flag++;
                        }
                    }
                    if (flag > 1)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Duplicate Record not allowed for the Bank {0} and House Bank {1} and Company {2}", o.bank_name, o.hb_code, o.comp_code); sms.ShowMessage();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(o.comp_code))
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Select company for the House Bank {0} and Account {1} and company {2}", o.bank_name, o.hb_code, o.comp_code); sms.ShowMessage();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(o.acc_no))
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Select Account Number for the House Bank {0} and Account {1} and company {2}", o.bank_name, o.hb_code, o.comp_code);
                        sms.ShowMessage(); return false;
                    }
                    if (string.IsNullOrWhiteSpace(o.hb_code))
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Select House Bank for the Bank {0} and HB Code {1} and Company {1}", o.bank_name, o.hb_code, o.comp_code);
                        sms.ShowMessage(); return false;
                    }
                }
            }
            return true;
        }
        private void SelectionChanged_ITEM(object InputValue)
        {
            try
            {
                ItemEntityObject = (FICO_M0004)InputValue;
            }
            catch (Exception ex) { }
        }
        private void InsertBank(object InputValue)
        {
            try
            {
                string Request = "";
                FICO_M0004 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.BANK_LIST.Where(x => x.hb_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<FICO_M0004>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ItemEntityObject.hb_code = POPUPEntityObject.hb_code;
                    ItemEntityObject.bank_code = POPUPEntityObject.bank_code;
                    ItemEntityObject.bank_name = POPUPEntityObject.bank_name;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (FICO_M0004 item in e.NewItems)
                    {
                        item.client = AppSessionState.client;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.selected = true;
                        item.userid = AppSessionState.UserID;
                        item.ts_code = ts_code_vm;
                        item.active = true;
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
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        #endregion

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<FICO_M0004> result)
        {
            try
            {
                List<FICO_M0004> RequestList = new List<FICO_M0004>();
                foreach (FICO_M0004 item in ItemsEntity)
                {
                    if (item.selected == true)
                    {
                        RequestList.Add(item);
                    }
                }
                if (Validation() == true)
                {
                    string strReturn = repository.Save<List<FICO_M0004>>(RequestList, "FICO_M0004_B_BL", "FICO");

                    if (SelectedList != null)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record Saved and Updated Successfully!", this.Title); sms.ShowMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnDocumentAction()
        { }
        protected override void OnRefreshCommand(InquiryActionResult<FICO_M0004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<FICO_M0004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<FICO_M0004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<FICO_M0004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<FICO_M0004> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<FICO_M0004> result)
        {
            isNewRecord = true;
            MasterEntity = new FICO_M0004();
            ItemEntityObject = new FICO_M0004();
            SelectedList = new List<FICO_M0004>();
            ItemsEntity = new ObservableCollection<FICO_M0004>();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<FICO_M0004> result)
        {
            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Delete Changes"; sms.Text = String.Format("This record will be Deleted forever", this.Title);
            if (sms.ShowMessage() == DialogResult.Ok)
            {
                //string response = repository.Delete(MasterEntity.SrNo, "FormReceivedFrmCustomer", "CRM");  
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<FICO_M0004> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<FICO_M0004> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<FICO_M0004> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<FICO_M0004> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<FICO_M0004> result)
        {

        }

        #endregion

        #region Filters

        #region Filters For DataGrid   

        private string _FLTR_STRING_VIEW;
        public string FLTR_STRING_VIEW
        {
            get { return _FLTR_STRING_VIEW; }
            set
            {
                if (_FLTR_STRING_VIEW != value)
                {
                    _FLTR_STRING_VIEW = value;
                    RaisePropertyChanged("FLTR_STRING_VIEW");
                    FilterCollection();
                }
            }
        }
        private void FilterCollection()
        {
            if (_ITEMS_COLLECTION_VIVE != null)
            {
                _ITEMS_COLLECTION_VIVE.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as FICO_M0004;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLTR_STRING_VIEW))
                {
                    return (data.hb_code != null && (data.hb_code ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.bank_code != null && (data.bank_code ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.bank_name != null && (data.bank_name ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.acc_name != null && (data.acc_name ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.acc_no != null && (data.acc_no ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.acc_type != null && (data.acc_type ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.abbr != null && (data.abbr ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.branch != null && (data.branch ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.iban_no != null && (data.iban_no ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.swift_code != null && (data.swift_code ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.ifsc_code != null && (data.ifsc_code ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower())
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
