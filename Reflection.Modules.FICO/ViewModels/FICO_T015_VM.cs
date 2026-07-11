using Reflection.BusinessEntity.Finance;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_T015_VM : WorkspaceViewModel<ACC_T004>
    {
        #region AutoSuggest TextBox Declaration Region

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_T015_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASCompCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCompCode
        {
            get { return _ASCompCode; }
            set
            {
                if (_ASCompCode != value)
                {
                    _ASCompCode = value; RaisePropertyChanged("ASCompCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPostingPeriod { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPostingPeriod
        {
            get { return _ASPostingPeriod; }
            set
            {
                if (_ASPostingPeriod != value)
                {
                    _ASPostingPeriod = value; RaisePropertyChanged("ASPostingPeriod");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASGeneralLedger_dg { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGeneralLedger_dg
        {
            get { return _ASGeneralLedger_dg; }
            set
            {
                if (_ASGeneralLedger_dg != value)
                {
                    _ASGeneralLedger_dg = value; RaisePropertyChanged("ASGeneralLedger_dg");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPostingKey_dg { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPostingKey_dg
        {
            get { return _ASPostingKey_dg; }
            set
            {
                if (_ASPostingKey_dg != value)
                {
                    _ASPostingKey_dg = value; RaisePropertyChanged("ASPostingKey_dg");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCurrency_dg { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCurrency_dg
        {
            get { return _ASCurrency_dg; }
            set
            {
                if (_ASCurrency_dg != value)
                {
                    _ASCurrency_dg = value; RaisePropertyChanged("ASCurrency_dg");
                }
            }
        }

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
                        { ASDefault = ASGeneralLedger_dg; }
                        else if (SourceName == "doc_curr_code")
                        { ASDefault = ASCurrency_dg; }
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

        #region Declaration
        bool isNewRecord = true;

        WebServiceRepository<ACC_T004> repository = new WebServiceRepository<ACC_T004>();
        WebServiceRepository<MultipleContext_ACC_T004> repository_MC = new WebServiceRepository<MultipleContext_ACC_T004>();
        WebServiceRepository<MultipleContext_ACC_T004> repository_MCTemp = new WebServiceRepository<MultipleContext_ACC_T004>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_ACC_T004 _MC = new MultipleContext_ACC_T004();
        public MultipleContext_ACC_T004 MC
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

        private MultipleContext_ACC_T004 _MCTemp = new MultipleContext_ACC_T004();
        public MultipleContext_ACC_T004 MCTemp
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

        private MultipleContext_ACC_T004 _MCTemp1 = new MultipleContext_ACC_T004();
        public MultipleContext_ACC_T004 MCTemp1
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

        private ACC_T004 _MasterEntity;
        public ACC_T004 MasterEntity
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

        private ObservableCollection<ACC_T004_A> _ItemsEntity;
        public ObservableCollection<ACC_T004_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value; RaisePropertyChanged("ItemsEntity");
                    //  ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    // RaisePropertyChanged("ItemsEntity");

                }
            }
        }

        private bool _IsDocumentViewerShow;
        public bool IsDocumentViewerShow
        {
            get
            {
                return _IsDocumentViewerShow;
            }
            set
            {
                if (_IsDocumentViewerShow != value)
                {
                    _IsDocumentViewerShow = value;
                    RaisePropertyChanged("IsDocumentViewerShow");
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

        NumberToEnglish num = new NumberToEnglish();

        #endregion

        #region List
        private List<ACC_T004_Flip> _FlipGridData;
        public List<ACC_T004_Flip> FlipGridData
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

        public List<ADM_M003> _plantList;
        public List<ADM_M003> plantList
        {
            get { return _plantList; }
            set
            {
                _plantList = value;
                RaisePropertyChanged("plantList");
            }
        }

        public List<ADM_M002> _CompanyList;
        public List<ADM_M002> CompanyList
        {
            get { return _CompanyList; }
            set
            {
                _CompanyList = value;
                RaisePropertyChanged("CompanyList");
            }
        }

        private int _dgSelectedIndexItem;
        public int dgSelectedIndexItem
        {
            get
            {
                return _dgSelectedIndexItem;
            }
            set
            {
                if (_dgSelectedIndexItem != value)
                {
                    _dgSelectedIndexItem = value;
                    RaisePropertyChanged("dgSelectedIndexItem");

                }
            }
        }
        #endregion

        #region Collection

        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }

        //ItemListForPopup
        private ICollectionView _popupItemCollection;
        public ICollectionView PopupItemCollection
        {
            get { return _popupItemCollection; }
            set { _popupItemCollection = value; RaisePropertyChanged("PopupItemCollection"); }
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

        #region Filters

        // Filter For BackFlip

        private string _FilterStringFlipGridData;
        public string FilterStringFlipGridData
        {
            get { return _FilterStringFlipGridData; }
            set
            {
                _FilterStringFlipGridData = value;
                RaisePropertyChanged("FilterStringFlipGridData");
                Filter_FlipGrid();
            }
        }
        private void Filter_FlipGrid()
        {
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as ACC_T004_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringFlipGridData))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.fin_year != null && data.fin_year.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower()));
                }
                return true;
            }
            return false;
        }

        // Filter For Item
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

        #region Relay Command
        #region Relay Command : Master ACC_T004
        public RelayCommand<object> cmdInsertFinYear { get; private set; }
        public RelayCommand<object> cmdInsertPostingPeriod { get; private set; }
        //public RelayCommand<object> CmdInsertCompCode { get; private set; }
        public RelayCommand<object> CmdInsertLocation { get; private set; }
        #endregion

        #region Relay Command : Detail ACC_T004_A
        public RelayCommand<object> CmdInsertGenLedger { get; private set; }
        public RelayCommand<object> CmdInsertCurrency { get; private set; }
        #endregion

        #region Relay Command : View Tab
        public RelayCommand<object> CommandLoadHistory { get; private set; }
        public RelayCommand<object> CommandFltrStatus { get; private set; }
        #endregion
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByDocumentNumber { get; private set; }
        #endregion

        #region Construtor
        public FICO_T015_VM(string ts_code) : base()

        {
            IsDocumentViewerShow = false;
            MasterEntity = new ACC_T004();
            ItemsEntity = new ObservableCollection<ACC_T004_A>();
            FlipGridData = new List<ACC_T004_Flip>();
            MC = new MultipleContext_ACC_T004();
            MCTemp = new MultipleContext_ACC_T004();
            MasterEntity.ValidateAsync().Wait();

            ACC_T004.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            ACC_T004_A.ModelEntityUpdated += new EventHandler(ModelUpdated_AmtConversion);

            #region Relay Command Initialisation

            #region Relay Command Initialisation : Master

            cmdInsertFinYear = new RelayCommand<object>(items => { if (items == null) { return; } InsertFinYear(items); });
            cmdInsertPostingPeriod = new RelayCommand<object>(items => { if (items == null) { return; } InsertPostingPeriod(items); });

            //CmdInsertCompCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompCode(items); });

            #endregion

            #region Relay Command Initialisation : Detail

            CmdInsertGenLedger = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertGeneralLedger(cmdPara, true, true, true); });
            CmdInsertCurrency = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCurrency(cmdPara, false, true, true); });
            #endregion

            #region Relay Command Initialisation : View Tab
            CommandLoadHistory = new RelayCommand<object>(items => { if (items == null) { return; } LoadHistory(); });
            CommandFltrStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrStatus(items); });
            #endregion

            CommandLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            CmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });

            #endregion

            LoadInitialData();
            if (AppSessionState.TransValue != null)
            {
                LoadDocumentByDocumentNumber(AppSessionState.TransValue, "DocumentNo");
                AppSessionState.TransValue = null;
                AppSessionState.TransParameter = null;
                AppSessionState.ViewOtherRecordAllowed = true;
            }
        }
        private void LoadInitialData()
        {
            try
            {
                MasterEntity.doc_cat = "OB";
                MasterEntity.doc_type = "OB";
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_T004>(MC, Request, "Opening_Balance", "Finance", " ", 0, "");

                //FlipGridData = MC.DocumentDataFlipGrid.ToList();
                //FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                //FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                PopupItemCollection = CollectionViewSource.GetDefaultView(MC.GeneralLedgerList);
                PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);

                #region Auto_Suggest Initialisation

                #region Auto_Suggest Initialisation : Master

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M001A_P)x).fin_year);
                TheFilter = (o, prefix) => ((ACC_M001A_P)o).fin_year.ToString().ToLower().Contains(prefix.ToLower());
                ASFinYear = new AutoSuggestTextViewModel<dynamic>(MC.FinYearList, TheFilter, SuggestedValue, "fin_year", true);
                ASFinYear.AutoSuggestVM.IsEmptyValueAllowed = true;

                CompanyList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCompCode = new AutoSuggestTextViewModel<dynamic>(CompanyList, TheFilter, SuggestedValue, "comp_code", true);
                ASCompCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion

                #region Auto_Suggest Initialisation : Details

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((General_Ledger_P)x).ledger_gen);
                TheFilter = (o, prefix) => (((General_Ledger_P)o).ledger_gen ?? "").ToString().ToLower().Contains(prefix) || (((General_Ledger_P)o).ledger_gen_desc ?? "").ToString().ToLower().Contains(prefix);
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.GeneralLedgerList, TheFilter, SuggestedValue, "ledger_gen", "ledger_gen", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((General_Ledger_P)x).ledger_gen);
                TheFilter = (o, prefix) => (((General_Ledger_P)o).ledger_gen ?? "").ToString().ToLower().Contains(prefix) || (((General_Ledger_P)o).ledger_gen_desc ?? "").ToString().ToLower().Contains(prefix);
                ASGeneralLedger_dg = new AutoSuggestTextViewModel<dynamic>(MC.GeneralLedgerList, TheFilter, SuggestedValue, "ledger_gen", "ledger_gen", true);
                ASGeneralLedger_dg.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASGeneralLedger_dg.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToString().ToLower().Contains(prefix) || (((ADM_M037_P)o).curr_name ?? "").ToString().ToLower().Contains(prefix);
                ASCurrency_dg = new AutoSuggestTextViewModel<dynamic>(MC.CurrencyList, TheFilter, SuggestedValue, "doc_curr_code", "curr_code", true);
                ASCurrency_dg.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASCurrency_dg.AutoSuggestVM.IsFreeTextAllowed = true;

                #endregion

                //Filters AutoSuggest
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASFltrt_status = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_display", true);
                ASFltrt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion

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

        #endregion

        #region Relay Command Implementation
        #region Relay Command Implementation : Master
        private void InsertFinYear(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M001A_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.FinYearList.Where(x => x.fin_year.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M001A_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.fin_year = POPUPEntityObject.fin_year;

                    //Filter Collection Posting Period
                    List<ACC_M001A_P> SelectedPostingPeriod = (from o in MC.PostPeriodList
                                                               where o.fin_year == MasterEntity.fin_year
                                                               select o).ToList();

                    // Posting Period PopUp
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M001A_P)x).posting_period);
                    TheFilter = (o, prefix) => (((ACC_M001A_P)o).posting_period ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M001A_P)o).long_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASPostingPeriod = new AutoSuggestTextViewModel<dynamic>(SelectedPostingPeriod, TheFilter, SuggestedValue, "posting_period", false);
                    ASPostingPeriod.AutoSuggestVM.IsEmptyValueAllowed = true;
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
        private void InsertPostingPeriod(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M001A_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PostPeriodList.Where(x => x.posting_period.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M001A_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.posting_period = POPUPEntityObject.posting_period;
                    MasterEntity.postingPrd_desc = POPUPEntityObject.long_desc;
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
        //private void InsertCompCode(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M002 POPUPEntityObject = null;

        //        #region Command Parameter Read Section
        //        try
        //        {

        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUPEntityObject = CompanyList.Where(x => x.comp_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null)
        //            {
        //                if (((IEnumerable)InputValue).Cast<ADM_M002>().Count() > 0)
        //                {
        //                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002>().ToList()[0];
        //                }
        //            }
        //        }
        //        catch (Exception ex) { }

        //        #endregion
        //        if (POPUPEntityObject != null)
        //        {
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;

        //        }
        //        var msg = new NotificationMessage("FICO_T015_VM");
        //        Messenger.Default.Send<NotificationMessage>(msg);
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();
        //    }

        //}
        #endregion

        #region Relay Command Implementation : Items

        private void InsertGeneralLedger(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                General_Ledger_P POPUPEntityObject = null;

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

                    if (NewRow == true && (AllowDuplicate == true) && ItemsEntity.Count == dgSelectedIndexItem)
                    {
                        ItemsEntity.Add(new ACC_T004_A()
                        {
                            line_id = 0,
                            id = 0,

                            ledger_gen = POPUPEntityObject.ledger_gen,
                            ledger_gen_desc = POPUPEntityObject.ledger_gen_desc,
                            gl_code = POPUPEntityObject.gl_code,
                            acc_type = POPUPEntityObject.acc_type,

                            location_Id = AppSessionState.OBJ_LOCATION.location_id,
                            comp_code = AppSessionState.OBJ_COMPANY.comp_code,
                            editby = AppSessionState.UserID,
                            add_by = AppSessionState.UserID,
                            t_status = "001",
                            t_display = "Draft",

                            active = true,
                            exc_rate = 1.00M,

                        });
                    }
                    else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            ItemsEntity[dgSelectedIndexItem].line_id = 0;
                            ItemsEntity[dgSelectedIndexItem].ledger_gen = POPUPEntityObject.ledger_gen;
                            ItemsEntity[dgSelectedIndexItem].ledger_gen_desc = POPUPEntityObject.ledger_gen_desc;
                            ItemsEntity[dgSelectedIndexItem].gl_code = POPUPEntityObject.gl_code;
                            ItemsEntity[dgSelectedIndexItem].acc_type = POPUPEntityObject.acc_type;
                            ItemsEntity[dgSelectedIndexItem].active = true;
                            ItemsEntity[dgSelectedIndexItem].location_Id = AppSessionState.OBJ_LOCATION.location_id;
                            ItemsEntity[dgSelectedIndexItem].comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                            ItemsEntity[dgSelectedIndexItem].add_by = AppSessionState.UserID;
                            ItemsEntity[dgSelectedIndexItem].editby = AppSessionState.UserID;
                            ItemsEntity[dgSelectedIndexItem].t_status = "001";
                            ItemsEntity[dgSelectedIndexItem].t_status = "Draft";
                            ItemsEntity[dgSelectedIndexItem].exc_rate = 1.00M;

                        }
                        else if (ItemsEntity[dgSelectedIndexItem].ledger_gen != POPUPEntityObject.ledger_gen)
                        {
                            ItemsEntity[dgSelectedIndexItem].ledger_gen = POPUPEntityObject.ledger_gen;
                            ItemsEntity[dgSelectedIndexItem].ledger_gen_desc = POPUPEntityObject.ledger_gen_desc;
                            ItemsEntity[dgSelectedIndexItem].gl_code = POPUPEntityObject.gl_code;
                            ItemsEntity[dgSelectedIndexItem].acc_type = POPUPEntityObject.acc_type;
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

        //private async void InsertItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        //{
        //    try
        //    {
        //        string Request = "";
        //        General_Ledger_P POPUPEntityObject = null;
        //        dgSelectedIndexItem = dgSelectedIndexItem;
        //        #region Command Parameter Read Section
        //        // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
        //        if (InputValue.GetType() == typeof(string) && InputValue != null)
        //        {
        //            //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
        //            Request = InputValue.ToString();
        //            if (Request.Length > 0)
        //            {
        //                try
        //                {
        //                    POPUPEntityObject = MC.GeneralLedgerList.Where(x => x.ledger_gen.Equals(Request, StringComparison.OrdinalIgnoreCase) == true ).ToList()[0];
        //                }
        //                catch (Exception ex) { }
        //            }
        //        }
        //        else if (InputValue != null)
        //        {
        //            POPUPEntityObject = ((IEnumerable)InputValue).Cast<General_Ledger_P>().ToList()[0];
        //        }

        //        #endregion

        //        if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
        //        {
        //            var InputValueIfExists = ItemsEntity.Where(X => X.ledger_gen == POPUPEntityObject.ledger_gen).FirstOrDefault(); // Prefer Primary Key for this instruction.
        //            int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.ledger_gen == POPUPEntityObject.ledger_gen).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
        //            var LineId = ItemsEntity.Count + 1;

        //            if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
        //            {
        //                ItemsEntity.Add(new ACC_T004_A()
        //                {        
        //                    line_id = LineId,
        //                    id = 0,
        //                    t_status = "001",
        //                    t_display = "Draft",
        //                    active = true,
        //                    exc_rate = 1.00M,
        //                    gl_code = POPUPEntityObject.gl_code,
        //                    acc_type = POPUPEntityObject.acc_type,
        //                    ledger_gen = POPUPEntityObject.ledger_gen,
        //                    ledger_gen_desc = POPUPEntityObject.ledger_gen_desc,
        //                });
        //            }
        //            else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
        //            {
        //                if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
        //                {
        //                    if (ItemsEntity[dgSelectedIndexItem].line_id == 0)
        //                    {
        //                        ItemsEntity[dgSelectedIndexItem].line_id = ItemsEntity.Count;
        //                    }
        //                    ItemsEntity[dgSelectedIndexItem].id = 0;
        //                    ItemsEntity[dgSelectedIndexItem].t_status = "001";
        //                    ItemsEntity[dgSelectedIndexItem].t_display = "Draft";
        //                    ItemsEntity[dgSelectedIndexItem].active = true;
        //                    ItemsEntity[dgSelectedIndexItem].exc_rate = 1.00M;

        //                    ItemsEntity[dgSelectedIndexItem].ledger_gen = POPUPEntityObject.ledger_gen;
        //                    ItemsEntity[dgSelectedIndexItem].acc_type = POPUPEntityObject.acc_type;
        //                    ItemsEntity[dgSelectedIndexItem].gl_code = POPUPEntityObject.gl_code;
        //                    ItemsEntity[dgSelectedIndexItem].ledger_gen_desc = POPUPEntityObject.ledger_gen_desc;
        //                }
        //                else if (ItemsEntity[dgSelectedIndexItem].ledger_gen != POPUPEntityObject.ledger_gen)
        //                {
        //                    ItemsEntity[dgSelectedIndexItem].ledger_gen = POPUPEntityObject.ledger_gen;
        //                    ItemsEntity[dgSelectedIndexItem].ledger_gen_desc = POPUPEntityObject.ledger_gen_desc;
        //                    ItemsEntity[dgSelectedIndexItem].gl_code = POPUPEntityObject.gl_code;
        //                    ItemsEntity[dgSelectedIndexItem].acc_type = POPUPEntityObject.acc_type;
        //                }
        //            }


        //        }
        //        #region Clear Empty Row
        //        ACC_T004_A newObj = new ACC_T004_A();
        //        for (int i = ItemsEntity.Count - 1; i >= 0; i--)
        //        {
        //            bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
        //            if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
        //            {
        //                ItemsEntity.RemoveAt(i);
        //                if (ItemsEntity.Count == 0)
        //                {
        //                    ItemsEntity.Add(newObj);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();
        //    }
        //    #endregion
        //}
        //private void InsertGeneralLedger(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        //{
        //    try
        //    {
        //        string Request = "";
        //        General_Ledger_P POPUPEntityObject = null;

        //        #region Command Parameter Read Section
        //        // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
        //        if (InputValue.GetType() == typeof(string) && InputValue != null)
        //        {
        //            Request = InputValue.ToString();
        //            if (Request.Length > 0)
        //            {
        //                try
        //                { POPUPEntityObject = MC.GeneralLedgerList.Where(x => x.ledger_gen.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                catch (Exception ex) { }
        //            }
        //        }
        //        else if (InputValue != null)
        //        {
        //            if (((IEnumerable)InputValue).Cast<General_Ledger_P>().Count() > 0)
        //            {
        //                POPUPEntityObject = ((IEnumerable)InputValue).Cast<General_Ledger_P>().ToList()[0];
        //            }
        //        }

        //        #endregion

        //        if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
        //        {
        //            if (MasterEntity.fin_year != null && MasterEntity.fin_year != "")
        //            {
        //                //var InputValueIfExists = DetailEntity.Where(X => X.gl_code == POPUPEntityObject.gl_name).FirstOrDefault(); // Prefer Primary Key for this instruction.
        //                //int IndexOfExistValue = DetailEntity.IndexOf(DetailEntity.Where(X => X.gl_code == POPUPEntityObject.gl_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

        //                if (NewRow == true && (AllowDuplicate == true) && ItemsEntity.Count == dgSelectedIndexItem)
        //                {
        //                    ItemsEntity.Add(new ACC_T004_A()
        //                    {
        //                        id = 0,
        //                        t_status = "001",
        //                        t_display = "Draft",
        //                        active = true,
        //                        exc_rate = 1.00M,
        //                        gl_code = POPUPEntityObject.gl_code,
        //                        acc_type = POPUPEntityObject.acc_type,
        //                        ledger_gen = POPUPEntityObject.ledger_gen,
        //                        ledger_gen_desc = POPUPEntityObject.ledger_gen_desc,
        //                    });
        //                }
        //                else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
        //                {
        //                    if (ItemsEntity[dgSelectedIndexItem].id == 0) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True
        //                    {
        //                        ItemsEntity[dgSelectedIndexItem].id =0;
        //                        ItemsEntity[dgSelectedIndexItem].t_status = "001";
        //                        ItemsEntity[dgSelectedIndexItem].t_display = "Draft";
        //                        ItemsEntity[dgSelectedIndexItem].active = true;
        //                        ItemsEntity[dgSelectedIndexItem].exc_rate = 1.00M;

        //                        ItemsEntity[dgSelectedIndexItem].ledger_gen = POPUPEntityObject.ledger_gen;
        //                        ItemsEntity[dgSelectedIndexItem].acc_type = POPUPEntityObject.acc_type;
        //                        ItemsEntity[dgSelectedIndexItem].gl_code = POPUPEntityObject.gl_code;
        //                        ItemsEntity[dgSelectedIndexItem].ledger_gen_desc = POPUPEntityObject.ledger_gen_desc;
        //                    }
        //                    else if (ItemsEntity[dgSelectedIndexItem].ledger_gen != POPUPEntityObject.ledger_gen)
        //                    {
        //                        ItemsEntity[dgSelectedIndexItem].ledger_gen = POPUPEntityObject.ledger_gen;
        //                        ItemsEntity[dgSelectedIndexItem].ledger_gen_desc = POPUPEntityObject.ledger_gen_desc;
        //                        ItemsEntity[dgSelectedIndexItem].gl_code = POPUPEntityObject.gl_code;
        //                        ItemsEntity[dgSelectedIndexItem].acc_type = POPUPEntityObject.acc_type;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //                showMessageService.ButtonSetup = DialogButton.Ok;
        //                showMessageService.Caption = "Message";
        //                showMessageService.Text = String.Format("please select Fin Year...");
        //                showMessageService.ShowMessage();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();
        //    }
        //}
        private void InsertCurrency(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M037_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.CurrencyList.Where(x => x.curr_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M037_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M037_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ItemsEntity.Count > dgSelectedIndexItem) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                    {
                        ItemsEntity[dgSelectedIndexItem].doc_curr_code = POPUPEntityObject.curr_code;
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].doc_curr_code != POPUPEntityObject.curr_code)
                    {
                        ItemsEntity[dgSelectedIndexItem].doc_curr_code = POPUPEntityObject.curr_code;
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

        #region Relay Command Implementation : View Tab 
        private void InsertFltrStatus(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0013 POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.STATUS_LIST.Where(x => x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M0013>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0013>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.Fltr_t_status = POPUPEntityObject.t_status;
                    MasterEntity.Fltr_t_display = POPUPEntityObject.t_display;
                }
            }
            catch (Exception Ex) { }
        }
        private void LoadHistory()
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadHistory" + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.EmpId + "!@" + Convert.ToDateTime(MasterEntity.Fltr_FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.Fltr_ToDate).ToString("MM/dd/yyyy") + "!@" + MasterEntity.Fltr_t_status + "!@" + MasterEntity.Fltr_active + "!@" + AppSessionState.client;
                MCTemp1 = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_T004>(MCTemp1, Request, "Opening_Balance", "Finance", "LoadHistory", 0, "");

                MC.DocDataFlipGridList = MCTemp1.DocDataFlipGridList;
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(MC.DocDataFlipGridList);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                var msg = new NotificationMessage("FICO_T015_VM");
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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";

                ACC_T004_Flip ParameterEntityObject = null;
                MasterEntity = new ACC_T004();
                ItemsEntity = new ObservableCollection<ACC_T004_A>();

                if (((IEnumerable)ParameterObject).Cast<ACC_T004_Flip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ACC_T004_Flip>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.doc_no;
                    SelectedTabControlIndex = 0;
                    isNewRecord = false;

                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ACC_T004>(MCTemp, Request, "Opening_Balance", "Finance", "LoadDocumentByDocumentNumber", 0, "");

                    if (MCTemp.MasterEntityList.Count > 0)
                    {
                        MasterEntity = MCTemp.MasterEntityList[0];
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("This Record Is Inactive...");
                        showMessageService.ShowMessage();
                    }


                    ItemsEntity = MCTemp.ItemsEntityList;
                    if (MC.GeneralLedgerList != null && ItemsEntity.Count > 0)
                    {
                        foreach (var item in ItemsEntity)
                        {
                            item.ledger_gen_desc = (from o in MC.GeneralLedgerList
                                                    where o.ledger_gen == item.ledger_gen
                                                    select o.ledger_gen_desc).FirstOrDefault();
                        }
                    }


                    if (MCTemp.AttachmentList != null)
                    {
                        AttachmentCollection = MCTemp.AttachmentList;
                    }
                    else
                    {
                        MCTemp.AttachmentList = new List<COM_T003>();
                    }

                }
                SetPopupSuggestionDataAfterLoad();

                var msg = new NotificationMessage("FICO_T015_VM");
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
                ASFinYear.AutoSuggestVM.Suggestion = MC.FinYearList.Find(x => x.fin_year == MasterEntity.fin_year);
                ASCompCode.AutoSuggestVM.Suggestion = CompanyList.Find(x => x.comp_code == MasterEntity.comp_code);
                ASPostingPeriod.AutoSuggestVM.Suggestion = MC.PostPeriodList.Find(x => x.posting_period == MasterEntity.posting_period);
            }
            catch (Exception ex) { }
        }

        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ItemsEntity[dgSelectedIndexItem].id == 0)
                {
                    ItemsEntity.RemoveAt(i);
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

        #region User Defined Functions
        private void DefaultValues()
        {
            try
            {
                MasterEntity.doc_cat = "OB";
                MasterEntity.doc_type = "OB";
                MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;

                var tempt_display = (from o in MC.STATUS_LIST
                                     where o.t_status == MasterEntity.t_status
                                     select o).ToList();
                MasterEntity.t_display = tempt_display[0].t_display;
                MasterEntity.t_status = tempt_display[0].t_status;

                MasterEntity.doc_no = "";
                MasterEntity.posting_period = "1";
                MasterEntity.doc_date = DateTime.Now;
                MasterEntity.post_date = DateTime.Now;
                MasterEntity.active = true;

                DateTime d = DateTime.UtcNow;
                d = d.AddMonths(-1);
                MasterEntity.Fltr_FrmDate = d;
                MasterEntity.Fltr_ToDate = DateTime.UtcNow;
                MasterEntity.Fltr_active = true;

                MasterEntity.Fltr_active = true;

                MasterEntity.exc_rate = 1.00M;
            }
            catch (Exception ex) { }

        }
        private void Logging()
        {
            //MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;

            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private bool Validation()
        {
            try
            {
                if (MasterEntity.comp_code == null || MasterEntity.comp_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Company Code Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.fin_year == null || MasterEntity.fin_year == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Financial Year Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.posting_period == null || MasterEntity.posting_period == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Posting Period Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }

                if (ItemsEntity.Count < 1)
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Atleast One Record In Opening Detail...");
                    showMessageService.ShowMessage();
                    return false;
                }
                if (dgSelectedIndexItem != -1)
                {
                    foreach (var o in ItemsEntity)
                    {
                        if (o.ledger_gen == null || o.ledger_gen == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Required";
                            showMessageService.Text = String.Format("General Ledger Number Is Required", this.Title);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.doc_curr_code == null || o.doc_curr_code == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Required";
                            showMessageService.Text = String.Format("Please select Currency", this.Title);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.gl_code == null || o.gl_code == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Required";
                            showMessageService.Text = String.Format("Please select Currency", this.Title);
                            showMessageService.ShowMessage();
                            return false;
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
            return true;
        }

        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = MasterEntity.HasErrors;
        }
        void ModelUpdated_AmtConversion(object sender, EventArgs e)
        {
            try
            {
                //This will get called when the property of an object inside the collection changes
                if (sender.ToString() == "debit_amt_dc" || sender.ToString() == "credit_amt_dc" || sender.ToString() == "exc_rate" || sender.ToString() == "active")
                {
                    Computation();
                }

            }
            catch (Exception ex) { }
        }
        private void Computation()
        {
            try
            {
                if (ItemsEntity.Count > 0 && dgSelectedIndexItem != -1)
                {
                    ItemsEntity[dgSelectedIndexItem].credit_amt_lc = ItemsEntity[dgSelectedIndexItem].credit_amt_dc * ItemsEntity[dgSelectedIndexItem].exc_rate;
                    ItemsEntity[dgSelectedIndexItem].debit_amt_lc = ItemsEntity[dgSelectedIndexItem].debit_amt_dc * ItemsEntity[dgSelectedIndexItem].exc_rate;

                    if (ItemsEntity[dgSelectedIndexItem].exc_rate != null)
                    {
                        ItemsEntity[dgSelectedIndexItem].credit_amt_lc = ItemsEntity[dgSelectedIndexItem].credit_amt_dc * ItemsEntity[dgSelectedIndexItem].exc_rate;
                        ItemsEntity[dgSelectedIndexItem].debit_amt_lc = ItemsEntity[dgSelectedIndexItem].debit_amt_dc * ItemsEntity[dgSelectedIndexItem].exc_rate;
                    }

                    ItemsEntity[dgSelectedIndexItem].balance_amt_dc = ItemsEntity[dgSelectedIndexItem].debit_amt_dc - ItemsEntity[dgSelectedIndexItem].credit_amt_dc;
                    ItemsEntity[dgSelectedIndexItem].balance_amt_lc = ItemsEntity[dgSelectedIndexItem].debit_amt_lc - ItemsEntity[dgSelectedIndexItem].credit_amt_lc;
                }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Event Handler

        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<ACC_T004> result)
        {
            try
            {
                isNewRecord = true;
                MasterEntity = new ACC_T004();
                MasterEntity.ValidateAsync().Wait();
                ItemsEntity = new ObservableCollection<ACC_T004_A>();
                ItemsEntity.Clear();
                DefaultValues();
                var msg = new NotificationMessage("FICO_T015_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex) { }
        }

        protected override void OnDiscardAction(InquiryActionResult<ACC_T004> result)
        {

        }

        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.doc_no.ToString()))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.ToString(), DocumentList = MCTemp.AttachmentList, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<ACC_T004> result)
        {
            LoadInitialData();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_T004> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_T004> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<ACC_T004> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<ACC_T004> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<ACC_T004> result)
        {

        }

        protected override void OnRemoveAction(InquiryActionResult<ACC_T004> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text =
                String.Format(
                    "This record will be Deleted forever '{0}'",
                        this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
                this.MasterEntity.EndEdit();
                string response = repository.Delete(MasterEntity.doc_no, "Opening_Balance", "Finance");


                MasterEntity = new ACC_T004();
                ItemsEntity = new ObservableCollection<ACC_T004_A>();

                isNewRecord = true;

                FlipDataGridCollection.Refresh();
            }
        }

        protected override void OnSaveAction(InquiryActionResult<ACC_T004> result)
        {
            try
            {
                if (Validation() == true)
                {
                    foreach (var item in ItemsEntity)
                    {
                        item.ref_doc_no = item.bill_doc_no;
                        item.ref_doc_date = item.bill_doc_date;
                    }

                    Logging();
                    MasterEntity.XmlDataDocument_ACC_T004_A = obj.ObjectToXML(ItemsEntity);

                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ACC_T004>(MasterEntity, "Opening_Balance", "Finance");

                        if (MasterEntity.doc_no != null || MasterEntity.doc_no != " ")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Saved Successfully");
                            showMessageService.ShowMessage();
                        }
                    }

                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ACC_T004>(MasterEntity, "Opening_Balance", "Finance");

                        if (MasterEntity.doc_no != null || MasterEntity.doc_no != " ")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Updated Successfully");
                            showMessageService.ShowMessage();
                        }
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");

                    isNewRecord = false;

                }
                var msg = new NotificationMessage("FICO_T015_VM");
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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_ACC_T004_A != null)
                {
                    ItemsEntity.Clear();
                    ItemsEntity = (ObservableCollection<ACC_T004_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T004_A, MC.ItemsEntityList);

                    if (MC.GeneralLedgerList != null && ItemsEntity.Count > 0)
                    {
                        foreach (var item in ItemsEntity)
                        {
                            item.ledger_gen_desc = (from o in MC.GeneralLedgerList
                                                    where o.ledger_gen == item.ledger_gen
                                                    select o.ledger_gen_desc).FirstOrDefault();
                        }
                    }
                }
                else
                {
                    MC.ItemsEntityList = new ObservableCollection<ACC_T004_A>();
                }

                if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocDataFlipGridList = (List<ACC_T004_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocDataFlipGridList);
                    FlipGridData.Add(MC.DocDataFlipGridList[0]);
                    FlipDataGridCollection.Refresh();
                    FlipDataGridCollection.SortDescriptions.Add(new SortDescription("doc_no", ListSortDirection.Descending));
                }

                var msg = new NotificationMessage("FICO_T015_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch { }
        }



        #endregion
    }
}
