using System;
using Reflection.BusinessEntity.Finance;
using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.FICO.ViewModels
{
    class FICO_T014_VM : WorkspaceViewModel<ACC_T006>
    {
        #region AutoSuggest TextBox Declaration Region
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASBank { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBank
        {
            get { return _ASBank; }
            set
            {
                if (_ASBank != value)
                {
                    _ASBank = value;
                    RaisePropertyChanged("ASBank");
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
                    _ASFinYear = value;
                    RaisePropertyChanged("ASFinYear");
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
                    _ASPostingPeriod = value;
                    RaisePropertyChanged("ASPostingPeriod");
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
                    }
                }
            }
            catch (Exception ex) { }
        }

        #endregion

        #region Declaration
        bool isNewRecord = true;
        bool isValidDate = true;

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
                    _MC = value;

                    RaisePropertyChanged("MC");
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
                    _MCTemp = value;
                    RaisePropertyChanged("MCTemp");
                }
            }
        }

        private int _dgSelectedIndex;
        public int dgSelectedIndex
        {
            get
            {
                return _dgSelectedIndex;
            }
            set
            {
                if (_dgSelectedIndex != value)
                {

                    _dgSelectedIndex = value;
                    RaisePropertyChanged("dgSelectedIndex");
                }
            }
        }

        private List<ACC_M004_P> _BankListCollection;
        public List<ACC_M004_P> BankListCollection
        {
            get { return _BankListCollection; }
            set
            {
                if (_BankListCollection != value)
                {
                    _BankListCollection = value;
                    RaisePropertyChanged("BankListCollection");
                }
            }
        }

        private ObservableCollection<ACC_T006_A> _BankRecoEntity;
        public ObservableCollection<ACC_T006_A> BankRecoEntity
        {
            get { return _BankRecoEntity; }
            set
            {
                if (_BankRecoEntity != value)
                {
                    _BankRecoEntity = value;
                    RaisePropertyChanged("BankListCollection");
                }
            }
        }

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

        private SearchEntity _SearchEntityObject;
        public SearchEntity SearchEntityObject
        {
            get
            {
                return _SearchEntityObject;
            }
            set
            {
                if (_SearchEntityObject != value)
                {
                    _SearchEntityObject = value;
                    RaisePropertyChanged(nameof(SearchEntityObject));
                }
            }
        }

        #endregion Variable Declaration

        #region ICollectionView
        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            private set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private List<ACC_T006> _RequestList;
        public List<ACC_T006> RequestList
        {
            get { return _RequestList; }
            set
            {
                if (_RequestList != value)
                {
                    _RequestList = value;
                    RaisePropertyChanged("RequestList");
                }
            }
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

        private ICollectionView _selectedGridCollection;
        public ICollectionView SelectedGridCollection
        {
            get { return _selectedGridCollection; }
            private set { _selectedGridCollection = value; RaisePropertyChanged("SelectedGridCollection"); }
        }

        #endregion ICollectionView

        #region Relay Commands Declaration
        public RelayCommand<object> CommandViewDocument { get; private set; }
        public RelayCommand<object> cmdLoad { get; private set; }
        public RelayCommand<object> CmdInsertBank { get; private set; }
        public RelayCommand<object> CmdInsertFinYear { get; private set; }
        public RelayCommand<object> CmdInsertPostingPeriod { get; private set; }
        public RelayCommand<object> cmdExportGrid { get; private set; }
        //public RelayCommand<object> CommandCompany { get; private set; }

        #endregion Relay Commands Declaration

        #region   Selected List

        private ACC_T006 _masterentity;
        public ACC_T006 MasterEntity
        {
            get { return _masterentity; }

            set
            {
                if (_masterentity != value)
                {
                    _masterentity = value;

                    RaisePropertyChanged("MasterEntity");

                }
            }

        }

        private ACC_T006_A _DetailList;
        public ACC_T006_A DetailList
        {
            get { return _DetailList; }

            set
            {
                if (_DetailList != value)
                {
                    _DetailList = value;

                    RaisePropertyChanged("DetailList");

                }
            }
        }
        private List<ACC_T006_A> _SelectedList;
        public List<ACC_T006_A> SelectedList
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

        private List<string> _StrListBank;
        public List<string> StrListBank
        {
            get
            {

                return _StrListBank;
            }
            set
            {
                if (_StrListBank != value)
                {
                    _StrListBank = value;

                    RaisePropertyChanged("StrListBank");

                }
            }
        }

        #endregion Selected List

        #region Constructor
        public FICO_T014_VM(string ts_code) : base()
        {
            SearchEntityObject = new SearchEntity();
            RequestList = new List<ACC_T006>();
            MasterEntity = new ACC_T006();
            BankRecoEntity = new ObservableCollection<ACC_T006_A>();
            //DetailEntity = new List<ACC_T006_A>();
            //DetailEntity = new ObservableCollection<ACC_T006_A>();
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            cmdLoad = new RelayCommand<object>(items => { if (items == null) { return; } LoadBankRecoDetails(); });

            //CommandCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            CmdInsertBank = new RelayCommand<object>(items => { if (items == null) { return; } InsertBank(items); });
            CmdInsertFinYear = new RelayCommand<object>(items => { if (items == null) { return; } InsertFinYear(items); });
            CmdInsertPostingPeriod = new RelayCommand<object>(items => { if (items == null) { return; } InsertPostingPeriod(items); });
            cmdExportGrid = new RelayCommand<object>(items => { if (items == null) { return; } ExportDocument(items); });

            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
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
        private void LoadInitialData()
        {
            try
            {
                MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                string Request = "LoadInitialDataBankReco" + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_T006>(MC, Request, "BankReco", "Finance", "LoadAll", 0, "");

                CompList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CompanyList = (from o in CompList where o.comp_code == AppSessionState.OBJ_COMPANY.comp_code select o).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M002)o).CompName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASComapny = new AutoSuggestTextViewModel<dynamic>(CompanyList, TheFilter, SuggestedValue, "comp_code", true);
                ASComapny.AutoSuggestVM.IsEmptyValueAllowed = false;

                //Bank PopUp
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M004_P)x).bank_code);
                TheFilter = (o, prefix) => (((ACC_M004_P)o).hb_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M004_P)o).bank_name ?? "").ToString().ToLower().Contains(prefix.ToLower())
                                        || (((ACC_M004_P)o).bank_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M004_P)o).bank_key ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASBank = new AutoSuggestTextViewModel<dynamic>(MC.BanksMaster, TheFilter, SuggestedValue, "para1", true);
                ASBank.AutoSuggestVM.IsEmptyValueAllowed = true;

                //Financial Year PopUp
                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M001A_P)x).fin_year);
                //TheFilter = (o, prefix) => ((ACC_M001A_P)o).fin_year.ToString().ToLower().Contains(prefix.ToLower());
                //ASFinYear = new AutoSuggestTextViewModel<dynamic>(MC.FinYearMaster, TheFilter, SuggestedValue, "fin_year", true);
                //ASFinYear.AutoSuggestVM.IsEmptyValueAllowed = true;

                SearchEntityObject.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                SearchEntityObject.client = AppSessionState.client;
                SearchEntityObject.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                SearchEntityObject.EmpId = AppSessionState.EmpId;
                SearchEntityObject.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                SearchEntityObject.from_date = DateTime.Now;
                SearchEntityObject.to_date = DateTime.Now;
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

        private void InsertBank(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M004_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.BanksMaster.Where(x => x.hb_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M004_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M004_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    // MasterEntity.bank_no_payee = POPUPEntityObject.bank_code;
                    SearchEntityObject.para1 = POPUPEntityObject.hb_code;
                    SearchEntityObject.para2 = POPUPEntityObject.bank_name;
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
        //private void InsertBank(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ACC_M004_P POPUPEntityObject = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUPEntityObject = MC.BanksMaster.Where(x => x.bank_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M004_P>().Count() > 0)
        //            {
        //                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M004_P>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }

        //        #endregion
        //        if (POPUPEntityObject != null)
        //        {
        //            MasterEntity.bank_no_payee = POPUPEntityObject.bank_code;
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
                            { POPUPEntityObject = MC.FinYearMaster.Where(x => x.fin_year.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.fin_year_Sclr = POPUPEntityObject.fin_year;

                    //Filter Collection Posting Period
                    List<ACC_M001A_P> SelectedPostingPeriod = (from o in MC.PostingPeriodMaster
                                                               where o.fin_year == MasterEntity.fin_year_Sclr
                                                               select o).ToList();

                    // Posting Period PopUp
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M001A_P)x).posting_period);
                    TheFilter = (o, prefix) => (((ACC_M001A_P)o).posting_period ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M001A_P)o).long_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASPostingPeriod = new AutoSuggestTextViewModel<dynamic>(SelectedPostingPeriod, TheFilter, SuggestedValue, "posting_period_Sclr", true);
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
                            { POPUPEntityObject = MC.FinYearMaster.Where(x => x.posting_period.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.posting_period_Sclr = POPUPEntityObject.posting_period;
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
        //private void InsertCompany(object InputValue)
        //{
        //    string Request = "";
        //    ADM_M002 POPUPEntityObject = null;
        //    #region Command Parameter Read Section
        //    try
        //    {
        //        // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
        //        if (InputValue.GetType() == typeof(string) && InputValue != null)
        //        {
        //            Request = InputValue.ToString();
        //            if (Request.Length > 0)
        //            {
        //                try
        //                { POPUPEntityObject = CompList.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                catch (Exception ex) { }
        //            }
        //        }
        //        else if (InputValue != null)
        //        {
        //            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002>().ToList()[0];
        //        }
        //        if (POPUPEntityObject != null) // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
        //        {
        // NOTE: why this three field are important?
        //            SearchEntityObject.comp_code = POPUPEntityObject.comp_code;
        //            SearchEntityObject.para3 = POPUPEntityObject.CompName;
        //            SearchEntityObject.ItemCode = POPUPEntityObject.curr_code;
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
        private void LoadBankRecoDetails()
        {
            try
            {
                if ((SearchEntityObject.comp_code != "" || SearchEntityObject.comp_code != null) ||
                    (SearchEntityObject.para1 != "" || SearchEntityObject.para1 != null))
                {

                    string Request = "LoadBankRecoDetails" + "!@" + Convert.ToDateTime(SearchEntityObject.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(SearchEntityObject.to_date).ToString("MM/dd/yyyy") + "!@" + SearchEntityObject.comp_code + "!@" + SearchEntityObject.para1 + "!@" + SearchEntityObject.active.ToString();
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_T006>(MCTemp, Request, "BankReco", "Finance", "", 0, "");

                    isNewRecord = false;

                    DataGridCollection = CollectionViewSource.GetDefaultView(MCTemp.DetailData);
                    DataGridCollection.Filter = new Predicate<object>(Filter);
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Following Fields Are Mandatory \n1.Bank \n2.Financial Year\n3.Posting Period \nPlease select all them and Try Again... ");
                    showMessageService.ShowMessage();
                }
            }
            catch (Exception ex) { }
        }

        private void ExportDocument(object InputValue)
        {
            try
            {
                ExportToExcel<ACC_T006_A, List<ACC_T006_A>> exportList = new ExportToExcel<ACC_T006_A, List<ACC_T006_A>>();
                exportList.ListCollectionData = SelectedList;
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

        #endregion

        #region Abstract Command Actions
        protected override void OnCreateAction(InquiryActionResult<ACC_T006> result)
        {
            try
            {
                MasterEntity = new ACC_T006();
                DetailList = new ACC_T006_A();
                SelectedList = new List<ACC_T006_A>();

                var msg = new NotificationMessage("FICO_T014_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex) { }
        }
        protected override void OnPrintAction(InquiryActionResult<ACC_T006> result)
        { }
        protected override void OnDocumentAction()
        {

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

                List<ACC_T006_A> temp = new List<ACC_T006_A>();

                foreach (var item in MCTemp.DetailData) //Only sends items where reconcile = true
                {
                    if (item.reconcile == true)
                    {
                        temp.Add(item);
                    }
                }

                if (temp.Count > 0)//validations
                {
                    foreach (var o in temp)
                    {
                        if (o.clrg_date == null || o.clrg_date == Convert.ToDateTime("01 / 01 / 0001 00:00:00"))
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please select Clearing Date");
                            showMessageService.ShowMessage();
                            isValidDate = false;
                        }
                        else
                        {
                            isValidDate = true;
                        }

                    }
                }

                MasterEntity.XmlDataDocument_ACC_T006_A = obj.ObjectToXML(temp);
                Logging();
                if (isNewRecord == false && isValidDate == true)
                {
                    string str = repository.Update<ACC_T006>(MasterEntity, "BankReco", "Finance");

                    if (temp.Count > 0) //refresh collection after save
                    {
                        foreach (var item in temp)
                        {
                            if (item.reconcile == true)
                            {
                                MCTemp.DetailData.Remove(item);
                            }
                        }

                        DataGridCollection = CollectionViewSource.GetDefaultView(MCTemp.DetailData);
                        DataGridCollection.Filter = new Predicate<object>(Filter);
                    }
                }
                var msg = new NotificationMessage("FICO_T014_VM");
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

        #region Filters
        private string _filterString_DataGrid;
        public string FilterString_DataGrid
        {
            get { return _filterString_DataGrid; }
            set
            {
                _filterString_DataGrid = value;
                RaisePropertyChanged("FilterString_DataGrid");
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
            var data = obj as ACC_T006_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_DataGrid))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_DataGrid.ToLower())) ||
                           (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_DataGrid.ToLower())) ||
                           (data.curr_code != null && data.curr_code.ToString().ToLower().Contains(_filterString_DataGrid.ToLower())) ||
                           (data.gl_code != null && data.gl_code.ToString().ToLower().Contains(_filterString_DataGrid.ToLower())) ||
                           (data.exc_rate != null && data.exc_rate.ToString().ToLower().Contains(_filterString_DataGrid.ToLower())) ||
                           (data.doc_curr_amt != null && data.doc_curr_amt.ToString().ToLower().Contains(_filterString_DataGrid.ToLower())) ||
                           (data.loc_curr_amt != null && data.loc_curr_amt.ToString().ToLower().Contains(_filterString_DataGrid.ToLower())) ||
                           (data.dc_ind != null && data.dc_ind.ToString().ToLower().Contains(_filterString_DataGrid.ToLower()));
                }
                return true;
            }
            return false;
        }



        #endregion
    }
}
