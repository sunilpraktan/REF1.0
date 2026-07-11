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
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using System.Windows;
using Reflection.BusinessEntity.Admin;
using Reflection.BusinessEntity;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Reflection.BusinessEntity.ADM;
using System.Collections.Specialized;
using Reflection.BusinessEntity.FICO;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0033_VM : WorkspaceViewModel<FICO_M0033>
    {
        bool isNewRecord = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
        IShowMessageViewService sms;
        WebServiceRepository<List<FICO_M0033>> repository = new WebServiceRepository<List<FICO_M0033>>();
        WebServiceRepository<MC_FICO_BE> repository_MC = new WebServiceRepository<MC_FICO_BE>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        //public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_M0033_VM));
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
        private AutoSuggestTextViewModel<dynamic> _AS_GROUP { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_GROUP
        {
            get { return _AS_GROUP; }
            set { _AS_GROUP = value; }
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
                    if (SourceName == "ctry_code")
                    { AS_DEFAULT = AS_COUNTRY; }
                    else if (SourceName == "group_code")
                    { AS_DEFAULT = AS_GROUP; }
                }
            }
        }

        #endregion

        #region Declarations       

        private MC_FICO_BE _MC;
        public MC_FICO_BE MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MC_FICO_BE _MC_TEMP;
        public MC_FICO_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); }
        }

        private FICO_M0033 _MasterEntity;
        public FICO_M0033 MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }
        private ObservableCollection<FICO_M0033> _ItemsEntity;
        public ObservableCollection<FICO_M0033> ItemsEntity
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
        private FICO_M0033 _ItemEntityObject;
        public FICO_M0033 ItemEntityObject
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

        private List<FICO_M0033> _SelectedList;
        public List<FICO_M0033> SelectedList
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
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        #endregion

        #region Constructor
        public FICO_M0033_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new FICO_M0033();
            ItemEntityObject = new FICO_M0033();
            SelectedList = new List<FICO_M0033>();
            ItemsEntity = new ObservableCollection<FICO_M0033>();
            MC = new MC_FICO_BE();
            MC_TEMP = new MC_FICO_BE();
            sms = this.GetViewService<IShowMessageViewService>();
            cmdSelectionChanged_ITEM = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_ITEM(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_FICO_BE>(MC, Request, "FICO_M0033_BL", "FICO", "LOAD_INI", 0, "");

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((FICO_M0033)x).curr_code);
                TheFilter = (o, prefix) => (((FICO_M0033)o).curr_code ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((FICO_M0033)o).curr_name ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                AS_DEFAULT = new AutoSuggestTextViewModel<dynamic>(MC.CURR_OC_LIST, TheFilter, SuggestedValue, "curr_code", "curr_code", true);
                ItemsEntity = MC.CURR_OC_LIST;
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void DefaultValues()
        {
            MasterEntity.client = AppSessionState.client;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                LoadInitialData();
                DefaultValues();
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
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
                        if (o.curr_code == p.curr_code)
                        {
                            flag++;
                        }
                    }
                    if (flag > 1)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Duplicate Record not allowed for the Currency {0}", o.curr_code); sms.ShowMessage();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(o.curr_code))
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Select curr_code for the Record {0} ", o.curr_code); sms.ShowMessage();
                        return false;
                    }
                }
            }
            return true;
        }
        private void SelectionChanged_ITEM(object InputValue)
        {
            try
            {
                ItemEntityObject = (FICO_M0033)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (FICO_M0033 item in e.NewItems)
                    {
                        item.client = AppSessionState.client;
                        item.selected = true;
                        item.userid = AppSessionState.UserID;
                        item.ts_code = ts_code_vm;
                        item.active = true;
                        item.user_source1 = AppSessionState.UserSource1;
                        item.user_source2 = AppSessionState.UserSource2;
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
        protected override void OnSaveAction(InquiryActionResult<FICO_M0033> result)
        {
            try
            {
                List<FICO_M0033> RequestList = new List<FICO_M0033>();
                foreach (FICO_M0033 item in ItemsEntity)
                {
                    if (item.selected == true)
                    {
                        RequestList.Add(item);
                    }
                }
                if (Validation() == true)
                {
                    string strReturn = repository.Save<List<FICO_M0033>>(RequestList, "FICO_M0033_BL", "FICO");

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
        protected override void OnRefreshCommand(InquiryActionResult<FICO_M0033> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<FICO_M0033> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<FICO_M0033> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<FICO_M0033> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<FICO_M0033> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<FICO_M0033> result)
        {
            isNewRecord = true;
            MasterEntity = new FICO_M0033();
            ItemEntityObject = new FICO_M0033();
            SelectedList = new List<FICO_M0033>();
            ItemsEntity = new ObservableCollection<FICO_M0033>();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<FICO_M0033> result)
        {
            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Delete Changes"; sms.Text = String.Format("This record will be Deleted forever", this.Title);
            if (sms.ShowMessage() == DialogResult.Ok)
            {
                //string response = repository.Delete(MasterEntity.SrNo, "FormReceivedFrmCustomer", "CRM");  
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<FICO_M0033> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<FICO_M0033> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<FICO_M0033> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<FICO_M0033> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<FICO_M0033> result)
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
            var data = obj as FICO_M0033;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLTR_STRING_VIEW))
                {
                    return (data.curr_code != null && (data.curr_code ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.curr_name != null && (data.curr_name ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.monitory_unit != null && (data.monitory_unit ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.monitory_unit_prefix != null && (data.monitory_unit_prefix ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.tail_word != null && (data.tail_word ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.word_format != null && (data.word_format ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.word_prefix != null && (data.word_prefix ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.word_suffix != null && (data.word_suffix ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower())
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





